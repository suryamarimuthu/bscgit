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
using MicroBSC.Integration.COM.Dac;

namespace MicroBSC.Integration.COM.Biz
{
    public class Biz_Com_Emp_Info
    {
        Dac_Com_Emp_Info _data;




        public Biz_Com_Emp_Info()
        {
            _data = new Dac_Com_Emp_Info();
        }



        public DataTable GetAll_DB()
        {
            DataTable dt = _data.SelectAll_DB().Tables[0];

            return dt;
        }


        public string Get_Emp_Ref_Id(string loginID)
        {
            string result = _data.Select_EMP_REF_ID(loginID);

            return result;
        }


        public DataTable Get_Emp_Info(int emp_ref_id)
        {
            DataTable dt = _data.Select_Emp_Info(emp_ref_id);

            return dt;
        }


        public bool Modify_Emp_Info(int emp_ref_id, string emp_email, string cell_phone, int update_user_ref_id)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow = 0;

            try
            {
                affectedRow = _data.Update_Emp_Info(conn, trx, emp_ref_id, emp_email, cell_phone, update_user_ref_id);
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



        public bool Add_Emp_Info(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string emp_ref_id = DataTypeUtility.GetString(dt.Rows[i]["EMP_REF_ID"]);
                string emp_code = DataTypeUtility.GetString(dt.Rows[i]["EMP_CODE"]);
                string loginid = DataTypeUtility.GetString(dt.Rows[i]["LOGINID"]);
                string loginip = DataTypeUtility.GetString(dt.Rows[i]["LOGINIP"]);
                string passwd = DataTypeUtility.GetString(dt.Rows[i]["PASSWD"]);
                string emp_name = DataTypeUtility.GetString(dt.Rows[i]["EMP_NAME"]);
                string emp_email = DataTypeUtility.GetString(dt.Rows[i]["EMP_EMAIL"]);
                string position_class_code = DataTypeUtility.GetString(dt.Rows[i]["POSITION_CLASS_CODE"]);
                string position_grp_code = DataTypeUtility.GetString(dt.Rows[i]["POSITION_GRP_CODE"]);
                string position_rank_code = DataTypeUtility.GetString(dt.Rows[i]["POSITION_RANK_CODE"]);
                string position_duty_code = DataTypeUtility.GetString(dt.Rows[i]["POSITION_DUTY_CODE"]);
                string position_stat_code = DataTypeUtility.GetString(dt.Rows[i]["POSITION_STAT_CODE"]);
                string position_kind_code = DataTypeUtility.GetString(dt.Rows[i]["POSITION_KIND_CODE"]);
                string daily_phone = DataTypeUtility.GetString(dt.Rows[i]["DAILY_PHONE"]);
                string cell_phone = DataTypeUtility.GetString(dt.Rows[i]["CELL_PHONE"]);
                string fax_number = DataTypeUtility.GetString(dt.Rows[i]["FAX_NUMBER"]);
                string job_status = DataTypeUtility.GetString(dt.Rows[i]["JOB_STATUS"]);
                string zipcode = DataTypeUtility.GetString(dt.Rows[i]["ZIPCODE"]);
                string addr_1 = DataTypeUtility.GetString(dt.Rows[i]["ADDR_1"]);
                string addr_2 = DataTypeUtility.GetString(dt.Rows[i]["ADDR_2"]);
                string sign_path = DataTypeUtility.GetString(dt.Rows[i]["SIGN_PATH"]);
                string stamp_path = DataTypeUtility.GetString(dt.Rows[i]["STAMP_PATH"]);
                string create_type = DataTypeUtility.GetString(dt.Rows[i]["CREATE_TYPE"]);
                string create_date = DataTypeUtility.GetString(dt.Rows[i]["CREATE_DATE"]);
                string create_emp_id = DataTypeUtility.GetString(dt.Rows[i]["CREATE_EMP_ID"]);
                string modify_type = DataTypeUtility.GetString(dt.Rows[i]["MODIFY_TYPE"]);
                string modify_date = DataTypeUtility.GetString(dt.Rows[i]["MODIFY_DATE"]);
                string modify_emp_id = DataTypeUtility.GetString(dt.Rows[i]["MODIFY_EMP_ID"]);

                /*
                _data.Insert_EmpInfo(null, null
                                    , emp_ref_id
                                    , emp_code
                                    , loginid
                                    , loginip
                                    , passwd
                                    , emp_name
                                    , emp_email
                                    , position_class_code
                                    , position_grp_code
                                    , position_rank_code
                                    , position_duty_code
                                    , position_stat_code
                                    , position_kind_code
                                    , daily_phone
                                    , cell_phone
                                    , fax_number
                                    , job_status
                                    , zipcode
                                    , addr_1
                                    , addr_2
                                    , sign_path
                                    , stamp_path
                                    , create_type
                                    , create_date
                                    , create_emp_id
                                    , modify_type
                                    , modify_date
                                    , modify_emp_id);
                */
            }

            return false;
        }


        public bool Increase_Login_FailCnt(IDbConnection conn, IDbTransaction trx
                                            , int emp_ref_id
                                            , int update_user_ref_id)
        {
            int affectedRow = _data.Update_Emp_Fail_Count(conn, trx, emp_ref_id, update_user_ref_id);

            return affectedRow > 0 ? true : false;
        }


        public bool Modify_Login_FailCnt(IDbConnection conn, IDbTransaction trx
                                        , int emp_ref_id
                                        , int failcnt
                                        , int update_user_ref_id)
        {
            int affectedRow = _data.Update_Emp_Fail_Count(conn, trx, emp_ref_id, failcnt, update_user_ref_id);

            return affectedRow > 0 ? true : false;
        }



        /// <summary>
        /// 사용자 로그인 정보 가져오면서 접속시도 횟수 증가. 작업실패시 null반환
        /// </summary>
        public DataTable Get_Emp_Login_Info(IDbConnection conn, IDbTransaction trx
                                            , string loginID)
        {
            DataTable dt = _data.Select_Emp_Login_Info(conn, trx, loginID);

            if (dt.Rows.Count > 0)
            {
                int emp_ref_id = DataTypeUtility.GetToInt32(dt.Rows[0]["EMP_REF_ID"]);

                if (!Increase_Login_FailCnt(conn, trx, emp_ref_id, emp_ref_id))
                {
                    dt = null;
                }
            }

            return dt;
        }

        public DataTable Select_Goal(int estrterm_id, string yymm, int goalemp, int kpiemp, string kpiname)
        {
            return _data.Select_Goal(estrterm_id, yymm, goalemp, kpiemp, kpiname);
        }

        public int Update_Goal(int estrterm_id, int kpi_ref_id, string ymd, double target_ms, double target_ts)
        {
            return _data.Update_Goal(estrterm_id, kpi_ref_id, ymd, target_ms, target_ts);
        }

        public DataTable Select_Result(int estrterm_id, string yymm, int goalemp, int kpiemp, string kpiname)
        {
            return _data.Select_Result(estrterm_id, yymm, goalemp, kpiemp, kpiname);
        }

        public int Update_Result(int estrterm_id, int kpi_ref_id, string ymd, double target_ms, double target_ts)
        {
            return _data.Update_Result(estrterm_id, kpi_ref_id, ymd, target_ms, target_ts);
        }
    }
}