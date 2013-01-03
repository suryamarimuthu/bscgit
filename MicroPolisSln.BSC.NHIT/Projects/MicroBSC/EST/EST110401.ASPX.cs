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
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Xml;

using Dundas.Charting.WebControl;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;

using MicroBSC.Estimation.Biz;
using MicroCharts;

public partial class EST_EST110401 : EstPageBase
{
    #region ================ 필드 =======================
    private string EST_ID;
    private string YEAR_YN;
    private string MERGE_YN;
    private string ESTTERM_SUB_ALL_USE_YN;
    private string ESTTERM_STEP_ALL_USE_YN;
    private string sXml = string.Empty;
    #endregion

    #region ================ 프로퍼티 =======================
    protected string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lbnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    private int IIS_TERM_CLOSE
    {
        get
        {
            if (ViewState["IS_TERM_CLOSE"] == null)
                ViewState["IS_TERM_CLOSE"] = 1;
            return (int)ViewState["IS_TERM_CLOSE"];
        }
        set
        {
            ViewState["IS_TERM_CLOSE"] = value;
        }
    }

    private int ICOMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
                ViewState["COMP_ID"] = 1;
            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }

    private int IESTTERM_SUB_ID
    {
        get
        {
            if (ViewState["ESTTERM_SUB_ID"] == null)
                ViewState["ESTTERM_SUB_ID"] = 0;
            return (int)ViewState["ESTTERM_SUB_ID"];
        }
        set
        {
            ViewState["ESTTERM_SUB_ID"] = value;
        }
    }
    private int IESTTERM_STEP_ID
    {
        get
        {
            if (ViewState["ESTTERM_STEP_ID"] == null)
                ViewState["ESTTERM_STEP_ID"] = 0;
            return (int)ViewState["ESTTERM_STEP_ID"];
        }
        set
        {
            ViewState["ESTTERM_STEP_ID"] = value;
        }
    }

    private int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    private string IEST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
                ViewState["EST_ID"] = "";
            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }

    private string IEST_JOB_IDS
    {
        get
        {
            if (ViewState["EST_JOB_IDS"] == null)
                ViewState["EST_JOB_IDS"] = "";
            return (string)ViewState["EST_JOB_IDS"];
        }
        set
        {
            ViewState["EST_JOB_IDS"] = value;
        }
    }

    private int IBIAS_GRP_ID
    {
        get
        {
            if (ViewState["BIAS_GRP_ID"] == null)
                ViewState["BIAS_GRP_ID"] = 0;
            return (int)ViewState["BIAS_GRP_ID"];
        }
        set
        {
            ViewState["BIAS_GRP_ID"] = value;
        }
    }

    private string ICOLUMN_SORT
    {
        get
        {
            if (ViewState["COLUMN_SORT"] == null)
                ViewState["COLUMN_SORT"] = "";
            return (string)ViewState["COLUMN_SORT"];
        }
        set
        {
            ViewState["COLUMN_SORT"] = value;
        }
    }
    private string ICOLUMN_DATA_TYPE
    {
        get
        {
            if (ViewState["COLUMN_DATA_TYPE"] == null)
                ViewState["COLUMN_DATA_TYPE"] = "";
            return (string)ViewState["COLUMN_DATA_TYPE"];
        }
        set
        {
            ViewState["COLUMN_DATA_TYPE"] = value;
        }
    }
    private string ICOLUMN_FORMAT
    {
        get
        {
            if (ViewState["COLUMN_FORMAT"] == null)
                ViewState["COLUMN_FORMAT"] = "";
            return (string)ViewState["COLUMN_FORMAT"];
        }
        set
        {
            ViewState["COLUMN_FORMAT"] = value;
        }
    }

    #endregion

    #region ================ Page 이벤트 =======================

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        YEAR_YN = WebUtility.GetRequest("YEAR_YN", "N");
        MERGE_YN = WebUtility.GetRequest("MERGE_YN", "N");
        EST_JOB_IDS = WebUtility.GetRequest("EST_JOB_IDS");

        //BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnApplyBiasPoint);
        //BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnCalcBiasPoint);

        if (!Page.IsPostBack)
        {
            this.IEST_ID = WebUtility.GetRequest("EST_ID", "");
            this.IEST_JOB_IDS = WebUtility.GetRequest("EST_JOB_IDS", "");

            lblCalc1.Font.Size = lblCalc2.Font.Size = FontUnit.Point(8);
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "----------", "");
            DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "----------", "");

            if (this.ICOMP_ID == 0)
                this.ICOMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

            if (this.IESTTERM_REF_ID == 0)
                this.IESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

            DropDownListCommom.BindEstTermSub(ddlEstTermSubID, this.ICOMP_ID, this.IEST_ID, "");
            DropDownListCommom.BindEstTermStep(ddlEstTermStepID, this.ICOMP_ID, this.IEST_ID);

            if (this.IESTTERM_SUB_ID == 0)
                this.IESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

            if (this.IESTTERM_STEP_ID == 0)
                this.IESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

            if (MERGE_YN.Equals("Y"))
            {
                this.IESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
            }
            else
            {
                if (ESTTERM_STEP_ALL_USE_YN.Equals("Y"))
                {
                    this.IESTTERM_STEP_ID = 0;
                }
                else
                {
                    this.IESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
                }
            }

            //평가마감되었는지 확인
            BizUtility.SetButtonVisibleByEstJobID(this.IEST_JOB_IDS
                                            , ibtnCalc
                                            , this.ICOMP_ID
                                            , this.IEST_ID
                                            , this.IESTTERM_REF_ID
                                            , this.IESTTERM_SUB_ID
                                            , this.IESTTERM_STEP_ID);
            ibtnInsert.Visible = ddlPointType.Visible = ibtnCalc.Visible;//ibtnConfirm.Visible = 
            
            Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
            DataTable dtGroup = bizBiasData.GetBiasGroup(this.ICOMP_ID, this.IEST_ID, "Y");
            ddlGroup.DataTextField = "BIAS_GRP_NM";
            ddlGroup.DataValueField = "BIAS_GRP_ID";
            ddlGroup.DataSource = dtGroup;
            ddlGroup.DataBind();
            ddlGroup.Width = Unit.Pixel(200);

            this.IBIAS_GRP_ID = WebUtility.GetIntByValueDropDownList(ddlGroup);

            DataTable dtPointType = bizBiasData.GetBiasColumns(this.ICOMP_ID, this.IEST_ID, "Y", "Y");
            if (dtPointType.Rows.Count > 0)
            {
                DataRow[] drPointType = dtPointType.Select("COL_TYPE = 'USERKEY' AND PROC_TYPE = 'Y'", "COL_ORDER ASC");
                foreach (DataRow dr in drPointType)
                {
                    ddlPointType.Items.Add(new ListItem(dr["COL_NAME"].ToString(), dr["COL_KEY"].ToString()));
                }
                if (ddlPointType.Items.Count > 0)
                    ddlPointType.Items[0].Selected = true;
            }

            if (!this.IEST_ID.Equals(""))
            {
                DoBindingData();
            }
            else
            {
                ibtnCalc.Visible = ddlPointType.Visible = ibtnInsert.Visible = ibtnDownload.Visible = false;//ibtnConfirm.Visible = 
            }
            DoBindingBiasMethod();
        }

        if (YEAR_YN.Equals("Y"))
            this.IESTTERM_SUB_ID = BizUtility.GetEstTermSubIDByYearYN(COMP_ID);
        else
            this.IESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        if (MERGE_YN.Equals("Y"))
            this.IESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
        else
            this.IESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

        DoSortColumn();
        if (ddlPointType.Items.Count == 0)
            ibtnInsert.Visible = ddlPointType.Visible = false;//ibtnConfirm.Visible = 
        ltrScript.Text = "";
    }

    protected void ugrdBias_InitializeLayout(object sender, LayoutEventArgs e)
    {
        if (!IsPostBack)
            DoInitColumn();
        else
            DoSortColumn();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (YEAR_YN.Equals("Y"))
            ddlEstTermSubID.Visible = false;

        if (MERGE_YN.Equals("Y"))
            ddlEstTermStepID.Visible = false;
    }

    #endregion

    #region ================ 메소드 =======================

    private void DoBindingData()
    {
        this.IESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        if (MERGE_YN.Equals("Y"))
            this.IESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
        else
            this.IESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        DataTable dtBiasData = bizBiasData.GetBiasData(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, this.IESTTERM_SUB_ID, this.IESTTERM_STEP_ID, this.IBIAS_GRP_ID);
        ugrdBias.DataSource = dtBiasData;
        ugrdBias.DataBind();

        if (ugrdBias.Rows.Count == 0)
            ddlPointType.Visible = ibtnInsert.Visible = ibtnDownload.Visible = false;//ibtnConfirm.Visible = 
        else
        {
            //평가마감되었는지 확인
            BizUtility.SetButtonVisibleByEstJobID(this.IEST_JOB_IDS
                                            , ibtnCalc
                                            , this.ICOMP_ID
                                            , this.IEST_ID
                                            , this.IESTTERM_REF_ID
                                            , this.IESTTERM_SUB_ID
                                            , this.IESTTERM_STEP_ID);
            ibtnInsert.Visible = ddlPointType.Visible = ibtnCalc.Visible;//ibtnConfirm.Visible = 
            ibtnDownload.Visible = true;
        }
        lblRowCount.Text = ugrdBias.Rows.Count.ToString();
    }

    private void DoInitColumn()
    {
        Biz_BiasDatas bizBaisData = new Biz_BiasDatas();
        DataTable dtColumn = bizBaisData.GetBiasColumns(this.ICOMP_ID, this.IEST_ID, "Y", "Y");
        UltraGridColumn ucol = null;
        foreach (DataRow dr in dtColumn.Rows)
        {
            ucol = new UltraGridColumn();

            ucol.Header.Caption = dr["COL_NAME"].ToString();
            ucol.Header.Style.HorizontalAlign = HorizontalAlign.Center;
            ucol.Header.Column.Key = ucol.Header.Column.BaseColumnName = dr["COL_KEY"].ToString();
            ucol.Width = Unit.Pixel(DataTypeUtility.GetToInt32(dr["COL_WIDTH"]));
            ucol.DataType = dr["DATA_TYPE"].ToString();
            if (dr["DATA_TYPE"].ToString() == "System.Double")
                ucol.Format = "##,###,##0.00";
            ucol.CellStyle.HorizontalAlign = GetAlignColumn(dr["COL_ALIGN"].ToString());
            this.ICOLUMN_SORT += dr["COL_ALIGN"].ToString() + ";";
            this.ICOLUMN_DATA_TYPE += ucol.DataType + ";";
            this.ICOLUMN_FORMAT += ucol.Format + ";";
            ugrdBias.Columns.Add(ucol);
        }
        if (dtColumn.Rows.Count > 0)
        {
            ucol = new UltraGridColumn();
            ucol.Header.Caption = "확정점수";
            ucol.Header.Style.HorizontalAlign = HorizontalAlign.Center;
            ucol.Header.Column.Key = ucol.Header.Column.BaseColumnName = "POINT";
            ucol.Width = Unit.Pixel(80);
            ucol.DataType = "System.Double";
            ucol.Format = "##,###,##0.00";
            ucol.CellStyle.HorizontalAlign = GetAlignColumn("Right");
            this.ICOLUMN_SORT += "Right";
            this.ICOLUMN_DATA_TYPE += "System.Double";
            this.ICOLUMN_FORMAT += "##,###,##0.00";
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "COMP_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "EST_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "ESTTERM_REF_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "ESTTERM_SUB_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "ESTTERM_STEP_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "BIAS_GRP_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "TGT_DEPT_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "TGT_EMP_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "TGT_POS_CLS_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "TGT_POS_DUT_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "TGT_POS_GRP_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);

            ucol = new UltraGridColumn();
            ucol.Header.Column.BaseColumnName = ucol.Header.Column.Key = "TGT_POS_RNK_ID";
            ucol.Header.Column.Hidden = true;
            ugrdBias.Columns.Add(ucol);
        }
    }

    private void DoSortColumn()
    {
        foreach (UltraGridColumn ucol in ugrdBias.Columns)
        {
            ucol.Header.Style.HorizontalAlign = HorizontalAlign.Center;

            if (!ucol.Header.Column.Hidden)
            {
                ucol.CellStyle.HorizontalAlign = GetAlignColumn(this.ICOLUMN_SORT.Split(';').GetValue(ucol.Index).ToString());
                ucol.DataType = this.ICOLUMN_DATA_TYPE.Split(';').GetValue(ucol.Index).ToString();
                ucol.Format = this.ICOLUMN_FORMAT.Split(';').GetValue(ucol.Index).ToString();
            }

        }
    }

    private HorizontalAlign GetAlignColumn(string strAlign)
    {
        HorizontalAlign rtnAlign = HorizontalAlign.Left;
        switch (strAlign.ToUpper())
        {
            case "CENTER":
                rtnAlign = HorizontalAlign.Center;
                break;
            case "RIGHT":
                rtnAlign = HorizontalAlign.Right;
                break;
        }
        return rtnAlign;

    }
    #endregion

    #region ======================= 드롭다운 컨트롤 ===========================

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ICOMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        DropDownListCommom.BindEstTermSub(ddlEstTermSubID, this.ICOMP_ID, this.IEST_ID, "");
        DropDownListCommom.BindEstTermStep(ddlEstTermStepID, this.ICOMP_ID, this.IEST_ID);
        DoBindingData();
    }

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        DoBindingData();
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        DoBindingData();
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IBIAS_GRP_ID = WebUtility.GetIntByValueDropDownList(ddlGroup);
        DoBindingData();
    }

    protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (MERGE_YN.Equals("Y"))
            this.IESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
        else
            this.IESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
        DoBindingData();
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {
        DoBindingBiasMethod();
    }

    #endregion

    #region ================== 버튼 컨틀롤 ========================
    private void DoBindingBiasMethod()
    {
        sXml = Server.MapPath(".") + "..\\..\\Resources\\Bias.xml";
        //DataSet ds = new DataSet();
        //ds.ReadXml(sXml);

        XmlDocument doc = new XmlDocument();
        doc.Load(sXml);
        XmlNode xNode = null;
        xNode = doc.SelectSingleNode(@"/root/data[@name='BIAS_AVG_METHOD']");
        lblCalc1.Text = xNode.SelectSingleNode("value").InnerXml;
        xNode = doc.SelectSingleNode(@"/root/data[@name='BIAS_STD_METHOD']");
        lblCalc2.Text = xNode.SelectSingleNode("value").InnerXml;
    }

    protected void ibtnCalc_Click(object sender, ImageClickEventArgs e)
    {
        string selectQuery = string.Empty;
        string joinQuery = string.Empty;

        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        DataTable dtPointType = bizBiasData.GetBiasColumns(this.ICOMP_ID, this.IEST_ID, "Y", "Y");
        if (dtPointType.Rows.Count > 0)
        {
            DataRow[] drPointType = dtPointType.Select("COL_TYPE = 'USERKEY'", "COL_ORDER ASC");
            foreach (DataRow dr in drPointType)
            {
                selectQuery += @"
        , " + dr["COL_KEY"].ToString() + ".RTNVALUE AS " + dr["COL_KEY"].ToString();
                joinQuery += @"
LEFT OUTER JOIN " + dr["PROC_NAME"].ToString() + "(@COMP_ID, @EST_ID, @ESTTERM_REF_ID, @ESTTERM_SUB_ID, @ESTTERM_STEP_ID, @BIAS_GRP_ID)  " + dr["COL_KEY"].ToString()
                           + "          ON  " + dr["COL_KEY"].ToString() + ".TGT_EMP_ID = A.EMP_REF_ID";
            }
        }
        
        DataTable dtBiasData = bizBiasData.CalcBiasData(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, this.IESTTERM_SUB_ID, this.IESTTERM_STEP_ID, this.IBIAS_GRP_ID, selectQuery, joinQuery);
        ugrdBias.DataSource = dtBiasData;
        ugrdBias.DataBind();
        
        
        DoSortColumn();

        if (ugrdBias.Rows.Count == 0)
        {
            ibtnInsert.Visible = false;//ibtnConfirm.Visible = 
            ltrScript.Text = JSHelper.GetAlertScript("계산된 데이터가 없습니다.");
        }
        else
        {
            DataTable dtBank = new DataTable();

            string strUserColumnName = string.Empty;
            for (int i = 1; i < 11; i++)
                if (ugrdBias.Columns.FromKey("COL" + i.ToString()) != null)
                    strUserColumnName += "COL" + i.ToString() + ";";

            string[] strUserColumn = { "TGT_DEPT_ID", "TGT_EMP_ID", "TGT_POS_CLS_ID", "TGT_POS_DUT_ID", "TGT_POS_GRP_ID", "TGT_POS_RNK_ID", "", "", "", "", "", "", "", "", "", "" };
            if (strUserColumnName != string.Empty)
            {
                strUserColumnName = strUserColumnName.Substring(0, strUserColumnName.Length - 1);
                for (int i = 0; i < strUserColumnName.Split(';').Length; i++)
                    strUserColumn.SetValue(strUserColumnName.Split(';').GetValue(i).ToString(), 6 + i);
            }


            int cntUserColumnName;
            if (strUserColumnName.Trim().Length == 0)
                cntUserColumnName = 0;
            else
                cntUserColumnName = strUserColumnName.Split(';').Length;


            string[] strFinalColumn = new string[6 + cntUserColumnName];
            for (int i = 0; i < strFinalColumn.Length; i++)
            {
                if (strUserColumn.GetValue(i).ToString() != "")
                {
                    strFinalColumn.SetValue(strUserColumn.GetValue(i).ToString(), i);
                    dtBank.Columns.Add(strUserColumn.GetValue(i).ToString(), (i < 2 ? typeof(int) : typeof(string)));
                }
            }
            
            //dtBank.Columns.Add("POINT", typeof(double));
            
            DataTable dtCalcData = UltraGridUtility.GetDataTableByAllValue(ugrdBias
                , strFinalColumn
                , dtBank);

            if (dtCalcData.Rows.Count > 0)
            {
                if (bizBiasData.InsertBiasData(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, this.IESTTERM_SUB_ID, this.IESTTERM_STEP_ID, this.IBIAS_GRP_ID, dtCalcData, gUserInfo.Emp_Ref_ID))
                {
                    DoBindingData();
                    ltrScript.Text = JSHelper.GetAlertScript("정상적으로 Bias 조정점수 계산을 완료하였습니다.");
                }
                else
                    ltrScript.Text = JSHelper.GetAlertScript("데이터 적용이 실패하였습니다.\\n" + bizBiasData.errMSG.Replace("\n", ""));
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("데이터 적용이 실패하였습니다.");
            }
        }
        lblRowCount.Text = ugrdBias.Rows.Count.ToString();
    }

    protected void ibtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        if (bizBiasData.UpdateBiasPoint(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, this.IESTTERM_SUB_ID, this.IESTTERM_STEP_ID, this.IBIAS_GRP_ID, ddlPointType.SelectedItem.Value, gUserInfo.Emp_Ref_ID))
        {
            DoBindingData();
            ltrScript.Text = JSHelper.GetAlertScript("성공적으로 점수를 적용하였습니다.");
            return;
        }
        ltrScript.Text = JSHelper.GetAlertScript("점수적용 실패!\\n" + bizBiasData.errMSG);
    }

    protected void ibtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        if (bizBiasData.ConfirmBiasPoint(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, this.IESTTERM_SUB_ID, this.IESTTERM_STEP_ID, this.IBIAS_GRP_ID, gUserInfo.Emp_Ref_ID))
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 Bias 조정점수를 확정하였습니다.");
            return;
        }
        ltrScript.Text = JSHelper.GetAlertScript("점수확정 실패!\\n" + bizBiasData.errMSG);
    }

    protected void ibtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        ugrdEEP.ExcelStartRow = 5;
        ugrdEEP.ExportMode = ExportMode.InBrowser;
        ugrdEEP.DownloadName = "Bias Control List";
        ugrdEEP.WorksheetName = "Bias 조정 현황";
        ugrdEEP.Export(ugrdBias);
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        Biz_EstInfos bizEstInfo = new Biz_EstInfos(this.ICOMP_ID, this.IEST_ID);
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermRefID.SelectedItem.Text;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가그룹 : " + ddlGroup.SelectedItem.Text;
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "평가명 : " + bizEstInfo.Est_Name;
        //e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
    }

    #endregion
}
