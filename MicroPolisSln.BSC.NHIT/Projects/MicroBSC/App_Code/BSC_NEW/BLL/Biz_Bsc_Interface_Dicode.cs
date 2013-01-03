using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;

using MicroBSC.Data;
using MicroBSC.BSC.Dac;
using MicroBSC.QueryEngine.QueryBuilder;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Interface_Dicode
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Interface_Dicode
    /// Class Func     : BSC_INTERFACE_DICODE Business Logic Class
    /// CREATE DATE    : 2008-07-18 오후 11:46:07
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Interface_Dicode  : Dac_Bsc_Interface_Dicode
    {
        public Biz_Bsc_Interface_Dicode() { }
        public Biz_Bsc_Interface_Dicode(string idicode, int itxr_user) : base(idicode, itxr_user) { }

        public int InsertData(IDbConnection con, IDbTransaction trx, string idicode, string iname, int isource_id, string iinput_type, string idefinition, string iuse_yn, string iquery, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx, idicode, iname, isource_id, iinput_type, idefinition, iuse_yn, iquery, itxr_user);
        }

        public int UpdateData(IDbConnection con, IDbTransaction trx, string idicode, string iname, int isource_id, string iinput_type, string idefinition, string iuse_yn, string iquery, int itxr_user, string idailykpi_yn) 
        {
            return base.UpdateData_Dac(con, trx, idicode, iname, isource_id, iinput_type, idefinition, iuse_yn, iquery, itxr_user, idailykpi_yn);
        }

        public int DeleteData(IDbConnection con, IDbTransaction trx, string idicode, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx, idicode, itxr_user);
        }

        /// <summary>
        /// Interface Info And Interface Column 처리
        /// </summary>
        /// <param name="con"></param>
        /// <param name="trx"></param>
        /// <param name="idicode"></param>
        /// <param name="iname"></param>
        /// <param name="idefinition"></param>
        /// <param name="iuse_yn"></param>
        /// <param name="itxr_user"></param>
        /// <param name="iDtCol">COLUMN_ID, COLUMN_ALIAS, LOV_YN, SORT_ORDER, DECIMAL_POINTS, GRID_WIDTH, USE_YN</param>
        /// <returns></returns>
        public bool InsertDiCodeColumn(IDbConnection con, IDbTransaction trx, string idicode, string iname, int isource_id, string iinput_type, string idefinition, string iuse_yn, string iquery, int itxr_user, DataTable iDtCol, string idailykpi_yn)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Interface_Dicode dacBscDI = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Interface_Dicode();

            if (con == null)
            {
                con = DbAgentHelper.CreateDbConnection();
                con.Open();
            }

            if (trx == null)
            {
                trx = con.BeginTransaction();
            }

            bool blnRtn = false ;
            int iRtn    = 0;
            try
            {
                //iRtn = base.UpdateData_Dac(con, trx, idicode, iname, isource_id, iinput_type, idefinition, iuse_yn, iquery, itxr_user, idailykpi_yn);
                DataTable dt = dacBscDI.Select_DB(con, trx, idicode);
                if (dt.Rows.Count > 0)
                {
                    iRtn = dacBscDI.Update_DB(con, trx, iname, isource_id, iinput_type, idefinition, iuse_yn, iquery, itxr_user, idailykpi_yn, idicode);
                }
                else
                {
                    iRtn = dacBscDI.Insert_DB(con, trx, idicode, iname, isource_id, iinput_type, idefinition, iuse_yn, iquery, itxr_user, idailykpi_yn);
                }
                

                //if (base.Transaction_Result == "Y")
                if(iRtn>0)
                {
                    Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
                    for (int i = 0; i < iDtCol.Rows.Count; i++)
                    {
                        objCol.IColumn_Id      = iDtCol.Rows[i]["COLUMN_ID"].ToString();
                        objCol.IColumn_Alias   = iDtCol.Rows[i]["COLUMN_ALIAS"].ToString();
                        objCol.ILov_Yn         = iDtCol.Rows[i]["LOV_YN"].ToString();
                        objCol.ISort_Order     = Convert.ToInt32(iDtCol.Rows[i]["SORT_ORDER"].ToString());
                        objCol.IUnit_Ref_Id    = Convert.ToInt32(iDtCol.Rows[i]["UNIT_REF_ID"].ToString());
                        objCol.IDecimal_Points = Convert.ToInt32(iDtCol.Rows[i]["DECIMAL_POINTS"].ToString());
                        objCol.IGrid_Width     = Convert.ToInt32(iDtCol.Rows[i]["GRID_WIDTH"].ToString());
                        objCol.IUse_Yn         = iDtCol.Rows[i]["USE_YN"].ToString();

                        
                        iRtn += objCol.UpdateData
                                      ( con 
                                       ,trx
                                       ,idicode
                                       ,objCol.IColumn_Id
                                       ,objCol.IColumn_Alias
                                       ,objCol.ILov_Yn
                                       ,objCol.ISort_Order
                                       ,objCol.IUnit_Ref_Id
                                       ,objCol.IDecimal_Points
                                       ,objCol.IGrid_Width
                                       ,objCol.IUse_Yn
                                       ,itxr_user);

                        if (objCol.Transaction_Result == "N")
                        {
                            base.Transaction_Message = objCol.Transaction_Message;
                            trx.Rollback();
                            blnRtn = false;
                        }
                    }

                    trx.Commit();
                    blnRtn = true;
                }
                else
                {
                    trx.Rollback();
                    blnRtn = false;
                }
            }
            catch(Exception e)
            {
                base.Transaction_Message = e.Message;
                trx.Rollback();
                blnRtn = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            return blnRtn;
        }

        public DataTable GetDataResult(string idicode, string sPreYMD, string sCurYMD, int itxr_user)
        {
            Biz_Bsc_Interface_Dicode objBSC = new Biz_Bsc_Interface_Dicode(idicode, itxr_user);
            string sQry = objBSC.IQuery;
            int isource_id = objBSC.ISource_Id;
            bool bisSucc = false;
            string sRtnMsg = "";
            int iAffRow = 0;

            sQry = sQry.Replace(QueryOperator.ParamCurrYmd, "'" + sCurYMD + "'");
            sQry = sQry.Replace(QueryOperator.ParamPrevYmd, "'" + sPreYMD + "'");

            DataSet rDs = new DataSet();
            Biz_Bsc_Interface_Datasource objDS = new Biz_Bsc_Interface_Datasource();
            Object objCon = objDS.GetConnection(isource_id, out bisSucc, out sRtnMsg);

            if (bisSucc && sQry.Trim().Length > 0)
            {
                if (objCon.GetType() == typeof(SqlConnection))
                {
                    SqlConnection conn = (SqlConnection)objCon;
                    SqlCommand cmmd = new SqlCommand(sQry, conn);
                    SqlDataAdapter dadt = new SqlDataAdapter(cmmd);
                    iAffRow = dadt.Fill(rDs);

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
                else if (objCon.GetType() == typeof(OracleConnection))
                {
                    OracleConnection conn = (OracleConnection)objCon;
                    OracleCommand cmmd = new OracleCommand(sQry, conn);
                    OracleDataAdapter dadt = new OracleDataAdapter(cmmd);
                    iAffRow = dadt.Fill(rDs);

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
                else if (objCon.GetType() == typeof(OleDbConnection))
                {
                    OleDbConnection conn = (OleDbConnection)objCon;
                    OleDbCommand cmmd = new OleDbCommand(sQry, conn);
                    OleDbDataAdapter dadt = new OleDbDataAdapter(cmmd);
                    iAffRow = dadt.Fill(rDs);

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }

                if (rDs.Tables.Count > 0)
                {
                    return (rDs.Tables[0]);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public int ExecRowDataInterface(string iYmd, int itxr_user)
        {
            Biz_Bsc_Interface_Datasource objDS = new Biz_Bsc_Interface_Datasource();

            DataSet rDs      = null;
            DataSet dsDicode = base.GetAllList("", "", "PULL", itxr_user);
            string sRtnMsg   = "";
            bool bisSucc     = false;
            int iAffRow      = 0;
            int iGetRow      = 0;
            

            if (dsDicode.Tables.Count > 0)
            {
                int iRow = dsDicode.Tables[0].Rows.Count;
                for(int i=0; i < iRow; i++)
                {
                    base.ISource_Id = int.Parse(dsDicode.Tables[0].Rows[i]["SOURCE_ID"].ToString());
                    Object objCon   = objDS.GetConnection(base.ISource_Id, out bisSucc, out sRtnMsg);
                    base.IDicode    = dsDicode.Tables[0].Rows[i]["DICODE"].ToString();

                    string sQry     = dsDicode.Tables[0].Rows[i]["QUERY"].ToString();
                    sQry = sQry.Replace(QueryOperator.ParamCurrYmd, "'" + iYmd + "'");
                    sQry = sQry.Replace(QueryOperator.ParamPrevYmd, "'" + iYmd + "'");

                    rDs = new DataSet();
                    if (bisSucc)
                    {
                        if (objCon.GetType() == typeof(SqlConnection))
                        {
                            SqlConnection conn = (SqlConnection)objCon;
                            SqlCommand cmmd = new SqlCommand(sQry, conn);
                            SqlDataAdapter dadt = new SqlDataAdapter(cmmd);
                            iAffRow = dadt.Fill(rDs);

                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                        else if (objCon.GetType() == typeof(OracleConnection))
                        {
                            OracleConnection conn = (OracleConnection)objCon;
                            OracleCommand cmmd = new OracleCommand(sQry, conn);
                            OracleDataAdapter dadt = new OracleDataAdapter(cmmd);
                            iAffRow = dadt.Fill(rDs);

                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                                conn.Dispose();
                            }
                        }
                        else if (objCon.GetType() == typeof(OleDbConnection))
                        {
                            OleDbConnection conn = (OleDbConnection)objCon;
                            OleDbCommand cmmd = new OleDbCommand(sQry, conn);
                            OleDbDataAdapter dadt = new OleDbDataAdapter(cmmd);
                            iAffRow = dadt.Fill(rDs);

                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                                conn.Dispose();
                            }
                        }

                    }
                    else
                    {
                        return 0;
                    }



                    
                    sQry = this.GetRowDataQuery(base.IDicode, iYmd, rDs, itxr_user);
                    //iGetRow += base.DbAgentObj.ExecuteNonQuery(sQry);
                    string[] arrQuery = sQry.Split(';');

                    IDbConnection dbcon = DbAgentHelper.CreateDbConnection();
                    dbcon.Open();
                    IDbTransaction trx = dbcon.BeginTransaction();
                    try
                    {
                        for (int k = 0; k < arrQuery.Length; k++)
                        {
                            if (arrQuery[k].Length > 0)
                            {
                                iGetRow += DbAgentObj.ExecuteNonQuery(arrQuery[k]);
                            }
                        }

                        trx.Commit();
                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        iGetRow = 0;
                    }
                    finally
                    {
                        dbcon.Close();
                    }
                }
            }

            return iGetRow;
        }

        public DataTable GetOrginalInterfaceData(object dicode, object diname, int itxr_user, string iYmd)
        {
            Biz_Bsc_Interface_Datasource objDS = new Biz_Bsc_Interface_Datasource();

            DataSet rDs = new DataSet();
            DataSet dsDicode = base.GetAllList(dicode.ToString(), "", "PULL", itxr_user);
            string sRtnMsg = "";
            bool bisSucc = false;
            int iAffRow = 0;


            if (dsDicode.Tables.Count > 0)
            {
                Object objCon = objDS.GetConnection(int.Parse(dsDicode.Tables[0].Rows[0]["SOURCE_ID"].ToString()), out bisSucc, out sRtnMsg);

                string sQry = dsDicode.Tables[0].Rows[0]["QUERY"].ToString();
                sQry = sQry.Replace(QueryOperator.ParamCurrYmd, "'" + iYmd + "'");
                sQry = sQry.Replace(QueryOperator.ParamPrevYmd, "'" + iYmd + "'");

                if (bisSucc)
                {
                    if (objCon.GetType() == typeof(SqlConnection))
                    {
                        SqlConnection conn = (SqlConnection)objCon;
                        SqlCommand cmmd = new SqlCommand(sQry, conn);
                        SqlDataAdapter dadt = new SqlDataAdapter(cmmd);
                        iAffRow = dadt.Fill(rDs);

                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                            conn.Dispose();
                        }
                    }
                    else if (objCon.GetType() == typeof(OracleConnection))
                    {
                        OracleConnection conn = (OracleConnection)objCon;
                        OracleCommand cmmd = new OracleCommand(sQry, conn);
                        OracleDataAdapter dadt = new OracleDataAdapter(cmmd);
                        iAffRow = dadt.Fill(rDs);

                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                            conn.Dispose();
                        }
                    }
                    else if (objCon.GetType() == typeof(OleDbConnection))
                    {
                        OleDbConnection conn = (OleDbConnection)objCon;
                        OleDbCommand cmmd = new OleDbCommand(sQry, conn);
                        OleDbDataAdapter dadt = new OleDbDataAdapter(cmmd);
                        iAffRow = dadt.Fill(rDs);

                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                            conn.Dispose();
                        }
                    }

                }
            }
            return rDs.Tables[0];
        }

        public string GetRowDataQuery(string iDiCode, string iYmd, DataSet rDs, int itxr_user)
        {
            string sQry = "";

            if (rDs.Tables.Count > 0)
            {
                sQry = string.Format("DELETE FROM BSC_INTERFACE_DATA WHERE DICODE='{0}' AND RDTERM='{1}';", base.IDicode, iYmd);

                if (!rDs.Tables[0].Columns.Contains("DICODE"))
                {
                    rDs.Tables[0].Columns.Add("DICODE", typeof(string));
                }

                if (!rDs.Tables[0].Columns.Contains("RDTERM"))
                {
                    rDs.Tables[0].Columns.Add("RDTERM", typeof(string));
                }

                if (!rDs.Tables[0].Columns.Contains("RDDATE"))
                {
                    rDs.Tables[0].Columns.Add("RDDATE", typeof(string));
                }

                if (!rDs.Tables[0].Columns.Contains("SEQUENCE"))
                {
                    rDs.Tables[0].Columns.Add("SEQUENCE", typeof(string));
                }

                if (!rDs.Tables[0].Columns.Contains("INPUT_TYPE"))
                {
                    rDs.Tables[0].Columns.Add("INPUT_TYPE", typeof(string));
                }

                int iCol   = rDs.Tables[0].Columns.Count;
                int iRow   = rDs.Tables[0].Rows.Count;
                for (int k = 0; k < iRow; k++)
                {
                    string sInsertQry = "INSERT INTO BSC_INTERFACE_DATA({0}) VALUES({1});";
                    string sColumn    = "";
                    string sValue     = "";
                    string sCellVal   = "";

                    for (int j = 0; j < iCol; j++)
                    {
                        if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "DICODE" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
                        { 
                            rDs.Tables[0].Rows[k][j] = iDiCode;
                        }

                        if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "RDTERM" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
                        {
                            rDs.Tables[0].Rows[k][j] = iYmd;
                        }

                        if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "RDDATE" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
                        {
                            rDs.Tables[0].Rows[k][j] = "01";
                        }

                        if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "SEQUENCE" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
                        {
                            rDs.Tables[0].Rows[k][j] = int.Parse(k.ToString());
                        }

                        if (rDs.Tables[0].Columns[j].ColumnName.ToUpper() == "INPUT_TYPE" & (rDs.Tables[0].Rows[k][j] == DBNull.Value || rDs.Tables[0].Rows[k][j] == string.Empty))
                        {
                            rDs.Tables[0].Rows[k][j] = int.Parse(Convert.ToString("1"));
                        }

                        sColumn += (j==0) ? rDs.Tables[0].Columns[j].ColumnName : ("," + rDs.Tables[0].Columns[j].ColumnName);

                        if (rDs.Tables[0].Columns[j].DataType == typeof(int) ||
                            rDs.Tables[0].Columns[j].DataType == typeof(long) ||
                            rDs.Tables[0].Columns[j].DataType == typeof(double) ||
                            rDs.Tables[0].Columns[j].DataType == typeof(decimal) ||
                            rDs.Tables[0].Columns[j].DataType == typeof(float))
                        {
                            if (rDs.Tables[0].Rows[k][j].ToString() == "" || rDs.Tables[0].Rows[k][j] == null || rDs.Tables[0].Rows[k][j] == DBNull.Value)
                                sCellVal = "0";
                            else
                                sCellVal = rDs.Tables[0].Rows[k][j].ToString();
                        }
                        else
                        { 
                            sCellVal = "'" + rDs.Tables[0].Rows[k][j].ToString() + "'"; 
                        }

                        sValue += (j == 0) ? sCellVal : ("," + sCellVal);
                    }
                    sQry += string.Format(sInsertQry, sColumn, sValue);
                }
            }

            return sQry;
        }

        public int RetrieveDataInterfaceValue(int iEstterm_Ref_Id, string iYmd, int itxr_user)
        {
            int rtnValue = 0;
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iEstterm_Ref_Id;
            paramArray[1] = CreateDataParameter("@iC_DATE", SqlDbType.VarChar);
            paramArray[1].Value = iYmd;


            rtnValue = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_INTERFACEVALUE_FROM_INF_DATA", "usp_INTERFACEVALUE_FROM_INF_DATA"), paramArray, CommandType.StoredProcedure);

            return rtnValue;
        }

        public DataTable GetDiCodeUseYNDailyKpiYN(string use_yn, string dailykpi_yn)
        {
            return base.GetDiCodeUseYNDailyKpiYN(use_yn, dailykpi_yn);
        }
    }
}