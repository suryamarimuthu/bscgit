using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MicroBSC.Biz.Common.Biz
{
    public class Biz_DeptTypeInfo : MicroBSC.Biz.Common.Dac.Dac_DeptTypeInfo
    {
        public Biz_DeptTypeInfo() { }
        public Biz_DeptTypeInfo(int itype_ref_id) : base(itype_ref_id) { }

        public int UpdateData(int itype_ref_id, string itype_name, int isort_order, string itype_desc, string itype_image, string izipcode, string iaddress1, string iaddress2, string itel, string ifax, string isite_url, string ibrn, int imgr_user_id, int itxr_user)
        {
            int affectedRow = UpdateData_Dac(itype_ref_id, itype_name, isort_order, itype_desc, itype_image, izipcode, iaddress1, iaddress2, itel, ifax, isite_url, ibrn, imgr_user_id, itxr_user);
            return affectedRow;        
        }

        public int InsertData(string itype_name, int isort_order, string itype_desc, string itype_image, string izipcode, string iaddress1, string iaddress2, string itel, string ifax, string isite_url, string ibrn, int imgr_user_id, int itxr_user)
        {
            int affectedRow = InsertData_Dac(itype_name, isort_order, itype_desc, itype_image, izipcode, iaddress1, iaddress2, itel, ifax, isite_url, ibrn, imgr_user_id, itxr_user);
            return affectedRow;
        }

        public int DeleteData(int itype_ref_id, int itxr_user)
        {
            int affectedRow = DeleteData_Dac(itype_ref_id, itxr_user);
            return affectedRow;
        }

        public DataSet GetAllList()
        {
            DataSet ds = GetAllList_Dac();
            return ds;
        }

        public DataSet GetOneList(int itype_ref_id)
        {
            DataSet ds = GetOneList_Dac(itype_ref_id);
            return ds;
        }

        public DataSet GetDeptTypeSortList(int estterm_ref_id, int dept_ref_id)
        {
            return GetDeptTypeSortList_Dac(estterm_ref_id, dept_ref_id);
        }


        public DataTable GetDeptTypeList()
        {
            return GetDeptTypeList_Dac();
        }

        //public int ModifyDeptTypeList(int type_ref_id, string home_yn_org, string header_yn_org, string content_yn_org)
        //{
        //    return ModifyDeptTypeList_Dac(type_ref_id, home_yn_org, header_yn_org, content_yn_org);
        //}
    }
}
