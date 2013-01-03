using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;
using System.Web.UI.WebControls;

using MicroBSC.PRJ.Dac;
using MicroBSC.Data;

namespace MicroBSC.PRJ.Biz
{
    public class Biz_Prj_QuestionData
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private string _est_id;
        private int _estterm_ref_id;
        private int _estterm_sub_id;
        private int _estterm_step_id;
        private int _est_dept_id;
        private int _est_emp_id;
        private int _prj_ref_id;
        private string _q_obj_id;
        private string _q_sbj_id;
        private string _q_itm_id;
        private float _point;
        private string _grade_id;
        private string _text_value;
        private string _opinion;
        private string _attach_no;
        private DateTime _update_date;
        private int _update_user;

        private Dac_Prj_QuestionData _questiondata = new Dac_Prj_QuestionData();

        #endregion

        #region ============================== [Properties] ==============================

        public int Comp_ID
        {
            get
            {
                return _comp_id;
            }
            set
            {
                _comp_id = value;
            }
        }

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

        public int Prj_Ref_ID
        {
            get
            {
                return _prj_ref_id;
            }
            set
            {
                _prj_ref_id = value;
            }
        }

        public string Q_Obj_ID
        {
            get
            {
                return _q_obj_id;
            }
            set
            {
                _q_obj_id = (value == null ? "" : value);
            }
        }

        public string Q_Sbj_ID
        {
            get
            {
                return _q_sbj_id;
            }
            set
            {
                _q_sbj_id = (value == null ? "" : value);
            }
        }

        public string Q_Itm_ID
        {
            get
            {
                return _q_itm_id;
            }
            set
            {
                _q_itm_id = (value == null ? "" : value);
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

        public string Text_Value
        {
            get
            {
                return _text_value;
            }
            set
            {
                _text_value = (value == null ? "" : value);
            }
        }

        public string Opinion
        {
            get
            {
                return _opinion;
            }
            set
            {
                _opinion = (value == null ? "" : value);
            }
        }

        public string Attach_NO
        {
            get
            {
                return _attach_no;
            }
            set
            {
                _attach_no = (value == null ? "" : value);
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

        public Biz_Prj_QuestionData()
        {

        }

        public Biz_Prj_QuestionData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int prj_ref_id
                                , string q_sbj_id)
        {
            DataSet ds = _questiondata.Select(comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , prj_ref_id
                                            , q_sbj_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];

                _comp_id            = DataTypeUtility.GetToInt32(dr["COMP_ID"]);
                _est_id             = DataTypeUtility.GetValue(dr["EST_ID"]);
                _estterm_ref_id     = DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id     = DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id    = DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id        = DataTypeUtility.GetToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id         = DataTypeUtility.GetToInt32(dr["EST_EMP_ID"]);
                _prj_ref_id         = DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]);
                _q_obj_id           = DataTypeUtility.GetValue(dr["Q_OBJ_ID"]);
                _q_sbj_id           = DataTypeUtility.GetValue(dr["Q_SBJ_ID"]);
                _q_itm_id           = DataTypeUtility.GetValue(dr["Q_ITM_ID"]);
                _point              = DataTypeUtility.GetToFloat(dr["POINT"]);
                _grade_id           = DataTypeUtility.GetValue(dr["GRADE_ID"]);
                _text_value         = DataTypeUtility.GetValue(dr["TEXT_VALUE"]);
                _opinion            = DataTypeUtility.GetValue(dr["OPINION"]);
                _attach_no          = DataTypeUtility.GetValue(dr["ATTACH_NO"]);
                _update_date        = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user        = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public Biz_Prj_QuestionData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_emp_id
                                , int prj_ref_id
                                , string q_sbj_id)
        {
            DataSet ds = _questiondata.Select(comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_emp_id
                                            , prj_ref_id
                                            , q_sbj_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];

                _comp_id            = DataTypeUtility.GetToInt32(dr["COMP_ID"]);
                _est_id             = DataTypeUtility.GetValue(dr["EST_ID"]);
                _estterm_ref_id     = DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id     = DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id    = DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id        = DataTypeUtility.GetToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id         = DataTypeUtility.GetToInt32(dr["EST_EMP_ID"]);
                _prj_ref_id         = DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]);
                _q_obj_id           = DataTypeUtility.GetValue(dr["Q_OBJ_ID"]);
                _q_sbj_id           = DataTypeUtility.GetValue(dr["Q_SBJ_ID"]);
                _q_itm_id           = DataTypeUtility.GetValue(dr["Q_ITM_ID"]);
                _point              = DataTypeUtility.GetToFloat(dr["POINT"]);
                _grade_id           = DataTypeUtility.GetValue(dr["GRADE_ID"]);
                _text_value         = DataTypeUtility.GetValue(dr["TEXT_VALUE"]);
                _opinion            = DataTypeUtility.GetValue(dr["OPINION"]);
                _attach_no          = DataTypeUtility.GetValue(dr["ATTACH_NO"]);
                _update_date        = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user        = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyQuestionData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int prj_ref_id
                                    , string q_obj_id
                                    , string q_sbj_id
                                    , string q_itm_id
                                    , float point
                                    , string grade_id
                                    , string text_value
                                    , string opinion
                                    , string attach_no
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _questiondata.Update(   null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , prj_ref_id
                                                , q_obj_id
                                                , q_sbj_id
                                                , q_itm_id
                                                , point
                                                , grade_id
                                                , text_value
                                                , opinion
                                                , attach_no
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetQuestionData(   int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int prj_ref_id
                                        , string q_sbj_id)
        {
            return _questiondata.Select(comp_id
                                     , est_id
                                     , estterm_ref_id
                                     , estterm_sub_id
                                     , estterm_step_id
                                     , est_dept_id
                                     , est_emp_id
                                     , prj_ref_id
                                     , q_sbj_id);
        }

        public DataSet GetQuestionData(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_emp_id
                                        , int prj_ref_id
                                        , string q_sbj_id)
        {
            return _questiondata.Select(comp_id
                                     , est_id
                                     , estterm_ref_id
                                     , estterm_sub_id
                                     , estterm_step_id
                                     , est_dept_id
                                     , est_emp_id
                                     , tgt_emp_id
                                     , prj_ref_id
                                     , q_sbj_id);
        }

        public bool AddQuestionData(  int comp_id  
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int prj_ref_id
                                    , string q_obj_id
                                    , string q_sbj_id
                                    , string q_itm_id
                                    , float point
                                    , string grade_id
                                    , string text_value
                                    , string opinion
                                    , string attach_no
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _questiondata.Insert(   null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , prj_ref_id
                                                , q_obj_id
                                                , q_sbj_id
                                                , q_itm_id
                                                , point
                                                , grade_id
                                                , text_value
                                                , opinion
                                                , attach_no
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveQuestionData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int prj_ref_id
                                    , string q_sbj_id)
        {
            int affectedRow = 0;

            affectedRow = _questiondata.Delete( null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , prj_ref_id
                                            , q_sbj_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(  int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int prj_ref_id
                            , string q_sbj_id)
        {
            int affectedRow = 0;

            affectedRow = _questiondata.Count(null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , prj_ref_id
                                            , q_sbj_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public bool IsExist(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_emp_id
                            , int prj_ref_id
                            , string q_sbj_id)
        {
            int affectedRow = 0;

            affectedRow = _questiondata.Count(null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_emp_id
                                            , prj_ref_id
                                            , q_sbj_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public bool SaveQuestionData(DataTable dtQData, DataTable dtPrjData)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            Dac_Prj_Data datas = new Dac_Prj_Data();

            try
            {
                foreach (DataRow dataRow in dtQData.Rows)
                {
                    if(IsExist(  DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                               , dataRow["EST_ID"].ToString()
                               , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["USER"])
                               , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])
                               , dataRow["Q_SBJ_ID"].ToString()))
                    {
                        affectedRow += _questiondata.Update( null
                                                           , null
                                                           , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                           , dataRow["EST_ID"].ToString()
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])
                                                           , dataRow["Q_OBJ_ID"].ToString()
                                                           , dataRow["Q_SBJ_ID"].ToString()
                                                           , dataRow["Q_ITM_ID"].ToString()
                                                           , DataTypeUtility.GetToFloat(dataRow["POINT"])
                                                           , dataRow["GRADE_ID"].ToString()
                                                           , dataRow["TEXT_VALUE"].ToString()
                                                           , dataRow["OPINION"].ToString()
                                                           , dataRow["ATTACH_NO"].ToString()
                                                           , DateTime.Now
                                                           , DataTypeUtility.GetToInt32(dataRow["USER"]));
                    }
                    else
                    {
                        affectedRow += _questiondata.Insert(  null
                                                            , null
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])
                                                            , dataRow["Q_OBJ_ID"].ToString()
                                                            , dataRow["Q_SBJ_ID"].ToString()
                                                            , dataRow["Q_ITM_ID"].ToString()
                                                            , DataTypeUtility.GetToFloat(dataRow["POINT"])
                                                            , dataRow["GRADE_ID"].ToString()
                                                            , dataRow["TEXT_VALUE"].ToString()
                                                            , dataRow["OPINION"].ToString()
                                                            , dataRow["ATTACH_NO"].ToString()
                                                            , DateTime.Now
                                                            , DataTypeUtility.GetToInt32(dataRow["USER"]));
                    }
                }

                // PRJ_DATA 저장
                foreach (DataRow dataRow in dtPrjData.Rows)
                {
                    if (datas.Count( DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                   , dataRow["EST_ID"].ToString()
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])) > 0)
                    {
                        affectedRow += datas.Update( null
                                                   , null
                                                   , dataRow["COMP_ID"]
                                                   , dataRow["EST_ID"]
                                                   , dataRow["ESTTERM_REF_ID"]
                                                   , dataRow["ESTTERM_SUB_ID"]
                                                   , dataRow["ESTTERM_STEP_ID"]
                                                   , dataRow["EST_DEPT_ID"]
                                                   , dataRow["EST_EMP_ID"]
                                                   , dataRow["PRJ_REF_ID"]
                                                   , dataRow["POINT"]
                                                   , Convert.ToDateTime(dataRow["POINT_DATE"])
                                                   , dataRow["STATUS_ID"]
                                                   , Convert.ToDateTime(dataRow["STATUS_DATE"])
                                                   , Convert.ToDateTime(dataRow["DATE"])
                                                   , dataRow["USER"]);
                    }
                    else
                    {
                        affectedRow += datas.Insert( null
                                                   , null
                                                   , dataRow["COMP_ID"]
                                                   , dataRow["EST_ID"]
                                                   , dataRow["ESTTERM_REF_ID"]
                                                   , dataRow["ESTTERM_SUB_ID"]
                                                   , dataRow["ESTTERM_STEP_ID"]
                                                   , dataRow["EST_DEPT_ID"]
                                                   , dataRow["EST_EMP_ID"]
                                                   , dataRow["PRJ_REF_ID"]
                                                   , dataRow["POINT"]
                                                   , dataRow["POINT_DATE"]
                                                   , dataRow["STATUS_ID"]
                                                   , dataRow["STATUS_DATE"]
                                                   , dataRow["DATE"]
                                                   , dataRow["USER"]);

                    }
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return (affectedRow > 0) ? true : false;
        }



        public bool SaveQuestionData_TGT_ID(DataTable dtQData, DataTable dtPrjData)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            Dac_Prj_Data datas = new Dac_Prj_Data();

            try
            {
                foreach (DataRow dataRow in dtQData.Rows)
                {
                    if (IsExist(DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                               , dataRow["EST_ID"].ToString()
                               , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                               , DataTypeUtility.GetToInt32(dataRow["USER"])
                               , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])
                               , dataRow["Q_SBJ_ID"].ToString()))
                    {
                        affectedRow += _questiondata.Update(null
                                                           , null
                                                           , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                           , dataRow["EST_ID"].ToString()
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])
                                                           , dataRow["Q_OBJ_ID"].ToString()
                                                           , dataRow["Q_SBJ_ID"].ToString()
                                                           , dataRow["Q_ITM_ID"].ToString()
                                                           , DataTypeUtility.GetToFloat(dataRow["POINT"])
                                                           , dataRow["GRADE_ID"].ToString()
                                                           , dataRow["TEXT_VALUE"].ToString()
                                                           , dataRow["OPINION"].ToString()
                                                           , dataRow["ATTACH_NO"].ToString()
                                                           , DateTime.Now
                                                           , DataTypeUtility.GetToInt32(dataRow["USER"]));
                    }
                    else
                    {
                        affectedRow += _questiondata.Insert(null
                                                            , null
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])
                                                            , dataRow["Q_OBJ_ID"].ToString()
                                                            , dataRow["Q_SBJ_ID"].ToString()
                                                            , dataRow["Q_ITM_ID"].ToString()
                                                            , DataTypeUtility.GetToFloat(dataRow["POINT"])
                                                            , dataRow["GRADE_ID"].ToString()
                                                            , dataRow["TEXT_VALUE"].ToString()
                                                            , dataRow["OPINION"].ToString()
                                                            , dataRow["ATTACH_NO"].ToString()
                                                            , DateTime.Now
                                                            , DataTypeUtility.GetToInt32(dataRow["USER"]));
                    }
                }

                // PRJ_DATA 저장
                foreach (DataRow dataRow in dtPrjData.Rows)
                {
                    if (datas.Count(DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                   , dataRow["EST_ID"].ToString()
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])) > 0)
                    {
                        affectedRow += datas.Update(null
                                                   , null
                                                   , dataRow["COMP_ID"]
                                                   , dataRow["EST_ID"]
                                                   , dataRow["ESTTERM_REF_ID"]
                                                   , dataRow["ESTTERM_SUB_ID"]
                                                   , dataRow["ESTTERM_STEP_ID"]
                                                   , dataRow["EST_DEPT_ID"]
                                                   , dataRow["EST_EMP_ID"]
                                                   , dataRow["TGT_DEPT_ID"]
                                                   , dataRow["TGT_EMP_ID"]
                                                   , dataRow["PRJ_REF_ID"]
                                                   , dataRow["POINT"]
                                                   , Convert.ToDateTime(dataRow["POINT_DATE"])
                                                   , dataRow["STATUS_ID"]
                                                   , Convert.ToDateTime(dataRow["STATUS_DATE"])
                                                   , Convert.ToDateTime(dataRow["DATE"])
                                                   , dataRow["USER"]);
                    }
                    else
                    {
                        affectedRow += datas.Insert(null
                                                   , null
                                                   , dataRow["COMP_ID"]
                                                   , dataRow["EST_ID"]
                                                   , dataRow["ESTTERM_REF_ID"]
                                                   , dataRow["ESTTERM_SUB_ID"]
                                                   , dataRow["ESTTERM_STEP_ID"]
                                                   , dataRow["EST_DEPT_ID"]
                                                   , dataRow["EST_EMP_ID"]
                                                   , dataRow["TGT_DEPT_ID"]
                                                   , dataRow["TGT_EMP_ID"]
                                                   , dataRow["PRJ_REF_ID"]
                                                   , dataRow["POINT"]
                                                   , dataRow["POINT_DATE"]
                                                   , dataRow["STATUS_ID"]
                                                   , dataRow["STATUS_DATE"]
                                                   , dataRow["DATE"]
                                                   , dataRow["USER"]);

                    }
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return (affectedRow > 0) ? true : false;
        }


        

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_SUB_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_STEP_ID", typeof(int));
            dataTable.Columns.Add("EST_DEPT_ID", typeof(int));
            dataTable.Columns.Add("EST_EMP_ID", typeof(int));
            dataTable.Columns.Add("PRJ_REF_ID", typeof(string));
            dataTable.Columns.Add("Q_OBJ_ID", typeof(string));
            dataTable.Columns.Add("Q_SBJ_ID", typeof(string));
            dataTable.Columns.Add("Q_ITM_ID", typeof(string));
            dataTable.Columns.Add("POINT", typeof(float));
            dataTable.Columns.Add("GRADE_ID", typeof(string));
            dataTable.Columns.Add("TEXT_VALUE", typeof(string));
            dataTable.Columns.Add("OPINION", typeof(string));
            dataTable.Columns.Add("ATTACH_NO", typeof(string));
            dataTable.Columns.Add("DATE", typeof(string));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}