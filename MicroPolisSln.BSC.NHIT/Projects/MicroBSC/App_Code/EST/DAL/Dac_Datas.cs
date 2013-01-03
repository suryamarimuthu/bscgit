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
    public class Dac_Datas : DbAgentBase
    {
        public Dac_Datas()
        {
        }

        public int UpdateGrade(IDbConnection conn
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
                            , object grade_id
                            , object grade_date
                            , object update_date
                            , object update_user)
        {
            string query = @"UPDATE	EST_DATA
                                SET	 
	                                 GRADE_ID               =  @GRADE_ID             
                                    ,GRADE_DATE             =  @GRADE_DATE           
	                                ,UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	(COMP_ID            = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID     = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID        = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID         = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID        = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID         = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value     = tgt_dept_id;
            paramArray[8]           = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value     = tgt_emp_id;
            paramArray[9]          = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[9].Value    = grade_id;
            paramArray[10]          = CreateDataParameter("@GRADE_DATE", SqlDbType.DateTime);
            paramArray[10].Value    = grade_date;
            paramArray[11]          = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[11].Value    = update_date;
            paramArray[12]          = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[12].Value    = update_user;

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

        public int UpdateCtrl(IDbConnection conn
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
                            , object grade_ctrl_org_id
                            , object grade_ctrl_org_date
                            , object grade_id
                            , object grade_date)
        {
            string query = @"UPDATE	EST_DATA
                                SET	 GRADE_CTRL_ORG_ID      =  @GRADE_CTRL_ORG_ID     
	                                ,GRADE_CTRL_ORG_DATE    =  @GRADE_CTRL_ORG_DATE  
	                                ,GRADE_ID               =  @GRADE_ID             
                                    ,GRADE_DATE             =  @GRADE_DATE
                                WHERE	(COMP_ID            = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID     = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID        = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID         = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID        = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID         = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value     = tgt_dept_id;
            paramArray[8]           = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value     = tgt_emp_id;
            paramArray[9]          = CreateDataParameter("@GRADE_CTRL_ORG_ID", SqlDbType.NVarChar);
            paramArray[9].Value    = grade_ctrl_org_id;
            paramArray[10]          = CreateDataParameter("@GRADE_CTRL_ORG_DATE", SqlDbType.DateTime);
            paramArray[10].Value    = grade_ctrl_org_date;
            paramArray[11]          = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[11].Value    = grade_id;
            paramArray[12]          = CreateDataParameter("@GRADE_DATE", SqlDbType.DateTime);
            paramArray[12].Value    = grade_date;

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
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object direction_type
                        , object point_org
                        , object point_org_date
                        , object point_avg
                        , object point_avg_date
                        , object point_std
                        , object point_std_date
                        , object point_ctrl_org
                        , object point_ctrl_org_date
                        , object grade_ctrl_org_id
                        , object grade_ctrl_org_date
                        , object point
                        , object point_date
                        , object grade_id
                        , object grade_date
                        , object grade_to_point
                        , object grade_to_point_date
                        , object status_id
                        , object status_date
                        , object update_date
                        , object update_user)
        {
            string query = @"UPDATE	EST_DATA
                                SET	 DIRECTION_TYPE         = CASE WHEN @DIRECTION_TYPE         IS NULL THEN DIRECTION_TYPE         ELSE @DIRECTION_TYPE        END
                                    ,POINT_ORG              = CASE WHEN @POINT_ORG              IS NULL THEN POINT_ORG              ELSE @POINT_ORG             END
	                                ,POINT_ORG_DATE         = CASE WHEN @POINT_ORG_DATE         IS NULL THEN POINT_ORG_DATE         ELSE @POINT_ORG_DATE        END
                                    ,POINT_AVG              = CASE WHEN @POINT_AVG              IS NULL THEN POINT_AVG              ELSE @POINT_AVG             END
	                                ,POINT_AVG_DATE         = CASE WHEN @POINT_AVG_DATE         IS NULL THEN POINT_AVG_DATE         ELSE @POINT_AVG_DATE        END
                                    ,POINT_STD              = CASE WHEN @POINT_STD              IS NULL THEN POINT_STD              ELSE @POINT_STD             END
	                                ,POINT_STD_DATE         = CASE WHEN @POINT_STD_DATE         IS NULL THEN POINT_STD_DATE         ELSE @POINT_STD_DATE        END
                                    ,POINT_CTRL_ORG         = CASE WHEN @POINT_CTRL_ORG         IS NULL THEN POINT_CTRL_ORG         ELSE @POINT_CTRL_ORG        END
	                                ,POINT_CTRL_ORG_DATE    = CASE WHEN @POINT_CTRL_ORG_DATE    IS NULL THEN POINT_CTRL_ORG_DATE    ELSE @POINT_CTRL_ORG_DATE   END
                                    ,GRADE_CTRL_ORG_ID      = CASE WHEN @GRADE_CTRL_ORG_ID      IS NULL THEN GRADE_CTRL_ORG_ID      ELSE @GRADE_CTRL_ORG_ID     END
	                                ,GRADE_CTRL_ORG_DATE    = CASE WHEN @GRADE_CTRL_ORG_DATE    IS NULL THEN GRADE_CTRL_ORG_DATE    ELSE @GRADE_CTRL_ORG_DATE   END
                                    ,POINT                  = CASE WHEN @POINT                  IS NULL THEN POINT                  ELSE @POINT                 END
	                                ,POINT_DATE             = CASE WHEN @POINT_DATE             IS NULL THEN POINT_DATE             ELSE @POINT_DATE            END
	                                ,GRADE_ID               = CASE WHEN @GRADE_ID               IS NULL THEN GRADE_ID               ELSE @GRADE_ID              END
                                    ,GRADE_DATE             = CASE WHEN @GRADE_DATE             IS NULL THEN GRADE_DATE             ELSE @GRADE_DATE            END
                                    ,GRADE_TO_POINT         = CASE WHEN @GRADE_TO_POINT         IS NULL THEN GRADE_TO_POINT         ELSE @GRADE_TO_POINT        END
                                    ,GRADE_TO_POINT_DATE    = CASE WHEN @GRADE_TO_POINT_DATE    IS NULL THEN GRADE_TO_POINT_DATE    ELSE @GRADE_TO_POINT_DATE   END
                                    ,STATUS_ID              = CASE WHEN @STATUS_ID              IS NULL THEN STATUS_ID              ELSE @STATUS_ID             END
	                                ,STATUS_DATE            = CASE WHEN @STATUS_DATE            IS NULL THEN STATUS_DATE            ELSE @STATUS_DATE           END
	                                ,UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	(COMP_ID            = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID     = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID        = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID         = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID        = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID         = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)";
            string query2 = @"UPDATE	EST_DATA
                                SET	 DIRECTION_TYPE         = nvl(@DIRECTION_TYPE,DIRECTION_TYPE)
                                    ,POINT_ORG              = NVL(@POINT_ORG,POINT_ORG)
	                                ,POINT_ORG_DATE         = NVL(@POINT_ORG_DATE,POINT_ORG_DATE)
                                    ,POINT_AVG              = NVL(@POINT_AVG,POINT_AVG)
	                                ,POINT_AVG_DATE         = NVL(@POINT_AVG_DATE,POINT_AVG_DATE)
                                    ,POINT_STD              = NVL(@POINT_STD,POINT_STD)
	                                ,POINT_STD_DATE         = NVL(@POINT_STD_DATE,POINT_STD_DATE)
                                    ,POINT_CTRL_ORG         = NVL(@POINT_CTRL_ORG,POINT_CTRL_ORG)
	                                ,POINT_CTRL_ORG_DATE    = NVL(@POINT_CTRL_ORG_DATE,POINT_CTRL_ORG_DATE)
                                    ,GRADE_CTRL_ORG_ID      = NVL(@GRADE_CTRL_ORG_ID,GRADE_CTRL_ORG_ID)
	                                ,GRADE_CTRL_ORG_DATE    = NVL(@GRADE_CTRL_ORG_DATE,GRADE_CTRL_ORG_DATE)
                                    ,POINT                  = NVL(@POINT,POINT)
	                                ,POINT_DATE             = NVL(@POINT_DATE,POINT_DATE)
	                                ,GRADE_ID               = NVL(@GRADE_ID,GRADE_ID)
                                    ,GRADE_DATE             = NVL(@GRADE_DATE,GRADE_DATE)
                                    ,GRADE_TO_POINT         = NVL(@GRADE_TO_POINT,GRADE_TO_POINT)
                                    ,GRADE_TO_POINT_DATE    = NVL(@GRADE_TO_POINT_DATE,GRADE_TO_POINT_DATE)
                                    ,STATUS_ID              = NVL(@STATUS_ID,STATUS_ID)
	                                ,STATUS_DATE            = NVL(@STATUS_DATE,STATUS_DATE)
	                                ,UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	(COMP_ID            = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID     = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID        = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID         = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID        = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID         = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(30);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value     = tgt_dept_id;
            paramArray[8]           = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value     = tgt_emp_id;
            paramArray[9]           = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.NVarChar);
            paramArray[9].Value     = direction_type;
            paramArray[10]          = CreateDataParameter("@POINT_ORG", SqlDbType.Decimal);
            paramArray[10].Value    = point_org;
            paramArray[11]          = CreateDataParameter("@POINT_ORG_DATE", SqlDbType.DateTime);
            paramArray[11].Value    = point_org_date;
            paramArray[12]          = CreateDataParameter("@POINT_AVG", SqlDbType.Decimal);
            paramArray[12].Value    = point_avg;
            paramArray[13]          = CreateDataParameter("@POINT_AVG_DATE", SqlDbType.DateTime);
            paramArray[13].Value    = point_avg_date;
            paramArray[14]          = CreateDataParameter("@POINT_STD", SqlDbType.Decimal);
            paramArray[14].Value    = point_std;
            paramArray[15]          = CreateDataParameter("@POINT_STD_DATE", SqlDbType.DateTime);
            paramArray[15].Value    = point_std_date;
            paramArray[16]          = CreateDataParameter("@POINT_CTRL_ORG", SqlDbType.Decimal);
            paramArray[16].Value    = point_ctrl_org;
            paramArray[17]          = CreateDataParameter("@POINT_CTRL_ORG_DATE", SqlDbType.DateTime);
            paramArray[17].Value    = point_ctrl_org_date;
            paramArray[18]          = CreateDataParameter("@GRADE_CTRL_ORG_ID", SqlDbType.NVarChar);
            paramArray[18].Value    = grade_ctrl_org_id;
            paramArray[19]          = CreateDataParameter("@GRADE_CTRL_ORG_DATE", SqlDbType.DateTime);
            paramArray[19].Value    = grade_ctrl_org_date;
            paramArray[20]          = CreateDataParameter("@POINT", SqlDbType.Decimal);
            paramArray[20].Value    = point;
            paramArray[21]          = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[21].Value    = point_date;
            paramArray[22]          = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[22].Value    = grade_id;
            paramArray[23]          = CreateDataParameter("@GRADE_DATE", SqlDbType.DateTime);
            paramArray[23].Value    = grade_date;
            paramArray[24]          = CreateDataParameter("@GRADE_TO_POINT", SqlDbType.NVarChar, 6);
            paramArray[24].Value    = grade_to_point;
            paramArray[25]          = CreateDataParameter("@GRADE_TO_POINT_DATE", SqlDbType.DateTime);
            paramArray[25].Value    = grade_to_point_date;
            paramArray[26]          = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[26].Value    = status_id;
            paramArray[27]          = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            paramArray[27].Value    = status_date;
            paramArray[28]          = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[28].Value    = update_date;
            paramArray[29]          = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[29].Value    = update_user;

           try
           {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(query,query2), paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 상태만 변경 하는 
        public int Update(IDbConnection conn
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
                        , object status_id
                        , object status_date
                        , object update_date
                        , object update_user)
        {
            string query = @"UPDATE	EST_DATA
                                SET	 
                                     STATUS_ID              = CASE WHEN @STATUS_ID              IS NULL THEN STATUS_ID              ELSE @STATUS_ID             END
	                                ,STATUS_DATE            = CASE WHEN @STATUS_ID              IS NULL THEN STATUS_DATE            ELSE GETDATE()              END
	                                ,UPDATE_DATE            = GETDATE()
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	(COMP_ID            = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID     = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID        = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID         = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID        = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID         = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value     = tgt_dept_id;
            paramArray[8]           = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value     = tgt_emp_id;
            paramArray[9]          = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[9].Value    = status_id;
            //paramArray[10]          = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            //paramArray[10].Value    = status_date;
            //paramArray[11]          = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            //paramArray[11].Value    = update_date;
            paramArray[10]          = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[10].Value    = update_user;

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
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object direction_type
                        , object point_org
                        , object point_org_date
                        , object point
                        , object point_date
                        , object status_id
                        , object status_date
                        , object update_date
                        , object update_user)
        {
            string query = @"UPDATE	EST_DATA
                                SET	 DIRECTION_TYPE         = CASE WHEN @DIRECTION_TYPE         IS NULL THEN DIRECTION_TYPE         ELSE @DIRECTION_TYPE        END
                                    ,UPDATE_DATE            = GETDATE()
	                                ,UPDATE_USER            = @UPDATE_USER
";
            string query_point_org = @"
                                    ,POINT_ORG              = CASE WHEN @POINT_ORG              IS NULL THEN POINT_ORG              ELSE @POINT_ORG             END
	                                ,POINT_ORG_DATE         = CASE WHEN @POINT_ORG              IS NULL THEN POINT_ORG_DATE         ELSE GETDATE()              END
";

            string query_point = @"
                                    ,POINT                  = CASE WHEN @POINT                  IS NULL THEN POINT                  ELSE @POINT                 END
	                                ,POINT_DATE             = CASE WHEN @POINT                  IS NULL THEN POINT_DATE             ELSE GETDATE()              END
";

            string query_tail = @"
                                    ,STATUS_ID              = CASE WHEN @STATUS_ID              IS NULL THEN STATUS_ID              ELSE @STATUS_ID             END
	                                ,STATUS_DATE            = CASE WHEN @STATUS_ID              IS NULL THEN STATUS_DATE            ELSE GETDATE()              END
                                WHERE	(COMP_ID            = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID     = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID        = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID         = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID        = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID         = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
";
            int i = 0;
            int j = 0;

            if (point != DBNull.Value || DataTypeUtility.GetToInt32(point) == -1)
            {
                query += query_point;
                i++;
            }

            if (point_org != DBNull.Value || DataTypeUtility.GetToInt32(point_org) == -1)
            {
                query += query_point_org;
                j++;
            }

            query += query_tail;


            IDbDataParameter[] paramArray = CreateDataParameters(12 + i + j);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value     = tgt_dept_id;
            paramArray[8]           = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value     = tgt_emp_id;
            paramArray[9]           = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.NVarChar);
            paramArray[9].Value     = direction_type;
            paramArray[10]          = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[10].Value    = update_user;
            paramArray[11]          = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[11].Value    = status_id;

            if (i > 0)
            {
                paramArray[11 + i]              = CreateDataParameter("@POINT", SqlDbType.Decimal);
                paramArray[11 + i].Value        = point;
            }

            if (j > 0)
            {
                paramArray[11 + i + j]          = CreateDataParameter("@POINT_ORG", SqlDbType.Decimal);
                paramArray[11 + i + j].Value    = point_org;
            }
            
            

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
                        , object comp_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object emp_ref_ids
                        , string type)
        {
            string query = "";

            if(type.Equals("POS"))
                query = @"UPDATE EST_DATA
	                            SET  TGT_POS_CLS_ID		= PC.POS_CLS_ID
		                            ,TGT_POS_CLS_NAME	= PC.POS_CLS_NAME
		                            ,TGT_POS_DUT_ID		= PD.POS_DUT_ID
		                            ,TGT_POS_DUT_NAME	= PD.POS_DUT_NAME
		                            ,TGT_POS_GRP_ID		= PG.POS_GRP_ID
		                            ,TGT_POS_GRP_NAME	= PG.POS_GRP_NAME
		                            ,TGT_POS_RNK_ID		= PR.POS_RNK_ID
		                            ,TGT_POS_RNK_NAME	= PR.POS_RNK_NAME
		                            ,TGT_POS_KND_ID		= PK.POS_KND_ID
		                            ,TGT_POS_KND_NAME	= PK.POS_KND_NAME
                                FROM				COM_DEPT_INFO		DI 
	                                JOIN			REL_DEPT_EMP		RD ON (DI.DEPT_REF_ID			= RD.DEPT_REF_ID)
	                                JOIN			COM_EMP_INFO		CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
                                    LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
                                    LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
                                    LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
		                            JOIN			EST_DATA			ED ON (CE.EMP_REF_ID			= ED.TGT_EMP_ID)
	                            WHERE		ED.COMP_ID			= @COMP_ID
			                            AND ED.ESTTERM_REF_ID	= @ESTTERM_REF_ID
			                            AND ED.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
			                            AND CE.EMP_REF_ID IN (" + emp_ref_ids.ToString() + ")";
            else if(type.Equals("DPT"))
                query = @"UPDATE EST_DATA
	                            SET  TGT_DEPT_ID        = DI.DEPT_REF_ID
                                FROM				COM_DEPT_INFO		DI 
	                                JOIN			REL_DEPT_EMP		RD ON (DI.DEPT_REF_ID			= RD.DEPT_REF_ID)
	                                JOIN			COM_EMP_INFO		CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
                                    LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
                                    LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
                                    LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
		                            JOIN			EST_DATA			ED ON (CE.EMP_REF_ID			= ED.TGT_EMP_ID)
	                            WHERE		ED.COMP_ID			= @COMP_ID
			                            AND ED.ESTTERM_REF_ID	= @ESTTERM_REF_ID
			                            AND ED.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
			                            AND CE.EMP_REF_ID IN (" + emp_ref_ids.ToString() + ")";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = estterm_ref_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_sub_id;

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

        public int UpdateConfirmBias( IDbConnection conn
                                    , IDbTransaction trx
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string bias_type_id
                                    , string dept_values
                                    , DateTime update_date
                                    , int update_user)
        {
            string query = string.Format(@"UPDATE	EST_DATA
                                                SET	 POINT               = POINT_{0}
	                                                ,POINT_DATE          = @UPDATE_DATE
	                                                ,UPDATE_DATE         = @UPDATE_DATE
	                                                ,UPDATE_USER         = @UPDATE_USER
                                                WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                                    AND (EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                                    {1}"
                                        , bias_type_id
                                        , (dept_values.Trim().Equals("")) ? "" : string.Format("AND TGT_DEPT_ID IN ({0})", dept_values));

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[5].Value     = update_date;
            paramArray[6]           = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[6].Value     = update_user;

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

        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx
                            , int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , string year_yn
                            , string merge_yn
                            , OwnerType ownerType)
        {
            string query = @"SELECT	 ED.COMP_ID
                                    ,ED.EST_ID
	                                ,ED.ESTTERM_REF_ID
	                                ,ED.ESTTERM_SUB_ID
	                                ,ED.ESTTERM_STEP_ID
	                                ,ED.EST_DEPT_ID
	                                ,ED.EST_EMP_ID
	                                ,ED.TGT_DEPT_ID
	                                ,ED.TGT_EMP_ID
                                    ,ED.TGT_POS_CLS_ID
                                    ,ED.TGT_POS_CLS_NAME
                                    ,ED.TGT_POS_DUT_ID
                                    ,ED.TGT_POS_DUT_NAME
                                    ,ED.TGT_POS_GRP_ID
                                    ,ED.TGT_POS_GRP_NAME
                                    ,ED.TGT_POS_RNK_ID
                                    ,ED.TGT_POS_RNK_NAME
                                    ,ED.TGT_POS_KND_ID
                                    ,ED.TGT_POS_KND_NAME
                                    ,DIRECTION_TYPE
	                                ,ED.POINT_ORG
	                                ,ED.POINT_ORG_DATE
                                    ,ED.POINT_AVG
	                                ,ED.POINT_AVG_DATE
                                    ,ED.POINT_STD
	                                ,ED.POINT_STD_DATE
                                    ,ED.POINT_CTRL_ORG
                                    ,ED.POINT_CTRL_ORG_DATE
                                    ,ED.GRADE_CTRL_ORG_ID
                                    ,ED.GRADE_CTRL_ORG_DATE
                                    ,ED.POINT
	                                ,ED.POINT_DATE
	                                ,ED.GRADE_ID
                                    ,ED.GRADE_DATE
                                    ,ED.GRADE_TO_POINT
                                    ,ED.GRADE_TO_POINT_DATE
                                    ,ED.STATUS_ID
	                                ,ED.STATUS_DATE
	                                ,ED.CREATE_DATE
	                                ,ED.CREATE_USER
	                                ,ED.UPDATE_DATE
	                                ,ED.UPDATE_USER
                                FROM	    EST_DATA              ED
                                    JOIN    EST_TERM_SUB          ESU    ON	(ED.COMP_ID         = ESU.COMP_ID
                                                                         AND ED.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
                                    JOIN    EST_TERM_STEP         EST    ON	(ED.COMP_ID         = EST.COMP_ID
                                                                         AND ED.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
                                    WHERE	(ED.COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                        AND (ED.EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                        AND	(ED.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                        AND	(ED.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                        AND	(ED.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                        AND	(ED.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                        AND	(ED.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                        AND	(ED.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                        AND	(ED.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                        AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN             =''    )
                                        AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN            =''    )";

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

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        #region ================================= 상대평가 그룹설정 =================================

        public DataSet Select(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string opt
                            , string where_sentence)
        {
            string query = @"
                          SELECT	 TM.COMP_ID
                                    ,TM.EST_ID
	                                ,TM.ESTTERM_REF_ID
	                                ,TM.ESTTERM_SUB_ID
                                    ,ES.ESTTERM_SUB_NAME
	                                ,TM.ESTTERM_STEP_ID
                                    ,ET.ESTTERM_STEP_NAME
	                                ,TM.EST_DEPT_ID
                                    ,ED1.DEPT_NAME              AS EST_DEPT_NAME
	                                ,TM.EST_EMP_ID
                                    ,CE1.EMP_NAME               AS EST_EMP_NAME
                                    ,CE1.POSITION_CLASS_CODE    AS EST_POS_CLS_ID
                                    ,PC.POS_CLS_NAME            AS EST_POS_CLS_NAME
		                            ,CE1.POSITION_DUTY_CODE     AS EST_POS_DUT_ID
                                    ,PD.POS_DUT_NAME            AS EST_POS_DUT_NAME
		                            ,CE1.POSITION_GRP_CODE      AS EST_POS_GRP_ID
                                    ,PG.POS_GRP_NAME            AS EST_POS_GRP_NAME
		                            ,CE1.POSITION_RANK_CODE     AS EST_POS_RNK_ID
		                            ,PR.POS_RNK_NAME            AS EST_POS_RNK_NAME
                                    ,CE1.POSITION_KIND_CODE     AS EST_POS_KND_ID
		                            ,PK.POS_KND_NAME            AS EST_POS_KND_NAME
	                                ,TM.TGT_DEPT_ID
                                    ,ED2.DEPT_NAME              AS TGT_DEPT_NAME
	                                ,TM.TGT_EMP_ID
                                    ,CE2.EMP_NAME               AS TGT_EMP_NAME
                                    ,TM.TGT_POS_CLS_ID
                                    ,TM.TGT_POS_CLS_NAME
		                            ,TM.TGT_POS_DUT_ID
                                    ,TM.TGT_POS_DUT_NAME
		                            ,TM.TGT_POS_GRP_ID
                                    ,TM.TGT_POS_GRP_NAME
		                            ,TM.TGT_POS_RNK_ID
		                            ,TM.TGT_POS_RNK_NAME
                                    ,TM.TGT_POS_KND_ID
		                            ,TM.TGT_POS_KND_NAME
                                    ,TM.DIRECTION_TYPE
	                                ,TM.STATUS_ID
	                                ,TM.CREATE_DATE
	                                ,TM.CREATE_USER
	                                ,TM.UPDATE_DATE
	                                ,TM.UPDATE_USER
                                FROM	            EST_DATA               TM
                                    LEFT OUTER JOIN COM_DEPT_INFO          ED1      ON (TM.EST_DEPT_ID          = ED1.DEPT_REF_ID)
                                    LEFT OUTER JOIN COM_DEPT_INFO          ED2      ON (TM.TGT_DEPT_ID          = ED2.DEPT_REF_ID)
                                    LEFT OUTER JOIN COM_EMP_INFO           CE1      ON (TM.EST_EMP_ID           = CE1.EMP_REF_ID)
                                    LEFT OUTER JOIN COM_EMP_INFO           CE2      ON (TM.TGT_EMP_ID           = CE2.EMP_REF_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	   PC       ON (CE1.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
		                            LEFT OUTER JOIN	EST_POSITION_DUT	   PD       ON (CE1.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
		                            LEFT OUTER JOIN	EST_POSITION_GRP	   PG       ON (CE1.POSITION_GRP_CODE	= PG.POS_GRP_ID)
		                            LEFT OUTER JOIN	EST_POSITION_RNK	   PR       ON (CE1.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	   PK       ON (CE1.POSITION_KIND_CODE	= PK.POS_KND_ID)
                                    JOIN            EST_TERM_STEP          ET       ON (TM.COMP_ID              = ET.COMP_ID
                                                                                    AND TM.ESTTERM_STEP_ID      = ET.ESTTERM_STEP_ID)                                    
                                    JOIN EST_TERM_SUB                      ES       ON (TM.ESTTERM_SUB_ID       = ES.ESTTERM_SUB_ID)
                                WHERE	(TM.COMP_ID            = @COMP_ID              OR @COMP_ID                 = 0)
                                  AND   (TM.EST_ID             = @EST_ID               OR @EST_ID                      =''    )
                                  AND   (TM.ESTTERM_REF_ID     = @ESTTERM_REF_ID       OR @ESTTERM_REF_ID          = 0) 
                                  AND   (ES.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID       OR @ESTTERM_SUB_ID          = 0)
                                  AND   (ET.ESTTERM_STEP_ID    = @ESTTERM_STEP_ID      OR @ESTTERM_STEP_ID         = 0)";

            StringBuilder sbQuery = new StringBuilder(query);

            if(!where_sentence.Trim().Equals("")) 
            {
                sbQuery.Append("");
                sbQuery.Append(opt);
                sbQuery.Append("");
                sbQuery.Append(where_sentence);
            }

            IDbDataParameter[] paramArray = CreateDataParameters(5);

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
            
            DataSet ds = DbAgentObj.FillDataSet(sbQuery.ToString(), "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        #endregion

        // Bias 조정에서 쓰이는 쿼리
        public string SelectBiasDataScript(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string bias_type
                                        , string dept_values)
        {
            string query = string.Format(@"SELECT ED.EST_EMP_ID
	                                            , CE.EMP_NAME                   AS EST_EMP_NAME
	                                            , ROUND(MAX(ED.POINT_{0}), 2)	AS PNT_MAX
	                                            , ROUND(MIN(ED.POINT_{0}), 2)	AS PNT_MIN
	                                            , ROUND(AVG(ED.POINT_{0}), 2)	AS PNT_AVG
	                                            , COUNT(ED.TGT_DEPT_ID)			AS PNT_CNT
                                            FROM		EST_DATA		ED 
	                                            JOIN	COM_EMP_INFO	CE ON (ED.EST_EMP_ID = CE.EMP_REF_ID)
                                            WHERE	(ED.COMP_ID         = {1}   OR {1}   = 0)
                                                AND (ED.EST_ID          = '{2}' OR '{2}'     =''    )
                                                AND	(ED.ESTTERM_REF_ID  = {3}   OR {3}   = 0)
                                                AND	(ED.ESTTERM_SUB_ID  = {4}   OR {4}   = 0)
                                                AND	(ED.ESTTERM_STEP_ID = {5}   OR {5}   = 0)
                                                {6}
                                            GROUP BY  ED.EST_EMP_ID
		                                            , CE.EMP_NAME
                                            ORDER BY CE.EMP_NAME"
                                        , bias_type
                                        , comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , (dept_values == null || dept_values.Equals("")) ? "" : string.Format("AND TGT_DEPT_ID IN ({0})", dept_values));

            return query;
        }



        // Bias 조정에서 쓰이는 쿼리를 Infragistics 차트에서 사용하기 위해서
        // DataTable로 반환한다.
        // 2010-04-29 => 이승주
        public DataTable SelectBiasData(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string bias_type
                                        , string dept_values)
        {
            string query = string.Format(@"SELECT ED.EST_EMP_ID
	                                            , CE.EMP_NAME                   AS EST_EMP_NAME
	                                            , ROUND(MAX(ED.POINT_{0}), 2)	AS PNT_MAX
	                                            , ROUND(MIN(ED.POINT_{0}), 2)	AS PNT_MIN
	                                            , ROUND(AVG(ED.POINT_{0}), 2)	AS PNT_AVG
	                                            , COUNT(ED.TGT_DEPT_ID)			AS PNT_CNT
                                            FROM		EST_DATA		ED 
	                                            JOIN	COM_EMP_INFO	CE ON (ED.EST_EMP_ID = CE.EMP_REF_ID)
                                            WHERE	(ED.COMP_ID         = {1}   OR {1}   = 0)
                                                AND (ED.EST_ID          = '{2}' OR '{2}'     =''    )
                                                AND	(ED.ESTTERM_REF_ID  = {3}   OR {3}   = 0)
                                                AND	(ED.ESTTERM_SUB_ID  = {4}   OR {4}   = 0)
                                                AND	(ED.ESTTERM_STEP_ID = {5}   OR {5}   = 0)
                                                {6}
                                            GROUP BY  ED.EST_EMP_ID
		                                            , CE.EMP_NAME
                                            ORDER BY CE.EMP_NAME"
                                        , bias_type
                                        , comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , (dept_values == null || dept_values.Equals("")) ? "" : string.Format("AND TGT_DEPT_ID IN ({0})", dept_values));

            DataSet ds = DbAgentObj.FillDataSet(query, "DATA", null, null, CommandType.Text);
            return ds.Tables[0];
        }

        #region --BSC_PERSON_EVALUATION

        public DataTable GetEvaluationScoreInfo(int estterm_ref_id)
        {
            /* 2011-05-06 수정 : BSC_EST_DEPT_ORG_SCORE_INFO테이블에서 BSC_EST_STDDEV_GRADE 테이블로 데이터 변경
            string query = @"SELECT   SCORE_CODE
                                    , SCORE_NAME
                                    , MIN_VALUE
                                    , MAX_VALUE
                            FROM    BSC_EST_DEPT_ORG_SCORE_INFO
                            WHERE   ESTTERM_REF_ID      =   @ESTTERM_REF_ID ";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            */
            string query = @"SELECT   SCORE_CODE
                                    , SCORE_NAME
                                    , MIN_VALUE
                                    , MAX_VALUE
                            FROM    BSC_EST_STDDEV_GRADE";
            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, null, CommandType.Text);

            return ds.Tables[0];
        }

        public DataSet SelectPersonEavluation(int comp_id
                                    , int estterm_ref_id
                                    , string iymd)
        {
            string query = @"SELECT   RDE.EMP_REF_ID
                                    , EDI.EST_DEPT_REF_ID
                                    , EDI.DEPT_NAME
                                    , EPG.POS_GRP_ID
                                    , EPG.POS_GRP_NAME
                                    , EPC.POS_CLS_ID
                                    , EPC.POS_CLS_NAME
                                    , CEI.EMP_CODE
                                    , CEI.EMP_NAME
                                    , ISNULL(BPE.ORGANIZATION_POINT, 0)      AS ORGANIZATION_POINT
                                    , ISNULL(BPE.ORGANIZATION_WEIGHT, 0)     AS ORGANIZATION_WEIGHT
                                    , ISNULL(BPE.APPRAISAL_POINT, 0)         AS APPRAISAL_POINT
                                    , ISNULL(BPE.APPRAISAL_WEIGHT, 0)        AS APPRAISAL_WEIGHT
                                    , ISNULL(BPE.OTHERS1_POINT, 0)           AS OTHERS1_POINT
                                    , ISNULL(BPE.OTHERS1_WEIGHT, 0)          AS OTHERS1_WEIGHT
                                    , ISNULL(BPE.OTHERS2_POINT, 0)           AS OTHERS2_POINT
                                    , ISNULL(BPE.OTHERS2_WEIGHT, 0)          AS OTHERS2_WEIGHT
                                    , ISNULL(BPE.OTHERS3_POINT, 0)           AS OTHERS3_POINT
                                    , ISNULL(BPE.OTHERS3_WEIGHT, 0)          AS OTHERS3_WEIGHT
                                    , ISNULL(BPE.WEIGHT_SUM, 0)              AS WEIGHT_SUM
                                    , ISNULL(BPE.POINT_SUM, 0)               AS POINT_SUM
                                    , ISNULL(BPE.STANDARD_SCORE, 0)          AS STANDARD_SCORE
                                    , ISNULL(BPE.STANDARD_RATING, 0)         AS STANDARD_RATING
                                FROM                EST_DEPT_INFO           EDI
                                    INNER JOIN COM_DEPT_INFO                CDI     ON  CDI.DEPT_REF_ID     =   EDI.DEPT_REF_ID
                                                                                    AND CDI.DEPT_FLAG       =   1
                                    INNER JOIN REL_DEPT_EMP                 RDE     ON  RDE.DEPT_REF_ID     =   EDI.DEPT_REF_ID
                                                                                    AND RDE.REL_STATUS      =   1
                                    LEFT OUTER JOIN COM_EMP_INFO            CEI     ON  CEI.EMP_REF_ID      =   RDE.EMP_REF_ID
                                    LEFT OUTER JOIN EST_POSITION_GRP        EPG     ON  EPG.POS_GRP_ID      =   CEI.POSITION_GRP_CODE
                                    LEFT OUTER JOIN BSC_PERSON_EVALUATION   BPE     ON  BPE.ESTTERM_REF_ID  =   EDI.ESTTERM_REF_ID
                                                                                    AND BPE.YY              =   @YY
                                                                                    AND BPE.DD              =   @DD
                                                                                    AND BPE.EMP_REF_ID      =   CEI.EMP_REF_ID
                                    LEFT OUTER JOIN EST_POSITION_CLS        EPC     ON  EPC.POS_CLS_ID      =   CEI.POSITION_CLASS_CODE
                                WHERE   EDI.ESTTERM_REF_ID = @ESTTERM_REF_ID ";
            query += @" ORDER BY EPG.POS_GRP_ID, CEI.EMP_CODE, EDI.EST_DEPT_REF_ID ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = iymd.Substring(0, 4);
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = iymd.Substring(4, 2);

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;              
        }

        public DataSet SelectPersonEavluationPoint(int comp_id
                                    , int estterm_ref_id
                                    , string iymd)
        {
            string query = @"SELECT  TA.EST_DEPT_REF_ID 
                                , ROUND(SUM(TA.SCORE_TS),2) as ORGANIZATION_POINT 
                        FROM (
                            SELECT  KW.EST_DEPT_REF_ID 
                                    ,ISNULL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE CONVERT(NUMERIC(20,4),TS.POINTS_TS)*0.01 END) as SCORE_TS 
                            FROM BSC_KPI_WEIGHT KW 
                                LEFT JOIN BSC_KPI_SCORE TS
                                    ON KW.ESTTERM_REF_ID = TS.ESTTERM_REF_ID
                                    AND KW.KPI_REF_ID     = TS.KPI_REF_ID
                                    AND KW.YMD            = TS.YMD
		                    WHERE	KW.ESTTERM_REF_ID	=	@ESTTERM_REF_ID
				                    AND KW.YMD          =	@YMD
                        ) TA 
                        GROUP BY TA.EST_DEPT_REF_ID ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = iymd;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectGroupEavluation(int comp_id
                                    , int estterm_ref_id
                                    , string iymd
                                    , string pos_grp_code)
        {
            //string query = @"SELECT   ROW_NUMBER() OVER(ORDER BY CEI.POSITION_GRP_CODE, BPE.STANDARD_SCORE DESC, CEI.EMP_NAME) AS IDC
            string query = @"SELECT   EDI.DEPT_NAME
                                    , EPG.POS_GRP_NAME
                                    , EPC.POS_CLS_NAME
                                    , CEI.EMP_CODE
                                    , CEI.EMP_NAME
                                    , BPE.POINT_SUM
                                    , BPE.STANDARD_SCORE
                                    , REPLACE(BPE.STANDARD_RATING, ' ', '') AS STANDARD_RATING
                                FROM                EST_DEPT_INFO           EDI
                                    INNER JOIN COM_DEPT_INFO                CDI     ON  CDI.DEPT_REF_ID     =   EDI.DEPT_REF_ID
                                                                                    AND CDI.DEPT_FLAG       =   1
                                    INNER JOIN      REL_DEPT_EMP            RDE     ON  RDE.DEPT_REF_ID     =   EDI.DEPT_REF_ID
                                                                                    AND RDE.REL_STATUS      =   1
                                    LEFT OUTER JOIN COM_EMP_INFO            CEI     ON  CEI.EMP_REF_ID      =   RDE.EMP_REF_ID
                                    LEFT OUTER JOIN BSC_PERSON_EVALUATION   BPE     ON  BPE.ESTTERM_REF_ID  =   EDI.ESTTERM_REF_ID
                                                                                    AND BPE.YY              =   @YY
                                                                                    AND BPE.DD              =   @DD
                                                                                    AND BPE.EMP_REF_ID      =   CEI.EMP_REF_ID
                                    LEFT OUTER JOIN EST_POSITION_GRP        EPG     ON  EPG.POS_GRP_ID      =   CEI.POSITION_GRP_CODE
                                    LEFT OUTER JOIN EST_POSITION_CLS        EPC     ON  EPC.POS_CLS_ID      =   CEI.POSITION_CLASS_CODE
                                WHERE   EDI.ESTTERM_REF_ID          =   @ESTTERM_REF_ID
                                        AND (CEI.POSITION_GRP_CODE   =   @POSITION_GRP_CODE OR @POSITION_GRP_CODE     =''    )
                                ORDER BY CEI.POSITION_GRP_CODE, BPE.STANDARD_SCORE DESC, EPC.POS_CLS_ID, EDI.DEPT_REF_ID, CEI.EMP_NAME";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = iymd.Substring(0, 4);
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = iymd.Substring(4, 2);
            paramArray[3] = CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.VarChar);
            paramArray[3].Value = pos_grp_code;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectGroupEavluationData(int comp_id
                                    , int estterm_ref_id
                                    , string iymd
                                    , string pos_grp_code)
        {
            string query = @"SELECT    BGE.GROUP_MEAN
                                , BGE.STANDARD_DEVIATION
                            FROM    BSC_GROUP_EVALUATION   BGE
		                    WHERE	BGE.ESTTERM_REF_ID	        =	@ESTTERM_REF_ID
				                    AND BGE.YY                  =   @YY
                                    AND BGE.DD                  =   @DD
                                    AND BGE.POS_GRP_ID   =   @POSITION_GRP_CODE
                        ORDER BY BGE.POS_GRP_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = iymd.Substring(0, 4);
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = iymd.Substring(4, 2);
            paramArray[3] = CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.VarChar);
            paramArray[3].Value = pos_grp_code;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int CountPersonEvaluation(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object yy
                                        , object dd
                                        , object emp_ref_id)
        {
            string query = @"SELECT COUNT(*) FROM BSC_PERSON_EVALUATION
                                WHERE	ESTTERM_REF_ID  =   @ESTTERM_REF_ID
                                    AND YY              =   @YY
                                    AND DD              =   @DD
                                    AND EMP_REF_ID      =   @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = yy;
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = dd;
            paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[3].Value = emp_ref_id;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertPersonEvaluation(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object yy
                                        , object dd
                                        , object emp_ref_id
                                        , object emp_code
                                        , object organization_point
                                        , object organization_weight
                                        , object appraisal_point
                                        , object appraisal_weight
                                        , object others1_point
                                        , object others1_weight
                                        , object others2_point
                                        , object others2_weight
                                        , object others3_point
                                        , object others3_weight
                                        , object weight_sum
                                        , object point_sum
                                        , object standard_score
                                        , object standard_rating
                                        , object create_user
                                        , object create_date
                                        , object update_user
                                        , object update_date)

        {
            string query = @"INSERT INTO BSC_PERSON_EVALUATION  (ESTTERM_REF_ID
                                                    , YY
                                                    , DD
                                                    , EMP_REF_ID
                                                    , EMP_CODE
                                                    , ORGANIZATION_POINT
                                                    , ORGANIZATION_WEIGHT
                                                    , APPRAISAL_POINT
                                                    , APPRAISAL_WEIGHT
                                                    , OTHERS1_POINT
                                                    , OTHERS1_WEIGHT
                                                    , OTHERS2_POINT
                                                    , OTHERS2_WEIGHT
                                                    , OTHERS3_POINT
                                                    , OTHERS3_WEIGHT
                                                    , WEIGHT_SUM
                                                    , POINT_SUM
                                                    , STANDARD_SCORE
                                                    , STANDARD_RATING
                                                    , CREATE_USER
                                                    , CREATE_DATE)
                                             VALUES
                                                   (@ESTTERM_REF_ID
                                                    , @YY
                                                    , @DD
                                                    , @EMP_REF_ID
                                                    , @EMP_CODE
                                                    , @ORGANIZATION_POINT
                                                    , @ORGANIZATION_WEIGHT
                                                    , @APPRAISAL_POINT
                                                    , @APPRAISAL_WEIGHT
                                                    , @OTHERS1_POINT
                                                    , @OTHERS1_WEIGHT
                                                    , @OTHERS2_POINT
                                                    , @OTHERS2_WEIGHT
                                                    , @OTHERS3_POINT
                                                    , @OTHERS3_WEIGHT
                                                    , @WEIGHT_SUM
                                                    , @POINT_SUM
                                                    , @STANDARD_SCORE
                                                    , @STANDARD_RATING
                                                    , @CREATE_USER
                                                    , @CREATE_DATE)";

            IDbDataParameter[] paramArray = CreateDataParameters(21);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = yy;
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = dd;
            paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[3].Value = emp_ref_id;
            paramArray[4] = CreateDataParameter("@EMP_CODE", SqlDbType.VarChar);
            paramArray[4].Value = emp_code;
            paramArray[5] = CreateDataParameter("@ORGANIZATION_POINT", SqlDbType.Decimal);
            paramArray[5].Value = organization_point;
            paramArray[6] = CreateDataParameter("@ORGANIZATION_WEIGHT", SqlDbType.Decimal);
            paramArray[6].Value = organization_weight;
            paramArray[7] = CreateDataParameter("@APPRAISAL_POINT", SqlDbType.Decimal);
            paramArray[7].Value = appraisal_point;
            paramArray[8] = CreateDataParameter("@APPRAISAL_WEIGHT", SqlDbType.Decimal);
            paramArray[8].Value = appraisal_weight;
            paramArray[9] = CreateDataParameter("@OTHERS1_POINT", SqlDbType.Decimal);
            paramArray[9].Value = others1_point;
            paramArray[10] = CreateDataParameter("@OTHERS1_WEIGHT", SqlDbType.Decimal);
            paramArray[10].Value = others1_weight;
            paramArray[11] = CreateDataParameter("@OTHERS2_POINT", SqlDbType.Decimal);
            paramArray[11].Value = others2_point;
            paramArray[12] = CreateDataParameter("@OTHERS2_WEIGHT", SqlDbType.Decimal);
            paramArray[12].Value = others2_weight;
            paramArray[13] = CreateDataParameter("@OTHERS3_POINT", SqlDbType.Decimal);
            paramArray[13].Value = others3_point;
            paramArray[14] = CreateDataParameter("@OTHERS3_WEIGHT", SqlDbType.Decimal);
            paramArray[14].Value = others3_weight;
            paramArray[15] = CreateDataParameter("@WEIGHT_SUM", SqlDbType.Decimal);
            paramArray[15].Value = weight_sum;
            paramArray[16] = CreateDataParameter("@POINT_SUM", SqlDbType.Decimal);
            paramArray[16].Value = point_sum;
            paramArray[17] = CreateDataParameter("@STANDARD_SCORE", SqlDbType.Decimal);
            paramArray[17].Value = standard_score;
            paramArray[18] = CreateDataParameter("@STANDARD_RATING", SqlDbType.Char);
            paramArray[18].Value = standard_rating;
            paramArray[19] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[19].Value = create_user;
            paramArray[20] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[20].Value = create_date;

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

        public int InsertGroupEvaluation(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object yy
                                        , object dd
                                        , object position_grp_code
                                        , object group_mean
                                        , object standard_deviation
                                        , object group_skewness
                                        , object group_kurtosis
                                        , object create_user
                                        , object create_date
                                        , object update_user
                                        , object update_date)
        {
            string query = @"INSERT INTO BSC_GROUP_EVALUATION  (ESTTERM_REF_ID
                                                    , YY
                                                    , DD
                                                    , POS_GRP_ID
                                                    , GROUP_MEAN
                                                    , STANDARD_DEVIATION
                                                    , GROUP_SKEWNESS
                                                    , GROUP_KURTOSIS
                                                    , CREATE_USER
                                                    , CREATE_DATE)
                                             VALUES
                                                   (@ESTTERM_REF_ID
                                                    , @YY
                                                    , @DD
                                                    , @POS_GRP_ID
                                                    , @GROUP_MEAN
                                                    , @STANDARD_DEVIATION
                                                    , @GROUP_SKEWNESS
                                                    , @GROUP_KURTOSIS
                                                    , @CREATE_USER
                                                    , @CREATE_DATE)";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = yy;
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = dd;
            paramArray[3] = CreateDataParameter("@POS_GRP_ID", SqlDbType.VarChar);
            paramArray[3].Value = position_grp_code;
            paramArray[4] = CreateDataParameter("@GROUP_MEAN", SqlDbType.Decimal);
            paramArray[4].Value = group_mean;
            paramArray[5] = CreateDataParameter("@STANDARD_DEVIATION", SqlDbType.Decimal);
            paramArray[5].Value = standard_deviation;
            paramArray[6] = CreateDataParameter("@GROUP_SKEWNESS", SqlDbType.Decimal);
            paramArray[6].Value = group_skewness;
            paramArray[7] = CreateDataParameter("@GROUP_KURTOSIS", SqlDbType.Decimal);
            paramArray[7].Value = group_kurtosis;
            paramArray[8] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[8].Value = create_user;
            paramArray[9] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[9].Value = create_date;

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

        public int UpdateGroupEvaluation(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object yy
                                        , object dd
                                        , object position_grp_code
                                        , object group_mean
                                        , object standard_deviation
                                        , object group_skewness
                                        , object group_kurtosis
                                        , object create_user
                                        , object create_date
                                        , object update_user
                                        , object update_date)
        {
            string query = "";
            query = @"UPDATE BSC_GROUP_EVALUATION
	                            SET   GROUP_MEAN                =   @GROUP_MEAN
		                            , STANDARD_DEVIATION        =   @STANDARD_DEVIATION
                                    , GROUP_SKEWNESS            =   @GROUP_SKEWNESS
                                    , GROUP_KURTOSIS            =   @GROUP_KURTOSIS
                                    , UPDATE_USER               =   @UPDATE_USER    
                                    , UPDATE_DATE               =   @UPDATE_DATE    
	                            WHERE		ESTTERM_REF_ID      =   @ESTTERM_REF_ID
			                            AND YY	                =   @YY
			                            AND DD	                =   @DD
			                            AND POS_GRP_ID   =   @POS_GRP_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = yy;
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = dd;
            paramArray[3] = CreateDataParameter("@POS_GRP_ID", SqlDbType.VarChar);
            paramArray[3].Value = position_grp_code;
            paramArray[4] = CreateDataParameter("@GROUP_MEAN", SqlDbType.Decimal);
            paramArray[4].Value = group_mean;
            paramArray[5] = CreateDataParameter("@STANDARD_DEVIATION", SqlDbType.Decimal);
            paramArray[5].Value = standard_deviation;
            paramArray[6] = CreateDataParameter("@GROUP_SKEWNESS", SqlDbType.Decimal);
            paramArray[6].Value = group_skewness;
            paramArray[7] = CreateDataParameter("@GROUP_KURTOSIS", SqlDbType.Decimal);
            paramArray[7].Value = group_kurtosis;
            paramArray[8] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[8].Value = update_user;
            paramArray[9] = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[9].Value = update_date;

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

        public int UpdatePersonEvaluation(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object yy
                                        , object dd
                                        , object emp_ref_id
                                        , object emp_code
                                        , object organization_point
                                        , object organization_weight
                                        , object appraisal_point
                                        , object appraisal_weight
                                        , object others1_point
                                        , object others1_weight
                                        , object others2_point
                                        , object others2_weight
                                        , object others3_point
                                        , object others3_weight
                                        , object weight_sum
                                        , object point_sum
                                        , object standard_score
                                        , object standard_rating
                                        , object create_user
                                        , object create_date
                                        , object update_user
                                        , object update_date)
        {
            string query = "";
                query = @"UPDATE BSC_PERSON_EVALUATION
	                            SET   EMP_CODE		        =   @EMP_CODE
		                            , ORGANIZATION_POINT    =   @ORGANIZATION_POINT
                                    , ORGANIZATION_WEIGHT   =   @ORGANIZATION_WEIGHT
                                    , APPRAISAL_POINT       =   @APPRAISAL_POINT
                                    , APPRAISAL_WEIGHT      =   @APPRAISAL_WEIGHT
                                    , OTHERS1_POINT         =   @OTHERS1_POINT
                                    , OTHERS1_WEIGHT        =   @OTHERS1_WEIGHT 
                                    , OTHERS2_POINT         =   @OTHERS2_POINT  
                                    , OTHERS2_WEIGHT        =   @OTHERS2_WEIGHT 
                                    , OTHERS3_POINT         =   @OTHERS3_POINT  
                                    , OTHERS3_WEIGHT        =   @OTHERS3_WEIGHT 
                                    , WEIGHT_SUM            =   @WEIGHT_SUM     
                                    , POINT_SUM             =   @POINT_SUM      
                                    , STANDARD_SCORE        =   @STANDARD_SCORE 
                                    , STANDARD_RATING       =   @STANDARD_RATING
                                    , UPDATE_USER           =   @UPDATE_USER    
                                    , UPDATE_DATE           =   @UPDATE_DATE    
	                            WHERE		ESTTERM_REF_ID  =   @ESTTERM_REF_ID
			                            AND YY	            =   @YY
			                            AND DD	            =   @DD
			                            AND EMP_REF_ID      =   @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(21);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = yy;
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = dd;
            paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[3].Value = emp_ref_id;
            paramArray[4] = CreateDataParameter("@EMP_CODE", SqlDbType.VarChar);
            paramArray[4].Value = emp_code;
            paramArray[5] = CreateDataParameter("@ORGANIZATION_POINT", SqlDbType.Decimal);
            paramArray[5].Value = organization_point;
            paramArray[6] = CreateDataParameter("@ORGANIZATION_WEIGHT", SqlDbType.Decimal);
            paramArray[6].Value = organization_weight;
            paramArray[7] = CreateDataParameter("@APPRAISAL_POINT", SqlDbType.Decimal);
            paramArray[7].Value = appraisal_point;
            paramArray[8] = CreateDataParameter("@APPRAISAL_WEIGHT", SqlDbType.Decimal);
            paramArray[8].Value = appraisal_weight;
            paramArray[9] = CreateDataParameter("@OTHERS1_POINT", SqlDbType.Decimal);
            paramArray[9].Value = others1_point;
            paramArray[10] = CreateDataParameter("@OTHERS1_WEIGHT", SqlDbType.Decimal);
            paramArray[10].Value = others1_weight;
            paramArray[11] = CreateDataParameter("@OTHERS2_POINT", SqlDbType.Decimal);
            paramArray[11].Value = others2_point;
            paramArray[12] = CreateDataParameter("@OTHERS2_WEIGHT", SqlDbType.Decimal);
            paramArray[12].Value = others2_weight;
            paramArray[13] = CreateDataParameter("@OTHERS3_POINT", SqlDbType.Decimal);
            paramArray[13].Value = others3_point;
            paramArray[14] = CreateDataParameter("@OTHERS3_WEIGHT", SqlDbType.Decimal);
            paramArray[14].Value = others3_weight;
            paramArray[15] = CreateDataParameter("@WEIGHT_SUM", SqlDbType.Decimal);
            paramArray[15].Value = weight_sum;
            paramArray[16] = CreateDataParameter("@POINT_SUM", SqlDbType.Decimal);
            paramArray[16].Value = point_sum;
            paramArray[17] = CreateDataParameter("@STANDARD_SCORE", SqlDbType.Decimal);
            paramArray[17].Value = standard_score;
            paramArray[18] = CreateDataParameter("@STANDARD_RATING", SqlDbType.Char);
            paramArray[18].Value = standard_rating;
            paramArray[19] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[19].Value = update_user;
            paramArray[20] = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[20].Value = update_date;

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

        public int CountGroupEvaluation(IDbConnection conn
                                        , IDbTransaction trx
                                        , object estterm_ref_id
                                        , object yy
                                        , object dd
                                        , object position_grp_code)
        {
            string query = @"SELECT COUNT(*) FROM BSC_GROUP_EVALUATION
                                WHERE	ESTTERM_REF_ID      =   @ESTTERM_REF_ID
                                    AND YY                  =   @YY
                                    AND DD                  =   @DD
                                    AND POS_GRP_ID   =   @POS_GRP_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YY", SqlDbType.Char);
            paramArray[1].Value = yy;
            paramArray[2] = CreateDataParameter("@DD", SqlDbType.Char);
            paramArray[2].Value = dd;
            paramArray[3] = CreateDataParameter("@POS_GRP_ID", SqlDbType.VarChar);
            paramArray[3].Value = position_grp_code;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public DataSet SelectEstData( int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string year_yn
                                    , string merge_yn
                                    , OwnerType ownerType
                                    , string sql_where)
        {
            string query = @"
SELECT  ED.COMP_ID
        ,ED.EST_ID
        ,ED.ESTTERM_REF_ID
        ,ED.ESTTERM_SUB_ID
        ,ESU.ESTTERM_SUB_NAME
        ,ESU.YEAR_YN
        ,ED.ESTTERM_STEP_ID
        ,EST.ESTTERM_STEP_NAME
        ,EST.MERGE_YN
        ,EST.SORT_ORDER            AS STEP_ORDER
        ,ED.EST_DEPT_ID
        ,EDE.DEPT_NAME             AS EST_DEPT_NAME
        ,ED.EST_EMP_ID
        ,EIE.EMP_NAME              AS EST_EMP_NAME
        ,ED.TGT_DEPT_ID
        ,EDT.DEPT_NAME             AS TGT_DEPT_NAME
        ,ED.TGT_EMP_ID
        ,EIT.EMP_NAME              AS TGT_EMP_NAME
        ,ED.TGT_POS_CLS_ID
        ,ED.TGT_POS_CLS_NAME
        ,ED.TGT_POS_DUT_ID
        ,ED.TGT_POS_DUT_NAME
        ,ED.TGT_POS_GRP_ID
        ,ED.TGT_POS_GRP_NAME
        ,ED.TGT_POS_RNK_ID
        ,ED.TGT_POS_RNK_NAME
        ,ED.TGT_POS_KND_ID
        ,ED.TGT_POS_KND_NAME
        ,ED.DIRECTION_TYPE
        ,DT.DIRECTION_TYPE_NAME
        ,ED.POINT_ORG
        ,ED.POINT_ORG_DATE
        ,ED.POINT_AVG
        ,ED.POINT_AVG_DATE
        ,ED.POINT_STD
        ,ED.POINT_STD_DATE
        ,ED.POINT_CTRL_ORG
        ,ED.POINT_CTRL_ORG_DATE
        ,ED.GRADE_CTRL_ORG_ID
        ,EGR1.GRADE_NAME
        ,ED.GRADE_CTRL_ORG_DATE
        ,ED.POINT
        ,ED.POINT_DATE
        ,ED.GRADE_ID
        ,EGR.SORT_ORDER            AS GRADE_SORT_ORDER
        ,EGR.GRADE_NAME
        ,ED.GRADE_DATE
        ,ED.GRADE_TO_POINT
        ,ED.GRADE_TO_POINT_DATE
        --,ED.EST_OPINION
        --,ED.TGT_OPINION
        ,ED.STATUS_ID
        ,ED.STATUS_DATE
        ,ESA.STATUS_IMG_PATH
        ,QPS.Q_STYLE_PAGE_NAME
        ,QPS.Q_YN
        ,SSM.WEIGHT                AS WEIGHT_ESTTERM_SUB
        ,STM.WEIGHT                AS WEIGHT_ESTTERM_STEP
        ,STM.FIXED_WEIGHT_YN
        ,ESU.YEAR_YN
        ,EST.MERGE_YN
        ,GEM.REL_GRP_ID
        ,GIR.REL_GRP_NAME
        ,ED.CREATE_DATE
        ,ED.CREATE_USER
        ,ED.UPDATE_DATE
        ,ED.UPDATE_USER
    FROM	            EST_DATA	          ED
	    JOIN            EST_TERM_SUB          ESU    ON	(ED.COMP_ID         = ESU.COMP_ID
												     AND ED.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
	    JOIN            EST_TERM_STEP         EST    ON	(ED.COMP_ID         = EST.COMP_ID
												     AND ED.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
	    JOIN            COM_DEPT_INFO         EDE    ON (ED.EST_DEPT_ID     = EDE.DEPT_REF_ID)
	    JOIN            COM_DEPT_INFO         EDT    ON (ED.TGT_DEPT_ID     = EDT.DEPT_REF_ID)
	    JOIN            COM_EMP_INFO          EIE    ON (ED.EST_EMP_ID      = EIE.EMP_REF_ID)
	    LEFT OUTER JOIN COM_EMP_INFO          EIT    ON (ED.TGT_EMP_ID      = EIT.EMP_REF_ID)
	    JOIN            EST_INFO              EI     ON (ED.COMP_ID         = EI.COMP_ID
												     AND ED.EST_ID          = EI.EST_ID)
	    JOIN            EST_STATUS_STYLE      ESS    ON (EI.STATUS_STYLE_ID = ESS.STATUS_STYLE_ID)
	    JOIN            EST_STATUS            ESA    ON (ESA.STATUS_STYLE_ID= ESS.STATUS_STYLE_ID
												     AND ESA.STATUS_ID      = ED.STATUS_ID)
	    JOIN EST_QUESTION_PAGE_STYLE          QPS    ON (EI.Q_STYLE_ID      = QPS.Q_STYLE_ID)
	    LEFT OUTER JOIN EST_TERM_SUB_EST_MAP  SSM    ON (ED.COMP_ID         = SSM.COMP_ID
												     AND ED.EST_ID          = SSM.EST_ID
												     AND ED.ESTTERM_SUB_ID  = SSM.ESTTERM_SUB_ID)
	    LEFT OUTER JOIN EST_TERM_STEP_EST_MAP STM    ON (ED.COMP_ID         = STM.COMP_ID
												     AND ED.EST_ID          = STM.EST_ID
												     AND ED.ESTTERM_STEP_ID = STM.ESTTERM_STEP_ID)
	    LEFT OUTER JOIN EST_REL_GROUP_TGT_MAP GEM    ON (ED.COMP_ID         = GEM.COMP_ID
												     AND ED.EST_ID          = GEM.EST_ID
												     AND ED.ESTTERM_REF_ID  = GEM.ESTTERM_REF_ID
												     AND ED.TGT_DEPT_ID		= GEM.TGT_DEPT_ID
												     AND ED.TGT_EMP_ID		= GEM.TGT_EMP_ID)
	    LEFT OUTER JOIN EST_REL_GROUP_INFO    GIR    ON (GEM.REL_GRP_ID     = GIR.REL_GRP_ID
												     AND GEM.COMP_ID        = GIR.COMP_ID
												     AND GEM.EST_ID         = GIR.EST_ID
												     AND GEM.ESTTERM_REF_ID = GIR.ESTTERM_REF_ID)
	    LEFT OUTER JOIN EST_GRADE             EGR    ON (ED.COMP_ID			= EGR.COMP_ID
                                                     AND ED.GRADE_ID        = EGR.GRADE_ID)
        LEFT OUTER JOIN EST_GRADE             EGR1   ON (ED.COMP_ID			    = EGR1.COMP_ID
                                                     AND ED.GRADE_CTRL_ORG_ID   = EGR1.GRADE_ID)
	    JOIN EST_DIRECTION_TYPE               DT     ON (ED.DIRECTION_TYPE  = DT.DIRECTION_TYPE)
WHERE	(ED.COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
	AND (ED.EST_ID          = @EST_ID          OR @EST_ID          ='')
	AND	(ED.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
	AND	(ED.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
	AND	(ED.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
	AND	(ED.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
	AND	(ED.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
	AND	(ED.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
	AND	(ED.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
	AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN         ='')
	AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN        ='')
                                    "
                                    + sql_where;

            if(ownerType == OwnerType.Dept)
            {
                query += @" AND ED.TGT_EMP_ID < 0";
            }
            else if(ownerType == OwnerType.Emp_User)
            {
                query += @" AND ED.TGT_EMP_ID IN (SELECT EMP_REF_ID FROM REL_DEPT_EMP WHERE REL_STATUS = 1) ";
                query += @" AND ED.TGT_EMP_ID > 0";
            }

            query += @" ORDER BY ESU.ESTTERM_SUB_NAME, EST.ESTTERM_STEP_NAME, EDE.DEPT_NAME, EIE.EMP_NAME, EDT.DEPT_NAME, EIT.EMP_NAME";

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

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectEstData(IDbConnection conn
                                    , IDbTransaction trx
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string year_yn
                                    , string merge_yn
                                    , OwnerType ownerType
                                    , string sql_where)
        {
            string query = @"SELECT  ED.COMP_ID
									,ED.EST_ID
									,ED.ESTTERM_REF_ID
									,ED.ESTTERM_SUB_ID
									,ESU.ESTTERM_SUB_NAME
									,ESU.YEAR_YN
									,ED.ESTTERM_STEP_ID
									,EST.ESTTERM_STEP_NAME
									,EST.MERGE_YN
                                    ,EST.SORT_ORDER            AS STEP_ORDER
									,ED.EST_DEPT_ID
									,EDE.DEPT_NAME             AS EST_DEPT_NAME
									,ED.EST_EMP_ID
									,EIE.EMP_NAME              AS EST_EMP_NAME
									,ED.TGT_DEPT_ID
									,EDT.DEPT_NAME             AS TGT_DEPT_NAME
									,ED.TGT_EMP_ID
									,EIT.EMP_NAME              AS TGT_EMP_NAME
									,ED.TGT_POS_CLS_ID
									,ED.TGT_POS_CLS_NAME
									,ED.TGT_POS_DUT_ID
									,ED.TGT_POS_DUT_NAME
									,ED.TGT_POS_GRP_ID
									,ED.TGT_POS_GRP_NAME
									,ED.TGT_POS_RNK_ID
									,ED.TGT_POS_RNK_NAME
									,ED.TGT_POS_KND_ID
									,ED.TGT_POS_KND_NAME
									,ED.DIRECTION_TYPE
									,DT.DIRECTION_TYPE_NAME
									,ED.POINT_ORG
									,ED.POINT_ORG_DATE
									,ED.POINT_AVG
									,ED.POINT_AVG_DATE
									,ED.POINT_STD
									,ED.POINT_STD_DATE
									,ED.POINT_CTRL_ORG
									,ED.POINT_CTRL_ORG_DATE
									,ED.GRADE_CTRL_ORG_ID
                                    ,EGR1.GRADE_NAME
									,ED.GRADE_CTRL_ORG_DATE
									,ED.POINT
									,ED.POINT_DATE
									,ED.GRADE_ID
									,EGR.SORT_ORDER            AS GRADE_SORT_ORDER
                                    ,EGR.GRADE_NAME
									,ED.GRADE_DATE
									,ED.GRADE_TO_POINT
									,ED.GRADE_TO_POINT_DATE
                                    --,ED.EST_OPINION
                                    --,ED.TGT_OPINION
									,ED.STATUS_ID
									,ED.STATUS_DATE
									,ESA.STATUS_IMG_PATH
									,QPS.Q_STYLE_PAGE_NAME
									,QPS.Q_YN
									,SSM.WEIGHT                AS WEIGHT_ESTTERM_SUB
									,STM.WEIGHT                AS WEIGHT_ESTTERM_STEP
									,STM.FIXED_WEIGHT_YN
									,ESU.YEAR_YN
									,EST.MERGE_YN
									,GEM.REL_GRP_ID
									,GIR.REL_GRP_NAME
									,ED.CREATE_DATE
									,ED.CREATE_USER
									,ED.UPDATE_DATE
									,ED.UPDATE_USER
								FROM	            EST_DATA	          ED
									JOIN            EST_TERM_SUB          ESU    ON	(ED.COMP_ID         = ESU.COMP_ID
																				 AND ED.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
									JOIN            EST_TERM_STEP         EST    ON	(ED.COMP_ID         = EST.COMP_ID
																				 AND ED.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
									JOIN            COM_DEPT_INFO         EDE    ON (ED.EST_DEPT_ID     = EDE.DEPT_REF_ID)
									JOIN            COM_DEPT_INFO         EDT    ON (ED.TGT_DEPT_ID     = EDT.DEPT_REF_ID)
									JOIN            COM_EMP_INFO          EIE    ON (ED.EST_EMP_ID      = EIE.EMP_REF_ID)
									LEFT OUTER JOIN COM_EMP_INFO          EIT    ON (ED.TGT_EMP_ID      = EIT.EMP_REF_ID)
									JOIN            EST_INFO              EI     ON (ED.COMP_ID         = EI.COMP_ID
																				 AND ED.EST_ID          = EI.EST_ID)
									JOIN            EST_STATUS_STYLE      ESS    ON (EI.STATUS_STYLE_ID = ESS.STATUS_STYLE_ID)
									JOIN            EST_STATUS            ESA    ON (ESA.STATUS_STYLE_ID= ESS.STATUS_STYLE_ID
																				 AND ESA.STATUS_ID      = ED.STATUS_ID)
									JOIN EST_QUESTION_PAGE_STYLE          QPS    ON (EI.Q_STYLE_ID      = QPS.Q_STYLE_ID)
									LEFT OUTER JOIN EST_TERM_SUB_EST_MAP  SSM    ON (ED.COMP_ID         = SSM.COMP_ID
																				 AND ED.EST_ID          = SSM.EST_ID
																				 AND ED.ESTTERM_SUB_ID  = SSM.ESTTERM_SUB_ID)
									LEFT OUTER JOIN EST_TERM_STEP_EST_MAP STM    ON (ED.COMP_ID         = STM.COMP_ID
																				 AND ED.EST_ID          = STM.EST_ID
																				 AND ED.ESTTERM_STEP_ID = STM.ESTTERM_STEP_ID)
									LEFT OUTER JOIN EST_REL_GROUP_TGT_MAP GEM    ON (ED.COMP_ID         = GEM.COMP_ID
																				 AND ED.EST_ID          = GEM.EST_ID
																				 AND ED.ESTTERM_REF_ID  = GEM.ESTTERM_REF_ID
																				 AND ED.TGT_DEPT_ID		= GEM.TGT_DEPT_ID
																				 AND ED.TGT_EMP_ID		= GEM.TGT_EMP_ID)
									LEFT OUTER JOIN EST_REL_GROUP_INFO    GIR    ON (GEM.REL_GRP_ID     = GIR.REL_GRP_ID
																				 AND GEM.COMP_ID        = GIR.COMP_ID
																				 AND GEM.EST_ID         = GIR.EST_ID
																				 AND GEM.ESTTERM_REF_ID = GIR.ESTTERM_REF_ID)
									LEFT OUTER JOIN EST_GRADE             EGR    ON (ED.COMP_ID			= EGR.COMP_ID
                                                                                 AND ED.GRADE_ID        = EGR.GRADE_ID)
                                    LEFT OUTER JOIN EST_GRADE             EGR1   ON (ED.COMP_ID			    = EGR1.COMP_ID
                                                                                 AND ED.GRADE_CTRL_ORG_ID   = EGR1.GRADE_ID)
									JOIN EST_DIRECTION_TYPE               DT     ON (ED.DIRECTION_TYPE  = DT.DIRECTION_TYPE)
								WHERE	(ED.COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
									AND (ED.EST_ID          = @EST_ID          OR @EST_ID          = N'')
									AND	(ED.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
									AND	(ED.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
									AND	(ED.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
									AND	(ED.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
									AND	(ED.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
									AND	(ED.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
									AND	(ED.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
									AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN         = N'')
									AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN        = N'')
                                    "
                                    + sql_where;

            if (ownerType == OwnerType.Dept)
            {
                query += @" AND ED.TGT_EMP_ID < 0";
            }
            else if (ownerType == OwnerType.Emp_User)
            {
                query += @" AND ED.TGT_EMP_ID IN (SELECT EMP_REF_ID FROM REL_DEPT_EMP WHERE REL_STATUS = 1) ";
                query += @" AND ED.TGT_EMP_ID > 0";
            }

            query += @" ORDER BY ESU.ESTTERM_SUB_NAME, EST.ESTTERM_STEP_NAME, EDE.DEPT_NAME, EIE.EMP_NAME, EDT.DEPT_NAME, EIT.EMP_NAME";

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
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9] = CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
            paramArray[9].Value = year_yn;
            paramArray[10] = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
            paramArray[10].Value = merge_yn;

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectTgtEmp(  int comp_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int emp_ref_id)
        {
            string query = @"
SELECT	  EST_ID
        , EST_NAME 
        , SORT_ORDER
    FROM (
            SELECT    ED.EST_ID
                    , EI.EST_NAME
                    , EI.SORT_ORDER
                FROM		EST_DATA                    ED
                    JOIN	EST_INFO                    EI ON (	    ED.COMP_ID      =    EI.COMP_ID
                                                                AND ED.EST_ID       =    EI.EST_ID  )
                WHERE	    EI.OWNER_TYPE       =   'P'
                        AND (EI.EST_STYLE_ID		=   'EST'  OR   EI.EST_STYLE_ID =   'MUL')
                        AND ED.COMP_ID	        =   @COMP_ID
                        AND ED.ESTTERM_REF_ID	=   @ESTTERM_REF_ID
                        AND ED.ESTTERM_SUB_ID	=   @ESTTERM_SUB_ID
                        AND (       ED.TGT_EMP_ID	=   @EMP_REF_ID
                                OR  ED.EST_EMP_ID   =   @EMP_REF_ID   OR  @EMP_REF_ID = 0   )




            UNION





             SELECT    ED.EST_ID
                    , EI.EST_NAME
                    , EI.SORT_ORDER
                FROM		EST_DATA	                ED
                    JOIN	EST_INFO	                EI  ON (	ED.COMP_ID		=   EI.COMP_ID
                                                                AND ED.EST_ID		=   EI.EST_ID   )
                    LEFT OUTER JOIN	
                            EST_DEPT_OPINION_TGT_EMP    OT  ON (	ED.COMP_ID		=   OT.COMP_ID
                                                                AND ED.EST_ID		=   OT.EST_ID
                                                                AND ED.TGT_DEPT_ID	=   OT.TGT_DEPT_ID)
                WHERE	    EI.OWNER_TYPE		=   'D'
                        AND EI.EST_STYLE_ID		=   'EST'
                        AND ED.COMP_ID	        =   @COMP_ID
                        AND ED.ESTTERM_REF_ID	=   @ESTTERM_REF_ID
                        AND ED.ESTTERM_SUB_ID	=   @ESTTERM_SUB_ID
                        AND (       ED.EST_EMP_ID		=   @EMP_REF_ID	    
                            OR      OT.TGT_EMP_ID		=   @EMP_REF_ID OR  @EMP_REF_ID = 0   )



            UNION




            SELECT    ED.EST_ID
                    , EI.EST_NAME
                    , EI.SORT_ORDER
                FROM        EST_DATA                    ED
                    JOIN    EST_INFO                    EI  ON (    ED.COMP_ID        =   EI.COMP_ID
                                                                AND ED.EST_ID        =   EI.EST_ID   )
                WHERE        EI.OWNER_TYPE       =   'D'
                        AND EI.EST_STYLE_ID      =   'EST'
                        AND ED.COMP_ID           =   @COMP_ID
                        AND ED.ESTTERM_REF_ID    =   @ESTTERM_REF_ID
                        AND ED.ESTTERM_SUB_ID    =   @ESTTERM_SUB_ID
                        AND ED.TGT_DEPT_ID IN ( SELECT DEPT_REF_ID FROM REL_DEPT_EMP
                                             WHERE DEPT_REF_ID   = ED.TGT_DEPT_ID
                                               AND REL_STATUS    = 1
                                               AND (EMP_REF_ID    = @EMP_REF_ID   OR   @EMP_REF_ID   = 0)
                                              )
                            

            UNION



            SELECT	  PD.EST_ID
                    , EI.EST_NAME
                    , EI.SORT_ORDER
                FROM		PRJ_DATA                    PD
                    JOIN	PRJ_INFO                    PI  ON (     PD.PRJ_REF_ID	=   PI.PRJ_REF_ID)
                    JOIN	EST_INFO                    EI  ON (     PD.COMP_ID		=   EI.COMP_ID
                                                                AND  PD.EST_ID		=   EI.EST_ID)
                WHERE	    PD.COMP_ID	        =   @COMP_ID
                        AND PD.ESTTERM_REF_ID	=   @ESTTERM_REF_ID
                        AND PD.ESTTERM_SUB_ID	=   @ESTTERM_SUB_ID
                        AND (       PI.OWNER_EMP_ID	    =   @EMP_REF_ID       
                            OR      PD.EST_EMP_ID       =   @EMP_REF_ID   OR  @EMP_REF_ID = 0   )
        ) A

    GROUP BY  EST_ID
            , EST_NAME
            , SORT_ORDER
    ORDEr BY  SORT_ORDER ASC
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[3].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Get3GAData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int emp_ref_id)
        {
            string query = @"
-- 내가 평가해야할 건수
SELECT   ISNULL(SUM(CASE WHEN ISNULL(C.STATUS, 'N') IN ('C', 'P', 'E') THEN 1 ELSE 0 END), 0) AS COMPLETE_Y
	    ,COUNT(ISNULL(C.STATUS, 'N')) AS TOTAL_CNT
FROM    EST_EMP_EST_TARGET_MAP          A
INNER JOIN REL_DEPT_EMP                 B   ON  B.EMP_REF_ID    = A.TGT_EMP_ID
                                            AND B.REL_STATUS    = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT	C	ON	C.COMP_ID	= A.COMP_ID
											AND	C.EST_ID	= A.EST_ID
											AND	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
											AND	C.ESTTERM_SUB_ID	= A.ESTTERM_SUB_ID
											AND	C.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID
											AND	C.EST_DEPT_ID		= A.EST_DEPT_ID
											AND	C.EST_EMP_ID		= A.EST_EMP_ID
											AND	C.TGT_DEPT_ID		= A.TGT_DEPT_ID
											AND	C.TGT_EMP_ID		= A.TGT_EMP_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_EMP_ID            = @EMP_REF_ID
    AND ISNULL(A.STATUS_ID, '') = 'E'
";


            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATAGET0", null, paramArray, CommandType.Text);

            query = @"

--내가 의견상신해야할 건수
SELECT   SUM(CASE WHEN ISNULL(A.STATUS, 'N') = 'C' THEN 1 ELSE 0 END) AS COMPLETE_Y
        ,COUNT(ISNULL(A.STATUS, 'N')) AS TOTAL_CNT
FROM        BSC_MBO_KPI_REPORT  A
INNER JOIN REL_DEPT_EMP         B   ON  B.EMP_REF_ID        = A.TGT_EMP_ID
                                    AND B.REL_STATUS        = 1
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.TGT_EMP_ID            = @EMP_REF_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4].Value = emp_ref_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATAGET1", ds, paramArray, CommandType.Text);

            query = @"
--내가 피드백해야할 건수
SELECT   SUM(CASE WHEN ISNULL(C.STATUS, 'N') = 'E' THEN 1 ELSE 0 END) AS COMPLETE_Y
	    ,COUNT(ISNULL(C.STATUS, 'N')) AS TOTAL_CNT
FROM    EST_EMP_EST_TARGET_MAP          A
INNER JOIN REL_DEPT_EMP                 B   ON  B.EMP_REF_ID    = A.TGT_EMP_ID
                                            AND B.REL_STATUS    = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT	C	ON	C.COMP_ID	= A.COMP_ID
											AND	C.EST_ID	= A.EST_ID
											AND	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
											AND	C.ESTTERM_SUB_ID	= A.ESTTERM_SUB_ID
											AND	C.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID
											AND	C.EST_DEPT_ID		= A.EST_DEPT_ID
											AND	C.EST_EMP_ID		= A.EST_EMP_ID
											AND	C.TGT_DEPT_ID		= A.TGT_DEPT_ID
											AND	C.TGT_EMP_ID		= A.TGT_EMP_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.TGT_EMP_ID            = @EMP_REF_ID
    AND ISNULL(A.STATUS_ID, '') = 'E'
    AND A.ESTTERM_STEP_ID		= (
		SELECT MAX(ESTTERM_STEP_ID) 
		FROM EST_EMP_EST_TARGET_MAP 
		WHERE	COMP_ID	                = @COMP_ID
			AND	EST_ID	                = @EST_ID
			AND	ESTTERM_REF_ID	        = @ESTTERM_REF_ID
			AND	ESTTERM_SUB_ID	        = @ESTTERM_SUB_ID
			AND	TGT_EMP_ID		        = @EMP_REF_ID
			AND	ISNULL(A.STATUS_ID, '')	= 'E')
";

            paramArray = null;
            paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4].Value = emp_ref_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATAGET2", ds, paramArray, CommandType.Text);

            return ds;
        }


        public DataSet Get3GADataEstData(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int dept_ref_id)
        {
            string query = @"
SELECT   A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,A.EST_DEPT_ID
        ,A.EST_EMP_ID
        ,A.TGT_DEPT_ID
        ,A.TGT_EMP_ID
        ,B.STATUS
        ,C.ESTTERM_STEP_NAME
        ,D.EMP_NAME AS EST_EMP_NAME
        ,E.DEPT_NAME AS TGT_DEPT_NAME
        ,F.EMP_NAME AS TGT_EMP_NAME
        ,G1.POS_CLS_NAME AS TGT_POS_CLS_NAME
        ,G2.POS_DUT_NAME AS TGT_POS_DUT_NAME
        ,G3.POS_RNK_NAME AS TGT_POS_RNK_NAME
        ,A.TGT_POS_GRP_NAME
        ,ISNULL(B.SCORE, 0) AS POINT
        ,H.STATUS_NAME
        ,H.STATUS_DESC
        ,H.STATUS_IMG_PATH
FROM        EST_DATA    A
INNER JOIN  BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID           = A.COMP_ID
                                        AND B.EST_ID            = A.EST_ID
                                        AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                        AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                        AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                        AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                        AND B.EST_EMP_ID        = A.EST_EMP_ID
                                        AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
                                        AND B.TGT_EMP_ID        = A.TGT_EMP_ID
LEFT OUTER JOIN EST_TERM_STEP       C   ON  C.COMP_ID           = B.COMP_ID
                                        AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                        AND C.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO        D   ON  D.EMP_REF_ID        = B.EST_EMP_ID
LEFT OUTER JOIN COM_DEPT_INFO       E   ON  E.DEPT_REF_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN COM_EMP_INFO        F   ON  F.EMP_REF_ID        = B.TGT_EMP_ID
LEFT OUTER JOIN EST_POSITION_CLS    G1  ON  G1.POS_CLS_ID       = F.POSITION_CLASS_CODE
LEFT OUTER JOIN EST_POSITION_DUT    G2  ON  G2.POS_DUT_ID       = F.POSITION_DUTY_CODE
LEFT OUTER JOIN EST_POSITION_RNK    G3  ON  G3.POS_RNK_ID       = F.POSITION_RANK_CODE
LEFT OUTER JOIN EST_STATUS          H   ON  H.STATUS_STYLE_ID   = '0003'
                                        AND H.STATUS_ID         = B.STATUS
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND (A.ESTTERM_STEP_ID  = @ESTTERM_STEP_ID  OR  (A.ESTTERM_STEP_ID <> 1 AND @ESTTERM_STEP_ID    = 0))
    AND (A.TGT_DEPT_ID      = @DEPT_REF_ID      OR  @DEPT_REF_ID        = 0)
ORDER BY A.TGT_DEPT_ID, A.TGT_EMP_ID, A.ESTTERM_SUB_ID, A.ESTTERM_STEP_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATAGET0", null, paramArray, CommandType.Text);

            query = @"
SELECT  ESTTERM_STEP_ID, STATUS_YN, START_DATE, END_DATE
FROM    EST_JOB_DETAIL
WHERE   COMP_ID = @COMP_ID
    AND EST_ID  = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = 0
    AND EST_JOB_ID  = 'JOB_91'
";
            paramArray = null;
            paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            
            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATAGET1", ds, paramArray, CommandType.Text);

            query = @"
SELECT TOP 1 EST_ID
FROM    BSC_MBO_KPI_SCORE_MT A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.STATUS            <> 'E'
";
            string queryOra = @"
SELECT EST_ID
FROM    BSC_MBO_KPI_SCORE_MT A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.STATUS            <> 'E'
    AND ROWNUM = 1
";
            paramArray = null;
            paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(queryOra)), "DATAGET2", ds, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Get3GADataList(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int usertype
                                    , int emp_ref_id)
        {
            string queryAdd = string.Empty;
            if (usertype == 1) //평가자 기준
                queryAdd = @"
    AND A.EST_EMP_ID    = @EMP_REF_ID";
            else if (usertype == 2) //피평가자 기준
                queryAdd = @"
    AND A.TGT_EMP_ID    = @EMP_REF_ID";
            else //관리자 및 성과평가 관리자 기준
                queryAdd = @"
    AND (A.TGT_DEPT_ID = @EMP_REF_ID OR @EMP_REF_ID = 0)";
            
            string query = @"
SELECT   D.EMP_NAME                     AS EST_EMP_NAME
        ,F.DEPT_NAME                    AS EST_DEPT_NAME
        ,H.ESTTERM_STEP_NAME            AS EST_STEP_NAME
        ,E.EMP_NAME                     AS TGT_EMP_NAME
        ,G.DEPT_NAME                    AS TGT_DEPT_NAME
        ,ISNULL(COUNT(C.KPI_REF_ID), 0) AS EST_KPI_COUNT
        ,ISNULL(SUM(CASE WHEN C.STATUS = 'N' THEN 1 ELSE 0 END), 0) AS STATUS_N
        ,ISNULL(SUM(CASE WHEN C.STATUS = 'O' THEN 1 ELSE 0 END), 0) AS STATUS_P
        ,ISNULL(SUM(CASE WHEN C.STATUS = 'C' THEN 1 ELSE 0 END), 0) AS STATUS_E
        ,CASE B.STATUS  WHEN 'P' THEN '피드백중'
                        WHEN 'E' THEN '피드백완료'
                        ELSE '미진행' END AS FEEDBACK_NAME
        ,CASE WHEN B.STATUS = 'E' THEN 'Y' ELSE 'N' END AS COMPLETE_YN
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,B.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN COM_EMP_INFO    D   ON  D.EMP_REF_ID        = A.EST_EMP_ID
LEFT OUTER JOIN COM_EMP_INFO    E   ON  E.EMP_REF_ID        = A.TGT_EMP_ID
LEFT OUTER JOIN COM_DEPT_INFO   F   ON  F.DEPT_REF_ID       = A.EST_DEPT_ID
LEFT OUTER JOIN COM_DEPT_INFO   G   ON  G.DEPT_REF_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN EST_TERM_STEP   H   ON  H.COMP_ID           = A.COMP_ID
                                    AND H.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
{0}
    AND ISNULL(A.STATUS_ID, '') = 'E'
GROUP BY D.EMP_NAME                     
        ,F.DEPT_NAME                    
        ,H.ESTTERM_STEP_NAME            
        ,E.EMP_NAME                     
        ,G.DEPT_NAME                    
        ,CASE B.STATUS  WHEN 'P' THEN '피드백중'
                        WHEN 'E' THEN '피드백완료'
                        ELSE '미진행' END 
        ,CASE WHEN B.STATUS = 'E' THEN 'Y' ELSE 'N' END 
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,B.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
";

            query = string.Format(query, queryAdd);

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public string GetMboReportStatus(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id)
        {
            string strQuery = @"
SELECT  ISNULL(STATUS, 'N')
FROM    BSC_MBO_KPI_REPORT
WHERE   COMP_ID         = @COMP_ID
        AND EST_ID          = @EST_ID
        AND ESTTERM_REF_ID = @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND TGT_DEPT_ID     = @TGT_DEPT_ID
        AND TGT_EMP_ID      = @TGT_EMP_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_dept_id;
            paramArray[5].Value = tgt_emp_id;

            return DbAgentObj.ExecuteScalar(strQuery, paramArray, CommandType.Text).ToString();
        }

        public bool UpdateMboDTGrade(IDbConnection idc
                                    , IDbTransaction idt
                                    , bool isOverStep
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , object[,] objGrade)
        {
            int affectedRow = 0;
            string strQuery = string.Empty;
            string strQuery2 = string.Empty;

            strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_DT
    SET  STATUS         = 'O' --N: 미평가, O:실적입력중, C: 실적입력완료
        ,SCORE_GRADE    = @SCORE_GRADE
        ,SCORE_ORI      = @SCORE_ORI
        ,SCORE_WEIGHT   = @SCORE_WEIGHT
        ,GRADE_REASON   = @GRADE_REASON
        ,SCORE_ORI_LIST = @SCORE_ORI_LIST
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
    AND KPI_REF_ID      = @KPI_REF_ID
";

            
            strQuery2 = @"
UPDATE BSC_MBO_KPI_SCORE_DT
SET  SCORE_GRADE    = @SCORE_GRADE
    ,SCORE_ORI      = @SCORE_ORI
    ,SCORE_WEIGHT   = @SCORE_WEIGHT
    ,GRADE_REASON   = @GRADE_REASON
    ,SCORE_ORI_LIST = @SCORE_ORI_LIST
    ,UPDATE_USER    = @EST_EMP_ID
    ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
AND EST_ID          = @EST_ID
AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
AND ESTTERM_STEP_ID > @ESTTERM_STEP_ID
AND TGT_DEPT_ID     = @TGT_DEPT_ID
AND TGT_EMP_ID      = @TGT_EMP_ID
AND KPI_REF_ID      = @KPI_REF_ID
";

            IDbDataParameter[] paramArray;
            for (int i = 0; i < objGrade.GetLength(0); i++)
            {
                paramArray = null;
                paramArray = CreateDataParameters(15);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[10] = CreateDataParameter("@SCORE_GRADE", SqlDbType.VarChar);
                paramArray[11] = CreateDataParameter("@SCORE_ORI", SqlDbType.Decimal);
                paramArray[12] = CreateDataParameter("@SCORE_WEIGHT", SqlDbType.Decimal);
                paramArray[13] = CreateDataParameter("@GRADE_REASON", SqlDbType.VarChar);
                paramArray[14] = CreateDataParameter("@SCORE_ORI_LIST", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = objGrade[i, 0];
                paramArray[10].Value = objGrade[i, 1];
                paramArray[11].Value = objGrade[i, 2];
                paramArray[12].Value = objGrade[i, 3];
                paramArray[13].Value = objGrade[i, 4];
                paramArray[14].Value = objGrade[i, 5];


                try
                {
                    affectedRow += DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (isOverStep)
                {
                    try
                    {
                        paramArray = null;
                        paramArray = CreateDataParameters(14);
                        paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                        paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                        paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                        paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                        paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                        paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                        paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                        paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                        paramArray[8] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                        paramArray[9] = CreateDataParameter("@SCORE_GRADE", SqlDbType.VarChar);
                        paramArray[10] = CreateDataParameter("@SCORE_ORI", SqlDbType.Decimal);
                        paramArray[11] = CreateDataParameter("@SCORE_WEIGHT", SqlDbType.Decimal);
                        paramArray[12] = CreateDataParameter("@GRADE_REASON", SqlDbType.VarChar);
                        paramArray[13] = CreateDataParameter("@SCORE_ORI_LIST", SqlDbType.VarChar);

                        paramArray[0].Value = comp_id;
                        paramArray[1].Value = est_id;
                        paramArray[2].Value = estterm_ref_id;
                        paramArray[3].Value = estterm_sub_id;
                        paramArray[4].Value = estterm_step_id;
                        paramArray[5].Value = est_emp_id;
                        paramArray[6].Value = tgt_dept_id;
                        paramArray[7].Value = tgt_emp_id;
                        paramArray[8].Value = objGrade[i, 0];
                        paramArray[9].Value = objGrade[i, 1];
                        paramArray[10].Value = objGrade[i, 2];
                        paramArray[11].Value = objGrade[i, 3];
                        paramArray[12].Value = objGrade[i, 4];
                        paramArray[13].Value = objGrade[i, 5];

                        int affect = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery2, GetQueryStringReplace(strQuery2)), paramArray, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            if (affectedRow < objGrade.GetLength(0))
                return false;


            strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
SET  SCORE          = ISNULL(B.SUM_SCORE, 0)
    ,UPDATE_USER    = @EST_EMP_ID
    ,UPDATE_DATE    = GETDATE()
FROM    BSC_MBO_KPI_SCORE_MT    A
LEFT OUTER JOIN (
SELECT ISNULL(SUM(SCORE_WEIGHT), 0) AS SUM_SCORE
FROM    BSC_MBO_KPI_SCORE_DT    
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
)   AS B    ON  1=1
WHERE   A.COMP_ID         = @COMP_ID
AND A.EST_ID          = @EST_ID
AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
AND A.ESTTERM_STEP_ID = @ESTTERM_STEP_ID
AND A.EST_DEPT_ID     = @EST_DEPT_ID
AND A.EST_EMP_ID      = @EST_EMP_ID
AND A.TGT_DEPT_ID     = @TGT_DEPT_ID
AND A.TGT_EMP_ID      = @TGT_EMP_ID
";
            strQuery2 = @"
UPDATE BSC_MBO_KPI_SCORE_MT A
SET  A.SCORE          = NVL((SELECT SUM(B.SCORE_WEIGHT) 
                                FROM BSC_MBO_KPI_SCORE_DT B 
                                WHERE   B.COMP_ID = A.COMP_ID
                                    AND B.EST_ID = A.EST_ID
                                    AND B.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                    AND B.EST_DEPT_ID     = A.EST_DEPT_ID
                                    AND B.EST_EMP_ID      = A.EST_EMP_ID
                                    AND B.TGT_DEPT_ID     = A.TGT_DEPT_ID
                                    AND B.TGT_EMP_ID      = A.TGT_EMP_ID
                        ), 0)
    ,A.UPDATE_USER    = @EST_EMP_ID
    ,A.UPDATE_DATE    = SYSDATE
WHERE   A.COMP_ID         = @COMP_ID
AND A.EST_ID          = @EST_ID
AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
AND A.ESTTERM_STEP_ID = @ESTTERM_STEP_ID
AND A.EST_DEPT_ID     = @EST_DEPT_ID
AND A.EST_EMP_ID      = @EST_EMP_ID
AND A.TGT_DEPT_ID     = @TGT_DEPT_ID
AND A.TGT_EMP_ID      = @TGT_EMP_ID
AND EXISTS (SELECT 'X' FROM BSC_MBO_KPI_SCORE_DT B 
                                WHERE   B.COMP_ID = A.COMP_ID
                                    AND B.EST_ID = A.EST_ID
                                    AND B.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                    AND B.EST_DEPT_ID     = A.EST_DEPT_ID
                                    AND B.EST_EMP_ID      = A.EST_EMP_ID
                                    AND B.TGT_DEPT_ID     = A.TGT_DEPT_ID
                                    AND B.TGT_EMP_ID      = A.TGT_EMP_ID)
";
            paramArray = null;
            paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = est_dept_id;
            paramArray[6].Value = est_emp_id;
            paramArray[7].Value = tgt_dept_id;
            paramArray[8].Value = tgt_emp_id;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, strQuery2), paramArray, CommandType.Text);
            if (affectedRow < 1)
                return false;

//est_data score update

            strQuery = @"
UPDATE EST_DATA
SET  POINT          = ISNULL(B.SUM_SCORE, 0)
    ,UPDATE_USER    = @EST_EMP_ID
    ,UPDATE_DATE    = GETDATE()
FROM    EST_DATA    A
LEFT OUTER JOIN (
SELECT ISNULL(SUM(SCORE_WEIGHT), 0) AS SUM_SCORE
FROM    BSC_MBO_KPI_SCORE_DT    
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
)   AS B    ON  1=1
WHERE   A.COMP_ID         = @COMP_ID
AND A.EST_ID          = @EST_ID
AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
AND A.ESTTERM_STEP_ID = @ESTTERM_STEP_ID
AND A.EST_DEPT_ID     = @EST_DEPT_ID
AND A.EST_EMP_ID      = @EST_EMP_ID
AND A.TGT_DEPT_ID     = @TGT_DEPT_ID
AND A.TGT_EMP_ID      = @TGT_EMP_ID
";
            strQuery2 = @"
UPDATE EST_DATA A
SET  A.POINT          = NVL((SELECT SUM(B.SCORE_WEIGHT) 
                                FROM BSC_MBO_KPI_SCORE_DT B 
                                WHERE   B.COMP_ID = A.COMP_ID
                                    AND B.EST_ID = A.EST_ID
                                    AND B.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                    AND B.EST_DEPT_ID     = A.EST_DEPT_ID
                                    AND B.EST_EMP_ID      = A.EST_EMP_ID
                                    AND B.TGT_DEPT_ID     = A.TGT_DEPT_ID
                                    AND B.TGT_EMP_ID      = A.TGT_EMP_ID
                        ), 0)
    ,A.UPDATE_USER    = @EST_EMP_ID
    ,A.UPDATE_DATE    = SYSDATE
WHERE   A.COMP_ID         = @COMP_ID
AND A.EST_ID          = @EST_ID
AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
AND A.ESTTERM_STEP_ID = @ESTTERM_STEP_ID
AND A.EST_DEPT_ID     = @EST_DEPT_ID
AND A.EST_EMP_ID      = @EST_EMP_ID
AND A.TGT_DEPT_ID     = @TGT_DEPT_ID
AND A.TGT_EMP_ID      = @TGT_EMP_ID
AND EXISTS (SELECT 'X' FROM BSC_MBO_KPI_SCORE_DT B 
                                WHERE   B.COMP_ID = A.COMP_ID
                                    AND B.EST_ID = A.EST_ID
                                    AND B.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                    AND B.EST_DEPT_ID     = A.EST_DEPT_ID
                                    AND B.EST_EMP_ID      = A.EST_EMP_ID
                                    AND B.TGT_DEPT_ID     = A.TGT_DEPT_ID
                                    AND B.TGT_EMP_ID      = A.TGT_EMP_ID)
";
            paramArray = null;
            paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = est_dept_id;
            paramArray[6].Value = est_emp_id;
            paramArray[7].Value = tgt_dept_id;
            paramArray[8].Value = tgt_emp_id;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, strQuery2), paramArray, CommandType.Text);
            if (affectedRow < 1)
                return false;
            if (!isOverStep)
            {
                return true;
            }
            else
            {
                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
SET  SCORE          = ISNULL(B.SUM_SCORE, 0)
    ,UPDATE_USER    = @EST_EMP_ID
    ,UPDATE_DATE    = GETDATE()
FROM    BSC_MBO_KPI_SCORE_MT    A
LEFT OUTER JOIN (
SELECT ISNULL(SUM(SCORE_WEIGHT), 0) AS SUM_SCORE
FROM    BSC_MBO_KPI_SCORE_DT    
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
)   AS B    ON  1=1
WHERE   A.COMP_ID         = @COMP_ID
AND A.EST_ID          = @EST_ID
AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
AND A.ESTTERM_STEP_ID > @ESTTERM_STEP_ID
AND A.TGT_DEPT_ID     = @TGT_DEPT_ID
AND A.TGT_EMP_ID      = @TGT_EMP_ID
";
                strQuery2 = @"
UPDATE BSC_MBO_KPI_SCORE_MT A
SET  A.SCORE          = NVL((SELECT SUM(B.SCORE_WEIGHT) 
                                FROM BSC_MBO_KPI_SCORE_DT B 
                                WHERE   B.COMP_ID = A.COMP_ID
                                    AND B.EST_ID = A.EST_ID
                                    AND B.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID = @ESTTERM_STEP_ID
                                    AND B.EST_DEPT_ID     = @EST_DEPT_ID
                                    AND B.EST_EMP_ID      = @EST_EMP_ID
                                    AND B.TGT_DEPT_ID     = A.TGT_DEPT_ID
                                    AND B.TGT_EMP_ID      = A.TGT_EMP_ID
                        ), 0)
    ,A.UPDATE_USER    = @EST_EMP_ID
    ,A.UPDATE_DATE    = SYSDATE
WHERE   A.COMP_ID         = @COMP_ID
AND A.EST_ID          = @EST_ID
AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
AND A.ESTTERM_STEP_ID > @ESTTERM_STEP_ID
AND A.TGT_DEPT_ID     = @TGT_DEPT_ID
AND A.TGT_EMP_ID      = @TGT_EMP_ID
AND EXISTS (SELECT 'X' FROM BSC_MBO_KPI_SCORE_DT B 
                                WHERE   B.COMP_ID = A.COMP_ID
                                    AND B.EST_ID = A.EST_ID
                                    AND B.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                    AND B.EST_DEPT_ID     = A.EST_DEPT_ID
                                    AND B.EST_EMP_ID      = A.EST_EMP_ID
                                    AND B.TGT_DEPT_ID     = A.TGT_DEPT_ID
                                    AND B.TGT_EMP_ID      = A.TGT_EMP_ID)
";

                paramArray = null;
                paramArray = CreateDataParameters(9);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, strQuery2), paramArray, CommandType.Text);
                return true;
            }
            
        }

        public bool UpdateMboMTGrade(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment)
        {
            int affectedRow = 0;
            string strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = 'O' --N: 미평가, O:실적입력중, C: 실적입력완료
        ,COMMENT        = @COMMENTS
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9] = CreateDataParameter("@COMMENTS", SqlDbType.NText);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = est_dept_id;
            paramArray[6].Value = est_emp_id;
            paramArray[7].Value = tgt_dept_id;
            paramArray[8].Value = tgt_emp_id;
            paramArray[9].Value = comment;

            try
            {
                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateMboEstDTStatus(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string status)
        {
            string strQuery = @"
IF EXISTS(SELECT * FROM BSC_MBO_KPI_REPORT WHERE COMP_ID=@COMP_ID AND EST_ID=@EST_ID AND ESTTERM_REF_ID=@ESTTERM_REF_ID AND ESTTERM_SUB_ID=@ESTTERM_SUB_ID
    AND TGT_EMP_ID=@TGT_EMP_ID AND ISNULL(STATUS, '')='C')
        UPDATE BSC_MBO_KPI_SCORE_DT
            SET  STATUS         = @STATUS --실적보고입력, N: 미평가, O:실적보고입력, C: 실적보고완료
                ,UPDATE_USER    = @EST_EMP_ID
                ,UPDATE_DATE    = GETDATE()
        WHERE   COMP_ID         = @COMP_ID
            AND EST_ID          = @EST_ID
            AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
            AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
            AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
            AND EST_DEPT_ID     = @EST_DEPT_ID
            AND EST_EMP_ID      = @EST_EMP_ID
            AND TGT_DEPT_ID     = @TGT_DEPT_ID
            AND TGT_EMP_ID      = @TGT_EMP_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(10);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = est_dept_id;
            paramArray[6].Value = est_emp_id;
            paramArray[7].Value = tgt_dept_id;
            paramArray[8].Value = tgt_emp_id;
            paramArray[9].Value = status;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                if (affectedRow > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateMboEstMTStatus(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string status)
        {
            string strQuery = string.Empty;
            IDbDataParameter[] paramArray = null;
            int affectedRow = 0;

            if (estterm_step_id > 2)
            {
                strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE   COMP_ID=@COMP_ID 
    AND EST_ID          = @EST_ID 
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID 
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID - 1 
    AND TGT_DEPT_ID     = @TGT_DEPT_ID 
    AND TGT_EMP_ID      = @TGT_EMP_ID 
    AND ISNULL(STATUS, '') = 'C'
";
                paramArray = null;
                paramArray = CreateDataParameters(7);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = tgt_dept_id;
                paramArray[6].Value = tgt_emp_id;

                affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
                if (affectedRow < 1)
                    return false;

                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS --실적보고입력, N: 미평가, O:실적보고입력, C: 실적보고완료
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(10);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = status;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;
            }
            else
            {
                strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_REPORT 
WHERE   COMP_ID            = @COMP_ID 
    AND EST_ID             = @EST_ID 
    AND ESTTERM_REF_ID     = @ESTTERM_REF_ID 
    AND ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
    AND TGT_DEPT_ID        = @TGT_DEPT_ID
    AND TGT_EMP_ID         = @TGT_EMP_ID 
    AND ISNULL(STATUS, '') = 'C'
";
                paramArray = null;
                paramArray = CreateDataParameters(6);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = tgt_dept_id;
                paramArray[5].Value = tgt_emp_id;

                affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
                if (affectedRow < 1)
                    return false;


                affectedRow = 0;
                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS --실적보고입력, N: 미평가, O:실적보고입력, C: 실적보고완료
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(10);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = status;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;

            }

            affectedRow = 0;
            //est_data status_id 평가중('P')
            strQuery = @"
UPDATE  EST_DATA
    SET  STATUS_ID      = 'P'
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @EST_EMP_ID
WHERE   COMP_ID             = @COMP_ID
        AND EST_ID          = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND EST_DEPT_ID     = @EST_DEPT_ID
        AND EST_EMP_ID      = @EST_EMP_ID
        AND TGT_DEPT_ID     = @TGT_DEPT_ID
        AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = est_dept_id;
            paramArray[6].Value = est_emp_id;
            paramArray[7].Value = tgt_dept_id;
            paramArray[8].Value = tgt_emp_id;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public bool UpdateMboReport(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string report
                                    , string report_file
                                    , string status)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE COMP_ID = @COMP_ID 
  AND EST_ID  = @EST_ID 
  AND ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND TGT_DEPT_ID    = @TGT_DEPT_ID 
  AND TGT_EMP_ID     = @TGT_EMP_ID 
  AND ISNULL(STATUS, '') <> 'N' 
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_dept_id;
            paramArray[5].Value = tgt_emp_id;
            
            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
            
            if (affectedRow > 0)
                return false;

            strQuery = @"
UPDATE BSC_MBO_KPI_REPORT
    SET  REPORT         = @REPORT
        ,REPORT_FILE    = @REPORT_FILE
        ,STATUS         = @STATUS --실적보고입력, N: 미평가, O:실적보고입력, C: 실적보고완료
        ,UPDATE_USER    = @TGT_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@REPORT", SqlDbType.NText);
            paramArray[7] = CreateDataParameter("@REPORT_FILE", SqlDbType.VarChar);
            paramArray[8] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_dept_id;
            paramArray[5].Value = tgt_emp_id;
            paramArray[6].Value = report;
            paramArray[7].Value = report_file;
            paramArray[8].Value = status;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
            if (affectedRow > 0)
                return true;

            return false;
        }

        public bool UpdateMboReport_3A(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string report
                                    , string report_file
                                    , string status)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE   COMP_ID=@COMP_ID AND EST_ID=@EST_ID AND ESTTERM_REF_ID=@ESTTERM_REF_ID AND ESTTERM_SUB_ID=@ESTTERM_SUB_ID
    AND TGT_EMP_ID=@TGT_EMP_ID AND ISNULL(STATUS, '')<>'N'
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;

            if (affectedRow > 0)
                return false;

            strQuery = @"
UPDATE BSC_MBO_KPI_REPORT
    SET  REPORT         = @REPORT
        ,REPORT_FILE    = @REPORT_FILE
        ,STATUS         = @STATUS --실적보고입력, N: 미평가, O:실적보고입력, C: 실적보고완료
        ,UPDATE_USER    = @TGT_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@REPORT", SqlDbType.NText);
            paramArray[7] = CreateDataParameter("@REPORT_FILE", SqlDbType.VarChar);
            paramArray[8] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_dept_id;
            paramArray[5].Value = tgt_emp_id;
            paramArray[6].Value = report;
            paramArray[7].Value = report_file;
            paramArray[8].Value = status;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
            if (affectedRow > 0)
                return true;

            return false;
        }

        public bool UpdateMboEst(IDbConnection idc
                                , IDbTransaction idt
                                , int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , string comment
                                , string status)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE COMP_ID = @COMP_ID 
  AND EST_ID  = @EST_ID 
  AND ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND TGT_DEPT_ID    = @TGT_DEPT_ID 
  AND TGT_EMP_ID     = @TGT_EMP_ID 
  AND STATUS IN ('P', 'E')
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_dept_id;
            paramArray[5].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
            if (affectedRow > 0)
                return false;

            strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  COMMENT        = @COMMENTS
        ,STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(11);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
            paramArray[10] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = est_dept_id;
            paramArray[6].Value = est_emp_id;
            paramArray[7].Value = tgt_dept_id;
            paramArray[8].Value = tgt_emp_id;
            paramArray[9].Value = comment;
            paramArray[10].Value = status;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
            if (affectedRow < 1)
                return false;

            strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_DT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(10);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = est_dept_id;
            paramArray[6].Value = est_emp_id;
            paramArray[7].Value = tgt_dept_id;
            paramArray[8].Value = tgt_emp_id;
            paramArray[9].Value = status;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
            if (affectedRow > 0)
                return true;
            return false;
        }

        public bool UpdateMboEstCancel(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment
                                    , string status)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE COMP_ID = @COMP_ID 
  AND EST_ID  = @EST_ID 
  AND ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND TGT_DEPT_ID = @TGT_DEPT_ID 
  AND TGT_EMP_ID  = @TGT_EMP_ID 
  AND STATUS IN ('O', 'P', 'E')
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_dept_id;
            paramArray[5].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, strQuery, "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
            if (affectedRow < 1)
            {
                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID >= @ESTTERM_STEP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(9);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_emp_id;
                paramArray[6].Value = tgt_dept_id;
                paramArray[7].Value = tgt_emp_id;
                paramArray[8].Value = status;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);

                if (affectedRow < 1)
                    return false;
                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_DT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID >= @ESTTERM_STEP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(9);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_emp_id;
                paramArray[6].Value = tgt_dept_id;
                paramArray[7].Value = tgt_emp_id;
                paramArray[8].Value = status;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);

                if (affectedRow < 1)
                    return false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateMboEstReject(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment
                                    , string status
                                    , string confirm_type)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE   COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID AND STATUS IN ('E')
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
            
            if (affectedRow < 1)
            {
                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(8);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = est_emp_id;
                paramArray[5].Value = tgt_dept_id;
                paramArray[6].Value = tgt_emp_id;
                paramArray[7].Value = status;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;

                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_DT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(8);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = est_emp_id;
                paramArray[5].Value = tgt_dept_id;
                paramArray[6].Value = tgt_emp_id;
                paramArray[7].Value = status;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;

                strQuery = @"
INSERT INTO EST_QUESTION_COMMENT 
    (COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
    ,EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, SEQ
    ,COMMENT  , EST_TGT_TYPE, CONFIRM_TYPE, CREATE_DATE, CREATE_USER)
SELECT
    @COMP_ID, @EST_ID, @ESTTERM_REF_ID, @ESTTERM_SUB_ID, @ESTTERM_STEP_ID
    ,@EST_DEPT_ID, @EST_EMP_ID, @TGT_DEPT_ID, @TGT_EMP_ID, ISNULL(MAX(SEQ), 0) +1
    ,@COMMENTS, 'TGT', @CONFIRM_TYPE, GETDATE(), @TGT_EMP_ID
FROM EST_QUESTION_COMMENT
WHERE COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(11);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
                paramArray[10] = CreateDataParameter("@CONFIRM_TYPE", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = comment;
                paramArray[10].Value = confirm_type;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }


        public bool UpdateMboEstReject_3A(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment
                                    , string status
                                    , string confirm_type)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE   COMP_ID = @COMP_ID 
  AND   EST_ID  = @EST_ID 
  AND   ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND   ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND   EST_EMP_ID = @EST_EMP_ID 
  AND   EST_DEPT_ID = @EST_DEPT_ID 
  AND   TGT_EMP_ID = @TGT_EMP_ID 
  AND   TGT_DEPT_ID = @TGT_DEPT_ID 
  AND   STATUS IN ('E')
";
            IDbDataParameter[] paramArray = CreateDataParameters(8);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);


            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = est_dept_id;
            paramArray[5].Value = est_emp_id;
            paramArray[6].Value = tgt_dept_id;
            paramArray[7].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;

            if (affectedRow < 1)
            {
                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(9);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = est_dept_id;
                paramArray[5].Value = est_emp_id;
                paramArray[6].Value = tgt_dept_id;
                paramArray[7].Value = tgt_emp_id;
                paramArray[8].Value = status;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;

                strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_DT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정
        ,UPDATE_USER    = @EST_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(9);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = est_dept_id;
                paramArray[5].Value = est_emp_id;
                paramArray[6].Value = tgt_dept_id;
                paramArray[7].Value = tgt_emp_id;
                paramArray[8].Value = status;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;

                strQuery = @"
INSERT INTO EST_QUESTION_COMMENT 
    (COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
    ,EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, SEQ
    ,COMMENT , EST_TGT_TYPE, CONFIRM_TYPE, CREATE_DATE, CREATE_USER)
SELECT
    @COMP_ID, @EST_ID, @ESTTERM_REF_ID, @ESTTERM_SUB_ID, @ESTTERM_STEP_ID
    ,@EST_DEPT_ID, @EST_EMP_ID, @TGT_DEPT_ID, @TGT_EMP_ID, ISNULL(MAX(SEQ), 0) +1
    ,@COMMENTS , 'TGT', @CONFIRM_TYPE, GETDATE(), @TGT_EMP_ID
FROM EST_QUESTION_COMMENT
WHERE COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(11);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
                paramArray[10] = CreateDataParameter("@CONFIRM_TYPE", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = comment;
                paramArray[10].Value = confirm_type;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                if (affectedRow > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateMboFeedBack(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string status)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE   COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID AND STATUS NOT IN ('C', 'P')
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
            if (affectedRow > 0)
                return false;

            strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정, P:피드백입력, E:완료
        ,UPDATE_USER    = @TGT_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(7);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_dept_id;
            paramArray[5].Value = tgt_emp_id;
            paramArray[6].Value = status;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
            if (affectedRow < 1)
                return false;

            if (seq == 0)
            {
                strQuery = @"
INSERT INTO EST_QUESTION_COMMENT 
    (COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
    ,EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, SEQ
    ,COMMENT  , EST_TGT_TYPE, CONFIRM_TYPE, CREATE_DATE, CREATE_USER)
SELECT
    @COMP_ID, @EST_ID, @ESTTERM_REF_ID, @ESTTERM_SUB_ID, @ESTTERM_STEP_ID
    ,@EST_DEPT_ID, @EST_EMP_ID, @TGT_DEPT_ID, @TGT_EMP_ID, ISNULL(MAX(SEQ), 0)+1
    ,@COMMENTS, 'TGT', 'INP', GETDATE(), @TGT_EMP_ID
FROM EST_QUESTION_COMMENT
WHERE COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(10);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@COMMENTS", SqlDbType.NText);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = comment;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;

            }
            else
            {
                strQuery = @"
UPDATE EST_QUESTION_COMMENT 
    SET  COMMENT        = @COMMENTS
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @TGT_EMP_ID
WHERE COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID AND SEQ = @SEQ
";
                paramArray = null;
                paramArray = CreateDataParameters(7);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
                paramArray[6] = CreateDataParameter("@SEQ", SqlDbType.Int);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = tgt_emp_id;
                paramArray[5].Value = comment;
                paramArray[6].Value = seq;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;
            }

            return true;
        }

        public bool UpdateMboFeedBack_3A(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string status)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE COMP_ID = @COMP_ID 
  AND EST_ID = @EST_ID 
  AND ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
  AND EST_DEPT_ID    = @EST_DEPT_ID
  AND EST_EMP_ID     = @EST_EMP_ID 
  AND TGT_DEPT_ID    = @TGT_DEPT_ID
  AND TGT_EMP_ID     = @TGT_EMP_ID 
  AND STATUS NOT IN ('C', 'P')
";
            IDbDataParameter[] paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = est_dept_id;
            paramArray[6].Value = est_emp_id;
            paramArray[7].Value = tgt_dept_id;
            paramArray[8].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
            if (affectedRow > 0)
                return false;

            strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정, P:피드백입력, E:완료
        ,UPDATE_USER    = @TGT_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND EST_DEPT_ID     = @EST_DEPT_ID
    AND EST_EMP_ID      = @EST_EMP_ID 
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = est_dept_id;
            paramArray[5].Value = est_emp_id;
            paramArray[6].Value = tgt_dept_id;
            paramArray[7].Value = tgt_emp_id;
            paramArray[8].Value = status;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
            if (affectedRow < 1)
                return false;

            if (seq == 0)
            {
                strQuery = @"
INSERT INTO EST_QUESTION_COMMENT 
    (COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
    ,EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, SEQ
    ,COMMENT , EST_TGT_TYPE, CONFIRM_TYPE, CREATE_DATE, CREATE_USER)
SELECT
    @COMP_ID, @EST_ID, @ESTTERM_REF_ID, @ESTTERM_SUB_ID, @ESTTERM_STEP_ID
    ,@EST_DEPT_ID, @EST_EMP_ID, @TGT_DEPT_ID, @TGT_EMP_ID, ISNULL(MAX(SEQ), 0)+1
    ,@COMMENTS, 'TGT', 'INP', GETDATE(), @TGT_EMP_ID
FROM EST_QUESTION_COMMENT
WHERE COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(10);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@COMMENTS", SqlDbType.NText);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = comment;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;

            }
            else
            {
                strQuery = @"
UPDATE EST_QUESTION_COMMENT 
    SET  COMMENT        = @COMMENTS
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @TGT_EMP_ID
WHERE COMP_ID = @COMP_ID 
  AND EST_ID  = @EST_ID 
  AND ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND TGT_EMP_ID = @TGT_EMP_ID 
  AND SEQ        = @SEQ
";
                paramArray = null;
                paramArray = CreateDataParameters(7);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
                paramArray[6] = CreateDataParameter("@SEQ", SqlDbType.Int);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = tgt_emp_id;
                paramArray[5].Value = comment;
                paramArray[6].Value = seq;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                if (affectedRow < 1)
                    return false;
            }

            return true;
        }

        public bool UpdateMboFeedBack(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string status
                                    , string confirm_type)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE   COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID AND STATUS NOT IN ('C', 'P')
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_emp_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
            if (affectedRow > 0)
                return false;

            strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정, P:피드백입력, E:완료
        ,UPDATE_USER    = @TGT_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(7);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = tgt_dept_id;
            paramArray[5].Value = tgt_emp_id;
            paramArray[6].Value = status;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);

            if (seq == 0)
            {
                strQuery = @"
INSERT INTO EST_QUESTION_COMMENT 
    (COMP_ID
    , EST_ID
    , ESTTERM_REF_ID
    , ESTTERM_SUB_ID
    , ESTTERM_STEP_ID
    , EST_DEPT_ID
    , EST_EMP_ID
    , TGT_DEPT_ID
    , TGT_EMP_ID, SEQ
    , COMMENT 
    , EST_TGT_TYPE
    , CONFIRM_TYPE
    , CREATE_DATE
    , CREATE_USER
    )
SELECT @COMP_ID
     , @EST_ID
    , @ESTTERM_REF_ID
    , @ESTTERM_SUB_ID
    , @ESTTERM_STEP_ID
    , @EST_DEPT_ID
    , @EST_EMP_ID
    , @TGT_DEPT_ID
    , @TGT_EMP_ID
    , ISNULL(MAX(SEQ), 0) +1
    , @COMMENTS
    , 'TGT'
    , @CONFIRM_TYPE
    , GETDATE()
    , @TGT_EMP_ID
FROM EST_QUESTION_COMMENT
WHERE COMP_ID    = @COMP_ID 
  AND EST_ID     = @EST_ID 
  AND ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND TGT_EMP_ID     = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(11);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
                paramArray[10] = CreateDataParameter("@CONFIRM_TYPE", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = comment;
                paramArray[10].Value = confirm_type;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow > 0)
                    return true;
            }
            else
            {
                strQuery = @"
UPDATE EST_QUESTION_COMMENT 
    SET  COMMENT        = @COMMENTS
        ,CONFIRM_TYPE   = @CONFIRM_TYPE
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @TGT_EMP_ID
WHERE COMP_ID = @COMP_ID 
  AND EST_ID  = @EST_ID 
  AND ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND TGT_EMP_ID     = @TGT_EMP_ID 
  AND SEQ            = @SEQ
";
                paramArray = null;
                paramArray = CreateDataParameters(8);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
                paramArray[6] = CreateDataParameter("@SEQ", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@CONFIRM_TYPE", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = tgt_emp_id;
                paramArray[5].Value = comment;
                paramArray[6].Value = seq;
                paramArray[7].Value = confirm_type;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);
                if (affectedRow > 0)
                    return true;
            }

            return false;
        }


        public bool UpdateMboFeedBack_3A(IDbConnection idc
                                    , IDbTransaction idt
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string status
                                    , string confirm_type)
        {
            string strQuery = @"
SELECT * 
FROM BSC_MBO_KPI_SCORE_MT 
WHERE   COMP_ID = @COMP_ID 
  AND   EST_ID  = @EST_ID 
  AND   ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND   ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND   ESTTERM_STEP_ID = @ESTTERM_STEP_ID
  AND   EST_DEPT_ID = @EST_DEPT_ID 
  AND   EST_EMP_ID  = @EST_EMP_ID 
  AND   TGT_DEPT_ID = @TGT_DEPT_ID 
  AND   TGT_EMP_ID  = @TGT_EMP_ID 
  AND   STATUS NOT IN ('C', 'P')
";
            IDbDataParameter[] paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = est_dept_id;
            paramArray[5].Value = est_emp_id;
            paramArray[6].Value = tgt_dept_id;
            paramArray[7].Value = tgt_emp_id;
            paramArray[8].Value = estterm_step_id;

            int affectedRow = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), "EST_DATA", null, paramArray, CommandType.Text).Tables[0].Rows.Count;
            if (affectedRow > 0)
                return false;

            strQuery = @"
UPDATE BSC_MBO_KPI_SCORE_MT
    SET  STATUS         = @STATUS -- N: 미평가, O:평가입력중, C: 평가확정, P:피드백입력, E:완료
        ,UPDATE_USER    = @TGT_EMP_ID
        ,UPDATE_DATE    = GETDATE()
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND   EST_DEPT_ID = @EST_DEPT_ID 
    AND   EST_EMP_ID  = @EST_EMP_ID 
    AND TGT_DEPT_ID     = @TGT_DEPT_ID
    AND TGT_EMP_ID      = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@STATUS", SqlDbType.VarChar);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = est_dept_id;
            paramArray[5].Value = est_emp_id;
            paramArray[6].Value = tgt_dept_id;
            paramArray[7].Value = tgt_emp_id;
            paramArray[8].Value = status;

            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb(strQuery, GetQueryStringReplace(strQuery)), paramArray, CommandType.Text);

            if (seq == 0)
            {
                strQuery = @"
INSERT INTO EST_QUESTION_COMMENT 
    (COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
    ,EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, SEQ
    ,COMMENT , EST_TGT_TYPE, CONFIRM_TYPE, CREATE_DATE, CREATE_USER)
SELECT
    @COMP_ID, @EST_ID, @ESTTERM_REF_ID, @ESTTERM_SUB_ID, @ESTTERM_STEP_ID
    ,@EST_DEPT_ID, @EST_EMP_ID, @TGT_DEPT_ID, @TGT_EMP_ID, ISNULL(MAX(SEQ), 0) +1
    ,@COMMENTS, 'TGT', @CONFIRM_TYPE, GETDATE(), @TGT_EMP_ID
FROM EST_QUESTION_COMMENT
WHERE COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
    AND TGT_EMP_ID = @TGT_EMP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(11);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[9] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
                paramArray[10] = CreateDataParameter("@CONFIRM_TYPE", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = estterm_step_id;
                paramArray[5].Value = est_dept_id;
                paramArray[6].Value = est_emp_id;
                paramArray[7].Value = tgt_dept_id;
                paramArray[8].Value = tgt_emp_id;
                paramArray[9].Value = comment;
                paramArray[10].Value = confirm_type;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                if (affectedRow > 0)
                    return true;
            }
            else
            {
                strQuery = @"
UPDATE EST_QUESTION_COMMENT 
    SET  COMMENT        = @COMMENTS
        ,CONFIRM_TYPE   = @CONFIRM_TYPE
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @TGT_EMP_ID
WHERE COMP_ID = @COMP_ID 
  AND EST_ID  = @EST_ID 
  AND ESTTERM_REF_ID = @ESTTERM_REF_ID 
  AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
  AND TGT_EMP_ID     = @TGT_EMP_ID 
  AND SEQ            = @SEQ
";
                paramArray = null;
                paramArray = CreateDataParameters(8);
                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@COMMENTS", SqlDbType.NText);
                paramArray[6] = CreateDataParameter("@SEQ", SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@CONFIRM_TYPE", SqlDbType.VarChar);

                paramArray[0].Value = comp_id;
                paramArray[1].Value = est_id;
                paramArray[2].Value = estterm_ref_id;
                paramArray[3].Value = estterm_sub_id;
                paramArray[4].Value = tgt_emp_id;
                paramArray[5].Value = comment;
                paramArray[6].Value = seq;
                paramArray[7].Value = confirm_type;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                if (affectedRow > 0)
                    return true;
            }

            return false;
        }


        public DataSet Get3GAKpiDataList(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id)
        {
            //[0] 평가데이터
            string query = @"
SELECT   F.KPI_CODE
        ,H.DEPT_NAME                AS COM_DEPT_NAME
        ,G.KPI_NAME
        ,E.EMP_NAME
        ,CASE G.KPI_GROUP_REF_ID WHEN 'QTT' THEN '계량' WHEN 'QLT' THEN '비계량' ELSE '' END AS KPI_GROUP_NAME--I.CODE_NAME                AS KPI_GROUP_NAME
        ,K.CODE_NAME                AS CLASS_NAME
        ,ISNULL(L.CATEGORY_NAME, ' ') + '/' + ISNULL(M.CATEGORY_NAME, ' ')  + '/' + ISNULL(N.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,ISNULL(O.UNIT, '-')        AS UNIT_NAME
        ,D.WEIGHT
        ,ISNULL(Q.TARGET_TS, 0) AS TARGET_TS
        ,ISNULL(R.RESULT_TS, 0) AS RESULT_TS
        ,CASE WHEN ISNULL(Q.TARGET_TS, 0) = 0 THEN 0 ELSE ISNULL(R.RESULT_TS / Q.TARGET_TS * 100, 0) END   AS ACHIEVEMENT_RATE
        ,U1.SET_MIN_VALUE   AS GRADE_S
        ,U1.SET_TXT_VALUE
        ,U2.SET_MIN_VALUE   AS GRADE_A
        ,U2.SET_TXT_VALUE
        ,U3.SET_MIN_VALUE   AS GRADE_B
        ,U3.SET_TXT_VALUE
        ,U4.SET_MIN_VALUE   AS GRADE_C
        ,U4.SET_TXT_VALUE
        ,U5.SET_MIN_VALUE   AS GRADE_D
        ,U5.SET_TXT_VALUE
        --,CASE WHEN ISNULL(S.APP_STATUS, ' ')  = 'CFT' THEN 'O' ELSE 'X' END AS APP_STATUS
        ,ISNULL(S.APP_STATUS, 'NFT') AS APP_STATUS
        ,C.SCORE_ORI
        ,C.SCORE_ORI_LIST
        ,ISNULL(C.SCORE_WEIGHT, 0)  AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_GRADE, '') AS GRADE
        ,C.GRADE_REASON
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,C.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
        ,C.KPI_REF_ID
        ,T.ESTTERM_STEP_NAME
        ,J.KPI_CLASS_REF_ID
        ,G.KPI_GROUP_REF_ID
        ,ISNULL(Z.SCORE_GRADE, ' ') AS GRADE_ORG
        ,G.KPI_POOL_REF_ID
        ,G.BASIS_USE_YN
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    E   ON  E.EMP_REF_ID        = D.EMP_REF_ID
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_DEPT_INFO   H   ON  H.DEPT_REF_ID       = C.TGT_DEPT_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  I   ON  I.ETC_CODE  = G.KPI_GROUP_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014') K   ON  K.ETC_CODE  = J.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                L   ON  L.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                M   ON  M.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND M.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                N   ON  N.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND N.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
                                                        AND N.CATEGORY_LOW_REF_ID   = G.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO  O  ON O.UNIT_TYPE_REF_ID  = F.UNIT_TYPE_REF_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  P   ON  P.ESTTERM_REF_ID    = J.ESTTERM_REF_ID
                                            AND P.KPI_REF_ID        = J.KPI_REF_ID
                                            AND P.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          Q   ON  Q.ESTTERM_REF_ID    = P.ESTTERM_REF_ID
                                            AND Q.KPI_REF_ID        = P.KPI_REF_ID
                                            AND Q.KPI_TARGET_VERSION_ID = P.KPI_TARGET_VERSION_ID
                                            AND Q.YMD                   = C.YMD
LEFT OUTER JOIN BSC_KPI_RESULT          R   ON  R.ESTTERM_REF_ID    = Q.ESTTERM_REF_ID
                                            AND R.KPI_REF_ID        = Q.KPI_REF_ID
                                            AND R.YMD               = Q.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO       S   ON  S.APP_REF_ID        = R.APP_REF_ID
                                            AND S.ACTIVE_YN    = 'Y'
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U1  ON  U1.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U1.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U1.THRESHOLD_REF_ID = 1
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U2  ON  U2.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U2.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U2.THRESHOLD_REF_ID = 2
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U3  ON  U3.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U3.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U3.THRESHOLD_REF_ID = 3
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U4  ON  U4.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U4.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U4.THRESHOLD_REF_ID = 4
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U5  ON  U5.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U5.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U5.THRESHOLD_REF_ID = 5
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";
            string queryOra = @"
SELECT   F.KPI_CODE
        ,H.DEPT_NAME                AS COM_DEPT_NAME
        ,G.KPI_NAME
        ,E.EMP_NAME
        ,CASE G.KPI_GROUP_REF_ID WHEN 'QTT' THEN '계량' WHEN 'QLT' THEN '비계량' ELSE '' END AS KPI_GROUP_NAME
        ,K.CODE_NAME                AS CLASS_NAME
        ,NVL(L.CATEGORY_NAME, ' ') || '/' || NVL(M.CATEGORY_NAME, ' ')  || '/' + NVL(N.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,NVL(O.UNIT, '-')        AS UNIT_NAME
        ,D.WEIGHT
        ,NVL(Q.TARGET_TS, 0) AS TARGET_TS
        ,NVL(R.RESULT_TS, 0) AS RESULT_TS
        ,CASE WHEN NVL(Q.TARGET_TS, 0) = 0 THEN 0 ELSE ROUND(NVL(R.RESULT_TS / Q.TARGET_TS * 100, 0),4) END   AS ACHIEVEMENT_RATE
        ,U1.SET_MIN_VALUE   AS GRADE_S
        ,U1.SET_TXT_VALUE
        ,U2.SET_MIN_VALUE   AS GRADE_A
        ,U2.SET_TXT_VALUE
        ,U3.SET_MIN_VALUE   AS GRADE_B
        ,U3.SET_TXT_VALUE
        ,U4.SET_MIN_VALUE   AS GRADE_C
        ,U4.SET_TXT_VALUE
        ,U5.SET_MIN_VALUE   AS GRADE_D
        ,U5.SET_TXT_VALUE
        ,NVL(S.APP_STATUS, 'NFT') AS APP_STATUS
        ,C.SCORE_ORI
        ,C.SCORE_ORI_LIST
        ,NVL(C.SCORE_WEIGHT, 0)  AS SCORE_WEIGHT
        ,NVL(C.SCORE_GRADE, ' ') AS GRADE
        ,C.GRADE_REASON
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,C.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
        ,C.KPI_REF_ID
        ,T.ESTTERM_STEP_NAME
        ,J.KPI_CLASS_REF_ID
        ,G.KPI_GROUP_REF_ID
        ,NVL(Z.SCORE_GRADE, ' ') AS GRADE_ORG
        ,G.KPI_POOL_REF_ID
        ,G.BASIS_USE_YN
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    E   ON  E.EMP_REF_ID        = D.EMP_REF_ID
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_DEPT_INFO   H   ON  H.DEPT_REF_ID       = C.TGT_DEPT_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  I   ON  I.ETC_CODE  = G.KPI_GROUP_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014') K   ON  K.ETC_CODE  = J.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                L   ON  L.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                M   ON  M.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND M.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                N   ON  N.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND N.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
                                                        AND N.CATEGORY_LOW_REF_ID   = G.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO  O  ON O.UNIT_TYPE_REF_ID  = F.UNIT_TYPE_REF_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  P   ON  P.ESTTERM_REF_ID    = J.ESTTERM_REF_ID
                                            AND P.KPI_REF_ID        = J.KPI_REF_ID
                                            AND P.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          Q   ON  Q.ESTTERM_REF_ID    = P.ESTTERM_REF_ID
                                            AND Q.KPI_REF_ID        = P.KPI_REF_ID
                                            AND Q.KPI_TARGET_VERSION_ID = P.KPI_TARGET_VERSION_ID
                                            AND Q.YMD                   = C.YMD
LEFT OUTER JOIN BSC_KPI_RESULT          R   ON  R.ESTTERM_REF_ID    = Q.ESTTERM_REF_ID
                                            AND R.KPI_REF_ID        = Q.KPI_REF_ID
                                            AND R.YMD               = Q.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO       S   ON  S.APP_REF_ID        = R.APP_REF_ID
                                            AND S.ACTIVE_YN    = 'Y'
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U1  ON  U1.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U1.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U1.THRESHOLD_REF_ID = 1
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U2  ON  U2.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U2.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U2.THRESHOLD_REF_ID = 2
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U3  ON  U3.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U3.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U3.THRESHOLD_REF_ID = 3
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U4  ON  U4.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U4.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U4.THRESHOLD_REF_ID = 4
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U5  ON  U5.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U5.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U5.THRESHOLD_REF_ID = 5
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND NVL(A.STATUS_ID, ' ') = 'E'
ORDER BY G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";
            //평가데이터
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query,queryOra), "DATATABLE0", null, paramArray, CommandType.Text);

            //[1]평가상태
            query = @"
SELECT  TOP 1 A.REPORT, A.REPORT_FILE, A.STATUS, ISNULL(B.STATUS, 'X') AS EST_STATUS
FROM    BSC_MBO_KPI_REPORT  A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID   = A.COMP_ID
                                            AND B.EST_ID    = A.EST_ID
                                            AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                            AND B.STATUS            <> 'N'
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            queryOra = @"
SELECT  A.REPORT, A.REPORT_FILE, A.STATUS, NVL(B.STATUS, 'X') AS EST_STATUS
FROM    BSC_MBO_KPI_REPORT  A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID   = A.COMP_ID
                                            AND B.EST_ID    = A.EST_ID
                                            AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                            AND B.STATUS            <> 'N'
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND ROWNUM = 1
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query,queryOra), "DATATABLE1", ds, paramArray, CommandType.Text);

            //[2] 평가마감여부
            query = @"
SELECT	C.START_DATE, C.END_DATE, ISNULL(C.STATUS_YN, 'N') AS STATUS_YN
FROM		EST_JOB_EST_MAP	A
INNER JOIN	EST_JOB_INFO	B	ON	B.EST_JOB_ID	= A.EST_JOB_ID
							AND	B.MNG_PAGE_YN	= 'N'
							AND	B.USE_YN		= 'Y'
INNER JOIN	EST_JOB_DETAIL	C	ON	C.COMP_ID		= A.COMP_ID
								AND	C.EST_ID		= A.EST_ID
								AND	C.ESTTERM_REF_ID	= @ESTTERM_REF_ID
								AND	C.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
								AND	C.EST_JOB_ID		= A.EST_JOB_ID
WHERE	A.COMP_ID		= @COMP_ID
	AND	A.EST_ID		= @EST_ID
	AND	A.EST_JOB_ID	= 'JOB_91'
";
            queryOra = @"
SELECT	C.START_DATE, C.END_DATE, NVL(C.STATUS_YN, 'N') AS STATUS_YN
FROM		EST_JOB_EST_MAP	A
INNER JOIN	EST_JOB_INFO	B	ON	B.EST_JOB_ID	= A.EST_JOB_ID
							AND	B.MNG_PAGE_YN	= 'N'
							AND	B.USE_YN		= 'Y'
INNER JOIN	EST_JOB_DETAIL	C	ON	C.COMP_ID		= A.COMP_ID
								AND	C.EST_ID		= A.EST_ID
								AND	C.ESTTERM_REF_ID	= @ESTTERM_REF_ID
								AND	C.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
								AND	C.EST_JOB_ID		= A.EST_JOB_ID
WHERE	A.COMP_ID		= @COMP_ID
	AND	A.EST_ID		= @EST_ID
	AND	A.EST_JOB_ID	= 'JOB_91'
";
            paramArray = null;
            paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE2", ds, paramArray, CommandType.Text);

            //[3] 모든 MBO실적 결재되었는지 확인
            query = @"
SELECT TOP 1 A.ESTTERM_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
LEFT OUTER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
LEFT OUTER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT       E   ON  E.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND E.KPI_REF_ID        = C.KPI_REF_ID
                                    AND E.YMD               = C.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO    F   ON  F.APP_REF_ID        = E.APP_REF_ID
                                    AND F.ACTIVE_YN         = 'Y'
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, '') = 'E'
    AND ISNULL(F.APP_STATUS, '') != 'CFT'
";
            queryOra = @"
SELECT A.ESTTERM_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
LEFT OUTER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
LEFT OUTER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT       E   ON  E.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND E.KPI_REF_ID        = C.KPI_REF_ID
                                    AND E.YMD               = C.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO    F   ON  F.APP_REF_ID        = E.APP_REF_ID
                                    AND F.ACTIVE_YN         = 'Y'
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND NVL(A.STATUS_ID, ' ') = 'E'
    AND NVL(F.APP_STATUS, ' ') != 'CFT'
    AND ROWNUM = 1
";
            paramArray = null;
            paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE3", ds, paramArray, CommandType.Text);

            //[4] 평가상태 및 코멘트
            query = @"
SELECT  A.STATUS, A.COMMENT
FROM    BSC_MBO_KPI_SCORE_MT    A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID       = @EST_DEPT_ID
    AND A.EST_EMP_ID        = @EST_EMP_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            queryOra = @"
SELECT  A.STATUS, A.COMMENT
FROM    BSC_MBO_KPI_SCORE_MT    A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID       = @EST_DEPT_ID
    AND A.EST_EMP_ID        = @EST_EMP_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE4", ds, paramArray, CommandType.Text);

            //[5]피평가자의견(피드백)
            query = @"
SELECT  A.SEQ, A.COMMENT, A.CONFIRM_TYPE
FROM EST_QUESTION_COMMENT   A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.SEQ               = ( SELECT MAX(SEQ) FROM EST_QUESTION_COMMENT
                                WHERE   COMP_ID           = @COMP_ID
                                    AND EST_ID            = @EST_ID
                                    AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                                    AND TGT_DEPT_ID       = @TGT_DEPT_ID
                                    AND TGT_EMP_ID        = @TGT_EMP_ID)
";
            queryOra = @"
SELECT  A.SEQ, A.COMMENT, A.CONFIRM_TYPE
FROM EST_QUESTION_COMMENT   A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.SEQ               = ( SELECT MAX(SEQ) FROM EST_QUESTION_COMMENT
                                WHERE   COMP_ID           = @COMP_ID
                                    AND EST_ID            = @EST_ID
                                    AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                                    AND TGT_DEPT_ID       = @TGT_DEPT_ID
                                    AND TGT_EMP_ID        = @TGT_EMP_ID)
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE5", ds, paramArray, CommandType.Text);

            //[6]현재평가가 아닌놈 가져와서 뿌리기 (평가자로 볼때)
            query = @"
SELECT   A.ESTTERM_STEP_ID
        ,A.STATUS
        ,B.ESTTERM_STEP_NAME
        ,C.STATUS_NAME
FROM            BSC_MBO_KPI_SCORE_MT    A
LEFT OUTER JOIN EST_TERM_STEP           B   ON  B.COMP_ID           = A.COMP_ID
                                            AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN EST_STATUS              C   ON  C.STATUS_STYLE_ID   = '0003'
                                            AND C.STATUS_ID         = A.STATUS
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.ESTTERM_STEP_ID   > 1
ORDER BY A.ESTTERM_STEP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, query), "DATATABLE6", ds, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //[7]이전차수 평가정보보기
                query = @"
SELECT   C.ESTTERM_STEP_ID
        ,T.ESTTERM_STEP_NAME
        ,C.KPI_REF_ID
        ,ISNULL(C.SCORE_WEIGHT, 0) AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_ORI, 0) AS SCORE_ORI
        ,ISNULL(C.SCORE_GRADE, '') AS GRADE
        ,ISNULL(COM.CODE_NAME, '평가중') AS GRADE_NAME
        ,G.KPI_GROUP_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN COM_CODE_INFO   COM ON COM.CATEGORY_CODE = 'BS015' AND COM.USE_YN = 'Y' AND COM.ETC_CODE = C.SCORE_GRADE
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1 AND A.ESTTERM_STEP_ID < @PREESTTERM_STEP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY C.ESTTERM_STEP_ID DESC, G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";

                paramArray = null;
                paramArray = CreateDataParameters(7);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;
                paramArray[6] = CreateDataParameter("@PREESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[6].Value = DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["ESTTERM_STEP_ID"]);

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE7", ds, paramArray, CommandType.Text);

                //[8]현재차수까지의 평가의견
                query = @"
SELECT A.ESTTERM_STEP_ID, ISNULL(A.COMMENT, '') AS    COMMENT   
FROM BSC_MBO_KPI_SCORE_MT A
WHERE A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1 AND A.ESTTERM_STEP_ID <= @ESTTERM_STEP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
ORDER BY A.ESTTERM_STEP_ID
";

                paramArray = null;
                paramArray = CreateDataParameters(7);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;
                paramArray[6] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[6].Value = DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["ESTTERM_STEP_ID"]);

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE8", ds, paramArray, CommandType.Text);

                //[9]모든차수의 평가자사번
                query = @"
SELECT A.ESTTERM_STEP_ID, A.EST_EMP_ID
FROM BSC_MBO_KPI_SCORE_MT A
WHERE A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
ORDER BY A.ESTTERM_STEP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(6);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE9", ds, paramArray, CommandType.Text);

            }
            return ds;
        }

        public DataSet Get3GAKpiDataList(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int admin)
        {
            //[0] 평가데이터
            string query = @"
SELECT   F.KPI_CODE
        ,H.DEPT_NAME                AS COM_DEPT_NAME
        ,G.KPI_NAME
        ,E.EMP_NAME
        ,CASE G.KPI_GROUP_REF_ID WHEN 'QTT' THEN '계량' WHEN 'QLT' THEN '비계량' ELSE '' END AS KPI_GROUP_NAME--I.CODE_NAME                AS KPI_GROUP_NAME
        ,K.CODE_NAME                AS CLASS_NAME
        ,ISNULL(L.CATEGORY_NAME, ' ') + '/' + ISNULL(M.CATEGORY_NAME, ' ')  + '/' + ISNULL(N.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,ISNULL(O.UNIT, '-')        AS UNIT_NAME
        ,D.WEIGHT
        ,ISNULL(Q.TARGET_TS, 0) AS TARGET_TS
        ,ISNULL(R.RESULT_TS, 0) AS RESULT_TS
        ,CASE WHEN ISNULL(Q.TARGET_TS, 0) = 0 THEN 0 ELSE ISNULL(R.RESULT_TS / Q.TARGET_TS * 100, 0) END   AS ACHIEVEMENT_RATE
        ,U1.SET_MIN_VALUE   AS GRADE_S
        ,U1.SET_TXT_VALUE
        ,U2.SET_MIN_VALUE   AS GRADE_A
        ,U2.SET_TXT_VALUE
        ,U3.SET_MIN_VALUE   AS GRADE_B
        ,U3.SET_TXT_VALUE
        ,U4.SET_MIN_VALUE   AS GRADE_C
        ,U4.SET_TXT_VALUE
        ,U5.SET_MIN_VALUE   AS GRADE_D
        ,U5.SET_TXT_VALUE
        --,CASE WHEN ISNULL(S.APP_STATUS, ' ')  = 'CFT' THEN 'O' ELSE 'X' END AS APP_STATUS
        ,ISNULL(S.APP_STATUS, 'NFT') AS APP_STATUS
        ,C.SCORE_ORI
        ,C.SCORE_ORI_LIST
        ,ISNULL(C.SCORE_WEIGHT, 0)  AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_GRADE, '') AS GRADE
        ,C.GRADE_REASON
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,C.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
        ,C.KPI_REF_ID
        ,T.ESTTERM_STEP_NAME
        ,J.KPI_CLASS_REF_ID
        ,G.KPI_GROUP_REF_ID
        ,ISNULL(Z.SCORE_GRADE, ' ') AS GRADE_ORG
        ,G.KPI_POOL_REF_ID
        ,G.BASIS_USE_YN
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    E   ON  E.EMP_REF_ID        = D.EMP_REF_ID
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_DEPT_INFO   H   ON  H.DEPT_REF_ID       = C.TGT_DEPT_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  I   ON  I.ETC_CODE  = G.KPI_GROUP_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014') K   ON  K.ETC_CODE  = J.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                L   ON  L.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                M   ON  M.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND M.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                N   ON  N.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND N.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
                                                        AND N.CATEGORY_LOW_REF_ID   = G.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO  O  ON O.UNIT_TYPE_REF_ID  = F.UNIT_TYPE_REF_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  P   ON  P.ESTTERM_REF_ID    = J.ESTTERM_REF_ID
                                            AND P.KPI_REF_ID        = J.KPI_REF_ID
                                            AND P.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          Q   ON  Q.ESTTERM_REF_ID    = P.ESTTERM_REF_ID
                                            AND Q.KPI_REF_ID        = P.KPI_REF_ID
                                            AND Q.KPI_TARGET_VERSION_ID = P.KPI_TARGET_VERSION_ID
                                            AND Q.YMD                   = C.YMD
LEFT OUTER JOIN BSC_KPI_RESULT          R   ON  R.ESTTERM_REF_ID    = Q.ESTTERM_REF_ID
                                            AND R.KPI_REF_ID        = Q.KPI_REF_ID
                                            AND R.YMD               = Q.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO       S   ON  S.APP_REF_ID        = R.APP_REF_ID
                                            AND S.ACTIVE_YN    = 'Y'
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U1  ON  U1.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U1.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U1.THRESHOLD_REF_ID = 1
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U2  ON  U2.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U2.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U2.THRESHOLD_REF_ID = 2
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U3  ON  U3.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U3.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U3.THRESHOLD_REF_ID = 3
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U4  ON  U4.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U4.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U4.THRESHOLD_REF_ID = 4
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U5  ON  U5.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U5.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U5.THRESHOLD_REF_ID = 5
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    --AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";
            string queryOra = @"
SELECT   F.KPI_CODE
        ,H.DEPT_NAME                AS COM_DEPT_NAME
        ,G.KPI_NAME
        ,E.EMP_NAME
        ,CASE G.KPI_GROUP_REF_ID WHEN 'QTT' THEN '계량' WHEN 'QLT' THEN '비계량' ELSE '' END AS KPI_GROUP_NAME
        ,K.CODE_NAME                AS CLASS_NAME
        ,NVL(L.CATEGORY_NAME, ' ') || '/' || NVL(M.CATEGORY_NAME, ' ')  || '/' + NVL(N.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,NVL(O.UNIT, '-')        AS UNIT_NAME
        ,D.WEIGHT
        ,NVL(Q.TARGET_TS, 0) AS TARGET_TS
        ,NVL(R.RESULT_TS, 0) AS RESULT_TS
        ,CASE WHEN NVL(Q.TARGET_TS, 0) = 0 THEN 0 ELSE ROUND(NVL(R.RESULT_TS / Q.TARGET_TS * 100, 0),4) END   AS ACHIEVEMENT_RATE
        ,U1.SET_MIN_VALUE   AS GRADE_S
        ,U1.SET_TXT_VALUE
        ,U2.SET_MIN_VALUE   AS GRADE_A
        ,U2.SET_TXT_VALUE
        ,U3.SET_MIN_VALUE   AS GRADE_B
        ,U3.SET_TXT_VALUE
        ,U4.SET_MIN_VALUE   AS GRADE_C
        ,U4.SET_TXT_VALUE
        ,U5.SET_MIN_VALUE   AS GRADE_D
        ,U5.SET_TXT_VALUE
        ,NVL(S.APP_STATUS, 'NFT') AS APP_STATUS
        ,C.SCORE_ORI
        ,C.SCORE_ORI_LIST
        ,NVL(C.SCORE_WEIGHT, 0)  AS SCORE_WEIGHT
        ,NVL(C.SCORE_GRADE, ' ') AS GRADE
        ,C.GRADE_REASON
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,C.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
        ,C.KPI_REF_ID
        ,T.ESTTERM_STEP_NAME
        ,J.KPI_CLASS_REF_ID
        ,G.KPI_GROUP_REF_ID
        ,NVL(Z.SCORE_GRADE, ' ') AS GRADE_ORG
        ,G.KPI_POOL_REF_ID
        ,G.BASIS_USE_YN
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    E   ON  E.EMP_REF_ID        = D.EMP_REF_ID
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_DEPT_INFO   H   ON  H.DEPT_REF_ID       = C.TGT_DEPT_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  I   ON  I.ETC_CODE  = G.KPI_GROUP_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014') K   ON  K.ETC_CODE  = J.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                L   ON  L.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                M   ON  M.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND M.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                N   ON  N.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND N.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
                                                        AND N.CATEGORY_LOW_REF_ID   = G.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO  O  ON O.UNIT_TYPE_REF_ID  = F.UNIT_TYPE_REF_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  P   ON  P.ESTTERM_REF_ID    = J.ESTTERM_REF_ID
                                            AND P.KPI_REF_ID        = J.KPI_REF_ID
                                            AND P.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          Q   ON  Q.ESTTERM_REF_ID    = P.ESTTERM_REF_ID
                                            AND Q.KPI_REF_ID        = P.KPI_REF_ID
                                            AND Q.KPI_TARGET_VERSION_ID = P.KPI_TARGET_VERSION_ID
                                            AND Q.YMD                   = C.YMD
LEFT OUTER JOIN BSC_KPI_RESULT          R   ON  R.ESTTERM_REF_ID    = Q.ESTTERM_REF_ID
                                            AND R.KPI_REF_ID        = Q.KPI_REF_ID
                                            AND R.YMD               = Q.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO       S   ON  S.APP_REF_ID        = R.APP_REF_ID
                                            AND S.ACTIVE_YN    = 'Y'
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U1  ON  U1.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U1.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U1.THRESHOLD_REF_ID = 1
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U2  ON  U2.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U2.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U2.THRESHOLD_REF_ID = 2
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U3  ON  U3.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U3.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U3.THRESHOLD_REF_ID = 3
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U4  ON  U4.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U4.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U4.THRESHOLD_REF_ID = 4
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U5  ON  U5.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U5.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U5.THRESHOLD_REF_ID = 5
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    --AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND NVL(A.STATUS_ID, ' ') = 'E'
ORDER BY G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";
            //평가데이터
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE0", null, paramArray, CommandType.Text);

            //[1]평가상태
            query = @"
SELECT  TOP 1 A.REPORT, A.REPORT_FILE, A.STATUS, ISNULL(B.STATUS, 'X') AS EST_STATUS
FROM    BSC_MBO_KPI_REPORT  A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID   = A.COMP_ID
                                            AND B.EST_ID    = A.EST_ID
                                            AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                            AND B.STATUS            <> 'N'
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            queryOra = @"
SELECT  A.REPORT, A.REPORT_FILE, A.STATUS, NVL(B.STATUS, 'X') AS EST_STATUS
FROM    BSC_MBO_KPI_REPORT  A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID   = A.COMP_ID
                                            AND B.EST_ID    = A.EST_ID
                                            AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                            AND B.STATUS            <> 'N'
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND ROWNUM = 1
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE1", ds, paramArray, CommandType.Text);

            //[2] 평가마감여부
            query = @"
SELECT	C.START_DATE, C.END_DATE, ISNULL(C.STATUS_YN, 'N') AS STATUS_YN
FROM		EST_JOB_EST_MAP	A
INNER JOIN	EST_JOB_INFO	B	ON	B.EST_JOB_ID	= A.EST_JOB_ID
							AND	B.MNG_PAGE_YN	= 'N'
							AND	B.USE_YN		= 'Y'
INNER JOIN	EST_JOB_DETAIL	C	ON	C.COMP_ID		= A.COMP_ID
								AND	C.EST_ID		= A.EST_ID
								AND	C.ESTTERM_REF_ID	= @ESTTERM_REF_ID
								AND	C.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
								AND	C.EST_JOB_ID		= A.EST_JOB_ID
WHERE	A.COMP_ID		= @COMP_ID
	AND	A.EST_ID		= @EST_ID
	AND	A.EST_JOB_ID	= 'JOB_91'
";
            queryOra = @"
SELECT	C.START_DATE, C.END_DATE, NVL(C.STATUS_YN, 'N') AS STATUS_YN
FROM		EST_JOB_EST_MAP	A
INNER JOIN	EST_JOB_INFO	B	ON	B.EST_JOB_ID	= A.EST_JOB_ID
							AND	B.MNG_PAGE_YN	= 'N'
							AND	B.USE_YN		= 'Y'
INNER JOIN	EST_JOB_DETAIL	C	ON	C.COMP_ID		= A.COMP_ID
								AND	C.EST_ID		= A.EST_ID
								AND	C.ESTTERM_REF_ID	= @ESTTERM_REF_ID
								AND	C.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
								AND	C.EST_JOB_ID		= A.EST_JOB_ID
WHERE	A.COMP_ID		= @COMP_ID
	AND	A.EST_ID		= @EST_ID
	AND	A.EST_JOB_ID	= 'JOB_91'
";
            paramArray = null;
            paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE2", ds, paramArray, CommandType.Text);

            //[3] 모든 MBO실적 결재되었는지 확인
            query = @"
SELECT TOP 1 A.ESTTERM_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
LEFT OUTER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
LEFT OUTER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT       E   ON  E.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND E.KPI_REF_ID        = C.KPI_REF_ID
                                    AND E.YMD               = C.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO    F   ON  F.APP_REF_ID        = E.APP_REF_ID
                                    AND F.ACTIVE_YN         = 'Y'
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, '') = 'E'
    AND ISNULL(F.APP_STATUS, '') != 'CFT'
";
            queryOra = @"
SELECT A.ESTTERM_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
LEFT OUTER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
LEFT OUTER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT       E   ON  E.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND E.KPI_REF_ID        = C.KPI_REF_ID
                                    AND E.YMD               = C.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO    F   ON  F.APP_REF_ID        = E.APP_REF_ID
                                    AND F.ACTIVE_YN         = 'Y'
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND NVL(A.STATUS_ID, ' ') = 'E'
    AND NVL(F.APP_STATUS, ' ') != 'CFT'
    AND ROWNUM = 1
";
            paramArray = null;
            paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE3", ds, paramArray, CommandType.Text);

            //[4] 평가상태 및 코멘트
            query = @"
SELECT  A.STATUS, A.COMMENT
FROM    BSC_MBO_KPI_SCORE_MT    A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID       = @EST_DEPT_ID
    AND A.EST_EMP_ID        = @EST_EMP_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            queryOra = @"
SELECT  A.STATUS, A.COMMENT
FROM    BSC_MBO_KPI_SCORE_MT    A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID       = @EST_DEPT_ID
    AND A.EST_EMP_ID        = @EST_EMP_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE4", ds, paramArray, CommandType.Text);

            //[5]피평가자의견(피드백)
            query = @"
SELECT  A.SEQ, A.COMMENT, A.CONFIRM_TYPE
FROM EST_QUESTION_COMMENT   A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.SEQ               = ( SELECT MAX(SEQ) FROM EST_QUESTION_COMMENT
                                WHERE   COMP_ID           = @COMP_ID
                                    AND EST_ID            = @EST_ID
                                    AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                                    AND TGT_DEPT_ID       = @TGT_DEPT_ID
                                    AND TGT_EMP_ID        = @TGT_EMP_ID)
";
            queryOra = @"
SELECT  A.SEQ, A.COMMENT, A.CONFIRM_TYPE
FROM EST_QUESTION_COMMENT   A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.SEQ               = ( SELECT MAX(SEQ) FROM EST_QUESTION_COMMENT
                                WHERE   COMP_ID           = @COMP_ID
                                    AND EST_ID            = @EST_ID
                                    AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                                    AND TGT_DEPT_ID       = @TGT_DEPT_ID
                                    AND TGT_EMP_ID        = @TGT_EMP_ID)
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE5", ds, paramArray, CommandType.Text);

            //[6]현재평가가 아닌놈 가져와서 뿌리기 (평가자로 볼때)
            query = @"
SELECT   A.ESTTERM_STEP_ID
        ,A.STATUS
        ,B.ESTTERM_STEP_NAME
        ,C.STATUS_NAME
FROM            BSC_MBO_KPI_SCORE_MT    A
LEFT OUTER JOIN EST_TERM_STEP           B   ON  B.COMP_ID           = A.COMP_ID
                                            AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN EST_STATUS              C   ON  C.STATUS_STYLE_ID   = '0003'
                                            AND C.STATUS_ID         = A.STATUS
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.ESTTERM_STEP_ID   > 1
ORDER BY A.ESTTERM_STEP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, query), "DATATABLE6", ds, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //[7]이전차수 평가정보보기
                query = @"
SELECT   C.ESTTERM_STEP_ID
        ,T.ESTTERM_STEP_NAME
        ,C.KPI_REF_ID
        ,ISNULL(C.SCORE_WEIGHT, 0) AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_ORI, 0) AS SCORE_ORI
        ,ISNULL(C.SCORE_GRADE, '') AS GRADE
        ,ISNULL(COM.CODE_NAME, '평가중') AS GRADE_NAME
        ,G.KPI_GROUP_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN COM_CODE_INFO   COM ON COM.CATEGORY_CODE = 'BS015' AND COM.USE_YN = 'Y' AND COM.ETC_CODE = C.SCORE_GRADE
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1 AND A.ESTTERM_STEP_ID < @PREESTTERM_STEP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY C.ESTTERM_STEP_ID DESC, G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";

                paramArray = null;
                paramArray = CreateDataParameters(7);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;
                paramArray[6] = CreateDataParameter("@PREESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[6].Value = DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["ESTTERM_STEP_ID"]);

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE7", ds, paramArray, CommandType.Text);

                //[8]현재차수까지의 평가의견
                query = @"
SELECT A.ESTTERM_STEP_ID, ISNULL(A.COMMENT, '') AS    COMMENT   
FROM BSC_MBO_KPI_SCORE_MT A
WHERE A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1 AND A.ESTTERM_STEP_ID <= @ESTTERM_STEP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
ORDER BY A.ESTTERM_STEP_ID
";

                paramArray = null;
                paramArray = CreateDataParameters(7);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;
                paramArray[6] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[6].Value = DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["ESTTERM_STEP_ID"]);

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE8", ds, paramArray, CommandType.Text);

                //[9]모든차수의 평가자사번
                query = @"
SELECT A.ESTTERM_STEP_ID, A.EST_EMP_ID
FROM BSC_MBO_KPI_SCORE_MT A
WHERE A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
ORDER BY A.ESTTERM_STEP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(6);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE9", ds, paramArray, CommandType.Text);

            }
            return ds;
        }

        public int Insert(IDbConnection conn
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
                        , object tgt_pos_cls_id
                        , object tgt_pos_cls_name
                        , object tgt_pos_dut_id
                        , object tgt_pos_dut_name
                        , object tgt_pos_grp_id
                        , object tgt_pos_grp_name
                        , object tgt_pos_rnk_id
                        , object tgt_pos_rnk_name
                        , object tgt_pos_knd_id
                        , object tgt_pos_knd_name
                        , object direction_type
                        , object point_org
                        , object point_org_date
                        , object point_avg
                        , object point_avg_date
                        , object point_std
                        , object point_std_date
                        , object point_ctrl_org
                        , object point_ctrl_org_date
                        , object grade_ctrl_org_id
                        , object grade_ctrl_org_date
                        , object point
                        , object point_date
                        , object grade_id
                        , object grade_date
                        , object grade_to_point
                        , object grade_to_point_date
                        , object status_id
                        , object status_date
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO EST_DATA  (COMP_ID
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
                                                   ,CREATE_USER)
                                             VALUES
                                                   (@COMP_ID
                                                   ,@EST_ID
                                                   ,@ESTTERM_REF_ID
                                                   ,@ESTTERM_SUB_ID
                                                   ,@ESTTERM_STEP_ID
                                                   ,@EST_DEPT_ID
                                                   ,@EST_EMP_ID
                                                   ,@TGT_DEPT_ID
                                                   ,@TGT_EMP_ID
                                                   ,@TGT_POS_CLS_ID
                                                   ,@TGT_POS_CLS_NAME
                                                   ,@TGT_POS_DUT_ID
                                                   ,@TGT_POS_DUT_NAME
                                                   ,@TGT_POS_GRP_ID
                                                   ,@TGT_POS_GRP_NAME
                                                   ,@TGT_POS_RNK_ID
                                                   ,@TGT_POS_RNK_NAME
                                                   ,@TGT_POS_KND_ID
                                                   ,@TGT_POS_KND_NAME
                                                   ,@DIRECTION_TYPE
                                                   ,@POINT_ORG
                                                   ,@POINT_ORG_DATE
                                                   ,@POINT_AVG
                                                   ,@POINT_AVG_DATE
                                                   ,@POINT_STD
                                                   ,@POINT_STD_DATE
                                                   ,@POINT_CTRL_ORG
                                                   ,@POINT_CTRL_ORG_DATE
                                                   ,@GRADE_CTRL_ORG_ID
                                                   ,@GRADE_CTRL_ORG_DATE
                                                   ,@POINT
                                                   ,@POINT_DATE
                                                   ,@GRADE_ID
                                                   ,@GRADE_DATE
                                                   ,@GRADE_TO_POINT
                                                   ,@GRADE_TO_POINT_DATE
                                                   ,@STATUS_ID
                                                   ,@STATUS_DATE
                                                   ,@CREATE_DATE
                                                   ,@CREATE_USER)";

            IDbDataParameter[] paramArray = CreateDataParameters(40);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value     = tgt_dept_id;
            paramArray[8]           = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value     = tgt_emp_id;
            paramArray[9]           = CreateDataParameter("@TGT_POS_CLS_ID", SqlDbType.NVarChar);
            paramArray[9].Value     = tgt_pos_cls_id;
            paramArray[10]          = CreateDataParameter("@TGT_POS_CLS_NAME", SqlDbType.NVarChar);
            paramArray[10].Value    = tgt_pos_cls_name;
            paramArray[11]          = CreateDataParameter("@TGT_POS_DUT_ID", SqlDbType.NVarChar);
            paramArray[11].Value    = tgt_pos_dut_id;
            paramArray[12]          = CreateDataParameter("@TGT_POS_DUT_NAME", SqlDbType.NVarChar);
            paramArray[12].Value    = tgt_pos_dut_name;
            paramArray[13]          = CreateDataParameter("@TGT_POS_GRP_ID", SqlDbType.NVarChar);
            paramArray[13].Value    = tgt_pos_grp_id;
            paramArray[14]          = CreateDataParameter("@TGT_POS_GRP_NAME", SqlDbType.NVarChar);
            paramArray[14].Value    = tgt_pos_grp_name;
            paramArray[15]          = CreateDataParameter("@TGT_POS_RNK_ID", SqlDbType.NVarChar);
            paramArray[15].Value    = tgt_pos_rnk_id;
            paramArray[16]          = CreateDataParameter("@TGT_POS_RNK_NAME", SqlDbType.NVarChar);
            paramArray[16].Value    = tgt_pos_rnk_name;
            paramArray[17]          = CreateDataParameter("@TGT_POS_KND_ID", SqlDbType.NVarChar);
            paramArray[17].Value    = tgt_pos_knd_id;
            paramArray[18]          = CreateDataParameter("@TGT_POS_KND_NAME", SqlDbType.NVarChar);
            paramArray[18].Value    = tgt_pos_knd_name;
            paramArray[19]          = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.NVarChar);
            paramArray[19].Value    = direction_type;
            paramArray[20]          = CreateDataParameter("@POINT_ORG", SqlDbType.Decimal);
            paramArray[20].Value    = point_org;
            paramArray[21]          = CreateDataParameter("@POINT_ORG_DATE", SqlDbType.DateTime);
            paramArray[21].Value    = point_org_date;
            paramArray[22]          = CreateDataParameter("@POINT_AVG", SqlDbType.Decimal);
            paramArray[22].Value    = point_avg;
            paramArray[23]          = CreateDataParameter("@POINT_AVG_DATE", SqlDbType.DateTime);
            paramArray[23].Value    = point_avg_date;
            paramArray[24]          = CreateDataParameter("@POINT_STD", SqlDbType.Decimal);
            paramArray[24].Value    = point_std;
            paramArray[25]          = CreateDataParameter("@POINT_STD_DATE", SqlDbType.DateTime);
            paramArray[25].Value    = point_std_date;
            paramArray[26]          = CreateDataParameter("@POINT_CTRL_ORG", SqlDbType.Decimal);
            paramArray[26].Value    = point_ctrl_org;
            paramArray[27]          = CreateDataParameter("@POINT_CTRL_ORG_DATE", SqlDbType.DateTime);
            paramArray[27].Value    = point_ctrl_org_date;
            paramArray[28]          = CreateDataParameter("@GRADE_CTRL_ORG_ID", SqlDbType.NVarChar);
            paramArray[28].Value    = grade_ctrl_org_id;
            paramArray[29]          = CreateDataParameter("@GRADE_CTRL_ORG_DATE", SqlDbType.DateTime);
            paramArray[29].Value    = grade_ctrl_org_date;
            paramArray[30]          = CreateDataParameter("@POINT", SqlDbType.Decimal);
            paramArray[30].Value    = point;
            paramArray[31]          = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[31].Value    = point_date;
            paramArray[32]          = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[32].Value    = grade_id;
            paramArray[33]          = CreateDataParameter("@GRADE_DATE", SqlDbType.DateTime);
            paramArray[33].Value    = grade_date;
            paramArray[34]          = CreateDataParameter("@GRADE_TO_POINT", SqlDbType.NVarChar, 6);
            paramArray[34].Value    = grade_to_point;
            paramArray[35]          = CreateDataParameter("@GRADE_TO_POINT_DATE", SqlDbType.DateTime);
            paramArray[35].Value    = grade_to_point_date;
            paramArray[36]          = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 6);
            paramArray[36].Value    = status_id;
            paramArray[37]          = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            paramArray[37].Value    = status_date;
            paramArray[38]          = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[38].Value    = create_date;
            paramArray[39]          = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[39].Value    = create_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

                if (affectedRow > 0 && est_id.ToString() == "3GA")
                {
                    query = @"
SELECT CONVERT(VARCHAR, YEAR(A.EST_STARTDATE))+CASE WHEN DATALENGTH(CONVERT(VARCHAR, B.END_MONTH)) = 2 THEN CONVERT(VARCHAR, B.END_MONTH) ELSE  '0'+CONVERT(VARCHAR, B.END_MONTH) END
FROM EST_TERM_INFO A
LEFT OUTER JOIN EST_TERM_SUB    B ON    B.COMP_ID = @COMP_ID 
                                AND B.ESTTERM_SUB_ID=@ESTTERM_SUB_ID
WHERE A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
";
                    paramArray = null;
                    paramArray = CreateDataParameters(3);
                    paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[0].Value = comp_id;
                    paramArray[1].Value = estterm_sub_id;
                    paramArray[2].Value = estterm_ref_id;

                    string rtnMonth = DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString();

                    query = @"
INSERT INTO BSC_MBO_KPI_SCORE_DT
    (COMP_ID,       EST_ID,         ESTTERM_REF_ID,     ESTTERM_SUB_ID,     ESTTERM_STEP_ID
    ,YMD,           EST_DEPT_ID,    EST_EMP_ID,         TGT_DEPT_ID,        TGT_EMP_ID
    ,KPI_REF_ID,    SCORE_GRADE,    SCORE_ORI,          SCORE_WEIGHT,       GRADE_REASON
    ,STATUS,        CREATE_USER,    CREATE_DATE)
SELECT
    @COMP_ID,       @EST_ID,        @ESTTERM_REF_ID,    @ESTTERM_SUB_ID,    @ESTTERM_STEP_ID
    ,@YMD,          @EST_DEPT_ID,   @EST_EMP_ID,        @TGT_DEPT_ID,       @TGT_EMP_ID
    ,A.KPI_REF_ID,  NULL,           NULL,               NULL,               NULL
    ,'N',           @CREATE_USER,   GETDATE()
FROM    BSC_MBO_KPI_WEIGHT  A
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
AND A.EMP_REF_ID        = @TGT_EMP_ID
AND A.USE_YN            = 'Y'

INSERT INTO BSC_MBO_KPI_SCORE_MT
    (COMP_ID,       EST_ID,         ESTTERM_REF_ID,     ESTTERM_SUB_ID,     ESTTERM_STEP_ID
    ,YMD,           EST_DEPT_ID,    EST_EMP_ID,         TGT_DEPT_ID,        TGT_EMP_ID
    ,SCORE,         COMMENT,        STATUS,             CREATE_USER,        CREATE_DATE)
VALUES
    (@COMP_ID,      @EST_ID,        @ESTTERM_REF_ID,    @ESTTERM_SUB_ID,    @ESTTERM_STEP_ID
    ,@YMD,          @EST_DEPT_ID,   @EST_EMP_ID,        @TGT_DEPT_ID,       @TGT_EMP_ID
    ,NULL,          NULL,           'N',                @CREATE_USER,       GETDATE())

IF NOT EXISTS(
    SELECT * FROM
    BSC_MBO_KPI_REPORT 
    WHERE   COMP_ID     = @COMP_ID
        AND EST_ID      = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID 
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID 
        AND TGT_DEPT_ID     = @TGT_DEPT_ID    
        AND TGT_EMP_ID      = @TGT_EMP_ID)
    INSERT INTO BSC_MBO_KPI_REPORT
        (COMP_ID,       EST_ID,     ESTTERM_REF_ID,     ESTTERM_SUB_ID,     TGT_DEPT_ID
        ,TGT_EMP_ID,    REPORT,     REPORT_FILE,        STATUS,             CREATE_USER,    CREATE_DATE)
    VALUES
        (@COMP_ID,      @EST_ID,    @ESTTERM_REF_ID,    @ESTTERM_SUB_ID,    @TGT_DEPT_ID
        ,@TGT_EMP_ID,   NULL,       NULL,               'N',                @CREATE_USER,   GETDATE())
";
                    paramArray = null;
                    paramArray = CreateDataParameters(11);
                    paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                    paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                    paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);

                    paramArray[5] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                    paramArray[6] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                    paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                    paramArray[8] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                    paramArray[9] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

                    paramArray[10] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

                    paramArray[0].Value = comp_id;
                    paramArray[1].Value = est_id;
                    paramArray[2].Value = estterm_ref_id;
                    paramArray[3].Value = estterm_sub_id;
                    paramArray[4].Value = estterm_step_id;

                    paramArray[5].Value = rtnMonth;
                    paramArray[6].Value = est_dept_id;
                    paramArray[7].Value = est_emp_id;
                    paramArray[8].Value = tgt_dept_id;
                    paramArray[9].Value = tgt_emp_id;

                    paramArray[10].Value = create_user;

                    int insertedCount = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                }
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 부서 데이터에서 사원 데이터
        public int InsertDeptToEmp(IDbConnection conn
                                , IDbTransaction trx
                                , object comp_id
                                , object est_id
                                , object estterm_ref_id
                                , object estterm_sub_id
                                , object estterm_step_id
                                , object create_date
                                , object create_user)
        {
            string query = @"INSERT INTO EST_DATA  (COMP_ID
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
                                                   ,CREATE_USER)
                                        SELECT   ED.COMP_ID
                                                ,ED.EST_ID
                                                ,ED.ESTTERM_REF_ID
                                                ,ED.ESTTERM_SUB_ID
                                                ,ED.ESTTERM_STEP_ID
                                                ,ED.EST_DEPT_ID
                                                ,ED.EST_EMP_ID
                                                ,ED.TGT_DEPT_ID
                                                ,GRP.TGT_EMP_ID
                                                ,GRP.TGT_POS_CLS_ID
                                                ,GRP.TGT_POS_CLS_NAME
                                                ,GRP.TGT_POS_DUT_ID
                                                ,GRP.TGT_POS_DUT_NAME
                                                ,GRP.TGT_POS_GRP_ID
                                                ,GRP.TGT_POS_GRP_NAME
                                                ,GRP.TGT_POS_RNK_ID
                                                ,GRP.TGT_POS_RNK_NAME
                                                ,GRP.TGT_POS_KND_ID
                                                ,GRP.TGT_POS_KND_NAME
                                                ,ED.DIRECTION_TYPE
                                                ,ED.POINT_ORG
                                                ,ED.POINT_ORG_DATE
                                                ,ED.POINT_AVG
                                                ,ED.POINT_AVG_DATE
                                                ,ED.POINT_STD
                                                ,ED.POINT_STD_DATE
                                                ,ED.POINT_CTRL_ORG
                                                ,ED.POINT_CTRL_ORG_DATE
                                                ,ED.GRADE_CTRL_ORG_ID
                                                ,ED.GRADE_CTRL_ORG_DATE
                                                ,ED.POINT
                                                ,ED.POINT_DATE
                                                ,ED.GRADE_ID
                                                ,ED.GRADE_DATE
                                                ,ED.GRADE_TO_POINT
                                                ,ED.GRADE_TO_POINT_DATE
                                                ,ED.STATUS_ID
                                                ,ED.STATUS_DATE
                                                ,@CREATE_DATE
                                                ,@CREATE_USER
                                            FROM	  EST_DATA																			    ED
                                                JOIN (SELECT  ED.TGT_DEPT_ID
			                                                , ED.TGT_EMP_ID 
			                                                , PC.POS_CLS_ID		AS TGT_POS_CLS_ID
			                                                , PC.POS_CLS_NAME	AS TGT_POS_CLS_NAME
			                                                , PD.POS_DUT_ID		AS TGT_POS_DUT_ID
			                                                , PD.POS_DUT_NAME	AS TGT_POS_DUT_NAME
			                                                , PG.POS_GRP_ID		AS TGT_POS_GRP_ID
			                                                , PG.POS_GRP_NAME	AS TGT_POS_GRP_NAME
			                                                , PR.POS_RNK_ID		AS TGT_POS_RNK_ID
			                                                , PR.POS_RNK_NAME	AS TGT_POS_RNK_NAME
                                                            , PK.POS_KND_ID		AS TGT_POS_KND_ID
			                                                , PK.POS_KND_NAME	AS TGT_POS_KND_NAME
			                                                FROM	 EST_DATA			ED
				                                                JOIN COM_EMP_INFO		CE ON (ED.TGT_EMP_ID			= CE.EMP_REF_ID)
				                                                JOIN EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
				                                                JOIN EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
				                                                JOIN EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
				                                                JOIN EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                                                JOIN EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
				                                                WHERE   ED.COMP_ID			= @COMP_ID
					                                                AND ED.ESTTERM_REF_ID	= @ESTTERM_REF_ID
					                                                AND ED.TGT_EMP_ID		> 0
				                                                GROUP BY  ED.TGT_DEPT_ID
						                                                , ED.TGT_EMP_ID
						                                                , PC.POS_CLS_ID	
						                                                , PC.POS_CLS_NAME
						                                                , PD.POS_DUT_ID	
						                                                , PD.POS_DUT_NAME
						                                                , PG.POS_GRP_ID	
						                                                , PG.POS_GRP_NAME
						                                                , PR.POS_RNK_ID	
						                                                , PR.POS_RNK_NAME
                                                                        , PK.POS_KND_ID	
						                                                , PK.POS_KND_NAME)                                                  GRP ON (ED.TGT_DEPT_ID = GRP.TGT_DEPT_ID)
                                                WHERE   ED.COMP_ID			= @COMP_ID
                                                    AND ED.EST_ID			= @EST_ID
                                                    AND ED.ESTTERM_REF_ID	= @ESTTERM_REF_ID
                                                    AND ED.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
                                                    AND ED.ESTTERM_STEP_ID  = @ESTTERM_STEP_ID
                                                    AND ED.TGT_EMP_ID		< 0";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[5].Value     = create_date;
            paramArray[6]           = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[6].Value     = create_user;

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
                                    AND (ED.EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ED.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ED.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ED.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(ED.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(ED.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(ED.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(ED.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                    AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN             =''    )
                                    AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN            =''    )";
//            string queryTemp = @"DELETE	EST_DATA
//	                            FROM        EST_DATA         ED
//		                            JOIN    EST_TERM_SUB     ESU    ON	(ED.COMP_ID         = ESU.COMP_ID
//									                                 AND ED.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
//		                            JOIN    EST_TERM_STEP    EST    ON	(ED.COMP_ID         = EST.COMP_ID
//									                                 AND ED.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
//	                            WHERE	(ED.COMP_ID         = 1         OR 1         = 0)
//                                    AND (ED.EST_ID          = '3D'          OR '3D'              =''    )
//                                    AND	(ED.ESTTERM_REF_ID  = 1000  OR 1000  = 0)
//                                    AND	(ED.ESTTERM_SUB_ID  = 2  OR 2  = 0)
//                                    AND	(ED.ESTTERM_STEP_ID = 1 OR 1 = 0)
//                                    AND	(ED.EST_DEPT_ID     = 0     OR 0     = 0)
//                                    AND	(ED.EST_EMP_ID      = 0     OR 0     = 0)
//                                    AND	(ED.TGT_DEPT_ID     = 0     OR 0     = 0)
//                                    AND	(ED.TGT_EMP_ID      = 0     OR 0     = 0)
//                                    AND	(ESU.YEAR_YN        = 'N'         OR 'N'             =''    )
//                                    AND	(EST.MERGE_YN       = 'Y'       OR 'Y'            =''    )";

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

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

                if (affectedRow > 0 && est_id.ToString() == "3GA")
                {
                    query = @"
SELECT CONVERT(VARCHAR, YEAR(A.EST_STARTDATE))+CASE WHEN DATALENGTH(CONVERT(VARCHAR, B.END_MONTH)) = 2 THEN CONVERT(VARCHAR, B.END_MONTH) ELSE  '0'+CONVERT(VARCHAR, B.END_MONTH) END
FROM EST_TERM_INFO A
LEFT OUTER JOIN EST_TERM_SUB    B ON    B.COMP_ID = @COMP_ID 
                                AND B.ESTTERM_SUB_ID=@ESTTERM_SUB_ID
WHERE A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
";
                    paramArray = null;
                    paramArray = CreateDataParameters(3);
                    paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[0].Value = comp_id;
                    paramArray[1].Value = estterm_sub_id;
                    paramArray[2].Value = estterm_ref_id;

                    string rtnMonth = DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString();

                    query = @"
DELETE FROM BSC_MBO_KPI_SCORE_DT
WHERE   COMP_ID         = @COMP_ID
AND EST_ID          = @EST_ID
AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
AND YMD             = @YMD
AND EST_DEPT_ID     = @EST_DEPT_ID
AND EST_EMP_ID      = @EST_EMP_ID
AND TGT_DEPT_ID     = @TGT_DEPT_ID
AND TGT_EMP_ID      = @TGT_EMP_ID

DELETE FROM BSC_MBO_KPI_SCORE_MT
WHERE   COMP_ID         = @COMP_ID        
AND EST_ID          = @EST_ID         
AND ESTTERM_REF_ID  = @ESTTERM_REF_ID 
AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID 
AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
AND YMD             = @YMD            
AND EST_DEPT_ID     = @EST_DEPT_ID    
AND EST_EMP_ID      = @EST_EMP_ID     
AND TGT_DEPT_ID     = @TGT_DEPT_ID    
AND TGT_EMP_ID      = @TGT_EMP_ID

IF NOT EXISTS(
    SELECT * 
    FROM BSC_MBO_KPI_SCORE_MT 
    WHERE   COMP_ID     = @COMP_ID
        AND EST_ID      = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID 
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID 
        AND TGT_DEPT_ID     = @TGT_DEPT_ID    
        AND TGT_EMP_ID      = @TGT_EMP_ID
        AND YMD             = @YMD)
    DELETE FROM 
    BSC_MBO_KPI_REPORT 
    WHERE   COMP_ID     = @COMP_ID
        AND EST_ID      = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID 
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID 
        AND TGT_DEPT_ID     = @TGT_DEPT_ID    
        AND TGT_EMP_ID      = @TGT_EMP_ID
";
                    paramArray = null;
                    paramArray = CreateDataParameters(10);
                    paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                    paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                    paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);

                    paramArray[5] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                    paramArray[6] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
                    paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
                    paramArray[8] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                    paramArray[9] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);

                    paramArray[0].Value = comp_id;
                    paramArray[1].Value = est_id;
                    paramArray[2].Value = estterm_ref_id;
                    paramArray[3].Value = estterm_sub_id;
                    paramArray[4].Value = estterm_step_id;

                    paramArray[5].Value = rtnMonth;
                    paramArray[6].Value = est_dept_id;
                    paramArray[7].Value = est_emp_id;
                    paramArray[8].Value = tgt_dept_id;
                    paramArray[9].Value = tgt_emp_id;

                    int deletedCount = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                }
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Count( int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id)
        {
            return Count( null
                        , null
                        , comp_id
                        , est_id
                        , estterm_ref_id
                        , estterm_sub_id
                        , estterm_step_id
                        , est_dept_id
                        , est_emp_id
                        , tgt_dept_id
                        , tgt_emp_id
                        , "");
        }

        public int Count( int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , string status_id)
        {
            return Count( null
                        , null
                        , comp_id
                        , est_id
                        , estterm_ref_id
                        , estterm_sub_id
                        , estterm_step_id
                        , est_dept_id
                        , est_emp_id
                        , tgt_dept_id
                        , tgt_emp_id
                        , status_id);
        }

        public int Count( IDbConnection conn
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
                        , object status_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_DATA
                                WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                    AND (STATUS_ID       = @STATUS_ID       OR @STATUS_ID           =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
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
            paramArray[9]       = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[9].Value = status_id;

            try
            {
               int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteAllStdDevGrade(IDbConnection conn, IDbTransaction trx)
        {
            int affectedRows = 0;

            string queryString = @"DELETE FROM BSC_EST_STDDEV_GRADE";

            try
            {
                affectedRows = DbAgentObj.ExecuteNonQuery(conn, trx, queryString, null, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return affectedRows;
        }

        public DataSet SelectAllStdDevGrade(IDbConnection conn, IDbTransaction trx)
        {
            string queryString = @"select SCORE_CODE, SCORE_NAME, MIN_VALUE, MAX_VALUE from BSC_EST_STDDEV_GRADE";

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, queryString, "DATAGET", null, null, CommandType.Text);
            return ds;
        }

        public bool ConfirmMBOEstimate(IDbConnection conn, IDbTransaction trx, int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, string job_id, int emp_ref_id, bool completeyn)
        {
            int affectedRow = 0;

            string strQuery = @"
UPDATE  EST_JOB_DETAIL
    SET
         STATUS_YN      = 'Y'
        ,UPDATE_DATE     = GETDATE()
        ,UPDATE_USER    = @EMP_REF_ID
WHERE   COMP_ID     = @COMP_ID
    AND EST_ID      = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = 0
    AND EST_JOB_ID  = @JOB_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@JOB_ID", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = job_id;
            paramArray[5].Value = emp_ref_id;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);
            if (affectedRow < 1)
                return false;

//            if (completeyn)//강제확정처리면 BSC_MBO_KPI_SCORE_MT STATUS = 'E'
//            {
//                strQuery = @"
//UPDATE  BSC_MBO_KPI_SCORE_MT
//    SET  STATUS  = 'E'
//        ,UPDATE_DATE    = GETDATE()
//        ,UPDATE_USER    = @EMP_REF_ID
//WHERE   COMP_ID     = @COMP_ID
//AND EST_ID      = @EST_ID
//AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
//AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
//AND STATUS <> 'E'
//";
//                paramArray = null;
//                paramArray = CreateDataParameters(5);

//                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
//                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
//                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
//                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
//                paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

//                paramArray[0].Value = comp_id;
//                paramArray[1].Value = est_id;
//                paramArray[2].Value = estterm_ref_id;
//                paramArray[3].Value = estterm_sub_id;
//                paramArray[4].Value = emp_ref_id;

//                affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);

//                if (affectedRow < 1)
//                    return false;
//            }

            //EST_DATA에 값 이전
            strQuery = @"
UPDATE  EST_DATA
    SET  POINT_ORG      = ISNULL(B.SCORE, 0)
        ,POINT_ORG_DATE = GETDATE()
        ,POINT          = ISNULL(B.SCORE, 0)
        ,POINT_DATE     = GETDATE()
        ,STATUS_ID      = 'E'
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @EMP_REF_ID
FROM        EST_DATA    A
INNER JOIN  BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID           = A.COMP_ID
                                        AND B.EST_ID            = A.EST_ID
                                        AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                        AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                        AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                        AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                        AND B.EST_EMP_ID        = A.EST_EMP_ID
                                        AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
                                        AND B.TGT_EMP_ID        = A.TGT_EMP_ID
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = emp_ref_id;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);

            if (affectedRow < 1)
                return false;

            return true;
        }

        public bool ConfirmCancelMBOEstimate(IDbConnection conn, IDbTransaction trx, int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, string job_id, int emp_ref_id)
        {
            int affectedRow = 0;

            string strQuery = @"
UPDATE  EST_JOB_DETAIL
    SET
         STATUS_YN      = 'N'
        ,UPDATE_DATE     = GETDATE()
        ,UPDATE_USER    = @EMP_REF_ID
WHERE   COMP_ID     = @COMP_ID
    AND EST_ID      = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = 0
    AND EST_JOB_ID  = @JOB_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@JOB_ID", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = job_id;
            paramArray[5].Value = emp_ref_id;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);
            if (affectedRow < 1)
                return false;

            //EST_DATA플래그를 bsc_mbo_kpi_score_mt의 상태에 따라 변경 (N, O -> N   C, P, E -> P)
            strQuery = @"
UPDATE  EST_DATA
    SET  POINT_ORG      = NULL
        ,POINT_ORG_DATE = NULL
        ,POINT          = NULL
        ,POINT_DATE     = NULL
        ,STATUS_ID      = CASE WHEN B.STATUS IN ('C', 'P', 'E') THEN 'P' ELSE 'N' END
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @EMP_REF_ID
FROM        EST_DATA    A
INNER JOIN  BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID           = A.COMP_ID
                                        AND B.EST_ID            = A.EST_ID
                                        AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                        AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                        AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                        AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                        AND B.EST_EMP_ID        = A.EST_EMP_ID
                                        AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
                                        AND B.TGT_EMP_ID        = A.TGT_EMP_ID
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = emp_ref_id;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);

            if (affectedRow < 1)
                return false;

            return true;
        }

        public int ConfirmMBOMapable(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, int estterm_step_id, int tgt_emp_id)
        {
            string strQuery = @"
IF EXISTS(SELECT * FROM BSC_MBO_KPI_WEIGHT WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND EMP_REF_ID = @EMP_REF_ID AND USE_YN = 'Y')
    BEGIN
        IF EXISTS(SELECT * FROM EST_EMP_EST_TARGET_MAP WHERE COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID
            AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID AND TGT_EMP_ID = @EMP_REF_ID)
            BEGIN
                SELECT 2
            END
        ELSE
            BEGIN
                SELECT 0
            END
    END
ELSE
    BEGIN
        SELECT 1
    END
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = est_id;
            paramArray[2].Value = estterm_ref_id;
            paramArray[3].Value = estterm_sub_id;
            paramArray[4].Value = estterm_step_id;
            paramArray[5].Value = tgt_emp_id;

            return DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(strQuery, paramArray, CommandType.Text));
        }

        public int InsertOneStdDevGrade(IDbConnection conn, IDbTransaction trx, string scoreCode, string scoreName, double minValue, double maxValue, int empId)
        {
            int affectedRows = 0;
            string queryString = @"INSERT BSC_EST_STDDEV_GRADE
                                        (SCORE_CODE, SCORE_NAME, MIN_VALUE, MAX_VALUE, CREATE_USER, UPDATE_USER)
                                        VALUES
                                        (@SCORE_CODE, @SCORE_NAME, @MIN_VALUE, @MAX_VALUE, @CREATE_USER, @UPDATE_USER)";
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@SCORE_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = scoreCode;
            paramArray[1] = CreateDataParameter("@SCORE_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = scoreName;
            paramArray[2] = CreateDataParameter("@MIN_VALUE", SqlDbType.Float);
            paramArray[2].Value = minValue;
            paramArray[3] = CreateDataParameter("@MAX_VALUE", SqlDbType.Float);
            paramArray[3].Value = maxValue;
            paramArray[4] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[4].Value = empId;
            paramArray[5] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[5].Value = empId;

            try
            {
                affectedRows = DbAgentObj.ExecuteNonQuery(conn, trx, queryString, paramArray, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return affectedRows;
        }

        public void ConfirmNewColumn(string tableName, string columnName, string schemeQuery)
        {
            string strQuery = @"
IF NOT EXISTS(SELECT * FROM	SYSOBJECTS A INNER JOIN SYSCOLUMNS B ON	B.id = A.id AND	B.name = '{0}' WHERE A.xtype = 'U' AND A.name='{1}')
	{2}
";
            strQuery = string.Format(strQuery, columnName, tableName, schemeQuery);
            int affectedRows = DbAgentObj.ExecuteNonQuery(strQuery);
        }

        public bool GetAuth(int emp_id)
        {
            string query = "SELECT COUNT(*) FROM COM_EMP_ROLE_REL WHERE EMP_REF_ID = @EMP_REF_ID AND ROLE_REF_ID = 9";
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_id;
            int count = int.Parse(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
            if (count > 0) return true;
            else return false;
        }
    }
}
