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

public partial class EST_EST040102 : EstPageBase
{
    private string EST_ID;
	public string WEIGHT_TYPE;

    private DataTable _dtEstDetail	= null;
	private DataTable _dtPosDetail	= null;

	private DataTable dtPositionAll = null;
	private Hashtable htPositionName = null;

	protected void Page_Load( object sender, EventArgs e )
	{
        COMP_ID		        = WebUtility.GetRequestByInt("COMP_ID");
        EST_ID				= WebUtility.GetRequest("EST_ID");
		ESTTERM_REF_ID		= WebUtility.GetRequestByInt("ESTTERM_REF_ID");
		WEIGHT_TYPE			= WebUtility.GetRequest("WEIGHT_TYPE");

		if (!Page.IsPostBack)
		{
            EST_JOB_ID      = "JOB_15";

			View(COMP_ID);

			TextBoxCommon.SetOnlyPercent( txtWeightAll );
			TextBoxCommon.SetOnlyPercent( txtWeightPos );

            ibnConfirm1.Attributes.Add("onclick", "return confirm('설정한 평가방법을 확정하시겠습니까?')");
            ibnConfirmCancel1.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");
            ibnConfirm2.Attributes.Add("onclick", "return confirm('설정한 평가방법을 확정하시겠습니까?')");
            ibnConfirmCancel2.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");
            ibnSavePosAll.Attributes.Add("onclick", "return confirm('현재 설정을 모든 부서에 일괄 적용하시겠습니까?')");
            ibnSaveAll2.Attributes.Add("onclick", "return confirm('현재 설정을 모든 부서에 일괄 적용하시겠습니까?')");
            ibnRemove.Attributes.Add("onclick", "return confirm('삭제하시겠습니까?')");
            ibnSave2.Attributes.Add("onclick", "return confirm('저장하시겠습니까?')");
            ibnSave3.Attributes.Add("onclick", "return confirm('저장하시겠습니까?')");
            ibnInit2.Attributes.Add("onclick", "return confirm('선택된 부서를 초기화 하시겠습니까?')");
		}

		Biz_Positions positions = new Biz_Positions();
		dtPositionAll           = positions.GetPositionAll();

		ltrScript.Text          = "";
	}

	private bool CheckParam()
	{
		if (   ESTTERM_REF_ID   != 0 
            && EST_ID.Length    != 0
            && !WEIGHT_TYPE.Equals(""))
			return true;

		return false;
	}

	private void View(int comp_id)
	{
		if ( CheckParam() == false )
			return;

		if (	WEIGHT_TYPE.Equals( WeightType.DPT.ToString() ) == true 
			 || WEIGHT_TYPE.Length == 0 )
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

		GridBinding2(comp_id, ESTTERM_REF_ID, EST_ID );

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

		GridBinding3(comp_id, ESTTERM_REF_ID, 0, EST_ID );
        GridBinding22(comp_id, ESTTERM_REF_ID, EST_ID );

		DropDownListCommom.BindPositionInfo(ddlPositionType);
		DropDownListCommom.BindPositionValue( ddlPositionValue
											, WebUtility.GetByValueDropDownList(ddlPositionType));

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm2
                                            , ibnConfirmCancel2);
	}

    protected void ibnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        bool isJobOK = EstJobUtility.SetConfirmButtonVisible( COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_JOB_ID
                                                            , (plDept.Visible) ? ibnConfirm1 : ibnConfirm2
                                                            , (plDept.Visible) ? ibnConfirmCancel1 : ibnConfirmCancel2
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
                                                            , (plDept.Visible) ? ibnConfirm1 : ibnConfirm2
                                                            , (plDept.Visible) ? ibnConfirmCancel1 : ibnConfirmCancel2
                                                            , "N"
                                                            , DateTime.Now
                                                            , EMP_REF_ID
                                                            , ltrScript);

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정을 취소하였습니다.");
    }

	#region Tab2 (가중치관리) - 부서별
	private void GridBinding2(int comp_id, int estterm_ref_id, string est_id )
	{
		Biz_DeptEstDetails deptEstDetail    = new Biz_DeptEstDetails();
		_dtEstDetail                        = deptEstDetail.GetDeptEstDetail(comp_id, estterm_ref_id, 0, est_id).Tables[0];

		Biz_DeptPosDetails deptPosDetail    = new Biz_DeptPosDetails();
		_dtPosDetail                        = deptPosDetail.GetDeptPosDetail(comp_id, estterm_ref_id, 0, est_id).Tables[0];

        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource            = BizUtility.GetDeptTree("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" );
        UltraWebGrid1.DataBind();
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
        DataRowView drw             = (DataRowView) e.Data;

        TemplatedColumn weight_col  = (TemplatedColumn)e.Row.Band.Columns.FromKey("TXT_WEIGHT");
        TextBox txtWeight           = (TextBox)((CellItem)weight_col.CellItems[e.Row.BandIndex]).FindControl("txtWeightDept");

		TextBoxCommon.SetOnlyPercent( txtWeight );

        DataRow[] drArr = _dtEstDetail.Select( string.Format( @"ESTTERM_REF_ID  = {0}                                        
                                                            AND DEPT_REF_ID     = {1}
                                                            AND EST_ID          = '{2}'"
                                                            , ESTTERM_REF_ID
                                                            , drw["DEPT_REF_ID"]
                                                            , EST_ID ) );

		if ( drArr.Length > 0 )
		{
			txtWeight.Text = drArr[0]["WEIGHT"].ToString();

			if ( drArr[0]["WEIGHT"].ToString().Length == 0 )
			{
				e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i03.gif'>";
			}
			else
			{
				e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i02.gif'>";
			}
		}
		else
		{
			e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i03.gif'>";
		}
	}

    private void SaveWeightData( string weight )
    {
        Biz_DeptEstDetails deptEstDetail = new Biz_DeptEstDetails();

        TextBox txtWeight;
        UltraGridRow row;
        TemplatedColumn col;

        DataTable dtEstDept = deptEstDetail.GetDataTableSchema();
        DataRow drEstDept   = null;

        for ( int i = 0; i < UltraWebGrid1.Rows.Count; i++ )
        {
            row         = UltraWebGrid1.Rows[i];
            col         = (TemplatedColumn)row.Band.Columns.FromKey( "TXT_WEIGHT" );
            txtWeight   = (TextBox)((CellItem)col.CellItems[row.BandIndex]).FindControl( "txtWeightDept" );

            drEstDept                      = dtEstDept.NewRow();
            drEstDept["COMP_ID"]           = COMP_ID;
            drEstDept["ESTTERM_REF_ID"]    = ESTTERM_REF_ID;
            drEstDept["DEPT_REF_ID"]       = row.Cells.FromKey("DEPT_REF_ID").Value;
            drEstDept["EST_ID"]            = EST_ID;
            drEstDept["DATE"]              = DateTime.Now;
            drEstDept["USER"]              = EMP_REF_ID;

			if ( weight.Length == 0 )
			{
				drEstDept["WEIGHT"] = txtWeight.Text.Trim();
			}
			else
			{
				drEstDept["WEIGHT"] = weight;
			}

            dtEstDept.Rows.Add( drEstDept );
        }

        bool isOK = deptEstDetail.SaveDeptEstWithWeight(dtEstDept);

        if (isOK)
        {
            GridBinding2(COMP_ID, ESTTERM_REF_ID, EST_ID);
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript( "저장 중 오류가 발생하였습니다." );
        }
    }
    // 가중치 설정 저장
	protected void ibnSave2_Click( object sender, ImageClickEventArgs e )
	{
		SaveWeightData("");
	}

	protected void ibnSaveAll2_Click( object sender, ImageClickEventArgs e )
	{
		SaveWeightData( txtWeightAll.Text.Trim() );
	}
	#endregion

	#region Tab2 (가중치관리) - 직급별
	private void GridBinding22(int comp_id, int estterm_ref_id, string est_id )
	{
		Biz_DeptEstDetails deptEstDetail    = new Biz_DeptEstDetails();
		_dtEstDetail                        = deptEstDetail.GetDeptEstDetail(comp_id, estterm_ref_id, 0, est_id ).Tables[0];

		Biz_DeptPosDetails deptPosDetail    = new Biz_DeptPosDetails();
		_dtPosDetail                        = deptPosDetail.GetDeptPosDetail(comp_id, estterm_ref_id, 0, est_id ).Tables[0];

        UltraWebGrid2.Clear();
        UltraWebGrid2.DataSource           = BizUtility.GetDeptTree("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" );
        UltraWebGrid2.DataBind();
	}

	protected void UltraWebGrid2_SelectedRowsChange( object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e )
	{
		if ( e.SelectedRows.Count > 0 )
		{
			hdfDeptRefID.Value   = e.SelectedRows[0].Cells.FromKey( "DEPT_REF_ID" ).Value.ToString();
			int intEstDeptRefID     = DataTypeUtility.GetToInt32( hdfDeptRefID.Value );

			GridBinding3(COMP_ID, ESTTERM_REF_ID, intEstDeptRefID, EST_ID);
		}
	}

	private void BindHashTablePositionName()
	{
		htPositionName = new Hashtable();

		for ( int i = 0; i < ddlPositionType.Items.Count; i++ )
		{
			htPositionName.Add(ddlPositionType.Items[i].Value, ddlPositionType.Items[i].Text);
		}
	}

	protected void ddlPositionType_SelectedIndexChanged( object sender, EventArgs e )
	{
		DropDownListCommom.BindPositionValue( ddlPositionValue
			                                , WebUtility.GetByValueDropDownList(ddlPositionType));
	}

	private void GridBinding3(int comp_id, int estterm_ref_id, int dept_ref_id, string est_id)
	{
		if ( dept_ref_id == 0 )
			return;

		Biz_DeptPosDetails deptPosDetail    = new Biz_DeptPosDetails();
		_dtPosDetail                        = deptPosDetail.GetDeptPosDetail(comp_id, estterm_ref_id, dept_ref_id, est_id).Tables[0];

        UltraWebGrid3.Clear();
		UltraWebGrid3.DataSource		    = _dtPosDetail;
		UltraWebGrid3.DataBind();
	}

    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw             = (DataRowView) e.Data;

        // 상태
        DataRow[] drArr = _dtPosDetail.Select( string.Format( @"ESTTERM_REF_ID  = {0}
                                                            AND DEPT_REF_ID     = {1}
                                                            AND EST_ID          = '{2}'"
                                                            , ESTTERM_REF_ID
                                                            , drw["DEPT_REF_ID"]
                                                            , EST_ID ) );

		if ( drArr.Length > 0 )
		{
            e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i02.gif'>";
		}
		else
		{
			e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i03.gif'>";
		}
    }

	protected void UltraWebGrid3_InitializeRow( object sender, RowEventArgs e )
	{
        DataRowView drw             = (DataRowView) e.Data;

		// 구분
		if ( htPositionName == null )
		{
			BindHashTablePositionName();
		}
		e.Row.Cells.FromKey("NAMEPOS_NAME").Value = htPositionName[drw["POS_ID"].ToString()].ToString();

		// 직급명
		DataRow[] drName = dtPositionAll.Select( string.Format( @"POS    = '{0}' 
                                                              AND POS_ID = '{1}'"
															, drw["POS_ID"].ToString()
															, drw["POS_VALUE"].ToString() ) );

		if ( drName.Length > 0 )
		{
			e.Row.Cells.FromKey("NAMEPOS_VALUE").Value = drName[0]["POS_NAME"].ToString();
		}
	}

	protected void UltraWebGrid3_SelectedRowsChange( object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e )
	{
		if ( e.SelectedRows.Count > 0 )
		{
			hdfEstPosEstTermRefID.Value = e.SelectedRows[0].Cells.FromKey("ESTTERM_REF_ID").Value.ToString();
			hdfEstPosEstDeptRefID.Value = e.SelectedRows[0].Cells.FromKey("DEPT_REF_ID").Value.ToString();
			hdfEstPosEstID.Value        = e.SelectedRows[0].Cells.FromKey("EST_ID").Value.ToString();
			hdfEstPosSeq.Value          = e.SelectedRows[0].Cells.FromKey("SEQ").Value.ToString();

            WebUtility.FindByValueDropDownList(ddlPositionType, e.SelectedRows[0].Cells.FromKey("POS_ID").Value);
            WebUtility.FindByValueDropDownList(ddlPositionValue, e.SelectedRows[0].Cells.FromKey("POS_VALUE").Value);
            txtWeightPos.Text           = e.SelectedRows[0].Cells.FromKey("WEIGHT").Value.ToString();
		}
	}

	private bool CheckInsertWeightPos()
	{
		if ( hdfDeptRefID.Value.Length == 0 )
		{
            ltrScript.Text = JSHelper.GetAlertScript("부서를 선택해주세요.");
			return false;
		}

		if ( txtWeightPos.Text.Trim().Length == 0 )
		{
            ltrScript.Text = JSHelper.GetAlertScript("가중치를 입력해주세요.");
			return false;
		}

		return true;
	}

	private void ClearControlValues()
	{
        WebUtility.FindByValueDropDownList(ddlPositionValue, "");

		txtWeightPos.Text               = "";
		hdfEstPosEstTermRefID.Value     = "";
		hdfEstPosEstDeptRefID.Value     = "";
		hdfEstPosEstID.Value            = "";
		hdfEstPosSeq.Value              = "";
	}

	protected void ibnSave3_Click( object sender, ImageClickEventArgs e )
	{
		if ( CheckInsertWeightPos())
		{
			Biz_DeptPosDetails deptPosDetail = new Biz_DeptPosDetails();

			int estterm_ref_id          = ESTTERM_REF_ID;
			int dept_ref_id             = DataTypeUtility.GetToInt32(hdfDeptRefID.Value);
			string est_id               = EST_ID;
			string pos_id               = WebUtility.GetByValueDropDownList(ddlPositionType);
			string pos_value            = WebUtility.GetByValueDropDownList(ddlPositionValue);
			float weight                = DataTypeUtility.GetToFloat(txtWeightPos.Text.Trim());
            bool isOK                   = false;

			try
			{
				bool isDuplicate = deptPosDetail.IsExist( COMP_ID
                                                        , estterm_ref_id
														, dept_ref_id
														, est_id
														, 0
														, pos_id
														, pos_value );

				if (isDuplicate)
				{
                    if(hdfEstPosSeq.Value.Equals(""))
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("변경하실 직급 구분을 선택하세요.");
                        return;
                    }

                    isOK = deptPosDetail.ModifyDeptPosDetail( COMP_ID
                                                            , estterm_ref_id
															, dept_ref_id
															, est_id
															, DataTypeUtility.GetToInt32(hdfEstPosSeq.Value)
															, pos_id
															, pos_value
															, weight
															, DateTime.Now
															, EMP_REF_ID );
				}
                else 
                {
                    isOK = deptPosDetail.AddDeptPosDetail(    COMP_ID
                                                            , estterm_ref_id
															, dept_ref_id
															, est_id
															, deptPosDetail.NewIdx(COMP_ID, estterm_ref_id, dept_ref_id, est_id)
															, pos_id
															, pos_value
															, weight
															, DateTime.Now
															, EMP_REF_ID );
                }
				
				if (isOK)
				{
					GridBinding3(COMP_ID, ESTTERM_REF_ID, dept_ref_id, EST_ID);
					ClearControlValues();
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

	private bool CheckRemoveWeightPos()
	{
		if (   hdfEstPosEstTermRefID.Value.Length   == 0
			&& hdfEstPosEstDeptRefID.Value.Length   == 0
			&& hdfEstPosEstID.Value.Length          == 0
			&& hdfEstPosSeq.Value.Length            == 0 )
		{
            ltrScript.Text = JSHelper.GetAlertScript("직급명을 선택해주세요.");
			return false;
		}

		return true;
	}

	protected void ibnRemove_Click( object sender, ImageClickEventArgs e )
	{
        Biz_DeptPosDetails deptPosDetail = new Biz_DeptPosDetails();
        DataTable dataTable              = deptPosDetail.GetDataTableSchema();

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

        bool isOK = deptPosDetail.RemoveDeptPosDetail(dataTable);

        if (isOK)
        {
            GridBinding3(COMP_ID, ESTTERM_REF_ID, DataTypeUtility.GetToInt32(hdfEstPosEstDeptRefID.Value), EST_ID);
            ClearControlValues();
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되지 않았습니다.");
        }
	}

    protected void lbnSaveDPT_Click(object sender, EventArgs e)
    {
        Biz_DeptEstDetails deptEstDetail = new Biz_DeptEstDetails();

        DataTable dtEstDept     = deptEstDetail.GetDataTableSchema();
        DataRow drEstDept       = null;
        string[] dept_values    = hdfDeptID.Value.Split(',');

        foreach (string dept_value in dept_values)
        {
            drEstDept                      = dtEstDept.NewRow();

            drEstDept["COMP_ID"]           = COMP_ID;
            drEstDept["ESTTERM_REF_ID"]    = ESTTERM_REF_ID;
            drEstDept["DEPT_REF_ID"]       = DataTypeUtility.GetToInt32(dept_value);
            drEstDept["EST_ID"]            = EST_ID;
            drEstDept["DATE"]              = DateTime.Now;
            drEstDept["USER"]              = EMP_REF_ID;
            drEstDept["WEIGHT"]            = txtWeightAll.Text.Trim();

            dtEstDept.Rows.Add( drEstDept );
        }

        bool isOK = deptEstDetail.SaveDeptEstWithWeight(dtEstDept);

        if (isOK)
        {
            GridBinding2(COMP_ID, ESTTERM_REF_ID, EST_ID);
            ltrScript.Text = JSHelper.GetAlertScript("선택된 부서의 가중치를 일괄 적용하였습니다.");
            hdfDeptID.Value = "";
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript( "저장 중 오류가 발생하였습니다." );
        }
    }
    protected void lbnSavePOS_Click(object sender, EventArgs e)
    {
        Biz_DeptPosDetails deptPosDetail = new Biz_DeptPosDetails();
        Biz_DeptInfos deptInfo           = new Biz_DeptInfos();
        DataTable dataTable              = deptPosDetail.GetDataTableSchema();
        DataTable dtDept                 = deptInfo.GetDataTableSchema();
        DataRow drRow                    = null;
        string[] dept_values             = hdfDeptID.Value.Split(',');

        dataTable   = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid3
                                                            , new string[] { "SEQ", "POS_ID", "POS_VALUE", "WEIGHT" }
                                                            , dataTable);

        foreach(string dept_value in dept_values) 
        {
            drRow                   = dtDept.NewRow();
            drRow["DEPT_REF_ID"]    = DataTypeUtility.GetToInt32(dept_value);
            dtDept.Rows.Add(drRow);
        }

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("적용하려는 부서별 가중치가 없습니다.");
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

        bool isOK = deptPosDetail.SaveDeptPosDetailAll(dtDept, dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택 부서의 가중치를 일괄 적용하였습니다.");

            GridBinding22(COMP_ID, ESTTERM_REF_ID, EST_ID );
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
        Biz_DeptPosDetails deptPosDetail = new Biz_DeptPosDetails();
        Biz_DeptInfos deptInfo           = new Biz_DeptInfos();
        DataTable dataTable              = deptPosDetail.GetDataTableSchema();
        DataTable dtDept                 = deptInfo.GetDataTableSchema();

        dataTable   = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid3
                                                            , new string[] { "SEQ", "POS_ID", "POS_VALUE", "WEIGHT" }
                                                            , dataTable);

        dtDept      = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid2
                                                            , new string[] { "DEPT_REF_ID" }
                                                            , dtDept);

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("적용하려는 부서별 가중치가 없습니다.");
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

        bool isOK = deptPosDetail.SaveDeptPosDetailAll(dtDept, dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("모든 부서의 가중치를 일괄 적용하였습니다.");

            GridBinding22(COMP_ID, ESTTERM_REF_ID, EST_ID );
            UltraWebGrid3.Clear();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리 않았습니다.");
        }
    }

    

    protected void ibnInit1_Click(object sender, ImageClickEventArgs e)
    {
        
    }

    protected void ibnInit2_Click(object sender, ImageClickEventArgs e)
    {
        Biz_DeptPosDetails deptPosDetail = new Biz_DeptPosDetails();
        Biz_DeptInfos deptInfo           = new Biz_DeptInfos();
        DataTable dataTable              = deptPosDetail.GetDataTableSchema();
        DataTable dtDept                 = deptInfo.GetDataTableSchema();

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

        bool isOK = deptPosDetail.InitDept(dtDept);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 선택부서를 초기화 하였습니다.");

            GridBinding22(COMP_ID, ESTTERM_REF_ID, EST_ID );
            UltraWebGrid3.Clear();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리 않았습니다.");
        }
    }

	#endregion

    
}
