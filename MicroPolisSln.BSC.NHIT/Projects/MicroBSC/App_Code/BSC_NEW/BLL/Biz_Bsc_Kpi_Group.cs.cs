using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.Data;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_Group에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Bsc_Kpi_Group Biz 클래스
    /// Class 내용		: Biz_Bsc_Kpi_Group Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2006.11.01
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Kpi_Group : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Group
    {
        public Biz_Bsc_Kpi_Group() { }
        public Biz_Bsc_Kpi_Group(int iestterm_ref_id, string ikpi_group_ref_id) : base(iestterm_ref_id, ikpi_group_ref_id) { }

        public int InsertData(int iestterm_ref_id, string ikpi_group_ref_id, string inormdist_use_yn, string imulti_est_use_yn, string idescriptions, int itxr_user) 
        {
            return base.InsertData_Dac(iestterm_ref_id
                                     , ikpi_group_ref_id
                                     , inormdist_use_yn
                                     , imulti_est_use_yn
                                     , idescriptions
                                     , itxr_user);
        }
        public int UpdateData(int iestterm_ref_id, string ikpi_group_ref_id, string inormdist_use_yn, string imulti_est_use_yn, string idescriptions, int itxr_user) 
        {
            return base.UpdateData_Dac(iestterm_ref_id
                                     , ikpi_group_ref_id
                                     , inormdist_use_yn
                                     , imulti_est_use_yn
                                     , idescriptions
                                     , itxr_user);
        }
        public int DeleteData(int iestterm_ref_id, string ikpi_group_ref_id,  int itxr_user) 
        {
            return base.DeleteData_Dac(iestterm_ref_id, ikpi_group_ref_id,  itxr_user);
        }

        public DataTable GetIssueGroup(int estterm_ref_id, int group_code)
        {
            return base.GetIssueGroup(estterm_ref_id, group_code);
        }

        public bool CopyGroup(int org_estterm_ref_id, int new_estterm_ref_id, int itxr_user)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.CopyGroup(conn, trx, org_estterm_ref_id, new_estterm_ref_id, itxr_user);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }
        public bool SaveIssueGroup(int estterm_ref_id, int group_code, string group_name, int itxr_user)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.SaveIssueGroup(conn, trx, estterm_ref_id, group_code, group_name, itxr_user);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }
        public bool DeleteIssueGroup(int estterm_ref_id, int group_code)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.DeleteIssueGroup(conn, trx, estterm_ref_id, group_code);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }
        public DataTable GetGroupMapList(int estterm_ref_id, int group_code)
        {
            return base.GetGroupMapList(estterm_ref_id, group_code);
        }
        public bool InsertIssueGroupMap(int estterm_ref_id, int group_code, DataTable dtInsert, int reg_user)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.InsertIssueGroupMap(conn, trx, estterm_ref_id, group_code, dtInsert, reg_user);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }
        public bool DeleteIssueGroupMap(int estterm_ref_id, int group_code, DataTable dtInsert)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.DeleteIssueGroupMap(conn, trx, estterm_ref_id, group_code, dtInsert);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }
    }
}
