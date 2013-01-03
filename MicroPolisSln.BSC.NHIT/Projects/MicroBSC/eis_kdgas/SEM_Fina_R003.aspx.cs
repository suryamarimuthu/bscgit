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

public partial class eis_SEM_Fina_R003 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txt_4001000000_01.Style.Add("text-align", "right");
            txt_4001000000_02.Style.Add("text-align", "right");
            txt_4001000000_03.Style.Add("text-align", "right");
            txt_4003000000_01.Style.Add("text-align", "right");
            txt_4003000000_02.Style.Add("text-align", "right");
            txt_4003000000_03.Style.Add("text-align", "right");
            txt_4005000000_01.Style.Add("text-align", "right");
            txt_4005000000_02.Style.Add("text-align", "right");
            txt_4005000000_03.Style.Add("text-align", "right");
            txt_4007000000_01.Style.Add("text-align", "right");
            txt_4007000000_02.Style.Add("text-align", "right");
            txt_4007000000_03.Style.Add("text-align", "right");
            txt_4009000000_01.Style.Add("text-align", "right");
            txt_4009000000_02.Style.Add("text-align", "right");
            txt_4009000000_03.Style.Add("text-align", "right");
            txt_4011000000_01.Style.Add("text-align", "right");
            txt_4011000000_02.Style.Add("text-align", "right");
            txt_4011000000_03.Style.Add("text-align", "right");
            txt_4013000000_01.Style.Add("text-align", "right");
            txt_4013000000_02.Style.Add("text-align", "right");
            txt_4013000000_03.Style.Add("text-align", "right");
            txt_4015000000_01.Style.Add("text-align", "right");
            txt_4015000000_02.Style.Add("text-align", "right");
            txt_4015000000_03.Style.Add("text-align", "right");
            txt_4017000000_01.Style.Add("text-align", "right");
            txt_4017000000_02.Style.Add("text-align", "right");
            txt_4017000000_03.Style.Add("text-align", "right");
            txt_4019000000_01.Style.Add("text-align", "right");
            txt_4019000000_02.Style.Add("text-align", "right");
            txt_4019000000_03.Style.Add("text-align", "right");
            txt_4021000000_01.Style.Add("text-align", "right");
            txt_4021000000_02.Style.Add("text-align", "right");
            txt_4021000000_03.Style.Add("text-align", "right");
            txt_4025000000_01.Style.Add("text-align", "right");
            txt_4025000000_02.Style.Add("text-align", "right");
            txt_4025000000_03.Style.Add("text-align", "right");
        }

        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this._queryGrid();
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

            
            this.cboYY.Items.Clear();

            for (intLP = 1; intLP < 13; intLP++)
            {
                if (intLP < 10)
                {
                    strMM = "0" + intLP.ToString();
                }
                else
                {
                    strMM = intLP.ToString();
                }

                this.cboMM.Items.Add(new ListItem(strMM, strMM));
                this.cboTMM.Items.Add(new ListItem(strMM, strMM));
                if (intMM-1 == intLP)
                {
                    this.cboMM.SelectedValue = strMM;
                    this.cboTMM.SelectedValue = strMM;
                }

            }

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
                this.cboTYY.Items.Add(new ListItem(strYY, strYY));
            }
            cboYY.SelectedValue = intYY.ToString();
            cboTYY.SelectedValue = intYY.ToString();

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));
            this.cboCom.SelectedIndex = 0;
        }
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        string sYMD = GetByValueDropDownList(cboYY) + GetByValueDropDownList(cboMM);
        string eYMD = GetByValueDropDownList(cboTYY) + GetByValueDropDownList(cboTMM);
        string[] saTerm = GetMonthDiff(sYMD, eYMD, "M");

        if (!(saTerm.Length >= 1 && saTerm.Length <= 12))
        {
            AlertMessage("[12개월] 이내에서만 조회 가능합니다!");
            return;
        }

        string sqlGrid = "";

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Fina_R003.PROC_Fina_R003_01", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[4];
        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = (strYY+strMM);
        arrOpm[1] = new OracleParameter("i_TOYM", OracleType.VarChar, 8);
        arrOpm[1].Value = (cboTYY.SelectedValue+cboTMM.SelectedValue);
        arrOpm[2] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpm[2].Value = cboCom.SelectedValue.ToString();
        arrOpm[3] = new OracleParameter("O_Fina_R003", OracleType.Cursor);
        arrOpm[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        try
        {
            DataSet dsGrid = new DataSet();
            OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
            daGrid.Fill(dsGrid);
            this.setTextBox(dsGrid);
        }
        catch (Exception e)
        {
            txt_4001000000_01.Text = Convert.ToString(0);
            txt_4001000000_02.Text = Convert.ToString(0.0);
            txt_4001000000_03.Text = Convert.ToString(0.0);
            txt_4003000000_01.Text = Convert.ToString(0);
            txt_4003000000_02.Text = Convert.ToString(0.0);
            txt_4003000000_03.Text = Convert.ToString(0.0);
            txt_4005000000_01.Text = Convert.ToString(0);
            txt_4005000000_02.Text = Convert.ToString(0.0);
            txt_4005000000_03.Text = Convert.ToString(0.0);
            txt_4007000000_01.Text = Convert.ToString(0);
            txt_4007000000_02.Text = Convert.ToString(0.0);
            txt_4007000000_03.Text = Convert.ToString(0.0);
            txt_4009000000_01.Text = Convert.ToString(0);
            txt_4009000000_02.Text = Convert.ToString(0.0);
            txt_4009000000_03.Text = Convert.ToString(0.0);
            txt_4011000000_01.Text = Convert.ToString(0);
            txt_4011000000_02.Text = Convert.ToString(0.0);
            txt_4011000000_03.Text = Convert.ToString(0.0);
            txt_4013000000_01.Text = Convert.ToString(0);
            txt_4013000000_02.Text = Convert.ToString(0.0);
            txt_4013000000_03.Text = Convert.ToString(0.0);
            txt_4015000000_01.Text = Convert.ToString(0);
            txt_4015000000_02.Text = Convert.ToString(0.0);
            txt_4015000000_03.Text = Convert.ToString(0.0);
            txt_4017000000_01.Text = Convert.ToString(0);
            txt_4017000000_02.Text = Convert.ToString(0.0);
            txt_4017000000_03.Text = Convert.ToString(0.0);
            txt_4019000000_01.Text = Convert.ToString(0);
            txt_4019000000_02.Text = Convert.ToString(0.0);
            txt_4019000000_03.Text = Convert.ToString(0.0);
            txt_4021000000_01.Text = Convert.ToString(0);
            txt_4021000000_02.Text = Convert.ToString(0.0);
            txt_4021000000_03.Text = Convert.ToString(0.0);
            txt_4025000000_01.Text = Convert.ToString(0);
            txt_4025000000_02.Text = Convert.ToString(0.0);
            txt_4025000000_03.Text = Convert.ToString(0.0);
            return;
        }

        _connection.Close();
        _connection = null;
        objCmd = null;

        
    }

    private void setTextBox(DataSet dsTxt)
    {
        int intRow = dsTxt.Tables[0].Rows.Count;
        string strAcctNm  = "";
        string strAcctCd  = "";
        double dblAddAmt  = 0.00;
        double dblSaleAmt = 0.00;
        double dblAcctAmt = 0.00;
        for (int i = 0; i < intRow; i++)
        {
            strAcctCd  = dsTxt.Tables[0].Rows[i][0].ToString();
            strAcctNm  = dsTxt.Tables[0].Rows[i][1].ToString();
            dblAcctAmt = Convert.ToDouble(dsTxt.Tables[0].Rows[i][2].ToString());
            dblAddAmt  = Convert.ToDouble(dsTxt.Tables[0].Rows[i][3].ToString());
            dblSaleAmt = Convert.ToDouble(dsTxt.Tables[0].Rows[i][4].ToString());
            

            switch (strAcctCd)
            {
                case "4001000000": // 당기순이익
                    //lbl_4001000000_01.Text = strAcctNm;
                    txt_4001000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4001000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4001000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4003000000": // 매출액
                    //lbl_4003000000_01.Text = strAcctNm;
                    txt_4003000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4003000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4003000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4005000000": // 매출원가
                    //lbl_4005000000_01.Text = strAcctNm;
                    txt_4005000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4005000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4005000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4007000000": // 매출총이익
                    //lbl_4007000000_01.Text = strAcctNm;
                    txt_4007000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4007000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4007000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4009000000": // 판매비와 일반관리비
                    //lbl_4009000000_01.Text = strAcctNm;
                    txt_4009000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4009000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4009000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4011000000": // 영업이익
                    //lbl_4011000000_01.Text = strAcctNm;
                    txt_4011000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4011000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4011000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4013000000": // 영업외수익
                    //lbl_4013000000_01.Text = strAcctNm;
                    txt_4013000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4013000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4013000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4015000000": // 영업외수익
                    //lbl_4015000000_01.Text = strAcctNm;
                    txt_4015000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4015000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4015000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4017000000": // 경상이익
                    //lbl_4017000000_01.Text = strAcctNm;
                    txt_4017000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4017000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4017000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4019000000": // 특별이익
                    //lbl_4019000000_01.Text = strAcctNm;
                    txt_4019000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4019000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4019000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4021000000": // 특별손실
                    //lbl_4021000000_01.Text = strAcctNm;
                    txt_4021000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4021000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4021000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                case "4025000000": // 법인세비용
                    //lbl_4025000000_01.Text = strAcctNm;
                    txt_4025000000_01.Text = dblAcctAmt.ToString("#,##0");
                    txt_4025000000_02.Text = dblAddAmt.ToString("#,##0.0%");
                    txt_4025000000_03.Text = dblSaleAmt.ToString("#,##0.0%");
                    break;
                default:
                    break;
            }
        }
    }
}