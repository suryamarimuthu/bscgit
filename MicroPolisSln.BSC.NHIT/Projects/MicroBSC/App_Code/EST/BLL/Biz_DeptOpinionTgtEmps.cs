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
    public class Biz_DeptOpinionTgtEmps
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_est_id;
        private int 	_tgt_dept_id;
        private int 	_tgt_emp_id;
        private string 	_tgt_opinion_yn;
        private DateTime 	_create_date;
        private int 	_create_user;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_DeptOpinionTgtEmps _deptOpinionTgtEmp = new Dac_DeptOpinionTgtEmps();

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
         
        public string Tgt_Opinion_YN
        {
	        get 
	        {
		        return _tgt_opinion_yn;
	        }
	        set
	        {
		        _tgt_opinion_yn = ( value==null ? "" : value );
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
         
        public Biz_DeptOpinionTgtEmps()
	    {
    		
	    }

        public Biz_DeptOpinionTgtEmps(int comp_id
                                    , string est_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id)
	    {
            DataSet ds = _deptOpinionTgtEmp.Select(comp_id
                                                , est_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , "");
    		DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _comp_id        = (dr["COMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id         = (dr["EST_ID"]         == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _tgt_dept_id    = (dr["TGT_DEPT_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_DEPT_ID"]);
		        _tgt_emp_id     = (dr["TGT_EMP_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_EMP_ID"]);
		        _tgt_opinion_yn = (dr["TGT_OPINION_YN"] == DBNull.Value) ? "" : (string) dr["TGT_OPINION_YN"];
		        _create_date    = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
		        _create_user    = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyDeptOpinionTgtEmp(  int comp_id
                                            , string est_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id
                                            , string tgt_opinion_yn
                                            , DateTime update_date
                                            , int update_user)
        {
	        int affectedRow = 0;

            affectedRow     = _deptOpinionTgtEmp.Update(  null
                                                        , null
                                                        , comp_id
                                                        , est_id
                                                        , tgt_dept_id
                                                        , tgt_emp_id
                                                        , tgt_opinion_yn
                                                        , update_date
                                                        , update_user);

            return ( affectedRow > 0 ) ? true : false;
        }
         
        public DataSet GetDeptOpinionTgtEmp(int comp_id
                                        , string est_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , string tgt_opinion_yn)
        {
	        return _deptOpinionTgtEmp.Select( comp_id
                                            , est_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , tgt_opinion_yn);
        }

        public DataSet GetDeptOpinionTgtEmp(int comp_id
                                        , string est_id
                                        , int tgt_emp_id)
        {
	        return _deptOpinionTgtEmp.Select( comp_id
                                            , est_id
                                            , 0
                                            , tgt_emp_id
                                            , "");
        }

        public DataSet GetDeptOpinionTgtEmp(int comp_id, string est_id)
        {
	        return _deptOpinionTgtEmp.Select( comp_id
                                            , est_id
                                            , 0
                                            , 0
                                            , "");
        }
         
        public bool AddDeptOpinionTgtEmp(int comp_id
                                    , string est_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string tgt_opinion_yn
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            affectedRow     = _deptOpinionTgtEmp.Insert(null
                                                    , null
                                                    , comp_id
                                                    , est_id
                                                    , tgt_dept_id
                                                    , tgt_emp_id
                                                    , tgt_opinion_yn
                                                    , create_date
                                                    , create_user);

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool SaveDeptOpinionTgtEmp(DataTable dataTable, int comp_id, string est_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow     += _deptOpinionTgtEmp.Delete( conn
                                                            , trx
                                                            , comp_id
                                                            , est_id
                                                            , 0
                                                            , 0);
                                            
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                     affectedRow     += _deptOpinionTgtEmp.Insert( conn
                                                                , trx
                                                                , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                                , DataTypeUtility.GetValue(dataRow["EST_ID"])
                                                                , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                                                , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                                                , DataTypeUtility.GetValue(dataRow["TGT_OPINION_YN"])
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
         
        public bool RemoveDeptOpinionTgtEmp(int comp_id
                                        , string est_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id)
        {
	        int affectedRow = 0;

            affectedRow     = _deptOpinionTgtEmp.Delete(  null
                                                        , null
                                                        , comp_id
                                                        , est_id
                                                        , tgt_dept_id
                                                        , tgt_emp_id);

            return ( affectedRow > 0 ) ? true : false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("TGT_DEPT_ID", typeof(int));
            dataTable.Columns.Add("TGT_EMP_ID", typeof(int));
            dataTable.Columns.Add("TGT_OPINION_YN", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
