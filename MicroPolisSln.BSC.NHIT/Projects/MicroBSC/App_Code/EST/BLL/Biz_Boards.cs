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
    public class Biz_Boards
    {
        #region ============================== [Fields] ==============================
 
        private string 	_board_id;
        private string 	_board_category_id;
        private string 	_subject_text;
        private string 	_content_text;
        private int 	_read_count;
        private string 	_attach_no;
        private string 	_p_board_id;
        private string 	_group_id;
        private int 	_level_id;
        private int 	_seq_id;
        private DateTime 	_start_date;
        private DateTime 	_end_date;
        private int      _menu_ref_id;
        private string 	_pop_up_yn;
        private int 	_write_emp_id;
        private string  _write_emp_name;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_Boards _board = new Dac_Boards();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Board_ID
        {
	        get 
	        {
		        return _board_id;
	        }
	        set
	        {
		        _board_id = ( value==null ? "" : value );
	        }
        }
         
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
                
        public string Subject_Text
        {
	        get 
	        {
		        return _subject_text;
	        }
	        set
	        {
		        _subject_text = ( value==null ? "" : value );
	        }
        }
         
        public string Content_Text
        {
	        get 
	        {
		        return _content_text;
	        }
	        set
	        {
		        _content_text = ( value==null ? "" : value );
	        }
        }
         
        public int Read_Count
        {
	        get 
	        {
		        return _read_count;
	        }
	        set
	        {
		        _read_count = value;
	        }
        }
         
        public string Attach_No
        {
	        get 
	        {
		        return _attach_no;
	        }
	        set
	        {
		        _attach_no = ( value==null ? "" : value );
	        }
        }
         
        public string P_Board_ID
        {
	        get 
	        {
		        return _p_board_id;
	        }
	        set
	        {
		        _p_board_id = ( value==null ? "" : value );
	        }
        }
         
        public string Group_ID
        {
	        get 
	        {
		        return _group_id;
	        }
	        set
	        {
		        _group_id = ( value==null ? "" : value );
	        }
        }
         
        public int Level_ID
        {
	        get 
	        {
		        return _level_id;
	        }
	        set
	        {
		        _level_id = value;
	        }
        }
         
        public int Seq_ID
        {
	        get 
	        {
		        return _seq_id;
	        }
	        set
	        {
		        _seq_id = value;
	        }
        }
         
        public DateTime Start_Date
        {
	        get 
	        {
		        return _start_date;
	        }
	        set
	        {
		        _start_date = value;
	        }
        }
         
        public DateTime End_Date
        {
	        get 
	        {
		        return _end_date;
	        }
	        set
	        {
		        _end_date = value;
	        }
        }

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
         
        public string Pop_Up_YN
        {
	        get 
	        {
		        return _pop_up_yn;
	        }
	        set
	        {
		        _pop_up_yn = ( value==null ? "" : value );
	        }
        }
         
        public int Write_Emp_ID
        {
	        get 
	        {
		        return _write_emp_id;
	        }
	        set
	        {
		        _write_emp_id = value;
	        }
        }

        public string Write_Emp_Name
        {
            get
            {
                return _write_emp_name;
            }
            set
            {
                _write_emp_name = (value == null ? "" : value);
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
         
        public Biz_Boards()
	    {
		    
	    }

        public Biz_Boards(string board_id, string board_category_id)
	    {
            DataSet ds = _board.Select(board_id, board_category_id, 0, "");
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];
		        _board_id           = DataTypeUtility.GetValue(dr["BOARD_ID"]);
		        _board_category_id  = DataTypeUtility.GetValue(dr["BOARD_CATEGORY_ID"]);
		        _subject_text       = DataTypeUtility.GetValue(dr["SUBJECT_TEXT"]);
		        _content_text       = DataTypeUtility.GetValue(dr["CONTENT_TEXT"]);
		        _read_count         = DataTypeUtility.GetToInt32(dr["READ_COUNT"]);
		        _attach_no          = DataTypeUtility.GetValue(dr["ATTACH_NO"]);
		        _p_board_id         = DataTypeUtility.GetValue(dr["P_BOARD_ID"]);
		        _group_id           = DataTypeUtility.GetValue(dr["GROUP_ID"]);
		        _level_id           = DataTypeUtility.GetToInt32(dr["LEVEL_ID"]);
		        _seq_id             = DataTypeUtility.GetToInt32(dr["SEQ_ID"]);
		        _start_date         = DataTypeUtility.GetToDateTime(dr["START_DATE"]);
		        _end_date           = DataTypeUtility.GetToDateTime(dr["END_DATE"]);
                _menu_ref_id        = DataTypeUtility.GetToInt32(dr["MENU_REF_ID"]);
		        _pop_up_yn          = DataTypeUtility.GetValue(dr["POP_UP_YN"]);
		        _write_emp_id       = DataTypeUtility.GetToInt32(dr["WRITE_EMP_ID"]);
                _write_emp_name     = DataTypeUtility.GetValue(dr["WRITE_EMP_NAME"]);
		        _update_date        = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
		        _update_user        = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyBoard(  string board_id
                                , string board_category_id
                                , string subject_text
                                , string content_text
                                , int read_count
                                , string attach_no
                                , string p_board_id
                                , string group_id
                                , int level_id
                                , int seq_id
                                , object start_date
                                , object end_date
                                , int menu_ref_id
                                , string pop_up_yn
                                , int write_emp_id
                                , DateTime update_date
                                , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _board.Update(  null
                                        , null
                                        , board_id
                                        , board_category_id
                                        , subject_text
                                        , content_text
                                        , read_count
                                        , attach_no
                                        , p_board_id
                                        , group_id
                                        , level_id
                                        , seq_id
                                        , start_date
                                        , end_date
                                        , menu_ref_id
                                        , pop_up_yn
                                        , write_emp_id
                                        , update_date
                                        , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetBoard(string board_id, string board_category_id, int menu_ref_id, string popup_yn)
        {
            return _board.Select(board_id, board_category_id, menu_ref_id, popup_yn);
        }
         
        public bool AddBoard( string board_category_id
                            , string subject_text
                            , string content_text
                            , int read_count
                            , string attach_no
                            , string p_board_id
                            , string group_id
                            , int level_id
                            , int seq_id
                            , object start_date
                            , object end_date
                            , int menu_ref_id
                            , string pop_up_yn
                            , int write_emp_id
                            , DateTime create_date
                            , int create_user)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Dac_KeyGens keyGen  = new Dac_KeyGens();
                string board_id     = keyGen.GetCode(conn, trx, "EST_BOARD");

                affectedRow = _board.Insert(  conn
                                            , trx
                                            , board_id.Trim()
                                            , board_category_id
                                            , subject_text
                                            , content_text
                                            , read_count
                                            , attach_no
                                            , p_board_id
                                            , group_id
                                            , level_id
                                            , seq_id
                                            , start_date
                                            , end_date
                                            , menu_ref_id
                                            , pop_up_yn
                                            , write_emp_id
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

        public bool RemoveBoard(string board_id, string board_category_id)
        {
	        int affectedRow = 0;

            affectedRow = _board.Delete(  null
                                        , null
                                        , board_id
                                        , board_category_id);

            return (affectedRow > 0) ? true : false;
        }
        
    }
}
