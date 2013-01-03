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
    public class Biz_PositionBizQuestionSubjectMaps
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_est_id;
        private string 	_pos_biz_id;
        private string 	_q_sbj_id;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_PositionBizQuestionSubjectMaps _positionBizQuestionSubMap = new Dac_PositionBizQuestionSubjectMaps();

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

        public string Pos_Biz_ID
        {
	        get 
	        {
		        return _pos_biz_id;
	        }
	        set
	        {
		        _pos_biz_id = ( value==null ? "" : value );
	        }
        }
         
        public string Q_Sbj_ID
        {
	        get 
	        {
		        return _q_sbj_id;
	        }
	        set
	        {
		        _q_sbj_id = ( value==null ? "" : value );
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
         
        public Biz_PositionBizQuestionSubjectMaps()
	    {
		    
	    }
    
        public Biz_PositionBizQuestionSubjectMaps(int comp_id
                                                , string est_id
                                                , string pos_biz_id
                                                , string q_sbj_id)
	    {
            DataSet ds = _positionBizQuestionSubMap.Select(comp_id, est_id, pos_biz_id, q_sbj_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
                _comp_id        = (dr["COMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id         = (dr["EST_ID"]         == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _pos_biz_id     = (dr["POS_BIZ_ID"]     == DBNull.Value) ? "" : (string) dr["POS_BIZ_ID"];
		        _q_sbj_id       = (dr["Q_SBJ_ID"]       == DBNull.Value) ? "" : (string) dr["Q_SBJ_ID"];
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyPosBizQuestionSbjMap(int comp_id
                                            , string est_id
                                            , string pos_biz_id
                                            , string q_sbj_id
                                            , DateTime update_date
                                            , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _positionBizQuestionSubMap.Update(null
                                                            , null
                                                            , comp_id
                                                            , est_id
                                                            , pos_biz_id
                                                            , q_sbj_id
                                                            , update_date
                                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetPosBizQuestionSbjMap(int comp_id, string est_id, string pos_biz_id, string q_sbj_id)
        {
	        return _positionBizQuestionSubMap.Select(comp_id, est_id, pos_biz_id, q_sbj_id);
        }
         
        public bool AddPosBizQuestionSbjMap(  int comp_id
                                            , string est_id
                                            , string pos_biz_id
                                            , string q_sbj_id
                                            , DateTime create_date
                                            , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _positionBizQuestionSubMap.Insert(null
                                                        , null
                                                        , comp_id
                                                        , est_id
                                                        , pos_biz_id
                                                        , q_sbj_id
                                                        , create_date
                                                        , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool SavePosBizQuestionSbjMap(DataTable dataTable, int comp_id, string est_id, string pos_biz_id)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow     += _positionBizQuestionSubMap.Delete( conn
                                                                    , trx
                                                                    , comp_id
                                                                    , est_id
                                                                    , pos_biz_id
                                                                    , "");
                                            
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                     affectedRow     += _positionBizQuestionSubMap.Insert(conn
                                                                        , trx
                                                                        , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                                        , DataTypeUtility.GetValue(dataRow["EST_ID"])
                                                                        , DataTypeUtility.GetValue(dataRow["POS_BIZ_ID"])
                                                                        , DataTypeUtility.GetValue(dataRow["Q_SBJ_ID"])
                                                                        , DataTypeUtility.GetToDateTime(dataRow["DATE"])
                                                                        , DataTypeUtility.GetToInt32(dataRow["USER"]));
                }

				trx.Commit();
			}
			catch ( Exception ex )
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
         
        public bool RemovePosBizQuestionSbjMap(int comp_id
                                             , string est_id
                                             , string pos_biz_id
                                             , string q_sbj_id)
        {
	        int affectedRow = 0;

            affectedRow = _positionBizQuestionSubMap.Delete(null
                                                        , null
                                                        , comp_id
                                                        , est_id
                                                        , pos_biz_id
                                                        , q_sbj_id);

            return (affectedRow > 0) ? true : false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("POS_BIZ_ID", typeof(string));
            dataTable.Columns.Add("Q_SBJ_ID", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
