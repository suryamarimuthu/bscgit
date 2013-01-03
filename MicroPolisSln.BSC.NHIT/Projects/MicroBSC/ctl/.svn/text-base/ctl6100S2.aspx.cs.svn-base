using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.IO;

using MicroBSC.Integration.CTL.Biz;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.Documents.Excel;

public partial class CTL_CTL6100S2 : AppPageBase
{
    public int toggleFlag;

    protected void Page_Init(object sender, EventArgs e)
    {
        // PlaceHold에 화면의 레이아웃의 모양을 잡아주는 UserControl 를 넣어준다.
        // Master Page와 유사한 기능
        SetPageLayout(phdLayout);
    }




    /// <summary>
    /// 쿼리 전송
    /// </summary>
    protected void ibtnRun_Click(object sender, ImageClickEventArgs e)
    {
        string query = this.userQuery.Text;


        initEnvironment();
        

        if (queryValidation(query))
        {
            DataSet DS = null;
            string Result = "";


            try
            {
                DS = procQuery(query);
                bindData(DS);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }


            this.exMsg.Text = Result;
        }
        else
            this.ltrScript.Text = JSHelper.GetAlertScript("올바른 쿼리가 아닙니다");
    }




    protected void initEnvironment()
    {
        exMsg.Text = "";
        lblRowCount.Text = "0";
        UltraWebGrid.Clear();
        ltrScript.Text = "";
        ibtnDownExcel.Visible = false;

    }



    /// <summary>
    /// 쿼리 처리
    /// </summary>
    protected DataSet procQuery(string query)
    {
        Biz_Ctl_Common bizCode = new Biz_Ctl_Common();
        DataSet DS = new DataSet();

        DS = bizCode.runUserQuery(this.userQuery.Text);

        return DS;
    }




    /// <summary>
    /// 데이터 바인딩
    /// </summary>
    protected void bindData(DataSet DS)
    {
        int maxRowCount = 100;
        int rowCount = DS.Tables[0].Rows.Count;;

        
        if (rowCount > maxRowCount)
        {
            ltrScript.Text = "<script>alert('데이터는 최대 " + maxRowCount + "개 까지만 출력됩니다.');</script>";
            cutDS(DS, maxRowCount);
        }


        lblRowCount.Text = DS.Tables[0].Rows.Count.ToString();


        this.UltraWebGrid.DataSource = DS;
        this.UltraWebGrid.DataBind();

        this.ibtnDownExcel.Visible = true;
    }




    /// <summary>
    /// 엑셆 다운로드
    /// </summary>
    protected void ibtnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName = "Result_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName = "RESULT";

        uGridExcelExporter.Export(UltraWebGrid);
    }





    protected bool queryValidation(string query)
    {
        string tmpStr = query.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").ToUpper().Trim();

        if (tmpStr.Length == 0)
            return false;

        if (tmpStr.IndexOf("SELECT ") > 0)
            return false;

        if (tmpStr.IndexOf("UPDATE ") > -1)
            return false;

        if (tmpStr.IndexOf("DELETE ") > -1)
            return false;

        if (tmpStr.IndexOf("CREATE ") > -1)
            return false;

        if (tmpStr.IndexOf("ALTER ") > -1)
            return false;

        if (tmpStr.IndexOf("DROP ") > -1)
            return false;

        if (tmpStr.IndexOf("TRUNCATE ") > -1)
            return false;

        return true;
    }



    protected DataSet cutDS(DataSet DS, int maxCnt)
    {
        while (DS.Tables[0].Rows.Count > maxCnt)
        {
            DS.Tables[0].Rows.RemoveAt(maxCnt);
        }

        return DS;
    }
}
