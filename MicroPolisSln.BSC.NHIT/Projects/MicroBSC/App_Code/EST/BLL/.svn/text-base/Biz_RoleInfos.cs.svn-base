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
    public class Biz_RoleInfos
    {
        #region ============================== [Fields] ==============================
 
        private int 	_role_ref_id;
        private string 	_role_name;
        private string 	_role_desc;
        private string  _sys_type;
        private int     _sort_order;
        private string  _delete_enabled_yn;

        private Dac_RoleInfos _roleInfo = new Dac_RoleInfos();

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
         
        public string Role_Name
        {
	        get 
	        {
		        return _role_name;
	        }
	        set
	        {
		        _role_name = ( value==null ? "" : value );
	        }
        }
         
        public string Role_Desc
        {
	        get 
	        {
		        return _role_desc;
	        }
	        set
	        {
		        _role_desc = ( value==null ? "" : value );
	        }
        }

        public string Sys_Type
        {
	        get 
	        {
                return _sys_type;
	        }
	        set
	        {
                _sys_type = (value == null ? "" : value);
	        }
        }

        public int Sort_Order
        {
            get
            {
                return _sort_order;
            }
            set
            {
                _sort_order = value;
            }
        }

        public string Delete_Enabled_YN
        {
            get
            {
                return _delete_enabled_yn;
            }
            set
            {
                _delete_enabled_yn = (value == null ? "" : value);
            }
        }

        #endregion
         
        public Biz_RoleInfos()
	    {
		    
	    }

        public Biz_RoleInfos(int role_ref_id)
	    {
            DataSet ds = _roleInfo.Select(role_ref_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];

		        _role_ref_id        = DataTypeUtility.GetToInt32(dr["ROLE_REF_ID"]);
		        _role_name          = DataTypeUtility.GetValue(dr["ROLE_NAME"]);
		        _role_desc          = DataTypeUtility.GetValue(dr["ROLE_DESC"]);
                _sys_type           = DataTypeUtility.GetValue(dr["SYS_TYPE"]);
                _sort_order         = DataTypeUtility.GetToInt32(dr["SORT_ORDER"]);
                _delete_enabled_yn  = DataTypeUtility.GetValue(dr["DELETE_ENABLED_YN"]);

	        }
	    }
         
        public bool ModifyRoleInfo(int   role_ref_id
                                , string role_name
                                , string role_desc
                                , string sys_type
                                , int    sort_order
                                , string delete_enabled_yn)
        {
	        int affectedRow = 0;

            affectedRow = _roleInfo.Update(null
                                        , null
                                        , role_ref_id
                                        , role_name
                                        , role_desc
                                        , sys_type
                                        , sort_order
                                        , delete_enabled_yn);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetRoleInfos()
        {
            return _roleInfo.Select(0);
        }
         
        public DataSet GetRoleInfo( int role_ref_id)
        {
            return _roleInfo.Select(role_ref_id);
        }
         
        public bool AddRoleInfo(  string role_name
                                , string role_desc
                                , string sys_type
                                , int    sort_order
                                , string delete_enabled_yn)
        {
	        int affectedRow = 0;

            affectedRow = _roleInfo.Insert(null
                                        , null
                                        , role_name
                                        , role_desc
                                        , sys_type
                                        , sort_order
                                        , delete_enabled_yn);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveRoleInfo( int role_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _roleInfo.Delete(null
                                        , null
                                        , role_ref_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveRoleInfo(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            Dac_RoleMenuRels _roleMenuRel = new Dac_RoleMenuRels();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _roleInfo.Delete(conn
                                                        , trx
                                                        , DataTypeUtility.GetToInt32(dataRow["ROLE_REF_ID"]));

                    affectedRow += _roleMenuRel.Delete(conn
                                                        , trx
                                                        , DataTypeUtility.GetToInt32(dataRow["ROLE_REF_ID"])
                                                        , 0);
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

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ROLE_REF_ID", typeof(int));
            dataTable.Columns.Add("ROLE_NAME", typeof(string));
            dataTable.Columns.Add("ROLE_DESC", typeof(string));
            dataTable.Columns.Add("SORT_ORDER", typeof(int));
            dataTable.Columns.Add("DELETE_ENABLED_YN", typeof(string));

            return dataTable;
        }
    }
}
