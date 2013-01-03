using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Syncfusion.Calculate;

using MicroBSC.Estimation.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_BiasDatas
    {
        private Dac_Datas       _data       = new Dac_Datas();
        private Dac_EstInfos    _estInfo    = new Dac_EstInfos();
        private Dac_BiasDatas   _biasData   = new Dac_BiasDatas();

        public string errMSG = string.Empty;

        public Biz_BiasDatas()
        {
            
        }

        /*
         
        DECLARE @ROWCOUNT 			int
        DECLARE @I					int
        DECLARE @EST_EMP_ID			int
        DECLARE @EST_TYPE			int

        DECLARE @전사평균			float
        DECLARE @평가자평균			float

        SET @EST_TYPE = 2

        --DROP TABLE #T

        SELECT IDENTITY(int, 1, 1) 'IDX'
		        , A.EST_EMP_ID, B.EMP_NAME AS EST_EMP_NAME
		        , ROUND(MAX(A.POINT_ORG),2) 	'최대값'
		        , ROUND(MIN(A.POINT_ORG),2) 	'최소값'
		        , COUNT(A.TARGET_EMP_ID) 		'갯수'
		        , ROUND(AVG(A.POINT_ORG),2) 	'평가자평균'
		        , 100000.00						'전사평균'
	        INTO #T FROM EST_ABL_REL_EMP	A
				        , COM_EMP_INFO		B
	        WHERE		A.EST_EMP_ID		= B.EMP_REF_ID
			        AND A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
			        AND A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
			        --AND A.ABL_STEP			= @ABL_STEP
			        AND A.EST_TYPE			= @EST_TYPE
			        AND A.STATUS			= 'E'
			        AND A.EST_TYPE			= 2
	        GROUP BY A.EST_EMP_ID, B.EMP_NAME

        --SELECT * FROM #T

        UPDATE #T SET 전사평균 = (SELECT ISNULL(ROUND(AVG(POINT_ORG),2), 0) 
									        FROM EST_ABL_REL_EMP 
										        WHERE	ESTTERM_REF_ID  		= @ESTTERM_REF_ID
												        AND ESTTERM_SUB_ID		= @ESTTERM_SUB_ID
												        AND EST_TYPE			= @EST_TYPE
												        AND STATUS				= 'E')

        SELECT @ROWCOUNT = COUNT(*) FROM #T
        SET @I = 1

        WHILE @I <= @ROWCOUNT
        BEGIN
         
	        SELECT @EST_EMP_ID = EST_EMP_ID
			        , @전사평균=전사평균
			        , @평가자평균 = 평가자평균 
		        FROM #T WHERE IDX=@I

	        UPDATE EST_ABL_REL_EMP 
		        SET POINT_1 = (CONVERT(float,POINT_ORG) / @평가자평균) * @전사평균
			        FROM EST_ABL_REL_EMP A, COM_EMP_INFO B
				        WHERE 		A.EST_EMP_ID		= B.EMP_REF_ID
						        AND A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
						        AND A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
						        --AND A.ABL_STEP			= @ABL_STEP
						        AND A.EST_EMP_ID		= @EST_EMP_ID
						        AND A.EST_TYPE			= @EST_TYPE
						        AND A.STATUS			= 'E'
						        AND A.EST_TYPE			= 2
         
	        SET @I = @I + 1	
        END
        
        */


        public bool SetBiasAvg(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string year_yn
                            , string merge_yn
                            , OwnerType ownerType
                            , string dept_values
                            , DateTime update_date
                            , int update_user) 
        {
            int affectedRow = 0;

            IDbConnection conn  = DbAgentHelper.CreateDbConnection();
            conn.Open();
            
            //IDbTransaction trx  = conn.BeginTransaction();
            DataTable dtNmlData;
            using (IDbTransaction trx = conn.BeginTransaction())
            {
                dtNmlData = _data.Select(conn
                                                  , trx
                                                  , comp_id
                                                  , est_id
                                                  , estterm_ref_id
                                                  , estterm_sub_id
                                                  , estterm_step_id
                                                  , 0
                                                  , 0
                                                  , 0
                                                  , 0
                                                  , year_yn
                                                  , merge_yn
                                                  , ownerType).Tables[0];
            }

            if(!dept_values.Trim().Equals(""))
                dtNmlData = DataTypeUtility.FilterSortDataTable(dtNmlData, string.Format("TGT_DEPT_ID IN ({0})", dept_values));

            double ttl_avg      = 0;
            
            ttl_avg             = DataTypeUtility.GetToDouble(dtNmlData.Compute("AVG(POINT_ORG)", ""));

            using (IDbTransaction trx = conn.BeginTransaction())
            {
                foreach (DataRow dataRow in dtNmlData.Rows)
                {
                    double est_avg = 0;

                    est_avg = DataTypeUtility.GetToDouble(dtNmlData.Compute("AVG(POINT_ORG)", string.Format("EST_EMP_ID = {0}", dataRow["EST_EMP_ID"])));

                    if (est_avg == 0)
                        continue;

                    //(CONVERT(float,POINT_ORG) / @평가자평균) * @전사평균

                    affectedRow += _data.Update(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                            , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                            , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                            , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , (DataTypeUtility.GetToDouble(dataRow["POINT_ORG"]) / est_avg) * ttl_avg
                                            , update_date
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , update_date
                                            , update_user);
                }
                if (affectedRow > 0)
                    trx.Commit();
            }

            return (affectedRow > 0) ? true : false;
            
        }


        /*
            DECLARE @ROWCOUNT 			int
            DECLARE @I					int
            DECLARE @EST_EMP_ID			int
            DECLARE @EST_TYPE			int

            DECLARE @전사평균			float
            DECLARE @전사표준편차		float
            DECLARE @평가자평균			float
            DECLARE @평가자표준편차		float

            SET @EST_TYPE = 2

            SELECT IDENTITY(int, 1, 1) 'IDX'
		            , A.EST_EMP_ID, B.EMP_NAME AS EST_EMP_NAME
		            , ROUND(MAX(A.POINT_ORG),2) 	'최대값'
		            , ROUND(MIN(A.POINT_ORG),2) 	'최소값'
		            , COUNT(A.TARGET_EMP_ID) 		'갯수'
		            , ROUND(AVG(A.POINT_ORG),2) 	'평가자평균'
		            , CASE WHEN ISNULL(ROUND(STDEV(A.POINT_ORG),2), 1) = 0 THEN 1 ELSE ISNULL(ROUND(STDEV(A.POINT_ORG),2), 1) END	'평가자표준편차'
		            , 100000.00						'전사평균'
		            , 100000.00						'전사표준편차'
	            INTO #T FROM EST_ABL_REL_EMP A
				            , COM_EMP_INFO B
	            WHERE		A.EST_EMP_ID		= B.EMP_REF_ID
			            AND A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
			            AND A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
			            --AND A.ABL_STEP			= @ABL_STEP
			            AND A.EST_TYPE			= @EST_TYPE
			            AND A.STATUS			= 'E'
			            AND A.EST_TYPE			= 2
	            GROUP BY A.EST_EMP_ID, B.EMP_NAME

            --SELECT * FROM #T

            --UPDATE #T SET 전사평균 = (SELECT AVG(평가자평균) '전사평균' FROM #T), 전사표준편차 = (SELECT STDEV(평가자평균) '전사표준편차' FROM #T)

            UPDATE #T SET 전사평균 		= (SELECT ISNULL(ROUND(AVG(POINT_ORG),2), 0) 
									            FROM EST_ABL_REL_EMP 
										            WHERE	ESTTERM_REF_ID  		= @ESTTERM_REF_ID
												            AND ESTTERM_SUB_ID		= @ESTTERM_SUB_ID
												            AND EST_TYPE			= @EST_TYPE
												            AND STATUS				= 'E')
			            , 전사표준편차 	= (SELECT ISNULL(ROUND(STDEV(POINT_ORG),2), 1) 
									            FROM EST_ABL_REL_EMP 
										            WHERE	ESTTERM_REF_ID  		= @ESTTERM_REF_ID
												            AND ESTTERM_SUB_ID		= @ESTTERM_SUB_ID
												            AND EST_TYPE			= @EST_TYPE
												            AND STATUS				= 'E')

            SELECT @ROWCOUNT = COUNT(*) FROM #T
            SET @I = 1


            WHILE @I <= @ROWCOUNT
            BEGIN
	            SELECT @EST_EMP_ID = EST_EMP_ID, @전사평균=전사평균, @전사표준편차=전사표준편차, @평가자평균 = 평가자평균, @평가자표준편차 = 평가자표준편차 FROM #T WHERE IDX=@I

	            UPDATE EST_ABL_REL_EMP SET POINT_2 = ((POINT_ORG - @평가자평균) / @평가자표준편차 * @전사표준편차) + @전사평균
		            FROM EST_ABL_REL_EMP A, COM_EMP_INFO B
			            WHERE 	A.EST_EMP_ID		= B.EMP_REF_ID
				            AND A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
				            AND A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
				            --AND A.ABL_STEP			= @ABL_STEP
				            AND A.EST_EMP_ID		= @EST_EMP_ID
				            AND A.EST_TYPE			= @EST_TYPE
				            AND A.STATUS			= 'E'
				            AND A.EST_TYPE			= 2

	            SET @I = @I + 1	
            END
         */

        public bool SetBiasSTDev( int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string year_yn
                                , string merge_yn
                                , OwnerType ownerType
                                , string dept_values
                                , DateTime update_date
                                , int update_user) 
        {
            int affectedRow = 0;

            IDbConnection conn  = DbAgentHelper.CreateDbConnection();
            conn.Open();
            //IDbTransaction trx  = conn.BeginTransaction();
            DataTable dtNmlData;
            using (IDbTransaction trx = conn.BeginTransaction())
            {
                dtNmlData = _data.Select(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , year_yn
                                                    , merge_yn
                                                    , ownerType).Tables[0];
            }
            if(!dept_values.Trim().Equals(""))
                dtNmlData = DataTypeUtility.FilterSortDataTable(dtNmlData, string.Format("TGT_DEPT_ID IN ({0})", dept_values));

            double ttl_avg      = 0;
            double ttl_std      = 0;
            
            ttl_avg             = DataTypeUtility.GetToDouble(dtNmlData.Compute("AVG(POINT_ORG)", ""));

            if(dtNmlData.Rows.Count > 1)
                ttl_std         = DataTypeUtility.GetToDouble(dtNmlData.Compute("STDEV(POINT_ORG)", ""));
            else 
                ttl_std         = 1;

            double test = 0;

            //try
            //{
            using (IDbTransaction trx = conn.BeginTransaction())
            {
                foreach (DataRow dataRow in dtNmlData.Rows)
                {
                    double est_avg = 0;
                    double est_std = 0;

                    est_avg = DataTypeUtility.GetToDouble(dtNmlData.Compute("AVG(POINT_ORG)", string.Format("EST_EMP_ID = {0}", dataRow["EST_EMP_ID"])));

                    if (est_avg == 0)
                        continue;

                    if (dtNmlData.Select(string.Format("EST_EMP_ID = {0}", dataRow["EST_EMP_ID"])).Length > 1)
                        est_std = DataTypeUtility.GetToDouble(dtNmlData.Compute("STDEV(POINT_ORG)", string.Format("EST_EMP_ID = {0}", dataRow["EST_EMP_ID"])));
                    else
                        est_std = 1;

                    //((POINT_ORG - @평가자평균) / @평가자표준편차 * @전사표준편차) + @전사평균


                    test = ((DataTypeUtility.GetToDouble(dataRow["POINT_ORG"]) - est_avg) / est_std * ttl_std) + ttl_avg;

                    if (test.Equals(double.NaN) == true)
                    {
                        test = 0.0;
                    }
                    /* 2011-08-01 수정 시작 : test의 값이 NaN인 경우 스트링 비교가 아니라 double.NaN으로 비교하도록 수정
                    if(test.Equals("NaN"))
                        System.Diagnostics.Debugger.Break();
                    */

                    affectedRow += _data.Update(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                            , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                            , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                            , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , test
                                            , update_date
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , update_date
                                            , update_user);
                }
                if (affectedRow > 0)
                    trx.Commit();
            }
            //    trx.Commit();
            //}
            //catch ( Exception ex )
            //{
            //    trx.Rollback();
            //    return false;
            //}
            //finally
            //{
            //    conn.Close();
            //}

            return (affectedRow > 0) ? true : false;
        }

        public bool SetBiasType(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string bias_type_id
                            , string dept_value
                            , DateTime update_date
                            , int update_user) 
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

	        int affectedRow = 0;

			try
			{
				affectedRow += _data.UpdateConfirmBias(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , bias_type_id
                                                    , dept_value
                                                    , update_date
                                                    , update_user);

                affectedRow += _estInfo.Update(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , bias_type_id
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , update_date
                                                , update_user);

				trx.Commit();
			}
			catch ( Exception e )
			{
				trx.Rollback();
				return false;
			}
            finally 
            {
                conn.Close();
            }

            return ( affectedRow > 0 ) ? true : false;
        }

        /// <summary>
        /// Bias 그룹별 대상현황 엑셀다운로드용
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <returns></returns>
        public DataTable GetBiasGroupEmpList(int comp_id, string est_id, int estterm_ref_id)
        {
            return _biasData.GetBiasGroupEmpList(comp_id, est_id, estterm_ref_id);
        }

        public DataTable GetBiasData(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, int estterm_step_id, int bias_grp_id)
        {
            return _biasData.GetBiasData(comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, bias_grp_id);
        }

        /// <summary>
        /// 그룹현황
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <returns></returns>
        public DataTable GetBiasGroup(int comp_id
                                        , string est_id
                                        , string use_yn)
        {
            return _biasData.GetBiasGroup(comp_id, est_id, use_yn);
        }

        public bool InsertBiasData(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, int estterm_step_id, int bias_grp_id, DataTable insertDT, int reg_user)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                int rtnCnt = _biasData.DeleteBiasData(conn, trx, comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, bias_grp_id);
                rtnValue = _biasData.InsertBiasData(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , bias_grp_id
                                                , insertDT
                                                , reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                errMSG = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        /// <summary>
        /// 바이어스그룹 사원 매핑(삭제후 insert)
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="bias_grp_id"></param>
        /// <param name="insertDT"></param>
        /// <returns></returns>
        public bool InsertBiasGroupEmp(int comp_id, string est_id, int estterm_ref_id, int bias_grp_id, DataTable insertDT, int reg_user)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                int rtnCnt = _biasData.DeleteBiasGroupEmp(conn, trx, comp_id, est_id, estterm_ref_id, bias_grp_id);
                rtnValue = _biasData.InsertBiasGroupEmp(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , bias_grp_id
                                                , insertDT
                                                , reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                errMSG = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        /// <summary>
        /// Bias 그룹에 매핑할(매핑된사용자포함) 부서+사원 트리
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="bias_grp_id"></param>
        /// <returns></returns>
        public DataSet GetBiasGroupEmp(int comp_id, string est_id, int estterm_ref_id, int bias_grp_id)
        {
            return _biasData.GetBiasGroupEmp(comp_id, est_id, estterm_ref_id, bias_grp_id);
        }

        public DataTable CalcBiasData(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, int estterm_step_id, int bias_grp_id, string selectQuery, string joinQuery)
        {
            return _biasData.CalcBiasData(comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, bias_grp_id, selectQuery, joinQuery);
        }

        /// <summary>
        /// Bias 컬럼정보 조회
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <returns></returns>
        public DataTable GetBiasColumns(int comp_id, string est_id, string visible_yn, string use_yn)
        {
            return _biasData.GetBiasColumns(comp_id, est_id, visible_yn, use_yn);
        }

        /// <summary>
        /// 그룹대상요약현황
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <returns></returns>
        public DataTable GetBiasGroupEmpCount(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , string use_yn)
        {
            return _biasData.GetBiasGroupEmpCount(comp_id, est_id, estterm_ref_id, use_yn);
        }

        /// <summary>
        /// Bias 컬럼 기본정보 입력
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="reg_user"></param>
        /// <returns></returns>
        public bool InsertInitBiasColumnData(int comp_id, string est_id, int reg_user)
        {
            bool rtnValue = false;
            errMSG = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _biasData.InsertInitBiasColumnData(conn, trx, comp_id, est_id, reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                errMSG = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        /// <summary>
        /// 그룹삭제
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="bias_grp_id"></param>
        /// <returns></returns>
        public bool DeleteBiasGroup(int comp_id
                                    , string est_id
                                    , int bias_grp_id)
        {
            bool rtnValue = false;
            errMSG = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _biasData.DeleteBiasGroup(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , bias_grp_id);
                if (!rtnValue)
                {
                    errMSG = _biasData.rtnMSG;
                    trx.Rollback();
                }
                else
                    trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                errMSG = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        public bool ConfirmBiasPoint(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int bias_grp_id
                                    , int reg_user)
        {
            bool rtnValue = false;
            errMSG = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _biasData.ConfirmBiasPoint(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , bias_grp_id
                                                    , reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                errMSG = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        public bool UpdateBiasPoint(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int bias_grp_id
                                    , string bias_apply_column
                                    , int reg_user)
        {
            bool rtnValue = false;
            errMSG = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _biasData.UpdateBiasPoint(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , bias_grp_id
                                                    , bias_apply_column
                                                    , reg_user);

                if (rtnValue)
                {
                    if (rtnValue = _biasData.ConfirmBiasPoint(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , bias_grp_id
                                                    , reg_user))
                        trx.Commit();
                    else
                        trx.Rollback();
                }
                else
                    trx.Rollback();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                errMSG = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        public bool UpdateBiasColumn(int comp_id
                                    , string est_id
                                    , int seq
                                    , string visible_yn
                                    , int col_order
                                    , string col_key
                                    , string col_name
                                    , string col_desc
                                    , string col_type
                                    , int col_width
                                    , string col_align
                                    , string data_type
                                    , string proc_name
                                    , string proc_type
                                    , string use_yn
                                    , int reg_user)
        {
            bool rtnValue = false;
            errMSG = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _biasData.UpdateBiasColumn(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , seq
                                                    , visible_yn
                                                    , col_order
                                                    , col_key
                                                    , col_name
                                                    , col_desc
                                                    , col_type
                                                    , col_width
                                                    , col_align
                                                    , data_type
                                                    , proc_name
                                                    , proc_type
                                                    , use_yn
                                                    , reg_user);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                errMSG = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        /// <summary>
        /// 그룹저장
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="bias_grp_id"></param>
        /// <param name="bias_grp_cd"></param>
        /// <param name="bias_grp_nm"></param>
        /// <param name="bias_grp_desc"></param>
        /// <param name="use_yn"></param>
        /// <param name="reg_emp_id"></param>
        /// <returns></returns>
        public int SaveBiasGroup(int comp_id
                                    , string est_id
                                    , int bias_grp_id
                                    , string bias_grp_cd
                                    , string bias_grp_nm
                                    , string bias_grp_desc
                                    , string use_yn
                                    , int reg_emp_id)
        {
            int rtnValue = 0;
            errMSG = "";
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _biasData.SaveBiasGroup(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , bias_grp_id
                                                , bias_grp_cd
                                                , bias_grp_nm
                                                , bias_grp_desc
                                                , use_yn
                                                , reg_emp_id);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                errMSG = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }
    }
}
