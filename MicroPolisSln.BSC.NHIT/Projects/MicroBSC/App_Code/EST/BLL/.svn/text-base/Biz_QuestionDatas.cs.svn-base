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
    public class Biz_QuestionDatas
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private string _est_id;
        private int _estterm_ref_id;
        private int _estterm_sub_id;
        private int _estterm_step_id;
        private int _est_dept_id;
        private int _est_emp_id;
        private int _tgt_dept_id;
        private int _tgt_emp_id;
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

        private Dac_QuestionDatas _questiondata = new Dac_QuestionDatas();

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

        public Biz_QuestionDatas()
        {

        }

        public Biz_QuestionDatas( int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , string q_sbj_id)
        {
            DataSet ds = _questiondata.Select(comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , q_sbj_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _est_id             = (dr["EST_ID"]            == DBNull.Value) ? "" : dr["EST_ID"].ToString();
                _estterm_ref_id     = (dr["ESTTERM_REF_ID"]    == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id     = (dr["ESTTERM_SUB_ID"]    == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id    = (dr["ESTTERM_STEP_ID"]   == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id        = (dr["EST_DEPT_ID"]       == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id         = (dr["EST_EMP_ID"]        == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["EST_EMP_ID"]);
                _tgt_dept_id        = (dr["TGT_DEPT_ID"]       == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["TGT_DEPT_ID"]);
                _tgt_emp_id         = (dr["TGT_EMP_ID"]        == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["TGT_EMP_ID"]);
                _q_obj_id           = (dr["Q_OBJ_ID"]          == DBNull.Value) ? "" : dr["Q_OBJ_ID"].ToString();
                _q_sbj_id           = (dr["Q_SBJ_ID"]          == DBNull.Value) ? "" : dr["Q_SBJ_ID"].ToString();
                _q_itm_id           = (dr["Q_ITM_ID"]          == DBNull.Value) ? "" : dr["Q_ITM_ID"].ToString();
                _point              = (dr["POINT"]             == DBNull.Value) ? 0 :  DataTypeUtility.GetToFloat(dr["POINT"]);
                _grade_id           = (dr["GRADE_ID"]          == DBNull.Value) ? "" : dr["GRADE_ID"].ToString();
                _text_value         = (dr["TEXT_VALUE"]        == DBNull.Value) ? "" : dr["TEXT_VALUE"].ToString();
                _opinion            = (dr["OPINION"]           == DBNull.Value) ? "" : dr["OPINION"].ToString();
                _attach_no          = (dr["ATTACH_NO"]         == DBNull.Value) ? "" : dr["ATTACH_NO"].ToString();
                _update_date        = (dr["UPDATE_DATE"]       == DBNull.Value) ? DateTime.MinValue : DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user        = (dr["UPDATE_USER"]       == DBNull.Value) ? 0 :  DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public Biz_QuestionDatas(int comp_id
                               , string est_id
                               , int estterm_ref_id
                               , int estterm_sub_id
                               , int estterm_step_id
                               , int est_dept_id
                               , int est_emp_id
                               , int tgt_dept_id
                               , int tgt_emp_id)
        {
            DataSet ds = _questiondata.Select(comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , "");
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _comp_id = (dr["COMP_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _est_id = (dr["EST_ID"] == DBNull.Value) ? "" : dr["EST_ID"].ToString();
                _estterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id = (dr["ESTTERM_SUB_ID"] == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id = (dr["ESTTERM_STEP_ID"] == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id = (dr["EST_DEPT_ID"] == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id = (dr["EST_EMP_ID"] == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["EST_EMP_ID"]);
                _tgt_dept_id = (dr["TGT_DEPT_ID"] == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["TGT_DEPT_ID"]);
                _tgt_emp_id = (dr["TGT_EMP_ID"] == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["TGT_EMP_ID"]);
                _q_obj_id = (dr["Q_OBJ_ID"] == DBNull.Value) ? "" : dr["Q_OBJ_ID"].ToString();
                _q_sbj_id = (dr["Q_SBJ_ID"] == DBNull.Value) ? "" : dr["Q_SBJ_ID"].ToString();
                _q_itm_id = (dr["Q_ITM_ID"] == DBNull.Value) ? "" : dr["Q_ITM_ID"].ToString();
                _point = (dr["POINT"] == DBNull.Value) ? 0 : DataTypeUtility.GetToFloat(dr["POINT"]);
                _grade_id = (dr["GRADE_ID"] == DBNull.Value) ? "" : dr["GRADE_ID"].ToString();
                _text_value = (dr["TEXT_VALUE"] == DBNull.Value) ? "" : dr["TEXT_VALUE"].ToString();
                _opinion = (dr["OPINION"] == DBNull.Value) ? "" : dr["OPINION"].ToString();
                _attach_no = (dr["ATTACH_NO"] == DBNull.Value) ? "" : dr["ATTACH_NO"].ToString();
                _update_date = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyQuestionData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
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
                                                , tgt_dept_id
                                                , tgt_emp_id
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
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , string q_sbj_id)
        {
            return _questiondata.Select(comp_id
                                     , est_id
                                     , estterm_ref_id
                                     , estterm_sub_id
                                     , estterm_step_id
                                     , est_dept_id
                                     , est_emp_id
                                     , tgt_dept_id
                                     , tgt_emp_id
                                     , q_sbj_id);
        }

        public bool AddQuestionData(  int comp_id  
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
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
                                                , tgt_dept_id
                                                , tgt_emp_id
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
                                    , int tgt_dept_id
                                    , int tgt_emp_id
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
                                            , tgt_dept_id
                                            , tgt_emp_id
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
                            , int tgt_dept_id
                            , int tgt_emp_id
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
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , q_sbj_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public bool SaveQuestionData(DataTable dtQData, DataTable dtEstData, int update_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            Dac_Datas datas = new Dac_Datas();

            try
            {
                foreach (DataRow dataRow in dtQData.Rows)
                {
                    if(_questiondata.Count(  conn
                                           , trx
                                           , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                           , dataRow["EST_ID"].ToString()
                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                           , dataRow["Q_SBJ_ID"].ToString()) > 0)
                    {
                        affectedRow += _questiondata.Update( conn
                                                           , trx
                                                           , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                           , dataRow["EST_ID"].ToString()
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
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
                        affectedRow += _questiondata.Insert(  conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
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

                // EST_DATA 저장
                foreach (DataRow dataRow in dtEstData.Rows)
                {
                    if (datas.Count( conn
                                   , trx
                                   , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                   , dataRow["EST_ID"].ToString()
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                   , "") > 0)
                    {
                        //affectedRow += datas.Update(conn
                        //                           , trx
                        //                           , dataRow["COMP_ID"]
                        //                           , dataRow["EST_ID"]
                        //                           , dataRow["ESTTERM_REF_ID"]
                        //                           , dataRow["ESTTERM_SUB_ID"]
                        //                           , dataRow["ESTTERM_STEP_ID"]
                        //                           , dataRow["EST_DEPT_ID"]
                        //                           , dataRow["EST_EMP_ID"]
                        //                           , dataRow["TGT_DEPT_ID"]
                        //                           , dataRow["TGT_EMP_ID"]
                        //                           , DBNull.Value
                        //                           , dataRow["POINT_ORG"]
                        //                           , dataRow["POINT_ORG_DATE"]
                        //                           , dataRow["POINT_AVG"]
                        //                           , dataRow["POINT_AVG_DATE"]
                        //                           , dataRow["POINT_STD"]
                        //                           , dataRow["POINT_STD_DATE"]
                        //                           , dataRow["POINT_CTRL_ORG"]
                        //                           , dataRow["POINT_CTRL_ORG_DATE"]
                        //                           , dataRow["GRADE_CTRL_ORG_ID"]
                        //                           , dataRow["GRADE_CTRL_ORG_DATE"]
                        //                           , dataRow["POINT"]
                        //                           , dataRow["POINT_DATE"]
                        //                           , dataRow["GRADE_ID"]
                        //                           , dataRow["GRADE_DATE"]
                        //                           , dataRow["GRADE_TO_POINT"]
                        //                           , dataRow["GRADE_TO_POINT_DATE"]
                        //                           , dataRow["STATUS_ID"]
                        //                           , dataRow["STATUS_DATE"]
                        //                           , dataRow["DATE"]
                        //                           , dataRow["USER"]);

                        affectedRow += datas.Update(conn
                                                   , trx
                                                   , dataRow["COMP_ID"]
                                                   , dataRow["EST_ID"]
                                                   , dataRow["ESTTERM_REF_ID"]
                                                   , dataRow["ESTTERM_SUB_ID"]
                                                   , dataRow["ESTTERM_STEP_ID"]
                                                   , dataRow["EST_DEPT_ID"]
                                                   , dataRow["EST_EMP_ID"]
                                                   , dataRow["TGT_DEPT_ID"]
                                                   , dataRow["TGT_EMP_ID"]
                                                   , DBNull.Value
                                                   , dataRow["POINT_ORG"]
                                                   , dataRow["POINT_ORG_DATE"]
                                                   , dataRow["POINT"]
                                                   , dataRow["POINT_DATE"]
                                                   , dataRow["STATUS_ID"]
                                                   , dataRow["STATUS_DATE"]
                                                   , dataRow["DATE"]
                                                   , dataRow["USER"]);
                    }
                    else
                    {
                        affectedRow += datas.Insert( conn
                                                   , trx
                                                   , dataRow["COMP_ID"]
                                                   , dataRow["EST_ID"]
                                                   , dataRow["ESTTERM_REF_ID"]
                                                   , dataRow["ESTTERM_SUB_ID"]
                                                   , dataRow["ESTTERM_STEP_ID"]
                                                   , dataRow["EST_DEPT_ID"]
                                                   , dataRow["EST_EMP_ID"]
                                                   , dataRow["TGT_DEPT_ID"]
                                                   , dataRow["TGT_EMP_ID"]
                                                   , DBNull.Value                       // TGT_POS_CLS_ID
                                                   , DBNull.Value                       // TGT_POS_CLS_NAME
                                                   , DBNull.Value                       // TGT_POS_DUT_ID
                                                   , DBNull.Value                       // TGT_POS_DUT_NAME
                                                   , DBNull.Value                       // TGT_POS_GRP_ID
                                                   , DBNull.Value                       // TGT_POS_GRP_NAME
                                                   , DBNull.Value                       // TGT_POS_RNK_ID
                                                   , DBNull.Value                       // TGT_POS_RNK_NAME
                                                   , DBNull.Value                       // TGT_POS_KND_ID
                                                   , DBNull.Value                       // TGT_POS_KND_NAME
                                                   , DBNull.Value
                                                   , dataRow["POINT_ORG"]               // POINT_ORG
                                                   , dataRow["POINT_ORG_DATE"]          // POINT_ORG_DATE
                                                   , DBNull.Value                       // POINT_AVG
                                                   , DBNull.Value                       // POINT_AVG_DATE
                                                   , DBNull.Value                       // POINT_STD
                                                   , DBNull.Value                       // POINT_STD_DATE
                                                   , DBNull.Value
                                                   , DBNull.Value
                                                   , DBNull.Value
                                                   , DBNull.Value
                                                   , dataRow["POINT"]
                                                   , dataRow["POINT_DATE"]
                                                   , DBNull.Value                       // GRADE_ID
                                                   , DBNull.Value                       // GRADE_DATE
                                                   , DBNull.Value                       // GRADE_TO_POINT
                                                   , DBNull.Value                       // GRADE_TO_POINT_DATE
                                                   , dataRow["STATUS_ID"]
                                                   , dataRow["STATUS_DATE"]
                                                   , dataRow["DATE"]
                                                   , dataRow["USER"]);

                    }
                }

                if (dtEstData.Columns.Contains("POINT_CTRL_ORG") && dtEstData.Columns.Contains("POINT_AVG") && dtEstData.Columns.Contains("POINT_STD"))
                {
                    MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();
                    bizEstData.ModifyEstData_Point(conn, trx, dtEstData, update_user_ref_id);
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


        public bool SaveQuestionData(IDbConnection conn, IDbTransaction trx
                                    , DataTable dtQData
                                    , DataTable dtEstData)
        {
            int affectedRow = 0;

            Dac_Datas datas = new Dac_Datas();

            try
            {
                foreach (DataRow dataRow in dtQData.Rows)
                {
                    if (_questiondata.Count(conn
                                           , trx
                                           , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                           , dataRow["EST_ID"].ToString()
                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                           , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                           , dataRow["Q_SBJ_ID"].ToString()) > 0)
                    {
                        affectedRow += _questiondata.Update(conn
                                                           , trx
                                                           , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                           , dataRow["EST_ID"].ToString()
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                                           , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
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
                        affectedRow += _questiondata.Insert(conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
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

                // EST_DATA 저장
                foreach (DataRow dataRow in dtEstData.Rows)
                {
                    if (datas.Count(conn
                                   , trx
                                   , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                   , dataRow["EST_ID"].ToString()
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                   , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                   , "") > 0)
                    {
                        //affectedRow += datas.Update(conn
                        //                           , trx
                        //                           , dataRow["COMP_ID"]
                        //                           , dataRow["EST_ID"]
                        //                           , dataRow["ESTTERM_REF_ID"]
                        //                           , dataRow["ESTTERM_SUB_ID"]
                        //                           , dataRow["ESTTERM_STEP_ID"]
                        //                           , dataRow["EST_DEPT_ID"]
                        //                           , dataRow["EST_EMP_ID"]
                        //                           , dataRow["TGT_DEPT_ID"]
                        //                           , dataRow["TGT_EMP_ID"]
                        //                           , DBNull.Value
                        //                           , dataRow["POINT_ORG"]
                        //                           , dataRow["POINT_ORG_DATE"]
                        //                           , dataRow["POINT_AVG"]
                        //                           , dataRow["POINT_AVG_DATE"]
                        //                           , dataRow["POINT_STD"]
                        //                           , dataRow["POINT_STD_DATE"]
                        //                           , dataRow["POINT_CTRL_ORG"]
                        //                           , dataRow["POINT_CTRL_ORG_DATE"]
                        //                           , dataRow["GRADE_CTRL_ORG_ID"]
                        //                           , dataRow["GRADE_CTRL_ORG_DATE"]
                        //                           , dataRow["POINT"]
                        //                           , dataRow["POINT_DATE"]
                        //                           , dataRow["GRADE_ID"]
                        //                           , dataRow["GRADE_DATE"]
                        //                           , dataRow["GRADE_TO_POINT"]
                        //                           , dataRow["GRADE_TO_POINT_DATE"]
                        //                           , dataRow["STATUS_ID"]
                        //                           , dataRow["STATUS_DATE"]
                        //                           , dataRow["DATE"]
                        //                           , dataRow["USER"]);

                        affectedRow += datas.Update(conn
                                                   , trx
                                                   , dataRow["COMP_ID"]
                                                   , dataRow["EST_ID"]
                                                   , dataRow["ESTTERM_REF_ID"]
                                                   , dataRow["ESTTERM_SUB_ID"]
                                                   , dataRow["ESTTERM_STEP_ID"]
                                                   , dataRow["EST_DEPT_ID"]
                                                   , dataRow["EST_EMP_ID"]
                                                   , dataRow["TGT_DEPT_ID"]
                                                   , dataRow["TGT_EMP_ID"]
                                                   , DBNull.Value
                                                   , dataRow["POINT_ORG"]
                                                   , dataRow["POINT_ORG_DATE"]
                                                   , dataRow["POINT"]
                                                   , dataRow["POINT_DATE"]
                                                   , dataRow["STATUS_ID"]
                                                   , dataRow["STATUS_DATE"]
                                                   , dataRow["DATE"]
                                                   , dataRow["USER"]);
                    }
                    else
                    {
                        affectedRow += datas.Insert(conn
                                                   , trx
                                                   , dataRow["COMP_ID"]
                                                   , dataRow["EST_ID"]
                                                   , dataRow["ESTTERM_REF_ID"]
                                                   , dataRow["ESTTERM_SUB_ID"]
                                                   , dataRow["ESTTERM_STEP_ID"]
                                                   , dataRow["EST_DEPT_ID"]
                                                   , dataRow["EST_EMP_ID"]
                                                   , dataRow["TGT_DEPT_ID"]
                                                   , dataRow["TGT_EMP_ID"]
                                                   , DBNull.Value                       // TGT_POS_CLS_ID
                                                   , DBNull.Value                       // TGT_POS_CLS_NAME
                                                   , DBNull.Value                       // TGT_POS_DUT_ID
                                                   , DBNull.Value                       // TGT_POS_DUT_NAME
                                                   , DBNull.Value                       // TGT_POS_GRP_ID
                                                   , DBNull.Value                       // TGT_POS_GRP_NAME
                                                   , DBNull.Value                       // TGT_POS_RNK_ID
                                                   , DBNull.Value                       // TGT_POS_RNK_NAME
                                                   , DBNull.Value                       // TGT_POS_KND_ID
                                                   , DBNull.Value                       // TGT_POS_KND_NAME
                                                   , DBNull.Value
                                                   , dataRow["POINT_ORG"]               // POINT_ORG
                                                   , dataRow["POINT_ORG_DATE"]          // POINT_ORG_DATE
                                                   , DBNull.Value                       // POINT_AVG
                                                   , DBNull.Value                       // POINT_AVG_DATE
                                                   , DBNull.Value                       // POINT_STD
                                                   , DBNull.Value                       // POINT_STD_DATE
                                                   , DBNull.Value
                                                   , DBNull.Value
                                                   , DBNull.Value
                                                   , DBNull.Value
                                                   , dataRow["POINT"]
                                                   , dataRow["POINT_DATE"]
                                                   , DBNull.Value                       // GRADE_ID
                                                   , DBNull.Value                       // GRADE_DATE
                                                   , DBNull.Value                       // GRADE_TO_POINT
                                                   , DBNull.Value                       // GRADE_TO_POINT_DATE
                                                   , dataRow["STATUS_ID"]
                                                   , dataRow["STATUS_DATE"]
                                                   , dataRow["DATE"]
                                                   , dataRow["USER"]);

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
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
            dataTable.Columns.Add("TGT_DEPT_ID", typeof(string));
            dataTable.Columns.Add("TGT_EMP_ID", typeof(string));
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