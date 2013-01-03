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
using System.Drawing;

using MicroBSC.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.WebDataInput;
using MicroBSC.QueryEngine.QueryBuilder;


public partial class BSC_BSC0602M1 : AppPageBase
{
    #region =========== [Declare Variables] ============
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = this.lBtnReload.ClientID.Replace('_', '$');
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public int IVersionNo
    {
        get
        {
            if (ViewState["VERSION_NO"] == null)
            {
                ViewState["VERSION_NO"] = GetRequestByInt("VERSION_NO", 1);
            }

            return (int)ViewState["VERSION_NO"];
        }
        set
        {
            ViewState["VERSION_NO"] = value;
        }
    }

    public string IDiCode
    {
        get
        {
            if (ViewState["DICODE"] == null)
            {
                ViewState["DICODE"] = GetRequest("DICODE", "");
            }

            return (string)ViewState["DICODE"];
        }
        set
        {
            ViewState["DICODE"] = value;
        }
    }

    public string IisValidQuery
    {
        get
        {
            if (ViewState["ISVALID_QUERY"] == null)
            {
                ViewState["ISVALID_QUERY"] = GetRequest("ISVALID_QUERY", "N");
            }

            return (string)ViewState["ISVALID_QUERY"];
        }
        set
        {
            ViewState["ISVALID_QUERY"] = value;
        }
    }

    #endregion

    #region =========== [Page Initialize] ============
    protected void Page_PreInit(object sender, EventArgs e)
    {
        string sStyUrl = "<link rel=\"stylesheet\" href=\"../_common/css/Calc.css\" type=\"text/css\" />";
        this.Master.Page.RegisterStartupScript("CALC_CSS", sStyUrl);

        string sMetaEnter = "<meta http-equiv=\"Page-Enter\" content=\"blendTrans(Duration=0.3)\" />";
        string sMetaExit = "<meta http-equiv=\"Page-Exit\" content=\"blendTrans(Duration=0.3)\" />";

        this.Master.Page.RegisterStartupScript("Page_Enter", sMetaEnter);
        this.Master.Page.RegisterStartupScript("Page_Exit", sMetaExit);

        //((ScriptManager)this.Master.Controls("ScriptManager1")).EnablePartialRendering = true;
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager scptMgn = (ScriptManager)this.Master.FindControl("ScriptManager1");

        //scptMgn.RegisterAsyncPostBackControl(btnD0);
        //scptMgn.RegisterAsyncPostBackControl(btnD1);
        //scptMgn.RegisterAsyncPostBackControl(btnD2);
        //scptMgn.RegisterAsyncPostBackControl(btnD3);
        //scptMgn.RegisterAsyncPostBackControl(btnD4);
        //scptMgn.RegisterAsyncPostBackControl(btnD5);
        //scptMgn.RegisterAsyncPostBackControl(btnD6);
        //scptMgn.RegisterAsyncPostBackControl(btnD7);
        //scptMgn.RegisterAsyncPostBackControl(btnD8);
        //scptMgn.RegisterAsyncPostBackControl(btnD9);

        ltrScript.Text = "";
        if (!IsPostBack)
        {
            this.InitForm();
        }
    }

    public void InitForm()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetComDeptDropDownList(ddlEstDept, true);
        PageUtility.FindByValueDropDownList(ddlEstDept, BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));

        WebCommon.SetSettingYnDropDownList(ddlIS_SET_QUERY, true);

        txtField_Ms.Attributes.Add("onkeydown", "return ProhibitKey(this);");
        txtField_Ms.Attributes.Add("onkeydown", "return ProhibitKey(this);");
        txtCondition_Ms.Attributes.Add("onkeydown", "return ProhibitKey(this);");
        txtCondition_Ts.Attributes.Add("onkeydown", "return ProhibitKey(this);");
        txtCondition_SS.Attributes.Add("onkeydown", "return ProhibitKey(this);");

        lblSuccessAl.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
        lblSuccessMs.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
        lblSuccessTs.Style.Add(HtmlTextWriterStyle.TextAlign, "left");

        rdoField.Checked     = true;
        rdoCondition.Checked = false;

        this.SetQueryBox();
    }

    #endregion

    #region =========== [Internal Function] ============
    /// <summary>
    /// 지표상세정보 조회
    /// </summary>
    public void setKpiData()
    {
        if (ddlEstTermInfo.Items.Count < 1)
        {
            PageUtility.AlertMessage("등록된 평가기간이 없습니다.");
            return;
        }

        Biz_Bsc_Interface_Kpi_Query objBSC = new Biz_Bsc_Interface_Kpi_Query();
        DataSet rDs = objBSC.GetQueryMappingStatus
                    ( PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                    , this.IDiCode
                    , txtKPICode.Text
                    , txtKPIName.Text
                    , txtChamName.Text
                    , ""
                    , "Y"
                    , PageUtility.GetByValueDropDownList(ddlIS_SET_QUERY));

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = rDs;
        ugrdKpiList.DataBind();
    }

    /// <summary>
    /// 기본정보 조회
    /// </summary>
    public void SetFormData()
    {
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        lblKpiCode.Text    = objBSC.Ikpi_code;
        lblKpiName.Text    = objBSC.Ikpi_name;
        txtCalcFormMs.Text = objBSC.Icalc_form_ms;
        txtCalcFormTs.Text = objBSC.Icalc_form_ts;

        Biz_Bsc_Interface_Kpi_Query objQry = new Biz_Bsc_Interface_Kpi_Query(this.IKpiRefID, this.IDiCode);
        this.IDiCode          =  objQry.IDicode;
        txtDiCode.Text        =  objQry.IDicode;
        this.IVersionNo       =  1 ; //objQry.IVersion_No; -- 차후에 버젼관리 연결 
        txtField_Ss.Text      =  objQry.IResult_Field_Al ; 
        txtCondition_SS.Text  =  objQry.IResult_Where_Al ; 
        txtField_Ms.Text      =  objQry.IResult_Field_Ms ; 
        txtCondition_Ms.Text  =  objQry.IResult_Where_Ms ; 
        txtField_Ts.Text      =  objQry.IResult_Field_Ts ; 
        txtCondition_Ts.Text  =  objQry.IResult_Where_Ts ; 
        txtQUERY_AL.Text      =  objQry.IQuery_Al        ; 
        txtQUERY_MS.Text      =  objQry.IQuery_Ms        ; 
        txtQUERY_TS.Text      =  objQry.IQuery_Ts        ;
        this.IisValidQuery    =  objQry.IIsvalid_Query   ;

        if (this.IVersionNo > 0)
        {
            Biz_Bsc_Interface_Dicode objCode = new Biz_Bsc_Interface_Dicode(this.IDiCode, gUserInfo.Emp_Ref_ID);
            txtDiName.Text = objCode.IName;
            this.IType     = "U";
            this.SetColumnList();
        }
        else
        {
            txtDiCode.Text = "";
            txtDiName.Text = "";
            this.IDiCode   = "";
            this.IType     = "A";
        }


        //int iTxrUser = gUserInfo.Emp_Ref_ID;
        //Biz_Bsc_Interface_Dicode objBSC = new Biz_Bsc_Interface_Dicode(this.IDiCode, iTxrUser);
        //txtDICODE.Text      = objBSC.IDicode;
        //txtDINAME.Text      = objBSC.IName;
        //txtDEFINITION.Text  = objBSC.IDefinition;
        //lblUseYN.Text       = objBSC.IUse_Yn;
        //txtDICODE.BackColor = Color.WhiteSmoke;
        //txtDICODE.ReadOnly  = true;
        //this.IType          = (objBSC.IUse_Yn=="Y") ? "U" : "R";

        //Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
        //DataTable dtRtn = objCol.GetColumnInfoPerDicode(this.IDiCode, iTxrUser);

        //ugrdDIColumn.Clear();
        //ugrdDIColumn.DataSource = dtRtn.DefaultView;
        //ugrdDIColumn.DataBind();

        this.SetButton();
    }

    /// <summary>
    /// 버튼처리
    /// </summary>
    public void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnClear.Visible  = false;
            iBtnDelete.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnInsert.Visible = true;
            iBtnReUse.Visible  = false;
        }
        else if (this.IType == "U")
        { 
            iBtnClear.Visible  = false;
            iBtnDelete.Visible = false;
            iBtnUpdate.Visible = true;
            iBtnInsert.Visible = false;
            iBtnReUse.Visible  = false;
        }
        else if (this.IType == "D")
        { 
            iBtnClear.Visible  = false;
            iBtnDelete.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnInsert.Visible = false;
            iBtnReUse.Visible  = false;
        }
        else
        {
            iBtnClear.Visible  = false;
            iBtnDelete.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnInsert.Visible = false;
            iBtnReUse.Visible  = false;
        }
    }

    /// <summary>
    /// 조회필드 조건필드 설정
    /// </summary>
    public void SetColumnList()
    {
        Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
        DataSet rDs = objCol.GetAllList(this.IDiCode, gUserInfo.Emp_Ref_ID);
        
        lstField.Items.Clear();
        lstCondition.Items.Clear();
        lstListField.Items.Clear();

        // Dicode Column 정보 세팅
        if (rDs.Tables.Count > 0)
        {
            int iRow = rDs.Tables[0].Rows.Count;
            string sKey = "";
            string sVal = "";
            string sUse = "N";
            bool bDigit = false;

            for (int i = 0; i < iRow; i++)
            {
                sKey = rDs.Tables[0].Rows[i]["COLUMN_ID"].ToString();
                sVal = rDs.Tables[0].Rows[i]["COLUMN_ALIAS"].ToString();
                sUse = rDs.Tables[0].Rows[i]["USE_YN"].ToString();
                bDigit = (sKey.Substring(0, 7) == "DVALUES") ? true : false;

                if (sUse == "Y" && bDigit)
                {
                    lstField.Items.Add(new ListItem(sVal, sKey));
                    lstCondition.Items.Add(new ListItem(sVal, sKey));
                }
                else if (sUse == "Y" && !bDigit)
                {
                    lstCondition.Items.Add(new ListItem(sVal, sKey));
                }

                lstListField.Items.Add(new ListItem(sVal, sKey));
            }
        }

        // 조건식의 경우 조회조건 파라미터 추가
        if (lstField.Items.Count > 0)
        {
            lstCondition.Items.Add(new ListItem("평가월", "RDTERM"));
            lstCondition.Items.Add(new ListItem("@평가시작월", QueryOperator.ParamFirstYmd));
            lstCondition.Items.Add(new ListItem("@현재평가월", QueryOperator.ParamCurrYmd));
        }

        // 실적데이터 리스트 필드 세팅
        // dicode 정의 후 지표에서 컬럼설정시 정의된 컬럼은 그대로 사용하고 조건식만 변경한다.
        // 즉 같은 dicode를 사용하는 지표의 컬럼은 모두 동일하다
        string sField_Ss = "";
        int iFRow = lstListField.Items.Count;
        for (int i = 0; i < iFRow; i++)
        {
            if (i == 0)
            {
                sField_Ss += QueryOperator.LBracket + lstListField.Items[i].Text + QueryOperator.RBracket;
            }
            else
            {
                sField_Ss += ", " + QueryOperator.LBracket + lstListField.Items[i].Text + QueryOperator.RBracket;
            }
        }

        txtField_Ss.Text = sField_Ss;
    }

    /// <summary>
    /// 쿼리생성
    /// </summary>
    public void MakeQuerySentense()
    {
        string sField_Ms = txtField_Ms.Text;
        string sField_Ts = txtField_Ts.Text;
        string sField_Ss = txtField_Ss.Text;
        string sCondi_Ms = txtCondition_Ms.Text;
        string sCondi_Ts = txtCondition_Ts.Text;
        string sCondi_Ss = txtCondition_SS.Text;

        string sField    = "";
        txtQUERY_AL.Text = "";
        txtQUERY_MS.Text = "";
        txtQUERY_TS.Text = "";

        int iFRow = lstField.Items.Count;
        for (int i = 0; i < iFRow; i++)
        {
            sField = QueryOperator.LBracket + lstField.Items[i].Text + QueryOperator.RBracket;
            sField_Ms = sField_Ms.Replace(sField, lstField.Items[i].Value);
            sField_Ts = sField_Ts.Replace(sField, lstField.Items[i].Value);
        }

        iFRow = lstCondition.Items.Count;
        for (int i = 0; i < iFRow; i++)
        {
            sField = QueryOperator.LBracket + lstCondition.Items[i].Text + QueryOperator.RBracket;
            sCondi_Ms = sCondi_Ms.Replace(sField, lstCondition.Items[i].Value);
            sCondi_Ts = sCondi_Ts.Replace(sField, lstCondition.Items[i].Value);
            sCondi_Ss = sCondi_Ss.Replace(sField, lstCondition.Items[i].Value);
        }

        iFRow = lstListField.Items.Count;
        for (int i = 0; i < iFRow; i++)
        {
            sField = QueryOperator.LBracket + lstListField.Items[i].Text + QueryOperator.RBracket;
            sField_Ss = sField_Ss.Replace(sField, lstListField.Items[i].Value);
        }

        txtQUERY_AL.Text = this.MakeQuery(sField_Ss, sCondi_Ss);
        txtQUERY_MS.Text = this.MakeQuery(sField_Ms, sCondi_Ms);
        txtQUERY_TS.Text = this.MakeQuery(sField_Ts, sCondi_Ts);
    }

    /// <summary>
    /// SELECT 문장 만들기
    /// </summary>
    /// <param name="sField"></param>
    /// <param name="sCondition"></param>
    /// <returns></returns>
    public string MakeQuery(string sField, string sCondition)
    {
        if (sField.Length < 1)
        {
            return "";
        }

        sField  = QueryOperator.QryCluseSelect + sField;
        sField += "\n" + QueryOperator.QryCluseFrom + QueryOperator.QryCluseTable;
        if (sCondition.Length > 0)
        {
            sField += "\n" + QueryOperator.QryCluseWhere + sCondition;
            sField += "\n" + QueryOperator.LogicOperAnd + "DICODE = '" + this.IDiCode + "'";
        }
        else
        {
            sField += "\n" + QueryOperator.QryCluseWhere + "DICODE = '" + this.IDiCode + "'";
        }

        return sField;
    }

    /// <summary>
    /// 쿼리작성 박스 선택
    /// </summary>
    public void SetQueryBox()
    {
        string sGubun = PageUtility.GetByValueRadioButtonList(rdoTermType);
        if (sGubun == "SS")
        {
            txtField_Ms.Visible = false;
            txtField_Ts.Visible = false;
            txtField_Ss.Visible = true;

            txtCondition_Ms.Visible = false;
            txtCondition_Ts.Visible = false;
            txtCondition_SS.Visible = true;

            rdoField.Checked        = false;
            rdoField.Enabled        = false;

            rdoCondition.Checked    = true;
            rdoCondition.Enabled    = false;

            pnlOperator.Visible     = true;
            pnlQuery.Visible        = false;
        }
        else if (sGubun == "MS")
        {
            txtField_Ms.Visible = true;
            txtField_Ts.Visible = false;
            txtField_Ss.Visible = false;

            txtCondition_Ms.Visible = true;
            txtCondition_Ts.Visible = false;
            txtCondition_SS.Visible = false;

            rdoField.Enabled     = true;
            rdoCondition.Enabled = true;

            pnlOperator.Visible     = true;
            pnlQuery.Visible        = false;
        }
        else if (sGubun == "TS")
        {
            txtField_Ms.Visible = false;
            txtField_Ts.Visible = true;
            txtField_Ss.Visible = false;

            txtCondition_Ms.Visible = false;
            txtCondition_Ts.Visible = true;
            txtCondition_SS.Visible = false;

            rdoField.Enabled     = true;
            rdoCondition.Enabled = true;

            pnlOperator.Visible     = true;
            pnlQuery.Visible        = false;
        }
        else if (sGubun == "QR")
        { 
            pnlOperator.Visible     = false;
            pnlQuery.Visible        = true;
            this.MakeQuerySentense();
            this.SetQueryValidate();
        }
    }

    /// <summary>
    /// Query 저장
    /// </summary>
    public void TrxFormData()
    {
        if (!this.ValidateForm())
        {
            return;
        }

        Biz_Bsc_Interface_Kpi_Query objQry = new Biz_Bsc_Interface_Kpi_Query();
        objQry.IKpi_Ref_Id      = this.IKpiRefID;
        objQry.IDicode          = this.IDiCode;
        objQry.IVersion_No      = 1;  //this.IVersionNo; -- 차후버젼관리 연결
        objQry.IActive_Yn       = "Y";
        objQry.IResult_Field_Al = txtField_Ss.Text;
        objQry.IResult_Where_Al = txtCondition_SS.Text;
        objQry.IResult_Field_Ms = txtField_Ms.Text;
        objQry.IResult_Where_Ms = txtCondition_Ms.Text;
        objQry.IResult_Field_Ts = txtField_Ts.Text;
        objQry.IResult_Where_Ts = txtCondition_Ts.Text;
        objQry.IQuery_Al        = txtQUERY_AL.Text;
        objQry.IQuery_Ms        = txtQUERY_MS.Text;
        objQry.IQuery_Ts        = txtQUERY_TS.Text;
        objQry.IIsvalid_Query   = this.IisValidQuery;
        objQry.IModify_Reason   = "";

        int iRtnRow = 0;
        if (this.IType == "A")
        {
            iRtnRow = objQry.InsertData
                     ( objQry.IKpi_Ref_Id
                     , objQry.IDicode
                     , objQry.IVersion_No
                     , objQry.IActive_Yn
                     , objQry.IResult_Field_Al
                     , objQry.IResult_Where_Al
                     , objQry.IResult_Field_Ms
                     , objQry.IResult_Where_Ms
                     , objQry.IResult_Field_Ts
                     , objQry.IResult_Where_Ts
                     , objQry.IQuery_Al
                     , objQry.IQuery_Ms
                     , objQry.IQuery_Ts
                     , objQry.IIsvalid_Query
                     , objQry.IModify_Reason
                     , gUserInfo.Emp_Ref_ID);
        }
        else if (this.IType == "U")
        {
            iRtnRow = objQry.UpdateData
                     (objQry.IKpi_Ref_Id
                     , objQry.IDicode
                     , objQry.IVersion_No
                     , objQry.IActive_Yn
                     , objQry.IResult_Field_Al
                     , objQry.IResult_Where_Al
                     , objQry.IResult_Field_Ms
                     , objQry.IResult_Where_Ms
                     , objQry.IResult_Field_Ts
                     , objQry.IResult_Where_Ts
                     , objQry.IQuery_Al
                     , objQry.IQuery_Ms
                     , objQry.IQuery_Ts
                     , objQry.IIsvalid_Query
                     , objQry.IModify_Reason
                     , gUserInfo.Emp_Ref_ID);
        }
        else if (this.IType == "D")
        {
            iRtnRow = objQry.DeleteData
                     ( objQry.IKpi_Ref_Id
                     , objQry.IDicode
                     , objQry.IVersion_No
                     , gUserInfo.Emp_Ref_ID);
        }

        ltrScript.Text = JSHelper.GetAlertScript(objQry.Transaction_Message, false);
    }

    /// <summary>
    /// 폼데이터 초기화
    /// </summary>
    public void SetFormClear()
    {
        this.IType = "A";
        txtKPICode.Text = "";
        txtKPIName.Text = "";

        txtDiCode.Text  = "";
        txtDiName.Text  = "";

        lstListField.Items.Clear();
        lstField.Items.Clear();
        lstCondition.Items.Clear();

        txtField_Ms.Text     = "";
        txtField_Ss.Text     = "";
        txtField_Ts.Text     = "";
        txtCondition_Ms.Text = "";
        txtCondition_SS.Text = "";
        txtCondition_Ts.Text = "";
        txtQUERY_AL.Text     = "";
        txtQUERY_MS.Text     = "";
        txtQUERY_TS.Text     = "";
    }

    /// <summary>
    /// 생성쿼리 검증
    /// </summary>
    public void SetQueryValidate()
    {
        Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail();
        string sSYmd = objTerm.GetStartEstMonth(); 
        string sCYmd = objTerm.GetReleasedMonth();

        decimal dRtnVal    = 0;
        string sRtnMsg     = "";
        bool   bIsSuccess  = false;
        this.IisValidQuery = "Y";
        Biz_Bsc_Interface_Kpi_Query objQry = new Biz_Bsc_Interface_Kpi_Query();
        
        // 인터페이스 리스트
        DataSet rDs = objQry.GetInterfaceData(txtQUERY_AL.Text, sCYmd, out sRtnMsg, out bIsSuccess);
        lblSuccessAl.Text = sRtnMsg;
        lblSuccessAl.BackColor = (bIsSuccess) ? Color.WhiteSmoke : Color.Red;
        if (!bIsSuccess)
        {
            this.IisValidQuery = "N";
        }
        
        // 당월실적 쿼리결과
        dRtnVal = objQry.GetInterfaceResultMs(txtQUERY_MS.Text, sCYmd, out sRtnMsg, out bIsSuccess);
        lblSuccessMs.Text = sRtnMsg;
        lblSuccessMs.BackColor = (bIsSuccess) ? Color.WhiteSmoke : Color.Red;
        if (!bIsSuccess)
        {
            this.IisValidQuery = "N";
        }

        // 누적실적 쿼리결과
        dRtnVal = objQry.GetInterfaceResultTs(txtQUERY_TS.Text, sSYmd, sCYmd, out sRtnMsg, out bIsSuccess);
        lblSuccessTs.Text = sRtnMsg;
        lblSuccessTs.BackColor = (bIsSuccess) ? Color.WhiteSmoke : Color.Red;
        if (!bIsSuccess)
        {
            this.IisValidQuery = "N";
        }
    }

    public bool ValidateForm()
    {
        if (this.lblKpiCode.Text == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("지표를 선택해주십시오");
            return false;
        }
        else if (this.IDiCode == "" || txtDiCode.Text == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("인터페이스 코드를 선택해주십시오");
            return false;
        }
        else if (this.IisValidQuery == "N")
        {
            ltrScript.Text = JSHelper.GetAlertScript("산식이 검증되지 않았거나 산식에 오류가 존재합니다.");
            return false;
        }

        return true;
    }
    #endregion


    #region =========== [ Event ] ====================================
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.TrxFormData();
    }

    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.TrxFormData();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnClear_Click(object sender, ImageClickEventArgs e)
    {
    }

    protected void iBtnReUse_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ugrdKpiList_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("IS_SET_QUERY");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("IS_SET_QUERY").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        ////cCol   = (TemplatedColumn)e.Row.Band.Columns.FromKey("APPROVAL_STATUS");
        ////objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        ////objImg.ImageUrl = (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y") ?
        ////                  "../images/icon_o.gif" : "../images/icon_x.gif";

        //cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        //objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        //string strImg = e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        //objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        //objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);
    }

    protected void ugrdKpiList_Click(object sender, ClickEventArgs e)
    {
        if (e.Row != null)
        {
            this.IEstTermRefID = int.Parse(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            this.IKpiRefID     = int.Parse(e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString());
            this.SetFormClear();
            this.SetFormData();
        }
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.setKpiData();
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.IDiCode = txtDiCode.Text;
        this.SetColumnList();
    }
    #endregion
    
    #region ======== [ Calculation Event ]
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Button btnIN = (Button)sender;
        switch (btnIN.ID)
        {
            case "btnClear":
                break;
            default:
                break;
        }

        this.txtField_Ms.Text = "";
    }

    protected void OperatorButton_Click(object sender, EventArgs e)
    {
        string sID = ((Control)sender).ID;

        string sCurQry = "";
        if (rdoCondition.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "SS")
        {
            sCurQry = txtCondition_SS.Text;
        }
        else if (rdoField.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "MS")
        {
            sCurQry = txtField_Ms.Text;
        }
        else if (rdoField.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "TS")
        {
            sCurQry = txtField_Ts.Text;
        }
        else if (rdoCondition.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "MS")
        {
            sCurQry = txtCondition_Ms.Text;
        }
        else if (rdoCondition.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "TS")
        {
            sCurQry = txtCondition_Ts.Text;
        }
        else
        {
            return;
        }

        switch (sID)
        {
            case "btnD0":
                sCurQry += QueryOperator.Digit0;
                break;
            case "btnD1":
                sCurQry += QueryOperator.Digit1;
                break;
            case "btnD2":
                sCurQry += QueryOperator.Digit2;
                break;
            case "btnD3":
                sCurQry += QueryOperator.Digit3;
                break;
            case "btnD4":
                sCurQry += QueryOperator.Digit4;
                break;
            case "btnD5":
                sCurQry += QueryOperator.Digit5;
                break;
            case "btnD6":
                sCurQry += QueryOperator.Digit6;
                break;
            case "btnD7":
                sCurQry += QueryOperator.Digit7;
                break;
            case "btnD8":
                sCurQry += QueryOperator.Digit8;
                break;
            case "btnD9":
                sCurQry += QueryOperator.Digit9;
                break;
            case "btnPoint":
                sCurQry += QueryOperator.DigitPoint;
                break;
            case "btnComma":
                sCurQry += QueryOperator.DigitComma;
                break;
            case "btnPlus":
                sCurQry += QueryOperator.ArithOperPlus;
                break;
            case "btnMinus":
                sCurQry += QueryOperator.ArithOperMinus;
                break;
            case "btnMultiply":
                sCurQry += QueryOperator.ArithOperMultiply;
                break;
            case "btnDivision":
                sCurQry += QueryOperator.ArithOperDivide;
                break;
            case "btnLeftBR":
                sCurQry += QueryOperator.LParenthesis;
                break;
            case "btnRightBR":
                sCurQry += QueryOperator.RParenthesis;
                break;
            case "btnQtaMark":
                sCurQry += QueryOperator.QuotationMark;
                break;
            case "btnConcat":
                sCurQry += QueryOperator.Concatenation;
                break;
            case "btnSum":
                sCurQry += QueryOperator.AggFuncSum;
                break;
            case "btnAbs":
                sCurQry += QueryOperator.AggFuncABS;
                break;
            case "btnAvg":
                sCurQry += QueryOperator.AggFuncAVG;
                break;
            case "btnMax":
                sCurQry += QueryOperator.AggFuncMAX;
                break;
            case "btnMin":
                sCurQry += QueryOperator.AggFuncMIN;
                break;
            case "btnCount":
                sCurQry += QueryOperator.AggFuncCOUNT;
                break;
            case "btnRound":
                sCurQry += QueryOperator.AggFuncROUND;
                break;
            case "btnTrunc":
                sCurQry += QueryOperator.AggFuncTRUNC;
                break;
            case "btnAnd":
                sCurQry += QueryOperator.LogicOperAnd;
                break;
            case "btnOR":
                sCurQry += QueryOperator.LogicOperOr;
                break;
            case "btnEqual":
                sCurQry += QueryOperator.CompOperEqual;
                break;
            case "btnNotEqual":
                sCurQry += QueryOperator.CompOperNotEqual;
                break;
            case "btnGT":
                sCurQry += QueryOperator.CompOperGrater;
                break;
            case "btnLT":
                sCurQry += QueryOperator.CompOperLower;
                break;
            case "btnMoreThen":
                sCurQry += QueryOperator.CompOperMoreThen;
                break;
            case "btnLessThen":
                sCurQry += QueryOperator.CompOperLessThen;
                break;
            case "btnLike":
                sCurQry += QueryOperator.LogicOperLike;
                break;
            case "btnPercent":
                sCurQry += QueryOperator.CompOperPercent;
                break;
            case "btnBetween":
                sCurQry += QueryOperator.LogicOperBetween;
                break;
            case "btnEnter":
                sCurQry += txtConstant.Text;
                break;
            case "lstField":
                sCurQry += QueryOperator.LBracket + lstField.SelectedItem.Text + QueryOperator.RBracket;
                break;
            case "lstCondition":
                sCurQry += QueryOperator.LBracket + lstCondition.SelectedItem.Text + QueryOperator.RBracket;
                break;
            default:
                break;
        }

        if (rdoCondition.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "SS")
        {
            txtCondition_SS.Text = sCurQry;
        }
        else if (rdoField.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "MS")
        {
            txtField_Ms.Text = sCurQry;
        }
        else if (rdoField.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "TS")
        {
            txtField_Ts.Text = sCurQry;
        }
        else if (rdoCondition.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "MS")
        {
            txtCondition_Ms.Text = sCurQry;
        }
        else if (rdoCondition.Checked && PageUtility.GetByValueRadioButtonList(rdoTermType) == "TS")
        {
            txtCondition_Ts.Text = sCurQry;
        }
        else
        {
            return;
        }
    }

    protected void lstField_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.OperatorButton_Click(sender, e);
        lstField.SelectedItem.Selected = false;
    }

    protected void lstCondition_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.OperatorButton_Click(sender, e);
        lstCondition.SelectedItem.Selected = false;
    }

    protected void rdoTermType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetQueryBox();
    }

    protected void rdoField_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoField.Checked)
        {
            rdoCondition.Checked = false;
        }
    }

    protected void rdoCondition_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCondition.Checked)
        {
            rdoField.Checked = false;
        }
    }
    #endregion
}
