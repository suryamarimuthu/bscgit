using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;
using System.Collections.Specialized;

using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;

using MicroBSC.Data;
//using MicroBSC.Biz.Common.Dac;

namespace MicroBSC.Biz.Common.Biz
{
    /// <summary>
    /// Biz_Com_Approval_Info
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Com_Approval_Info
    /// Class Func     : COM_APPROVAL_INFO Business Logic Class
    /// CREATE DATE    : 2008-05-17 오전 6:07:10
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Com_Approval_Info : MicroBSC.Biz.Common.Dac.Dac_Com_Approval_Info
    {
        #region =========== 결재처리 환경설정, Util =============

        public static string GetDraftPagePath(string ibiz_type)
        {
            switch (ibiz_type)
            { 
                case Biz_Type.biz_type_kpi_doc:
                    return Biz_Type.path_kpi_doc;
                case Biz_Type.biz_type_kpi_docbatch:
                    return Biz_Type.path_kpi_docbatch;
                case Biz_Type.biz_type_kpi_rst:
                    return Biz_Type.path_rst_doc;
                case Biz_Type.biz_type_kpi_rstbatch:
                    return Biz_Type.path_rst_docbatch;
                case Biz_Type.biz_type_prj_doc:
                    return Biz_Type.path_prj_doc;
                case Biz_Type.biz_type_target_agreement:
                    return Biz_Type.path_target_agreement;
                case Biz_Type.biz_type_target_result:
                    return Biz_Type.path_target_result;
                case Biz_Type.biz_type_target_resultbatch:
                    return Biz_Type.path_target_resultbatch;
                default:
                    return "";
            }
        }

        public static string GetDraftTitle(string ibiz_type)
        { 
            switch (ibiz_type)
            { 
                case Biz_Type.biz_type_kpi_doc:
                    return Biz_Type.biz_type_kpi_doc_name;
                case Biz_Type.biz_type_kpi_rst:
                    return Biz_Type.biz_type_kpi_rst_name;
                case Biz_Type.biz_type_prj_doc:
                    return Biz_Type.biz_type_prj_doc_name;
                case Biz_Type.biz_type_target_agreement:
                    return Biz_Type.biz_type_target_agreement_name;
                case Biz_Type.biz_type_target_result:
                    return Biz_Type.biz_type_target_result_name;
                case Biz_Type.biz_type_kpi_docbatch:
                    return Biz_Type.biz_type_kpi_docbatch_name;
                case Biz_Type.biz_type_kpi_rstbatch:
                    return Biz_Type.biz_type_kpi_rstbatch_name;
                default:
                    return "";
            }
        }

        /// <summary>
        /// aspx -> html
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtmlSource(string url)
        {
            WebRequest objRequest = HttpWebRequest.Create(url);

            StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            return result;
        }

        public void SetLineUpdateHistory(decimal app_ref_id, int version_no, string update_reason)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                base.SetLineUpdateHistory(conn, trx, app_ref_id, version_no, update_reason);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// aspx -> html file
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filePath"></param>
        public static void SaveHtmlSourceToFile(string url, string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            string htmlSource = GetHtmlSource(url);

            StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);

            writer.WriteLine(htmlSource);
            writer.Close();
        }

        /// <summary>
        /// aspx -> html
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetServerPageToHtml(string uri, string filePath)
        {
            WebClient Client = new WebClient();
            Stream strm = Client.OpenRead(uri);
            StreamReader sr = new StreamReader(strm);
            string str = " ";
            str = sr.ReadToEnd();
            sr.Close();
            strm.Close();

            //StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
            //writer.WriteLine(str);
            //writer.Close();

            return str;
        }

        /// <summary>
        /// 결재이미지 리턴
        /// </summary>
        /// <param name="iAppStatus">결재상태값</param>
        /// <returns></returns>
        public static string GetAppImageUrl(string iAppStatus)
        {
            switch (iAppStatus)
            { 
                case Biz_Type.app_status_nodraft:
                    return Biz_Type.app_status_img_none;
                case Biz_Type.app_status_draft:
                    return Biz_Type.app_status_img_draft;
                case Biz_Type.app_status_ondraft:
                    return Biz_Type.app_status_img_ondraft;
                case Biz_Type.app_status_onmodify:
                    return Biz_Type.app_status_img_onmodify;
                case Biz_Type.app_status_recall:
                    return Biz_Type.app_status_img_recall;
                case Biz_Type.app_status_complete:
                    return Biz_Type.app_status_img_complete;
                case Biz_Type.app_status_return:
                    return Biz_Type.app_status_img_return;
                default:
                    return Biz_Type.app_status_img_none;
            }

            return Biz_Type.app_status_img_none;
        }

        /// <summary>
        /// 결재이미지 텍스트
        /// </summary>
        /// <param name="iAppStatus">결재상태값</param>
        /// <returns></returns>
        public static string GetAppImageText(string iAppStatus)
        {
            switch (iAppStatus)
            { 
                case Biz_Type.app_status_nodraft:
                    return Biz_Type.app_status_desc_none;
                case Biz_Type.app_status_draft:
                    return Biz_Type.app_status_desc_ondraft;
                case Biz_Type.app_status_ondraft:
                    return Biz_Type.app_status_desc_ondraft;
                case Biz_Type.app_status_onmodify:
                    return Biz_Type.app_status_desc_onmodify;
                case Biz_Type.app_status_complete:
                    return Biz_Type.app_status_desc_complete;
                case Biz_Type.app_status_return:
                    return Biz_Type.app_status_desc_return;
                default:
                    return Biz_Type.app_status_desc_none;
            }
        }

        public DataTable GetApprovalEmpByOne(string biz_type, int draft_emp_ref_id)
        {
            return base.GetApprovalEmpByOne(biz_type, draft_emp_ref_id);
        }

        public DataTable GetEmpList(string biz_type, string dept_id)
        {
            return base.GetEmpList(biz_type, dept_id);
        }

        public bool InsertFixEmp(string biz_type, object[,] objAppEmp, int reg_user)
        {
            bool rtnValue = false;
            this.Transaction_Message = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.InsertFixEmp(conn, trx, biz_type, objAppEmp, reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                this.Transaction_Message = ex.Message.Replace("\\r", "");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return rtnValue;
        }

        public bool DeleteFixEmp(string biz_type, object[] objAppEmp)
        {
            bool rtnValue = false;
            this.Transaction_Message = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.DeleteFixEmp(conn, trx, biz_type, objAppEmp);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                this.Transaction_Message = ex.Message.Replace("\\r", "");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return rtnValue;
        }

        public bool DeleteAllEmp(string biz_type, object[] objDraftEmp, object[] objAppEmp)
        {
            bool rtnValue = false;
            this.Transaction_Message = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.DeleteAllEmp(conn, trx, biz_type, objDraftEmp, objAppEmp);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                this.Transaction_Message = ex.Message.Replace("\\r", "");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return rtnValue;
        }

        public bool ChangeLineSort(string biz_type, bool sort_up, object[] objDraftEmp, int app_emp_ref_id, int reg_user)
        {
            bool rtnValue = false;
            this.Transaction_Message = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.ChangeLineSort(conn, trx, biz_type, sort_up, objDraftEmp, app_emp_ref_id, reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                this.Transaction_Message = ex.Message.Replace("\\r", "");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return rtnValue;
        }
        public bool ChangeBaseSort(string biz_type, bool sort_up, int emp_ref_id, int reg_user)
        {
            bool rtnValue = false;
            this.Transaction_Message = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.ChangeBaseSort(conn, trx, biz_type, sort_up, emp_ref_id, reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                this.Transaction_Message = ex.Message.Replace("\\r", "");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return rtnValue;
        }

        public bool InsertAppEmp(string biz_type, object[] objDraftEmp, object[, ] objAppEmp, int reg_user)
        {
            bool rtnValue = false;
            this.Transaction_Message = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.InsertAppEmp(conn, trx, biz_type, objDraftEmp, objAppEmp, reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                this.Transaction_Message = ex.Message.Replace("\\r", "");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return rtnValue;
        }

        public DataTable GetLineUpdateReason(decimal app_ref_id, int version_no)
        {
            return base.GetLineUpdateReason(app_ref_id, version_no);
        }

        public DataTable GetFullAppLine(string biz_type, int emp_ref_id)
        {
            /* 수정일자 : 2012.7.2
             * 수정작자 : 장동건
             * 수정내용 : 하나이 던 것을 세개로 분리
             *            주석 처리한 아래 메서드 따라 가 볼껏
             * return base.GetFullAppLine(biz_type, emp_ref_id);
             * */


            int intPlusCount = 0;
            int intLastStep = 0;

            DataTable dtPlusCount = base.GetPlusCountOfFullAppLine(biz_type);
            if (dtPlusCount.Rows.Count > 0)
            {
                intPlusCount = DataTypeUtility.GetToInt32(dtPlusCount.Rows[0][0]);
            }

            DataTable dtLastStep = GetLastStepOfFullAppLine(biz_type, emp_ref_id);
            if (dtLastStep.Rows.Count > 0)
            {
                intLastStep = DataTypeUtility.GetToInt32(dtLastStep.Rows[0][0]);
            }



            return base.GetFullAppLine(intPlusCount, intLastStep, biz_type, emp_ref_id);

        }

        public DataTable GetBaseAppList(string biz_type)
        {
            return base.GetBaseAppList(biz_type);
        }

        public static string GetBizTypeName(string iBizType)
        {
            switch (iBizType)
            { 
                case Biz_Type.biz_type_kpi_doc:
                    return Biz_Type.biz_type_kpi_doc_name;
                case Biz_Type.biz_type_kpi_rst:
                    return Biz_Type.biz_type_kpi_rst_name;
                case Biz_Type.biz_type_prj_doc:
                    return Biz_Type.biz_type_prj_doc_name;
                case Biz_Type.biz_type_target_agreement:
                    return Biz_Type.biz_type_target_agreement_name;
                default:
                    return "";
            }
        }

        #endregion

        #region ============== Data IO ================
        public Biz_Com_Approval_Info() { }
        public Biz_Com_Approval_Info(decimal iapp_ref_id) : base(iapp_ref_id) { }
        public Biz_Com_Approval_Info(decimal iapp_ref_id, int iversion_no) : base(iapp_ref_id, iversion_no) { }

        public int InsertData(IDbConnection con, IDbTransaction txr, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user)
        {
            return base.InsertData_Dac(con, txr, iori_doc, ititle, ibiz_type, iapp_status, idraft_status, ifile_ref_id, itxr_user);
        }

        public int ReDraft(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user)
        {
            return base.ReDraft_Dac(con, txr, iapp_ref_id, iori_doc, ititle, ibiz_type, iapp_status, idraft_status, ifile_ref_id, itxr_user);
        }

        public int ReWrite(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user)
        { 
            return ReWrite_Dac (con, txr, iapp_ref_id, iversion_no, iori_doc, ititle, ibiz_type, iapp_status, idraft_status, ifile_ref_id, itxr_user);
        }

        public int UpdateData(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, string iapp_code, string iori_doc, string ititle, string ibiz_type, string ifile_ref_id, int itxr_user)
        {
            return base.UpdateData_Dac(con, txr, iapp_ref_id, iversion_no, iapp_code, iori_doc, ititle, ibiz_type, ifile_ref_id, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int itxr_user)
        {
            return base.DeleteData_Dac(con, txr, iapp_ref_id, iversion_no, itxr_user);
        }

        /// <summary>
        /// 최초기안
        /// </summary>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <param name="dtAppLine"></param>
        /// <returns></returns>
        public bool TxrDraft(string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user
                             , DataTable dtAppLine, NameValueCollection pParam)
        {
            int iRtnRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
                iRtnRow = this.InsertData(conn, trx, iori_doc, ititle, ibiz_type, iapp_status, idraft_status, ifile_ref_id, itxr_user);
                if (base.Transaction_Result == "Y" && base.IApp_Ref_Id > 0 && base.IVersion_No>0)
                {
                    for (int i=0; i < dtAppLine.Rows.Count; i++)
                    {
                        objPrc.IApp_Ref_Id    = base.IApp_Ref_Id;
                        objPrc.IVersion_No    = base.IVersion_No;
                        objPrc.ILine_Step     = int.Parse(dtAppLine.Rows[i]["LINE_STEP"].ToString());
                        objPrc.IApp_Emp_Id    = int.Parse(dtAppLine.Rows[i]["APP_EMP_ID"].ToString());
                        objPrc.IComplete_Yn   = dtAppLine.Rows[i]["COMPLETE_YN"].ToString();
                        objPrc.IComments      = dtAppLine.Rows[i]["COMMENTS"].ToString();
                        objPrc.IReturn_Reason = dtAppLine.Rows[i]["RETURN_REASON"].ToString();
                        objPrc.ILine_Type     = dtAppLine.Rows[i]["LINE_TYPE"].ToString();
                        objPrc.IApp_Method    = dtAppLine.Rows[i]["APP_METHOD"].ToString();
                        objPrc.Itxr_user      = int.Parse(dtAppLine.Rows[i]["TXR_USER"].ToString());

                        iRtnRow = objPrc.UpdateData
                                         ( conn, trx
                                         , objPrc.IApp_Ref_Id
                                         , objPrc.IVersion_No
                                         , objPrc.ILine_Step
                                         , objPrc.IApp_Emp_Id
                                         , objPrc.IComplete_Yn
                                         , objPrc.IComments
                                         , objPrc.IReturn_Reason
                                         , objPrc.ILine_Type
                                         , objPrc.IApp_Method
                                         , objPrc.Itxr_user);
                        if (objPrc.Transaction_Result == "N")
                        {
                            base.Transaction_Message = objPrc.Transaction_Message;
                            base.Transaction_Result  = objPrc.Transaction_Result;
                            trx.Rollback();
                            return false;
                        }
                    }

                    // 최초기안의 경우에만 원문서에 문서번호 Update
                    if (!this.UpdateOriDocAppKey(conn, trx, ibiz_type, pParam, objPrc.IApp_Ref_Id))
                    {
                        base.Transaction_Message = "결재원문에 결재상태를 수정할 수 없습니다.";
                        base.Transaction_Result = "N";
                        trx.Rollback();
                        return false;
                    }

                    trx.Commit();
                }
                else
                {
                    trx.Rollback();
                    base.Transaction_Message = objPrc.Transaction_Message;
                    base.Transaction_Result = "N";
                    return false;
                }
            }
            catch(Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result  = "N";
                trx.Rollback();
                return false;
            }
            finally
            {
                //trx.Commit();
                conn.Close();
                conn.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 최초기안 일괄처리
        /// </summary>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <param name="dtAppLine"></param>
        /// <returns></returns>
        public bool TxrDraftBatch(IDbConnection conn, IDbTransaction trx, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user
                             , DataTable dtAppLine, NameValueCollection pParam)
        {
            int iRtnRow = 0;

            try
            {
                Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
                iRtnRow = this.InsertData(conn, trx, iori_doc, ititle, ibiz_type, iapp_status, idraft_status, ifile_ref_id, itxr_user);
                if (base.Transaction_Result == "Y" && base.IApp_Ref_Id > 0 && base.IVersion_No > 0)
                {
                    for (int i = 0; i < dtAppLine.Rows.Count; i++)
                    {
                        objPrc.IApp_Ref_Id = base.IApp_Ref_Id;
                        objPrc.IVersion_No = base.IVersion_No;
                        objPrc.ILine_Step = int.Parse(dtAppLine.Rows[i]["LINE_STEP"].ToString());
                        objPrc.IApp_Emp_Id = int.Parse(dtAppLine.Rows[i]["APP_EMP_ID"].ToString());
                        objPrc.IComplete_Yn = dtAppLine.Rows[i]["COMPLETE_YN"].ToString();
                        objPrc.IComments = dtAppLine.Rows[i]["COMMENTS"].ToString();
                        objPrc.IReturn_Reason = dtAppLine.Rows[i]["RETURN_REASON"].ToString();
                        objPrc.ILine_Type = dtAppLine.Rows[i]["LINE_TYPE"].ToString();
                        objPrc.IApp_Method = dtAppLine.Rows[i]["APP_METHOD"].ToString();
                        objPrc.Itxr_user = int.Parse(dtAppLine.Rows[i]["TXR_USER"].ToString());

                        iRtnRow = objPrc.UpdateData
                                         (conn, trx
                                         , objPrc.IApp_Ref_Id
                                         , objPrc.IVersion_No
                                         , objPrc.ILine_Step
                                         , objPrc.IApp_Emp_Id
                                         , objPrc.IComplete_Yn
                                         , objPrc.IComments
                                         , objPrc.IReturn_Reason
                                         , objPrc.ILine_Type
                                         , objPrc.IApp_Method
                                         , objPrc.Itxr_user);
                        if (objPrc.Transaction_Result == "N")
                        {
                            base.Transaction_Message = objPrc.Transaction_Message;
                            base.Transaction_Result = objPrc.Transaction_Result;
                            //trx.Rollback();
                            return false;
                        }
                    }

                    // 최초기안의 경우에만 원문서에 문서번호 Update
                    if (!this.UpdateOriDocAppKey(conn, trx, ibiz_type, pParam, objPrc.IApp_Ref_Id))
                    {
                        base.Transaction_Message = "결재원문에 결재상태를 수정할 수 없습니다.";
                        base.Transaction_Result = "N";
                        //trx.Rollback();
                        return false;
                    }

                    //trx.Commit();
                }
                else
                {
                    //trx.Rollback();
                    base.Transaction_Message = objPrc.Transaction_Message;
                    base.Transaction_Result = "N";
                    return false;
                }
            }
            catch (Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result = "N";
                //trx.Rollback();
                return false;
            }
            finally
            {
                //trx.Commit();
                //conn.Close();
                //conn.Dispose();
            }

            return true;
        }


        /// <summary>
        /// 재기안
        /// </summary>
        /// <param name="iapp_ref_id"></param>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <param name="dtAppLine"></param>
        /// <param name="pParam"></param>
        /// <param name="isFirstDraft"></param>
        /// <returns></returns>
        public bool TxrReDraft(decimal iapp_ref_id, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user
                             , DataTable dtAppLine, NameValueCollection pParam)
        {
            int iRtnRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
                iRtnRow = this.ReDraft(conn, trx, iapp_ref_id, iori_doc, ititle, ibiz_type, iapp_status, idraft_status, ifile_ref_id, itxr_user);
                if (base.Transaction_Result == "Y" && base.IApp_Ref_Id > 0 && base.IVersion_No>0)
                {
                    for (int i=0; i < dtAppLine.Rows.Count; i++)
                    {
                        objPrc.IApp_Ref_Id    = base.IApp_Ref_Id;
                        objPrc.IVersion_No    = base.IVersion_No;
                        objPrc.ILine_Step     = int.Parse(dtAppLine.Rows[i]["LINE_STEP"].ToString());
                        objPrc.IApp_Emp_Id    = int.Parse(dtAppLine.Rows[i]["APP_EMP_ID"].ToString());
                        objPrc.IComplete_Yn   = dtAppLine.Rows[i]["COMPLETE_YN"].ToString();
                        objPrc.IComments      = dtAppLine.Rows[i]["COMMENTS"].ToString();
                        objPrc.IReturn_Reason = dtAppLine.Rows[i]["RETURN_REASON"].ToString();
                        objPrc.ILine_Type     = dtAppLine.Rows[i]["LINE_TYPE"].ToString();
                        objPrc.IApp_Method    = dtAppLine.Rows[i]["APP_METHOD"].ToString();
                        objPrc.Itxr_user      = int.Parse(dtAppLine.Rows[i]["TXR_USER"].ToString());

                        iRtnRow = objPrc.UpdateData
                                         ( conn, trx
                                         , objPrc.IApp_Ref_Id
                                         , objPrc.IVersion_No
                                         , objPrc.ILine_Step
                                         , objPrc.IApp_Emp_Id
                                         , objPrc.IComplete_Yn
                                         , objPrc.IComments
                                         , objPrc.IReturn_Reason
                                         , objPrc.ILine_Type
                                         , objPrc.IApp_Method
                                         , objPrc.Itxr_user);
                        if (objPrc.Transaction_Result == "N")
                        {
                            base.Transaction_Message = objPrc.Transaction_Message;
                            base.Transaction_Result  = objPrc.Transaction_Result;
                            trx.Rollback();
                            return false;
                        }
                    }

                    trx.Commit();
                }
                else
                {
                    trx.Rollback();
                    base.Transaction_Message = objPrc.Transaction_Message;
                    base.Transaction_Result = "N";
                    return false;
                }
            }
            catch(Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result  = "N";
                trx.Rollback();
                return false;
            }
            finally
            {
                //trx.Commit();
                conn.Close();
                conn.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 재작성
        /// </summary>
        /// <param name="iapp_ref_id"></param>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="idraft_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <param name="dtAppLine"></param>
        /// <param name="pParam"></param>
        /// <returns></returns>
        public bool TxrReWrite(decimal iapp_ref_id, int iversion_no, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user
                             , DataTable dtAppLine, NameValueCollection pParam)
        {
            int iRtnRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
                iRtnRow = this.ReWrite(conn, trx, iapp_ref_id, iversion_no, iori_doc, ititle, ibiz_type, iapp_status, idraft_status, ifile_ref_id, itxr_user);
                iRtnRow = objPrc.DeleteData(conn, trx, iapp_ref_id, iversion_no, itxr_user);
                if (base.Transaction_Result == "Y" && iapp_ref_id > 0 && iversion_no > 0)
                {
                    this.IApp_Ref_Id = iapp_ref_id;
                    this.IVersion_No = iversion_no;

                    for (int i=0; i < dtAppLine.Rows.Count; i++)
                    {
                        objPrc.IApp_Ref_Id    = iapp_ref_id;
                        objPrc.IVersion_No    = iversion_no;
                        objPrc.ILine_Step     = int.Parse(dtAppLine.Rows[i]["LINE_STEP"].ToString());
                        objPrc.IApp_Emp_Id    = int.Parse(dtAppLine.Rows[i]["APP_EMP_ID"].ToString());
                        objPrc.IComplete_Yn   = dtAppLine.Rows[i]["COMPLETE_YN"].ToString();
                        objPrc.IComments      = dtAppLine.Rows[i]["COMMENTS"].ToString();
                        objPrc.IReturn_Reason = dtAppLine.Rows[i]["RETURN_REASON"].ToString();
                        objPrc.ILine_Type     = dtAppLine.Rows[i]["LINE_TYPE"].ToString();
                        objPrc.IApp_Method    = dtAppLine.Rows[i]["APP_METHOD"].ToString();
                        objPrc.Itxr_user      = int.Parse(dtAppLine.Rows[i]["TXR_USER"].ToString());

                        iRtnRow = objPrc.UpdateData
                                         ( conn, trx
                                         , objPrc.IApp_Ref_Id
                                         , objPrc.IVersion_No
                                         , objPrc.ILine_Step
                                         , objPrc.IApp_Emp_Id
                                         , objPrc.IComplete_Yn
                                         , objPrc.IComments
                                         , objPrc.IReturn_Reason
                                         , objPrc.ILine_Type
                                         , objPrc.IApp_Method
                                         , objPrc.Itxr_user);
                        if (objPrc.Transaction_Result == "N")
                        {
                            base.Transaction_Message = objPrc.Transaction_Message;
                            base.Transaction_Result  = objPrc.Transaction_Result;
                            trx.Rollback();
                            return false;
                        }
                    }

                    trx.Commit();
                }
                else
                {
                    trx.Rollback();
                    base.Transaction_Message = objPrc.Transaction_Message;
                    base.Transaction_Result = "N";
                    return false;
                }
            }
            catch(Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result  = "N";
                trx.Rollback();
                return false;
            }
            finally
            {
                //trx.Commit();
                conn.Close();
                conn.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 수정기안
        /// </summary>
        /// <param name="iapp_ref_id"></param>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <param name="dtAppLine"></param>
        /// <param name="pParam"></param>
        /// <param name="isFirstDraft"></param>
        /// <returns></returns>
        public bool TxrMoDraft(decimal iapp_ref_id, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user
                             , DataTable dtAppLine, NameValueCollection pParam)
        {
            int iRtnRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
                iRtnRow = this.MoDraft_Dac(conn, trx, iapp_ref_id, iori_doc, ititle, ibiz_type, iapp_status, idraft_status, ifile_ref_id, itxr_user);
                if (base.Transaction_Result == "Y" && base.IApp_Ref_Id > 0 && base.IVersion_No>0)
                {
                    for (int i=0; i < dtAppLine.Rows.Count; i++)
                    {
                        objPrc.IApp_Ref_Id    = base.IApp_Ref_Id;
                        objPrc.IVersion_No    = base.IVersion_No;
                        objPrc.ILine_Step     = int.Parse(dtAppLine.Rows[i]["LINE_STEP"].ToString());
                        objPrc.IApp_Emp_Id    = int.Parse(dtAppLine.Rows[i]["APP_EMP_ID"].ToString());
                        objPrc.IComplete_Yn   = dtAppLine.Rows[i]["COMPLETE_YN"].ToString();
                        objPrc.IComments      = dtAppLine.Rows[i]["COMMENTS"].ToString();
                        objPrc.IReturn_Reason = dtAppLine.Rows[i]["RETURN_REASON"].ToString();
                        objPrc.ILine_Type     = dtAppLine.Rows[i]["LINE_TYPE"].ToString();
                        objPrc.IApp_Method    = dtAppLine.Rows[i]["APP_METHOD"].ToString();
                        objPrc.Itxr_user      = int.Parse(dtAppLine.Rows[i]["TXR_USER"].ToString());

                        iRtnRow = objPrc.UpdateData
                                         ( conn, trx
                                         , objPrc.IApp_Ref_Id
                                         , objPrc.IVersion_No
                                         , objPrc.ILine_Step
                                         , objPrc.IApp_Emp_Id
                                         , objPrc.IComplete_Yn
                                         , objPrc.IComments
                                         , objPrc.IReturn_Reason
                                         , objPrc.ILine_Type
                                         , objPrc.IApp_Method
                                         , objPrc.Itxr_user);
                        if (objPrc.Transaction_Result == "N")
                        {
                            base.Transaction_Message = objPrc.Transaction_Message;
                            base.Transaction_Result  = objPrc.Transaction_Result;
                            trx.Rollback();
                            return false;
                        }
                    }

                    trx.Commit();
                }
                else
                {
                    trx.Rollback();
                    base.Transaction_Message = objPrc.Transaction_Message;
                    base.Transaction_Result = "N";
                    return false;
                }
            }
            catch(Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result  = "N";
                trx.Rollback();
                return false;
            }
            finally
            {
                //trx.Commit();
                conn.Close();
                conn.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 결재원문 Key Update (최초기안시에만 호출)
        /// </summary>
        /// <param name="con"></param>
        /// <param name="trx"></param>
        /// <param name="iBizTypeCode"></param>
        /// <param name="pParam"></param>
        /// <param name="pAppRefId"></param>
        /// <returns></returns>
        public bool UpdateOriDocAppKey(IDbConnection con, IDbTransaction trx, string iBizTypeCode, NameValueCollection pParam, decimal pAppRefId)
        {
            if (con == null)
            {
                con = DbAgentHelper.CreateDbConnection();
                con.Open();
            }

            if (trx == null)
            {
                trx = con.BeginTransaction();
            }

            return base.UpdateOriDocAppKey_Dac(con, trx, iBizTypeCode, pParam, pAppRefId);
        }

        public bool UpdateOriDocAppKey(string iBizTypeCode, NameValueCollection pParam, decimal pAppRefId)
        {
            return this.UpdateOriDocAppKey(null, null, iBizTypeCode, pParam, pAppRefId);
        }

        #endregion
    }
}