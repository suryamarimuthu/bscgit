using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

/// <summary>
/// Biz_Ctl_Common의 요약 설명입니다.
/// </summary>

/// <summary>
/// Biz_Ctl_Common의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Ctl_Common Biz 클래스
/// Class 내용		: Bsc_Kpi_Result Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 방병현
/// 최초작성일		: 2007.04.26
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
namespace MicroBSC.Integration.CTL.Biz
{
    public class Biz_Ctl_Common : MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result
    {
        public Biz_Ctl_Common() { }
      

        #region ========================== 멀티 DB 작업 ============================


        public int AddMenuRole(DataTable dataTable
                                     , object old_role_ref_id)
        {

            MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common _data = new MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common();

            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    _data.Delete_RoleMenu(conn
                                                , trx
                                                , old_role_ref_id
                                                , dataRow["MENU_REF_ID"]);

                    affectedRow += _data.Insert_RoleMenu(conn
                                                        , trx
                                                        , old_role_ref_id
                                                        , dataRow["MENU_REF_ID"]);

                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return 0;
            }
            finally
            {
                conn.Close();
            }

            return affectedRow;
        }
        #endregion


        /// <summary>
        /// 사용자 쿼리 실행
        /// </summary>
        public DataSet runUserQuery(string userQuery)
        {
            MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common dacCtlData = new MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common();
            DataSet DS = dacCtlData.runUserQuery_DB(userQuery);
            return DS;
        }



        /// <summary>
        /// 접속정보 인서트
        /// </summary>
        public void AddConnectLog(string SESSION_ID, int EMP_REF_ID, string LOGIN_ID, string EMP_NAME, string CONNECT_IP, string SYS_NAME)
        {
            MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common dacCtlData = new MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common();

            if (dacCtlData.CheckConnectLog(SESSION_ID, LOGIN_ID) == 0)
            {
                dacCtlData.InsertConnectLog(SESSION_ID, EMP_REF_ID, LOGIN_ID, EMP_NAME, CONNECT_IP, SYS_NAME);
            }
        }




        /// <summary>
        /// 접속정보 업데이트
        /// </summary>
        public void ModifyConnectLog(string SESSION_ID, string LOGIN_ID)
        {
            MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common dacCtlData = new MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common();

            dacCtlData.UpdateConnectLog(SESSION_ID, LOGIN_ID);
        }




        /// <summary>
        /// 접속정보 조회
        /// </summary>
        public DataTable GetConnectLog(string dept_ref_id, string emp_name, string start_dt, string end_dt, int iFirstRow, int iLastRow)
        {
            MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common dacCtlCommon = new MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common();
            DataTable DT = new DataTable();

            DT = dacCtlCommon.SelectConnectLog(dept_ref_id, emp_name, start_dt, end_dt, iFirstRow, iLastRow);

            return DT;
        }



        public int GetConnectLogCount(string dept_ref_id, string emp_name, string start_dt, string end_dt)
        {
            MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common dacCtlCommon = new MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common();
            int cnt;

            cnt = dacCtlCommon.SelectConnectLogCount(dept_ref_id, emp_name, start_dt, end_dt);

            return cnt;
        }
    }
}
