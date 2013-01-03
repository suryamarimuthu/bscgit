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
using System.Transactions;

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;

public partial class EST_EST0601S1 : EstPageBase
{
    private int ROLE_REF_ID     = 7;
    private string EST_ID       = "";
    private Biz_EmpEstTargetMaps _empEstTargetMap = null;
    private string DIRECTION_TYPE = "DN";

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _empEstTargetMap = new Biz_EmpEstTargetMaps();

        if (!Page.IsPostBack)
        {
            EST_JOB_ID = "JOB_17";

            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "-----", "");
            DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "-----", "");
            RadioButtonListCommom.BindDirectionType(rblDirectionType);
            RadioButtonListCommom.BindConfirmAllAndPart(rblConfirmAllAndPart);

            TreeViewCommom.BindEst(treeEstList, WebUtility.GetIntByValueDropDownList(ddlCompID));

            ibnSearch.Attributes.Add("onclick", "return Search();");
            ibnConfirmCancel.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");
            ibnUpdateEmpRole.Attributes.Add("onclick", "return confirm('현재 세팅된 평가자에게 평가자 권한을 모두 부여하시겠습니까?');");
            ibnConfirm.Attributes.Add("onclick", "return ConfirmMsg()");
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID          = hdfSearchEstID.Value;
        ESTTERM_REF_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
        DIRECTION_TYPE  = WebUtility.GetByValueRadioButtonList(rblDirectionType);

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        rblConfirmAllAndPart.Visible = ibnConfirm.Visible;
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindingData(COMP_ID, EST_ID, ESTTERM_REF_ID);
    }

    private void BindingData(int comp_id, string est_id, int estterm_ref_id) 
    {
        if(est_id.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가를 선택하세요.");
            return;
        }

        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        if(!estInfo.IsExists(comp_id, est_id))
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 회사의 평가정보가 없습니다.");
            return;
        }

        // 상향평가 여부에 따라...
        if(DataTypeUtility.GetYNToBoolean(estInfo.Fixed_Weight_Use_YN))
        {
            rblDirectionType.Visible = true;
            WebUtility.FindByValueRadioButtonList(rblDirectionType, "DN");
        }
        else 
        {
            rblDirectionType.Visible = false;
            WebUtility.FindByValueRadioButtonList(rblDirectionType, "DN");
        }

        DropDownListCommom.BindEstTermSub(ddlEstTermSubID, comp_id, est_id, "");
        if (ddlEstTermSubID.Items.Count == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가주기가 설정되지 않았습니다.");
            TreeView1.Nodes.Clear();
            TreeGrid_1.Controls.Clear();
            TreeView2.Nodes.Clear();
            TreeGrid_2.Controls.Clear();
            DataGrid1.Controls.Clear();
            DataGrid2.Controls.Clear();
            ibnConfirm.Visible = ibnConfirmCancel.Visible = false;
            return;
        }

        DropDownListCommom.BindEstTermStep(ddlEstTermStepID, comp_id, est_id, "N");

        if (ddlEstTermStepID.Items.Count > 0)
        {
            ddlEstTermStepID.SelectedIndex = 0;
            ESTTERM_STEP_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermStepID);
        }

        OwnerTypeMode = BizUtility.GetOwnerType(estInfo.Owner_Type);

        if(OwnerTypeMode == OwnerType.Dept) 
        {
            DataGrid2.DataKeyField  = "TGT_DEPT_ID";
            TreeGrid_2.Visible      = false;
        }
        else if(OwnerTypeMode == OwnerType.Emp_User) 
        {
            OwnerTypeMode           = OwnerType.Emp_User;
            DataGrid2.DataKeyField  = "TGT_EMP_ID";
            TreeGrid_2.Visible      = true;
        }

        if (ddlEstTermRefID.Items.Count > 0)
        {
            TreeViewCommom.BindDept(TreeView1);

            if(OwnerTypeMode == OwnerType.Dept) 
            {
                TreeViewCommom.BindDept(TreeView2, true, TreeNodeSelectAction.None, "");

                TreeView1.ExpandAll();
                TreeView2.ExpandAll();

                DataTable dtLeft        = CreateSessionData("TreeLeft");

                TreeGrid_1.DataSource   = dtLeft;
                TreeGrid_1.DataBind();
                ViewState["TreeLeft"]   = dtLeft;
            }
            else if(OwnerTypeMode == OwnerType.Emp_User) 
            {
                TreeViewCommom.BindDept(TreeView2);

                TreeView1.ExpandAll();
                TreeView2.ExpandAll();

                DataTable dtLeft        = CreateSessionData("TreeLeft");
                DataTable dtRight       = CreateSessionData("TreeRight");

                TreeGrid_1.DataSource   = dtLeft;
                TreeGrid_1.DataBind();
                TreeGrid_2.DataSource   = dtRight;
                TreeGrid_2.DataBind();
                ViewState["TreeLeft"]   = dtLeft;
                ViewState["TreeRight"]  = dtRight;
            }
        }

        //ibnConfirm.Visible      = true;
        imgEstTgtMap.Visible     = true;
        ibnUpdateEmpRole.Visible = true;

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);
    }

    private int GetNewEstTermStepID(DataTable oldDT)
    {
        DataView dw     = oldDT.DefaultView;
        dw.Sort         = "ESTTERM_STEP_ID";

        DataTable dtEstTermStep = GetEstTermStepData(COMP_ID, hdfSearchEstID.Value);

        foreach(DataRow dataRow in dw.Table.Rows) 
        {
            dtEstTermStep = DataTypeUtility.FilterSortDataTable(dtEstTermStep
                                                            , string.Format("ESTTERM_STEP_ID <> {0}", dataRow["ESTTERM_STEP_ID"])
                                                            , "ESTTERM_STEP_ID");
        }

        if(dtEstTermStep.Rows.Count == 0)
            return -1;

        return DataTypeUtility.GetToInt32(dtEstTermStep.Rows[0]["ESTTERM_STEP_ID"]);

        //for(int i = 0; i < dtEstTermStep.Rows.Count; i++) 
        //{
        //    for(int k = 0; k < dw.Table.Rows.Count; k++) 
        //    {
        //        int estterm_step_id_org = DataTypeUtility.GetToInt32(dtEstTermStep.Rows[i]["ESTTERM_STEP_ID"]);
        //        int estterm_step_id_old = DataTypeUtility.GetToInt32(dw.Table.Rows[k]["ESTTERM_STEP_ID"]);

        //        if(estterm_step_id_org <= estterm_step_id_old) 
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            return estterm_step_id_org;
        //        }
        //    }
        //}

        //return ESTTERM_STEP_ID;
    }

    // DataTable 생성
    private DataTable CreateSessionData(string treeName)
    {
        DataTable dt    = new DataTable();
        string prefix   = "";

        if(treeName.Equals("TreeLeft"))
        {
            prefix = "EST_";
        }
        else if(treeName.Equals("TreeRight"))
        {
            prefix = "TGT_";
        }

        dt.Columns.Add(prefix + "DEPT_ID", typeof(int));
        dt.Columns.Add(prefix + "DEPT_NAME", typeof(string));
        dt.Columns.Add(prefix + "EMP_ID", typeof(int));
        dt.Columns.Add(prefix + "EMP_NAME", typeof(string));
        dt.Columns.Add(prefix + "POS_CLS_ID", typeof(string));
        dt.Columns.Add(prefix + "POS_CLS_NAME", typeof(string));
        dt.Columns.Add(prefix + "POS_DUT_ID", typeof(string));
        dt.Columns.Add(prefix + "POS_DUT_NAME", typeof(string));
        dt.Columns.Add(prefix + "POS_GRP_ID", typeof(string));
        dt.Columns.Add(prefix + "POS_GRP_NAME", typeof(string));
        dt.Columns.Add(prefix + "POS_RNK_ID", typeof(string));
        dt.Columns.Add(prefix + "POS_RNK_NAME", typeof(string));
        dt.Columns.Add(prefix + "POS_KND_ID", typeof(string));
        dt.Columns.Add(prefix + "POS_KND_NAME", typeof(string));
        dt.Columns.Add("ESTTERM_STEP_ID", typeof(int));
        dt.Columns.Add("ESTTERM_STEP_NAME", typeof(string));

        return dt;
    }
    // DataTable Reset (초기화)
    private void RemoveSessionData(string viewStatName)
    {
        ViewState[viewStatName] = CreateSessionData(viewStatName);
    }
    // emp_ref_id 에 해당하는 DataRow 삭제
    private DataTable RemoveAtSessionDataByEmp(string viewStatName, int emp_ref_id)
    {
        DataTable oldDT = (DataTable)ViewState[viewStatName];
        string prefix   = GetPreFix(viewStatName);

        for (int i = 0; i < oldDT.Rows.Count; i++)
        {
            string oldEmpID = oldDT.Rows[i][prefix + "EMP_ID"].ToString();

            if (oldEmpID.Equals(emp_ref_id.ToString()))
            {
                oldDT.Rows[i].Delete();
            }
        }

        return oldDT;
    }

    private DataTable RemoveAtSessionDataByDept(string viewStatName, int dept_ref_id)
    {
        DataTable oldDT = (DataTable)ViewState[viewStatName];
        string prefix   = GetPreFix(viewStatName);

        for (int i = 0; i < oldDT.Rows.Count; i++)
        {
            string oldEmpID = oldDT.Rows[i][prefix + "DEPT_ID"].ToString();

            if (oldEmpID.Equals(dept_ref_id.ToString()))
            {
                oldDT.Rows[i].Delete();
            }
        }

        return oldDT;
    }

    // 특정 DataTable Return
    private DataTable GetSessionData(string viewStatName)
    {
        if (((DataTable)ViewState[viewStatName]) == null)
            return null;

        DataView dw = ((DataTable)ViewState[viewStatName]).DefaultView;
        dw.Sort     = "ESTTERM_STEP_ID";

        return dw.Table;
    }
    // DataRow 추가
    private DataTable AddSessionData( string viewStatName
                                    , int emp_ref_id
                                    , int dept_ref_id
                                    , string emp_name
                                    , string dept_name
                                    , string pos_cls_id
                                    , string pos_cls_name
		                            , string pos_dut_id
                                    , string pos_dut_name
		                            , string pos_grp_id
                                    , string pos_grp_name
		                            , string pos_rnk_id
		                            , string pos_rnk_name
                                    , string pos_knd_id
		                            , string pos_knd_name)
    {
        return AddSessionData(viewStatName
                            , emp_ref_id
                            , dept_ref_id
                            , emp_name
                            , dept_name
                            , pos_cls_id
                            , pos_cls_name
                            , pos_dut_id
                            , pos_dut_name
                            , pos_grp_id
                            , pos_grp_name
                            , pos_rnk_id
                            , pos_rnk_name
                            , pos_knd_id
                            , pos_knd_name
                            , 0);
    }
    private DataTable AddSessionData( string viewStatName
                                    , int emp_ref_id
                                    , int dept_ref_id
                                    , string emp_name
                                    , string dept_name
                                    , string pos_cls_id
                                    , string pos_cls_name
		                            , string pos_dut_id
                                    , string pos_dut_name
		                            , string pos_grp_id
                                    , string pos_grp_name
		                            , string pos_rnk_id
		                            , string pos_rnk_name
                                    , string pos_knd_id
		                            , string pos_knd_name
                                    , int estterm_step_id)
    {
        DataTable dtEstTermStep = GetEstTermStepData(COMP_ID, EST_ID);

        if (ViewState[viewStatName] == null)
        {
            ViewState[viewStatName] = CreateSessionData(viewStatName);
        }

        DataTable oldDT = (DataTable)ViewState[viewStatName];

        if (oldDT.Rows.Count >= dtEstTermStep.Rows.Count && viewStatName.Equals("TreeLeft"))
        {
            if(ddlEstTermStepID.Items.Count == 0) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("해당 평가에 설정된 차수가 없습니다. 평가관리에서 차수를 설정해주세요.");
            }
            else 
            {
                ltrScript.Text = JSHelper.GetAlertScript(string.Format("평가자는 {0} 까지 설정할 수 있습니다.", ddlEstTermStepID.Items[ddlEstTermStepID.Items.Count - 1].Text));
            }
            
            return null;
        }

        DataTable dt                = CreateSessionData(viewStatName);
        DataRow dr;
        string prefix               = GetPreFix(viewStatName);
        Biz_TermSteps termStep      = null;

        dr                          = dt.NewRow();
        dr[prefix + "EMP_ID"]       = emp_ref_id;
        dr[prefix + "EMP_NAME"]     = emp_name;
        dr[prefix + "DEPT_ID"]      = dept_ref_id;
        dr[prefix + "DEPT_NAME"]    = dept_name;
        dr[prefix + "POS_CLS_ID"]   = pos_cls_id;
        dr[prefix + "POS_CLS_NAME"] = pos_cls_name;
        dr[prefix + "POS_DUT_ID"]   = pos_dut_id;
        dr[prefix + "POS_DUT_NAME"] = pos_dut_name;
        dr[prefix + "POS_GRP_ID"]   = pos_grp_id;
        dr[prefix + "POS_GRP_NAME"] = pos_grp_name;
        dr[prefix + "POS_KND_ID"]   = pos_knd_id;
        dr[prefix + "POS_KND_NAME"] = pos_knd_name;

        /* 2011-08-01 수정 시작 : 평가자에 대해서 피평가자를 2인 이상할당시 메세지가 표시되는 현상 방지를 위해 주석처리
        if (estterm_step_id == 0)
        {
            estterm_step_id         = GetNewEstTermStepID(oldDT);

            if(estterm_step_id == -1) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("해당평가에 해당하는 차수가 모두 매핑되어 있습니다.");
                return null;
            }

            dr["ESTTERM_STEP_ID"]   = estterm_step_id;

            termStep                = new Biz_TermSteps(COMP_ID, estterm_step_id);
            dr["ESTTERM_STEP_NAME"] = termStep.EstTerm_Step_Name;
        }
        else
        {
            dr["ESTTERM_STEP_ID"]   = estterm_step_id;

            termStep                = new Biz_TermSteps(COMP_ID, estterm_step_id);
            dr["ESTTERM_STEP_NAME"] = termStep.EstTerm_Step_Name;
        }
        */

        // 위에꺼 뭐지? 위에 주석처리 되있어서 step id 가 0이 들어가잖아.ㅠㅠ
        dr["ESTTERM_STEP_ID"] = estterm_step_id;
        termStep = new Biz_TermSteps(COMP_ID, estterm_step_id);
        dr["ESTTERM_STEP_NAME"] = termStep.EstTerm_Step_Name;

        dt.Rows.Add(dr);

        bool isDuplicated = false;

        if(OwnerTypeMode == OwnerType.Emp_User) 
        {
            for (int i = 0; i < oldDT.Rows.Count; i++)
            {
                string oldEmpID = oldDT.Rows[i][prefix + "EMP_ID"].ToString();

                if (oldEmpID.Equals(emp_ref_id.ToString()))
                {
                    isDuplicated = true;
                }
            }
        }
        else if(OwnerTypeMode == OwnerType.Dept) 
        {
            for (int i = 0; i < oldDT.Rows.Count; i++)
            {
                string oldEmpID = oldDT.Rows[i][prefix + "DEPT_ID"].ToString();

                if (oldEmpID.Equals(dept_ref_id.ToString()))
                {
                    isDuplicated = true;
                }
            }
        }

        if (!isDuplicated)
            oldDT.Merge(dt);

        ViewState[viewStatName] = oldDT;
        return oldDT;
    }

    // TreeView가 선택되었을 경우
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeView treeView       = (TreeView)sender;
        int dept_ref_id         = DataTypeUtility.GetToInt32(treeView.SelectedValue);

        Biz_EmpInfos empInfo    = new Biz_EmpInfos();

        if (treeView.ID.Equals("TreeView1"))
        {
            TreeGrid_1.DataSource = empInfo.GetEmpByEstDeptIDWithPrefix(dept_ref_id, "EST_");
            TreeGrid_1.DataBind();
        }
        else if (treeView.ID.Equals("TreeView2"))
        {
            TreeGrid_2.DataSource = empInfo.GetEmpByEstDeptIDWithPrefix(dept_ref_id, "TGT_");
            TreeGrid_2.DataBind();
        }
    }
    // 성과 DropDownList의 선택이 바뀌었을 경우
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeView1.Nodes.Clear();
        TreeView2.Nodes.Clear();
        TreeViewCommom.BindDept(TreeView1);

        if(OwnerTypeMode == OwnerType.Dept) 
        {
            TreeViewCommom.BindDept(TreeView2, true, TreeNodeSelectAction.None, "");
        }
        else if(OwnerTypeMode == OwnerType.Emp_User) 
        {
            TreeViewCommom.BindDept(TreeView2);
        }

        TreeView1.ExpandAll();
        TreeView2.ExpandAll();

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);
    }
    protected void ddlEstTermSub_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeView1.Nodes.Clear();
        TreeView2.Nodes.Clear();
        TreeViewCommom.BindDept(TreeView1);

        if(OwnerTypeMode == OwnerType.Dept) 
        {
            TreeViewCommom.BindDept(TreeView2, true, TreeNodeSelectAction.None, "");
        }
        else if(OwnerTypeMode == OwnerType.Emp_User) 
        {
            TreeViewCommom.BindDept(TreeView2);
        }

        TreeView1.ExpandAll();
        TreeView2.ExpandAll();

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);
    }
    protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeView1.Nodes.Clear();
        TreeView2.Nodes.Clear();
        TreeViewCommom.BindDept(TreeView1);

        if(OwnerTypeMode == OwnerType.Dept) 
        {
            TreeViewCommom.BindDept(TreeView2, true, TreeNodeSelectAction.None, "");
        }
        else if(OwnerTypeMode == OwnerType.Emp_User) 
        {
            TreeViewCommom.BindDept(TreeView2);
        }

        TreeView1.ExpandAll();
        TreeView2.ExpandAll();

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);
    }
    // 추가 버튼이 클릭되었을 때
    protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton iBtnAdd = (ImageButton)sender;
        DataGrid treeGrid   = null;
        DataGrid dataGrid   = null;
        string treeName     = null;
        string index        = null;

        CheckBox chk;
        DataTable dt        = new DataTable();
        bool isSuccessed    = false;

        if (iBtnAdd.ID.Equals("iBtnAdd_1"))
        {
            treeGrid    = TreeGrid_1;
            dataGrid    = DataGrid1;
            treeName    = "TreeLeft";
            index       = "1";

            for (int i = 0; i < treeGrid.Items.Count; i++)
            {
                chk             = treeGrid.Items[i].Cells[0].FindControl("cBox_" + index) as CheckBox;

                if (chk.Checked)
                {
                    isSuccessed = true;

                    dt = AddSessionData(  treeName
                                        , DataTypeUtility.GetToInt32(treeGrid.DataKeys[treeGrid.Items[i].ItemIndex])
                                        , DataTypeUtility.GetToInt32(treeGrid.Items[i].Cells[3].Text)
                                        , treeGrid.Items[i].Cells[2].Text
                                        , treeGrid.Items[i].Cells[4].Text
                                        , treeGrid.Items[i].Cells[5].Text
                                        , treeGrid.Items[i].Cells[6].Text
                                        , treeGrid.Items[i].Cells[7].Text
                                        , treeGrid.Items[i].Cells[8].Text
                                        , treeGrid.Items[i].Cells[9].Text
                                        , treeGrid.Items[i].Cells[10].Text
                                        , treeGrid.Items[i].Cells[11].Text
                                        , treeGrid.Items[i].Cells[12].Text
                                        , treeGrid.Items[i].Cells[13].Text
                                        , treeGrid.Items[i].Cells[14].Text
                                        , WebUtility.GetIntByValueDropDownList(ddlEstTermStepID)
                                        );

                    if(dt == null)
                        return;

                    chk.Checked = false;
                }
            }

            DataTable dtLeft    = GetSessionData("TreeLeft");
            DataTable dtRight   = GetSessionData("TreeRight");

            if (dtLeft == null || dtRight == null)
                return;

            // 잠시 뒤에...
            for (int k = 0; k < dtLeft.Rows.Count; k++)
            {
                for (int j = 0; j < dtRight.Rows.Count; j++)
                {
                    isSuccessed = _empEstTargetMap.AddEmpEstTargetMap(COMP_ID
                                                                    , EST_ID
                                                                    , ESTTERM_REF_ID 
                                                                    , ESTTERM_SUB_ID
                                                                    , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["ESTTERM_STEP_ID"])
                                                                    , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["EST_DEPT_ID"])
                                                                    , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["EST_EMP_ID"])
                                                                    , DataTypeUtility.GetToInt32(dtRight.Rows[j]["TGT_DEPT_ID"])
                                                                    , DataTypeUtility.GetToInt32(dtRight.Rows[j]["TGT_EMP_ID"])
                                                                    , dtRight.Rows[j]["TGT_POS_CLS_ID"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_CLS_NAME"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_DUT_ID"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_DUT_NAME"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_GRP_ID"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_GRP_NAME"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_RNK_ID"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_RNK_NAME"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_KND_ID"].ToString()
                                                                    , dtRight.Rows[j]["TGT_POS_KND_NAME"].ToString()
                                                                    , WebUtility.GetByValueRadioButtonList(rblDirectionType)
                                                                    , "E"
                                                                    , DateTime.Now
                                                                    , EMP_REF_ID);

                    if(!isSuccessed)
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("평가자 설정 중 존재하는 평가자가 있습니다. 평가차수에 따른 평가자를 확인해주세요.", false);
                        return;
                    }
                    else
                    {
                        dataGrid.DataSource = dt;
                        dataGrid.DataBind();

                        if (iBtnAdd.ID.Equals("iBtnAdd_1"))
                        {
                            SetCount(dt, lblEst_1_Cnt);
                        }
                        else if (iBtnAdd.ID.Equals("iBtnAdd_2"))
                        {
                            SetCount(dt, lblEst_2_Cnt);
                        }
                    }
                }
            }
        }
        else if (iBtnAdd.ID.Equals("iBtnAdd_2"))
        {
            if (EST_ID == "3GA") //직접평가하는 MBO의 경우 추가하려는 피평가자가 MBO가중치 및 결재가 되어있는지 확인한다.
            {
                for (int i = 0; i < TreeGrid_2.Items.Count; i++)
                {
                    chk = TreeGrid_2.Items[i].Cells[0].FindControl("cBox_" + 2) as CheckBox;
                    if (chk.Checked)
                    {
                        int target_ref_id = DataTypeUtility.GetToInt32(TreeGrid_2.DataKeys[TreeGrid_2.Items[i].ItemIndex]);
                        Biz_Datas biz = new Biz_Datas();
                        int rtnValue = biz.ConfirmMBOMapable(COMP_ID
                                                        , EST_ID
                                                        , ESTTERM_REF_ID
                                                        , ESTTERM_SUB_ID
                                                        , ESTTERM_STEP_ID
                                                        , target_ref_id);
                        switch (rtnValue)
                        {
                            case 1:
                                ltrScript.Text = JSHelper.GetAlertScript(TreeGrid_2.Items[i].Cells[2].Text.ToString() + "님의 가중치가 설정된 MBO가 없습니다.");
                                chk.Checked = false;
                                return;
                            case 2:
                                ltrScript.Text = JSHelper.GetAlertScript(TreeGrid_2.Items[i].Cells[2].Text.ToString() + "님은 이미 해당차수에 매핑되어있습니다.");
                                chk.Checked = false;
                                return;
                            default:
                                break;
                        }
                    }
                }
            }

            treeGrid    = TreeGrid_2;
            dataGrid    = DataGrid2;
            treeName    = "TreeRight";
            index       = "2";

            DataTable dtLeft    = GetSessionData("TreeLeft");

            // 선택된 평가에서 
            if(OwnerTypeMode == OwnerType.Emp_User) 
            {
                DataTable dtRight   = GetSessionData("TreeRight");

                for (int i = 0; i < treeGrid.Items.Count; i++)
                {
                    chk = treeGrid.Items[i].Cells[0].FindControl("cBox_" + index) as CheckBox;

                    if (chk.Checked)
                    {
                        isSuccessed         = true;

                        int target_ref_id   = DataTypeUtility.GetToInt32(treeGrid.DataKeys[treeGrid.Items[i].ItemIndex]);
                        int target_dept_id  = DataTypeUtility.GetToInt32(treeGrid.Items[i].Cells[3].Text);

                        dt = AddSessionData(  treeName
                                            , target_ref_id
                                            , target_dept_id
                                            , treeGrid.Items[i].Cells[2].Text
                                            , treeGrid.Items[i].Cells[4].Text
                                            , treeGrid.Items[i].Cells[5].Text
                                            , treeGrid.Items[i].Cells[6].Text
                                            , treeGrid.Items[i].Cells[7].Text
                                            , treeGrid.Items[i].Cells[8].Text
                                            , treeGrid.Items[i].Cells[9].Text
                                            , treeGrid.Items[i].Cells[10].Text
                                            , treeGrid.Items[i].Cells[11].Text
                                            , treeGrid.Items[i].Cells[12].Text
                                            , treeGrid.Items[i].Cells[13].Text
                                            , treeGrid.Items[i].Cells[14].Text
                                            );

                        for (int k = 0; k < dtLeft.Rows.Count; k++)
                        {
                            bool isOK = _empEstTargetMap.AddEmpEstTargetMap(  COMP_ID
                                                                            , EST_ID
                                                                            , ESTTERM_REF_ID 
                                                                            , ESTTERM_SUB_ID
                                                                            , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["ESTTERM_STEP_ID"])
                                                                            , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["EST_DEPT_ID"])
                                                                            , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["EST_EMP_ID"])
                                                                            , target_dept_id
                                                                            , target_ref_id
                                                                            , treeGrid.Items[i].Cells[5].Text
                                                                            , treeGrid.Items[i].Cells[6].Text
                                                                            , treeGrid.Items[i].Cells[7].Text
                                                                            , treeGrid.Items[i].Cells[8].Text
                                                                            , treeGrid.Items[i].Cells[9].Text
                                                                            , treeGrid.Items[i].Cells[10].Text
                                                                            , treeGrid.Items[i].Cells[11].Text
                                                                            , treeGrid.Items[i].Cells[12].Text
                                                                            , treeGrid.Items[i].Cells[13].Text
                                                                            , treeGrid.Items[i].Cells[14].Text
                                                                            , WebUtility.GetByValueRadioButtonList(rblDirectionType)
                                                                            , "E"
                                                                            , DateTime.Now
                                                                            , EMP_REF_ID);

                            if(!isOK) 
                            {
                                ltrScript.Text = JSHelper.GetAlertScript("평가자 설정 중 존재하는 평가자가 있습니다. 평가차수에 따른 평가자를 확인해주세요.", false);
                                return;
                            }


                            //}
                            //catch
                            //{
                            //    ltrScript.Text = JSHelper.GetAlertScript("평가자 설정 중 존재하는 평가자가 있습니다. 평가차수에 따른 평가자를 확인해주세요.", false);
                            //    return;
                            //}
                        }

                        chk.Checked = false;
                    }
                }
            }
            else if(OwnerTypeMode == OwnerType.Dept) //******************************* 부서를 평가하게 되는 평가
            {
                for(int i = 0; i < TreeView2.CheckedNodes.Count; i++) 
                {
                    for (int k = 0; k < dtLeft.Rows.Count; k++)
                    {
                        bool isOK = _empEstTargetMap.AddEmpEstTargetMap(  COMP_ID
                                                                        , EST_ID
                                                                        , ESTTERM_REF_ID 
                                                                        , ESTTERM_SUB_ID
                                                                        , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["ESTTERM_STEP_ID"])
                                                                        , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["EST_DEPT_ID"])
                                                                        , DataTypeUtility.GetToInt32(dtLeft.Rows[k]["EST_EMP_ID"])
                                                                        , DataTypeUtility.GetToInt32(TreeView2.CheckedNodes[i].Value)
                                                                        , -1
                                                                        , ""
                                                                        , ""
                                                                        , ""
                                                                        , ""
                                                                        , ""
                                                                        , ""
                                                                        , ""
                                                                        , ""
                                                                        , ""
                                                                        , ""
                                                                        , WebUtility.GetByValueRadioButtonList(rblDirectionType)
                                                                        , "E"
                                                                        , DateTime.Now
                                                                        , EMP_REF_ID);



                        dt = AddSessionData(  "TreeRight"
                                            , -1
                                            , DataTypeUtility.GetToInt32(TreeView2.CheckedNodes[i].Value)
                                            , ""
                                            , TreeView2.CheckedNodes[i].Text
                                            , ""
                                            , ""
                                            , ""
                                            , ""
                                            , ""
                                            , ""
                                            , ""
                                            , ""
                                            , ""
                                            , ""
                                            );


                        if(!isOK) 
                        {
                            ltrScript.Text = JSHelper.GetAlertScript("평가자 설정 중 존재하는 부서가 있습니다. 평가차수에 따른 부서를 확인해주세요.");
                            return;
                        }
                    }
                }

                TreeViewCommom.BindDept(TreeView2, true, TreeNodeSelectAction.None, "");
            }

            DataGrid2.DataSource = dt;
            DataGrid2.DataBind();

            if (iBtnAdd.ID.Equals("iBtnAdd_1"))
            {
                SetCount(dt, lblEst_1_Cnt);
            }
            else if (iBtnAdd.ID.Equals("iBtnAdd_2"))
            {
                SetCount(dt, lblEst_2_Cnt);
            }
        }
    }

    protected void DataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.CommandName.Equals("Delete"))
            {
                DataGrid dataGrid = (DataGrid)source;

                if (dataGrid.ID.Equals("DataGrid1"))
                {
                    int est_ref_if      = DataTypeUtility.GetToInt32(dataGrid.DataKeys[e.Item.ItemIndex].ToString());
                    DataTable dt        = RemoveAtSessionDataByEmp("TreeLeft", est_ref_if);
                    dataGrid.DataSource = dt;
                    dataGrid.DataBind();

                    SetCount(dt, lblEst_1_Cnt);

                    DataTable dtRight = GetSessionData("TreeRight");

                    for (int j = 0; j < dtRight.Rows.Count; j++)
                    {
                        _empEstTargetMap.RemoveEmpEstTargetMap(   COMP_ID
                                                                , EST_ID
                                                                , ESTTERM_REF_ID
                                                                , ESTTERM_SUB_ID
                                                                , 0
                                                                , 0
                                                                , est_ref_if
                                                                , 0
                                                                , DataTypeUtility.GetToInt32(dtRight.Rows[j]["TGT_EMP_ID"]));
                    }
                }
                else if (dataGrid.ID.Equals("DataGrid2"))
                {
                    if(OwnerTypeMode == OwnerType.Emp_User) 
                    {
                        int target_ref_id   = DataTypeUtility.GetToInt32(dataGrid.DataKeys[e.Item.ItemIndex].ToString());
                        DataTable dt        = RemoveAtSessionDataByEmp("TreeRight", target_ref_id);
                        dataGrid.DataSource = dt;
                        dataGrid.DataBind();

                        SetCount(dt, lblEst_2_Cnt);

                        DataTable dtLeft = GetSessionData("TreeLeft");

                        for (int i = 0; i < dtLeft.Rows.Count; i++)
                        {
                            _empEstTargetMap.RemoveEmpEstTargetMap(   COMP_ID
                                                                    , EST_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , DataTypeUtility.GetToInt32(dtLeft.Rows[i]["ESTTERM_STEP_ID"])
                                                                    , 0
                                                                    , DataTypeUtility.GetToInt32(dtLeft.Rows[i]["EST_EMP_ID"])
                                                                    , 0
                                                                    , target_ref_id);
                        }
                    }
                    else if(OwnerTypeMode == OwnerType.Dept) 
                    {
                        int target_dept_id  = int.Parse(dataGrid.DataKeys[e.Item.ItemIndex].ToString());
                        DataTable dt        = RemoveAtSessionDataByDept("TreeRight", target_dept_id);
                        dataGrid.DataSource = dt;
                        dataGrid.DataBind();

                        SetCount(dt, lblEst_2_Cnt);

                        DataTable dtLeft = GetSessionData("TreeLeft");

                        for (int i = 0; i < dtLeft.Rows.Count; i++)
                        {
                            _empEstTargetMap.RemoveEmpEstTargetMap(   COMP_ID
                                                                    , EST_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , DataTypeUtility.GetToInt32(dtLeft.Rows[i]["ESTTERM_STEP_ID"])
                                                                    , 0
                                                                    , DataTypeUtility.GetToInt32(dtLeft.Rows[i]["EST_EMP_ID"])
                                                                    , target_dept_id
                                                                    , 0);
                        }  
                    }
                }
            }
        }
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingData(COMP_ID, EST_ID, ESTTERM_REF_ID);
    }

    protected void DataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        e.Item.Cells[2].Visible     = false;
        e.Item.Cells[3].Visible     = false;
        e.Item.Cells[4].Visible     = false;
        e.Item.Cells[5].Visible     = true;
        e.Item.Cells[6].Visible     = false;
        e.Item.Cells[7].Visible     = false;
        e.Item.Cells[8].Visible     = false;
        e.Item.Cells[9].Visible     = false;
        e.Item.Cells[10].Visible    = false;
        e.Item.Cells[11].Visible    = false;

        if (((DataGrid)sender).ID.Equals("DataGrid2"))
        {
            if(OwnerTypeMode == OwnerType.Dept) 
            {
                e.Item.Cells[0].Visible = false;
                e.Item.Cells[5].Visible = false;
            }
        }
    }

    // Tree Grid의 ItemCommand 이벤트가 발생했을 경우
    protected void TreeGrid_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        // 선택이 클릭되었을 경우
        if (e.CommandName.Equals("Select"))
        {
            DataTable dt        = new DataTable();
            DataGrid treeGrid   = (DataGrid)source;
            int emp_ref_id      = DataTypeUtility.GetToInt32(treeGrid.DataKeys[e.Item.ItemIndex].ToString());

            // TreeGrid_1 이면
            if (treeGrid.ID.Equals("TreeGrid_1"))
            {
                // 모든 TreeLeft 데이터를 Reset
                RemoveSessionData("TreeLeft");
                // TreeLeft 정보에 추가
                dt = AddSessionData(  "TreeLeft"
                                    , emp_ref_id
                                    , DataTypeUtility.GetToInt32(e.Item.Cells[3].Text)
                                    , e.Item.Cells[2].Text
                                    , e.Item.Cells[4].Text
                                    , e.Item.Cells[5].Text
                                    , e.Item.Cells[6].Text
                                    , e.Item.Cells[7].Text
                                    , e.Item.Cells[8].Text
                                    , e.Item.Cells[9].Text
                                    , e.Item.Cells[10].Text
                                    , e.Item.Cells[11].Text
                                    , e.Item.Cells[12].Text
                                    , e.Item.Cells[13].Text
                                    , e.Item.Cells[14].Text
                                    , WebUtility.GetIntByValueDropDownList(ddlEstTermStepID)
                                    );

                DataGrid1.DataSource = dt;
                DataGrid1.DataBind();

                SetCount(dt, lblEst_1_Cnt);

                DataTable dtBiz         = _empEstTargetMap.GetEmpEstTargetMap(COMP_ID
                                                                            , EST_ID
                                                                            , ESTTERM_REF_ID
                                                                            , ESTTERM_SUB_ID
                                                                            , ESTTERM_STEP_ID
                                                                            , 0
                                                                            , emp_ref_id
                                                                            , 0
                                                                            , 0
                                                                            , OwnerTypeMode).Tables[0];

                if(DIRECTION_TYPE.Equals("DN"))
                    dtBiz                = DataTypeUtility.FilterSortDataTable(dtBiz, "FIXED_WEIGHT_YN = 'N'");
                else
                    dtBiz                = DataTypeUtility.FilterSortDataTable(dtBiz, "FIXED_WEIGHT_YN = 'Y'");

                DataGrid2.DataSource    = dtBiz;
                DataGrid2.DataBind();

                SetCount(dtBiz, lblEst_2_Cnt);

                RemoveSessionData("TreeRight");

                for (int i = 0; i < dtBiz.Rows.Count; i++)
                {
                    dt = AddSessionData(  "TreeRight"
                                        , DataTypeUtility.GetToInt32(dtBiz.Rows[i]["TGT_EMP_ID"])
                                        , DataTypeUtility.GetToInt32(dtBiz.Rows[i]["TGT_DEPT_ID"])
                                        , dtBiz.Rows[i]["TGT_EMP_NAME"].ToString()
                                        , dtBiz.Rows[i]["TGT_DEPT_NAME"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_CLS_ID"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_CLS_NAME"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_DUT_ID"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_DUT_NAME"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_GRP_ID"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_GRP_NAME"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_RNK_ID"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_RNK_NAME"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_KND_ID"].ToString()
                                        , dtBiz.Rows[i]["TGT_POS_KND_NAME"].ToString()
                                        );
                }
            }
            else if (treeGrid.ID.Equals("TreeGrid_2"))
            {
                //if (EST_ID == "3GA") //직접평가하는 MBO의 경우 추가하려는 피평가자가 MBO가중치 및 결재가 되어있는지 확인한다.
                //{
                //    Biz_Datas biz = new Biz_Datas();
                //    int rtnValue = biz.ConfirmMBOMapable(COMP_ID
                //                                    , EST_ID
                //                                    , ESTTERM_REF_ID
                //                                    , ESTTERM_SUB_ID
                //                                    , ESTTERM_STEP_ID
                //                                    , emp_ref_id);
                //    switch (rtnValue)
                //    {
                //        case 1:
                //            ltrScript.Text = JSHelper.GetAlertScript(TreeGrid_2.Items[0].Cells[2].Text.ToString() + "님의 가중치가 설정된 MBO가 없습니다.");
                //            return;
                //        case 2:
                //            ltrScript.Text = JSHelper.GetAlertScript(TreeGrid_2.Items[0].Cells[2].Text.ToString() + "님은 이미 해당차수에 매핑되어있습니다.");
                //            return;
                //        default:
                //            break;
                //    }
                //}

                RemoveSessionData("TreeRight");

                dt = AddSessionData( "TreeRight"
                                    , emp_ref_id
                                    , DataTypeUtility.GetToInt32(e.Item.Cells[3].Text)
                                    , e.Item.Cells[2].Text
                                    , e.Item.Cells[4].Text
                                    , e.Item.Cells[5].Text
                                    , e.Item.Cells[6].Text
                                    , e.Item.Cells[7].Text
                                    , e.Item.Cells[8].Text
                                    , e.Item.Cells[9].Text
                                    , e.Item.Cells[10].Text
                                    , e.Item.Cells[11].Text
                                    , e.Item.Cells[12].Text
                                    , e.Item.Cells[13].Text
                                    , e.Item.Cells[14].Text
                                    );

                DataGrid2.DataSource = dt;
                DataGrid2.DataBind();

                SetCount(dt, lblEst_2_Cnt);

                DataTable dtBiz         = _empEstTargetMap.GetEmpEstTargetMap(COMP_ID
                                                                            , EST_ID
                                                                            , ESTTERM_REF_ID
                                                                            , ESTTERM_SUB_ID
                                                                            , 0
                                                                            , 0
                                                                            , 0
                                                                            , 0
                                                                            , emp_ref_id).Tables[0];

                if(DIRECTION_TYPE.Equals("DN"))
                    dtBiz                = DataTypeUtility.FilterSortDataTable(dtBiz, "FIXED_WEIGHT_YN = 'N'");
                else
                    dtBiz                = DataTypeUtility.FilterSortDataTable(dtBiz, "FIXED_WEIGHT_YN = 'Y'");

                DataGrid1.DataSource    = dtBiz;
                DataGrid1.DataBind();

                SetCount(dtBiz, lblEst_1_Cnt);

                RemoveSessionData("TreeLeft");

                for (int i = 0; i < dtBiz.Rows.Count; i++)
                {
                    dt = AddSessionData(  "TreeLeft"
                                        , DataTypeUtility.GetToInt32(dtBiz.Rows[i]["EST_EMP_ID"])
                                        , DataTypeUtility.GetToInt32(dtBiz.Rows[i]["EST_DEPT_ID"])
                                        , dtBiz.Rows[i]["EST_EMP_NAME"].ToString()
                                        , dtBiz.Rows[i]["EST_DEPT_NAME"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_CLS_ID"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_CLS_NAME"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_DUT_ID"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_DUT_NAME"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_GRP_ID"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_GRP_NAME"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_RNK_ID"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_RNK_NAME"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_KND_ID"].ToString()
                                        , dtBiz.Rows[i]["EST_POS_KND_NAME"].ToString()
                                        );
                }
            }
        }
    }
    // Tree Grid 의 ItemBound 되었을 때
    protected void TreeGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        e.Item.Cells[3].Visible     = false;
        e.Item.Cells[5].Visible     = false;
        e.Item.Cells[6].Visible     = false;
        e.Item.Cells[7].Visible     = false;
        e.Item.Cells[8].Visible     = true;
        e.Item.Cells[9].Visible     = false;
        e.Item.Cells[10].Visible    = false;
        e.Item.Cells[11].Visible    = false;
        e.Item.Cells[12].Visible    = false;
        e.Item.Cells[13].Visible    = false;
        e.Item.Cells[14].Visible    = false;
    }

    private void SetCount(DataTable dt, Label lblCount)
    {
        if(dt != null)
            lblCount.Text = dt.Rows.Count.ToString() + " 건";
        else
            lblCount.Text = "";
    }
    
    private DataTable GetEstTermStepData(int comp_id, string est_id) 
    {
        Biz_TermStepEstMaps termStepEstMap = new Biz_TermStepEstMaps();

        if(WebUtility.GetByValueRadioButtonList(rblDirectionType).Equals("DN"))
            return termStepEstMap.GetTermStepEstMap(comp_id, est_id, "N").Tables[0];

        return termStepEstMap.GetTermStepEstMap(comp_id, est_id, "Y").Tables[0];
    }

    private string GetPreFix(string viewName) 
    {
        if(viewName.Equals("TreeLeft")) 
        {
            return "EST_";
        }
        else if(viewName.Equals("TreeRight")) 
        {
            return "TGT_";
        }

        return "";
    }

    protected void ibnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        bool isJobOK = EstJobUtility.SetConfirmButtonVisible( COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_JOB_ID
                                                            , ibnConfirm
                                                            , ibnConfirmCancel
                                                            , "Y"
                                                            , DateTime.Now
                                                            , EMP_REF_ID
                                                            , ltrScript);

        // 만약 이전에 처리하지 않은 작업이 있다면 아래의 내용을 처리하지 못함
        if(!isJobOK)
            return;

        DataTable dataTable = _empEstTargetMap.GetEmpEstTargetMap(COMP_ID
                                                                , EST_ID
                                                                , ESTTERM_REF_ID
                                                                , ESTTERM_SUB_ID
                                                                , 0
                                                                , 0
                                                                , 0
                                                                , 0
                                                                , 0
                                                                , OwnerTypeMode).Tables[0];

        if(DIRECTION_TYPE.Equals("DN"))
            dataTable       = DataTypeUtility.FilterSortDataTable(dataTable, "FIXED_WEIGHT_YN = 'N'");
        else
            dataTable       = DataTypeUtility.FilterSortDataTable(dataTable, "FIXED_WEIGHT_YN = 'Y'");

        dataTable.Columns.Add("DATE", typeof(DateTime));
        dataTable.Columns.Add("USER", typeof(int));

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["DATE"] = DateTime.Now;
            dataRow["USER"] = EMP_REF_ID;
        }

        Biz_Datas biz_data  = new Biz_Datas();
        bool isOK           = false;
        string confirm_type = WebUtility.GetByValueRadioButtonList(rblConfirmAllAndPart);

        if(confirm_type.Equals("PRT")) //부분
            isOK           = biz_data.CopyTgtMapDataToEstData_PART(dataTable, OwnerTypeMode);
        else if(confirm_type.Equals("ALL")) //전체
            isOK           = biz_data.CopyTgtMapDataToEstData_ALL(dataTable, OwnerTypeMode);

        if(isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가자,피평가자 매핑정보를 평가리스트로 설정 및 확정하였습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가정보로 반영되어야할 매핑정보가 없습니다.");
        }
    }

    protected void ibnConfirmCancel_Click(object sender, ImageClickEventArgs e)
    {
        bool isJobOK = EstJobUtility.SetConfirmButtonVisible( COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_JOB_ID
                                                            , ibnConfirm
                                                            , ibnConfirmCancel
                                                            , "N"
                                                            , DateTime.Now
                                                            , EMP_REF_ID
                                                            , ltrScript);

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정을 취소하였습니다.");
    }
    
    protected void ibnUpdateEmpRole_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EmpRoleRels empRoleRel = new Biz_EmpRoleRels();

        DataTable dataTable = _empEstTargetMap.GetEmpEstTargetMap(COMP_ID
                                                                , ""
                                                                , ESTTERM_REF_ID
                                                                , ESTTERM_SUB_ID
                                                                , 0
                                                                , 0
                                                                , 0
                                                                , 0
                                                                , 0
                                                                , OwnerType.All).Tables[0];

        dataTable = DataTypeUtility.GetGroupByDataTable(dataTable, new string[] {"EST_EMP_ID"});

        dataTable.Columns.Add("EMP_REF_ID", typeof(int));
        dataTable.Columns.Add("ROLE_REF_ID", typeof(int));

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["EMP_REF_ID"]   = dataRow["EST_EMP_ID"];
            dataRow["ROLE_REF_ID"]  = ROLE_REF_ID;
        }

        bool isOK = empRoleRel.SaveEmpRoleRel(dataTable, ROLE_REF_ID);

        if(isOK) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가자 권한을 부여하였습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("부여된 권한이 없습니다.");
        }
    }

    // 하향평가인지 상향평가인지
    protected void rblDirectionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string directionType = WebUtility.GetByValueRadioButtonList(rblDirectionType);

        if(directionType.Equals("DN"))
        {
            DropDownListCommom.BindEstTermStep(ddlEstTermStepID, COMP_ID, EST_ID, "N");
        }
        else 
        {
            DropDownListCommom.BindEstTermStep(ddlEstTermStepID, COMP_ID, EST_ID, "Y");
        }
    }


    protected void treeEstList_SelectedNodeChanged(object sender, EventArgs e)
    {
        hdfSearchEstID.Value = treeEstList.SelectedNode.Value;
        ibnSearch_Click(null, null);
    }
}
