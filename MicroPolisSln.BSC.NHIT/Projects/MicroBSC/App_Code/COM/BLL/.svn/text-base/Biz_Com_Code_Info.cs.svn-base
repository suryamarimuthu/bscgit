using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Biz_Com_Code_Info의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.Biz.Common.Biz
{
    public class Biz_Com_Code_Info : MicroBSC.Biz.Common.Dac.Dac_Com_Code_Info
    {
        private string strText     = ":: 전체 ::";
        private string strValue    = "";

        #region ====================================== [ Data 입출력] ======================
        public Biz_Com_Code_Info() { }
        public Biz_Com_Code_Info(Int32 icode_info_id) : base(icode_info_id) { }
        public Biz_Com_Code_Info(string icategory_code, string ietc_code) : base(icategory_code, ietc_code) { }

        public int InsertData(int icode_info_id, string icategory_code, string ietc_code, string icode_name, string icode_desc, int isort_order, string iuse_yn
                             ,string isegment1,string isegment2,string isegment3,string isegment4,string isegment5, int itxr_user)
        {
            return base.InsertData_Dac(icode_info_id, icategory_code, ietc_code, icode_name, icode_desc, isort_order, iuse_yn
                                     , isegment1, isegment2, isegment3, isegment4, isegment5, itxr_user);
        }

        public int UpdateData(int icode_info_id, string icategory_code, string ietc_code, string icode_name, string icode_desc, int isort_order, string iuse_yn
                             ,string isegment1,string isegment2,string isegment3,string isegment4,string isegment5, int itxr_user)
        {
            return base. UpdateData_Dac(icode_info_id, icategory_code, ietc_code, icode_name, icode_desc, isort_order, iuse_yn
                                      , isegment1, isegment2, isegment3, isegment4, isegment5, itxr_user);
        }

        public int DeleteData(int icode_info_id, int itxr_user)
        { 
            return base.DeleteData_Dac(icode_info_id, itxr_user);
        }
        #endregion

        #region ====================================== [ 기타코드관리 ] ======================
        private DataSet fillDataSet(string istrCode)
        {
            return base.GetCodeListPerCategory(istrCode,"Y");
        }

        private void fillDropDownList(string istrCode, DropDownList iddList, int iWidth)
        {
            if (iddList.Equals(null))
            {

            }
            else
            {
                DataSet rtnDs = base.GetCodeListPerCategory(istrCode,"Y");
                iddList.DataTextField = "CODE_NAME";
                iddList.DataValueField = "ETC_CODE";
                iddList.DataSource = rtnDs;
                iddList.DataBind();
                if(iWidth != 0) iddList.Width = (iWidth == -1) ? 120 : iWidth;
            }
        }

        private void fillDropDownList(string istrCode, DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            if (iddList.Equals(null))
            {

            }
            else
            {
                try
                {
                    DataSet rtnDs = base.GetCodeListPerCategory(istrCode,"Y");
                    iddList.DataSource = rtnDs;
                    iddList.DataTextField = "CODE_NAME";
                    iddList.DataValueField = "ETC_CODE";
                    iddList.DataBind();
                    if(iWidth != 0) iddList.Width = (iWidth == -1) ? 120 : iWidth;

                    if (blnTotalYn)
                    {
                        iddList.Items.Insert(0, new ListItem(strText, strValue));
                    }

                    iddList.SelectedIndex = defaultIndex;
                }
                catch
                { 
                
                }
            }
        }

        private void fillDropDownList(string istrCode, DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            if (iddList.Equals(null))
            {

            }
            else
            {
                try
                {
                    DataSet rtnDs = base.GetCodeListPerCategory(istrCode, "Y");
                    iddList.DataSource = rtnDs;
                    iddList.DataTextField = "CODE_NAME";
                    iddList.DataValueField = "ETC_CODE";
                    iddList.DataBind();
                    if(iWidth != 0) iddList.Width = (iWidth == -1) ? 120 : iWidth;

                    iddList.SelectedValue = defaultValue;
                }
                catch
                {

                }

                if (blnTotalYn)
                {
                    iddList.Items.Insert(0, new ListItem(strText, strValue));
                }
            }
        }

        //-------------------------------------------------------- 실적입력방식
        public DataSet getResultMethod(int defaultIndex)
        {
            return fillDataSet("BS001");
        }

        public void getResultMethod(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS001", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getResultMethod(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS001", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 기간유형
        public DataSet getTermType(int defaultIndex)
        {
            return fillDataSet("BS005");
        }

        public void getTermType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS005", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getTermType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS005", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- KPI유형
        public DataSet getPNUType(int defaultIndex)
        {
            return fillDataSet("BS003");
        }

        public void getPNUType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS003", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getPNUType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS003", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 누계유형
        public DataSet getColTargetType(int defaultIndex)
        {
            return fillDataSet("BS002");
        }

        public void getColTargetType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS002", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getColTargetType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS002", iddList, defaultValue, blnTotalYn, iWidth);
        }
        //-------------------------------------------------------- 측정단계
        public DataSet getCheckStep(int defaultIndex)
        {
            return fillDataSet("BS004");
        }

        public void getCheckStep(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS004", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getCheckStep(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS004", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 실적비교방법
        public DataSet getCheckType(int defaultIndex)
        {
            return fillDataSet("BS006");
        }

        public void getCheckType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS006", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getCheckType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS006", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- Initiative 작성단계
        public DataSet getInitiativeStatus(int defaultIndex)
        {
            return fillDataSet("BS007");
        }

        public void getInitiativeStatus(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS007", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getInitiativeStatus(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS007", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 점수계산방식
        public DataSet GetScoreValuationType(int defaultIndex)
        {
            return fillDataSet("BS008");
        }

        public void GetScoreValuationType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS008", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetScoreValuationType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS008", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 지표유형(QLT:비계량지표, QTT:계량지표, COM:공통지표,EXT:외부평가지표)
        public DataSet GetKpiType(int defaultIndex)
        {
            return fillDataSet("BS009");
        }

        public void GetKpiType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS009", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetKpiType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS009", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 지표구분(INR:내부지표, EXT:외부지표)
        public DataSet GetKpiExternalType(int defaultIndex)
        {
            return fillDataSet("BS010");
        }

        public void GetKpiExternalType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS010", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetKpiExternalType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS010", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 평가방식구분(EQL:정성평가, EQT:정량평가)
        public DataSet GetKpiEstimateType(int defaultIndex)
        {
            return fillDataSet("BS011");
        }

        public void GetKpiEstimateType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS011", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetKpiEstimateType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS011", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 비계량지표 등급구간
        public DataSet GetKpiQualityEstimateGrade(int defaultIndex)
        {
            return fillDataSet("BS012");
        }

        public void GetKpiQualityEstimateGrade(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS012", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetKpiQualityEstimateGrade(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS012", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 누적확률분포 그룹코드
        public DataSet GetKpiNormdistGroup(int defaultIndex)
        {
            return fillDataSet("BS013");
        }

        public void GetKpiNormdistGroup(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS013", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetKpiNormdistGroup(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS013", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 결재선종류(정의서, 실적, 정의서&실적, 프로젝트, 전사, 개인)
        public DataSet GetApprovalLine(int defaultIndex)
        {
            return fillDataSet("CM001");
        }

        public void GetApprovalLine(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("CM001", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetApprovalLine(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("CM001", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 결재상태
        public DataSet GetApprovalStatus(int defaultIndex)
        {
            return fillDataSet("CM002");
        }

        public void GetApprovalStatus(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("CM002", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetApprovalStatus(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("CM002", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 결재업무유형(정의서, 실적, 사업관리)
        public DataSet GetApprovalBizType(int defaultIndex)
        {
            return fillDataSet("CM003");
        }

        public void GetApprovalBizType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("CM003", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetApprovalBizType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("CM003", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 결재선유형(기안, 검토, 참조, 승인)
        public DataSet GetApprovalLineType(int defaultIndex)
        {
            return fillDataSet("CM004");
        }

        public void GetApprovalLineType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("CM004", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetApprovalLineType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("CM004", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 프로젝트 중요도
        public DataSet GetProjectPriority(int defaultIndex)
        {
            return fillDataSet("PM001");
        }

        public void GetProjectPriority(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("PM001", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetProjectPriority(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("PM001", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //------------------------------------------------------  프로젝트 유형

        public DataSet GetProjectType(int defaultIndex)
        {
            return fillDataSet("PM002");
        }

        public void GetProjectType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("PM002", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetProjectType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("PM002", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //------------------------------------------------------  작업유형

        public DataSet GetTaskType(int defaultIndex)
        {
            return fillDataSet("PM003");
        }

        public void GetTaskType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("PM003", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetTaskType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("PM003", iddList, defaultValue, blnTotalYn, iWidth);
        }


        #endregion
    }
}