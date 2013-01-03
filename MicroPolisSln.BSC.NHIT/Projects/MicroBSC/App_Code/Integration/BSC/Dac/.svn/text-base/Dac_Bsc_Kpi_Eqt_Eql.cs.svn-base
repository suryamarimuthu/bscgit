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

namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Eqt_Eql : DbAgentBase
    {
        public Dac_Bsc_Kpi_Eqt_Eql()
        { }

        public DataTable Select_DB_Join_Kpi_Info(object estterm_ref_id
                                                , object est_type
                                                , object dept_ref_id
                                                , object champion_emp_ref_id
                                                , object is_team_kpi_yn
                                                , object kpi_code
                                                , object kpi_name)
        {
            string query = @"
SELECT      KI.KPI_REF_ID
            , KI.KPI_CODE
            , KP.KPI_NAME
            , KP.KPI_DESC
            , KI.CHAMPION_EMP_ID
            , EMP.EMP_NAME
            , DEPT.DEPT_NAME
            , RATIO.EQT
            , RATIO.EQL
            , CASE WHEN     IS_TEAM_KPI='Y'     THEN    '조직KPI'
                                                ELSE    '개인KPI'  END     AS  IS_TEAM_KPI
    FROM                    BSC_KPI_INFO    KI
        LEFT OUTER JOIN     BSC_KPI_POOL    KP
            ON      KI.KPI_POOL_REF_ID  =   KP.KPI_POOL_REF_ID
        LEFT OUTER JOIN     BSC_KPI_EQT_EQL RATIO
            ON  (
                    KI.KPI_REF_ID       =   RATIO.KPI_REF_ID
                AND KI.ESTTERM_REF_ID   =   RATIO.ESTTERM_REF_ID
                )
        LEFT OUTER JOIN     COM_EMP_INFO    EMP
            ON      KI.CHAMPION_EMP_ID  =   EMP.EMP_REF_ID
        LEFT OUTER JOIN     REL_DEPT_EMP    REL
            ON      EMP.EMP_REF_ID      =   REL.EMP_REF_ID
        LEFT OUTER JOIN     COM_DEPT_INFO   DEPT
            ON      DEPT.DEPT_REF_ID    =   REL.DEPT_REF_ID
    WHERE
            (  KI.ESTTERM_REF_ID   =       @ESTTERM_REF_ID     OR  @ESTTERM_REF_ID  = 0  )
        AND (  KP.BASIS_USE_YN     =       @EST_TYPE           OR  @EST_TYPE        =''  )
        AND (  DEPT.DEPT_REF_ID    =       @DEPT_REF_ID        OR  @DEPT_REF_ID     = 0  )
        AND (  EMP.EMP_REF_ID      =       @EMP_REF_ID         OR  @EMP_REF_ID      = 0  )
        AND (  KI.IS_TEAM_KPI      =       @IS_TEAM_KPI_YN     OR  @IS_TEAM_KPI_YN  =''  )
        AND KI.KPI_CODE            LIKE    @KPI_CODE
        AND KP.KPI_NAME            LIKE    @KPI_NAME        
";


            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_TYPE", SqlDbType.NVarChar);
            paramArray[1].Value = est_type;
            paramArray[2] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[3].Value = champion_emp_ref_id;
            paramArray[4] = CreateDataParameter("@IS_TEAM_KPI_YN", SqlDbType.NChar);
            paramArray[4].Value = is_team_kpi_yn;
            paramArray[5] = CreateDataParameter("@KPI_CODE", SqlDbType.NVarChar);
            paramArray[5].Value = "%" + kpi_code + "%";
            paramArray[6] = CreateDataParameter("@KPI_NAME", SqlDbType.NVarChar);
            paramArray[6].Value = "%" + kpi_name + "%";


            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }


        public int Delete_Bsc_Kpi_Eqt_Eql(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object kpi_ref_id)
        {


            string query = @"
DELETE FROM BSC_KPI_EQT_EQL
    WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID      = @KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int Delete_Bsc_Kpi_Eqt_Eql_Bulk(IDbConnection conn
                                            , IDbTransaction trx
                                            , object estterm_ref_id
                                            , object kpi_ref_id_list)
        {


            string query = string.Format(@"
DELETE FROM BSC_KPI_EQT_EQL
    WHERE   ESTTERM_REF_ID  =   @ESTTERM_REF_ID
        AND KPI_REF_ID      IN  ({0})
", kpi_ref_id_list);


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        public int Insert_Bsc_Kpi_Eqt_Eql(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object kpi_ref_id
                                        , object eqt
                                        , object eql
                                        , object create_user_ref_id)
        {
            string query = @"
INSERT INTO BSC_KPI_EQT_EQL
    (
        ESTTERM_REF_ID
        , KPI_REF_ID
        , EQT
        , EQL
        , CREATE_USER
    )
    VALUES
    (
        @ESTTERM_REF_ID
        , @KPI_REF_ID
        , @EQT
        , @EQL
        , @CREATE_USER
    )
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@EQT", SqlDbType.Int);
            paramArray[2].Value = eqt;
            paramArray[3] = CreateDataParameter("@EQL", SqlDbType.Int);
            paramArray[3].Value = eql;
            paramArray[4] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[4].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        public int Insert_Bsc_Kpi_Eqt_Eql_Bulk(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object kpi_ref_id_list
                                        , object eqtValue
                                        , object eqlValue
                                        , object create_user_ref_id)
        {
            string query = string.Format(@"
INSERT INTO BSC_KPI_EQT_EQL
    (
        ESTTERM_REF_ID
        , KPI_REF_ID
        , EQT
        , EQL
        , CREATE_USER
    )
    SELECT
            ESTTERM_REF_ID
            , KPI_REF_ID
            , @EQT
            , @EQL
            , @CREATE_USER
        FROM
            BSC_KPI_INFO
        WHERE
                ESTTERM_REF_ID  =   @ESTTERM_REF_ID
            AND KPI_REF_ID      IN  ({0})
", kpi_ref_id_list);

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EQT", SqlDbType.Int);
            paramArray[1].Value = eqtValue;
            paramArray[2] = CreateDataParameter("@EQL", SqlDbType.Int);
            paramArray[2].Value = eqlValue;
            paramArray[3] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }
    }
}
