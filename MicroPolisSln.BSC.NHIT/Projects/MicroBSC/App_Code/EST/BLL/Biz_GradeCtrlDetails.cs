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
    public class Biz_GradeCtrlDetails
    {

        #region ============================== [Fields] ==============================

        private string _est_id;
        private int _estterm_ref_id;
        private int _estterm_sub_id;
        private int _estterm_step_id;
        private int _est_dept_id;
        private int _est_emp_id;
        private int _tgt_dept_id;
        private int _tgt_emp_id;
        private int _seq;
        private string _grade_id;
        private DateTime _grade_date;
        private int _ctrl_dept_id;
        private int _ctrl_emp_id;
        private DateTime _update_date;
        private int _update_user;

        private Dac_GradeCtrlDetails _gradeCtrlDetail = new Dac_GradeCtrlDetails();
        #endregion

        #region ============================== [Properties] ==============================

        public string Est_ID
        {
            get
            {
                return _est_id;
            }
            set
            {
                _est_id = (value == null ? "" : value);
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

        public int Estterm_Step_ID
        {
            get
            {
                return _estterm_step_id;
            }
            set
            {
                _estterm_step_id = value;
            }
        }

        public int Est_Dept_ID
        {
            get
            {
                return _est_dept_id;
            }
            set
            {
                _est_dept_id = value;
            }
        }

        public int Est_Emp_ID
        {
            get
            {
                return _est_emp_id;
            }
            set
            {
                _est_emp_id = value;
            }
        }

        public int Tgt_Dept_ID
        {
            get
            {
                return _tgt_dept_id;
            }
            set
            {
                _tgt_dept_id = value;
            }
        }

        public int Tgt_Emp_ID
        {
            get
            {
                return _tgt_emp_id;
            }
            set
            {
                _tgt_emp_id = value;
            }
        }

        public int Seq
        {
            get
            {
                return _seq;
            }
            set
            {
                _seq = value;
            }
        }

        public string Grade_ID
        {
            get
            {
                return _grade_id;
            }
            set
            {
                _grade_id = (value == null ? "" : value);
            }
        }

        public DateTime Grade_Date
        {
            get
            {
                return _grade_date;
            }
            set
            {
                _grade_date = value;
            }
        }

        public int Ctrl_Dept_ID
        {
            get
            {
                return _ctrl_dept_id;
            }
            set
            {
                _ctrl_dept_id = value;
            }
        }

        public int Ctrl_Emp_ID
        {
            get
            {
                return _ctrl_emp_id;
            }
            set
            {
                _ctrl_emp_id = value;
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

        public Biz_GradeCtrlDetails()
        {

        }
        public Biz_GradeCtrlDetails(string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq)
        {
            DataSet ds = _gradeCtrlDetail.Select( est_id
                                                ,  estterm_ref_id
                                                ,  estterm_sub_id
                                                ,  estterm_step_id
                                                ,  est_dept_id
                                                ,  est_emp_id
                                                ,  tgt_dept_id
                                                ,  tgt_emp_id
                                                ,  seq);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];
                _est_id             = (dr["EST_ID"]             == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _estterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id     = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id    = (dr["ESTTERM_STEP_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id        = (dr["EST_DEPT_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id         = (dr["EST_EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_EMP_ID"]);
                _tgt_dept_id        = (dr["TGT_DEPT_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_DEPT_ID"]);
                _tgt_emp_id         = (dr["TGT_EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_EMP_ID"]);
                _seq                = (dr["SEQ"]                == DBNull.Value) ? 0 : Convert.ToInt32(dr["SEQ"]);
                _grade_id           = (dr["GRADE_ID"]           == DBNull.Value) ? "" : (string)dr["GRADE_ID"];
                _grade_date         = (dr["GRADE_DATE"]         == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["GRADE_DATE"];
                _ctrl_dept_id       = (dr["CTRL_DEPT_ID"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["CTRL_DEPT_ID"]);
                _ctrl_emp_id        = (dr["CTRL_EMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CTRL_EMP_ID"]);
                _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }


        public bool ModifyGradeCtrlDetail(string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int seq
                                        , string grade_id
                                        , DateTime grade_date
                                        , int ctrl_dept_id
                                        , int ctrl_emp_id
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _gradeCtrlDetail.Update(null
                                                , null
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq
                                                , grade_id
                                                , grade_date
                                                , ctrl_dept_id
                                                , ctrl_emp_id
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetGradeCtrlDetail(string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int seq)
        {
            return _gradeCtrlDetail.Select(est_id
                                                 , estterm_ref_id
                                                 , estterm_sub_id
                                                 , estterm_step_id
                                                 , est_dept_id
                                                 , est_emp_id
                                                 , tgt_dept_id
                                                 , tgt_emp_id
                                                 , seq);
        }

        public bool AddGradeCtrlDetail(string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int seq
                                        , string grade_id
                                        , DateTime grade_date
                                        , int ctrl_dept_id
                                        , int ctrl_emp_id
                                        , DateTime create_date
                                        , int create_user)
        {
          int affectedRow = 0;

          affectedRow = _gradeCtrlDetail.Insert(null
                                              , null
                                              , est_id
                                              , estterm_ref_id
                                              , estterm_sub_id
                                              , estterm_step_id
                                              , est_dept_id
                                              , est_emp_id
                                              , tgt_dept_id
                                              , tgt_emp_id
                                              , seq
                                              , grade_id
                                              , grade_date
                                              , ctrl_dept_id
                                              , ctrl_emp_id
                                              , create_date
                                              , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveGradeCtrlDetail(string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int seq)
        {
            int affectedRow = 0;

            affectedRow = _gradeCtrlDetail.Delete( null
                                                 , null
                                                 , est_id
                                                 , estterm_ref_id
                                                 , estterm_sub_id
                                                 , estterm_step_id
                                                 , est_dept_id
                                                 , est_emp_id
                                                 , tgt_dept_id
                                                 , tgt_emp_id
                                                 , seq);

            return (affectedRow > 0) ? true : false;
        }



    }
}
