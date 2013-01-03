using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.COM.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Biz
{
    public class Biz_NHIT
    {
        Dac_NHIT _data;


        public Biz_NHIT()
        {
            _data = new Dac_NHIT();
        }


        #region ====================   농협 Dashboard 메인 =====================



        public DataTable GetYear_DB()
        {
            return _data.SelectYear_DB();
        }

        public DataTable GetMonth_DB()
        {
            return _data.SelectMonth_DB();
        }

        public DataTable GetJeonSa(string grp_one_code
                                 , int grp_two_code
                                 , string grp_three_code
                                 , string cr_year
                                 , string cr_month
                                 , string tg_gubun)
        {
            return _data.SelectJeonSa(grp_one_code
                                        , grp_two_code
                                        , grp_three_code
                                        , cr_year
                                        , cr_month, tg_gubun);
        }

        public DataTable GetJeonSa(string grp_one_code
                                 , int grp_two_code
                                 , string cr_year
                                 , string cr_month
                                 , string tg_gubun)
        {
            return _data.SelectJeonSa(grp_one_code
                                    , grp_two_code
                                    , cr_year
                                    , cr_month
                                    , tg_gubun);
        }

        public DataTable GetJeonSaPOPUP(string grp_one_code
                                 , int grp_two_code
                                 , string cr_year
                                 , string tg_gubun
                                 )
        {
            return _data.SelectJeonSaPOPUP(grp_one_code
                                    , grp_two_code
                                    , cr_year
                                    , tg_gubun
                                    );
        }

        public DataTable GetInPower(string cr_year)
        {
            return _data.SelectInPower(cr_year);
        }

        public DataTable GetEtc(string grp_one_code
                                 , string cr_year
                                 , string cr_month
                                 , string tg_gubun)
        {
            return _data.SelectEtc(grp_one_code
                                    , cr_year
                                    , cr_month
                                    , tg_gubun);
        }

        #endregion

        #region ====================   농협 Dashboard 인력정산 세부 =====================

        public DataTable GetEmpProject(string cr_year
                                 , string cr_month)
        {
            return _data.SelectEmpProject(cr_year
                                    , cr_month);
        }


        public DataTable GetEmpProjectDetail(string cr_year
                                           , string cr_month
                                           , string project_name)
        {
            return _data.SelectEmpProjectDetail(cr_year
                                               , cr_month
                                               , project_name);
        }


        #endregion


        #region ====================   농협 Dashboard 프로젝트 세부 =====================


        public DataTable GetProjectDetail(string cr_year
                                         , string grp_one_b_code
                                          , string grp_one_c_code
                                          , string grp_one_d_code)
        {
            return _data.SelectProjectDetail(cr_year
                                               , grp_one_b_code
                                               , grp_one_c_code
                                               , grp_one_d_code);
        }

        #endregion

    }
}