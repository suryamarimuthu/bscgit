using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.Data;
using MicroBSC.Biz.Common.Dac;

namespace MicroBSC.Biz.Common.Biz
{
    /// <summary>
    /// Biz_Com_Approval_Prc
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Com_Approval_Prc
    /// Class Func     : COM_APPROVAL_PRC Business Logic Class
    /// CREATE DATE    : 2008-05-18 오전 12:04:40
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Com_Approval_Prc  : Dac_Com_Approval_Prc
    {
        public Biz_Com_Approval_Prc() { }
        public Biz_Com_Approval_Prc(decimal iapp_ref_id, int iversion_no, int iline_step) : base( iapp_ref_id,  iversion_no,  iline_step) { }

        public int InsertData(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int iline_step, int iapp_emp_id, string icomplete_yn, string icomments, string ireturn_reason, string iline_type, string iapp_method, int icreate_user, int itxr_user) 
        {
            return base.InsertData_Dac(con, txr, iapp_ref_id,  iversion_no,  iline_step,  iapp_emp_id,  icomplete_yn,  icomments,  ireturn_reason,  iline_type,  iapp_method, itxr_user);
        }

        public int UpdateData(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int iline_step, int iapp_emp_id, string icomplete_yn, string icomments, string ireturn_reason, string iline_type, string iapp_method, int itxr_user) 
        {
            return base.UpdateData_Dac(con, txr, iapp_ref_id, iversion_no, iline_step, iapp_emp_id, icomplete_yn, icomments, ireturn_reason, iline_type, iapp_method, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int iline_step, int itxr_user) 
        {
            return base.DeleteData_Dac(con, txr, iapp_ref_id, iversion_no, iline_step, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int itxr_user)
        {
            return base.DeleteData_Dac(con, txr, iapp_ref_id, iversion_no, itxr_user);
        }

        /// <summary>
        /// 승인
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="dtAppLine">APP_REF_ID:decimal,VERSION_NO:int,LINE_STEP:int, APP_EMP_ID:int</param>
        /// <returns></returns>
        public int Approval
                 (IDbConnection con, IDbTransaction trx, DataTable dtAppLine)
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

            int iRtn = 0;

            for (int i = 0; i < dtAppLine.Rows.Count; i++)
            { 
                base.IApp_Ref_Id = decimal.Parse(dtAppLine.Rows[i]["APP_REF_ID"].ToString());
                base.IVersion_No = int.Parse(dtAppLine.Rows[i]["VERSION_NO"].ToString());
                base.ILine_Step  = int.Parse(dtAppLine.Rows[i]["LINE_STEP"].ToString());
                base.IComments   = dtAppLine.Rows[i]["COMMENTS"].ToString();
                base.Itxr_user   = int.Parse(dtAppLine.Rows[i]["APP_EMP_ID"].ToString());
                iRtn += base.Approval_Dac(con, trx, base.IApp_Ref_Id, base.IVersion_No, base.ILine_Step, base.IComments, base.Itxr_user);

                if (base.Transaction_Result != "Y")
                {
                    trx.Rollback();
                    con.Close();
                    con.Dispose();
                    return 0;
                }
            }
            trx.Commit();
            con.Close();
            con.Dispose();

            return iRtn;
        }

        public int Approval(DataTable dtAppLine)
        {
            return this.Approval(null, null, dtAppLine);
        }

        /// <summary>
        /// 반려
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="dtAppLine">APP_REF_ID:decimal,VERSION_NO:int,LINE_STEP:int, APP_EMP_ID:int</param>
        /// <returns></returns>
        public int Return
                 (IDbConnection con, IDbTransaction trx, DataTable dtAppLine)
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

            int iRtn = 0;
            for (int i = 0; i < dtAppLine.Rows.Count; i++)
            {
                base.IApp_Ref_Id    = decimal.Parse(dtAppLine.Rows[i]["APP_REF_ID"].ToString());
                base.IVersion_No    = int.Parse(dtAppLine.Rows[i]["VERSION_NO"].ToString());
                base.ILine_Step     = int.Parse(dtAppLine.Rows[i]["LINE_STEP"].ToString());
                base.IReturn_Reason = dtAppLine.Rows[i]["RETURN_REASON"].ToString();
                base.Itxr_user      = int.Parse(dtAppLine.Rows[i]["APP_EMP_ID"].ToString());                

                iRtn += base.Return_Dac(con, trx, base.IApp_Ref_Id, base.IVersion_No, base.ILine_Step, base.IReturn_Reason, base.Itxr_user);
                
                if (base.Transaction_Result == "Y")
                {
                    trx.Commit();
                }
                else
                {
                    trx.Rollback();
                }
            }

            con.Close();
            con.Dispose();

            return iRtn;
        }

        public int Return(DataTable dtAppLine)
        {
            return this.Return(null, null, dtAppLine);
        }

        /// <summary>
        /// 수정결재요청
        /// </summary>
        /// <param name="con"></param>
        /// <param name="trx"></param>
        /// <param name="iapp_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public bool RequestModifyDraft(IDbConnection con, IDbTransaction trx, decimal iapp_ref_id, int itxr_user)
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

            int intRtn = base.RequestModifyDraft_Dac(con, trx, iapp_ref_id, itxr_user);

            if (base.Transaction_Result == "Y")
            {
                trx.Commit();
            }
            else
            {
                trx.Rollback();
            }

            con.Close();
            con.Dispose();

            if (base.Transaction_Result == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RequestModifyDraft(decimal iapp_ref_id, int itxr_user)
        {
            return this.RequestModifyDraft(null, null, iapp_ref_id, itxr_user);
        }

        /// <summary>
        /// 결재회수
        /// </summary>
        /// <param name="con"></param>
        /// <param name="trx"></param>
        /// <param name="dtRecall">APP_REF_ID:decimal,VERSION_NO:int</param>
        /// <returns></returns>
        public int RecallDraft(IDbConnection con, IDbTransaction trx, DataTable dtRecall, int itxr_user)
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

            int iRtn = 0;

            try 
            {
                for (int i = 0; i < dtRecall.Rows.Count; i++)
                {
                    base.IApp_Ref_Id    = decimal.Parse(dtRecall.Rows[i]["APP_REF_ID"].ToString());
                    base.IVersion_No    = int.Parse(dtRecall.Rows[i]["VERSION_NO"].ToString());

                    iRtn += base.RecallDraft_Dac(con, trx, base.IApp_Ref_Id, base.IVersion_No, itxr_user);
                    
                    if(base.Transaction_Result != "Y")
                    {
                        trx.Rollback();
                    }
                }

                trx.Commit();
            }
            catch(Exception ex) 
            {
                trx.Rollback();
            }
            finally 
            {
                con.Close();
                con.Dispose();
            }

            return iRtn;
        }

        public bool GetSendMailUser(decimal iapp_ref_id, int iversion_no, int itxr_user, out string sC_EMP_MAIL, out string sP_EMP_MAIL, out string sN_EMP_MAIL)
        {
            bool blnRtn = false;
            DataSet rDs = base.GetAllList(iapp_ref_id, iversion_no);
            string sEmpRefID = "0";

            sC_EMP_MAIL = "";
            sP_EMP_MAIL = "";
            sN_EMP_MAIL = "";
            int iRow = rDs.Tables[0].Rows.Count;
            for (int i = 0; i < iRow; i++)
            {
                sEmpRefID = DataTypeUtility.GetValue(rDs.Tables[0].Rows[i]["EMP_REF_ID"]);
                if (sEmpRefID == itxr_user.ToString())
                {
                    blnRtn = true;
                    sC_EMP_MAIL     = DataTypeUtility.GetValue(rDs.Tables[0].Rows[i]["EMP_EMAIL"]);
                    if (i > 0)
                    {
                        sP_EMP_MAIL = DataTypeUtility.GetValue(rDs.Tables[0].Rows[i - 1]["EMP_EMAIL"]);
                    }

                    if ((i + 1) < iRow)
                    {
                        sN_EMP_MAIL = DataTypeUtility.GetValue(rDs.Tables[0].Rows[i + 1]["EMP_EMAIL"]);
                    }
                    break;
                }
            }

            return blnRtn;
        }
    }
}