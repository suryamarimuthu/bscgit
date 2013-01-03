using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.PRJ.Dac
{
    public class Dac_Prj_EmpEstPrjMap : DbAgentBase
    {
        public int Update(IDbConnection conn
                         , IDbTransaction trx
                         , int comp_id
                         , string est_id
                         , int estterm_ref_id
                         , int estterm_sub_id
                         , int estterm_step_id
                         , int est_dept_id
                         , int est_emp_id
                         , int prj_ref_id
                         , string status_id
                         , DateTime update_date
                         , int update_user)
        {
            string query = @"UPDATE	PRJ_EMP_EST_PRJ_MAP
                                SET	STATUS_ID           = @STATUS_ID
                                    ,UPDATE_DATE        = @UPDATE_DATE
                                    ,UPDATE_USER        = @UPDATE_USER
                                WHERE	COMP_ID         = @COMP_ID
                                    AND EST_ID          = @EST_ID
                                    AND	ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND	ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
                                    AND	ESTTERM_STEP_ID = @ESTTERM_STEP_ID
                                    AND	EST_DEPT_ID     = @EST_DEPT_ID
                                    AND	EST_EMP_ID      = @EST_EMP_ID
                                    AND	PRJ_REF_ID      = @PRJ_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[6].Value = prj_ref_id;
            paramArray[7] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 12);
            paramArray[7].Value = status_id;
            paramArray[8] = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value = update_date;
            paramArray[9] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[9].Value = update_user;

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

        public DataSet Select(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int prj_ref_id)
                            
        {
            string query = @"SELECT	 MAP.COMP_ID
                                    , MAP.EST_ID
                                    , MAP.ESTTERM_REF_ID
                                    , MAP.ESTTERM_SUB_ID
                                    , MAP.ESTTERM_STEP_ID
                                    , MAP.EST_DEPT_ID
                                    , MAP.EST_EMP_ID
                                    , MAP.PRJ_REF_ID
                                    , MAP.STATUS_ID
                                    , MAP.CREATE_DATE
                                    , MAP.CREATE_USER
                                    , MAP.UPDATE_DATE
                                    , MAP.UPDATE_USER
                                    , PI.PRJ_CODE
                                    , PI.PRJ_NAME
                                    , PI.DEFINITION
                                    , PI.REF_STG
                                    , PI.EFFECTIVENESS
                                    , PI.RANGE
                                    , PI.OWNER_DEPT_ID
                                    , CD.DEPT_NAME as OWNER_DEPT_NAME
                                    , PI.OWNER_EMP_ID
                                    , CE.EMP_NAME  as OWNER_EMP_NAME
                                    , PI.REQUEST_DEPT
                                    , PI.PRIORITY
                                    , PI.TOTAL_BUDGET
                                    , PI.PRJ_TYPE
                                    , COM.CODE_NAME as PRJ_TYPE_NAME
                                    , PI.INTERESTED_PARTIES
                                    , PI.PLAN_START_DATE
                                    , PI.PLAN_END_DATE
                                    , PI.ACTUAL_START_DATE
                                    , PI.ACTUAL_END_DATE
                                    , PI.ISDELETE
                                    , CI.EMP_NAME AS EST_EMP_NAME
                                    , DI.DEPT_NAME AS EST_DEPT_NAME
                                    , ES.ESTTERM_SUB_NAME
                                    , ET.ESTTERM_STEP_NAME
                                    FROM	PRJ_EMP_EST_PRJ_MAP MAP
                                    LEFT JOIN PRJ_INFO PI
                                    ON PI.PRJ_REF_ID = MAP.PRJ_REF_ID
                                    LEFT JOIN COM_EMP_INFO CE
                                    ON PI.OWNER_EMP_ID = CE.EMP_REF_ID
                                    LEFT JOIN COM_DEPT_INFO CD
                                    ON PI.OWNER_DEPT_ID = CD.DEPT_REF_ID
                                    LEFT JOIN COM_CODE_INFO COM
                                    ON PI.PRJ_TYPE = COM.ETC_CODE 
                                    LEFT JOIN COM_EMP_INFO CI
                                    ON MAP.EST_EMP_ID = CI.EMP_REF_ID
                                    LEFT JOIN COM_DEPT_INFO DI
                                    ON MAP.EST_DEPT_ID = DI.DEPT_REF_ID
                                    JOIN EST_TERM_SUB  ES
                                    ON (MAP.COMP_ID              = ES.COMP_ID
                                    AND MAP.ESTTERM_SUB_ID       = ES.ESTTERM_SUB_ID)
                                    JOIN EST_TERM_STEP ET       
                                    ON (MAP.COMP_ID              = ET.COMP_ID
                                    AND MAP.ESTTERM_STEP_ID      = ET.ESTTERM_STEP_ID)
                                WHERE	(MAP.COMP_ID         = @COMP_ID              OR @COMP_ID                 = 0)
                                    AND (MAP.EST_ID          = @EST_ID               OR @EST_ID                      =''    )
                                    AND	(MAP.ESTTERM_REF_ID  = @ESTTERM_REF_ID       OR @ESTTERM_REF_ID          = 0)
                                    AND	(MAP.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID       OR @ESTTERM_SUB_ID          = 0)
                                    AND	(MAP.ESTTERM_STEP_ID = @ESTTERM_STEP_ID      OR @ESTTERM_STEP_ID         = 0)
                                    AND	(MAP.EST_DEPT_ID     = @EST_DEPT_ID          OR @EST_DEPT_ID             = 0)
                                    AND	(MAP.EST_EMP_ID      = @EST_EMP_ID           OR @EST_EMP_ID              = 0)
                                    AND	(MAP.PRJ_REF_ID      = @PRJ_REF_ID           OR @PRJ_REF_ID              = 0) ";

            
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value = prj_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "PRJEMPESTPRJMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int prj_ref_id
                        , string status_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO PRJ_EMP_EST_PRJ_MAP( COMP_ID
                                                                ,EST_ID
			                                                    ,ESTTERM_REF_ID
			                                                    ,ESTTERM_SUB_ID
			                                                    ,ESTTERM_STEP_ID
			                                                    ,EST_DEPT_ID
			                                                    ,EST_EMP_ID
			                                                    ,PRJ_REF_ID
			                                                    ,STATUS_ID
			                                                    ,CREATE_DATE
			                                                    ,CREATE_USER
			                                                    ,UPDATE_DATE
			                                                    ,UPDATE_USER
			                                                    )
		                                                    VALUES	(@COMP_ID
                                                                ,@EST_ID
			                                                    ,@ESTTERM_REF_ID
			                                                    ,@ESTTERM_SUB_ID
			                                                    ,@ESTTERM_STEP_ID
			                                                    ,@EST_DEPT_ID
			                                                    ,@EST_EMP_ID
			                                                    ,@PRJ_REF_ID
			                                                    ,@STATUS_ID
			                                                    ,@CREATE_DATE
			                                                    ,@CREATE_USER
			                                                    ,NULL
			                                                    ,NULL
			                                                    )";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value = prj_ref_id;
            paramArray[8] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 12);
            paramArray[8].Value = status_id;
            paramArray[9] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[9].Value = create_date;
            paramArray[10] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[10].Value = create_user;

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
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int prj_ref_id)
        {
            string query = @"DELETE	PRJ_EMP_EST_PRJ_MAP
                                WHERE	(COMP_ID         = @COMP_ID             OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID              OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID         OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID          OR @EST_EMP_ID      = 0)
                                    AND	(PRJ_REF_ID      = @PRJ_REF_ID          OR @PRJ_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value = prj_ref_id;

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

        public int Count(int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int prj_ref_id)
        {
            string query = @"SELECT COUNT(*) FROM PRJ_EMP_EST_PRJ_MAP
                                WHERE	(COMP_ID         = @COMP_ID             OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID              OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID         OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID          OR @EST_EMP_ID      = 0)
                                    AND	(PRJ_REF_ID      = @PRJ_REF_ID          OR @PRJ_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value = prj_ref_id;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}