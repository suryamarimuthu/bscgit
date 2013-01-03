using System;
using MicroBSC.Biz.BSC.Biz;

public partial class usr_dept_org_embed : AppPageBase
{
    public string ImageType = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        int i = DateTime.Now.Second;

        //if (i > 0 && i <= 20)
        //    ImageType = "1";
        //else if (i > 20 && i <= 40)
        //    ImageType = "2";
        //else
        //    ImageType = "3";

        ImageType = "19";

        Biz_EstDeptOrgDetails estDeptOrgDetail  = new Biz_EstDeptOrgDetails();
        Biz_EstDeptOrgMaps estDeptOrgMap        = null;

        int ESTTERM_REF_ID                      = GetRequestByInt("ESTTERM_REF_ID");
        int MONTH                               = GetRequestByInt("TMCODE");
        int EST_DEPT_REF_ID                     = GetRequestByInt("EST_DEPT_REF_ID"); ;

        if (Request["DRILLDOWN_YN"] == null)
        {
            EST_DEPT_REF_ID                     = estDeptOrgDetail.GetEstDeptRefID(ESTTERM_REF_ID);

            estDeptOrgMap                       = new Biz_EstDeptOrgMaps(ESTTERM_REF_ID, MONTH);
            estDeptOrgMap.Emp_Ref_ID            = EMP_REF_ID;
            estDeptOrgMap.Is_Embed              = true;
            estDeptOrgMap.Est_Dept_Ref_ID       = EST_DEPT_REF_ID;
            //estDeptOrgMap.Est_Dept_Ref_ID       = GetRequestByInt("EST_DEPT_REF_ID", EST_DEPT_REF_ID);
            ltrScript.Text                      = estDeptOrgMap.GetHtml();
        }
        else if (GetRequest("DRILLDOWN_YN").Equals("X"))
        {
            ltrScript.Text = string.Format("<script language=javascript> parent.location.href='../BSC/BSC0406S1.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&YMD={2}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH);
        }
        else if (GetRequest("DRILLDOWN_YN").Equals("N"))
        {
            //Literal1.Text = string.Format("<script language=javascript> parent.location.href='usr10001.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH);
            ltrScript.Text = string.Format("<script language=javascript> parent.location.href='usr10001.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH);

            //usr_ana_view.aspx
        }
        else 
        {
            if (estDeptOrgDetail.IsDrillDownPosible(ESTTERM_REF_ID, EST_DEPT_REF_ID))
            {
                estDeptOrgMap                   = new Biz_EstDeptOrgMaps(ESTTERM_REF_ID, MONTH);
                estDeptOrgMap.Emp_Ref_ID        = EMP_REF_ID;
                estDeptOrgMap.Is_Embed          = true;
                estDeptOrgMap.Est_Dept_Ref_ID   = EST_DEPT_REF_ID;
                ltrScript.Text                  = estDeptOrgMap.GetHtml();
            }
            else 
            {
                //Literal1.Text = string.Format("<script language=javascript> parent.location.href='usr10001.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH);
                ltrScript.Text = string.Format("<script language=javascript> parent.location.href='usr10001_embed.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}'; </script>", ESTTERM_REF_ID, EST_DEPT_REF_ID, MONTH);
            }
        }
    }
}
