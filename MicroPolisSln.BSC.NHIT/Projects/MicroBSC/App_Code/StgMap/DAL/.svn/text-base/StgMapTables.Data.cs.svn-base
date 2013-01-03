using System;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC
{
    public class StgMapTables_Data : DbAgentBase
    {
        #region ------------------------ 필드 ------------------------

        private int _est_year;
        private string _est_month;
        private int _estterm_ref_id     = 0;
        private int _est_dept_ref_id    = 0;
        private int _map_version_id     = 0;

        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public int Est_Year
        {
            get
            {
                return _est_year;
            }
            set
            {
                if (_est_year == value)
                    return;
                _est_year = value;
            }
        }

        public string Est_Month
        {
            get
            {
                return _est_month;
            }
            set
            {
                if (_est_month == value)
                    return;
                _est_month = value;
            }
        }

        public int EstTerm_Ref_ID
        {
            get
            {
                return _estterm_ref_id;
            }
            set
            {
                if (_estterm_ref_id == value)
                    return;
                _estterm_ref_id = value;
            }
        }

        public int Est_Dept_Ref_ID
        {
            get
            {
                return _est_dept_ref_id;
            }
            set
            {
                if (_est_dept_ref_id == value)
                    return;
                _est_dept_ref_id = value;
            }
        }

        public int Map_Version_ID
        {
            get
            {
                return _map_version_id;
            }
            set
            {
                if (_map_version_id == value)
                    return;
                _map_version_id = value;
            }
        }

        #endregion

        public StgMapTables_Data(int est_year, string est_month)
        {
            _est_year           = est_year;
            _est_month          = est_month;
            _estterm_ref_id     = 0;
            _est_dept_ref_id    = 0;
            _map_version_id     = 0;
        }

        public StgMapTables_Data(int est_year, string est_month, int estterm_ref_id, int est_dept_ref_id, int map_version_id)
        {
            _est_year           = est_year;
            _est_month          = est_month;
            _estterm_ref_id     = estterm_ref_id;
            _est_dept_ref_id    = est_dept_ref_id;
            _map_version_id     = map_version_id;
        }

        public DataSet GetWorkList(int stg_map_id)
        {
            string strQuery = @"
SELECT	 A.ESTTERM_REF_ID
        , CASE WHEN ISNULL(A.WORK_REF_ID, 0) = 0 THEN A.EXEC_REF_ID ELSE A.WORK_REF_ID END	AS KPI_REF_ID
        , CASE WHEN ISNULL(A.WORK_REF_ID, 0) = 0 THEN C.EXEC_CODE ELSE B.WORK_CODE END	AS KPI_CODE
        , CASE WHEN ISNULL(A.WORK_REF_ID, 0) = 0 THEN C.EXEC_NAME ELSE B.WORK_NAME END	AS KPI_NAME
        , CASE WHEN ISNULL(A.WORK_REF_ID, 0) = 0 THEN C.EXEC_EMP_ID ELSE B.WORK_EMP_ID END	AS CHAMPION_EMP_ID
        , CASE WHEN ISNULL(A.WORK_REF_ID, 0) = 0 THEN C.USE_YN ELSE B.USE_YN END	AS USE_YN
		, CASE WHEN ISNULL(A.WORK_REF_ID, 0) = 0 THEN 'E' ELSE 'C' END	AS WORK_TYPE
        , CASE WHEN ISNULL(A.WORK_REF_ID, 0) = 0 THEN ISNULL(C.COMPLETE_YN, 'N') ELSE ISNULL(B.COMPLETE_YN, 'N') END	AS COMPLETE_YN
        , ISNULL(C.WORK_REF_ID, 0) AS ORG_KPI_REF_ID
FROM	BSC_MAP_SK_IE	A
LEFT OUTER JOIN BSC_WORK_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
									AND	B.WORK_REF_ID		= A.WORK_REF_ID
LEFT OUTER JOIN BSC_WORK_EXEC	C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
									AND	C.EXEC_REF_ID		= A.EXEC_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
	AND	A.STG_REF_ID		= @STG_REF_ID
	AND	ISNULL(A.WORK_REF_ID, 0) = CASE WHEN ISNULL(A.WORK_REF_ID, 0) = 0 THEN 0 ELSE B.WORK_REF_ID END
	AND	ISNULL(A.EXEC_REF_ID, 0) = CASE WHEN ISNULL(A.EXEC_REF_ID, 0) = 0 THEN 0 ELSE C.EXEC_REF_ID END
ORDER BY WORK_TYPE
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = _estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = _est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value = stg_map_id;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "DataSet", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetKpiList(int stg_map_id) 
        {
            string query = @"SELECT A.ESTTERM_REF_ID
                                    , A.KPI_REF_ID
                                    , A.KPI_CODE
                                    , C.KPI_NAME
                                    --, A.EST_DEPT_ID
                                    , A.CHAMPION_EMP_ID
                                    , A.USE_YN
                                    , A.MEASUREMENT_PURPOSE
                                    , A.RESULT_INPUT_TYPE
                                    , A.CALC_FORM_MS
                                    , A.CALC_FORM_TS
                                    , A.WORD_DEFINITION
                                    , A.RELATED_ISSUE
                                    --, A.CHECK_METHOD
                                    , A.RESULT_MEASUREMENT_STEP
                                    , A.RESULT_TS_CALC_TYPE
                                    , A.RESULT_ACHIEVEMENT_TYPE
                                    --, A.NUJUK_USE
                                    , A.RESULT_TERM_TYPE
                                    , A.MEASUREMENT_GRADE_TYPE
                                    , A.DATA_GETHERING_METHOD
                                    , A.GRAPH_TYPE
                                    , A.UNIT_TYPE_REF_ID
                                    , A.APP_REF_ID
                                    , A.EXCEL_DNUSE
                                    , A.ADD_FILE
                                    , A.APPROVAL_STATUS
                                    , A.MEASUREMENT_EMP_ID
                                    , A.APPROVAL_EMP_ID
                                    , A.KPI_POOL_REF_ID
                                    --, A.KPI_TARGET_VERSION_ID
                                    , A.CREATE_DATE
                                    , A.CREATE_USER
                                    , A.UPDATE_DATE
                                    , A.UPDATE_USER
                                    , B.STG_REF_ID 
                                    , ISNULL(B.MAP_KPI_TYPE, '') AS MAP_KPI_TYPE
                                    , ISNULL(D.CODE_NAME, '') AS MAP_KPI_TYPE_NAME
                                    , ISNULL(D.CODE_DESC, '') AS MAP_KPI_TYPE_DESC
                                FROM         BSC_KPI_INFO       A
                                        JOIN BSC_MAP_KPI        B ON (A.KPI_REF_ID				= B.KPI_REF_ID 
											                            AND A.ESTTERM_REF_ID	= B.ESTTERM_REF_ID)
			                            JOIN BSC_KPI_POOL		C ON (A.KPI_POOL_REF_ID			= C.KPI_POOL_REF_ID)
                                LEFT OUTER JOIN COM_CODE_INFO D ON D.CATEGORY_CODE='BS0017' AND D.ETC_CODE = B.MAP_KPI_TYPE
                                    WHERE A.ESTTERM_REF_ID	    = @ESTTERM_REF_ID
			                            AND B.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
                                        AND B.MAP_VERSION_ID    = @MAP_VERSION_ID
                                        AND B.STG_REF_ID	    = @STG_REF_ID
                                    ORDER BY B.SORT_ORDER, C.KPI_NAME ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = _est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_map_id;
            paramArray[3]               = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = StgMaps_Data.GetMapVersionID(_estterm_ref_id, _est_dept_ref_id, _est_month, _map_version_id);

            DataSet ds                  = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);
            return ds;
        }

        public string GetKPIIndicatorImageName(int kpi_ref_id, CloseType closeType)
        {
            string closeTypeStr = "MS";

            if (closeType == CloseType.TotalSignal)
                closeTypeStr = "TS";

            //string query = @"SELECT [dbo].[fn_KPI_INDICATOR](@iKPI_ID, @iACTUAL_MM, @iPERIOD) AS INDICATOR";

//            string query = @"SELECT B.SIGNAL_" + closeTypeStr + @" FROM		KPI_INFO	A 
//			                                JOIN	TOTAL_SCORE B ON (A.KPI_REF_ID = B.KPI_REF_ID)
//	                                WHERE   B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
//		                                AND B.TMCODE            = @TMCODE
//		                                AND B.KPI_REF_ID        = @KPI_REF_ID";

            string query = @"SELECT C.IMAGE_FILE_NAME
                                       FROM	BSC_KPI_INFO                    A 
		                                    LEFT JOIN BSC_KPI_SCORE         B        ON (A.KPI_REF_ID           = B.KPI_REF_ID 
                                                                                        AND A.ESTTERM_REF_ID    = B.ESTTERM_REF_ID)
		                                    LEFT JOIN BSC_THRESHOLD_CODE    C        ON B.THRESHOLD_REF_ID_" + closeTypeStr + @"  = C.THRESHOLD_REF_ID
                                      WHERE B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
	                                    AND B.KPI_REF_ID        = @KPI_REF_ID
	                                    AND B.YMD               = @YMD";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value         = _est_month;
            paramArray[2]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = kpi_ref_id;
            //paramArray[2]       = CreateDataParameter("@iPERIOD", SqlDbType.Char);
            //paramArray[2].Value = closeTypeStr;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    return ds.Tables[0].Rows[0]["SIGNAL_" + closeTypeStr].ToString();
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["IMAGE_FILE_NAME"].ToString();
            }

            return "ICON_U.GIF";
        }

        public double GetTotalPointByStgMapType(int stg_map_type) 
        {
            string s_query = @"SELECT A.EST_DEPT_REF_ID
		                            , ISNULL(SUM(A.WEIGHT), 0) AS WEIGHT
	                             FROM BSC_MAP_KPI		A 
									JOIN BSC_MAP_STG	B ON (A.ESTTERM_REF_ID			= B.ESTTERM_REF_ID 
																AND A.EST_DEPT_REF_ID	= B.EST_DEPT_REF_ID 
																AND A.STG_REF_ID		= B.STG_REF_ID
                                                                AND A.MAP_VERSION_ID    = B.MAP_VERSION_ID)
									WHERE A.ESTTERM_REF_ID      = @ESTTERM_REF_ID
										AND A.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
										AND B.VIEW_REF_ID       = @STG_MAP_TYPE
                                        AND B.MAP_VERSION_ID    = @MAP_VERSION_ID
									GROUP BY A.EST_DEPT_REF_ID";

            string o_query = @"SELECT A.EST_DEPT_REF_ID
		                            , NVL(SUM(A.WEIGHT), 0) AS WEIGHT
	                             FROM BSC_MAP_KPI		A 
									JOIN BSC_MAP_STG	B ON (A.ESTTERM_REF_ID			= B.ESTTERM_REF_ID 
																AND A.EST_DEPT_REF_ID	= B.EST_DEPT_REF_ID 
																AND A.STG_REF_ID		= B.STG_REF_ID
                                                                AND A.MAP_VERSION_ID    = B.MAP_VERSION_ID)
									WHERE A.ESTTERM_REF_ID      = @ESTTERM_REF_ID
										AND A.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
										AND B.VIEW_REF_ID       = @STG_MAP_TYPE
                                        AND B.MAP_VERSION_ID    = @MAP_VERSION_ID
									GROUP BY A.EST_DEPT_REF_ID";


            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = _est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_MAP_TYPE", SqlDbType.Int);
            paramArray[2].Value         = stg_map_type;
            paramArray[3]               = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = StgMaps_Data.GetMapVersionID(_estterm_ref_id, _est_dept_ref_id, _est_month, _map_version_id);

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "DataSet", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0) 
            {
                return Convert.ToDouble(ds.Tables[0].Rows[0]["WEIGHT"].ToString());
            }

            return 0;
        }

        public double GetStgPointById(int stg_ref_id)
        {
//            string query = @"SELECT EST_DEPT_REF_ID
//		                            , STG_REF_ID
//		                            , ISNULL(SUM(WEIGHT), 0) AS WEIGHT
//	                            FROM REL_STG_KPI 
//		                            WHERE ESTTERM_REF_ID    = @ESTTERM_REF_ID
//			                            AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
//			                            AND STG_REF_ID      = @STG_REF_ID
//	                            GROUP BY EST_DEPT_REF_ID
//			                            , STG_REF_ID";

            string query = @"SELECT EST_DEPT_REF_ID
		                            , STG_REF_ID
		                            , ISNULL(SUM(WEIGHT), 0) AS WEIGHT
	                            FROM BSC_MAP_KPI
								   WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
									 AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
									 AND STG_REF_ID      = @STG_REF_ID
								   GROUP BY EST_DEPT_REF_ID
										  , STG_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = _est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDouble(ds.Tables[0].Rows[0]["WEIGHT"].ToString());
            }

            return 0;
        }

        protected DataSet GetIndicator(int stg_ref_id)
        {
//            string query = @"SELECT REPLACE(REPLACE(UPPER(B.SIGNAL_MS), 'ICON_', ''), '.GIF', '') AS MS
//	                            ,   REPLACE(REPLACE(UPPER(B.SIGNAL_TS), 'ICON_', ''), '.GIF', '') AS TS
//		                            FROM		KPI_INFO	A 
//			                            JOIN	TOTAL_SCORE B ON (A.ESTTERM_REF_ID = B.ESTTERM_REF_ID AND A.KPI_REF_ID = B.KPI_REF_ID)
//			                            JOIN	REL_STG_KPI C ON (A.ESTTERM_REF_ID = C.ESTTERM_REF_ID AND A.KPI_REF_ID = C.KPI_REF_ID)
//	                            WHERE  B.ESTTERM_REF_ID     = @ESTTERM_REF_ID
//		                            AND B.TMCODE            = @TMCODE
//		                            AND C.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
//		                            AND C.STG_REF_ID        = @STG_REF_ID";

            string query = @"SELECT REPLACE(REPLACE(UPPER(D.IMAGE_FILE_NAME), 'ICON_', ''), '.GIF', '') AS MS
	                            ,   REPLACE(REPLACE(UPPER(E.IMAGE_FILE_NAME), 'ICON_', ''), '.GIF', '') AS TS
		                       FROM	BSC_KPI_INFO					A 
			                        LEFT JOIN BSC_KPI_SCORE			B ON (A.ESTTERM_REF_ID		= B.ESTTERM_REF_ID 
																		AND A.KPI_REF_ID		= B.KPI_REF_ID)
			                        LEFT JOIN BSC_MAP_KPI			C ON (A.ESTTERM_REF_ID		= C.ESTTERM_REF_ID 
																		AND A.KPI_REF_ID		= C.KPI_REF_ID)
			                        LEFT JOIN BSC_THRESHOLD_CODE	D ON B.THRESHOLD_REF_ID_MS	= D.THRESHOLD_REF_ID
			                        LEFT JOIN BSC_THRESHOLD_CODE	E ON B.THRESHOLD_REF_ID_TS	= E.THRESHOLD_REF_ID
	                          WHERE B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
		                        AND B.YMD               = @YMD
		                        AND C.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
		                        AND C.STG_REF_ID        = @STG_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value         = _est_month;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = _est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);
            return ds;
        }

        /// <summary>
        /// 해당 전략의 시그널이 전체가 Unmeasured 인지, Alert 시그널이 있는지 여부 구하기
        /// </summary>
        /// <param name="stg_ref_id"></param>
        /// <returns></returns>
        protected DataSet GetStgStatus(int stg_ref_id)
        {
            string query = @"SELECT CASE WHEN (TB.CNT_U=TB.CNT_ALL OR TB.CNT_ALL=0) THEN 'Y' ELSE 'N' END as IS_U
		                           ,CASE WHEN TB.CNT_A>1          THEN 'Y' ELSE 'N' END as IS_A
		                       FROM (
									 SELECT ISNULL(SUM(TA.CNT_U_MS),0)+ISNULL(SUM(TA.CNT_U_TS),0)  as CNT_U
										   ,ISNULL(SUM(TA.CNT_A_MS),0)+ISNULL(SUM(TA.CNT_A_TS),0)  as CNT_A
										   ,ISNULL(SUM(TA.CNT_ALL),0)  as CNT_ALL
									   FROM (
											 SELECT CASE WHEN D.DEFAULT_IMG_YN='Y' THEN 1 ELSE 0 END AS CNT_U_MS
												  , CASE WHEN E.DEFAULT_IMG_YN='Y' THEN 1 ELSE 0 END AS CNT_U_TS
												  , CASE WHEN D.ALERT_IMG_YN='Y' THEN 1 ELSE 0 END   AS CNT_A_MS
												  , CASE WHEN E.ALERT_IMG_YN='Y' THEN 1 ELSE 0 END   AS CNT_A_TS
												  , 2 as CNT_ALL
											   FROM	BSC_MAP_KPI C 
											        INNER JOIN BSC_MAP_TERM A
											           ON C.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
											          AND A.EST_DEPT_REF_ID = A.EST_DEPT_REF_ID
											          AND A.MAP_VERSION_ID  = A.MAP_VERSION_ID
											          AND A.YMD             = @YMD
													LEFT JOIN BSC_KPI_SCORE B 
													  ON C.ESTTERM_REF_ID = B.ESTTERM_REF_ID 
													 AND C.KPI_REF_ID     = B.KPI_REF_ID
													LEFT JOIN BSC_THRESHOLD_CODE D 
													  ON B.THRESHOLD_REF_ID_MS = D.THRESHOLD_REF_ID
													LEFT JOIN BSC_THRESHOLD_CODE E 
													  ON B.THRESHOLD_REF_ID_TS = E.THRESHOLD_REF_ID
											  WHERE B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
												AND B.YMD               = @YMD
												AND C.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
												AND C.STG_REF_ID        = @STG_REF_ID
											 ) TA
		                            ) TB";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value         = _est_month;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = _est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);
            return ds;
        }

        protected string GetTargetByMonth(int kpi_ref_id)
        {
//            string query = @"SELECT    CONVERT(varchar(100),CONVERT(int, A.TARGET)) + '' + C.UNIT AS TARGET_TEXT
//	                            FROM	 KPI_TARGET			A
//		                            JOIN KPI_INFO			B ON A.KPI_REF_ID	= B.KPI_REF_ID
//		                            JOIN COM_UNIT_TYPE_INFO C ON B.UNIT_TYPE_ID = C.UNIT_TYPE_REF_ID
//	                            WHERE A.KPI_REF_ID	= @KPI_REF_ID
//		                            AND A.TMCODE	= @TMCODE
//                            ";

            string query = @"SELECT CONVERT(varchar(100), CONVERT(int, A.TARGET_MS)) + '' + C.UNIT AS TARGET_TEXT
	                            FROM	 BSC_KPI_TARGET			A
		                            JOIN BSC_KPI_INFO			B ON A.KPI_REF_ID		= B.KPI_REF_ID
		                            JOIN COM_UNIT_TYPE_INFO		C ON B.UNIT_TYPE_REF_ID = C.UNIT_TYPE_REF_ID
	                            WHERE   A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
                                    AND A.KPI_REF_ID	        = @KPI_REF_ID
		                            AND A.YMD                   = @YMD";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_ref_id;
            paramArray[2]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2].Value         = _est_month;
            
            DataSet ds                  = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count == 0)
                return " ";

            return ds.Tables[0].Rows[0]["TARGET_TEXT"].ToString();
            
        }
        
    }
}
