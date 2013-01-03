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
    public class Biz_Pms_Info
    {
        Dac_Pms_Info _data;

        public Biz_Pms_Info()
        {
            _data = new Dac_Pms_Info();
        }


        public DataTable Get_Project_List(DateTime StartDate, DateTime EndDate)
        {
            string sDate = StartDate.ToString("yyyy-MM-dd");
            string eDate = EndDate.ToString("yyyy-MM-dd");

            DataTable DT = _data.Select_Prj_List(sDate, eDate);
            //DataTable DT = _data.Select_Prj_List(StartDate, EndDate);

            return DT;
        }


        public DataTable Get_Project_Detail(string PRJ_ID, DateTime StartDate, DateTime EndDate)
        {
            Biz_Pms_Col_Info bizPmsColInfo = new Biz_Pms_Col_Info();

            string sDate = StartDate.ToString("yyyy-MM-dd");
            string eDate = EndDate.ToString("yyyy-MM-dd");

            DataTable colList = bizPmsColInfo.Get_Col_Info_List(PRJ_ID);
            
            DataTable DT = _data.Select_Prj_Detail(colList, PRJ_ID, sDate, eDate);

            return DT;
        }



        public bool Add_Project_Info_To_Pms(DateTime start_date, DateTime end_date, string projectid_list, string colList)
        {
            string sDate = start_date.ToString("yyyy-MM-dd");
            string eDate = end_date.ToString("yyyy-MM-dd");


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow = 0;

            try
            {
                affectedRow = _data.Delete_Pms_info(conn, trx, projectid_list);
                affectedRow = _data.Insert_From_Vw_Bsc_Pms(conn, trx, sDate, eDate, projectid_list, colList);
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



        /// <summary>
        /// 뷰테이블의 프로젝트ID리스트
        /// </summary>
        public DataTable Get_Vw_ProjectID(DateTime start_date, DateTime end_date)
        {
            string sDate = start_date.ToString("yyyy-MM-dd");
            string eDate = end_date.ToString("yyyy-MM-dd");

            DataTable DT = _data.Select_Vw_ProjectID(sDate, eDate);

            return DT;
        }
    }
}