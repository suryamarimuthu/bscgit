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

namespace MicroBSC.Integration.PRJ.Dac
{
    public class Dac_Prj_Schedule : DbAgentBase
    {
        public Dac_Prj_Schedule()
        {
        }

        public DataTable SelectData_DB(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object estterm_step_id)
        {
            string query = @"
SELECT  COMP_ID
       ,EST_ID
       ,ESTTERM_REF_ID
       ,ESTTERM_SUB_ID
       ,ESTTERM_STEP_ID
       ,EST_DEPT_ID
       ,EST_EMP_ID
       ,TGT_DEPT_ID
       ,TGT_EMP_ID
       ,TGT_POS_CLS_ID
       ,TGT_POS_CLS_NAME
       ,TGT_POS_DUT_ID
       ,TGT_POS_DUT_NAME
       ,TGT_POS_GRP_ID
       ,TGT_POS_GRP_NAME
       ,TGT_POS_RNK_ID
       ,TGT_POS_RNK_NAME
       ,TGT_POS_KND_ID
       ,TGT_POS_KND_NAME
       ,DIRECTION_TYPE
       ,POINT_ORG
       ,POINT_ORG_DATE
       ,POINT_AVG
       ,POINT_AVG_DATE
       ,POINT_STD
       ,POINT_STD_DATE
       ,POINT_CTRL_ORG
       ,POINT_CTRL_ORG_DATE
       ,GRADE_CTRL_ORG_ID
       ,GRADE_CTRL_ORG_DATE
       ,POINT
       ,POINT_DATE
       ,GRADE_ID
       ,GRADE_DATE
       ,GRADE_TO_POINT
       ,GRADE_TO_POINT_DATE
       ,STATUS_ID
       ,STATUS_DATE
       ,CREATE_DATE
       ,CREATE_USER
FROM EST_DATA
WHERE COMP_ID           = @COMP_ID
  AND EST_ID            = @EST_ID
  AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
  AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
  AND ESTTERM_STEP_ID   = @ESTTERM_STEP_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public int DeleteWithJoin_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object year_yn
                        , object merge_yn
                        , OwnerType ownerType)
        {

            string query = @"DELETE	EST_DATA
	                            FROM        EST_DATA         ED
		                            JOIN    EST_TERM_SUB     ESU    ON	(ED.COMP_ID         = ESU.COMP_ID
									                                 AND ED.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
		                            JOIN    EST_TERM_STEP    EST    ON	(ED.COMP_ID         = EST.COMP_ID
									                                 AND ED.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
	                            WHERE	(ED.COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (ED.EST_ID          = @EST_ID          OR @EST_ID          =''  )
                                    AND	(ED.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ED.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ED.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(ED.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(ED.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(ED.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(ED.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                    AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN         ='')
                                    AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN        ='')";

            if(ownerType == OwnerType.Dept)
            {
                query += @" AND TGT_EMP_ID < 0";
            }
            else if(ownerType == OwnerType.Emp_User)
            {
                query += @" AND TGT_EMP_ID > 0";
            }

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9]       = CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
            paramArray[9].Value = year_yn;
            paramArray[10]      = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
            paramArray[10].Value= merge_yn;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id)
        {
            string query = @"
DELETE FROM EST_DATA
  WHERE COMP_ID         = @COMP_ID
  AND EST_ID            = @EST_ID
  AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
  AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID

";

           
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
          
        }

        public int SelectMaxTaskRefID(IDbConnection conn
                                    , IDbTransaction trx
                                    , object prj_ref_id)
        {
            string query = @"

SELECT TASK_REF_ID FROM PRJ_SCHEDULE
  WHERE PRJ_REF_ID         = @PRJ_REF_ID
  

";
           
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[0].Value = prj_ref_id;

            object objMax = DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text);

            int intMax = DataTypeUtility.GetToInt32(objMax) + 1;

            return intMax;
        }



        public int Insert_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object iprj_ref_id
                        , object itask_ref_id
                        , object itask_name
                        , object itask_type
                        , object iup_task_ref_id
                        , object itask_code
                        , object itask_weight
                        , object iplan_start_date
                        , object iplan_end_date
                        , object iactual_start_date
                        , object iactual_end_date
                        , object iproceed_rate
                        , object iatt_file
                        , object icomplete_yn
                        , object iisdelete
                        , object inode_depth
                        , object iafter_task_ref_id
                        , object idesction
                        , object itxr_user)
        {
            string query = @"

INSERT INTO PRJ_SCHEDULE
		(
			PRJ_REF_ID
           ,TASK_REF_ID
           ,TASK_NAME
           ,TASK_TYPE
           ,UP_TASK_REF_ID
           ,TASK_CODE
		   ,TASK_WEIGHT
           ,PLAN_START_DATE
           ,PLAN_END_DATE
           ,ACTUAL_START_DATE
           ,ACTUAL_END_DATE
           ,PROCEED_RATE
           ,ATT_FILE
           ,COMPLETE_YN
           ,ISDELETE
           ,NODE_DEPTH
           ,AFTER_TASK_REF_ID
           ,DESCTION
           ,CREATE_USER
           ,CREATE_DATE
		)
		VALUES
		(
			@iPRJ_REF_ID
           ,@iTASK_REF_ID
           ,@iTASK_NAME
           ,@iTASK_TYPE
           ,@iUP_TASK_REF_ID
           ,@iTASK_CODE
           ,@iTASK_WEIGHT
           ,@iPLAN_START_DATE
           ,@iPLAN_END_DATE
           ,@iACTUAL_START_DATE
           ,@iACTUAL_END_DATE
           ,@iPROCEED_RATE
           ,@iATT_FILE
           ,@iCOMPLETE_YN
           ,@iISDELETE
           ,@iNODE_DEPTH
           ,@iAFTER_TASK_REF_ID
           ,@iDESCTION
           ,@iTXR_USER 
           ,GETDATE()
		)

";

            IDbDataParameter[] paramArray = CreateDataParameters(20);


            paramArray[0]       = CreateDataParameter("@ITASK_REF_ID", SqlDbType.DateTime);
            paramArray[0].Value = DateTime.Now;
            paramArray[1]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2]       = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3]       = CreateDataParameter("@iTASK_NAME", SqlDbType.VarChar);
            paramArray[3].Value = itask_name;
            paramArray[4]       = CreateDataParameter("@iTASK_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = itask_type;
            paramArray[5]       = CreateDataParameter("@iTASK_WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = itask_weight;
            paramArray[6]       = CreateDataParameter("@iUP_TASK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iup_task_ref_id;
            paramArray[7]       = CreateDataParameter("@iTASK_CODE", SqlDbType.VarChar);
            paramArray[7].Value = itask_code;
            paramArray[8]       = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[8].Value = (iplan_start_date == null) ? DBNull.Value : iplan_start_date;
            paramArray[9]       = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[9].Value = (iplan_end_date == null) ? DBNull.Value : iplan_end_date;

            paramArray[10]       = CreateDataParameter("@iACTUAL_START_DATE", SqlDbType.DateTime);
            paramArray[10].Value = (iactual_start_date == null) ? DBNull.Value : iactual_start_date;
            paramArray[11]       = CreateDataParameter("@iACTUAL_END_DATE", SqlDbType.DateTime);
            paramArray[11].Value = (iactual_end_date == null) ? DBNull.Value : iactual_end_date;

            paramArray[12]       = CreateDataParameter("@iPROCEED_RATE", SqlDbType.Decimal);
            paramArray[12].Value = iproceed_rate;
            paramArray[13]       = CreateDataParameter("@iATT_FILE", SqlDbType.VarChar);
            paramArray[13].Value = iatt_file;
            paramArray[14]       = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[14].Value = icomplete_yn;
            paramArray[15]       = CreateDataParameter("@iISDELETE", SqlDbType.Char);
            paramArray[15].Value = iisdelete;
            paramArray[16]       = CreateDataParameter("@iNODE_DEPTH", SqlDbType.Int);
            paramArray[16].Value = inode_depth;
            paramArray[17]       = CreateDataParameter("@iAFTER_TASK_REF_ID", SqlDbType.Int);
            paramArray[17].Value = iafter_task_ref_id;
            paramArray[18]       = CreateDataParameter("@iDESCTION", SqlDbType.VarChar, 2000);
            paramArray[18].Value = idesction;
            paramArray[19]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[19].Value = itxr_user;
            
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
          
        }


        public int Update_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object point)
        {
            string query = @"UPDATE	EST_DATA
                                SET	 POINT                  = CASE WHEN @POINT                  IS NULL THEN POINT                  ELSE @POINT                 END
                                WHERE	(COMP_ID            = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID     = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0) ";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@POINT", SqlDbType.NVarChar);
            paramArray[5].Value     = point;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
            return affectedRow;
        }
    }
}
