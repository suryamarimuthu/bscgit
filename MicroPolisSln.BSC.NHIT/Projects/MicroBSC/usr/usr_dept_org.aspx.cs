using System;
using MicroBSC.Biz.BSC.Biz;

public partial class usr_dept_org : AppPageBase
{
    public string ImageType = "";
    public string DEPT_ORG_SCORE_USE_YN = "";
    public string WORKING_MAP_USE_YN = "";

    public int legend_offsetTop;
    public int legend_offsetLeft;
    public int legend_colCnt;

    protected void Page_Load(object sender, EventArgs e)
    {
        string master_site = WebUtility.GetConfig("SITE", "") + "/";
        ImageType = WebUtility.GetConfig("DEPT_ORG_IMAGE", "1");
        string back_img = string.Format("background-image:url(../images/{0}org/back_org_{1}.jpg); background-position:top; background-repeat:repeat-x", master_site, ImageType);

        //legend 위치 - 루트노드에서 우측으로 위치
        legend_offsetLeft = WebUtility.GetRequestByInt("LEGEND_OFFSETLEFT", 150);
        legend_offsetTop = WebUtility.GetRequestByInt("LEGEND_OFFSETTOP", 15);
        legend_colCnt = WebUtility.GetRequestByInt("LEGEND_COLCNT", 1);

        tblMain.Attributes.Add("style", back_img);
        // 조직상황판 백그라운드 이미지 타입 (1부터 시작)
        

        Biz_EstDeptOrgDetails estDeptOrgDetail  = new Biz_EstDeptOrgDetails();
        Biz_EstDeptOrgMaps estDeptOrgMap        = null;

        int ESTTERM_REF_ID                      = GetRequestByInt("ESTTERM_REF_ID");
        int MONTH                               = GetRequestByInt("TMCODE");
        int EST_DEPT_REF_ID                     = GetRequestByInt("EST_DEPT_REF_ID");
        string EXT_KPI_YN                       = GetRequest("EXT_KPI_YN","N");
        DEPT_ORG_SCORE_USE_YN                   = WebUtility.GetConfig("DEPT_ORG_SCORE_USE_YN", "Y");
        WORKING_MAP_USE_YN = WebUtility.GetConfig("WORKING_MAP_USE_YN", "N");

        WebUtility.GetConfig("", "");
        string lineColor = "#cccccc";
        string lineWidth = "2";

        if (Request["DRILLDOWN_YN"] == null)
        {
            EST_DEPT_REF_ID = estDeptOrgDetail.GetEstDeptRefID(ESTTERM_REF_ID);

            bool Include_Ext_Kpi_Score = (EXT_KPI_YN == "Y") ? true : false;


            if (legend_colCnt > 0)
                estDeptOrgMap = new Biz_EstDeptOrgMaps(ESTTERM_REF_ID, MONTH, Include_Ext_Kpi_Score, lineColor, lineWidth, legend_colCnt);
            else
                estDeptOrgMap = new Biz_EstDeptOrgMaps(ESTTERM_REF_ID, MONTH, Include_Ext_Kpi_Score, lineColor, lineWidth);


            estDeptOrgMap.Emp_Ref_ID = EMP_REF_ID;
            estDeptOrgMap.Est_Dept_Ref_ID = GetRequestByInt("EST_DEPT_REF_ID", EST_DEPT_REF_ID);
            estDeptOrgMap.DeptTitleWidth = 152;
            estDeptOrgMap.DeptTitleHeight = 39;
            estDeptOrgMap.SignalPaddingRight = 3;


            ltrScript.Text = estDeptOrgMap.GetHtml();
        }
        else if (GetRequest("DRILLDOWN_YN").Equals("X"))
        {
            ltrScript.Text = string.Format("<script language=javascript> parent.location.href='/BSC/BSC0404S1.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&YMD={2}&SUM_TYPE=MS&EXT_KPI_YN={3}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH, EXT_KPI_YN);
        }
        else if (GetRequest("DRILLDOWN_YN").Equals("N"))
        {
            ///ltrScript.Text = string.Format("<script language=javascript> parent.location.href='usr_ana_view.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH);
            ltrScript.Text = string.Format("<script language=javascript> parent.location.href='usr10001.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&YMD={2}&EXT_KPI_YN={3}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH, EXT_KPI_YN);
        }
        else if (GetRequest("DRILLDOWN_YN").Equals("S"))
        {
            ltrScript.Text = string.Format("<script language=javascript> parent.location.href='/BSC/BSC0403S4.aspx?ITYPE=POP&ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&YMD={2}&SUM_TYPE=MS&EXT_KPI_YN={3}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH, EXT_KPI_YN);
        }
        else if (GetRequest("DRILLDOWN_YN").Equals("W"))
            ltrScript.Text = string.Format("<script language=javascript> parent.location.href='usr10002.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&EXT_KPI_YN={2}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, EXT_KPI_YN);
        else
        {
            if (estDeptOrgDetail.IsDrillDownPosible(ESTTERM_REF_ID, EST_DEPT_REF_ID))
            {
                estDeptOrgMap = new Biz_EstDeptOrgMaps(ESTTERM_REF_ID, MONTH);
                estDeptOrgMap.Emp_Ref_ID = EMP_REF_ID;
                estDeptOrgMap.Est_Dept_Ref_ID = EST_DEPT_REF_ID;
                ltrScript.Text = estDeptOrgMap.GetHtml();
            }
            else
            {
                //ltrScript.Text = string.Format("<script language=javascript> parent.location.href='usr_ana_view.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH);
                ltrScript.Text = string.Format("<script language=javascript> parent.location.href='usr10001.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&YMD={2}&EXT_KPI_YN={3}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH, EXT_KPI_YN);
            }
        }
    }
}
