using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Com_Dept_Info : DbAgentBase
    {
        public Dac_Com_Dept_Info()
        {

        }


        public DataTable SelectRoot_DB()
        {
            DataSet DS = new DataSet();
            string query = @"

SELECT  DEPT_REF_ID  
FROM    COM_DEPT_INFO
WHERE   ISNULL(UP_DEPT_ID, 0) = 0
  AND   DEPT_FLAG = 1

";

            DS = DbAgentObj.Fill(query, null);

            return DS.Tables[0];
        }


        
        public string Select_DEPT_REF_ID(string DEPT_CODE)
        {
            DataSet DS = new DataSet();
            string query = @"
SELECT  DEPT_REF_ID
    FROM        COM_DEPT_INFO
    WHERE       DEPT_CODE   =   @DEPT_CODE
    ORDER BY    UPDATE_DATE DESC";



            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@DEPT_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = DEPT_CODE;



            DS = DbAgentObj.Fill(query, paramArray);

            return DS.Tables[0].Rows[0][0].ToString();
        }





        public string Select_DEPT_REF_ID(IDbConnection conn, IDbTransaction trx, string DEPT_CODE)
        {
            DataSet DS = new DataSet();

            string query = @"
SELECT  DEPT_REF_ID
    FROM        COM_DEPT_INFO
    WHERE       DEPT_CODE   =   @DEPT_CODE
    ORDER BY    UPDATE_DATE DESC";



            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@DEPT_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = DEPT_CODE;



            DS = DbAgentObj.FillDataSet(conn, trx, query, "DEPT_REF_ID", DS, paramArray, CommandType.Text);

            return DS.Tables[0].Rows[0][0].ToString();
        }



        public int Insert_DeptInfo(IDbConnection conn
                                    , IDbTransaction trx
                                    , object DEPT_REF_ID
                                    , object UP_DEPT_ID
                                    , object DEPT_LEVEL
                                    , object DEPT_NAME
                                    , object DEPT_CODE
                                    , object DEPT_FLAG
                                    , object DEPT_TYPE
                                    , object SORT_ORDER
                                    , object DEPT_DESC
                                    , object CREATE_USER
                                    , object UPDATE_USER)
        {
            string query = @"
INSERT INTO COM_DEPT_INFO
    (
        DEPT_REF_ID
        , UP_DEPT_ID
        , DEPT_LEVEL
        , DEPT_NAME
        , DEPT_CODE
        , DEPT_FLAG
        , DEPT_TYPE
        , SORT_ORDER
        , DEPT_DESC
        , CREATE_USER
        , UPDATE_USER
    )
    VALUES
    (
        @DEPT_REF_ID
        , @UP_DEPT_ID
        , @DEPT_LEVEL
        , @DEPT_NAME
        , @DEPT_CODE
        , @DEPT_FLAG
        , @DEPT_TYPE
        , @SORT_ORDER
        , @DEPT_DESC
        , @CREATE_USER
        , @UPDATE_USER
    )
";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = DEPT_REF_ID;
            paramArray[1] = CreateDataParameter("@UP_DEPT_ID", SqlDbType.Int);
            paramArray[1].Value = UP_DEPT_ID;
            paramArray[2] = CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
            paramArray[2].Value = DEPT_LEVEL;
            paramArray[3] = CreateDataParameter("@DEPT_NAME", SqlDbType.NVarChar, 100);
            paramArray[3].Value = DEPT_NAME;
            paramArray[4] = CreateDataParameter("@DEPT_CODE", SqlDbType.NVarChar, 20);
            paramArray[4].Value = DEPT_CODE;
            paramArray[5] = CreateDataParameter("@DEPT_FLAG", SqlDbType.Int);
            paramArray[5].Value = DEPT_FLAG;
            paramArray[6] = CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
            paramArray[6].Value = DEPT_TYPE;
            paramArray[7] = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[7].Value = SORT_ORDER;
            paramArray[8] = CreateDataParameter("@DEPT_DESC", SqlDbType.NVarChar, 500);
            paramArray[8].Value = DEPT_DESC;
            paramArray[9] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[9].Value = CREATE_USER;
            paramArray[10] = CreateDataParameter("@UPDATE_USER", SqlDbType.NVarChar);
            paramArray[10].Value = UPDATE_USER;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public string SelectNextDeptID(IDbConnection conn, IDbTransaction trx)
        {
            object Result;
            string query = @"
SELECT  MAX(DEPT_REF_ID)+1
    FROM COM_DEPT_INFO";

            Result = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);

            return DataTypeUtility.GetString(Result);
        }


        public DataTable Select_DB(object dept_ref_id)
        {
            string query = @"
SELECT  DEPT_REF_ID
        , UP_DEPT_ID
        , DEPT_LEVEL
        , DEPT_NAME
        , DEPT_CODE
        , DEPT_FLAG
        , DEPT_TYPE
        , SORT_ORDER
        , DEPT_DESC
        , CREATE_USER
        , UPDATE_USER
    FROM    COM_DEPT_INFO
    WHERE   (  DEPT_REF_ID =   @DEPT_REF_ID     OR  @DEPT_REF_ID    =   0  )
";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = dept_ref_id;

            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }


        /// <summary>
        /// 부서와 상위부서
        /// </summary>
        public DataTable Select_Dept_UpDept()
        {
            string query = @"
SELECT      DEPT.DEPT_REF_ID        AS  DEPT_ID
            , DEPT.DEPT_NAME
            , DEPT.UP_DEPT_ID
            , UP_DEPT.DEPT_NAME     AS UP_DEPT_NAME
    FROM                    COM_DEPT_INFO DEPT
        LEFT OUTER JOIN     COM_DEPT_INFO UP_DEPT
            ON  DEPT.UP_DEPT_ID =   UP_DEPT.DEPT_REF_ID
    ORDER BY
            DEPT.SORT_ORDER
";

            DataTable dt = DbAgentObj.Fill(query).Tables[0];

            return dt;
        }
    }
}
