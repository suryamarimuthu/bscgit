using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.WebUI.UltraWebGrid;
using System.Data;
using MicroBSC.RolesBasedAthentication;

public partial class BSC_BSC0381M1 : AppPageBase
{
    private int _iestterm_ref_id = 0;
    private string _iresult_input_method = "";
    private string _ikpi_code = "";
    private string _ikpi_name = "";
    private string _iemp_name = "";
    private int _iest_dept_id = 0;
    private int _ilogin_id = 0;
    private string _iymd = "";


    public int EstTermRefId
    {
        get { return _iestterm_ref_id; }
        set { _iestterm_ref_id = value; }
    }

    public DataSet DS_DATA
    {
        get { return (DataSet)ViewState["DS_DATA"]; }
        set { ViewState["DS_DATA"] = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.NotPostBackSetting();
            //this.iBtnUpdate.OnClientClick = "return UpdateResults('" + this.ugridKpiTargetList.ClientID + "')";
        }
        else
        {
            this.PostBackSetting();
        }

        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iymd            = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");
        
        if (txtDeptCode.Value != string.Empty)
        {
            _iest_dept_id = DataTypeUtility.GetToInt32(txtDeptCode.Value);
        }

        ltrScript.Text = "";
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        //this.SetResultListGrid();

        DoBinding();
    }

    protected void iBtnSearch_Click(object sender, EventArgs e)
    {
        //this.SetResultListGrid();

        DoBinding();

    }

    protected void iBtnUpdate_Click(object sender, EventArgs e)
    {
        //DoUpating();


        int iesttermRefId;
        int ikpiRefId;
        string iymd;
        int itxrUser;
        int itargetVersionId;
        double icalcMs;
        double icalcTs;
        string targetYM;
        TemplatedColumn template;
        CellItem cellItemObject;
        Infragistics.WebUI.WebDataInput.WebNumericEdit calcMsTxt;
        Infragistics.WebUI.WebDataInput.WebNumericEdit calcTsTxt;
        System.Web.UI.HtmlControls.HtmlInputText txtTargetMM;

        DataTable dtKpiTarget = new DataTable();

        dtKpiTarget.Columns.Add("ESTTERM_REF_ID");
        dtKpiTarget.Columns.Add("KPI_REF_ID");
        dtKpiTarget.Columns.Add("YMD");
        dtKpiTarget.Columns.Add("UPDATE_USER");
        dtKpiTarget.Columns.Add("TARGET_VERSION_ID");
        dtKpiTarget.Columns.Add("TARGET_MS");
        dtKpiTarget.Columns.Add("TARGET_TS");

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in this.ugridKpiTargetList.Rows)
        {
            string result_input_type = DataTypeUtility.GetValue(row.Cells.FromKey("resultInputType").Value);

            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();
            iesttermRefId    = DataTypeUtility.GetToInt32(row.Cells.FromKey("estTermRefId").Value);
            ikpiRefId        = DataTypeUtility.GetToInt32(row.Cells.FromKey("kpiRefId").Value);
            iymd             =  DataTypeUtility.GetValue(row.Cells.FromKey("estYmd").Value);
            itargetVersionId = DataTypeUtility.GetToInt32(row.Cells.FromKey("kpiTargetVersionId").Value);
            itxrUser         = this.gUserInfo.Emp_Ref_ID;

            if (result_input_type.Equals("MAN"))
            {
                for (int i = 1; i < 13; i++)
                {
                    string month = i.ToString().PadLeft(2, '0');

                    template = (TemplatedColumn)row.Cells.FromKey(string.Format("m{0}Target", month)).Column;
                    cellItemObject = (CellItem)template.CellItems[row.Index];
                    calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl(string.Format("txtM{0}Ms", month));
                    calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl(string.Format("txtM{0}Ts", month));
                    txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl(string.Format("txtTarget{0}", month));
                    icalcMs = calcMsTxt.ValueDouble;
                    icalcTs = calcTsTxt.ValueDouble;

                    if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
                    {
                        targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                        DataRow rowKpiTarget = dtKpiTarget.NewRow();

                        rowKpiTarget["ESTTERM_REF_ID"] = iesttermRefId;
                        rowKpiTarget["KPI_REF_ID"] = ikpiRefId;
                        rowKpiTarget["YMD"] = targetYM;
                        rowKpiTarget["UPDATE_USER"] = targetYM;
                        rowKpiTarget["TARGET_VERSION_ID"] = itargetVersionId;
                        rowKpiTarget["TARGET_MS"] = icalcMs;
                        rowKpiTarget["TARGET_TS"] = icalcTs;

                        dtKpiTarget.Rows.Add(rowKpiTarget);
                    }
                }
            }
        }

        //MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();
        //objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target bizBscKpiTarget = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target();

        int okCnt = bizBscKpiTarget.ModifyData(dtKpiTarget);

        if (okCnt > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장이 완료되었습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("오류가 발생하였습니다.");
        }
    }

    protected void ugridKpiTargetList_InitializeRow(object sender, RowEventArgs e)
    {
        UltraWebGrid grid = (UltraWebGrid)sender;
        DataRowView view = (DataRowView)e.Data;

        TemplatedColumn template;
        CellItem cellItemObject;
        int userRefId = ((MicroBSC.RolesBasedAthentication.SiteIdentity)this.User.Identity).Emp_Ref_ID;

        Infragistics.WebUI.WebDataInput.WebNumericEdit txtMs;
        Infragistics.WebUI.WebDataInput.WebNumericEdit txtTs;
        System.Web.UI.HtmlControls.HtmlInputText txtTargetMM;

        string per_month           = DataTypeUtility.GetValue(view["PER_MONTH"].ToString());
        string result_ts_calc_type = DataTypeUtility.GetValue(view["RESULT_TS_CALC_TYPE"].ToString());
        string result_input_type = DataTypeUtility.GetValue(view["RESULT_INPUT_TYPE"].ToString());

        for (int i = 1; i < 13; i++)
        {
            string month = i.ToString().PadLeft(2, '0');

            template       = (TemplatedColumn)e.Row.Cells.FromKey(string.Format("m{0}Target", month)).Column;
            cellItemObject = (CellItem)template.CellItems[e.Row.Index];
            txtMs          = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl(string.Format("txtM{0}Ms", month));
            txtTs          = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl(string.Format("txtM{0}Ts", month));
            txtMs.Value    = DataTypeUtility.GetValue(view[string.Format("M{0}_MS", month)]);
            txtTs.Value    = DataTypeUtility.GetValue(view[string.Format("M{0}_TS", month)]);

            string check_yn  = DataTypeUtility.GetValue(view[string.Format("M{0}_CHECK", month)]);
            string target_mm = DataTypeUtility.GetValue(view[string.Format("M{0}_TARGET_MM", month)]);

            txtMs.Attributes.Add("onblur", string.Format("return doAutoCulcuration(this,'{0}')", result_ts_calc_type));
            //txtMs.Value = "1111";//("onchange", string.Format("doAutoCulcuration(this,'{0}')", result_ts_calc_type));
            

            if (check_yn.Equals("N") || target_mm.CompareTo(per_month) < 0)
            {
                txtMs.ReadOnly = false;
                txtTs.ReadOnly = false;

                txtMs.BackColor = System.Drawing.Color.Silver;
                txtTs.BackColor = System.Drawing.Color.Silver;
            }
            else
            {
                txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl(string.Format("txtTarget{0}", month));
                txtTargetMM.Value = target_mm;
            }

            if (result_ts_calc_type.Equals("SUM") || result_ts_calc_type.Equals("AVG"))
            {
                txtTs.ReadOnly = true;
                txtTs.BackColor = System.Drawing.Color.Silver;
            }

            /* result_input_type 코드
             * MAN : 수기입력 
             * SYS : 기간 시스템 자동계산
             * KPI : 하위 지표가 있는거 
             * */

            if (result_input_type.Equals("KPI"))
            {
                txtMs.ReadOnly = false;
                txtTs.ReadOnly = false;

                txtMs.BackColor = System.Drawing.Color.Silver;
                txtTs.BackColor = System.Drawing.Color.Silver;
            }

            string ymd = _iymd.Remove(4) + month;

            DataRow[] rows = DS_DATA.Tables[0].Select(string.Format(" YMD = '{0}' AND CLOSE_YN = 'Y' ", ymd));

            if (rows.Length > 0)
            {
                txtMs.ReadOnly = false;
                txtTs.ReadOnly = false;

                txtMs.BackColor = System.Drawing.Color.Silver;
                txtTs.BackColor = System.Drawing.Color.Silver;

                template.CellStyle.BackColor = System.Drawing.Color.Silver;
                template.Header.Caption = string.Format("M{0}(<FONT COLOR='YELLOW'>마감</FONT>)", month);
            }
        }

        if (result_input_type.Equals("KPI"))
        {
            e.Row.Style.BackColor = System.Drawing.Color.Silver;
        }
        
        /*

        // 1월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m01Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM01Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM01Ts");
        txtMs.Value = view["M01_MS"].ToString();
        txtTs.Value = view["M01_TS"].ToString();
        if ("N".Equals(view["M01_CHECK"].ToString()) == true || view["M01_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget01");
            txtTargetMM.Value = view["M01_TARGET_MM"].ToString();
        }
        // 2월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m02Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM02Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM02Ts");
        txtMs.Value = view["M02_MS"].ToString();
        txtTs.Value = view["M02_TS"].ToString();
        if ("N".Equals(view["M02_CHECK"].ToString()) == true || view["M02_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget02");
            txtTargetMM.Value = view["M02_TARGET_MM"].ToString();
        }
        // 3월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m03Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM03Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM03Ts");
        txtMs.Value = view["M03_MS"].ToString();
        txtTs.Value = view["M03_TS"].ToString();
        if ("N".Equals(view["M03_CHECK"].ToString()) == true || view["M03_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget03");
            txtTargetMM.Value = view["M03_TARGET_MM"].ToString();
        }
        // 4월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m04Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM04Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM04Ts");
        txtMs.Value = view["M04_MS"].ToString();
        txtTs.Value = view["M04_TS"].ToString();
        if ("N".Equals(view["M04_CHECK"].ToString()) == true || view["M04_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget04");
            txtTargetMM.Value = view["M04_TARGET_MM"].ToString();
        }
        // 5월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m05Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM05Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM05Ts");
        txtMs.Value = view["M05_MS"].ToString();
        txtTs.Value = view["M05_TS"].ToString();
        if ("N".Equals(view["M05_CHECK"].ToString()) == true || view["M05_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget05");
            txtTargetMM.Value = view["M05_TARGET_MM"].ToString();
        }
        // 6월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m06Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM06Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM06Ts");
        txtMs.Value = view["M06_MS"].ToString();
        txtTs.Value = view["M06_TS"].ToString();
        if ("N".Equals(view["M06_CHECK"].ToString()) == true || view["M06_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget06");
            txtTargetMM.Value = view["M06_TARGET_MM"].ToString();
        }
        // 7월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m07Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM07Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM07Ts");
        txtMs.Value = view["M07_MS"].ToString();
        txtTs.Value = view["M07_TS"].ToString();
        if ("N".Equals(view["M07_CHECK"].ToString()) == true || view["M07_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget07");
            txtTargetMM.Value = view["M07_TARGET_MM"].ToString();
        }
        // 8월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m08Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM08Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM08Ts");
        txtMs.Value = view["M08_MS"].ToString();
        txtTs.Value = view["M08_TS"].ToString();
        if ("N".Equals(view["M08_CHECK"].ToString()) == true || view["M08_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget08");
            txtTargetMM.Value = view["M08_TARGET_MM"].ToString();
        }
        // 9월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m09Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM09Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM09Ts");
        txtMs.Value = view["M09_MS"].ToString();
        txtTs.Value = view["M09_TS"].ToString();
        if ("N".Equals(view["M09_CHECK"].ToString()) == true || view["M09_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget09");
            txtTargetMM.Value = view["M09_TARGET_MM"].ToString();
        }
        // 10월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m10Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM10Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM10Ts");
        txtMs.Value = view["M10_MS"].ToString();
        txtTs.Value = view["M10_TS"].ToString();
        if ("N".Equals(view["M10_CHECK"].ToString()) == true || view["M10_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget10");
            txtTargetMM.Value = view["M10_TARGET_MM"].ToString();
        }
        // 11월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m11Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM11Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM11Ts");
        txtMs.Value = view["M11_MS"].ToString();
        txtTs.Value = view["M11_TS"].ToString();
        if ("N".Equals(view["M11_CHECK"].ToString()) == true || view["M11_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget11");
            txtTargetMM.Value = view["M11_TARGET_MM"].ToString();
        }
        // 12월 목표 및 누적목표
        template = (TemplatedColumn)e.Row.Cells.FromKey("m12Target").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];
        txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM12Ms");
        txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM12Ts");
        txtMs.Value = view["M12_MS"].ToString();
        txtTs.Value = view["M12_TS"].ToString();
        if ("N".Equals(view["M12_CHECK"].ToString()) == true || view["M12_TARGET_MM"].ToString().CompareTo(view["PER_MONTH"].ToString()) < 0)
        {
            txtMs.Enabled = false;
            txtTs.Enabled = false;
        }
        else
        {
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget12");
            txtTargetMM.Value = view["M12_TARGET_MM"].ToString();
        }
         * 
         * */

        if (userRefId.ToString().Equals(view["CHAMPION_EMP_ID"].ToString()) == false)
        {
            //txtMs.Enabled = false;
            //txtTs.Enabled = false;
        }
    }

    private void NotPostBackSetting()
    {
        this.InitControlValue();
        //this.SetResultListGrid();
        DoBinding();
    }

    private void PostBackSetting()
    {

    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
    }

    public void SetResultListGrid()
    {
        DataSet ds;
        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");

        if (txtDeptCode.Value == string.Empty)
        {
            _iest_dept_id = 0;
        }
        else
        {
            _iest_dept_id = int.Parse(txtDeptCode.Value);
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();
        if (((SitePrincipal)this.User).Roles.Contains("1") == true || ((SitePrincipal)this.User).Roles.Contains("8") == true)
        {
            ds = objBSC.SelectKpiTargetList(_iestterm_ref_id, _iest_dept_id, _iymd, 0);
        }
        else
        {
            ds = objBSC.SelectKpiTargetList(_iestterm_ref_id, _iest_dept_id, _iymd, this.gUserInfo.Emp_Ref_ID);
        }

        //for (int i = ds.Tables[0].Rows.Count - 1; i > 16; i--)
        //{
        //    ds.Tables[0].Rows[i].Delete();
        //}
        this.ugridKpiTargetList.Clear();
        this.ugridKpiTargetList.DataSource = ds;
        this.ugridKpiTargetList.DataBind();

        lblRowCount.Text = ugridKpiTargetList.Rows.Count.ToString();
    }





    private void DoUpating()
    {
        int iesttermRefId;
        int ikpiRefId;
        string iymd;
        int itxrUser;
        int itargetVersionId;
        double icalcMs;
        double icalcTs;
        string targetMonth;
        string targetYM;
        TemplatedColumn template;
        CellItem cellItemObject;
        Infragistics.WebUI.WebDataInput.WebNumericEdit calcMsTxt;
        Infragistics.WebUI.WebDataInput.WebNumericEdit calcTsTxt;
        System.Web.UI.HtmlControls.HtmlInputText txtTargetMM;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in this.ugridKpiTargetList.Rows)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();
            iesttermRefId = DataTypeUtility.GetToInt32(row.Cells.FromKey("estTermRefId").Value);
            ikpiRefId = DataTypeUtility.GetToInt32(row.Cells.FromKey("kpiRefId").Value);
            iymd = DataTypeUtility.GetValue(row.Cells.FromKey("estYmd").Value);
            itargetVersionId = DataTypeUtility.GetToInt32(row.Cells.FromKey("kpiTargetVersionId").Value);
            itxrUser = this.gUserInfo.Emp_Ref_ID;

            /* 1월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m01Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM01Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM01Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget01");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 2월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m02Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM02Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM02Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget02");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 3월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m03Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM03Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM03Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget03");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 4월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m04Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM04Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM04Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget04");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 5월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m05Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM05Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM05Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget05");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 6월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m06Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM06Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM06Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget06");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 7월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m07Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM07Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM07Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget07");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 8월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m08Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM08Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM08Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget08");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 9월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m09Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM09Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM09Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget09");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 10월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m10Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM10Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM10Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget10");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 11월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m11Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM11Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM11Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget11");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }

            /* 12월 목표 설정 */
            template = (TemplatedColumn)row.Cells.FromKey("m12Target").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            calcMsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM12Ms");
            calcTsTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtM12Ts");
            txtTargetMM = (System.Web.UI.HtmlControls.HtmlInputText)cellItemObject.FindControl("txtTarget12");
            icalcMs = calcMsTxt.ValueDouble;
            icalcTs = calcTsTxt.ValueDouble;

            if (string.IsNullOrEmpty(txtTargetMM.Value) == false)
            {
                targetYM = row.Cells.FromKey("perYear").Value.ToString() + txtTargetMM.Value;

                objBSC.UpdateKpiTarget(null, null, iesttermRefId, ikpiRefId, targetYM, itxrUser, itargetVersionId, icalcMs, icalcTs);
            }
        }

    }

    private void DoBinding()
    {
        

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result bizBscKpiResult = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result();

        int emp_id = this.gUserInfo.Emp_Ref_ID;
        if (this.EMP_ROLES.Contains("1") || this.EMP_ROLES.Contains("8"))
        {
            emp_id = 0;
        }

        DS_DATA = bizBscKpiResult.SelectKpiTargetList(_iestterm_ref_id, _iest_dept_id, _iymd, emp_id);

        this.ugridKpiTargetList.Clear();
        this.ugridKpiTargetList.DataSource = DS_DATA;
        this.ugridKpiTargetList.DataBind();

        lblRowCount.Text = ugridKpiTargetList.Rows.Count.ToString();
    }
}
