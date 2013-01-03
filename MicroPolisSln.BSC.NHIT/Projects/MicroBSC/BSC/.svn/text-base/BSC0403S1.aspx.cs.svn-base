using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Common;
using MicroBSC.Biz;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Biz;
using MicroBSC.RolesBasedAthentication;

public partial class BSC_BSC0403S1 : AppPageBase
{
    //----------------------
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.hdfDeptID.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.txtDeptName.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    // Control for Call Back
    public string ICCB3
    {
        get
        {
            if (ViewState["CCB3"] == null)
            {
                ViewState["CCB3"] = GetRequest("CCB3", this.lBtnReload.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB3"];
        }
        set
        {
            ViewState["CCB3"] = value;
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

    public int IEstDeptID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }
            hdfDeptID.Value = ViewState["EST_DEPT_REF_ID"].ToString();
            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public int ISelDeptID
    {
        get
        {
            if (ViewState["SEL_DEPT_REF_ID"] == null)
            {
                ViewState["SEL_DEPT_REF_ID"] = GetRequestByInt("SEL_DEPT_REF_ID", 0);
            }
            return (int)ViewState["SEL_DEPT_REF_ID"];
        }
        set
        {
            ViewState["SEL_DEPT_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public int IDeptType
    {
        get
        {
            if (ViewState["DEPT_TYPE_ID"] == null)
            {
                ViewState["DEPT_TYPE_ID"] = GetRequestByInt("DEPT_TYPE_ID", 0);
            }

            return (int)ViewState["DEPT_TYPE_ID"];
        }
        set
        {
            ViewState["DEPT_TYPE_ID"] = value;
        }
    }

    public string ISumType
    {
        get
        {
            if (ViewState["SUM_TYPE"] == null)
            {
                ViewState["SUM_TYPE"] = GetRequest("SUM_TYPE", "");
            }

            return (string)ViewState["SUM_TYPE"];
        }
        set
        {
            ViewState["SUM_TYPE"] = value;
        }
    }

    public bool IExtKpiYN
    {
        get
        {
            if (ViewState["EXT_KPI_YN"] == null)
            {
                ViewState["EXT_KPI_YN"] = (GetRequest("EXT_KPI_YN", "N") == "Y") ? true : false;
            }

            return (bool)ViewState["EXT_KPI_YN"];
        }
        set
        {
            ViewState["EXT_KPI_YN"] = value;
        }
    }

    private int cntRow = 0;
    private int cntAll = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            WebCommon.SetDeptTypeDropDownList(ddlComTypeInfo, false);
            WebCommon.SetSumTypeDropDownList(ddlSumType, false);
            WebCommon.SetScoreCardLevelDropDownList(ddlMapLevel, false);

            if (this.IYmd != "")
            {
                PageUtility.FindByValueDropDownList(ddlMonthInfo, this.IYmd);
            }

            this.ISelDeptID = this.IEstDeptID;

            this.SetKpiSignalMaster();

            this.TopEstDeptInfo();

            SetParameter();


            if (this.IType == "POP")
            {
                Biz_EstDeptInfos objDept = new Biz_EstDeptInfos(this.IEstTermRefID, this.IEstDeptID);
                this.IDeptType = objDept.Dept_Type;

                base.SetMenuControl(false, false, false);
                this.plnWhere.Visible     = false;
                this.plnScoreGrid.Visible = false;
                this.tdplnScoreGrid.Visible = false;
                ddlMapLevel.SelectedValue = "VP";
                hdfDeptID.Value           = this.IEstDeptID.ToString();
                this.SetScoreRank();
                this.SetDeptScoreCard();
                //lblRank.Text    = "-";
                //lblRankAll.Text = "-";
                //lblGrade.Text   = "-";
            }
            else
            {
                this.SetScoreRank();
            }

            WebCommon.SetExternalScoreCheckBox(chkApplyExtScore, this.IEstTermRefID);
            chkApplyExtScore.Checked = this.IExtKpiYN;
        }
       
    }

    #region 내부함수
    public void SetParameter()
    {
        if (this.IType != "POP")
        {
            this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);
            this.IDeptType     = PageUtility.GetIntByValueDropDownList(ddlComTypeInfo);
            this.ISumType      = PageUtility.GetByValueDropDownList(ddlSumType);
            this.IExtKpiYN     = chkApplyExtScore.Checked;
        }
    }

    public void SetScoreRank()
    {
        this.SetParameter();
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        DataSet iDs = new DataSet();

        if (this.IExtKpiYN)
        {

            iDs = objBSC.GetEstDeptRank
                 (this.IEstTermRefID
                 , this.IYmd
                 , this.IDeptType
                 , this.ISumType
                 , (hdfDeptID.Value == "") ? 0 : int.Parse(hdfDeptID.Value.ToString())
                 , (this.chkInSubDept.Checked) ? "Y" : "N"
                 , this.chkApplyExtScore.Checked
                 , gUserInfo.Emp_Ref_ID
                 , this.IExtKpiYN
                 );
        }
        else
        {
            iDs = objBSC.GetEstDeptRank
                 (this.IEstTermRefID
                 , this.IYmd
                 , this.IDeptType
                 , this.ISumType
                 , (hdfDeptID.Value == "") ? 0 : int.Parse(hdfDeptID.Value.ToString())
                 , (this.chkInSubDept.Checked) ? "Y" : "N"
                 , this.chkApplyExtScore.Checked
                 , gUserInfo.Emp_Ref_ID
                 );
        }

        ugrdScore.Clear();
        ugrdScore.DataSource = iDs.Tables[0].DefaultView;
        ugrdScore.DataBind();

        //2012.05.04 박효동 : 권기풍차 요청(부경양돈)으로 전사내 동위레벨의 순위 표출)
        if (this.IType == "POP")
        {
            
            //DataSet dsPOP = objBSC.GetEstDeptRankPOP(this.IEstTermRefID, this.IYmd, this.IDeptType);

            MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Weight bizBscKpiWeight = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Weight();
            DataTable dtPop1 = bizBscKpiWeight.GetBscKpiWeight_DB(this.IEstTermRefID, this.IYmd, this.IDeptType);

            MicroBSC.Integration.BSC.Biz.Biz_Bsc_Est_Dept_Grade bizBscEstDeptGrade = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Est_Dept_Grade();
            DataTable dtPop2 = bizBscEstDeptGrade.GetBscEstDeptGrade_DB(this.IEstTermRefID, this.IDeptType);

            if (dtPop1.Rows.Count > 0)
            {
                DataRow[] drr = dtPop1.Select(string.Format("EST_DEPT_REF_ID = {0}", DataTypeUtility.GetToInt32(hdfDeptID.Value)));
                if (drr.Length > 0)
                {
                    double currScore = DataTypeUtility.GetToDouble(drr[0]["SCORE_" + this.ISumType]);
                    lblRank.Text = (dtPop1.Rows.Count - dtPop1.Select(string.Format("SCORE_{0} < {1}", this.ISumType, currScore)).Length).ToString();
                    lblRankAll.Text = dtPop1.Rows.Count.ToString();

                    if (dtPop2.Rows.Count > 0)
                    {
                        DataRow[] drrSub = dtPop2.Select(string.Format("MIN_VALUE <= {0} AND MAX_VALUE >= {0}", currScore));
                        if (drrSub.Length > 0)
                            lblGrade.Text = drrSub[0]["GRADE_NAME"].ToString();
                    }
                }
            }
        }

        ugrdScoreRankPrint.Clear();
        ugrdScoreRankPrint.DataSource = iDs;
        ugrdScoreRankPrint.DataBind();

        cntRow = iDs.Tables[0].Rows.Count;

        if (cntRow < 1)
        {
            ugrdScoreCard.Clear();
            this.IEstDeptID       = 0;
            lblDeptName.Text      = " ";
            lblDeptVision.Text    = " ";
            lblBSCChampion.Text   = " ";
            lblRank.Text          = " ";
            lblTotalScore.Text    = " ";
            lblGrade.Text         = " ";
            lblRankAll.Text       = " ";
            iBtnPrintRank.Visible = false;
        }
        else
        { 
            iBtnPrintRank.Visible = true;
        }
    }

    public void SetDeptScoreCard()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        DataSet iDs = objBSC.GetEstDeptTotalScore( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.ISelDeptID
                                                 , this.IExtKpiYN);

        DataSet dsViw = objBSC.GetEstDeptKpiViewTypeList
                                                 ( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.ISelDeptID
                                                 , this.IExtKpiYN);

        DataSet dsKpi = objBSC.GetEstDeptKpiScoreList
                                                 ( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.ISelDeptID
                                                 , this.IExtKpiYN);

        DataSet dsTot = objBSC.GetEstDeptTotalScore
                                                 ( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.ISelDeptID
                                                 , this.IExtKpiYN);

        DataSet dsTree = new DataSet();
        if (ddlMapLevel.SelectedValue == "SP")
        {
            DataSet dsStg = objBSC.GetScorePerStrategy
                                                 ( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.ISelDeptID
                                                 , this.IExtKpiYN);

            DataTable dtStg = dsStg.Tables[0].Copy();
            DataTable dtKpi = dsKpi.Tables[0].Copy();

            dsTree = dsViw.Copy();
            dsTree.Tables.Add(dtStg);
            dsTree.Tables.Add(dtKpi);


            dsTree.Relations.Add("SCORE_CARD_STG", dsTree.Tables[0].Columns["VIEW_REF_ID"], dsTree.Tables[1].Columns["VIEW_REF_ID"]);
            dsTree.Relations.Add("SCORE_CARD_KPI", dsTree.Tables[1].Columns["STG_REF_ID"], dsTree.Tables[2].Columns["STG_REF_ID"]);
        }
        else
        {
            DataTable dtKpi = dsKpi.Tables[0].Copy();

            dsTree = dsViw.Copy();
            dsTree.Tables.Add(dtKpi);

            dsTree.Relations.Add("SCORE_CARD_KPI", dsTree.Tables[0].Columns["VIEW_REF_ID"], dsTree.Tables[1].Columns["VIEW_REF_ID"]);
        }

        ugrdScoreCard.Clear();
        ugrdScoreCard.DataSource = dsTree.Tables[0].DefaultView;
        ugrdScoreCard.DataBind();

        lblTotalScore.Style.Add("align", "right");
        lblTotalScore.Text = (dsTot.Tables[0].Rows.Count > 0) ? double.Parse(dsTot.Tables[0].Rows[0]["POINT"].ToString()).ToString("#,##0.00") : "0";

        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objMap = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info(this.IEstTermRefID
                                                                                       , this.ISelDeptID
                                                                                       , this.IYmd);
        lblDeptName.Text    = objMap.Iest_dept_name;
        lblDeptVision.Text  = objMap.Idept_vision;
        lblBSCChampion.Text = objMap.Ibscchampion_name;
    }

    private void BindComTypeInfo()
    {
        int sDEPT_REF_ID = (hdfDeptID.Value=="") ? 0 : int.Parse(hdfDeptID.Value);

        MicroBSC.Biz.Common.Biz.Biz_DeptTypeInfo biz = new MicroBSC.Biz.Common.Biz.Biz_DeptTypeInfo();
        DataSet ds = biz.GetDeptTypeSortList(IEstTermRefID, sDEPT_REF_ID);

        ddlComTypeInfo.Items.Clear();

        this.hdfDept_Type_Flag.Value = ds.Tables[0].Rows.Count.ToString();

        ddlComTypeInfo.DataSource = ds;

        ddlComTypeInfo.DataTextField  = "TYPE_NAME";
        ddlComTypeInfo.DataValueField = "TYPE_REF_ID";

        ddlComTypeInfo.DataBind();

    }

    private void PrintFormGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        DataSet dsKpi = objBSC.GetEstDeptKpiScoreList
                                                 ( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IEstDeptID
                                                 , this.IExtKpiYN);

        ugrdScoreCardPrint.Clear();
        ugrdScoreCardPrint.DataSource = dsKpi;
        ugrdScoreCardPrint.DataBind();

        string strCurDate     = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');
        ugrdEEP.ExcelStartRow = 10;
        ugrdEEP.ExportMode    = ExportMode.Download;
        ugrdEEP.DownloadName  = "ScoreCard"+strCurDate+".xls"; 
        ugrdEEP.WorksheetName = "ScoreCardFor"+lblDeptName.Text;
        ugrdEEP.Export(ugrdScoreCardPrint);
        ugrdScoreCardPrint.Clear();
    }

    private void PrintRankGrid()
    {
        string strCurDate          = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');
        ugrdEEP_Rank.ExcelStartRow = 5;
        ugrdEEP_Rank.ExportMode    = ExportMode.Download;
        ugrdEEP_Rank.DownloadName  = "RankList"+PageUtility.GetByValueDropDownList(ddlComTypeInfo)+".xls"; 
        ugrdEEP_Rank.WorksheetName = "RankList"+PageUtility.GetByTextDropDownList(ddlComTypeInfo);
        ugrdEEP_Rank.Export(ugrdScoreRankPrint);
        //ugrdScoreCardPrint.Clear();
    }

    private void TopEstDeptInfo()
    {
        this.SetParameter();

        MicroBSC.Estimation.Dac.DeptInfos objEst2 = new MicroBSC.Estimation.Dac.DeptInfos(this.IEstDeptID);
        this.txtDeptName.Text = objEst2.Dept_Name;

        BindComTypeInfo();

    }

    private void SetKpiSignalMaster()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Threshold_Code objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Threshold_Code();
        DataSet rDs = objBSC.GetThresholdCodeList("");

        grvSignal.DataSource = rDs.Tables[0].DefaultView;
        grvSignal.DataBind();
    }
    #endregion

    #region 이벤트


    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        BindComTypeInfo();
    }


    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetScoreRank();
    }

    protected void ugrdScoreCard_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int idxBand      = (ddlMapLevel.SelectedValue == "VP") ? 1 : 2;
        string widthView = (ddlMapLevel.SelectedValue == "VP") ? "500 px" : "544 px";
        //----------------------------------------------------------------------
        // 관점설정
        //----------------------------------------------------------------------
        ugrdScoreCard.Bands[0].Columns.FromKey("ESTTERM_REF_ID").Hidden  = true;
        ugrdScoreCard.Bands[0].Columns.FromKey("YMD").Hidden             = true;
        ugrdScoreCard.Bands[0].Columns.FromKey("VIEW_REF_ID").Hidden     = true;
        ugrdScoreCard.Bands[0].Columns.FromKey("EST_DEPT_REF_ID").Hidden = true;
        ugrdScoreCard.Bands[0].Columns.FromKey("ACHV_RATE").Hidden       = true;

        ugrdScoreCard.DisplayLayout.Bands[0].Columns.FromKey("VIEW_NAME").Header.Caption = "관점명";
        ugrdScoreCard.DisplayLayout.Bands[0].Columns.FromKey("POINT").Header.Caption     = "관점별 획득점수";
        ugrdScoreCard.DisplayLayout.Bands[0].Columns.FromKey("WEIGHT").Header.Caption    = "가중치";

        ugrdScoreCard.Bands[0].Columns.FromKey("VIEW_NAME").Width = new Unit(widthView);
        ugrdScoreCard.Bands[0].Columns.FromKey("POINT").Width     = new Unit("150 px");
        ugrdScoreCard.Bands[0].Columns.FromKey("WEIGHT").Width    = new Unit("100 px");
        ugrdScoreCard.DisplayLayout.Bands[0].Columns.FromKey("POINT").Format    = "#,##0.00";
        ugrdScoreCard.DisplayLayout.Bands[0].Columns.FromKey("WEIGHT").Format   = "#,##0.00";

        ugrdScoreCard.DisplayLayout.Bands[0].Columns.FromKey("POINT").CellStyle.HorizontalAlign  = HorizontalAlign.Right;
        ugrdScoreCard.DisplayLayout.Bands[0].Columns.FromKey("WEIGHT").CellStyle.HorizontalAlign = HorizontalAlign.Right;

        //----------------------------------------------------------------------
        // 관점별 전략 설정
        //----------------------------------------------------------------------
        if (ddlMapLevel.SelectedValue == "SP")
        {
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("ESTTERM_REF_ID").Hidden  = true;
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("YMD").Hidden             = true;
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("VIEW_REF_ID").Hidden     = true;
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("VIEW_NAME").Hidden       = true;
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("EST_DEPT_REF_ID").Hidden = true;
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("STG_REF_ID").Hidden      = true;
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("ACHV_RATE").Hidden       = true;

            ugrdScoreCard.DisplayLayout.Bands[idxBand-1].Columns.FromKey("STG_NAME").Header.Caption = "전략명";
            ugrdScoreCard.DisplayLayout.Bands[idxBand-1].Columns.FromKey("POINT").Header.Caption    = "전략별 획득점수";
            ugrdScoreCard.DisplayLayout.Bands[idxBand-1].Columns.FromKey("WEIGHT").Header.Caption   = "가중치";

            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("STG_NAME").Width = new Unit("500 px");
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("POINT").Width    = new Unit("150 px");
            ugrdScoreCard.Bands[idxBand-1].Columns.FromKey("WEIGHT").Width   = new Unit("100 px");
            ugrdScoreCard.DisplayLayout.Bands[idxBand-1].Columns.FromKey("POINT").Format  = "#,##0.00";
            ugrdScoreCard.DisplayLayout.Bands[idxBand-1].Columns.FromKey("WEIGHT").Format = "#,##0.00";
            ugrdScoreCard.DisplayLayout.Bands[idxBand-1].Columns.FromKey("POINT").CellStyle.HorizontalAlign  = HorizontalAlign.Right;
            ugrdScoreCard.DisplayLayout.Bands[idxBand-1].Columns.FromKey("WEIGHT").CellStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        //----------------------------------------------------------------------
        // 전략별 KPI 설정
        //----------------------------------------------------------------------
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("ESTTERM_REF_ID").Hidden  = true;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("EST_DEPT_REF_ID").Hidden = true;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("VIEW_REF_ID").Hidden     = true;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("VIEW_NAME").Hidden       = true;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("STG_REF_ID").Hidden      = true;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("STG_NAME").Hidden        = true;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("KPI_REF_ID").Hidden      = true;        
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("YMD").Hidden             = true;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("SIGNAL_NAME").Hidden     = true;

        ugrdScoreCard.Bands[idxBand].Columns.FromKey("SIGNAL").Hidden          = false;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("ORI_POINT").Hidden       = false;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("POINT").Hidden           = false;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("AC_POINT").Hidden        = false;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("WEIGHT").Hidden          = false;
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Hidden  = false;

        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("KPI_NAME").Header.Caption       = "KPI명";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("UNIT").Header.Caption           = "단위";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("TARGET").Header.Caption         = "목표";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("RESULT").Header.Caption         = "실적";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("SIGNAL").Header.Caption         = "신호";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("ORI_POINT").Header.Caption      = "획  득";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("POINT").Header.Caption          = "변환전";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("AC_POINT").Header.Caption       = "변환후";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("WEIGHT").Header.Caption         = "변환전";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Header.Caption = "변환후";

        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("KPI_NAME").Header.Style.HorizontalAlign       = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("UNIT").Header.Style.HorizontalAlign           = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("TARGET").Header.Style.HorizontalAlign         = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("RESULT").Header.Style.HorizontalAlign         = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("SIGNAL").Header.Style.HorizontalAlign         = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("ORI_POINT").Header.Style.HorizontalAlign      = HorizontalAlign.Center;        
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("POINT").Header.Style.HorizontalAlign          = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("AC_POINT").Header.Style.HorizontalAlign       = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("WEIGHT").Header.Style.HorizontalAlign         = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Header.Style.HorizontalAlign = HorizontalAlign.Center;

        ugrdScoreCard.Bands[idxBand].Columns.FromKey("KPI_NAME").Width       = new Unit("243 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("UNIT").Width           = new Unit("40 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("TARGET").Width         = new Unit("85 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("RESULT").Width         = new Unit("85 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("SIGNAL").Width         = new Unit("25 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("ORI_POINT").Width      = new Unit("50 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("POINT").Width          = new Unit("50 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("AC_POINT").Width       = new Unit("50 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("WEIGHT").Width         = new Unit("50 px");
        ugrdScoreCard.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Width = new Unit("50 px");

        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("TARGET").Format         = "#,##0.00";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("RESULT").Format         = "#,##0.00";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("ORI_POINT").Format      = "#,##0.00";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("POINT").Format          = "#,##0.00";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("AC_POINT").Format       = "#,##0.00";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("WEIGHT").Format         = "#,##0.00";
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Format = "#,##0.00";

        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("UNIT").CellStyle.HorizontalAlign           = HorizontalAlign.Center;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("TARGET").CellStyle.HorizontalAlign         = HorizontalAlign.Right;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("RESULT").CellStyle.HorizontalAlign         = HorizontalAlign.Right;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("ORI_POINT").CellStyle.HorizontalAlign      = HorizontalAlign.Right;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("POINT").CellStyle.HorizontalAlign          = HorizontalAlign.Right;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("AC_POINT").CellStyle.HorizontalAlign       = HorizontalAlign.Right;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("WEIGHT").CellStyle.HorizontalAlign         = HorizontalAlign.Right;
        ugrdScoreCard.DisplayLayout.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").CellStyle.HorizontalAlign = HorizontalAlign.Right;
    }
    protected void ugrdScoreCard_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        //string strURL = "<a href='../BSC/BSC0304S2.aspx?iType="+this.IType+"&ESTTERM_REF_ID={0}&KPI_REF_ID={1}&YMD={2}' style=\"color:Navy;\">{3}</a>";
        string strURL = "<a href=\"javascript:gfOpenWindow('../BSC/BSC0304S2.aspx?iType=POP&ESTTERM_REF_ID={0}&KPI_REF_ID={1}&YMD={2}',840,600,'no','no');\" style=\"color:Navy;\">{3}</a>";

        if (ddlMapLevel.SelectedValue == "SP")
        {
            if (e.Row.Band.Index == 1)
            {
                e.Row.Style.BackColor = System.Drawing.Color.White;
                e.Row.Style.ForeColor = System.Drawing.Color.Black;
                e.Row.Expand(false);
            }
            else if (e.Row.Band.Index == 2)
            {
                e.Row.Cells.FromKey("SIGNAL").Text = "<img alt='' src='../images/" + e.Row.Cells.FromKey("SIGNAL").Value.ToString() + "'";
                e.Row.Cells.FromKey("SIGNAL").Style.HorizontalAlign = HorizontalAlign.Center;
                e.Row.Style.BackColor = System.Drawing.Color.White;
                e.Row.Style.ForeColor = System.Drawing.Color.Black;

                e.Row.Cells.FromKey("KPI_NAME").Text = string.Format(strURL
                                                                     , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value
                                                                     , e.Row.Cells.FromKey("KPI_REF_ID").Value
                                                                     , e.Row.Cells.FromKey("YMD").Value
                                                                     , e.Row.Cells.FromKey("KPI_NAME").Value);

                if (e.Row.Cells.FromKey("POINT").Value != null)
                {
                    if (e.Row.Cells.FromKey("POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("POINT").Value = double.Parse(e.Row.Cells.FromKey("POINT").Value.ToString()).ToString("#,##0.00");
                    }

                    if (e.Row.Cells.FromKey("AC_POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("AC_POINT").Value = double.Parse(e.Row.Cells.FromKey("AC_POINT").Value.ToString()).ToString("#,##0.00");
                    }

                    if (e.Row.Cells.FromKey("ORI_POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("ORI_POINT").Value = double.Parse(e.Row.Cells.FromKey("ORI_POINT").Value.ToString()).ToString("#,##0.00");
                    }
                }

                e.Row.Expand(false);
            }
            else
            {
                e.Row.Style.ForeColor = System.Drawing.Color.DarkBlue;
                e.Row.Style.Font.Bold = true;
                e.Row.Height = Unit.Pixel(20);
                e.Row.Style.BackColor = System.Drawing.Color.WhiteSmoke;
                e.Row.Expand(false);
            }
        }
        else
        { 
            if (e.Row.Band.Index == 1)
            {
                e.Row.Cells.FromKey("SIGNAL").Text = "<img alt='' src='../images/" + e.Row.Cells.FromKey("SIGNAL").Value.ToString() + "'";
                e.Row.Cells.FromKey("SIGNAL").Style.HorizontalAlign = HorizontalAlign.Center;
                e.Row.Style.BackColor = System.Drawing.Color.White;
                e.Row.Style.ForeColor = System.Drawing.Color.Black;

                e.Row.Cells.FromKey("KPI_NAME").Text = string.Format(strURL
                                                                     , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value
                                                                     , e.Row.Cells.FromKey("KPI_REF_ID").Value
                                                                     , e.Row.Cells.FromKey("YMD").Value
                                                                     , e.Row.Cells.FromKey("KPI_NAME").Value);

                //if (e.Row.Cells.FromKey("POINT").Value.ToString() != "-")
                //{
                //    e.Row.Cells.FromKey("POINT").Value = Convert.ToDouble(e.Row.Cells.FromKey("POINT").Value.ToString()).ToString("#,##0.00");
                //}

                //Response.Write(drw["POINT"].ToString());

                try
                {
                    if (drw["POINT"].ToString().IndexOf('-') < 0 || !drw["POINT"].ToString().Trim().Equals(""))
                    {
                        e.Row.Cells.FromKey("POINT").Value = double.Parse(drw["POINT"].ToString()).ToString("#,##0.00");
                    }
                }
                catch { }

                try
                {
                    if (drw["AC_POINT"].ToString().IndexOf('-') < 0 || !drw["AC_POINT"].ToString().Trim().Equals(""))
                    {
                        e.Row.Cells.FromKey("AC_POINT").Value = double.Parse(drw["AC_POINT"].ToString()).ToString("#,##0.00");
                    }
                }
                catch { }

                try
                {
                    if (drw["ORI_POINT"].ToString().IndexOf('-') < 0 || !drw["ORI_POINT"].ToString().Trim().Equals(""))
                    {
                        e.Row.Cells.FromKey("ORI_POINT").Value = double.Parse(drw["ORI_POINT"].ToString()).ToString("#,##0.00");
                    }
                }
                catch { }
                
                e.Row.Expand(false);
            }
            else
            {
                e.Row.Style.ForeColor = System.Drawing.Color.DarkBlue;
                e.Row.Style.Font.Bold = true;
                e.Row.Height = Unit.Pixel(20);
                e.Row.Style.BackColor = System.Drawing.Color.WhiteSmoke;
                e.Row.Expand(false);
            }
        }
    }

    protected void ugrdScore_InitializeRow(object sender, RowEventArgs e)
    {
        cntAll += 1;
        string haveAccessRight = (e.Row.Cells.FromKey("ACCESS_YN").Value == null) ? "N": Convert.ToString(e.Row.Cells.FromKey("ACCESS_YN").Value);

        if (haveAccessRight == "Y")
        {
            cntRow += 1;
            if (cntRow == 1 && this.IType != "POP")
            {
                e.Row.Selected      = true;
                //this.IEstTermRefID  = (e.Row.Cells.FromKey("ESTTERM_REF_ID").Value == null)  ? 0  : int.Parse(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                //this.IYmd           = (e.Row.Cells.FromKey("YMD").Value == null)             ? "" : e.Row.Cells.FromKey("YMD").Value.ToString();
                //this.IDeptType      = (e.Row.Cells.FromKey("DEPT_TYPE").Value == null)       ? 0  : int.Parse(e.Row.Cells.FromKey("DEPT_TYPE").Value.ToString());
                //this.ISumType       = (e.Row.Cells.FromKey("SUM_TYPE").Value == null)        ? "" : e.Row.Cells.FromKey("SUM_TYPE").Value.ToString();
                this.ISelDeptID     = (e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value == null) ? 0  : int.Parse(e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
                lblRank.Text        = (e.Row.Cells.FromKey("RANK_ID").Value == null)         ? " ": e.Row.Cells.FromKey("RANK_ID").Value.ToString();
                lblGrade.Text       = (e.Row.Cells.FromKey("DEPT_GRADE").Value == null)      ? " ": e.Row.Cells.FromKey("DEPT_GRADE").Value.ToString();
                this.SetDeptScoreCard();
            }
        }
        else
        {
            e.Row.Hidden = true;
        }

        lblRankAll.Text = cntAll.ToString();
    }

    protected void ugrdScore_Click(object sender, ClickEventArgs e)
    {
        if (e.Row != null)
        {
            //this.IEstTermRefID  = (e.Row.Cells.FromKey("ESTTERM_REF_ID").Value == null)  ? 0  : int.Parse(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            //this.IYmd           = (e.Row.Cells.FromKey("YMD").Value == null)             ? "" : e.Row.Cells.FromKey("YMD").Value.ToString();
            //this.IDeptType      = (e.Row.Cells.FromKey("DEPT_TYPE").Value == null)       ? 0  : int.Parse(e.Row.Cells.FromKey("DEPT_TYPE").Value.ToString());
            //this.ISumType       = (e.Row.Cells.FromKey("SUM_TYPE").Value == null)        ? "" : e.Row.Cells.FromKey("SUM_TYPE").Value.ToString();
            this.ISelDeptID     = (e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value == null) ? 0  : int.Parse(e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
            lblRank.Text        = (e.Row.Cells.FromKey("RANK_ID").Value == null)         ? " ": e.Row.Cells.FromKey("RANK_ID").Value.ToString();
            lblGrade.Text       = (e.Row.Cells.FromKey("DEPT_GRADE").Value == null)      ? " ": e.Row.Cells.FromKey("DEPT_GRADE").Value.ToString();
            this.SetDeptScoreCard();
        }
        else
        {
            return;
        }
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermInfo.SelectedItem.Text ;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가년월 : " + ddlMonthInfo.SelectedItem.Text ;
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "평가조직 : " + lblDeptName.Text;
        e.CurrentWorksheet.Rows[3].Cells[0].Value = "평가점수 : " + lblTotalScore.Text;
        e.CurrentWorksheet.Rows[4].Cells[0].Value = "순    위 : " + lblRank.Text+"/"+lblRankAll.Text;
        e.CurrentWorksheet.Rows[5].Cells[0].Value = "등    급 : " + lblGrade.Text;
        e.CurrentWorksheet.Rows[6].Cells[0].Value = "조직비젼 : " + lblDeptVision.Text;
        e.CurrentWorksheet.Rows[7].Cells[0].Value = "BSC Champion : " + lblBSCChampion.Text;
        
        for (int i = 0; i < 8; i++)
        {
            e.CurrentWorksheet.Rows[i].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Navy;
            e.CurrentWorksheet.Rows[i].Cells[0].CellFormat.Font.Height = 250;
            e.CurrentWorksheet.Rows[i].Height = 400;
        }
    }

    protected void ugrdEEP_InitializeRow(object sender, ExcelExportInitializeRowEventArgs e)
    {
        // Add extra styling to particular rows in the document
        //if ((string)e.Row.Cells.FromKey("Country").Value == "UK")
        //{
        //    // highlight rows where the customer is from the UK
        //    e.Row.Style.BackColor = System.Drawing.Color.Pink;
        //}
    }

    protected void ugrdEEP_Rank_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermInfo.SelectedItem.Text ;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가년월 : " + ddlMonthInfo.SelectedItem.Text ;
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "조직유형 : " + PageUtility.GetByTextDropDownList(ddlComTypeInfo);
        e.CurrentWorksheet.Columns[0].Width = 200;
        e.CurrentWorksheet.Columns[1].Width = 600;
        e.CurrentWorksheet.Columns[2].Width = 300;
        e.CurrentWorksheet.Columns[3].Width = 200;
        
        for (int i = 0; i < 3; i++)
        {
            e.CurrentWorksheet.Rows[i].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Navy;
            e.CurrentWorksheet.Rows[i].Cells[0].CellFormat.Font.Height = 250;
            e.CurrentWorksheet.Rows[i].Height = 400;
        }
    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.PrintFormGrid();
    }

    protected void iBtnPrintRank_Click(object sender, ImageClickEventArgs e)
    {
        this.PrintRankGrid();
    }

    protected void ugrdScoreCardPrint_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells.FromKey("ORI_POINT").Value = (e.Row.Cells.FromKey("ORI_POINT").Value == null) ? 0 : Convert.ToDouble(e.Row.Cells.FromKey("ORI_POINT").Value.ToString().Replace('-','0'));
        e.Row.Cells.FromKey("POINT").Value     = (e.Row.Cells.FromKey("POINT").Value == null)     ? 0 : Convert.ToDouble(e.Row.Cells.FromKey("POINT").Value.ToString().Replace('-','0'));
        e.Row.Cells.FromKey("AC_POINT").Value  = (e.Row.Cells.FromKey("AC_POINT").Value == null)  ? 0 : Convert.ToDouble(e.Row.Cells.FromKey("AC_POINT").Value.ToString().Replace('-','0'));
    }

    protected void ugrdScoreCardPrint_InitializeLayout(object sender, LayoutEventArgs e)
    {
        if (PageUtility.GetByValueDropDownList(ddlMapLevel) == "SP")
        {
            e.Layout.Bands[0].Columns.FromKey("STG_NAME").Hidden = false;
        }
        else
        { 
            e.Layout.Bands[0].Columns.FromKey("STG_NAME").Hidden = true;
        }
    }

    protected void ugrdScoreRankPrint_InitializeRow(object sender, RowEventArgs e)
    {

        string haveAccessRight = (e.Row.Cells.FromKey("ACCESS_YN").Value == null) ? "N" : Convert.ToString(e.Row.Cells.FromKey("ACCESS_YN").Value);

        if (haveAccessRight == "N")
        {
            e.Row.Delete();
        }
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        this.txtDeptName.Text = "";
        this.hdfDeptID.Value  = "";
        ugrdScore.Clear();
        ugrdScoreCard.Clear();

        lblDeptName.Text    = "";
        lblDeptVision.Text  = "";
        lblBSCChampion.Text = "";
        lblRank.Text        = "-";
        lblRankAll.Text     = "-";
        lblTotalScore.Text  = "-";
        lblGrade.Text       = "";
        iBtnPrintRank.Visible = false;

        this.TopEstDeptInfo();
    }
    #endregion
}
