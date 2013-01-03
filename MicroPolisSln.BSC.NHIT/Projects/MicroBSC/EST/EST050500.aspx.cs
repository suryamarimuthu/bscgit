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

public partial class EST_EST050500 : EstPageBase
{
    private string BOARD_CATEGORY_ID;
    private string BOARD_ID;

	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load(object sender, EventArgs e)
    {
        BOARD_ID          = WebUtility.GetRequest("BOARD_ID", "");
        BOARD_CATEGORY_ID = WebUtility.GetRequest("BOARD_CATEGORY_ID", "");

        if (!IsPostBack)
        {
            DropDownListCommom.BindEstBoardPopupPage(ddlMenuRefID, 0, true);

            BindingBoardInfo(BOARD_ID,BOARD_CATEGORY_ID);
            ButtonStatusByInit();

            ibnSave.Attributes.Add("onclick", "return CheckForm();");
            ibnDelete.Attributes.Add("onclick", string.Format("return confirm( '{0}' );", "정말 삭제하시겠습니까?"));
        }
        
        ltrScript.Text  = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindingBoardInfo("", BOARD_CATEGORY_ID);
        ButtonStatusByInit();
    }
        
    protected void ibnNew_Click(object sender, ImageClickEventArgs e)
    {
        ButtonStatusByNew();
    }
    
    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Boards boardInfo = new Biz_Boards();

        if (PageWriteMode == WriteMode.New)
        {
            if (txtSubjectText.Text.Equals("")) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("공지사항 제목을 입력하세요.");
                return;
            }

            if (txtContentText.Value.Equals(""))
            {
                ltrScript.Text = JSHelper.GetAlertScript("공지사항 내용을 입력하세요.");
                return;
            }

            bool isOK = boardInfo.AddBoard(BOARD_CATEGORY_ID
                                            , txtSubjectText.Text.Trim()
                                            , txtContentText.Value
                                            , 0
                                            , ""
                                            , ""
                                            , ""
                                            , 0
                                            , 0
                                            , wdcStartDate.Value
                                            , wdcEndDate.Value
                                            , DataTypeUtility.GetToInt32(ddlMenuRefID.SelectedValue)
                                            , DataTypeUtility.GetBooleanToYN(cbPopupYN.Checked)
                                            , EMP_REF_ID
                                            , DateTime.Now
                                            , EMP_REF_ID);

            if (isOK)
            {
                BindingBoardInfo("", BOARD_CATEGORY_ID);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되지 않았습니다.");
                return;
            }    
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            if (hdfBoardID.Value.Equals(""))
            {
                ltrScript.Text = JSHelper.GetAlertScript("선택된 공지사항이 없습니다.");
                return;
            }

            bool isOK = boardInfo.ModifyBoard(hdfBoardID.Value.Trim()
                                            , BOARD_CATEGORY_ID
                                            , txtSubjectText.Text.Trim()
                                            , txtContentText.Value
                                            , 0
                                            , ""
                                            , ""
                                            , ""
                                            , 0
                                            , 0
                                            , wdcStartDate.Value
                                            , wdcEndDate.Value
                                            , DataTypeUtility.GetToInt32(ddlMenuRefID.SelectedValue)
                                            , DataTypeUtility.GetBooleanToYN(cbPopupYN.Checked)
                                            , EMP_REF_ID
                                            , DateTime.Now
                                            , EMP_REF_ID);
            if (isOK)
            {
                BindingBoardInfo("", BOARD_CATEGORY_ID);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 수정되지 않았습니다.");
                return;
            }
        }

        ButtonStatusByInit();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Data;
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0) 
        {
            string board_id = e.SelectedRows[0].Cells.FromKey("BOARD_ID").Value.ToString();

            SelectBoardInfo(board_id);
            ButtonStatusByModify();
        }
    }
   
    protected void cbPopupYN_CheckedChanged(object sender, EventArgs e)
    {
        SetPopupYN(((CheckBox)sender).Checked);
    }

    private void SetPopupYN(bool isYN)
    {
        wdcStartDate.Enabled = isYN;
        wdcEndDate.Enabled = isYN;
        ddlMenuRefID.Enabled = isYN;
    }
    private void BindingBoardInfo(string board_id, string board_category_id) 
    {
        Biz_Boards boardInfo          = new Biz_Boards();

        DataSet ds                    = boardInfo.GetBoard("",board_category_id,0,"");
        UltraWebGrid1.DataSource      = ds;
        UltraWebGrid1.DataBind();

        lblRowCount.Text              = ds.Tables[0].Rows.Count.ToString();
    }
    
    protected void ibnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Boards boardInfo = new Biz_Boards();

        if (hdfBoardID.Value.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 공지사항이 없습니다.");
            return;
        }

        bool isOK = boardInfo.RemoveBoard(hdfBoardID.Value, BOARD_CATEGORY_ID);

        if (isOK)
        {
            BindingBoardInfo("", BOARD_CATEGORY_ID);
            ButtonStatusByInit();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제가 처리되지 않았습니다.");
            return;
        }
    }

    private void SelectBoardInfo(string board_id) 
    {
        Biz_Boards boardInfo = new Biz_Boards(board_id, BOARD_CATEGORY_ID);

        hdfBoardID.Value            = board_id;
        txtSubjectText.Text         = boardInfo.Subject_Text;
        txtContentText.Value        = boardInfo.Content_Text;
        cbPopupYN.Checked           = DataTypeUtility.GetYNToBoolean(boardInfo.Pop_Up_YN);
        wdcStartDate.Value          = boardInfo.Start_Date;
        wdcEndDate.Value            = boardInfo.End_Date;
        WebUtility.FindByValueDropDownList(ddlMenuRefID, boardInfo.Menu_Ref_ID);
        lblWriteEmpName.Text        = boardInfo.Write_Emp_Name + "( " + boardInfo.Write_Emp_ID.ToString() + " )";

        SetPopupYN(cbPopupYN.Checked);
    }

    private void ClearValueControls() 
    {
       
        txtSubjectText.Text         = "";
        txtContentText.Value        = "";
        cbPopupYN.Checked           = false;
        wdcStartDate.Value          = DBNull.Value;
        wdcEndDate.Value            = DBNull.Value;
        WebUtility.FindByValueDropDownList(ddlMenuRefID, "");
        lblWriteEmpName.Text        = "";
    }

    private void ButtonStatusByInit() 
    {
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = false;
        ibnDelete.Enabled       = false;



        ClearValueControls();

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode           = WriteMode.None;
    }

    private void ButtonStatusByNew() 
    {
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = true;
        ibnDelete.Enabled       = false;

        ClearValueControls();

        cbPopupYN.Checked       = true;
        SetPopupYN(true);

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode           = WriteMode.New;
    }

    private void ButtonStatusByModify() 
    {
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = true;
        ibnDelete.Enabled       = true;



        ibnSave.ImageUrl        = "../images/btn/b_002.gif";//"수정";

        PageWriteMode           = WriteMode.Modify;
    }
    
}
