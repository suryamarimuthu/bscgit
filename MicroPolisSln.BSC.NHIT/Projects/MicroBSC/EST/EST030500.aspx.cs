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

public partial class EST_EST030500 : EstPageBase
{
    protected string EST_ID;
    private DataTable DT_POS_BIZ_Q_SBJ = null;

	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!IsPostBack)
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            TreeViewCommom.BindKndBiz(TreeView1);

            ibnSearch.Attributes.Add("onclick", "return Search();");
            ibnSave.Attributes.Add("onclick", "return confirm('체크하신 질의문항을 저장하시겠습니까?');");
		}

        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID  = hdfSearchEstID.Value;

        ltrScript.Text = "";
	}

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if(EST_ID.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가를 선택하세요.");
            return;
        }

        BindGrid(COMP_ID, EST_ID, TreeView1.SelectedValue);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);

        if(estInfo.Q_Tgt_Pos_Biz_Use_YN.Equals("N")) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("현재 평가는 직무평가가 아닙니다.");
            return;
        }

        BindGrid(COMP_ID, EST_ID, TreeView1.SelectedValue);
    }

    private void BindGrid(int comp_id, string est_id, string pos_bis_id) 
    {
        Biz_QuestionEstMaps qEstMap = new Biz_QuestionEstMaps();
        DataSet ds                  = qEstMap.GetQuestionObJSubData(EST_ID);


        Biz_PositionBizQuestionSubjectMaps posBizQSub = new Biz_PositionBizQuestionSubjectMaps();

        if(pos_bis_id != "")
            DT_POS_BIZ_Q_SBJ = posBizQSub.GetPosBizQuestionSbjMap(comp_id, est_id, pos_bis_id, "").Tables[0];

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        TemplatedColumn ckb_col     = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
        CheckBox ckbSelect          = (CheckBox)((CellItem)ckb_col.CellItems[e.Row.BandIndex]).FindControl("cBox");

        if(DT_POS_BIZ_Q_SBJ != null && DT_POS_BIZ_Q_SBJ.Rows.Count > 0) 
        {
            DataRow[] drArr             = DT_POS_BIZ_Q_SBJ.Select(string.Format(@"Q_SBJ_ID = '{0}'", drw["Q_SBJ_ID"]));

            if (drArr.Length > 0)
            {
                ckbSelect.Checked = true;
            }
            else
            {
                ckbSelect.Checked = false;
            }
        }
        else
        {
            ckbSelect.Checked = false;
        }
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        if(TreeView1.SelectedValue.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("먼저 직무를 선택하세요.");
            return;
        }

        Biz_PositionBizQuestionSubjectMaps posBizQSub   = new Biz_PositionBizQuestionSubjectMaps();
        DataTable dataTable                             = posBizQSub.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] {"Q_SBJ_ID"}
                                                            , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["POS_BIZ_ID"]       = TreeView1.SelectedValue;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = posBizQSub.SavePosBizQuestionSbjMap(dataTable, COMP_ID, EST_ID, TreeView1.SelectedValue);

        if(isOK) 
        {
            //ltrScript.Text = JSHelper.GetAlertScript("정상적으로 직무평가항목을 설정하였습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }
}
