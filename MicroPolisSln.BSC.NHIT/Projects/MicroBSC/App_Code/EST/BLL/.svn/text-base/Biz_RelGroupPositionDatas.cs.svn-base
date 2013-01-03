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
    public class Biz_RelGroupPositionDatas
    {
        #region ============================== [Fields] ==============================
 
        private int     _comp_id;
        private string 	_rel_grp_pos_data_id;
        private string 	_rel_grp_id;
        private string 	_rel_grp_pos_id;
        private string 	_est_id;
        private int 	_estterm_ref_id;
        private string 	_pos_id;
        private string 	_pos_id_name;
        private string 	_pos_value;
        private string 	_pos_value_name;
        private string 	_opt_value;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_RelGroupPositionDatas _relGroupPosData = new Dac_RelGroupPositionDatas();

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
         
        public string Rel_Grp_Pos_Data_ID
        {
	        get 
	        {
		        return _rel_grp_pos_data_id;
	        }
	        set
	        {
		        _rel_grp_pos_data_id = ( value==null ? "" : value );
	        }
        }
         
        public string Rel_Grp_ID
        {
	        get 
	        {
		        return _rel_grp_id;
	        }
	        set
	        {
		        _rel_grp_id = ( value==null ? "" : value );
	        }
        }
         
        public string Rel_Grp_Pos_ID
        {
	        get 
	        {
		        return _rel_grp_pos_id;
	        }
	        set
	        {
		        _rel_grp_pos_id = ( value==null ? "" : value );
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
         
        public string Pos_ID
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

        public string Pos_ID_Name
        {
	        get 
	        {
		        return _pos_id_name;
	        }
	        set
	        {
		        _pos_id_name = ( value==null ? "" : value );
	        }
        }
         
        public string Pos_Value
        {
	        get 
	        {
		        return _pos_value;
	        }
	        set
	        {
		        _pos_value = ( value==null ? "" : value );
	        }
        }

        public string Pos_Value_Name
        {
	        get 
	        {
		        return _pos_value_name;
	        }
	        set
	        {
		        _pos_value_name = ( value==null ? "" : value );
	        }
        }
         
        public string Opt_Value
        {
	        get 
	        {
		        return _opt_value;
	        }
	        set
	        {
		        _opt_value = ( value==null ? "" : value );
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
         
        public Biz_RelGroupPositionDatas()
        {
            
        }

        public Biz_RelGroupPositionDatas( int comp_id
                                        , string rel_grp_pos_data_id
                                        , string rel_grp_id
                                        , string rel_grp_pos_id
                                        , string est_id
                                        , int estterm_ref_id)
        {
            DataSet ds = GetRelGroupPosData(  comp_id
                                            , rel_grp_pos_data_id
                                            , rel_grp_id
                                            , rel_grp_pos_id
                                            , est_id
                                            , estterm_ref_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr = ds.Tables[0].Rows[0];

                _comp_id                = (dr["COMP_ID"]                == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _rel_grp_pos_data_id    = (dr["REL_GRP_POS_DATA_ID"]    == DBNull.Value) ? "" : (string) dr["REL_GRP_POS_DATA_ID"];
		        _rel_grp_id             = (dr["REL_GRP_ID"]             == DBNull.Value) ? "" : (string) dr["REL_GRP_ID"];
		        _rel_grp_pos_id         = (dr["REL_GRP_POS_ID"]         == DBNull.Value) ? "" : (string) dr["REL_GRP_POS_ID"];
		        _est_id                 = (dr["EST_ID"]                 == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_ref_id         = (dr["ESTTERM_REF_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _pos_id                 = (dr["POS_ID"]                 == DBNull.Value) ? "" : (string) dr["POS_ID"];
                _pos_id_name            = (dr["POS_ID_NAME"]            == DBNull.Value) ? "" : (string) dr["POS_ID_NAME"];
		        _pos_value              = (dr["POS_VALUE"]              == DBNull.Value) ? "" : (string) dr["POS_VALUE"];
                _pos_value_name         = (dr["POS_VALUE_NAME"]         == DBNull.Value) ? "" : (string) dr["POS_VALUE_NAME"];
		        _opt_value              = (dr["OPT_VALUE"]              == DBNull.Value) ? "" : (string) dr["OPT_VALUE"];
		        _update_date            = (dr["UPDATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user            = (dr["UPDATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyRelGroupPosData(int comp_id
                                        , string rel_grp_pos_data_id
                                        , string rel_grp_id
                                        , string rel_grp_pos_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , string pos_id
                                        , string pos_id_name
                                        , string pos_value
                                        , string pos_value_name
                                        , string opt_value
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupPosData.Update(null
                                                , null
                                                , comp_id
                                                , rel_grp_pos_data_id
                                                , rel_grp_id
                                                , rel_grp_pos_id
                                                , est_id
                                                , estterm_ref_id
                                                , pos_id
                                                , pos_id_name
                                                , pos_value
                                                , pos_value_name
                                                , opt_value
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetRelGroupPosData(int comp_id
                                        , string rel_grp_pos_data_id
                                        , string rel_grp_id
                                        , string rel_grp_pos_id
                                        , string est_id
                                        , int estterm_ref_id)
        {
	        return _relGroupPosData.Select(   null
                                            , null
                                            , comp_id
                                            , rel_grp_pos_data_id
                                            , rel_grp_id
                                            , rel_grp_pos_id
                                            , est_id
                                            , estterm_ref_id);
        }
         
        public bool AddRelGroupPosData(   int comp_id
                                        , string rel_grp_id
                                        , string rel_grp_pos_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , string pos_id
                                        , string pos_id_name
                                        , string pos_value
                                        , string pos_value_name
                                        , string opt_value
                                        , DateTime create_date
                                        , int create_user)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Dac_KeyGens keyGen          = new Dac_KeyGens();
                string rel_grp_pos_data_id  = keyGen.GetCode(conn, trx, "EST_REL_GROUP_POS_DATA");

                if(_relGroupPosData.Count(conn
                                        , trx
                                        , comp_id
                                        , ""
                                        , rel_grp_id
                                        , rel_grp_pos_id
                                        , est_id
                                        , estterm_ref_id
                                        , pos_id
                                        , pos_value) > 0)
                {
                    trx.Rollback();
                    return false;
                }

                affectedRow = _relGroupPosData.Insert(conn
                                                    , trx
                                                    , comp_id
                                                    , rel_grp_pos_data_id
                                                    , rel_grp_id
                                                    , rel_grp_pos_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , pos_id
                                                    , pos_id_name
                                                    , pos_value
                                                    , pos_value_name
                                                    , opt_value
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
         
        public bool RemoveRelGroupPosData(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _relGroupPosData.Delete(   conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , dataRow["REL_GRP_POS_DATA_ID"].ToString()
                                                            , "");
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

        public bool RemoveRelGroupPosData(int comp_id, string rel_grp_pos_data_id, string rel_grp_id)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupPosData.Delete(null
                                                , null
                                                , comp_id
                                                , rel_grp_pos_data_id
                                                , rel_grp_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(  int comp_id
                            , string rel_grp_pos_data_id
                            , string rel_grp_id
                            , string rel_grp_pos_id
                            , string est_id
                            , int estterm_ref_id
                            , string pos_id
                            , string pos_value)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupPosData.Count( null
                                                , null
                                                , comp_id
                                                , rel_grp_pos_data_id
                                                , rel_grp_id
                                                , rel_grp_pos_id
                                                , est_id
                                                , estterm_ref_id
                                                , pos_id
                                                , pos_value);

            return (affectedRow > 0) ? true : false;
        }

        public int Count( int comp_id
                        , string rel_grp_pos_data_id
                        , string rel_grp_id
                        , string rel_grp_pos_id
                        , string est_id
                        , int estterm_ref_id
                        , string pos_id
                        , string pos_value)
        {
            return _relGroupPosData.Count(null
                                        , null
                                        , comp_id
                                        , rel_grp_pos_data_id
                                        , rel_grp_id
                                        , rel_grp_pos_id
                                        , est_id
                                        , estterm_ref_id
                                        , pos_id
                                        , pos_value);
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("REL_GRP_POS_DATA_ID", typeof(string));
            dataTable.Columns.Add("REL_GRP_ID", typeof(string));
            dataTable.Columns.Add("REL_GRP_POS_ID", typeof(string));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("POS_ID", typeof(string));
            dataTable.Columns.Add("POS_VALUE", typeof(string));
            dataTable.Columns.Add("OPT_VALUE", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
