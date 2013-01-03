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

using MicroBSC.Estimation.Biz;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.Documents.Excel;

public partial class EST_EST110100 : EstPageBase
{
	#region ================ 필드 =======================

	public string EST_ID;                           // 평가ID
	public string EST_TGT_TYPE;                     // EST or TGT => 평가자 인지 피평가자 인지
	public string YEAR_YN;                          // 연년평가인지 여부
	public string MERGE_YN;                         // 합산인지 여부
	public string DEPT_COLUMN_NO_USE_YN;            // 부서컬럼을 사용하지 않는다 에 대한 여부
	public string ESTTERM_SUB_ALL_USE_YN;           // 모든 주기를 사용한다 에 대한 여부
	public string ESTTERM_STEP_ALL_USE_YN;          // 모든 차수를 사용한다 에 대한 여부
	public YesNo WEIGHT_EST_MANUAL_YN;             // 평가에 대한 수기 가중치 사용 여부
	public YesNo WEIGHT_STEP_MANUAL_YN;            // 차수에 대한 수기 가중치 사용 여부

    private const string EST_ID_3GA = "3GA"; // 개인KPI 평가
    private const string EST_ID_3A = "3A"; // 조직KPI 평가

	private bool isEstStepOtherListVisible = true;  // ???

	public string REPORT_YN;                        // 리포트 여부

	public int DEFAULT_INDEX_COUNT = 1;    // Ultra

	private DataTable DT_COLUMN_INFO = null; // 평가별 컬럼정보를 가지고 있는 DataTable
	private DataTable DT_GRADE = null; // 등급에 관련된 DataTable
	private DataTable DT_CTRL_INFO = null; // 조정에 관련된 DataTable
	private DataTable DT_CTRL_EST_DEPT_MAP = null; // 평가대상 부서의 조정 대상 DataTable
	private DataTable DT_CTRL_EST_EMP_MAP = null; // 평가자의 조정 대상 DataTable
	private DataTable DT_CTRL_POINT_DATA = null; // 조정 점수 데이터 DataTable
	private DataTable DT_CTRL_GRADE_DATA = null; // 조정 등급 데이터 DataTable
	private DataTable DT_EST_DATA = null; // 평가 Data DataTable
	private DataTable DT_DEPT_SCALE = null; // 부서별 절대/상대평가 여부 DataTable
	private DataTable DT_POS_SCALE = null; // 부서별 직급체계에 따른 절대/상대평가 여부 DataTable
	private DataTable DT_POS_BIZ = null; // 직무 데이터 DataTable

    private bool IVISIBLE_PAST_POINT_YN
    {
        get
        {
            if (ViewState["VISIBLE_PAST_POINT_YN"] == null)
                ViewState["VISIBLE_PAST_POINT_YN"] = true;
            return (bool)ViewState["VISIBLE_PAST_POINT_YN"];
        }
        set
        {
            ViewState["VISIBLE_PAST_POINT_YN"] = value;
        }
    }

    protected string IEST_STATUS
    {
        get
        {
            if (ViewState["EST_STATUS"] == null)
                ViewState["EST_STATUS"] = "N";
            return (string)ViewState["EST_STATUS"];
        }
        set
        {
            ViewState["EST_STATUS"] = value;
        }
    }

    protected string IEST_COMPLETE
    {
        get
        {
            if (ViewState["EST_COMPLETE"] == null)
                ViewState["EST_COMPLETE"] = "N";
            return (string)ViewState["EST_COMPLETE"];
        }
        set
        {
            ViewState["EST_COMPLETE"] = value;
        }
    }

	private bool USE_POS_BIZ = false; // 직무 사용 여부

	#endregion

	#region ====================== Page_Load =====================

	protected void Page_Init(object sender, EventArgs e)
	{
		// PlaceHold에 화면의 레이아웃의 모양을 잡아주는 UserControl 를 넣어준다.
		// Master Page와 유사한 기능
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		EST_JOB_IDS = WebUtility.GetRequest("EST_JOB_IDS");                 // EST_JOB_ID의 ',' 구분으로 배열을 받음 => 작업 버튼 중 배열값의 따라 보이기 여부가 결정됨
		EST_TGT_TYPE = WebUtility.GetRequest("EST_TGT_TYPE", "EST");         // 평가자 인지 피평가자 인지 의 구분
		YEAR_YN = WebUtility.GetRequest("YEAR_YN", "N");                // 년간 일 경우 주기의 DropDownList가 보이지 않는다.
		MERGE_YN = WebUtility.GetRequest("MERGE_YN", "N");               // 합산 일 경우 차수의 DropDownList가 보이지 않는다.
		DEPT_COLUMN_NO_USE_YN = WebUtility.GetRequest("DEPT_COLUMN_NO_USE_YN", "N");  // 여부에 따라 피평가 주체가 부서냐 아니면 사원이냐의 따라 관련 컬럼이 보이기 여부가 결정된다.
		ESTTERM_SUB_ALL_USE_YN = WebUtility.GetRequest("ESTTERM_SUB_ALL_USE_YN", "N"); // 여부에 따라 주기 DropDownList가 결정된다. 기본은 보이기 Yes => 모든 주기의 정보를 보여주게 된다.
		ESTTERM_STEP_ALL_USE_YN = WebUtility.GetRequest("ESTTERM_STEP_ALL_USE_YN", "N");// 여부에 따라 차수 DropDownList가 결정된다. 기본은 보이기 Yes => 모든 차수의 정보를 보여주게 된다.
		REPORT_YN = WebUtility.GetRequest("REPORT_YN", "N");              // 리포트인지의 여부


        // 웹 취약성 검사 때문에 처리
        if (EST_JOB_IDS.Equals("-0")
            || EST_TGT_TYPE.Equals("-0")
            || YEAR_YN.Equals("-0")
            || MERGE_YN.Equals("-0")
            || DEPT_COLUMN_NO_USE_YN.Equals("-0")
            || ESTTERM_SUB_ALL_USE_YN.Equals("-0")
            || ESTTERM_STEP_ALL_USE_YN.Equals("-0")
            || REPORT_YN.Equals("-0"))
        {
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }

		if (!Page.IsPostBack)
		{

			DropDownListCommom.BindComp(ddlCompID, lblCompTitle);                       // 만약 성과평가를 사용하는 회사가 2개 이상을 경우 그 부분을 해결하기 위해서 COMP_ID 값을 사용하는데 UI를 DropDownList로 해결한다.
			DropDownListCommom.BindEstTerm(ddlEstTermRefID);                            // 평가기간 DropDownList에 바인딩
			DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "----------", "");     // 평가주기 DropDownList에 바인딩
			DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "----------", "");    // 평가차수 DropDownList에 바인딩

            //피평가부서 보이기 여부
            if (WebUtility.GetRequest("TGT_DEPT_YN", "N") == "Y")
                WebCommon.SetComDeptDropDownList(ddlTgtDept, true);
            else
                ddlTgtDept.Visible = false;

            // MBO평가일경우, 조회, 전체조회 보이기
            if ((WebUtility.GetRequest("EST_ID", "") == EST_ID_3GA || WebUtility.GetRequest("EST_ID", "") == EST_ID_3A )
                && EST_JOB_IDS == "JOB_91")
                ibtnSearch.Visible = ibtnSearchAll.Visible = true;

			// COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID은 Session 변수로 사용하여
			// 한 페이지에서 저장된 값을 이동되는 다른 페이지에서 사용한다.
			if (COMP_ID == 0)
				COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

			if (ESTTERM_REF_ID == 0)
				ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

			if (ESTTERM_SUB_ID == 0)
				ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
			if (ESTTERM_STEP_ID == 0)
				ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

			// 모든 버튼을 클릭할 때는 confirm 을 사용하여 사용여부를 확인한다.
			ibnSearch.Attributes.Add("onclick", "return Search();");                                                    // 검색버튼
			ibnConfirmEstQ.Attributes.Add("onclick", "return confirm('다면평가를 확정하시겠습니까?');");                // 평가자 질의 확정
			ibnCancelEstQ.Attributes.Add("onclick", "return confirm('다면평가를 취소하시겠습니까?');");                 // 평가자 질의 취소
			ibnConfirmTgtOpinion.Attributes.Add("onclick", "return confirm('의견상신을 확정하시겠습니까?');");          // 피평가자 의견상신 확정
			ibnCancelTgtOpinion.Attributes.Add("onclick", "return confirm('의견상신을 취소하시겠습니까?');");           // 피평가자 의견상신 취소
			ibnConfirmFeedback.Attributes.Add("onclick", "return confirm('피드백을 확정하시겠습니까?');");              // 피평가자 피드백 확정
			ibnCancelFeedback.Attributes.Add("onclick", "return confirm('피드백을 취소하시겠습니까?');");               // 피평가자 피드백 취소
			ibnConfirmBias.Attributes.Add("onclick", "return confirm('Bias 조정점수 작업을 확정하시겠습니까?');");      // Bias 조정 확정
			ibnConfirmPoint.Attributes.Add("onclick", "return confirm('평가점수를 확정하시겠습니까?');");               // 점수확정 
			ibnConfirmGrade.Attributes.Add("onclick", "return confirm('평가등급을 확정하시겠습니까?');");               // 등급확정
			ibnGradeToPoint.Attributes.Add("onclick", "return confirm('등급을 점수로 환산 하시겠습니까?');");           // 등급 점수 확정


            if (WebUtility.GetRequest("EST_ID").Equals("3O") && this.User.IsInRole(ROLE_ADMIN))
            {
                //다면평가 점수 합계
                ibnAggEstTermStep.Attributes.Add("onclick", "return confirm('다면평가 점수를 합산하시겠습니까?');");
            }
            else
            {
                // 평가차수 집계
                ibnAggEstTermStep.Attributes.Add("onclick", "return confirm('평가차수 간에 가중치를 반영하여 점수를 집계하시겠습니까?');"); 
            }


			ibnAggEstTermSub.Attributes.Add("onclick", "return confirm('평가주기 간에 가중치를 반영하여 점수를 집계하시겠습니까?');");  // 평가주기 집계
			ibnCtrlConfirmPoint.Attributes.Add("onclick", "return confirm('조정점수를 확정하시겠습니까?');");                           // 조정점수 확정
			ibnCtrlConfirmGrade.Attributes.Add("onclick", "return confirm('조정등급을 확정하시겠습니까?');");                           // 조정등급 확정
			ibnDeptToEmpData.Attributes.Add("onclick", "return confirm('부서 평가정보를 사원 평가정보로 변환하시겠습니까?');");         // 부서점수를 사원점수로 변환
			ibnGetOuterData.Attributes.Add("onclick", "return confirm('현재 평가 정보 데이터를 등록하시겠습니까?');");                  // 외부데이터 가져오기
            ibnAggChildEstPoint.Attributes.Add("onclick", "return confirm('하위 평가의 점수를 가중치 적용하시겠습니까?');");            // 하위평가점수 가져오기
			
            
            
            ibnPrjToEmpData.Attributes.Add("onclick", "return confirm('프로젝트 점수를 사원 점수 변환하시겠습니까?');");                // 프로젝트점수를 사원평가점수로 변환
			ibnGetLinkEstData.Attributes.Add("onclick", "return confirm('링크된 평가점수 결과를 가져오시겠습니까?');");                 // 링크된 평가점수 가져오기
			ibnConfirmEstResult.Attributes.Add("onclick", "return confirm('평가결과을 확정하시겠습니까?');");                           // 평가결과 확정
			ibnConfirmByForce.Attributes.Add("onclick", "return confirm('평가결과 강제확정하시겠습니까?');");                           // 평가결과 강제확정

			// 쿼리스트링으로 받은 EST_JOB_ID로 COL_ 관련 필드의 값을 넣어 주는 메소드
			SetColColumnsByEstJobID(EST_JOB_IDS);

			// 쿼리스트링으로 EST_ID가 존재한다면
			if (!WebUtility.GetRequest("EST_ID").Equals(""))
			{
				txtSearchEstName.Visible = false;        // 평가 조회 TextBox
				imgEstButton.Visible = false;        // 평가 조회 Image
				ibnSearch.Visible = false;        // 평가 조회 ImageButton

				hdfSearchEstID.Value = WebUtility.GetRequest("EST_ID");  // HiddenField에 값을 저장
				EST_ID = hdfSearchEstID.Value;             // 

				// 권한에 따라 버튼의 보여주기 여부 처리함
				BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);

                //if (EST_ID == EST_ID_3GA&& EST_JOB_IDS == "JOB_07")
                //    BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibtnSearchAll.Parent.Controls);

                // 합산여부 (차수 합산)
                if (MERGE_YN.Equals("Y"))
                {
                    ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
                }
                else
                {
                    // DropDownList 보여주기 
                    if (ESTTERM_STEP_ALL_USE_YN.Equals("Y"))
                    {
                        ESTTERM_STEP_ID = 0;
                    }
                    else
                    {
                        ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
                    }
                }

				// EST_JOB_ID에 따라 버튼의 보여주기 여부를 처리함
				BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
													, tdImgBox.Controls
													, COMP_ID
													, hdfSearchEstID.Value
													, ESTTERM_REF_ID
													, ESTTERM_SUB_ID
													, ESTTERM_STEP_ID);

				// EST_JOB_ID에 따라 진행상태아이콘 Html코드 반영
				SetConfirmStatusHtml(EST_JOB_IDS);

				// 전체검색 버튼 클릭에 따라 값이 true or false
				SEARCH_ALL = false;

				// -------------- 주석 시작 --------------
				//if(YEAR_YN.Equals("N") && MERGE_YN.Equals("N")) 
				//{
				//    SEARCH_ALL = false;
				//}
				//else if(ibnSearchAll.Visible) 
				//{
				//    SEARCH_ALL = true;
				//}
				// -------------- 주석 끝 --------------

                //과거년도 점수 비활성화 여부
                if (!User.IsInRole(ROLE_ADMIN) && !User.IsInRole(ROLE_EST_EMPLOYEE) && !User.IsInRole(ROLE_TEAM_MANAGER))
                {
                    Biz_EstInfos biz = new Biz_EstInfos();
                    DataTable dtBiz = biz.GetEstInfo(COMP_ID, EST_ID).Tables[0];
                    if (dtBiz.Rows.Count > 0)
                        IVISIBLE_PAST_POINT_YN = (dtBiz.Rows[0]["VISIBLE_PAST_POINT_YN"].ToString().Trim() == "N" ? false : true);
                }

                // 그리드 데이터 바인딩
                if ((EST_ID == EST_ID_3GA || EST_ID == EST_ID_3A) && EST_JOB_IDS == "JOB_91")//MBO평가면
                    DoBindingMbo();
                else
                    GridBidingData(COMP_ID
								, EST_ID
								, ESTTERM_REF_ID
								, ESTTERM_SUB_ID
								, ESTTERM_STEP_ID
								, SEARCH_ALL);
			}
		}

		COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);              // 회사코드
		EST_ID = hdfSearchEstID.Value;                                         // 평가ID
		ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);        // 평가기간ID

		// 년간여부 (주기 합산)
		if (YEAR_YN.Equals("Y"))
		{
			ESTTERM_SUB_ID = BizUtility.GetEstTermSubIDByYearYN(COMP_ID);
		}
		else
		{
			ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
		}

		// 합산여부 (차수 합산)
		if (MERGE_YN.Equals("Y"))
		{
			ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
		}
		else
		{
			// DropDownList 보여주기 
			if (ESTTERM_STEP_ALL_USE_YN.Equals("Y"))
			{
				ESTTERM_STEP_ID = 0;
			}
			else
			{
				ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
			}
		}

		ltrScript.Text = "";

        //this.ibnSearchAll.Visible = false;
        this.ibnConfirmByForce.Visible = false;

        
        

        //string master_site = WebUtility.GetConfig("SITE", "");
        //string bottom_control_id = "MenuControl_Bottom1";
        //string bottom_control_url = string.Format("/_common/lib{0}/MenuControl_Bottom.ascx", master_site);

        //UserControl bottomControl = new UserControl();
        //bottomControl.LoadControl(bottom_control_url);

        ////Control srcControl = this.Page.FindControl(bottom_control_id);
        ////srcControl. = bottomControl;

        

        ////this.Page.DataBind();
        //Control srcControl = this.form2.Controls[51];
        //srcControl = bottomControl;



        


        // 상태 html
        HtmlScriptCommon.CreateStatusHtmlTable(tblViewStatus, EST_ID);
	}

	#endregion

	#region ==================== Page_PreRender =============================

	protected void Page_PreRender(object sender, EventArgs e)
	{
		if (EST_TGT_TYPE.Equals("EST"))
		{
			ibnConfirmTgtOpinion.Visible = false;
		}
		else if (EST_TGT_TYPE.Equals("TGT"))
		{
			ibnConfirmPoint.Visible = false;
		}


		// --------------- 주석 시작 -----------------
		// 년간 집계 평가라고 하더라도 드롭다운을 보여준다.
		//if(YEAR_YN.Equals("Y"))
		//    ddlEstTermSubID.Visible = false;
		// --------------- 주석 끝 --------------------

		if (MERGE_YN.Equals("Y"))
			ddlEstTermStepID.Visible = false;
	}

	#endregion

	
    #region ======================== 울트라 그리드 이벤트 ================

	// UltraGrid의 Layout를 만들때 이벤트 발생 => 처음 페이지를 보여줄 때 한번만 발생한다.
	protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
	{
		// 동적으로 UltraGridColumn를 만들어 준다.
		UltraGridUtility.CreateColumns((UltraWebGrid)sender
										, COMP_ID
										, EST_ID
										, DEFAULT_INDEX_COUNT
										, out DT_COLUMN_INFO
										, (OwnerTypeMode == OwnerType.Dept) ? "D" : "P"
										, EST_JOB_IDS.Split(',')
										, DEPT_COLUMN_NO_USE_YN);

        // mbo평가중 차수합산 외의 작업(평가, 수기조정)은 체크박스 안보이게..
        if ((EST_ID == EST_ID_3GA || EST_ID == EST_ID_3A) && EST_JOB_IDS != "JOB_07")
        {
            //UltraWebGrid1.Bands[0].Columns.RemoveAt(0);
            //UltraWebGrid1.DisplayLayout.Bands[0].HeaderLayout.RemoveAt(0);
            UltraWebGrid1.Bands[0].Columns[0].Hidden = true;
        }

		// 가중치 컬럼을 사용할 경우
		if (COL_WEIGHT_VISIBLE_YN.Equals("Y")
			|| COL_GRADE_VISIBLE_YN.Equals("Y"))
		{
			Biz_DeptEstDetails deptEstDetail = null;
			Biz_DeptPosDetails deptPosDetail = null;
			DataTable dtDeptDetail = null;

			// 업무컬럼를 가져온다.
			DataRow[] drArrColumn = DT_COLUMN_INFO.Select(@"COL_STYLE_ID = 'BIZ' 
                                                                    AND VISIBLE_YN   = 'Y'");

			foreach (DataRow drColumn in drArrColumn)
			{
				// 평가별 가중치를 넣어주기 위해서는 컬럼의 COL_KEY 값에 "WEIGHT_평가ID" 
				// 형식이 들어가 있어야 하는데 해당 평가ID로 WEIGHT_TYPE에 따라
				// 부서별가중치 또는 직급체계별가중치를 적용한다.
				if (drColumn["COL_KEY"].ToString().IndexOf("WEIGHT_") < 0)
					continue;

				string est_id = drColumn["COL_KEY"].ToString().Replace("WEIGHT_", "");

				Biz_EstInfos estSubInfo = new Biz_EstInfos(COMP_ID, est_id);

				if (estSubInfo.Weight_Type.Equals("DPT"))
				{
					deptEstDetail = new Biz_DeptEstDetails();
					dtDeptDetail = deptEstDetail.GetDeptEstDetail(COMP_ID, ESTTERM_REF_ID, 0, est_id).Tables[0];
				}
				else if (estSubInfo.Weight_Type.Equals("POS"))
				{
					deptPosDetail = new Biz_DeptPosDetails();
					dtDeptDetail = deptPosDetail.GetDeptPosDetail(COMP_ID, ESTTERM_REF_ID, 0, est_id).Tables[0];
				}

				if (DT_DEPT_EST_POS_DETAIL == null)
					DT_DEPT_EST_POS_DETAIL = dtDeptDetail;
				else
					DT_DEPT_EST_POS_DETAIL.Merge(dtDeptDetail);
			}
		}
	}

	protected internal void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
	{
		DataRowView drw = (DataRowView)e.Data;

		// 진행상태 컬럼의 HTML코드를 넣어주기 위한 부분
		BizUtility.SetStatusImage(drw, e.Row.Cells);

		// 점수바의 HTML코드를 넣어주기 위한 부분
		BizUtility.SetPointBar(drw, e.Row.Cells);

		// 가중치관련 컬럼 보이기가 Y 인경우
		if (COL_WEIGHT_VISIBLE_YN.Equals("Y"))
		{
			BizUtility.SetWeightByDptPos(DT_COLUMN_INFO.Select(@"COL_STYLE_ID            = 'BIZ' 
                                                              AND VISIBLE_YN              = 'Y'")
										, COMP_ID
										, DT_DEPT_EST_POS_DETAIL
										, drw
										, e.Row.Cells);
		}

		// 평가별 점수 보여주기 사용 여부
		if (COL_POINT_VISIBLE_YN.Equals("Y"))
		{

		}

		// Bias 점수 조정 사용 여부
		if (COL_BIAS_POINT_VISIBLE_YN.Equals("Y"))
		{

		}

		// 등급 보이기 여부
		if (COL_GRADE_VISIBLE_YN.Equals("Y"))
		{
			// 부서별 평가방법일 경우
			if (ScaleTypeMode.Equals("DPT"))
			{
				DataRow[] drArr = DT_DEPT_SCALE.Select(string.Format("DEPT_REF_ID = {0}", drw["TGT_DEPT_ID"]));

				if (drArr.Length > 0)
				{
					// 절대평가인 경우 계산된 등급컬럼에 범위 구간에 따라 값을 반환받는다.
					if (drArr[0]["SCALE_ID"].ToString().Equals("ABS"))
					{
						BizUtility.SetGradeByScale_ABS(DT_SCOPE
													, drw
													, e.Row.Cells);
					}
					else if (drArr[0]["SCALE_ID"].ToString().Equals("REL"))
					{
						// 상대평가인 경우 상대그룹 안에 총명수에 해당하는 등수로 상위%를 구한 후 
						// 해당하는 등급 구간에 등급을 반환 받는다.
						BizUtility.SetGradeByScale_REL(DT_SCOPE
													, DT_EST_DATA
													, drw
													, e.Row.Cells);
					}
				}
			} // 직급,직책별 평가방법일 경우
			else if (ScaleTypeMode.Equals("POS"))
			{
				string scale_id = "ABS";

				//해당 부서 중 직책, 직급을 선별
				DataRow[] dtArrPosScale = DT_POS_SCALE.Select(string.Format("EST_ID = '{0}' AND DEPT_REF_ID = {1}", EST_ID, drw["TGT_DEPT_ID"]), "SEQ");

				//선별된 직책, 직급의 순서에 따라
				foreach (DataRow drChildPosScale in dtArrPosScale)
				{
					// 기본값이면
					if (drChildPosScale["POS_VALUE"].ToString().Equals("-"))
					{
						scale_id = DataTypeUtility.GetValue(drChildPosScale["SCALE_ID"]);
						break;
					}
					else // 선별된 직급
					{
						if (drw[string.Format("TGT_POS_{0}_ID", drChildPosScale["POS_ID"])].ToString().Equals(drChildPosScale["POS_VALUE"].ToString()))
						{
							scale_id = DataTypeUtility.GetValue(drChildPosScale["SCALE_ID"]);
							break;
						}
					}
				}

				// 위의 내용과 같다.
				if (scale_id.Equals("ABS"))
				{
					BizUtility.SetGradeByScale_ABS(DT_SCOPE
												, drw
												, e.Row.Cells);
				}
				else if (scale_id.Equals("REL"))
				{
					BizUtility.SetGradeByScale_REL(DT_SCOPE
												, DT_EST_DATA
												, drw
												, e.Row.Cells);
				}
			}
		}

		// 등급을 점수로 환산 사용 여부
		if (COL_GRADE_TO_POINT_VISIBLE_YN.Equals("Y"))
		{
			// 현재 사용하지 않는 내용
			BizUtility.SetGradeToPoint(DT_SCOPE
										, drw
										, e.Row.Cells);
		}

		// 주기별 집계 사용 여부
		if (COL_ESTTERM_SUB_AGG_VISIBLE_YN.Equals("Y"))
		{

		}

		// 차수별 집계 사용 여부
		if (COL_ESTTERM_STEP_AGG_VISIBLE_YN.Equals("Y"))
		{

		}

		// 점수 조정 사용 여부
		if (COL_CTRL_POINT_VISIBLE_YN.Equals("Y"))
		{
			// 점수 조정할 때
			BizUtility.SetCtrlPoint(drw
									, e.Row.Cells
									, DT_COLUMN_INFO
									, DT_CTRL_INFO
									, DT_CTRL_EST_DEPT_MAP
									, DT_CTRL_POINT_DATA
									, EMP_REF_ID);
		}

		// 등급 조정 사용 여부
		if (COL_CTRL_GRADE_VISIBLE_YN.Equals("Y"))
		{
			BizUtility.SetCtrlGrade(drw
									, e.Row.Cells
									, DT_COLUMN_INFO
									, DT_CTRL_INFO
									, DT_CTRL_EST_DEPT_MAP
									, DT_CTRL_GRADE_DATA
									, EMP_REF_ID);
		}


		//------------------ 추가 시작 ------------------------------
		// 만약 직무가 존재한다면 쉽표로 구분지어 데이터를 더한다.
		if (USE_POS_BIZ)
		{
			DataRow[] drArrPosBiz = DT_POS_BIZ.Select(string.Format(@"EMP_REF_ID = {0}", drw["TGT_EMP_ID"]));
			string temp = "";

			for (int i = 0; i < drArrPosBiz.Length; i++)
			{
				if (i > 0)
					temp += ",";

				temp += DataTypeUtility.GetValue(drArrPosBiz[i]["POS_BIZ_NAME"]);
			}

			e.Row.Cells.FromKey("TGT_POS_BIZ_NAME").Value = temp;
		}

		// 만약 시스템관리자가 아닌 경우 (시스템관리자만 전제보기 버튼을 사용할 수 있다. 설정으로 변경할 수 있지만 일반적으로...)
        //if (ibnSearchAll.Visible != true)
        //{
        //    // 평가자 화면인데 평가가로 로그인 하지 않은 경우 나 피평가자로 화면인데 피평가자로 로그인 하지 않은 경우
        //    // 체크박스 컬럼의 사용을 금하게 한다. 현재는 기능상의 오류로 주석처리를 했는 차후 체크해야 할 부분임
        //    if ((EST_TGT_TYPE.Equals("EST")
        //        && DataTypeUtility.GetToInt32(drw["EST_EMP_ID"]) != EMP_REF_ID)
        //    || (EST_TGT_TYPE.Equals("TGT")
        //         && DataTypeUtility.GetToInt32(drw["TGT_EMP_ID"]) != EMP_REF_ID))
        //    {
        //        TemplatedColumn tempCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
        //        CheckBox cBox = (CheckBox)((CellItem)tempCol.CellItems[e.Row.BandIndex]).FindControl("cBox");

        //        //cBox.Enabled = false;
        //    }
        //}
		//------------------ 추가 끝 ------------------------------

        if (EST_JOB_IDS.Equals("JOB_05"))
        {
            // 등급확정 시 이의신청 확인
            if (e.Row.Cells.FromKey("GRADE_ID") != null)
            {
                int tgt_emp_id = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("tgt_emp_id").Value);
                string grade_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("GRADE_ID").Value);

                MicroBSC.Integration.EST.Biz.Biz_Est_Refusal bizRefusal = new MicroBSC.Integration.EST.Biz.Biz_Est_Refusal();
                DataTable dtRefusal = bizRefusal.Get_Est_Refusal_Data(COMP_ID
                                                                    , EST_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , ESTTERM_STEP_ID
                                                                    , 0
                                                                    , tgt_emp_id);

                string url = "{0}<a href='javascript:gfOpenWindow(\"../est/EST110100M1.aspx?TGT_EMP_ID={1}&EST_TGT_TYPE=EST\",400,500,false,false);' style='color:red;font-weight:bold;'>{2}</a>";



                if (dtRefusal.Rows.Count > 0)
                {
                    grade_id = string.Format(url, grade_id, tgt_emp_id, "(이의)");
                }

                e.Row.Cells.FromKey("GRADE_ID").Value = grade_id;
            }
        }


	}

	#endregion

	#region ==================== 드롭다운 리스트 ================

	// 평가기간 드롭다운리스트의 선택을 변경했을 경우
	protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (HasGroupByColumns()) return;

		ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        if (EST_ID != EST_ID_3GA && EST_ID != EST_ID_3A)
		    GridBidingData(COMP_ID
					     , EST_ID
					     , ESTTERM_REF_ID
					     , ESTTERM_SUB_ID
					     , ESTTERM_STEP_ID
					     , SEARCH_ALL);
        else
            DoBindingMbo();
	}

	// 평가주기 드롭다운리스트의 선택을 변경했을 경우
	protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (HasGroupByColumns()) return;

		ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        if (EST_ID != EST_ID_3GA && EST_ID != EST_ID_3A)
		    GridBidingData(COMP_ID
					     , EST_ID
					     , ESTTERM_REF_ID
					     , ESTTERM_SUB_ID
					     , ESTTERM_STEP_ID
					     , SEARCH_ALL);
        else
            DoBindingMbo();
	}

	// 평가차수 드롭다운리스트의 선택을 변경했을 경우
	protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (HasGroupByColumns()) return;

		ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
        if (EST_ID != EST_ID_3GA && EST_ID != EST_ID_3A)
            GridBidingData(COMP_ID
                         , EST_ID
                         , ESTTERM_REF_ID
                         , ESTTERM_SUB_ID
                         , ESTTERM_STEP_ID
                         , SEARCH_ALL);
        else
            DoBindingMbo();
	}

	// 회사 드롭다운리스트의 선택을 변경했을 경우 (회사가 한개일 경우는 보이지 않음)
	protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (HasGroupByColumns()) return;

		COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

		GridBidingData(COMP_ID
					 , EST_ID
					 , ESTTERM_REF_ID
					 , ESTTERM_SUB_ID
					 , ESTTERM_STEP_ID
					 , SEARCH_ALL);

		BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);

		BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
											, tdImgBox.Controls
											, COMP_ID
											, hdfSearchEstID.Value
											, ESTTERM_REF_ID
											, ESTTERM_SUB_ID
											, ESTTERM_STEP_ID);

		SetConfirmStatusHtml(EST_JOB_IDS);
	}

    //피평가부서 선택변경
    protected void ddlTgtDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBindingMbo();
    }

	#endregion

	#region ================ 버튼 클릭 이벤트 =========================

	/// <summary>
	/// 팝업창에서 부모창을 Refresh 되었을 때
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void lbnReload_Click(object sender, EventArgs e)
	{
		if (HasGroupByColumns()) return;

		GridBidingData(COMP_ID
					 , EST_ID
					 , ESTTERM_REF_ID
					 , ESTTERM_SUB_ID
					 , ESTTERM_STEP_ID
					 , SEARCH_ALL);

		BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);
		BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
											, tdImgBox.Controls
											, COMP_ID
											, EST_ID
											, ESTTERM_REF_ID
											, ESTTERM_SUB_ID
											, ESTTERM_STEP_ID);

		SetConfirmStatusHtml(EST_JOB_IDS);
	}

	/// <summary>
	/// 조회 클릭
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
	{
		if (HasGroupByColumns()) return;

		GridBidingData(COMP_ID
					 , EST_ID
					 , ESTTERM_REF_ID
					 , ESTTERM_SUB_ID
					 , ESTTERM_STEP_ID
					 , SEARCH_ALL);

		BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);
		BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
											, tdImgBox.Controls
											, COMP_ID
											, EST_ID
											, ESTTERM_REF_ID
											, ESTTERM_SUB_ID
											, ESTTERM_STEP_ID);
	}

	/// <summary>
	/// 전체 리스트 가지고 오기
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnSearchAll_Click(object sender, ImageClickEventArgs e)
	{
		SEARCH_ALL = true;

		GridBidingData(COMP_ID
					 , EST_ID
					 , ESTTERM_REF_ID
					 , ESTTERM_SUB_ID
					 , ESTTERM_STEP_ID
					 , SEARCH_ALL);

		BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);
		BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
											, tdImgBox.Controls
											, COMP_ID
											, EST_ID
											, ESTTERM_REF_ID
											, ESTTERM_SUB_ID
											, ESTTERM_STEP_ID);

		SetConfirmStatusHtml(EST_JOB_IDS);
	}

	private bool _is_search_emp = false;

	/// <summary>
	/// 데이터 조회
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnSearchEmp_Click(object sender, ImageClickEventArgs e)
	{
		SEARCH_ALL = true;

		_is_search_emp = true;

		GridBidingData(COMP_ID
					 , EST_ID
					 , ESTTERM_REF_ID
					 , ESTTERM_SUB_ID
					 , ESTTERM_STEP_ID
					 , SEARCH_ALL);

		BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);
		BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
											, tdImgBox.Controls
											, COMP_ID
											, EST_ID
											, ESTTERM_REF_ID
											, ESTTERM_SUB_ID
											, ESTTERM_STEP_ID);

		SetConfirmStatusHtml(EST_JOB_IDS);
	}

	/// <summary>
	/// 질의평가 확정 (JOB_01)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnConfirmEstQ_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		if (!EST_TGT_TYPE.Equals("EST"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("평가자 평가 방식이 아닙니다. 솔루션 세팅이 잘못되었습니다.");
			return;
		}

		Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);
		Biz_Datas data = new Biz_Datas();
		DataTable dataTable = data.GetDataTableSchema();

		// 울트라 그리드에서 체크된 Row로 string 배열로 넣은 컬럼들로 DataTable을 반환한다.
		dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
															, "cBox"
															, "selchk"
															, new string[] { "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID", "STATUS_ID", "DIRECTION_TYPE" }
															, dataTable);

		if (estInfo.FeedBack_YN.Equals("Y"))
		{
			// 의견상신인지
			dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'O'");
		}
		else
		{
			// 평가중인지
			dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'P'");
		}

		if (dataTable.Rows.Count == 0)
		{
			ltrScript.Text = JSHelper.GetAlertScript("상태가 평가 중이 아니거나 선택된 항목이 없습니다.");
			return;
		}

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;

			if (estInfo.FeedBack_YN.Equals("Y"))
			{
				// 상향평가/하향평가에 따라 확정을 틀리게 해준다.
				if (DataTypeUtility.GetValue(dataRow["DIRECTION_TYPE"]).Equals("UP"))
				{
					dataRow["STATUS_ID"] = "E";
				}
				else
				{
					dataRow["STATUS_ID"] = "C";
				}
			}
			else
			{
				dataRow["STATUS_ID"] = "E";
			}

            dataRow["STATUS_DATE"] = DateTime.Now.ToString("yyyy-MM-dd");
            dataRow["DATE"] = DateTime.Now.ToString("yyyy-MM-dd");
            dataRow["USER"] = this.gUserInfo.Emp_Ref_ID;
		}

		bool isOK = data.SaveStatus(dataTable);

		if (isOK)
		{
			if (data.CheckStatusByEstEmp(COMP_ID
										, EST_ID
										, ESTTERM_REF_ID
										, ESTTERM_SUB_ID
										, ESTTERM_STEP_ID
										, estInfo.FeedBack_YN))
			{
				bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																			, EST_ID
																			, ESTTERM_REF_ID
																			, ESTTERM_SUB_ID
																			, ESTTERM_STEP_ID
																			, est_job_id
																			, null
																			, null
																			, "Y"
																			, DateTime.Now
																			, EMP_REF_ID
																			, ltrScript);

				BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
													, tdImgBox.Controls
													, COMP_ID
													, hdfSearchEstID.Value
													, ESTTERM_REF_ID
													, ESTTERM_SUB_ID
													, ESTTERM_STEP_ID);
			}

			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가를 확정하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정되지 않았습니다.");
		}
	}

	/// <summary>
	/// 질의확정 취소
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnCancelEstQ_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		// 평가자인 경우 질의확정 취소를 할 수 있다.
		if (!EST_TGT_TYPE.Equals("EST"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("평가자 평가 방식이 아닙니다. 솔루션 세팅이 잘못되었습니다.");
			return;
		}

		// 작업 상태 여부의 값을 받아온다.
		string status_yn = EstJobUtility.GetStatusYN(COMP_ID
													, EST_ID
													, ESTTERM_REF_ID
													, ESTTERM_SUB_ID
													, ESTTERM_STEP_ID
													, est_job_id);

		if (status_yn.Equals("Y"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("질의작업이 모두 확정되어 작성취소를 할 수 없습니다.");
			return;
		}

		Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);
		Biz_Datas data = new Biz_Datas();
		DataTable dataTable = data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
															, "cBox"
															, "selchk"
															, new string[] { "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID", "STATUS_ID", "DIRECTION_TYPE" }
															, dataTable);

		if (estInfo.FeedBack_YN.Equals("Y"))
		{
			// 상향평가/하향평가에 따라 확정을 틀리게 해준다.
			dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "(STATUS_ID = 'E' AND DIRECTION_TYPE = 'UP') OR (STATUS_ID = 'C' AND DIRECTION_TYPE = 'DN')");
		}
		else
		{
			dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'E'");
		}

		if (dataTable.Rows.Count == 0)
		{
			ltrScript.Text = JSHelper.GetAlertScript("상태가 평가완료가 아니거나 선택된 항목이 없습니다.");
			return;
		}

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;

			if (estInfo.FeedBack_YN.Equals("Y"))
			{
				// 상향평가/하향평가에 따라 확정을 틀리게 해준다.
				if (DataTypeUtility.GetValue(dataRow["DIRECTION_TYPE"]).Equals("UP"))
				{
					dataRow["STATUS_ID"] = "O";
				}
				else
				{
					dataRow["STATUS_ID"] = "O";
				}
			}
			else
			{
				dataRow["STATUS_ID"] = "P";
			}

            dataRow["STATUS_DATE"] = DateTime.Now.ToString("yyyy-MM-dd");
            dataRow["DATE"] = DateTime.Now.ToString("yyyy-MM-dd");
            dataRow["USER"] = this.gUserInfo.Emp_Ref_ID;
		}

		bool isOK = data.SaveStatus(dataTable);

		if (isOK)
		{
			bool isJobOK = false;

			if (status_yn.Equals("Y"))
				isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																		, EST_ID
																		, ESTTERM_REF_ID
																		, ESTTERM_SUB_ID
																		, ESTTERM_STEP_ID
																		, est_job_id
																		, null
																		, null
																		, "N"
																		, DateTime.Now
																		, EMP_REF_ID
																		, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 다면평가를 취소하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 취소되지 않았습니다.");
		}
	}

	/// <summary>
	/// 의견상신 확정 (JOB_02)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnConfirmTgtOpinion_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		if (!EST_TGT_TYPE.Equals("TGT"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("피평가자 평가 방식이 아닙니다. 솔루션 세팅이 잘못되었습니다.");
			return;
		}

		Biz_Datas data = new Biz_Datas();
		DataTable dataTable = data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
															, "cBox"
															, "selchk"
															, new string[] { "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID", "STATUS_ID" }
															, dataTable);

		dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'O'");

		if (dataTable.Rows.Count == 0)
		{
			ltrScript.Text = JSHelper.GetAlertScript("상태가 의견상신 중이 아니거나 선택된 항목이 없습니다.");
			return;
		}

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;
			dataRow["STATUS_ID"] = "C";
		}

		bool isOK = data.SaveStatus(dataTable);

		if (isOK)
		{
			if (data.CheckStatusByOpinion(COMP_ID
										, EST_ID
										, ESTTERM_REF_ID
										, ESTTERM_SUB_ID
										, ESTTERM_STEP_ID))
			{
				bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																			, EST_ID
																			, ESTTERM_REF_ID
																			, ESTTERM_SUB_ID
																			, ESTTERM_STEP_ID
																			, est_job_id
																			, null
																			, null
																			, "Y"
																			, DateTime.Now
																			, EMP_REF_ID
																			, ltrScript);

				BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
													, tdImgBox.Controls
													, COMP_ID
													, hdfSearchEstID.Value
													, ESTTERM_REF_ID
													, ESTTERM_SUB_ID
													, ESTTERM_STEP_ID);
			}

			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가를 확정하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정되지 않았습니다.", false);
		}
	}

	/// <summary>
	/// 의견상신 취소
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnCancelTgtOpinion_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		if (!EST_TGT_TYPE.Equals("TGT"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("피평가자 평가 방식이 아닙니다. 솔루션 세팅이 잘못되었습니다.");
			return;
		}

		string status_yn = EstJobUtility.GetStatusYN(COMP_ID
													, EST_ID
													, ESTTERM_REF_ID
													, ESTTERM_SUB_ID
													, ESTTERM_STEP_ID
													, est_job_id);

		if (status_yn.Equals("Y"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("질의작업이 모두 확정되어 의견상신 취소를 할 수 없습니다.");
			return;
		}

		Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);
		Biz_Datas data = new Biz_Datas();
		DataTable dataTable = data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
															, "cBox"
															, "selchk"
															, new string[] { "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID", "STATUS_ID" }
															, dataTable);

		dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'C'");

		if (dataTable.Rows.Count == 0)
		{
			ltrScript.Text = JSHelper.GetAlertScript("상태가 상신완료가 아니거나 선택된 항목이 없습니다.");
			return;
		}

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;
			dataRow["STATUS_ID"] = "O";
		}

		bool isOK = data.SaveStatus(dataTable);

		if (isOK)
		{
			bool isJobOK = false;

			if (status_yn.Equals("Y"))
				isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																		, EST_ID
																		, ESTTERM_REF_ID
																		, ESTTERM_SUB_ID
																		, ESTTERM_STEP_ID
																		, est_job_id
																		, null
																		, null
																		, "N"
																		, DateTime.Now
																		, EMP_REF_ID
																		, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 의견상신 취소를 하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 의견상신 취소되지 않았습니다.");
		}
	}

	/// <summary>
	/// 피드백 확정 (JOB_28)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnConfirmFeedback_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		if (!EST_TGT_TYPE.Equals("TGT"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("피평가자 평가 방식이 아닙니다. 솔루션 세팅이 잘못되었습니다.");
			return;
		}

		Biz_Datas data = new Biz_Datas();
		DataTable dataTable = data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
															, "cBox"
															, "selchk"
															, new string[] { "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID", "STATUS_ID" }
															, dataTable);

		dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'P'");

		if (dataTable.Rows.Count == 0)
		{
			ltrScript.Text = JSHelper.GetAlertScript("상태가 피드백 중이 아니거나 선택된 항목이 없습니다.");
			return;
		}

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;
			dataRow["STATUS_ID"] = "E";
            dataRow["DATE"] = DateTime.Now.ToString("yyyy-MM-dd");
		}

		bool isOK = data.SaveStatus(dataTable);

		if (isOK)
		{
			if (data.CheckStatusByFeedback(COMP_ID
										, EST_ID
										, ESTTERM_REF_ID
										, ESTTERM_SUB_ID
										, ESTTERM_STEP_ID))
			{
				bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																			, EST_ID
																			, ESTTERM_REF_ID
																			, ESTTERM_SUB_ID
																			, ESTTERM_STEP_ID
																			, est_job_id
																			, null
																			, null
																			, "Y"
																			, DateTime.Now
																			, EMP_REF_ID
																			, ltrScript);

				BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
													, tdImgBox.Controls
													, COMP_ID
													, hdfSearchEstID.Value
													, ESTTERM_REF_ID
													, ESTTERM_SUB_ID
													, ESTTERM_STEP_ID);
			}

			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 피드백을 확정하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정되지 않았습니다.", false);
		}
	}

	/// <summary>
	/// 피드백 확정 취소
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnCancelFeedback_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		if (!EST_TGT_TYPE.Equals("TGT"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("피평가자 평가 방식이 아닙니다. 솔루션 세팅이 잘못되었습니다.");
			return;
		}

		string status_yn = EstJobUtility.GetStatusYN(COMP_ID
													, EST_ID
													, ESTTERM_REF_ID
													, ESTTERM_SUB_ID
													, ESTTERM_STEP_ID
													, est_job_id);

		if (status_yn.Equals("Y"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("질의작업이 모두 확정되어 피드백을 취소 할 수 없습니다.");
			return;
		}

		Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);
		Biz_Datas data = new Biz_Datas();
		DataTable dataTable = data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
															, "cBox"
															, "selchk"
															, new string[] { "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID", "STATUS_ID" }
															, dataTable);

		dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'E'");

		if (dataTable.Rows.Count == 0)
		{
			ltrScript.Text = JSHelper.GetAlertScript("상태가 피드백 완료가 아니거나 선택된 항목이 없습니다.");
			return;
		}

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;
			dataRow["STATUS_ID"] = "C";
            dataRow["DATE"] = DateTime.Now.ToString("yyyy-MM-dd");
		}

		bool isOK = data.SaveStatus(dataTable);

		if (isOK)
		{
            

			bool isJobOK = false;

			if (status_yn.Equals("Y"))
				isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																		, EST_ID
																		, ESTTERM_REF_ID
																		, ESTTERM_SUB_ID
																		, ESTTERM_STEP_ID
																		, est_job_id
																		, null
																		, null
																		, "N"
																		, DateTime.Now
																		, EMP_REF_ID
																		, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 피드백 취소를 하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 피드백 취소되지 않았습니다.");
		}
	}

	/// <summary>
	/// 점수 확정 (JOB_03)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnConfirmPoint_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		SetConfirmStatusHtml(EST_JOB_IDS);

		if (isJobOK)
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가점수를 확정하였습니다.");
	}

	/// <summary>
	/// Bias 조정점수 확정 (JOB_04)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnConfirmBias_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																		, EST_ID
																		, ESTTERM_REF_ID
																		, ESTTERM_SUB_ID
																		, ESTTERM_STEP_ID
																		, est_job_id
																		, ibn
																		, null
																		, "Y"
																		, DateTime.Now
																		, EMP_REF_ID
																		, ltrScript);
		SetConfirmStatusHtml(EST_JOB_IDS);

		if (isJobOK)
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 Bias 조정점수를 확정하였습니다.");
	}

	/// <summary>
	/// 등급 확정 (JOB_05)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnConfirmGrade_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		Biz_Datas biz_data = new Biz_Datas();
		DataTable dataTable = biz_data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid1
															, new string[] {  "EST_ID"
                                                                            , "ESTTERM_REF_ID"
                                                                            , "ESTTERM_SUB_ID"
                                                                            , "ESTTERM_STEP_ID"
                                                                            , "EST_DEPT_ID"
                                                                            , "EST_EMP_ID"
                                                                            , "TGT_DEPT_ID"
                                                                            , "TGT_EMP_ID"
                                                                            , "GRADE_CALC_ID" }
															, dataTable);

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;
			dataRow["GRADE_ID"] = dataRow["GRADE_CALC_ID"];
			dataRow["GRADE_DATE"] = DateTime.Now;
			dataRow["DATE"] = DateTime.Now;
			dataRow["USER"] = EMP_REF_ID;
		}

		if (dataTable.Select("GRADE_CALC_ID = ''").Length > 0)
		{
			ltrScript.Text = JSHelper.GetAlertScript("평가등급을 부여 받지 못한 사원이 있습니다. 운영관리에서 평가별 등급세팅을 확인하세요.");
			return;
		}

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;

		bool isOK = biz_data.ConfirmGrade(dataTable);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등급을 확정하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("등급 확정 중 오류가 발생하였습니다.");
		}
	}

	/// <summary>
	/// 등급을 점수로 환산 (JOB_06)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnGradeToPoint_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;

		Biz_Datas biz_data = new Biz_Datas();
		DataTable dataTable = biz_data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid1
															, new string[] {  "EST_ID"
                                                                            , "ESTTERM_REF_ID"
                                                                            , "ESTTERM_SUB_ID"
                                                                            , "ESTTERM_STEP_ID"
                                                                            , "EST_DEPT_ID"
                                                                            , "EST_EMP_ID"
                                                                            , "TGT_DEPT_ID"
                                                                            , "TGT_EMP_ID"
                                                                            , "GRADE_TO_POINT_CALC" }
															, dataTable);

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;
			dataRow["GRADE_TO_POINT"] = dataRow["GRADE_TO_POINT_CALC"];
			dataRow["GRADE_TO_POINT_DATE"] = DateTime.Now;
			dataRow["DATE"] = DateTime.Now;
			dataRow["USER"] = EMP_REF_ID;
		}

		bool isOK = biz_data.GradeToPoint(dataTable);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등급을 점수로 환산하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("등급을 점수로 환산 중 오류가 발생하였습니다.");
		}
	}

	/// <summary>
	/// 평가차수에 따른 점수 가중치 적용 집계 (JOB_07)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>

	protected void ibnAggEstTermStep_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;

		Biz_Datas biz_data = new Biz_Datas();
		DataTable dtStatusCheck = biz_data.GetDataByMergeYN(COMP_ID
															, EST_ID
															, ESTTERM_REF_ID
															, ESTTERM_SUB_ID
															, ESTTERM_STEP_ID
															, "N"
															, OwnerTypeMode).Tables[0];


		//-------------------- 주석 시작 ----------------
		//if(dtStatusCheck.Rows.Count != dtStatusCheck.Select("STATUS_ID = 'E'").Length)
		//{
		//    ltrScript.Text = JSHelper.GetAlertScript("확정되지 않은 평가정보가 있습니다. 모두 확정된 상태에서 차수별 합산이 가능합니다.");
		//    return;
		//}
		//-------------------- 주석 끝 ------------------

		//, BizUtility.GetTotalWeightEstTermStep(COMP_ID, EST_ID)
		// MERGE_YN 이 N 인 이유는 N인 것만 데이터를 수집해서 집계하기 때문
        //bool isOK = biz_data.AggregateEstTermStepEstData(COMP_ID
        //                                                        , EST_ID
        //                                                        , ESTTERM_REF_ID
        //                                                        , ESTTERM_SUB_ID
        //                                                        , ESTTERM_STEP_ID
        //                                                        , BizUtility.GetTotalWeightEstTermStep(COMP_ID, EST_ID)
        //                                                        , YEAR_YN
        //                                                        , "N"
        //                                                        , OwnerTypeMode);

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        bool isOK = bizEstData.AggregateEstTermStepEstData(COMP_ID
                                                               , EST_ID
                                                               , ESTTERM_REF_ID
                                                               , ESTTERM_SUB_ID
                                                               , ESTTERM_STEP_ID
                                                               , BizUtility.GetTotalWeightEstTermStep(COMP_ID, EST_ID)
                                                               , YEAR_YN
                                                               , "N"
                                                               , OwnerTypeMode);

		if (isOK)
		{
            if (EST_ID.Equals("3O"))
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 다면평가 점수를 합산하였습니다.");
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가차수에 따른 가중치 집계를 처리하였습니다.");
            }

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

            if (EST_ID.Equals("3O"))
            {
                ltrScript.Text = JSHelper.GetAlertScript("다면평가 점수 합산 처리 중 오류가 발생하였습니다.");
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("가중치 집계 처리 중 오류가 발생하였습니다.");
            }
		}
	}

	/// <summary>
	/// 평가주기에 따른 점수 가중치 적용 집계 (JOB_08)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>

	protected void ibnAggEstTermSub_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;


		Biz_Datas biz_data = new Biz_Datas();
		DataTable dtStatusCheck = biz_data.GetDataByYearYN(COMP_ID
															, EST_ID
															, ESTTERM_REF_ID
															, ESTTERM_SUB_ID
															, ESTTERM_STEP_ID
															, "N"
															, OwnerTypeMode).Tables[0];

		if (dtStatusCheck.Rows.Count != dtStatusCheck.Select("STATUS_ID = 'E'").Length)
		{
			ltrScript.Text = JSHelper.GetAlertScript("확정되지 않은 평가정보가 있습니다. 모두 확정된 상태에서 주기별 합산이 가능합니다.");
			return;
		}

		// YEAR_YN 이 N 인 이유는 N인 것만 데이터를 수집해서 집계하기 때문
		bool isOK = biz_data.AggregateEstTermSubEstData(COMP_ID
																, EST_ID
																, ESTTERM_REF_ID
																, BizUtility.GetEstTermSubIDByYearYN(COMP_ID)
																, BizUtility.GetEstTermStepIDByMergeYN(COMP_ID)
																, BizUtility.GetTotalWeightEstTermSub(COMP_ID, EST_ID)
																, "N"
																, MERGE_YN
																, OwnerTypeMode);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가주기에 따른 가중치 집계를 처리하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("가중치 집계 처리 중 오류가 발생하였습니다.");
		}
	}

	/// <summary>
	/// 점수 조정 확정 (JOB_09)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnCtrlConfirmPoint_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		SetConfirmStatusHtml(EST_JOB_IDS);

		if (isJobOK)
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 점수조정을 확정하였습니다.");
	}

	/// <summary>
	/// 등급 조정 확정 (JOB_10)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnCtrlConfirmGrade_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;

		Biz_Datas biz_data = new Biz_Datas();
		DataTable dataTable = biz_data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid1
															, new string[] {  "EST_ID"
                                                                            , "ESTTERM_REF_ID"
                                                                            , "ESTTERM_SUB_ID"
                                                                            , "ESTTERM_STEP_ID"
                                                                            , "EST_DEPT_ID"
                                                                            , "EST_EMP_ID"
                                                                            , "TGT_DEPT_ID"
                                                                            , "TGT_EMP_ID"
                                                                            , "GRADE_ID" }
															, dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"] = COMP_ID;
            //dataRow["GRADE_ID"] = dataRow["GRADE_CALC_ID"];
            //dataRow["GRADE_DATE"] = DateTime.Now;
            //dataRow["DATE"] = DateTime.Now;
            //dataRow["USER"] = EMP_REF_ID;
        }

        //bool isOK = false;
        bool isOK = biz_data.ConfirmGrade(dataTable);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등급을 확정하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("등급 확정 중 오류가 발생하였습니다.");
		}
	}

	/// <summary>
	/// 부서점수를 사원점수를 변환 (JOB_11)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnDeptToEmpData_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;

		Biz_Datas data = new Biz_Datas();
		bool isOK = data.CopyDeptToEmpData(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, YEAR_YN
												, MERGE_YN
												, DateTime.Now
												, EMP_REF_ID);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 부서 평가 정보를 사원 평가 정보로 변환하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("부서 평가 정보를 사원 평가 정보로 변환 중 오류가 발생하였습니다.");
		}
	}

	/// <summary>
	/// 외부 데이터를 평가점수로 가지고 오기 (JOB_12)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnGetOuterData_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;

        //Biz_OuterDataProcInfos biz_data = new Biz_OuterDataProcInfos();
        //string msg = null;
        //bool isOK = biz_data.GetOuterData(COMP_ID
        //                                                            , EST_ID
        //                                                            , ESTTERM_REF_ID
        //                                                            , ESTTERM_SUB_ID
        //                                                            , ESTTERM_STEP_ID
        //                                                            , out msg);

        

        MicroBSC.Integration.EST.Biz.Biz_Est_Outer_Data_Proc_Info biz_data = new MicroBSC.Integration.EST.Biz.Biz_Est_Outer_Data_Proc_Info();
        string msg = null;

        bool isOK = biz_data.GetOuterData(COMP_ID
                                        , EST_ID
                                        , ESTTERM_REF_ID
                                        , ESTTERM_SUB_ID
                                        , ESTTERM_STEP_ID
                                        , out msg);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 외부평가 데이터를 반영하였습니다.");


            // 암호화 키가 있으면 해당 컬럼에 암호화 적용
            //string encryption_key = WebUtility.GetConfig("ENCRYPTION_KEY");
            //if (!encryption_key.Equals(string.Empty))
            //{
            //    MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();
            //    DataTable dtEstData = bizEstData.GetEstData(COMP_ID
            //                                                , EST_ID
            //                                                , ESTTERM_REF_ID
            //                                                , ESTTERM_SUB_ID
            //                                                , ESTTERM_STEP_ID);

            //    for (int i = 0; i < dtEstData.Rows.Count; i++)
            //    {

            //        DataRow row = dtEstData.Rows[i];
            //        string point = MicroBSC.Common.Cryptography.Encrypt(DataTypeUtility.GetValue(row["POINT"]), encryption_key);
            //        row["POINT"] = point;
            //    }

            //    int okCnt = bizEstData.ModifyEstData(dtEstData);
            //}


			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript(msg);
		}
	}

	/// <summary>
	/// 하위 평가점수 가중치 적용하여 데이터 삽입하기 (JOB_13)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    protected void ibnAggChildEstPoint_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn = ((ImageButton)sender);
        string est_job_id = ibn.CommandArgument;

        if (HasGroupByColumns()) return;

        bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                                                    , EST_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , ESTTERM_STEP_ID
                                                                    , est_job_id
                                                                    , ibn
                                                                    , null
                                                                    , "Y"
                                                                    , DateTime.Now
                                                                    , EMP_REF_ID
                                                                    , ltrScript);

        if (!isJobOK)
            return;

        //Biz_Datas biz_data = new Biz_Datas();
        //bool isOK = biz_data.AggregateChildEstData(COMP_ID
        //                                                    , EST_ID
        //                                                    , ESTTERM_REF_ID
        //                                                    , ESTTERM_SUB_ID
        //                                                    , ESTTERM_STEP_ID
        //                                                    , WeightTypeMode);

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        bool isOK = bizEstData.AggregateChildEstData(COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , WeightTypeMode);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 하위 종속 평가의 가중치 적용이 처리되었습니다.");

            GridBidingData(COMP_ID
                         , EST_ID
                         , ESTTERM_REF_ID
                         , ESTTERM_SUB_ID
                         , ESTTERM_STEP_ID
                         , SEARCH_ALL);

            SetConfirmStatusHtml(EST_JOB_IDS);
        }
        else
        {
            EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                                , EST_ID
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID
                                                , est_job_id
                                                , ibn
                                                , null
                                                , "N"
                                                , DateTime.Now
                                                , EMP_REF_ID
                                                , ltrScript);

            ltrScript.Text = JSHelper.GetAlertScript("가중치 적용 처리 중 오류가 발생하였습니다.");
        }
    }

	/// <summary>
	/// 링크된 평가 데이터 가지고 오기 (JOB_21)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnGetLinkEstData_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);

		if (!estInfo.Est_Style_ID.Equals("LNK"))
		{
			ltrScript.Text = JSHelper.GetAlertScript("링크된 데이터를 받는 평가가 아닙니다.");
			return;
		}

		string est_id_from = estInfo.Link_Est_ID;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;

		Biz_Datas biz_data = new Biz_Datas();
		bool isOK = biz_data.CopyEstDataToLinkedEst(COMP_ID
															, est_id_from
															, EST_ID
															, ESTTERM_REF_ID
															, ESTTERM_SUB_ID
															, ESTTERM_STEP_ID
															, YEAR_YN
															, MERGE_YN
															, OwnerTypeMode);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 링크된 평가데이터로 복사하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("링크된 평가데이터 중 오류가 발생하였습니다.");
		}
	}

	// 프로젝트 평가 점수를 사원점수로 반환해주는 내용
	protected void ibnPrjToEmpData_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																	, EST_ID
																	, ESTTERM_REF_ID
																	, ESTTERM_SUB_ID
																	, ESTTERM_STEP_ID
																	, est_job_id
																	, ibn
																	, null
																	, "Y"
																	, DateTime.Now
																	, EMP_REF_ID
																	, ltrScript);

		if (!isJobOK)
			return;

		MicroBSC.PRJ.Biz.Biz_Prj_Data data = new MicroBSC.PRJ.Biz.Biz_Prj_Data();

		bool isOK = data.CopyProjectToEmpData(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, YEAR_YN
												, MERGE_YN
												, DateTime.Now
												, EMP_REF_ID);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 프로젝트 평가 정보를 사원 평가 정보로 변환하였습니다.");

			GridBidingData(COMP_ID
						   , EST_ID
						   , ESTTERM_REF_ID
						   , ESTTERM_SUB_ID
						   , ESTTERM_STEP_ID
						   , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			EstJobUtility.SetConfirmButtonVisible(COMP_ID
												, EST_ID
												, ESTTERM_REF_ID
												, ESTTERM_SUB_ID
												, ESTTERM_STEP_ID
												, est_job_id
												, ibn
												, null
												, "N"
												, DateTime.Now
												, EMP_REF_ID
												, ltrScript);

			ltrScript.Text = JSHelper.GetAlertScript("프로젝트 평가 정보를 사원 평가 정보로 변환 중 오류가 발생하였습니다.");
		}
	}

	protected void ibnAssignDeptPoint_Click(object sender, ImageClickEventArgs e)
	{

	}

	/// <summary>
	/// 평가결과 확인 (JOB_30)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnConfirmEstResult_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
																		, EST_ID
																		, ESTTERM_REF_ID
																		, ESTTERM_SUB_ID
																		, ESTTERM_STEP_ID
																		, est_job_id
																		, ibn
																		, null
																		, "Y"
																		, DateTime.Now
																		, EMP_REF_ID
																		, ltrScript);
		SetConfirmStatusHtml(EST_JOB_IDS);

		if (isJobOK)
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가결과를 확정하였습니다.");
	}

	/// <summary>
	/// 평가/피드백/의견상신 강제확정 (JOB_34)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnConfirmByForce_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton ibn = ((ImageButton)sender);
		string est_job_id = ibn.CommandArgument;

		if (HasGroupByColumns()) return;

		Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);
		Biz_Datas data = new Biz_Datas();
		DataTable dataTable = data.GetDataTableSchema();

		dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
															, "cBox"
															, "selchk"
															, new string[] { "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID", "STATUS_ID" }
															, dataTable);

		dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID <> 'N'");

		if (dataTable.Rows.Count == 0)
		{
			ltrScript.Text = JSHelper.GetAlertScript("상태가 미평가이거나 선택된 항목이 없습니다.");
			return;
		}

		foreach (DataRow dataRow in dataTable.Rows)
		{
			dataRow["COMP_ID"] = COMP_ID;
			dataRow["STATUS_ID"] = "E";
		}

		bool isOK = data.SaveStatus(dataTable);

		if (isOK)
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가를 강제확정하였습니다.");

			GridBidingData(COMP_ID
						 , EST_ID
						 , ESTTERM_REF_ID
						 , ESTTERM_SUB_ID
						 , ESTTERM_STEP_ID
						 , SEARCH_ALL);

			SetConfirmStatusHtml(EST_JOB_IDS);
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 강제확정되지 않았습니다.");
		}
	}


	/// <summary>
	/// 다운로드
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
	{
		uGridExcelExporter.DownloadName = "EST." + DateTime.Now.ToString("yyMMddHHmmss");
		uGridExcelExporter.WorksheetName = "EST_DATA";

		bool isSelect = false;
		bool isStatusImg = false;
		bool isCtrlPoint = false;
		bool isCtrlGrade = false;

		if (UltraWebGrid1.DisplayLayout.Bands[0].Columns.Exists("selchk"))
			isSelect = !UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("selchk").Hidden;

		if (UltraWebGrid1.DisplayLayout.Bands[0].Columns.Exists("STATUS_IMG_PATH"))
			isStatusImg = !UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("STATUS_IMG_PATH").Hidden;

		if (UltraWebGrid1.DisplayLayout.Bands[0].Columns.Exists("CTRL_POINT"))
			isCtrlPoint = !UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("CTRL_POINT").Hidden;

		if (UltraWebGrid1.DisplayLayout.Bands[0].Columns.Exists("CTRL_GRADE"))
			isCtrlGrade = !UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("CTRL_GRADE").Hidden;

		if (isSelect)
			UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("selchk").Hidden = true;

		if (isStatusImg)
			UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("STATUS_IMG_PATH").Hidden = true;

		if (isCtrlPoint)
			UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("CTRL_POINT").Hidden = true;

		if (isCtrlGrade)
			UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("CTRL_GRADE").Hidden = true;

		uGridExcelExporter.Export(UltraWebGrid1);

		if (isSelect)
			UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("selchk").Hidden = false;

		if (isStatusImg)
			UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("STATUS_IMG_PATH").Hidden = false;

		if (isCtrlPoint)
			UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("CTRL_POINT").Hidden = false;

		if (isCtrlGrade)
			UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("CTRL_GRADE").Hidden = false;
	}

    //MBO강제확정
    protected void ibtnConfirmForced_Click(object sender, ImageClickEventArgs e)
    {
        DoConfirmEst(true);
    }
    //mbo확정
    protected void ibtnConfirmMbo_Click(object sender, ImageClickEventArgs e)
    {
        DoConfirmEst(false);
    }
    //mbo확정취소
    protected void ibtnCancelMboConfirm_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas bizDatas = new Biz_Datas();
        if (bizDatas.ConfirmCancelMBOEstimate(this.COMP_ID
                                            , this.EST_ID
                                            , this.ESTTERM_REF_ID
                                            , this.ESTTERM_SUB_ID
                                            , "JOB_91"
                                            , this.EMP_REF_ID))
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정취소하였습니다.");
            DoBindingMbo();
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("확정취소 실패!");
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBindingMbo();
    }

    protected void ibtnSearchAll_Click(object sender, ImageClickEventArgs e)
    {
        if (EST_JOB_IDS == "JOB_91")
        {
            ddlTgtDept.SelectedIndex = 0;
            ddlEstTermStepID.SelectedIndex = 0;
            DoBindingMbo();
        }
        else
        {
            SEARCH_ALL = true;

            GridBidingData(COMP_ID
                         , EST_ID
                         , ESTTERM_REF_ID
                         , ESTTERM_SUB_ID
                         , ESTTERM_STEP_ID
                         , SEARCH_ALL);

            BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);
            BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
                                                , tdImgBox.Controls
                                                , COMP_ID
                                                , EST_ID
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID);

            SetConfirmStatusHtml(EST_JOB_IDS);
        }
    }

	#endregion

	#region =================== 일반 메소드 ==========================

    //mbo확정
    private void DoConfirmEst(bool completeYN)
    {
        Biz_Datas bizDatas = new Biz_Datas();
        if (bizDatas.ConfirmMBOEstimate(this.COMP_ID
                                        , this.EST_ID
                                        , this.ESTTERM_REF_ID
                                        , this.ESTTERM_SUB_ID
                                        , "JOB_91"
                                        , this.EMP_REF_ID
                                        , completeYN))
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정하였습니다.");
            DoBindingMbo();
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("확정 실패!");
    }

	/// <summary>
	/// 그리드 바인딩 메소드
	/// </summary>
	/// <param name="comp_id"></param>
	/// <param name="est_id"></param>
	/// <param name="estterm_ref_id"></param>
	/// <param name="estterm_sub_id"></param>
	/// <param name="estterm_step_id"></param>
	private void GridBidingData(int comp_id
								, string est_id
								, int estterm_ref_id
								, int estterm_sub_id
								, int estterm_step_id
								, bool isAll)
	{
		// 평가정보를 가져온다.
		Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

		// 해당평가가 존재하는지 여부 체크
		if (!estInfo.IsExists(comp_id, est_id))
		{
			ltrScript.Text = JSHelper.GetAlertScript("선택된 회사의 평가정보가 없습니다.");
			return;
		}

		DropDownListCommom.BindEstTermSub(ddlEstTermSubID, comp_id, est_id, YEAR_YN);   // 평가주기 DropDownList 바인딩 
		DropDownListCommom.BindEstTermStep(ddlEstTermStepID, comp_id, est_id);          // 평가차수 DropDownList 바인딩

		// 처음 실행될때 (추가)
		if (estterm_sub_id.Equals(0))    // 값 존재 여부
		{
			ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);     // DropDownList의 값을 반환
		}
		else
		{
			WebUtility.FindByValueDropDownList(ddlEstTermSubID, estterm_sub_id);        // DropDwonList의 값을 선택함
			ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);     // DropDownList의 값을 반환
		}

		estterm_sub_id = ESTTERM_SUB_ID;

		// 만약 주기가 년간일 경우
		if (YEAR_YN.Equals("Y"))
		{
			ESTTERM_SUB_ID = BizUtility.GetEstTermSubIDByYearYN(COMP_ID);               // 년간인 경우 (년간의 주기ID의 값을 반환)
		}

		// 만약 차수가 합산일 경우
		if (MERGE_YN.Equals("Y"))
		{
			ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);            // 차수집계인 경우 (차추집계의 차수ID의 값을 반환)
		}
		else
		{
			// 만약 모든 차수를 보여 줘야하는 경우
			// ESTTERM_STEP_ALL_USE_YN 은 쿼리스트링으로 값을 받는데 이 값의 여부에 따라 차수DropDownList의 컨트롤의
			// 보이기 여부를 처리한다.
			if (ESTTERM_STEP_ALL_USE_YN.Equals("Y"))
			{
				ESTTERM_STEP_ID = 0;
				ddlEstTermStepID.Visible = false;
			}
		}

		WebUtility.FindByValueDropDownList(ddlEstTermRefID, estterm_ref_id);

		if (ddlEstTermSubID.Visible)
			WebUtility.FindByValueDropDownList(ddlEstTermSubID, estterm_sub_id);

		if (ddlEstTermStepID.Visible)
			WebUtility.FindByValueDropDownList(ddlEstTermStepID, estterm_step_id);

		// 상태 html
		HtmlScriptCommon.CreateStatusHtmlTable(tblViewStatus, est_id);

		//// 평가기간별 평가정보
		//Biz_EstDetails estDetail = new Biz_EstDetails(COMP_ID
		//                                            , EST_ID
		//                                            , ESTTERM_REF_ID
		//                                            , ESTTERM_SUB_ID
		//                                            , ESTTERM_STEP_ID);

		//if(estDetail.Owner_Type.Equals("")) 
		//{
		//    if(estInfo.Owner_Type.Equals("D")) 
		//        OwnerTypeMode   = OwnerType.Dept;
		//    else 
		//        OwnerTypeMode   = OwnerType.Emp_User;
		//}
		//else 
		//{
		//    if(estDetail.Owner_Type.Equals("D")) 
		//        OwnerTypeMode   = OwnerType.Dept;
		//    else 
		//        OwnerTypeMode   = OwnerType.Emp_User;
		//}

		// 피평가 주체가 부서인지 사원인지 여부 
		if (estInfo.Owner_Type.Equals("D"))  // D:부서, E:사원
			OwnerTypeMode = OwnerType.Dept;
		else
			OwnerTypeMode = OwnerType.Emp_User;

		ScaleTypeMode = estInfo.Scale_Type;       // 절대,상대평가
		WeightTypeMode = estInfo.Weight_Type;      // 가중치 처리 방식 (부서별 인지 직급체계별 인지)

		if (estInfo.Bias_YN.Equals("Y"))             // Bias 사용 여부
			BiasYN = YesNo.Yes;
		else
			BiasYN = YesNo.No;

		if (estInfo.Grade_Confirm_YN.Equals("Y"))    // 등급확정 여부
			GradeConfirmYN = YesNo.Yes;
		else
			GradeConfirmYN = YesNo.No;

		Biz_Datas est_data = new Biz_Datas();

		int est_emp_id = 0;                    // 평가자 아이디
		int tgt_dept_id = 0;                    // 피평가부서 아이디 or 피평가자가 속한 부서 아이디
		int tgt_emp_id = 0;                    // 피평가자 아이디

		if (OwnerTypeMode == OwnerType.Dept && DEPT_COLUMN_NO_USE_YN.Equals("Y"))
		{
			OwnerTypeMode = OwnerType.Emp_User;
		}
		else if (OwnerTypeMode == OwnerType.Emp_User && DEPT_COLUMN_NO_USE_YN.Equals("Y"))
		{
			OwnerTypeMode = OwnerType.Dept;
		}

        DataTable dtTargetDepartment = null;

		// 만약 피평가자 주체가 부서일 경우
		if (OwnerTypeMode == OwnerType.Dept)
		{
			// 평가자일경우
			if (EST_TGT_TYPE.Equals("EST"))
			{
				est_emp_id = EMP_REF_ID;           // 해당 평가자 아이디에 해당하는 정보 조회
				tgt_dept_id = 0;                    // 모든 피평가부서는 조회됨
				tgt_emp_id = -1;                   // 사원은 조회 안됨 (피평가자 주체가 부서이기 때문)
			}
			else if (EST_TGT_TYPE.Equals("TGT"))     // 피평가자 일경우
			{
				est_emp_id = 0;                    // 모든 평가가 조회됨
				tgt_emp_id = -1;                   // 사원은 조회 안됨 (피평가자 주체가 부서이기 때문)

				// 만약 의견상신이고 STYLE_ID = "0002" 인 경우
				if (estInfo.Tgt_Opinion_YN.Equals("Y") && estInfo.Status_Style_ID.Equals("0002"))
				{
					// 피평가자 부서를 대표하는 사원 DataTable를 받아온다. 
					Biz_DeptOpinionTgtEmps deptOpinionTgtEmp = new Biz_DeptOpinionTgtEmps();
                    dtTargetDepartment = deptOpinionTgtEmp.GetDeptOpinionTgtEmp(COMP_ID
                                                                                                        , EST_ID
                                                                                                        , EMP_REF_ID).Tables[0];
                    /*
                   DataTable dataTable = deptOpinionTgtEmp.GetDeptOpinionTgtEmp(COMP_ID
                                                                                                       , EST_ID
                                                                                                       , EMP_REF_ID).Tables[0];
                   
                   if (dataTable.Rows.Count > 0)
                   {
                       tgt_dept_id = DataTypeUtility.GetToInt32(dataTable.Rows[0]["TGT_DEPT_ID"]);
                   }
                   */
				}
				else
				{
					tgt_dept_id = -1;
				}
			}
		}
		else if (OwnerTypeMode == OwnerType.Emp_User)            // 만약 피평가주체가 사원인 경우
		{
			if (EST_TGT_TYPE.Equals("EST"))              // 평가자로 로그인했을 경우
			{
				est_emp_id = EMP_REF_ID;               // 로그인한 평가자의 아이디로 검색을 한다.
				tgt_dept_id = 0;                        // 모든 피평가자가 속한 부서를 가져온다.
				tgt_emp_id = 0;                        // 모든 피평가자를 가져온다.
			}
			else if (EST_TGT_TYPE.Equals("TGT"))         // 피평가자로 로그인했을 경우
			{
				est_emp_id = 0;                        // 모든 평가자를 가져온다.
				tgt_dept_id = 0;                        // 모든 피평가자가 속한 부서를 가져온다.
				tgt_emp_id = EMP_REF_ID;               // 로그인한 피평가자의 아이디로 검색을 한다.
			}
		}

		if (isAll)                                       // 전체검색 버튼을 클릭했을 경우
		{
			est_emp_id = 0;                            // 모든 피평가자를 가져온다.
			tgt_dept_id = 0;                            // 모든 피평가자가 속한 부서를 가져온다.
			tgt_emp_id = 0;                            // 모든 피평가가를 가져온다.
		}

		//------------ 주석 시작 -------------------
		//DT_EST_DATA = est_data.GetEstData(comp_id
		//                                , est_id
		//                                , ESTTERM_REF_ID
		//                                , ESTTERM_SUB_ID
		//                                , ESTTERM_STEP_ID
		//                                , 0
		//                                , est_emp_id
		//                                , tgt_dept_id
		//                                , tgt_emp_id
		//                                , YEAR_YN
		//                                , MERGE_YN
		//                                , OwnerTypeMode).Tables[0];
		//-------------- 주석 끝 --------------------


		//---------------------- 추가 시작 ---------------------
		int est_emp_id_back_up = 0;

		// 만약 평가별로 하위차수의 평가정보 보여주기가 Y 이면 
		// 피평가자의 모든 리스트를 보여주게 하고
		// 평가자의 정보를 포함한 하위평가 정보를 보여주게 한다.
		if (estInfo.All_Step_Visible_YN.Equals("Y"))
		{
			est_emp_id_back_up = est_emp_id;
			est_emp_id = 0;
		}

		// 점수조정컬럼 및 등급조정컬럼을 사용하고 전체버튼을 클릭하지 않았을 겨우
        if ((COL_CTRL_POINT_VISIBLE_YN.Equals("Y")
            || COL_CTRL_GRADE_VISIBLE_YN.Equals("Y"))
            && isAll == false)
        {
            string grd_pnt_type = "";

            if (COL_CTRL_POINT_VISIBLE_YN.Equals("Y"))
                grd_pnt_type = "PNT";
            else
                grd_pnt_type = "GRD";

            DT_EST_DATA = est_data.GetEstDataByCtrl(comp_id
                                                , est_id
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID
                                                , 0
                                                , 0
                                                , 0
                                                , 0
                                                , YEAR_YN
                                                , MERGE_YN
                                                , OwnerTypeMode
                                                , EMP_REF_ID
                                                , grd_pnt_type).Tables[0];
        }
        else
        {
            /* 2011-05-25 수정 : 피평가자의 의견상신의 경우 피평가자부서에 해당하는 모든 건을 조회하도록 수정 */
            if (EST_TGT_TYPE.Equals("TGT") == true && estInfo.Owner_Type.Equals("D") == true)
            {
                DT_EST_DATA = new DataTable();
                foreach (DataRow rowTgtDepartment in dtTargetDepartment.Rows)
                {
                    tgt_dept_id = DataTypeUtility.GetToInt32(rowTgtDepartment["TGT_DEPT_ID"]);

                    DT_EST_DATA.Merge(est_data.GetEstData(comp_id
                                                , est_id
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID
                                                , 0
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , YEAR_YN
                                                , MERGE_YN
                                                , OwnerTypeMode).Tables[0]);
                }
                /* 2011-05-25 수정 완료 *****************************************************************/
            }
            else
            {
                DT_EST_DATA = est_data.GetEstData(comp_id
                                                , est_id
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID
                                                , 0
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , YEAR_YN
                                                , MERGE_YN
                                                , OwnerTypeMode).Tables[0];
            }
        }



		// 보통 1차,2차 평가를 할 경우 평가자는 해당 차수의 평가만 리스트에 나오는데
		// 만약 자신이 2차평가자인데 1차 평가가 정보를 보고 싶을 경우가 있다.
		// 설정에서 모든 차수 평가 보기가 설정되어 있다면 1,2차 평가 모두 볼 수게 된다.
		// 이와 같은 일을 위해서 아래와 같은 함수가 필요하다.
		if (estInfo.All_Step_Visible_YN.Equals("Y"))
			DT_EST_DATA = GetEstDataByAllStepVisible(DT_EST_DATA, est_emp_id_back_up);

		//---------------------- 추가 끝 ------------------------------


		// 작업ID에 따라서 UltraGrid에 바인되는 데이터의 정렬를 반영하기 위한 컬럼값을 반환한다.
		string sort_columns = BizUtility.GetSortColumns(EST_JOB_IDS);

		// 피평가자로 로그인 한 경우
		if (EST_TGT_TYPE.Equals("TGT") && DT_EST_DATA.Rows.Count > 0)
		{
			// 전체버튼을 클릭했을 경우
			if (isAll)
				DT_EST_DATA = DataTypeUtility.FilterSortDataTable(DT_EST_DATA, "", sort_columns);
			else
				DT_EST_DATA = DataTypeUtility.FilterSortDataTable(DT_EST_DATA, "DIRECTION_TYPE <> 'UP'", sort_columns);
		}
		else if ( DT_EST_DATA.Rows.Count > 0)
		{
			DT_EST_DATA = DataTypeUtility.FilterSortDataTable(DT_EST_DATA, "", sort_columns);
		}


		// 조회된 데이터가 존재할 경우
		if (DT_EST_DATA != null)
		{
			// 만약 가중치 보이기 Y 일때
			// 가중치 컬럼이 보이는 경우는 현재의 평가에서 하위의 평가가 존재하는데
			// 현재평가와 관련되어 있는 모든 하위평가를 정보를 가지고와서 DataTable를 동적으로
			// 만들어 준다. 데이터 Row가 많거나 하위평가가 많이 존재할 경우는 처리시간이 길 수있다.
			// 현업에서 충분한 설명이 필요하고 [하위평가 집계]버튼을 클릭시 데이터 반영 후에는
			// 모든 데이터가 DB에 집계되어 있어 이후에는 처리속도가 이전보다는 빠르게 처리된다.
			if (COL_WEIGHT_VISIBLE_YN.Equals("Y"))
			{
				DataTable _dtEstID = null;

				//if(DT_MENUAL_EST == null)

                //2011.12.28 박효동 : 하위평가를 가져오니 문제가 있어서 수정
                // - MBO의 하위평가를 가져오도록 평가컬럼설정이 되있는데 현재는 현재평가의 하위차수를 가져오니 안나오더라
                // - 해서 평가컬럼설정에 등록되어있는 POINT_평가아이디에 해당하는 평가아이디를 가져오도록 수정 휴~~
				// 하위평가 정보를 가지고 온다.
				//_dtEstID = estInfo.GetEstInfoByUpEstID(comp_id, est_id).Tables[0];

                _dtEstID = estInfo.GetEstInfoByUpEstID(comp_id, est_id).Tables[0];
                _dtEstID.Rows.Clear();
                Biz_ColumnInfos colInfo = new Biz_ColumnInfos();
                DataTable dtEstID = colInfo.GetColumnInfo(COMP_ID, EST_ID).Tables[0];
                foreach (DataRow dr in dtEstID.Rows)
                {
                    string colnames = dr[6].ToString();
                    if (colnames.Length > 5)
                    {
                        if (colnames.Substring(0, 6) == "POINT_" && colnames.Length == 8)
                        {
                            DataRow insertDR = _dtEstID.NewRow();
                            insertDR["EST_ID"] = colnames.Remove(0, 6);
                            _dtEstID.Rows.Add(insertDR);
                            insertDR = null;
                        }
                    }
                }

				//else
				//    _dtEstID  = DT_MENUAL_EST;

				// 하위평가의 하나씩 읽어가며 평가데이터 및 가중치컬럼을 추가한다.
				foreach (DataRow dataRow in _dtEstID.Rows)
				{
					DT_EST_DATA.Columns.Add(string.Format("WEIGHT_{0}", dataRow["EST_ID"]), typeof(double));    // 하위평가별 가중치 컬럼 추가

					// 평가별 점수 보이기 여부에 따라
					if (COL_POINT_VISIBLE_YN.Equals("Y"))
					{
						DT_EST_DATA.Columns.Add(string.Format("POINT_{0}", dataRow["EST_ID"]), typeof(double)); // 하위평가별 점수 컬럼 추가

						// 하위평가 평가결과정보를 가져온다.
						DataTable dtEstData = est_data.GetData(comp_id
																, dataRow["EST_ID"].ToString()
																, ESTTERM_REF_ID
																, ESTTERM_SUB_ID
																, 0
																, 0
																, 0
																, 0
																, 0
																, YEAR_YN
																, "Y"
																, OwnerTypeMode).Tables[0];

						//DataTable dtEstData = est_data.GetData(comp_id
						//                                    , dataRow["EST_ID"].ToString()
						//                                    , ESTTERM_REF_ID
						//                                    , ESTTERM_SUB_ID
						//                                    , ESTTERM_STEP_ID
						//                                    , 0
						//                                    , est_emp_id
						//                                    , tgt_dept_id
						//                                    , tgt_emp_id
						//                                    , YEAR_YN
						//                                    , MERGE_YN
						//                                    , OwnerTypeMode).Tables[0];


						// 보통 1차,2차 평가를 할 경우 평가자는 해당 차수의 평가만 리스트에 나오는데
						// 만약 자신이 2차평가자인데 1차 평가가 정보를 보고 싶을 경우가 있다.
						// 설정에서 모든 차수 평가 보기가 설정되어 있다면 1,2차 평가 모두 볼 수게 된다.
						// 이와 같은 일을 위해서 아래와 같은 함수가 필요하다.

						//==================================================================================

						//----------------- 추가 시작 -------------
						if (estInfo.All_Step_Visible_YN.Equals("Y"))
							dtEstData = GetEstDataByAllStepVisible(dtEstData, est_emp_id_back_up);
						//--------------- 추가 끝 ------------------

						foreach (DataRow drEstData in dtEstData.Rows) //// ESTTERM_STEP 를 제거함 //AND ESTTERM_STEP_ID = {2}
						{
							DataRow[] drArrEstData = DT_EST_DATA.Select(string.Format(@"ESTTERM_REF_ID  = {0}
                                                                                    AND ESTTERM_SUB_ID  = {1}
                                                                                    
                                                                                    AND TGT_DEPT_ID     = {3}
                                                                                    AND TGT_EMP_ID      = {4}"
																					, drEstData["ESTTERM_REF_ID"]
																					, drEstData["ESTTERM_SUB_ID"]
																					, drEstData["ESTTERM_STEP_ID"]
																					, drEstData["TGT_DEPT_ID"]
																					, drEstData["TGT_EMP_ID"]));

							if (drArrEstData.Length > 0)
							{
								drArrEstData[0][string.Format("POINT_{0}", dataRow["EST_ID"])] = drEstData["POINT"];
							}
						}

						//==================================================================================
					}
				}
			}

			// 등급 컬럼 보이기가 Y 일경우 (이건 DT_EST_DATA 과 관계 없음)
			if (COL_GRADE_VISIBLE_YN.Equals("Y")
				|| COL_GRADE_TO_POINT_VISIBLE_YN.Equals("Y"))
			{
				// 부서별 절대/상대평가 설정 DataTable 반환
				Biz_DeptEstDetails deptEstDetail = new Biz_DeptEstDetails();
				DT_DEPT_SCALE = deptEstDetail.GetDeptEstDetail(comp_id, estterm_ref_id, 0, est_id).Tables[0];

				// 직급체계별 절대/상대평가 설정 DataTable 반환
				Biz_DeptPosScales deptPosScale = new Biz_DeptPosScales();
				DT_POS_SCALE = deptPosScale.GetDeptPosScale(comp_id, estterm_ref_id, 0, est_id).Tables[0];

				// 평가별 절대/상대 점수를 등급으로 계산시 점수 범위 DataTable 반환
				Biz_Scopes scope = new Biz_Scopes();
				DT_SCOPE = scope.GetScope(comp_id, est_id).Tables[0];

				DT_EST_DATA.Columns.Add("RANK", typeof(double));            // 상대평가시 상위%를 계산하기 위해서 등수컬럼 추가
				DT_EST_DATA.Columns.Add("SCALE_ID", typeof(string));        // 절대/상대평가 ID 컬럼 추가
				DT_EST_DATA.Columns.Add("SCALE_NAME", typeof(string));      // 절대/상대평가 Name 컬럼 추가
				DT_EST_DATA.Columns.Add("GRADE_CALC_ID", typeof(string));   // 계산된 평가등급 ID 컬럼 추가
			}

			// 평가주기 집계 사용 여부 (현재 특별히 필요한 부분이 없다.)
			if (COL_ESTTERM_SUB_AGG_VISIBLE_YN.Equals("Y"))
			{

			}

			// 평가차수 집계 사용 여부 (현재 특별히 필요한 부분이 없다.)
			if (COL_ESTTERM_STEP_AGG_VISIBLE_YN.Equals("Y"))
			{

			}

			// 점수조정, 등급조정을 진행할 경우 아래와 같은 공통사항의 처리가 진행된다.
			if (COL_CTRL_POINT_VISIBLE_YN.Equals("Y")
				|| COL_CTRL_GRADE_VISIBLE_YN.Equals("Y"))
			{
				Biz_CtrlEstMaps ctrlEstDeptMap = new Biz_CtrlEstMaps();
				DT_CTRL_INFO = ctrlEstDeptMap.GetCtrlInfoByEstID(COMP_ID, EST_ID).Tables[0];
				DT_CTRL_EST_DEPT_MAP = ctrlEstDeptMap.GetCtrlEstDeptByEstID(COMP_ID, EST_ID).Tables[0];

				// ---------------- 추가 시작 ----------------
				Biz_ColumnInfos columnInfo = new Biz_ColumnInfos();
				// 평가ID의 컬럼 정보를 가져온다.
				DT_COLUMN_INFO = columnInfo.GetColumnInfo(COMP_ID, EST_ID).Tables[0];
				// ---------------- 추가 끝 ------------------

				// 만약 점수조정 컬럼을 사용할 경우
				if (COL_CTRL_POINT_VISIBLE_YN.Equals("Y"))
				{
					Biz_CtrlPointDatas ctrlPointData = new Biz_CtrlPointDatas();
					DT_CTRL_POINT_DATA = ctrlPointData.GetCtrlPointData(comp_id
																						, est_id
																						, estterm_ref_id
																						, estterm_sub_id
																						, estterm_step_id
																						, 0
																						, 0
																						, 0
																						, 0).Tables[0];
				}

				// 만약 등급조정 컬럼을 사용할 경우
				if (COL_CTRL_GRADE_VISIBLE_YN.Equals("Y"))
				{
					Biz_CtrlGradeDatas ctrlGradeData = new Biz_CtrlGradeDatas();
					DT_CTRL_GRADE_DATA = ctrlGradeData.GetCtrlGradeData(comp_id
																						, est_id
																						, estterm_ref_id
																						, estterm_sub_id
																						, estterm_step_id
																						, 0
																						, 0
																						, 0
																						, 0).Tables[0];
				}
			}

			//ClearGroupByBoxColumn();

			DataTable dtEmpComp = null;

			if (estInfo.Emp_Com_Dept_YN.Equals("N") && _is_search_emp == true)
			{
				return;
			}

			if (estInfo.Emp_Com_Dept_YN.Equals("Y") && _is_search_emp == true)
			{
				Biz_EmpComDeptDetails bizEmpCom = new Biz_EmpComDeptDetails();
				dtEmpComp = bizEmpCom.GetComDeptDetail(EMP_REF_ID, 0).Tables[0];
			}

			if (dtEmpComp != null)
			{
				DataTable dtClone = DT_EST_DATA.Clone();

				foreach (DataRow drEmpCom in dtEmpComp.Rows)
				{
					DataRow[] drCol = DT_EST_DATA.Select(string.Format("TGT_DEPT_ID = {0}", drEmpCom["DEPT_REF_ID"]));

					foreach (DataRow dr in drCol)
					{
						dtClone.ImportRow(dr);
					}
				}

				DT_EST_DATA = dtClone.Copy();
			}




			UltraWebGrid1.DataSource = DT_EST_DATA;

			try
			{
				UltraWebGrid1.DataBind();
                //점수 보여주기 여부
                if (!IVISIBLE_PAST_POINT_YN)
                    for (int i = 0; i < UltraWebGrid1.Columns.Count; i++)
                    {
                        //if (UltraWebGrid1.Columns[i].Header.Caption.Trim() == "점수")
                        if (UltraWebGrid1.Columns[i].Key == "POINT")
                        {
                            UltraWebGrid1.Columns[i].Hidden = true;
                        }
                    }
			}
			catch
			{

			}

			lblRowCount.Text = DT_EST_DATA.Rows.Count.ToString("#,##0");
		}
	}

	// 보통 1차,2차 평가를 할 경우 평가자는 해당 차수의 평가만 리스트에 나오는데
	// 만약 자신이 2차평가자인데 1차 평가가 정보를 보고 싶을 경우가 있다.
	// 설정에서 모든 차수 평가 보기가 설정되어 있다면 1,2차 평가 모두 볼 수게 된다.
	// 이와 같은 일을 위해서 아래와 같은 함수가 필요하다.
	private DataTable GetEstDataByAllStepVisible(DataTable dtData, int est_emp_id)
	{
		if (est_emp_id == 0)
			return dtData;

		DataTable dtTemp = dtData.Clone();
		DataTable dtSub = null;

		DataTable dtTgt = DataTypeUtility.GetGroupByDataTable(dtData, new string[] { "TGT_EMP_ID" });

		foreach (DataRow drTgt in dtTgt.Rows)
		{
			DataRow[] drCol = dtData.Select(string.Format("EST_EMP_ID = {0} AND TGT_EMP_ID = {1}", est_emp_id, drTgt["TGT_EMP_ID"]));

			if (drCol.Length == 0)
				continue;

			int step_order = DataTypeUtility.GetToInt32(drCol[0]["STEP_ORDER"]);

			dtSub = DataTypeUtility.FilterSortDataTable(dtData, string.Format("TGT_EMP_ID = {0} AND STEP_ORDER <= {1}", drTgt["TGT_EMP_ID"], step_order));

			dtTemp.Merge(dtSub);
		}

		return dtTemp;
	}

	/// <summary>
	/// 쿼리스트링으로 받은 EST_JOB_ID로 COL_ 관련 필드의 값을 넣어 주는 메소드
	/// </summary>
	/// <param name="est_job_ids"></param>
	private void SetColColumnsByEstJobID(string est_job_ids)
	{
		// 작업ID에 따라서 EST_JOB_ID 테이블의 VAR_MAP_KEY 컬럼의 값이 존재하는 것에 따라
		// 사용여부의 값을 반환하는데 이러한 변수(COL_XXX_XXX_YN)를 사용하는 이유는
		// 동적으로 컬럼을 만들 때 필요하지 않은 경우 성능을 위해서 프로그램 처리를 안하기 위해서 이다.

		//public string COL_WEIGHT_VISIBLE_YN             = "N";
		//public string COL_POINT_VISIBLE_YN              = "N";
		//public string COL_BIAS_POINT_VISIBLE_YN         = "N";
		//public string COL_GRADE_VISIBLE_YN              = "N";
		//public string COL_GRADE_TO_POINT_VISIBLE_YN     = "N";
		//public string COL_ESTTERM_SUB_AGG_VISIBLE_YN    = "N";
		//public string COL_ESTTERM_STEP_AGG_VISIBLE_YN   = "N";
		//public string COL_CTRL_POINT_VISIBLE_YN         = "N";
		//public string COL_CTRL_GRADE_VISIBLE_YN         = "N";
		//public string COL_DEPT_TO_EMP_DATA              = "N";
		//public string COL_GET_OUTER_DATA                = "N";
		//public string COL_LINK_EST_DATA                 = "N";

		if (est_job_ids.Equals(""))
		{
			return;
		}

        Biz_JobInfos jobInfo = null;

		foreach (string est_job_id in est_job_ids.Split(','))
		{
			jobInfo = new Biz_JobInfos(est_job_id);

            if (jobInfo.Var_Map_Key != null)
            {
                //jobInfo = new Biz_JobInfos(est_job_id);

                // 선택컬럼 보이기 여부
                if (COL_CHECK_VISIBLE_YN.Equals("N"))
                    COL_CHECK_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_CHECK_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 가중치 컬럼 보이기 여부
                if (COL_WEIGHT_VISIBLE_YN.Equals("N"))
                    COL_WEIGHT_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_WEIGHT_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 점수 컬럼 보이기 여부
                if (COL_POINT_VISIBLE_YN.Equals("N"))
                    COL_POINT_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_POINT_VISIBLE_YN") >= 0) ? "Y" : "N";

                // Bias 컬럼 보이기 여부(원시점수, 평균조정, 표준편차)
                if (COL_BIAS_POINT_VISIBLE_YN.Equals("N"))
                    COL_BIAS_POINT_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_BIAS_POINT_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 등급 컬럼 보이기 여부
                if (COL_GRADE_VISIBLE_YN.Equals("N"))
                    COL_GRADE_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_GRADE_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 등급을 점수로 환산 컬럼 보이기 여부
                if (COL_GRADE_TO_POINT_VISIBLE_YN.Equals("N"))
                    COL_GRADE_TO_POINT_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_GRADE_TO_POINT_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 주기 집계 컬럼 보이기 여부(상반기,하반기 -> 년간)
                if (COL_ESTTERM_SUB_AGG_VISIBLE_YN.Equals("N"))
                    COL_ESTTERM_SUB_AGG_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_ESTTERM_SUB_AGG_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 차수 집계 컬럼 보이기 여부(1차,2차 -> 집계)
                if (COL_ESTTERM_STEP_AGG_VISIBLE_YN.Equals("N"))
                    COL_ESTTERM_STEP_AGG_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_ESTTERM_STEP_AGG_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 조정 점수 컬럼 보이기 여부
                if (COL_CTRL_POINT_VISIBLE_YN.Equals("N"))
                    COL_CTRL_POINT_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_CTRL_POINT_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 조정 등급 컬럼 보이기 여부
                if (COL_CTRL_GRADE_VISIBLE_YN.Equals("N"))
                    COL_CTRL_GRADE_VISIBLE_YN = (jobInfo.Var_Map_Key.IndexOf("COL_CTRL_GRADE_VISIBLE_YN") >= 0) ? "Y" : "N";

                // 부서 점수를 사원 점수로 반영 컬럼 보이기 여부
                if (COL_DEPT_TO_EMP_DATA.Equals("N"))
                    COL_DEPT_TO_EMP_DATA = (jobInfo.Var_Map_Key.IndexOf("COL_DEPT_TO_EMP_DATA") >= 0) ? "Y" : "N";

                // 외부 데이터 처리 컬럼 보이기 여부
                if (COL_GET_OUTER_DATA.Equals("N"))
                    COL_GET_OUTER_DATA = (jobInfo.Var_Map_Key.IndexOf("COL_GET_OUTER_DATA") >= 0) ? "Y" : "N";

                // 링크된 평가 컬럼 보이기 여부
                if (COL_LINK_EST_DATA.Equals("N"))
                    COL_LINK_EST_DATA = (jobInfo.Var_Map_Key.IndexOf("COL_LINK_EST_DATA") >= 0) ? "Y" : "N";
            }
		}
	}

	/// <summary>
	/// EST_JOB_ID의 확정 상태
	/// </summary>
	/// <param name="est_job_ids"></param>
	private void SetConfirmStatusHtml(string est_job_ids)
	{
		// 작업ID에 따른 상태진행 아이콘 Html 코드 반환
		ltrConfirmStatus.Text = EstJobUtility.GetStatusHtml(COMP_ID
															, EST_ID
															, ESTTERM_REF_ID
															, ESTTERM_SUB_ID
															, ESTTERM_STEP_ID
															, est_job_ids.Split(','));
	}

	private void ClearGroupByBoxColumn()
	{
		UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;
		UltraWebGrid1.Clear();
		UltraWebGrid1.DisplayLayout.ViewType = ViewType.OutlookGroupBy;
	}

	// UltraGrid의 GroupByColumn에 특정 컬럼으로 Group 되어 있으면 하단의 작업 버튼 처리시 오류가 발생되어
	// 그런 사항이 있는지 체크하고 만약 존재한다면 아래와 같은 메세지를 출력한다.
	private bool HasGroupByColumns()
	{
		bool isColumns = false;
		string temp = "";

		for (int i = 0; i < UltraWebGrid1.Columns.Count; i++)
		{
			if (UltraWebGrid1.Columns[i].IsGroupByColumn)
			{
				temp += string.Format("[{0}] ", UltraWebGrid1.Columns[i].Header.Caption);

				if (!isColumns)
					isColumns = true;
			}
		}

		if (isColumns)
			ltrScript.Text = JSHelper.GetAlertScript(string.Format("현재의 작업을 진행하시기 전에 GroupByBox에서 존재하는 {0}컬럼을 모두 제거하세요.", temp));

		return isColumns;
	}

    //MBO조회
    private void DoBindingMbo()
    {
        if (!IsPostBack)
        {
            DropDownListCommom.BindEstTermSub(ddlEstTermSubID, COMP_ID, EST_ID, YEAR_YN);   // 평가주기 DropDownList 바인딩 
            DropDownListCommom.BindEstTermStep(ddlEstTermStepID, COMP_ID, EST_ID);          // 평가차수 DropDownList 바인딩
            ddlEstTermStepID.Items.Insert(0, new ListItem("::전체::", "0"));
            ddlEstTermStepID.SelectedIndex = 0;
        }
        
        ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

        // 처음 실행될때 (추가)
        if (ESTTERM_SUB_ID.Equals(0))    // 값 존재 여부
        {
            ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);     // DropDownList의 값을 반환
        }
        else
        {
            WebUtility.FindByValueDropDownList(ddlEstTermSubID, ESTTERM_SUB_ID);        // DropDwonList의 값을 선택함
            ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);     // DropDownList의 값을 반환
        }

        // 만약 주기가 년간일 경우
        if (YEAR_YN.Equals("Y"))
        {
            ESTTERM_SUB_ID = BizUtility.GetEstTermSubIDByYearYN(COMP_ID);               // 년간인 경우 (년간의 주기ID의 값을 반환)
        }

        // 만약 차수가 합산일 경우
        if (MERGE_YN.Equals("Y"))
        {
            ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);            // 차수집계인 경우 (차추집계의 차수ID의 값을 반환)
        }
        else
        {
            // 만약 모든 차수를 보여 줘야하는 경우
            // ESTTERM_STEP_ALL_USE_YN 은 쿼리스트링으로 값을 받는데 이 값의 여부에 따라 차수DropDownList의 컨트롤의
            // 보이기 여부를 처리한다.
            if (ESTTERM_STEP_ALL_USE_YN.Equals("Y"))
            {
                ESTTERM_STEP_ID = 0;
                ddlEstTermStepID.Visible = false;
            }
        }

        WebUtility.FindByValueDropDownList(ddlEstTermRefID, ESTTERM_REF_ID);

        if (ddlEstTermSubID.Visible)
            WebUtility.FindByValueDropDownList(ddlEstTermSubID, ESTTERM_SUB_ID);

        //if (ddlEstTermStepID.Visible)
        //    WebUtility.FindByValueDropDownList(ddlEstTermStepID, ESTTERM_SUB_ID);

        // 상태 html
        HtmlScriptCommon.CreateStatusHtmlTable(tblViewStatus, EST_ID);

        Biz_Datas biz = new Biz_Datas();
        DataSet ds = biz.Get3GADataEstData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, DataTypeUtility.GetToInt32(ddlTgtDept.SelectedValue));
        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource = ds.Tables[0];
        UltraWebGrid1.DataBind();

        if (ds.Tables[1].Rows.Count > 0)
            this.IEST_STATUS = ds.Tables[1].Rows[0]["STATUS_YN"].ToString();

        if (ds.Tables[2].Rows.Count > 0)
            this.IEST_COMPLETE = "N";
        else
            this.IEST_COMPLETE = "Y";

        //점수 보여주기 여부
        if (!IVISIBLE_PAST_POINT_YN)
            for (int i = 0; i < UltraWebGrid1.Columns.Count; i++)
            {
                if (UltraWebGrid1.Columns[i].Header.Caption.Trim() == "점수")
                {
                    UltraWebGrid1.Columns[i].Hidden = true;
                }
            }

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString("#,##0");
    }
	#endregion



}
