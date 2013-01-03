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
    public class Biz_EmpPositionBizMaps
    {
        #region ============================== [Fields] ==============================
 
        private int 	_emp_ref_id;
        private string 	_pos_biz_id;
        private DateTime 	_create_date;
        private int 	_create_user;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_EmpPositionBizMaps _empPosBizMap = new Dac_EmpPositionBizMaps();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public int Emp_Ref_ID
        {
	        get 
	        {
		        return _emp_ref_id;
	        }
	        set
	        {
		        _emp_ref_id = value;
	        }
        }
         
        public string Pos_Biz_ID
        {
	        get 
	        {
		        return _pos_biz_id;
	        }
	        set
	        {
		        _pos_biz_id = ( value==null ? "" : value );
	        }
        }
         
        public DateTime Create_Date
        {
	        get 
	        {
		        return _create_date;
	        }
	        set
	        {
		        _create_date = value;
	        }
        }
         
        public int Create_User
        {
	        get 
	        {
		        return _create_user;
	        }
	        set
	        {
		        _create_user = value;
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
         
        public Biz_EmpPositionBizMaps()
	    {
		    
	    }

        public Biz_EmpPositionBizMaps(int emp_ref_id
                                    , string pos_biz_id)
	    {
            DataSet ds = _empPosBizMap.Select( emp_ref_id
                                             , pos_biz_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _emp_ref_id     = (dr["EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["EMP_ID"]);
		        _pos_biz_id     = (dr["POS_BIZ_ID"]     == DBNull.Value) ? "" : (string) dr["POS_BIZ_ID"];
		        _create_date    = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
		        _create_user    = (dr["CREATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
		        _update_date    = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyPosBizMap(int emp_ref_id
                                    , string pos_biz_id
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow     = _empPosBizMap.Update(null
                                                    , null
                                                    , emp_ref_id
                                                    , pos_biz_id
                                                    , update_date
                                                    , update_user );

            return ( affectedRow > 0 ) ? true : false;
        }
         
        public DataSet GetPosBizMap(int emp_ref_id
                               , string pos_biz_id)
        {
	        return _empPosBizMap.Select(emp_ref_id
                                        , pos_biz_id);
        }

        public DataSet GetPosBizMap(int emp_ref_id)
        {
	        return _empPosBizMap.Select(emp_ref_id, "");
        }
         
        public bool AddPosBizMap( int emp_ref_id
                                , string pos_biz_id
                                , DateTime create_date
                                , int create_user)
        {
	        int affectedRow = 0;

            affectedRow     = _empPosBizMap.Insert(null
                                                , null
                                                , emp_ref_id
                                                , pos_biz_id
                                                , create_date
                                                , create_user );

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool SavePosBizMap(DataTable dataTable, int emp_ref_id)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow     += _empPosBizMap.Delete(  conn
                                                        , trx
                                                        , emp_ref_id
                                                        , "");
                                            
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                     affectedRow     += _empPosBizMap.Insert( conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["EMP_REF_ID"])
                                                            , DataTypeUtility.GetValue(dataRow["POS_BIZ_ID"])
                                                            , DataTypeUtility.GetToDateTime(dataRow["DATE"])
                                                            , DataTypeUtility.GetToInt32(dataRow["USER"]));
                }

				trx.Commit();
			}
			catch ( Exception ex )
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
         
        public bool RemovePosBizMap(int emp_ref_id
                                , string pos_biz_id)
        {
	        int affectedRow = 0;

            affectedRow     = _empPosBizMap.Delete(null
                                                , null
                                                , emp_ref_id
                                                , pos_biz_id);

            return ( affectedRow > 0 ) ? true : false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("EMP_REF_ID", typeof(int));
            dataTable.Columns.Add("POS_BIZ_ID", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
