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
using MicroBSC.Integration.MUL.Biz;

public partial class MUL_MUL0300S1 : EstPageBase
{
    Biz_Mul_Basic_Info bizMulBasicInfo;

    private string EST_ID = "0";

    private int EST_MAX_COUNT = 10;
    private string EST_RANGE = "A"; // A:전체. D:부서만
    private string EST_METHOD = "R"; // R:RANDON   S:우선순위

    const int ConESTTERM_STEP_ID = 2;
    const string ConDIRECTION_TYPE = "MU";

    protected int DEPT_REF_ID
    {
        get
        {
            if (ViewState["DEPT_REF_ID"] == null)
                return -1;

            return (int)ViewState["DEPT_REF_ID"];
        }
        set
        {
            ViewState["DEPT_REF_ID"] = value;
        }
    }

    protected DataTable DT_DEPTEMP
    {
        get
        {
            if (ViewState["DT_DEPTEMP"] == null)
                return null;

            return (DataTable)ViewState["DT_DEPTEMP"];
        }
        set
        {
            ViewState["DT_DEPTEMP"] = value;
        }
    }

    protected DataTable DT_ESTEMP
    {
        get
        {
            if (ViewState["DT_ESTEMP"] == null)
                return null;

            return (DataTable)ViewState["DT_ESTEMP"];
        }
        set
        {
            ViewState["DT_ESTEMP"] = value;
        }
    }

    protected DataTable DT_TGTEMP
    {
        get
        {
            if (ViewState["DT_TGTEMP"] == null)
                return null;

            return (DataTable)ViewState["DT_TGTEMP"];
        }
        set
        {
            ViewState["DT_TGTEMP"] = value;
        }
    }

    protected DataTable DT_ESTTARGETMAP
    {
        get
        {
            if (ViewState["DT_ESTTARGETMAP"] == null)
                return null;

            return (DataTable)ViewState["DT_ESTTARGETMAP"];
        }
        set
        {
            ViewState["DT_ESTTARGETMAP"] = value;
        }
    }

    protected DataTable DT_ESTTARGETMAP_GROUPBYEST
    {
        get
        {
            if (ViewState["DT_ESTTARGETMAP_GROUPBYEST"] == null)
                return null;

            return (DataTable)ViewState["DT_ESTTARGETMAP_GROUPBYEST"];
        }
        set
        {
            ViewState["DT_ESTTARGETMAP_GROUPBYEST"] = value;
        }
    }

    protected DataTable DT_ESTTARGETMAP_GROUPBYTGT
    {
        get
        {
            if (ViewState["DT_ESTTARGETMAP_GROUPBYTGT"] == null)
                return null;

            return (DataTable)ViewState["DT_ESTTARGETMAP_GROUPBYTGT"];
        }
        set
        {
            ViewState["DT_ESTTARGETMAP_GROUPBYTGT"] = value;
        }
    }

    protected DataTable DT_EST_DATA
    {
        get
        {
            if (ViewState["DT_EST_DATA"] == null)
                return null;

            return (DataTable)ViewState["DT_EST_DATA"];
        }
        set
        {
            ViewState["DT_EST_DATA"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bizMulBasicInfo = new Biz_Mul_Basic_Info();

        if (!IsPostBack)
        {

            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID
                                                    , WebUtility.GetIntByValueDropDownList(ddlCompID)
                                                    , "N");

            DropDownListCommom.BindEstStyle(ddlEstList, WebUtility.GetIntByValueDropDownList(ddlCompID), "MUL");

            rdoEstTypeList.Items.Add(new ListItem("평가자", "EST"));
            rdoEstTypeList.Items.Add(new ListItem("피평가자", "TGT"));
            rdoEstTypeList.SelectedIndex = 0;


            ibnRandom.Enabled = false;
            ibnDelRandom.Enabled = false;
        }


        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID = WebUtility.GetByValueDropDownList(ddlEstList);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);


        EST_MAX_COUNT = DataTypeUtility.GetToInt32(this.txtMaxEstEmpCnt.Text);


        if(!IsPostBack)
            doBinding_MulBasicInfo();            


        ltrScript.Text = "";
    }
    

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        int dept_ref_id = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("DEPT_REF_ID").Value);

        int est_cnt = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("EST_CNT").Value);
        int tgt_cnt = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("TGT_CNT").Value);

        DataRow[] rows = DT_ESTTARGETMAP_GROUPBYTGT.Select(string.Format(" EST_DEPT_ID = {0} AND DIRECTION_TYPE = '{1}' ", dept_ref_id, ConDIRECTION_TYPE));

        e.Row.Cells.FromKey("EST_CNT").Value = string.Format("{0}/{1}", rows.Length, est_cnt);
        if (rows.Length > 0)
        {
            e.Row.Cells.FromKey("EST_CNT").Style.ForeColor = System.Drawing.Color.Red;
            e.Row.Cells.FromKey("EST_CNT").Style.Font.Bold = true;
        }

        rows = DT_ESTTARGETMAP_GROUPBYEST.Select(string.Format(" TGT_DEPT_ID = {0} AND DIRECTION_TYPE= '{1}' ", dept_ref_id, ConDIRECTION_TYPE));

        e.Row.Cells.FromKey("TGT_CNT").Value = string.Format("{0}/{1}", rows.Length, tgt_cnt);
        if (rows.Length > 0)
        {
            e.Row.Cells.FromKey("TGT_CNT").Style.ForeColor = System.Drawing.Color.Red;
            e.Row.Cells.FromKey("TGT_CNT").Style.Font.Bold = true;
        }

        //status_id 체크 후 체크박스 비활성화
        //수정 - est_data로 들어갔으면 다면평가 랜덤 지정/해제가 불가능하도록 설정
        /*
        if (DT_DEPTEMP != null)
        {
            bool allowModify = CheckModifyPossiblity(dept_ref_id);

            TemplatedColumn selchk = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[e.Row.BandIndex]).FindControl("cBox");

            cBox.Enabled = allowModify;
        }
        */
    }
    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        UltraWebGrid2.Clear();
        UltraWebGrid3.Clear();

        if (e.SelectedRows.Count > 0)
        {
            string dept_name = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("DEPT_NAME").Value);

            lblTitleDept.Text = string.Format("({0})", dept_name);

            DEPT_REF_ID = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("DEPT_REF_ID").Value);
            DoBinding_Emp(DEPT_REF_ID);
        }
    }
    


    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
    }
    protected void UltraWebGrid2_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0)
        {
            int est_emp_id = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("EST_EMP_ID").Value);
            DoBinding_EST(est_emp_id);
        }
    }


    protected void ibnRandom_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Mul_Est_Target_Pool bizMulEstTargetPool = new Biz_Mul_Est_Target_Pool();

        DataTable DT_dept_ref_id = UltraGridUtility.GetDataSetByCheckedBox(UltraWebGrid1, new string[] { "DEPT_REF_ID" }, "selchk", "cBox").Tables[0];
        
        StringBuilder dept_ref_id_list = new StringBuilder();


        //전체 직원 정보, 평가, 피평가 포함된 테이블 스키마 복사
        DataTable dtResult = DT_DEPTEMP.Clone();



        for (int i = 0; i < DT_dept_ref_id.Rows.Count; i++)
        {
            string dept_ref_id = DT_dept_ref_id.Rows[i]["DEPT_REF_ID"].ToString();
            if (dept_ref_id_list.Length > 0)
                dept_ref_id_list.Append(", ");
            dept_ref_id_list.Append(dept_ref_id);
        }


        //해당 부서들의 피평가자들 리스트
        DataTable DT_tgt_emp_id = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" EST_TYPE_TGT = 'TGT' AND DEPT_REF_ID IN ({0}) ", dept_ref_id_list.ToString()));

        
        
        //피평가자들의 모든 평가자 리스트
        DataTable DT_est_emp_id = bizMulEstTargetPool.Get_BaseEstEmpList(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, DT_tgt_emp_id);





        DT_est_emp_id.Columns.Add("TGT_DEPT_ID");
        DT_est_emp_id.Columns.Add("TGT_EMP_NAME");
        DT_est_emp_id.Columns.Add("TGT_CLASS_CODE");
        DT_est_emp_id.Columns.Add("TGT_CLS_NAME");
        DT_est_emp_id.Columns.Add("TGT_GRP_CODE");
        DT_est_emp_id.Columns.Add("TGT_GRP_NAME");
        DT_est_emp_id.Columns.Add("TGT_RANK_CODE");
        DT_est_emp_id.Columns.Add("TGT_RANK_NAME");
        DT_est_emp_id.Columns.Add("TGT_DUTY_CODE");
        DT_est_emp_id.Columns.Add("TGT_DUT_NAME");
        DT_est_emp_id.Columns.Add("TGT_KIND_CODE");
        DT_est_emp_id.Columns.Add("TGT_KND_NAME");

        StringBuilder est_tgt_list = new StringBuilder();

        for (int i = 0; i < DT_dept_ref_id.Rows.Count; i++)
        {

            string c_dept_ref_id = DT_dept_ref_id.Rows[i]["DEPT_REF_ID"].ToString();
            DataTable c_DT_tgt_emp_id = DataTypeUtility.FilterSortDataTable(DT_tgt_emp_id, string.Format("DEPT_REF_ID={0}", c_dept_ref_id));

            //선택된 부서의 피평가자 수만큼 루프
            for (int j = 0; j < c_DT_tgt_emp_id.Rows.Count; j++)
            {
                string tgt_dept_id          = c_DT_tgt_emp_id.Rows[j]["DEPT_REF_ID"].ToString();
                string tgt_emp_id           = c_DT_tgt_emp_id.Rows[j]["EMP_REF_ID"].ToString();
                string tgt_emp_name         = c_DT_tgt_emp_id.Rows[j]["EMP_NAME"].ToString();
                string position_class_code  = c_DT_tgt_emp_id.Rows[j]["POSITION_CLASS_CODE"].ToString();
                string pos_cls_name         = c_DT_tgt_emp_id.Rows[j]["POS_CLS_NAME"].ToString();
                string position_grp_code    = c_DT_tgt_emp_id.Rows[j]["POSITION_GRP_CODE"].ToString();
                string pos_grp_name         = c_DT_tgt_emp_id.Rows[j]["POS_GRP_NAME"].ToString();
                string position_rank_code   = c_DT_tgt_emp_id.Rows[j]["POSITION_RANK_CODE"].ToString();
                string pos_rank_name        = c_DT_tgt_emp_id.Rows[j]["POS_RNK_NAME"].ToString();
                string position_duty_code   = c_DT_tgt_emp_id.Rows[j]["POSITION_DUTY_CODE"].ToString();
                string pos_dut_name         = c_DT_tgt_emp_id.Rows[j]["POS_DUT_NAME"].ToString();
                string position_kind_code   = c_DT_tgt_emp_id.Rows[j]["POSITION_KIND_CODE"].ToString();
                string pos_knd_name         = c_DT_tgt_emp_id.Rows[j]["POS_KND_NAME"].ToString();




                //해당 피평가자에 대한 평가자 리스트 추출
                string filter_Extract_EstEmp = string.Format("TGT_EMP_ID={0} AND EST_EMP_ID <> {0}", tgt_emp_id);
                DataTable dtRandom = DataTypeUtility.FilterSortDataTable(DT_est_emp_id, filter_Extract_EstEmp);



                StringBuilder est_emp_list = new StringBuilder();

                if (dtRandom.Rows.Count > 0)
                {
                    for (int k = 0; k < EST_MAX_COUNT; k++)
                    {
                        int cntRandom = dtRandom.Rows.Count;


                        //행 감소를 체크
                        if (cntRandom == 0)
                            break;


                        //랜덤 인덱스
                        Random rnd = new Random();
                        int rndNum = rnd.Next();
                        int rndIdx = rndNum % cntRandom;




                        //평가자 EMP_REF_ID
                        if (est_emp_list.Length > 0)
                            est_emp_list.Append(", ");
                        est_emp_list.Append(j.ToString() + "-" + dtRandom.Rows[rndIdx]["EMP_REF_ID"].ToString());



                        DataRow rowRandom = dtRandom.Rows[rndIdx];

                        rowRandom["TGT_DEPT_ID"] = tgt_dept_id;
                        rowRandom["TGT_EMP_ID"] = tgt_emp_id;
                        rowRandom["TGT_EMP_NAME"] = tgt_emp_name;
                        rowRandom["TGT_CLASS_CODE"] = position_class_code;
                        rowRandom["TGT_CLS_NAME"] = pos_cls_name;
                        rowRandom["TGT_GRP_CODE"] = position_grp_code;
                        rowRandom["TGT_GRP_NAME"] = pos_grp_name;
                        rowRandom["TGT_RANK_CODE"] = position_rank_code;
                        rowRandom["TGT_RANK_NAME"] = pos_rank_name;
                        rowRandom["TGT_DUTY_CODE"] = position_duty_code;
                        rowRandom["TGT_DUT_NAME"] = pos_dut_name;
                        rowRandom["TGT_KIND_CODE"] = position_kind_code;
                        rowRandom["TGT_KND_NAME"] = pos_knd_name;



                        //평가자 추가
                        dtResult.ImportRow(rowRandom);



                        //원본 데이터에서 사용한 데이터 삭제 확정
                        rowRandom.Delete();
                        dtRandom.AcceptChanges();
                    }



                    if (est_emp_list.Length > 0)
                    {
                        if (est_tgt_list.Length > 0)
                            est_tgt_list.Append(";");
                        est_tgt_list.Append(string.Format("{2}. {0}={1}", tgt_emp_id, est_emp_list.ToString(), i.ToString()));
                    }
                }
            }
        }

        if (dept_ref_id_list.Length == 0)
            dept_ref_id_list.Append("-1");
        

        DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" DEPT_REF_ID  IN ({0})  ", dept_ref_id_list));

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpEstTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();
        
        
        
        //해당 부서에 해당하는 직원이 피평가자로 있는 매핑 데이터를 모두 삭제 후 다시 추가
        string okMsg = bizEstEmpEstTargetMap.AddEmpEstTargetMapFromPool(dtEmp
                                                                 , dtResult
                                                                 , COMP_ID
                                                                 , EST_ID
                                                                 , ESTTERM_REF_ID
                                                                 , ESTTERM_SUB_ID
                                                                 , ConESTTERM_STEP_ID
                                                                 , ConDIRECTION_TYPE
                                                                 , "N"
                                                                 , DateTime.Now
                                                                 , this.gUserInfo.Emp_Ref_ID);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("실패하였습니다.", false);
        }
    }


    protected void ibnDelRandom_Click(object sender, ImageClickEventArgs e)
    {
        int cnt = UltraWebGrid1.Rows.Count;

        string dept_ref_id_list = string.Empty;

        for (int i = 0; i < cnt; i++)
        {
            UltraGridRow row = UltraWebGrid1.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                dept_ref_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("DEPT_REF_ID").Value);
            }
        }

        if (dept_ref_id_list.Length > 0)
        {
            dept_ref_id_list = dept_ref_id_list.Remove(0, 1);
        }
        else
        {
            dept_ref_id_list = "-1";
        }

        DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" DEPT_REF_ID  IN ({0})  ", dept_ref_id_list));

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpEstTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();

        string okMsg = bizEstEmpEstTargetMap.AddEmpEstTargetMapFromPool(dtEmp
                                                                 , null
                                                                 , COMP_ID
                                                                 , EST_ID
                                                                 , ESTTERM_REF_ID
                                                                 , ESTTERM_SUB_ID
                                                                 , ConESTTERM_STEP_ID
                                                                 , ConDIRECTION_TYPE
                                                                 , "N"
                                                                 , DateTime.Now
                                                                 , this.gUserInfo.Emp_Ref_ID);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(okMsg);
        }
    }


    protected bool CheckModifyPossiblity(int dept_ref_id)
    {
        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();

        bool allowModify;


        //현재 부서의 피평가자 목록 데이터테이블
        DataTable c_DT_tgt_emp_id = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" EST_TYPE_TGT = 'TGT' AND DEPT_REF_ID={0}", dept_ref_id));
        
        
        
        //현재 부서의 피평가자 목록 스트링
        StringBuilder tgt_emp_id_list = new StringBuilder();
        for (int i = 0; i < c_DT_tgt_emp_id.Rows.Count; i++)
        {
            if (tgt_emp_id_list.Length > 0)
                tgt_emp_id_list.Append(", ");
            tgt_emp_id_list.Append(c_DT_tgt_emp_id.Rows[i]["EMP_REF_ID"].ToString());
        }
        
        if(tgt_emp_id_list.Length==0)
            tgt_emp_id_list.Append("''");

        //현재 부서의 피평가자에 대한 평가자 매핑 정보
        DataTable dtConfirmed = DataTypeUtility.FilterSortDataTable(DT_EST_DATA, string.Format("TGT_EMP_ID IN ({0})", tgt_emp_id_list.ToString()));



        if (dtConfirmed.Rows.Count > 0)
            allowModify = false;
        else
            allowModify = true;

        return allowModify;
    }


    protected void ibnAddEstData_Click(object sender, ImageClickEventArgs e)
    {
        //int cnt = UltraWebGrid1.Rows.Count;

        //string dept_ref_id_list = string.Empty;

        //for (int i = 0; i < cnt; i++)
        //{
        //    UltraGridRow row = UltraWebGrid1.Rows[i];

        //    TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
        //    CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

        //    if (cBox.Checked)
        //    {
        //        dept_ref_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("DEPT_REF_ID").Value);
        //    }
        //}

        //if (dept_ref_id_list.Length > 0)
        //{
        //    dept_ref_id_list = dept_ref_id_list.Remove(0, 1);
        //}
        //else
        //{
        //    dept_ref_id_list = "-1";
        //}
        //DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, string.Format(" TGT_DEPT_ID  IN ({0}) AND DIRECTION_TYPE = '{1}' ", dept_ref_id_list, ConDIRECTION_TYPE));
        
        
        //전체 확정
        DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, string.Format(" DIRECTION_TYPE = '{0}' ", ConDIRECTION_TYPE));

        DataTable dtDel = DataTypeUtility.GetGroupByDataTable(dtEmp.Copy(), new string[] { "TGT_EMP_ID" });

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        string okMsg = bizEstData.AddData(dtDel
                                        , dtEmp
                                        , COMP_ID
                                        , EST_ID
                                        , ESTTERM_REF_ID
                                        , ESTTERM_SUB_ID
                                        , ConESTTERM_STEP_ID
                                        , ConDIRECTION_TYPE
                                        , "N"
                                        , DateTime.Now
                                        , DateTime.Now
                                        , this.gUserInfo.Emp_Ref_ID);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
            DEPT_REF_ID = -1;

        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(okMsg);
        }
    }


    protected void ibnDelEstData_Click(object sender, ImageClickEventArgs e)
    {
        //int cnt = UltraWebGrid1.Rows.Count;

        //string dept_ref_id_list = string.Empty;

        //for (int i = 0; i < cnt; i++)
        //{
        //    UltraGridRow row = UltraWebGrid1.Rows[i];

        //    TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
        //    CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");
           
        //    if (cBox.Checked || !cBox.Enabled)
        //    {
        //        dept_ref_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("DEPT_REF_ID").Value);
        //    }
        //}

        //if (dept_ref_id_list.Length > 0)
        //{
        //    dept_ref_id_list = dept_ref_id_list.Remove(0, 1);
        //}
        //else
        //{
        //    dept_ref_id_list = "-1";
        //}

        //DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, string.Format(" TGT_DEPT_ID  IN ({0}) AND DIRECTION_TYPE = '{1}' ", dept_ref_id_list, ConDIRECTION_TYPE));


        //전체 확정 취소
        DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, string.Format(" DIRECTION_TYPE = '{0}' ", ConDIRECTION_TYPE));

        DataTable dtDel = DataTypeUtility.GetGroupByDataTable(dtEmp.Copy(), new string[] { "TGT_EMP_ID" });

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        string okMsg = bizEstData.RemoveEstData(dtDel
                                             , COMP_ID
                                             , EST_ID
                                             , ESTTERM_REF_ID
                                             , ESTTERM_SUB_ID
                                             , ConESTTERM_STEP_ID
                                             , ConDIRECTION_TYPE);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
            DEPT_REF_ID = -1;

        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(okMsg);
        }
    }


    protected void rdoEstTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (UltraWebGrid1.Rows.Count > 0)
        {
            if (DEPT_REF_ID > 0)
            {
                DoBinding_Emp(DEPT_REF_ID);
            }
        }

    }


    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding_Dept();
    }
    private void DoBinding_Dept()
    {
        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();
        DT_EST_DATA = bizEstData.GetEstData(COMP_ID
                                          , EST_ID
                                          , ESTTERM_REF_ID
                                          , ESTTERM_SUB_ID
                                          , ConESTTERM_STEP_ID
                                          , ConDIRECTION_TYPE);


        DEPT_REF_ID = -1;
        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();
        UltraWebGrid3.Clear();

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEmpEstTargetMaps = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();
        DT_ESTTARGETMAP = bizEmpEstTargetMaps.GetEmpEstTargetMap(COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ConESTTERM_STEP_ID
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , 0).Tables[0];

        string[] groupBy = { "TGT_DEPT_ID"
                            ,"TGT_DEPT_NAME"
                            ,"TGT_EMP_ID"
                            ,"TGT_EMP_NAME"
                            ,"TGT_POS_CLS_ID"
                            ,"TGT_POS_CLS_NAME"
                            ,"TGT_POS_DUT_ID"
                            ,"TGT_POS_DUT_NAME"
                            ,"TGT_POS_GRP_ID"
                            ,"TGT_POS_GRP_NAME"
                            ,"TGT_POS_RNK_ID"
                            ,"TGT_POS_RNK_NAME"
                            ,"TGT_POS_KND_ID"
                            ,"TGT_POS_KND_NAME"
                            ,"DIRECTION_TYPE" };

        DataTable dtEst = DT_ESTTARGETMAP.Copy();
        DataTable dtTgt = DT_ESTTARGETMAP.Copy();

        DT_ESTTARGETMAP_GROUPBYEST = DataTypeUtility.GetGroupByDataTable(dtEst, groupBy);

        DT_ESTTARGETMAP_GROUPBYTGT = DataTypeUtility.GetGroupByDataTable(dtTgt, new string[] { "EST_DEPT_ID", "EST_EMP_ID", "DIRECTION_TYPE" });




        MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp bizMulEstEmp = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp();
        DataTable dtMulEstEmp = bizMulEstEmp.GetDeptMapping_DB(COMP_ID
                                                             , EST_ID
                                                             , ESTTERM_REF_ID
                                                             , ESTTERM_SUB_ID);

        

        // 평가자 목록 (EST_TYPE : EST)
        /*
        DT_ESTEMP = bizMulEstEmp.GetEstEmp_DB(COMP_ID
                                             , EST_ID
                                             , ESTTERM_REF_ID
                                             , ESTTERM_SUB_ID
                                             , 0
                                             , "");
        */
        MicroBSC.Integration.COM.Biz.Biz_Rel_Dept_Emp bizRelDeptEmp = new MicroBSC.Integration.COM.Biz.Biz_Rel_Dept_Emp();
        DT_DEPTEMP = bizRelDeptEmp.GetRelDeptEmp_DB(0
                                                  , COMP_ID
                                                  , EST_ID
                                                  , ESTTERM_REF_ID
                                                  , ESTTERM_SUB_ID);

        DT_DEPTEMP.Columns.Add("TGT_DEPT_ID");
        DT_DEPTEMP.Columns.Add("TGT_EMP_ID");
        DT_DEPTEMP.Columns.Add("TGT_EMP_NAME");
        DT_DEPTEMP.Columns.Add("TGT_CLASS_CODE");
        DT_DEPTEMP.Columns.Add("TGT_CLS_NAME");
        DT_DEPTEMP.Columns.Add("TGT_GRP_CODE");
        DT_DEPTEMP.Columns.Add("TGT_GRP_NAME");
        DT_DEPTEMP.Columns.Add("TGT_RANK_CODE");
        DT_DEPTEMP.Columns.Add("TGT_RANK_NAME");
        DT_DEPTEMP.Columns.Add("TGT_DUTY_CODE");
        DT_DEPTEMP.Columns.Add("TGT_DUT_NAME");
        DT_DEPTEMP.Columns.Add("TGT_KIND_CODE");
        DT_DEPTEMP.Columns.Add("TGT_KND_NAME");




        //랜덤 지정/해제 버튼 보이기 상태
        setRndButtonVisible();
        



        //매핑 확정/취소 버튼 보이기상태
        if (CheckPossiblityCancelConfirm())
        {
            ibnAddEstData.Visible = true;
            ibnDelEstData.Visible = true;
        }
        else
        {
            ibnAddEstData.Visible = false;
            ibnDelEstData.Visible = false;
        }





        //바인드
        UltraWebGrid1.DataSource = dtMulEstEmp;
        UltraWebGrid1.DataBind();

        if (dtMulEstEmp.Rows.Count > 0)
        {
            ibnRandom.Enabled = true;
            ibnDelRandom.Enabled = true;
        }
        else
        {
            ibnRandom.Enabled = false;
            ibnDelRandom.Enabled = false;
        }
    }


    private void setRndButtonVisible()
    {
        if (DT_EST_DATA.Rows.Count > 0)
        {
            this.ibnRandom.Visible = false;
            this.ibnDelRandom.Visible = false;
        }
        else
        {
            this.ibnRandom.Visible = true;
            this.ibnDelRandom.Visible = true;
        }
    }


    /// <summary>
    /// STATUS_ID 체크
    /// </summary>
    protected bool CheckPossiblityCancelConfirm()
    {
        bool Result = true;

        for (int i = 0; i < DT_EST_DATA.Rows.Count; i++)
        {
            if (!DT_EST_DATA.Rows[i]["STATUS_ID"].ToString().Equals("N"))
            {
                Result = false;
                break;
            }
        }

        return Result;
    }


    private void DoBinding_Emp(int dept_ref_id)
    {
        string filter = string.Format(" TGT_DEPT_ID = {0} ", dept_ref_id);
        string sort = "TGT_EMP_NAME";
        string[] groupBy = { "TGT_DEPT_ID"
                            ,"TGT_DEPT_NAME"
                            ,"TGT_EMP_ID"
                            ,"TGT_EMP_NAME"
                            ,"TGT_POS_CLS_ID"
                            ,"TGT_POS_CLS_NAME"
                            ,"TGT_POS_DUT_ID"
                            ,"TGT_POS_DUT_NAME"
                            ,"TGT_POS_GRP_ID"
                            ,"TGT_POS_GRP_NAME"
                            ,"TGT_POS_RNK_ID"
                            ,"TGT_POS_RNK_NAME"
                            ,"TGT_POS_KND_ID"
                            ,"TGT_POS_KND_NAME"
                            ,"DIRECTION_TYPE"};

        UltraWebGrid2.Columns[1].BaseColumnName = "TGT_EMP_NAME";
        UltraWebGrid2.Columns[2].BaseColumnName = "TGT_POS_KND_NAME";
        UltraWebGrid2.Columns[3].BaseColumnName = "TGT_POS_CLS_NAME";
        UltraWebGrid2.Columns[4].BaseColumnName = "TGT_POS_DUT_NAME";
        UltraWebGrid2.Columns[5].BaseColumnName = "TGT_EMP_ID";


        DataTable dtDeptEmp = DataTypeUtility.FilterSortDataTable(DataTypeUtility.GetGroupByDataTable(DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, filter)
                                                                                                    , groupBy)
                                                                , ""
                                                                , sort);
        UltraWebGrid2.DataSource = dtDeptEmp;
        UltraWebGrid2.DataBind();
    }


    private void DoBinding_EST(int est_emp_id)
    {
        DataTable dtEST = DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, string.Format(" TGT_EMP_ID = {0} ", est_emp_id), " EST_DEPT_NAME, EST_EMP_NAME ");
        UltraWebGrid3.DataSource = dtEST;
        UltraWebGrid3.DataBind();
    }


    protected bool doDelete_Mul_Basic_Info()
    {
        return bizMulBasicInfo.Remove_Mul_Basic_Info(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);
    }


    protected void doBinding_MulBasicInfo()
    {
        DataTable DT = bizMulBasicInfo.Get_Mul_Basic_Info(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

        if (DT.Rows.Count > 0)
        {
            this.txtMaxEstEmpCnt.Value = DT.Rows[0]["MAX_EST_EMP_CNT"].ToString();
            this.txtMidEstEmpCnt.Value = DT.Rows[0]["MID_EST_EMP_CNT"].ToString();
            this.txtMinEstEmpCnt.Value = DT.Rows[0]["MIN_EST_EMP_CNT"].ToString();
        }
    }


    protected void ibnClearMulBasicInfo_Click(object sender, ImageClickEventArgs e)
    {
        doDelete_Mul_Basic_Info();

        SetEstCntRangeDefault();

        this.ltrScript.Text = JSHelper.GetAlertScript("초기화하였습니다.");
    }


    protected void ibnSaveMulBasicInfo_Click(object sender, ImageClickEventArgs e)
    {
        bool Result = doSave_Mul_Basic_Info();

        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장에 실패하였습니다.");
        }
    }
    protected bool doSave_Mul_Basic_Info()
    {
        int MaxEstEmpCnt = DataTypeUtility.GetToInt32(this.txtMaxEstEmpCnt.Value);
        int MidEstEmpCnt = DataTypeUtility.GetToInt32(this.txtMidEstEmpCnt.Value);
        int MinEstEmpCnt = DataTypeUtility.GetToInt32(this.txtMinEstEmpCnt.Value);

        doDelete_Mul_Basic_Info();

        return bizMulBasicInfo.Add_Mul_Basic_Info(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, MaxEstEmpCnt, MidEstEmpCnt, MinEstEmpCnt, gUserInfo.Emp_Ref_ID);
    }


    protected void SetEstCntRangeDefault()
    {
        this.txtMaxEstEmpCnt.Value = 1;
        this.txtMidEstEmpCnt.Value = 1;
        this.txtMinEstEmpCnt.Value = 1;
    }


    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridBinding(COMP_ID);
    }
    /*
    protected void ibnCheckID_Click(object sender, ImageClickEventArgs e)
    {
        //if ( txtEstTermSubID.Text.Trim().Length == 0 )
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript( "평가주기ID를 입력해주세요." );
        //    return;
        //}

        //int intEstTermSubID     = DataTypeUtility.GetToInt32(txtEstTermSubID.Text);
        //Biz_TermSubs termSubs   = new Biz_TermSubs();
        //bool bDuplicate         = termSubs.IsExist(COMP_ID, intEstTermSubID );

        //if (bDuplicate)
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("존재하는 평가주기 ID가 있습니다.");
        //}
        //else
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("사용가능한 평가주기 ID 입니다.");
        //}
    }
    */
    /*
    private void DoBindingDept()
    {
        MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo bizComDeptInfo = new MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo();

        DataTable dtComDeptInfo = bizComDeptInfo.GetAllList().Tables[0];

        UltraWebGrid1.DataSource = dtComDeptInfo;
        UltraWebGrid1.DataBind();
    }
    */
    /*
    private void GridBinding(int comp_id)
    {
        Biz_TermSubs termSubs = new Biz_TermSubs();
        DataSet ds = termSubs.GetTermSubs(comp_id, "");

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        //lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
    }
    */
    /*
    private void ViewOne(int comp_id, int estterm_sub_id)
    {
        Biz_TermSubs termSub = new Biz_TermSubs(comp_id, estterm_sub_id);

        //txtEstTermSubID.Text   = termSub.EstTerm_Sub_ID.ToString();
        //txtEstTermSubName.Text = termSub.EstTerm_Sub_Name;
        //txtWeight.Text         = DataTypeUtility.GetValue(termSub.Weight);
        //ckbYearYN.Checked      = DataTypeUtility.GetYNToBoolean(termSub.Year_YN);
        //txtSortOrder.Text      = DataTypeUtility.GetValue(termSub.Sort_Order);
        //ckbUseYN.Checked       = DataTypeUtility.GetYNToBoolean(termSub.Use_YN);
        //txtStartMonth.Text     = DataTypeUtility.GetValue(termSub.Start_Month);
        //txtEndMonth.Text       = DataTypeUtility.GetValue(termSub.End_Month);

        hdfEstTermSubID.Value = estterm_sub_id.ToString();
    }
    */
}