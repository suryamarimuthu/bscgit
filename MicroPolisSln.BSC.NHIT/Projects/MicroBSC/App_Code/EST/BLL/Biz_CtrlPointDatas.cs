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
    public class Biz_CtrlPointDatas
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_est_id;
        private int 	_estterm_ref_id;
        private int 	_estterm_sub_id;
        private int 	_estterm_step_id;
        private int 	_ctrl_emp_id;
        private int 	_tgt_dept_id;
        private int 	_tgt_emp_id;
        private int 	_ctrl_seq;
        private float 	_ctrl_point;
        private string 	_ctrl_opinion;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_CtrlPointDatas _ctrlPointData = new Dac_CtrlPointDatas();

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
		        _est_id = ( value==null ? "" : value );
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

        public int EstTerm_Step_ID
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
         
        public int Ctrl_Seq
        {
	        get 
	        {
		        return _ctrl_seq;
	        }
	        set
	        {
		        _ctrl_seq = value;
	        }
        }
         
        public float Ctrl_Point
        {
	        get 
	        {
		        return _ctrl_point;
	        }
	        set
	        {
		        _ctrl_point = value;
	        }
        }

        public string Ctrl_Opinion
        {
	        get 
	        {
		        return _ctrl_opinion;
	        }
	        set
	        {
		        _ctrl_opinion = value;
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
         
        public Biz_CtrlPointDatas()
        {
            
        }

        public Biz_CtrlPointDatas(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int ctrl_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int ctrl_seq)
        {
            DataSet ds = _ctrlPointData.Select( comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , ctrl_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , ctrl_seq);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _comp_id        = (dr["COMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id         = (dr["EST_ID"]         == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_ref_id = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _estterm_sub_id = (dr["ESTTERM_SUB_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id = (dr["ESTTERM_STEP_ID"]== DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
		        _ctrl_emp_id    = (dr["CTRL_EMP_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CTRL_EMP_ID"]);
                _tgt_dept_id    = (dr["TGT_DEPT_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_DEPT_ID"]);
		        _tgt_emp_id     = (dr["TGT_EMP_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_EMP_ID"]);
		        _ctrl_seq       = (dr["CTRL_SEQ"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["CTRL_SEQ"]);
		        _ctrl_point     = (dr["CTRL_POINT"]     == DBNull.Value) ? 0 : Convert.ToSingle(dr["CTRL_POINT"]);
                _ctrl_opinion   = (dr["CTRL_OPINION"]   == DBNull.Value) ? "" : (string) dr["CTRL_OPINION"];
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyCtrlPointData(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int ctrl_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int ctrl_seq
                                        , float ctrl_point
                                        , string ctrl_opinion
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlPointData.Update(null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , ctrl_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , ctrl_seq
                                            , ctrl_point
                                            , ctrl_opinion
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetCtrlPointData(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int ctrl_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int ctrl_seq)
        {
            return _ctrlPointData.Select( comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , ctrl_emp_id
                                        , tgt_dept_id
                                        , tgt_emp_id
                                        , ctrl_seq);
        }
         
        public bool AddCtrlPointData( int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int ctrl_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , float ctrl_point
                                    , string ctrl_opinion
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            int ctrl_seq = _ctrlPointData.Count(comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, 0, 0, tgt_dept_id, tgt_emp_id) + 1;

            affectedRow = _ctrlPointData.Insert(null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , ctrl_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , ctrl_seq
                                            , ctrl_point
                                            , ctrl_opinion
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveCtrlPointData(  int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int ctrl_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int ctrl_seq)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlPointData.Delete(null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , ctrl_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , ctrl_seq);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(  int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int ctrl_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , int ctrl_seq)
        {
	        int affectedRow = 0;

            affectedRow = _ctrlPointData.Count(comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , ctrl_emp_id
                                            , tgt_dept_id
                                            , tgt_emp_id
                                            , ctrl_seq);

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
            dataTable.Columns.Add("CTRL_EMP_ID", typeof(int));
            dataTable.Columns.Add("TGT_DEPT_ID", typeof(int));
            dataTable.Columns.Add("TGT_EMP_ID", typeof(int));
            dataTable.Columns.Add("CTRL_SEQ", typeof(int));
            dataTable.Columns.Add("CTRL_POINT", typeof(float));
            dataTable.Columns.Add("CTRL_OPINION", typeof(string));
            dataTable.Columns.Add("CTRL_YN", typeof(string));
            dataTable.Columns.Add("BEFORE_POINT", typeof(float));
            dataTable.Columns.Add("CREATE_DATE", typeof(int));
            dataTable.Columns.Add("CREATE_USER", typeof(int));
            
            return dataTable;
        }
    }
}
