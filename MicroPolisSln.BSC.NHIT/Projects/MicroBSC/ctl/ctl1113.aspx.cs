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

using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Syncfusion.XlsIO;
using Syncfusion.Calculate;

public partial class ctl_ctl1113 : AppPageBase
{
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

    public string IYMD
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

    bool blnSw    = false;
    bool blnCL    = false;
    string NewKey = "";
    string OldKey = "";

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            this.initForm();
            this.setFormData();
            this.setGridClose();
            return;
        }
    }

    private void initForm()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();

        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYMD          = objTerm.GetReleasedMonth();

        imgBtnInterface.Attributes.Add("onclick", "ShowYahooScreen('Data Interface 처리중입니다.')");
        imgBtnClose.Attributes.Add("onclick", "ShowYahooScreen('마감 처리중입니다.')");
        imgBtnCalc.Attributes.Add("onclick", "ShowYahooScreen('계산 처리중입니다.')");
        imgBtnCancel.Attributes.Add("onclick", "ShowYahooScreen('마감취소 처리중입니다.')");
        imgBtnNormDist.Attributes.Add("onclick", "ShowYahooScreen('누적확률적용 및 등급산출을 처리하고 있습니다.')");

        imgBtnApplyExt.Attributes.Add("onclick", "ShowYahooScreen('외부평가점수를 적용하고 있습니다.')");
    }

    private void setGridClose()
    {

        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        DataSet dsClose = objBSC.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

        ugrdClose.Clear();
        ugrdClose.DataSource = dsClose;
        ugrdClose.DataBind();        
    }

    private void setFormData()
    {
        bool blnClose = false;

        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail(this.IEstTermRefID, this.IYMD);
        txtEstTermName.Text = objBSC.Iestterm_name;
        txtCloseMM.Text = objBSC.Iymd;
        txtIFYn.Text = (objBSC.Iinterface_yn == "Y") ? "I/F 처리완료" : "I/F처리미완료";
        txtIFDate.Text = objBSC.Iinterface_date;
        txtIFUser.Text = objBSC.IUpdate_user_name;
        txtIFDesc.Text = objBSC.Iinterface_desc;
        txtCloseYN.Text = (objBSC.Iclose_yn == "Y") ? "마감처리완료" : "마감처리미완료";
        txtCloseDate.Text = objBSC.Iclosing_date;
        txtCloseUser.Text = objBSC.IUpdate_user_name;
        txtEtc.Text = objBSC.Iclose_desc;
        blnClose = (objBSC.Iclose_yn == "Y") ? true : false;

        if (blnClose)
        {
            imgBtnClose.Visible = false;
            imgBtnCalc.Visible = false;
            imgBtnCancel.Visible = true;
            imgBtnNormDist.Visible = (objBSC.Inormdist_yn == "N") ? true : false;
            imgBtnApplyExt.Visible = (objBSC.Inormdist_yn == "Y" && objBSC.Iapply_ext_score_yn == "N") ? true : false;
            imgBtnInterface.Visible = false;
        }
        else
        {
            imgBtnInterface.Visible = true;
            imgBtnClose.Visible = true;
            imgBtnCalc.Visible = true;
            imgBtnCancel.Visible = false;
            imgBtnNormDist.Visible = false;

            imgBtnApplyExt.Visible = false;
        }

        imgBtnRelease.Visible = true;
        imgBtnPrint.Visible = true;

        if(true) // 공공에서만 쓴다고 농협할때 지움// 등급산출, 월별평가결과, 누적확률계산식
        {
            imgBtnNormDist.Visible = false;
            imgBtnPrint.Visible = false;
            ImgBtnPrintNorm.Visible = false;

            ugrdClose.Columns.FromKey("NORMDIST_YN").Hidden = true;
        }
    }

    private bool setCalc()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        if (objBSC.GetReleasedMonth() != this.IYMD)
            ltlMsg.Text = JSHelper.GetAlertScript("계산하려는 월은 배포되어있어야 합니다!!!", false);
        else
        {
            bool rtnValue = objBSC.CalcTermMonth(this.IEstTermRefID, this.IYMD, gUserInfo.Emp_Ref_ID);
            if (rtnValue)
                return true;
            else
            {
                ltlMsg.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message);
                return false;
            }
        }
        return false;
    }

    /// <summary>
    /// 원시점수 확정/취소
    /// </summary>
    /// <param name="iGubun"></param>
    private bool setClosing_Cancel(string iGubun)
    {
        int intRtn = 0;
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();

        if (iGubun == "CLOSE")
        {
            //Response.Write(String.Format("{0}||{1}||{2}||{3}", this.IEstTermRefID
            //                     , this.IYMD
            //                     , txtEtc.Text
            //                     , gUserInfo.Emp_Ref_ID));
            //Response.End();

            if (objBSC.GetReleasedMonth() != this.IYMD)
            {
                ltlMsg.Text = JSHelper.GetAlertScript("마감하려는 월은 배포되어있어야 합니다!!!", false);
                return false;
            }


            intRtn = objBSC.CloseTermMonth
                                 ( this.IEstTermRefID
                                 , this.IYMD
                                 , txtEtc.Text
                                 , gUserInfo.Emp_Ref_ID);

            string okMsg = objBSC.Transaction_Message;
            string okResult = objBSC.Transaction_Result;

            intRtn = objBSC.CloseTermMonthForWeight
                                 (this.IEstTermRefID
                                 , this.IYMD);

            // 골타겟 관련 입력 버튼 (농협에서 추가)
            if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
                intRtn = objBSC.CloseTermMonth_Goal
                                     (this.IEstTermRefID
                                     , this.IYMD
                                     , txtEtc.Text
                                     , gUserInfo.Emp_Ref_ID);


            ltlMsg.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
        }
        else
        {
            intRtn = objBSC.CancelTermMonth
                                 ( this.IEstTermRefID
                                 , this.IYMD
                                 , txtEtc.Text
                                 , gUserInfo.Emp_Ref_ID);

            // 골타겟 관련 입력 버튼 (농협에서 추가)
            if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
                intRtn = objBSC.CancelTermMonth_GOAL
                                     (this.IEstTermRefID
                                     , this.IYMD
                                     , txtEtc.Text
                                     , gUserInfo.Emp_Ref_ID);

            ltlMsg.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
        }

        if (intRtn > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 최종점수계산 / 최종점수 Rollup
    /// </summary>
    public void CalcFinalScore()
    {
        CalcQuick objCAL = new CalcQuick();
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        DataSet rDs = objBSC.GetOriginalScorePerKPI(this.IEstTermRefID, this.IYMD);

        int intRow = rDs.Tables[0].Rows.Count;
        int intCol = rDs.Tables[0].Columns.Count;
        int intRtn = 0;

        string strQrtMark = "\"";
        string sQM = "\"";

        int    intEsttermRefID = 0;
        int    intKpiRefID     = 0;
        string strYMD          = "";
        string strUseMS        = "";
        string strOriMS        = "";
        string strAvgMS        = "";
        string strStdMS        = "";
        string strAdaMS        = "";
        string strAdsMS        = "";
        string strNorMS        = "";
        string strFnlMS        = "";
        string strUseTS        = "";
        string strOriTS        = "";
        string strAvgTS        = "";
        string strStdTS        = "";
        string strAdaTS        = "";
        string strAdsTS        = "";
        string strNorTS        = "";
        string strFnlTS        = "";
        string strAplMS        = "";
        string strAplTS        = "";
        string strAplBS        = ""; // 바이어스 조정여부 확률여부

        string strColEsttermRefID = "";
        string strColKpiRefID     = "";
        string strColYMD          = "";
        string strColUseMS = "";
        string strColOriMS = "";
        string strColAvgMS = "";
        string strColStdMS = "";
        string strColAdaMS = "";
        string strColAdsMS = "";
        string strColNorMS = "";
        string strColFnlMS = "";
        string strColUseTS = "";
        string strColOriTS = "";
        string strColAvgTS = "";
        string strColStdTS = "";
        string strColAdaTS = "";
        string strColAdsTS = "";
        string strColNorTS = "";
        string strColFnlTS = "";
        string strColAplMS = "";
        string strColAplTS = "";
        string strColAplBS = "";
 
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Score_Detail objSCR = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Score_Detail();
        int itxr_user = gUserInfo.Emp_Ref_ID;

        DataRow dr;
        for (int i = 0; i < intRow; i++)
        {
            if (i == 0)
            {
                strColEsttermRefID = rDs.Tables[0].Columns[0].ColumnName;
                strColKpiRefID = rDs.Tables[0].Columns[1].ColumnName;
                strColYMD = rDs.Tables[0].Columns[2].ColumnName;
                strColUseMS = rDs.Tables[0].Columns[3].ColumnName;
                strColOriMS = rDs.Tables[0].Columns[4].ColumnName;
                strColAvgMS = rDs.Tables[0].Columns[5].ColumnName;
                strColStdMS = rDs.Tables[0].Columns[6].ColumnName;
                strColAdaMS = rDs.Tables[0].Columns[7].ColumnName;
                strColAdsMS = rDs.Tables[0].Columns[8].ColumnName;
                strColNorMS = rDs.Tables[0].Columns[9].ColumnName;
                strColFnlMS = rDs.Tables[0].Columns[10].ColumnName;
                strColUseTS = rDs.Tables[0].Columns[11].ColumnName;
                strColOriTS = rDs.Tables[0].Columns[12].ColumnName;
                strColAvgTS = rDs.Tables[0].Columns[13].ColumnName;
                strColStdTS = rDs.Tables[0].Columns[14].ColumnName;
                strColAdaTS = rDs.Tables[0].Columns[15].ColumnName;
                strColAdsTS = rDs.Tables[0].Columns[16].ColumnName;
                strColNorTS = rDs.Tables[0].Columns[17].ColumnName;
                strColFnlTS = rDs.Tables[0].Columns[18].ColumnName;
                strColAplMS = rDs.Tables[0].Columns[19].ColumnName;
                strColAplTS = rDs.Tables[0].Columns[20].ColumnName;
                strColAplBS = rDs.Tables[0].Columns[21].ColumnName;

                //// 누적확률을 처음 돌릴경우만 지우고 새로생성/ 외부지표 평가시 update
                intRtn = objSCR.DeleteDataAll(Convert.ToInt32(rDs.Tables[0].Rows[0]["ESTTERM_REF_ID"].ToString())
                                             , rDs.Tables[0].Rows[0]["YMD"].ToString()
                                             , itxr_user);
            }

                dr = rDs.Tables[0].Rows[i];
                intEsttermRefID = Convert.ToInt32(dr["ESTTERM_REF_ID"].ToString());
                intKpiRefID = Convert.ToInt32(dr["KPI_REF_ID"].ToString());
                strYMD = Convert.ToString(dr["YMD"].ToString());
                strUseMS = Convert.ToString(dr["NRMDST_USE_MS"].ToString());
                strOriMS = Convert.ToString(dr["POINTS_ORI_MS"].ToString());
                strAvgMS = Convert.ToString(dr["POINTS_AVG_MS"].ToString());
                strStdMS = Convert.ToString(dr["POINTS_STD_MS"].ToString());
                strAdaMS = Convert.ToString(dr["POINTS_ADA_MS"].ToString());
                strAdsMS = Convert.ToString(dr["POINTS_ADS_MS"].ToString());
                strNorMS = Convert.ToString(dr["POINTS_NOR_MS"].ToString());
                strFnlMS = Convert.ToString(dr["POINTS_FNL_MS"].ToString());
                strUseTS = Convert.ToString(dr["NRMDST_USE_TS"].ToString());
                strOriTS = Convert.ToString(dr["POINTS_ORI_TS"].ToString());
                strAvgTS = Convert.ToString(dr["POINTS_AVG_TS"].ToString());
                strStdTS = Convert.ToString(dr["POINTS_STD_TS"].ToString());
                strAdaTS = Convert.ToString(dr["POINTS_ADA_TS"].ToString());
                strAdsTS = Convert.ToString(dr["POINTS_ADS_TS"].ToString());
                strNorTS = Convert.ToString(dr["POINTS_NOR_TS"].ToString());
                strFnlTS = Convert.ToString(dr["POINTS_FNL_TS"].ToString());
                strAplMS = Convert.ToString(dr["POINTS_APL_MS"].ToString());
                strAplTS = Convert.ToString(dr["POINTS_APL_TS"].ToString());
                strAplBS = Convert.ToString(dr["BIAS_YN"].ToString());

                objCAL[strColEsttermRefID] = intEsttermRefID.ToString();
                objCAL[strColKpiRefID] = intKpiRefID.ToString();
                objCAL[strColYMD] = strYMD;
                objCAL[strColUseMS] = strUseMS;
                objCAL[strColOriMS] = strOriMS;
                objCAL[strColAvgMS] = strAvgMS;
                objCAL[strColStdMS] = strStdMS;
                objCAL[strColAdaMS] = strAdaMS;
                objCAL[strColAdsMS] = strAdsMS;
                objCAL[strColNorMS] = strNorMS;
                objCAL[strColFnlMS] = strFnlMS;
                objCAL[strColUseTS] = strUseTS;
                objCAL[strColOriTS] = strOriTS;
                objCAL[strColAvgTS] = strAvgTS;
                objCAL[strColStdTS] = strStdTS;
                objCAL[strColAdaTS] = strAdaTS;
                objCAL[strColAdsTS] = strAdsTS;
                objCAL[strColNorTS] = strNorTS;
                objCAL[strColFnlTS] = strFnlTS;
                objCAL[strColAplMS] = strAplMS;
                objCAL[strColAplTS] = strAplTS;
                objCAL[strColAplBS] = strAplBS;

                //objCAL[strColNorMS] = "=IF(["+strColStdMS+"]=0,0,ROUNDDOWN(NORMDIST(["+strColOriMS+"],["+strColAvgMS+"],["+strColStdMS+"],TRUE),8))";
                //objCAL[strColNorTS] = "=IF(["+strColStdTS+"]=0,0,ROUNDDOWN(NORMDIST(["+strColOriTS+"],["+strColAvgTS+"],["+strColStdTS+"],TRUE),8))";

                objCAL[strColNorMS] = "=IF([" + strColUseMS + "]=" + sQM + "Y" + sQM + ",IF([" + strColStdMS + "]=0,0,ROUNDDOWN(NORMDIST(IF([" + strColAplBS + "]=" + sQM + "Y" + sQM + ",[" + strColAdsMS + "],[" + strColOriMS + "]),[" + strColAvgMS + "],[" + strColStdMS + "],TRUE),8)),IF([" + strColAplBS + "]=" + sQM + "Y" + sQM + ",[" + strColAdsMS + "],[" + strColOriMS + "]))";
                objCAL[strColNorTS] = "=IF([" + strColUseTS + "]=" + sQM + "Y" + sQM + ",IF([" + strColStdTS + "]=0,0,ROUNDDOWN(NORMDIST(IF([" + strColAplBS + "]=" + sQM + "Y" + sQM + ",[" + strColAdsTS + "],[" + strColOriTS + "]),[" + strColAvgTS + "],[" + strColStdTS + "],TRUE),8)),IF([" + strColAplBS + "]=" + sQM + "Y" + sQM + ",[" + strColAdsTS + "],[" + strColOriTS + "]))";

                //objCAL[strColFnlMS] = "=IF(IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"],(85+(["+strColNorMS+"]-0.5)*30))<70,0, IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"],(85+(["+strColNorMS+"]-0.5)*30)))";
                //objCAL[strColFnlTS] = "=IF(IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"],(85+(["+strColNorTS+"]-0.5)*30))<70,0, IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"],(85+(["+strColNorTS+"]-0.5)*30)))";

                //objCAL[strColFnlMS] = "=IF(["+strColStdMS+"]=0, 85, IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"],(85+(["+strColNorMS+"]-0.5)*30)))";
                //objCAL[strColFnlTS] = "=IF(["+strColStdTS+"]=0, 85, IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"],(85+(["+strColNorTS+"]-0.5)*30)))";

                //objCAL[strColFnlMS] = "=IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"], IF(["+strColStdMS+"]=0, 85, (85+(["+strColNorMS+"]-0.5)*30)))";
                //objCAL[strColFnlTS] = "=IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"], IF(["+strColStdTS+"]=0, 85, (85+(["+strColNorTS+"]-0.5)*30)))";

                // 누적확률을 돌리지 않으면 원시점수 , 누적확률이 0 이면 기본점수 80 그렇지 않으면  (85+([누적확률]-0.5)*30)
                objCAL[strColFnlMS] = "=IF([" + strColUseMS + "]=" + sQM + "N" + sQM + ",[" + strColOriMS + "], IF([" + strColStdMS + "]=0, 85, (85+([" + strColNorMS + "]-0.5)*30)))";
                objCAL[strColFnlTS] = "=IF([" + strColUseTS + "]=" + sQM + "N" + sQM + ",[" + strColOriTS + "], IF([" + strColStdTS + "]=0, 85, (85+([" + strColNorTS + "]-0.5)*30)))";

                objCAL.SetDirty();

                strNorMS = objCAL[strColNorMS].ToString();
                strFnlMS = objCAL[strColFnlMS].ToString();
                strNorTS = objCAL[strColNorTS].ToString();
                strFnlTS = objCAL[strColFnlTS].ToString();

                strNorMS = PageUtility.IsAllNumber(strNorMS) ? strNorMS : "0";
                strFnlMS = PageUtility.IsAllNumber(strFnlMS) ? strFnlMS : "0";
                strNorTS = PageUtility.IsAllNumber(strNorTS) ? strNorTS : "0";
                strFnlTS = PageUtility.IsAllNumber(strFnlTS) ? strFnlTS : "0";

                intRtn = objSCR.UpdateData
                               (intEsttermRefID
                               , intKpiRefID
                               , strYMD
                               , strUseMS
                               , strOriMS
                               , strAvgMS
                               , strStdMS
                               , strAdaMS
                               , strAdsMS
                               , strNorMS
                               , strFnlMS
                               , strUseTS
                               , strOriTS
                               , strAvgTS
                               , strStdTS
                               , strAdaTS
                               , strAdsTS
                               , strNorTS
                               , strFnlTS
                               , itxr_user
                               );

            }

        // 최종점수 롤업
        intRtn = objBSC.SetNormdisScoreRollUp(this.IEstTermRefID, this.IYMD);

        intRtn = objBSC.ApplyNormDist(this.IEstTermRefID, this.IYMD, gUserInfo.Emp_Ref_ID);
    }

    /// <summary>
    /// 최종외부점수계산 / 최종점수 Rollup
    /// </summary>
    public void CalcFinalExternalScore()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Score_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Score_Detail();
        int iRtn = objBSC.UpdateExternalOriScore(this.IEstTermRefID, this.IYMD);

        CalcQuick objCAL = new CalcQuick();
        DataSet rDs = objBSC.GetExternalScorePerKPI(this.IEstTermRefID, this.IYMD);

        int intRow = rDs.Tables[0].Rows.Count;
        int intCol = rDs.Tables[0].Columns.Count;
        int intRtn = 0;

        string strQrtMark = "\"";
        string sQM = "\"";

        int    intEsttermRefID = 0;
        int    intKpiRefID     = 0;
        string strYMD          = "";
        string strUseTS        = "";
        string strOriTS        = "";
        string strAvgTS        = "";
        string strStdTS        = "";
        string strAdaTS        = "";
        string strAdsTS        = "";
        string strNorTS        = "";
        string strFnlTS        = "";

        string strColEsttermRefID = "";
        string strColKpiRefID     = "";
        string strColYMD          = "";
        string strColUseTS = "";
        string strColOriTS = "";
        string strColAvgTS = "";
        string strColStdTS = "";
        string strColAdaTS = "";
        string strColAdsTS = "";
        string strColNorTS = "";
        string strColFnlTS = "";
 
        int itxr_user = gUserInfo.Emp_Ref_ID;
        DataRow dr;
        for (int i = 0; i < intRow; i++)
        {
            if (i == 0)
            {
                strColEsttermRefID = rDs.Tables[0].Columns[0].ColumnName;
                strColKpiRefID     = rDs.Tables[0].Columns[1].ColumnName;
                strColYMD          = rDs.Tables[0].Columns[2].ColumnName;
                strColUseTS        = rDs.Tables[0].Columns[3].ColumnName;
                strColOriTS        = rDs.Tables[0].Columns[4].ColumnName;
                strColAvgTS        = rDs.Tables[0].Columns[5].ColumnName;
                strColStdTS        = rDs.Tables[0].Columns[6].ColumnName;
                strColAdaTS        = rDs.Tables[0].Columns[7].ColumnName;
                strColAdsTS        = rDs.Tables[0].Columns[8].ColumnName;
                strColNorTS        = rDs.Tables[0].Columns[9].ColumnName;
                strColFnlTS        = rDs.Tables[0].Columns[10].ColumnName;
            }

            dr = rDs.Tables[0].Rows[i];
            intEsttermRefID = Convert.ToInt32(dr["ESTTERM_REF_ID"].ToString());
            intKpiRefID     = Convert.ToInt32(dr["KPI_REF_ID"].ToString());
            strYMD          = Convert.ToString(dr["YMD"].ToString());
            strUseTS        = Convert.ToString(dr["NRMDST_USE_TS"].ToString());
            strOriTS        = Convert.ToString(dr["POINTS_ORI_TS"].ToString());
            strAvgTS        = Convert.ToString(dr["POINTS_AVG_TS"].ToString());
            strStdTS        = Convert.ToString(dr["POINTS_STD_TS"].ToString());
            strAdaTS        = Convert.ToString(dr["POINTS_ADA_TS"].ToString());
            strAdsTS        = Convert.ToString(dr["POINTS_ADS_TS"].ToString());
            strNorTS        = Convert.ToString(dr["POINTS_NOR_TS"].ToString());
            strFnlTS        = Convert.ToString(dr["POINTS_FNL_TS"].ToString());

            objCAL[strColEsttermRefID] = intEsttermRefID.ToString();
            objCAL[strColKpiRefID]     = intKpiRefID.ToString();
            objCAL[strColYMD]          = strYMD     ;
            objCAL[strColUseTS]        = strUseTS   ;
            objCAL[strColOriTS]        = strOriTS   ;
            objCAL[strColAvgTS]        = strAvgTS   ;
            objCAL[strColStdTS]        = strStdTS   ;
            objCAL[strColAdaTS]        = strAdaTS   ;
            objCAL[strColAdsTS]        = strAdsTS   ;
            objCAL[strColNorTS]        = strNorTS   ;
            objCAL[strColFnlTS]        = strFnlTS   ;

            //objCAL[strColNorMS] = "=IF(["+strColStdMS+"]=0,0,ROUNDDOWN(NORMDIST(["+strColOriMS+"],["+strColAvgMS+"],["+strColStdMS+"],TRUE),8))";
            objCAL[strColNorTS] = "=ROUNDDOWN(NORMDIST(["+strColOriTS+"],["+strColAvgTS+"],["+strColStdTS+"],TRUE),8)";

            //objCAL[strColNorMS] = "=IF([" + strColUseMS + "]=" + sQM + "Y" + sQM + ",IF([" + strColStdMS + "]=0,0,ROUNDDOWN(NORMDIST(IF([" + strColAplBS + "]=" + sQM + "Y" + sQM + ",[" + strColAdsMS + "],[" + strColOriMS + "]),[" + strColAvgMS + "],[" + strColStdMS + "],TRUE),8)),IF([" + strColAplBS + "]=" + sQM + "Y" + sQM + ",[" + strColAdsMS + "],[" + strColOriMS + "]))";
            //objCAL[strColNorTS] = "=IF([" + strColUseTS + "]=" + sQM + "Y" + sQM + ",IF([" + strColStdTS + "]=0,0,ROUNDDOWN(NORMDIST(IF([" + strColAplBS + "]=" + sQM + "Y" + sQM + ",[" + strColAdsTS + "],[" + strColOriTS + "]),[" + strColAvgTS + "],[" + strColStdTS + "],TRUE),8)),IF([" + strColAplBS + "]=" + sQM + "Y" + sQM + ",[" + strColAdsTS + "],[" + strColOriTS + "]))";

            //objCAL[strColFnlMS] = "=IF(IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"],(85+(["+strColNorMS+"]-0.5)*30))<70,0, IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"],(85+(["+strColNorMS+"]-0.5)*30)))";
            //objCAL[strColFnlTS] = "=IF(IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"],(85+(["+strColNorTS+"]-0.5)*30))<70,0, IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"],(85+(["+strColNorTS+"]-0.5)*30)))";

            //objCAL[strColFnlMS] = "=IF(["+strColStdMS+"]=0, 85, IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"],(85+(["+strColNorMS+"]-0.5)*30)))";
            //objCAL[strColFnlTS] = "=IF(["+strColStdTS+"]=0, 85, IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"],(85+(["+strColNorTS+"]-0.5)*30)))";

            //objCAL[strColFnlMS] = "=IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"], IF(["+strColStdMS+"]=0, 85, (85+(["+strColNorMS+"]-0.5)*30)))";
            //objCAL[strColFnlTS] = "=IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"], IF(["+strColStdTS+"]=0, 85, (85+(["+strColNorTS+"]-0.5)*30)))";

            // 누적확률을 돌리지 않으면 원시점수 , 누적확률이 0 이면 기본점수 80 그렇지 않으면  (85+([누적확률]-0.5)*30)
            objCAL[strColFnlTS] = "=IF([" + strColUseTS + "]=" + sQM + "N" + sQM + ",[" + strColOriTS + "], IF([" + strColStdTS + "]=0, 85, (85+([" + strColNorTS + "]-0.5)*30)))";

            objCAL.SetDirty();

            strNorTS = objCAL[strColNorTS].ToString();
            strFnlTS = objCAL[strColFnlTS].ToString();

            strNorTS = PageUtility.IsAllNumber(strNorTS) ? strNorTS : "0";
            strFnlTS = PageUtility.IsAllNumber(strFnlTS) ? strFnlTS : "0";

            intRtn = objBSC.UpdateExternalScore
                           ( intEsttermRefID
                           , intKpiRefID    
                           , strYMD         
                           , strUseTS
                           , strOriTS       
                           , strAvgTS       
                           , strStdTS       
                           , strAdaTS       
                           , strAdsTS       
                           , strNorTS       
                           , strFnlTS
                           , itxr_user
                           ); 

        }

        // 최종점수 롤업
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTrm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        intRtn = objTrm.SetNormdisScoreRollUp(this.IEstTermRefID, this.IYMD);
    }

    /// <summary>
    /// 누적확률 분포적용 엑셀 다운로드
    /// </summary>
    public void SetNormDistExcelDown()
    {

        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        DataSet rDs = objBSC.GetOriginalScorePerKPI(this.IEstTermRefID, this.IYMD);

        int intRow = rDs.Tables[0].Rows.Count;
        int intCol = rDs.Tables[0].Columns.Count;

        if (intRow < 1)
        {
            return;
        }

        ExcelEngine xlsEgn = new ExcelEngine();  //Step 2 : Instantiate the excel xlsApp object.
        IApplication xlsApp = xlsEgn.Excel;
        
        //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
        //The new workbook will have 3 worksheets
        IWorkbook workbook = xlsEgn.Excel.Workbooks.Create(3);
        
        //The first worksheet object in the worksheets collection is accessed.
        IWorksheet xlsSht = workbook.Worksheets[0];

        string strQrtMark = "\"";
        string strColName = "";

        string strColEsttermRefID = "";
        string strColKpiRefID     = "";
        string strColYMD          = "";
        string strColUseMS = "";
        string strColOriMS = "";
        string strColAvgMS = "";
        string strColStdMS = "";
        string strColAdaMS = "";
        string strColAdsMS = "";
        string strColNorMS = "";
        string strColFnlMS = "";
        string strColUseTS = "";
        string strColOriTS = "";
        string strColAvgTS = "";
        string strColStdTS = "";
        string strColAdaTS = "";
        string strColAdsTS = "";
        string strColNorTS = "";
        string strColFnlTS = "";

        int itxr_user = gUserInfo.Emp_Ref_ID;
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Score_Detail objSCR = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Score_Detail();
        
        for (int i = 0; i < intCol; i++)
        {
            strColName = WebCommon.GetExcelColumnName(i) + Convert.ToString(1);
            xlsSht.Range[strColName].Text = rDs.Tables[0].Columns[i].ColumnName;
            xlsSht.Range[strColName].ColumnWidth = 10;
        }

        for (int i = 0; i < intRow; i++)
        {
            for (int j=0; j < intCol; j++)
            {
                strColName = WebCommon.GetExcelColumnName(j) + Convert.ToString(i+2);

                switch (rDs.Tables[0].Columns[j].DataType.Name)
                { 
                    case ("Decimal"):
                        xlsSht.Range[strColName].Number = Convert.ToDouble(rDs.Tables[0].Rows[i][j].ToString());
                        break;
                    case ("Double"):
                        xlsSht.Range[strColName].Number = Convert.ToDouble(rDs.Tables[0].Rows[i][j].ToString());
                        break;
                    case ("Int16"):
                        xlsSht.Range[strColName].Number = Convert.ToInt16(rDs.Tables[0].Rows[i][j].ToString());
                        break;
                    case ("Int32"):
                        xlsSht.Range[strColName].Number = Convert.ToInt32(rDs.Tables[0].Rows[i][j].ToString());
                        break;
                    case ("Int64"):
                        xlsSht.Range[strColName].Number = Convert.ToInt64(rDs.Tables[0].Rows[i][j].ToString());
                        break;
                    default:
                        xlsSht.Range[strColName].Text = rDs.Tables[0].Rows[i][j].ToString();
                        break;
                }

                if (j == (intCol-1))
                {
                    strColEsttermRefID = WebCommon.GetExcelColumnName(0)  + Convert.ToString(i+2);
                    strColKpiRefID     = WebCommon.GetExcelColumnName(1)  + Convert.ToString(i+2);
                    strColYMD          = WebCommon.GetExcelColumnName(2)  + Convert.ToString(i+2);
                    strColUseMS        = WebCommon.GetExcelColumnName(3)  + Convert.ToString(i+2);
                    strColOriMS        = WebCommon.GetExcelColumnName(4)  + Convert.ToString(i+2);
                    strColAvgMS        = WebCommon.GetExcelColumnName(5)  + Convert.ToString(i+2);
                    strColStdMS        = WebCommon.GetExcelColumnName(6)  + Convert.ToString(i+2);
                    strColAdaMS        = WebCommon.GetExcelColumnName(7)  + Convert.ToString(i+2);
                    strColAdsMS        = WebCommon.GetExcelColumnName(8)  + Convert.ToString(i+2);
                    strColNorMS        = WebCommon.GetExcelColumnName(9)  + Convert.ToString(i+2);
                    strColFnlMS        = WebCommon.GetExcelColumnName(10) + Convert.ToString(i+2);
                    strColUseTS        = WebCommon.GetExcelColumnName(11) + Convert.ToString(i+2);
                    strColOriTS        = WebCommon.GetExcelColumnName(12) + Convert.ToString(i+2);
                    strColAvgTS        = WebCommon.GetExcelColumnName(13) + Convert.ToString(i+2);
                    strColStdTS        = WebCommon.GetExcelColumnName(14) + Convert.ToString(i+2);
                    strColAdaTS        = WebCommon.GetExcelColumnName(15) + Convert.ToString(i+2);
                    strColAdsTS        = WebCommon.GetExcelColumnName(16) + Convert.ToString(i+2);
                    strColNorTS        = WebCommon.GetExcelColumnName(17) + Convert.ToString(i+2);
                    strColFnlTS        = WebCommon.GetExcelColumnName(18) + Convert.ToString(i+2);

                    //=IF(IF(D739="N",E739,(85+(J739-0.5)*30))<70,0, IF(D739="N",E739,(85+(J739-0.5)*30))) --최초계산식
                    //=IF(E11<1,0, IF(D11="N",E11,(85+(J11-0.5)*30)))
                    //=IF(D739="N",E739, IF(G11=0, 85, (85+(J739-0.5)*30)))

                    xlsSht.Range[strColNorMS].Formula = "=IF("+strColStdMS+"=0,0,ROUNDDOWN(NORMDIST("+strColOriMS+","+strColAvgMS+","+strColStdMS+",TRUE),8))";
                    xlsSht.Range[strColNorTS].Formula = "=IF("+strColStdTS+"=0,0,ROUNDDOWN(NORMDIST("+strColOriTS+","+strColAvgTS+","+strColStdTS+",TRUE),8))";

                    //xlsSht.Range[strColFnlMS].Formula = "=IF(IF("+strColUseMS+"="+strQrtMark+"N"+strQrtMark+","+strColOriMS+",(85+("+strColNorMS+"-0.5)*30))<70,0, IF("+strColUseMS+"="+strQrtMark+"N"+strQrtMark+","+strColOriMS+",(85+("+strColNorMS+"-0.5)*30)))";
                    //xlsSht.Range[strColFnlTS].Formula = "=IF(IF("+strColUseMS+"="+strQrtMark+"N"+strQrtMark+","+strColOriTS+",(85+("+strColNorTS+"-0.5)*30))<70,0, IF("+strColUseTS+"="+strQrtMark+"N"+strQrtMark+","+strColOriTS+",(85+("+strColNorTS+"-0.5)*30)))";

                    //xlsSht.Range[strColFnlMS].Formula = "=IF("+strColStdMS+"=0, 85, IF("+strColUseMS+"="+strQrtMark+"N"+strQrtMark+","+strColOriMS+",(85+("+strColNorMS+"-0.5)*30)))";
                    //xlsSht.Range[strColFnlTS].Formula = "=IF("+strColStdTS+"=0, 85, IF("+strColUseTS+"="+strQrtMark+"N"+strQrtMark+","+strColOriTS+",(85+("+strColNorTS+"-0.5)*30)))";

                    xlsSht.Range[strColFnlMS].Formula = "=IF(["+strColUseMS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriMS+"], IF(["+strColStdMS+"]=0, 85, (85+(["+strColNorMS+"]-0.5)*30)))";
                    xlsSht.Range[strColFnlTS].Formula = "=IF(["+strColUseTS+"]="+strQrtMark+"N"+strQrtMark+",["+strColOriTS+"], IF(["+strColStdTS+"]=0, 85, (85+(["+strColNorTS+"]-0.5)*30)))";

                    objSCR.Iestterm_ref_id  = Convert.ToInt32(xlsSht.Range[strColEsttermRefID].Text);
                    objSCR.Ikpi_ref_id      = Convert.ToInt32(xlsSht.Range[strColKpiRefID].Text);
                    objSCR.Iymd             = xlsSht.Range[strColYMD].Text;
                    objSCR.Inrmdst_use_ms   = xlsSht.Range[strColUseMS].Text;
                    objSCR.Ipoints_ori_ms   = xlsSht.Range[strColOriMS].Number.ToString();
                    objSCR.Ipoints_avg_ms   = xlsSht.Range[strColAvgMS].Number.ToString();
                    objSCR.Ipoints_std_ms   = xlsSht.Range[strColStdMS].Number.ToString();
                    objSCR.Ipoints_ada_ms   = xlsSht.Range[strColAdaMS].Number.ToString();
                    objSCR.Ipoints_ads_ms   = xlsSht.Range[strColAdsMS].Number.ToString();
                    objSCR.Ipoints_nor_ms   = xlsSht.Range[strColNorMS].Number.ToString();
                    objSCR.Ipoints_fnl_ms   = xlsSht.Range[strColFnlMS].Number.ToString();
                    objSCR.Inrmdst_use_ts   = xlsSht.Range[strColUseTS].Text;
                    objSCR.Ipoints_ori_ts   = xlsSht.Range[strColOriTS].Number.ToString();
                    objSCR.Ipoints_avg_ts   = xlsSht.Range[strColAvgTS].Number.ToString();
                    objSCR.Ipoints_std_ts   = xlsSht.Range[strColStdTS].Number.ToString();
                    objSCR.Ipoints_ada_ts   = xlsSht.Range[strColAdaTS].Number.ToString();
                    objSCR.Ipoints_ads_ts   = xlsSht.Range[strColAdsTS].Number.ToString();
                    objSCR.Ipoints_nor_ts   = xlsSht.Range[strColNorTS].Number.ToString();
                    objSCR.Ipoints_fnl_ts   = xlsSht.Range[strColFnlTS].Number.ToString();

                    //intRtn = objSCR.InsertData
                    //         ( objSCR.Iestterm_ref_id
                    //         , objSCR.Ikpi_ref_id
                    //         , objSCR.Iymd
                    //         , objSCR.Inormdist_use_yn
                    //         , objSCR.Ipoints_ori_ms
                    //         , objSCR.Ipoints_avg_ms
                    //         , objSCR.Ipoints_std_ms
                    //         , objSCR.Ipoints_ada_ms
                    //         , objSCR.Ipoints_ads_ms
                    //         , objSCR.Ipoints_nor_ms
                    //         , objSCR.Ipoints_fnl_ms
                    //         , objSCR.Ipoints_ori_ms
                    //         , objSCR.Ipoints_avg_ms
                    //         , objSCR.Ipoints_std_ms
                    //         , objSCR.Ipoints_ada_ms
                    //         , objSCR.Ipoints_ads_ms
                    //         , objSCR.Ipoints_nor_ms
                    //         , objSCR.Ipoints_fnl_ms
                    //         , itxr_user);
                    //objBSC.Iestterm_ref_id = sheet.Range[strColEsttermRefID].FormulaNumberValue.ToString();
                    //string strTmp = xlsSht.Range[strColNorm].FormulaNumberValue.ToString();
                }
            }
        }

        # region Static Data

        # region Formatting results

        //IStyle headerStyle = workbook.Styles.Add("Heading", null);
        ////Add custom colors to the palette.
        //workbook.SetPaletteColor(8, Color.FromArgb(255, 174, 33));
        //headerStyle.Color = Color.FromArgb(255, 174, 33);
        //headerStyle.Font.Bold = true;
        //headerStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
        //headerStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
        //headerStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
        //headerStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;


        ////Body Style
        //IStyle bodyStyle = workbook.Styles.Add("BodyStyle");
        ////Add custom colors to the palette.
        //workbook.SetPaletteColor(9, Color.FromArgb(239, 243, 247));
        //workbook.SetPaletteColor(10, Color.FromArgb(204, 212, 230));

        //bodyStyle.Color = Color.FromArgb(239, 243, 247);
        //bodyStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
        //bodyStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
        //bodyStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
        //bodyStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
        //bodyStyle.Borders.ColorRGB = Color.FromArgb(204, 212, 230);
        //bodyStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;

        ////Formatting Results
        //xlsSht.Range["A1:B144"].CellStyleName = "BodyStyle";

        //xlsSht.Range["A1:A2"].CellStyleName = "Heading";
        //xlsSht.Range["B2"].CellStyleName = "Heading";

        //xlsSht.Range["A21"].CellStyleName = "Heading";
        //xlsSht.Range["B21"].CellStyleName = "Heading";

        # endregion Formatting Reults

        # endregion

        //Excel Functions
        //xlsSht.Range["A22"].Text = "ABS(ABS(-A3))";
        //xlsSht.Range["B22"].Formula = "ABS(ABS(-A3))";

        //No exception will be thrown if there are unsaved workbooks.
        xlsEgn.ThrowNotSavedOnDestroy = false;
        xlsEgn.Dispose();

        //Saving the workbook to disk.
        workbook.SaveAs("Sample.xls", ExcelSaveType.SaveAsXLS, Response, ExcelDownloadType.PromptDialog);
        //No exception will be thrown if there are unsaved workbooks. No use here since we are
        // saving the workbook.
        xlsEgn.ThrowNotSavedOnDestroy = false;
        xlsEgn.Dispose(); 
    }

    private void PrintFinalScoreToExcel()
    { 
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        DataSet rDs = objBSC.GetFinalScoreApplyNormdist(this.IEstTermRefID, this.IYMD);

        ugrdKpiScore.Clear();
        ugrdKpiScore.DataSource = rDs;
        ugrdKpiScore.DataBind();

        string strCurDate     = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');
        ugrdEEP.ExcelStartRow = 1;
        ugrdEEP.ExportMode    = ExportMode.Download;
        ugrdEEP.DownloadName  = "FinalScore"+strCurDate+".xls"; 
        ugrdEEP.WorksheetName = "FinalScore"+this.IYMD;
        ugrdEEP.Export(ugrdKpiScore);
        ugrdKpiScore.Clear();
    }

    /// <summary>
    /// 실적입력월 배포
    /// </summary>
    private void setTermMonthRelease()
    {
        int intRtn = 0;
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        intRtn      = objBSC.OpenTermDetailMonth(this.IEstTermRefID, this.IYMD, gUserInfo.Emp_Ref_ID);
        ltlMsg.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
    }

    private void GetInterfaceRowData()
    {
        int iRtn1 = 0;
        int iRtn2 = 0;
        /* Source 데이터로부터 I/F 데이터로 데이터를 추출한다. */
        MicroBSC.BSC.Biz.Biz_Bsc_Interface_Dicode objDi = new MicroBSC.BSC.Biz.Biz_Bsc_Interface_Dicode();
        iRtn1 = objDi.ExecRowDataInterface(this.IYMD, EMP_REF_ID);
        objDi.Transaction_Message = iRtn1.ToString() + " 건이 Interface 되었습니다.";
        //ltlMsg.Text = JSHelper.GetAlertScript(objDi.Transaction_Message, false);


        /* TODO : interface 테이블로부터 값을 kpi_result테이블의 인터페이스값을 저장 */
        //MicroBSC.BSC.Biz.Biz_Bsc_Interface_Dicode objDi = new MicroBSC.BSC.Biz.Biz_Bsc_Interface_Dicode();


        //iRtn2 = objDi.RetrieveDataInterfaceValue(IEstTermRefID, IYMD, 0);
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Interface_Dicode bizBscDI = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Interface_Dicode();
        iRtn2 = bizBscDI.RetrieveDataInterfaceValue(IEstTermRefID, IYMD, gUserInfo.Emp_Ref_ID);


        objDi.Transaction_Message = objDi.Transaction_Message + "\n" + iRtn2.ToString() + " 건이 전송 되었습니다.";
        ltlMsg.Text = JSHelper.GetAlertScript(objDi.Transaction_Message, false);

        if (iRtn1 > 0)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
            objBSC.InterfaceData(this.IEstTermRefID, this.IYMD, txtIFDesc.Text, EMP_REF_ID);
            this.setGridClose();
        }
    }

    protected void ugrdClose_InitializeRow(object sender, RowEventArgs e)
    {
        string strVal = e.Row.Cells.FromKey("CLOSING_RATE").Value.ToString();
        if (strVal != "-")
        {
            e.Row.Cells.FromKey("CLOSING_RATE").Style.ForeColor = (double.Parse(strVal) < 100) ? Color.Red : Color.Blue;
            e.Row.Cells.FromKey("CLOSING_RATE").Value = strVal + "%";
        }

        if (e.Row.Cells.FromKey("YMD").Value.ToString() == this.IYMD)
        {
            e.Row.Selected = true;
        }
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.setGridClose();
    }
    
    protected void ugrdClose_Click(object sender, ClickEventArgs e)
    {
        ltlMsg.Text = "";
        this.IEstTermRefID = (e.Row.Cells.FromKey("ESTTERM_REF_ID").Value!=null) ? Convert.ToInt32(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()) : 0;
        this.IYMD          = (e.Row.Cells.FromKey("YMD").Value!=null) ? e.Row.Cells.FromKey("YMD").Value.ToString() : "";

        string strClose    = (e.Row.Cells.FromKey("CLOSE_YN").Value!=null) ? e.Row.Cells.FromKey("CLOSE_YN").Value.ToString() : "N";

        this.setFormData();
    }
    
    protected void imgBtnRelease_Click(object sender, ImageClickEventArgs e)
    {
        this.setTermMonthRelease();
        this.setGridClose();
    }

    protected void imgBtnNormDist_Click(object sender, ImageClickEventArgs e)
    {
        this.CalcFinalScore();
        this.setGridClose();
        this.setFormData();
    }

    protected void imgBtnApplyExt_Click(object sender, ImageClickEventArgs e)
    {
        this.CalcFinalExternalScore();
        this.setGridClose();
        this.setFormData();
    }

    protected void imgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.setClosing_Cancel("CANCEL");
        this.setGridClose();
        this.setFormData();
    }

    protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (this.setClosing_Cancel("CLOSE"))
        {
            this.setGridClose();
            this.setFormData();
        }
    }

    protected void imgBtnCalc_Click(object sender, ImageClickEventArgs e)
    {
        if (this.setCalc())
            ltlMsg.Text = JSHelper.GetAlertScript("계산이 성공하였습니다.");
    }

    protected void imgBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.PrintFinalScoreToExcel();
    }    

    protected void imgBtnPrintNorm_Click(object sender, ImageClickEventArgs e)
    {
        this.SetNormDistExcelDown();
    }

    protected void imgBtnInterface_Click(object sender, ImageClickEventArgs e)
    {
        this.GetInterfaceRowData();
    }

    protected void ugrdEEP_RowExporting(object sender, RowExportingEventArgs e)
    {
        NewKey = e.GridRow.Cells[1].Value.ToString();
        if (OldKey == NewKey)
        {
            blnSw = true;
        }
        else
        {
            blnSw = false;
            blnCL = (blnCL) ? false : true;
        }

        OldKey = NewKey;

        e.GridRow.Style.BackColor = (blnCL) ? Color.Wheat : Color.AliceBlue;

    }

}
