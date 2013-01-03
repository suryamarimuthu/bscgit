using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;
using MicroBSC.Integration.PMS.Dac;

namespace MicroBSC.Integration.PMS.Biz
{
    public class Biz_Pms_Com_Info
    {
        Dac_Pms_Com_Info _data;

        public Biz_Pms_Com_Info()
        {
            _data = new Dac_Pms_Com_Info();
        }


        public bool Add_Pms_Com_Info(string IF_COL_ID
                                    , string IF_COL_NAME
                                    , string CUSTOM_COL_ID
                                    , string CUSTOM_COL_NAME
                                    , string SOOSIK
                                    , string soosik_desc
                                    , string USER_REF_ID)
        {
            int affectedRow = 0;
            int PmsComInfo_ID;


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();



            try
            {
                //PmsComInfo_ID = _data.Select_NewIdx_Pms_Com_Info(conn, trx);
                PmsComInfo_ID = 1;
                if (_data.Select_Pms_Com_Info(PmsComInfo_ID).Rows.Count == 0)
                {
                    affectedRow = _data.Insert_Pms_Com_Info(conn, trx
                                                            , PmsComInfo_ID
                                                            , IF_COL_ID, IF_COL_NAME
                                                            , CUSTOM_COL_ID, CUSTOM_COL_NAME
                                                            , SOOSIK
                                                            , soosik_desc
                                                            , USER_REF_ID);
                }
                else
                {
                    affectedRow = _data.Update_Pms_Com_Info(conn, trx
                                                            , PmsComInfo_ID
                                                            , IF_COL_ID, IF_COL_NAME
                                                            , CUSTOM_COL_ID, CUSTOM_COL_NAME
                                                            , SOOSIK
                                                            , soosik_desc
                                                            , USER_REF_ID);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }


            return affectedRow > 0 ? true : false;
        }



        public bool Modify_Pms_Com_Info(string IF_COL_ID
                                    , string IF_COL_NAME
                                    , string CUSTOM_COL_ID
                                    , string CUSTOM_COL_NAME
                                    , string SOOSIK
                                    , string soosik_desc
                                    , string USER_REF_ID)
        {
            int affectedRow = 0;
            int PmsComInfo_ID = 1;


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();



            try
            {
                affectedRow = _data.Update_Pms_Com_Info(conn, trx
                                                        , PmsComInfo_ID
                                                        , IF_COL_ID, IF_COL_NAME
                                                        , CUSTOM_COL_ID, CUSTOM_COL_NAME
                                                        , SOOSIK
                                                        , soosik_desc
                                                        , USER_REF_ID);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }


            return affectedRow > 0 ? true : false;
        }



        public DataTable Get_Pms_Com_Info(int Idx)
        {
            DataTable DT = _data.Select_Pms_Com_Info(Idx);

            return DT;
        }
    }
}