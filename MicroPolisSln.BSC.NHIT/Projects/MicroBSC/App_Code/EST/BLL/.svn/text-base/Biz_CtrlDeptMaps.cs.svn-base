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
    public class Biz_CtrlDeptMaps
    {
        #region ============================== [Fields] ==============================
 
        private string 	_ctrl_id;
        private int 	_dept_ref_id;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_CtrlDeptMaps _ctrlDeptMap = new Dac_CtrlDeptMaps();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Ctrl_ID
        {
	        get 
	        {
		        return _ctrl_id;
	        }
	        set
	        {
		        _ctrl_id = ( value==null ? "" : value );
	        }
        }
         
        public int dept_ref_id
        {
	        get 
	        {
		        return _dept_ref_id;
	        }
	        set
	        {
		        _dept_ref_id = value;
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
         
        public Biz_CtrlDeptMaps()
        {
            
        }

        public Biz_CtrlDeptMaps(string ctrl_id, int dept_ref_id)
        {
            DataSet ds = _ctrlDeptMap.Select(ctrl_id, dept_ref_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];
		        _ctrl_id            = (dr["CTRL_ID"]            == DBNull.Value) ? "" : (string) dr["CTRL_ID"];
		        _dept_ref_id        = (dr["DEPT_REF_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_REF_ID"]);
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyCtrlEstDeptMap( string ctrl_id
                                        , int dept_ref_id
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _ctrlDeptMap.Update(null
                                            , null
                                            , ctrl_id
                                            , dept_ref_id
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetCtrlEstDeptMap(string ctrl_id)
        {
            return _ctrlDeptMap.Select(ctrl_id, 0);
        }

        public bool AddCtrlEstDeptMap(DataTable dataTable)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _ctrlDeptMap.Delete(conn
                                                    , trx
                                                    , DataTypeUtility.GetValue(dataRow["CTRL_ID"])
                                                    , DataTypeUtility.GetToInt32(dataRow["DEPT_REF_ID"]));

                    affectedRow += _ctrlDeptMap.Insert(conn
                                                    , trx
                                                    , DataTypeUtility.GetValue(dataRow["CTRL_ID"])
                                                    , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                    , DataTypeUtility.GetToInt32(dataRow["DEPT_REF_ID"])
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
         
        public bool AddCtrlEstDeptMap(string ctrl_id
                                    , int comp_id
                                    , int dept_ref_id
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlDeptMap.Insert(null
                                            , null
                                            , ctrl_id
                                            , comp_id
                                            , dept_ref_id
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveCtrlEstDeptMap(DataTable dataTable)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _ctrlDeptMap.Delete(conn
                                                    , trx
                                                    , DataTypeUtility.GetValue(dataRow["CTRL_ID"])
                                                    , DataTypeUtility.GetToInt32(dataRow["DEPT_REF_ID"]));
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
         
        public bool RemoveCtrlEstDeptMap( string ctrl_id, int dept_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlDeptMap.Delete(null
                                            , null
                                            , ctrl_id
                                            , dept_ref_id);

            return (affectedRow > 0) ? true : false;
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CTRL_ID", typeof(string));
            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("DEPT_REF_ID", typeof(int));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
