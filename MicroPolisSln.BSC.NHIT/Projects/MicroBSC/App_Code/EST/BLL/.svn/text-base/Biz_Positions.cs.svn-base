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
	public class Biz_Positions
	{
		#region ============================== [Fields] ================

		private string _position_table_name;
		private string _pos;
		private string _pos_id;
		private string _pos_name;

		private Dac_Positions _dac_positions = new Dac_Positions();

		#endregion

		#region ============================== [Properties] ==============

		public string PositionTableName
		{
			get
			{
				return _position_table_name;
			}
		}

		public string Pos
		{
			get
			{
				return _pos;
			}
		}

		public string PosID
		{
			get
			{
				return _pos_id;
			}
			set
			{
				_pos_id = ( value == null ? "" : value );
			}
		}

		public string PosName
		{
			get
			{
				return _pos_name;
			}
			set
			{
				_pos_name = ( value == null ? "" : value );
			}
		}

		#endregion

        public Biz_Positions() 
        {
        
        }

		public Biz_Positions( string strPosTableName
							, string strPos )
		{
			_position_table_name    = strPosTableName;
			_pos                    = strPos;
		}

		public Biz_Positions( string strPosTableName
							, string strPos
							, string strPosID )
		{
			_position_table_name    = strPosTableName;
			_pos                    = strPos;
			
			DataSet ds = _dac_positions.Select( _position_table_name
                                                , _pos
												, strPosID);
			DataRow dr;

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				dr          = ds.Tables[0].Rows[0];

				_pos_id     = ( dr["POS_ID"]      == DBNull.Value ) ? "" : (string)dr["POS_ID"];
				_pos_name   = ( dr["POS_NAME"]    == DBNull.Value ) ? "" : (string)dr["POS_NAME"];
			}
		}

		public DataSet GetPositions()
		{
			DataSet dtReturn = _dac_positions.Select( _position_table_name, _pos, string.Empty );
			return dtReturn;
		}

		public DataSet GetPosition( string strPosID )
		{
			DataSet dtReturn = _dac_positions.Select( _position_table_name, _pos, strPosID );
			return dtReturn;
		}

		public DataTable GetPositionAll()
		{
			Biz_PositionInfos positionInfos = new Biz_PositionInfos();
			DataSet dsPositionInfo = positionInfos.GetPositionInfos();
			string strPositionTableName = string.Empty;
			string strPosID = string.Empty;

			DataTable dtReturn = new DataTable();
			dtReturn.Columns.Add( "POS", typeof(string) );
			dtReturn.Columns.Add( "POS_ID", typeof(string) );
			dtReturn.Columns.Add( "POS_NAME", typeof(string) );
            //dtReturn.Columns.Add( "CREATE_DATE", typeof(DateTime) );
            //dtReturn.Columns.Add( "CREATE_USER", typeof(int) );
            //dtReturn.Columns.Add( "UPDATE_DATE", typeof(DateTime) );
            //dtReturn.Columns.Add( "UPDATE_USER", typeof(int) );


			for ( int i = 0; i < dsPositionInfo.Tables[0].Rows.Count; i++ )
			{
                DataTable dtPosition = _dac_positions.Select(dsPositionInfo.Tables[0].Rows[i]["POS_TABLE_NAME"].ToString()
                                                    , dsPositionInfo.Tables[0].Rows[i]["POS_ID"].ToString()
                                                    , string.Empty).Tables[0];
                dtReturn.Merge(dtPosition);
			}

            
            
			return dtReturn;
		}

		public bool IsExist( string strPosID )
		{
			DataSet ds = _dac_positions.Select( _position_table_name, _pos, strPosID );
			return ( ds.Tables[0].Rows.Count == 1 ) ? true : false;
		}

		public bool AddPositions( string strPosId
								, string strPosName
								, DateTime create_date
								, int create_user )
		{

			int affectedRow = 0;

			if ( IsExist( strPosId ) == false )
			{
				affectedRow = _dac_positions.Insert(  null
                                                    , null
                                                    , _position_table_name
                                                    , _pos
													, strPosId
													, strPosName
													, create_date
													, create_user );
			}

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool ModifyPositions(  string strPosID
									, string strPosName
									, DateTime update_date
									, int update_user )
		{
			int affectedRow = 0;

			affectedRow = _dac_positions.Update(  null
                                                , null
                                                , _position_table_name
                                                , _pos
											    , strPosID
											    , strPosName
											    , update_date
											    , update_user );

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool RemovePositions( string strPosID )
		{
			int affectedRow = 0;

			affectedRow = _dac_positions.Delete(  null
                                                , null
                                                , _position_table_name
                                                , _pos
                                                , strPosID );

			if ( affectedRow > 0 )
				return true;

			return false;
		}
	}
}