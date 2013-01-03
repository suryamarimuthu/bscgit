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
    public class Dac_Prj_QuestionPrjMap : DbAgentBase
    {
//        public int Update(IDbConnection conn
//                        , IDbTransaction trx
//                        , int estterm_ref_id
//                        , int estterm_sub_id
//                        , int estterm_step_id
//                        , string est_id
//                        , string q_obj_id
//                        , int tgt_dept_id
//                        , int tgt_emp_id
//                        , DateTime update_date
//                        , int update_user)
//        {
//            string query = @"UPDATE	EST_QUESTION_DEPT_EMP_MAP
//                                SET	 UPDATE_DATE        = @UPDATE_DATE
//                                    ,UPDATE_USER        = @UPDATE_USER
//                                WHERE	ESTTERM_REF_ID  = @ESTTERM_REF_ID
//                                    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
//                                    AND	EST_ID          = @EST_ID
//                                    AND	Q_OBJ_ID        = @Q_OBJ_ID
//                                    AND TGT_DEPT_ID     = @TGT_DEPT_ID
//                                    AND	TGT_EMP_ID      = @TGT_EMP_ID";

//            IDbDataParameter[] paramArray = CreateDataParameters(9);

//            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
//            paramArray[0].Value = estterm_ref_id;
//            paramArray[1]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
//            paramArray[1].Value = estterm_sub_id;
//            paramArray[2]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
//            paramArray[2].Value = estterm_step_id;
//            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
//            paramArray[3].Value = est_id;
//            paramArray[4]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
//            paramArray[4].Value = q_obj_id;
//            paramArray[5]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
//            paramArray[5].Value = tgt_dept_id;
//            paramArray[6]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
//            paramArray[6].Value = tgt_emp_id;
//            paramArray[7]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
//            paramArray[7].Value = update_date;
//            paramArray[8]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
//            paramArray[8].Value = update_user;

//            try
//            {
//                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
//                return affectedRow;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

     
        public DataSet Select(int comp_id
                          , int estterm_ref_id
                          , int estterm_sub_id
                          , int estterm_step_id
                          , string est_id
                          , string q_obj_id
                          , int prj_ref_id)
        {
            string query = @" SELECT  MAP.COMP_ID
                                    , MAP.ESTTERM_REF_ID
                                    , MAP.ESTTERM_SUB_ID
                                    , MAP.ESTTERM_STEP_ID
                                    , MAP.EST_ID
                                    , MAP.Q_OBJ_ID
                                    , MAP.PRJ_REF_ID
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
                                    , PI.CREATE_USER
                                    , PI.CREATE_DATE
                                    , PI.UPDATE_USER
                                    , PI.UPDATE_DATE

                                    FROM PRJ_QUESTION_PRJ_MAP MAP
                                    LEFT JOIN PRJ_INFO PI
                                    ON PI.PRJ_REF_ID = MAP.PRJ_REF_ID
                                    LEFT JOIN COM_EMP_INFO CE
                                      ON PI.OWNER_EMP_ID = CE.EMP_REF_ID
                                    LEFT JOIN COM_DEPT_INFO CD
                                      ON PI.OWNER_DEPT_ID = CD.DEPT_REF_ID
                                    LEFT JOIN COM_CODE_INFO COM
                                      ON PI.PRJ_TYPE = COM.ETC_CODE

                                    WHERE (MAP.COMP_ID          = @COMP_ID         OR @COMP_ID           = 0)
                                    AND   (MAP.ESTTERM_REF_ID   = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID    = 0)
                                    AND   (MAP.ESTTERM_SUB_ID   = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID    = 0)
                                    AND   (MAP.ESTTERM_STEP_ID  = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID  = 0)
                                    AND   (MAP.EST_ID           = @EST_ID          OR @EST_ID           =''    )
                                    AND   (MAP.Q_OBJ_ID		    = @Q_OBJ_ID        OR @Q_OBJ_ID         =''    )
                                    AND   (MAP.PRJ_REF_ID       = @PRJ_REF_ID      OR @PRJ_REF_ID       = 0) ";
                                    

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[4].Value = est_id;
            paramArray[5]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[5].Value = q_obj_id;
            paramArray[6]       = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[6].Value = prj_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "QUESTIONPRJECTMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , string est_id
                        , string q_obj_id
                        , int prj_ref_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO PRJ_QUESTION_PRJ_MAP(COMP_ID
                                                                    ,ESTTERM_REF_ID
			                                                        ,ESTTERM_SUB_ID
			                                                        ,ESTTERM_STEP_ID
			                                                        ,EST_ID
			                                                        ,Q_OBJ_ID
			                                                        ,PRJ_REF_ID
			                                                        ,CREATE_DATE
			                                                        ,CREATE_USER
			                                                        ,UPDATE_DATE
			                                                        ,UPDATE_USER
			                                                        )
		                                                        VALUES	(@COMP_ID
                                                                    ,@ESTTERM_REF_ID
			                                                        ,@ESTTERM_SUB_ID
			                                                        ,@ESTTERM_STEP_ID
			                                                        ,@EST_ID
			                                                        ,@Q_OBJ_ID
			                                                        ,@PRJ_REF_ID
			                                                        ,@CREATE_DATE
			                                                        ,@CREATE_USER
			                                                        ,NULL
			                                                        ,NULL
			                                                        )";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[4].Value = est_id;
            paramArray[5]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[5].Value = q_obj_id;
            paramArray[6]       = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[6].Value = prj_ref_id;
            paramArray[7] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[7].Value = create_date;
            paramArray[8] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[8].Value = create_user;

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
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , string est_id
                        , string q_obj_id
                        , int prj_ref_id)
        {
            string query = @"DELETE	PRJ_QUESTION_PRJ_MAP
                                WHERE   (COMP_ID            = @COMP_ID          OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND	(EST_ID             = @EST_ID           OR @EST_ID              =''    )
                                    AND	(Q_OBJ_ID           = @Q_OBJ_ID         OR @Q_OBJ_ID            =''    )
                                    AND	(PRJ_REF_ID         = @PRJ_REF_ID       OR @PRJ_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = estterm_ref_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_sub_id;
            paramArray[3]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value     = est_id;
            paramArray[4]           = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value     = q_obj_id;
            paramArray[5]           = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[5].Value     = prj_ref_id;

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

        public int Count( int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , string est_id
                        , string q_obj_id
                        , int prj_ref_id)
        {
            string query = @"SELECT COUNT(*) FROM PRJ_QUESTION_PRJ_MAP
                                WHERE	(COMP_ID            = @COMP_ID          OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND	(EST_ID             = @EST_ID           OR @EST_ID              =''    )
                                    AND	(Q_OBJ_ID           = @Q_OBJ_ID         OR @Q_OBJ_ID            =''    )
                                    AND	(PRJ_REF_ID         = @PRJ_REF_ID       OR @PRJ_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value = q_obj_id;
            paramArray[5]       = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[5].Value = prj_ref_id;

            try
            {
                return DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
