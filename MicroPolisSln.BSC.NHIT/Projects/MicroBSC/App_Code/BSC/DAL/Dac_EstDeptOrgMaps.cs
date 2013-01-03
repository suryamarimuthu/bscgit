using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_EstDeptOrgMaps : DbAgentBase
    {

        public DataTable GetDeptOrgMaps(int est_dept_ref_id) 
        {
            string query = @"SELECT EST_DEPT_REF_ID
		                            , ESTTERM_REF_ID
		                            , DEPT_NAME
                                    , DEPT_TYPE
		                            , VIEW_YN_ORG
		                            , HEADER_IMG_ORG
		                            , SORT_ORG
		                            , DEPT_NAME_ORG
	                            FROM EST_DEPT_INFO
                                    WHERE (EST_DEPT_REF_ID = @EST_DEPT_REF_ID OR @EST_DEPT_REF_ID = 0)
                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = est_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "SIGNAL", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }

        public DataTable GetSignal(int estterm_ref_id, int month, bool GetExtKpiScore)
        {
            if (!GetExtKpiScore)
            {
                return this.GetSignal(estterm_ref_id, month);
            }
            else
            {
                return this.GetSignalExtKpiScore(estterm_ref_id, month);
            }
        }

        public DataTable GetSignal(int estterm_ref_id, int month) 
        {
            string query = @"  
                             SELECT KW.ESTTERM_REF_ID,
                                    KW.YMD,
                                    KW.EST_DEPT_REF_ID,
                                    ED.DEPT_NAME,
                                    KW.VIEW_REF_ID AS VIEW_TYPE,
                                    ISNULL(KW.WEIGHT3,0)  * (CASE TS.POINTS_MS WHEN '-' THEN 0 ELSE CONVERT(NUMERIC(20,4),TS.POINTS_MS)*0.01 END) as SCORE_MS,
                                    ISNULL(KW.SWEIGHT3,0) * (CASE TS.POINTS_TS WHEN '-' THEN 0 ELSE CONVERT(NUMERIC(20,4),TS.POINTS_TS)*0.01 END) as SCORE_TS
                               FROM BSC_KPI_WEIGHT          KW 
                                    LEFT JOIN BSC_KPI_SCORE TS ON KW.ESTTERM_REF_ID         = TS.ESTTERM_REF_ID
                                                                     AND KW.KPI_REF_ID      = TS.KPI_REF_ID
                                                                     AND KW.YMD             = TS.YMD
                                                                     AND KW.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    LEFT JOIN EST_DEPT_INFO ED ON KW.ESTTERM_REF_ID         = ED.ESTTERM_REF_ID
                                                                    AND KW.EST_DEPT_REF_ID  = ED.EST_DEPT_REF_ID
                                    LEFT JOIN BSC_MAP_TERM	MT ON KW.ESTTERM_REF_ID         = MT.ESTTERM_REF_ID
									                                 AND KW.EST_DEPT_REF_ID = MT.EST_DEPT_REF_ID
									                                 AND KW.YMD				= MT.YMD
									                                 AND KW.MAP_VERSION_ID	= MT.MAP_VERSION_ID
                              WHERE KW.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                AND KW.YMD             = @MONTH
                                    ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@MONTH", SqlDbType.Int);
            paramArray[1].Value         = month;

            DataSet ds                  = DbAgentObj.FillDataSet(GetQueryStringReplace(query), "SIGNAL", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }

        public DataTable GetSignalExtKpiScore(int estterm_ref_id, int month)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();

            string query = @"  
                             SELECT TA.ESTTERM_REF_ID
                                   ,TA.YMD
                                   ,TA.EST_DEPT_REF_ID
                                   ,TA.DEPT_NAME
                                   ,TA.VIEW_TYPE
                                   ,CASE WHEN TA.POINTS_EXT IS NULL THEN (TA.SCORE_MS*TA.WEIGHT3)
                                         ELSE ((TA.SCORE_MS*TA.WEIGHT_INR) + (TA.POINTS_EXT*TA.WEIGHT_EXT))*TA.WEIGHT3
                                    END as SCORE_MS
                                   ,CASE WHEN TA.POINTS_EXT IS NULL THEN (TA.SCORE_TS*TA.SWEIGHT3)
                                         ELSE ((TA.SCORE_TS*TA.WEIGHT_INR) + (TA.POINTS_EXT*TA.WEIGHT_EXT))*TA.SWEIGHT3
                                    END as SCORE_TS
                               FROM (                         
                                     SELECT KW.ESTTERM_REF_ID 
                                           ,KW.YMD 
                                           ,KW.EST_DEPT_REF_ID 
                                           ,ED.DEPT_NAME 
                                           ,KW.VIEW_REF_ID AS VIEW_TYPE 
                                           ,ISNULL(KW.WEIGHT3,0)*0.01  as WEIGHT3
                                           ,(CASE TS.POINTS_MS WHEN '-' THEN 0 ELSE CONVERT(NUMERIC(20,4),TS.POINTS_MS) END) as SCORE_MS 
                                           ,ISNULL(KW.SWEIGHT3,0)*0.01 as SWEIGHT3
                                           ,(CASE TS.POINTS_TS WHEN '-' THEN 0 ELSE CONVERT(NUMERIC(20,4),TS.POINTS_TS) END) as SCORE_TS
                                           ,ES.WEIGHT_INR*0.01  as WEIGHT_INR 
                                           ,ES.WEIGHT_EXT*0.01  as WEIGHT_EXT
                                           ,ES.POINTS_EXT       as POINTS_EXT
                                       FROM BSC_KPI_WEIGHT          KW 
                                            LEFT JOIN BSC_KPI_SCORE TS 
                                              ON KW.ESTTERM_REF_ID  = TS.ESTTERM_REF_ID
                                             AND KW.KPI_REF_ID      = TS.KPI_REF_ID
                                             AND KW.YMD             = TS.YMD
                                             AND KW.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                            LEFT JOIN BSC_KPI_EXTERNAL_SCORE ES
                                              ON KW.ESTTERM_REF_ID = ES.ESTTERM_REF_ID
                                             AND KW.KPI_REF_ID     = ES.KPI_REF_ID
                                             AND KW.YMD            = ES.YMD
                                            LEFT JOIN EST_DEPT_INFO ED 
                                              ON KW.ESTTERM_REF_ID         = ED.ESTTERM_REF_ID
                                             AND KW.EST_DEPT_REF_ID  = ED.EST_DEPT_REF_ID
                                            LEFT JOIN BSC_MAP_TERM  MT 
                                              ON KW.ESTTERM_REF_ID         = MT.ESTTERM_REF_ID
                                         AND KW.EST_DEPT_REF_ID = MT.EST_DEPT_REF_ID
                                         AND KW.YMD             = MT.YMD
                                         AND KW.MAP_VERSION_ID  = MT.MAP_VERSION_ID
                                      WHERE KW.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                        AND KW.YMD             = @MONTH
                                    ) TA
                                    ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@MONTH", SqlDbType.Int);
            paramArray[1].Value = month;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringReplace(query), "SIGNAL", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }

        // 전사 가지고 오기
        public DataTable GetHomeData(int estterm_ref_id, int est_dept_ref_id, int emp_ref_id) 
        {
            string s_query = @"SELECT A.EST_DEPT_REF_ID
                                    , B.ESTTERM_REF_ID
                                    , B.DEPT_NAME
                                    , B.HEADER_IMG_ORG
                                    , C.POSITION_ORG
                                    , B.SORT_ORG
                                    , B.DEPT_NAME_ORG 
                                    , A.DEPT_LEVEL
                                    , D.TREE_NODE_TYPE
	                            FROM dbo.fn_GetEstDeptByLevel (@EST_DEPT_REF_ID) A
		                            JOIN EST_DEPT_INFO				B ON (B.ESTTERM_REF_ID		= @ESTTERM_REF_ID 
											                            AND A.EST_DEPT_REF_ID	= B.EST_DEPT_REF_ID)
		                            JOIN BSC_EST_DEPT_ORG_DETAIL	C ON (B.ESTTERM_REF_ID		= @ESTTERM_REF_ID 
											                            AND C.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID 
											                            AND B.DEPT_TYPE			= C.TYPE_REF_ID 
											                            AND C.HOME_YN_ORG		= 'Y')
                                    JOIN dbo.fn_BSC_EMP_COM_DEPT_BY_EMP_ID(@EMP_REF_ID) D ON (B.DEPT_REF_ID = D.DEPT_REF_ID)
	                            WHERE B.VIEW_YN_ORG = 'Y'
		                            ORDER BY B.SORT_ORG";

            string o_query = @"
                              SELECT A.EST_DEPT_REF_ID
                                   , A.ESTTERM_REF_ID
                                   , A.DEPT_NAME
                                   , A.HEADER_IMG_ORG
                                   , C.POSITION_ORG
                                   , A.SORT_ORG
                                   , A.DEPT_NAME_ORG 
                                   , A.DEPT_LEVEL
                                   , D.TREE_NODE_TYPE
                                FROM (SELECT ESTTERM_REF_ID, EST_DEPT_REF_ID, DEPT_NAME, HEADER_IMG_ORG, SORT_ORG, DEPT_NAME_ORG, DEPT_REF_ID, VIEW_YN_ORG, DEPT_TYPE, LEVEL as DEPT_LEVEL
                                        FROM EST_DEPT_INFO
                                       START WITH (ESTTERM_REF_ID = @ESTTERM_REF_ID AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID AND TEMP_FLAG = 1)
                                       CONNECT BY PRIOR EST_DEPT_REF_ID = UP_EST_DEPT_ID) A
                                     INNER JOIN BSC_EST_DEPT_ORG_DETAIL C
                                        ON A.ESTTERM_REF_ID  = C.ESTTERM_REF_ID
                                       AND A.DEPT_TYPE       = C.TYPE_REF_ID
                                       AND A.EST_DEPT_REF_ID = C.EST_DEPT_REF_ID
                                       AND A.EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                       AND C.HOME_YN_ORG		= 'Y'
                                     INNER JOIN (SELECT TT.DEPT_REF_ID, CASE WHEN TZ.DEPT_REF_ID IS NULL THEN 0 ELSE 1 END TREE_NODE_TYPE
                                                   FROM (SELECT DEPT_REF_ID
                                                           FROM COM_DEPT_INFO
                                                          START WITH NVL(DEPT_REF_ID,0) IN (SELECT DEPT_REF_ID 
                                                                                              FROM BSC_EMP_COM_DEPT_DETAIL 
                                                                                             WHERE EMP_REF_ID  = @EMP_REF_ID)
                                                        CONNECT BY PRIOR UP_DEPT_ID = DEPT_REF_ID
                                                          GROUP BY DEPT_REF_ID) TT
                                                        LEFT JOIN BSC_EMP_COM_DEPT_DETAIL TZ
                                                          ON TT.DEPT_REF_ID = TZ.DEPT_REF_ID
                                                         AND TZ.EMP_REF_ID  = @EMP_REF_ID
                                                ) D
                                       ON A.DEPT_REF_ID = D.DEPT_REF_ID
	                            WHERE A.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                  AND A.VIEW_YN_ORG = 'Y'
		                        ORDER BY A.SORT_ORG
                             ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "SIGNAL", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }

        // 헤더 가지고 오기
        public DataTable GetHeaderData(int estterm_ref_id, int est_dept_ref_id, int emp_ref_id)
        {
            string s_query = @"SELECT A.EST_DEPT_REF_ID
                                    , B.ESTTERM_REF_ID
                                    , B.DEPT_NAME
                                    , B.HEADER_IMG_ORG
                                    , C.POSITION_ORG
                                    , B.SORT_ORG
                                    , B.DEPT_NAME_ORG 
                                    , A.DEPT_LEVEL
                                    , D.TREE_NODE_TYPE
	                            FROM dbo.fn_GetEstDeptByLevel (@EST_DEPT_REF_ID) A
		                            JOIN EST_DEPT_INFO				B ON (B.ESTTERM_REF_ID		= @ESTTERM_REF_ID 
											                            AND A.EST_DEPT_REF_ID	= B.EST_DEPT_REF_ID)
		                            JOIN BSC_EST_DEPT_ORG_DETAIL	C ON (B.ESTTERM_REF_ID		= @ESTTERM_REF_ID 
											                            AND C.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID 
											                            AND B.DEPT_TYPE			= C.TYPE_REF_ID 
											                            AND C.HEADER_YN_ORG		= 'Y')
                                    JOIN dbo.fn_BSC_EMP_COM_DEPT_BY_EMP_ID(@EMP_REF_ID) D ON (B.DEPT_REF_ID = D.DEPT_REF_ID)
	                            WHERE B.VIEW_YN_ORG = 'Y'
		                            ORDER BY B.SORT_ORG";
            string o_query = @"
                              SELECT A.EST_DEPT_REF_ID
                                   , A.ESTTERM_REF_ID
                                   , A.DEPT_NAME
                                   , A.HEADER_IMG_ORG
                                   , C.POSITION_ORG
                                   , A.SORT_ORG
                                   , A.DEPT_NAME_ORG 
                                   , A.DEPT_LEVEL
                                   , D.TREE_NODE_TYPE
                                FROM (SELECT ESTTERM_REF_ID, EST_DEPT_REF_ID, DEPT_NAME, HEADER_IMG_ORG, SORT_ORG, DEPT_NAME_ORG, DEPT_REF_ID, VIEW_YN_ORG, DEPT_TYPE, LEVEL as DEPT_LEVEL
                                        FROM EST_DEPT_INFO
                                       START WITH (ESTTERM_REF_ID = @ESTTERM_REF_ID AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID AND TEMP_FLAG = 1)
                                       CONNECT BY PRIOR EST_DEPT_REF_ID = UP_EST_DEPT_ID) A
                                     INNER JOIN BSC_EST_DEPT_ORG_DETAIL C
                                        ON A.ESTTERM_REF_ID  = C.ESTTERM_REF_ID
                                       AND A.DEPT_TYPE       = C.TYPE_REF_ID
                                       AND C.EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                       AND C.HEADER_YN_ORG   = 'Y'
                                     INNER JOIN (SELECT TT.DEPT_REF_ID, CASE WHEN TZ.DEPT_REF_ID IS NULL THEN 0 ELSE 1 END TREE_NODE_TYPE
                                                   FROM (SELECT DEPT_REF_ID
                                                           FROM COM_DEPT_INFO
                                                          START WITH NVL(DEPT_REF_ID,0) IN (SELECT DEPT_REF_ID 
                                                                                              FROM BSC_EMP_COM_DEPT_DETAIL 
                                                                                             WHERE EMP_REF_ID  = @EMP_REF_ID)
                                                        CONNECT BY PRIOR UP_DEPT_ID = DEPT_REF_ID
                                                          GROUP BY DEPT_REF_ID) TT
                                                        LEFT JOIN BSC_EMP_COM_DEPT_DETAIL TZ
                                                          ON TT.DEPT_REF_ID = TZ.DEPT_REF_ID
                                                         AND TZ.EMP_REF_ID  = @EMP_REF_ID
                                                ) D
                                       ON A.DEPT_REF_ID = D.DEPT_REF_ID
	                            WHERE A.VIEW_YN_ORG = 'Y'
		                        ORDER BY A.SORT_ORG
                             ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "SIGNAL", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }

        // 컨텐트 가지고 오기
        public DataTable GetContentData(int estterm_ref_id
                                                , int est_dept_ref_id_org
                                                , int est_dept_ref_id
                                                , int emp_ref_id)
        {
            string s_query = @"SELECT A.EST_DEPT_REF_ID
                                    , B.ESTTERM_REF_ID
                                    , B.DEPT_NAME
                                    , B.HEADER_IMG_ORG
                                    , C.POSITION_ORG
                                    , B.SORT_ORG
                                    , B.DEPT_NAME_ORG 
                                    , A.DEPT_LEVEL
                                    , D.TREE_NODE_TYPE
	                            FROM dbo.fn_GetEstDeptByLevel (@EST_DEPT_REF_ID) A
		                            JOIN EST_DEPT_INFO				B ON (B.ESTTERM_REF_ID		= @ESTTERM_REF_ID 
											                            AND A.EST_DEPT_REF_ID	= B.EST_DEPT_REF_ID)
		                            JOIN BSC_EST_DEPT_ORG_DETAIL	C ON (B.ESTTERM_REF_ID		= @ESTTERM_REF_ID 
											                            AND C.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID_ORG 
											                            AND B.DEPT_TYPE			= C.TYPE_REF_ID 
											                            AND C.CONTENT_YN_ORG	= 'Y')
                                    JOIN dbo.fn_BSC_EMP_COM_DEPT_BY_EMP_ID(@EMP_REF_ID) D ON (B.DEPT_REF_ID = D.DEPT_REF_ID)
	                            WHERE B.VIEW_YN_ORG = 'Y'
		                            ORDER BY B.SORT_ORG";

            string o_query = @"
                              SELECT A.EST_DEPT_REF_ID
                                   , A.ESTTERM_REF_ID
                                   , A.DEPT_NAME
                                   , A.HEADER_IMG_ORG
                                   , C.POSITION_ORG
                                   , A.SORT_ORG
                                   , A.DEPT_NAME_ORG 
                                   , A.DEPT_LEVEL
                                   , D.TREE_NODE_TYPE
                                FROM (SELECT ESTTERM_REF_ID, EST_DEPT_REF_ID, DEPT_NAME, HEADER_IMG_ORG, SORT_ORG, DEPT_NAME_ORG, DEPT_REF_ID, VIEW_YN_ORG, DEPT_TYPE, LEVEL as DEPT_LEVEL
                                        FROM EST_DEPT_INFO
                                       START WITH (ESTTERM_REF_ID = @ESTTERM_REF_ID AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID AND TEMP_FLAG = 1)
                                       CONNECT BY PRIOR EST_DEPT_REF_ID = UP_EST_DEPT_ID) A
                                     INNER JOIN BSC_EST_DEPT_ORG_DETAIL C
                                        ON A.ESTTERM_REF_ID  = C.ESTTERM_REF_ID
                                       AND A.DEPT_TYPE       = C.TYPE_REF_ID
                                       AND C.EST_DEPT_REF_ID = @EST_DEPT_REF_ID_ORG
                                       AND C.CONTENT_YN_ORG  = 'Y'
                                     INNER JOIN (SELECT TT.DEPT_REF_ID, CASE WHEN TZ.DEPT_REF_ID IS NULL THEN 0 ELSE 1 END TREE_NODE_TYPE
                                                   FROM (SELECT DEPT_REF_ID
                                                           FROM COM_DEPT_INFO
                                                          START WITH NVL(DEPT_REF_ID,0) IN (SELECT DEPT_REF_ID 
                                                                                              FROM BSC_EMP_COM_DEPT_DETAIL 
                                                                                             WHERE EMP_REF_ID  = @EMP_REF_ID)
                                                        CONNECT BY PRIOR UP_DEPT_ID = DEPT_REF_ID
                                                          GROUP BY DEPT_REF_ID) TT
                                                        LEFT JOIN BSC_EMP_COM_DEPT_DETAIL TZ
                                                          ON TT.DEPT_REF_ID = TZ.DEPT_REF_ID
                                                         AND TZ.EMP_REF_ID  = @EMP_REF_ID
                                                ) D
                                       ON A.DEPT_REF_ID = D.DEPT_REF_ID
	                            WHERE A.VIEW_YN_ORG = 'Y'
		                        ORDER BY A.SORT_ORG
                             ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID_ORG", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id_org;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "SIGNAL", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }

        public bool ModifyViewYNOrg(IDbConnection conn
                                    , IDbTransaction trx
                                    , int estterm_ref_id
                                    , int est_dept_ref_id
                                    , string view_yn_org) 
        {
            string query = @"UPDATE EST_DEPT_INFO 
	                            SET VIEW_YN_ORG		 = @VIEW_YN_ORG
		                      WHERE ESTTERM_REF_ID   = @ESTTERM_REF_ID
                                AND (EST_DEPT_REF_ID = @EST_DEPT_REF_ID OR @EST_DEPT_REF_ID = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@VIEW_YN_ORG", SqlDbType.Char);
            paramArray[2].Value         = view_yn_org;

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

        public bool ModifyEstDeptOrg(IDbConnection conn
                                    , IDbTransaction trx
                                    , int est_dept_ref_id
                                    , int header_img_org
                                    , int sort_org
                                    , int dept_type
                                    , string dept_name_org) 
        {
            string query = @"UPDATE EST_DEPT_INFO 
	                            SET   HEADER_IMG_ORG            = @HEADER_IMG_ORG
		                            , SORT_ORG                  = @SORT_ORG
                                    , DEPT_TYPE                 = @DEPT_TYPE
		                            , DEPT_NAME_ORG             = CASE WHEN @DEPT_NAME_ORG = '' THEN NULL ELSE @DEPT_NAME_ORG END
		                            WHERE EST_DEPT_REF_ID	    = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = est_dept_ref_id;
            paramArray[1]               = CreateDataParameter("@HEADER_IMG_ORG", SqlDbType.Int);
            paramArray[1].Value         = header_img_org;
            paramArray[2]               = CreateDataParameter("@SORT_ORG", SqlDbType.Int);
            paramArray[2].Value         = sort_org;
            paramArray[3]               = CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value         = dept_type;
            paramArray[4]               = CreateDataParameter("@DEPT_NAME_ORG", SqlDbType.VarChar);
            paramArray[4].Value         = dept_name_org;

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
    }
}
