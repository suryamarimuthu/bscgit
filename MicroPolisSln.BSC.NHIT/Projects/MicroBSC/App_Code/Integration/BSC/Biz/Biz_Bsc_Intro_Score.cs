using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.COM.Dac;
using MicroBSC.Integration.BSC.Dac;
using MicroBSC.Data;


/// <summary>
/// Summary description for Biz_Bsc_Intro_Score
/// </summary>


namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Intro_Score
    {
        Dac_Bsc_Intro_Score _data;


        public Biz_Bsc_Intro_Score()
        {
            _data = new Dac_Bsc_Intro_Score();

            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetMboScore(int estterm_ref_id, string ymd, string loginid)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetMboScore(estterm_ref_id, ymd, loginid);
        }
        public DataTable GetOrgRank(int estterm_ref_id, string ymd, int rowcnt)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgRank(estterm_ref_id, ymd, rowcnt);
        }
        public DataTable GetOrgRankBonbuInTeam(int estterm_ref_id, string ymd, int rowcnt, int up_dept_ref_id)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgRankBonbuInTeam(estterm_ref_id, ymd, rowcnt, up_dept_ref_id);
        }

        public DataTable GetOrgRankDesc(int estterm_ref_id, string ymd, int rowcnt)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgRankDesc(estterm_ref_id, ymd, rowcnt);
        }

        public DataTable GetOrgRankBonbu(int estterm_ref_id, string ymd, string dept_type, string sum_type)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgRankBonbu(estterm_ref_id, ymd, dept_type, sum_type);
        }

        public DataTable GetOrgRankBonbuAsc(int estterm_ref_id, string ymd, string dept_type, string sum_type, int rowcnt)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgRankBonbuAsc(estterm_ref_id, ymd, dept_type, sum_type, rowcnt);
        }

        public DataTable GetOrgRankBonbuDesc(int estterm_ref_id, string ymd, string dept_type, string sum_type, int rowcnt)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgRankBonbuDesc(estterm_ref_id, ymd, dept_type, sum_type, rowcnt);
        }

        public DataTable GetOrgRankPri(int estterm_ref_id, string ymd, string bonbu_id)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgRankPri(estterm_ref_id, ymd, bonbu_id);
        }

        public DataTable GetOrgRankBunpo(int estterm_ref_id, string ymd, string dept_type, string sum_type)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgRankBunpo(estterm_ref_id, ymd, dept_type, sum_type);
        }

        public DataTable GetPriRankBunpo(int estterm_ref_id, string ymd)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetPriRankBunpo(estterm_ref_id, ymd);
        }

        public DataTable GetDeptInfo(int dept_ref_id)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetDeptInfo(dept_ref_id);

        }


        public DataTable GetOrgScore(string sum_type, string estterm_ref_id, string ymd, string est_dept_ref_id)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetOrgScore(sum_type, estterm_ref_id, ymd, est_dept_ref_id);

        }


        public DataTable GetJeonsaInfo(string estterm_ref_id)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetJeonsaInfo(estterm_ref_id);

        }

        public DataTable GetBscSchedule(string schd_top, int row_cnt)
        {
            Dac_Bsc_Intro_Score obj = new Dac_Bsc_Intro_Score();
            return obj.GetBscSchedule(schd_top, row_cnt);

        }
    }

         

}
