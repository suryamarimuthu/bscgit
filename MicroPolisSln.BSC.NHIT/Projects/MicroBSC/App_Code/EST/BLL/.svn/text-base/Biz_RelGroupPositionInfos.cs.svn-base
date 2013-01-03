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
    public class Biz_RelGroupPositionInfos
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_rel_grp_pos_id;
        private string 	_rel_grp_id;
        private string 	_est_id;
        private int 	_estterm_ref_id;
        private string 	_rel_grp_pos_name;
        private string 	_rel_grp_pos_desc;
        private string 	_opt_value;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_RelGroupPositionInfos _relGroupPosInfo = new Dac_RelGroupPositionInfos();

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
         
        public string Rel_Grp_Pos_Name
        {
	        get 
	        {
		        return _rel_grp_pos_name;
	        }
	        set
	        {
		        _rel_grp_pos_name = ( value==null ? "" : value );
	        }
        }
         
        public string Rel_Grp_Pos_Desc
        {
	        get 
	        {
		        return _rel_grp_pos_desc;
	        }
	        set
	        {
		        _rel_grp_pos_desc = ( value==null ? "" : value );
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
         
        public Biz_RelGroupPositionInfos()
        {
            
        }

        public Biz_RelGroupPositionInfos(int comp_id, string rel_grp_pos_id)
        {
            DataSet ds = GetRelGroupPosInfo(  comp_id
                                            , rel_grp_pos_id
                                            , ""
                                            , ""
                                            , 0);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _rel_grp_pos_id     = (dr["REL_GRP_POS_ID"]     == DBNull.Value) ? "" : (string) dr["REL_GRP_POS_ID"];
		        _rel_grp_id         = (dr["REL_GRP_ID"]         == DBNull.Value) ? "" : (string) dr["REL_GRP_ID"];
		        _est_id             = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _rel_grp_pos_name   = (dr["REL_GRP_POS_NAME"]   == DBNull.Value) ? "" : (string) dr["REL_GRP_POS_NAME"];
		        _rel_grp_pos_desc   = (dr["REL_GRP_POS_DESC"]   == DBNull.Value) ? "" : (string) dr["REL_GRP_POS_DESC"];
		        _opt_value          = (dr["OPT_VALUE"]          == DBNull.Value) ? "" : (string) dr["OPT_VALUE"];
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyRelGroupPosInfo(int comp_id
                                        , string rel_grp_pos_id
                                        , string rel_grp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , string rel_grp_pos_name
                                        , string rel_grp_pos_desc
                                        , string opt_value
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupPosInfo.Update(null
                                                , null
                                                , comp_id
                                                , rel_grp_pos_id
                                                , rel_grp_id
                                                , est_id
                                                , estterm_ref_id
                                                , rel_grp_pos_name
                                                , rel_grp_pos_desc
                                                , opt_value
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetRelGroupPosInfo(int comp_id
                                        , string rel_grp_pos_id
                                        , string rel_grp_id
                                        , string est_id
                                        , int estterm_ref_id)
        {
	        return _relGroupPosInfo.Select(null
                                        , null
                                        , comp_id
                                        , rel_grp_pos_id
                                        , rel_grp_id
                                        , est_id
                                        , estterm_ref_id);
        }
         
        public bool AddRelGroupPosInfo(   int comp_id
                                        , string rel_grp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , string rel_grp_pos_name
                                        , string rel_grp_pos_desc
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
                Dac_KeyGens keyGen      = new Dac_KeyGens();
                string rel_grp_pos_id   = keyGen.GetCode(conn, trx, "EST_REL_GROUP_POS_INFO");

                affectedRow = _relGroupPosInfo.Insert(conn
                                                    , trx
                                                    , comp_id
                                                    , rel_grp_pos_id
                                                    , rel_grp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , rel_grp_pos_name
                                                    , rel_grp_pos_desc
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
         
        public bool RemoveRelGroupPosInfo( DataTable dataTable)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _relGroupPosInfo.Delete(   conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , dataRow["REL_GRP_POS_ID"].ToString());

                    Dac_RelGroupPositionDatas dacDatas = new Dac_RelGroupPositionDatas();
                    dacDatas.Delete(conn
                                  , trx
                                  , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                  , dataRow["REL_GRP_POS_ID"].ToString());
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

        public bool RemoveRelGroupPosInfo(int comp_id, string rel_grp_pos_id)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupPosInfo.Delete(null
                                                , null
                                                , comp_id
                                                , rel_grp_pos_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(  int comp_id
                            , string rel_grp_pos_id
                            , string rel_grp_id
                            , string est_id
                            , int estterm_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupPosInfo.Count( comp_id
                                                , rel_grp_pos_id
                                                , rel_grp_id
                                                , est_id
                                                , estterm_ref_id);

            return (affectedRow > 0) ? true : false;
        }

        public int Count( int comp_id
                        , string rel_grp_pos_id
                        , string rel_grp_id
                        , string est_id
                        , int estterm_ref_id)
        {
            return _relGroupPosInfo.Count(comp_id
                                        , rel_grp_pos_id
                                        , rel_grp_id
                                        , est_id
                                        , estterm_ref_id);

        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("REL_GRP_POS_ID", typeof(string));
            dataTable.Columns.Add("REL_GRP_ID", typeof(string));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("REL_GRP_POS_NAME", typeof(string));
            dataTable.Columns.Add("REL_GRP_POS_DESC", typeof(string));
            dataTable.Columns.Add("OPT_VALUE", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }
    }
}
