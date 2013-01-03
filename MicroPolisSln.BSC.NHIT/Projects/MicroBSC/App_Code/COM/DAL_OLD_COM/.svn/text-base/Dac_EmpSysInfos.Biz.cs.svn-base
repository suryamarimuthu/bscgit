using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MicroBSC.Biz.Common
{
    public class EmpSysInfos_Biz : EmpSysInfos_Data
    {
        public EmpSysInfos_Biz(int emp_ref_id) : base(emp_ref_id)
        {
            
        }

        public string GetSysValueByEmpID(int sys_key) 
        {
            DataSet ds_info     = GetEmpSysInfo(sys_key);
            DataSet ds_detail   = GetEmpSysDetail(sys_key);

            if (ds_detail.Tables[0].Rows.Count > 0) 
            {
                return ds_detail.Tables[0].Rows[0]["SYS_VALUE"].ToString();
            }

            return ds_info.Tables[0].Rows[0]["SYS_CTRL_DEFAUT"].ToString();
        }

        public DataTable GetSysDataSource(int sys_key, ref string control_type) 
        {
            DataSet ds_info         = GetEmpSysInfo(sys_key);
            string[] ctrl_key_col   = ds_info.Tables[0].Rows[0]["SYS_CTRL_KEY_COL"].ToString().Split(',');
            string[] ctrl_value_col = ds_info.Tables[0].Rows[0]["SYS_CTRL_VALUE_COL"].ToString().Split(',');
            control_type            = ds_info.Tables[0].Rows[0]["SYS_CTRL_TYPE"].ToString();
            
            DataTable dt    = new DataTable();
            DataRow dr      = null;
            dt.Columns.Add("SYS_CTRL_KEY", typeof(string));
            dt.Columns.Add("SYS_CTRL_VALUE", typeof(string));

            for (int i = 0; i < ctrl_key_col.Length; i++) 
            {
                dr                      = dt.NewRow();
                dr["SYS_CTRL_KEY"]      = ctrl_key_col[i];
                dr["SYS_CTRL_VALUE"]    = ctrl_value_col[i];
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public DataTable GetSysDataSource(string sys_key_col, string sys_value_col) 
        {
            string[] ctrl_key_col   = sys_key_col.Split(',');
            string[] ctrl_value_col = sys_value_col.Split(',');

            DataTable dt    = new DataTable();
            DataRow dr      = null;
            dt.Columns.Add("SYS_CTRL_KEY", typeof(string));
            dt.Columns.Add("SYS_CTRL_VALUE", typeof(string));

            for (int i = 0; i < ctrl_key_col.Length; i++)
            {
                dr                      = dt.NewRow();
                dr["SYS_CTRL_KEY"]      = ctrl_key_col[i];
                dr["SYS_CTRL_VALUE"]    = ctrl_value_col[i];
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
