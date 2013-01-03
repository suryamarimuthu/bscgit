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

using MicroBSC.Integration.EST.Dac;
using MicroBSC.Integration.BSC.Dac;
using MicroBSC.Integration.COM.Dac;

using MicroBSC.Data;
using MicroBSC.Integration.BSC.Dac;

namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Kpi_Score_Goal
    {
        Dac_Bsc_Kpi_Score_Goal _data;

        public Biz_Bsc_Kpi_Score_Goal()
        {
            _data = new Dac_Bsc_Kpi_Score_Goal();
        }



        /// <summary>
        /// 부서의 월별 KPI 누적 실적
        /// </summary>
        public DataTable Get_Kpi_Monthly_Total_Sum(int estterm_ref_id
                                                    , int dept_ref_id)
        {
            DataTable dt = _data.Select_Kpi_Monthly_Total_Sum(estterm_ref_id, dept_ref_id);

            return dt;
        }




        /// <summary>
        /// 부서의 월별 점수
        /// </summary>
        /// <param name="sum_type">TS:누적점수, MS:월별점수</param>
        public DataTable Get_Kpi_Monthly_Score(int estterm_ref_id
                                                , int dept_ref_id
                                                , string sum_type)
        {
            DataTable dt = _data.Select_Kpi_Monthly_Score(estterm_ref_id, dept_ref_id, sum_type);

            return dt;
        }
    }
}