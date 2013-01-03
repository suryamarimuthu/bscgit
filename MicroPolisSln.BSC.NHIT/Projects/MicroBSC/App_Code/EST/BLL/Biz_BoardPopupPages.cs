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
    public class Biz_BoardPopupPages
    {
        #region ============================== [Fields] ==============================
 
     
        private int      _menu_ref_id;
        private int      _sort_order;
        private string 	 _use_yn;
        private DateTime _update_date;
        private int 	 _update_user;

        private Dac_BoardPopupPages _boardPopupPage = new Dac_BoardPopupPages();

        #endregion
         
        #region ============================== [Properties] ==============================

        public int Menu_Ref_ID
        {
            get
            {
                return _menu_ref_id;
            }
            set
            {
                _menu_ref_id = value;
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
                _use_yn = (value == null ? "" : value);
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
         
        public Biz_BoardPopupPages()
	    {
		    
	    }

        public Biz_BoardPopupPages(int meun_ref_id)
	    {
            DataSet ds = _boardPopupPage.Select(meun_ref_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];
                _menu_ref_id        = DataTypeUtility.GetToInt32(dr["MENU_REF_ID"]);
                _sort_order         = DataTypeUtility.GetToInt32(dr["SORT_ORDER"]);
		        _use_yn             = DataTypeUtility.GetValue(dr["POP_UP_YN"]);
		        _update_date        = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
		        _update_user        = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyBoardPopupPage( int menu_ref_id
                                , int sort_order
                                , string use_yn
                                , DateTime update_date
                                , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _boardPopupPage.Update(  null
                                        , null
                                        , menu_ref_id
                                        , sort_order
                                        , use_yn
                                        , update_date
                                        , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetBoardPoupPage(int menu_ref_id)
        {
            return _boardPopupPage.Select(menu_ref_id);
        }
         
        public bool AddBoardPopupPage(int menu_ref_id
                            , int sort_order
                            , string use_yn
                            , DateTime create_date
                            , int create_user)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                
                affectedRow = _boardPopupPage.Insert(  conn
                                            , trx
                                            , menu_ref_id
                                            , sort_order
                                            , use_yn
                                            , create_date
                                            , create_user);

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
         
        public bool RemoveBoardPopupPage( int meun_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _boardPopupPage.Delete(  null
                                        , null
                                        , meun_ref_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
