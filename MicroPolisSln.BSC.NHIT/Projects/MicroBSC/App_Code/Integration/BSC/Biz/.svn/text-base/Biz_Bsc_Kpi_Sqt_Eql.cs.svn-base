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

using MicroBSC.Data;
using MicroBSC.Integration.BSC.Dac;

namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Kpi_Eqt_Eql
    {
        Dac_Bsc_Kpi_Eqt_Eql _data;

        public Biz_Bsc_Kpi_Eqt_Eql()
        {
            _data = new Dac_Bsc_Kpi_Eqt_Eql();
        }


        public enum EST_TYPE { TOTAL, EQT, EQL };
        public DataTable Get_Kpi_Eqt_Eql_Ratio(int estterm_ref_id
                                            , EST_TYPE est_type
                                            , int dept_ref_id
                                            , int champion_emp_ref_id
                                            , string is_team_kpi_yn
                                            , string kpi_code
                                            , string kpi_name)
        {
            string str_est_type;
            if (est_type == EST_TYPE.EQT)
                str_est_type = "EQT";
            else if (est_type == EST_TYPE.EQL)
                str_est_type = "EQL";
            else
                str_est_type = "";

            DataTable dt = _data.Select_DB_Join_Kpi_Info(estterm_ref_id
                                                        , str_est_type
                                                        , dept_ref_id
                                                        , champion_emp_ref_id
                                                        , is_team_kpi_yn
                                                        , kpi_code
                                                        , kpi_name);

            return dt;
        }



        public int Remove_Kpi_Eqt_Eql_Ratio(IDbConnection conn, IDbTransaction trx
                                            , int estterm_ref_id
                                            , DataTable dt_kpi_ref_id)
        {
            int affectedRow = 0;

            string kpi_ref_id_list = "";
            for (int i = 0; i < dt_kpi_ref_id.Rows.Count; i++)
            {
                if (kpi_ref_id_list.Length > 0)
                    kpi_ref_id_list += ", ";
                kpi_ref_id_list += DataTypeUtility.GetString(dt_kpi_ref_id.Rows[i]["KPI_REF_ID"]);
            }
            if (kpi_ref_id_list.Length == 0)
                kpi_ref_id_list = "''";

            affectedRow = _data.Delete_Bsc_Kpi_Eqt_Eql_Bulk(conn, trx
                                                            , estterm_ref_id
                                                            , kpi_ref_id_list);
            return affectedRow;
        }
        public int Remove_Kpi_Eqt_Eql_Ratio(IDbConnection conn, IDbTransaction trx
                                            , int estterm_ref_id
                                            , int kpi_ref_id)
        {
            int affectedRow = 0;
            affectedRow = _data.Delete_Bsc_Kpi_Eqt_Eql(conn, trx
                                                        , estterm_ref_id
                                                        , kpi_ref_id);

            return affectedRow;
        }



        public int Add_Kpi_Eqt_Eql_Ratio(IDbConnection conn, IDbTransaction trx
                                        , int estterm_ref_id
                                        , DataTable dt_kpi_ref_id
                                        , int eqtValue
                                        , int eqlValue
                                        , int create_user_ref_id)
        {
            int affectedRow = 0;

            string kpi_ref_id_list = "";
            for (int i = 0; i < dt_kpi_ref_id.Rows.Count; i++)
            {
                if (kpi_ref_id_list.Length > 0)
                    kpi_ref_id_list += ", ";
                kpi_ref_id_list += DataTypeUtility.GetString(dt_kpi_ref_id.Rows[i]["KPI_REF_ID"]);
            }
            if (kpi_ref_id_list.Length == 0)
                kpi_ref_id_list = "''";

            affectedRow = _data.Insert_Bsc_Kpi_Eqt_Eql_Bulk(conn, trx
                                                            , estterm_ref_id
                                                            , kpi_ref_id_list
                                                            , eqtValue
                                                            , eqlValue
                                                            , create_user_ref_id);
            return affectedRow;
        }
        public int Add_Kpi_Eqt_Eql_Ratio(IDbConnection conn, IDbTransaction trx
                                        , int estterm_ref_id
                                        , int kpi_ref_id
                                        , int eqtValue
                                        , int eqlValue
                                        , int create_user_ref_id)
        {
            int affectedRow = 0;


            affectedRow = _data.Insert_Bsc_Kpi_Eqt_Eql(conn, trx
                                                        , estterm_ref_id
                                                        , kpi_ref_id
                                                        , eqtValue
                                                        , eqlValue
                                                        , create_user_ref_id);

            return affectedRow;
        }



        public bool Set_Kpi_Eqt_Eql_Ratio(int estterm_ref_id
                                        , DataTable dt_kpi_ref_id
                                        , int eqtValue
                                        , int eqlValue
                                        , int create_user_ref_id)
        {
            int affectedRow = 0;


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow = Remove_Kpi_Eqt_Eql_Ratio(conn, trx
                                                    , estterm_ref_id
                                                    , dt_kpi_ref_id);
                affectedRow += Add_Kpi_Eqt_Eql_Ratio(conn, trx
                                                    , estterm_ref_id
                                                    , dt_kpi_ref_id
                                                    , eqtValue
                                                    , eqlValue
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

            return affectedRow > 0 ? true : false;
        }
    }
}
