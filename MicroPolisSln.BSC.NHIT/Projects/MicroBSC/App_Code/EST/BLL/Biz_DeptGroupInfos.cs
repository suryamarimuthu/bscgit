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
    public class Biz_DeptGroupInfos
    {
        #region ============================== [Fields] ==============================

        private int _est_dept_group_id;
        private string _est_dept_group_name;

        private Dac_DeptGroupInfos _deptGroupInfo = new Dac_DeptGroupInfos();

        #endregion

        #region ============================== [Properties] ==============================

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

        public string Est_Dept_Group_Name
        {
            get
            {
                return _est_dept_group_name;
            }
            set
            {
                _est_dept_group_name = (value == null ? "" : value);
            }
        }
        #endregion

        public Biz_DeptGroupInfos()
	    {
		    
	    }

        public Biz_DeptGroupInfos(int est_dept_group_id)
	    {
		    DataSet ds = _deptGroupInfo.Select(est_dept_group_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _est_dept_group_id      = (dr["EST_DEPT_GROUP_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_GROUP_ID"]);
                _est_dept_group_name    = (dr["EST_DEPT_GROUP_NAME"]    == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_GROUP_NAME"]);
            }
	    }

        public bool ModifyDeptGroupInfo(  int est_dept_group_id
                                        , string est_dept_group_name)
        {
            int affectedRow = 0;

            affectedRow = _deptGroupInfo.Update(  null
                                                , null
                                                , est_dept_group_id
                                                , est_dept_group_name);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetDeptGroupInfo(int est_dept_group_id)
        {
            return _deptGroupInfo.Select(est_dept_group_id);
        }

        public bool AddDeptGroupInfo( int est_dept_group_id
                                    , string est_dept_group_name)
        {
            int affectedRow = 0;

            affectedRow = _deptGroupInfo.Insert(  null
                                                , null
                                                , est_dept_group_id
                                                , est_dept_group_name);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveDeptGroupInfo(int est_dept_group_id)
        {
            int affectedRow = 0;

            affectedRow = _deptGroupInfo.Delete(  null
                                                , null
                                                , est_dept_group_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
