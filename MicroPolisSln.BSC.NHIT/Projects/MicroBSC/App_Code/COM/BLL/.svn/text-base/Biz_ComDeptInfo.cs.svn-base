using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MicroBSC.Biz.Common.Biz
{
    public class Biz_ComDeptInfo : MicroBSC.Biz.Common.Dac.Dac_ComDeptInfo
    {
        public Biz_ComDeptInfo() { }
        public Biz_ComDeptInfo(int idept_ref_id) : base(idept_ref_id) { }

        public int InsertData(int iup_dept_id, int idept_level, string idept_name, string idept_code, int idept_flag, int idept_type, int isort_order, string idept_desc, int itxr_user)
        {
            int affectedRow = InsertData_Dac(iup_dept_id, idept_level, idept_name, idept_code, idept_flag, idept_type, isort_order, idept_desc, itxr_user);
            return affectedRow;
        }

        public int UpdateData(int idept_ref_id, int iup_dept_id, int idept_level, string idept_name, string idept_code, int idept_flag, int idept_type, int isort_order, string idept_desc, int itxr_user)
        {
            int affectedRow  = UpdateData_Dac(idept_ref_id, iup_dept_id, idept_level, idept_name, idept_code, idept_flag, idept_type, isort_order, idept_desc, itxr_user);
            return affectedRow;
        }

        public int DeleteData(int idept_ref_id, int itxr_user)
        {
            int affectedRow = DeleteData_Dac(idept_ref_id, itxr_user);
            return affectedRow;
        }

        public int DeptShift(int idept_ref_id, int iup_dept_id, int itxr_user)
        {
            int affectedRow = DeptShift_Dac(idept_ref_id, iup_dept_id, itxr_user);
            return affectedRow;
        }

        public DataSet GetAllList()
        {
            DataSet ds = GetAllList_Dac();
            return ds;
        }

        public DataSet GetOneList(int idept_ref_id)
        {
            DataSet ds = GetOneList_Dac(idept_ref_id);
            return ds;
        }

        public DataSet GetComDeptByTree()
        {
            DataSet ds = GetComDeptByTree_Dac();
            return ds;
        }

        public DataSet GetDeptMappingByTree(int iest_term_ref_id)
        { 
            DataSet ds = GetDeptMappingByTree_Dac(iest_term_ref_id);
            return ds;
        }

        public DataSet GetDeptOrgStatusByTree(int iest_term_ref_id)
        {
            DataSet ds = GetDeptOrgStatusByTree_Dac(iest_term_ref_id);
            return ds;
        }

        public DataSet GetComDeptOrgAuthorityByTree(int iLoginUser)
        {
            DataSet ds = base.GetComDeptOrgAuthorityByTree_Dac(iLoginUser);
            return ds;
        }
    }
}
