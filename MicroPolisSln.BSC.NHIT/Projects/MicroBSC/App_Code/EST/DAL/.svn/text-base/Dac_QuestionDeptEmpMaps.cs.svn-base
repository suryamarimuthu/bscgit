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
    public class Dac_QuestionDeptEmpMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , string est_id
                        , string q_obj_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_QUESTION_DEPT_EMP_MAP
                                SET	 UPDATE_DATE        = @UPDATE_DATE
                                    ,UPDATE_USER        = @UPDATE_USER
                                WHERE	COMP_ID         = @COMP_ID
                                    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
                                    AND	EST_ID          = @EST_ID
                                    AND	Q_OBJ_ID        = @Q_OBJ_ID
                                    AND TGT_DEPT_ID     = @TGT_DEPT_ID
                                    AND	TGT_EMP_ID      = @TGT_EMP_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
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
            paramArray[6]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value = update_date;
            paramArray[9]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
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

        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , string emp_ref_ids)
        {
            string query = @"UPDATE EST_QUESTION_DEPT_EMP_MAP
	                            SET TGT_DEPT_ID = ED.DEPT_REF_ID
                                FROM	    EST_QUESTION_DEPT_EMP_MAP   EM
		                            JOIN	        COM_DEPT_INFO		ED ON (ED.DEPT_REF_ID		    = EM.TGT_DEPT_ID)
                                    JOIN	        REL_DEPT_EMP		RD ON (EM.TGT_EMP_ID			= RD.EMP_REF_ID)
                                    JOIN	        COM_EMP_INFO	    CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
                                    JOIN            EST_QUESTION_OBJECT QO ON (EM.Q_OBJ_ID              = QO.Q_OBJ_ID)
                            WHERE   EM.COMP_ID            = @COMP_ID
                                AND EM.ESTTERM_REF_ID     = @ESTTERM_REF_ID
                                AND EM.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
                                AND CE.EMP_REF_ID IN (" + emp_ref_ids.ToString() + @")";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;

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

        public DataSet SelectEmp( int comp_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string est_id
                                , string q_obj_id
                                , int tgt_emp_id
                                , OwnerType ownerType)
        {
            string query = @"SELECT	 EM.COMP_ID
                                    ,ED.DEPT_NAME
                                    ,CE.EMP_NAME
                                    ,PC.POS_CLS_ID
                                    ,PC.POS_CLS_NAME
		                            ,PD.POS_DUT_ID
                                    ,PD.POS_DUT_NAME
		                            ,PG.POS_GRP_ID
                                    ,PG.POS_GRP_NAME
		                            ,PR.POS_RNK_ID
		                            ,PR.POS_RNK_NAME
                                    ,EM.ESTTERM_REF_ID
	                                ,EM.ESTTERM_SUB_ID
	                                ,EM.ESTTERM_STEP_ID
	                                ,EM.EST_ID
	                                ,EM.Q_OBJ_ID
                                    ,QO.Q_OBJ_NAME
	                                ,EM.TGT_DEPT_ID
	                                ,EM.TGT_EMP_ID
	                                ,EM.CREATE_DATE
	                                ,EM.CREATE_USER
	                                ,EM.UPDATE_DATE
	                                ,EM.UPDATE_USER
                                FROM	    EST_QUESTION_DEPT_EMP_MAP   EM
									JOIN	        COM_DEPT_INFO		ED ON (ED.DEPT_REF_ID		    = EM.TGT_DEPT_ID)
                                    JOIN	        REL_DEPT_EMP		RD ON (EM.TGT_EMP_ID			= RD.EMP_REF_ID)
                                    JOIN	        COM_EMP_INFO	    CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
                                    JOIN            EST_QUESTION_OBJECT QO ON (EM.Q_OBJ_ID              = QO.Q_OBJ_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
		                            LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
		                            LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
		                            LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                WHERE	(EM.COMP_ID            = @COMP_ID          OR @COMP_ID         = 0)
                                    AND (EM.ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (EM.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND	(EM.EST_ID             = @EST_ID           OR @EST_ID              =''    )
                                    AND	(EM.Q_OBJ_ID           = @Q_OBJ_ID         OR @Q_OBJ_ID            =''    )
                                    AND	(EM.TGT_EMP_ID         = @TGT_EMP_ID       OR @TGT_EMP_ID      = 0)";

            if(ownerType == OwnerType.Dept)
            {
                query += @" AND EM.TGT_EMP_ID < 0";
            }
            else if(ownerType == OwnerType.Emp_User)
            {
                query += @" AND EM.TGT_EMP_ID > 0";
            }

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value = q_obj_id;
            paramArray[5]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "QUESTIONDEPTEMPMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectDept(  int comp_id
                                  , int estterm_ref_id
                                  , int estterm_sub_id
                                  , int estterm_step_id
                                  , string est_id
                                  , string q_obj_id
                                  , int tgt_dept_id)
        {
            string query = @"SELECT  EM.COMP_ID
                                    ,ED.DEPT_NAME
                                    ,EM.ESTTERM_REF_ID
                                    ,EM.ESTTERM_SUB_ID
                                    ,EM.ESTTERM_STEP_ID
                                    ,EM.EST_ID
                                    ,EM.Q_OBJ_ID
                                    ,QO.Q_OBJ_NAME
                                    ,EM.TGT_DEPT_ID
                                    ,EM.TGT_EMP_ID
                                    ,EM.CREATE_DATE
                                    ,EM.CREATE_USER
                                    ,EM.UPDATE_DATE
                                    ,EM.UPDATE_USER
                            FROM        EST_QUESTION_DEPT_EMP_MAP   EM
                                JOIN	COM_DEPT_INFO               ED ON (ED.DEPT_REF_ID		    = EM.TGT_DEPT_ID)
                                JOIN    EST_QUESTION_OBJECT         QO ON (EM.Q_OBJ_ID              = QO.Q_OBJ_ID)
                            WHERE	    (EM.COMP_ID            = @COMP_ID          OR @COMP_ID         = 0)
                                    AND (EM.ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (EM.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND	(EM.EST_ID             = @EST_ID           OR @EST_ID              =''    )
                                    AND	(EM.Q_OBJ_ID           = @Q_OBJ_ID         OR @Q_OBJ_ID            =''    )
                                    AND	(EM.TGT_DEPT_ID        = @TGT_DEPT_ID      OR @TGT_DEPT_ID     = 0)
                                    AND  EM.TGT_EMP_ID         = -1";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value = q_obj_id;
            paramArray[5]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "QUESTIONDEPTEMPMAPGET", null, paramArray, CommandType.Text);
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
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_QUESTION_DEPT_EMP_MAP(  COMP_ID
                                                                    ,ESTTERM_REF_ID
			                                                        ,ESTTERM_SUB_ID
			                                                        ,ESTTERM_STEP_ID
			                                                        ,EST_ID
			                                                        ,Q_OBJ_ID
			                                                        ,TGT_DEPT_ID
			                                                        ,TGT_EMP_ID
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
			                                                        ,@TGT_DEPT_ID
			                                                        ,@TGT_EMP_ID
			                                                        ,@CREATE_DATE
			                                                        ,@CREATE_USER
			                                                        ,NULL
			                                                        ,NULL
			                                                        )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
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
            paramArray[6]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value = create_date;
            paramArray[9]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[9].Value = create_user;

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

        public int InsertDataFromTo(  IDbConnection conn
                                    , IDbTransaction trx
                                    , int comp_id
                                    , int estterm_ref_id_from
                                    , int estterm_sub_id_from
                                    , int estterm_ref_id_to
                                    , int estterm_sub_id_to
                                    , DateTime date
                                    , int user)
        {
            string query = @"INSERT INTO EST_QUESTION_DEPT_EMP_MAP(  COMP_ID
                                                                    ,ESTTERM_REF_ID
			                                                        ,ESTTERM_SUB_ID
			                                                        ,ESTTERM_STEP_ID
			                                                        ,EST_ID
			                                                        ,Q_OBJ_ID
			                                                        ,TGT_DEPT_ID
			                                                        ,TGT_EMP_ID
			                                                        ,CREATE_DATE
			                                                        ,CREATE_USER
			                                                        ,UPDATE_DATE
			                                                        ,UPDATE_USER
			                                                        )
                                                        SELECT    COMP_ID
		                                                        , @ESTTERM_REF_ID_TO
		                                                        , @ESTTERM_SUB_ID_TO
		                                                        , ESTTERM_STEP_ID
		                                                        , EST_ID
		                                                        , Q_OBJ_ID
		                                                        , TGT_DEPT_ID
		                                                        , TGT_EMP_ID
		                                                        , CREATE_DATE
		                                                        , CREATE_USER
		                                                        , UPDATE_DATE
		                                                        , UPDATE_USER
	                                                        FROM EST_QUESTION_DEPT_EMP_MAP
                                                                WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID_FROM
                                                                    AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID_FROM";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID_FROM", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id_from;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID_FROM", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id_from;
            paramArray[3]       = CreateDataParameter("@ESTTERM_REF_ID_TO", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id_to;
            paramArray[4]       = CreateDataParameter("@ESTTERM_SUB_ID_TO", SqlDbType.Int);
            paramArray[4].Value = estterm_sub_id_to;
            paramArray[5]       = CreateDataParameter("@DATE", SqlDbType.DateTime);
            paramArray[5].Value = date;
            paramArray[6]       = CreateDataParameter("@USER", SqlDbType.Int);
            paramArray[6].Value = user;

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
                        , int tgt_dept_id
                        , int tgt_emp_id)
        {
            string query = @"DELETE	EST_QUESTION_DEPT_EMP_MAP
                                WHERE	(COMP_ID            = @COMP_ID          OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND	(EST_ID             = @EST_ID           OR @EST_ID              =''    )
                                    AND	(Q_OBJ_ID           = @Q_OBJ_ID         OR @Q_OBJ_ID            =''    )
                                    AND	(TGT_DEPT_ID        = @TGT_DEPT_ID      OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID         = @TGT_EMP_ID       OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value = q_obj_id;
            paramArray[5]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;

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
                        , int tgt_dept_id
                        , int tgt_emp_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_QUESTION_DEPT_EMP_MAP
                                WHERE	(COMP_ID            = @COMP_ID          OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND	(EST_ID             = @EST_ID           OR @EST_ID              =''    )
                                    AND	(Q_OBJ_ID           = @Q_OBJ_ID         OR @Q_OBJ_ID            =''    )
                                    AND	(TGT_DEPT_ID        = @TGT_DEPT_ID      OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID         = @TGT_EMP_ID       OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value = q_obj_id;
            paramArray[5]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;

            try
            {
                return (int)DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectDeptByEmpList(int comp_id
                                         , int estterm_ref_id
                                         , int estterm_sub_id
                                         , string est_id
                                         , int dept_ref_id)
        {
            string query = @"
SELECT   A.DEPT_REF_ID
            , A.ESTTERM_REF_ID
            , A.DEPT_NAME
            , A.LOGINID
            , A.EMP_REF_ID
            , A.EMP_NAME
            , A.EMP_EMAIL
            , A.POS_CLS_ID
            , A.POS_DUT_ID
            , A.POS_GRP_ID
            , A.POS_RNK_ID
            , A.POS_CLS_NAME
            , A.POS_DUT_NAME
            , A.POS_GRP_NAME
            , A.POS_RNK_NAME
            , CASE  WHEN    EM.Q_OBJ_ID     IS NULL     THEN    1
                                                        ELSE    0   END ENABLED
            , EM.Q_OBJ_ID
    FROM 
    (
        SELECT    ED.DEPT_REF_ID
				, @ESTTERM_REF_ID       AS ESTTERM_REF_ID
				, ED.DEPT_NAME
				, CE.LOGINID
				, CE.EMP_REF_ID
				, CE.EMP_NAME
				, CE.EMP_EMAIL
                , PC.POS_CLS_ID
                , PD.POS_DUT_ID
                , PG.POS_GRP_ID
                , PR.POS_RNK_ID
                , PC.POS_CLS_NAME
                , PD.POS_DUT_NAME
                , PG.POS_GRP_NAME
                , PR.POS_RNK_NAME
		    FROM				COM_DEPT_INFO				ED 
				JOIN			REL_DEPT_EMP				RD ON (ED.DEPT_REF_ID			= RD.DEPT_REF_ID)
				JOIN			COM_EMP_INFO				CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
				LEFT OUTER JOIN	EST_POSITION_CLS			PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
				LEFT OUTER JOIN	EST_POSITION_DUT			PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
				LEFT OUTER JOIN	EST_POSITION_GRP			PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
				LEFT OUTER JOIN	EST_POSITION_RNK			PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
			WHERE   (   ED.DEPT_REF_ID	                = @DEPT_REF_ID      OR  @DEPT_REF_ID = 0)
				AND     RD.REL_STATUS		            = 1
    ) A
    LEFT OUTER JOIN     EST_QUESTION_DEPT_EMP_MAP   EM ON (
                                                                EM.TGT_EMP_ID       = A.EMP_REF_ID
							                                AND EM.ESTTERM_REF_ID   = @ESTTERM_REF_ID
                                                            AND EM.ESTTERM_SUB_ID   = @ESTTERM_SUB_ID
							                                AND EM.EST_ID           = @EST_ID
                                                            AND EM.COMP_ID          = @COMP_ID
						                                  ) 
    ORDER BY A.EMP_NAME
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;

            //상반기, 하반기 매핑을 따로 가져가도록 수정됨 - 이현석
            //2012.10.30
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = dept_ref_id;

            try
            {
                DataSet ds = DbAgentObj.FillDataSet(query, "QUESTIONDEPTEMPMAPGET", null, paramArray, CommandType.Text);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
