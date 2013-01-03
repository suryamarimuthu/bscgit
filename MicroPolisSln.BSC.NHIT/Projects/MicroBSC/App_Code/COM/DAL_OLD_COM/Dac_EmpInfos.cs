using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class EmpInfos : DbAgentBase
    {
        public EmpInfos()
        {

        }

        public EmpInfos(int emp_ref_id)
        {
            DataSet ds = GetEmpInfo(emp_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _emp_ref_id             = Convert.ToInt32(dr["EMP_REF_ID"]);
                _loginid                = (dr["LOGINID"]                == DBNull.Value) ? "" : (string)dr["LOGINID"];
                _loginip                = (dr["LOGINIP"]                == DBNull.Value) ? "" : (string)dr["LOGINIP"];
                //_passwd                 = (string)dr["PASSWD"];
                _emp_name               = (dr["EMP_NAME"]               == DBNull.Value) ? "" : (string)dr["EMP_NAME"];
                _position_class_code    = (dr["POSITION_CLASS_CODE"]    == DBNull.Value) ? "" : (string)dr["POSITION_CLASS_CODE"];
                _position_grp_code      = (dr["POSITION_GRP_CODE"]      == DBNull.Value) ? "" : (string)dr["POSITION_GRP_CODE"];
                _position_rank_code     = (dr["POSITION_RANK_CODE"]     == DBNull.Value) ? "" : (string)dr["POSITION_RANK_CODE"];
                _position_duty_code     = (dr["POSITION_DUTY_CODE"]     == DBNull.Value) ? "" : (string)dr["POSITION_DUTY_CODE"];
                _position_kind_code     = (dr["POSITION_KIND_CODE"]     == DBNull.Value) ? "" : (string)dr["POSITION_KIND_CODE"];
                //_position_class_name    = (dr["POSITION_CLASS_NAME"]    == DBNull.Value) ? "" : (string)dr["POSITION_CLASS_NAME"];
                //_position_grp_name      = (dr["POSITION_GRP_NAME"]      == DBNull.Value) ? "" : (string)dr["POSITION_GRP_NAME"];
                //_position_rank_name     = (dr["POSITION_RANK_NAME"]     == DBNull.Value) ? "" : (string)dr["POSITION_RANK_NAME"];
                //_position_duty_name     = (dr["POSITION_DUTY_NAME"]     == DBNull.Value) ? "" : (string)dr["POSITION_DUTY_NAME"];
                _dept_ref_id            = Convert.ToInt32(dr["DEPT_REF_ID"]);
                _dept_name              = (dr["DEPT_NAME"]              == DBNull.Value) ? "" : (string)dr["DEPT_NAME"];
                _emp_email              = (dr["EMP_EMAIL"]              == DBNull.Value) ? "" : (string)dr["EMP_EMAIL"];
                _daily_phone            = (dr["DAILY_PHONE"]            == DBNull.Value) ? "" : (string)dr["DAILY_PHONE"];
                _cell_phone             = (dr["CELL_PHONE"]             == DBNull.Value) ? "" : (string)dr["CELL_PHONE"];
                _fax_number             = (dr["FAX_NUMBER"]             == DBNull.Value) ? "" : (string)dr["FAX_NUMBER"];
                _job_status             = Convert.ToInt16(dr["JOB_STATUS"]);
                _zipcode                = (dr["ZIPCODE"]                == DBNull.Value) ? "" : (string)dr["ZIPCODE"];
                _addr_1                 = (dr["ADDR_1"]                 == DBNull.Value) ? "" : (string)dr["ADDR_1"];
                _addr_2                 = (dr["ADDR_2"]                 == DBNull.Value) ? "" : (string)dr["ADDR_2"];
                _sign_path              = (dr["SIGN_PATH"]              == DBNull.Value) ? "" : (string)dr["SIGN_PATH"];
                _stamp_path             = (dr["STAMP_PATH"]             == DBNull.Value) ? "" : (string)dr["STAMP_PATH"];
                //_create_type = Convert.ToInt16(dr["CREATE_TYPE"];
                //_create_date = Convert.ToDateTime(dr["CREATE_DATE"];
                //_create_emp_id = (int)dr["CREATE_EMP_ID"];
                //_modify_type = Convert.ToInt16(dr["MODIFY_TYPE"];
                //_modify_date = Convert.ToDateTime(dr["MODIFY_DATE"];
                //_modify_emp_id = (int)dr["MODIFY_EMP_ID"];
            }
        }

        #region ------------------------ 필드 ------------------------

        private int _emp_ref_id;
        private string _loginid;
        private string _loginip;
        private string _passwd;
        private string _emp_name;
        private string _position_class_code;
        private string _position_grp_code;
        private string _position_rank_code;
        private string _position_duty_code;
        private string _position_kind_code;
        private string _position_class_name;
        private string _position_grp_name;
        private string _position_rank_name;
        private string _position_duty_name;
        private int _dept_ref_id;
        private string _dept_name;
        private string _emp_email;
        private string _daily_phone;
        private string _cell_phone;
        private string _fax_number;
        private short _job_status;
        private string _zipcode;
        private string _addr_1;
        private string _addr_2;
        private string _sign_path;
        private string _stamp_path;
        private short _create_type;
        private DateTime _create_date;
        private int _create_emp_id;
        private short _modify_type;
        private DateTime _modify_date;
        private int _modify_emp_id;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

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

        public string LoginID
        {
            get
            {
                return _loginid;
            }
            set
            {
                _loginid = (value == null ? "" : value);
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
                _loginip = (value == null ? "" : value);
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
                _passwd = (value == null ? "" : value);
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
                _emp_name = (value == null ? "" : value);
            }
        }

        public string Position_class_code
        {
            get
            {
                return _position_class_code;
            }
            set
            {
                _position_class_code = (value == null ? "" : value);
            }
        }
        public string Position_grp_code
        {
            get
            {
                return _position_grp_code;
            }
            set
            {
                _position_grp_code = (value == null ? "" : value);
            }
        }
        public string Position_rank_code
        {
            get
            {
                return _position_rank_code;
            }
            set
            {
                _position_rank_code = (value == null ? "" : value);
            }
        }

        public string Position_duty_code
        {
            get
            {
                return _position_duty_code;
            }
            set
            {
                _position_duty_code = (value == null ? "" : value);
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
                _position_kind_code = (value == null ? "" : value);
            }
        }

        public string Position_class_name
        {
            get
            {
                return _position_class_name;
            }
            set
            {
                _position_class_name = (value == null ? "" : value);
            }
        }
        public string Position_grp_name
        {
            get
            {
                return _position_grp_name;
            }
            set
            {
                _position_grp_name = (value == null ? "" : value);
            }
        }
        public string Position_rank_name
        {
            get
            {
                return _position_rank_name;
            }
            set
            {
                _position_rank_name = (value == null ? "" : value);
            }
        }
        public string Position_duty_name
        {
            get
            {
                return _position_duty_name;
            }
            set
            {
                _position_duty_name = (value == null ? "" : value);
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
                _emp_email = (value == null ? "" : value);
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
                _daily_phone = (value == null ? "" : value);
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
                _cell_phone = (value == null ? "" : value);
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
                _fax_number = (value == null ? "" : value);
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
                _zipcode = (value == null ? "" : value);
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
                _addr_1 = (value == null ? "" : value);
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
                _addr_2 = (value == null ? "" : value);
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
                _sign_path = (value == null ? "" : value);
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
                _stamp_path = (value == null ? "" : value);
            }
        }

        //public short Create_Type
        //{
        //    get
        //    {
        //        return _create_type;
        //    }
        //    set
        //    {
        //        _create_type = value;
        //    }
        //}

        //public DateTime Create_Date
        //{
        //    get
        //    {
        //        return _create_date;
        //    }
        //    set
        //    {
        //        _create_date = value;
        //    }
        //}

        //public int Create_Emp_ID
        //{
        //    get
        //    {
        //        return _create_emp_id;
        //    }
        //    set
        //    {
        //        _create_emp_id = value;
        //    }
        //}

        //public short Modify_Type
        //{
        //    get
        //    {
        //        return _modify_type;
        //    }
        //    set
        //    {
        //        _modify_type = value;
        //    }
        //}

        //public DateTime Modify_Date
        //{
        //    get
        //    {
        //        return _modify_date;
        //    }
        //    set
        //    {
        //        _modify_date = value;
        //    }
        //}

        //public int Modify_Emp_ID
        //{
        //    get
        //    {
        //        return _modify_emp_id;
        //    }
        //    set
        //    {
        //        _modify_emp_id = value;
        //    }
        //}

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

        public string Dept_Name
        {
            get
            {
                return _dept_name;
            }
            set
            {
                _dept_name = value;
            }
        }
        #endregion

        public bool ModifyEmpInfo(int emp_ref_id, string loginid, string passwd, string emp_name, string position_class_code, string position_grp_code, string position_rank_code, string position_duty_code, string emp_email, string daily_phone, string cell_phone, string fax_number, short job_status, string zipcode, string addr_1, string addr_2, string sign_path, string stamp_path, short create_type, DateTime create_date, int create_emp_id, short modify_type, DateTime modify_date, int modify_emp_id)
        {
            string query = @"UPDATE	COM_EMP_INFO
                            SET	--LOGINID = @LOGINID
	                            --,PASSWD = @PASSWD
	                            --,
	                            EMP_NAME                = @EMP_NAME
	                            ,POSITION_CLASS_CODE    = @POSITION_CLASS_CODE
	                            ,POSITION_GRP_CODE      = @POSITION_GRP_CODE
	                            ,POSITION_RANK_CODE     = @POSITION_RANK_CODE
	                            ,POSITION_DUTY_CODE     = @POSITION_DUTY_CODE
	                            ,POSITION_STAT_CODE     = @POSITION_STAT_CODE
	                            ,EMP_EMail              = @EMP_EMail
	                            ,DAILY_PHONE            = @DAILY_PHONE
	                            ,CELL_PHONE             = @CELL_PHONE
	                            ,FAX_NUMBER             = @FAX_NUMBER
	                            ,JOB_STATUS             = @JOB_STATUS
	                            ,ZIPCODE                = @ZIPCODE
	                            ,ADDR_1                 = @ADDR_1
	                            ,ADDR_2                 = @ADDR_2
	                            ,SIGN_PATH              = CASE WHEN @SIGN_PATH = '' THEN SIGN_PATH ELSE @SIGN_PATH END
	                            ,STAMP_PATH             = CASE WHEN @STAMP_PATH = '' THEN STAMP_PATH ELSE @STAMP_PATH END
	                            ,CREATE_TYPE            = @CREATE_TYPE
	                            ,CREATE_DATE            = @CREATE_DATE
	                            ,CREATE_EMP_ID          = CASE WHEN @CREATE_EMP_ID = 0 THEN CREATE_EMP_ID ELSE @CREATE_EMP_ID END
	                            ,MODIFY_TYPE            = @MODIFY_TYPE
	                            ,MODIFY_DATE            = @MODIFY_DATE
	                            ,MODIFY_EMP_ID          = CASE WHEN @MODIFY_EMP_ID = 0 THEN MODIFY_EMP_ID ELSE @MODIFY_EMP_ID END
                            WHERE	EMP_REF_ID          = @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(24);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[1].Value         = loginid;
            paramArray[2]               = CreateDataParameter("@PASSWD", SqlDbType.VarChar);
            paramArray[2].Value         = passwd;
            paramArray[3]               = CreateDataParameter("@EMP_NAME", SqlDbType.VarChar);
            paramArray[3].Value         = emp_name;
            paramArray[4]               = CreateDataParameter("@POSITION_CLASS_CODE", SqlDbType.VarChar);
            paramArray[4].Value         = position_class_code;
            paramArray[5]               = CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.VarChar);
            paramArray[5].Value         = position_grp_code;
            paramArray[6]               = CreateDataParameter("@POSITION_RANK_CODE", SqlDbType.VarChar);
            paramArray[6].Value         = position_rank_code;
            paramArray[7]               = CreateDataParameter("@POSITION_DUTY_CODE", SqlDbType.VarChar);
            paramArray[7].Value         = position_duty_code;
            paramArray[8]               = CreateDataParameter("@EMP_EMail", SqlDbType.VarChar);
            paramArray[8].Value         = emp_email;
            paramArray[9]               = CreateDataParameter("@DAILY_PHONE", SqlDbType.VarChar);
            paramArray[9].Value         = daily_phone;
            paramArray[10]              = CreateDataParameter("@CELL_PHONE", SqlDbType.VarChar);
            paramArray[10].Value        = cell_phone;
            paramArray[11]              = CreateDataParameter("@FAX_NUMBER", SqlDbType.VarChar);
            paramArray[11].Value        = fax_number;
            paramArray[12]              = CreateDataParameter("@JOB_STATUS", SqlDbType.SmallInt);
            paramArray[12].Value        = job_status;
            paramArray[13]              = CreateDataParameter("@ZIPCODE", SqlDbType.VarChar);
            paramArray[13].Value        = zipcode;
            paramArray[14]              = CreateDataParameter("@ADDR_1", SqlDbType.VarChar);
            paramArray[14].Value        = addr_1;
            paramArray[15]              = CreateDataParameter("@ADDR_2", SqlDbType.VarChar);
            paramArray[15].Value        = addr_2;
            paramArray[16]              = CreateDataParameter("@SIGN_PATH", SqlDbType.VarChar);
            paramArray[16].Value        = sign_path;
            paramArray[17]              = CreateDataParameter("@STAMP_PATH", SqlDbType.VarChar);
            paramArray[17].Value        = stamp_path;
            paramArray[18]              = CreateDataParameter("@CREATE_TYPE", SqlDbType.SmallInt);
            paramArray[18].Value        = create_type;
            paramArray[19]              = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[19].Value        = create_date;
            paramArray[20]              = CreateDataParameter("@CREATE_EMP_ID", SqlDbType.Int);
            paramArray[20].Value        = create_emp_id;
            paramArray[21]              = CreateDataParameter("@MODIFY_TYPE", SqlDbType.SmallInt);
            paramArray[21].Value        = modify_type;
            paramArray[22]              = CreateDataParameter("@MODIFY_DATE", SqlDbType.DateTime);
            paramArray[22].Value        = modify_date;
            paramArray[23]              = CreateDataParameter("@MODIFY_EMP_ID", SqlDbType.Int);
            paramArray[23].Value        = modify_emp_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmpInfo(int emp_ref_id)
        {
            string query = @"SELECT	  LOGINID
		                            , LOGINIP
                                    , A.EMP_REF_ID
                                    , EMP_NAME
		                            , B.DEPT_REF_ID             AS DEPT_REF_ID
                                    , C.DePT_NAME               AS DEPT_NAME
                                    , EMP_EMail
		                            , DAILY_PHONE
		                            , CELL_PHONE
		                            , FAX_NUMBER
		                            , JOB_STATUS
		                            , ZIPCODE
		                            , ADDR_1
		                            , ADDR_2
		                            , SIGN_PATH
		                            , STAMP_PATH
                                    , POSITION_CLASS_CODE
                                    --, fn_GetPositionClass(POSITION_CLASS_CODE)	    AS POSITION_CLASS_NAME
                                    , POSITION_GRP_CODE
                                    --, fn_GetPositionGroup(POSITION_GRP_CODE)		AS POSITION_GRP_NAME
                                    , POSITION_RANK_CODE
                                    --, fn_GetPositionRank(POSITION_RANK_CODE)		AS POSITION_RANK_NAME
                                    , POSITION_DUTY_CODE
                                    --, fn_GetPositionRank(POSITION_DUTY_CODE)		AS POSITION_DUTY_NAME
                                    , POSITION_KIND_CODE
                                    , EMP_CODE
                            FROM  COM_EMP_INFO          A 
                                    JOIN REL_DEPT_EMP   B ON (A.EMP_REF_ID   = B.EMP_REF_ID)
                                    JOIN COM_DEPT_INFO  C ON (B.DEPT_REF_ID  = C.DEPT_REF_ID)
                                WHERE A.EMP_REF_ID = @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "EMPINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetEmpInfo(string loginId)
        {
//            string query = @"SELECT EMP_REF_ID
//                                    ,LOGINID
//                                    ,EMP_NAME
//                                    ,POSITION_CLASS_CODE
//                                    ,POSITION_GRP_CODE
//                                    ,POSITION_RANK_CODE
//                                    ,POSITION_DUTY_CODE
//                                    ,POSITION_KIND_CODE
//                                    ,EMP_EMail
//                                    ,DAILY_PHONE
//                                    ,CELL_PHONE
//                                    ,JOB_STATUS
//                                    ,EMP_CODE
//                                FROM COM_EMP_INFO 
//                                    WHERE UPPER(LOGINID) = UPPER(@LOGINID)";
            string query = @"SELECT	  LOGINID
		                            , LOGINIP
                                    , A.EMP_REF_ID
                                    , EMP_NAME
		                            , B.DEPT_REF_ID             AS DEPT_REF_ID
                                    , C.DePT_NAME               AS DEPT_NAME
                                    , EMP_EMail
		                            , DAILY_PHONE
		                            , CELL_PHONE
		                            , FAX_NUMBER
		                            , JOB_STATUS
		                            , ZIPCODE
		                            , ADDR_1
		                            , ADDR_2
		                            , SIGN_PATH
		                            , STAMP_PATH
                                    , POSITION_CLASS_CODE
                                    --, fn_GetPositionClass(POSITION_CLASS_CODE)	    AS POSITION_CLASS_NAME
                                    , POSITION_GRP_CODE
                                    --, fn_GetPositionGroup(POSITION_GRP_CODE)		AS POSITION_GRP_NAME
                                    , POSITION_RANK_CODE
                                    --, fn_GetPositionRank(POSITION_RANK_CODE)		AS POSITION_RANK_NAME
                                    , POSITION_DUTY_CODE
                                    --, fn_GetPositionRank(POSITION_DUTY_CODE)		AS POSITION_DUTY_NAME
                                    , POSITION_KIND_CODE
                                    , EMP_CODE
                            FROM  COM_EMP_INFO          A 
                                    JOIN REL_DEPT_EMP   B ON (A.EMP_REF_ID   = B.EMP_REF_ID)
                                    JOIN COM_DEPT_INFO  C ON (B.DEPT_REF_ID  = C.DEPT_REF_ID)
                                WHERE  UPPER(A.LOGINID) = UPPER(@LOGINID)";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[0].Value         = loginId;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "EMPINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        // 업적 부서를 가지고 옴
        public DataSet GetConEmpByDeptID(int estterm_ref_id, int estterm_sub_id, int dept_ref_id)
        {
            return GetSurveyEmpByDeptID(estterm_ref_id, estterm_sub_id, dept_ref_id, 1);
        }

        // 역량 부서를 가지고 옴
        public DataSet GetAblEmpByDeptID(int estterm_ref_id, int estterm_sub_id, int dept_ref_id) 
        {
            return GetSurveyEmpByDeptID(estterm_ref_id, estterm_sub_id, dept_ref_id, 2);
        }

        // 질의부서 부서를 가지고 옴
        public DataSet GetSurveyEmpByDeptID(int estterm_ref_id, int estterm_sub_id, int dept_ref_id, int est_type)
        {
            string query = @"SELECT A.EMP_REF_ID
                                  , A.LOGINID
			                            , A.EMP_NAME
			                            , dbo.fn_GetEstDeptID(@ESTTERM_REF_ID, A.EMP_REF_ID)													AS EST_DEPT_REF_ID
			                            , dbo.fn_GetEstDeptGroupName(@ESTTERM_REF_ID, fn_GetEstDeptID(@ESTTERM_REF_ID, A.EMP_REF_ID))		AS DEPT_NAME
			                            , A.EMP_EMail
			                            , A.POSITION_CLASS_CODE
			                            , dbo.fn_GetPositionClass(A.POSITION_CLASS_CODE)	AS POSITION_CLASS_NAME
			                            , A.POSITION_GRP_CODE
			                            , dbo.fn_GetPositionGroup(A.POSITION_GRP_CODE)		AS POSITION_GRP_NAME
			                            , A.POSITION_RANK_CODE
			                            , dbo.fn_GetPositionRank(A.POSITION_RANK_CODE)		AS POSITION_RANK_NAME
			                            , A.POSITION_DUTY_CODE
			                            , dbo.fn_GetPositionRank(A.POSITION_DUTY_CODE)		AS POSITION_DUTY_NAME
			                            , ISNULL(B.EDIDX, 0)    EDIDX
                                        , ISNULL(B.ED_NAME, '') ED_NAME
			                            , CASE WHEN B.TARGET_EMP_ID IS NULL THEN 1 ELSE 0 END ENABLED 
                            FROM 	  COM_EMP_INFO 		                                                A
                                    , (SELECT C.*, D.ED_NAME FROM EST_CON_EMP_REL C, EST_CON_DEPT_INFO D 
		                                        WHERE C.EDIDX               = D.EDIDX
			                                        AND D.ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                                    AND D.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                                                    AND D.EST_TYPE          = @EST_TYPE     ) 			B
                                WHERE       A.EMP_REF_ID                                           *= B.TARGET_EMP_ID
                                        AND fn_GetEstDeptID(@ESTTERM_REF_ID, EMP_REF_ID)       =  @DEPT_REF_ID
                                ORDER BY A.EMP_NAME
                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_sub_id;
            paramArray[2]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = dept_ref_id;
            paramArray[3]               = CreateDataParameter("@EST_TYPE", SqlDbType.Int);
            paramArray[3].Value         = est_type;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "EmpInfos", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetEmpInfoByDeptID(string dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[0].Value         = dept_ref_id;

            string query = @"SELECT a.EMP_REF_ID   
                                   ,a.EMP_CODE   
                                   ,a.LOGINID   
                                   ,a.LOGINIP   
                                   ,a.PASSWD   
                                   ,a.EMP_NAME
                                   ,a.EMP_EMail
                                   ,a.POSITION_CLASS_CODE
                                   ,a.POSITION_GRP_CODE
                                   ,a.POSITION_RANK_CODE
                                   ,a.POSITION_DUTY_CODE
                                   ,a.POSITION_STAT_CODE
                                   ,a.DAILY_PHONE
                                   ,a.CELL_PHONE
                                   ,a.FAX_NUMBER
                                   ,a.JOB_STATUS
                                   ,a.ZIPCODE
                                   ,a.ADDR_1
                                   ,a.ADDR_2
                                   ,a.SIGN_PATH
                                   ,a.STAMP_PATH
                                   ,a.CREATE_TYPE
                                   ,a.CREATE_DATE
                                   ,a.CREATE_EMP_ID
                                   ,a.MODIFY_TYPE
                                   ,a.MODIFY_DATE
                                   ,a.MODIFY_EMP_ID
                                   ,c.DEPT_REF_ID
                                   ,c.DEPT_NAME
                                   ,d.POS_CLS_NAME   POSITION_CLASS_NAME
                                   ,e.POS_GRP_NAME   POSITION_GRP_NAME   
                                   ,f.POS_RNK_NAME   POSITION_RANK_NAME   
                                   ,g.POS_DUT_NAME   POSITION_DUTY_NAME
                                   ,h.POS_KND_NAME   POSITION_KIND_NAME
                                   ,d.POS_CLS_ID
                                   ,e.POS_GRP_ID
                                   ,f.POS_RNK_ID
                                   ,g.POS_DUT_ID
                                   ,h.POS_KND_ID
                                   ,d.POS_CLS_NAME
                                   ,e.POS_GRP_NAME
                                   ,f.POS_RNK_NAME
                                   ,g.POS_DUT_NAME
                                   ,h.POS_KND_NAME
                              FROM                  COM_EMP_INFO        a   
                                    JOIN            REL_DEPT_EMP        b   ON a.EMP_REF_ID          = b.EMP_REF_ID   
                                    JOIN            COM_DEPT_INFO       c   ON b.DEPT_REF_ID         = c.DEPT_REF_ID   
                                    LEFT OUTER JOIN EST_POSITION_CLS    d   ON a.POSITION_CLASS_CODE = d.POS_CLS_ID   
                                    LEFT OUTER JOIN EST_POSITION_GRP    e   ON a.POSITION_GRP_CODE   = e.POS_GRP_ID   
                                    LEFT OUTER JOIN EST_POSITION_RNK    f   ON a.POSITION_RANK_CODE  = f.POS_RNK_ID   
                                    LEFT OUTER JOIN EST_POSITION_DUT    g   ON a.POSITION_DUTY_CODE  = g.POS_DUT_ID  
                                    LEFT OUTER JOIN EST_POSITION_KND    h   ON a.POSITION_KIND_CODE  = h.POS_KND_ID  
                             WHERE  b.REL_STATUS    = 1 
                                AND c.DEPT_FLAG     = 1
                                AND c.DEPT_REF_ID   = @DEPT_REF_ID 
                            ORDER BY a.POSITION_DUTY_CODE, a.POSITION_CLASS_CODE, a.POSITION_RANK_CODE, a.EMP_NAME";

            DataSet ds                  = DbAgentObj.FillDataSet(query, "EmpInfos", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetEmpInfoByEmpIDArr(string receiver_arr)
        {
            //IDbDataParameter[] paramArray = CreateDataParameters(1);

            //paramArray[0] = CreateDataParameter("@RECEIVER_ARR", SqlDbType.VarChar);
            //paramArray[0].Value = receiver_arr.Replace(";", ",").Substring(0, receiver_arr.Length - 1); // "1001";//receiver_arr;

            string sRECEIVER_ARR = receiver_arr.Replace(";", ",").Substring(0, receiver_arr.Length - 1);

            string s_query = @"
                                SELECT EMP_REF_ID
		                                , LOGINID
		                                , EMP_NAME
		                                , EMP_EMAIL
		                                , POSITION_CLASS_NAME
		                                , POSITION_GRP_NAME
		                                , POSITION_RANK_NAME
		                                , POSITION_DUTY_NAME
                                        , DEPT_NAME 
	                                FROM V_COM_EMPINFO_DETAIL A
		                                WHERE  A.EMP_REF_ID IN ("+sRECEIVER_ARR+@")";


            string o_query = @"
                                SELECT EMP_REF_ID
                                    , LOGINID
                                    , EMP_NAME
                                    , EMP_EMAIL
                                    , DEPT_NAME
                                    , POSITION_CLASS_NAME
                                    , POSITION_GRP_NAME
                                    , POSITION_RANK_NAME
                                    , POSITION_DUTY_NAME 
                                FROM 
                                    V_COM_EMPINFO_DETAIL 
                                    WHERE EMP_REF_ID IN (" + sRECEIVER_ARR + @")";
            //WHERE
            //    EMP_REF_ID IN ("+ receiver_arr.Replace(";",",").Substring(0,receiver_arr.Length-1) + ") ";


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "EmpInfos", null, null, CommandType.Text);
            return ds;
        }

        public DataSet GetEmpInfoByEstDeptID(int est_dept_ref_id) 
        {
            string query = @"SELECT A.*
		                            , C.*
		                            , dbo.fn_GetPositionClass(C.POSITION_CLASS_CODE) AS POSITION_CLASS_NAME
		                            , dbo.fn_GetPositionDuty(C.POSITION_DUTY_CODE) AS POSITION_DUTY_NAME
		                            , dbo.fn_GetPositionGroup(C.POSITION_GRP_CODE) AS POSITION_GRP_NAME
		                            , dbo.fn_GetPositionRank(C.POSITION_RANK_CODE) AS POSITION_RANK_NAME
                            FROM EST_DEPT_INFO A 
		                            JOIN REL_DEPT_EMP B ON (A.DEPT_REF_ID = B.DEPT_REF_ID)
		                            JOIN COM_EMP_INFO C ON (B.EMP_REF_ID = C.EMP_REF_ID)
                            WHERE A.EST_DEPT_REF_ID     = @EST_DEPT_REF_ID
                                    AND B.REL_STATUS    = 1
                            ORDER BY C.EMP_NAME";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = est_dept_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "EmpInfos", null, paramArray, CommandType.Text);
            return ds;
        }


        // 2007.08.30 [juny177] 공통 쿼리 변경 사항 없음
        public string GetRoleNamesArray(int emp_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.VarChar);
            paramArray[0].Value         = emp_ref_id;

            string query = @"
                                SELECT * 
                                  FROM COM_ROLE_INFO     A
                                     , COM_EMP_ROLE_REL  B 
                                 WHERE A.ROLE_REF_ID   = B.ROLE_REF_ID 
                                   AND B.EMP_REF_ID    = @EMP_REF_ID
                            ";

            DataSet ds                  = DbAgentObj.FillDataSet(query, "Data", null, paramArray, CommandType.Text);

            string returnStr = "";
            bool isFirst = true;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else 
                {
                    returnStr += ", ";
                }

                returnStr += ds.Tables[0].Rows[i]["ROLE_NAME"].ToString();
            }

            return returnStr;
        }

        public int ValidateLogin(string loginId)
        {
            string query = @"SELECT EMP_REF_ID 
                               FROM COM_EMP_INFO 
                              WHERE LOGINID     = @LOGINID 
                                        ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[0].Value = loginId;

            DataSet ds = DbAgentObj.Fill(query, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["EMP_REF_ID"]);
        }

        public int ValidateLogin(string loginId, string passwd) 
        {
            string query = @"SELECT EMP_REF_ID 
                               FROM COM_EMP_INFO 
                              WHERE LOGINID     = @LOGINID 
                                AND PASSWD      = @PASSWD 
                                        ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[0].Value         = loginId;
            paramArray[1]               = CreateDataParameter("@PASSWD", SqlDbType.VarChar);
            paramArray[1].Value         = passwd;

            DataSet ds = DbAgentObj.Fill(query, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["EMP_REF_ID"]);
        }



        public int ValidateLogin(string loginId, string passwd, string loginIp) 
        {
            string query = @"SELECT EMP_REF_ID 
                                FROM COM_EMP_INFO 
                                    WHERE   LOGINID     = @LOGINID 
                                        AND PASSWD      = @PASSWD 
                                        AND ( LOGINIP   = @LOGINIP OR @LOGINIP       =''    )
                                        ";
	                            
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[0].Value         = loginId;
            paramArray[1]               = CreateDataParameter("@PASSWD", SqlDbType.VarChar);
            paramArray[1].Value         = passwd;
            paramArray[2]               = CreateDataParameter("@LOGINIP", SqlDbType.VarChar);
            paramArray[2].Value         = loginIp;

            DataSet ds = DbAgentObj.Fill(query, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["EMP_REF_ID"]);
        }

        // 로그인 아이디 중복 확인
        public bool CheckLoginID(string loginId) 
        {
            string s_query = @"SELECT CASE WHEN (SELECT COUNT(*) FROM COM_EMP_INFO WHERE LOGINID=@LOGINID) >= 1 THEN 1 ELSE 0 END AS RESULT";

            string o_query = @"SELECT CASE WHEN (SELECT COUNT(*) FROM COM_EMP_INFO WHERE LOGINID=@LOGINID) >= 1 THEN 1 ELSE 0 END AS RESULT FROM DUAL";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[0].Value         = loginId;

            string result               = Convert.ToString(DbAgentObj.ExecuteScalar(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text));
            return (result == "1") ? false : true;
        }

        public DataSet GetAllEmpInfo(int emp_ref_id)
        {
            string query = @"SELECT	EMP_REF_ID
	                                ,LOGINID
	                                ,LOGINIP
	                                ,PASSWD
	                                ,EMP_NAME
	                                ,POSITION_CLASS_CODE
	                                ,POSITION_GRP_CODE
	                                ,POSITION_RANK_CODE
	                                ,POSITION_DUTY_CODE
	                                ,POSITION_STAT_CODE
                                    ,POSITION_KIND_CODE
	                                ,EMP_EMail
	                                ,DAILY_PHONE
	                                ,CELL_PHONE
	                                ,FAX_NUMBER
	                                ,JOB_STATUS
	                                ,ZIPCODE
	                                ,ADDR_1
	                                ,ADDR_2
	                                ,SIGN_PATH
	                                ,STAMP_PATH
	                                ,CREATE_TYPE
	                                ,CREATE_DATE
	                                ,CREATE_EMP_ID
	                                ,MODIFY_TYPE
	                                ,MODIFY_DATE
	                                ,MODIFY_EMP_ID
                                FROM	COM_EMP_INFO";

            DataSet ds = DbAgentObj.FillDataSet(query, "EMPINFOGETALL", null, null, CommandType.Text);
            return ds;
        }

        public bool AddEmpInfo(int emp_ref_id, string loginid, string passwd, string emp_name, string position_class_code, string position_grp_code, string position_rank_code, string position_duty_code, string emp_email, string daily_phone, string cell_phone, string fax_number, short job_status, string zipcode, string addr_1, string addr_2, string sign_path, string stamp_path, short create_type, DateTime create_date, int create_emp_id, short modify_type, DateTime modify_date, int modify_emp_id)
        {
            string query = @"INSERT INTO COM_EMP_INFO(EMP_REF_ID
			                                            ,LOGINID
			                                            ,PASSWD
			                                            ,EMP_NAME
	                                                    ,POSITION_CLASS_CODE
	                                                    ,POSITION_GRP_CODE
	                                                    ,POSITION_RANK_CODE
	                                                    ,POSITION_DUTY_CODE
	                                                    ,POSITION_STAT_CODE
			                                            ,EMP_EMail
			                                            ,DAILY_PHONE
			                                            ,CELL_PHONE
			                                            ,FAX_NUMBER
			                                            ,JOB_STATUS
			                                            ,ZIPCODE
			                                            ,ADDR_1
			                                            ,ADDR_2
			                                            ,SIGN_PATH
			                                            ,STAMP_PATH
			                                            ,CREATE_TYPE
			                                            ,CREATE_DATE
			                                            ,CREATE_EMP_ID
			                                            ,MODIFY_TYPE
			                                            ,MODIFY_DATE
			                                            ,MODIFY_EMP_ID
			                                            )
		                                            VALUES	(@EMP_REF_ID
			                                            ,@LOGINID
			                                            ,@PASSWD
			                                            ,@EMP_NAME
	                                                    ,@POSITION_CLASS_CODE
	                                                    ,@POSITION_GRP_CODE
	                                                    ,@POSITION_RANK_CODE
	                                                    ,@POSITION_DUTY_CODE
	                                                    ,@POSITION_STAT_CODE
			                                            ,@EMP_EMail
			                                            ,@DAILY_PHONE
			                                            ,@CELL_PHONE
			                                            ,@FAX_NUMBER
			                                            ,@JOB_STATUS
			                                            ,@ZIPCODE
			                                            ,@ADDR_1
			                                            ,@ADDR_2
			                                            ,@SIGN_PATH
			                                            ,@STAMP_PATH
			                                            ,@CREATE_TYPE
			                                            ,@CREATE_DATE
			                                            ,@CREATE_EMP_ID
			                                            ,@MODIFY_TYPE
			                                            ,@MODIFY_DATE
			                                            ,@MODIFY_EMP_ID
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(24);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[1].Value         = loginid;
            paramArray[2]               = CreateDataParameter("@PASSWD", SqlDbType.VarChar);
            paramArray[2].Value         = passwd;
            paramArray[3]               = CreateDataParameter("@EMP_NAME", SqlDbType.VarChar);
            paramArray[3].Value         = emp_name;
            paramArray[4]               = CreateDataParameter("@POSITION_CLASS_CODE", SqlDbType.VarChar);
            paramArray[4].Value         = position_class_code;
            paramArray[5]               = CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.VarChar);
            paramArray[5].Value         = position_grp_code;
            paramArray[6]               = CreateDataParameter("@POSITION_RANK_CODE", SqlDbType.VarChar);
            paramArray[6].Value         = position_rank_code;
            paramArray[7]               = CreateDataParameter("@POSITION_DUTY_CODE", SqlDbType.VarChar);
            paramArray[7].Value         = position_duty_code;
            paramArray[8]               = CreateDataParameter("@EMP_EMail", SqlDbType.VarChar);
            paramArray[8].Value         = emp_email;
            paramArray[9]               = CreateDataParameter("@DAILY_PHONE", SqlDbType.VarChar);
            paramArray[9].Value         = daily_phone;
            paramArray[10]              = CreateDataParameter("@CELL_PHONE", SqlDbType.VarChar);
            paramArray[10].Value        = cell_phone;
            paramArray[11]              = CreateDataParameter("@FAX_NUMBER", SqlDbType.VarChar);
            paramArray[11].Value        = fax_number;
            paramArray[12]              = CreateDataParameter("@JOB_STATUS", SqlDbType.SmallInt);
            paramArray[12].Value        = job_status;
            paramArray[13]              = CreateDataParameter("@ZIPCODE", SqlDbType.VarChar);
            paramArray[13].Value        = zipcode;
            paramArray[14]              = CreateDataParameter("@ADDR_1", SqlDbType.VarChar);
            paramArray[14].Value        = addr_1;
            paramArray[15]              = CreateDataParameter("@ADDR_2", SqlDbType.VarChar);
            paramArray[15].Value        = addr_2;
            paramArray[16]              = CreateDataParameter("@SIGN_PATH", SqlDbType.VarChar);
            paramArray[16].Value        = sign_path;
            paramArray[17]              = CreateDataParameter("@STAMP_PATH", SqlDbType.VarChar);
            paramArray[17].Value        = stamp_path;
            paramArray[18]              = CreateDataParameter("@CREATE_TYPE", SqlDbType.SmallInt);
            paramArray[18].Value        = create_type;
            paramArray[19]              = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[19].Value        = create_date;
            paramArray[20]              = CreateDataParameter("@CREATE_EMP_ID", SqlDbType.Int);
            paramArray[20].Value        = create_emp_id;
            paramArray[21]              = CreateDataParameter("@MODIFY_TYPE", SqlDbType.SmallInt);
            paramArray[21].Value        = modify_type;
            paramArray[22]              = CreateDataParameter("@MODIFY_DATE", SqlDbType.DateTime);
            paramArray[22].Value        = modify_date;
            paramArray[23]              = CreateDataParameter("@MODIFY_EMP_ID", SqlDbType.Int);
            paramArray[23].Value        = modify_emp_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveEmpInfo(int emp_ref_id)
        {
            string query = @"DELETE	COM_EMP_INFO
                                WHERE	EMP_REF_ID = @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InitEmpPasswd(int emp_ref_id, string passwd)
        {
            string query = @"UPDATE COM_EMP_INFO SET PASSWD=@PASSWD WHERE EMP_REF_ID=@EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@PASSWD", SqlDbType.VarChar);
            paramArray[1].Value         = passwd;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool HaveTeamManager(int estterm_ref_id, int est_dept_ref_id) 
        {
            string query = @"SELECT ISNULL(fn_GetTeamManagerID(@ESTTERM_REF_ID, @EST_DEPT_REF_ID), 0) EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "EmpInfos", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows[0]["EMP_REF_ID"].ToString() == "0")
                return false;

            return true;
        }


        public DataSet GetEmpInfoSearch(string searchType, string searchText, int relStatus)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
        
            paramArray[0] = CreateDataParameter("@SEARCH_TEXT", SqlDbType.VarChar);
            paramArray[0].Value = searchText +"%";
            paramArray[1] = CreateDataParameter("@REL_STATUS", SqlDbType.Int);
            paramArray[1].Value = relStatus;

            string query = string.Empty;

            if (searchType == "EMP_CODE")
            {
                query = @"SELECT a.EMP_REF_ID   
                                   ,a.EMP_CODE   
                                   ,a.LOGINID   
                                   ,a.LOGINIP   
                                   ,a.PASSWD   
                                   ,a.EMP_NAME
                                   ,a.EMP_EMail
                                   ,a.POSITION_CLASS_CODE
                                   ,a.POSITION_GRP_CODE
                                   ,a.POSITION_RANK_CODE
                                   ,a.POSITION_DUTY_CODE
                                   ,a.POSITION_STAT_CODE
                                   ,a.DAILY_PHONE
                                   ,a.CELL_PHONE
                                   ,a.FAX_NUMBER
                                   ,a.JOB_STATUS
                                   ,a.ZIPCODE
                                   ,a.ADDR_1
                                   ,a.ADDR_2
                                   ,a.SIGN_PATH
                                   ,a.STAMP_PATH
                                   ,a.CREATE_TYPE
                                   ,a.CREATE_DATE
                                   ,a.CREATE_EMP_ID
                                   ,a.MODIFY_TYPE
                                   ,a.MODIFY_DATE
                                   ,a.MODIFY_EMP_ID
                                   ,c.DEPT_REF_ID
                                   ,c.DEPT_NAME
                                   ,d.POS_CLS_NAME   POSITION_CLASS_NAME
                                   ,e.POS_GRP_NAME   POSITION_GRP_NAME   
                                   ,f.POS_RNK_NAME   POSITION_RANK_NAME   
                                   ,g.POS_DUT_NAME   POSITION_DUTY_NAME
                                   ,h.POS_KND_NAME   POSITION_KIND_NAME
                                   ,d.POS_CLS_ID
                                   ,e.POS_GRP_ID
                                   ,f.POS_RNK_ID
                                   ,g.POS_DUT_ID
                                   ,h.POS_KND_ID
                                   ,d.POS_CLS_NAME
                                   ,e.POS_GRP_NAME
                                   ,f.POS_RNK_NAME
                                   ,g.POS_DUT_NAME
                                   ,h.POS_KND_NAME
                              FROM                  COM_EMP_INFO        a   
                                    JOIN            REL_DEPT_EMP        b   ON a.EMP_REF_ID          = b.EMP_REF_ID   
                                    JOIN            COM_DEPT_INFO       c   ON b.DEPT_REF_ID         = c.DEPT_REF_ID   
                                    LEFT OUTER JOIN EST_POSITION_CLS    d   ON a.POSITION_CLASS_CODE = d.POS_CLS_ID   
                                    LEFT OUTER JOIN EST_POSITION_GRP    e   ON a.POSITION_GRP_CODE   = e.POS_GRP_ID   
                                    LEFT OUTER JOIN EST_POSITION_RNK    f   ON a.POSITION_RANK_CODE  = f.POS_RNK_ID   
                                    LEFT OUTER JOIN EST_POSITION_DUT    g   ON a.POSITION_DUTY_CODE  = g.POS_DUT_ID  
                                    LEFT OUTER JOIN EST_POSITION_KND    h   ON a.POSITION_KIND_CODE  = h.POS_KND_ID  
                             WHERE  b.REL_STATUS    = @REL_STATUS 
                                AND c.DEPT_FLAG     = 1
                                AND c.DEPT_REF_ID   = @DEPT_REF_ID 
                                AND a.EMP_CODE LIKE @SEARCH_TEXT 
                            ORDER BY a.POSITION_DUTY_CODE, a.POSITION_CLASS_CODE, a.POSITION_RANK_CODE, a.EMP_NAME";

            }
            else if (searchType == "EMP_NAME")
            {
                query = @"SELECT a.EMP_REF_ID   
                                   ,a.EMP_CODE   
                                   ,a.LOGINID   
                                   ,a.LOGINIP   
                                   ,a.PASSWD   
                                   ,a.EMP_NAME
                                   ,a.EMP_EMail
                                   ,a.POSITION_CLASS_CODE
                                   ,a.POSITION_GRP_CODE
                                   ,a.POSITION_RANK_CODE
                                   ,a.POSITION_DUTY_CODE
                                   ,a.POSITION_STAT_CODE
                                   ,a.DAILY_PHONE
                                   ,a.CELL_PHONE
                                   ,a.FAX_NUMBER
                                   ,a.JOB_STATUS
                                   ,a.ZIPCODE
                                   ,a.ADDR_1
                                   ,a.ADDR_2
                                   ,a.SIGN_PATH
                                   ,a.STAMP_PATH
                                   ,a.CREATE_TYPE
                                   ,a.CREATE_DATE
                                   ,a.CREATE_EMP_ID
                                   ,a.MODIFY_TYPE
                                   ,a.MODIFY_DATE
                                   ,a.MODIFY_EMP_ID
                                   ,c.DEPT_REF_ID
                                   ,c.DEPT_NAME
                                   ,d.POS_CLS_NAME   POSITION_CLASS_NAME
                                   ,e.POS_GRP_NAME   POSITION_GRP_NAME   
                                   ,f.POS_RNK_NAME   POSITION_RANK_NAME   
                                   ,g.POS_DUT_NAME   POSITION_DUTY_NAME
                                   ,h.POS_KND_NAME   POSITION_KIND_NAME
                                   ,d.POS_CLS_ID
                                   ,e.POS_GRP_ID
                                   ,f.POS_RNK_ID
                                   ,g.POS_DUT_ID
                                   ,h.POS_KND_ID
                                   ,d.POS_CLS_NAME
                                   ,e.POS_GRP_NAME
                                   ,f.POS_RNK_NAME
                                   ,g.POS_DUT_NAME
                                   ,h.POS_KND_NAME
                              FROM                  COM_EMP_INFO        a   
                                    JOIN            REL_DEPT_EMP        b   ON a.EMP_REF_ID          = b.EMP_REF_ID   
                                    JOIN            COM_DEPT_INFO       c   ON b.DEPT_REF_ID         = c.DEPT_REF_ID   
                                    LEFT OUTER JOIN EST_POSITION_CLS    d   ON a.POSITION_CLASS_CODE = d.POS_CLS_ID   
                                    LEFT OUTER JOIN EST_POSITION_GRP    e   ON a.POSITION_GRP_CODE   = e.POS_GRP_ID   
                                    LEFT OUTER JOIN EST_POSITION_RNK    f   ON a.POSITION_RANK_CODE  = f.POS_RNK_ID   
                                    LEFT OUTER JOIN EST_POSITION_DUT    g   ON a.POSITION_DUTY_CODE  = g.POS_DUT_ID  
                                    LEFT OUTER JOIN EST_POSITION_KND    h   ON a.POSITION_KIND_CODE  = h.POS_KND_ID  
                             WHERE  b.REL_STATUS    = @REL_STATUS 
                                AND c.DEPT_FLAG     = 1
                                AND a.EMP_NAME LIKE @SEARCH_TEXT 
                            ORDER BY a.POSITION_DUTY_CODE, a.POSITION_CLASS_CODE, a.POSITION_RANK_CODE, a.EMP_NAME";
            }


            DataSet ds = DbAgentObj.FillDataSet(query, "EmpInfos", null, paramArray, CommandType.Text);
            return ds;
        }
    }
}
