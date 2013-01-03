using System;
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
    public class Dac_ColumnInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int seq
                        , string col_name
                        , string col_style_id
                        , string col_key
                        , string caption
                        , int width
                        , string data_type
                        , string halign
                        , string back_color
                        , string format
                        , string formula
                        , string default_value
                        , string col_desc
                        , string back_color_yn
                        , string format_yn
                        , string formula_yn
                        , string default_value_yn
                        , string visible_yn
                        , string col_emp_visible_yn
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_COLUMN_INFO
	                            SET	 COL_NAME                       = @COL_NAME
		                            ,COL_STYLE_ID                   = @COL_STYLE_ID
		                            ,SEQ                            = @SEQ
		                            ,CAPTION                        = @CAPTION
		                            ,WIDTH                          = @WIDTH
		                            ,DATA_TYPE                      = @DATA_TYPE
		                            ,HALIGN                         = @HALIGN
		                            ,BACK_COLOR                     = @BACK_COLOR
		                            ,FORMAT                         = @FORMAT
		                            ,FORMULA                        = @FORMULA
                                    ,DEFAULT_VALUE                  = @DEFAULT_VALUE
		                            ,COL_DESC                       = @COL_DESC
		                            ,BACK_COLOR_YN                  = @BACK_COLOR_YN
		                            ,FORMAT_YN                      = @FORMAT_YN
		                            ,FORMULA_YN                     = @FORMULA_YN
                                    ,DEFAULT_VALUE_YN               = @DEFAULT_VALUE_YN
		                            ,VISIBLE_YN                     = @VISIBLE_YN
                                    ,COL_EMP_VISIBLE_YN             = @COL_EMP_VISIBLE_YN
		                            ,UPDATE_DATE                    = @UPDATE_DATE
		                            ,UPDATE_USER                    = @UPDATE_USER
	                            WHERE	COMP_ID                     = @COMP_ID
                                    AND EST_ID                      = @EST_ID
	                                AND	COL_KEY                     = @COL_KEY";

            IDbDataParameter[] paramArray = CreateDataParameters(23);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[2].Value     = seq;
            paramArray[3]           = CreateDataParameter("@COL_NAME", SqlDbType.NVarChar, 200);
            paramArray[3].Value     = col_name;
            paramArray[4]           = CreateDataParameter("@COL_STYLE_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value     = col_style_id;
            paramArray[5]           = CreateDataParameter("@COL_KEY", SqlDbType.NVarChar, 200);
            paramArray[5].Value     = col_key;
            paramArray[6]           = CreateDataParameter("@CAPTION", SqlDbType.NVarChar, 200);
            paramArray[6].Value     = caption;
            paramArray[7]           = CreateDataParameter("@WIDTH", SqlDbType.Int);
            paramArray[7].Value     = width;
            paramArray[8]           = CreateDataParameter("@DATA_TYPE", SqlDbType.NVarChar, 200);
            paramArray[8].Value     = data_type;
            paramArray[9]           = CreateDataParameter("@HALIGN", SqlDbType.NVarChar, 20);
            paramArray[9].Value     = halign;
            paramArray[10]          = CreateDataParameter("@BACK_COLOR", SqlDbType.NVarChar, 100);
            paramArray[10].Value    = back_color;
            paramArray[11]          = CreateDataParameter("@FORMAT", SqlDbType.NVarChar, 200);
            paramArray[11].Value    = format;
            paramArray[12]          = CreateDataParameter("@FORMULA", SqlDbType.NVarChar, 200);
            paramArray[12].Value    = formula;
            paramArray[13]          = CreateDataParameter("@DEFAULT_VALUE", SqlDbType.NVarChar);
            paramArray[13].Value    = default_value;
            paramArray[14]          = CreateDataParameter("@COL_DESC", SqlDbType.NVarChar, 2000);
            paramArray[14].Value    = col_desc;
            paramArray[15]          = CreateDataParameter("@BACK_COLOR_YN", SqlDbType.NChar);
            paramArray[15].Value    = back_color_yn;
            paramArray[16]          = CreateDataParameter("@FORMAT_YN", SqlDbType.NChar);
            paramArray[16].Value    = format_yn;
            paramArray[17]          = CreateDataParameter("@FORMULA_YN", SqlDbType.NChar);
            paramArray[17].Value    = formula_yn;
            paramArray[18]          = CreateDataParameter("@DEFAULT_VALUE_YN", SqlDbType.NChar);
            paramArray[18].Value    = default_value_yn;
            paramArray[19]          = CreateDataParameter("@VISIBLE_YN", SqlDbType.NChar);
            paramArray[19].Value    = visible_yn;
            paramArray[20]          = CreateDataParameter("@COL_EMP_VISIBLE_YN", SqlDbType.NChar);
            paramArray[20].Value    = col_emp_visible_yn;
            paramArray[21]          = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[21].Value    = update_date;
            paramArray[22]          = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[22].Value    = update_user;

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

        public DataSet Select(int comp_id, string est_id, string col_key, string visible_yn)
        {
            string query = @"
SELECT	 CI.COMP_ID
        ,CI.EST_ID
        ,CI.SEQ
        ,CI.COL_NAME
        ,CI.COL_STYLE_ID
        ,CS.COL_STYLE_NAME
        ,CI.COL_KEY
        ,CI.CAPTION
        ,CI.WIDTH
        ,CI.DATA_TYPE
        ,CI.HALIGN
        ,CI.BACK_COLOR
        ,CI.FORMAT
        ,CI.FORMULA
        ,CI.DEFAUlT_VALUE
        ,CI.COL_DESC
        ,CI.BACK_COLOR_YN
        ,CI.FORMAT_YN
        ,CI.FORMULA_YN
        ,CI.DEFAULT_VALUE_YN
        ,CI.VISIBLE_YN
        ,CI.COL_EMP_VISIBLE_YN
        ,CI.CREATE_DATE
        ,CI.CREATE_USER
        ,CI.UPDATE_DATE
        ,CI.UPDATE_USER
    FROM	    EST_COLUMN_INFO  CI
        JOIN    EST_COLUMN_STYLE CS     ON  (    CI.COL_STYLE_ID     =   CS.COL_STYLE_ID     )
    WHERE
            (   CI.COMP_ID    =     @COMP_ID      OR    @COMP_ID     =      0)
        AND (   CI.EST_ID     =     @EST_ID       OR    @EST_ID      ='')
        AND	(   CI.COL_KEY    =     @COL_KEY      OR    @COL_KEY     ='')
        AND (   CI.VISIBLE_YN =     @VISIBLE_YN   OR    @VISIBLE_YN  ='')
    ORDER BY
        CI.SEQ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@COL_KEY", SqlDbType.NVarChar, 100);
            paramArray[2].Value     = col_key;
            paramArray[3]           = CreateDataParameter("@VISIBLE_YN", SqlDbType.NVarChar);
            paramArray[3].Value     = visible_yn;

            DataSet ds = DbAgentObj.FillDataSet(query, "COLUMNINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int seq
                        , string col_name
                        , string col_style_id
                        , string col_key
                        , string caption
                        , int width
                        , string data_type
                        , string halign
                        , string back_color
                        , string format
                        , string formula
                        , string default_value
                        , string col_desc
                        , string back_color_yn
                        , string format_yn
                        , string formula_yn
                        , string default_value_yn
                        , string visible_yn
                        , string col_emp_visible_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_COLUMN_INFO(COMP_ID
                                                        ,EST_ID
			                                            ,SEQ
			                                            ,COL_NAME
			                                            ,COL_STYLE_ID
			                                            ,COL_KEY
			                                            ,CAPTION
			                                            ,WIDTH
			                                            ,DATA_TYPE
			                                            ,HALIGN
			                                            ,BACK_COLOR
			                                            ,FORMAT
			                                            ,FORMULA
                                                        ,DEFAULT_VALUE
			                                            ,COL_DESC
			                                            ,BACK_COLOR_YN
			                                            ,FORMAT_YN
			                                            ,FORMULA_YN
                                                        ,DEFAULT_VALUE_YN
			                                            ,VISIBLE_YN
                                                        ,COL_EMP_VISIBLE_YN
			                                            ,CREATE_DATE
			                                            ,CREATE_USER
			                                            ,UPDATE_DATE
			                                            ,UPDATE_USER
			                                            )
		                                            VALUES	(@COMP_ID
                                                        ,@EST_ID
			                                            ,@SEQ
			                                            ,@COL_NAME
			                                            ,@COL_STYLE_ID
			                                            ,@COL_KEY
			                                            ,@CAPTION
			                                            ,@WIDTH
			                                            ,@DATA_TYPE
			                                            ,@HALIGN
			                                            ,@BACK_COLOR
			                                            ,@FORMAT
			                                            ,@FORMULA
                                                        ,@DEFAULT_VALUE
			                                            ,@COL_DESC
			                                            ,@BACK_COLOR_YN
			                                            ,@FORMAT_YN
			                                            ,@FORMULA_YN
                                                        ,@DEFAULT_VALUE_YN
			                                            ,@VISIBLE_YN
                                                        ,@COL_EMP_VISIBLE_YN
			                                            ,@CREATE_DATE
			                                            ,@CREATE_USER
			                                            ,NULL
			                                            ,NULL
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(23);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[2].Value     = seq;
            paramArray[3]           = CreateDataParameter("@COL_NAME", SqlDbType.NVarChar, 200);
            paramArray[3].Value     = col_name;
            paramArray[4]           = CreateDataParameter("@COL_STYLE_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value     = col_style_id;
            paramArray[5]           = CreateDataParameter("@COL_KEY", SqlDbType.NVarChar, 200);
            paramArray[5].Value     = col_key;
            paramArray[6]           = CreateDataParameter("@CAPTION", SqlDbType.NVarChar, 200);
            paramArray[6].Value     = caption;
            paramArray[7]           = CreateDataParameter("@WIDTH", SqlDbType.Int);
            paramArray[7].Value     = width;
            paramArray[8]           = CreateDataParameter("@DATA_TYPE", SqlDbType.NVarChar, 200);
            paramArray[8].Value     = data_type;
            paramArray[9]           = CreateDataParameter("@HALIGN", SqlDbType.NVarChar, 20);
            paramArray[9].Value     = halign;
            paramArray[10]          = CreateDataParameter("@BACK_COLOR", SqlDbType.NVarChar, 100);
            paramArray[10].Value    = back_color;
            paramArray[11]          = CreateDataParameter("@FORMAT", SqlDbType.NVarChar, 200);
            paramArray[11].Value    = format;
            paramArray[12]          = CreateDataParameter("@FORMULA", SqlDbType.NVarChar, 200);
            paramArray[12].Value    = formula;
            paramArray[13]          = CreateDataParameter("@DEFAULT_VALUE", SqlDbType.NVarChar);
            paramArray[13].Value    = default_value;
            paramArray[14]          = CreateDataParameter("@COL_DESC", SqlDbType.NVarChar, 2000);
            paramArray[14].Value    = col_desc;
            paramArray[15]          = CreateDataParameter("@BACK_COLOR_YN", SqlDbType.NChar);
            paramArray[15].Value    = back_color_yn;
            paramArray[16]          = CreateDataParameter("@FORMAT_YN", SqlDbType.NChar);
            paramArray[16].Value    = format_yn;
            paramArray[17]          = CreateDataParameter("@FORMULA_YN", SqlDbType.NChar);
            paramArray[17].Value    = formula_yn;
            paramArray[18]          = CreateDataParameter("@DEFAULT_VALUE_YN", SqlDbType.NChar);
            paramArray[18].Value    = formula_yn;
            paramArray[19]          = CreateDataParameter("@VISIBLE_YN", SqlDbType.NChar);
            paramArray[19].Value    = visible_yn;
            paramArray[20]          = CreateDataParameter("@COL_EMP_VISIBLE_YN", SqlDbType.NChar);
            paramArray[20].Value    = col_emp_visible_yn;
            paramArray[21]          = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[21].Value    = create_date;
            paramArray[22]          = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[22].Value    = create_user;

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
                        , int comp_id
                        , string est_id
                        , string col_key)
        {
            string query = @"DELETE	EST_COLUMN_INFO
		                        WHERE	COMP_ID     = @COMP_ID
                                    AND EST_ID      = @EST_ID
		                            AND	COL_KEY     = @COL_KEY";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value         = comp_id;
            paramArray[1]               = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value         = est_id;
            paramArray[2]               = CreateDataParameter("@COL_KEY", SqlDbType.NVarChar,100);
            paramArray[2].Value         = col_key;

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

        public int Count(int comp_id, string est_id, string col_key)
        {
            string query = @"SELECT COUNT(*) FROM EST_COLUMN_INFO
		                       WHERE	COMP_ID    = @COMP_ID
                                    AND EST_ID     = @EST_ID  
	                                AND	COL_KEY    = @COL_KEY ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@COL_KEY", SqlDbType.NVarChar,100);
            paramArray[2].Value = col_key;

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
