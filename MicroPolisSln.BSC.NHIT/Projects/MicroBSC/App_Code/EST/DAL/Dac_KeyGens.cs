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
    public class Dac_KeyGens : DbAgentBase
    {
        private DataTable Select( IDbConnection conn
                                , IDbTransaction trx 
                                , string table_name)
		{
			string query = @"SELECT   TABLE_NAME
		                            , COLUMN_NAME
		                            , FRONT_CHAR
		                            , DATE_FORMAT
		                            , CHAR_MERGE
		                            , FRONT_CHAR_S_POS
		                            , FRONT_CHAR_LENGTH
		                            , DATE_CHAR_S_POS
		                            , DATE_CHAR_LENGTH
		                            , MAX_INT_S_POS
		                            , MAX_INT_LENGTH
		                            , MAX_INT_PADDING_CHAR
                                FROM EST_KEY_GEN
                                    WHERE TABLE_NAME = @TABLE_NAME";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@TABLE_NAME", SqlDbType.NVarChar);
            paramArray[0].Value = table_name;

            DataSet ds          = DbAgentObj.FillDataSet(conn, trx, query, "PAGEINFOGET", null, paramArray, CommandType.Text);
            return ds.Tables[0];
		}

        private DataTable Select( string table_name) 
        {
            return Select(null, null, table_name);
        }

        private object NewCode(IDbConnection conn
                            , IDbTransaction trx
                            , string table_name
                            , string column_name)
        {
            string query = string.Format(@"SELECT MAX({0}) FROM {1}", column_name, table_name);
            return DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);
        }

        public string GetCode(IDbConnection conn
                            , IDbTransaction trx 
                            , string table_name)
        { 
            return GetCode(conn, trx, table_name, "", 1);
        }

        public string GetCode(string table_name)
        { 
            return GetCode(null, null, table_name, "", 1);
        }

        public string GetCode(string table_name, string columnName)
        { 
            return GetCode(null, null, table_name, columnName, 1);
        }

        public string GetCode(IDbConnection conn
                            , IDbTransaction trx 
                            , string table_name
                            , string columnName
                            , int add_num) 
        {
            DataTable dataTable = Select(conn, trx, table_name);

            if(dataTable.Rows.Count == 0)
                return null;

            DataRow dataRow = dataTable.Rows[0];

            string front_char           = "";
                
            if(columnName != "")
                front_char              = columnName;
            else
                front_char              = dataRow["FRONT_CHAR"].ToString();

            string column_name          = dataRow["COLUMN_NAME"].ToString();

            string date_format          = dataRow["DATE_FORMAT"].ToString();
            string char_merge           = dataRow["CHAR_MERGE"].ToString();
            int front_char_s_pos        = int.Parse(dataRow["FRONT_CHAR_S_POS"].ToString());
            int front_char_length       = int.Parse(dataRow["FRONT_CHAR_LENGTH"].ToString());
            int date_char_s_pos         = int.Parse(dataRow["DATE_CHAR_S_POS"].ToString());
            int date_char_length        = int.Parse(dataRow["DATE_CHAR_LENGTH"].ToString());
            int max_int_s_pos           = int.Parse(dataRow["MAX_INT_S_POS"].ToString());
            int max_int_length          = int.Parse(dataRow["MAX_INT_LENGTH"].ToString());
            char max_int_padding_char   = Convert.ToChar(dataRow["MAX_INT_PADDING_CHAR"].ToString());

            string date_char_today      = DateTime.Now.ToString(date_format);
            string max_int_char         = Convert.ToString(add_num).PadLeft(max_int_length, max_int_padding_char);

            object max                  =  NewCode(conn, trx, table_name, column_name);

            // 데이터가 존재하지 않을 경우
            if (max == DBNull.Value)
            {
                return string.Format(char_merge, front_char, date_char_today, max_int_char);
            }

            string max_column_data  = max.ToString();
            string date_char        = max_column_data.Substring(date_char_s_pos, date_char_length);

            max_column_data         = Convert.ToString(max_column_data).PadLeft(max_int_length, max_int_padding_char);

            // 오늘날짜가 데이터가 있을 경우
            if (date_char_today.Equals(date_char) || date_char.Equals(""))
            {
                max_int_char = Convert.ToString(Convert.ToInt32(max_column_data.Substring(max_int_s_pos, max_int_length)) + add_num).PadLeft(max_int_length, max_int_padding_char);
                return string.Format(char_merge, front_char, date_char, max_int_char);    
            }

            // 데이터는 존재하는 오늘날짜의 데이터가 없을 경우
            return string.Format(char_merge, front_char, date_char_today, max_int_char);
        }
    }
}
