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
    public class Dac_Mul_Est_Data : DbAgentBase
    {
        public string EST_ID;
        public Dac_Mul_Est_Data()
        {
            EST_ID = "3O";
        }


        /// <summary>
        /// 부서별 평가/미평가 현황, N:미평가, P:평가중, E:평가완료
        /// </summary>
        public DataTable Select_Est_Stat_GroupByDept(object est_id
                                                    , object estterm_ref_id
                                                    , object estterm_sub_id)
        {
            string query = @"
SELECT  DEPT.DEPT_REF_ID    AS  TGT_DEPT_ID
        , DEPT.DEPT_NAME    AS  TGT_DEPT_NAME
        , SUM(CASE WHEN     ED.EST_ID IS NOT NULL   THEN    1   ELSE    0   END)    AS  TOTAL_EST_CNT
        , SUM(CASE WHEN     ED.STATUS_ID='N'        THEN    1   ELSE    0   END)    AS  STATUS_N_CNT
        , SUM(CASE WHEN     ED.STATUS_ID='P'        THEN    1   ELSE    0   END)    AS  STATUS_P_CNT
        , SUM(CASE WHEN     ED.STATUS_ID='E'        THEN    1   ELSE    0   END)    AS  STATUS_E_CNT

    FROM                    COM_DEPT_INFO   DEPT
        LEFT OUTER JOIN     (

                                SELECT      EST_ID, TGT_DEPT_ID, TGT_EMP_ID, STATUS_ID
                                    FROM    EST_DATA
                                    WHERE   EST_ID          =   @EST_ID
                                        AND ESTTERM_REF_ID  =   @ESTTERM_REF_ID
                                        AND ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
                                        AND ESTTERM_STEP_ID <>   1

                            )               ED     
            ON  DEPT.DEPT_REF_ID    =   ED.TGT_DEPT_ID

    GROUP BY    DEPT.DEPT_REF_ID
                , DEPT.DEPT_NAME

    ORDER BY    DEPT.DEPT_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[0].Value = est_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_STAT_DEPT", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        /// <summary>
        /// 피평가자별 평가/미평가 현황, N:미평가, P:평가중, E:평가완료
        /// </summary>
        public DataTable Select_Est_Stat_GroupByEmp(object est_id
                                                    , object estterm_ref_id
                                                    , object estterm_sub_id
                                                    , object tgt_dept_id)
        {
            string query = @"
SELECT  TGT_DEPT_ID, TGT_DEPT_NAME, TGT_EMP_ID, TGT_EMP_NAME
        , TOTAL_EST_CNT, STATUS_N_CNT, STATUS_P_CNT, STATUS_E_CNT
    FROM
        (
        SELECT  DEPT.DEPT_REF_ID    AS  TGT_DEPT_ID
                , DEPT.DEPT_NAME    AS  TGT_DEPT_NAME
                , CASE WHEN     EMP.EMP_REF_ID IS NULL  THEN    ED.TGT_EMP_ID
                                                        ELSE    EMP.EMP_REF_ID      END     AS  TGT_EMP_ID
                , CASE WHEN     EMP.EMP_NAME IS NULL    THEN    CAST(ED.TGT_EMP_ID AS varchar(100))
                                                        ELSE    EMP.EMP_NAME        END     AS  TGT_EMP_NAME
                , SUM(CASE WHEN     ED.EST_ID IS NOT NULL   THEN    1   ELSE    0   END)    AS  TOTAL_EST_CNT
                , SUM(CASE WHEN     ED.STATUS_ID='N'        THEN    1   ELSE    0   END)    AS  STATUS_N_CNT
                , SUM(CASE WHEN     ED.STATUS_ID='P'        THEN    1   ELSE    0   END)    AS  STATUS_P_CNT
                , SUM(CASE WHEN     ED.STATUS_ID='E'        THEN    1   ELSE    0   END)    AS  STATUS_E_CNT

            FROM                    COM_EMP_INFO    EMP
                FULL OUTER JOIN     (

                                        SELECT      EST_ID, TGT_DEPT_ID, TGT_EMP_ID, STATUS_ID
                                            FROM    EST_DATA
                                            WHERE   EST_ID          =   @EST_ID
                                                AND ESTTERM_REF_ID  =   @ESTTERM_REF_ID
                                                AND ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
                                                AND ESTTERM_STEP_ID <>  1
                                    )               ED
                    ON  EMP.EMP_REF_ID      =   ED.TGT_EMP_ID
                LEFT OUTER JOIN     COM_DEPT_INFO   DEPT
                    ON  ED.TGT_DEPT_ID      =   DEPT.DEPT_REF_ID                

            WHERE       DEPT.DEPT_REF_ID        =   @TGT_DEPT_ID

            GROUP BY    DEPT.DEPT_REF_ID
                        , DEPT.DEPT_NAME
                        , CASE WHEN     EMP.EMP_REF_ID IS NULL  THEN    ED.TGT_EMP_ID
                                                        ELSE    EMP.EMP_REF_ID      END
                        , CASE WHEN     EMP.EMP_NAME IS NULL    THEN    CAST(ED.TGT_EMP_ID AS varchar(100))
                                                        ELSE    EMP.EMP_NAME    END
        )

    ORDER BY    TGT_EMP_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[0].Value = est_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[3].Value = tgt_dept_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_STAT_EMP", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        /// <summary>
        /// 피평가자의 평가자 리스트
        /// </summary>
        public DataTable Select_Est_Emp_List(string tgt_dept_id, string tgt_emp_id)
        {
            string query = @"
SELECT EST.ESTTERM_STEP_NAME                            AS  EST_STEP_NAME
        , CASE  WHEN DEPT.DEPT_NAME IS NULL
                THEN CAST(ED.EST_DEPT_ID AS varchar(100))
                ELSE DEPT.DEPT_NAME
            END                                         AS  EST_DEPT_NAME
        , CASE  WHEN EMP.EMP_NAME IS NULL
                THEN CAST(ED.EST_EMP_ID AS varchar(100))
                ELSE EMP.EMP_NAME
            END                                         AS  EST_EMP_NAME
        , ED.POINT                                      AS  EST_POINT
    FROM                    EST_DATA        ED
        LEFT OUTER JOIN     EST_TERM_STEP   EST
            ON      ED.ESTTERM_STEP_ID      =   EST.ESTTERM_STEP_ID
        LEFT OUTER JOIN     COM_DEPT_INFO   DEPT
            ON      ED.EST_DEPT_ID          =   DEPT.DEPT_REF_ID
        LEFT OUTER JOIN     COM_EMP_INFO    EMP
            ON      ED.EST_EMP_ID           =   EMP.EMP_REF_ID
    WHERE   ED.TGT_DEPT_ID  =   @TGT_DEPT_ID
        AND ED.TGT_EMP_ID   =   @TGT_EMP_ID
        AND ED.EST_ID       =   @EST_ID
        AND ED.ESTTERM_STEP_ID <> 1
";


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.NVarChar);
            paramArray[0].Value = tgt_dept_id;
            paramArray[1] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[1].Value = tgt_emp_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.Int);
            paramArray[2].Value = EST_ID;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_EMP_LIST", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        
        /// <summary>
        /// 피평가자 부서, 이름, 평균 점수
        /// </summary>
        public DataTable Select_Est_Emp_Info(string tgt_dept_id, string tgt_emp_id)
        {
            string Result;
            string query = @"
SELECT      CASE WHEN   EMP.EMP_NAME IS NULL    THEN    CAST(ED.TGT_EMP_ID AS varchar(100))
                                                ELSE    EMP.EMP_NAME    END     AS  TGT_EMP_NAME
            , DEPT.DEPT_NAME                                                    AS  TGT_DEPT_NAME
            , ROUND(  AVG(    CAST(POINT AS float)    ), 1)                     AS  AVG_POINT

    FROM    EST_DATA        ED
        LEFT OUTER JOIN     COM_DEPT_INFO   DEPT
            ON              ED.TGT_DEPT_ID      =   DEPT.DEPT_REF_ID
        LEFT OUTER JOIN     COM_EMP_INFO    EMP
            ON              ED.TGT_EMP_ID       =   EMP.EMP_REF_ID

    WHERE
            ED.TGT_DEPT_ID     =   @TGT_DEPT_ID
        AND ED.TGT_EMP_ID      =   @TGT_EMP_id
        AND ED.EST_ID          =   @EST_ID
    GROUP BY
            CASE WHEN   EMP.EMP_NAME IS NULL    THEN    CAST(ED.TGT_EMP_ID AS varchar(100))
                                                ELSE    EMP.EMP_NAME    END
            , DEPT.DEPT_NAME
";


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.NVarChar);
            paramArray[0].Value = tgt_dept_id;
            paramArray[1] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[1].Value = tgt_emp_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.Int);
            paramArray[2].Value = EST_ID;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_AVG", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }




        public int Insert_Sum_Point(IDbConnection conn, IDbTransaction trx
                                    , object admin_dept_ref_id
                                    , object admin_emp_ref_id
                                    , object comp_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object tgt_dept_id
                                    , object tgt_emp_id)
        {
            string query = @"
INSERT INTO     EST_DATA
    (
        COMP_ID
        , EST_ID
        , ESTTERM_REF_ID
        , ESTTERM_SUB_ID
        , ESTTERM_STEP_ID
        , EST_DEPT_ID
        , EST_EMP_ID
        , TGT_DEPT_ID
        , TGT_EMP_ID
        , TGT_POS_CLS_ID
        , TGT_POS_CLS_NAME
        , TGT_POS_DUT_ID
        , TGT_POS_DUT_NAME
        , TGT_POS_GRP_ID
        , TGT_POS_GRP_NAME
        , TGT_POS_RNK_ID
        , TGT_POS_RNK_NAME
        , TGT_POS_KND_ID
        , TGT_POS_KND_NAME
        , DIRECTION_TYPE
        , POINT_ORG
        , POINT_AVG
        , POINT_STD
        , POINT_CTRL_ORG
        , POINT
        , STATUS_ID
        , CREATE_USER
        , CREATE_DATE
        , UPDATE_USER
        , UPDATE_DATE
    )
    (
    SELECT
        COMP_ID
        , EST_ID
        , ESTTERM_REF_ID
        , ESTTERM_SUB_ID
        , @ESTTERM_STEP_ID
        , @ADMIN_DEPT_REF_ID     --EST_DEPT_ID
        , @ADMIN_EMP_REF_ID     --EST_EMP_ID
        , TGT_DEPT_ID
        , TGT_EMP_ID
        , TGT_POS_CLS_ID
        , TGT_POS_CLS_NAME
        , TGT_POS_DUT_ID
        , TGT_POS_DUT_NAME
        , TGT_POS_GRP_ID
        , TGT_POS_GRP_NAME
        , TGT_POS_RNK_ID
        , TGT_POS_RNK_NAME
        , TGT_POS_KND_ID
        , TGT_POS_KND_NAME
        , DIRECTION_TYPE
        , AVG(POINT_ORG)        AS  POINT_ORG
        , AVG(POINT_AVG)        AS  POINT_AVG
        , AVG(POINT_STD)        AS  POINT_STD
        , AVG(POINT_CTRL_ORG)   AS  POINT_CTRL_ORG
        , AVG(POINT) AS POINT
        , 'E'
        , @ADMIN_EMP_REF_ID
        , GETDATE()
        , @ADMIN_EMP_REF_ID
        , GETDATE()
        FROM    EST_DATA
        WHERE   EST_ID          =   @EST_ID
            AND COMP_ID         =   @COMP_ID
            AND ESTTERM_REF_ID  =   @ESTTERM_REF_ID
            AND ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
            AND (TGT_DEPT_ID    =   @TGT_DEPT_ID    OR  @TGT_DEPT_ID    =   0)
            AND (TGT_EMP_ID     =   @TGT_EMP_ID     OR  @TGT_EMP_ID     =   0)
        GROUP BY 
            COMP_ID
            , EST_ID
            , ESTTERM_REF_ID
            , ESTTERM_SUB_ID
            , ESTTERM_STEP_ID
            , TGT_DEPT_ID
            , TGT_EMP_ID
            , TGT_POS_CLS_ID
            , TGT_POS_CLS_NAME
            , TGT_POS_DUT_ID
            , TGT_POS_DUT_NAME
            , TGT_POS_GRP_ID
            , TGT_POS_GRP_NAME
            , TGT_POS_RNK_ID
            , TGT_POS_RNK_NAME
            , TGT_POS_KND_ID
            , TGT_POS_KND_NAME
            , DIRECTION_TYPE
    )
";


            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@ADMIN_EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = admin_emp_ref_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[2].Value = comp_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_sub_id;
            paramArray[5] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5].Value = 1;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8] = CreateDataParameter("@ADMIN_DEPT_REF_ID", SqlDbType.Int);
            paramArray[8].Value = admin_dept_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }
    }
}
