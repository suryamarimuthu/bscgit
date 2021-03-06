﻿using System;
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
    public class Dac_PosClsEmps: DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , int seq
                        , float point
                        , DateTime point_date
                        , int ctrl_dept_id
                        , int ctrl_emp_id
                        , string ctrl_type
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_POS_CLS_EMP
                                SET	ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    ,ESTTERM_SUB_ID = @ESTTERM_SUB_ID
                                    ,END_DATE       = @END_DATE
                                    ,UPDATE_DATE    = @UPDATE_DATE
                                    ,UPDATE_USER    = @UPDATE_USER
                                WHERE	EMP_REF_ID  = @EMP_REF_ID
                                    AND	POS_CLS_ID  = @POS_CLS_ID
                                    AND	START_DATE  = @START_DATE";

            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8]       = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[8].Value = seq;
            paramArray[9]       = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[9].Value = point;
            paramArray[10]      = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[10].Value= point_date;
            paramArray[11]      = CreateDataParameter("@CTRL_DEPT_ID", SqlDbType.Int);
            paramArray[11].Value= ctrl_dept_id;
            paramArray[12]      = CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
            paramArray[12].Value= ctrl_emp_id;
            paramArray[13]      = CreateDataParameter("@CTRL_TYPE", SqlDbType.NVarChar, 12);
            paramArray[13].Value= ctrl_type;
            paramArray[14]      = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[14].Value= update_date;
            paramArray[15]      = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[15].Value= update_user;

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

        public DataSet Select(string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , int seq)
        {
            string query = @"SELECT	 EMP_REF_ID
	                                ,ESTTERM_REF_ID
	                                ,ESTTERM_SUB_ID
	                                ,POS_CLS_ID
	                                ,START_DATE
	                                ,END_DATE
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_POS_CLS_EMP 
                                    WHERE	EMP_REF_ID = @EMP_REF_ID
                                        AND	POS_CLS_ID = @POS_CLS_ID
                                        AND	START_DATE = @START_DATE";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8]       = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[8].Value = seq;

            DataSet ds = DbAgentObj.FillDataSet(query, "POINTCTRLDETAILGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , int seq
                        , float point
                        , DateTime point_date
                        , int ctrl_dept_id
                        , int ctrl_emp_id
                        , string ctrl_type
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_POS_CLS_EMP(EMP_REF_ID
			                                            ,ESTTERM_REF_ID
			                                            ,ESTTERM_SUB_ID
			                                            ,POS_CLS_ID
			                                            ,START_DATE
			                                            ,END_DATE
			                                            ,CREATE_DATE
			                                            ,CREATE_USER
			                                            ,UPDATE_DATE
			                                            ,UPDATE_USER
			                                            )
		                                            VALUES	(@EMP_REF_ID
			                                            ,@ESTTERM_REF_ID
			                                            ,@ESTTERM_SUB_ID
			                                            ,@POS_CLS_ID
			                                            ,@START_DATE
			                                            ,@END_DATE
			                                            ,@CREATE_DATE
			                                            ,@CREATE_USER
			                                            ,NULL
			                                            ,NULL
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8]       = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[8].Value = seq;
            paramArray[9]       = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[9].Value = point;
            paramArray[10]      = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[10].Value= point_date;
            paramArray[11]      = CreateDataParameter("@CTRL_DEPT_ID", SqlDbType.Int);
            paramArray[11].Value= ctrl_dept_id;
            paramArray[12]      = CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
            paramArray[12].Value= ctrl_emp_id;
            paramArray[13]      = CreateDataParameter("@CTRL_TYPE", SqlDbType.NVarChar, 12);
            paramArray[13].Value= ctrl_type;
            paramArray[14]      = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[14].Value= create_date;
            paramArray[15]      = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[15].Value= create_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx,query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , int seq)
        {
            string query = @"DELETE	EST_POS_CLS_EMP
                                WHERE	EMP_REF_ID = @EMP_REF_ID
                                    AND	POS_CLS_ID = @POS_CLS_ID
                                    AND	START_DATE = @START_DATE";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8]       = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[8].Value = seq;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx,query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Count( string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , int seq)
        {
            string query = @"SELECT COUNT(*) FROM EST_POS_CLS_EMP
                                    WHERE	(EMP_REF_ID = @EMP_REF_ID OR @EMP_REF_ID = 0)
                                        AND	(POS_CLS_ID = @POS_CLS_ID OR @POS_CLS_ID     =''    )
                                        AND	START_DATE = @START_DATE";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8]       = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[8].Value = seq;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}