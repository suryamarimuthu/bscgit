using System;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;
using MicroBSC.Biz.BSC;

namespace MicroBSC.Biz.BSC
{
    public class StgMaps_Data : DbAgentBase
    {
        #region ------------------------ 필드 ------------------------

        private int _estterm_ref_id;
        private int _est_dept_ref_id;
        private int _map_version_id;
        private int _stg_map_id;
        private int _up_stg_map_id;
        private int _stg_map_type;
        private int _view_seq;
        private string _stg_name;
        private string _stg_desc;
        private string _est_month;

        #endregion

        #region ------------------------ 프로퍼티 ------------------------

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

        public int Stg_Map_ID
        {
            get
            {
                return _stg_map_id;
            }
            set
            {
                _stg_map_id = value;
            }
        }

        public int Up_Stg_Map_ID
        {
            get
            {
                return _up_stg_map_id;
            }
            set
            {
                _up_stg_map_id = value;
            }
        }

        public int Stg_Map_Type
        {
            get
            {
                return _stg_map_type;
            }
            set
            {
                _stg_map_type = value;
            }
        }

        // [20071002추가] juny177
        public int View_Seq
        {
            get
            {
                return _view_seq;
            }
            set
            {
                _view_seq = value;
            }
        }

        public string Stg_Name
        {
            get
            {
                return _stg_name;
            }
            set
            {
                if (_stg_name == value)
                    return;
                _stg_name = value;
            }
        }
        public string Stg_Desc
        {
            get
            {
                return _stg_desc;
            }
            set
            {
                if (_stg_desc == value)
                    return;
                _stg_desc = value;
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

        #endregion

        public StgMaps_Data() 
        {
        
        }

        public StgMaps_Data(int estterm_ref_id, int est_dept_ref_id, string est_month, int map_version_id)
        {
            _estterm_ref_id     = estterm_ref_id;
            _est_dept_ref_id    = est_dept_ref_id;
            _est_month          = est_month;
            _map_version_id     = map_version_id;
        }

        public StgMaps_Data(int estterm_ref_id, int est_dept_ref_id, int stg_map_id, string est_month, int map_version_id) 
        {
            _estterm_ref_id     = estterm_ref_id;
            _est_dept_ref_id    = est_dept_ref_id;
            _est_month          = est_month;
            _map_version_id     = map_version_id;

            DataSet ds = GetMapInfoByStgID(stg_map_id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                dr                  = ds.Tables[0].Rows[0];
                _stg_map_id         = Convert.ToInt32(dr["STG_REF_ID"]);
                _up_stg_map_id      = (dr["UP_STG_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UP_STG_ID"]);
                _stg_map_type       = Convert.ToInt32(dr["VIEW_REF_ID"]);
                _stg_name           = Convert.ToString(dr["STG_NAME"]);
                _stg_desc           = Convert.ToString(dr["STG_SET_DESC"]);
                _view_seq           = Convert.ToInt32(dr["VIEW_SEQ"]);
            }
        }
        
        public DataSet GetMapinfo(int stg_map_id, int up_stg_map_id, int stg_map_type)
        {
            string query = @"
                               SELECT X.ESTTERM_REF_ID
                                    , X.EST_DEPT_REF_ID
                                    , X.STG_REF_ID
                                    , X.UP_STG_ID
                                    , X.VIEW_REF_ID
                                    , X.SORT_ORDER
                                    , Y.STG_NAME
                                    , Y.STG_SET_DESC   
                                    , X.VIEW_SEQ
                                  FROM (
                                      SELECT BMS.ESTTERM_REF_ID
                                           , BMS.EST_DEPT_REF_ID
                                           , BMS.STG_REF_ID 
                                           , NULL AS UP_STG_ID 
                                           , BMS.VIEW_REF_ID
                                           , BMS.SORT_ORDER
                                           , BVI.VIEW_SEQ 
                                       FROM BSC_MAP_STG BMS
                                        LEFT JOIN BSC_VIEW_INFO BVI  ON BMS.VIEW_REF_ID = BVI.VIEW_REF_ID
                                      WHERE ESTTERM_REF_ID	= @ESTTERM_REF_ID
                                        AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                        AND MAP_VERSION_ID  = @MAP_VERSION_ID
                                        AND STG_REF_ID NOT IN (SELECT STG_REF_ID 
                                                                 FROM BSC_MAP_STG_PARENT 
                                                                WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID 
                                                                  AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                                                  AND MAP_VERSION_ID  = @MAP_VERSION_ID)
                                      UNION 
                                      SELECT TA.ESTTERM_REF_ID
                                           , TA.EST_DEPT_REF_ID
                                           , TA.STG_REF_ID
                                           , TA.UP_STG_REF_ID
                                           , TB.VIEW_REF_ID
                                           , TB.SORT_ORDER
                                            , TI.VIEW_SEQ
                                       FROM BSC_MAP_STG_PARENT TA
                                            LEFT JOIN BSC_MAP_STG TB
                                              ON TA.ESTTERM_REF_ID  = TB.ESTTERM_REF_ID
                                             AND TA.EST_DEPT_REF_ID = TB.EST_DEPT_REF_ID
                                             AND TA.MAP_VERSION_ID  = TB.MAP_VERSION_ID
                                             AND TA.STG_REF_ID      = TB.STG_REF_ID
                                        LEFT JOIN BSC_VIEW_INFO TI  ON TB.VIEW_REF_ID = TI.VIEW_REF_ID
                                      WHERE TA.ESTTERM_REF_ID	= @ESTTERM_REF_ID
                                        AND TA.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
                                        AND TA.MAP_VERSION_ID   = @MAP_VERSION_ID
                                      ) X 
                                         LEFT JOIN BSC_STG_INFO Y ON (X.ESTTERM_REF_ID = Y.ESTTERM_REF_ID AND X.STG_REF_ID = Y.STG_REF_ID)
                                        WHERE (Y.STG_REF_ID 	    = @STG_REF_ID 		OR @STG_REF_ID 		= 0)
                                          AND (X.UP_STG_ID 	        = @UP_STG_ID 	    OR @UP_STG_ID 	    = 0)
                                          AND (X.VIEW_REF_ID 	    = @STG_MAP_TYPE 	OR @STG_MAP_TYPE 	= 0)
                                    ORDER BY X.VIEW_SEQ, X.SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = _est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_map_id;
            paramArray[3]               = CreateDataParameter("@UP_STG_ID", SqlDbType.Int);
            paramArray[3].Value         = up_stg_map_id;
            paramArray[4]               = CreateDataParameter("@STG_MAP_TYPE", SqlDbType.Int);
            paramArray[4].Value         = stg_map_type;
            paramArray[5]               = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[5].Value         = StgMaps_Data.GetMapVersionID(_estterm_ref_id, _est_dept_ref_id, _est_month, _map_version_id);

            DataSet ds                  = DbAgentObj.FillDataSet(query, "MAPINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public static int GetMapVersionID(int estterm_ref_id, int est_dept_ref_id, string est_month, int map_version_id)
        {
            if (map_version_id != 0)
                return map_version_id;

            MicroBSC.BSC.Biz.Biz_Bsc_Map_Term mapTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Term();
            DataSet ds = mapTerm.GetOneList(estterm_ref_id, est_dept_ref_id, est_month);


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0]["MAP_VERSION_ID"].ToString());
            }

            return 0;
        }

        public DataSet GetMapInfoByStgType(int stg_map_type)
        {
            return GetMapinfo(0, 0, stg_map_type);
        }

        public DataSet GetMapInfoByUpStgID(int up_stg_map_id)
        {
            return GetMapinfo(0, up_stg_map_id, 0);
        }

        public DataSet GetMapInfoByStgID(int stg_map_id)
        {
            return GetMapinfo(stg_map_id, 0, 0);
        }

        /// <summary>
        /// 전략맵인과관계를 가지고 옴 (오버로드 1)
        /// </summary>
        /// <param name="stg_map_id"></param>
        /// <returns></returns>
        public DataSet GetStgMapList(int stg_map_id)
        {
            return GetStgMapList(stg_map_id, 0);
        }

        //, vertical_id.ToString()

        /// <summary>
        /// 전략맵인과관계를 가지고 옴 (오버로드 2)
        /// </summary>
        /// <param name="stg_map_id"></param>
        /// <param name="stg_map_type"></param>
        /// <returns></returns>
        public DataSet GetStgMapList(int stg_map_id, int stg_map_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = _est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_map_id;
            paramArray[3]               = CreateDataParameter("@STG_MAP_TYPE", SqlDbType.Int);
            paramArray[3].Value         = stg_map_type;
            paramArray[4]               = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[4].Value         = StgMaps_Data.GetMapVersionID(_estterm_ref_id, _est_dept_ref_id, _est_month, _map_version_id);

            DataSet rDs = new DataSet();
            //string providertype = GetProviderType();
            string s_query = "";
            string o_query = "";

                   s_query = @"SELECT ESTTERM_REF_ID
                                    , EST_DEPT_REF_ID
                                    , STG_REF_ID
                                    , UP_STG_ID
                                    , STG_MAP_TYPE
                                    , STG_NAME
                                    , STG_SET_DESC
                                    , SORT_ORDER
                                    , STG_MAP_LEVEL
                                FROM dbo.fn_GetStgMapByLevel_Version(@ESTTERM_REF_ID, @EST_DEPT_REF_ID, @STG_REF_ID, @MAP_VERSION_ID) 
                                    WHERE (STG_MAP_TYPE = @STG_MAP_TYPE OR @STG_MAP_TYPE = 0) 
                                ORDER BY SORT_ORDER, UP_STG_ID, STG_REF_ID";


                     o_query = @"SELECT TZ.ESTTERM_REF_ID
                                       ,TZ.EST_DEPT_REF_ID
                                       ,TZ.STG_MAP_TYPE
                                       ,TZ.STG_REF_ID
                                       ,TZ.UP_STG_ID
                                       ,MAX(TZ.STG_NAME)
                                       ,'' as STG_SET_DESC
                                       ,MAX(TZ.STG_MAP_LEVEL) as STG_MAP_LEVEL
                                   FROM (
                                          SELECT TT.ESTTERM_REF_ID             
                                                ,TT.EST_DEPT_REF_ID            
                                                ,TT.STG_MAP_TYPE
                                                ,TT.STG_REF_ID
                                                ,TT.STG_NAME                 
                                                ,TT.UP_STG_ID                                                 
                                                ,TT.STG_SET_DESC as STG_SET_DESC           
                                                ,TT.UP_STG_REF_ID              
                                                ,TT.SORT_ORDER as SORT_ORDER
                                                ,TT.STG_MAP_LEVEL as STG_MAP_LEVEL
                                                ,ROWNUM as ALL_ORDER
                                            FROM (
                                                  SELECT TA.ESTTERM_REF_ID
                                                       , TA.EST_DEPT_REF_ID
                                                       , TA.STG_REF_ID, TB.STG_NAME
                                                       , TA.UP_STG_REF_ID as UP_STG_ID
                                                       , TC.VIEW_REF_ID as STG_MAP_TYPE
                                                       , ' ' as STG_SET_DESC
                                                       , TA.UP_STG_REF_ID
                                                       , TC.SORT_ORDER
                                                       , LEVEL as STG_MAP_LEVEL
                                                       , VI.VIEW_SEQ
                                                    FROM (                                           
                                                          SELECT @ESTTERM_REF_ID  as ESTTERM_REF_ID
                                                               , @EST_DEPT_REF_ID as EST_DEPT_REF_ID
                                                               , @MAP_VERSION_ID  as MAP_VERSION_ID
                                                               , @STG_REF_ID      as STG_REF_ID
                                                               , NULL             as UP_STG_REF_ID 
                                                            FROM DUAL
                                                          UNION ALL
                                                          SELECT ESTTERM_REF_ID
                                                               , EST_DEPT_REF_ID
                                                               , MAP_VERSION_ID
                                                               , STG_REF_ID
                                                               , UP_STG_REF_ID
                                                            FROM BSC_MAP_STG_PARENT
                                                           WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                             AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                                             AND MAP_VERSION_ID  = @MAP_VERSION_ID
                                                         ) TA
                                                         LEFT JOIN BSC_STG_INFO TB
                                                           ON TA.STG_REF_ID = TB.STG_REF_ID
                                                         LEFT JOIN BSC_MAP_STG TC
                                                           ON TA.ESTTERM_REF_ID  = TC.ESTTERM_REF_ID
                                                          AND TA.EST_DEPT_REF_ID = TC.EST_DEPT_REF_ID
                                                          AND TA.MAP_VERSION_ID  = TC.MAP_VERSION_ID
                                                          AND TA.STG_REF_ID      = TC.STG_REF_ID
                                                         LEFT JOIN BSC_VIEW_INFO VI
                                                           ON TC.VIEW_REF_ID = VI.VIEW_REF_ID
                                                   WHERE (TC.VIEW_REF_ID = @STG_MAP_TYPE OR @STG_MAP_TYPE=0)
                                                   START WITH TA.UP_STG_REF_ID IS NULL
                                                   CONNECT BY PRIOR TA.STG_REF_ID = TA.UP_STG_REF_ID
                                                   ORDER BY TA.ESTTERM_REF_ID
                                                          , TA.EST_DEPT_REF_ID
                                                          , VI.VIEW_SEQ
                                                          , TC.SORT_ORDER                                          
                                                   ) TT
                                        ) TZ
                                  GROUP BY TZ.ESTTERM_REF_ID
                                          ,TZ.EST_DEPT_REF_ID
                                          ,TZ.STG_MAP_TYPE
                                          ,TZ.STG_REF_ID
                                          ,TZ.UP_STG_ID
                                  ORDER BY MAX(TZ.ALL_ORDER)";

//                     o_query = @"
//                                 SELECT TC.ESTTERM_REF_ID 
//                                       ,TC.EST_DEPT_REF_ID
//                                       ,TC.VIEW_REF_ID as STG_MAP_TYPE
//                                       ,TC.VIEW_NAME      
//                                       ,TC.STG_REF_ID     
//                                       ,TC.STG_NAME    
//                                       ,'' as STG_SET_DESC
//                                       ,TC.UP_STG_REF_ID as UP_STG_ID 
//                                       ,TC.VIEW_SEQ       
//                                       ,TC.SORT_ORDER     
//                                       ,TC.STG_LEVEL     as STG_MAP_LEVEL
//                                       ,TC.ALL_SORT_ORDER 
//                                   FROM (
//                                          SELECT TB.ESTTERM_REF_ID         as ESTTERM_REF_ID 
//                                                ,TB.EST_DEPT_REF_ID        as EST_DEPT_REF_ID
//                                                ,TB.VIEW_REF_ID            as VIEW_REF_ID    
//                                                ,TB.VIEW_NAME              as VIEW_NAME      
//                                                ,TB.STG_REF_ID             as STG_REF_ID     
//                                                ,TB.STG_NAME               as STG_NAME       
//                                                ,TB.UP_STG_REF_ID          as UP_STG_REF_ID  
//                                                ,MAX(TB.VIEW_SEQ)          as VIEW_SEQ       
//                                                ,MAX(TB.SORT_ORDER)        as SORT_ORDER     
//                                                ,MAX(TB.STG_LEVEL)         as STG_LEVEL      
//                                                ,MAX(TB.ALL_SORT_ORDER)    as ALL_SORT_ORDER 
//                                            FROM (
//                                                   SELECT TA.ESTTERM_REF_ID 
//                                                         ,TA.EST_DEPT_REF_ID
//                                                         ,TA.VIEW_REF_ID    
//                                                         ,TA.STG_REF_ID  
//                                                         ,TA.STG_NAME   
//                                                         ,TA.UP_STG_REF_ID
//                                                         ,TA.VIEW_SEQ
//                                                         ,TA.SORT_ORDER
//                                                         ,TA.VIEW_NAME 
//                                                         ,LEVEL  as STG_LEVEL
//                                                         ,ROWNUM as ALL_SORT_ORDER
//                                                     FROM (           
//                                                            SELECT MS.ESTTERM_REF_ID
//                                                                 , MS.EST_DEPT_REF_ID
//                                                                 , MS.VIEW_REF_ID
//                                                                 , MS.STG_REF_ID
//                                                                 , SI.STG_NAME
//                                                                 , NVL(SP.UP_STG_REF_ID,0) as UP_STG_REF_ID
//                                                                 , VI.VIEW_SEQ
//                                                                 , MS.SORT_ORDER
//                                                                 , VI.VIEW_NAME
//                                                              FROM BSC_MAP_STG MS
//                                                                   INNER JOIN BSC_STG_INFO SI
//                                                                      ON MS.ESTTERM_REF_ID  = SI.ESTTERM_REF_ID
//                                                                     AND MS.STG_REF_ID      = SI.STG_REF_ID
//                                                                   INNER JOIN BSC_VIEW_INFO VI
//                                                                      ON MS.VIEW_REF_ID = VI.VIEW_REF_ID
//                                                                   LEFT JOIN BSC_MAP_STG_PARENT SP
//                                                                     ON MS.ESTTERM_REF_ID  = SP.ESTTERM_REF_ID
//                                                                    AND MS.EST_DEPT_REF_ID = SP.EST_DEPT_REF_ID
//                                                                    AND MS.STG_REF_ID      = SP.STG_REF_ID
//                                                                    AND MS.MAP_VERSION_ID  = SP.MAP_VERSION_ID
//                                                                    AND MS.MAP_VERSION_ID  = @MAP_VERSION_ID
//                                                             WHERE MS.ESTTERM_REF_ID       = @ESTTERM_REF_ID
//                                                               AND MS.EST_DEPT_REF_ID      = @EST_DEPT_REF_ID                     
//                                                          ) TA
//                                                    START WITH (TA.STG_REF_ID = :STG_REF_ID OR :STG_REF_ID = 0) 
//                                                    CONNECT BY PRIOR TA.STG_REF_ID =TA.UP_STG_REF_ID          
//                                                 ) TB        
//                                            GROUP BY TB.ESTTERM_REF_ID 
//                                                    ,TB.EST_DEPT_REF_ID
//                                                    ,TB.VIEW_REF_ID    
//                                                    ,TB.VIEW_NAME      
//                                                    ,TB.STG_REF_ID    
//                                                    ,TB.STG_NAME 
//                                                    ,TB.UP_STG_REF_ID
//                                         ) TC
//                                  WHERE (TC.VIEW_REF_ID = @STG_MAP_TYPE OR @STG_MAP_TYPE = 0) 
//                                  ORDER BY TC.ALL_SORT_ORDER
//                               ";

            rDs = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "DataSet", null, paramArray, CommandType.Text);

            return rDs;
        }

        /// <summary>
        /// 최상위 객체의 갯수를 반환한다.
        /// </summary>
        /// <returns></returns>
        public int GetTopParentCount(int isContainType)
        {
            return GetTopParents(isContainType).Tables[0].Rows.Count;
        }

        /// <summary>
        /// 최상위 객체의 정보를 가지고 온다. (UP_STG_ID 이 NULL 인 개체)
        /// </summary>
        /// <returns></returns>
        public DataSet GetTopParents(int isContainType) 
        {
            // -1->최상위부모가아님, 0->전체, 1->자식이존재함, 2->자식이존재하지않음

            string query = @"
                                  SELECT * FROM (
                                                SELECT A.ESTTERM_REF_ID
                                                     , A.EST_DEPT_REF_ID
                                                     , A.STG_REF_ID 
                                                     , NULL AS UP_STG_ID 
                                                     , A.VIEW_REF_ID AS STG_MAP_TYPE 
                                                     , B.VIEW_SEQ
                                                     , A.SORT_ORDER
                                                     , CASE WHEN 
                                                           (SELECT COUNT(*)
                                                              FROM BSC_MAP_STG_PARENT
                                                             WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                               AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                                               AND MAP_VERSION_ID  = @MAP_VERSION_ID
                                                               AND UP_STG_REF_ID   = A.STG_REF_ID) > 0 
                                                       THEN 
                                                           1
                                                       ELSE
                                                           2
                                                      END AS ISCONTAIN
                                                 FROM BSC_MAP_STG A
                                                 JOIN BSC_VIEW_INFO B ON A.VIEW_REF_ID = B.VIEW_REF_ID
                                                WHERE A.ESTTERM_REF_ID	  = @ESTTERM_REF_ID
                                                  AND A.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
                                                  AND A.MAP_VERSION_ID    = @MAP_VERSION_ID
                                                  AND A.STG_REF_ID NOT IN (SELECT STG_REF_ID 
                                                                             FROM BSC_MAP_STG_PARENT 
                                                                            WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                                              AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                                                              AND MAP_VERSION_ID  = @MAP_VERSION_ID)
                                                ) X 
                                      WHERE (X.ISCONTAIN = @ISCONTAIN OR @ISCONTAIN = 0)
                                      ORDER BY X.VIEW_SEQ, X.SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = _est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@ISCONTAIN", SqlDbType.Int);
            paramArray[2].Value         = isContainType;
            paramArray[3]               = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = StgMaps_Data.GetMapVersionID(_estterm_ref_id, _est_dept_ref_id, _est_month, _map_version_id);

            DataSet ds                  = DbAgentObj.Fill(query, paramArray, CommandType.Text);
            return ds;
        }

        public int GetStgMapType(int stg_map_id) 
        {
            DataRowCollection drCol = GetMapInfoByStgID(stg_map_id).Tables[0].Rows;

            if (drCol.Count > 0)
            {
                return Convert.ToInt32(drCol[0]["VIEW_REF_ID"].ToString());
            }

            return 0;
        }

        // 자식을 가지고 있지 않은 부모가 있는지 확인
        public bool IsNotContainChildrenParents() 
        {
            int cnt = GetTopParentCount(2);

            if (cnt > 0)
                return true;

            return false;
        }

        // 전략 실적 상태 여부
        public StatusType GetStatusTypeByStgRefID(int sta_ref_id) 
        {
            StatusType statusType = StatusType.Ended;

            return statusType;
        }

        //[20070927]juny177 수정 :BSE_NEW 호출로 변경
        public int GetStgMapTypeCount() 
        {
            MicroBSC.BSC.Biz.Biz_Bsc_View_Info biz = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();     
            DataSet ds          = biz.GetAllList();
            return ds.Tables[0].Rows.Count;
        }

        //[20070927]juny177 수정 :BSE_NEW 호출로 변경
        public DataTable GetStgMapTypes()
        {
            MicroBSC.BSC.Biz.Biz_Bsc_View_Info biz = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
            DataSet ds          = biz.GetAllList();
            return ds.Tables[0];
        }

        public bool IsAllRelationed(int stg_map_id) 
        {
            string s_query = @"
                           SELECT CASE WHEN TA.ALL_STG = 0 
                                        THEN 'F' 
                                    ELSE 
                                        CASE WHEN (TA.ALL_STG - TB.UP_STG) = 0 
                                                THEN 'T' 
                                            ELSE 'F' 
                                        END 
                            END AS RTN
                        FROM (
                                SELECT COUNT(STG_REF_ID) AS ALL_STG
                                  FROM BSC_MAP_STG
                                 WHERE ESTTERM_REF_ID   = @ESTTERM_REF_ID
                                   AND EST_DEPT_REF_ID  = @EST_DEPT_REF_ID
                                   AND MAP_VERSION_ID   = @MAP_VERSION_ID
                                   AND VIEW_REF_ID      = (SELECT TOP 1 TB.VIEW_REF_ID
                                                             FROM BSC_MAP_STG TA 
                                                                  LEFT JOIN BSC_VIEW_INFO TB
                                                                    ON TA.VIEW_REF_ID = TB.VIEW_REF_ID
                                                                  
                                                                  
                                                            WHERE TA.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                              AND TA.EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                                              AND TA.MAP_VERSION_ID  = @MAP_VERSION_ID
                                                              AND TB.VIEW_SEQ    < ( SELECT B.VIEW_SEQ
                                                                                       FROM BSC_MAP_STG A 
                                                                                            LEFT JOIN BSC_VIEW_INFO B
                                                                                              ON A.VIEW_REF_ID = B.VIEW_REF_ID
                                                                                      WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                                                        AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                                                                        AND MAP_VERSION_ID  = @MAP_VERSION_ID
                                                                                        AND STG_REF_ID      = @STG_REF_ID)
                                                            ORDER BY TB.VIEW_SEQ DESC)
                            ) TA,
                                    (SELECT COUNT(UP_STG_REF_ID) AS UP_STG
                                       FROM BSC_MAP_STG_PARENT
                                      WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                        AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                        AND MAP_VERSION_ID  = @MAP_VERSION_ID
                                        AND STG_REF_ID      = @STG_REF_ID) TB
                            WHERE 1 = 1     ";

            string o_query = @"
                           SELECT 
                                CASE 
                                    WHEN TA.ALL_STG = 0  THEN 'F' 
                                ELSE 
                                    CASE WHEN (TA.ALL_STG - TB.UP_STG) = 0  THEN 'T' ELSE 'F' END 
                                END AS RTN
                            FROM (
                                SELECT COUNT(STG_REF_ID) AS ALL_STG
                                FROM BSC_MAP_STG
                                WHERE ESTTERM_REF_ID   = @ESTTERM_REF_ID
                                    AND EST_DEPT_REF_ID  = @EST_DEPT_REF_ID
                                    AND MAP_VERSION_ID   = @MAP_VERSION_ID
                                    AND VIEW_REF_ID      = ( SELECT VIEW_REF_ID FROM 
                                                                ( SELECT 
                                                                    TB.VIEW_REF_ID,
                                                                    ROWNUM AS RNUM
                                                                FROM BSC_MAP_STG TA 
                                                                LEFT JOIN BSC_VIEW_INFO TB
                                                                    ON TA.VIEW_REF_ID = TB.VIEW_REF_ID
                                                                WHERE TA.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                                    AND TA.EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                                                    AND TA.MAP_VERSION_ID  = @MAP_VERSION_ID
                                                                    AND TB.VIEW_SEQ    < (SELECT B.VIEW_SEQ
                                                                            FROM BSC_MAP_STG A 
                                                                            LEFT JOIN BSC_VIEW_INFO B
                                                                                ON A.VIEW_REF_ID = B.VIEW_REF_ID
                                                                            WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                                                AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                                                                AND MAP_VERSION_ID  = @MAP_VERSION_ID
                                                                                AND STG_REF_ID      = @STG_REF_ID)                                                    
                                                               ORDER BY TB.VIEW_SEQ DESC )
                                                           WHERE RNUM = 1 )
                            ) TA ,(SELECT COUNT(UP_STG_REF_ID) AS UP_STG
                               FROM BSC_MAP_STG_PARENT
                              WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                AND MAP_VERSION_ID  = @MAP_VERSION_ID
                                AND STG_REF_ID      = @STG_REF_ID) TB
                            WHERE 1 = 1   ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = _est_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_map_id;
            paramArray[3]               = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = StgMaps_Data.GetMapVersionID(_estterm_ref_id, _est_dept_ref_id, _est_month, _map_version_id);

            string outValue             = Convert.ToString(DbAgentObj.ExecuteScalar(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text));

            if (outValue == "T")
                return true;

            return false;
        }
    }
}
