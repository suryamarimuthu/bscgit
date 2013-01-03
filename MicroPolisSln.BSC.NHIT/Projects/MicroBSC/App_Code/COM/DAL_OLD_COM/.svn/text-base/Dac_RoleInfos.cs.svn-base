using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class RoleInfos : DbAgentBase
    {
        public RoleInfos() 
        {
        
        }
        public DataSet GetNotMenuRoles(int menu_ref_id) 
        {
            string query = @"SELECT   ROLE_REF_ID
                                    , ROLE_NAME 
                                FROM COM_ROLE_INFO
                                    WHERE ROLE_REF_ID NOT IN (SELECT A.ROLE_REF_ID 
                                                                FROM  COM_ROLE_INFO     A
                                                                    , COM_ROLE_MENU_REL B 
                                                                WHERE   A.ROLE_REF_ID = B.ROLE_REF_ID 
                                                                    AND B.MENU_REF_ID = @MENU_REF_ID)
                                ORDER BY SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = menu_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "Data", null, paramArray, CommandType.Text);
            return ds;
        }
        public DataSet GetMenuRoles(int menu_ref_id)
        {
            string query = @"SELECT * 
                                FROM  COM_ROLE_INFO     A
                                    , COM_ROLE_MENU_REL B 
                                WHERE   A.ROLE_REF_ID = B.ROLE_REF_ID 
                                    AND B.MENU_REF_ID = @MENU_REF_ID
                                ORDER BY SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = menu_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "Data", null, paramArray, CommandType.Text);
            return ds;
        }
        public DataSet GetRoleMenu(int menu_ref_id) 
        {
            string query = @"SELECT * 
                                FROM  COM_ROLE_INFO     A
                                    , COM_ROLE_MENU_REL B 
                                WHERE   A.ROLE_REF_ID = B.ROLE_REF_ID 
                                    AND B.MENU_REF_ID = @MENU_REF_ID
                                ORDER BY SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = menu_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "Data", null, paramArray, CommandType.Text);
            return ds;
        }
        public bool AddRoleMenu(int role_ref_id, int menu_ref_id)
        {
            string query = "INSERT INTO COM_ROLE_MENU_REL(ROLE_REF_ID, MENU_REF_ID) VALUES(@ROLE_REF_ID, @MENU_REF_ID)";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = role_ref_id;
            paramArray[1]               = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = menu_ref_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RemoveRoleMenu(int role_ref_id, int menu_ref_id)
        {
            string query = "DELETE COM_ROLE_MENU_REL WHERE ROLE_REF_ID = @ROLE_REF_ID AND MENU_REF_ID = @MENU_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = role_ref_id;
            paramArray[1]               = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = menu_ref_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
