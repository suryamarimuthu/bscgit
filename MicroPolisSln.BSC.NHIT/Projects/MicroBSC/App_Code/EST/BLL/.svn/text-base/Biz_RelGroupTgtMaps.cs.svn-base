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
    public class Biz_RelGroupTgtMaps
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_rel_grp_id;
        private string 	_est_id;
        private int 	_estterm_ref_id;
        private int 	_tgt_dept_id;
        private int 	_tgt_emp_id;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_RelGroupTgtMaps _relGroupTgtMap = new Dac_RelGroupTgtMaps();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public int Comp_ID
        {
	        get 
	        {
		        return _comp_id;
	        }
	        set
	        {
		        _comp_id = value;
	        }
        }
         
        public string Rel_Grp_ID
        {
	        get 
	        {
		        return _rel_grp_id;
	        }
	        set
	        {
		        _rel_grp_id = ( value==null ? "" : value );
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
         
        public int EstTerm_Ref_ID
        {
	        get 
	        {
		        return _estterm_ref_id;
	        }
	        set
	        {
		        _estterm_ref_id = value;
	        }
        }
         
        public int Tgt_Dept_ID
        {
	        get 
	        {
		        return _tgt_dept_id;
	        }
	        set
	        {
		        _tgt_dept_id = value;
	        }
        }

        public int Tgt_Emp_ID
        {
	        get 
	        {
		        return _tgt_emp_id;
	        }
	        set
	        {
		        _tgt_emp_id = value;
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
         
        public Biz_RelGroupTgtMaps()
	    {
		    
	    }

        public Biz_RelGroupTgtMaps(int comp_id
                                , string rel_grp_id
                                , string est_id
                                , int estterm_ref_id
                                , int tgt_dept_id
                                , int tgt_emp_id)
	    {
            DataSet ds = _relGroupTgtMap.Select(  comp_id
                                                , rel_grp_id
                                                , est_id
                                                , estterm_ref_id
                                                , tgt_dept_id
                                                , tgt_emp_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _comp_id        = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _rel_grp_id     = (dr["REL_GRP_ID"]         == DBNull.Value) ? "" : (string) dr["REL_GRP_ID"];
		        _est_id         = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_ref_id = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _tgt_dept_id    = (dr["TGT_DEPT_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_DEPT_ID"]);
                _tgt_emp_id     = (dr["TGT_EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_EMP_ID"]);
		        _update_date    = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyRelGroupEmpMap( int comp_id
                                        , string rel_grp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupTgtMap.Update( null
                                                , null
                                                , comp_id
                                                , rel_grp_id
                                                , est_id
                                                , estterm_ref_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetRelGroupEmpMap( int comp_id
                                        , string rel_grp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id)
        {
            return _relGroupTgtMap.Select(comp_id
                                        , rel_grp_id
                                        , est_id
                                        , estterm_ref_id
                                        , tgt_dept_id
                                        , tgt_emp_id);
        }
         
        public bool AddRelGroupEmpMap(int comp_id
                                    , string rel_grp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupTgtMap.Insert( null
                                                , null
                                                , comp_id
                                                , rel_grp_id
                                                , est_id
                                                , estterm_ref_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool AddRelGroupEmpMap(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _relGroupTgtMap.Insert(conn
                                                        , trx
                                                        , dataRow["COMP_ID"]
                                                        , dataRow["REL_GRP_ID"]
                                                        , dataRow["EST_ID"]
                                                        , dataRow["ESTTERM_REF_ID"]
                                                        , dataRow["TGT_DEPT_ID"]
                                                        , dataRow["TGT_EMP_ID"]
                                                        , dataRow["DATE"]
                                                        , dataRow["USER"]);
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
         
        public bool RemoveRelGroupEmpMap( int comp_id
                                        , string rel_grp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupTgtMap.Delete( null
                                                , null
                                                , comp_id
                                                , rel_grp_id
                                                , est_id
                                                , estterm_ref_id
                                                , tgt_dept_id
                                                , tgt_emp_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(  int comp_id
                            , string rel_grp_id
                            , string est_id
                            , int estterm_ref_id
                            , int tgt_dept_id
                            , int tgt_emp_id)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupTgtMap.Count(  null
                                                , null
                                                , comp_id
                                                , rel_grp_id
                                                , est_id
                                                , estterm_ref_id
                                                , tgt_dept_id
                                                , tgt_emp_id);

            return (affectedRow > 0) ? true : false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("REL_GRP_ID", typeof(string));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("TGT_DEPT_ID", typeof(int));
            dataTable.Columns.Add("TGT_EMP_ID", typeof(int));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
