using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.EST.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Biz
{
    public class Biz_Est_Bias_Group
    {
        Dac_Est_Bias_Group _data;

        public Biz_Est_Bias_Group()
	    {
            _data = new Dac_Est_Bias_Group();
	    }


        public int AddEstBiasGroup_DB(int comp_id
                                    , string est_id
                                    , int bias_grp_id
                                    , string bias_grp_cd
                                    , string bias_grp_nm
                                    , string bias_grp_desc
                                    , string use_yn
                                    , int create_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (bias_grp_id.Equals(0))
                {
                    bias_grp_id = _data.SelectMax_DB(conn, trx);
                    affectedRow += _data.Insert_DB(conn
                                                 , trx
                                                , comp_id
                                                , est_id
                                                , bias_grp_id
                                                , bias_grp_cd
                                                , bias_grp_nm
                                                , bias_grp_desc
                                                , use_yn
                                                , create_user_ref_id);
                }
                else
                {
                    
                    affectedRow += _data.Update_DB(conn
                                                 , trx
                                                , comp_id
                                                , est_id
                                                , bias_grp_id
                                                , bias_grp_cd
                                                , bias_grp_nm
                                                , bias_grp_desc
                                                , use_yn
                                                , create_user_ref_id);

                }

                
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                affectedRow = -1;
                return -1;
            }
            finally
            {
                conn.Close();
            }

            return bias_grp_id;
        }

        public int ModifyEstBiasGroup_DB(int comp_id
                                    , string est_id
                                    , int bias_grp_id
                                    , string bias_grp_cd
                                    , string bias_grp_nm
                                    , string bias_grp_desc
                                    , string use_yn
                                    , int create_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _data.Update_DB(conn
                                             , trx
                                             , comp_id
                                            , est_id
                                            , bias_grp_id
                                            , bias_grp_cd
                                            , bias_grp_nm
                                            , bias_grp_desc
                                            , use_yn
                                            , create_user_ref_id);

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                affectedRow = 0;
            }
            finally
            {
                conn.Close();
            }

            return bias_grp_id;
        }

        public bool RemoveEstBiasGroup_DB(int bias_grp_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _data.Delete_DB(conn
                                             , trx
                                            , bias_grp_id);

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                affectedRow = 0;
            }
            finally
            {
                conn.Close();
            }

            return affectedRow > 0 ? true : false;
        }


        public DataTable GetBiasGroup_DB(int comp_id
                                        , string est_id
                                        , string bias_grp_cd)
                                           
        {
            DataTable dt = _data.Select_DB(comp_id
                                        , est_id
                                        , bias_grp_cd);

            return dt;
        }

        public DataSet GetBiasGroupEmp_DB(int comp_id
                                           , string est_id
                                           , int estterm_ref_id
                                           , int bias_grp_id)

        {
            return _data.SelectBiasGroupEmp_DB(comp_id
                                               , est_id
                                               , estterm_ref_id
                                               , bias_grp_id);

        }
    }
}