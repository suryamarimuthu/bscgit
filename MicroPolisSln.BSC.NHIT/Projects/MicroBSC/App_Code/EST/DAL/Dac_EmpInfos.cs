using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class Dac_EmpInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int emp_ref_id
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
            string query = @"UPDATE	COM_EMP_INFO
	                            SET	EMP_CODE				= @EMP_CODE
		                            ,LOGINID				= @LOGINID
		                            ,LOGINIP				= @LOGINIP
		                            ,PASSWD					= @PASSWD
		                            ,EMP_NAME				= @EMP_NAME
		                            ,EMP_EMail				= @EMP_EMail
		                            ,POSITION_CLASS_CODE	= @POSITION_CLASS_CODE
		                            ,POSITION_GRP_CODE		= @POSITION_GRP_CODE
		                            ,POSITION_RANK_CODE		= @POSITION_RANK_CODE
		                            ,POSITION_DUTY_CODE		= @POSITION_DUTY_CODE
		                            ,POSITION_STAT_CODE		= @POSITION_STAT_CODE
                                    ,POSITION_KIND_CODE		= @POSITION_KIND_CODE
		                            ,DAILY_PHONE			= @DAILY_PHONE
		                            ,CELL_PHONE				= @CELL_PHONE
		                            ,FAX_NUMBER				= @FAX_NUMBER
		                            ,JOB_STATUS				= @JOB_STATUS
		                            ,ZIPCODE				= @ZIPCODE
		                            ,ADDR_1					= @ADDR_1
		                            ,ADDR_2					= @ADDR_2
		                            ,SIGN_PATH				= @SIGN_PATH
		                            ,STAMP_PATH				= @STAMP_PATH
		                            ,CREATE_TYPE			= @CREATE_TYPE
		                            ,MODIFY_TYPE			= @MODIFY_TYPE
		                            ,MODIFY_DATE			= @MODIFY_DATE
		                            ,MODIFY_EMP_ID			= @MODIFY_EMP_ID
	                            WHERE	EMP_REF_ID			= @EMP_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(26);
         
	        paramArray[0] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = emp_ref_id;
	        paramArray[1] 		= CreateDataParameter("@EMP_CODE", SqlDbType.VarChar, 50);
	        paramArray[1].Value = emp_code;
	        paramArray[2] 		= CreateDataParameter("@LOGINID", SqlDbType.VarChar, 50);
	        paramArray[2].Value = loginid;
	        paramArray[3] 		= CreateDataParameter("@LOGINIP", SqlDbType.VarChar, 2000);
	        paramArray[3].Value = loginip;
	        paramArray[4] 		= CreateDataParameter("@PASSWD", SqlDbType.VarChar, 50);
	        paramArray[4].Value = passwd;
	        paramArray[5] 		= CreateDataParameter("@EMP_NAME", SqlDbType.VarChar, 100);
	        paramArray[5].Value = emp_name;
	        paramArray[6] 		= CreateDataParameter("@EMP_EMail", SqlDbType.VarChar, 200);
	        paramArray[6].Value = emp_email;
	        paramArray[7] 		= CreateDataParameter("@POSITION_CLASS_CODE", SqlDbType.VarChar, 20);
	        paramArray[7].Value = position_class_code;
	        paramArray[8] 		= CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.VarChar, 20);
	        paramArray[8].Value = position_grp_code;
	        paramArray[9] 		= CreateDataParameter("@POSITION_RANK_CODE", SqlDbType.VarChar, 20);
	        paramArray[9].Value = position_rank_code;
	        paramArray[10] 		= CreateDataParameter("@POSITION_DUTY_CODE", SqlDbType.VarChar, 20);
	        paramArray[10].Value= position_duty_code;
	        paramArray[11] 		= CreateDataParameter("@POSITION_STAT_CODE", SqlDbType.VarChar, 20);
	        paramArray[11].Value= position_stat_code;
            paramArray[12] 		= CreateDataParameter("@POSITION_KIND_CODE", SqlDbType.VarChar, 20);
	        paramArray[12].Value= position_kind_code;
	        paramArray[13] 		= CreateDataParameter("@DAILY_PHONE", SqlDbType.VarChar, 30);
	        paramArray[13].Value= daily_phone;
	        paramArray[14] 		= CreateDataParameter("@CELL_PHONE", SqlDbType.VarChar, 30);
	        paramArray[14].Value= cell_phone;
	        paramArray[15] 		= CreateDataParameter("@FAX_NUMBER", SqlDbType.VarChar, 30);
	        paramArray[15].Value= fax_number;
	        paramArray[16] 		= CreateDataParameter("@JOB_STATUS", SqlDbType.SmallInt);
	        paramArray[16].Value= job_status;
	        paramArray[17] 		= CreateDataParameter("@ZIPCODE", SqlDbType.VarChar, 6);
	        paramArray[17].Value= zipcode;
	        paramArray[18] 		= CreateDataParameter("@ADDR_1", SqlDbType.VarChar, 200);
	        paramArray[18].Value= addr_1;
	        paramArray[19] 		= CreateDataParameter("@ADDR_2", SqlDbType.VarChar, 200);
	        paramArray[19].Value= addr_2;
	        paramArray[20] 		= CreateDataParameter("@SIGN_PATH", SqlDbType.VarChar, 200);
	        paramArray[20].Value= sign_path;
	        paramArray[21] 		= CreateDataParameter("@STAMP_PATH", SqlDbType.VarChar, 200);
	        paramArray[21].Value= stamp_path;
	        paramArray[22] 		= CreateDataParameter("@CREATE_TYPE", SqlDbType.SmallInt);
	        paramArray[22].Value= create_type;
	        paramArray[23] 		= CreateDataParameter("@MODIFY_TYPE", SqlDbType.SmallInt);
	        paramArray[23].Value= modify_type;
	        paramArray[24] 		= CreateDataParameter("@MODIFY_DATE", SqlDbType.DateTime);
	        paramArray[24].Value= modify_date;
	        paramArray[25] 		= CreateDataParameter("@MODIFY_EMP_ID", SqlDbType.Int);
	        paramArray[25].Value= modify_emp_id;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public DataSet Select( int emp_ref_id)
        {
            string query = @"SELECT	 EMP_REF_ID
		                            ,EMP_CODE
		                            ,LOGINID
		                            ,LOGINIP
		                            ,PASSWD
		                            ,EMP_NAME
		                            ,EMP_EMail
		                            ,POSITION_CLASS_CODE
		                            ,POSITION_GRP_CODE
		                            ,POSITION_RANK_CODE
		                            ,POSITION_DUTY_CODE
		                            ,POSITION_STAT_CODE
                                    ,POSITION_KIND_CODE
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
	                            FROM	COM_EMP_INFO 
		                            WHERE	(EMP_REF_ID = @EMP_REF_ID OR @EMP_REF_ID = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[0].Value 	= emp_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "EMPINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectByDept(   int dept_ref_id
                                        , int emp_ref_id)
        {
            string query = @"SELECT   ED.DEPT_REF_ID
		                            , ED.DEPT_NAME
                                    , CE.LOGINID
		                            , CE.EMP_REF_ID
		                            , CE.EMP_NAME
		                            , PC.POS_CLS_ID
                                    , PC.POS_CLS_NAME
		                            , PD.POS_DUT_ID
                                    , PD.POS_DUT_NAME
		                            , PG.POS_GRP_ID
                                    , PG.POS_GRP_NAME
		                            , PR.POS_RNK_ID
		                            , PR.POS_RNK_NAME
                                    , PK.POS_KND_ID
		                            , PK.POS_KND_NAME
                                    , PC.POS_CLS_ID     AS TGT_POS_CLS_ID
                                    , PC.POS_CLS_NAME   AS TGT_POS_CLS_NAME
		                            , PD.POS_DUT_ID     AS TGT_POS_DUT_ID
                                    , PD.POS_DUT_NAME   AS TGT_POS_DUT_NAME
		                            , PG.POS_GRP_ID     AS TGT_POS_GRP_ID
                                    , PG.POS_GRP_NAME   AS TGT_POS_GRP_NAME
		                            , PR.POS_RNK_ID     AS TGT_POS_RNK_ID
		                            , PR.POS_RNK_NAME   AS TGT_POS_RNK_NAME
                                    , PK.POS_KND_ID     AS TGT_POS_KND_ID
		                            , PK.POS_KND_NAME   AS TGT_POS_KND_NAME

                                FROM				COM_DEPT_INFO		ED 
                                    JOIN			REL_DEPT_EMP		RD ON (ED.DEPT_REF_ID			= RD.DEPT_REF_ID)
                                    JOIN			COM_EMP_INFO		CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
		                            LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
		                            LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
		                            LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
		                            LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
                                WHERE   (ED.DEPT_REF_ID	                = @DEPT_REF_ID	    OR @DEPT_REF_ID     = 0)
		                            AND (CE.EMP_REF_ID		            = @EMP_REF_ID       OR @EMP_REF_ID      = 0)
		                            AND RD.REL_STATUS		            = 1
                                ORDER BY CE.EMP_NAME";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            paramArray[0] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = dept_ref_id;
            paramArray[1] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = emp_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "EMPINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectByDeptWithPrefix( string prefix
                                                , int estterm_ref_id
                                                , int dept_ref_id
                                                , int emp_ref_id)
        {
            string query = @"SELECT   @ESTTERM_REF_ID
                                    , ED.DEPT_REF_ID"       + " AS " + prefix + "DEPT_ID"       + @"
		                            , ED.DEPT_NAME"         + " AS " + prefix + "DEPT_NAME"     + @"
		                            , CE.EMP_REF_ID"        + " AS " + prefix + "EMP_ID"        + @"
		                            , CE.EMP_NAME"          + " AS " + prefix + "EMP_NAME"      + @"
		                            , PC.POS_CLS_ID"        + " AS " + prefix + "POS_CLS_ID"    + @"
                                    , PC.POS_CLS_NAME"      + " AS " + prefix + "POS_CLS_NAME"  + @"
		                            , PD.POS_DUT_ID"        + " AS " + prefix + "POS_DUT_ID"    + @"
                                    , PD.POS_DUT_NAME"      + " AS " + prefix + "POS_DUT_NAME"  + @"
		                            , PG.POS_GRP_ID"        + " AS " + prefix + "POS_GRP_ID"    + @"
                                    , PG.POS_GRP_NAME"      + " AS " + prefix + "POS_GRP_NAME"  + @"
		                            , PR.POS_RNK_ID"        + " AS " + prefix + "POS_RNK_ID"    + @"
		                            , PR.POS_RNK_NAME"      + " AS " + prefix + "POS_RNK_NAME"  + @"
                                    , PK.POS_KND_ID"        + " AS " + prefix + "POS_KND_ID"    + @"
		                            , PK.POS_KND_NAME"      + " AS " + prefix + "POS_KND_NAME"  + @"
                                    , CE.LOGINID
                                FROM				COM_DEPT_INFO		ED 
                                    JOIN			REL_DEPT_EMP		RD ON (ED.DEPT_REF_ID			= RD.DEPT_REF_ID)
                                    JOIN			COM_EMP_INFO		CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
		                            LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
		                            LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
		                            LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
		                            LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
                                WHERE   (ED.DEPT_REF_ID	                = @DEPT_REF_ID	    OR @DEPT_REF_ID     = 0)
		                            AND (CE.EMP_REF_ID		            = @EMP_REF_ID       OR @EMP_REF_ID      = 0)
		                            AND RD.REL_STATUS		            = 1
                                ORDER BY CE.EMP_NAME";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = estterm_ref_id;
            paramArray[1] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = dept_ref_id;
            paramArray[2] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = emp_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "EMPINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int emp_ref_id
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
            string query = @"INSERT INTO COM_EMP_INFO(EMP_REF_ID
						                            ,EMP_CODE
						                            ,LOGINID
						                            ,LOGINIP
						                            ,PASSWD
						                            ,EMP_NAME
						                            ,EMP_EMail
						                            ,POSITION_CLASS_CODE
						                            ,POSITION_GRP_CODE
						                            ,POSITION_RANK_CODE
						                            ,POSITION_DUTY_CODE
						                            ,POSITION_STAT_CODE
                                                    ,POSITION_KIND_CODE
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
						                            ,@EMP_CODE
						                            ,@LOGINID
						                            ,@LOGINIP
						                            ,@PASSWD
						                            ,@EMP_NAME
						                            ,@EMP_EMail
						                            ,@POSITION_CLASS_CODE
						                            ,@POSITION_GRP_CODE
						                            ,@POSITION_RANK_CODE
						                            ,@POSITION_DUTY_CODE
						                            ,@POSITION_STAT_CODE
                                                    ,@POSITION_KIND_CODE
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
						                            ,NULL
						                            ,NULL
						                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(26);
         
	        paramArray[0] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = emp_ref_id;
	        paramArray[1] 		= CreateDataParameter("@EMP_CODE", SqlDbType.VarChar, 50);
	        paramArray[1].Value = emp_code;
	        paramArray[2] 		= CreateDataParameter("@LOGINID", SqlDbType.VarChar, 50);
	        paramArray[2].Value = loginid;
	        paramArray[3] 		= CreateDataParameter("@LOGINIP", SqlDbType.VarChar, 2000);
	        paramArray[3].Value = loginip;
	        paramArray[4] 		= CreateDataParameter("@PASSWD", SqlDbType.VarChar, 50);
	        paramArray[4].Value = passwd;
	        paramArray[5] 		= CreateDataParameter("@EMP_NAME", SqlDbType.VarChar, 100);
	        paramArray[5].Value = emp_name;
	        paramArray[6] 		= CreateDataParameter("@EMP_EMail", SqlDbType.VarChar, 200);
	        paramArray[6].Value = emp_email;
	        paramArray[7] 		= CreateDataParameter("@POSITION_CLASS_CODE", SqlDbType.VarChar, 20);
	        paramArray[7].Value = position_class_code;
	        paramArray[8] 		= CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.VarChar, 20);
	        paramArray[8].Value = position_grp_code;
	        paramArray[9] 		= CreateDataParameter("@POSITION_RANK_CODE", SqlDbType.VarChar, 20);
	        paramArray[9].Value = position_rank_code;
	        paramArray[10] 		= CreateDataParameter("@POSITION_DUTY_CODE", SqlDbType.VarChar, 20);
	        paramArray[10].Value= position_duty_code;
	        paramArray[11] 		= CreateDataParameter("@POSITION_STAT_CODE", SqlDbType.VarChar, 20);
	        paramArray[11].Value= position_stat_code;
            paramArray[12] 		= CreateDataParameter("@POSITION_KIND_CODE", SqlDbType.VarChar, 20);
	        paramArray[12].Value= position_kind_code;
	        paramArray[13] 		= CreateDataParameter("@DAILY_PHONE", SqlDbType.VarChar, 30);
	        paramArray[13].Value= daily_phone;
	        paramArray[14] 		= CreateDataParameter("@CELL_PHONE", SqlDbType.VarChar, 30);
	        paramArray[14].Value= cell_phone;
	        paramArray[15] 		= CreateDataParameter("@FAX_NUMBER", SqlDbType.VarChar, 30);
	        paramArray[15].Value= fax_number;
	        paramArray[16] 		= CreateDataParameter("@JOB_STATUS", SqlDbType.SmallInt);
	        paramArray[16].Value= job_status;
	        paramArray[17] 		= CreateDataParameter("@ZIPCODE", SqlDbType.VarChar, 6);
	        paramArray[17].Value= zipcode;
	        paramArray[18] 		= CreateDataParameter("@ADDR_1", SqlDbType.VarChar, 200);
	        paramArray[18].Value= addr_1;
	        paramArray[19] 		= CreateDataParameter("@ADDR_2", SqlDbType.VarChar, 200);
	        paramArray[19].Value= addr_2;
	        paramArray[20] 		= CreateDataParameter("@SIGN_PATH", SqlDbType.VarChar, 200);
	        paramArray[20].Value= sign_path;
	        paramArray[21] 		= CreateDataParameter("@STAMP_PATH", SqlDbType.VarChar, 200);
	        paramArray[21].Value= stamp_path;
	        paramArray[22] 		= CreateDataParameter("@CREATE_TYPE", SqlDbType.SmallInt);
	        paramArray[22].Value= create_type;
	        paramArray[23] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[23].Value= create_date;
	        paramArray[24] 		= CreateDataParameter("@CREATE_EMP_ID", SqlDbType.Int);
	        paramArray[24].Value= create_emp_id;
	        paramArray[25] 		= CreateDataParameter("@MODIFY_TYPE", SqlDbType.SmallInt);
	        paramArray[25].Value= modify_type;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , int emp_ref_id)
        {
            string query = @"DELETE	COM_EMP_INFO
	                            WHERE	EMP_REF_ID = @EMP_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);

	        paramArray[0] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = emp_ref_id;

	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }

        #region ================================= 상대평가 그룹 관련 메소드 =================================

        public DataSet SelectRelByDept(string opt
                                    , string where_sentence
                                    , string prefix)
        {
            string query = @"SELECT * FROM (
		                                SELECT    DEPT_REF_ID AS TGT_DEPT_ID
                                                , DEPT_NAME   AS TGT_DEPT_NAME
				                                , -1          AS TGT_EMP_ID
			                                FROM COM_DEPT_INFO
                                           WHERE DEPT_FLAG = 1 
                                ) " + prefix ;

            StringBuilder sbQuery = new StringBuilder(query);

            if(!where_sentence.Trim().Equals("")) 
            {
                sbQuery.Append(" ");
                sbQuery.Append(opt);
                sbQuery.Append(" ");
                sbQuery.Append(where_sentence);
            }
            
            sbQuery.Append(" ORDER BY " + prefix + ".TGT_DEPT_NAME ");

            DataSet ds = DbAgentObj.FillDataSet(sbQuery.ToString(), "DEPTINFOGET", null, null, CommandType.Text);
            return ds;
        }

        public DataSet SelectRelByEmp(string opt
                                    , string where_sentence
                                    , string prefix)
        {
            string query = @"SELECT * FROM (
		                                SELECT    ED.DEPT_REF_ID           AS TGT_DEPT_ID
				                                , ED.DEPT_NAME             AS TGT_DEPT_NAME
				                                , CE.EMP_REF_ID            AS TGT_EMP_ID
				                                , CE.EMP_NAME              AS TGT_EMP_NAME
				                                , PC.POS_CLS_ID            AS TGT_POS_CLS_ID
				                                , PC.POS_CLS_NAME          AS TGT_POS_CLS_NAME
				                                , PD.POS_DUT_ID            AS TGT_POS_DUT_ID
				                                , PD.POS_DUT_NAME          AS TGT_POS_DUT_NAME
				                                , PG.POS_GRP_ID            AS TGT_POS_GRP_ID
				                                , PG.POS_GRP_NAME          AS TGT_POS_GRP_NAME
				                                , PR.POS_RNK_ID            AS TGT_POS_RNK_ID
				                                , PR.POS_RNK_NAME          AS TGT_POS_RNK_NAME
                                                , PK.POS_KND_ID            AS TGT_POS_KND_ID
				                                , PK.POS_KND_NAME          AS TGT_POS_KND_NAME
			                                FROM				COM_DEPT_INFO		ED 
				                                JOIN			REL_DEPT_EMP		RD ON (ED.DEPT_REF_ID			= RD.DEPT_REF_ID)
				                                JOIN			COM_EMP_INFO		CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
				                                LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
				                                LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
				                                LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
				                                LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                                LEFT OUTER JOIN	EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
                                           WHERE    RD.REL_STATUS		            = 1 
                                ) " + prefix ;

            StringBuilder sbQuery = new StringBuilder(query);

            if(!where_sentence.Trim().Equals("")) 
            {
                sbQuery.Append(" ");
                sbQuery.Append(opt);
                sbQuery.Append(" ");
                sbQuery.Append(where_sentence);
            }
            
            sbQuery.Append(" ORDER BY " + prefix + ".TGT_EMP_NAME ");

            DataSet ds = DbAgentObj.FillDataSet(sbQuery.ToString(), "EMPINFOGET", null, null, CommandType.Text);
            return ds;
        }

        #endregion
    }
}
