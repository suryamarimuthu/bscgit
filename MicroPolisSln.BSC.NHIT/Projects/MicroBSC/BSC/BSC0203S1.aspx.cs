using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

public partial class BSC_BSC0203S1 : AppPageBase
{
    #region 변수선언 및 초기화
    int intGridRow      = 0;

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

    public int IEstDeptRefID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "000000");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    private string sPfxDeptId = "DID_";  // 부서id
    private string sPfxStgId  = "SID_";  // 전략id
    private string sPfxStgNm  = "SNM_";  // 전략명
    private string sPfxKpiId  = "KID_";  // 지표ID
    private string sPfxKpiNm  = "KNM_";  // 지표명
    private string sPfxTarget = "TGT_";  // 목표
    private string sPfxResult = "RST_";  // 실적
    private string sPfxSignal = "SGN_";  // 시그널
    private string sPfxWeight = "WGT_";  // 가중치

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            iBtnPrint.Style.Add("vertical-align", "middle");
            iBtnSearch.Attributes.Add("onclick", "ShowYahooScreen('문챠트를 조회하고 있습니다... 다량의 데이터 전송으로 인해 시간이 걸릴 수 있습니다.')");
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

            int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
            WebCommon.SetEstDeptDropDownList(ddlEstDept, intEstTermId, false, gUserInfo.Emp_Ref_ID);

            WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);

            setKpiData();
        }

        ltrScript.Text = "";
    }

    #endregion

    // test


    #region 초기 세팅 메소드

    #endregion

    #region 내부 함수

    public void setKpiData()
    {
        if (ddlEstTermInfo.Items.Count < 1)
        {
            PageUtility.AlertMessage("등록된 평가기간이 없습니다.");
            return;
        }

        string iresult_input_method = "";
        string ikpi_code         = "";
        string ikpi_name         = "";
        string iemp_name         = "";
        int    ilogin_id         = int.Parse(gUserInfo.Emp_Ref_ID.ToString());
        string ikpi_group_ref_id = "";

        this.SetParameter();

        MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi objKpi = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi();
        DataSet ds = objKpi.GetKpiListPerEstDept(this.IEstTermRefID, this.IEstDeptRefID, this.IYmd, iresult_input_method, ikpi_code, ikpi_name, iemp_name, ikpi_group_ref_id);

        ugrdMoonChart.Visible = true;
        ugrdMoonChart.Clear();

        lblCountRow.Text = "Total Rows : " + ugrdMoonChart.Rows.Count.ToString();

    }

    public void SetParameter()
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IEstDeptRefID = PageUtility.GetIntByValueDropDownList(ddlEstDept);
        this.IYmd = PageUtility.GetByValueDropDownList(ddlEstTermMonth);
    }

    public void SetPrintMoonChartGrid()
    {
        ugrdMoonChart.Visible = true;

        this.IEstTermRefID      = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IEstDeptRefID      = PageUtility.GetIntByValueDropDownList(ddlEstDept);
        this.IYmd               = PageUtility.GetByValueDropDownList(ddlEstTermMonth);

        DeptInfos objDept = new DeptInfos();
        DataSet rDs = objDept.GetEstDeptHaveMap(this.IEstTermRefID, this.IYmd, this.IEstDeptRefID, gUserInfo.Emp_Ref_ID);

        Biz_Bsc_Map_Kpi objMap = new Biz_Bsc_Map_Kpi();
        DataSet rDsKpi = null;
        DataSet rDsTop = null;

        string strEstDeptID = "";
        string strEstDeptNm = "";
        string strViwID     = "";
        string strViwName   = "";
        string strStgID     = "";
        string strStgName   = "";
        string strKpiID     = "";
        string strKpiName   = "";
        string strUnit      = "";
        string strTarget    = "";
        string strResult    = "";
        string strWeight    = "";
        
        int intRow      = rDs.Tables[0].Rows.Count;
        DataRow rDr     = null;
        DataRow rDrKpi  = null;
        ColumnHeader ch = null;

        ugrdMoonChart.Clear();

        for (int i = ugrdMoonChart.Columns.Count; i > 0; i--)
        {
            ugrdMoonChart.Bands[0].Columns.RemoveAt(i-1);
            ugrdMoonChart.Bands[0].HeaderLayout.RemoveAt(i - 1);
        }

        ugrdMoonChart.ResetColumns();

        for (int i = 0; i < intRow; i++)
        {
            rDr = rDs.Tables[0].Rows[i];
            strEstDeptID = rDr["EST_DEPT_REF_ID"].ToString();
            strEstDeptNm = rDr["DEPT_NAME"].ToString();
            strViwID     = strEstDeptID+"_VIEW_REF_ID";
            strViwName   = strEstDeptID+"_VIEW_NAME";
            strStgID     = strEstDeptID+"_STG_REF_ID";
            strStgName   = strEstDeptID+"_STG_NAME";
            strKpiName   = strEstDeptID+"_KPI_REF_ID";
            strUnit      = strEstDeptID+"_UNIT";
            strTarget    = strEstDeptID+"_TARGET";
            strResult    = strEstDeptID+"_RESULT";
            strWeight    = strEstDeptID+"_WEIGHT";

            ugrdMoonChart.Columns.Add(strViwName, "관점명");
            ugrdMoonChart.Columns.Add(strStgID  , "전략ID");
            ugrdMoonChart.Columns.Add(strStgName, "전략명");
            ugrdMoonChart.Columns.Add(strKpiName, "지표명");
            ugrdMoonChart.Columns.Add(strUnit   , "단위");
            ugrdMoonChart.Columns.Add(strResult , "전년실적");
            ugrdMoonChart.Columns.Add(strTarget , "목표");
            ugrdMoonChart.Columns.Add(strWeight , "가중치");

            ugrdMoonChart.Columns.FromKey(strViwName).Width = (i==0) ? Unit.Pixel(60)  : Unit.Pixel(0);
            ugrdMoonChart.Columns.FromKey(strStgID).Width   = Unit.Pixel(0);
            ugrdMoonChart.Columns.FromKey(strStgName).Width = (i==0) ? Unit.Pixel(100) : Unit.Pixel(0);
            ugrdMoonChart.Columns.FromKey(strKpiName).Width = Unit.Pixel(160);
            ugrdMoonChart.Columns.FromKey(strUnit).Width    = Unit.Pixel(30);
            ugrdMoonChart.Columns.FromKey(strTarget).Width  = Unit.Pixel(80);
            ugrdMoonChart.Columns.FromKey(strResult).Width  = Unit.Pixel(80);
            ugrdMoonChart.Columns.FromKey(strWeight).Width  = Unit.Pixel(50);

            ugrdMoonChart.Columns.FromKey(strUnit).CellStyle.HorizontalAlign   = HorizontalAlign.Center;
            ugrdMoonChart.Columns.FromKey(strTarget).CellStyle.HorizontalAlign = HorizontalAlign.Right;
            ugrdMoonChart.Columns.FromKey(strResult).CellStyle.HorizontalAlign = HorizontalAlign.Right;
            ugrdMoonChart.Columns.FromKey(strWeight).CellStyle.HorizontalAlign = HorizontalAlign.Right;

            ugrdMoonChart.Columns.FromKey(strTarget).Format = "#,##0.00";
            ugrdMoonChart.Columns.FromKey(strResult).Format = "#,##0.00";
            ugrdMoonChart.Columns.FromKey(strWeight).Format = "#,##0.00";

            ugrdMoonChart.Columns.FromKey(strViwName).Header.RowLayoutColumnInfo.OriginX = 0+(i*8);
            ugrdMoonChart.Columns.FromKey(strStgID).Header.RowLayoutColumnInfo.OriginX   = 1+(i*8);
            ugrdMoonChart.Columns.FromKey(strStgName).Header.RowLayoutColumnInfo.OriginX = 2+(i*8);
            ugrdMoonChart.Columns.FromKey(strKpiName).Header.RowLayoutColumnInfo.OriginX = 3+(i*8);
            ugrdMoonChart.Columns.FromKey(strUnit).Header.RowLayoutColumnInfo.OriginX    = 4+(i*8);
            ugrdMoonChart.Columns.FromKey(strResult).Header.RowLayoutColumnInfo.OriginX  = 5+(i*8);
            ugrdMoonChart.Columns.FromKey(strTarget).Header.RowLayoutColumnInfo.OriginX  = 6+(i*8);            
            ugrdMoonChart.Columns.FromKey(strWeight).Header.RowLayoutColumnInfo.OriginX  = 7+(i*8);

            ugrdMoonChart.Columns.FromKey(strViwName).Header.RowLayoutColumnInfo.OriginY = 1;
            ugrdMoonChart.Columns.FromKey(strStgID).Header.RowLayoutColumnInfo.OriginY   = 1;
            ugrdMoonChart.Columns.FromKey(strStgName).Header.RowLayoutColumnInfo.OriginY = 1;
            ugrdMoonChart.Columns.FromKey(strKpiName).Header.RowLayoutColumnInfo.OriginY = 1;
            ugrdMoonChart.Columns.FromKey(strUnit).Header.RowLayoutColumnInfo.OriginY    = 1;
            ugrdMoonChart.Columns.FromKey(strTarget).Header.RowLayoutColumnInfo.OriginY  = 1;
            ugrdMoonChart.Columns.FromKey(strResult).Header.RowLayoutColumnInfo.OriginY  = 1;
            ugrdMoonChart.Columns.FromKey(strWeight).Header.RowLayoutColumnInfo.OriginY  = 1;

            rDsKpi = objMap.GetKpiForMoonchart(this.IEstTermRefID, Convert.ToInt32(strEstDeptID), this.IYmd);
            int cntKpi = rDsKpi.Tables[0].Rows.Count;

            if (i == 0)
            {
                // 최상위 부서의 데이터 복사
                rDsTop = rDsKpi.Copy();
                rDsTop.Tables[0].Columns.Add("RowUseYN", typeof(string));
                rDsTop.Tables[0].Columns.Add("NewYN", typeof(string));

                ugrdMoonChart.Columns.FromKey(strViwName).Header.Fixed = true;
                ugrdMoonChart.Columns.FromKey(strStgID).Header.Fixed   = true;
                ugrdMoonChart.Columns.FromKey(strStgName).Header.Fixed = true;
                ugrdMoonChart.Columns.FromKey(strKpiName).Header.Fixed = true;
                ugrdMoonChart.Columns.FromKey(strUnit).Header.Fixed    = true;
                ugrdMoonChart.Columns.FromKey(strTarget).Header.Fixed  = true;
                ugrdMoonChart.Columns.FromKey(strResult).Header.Fixed  = true;
                ugrdMoonChart.Columns.FromKey(strWeight).Header.Fixed  = true;

                ch = new ColumnHeader(true);
                ch.Caption = strEstDeptNm;
                ch.RowLayoutColumnInfo.OriginY = 0;
                ch.RowLayoutColumnInfo.OriginX = 0;
                ch.RowLayoutColumnInfo.SpanX   = 8;
                ch.Style.Height                = Unit.Pixel(20);
                ugrdMoonChart.Bands[0].HeaderLayout.Add(ch);
                ugrdMoonChart.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                ch = null;

                ugrdMoonChart.Columns.FromKey(strViwName).MergeCells = true;
                ugrdMoonChart.Columns.FromKey(strStgID).MergeCells   = true;
                ugrdMoonChart.Columns.FromKey(strStgName).MergeCells = true;
                ugrdMoonChart.Columns.FromKey(strKpiName).MergeCells = true;
                
                for (int k = 0; k < cntKpi; k++)
                {
                    rDrKpi = rDsKpi.Tables[0].Rows[k];
                    ugrdMoonChart.Rows.Add();
                    ugrdMoonChart.Rows[k].Cells.FromKey(strViwName).Value = rDrKpi["VIEW_NAME"].ToString();
                    ugrdMoonChart.Rows[k].Cells.FromKey(strStgID).Value   = rDrKpi["STG_REF_ID"].ToString();
                    ugrdMoonChart.Rows[k].Cells.FromKey(strStgName).Value = rDrKpi["STG_NAME"].ToString();
                    ugrdMoonChart.Rows[k].Cells.FromKey(strKpiName).Value = rDrKpi["KPI_NAME"].ToString();
                    ugrdMoonChart.Rows[k].Cells.FromKey(strUnit).Value    = rDrKpi["UNIT"].ToString();
                    ugrdMoonChart.Rows[k].Cells.FromKey(strTarget).Value  = Convert.ToDouble(rDrKpi["TARGET"].ToString());
                    ugrdMoonChart.Rows[k].Cells.FromKey(strResult).Value  = Convert.ToDouble(rDrKpi["RESULT"].ToString());
                    ugrdMoonChart.Rows[k].Cells.FromKey(strWeight).Value  = Convert.ToDouble(rDrKpi["WEIGHT"].ToString());
                }
            }
            else
            { 
                ch = new ColumnHeader(true);
                ch.Caption = strEstDeptNm;
                ch.RowLayoutColumnInfo.OriginY = 0;
                ch.RowLayoutColumnInfo.OriginX = (i * 8);
                ch.RowLayoutColumnInfo.SpanX   = 8;
                ch.Style.Height                = Unit.Pixel(20);
                ugrdMoonChart.Bands[0].HeaderLayout.Add(ch);
                ugrdMoonChart.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                ch = null;

                string strStgRefID = "";
                int intIdx         = 0;
                string strCurKPI   = "0";
                bool blnPrintYN    = false;
                bool blnHaveKpi    = false;
                bool blnExitsKpi   = false;
                string[] ArrKpi    = null;

                // 최상위부서 행번호 사용여부 초기화
                for (int y = 0; y < rDsTop.Tables[0].Rows.Count; y++)
                {
                    rDsTop.Tables[0].Rows[y]["RowUseYN"] = "N";
                }

                #region -- 현재 부서의 지표 인쇄
                // 현재 조직을 기준으로 검색한다
                for (int k = 0; k < cntKpi; k++)
                {
                    rDrKpi      = rDsKpi.Tables[0].Rows[k];
                    strStgRefID = rDrKpi["STG_REF_ID"].ToString();
                    strCurKPI   = rDrKpi["KPI_REF_ID"].ToString();
                    intIdx      = 0;
                    blnHaveKpi  = false;
                    blnPrintYN  = false;
                    blnExitsKpi = false;

                    #region -- 지표별 인쇄 --
                    // 최상위 부서의 데이터셋에서 나의 지표아이디가 있는지 검색한다
                    // 첫번째로 상위지표별로 검색하고 없으면 전략아이디로 검색한다
                    for (int x = 0; x < rDsTop.Tables[0].Rows.Count; x++)
                    {
                        ArrKpi = rDsTop.Tables[0].Rows[x]["CHILD_KPI"].ToString().Split(',');
                        ArrKpi.Initialize();
                        blnExitsKpi = false;
                        for (int n = 0; n < ArrKpi.Length; n++)
                        {
                            if (ArrKpi[n] == strCurKPI)
                            {
                                blnExitsKpi = true;
                                break;
                            }
                        }

                        if (blnExitsKpi)
                        {
                            if (rDsTop.Tables[0].Rows[x]["RowUseYN"].ToString() == "N" || 
                                rDsTop.Tables[0].Rows[x]["RowUseYN"] == DBNull.Value   ||
                                rDsTop.Tables[0].Rows[x]["RowUseYN"] == "")
                            {
                                intIdx = x;                                
                                blnPrintYN = true;
                                blnHaveKpi = true;
                                rDsTop.Tables[0].Rows[x]["RowUseYN"] = "Y";
                                break;
                            }
                            else
                            { 
                                intIdx = x;
                                blnHaveKpi = true;
                            }
                        }
                        else
                        {                            
                            blnPrintYN = false;
                        }

                        ArrKpi = null;
                    }

                    //if (!blnHaveKpi && !blnPrintYN)
                    //{
                    //    // 최상위 부서의 데이터셋에서 나의 전략아이디가 있는지 검색한다
                    //    // 두번째로 상위지표별로 검색하고 없으면 전략아이디로 검색한다
                    //    for (int x = 0; x < rDsTop.Tables[0].Rows.Count; x++)
                    //    {
                    //        if (rDsTop.Tables[0].Rows[x]["STG_REF_ID"].ToString() == strStgRefID)
                    //        {
                    //            if (rDsTop.Tables[0].Rows[x]["RowUseYN"].ToString() == "N" ||
                    //                rDsTop.Tables[0].Rows[x]["RowUseYN"] == DBNull.Value ||
                    //                rDsTop.Tables[0].Rows[x]["RowUseYN"] == "")
                    //            {
                    //                intIdx = x;
                    //                blnPrintYN = true;
                    //                blnHaveKpi = true;
                    //                rDsTop.Tables[0].Rows[x]["RowUseYN"] = "Y";
                    //                break;
                    //            }
                    //            else
                    //            {
                    //                intIdx = x;
                    //                blnHaveKpi = true;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            blnPrintYN = false;
                    //        }
                    //    }
                    //}

                    try
                    {
                        // 나의 지표아이디가 최상위 부서에 존재하고 프린트할 자리도 있는 경우
                        if (blnHaveKpi && blnPrintYN)
                        {
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strViwName).Value = rDrKpi["VIEW_NAME"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strStgID).Value   = rDrKpi["STG_REF_ID"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strStgName).Value = rDrKpi["STG_NAME"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strKpiName).Value = rDrKpi["KPI_NAME"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strUnit).Value    = rDrKpi["UNIT"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strTarget).Value  = Convert.ToDouble(rDrKpi["TARGET"].ToString());
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strResult).Value  = Convert.ToDouble(rDrKpi["RESULT"].ToString());
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strWeight).Value  = Convert.ToDouble(rDrKpi["WEIGHT"].ToString());
                        }
                        // 상위지표는 존재 하나 프린트할 자리가 없는경우
                        // 행을 하나 늘이고 인쇄한다
                        else if (!blnPrintYN && blnHaveKpi) 
                        { 
                            UltraGridRow ugrNew = new UltraGridRow();
                            for (int m = 0; m < 8; m++)
                            {
                                ugrNew.Cells.Add(ugrdMoonChart.Rows[intIdx].Cells[m]);
                            }

                            ugrdMoonChart.Rows.Insert(intIdx+1, ugrNew);

                            DataRow drNew = rDsTop.Tables[0].NewRow();
                            int TopCnt = rDsTop.Tables[0].Columns.Count;
                            for (int z = 0; z < TopCnt; z++)
                            { 
                                drNew[z] = rDsTop.Tables[0].Rows[intIdx][z];
                                // 새로 추가된 행을 구분하고 검색후 삭제한다
                                if (z == (TopCnt - 1))
                                {
                                    drNew[z] = "Y";
                                }
                            }

                            rDsTop.Tables[0].Rows.InsertAt(drNew, intIdx);

                            intIdx += 1;

                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strViwName).Value = rDrKpi["VIEW_NAME"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strStgID).Value   = rDrKpi["STG_REF_ID"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strStgName).Value = rDrKpi["STG_NAME"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strKpiName).Value = rDrKpi["KPI_NAME"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strUnit).Value    = rDrKpi["UNIT"].ToString();
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strTarget).Value  = Convert.ToDouble(rDrKpi["TARGET"].ToString());
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strResult).Value  = Convert.ToDouble(rDrKpi["RESULT"].ToString());
                            ugrdMoonChart.Rows[intIdx].Cells.FromKey(strWeight).Value  = Convert.ToDouble(rDrKpi["WEIGHT"].ToString());
                        }
                        #endregion

                    }
                    catch(Exception e)
                    {
                        ltrScript.Text = JSHelper.GetAlertScript(e.Message, false);
                    }
                }
                #endregion
            }

            rDsKpi = null;
        }

        lblCountRow.Text = "Total Rows : "+ugrdMoonChart.Rows.Count.ToString();
    }

    public void SetPrintGrid()
    {
        if (ugrdMoonChart.Columns.Count > 256)
        {
            ltrScript.Text = JSHelper.GetAlertScript("컬럼수가 엑셀시트의 컬럼수 보다 많습니다. 인쇄할수 없습니다.", false);
            return;
        }

        ugrdEEP.ExcelStartRow = 2;
        ugrdEEP.ExportMode    = ExportMode.Download;
        ugrdEEP.DownloadName  = "MoonChart";
        ugrdEEP.WorksheetName = "MoonChartPerEstimationDept";
        ugrdEEP.Export(ugrdMoonChart);
        return;
    }

    /// <summary>
    /// 결재아이콘 범례생성
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SetDraftLegend(object sender, LayoutEventArgs e)
    { 
        try
        {
            e.Layout.StationaryMargins                  = StationaryMargins.HeaderAndFooter;
            e.Layout.CellClickActionDefault             = CellClickAction.RowSelect;
            e.Layout.ColFootersVisibleDefault           = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height          = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor       = Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor       = Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right    = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.FooterStyleDefault.VerticalAlign   = VerticalAlign.Middle;

            int iCol  = e.Layout.Bands[0].Columns.Count - 1;
            int iMrg  = iCol;  // Start Colspan Length
            int iFRow = 0;     // Start Colspan Index
            for (int i = 0; i < iCol; i++)
            {
                iFRow += 1;
                if (e.Layout.Bands[0].Columns[i].Hidden)
                {
                    iMrg -= 1;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX     = iMrg;
                    break;
                }
            }

            if (iFRow > 0)
            {
                string sLegend = Biz_Type.app_legend;

                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Caption = sLegend;
                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Style.Width = Unit.Percentage(100);
            }
        }
        catch (Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript(ex.Message);
        }
    }

    #region ================================ [ 전략별 인과관계분석 ] ================================
    public DataTable GetStgCaE()
    { 
        // 1. 전략을 가진 부서를 조회하여 컬럼으로 늘이기
        Biz_Bsc_Map_Stg objStg = new Biz_Bsc_Map_Stg();
        DataSet dsDept = objStg.GetEstDeptHaveStrategy(this.IEstTermRefID, this.IEstDeptRefID, this.IYmd);

        DataTable dtStgMoon = new DataTable("STG_MOON_CHART");
        string sDeptId = "";

        string cDeptId = "";  // 부서id
        string cStgId  = "";  // 전략id
        string cStgNm  = "";  // 전략명
        string cKpiId  = "";  // 지표ID
        string cKpiNm  = "";  // 지표명
        string cTarget = "";  // 목표
        string cResult = "";  // 실적
        string cSignal = "";  // 시그널
        string cWeight = "";  // 가중치

        if (dsDept.Tables.Count > 0)
        {
            for (int i = 0; i < dsDept.Tables[0].Rows.Count; i++)
            {
                sDeptId = dsDept.Tables[0].Rows[i]["EST_DEPT_REF_ID"].ToString();
                cDeptId  = sPfxDeptId + sDeptId;
                cStgId   = sPfxStgId  + sDeptId;
                cStgNm   = sPfxStgNm  + sDeptId;
                cKpiId   = sPfxKpiId  + sDeptId;
                cKpiNm   = sPfxKpiNm  + sDeptId;
                cTarget  = sPfxTarget + sDeptId;
                cResult  = sPfxResult + sDeptId;
                cSignal  = sPfxSignal + sDeptId;
                cWeight  = sPfxWeight + sDeptId;

                dtStgMoon.Columns.Add(cStgId,  typeof(string));
                dtStgMoon.Columns.Add(cStgNm,  typeof(string));
                dtStgMoon.Columns.Add(cKpiId,  typeof(string));
                dtStgMoon.Columns.Add(cKpiNm,  typeof(string));
                dtStgMoon.Columns.Add(cTarget, typeof(string));
                dtStgMoon.Columns.Add(cResult, typeof(string));
                dtStgMoon.Columns.Add(cSignal, typeof(string));
                dtStgMoon.Columns.Add(cWeight, typeof(string));
            }
        }

        // 2. 전략관계가져오기
        Biz_Bsc_Stg_Tree_Term objSTerm = new Biz_Bsc_Stg_Tree_Term(this.IEstTermRefID,this.IYmd);
        

        //Biz_Bsc_Stg_Tree objSTree = new Biz_Bsc_Stg_Tree();
        //DataSet dtSTree = objSTree.GetStgTree(this.IEstTermRefID, objSTerm.IVersion_Ref_Id);


        // 3. 해당조직의 전략을 조회하여 나래비를 세움
        Biz_Bsc_Map_Kpi objKpi  = new Biz_Bsc_Map_Kpi();

        if (dsDept.Tables.Count > 0)
        {
            for (int k = 0; k < dsDept.Tables[0].Rows.Count; k++)
            {
                sDeptId = dsDept.Tables[0].Rows[k]["EST_DEPT_REF_ID"].ToString();
                DataSet dsStgDept = objKpi.GetKpiAnalysisPerEstDept(this.IEstTermRefID, int.Parse(sDeptId), this.IYmd, 0, "MS");
                if (dsStgDept.Tables.Count > 0)
                {
                    DataRow dr = null;
                    for (int i = 0; i < dsStgDept.Tables[0].Rows.Count; i++)
                    {
                        dr = dtStgMoon.NewRow();
                        sDeptId = dsStgDept.Tables[0].Rows[i]["EST_DEPT_REF_ID"].ToString();
                        cDeptId  = sPfxDeptId + sDeptId;
                        cStgId   = sPfxStgId  + sDeptId;
                        cStgNm   = sPfxStgNm  + sDeptId;
                        cKpiId   = sPfxKpiId  + sDeptId;
                        cKpiNm   = sPfxKpiNm  + sDeptId;
                        cTarget  = sPfxTarget + sDeptId;
                        cResult  = sPfxResult + sDeptId;
                        cSignal  = sPfxSignal + sDeptId;
                        cWeight  = sPfxWeight + sDeptId;

                        dr[cStgId]  = dsStgDept.Tables[0].Rows[i]["STG_REF_ID"].ToString();
                        dr[cStgNm]  = dsStgDept.Tables[0].Rows[i]["STG_NAME"].ToString();
                        dr[cKpiId]  = dsStgDept.Tables[0].Rows[i]["KPI_REF_ID"].ToString();
                        dr[cKpiNm]  = dsStgDept.Tables[0].Rows[i]["KPI_NAME"].ToString();
                        dr[cTarget] = dsStgDept.Tables[0].Rows[i]["TARGET"].ToString();
                        dr[cResult] = dsStgDept.Tables[0].Rows[i]["RESULT"].ToString();
                        dr[cSignal] = dsStgDept.Tables[0].Rows[i]["THRESHOLD_IMG"].ToString();
                        dr[cWeight] = dsStgDept.Tables[0].Rows[i]["WEIGHT"].ToString();

                        dtStgMoon.Rows.Add(dr);
                    }
                }

                if (k == 2)
                    break;
            }
        }


        return dtStgMoon;
    }

    public void SetStgCaEGrid()
    {
        for (int i = ugrdMoonChart.Columns.Count; i > 0; i--)
        {
            ugrdMoonChart.Bands[0].Columns.RemoveAt(i - 1);
            ugrdMoonChart.Bands[0].HeaderLayout.RemoveAt(i - 1);
        }

        ugrdMoonChart.ResetColumns();

        ugrdMoonChart.Clear();
        ugrdMoonChart.DataSource = this.GetStgCaE().DefaultView;
        ugrdMoonChart.DataBind();

    }
    #endregion

    #endregion

    #region 서버 이벤트 처리 함수
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetParameter();
        if (PageUtility.GetByValueRadioButtonList(rdoSelect) == "K")
        {
            this.SetPrintMoonChartGrid();
        }
        else
        {
            this.SetStgCaEGrid();
        }
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.setKpiData();
    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.SetPrintGrid();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetEstDeptDropDownList(ddlEstDept, intEstTermId, true);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        this.setKpiData();
    }

    protected void ugrdMoonChart_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.FixedColumnScrollType = FixedColumnScrollType.Pixel;
    }
    #endregion
}
