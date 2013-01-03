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

public partial class EST_EST010500 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
			GridBinding(WebUtility.GetIntByValueDropDownList(ddlCompID));
			ButtonStatusInit();
		}

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
		ltrScript.Text  = "";
	}

	private void GridBinding(int comp_id)
	{
		Biz_Grades grades   = new Biz_Grades();
		DataSet ds          = grades.GetEstGrades(comp_id);

		UltraWebGrid1.DataSource = ds;
		UltraWebGrid1.DataBind();

		lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
	}

	private void ViewOne(int comp_id, string grade_id)
	{
		Biz_Grades grades = new Biz_Grades(comp_id, grade_id);

		txtGradeID.Text			= grades.Grade_ID;
		txtGradeName.Text		= grades.Grade_Name;
		txtGradeDesc.Text		= grades.Grade_Desc;

		hdfGradeID.Value		= grade_id;
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
	}

	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
		hdfGradeID.Value	= e.SelectedRows[0].Cells.FromKey("GRADE_ID").Value.ToString();

        ViewOne(COMP_ID, hdfGradeID.Value);
		ButtonStatusModify();
	}

	private void ClearValueControls()
	{
		txtGradeID.Text			= "";
		txtGradeName.Text		= "";
		txtGradeDesc.Text		= "";
	}

	protected void ibnCheckID_Click( object sender, ImageClickEventArgs e )
	{
		string strGradeID   = txtGradeID.Text;

		if (strGradeID == "")
		{
			ltrScript.Text = JSHelper.GetAlertScript("등급 ID를 입력해주세요.");
			return;
		}

		Biz_Grades grades   = new Biz_Grades();
		bool bDuplicate     = grades.IsExist(COMP_ID, strGradeID);

		if (bDuplicate)
		{
			ltrScript.Text = JSHelper.GetAlertScript("존재하는 등급 ID 입니다.");
		}
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("사용가능한 등급 ID 입니다.");
        }
	}

	protected void ibnNew_Click( object sender, ImageClickEventArgs e )
	{
		ButtonStatusNew();
	}

	protected void ibnSave_Click( object sender, ImageClickEventArgs e )
	{
		string strGradeID   = txtGradeID.Text;
		string strGradeName = txtGradeName.Text;
		string strGradeDesc = txtGradeDesc.Text;

		Biz_Grades grades   = new Biz_Grades();
        bool bResult        = false;

        if (PageWriteMode == WriteMode.New)
        {
            bool bDuplicate     = grades.IsExist(COMP_ID, strGradeID);

		    if (bDuplicate)
		    {
			    ltrScript.Text = JSHelper.GetAlertScript("존재하는 등급 ID 입니다.");
                return;
		    }

		    bResult = grades.AddEstGrade( COMP_ID
                                        , strGradeID
									    , strGradeName
									    , strGradeDesc
									    , DateTime.Now
									    , EMP_REF_ID);

		    if (bResult)
		    {
			    GridBinding(COMP_ID);
			    ButtonStatusInit();
		    }
		    else
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "저장 중 오류가 발생하였습니다." );
		    }
        }
        else 
        {
            bResult = grades.ModifyEstGrade(  COMP_ID
                                            , strGradeID
											, strGradeName
											, strGradeDesc
											, DateTime.Now
											, EMP_REF_ID);

		    if (bResult)
		    {
			    GridBinding(COMP_ID);
			    ButtonStatusInit();
		    }
		    else
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "수정 중 오류가 발생하였습니다." );
		    }
        }
	}

	protected void ibnDelete_Click( object sender, ImageClickEventArgs e )
	{
		string strGradeID	= hdfGradeID.Value;

		Biz_Grades grades   = new Biz_Grades();
		bool bResult        = grades.RemoveEstGrade(COMP_ID, strGradeID);

		if (bResult)
		{
			ltrScript.Text = JSHelper.GetAlertScript( "정상적으로 삭제되었습니다.", false );

			GridBinding(COMP_ID);
			ButtonStatusInit();
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript( "삭제 중 오류가 발생하였습니다." );
		}
	}

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridBinding(COMP_ID);
    }

	private void ButtonStatusInit()
	{
		ibnSave.Enabled		    = false;
		ibnDelete.Enabled		= false;

		ibnCheckID.Visible      = false;

		ClearValueControls();

		txtGradeID.Enabled		= false;
		txtGradeName.Enabled	= false;
		txtGradeDesc.Enabled	= false;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode           = WriteMode.None;
	}

	private void ButtonStatusNew()
	{
		ibnSave.Enabled		    = true;
		ibnDelete.Enabled		= false;

		ibnCheckID.Visible      = true;
		txtGradeID.Width        = Unit.Percentage(60);

		ClearValueControls();

		txtGradeID.Enabled      = true;
		txtGradeName.Enabled    = true;
		txtGradeDesc.Enabled    = true;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode           = WriteMode.New;
	}

	private void ButtonStatusModify()
	{
		ibnSave.Enabled		    = true;
		ibnDelete.Enabled		= true;

		ibnCheckID.Visible      = true;
		txtGradeID.Width        = Unit.Percentage(60);

		txtGradeID.Enabled      = false;
		txtGradeName.Enabled    = true;
		txtGradeDesc.Enabled    = true;

        ibnSave.ImageUrl        = "../images/btn/b_002.gif";//"수정";

		PageWriteMode           = WriteMode.Modify;
	}
}

