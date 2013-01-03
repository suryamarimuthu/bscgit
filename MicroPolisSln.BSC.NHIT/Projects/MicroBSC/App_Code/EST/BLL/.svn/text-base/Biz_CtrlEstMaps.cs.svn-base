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
    public class Biz_CtrlEstMaps
    {
        #region ============================== [Fields] ==============================
 
        private string 	_ctrl_id;
        private string 	_est_id;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_CtrlEstMaps _ctrlEstMap = new Dac_CtrlEstMaps();

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
         
        public string Est_ID
        {
	        get 
	        {
		        return _est_id;
	        }
	        set
	        {
		        _est_id = ( value==null ? "" : value );
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
         
        public Biz_CtrlEstMaps()
        {
               
        }

        public Biz_CtrlEstMaps(string ctrl_id, string est_id)
        {
            DataSet ds = _ctrlEstMap.Select(ctrl_id, est_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr           = ds.Tables[0].Rows[0];
		        _ctrl_id     = (dr["CTRL_ID"]       == DBNull.Value) ? "" : (string) dr["CTRL_ID"];
		        _est_id      = (dr["EST_ID"]        == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _update_date = (dr["UPDATE_DATE"]   == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user = (dr["UPDATE_USER"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }   
        }
         
        public bool ModifyCtrlEstMap( string ctrl_id
                                    , string est_id
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlEstMap.Update(null
                                        , null
                                        , ctrl_id
                                        , est_id
                                        , update_date
                                        , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetCtrlEstMap(string ctrl_id)
        {
            return _ctrlEstMap.Select(ctrl_id, "");
        }

        public DataSet GetCtrlInfoByEstID(int comp_id, string est_id)
        {
            return _ctrlEstMap.SelectCtrlInfoByEstID(comp_id, est_id);
        }

        public DataSet GetCtrlEstDeptByEstID(int comp_id, string est_id)
        {
            return _ctrlEstMap.SelectCtrlEstDeptByEstID(comp_id, est_id);
        }

        public bool AddCtrlEstMap(DataTable dataTable)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _ctrlEstMap.Delete(conn
                                                    , trx
                                                    , DataTypeUtility.GetValue(dataRow["CTRL_ID"])
                                                    , DataTypeUtility.GetValue(dataRow["EST_ID"]));

                    affectedRow += _ctrlEstMap.Insert(conn
                                                    , trx
                                                    , DataTypeUtility.GetValue(dataRow["CTRL_ID"])
                                                    , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                    , DataTypeUtility.GetValue(dataRow["EST_ID"])
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

        public bool AddCtrlEstMap(string ctrl_id
                                , int comp_id
                                , string est_id
                                , DateTime create_date
                                , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlEstMap.Insert( null
                                            , null
                                            , ctrl_id
                                            , comp_id
                                            , est_id
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveCtrlEstMap(DataTable dataTable)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _ctrlEstMap.Delete(conn
                                                    , trx
                                                    , DataTypeUtility.GetValue(dataRow["CTRL_ID"])
                                                    , DataTypeUtility.GetValue(dataRow["EST_ID"]));
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
         
        public bool RemoveCtrlEstMap( string ctrl_id, string est_id)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlEstMap.Delete( null
                                            , null
                                            , ctrl_id
                                            , est_id);

            return (affectedRow > 0) ? true : false;
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CTRL_ID", typeof(string));
            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
