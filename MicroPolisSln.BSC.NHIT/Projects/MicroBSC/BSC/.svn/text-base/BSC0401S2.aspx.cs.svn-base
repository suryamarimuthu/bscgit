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

public partial class BSC_BSC0401S2 : AppPageBase
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

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdMapKpi.DisplayLayout.Bands[0].Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");

        if (!IsPostBack)
        {
            iBtnPrint.Style.Add("vertical-align", "middle");
            iBtnMoonChart.Attributes.Add("onclick", "ShowYahooScreen('문챠트를 조회하고 있습니다... 다량의 데이터 전송으로 인해 시간이 걸릴 수 있습니다.')");
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

            int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
            WebCommon.SetEstDeptDropDownList(ddlEstDept, intEstTermId, false, gUserInfo.Emp_Ref_ID);
            WebUtility.FindByValueDropDownList(ddlEstDept, gUserInfo.Dept_Ref_ID);


            WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);

            Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
            objCode.getResultMethod(ddlResultInput, "", true, 100);
            objCode.GetKpiType(ddlKpiGroupRefID, "", true, 100);

            setKpiData();
        }

        ltrScript.Text = "";
    }

    #endregion

    #region 초기 세팅 메소드

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.setKpiData();
    }

    #endregion

    #region 내부 함수

    public void setKpiData()
    {
        if (ddlEstTermInfo.Items.Count < 1)
        {
            PageUtility.AlertMessage("등록된 평가기간이 없습니다.");
            return;
        }

        string iresult_input_method = ddlResultInput.SelectedValue;
        string ikpi_code         = txtKPICode.Text.Trim();
        string ikpi_name         = txtKPIName.Text.Trim();
        string iemp_name         = txtChamName.Text.Trim();
        int    ilogin_id         = int.Parse(gUserInfo.Emp_Ref_ID.ToString());
        string ikpi_group_ref_id = PageUtility.GetByValueDropDownList(ddlKpiGroupRefID);

        this.IEstTermRefID      = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IEstDeptRefID      = PageUtility.GetIntByValueDropDownList(ddlEstDept);
        this.IYmd               = PageUtility.GetByValueDropDownList(ddlEstTermMonth);
        string ikpi_use_yn = "Y";
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi objKpi = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi();
        DataSet ds = objKpi.GetKpiListPerEstDept2(this.IEstTermRefID, this.IEstDeptRefID, this.IYmd, iresult_input_method, ikpi_code, ikpi_name, iemp_name, ikpi_group_ref_id, ikpi_use_yn);

        ugrdMapKpi.Visible = true;
        ugrdMoonChartForPrint.Visible = false;
        ugrdMoonChartForPrint.Clear();

        ugrdMapKpi.Clear();
        ugrdMapKpi.DataSource = ds;
        ugrdMapKpi.DataBind();

        lblRowCount.Text = ugrdMapKpi.Rows.Count.ToString("#,##0");

    }

    public void SetKpiConfirmCancel(DataTable iTs, string strGubun)
    {
        //int i = 0;
        //int intRow = iTs.Rows.Count;
        //this.IEstTermRefID      = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        //int ikpi_ref_id = 0;

        //IDataParameterCollection col;

        //Biz_Kpi_Info objKpi = new Biz_Kpi_Info();
        //for (i = 0; i < intRow; i++)
        //{
        //    ikpi_ref_id = int.Parse(iTs.Rows[i]["KPI_REF_ID"].ToString());
        //    col = (strGubun == "CONFIRM") ? objKpi.SetKpiConirm(this.IEstTermRefID, ikpi_ref_id)
        //                                  : objKpi.SetKpiCancel(this.IEstTermRefID, ikpi_ref_id);

        //    if (DbAgentBase.GetOutputParameterValueBySP(col, "@iRTN_COMPLETE_YN").ToString() == "N")
        //    {
        //        break;
        //    }
        //}
        ////string strMsg = "총 " + intRow.ToString() + "건중 " + i.ToString() + "건이 처리되었습니다.";
        //string strMsg   = string.Format("총 {0}건중 {1}건이 처리되었습니다.", intRow, i);
        //ltrScript.Text  = JSHelper.GetAlertScript(strMsg, false);
    }

    public void GetCountConfirmCancel(string strGubun)
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;

        DataTable dt = new DataTable("tblKpiConfirmList");
        dt.Columns.Add("KPI_REF_ID", typeof(int));
        DataRow dr;

        for (int i = 0; i < ugrdMapKpi.Rows.Count; i++)
        {
            row = ugrdMapKpi.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    dr = dt.NewRow();
                    dr["KPI_REF_ID"] = int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                    dt.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    PageUtility.AlertMessage(ex.Message);
                    return;
                }
            }
        }

        if (dt.Rows.Count < 1)
        {
            PageUtility.AlertMessage("확정 항목을 선택하세요.");
        }
        else
        {
            this.SetKpiConfirmCancel(dt, strGubun);
            this.setKpiData();
        }
    }

    public void SetPrintMoonChartGrid()
    {
        ugrdMapKpi.Visible = false;
        ugrdMapKpi.Clear();
        ugrdMoonChartForPrint.Visible = true;

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

        ugrdMoonChartForPrint.Clear();

        for (int i = ugrdMoonChartForPrint.Columns.Count; i > 0; i--)
        {
            ugrdMoonChartForPrint.Bands[0].Columns.RemoveAt(i-1);
            ugrdMoonChartForPrint.Bands[0].HeaderLayout.RemoveAt(i - 1);
        }

        ugrdMoonChartForPrint.ResetColumns();

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

            ugrdMoonChartForPrint.Columns.Add(strViwName, "관점명");
            ugrdMoonChartForPrint.Columns.Add(strStgID  , "전략ID");
            ugrdMoonChartForPrint.Columns.Add(strStgName, "전략명");
            ugrdMoonChartForPrint.Columns.Add(strKpiName, "지표명");
            ugrdMoonChartForPrint.Columns.Add(strUnit   , "단위");
            ugrdMoonChartForPrint.Columns.Add(strResult , "전년실적");
            ugrdMoonChartForPrint.Columns.Add(strTarget , "목표");
            ugrdMoonChartForPrint.Columns.Add(strWeight , "가중치");

            ugrdMoonChartForPrint.Columns.FromKey(strViwName).Width = (i==0) ? Unit.Pixel(60)  : Unit.Pixel(0);
            ugrdMoonChartForPrint.Columns.FromKey(strStgID).Width   = Unit.Pixel(0);
            ugrdMoonChartForPrint.Columns.FromKey(strStgName).Width = (i==0) ? Unit.Pixel(100) : Unit.Pixel(0);
            ugrdMoonChartForPrint.Columns.FromKey(strKpiName).Width = Unit.Pixel(160);
            ugrdMoonChartForPrint.Columns.FromKey(strUnit).Width    = Unit.Pixel(30);
            ugrdMoonChartForPrint.Columns.FromKey(strTarget).Width  = Unit.Pixel(80);
            ugrdMoonChartForPrint.Columns.FromKey(strResult).Width  = Unit.Pixel(80);
            ugrdMoonChartForPrint.Columns.FromKey(strWeight).Width  = Unit.Pixel(50);

            ugrdMoonChartForPrint.Columns.FromKey(strUnit).CellStyle.HorizontalAlign   = HorizontalAlign.Center;
            ugrdMoonChartForPrint.Columns.FromKey(strTarget).CellStyle.HorizontalAlign = HorizontalAlign.Right;
            ugrdMoonChartForPrint.Columns.FromKey(strResult).CellStyle.HorizontalAlign = HorizontalAlign.Right;
            ugrdMoonChartForPrint.Columns.FromKey(strWeight).CellStyle.HorizontalAlign = HorizontalAlign.Right;

            ugrdMoonChartForPrint.Columns.FromKey(strTarget).Format = "#,##0.00";
            ugrdMoonChartForPrint.Columns.FromKey(strResult).Format = "#,##0.00";
            ugrdMoonChartForPrint.Columns.FromKey(strWeight).Format = "#,##0.00";

            ugrdMoonChartForPrint.Columns.FromKey(strViwName).Header.RowLayoutColumnInfo.OriginX = 0+(i*8);
            ugrdMoonChartForPrint.Columns.FromKey(strStgID).Header.RowLayoutColumnInfo.OriginX   = 1+(i*8);
            ugrdMoonChartForPrint.Columns.FromKey(strStgName).Header.RowLayoutColumnInfo.OriginX = 2+(i*8);
            ugrdMoonChartForPrint.Columns.FromKey(strKpiName).Header.RowLayoutColumnInfo.OriginX = 3+(i*8);
            ugrdMoonChartForPrint.Columns.FromKey(strUnit).Header.RowLayoutColumnInfo.OriginX    = 4+(i*8);
            ugrdMoonChartForPrint.Columns.FromKey(strResult).Header.RowLayoutColumnInfo.OriginX  = 5+(i*8);
            ugrdMoonChartForPrint.Columns.FromKey(strTarget).Header.RowLayoutColumnInfo.OriginX  = 6+(i*8);            
            ugrdMoonChartForPrint.Columns.FromKey(strWeight).Header.RowLayoutColumnInfo.OriginX  = 7+(i*8);

            ugrdMoonChartForPrint.Columns.FromKey(strViwName).Header.RowLayoutColumnInfo.OriginY = 1;
            ugrdMoonChartForPrint.Columns.FromKey(strStgID).Header.RowLayoutColumnInfo.OriginY   = 1;
            ugrdMoonChartForPrint.Columns.FromKey(strStgName).Header.RowLayoutColumnInfo.OriginY = 1;
            ugrdMoonChartForPrint.Columns.FromKey(strKpiName).Header.RowLayoutColumnInfo.OriginY = 1;
            ugrdMoonChartForPrint.Columns.FromKey(strUnit).Header.RowLayoutColumnInfo.OriginY    = 1;
            ugrdMoonChartForPrint.Columns.FromKey(strTarget).Header.RowLayoutColumnInfo.OriginY  = 1;
            ugrdMoonChartForPrint.Columns.FromKey(strResult).Header.RowLayoutColumnInfo.OriginY  = 1;
            ugrdMoonChartForPrint.Columns.FromKey(strWeight).Header.RowLayoutColumnInfo.OriginY  = 1;

            rDsKpi = objMap.GetKpiForMoonchart(this.IEstTermRefID, Convert.ToInt32(strEstDeptID), this.IYmd);
            int cntKpi = rDsKpi.Tables[0].Rows.Count;

            if (i == 0)
            {
                // 최상위 부서의 데이터 복사
                rDsTop = rDsKpi.Copy();
                rDsTop.Tables[0].Columns.Add("RowUseYN", typeof(string));
                rDsTop.Tables[0].Columns.Add("NewYN", typeof(string));

                ugrdMoonChartForPrint.Columns.FromKey(strViwName).Header.Fixed = true;
                ugrdMoonChartForPrint.Columns.FromKey(strStgID).Header.Fixed   = true;
                ugrdMoonChartForPrint.Columns.FromKey(strStgName).Header.Fixed = true;
                ugrdMoonChartForPrint.Columns.FromKey(strKpiName).Header.Fixed = true;
                ugrdMoonChartForPrint.Columns.FromKey(strUnit).Header.Fixed    = true;
                ugrdMoonChartForPrint.Columns.FromKey(strTarget).Header.Fixed  = true;
                ugrdMoonChartForPrint.Columns.FromKey(strResult).Header.Fixed  = true;
                ugrdMoonChartForPrint.Columns.FromKey(strWeight).Header.Fixed  = true;

                ch = new ColumnHeader(true);
                ch.Caption = strEstDeptNm;
                ch.RowLayoutColumnInfo.OriginY = 0;
                ch.RowLayoutColumnInfo.OriginX = 0;
                ch.RowLayoutColumnInfo.SpanX   = 8;
                ch.Style.Height                = Unit.Pixel(20);
                ugrdMoonChartForPrint.Bands[0].HeaderLayout.Add(ch);
                ugrdMoonChartForPrint.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                ch = null;

                ugrdMoonChartForPrint.Columns.FromKey(strViwName).MergeCells = true;
                ugrdMoonChartForPrint.Columns.FromKey(strStgID).MergeCells   = true;
                ugrdMoonChartForPrint.Columns.FromKey(strStgName).MergeCells = true;
                ugrdMoonChartForPrint.Columns.FromKey(strKpiName).MergeCells = true;
                
                for (int k = 0; k < cntKpi; k++)
                {
                    rDrKpi = rDsKpi.Tables[0].Rows[k];
                    ugrdMoonChartForPrint.Rows.Add();
                    ugrdMoonChartForPrint.Rows[k].Cells.FromKey(strViwName).Value = rDrKpi["VIEW_NAME"].ToString();
                    ugrdMoonChartForPrint.Rows[k].Cells.FromKey(strStgID).Value   = rDrKpi["STG_REF_ID"].ToString();
                    ugrdMoonChartForPrint.Rows[k].Cells.FromKey(strStgName).Value = rDrKpi["STG_NAME"].ToString();
                    ugrdMoonChartForPrint.Rows[k].Cells.FromKey(strKpiName).Value = rDrKpi["KPI_NAME"].ToString();
                    ugrdMoonChartForPrint.Rows[k].Cells.FromKey(strUnit).Value    = rDrKpi["UNIT"].ToString();
                    ugrdMoonChartForPrint.Rows[k].Cells.FromKey(strTarget).Value  = Convert.ToDouble(rDrKpi["TARGET"].ToString());
                    ugrdMoonChartForPrint.Rows[k].Cells.FromKey(strResult).Value  = Convert.ToDouble(rDrKpi["RESULT"].ToString());
                    ugrdMoonChartForPrint.Rows[k].Cells.FromKey(strWeight).Value  = Convert.ToDouble(rDrKpi["WEIGHT"].ToString());
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
                ugrdMoonChartForPrint.Bands[0].HeaderLayout.Add(ch);
                ugrdMoonChartForPrint.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
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
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strViwName).Value = rDrKpi["VIEW_NAME"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strStgID).Value   = rDrKpi["STG_REF_ID"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strStgName).Value = rDrKpi["STG_NAME"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strKpiName).Value = rDrKpi["KPI_NAME"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strUnit).Value    = rDrKpi["UNIT"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strTarget).Value  = Convert.ToDouble(rDrKpi["TARGET"].ToString());
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strResult).Value  = Convert.ToDouble(rDrKpi["RESULT"].ToString());
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strWeight).Value  = Convert.ToDouble(rDrKpi["WEIGHT"].ToString());
                        }
                        // 상위지표는 존재 하나 프린트할 자리가 없는경우
                        // 행을 하나 늘이고 인쇄한다
                        else if (!blnPrintYN && blnHaveKpi) 
                        { 
                            UltraGridRow ugrNew = new UltraGridRow();
                            for (int m = 0; m < 8; m++)
                            {
                                ugrNew.Cells.Add(ugrdMoonChartForPrint.Rows[intIdx].Cells[m]);
                            }

                            ugrdMoonChartForPrint.Rows.Insert(intIdx+1, ugrNew);

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

                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strViwName).Value = rDrKpi["VIEW_NAME"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strStgID).Value   = rDrKpi["STG_REF_ID"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strStgName).Value = rDrKpi["STG_NAME"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strKpiName).Value = rDrKpi["KPI_NAME"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strUnit).Value    = rDrKpi["UNIT"].ToString();
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strTarget).Value  = Convert.ToDouble(rDrKpi["TARGET"].ToString());
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strResult).Value  = Convert.ToDouble(rDrKpi["RESULT"].ToString());
                            ugrdMoonChartForPrint.Rows[intIdx].Cells.FromKey(strWeight).Value  = Convert.ToDouble(rDrKpi["WEIGHT"].ToString());
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

        lblRowCount.Text = ugrdMoonChartForPrint.Rows.Count.ToString("#,##0");
    }

    public void SetPrintGrid()
    {
        if (ugrdMoonChartForPrint.Visible)
        {
            if (ugrdMoonChartForPrint.Columns.Count > 256)
            {
                ltrScript.Text = JSHelper.GetAlertScript("컬럼수가 엑셀시트의 컬럼수 보다 많습니다. 인쇄할수 없습니다.", false);
                return;
            }

            ugrdEEP.ExcelStartRow = 2;
            ugrdEEP.ExportMode    = ExportMode.Download;
            ugrdEEP.DownloadName  = "MoonChart";
            ugrdEEP.WorksheetName = "MoonChartPerEstimationDept";
            ugrdEEP.Export(ugrdMoonChartForPrint);
            return;
        }
        else if (ugrdMapKpi.Visible)
        {
            ugrdEEP.ExcelStartRow = 2;
            ugrdEEP.ExportMode    = ExportMode.Download;
            ugrdEEP.DownloadName  = "KpiList";
            ugrdEEP.WorksheetName = "KpiListPerEstimationDept";
            ugrdMapKpi.Bands[0].ColFootersVisible = ShowMarginInfo.No;
            ugrdEEP.Export(ugrdMapKpi);
            ugrdMapKpi.Bands[0].ColFootersVisible = ShowMarginInfo.Yes;
            return;
        }
        else
        {
            return;
        }
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
            e.Layout.StationaryMargins = StationaryMargins.HeaderAndFooter;
            e.Layout.CellClickActionDefault = CellClickAction.RowSelect;
            e.Layout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor = Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor = Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.FooterStyleDefault.VerticalAlign = VerticalAlign.Middle;

            int iCol = e.Layout.Bands[0].Columns.Count - 1;
            int iMrg = iCol;  // Start Colspan Length
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
                    e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX = iMrg;
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
        //try
        //{
        //    e.Layout.StationaryMargins                  = StationaryMargins.HeaderAndFooter;
        //    e.Layout.CellClickActionDefault             = CellClickAction.RowSelect;
        //    e.Layout.ColFootersVisibleDefault           = ShowMarginInfo.Yes;
        //    e.Layout.FooterStyleDefault.Height          = Unit.Pixel(25);
        //    e.Layout.FooterStyleDefault.BackColor       = Color.WhiteSmoke;
        //    e.Layout.FooterStyleDefault.ForeColor       = Color.Navy;
        //    e.Layout.FooterStyleDefault.Margin.Right    = Unit.Pixel(10);
        //    e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
        //    e.Layout.FooterStyleDefault.VerticalAlign   = VerticalAlign.Middle;

        //    int iCol  = e.Layout.Bands[0].Columns.Count - 1;
        //    int iMrg  = iCol;  // Start Colspan Length
        //    int iFRow = 0;     // Start Colspan Index
        //    for (int i = 0; i < iCol; i++)
        //    {
        //        iFRow += 1;
        //        if (e.Layout.Bands[0].Columns[i].Hidden)
        //        {
        //            iMrg -= 1;
        //        }
        //        else
        //        {
        //            e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX     = iMrg;
        //            break;
        //        }
        //    }

        //    if (iFRow > 0)
        //    {
        //        string sLegend = Biz_Type.app_legend;

        //        e.Layout.Bands[0].Columns[iFRow - 1].Footer.Caption = sLegend;
        //        e.Layout.Bands[0].Columns[iFRow - 1].Footer.Style.Width = Unit.Percentage(100);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript(ex.Message);
        //}
    }
    #endregion

    #region 서버 이벤트 처리 함수
    protected void ugrdMapKpi_InitializeLayout(object sender, LayoutEventArgs e)
    {
        this.SetDraftLegend(sender, e);
    }

    protected void ugrdMapKpi_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        e.Row.Height = Unit.Pixel(20);
        DataRowView drw = (DataRowView)e.Data;

        //if (drw["APPROVAL_STATUS"].ToString() == "0")
        //{
        //    e.Row.Cells.FromKey("CONFIRMSTATUS").Value = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        //}
        //else
        //{
        //    e.Row.Cells.FromKey("CONFIRMSTATUS").Value = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        //}

        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);


        string kpi_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_REF_ID").Value);
        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        string url = "<a href='#null' onclick='doPoppingUp_KPI(\"{0}\",\"{1}\")' style=\"color:Navy;\">{2}</a>";
        string temp = string.Format(url, IEstTermRefID, kpi_ref_id, kpi_name);

        e.Row.Cells.FromKey("KPI_NAME").Value = temp;
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.setKpiData();
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        this.GetCountConfirmCancel("CONFIRM");
    }

    protected void iBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.GetCountConfirmCancel("CANCEL");
    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.SetPrintGrid();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetEstDeptDropDownList(ddlEstDept, intEstTermId, true, EMP_REF_ID);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        this.setKpiData();
    }

    protected void ugrdMoonChartForPrint_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.FixedColumnScrollType = FixedColumnScrollType.Pixel;
    }

    protected void iBtnMoonChart_Click(object sender, ImageClickEventArgs e)
    {
        this.SetPrintMoonChartGrid();
    }
    #endregion
}
