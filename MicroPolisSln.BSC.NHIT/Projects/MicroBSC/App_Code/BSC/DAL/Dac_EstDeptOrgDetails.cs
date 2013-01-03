using System;
using System.Data;
using System.Data.SqlClient;
using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_EstDeptOrgDetails : DbAgentBase
    {
        public bool ModifyEstDeptOrgDetail(IDbConnection conn
                                                , IDbTransaction trx
                                                , int estterm_ref_id
                                                , string est_dept_top_yn_org
                                                )
        {
            return ModifyEstDeptOrgDetail(conn, trx, estterm_ref_id, 0, 0, est_dept_top_yn_org);
        }

        public bool ModifyEstDeptOrgDetail(IDbConnection conn
                                                , IDbTransaction trx
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , string est_dept_top_yn_org
                                                ) 
        {
            return ModifyEstDeptOrgDetail(conn, trx, estterm_ref_id, est_dept_ref_id, 0, est_dept_top_yn_org);
        }

        public bool ModifyEstDeptOrgDetail(IDbConnection conn
                                                , IDbTransaction trx
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , int type_ref_id
                                                , string est_dept_top_yn_org
                                                )
        {
            string query = @"UPDATE	BSC_EST_DEPT_ORG_DETAIL
                                SET	EST_DEPT_TOP_YN_ORG     = @EST_DEPT_TOP_YN_ORG
                                WHERE	(ESTTERM_REF_ID	    = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
		                            AND	(EST_DEPT_REF_ID    = @EST_DEPT_REF_ID  OR @EST_DEPT_REF_ID = 0)
		                            AND	(TYPE_REF_ID		= @TYPE_REF_ID      OR @TYPE_REF_ID     = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@TYPE_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = type_ref_id;
            paramArray[3]               = CreateDataParameter("@EST_DEPT_TOP_YN_ORG", SqlDbType.Char);
            paramArray[3].Value         = est_dept_top_yn_org;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEstDeptOrgDetail(int estterm_ref_id, int est_dept_ref_id)
        {
            string s_query = @"SELECT A.TYPE_REF_ID
                                    , A.TYPE_NAME
                                    , ISNULL(B.HOME_YN_ORG, 'N')	AS HOME_YN_ORG
                                    , ISNULL(B.HEADER_YN_ORG, 'N')	AS HEADER_YN_ORG
                                    , ISNULL(B.CONTENT_YN_ORG, 'N')	AS CONTENT_YN_ORG
                                    , ISNULL(B.POSITION_ORG, 7)	    AS POSITION_ORG
                                 FROM               COM_DEPT_TYPE_INFO		A
		                            LEFT OUTER JOIN BSC_EST_DEPT_ORG_DETAIL	B ON (A.TYPE_REF_ID         = B.TYPE_REF_ID
													                            AND B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
													                            AND B.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID)
                                    WHERE USE_YN = 'Y'
                                ORDER BY SORT_ORDER";

            string o_query = @"SELECT A.TYPE_REF_ID
                                    , A.TYPE_NAME
                                    , NVL(B.HOME_YN_ORG, 'N')	AS HOME_YN_ORG
                                    , NVL(B.HEADER_YN_ORG, 'N')	AS HEADER_YN_ORG
                                    , NVL(B.CONTENT_YN_ORG, 'N')	AS CONTENT_YN_ORG
                                    , NVL(B.POSITION_ORG, 7)	    AS POSITION_ORG
                                 FROM               COM_DEPT_TYPE_INFO		A
		                            LEFT OUTER JOIN BSC_EST_DEPT_ORG_DETAIL	B ON (A.TYPE_REF_ID         = B.TYPE_REF_ID
													                            AND B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
													                            AND B.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID)
                                    WHERE USE_YN = 'Y'
                                ORDER BY SORT_ORDER";

            IDbDataParameter[] paramArray   = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "ESTDEPTORGDETAILGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public bool AddEstDeptOrgDetail(   IDbConnection conn
                                                , IDbTransaction trx
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , int type_ref_id
                                                , string home_yn_org
                                                , string header_yn_org
                                                , string content_yn_org
                                                , string est_dept_top_yn_org
                                                , int position_org
                                                , int create_user)
        {
            string s_query = @" 
                                INSERT INTO	BSC_EST_DEPT_ORG_DETAIL
                                    (ESTTERM_REF_ID,EST_DEPT_REF_ID,TYPE_REF_ID,HOME_YN_ORG,HEADER_YN_ORG,CONTENT_YN_ORG,EST_DEPT_TOP_YN_ORG
                                    ,POSITION_ORG,CREATE_USER,CREATE_DATE,UPDATE_USER,UPDATE_DATE)
	                            VALUES	
                                    (@ESTTERM_REF_ID,@EST_DEPT_REF_ID,@TYPE_REF_ID,@HOME_YN_ORG,@HEADER_YN_ORG,@CONTENT_YN_ORG,@EST_DEPT_TOP_YN_ORG
                                    ,@POSITION_ORG,@CREATE_USER,GETDATE(),@CREATE_USER,GETDATE()

            )";

            string o_query = @"
                                INSERT INTO	BSC_EST_DEPT_ORG_DETAIL
                                    (ESTTERM_REF_ID,EST_DEPT_REF_ID,TYPE_REF_ID,HOME_YN_ORG,HEADER_YN_ORG,CONTENT_YN_ORG,EST_DEPT_TOP_YN_ORG
                                    ,POSITION_ORG,CREATE_USER,CREATE_DATE,UPDATE_USER,UPDATE_DATE)
	                            VALUES	
                                    (@ESTTERM_REF_ID,@EST_DEPT_REF_ID,@TYPE_REF_ID,@HOME_YN_ORG,@HEADER_YN_ORG,@CONTENT_YN_ORG,@EST_DEPT_TOP_YN_ORG
                                    ,@POSITION_ORG,@CREATE_USER,SYSDATE,@CREATE_USER,SYSDATE)
            ";

            IDbDataParameter[] paramArray   = CreateDataParameters(9);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@TYPE_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = type_ref_id;
            paramArray[3]               = CreateDataParameter("@HOME_YN_ORG", SqlDbType.Char);
            paramArray[3].Value         = home_yn_org;
            paramArray[4]               = CreateDataParameter("@HEADER_YN_ORG", SqlDbType.Char);
            paramArray[4].Value         = header_yn_org;
            paramArray[5]               = CreateDataParameter("@CONTENT_YN_ORG", SqlDbType.Char);
            paramArray[5].Value         = content_yn_org;
            paramArray[6]               = CreateDataParameter("@EST_DEPT_TOP_YN_ORG", SqlDbType.Char);
            paramArray[6].Value         = est_dept_top_yn_org;
            paramArray[7]               = CreateDataParameter("@POSITION_ORG", SqlDbType.Int);
            paramArray[7].Value         = position_org;
            paramArray[8]               = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[8].Value         = create_user;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveEstDeptOrgDetail(IDbConnection conn
                                            , IDbTransaction trx
                                            , int estterm_ref_id
                                            , int est_dept_ref_id
                                            , int type_ref_id)
        {
            string query = @"DELETE	BSC_EST_DEPT_ORG_DETAIL
	                            WHERE	(ESTTERM_REF_ID	    = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
		                            AND	(EST_DEPT_REF_ID    = @EST_DEPT_REF_ID  OR @EST_DEPT_REF_ID = 0)
		                            AND	(TYPE_REF_ID		= @TYPE_REF_ID      OR @TYPE_REF_ID     = 0)";

            IDbDataParameter[] paramArray   = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@TYPE_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = type_ref_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetEstDeptOrgCount(int estterm_ref_id) 
        {
            string query = @"SELECT COUNT(*) FROM (SELECT DISTINCT EST_DEPT_REF_ID FROM BSC_EST_DEPT_ORG_DETAIL 
	                            WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID) A";

            IDbDataParameter[] paramArray   = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;

            try
            {
                return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetEstDeptTopYN(int estterm_ref_id
                                            , int est_dept_ref_id) 
        {
            string query = @"SELECT EST_DEPT_TOP_YN_ORG FROM BSC_EST_DEPT_ORG_DETAIL 
	                            WHERE ESTTERM_REF_ID		= @ESTTERM_REF_ID
			                            AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID";


            IDbDataParameter[] paramArray   = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;

            DataSet ds = DbAgentObj.Fill(query, paramArray);

            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["EST_DEPT_TOP_YN_ORG"].ToString();

            return "N";
        }

        public int GetEstDeptRefIDByTopYN(int estterm_ref_id)
        {
            string query = @"SELECT DISTINCT EST_DEPT_REF_ID FROM BSC_EST_DEPT_ORG_DETAIL 
	                            WHERE ESTTERM_REF_ID			= @ESTTERM_REF_ID
			                            AND EST_DEPT_TOP_YN_ORG = 'Y'";

            IDbDataParameter[] paramArray   = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;

            DataSet ds = DbAgentCache.FillDataSet(query, "EST_ID", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["EST_DEPT_REF_ID"]);

            return 0;
        }


        public int GetEstDeptRefIDByTop1(int estterm_ref_id)
        {
            string query = @"SELECT A.EST_DEPT_REF_ID 
                                FROM (
                                        SELECT 
                                             ED.EST_DEPT_REF_ID
                                            ,ED.UP_EST_DEPT_ID
                                            ,LEVEL  as DEPT_LEVEL
                                        FROM 
                                            EST_DEPT_INFO ED
                                        WHERE
                                            ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                            AND TEMP_FLAG       = 1
                                            START WITH EST_DEPT_REF_ID = (SELECT EST_DEPT_REF_ID FROM EST_DEPT_INFO WHERE NVL(UP_EST_DEPT_ID,0) = 0 AND ROWNUM = 1)
                                            CONNECT BY PRIOR EST_DEPT_REF_ID = UP_EST_DEPT_ID
                                )A
		                            JOIN (SELECT DISTINCT EST_DEPT_REF_ID 
					                            FROM BSC_EST_DEPT_ORG_DETAIL 
				                            WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID)		B ON A.EST_DEPT_REF_ID = B.EST_DEPT_REF_ID
	                            ORDER BY DEPT_LEVEL";

            query = @"
                      SELECT DISTINCT EST_DEPT_REF_ID 
					    FROM BSC_EST_DEPT_ORG_DETAIL 
				       WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
                    ";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;

            DataSet ds          = DbAgentCache.Fill(query, paramArray);
            //DataSet ds            = DbAgent.Fill(query, paramArray);

            if (ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["EST_DEPT_REF_ID"]);

            return 0;
        }

        public int GetEstDeptRefIDByTop1(int estterm_ref_id, int emp_ref_id)
        {
            string query = @"
                            SELECT A.EST_DEPT_REF_ID
                              FROM EST_DEPT_INFO A
                                   INNER JOIN BSC_EMP_COM_DEPT_DETAIL B
                                      ON A.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                     AND A.DEPT_REF_ID = B.DEPT_REF_ID
                                     AND B.EMP_REF_ID  = @EMP_REF_ID
                             ORDER BY A.DEPT_TYPE";


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;

            DataSet ds          = DbAgentCache.Fill(query, paramArray);
            //DataSet ds            = DbAgent.Fill(query, paramArray);

            if (ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["EST_DEPT_REF_ID"]);

            return 0;
        }

        public int GetCount(int estterm_ref_id, int est_dept_ref_id) 
        {
            string query = @"   SELECT COUNT(*) FROM BSC_EST_DEPT_ORG_DETAIL
	                                WHERE ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                                AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;

            try
            {
                return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
