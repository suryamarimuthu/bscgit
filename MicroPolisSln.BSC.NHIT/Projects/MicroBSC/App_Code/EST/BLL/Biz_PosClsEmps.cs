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
    public class Biz_PosClsEmps
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
        private float _point;
        private DateTime _point_date;
        private int _ctrl_dept_id;
        private int _ctrl_emp_id;
        private string _ctrl_type;
        private DateTime _update_date;
        private int _update_user;

        private Dac_PosClsEmps _posClsEmp = new Dac_PosClsEmps();
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

        public float Point
        {
            get
            {
                return _point;
            }
            set
            {
                _point = value;
            }
        }

        public DateTime Point_Date
        {
            get
            {
                return _point_date;
            }
            set
            {
                _point_date = value;
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

        public string Ctrl_Type
        {
            get
            {
                return _ctrl_type;
            }
            set
            {
                _ctrl_type = (value == null ? "" : value);
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

        public Biz_PosClsEmps()
        {

        }

        public Biz_PosClsEmps(string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , int seq)
        {
            DataSet ds = _posClsEmp.Select(est_id
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
                _point              = (dr["POINT"]              == DBNull.Value) ? 0 : (float)dr["POINT"];
                _point_date         = (dr["POINT_DATE"]         == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["POINT_DATE"];
                _ctrl_dept_id       = (dr["CTRL_DEPT_ID"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["CTRL_DEPT_ID"]);
                _ctrl_emp_id        = (dr["CTRL_EMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CTRL_EMP_ID"]);
                _ctrl_type          = (dr["CTRL_TYPE"]          == DBNull.Value) ? "" : (string)dr["CTRL_TYPE"];
                _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyPosClsEmp(string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , float point
                                    , DateTime point_date
                                    , int ctrl_dept_id
                                    , int ctrl_emp_id
                                    , string ctrl_type
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _posClsEmp.Update(  null
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
                                            , point
                                            , point_date
                                            , ctrl_dept_id
                                            , ctrl_emp_id
                                            , ctrl_type
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPosClsEmp(string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq)
        {
            return _posClsEmp.Select(est_id
                                           , estterm_ref_id
                                           , estterm_sub_id
                                           , estterm_step_id
                                           , est_dept_id
                                           , est_emp_id
                                           , tgt_dept_id
                                           , tgt_emp_id
                                           , seq);
        }

        public bool AddPosClsEmp(string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , int seq
                                , float point
                                , DateTime point_date
                                , int ctrl_dept_id
                                , int ctrl_emp_id
                                , string ctrl_type
                                , DateTime create_date
                                , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _posClsEmp.Insert(  null
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
                                            , point
                                            , point_date
                                            , ctrl_dept_id
                                            , ctrl_emp_id
                                            , ctrl_type
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemovePosClsEmp(string est_id
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

            affectedRow = _posClsEmp.Delete(null
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