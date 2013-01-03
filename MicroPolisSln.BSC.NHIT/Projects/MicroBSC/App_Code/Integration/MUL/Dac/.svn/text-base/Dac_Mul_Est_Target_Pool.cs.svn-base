using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Integration.MUL.Dac
{
    public class Dac_Mul_Est_Target_Pool : DbAgentBase
    {
        public Dac_Mul_Est_Target_Pool()
        {
        }



        public int Insert_Pool_Data(IDbConnection conn
                                , IDbTransaction trx
                                , object comp_id
                                , object est_id
                                , object estterm_ref_id
                                , object estterm_sub_id
                                , object est_emp_id
                                , object tgt_emp_id
                                , object create_user_ref_id)
        {
            string query = @"
INSERT INTO MUL_EST_TARGET_POOL
		( 
            COMP_ID
            , EST_ID
            , ESTTERM_REF_ID
            , ESTTERM_SUB_ID
            , EST_EMP_ID
            , TGT_EMP_ID
            , CREATE_USER
		)
		VALUES
		(
			@COMP_ID
            , @EST_ID
            , @ESTTERM_REF_ID
            , @ESTTERM_SUB_ID
            , @EST_EMP_ID
            , @TGT_EMP_ID
            , @CREATE_USER
		)
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = est_emp_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;
            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[6].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        /// <summary>
        /// 셀렉트한 결과 모두 인서트, 피평가자의 부서에 해당하는 평가자
        /// </summary>
        public int Insert_Pool_Data_Dept(IDbConnection conn
                                        , IDbTransaction trx
                                        , object comp_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id
                                        , object tgt_dept_id
                                        , object tgt_emp_id
                                        , object create_user_ref_id)
        {
            string query = @"
INSERT INTO     MUL_EST_TARGET_POOL
                    (
                        COMP_ID
                        , EST_ID
                        , ESTTERM_REF_ID
                        , ESTTERM_SUB_ID
                        , EST_EMP_ID
                        , TGT_EMP_ID
                        , CREATE_USER
                    )
    SELECT 
                COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , EST_EMP_ID
                , @TGT_EMP_ID
                , @CREATE_USER
        FROM                    MUL_EST_EMP     MUL
            LEFT OUTER JOIN     REL_DEPT_EMP    REL
                ON  MUL.EST_EMP_ID = REL.EMP_REF_ID
        WHERE
                MUL.COMP_ID            = @COMP_ID
            AND MUL.EST_ID             = @EST_ID
            AND MUL.ESTTERM_REF_ID     = @ESTTERM_REF_ID
            AND MUL.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
            AND MUL.EST_TYPE           = 'EST'
            AND MUL.EST_EMP_ID        != @TGT_EMP_ID
            AND (  REL.DEPT_REF_ID     = @TGT_DEPT_ID       OR  @TGT_DEPT_ID    =   0  )
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;
            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[6].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        /// <summary>
        /// 셀렉트한 결과 모두 인서트, 전체 평가자 대상
        /// </summary>
        public int Insert_Pool_Data(IDbConnection conn
                                    , IDbTransaction trx
                                    , object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object tgt_emp_id
                                    , object create_user_ref_id)
        {
            int affectedRow = Insert_Pool_Data_Dept(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , 0
                                                    , tgt_emp_id
                                                    , create_user_ref_id);

            return affectedRow;
        }



        public int Delete_Pool_Data(IDbConnection conn
                                , IDbTransaction trx
                                , object comp_id
                                , object est_id
                                , object estterm_ref_id
                                , object estterm_sub_id
                                , object est_emp_id
                                , object tgt_emp_id)
        {
            string query = @"
DELETE FROM MUL_EST_TARGET_POOL
  WHERE COMP_ID            = @COMP_ID
    AND EST_ID             = @EST_ID
    AND ESTTERM_REF_ID     = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
    AND (   EST_EMP_ID     = @EST_EMP_ID       OR    @EST_EMP_ID   =  0  )
    AND (   TGT_EMP_ID     = @TGT_EMP_ID       OR    @TGT_EMP_ID   =  0  )
";

           
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = est_emp_id;
            paramArray[5]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        /// <summary>
        /// 삭제 대상을 데이터테이블로 받아서 모두 삭제
        /// </summary>
        public int Delete_Pool_Data(IDbConnection conn
                                , IDbTransaction trx
                                , object comp_id
                                , object est_id
                                , object estterm_ref_id
                                , object estterm_sub_id
                                , DataTable DT_tgt_emp_id)
        {
            if (DT_tgt_emp_id.Rows.Count == 0)
                return 0;
            
            StringBuilder tgt_emp_id_list = new StringBuilder();

            for (int i = 0; i < DT_tgt_emp_id.Rows.Count; i++)
            {
                if (tgt_emp_id_list.Length > 0)
                {
                    tgt_emp_id_list.Append(", ");
                }

                tgt_emp_id_list.Append(DT_tgt_emp_id.Rows[i]["EMP_REF_ID"].ToString());
            }

            string query = string.Format(@"
DELETE FROM MUL_EST_TARGET_POOL
  WHERE COMP_ID            = @COMP_ID
    AND EST_ID             = @EST_ID
    AND ESTTERM_REF_ID     = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
    AND TGT_EMP_ID  IN      ({0})
", tgt_emp_id_list.ToString());


            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }
        



        public DataTable Select_MulEmpCnt_Join_MulPoolEmpCnt(object COMP_ID
                                                        , object EST_ID
                                                        , object ESTTERM_REF_ID
                                                        , object ESTTERM_SUB_ID)
        {
            string query = @"
SELECT      TOTAL.DEPT_REF_ID           AS  DEPT_ID
          , TOTAL.DEPT_NAME             AS  DEPT_NAME
          , CASE WHEN
                        TOTAL.EMP_CNT               IS NULL THEN    0
                                                            ELSE    TOTAL.EMP_CNT               END
                                        AS  EMP_CNT
          , CASE WHEN 
                        EST_EMP_CNT.EST_CNT         IS NULL THEN    0
                                                            ELSE    EST_EMP_CNT.EST_CNT         END
                                        AS  POOL_EST_CNT
          , CASE WHEN
                        EST_TGT_CNT.TOTAL_EST_CNT   IS NULL THEN    0
                                                            ELSE    EST_TGT_CNT.TOTAL_EST_CNT   END
                                        AS  EST_EMP_CNT
          , CASE WHEN
                        TGT_EMP_CNT.TGT_CNT         IS NULL THEN    0 
                                                            ELSE    TGT_EMP_CNT.TGT_CNT         END
                                        AS  POOL_TGT_CNT
          , CASE WHEN
                        EST_TGT_CNT.TOTAL_TGT_CNT   IS NULL THEN    0
                                                            ELSE    EST_TGT_CNT.TOTAL_TGT_CNT   END
                                        AS  TGT_EMP_CNT
    FROM
        (
        --부서별 직원 수        
        SELECT          DEPT_REF_ID, DEPT_NAME, COUNT(*) AS EMP_CNT
            FROM                    COM_EMP_INFO    EMP
                LEFT OUTER JOIN     REL_DEPT_EMP    REL
                    ON  EMP.EMP_REF_ID      =   REL.EMP_REF_ID
                LEFT OUTER JOIN     COM_DEPT_INFO   DEPT
                    ON  DEPT.DEPT_REF_ID   =   REL.DEPT_REF_ID
            WHERE       DEPT.DEPT_REF_ID    IS NOT NULL
            GROUP BY
                        DEPT.DEPT_REF_ID
                      , DEPT.DEPT_NAME
        )   TOTAL
        LEFT OUTER JOIN
        (
        --부서별 평가/피평가자 설정 수
        SELECT          DEPT_REF_ID
                      , SUM(CASE WHEN   EST_TYPE    =   'EST'   THEN    1   ELSE    0   END) AS  TOTAL_EST_CNT
                      , SUM(CASE WHEN   EST_TYPE    =   'TGT'   THEN    1   ELSE    0   END) AS  TOTAL_TGT_CNT
            FROM                    MUL_EST_EMP     MUL
                LEFT OUTER JOIN     REL_DEPT_EMP    REL
                    ON  MUL.EST_EMP_ID      =   REL.EMP_REF_ID
                LEFT OUTER JOIN     COM_DEPT_INFO   DEPT
                    ON  DEPT.DEPT_REF_ID    =   REL.DEPT_REF_ID
            WHERE
                    COMP_ID                 =   @COMP_ID
                AND MUL.EST_ID             =   @EST_ID
                AND MUL.ESTTERM_REF_ID     =   @ESTTERM_REF_ID
                AND MUL.ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
            GROUP BY
                        DEPT.DEPT_REF_ID
        )   EST_TGT_CNT
            ON  TOTAL.DEPT_REF_ID   =   EST_TGT_CNT.DEPT_REF_ID
        LEFT OUTER JOIN
        (
        --풀에 저장된 부서별 평가자 인원
        SELECT          DEPT_REF_ID, COUNT(*) AS EST_CNT
            FROM                    (
                                        SELECT          EST_EMP_ID
                                            FROM        MUL_EST_TARGET_POOL
                                            WHERE
                                                        COMP_ID            =   @COMP_ID
                                                AND     EST_ID             =   @EST_ID
                                                AND     ESTTERM_REF_ID     =   @ESTTERM_REF_ID
                                                AND     ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
                                            GROUP BY    EST_EMP_ID
                                    )     POOL_EST
                LEFT OUTER JOIN     REL_DEPT_EMP            REL
                    ON  POOL_EST.EST_EMP_ID      =   REL.EMP_REF_ID
                LEFT OUTER JOIN     COM_DEPT_INFO           DEPT
                    ON  DEPT.DEPT_REF_ID         =   REL.DEPT_REF_ID
            WHERE       
                    DEPT.DEPT_REF_ID    IS NOT NULL
            GROUP BY
                        DEPT.DEPT_REF_ID
        )   EST_EMP_CNT
            ON  TOTAL.DEPT_REF_ID   =   EST_EMP_CNT.DEPT_REF_ID
        LEFT OUTER JOIN
        (
        --풀에 저장된 부서별 피평가자 인원
        SELECT          DEPT_REF_ID, COUNT(*) AS TGT_CNT
            FROM                    (
                                        SELECT          TGT_EMP_ID
                                            FROM        MUL_EST_TARGET_POOL
                                            WHERE
                                                        COMP_ID            =   @COMP_ID
                                                AND     EST_ID             =   @EST_ID
                                                AND     ESTTERM_REF_ID     =   @ESTTERM_REF_ID
                                                AND     ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
                                            GROUP BY    TGT_EMP_ID
                                    )     POOL_TGT
                LEFT OUTER JOIN     REL_DEPT_EMP            REL
                    ON  POOL_TGT.TGT_EMP_ID      =   REL.EMP_REF_ID
                LEFT OUTER JOIN     COM_DEPT_INFO           DEPT
                    ON  DEPT.DEPT_REF_ID         =   REL.DEPT_REF_ID
            WHERE
                    DEPT.DEPT_REF_ID    IS NOT NULL
            GROUP BY
                        DEPT.DEPT_REF_ID
        )   TGT_EMP_CNT
            ON  TOTAL.DEPT_REF_ID   =   TGT_EMP_CNT.DEPT_REF_ID
    ORDER BY
        TOTAL.DEPT_REF_ID   ASC
";

            /*
            string query = @"
SELECT  DEPT_ID
      , DEPT_NAME
      , COUNT(*)        AS  EMP_CNT
      , SUM(POOL_EST)   AS  POOL_EST_CNT
      , SUM(EST)        AS  EST_EMP_CNT
      , SUM(POOL_TGT)   AS  POOL_TGT_CNT
      , SUM(TGT)        AS  TGT_EMP_CNT      
    FROM
        (
        SELECT
                DEPT.DEPT_REF_ID    AS  DEPT_ID
              , DEPT.DEPT_NAME      AS  DEPT_NAME
              , EMP.EMP_REF_ID      AS  EMP_ID
              , EMP.EMP_NAME        AS  EMP_NAME
              , SUM(CASE    WHEN    EST_TYPE = 'EST'    THEN    1   ELSE    0   END)     AS  EST
              , SUM(CASE    WHEN    EST_TYPE = 'TGT'    THEN    1   ELSE    0   END)     AS  TGT
              , SUM(CASE    WHEN    POOL_EST.EMP_ID     IS NULL     THEN    0   ELSE    1   END)     AS  POOL_EST
              , SUM(CASE    WHEN    POOL_TGT.EMP_ID     IS NULL     THEN    0   ELSE    1   END)     AS  POOL_TGT
            FROM
                                    COM_EMP_INFO            EMP
                LEFT OUTER JOIN     REL_DEPT_EMP            REL
                    ON      EMP.EMP_REF_ID      =   REL.EMP_REF_ID
                LEFT OUTER JOIN     COM_DEPT_INFO           DEPT
                    ON      REL.DEPT_REF_ID     =   DEPT.DEPT_REF_ID
                LEFT OUTER JOIN     MUL_EST_EMP             BASE
                    ON      BASE.EST_EMP_ID     =   EMP.EMP_REF_ID
                LEFT OUTER JOIN     (
                                        SELECT      TGT_EMP_ID  AS  EMP_ID
                                            FROM    MUL_EST_TARGET_POOL
                                            WHERE   
                                                    COMP_ID            =   @COMP_ID
                                                AND EST_ID             =   @EST_ID
                                                AND ESTTERM_REF_ID     =   @ESTTERM_REF_ID
                                                AND ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
                                            GROUP BY
                                                    TGT_EMP_ID
                                    )     POOL_TGT
                    ON  (
                            EMP.EMP_REF_ID      =   POOL_TGT.EMP_ID
                        AND BASE.EST_EMP_ID     =   POOL_TGT.EMP_ID
                        AND BASE.EST_TYPE       =   'TGT'
                        )
                LEFT OUTER JOIN     (
                                        SELECT      EST_EMP_ID  AS  EMP_ID
                                            FROM    MUL_EST_TARGET_POOL
                                            WHERE   
                                                    COMP_ID            =   @COMP_ID
                                                AND EST_ID             =   @EST_ID
                                                AND ESTTERM_REF_ID     =   @ESTTERM_REF_ID
                                                AND ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
                                            GROUP BY
                                                    EST_EMP_ID
                                    )   POOL_EST
                    ON  (
                            EMP.EMP_REF_ID      =   POOL_EST.EMP_ID
                        AND BASE.EST_EMP_ID     =   POOL_EST.EMP_ID
                        AND BASE.EST_TYPE       =   'EST'
                        )
            WHERE
                    COMP_ID                 =   @COMP_ID
                AND BASE.EST_ID             =   @EST_ID
                AND BASE.ESTTERM_REF_ID     =   @ESTTERM_REF_ID
                AND BASE.ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
            GROUP BY
                DEPT.DEPT_REF_ID
              , DEPT.DEPT_NAME
              , EMP.EMP_REF_ID
              , EMP.EMP_NAME
        )   A
    GROUP BY
        DEPT_ID, DEPT_NAME
    ORDER BY
        DEPT_ID ASC
";
            */

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;


            DataTable DT = DbAgentObj.FillDataSet(query, "MulEmpCnt_Join_MulPoolEmpCnt", null, paramArray).Tables[0];

            return DT;
        }



        public DataTable Select_MulPoolTgtEmp_List(object COMP_ID
                                            , object DEPT_REF_ID
                                            , object EST_ID
                                            , object ESTTERM_REF_ID
                                            , object ESTTERM_SUB_ID)
        {
            string query = @"
SELECT      POOL.TGT_EMP_ID     AS  EMP_ID
          , EMP.EMP_NAME        AS  EMP_NAME
          , RNK.POS_RNK_NAME    AS  RANK_NAME
          , CLS.POS_CLS_NAME    AS  CLASS_NAME
          , DUT.POS_DUT_NAME    AS  DUTY_NAME
    FROM                    MUL_EST_TARGET_POOL     POOL
        LEFT OUTER JOIN     COM_EMP_INFO            EMP
            ON      POOL.TGT_EMP_ID             =   EMP.EMP_REF_ID     
        LEFT OUTER JOIN     REL_DEPT_EMP            REL
            ON      POOL.TGT_EMP_ID             =   REL.EMP_REF_ID
        LEFT OUTER JOIN     COM_DEPT_INFO           DEPT
            ON      REL.DEPT_REF_ID             =   DEPT.DEPT_REF_ID
        LEFT OUTER JOIN     EST_POSITION_CLS        CLS
            ON      EMP.POSITION_CLASS_CODE     =   CLS.POS_CLS_ID
        LEFT OUTER JOIN     EST_POSITION_RNK        RNK
            ON      EMP.POSITION_RANK_CODE      =   RNK.POS_RNK_ID
        LEFT OUTER JOIN     EST_POSITION_DUT        DUT
            ON      EMP.POSITION_DUTY_CODE      =   DUT.POS_DUT_ID
    WHERE
            POOL.COMP_ID            =   @COMP_ID
        AND DEPT.DEPT_REF_ID        =   @DEPT_ID
        AND POOL.EST_ID             =   @EST_ID
        AND POOL.ESTTERM_REF_ID     =   @ESTTERM_REF_ID
        AND POOL.ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
    GROUP BY
        POOL.TGT_EMP_ID
      , EMP.EMP_NAME
      , RNK.POS_RNK_NAME
      , CLS.POS_CLS_NAME
      , DUT.POS_DUT_NAME
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@DEPT_ID", SqlDbType.Int);
            paramArray[1].Value = DEPT_REF_ID;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[2].Value = EST_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_REF_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_SUB_ID;


            DataTable DT = DbAgentObj.FillDataSet(query, "MulPoolTgtEmp_Lis", null, paramArray).Tables[0];

            return DT;
        }



        public DataTable Select_MulPoolEstEmp_List(object COMP_ID
                                                , object TGT_EMP_ID
                                                , object EST_ID
                                                , object ESTTERM_REF_ID
                                                , object ESTTERM_SUB_ID)
        {
            string query = @"
SELECT      POOL.EST_EMP_ID     AS  EMP_ID
          , EMP.EMP_NAME        AS  EMP_NAME
          , DEPT.DEPT_NAME      AS  DEPT_NAME
          , RNK.POS_RNK_NAME    AS  RANK_NAME
          , CLS.POS_CLS_NAME    AS  CLASS_NAME
          , DUT.POS_DUT_NAME    AS  DUTY_NAME
    FROM                    MUL_EST_TARGET_POOL     POOL
        LEFT OUTER JOIN     COM_EMP_INFO            EMP
            ON      POOL.EST_EMP_ID             =   EMP.EMP_REF_ID     
        LEFT OUTER JOIN     REL_DEPT_EMP            REL
            ON      POOL.EST_EMP_ID             =   REL.EMP_REF_ID
        LEFT OUTER JOIN     COM_DEPT_INFO           DEPT
            ON      REL.DEPT_REF_ID             =   DEPT.DEPT_REF_ID
        LEFT OUTER JOIN     EST_POSITION_CLS        CLS
            ON      EMP.POSITION_CLASS_CODE     =   CLS.POS_CLS_ID
        LEFT OUTER JOIN     EST_POSITION_RNK        RNK
            ON      EMP.POSITION_RANK_CODE      =   RNK.POS_RNK_ID
        LEFT OUTER JOIN     EST_POSITION_DUT        DUT
            ON      EMP.POSITION_DUTY_CODE      =   DUT.POS_DUT_ID
    WHERE
            POOL.COMP_ID            =   @COMP_ID
        AND POOL.TGT_EMP_ID         =   @TGT_EMP_ID
        AND POOL.EST_EMP_ID        !=   @TGT_EMP_ID
        AND POOL.EST_ID             =   @EST_ID
        AND POOL.ESTTERM_REF_ID     =   @ESTTERM_REF_ID
        AND POOL.ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
    GROUP BY
            POOL.EST_EMP_ID
          , EMP.EMP_NAME
          , DEPT.DEPT_NAME
          , RNK.POS_RNK_NAME
          , CLS.POS_CLS_NAME
          , DUT.POS_DUT_NAME
";


            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[1].Value = TGT_EMP_ID;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[2].Value = EST_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_REF_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_SUB_ID;


            DataTable DT = DbAgentObj.FillDataSet(query, "MulPoolEstEmp_List", null, paramArray).Tables[0];

            return DT;
        }




        /// <summary>
        /// 데이터테이블에 포함된 피평가자에 대한 평가자 목록을 풀에서 가져옴
        /// 피평가자 목록이 없으면 null반환
        /// </summary>
        public DataTable Select_BaseEstEmptable(object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , DataTable DT_tgt_emp_id
                                            , object select_yn)
        {
            string tgt_emp_id_list = "";

            for (int i = 0; i < DT_tgt_emp_id.Rows.Count; i++)
            {
                if (tgt_emp_id_list.Length > 0)
                    tgt_emp_id_list += ", ";

                tgt_emp_id_list += DT_tgt_emp_id.Rows[i]["EMP_REF_ID"].ToString();
            }


            if (tgt_emp_id_list.Length == 0)
                tgt_emp_id_list = "-1";


            string query = string.Format(@"
SELECT    EMP.LOGINID
        , EMP.LOGINIP
        , EMP.EMP_REF_ID
        , EMP.EMP_CODE
        , EMP.EMP_EMail
        , EMP.DAILY_PHONE
        , EMP.CELL_PHONE
        , EMP.FAX_NUMBER
        , EMP.JOB_STATUS
        , EMP.ZIPCODE
        , EMP.ADDR_1
        , EMP.ADDR_2
        , EMP.SIGN_PATH
        , EMP.STAMP_PATH
        , EMP.POSITION_CLASS_CODE
        , EMP.POSITION_GRP_CODE
        , EMP.POSITION_RANK_CODE
        , EMP.POSITION_DUTY_CODE
        , EMP.POSITION_KIND_CODE
        , CLS.POS_CLS_NAME
        , GRP.POS_GRP_NAME
        , RNK.POS_RNK_NAME
        , DUT.POS_DUT_NAME    
        , KND.POS_KND_NAME
        , REL.DEPT_REF_ID              AS DEPT_REF_ID
        , DEPT.DEPT_NAME               AS DEPT_NAME
        , POOL.TGT_EMP_ID              AS TGT_EMP_ID
        , POOL.EST_EMP_ID              AS EST_EMP_ID
        , EMP.EMP_NAME                 AS EST_EMP_NAME
    FROM                MUL_EST_TARGET_POOL     POOL
        LEFT OUTER JOIN COM_EMP_INFO            EMP 
            ON (
                        EMP.EMP_REF_ID          =   POOL.EST_EMP_ID
                AND     POOL.COMP_ID            =   @COMP_ID
                AND     POOL.EST_ID             =   @EST_ID
                AND     POOL.ESTTERM_REF_ID     =   @ESTTERM_REF_ID
                AND     POOL.ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
                AND    (POOL.SELECT_YN          =   @SELECT_YN    OR  @SELECT_YN='')        
                AND     POOL.TGT_EMP_ID        IN   ({0})
                )
       LEFT OUTER JOIN  REL_DEPT_EMP            REL
            ON (        EMP.EMP_REF_ID          =   REL.EMP_REF_ID      )
       LEFT OUTER JOIN  COM_DEPT_INFO           DEPT
            ON (        REL.DEPT_REF_ID         =   DEPT.DEPT_REF_ID    )
       LEFT OUTER JOIN  EST_POSITION_DUT        DUT
            ON (        EMP.POSITION_DUTY_CODE  = DUT.POS_DUT_ID        )
       LEFT OUTER JOIN  EST_POSITION_KND        KND
            ON (        EMP.POSITION_KIND_CODE  =   KND.POS_KND_ID      )
       LEFT OUTER JOIN  EST_POSITION_CLS        CLS
            ON (        EMP.POSITION_CLASS_CODE =   CLS.POS_CLS_ID      )
       LEFT OUTER JOIN  EST_POSITION_GRP        GRP
            ON (        EMP.POSITION_GRP_CODE   =   GRP.POS_GRP_ID      )
       LEFT OUTER JOIN  EST_POSITION_RNK        RNK
            ON (        EMP.POSITION_RANK_CODE  =   RNK.POS_RNK_ID      )
    WHERE
            EMP.EMP_REF_ID   IS NOT NULL
    ORDER BY
            TGT_EMP_ID ASC, EST_EMP_ID ASC
", tgt_emp_id_list);


            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@SELECT_YN", SqlDbType.NChar);
            paramArray[4].Value = select_yn;


            DataTable DT = DbAgentObj.FillDataSet(query, "EST_EMP_LIST", null, paramArray, CommandType.Text).Tables[0];
            return DT;
        }

        public DataTable Select_BaseEstEmptable(object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object tgt_emp_id
                                            , object select_yn)
        {
           

            string query = @"
SELECT    EMP.LOGINID
        , EMP.LOGINIP
        , EMP.EMP_REF_ID
        , EMP.EMP_CODE
        , EMP.EMP_EMail
        , EMP.DAILY_PHONE
        , EMP.CELL_PHONE
        , EMP.FAX_NUMBER
        , EMP.JOB_STATUS
        , EMP.ZIPCODE
        , EMP.ADDR_1
        , EMP.ADDR_2
        , EMP.SIGN_PATH
        , EMP.STAMP_PATH
        , EMP.POSITION_CLASS_CODE
        , EMP.POSITION_GRP_CODE
        , EMP.POSITION_RANK_CODE
        , EMP.POSITION_DUTY_CODE
        , EMP.POSITION_KIND_CODE
        , CLS.POS_CLS_NAME
        , GRP.POS_GRP_NAME
        , RNK.POS_RNK_NAME
        , DUT.POS_DUT_NAME    
        , KND.POS_KND_NAME
        , REL.DEPT_REF_ID              AS DEPT_REF_ID
        , DEPT.DEPT_NAME               AS DEPT_NAME
        , POOL.TGT_EMP_ID              AS TGT_EMP_ID
        , POOL.EST_EMP_ID              AS EST_EMP_ID
        , EMP.EMP_NAME                 AS EST_EMP_NAME
    FROM                MUL_EST_TARGET_POOL     POOL
        LEFT OUTER JOIN COM_EMP_INFO            EMP 
            ON (
                        EMP.EMP_REF_ID          =   POOL.EST_EMP_ID
                AND     POOL.COMP_ID            =   @COMP_ID
                AND     POOL.EST_ID             =   @EST_ID
                AND     POOL.ESTTERM_REF_ID     =   @ESTTERM_REF_ID
                AND     POOL.ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID
                AND    (POOL.SELECT_YN          =   @SELECT_YN    OR  @SELECT_YN='')        
                AND     POOL.TGT_EMP_ID         =   @TGT_EMP_ID
                )
       LEFT OUTER JOIN  REL_DEPT_EMP            REL
            ON (        EMP.EMP_REF_ID          =   REL.EMP_REF_ID      )
       LEFT OUTER JOIN  COM_DEPT_INFO           DEPT
            ON (        REL.DEPT_REF_ID         =   DEPT.DEPT_REF_ID    )
       LEFT OUTER JOIN  EST_POSITION_DUT        DUT
            ON (        EMP.POSITION_DUTY_CODE  = DUT.POS_DUT_ID        )
       LEFT OUTER JOIN  EST_POSITION_KND        KND
            ON (        EMP.POSITION_KIND_CODE  =   KND.POS_KND_ID      )
       LEFT OUTER JOIN  EST_POSITION_CLS        CLS
            ON (        EMP.POSITION_CLASS_CODE =   CLS.POS_CLS_ID      )
       LEFT OUTER JOIN  EST_POSITION_GRP        GRP
            ON (        EMP.POSITION_GRP_CODE   =   GRP.POS_GRP_ID      )
       LEFT OUTER JOIN  EST_POSITION_RNK        RNK
            ON (        EMP.POSITION_RANK_CODE  =   RNK.POS_RNK_ID      )
    WHERE
            EMP.EMP_REF_ID   IS NOT NULL
    ORDER BY
            TGT_EMP_ID ASC, EST_EMP_ID ASC
";


            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@SELECT_YN", SqlDbType.NChar);
            paramArray[4].Value = select_yn;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.VarChar);
            paramArray[5].Value = tgt_emp_id;


            DataTable DT = DbAgentObj.FillDataSet(query, "EST_EMP_LIST", null, paramArray, CommandType.Text).Tables[0];
            return DT;
        }


        public int Update_Pool_Select_Flag(IDbConnection conn, IDbTransaction trx
                                        , object comp_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id
                                        , object est_emp_id
                                        , object tgt_emp_id
                                        , object select_yn
                                        , object update_user_ref_id)
        { 
            string query = @"
UPDATE      MUL_EST_TARGET_POOL
    SET     SELECT_YN       =   @SELECT_YN
          , UPDATE_USER     =   @UPDATE_USER
          , UPDATE_DATE     =   GETDATE()
    WHERE      COMP_ID         =   @COMP_ID
        AND    EST_ID          =   @EST_ID
        AND    ESTTERM_REF_ID  =   @ESTTERM_REF_ID
        AND    ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
        AND    EST_EMP_ID      =   @EST_EMP_ID
        AND    TGT_EMP_ID      =   @TGT_EMP_ID
";

           
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = est_emp_id;
            paramArray[5]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;
            paramArray[6]       = CreateDataParameter("@SELECT_YN", SqlDbType.NChar);
            paramArray[6].Value = select_yn;
            paramArray[7]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[7].Value = update_user_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }
                                        
    }
}
