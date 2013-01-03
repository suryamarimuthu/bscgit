using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_PosDutEmps
    {
        #region ============================== [Fields] ==============================

        private int _emp_ref_id;
        private int _estterm_ref_id;
        private int _estterm_sub_id;
        private string _pos_dut_id;
        private DateTime _start_date;
        private DateTime _end_date;
        private DateTime _update_date;
        private int _update_user;

        private Dac_PosDutEmps _posDutEmp = new Dac_PosDutEmps();

        #endregion

        #region ============================== [Properties] ==============================

        public int Emp_Ref_ID
        {
            get
            {
                return _emp_ref_id;
            }
            set
            {
                _emp_ref_id = value;
            }
        }

        public int Estterm_Ref_ID
        {
            get
            {
                return _estterm_ref_id;
            }
            set
            {
                _estterm_ref_id = value;
            }
        }

        public int Estterm_Sub_ID
        {
            get
            {
                return _estterm_sub_id;
            }
            set
            {
                _estterm_sub_id = value;
            }
        }

        public string Pos_Dut_ID
        {
            get
            {
                return _pos_dut_id;
            }
            set
            {
                _pos_dut_id = (value == null ? "" : value);
            }
        }

        public DateTime Start_Date
        {
            get
            {
                return _start_date;
            }
            set
            {
                _start_date = value;
            }
        }

        public DateTime End_Date
        {
            get
            {
                return _end_date;
            }
            set
            {
                _end_date = value;
            }
        }

        public DateTime Update_Date
        {
            get
            {
                return _update_date;
            }
            set
            {
                _update_date = value;
            }
        }

        public int Update_User
        {
            get
            {
                return _update_user;
            }
            set
            {
                _update_user = value;
            }
        }
        #endregion

        public Biz_PosDutEmps()
        {

        }

        public Biz_PosDutEmps(int emp_ref_id
                                , string pos_dut_id
                                , DateTime start_date)
        {
            DataSet ds = _posDutEmp.Select(emp_ref_id,  pos_dut_id, start_date);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _emp_ref_id     = (dr["EMP_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["EMP_REF_ID"]);
                _estterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id = (dr["ESTTERM_SUB_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
                _pos_dut_id     = (dr["POS_DUT_ID"]     == DBNull.Value) ? "" : (string)dr["POS_DUT_ID"];
                _start_date     = (dr["START_DATE"]     == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["START_DATE"];
                _end_date       = (dr["END_DATE"]       == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["END_DATE"];
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyPosDutEmp(int emp_ref_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , string pos_dut_id
                                    , DateTime start_date
                                    , DateTime end_date
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _posDutEmp.Update(  null
                                            , null
                                            , emp_ref_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , pos_dut_id
                                            , start_date
                                            , end_date
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPosDutEmp(int emp_ref_id
                                    , string pos_dut_id
                                    , DateTime start_date)
        {
            return _posDutEmp.Select(emp_ref_id
                                    , pos_dut_id
                                    , start_date);
        }

        public bool AddPosDutEmp(int emp_ref_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , string pos_dut_id
                                , DateTime start_date
                                , DateTime end_date
                                , DateTime create_date
                                , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _posDutEmp.Insert(  null
                                            , null
                                            , emp_ref_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , pos_dut_id
                                            , start_date
                                            , end_date
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemovePosDutEmp(int emp_ref_id
                                    , string pos_dut_id
                                    , DateTime start_date)
        {
            int affectedRow = 0;

            affectedRow = _posDutEmp.Delete(  null
                                            , null
                                            , emp_ref_id
                                            , pos_dut_id
                                            , start_date);

            return (affectedRow > 0) ? true : false;
        }
    }
}
