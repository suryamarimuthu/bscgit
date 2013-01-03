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

public partial class eis_SEM_Mana_R030 : System.Web.UI.Page
{
    int type = 0;
    string strY01 = "";
    string strY02 = "";
    string strY03 = "";
    string strY04 = "";
    string strY05 = "";
    string strY06 = "";

    string[] arrHdrNm = new string[6] {"Y01","Y02","Y03","Y04","Y05","Y06"};

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
            string[] arrMM = new string[6] {"01","03","05","07","09","11"};
            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            if (intMM % 2 == 0)
            {
                intMM = intMM - 1;
            }

            this.cboYY.Items.Clear();
            this.cboMM.Items.Clear();
            this.cboCom.Items.Clear();

            for (intLP = 0; intLP < arrMM.Length; intLP++)
            {
                strMM = arrMM[intLP].ToString();
                this.cboMM.Items.Add(new ListItem(strMM, strMM));
                if (intMM == int.Parse(strMM))
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY+3; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }

            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));

            this.cboGbn.Items.Add(new ListItem("월별", "01"));
            this.cboGbn.Items.Add(new ListItem("추이", "02"));

            this.cboYY.SelectedValue = intYY.ToString();
            /// </summary>
        }
    }

    private void _queryGrid(bool blnPostYn)
    {
        string strCYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strYM = strCYY + strMM;
        string strCom = this.cboCom.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R029.PROC_Mana_R029_01", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        OracleParameter[] arrOpm = new OracleParameter[9];
        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = strYM;
        arrOpm[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 10);
        arrOpm[1].Value = strCom;
        arrOpm[2] = new OracleParameter("O_YYMM01", OracleType.VarChar,8);
        arrOpm[2].Direction = ParameterDirection.Output;
        arrOpm[3] = new OracleParameter("O_YYMM02", OracleType.VarChar, 8);
        arrOpm[3].Direction = ParameterDirection.Output;
        arrOpm[4] = new OracleParameter("O_YYMM03", OracleType.VarChar, 8);
        arrOpm[4].Direction = ParameterDirection.Output;
        arrOpm[5] = new OracleParameter("O_YYMM04", OracleType.VarChar, 8);
        arrOpm[5].Direction = ParameterDirection.Output;
        arrOpm[6] = new OracleParameter("O_YYMM05", OracleType.VarChar, 8);
        arrOpm[6].Direction = ParameterDirection.Output;
        arrOpm[7] = new OracleParameter("O_YYMM06", OracleType.VarChar, 8);
        arrOpm[7].Direction = ParameterDirection.Output;
        arrOpm[8] = new OracleParameter("O_Mana_R029", OracleType.Cursor);
        arrOpm[8].Direction = ParameterDirection.Output;

        for (int i = 0; i<arrOpm.Length;i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        strY01 = objCmd.Parameters["O_YYMM01"].Value.ToString();
        strY02 = objCmd.Parameters["O_YYMM02"].Value.ToString();
        strY03 = objCmd.Parameters["O_YYMM03"].Value.ToString();
        strY04 = objCmd.Parameters["O_YYMM04"].Value.ToString();
        strY05 = objCmd.Parameters["O_YYMM05"].Value.ToString();
        strY06 = objCmd.Parameters["O_YYMM06"].Value.ToString();

        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {

        e.Layout.Bands[0].HeaderLayout.Reset();
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader[] arrCh = new Infragistics.WebUI.UltraWebGrid.ColumnHeader[6];

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;

            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Key = "GUBUN";
        ch.Caption = "구     분";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        int intSpan = 2;
        for (int i = 0; i < arrCh.Length; i++)
        {
            arrCh[i] = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            switch (i)
            {
                case 0:

                    arrCh[i].Caption = strY01;
                    break;
                case 1:
                    arrCh[i].Caption = strY02;
                    break;
                case 2:
                    arrCh[i].Caption = strY03;
                    break;
                case 3:
                    arrCh[i].Caption = strY04;
                    break;
                case 4:
                    arrCh[i].Caption = strY05;
                    break;
                case 5:
                    arrCh[i].Caption = strY06;
                    break;
                default:
                    break;
            }
            arrCh[i].Key = arrHdrNm[i].ToString();
            arrCh[i].RowLayoutColumnInfo.OriginY = 0;
            arrCh[i].RowLayoutColumnInfo.OriginX = intSpan;
            arrCh[i].RowLayoutColumnInfo.SpanX = 3;
            arrCh[i].Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(arrCh[i]);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            intSpan = intSpan + 3;
        }
    }
}