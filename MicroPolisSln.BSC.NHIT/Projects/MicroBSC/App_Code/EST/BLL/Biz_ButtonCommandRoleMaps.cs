using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_ButtonCommandRoleMaps
    {
        #region ============================== [Fields] ==============================
 
        private int 	_role_ref_id;
        private string 	_command_name;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_ButtonCommandRoleMaps _buttonCommandRoleMap = new Dac_ButtonCommandRoleMaps();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public int Role_Ref_ID
        {
	        get 
	        {
		        return _role_ref_id;
	        }
	        set
	        {
		        _role_ref_id = value;
	        }
        }
         
        public string Command_Name
        {
	        get 
	        {
		        return _command_name;
	        }
	        set
	        {
		        _command_name = ( value==null ? "" : value );
	        }
        }
         
        public DateTime Update_Date
        {
	        get 
	        {
		        return _update_date;
	        }
	        set
	        {
		        _update_date = value;
	        }
        }
         
        public int Update_User
        {
	        get 
	        {
		        return _update_user;
	        }
	        set
	        {
		        _update_user = value;
	        }
        }

        #endregion
         
        public Biz_ButtonCommandRoleMaps()
	    {
		    
	    }

        public Biz_ButtonCommandRoleMaps(int role_ref_id, string command_name)
	    {
            DataSet ds = _buttonCommandRoleMap.Select(role_ref_id
                                                    , command_name);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _role_ref_id    = (dr["ROLE_REF_ID"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["ROLE_REF_ID"]);
		        _command_name   = (dr["COMMAND_NAME"]  == DBNull.Value) ? "" : (string) dr["COMMAND_NAME"];
		        _update_date    = (dr["UPDATE_DATE"]   == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyButtonCommandRoleMap(   int role_ref_id
                                                , string command_name
                                                , DateTime update_date
                                                , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _buttonCommandRoleMap.Update(   null
                                                        , null
                                                        , role_ref_id
                                                        , command_name
                                                        , update_date
                                                        , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetButtonCommandRoleMap( int role_ref_id, string command_name)
        {
	        return _buttonCommandRoleMap.Select(  role_ref_id
                                                , command_name);
        }

        public DataSet GetButtonCommandsByEmpID( int emp_ref_id)
        {
	        return _buttonCommandRoleMap.SelectByEmpID(emp_ref_id, 0, "", "");
        }
         
        public bool AddButtonCommandRoleMap(  int role_ref_id
                                            , string command_name
                                            , DateTime create_date
                                            , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _buttonCommandRoleMap.Insert(   null
                                                        , null
                                                        , role_ref_id
                                                        , command_name
                                                        , create_date
                                                        , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool SaveButtonCommandRoleMap(DataTable dataTable, int role_ref_id)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _buttonCommandRoleMap.Delete(  conn
                                                            , trx
                                                            , role_ref_id
                                                            , "");

                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _buttonCommandRoleMap.Insert(  conn
                                                                , trx
                                                                , DataTypeUtility.GetToInt32(dataRow["ROLE_REF_ID"])
                                                                , DataTypeUtility.GetValue(dataRow["COMMAND_NAME"])
                                                                , DataTypeUtility.GetToDateTime(dataRow["DATE"])
                                                                , DataTypeUtility.GetToInt32(dataRow["USER"]));
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveButtonCommandRoleMap( int role_ref_id, string command_name)
        {
	        int affectedRow = 0;

            affectedRow = _buttonCommandRoleMap.Delete(   null
                                                        , null
                                                        , role_ref_id
                                                        , command_name);

            return (affectedRow > 0) ? true : false;
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ROLE_REF_ID", typeof(int));
            dataTable.Columns.Add("COMMAND_NAME", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }
    }
}
