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

public partial class eis_SEM_Fina_R025 : EISPageBase
{
     int type = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
            this._initForm(Page.IsPostBack);
            this._queryGrid();
        }
        else
        {
           this._queryGrid();
        }
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

            this.cboBank.Items.Clear();

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
                if (intMM  == intLP)
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

           
            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            this.cboYY.SelectedIndex = cboYY.Items.Count - 1;


            this.cboBank.Items.Add(new ListItem("전체", ""));
            this.cboBank.Items.Add(new ListItem("경남은행", "10000"));
            this.cboBank.Items.Add(new ListItem("국민은행", "10003"));
            cboBank.SelectedIndex = 0;


        }
    }

    private void _queryGrid()
    {
        string strYMD = (cboYY.SelectedValue + cboMM.SelectedValue );

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Fina_R025.PROC_Fina_R025_01", _connection);
        _connection.Open();

        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpmGrid = new OracleParameter[3];

        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 6);
        arrOpmGrid[0].Value = (strYMD);
        arrOpmGrid[1] = new OracleParameter("i_BANK", OracleType.VarChar, 12);
        arrOpmGrid[1].Value = cboBank.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("O_Fina_R025", OracleType.Cursor);
        arrOpmGrid[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);
        daGrid.Fill(dsGrid);
        //this.setGridData(dsGrid);

        UltraWebGrid1.Clear();
        if (dsGrid.Tables.Count > 0)
        {
            UltraWebGrid1.DataSource = dsGrid;
            UltraWebGrid1.DataBind();
        }
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {

                e.Layout.Bands[0].Columns[0].MergeCells = true;
          

    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
        
        string strSum = (e.Row.Cells[1].Value == null) ? " " : e.Row.Cells[1].Value.ToString().Trim();
        
        
        int intSt = strSum.Length-1;
        if (intSt > 0 )
        {
           
           strSum = strSum.Substring(intSt,1);
        
           //Response.Write(strSum);
           if (strSum == "계" )
           {
               e.Row.Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
            
           }
                                
        }

        string strBank = (e.Row.Cells[0].Value == null) ? " " : e.Row.Cells[0].Value.ToString().Trim();
        
        
        int intBk = strBank.Length-1;
        if (intBk > 0 )
        {
           
           strBank = strBank.Substring(intBk,1);
        
           //Response.Write(strBank);
           if (strBank == "계" )
           {
               e.Row.Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
            
           }
                                
        }
    }


}
