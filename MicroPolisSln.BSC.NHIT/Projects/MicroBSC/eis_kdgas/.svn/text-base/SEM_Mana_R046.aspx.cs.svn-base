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

public partial class eis_SEM_Mana_R046 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            //SetDateDropDownList(ddlYear, ddlMonth);
            SetTypeDropDownList(ddlType);
            DataBindingObjects();
        }
    }
    public void SetTypeDropDownList(System.Web.UI.WebControls.DropDownList ddList)
    {
        string query = @"SELECT SEM_CODE2_T, SEM_CODE2_NAME FROM SEM_CODE_MASTER WHERE SEM_CODE1_T = '15'";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        ddList.DataSource = ds;
        ddList.DataTextField = "SEM_CODE2_NAME";
        ddList.DataValueField = "SEM_CODE2_T";
        ddList.DataBind();

        //ddList.Items.Insert(0, new ListItem("전체", "*"));
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        //if (dr["CENTER_JMNO_T"].ToString().Length == 13)
        //    e.Row.Cells.FromKey("CENTER_JMNO_T").Value = dr["CENTER_JMNO_T"].ToString().Substring(0, 6) + "-" + dr["CENTER_JMNO_T"].ToString().Substring(6, 7);

        if (dr["CENTER_ENTER_DATE"].ToString().Length == 8)
            e.Row.Cells.FromKey("CENTER_ENTER_DATE").Value = dr["CENTER_ENTER_DATE"].ToString().Substring(0, 4) + "." + dr["CENTER_ENTER_DATE"].ToString().Substring(4, 2) + "." + dr["CENTER_ENTER_DATE"].ToString().Substring(6, 2);

        //if (dr["CENTER_END_DATE"].ToString().Length == 8)
        //    e.Row.Cells.FromKey("CENTER_END_DATE").Value = dr["CENTER_END_DATE"].ToString().Substring(0, 4) + "." + dr["CENTER_END_DATE"].ToString().Substring(4, 2) + "." + dr["CENTER_END_DATE"].ToString().Substring(6, 2);

        //if (dr["CENTER_GRAD_DATE"].ToString().Length == 8)
        //    e.Row.Cells.FromKey("CENTER_GRAD_DATE").Value = dr["CENTER_GRAD_DATE"].ToString().Substring(0, 4) + "." + dr["CENTER_GRAD_DATE"].ToString().Substring(4, 2) + "." + dr["CENTER_GRAD_DATE"].ToString().Substring(6, 2);
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    private void DataBindingObjects() 
    {
        string type     = ddlType.SelectedValue;
        GridBinding(type);
    }
    private void GridBinding(string type)
    {
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(GetQuery(type), "Data");

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }
    private string GetQuery(string type)
    {
        string query = @"
                SELECT SEM_CENTER_EMPLOYEE.CENTER_CODE_T,            
                  SEM_CODE_MASTER.SEM_CODE2_NAME,     
                  SEM_CENTER_EMPLOYEE.CENTER_SABUN_T, 
                  SEM_CENTER_EMPLOYEE.CENTER_JMNO_T,  
                  SEM_CENTER_EMPLOYEE.CENTER_NAME,    
                  SEM_CENTER_EMPLOYEE.CENTER_POSITION,
                  SEM_CENTER_EMPLOYEE.CENTER_STATUS,  
                  SEM_CENTER_EMPLOYEE.CENTER_JOB,     
                  SEM_CENTER_EMPLOYEE.CENTER_ENTER_DATE,  
                  SEM_CENTER_EMPLOYEE.CENTER_END_DATE,    
                  SEM_CENTER_EMPLOYEE.CENTER_LICENSE1,    
                  SEM_CENTER_EMPLOYEE.CENTER_LICENSE2,    
                  SEM_CENTER_EMPLOYEE.CENTER_LICENSE3,    
                  SEM_CENTER_EMPLOYEE.CENTER_SCHOOL,      
                  SEM_CENTER_EMPLOYEE.CENTER_STUDY,       
                  SEM_CENTER_EMPLOYEE.CENTER_GRAD_DATE,   
                  SEM_CENTER_EMPLOYEE.CENTER_HPNO,        
                  SEM_CENTER_EMPLOYEE.CENTER_HMNO,        
                  SEM_CENTER_EMPLOYEE.CENTER_EMAIL,       
                  SEM_CENTER_EMPLOYEE.CENTER_ADDR         
                      FROM  SEM_CENTER_EMPLOYEE SEM_CENTER_EMPLOYEE,
                            SEM_CODE_MASTER SEM_CODE_MASTER                 
                                WHERE SEM_CENTER_EMPLOYEE.CENTER_CODE_T = '" + type + @"'
                                    AND SEM_CODE_MASTER.SEM_CODE1_T = '15'
                                    AND SEM_CENTER_EMPLOYEE.CENTER_CODE_T = SEM_CODE_MASTER.SEM_CODE2_T";
        
        return query;
    }
}
