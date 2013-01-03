using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MicroBSC.Biz.Common.Biz
{
    public class Biz_Com_Unit_Type_Info : MicroBSC.Biz.Common.Dac.Dac_Com_Unit_Type_Info
    {
        public IDataParameterCollection InsertData(string iunit_type, string iunit, string iformat_string, int idecimal_point, string irounding_type, string iuse_yn, int itxr_user)
        {
            IDataParameterCollection col = InsertData_Dac(iunit_type, iunit, iformat_string, idecimal_point, irounding_type, iuse_yn, itxr_user);
            return col;
        }

        public IDataParameterCollection UpdateData(int iunit_type_ref_id, string iunit_type, string iunit, string iformat_string, int idecimal_point, string irounding_type, string iuse_yn, int itxr_user)
        {
            IDataParameterCollection col = UpdateData_Dac(iunit_type_ref_id, iunit_type, iunit, iformat_string, idecimal_point, irounding_type, iuse_yn, itxr_user);
            return col;
        }

        public IDataParameterCollection DeleteData(int iunit_type_ref_id)
        { 
            IDataParameterCollection col = DeleteData_Dac(iunit_type_ref_id);
            return col;
        }

        public DataSet GetAllList()
        {
            DataSet ds = GetAllList_Dac();
            return ds;
        }

        public DataSet GetOneList(int iunit_type_ref_id)
        {
            DataSet ds = GetOneList_Dac(iunit_type_ref_id);
            return ds;
        }
    }
}
