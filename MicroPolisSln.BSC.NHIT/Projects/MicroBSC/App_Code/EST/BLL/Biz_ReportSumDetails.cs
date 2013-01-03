using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_ReportSumDetails
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private int 	_estterm_ref_id;
        private int 	_estterm_sub_id;
        private string 	_est_id;
        private int 	_sort_order;
        private string 	_use_yn;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_ReportSumDetails _reportSumDetail = new Dac_ReportSumDetails();

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
         
        public int EstTerm_Ref_ID
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
         
        public int EstTerm_Sub_ID
        {
	        get 
	        {
		        return _estterm_sub_id;
	        }
	        set
	        {
		        _estterm_sub_id = value;
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
         
        public int Sort_Order
        {
	        get 
	        {
		        return _sort_order;
	        }
	        set
	        {
		        _sort_order = value;
	        }
        }
         
        public string Use_YN
        {
	        get 
	        {
		        return _use_yn;
	        }
	        set
	        {
		        _use_yn = ( value==null ? "" : value );
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
        #endregion
         
        public Biz_ReportSumDetails()
	    {
		    
	    }

        //public Biz_ReportSumDetails()
        //{
        //    DataSet ds = null;
        //    DataRow dr;
         
        //    if(ds.Tables[0].Rows.Count == 1)
        //    {
        //        dr              = ds.Tables[0].Rows[0];
        //        _comp_id        = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
        //        _estterm_ref_id = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
        //        _estterm_sub_id = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
        //        _est_id         = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
        //        _sort_order     = (dr["SORT_ORDER"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
        //        _use_yn         = (dr["USE_YN"]             == DBNull.Value) ? "" : (string) dr["USE_YN"];
        //        _update_date    = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
        //        _update_user    = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
        //    }
        //}
         
        public bool ModifyReportSumDetail(int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , string est_id
                                        , int sort_order
                                        , string use_yn
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _reportSumDetail.Update(null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , est_id
                                                , sort_order
                                                , use_yn
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetReportSumDetail(int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id)
        {
	        return _reportSumDetail.Select(comp_id
                                        , estterm_ref_id
                                        , estterm_sub_id);
        }
         
        public bool AddReportSumDetail(int comp_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , string est_id
                                    , int sort_order
                                    , string use_yn
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _reportSumDetail.Insert(null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , est_id
                                                , sort_order
                                                , use_yn
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveReportSumDetail(int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , string est_id)
        {
	        int affectedRow = 0;

            affectedRow = _reportSumDetail.Delete(null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , est_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
