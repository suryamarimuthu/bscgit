using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using System.Data.OracleClient;
using System.Data.OleDb;
using MicroBSC.Data;
using MicroBSC.BSC.Biz;
using MicroBSC.QueryEngine.QueryBuilder;
using MicroBSC.Integration.BSC.Dac;

namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Interface_Dicode
    {
        Dac_Bsc_Interface_Dicode _data;

        public Biz_Bsc_Interface_Dicode()
        {
            _data = new Dac_Bsc_Interface_Dicode();
        }

        public int RetrieveDataInterfaceValue(int estterm_ref_id, string ymd, int user_ref_id)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();

            IDbTransaction trx = conn.BeginTransaction();
            int affectedRow = 0;

            try
            {
                DataTable dt = _data.RetrieveDataInterfaceValue(conn, trx
                                                                , estterm_ref_id
                                                                , ymd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string query_ms = DataTypeUtility.GetString(dt.Rows[i]["Q_MS"]);
                    string query_ts = DataTypeUtility.GetString(dt.Rows[i]["Q_TS"]);
                    int kpi_ref_id = DataTypeUtility.GetToInt32(dt.Rows[i]["KPI_REF_ID"]);

                    affectedRow += _data.Update_KPI_Result_From_RetrieveData(conn, trx
                                                                            , query_ms
                                                                            , query_ts
                                                                            , estterm_ref_id
                                                                            , kpi_ref_id
                                                                            , ymd
                                                                            , user_ref_id);
                }


                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                affectedRow = 0;
            }
            finally
            {
                conn.Close();
            }

            return affectedRow;
        }


        //public int ExecRowDataInterface(string iYmd, int itxr_user)
        //{
        //    Biz_Bsc_Interface_Datasource objDS = new Biz_Bsc_Interface_Datasource();

        //    DataSet rDs = null;
        //    DataTable dtDicode = _data.Select_DB("", "", "PULL");
        //    string sRtnMsg = "";
        //    bool bisSucc = false;
        //    int iAffRow = 0;
        //    int iGetRow = 0;


        //    if (dtDicode.Rows.Count > 0)
        //    {
        //        int iRow = dtDicode.Rows.Count;
        //        for (int i = 0; i < iRow; i++)
        //        {
        //            int source_id = int.Parse(dtDicode.Rows[i]["SOURCE_ID"].ToString());
        //            Object objCon = objDS.GetConnection(source_id, out bisSucc, out sRtnMsg);
        //            string dicode = dtDicode.Rows[i]["DICODE"].ToString();

        //            string sQry = dtDicode.Rows[i]["QUERY"].ToString();
        //            sQry = sQry.Replace(QueryOperator.ParamCurrYmd, "'" + iYmd + "'");
        //            sQry = sQry.Replace(QueryOperator.ParamPrevYmd, "'" + iYmd + "'");

        //            rDs = new DataSet();
        //            if (bisSucc)
        //            {
        //                if (objCon.GetType() == typeof(SqlConnection))
        //                {
        //                    SqlConnection conn = (SqlConnection)objCon;
        //                    SqlCommand cmmd = new SqlCommand(sQry, conn);
        //                    SqlDataAdapter dadt = new SqlDataAdapter(cmmd);
        //                    iAffRow = dadt.Fill(rDs);

        //                    if (conn.State == ConnectionState.Open)
        //                    {
        //                        conn.Close();
        //                        conn.Dispose();
        //                    }
        //                }
        //                else if (objCon.GetType() == typeof(OracleConnection))
        //                {
        //                    OracleConnection conn = (OracleConnection)objCon;
        //                    OracleCommand cmmd = new OracleCommand(sQry, conn);
        //                    OracleDataAdapter dadt = new OracleDataAdapter(cmmd);
        //                    iAffRow = dadt.Fill(rDs);

        //                    if (conn.State == ConnectionState.Open)
        //                    {
        //                        conn.Close();
        //                        conn.Dispose();
        //                    }
        //                }
        //                else if (objCon.GetType() == typeof(OleDbConnection))
        //                {
        //                    OleDbConnection conn = (OleDbConnection)objCon;
        //                    OleDbCommand cmmd = new OleDbCommand(sQry, conn);
        //                    OleDbDataAdapter dadt = new OleDbDataAdapter(cmmd);
        //                    iAffRow = dadt.Fill(rDs);

        //                    if (conn.State == ConnectionState.Open)
        //                    {
        //                        conn.Close();
        //                        conn.Dispose();
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                return 0;
        //            }




        //            sQry = GetRowDataQuery(dicode, iYmd, rDs, itxr_user);
        //            string[] arrQuery = sQry.Split(';');

        //            IDbConnection dbcon = DbAgentHelper.CreateDbConnection();
        //            dbcon.Open();
        //            IDbTransaction trx = dbcon.BeginTransaction();
        //            try
        //            {
        //                for (int k = 0; k < arrQuery.Length; k++)
        //                {
        //                    if (arrQuery[k].Length > 0)
        //                    {
        //                        iGetRow += DbAgentObj.ExecuteNonQuery(arrQuery[k]);
        //                    }
        //                }

        //                trx.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trx.Rollback();
        //                iGetRow = 0;
        //            }
        //            finally
        //            {
        //                dbcon.Close();
        //            }
        //        }
        //    }

        //    return iGetRow;
        //}

        //public string GetRowDataQuery(string iDiCode, string iYmd, DataSet rDs, int itxr_user)
        //{
        //    string sQry = "";

        //    if (rDs.Tables.Count > 0)
        //    {
        //        sQry = string.Format("DELETE FROM BSC_INTERFACE_DATA WHERE DICODE='{0}' AND RDTERM='{1}';", base.IDicode, iYmd);

        //        if (!rDs.Tables[0].Columns.Contains("DICODE"))
        //        {
        //            rDs.Tables[0].Columns.Add("DICODE", typeof(string));
        //        }

        //        if (!rDs.Tables[0].Columns.Contains("RDTERM"))
        //        {
        //            rDs.Tables[0].Columns.Add("RDTERM", typeof(string));
        //        }

        //        if (!rDs.Tables[0].Columns.Contains("RDDATE"))
        //        {
        //            rDs.Tables[0].Columns.Add("RDDATE", typeof(string));
        //        }

        //        if (!rDs.Tables[0].Columns.Contains("SEQUENCE"))
        //        {
        //            rDs.Tables[0].Columns.Add("SEQUENCE", typeof(string));
        //        }

        //        if (!rDs.Tables[0].Columns.Contains("INPUT_TYPE"))
        //        {
        //            rDs.Tables[0].Columns.Add("INPUT_TYPE", typeof(string));
        //        }

        //        int iCol = rDs.Tables[0].Columns.Count;
        //        int iRow = rDs.Tables[0].Rows.Count;
        //        for (int k = 0; k < iRow; k++)
        //        {
        //            string sInsertQry = "INSERT INTO BSC_INTERFACE_DATA({0}) VALUES({1});";
        //            string sColumn = "";
        //            string sValue = "";
        //            string sCellVal = "";

        //            for (int j = 0; j < iCol; j++)
        //            {
        //                if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "DICODE" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
        //                {
        //                    rDs.Tables[0].Rows[k][j] = iDiCode;
        //                }

        //                if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "RDTERM" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
        //                {
        //                    rDs.Tables[0].Rows[k][j] = iYmd;
        //                }

        //                if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "RDDATE" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
        //                {
        //                    rDs.Tables[0].Rows[k][j] = "01";
        //                }

        //                if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "SEQUENCE" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
        //                {
        //                    rDs.Tables[0].Rows[k][j] = int.Parse(k.ToString());
        //                }

        //                if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "INPUT_TYPE" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
        //                {
        //                    rDs.Tables[0].Rows[k][j] = int.Parse(Convert.ToString("1"));
        //                }

        //                sColumn += (j == 0) ? rDs.Tables[0].Columns[j].ColumnName : ("," + rDs.Tables[0].Columns[j].ColumnName);

        //                if (rDs.Tables[0].Columns[j].DataType == typeof(int) ||
        //                    rDs.Tables[0].Columns[j].DataType == typeof(long) ||
        //                    rDs.Tables[0].Columns[j].DataType == typeof(double) ||
        //                    rDs.Tables[0].Columns[j].DataType == typeof(decimal) ||
        //                    rDs.Tables[0].Columns[j].DataType == typeof(float))
        //                {
        //                    if (rDs.Tables[0].Rows[k][j].ToString() == "" || rDs.Tables[0].Rows[k][j] == null || rDs.Tables[0].Rows[k][j] == DBNull.Value)
        //                        sCellVal = "0";
        //                    else
        //                        sCellVal = rDs.Tables[0].Rows[k][j].ToString();
        //                }
        //                else
        //                {
        //                    sCellVal = "'" + rDs.Tables[0].Rows[k][j].ToString() + "'";
        //                }

        //                sValue += (j == 0) ? sCellVal : ("," + sCellVal);
        //            }
        //            sQry += string.Format(sInsertQry, sColumn, sValue);
        //        }
        //    }

        //    return sQry;
        //}
    }
}
