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
    public class Biz_PositionInfos
    {
        #region ============================== [Fields] ==============================

        private string	_pos_id;
		private string	_pos_name;
        private string 	_pos_table_name;
        private string 	_pos_type_name;
        private string 	_use_yn;
        private DateTime 	_create_date;
        private int 	_create_user;
        private DateTime 	_update_date;
        private int 	_update_user;

        Dac_PositionInfos _dac_positionInfo = new Dac_PositionInfos();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Position_ID
        {
            get 
            {
	            return _pos_id;
            }
            set
            {
	            _pos_id = ( value==null ? "" : value );
            }
        }
         
        public string Position_Name
        {
            get 
            {
	            return _pos_name;
            }
            set
            {
	            _pos_name = ( value==null ? "" : value );
            }
        }
         
        public string Position_Table_Name
        {
            get 
            {
	            return _pos_table_name;
            }
            set
            {
	            _pos_table_name = ( value==null ? "" : value );
            }
        }

        public string Position_Type_Name
        {
            get 
            {
	            return _pos_type_name;
            }
            set
            {
	            _pos_type_name = ( value==null ? "" : value );
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
                 
        public DateTime Create_Date
        {
            get 
            {
	            return _create_date;
            }
            set
            {
	            _create_date = value;
            }
        }
         
        public int Create_User
        {
            get 
            {
	            return _create_user;
            }
            set
            {
	            _create_user = value;
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
         
        public Biz_PositionInfos()
        {
        }

        public Biz_PositionInfos( string pos_id )
        {
            DataSet ds = GetPositionInfoByPosID( pos_id );
            DataRow dr;
             
            if ( ds.Tables[0].Rows.Count == 1 )
            {
	            dr                      = ds.Tables[0].Rows[0];

	            _pos_id            = (dr["POS_ID"]            == DBNull.Value) ? "" : (string) dr["POS_ID"];
	            _pos_name          = (dr["POS_NAME"]          == DBNull.Value) ? "" : (string) dr["POS_NAME"];
	            _pos_table_name    = (dr["POS_TABLE_NAME"]    == DBNull.Value) ? "" : (string) dr["POS_TABLE_NAME"];
	            _pos_type_name     = (dr["POS_TYPE_NAME"]     == DBNull.Value) ? "" : (string) dr["POS_TYPE_NAME"];
	            _use_yn            = (dr["USE_YN"]            == DBNull.Value) ? "" : (string) dr["USE_YN"];
	            _create_date       = (dr["CREATE_DATE"]       == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
	            _create_user       = (dr["CREATE_USER"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
	            _update_date       = (dr["UPDATE_DATE"]       == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
	            _update_user       = (dr["UPDATE_USER"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public DataSet GetPositionInfos()
        {
            return _dac_positionInfo.Select("", "", "", "", "");
        }

        public DataSet GetPositionInfoByPosID(string pos_id)
        {
            return _dac_positionInfo.Select(pos_id, "", "", "", "" );
        }

        public DataSet GetPositionInfoByUseYN(string use_yn)
        {
            return _dac_positionInfo.Select("", "", "", "", use_yn);
        }
        
		public bool ModifyPositionID( string strIdxs
									, DateTime update_date
									, int update_user )
		{
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow	= 0;
			try
			{
				affectedRow = _dac_positionInfo.UpdateByINPosId(  conn
																, trx
																, strIdxs
																, update_date
																, update_user );

				affectedRow += _dac_positionInfo.UpdateByNotINPosId(  conn
																	, trx
																	, strIdxs
																	, update_date
																	, update_user );

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

			return ( affectedRow > 0 ) ? true : false;
		}

        public bool AddPositionInfo(  string pos_id
									, string pos_name
                                    , string pos_table_name
                                    , string pos_type_name
                                    , string use_yn
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            affectedRow     = _dac_positionInfo.Insert(null
                                                    , null
                                                    , pos_id
													, pos_name
                                                    , pos_table_name
                                                    , pos_type_name
                                                    , use_yn
                                                    , create_date
                                                    , create_user );

            return ( affectedRow > 0 ) ? true : false;
        }


        public bool RemovePositioninfo( string pos_id )
        {
            int affectedRow = 0;

            affectedRow     = _dac_positionInfo.Delete(null, null, pos_id );

            return ( affectedRow > 0 ) ? true : false;
        }
    }
}
