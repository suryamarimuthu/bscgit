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
using MicroBSC.Data.Oracle;
using System.Text;

public partial class eis_SEM_Mana_R002 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
    }

    private void _initForm(bool blnGbn)
    {
        /// <summary>
        /// 폼초기화 및 기본값 세팅
        /// 
        if (!blnGbn)
        {
            this.cboTCom.Items.Add(new ListItem("전체", "99"));
            this.cboTCom.Items.Add(new ListItem("울산", "21"));
            this.cboTCom.Items.Add(new ListItem("양산", "51"));
            this.cboTCom.SelectedIndex = 0;

            DateTime dtSYMD = Convert.ToDateTime(sDate.Value.ToString());
            DateTime dtEYMD = Convert.ToDateTime(eDate.Value.ToString());

            dtSYMD = dtSYMD.AddDays(-1);
            dtEYMD = dtEYMD.AddDays(-1);

            sDate.Value = dtSYMD;
            eDate.Value = dtEYMD;

            this._queryGrid();

        }
    }

    private void _queryGrid()
    {
        string strYY = "";
        string strMM = "";
        string strDD = "";
        string strSYMD = "";
        string strEYMD = "";
        int intDateDiff = 0;

        DateTime dtSYMD = Convert.ToDateTime(sDate.Value.ToString());
        DateTime dtEYMD = Convert.ToDateTime(eDate.Value.ToString());

        System.TimeSpan dtSpen = (dtEYMD - dtSYMD);
        intDateDiff = dtSpen.Days;

        strYY = dtSYMD.Year.ToString();
        strMM = (dtSYMD.Month > 9) ? dtSYMD.Month.ToString() : ("0" + dtSYMD.Month.ToString());
        strDD = (dtSYMD.Day > 9) ? dtSYMD.Day.ToString() : ("0" + dtSYMD.Day.ToString());
        strSYMD = strYY+strMM+strDD;

        strYY = dtEYMD.Year.ToString();
        strMM = (dtEYMD.Month > 9) ? dtEYMD.Month.ToString() : ("0" + dtEYMD.Month.ToString());
        strDD = (dtEYMD.Day > 9) ? dtEYMD.Day.ToString() : ("0" + dtEYMD.Day.ToString());
        strEYMD = strYY + strMM + strDD;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R001.PROC_Mana_R001_03", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[4];

        arrOpmGrph[0] = new OracleParameter("i_FR_YMD", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = strSYMD;
        arrOpmGrph[1] = new OracleParameter("i_TO_YMD", OracleType.VarChar, 8);
        arrOpmGrph[1].Value = strEYMD;
        arrOpmGrph[2] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpmGrph[2].Value = cboTCom.SelectedValue;
        arrOpmGrph[3] = new OracleParameter("O_Mana_R001", OracleType.Cursor);
        arrOpmGrph[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);
        this._setGraph(dsGrph, intDateDiff);
    }

    private void _setGraph(DataSet dsLine, int iDateDiff)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 400
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series[] oasrType = new Series[3]; //Series[dsLine.Tables[0].Rows.Count];
        string strCYY = "";
        string strOYY = "";
        string strNYY = "";
        string strYMD = "";
        double dblQtn = 0.00;
        int intLP = 0;
        int intSE = 0;
        int intRow = dsLine.Tables[0].Rows.Count;

        for (intLP = 0; intLP < intRow; intLP++ )
        {
            strYMD = dsLine.Tables[0].Rows[intLP]["YMD"].ToString();
            strCYY = dsLine.Tables[0].Rows[intLP]["YY"].ToString() + "년";
            if (intLP == 0)
            {
                oasrType[intSE] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                        strCYY, null, SeriesChartType.Line, 2,
                                                        GetChartColor(intSE), GetChartColor(intSE), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                intSE += 1;
            }
            else
            {
                strOYY = dsLine.Tables[0].Rows[intLP - 1]["YY"].ToString();
                strNYY = dsLine.Tables[0].Rows[intLP]["YY"].ToString();

                if (strOYY == strNYY)
                {

                }
                else
                {
                    oasrType[intSE] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                            strCYY, null, SeriesChartType.Line, 2,
                                                            GetChartColor(intSE), GetChartColor(intSE), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                    intSE += 1;
                }
            }

            
            dblQtn = Convert.ToDouble(dsLine.Tables[0].Rows[intLP]["SPLY_QTN"].ToString());
            Chart1.Series[oasrType[intSE - 1].Name].Points.AddXY(strYMD, dblQtn);
            
        }

        //for (intLP = 0; intLP < intRow; intLP++ )
        //{
        //    strOYY = dsLine.Tables[0].Rows[intLP]["YY"].ToString();
        //    strNYY = (intLP == intRow-1) ? strOYY : dsLine.Tables[0].Rows[intLP + 1]["YY"].ToString();
        //    strYMD = dsLine.Tables[0].Rows[intLP]["YMD"].ToString();
        //    dblQtn = Convert.ToDouble(dsLine.Tables[0].Rows[intLP]["SPLY_QTN"].ToString());

        //    if ((intLP == 0) || (strOYY != strNYY))
        //    {
        //        oasrType[intSE] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
        //                                                strNYY, null, SeriesChartType.Line, 2,
        //                                                GetChartColor(intSE), GetChartColor(intSE), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //        intSE += 1;
        //    }
        //    Chart1.Series[oasrType[intSE - 1].Name].Points.AddXY(strYMD, dblQtn);
        //}


        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            if (iDateDiff > 6 && iDateDiff < 10)
            {
                oasrType[i].MarkerStyle = GetMarkerStyle(i);
                oasrType[i].MarkerColor = GetChartColor(i);
                oasrType[i].MarkerBorderColor = GetMarkerBorderColor(i);
            }

            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, false);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);
        }

        Chart1.ChartAreas[Chart1.Series[oasrType[0].Name].ChartArea].AxisX.Interval = (intRow == 0) ? 1 : float.Parse(Convert.ToString(intRow / 24));

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.DataSource = dsLine.Tables[0].DefaultView;
        Chart1.DataBind();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this._queryGrid();
    }

}
