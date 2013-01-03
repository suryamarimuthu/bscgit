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

using SJ.Web.UI;

using MicroBSC.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.BSC.Biz;

using DeptInfos = MicroBSC.Estimation.Dac.DeptInfos;

public partial class usr_usr_pdt_ahp_deployment : AppPageBase
{
    private int VER_ID          = 0;
    private int ESTTERM_REF_ID  = 0;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        VER_ID          = PageUtility.GetIntByValueDropDownList(ddlStgVersion);
        ESTTERM_REF_ID  = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        if (!Page.IsPostBack) 
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.FillEstTree(trvEstDept, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), EMP_REF_ID);
            StgVersionDropDownBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

            iBtnSearch.Attributes.Add("onclick", "return ValidCheck();");
            iBtnDeploy.Attributes.Add("onclick", "return confirm('선택된 평가기간, 버젼, 부서에 대한 전략정보를 배포 하시겠습니까?');");
        }

        ltrScript.Text = "";
    }
    private void StgVersionDropDownBinding(int estterm_ref_id) 
    {
        ddlStgVersion.ClearSelection();
        Biz_PDTAndAHPVersions pdtAhpVersion = new Biz_PDTAndAHPVersions();
        DataSet ds                          = pdtAhpVersion.GetPdtAhpVersions(estterm_ref_id); 
        ddlStgVersion.DataSource            = ds;
        ddlStgVersion.DataValueField        = "VER_ID";
        ddlStgVersion.DataTextField         = "VER_NAME";
        ddlStgVersion.DataBind();
    }
    private void DeployGridDataBinding(int ver_id
                                        , int estterm_ref_id
                                        , int est_dept_ref_id
                                        , bool isSubDept) 
    {
        Biz_PDTAndAHPStgEstDeptDatas pDTAndAHPStgEstDeptDatas = new Biz_PDTAndAHPStgEstDeptDatas();
        DataSet ds              = pDTAndAHPStgEstDeptDatas.GetPDTAndAHPDeployList(ver_id
                                                                                , estterm_ref_id
                                                                                , est_dept_ref_id
                                                                                , 0
                                                                                , isSubDept);
        DataGrid1.DataSource    = ds;
        DataGrid1.DataBind();
    }
    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        PopupControlExtender1.Commit(trvEstDept.SelectedNode.Text);
        PopupControlExtender2.Commit(trvEstDept.SelectedNode.Value);
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DeployGridDataBinding(VER_ID
                            , ESTTERM_REF_ID
                            , int.Parse(txtDeptID.Text)
                            , cBoxIsSubDept.Checked);
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drw = (DataRowView)e.Item.DataItem;

            if (drw["WEIGHT"] != DBNull.Value)
                e.Item.Cells[2].Text = Convert.ToString(Math.Round(Convert.ToDouble(drw["WEIGHT"].ToString()), 2)) + "&nbsp;%&nbsp;&nbsp;";

            if (drw["CI"] != DBNull.Value)
                e.Item.Cells[3].Text = Convert.ToString(Math.Round(Convert.ToDouble(drw["CI"].ToString()) * 100, 2)) + "&nbsp;%&nbsp;&nbsp;";

            if (drw["CR"] != DBNull.Value)
                e.Item.Cells[4].Text = Convert.ToString(Math.Round(Convert.ToDouble(drw["CR"].ToString()) * 100, 2)) + "&nbsp;%&nbsp;&nbsp;";

            if (drw["DEPLOY_DATE"] != DBNull.Value)
                e.Item.Cells[6].Text = Convert.ToDateTime(drw["DEPLOY_DATE"]).ToString("yyyy-MM-dd");
        }

    }
    protected void iBtnDeploy_Click(object sender, ImageClickEventArgs e)
    {
        Biz_PDTAndAHPStgEstDeptDatas pDTAndAHPStgEstDeptDatas = new Biz_PDTAndAHPStgEstDeptDatas();

        DataTable stgdData  = new DataTable();
        DataRow dr          = null;

        //stgdData.Columns.Add("STG_REF_ID"   , typeof(int));
        
        //foreach (DataGridItem item in DataGrid1.Items)
        //{
        //    dr                  = stgdData.NewRow();
        //    dr["STG_REF_ID"]    = (item.Cells[0].FindControl("lblStgRefID") as Label).Text;
        //    stgdData.Rows.Add(dr);
        //}



    }
}
