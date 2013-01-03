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
    public class Biz_RelGroupDepts
    {
        #region ============================== [Fields] ==============================
 
        private int _comp_id;
        private string 	_rel_grp_id;
        private int 	_dept_ref_id;
        private string 	_est_id;
        private int 	_estterm_ref_id;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_RelGroupDepts _relGroupDept = new Dac_RelGroupDepts();

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
         
        public int Dept_Ref_ID
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

        public Biz_RelGroupDepts()
        {
           
        }

        public Biz_RelGroupDepts( int comp_id
                                , string rel_grp_id
                                , int dept_ref_id
                                , string est_id
                                , int estterm_ref_id)
        {
            DataSet ds = GetRelGroupDept( comp_id
                                        , rel_grp_id
                                        , dept_ref_id
                                        , est_id
                                        , estterm_ref_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];

                _comp_id        = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _rel_grp_id     = (dr["REL_GRP_ID"]         == DBNull.Value) ? "" : (string) dr["REL_GRP_ID"];
		        _dept_ref_id    = (dr["DEPT_REF_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_REF_ID"]);
		        _est_id         = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_ref_id = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _update_date    = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyRelGroupDept(int comp_id
                                    , string rel_grp_id
                                    , int dept_ref_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupDept.Update(   null
                                                , null
                                                , comp_id
                                                , rel_grp_id
                                                , dept_ref_id
                                                , est_id
                                                , estterm_ref_id
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetRelGroupDept(   int comp_id
                                        , string rel_grp_id
                                        , int dept_ref_id
                                        , string est_id
                                        , int estterm_ref_id)
        {
	        return _relGroupDept.Select(  null
                                        , null
                                        , comp_id
                                        , rel_grp_id
                                        , dept_ref_id
                                        , est_id
                                        , estterm_ref_id);
        }
         
        public bool AddRelGroupDept(  int comp_id
                                    , string rel_grp_id
                                    , int dept_ref_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupDept.Insert(   null
                                                , null
                                                , comp_id
                                                , rel_grp_id
                                                , dept_ref_id
                                                , est_id
                                                , estterm_ref_id
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool AddRelGroupDept(  int comp_id
                                    , string rel_grp_id
                                    , string[] est_dept_values
                                    , string est_id
                                    , int estterm_ref_id
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            if(est_dept_values.Length == 0)
            {
			    return false;
            }

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow += _relGroupDept.Delete(  conn
                                                    , trx
                                                    , comp_id
                                                    , rel_grp_id
                                                    , 0
                                                    , est_id
                                                    , estterm_ref_id);

                foreach (string dept_ref_id in est_dept_values)
                {
                    affectedRow += _relGroupDept.Insert(  conn
                                                        , trx
                                                        , comp_id
                                                        , rel_grp_id
                                                        , DataTypeUtility.GetToInt32(dept_ref_id)
                                                        , est_id
                                                        , estterm_ref_id
                                                        , create_date
                                                        , create_user);
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
         
        public bool RemoveRelGroupDept(int comp_id
                                    , string rel_grp_id
                                    , int dept_ref_id
                                    , string est_id
                                    , int estterm_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupDept.Delete(   null
                                                , null
                                                , comp_id
                                                , rel_grp_id
                                                , dept_ref_id
                                                , est_id
                                                , estterm_ref_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveRelGroupDept(DataTable dataTable)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _relGroupDept.Delete(  conn
                                                        , trx
                                                        , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                        , dataRow["REL_GRP_ID"].ToString()
                                                        , DataTypeUtility.GetToInt32(dataRow["DEPT_REF_ID"])
                                                        , dataRow["EST_ID"].ToString()
                                                        , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"]));
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

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("REL_GRP_ID", typeof(string));
            dataTable.Columns.Add("DEPT_REF_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
