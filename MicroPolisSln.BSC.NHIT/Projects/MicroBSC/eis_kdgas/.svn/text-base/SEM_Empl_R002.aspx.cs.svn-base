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

public partial class SEM_Empl_R002 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            iBtnSearch.Attributes.Add("onclick", "return ValidCtrl();");
            try
            {
                string strEmpNo = (Request["EMP_NO"] == null) ? "" : Request["EMP_NO"];

                this.TableBinding(strEmpNo);
                this.DataBindingFamily(strEmpNo);
                this.DataBindingSchool(strEmpNo);
                this.DataBindingOrder(strEmpNo);

                if (User.IsInRole(ROLE_ADMIN) || User.IsInRole(ROLE_CEO))
                {
                    iBtnInsa.Visible = true;
                }
                else
                {
                    iBtnInsa.Visible = false;
                }
            }
            catch
            {
                return;
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    private void DataBindingObjects() 
    {
        TableBinding(hdfSabun.Value);
        DataBindingFamily(hdfSabun.Value);
        DataBindingSchool(hdfSabun.Value);
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int intCol = e.Layout.Bands[0].Columns.Count;
        int intSpan = 0;
        if (e.Layout.Name.ToString() == "UltraWebGrid1")
        {
            intSpan = (e.Layout.Bands[0].Columns.Count < 1) ? 0 : (int)(760 / e.Layout.Bands[0].Columns.Count);
        }
        else
        {
            intSpan = (e.Layout.Bands[0].Columns.Count < 1) ? 0 : (int)(370 / e.Layout.Bands[0].Columns.Count);
        }

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            e.Layout.Bands[0].Columns[i].Width = intSpan;
        }
    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        
    }

    private void TableBinding(string sabun) 
    {
        string query = @"
                        SELECT SEM_EMPLOYEE_INFO.EMP_SABUN_T,       SEM_EMPLOYEE_INFO.EMP_NAME,                -- 사번 ,             성명
                             SEM_EMPLOYEE_INFO.EMP_JMNO,                     SEM_EMPLOYEE_INFO.EMP_POSITION,   -- 주민번호,       직급코드
                             SEM_EMPLOYEE_INFO.EMP_LAST_SCHOOL,     SEM_EMPLOYEE_INFO.EMP_JOIN_DATE,           -- 최종학년코드,입사일 
                             SEM_EMPLOYEE_INFO.EMP_BRTH_DATE,          SEM_EMPLOYEE_INFO.EMP_MARRY_GUBN,       -- 생일,               결혼유무
                             SEM_EMPLOYEE_INFO.EMP_SEX_GUBN,            SEM_EMPLOYEE_INFO.EMP_LEGAL_RESIDENCE, --성별,                본적
                             SEM_EMPLOYEE_INFO.EMP_ADDRESS,              SEM_EMPLOYEE_INFO.EMP_HOBBY,          -- 주소,               취미
                             SEM_EMPLOYEE_INFO.EMP_SPECIAL_TALENT, SEM_EMPLOYEE_INFO.EMP_MILITARY_FORCE,       -- 특기,                병력
                             SEM_EMPLOYEE_INFO.EMP_MAIN_TALENT,      SEM_EMPLOYEE_INFO.EMP_MILITARY_NUMBER,    -- 주특기,             군번
                             SEM_EMPLOYEE_INFO.EMP_HEIGHT,                 SEM_EMPLOYEE_INFO.EMP_WEIGHT,       -- 신장,                 몸무게
                             SEM_EMPLOYEE_INFO.EMP_VISION_LEFT,       SEM_EMPLOYEE_INFO.EMP_VISION_RIGHT,      -- 시력(좌),          시력(우)
                             SEM_EMPLOYEE_INFO.EMP_BLOOD_TYPE,      SEM_EMPLOYEE_INFO.EMP_EMAIL,               -- 혈액형,              Email
                             SEM_EMPLOYEE_INFO.EMP_STATUS,                SEM_CODE_MASTER.SEM_CODE2_NAME,      -- 상태,                직급명
                             SCHOOL.SEM_CODE2_NAME                                                             -- 최종학력 명
                        FROM SEM_EMPLOYEE_INFO SEM_EMPLOYEE_INFO,                                      -- 인사 기본 Table
                             SEM_CODE_MASTER SEM_CODE_MASTER,                                          -- 코드(직급)
                             SEM_CODE_MASTER SCHOOL                                                   -- 코드(최종학력)
                       WHERE SEM_CODE_MASTER.SEM_CODE1_T(+) = '27'
                         AND SCHOOL.SEM_CODE1_T(+) = '29'
                         AND SEM_EMPLOYEE_INFO.EMP_POSITION = SEM_CODE_MASTER.SEM_CODE3_T(+)
                         AND SEM_EMPLOYEE_INFO.EMP_LAST_SCHOOL = SCHOOL.SEM_CODE2_T(+)
                         AND SEM_EMPLOYEE_INFO.EMP_STATUS in ('1','2','3','4')
                         AND EMP_SABUN_T = '" + sabun + "'";

        DataTable dt = GetDataSet(query).Tables[0];
        if (dt.Rows.Count == 0)
            return;

        DataRow dr = dt.Rows[0];

        lblName.Text        = dr["EMP_NAME"].ToString();
        lblAddress.Text     = dr["EMP_ADDRESS"].ToString();
        lblBloodType.Text   = dr["EMP_BLOOD_TYPE"].ToString();
        lblBonjuk.Text      = "";
        lblBrthDate.Text    = GetDate(dr["EMP_BRTH_DATE"].ToString());
        lblEMail.Text       = dr["EMP_EMAIL"].ToString();
        lblHeight.Text      = dr["EMP_HEIGHT"].ToString();
        lblHobby.Text       = dr["EMP_HOBBY"].ToString();
        lblJmno.Text        = (dr["EMP_JMNO"].ToString().Length != 13) ? "" : dr["EMP_JMNO"].ToString().Substring(0, 6) + " - " + dr["EMP_JMNO"].ToString().Substring(6, 7);
        lblJoinDate.Text    = GetDate(dr["EMP_JOIN_DATE"].ToString());
        lblMainTalent.Text  = dr["EMP_MAIN_TALENT"].ToString();
        lblMarryGubn.Text   = (dr["EMP_MARRY_GUBN"].ToString() == "Y") ? "기혼" : "미혼";
        lblMilitaryNumber.Text = dr["EMP_MILITARY_NUMBER"].ToString();
        lblSabun.Text           = dr["EMP_SABUN_T"].ToString();
        lblSexGubn.Text         = (dr["EMP_SEX_GUBN"].ToString() == "1") ? "남": "여";
        lblSpecialTalent.Text   = dr["EMP_SPECIAL_TALENT"].ToString();
        lblVisionLeft.Text      = dr["EMP_VISION_LEFT"].ToString();
        lblVisionRight.Text     = dr["EMP_VISION_RIGHT"].ToString();
        lblWeight.Text          = dr["EMP_WEIGHT"].ToString();
        imgEmp.ImageUrl = "../images/photo/"+sabun + ".BMP";
        imgEmp.Width = System.Web.UI.WebControls.Unit.Pixel(100);
        imgEmp.Height = System.Web.UI.WebControls.Unit.Pixel(125); ;
    }
    private string GetDate(string date) 
    {
        return (date.Length != 8) ? "" : date.Substring(0, 4) + "." + date.Substring(4, 2) + "." + date.Substring(6, 2);
    }
    private void DataBindingFamily(string sabun) 
    {
        string query = @"SELECT         FAMILY.EMP_SABUN_T,
                                        FAMILY.EMP_RELATION,                            -- 관계
                                        FAMILY.EMP_NAME,                                -- 가족 명
                                        FAMILY.EMP_BRTH_DATE,                         	-- 생년월일
                                        FAMILY.EMP_JOB                                  -- 직업
                            FROM SEM_EMPLOYEE_FAMILY FAMILY
                        WHERE FAMILY.EMP_SABUN_T = '" + sabun + @"'";
        UltraWebGrid2.DataSource = GetDataSet(query);
        UltraWebGrid2.DataBind();
    }
    private void DataBindingSchool(string sabun)
    {
        string query = @"SELECT SCHOOL.EMP_ENTER_DATE,                          -- 입학년월
                                SCHOOL.EMP_GRADUATE_DATE,             	        -- 졸업년월
                                SCHOOL.EMP_SCHOOL,                              -- 최종학교
                                SCHOOL.EMP_STUDY                                -- 전공
                            FROM SEM_EMPLOYEE_SCHOOL SCHOOL
                                WHERE SCHOOL.EMP_SABUN_T = '" + sabun + @"'";
                        
        UltraWebGrid3.DataSource = GetDataSet(query);
        UltraWebGrid3.DataBind();
    }
    private void DataBindingOrder(string sabun)
    {
        string query = @"SELECT     EMPL.EMP_BAL_DATE 발령일자,                      -- 발령일자
                                    EMPL.EMP_EMPLOYMENT_GUBN 발령구분,               -- 발령구분
                                    EMPL.EMP_POST 부서,                          -- 부서 
                                    EMPL.EMP_POSITION 직급,                      -- 직급
                                    EMPL.EMP_SALARY_CLASS 호봉                  -- 호봉
                            FROM SEM_EMPLOYMENT EMPL
                                WHERE EMPL.EMP_SABUN_T = '" + sabun + @"' ORDER BY EMPL.EMP_BAL_DATE";

        UltraWebGrid1.DataSource = GetDataSet(query);
        UltraWebGrid1.DataBind();
    }
    private void DataBindingJob(string sabun)
    {
        string query = @"SELECT     CAREER.EMP_JOIN_DATE 입사일,                    -- 입사일
                                    CAREER.EMP_RETIRE_DATE 퇴사일,                  -- 퇴사일
                                    CAREER.EMP_OFFICE_NAME 직장명,                  -- 직장명
                                    CAREER.EMP_JOB_FUNCTION 직무,                 -- 직무
                                    CAREER.EMP_POST 소속,                         -- 소속
                                    CAREER.EMP_POSITING 직위                     -- 직위
                            FROM SEM_EMPLOYEE_CAREER CAREER
                                WHERE CAREER.EMP_SABUN_T = '" + sabun + @"'";

        UltraWebGrid1.DataSource = GetDataSet(query);
        UltraWebGrid1.DataBind();
    }
    private void DataBindingCtf(string sabun)
    {
        string query = @"SELECT     LICENSE.EMP_GET_DATE 취득일자,                         -- 취득일자
                                    LICENSE.EMP_CERTIFICATE 자격증명,                      -- 자격증 명
                                    LICENSE.EMP_GRADE 등급                             -- 등급
                              FROM SEM_EMPLOYEE_LICENSE LICENSE
                           WHERE LICENSE.EMP_SABUN_T = '" + sabun + @"'";

        UltraWebGrid1.DataSource = GetDataSet(query);
        UltraWebGrid1.DataBind();
    }
    private void DataBindingPrize(string sabun)
    {
        string query = @"SELECT     REWARD.EMP_REWARD_DATE 상훈징벌일자,                 -- 상훈_징벌 일자
                                    REWARD.EMP_REWARD_GUBN 상훈구분,                 -- 상훈 구분
                                    REWARD.EMP_REWARD_REASON 상훈사유                --  상훈 사유
                            FROM SEM_EMPLOYEE_REWARD REWARD
                                WHERE REWARD.EMP_SABUN_T = '" + sabun + @"'";

        UltraWebGrid1.DataSource = GetDataSet(query);
        UltraWebGrid1.DataBind();
    }
    private void DataBindingInsa(string sabun)
    {
       string query = @"  SELECT ES.EMP_DATE_T as 평가년도,
                                   OT.SEM_ORG_CODE1_NAME 부문,
                                   OT.SEM_ORG_CODE2_NAME 팀,
                                   round(ES.EMP_PERFORMANCE_RATING,1) 인사고과,
                                   ES.EMP_RESULT_RATING 점수,
                                   ES.EMP_TEST_POINTS as 시험점수,
                                   (CASE WHEN ES.EMP_GRADE = '1' THEN 'D'
                                         WHEN ES.EMP_GRADE = '2' THEN 'C'
                                         WHEN ES.EMP_GRADE = '3' THEN 'B'
                                         WHEN ES.EMP_GRADE = '4' THEN 'A'
                                         WHEN ES.EMP_GRADE = '5' THEN 'S' ELSE '' END) as 등급,
                                   ES.EMP_PROMOTION_RATING as 전체순위
                              FROM SEM_EMPLOYEE_ESTIMATE ES,
                                   SEM_ORG_TABLE OT
                             WHERE ES.EMP_TEAM = OT.SEM_ORG_CODE3(+)
                               AND (ES.EMP_SABUN_T-1111111)/3 = '"+sabun+@"'             -- (사번 * 3)+1111111
                              ORDER BY ES.EMP_DATE_T DESC";

        UltraWebGrid1.DataSource = GetDataSet(query);
        UltraWebGrid1.DataBind();
    }
    private void DataBindingLearning(string sabun)
    {
        string query = @"SELECT     EDUC.EMP_FROM_DATE 교육시작일,                      -- 교육 시작일
                                    EDUC.EMP_TO_DATE 교육종료일,                        -- 교육 종료일
                                    EDUC.EMP_STUDY 교육내용,                          -- 교육 내용
                                    EDUC.EMP_MARKS 점수                          -- 점수
                            FROM SEM_EMPLOYEE_EDUCATION EDUC
                                WHERE EDUC.EMP_SABUN_T = '" + sabun + @"'";

        UltraWebGrid1.DataSource = GetDataSet(query);
        UltraWebGrid1.DataBind();
    }
    protected void iBtnOrder_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.Clear();
        DataBindingOrder(hdfSabun.Value);
    }
    protected void iBtnPrize_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.Clear();
        DataBindingPrize(hdfSabun.Value);
    }
    protected void iBtnJob_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.Clear();
        DataBindingJob(hdfSabun.Value);
    }
    protected void iBtnInsa_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.Clear();
        DataBindingInsa(hdfSabun.Value);
    }
    protected void iBtnCtf_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.Clear();
        DataBindingCtf(hdfSabun.Value);
    }
    protected void iBtnLearning_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.Clear();
        DataBindingLearning(hdfSabun.Value);
    }
}
