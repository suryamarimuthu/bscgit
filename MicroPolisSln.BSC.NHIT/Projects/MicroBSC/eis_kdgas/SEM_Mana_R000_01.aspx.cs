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
using Dundas.Gauges.WebControl;

public partial class eis_SEM_Mana_R000_01 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
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
            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            this.cboGbn.SelectedIndex = 0;
        }
    }

    private void _queryGrid()
    {
        string strYY = "";
        string strMM = "";
        string strDD = "";
        string strYMD = "";
        DateTime dtYMD = Convert.ToDateTime(sDate.Value.ToString());

        strYY = dtYMD.Year.ToString();
        strMM = (dtYMD.Month > 9) ? dtYMD.Month.ToString() : ("0" + dtYMD.Month.ToString());
        strDD = (dtYMD.Day > 9) ? dtYMD.Day.ToString() : ("0" + dtYMD.Day.ToString());

        strYMD = strYY+strMM+strDD;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R001.PROC_Mana_R001_01", _connection);
        OracleCommand objCmdBoard1 = new OracleCommand("PKG_SEM_Mana_R000.PROC_Mana_R000_01", _connection);
        OracleCommand objCmdBoard2 = new OracleCommand("PKG_SEM_Mana_R000.PROC_Mana_R000_02", _connection);
        OracleCommand objCmdBoard3 = new OracleCommand("PKG_SEM_Mana_R000.PROC_Mana_R000_03", _connection);
        OracleCommand objCmdBoard4 = new OracleCommand("PKG_SEM_Mana_R000.PROC_Mana_R000_04", _connection);

        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;
        objCmdBoard1.CommandType = CommandType.StoredProcedure;
        objCmdBoard2.CommandType = CommandType.StoredProcedure;
        objCmdBoard3.CommandType = CommandType.StoredProcedure;
        objCmdBoard4.CommandType = CommandType.StoredProcedure;


        //================================================================== Graph Query ( 사업장 : 전체)
        OracleParameter[] arrOpmGrph = new OracleParameter[4];

        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = (strYMD);
        arrOpmGrph[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpmGrph[1].Value = "";
        arrOpmGrph[2] = new OracleParameter("i_SGUBUN", OracleType.VarChar, 2);
        arrOpmGrph[2].Value = "HS";
        arrOpmGrph[3] = new OracleParameter("O_Mana_R001", OracleType.Cursor);
        arrOpmGrph[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);

        //================================================================== Dash Board 1
        OracleParameter[] arrOpmBrd1 = new OracleParameter[3];

        arrOpmBrd1[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmBrd1[0].Value = (strYMD);
        arrOpmBrd1[1] = new OracleParameter("i_GUBUN", OracleType.VarChar, 12);
        arrOpmBrd1[1].Value = cboGbn.SelectedValue;
        arrOpmBrd1[2] = new OracleParameter("O_Mana_R000", OracleType.Cursor);
        arrOpmBrd1[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmBrd1.Length; i++)
        {
            objCmdBoard1.Parameters.Add(arrOpmBrd1[i]);
        }

        DataSet dsBoard1 = new DataSet();
        OracleDataAdapter daBoard1 = new OracleDataAdapter(objCmdBoard1);
        daBoard1.Fill(dsBoard1);
        this.setDashBoard1(dsBoard1);

        //================================================================== Dash Board 2
        OracleParameter[] arrOpmBrd2 = new OracleParameter[3];

        arrOpmBrd2[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmBrd2[0].Value = (strYMD);
        arrOpmBrd2[1] = new OracleParameter("i_GUBUN", OracleType.VarChar, 12);
        arrOpmBrd2[1].Value = cboGbn.SelectedValue;
        arrOpmBrd2[2] = new OracleParameter("O_Mana_R000", OracleType.Cursor);
        arrOpmBrd2[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmBrd2.Length; i++)
        {
            objCmdBoard2.Parameters.Add(arrOpmBrd2[i]);
        }

        DataSet dsBoard2 = new DataSet();
        OracleDataAdapter daBoard2 = new OracleDataAdapter(objCmdBoard2);
        daBoard2.Fill(dsBoard2);
        this.setDashBoard2(dsBoard2);

        //================================================================== Dash Board 3
        OracleParameter[] arrOpmBrd3 = new OracleParameter[3];

        arrOpmBrd3[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmBrd3[0].Value = (strYMD);
        arrOpmBrd3[1] = new OracleParameter("i_GUBUN", OracleType.VarChar, 12);
        arrOpmBrd3[1].Value = cboGbn.SelectedValue;
        arrOpmBrd3[2] = new OracleParameter("O_Mana_R000", OracleType.Cursor);
        arrOpmBrd3[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmBrd3.Length; i++)
        {
            objCmdBoard3.Parameters.Add(arrOpmBrd3[i]);
        }

        DataSet dsBoard3 = new DataSet();
        OracleDataAdapter daBoard3 = new OracleDataAdapter(objCmdBoard3);
        daBoard1.Fill(dsBoard3);
        this.setDashBoard3(dsBoard3);

        //================================================================== Dash Board 4
        OracleParameter[] arrOpmBrd4 = new OracleParameter[3];

        arrOpmBrd4[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmBrd4[0].Value = (strYMD);
        arrOpmBrd4[1] = new OracleParameter("i_GUBUN", OracleType.VarChar, 12);
        arrOpmBrd4[1].Value = cboGbn.SelectedValue;
        arrOpmBrd4[2] = new OracleParameter("O_Mana_R000", OracleType.Cursor);
        arrOpmBrd4[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmBrd4.Length; i++)
        {
            objCmdBoard4.Parameters.Add(arrOpmBrd4[i]);
        }

        DataSet dsBoard4 = new DataSet();
        OracleDataAdapter daBoard4 = new OracleDataAdapter(objCmdBoard4);
        daBoard4.Fill(dsBoard4);
        this.setDashBoard4(dsBoard4);

    }

    private void setDashBoard1(DataSet iDsSet)
    {
        int intRow = iDsSet.Tables[0].Rows.Count;
        if (intRow > 0)
        {
            txtBrd1_1.Text = double.Parse(iDsSet.Tables[0].Rows[0][0].ToString()).ToString("#,##0");
            txtBrd1_2.Text = double.Parse(iDsSet.Tables[0].Rows[0][1].ToString()).ToString("#,##0");
            txtBrd1_3.Text = double.Parse(iDsSet.Tables[0].Rows[0][2].ToString()).ToString("#,##0");
            txtBrd1_4.Text = double.Parse(iDsSet.Tables[0].Rows[0][3].ToString()).ToString("#,##0.#0");
            txtBrd1_5.Text = double.Parse(iDsSet.Tables[0].Rows[0][4].ToString()).ToString("#,##0.#0");
            //GaugeContainer1.CircularGauges["Default"].Scales[0].Maximum = double.Parse(iDsSet.Tables[0].Rows[0][3].ToString()).ToString();

            GaugeContainer1.CircularGauges["Default"].Ranges.Add("MaxRange");
            CircularRange range = GaugeContainer1.CircularGauges["Default"].Ranges["MaxRange"];
            range.FillColor = Color.Lime;
            range.FillGradientEndColor = Color.Red;
            range.FillGradientType = RangeGradientType.StartToEnd;

            // Set range border attributes
            range.BorderColor = Color.Black;
            range.BorderWidth = 0;

            // Set range start and end values
            range.StartValue = double.Parse(iDsSet.Tables[0].Rows[0][3].ToString()) - 20;
            range.EndValue = double.Parse(iDsSet.Tables[0].Rows[0][3].ToString());

            // Set range width
            range.StartWidth = 4;
            range.EndWidth = 8;

            GaugeContainer1.CircularGauges["Default"].Pointers["Default"].Value = Convert.ToDouble(iDsSet.Tables[0].Rows[0][3].ToString());
        }
        else
        {
            txtBrd1_1.Text = "0";
            txtBrd1_2.Text = "0";
            txtBrd1_3.Text = "0";
            txtBrd1_4.Text = "0";
            txtBrd1_5.Text = "0";
        }
        return;
    }

    private void setDashBoard2(DataSet iDsSet)
    {
        int intRow = iDsSet.Tables[0].Rows.Count;
        if (intRow > 0)
        {
            txtBrd2_1.Text = double.Parse(iDsSet.Tables[0].Rows[0][0].ToString()).ToString("#,##0");
            txtBrd2_2.Text = double.Parse(iDsSet.Tables[0].Rows[0][1].ToString()).ToString("#,##0");
            txtBrd2_3.Text = double.Parse(iDsSet.Tables[0].Rows[0][2].ToString()).ToString("#,##0");
            txtBrd2_4.Text = double.Parse(iDsSet.Tables[0].Rows[0][3].ToString()).ToString("#,##0.#0");
            txtBrd2_5.Text = double.Parse(iDsSet.Tables[0].Rows[0][4].ToString()).ToString("#,##0.#0");
            GaugeContainer2.CircularGauges["Default"].Pointers["Default"].Value = Convert.ToDouble(iDsSet.Tables[0].Rows[0][3].ToString());
        }
        else
        {
            txtBrd2_1.Text = "0";
            txtBrd2_2.Text = "0";
            txtBrd2_3.Text = "0";
            txtBrd2_4.Text = "0";
            txtBrd2_5.Text = "0";
        }
        return;
    }

    private void setDashBoard3(DataSet iDsSet)
    {
        int intRow = iDsSet.Tables[0].Rows.Count;
        if (intRow > 0)
        {
            txtBrd3_1.Text = double.Parse(iDsSet.Tables[0].Rows[0][0].ToString()).ToString("#,##0");
            txtBrd3_2.Text = double.Parse(iDsSet.Tables[0].Rows[0][1].ToString()).ToString("#,##0");
            txtBrd3_3.Text = double.Parse(iDsSet.Tables[0].Rows[0][2].ToString()).ToString("#,##0");
            txtBrd3_4.Text = double.Parse(iDsSet.Tables[0].Rows[0][3].ToString()).ToString("#,##0.#0");
            txtBrd3_5.Text = double.Parse(iDsSet.Tables[0].Rows[0][4].ToString()).ToString("#,##0.#0");
            GaugeContainer3.CircularGauges["Default"].Pointers["Default"].Value = Convert.ToDouble(iDsSet.Tables[0].Rows[0][3].ToString());
        }
        else
        {
            txtBrd3_1.Text = "0";
            txtBrd3_2.Text = "0";
            txtBrd3_3.Text = "0";
            txtBrd3_4.Text = "0";
            txtBrd3_5.Text = "0";
        }
        return;
    }

    private void setDashBoard4(DataSet iDsSet)
    {
        int intRow = iDsSet.Tables[0].Rows.Count;
        if (intRow > 0)
        {
            txtBrd4_1.Text = double.Parse(iDsSet.Tables[0].Rows[0][0].ToString()).ToString("#,##0");
            txtBrd4_2.Text = double.Parse(iDsSet.Tables[0].Rows[0][1].ToString()).ToString("#,##0");
            txtBrd4_3.Text = double.Parse(iDsSet.Tables[0].Rows[0][2].ToString()).ToString("#,##0");
            txtBrd4_4.Text = double.Parse(iDsSet.Tables[0].Rows[0][3].ToString()).ToString("#,##0.#0");
            txtBrd4_5.Text = double.Parse(iDsSet.Tables[0].Rows[0][4].ToString()).ToString("#,##0.#0");
            GaugeContainer4.CircularGauges["Default"].Pointers["Default"].Value = Convert.ToDouble(iDsSet.Tables[0].Rows[0][3].ToString());
        }
        else
        {
            txtBrd4_1.Text = "0";
            txtBrd4_2.Text = "0";
            txtBrd4_3.Text = "0";
            txtBrd4_4.Text = "0";
            txtBrd4_5.Text = "0";
        }
        return;
    }


                          
}

