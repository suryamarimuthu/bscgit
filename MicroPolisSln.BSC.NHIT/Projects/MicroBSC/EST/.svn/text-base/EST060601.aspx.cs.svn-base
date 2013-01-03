using System;
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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;

public partial class EST_EST060601 : EstPageBase
{
    private int ESTTERM_REF_ID_FROM;
    private int ESTTERM_REF_ID_TO;
    private int ESTTERM_SUB_ID_FROM;
    private int ESTTERM_SUB_ID_TO;
    private int ESTTERM_STEP_ID_FROM;
    private int ESTTERM_STEP_ID_TO;
    private string TYPE;

    protected void Page_Load(object sender, EventArgs e)
    {
        TYPE = WebUtility.GetRequest("TYPE");

        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID_From);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID_To);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID_From, WebUtility.GetIntByValueDropDownList(ddlCompID), "N");
            DropDownListCommom.BindEstTermSub(ddlEstTermSubID_To, WebUtility.GetIntByValueDropDownList(ddlCompID));
            DropDownListCommom.BindEstTermStep(ddlEstTermStepID_From, WebUtility.GetIntByValueDropDownList(ddlCompID)); 
            DropDownListCommom.BindEstTermStep(ddlEstTermStepID_To, WebUtility.GetIntByValueDropDownList(ddlCompID)); 

            SetTitle(TYPE);

            ibnSave.Attributes.Add("onclick", "return confirm('체크하신 항목에 대한 기준대상의 정보를 피참조대상으로 복사하시겠습니까?')");

            if(TYPE.Equals("")) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("선택된 전기간 참조가 없습니다.");
                return;
            }
        }

        COMP_ID              = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID_FROM  = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID_From);
        ESTTERM_REF_ID_TO    = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID_To);
        ESTTERM_SUB_ID_FROM  = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID_From);
        ESTTERM_SUB_ID_TO    = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID_To);
        ESTTERM_STEP_ID_FROM = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID_From);
        ESTTERM_STEP_ID_TO   = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID_To);

        ltrScript.Text  = "";
    }

    private void SetTitle(string type) 
    {
        if(type.Equals("1")) 
        {
            lblTitle.Text = "부서별 등급산출 방법";

            ddlEstTermSubID_From.Visible    = false;
            ddlEstTermSubID_To.Visible      = false;
            ddlEstTermStepID_From.Visible   = false;
            ddlEstTermStepID_To.Visible     = false;
        }
        else if(type.Equals("2")) 
        {
            lblTitle.Text = "부서별 가중치";

            ddlEstTermSubID_From.Visible    = false;
            ddlEstTermSubID_To.Visible      = false;
            ddlEstTermStepID_From.Visible   = false;
            ddlEstTermStepID_To.Visible     = false;
        }
        else if(type.Equals("3")) 
        {
            lblTitle.Text = "상대그룹 설정";

            ddlEstTermSubID_From.Visible    = false;
            ddlEstTermSubID_To.Visible      = false;
            ddlEstTermStepID_From.Visible   = false;
            ddlEstTermStepID_To.Visible     = false;
        }
        else if(type.Equals("4")) 
        {
            lblTitle.Text = "평가자/ 피평가자 매핑 정보";
        }
        else if(type.Equals("5")) 
        {
            lblTitle.Text = "질의/ 피평가자 매핑 정보";

            ddlEstTermStepID_From.Visible   = false;
            ddlEstTermStepID_To.Visible     = false;
        }
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        if(    ESTTERM_REF_ID_FROM == ESTTERM_REF_ID_TO 
            && ESTTERM_SUB_ID_FROM == ESTTERM_SUB_ID_TO) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("기준대상과 피참조대상의 기간이 같습니다. 다시 설정하세요.");
            return;
        }

        bool isOK = false;

        if(TYPE.Equals("1")) 
        {
            if(    ESTTERM_REF_ID_FROM == ESTTERM_REF_ID_TO) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("기준대상과 피참조대상의 기간이 같습니다. 다시 설정하세요.");
                return;
            }

            Biz_DeptEstDetails deptEstDetail    = new Biz_DeptEstDetails();
            Biz_DeptPosScales deptPosScale      = new Biz_DeptPosScales();

            isOK = deptEstDetail.CopyDataFromTo(  COMP_ID
                                                , ESTTERM_REF_ID_FROM
                                                , ESTTERM_REF_ID_TO
                                                , DateTime.Now
                                                , EMP_REF_ID);

            if(isOK)
                deptPosScale.CopyDataFromTo(  COMP_ID
                                            , ESTTERM_REF_ID_FROM
                                            , ESTTERM_REF_ID_TO
                                            , DateTime.Now
                                            , EMP_REF_ID);
        }
        else if(TYPE.Equals("2")) 
        {
            if(    ESTTERM_REF_ID_FROM == ESTTERM_REF_ID_TO) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("기준대상과 피참조대상의 기간이 같습니다. 다시 설정하세요.");
                return;
            }

            Biz_DeptPosDetails deptPosScale     = new Biz_DeptPosDetails();
            isOK                                = deptPosScale.CopyDataFromTo(COMP_ID
                                                                            , ESTTERM_REF_ID_FROM
                                                                            , ESTTERM_REF_ID_TO
                                                                            , DateTime.Now
                                                                            , EMP_REF_ID);
        }
        else if(TYPE.Equals("3")) 
        {
            if(    ESTTERM_REF_ID_FROM == ESTTERM_REF_ID_TO) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("기준대상과 피참조대상의 기간이 같습니다. 다시 설정하세요.");
                return;
            }

            Biz_RelGroupInfos relGroupInfo              = new Biz_RelGroupInfos();
            isOK                                        = relGroupInfo.CopyDataFromTo(COMP_ID 
                                                                                    , ESTTERM_REF_ID_FROM
                                                                                    , ESTTERM_REF_ID_TO
                                                                                    , DateTime.Now
                                                                                    , EMP_REF_ID);
        }
        else if(TYPE.Equals("4")) 
        {
            Biz_EmpEstTargetMaps empEstTgtMap   = new Biz_EmpEstTargetMaps();
            isOK                                = empEstTgtMap.CopyDataFromTo(COMP_ID
                                                                            , ""
                                                                            , ESTTERM_REF_ID_FROM
                                                                            , ESTTERM_SUB_ID_FROM
                                                                            , ESTTERM_STEP_ID_FROM
                                                                            , ESTTERM_REF_ID_TO
                                                                            , ESTTERM_SUB_ID_TO
                                                                            , ESTTERM_STEP_ID_TO
                                                                            , DateTime.Now
                                                                            , EMP_REF_ID);
            
        }
        else if(TYPE.Equals("5")) 
        {
            if(    ESTTERM_REF_ID_FROM == ESTTERM_REF_ID_TO 
                && ESTTERM_SUB_ID_FROM == ESTTERM_SUB_ID_TO) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("기준대상과 피참조대상의 기간이 같습니다. 다시 설정하세요.");
                return;
            }

            Biz_QuestionDeptEmpMaps questionDeptEmp = new Biz_QuestionDeptEmpMaps();
            isOK                                    = questionDeptEmp.CopyEstDataFromTo(  COMP_ID
                                                                                        , ESTTERM_REF_ID_FROM
                                                                                        , ESTTERM_SUB_ID_FROM
                                                                                        , ESTTERM_REF_ID_TO
                                                                                        , ESTTERM_SUB_ID_TO
                                                                                        , DateTime.Now
                                                                                        , EMP_REF_ID);
        }

        if(isOK) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 데이터가 참조되었습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("참조 중 오류가 발생하였습니다.");
        }
    }
}
