using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Com_Emp_Role_Rel : DbAgentBase
    {
        public Dac_Com_Emp_Role_Rel()
        {

        }


        public int Insert_DB(IDbConnection conn, IDbTransaction trx
                            , object emp_ref_id
                            , object role_ref_id)
        {
            string query = @"
INSERT INTO     COM_EMP_ROLE_REL
            (
                EMP_REF_ID
                , ROLE_REF_ID
            )
    VALUES
            (
                @EMP_REF_ID
                , @ROLE_REF_ID
            )
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = role_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
            return affectedRow;
        }


        public int Delete_DB(IDbConnection conn, IDbTransaction trx
                            , object emp_ref_id
                            , object role_ref_id)
        {
            string query = @"
DELETE FROM     COM_EMP_ROLE_REL
    WHERE       EMP_REF_ID      =   @EMP_REF_ID
        AND     ROLE_REF_ID     =   @ROLE_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = role_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
            return affectedRow;
        }



        public int Select_Cnt_EmpRole(object emp_ref_id, object role_ref_id)
        {
            string query = @"
SELECT      COUNT(*)
    FROM    COM_EMP_ROLE_REL
    WHERE   EMP_REF_ID  =   @EMP_REF_ID
        AND ROLE_REF_ID =   @ROLE_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = role_ref_id;

            object result = DbAgentObj.ExecuteScalar(query, paramArray);

            return DataTypeUtility.GetToInt32(result);
        }



        public DataTable Select_EmpRoleRel(object emp_ref_id, object role_ref_id)
        {
            string query = @"
SELECT      REL.EMP_REF_ID
            , ROLE.ROLE_REF_ID
            , ROLE.ROLE_NAME
            , ROLE.SYS_TYPE
    FROM                COM_EMP_ROLE_REL    REL
        LEFT OUTER JOIN COM_ROLE_INFO       ROLE
    WHERE   (  REL.EMP_REF_ID   =   @EMP_REF_ID     OR  @EMP_REF_ID     =   0  )
        AND (  ROLE.ROLE_REF_ID =   @ROLE_REF_ID    OR  @ROLE_REF_ID    =   0  )
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = role_ref_id;

            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }
    }
}
