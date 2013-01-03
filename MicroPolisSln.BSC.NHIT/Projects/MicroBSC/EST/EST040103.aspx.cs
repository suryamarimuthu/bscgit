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

public partial class EST_EST040103 : EstPageBase
{
    private string EST_ID;

    private string REL_GRP_ID;
    private string REL_GRP_POS_ID;

	protected void Page_Load( object sender, EventArgs e )
	{
		ESTTERM_REF_ID		= WebUtility.GetRequestByInt("ESTTERM_REF_ID");
		EST_ID				= WebUtility.GetRequest("EST_ID");

		if (!IsPostBack)
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindPositionInfo(ddlPosID);
            DropDownListCommom.BindPositionValue(ddlPosValue
                                                , WebUtility.GetByValueDropDownList(ddlPosID));

            ButtonStatusByInit_RelGrpPos();
            ButtonStatusByInit_RelGrp();

            if(!EST_ID.Equals("")) 
            {
                BindingRelGroupInfo(COMP_ID, EST_ID, ESTTERM_REF_ID);
                ibnNewRelGrp.Enabled = true;
            }
            else
            {
                ibnNewRelGrp.Enabled = false;
            }

            CheckPosGrid(COMP_ID, EST_ID);

            ibnDeleteRelGrp.Attributes.Add("onclick", "return ValidRelGrp();");
            ibnSaveRelGrpDept.Attributes.Add("onclick", "return ValidRelGrp();");
            ibnSaveRelGrpPos.Attributes.Add("onclick", "return ValidRelGrp();");
            ibnSaveRelGrpPosData.Attributes.Add("onclick", "return ValidRelGrpPosData();");
            ibnValidCheck.Attributes.Add("onclick", "return confirm('유효성를 체크하시겠습니까?');");
            ibnRelGrpTgtMap.Attributes.Add("onclick", "return confirm('상대평가 그룹에 속하는 부서 or 사원을 상대평가 대상자로 반영하시겠습니까?');");
		}

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        REL_GRP_ID      = hdfRelGrpID.Value;
        REL_GRP_POS_ID  = hdfRelGrpPosID.Value;

		ltrScript.Text  = string.Empty;
	}

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        BindingRelGroupInfo(COMP_ID, EST_ID, ESTTERM_REF_ID);

        ButtonStatusByInit_RelGrpPos();
        ButtonStatusByInit_RelGrp();
    }

    // 상대그룹정보 등록
    //***********************************************************************************

    protected void ibnNewRelGrp_Click(object sender, ImageClickEventArgs e)
    {
        BindingRelGroupInfo(COMP_ID, EST_ID, ESTTERM_REF_ID);
        ButtonStatusByNew_RelGrp();

        //ButtonStatusByInit_RelGrpPos();
        //ClearValueControls_RelGrp();
        //ClearValueControls_RelGrpPos();
        //ClearValueControls_RelGrpDept();
        uwgRelGroupDept.Clear();
        uwgRelGrpPosInfo.Clear();
        uwgRelGrpPosData.Clear();
    }
    protected void ibnSaveRelGrp_Click(object sender, ImageClickEventArgs e)
    {
        Biz_RelGroupInfos relGrpInfo = new Biz_RelGroupInfos();

        if (PageWriteMode == WriteMode.New)
        {
            bool isOK = relGrpInfo.AddRelGroupInfo(COMP_ID
                                                , EST_ID
                                                , ESTTERM_REF_ID
                                                , txtRelGrpName.Text
                                                , txtRelGrpDesc.Text
                                                , DateTime.Now
                                                , EMP_REF_ID);

            if (isOK)
            {
                BindingRelGroupInfo(COMP_ID, EST_ID, ESTTERM_REF_ID);

                ButtonStatusByInit_RelGrp();
                ButtonStatusByInit_RelGrpPos();
                ClearValueControls_RelGrp();
                ClearValueControls_RelGrpPos();
                ClearValueControls_RelGrpDept();
                uwgRelGroupDept.Clear();
                uwgRelGrpPosInfo.Clear();
                uwgRelGrpPosData.Clear();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되지 않았습니다.");
                return;
            }    
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            if (REL_GRP_ID.Equals(""))
            {
                ltrScript.Text = JSHelper.GetAlertScript("");
                return;
            }

            bool isOK = relGrpInfo.ModifyRelGroupInfo(COMP_ID
                                                    , REL_GRP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , txtRelGrpName.Text
                                                    , txtRelGrpDesc.Text
                                                    , DateTime.Now
                                                    , EMP_REF_ID);

            if (isOK)
            {
                BindingRelGroupInfo(COMP_ID, EST_ID, ESTTERM_REF_ID);

                ButtonStatusByInit_RelGrp();
                ButtonStatusByInit_RelGrpPos();
                ClearValueControls_RelGrp();
                ClearValueControls_RelGrpPos();
                ClearValueControls_RelGrpDept();
                uwgRelGroupDept.Clear();
                uwgRelGrpPosInfo.Clear();
                uwgRelGrpPosData.Clear();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 수정되지 않았습니다.");
                return;
            }
        }

        ButtonStatusByInit_RelGrp();
    }
    protected void ibnDeleteRelGrp_Click(object sender, ImageClickEventArgs e)
    {
        Biz_RelGroupInfos relGroupInfo  = new Biz_RelGroupInfos();

        bool isOK                       = relGroupInfo.RemoveRelGroupInfo(COMP_ID, REL_GRP_ID);

        if (isOK)
        {
            BindingRelGroupInfo(COMP_ID, EST_ID, ESTTERM_REF_ID);
            
            ButtonStatusByInit_RelGrp();
            ButtonStatusByInit_RelGrpPos();
            ClearValueControls_RelGrp();
            ClearValueControls_RelGrpPos();
            ClearValueControls_RelGrpDept();
            uwgRelGroupDept.Clear();
            uwgRelGrpPosInfo.Clear();
            uwgRelGrpPosData.Clear();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제가 처리되지 않았습니다.");
            return;
        }
    }

    protected void uwgRelGroup_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        e.Row.Cells.FromKey("EMP_LIST").Value = string.Format("<a href='#' onmousedown=\"ViewEmpList('{0}','{1}','{2}','{3}');\">{4}</a>"
                                                            , COMP_ID.ToString()
                                                            , EST_ID
                                                            , ESTTERM_REF_ID.ToString()
                                                            , e.Row.Cells.FromKey("REL_GRP_ID").Value.ToString()
                                                            , "<img src='../images/icon/gr_po02.gif' boader='0'>");
    }

    protected void uwgRelGroup_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0) 
        {
            string rel_grp_id = e.SelectedRows[0].Cells.FromKey("REL_GRP_ID").Value.ToString();
            hdfRelGrpID.Value = rel_grp_id;

            SelectRelGrpInfo(COMP_ID, rel_grp_id);
            BindingRelGroupDept(COMP_ID, rel_grp_id, EST_ID, ESTTERM_REF_ID);
            BindingRelGroupPosInfo(COMP_ID, rel_grp_id,  EST_ID, ESTTERM_REF_ID);

            ButtonStatusByInit_RelGrpPos();
            ButtonStatusByModify_RelGrp();
        }
    }

    private void BindingRelGroupInfo(int comp_id, string est_id, int estterm_ref_id) 
    {
        Biz_RelGroupInfos relGroupInfo  = new Biz_RelGroupInfos();
        DataSet ds                      = relGroupInfo.GetRelGroupInfo(comp_id, "", est_id, estterm_ref_id);
        uwgRelGroup.DataSource          = ds;
        uwgRelGroup.DataBind();

        //lblRowCount.Text              = ds.Tables[0].Rows.Count.ToString();
    }

    private void CheckPosGrid(int comp_id, string est_id) 
    {
        Biz_EstInfos estInfo    = new Biz_EstInfos(comp_id, est_id);
        OwnerTypeMode           = BizUtility.GetOwnerType(estInfo.Owner_Type);

        if(OwnerTypeMode == OwnerType.Dept) 
        {
            uwgRelGrpPosInfo.Visible    = false;
            uwgRelGrpPosData.Visible    = false;
            trRelPos.Visible            = false;
            trRelPosData.Visible        = false;
        }
    }
    
    private void SelectRelGrpInfo(int comp_id, string rel_grp_id) 
    {
        Biz_RelGroupInfos relGroupInfo  = new Biz_RelGroupInfos(comp_id, rel_grp_id);

        hdfRelGrpID.Value   = relGroupInfo.Rel_Grp_ID;
        txtRelGrpName.Text  = relGroupInfo.Rel_Grp_Name;
        txtRelGrpDesc.Text  = relGroupInfo.Rel_Grp_Desc;
    }

    private void ClearValueControls_RelGrp() 
    {
        hdfRelGrpID.Value   = "";
        txtRelGrpName.Text  = "";
        txtRelGrpDesc.Text  = "";
    }

    private void ButtonStatusByInit_RelGrp() 
    {
        ibnNewRelGrp.Enabled        = true;
        ibnSaveRelGrp.Enabled       = false;
        ibnDeleteRelGrp.Enabled     = false;

        ibnSaveRelGrpDept.Enabled   = false;
        ibnDeleteRelGrpDept.Enabled = false;

        ibnNewRelGrpPos.Enabled     = false;
        ibnSaveRelGrpPos.Enabled    = false;
        ibnDeleteRelGrpPos.Enabled  = false;

        txtRelGrpName.Enabled       = false;
        txtRelGrpDesc.Enabled       = false;

        txtRelGrpName.BackColor     = Color.FromName("#EBEBEB");
        txtRelGrpDesc.BackColor     = Color.FromName("#EBEBEB");

        ClearValueControls_RelGrp();

        ibnSaveRelGrp.ImageUrl      = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode = WriteMode.None;
    }

    private void ButtonStatusByNew_RelGrp() 
    {
        ibnNewRelGrp.Enabled        = true;
        ibnSaveRelGrp.Enabled       = true;
        ibnDeleteRelGrp.Enabled     = false;

        ibnSaveRelGrpDept.Enabled   = false;
        ibnDeleteRelGrpDept.Enabled = false;

        ibnNewRelGrpPos.Enabled     = false;
        ibnSaveRelGrpPos.Enabled    = false;
        ibnDeleteRelGrpPos.Enabled  = false;

        txtRelGrpName.Enabled       = true;
        txtRelGrpDesc.Enabled       = true;

        txtRelGrpName.BackColor     = Color.FromName("#ffffff");
        txtRelGrpDesc.BackColor     = Color.FromName("#ffffff");

        ClearValueControls_RelGrp();

        ibnSaveRelGrp.ImageUrl     = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode = WriteMode.New;
    }

    private void ButtonStatusByModify_RelGrp() 
    {
        ibnNewRelGrp.Enabled        = true;
        ibnSaveRelGrp.Enabled       = true;
        ibnDeleteRelGrp.Enabled     = true;

        ibnSaveRelGrpDept.Enabled   = true;
        ibnDeleteRelGrpDept.Enabled = true;

        txtRelGrpName.Enabled       = true;
        txtRelGrpDesc.Enabled       = true;

        txtRelGrpName.BackColor     = Color.FromName("#ffffff");
        txtRelGrpDesc.BackColor     = Color.FromName("#ffffff");

        ibnNewRelGrpPos.Enabled     = true;
        ibnSaveRelGrpPos.Enabled    = false;
        ibnDeleteRelGrpPos.Enabled  = false;

        ibnSaveRelGrp.ImageUrl       = "../images/btn/b_002.gif";//"수정";

        PageWriteMode = WriteMode.Modify;
    }

    // 상대그룹 부서 등록
    //***********************************************************************************

    private void BindingRelGroupDept(int comp_id, string rel_grp_id, string est_id, int estterm_ref_id) 
    {
        Biz_RelGroupDepts relGrpDept    = new Biz_RelGroupDepts();
        DataSet ds                      = relGrpDept.GetRelGroupDept(comp_id, rel_grp_id, 0, est_id, estterm_ref_id);
        uwgRelGroupDept.DataSource      = ds;
        uwgRelGroupDept.DataBind();

        hdfEstDept.Value                = WebUtility.GetValueForSplit(ds.Tables[0]
                                                                    , "DEPT_REF_ID"
                                                                    , ",");

        txtEstDept.Text                 = WebUtility.GetValueForSplit(ds.Tables[0]
                                                                    , "DEPT_NAME"
                                                                    , ",");
    }

    protected void ibnSaveRelGrpDept_Click(object sender, ImageClickEventArgs e)
    {
        Biz_RelGroupDepts relGrpDept    = new Biz_RelGroupDepts();

        string[] est_dept_values        = hdfEstDept.Value.Split(',');

        bool isOK = relGrpDept.AddRelGroupDept(COMP_ID
                                            , REL_GRP_ID
                                            , est_dept_values
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , DateTime.Now
                                            , EMP_REF_ID);

        if(isOK) 
        {
            BindingRelGroupDept(COMP_ID, REL_GRP_ID, EST_ID, ESTTERM_REF_ID);
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("부서 저장 중 오류가 발생하였습니다.");
        }
    }

    protected void ibnDeleteRelGrpDept_Click(object sender, ImageClickEventArgs e)
    {
        Biz_RelGroupDepts relGrpDept    = new Biz_RelGroupDepts();
        DataTable dataTable             = relGrpDept.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(uwgRelGroupDept
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "DEPT_REF_ID" }
                                                            , dataTable);

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["REL_GRP_ID"]       = REL_GRP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = relGrpDept.RemoveRelGroupDept(dataTable);

        if(isOK) 
        {
            BindingRelGroupDept(COMP_ID, REL_GRP_ID, EST_ID, ESTTERM_REF_ID);
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("부서 저장 중 오류가 발생하였습니다.");
        }
    }

    private void ClearValueControls_RelGrpDept() 
    {
        hdfEstDept.Value = "";
        txtEstDept.Text  = "";
        uwgRelGroupDept.Clear();
    }

    // 상대그룹 직급별 정보 등록
    //***********************************************************************************

    protected void ibnNewRelGrpPos_Click(object sender, ImageClickEventArgs e)
    {
        BindingRelGroupPosInfo(COMP_ID, REL_GRP_ID, EST_ID, ESTTERM_REF_ID);
        ButtonStatusByNew_RelGrpPos();
    }

    protected void ibnSaveRelGrpPos_Click(object sender, ImageClickEventArgs e)
    {
        Biz_RelGroupPositionInfos relGrpPosInfo = new Biz_RelGroupPositionInfos();

        if (REL_GRP_ID.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("");
            return;
        }

        if (PageWriteMode == WriteMode.New)
        {
            bool isOK = relGrpPosInfo.AddRelGroupPosInfo( COMP_ID
                                                        , REL_GRP_ID
                                                        , EST_ID
                                                        , ESTTERM_REF_ID
                                                        , txtRelGrpPosName.Text
                                                        , txtRelGrpPosDesc.Text
                                                        , (ddlOptValue.Enabled) ? WebUtility.GetByValueDropDownList(ddlOptValue) : ""
                                                        , DateTime.Now
                                                        , EMP_REF_ID);

            if (isOK)
            {
                BindingRelGroupPosInfo(COMP_ID, REL_GRP_ID, EST_ID, ESTTERM_REF_ID);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되지 않았습니다.");
                return;
            }    
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            bool isOK = relGrpPosInfo.ModifyRelGroupPosInfo(  COMP_ID
                                                            , REL_GRP_POS_ID
                                                            , REL_GRP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , txtRelGrpPosName.Text
                                                            , txtRelGrpPosDesc.Text
                                                            , (ddlOptValue.Enabled) ? WebUtility.GetByValueDropDownList(ddlOptValue) : ""
                                                            , DateTime.Now
                                                            , EMP_REF_ID);

            if (isOK)
            {
                BindingRelGroupPosInfo(COMP_ID, REL_GRP_ID, EST_ID, ESTTERM_REF_ID);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 수정되지 않았습니다.");
                return;
            }
        }

        ButtonStatusByInit_RelGrpPos();
    }

    protected void iBtnRemoveGroupPosition_Click(object sender, ImageClickEventArgs e)
    {
        Biz_RelGroupPositionInfos relGroupPosInfo   = new Biz_RelGroupPositionInfos();
        DataTable dataTable                         = relGroupPosInfo.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(uwgRelGrpPosInfo
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "REL_GRP_POS_ID" }
                                                            , dataTable);

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["REL_GRP_ID"]       = REL_GRP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
        }

        bool isOK = relGroupPosInfo.RemoveRelGroupPosInfo(dataTable);

        if (isOK)
        {
            BindingRelGroupPosInfo(COMP_ID, REL_GRP_ID, EST_ID, ESTTERM_REF_ID);
            ButtonStatusByInit_RelGrpPos();
            uwgRelGrpPosData.Clear();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제가 처리되지 않았습니다.");
            return;
        }
    }

    protected void uwgRelGrpPos_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0) 
        {
            string rel_grp_pos_id   = e.SelectedRows[0].Cells.FromKey("REL_GRP_POS_ID").Value.ToString();
            hdfRelGrpPosID.Value    = rel_grp_pos_id;
            SelectRelGrpPosInfo(COMP_ID, rel_grp_pos_id);
            BindingRelGroupDept(COMP_ID, REL_GRP_ID, rel_grp_pos_id, EST_ID, ESTTERM_REF_ID);

            ButtonStatusByModify_RelGrpPos();
        }
    }

    private void BindingRelGroupPosInfo(int comp_id, string rel_grp_id,  string est_id, int estterm_ref_id) 
    {
        Biz_RelGroupPositionInfos relGroupPosInfo   = new Biz_RelGroupPositionInfos();
        DataSet ds                                  = relGroupPosInfo.GetRelGroupPosInfo(comp_id, "", rel_grp_id, est_id, estterm_ref_id);
        uwgRelGrpPosInfo.DataSource                 = ds;
        uwgRelGrpPosInfo.DataBind();

        BindOptValue(comp_id, rel_grp_id, est_id, estterm_ref_id);

        //lblRowCount.Text              = ds.Tables[0].Rows.Count.ToString();
    }
    
    private void SelectRelGrpPosInfo(int comp_id, string rel_grp_pos_id) 
    {
        Biz_RelGroupPositionInfos relGroupPosInfo  = new Biz_RelGroupPositionInfos(comp_id, rel_grp_pos_id);

        hdfRelGrpPosID.Value   = relGroupPosInfo.Rel_Grp_Pos_ID;
        txtRelGrpPosName.Text  = relGroupPosInfo.Rel_Grp_Pos_Name;
        txtRelGrpPosDesc.Text  = relGroupPosInfo.Rel_Grp_Pos_Desc;
        WebUtility.FindByValueDropDownList(ddlOptValue, relGroupPosInfo.Opt_Value);

        if(relGroupPosInfo.Opt_Value.Equals(""))
        {
            //ddlOptValue.Enabled = false;
        }
        else 
        {
            //ddlOptValue.Enabled = true;
        }
    }

    private void ClearValueControls_RelGrpPos() 
    {
        hdfRelGrpPosID.Value   = "";
        txtRelGrpPosName.Text  = "";
        txtRelGrpPosDesc.Text  = "";
        uwgRelGrpPosData.Clear();
    }

    private void BindOptValue(int comp_id, string rel_grp_id, string est_id, int estterm_ref_id) 
    {
        Biz_RelGroupPositionInfos relGroupPosInfo   = new Biz_RelGroupPositionInfos();
        bool isContain                              = relGroupPosInfo.IsExist(comp_id
                                                                            , ""
                                                                            , rel_grp_id
                                                                            , est_id
                                                                            , estterm_ref_id);

        if(isContain) 
        {
            WebUtility.FindByValueDropDownList(ddlOptValue, "OR");
            //ddlOptValue.Enabled = true;
        }
        else
        {
            //ddlOptValue.Enabled = false;
        }
    }

    private void ButtonStatusByInit_RelGrpPos() 
    {
        ibnNewRelGrpPos.Enabled         = true;
        ibnSaveRelGrpPos.Enabled        = false;
        ibnDeleteRelGrpPos.Enabled      = true;

        txtRelGrpPosName.Enabled        = false;
        txtRelGrpPosDesc.Enabled        = false;

        txtRelGrpPosName.BackColor      = Color.FromName("#EBEBEB");
        txtRelGrpPosDesc.BackColor      = Color.FromName("#EBEBEB");

        ClearValueControls_RelGrpPos();

        ibnSaveRelGrpPos.ImageUrl      = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode = WriteMode.None;
    }

    private void ButtonStatusByNew_RelGrpPos() 
    {
        //ddlOptValue.Enabled             = (uwgRelGrpPosInfo.Rows.Count > 0);

        ibnNewRelGrpPos.Enabled         = true;
        ibnSaveRelGrpPos.Enabled        = true;
        ibnDeleteRelGrpPos.Enabled      = true;

        txtRelGrpPosName.Enabled        = true;
        txtRelGrpPosDesc.Enabled        = true;

        txtRelGrpPosName.BackColor      = Color.FromName("#ffffff");
        txtRelGrpPosDesc.BackColor      = Color.FromName("#ffffff");

        ClearValueControls_RelGrpPos();

        ibnSaveRelGrpPos.ImageUrl     = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode = WriteMode.New;
    }

    private void ButtonStatusByModify_RelGrpPos() 
    {
        //ddlOptValueData.Enabled = (uwgRelGrpPosData.Rows.Count > 0);

        ibnNewRelGrpPos.Enabled         = true;
        ibnSaveRelGrpPos.Enabled        = true;
        ibnDeleteRelGrpPos.Enabled      = true;

        txtRelGrpPosName.Enabled        = true;
        txtRelGrpPosDesc.Enabled        = true;

        txtRelGrpPosName.BackColor      = Color.FromName("#ffffff");
        txtRelGrpPosDesc.BackColor      = Color.FromName("#ffffff");

        ibnSaveRelGrpPos.ImageUrl       = "../images/btn/b_002.gif";//"수정";

        PageWriteMode = WriteMode.Modify;
    }

    // 상대그룹 직급별 데이터 등록
    //***********************************************************************************

    protected void uwgRelGrpPosData_InitializeRow(object sender, RowEventArgs e)
    {

    }

    private void BindingRelGroupDept(int comp_id, string rel_grp_id, string rel_grp_pos_id, string est_id, int estterm_ref_id) 
    {
        Biz_RelGroupPositionDatas relGrpPosData = new Biz_RelGroupPositionDatas();
        DataSet ds                              = relGrpPosData.GetRelGroupPosData(comp_id
                                                                                , ""
                                                                                , rel_grp_id
                                                                                , rel_grp_pos_id
                                                                                , est_id
                                                                                , estterm_ref_id);
        uwgRelGrpPosData.DataSource             = ds;
        uwgRelGrpPosData.DataBind();
    }

    protected void ibnSaveRelGrpPosData_Click(object sender, ImageClickEventArgs e)
    {
        Biz_RelGroupPositionDatas relGrpPosData = new Biz_RelGroupPositionDatas();
        bool isOK = relGrpPosData.AddRelGroupPosData( COMP_ID
                                                    , REL_GRP_ID
                                                    , REL_GRP_POS_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , WebUtility.GetByValueDropDownList(ddlPosID)
                                                    , WebUtility.GetByTextDropDownList(ddlPosID)
                                                    , WebUtility.GetByValueDropDownList(ddlPosValue)
                                                    , WebUtility.GetByTextDropDownList(ddlPosValue)
                                                    , WebUtility.GetByValueDropDownList(ddlOptValueData)
                                                    , DateTime.Now
                                                    , EMP_REF_ID);

        if(isOK) 
        {
            BindingRelGroupDept(COMP_ID, REL_GRP_ID, REL_GRP_POS_ID, EST_ID, ESTTERM_REF_ID);
            ButtonStatusByModify_RelGrpPos();
        }
        else 
        {
            //ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제가 처리되지 않았습니다.");
            return;
        }
                                            
    }
    protected void ibnDeleteRelGrpPosData_Click(object sender, ImageClickEventArgs e)
    {
        Biz_RelGroupPositionDatas relGrpPosData   = new Biz_RelGroupPositionDatas();
        DataTable dataTable                       = relGrpPosData.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(uwgRelGrpPosData
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "REL_GRP_POS_DATA_ID" }
                                                            , dataTable);

        bool isOK = relGrpPosData.RemoveRelGroupPosData(dataTable);

        if (isOK)
        {
            BindingRelGroupDept(COMP_ID, REL_GRP_ID, REL_GRP_POS_ID, EST_ID, ESTTERM_REF_ID);
            ButtonStatusByModify_RelGrpPos();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제가 처리되지 않았습니다.");
            return;
        }
    }

    private void BindOptValueData() 
    {
        Biz_RelGroupPositionDatas relGrpPosData = new Biz_RelGroupPositionDatas();

        bool contain_all    = relGrpPosData.IsExist(COMP_ID, "", REL_GRP_ID, REL_GRP_POS_ID, EST_ID, ESTTERM_REF_ID, "", "");
        bool contain        = relGrpPosData.IsExist(COMP_ID, "", REL_GRP_ID, REL_GRP_POS_ID, EST_ID, ESTTERM_REF_ID, "", "");

        if (contain_all)
        {
            if (contain)
            {
                WebUtility.FindByValueDropDownList(ddlOptValueData, "OR");
                ddlOptValueData.Visible = true;
                //ddlOptValueData.Enabled = false;
            }
            else
            {
                ddlOptValueData.ClearSelection();
                WebUtility.FindByValueDropDownList(ddlOptValueData, "AND");
                ddlOptValueData.Visible = true;
                //ddlOptValueData.Enabled = true;
            }
        }
        else 
        {
            WebUtility.FindByValueDropDownList(ddlOptValueData, "OR");
            ddlOptValueData.Visible = false;
        }        
    }

    protected void ddlPosID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownListCommom.BindPositionValue(ddlPosValue
                                            , WebUtility.GetByValueDropDownList(ddlPosID));
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ibnValidCheck_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtRelGrpData  = GetRelGroupData(COMP_ID, EST_ID, ESTTERM_REF_ID);
        DataTable dtValid       = null;

        if(dtRelGrpData.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("상대그룹에 포함된 사원정보가 없습니다.");
            return;
        }

        dtValid = DataTypeUtility.GetGroupByDataTable(dtRelGrpData
                                                    , "TGT_EMP_ID"
                                                    , new string[] { "TGT_DEPT_ID", "TGT_EMP_ID" }
                                                    , "TGT_EMP_ID");

        dtValid = DataTypeUtility.FilterSortDataTable(dtValid, "CNT_TGT_EMP_ID > 1");

        int duplicate_emp_id_cnt = dtValid.Rows.Count;

        if(duplicate_emp_id_cnt > 0) 
        {
            string temp = "\\r\\n";

            foreach(DataRow drRow in dtValid.Rows) 
            {
                DataRow[] drArrTgt = dtRelGrpData.Select(string.Format("TGT_EMP_ID = {0}", drRow["TGT_EMP_ID"]));

                foreach(DataRow drRowTgt in drArrTgt) 
                {
                    Biz_RelGroupInfos relGroupInfo  = new Biz_RelGroupInfos(COMP_ID, DataTypeUtility.GetValue(drRowTgt["REL_GRP_ID"]));
                    Biz_EmpInfos empInfo            = new Biz_EmpInfos(DataTypeUtility.GetToInt32(drRowTgt["TGT_EMP_ID"]));
                    temp                            += relGroupInfo.Rel_Grp_Name + " - " + empInfo.Emp_Name + "\\r\\n";
                }
            }

            ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0}명의 사원이 상대그룹에 중복되어 있습니다.{1}", duplicate_emp_id_cnt, temp));
            return;
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("상대그룹 설정에 오류가 없습니다.");
            return;
        }
    }

    protected void ibnRelGrpTgtMap_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtRelGrpData  = GetRelGroupData(COMP_ID, EST_ID, ESTTERM_REF_ID);
        DataTable dtValid       = null;

        if(dtRelGrpData.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("상대그룹에 포함된 사원정보가 없습니다.");
            return;
        }

        dtValid = DataTypeUtility.GetGroupByDataTable(dtRelGrpData
                                                    , "TGT_EMP_ID"
                                                    , new string[] { "TGT_DEPT_ID", "TGT_EMP_ID" }
                                                    , "TGT_EMP_ID");

        int duplicate_emp_id_cnt = dtValid.Select("CNT_TGT_EMP_ID > 1").Length;

        if(duplicate_emp_id_cnt > 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0}건의 부서 or 사원이 상대그룹으로 중복되어 있습니다.", duplicate_emp_id_cnt));
            return;
        }

        Biz_RelGroupTgtMaps relGrpTgtMap    = new Biz_RelGroupTgtMaps();
        bool isOK = relGrpTgtMap.AddRelGroupEmpMap(dtRelGrpData);

        if(isOK) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 상대그룹 대상자를 반영하였습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }

    private DataTable GetRelGroupData(int comp_id, string est_id, int estterm_ref_id) 
    {
        Biz_EmpInfos empInfo                = new Biz_EmpInfos();
        Biz_RelGroupInfos relGrpInfo        = new Biz_RelGroupInfos();
        Biz_RelGroupTgtMaps relGrpTgtMap    = new Biz_RelGroupTgtMaps();
        DataTable dataTable                 = relGrpTgtMap.GetDataTableSchema();
        DataRow dataRow                     = null;
        DataTable dtRelGrp                  = relGrpInfo.GetRelGroupInfo(comp_id, "", est_id, estterm_ref_id).Tables[0];

        foreach(DataRow dataRowRelGrp in dtRelGrp.Rows) 
        {
            DataTable dtTgt         = null;
            string rel_grp_id       = dataRowRelGrp["REL_GRP_ID"].ToString();
            string where_sentence   = "";

            where_sentence          =  BizUtility.GetRelGroupWhereString( COMP_ID
                                                                        , EST_ID
                                                                        , ESTTERM_REF_ID
                                                                        , rel_grp_id
                                                                        , "TM");

            if(OwnerTypeMode == OwnerType.Dept)
                dtTgt = empInfo.GetRelDeptList("WHERE", where_sentence, "TM").Tables[0];
            else if(OwnerTypeMode == OwnerType.Emp_User)
                dtTgt = empInfo.GetRelEmpList("WHERE", where_sentence, "TM").Tables[0];

            foreach(DataRow dataRowTgt in dtTgt.Rows) 
            {
                dataRow                     = dataTable.NewRow();

                dataRow["COMP_ID"]          = comp_id;
                dataRow["REL_GRP_ID"]       = rel_grp_id;
                dataRow["EST_ID"]           = est_id;
                dataRow["ESTTERM_REF_ID"]   = estterm_ref_id;
                dataRow["TGT_DEPT_ID"]      = dataRowTgt["TGT_DEPT_ID"];
                dataRow["TGT_EMP_ID"]       = dataRowTgt["TGT_EMP_ID"];
                dataRow["DATE"]             = DateTime.Now;
                dataRow["USER"]             = EMP_REF_ID;

                dataTable.Rows.Add(dataRow);
            }
        }

        return dataTable;
    }
}
