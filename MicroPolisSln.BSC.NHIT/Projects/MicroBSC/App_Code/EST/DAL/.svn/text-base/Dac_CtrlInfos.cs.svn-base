using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class Dac_CtrlInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string ctrl_id
                        , int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int ctrl_emp_id
                        , float scope
                        , string point_grade_type
                        , string scope_unit_id
                        , string all_est_yn
                        , string all_est_dept_yn
                        , string confirm_emp_yn
                        , int ctrl_order
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_CTRL_INFO
	                            SET	 ESTTERM_REF_ID		= @ESTTERM_REF_ID
		                            ,ESTTERM_SUB_ID		= @ESTTERM_SUB_ID
		                            ,CTRL_EMP_ID		= @CTRL_EMP_ID
		                            ,SCOPE				= @SCOPE
		                            ,POINT_GRADE_TYPE	= @POINT_GRADE_TYPE
		                            ,SCOPE_UNIT_ID		= @SCOPE_UNIT_ID
                                    ,ALL_EST_YN		    = @ALL_EST_YN
                                    ,ALL_EST_DEPT_YN	= @ALL_EST_DEPT_YN
                                    ,CONFIRM_EMP_YN     = @CONFIRM_EMP_YN
		                            ,CTRL_ORDER			= @CTRL_ORDER
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID         = @COMP_ID
                                    AND CTRL_ID         = @CTRL_ID
                                    AND POINT_GRADE_TYPE= @POINT_GRADE_TYPE";

	        IDbDataParameter[] paramArray = CreateDataParameters(14);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
	        paramArray[1] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[1].Value = comp_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value = ctrl_emp_id;
	        paramArray[5] 		= CreateDataParameter("@SCOPE", SqlDbType.Float);
	        paramArray[5].Value = scope;
	        paramArray[6] 		= CreateDataParameter("@POINT_GRADE_TYPE", SqlDbType.NVarChar, 20);
	        paramArray[6].Value = point_grade_type;
	        paramArray[7] 		= CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 6);
	        paramArray[7].Value = scope_unit_id;
            paramArray[8] 		= CreateDataParameter("@ALL_EST_YN", SqlDbType.NChar);
	        paramArray[8].Value = all_est_yn;
            paramArray[9] 		= CreateDataParameter("@ALL_EST_DEPT_YN", SqlDbType.NChar);
	        paramArray[9].Value = all_est_dept_yn;
            paramArray[10] 		= CreateDataParameter("@CONFIRM_EMP_YN", SqlDbType.NChar);
	        paramArray[10].Value= confirm_emp_yn;
	        paramArray[11] 		= CreateDataParameter("@CTRL_ORDER", SqlDbType.Int);
	        paramArray[11].Value= ctrl_order;
	        paramArray[12] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[12].Value= update_date;
	        paramArray[13] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[13].Value= update_user;
         
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
         
        public DataSet Select(string ctrl_id
							, int comp_id
							, int estterm_ref_id
                            , int estterm_sub_id
                            , int ctrl_emp_id
							, string point_grade_type)
        {
            string query = @"SELECT	 ECI.CTRL_ID
									,ECI.COMP_ID
									,ECI.ESTTERM_REF_ID
									,ECI.ESTTERM_SUB_ID
									,ECI.CTRL_EMP_ID
									,CEI.EMP_NAME           AS CTRL_EMP_NAME
									,ECI.SCOPE
									,ECI.POINT_GRADE_TYPE
									,ECI.SCOPE_UNIT_ID
									,ECI.ALL_EST_YN
									,ECI.ALL_EST_DEPT_YN
                                    ,ECI.ALL_EST_EMP_YN
									,ECI.CONFIRM_EMP_YN
									,ECI.CTRL_ORDER
									,ECI.CREATE_DATE
									,ECI.CREATE_USER
									,ECI.UPDATE_DATE
									,ECI.UPDATE_USER
								FROM	 EST_CTRL_INFO ECI
									JOIN COM_EMP_INFO  CEI ON (ECI.CTRL_EMP_ID = CEI.EMP_REF_ID)
									WHERE	(COMP_ID            = @COMP_ID          OR @COMP_ID             = 0)
										AND (CTRL_ID            = @CTRL_ID          OR @CTRL_ID             = N'')
										AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID      = 0)
                                        AND (ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID      = 0)
                                        AND (CTRL_EMP_ID        = @CTRL_EMP_ID      OR @CTRL_EMP_ID         = 0)
										AND (POINT_GRADE_TYPE   = @POINT_GRADE_TYPE OR @POINT_GRADE_TYPE    = N'')";

			IDbDataParameter[] paramArray = CreateDataParameters(6);

			paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
			paramArray[1].Value = ctrl_id;
			paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
			paramArray[2].Value = estterm_ref_id;
            paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
			paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
			paramArray[4].Value = ctrl_emp_id;
			paramArray[5] 		= CreateDataParameter("@POINT_GRADE_TYPE", SqlDbType.NVarChar);
			paramArray[5].Value = point_grade_type;

			DataSet ds = DbAgentObj.FillDataSet( query, "CTRLINFOGET" , null, paramArray, CommandType.Text);
			return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string ctrl_id
                        , int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int ctrl_emp_id
                        , float scope
                        , string point_grade_type
                        , string scope_unit_id
                        , string all_est_yn
                        , string all_est_dept_yn
                        , string confirm_emp_yn
                        , int ctrl_order
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_CTRL_INFO(CTRL_ID
			                                        ,COMP_ID
			                                        ,ESTTERM_REF_ID
			                                        ,ESTTERM_SUB_ID
			                                        ,CTRL_EMP_ID
			                                        ,SCOPE
			                                        ,POINT_GRADE_TYPE
			                                        ,SCOPE_UNIT_ID
                                                    ,ALL_EST_YN
                                                    ,ALL_EST_DEPT_YN
                                                    ,CONFIRM_EMP_YN
			                                        ,CTRL_ORDER
			                                        ,CREATE_DATE
			                                        ,CREATE_USER
			                                        ,UPDATE_DATE
			                                        ,UPDATE_USER
			                                        )
		                                        VALUES	(@CTRL_ID
			                                        ,@COMP_ID
			                                        ,@ESTTERM_REF_ID
			                                        ,@ESTTERM_SUB_ID
			                                        ,@CTRL_EMP_ID
			                                        ,@SCOPE
			                                        ,@POINT_GRADE_TYPE
			                                        ,@SCOPE_UNIT_ID
                                                    ,@ALL_EST_YN
                                                    ,@ALL_EST_DEPT_YN
                                                    ,@CONFIRM_EMP_YN
			                                        ,@CTRL_ORDER
			                                        ,@CREATE_DATE
			                                        ,@CREATE_USER
			                                        ,NULL
			                                        ,NULL
			                                        )";

	        IDbDataParameter[] paramArray = CreateDataParameters(14);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
	        paramArray[1] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[1].Value = comp_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value = ctrl_emp_id;
	        paramArray[5] 		= CreateDataParameter("@SCOPE", SqlDbType.Float);
	        paramArray[5].Value = scope;
	        paramArray[6] 		= CreateDataParameter("@POINT_GRADE_TYPE", SqlDbType.NVarChar, 20);
	        paramArray[6].Value = point_grade_type;
	        paramArray[7] 		= CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 6);
	        paramArray[7].Value = scope_unit_id;
            paramArray[8] 		= CreateDataParameter("@ALL_EST_YN", SqlDbType.NChar);
	        paramArray[8].Value = all_est_yn;
            paramArray[9] 		= CreateDataParameter("@ALL_EST_DEPT_YN", SqlDbType.NChar);
	        paramArray[9].Value = all_est_dept_yn;
            paramArray[10] 		= CreateDataParameter("@CONFIRM_EMP_YN", SqlDbType.NChar);
	        paramArray[10].Value= confirm_emp_yn;
	        paramArray[11] 		= CreateDataParameter("@CTRL_ORDER", SqlDbType.Int);
	        paramArray[11].Value= ctrl_order;
	        paramArray[12] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[12].Value= create_date;
	        paramArray[13] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[13].Value= create_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query , paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string ctrl_id
                        , int comp_id
                        , string point_grade_type)
        {
            string query = @"DELETE	EST_CTRL_INFO
	                            WHERE	(COMP_ID            = @COMP_ID          OR @COMP_ID             = 0)
                                    AND (CTRL_ID            = @CTRL_ID          OR @CTRL_ID                 =''    )
                                    AND (POINT_GRADE_TYPE   = @POINT_GRADE_TYPE OR @POINT_GRADE_TYPE        =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = ctrl_id;
            paramArray[2] 		= CreateDataParameter("@POINT_GRADE_TYPE", SqlDbType.NVarChar);
	        paramArray[2].Value = point_grade_type;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query , paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}
