using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.EST.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Biz
{
    public class Biz_Est_Outer_Data_Proc_Info
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_est_id;
        private string 	_proc_name;
        private DateTime 	_update_date;
        private int 	_update_user;
        private string _query_string;

        private Dac_Est_Outer_Data_Proc_Info _outerDataPro = new Dac_Est_Outer_Data_Proc_Info();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public int Comp_ID
        {
	        get 
	        {
		        return _comp_id;
	        }
	        set
	        {
		        _comp_id = value;
	        }
        }
         
        public string Est_ID
        {
	        get 
	        {
		        return _est_id;
	        }
	        set
	        {
		        _est_id = ( value==null ? "" : value );
	        }
        }
         
        public string Proc_Name
        {
	        get 
	        {
		        return _proc_name;
	        }
	        set
	        {
		        _proc_name = ( value==null ? "" : value );
	        }
        }
         
        public DateTime Update_Date
        {
	        get 
	        {
		        return _update_date;
	        }
	        set
	        {
		        _update_date = value;
	        }
        }
         
        public int Update_User
        {
	        get 
	        {
		        return _update_user;
	        }
	        set
	        {
		        _update_user = value;
	        }
        }

        public string Query_String
        {
            get
            {
                return _query_string;
            }
            set
            {
                _query_string = (value == null ? "" : value);
            }
        }

        #endregion
         
        public Biz_Est_Outer_Data_Proc_Info()
	    {
		    
	    }

        public Biz_Est_Outer_Data_Proc_Info(int comp_id
                                    , string est_id)
	    {
            DataSet ds = GetOuterDataProcInfo(comp_id
                                            , est_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _comp_id        = (dr["COMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id         = (dr["EST_ID"]         == DBNull.Value) ? "" : DataTypeUtility.GetValue( dr["EST_ID"]);
                _proc_name      = (dr["PROC_NAME"]      == DBNull.Value) ? "" : DataTypeUtility.GetValue(dr["PROC_NAME"]);
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _query_string   = (dr["QUERY_STRING"]   == DBNull.Value) ? "" : DataTypeUtility.GetValue(dr["QUERY_STRING"]);
	        }
	    }


        public bool GetOuterData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_ste_id
                                , out string msg)
        {
            int intTxrCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();



            DataTable dtOuter = _outerDataPro.Select(comp_id, est_id).Tables[0];
            msg = "";

            int cnt = dtOuter.Rows.Count;

            bool isContainQueryString = false;
            int affectedRow = 0;

            if (dtOuter.Columns.Contains("QUERY_STRING"))
            {
                if (cnt > 0)
                {
                    isContainQueryString = true;
                }
            }

            if (cnt == 0)
            {
                msg = "평가별 프로시져 또는 쿼리 정보가 등록되어 있지 않습니다.";
                return false;
            }

            try
            {
                MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();
                int delCnt = dacEstData.Delete(null
                                             , null
                                             , comp_id
                                             , est_id
                                             , estterm_ref_id
                                             , estterm_sub_id);


                if (isContainQueryString)
                {
                    msg = "(쿼리스트링)";
                    string query_string = DataTypeUtility.GetValue(dtOuter.Rows[0]["QUERY_STRING"]);

                    affectedRow = _outerDataPro.DoInsertingDataByUsingQuery(comp_id
                                                                            , est_id
                                                                            , estterm_ref_id
                                                                            , estterm_sub_id
                                                                            , estterm_ste_id
                                                                            , query_string);

                }
                else
                {
                    msg = "(프로시져)";
                    affectedRow = _outerDataPro.GetData(comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , estterm_ste_id
                                                        , DataTypeUtility.GetValue(dtOuter.Rows[0]["PROC_NAME"]));


                }
                
            trx.Commit();

            }
            catch (Exception ex)
            {
                trx.Rollback();
                msg += ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        
         
        public bool ModifyOuterDataProcInfo(  int comp_id
                                            , string est_id
                                            , string proc_name
                                            , string query_string
                                            , DateTime update_date
                                            , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _outerDataPro.Update(null
                                            , null
                                            , comp_id
                                            , est_id
                                            , proc_name
                                            , update_date
                                            , update_user
                                            , query_string);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetOuterDataProcInfo(  int comp_id
                                            , string est_id)
        {
	        return _outerDataPro.Select(  comp_id
                                        , est_id);
        }
         
        public bool AddOuterDataProcInfo( int comp_id
                                        , string est_id
                                        , string proc_name
                                        , string query_string
                                        , DateTime create_date
                                        , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _outerDataPro.Insert(null
                                            , null
                                            , comp_id
                                            , est_id
                                            , proc_name
                                            , create_date
                                            , create_user
                                            , query_string);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveOuterDataProcInfo(int comp_id, string est_id)
        {
	        int affectedRow = 0;

            affectedRow = _outerDataPro.Delete(null
                                            , null
                                            , comp_id
                                            , est_id);

            return (affectedRow > 0) ? true : false;
        }

    }
}