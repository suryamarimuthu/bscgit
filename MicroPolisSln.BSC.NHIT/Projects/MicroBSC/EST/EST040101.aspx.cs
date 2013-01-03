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

public partial class EST_EST040101 : EstPageBase
{
    private string EST_ID;
    public string SCALE_TYPE;

    private DataView _dwScale		 = null;
    private DataTable _dtEstScale	 = null;
	private DataTable _dtPosScale	 = null;

	private DataTable dtPositionAll  = null;
	private Hashtable htPositionName = null;

	protected void Page_Load( object sender, EventArgs e )
	{
        COMP_ID             = WebUtility.GetRequestByInt("COMP_ID");
        EST_ID				= WebUtility.GetRequest("EST_ID");
		ESTTERM_REF_ID		= WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        SCALE_TYPE			= WebUtility.GetRequest("SCALE_TYPE");

		if (!Page.IsPostBack)	
		{
            EST_JOB_ID      = "JOB_14";

            DropDownListCommom.BindEstScaleInfo(ddlScaleIDAll, COMP_ID);
            DropDownListCommom.BindScale(ddlScaleID, COMP_ID);

            Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, EST_ID);

            if(estInfo.Grade_Confirm_YN.Equals("Y")) 
            {
                tblCtrls1.Visible = true;
                tblCtrls2.Visible = true;

                View(COMP_ID);

                ibnSaveAll.Attributes.Add( "onclick", "return confirm( '설정된 평가방법으로 저장하시겠습니까?' )" );
                ibnSave.Attributes.Add( "onclick", "return confirm( '저장하시겠습니까?' )" );
                ibnConfirm.Attributes.Add("onclick", "return confirm('설정한 평가방법을 확정하시겠습니까?')");
                ibnConfirmCancel.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");
                ibnSavePosAll.Attributes.Add("onclick", "return confirm('현재 설정을 모든 부서에 적용하시겠습니까?')");
                ibnRemove.Attributes.Add("onclick", "return confirm('삭제하시겠습니까?')");
                ibnSave.Attributes.Add("onclick", "return confirm('저장하시겠습니까?')");
                ibnSave3.Attributes.Add("onclick", "return confirm('저장하시겠습니까?')");
                ibnInit2.Attributes.Add("onclick", "return confirm('선택된 부서를 초기화 하시겠습니까?')");
            }
            else 
            {
                tblCtrls1.Visible = false;
                tblCtrls2.Visible = false;

                ltrScript.Text = JSHelper.GetAlertScript("등급확정이 아닌 평가에서는 평가방식 설정이 요구되지 않습니다.");
                return;
            }
		}

        Biz_Positions positions = new Biz_Positions();
		dtPositionAll           = positions.GetPositionAll();

        ltrScript.Text          = "";
	}

    protected void Page_PreRender( object sender, EventArgs e )
	{

    }

	private bool CheckParam()
	{
		if (   ESTTERM_REF_ID   != 0 
            && EST_ID.Length    != 0
            && !SCALE_TYPE.Equals(""))
			return true;

		return false;
	}

    private void View(int comp_id)
	{
		if ( CheckParam() == false )
			return;

		if (	SCALE_TYPE.Equals( ScaleType.DPT.ToString() ) == true 
			 || SCALE_TYPE.Length == 0 )
		{
			BindDept(comp_id);
		}
		else
		{
			BindPos(comp_id);
		}
	}

    private void BindDept(int comp_id)
	{
		plDept.Visible  = true;
		plPos.Visible   = false;

		GridBinding(comp_id);

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm1
                                            , ibnConfirmCancel1);
	}

	private void BindPos(int comp_id)
	{
		plDept.Visible  = false;
		plPos.Visible   = true;

        GridBinding2(comp_id, ESTTERM_REF_ID, EST_ID);

		DropDownListCommom.BindPositionInfo(ddlPositionType);
		DropDownListCommom.BindPositionValue( ddlPositionValue
											, WebUtility.GetByValueDropDownList(ddlPositionType));

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , null
                                            , null);
	}

    private void GridBinding(int comp_id)
	{
		if ( CheckParam() == false ) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가정보나 평가방법이 설정되지 않았습니다.");
        	return;
        }
		
        Biz_ScaleInfos scaleInfo            = new Biz_ScaleInfos();
        DataTable dtScale                   = scaleInfo.GetScaleInfos(comp_id).Tables[0];
        _dwScale                            = dtScale.DefaultView;
        _dwScale.Sort                       = "SCALE_ID";

        Biz_DeptEstDetails deptEstDetail    = new Biz_DeptEstDetails();
        _dtEstScale                        = deptEstDetail.GetDeptEstDetail(comp_id, ESTTERM_REF_ID, 0, EST_ID ).Tables[0];

        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource            = BizUtility.GetDeptTree("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        UltraWebGrid1.DataBind();

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                    , EST_ID
                                    , ESTTERM_REF_ID
                                    , ESTTERM_SUB_ID
                                    , ESTTERM_STEP_ID
                                    , EST_JOB_ID
                                    , ibnConfirm
                                    , ibnConfirmCancel);
	}

    private void GridBinding2(int comp_id, int estterm_ref_id, string est_id )
	{
		Biz_DeptEstDetails deptEstDetail    = new Biz_DeptEstDetails();
		_dtEstScale                         = deptEstDetail.GetDeptEstDetail(comp_id, estterm_ref_id, 0, est_id).Tables[0];

		Biz_DeptPosScales deptPosScale      = new Biz_DeptPosScales();
		_dtPosScale                         = deptPosScale.GetDeptPosScale(comp_id, estterm_ref_id, 0, est_id).Tables[0];

        UltraWebGrid2.Clear();
        UltraWebGrid2.DataSource            = BizUtility.GetDeptTree("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        UltraWebGrid2.DataBind();
	}

    private void GridBinding3(int comp_id, int estterm_ref_id, int dept_ref_id, string est_id)
	{
		if ( dept_ref_id == 0 )
			return;

		Biz_DeptPosScales deptPosScale     = new Biz_DeptPosScales();
		_dtPosScale                        = deptPosScale.GetDeptPosScale(comp_id
                                                                        , estterm_ref_id
                                                                        , dept_ref_id
                                                                        , est_id).Tables[0];

        UltraWebGrid3.Clear();
		UltraWebGrid3.DataSource		   = _dtPosScale;
		UltraWebGrid3.DataBind();
	}

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw             = (DataRowView) e.Data;

        TemplatedColumn scale_col   = (TemplatedColumn)e.Row.Band.Columns.FromKey("SCALE_ID");
        DropDownList ddlScaleID     = (DropDownList)((CellItem)scale_col.CellItems[e.Row.BandIndex]).FindControl("ddlScaleID");

        ddlScaleID.DataTextField    = "SCALE_NAME";
        ddlScaleID.DataValueField   = "SCALE_ID";
        ddlScaleID.DataSource       = _dwScale;
        ddlScaleID.DataBind();

        DataRow[] drArr = _dtEstScale.Select( string.Format(@" ESTTERM_REF_ID   = {0}
                                                            AND DEPT_REF_ID     = {1}
                                                            AND EST_ID          = '{2}'"
                                                            , ESTTERM_REF_ID
                                                            , drw["DEPT_REF_ID"]
                                                            , EST_ID ) );

        if ( drArr.Length > 0)
        {
            WebUtility.FindByValueDropDownList(ddlScaleID, drArr[0]["SCALE_ID"]);
            e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i02.gif'>";
        }
        else 
        {
            e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i03.gif'>";
        }
    }

    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw             = (DataRowView) e.Data;

        DataRow[] drArr = _dtPosScale.Select(string.Format(@"COMP_ID            = {0}
                                                        AND ESTTERM_REF_ID      = {1}
                                                        AND DEPT_REF_ID         = {2}
                                                        AND EST_ID              = '{3}'"
                                                        , COMP_ID
                                                        , ESTTERM_REF_ID
                                                        , drw["DEPT_REF_ID"]
                                                        , EST_ID));

        if ( drArr.Length > 0 )
        {
            e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i02.gif'>";
        }
        else
        {
            e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i03.gif'>";
        }
    }

    protected void UltraWebGrid3_InitializeRow(object sender, RowEventArgs e)
    {
         DataRowView drw             = (DataRowView) e.Data;

		// 구분
		if ( htPositionName == null )
		{
			BindHashTablePositionName();
		}
		e.Row.Cells.FromKey("NAMEPOS_NAME").Value = htPositionName[drw["POS_ID"].ToString()].ToString();

		// 직급명
		DataRow[] drName = dtPositionAll.Select(string.Format(  @"POS    = '{0}' 
                                                              AND POS_ID = '{1}'"
															, drw["POS_ID"].ToString()
															, drw["POS_VALUE"].ToString()));

		if ( drName.Length > 0 )
		{
			e.Row.Cells.FromKey("NAMEPOS_VALUE").Value = drName[0]["POS_NAME"].ToString();
		}


		// 상태
        DataRow[] drArr = _dtPosScale.Select( string.Format(  @"ESTTERM_REF_ID  = {0}
                                                            AND DEPT_REF_ID     = {1}
                                                            AND EST_ID          = '{2}'"
                                                            , ESTTERM_REF_ID
                                                            , DataTypeUtility.GetToInt32( hdfDeptRefID.Value )
                                                            , EST_ID));
    }

    protected void UltraWebGrid2_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if ( e.SelectedRows.Count > 0 )
		{
			hdfDeptRefID.Value   = e.SelectedRows[0].Cells.FromKey("DEPT_REF_ID").Value.ToString();

			GridBinding3( COMP_ID
                        , ESTTERM_REF_ID
                        , DataTypeUtility.GetToInt32(hdfDeptRefID.Value)
                        , EST_ID);
		}
    }

    protected void UltraWebGrid3_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if ( e.SelectedRows.Count > 0 )
		{
			hdfEstPosSeq.Value          = e.SelectedRows[0].Cells.FromKey("SEQ").Value.ToString();

            WebUtility.FindByValueDropDownList(ddlPositionType, e.SelectedRows[0].Cells.FromKey("POS_ID").Value);
            WebUtility.FindByValueDropDownList(ddlPositionValue, e.SelectedRows[0].Cells.FromKey("POS_VALUE").Value);
            WebUtility.FindByValueDropDownList(ddlScaleID, e.SelectedRows[0].Cells.FromKey("SCALE_ID").Value);
		}
    }

    protected void ddlPositionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownListCommom.BindPositionValue( ddlPositionValue
			                                , WebUtility.GetByValueDropDownList(ddlPositionType));
    }

    private bool CheckInsertPosScale()
	{
		if ( hdfDeptRefID.Value.Length == 0 )
		{
            ltrScript.Text = JSHelper.GetAlertScript("부서를 선택해주세요.");
			return false;
		}

		return true;
	}

    private void BindHashTablePositionName()
	{
		htPositionName = new Hashtable();

		for ( int i = 0; i < ddlPositionType.Items.Count; i++ )
		{
			htPositionName.Add(ddlPositionType.Items[i].Value, ddlPositionType.Items[i].Text);
		}
	}

	private void SaveScaleData( string scale_id )
	{
		Biz_DeptEstDetails deptEstDetail = new Biz_DeptEstDetails();

		DropDownList ddlScaleID;
		UltraGridRow row;
		TemplatedColumn col;

		DataTable dtEstDeptScale    = deptEstDetail.GetDataTableSchema();
		DataRow drEstDeptScale      = null;

		for ( int i = 0; i < UltraWebGrid1.Rows.Count; i++ )
		{
			row         = UltraWebGrid1.Rows[i];
			col         = (TemplatedColumn)row.Band.Columns.FromKey("SCALE_ID");
			ddlScaleID  = (DropDownList)( (CellItem)col.CellItems[row.BandIndex] ).FindControl("ddlScaleID");

			drEstDeptScale                      = dtEstDeptScale.NewRow();
            drEstDeptScale["COMP_ID"]           = COMP_ID;
			drEstDeptScale["ESTTERM_REF_ID"]    = ESTTERM_REF_ID;
			drEstDeptScale["DEPT_REF_ID"]       = row.Cells.FromKey("DEPT_REF_ID").Value;
			drEstDeptScale["EST_ID"]            = EST_ID;
			drEstDeptScale["DATE"]              = DateTime.Now;
			drEstDeptScale["USER"]              = EMP_REF_ID;

			if ( scale_id.Equals( "" ) )
				drEstDeptScale["SCALE_ID"]      = WebUtility.GetByValueDropDownList(ddlScaleID);
			else
				drEstDeptScale["SCALE_ID"]      = scale_id;

			dtEstDeptScale.Rows.Add( drEstDeptScale );
		}

		bool isOK = deptEstDetail.SaveDeptEstWidthScale( dtEstDeptScale );

		if (isOK)
		{
			GridBinding(COMP_ID);
			ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.");
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("저장 중 오류가 발생하였습니다.");
		}
	}

    protected void ibnSave_Click( object sender, ImageClickEventArgs e )
    {
        SaveScaleData("");
    }

    protected void ibnSaveAll_Click( object sender, ImageClickEventArgs e )
    {
        SaveScaleData(WebUtility.GetByValueDropDownList(ddlScaleIDAll));
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

        if(isJobOK)
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가자,피평가자 매핑정보를 평가리스트로 설정 및 확정하였습니다.");
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

    protected void lbnSaveDPT_Click(object sender, EventArgs e)
    {
        Biz_DeptEstDetails deptEstDetail = new Biz_DeptEstDetails();

		DataTable dtEstDeptScale    = deptEstDetail.GetDataTableSchema();
		DataRow drEstDeptScale      = null;
        string[] dept_values        = hdfDeptID.Value.Split(',');

        foreach (string dept_value in dept_values)
        {
			drEstDeptScale                      = dtEstDeptScale.NewRow();

            drEstDeptScale["COMP_ID"]           = COMP_ID;
			drEstDeptScale["ESTTERM_REF_ID"]    = ESTTERM_REF_ID;
			drEstDeptScale["DEPT_REF_ID"]       = DataTypeUtility.GetToInt32(dept_value);
			drEstDeptScale["EST_ID"]            = EST_ID;
			drEstDeptScale["DATE"]              = DateTime.Now;
			drEstDeptScale["USER"]              = EMP_REF_ID;

            drEstDeptScale["SCALE_ID"]          = WebUtility.GetByValueDropDownList(ddlScaleIDAll);
			
			dtEstDeptScale.Rows.Add( drEstDeptScale );
		}

		bool isOK = deptEstDetail.SaveDeptEstWidthScale( dtEstDeptScale );

		if (isOK)
		{
			GridBinding(COMP_ID);
			ltrScript.Text  = JSHelper.GetAlertScript("정상적으로 저장되었습니다.");
            hdfDeptID.Value = "";
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("저장 중 오류가 발생하였습니다.");
		}
    }

    protected void lbnSavePOS_Click(object sender, EventArgs e)
    {
        Biz_DeptPosScales deptPosScale  = new Biz_DeptPosScales();
        Biz_DeptInfos deptInfo          = new Biz_DeptInfos();
        DataTable dataTable             = deptPosScale.GetDataTableSchema();
        DataTable dtDept                = deptInfo.GetDataTableSchema();
        DataRow drRow                   = null;

        string[] dept_values            = hdfDeptID.Value.Split(',');

        dataTable   = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid3
                                                            , new string[] { "SEQ", "POS_ID", "POS_VALUE", "SCALE_ID" }
                                                            , dataTable);

        foreach(string dept_value in dept_values) 
        {
            drRow                   = dtDept.NewRow();
            drRow["DEPT_REF_ID"]    = DataTypeUtility.GetToInt32(dept_value);
            dtDept.Rows.Add(drRow);
        }

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("적용하려는 부서별 평가방법이 없습니다.");
            return;
        }

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = deptPosScale.SaveDeptPosScaleAll(dtDept, dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택부서의 평가방법을 일괄 적용하였습니다.");

            GridBinding2(COMP_ID, ESTTERM_REF_ID, EST_ID);
            UltraWebGrid3.Clear();
            hdfDeptID.Value = "";
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리 않았습니다.");
        }
    }

    protected void ibnSavePosAll_Click(object sender, ImageClickEventArgs e)
    {
        Biz_DeptPosScales deptPosScale  = new Biz_DeptPosScales();
        Biz_DeptInfos deptInfo          = new Biz_DeptInfos();
        DataTable dataTable             = deptPosScale.GetDataTableSchema();
        DataTable dtDept                = deptInfo.GetDataTableSchema();

        dataTable   = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid3
                                                            , new string[] { "SEQ", "POS_ID", "POS_VALUE", "SCALE_ID" }
                                                            , dataTable);

        dtDept      = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid2
                                                            , new string[] { "DEPT_REF_ID" }
                                                            , dtDept);

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("적용하려는 부서별 평가방법이 없습니다.");
            return;
        }

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = deptPosScale.SaveDeptPosScaleAll(dtDept, dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("모든 부서의 평가방법을 일괄 적용하였습니다.");

            GridBinding2(COMP_ID, ESTTERM_REF_ID, EST_ID);
            UltraWebGrid3.Clear();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리 않았습니다.");
        }
    }
    
    protected void ibnSave3_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckInsertPosScale())
		{
			Biz_DeptPosScales deptPosScale = new Biz_DeptPosScales();

			int dept_ref_id             = DataTypeUtility.GetToInt32(hdfDeptRefID.Value);
			string pos_id               = WebUtility.GetByValueDropDownList(ddlPositionType);
			string pos_value            = WebUtility.GetByValueDropDownList(ddlPositionValue);
			string scale_id             = WebUtility.GetByValueDropDownList(ddlScaleID);
            bool isOK                   = false;

			try
			{
                bool isDuplicate = deptPosScale.IsExist(  COMP_ID
                                                        , ESTTERM_REF_ID
                                                        , dept_ref_id
                                                        , EST_ID
                                                        , 0
                                                        , pos_id
                                                        , pos_value);

                if (isDuplicate)
                {
                    if(hdfEstPosSeq.Value.Equals(""))
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("변경하실 직급 구분을 선택하세요.");
                        return;
                    }

                    isOK = deptPosScale.ModifyDeptPosScale(COMP_ID
                                                        , ESTTERM_REF_ID
                                                        , dept_ref_id
                                                        , EST_ID
                                                        , DataTypeUtility.GetToInt32(hdfEstPosSeq.Value)
                                                        , pos_id
                                                        , pos_value
                                                        , scale_id
                                                        , DateTime.Now
                                                        , EMP_REF_ID );
                }
                else 
                {
                    isOK = deptPosScale.AddDeptPosScale(  COMP_ID
                                                        , ESTTERM_REF_ID
                                                        , dept_ref_id
                                                        , EST_ID
                                                        , deptPosScale.NewIdx(COMP_ID, ESTTERM_REF_ID, dept_ref_id, EST_ID)
                                                        , pos_id
                                                        , pos_value
                                                        , scale_id
                                                        , DateTime.Now
                                                        , EMP_REF_ID);
                }
                
                if (isOK)
                {
                    GridBinding3(COMP_ID, ESTTERM_REF_ID, dept_ref_id, EST_ID);
                    hdfEstPosSeq.Value = "";
                }
                else
                {
                    ltrScript.Text = JSHelper.GetAlertScript("저장 중 오류가 발생하였습니다.");
                }
			}
			catch ( Exception ex )
			{
				ltrScript.Text = JSHelper.GetAlertScript("저장 중 오류가 발생하였습니다.");
			}
		}
    }

    protected void ibnRemove_Click(object sender, ImageClickEventArgs e)
    {
        Biz_DeptPosScales deptPosScale   = new Biz_DeptPosScales();
        DataTable dataTable              = deptPosScale.GetDataTableSchema();

        dataTable                        = UltraGridUtility.GetDataTableByCheckValue( UltraWebGrid3
                                                                                    , "cBox"
                                                                                    , "selchk"
                                                                                    , new string[] {"DEPT_REF_ID", "SEQ" }
                                                                                    , dataTable);

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제하려는 항목을 선택하세요.");
            return;
        }

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
        }

        bool isOK = deptPosScale.RemoveDeptPosScale(dataTable);

        if (isOK)
        {
            GridBinding3(COMP_ID, ESTTERM_REF_ID, DataTypeUtility.GetToInt32(hdfDeptRefID.Value), EST_ID);
            hdfEstPosSeq.Value = "";
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되지 않았습니다.");
        }
    }

    protected void ibnInit1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ibnInit2_Click(object sender, ImageClickEventArgs e)
    {
        Biz_DeptPosScales deptPosScale  = new Biz_DeptPosScales();
        Biz_DeptInfos deptInfo          = new Biz_DeptInfos();
        DataTable dataTable             = deptPosScale.GetDataTableSchema();
        DataTable dtDept                = deptInfo.GetDataTableSchema();

        dtDept.Columns.Add("COMP_ID", typeof(int));
        dtDept.Columns.Add("EST_ID", typeof(string));
        dtDept.Columns.Add("ESTTERM_REF_ID", typeof(int));

        dtDept      = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid2
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "DEPT_REF_ID" }
                                                            , dtDept);

        if(dtDept.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("초기화하려는 부서를 선택하세요.");
            return;
        }

        foreach(DataRow dataRow in dtDept.Rows) 
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
        }

        bool isOK = deptPosScale.InitDept(dtDept);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 선택부서를 초기화 하였습니다.");

            GridBinding2(COMP_ID, ESTTERM_REF_ID, EST_ID);
            UltraWebGrid3.Clear();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되지 않았습니다.");
        }
    }
}
