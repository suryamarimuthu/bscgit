using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;

using MicroBSC.BSC.Dac;
using MicroBSC.Data;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Interface_Datasource
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Interface_Datasource
    /// Class Func     : BSC_INTERFACE_DATASOURCE Business Logic Class
    /// CREATE DATE    : 2008-08-28 오후 3:52:10
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Interface_Datasource  : Dac_Bsc_Interface_Datasource
    {
        public Biz_Bsc_Interface_Datasource() { }
        public Biz_Bsc_Interface_Datasource(int isource_id) : base( isource_id) { }

        public int InsertData(IDbConnection con, IDbTransaction trx, string isource_name, string isource_type, string ics_initial_catalog, string ics_data_source, string ics_provider, string ics_user_id, string ics_password, string ics_connect_timeout, string ics_extended_properties, string idescriptions, string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx, isource_name,  isource_type,  ics_initial_catalog,  ics_data_source,  ics_provider,  ics_user_id,  ics_password,  ics_connect_timeout,  ics_extended_properties,  idescriptions,  iuse_yn, itxr_user);
        }

        public bool InsertInterfaceData(DataTable dataTable, bool allowUpdate)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow = base.DeleteInterfaceData(conn
                                                    , trx
                                                    , dataTable.Rows[0]["DICODE"].ToString()
                                                    , dataTable.Rows[0]["RDTERM"].ToString()
                                                    , dataTable.Rows[0]["RDDATE"].ToString()
                                                    , DataTypeUtility.GetToInt32(dataTable.Rows[0]["INPUT_TYPE"]));

                affectedRow = base.InsertInterfaceData(conn
                                                    , trx
                                                    , dataTable);

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return (affectedRow > 0) ? true : false;
        }

        public int UpdateData(IDbConnection con, IDbTransaction trx, int isource_id, string isource_name, string isource_type, string ics_initial_catalog, string ics_data_source, string ics_provider, string ics_user_id, string ics_password, string ics_connect_timeout, string ics_extended_properties, string idescriptions, string iuse_yn, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx, isource_id, isource_name, isource_type, ics_initial_catalog, ics_data_source, ics_provider, ics_user_id, ics_password, ics_connect_timeout, ics_extended_properties, idescriptions, iuse_yn, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction trx, int isource_id, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx, isource_id, itxr_user);
        }

        public int ReUseData(IDbConnection con, IDbTransaction trx, int isource_id, int itxr_user)
        {
            return base.ReUseData_Dac(con, trx, isource_id, itxr_user);
        }

        /// <summary>
        /// 소스에 대한 연결 문자열을 구하여 연결 커넥션 객체 리턴
        /// </summary>
        /// <param name="isource_id"></param>
        /// <returns></returns>
        public object GetConnectionPerSourceID(int isource_id)
        {
            Biz_Bsc_Interface_Datasource objBSC = new Biz_Bsc_Interface_Datasource(isource_id);
            string strCon = "";
            if (objBSC.ISource_Type.ToUpper() == "SYSTEM.DATA.SQLCLIENT")
            {
                strCon = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
                strCon = String.Format(strCon, objBSC.ICs_Data_Source, objBSC.ICs_Initial_Catalog, objBSC.ICs_User_Id, objBSC.ICs_Password);
                SqlConnection objCon = new SqlConnection(strCon);

                return objCon;
            }
            else if (objBSC.ISource_Type.ToUpper() == "SYSTEM.DATA.ORACLECLIENT")
            {
                strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2}; Unicode=True";
                strCon = String.Format(strCon, objBSC.ICs_Data_Source, objBSC.ICs_User_Id, objBSC.ICs_Password);
                OracleConnection objCon = new OracleConnection(strCon);
                return objCon;
            }
            else if (objBSC.ISource_Type.ToUpper() == "SYSTEM.DATA.OLEDB")
            {
                strCon = "Provider={0};Data Source={1};User Id={2};Password={3};";
                strCon = String.Format(strCon, objBSC.ICs_Provider, objBSC.ICs_Data_Source, objBSC.ICs_User_Id, objBSC.ICs_Password);
                OleDbConnection objCon = new OleDbConnection(strCon);
                return objCon;
            }

            return null;
        }

        /// <summary>
        /// 연결객체를 구하여 연결한다
        /// </summary>
        /// <param name="isource_id"></param>
        /// <param name="isConnetSuccess"></param>
        /// <param name="sError"></param>
        /// <returns></returns>
        public object GetConnection(int isource_id, out bool isConnetSuccess, out string sError)
        {
            Object objCon = this.GetConnectionPerSourceID(isource_id);
            sError        = "연결테스트를 성공했습니다.";

            if (objCon.GetType() == typeof(SqlConnection))
            {
                SqlConnection conn = null;
                try
                {
                    conn = (SqlConnection)objCon;
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        isConnetSuccess = true;
                        return conn;                        
                    }
                }
                catch( Exception e)
                {
                    sError          = e.Message;
                    isConnetSuccess = false;
                }

                isConnetSuccess = false;
                return conn;
            }
            else if (objCon.GetType() == typeof(OracleConnection))
            {
                OracleConnection conn = null;
                try
                {
                    conn = (OracleConnection)objCon;
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        isConnetSuccess = true;
                        return conn;
                    }
                }
                catch (Exception e)
                {
                    sError = e.Message;
                    isConnetSuccess = false;
                }

                isConnetSuccess = false;
                return conn;
            }
            else if (objCon.GetType() == typeof(OleDbConnection))
            {
                OleDbConnection conn = null;
                try
                {
                    conn = (OleDbConnection)objCon;
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        isConnetSuccess = true;
                        return conn;
                    }
                }
                catch (Exception e)
                {
                    sError = e.Message;
                    isConnetSuccess = false;
                }

                isConnetSuccess = false;
                return conn;
            }

            isConnetSuccess = false;
            return null;
        }


        public DataSet GetInterfaceData(string dicode
                                    , string rdterm
                                    , int input_type
                                    , string rddate)
        {
            return base.GetInterfaceData(dicode
                                        , rdterm
                                        , input_type
                                        , rddate);
        }

        public DataSet GetInterfacePreviewData(string strQuery
                                                , string ymd)
        {
            return base.GetInterfacePreviewData(strQuery
                                                , ymd);
        }

        /// <summary>
        /// Bsc_interface_data 테이블 스키마정보
        /// </summary>
        /// <returns></returns>
        public DataTable GetInsertSchema()
        {
            DataTable dtInterfaceData = new DataTable("BSC_INTERFACE_DATA");

            dtInterfaceData.Columns.Add("DICODE", typeof(string));//	varchar
            dtInterfaceData.Columns.Add("RDTERM", typeof(string));//	varchar
            dtInterfaceData.Columns.Add("RDDATE", typeof(string));//	varchar
            dtInterfaceData.Columns.Add("SEQUENCE", typeof(int));//	numeric
            dtInterfaceData.Columns.Add("INPUT_TYPE", typeof(int));//	int
            dtInterfaceData.Columns.Add("RESULT_DATE", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES1", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES2", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES3", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES4", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES5", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES6", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES7", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES8", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES9", typeof(string));//	nvarchar
            dtInterfaceData.Columns.Add("SVALUES10", typeof(string));//	nvarchar

            dtInterfaceData.Columns.Add("DVALUES1", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES2", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES3", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES4", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES5", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES6", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES7", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES8", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES9", typeof(double));//	numeric
            dtInterfaceData.Columns.Add("DVALUES10", typeof(double));//	numeric

            dtInterfaceData.Columns.Add("RD_STATUS", typeof(int));//	int
            //dtInterfaceData.Columns.Add("ADDFILE", typeof(string));//	varchar
            //dtInterfaceData.Columns.Add("REMARK", typeof(string));//	nvarchar
            //dtInterfaceData.Columns.Add("KPI_CODE", typeof(string));//	varchar
            dtInterfaceData.Columns.Add("CREATE_USER", typeof(int));//	int
            dtInterfaceData.Columns.Add("CREATE_DATE", typeof(DateTime));//	datetime

            return dtInterfaceData;
        }
	}
}