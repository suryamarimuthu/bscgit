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
    public class Biz_EstDeptInfos
    {
       
        #region ============================== [Fields] ==============================

        private int _est_dept_ref_id;
        private int _estterm_ref_id;
        private int _dept_ref_id;
        private int _up_est_dept_id;
        private int _dept_level;
        private string _dept_name;
        private bool _temp_flag;
        private int _est_dept_group_id;
        private int _dept_type;
        private int _sort_order;
        private string _view_yn_org;
        private string _header_img_org;
        private int _sort_org;
        private string _dept_name_org;
        private string _industry_type;
        private int _industry_type_order;
        private int _update_user;
        private string _errMSG;
        private DateTime _update_date;
        private Dac_EstDeptInfos _estDeptInfos = new Dac_EstDeptInfos();
        #endregion

        #region ============================== [Properties] ==============================

        public string errMSG
        {
            get
            {
                return _errMSG;
            }
            set
            {
                _errMSG = (value == null ? "" : value);
            }
        }

        public int Est_Dept_Ref_ID
        {
            get
            {
                return _est_dept_ref_id;
            }
            set
            {
                _est_dept_ref_id = value;
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

        public int Dept_Ref_ID
        {
            get
            {
                return _dept_ref_id;
            }
            set
            {
                _dept_ref_id = value;
            }
        }

        public int Up_Est_Dept_ID
        {
            get
            {
                return _up_est_dept_id;
            }
            set
            {
                _up_est_dept_id = value;
            }
        }

        public int Dept_Level
        {
            get
            {
                return _dept_level;
            }
            set
            {
                _dept_level = value;
            }
        }

        public string Dept_Name
        {
            get
            {
                return _dept_name;
            }
            set
            {
                _dept_name = (value == null ? "" : value);
            }
        }

        public bool Temp_Flag
        {
            get
            {
                return _temp_flag;
            }
            set
            {
                _temp_flag = value;
            }
        }

        public int Est_Dept_Group_ID
        {
            get
            {
                return _est_dept_group_id;
            }
            set
            {
                _est_dept_group_id = value;
            }
        }

        public int Dept_Type
        {
            get
            {
                return _dept_type;
            }
            set
            {
                _dept_type = value;
            }
        }

        public int Sort_Order
        {
            get
            {
                return _sort_order;
            }
            set
            {
                _sort_order = value;
            }
        }

        public string View_YN_Org
        {
            get
            {
                return _view_yn_org;
            }
            set
            {
                _view_yn_org = (value == null ? "" : value);
            }
        }

        public string Header_Img_Org
        {
            get
            {
                return _header_img_org;
            }
            set
            {
                _header_img_org = (value == null ? "" : value);
            }
        }

        public int Sort_Org
        {
            get
            {
                return _sort_org;
            }
            set
            {
                _sort_org = value;
            }
        }

        public string Dept_Name_Org
        {
            get
            {
                return _dept_name_org;
            }
            set
            {
                _dept_name_org = (value == null ? "" : value);
            }
        }

        public string Industry_Type
        {
            get
            {
                return _industry_type;
            }
            set
            {
                _industry_type = (value == null ? "" : value);
            }
        }

        public int Industry_Type_Order
        {
            get
            {
                return _industry_type_order;
            }
            set
            {
                _industry_type_order = value;
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
        #endregion

        public Biz_EstDeptInfos()
        {

        }

        public Biz_EstDeptInfos(int estterm_ref_id, int est_dept_ref_id)
        {
            DataSet ds = _estDeptInfos.Select(estterm_ref_id, est_dept_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                      = ds.Tables[0].Rows[0];
                _est_dept_ref_id        = (dr["EST_DEPT_REF_ID"]        == DBNull.Value) ? 0 : int.Parse(dr["EST_DEPT_REF_ID"].ToString());
                _estterm_ref_id         = (dr["ESTTERM_REF_ID"]         == DBNull.Value) ? 0 : int.Parse(dr["ESTTERM_REF_ID"].ToString());
                _dept_ref_id            = (dr["DEPT_REF_ID"]            == DBNull.Value) ? 0 : int.Parse(dr["DEPT_REF_ID"].ToString());
                _up_est_dept_id         = (dr["UP_EST_DEPT_ID"]         == DBNull.Value) ? 0 : int.Parse(dr["UP_EST_DEPT_ID"].ToString());
                _dept_level             = (dr["DEPT_LEVEL"]             == DBNull.Value) ? 0 : int.Parse(dr["DEPT_LEVEL"].ToString());
                _dept_name              = (dr["DEPT_NAME"]              == DBNull.Value) ? "" : (string)dr["DEPT_NAME"];
                if (DbAgentHelper.GetProviderType() == "ORACLE")
                {
                    decimal sflag = (dr["TEMP_FLAG"] == DBNull.Value) ? 0 : decimal.Parse(dr["TEMP_FLAG"].ToString());
                    _temp_flag = (sflag == 0) ? false : true;
                }
                else
                { 
                    _temp_flag          = (dr["TEMP_FLAG"] == DBNull.Value) ? false : bool.Parse(dr["TEMP_FLAG"].ToString());
                }
                _est_dept_group_id      = (dr["EST_DEPT_GROUP_ID"]      == DBNull.Value) ? 0 : int.Parse(dr["EST_DEPT_GROUP_ID"].ToString());
                _dept_type              = (dr["DEPT_TYPE"]              == DBNull.Value) ? 0 : int.Parse(dr["DEPT_TYPE"].ToString());
                _sort_order             = (dr["SORT_ORDER"]             == DBNull.Value) ? 0 : int.Parse(dr["SORT_ORDER"].ToString());
                _view_yn_org            = (dr["VIEW_YN_ORG"]            == DBNull.Value) ? "" : (string)dr["VIEW_YN_ORG"];
                _header_img_org         = (dr["HEADER_IMG_ORG"]         == DBNull.Value) ? "" : (string)dr["HEADER_IMG_ORG"];
                _sort_org               = (dr["SORT_ORG"]               == DBNull.Value) ? 0 : int.Parse(dr["SORT_ORG"].ToString());
                _dept_name_org          = (dr["DEPT_NAME_ORG"]          == DBNull.Value) ? "" : (string)dr["DEPT_NAME_ORG"];
                _industry_type          = (dr["INDUSTRY_TYPE"]          == DBNull.Value) ? "" : (string)dr["INDUSTRY_TYPE"];
                _industry_type_order    = (dr["INDUSTRY_TYPE_ORDER"]    == DBNull.Value) ? 0 : int.Parse(dr["INDUSTRY_TYPE_ORDER"].ToString());
                _update_user            = (dr["UPDATE_USER"]            == DBNull.Value) ? 0 : int.Parse(dr["UPDATE_USER"].ToString());
                _update_date            = (dr["UPDATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
            }
        }

        public bool ModifyDeptinfo(int est_dept_ref_id
                                , int estterm_ref_id
                                , int dept_ref_id
                                , int up_est_dept_id
                                , int dept_level
                                , string dept_name
                                , bool temp_flag
                                , int est_dept_group_id
                                , int dept_type
                                , int sort_order
                                , string view_yn_org
                                , string header_img_org
                                , int sort_org
                                , string dept_name_org
                                , string industry_type
                                , int industry_type_order
                                , int update_user
                                , DateTime update_date)
        {
             int affectedRow = 0;

             affectedRow =  _estDeptInfos.Update(null
                                            ,  null
                                            ,  est_dept_ref_id
                                            ,  estterm_ref_id
                                            ,  dept_ref_id
                                            ,  up_est_dept_id
                                            ,  dept_level
                                            ,  dept_name
                                            ,  temp_flag
                                            ,  est_dept_group_id
                                            ,  dept_type
                                            ,  sort_order
                                            ,  view_yn_org
                                            ,  header_img_org
                                            ,  sort_org
                                            ,  dept_name_org
                                            ,  industry_type
                                            ,  industry_type_order
                                            ,  update_user
                                            ,  update_date);

            return ( affectedRow > 0 ) ? true : false;
        }

        public DataSet GetDeptDetailInfo(int estterm_ref_id, string est_id)
        {
            return _estDeptInfos.SelectDeptDetail(estterm_ref_id, est_id);
        }

        public DataSet GetDeptinfo(int estterm_ref_id, int est_dept_ref_id)
        {
            return _estDeptInfos.Select(estterm_ref_id, est_dept_ref_id);
        }

        public DataSet GetDeptinfo(int estterm_ref_id)
        {
            return _estDeptInfos.Select(estterm_ref_id, 0);
        }

        public bool AddDeptinfo(int est_dept_ref_id
                                , int estterm_ref_id
                                , int dept_ref_id
                                , int up_est_dept_id
                                , int dept_level
                                , string dept_name
                                , bool temp_flag
                                , int est_dept_group_id
                                , int dept_type
                                , int sort_order
                                , string view_yn_org
                                , string header_img_org
                                , int sort_org
                                , string dept_name_org
                                , string industry_type
                                , int industry_type_order
                                , int create_user
                                , DateTime create_date)
        {
            int affectedRow = 0;

            affectedRow = _estDeptInfos.Insert(null
                                            , null
                                            , est_dept_ref_id
                                            , estterm_ref_id
                                            , dept_ref_id
                                            , up_est_dept_id
                                            , dept_level
                                            , dept_name
                                            , temp_flag
                                            , est_dept_group_id
                                            , dept_type
                                            , sort_order
                                            , view_yn_org
                                            , header_img_org
                                            , sort_org
                                            , dept_name_org
                                            , industry_type
                                            , industry_type_order
                                            , create_user
                                            , create_date);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveDeptinfo(int est_dept_ref_id)
        {
            int affectedRow = 0;

            affectedRow = _estDeptInfos.Delete(null
                                               , null
                                               , est_dept_ref_id);

            return (affectedRow > 0) ? true : false;
            
        }

        public bool IsExists(int est_dept_ref_id)
        {
            int affectedRow = 0;

            affectedRow = _estDeptInfos.Count(est_dept_ref_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool CopyEstDept(int org_estterm_ref_id, int new_estterm_ref_id, int reg_user)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = _estDeptInfos.CopyEstDept(conn, trx, org_estterm_ref_id, new_estterm_ref_id, reg_user);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch(Exception ex)
            {
                trx.Rollback();
                this.errMSG = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }
    }
}
