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

namespace MicroBSC.Integration.PMS.Dac
{
    public class Dac_Pms_Col_Info : DbAgentBase
    {
        public Dac_Pms_Col_Info()
        {
        }


        public int Select_Col_Info_Count(IDbConnection conn, IDbTransaction trx
                                        , object PRJ_ID, object PRJ_COL_ID)
        {
            string query = @"
SELECT  COUNT(*)
    FROM
            PMS_COL_INFO
    WHERE
            PRJ_ID              =   @PRJ_ID
        AND PRJ_COL_ID          =   @PRJ_COL_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;
            paramArray[1] = CreateDataParameter("@PRJ_COL_ID", SqlDbType.NVarChar);
            paramArray[1].Value = PRJ_COL_ID;

            object Result = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);

            return DataTypeUtility.GetToInt32(Result);
        }



        public DataTable Select_Col_Info_List(object PRJ_ID
                                            , object PRJ_COL_TYPE
                                            , object PRJ_COL_CUSTOM_YN)
        {
            string query = @"
SELECT  PRJ_COL_ID
        , PRJ_COL_NAME
        , PRJ_COL_VALUE
        , PRJ_COL_TYPE
        , PRJ_COL_CUSTOM_YN
        , PRJ_COL_WEIGHT
        , PRJ_COL_ORD
        , PRJ_COL_NOTE
        , PRJ_COL_VIEW
        , PRJ_COL_SOOSIK
        , PRJ_COL_EST_STATE
    FROM
            PMS_COL_INFO
    WHERE
                PRJ_ID              =   @PRJ_ID
        AND (   PRJ_COL_CUSTOM_YN   =   @PRJ_COL_CUSTOM_YN      OR  @PRJ_COL_CUSTOM_YN  =''   )
        AND (   PRJ_COL_TYPE        =   @PRJ_COL_TYPE           OR  @PRJ_COL_TYPE       =''   )
    ORDER BY
            PRJ_COL_ORD     ASC
";


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;
            paramArray[1] = CreateDataParameter("@PRJ_COL_CUSTOM_YN", SqlDbType.NChar);
            paramArray[1].Value = PRJ_COL_CUSTOM_YN;
            paramArray[2] = CreateDataParameter("@PRJ_COL_TYPE", SqlDbType.NVarChar);
            paramArray[2].Value = PRJ_COL_TYPE;

            DataTable dt = DbAgentObj.FillDataSet(query, "PMS_COL_INFO", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        public int Insert_Pms_Col_Info(IDbConnection conn
                                    , IDbTransaction trx
                                    , object PRJ_ID
                                    , object PRJ_COL_ID
                                    , object PRJ_COL_NAME
                                    , object PRJ_COL_TYPE
                                    , object PRJ_COL_CUSTOM_YN
                                    , object PRJ_COL_WEIGHT
                                    , object PRJ_COL_ORD
                                    , object PRJ_COL_VALUE
                                    , object PRJ_COL_NOTE
                                    , object PRJ_COL_VIEW
                                    , object PRJ_COL_SOOSIK
                                    , object PRJ_COL_EST_STATE
                                    , object USER_REF_ID)
        {
            string query = @"
INSERT INTO     PMS_COL_INFO
    (
        PRJ_ID
        , PRJ_COL_ID
        , PRJ_COL_NAME
        , PRJ_COL_VALUE
        , PRJ_COL_TYPE
        , PRJ_COL_CUSTOM_YN
        , PRJ_COL_WEIGHT
        , PRJ_COL_ORD
        , PRJ_COL_NOTE
        , PRJ_COL_VIEW
        , PRJ_COL_SOOSIK
        , PRJ_COL_EST_STATE
        , CREATE_USER
    )
    VALUES
    (
        @PRJ_ID
        , @PRJ_COL_ID
        , @PRJ_COL_NAME
        , @PRJ_COL_VALUE
        , @PRJ_COL_TYPE
        , @PRJ_COL_CUSTOM_YN
        , @PRJ_COL_WEIGHT
        , @PRJ_COL_ORD
        , @PRJ_COL_NOTE
        , @PRJ_COL_VIEW
        , @PRJ_COL_SOOSIK
        , @PRJ_COL_EST_STATE
        , @USER_REF_ID
    )
";


            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;
            paramArray[1] = CreateDataParameter("@PRJ_COL_ID", SqlDbType.NVarChar);
            paramArray[1].Value = PRJ_COL_ID;
            paramArray[2] = CreateDataParameter("@PRJ_COL_NAME", SqlDbType.NVarChar);
            paramArray[2].Value = PRJ_COL_NAME;
            paramArray[3] = CreateDataParameter("@PRJ_COL_VALUE", SqlDbType.NVarChar);
            paramArray[3].Value = PRJ_COL_VALUE;
            paramArray[4] = CreateDataParameter("@PRJ_COL_TYPE", SqlDbType.NVarChar);
            paramArray[4].Value = PRJ_COL_TYPE;
            paramArray[5] = CreateDataParameter("@PRJ_COL_CUSTOM_YN", SqlDbType.NChar);
            paramArray[5].Value = PRJ_COL_CUSTOM_YN;
            paramArray[6] = CreateDataParameter("@PRJ_COL_WEIGHT", SqlDbType.Float);
            paramArray[6].Value = PRJ_COL_WEIGHT;
            paramArray[7] = CreateDataParameter("@PRJ_COL_ORD", SqlDbType.Int);
            paramArray[7].Value = PRJ_COL_ORD;
            paramArray[8] = CreateDataParameter("@PRJ_COL_NOTE", SqlDbType.NVarChar);
            paramArray[8].Value = PRJ_COL_NOTE;
            paramArray[9] = CreateDataParameter("@PRJ_COL_VIEW", SqlDbType.NVarChar);
            paramArray[9].Value = PRJ_COL_VIEW;
            paramArray[10] = CreateDataParameter("@PRJ_COL_SOOSIK", SqlDbType.NVarChar);
            paramArray[10].Value = PRJ_COL_SOOSIK;
            paramArray[11] = CreateDataParameter("@PRJ_COL_EST_STATE", SqlDbType.NVarChar);
            paramArray[11].Value = PRJ_COL_EST_STATE;
            paramArray[12] = CreateDataParameter("@USER_REF_ID", SqlDbType.Int);
            paramArray[12].Value = USER_REF_ID;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        public int Update_Pms_Custom_Col_Value(IDbConnection conn
                                            , IDbTransaction trx
                                            , object PRJ_ID
                                            , object PRJ_COL_ID
                                            , object PRJ_COL_NAME
                                            , object PRJ_COL_VALUE
                                            , object USER_REF_ID)
        {
            string query = @"
UPDATE PMS_COL_INFO
    SET
        PRJ_COL_NAME        = @PRJ_COL_NAME
        , PRJ_COL_VALUE     = @PRJ_COL_VALUE
        , UPDATE_USER       = @USER_REF_ID
        , UPDATE_DATE       = GETDATE()
    WHERE
            PRJ_ID      =   @PRJ_ID
        AND PRJ_COL_ID  =   @PRJ_COL_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;
            paramArray[1] = CreateDataParameter("@PRJ_COL_ID", SqlDbType.NVarChar);
            paramArray[1].Value = PRJ_COL_ID;
            paramArray[2] = CreateDataParameter("@PRJ_COL_NAME", SqlDbType.NVarChar);
            paramArray[2].Value = PRJ_COL_NAME;
            paramArray[3] = CreateDataParameter("@PRJ_COL_VALUE", SqlDbType.NVarChar);
            paramArray[3].Value = PRJ_COL_VALUE;
            paramArray[4] = CreateDataParameter("@USER_REF_ID", SqlDbType.Int);
            paramArray[4].Value = USER_REF_ID;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }




        public int Update_Pms_Common_Soosik_Value(IDbConnection conn
                                            , IDbTransaction trx
                                            , object PRJ_ID
                                            , object PRJ_COL_VALUE
                                            , object USER_REF_ID)
        {
            string query = @"
UPDATE PMS_COL_INFO
    SET
        PRJ_COL_VALUE     = @PRJ_COL_VALUE
        , UPDATE_USER       = @USER_REF_ID
        , UPDATE_DATE       = GETDATE()
    WHERE
            PRJ_ID      =   @PRJ_ID
        AND PRJ_COL_ID  =   'SOOSIK_' + @PRJ_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;
            paramArray[1] = CreateDataParameter("@PRJ_COL_VALUE", SqlDbType.NVarChar);
            paramArray[1].Value = PRJ_COL_VALUE;
            paramArray[2] = CreateDataParameter("@USER_REF_ID", SqlDbType.Int);
            paramArray[2].Value = USER_REF_ID;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }




        public DataTable Select_Soosik(object PRJ_ID)
        {
            string query = @"
SELECT  PRJ_COL_ID
        , PRJ_COL_NAME
        , PRJ_COL_VALUE
        , PRJ_COL_TYPE
        , PRJ_COL_WEIGHT
        , PRJ_COL_ORD
        , PRJ_COL_NOTE
    FROM
            PMS_COL_INFO
    WHERE
            PRJ_ID  =   @PRJ_ID
        AND PRJ_COL_CUSTOM_YN='S'
        AND PRJ_COL_ID = ''SOOSIK_' + @PRJ_ID 
    ORDER BY
            PRJ_COL_ORD     ASC
";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;

            DataTable dt = DbAgentObj.FillDataSet(query, "SOOSIK", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        



        public int Delete_Pms_Col_Info(IDbConnection conn
                                    , IDbTransaction trx
                                    , object PRJ_ID
                                    , object PRJ_COL_ID)
        {
            string query = @"
DELETE
    FROM     PMS_COL_INFO
    WHERE       PRJ_ID     =   @PRJ_ID
        AND (   PRJ_COL_ID  =   @PRJ_COL_ID     OR  @PRJ_COL_ID     ='' )
";



            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;
            paramArray[1] = CreateDataParameter("@PRJ_COL_ID", SqlDbType.NVarChar);
            paramArray[1].Value = PRJ_COL_ID;



            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }
    }
}
