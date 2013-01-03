using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.ETC.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.ETC.Biz
{
    public class Biz_Nhis_Hist_Sd
    {
        Dac_Nhis_Hist_Sd _data;

        public Biz_Nhis_Hist_Sd()
        {
            _data = new Dac_Nhis_Hist_Sd();
        }


        public bool Add_Nhis_Hist_Sd(string receiver, string sender, string sms_msg)
        {
            int affectedRow = 0;
            int msg_key;

            string save_time = System.DateTime.Now.ToString("yyyyMMddHHmmss");

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                msg_key = _data.Select_Max_Msg_Key(conn, trx);
                affectedRow += _data.Insert_Nhis_Hist_Sd(conn, trx, msg_key, receiver, sender, sms_msg, save_time);

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
    }
}