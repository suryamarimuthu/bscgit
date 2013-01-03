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
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;

using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0305M1 : AppPageBase
{
    #region 변수선언
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
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

    int iTRow = 0;
    int iCRow = 0;
    #endregion

    #region 페이지 초기화 함수
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebCommon.SetComDeptDropDownList(ddlEstDept, true);
            Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
            objCode.getResultMethod(ddlResultInput, "", true, 120);
            objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);

            this.ugrdKpiStatusTab.SelectedTab = 0;

            this.setChildKpi();
            ltrAppLegend.Text = Biz_Type.app_legend; ;
        }
        else
        { 
            
        }
    }
    #endregion

    #region 내부 함수

    public void setKpiData()
    {
        if (this.IEstTermRefID < 1)
        {
            PageUtility.AlertMessage("평가기간을 알 수 없습니다.");
            return;
        }

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();

        objBSC.Iestterm_ref_id    = this.IEstTermRefID;
        objBSC.Iresult_input_type = ddlResultInput.SelectedValue;
        objBSC.Ikpi_code          = txtKPICode.Text.Trim();
        objBSC.Ikpi_name          = txtKPIName.Text.Trim();
        objBSC.Ichampion_emp_name = txtChamName.Text.Trim();
        int iest_dept_id          = (ddlEstDept.SelectedValue.Trim() == "") ? -1 : int.Parse(ddlEstDept.SelectedValue);
        objBSC.Iuse_yn            = "";
        objBSC.Itxr_user          = int.Parse(gUserInfo.Emp_Ref_ID.ToString());

        //DataSet ds = objBSC.GetKpiListPerUser
        //                        (objBSC.Iestterm_ref_id 
        //                       , objBSC.Iresult_input_type 
        //                       , objBSC.Ikpi_code 
        //                       , objBSC.Ikpi_name 
        //                       , objBSC.Iuse_yn 
        //                       , objBSC.Ichampion_emp_name 
        //                       , iest_dept_id 
        //                       , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
        //                       , objBSC.Itxr_user);

        DataSet ds = objBSC.GetKpiChildTargetList
                                (this.IEstTermRefID
                               , this.IKpiRefID
                               , txtKPICode.Text
                               , txtKPIName.Text
                               , txtChamName.Text
                               , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                               , PageUtility.GetIntByValueDropDownList(ddlEstDept));

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = ds;
        ugrdKpiList.DataBind();
    }

    public void setChildKpi()
    { 
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet rDs = objBSC.GetKpiChildList(this.IEstTermRefID, this.IKpiRefID);

        ugrdChildKpi.Clear();
        ugrdChildKpi.DataSource = rDs;
        ugrdChildKpi.DataBind();
    }

    public void SetChildKpiTarget()
    {
        Biz_Bsc_Kpi_Target objBSC = new Biz_Bsc_Kpi_Target();
        DataSet rDs = objBSC.GetChildKpiTargetStatus(this.IEstTermRefID, this.IKpiRefID);
        
        ugrdChildKpiTarget.Clear();
        ugrdChildKpiTarget.DataSource = rDs;
        ugrdChildKpiTarget.DataBind();
    }

    public void SetKpiRelation(string iType)
    {
        int itxr_user = gUserInfo.Emp_Ref_ID;
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        UltraWebGrid ugrdKpi = (iType == "ADD") ? ugrdKpiList : ugrdChildKpi;
        int intRtn = 0;
        int cntRow = 0;

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();

        for (int i = 0; i < ugrdKpi.Rows.Count; i++)
        {
            row = ugrdKpi.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    if (iType == "ADD")
                    {
                        intRtn += objBSC.SetKpiParent
                                 ( int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString())
                                 , int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString())
                                 , this.IKpiRefID
                                 , 0
                                 , "N"
                                 , "N"
                                 , itxr_user);
                    }
                    else if (iType == "SET")
                    {
                        TemplatedColumn colTarget = (TemplatedColumn)row.Band.Columns.FromKey("ROLLUP_TARGET_YN");
                        TemplatedColumn colScore  = (TemplatedColumn)row.Band.Columns.FromKey("ROLLUP_SCORE_YN");
                        CheckBox chkTarget = (CheckBox)((CellItem)colTarget.CellItems[row.BandIndex]).FindControl("cBox");
                        CheckBox chkScore  = (CheckBox)((CellItem)colScore.CellItems[row.BandIndex]).FindControl("cBox");
                        

                        intRtn += objBSC.SetKpiParent
                                 ( int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString())
                                 , int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString())
                                 , this.IKpiRefID
                                 , double.Parse(row.Cells.FromKey("UP_KPI_WEIGHT").Value.ToString())
                                 , (chkTarget.Checked) ? "Y" : "N"
                                 , (chkScore.Checked) ? "Y" : "N"
                                 , itxr_user);
                    }
                    else if (iType == "DEL")
                    {
                        intRtn += objBSC.RemoveKpiParent
                                 ( int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString())
                                 , int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString())
                                 , itxr_user);
                    }
                }
                catch (Exception ex)
                {
                    PageUtility.AlertMessage(ex.Message);
                    return;
                }

                cntRow += 1;
            }
        }

        if (cntRow < 1)
        {
            PageUtility.AlertMessage("항목을 선택하세요.");
        }
        else
        {
            this.setChildKpi();
            this.setKpiData();
        }
    }

    #endregion

    #region 이벤트처리
    protected void ugrdKpiList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg        = (e.Row.Cells.FromKey("APP_STATUS").Value == null) ? "" : e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);

        iTRow += 1;
        if (strImg == Biz_Type.app_status_complete)
        {
            iCRow += 1;
        }

        lblCountRow.Text = "Total Rows : " + iCRow.ToString() + "/" + iTRow.ToString();

    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.setKpiData();
    }

    protected void addKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.SetKpiRelation("ADD");
    }
    
    protected void remKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.SetKpiRelation("DEL");
    }

    protected void iBtnSaveWeight_Click(object sender, ImageClickEventArgs e)
    {
        this.SetKpiRelation("SET");
    }

    protected void ugrdChildKpiTarget_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "KPI 코드";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "KPI명";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "L";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "가중치";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "운영조직";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "챔피언";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "단위";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = true;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "실적방식";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = true;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "결재상태";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = true;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 당 월 목 표 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 12;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = false;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 누 적 목 표 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 21;
        ch.RowLayoutColumnInfo.SpanX = 12;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = false;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i < 9)
            {
                ch = e.Layout.Bands[0].Columns[i].Header;
                ch.RowLayoutColumnInfo.OriginY = 0;
                ch.RowLayoutColumnInfo.OriginX = i;
                ch.RowLayoutColumnInfo.SpanY   = 2;
                e.Layout.Bands[0].Columns[i].Header.Style.BackColor = ColorTranslator.FromHtml("#94BAC9");
                e.Layout.Bands[0].Columns[i].Header.Style.ForeColor = Color.White;
                e.Layout.Bands[0].Columns[i].Header.Fixed = true;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Header.Fixed = false;
            }
        }
    }

    protected void ugrdChildKpiTarget_InitializeRow(object sender, RowEventArgs e)
    { 
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg        = (e.Row.Cells.FromKey("APP_STATUS").Value == null) ? "" : e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);

        iTRow += 1;
        if (strImg == Biz_Type.app_status_complete)
        {
            iCRow += 1;
        }

        lblCountRow.Text = "Total Rows : " + iCRow.ToString() + "/" + iTRow.ToString();
    }

    protected void ugrdChildKpi_InitializeRow(object sender, RowEventArgs e)
    {
        string sTargetYn = (e.Row.Cells.FromKey("ROLLUP_TARGET_YN").Value == null) ? "N" : e.Row.Cells.FromKey("ROLLUP_TARGET_YN").Value.ToString();
        string sScoreYn  = (e.Row.Cells.FromKey("ROLLUP_SCORE_YN").Value == null)  ? "N" : e.Row.Cells.FromKey("ROLLUP_SCORE_YN").Value.ToString();
        TemplatedColumn colTarget = (TemplatedColumn)e.Row.Band.Columns.FromKey("ROLLUP_TARGET_YN");
        TemplatedColumn colScore  = (TemplatedColumn)e.Row.Band.Columns.FromKey("ROLLUP_SCORE_YN");
        CheckBox chkTarget = (CheckBox)((CellItem)colTarget.CellItems[e.Row.BandIndex]).FindControl("cBox");
        CheckBox chkScore  = (CheckBox)((CellItem)colScore.CellItems[e.Row.BandIndex]).FindControl("cBox");

        chkTarget.Checked = (sTargetYn == "Y") ? true : false;
        chkScore.Checked  = (sScoreYn == "Y") ? true : false;
    }

    protected void ugrdKpiStatusTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        if (e.Tab.Key == "1")
        {
            lblCountRow.Text  = "";
            ugrdKpiList.Clear();
        }
        else
        {
            lblCountRow.Text  = "";
            this.SetChildKpiTarget();
        }
    }
    #endregion
}