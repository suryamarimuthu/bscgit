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
    public class Dac_Pms_Com_Info : DbAgentBase
    {
        public Dac_Pms_Com_Info()
        {
        }


        public int Insert_Pms_Com_Info(IDbConnection conn
                                        , IDbTransaction trx
                                        , object IDX
                                        , object IF_COL_ID
                                        , object IF_COL_NAME
                                        , object CUSTOM_COL_ID
                                        , object CUSTOM_COL_NAME
                                        , object SOOSIK
                                        , object soosik_desc
                                        , object USER_REF_ID)
        {
            string query = @"
INSERT INTO     PMS_COM_INFO
    (
        IDX
        , IF_COL_ID
        , IF_COL_NAME
        , CUSTOM_COL_ID
        , CUSTOM_COL_NAME
        , SOOSIK
        , SOOSIK_DESC
        , CREATE_USER
    )
    VALUES
    (
        @IDX
        , @IF_COL_ID
        , @IF_COL_NAME
        , @CUSTOM_COL_ID
        , @CUSTOM_COL_NAME
        , @SOOSIK
        , @SOOSIK_DESC
        , @USER_REF_ID
    )
";



            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@IDX", SqlDbType.Int);
            paramArray[0].Value = IDX;
            paramArray[1] = CreateDataParameter("@IF_COL_ID", SqlDbType.NVarChar);
            paramArray[1].Value = IF_COL_ID;
            paramArray[2] = CreateDataParameter("@IF_COL_NAME", SqlDbType.NVarChar);
            paramArray[2].Value = IF_COL_NAME;
            paramArray[3] = CreateDataParameter("@CUSTOM_COL_ID", SqlDbType.NVarChar);
            paramArray[3].Value = CUSTOM_COL_ID;
            paramArray[4] = CreateDataParameter("@CUSTOM_COL_NAME", SqlDbType.NVarChar);
            paramArray[4].Value = CUSTOM_COL_NAME;
            paramArray[5] = CreateDataParameter("@SOOSIK", SqlDbType.NVarChar);
            paramArray[5].Value = SOOSIK;
            paramArray[6] = CreateDataParameter("@SOOSIK_DESC", SqlDbType.NVarChar);
            paramArray[6].Value = soosik_desc;
            paramArray[7] = CreateDataParameter("@USER_REF_ID", SqlDbType.Int);
            paramArray[7].Value = USER_REF_ID;



            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }




        public int Update_Pms_Com_Info(IDbConnection conn
                                        , IDbTransaction trx
                                        , object IDX
                                        , object IF_COL_ID
                                        , object IF_COL_NAME
                                        , object CUSTOM_COL_ID
                                        , object CUSTOM_COL_NAME
                                        , object SOOSIK
                                        , object soosik_desc
                                        , object USER_REF_ID)
        {
            string query = @"
UPDATE      PMS_COM_INFO
    SET
            IF_COL_ID           = @IF_COL_ID
            , IF_COL_NAME       = @IF_COL_NAME
            , CUSTOM_COL_ID     = @CUSTOM_COL_ID
            , CUSTOM_COL_NAME   = @CUSTOM_COL_NAME
            , SOOSIK            = @SOOSIK
            , SOOSIK_DESC       = @SOOSIK_DESC
            , UPDATE_USER       = @USER_REF_ID
            , UPDATE_DATE       = GETDATE()
    WHERE   IDX     =   @IDX
";



            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@IDX", SqlDbType.Int);
            paramArray[0].Value = IDX;
            paramArray[1] = CreateDataParameter("@IF_COL_ID", SqlDbType.NVarChar);
            paramArray[1].Value = IF_COL_ID;
            paramArray[2] = CreateDataParameter("@IF_COL_NAME", SqlDbType.NVarChar);
            paramArray[2].Value = IF_COL_NAME;
            paramArray[3] = CreateDataParameter("@CUSTOM_COL_ID", SqlDbType.NVarChar);
            paramArray[3].Value = CUSTOM_COL_ID;
            paramArray[4] = CreateDataParameter("@CUSTOM_COL_NAME", SqlDbType.NVarChar);
            paramArray[4].Value = CUSTOM_COL_NAME;
            paramArray[5] = CreateDataParameter("@SOOSIK", SqlDbType.NVarChar);
            paramArray[5].Value = SOOSIK;
            paramArray[6] = CreateDataParameter("@SOOSIK_DESC", SqlDbType.NVarChar);
            paramArray[6].Value = soosik_desc;
            paramArray[7] = CreateDataParameter("@USER_REF_ID", SqlDbType.Int);
            paramArray[7].Value = USER_REF_ID;



            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }




        public DataTable Select_Pms_Com_Info(object IDX)
        {
            string query = @"
SELECT      IF_COL_ID
            , IF_COL_NAME
            , CUSTOM_COL_ID
            , CUSTOM_COL_NAME
            , SOOSIK
            , SOOSIK_DESC
    FROM
            PMS_COM_INFO
    WHERE
            (   IDX     =   @IDX    OR  @IDX    =   0   )
";



            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@IDX", SqlDbType.Int);
            paramArray[0].Value = IDX;


            DataTable DT = DbAgentObj.FillDataSet(query, "PMS_COM_INFO", null, paramArray, CommandType.Text).Tables[0];

            return DT;
        }



        public int Select_NewIdx_Pms_Com_Info(IDbConnection conn
                                            , IDbTransaction trx)
        {
            string query = @"
SELECT
        CASE    WHEN    MAX(IDX)    IS NULL THEN    1
                                            ELSE    MAX(IDX)+1  END     AS  NEW_IDX
    FROM    PMS_COM_INFO
";

            object Result = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);

            return DataTypeUtility.GetToInt32(Result);
        }
    }
}
