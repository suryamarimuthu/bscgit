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

public partial class EST_EST020100 : EstPageBase
{
    //private string[] formatList = new string[] {"None"
    //                                            ,"Currency"
    //                                            ,"Date"
    //                                            ,"DateTime"
    //                                            ,"Integer"
    //                                            ,"Double"
    //                                            ,"Time"
    //                                           };

    private string[] halignList = new string[] {"NotSet"
                                                ,"Left"
                                                ,"Center"
                                                ,"Right"
                                                ,"Justify"
                                               };

    private string[] dataTypeList = new string[] {"System.String"
                                                 ,"System.Boolean"
                                                 ,"System.Byte"
                                                 ,"System.Char"
                                                 ,"System.DateTime"
                                                 ,"System.Decimal"
                                                 ,"System.Double"
                                                 ,"System.Guid"
                                                 ,"System.Int16"
                                                 ,"System.Int32"
                                                 ,"System.Int64"
                                                 ,"System.Object"
                                                 ,"System.SByte"
                                                 ,"System.Single"
                                                 ,"System.UInt16"
                                                 ,"System.UInt32"
                                                 ,"System.UInt64"
                                                };

    private string EST_ID;
    private DataTable _dtEstColumnMap;

    protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!IsPostBack)
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            TextBoxCommon.SetOnlyInteger(txtWidth);
            TextBoxCommon.SetOnlyInteger(txtSeq);

            RadioButtonListCommom.BindUseYN(rbnVisibleYN);
            RadioButtonListCommom.BindUseYN(rbnColEmpVisibleYN);
            //RadioButtonListCommom.BindUseYN(rbnGradeToPointVisibleYN);
            //RadioButtonListCommom.BindUseYN(rbnEstTermSubVisibleYN);
            //RadioButtonListCommom.BindUseYN(rbnEstTermStepVisibleYN);

            DropDownListCommom.BindColumnStyle(ddlColStyleID, false);

            MakeData(ddlHAlign, halignList);
            MakeData(ddlDataType, dataTypeList); 

			ButtonStatusInit();

            ibnSearch.Attributes.Add("onclick", "return CheckForm();");
            ibnCheckID.Attributes.Add("onclick","return CheckID();");
            ibnNew.Attributes.Add("onclick", "return CheckForm();");
            ibnSave.Attributes.Add("onclick", "return SaveCheckForm();");
            ibnDelete.Attributes.Add("onclick", "return ConfirmYN();");
		}

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID          = hdfEstID.Value;

		ltrScript.Text  = string.Empty;
	}

	protected void Page_PreRender( object sender, EventArgs e )
	{

	}

	private void GridBinding(int comp_id)
	{
        Biz_ColumnInfos columnInfos = new Biz_ColumnInfos();
        DataSet ds                  = columnInfos.GetColumnInfo(comp_id, EST_ID, "");

        UltraWebGrid1.DataSource    = ds;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
	}

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        GridBinding(COMP_ID);
        ClearValueControls();
        ddlColStyleID_SelectedIndexChanged(null, null);
    }

    protected void ibnNew_Click(object sender, ImageClickEventArgs e)
    {
		ButtonStatusNew();
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        int seq                                 = DataTypeUtility.GetToInt32(txtSeq.Text.Trim());
        string col_name                         = txtColName.Text.Trim();
        string col_style_id                     = WebUtility.GetByValueDropDownList(ddlColStyleID);
        string col_key                          = txtColKey.Text.Trim();
        string caption                          = txtCaption.Text.Trim();
        int    width                            = DataTypeUtility.GetToInt32(txtWidth.Text.Trim());
        string data_type                        = WebUtility.GetByValueDropDownList(ddlDataType);
        string halign                           = WebUtility.GetByValueDropDownList(ddlHAlign);
        string back_color                       = txtBackColor.Text.Trim();
        string format                           = txtFormat.Text;
        string formula                          = txtFormula.Text.Trim();
        string defaultValue                     = txtDefaultValue.Text.Trim();
        string col_desc                         = txtColDesc.Text.Trim();
        string back_color_yn                    = DataTypeUtility.GetBooleanToYN(ckbBackColorYN.Checked);
        string format_yn                        = DataTypeUtility.GetBooleanToYN(ckbFormatYN.Checked);
        string formula_yn                       = DataTypeUtility.GetBooleanToYN(ckbFormularYN.Checked);
        string defaultValue_yn                  = DataTypeUtility.GetBooleanToYN(ckbDefaultValueYN.Checked);
        string visible_yn                       = WebUtility.GetByValueRadioButtonList(rbnVisibleYN);
        string col_emp_visible_yn               = WebUtility.GetByValueRadioButtonList(rbnColEmpVisibleYN);

        Biz_ColumnInfos columnInfos = new Biz_ColumnInfos();

        if (PageWriteMode == WriteMode.New)
        {
            bool bDuplicate = columnInfos.IsExist(COMP_ID, EST_ID, col_key);

            if (bDuplicate)
            {
                ltrScript.Text = JSHelper.GetAlertScript("동일한 컬럼키가 존재합니다.");
                return;
            }

            bool bResult = columnInfos.AddColumnInfo( COMP_ID
                                                    , EST_ID
                                                    , seq
                                                    , col_name
                                                    , col_style_id
                                                    , col_key
                                                    , caption
                                                    , width
                                                    , data_type
                                                    , halign
                                                    , back_color
                                                    , format
                                                    , formula
                                                    , defaultValue
                                                    , col_desc
                                                    , back_color_yn
                                                    , format_yn
                                                    , formula_yn
                                                    , defaultValue_yn
                                                    , visible_yn
                                                    , col_emp_visible_yn
                                                    , DateTime.Now
                                                    , EMP_REF_ID
                                                    );

            bool isOK = SaveEstJobColumnMap(!trEstJob.Visible);

            if (bResult)
            {
                //ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.");
                GridBinding(COMP_ID);
                ButtonStatusInit();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
                return;
            }
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            bool bResult = columnInfos.ModifyColumnInfo(  COMP_ID
                                                        , EST_ID
                                                        , seq
                                                        , col_name
                                                        , col_style_id
                                                        , col_key
                                                        , caption
                                                        , width
                                                        , data_type
                                                        , halign
                                                        , back_color
                                                        , format
                                                        , formula
                                                        , defaultValue
                                                        , col_desc
                                                        , back_color_yn
                                                        , format_yn
                                                        , formula_yn
                                                        , defaultValue_yn
                                                        , visible_yn
                                                        , col_emp_visible_yn
                                                        , DateTime.Now
                                                        , EMP_REF_ID
                                                        );

            bool isOK = SaveEstJobColumnMap(!trEstJob.Visible);

            if (bResult)
            {
                //ltrScript.Text = JSHelper.GetAlertScript("정상적으로 수정되었습니다.");
                //GridBinding(COMP_ID);
                //ButtonStatusInit();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("수정되지 않았습니다.");
                return;
            }
        }
    }
       
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr                              = (DataRowView)e.Data;

        Biz_ColumnStyles columnStyles               = new Biz_ColumnStyles(dr["COL_STYLE_ID"].ToString());
        e.Row.Cells.FromKey("COL_STYLE_NAME").Value = columnStyles.Col_Style_Name;

        if(dr["VISIBLE_YN"].ToString().Equals("Y")) 
        {
            e.Row.Cells.FromKey("VISIBLE_YN_IMG").Value = "<img src='../images/icon/color/blue.gif'/>";
        }
        else 
        {
            e.Row.Cells.FromKey("VISIBLE_YN_IMG").Value = "<img src='../images/icon/color/red.gif'/>";
        }
    }

    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView) e.Data;

        if (PageWriteMode == WriteMode.Modify) 
        {
            string est_job_id = drw["EST_JOB_ID"].ToString();

            if(_dtEstColumnMap.Select(string.Format("EST_JOB_ID = '{0}' AND COL_KEY = '{1}'"
                                                    , est_job_id
                                                    , txtColKey.Text)).Length > 0)
            {
                TemplatedColumn ckbEstJobEstMap	= (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
	            CheckBox cBox		            = (CheckBox)((CellItem)ckbEstJobEstMap.CellItems[e.Row.BandIndex]).FindControl("cBox");
                cBox.Checked                    = true;
            }
        }
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if(e.SelectedRows.Count > 0) 
        {
            string col_key = e.SelectedRows[0].Cells.FromKey("COL_KEY").Value.ToString();

            hdfEstID.Value = e.SelectedRows[0].Cells.FromKey("EST_ID").Value.ToString();
            ButtonStatusModify();

            ViewOne(COMP_ID, hdfEstID.Value, col_key);
        }
    }

    protected void itnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string col_key = txtColKey.Text.Trim();

        Biz_ColumnInfos columnInfos = new Biz_ColumnInfos();
        bool bResult                = columnInfos.RemoveColumnInfo(COMP_ID, EST_ID, col_key);

        if (bResult)
        {
            //ltrScript.Text = JSHelper.GetAlertScript("삭제되었습니다.", false);

            GridBinding(COMP_ID);
            ButtonStatusInit();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제되지 않았습니다.");
        }
    }

    protected void ibnCheckID_Click(object sender, ImageClickEventArgs e)
    {
        Biz_ColumnInfos columnInfos = new Biz_ColumnInfos();
        bool bDuplicate             = columnInfos.IsExist(COMP_ID, EST_ID, txtColKey.Text.Trim());

        if (bDuplicate)
        {
            ltrScript.Text = JSHelper.GetAlertScript("동일한 컬럼키가 존재합니다.");
            return;
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("사용가능한 컬럼키입니다.");
            return;
        }
    }

    private void ViewOne(int comp_id, string est_id, string col_key)
    {
        Biz_ColumnInfos columnInfos     = new Biz_ColumnInfos(comp_id, est_id, col_key);
        Biz_ColumnStyles columnStyles   = new Biz_ColumnStyles(columnInfos.Col_Style_ID);

        txtSeq.Text             = columnInfos.Seq.ToString();
        txtColName.Text         = columnInfos.Col_Name;
        WebUtility.FindByValueDropDownList(ddlColStyleID,columnInfos.Col_Style_ID);
        txtColKey.Text          = columnInfos.Col_Key;
        txtCaption.Text         = columnInfos.Caption;
        txtWidth.Text           = columnInfos.Width.ToString();

        WebUtility.FindByValueDropDownList(ddlDataType, columnInfos.Data_Type);
        WebUtility.FindByValueDropDownList(ddlHAlign, columnInfos.Halign);
        txtBackColor.Text       = columnInfos.Back_Color;
        txtFormat.Text          = columnInfos.Format;
        txtFormula.Text         = columnInfos.Formula;
        txtDefaultValue.Text    = columnInfos.Default_Value;
        txtColDesc.Text         = columnInfos.Col_Desc;

        ckbBackColorYN.Checked  = DataTypeUtility.GetYNToBoolean(columnInfos.Back_color_YN);
        ckbFormatYN.Checked     = DataTypeUtility.GetYNToBoolean(columnInfos.Format_YN);
        ckbFormularYN.Checked   = DataTypeUtility.GetYNToBoolean(columnInfos.Formula_YN);
        ckbDefaultValueYN.Checked   = DataTypeUtility.GetYNToBoolean(columnInfos.Default_Value_YN);
        WebUtility.FindByValueRadioButtonList(rbnVisibleYN, columnInfos.Visible_YN);
        WebUtility.FindByValueRadioButtonList(rbnColEmpVisibleYN, columnInfos.Col_Emp_Visible_YN);
        //WebUtility.FindByValueRadioButtonList(rbnGradeToPointVisibleYN, columnInfos.Col_Grade_To_Point_Visible_YN);

        BindEstJob(COMP_ID, EST_ID, col_key);

        ddlColStyleID_SelectedIndexChanged(null, null);
    }

    private void MakeData(DropDownList ddl, string[] strList)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("COLNAME", typeof(string));
        dt.Columns.Add("COLVALUE", typeof(string));

        for (int i = 0; i < strList.Length; i++)
        {
            DataRow row     = dt.Rows.Add(new object[0]);
            row["COLNAME"]  = strList[i].ToString();
            row["COLVALUE"] = strList[i].ToString();
        }

        dt.AcceptChanges();

        ddl.DataSource      = dt;
        ddl.DataTextField   = "COLNAME";
        ddl.DataValueField  = "COLVALUE";

        ddl.DataBind();
    }

    private bool SaveEstJobColumnMap(bool isBlank) 
    {
        Biz_JobColumnMaps jobColumnMap = new Biz_JobColumnMaps();
        DataTable dataTable      = jobColumnMap.GetDataTableSchema();

        if(!isBlank) 
        {
            dataTable                = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid2
                                                                            , "cBox"
                                                                            , "selchk"
                                                                            , new string[] { "EST_JOB_ID" }
                                                                            , dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                dataRow["COMP_ID"]  = COMP_ID;
                dataRow["EST_ID"]   = EST_ID;
                dataRow["COL_KEY"]  = txtColKey.Text;
                dataRow["DATE"]     = DateTime.Now;
                dataRow["USER"]     = EMP_REF_ID;
            }
        }

        return jobColumnMap.SaveJobColumnMap(dataTable, COMP_ID, EST_ID, txtColKey.Text);
    }

    private void BindEstJob(int comp_id, string est_id, string col_key) 
    {
        if(!est_id.Equals("")) 
        {
            Biz_JobColumnMaps jobColumnMap  = new Biz_JobColumnMaps();
            _dtEstColumnMap                 = jobColumnMap.GetJobColumnMap(comp_id, est_id, "", col_key).Tables[0];
        }

        Biz_JobInfos jobInfo        = new Biz_JobInfos();
        UltraWebGrid2.DataSource    = jobInfo.GetJobInfoInEstJobMaps(comp_id, est_id, "N");
        UltraWebGrid2.DataBind();
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridBinding(COMP_ID);
        ddlColStyleID_SelectedIndexChanged(null, null);
    }

    protected void ddlColStyleID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(WebUtility.GetByValueDropDownList(ddlColStyleID).Equals("BIZ"))
        {
            trEstJob.Visible = true;

            if(PageWriteMode == WriteMode.Modify)
                BindEstJob(COMP_ID, EST_ID, txtColKey.Text);
            else if(PageWriteMode == WriteMode.New)
                BindEstJob(COMP_ID, EST_ID, "-");
        }
        else 
        {
            trEstJob.Visible = false;
        }
    }

	private void ClearValueControls()
	{
        txtSeq.Text             = "";
        txtColName.Text         = "";
        WebUtility.GetByValueDropDownList(ddlColStyleID,"");
        txtColKey.Text          = "";
        txtCaption.Text         = "";
        txtWidth.Text           = "";
        WebUtility.FindByValueDropDownList(ddlDataType, "System.String");
        WebUtility.FindByValueDropDownList(ddlHAlign, "NotSet");
        txtBackColor.Text       = "";
        txtFormat.Text          = "";
        txtFormula.Text         = "";
        txtDefaultValue.Text    = "";
        txtColDesc.Text         = "";
        ckbBackColorYN.Checked  = false;
        ckbFormatYN.Checked     = false;
        ckbFormularYN.Checked   = false;
        ckbDefaultValueYN.Checked = false;
        WebUtility.FindByValueRadioButtonList(rbnVisibleYN, "Y");
        WebUtility.FindByValueRadioButtonList(rbnColEmpVisibleYN, "N");
        WebUtility.FindByValueDropDownList(ddlColStyleID, "NML");
        ddlColStyleID_SelectedIndexChanged(null, null);

        //WebUtility.FindByValueRadioButtonList(rbnGradeToPointVisibleYN, "N");
        //WebUtility.FindByValueRadioButtonList(rbnEstTermSubVisibleYN, "N");
        //WebUtility.FindByValueRadioButtonList(rbnEstTermStepVisibleYN, "N");
	}

	private void ButtonStatusInit()
	{
        txtColKey.Enabled   = true;
        txtColKey.Width     = Unit.Percentage(100);

        ibnCheckID.Visible  = false;
        ibnSave.Enabled     = false;
        ibnDelete.Enabled   = false;

        ClearValueControls();

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode           = WriteMode.None;
	}

	private void ButtonStatusNew()
	{
        //GridBinding(COMP_ID);

        txtColKey.Enabled   = true;

        txtColKey.Width     = Unit.Percentage(55);

        ibnCheckID.Visible  = true;
        ibnSave.Enabled     = true;
        ibnDelete.Enabled   = false;

        ClearValueControls();

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode           = WriteMode.New;
        
        txtColKey.Focus();
	}

	private void ButtonStatusModify()
	{
        txtColKey.Enabled   = false;
        ibnCheckID.Visible  = false;
        txtColKey.Width     = Unit.Percentage(100);
        ibnSave.Enabled     = true;
        ibnDelete.Enabled   = true;
        ibnSave.ImageUrl    = "../images/btn/b_002.gif";//"수정";
		PageWriteMode       = WriteMode.Modify;
	}
}
