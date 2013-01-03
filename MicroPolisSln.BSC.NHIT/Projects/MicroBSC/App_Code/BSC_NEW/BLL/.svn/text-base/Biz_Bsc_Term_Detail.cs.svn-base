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

/// <summary>
/// Biz_Bsc_Term_Detail의 요약 설명입니다.
/// </summary>
/// 

namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Term_Detail : MicroBSC.BSC.Dac.Dac_Bsc_Term_Detail
    {
        public Biz_Bsc_Term_Detail() { }

        public Biz_Bsc_Term_Detail(int pIestterm_ref_id, string pIymd)
            : base(pIestterm_ref_id, pIymd)
        {
            
        }

        public DataSet GetTermDetail(int estterm_ref_id)
        {
            return GetAllList(estterm_ref_id);
        }

        public int OpenTermDetailMonth(int pIestterm_ref_id, string pIymd, int pItxr_user)
        { 
            return base.OpenTermDetailMonth_Dac(pIestterm_ref_id, pIymd, pItxr_user);
        }

        public int ApplyNormDist(int pIestterm_ref_id, string pIymd, int pItxr_user)
        { 
            return base.ApplyNormDist_Dac(pIestterm_ref_id, pIymd, pItxr_user);
        }

        public int ApplyExtScore(int pIestterm_ref_id, string pIymd, int pItxr_user)
        { 
            return base.ApplyExtScore_Dac(pIestterm_ref_id, pIymd, pItxr_user);
        }

        public int InterfaceData(int pIestterm_ref_id, string pIymd, string pInterface_desc, int pItxr_user)
        {
            return base.InterfaceData_Dac(pIestterm_ref_id, pIymd, pInterface_desc, pItxr_user);
        }

        public bool CalcTermMonth(int estterm_ref_id, string ymd, int txr_user)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.CalcTermMonth(conn, trx, estterm_ref_id, ymd, txr_user);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch(Exception ex)
            {
                trx.Rollback();
                this.Transaction_Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }
    }
}
