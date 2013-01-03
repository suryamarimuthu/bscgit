using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class DeptInfos : DbAgentBase
    {
        public DeptInfos()
        {

        }

        public DeptInfos(int dept_ref_id)
        {
            DataSet ds = GetDeptInfo(dept_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _up_dept_id     = Convert.ToInt32(dr["UP_DEPT_ID"]);
                _dept_level     = Convert.ToInt32(dr["DEPT_LEVEL"]);
                _dept_name      = Convert.ToString(dr["DEPT_NAME"]);
                _create_date    = (DateTime)dr["CREATE_DATE"];
                //_create_emp_id  = (int)dr["CREATE_EMP_ID"];
                _dept_ref_id    = Convert.ToInt32(dr["DEPT_REF_ID"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private int _up_dept_id;
        private int _dept_level;
        private string _dept_name;
        private DateTime _create_date;
        private int _create_emp_id;
        private int _dept_ref_id;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public int Up_Dept_ID
        {
            get
            {
                return _up_dept_id;
            }
            set
            {
                _up_dept_id = value;
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

        public int Create_Emp_ID
        {
            get
            {
                return _create_emp_id;
            }
            set
            {
                _create_emp_id = value;
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
        #endregion

        // 2007.08.30 [juny177] 공통 쿼리 변경 사항 없음
        public bool ModifyDeptInfo(int up_dept_id, int dept_level, string dept_name, DateTime create_date, int create_emp_id, int dept_ref_id)
        {
            string query = @"UPDATE	COM_DEPT_INFO
                                SET	UP_DEPT_ID      = @UP_DEPT_ID
	                                ,DEPT_LEVEL     = @DEPT_LEVEL
                                WHERE	DEPT_REF_ID = @DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@UP_DEPT_ID", SqlDbType.Int);
            paramArray[0].Value         = up_dept_id;
            paramArray[1]               = CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
            paramArray[1].Value         = dept_level;
            paramArray[2]               = CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = dept_name;
            paramArray[3]               = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[3].Value         = create_date;
            paramArray[4]               = CreateDataParameter("@CREATE_EMP_ID", SqlDbType.Int);
            paramArray[4].Value         = create_emp_id;
            paramArray[5]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = dept_ref_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 2007.08.30 [juny177] 공통 쿼리 변경 사항 없음
        public DataSet GetDeptInfo(int dept_ref_id)
        {
            string query = @"SELECT	UP_DEPT_ID
	                            ,DEPT_LEVEL
	                            ,DEPT_NAME
	                            ,CREATE_DATE
	                            ,DEPT_REF_ID
	                            ,DEPT_CODE
	                            ,DEPT_FLAG
                            FROM	COM_DEPT_INFO 
                            WHERE	DEPT_REF_ID = @DEPT_REF_ID
	                            AND DEPT_FLAG = 1";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        // 2007.08.30 [juny177] 공통 쿼리 변경 사항 없음
        public DataSet GetAllDeptInfo()
        {
            string query = @"SELECT	UP_DEPT_ID
	                                ,DEPT_LEVEL
	                                ,DEPT_NAME
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,DEPT_REF_ID
	                                ,DEPT_CODE
	                                ,DEPT_FLAG
                                FROM	COM_DEPT_INFO 
                                    WHERE 	DEPT_FLAG = 1
                                    ORDER BY UP_DEPT_ID, DEPT_LEVEL";

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTINFOGETALL", null, null, CommandType.Text);
            return ds;
        }

        // 2007.08.30 [juny177] 공통 쿼리 변경 사항 없음
        public bool AddDeptInfo(int up_dept_id, int dept_level, string dept_name, DateTime create_date, int create_emp_id)
        {
            string query = @"INSERT INTO COM_DEPT_INFO(UP_DEPT_ID
			                                            ,DEPT_LEVEL
			                                            ,DEPT_NAME
			                                            ,CREATE_DATE
			                                            ,CREATE_EMP_ID
			                                            ,DEPT_CODE
			                                            ,DEPT_FLAG
			                                            )
		                                            VALUES	(@UP_DEPT_ID
			                                            ,@DEPT_LEVEL
			                                            ,@DEPT_NAME
			                                            ,@CREATE_DATE
			                                            ,@CREATE_EMP_ID
			                                            ,''
			                                            ,1
			                                            )
                                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@UP_DEPT_ID", SqlDbType.Int);
            paramArray[0].Value         = up_dept_id;
            paramArray[1]               = CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
            paramArray[1].Value         = dept_level;
            paramArray[2]               = CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = dept_name;
            paramArray[3]               = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[3].Value         = create_date;
            paramArray[4]               = CreateDataParameter("@CREATE_EMP_ID", SqlDbType.Int);
            paramArray[4].Value         = create_emp_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 2007.08.30 [juny177] 사용 안함
        public string GetDeptpath( int dept_ref_id, ref int dept_level)
        {
            string query = @"DECLARE @DEPT_LEVEL int
                            DECLARE @T_DEPT_NAME varchar(200)
                            DECLARE @STR varchar(20)
                            SET @T_DEPT_NAME = ''

                            SELECT @DEPT_LEVEL=DEPT_LEVEL FROM COM_DEPT_INFO 
	                            WHERE DEPT_REF_ID = @DEPT_REF_ID AND DEPT_FLAG = 1

                            SET @LEVEL= @DEPT_LEVEL

                            WHILE @DEPT_LEVEL > 1 
                            BEGIN
	                            SELECT @STR=A.DEPT_NAME, @DEPT_REF_ID=B.DEPT_REF_ID, @DEPT_LEVEL=B.DEPT_LEVEL FROM COM_DEPT_INFO A 
		                            JOIN COM_DEPT_INFO B ON A.UP_DEPT_ID=B.DEPT_REF_ID 
			                            WHERE A.DEPT_REF_ID = @DEPT_REF_ID AND A.DEPT_FLAG = 1

	                            SET @T_DEPT_NAME = @STR  + '/' +@T_DEPT_NAME
                            END


                            SET @RValue = '/' + (SELECT DEPT_NAME FROM COM_DEPT_INFO WHERE DEPT_LEVEL = 1  AND DEPT_FLAG = 1) 
		                            + '/' + @T_DEPT_NAME";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[0].Value         = dept_ref_id;
	        paramArray[1] 		        = CreateDataParameter("@LEVEL", SqlDbType.Int);
	        paramArray[1].Direction     = ParameterDirection.Output ;
	        paramArray[2] 		        = CreateDataParameter("@RValue", SqlDbType.VarChar);
	        paramArray[2].Direction     = ParameterDirection.Output ;
         
	        IDataParameterCollection col;
         
	        try
	        {
		        int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text, out col);
                dept_level              = (int)GetOutputParameterValue(col, "@LEVEL");
                return GetOutputParameterValue(col, "@RValue").ToString();
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }

        // 2007.08.30 [juny177] ORACLE 쿼리 추가
        public bool RemoveDeptinfo(int dept_ref_id)
        {
            string s_query = @"
	                            UPDATE	
                                    COM_DEPT_INFO
		                        SET	
                                    DEPT_FLAG = 0
		                        WHERE	
                                    DEPT_REF_ID = @DEPT_REF_ID
                                    AND (SELECT ISNULL(COUNT(*),0) FROM REL_DEPT_EMP
	                                    WHERE DEPT_REF_ID = @DEPT_REF_ID )= 0
	        ";


            string o_query = @"
	                            UPDATE	
                                    COM_DEPT_INFO
		                        SET	
                                    DEPT_FLAG = 0
		                        WHERE	
                                    DEPT_REF_ID = @DEPT_REF_ID
                                    AND (SELECT NVL(COUNT(*),0) FROM REL_DEPT_EMP
	                                    WHERE DEPT_REF_ID = @DEPT_REF_ID )= 0
                        ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = dept_ref_id;

            int affectedRow = 0;
            try
            {
                affectedRow         = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (affectedRow == 1)?true:false;
        }

        // 2007.08.30 [juny177] 공통 쿼리 변경 사항 없음
        public bool RenameDeptName(int dept_ref_id, string dept_name)
        {
            string query = @"UPDATE	COM_DEPT_INFO
                                SET	DEPT_NAME           = @DEPT_NAME
                                    WHERE	DEPT_REF_ID = @DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = dept_ref_id;
            paramArray[1]               = CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = dept_name;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 2007.08.30 [juny177] 공통 쿼리 변경 사항 없음
        public bool MoveDeptPath(int dept_ref_id, int up_dept_id, int dept_level)
        {
            string query = @"UPDATE	COM_DEPT_INFO
                                SET	UP_DEPT_ID      = @UP_DEPT_ID
	                                ,DEPT_LEVEL     = @DEPT_LEVEL
                                WHERE	DEPT_REF_ID = @DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = dept_ref_id;
            paramArray[1]               = CreateDataParameter("@UP_DEPT_ID", SqlDbType.Int);
            paramArray[1].Value         = up_dept_id;
            paramArray[2]               = CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
            paramArray[2].Value         = dept_level;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex
;
            }
        }

        // 2007.08.30 [juny177] 공통 쿼리 변경 사항 없음
        public DataSet GetMenuDeptInfo()
        {
            string query = @"   SELECT DEPT_REF_ID
                                      ,UP_DEPT_ID
                                      ,DEPT_LEVEL
                                      ,DEPT_NAME
                                      ,DEPT_CODE
                                      ,DEPT_FLAG
                                      ,DEPT_TYPE
                                      ,SORT_ORDER
                                      ,DEPT_DESC
                                      ,CREATE_USER
                                      ,CREATE_DATE
                                      ,UPDATE_USER
                                      ,UPDATE_DATE
                                  FROM COM_DEPT_INFO
	                                ORDER BY UP_DEPT_ID, SORT_ORDER";

            DataSet ds = DbAgentObj.FillDataSet(query, "Data", null, null, CommandType.Text);
            return ds;
        }
    }
}
