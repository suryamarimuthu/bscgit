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

public partial class eis_SEM_Fina_R024 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this._queryGrid(Page.IsPostBack);
    }

    private void _initForm(bool blnGbn)
    {
        /// <summary>
        /// 폼초기화 및 기본값 세팅
        /// 
        if (!blnGbn)
        {
            DateTime objDT = DateTime.Now;
            string strYY;
            string strMM;

            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            this.cboYY.Items.Clear();
            this.cboMM.Items.Clear();
            this.cboComCd.Items.Clear();
            this.cboGubn.Items.Clear();

            for (intLP = 0; intLP < 13; intLP++)
            {
                if (intLP < 10)
                {
                    strMM = "0"+intLP.ToString();
                }
                else
                {
                    strMM = intLP.ToString();
                }

                this.cboMM.Items.Add(new ListItem(strMM, strMM));
                if (intMM-1 == int.Parse(strMM))
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY+3; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            this.cboYY.SelectedValue = intYY.ToString();

            this.cboComCd.Items.Add(new ListItem("전체", ""));
            this.cboComCd.Items.Add(new ListItem("울산", "01"));
            this.cboComCd.Items.Add(new ListItem("양산", "02"));
            this.cboComCd.SelectedIndex = 0;
            this.cboGubn.Items.Add(new ListItem("당월","MS"));
            this.cboGubn.Items.Add(new ListItem("누계","TS"));
            this.cboGubn.SelectedIndex = 0;            
            
            /// </summary>
        }
    }

    private void _queryGrid(bool blnPostYn)
    {
        string strCYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strYM = strCYY + strMM;
        

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Fina_R004.PROC_Fina_R004_02", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[4];
        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = strYM;
        arrOpm[1] = new OracleParameter("i_COM_CD", OracleType.VarChar, 10);
        arrOpm[1].Value = cboComCd.SelectedValue.ToString();
        arrOpm[2] = new OracleParameter("i_GUBN", OracleType.VarChar, 10);
        arrOpm[2].Value = cboGubn.SelectedValue.ToString();
        arrOpm[3] = new OracleParameter("O_Fina_R004", OracleType.Cursor);
        arrOpm[3].Direction = ParameterDirection.Output;

        for (int i = 0; i<arrOpm.Length;i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();
    }


    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 60;
                e.Layout.Bands[0].Columns[i].MergeCells = true;
            }
            else if (i == 1)
            {
                e.Layout.Bands[0].Columns[i].Width = 100;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 60;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
        
    }
    
}