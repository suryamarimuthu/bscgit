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
    public class Biz_CtrlInfos
    {
        #region ============================== [Fields] ==============================
 
        private string 	_ctrl_id;
        private int 	_comp_id;
        private int 	_estterm_ref_id;
        private int 	_estterm_sub_id;
        private int 	_ctrl_emp_id;
        private float 	_scope;
        private string 	_point_grade_type;
        private string 	_scope_unit_id;
        private string 	_all_est_yn;
        private string 	_all_est_dept_yn;
        private string  _confirm_emp_yn;
        private int 	_ctrl_order;
        private DateTime 	_update_date;
        private int 	_update_user;

        Dac_CtrlInfos _ctrlInfo = new Dac_CtrlInfos();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Ctrl_ID
        {
	        get 
	        {
		        return _ctrl_id;
	        }
	        set
	        {
		        _ctrl_id = ( value==null ? "" : value );
	        }
        }
         
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
         
        public int EstTerm_Ref_ID
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
         
        public int EstTerm_Sub_ID
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
         
        public float Scope
        {
	        get 
	        {
		        return _scope;
	        }
	        set
	        {
		        _scope = value;
	        }
        }
         
        public string Point_Grade_Type
        {
	        get 
	        {
		        return _point_grade_type;
	        }
	        set
	        {
		        _point_grade_type = ( value==null ? "" : value );
	        }
        }
         
        public string Scope_Unit_ID
        {
	        get 
	        {
		        return _scope_unit_id;
	        }
	        set
	        {
		        _scope_unit_id = ( value==null ? "" : value );
	        }
        }

        public string All_Est_YN
        {
	        get 
	        {
		        return _all_est_yn;
	        }
	        set
	        {
		        _all_est_yn = ( value==null ? "N" : value );
	        }
        }

        public string All_Est_Dept_YN
        {
	        get 
	        {
		        return _all_est_dept_yn;
	        }
	        set
	        {
		        _all_est_dept_yn = ( value==null ? "N" : value );
	        }
        }

        public string Confirm_Emp_YN
        {
	        get 
	        {
		        return _confirm_emp_yn;
	        }
	        set
	        {
		        _confirm_emp_yn = ( value==null ? "N" : value );
	        }
        }
         
        public int Ctrl_Order
        {
	        get 
	        {
		        return _ctrl_order;
	        }
	        set
	        {
		        _ctrl_order = value;
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
         
        public Biz_CtrlInfos() 
        {
            
        }

        public Biz_CtrlInfos(string ctrl_id) 
        {
            DataSet ds = _ctrlInfo.Select(ctrl_id, 0, 0, 0, 0, "");
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];
		        _ctrl_id            = (dr["CTRL_ID"]            == DBNull.Value) ? "" : (string) dr["CTRL_ID"];
		        _comp_id            = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _estterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _estterm_sub_id     = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
		        _ctrl_emp_id        = (dr["CTRL_EMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CTRL_EMP_ID"]);
		        _scope              = (dr["SCOPE"]              == DBNull.Value) ? 0 : Convert.ToSingle(dr["SCOPE"]);
		        _point_grade_type   = (dr["POINT_GRADE_TYPE"]   == DBNull.Value) ? "" : (string) dr["POINT_GRADE_TYPE"];
		        _scope_unit_id      = (dr["SCOPE_UNIT_ID"]      == DBNull.Value) ? "" : (string) dr["SCOPE_UNIT_ID"];
                _all_est_yn         = (dr["ALL_EST_YN"]         == DBNull.Value) ? "" : (string) dr["ALL_EST_YN"];
                _all_est_dept_yn    = (dr["ALL_EST_DEPT_YN"]    == DBNull.Value) ? "" : (string) dr["ALL_EST_DEPT_YN"];
                _confirm_emp_yn     = (dr["CONFIRM_EMP_YN"]     == DBNull.Value) ? "" : (string) dr["CONFIRM_EMP_YN"];
		        _ctrl_order         = (dr["CTRL_ORDER"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["CTRL_ORDER"]);
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyCtrlInfo(string ctrl_id
                                , int comp_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int ctrl_emp_id
                                , float scope
                                , string point_grade_type
                                , string scope_unit_id
                                , string all_est_yn
                                , string all_est_dept_yn
                                , string confirm_emp_yn
                                , int ctrl_order
                                , DateTime update_date
                                , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlInfo.Update(null
                                        , null
                                        , ctrl_id
                                        , comp_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , ctrl_emp_id
                                        , scope
                                        , point_grade_type
                                        , scope_unit_id
                                        , all_est_yn
                                        , all_est_dept_yn
                                        , confirm_emp_yn
                                        , ctrl_order
                                        , update_date
                                        , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetCtrlInfo( string ctrl_id
                                    , int comp_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , string point_grade_type)
		{
			return _ctrlInfo.Select(  ctrl_id
                                    , comp_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , 0
                                    , point_grade_type);
		}
         
        public bool AddCtrlInfo(int comp_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int ctrl_emp_id
                            , float scope
                            , string point_grade_type
                            , string scope_unit_id
                            , string all_est_yn
                            , string all_est_dept_yn
                            , string confirm_emp_yn
                            , int ctrl_order
                            , DateTime create_date
                            , int create_user)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Dac_KeyGens keyGen  = new Dac_KeyGens();
                string ctrl_id      = keyGen.GetCode(conn, trx, "EST_CTRL_INFO");

                affectedRow = _ctrlInfo.Insert(conn
                                            , trx
                                            , ctrl_id
                                            , comp_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , ctrl_emp_id
                                            , scope
                                            , point_grade_type
                                            , scope_unit_id
                                            , all_est_yn
                                            , all_est_dept_yn
                                            , confirm_emp_yn
                                            , ctrl_order
                                            , create_date
                                            , create_user);

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
         
        public bool RemoveCtrlInfo( string ctrl_id)
        {
            int affectedRow = 0;

            Dac_CtrlEstMaps ctrlEstMap          = new Dac_CtrlEstMaps();
            Dac_CtrlDeptMaps ctrlDeptMap        = new Dac_CtrlDeptMaps();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += ctrlDeptMap.Delete(conn
                                                    , trx
                                                    , ctrl_id
                                                    , 0);

                affectedRow += ctrlEstMap.Delete(conn
                                                , trx
                                                , ctrl_id
                                                , "");

                affectedRow += _ctrlInfo.Delete(conn
                                                , trx
                                                , ctrl_id
                                                , 0
                                                , "");
                
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
    }
}
