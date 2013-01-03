using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// ------------------------------------------------------
/// DATE    : 2007.08.30
/// AUTHOR  : juny177
/// MEMO    : [오라클/MS-SQL] 구문 공통사용을 위한 변경
/// ------------------------------------------------------

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class DeptInfos : DbAgentBase
    {
        private string errMSG = "";

        public string IERRMSG
        {
            get
            {
                return this.errMSG;
            }
            set
            {
                this.errMSG = value;
            }
        }

        public DeptInfos()
        {

        }

        public DeptInfos(int est_dept_ref_id)
        {
            DataSet ds = GetDeptInfo(est_dept_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];
                _est_dept_ref_id    = Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _up_est_dept_id     = Convert.ToInt32(dr["UP_EST_DEPT_ID"]);
                _dept_level         = Convert.ToInt32(dr["DEPT_LEVEL"]);
                _dept_name          = Convert.ToString(dr["DEPT_NAME"]);
                _temp_flag          = Convert.ToBoolean(dr["TEMP_FLAG"]);
                _create_date        = Convert.ToDateTime(dr["CREATE_DATE"]);
                _dept_ref_id        = (dr["DEPT_REF_ID"] != DBNull.Value) ?  Convert.ToInt32(dr["DEPT_REF_ID"]):0;
                _estterm_ref_id     = Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _dept_type          = Convert.ToInt32(dr["DEPT_TYPE"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private int _est_dept_ref_id;
        private int _up_est_dept_id;
        private int _dept_level;
        private string _dept_name;
        private Boolean _temp_flag;
        private DateTime _create_date;
        private int _dept_ref_id;
        private int _estterm_ref_id;
        private int _dept_type;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public int Est_Dept_Ref_ID
        {
            get
            {
                return _est_dept_ref_id;
            }
            set
            {
                _est_dept_ref_id = value;
            }
        }

        public int Up_Est_Dept_ID
        {
            get
            {
                return _up_est_dept_id;
            }
            set
            {
                _up_est_dept_id = value;
            }
        }

        public int Dept_Level
        {
            get
            {
                return _dept_level;
            }
            set
            {
                _dept_level = value;
            }
        }

        public string Dept_Name
        {
            get
            {
                return _dept_name;
            }
            set
            {
                _dept_name = (value == null ? "" : value);
            }
        }

        public Boolean Temp_Flag
        {
            get
            {
                return _temp_flag;
            }
            set
            {
                _temp_flag = value;
            }
        }

        public DateTime Create_Date
        {
            get
            {
                return _create_date;
            }
            set
            {
                _create_date = value;
            }
        }

        public int Dept_Ref_ID
        {
            get
            {
                return _dept_ref_id;
            }
            set
            {
                _dept_ref_id = value;
            }
        }

        public int Estterm_Ref_ID
        {
            get
            {
                return _estterm_ref_id;
            }
            set
            {
                _estterm_ref_id = value;
            }
        }
        public int Dept_Type
        {
            get
            {
                return _dept_type;
            }
            set
            {
                _dept_type = value;
            }
        }
        
        #endregion
        
        public DataSet GetDeptInfo(int est_dept_ref_id)
        {
            string query = @"SELECT	EST_DEPT_REF_ID
	                              , UP_EST_DEPT_ID
	                              , DEPT_LEVEL
	                              , DEPT_NAME
	                              , TEMP_FLAG
	                              , CREATE_DATE
	                              , DEPT_REF_ID
	                              , ESTTERM_REF_ID
                                  , DEPT_TYPE
                               FROM EST_DEPT_INFO
                              WHERE	EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                  ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = est_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }
        
        public DataSet getEstDeptTree(int iEstTermId,int iEmpRefID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "DT";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iEstTermId;
            paramArray[2]       = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iEmpRefID;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_EST_DEPT_INFO", "PKG_EST_DEPT_INFO.PROC_SELECT_EST_DEPT_TREE"), "ESTTREE_TBL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptHaveMap(int iEstTermId , string iymd, int itop_dept_ref_id, int ilogin_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "MD";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iEstTermId;
            paramArray[2]       = CreateDataParameter("@iYMD", SqlDbType.Int);
            paramArray[2].Value = iymd;
            paramArray[3]       = CreateDataParameter("@iTOP_DEPT_REF_ID", SqlDbType.Int);
            paramArray[3].Value = itop_dept_ref_id;
            paramArray[4]       = CreateDataParameter("@iLOGIN_ID", SqlDbType.Int);
            paramArray[4].Value = ilogin_id;



            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_EST_DEPT_INFO", "PKG_EST_DEPT_INFO.PROC_SELECT_HAVE_MAP_DEPT"), "ESTTREE_TBL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        // 2007.08.30 [juny177] join 안에 펑션..  > 오라클용으로 처리해야함
        public DataSet getEstDeptList(int iEstTermId, int emp_ref_id)
        {
            string strSQL = @" SELECT A.EST_DEPT_REF_ID
                                    , A.DEPT_NAME 
                                    , B.TREE_NODE_TYPE
                                FROM EST_DEPT_INFO  A
                                     JOIN dbo.fn_BSC_EMP_COM_DEPT_BY_EMP_ID(@EMP_REF_ID) B 
                                       ON (A.DEPT_REF_ID = B.DEPT_REF_ID) 
                               WHERE A.ESTTERM_REF_ID = @iESTTERM_REF_ID 
                                 AND A.TEMP_FLAG = 1
                               ORDER BY A.SORT_ORDER";


            string strORA = @"
                              SELECT TA.EST_DEPT_REF_ID
                                    ,TA.DEPT_NAME
                                    ,CASE WHEN BE.DEPT_REF_ID = NULL THEN 0 ELSE 1 END as TREE_NODE_TYPE
                                FROM (
                                      SELECT ED.ESTTERM_REF_ID
                                            ,ED.EST_DEPT_REF_ID
                                            ,ED.UP_EST_DEPT_ID
                                            ,ED.DEPT_NAME
                                            ,LEVEL  as DEPT_LEVEL
                                            ,ED.DEPT_REF_ID
                                            ,ROWNUM as SORT_ORDER
                                        FROM EST_DEPT_INFO ED
                                       WHERE ESTTERM_REF_ID       = @iESTTERM_REF_ID
                                         AND ED.TEMP_FLAG         = 1
                                       START WITH EST_DEPT_REF_ID = (SELECT EST_DEPT_REF_ID
                                                                       FROM EST_DEPT_INFO
                                                                      WHERE ESTTERM_REF_ID = @iESTTERM_REF_ID
                                                                        AND (UP_EST_DEPT_ID = NULL OR UP_EST_DEPT_ID = 0)
                                                                        AND ROWNUM = 1)
                                       CONNECT BY PRIOR EST_DEPT_REF_ID = UP_EST_DEPT_ID  
                                     ) TA
                                     LEFT JOIN BSC_EMP_COM_DEPT_DETAIL BE
                                       ON TA.DEPT_REF_ID = BE.DEPT_REF_ID
                                      AND BE.EMP_REF_ID  = @EMP_REF_ID
                               ORDER BY TA.SORT_ORDER
                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iEstTermId;
            paramArray[1]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(strSQL, strORA), "ESTTREE_TBL", null, paramArray, CommandType.Text);
            return ds;
        }

        // 2011.08.22 [박효동] kpi실적화면, 부서범위로 가져오기
        public DataSet getComDeptListByPermit(int emp_ref_id)
        {
            string strSQL = @" SELECT A.DEPT_REF_ID
                                    , A.DEPT_NAME 
                                    , B.TREE_NODE_TYPE
                                FROM COM_DEPT_INFO  A
                                     JOIN dbo.fn_BSC_EMP_COM_DEPT_BY_EMP_ID(@EMP_REF_ID) B 
                                       ON (A.DEPT_REF_ID = B.DEPT_REF_ID) 
                               ORDER BY A.DEPT_REF_ID";

            string strORA = @"
                               
                            ";

            string query = @"
SELECT A.DEPT_REF_ID
      , A.DEPT_NAME  
      , CASE WHEN A.DEPT_REF_ID IS NULL THEN 0 ELSE 1 END TREE_NODE_TYPE
FROM COM_DEPT_INFO A JOIN  
             (SELECT DEPT_REF_ID FROM BSC_EMP_COM_DEPT_DETAIL WHERE EMP_REF_ID = @EMP_REF_ID ) B 
              ON (A.DEPT_REF_ID = B.DEPT_REF_ID)
ORDER BY A.DEPT_REF_ID ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(strSQL, strORA), "ESTTREE_TBL", null, paramArray, CommandType.Text);
            DataSet ds = DbAgentObj.FillDataSet(query, "ESTTREE_TBL", null, paramArray, CommandType.Text);
            return ds;
        }

        public bool AddDeptinfo(int up_est_dept_id, int dept_level, string dept_name, int estterm_ref_id)
        {
            /* 2011-06-13 수정 : sort order필드에 항상 마지막 sort order + 1의 값을 저장 
string s_query = @"
                    INSERT INTO EST_DEPT_INFO
                        (UP_EST_DEPT_ID,DEPT_LEVEL,DEPT_NAME,TEMP_FLAG,CREATE_DATE,DEPT_REF_ID,ESTTERM_REF_ID)
                    VALUES	
                        (@UP_EST_DEPT_ID,@DEPT_LEVEL,@DEPT_NAME,1,GETDATE(),NULL,@ESTTERM_REF_ID)
";

string o_query = @"
                    INSERT INTO	 EST_DEPT_INFO
                        (EST_DEPT_REF_ID,UP_EST_DEPT_ID,DEPT_LEVEL,DEPT_NAME,TEMP_FLAG,CREATE_DATE,DEPT_REF_ID,ESTTERM_REF_ID)
                    VALUES	
                        (SEQ_EST_DEPT_INFO.NEXTVAL,@UP_EST_DEPT_ID,@DEPT_LEVEL,@DEPT_NAME,1, SYSDATE,NULL,@ESTTERM_REF_ID)
";
/* 2011-06-13 수정 완료 *********************************************************************/



            string s_query = @"
                                INSERT INTO EST_DEPT_INFO
                                    (UP_EST_DEPT_ID,DEPT_LEVEL,DEPT_NAME,TEMP_FLAG,CREATE_DATE,DEPT_REF_ID,ESTTERM_REF_ID, SORT_ORDER)
                                VALUES	
                                    (@UP_EST_DEPT_ID,@DEPT_LEVEL,@DEPT_NAME,1,GETDATE(),NULL,@ESTTERM_REF_ID, @SORT_ORDER)
            ";

            string o_query = @"
                                INSERT INTO	 EST_DEPT_INFO
                                    (EST_DEPT_REF_ID,UP_EST_DEPT_ID,DEPT_LEVEL,DEPT_NAME,TEMP_FLAG,CREATE_DATE,DEPT_REF_ID,ESTTERM_REF_ID, SORT_ORDER)
                                VALUES	
                                    (SEQ_EST_DEPT_INFO.NEXTVAL,@UP_EST_DEPT_ID,@DEPT_LEVEL,@DEPT_NAME,1, SYSDATE,NULL,@ESTTERM_REF_ID, @SORT_ORDER)
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@UP_EST_DEPT_ID", SqlDbType.Int);
            paramArray[0].Value = up_est_dept_id;
            paramArray[1] = CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
            paramArray[1].Value = dept_level;
            paramArray[2] = CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar);
            paramArray[2].Value = dept_name;
            paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id;
            paramArray[4] = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[4].Value = 0;

            /* 2011-06-13 수정 : sort order필드에 항상 마지막 sort order + 1의 값을 저장 
            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /* 2011-06-13 수정 완료 *********************************************************************/

            /* 2011-06-13 수정 : sort order 필드에 항상 마지막 sort order + 1의 값을 저장 */
            string maxQuery = @"SELECT MAX(SORT_ORDER) +1 FROM EST_DEPT_INFO WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID";
            IDbDataParameter[] paramMaxArray = CreateDataParameters(1);
            paramMaxArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramMaxArray[0].Value = estterm_ref_id;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Object maxValueObject = DbAgentObj.ExecuteScalar(conn, trx, maxQuery, paramMaxArray, CommandType.Text);

                // sortOrder를 저장
                paramArray[4].Value = maxValueObject;
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(s_query, o_query), paramArray);

                trx.Commit();

                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                trx.Rollback();
                this.IERRMSG = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
            /* 2011-06-13 수정 완료 ********************************************************/
        }

        public bool RemoveDeptInfo(int est_term_ref_id,int est_dept_ref_id)
        {
//            string query = @"DELETE	EST_DEPT_INFO
//                                    WHERE	EST_DEPT_REF_ID = @EST_DEPT_REF_ID";
            string query = @" UPDATE EST_DEPT_INFO
                                 SET TEMP_FLAG = 0
                               WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                 AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = est_term_ref_id;
            paramArray[1]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                //throw new Exception("ERROR - EST_DEPT_INFO_REMOVE :  RemoveDeptinfo() \n" + ex.Message);
                return false;
            }
        }

        public bool RenameDeptName(int estterm_ref_id,int est_det_ref_id, string dept_name)
        {
            string query = @"UPDATE	EST_DEPT_INFO
                                SET	DEPT_NAME = @DEPT_NAME
                              WHERE	ESTTERM_REF_ID = @ESTTERM_REF_ID
                                AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_det_ref_id;
            paramArray[2] = CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar);
            paramArray[2].Value = dept_name;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RenameDeptName(int estterm_ref_id, int est_det_ref_id, string dept_name, int sortOrder)
        {
            string query = @"UPDATE	EST_DEPT_INFO
                                SET	DEPT_NAME = @DEPT_NAME
                                        , SORT_ORDER = @SORT_ORDER
                              WHERE	ESTTERM_REF_ID = @ESTTERM_REF_ID
                                AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_det_ref_id;
            paramArray[2] = CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar);
            paramArray[2].Value = dept_name;
            paramArray[3] = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[3].Value = sortOrder;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MoveDeptPath(int estterm_ref_id, int est_det_ref_id, int up_est_dept_id, int dept_level)
        {
            string query = @"UPDATE	EST_DEPT_INFO
                                SET	UP_EST_DEPT_ID  = @UP_EST_DEPT_ID
	                               ,DEPT_LEVEL      = @DEPT_LEVEL
                              WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_det_ref_id;
            paramArray[2] = CreateDataParameter("@UP_EST_DEPT_ID", SqlDbType.Int);
            paramArray[2].Value = up_est_dept_id;
            paramArray[3] = CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
            paramArray[3].Value = dept_level;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // [20070917]juny177추가 : 평가부서 맵트리에서 부서 선택시 선택된 부서의 레벨을 리턴한다.
        public string GetDeptpathSelectLevel(int est_det_ref_id, int est_term_ref_id)
        {
            string s_query = @"
                                SELECT 
                                    ISNULL(DEPT_LEVEL,0) AS LEVEL
                                FROM 
                                    EST_DEPT_INFO 
	                            WHERE 
                                    EST_DEPT_REF_ID = @EST_DEPT_REF_ID AND ESTTERM_REF_ID = @EST_TERM_REF_ID
            ";

            string o_query = @"
                                SELECT 
                                    NVL(DEPT_LEVEL,0)   
                                FROM 
                                    EST_DEPT_INFO 
	                            WHERE 
                                    EST_DEPT_REF_ID = @EST_DEPT_REF_ID  AND ESTTERM_REF_ID = @EST_TERM_REF_ID
                                    AND ROWNUM = 1
            ";
            
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = est_det_ref_id;
            paramArray[1] = CreateDataParameter("@EST_TERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_term_ref_id;

            return DbAgentObj.ExecuteScalar(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text).ToString();            
        }

        public bool MappingEstDept_Dept_ID(int estterm_ref_id, int est_dept_ref_id, int dept_ref_id, int est_dept_group_id)
        {
            string query = @"UPDATE	EST_DEPT_INFO
	                            SET	DEPT_REF_ID         = CASE WHEN @DEPT_REF_ID = 0 THEN NULL ELSE @DEPT_REF_ID END 
                                  , EST_DEPT_GROUP_ID   = @EST_DEPT_GROUP_ID
                                  , DEPT_TYPE           = (SELECT DEPT_TYPE FROM COM_DEPT_INFO WHERE DEPT_REF_ID = @DEPT_REF_ID)
                              WHERE ESTTERM_REF_ID      = @ESTTERM_REF_ID
                                AND EST_DEPT_REF_ID     = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@EST_DEPT_REF_ID"     , SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID"         , SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_DEPT_GROUP_ID"   , SqlDbType.Int);
            paramArray[3].Value = est_dept_group_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEstDeptLevel(int estterm_ref_id, int dept_level) 
        {
            string query = @"SELECT * FROM EST_DEPT_INFO
                                    WHERE DEPT_LEVEL        = @DEPT_LEVEL
		                                AND ESTTERM_REF_ID  = @ESTTERM_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@DEPT_LEVEL"    , SqlDbType.Int);
            paramArray[1].Value = dept_level;

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTINFOGETALL", null, paramArray, CommandType.Text);
            return ds;
        }
        public DataSet GetEstDeptGroups() 
        {
            string query = "SELECT * FROM EST_DEPT_GROUP_INFO";
            return DbAgentObj.FillDataSet(query, "Data", null, null, CommandType.Text);
        }

        // 2007.08.30 [juny177] SELECT 절 안에 펑션..  > 오라클용으로 처리해야함
        public string GetEstDeptName(int estterm_ref_id, int est_dept_ref_id) 
        {
            string query = "SELECT dbo.fn_GetEstDeptName(@ESTTERM_REF_ID, @EST_DEPT_REF_ID) AS EST_DEPT_NAME";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTINFOGETALL", null, paramArray, CommandType.Text);
            return ds.Tables[0].Rows[0]["EST_DEPT_NAME"].ToString();
        }

        public DataSet GetEstDeptStrategyBscChampionList(int iEstTermId, int iLogInID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S2";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iEstTermId;
            paramArray[2]       = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iLogInID;

            DataSet ds = DbAgentObj.FillDataSet("usp_EST_DEPT_INFO", "ESTTREE_TBL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public int GetRootEstDeptID(int estterm_ref_id) 
        {
            string query = @"SELECT EST_DEPT_REF_ID FROM EST_DEPT_INFO 
                                WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
                                      AND (UP_EST_DEPT_ID = 0 OR UP_EST_DEPT_ID IS NULL)  ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count  > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["EST_DEPT_REF_ID"]);

            return 0;
        }

        public DataSet GetEstDeptByStgMap(int estterm_ref_id)
        {
            string query = @"
                        SELECT ED.DEPT_NAME
                             , TA.EST_DEPT_REF_ID
                          FROM (SELECT ESTTERM_REF_ID
                                     , EST_DEPT_REF_ID
                                  FROM REL_STG_MAP
                                    GROUP BY ESTTERM_REF_ID
                                           , EST_DEPT_REF_ID
                               )  TA 
                        JOIN EST_DEPT_INFO  ED  ON      TA.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                                                  AND   TA.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                                                  AND   TA.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                        ORDER BY TA.EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);

            return ds;
        }

        // 2007.08.30 [juny177] FROM절 안에 펑션..  > 오라클용으로 처리해야함
        public DataSet GetEstDeptListByLevel(int estterm_ref_id)
        {
            string query = @"SELECT A.*
                                    , B.DEPT_NAME 
                                FROM    dbo.fn_GetEstDeptOppByLevel(@EST_DEPT_REF_ID) A
			                        JOIN EST_DEPT_INFO B ON A.EST_DEPT_REF_ID = B.EST_DEPT_REF_ID
                                        ORDER BY A.DEPT_LEVEL DESC";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DataSet", null, paramArray, CommandType.Text);

            return ds;
        }
    }
}
