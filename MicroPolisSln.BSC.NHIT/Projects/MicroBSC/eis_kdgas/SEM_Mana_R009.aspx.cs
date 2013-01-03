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

public partial class eis_SEM_Mana_R009 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        //this._queryGrid();
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

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            cboYY.SelectedValue = intYY.ToString();

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
                if (intMM-1 == intLP)
                {
                    this.cboMM.SelectedValue = strMM;
                }

            }

            this.cboTCom.Items.Add(new ListItem("전체", ""));
            this.cboTCom.Items.Add(new ListItem("울산", "01"));
            this.cboTCom.Items.Add(new ListItem("양산", "02"));
            this.cboTCom.SelectedIndex = 0;

            this.cboGbnNew.Items.Add(new ListItem("전체", ""));
            this.cboGbnNew.Items.Add(new ListItem("주요", "M"));
            this.cboGbnNew.Items.Add(new ListItem("신규", "N"));
            this.cboGbnNew.SelectedIndex = 0;

            this.cboGbnSum.Items.Add(new ListItem("월계", "MS"));
            this.cboGbnSum.Items.Add(new ListItem("누계", "TS"));
            this.cboGbnSum.SelectedIndex = 0;
            
            this.cboName.Text  = "";

            this.setDBCombo();
            this._queryChart();
            this._queryGrid();
        }
    }
    private void setDBName()
    {
    	cboName.Text = "";
    	//UltraWebGrid1.ResetRows();
        //this._queryGrid();
    }

    private void setDBCombo()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R009.PROC_Mana_R009_02", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Combo Query
        OracleParameter[] arrOpm = new OracleParameter[4];

        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = (strYY);
        arrOpm[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpm[1].Value = cboTCom.SelectedValue;
        arrOpm[2] = new OracleParameter("i_GUBN", OracleType.VarChar, 12);
        arrOpm[2].Value = cboGbnNew.SelectedValue;
        arrOpm[3] = new OracleParameter("O_Mana_R009", OracleType.Cursor);
        arrOpm[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsCombo = new DataSet();
        OracleDataAdapter daCombo = new OracleDataAdapter(objCmd);

        daCombo.Fill(dsCombo);
        _connection.Close();
        objCmd = null;

        cboMCom.Items.Clear();
        cboName.Text = "";

        string strCd = "";
        string strNm = "";
        int intRow = dsCombo.Tables[0].Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            strCd = dsCombo.Tables[0].Rows[i]["COM_CD"].ToString();
            strNm = dsCombo.Tables[0].Rows[i]["COM_NM"].ToString();
            cboMCom.Items.Add(new ListItem(strNm, strCd));
        }
        cboMCom.SelectedIndex = 0;
    }
    private void _queryChart()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R009.PROC_Mana_R009_03", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Combo Query
        OracleParameter[] arrOpm = new OracleParameter[7];

        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = (strYY + strMM);
        arrOpm[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpm[1].Value = cboTCom.SelectedValue;
        arrOpm[2] = new OracleParameter("i_MCOMCD", OracleType.VarChar, 12);
        arrOpm[2].Value = cboMCom.SelectedValue;
        arrOpm[3] = new OracleParameter("i_GBN_NEWYN", OracleType.VarChar, 12);
        arrOpm[3].Value = cboGbnNew.SelectedValue;
        arrOpm[4] = new OracleParameter("i_GBN_SUMYN", OracleType.VarChar, 12);
        arrOpm[4].Value = cboGbnSum.SelectedValue;
        arrOpm[5] = new OracleParameter("i_MCOMNM", OracleType.VarChar, 20);
        arrOpm[5].Value = cboName.Text;        
        arrOpm[6] = new OracleParameter("O_Mana_R009", OracleType.Cursor);
        arrOpm[6].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        this._setGraph(dsGrid);
        DataView dvTmp = dsGrid.Tables[0].DefaultView;
        dvTmp.Sort = "YY DESC";
        //UltraWebGrid1.DataSource = dvTmp;
        //UltraWebGrid1.DataBind();
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R009.PROC_Mana_R009_01", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Combo Query
        OracleParameter[] arrOpm = new OracleParameter[7];

        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = (strYY + strMM);
        arrOpm[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpm[1].Value = cboTCom.SelectedValue;
        arrOpm[2] = new OracleParameter("i_MCOMCD", OracleType.VarChar, 12);
        arrOpm[2].Value = cboMCom.SelectedValue;
        arrOpm[3] = new OracleParameter("i_GBN_NEWYN", OracleType.VarChar, 12);
        arrOpm[3].Value = cboGbnNew.SelectedValue;
        arrOpm[4] = new OracleParameter("i_GBN_SUMYN", OracleType.VarChar, 12);
        arrOpm[4].Value = cboGbnSum.SelectedValue;
        arrOpm[5] = new OracleParameter("i_MCOMNM", OracleType.VarChar, 20);
        arrOpm[5].Value = cboName.Text;        
        arrOpm[6] = new OracleParameter("O_Mana_R009", OracleType.Cursor);
        arrOpm[6].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        //this._setGraph(dsGrid);
        DataView dvTmp = dsGrid.Tables[0].DefaultView;
        dvTmp.Sort = "GUBN ASC";
        UltraWebGrid1.DataSource = dvTmp;
        UltraWebGrid1.DataBind();
    }

    private void _setGraph(DataSet dsGrid)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        
        Series[] oasrType = new Series[dsGrid.Tables[0].Rows.Count];
        int intLP = 0;
        foreach (DataRow row in dsGrid.Tables[0].Rows)
        {
            oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                    row["YY"].ToString(), null, SeriesChartType.Line, 3,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 1; colIndex < dsGrid.Tables[0].Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = dsGrid.Tables[0].Columns[colIndex].ColumnName;
                double YVal = double.Parse(row[columnName].ToString());
                Chart1.Series[oasrType[intLP].Name].Points.AddXY(columnName, YVal);
            }
            intLP += 1;
        }

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            oasrType[i].MarkerStyle = GetMarkerStyle(i);
            oasrType[i].MarkerColor = GetChartColor(i);
            oasrType[i].MarkerBorderColor = GetMarkerBorderColor(i);
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, false);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.DataSource = dsGrid.Tables[0].DefaultView;
        Chart1.DataBind();
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        try
        {
            Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
            ch = e.Layout.Bands[0].Columns[0].Header;

            e.Layout.Bands[0].Columns.FromKey("YY").Header.Caption = "년도";
            e.Layout.Bands[0].Columns.FromKey("YY").Width = 60;
            e.Layout.Bands[0].Columns.FromKey("YY").Header.Style.HorizontalAlign = HorizontalAlign.Center;

            for (int i = 1; i < e.Layout.Bands[0].Columns.Count; i++)
            {
            	if ( i > 0 && i < 13)
                {   
                   e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                   e.Layout.Bands[0].Columns[i].Format = "#,##0";
                   e.Layout.Bands[0].Columns[i].Width = 64;
                } 
                else
                {
                    e.Layout.Bands[0].Columns[i].Hidden = true;
                }	
            }
            
          
        }
        catch
        {
        }
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
 
    }

    protected void cboTCom_SelectedIndexChanged(object sender, EventArgs e)
    {
        UltraWebGrid1.ResetRows();
        this.setDBCombo();
    }
    
    protected void cboMCom_SelectedIndexChanged(object sender, EventArgs e)
    {
        //UltraWebGrid1.ResetRows();
        this._queryChart();
        this._queryGrid();
        this.setDBName();
    }
  
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.ResetRows();
        this._queryChart();
        this._queryGrid();
    }
}
