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
using MicroBSC.Integration.BSC.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_Datas
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
        private string _tgt_pos_cls_id;
        private string _tgt_pos_cls_name;
        private string _tgt_pos_dut_id;
        private string _tgt_pos_dut_name;
        private string _tgt_pos_grp_id;
        private string _tgt_pos_grp_name;
        private string _tgt_pos_rnk_id;
        private string _tgt_pos_rnk_name;
        private string _tgt_pos_knd_id;
        private string _tgt_pos_knd_name;
        private float _point_org;
        private DateTime _point_org_date;
        private float _point_avg;
        private DateTime _point_avg_date;
        private float _point_std;
        private DateTime _point_std_date;
        private float _point_ctrl_org;
        private DateTime _point_ctrl_org_date;
        private string _grade_ctrl_org_id;
        private DateTime _grade_ctrl_org_date;
        private float _point;
        private DateTime _point_date;
        private string _direction_type;
        private string _grade_id = "";
        private DateTime _grade_date;
        private string _status_id = "N";
        private DateTime _status_date;
        private DateTime _update_date;
        private int _update_user;
        private string _errMsg;

        private Dac_Datas _data = new Dac_Datas();

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

        public string Tgt_Pos_Cls_ID
        {
            get
            {
                return _tgt_pos_cls_id;
            }
            set
            {
                _tgt_pos_cls_id = value;
            }
        }

        public string Tgt_Pos_Cls_Name
        {
            get
            {
                return _tgt_pos_cls_name;
            }
            set
            {
                _tgt_pos_cls_name = value;
            }
        }

        public string Tgt_Pos_Dut_ID
        {
            get
            {
                return _tgt_pos_dut_id;
            }
            set
            {
                _tgt_pos_dut_id = value;
            }
        }

        public string Tgt_Pos_Dut_Name
        {
            get
            {
                return _tgt_pos_dut_name;
            }
            set
            {
                _tgt_pos_dut_name = value;
            }
        }

        public string Tgt_Pos_Grp_ID
        {
            get
            {
                return _tgt_pos_grp_id;
            }
            set
            {
                _tgt_pos_grp_id = value;
            }
        }

        public string Tgt_Pos_Grp_Name
        {
            get
            {
                return _tgt_pos_grp_name;
            }
            set
            {
                _tgt_pos_grp_name = value;
            }
        }

        public string Tgt_Pos_Rnk_ID
        {
            get
            {
                return _tgt_pos_rnk_id;
            }
            set
            {
                _tgt_pos_rnk_id = value;
            }
        }

        public string Tgt_Pos_Rnk_Name
        {
            get
            {
                return _tgt_pos_rnk_name;
            }
            set
            {
                _tgt_pos_rnk_name = value;
            }
        }

        public string Tgt_Pos_Knd_ID
        {
            get
            {
                return _tgt_pos_knd_id;
            }
            set
            {
                _tgt_pos_knd_id = value;
            }
        }

        public string Tgt_Pos_Knd_Name
        {
            get
            {
                return _tgt_pos_knd_name;
            }
            set
            {
                _tgt_pos_knd_name = value;
            }
        }

        public float Point_Org
        {
            get
            {
                return _point_org;
            }
            set
            {
                _point_org = value;
            }
        }

        public DateTime Point_Org_Date
        {
            get
            {
                return _point_org_date;
            }
            set
            {
                _point_date = value;
            }
        }

        public float Point_Avg
        {
            get
            {
                return _point_avg;
            }
            set
            {
                _point_avg = value;
            }
        }

        public DateTime Point_Avg_Date
        {
            get
            {
                return _point_avg_date;
            }
            set
            {
                _point_avg_date = value;
            }
        }

        public float Point_Std
        {
            get
            {
                return _point_std;
            }
            set
            {
                _point_std = value;
            }
        }

        public DateTime Point_Std_Date
        {
            get
            {
                return _point_std_date;
            }
            set
            {
                _point_std_date = value;
            }
        }



        public float Point_Ctrl_Org
        {
            get
            {
                return _point_ctrl_org;
            }
            set
            {
                _point_ctrl_org = value;
            }
        }

        public DateTime Point_Ctrl_Org_Date
        {
            get
            {
                return _point_ctrl_org_date;
            }
            set
            {
                _point_ctrl_org_date = value;
            }
        }

        public string Grade_Ctrl_Org_ID
        {
            get
            {
                return _grade_ctrl_org_id;
            }
            set
            {
                _grade_ctrl_org_id = value;
            }
        }

        public DateTime Grade_Ctrl_Org_Date
        {
            get
            {
                return _grade_ctrl_org_date;
            }
            set
            {
                _grade_ctrl_org_date = value;
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

        public string Direction_Type 
        {
            get
            {
                return _direction_type;
            }
            set 
            {
                _direction_type = value;
            }
        }

        public string Status_ID
        {
            get 
            { 
                return _status_id; 
            }
            set 
            { 
                _status_id = (value == null ? "N" : value); 
            }
        }

        public string Err_Msg
        {
            get
            {
                return _errMsg;
            }
            set
            {
                _errMsg = (value == null ? "" : value);
            }
        }

        public DateTime Status_Date
        {
            get
            {
                return _status_date;
            }
            set
            {
                _status_date = value;
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

        public Biz_Datas()
        {

        }

        public Biz_Datas( int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id)
        {
            DataSet ds = _data.Select(null
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
                                    , ""
                                    , ""
                                    , OwnerType.All);

            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]             == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _est_id             = (dr["EST_ID"]              == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _estterm_ref_id     = (dr["ESTTERM_REF_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id     = (dr["ESTTERM_SUB_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id    = (dr["ESTTERM_STEP_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id        = (dr["EST_DEPT_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id         = (dr["EST_EMP_ID"]          == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_EMP_ID"]);
                _tgt_dept_id        = (dr["TGT_DEPT_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_DEPT_ID"]);
                _tgt_emp_id         = (dr["TGT_EMP_ID"]          == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_EMP_ID"]);
                _tgt_pos_cls_id     = (dr["TGT_POS_CLS_ID"]      == DBNull.Value) ? "" : (string)dr["TGT_POS_CLS_ID"];
                _tgt_pos_cls_name   = (dr["TGT_POS_CLS_NAME"]    == DBNull.Value) ? "" : (string)dr["TGT_POS_CLS_NAME"];
                _tgt_pos_dut_id     = (dr["TGT_POS_DUT_ID"]      == DBNull.Value) ? "" : (string)dr["TGT_POS_DUT_ID"];
                _tgt_pos_dut_name   = (dr["TGT_POS_DUT_NAME"]    == DBNull.Value) ? "" : (string)dr["TGT_POS_DUT_NAME"];
                _tgt_pos_grp_id     = (dr["TGT_POS_GRP_ID"]      == DBNull.Value) ? "" : (string)dr["TGT_POS_GRP_ID"];
                _tgt_pos_grp_name   = (dr["TGT_POS_GRP_NAME"]    == DBNull.Value) ? "" : (string)dr["TGT_POS_GRP_NAME"];
                _tgt_pos_rnk_id     = (dr["TGT_POS_RNK_ID"]      == DBNull.Value) ? "" : (string)dr["TGT_POS_RNK_ID"];
                _tgt_pos_rnk_name   = (dr["TGT_POS_RNK_NAME"]    == DBNull.Value) ? "" : (string)dr["TGT_POS_RNK_NAME"];
                _tgt_pos_knd_id     = (dr["TGT_POS_KND_ID"]      == DBNull.Value) ? "" : (string)dr["TGT_POS_KND_ID"];
                _tgt_pos_knd_name   = (dr["TGT_POS_KND_NAME"]    == DBNull.Value) ? "" : (string)dr["TGT_POS_KND_NAME"];
                _point_org          = (dr["POINT_ORG"]           == DBNull.Value) ? 0 : Convert.ToSingle(dr["POINT_ORG"]);
                _point_org_date     = (dr["POINT_ORG_DATE"]      == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["POINT_ORG_DATE"];
                _point_avg          = (dr["POINT_AVG"]           == DBNull.Value) ? 0 : Convert.ToSingle(dr["POINT_AVG"]);
                _point_avg_date     = (dr["POINT_AVG_DATE"]      == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["POINT_AVG_DATE"];
                _point_std          = (dr["POINT_STD"]           == DBNull.Value) ? 0 : Convert.ToSingle(dr["POINT_STD"]);
                _point_std_date     = (dr["POINT_STD_DATE"]      == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["POINT_STD_DATE"];
                _point_ctrl_org     = (dr["POINT_CTRL_ORG"]      == DBNull.Value) ? 0 : Convert.ToSingle(dr["POINT_CTRL_ORG"]);
                _point_ctrl_org_date= (dr["POINT_CTRL_ORG_DATE"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["POINT_CTRL_ORG_DATE"];
                _grade_ctrl_org_id  = (dr["GRADE_CTRL_ORG_ID"]   == DBNull.Value) ? "" : dr["GRADE_CTRL_ORG_ID"].ToString();
                _grade_ctrl_org_date= (dr["GRADE_CTRL_ORG_DATE"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["GRADE_CTRL_ORG_DATE"];
                _point              = (dr["POINT"]               == DBNull.Value) ? 0 : Convert.ToSingle(dr["POINT"]);
                _point_date         = (dr["POINT_DATE"]          == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["POINT_DATE"];
                _grade_id           = (dr["GRADE_ID"]            == DBNull.Value) ? "" : (string)dr["GRADE_ID"];
                _grade_date         = (dr["GRADE_DATE"]          == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["GRADE_DATE"];
                _direction_type     = (dr["DIRECTION_TYPE"]      == DBNull.Value) ? "DN" : (string)dr["DIRECTION_TYPE"];
                _status_id          = (dr["STATUS_ID"]           == DBNull.Value) ? "" : (string)dr["STATUS_ID"];
                _status_date        = (dr["STATUS_DATE"]         == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["STATUS_DATE"];
                _update_date        = (dr["UPDATE_DATE"]         == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user        = (dr["UPDATE_USER"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyData(   int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , string direction_type
                                , float point_org
                                , DateTime point_org_date
                                , float point_avg
                                , DateTime point_avg_date
                                , float point_std
                                , DateTime point_std_date
                                , float point_ctrl_org
                                , DateTime point_ctrl_org_date
                                , float grade_ctrl_org_id
                                , DateTime grade_ctrl_org_date
                                , float point
                                , DateTime point_date
                                , string grade_id
                                , DateTime grade_date
                                , float grade_to_point
                                , DateTime grade_to_point_date
                                , string status_id
                                , DateTime status_date
                                , DateTime update_date
                                , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _data.Update(   null
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
                                        , direction_type
                                        , point_org
                                        , point_org_date
                                        , point_avg
                                        , point_avg_date
                                        , point_std
                                        , point_std_date
                                        , point_ctrl_org
                                        , point_ctrl_org_date
                                        , grade_ctrl_org_id
                                        , grade_ctrl_org_date
                                        , point
                                        , point_date
                                        , grade_id
                                        , grade_date
                                        , grade_to_point
                                        , grade_to_point_date
                                        , status_id
                                        , status_date
                                        , update_date
                                        , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool ConfirmGrade(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _data.UpdateGrade(  conn
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
                                                , dataRow["GRADE_ID"]
                                                , dataRow["GRADE_DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);

                    //affectedRow += _data.Update(conn
                    //                            , trx
                    //                            , dataRow["COMP_ID"]
                    //                            , dataRow["EST_ID"]
                    //                            , dataRow["ESTTERM_REF_ID"]
                    //                            , dataRow["ESTTERM_SUB_ID"]
                    //                            , dataRow["ESTTERM_STEP_ID"]
                    //                            , dataRow["EST_DEPT_ID"]
                    //                            , dataRow["EST_EMP_ID"]
                    //                            , dataRow["TGT_DEPT_ID"]
                    //                            , dataRow["TGT_EMP_ID"]
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , dataRow["GRADE_ID"]
                    //                            , dataRow["GRADE_DATE"]
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , dataRow["DATE"]
                    //                            , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        public bool GradeToPoint(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _data.Update(  conn
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
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , dataRow["GRADE_TO_POINT"]
                                                , dataRow["GRADE_TO_POINT_DATE"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        

        public DataSet GetData(   int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id)
        {
            return _data.Select(  null
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
                                , ""
                                , ""
                                , OwnerType.All);
        }

        /// <summary>
        /// 로그인한 사람의 관련된 평가 정보를 반환한다.
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="estterm_sub_id"></param>
        /// <param name="tgt_emp_id"></param>
        /// <returns></returns>
        public DataSet GetEstIDByTgtEmp(  int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int tgt_emp_id)
        {
            return _data.SelectTgtEmp(comp_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , tgt_emp_id);
        }

        public DataSet Get3GAData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int emp_ref_id)
        {
            return _data.Get3GAData(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , emp_ref_id);
        }

        public DataSet Get3GADataEstData(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int dept_ref_id)
        {
            return _data.Get3GADataEstData(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , dept_ref_id);
        }

        public DataSet Get3GADataList(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int usertype
                                    , int emp_ref_id)
        {
            return _data.Get3GADataList(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , usertype
                                        , emp_ref_id);
        }

        public bool UpdateMboDTGrade(bool isOverStep
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , object[,] objGrade)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboDTGrade(conn
                                                , trx
                                                , isOverStep
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , objGrade);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }


        public bool UpdateMboDTGrade(bool isOverStep
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , object[,] objGrade
                                    , double[] scoreMT
                                    , string[] ymd
                                    , int update_user_ref_id)
        {
            Dac_Bsc_Mbo_Kpi_Score_Mt dacBscMboKpiScoreMt = new Dac_Bsc_Mbo_Kpi_Score_Mt();

            bool rtnValue = false;
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboDTGrade(conn
                                                , trx
                                                , isOverStep
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , objGrade);

                if(rtnValue)
                {
                    for (int i = 0; i < scoreMT.Length; i++)
                    {
                        if (scoreMT[i] >= 0.0)
                        {
                            affectedRow = dacBscMboKpiScoreMt.Update_Score(conn, trx
                                                                        , comp_id
                                                                        , est_id
                                                                        , estterm_ref_id
                                                                        , estterm_sub_id
                                                                        , estterm_step_id
                                                                        , ymd[i]
                                                                        , est_dept_id
                                                                        , est_emp_id
                                                                        , tgt_dept_id
                                                                        , tgt_emp_id
                                                                        , scoreMT[i]
                                                                        , update_user_ref_id);
                        }
                    }
                }
                
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
                rtnValue = false;
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboMTGrade(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboMTGrade(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , comment);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboEstStatusAll(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string status)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboEstDTStatus(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , status);
                if (rtnValue)
                {
                    rtnValue = _data.UpdateMboEstMTStatus(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , status);
                    if (rtnValue)
                        trx.Commit();
                    else
                        trx.Rollback();
                }
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboEstMTStatus(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string status)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboEstMTStatus(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , status);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public string GetMboReportStatus(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id)
        { 
            return _data.GetMboReportStatus(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , tgt_dept_id
                                        , tgt_emp_id);
        }

        public bool UpdateMboReport(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string report
                                    , string report_file
                                    , string status)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboReport(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , report
                                            , report_file
                                            , status);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboReport_3A(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string report
                                    , string report_file
                                    , string status)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboReport_3A(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , report
                                            , report_file
                                            , status);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboEst(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , string comment
                                , string status)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboEst(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , comment
                                            , status);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboEstCancel(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment
                                    , string status)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboEstCancel(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , comment
                                            , status);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch(Exception ex)
            {
                Err_Msg = ex.Message;
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboEstReject(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment
                                    , string status
                                    , string confirm_type)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboEstReject(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , comment
                                            , status
                                            , confirm_type);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }


        public bool UpdateMboEstReject_3A(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment
                                    , string status
                                    , string confirm_type)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboEstReject_3A(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , comment
                                            , status
                                            , confirm_type);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboFeedBack(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string status)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboFeedBack(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq
                                                , comment
                                                , status);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboFeedBack_3A(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string status)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboFeedBack_3A(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq
                                                , comment
                                                , status);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboFeedBack(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string status
                                    , string confirm_type)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboFeedBack(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq
                                                , comment
                                                , status
                                                , confirm_type);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool UpdateMboFeedBack_3A(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string status
                                    , string confirm_type)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = _data.UpdateMboFeedBack_3A(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq
                                                , comment
                                                , status
                                                , confirm_type);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public DataSet Get3GAKpiDataList(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id)
        {
            return _data.Get3GAKpiDataList(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , est_dept_id
                                        , est_emp_id
                                        , tgt_dept_id
                                        , tgt_emp_id);
        }

        public DataSet Get3GAKpiDataList(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int admin)
        {
            return _data.Get3GAKpiDataList(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , est_dept_id
                                        , est_emp_id
                                        , tgt_dept_id
                                        , tgt_emp_id
                                        , admin);
        }

        public DataSet GetData(   int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , string year_yn
                                , string merge_yn
                                , OwnerType ownerType)
        {
            return _data.Select(  null
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
                                , year_yn
                                , merge_yn
                                , ownerType);
        }

        public DataSet GetDataByMergeYN(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string merge_yn)
        {
            return _data.Select(  null
                                , null
                                , comp_id
                                , est_id
                                , estterm_ref_id
                                , estterm_sub_id
                                , estterm_step_id
                                , 0
                                , 0
                                , 0
                                , 0
                                , ""
                                , merge_yn
                                , OwnerType.All);
        }

        public DataSet GetDataByMergeYN(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string merge_yn
                                        , OwnerType ownerType)
        {
            return _data.Select(  null
                                , null
                                , comp_id
                                , est_id
                                , estterm_ref_id
                                , estterm_sub_id
                                , estterm_step_id
                                , 0
                                , 0
                                , 0
                                , 0
                                , ""
                                , merge_yn
                                , ownerType);
        }

        public DataSet GetDataByYearYN(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string year_yn)
        {
            return _data.Select(  null
                                , null
                                , comp_id
                                , est_id
                                , estterm_ref_id
                                , estterm_sub_id
                                , estterm_step_id
                                , 0
                                , 0
                                , 0
                                , 0
                                , year_yn
                                , ""
                                , OwnerType.All);
        }

        public DataSet GetDataByYearYN(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string year_yn
                                        , OwnerType ownerType)
        {
            return _data.Select(  null
                                , null
                                , comp_id
                                , est_id
                                , estterm_ref_id
                                , estterm_sub_id
                                , estterm_step_id
                                , 0
                                , 0
                                , 0
                                , 0
                                , year_yn
                                , ""
                                , ownerType);
        }

        public string GetBiasQueryScript( int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string bias_type
                                        , string dept_values)
        {
            return _data.SelectBiasDataScript(comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , bias_type
                                            , dept_values);
        }

        public DataTable GetBiasQueryData(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string bias_type
                                        , string dept_values)
        {
            return _data.SelectBiasData(  comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , bias_type
                                        , dept_values);
        }

        #region --BSC_PERSON_EVALUATION

        public DataSet GetEvaluationDataScheme()
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();

            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("YY", typeof(string));
            dataTable.Columns.Add("DD", typeof(string));
            dataTable.Columns.Add("EMP_REF_ID", typeof(int));
            dataTable.Columns.Add("EMP_CODE", typeof(string));
            dataTable.Columns.Add("ORGANIZATION_POINT", typeof(double));
            dataTable.Columns.Add("ORGANIZATION_WEIGHT", typeof(double));
            dataTable.Columns.Add("APPRAISAL_POINT", typeof(double));
            dataTable.Columns.Add("APPRAISAL_WEIGHT", typeof(double));
            dataTable.Columns.Add("OTHERS1_POINT", typeof(double));
            dataTable.Columns.Add("OTHERS1_WEIGHT", typeof(double));
            dataTable.Columns.Add("OTHERS2_POINT", typeof(double));
            dataTable.Columns.Add("OTHERS2_WEIGHT", typeof(double));
            dataTable.Columns.Add("OTHERS3_POINT", typeof(double));
            dataTable.Columns.Add("OTHERS3_WEIGHT", typeof(double));
            dataTable.Columns.Add("WEIGHT_SUM", typeof(double));
            dataTable.Columns.Add("POINT_SUM", typeof(double));
            dataTable.Columns.Add("STANDARD_SCORE", typeof(double));
            dataTable.Columns.Add("STANDARD_RATING", typeof(string));
            dataTable.Columns.Add("CREATE_USER", typeof(int));
            dataTable.Columns.Add("CREATE_DATE", typeof(DateTime));
            dataTable.Columns.Add("UPDATE_USER", typeof(int));
            dataTable.Columns.Add("UPDATE_DATE", typeof(DateTime));
            dataTable.Columns.Add("POS_GRP_ID", typeof(string));

            dataSet.Tables.Add(dataTable);

            dataTable2.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable2.Columns.Add("YY", typeof(string));
            dataTable2.Columns.Add("DD", typeof(string));
            dataTable2.Columns.Add("POS_GRP_ID", typeof(string));
            dataTable2.Columns.Add("GROUP_MEAN", typeof(double));
            dataTable2.Columns.Add("STANDARD_DEVIATION", typeof(double));
            dataTable2.Columns.Add("GROUP_SKEWNESS", typeof(double));
            dataTable2.Columns.Add("GROUP_KURTOSIS", typeof(double));
            dataTable2.Columns.Add("CREATE_USER", typeof(int));
            dataTable2.Columns.Add("CREATE_DATE", typeof(DateTime));
            dataTable2.Columns.Add("UPDATE_USER", typeof(int));
            dataTable2.Columns.Add("UPDATE_DATE", typeof(DateTime));

            dataSet.Tables.Add(dataTable2);
            return dataSet ;
        }

        public DataTable GetEvaluationScoreInfo(int estterm_ref_id)
        {
            return _data.GetEvaluationScoreInfo(estterm_ref_id);
        }

        public DataSet GetPersonEavluation(int comp_id
                                , int estterm_ref_id
                                , string iymd)
        {
            return _data.SelectPersonEavluation(comp_id
                                , estterm_ref_id
                                , iymd);
        }

        public DataSet GetPersonEavluationPoint(int comp_id
                                , int estterm_ref_id
                                , string iymd)
        {
            return _data.SelectPersonEavluationPoint(comp_id
                                , estterm_ref_id
                                , iymd);
        }

        public DataSet GetGroupEavluation(int comp_id
                                , int estterm_ref_id
                                , string iymd
                                , string pos_grp_code)
        {
            return _data.SelectGroupEavluation(comp_id
                                , estterm_ref_id
                                , iymd
                                , pos_grp_code);
        }

        public DataSet GetGroupEavluationData(int comp_id
                                , int estterm_ref_id
                                , string iymd
                                , string pos_grp_code)
        {
            return _data.SelectGroupEavluationData(comp_id
                                , estterm_ref_id
                                , iymd
                                , pos_grp_code);
        }

        public bool SaveDataPersonEvaluation(DataTable dataTable, bool allowUpdate)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (_data.CountPersonEvaluation(conn
                                                , trx
                                                , dataRow["ESTTERM_REF_ID"]
                                                , dataRow["YY"]
                                                , dataRow["DD"]
                                                , dataRow["EMP_REF_ID"]) == 0)
                    {
                        affectedRow += _data.InsertPersonEvaluation(conn
                                                               , trx
                                                               , dataRow["ESTTERM_REF_ID"]
                                                               , dataRow["YY"]
                                                               , dataRow["DD"]
                                                               , dataRow["EMP_REF_ID"]
                                                               , dataRow["EMP_CODE"]
                                                               , dataRow["ORGANIZATION_POINT"]
                                                               , dataRow["ORGANIZATION_WEIGHT"]
                                                               , dataRow["APPRAISAL_POINT"]
                                                               , dataRow["APPRAISAL_WEIGHT"]
                                                               , dataRow["OTHERS1_POINT"]
                                                               , dataRow["OTHERS1_WEIGHT"]
                                                               , dataRow["OTHERS2_POINT"]
                                                               , dataRow["OTHERS2_WEIGHT"]
                                                               , dataRow["OTHERS3_POINT"]
                                                               , dataRow["OTHERS3_WEIGHT"]
                                                               , dataRow["WEIGHT_SUM"]
                                                               , dataRow["POINT_SUM"]
                                                               , dataRow["STANDARD_SCORE"]
                                                               , dataRow["STANDARD_RATING"]
                                                               , dataRow["CREATE_USER"]
                                                               , dataRow["CREATE_DATE"]
                                                               , dataRow["UPDATE_USER"]
                                                               , dataRow["UPDATE_DATE"]);
                    }
                    else
                    {
                        if (allowUpdate)
                            affectedRow += _data.UpdatePersonEvaluation(conn
                                                                    , trx
                                                                    , dataRow["ESTTERM_REF_ID"]
                                                                    , dataRow["YY"]
                                                                    , dataRow["DD"]
                                                                    , dataRow["EMP_REF_ID"]
                                                                    , dataRow["EMP_CODE"]
                                                                    , dataRow["ORGANIZATION_POINT"]
                                                                    , dataRow["ORGANIZATION_WEIGHT"]
                                                                    , dataRow["APPRAISAL_POINT"]
                                                                    , dataRow["APPRAISAL_WEIGHT"]
                                                                    , dataRow["OTHERS1_POINT"]
                                                                    , dataRow["OTHERS1_WEIGHT"]
                                                                    , dataRow["OTHERS2_POINT"]
                                                                    , dataRow["OTHERS2_WEIGHT"]
                                                                    , dataRow["OTHERS3_POINT"]
                                                                    , dataRow["OTHERS3_WEIGHT"]
                                                                    , dataRow["WEIGHT_SUM"]
                                                                    , dataRow["POINT_SUM"]
                                                                    , dataRow["STANDARD_SCORE"]
                                                                    , dataRow["STANDARD_RATING"]
                                                                    , dataRow["CREATE_USER"]
                                                                    , dataRow["CREATE_DATE"]
                                                                    , dataRow["UPDATE_USER"]
                                                                    , dataRow["UPDATE_DATE"]);
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

        public bool SaveDataGroupEvaluation(DataTable dataTable, bool allowUpdate)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (_data.CountGroupEvaluation(conn
                                                , trx
                                                , dataRow["ESTTERM_REF_ID"]
                                                , dataRow["YY"]
                                                , dataRow["DD"]
                                                , dataRow["POS_GRP_ID"]) == 0)
                    {
                        affectedRow += _data.InsertGroupEvaluation(conn
                                                               , trx
                                                               , dataRow["ESTTERM_REF_ID"]
                                                               , dataRow["YY"]
                                                               , dataRow["DD"]
                                                               , dataRow["POS_GRP_ID"]
                                                               , dataRow["GROUP_MEAN"]
                                                               , dataRow["STANDARD_DEVIATION"]
                                                               , dataRow["GROUP_SKEWNESS"]
                                                               , dataRow["GROUP_KURTOSIS"]
                                                               , dataRow["CREATE_USER"]
                                                               , dataRow["CREATE_DATE"]
                                                               , dataRow["UPDATE_USER"]
                                                               , dataRow["UPDATE_DATE"]);
                    }
                    else
                    {
                        if (allowUpdate)
                            affectedRow += _data.UpdateGroupEvaluation(conn
                                                                    , trx
                                                                    , dataRow["ESTTERM_REF_ID"]
                                                                    , dataRow["YY"]
                                                                    , dataRow["DD"]
                                                                    , dataRow["POS_GRP_ID"]
                                                                    , dataRow["GROUP_MEAN"]
                                                                    , dataRow["STANDARD_DEVIATION"]
                                                                    , dataRow["GROUP_SKEWNESS"]
                                                                    , dataRow["GROUP_KURTOSIS"]
                                                                    , dataRow["CREATE_USER"]
                                                                    , dataRow["CREATE_DATE"]
                                                                    , dataRow["UPDATE_USER"]
                                                                    , dataRow["UPDATE_DATE"]);
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
        #endregion

        public DataSet GetEstData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , string year_yn
                                , string merge_yn)
        {
            return _data.SelectEstData(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , tgt_dept_id
                                    , tgt_emp_id
                                    , year_yn
                                    , merge_yn
                                    , OwnerType.All
                                    , "");
        }

        public DataSet GetEstData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id)
        {
            return _data.SelectEstData(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , tgt_dept_id
                                    , tgt_emp_id
                                    , ""
                                    , ""
                                    , OwnerType.All
                                    , "");
        }

        public DataSet GetEstData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , string year_yn
                                , string merge_yn
                                , OwnerType ownerType)
        {
            return _data.SelectEstData(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , tgt_dept_id
                                    , tgt_emp_id
                                    , year_yn
                                    , merge_yn
                                    , ownerType
                                    , "");
        }

        // 의견상신일 경우 의견상신이 모두 끝났는지 체크
        public bool CheckStatusByOpinion( int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id)
        {
            int cnt_n =  _data.Count(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , 0
                                    , 0
                                    , 0
                                    , 0
                                    , "N");

            int cnt_o =  _data.Count(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , 0
                                    , 0
                                    , 0
                                    , 0
                                    , "O");

            int cnt_all =  _data.Count(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , 0
                                    , 0
                                    , 0
                                    , 0
                                    , "");

            if(cnt_n == 0 && cnt_o == 0 && cnt_all > 0)
                return true;

            return false;
        }

        // 평가자 일때 질의평가가 완료되었는 체크
        public bool CheckStatusByEstEmp(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string feedback_yn)
        {
            string status_id    = "";
            int cnt_e           =  0;

            if(feedback_yn.Equals("Y")) 
            {
                status_id   = "C";

                cnt_e       +=  _data.Count(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , 0
                                        , 0
                                        , 0
                                        , 0
                                        , "C");

                cnt_e       +=  _data.Count(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , 0
                                        , 0
                                        , 0
                                        , 0
                                        , "P");

                cnt_e       +=  _data.Count(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , 0
                                        , 0
                                        , 0
                                        , 0
                                        , "E");
            }
            else 
            {
                status_id   = "E";

                cnt_e       =  _data.Count(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , 0
                                        , 0
                                        , 0
                                        , 0
                                        , status_id);
            }

            int cnt_all =  _data.Count(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , 0
                                    , 0
                                    , 0
                                    , 0
                                    , "");

            if(cnt_e == cnt_all && cnt_all > 0)
                return true;

            return false;
        }

        // 피평가자 일때 질의평가가 모두 피드백 되었는 체크
        public bool CheckStatusByFeedback(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id)
        {
            int cnt_e =  _data.Count( comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , 0
                                    , 0
                                    , 0
                                    , 0
                                    , "E");

            int cnt_all =  _data.Count(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , 0
                                    , 0
                                    , 0
                                    , 0
                                    , "");

            if(cnt_e == cnt_all && cnt_all > 0)
                return true;

            return false;
        }

        public bool AddData(  int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , float point_org
                            , DateTime point_org_date
                            , string status_id
                            , DateTime status_date
                            , DateTime create_date
                            , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _data.Insert(null
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
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , point_org
                                    , point_org_date
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , status_id
                                    , status_date
                                    , create_date
                                    , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool SaveData(DataTable dataTable)
        {
            return SaveData(dataTable, false);
        }

        public bool SaveData(DataTable dataTable, bool allowUpdate)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    if(_data.Count(conn
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
                                , "") == 0) 
                    {
                         affectedRow += _data.Insert( conn
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
                                                    , dataRow["TGT_POS_CLS_ID"]
                                                    , dataRow["TGT_POS_CLS_NAME"]
                                                    , dataRow["TGT_POS_DUT_ID"]
                                                    , dataRow["TGT_POS_DUT_NAME"]
                                                    , dataRow["TGT_POS_GRP_ID"]
                                                    , dataRow["TGT_POS_GRP_NAME"]
                                                    , dataRow["TGT_POS_RNK_ID"]
                                                    , dataRow["TGT_POS_RNK_NAME"]
                                                    , dataRow["TGT_POS_KND_ID"]
                                                    , dataRow["TGT_POS_KND_NAME"]
                                                    , dataRow["DIRECTION_TYPE"]
                                                    , dataRow["POINT_ORG"]
                                                    , dataRow["POINT_ORG_DATE"]
                                                    , dataRow["POINT_AVG"]
                                                    , dataRow["POINT_AVG_DATE"]
                                                    , dataRow["POINT_STD"]
                                                    , dataRow["POINT_STD_DATE"]
                                                    , dataRow["POINT_CTRL_ORG"]
                                                    , dataRow["POINT_CTRL_ORG_DATE"]
                                                    , dataRow["GRADE_CTRL_ORG_ID"]
                                                    , dataRow["GRADE_CTRL_ORG_DATE"]
                                                    , dataRow["POINT"]
                                                    , dataRow["POINT_DATE"]
                                                    , dataRow["GRADE_ID"]
                                                    , dataRow["GRADE_DATE"]
                                                    , dataRow["GRADE_TO_POINT"]
                                                    , dataRow["GRADE_TO_POINT_DATE"]
                                                    , dataRow["STATUS_ID"]
                                                    , dataRow["STATUS_DATE"]
                                                    , dataRow["DATE"]
                                                    , dataRow["USER"]);
                    }
                    else 
                    {
                        if(allowUpdate)
                            affectedRow += _data.Update(  conn
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
                                                        , dataRow["DIRECTION_TYPE"]
                                                        , dataRow["POINT_ORG"]
                                                        , dataRow["POINT_ORG_DATE"]
                                                        , dataRow["POINT_AVG"]
                                                        , dataRow["POINT_AVG_DATE"]
                                                        , dataRow["POINT_STD"]
                                                        , dataRow["POINT_STD_DATE"]
                                                        , dataRow["POINT_CTRL_ORG"]
                                                        , dataRow["POINT_CTRL_ORG_DATE"]
                                                        , dataRow["GRADE_CTRL_ORG_ID"]
                                                        , dataRow["GRADE_CTRL_ORG_DATE"]
                                                        , dataRow["POINT"]
                                                        , dataRow["POINT_DATE"]
                                                        , dataRow["GRADE_ID"]
                                                        , dataRow["GRADE_DATE"]
                                                        , dataRow["GRADE_TO_POINT"]
                                                        , dataRow["GRADE_TO_POINT_DATE"]
                                                        , dataRow["STATUS_ID"]
                                                        , dataRow["STATUS_DATE"]
                                                        , dataRow["DATE"]
                                                        , dataRow["USER"]);
                    }
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        // 맵핑된 평가자 <-> 피평가자의 Data를 EST_DATA 로 복사한다.(전체)
        public bool CopyTgtMapDataToEstData_ALL(DataTable dataTable, OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                if(dataTable.Rows.Count > 0) 
                {
                    affectedRow += _data.Delete(  conn
                                                , trx
                                                , dataTable.Rows[0]["COMP_ID"]
                                                , dataTable.Rows[0]["EST_ID"]
                                                , dataTable.Rows[0]["ESTTERM_REF_ID"]
                                                , dataTable.Rows[0]["ESTTERM_SUB_ID"]
                                                , 0
                                                , 0
                                                , 0
                                                , 0
                                                , 0
                                                , "N"
                                                , "N"
                                                , ownerType);
                }

                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _data.Insert(  conn
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
                                                , dataRow["TGT_POS_CLS_ID"]
                                                , dataRow["TGT_POS_CLS_NAME"]
                                                , dataRow["TGT_POS_DUT_ID"]
                                                , dataRow["TGT_POS_DUT_NAME"]
                                                , dataRow["TGT_POS_GRP_ID"]
                                                , dataRow["TGT_POS_GRP_NAME"]
                                                , dataRow["TGT_POS_RNK_ID"]
                                                , dataRow["TGT_POS_RNK_NAME"]
                                                , dataRow["TGT_POS_KND_ID"]
                                                , dataRow["TGT_POS_KND_NAME"]
                                                , dataRow["DIRECTION_TYPE"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , "N"
                                                , dataRow["DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        // 맵핑된 평가자 <-> 피평가자의 Data를 EST_DATA 로 복사한다.(부분)
        public bool CopyTgtMapDataToEstData_PART(DataTable dataTable, OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                Dac_EmpEstTargetMaps empEstTgtMap   = new Dac_EmpEstTargetMaps();
                DataTable dtClone                   = dataTable.Clone();

                // 존재하지 않는 EST_DATA 테이블의 정보를 보관한다.
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    if(_data.Count(conn
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
                                , "") == 0) 
                    {
                        dtClone.ImportRow(dataRow);
                    }
                }

                DataTable dtEstData = _data.Select(   conn
                                                    , trx
                                                    , DataTypeUtility.GetToInt32(dataTable.Rows[0]["COMP_ID"])
                                                    , DataTypeUtility.GetValue(dataTable.Rows[0]["EST_ID"])
                                                    , DataTypeUtility.GetToInt32(dataTable.Rows[0]["ESTTERM_REF_ID"])
                                                    , DataTypeUtility.GetToInt32(dataTable.Rows[0]["ESTTERM_SUB_ID"])
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , "N"
                                                    , "N"
                                                    , ownerType).Tables[0];

                // 존재하지 않는 맵핑 정보가 있을 경우 평가데이터를 삭제한다.
                foreach(DataRow dataRow in dtEstData.Rows) 
                {
                    if(empEstTgtMap.Count(conn
                                        , trx
                                        , dataRow["COMP_ID"]
                                        , dataRow["EST_ID"]
                                        , dataRow["ESTTERM_REF_ID"]
                                        , dataRow["ESTTERM_SUB_ID"]
                                        , dataRow["ESTTERM_STEP_ID"]
                                        , dataRow["EST_DEPT_ID"]
                                        , dataRow["EST_EMP_ID"]
                                        , dataRow["TGT_DEPT_ID"]
                                        , dataRow["TGT_EMP_ID"]) == 0) 
                    {
                        affectedRow += _data.Delete(  conn
                                                    , trx
                                                    , dataTable.Rows[0]["COMP_ID"]
                                                    , dataTable.Rows[0]["EST_ID"]
                                                    , dataTable.Rows[0]["ESTTERM_REF_ID"]
                                                    , dataTable.Rows[0]["ESTTERM_SUB_ID"]
                                                    , dataRow["ESTTERM_STEP_ID"]
                                                    , dataRow["EST_DEPT_ID"]
                                                    , dataRow["EST_EMP_ID"]
                                                    , dataRow["TGT_DEPT_ID"]
                                                    , dataRow["TGT_EMP_ID"]
                                                    , "N"
                                                    , "N"
                                                    , ownerType);
                    }
                }

                foreach(DataRow dataRow in dtClone.Rows) 
                {
                    affectedRow += _data.Insert(  conn
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
                                                , dataRow["TGT_POS_CLS_ID"]
                                                , dataRow["TGT_POS_CLS_NAME"]
                                                , dataRow["TGT_POS_DUT_ID"]
                                                , dataRow["TGT_POS_DUT_NAME"]
                                                , dataRow["TGT_POS_GRP_ID"]
                                                , dataRow["TGT_POS_GRP_NAME"]
                                                , dataRow["TGT_POS_RNK_ID"]
                                                , dataRow["TGT_POS_RNK_NAME"]
                                                , dataRow["TGT_POS_KND_ID"]
                                                , dataRow["TGT_POS_KND_NAME"]
                                                , dataRow["DIRECTION_TYPE"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , "N"
                                                , dataRow["DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        // 선택된 항목에 따른 맵핑된 평가자 <-> 피평가자의 Data를 EST_DATA 로 복사한다.
        public bool CopyTgtMapDataToEstDataBySelectedItem(DataTable dataTable, OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                if(dataTable.Rows.Count > 0) 
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        affectedRow += _data.Delete(conn
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
                                                    , "N"
                                                    , "N"
                                                    , ownerType);
                    }
                }

                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _data.Insert(  conn
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
                                                , dataRow["TGT_POS_CLS_ID"]
                                                , dataRow["TGT_POS_CLS_NAME"]
                                                , dataRow["TGT_POS_DUT_ID"]
                                                , dataRow["TGT_POS_DUT_NAME"]
                                                , dataRow["TGT_POS_GRP_ID"]
                                                , dataRow["TGT_POS_GRP_NAME"]
                                                , dataRow["TGT_POS_RNK_ID"]
                                                , dataRow["TGT_POS_RNK_NAME"]
                                                , dataRow["TGT_POS_KND_ID"]
                                                , dataRow["TGT_POS_KND_NAME"]
                                                , dataRow["DIRECTION_TYPE"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , "N"
                                                , dataRow["DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        public bool RemoveData(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , string year_yn
                            , string merge_yn
                            , OwnerType ownerType)
        {
            int affectedRow = 0;

            affectedRow = _data.Delete(null
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
                                    , year_yn
                                    , merge_yn
                                    , ownerType);

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
                            , int tgt_emp_id)
        {
            int affectedRow = 0;

            affectedRow = _data.Count(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , tgt_dept_id
                                    , tgt_emp_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        /// <summary>
        /// 평가주기에 따른 점수를 가중치로 계산하여 집계하는 메소드
        /// </summary>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="estterm_sub_id"></param>
        /// <returns></returns>
        public bool AggregateEstTermSubEstData(int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id_year_y
                                            , int estterm_step_id_merge_y
                                            , double total_weight_estterm_sub
                                            , string year_yn
                                            , string merge_yn
                                            , OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                // 존재하는 테이터를 우선 삭제한다.
                affectedRow += _data.Delete(  conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id_year_y
                                            , estterm_step_id_merge_y
                                            , 0
                                            , 0
                                            , 0
                                            , 0
                                            , "Y"
                                            , merge_yn
                                            , ownerType);
                
                DataTable dtEstData             = _data.SelectEstData(comp_id
                                                                    , est_id
                                                                    , estterm_ref_id
                                                                    , 0
                                                                    , estterm_step_id_merge_y
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , year_yn
                                                                    , merge_yn
                                                                    , ownerType
                                                                    , "").Tables[0];

                DataTable dtBlank               = GetDataTableSchema();
                DataRow dataRow                 = null;

                foreach(DataRow drEstData in dtEstData.Rows) 
                {
                    // 빈 데이터 테이블에 존재하는 피평가 대상자 있는 지 확인 후
                    // 있다면 존재하는 데이터에 가중치를 계산하여 수정하지만
                    // 존재하지 않다면 새로운 데이터 Row를 생성하여 삽입한다.
                    DataRow[] drArr= dtBlank.Select(string.Format(@"COMP_ID         = {0}
                                                                AND EST_ID          = '{1}'
                                                                AND ESTTERM_REF_ID  = {2}
                                                                AND ESTTERM_SUB_ID  = {3}
                                                                AND ESTTERM_STEP_ID = {4}
                                                                AND TGT_DEPT_ID     = {5}
                                                                AND TGT_EMP_ID      = {6}"
                                                                , drEstData["COMP_ID"]
                                                                , drEstData["EST_ID"]
                                                                , drEstData["ESTTERM_REF_ID"]
                                                                , estterm_sub_id_year_y
                                                                , estterm_step_id_merge_y
                                                                , drEstData["TGT_DEPT_ID"]
                                                                , drEstData["TGT_EMP_ID"]));

                    if(drArr.Length == 0) 
                    {
                        dataRow = dtBlank.NewRow();
                    }
                    else 
                    {
                        dataRow = drArr[0];
                    }

                    dataRow["COMP_ID"]              = drEstData["COMP_ID"];
                    dataRow["EST_ID"]               = drEstData["EST_ID"];
                    dataRow["ESTTERM_REF_ID"]       = drEstData["ESTTERM_REF_ID"];
                    dataRow["ESTTERM_SUB_ID"]       = estterm_sub_id_year_y;
                    dataRow["ESTTERM_STEP_ID"]      = estterm_step_id_merge_y;
                    dataRow["EST_DEPT_ID"]          = drEstData["EST_DEPT_ID"];
                    dataRow["EST_EMP_ID"]           = drEstData["EST_EMP_ID"];
                    dataRow["TGT_DEPT_ID"]          = drEstData["TGT_DEPT_ID"];
                    dataRow["TGT_EMP_ID"]           = drEstData["TGT_EMP_ID"];
                    dataRow["TGT_POS_CLS_ID"]       = drEstData["TGT_POS_CLS_ID"];
                    dataRow["TGT_POS_CLS_NAME"]     = drEstData["TGT_POS_CLS_NAME"];
                    dataRow["TGT_POS_DUT_ID"]       = drEstData["TGT_POS_DUT_ID"];
                    dataRow["TGT_POS_DUT_NAME"]     = drEstData["TGT_POS_DUT_NAME"];
                    dataRow["TGT_POS_GRP_ID"]       = drEstData["TGT_POS_GRP_ID"];
                    dataRow["TGT_POS_GRP_NAME"]     = drEstData["TGT_POS_GRP_NAME"];
                    dataRow["TGT_POS_RNK_ID"]       = drEstData["TGT_POS_RNK_ID"];
                    dataRow["TGT_POS_RNK_NAME"]     = drEstData["TGT_POS_RNK_NAME"];
                    dataRow["TGT_POS_KND_ID"]       = drEstData["TGT_POS_KND_ID"];
                    dataRow["TGT_POS_KND_NAME"]     = drEstData["TGT_POS_KND_NAME"];
                    dataRow["DIRECTION_TYPE"]       = "SM";
                    dataRow["POINT_ORG"]            = DataTypeUtility.GetToDouble(dataRow["POINT_ORG"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_ORG"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_SUB"]) / total_weight_estterm_sub);
                    dataRow["POINT_ORG_DATE"]       = DBNull.Value;
                    dataRow["POINT_AVG"]            = DataTypeUtility.GetToDouble(dataRow["POINT_AVG"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_AVG"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_SUB"]) / total_weight_estterm_sub);
                    dataRow["POINT_AVG_DATE"]       = DBNull.Value;
                    dataRow["POINT_STD"]            = DataTypeUtility.GetToDouble(dataRow["POINT_STD"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_STD"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_SUB"]) / total_weight_estterm_sub);
                    dataRow["POINT_STD_DATE"]       = DBNull.Value;
                    dataRow["POINT"]                = DataTypeUtility.GetToDouble(dataRow["POINT"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_SUB"]) / total_weight_estterm_sub);
                    dataRow["POINT_DATE"]           = DateTime.Now;
                    dataRow["GRADE_ID"]             = DBNull.Value;
                    dataRow["GRADE_DATE"]           = DBNull.Value;
                    dataRow["GRADE_TO_POINT"]       = DBNull.Value;
                    dataRow["GRADE_TO_POINT_DATE"]  = DBNull.Value;
                    dataRow["STATUS_ID"]            = "E";
                    dataRow["STATUS_DATE"]          = drEstData["UPDATE_DATE"];
                    dataRow["DATE"]                 = drEstData["UPDATE_DATE"];
                    dataRow["USER"]                 = drEstData["UPDATE_USER"];

                    if(drArr.Length == 0) 
                    {
                        dtBlank.Rows.Add(dataRow);
                    }
                }

                foreach(DataRow drBlank in dtBlank.Rows) 
                {
                    affectedRow += _data.Insert(  conn
                                                , trx
                                                , drBlank["COMP_ID"]
                                                , drBlank["EST_ID"]
                                                , drBlank["ESTTERM_REF_ID"]
                                                , drBlank["ESTTERM_SUB_ID"]
                                                , drBlank["ESTTERM_STEP_ID"]
                                                , drBlank["EST_DEPT_ID"]
                                                , drBlank["EST_EMP_ID"]
                                                , drBlank["TGT_DEPT_ID"]
                                                , drBlank["TGT_EMP_ID"]
                                                , drBlank["TGT_POS_CLS_ID"]
                                                , drBlank["TGT_POS_CLS_NAME"]
                                                , drBlank["TGT_POS_DUT_ID"]
                                                , drBlank["TGT_POS_DUT_NAME"]
                                                , drBlank["TGT_POS_GRP_ID"]
                                                , drBlank["TGT_POS_GRP_NAME"]
                                                , drBlank["TGT_POS_RNK_ID"]
                                                , drBlank["TGT_POS_RNK_NAME"]
                                                , drBlank["TGT_POS_KND_ID"]
                                                , drBlank["TGT_POS_KND_NAME"]
                                                , drBlank["DIRECTION_TYPE"]
                                                , drBlank["POINT_ORG"]
                                                , drBlank["POINT_ORG_DATE"]
                                                , drBlank["POINT_AVG"]
                                                , drBlank["POINT_AVG_DATE"]
                                                , drBlank["POINT_STD"]
                                                , drBlank["POINT_STD_DATE"]
                                                , drBlank["POINT_CTRL_ORG"]
                                                , drBlank["POINT_CTRL_ORG_DATE"]
                                                , drBlank["GRADE_CTRL_ORG_ID"]
                                                , drBlank["GRADE_CTRL_ORG_DATE"]
                                                , drBlank["POINT"]
                                                , drBlank["POINT_DATE"]
                                                , drBlank["GRADE_ID"]
                                                , drBlank["GRADE_DATE"]
                                                , drBlank["GRADE_TO_POINT"]
                                                , drBlank["GRADE_TO_POINT_DATE"]
                                                , drBlank["STATUS_ID"]
                                                , drBlank["STATUS_DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        /// <summary>
        /// 평가차수에 따른 점수를 가중치로 계산하여 집계하는 메소드
        /// </summary>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="estterm_sub_id"></param>
        /// <returns></returns>
        public bool AggregateEstTermStepEstData(  int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id_merge_y
                                                , double total_weight_estterm_step
                                                , string year_yn
                                                , string merge_yn
                                                , OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                // 존재하는 테이터를 우선 삭제한다.
                affectedRow += _data.Delete(  conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id_merge_y
                                            , 0
                                            , 0
                                            , 0
                                            , 0
                                            , year_yn
                                            , "Y"
                                            , ownerType);

                DataTable dtBlank               = GetDataTableSchema();
                DataRow dataRow                 = null;
                
                DataTable dtEstData             = _data.SelectEstData(comp_id
                                                                    , est_id
                                                                    , estterm_ref_id
                                                                    , estterm_sub_id
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , year_yn
                                                                    , merge_yn
                                                                    , ownerType
                                                                    , "").Tables[0];


                //----------------------- 상향평가 가중치 적용 체크

                Biz_EstInfos estInfo        = new Biz_EstInfos(comp_id, est_id);
                DataTable dtTgtEmp          = null;
                DataTable dtTgtAllSum       = null;
                double fixed_weight         = 0;

                if(DataTypeUtility.GetYNToBoolean(estInfo.Fixed_Weight_Use_YN)) 
                {
                    fixed_weight            = DataTypeUtility.GetToDouble(estInfo.Fixed_Weight);
                    DataTable dtFilterData  = DataTypeUtility.FilterSortDataTable(dtEstData, "FIXED_WEIGHT_YN = 'Y'");

                    dtTgtEmp                = DataTypeUtility.GetGroupByDataTable(dtFilterData
                                                                                , "WEIGHT_ESTTERM_STEP"
                                                                                , new string[] {"COMP_ID", "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "TGT_DEPT_ID", "TGT_EMP_ID"}
                                                                                , "WEIGHT_ESTTERM_STEP");

                    foreach(DataRow drTgtEmp in dtTgtEmp.Rows) 
                    {
                        DataRow[] drArrEstData   = dtEstData.Select(string.Format(@"COMP_ID         = {0}
                                                                                AND EST_ID          = '{1}'
                                                                                AND ESTTERM_REF_ID  = {2}
                                                                                AND ESTTERM_SUB_ID  = {3}
                                                                                AND TGT_DEPT_ID     = {4}
                                                                                AND TGT_EMP_ID      = {5}"
                                                                                , drTgtEmp["COMP_ID"]
                                                                                , drTgtEmp["EST_ID"]
                                                                                , drTgtEmp["ESTTERM_REF_ID"]
                                                                                , drTgtEmp["ESTTERM_SUB_ID"]
                                                                                , drTgtEmp["TGT_DEPT_ID"]
                                                                                , drTgtEmp["TGT_EMP_ID"]));

                        // 상향평가 가중치를 재계산 한다. 
                        foreach(DataRow drEstData in drArrEstData) 
                        {
                            if(DataTypeUtility.GetValue(drEstData["FIXED_WEIGHT_YN"]).Equals("Y"))
                                drEstData["WEIGHT_ESTTERM_STEP"] = DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / DataTypeUtility.GetToDouble(drTgtEmp["SUM_WEIGHT_ESTTERM_STEP"]) * fixed_weight;
                        }
                    }
                }

                dtTgtAllSum             = DataTypeUtility.GetGroupByDataTable(dtEstData
                                                                                , "WEIGHT_ESTTERM_STEP"
                                                                                , new string[] {"COMP_ID", "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "TGT_DEPT_ID", "TGT_EMP_ID"}
                                                                                , "WEIGHT_ESTTERM_STEP");
                
                //--------------------------------------------

                foreach(DataRow drEstData in dtEstData.Rows) 
                {
                    // 빈 데이터 테이블에 존재하는 피평가 대상자 있는 지 확인 후
                    // 있다면 존재하는 데이터에 가중치를 계산하여 수정하지만
                    // 존재하지 않다면 새로운 데이터 Row를 생성하여 삽입한다.
                    DataRow[] drArr= dtBlank.Select(string.Format(@"COMP_ID         = {0}
                                                                AND EST_ID          = '{1}'
                                                                AND ESTTERM_REF_ID  = {2}
                                                                AND ESTTERM_SUB_ID  = {3}
                                                                AND ESTTERM_STEP_ID = {4}
                                                                AND TGT_DEPT_ID     = {5}
                                                                AND TGT_EMP_ID      = {6}"
                                                                , drEstData["COMP_ID"]
                                                                , drEstData["EST_ID"]
                                                                , drEstData["ESTTERM_REF_ID"]
                                                                , drEstData["ESTTERM_SUB_ID"]
                                                                , estterm_step_id_merge_y
                                                                , drEstData["TGT_DEPT_ID"]
                                                                , drEstData["TGT_EMP_ID"]));

                    DataRow[] drArrSum = dtTgtAllSum.Select(string.Format(@"COMP_ID         = {0}
                                                                    AND EST_ID          = '{1}'
                                                                    AND ESTTERM_REF_ID  = {2}
                                                                    AND ESTTERM_SUB_ID  = {3}
                                                                    AND TGT_DEPT_ID     = {4}
                                                                    AND TGT_EMP_ID      = {5}"
                                                                    , drEstData["COMP_ID"]
                                                                    , drEstData["EST_ID"]
                                                                    , drEstData["ESTTERM_REF_ID"]
                                                                    , drEstData["ESTTERM_SUB_ID"]
                                                                    , drEstData["TGT_DEPT_ID"]
                                                                    , drEstData["TGT_EMP_ID"]));

                    double totalWeight = DataTypeUtility.GetToDouble(drArrSum[0]["SUM_WEIGHT_ESTTERM_STEP"]);

                    if(totalWeight <= 0)
                        return false;

                    if(drArr.Length == 0) 
                    {
                        dataRow = dtBlank.NewRow();
                    }
                    else 
                    {
                        dataRow = drArr[0];
                    }

                    dataRow["COMP_ID"]              = drEstData["COMP_ID"];
                    dataRow["EST_ID"]               = drEstData["EST_ID"];
                    dataRow["ESTTERM_REF_ID"]       = drEstData["ESTTERM_REF_ID"];
                    dataRow["ESTTERM_SUB_ID"]       = drEstData["ESTTERM_SUB_ID"];
                    dataRow["ESTTERM_STEP_ID"]      = estterm_step_id_merge_y;
                    dataRow["EST_DEPT_ID"]          = drEstData["EST_DEPT_ID"];
                    dataRow["EST_EMP_ID"]           = drEstData["EST_EMP_ID"];
                    dataRow["TGT_DEPT_ID"]          = drEstData["TGT_DEPT_ID"];
                    dataRow["TGT_EMP_ID"]           = drEstData["TGT_EMP_ID"];
                    dataRow["TGT_POS_CLS_ID"]       = drEstData["TGT_POS_CLS_ID"];
                    dataRow["TGT_POS_CLS_NAME"]     = drEstData["TGT_POS_CLS_NAME"];
                    dataRow["TGT_POS_DUT_ID"]       = drEstData["TGT_POS_DUT_ID"];
                    dataRow["TGT_POS_DUT_NAME"]     = drEstData["TGT_POS_DUT_NAME"];
                    dataRow["TGT_POS_GRP_ID"]       = drEstData["TGT_POS_GRP_ID"];
                    dataRow["TGT_POS_GRP_NAME"]     = drEstData["TGT_POS_GRP_NAME"];
                    dataRow["TGT_POS_RNK_ID"]       = drEstData["TGT_POS_RNK_ID"];
                    dataRow["TGT_POS_RNK_NAME"]     = drEstData["TGT_POS_RNK_NAME"];
                    dataRow["TGT_POS_KND_ID"]       = drEstData["TGT_POS_KND_ID"];
                    dataRow["TGT_POS_KND_NAME"]     = drEstData["TGT_POS_KND_NAME"];
                    dataRow["DIRECTION_TYPE"]       = "SM";
                    dataRow["POINT_ORG"]            = DataTypeUtility.GetToDouble(dataRow["POINT_ORG"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_ORG"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / totalWeight);
                    dataRow["POINT_ORG_DATE"]       = DBNull.Value;
                    dataRow["POINT_AVG"]            = DataTypeUtility.GetToDouble(dataRow["POINT_AVG"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_AVG"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / totalWeight);
                    dataRow["POINT_AVG_DATE"]       = DBNull.Value;
                    dataRow["POINT_STD"]            = DataTypeUtility.GetToDouble(dataRow["POINT_STD"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_STD"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / totalWeight);
                    dataRow["POINT_STD_DATE"]       = DBNull.Value;
                    dataRow["POINT"]                = DataTypeUtility.GetToDouble(dataRow["POINT"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / totalWeight);
                    dataRow["POINT_DATE"]           = DateTime.Now;
                    dataRow["GRADE_ID"]             = DBNull.Value;
                    dataRow["GRADE_DATE"]           = DBNull.Value;
                    dataRow["GRADE_TO_POINT"]       = DBNull.Value;
                    dataRow["GRADE_TO_POINT_DATE"]  = DBNull.Value;
                    dataRow["STATUS_ID"]            = "E";
                    dataRow["STATUS_DATE"]          = drEstData["UPDATE_DATE"];
                    dataRow["DATE"]                 = drEstData["UPDATE_DATE"];
                    dataRow["USER"]                 = drEstData["UPDATE_USER"];

                    if(drArr.Length == 0) 
                    {
                        dtBlank.Rows.Add(dataRow);
                    }
                }

                foreach(DataRow drBlank in dtBlank.Rows) 
                {
                    affectedRow += _data.Insert(  conn
                                                , trx
                                                , drBlank["COMP_ID"]
                                                , drBlank["EST_ID"]
                                                , drBlank["ESTTERM_REF_ID"]
                                                , drBlank["ESTTERM_SUB_ID"]
                                                , drBlank["ESTTERM_STEP_ID"]
                                                , drBlank["EST_DEPT_ID"]
                                                , drBlank["EST_EMP_ID"]
                                                , drBlank["TGT_DEPT_ID"]
                                                , drBlank["TGT_EMP_ID"]
                                                , drBlank["TGT_POS_CLS_ID"]
                                                , drBlank["TGT_POS_CLS_NAME"]
                                                , drBlank["TGT_POS_DUT_ID"]
                                                , drBlank["TGT_POS_DUT_NAME"]
                                                , drBlank["TGT_POS_GRP_ID"]
                                                , drBlank["TGT_POS_GRP_NAME"]
                                                , drBlank["TGT_POS_RNK_ID"]
                                                , drBlank["TGT_POS_RNK_NAME"]
                                                , drBlank["TGT_POS_KND_ID"]
                                                , drBlank["TGT_POS_KND_NAME"]
                                                , drBlank["DIRECTION_TYPE"]
                                                , drBlank["POINT_ORG"]
                                                , drBlank["POINT_ORG_DATE"]
                                                , drBlank["POINT_AVG"]
                                                , drBlank["POINT_AVG_DATE"]
                                                , drBlank["POINT_STD"]
                                                , drBlank["POINT_STD_DATE"]
                                                , drBlank["POINT_CTRL_ORG"]
                                                , drBlank["POINT_CTRL_ORG_DATE"]
                                                , drBlank["GRADE_CTRL_ORG_ID"]
                                                , drBlank["GRADE_CTRL_ORG_DATE"]
                                                , drBlank["POINT"]
                                                , drBlank["POINT_DATE"]
                                                , drBlank["GRADE_ID"]
                                                , drBlank["GRADE_DATE"]
                                                , drBlank["GRADE_TO_POINT"]
                                                , drBlank["GRADE_TO_POINT_DATE"]
                                                , drBlank["STATUS_ID"]
                                                , drBlank["STATUS_DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        public bool AggregateChildEstData(int comp_id
                                        , string parent_est_id
                                        , int parent_estterm_ref_id
                                        , int parent_estterm_sub_id
                                        , int parent_estterm_step_id
                                        , string weightType)
        {
            int affectedRow = 0;

            Biz_EstInfos estInfo                = new Biz_EstInfos();
            Biz_DeptEstDetails deptEstDetail    = null;
            Biz_DeptPosDetails deptPosDetail    = null;
            DataTable dtDeptDetail_temp         = null;
            DataTable dtDeptDetail              = null;
            DataTable dtEstData_temp            = null;
            DataTable dtEstData                 = null;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                // 존재하는 테이터를 우선 삭제한다.
                affectedRow += _data.Delete(  conn
                                            , trx
                                            , comp_id
                                            , parent_est_id
                                            , parent_estterm_ref_id
                                            , parent_estterm_sub_id
                                            , parent_estterm_step_id
                                            , 0
                                            , 0
                                            , 0
                                            , 0
                                            , ""
                                            , ""
                                            , OwnerType.All);


                //2011.12.28 박효동 : 하위평가를 가져오니 문제가 있어서 수정
                // - MBO의 하위평가를 가져오도록 평가컬럼설정이 되있는데 현재는 현재평가의 하위차수를 가져오니 안나오더라
                // - 해서 평가컬럼설정에 등록되어있는 POINT_평가아이디에 해당하는 평가아이디를 가져오도록 수정 휴~~
                // 부모 평가에 속해 있는 종속 평가를 가지고 온다.
                //DataTable dtChildEst = estInfo.GetEstInfoByUpEstID(comp_id, parent_est_id).Tables[0];
                DataTable dtChildEst = estInfo.GetEstInfoByUpEstID(comp_id, parent_est_id).Tables[0];

                dtChildEst.Rows.Clear();
                Biz_ColumnInfos colInfo = new Biz_ColumnInfos();
                DataTable dtEstID = colInfo.GetColumnInfo(comp_id, parent_est_id).Tables[0];
                foreach (DataRow dr in dtEstID.Rows)
                {
                    string colnames = dr[6].ToString();
                    if (colnames.Length > 5)
                    {
                        if (colnames.Substring(0, 6) == "POINT_" && colnames.Length == 8)
                        {
                            DataRow insertDR = dtChildEst.NewRow();
                            insertDR["EST_ID"] = colnames.Remove(0, 6);
                            dtChildEst.Rows.Add(insertDR);
                            insertDR = null;
                        }
                    }
                }                

                foreach(DataRow drChildEst in dtChildEst.Rows) 
                {
                    string est_id               = drChildEst["EST_ID"].ToString();
                    Biz_EstInfos estChildInfo   = new Biz_EstInfos(comp_id, est_id);

                    weightType = estChildInfo.Weight_Type;

                    // 가중치 적용 방식에 따라
                    if(weightType.Equals("DPT")) 
                    {
                        deptEstDetail           = new Biz_DeptEstDetails();
                        dtDeptDetail_temp       = deptEstDetail.GetDeptEstDetail(comp_id, parent_estterm_ref_id, 0, est_id).Tables[0];
                    }
                    else if(weightType.Equals("POS")) 
                    {
                        deptPosDetail           = new Biz_DeptPosDetails();
                        dtDeptDetail_temp       = deptPosDetail.GetDeptPosDetail(comp_id, parent_estterm_ref_id, 0, est_id).Tables[0];
                    }

                    // 평가별 가중치 Data Merge
                    if(dtDeptDetail == null)
                        dtDeptDetail = dtDeptDetail_temp;
                    else 
                        dtDeptDetail.Merge(dtDeptDetail_temp);

                    // 평가 데이터 Data Merge
                    dtEstData_temp             = _data.SelectEstData( conn
                                                                    , trx
                                                                    , comp_id
                                                                    , est_id
                                                                    , parent_estterm_ref_id
                                                                    , parent_estterm_sub_id
                                                                    , parent_estterm_step_id
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , ""
                                                                    , ""
                                                                    , OwnerType.All
                                                                    , "").Tables[0];

                    dtEstData_temp.Columns.Add("WEIGHT_EST", typeof(double));
                    dtEstData_temp.AcceptChanges();

                    if(weightType.Equals("DPT")) 
                    {
                        foreach(DataRow drDeptDetail in dtDeptDetail_temp.Rows)
                        {
                            DataRow[] drArrEstData = dtEstData_temp.Select(string.Format("TGT_DEPT_ID = {0}", drDeptDetail["DEPT_REF_ID"]));

                            foreach(DataRow drEstData in drArrEstData) 
                            {
                                drEstData["WEIGHT_EST"] = drDeptDetail["WEIGHT"];
                            }
                        }
                    }
                    else if(weightType.Equals("POS")) 
                    {
                        DataTable dtPosDept = DataTypeUtility.GetGroupByDataTable(dtDeptDetail_temp 
                                                                                , new string[] {"DEPT_REF_ID"});

                        //1. 부서_직급,직책 
                        //2. 부서로 그룹
                        //3. 부서그룹으로 루프
                        //4. 해당부서의 est_data로 선택
                        //5. 부서_직급,직책에서 해당당 직급,직책으로 선택
                        //6. 마지막으로 직급,직책의 값이 - 일 경우 WEIGHT_EST의 값이 null 인 컬럼을 모두 - 의 가중치로 채움

                        // 부서그룹에서
                        foreach(DataRow drPosDept in dtPosDept.Rows) 
                        {
                            //해당 부서 중 직책, 직급을 선별
                            DataRow[] drArrEstPosDetail = dtDeptDetail_temp.Select(string.Format("DEPT_REF_ID = {0}", drPosDept["DEPT_REF_ID"]), "SEQ");

                            //선별된 직책, 직급의 순서에 따라
                            foreach(DataRow drChildPosDetail in drArrEstPosDetail) 
                            {
                                // 기본값이면
                                if(drChildPosDetail["POS_VALUE"].ToString().Equals("-"))
                                {
                                    DataRow[] drArrEstData = dtEstData_temp.Select(string.Format("TGT_DEPT_ID = {0} AND WEIGHT_EST IS NULL", drPosDept["DEPT_REF_ID"]));

                                    for(int i = 0; i < drArrEstData.Length; i++) 
                                    {
                                        drArrEstData[i]["WEIGHT_EST"] = drChildPosDetail["WEIGHT"];
                                    }
                                }
                                else // 선별된 직급
                                {
                                    DataRow[] drArrEstData = dtEstData_temp.Select(string.Format("TGT_DEPT_ID = {0} AND TGT_POS_{1}_ID = '{2}' AND WEIGHT_EST IS NULL"
                                                                                                , drPosDept["DEPT_REF_ID"]
                                                                                                , drChildPosDetail["POS_ID"]
                                                                                                , drChildPosDetail["POS_VALUE"]));

                                    for(int i = 0; i < drArrEstData.Length; i++) 
                                    {
                                        drArrEstData[i]["WEIGHT_EST"] = drChildPosDetail["WEIGHT"];
                                    }
                                }
                            }
                        }
                    }
                        
                    if(dtEstData == null)
                        dtEstData = dtEstData_temp;
                    else 
                        dtEstData.Merge(dtEstData_temp);
                }

                // 자식이 아닌 자신평가에서 가중치 타입를 처리 하지 않기 위해서 자식 외 Scope 에서 우선 주석처리 함
                // 가중치 방법에 따라 총합계 계산 처리
                //if(weightType.Equals("DPT")) 
                //{
                //    dtDeptDetail = DataTypeUtility.GetGroupByDataTable(dtDeptDetail
                //                                                    , "WEIGHT"
                //                                                    , new string[] {"DEPT_REF_ID"}
                //                                                    , "WEIGHT");
                //}
                //else if(weightType.Equals("POS")) 
                //{
                
                //}

                DataTable dtBlank               = GetDataTableSchema();
                DataRow dataRow                 = null;

                foreach(DataRow drEstData in dtEstData.Rows) 
                {
                    // 빈 데이터 테이블에 존재하는 피평가 대상자 있는 지 확인 후
                    // 있다면 존재하는 데이터에 가중치를 계산하여 수정하지만
                    // 존재하지 않다면 새로운 데이터 Row를 생성하여 삽입한다.
                    DataRow[] drArr= dtBlank.Select(string.Format(@"COMP_ID         = {0}
                                                                AND EST_ID          = '{1}'
                                                                AND ESTTERM_REF_ID  = {2}
                                                                AND ESTTERM_SUB_ID  = {3}
                                                                AND ESTTERM_STEP_ID = {4}
                                                                AND TGT_DEPT_ID     = {5}
                                                                AND TGT_EMP_ID      = {6}"
                                                                , comp_id
                                                                , parent_est_id
                                                                , parent_estterm_ref_id
                                                                , parent_estterm_sub_id
                                                                , parent_estterm_step_id
                                                                , drEstData["TGT_DEPT_ID"]
                                                                , drEstData["TGT_EMP_ID"]));

                    if(drArr.Length == 0) 
                    {
                        dataRow = dtBlank.NewRow();
                    }
                    else 
                    {
                        dataRow = drArr[0];
                    }

                    double weight_total_weight  = 100.00;

                    // 이것도 위와 같은 경우
                    //if(weightType.Equals("DPT")) 
                    //{
                    //    DataRow[] drArrWeight       = dtDeptDetail.Select(string.Format("DEPT_REF_ID = {0}", drEstData["TGT_DEPT_ID"]));
                        
                    //    if(drArrWeight.Length > 0) 
                    //    {
                    //        weight_total_weight = DataTypeUtility.GetToDouble(drArrWeight[0]["SUM_WEIGHT"]);
                    //    }
                    //}
                    //else if(weightType.Equals("POS")) 
                    //{
                    //    weight_total_weight = 100;
                    //}

                    dataRow["COMP_ID"]              = drEstData["COMP_ID"];
                    dataRow["EST_ID"]               = parent_est_id;
                    dataRow["ESTTERM_REF_ID"]       = parent_estterm_ref_id;
                    dataRow["ESTTERM_SUB_ID"]       = parent_estterm_sub_id;
                    dataRow["ESTTERM_STEP_ID"]      = parent_estterm_step_id;
                    dataRow["EST_DEPT_ID"]          = drEstData["EST_DEPT_ID"];
                    dataRow["EST_EMP_ID"]           = drEstData["EST_EMP_ID"];
                    dataRow["TGT_DEPT_ID"]          = drEstData["TGT_DEPT_ID"];
                    dataRow["TGT_EMP_ID"]           = drEstData["TGT_EMP_ID"];
                    dataRow["TGT_POS_CLS_ID"]       = drEstData["TGT_POS_CLS_ID"];
                    dataRow["TGT_POS_CLS_NAME"]     = drEstData["TGT_POS_CLS_NAME"];
                    dataRow["TGT_POS_DUT_ID"]       = drEstData["TGT_POS_DUT_ID"];
                    dataRow["TGT_POS_DUT_NAME"]     = drEstData["TGT_POS_DUT_NAME"];
                    dataRow["TGT_POS_GRP_ID"]       = drEstData["TGT_POS_GRP_ID"];
                    dataRow["TGT_POS_GRP_NAME"]     = drEstData["TGT_POS_GRP_NAME"];
                    dataRow["TGT_POS_RNK_ID"]       = drEstData["TGT_POS_RNK_ID"];
                    dataRow["TGT_POS_RNK_NAME"]     = drEstData["TGT_POS_RNK_NAME"];
                    dataRow["TGT_POS_KND_ID"]       = drEstData["TGT_POS_KND_ID"];
                    dataRow["TGT_POS_KND_NAME"]     = drEstData["TGT_POS_KND_NAME"];
                    dataRow["DIRECTION_TYPE"]       = "SM";
                    dataRow["POINT_ORG"]            = DataTypeUtility.GetToDouble(dataRow["POINT_ORG"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_ORG"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_EST"]) / weight_total_weight);
                    dataRow["POINT_ORG_DATE"]       = DBNull.Value;
                    dataRow["POINT_AVG"]            = DataTypeUtility.GetToDouble(dataRow["POINT_AVG"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_AVG"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_EST"]) / weight_total_weight);
                    dataRow["POINT_AVG_DATE"]       = DBNull.Value;
                    dataRow["POINT_STD"]            = DataTypeUtility.GetToDouble(dataRow["POINT_STD"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_STD"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_EST"]) / weight_total_weight);
                    dataRow["POINT_STD_DATE"]       = DBNull.Value;
                    dataRow["POINT"]                = DataTypeUtility.GetToDouble(dataRow["POINT"]) 
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT"]) 
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_EST"]) / weight_total_weight);
                    dataRow["POINT_DATE"]           = DateTime.Now;
                    dataRow["GRADE_ID"]             = DBNull.Value;
                    dataRow["GRADE_DATE"]           = DBNull.Value;
                    dataRow["GRADE_TO_POINT"]       = DBNull.Value;
                    dataRow["GRADE_TO_POINT_DATE"]  = DBNull.Value;
                    dataRow["STATUS_ID"]            = DBNull.Value;
                    dataRow["STATUS_DATE"]          = DBNull.Value;
                    dataRow["DATE"]                 = drEstData["UPDATE_DATE"];
                    dataRow["USER"]                 = drEstData["UPDATE_USER"];

                    if(drArr.Length == 0) 
                    {
                        dtBlank.Rows.Add(dataRow);
                    }
                }

                foreach(DataRow drBlank in dtBlank.Rows) 
                {
                    affectedRow += _data.Insert(  conn
                                                , trx
                                                , drBlank["COMP_ID"]
                                                , drBlank["EST_ID"]
                                                , drBlank["ESTTERM_REF_ID"]
                                                , drBlank["ESTTERM_SUB_ID"]
                                                , drBlank["ESTTERM_STEP_ID"]
                                                , drBlank["EST_DEPT_ID"]
                                                , drBlank["EST_EMP_ID"]
                                                , drBlank["TGT_DEPT_ID"]
                                                , drBlank["TGT_EMP_ID"]
                                                , drBlank["TGT_POS_CLS_ID"]
                                                , drBlank["TGT_POS_CLS_NAME"]
                                                , drBlank["TGT_POS_DUT_ID"]
                                                , drBlank["TGT_POS_DUT_NAME"]
                                                , drBlank["TGT_POS_GRP_ID"]
                                                , drBlank["TGT_POS_GRP_NAME"]
                                                , drBlank["TGT_POS_RNK_ID"]
                                                , drBlank["TGT_POS_RNK_NAME"]
                                                , drBlank["TGT_POS_KND_ID"]
                                                , drBlank["TGT_POS_KND_NAME"]
                                                , drBlank["DIRECTION_TYPE"]
                                                , drBlank["POINT_ORG"]
                                                , drBlank["POINT_ORG_DATE"]
                                                , drBlank["POINT_AVG"]
                                                , drBlank["POINT_AVG_DATE"]
                                                , drBlank["POINT_STD"]
                                                , drBlank["POINT_STD_DATE"]
                                                , drBlank["POINT_CTRL_ORG"]
                                                , drBlank["POINT_CTRL_ORG_DATE"]
                                                , drBlank["GRADE_CTRL_ORG_ID"]
                                                , drBlank["GRADE_CTRL_ORG_DATE"]
                                                , drBlank["POINT"]
                                                , drBlank["POINT_DATE"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , "E"
                                                , DateTime.Now
                                                , DateTime.Now
                                                , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        // 점수 조정
        public bool CtrlPoint(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , int ctrl_emp_id
                            , int ctrl_seq
                            , float before_point
                            , float ctrl_point
                            , DateTime ctrl_date
                            , DateTime update_date
                            , int update_user)
        {
            int affectedRow = 0;

            Dac_CtrlPointDatas ctrlPointData = new Dac_CtrlPointDatas();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow += ctrlPointData.UpdateInitCtrlYN(conn
                                                            , trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , ctrl_emp_id
                                                            , tgt_dept_id
                                                            , tgt_emp_id);

                affectedRow += ctrlPointData.UpdateConfirmCtrl(conn
                                                            , trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , ctrl_emp_id
                                                            , tgt_dept_id
                                                            , tgt_emp_id
                                                            , ctrl_seq
                                                            , before_point
                                                            , update_date
                                                            , update_user);

                affectedRow += _data.Update(  conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , before_point
                                            , ctrl_date
                                            , DBNull.Value
                                            , DBNull.Value
                                            , ctrl_point
                                            , ctrl_date
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value);

				trx.Commit();
			}
			catch ( Exception ex )
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

        // 등급 조정
        public bool CtrlGrade(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , int ctrl_emp_id
                            , int ctrl_seq
                            , string before_grade_id
                            , string ctrl_grade_id
                            , DateTime ctrl_date
                            , DateTime update_date
                            , int update_user)
        {
            int affectedRow = 0;

            Dac_CtrlGradeDatas ctrlGradeData = new Dac_CtrlGradeDatas();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow += ctrlGradeData.UpdateInitCtrlYN(    conn
                                                                , trx
                                                                , comp_id
                                                                , est_id
                                                                , estterm_ref_id
                                                                , estterm_sub_id
                                                                , estterm_step_id
                                                                , ctrl_emp_id
                                                                , tgt_dept_id
                                                                , tgt_emp_id);

                affectedRow += ctrlGradeData.UpdateConfirmCtrl(   conn
                                                                , trx
                                                                , comp_id
                                                                , est_id
                                                                , estterm_ref_id
                                                                , estterm_sub_id
                                                                , estterm_step_id
                                                                , ctrl_emp_id
                                                                , tgt_dept_id
                                                                , tgt_emp_id
                                                                , ctrl_seq
                                                                , before_grade_id
                                                                , update_date
                                                                , update_user);

                //affectedRow += _data.Update(  conn
                //                            , trx
                //                            , comp_id
                //                            , est_id
                //                            , estterm_ref_id
                //                            , estterm_sub_id
                //                            , estterm_step_id
                //                            , est_dept_id
                //                            , est_emp_id
                //                            , tgt_dept_id
                //                            , tgt_emp_id
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , before_grade_id
                //                            , ctrl_date
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , ctrl_grade_id
                //                            , ctrl_date
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value
                //                            , DBNull.Value);

                affectedRow += _data.UpdateCtrl(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , before_grade_id
                                            , ctrl_date
                                            , ctrl_grade_id
                                            , ctrl_date);

				trx.Commit();
			}
			catch ( Exception ex )
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

        /// <summary>
        /// 평가의 상태를 바꿈
        /// </summary>
        /// <param name="dtEstQ"></param>
        /// <returns></returns>
        public bool SaveStatus(DataTable dtEstQ)
        {
            int affectedRow = 0;

            Dac_CtrlGradeDatas ctrlGradeData = new Dac_CtrlGradeDatas();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach(DataRow dataRow in dtEstQ.Rows) 
                {
                   
                    //affectedRow += _data.Update(  conn
                    //                            , trx
                    //                            , dataRow["COMP_ID"]
                    //                            , dataRow["EST_ID"]
                    //                            , dataRow["ESTTERM_REF_ID"]
                    //                            , dataRow["ESTTERM_SUB_ID"]
                    //                            , dataRow["ESTTERM_STEP_ID"]
                    //                            , dataRow["EST_DEPT_ID"]
                    //                            , dataRow["EST_EMP_ID"]
                    //                            , dataRow["TGT_DEPT_ID"]
                    //                            , dataRow["TGT_EMP_ID"]
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , DBNull.Value
                    //                            , dataRow["STATUS_ID"]
                    //                            , dataRow["DATE"]
                    //                            , dataRow["USER"]
                    //                            , dataRow["DATE"]);

                    // 상태만 변경 하는 
                    affectedRow += _data.Update(conn
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
                                                , dataRow["STATUS_ID"]
                                                , dataRow["DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]
                                                );


                    // 확정취소인 "C" 일때만 코멘트 삭제
                    if (DataTypeUtility.GetValue(dataRow["STATUS_ID"]).Equals("C"))
                    {
                        Dac_QuestionComments questionComment = new Dac_QuestionComments();
                        int delCnt = questionComment.Delete(conn
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
                                                   , 0);
                    }
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        /// <summary>
        /// 부서 점수를 개인 점수로 재분재하는 메소드
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="estterm_sub_id"></param>
        /// <param name="estterm_step_id"></param>
        /// <param name="create_date"></param>
        /// <param name="create_user"></param>
        /// <returns></returns>
        public bool CopyDeptToEmpData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string year_yn
                                    , string merge_yn
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            Dac_EstInfos estInfo        = new Dac_EstInfos();
            Dac_EstDetails estDetail    = new Dac_EstDetails();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                // 평가 기간별 정보에서 OwnerType 를 변경해준다.
                if(estDetail.Count(conn
                                , trx
                                , comp_id
                                , est_id
                                , estterm_ref_id
                                , estterm_sub_id
                                , estterm_step_id) > 0) 
                {
                    affectedRow += estDetail.Update(  conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , "P"
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , create_date
                                                    , create_user );
                }
                else 
                {
                    affectedRow += estDetail.Insert(  conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , "P"
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , create_date
                                                    , create_user );
                }

                // 기존에 존재하는 사원평가 데이터를 삭제한다.
                affectedRow += _data.Delete(          conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , year_yn
                                                    , merge_yn
                                                    , OwnerType.Emp_User);

                // 부서 평가 데이터를 사원 평가 데이터로 복사한다.
                affectedRow += _data.InsertDeptToEmp( conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , create_date
                                                    , create_user);

                //// 복사 원본 부서 데이터를 삭제한다.
                //affectedRow += _data.Delete(          conn
                //                                    , trx
                //                                    , comp_id
                //                                    , est_id
                //                                    , estterm_ref_id
                //                                    , estterm_sub_id
                //                                    , estterm_step_id
                //                                    , ctrl_emp_id
                //                                    , 0
                //                                    , 0
                //                                    , 0
                //                                    , 0
                //                                    , update_date
                //                                    , update_user);
                

				trx.Commit();
			}
			catch ( Exception ex )
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

        /// <summary>
        /// 링크된 평가를 복사한다.
        /// </summary>
        /// <param name="dtEstQ"></param>
        /// <returns></returns>
        public bool CopyEstDataToLinkedEst(int comp_id
                                        , string est_id_from
                                        , string est_id_to
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string year_yn
                                        , string merge_yn
                                        , OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                // 존재하는 테이터를 우선 삭제한다.
                affectedRow += _data.Delete(  conn
                                            , trx
                                            , comp_id
                                            , est_id_to
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , 0
                                            , 0
                                            , 0
                                            , 0
                                            , year_yn
                                            , merge_yn
                                            , ownerType);
                
                DataTable dtEstData             = _data.SelectEstData(comp_id
                                                                    , est_id_from
                                                                    , estterm_ref_id
                                                                    , estterm_sub_id
                                                                    , estterm_step_id
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , year_yn
                                                                    , merge_yn
                                                                    , ownerType
                                                                    , "").Tables[0];

                DataTable dtBlank               = GetDataTableSchema();
                DataRow dataRow                 = null;

                foreach(DataRow drEstData in dtEstData.Rows) 
                {
                    dataRow = dtBlank.NewRow();

                    dataRow["COMP_ID"]              = comp_id;
                    dataRow["EST_ID"]               = est_id_to;
                    dataRow["ESTTERM_REF_ID"]       = estterm_ref_id;
                    dataRow["ESTTERM_SUB_ID"]       = estterm_sub_id;
                    dataRow["ESTTERM_STEP_ID"]      = estterm_step_id;
                    dataRow["EST_DEPT_ID"]          = drEstData["EST_DEPT_ID"];
                    dataRow["EST_EMP_ID"]           = drEstData["EST_EMP_ID"];
                    dataRow["TGT_DEPT_ID"]          = drEstData["TGT_DEPT_ID"];
                    dataRow["TGT_EMP_ID"]           = drEstData["TGT_EMP_ID"];
                    dataRow["TGT_POS_CLS_ID"]       = drEstData["TGT_POS_CLS_ID"];
                    dataRow["TGT_POS_CLS_NAME"]     = drEstData["TGT_POS_CLS_NAME"];
                    dataRow["TGT_POS_DUT_ID"]       = drEstData["TGT_POS_DUT_ID"];
                    dataRow["TGT_POS_DUT_NAME"]     = drEstData["TGT_POS_DUT_NAME"];
                    dataRow["TGT_POS_GRP_ID"]       = drEstData["TGT_POS_GRP_ID"];
                    dataRow["TGT_POS_GRP_NAME"]     = drEstData["TGT_POS_GRP_NAME"];
                    dataRow["TGT_POS_RNK_ID"]       = drEstData["TGT_POS_RNK_ID"];
                    dataRow["TGT_POS_RNK_NAME"]     = drEstData["TGT_POS_RNK_NAME"];
                    dataRow["TGT_POS_KND_ID"]       = drEstData["TGT_POS_KND_ID"];
                    dataRow["TGT_POS_KND_NAME"]     = drEstData["TGT_POS_KND_NAME"];
                    dataRow["DIRECTION_TYPE"]       = drEstData["DIRECTION_TYPE"];
                    dataRow["POINT_ORG"]            = drEstData["POINT_ORG"];
                    dataRow["POINT_ORG_DATE"]       = drEstData["POINT_ORG_DATE"];
                    dataRow["POINT_AVG"]            = drEstData["POINT_AVG"];
                    dataRow["POINT_AVG_DATE"]       = drEstData["POINT_AVG_DATE"];
                    dataRow["POINT_STD"]            = drEstData["POINT_STD"];
                    dataRow["POINT_STD_DATE"]       = drEstData["POINT_STD_DATE"];
                    dataRow["POINT_CTRL_ORG"]       = drEstData["POINT_CTRL_ORG"];
                    dataRow["POINT_CTRL_ORG_DATE"]  = drEstData["POINT_CTRL_ORG_DATE"];
                    dataRow["GRADE_CTRL_ORG_ID"]    = drEstData["GRADE_CTRL_ORG_ID"];
                    dataRow["GRADE_CTRL_ORG_DATE"]  = drEstData["GRADE_CTRL_ORG_DATE"];
                    dataRow["POINT"]                = drEstData["POINT"];
                    dataRow["POINT_DATE"]           = DateTime.Now;
                    dataRow["GRADE_ID"]             = DBNull.Value;
                    dataRow["GRADE_DATE"]           = DBNull.Value;
                    dataRow["GRADE_TO_POINT"]       = DBNull.Value;
                    dataRow["GRADE_TO_POINT_DATE"]  = DBNull.Value;
                    dataRow["STATUS_ID"]            = drEstData["STATUS_ID"];
                    dataRow["STATUS_DATE"]          = drEstData["UPDATE_DATE"];
                    dataRow["DATE"]                 = drEstData["UPDATE_DATE"];
                    dataRow["USER"]                 = drEstData["UPDATE_USER"];

                    dtBlank.Rows.Add(dataRow);
                }

                foreach(DataRow drBlank in dtBlank.Rows) 
                {
                    affectedRow += _data.Insert(  conn
                                                , trx
                                                , drBlank["COMP_ID"]
                                                , drBlank["EST_ID"]
                                                , drBlank["ESTTERM_REF_ID"]
                                                , drBlank["ESTTERM_SUB_ID"]
                                                , drBlank["ESTTERM_STEP_ID"]
                                                , drBlank["EST_DEPT_ID"]
                                                , drBlank["EST_EMP_ID"]
                                                , drBlank["TGT_DEPT_ID"]
                                                , drBlank["TGT_EMP_ID"]
                                                , drBlank["TGT_POS_CLS_ID"]
                                                , drBlank["TGT_POS_CLS_NAME"]
                                                , drBlank["TGT_POS_DUT_ID"]
                                                , drBlank["TGT_POS_DUT_NAME"]
                                                , drBlank["TGT_POS_GRP_ID"]
                                                , drBlank["TGT_POS_GRP_NAME"]
                                                , drBlank["TGT_POS_RNK_ID"]
                                                , drBlank["TGT_POS_RNK_NAME"]
                                                , drBlank["TGT_POS_KND_ID"]
                                                , drBlank["TGT_POS_KND_NAME"]
                                                , drBlank["DIRECTION_TYPE"]
                                                , drBlank["POINT_ORG"]
                                                , drBlank["POINT_ORG_DATE"]
                                                , drBlank["POINT_AVG"]
                                                , drBlank["POINT_AVG_DATE"]
                                                , drBlank["POINT_STD"]
                                                , drBlank["POINT_STD_DATE"]
                                                , drBlank["POINT_CTRL_ORG"]
                                                , drBlank["POINT_CTRL_ORG_DATE"]
                                                , drBlank["GRADE_CTRL_ORG_ID"]
                                                , drBlank["GRADE_CTRL_ORG_DATE"]
                                                , drBlank["POINT"]
                                                , drBlank["POINT_DATE"]
                                                , drBlank["GRADE_ID"]
                                                , drBlank["GRADE_DATE"]
                                                , drBlank["GRADE_TO_POINT"]
                                                , drBlank["GRADE_TO_POINT_DATE"]
                                                , drBlank["STATUS_ID"]
                                                , drBlank["STATUS_DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        public bool ChangePosData(int comp_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , string emp_ref_ids
                                , string type)
        {
            int affectedRow = 0;

            Dac_EmpEstTargetMaps empEstTgtMap       = new Dac_EmpEstTargetMaps();
            Dac_QuestionDeptEmpMaps questionDeptEmp = new Dac_QuestionDeptEmpMaps();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow += _data.Update(  conn
                                            , trx
                                            , comp_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , emp_ref_ids
                                            , type);

                affectedRow += empEstTgtMap.Update(   conn
                                                    , trx
                                                    , comp_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , emp_ref_ids
                                                    , type);

                if(type.Equals("DPT")) 
                {
                    affectedRow += questionDeptEmp.Update(conn
                                                        , trx
                                                        , comp_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , emp_ref_ids);
                }

				trx.Commit();
			}
			catch ( Exception ex )
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="estterm_sub_id"></param>
        /// <param name="estterm_step_id"></param>
        /// <param name="where_sentence"></param>
        /// <returns></returns>
        public DataSet GetEstDataByRelGroup(  int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , string opt
                                            , string where_sentence)
        {
            return _data.Select(comp_id
                              , est_id
                              , estterm_ref_id
                              , estterm_sub_id
                              , estterm_step_id
                              , opt
                              , where_sentence);
        }

        // 조정자 리스트만 데이터 가지고 오기
		public DataSet GetEstDataByCtrl( int comp_id
								    , string est_id
								    , int estterm_ref_id
								    , int estterm_sub_id
								    , int estterm_step_id
								    , int est_dept_id
								    , int est_emp_id
								    , int tgt_dept_id
								    , int tgt_emp_id
								    , string year_yn
								    , string merge_yn
								    , OwnerType ownerType
                                    , int ctrl_emp_id
                                    , string point_grade_type)
		{
			DataSet ds = null;

			IDbConnection conn = DbAgentHelper.CreateDbConnection();
			conn.Open();
			IDbTransaction trx = conn.BeginTransaction();

			try
			{
                string sql_where = "";

                Dac_CtrlInfos ctrlInfo = new Dac_CtrlInfos();
                DataTable dtCtrlInfo = ctrlInfo.Select("", comp_id, estterm_ref_id, estterm_sub_id, ctrl_emp_id, point_grade_type).Tables[0];
                
                if(dtCtrlInfo.Rows.Count == 0) 
                {
                    sql_where = "AND 1 = 2 ";
                }
                else 
                {
                    sql_where = "AND 1 = 1 ";

                    DataRow dataRowCtrl = dtCtrlInfo.Rows[0];

                    string ctrl_id          = DataTypeUtility.GetValue(dataRowCtrl["CTRL_ID"]);
                    string all_est_yn       = DataTypeUtility.GetValue(dataRowCtrl["ALL_EST_YN"], "N");
                    string all_est_dept_yn  = DataTypeUtility.GetValue(dataRowCtrl["ALL_EST_DEPT_YN"], "N");
                    string all_est_emp_yn   = DataTypeUtility.GetValue(dataRowCtrl["ALL_EST_EMP_YN"], "N");
                    
                    if(all_est_yn == "N") 
                    {
                        Dac_CtrlEstMaps ctrlEstMap = new Dac_CtrlEstMaps();
                        DataTable dtCtrlEstMap = ctrlEstMap.Select(ctrl_id, "").Tables[0];

                        if(dtCtrlEstMap.Rows.Count > 0)
                            sql_where += string.Format("AND ED.EST_ID IN ({0}) ", DataTypeUtility.GetSplitString(dtCtrlEstMap, "EST_ID", ",", true));
                    }

                    if(all_est_dept_yn == "N") 
                    {
                        Dac_CtrlDeptMaps ctrlDeptMap = new Dac_CtrlDeptMaps();
                        DataTable dtCtrlEstDeptMap = ctrlDeptMap.Select(ctrl_id, 0).Tables[0];

                        if(dtCtrlEstDeptMap.Rows.Count > 0)
                            sql_where += string.Format("AND ED.TGT_DEPT_ID IN ({0}) ", DataTypeUtility.GetSplitString(dtCtrlEstDeptMap, "DEPT_REF_ID", ",", true));
                    }

                    if(all_est_emp_yn == "N")  
                    {
                        // 일단 주석 처리
                        //Dac_CtrlEmpMaps ctrlEmpMap = new Dac_CtrlEmpMaps();
                        //DataTable dtCtrlEmpMap = ctrlEmpMap.Select(ctrl_id, 0).Tables[0];

                        //if(dtCtrlEmpMap.Rows.Count > 0)
                        //    sql_where += string.Format("AND ED.TGT_EMP_ID IN ({0}) ", DataTypeUtility.GetSplitString(dtCtrlEmpMap, "EMP_REF_ID", ",", true));
                    }
                }

				ds = _data.SelectEstData( comp_id
							            , est_id
							            , estterm_ref_id
							            , estterm_sub_id
							            , estterm_step_id
							            , est_dept_id
							            , est_emp_id
							            , tgt_dept_id
							            , tgt_emp_id
							            , year_yn
							            , merge_yn
							            , ownerType
                                        , sql_where);

				trx.Commit();
			}
			catch ( Exception ex )
			{
				trx.Rollback();
				return null;
			}
			finally
			{
				conn.Close();
			}

			return ds;
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
            dataTable.Columns.Add("TGT_DEPT_ID", typeof(int));
            dataTable.Columns.Add("TGT_EMP_ID", typeof(int));
            dataTable.Columns.Add("TGT_POS_CLS_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_CLS_NAME", typeof(string));
            dataTable.Columns.Add("TGT_POS_DUT_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_DUT_NAME", typeof(string));
            dataTable.Columns.Add("TGT_POS_GRP_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_GRP_NAME", typeof(string));
            dataTable.Columns.Add("TGT_POS_RNK_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_RNK_NAME", typeof(string));
            dataTable.Columns.Add("TGT_POS_KND_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_KND_NAME", typeof(string));
            dataTable.Columns.Add("DIRECTION_TYPE", typeof(string));
            dataTable.Columns.Add("POINT_ORG", typeof(decimal));
            dataTable.Columns.Add("POINT_ORG_DATE", typeof(DateTime));
            dataTable.Columns.Add("POINT_AVG", typeof(decimal));
            dataTable.Columns.Add("POINT_AVG_DATE", typeof(DateTime));
            dataTable.Columns.Add("POINT_STD", typeof(decimal));
            dataTable.Columns.Add("POINT_STD_DATE", typeof(DateTime));
            dataTable.Columns.Add("POINT_CTRL_ORG", typeof(decimal));
            dataTable.Columns.Add("POINT_CTRL_ORG_DATE", typeof(DateTime));
            dataTable.Columns.Add("GRADE_CTRL_ORG_ID", typeof(string));
            dataTable.Columns.Add("GRADE_CTRL_ORG_DATE", typeof(DateTime));
            dataTable.Columns.Add("POINT", typeof(decimal));
            dataTable.Columns.Add("POINT_DATE", typeof(DateTime));
            dataTable.Columns.Add("GRADE_CALC_ID", typeof(string));
            dataTable.Columns.Add("GRADE_ID", typeof(string));
            dataTable.Columns.Add("GRADE_DATE", typeof(DateTime));
            dataTable.Columns.Add("GRADE_TO_POINT_CALC", typeof(decimal));
            dataTable.Columns.Add("GRADE_TO_POINT", typeof(decimal));
            dataTable.Columns.Add("GRADE_TO_POINT_DATE", typeof(DateTime));
            dataTable.Columns.Add("STATUS_ID", typeof(string));
            dataTable.Columns.Add("STATUS_DATE", typeof(DateTime));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }

        public DataSet SelectAllStdDevGrade()
        {
            DataSet dsStdDevGrade = null;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                dsStdDevGrade = this._data.SelectAllStdDevGrade(conn, trx);
                trx.Commit();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return dsStdDevGrade;
        }

        public int ConfirmMBOMapable(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, int estterm_step_id, int tgt_emp_id)
        {
            return _data.ConfirmMBOMapable(comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, tgt_emp_id);
        }

        public bool ConfirmMBOEstimate(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, string job_id, int emp_ref_id, bool completeyn)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (_data.ConfirmMBOEstimate(conn, trx, comp_id, est_id, estterm_ref_id, estterm_sub_id, job_id, emp_ref_id, completeyn))
                    trx.Commit();
                else
                {
                    trx.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                trx.Rollback();
                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public bool ConfirmCancelMBOEstimate(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, string job_id, int emp_ref_id)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (_data.ConfirmCancelMBOEstimate(conn, trx, comp_id, est_id, estterm_ref_id, estterm_sub_id, job_id, emp_ref_id))
                    trx.Commit();
                else
                {
                    trx.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                trx.Rollback();
                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public int SaveAllStdDevGrade(DataTable dtStdDevGrade, int empId)
        {
            int affectedRows = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                _data.DeleteAllStdDevGrade(conn, trx);
                for (int rowIdx = 0; rowIdx < dtStdDevGrade.Rows.Count; rowIdx++)
                {
                    string scoreCode = dtStdDevGrade.Rows[rowIdx].ItemArray.GetValue(1) as string;
                    string scoreName = dtStdDevGrade.Rows[rowIdx].ItemArray.GetValue(2) as string;
                    double minValue = Convert.ToDouble(dtStdDevGrade.Rows[rowIdx].ItemArray.GetValue(3));
                    double maxValue = Convert.ToDouble(dtStdDevGrade.Rows[rowIdx].ItemArray.GetValue(4));

                    _data.InsertOneStdDevGrade(conn, trx, scoreCode, scoreName, minValue, maxValue, empId);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return affectedRows;
        }

        public void ConfirmNewColumn(string tableName, string columnName, string schemeQuery)
        {
            _data.ConfirmNewColumn(tableName, columnName, schemeQuery);
        }
    }
}