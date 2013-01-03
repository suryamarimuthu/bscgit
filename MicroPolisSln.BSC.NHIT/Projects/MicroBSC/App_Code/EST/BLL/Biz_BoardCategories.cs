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
    public class Biz_BoardCategories
    {
        #region ============================== [Fields] ==============================
 
        private string 	_board_category_id;
        private string 	_board_categroy_name;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_BoardCategories _boardCategory = new Dac_BoardCategories();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Board_Category_ID
        {
	        get 
	        {
		        return _board_category_id;
	        }
	        set
	        {
		        _board_category_id = ( value==null ? "" : value );
	        }
        }
         
        public string Board_Categroy_Name
        {
	        get 
	        {
		        return _board_categroy_name;
	        }
	        set
	        {
		        _board_categroy_name = ( value==null ? "" : value );
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
         
        public Biz_BoardCategories()
	    {
		    
	    }

        public Biz_BoardCategories(string board_category_id)
	    {
            DataSet ds = _boardCategory.Select(board_category_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                      = ds.Tables[0].Rows[0];
		        _board_category_id      = DataTypeUtility.GetValue(dr["BOARD_CATEGORY_ID"]);
		        _board_categroy_name    = DataTypeUtility.GetValue(dr["BOARD_CATEGROY_NAME"]);
		        _update_date            = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
		        _update_user            = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyBoardCategory(  string board_category_id
                                        , string board_categroy_name
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _boardCategory.Update(  null
                                                , null
                                                , board_category_id
                                                , board_categroy_name
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetBoardCategory( string board_category_id)
        {
            return _boardCategory.Select(board_category_id);
        }
         
        public bool AddBoardCategory( string board_category_id
                                    , string board_categroy_name
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _boardCategory.Insert(  null
                                                , null
                                                , board_category_id
                                                , board_categroy_name
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveBoardCategory( string board_category_id)
        {
	        int affectedRow = 0;

            affectedRow = _boardCategory.Delete(null, null, board_category_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
