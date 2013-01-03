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
    public class Biz_EmpInfos
    {
        #region ============================== [Fields] ==============================
 
        private int 	_emp_ref_id;
        private string 	_emp_code;
        private string 	_loginid;
        private string 	_loginip;
        private string 	_passwd;
        private string 	_emp_name;
        private string 	_emp_email;
        private string 	_position_class_code;
        private string 	_position_grp_code;
        private string 	_position_rank_code;
        private string 	_position_duty_code;
        private string 	_position_stat_code;
        private string 	_position_kind_code;
        private string 	_daily_phone;
        private string 	_cell_phone;
        private string 	_fax_number;
        private short 	_job_status;
        private string 	_zipcode;
        private string 	_addr_1;
        private string 	_addr_2;
        private string 	_sign_path;
        private string 	_stamp_path;
        private short 	_create_type;
        private short 	_modify_type;
        private DateTime 	_modify_date;
        private int 	_modify_emp_id;

        private Dac_EmpInfos _empInfo = new Dac_EmpInfos();

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
         
        public string Emp_Code
        {
	        get 
	        {
		        return _emp_code;
	        }
	        set
	        {
		        _emp_code = ( value==null ? "" : value );
	        }
        }
         
        public string LoginID
        {
	        get 
	        {
		        return _loginid;
	        }
	        set
	        {
		        _loginid = ( value==null ? "" : value );
	        }
        }
         
        public string LoginIP
        {
	        get 
	        {
		        return _loginip;
	        }
	        set
	        {
		        _loginip = ( value==null ? "" : value );
	        }
        }
         
        public string Passwd
        {
	        get 
	        {
		        return _passwd;
	        }
	        set
	        {
		        _passwd = ( value==null ? "" : value );
	        }
        }
         
        public string Emp_Name
        {
	        get 
	        {
		        return _emp_name;
	        }
	        set
	        {
		        _emp_name = ( value==null ? "" : value );
	        }
        }
         
        public string Emp_Email
        {
	        get 
	        {
		        return _emp_email;
	        }
	        set
	        {
		        _emp_email = ( value==null ? "" : value );
	        }
        }
         
        public string Position_Class_Code
        {
	        get 
	        {
		        return _position_class_code;
	        }
	        set
	        {
		        _position_class_code = ( value==null ? "" : value );
	        }
        }
         
        public string Position_Grp_Code
        {
	        get 
	        {
		        return _position_grp_code;
	        }
	        set
	        {
		        _position_grp_code = ( value==null ? "" : value );
	        }
        }
         
        public string Position_Rank_Code
        {
	        get 
	        {
		        return _position_rank_code;
	        }
	        set
	        {
		        _position_rank_code = ( value==null ? "" : value );
	        }
        }
         
        public string Position_Duty_Code
        {
	        get 
	        {
		        return _position_duty_code;
	        }
	        set
	        {
		        _position_duty_code = ( value==null ? "" : value );
	        }
        }
         
        public string Position_Stat_Code
        {
	        get 
	        {
		        return _position_stat_code;
	        }
	        set
	        {
		        _position_stat_code = ( value==null ? "" : value );
	        }
        }

        public string Position_Kind_Code
        {
	        get 
	        {
		        return _position_kind_code;
	        }
	        set
	        {
		        _position_kind_code = ( value==null ? "" : value );
	        }
        }
         
        public string Daily_Phone
        {
	        get 
	        {
		        return _daily_phone;
	        }
	        set
	        {
		        _daily_phone = ( value==null ? "" : value );
	        }
        }
         
        public string Cell_Phone
        {
	        get 
	        {
		        return _cell_phone;
	        }
	        set
	        {
		        _cell_phone = ( value==null ? "" : value );
	        }
        }
         
        public string Fax_Number
        {
	        get 
	        {
		        return _fax_number;
	        }
	        set
	        {
		        _fax_number = ( value==null ? "" : value );
	        }
        }
         
        public short Job_Status
        {
	        get 
	        {
		        return _job_status;
	        }
	        set
	        {
		        _job_status = value;
	        }
        }
         
        public string ZipCode
        {
	        get 
	        {
		        return _zipcode;
	        }
	        set
	        {
		        _zipcode = ( value==null ? "" : value );
	        }
        }
         
        public string Addr_1
        {
	        get 
	        {
		        return _addr_1;
	        }
	        set
	        {
		        _addr_1 = ( value==null ? "" : value );
	        }
        }
         
        public string Addr_2
        {
	        get 
	        {
		        return _addr_2;
	        }
	        set
	        {
		        _addr_2 = ( value==null ? "" : value );
	        }
        }
         
        public string Sign_Path
        {
	        get 
	        {
		        return _sign_path;
	        }
	        set
	        {
		        _sign_path = ( value==null ? "" : value );
	        }
        }
         
        public string Stamp_Path
        {
	        get 
	        {
		        return _stamp_path;
	        }
	        set
	        {
		        _stamp_path = ( value==null ? "" : value );
	        }
        }
         
        public short Create_Type
        {
	        get 
	        {
		        return _create_type;
	        }
	        set
	        {
		        _create_type = value;
	        }
        }
         
        public short Modify_Type
        {
	        get 
	        {
		        return _modify_type;
	        }
	        set
	        {
		        _modify_type = value;
	        }
        }
         
        public DateTime Modify_Date
        {
	        get 
	        {
		        return _modify_date;
	        }
	        set
	        {
		        _modify_date = value;
	        }
        }
         
        public int Modify_Emp_ID
        {
	        get 
	        {
		        return _modify_emp_id;
	        }
	        set
	        {
		        _modify_emp_id = value;
	        }
        }
        #endregion
         
        public Biz_EmpInfos()
        {
         
        }

        public Biz_EmpInfos(int emp_ref_id)
        {
            DataSet ds = GetEmpInfo(emp_ref_id);

	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                      = ds.Tables[0].Rows[0];
		        _emp_ref_id             = (dr["EMP_REF_ID"]             == DBNull.Value) ? 0 : Convert.ToInt32(dr["EMP_REF_ID"]);
		        _emp_code               = (dr["EMP_CODE"]               == DBNull.Value) ? "" : (string) dr["EMP_CODE"];
		        _loginid                = (dr["LOGINID"]                == DBNull.Value) ? "" : (string) dr["LOGINID"];
		        _loginip                = (dr["LOGINIP"]                == DBNull.Value) ? "" : (string) dr["LOGINIP"];
		        _passwd                 = (dr["PASSWD"]                 == DBNull.Value) ? "" : (string) dr["PASSWD"];
		        _emp_name               = (dr["EMP_NAME"]               == DBNull.Value) ? "" : (string) dr["EMP_NAME"];
		        _emp_email              = (dr["EMP_EMail"]              == DBNull.Value) ? "" : (string) dr["EMP_EMail"];
		        _position_class_code    = (dr["POSITION_CLASS_CODE"]    == DBNull.Value) ? "" : (string) dr["POSITION_CLASS_CODE"];
		        _position_grp_code      = (dr["POSITION_GRP_CODE"]      == DBNull.Value) ? "" : (string) dr["POSITION_GRP_CODE"];
		        _position_rank_code     = (dr["POSITION_RANK_CODE"]     == DBNull.Value) ? "" : (string) dr["POSITION_RANK_CODE"];
		        _position_duty_code     = (dr["POSITION_DUTY_CODE"]     == DBNull.Value) ? "" : (string) dr["POSITION_DUTY_CODE"];
		        _position_stat_code     = (dr["POSITION_STAT_CODE"]     == DBNull.Value) ? "" : (string) dr["POSITION_STAT_CODE"];
                _position_kind_code     = (dr["POSITION_KIND_CODE"]     == DBNull.Value) ? "" : (string) dr["POSITION_KIND_CODE"];
		        _daily_phone            = (dr["DAILY_PHONE"]            == DBNull.Value) ? "" : (string) dr["DAILY_PHONE"];
		        _cell_phone             = (dr["CELL_PHONE"]             == DBNull.Value) ? "" : (string) dr["CELL_PHONE"];
		        _fax_number             = (dr["FAX_NUMBER"]             == DBNull.Value) ? "" : (string) dr["FAX_NUMBER"];
		        //_job_status             = (dr["JOB_STATUS"]             == DBNull.Value) ? 0 : (short) dr["JOB_STATUS"];
		        _zipcode                = (dr["ZIPCODE"]                == DBNull.Value) ? "" : (string) dr["ZIPCODE"];
		        _addr_1                 = (dr["ADDR_1"]                 == DBNull.Value) ? "" : (string) dr["ADDR_1"];
		        _addr_2                 = (dr["ADDR_2"]                 == DBNull.Value) ? "" : (string) dr["ADDR_2"];
		        _sign_path              = (dr["SIGN_PATH"]              == DBNull.Value) ? "" : (string) dr["SIGN_PATH"];
		        _stamp_path             = (dr["STAMP_PATH"]             == DBNull.Value) ? "" : (string) dr["STAMP_PATH"];
                //_create_type            = (dr["CREATE_TYPE"]            == DBNull.Value) ? 0 : (short) dr["CREATE_TYPE"];
                //_modify_type            = (dr["MODIFY_TYPE"]            == DBNull.Value) ? 0 : (short) dr["MODIFY_TYPE"];
		        _modify_date            = (dr["MODIFY_DATE"]            == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["MODIFY_DATE"];
		        _modify_emp_id          = (dr["MODIFY_EMP_ID"]          == DBNull.Value) ? 0 : Convert.ToInt32(dr["MODIFY_EMP_ID"]);
	        }
        }
         
        public bool ModifyEmpInfo(int emp_ref_id
                                , string emp_code
                                , string loginid
                                , string loginip
                                , string passwd
                                , string emp_name
                                , string emp_email
                                , string position_class_code
                                , string position_grp_code
                                , string position_rank_code
                                , string position_duty_code
                                , string position_stat_code
                                , string position_kind_code
                                , string daily_phone
                                , string cell_phone
                                , string fax_number
                                , short job_status
                                , string zipcode
                                , string addr_1
                                , string addr_2
                                , string sign_path
                                , string stamp_path
                                , short create_type
                                , short modify_type
                                , DateTime modify_date
                                , int modify_emp_id)
        {
	        int affectedRow = 0;

            affectedRow = _empInfo.Update(null
                                        , null
                                        , emp_ref_id
                                        , emp_code
                                        , loginid
                                        , loginip
                                        , passwd
                                        , emp_name
                                        , emp_email
                                        , position_class_code
                                        , position_grp_code
                                        , position_rank_code
                                        , position_duty_code
                                        , position_stat_code
                                        , position_kind_code
                                        , daily_phone
                                        , cell_phone
                                        , fax_number
                                        , job_status
                                        , zipcode
                                        , addr_1
                                        , addr_2
                                        , sign_path
                                        , stamp_path
                                        , create_type
                                        , modify_type
                                        , modify_date
                                        , modify_emp_id);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetEmpInfo( int emp_ref_id)
        {
            return _empInfo.Select(emp_ref_id);
        }

        public DataSet GetEmpByEstDeptID(int dept_ref_id)
        {
            return _empInfo.SelectByDept(dept_ref_id, 0);
        }

        public DataSet GetAllEmp()
        {
            return _empInfo.SelectByDept(0, 0);
        }

        public DataSet GetEmpByEstDeptIDWithPrefix(int dept_ref_id, string prefix)
        {
            return _empInfo.SelectByDeptWithPrefix(prefix, 0, dept_ref_id, 0);
        }

        public DataSet GetEmpByEmpID(int emp_ref_id)
        {
            return _empInfo.SelectByDept(0, emp_ref_id);
        }
         
        public bool AddEmpInfo(int emp_ref_id
                            , string emp_code
                            , string loginid
                            , string loginip
                            , string passwd
                            , string emp_name
                            , string emp_email
                            , string position_class_code
                            , string position_grp_code
                            , string position_rank_code
                            , string position_duty_code
                            , string position_stat_code
                            , string position_kind_code
                            , string daily_phone
                            , string cell_phone
                            , string fax_number
                            , short job_status
                            , string zipcode
                            , string addr_1
                            , string addr_2
                            , string sign_path
                            , string stamp_path
                            , short create_type
                            , DateTime create_date
                            , int create_emp_id
                            , short modify_type)
        {
	        int affectedRow = 0;

            affectedRow = _empInfo.Insert(null
                                        , null
                                        , emp_ref_id
                                        , emp_code
                                        , loginid
                                        , loginip
                                        , passwd
                                        , emp_name
                                        , emp_email
                                        , position_class_code
                                        , position_grp_code
                                        , position_rank_code
                                        , position_duty_code
                                        , position_stat_code
                                        , position_kind_code
                                        , daily_phone
                                        , cell_phone
                                        , fax_number
                                        , job_status
                                        , zipcode
                                        , addr_1
                                        , addr_2
                                        , sign_path
                                        , stamp_path
                                        , create_type
                                        , create_date
                                        , create_emp_id
                                        , modify_type);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveEmpInfo( int emp_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _empInfo.Delete(null
                                        , null
                                        , emp_ref_id);

            return (affectedRow > 0) ? true : false;
        }
        #region ================================= 상대평가 그룹설정 =================================

        public DataSet GetRelDeptList(string opt
                                    , string where_sentence
                                    , string prefix)
        {
            return _empInfo.SelectRelByDept(  opt
                                            , where_sentence
                                            , prefix);
        }

        public DataSet GetRelEmpList( string opt
                                    , string where_sentence
                                    , string prefix)
        {
            return _empInfo.SelectRelByEmp(   opt
                                            , where_sentence
                                            , prefix);
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("EMP_REF_ID", typeof(int));
            dataTable.Columns.Add("EMP_CODE", typeof(string));
            dataTable.Columns.Add("LOGINID", typeof(string));
            dataTable.Columns.Add("LOGINIP", typeof(string));
            dataTable.Columns.Add("PASSWD", typeof(string));
            dataTable.Columns.Add("EMP_NAME", typeof(string));
            dataTable.Columns.Add("EMP_EMAIL", typeof(string));
            dataTable.Columns.Add("POSITION_CLASS_CODE", typeof(string));
            dataTable.Columns.Add("POSITION_GRP_CODE", typeof(string));
            dataTable.Columns.Add("POSITION_RANK_CODE", typeof(string));
            dataTable.Columns.Add("POSITION_DUTY_CODE", typeof(string));
            dataTable.Columns.Add("POSITION_STAT_CODE", typeof(string));
            dataTable.Columns.Add("POSITION_KIND_CODE", typeof(string));
            dataTable.Columns.Add("DAILY_PHONE", typeof(string));
            dataTable.Columns.Add("CELL_PHONE", typeof(string));
            dataTable.Columns.Add("FAX_NUMBER", typeof(int));
            dataTable.Columns.Add("JOB_STATUS", typeof(string));
            dataTable.Columns.Add("ZIPCODE", typeof(string));
            dataTable.Columns.Add("ADDR_1", typeof(string));
            dataTable.Columns.Add("ADDR_2", typeof(string));
            dataTable.Columns.Add("SIGN_PATH", typeof(string));
            dataTable.Columns.Add("STAMP_PATH", typeof(string));
            dataTable.Columns.Add("CREATE_TYPE", typeof(int));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }

        #endregion
    }
}
