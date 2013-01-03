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

public partial class eis_eis1000 : System.Web.UI.Page
{
    String query = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        query = "SELECT splyy as tmcode , sum(splddqty)/1000000 as target , sum(sumddqty)/1000000 as result FROM uz5plan WHERE saupjang=21 and splyy > 2001 group by splyy";
        DataSet ds = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter ad = new OracleDataAdapter(query, _connection);
        ad.Fill(ds);
        
        ArrayList yValues1;
        ArrayList yValues2;
        ArrayList yValues3;
        ArrayList yValues4;
        ArrayList xValues;

        DundasCharts.SetDataFieldsX1(query, "tmcode", out xValues, "target", out yValues1, "result", out yValues2);
        DundasCharts.SetDataFieldsX1(query, "tmcode", out xValues, "target", out yValues3, "result", out yValues4);

        Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues1);
        Chart1.Series["Series2"].Points.DataBindXY(xValues, yValues2);
        Chart1.Series["Series3"].Points.DataBindXY(xValues, yValues3);
        Chart1.Series["Series4"].Points.DataBindXY(xValues, yValues4);

        Chart2.Series["Series1"].Points.DataBindXY(xValues, yValues1);
        Chart2.Series["Series2"].Points.DataBindXY(xValues, yValues2);
        Chart2.Series["Series3"].Points.DataBindXY(xValues, yValues3);
        Chart2.Series["Series4"].Points.DataBindXY(xValues, yValues4);

        query = " SELECT a.saupjang, a.splyy, a.splmm, a.spldd, a.splddqty, a.splmmqty,";
        query += " a.splyyqty, a.sumddqty, a.summmqty, a.sumyyqty, a.modempno, a.modymdt";
        query += " FROM uz5plan a";
        query += " where a.splyy = 2006 order by saupjang, splyy, splmm";
        ds = new DataSet();
        ad = new OracleDataAdapter(query, _connection);
        ad.Fill(ds);

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }
}
