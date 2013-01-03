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
    public class Biz_RelGroupInfos
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_rel_grp_id;
        private string 	_est_id;
        private int 	_estterm_ref_id;
        private string 	_rel_grp_name;
        private string 	_rel_grp_desc;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_RelGroupInfos _relGroupInfo             = new Dac_RelGroupInfos();
        private Dac_RelGroupDepts _relGroupDept             = new Dac_RelGroupDepts();
        private Dac_RelGroupPositionInfos _relGroupPosInfo  = new Dac_RelGroupPositionInfos();
        private Dac_RelGroupPositionDatas _relGroupPosData  = new Dac_RelGroupPositionDatas();
        private Dac_RelGroupTgtMaps _relGroupTgtMap         = new Dac_RelGroupTgtMaps();

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
         
        public string Rel_Grp_Name
        {
	        get 
	        {
		        return _rel_grp_name;
	        }
	        set
	        {
		        _rel_grp_name = ( value==null ? "" : value );
	        }
        }
         
        public string Rel_Grp_Desc
        {
	        get 
	        {
		        return _rel_grp_desc;
	        }
	        set
	        {
		        _rel_grp_desc = ( value==null ? "" : value );
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
         
        public Biz_RelGroupInfos()
        {
            
        }

        public Biz_RelGroupInfos(int comp_id, string rel_grp_id)
        {
            DataSet ds = GetRelGroupInfo(comp_id, rel_grp_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];

                _comp_id        = (dr["COMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _rel_grp_id     = (dr["REL_GRP_ID"]     == DBNull.Value) ? "" : (string) dr["REL_GRP_ID"];
		        _est_id         = (dr["EST_ID"]         == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _rel_grp_name   = (dr["REL_GRP_NAME"]   == DBNull.Value) ? "" : (string) dr["REL_GRP_NAME"];
		        _rel_grp_desc   = (dr["REL_GRP_DESC"]   == DBNull.Value) ? "" : (string) dr["REL_GRP_DESC"];
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyRelGroupInfo(int comp_id
                                    , string rel_grp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , string rel_grp_name
                                    , string rel_grp_desc
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _relGroupInfo.Update(   null
                                                , null
                                                , comp_id
                                                , rel_grp_id
                                                , est_id
                                                , estterm_ref_id
                                                , rel_grp_name
                                                , rel_grp_desc
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetRelGroupInfos(int comp_id)
        {
	        return _relGroupInfo.Select(null, null, comp_id, "", "", 0);
        }
         
        public DataSet GetRelGroupInfo(int comp_id, string rel_grp_id)
        {
	        return _relGroupInfo.Select(null, null, comp_id, rel_grp_id, "", 0);
        }

        public DataSet GetRelGroupInfo(int comp_id
                                    , string rel_grp_id
                                    , string est_id
                                    , int estterm_ref_id)
        {
	        return _relGroupInfo.Select(null, null, comp_id, rel_grp_id, est_id, estterm_ref_id);
        }
         
        public bool AddRelGroupInfo(  int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , string rel_grp_name
                                    , string rel_grp_desc
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
                string rel_grp_id   = keyGen.GetCode(conn, trx, "EST_REL_GROUP_INFO");

                affectedRow = _relGroupInfo.Insert(   conn
                                                    , trx
                                                    , comp_id
                                                    , rel_grp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , rel_grp_name
                                                    , rel_grp_desc
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

        public bool CopyDataFromTo(   int comp_id
                                    , int estterm_ref_id_from
                                    , int estterm_ref_id_to
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            Dac_KeyGens keyGen  = new Dac_KeyGens();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                DataTable dtRelGrpInfo = _relGroupInfo.Select(conn, trx, comp_id, "", "", estterm_ref_id_from).Tables[0];

                foreach(DataRow drRelGrpInfo in dtRelGrpInfo.Rows) 
                {
                    string rel_grp_id   = keyGen.GetCode(conn, trx, "EST_REL_GROUP_INFO");

                    affectedRow += _relGroupInfo.Insert(  conn
                                                        , trx
                                                        , comp_id
                                                        , rel_grp_id
                                                        , DataTypeUtility.GetValue(drRelGrpInfo["EST_ID"])
                                                        , estterm_ref_id_to
                                                        , DataTypeUtility.GetValue(drRelGrpInfo["REL_GRP_NAME"])
                                                        , DataTypeUtility.GetValue(drRelGrpInfo["REL_GRP_DESC"])
                                                        , create_date
                                                        , create_user);

                    DataTable dtRelGrpDept =  _relGroupDept.Select(   conn
                                                                    , trx
                                                                    , comp_id
                                                                    , DataTypeUtility.GetValue(drRelGrpInfo["REL_GRP_ID"])
                                                                    , 0
                                                                    , ""
                                                                    , estterm_ref_id_from).Tables[0];

                    foreach(DataRow drRelGrpDept in dtRelGrpDept.Rows) 
                    {
                        affectedRow += _relGroupDept.Insert(  conn
                                                            , trx
                                                            , comp_id
                                                            , rel_grp_id
                                                            , DataTypeUtility.GetToInt32(drRelGrpDept["DEPT_REF_ID"])
                                                            , DataTypeUtility.GetValue(drRelGrpDept["EST_ID"])
                                                            , estterm_ref_id_to
                                                            , create_date
                                                            , create_user);
                    }

                    DataTable dtRelGrpPosInfo =  _relGroupPosInfo.Select( conn
                                                                        , trx
                                                                        , comp_id
                                                                        , ""
                                                                        , DataTypeUtility.GetValue(drRelGrpInfo["REL_GRP_ID"])
                                                                        , ""
                                                                        , estterm_ref_id_from).Tables[0];

                    foreach(DataRow drRelGrpPosInfo in dtRelGrpPosInfo.Rows) 
                    {
                        string rel_grp_pos_id   = keyGen.GetCode(conn, trx, "EST_REL_GROUP_POS_INFO");

                        affectedRow += _relGroupPosInfo.Insert(   conn
                                                                , trx
                                                                , comp_id
                                                                , rel_grp_pos_id
                                                                , DataTypeUtility.GetValue(drRelGrpInfo["REL_GRP_ID"])
                                                                , DataTypeUtility.GetValue(drRelGrpPosInfo["EST_ID"])
                                                                , estterm_ref_id_to
                                                                , DataTypeUtility.GetValue(drRelGrpPosInfo["REL_GRP_POS_NAME"])
                                                                , DataTypeUtility.GetValue(drRelGrpPosInfo["REL_GRP_POS_DESC"])
                                                                , DataTypeUtility.GetValue(drRelGrpPosInfo["OPT_VALUE"])
                                                                , create_date
                                                                , create_user);

                        DataTable dtRelGrpPosData =  _relGroupPosData.Select( conn
                                                                            , trx
                                                                            , comp_id
                                                                            , ""
                                                                            , DataTypeUtility.GetValue(drRelGrpInfo["REL_GRP_ID"])
                                                                            , DataTypeUtility.GetValue(drRelGrpPosInfo["REL_GRP_POS_ID"])
                                                                            , ""
                                                                            , estterm_ref_id_from).Tables[0];

                        foreach(DataRow drRelGrpPosData in dtRelGrpPosData.Rows) 
                        {
                            string rel_grp_pos_data_id   = keyGen.GetCode(conn, trx, "EST_REL_GROUP_POS_DATA");

                            affectedRow += _relGroupPosData.Insert(   conn
                                                                    , trx
                                                                    , comp_id
                                                                    , rel_grp_pos_data_id
                                                                    , DataTypeUtility.GetValue(drRelGrpInfo["REL_GRP_ID"])
                                                                    , DataTypeUtility.GetValue(drRelGrpPosData["REL_GRP_POS_ID"])
                                                                    , DataTypeUtility.GetValue(drRelGrpPosData["EST_ID"])
                                                                    , estterm_ref_id_to
                                                                    , DataTypeUtility.GetValue(drRelGrpPosData["POS_ID"])
                                                                    , DataTypeUtility.GetValue(drRelGrpPosData["POS_ID_NAME"])
                                                                    , DataTypeUtility.GetValue(drRelGrpPosData["POS_VALUE"])
                                                                    , DataTypeUtility.GetValue(drRelGrpPosData["POS_VALUE_NAME"])
                                                                    , DataTypeUtility.GetValue(drRelGrpPosData["OPT_VALUE"])
                                                                    , create_date
                                                                    , create_user);
                        }
                    }
                }

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
         
        public bool RemoveRelGroupInfo(int comp_id, string rel_grp_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                affectedRow = _relGroupInfo.Delete(conn
                                                 , trx
                                                 , comp_id
                                                 , rel_grp_id);

                
                Dac_RelGroupDepts dacDept =  new Dac_RelGroupDepts();
                dacDept.Delete(conn
                             , trx
                             , comp_id
                             , rel_grp_id
                             , 0
                             , ""
                             , 0);

                Dac_RelGroupPositionInfos dacInfos = new Dac_RelGroupPositionInfos();
                dacInfos.Delete(conn
                              , trx
                              , comp_id
                              , ""
                              , rel_grp_id);

                Dac_RelGroupPositionDatas dacDatas = new Dac_RelGroupPositionDatas();
                dacDatas.Delete(conn
                              , trx
                              , comp_id
                              , ""
                              , rel_grp_id);


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
    }
}
