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
    public class Biz_DeptInfos
    {
        #region ============================== [Fields] ==============================
 
        private int 	_dept_ref_id;
        private int 	_up_dept_id;
        private int 	_dept_level;
        private string 	_dept_name;
        private string 	_dept_code;
        private bool 	_dept_flag;
        private int 	_dept_type;
        private int 	_sort_order;
        private string 	_dept_desc;
        private int 	_create_user;
        private DateTime 	_create_date;
        private int 	_update_user;
        private DateTime 	_update_date;

        private Dac_DeptInfos _deptInfo = new Dac_DeptInfos();

        #endregion
         
        #region ============================== [Properties] ==============================
         
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
         
        public int Up_Dept_ID
        {
	        get 
	        {
		        return _up_dept_id;
	        }
	        set
	        {
		        _up_dept_id = value;
	        }
        }
         
        public int Dept_Level
        {
	        get 
	        {
		        return _dept_level;
	        }
	        set
	        {
		        _dept_level = value;
	        }
        }
         
        public string Dept_Name
        {
	        get 
	        {
		        return _dept_name;
	        }
	        set
	        {
		        _dept_name = ( value==null ? "" : value );
	        }
        }
         
        public string Dept_Code
        {
	        get 
	        {
		        return _dept_code;
	        }
	        set
	        {
		        _dept_code = ( value==null ? "" : value );
	        }
        }
         
        public bool Dept_Flag
        {
	        get 
	        {
		        return _dept_flag;
	        }
	        set
	        {
		        _dept_flag = value;
	        }
        }
         
        public int Dept_Type
        {
	        get 
	        {
		        return _dept_type;
	        }
	        set
	        {
		        _dept_type = value;
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
         
        public string Dept_Desc
        {
	        get 
	        {
		        return _dept_desc;
	        }
	        set
	        {
		        _dept_desc = ( value==null ? "" : value );
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
        #endregion
         
        public Biz_DeptInfos() 
        {
        
        }

        public Biz_DeptInfos(int dept_ref_id) 
        {
            DataSet ds = _deptInfo.Select(dept_ref_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _dept_ref_id    = (dr["DEPT_REF_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_REF_ID"]);
		        _up_dept_id     = (dr["UP_DEPT_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["UP_DEPT_ID"]);
		        _dept_level     = (dr["DEPT_LEVEL"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_LEVEL"]);
		        _dept_name      = (dr["DEPT_NAME"]      == DBNull.Value) ? "" : (string) dr["DEPT_NAME"];
		        _dept_code      = (dr["DEPT_CODE"]      == DBNull.Value) ? "" : (string) dr["DEPT_CODE"];
		        _dept_flag      = (dr["DEPT_FLAG"]      == DBNull.Value) ? false : Convert.ToBoolean(dr["DEPT_FLAG"]);
		        _dept_type      = (dr["DEPT_TYPE"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_TYPE"]);
		        _sort_order     = (dr["SORT_ORDER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
		        _dept_desc      = (dr["DEPT_DESC"]      == DBNull.Value) ? "" : (string) dr["DEPT_DESC"];
		        _create_user    = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
		        _create_date    = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
	        }
        }
         
        public bool ModifyDeptInfo(int dept_ref_id
                                , int up_dept_id
                                , int dept_level
                                , string dept_name
                                , string dept_code
                                , bool dept_flag
                                , int dept_type
                                , int sort_order
                                , string dept_desc
                                , int update_user
                                , DateTime update_date)
        {
	        int affectedRow = 0;

            affectedRow = _deptInfo.Update(  null
                                            , null
                                            , dept_ref_id
                                            , up_dept_id
                                            , dept_level
                                            , dept_name
                                            , dept_code
                                            , dept_flag
                                            , dept_type
                                            , sort_order
                                            , dept_desc
                                            , update_user
                                            , update_date);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetDeptInfo( int dept_ref_id)
        {
            return _deptInfo.Select(dept_ref_id);
        }

        public DataSet GetDeptInfos()
        {
            return _deptInfo.Select(0);
        }

        public DataSet GetCompID()
        {
            return _deptInfo.SelectComp();
        }
         
        public bool AddDeptInfo(  int dept_ref_id
                                , int up_dept_id
                                , int dept_level
                                , string dept_name
                                , string dept_code
                                , bool dept_flag
                                , int dept_type
                                , int sort_order
                                , string dept_desc
                                , int create_user
                                , DateTime create_date)
        {
	        int affectedRow = 0;

            affectedRow = _deptInfo.Insert(null
                                        , null
                                        , dept_ref_id
                                        , up_dept_id
                                        , dept_level
                                        , dept_name
                                        , dept_code
                                        , dept_flag
                                        , dept_type
                                        , sort_order
                                        , dept_desc
                                        , create_user
                                        , create_date);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveDeptInfo( int dept_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _deptInfo.Delete(null
                                        , null
                                        , dept_ref_id);

            return (affectedRow > 0) ? true : false;
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("DEPT_REF_ID", typeof(int));
            dataTable.Columns.Add("UP_DEPT_ID", typeof(int));
            dataTable.Columns.Add("DEPT_LEVEL", typeof(int));
            dataTable.Columns.Add("DEPT_NAME", typeof(string));
            dataTable.Columns.Add("DEPT_CODE", typeof(string));
            dataTable.Columns.Add("DEPT_TYPE", typeof(int));
            dataTable.Columns.Add("SORT_ORDER", typeof(int));
            dataTable.Columns.Add("DEPT_DESC", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }
    }
}
