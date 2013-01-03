using ASP;
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
using Infragistics.WebUI.UltraWebGrid;

using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;
 
using MicroBSC.Estimation.Biz;

// 제    목 : 리포트에서 사용하는 Custom Grid 
// 내    용 : 리포트 장표 안에서 반복적으로 사용하는 그리드를 사용하기 위해서 만들었음
public partial class EST_USER_CTRL_EST_GRID : EstUserControlBase
{
    #region ----------------------- 필드 ------------------------------------

    private string FROM_EST_ID;
    private string EST_ID;
    private int ESTTERM_SUB_ID;
    private int ESTTERM_STEP_ID;
    private int EST_DEPT_ID;
    private int EST_EMP_ID;
    private int TGT_DEPT_ID;
    private int TGT_EMP_ID;
    private string EST_TGT_TYPE;
    private string YEAR_YN;
    private string MERGE_YN;
    private string DEPT_COLUMN_NO_USE_YN;
    private string ESTTERM_SUB_ALL_USE_YN;
    private string ESTTERM_STEP_ALL_USE_YN;
    private string RPT_DTL_ID;
    private int GRID_HEIGHT;
    private int EMP_REF_ID;

    private int DEFAULT_INDEX_COUNT          = 1;

    private DataTable DT_COLUMN_INFO        = null;
    private DataTable DT_CTRL_INFO          = null;
    private DataTable DT_CTRL_EST_DEPT_MAP  = null;
    private DataTable DT_CTRL_POINT_DATA    = null;
    private DataTable DT_CTRL_GRADE_DATA    = null;
    private DataTable DT_EST_DATA           = null;
    private DataTable DT_DEPT_SCALE         = null;
    private DataTable DT_POS_SCALE          = null;

    #endregion

    #region ----------------------- 속성 ------------------------------------

    public int Comp_ID 
    {
        set 
        {
            COMP_ID = value;
        }
    }

    public string From_Est_ID
    {
        set 
        {
            FROM_EST_ID = value;
        }
    }

    public string Est_ID
    {
        set 
        {
            EST_ID = value;
        }
    }

    public int EstTerm_Ref_ID 
    {
        set 
        {
            ESTTERM_REF_ID = value;
        }
    }

    public int EstTerm_Sub_ID 
    {
        set 
        {
            ESTTERM_SUB_ID = value;
        }
    }

    public int EstTerm_Step_ID 
    {
        set 
        {
            ESTTERM_STEP_ID = value;
        }
    }

    public string Est_Job_IDs
    {
        set 
        {
            EST_JOB_IDS = value;
        }
    }

    public string Est_Tgt_Type
    {
        set 
        {
            EST_TGT_TYPE = value;
        }
    }

    public string Year_YN
    {
        set 
        {
            YEAR_YN = value;
        }
    }

    public string Merge_YN
    {
        set 
        {
            MERGE_YN = value;
        }
    }

    public string Dept_Column_No_Use_Yn
    {
        set 
        {
            DEPT_COLUMN_NO_USE_YN = value;
        }
    }

    public string EstTerm_Sub_All_Use_YN
    {
        set 
        {
            ESTTERM_SUB_ALL_USE_YN = value;
        }
    }

    public string EstTerm_Step_All_Use_YN
    {
        set 
        {
            ESTTERM_STEP_ALL_USE_YN = value;
        }
    }

    public int Est_Dept_ID 
    {
        set 
        {
            EST_DEPT_ID = value;
        }
    }

    public int Est_Emp_ID 
    {
        set 
        {
            EST_EMP_ID = value;
        }
    }

    public int Tgt_Dept_ID 
    {
        set 
        {
            TGT_DEPT_ID = value;
        }
    }

    public int Tgt_Emp_ID 
    {
        set 
        {
            TGT_EMP_ID = value;
        }
    }

    public string Title_Name
    {
        set 
        {
            lblTitle.Text = value;
        }
    }

    public string Title_Img_Url
    {
        set 
        {
            imgTitle.ImageUrl = value;
        }
    }

    public string Rpt_Dtl_ID
    {
        set 
        {
            RPT_DTL_ID = value;
        }
    }

    public int Grid_Height
    {
        set 
        {
            GRID_HEIGHT = value;
        }
    }

    public int Emp_Ref_ID
    {
        set 
        {
            EMP_REF_ID = value;
        }
    }

    #endregion

    #region ------------------- Page -----------------------------------------

    protected void Page_PreInit(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack) 
        {
            SetColColumnsByEstJobID(EST_JOB_IDS);

            ltrJScript.Text = GetJScript(RPT_DTL_ID, EST_TGT_TYPE, COL_ESTTERM_STEP_AGG_VISIBLE_YN, COMP_ID);

            UltraWebGrid1.Height = GRID_HEIGHT;

            GridBidingData(   COMP_ID
                            , EST_ID
                            , ESTTERM_REF_ID
                            , ESTTERM_SUB_ID
                            , ESTTERM_STEP_ID);
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    #endregion

    #region ----------------------- 그리드 ------------------------------------

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.CreateColumns(   (UltraWebGrid)sender
                                        , COMP_ID
                                        , EST_ID
                                        , DEFAULT_INDEX_COUNT
                                        , out DT_COLUMN_INFO
                                        , (OwnerTypeMode == OwnerType.Dept) ? "D" : "P"
                                        , EST_JOB_IDS.Split(',')
                                        , DEPT_COLUMN_NO_USE_YN);

        if(e.Layout.Bands[0].Columns.Exists("selchk"))
            if(!e.Layout.Bands[0].Columns.FromKey("selchk").Hidden)
                e.Layout.Bands[0].Columns.FromKey("selchk").Hidden = true;

        // 가중치 컬럼을 사용할 경우
        if(    COL_WEIGHT_VISIBLE_YN.Equals("Y")
            || COL_GRADE_VISIBLE_YN.Equals("Y")) 
        {
            Biz_DeptEstDetails deptEstDetail = null;
            Biz_DeptPosDetails deptPosDetail = null;
            DataTable dtDeptDetail           = null;

            DataRow[] drArrColumn            = DT_COLUMN_INFO.Select( @"COL_STYLE_ID = 'BIZ' 
                                                                    AND VISIBLE_YN   = 'Y'");

            foreach(DataRow drColumn in drArrColumn) 
            {
                if(drColumn["COL_KEY"].ToString().IndexOf("WEIGHT_") < 0)
                    continue;

                string est_id = drColumn["COL_KEY"].ToString().Replace("WEIGHT_", "");

                Biz_EstInfos estSubInfo = new Biz_EstInfos(COMP_ID, est_id);

                if (estSubInfo.Weight_Type != null && estSubInfo.Weight_Type.Equals("DPT")) 
                {
                    deptEstDetail           = new Biz_DeptEstDetails();
                    dtDeptDetail            = deptEstDetail.GetDeptEstDetail(COMP_ID, ESTTERM_REF_ID, 0, est_id).Tables[0];
                }
                else if (estSubInfo.Weight_Type != null && estSubInfo.Weight_Type.Equals("POS")) 
                {
                    deptPosDetail           = new Biz_DeptPosDetails();
                    dtDeptDetail            = deptPosDetail.GetDeptPosDetail(COMP_ID, ESTTERM_REF_ID, 0, est_id).Tables[0];
                }

                if(DT_DEPT_EST_POS_DETAIL == null)
                    DT_DEPT_EST_POS_DETAIL = dtDeptDetail;
                else 
                    DT_DEPT_EST_POS_DETAIL.Merge(dtDeptDetail);
            }
        }

        e.Layout.ClientSideEvents.MouseOverHandler  = RPT_DTL_ID + e.Layout.ClientSideEvents.MouseOverHandler;
        e.Layout.ClientSideEvents.DblClickHandler   = RPT_DTL_ID + e.Layout.ClientSideEvents.DblClickHandler;
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        BizUtility.SetStatusImage(drw, e.Row.Cells);

        // 가중치관련 컬럼 보이기가 Y 인경우
        if(COL_WEIGHT_VISIBLE_YN.Equals("Y")) 
        {
            BizUtility.SetWeightByDptPos( DT_COLUMN_INFO.Select(@"COL_STYLE_ID            = 'BIZ' 
                                                              AND VISIBLE_YN              = 'Y'")
                                        , COMP_ID
                                        , DT_DEPT_EST_POS_DETAIL
                                        , drw
                                        , e.Row.Cells);
        }

        // 평가별 점수 보여주기 사용 여부
        if(COL_POINT_VISIBLE_YN.Equals("Y"))
        {
            
        }

        // Bias 점수 조정 사용 여부
        if(COL_BIAS_POINT_VISIBLE_YN.Equals("Y")) 
        {
            
        }

        // 등급 보이기 여부
        if(COL_GRADE_VISIBLE_YN.Equals("Y")) 
        {
            // 부서별 평가방법일 경우
            if(ScaleTypeMode.Equals("DPT")) 
            {
                DataRow[] drArr = DT_DEPT_SCALE.Select(string.Format("DEPT_REF_ID = {0}", drw["TGT_DEPT_ID"]));

                if(drArr.Length > 0) 
                {
                    if(drArr[0]["SCALE_ID"].ToString().Equals("ABS")) 
                    {
                        BizUtility.SetGradeByScale_ABS(DT_SCOPE
                                                    , drw
                                                    , e.Row.Cells);
                    }
                    else if(drArr[0]["SCALE_ID"].ToString().Equals("REL")) 
                    {
                        BizUtility.SetGradeByScale_REL(DT_SCOPE
                                                    , DT_EST_DATA
                                                    , drw
                                                    , e.Row.Cells);
                    }
                }
            } // 직급,직책별 평가방법일 경우
            else if(ScaleTypeMode.Equals("POS")) 
            {
                string scale_id = "ABS";

                //해당 부서 중 직책, 직급을 선별
                DataRow[] dtArrPosScale = DT_POS_SCALE.Select(string.Format("EST_ID = '{0}' AND DEPT_REF_ID = {1}", EST_ID, drw["TGT_DEPT_ID"]), "SEQ");

                //선별된 직책, 직급의 순서에 따라
                foreach(DataRow drChildPosScale in dtArrPosScale) 
                {
                    // 기본값이면
                    if(drChildPosScale["POS_VALUE"].ToString().Equals("-"))
                    {
                        scale_id = DataTypeUtility.GetValue(drChildPosScale["SCALE_ID"]);
                        break;
                    }
                    else // 선별된 직급
                    {
                        if(drw[string.Format("TGT_POS_{0}_ID", drChildPosScale["POS_ID"])].ToString().Equals(drChildPosScale["POS_VALUE"].ToString())) 
                        {
                            scale_id = DataTypeUtility.GetValue(drChildPosScale["SCALE_ID"]);
                            break;
                        }
                    }
                }

                if(scale_id.Equals("ABS")) 
                {
                    BizUtility.SetGradeByScale_ABS(DT_SCOPE
                                                , drw
                                                , e.Row.Cells);
                }
                else if(scale_id.Equals("REL")) 
                {
                    BizUtility.SetGradeByScale_REL(DT_SCOPE
                                                , DT_EST_DATA
                                                , drw
                                                , e.Row.Cells);
                }
            }
        }

        // 등급을 점수로 환산 사용 여부
        if(COL_GRADE_TO_POINT_VISIBLE_YN.Equals("Y")) 
        {
            BizUtility.SetGradeToPoint(   DT_SCOPE
                                        , drw
                                        , e.Row.Cells);
        }

        // 주기별 집계 사용 여부
        if(COL_ESTTERM_SUB_AGG_VISIBLE_YN.Equals("Y")) 
        {
            
        }

        // 차수별 집계 사용 여부
        if(COL_ESTTERM_STEP_AGG_VISIBLE_YN.Equals("Y")) 
        {
            
        }

        // 점수 조정 사용 여부
        if(COL_CTRL_POINT_VISIBLE_YN.Equals("Y"))
        {
            BizUtility.SetCtrlPoint(  drw
                                    , e.Row.Cells
                                    , DT_COLUMN_INFO
                                    , DT_CTRL_INFO
                                    , DT_CTRL_EST_DEPT_MAP
                                    , DT_CTRL_POINT_DATA
                                    , EMP_REF_ID);
        }

        // 등급 조정 사용 여부
        if(COL_CTRL_GRADE_VISIBLE_YN.Equals("Y"))
        {
            BizUtility.SetCtrlGrade(  drw
                                    , e.Row.Cells
                                    , DT_COLUMN_INFO
                                    , DT_CTRL_INFO
                                    , DT_CTRL_EST_DEPT_MAP
                                    , DT_CTRL_GRADE_DATA
                                    , EMP_REF_ID);    
        }
    }

    #endregion 

    #region ----------------------- 메서드 ------------------------------------

    /// <summary>
    /// 그리드 바인딩 메소드
    /// </summary>
    /// <param name="comp_id"></param>
    /// <param name="est_id"></param>
    /// <param name="estterm_ref_id"></param>
    /// <param name="estterm_sub_id"></param>
    /// <param name="estterm_step_id"></param>
    private void GridBidingData(  int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id) 
    {
        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        if(!estInfo.IsExists(comp_id, est_id)) 
        {
            return;
        }

        // 만약 주기가 년간일 경우
        if(YEAR_YN.Equals("Y")) 
        {
            ESTTERM_SUB_ID = BizUtility.GetEstTermSubIDByYearYN(COMP_ID);
        }

        // 만약 차수가 합산일 경우
        if(MERGE_YN.Equals("Y")) 
        {
            ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
        }

        if (estInfo.Owner_Type != null && estInfo.Owner_Type.Equals("D"))
            OwnerTypeMode = OwnerType.Dept;
        else
            OwnerTypeMode = OwnerType.Emp_User;
        //if (estInfo.Owner_Type.Equals("D"))
        //    OwnerTypeMode = OwnerType.Dept;
        //else
        //    OwnerTypeMode = OwnerType.Emp_User;

        ScaleTypeMode   = estInfo.Scale_Type;
        WeightTypeMode  = estInfo.Weight_Type;

        if(estInfo.Bias_YN.Equals("Y"))
            BiasYN          = YesNo.Yes;
        else
            BiasYN          = YesNo.No;

        if(estInfo.Grade_Confirm_YN.Equals("Y"))
            GradeConfirmYN = YesNo.Yes;
        else
            GradeConfirmYN = YesNo.No;

        Biz_Datas est_data   = new Biz_Datas();

        int est_emp_id      = 0;;
        int tgt_dept_id     = 0;
        int tgt_emp_id      = 0;

        if(OwnerTypeMode == OwnerType.Dept && DEPT_COLUMN_NO_USE_YN.Equals("Y")) 
        {
            OwnerTypeMode = OwnerType.Emp_User;
        }
        else if(OwnerTypeMode == OwnerType.Emp_User && DEPT_COLUMN_NO_USE_YN.Equals("Y")) 
        {
            OwnerTypeMode = OwnerType.Dept;
        }

        if(OwnerTypeMode == OwnerType.Dept) 
        {
            if(EST_TGT_TYPE.Equals("EST"))
            {
                est_emp_id  = 0;
                tgt_dept_id = TGT_DEPT_ID;
                tgt_emp_id  = -1;
            }
            else if(EST_TGT_TYPE.Equals("TGT"))
            {
                est_emp_id  = 0;
                tgt_dept_id = TGT_DEPT_ID;
                tgt_emp_id  = -1;
            }
        }
        else if(OwnerTypeMode == OwnerType.Emp_User) 
        {
            if(EST_TGT_TYPE.Equals("EST"))
            {
                est_emp_id  = 0;
                tgt_dept_id = 0;
                tgt_emp_id  = TGT_EMP_ID;
            }
            else if(EST_TGT_TYPE.Equals("TGT"))
            {
                est_emp_id  = 0;
                tgt_dept_id = 0;
                tgt_emp_id  = TGT_EMP_ID;
            }
        }

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

        // 조회된 데이터가 존재할 경우
        if(DT_EST_DATA != null) 
        {
            // 만약 가중치 보이기 Y 일때
            if(COL_WEIGHT_VISIBLE_YN.Equals("Y")) 
            {
                //2012.01.16 박효동 : 하위평가를 가져오니 문제가 있어서 수정
                // - MBO의 하위평가를 가져오도록 평가컬럼설정이 되있는데 현재는 현재평가의 하위차수를 가져오니 안나오더라
                // - 해서 평가컬럼설정에 등록되어있는 POINT_평가아이디에 해당하는 평가아이디를 가져오도록 수정 휴~~
                // 하위평가 정보를 가지고 온다.
                //DataTable _dtEstID  = estInfo.GetEstInfoByUpEstID(comp_id, est_id).Tables[0];

                DataTable _dtEstID = estInfo.GetEstInfoByUpEstID(comp_id, est_id).Tables[0];
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

                foreach(DataRow dataRow in _dtEstID.Rows) 
                {
                    DT_EST_DATA.Columns.Add(string.Format("WEIGHT_{0}", dataRow["EST_ID"]), typeof(double));

                    // 평가별 점수 보이기 여부에 따라
                    if(COL_POINT_VISIBLE_YN.Equals("Y")) 
                    {
                        DT_EST_DATA.Columns.Add(string.Format("POINT_{0}", dataRow["EST_ID"]), typeof(double));

                        DataTable dtEstData = est_data.GetData(comp_id
                                                            , dataRow["EST_ID"].ToString()
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

                        foreach(DataRow drEstData in dtEstData.Rows) 
                        {
                            DataRow[] drArrEstData = DT_EST_DATA.Select(string.Format(@"ESTTERM_REF_ID  = {0}
                                                                                    AND ESTTERM_SUB_ID  = {1}
                                                                                    AND ESTTERM_STEP_ID = {2}
                                                                                    AND TGT_DEPT_ID     = {3}
                                                                                    AND TGT_EMP_ID      = {4}"
                                                                                    , drEstData["ESTTERM_REF_ID"]
                                                                                    , drEstData["ESTTERM_SUB_ID"]
                                                                                    , drEstData["ESTTERM_STEP_ID"]
                                                                                    , drEstData["TGT_DEPT_ID"]
                                                                                    , drEstData["TGT_EMP_ID"]));

                            if(drArrEstData.Length > 0) 
                            {
                                drArrEstData[0][string.Format("POINT_{0}", dataRow["EST_ID"])] = drEstData["POINT"];
                            }
                        }
                    }
                }
            }

            // 등급 컬럼 보이기가 Y 일경우 (이건 DT_EST_DATA 과 관계 없음)
            if(    COL_GRADE_VISIBLE_YN.Equals("Y") 
                || COL_GRADE_TO_POINT_VISIBLE_YN.Equals("Y")) 
            {
                Biz_DeptEstDetails deptEstDetail = new Biz_DeptEstDetails();
                DT_DEPT_SCALE                    = deptEstDetail.GetDeptEstDetail(comp_id, estterm_ref_id, 0, est_id).Tables[0];

                Biz_DeptPosScales deptPosScale   = new Biz_DeptPosScales();
                DT_POS_SCALE                     = deptPosScale.GetDeptPosScale(comp_id, estterm_ref_id, 0, est_id).Tables[0];

                Biz_Scopes scope                 = new Biz_Scopes();
                DT_SCOPE                         = scope.GetScope(comp_id, est_id).Tables[0];

                DT_EST_DATA.Columns.Add("RANK", typeof(double));
                DT_EST_DATA.Columns.Add("SCALE_ID", typeof(string));
                DT_EST_DATA.Columns.Add("SCALE_NAME", typeof(string));
                DT_EST_DATA.Columns.Add("GRADE_CALC_ID", typeof(string));
            }

            if(COL_ESTTERM_SUB_AGG_VISIBLE_YN.Equals("Y")) 
            {
                
            }

            if(COL_ESTTERM_STEP_AGG_VISIBLE_YN.Equals("Y")) 
            {
                
            }

            if(    COL_CTRL_POINT_VISIBLE_YN.Equals("Y")
                || COL_CTRL_GRADE_VISIBLE_YN.Equals("Y")) 
            {
                Biz_CtrlEstMaps ctrlEstDeptMap  = new Biz_CtrlEstMaps();
                DT_CTRL_INFO                    = ctrlEstDeptMap.GetCtrlInfoByEstID(COMP_ID, EST_ID).Tables[0];
                DT_CTRL_EST_DEPT_MAP            = ctrlEstDeptMap.GetCtrlEstDeptByEstID(COMP_ID, EST_ID).Tables[0];

                if(COL_CTRL_POINT_VISIBLE_YN.Equals("Y")) 
                {
                    Biz_CtrlPointDatas ctrlPointData    = new Biz_CtrlPointDatas();
                    DT_CTRL_POINT_DATA                  = ctrlPointData.GetCtrlPointData( comp_id
                                                                                        , est_id
                                                                                        , estterm_ref_id
                                                                                        , estterm_sub_id
                                                                                        , estterm_step_id
                                                                                        , 0
                                                                                        , 0
                                                                                        , 0
                                                                                        , 0).Tables[0];
                }

                if(COL_CTRL_GRADE_VISIBLE_YN.Equals("Y")) 
                {
                    Biz_CtrlGradeDatas ctrlGradeData    = new Biz_CtrlGradeDatas();
                    DT_CTRL_GRADE_DATA                  = ctrlGradeData.GetCtrlGradeData( comp_id
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

            UltraWebGrid1.Clear();
            UltraWebGrid1.DataSource = DT_EST_DATA;
            UltraWebGrid1.DataBind();
        }
    }

    /// <summary>
    /// 쿼리스트링으로 받은 EST_JOB_ID로 COL_ 관련 필드의 값을 넣어 주는 메소드
    /// </summary>
    /// <param name="est_job_ids"></param>
    private void SetColColumnsByEstJobID(string est_job_ids) 
    {
        if(est_job_ids.Equals(""))
        {
            return;
        }

        Biz_JobInfos jobInfo = null;

        foreach(string est_job_id in est_job_ids.Split(',')) 
        {
            jobInfo = new Biz_JobInfos(est_job_id);

            if(COL_WEIGHT_VISIBLE_YN.Equals("N"))
                COL_WEIGHT_VISIBLE_YN                       = (jobInfo.Var_Map_Key.IndexOf("COL_WEIGHT_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_POINT_VISIBLE_YN.Equals("N"))
                COL_POINT_VISIBLE_YN                        = (jobInfo.Var_Map_Key.IndexOf("COL_POINT_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_BIAS_POINT_VISIBLE_YN.Equals("N"))
                COL_BIAS_POINT_VISIBLE_YN                   = (jobInfo.Var_Map_Key.IndexOf("COL_BIAS_POINT_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_GRADE_VISIBLE_YN.Equals("N"))
                COL_GRADE_VISIBLE_YN                        = (jobInfo.Var_Map_Key.IndexOf("COL_GRADE_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_GRADE_TO_POINT_VISIBLE_YN.Equals("N"))
                COL_GRADE_TO_POINT_VISIBLE_YN               = (jobInfo.Var_Map_Key.IndexOf("COL_GRADE_TO_POINT_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_ESTTERM_SUB_AGG_VISIBLE_YN.Equals("N"))
                COL_ESTTERM_SUB_AGG_VISIBLE_YN              = (jobInfo.Var_Map_Key.IndexOf("COL_ESTTERM_SUB_AGG_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_ESTTERM_STEP_AGG_VISIBLE_YN.Equals("N"))
                COL_ESTTERM_STEP_AGG_VISIBLE_YN             = (jobInfo.Var_Map_Key.IndexOf("COL_ESTTERM_STEP_AGG_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_CTRL_POINT_VISIBLE_YN.Equals("N"))
                COL_CTRL_POINT_VISIBLE_YN                   = (jobInfo.Var_Map_Key.IndexOf("COL_CTRL_POINT_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_CTRL_GRADE_VISIBLE_YN.Equals("N"))
                COL_CTRL_GRADE_VISIBLE_YN                   = (jobInfo.Var_Map_Key.IndexOf("COL_CTRL_GRADE_VISIBLE_YN") >= 0) ? "Y":"N";

            if(COL_DEPT_TO_EMP_DATA.Equals("N"))
                COL_DEPT_TO_EMP_DATA                        = (jobInfo.Var_Map_Key.IndexOf("COL_DEPT_TO_EMP_DATA") >= 0) ? "Y":"N";

            if(COL_GET_OUTER_DATA.Equals("N"))
                COL_GET_OUTER_DATA                          = (jobInfo.Var_Map_Key.IndexOf("COL_GET_OUTER_DATA") >= 0) ? "Y":"N";

            if(COL_LINK_EST_DATA.Equals("N"))
                COL_LINK_EST_DATA                           = (jobInfo.Var_Map_Key.IndexOf("COL_LINK_EST_DATA") >= 0) ? "Y":"N";
        }

        
    }

    private string GetJScript(string rpt_dtl_id
                            , string est_tgt_type
                            , string col_estterm_step_agg_visible_yn
                            , int comp_id) 
    {
        string query = 
@"<script id='Infragistics' type='text/javascript'>

    function " + rpt_dtl_id + @"DblClickHandler(gridName, id) 
    {
        var cell             = igtbl_getElementById(id);
        var row              = igtbl_getRowById(id);
        
        var est_id           = row.getCellFromKey('EST_ID').getValue();
        var estterm_ref_id   = row.getCellFromKey('ESTTERM_REF_ID').getValue();
        var estterm_sub_id   = row.getCellFromKey('ESTTERM_SUB_ID').getValue();
        var estterm_step_id  = row.getCellFromKey('ESTTERM_STEP_ID').getValue();
        var est_dept_id      = row.getCellFromKey('EST_DEPT_ID').getValue();
        var est_emp_id       = row.getCellFromKey('EST_EMP_ID').getValue();
        var tgt_dept_id      = row.getCellFromKey('TGT_DEPT_ID').getValue();
        var tgt_emp_id       = row.getCellFromKey('TGT_EMP_ID').getValue();
        var status_id        = row.getCellFromKey('STATUS_ID').getValue();
        
        var q_style_page_name  = row.getCellFromKey('Q_STYLE_PAGE_NAME').getValue();
        //var q_yn               = row.getCellFromKey('Q_YN').getValue();
        
        if('" + est_tgt_type + @"' == '') 
        {
            alert('설정된 평가 방법이 없습니다.');
            return;
        }
        else if('" + est_tgt_type + @"' == 'EST') 
        {
            
        }
        else if('" + est_tgt_type + @"' == 'TGT') 
        {
            
        }
        
        if(    q_style_page_name != null 
            && '" + col_estterm_step_agg_visible_yn + @"' == 'N' 
            && q_style_page_name != 'EST_RPT_EMP.aspx')
            gfOpenWindow(q_style_page_name  + '?COMP_ID=" + comp_id.ToString() + @"'
                                            + '&EST_ID='            + est_id
                                            + '&ESTTERM_REF_ID='    + estterm_ref_id
                                            + '&ESTTERM_SUB_ID='    + estterm_sub_id 
                                            + '&ESTTERM_STEP_ID='   + estterm_step_id 
                                            + '&EST_DEPT_ID='       + est_dept_id
                                            + '&EST_EMP_ID='        + est_emp_id
                                            + '&TGT_DEPT_ID='       + tgt_dept_id
                                            + '&TGT_EMP_ID='        + tgt_emp_id
                                            + '&EST_TGT_TYPE=" + est_tgt_type + @"'
                                            ,700
                                            ,600
                                            ,'yes'
                                            ,'no'
                                            , '" + rpt_dtl_id + @"');
    }

    function " + rpt_dtl_id + @"MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    {
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);
           
           var q_style_page_name  = row.getCellFromKey('Q_STYLE_PAGE_NAME').getValue();
        
           if(     q_style_page_name != null 
                && '" + col_estterm_step_agg_visible_yn + @"' == 'N'
                && q_style_page_name != 'EST_RPT_EMP.aspx')
              cell.style.cursor = 'hand';
        }
    }
    </script>";

        return query;
    }

    #endregion
}


