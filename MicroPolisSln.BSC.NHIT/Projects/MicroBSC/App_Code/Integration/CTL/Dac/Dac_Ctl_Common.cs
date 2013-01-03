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
/// Dac_Ctl_Common에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Ctl_Common Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.Integration.CTL.Dac
{
    public class Dac_Ctl_Common : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================
        
        
        public int Insert_RoleMenu(IDbConnection conn
                                , IDbTransaction trx
                                , object role_ref_id
                                , object menu_ref_id)
        {
            string query = @"
INSERT INTO COM_ROLE_MENU_REL (ROLE_REF_ID, MENU_REF_ID) 
                       VALUES (@ROLE_REF_ID, @MENU_REF_ID)";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
            paramArray[0].Value = role_ref_id;
            paramArray[1]       = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[1].Value = menu_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
            return affectedRow;
        }

        public bool Delete_RoleMenu(IDbConnection conn
                                , IDbTransaction trx
                                , object role_ref_id
                                , object menu_ref_id)
        {
            string query = @"
DELETE COM_ROLE_MENU_REL 
WHERE ROLE_REF_ID = @ROLE_REF_ID 
  AND MENU_REF_ID = @MENU_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = role_ref_id;
            paramArray[1]               = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = menu_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
            return (affectedRow > 0) ? true : false;
        }


        #endregion



        #region ========================== 접속 LOG ============================


        public DataSet runUserQuery_DB(string query)
        {
            DataSet DS = DbAgentObj.Fill(query);
            return DS;
        }



        /// <summary>
        /// 해당 세션ID 정보가 있는지 확인
        /// </summary>
        public int CheckConnectLog(string SESSION_ID, string LOGIN_ID)
        {
            DataSet DS = new DataSet();
            
            
            string query = @"
SELECT  COUNT(*)
    FROM    COM_CONNECT_LOG
    WHERE   SESSION_ID  =   @SESSION_ID
        AND LOGIN_ID    =   @LOGIN_ID";

            int cnt;


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@SESSION_ID", SqlDbType.NVarChar);
            paramArray[0].Value = SESSION_ID;
            paramArray[1] = CreateDataParameter("@LOGIN_ID", SqlDbType.NVarChar);
            paramArray[1].Value = LOGIN_ID;


            DS = DbAgentObj.Fill(query, paramArray);


            cnt = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString());

            return cnt;
        }



        /// <summary>
        /// 해당 세션정보를 인서트
        /// </summary>
        public int InsertConnectLog(string SESSION_ID, int EMP_REF_ID, string LOGIN_ID, string EMP_NAME, string CONNECT_IP, string SYS_NAME)
        {
            string query = @"
INSERT INTO     COM_CONNECT_LOG (
                    SESSION_ID
                    , EMP_REF_ID
                    , LOGIN_ID
                    , EMP_NAME
                    , CONNECT_IP
                    , SYS_NAME
                    , START_DT)

                VALUES (
                    @SESSION_ID
					, @EMP_REF_ID
					, @LOGIN_ID
					, @EMP_NAME
                    , @CONNECT_IP
                    , @SYS_NAME
					, sysdate)";

            query = query.Replace("\n", " ").Replace("\t", " ").Replace("\r", " ");



            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@SESSION_ID", SqlDbType.NVarChar);
            paramArray[0].Value = SESSION_ID;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = EMP_REF_ID;
            paramArray[2] = CreateDataParameter("@LOGIN_ID", SqlDbType.NVarChar);
            paramArray[2].Value = LOGIN_ID;
            paramArray[3] = CreateDataParameter("@EMP_NAME", SqlDbType.NVarChar);
            paramArray[3].Value = EMP_NAME;
            paramArray[4] = CreateDataParameter("@CONNECT_IP", SqlDbType.VarChar);
            paramArray[4].Value = CONNECT_IP;
            paramArray[5] = CreateDataParameter("@SYS_NAME", SqlDbType.NVarChar);
            paramArray[5].Value = SYS_NAME;




            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray);

            return affectedRow;
        }




        public int UpdateConnectLog(string SESSION_ID, string LOGIN_ID)
        {
            string query = @"
UPDATE  COM_CONNECT_LOG
    SET     END_DT      =   GETDATE()
    WHERE   SESSION_ID  =   @SESSION_ID
        AND LOGIN_ID    =   @LOGIN_ID";


            query = query.Replace("\n", " ").Replace("\t", " ").Replace("\r", " ");



            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@SESSION_ID", SqlDbType.NVarChar);
            paramArray[0].Value = SESSION_ID;
            paramArray[1] = CreateDataParameter("@LOGIN_ID", SqlDbType.NVarChar);
            paramArray[1].Value = LOGIN_ID;




            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray);
            return affectedRow;
        }





        public DataTable SelectConnectLog(string dept_ref_id, string emp_name, string start_dt, string end_dt, int iFirstRow, int iLastRow)
        {

            string query = @"
SELECT  *
    FROM
        (
         SELECT A.SESSION_ID
                , A.EMP_REF_ID
                , A.LOGIN_ID
                , A.EMP_NAME
                , A.CONNECT_IP
                , A.START_DT
                , A.END_DT
                , C.DEPT_NAME
                , ROW_NUMBER() over ( order by A.START_DT desc) as RN
            FROM        COM_CONNECT_LOG A
                JOIN    REL_DEPT_EMP B  ON  A.EMP_REF_ID    =   b.EMP_REF_ID   
                JOIN    COM_DEPT_INFO C ON  B.DEPT_REF_ID   =   C.DEPT_REF_ID
            WHERE   C.DEPT_REF_ID   LIKE    (@DEPT_REF_ID || '%')
                AND A.EMP_NAME      LIKE    (@EMP_NAME || '%') 
                AND A.START_DT
                        BETWEEN     TO_DATE(@SDT,'YYYYMMDD')
                            AND     TO_DATE(@EDT,'YYYYMMDD')
        )
    WHERE
        RN BETWEEN @FirstRow AND @LastRow";


            query = query.Replace("\n", " ").Replace("\t", " ").Replace("\r", " ");
            
            
            
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.NVarChar);
            paramArray[0].Value = dept_ref_id;
            paramArray[1] = CreateDataParameter("@EMP_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = emp_name;
            paramArray[2] = CreateDataParameter("@SDT", SqlDbType.NVarChar);
            paramArray[2].Value = start_dt;
            paramArray[3] = CreateDataParameter("@EDT", SqlDbType.NVarChar);
            paramArray[3].Value = end_dt;
            paramArray[4] = CreateDataParameter("@FirstRow", SqlDbType.Int);
            paramArray[4].Value = iFirstRow;
            paramArray[5] = CreateDataParameter("@LastRow", SqlDbType.Int);
            paramArray[5].Value = iLastRow;
            
            
            DataSet ds = DbAgentObj.FillDataSet(query, "CTRLINFOGET", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }





        public int SelectConnectLogCount(string dept_ref_id, string emp_name, string start_dt, string end_dt)
        {
            string query = @"
SELECT  COUNT(*)
    FROM        COM_CONNECT_LOG     A
        JOIN    REL_DEPT_EMP        B   ON  A.EMP_REF_ID    =   B.EMP_REF_ID   
        JOIN    COM_DEPT_INFO       C   ON  B.DEPT_REF_ID   =   C.DEPT_REF_ID
    WHERE
            C.DEPT_REF_ID   LIKE    (@DEPT_REF_ID || '%')
        AND A.EMP_NAME      LIKE    (@EMP_NAME || '%') 
        AND A.START_DT
                BETWEEN TO_DATE(@SDT,'YYYYMMDD')
                    AND TO_DATE(@EDT,'YYYYMMDD')
    ORDER BY
        A.START_DT DESC";


            query = query.Replace("\n", " ").Replace("\t", " ").Replace("\r", " ");



            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.NVarChar);
            paramArray[0].Value = dept_ref_id;
            paramArray[1] = CreateDataParameter("@EMP_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = emp_name;
            paramArray[2] = CreateDataParameter("@SDT", SqlDbType.NVarChar);
            paramArray[2].Value = start_dt;
            paramArray[3] = CreateDataParameter("@EDT", SqlDbType.NVarChar);
            paramArray[3].Value = end_dt;

            int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray));
            return affectedRow;
        }

        #endregion

    }


}
