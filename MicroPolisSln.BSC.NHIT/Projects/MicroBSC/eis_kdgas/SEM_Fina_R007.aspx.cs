using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
using System.Drawing;
using Dundas.Charting.WebControl;
using MicroCharts;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Data.Oracle;
using System.Text;


public partial class eis_SEM_Fina_R007 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitControlValue();
        }
        else
        {
            _queryGrid();
        }

    }

    #region 페이지 초기화 함수

        private void InitControlValue()
        {

            DateTime dtNow = System.DateTime.Now;

            string sMonth = "";

            this.ddlYear.Items.Clear();
            this.ddlMonth.Items.Clear();
            this.ddlGubun.Items.Clear();

            for (int i = dtNow.Year - 2; i <= dtNow.Year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i <= 12; i++)
            {
                sMonth = (i < 10 ? "0" + i.ToString() : i.ToString());
                this.ddlMonth.Items.Add(new ListItem(sMonth, sMonth));
            }

            //ddlGubun 에 아이템을 추가합니다.
            ddlGubun.Items.Add(new ListItem("안정성", "01"));
            ddlGubun.Items.Add(new ListItem("수익성", "02"));
            ddlGubun.Items.Add(new ListItem("활동성", "03"));
            ddlGubun.Items.Add(new ListItem("성장성", "04"));

            FindByValueDropDownList(ddlYear, dtNow.Year.ToString());
            FindByValueDropDownList(ddlMonth, (dtNow.AddMonths(-1).Month < 10 ? "0" + dtNow.AddMonths(-1).Month.ToString() : dtNow.AddMonths(-1).ToString()));

            _queryGrid();
        }

    #endregion

        private void _queryGrid()
        {
            string strYY = this.ddlYear.SelectedValue;
            string strMM = this.ddlMonth.SelectedValue;

            OracleConnection _connection = new OracleConnection();
            _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
            OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Fina_R007.PROC_Fina_R007_01", _connection);

            _connection.Open();

            objCmdGrid.CommandType = CommandType.StoredProcedure;

            OracleParameter[] arrOpmGrid = new OracleParameter[3];
            arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
            arrOpmGrid[0].Value = (strYY + strMM);
            arrOpmGrid[1] = new OracleParameter("i_GUBUN", OracleType.VarChar, 8);
            arrOpmGrid[1].Value = ddlGubun.SelectedValue;
            arrOpmGrid[2] = new OracleParameter("O_Fina_R007", OracleType.Cursor);
            arrOpmGrid[2].Direction = ParameterDirection.Output;

            for (int i = 0; i < arrOpmGrid.Length; i++)
            {
                objCmdGrid.Parameters.Add(arrOpmGrid[i]);
            }

            DataSet dsGrid = new DataSet();
            OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);

            daGrid.Fill(dsGrid);
            this._setGraph(dsGrid);

            UltraWebGrid1.Bands[0].ResetColumns();
            UltraWebGrid1.DataSource = dsGrid;
            UltraWebGrid1.DataBind();

            _connection.Close();
            _connection = null;

            objCmdGrid = null;
        }

        private void _setGraph(DataSet dsLine)
        {
            DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

            Series[] oasrType = new Series[dsLine.Tables[0].Columns.Count - 1];
            int intLP = 0;
            string strColNm = "";
            for (intLP = 1; intLP < dsLine.Tables[0].Columns.Count; intLP++ )
            {
                strColNm = dsLine.Tables[0].Columns[intLP].ColumnName;
                oasrType[intLP-1] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                        strColNm, null, SeriesChartType.Line, 3,
                                                        GetChartColor(intLP-1), GetChartColor(intLP-1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

                Chart1.Series[oasrType[intLP - 1].Name].ValueMemberX = "월";
                Chart1.Series[oasrType[intLP - 1].Name].ValueMembersY = strColNm;
            }

            Chart1.DataSource = dsLine;
            Chart1.DataBind();
            

            DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
            for (int i = 0; i < oasrType.Length; i++)
            {
                if (i == 0)
                    DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, true);
                else
                    DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);

                oasrType[i].MarkerStyle = GetMarkerStyle(i);
                oasrType[i].MarkerColor = GetChartColor(i);
                oasrType[i].MarkerBorderColor = GetChartColor(i);
            }

            Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0.0";
            Chart1.DataSource = dsLine.Tables[0].DefaultView;
            Chart1.DataBind();
         }

        protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        {
            try
            {
                int intWidth = 0;
                e.Layout.Bands[0].HeaderLayout.Reset();

                intWidth = ((e.Layout.Bands[0].Columns.Count - 1) > 0) ? Convert.ToInt32(720 / (e.Layout.Bands[0].Columns.Count - 1)) : 0;

                for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
                {

                    if (i == 0)
                    {
                        e.Layout.Bands[0].Columns[i].Width = 40;
                    }
                    else
                    {
                        e.Layout.Bands[0].Columns[i].Width = intWidth;
                        e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                        e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                }
            }
            catch
            {
            }
        }

}
