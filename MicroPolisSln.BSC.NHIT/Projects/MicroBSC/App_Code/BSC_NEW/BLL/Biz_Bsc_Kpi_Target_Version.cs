using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Kpi_Target_Version : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Target_Version
    {
        public Biz_Bsc_Kpi_Target_Version()
        { 
        
        }

        public Biz_Bsc_Kpi_Target_Version(int iestterm_ref_id, int ikpi_ref_id, int _ikpi_target_version_id)
            : base(iestterm_ref_id, ikpi_ref_id, _ikpi_target_version_id)
        { 
            
        }

        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iversion_name, string iversion_desc, int iversion_number, int iupdate_term, string iuse_yn, int itxr_user)
        {
            int affectedRow = base.InsertData_Dac(iestterm_ref_id, ikpi_ref_id,  ikpi_target_version_id, iversion_name, iversion_desc, 
                                                  iversion_number, iupdate_term, iuse_yn, itxr_user);
            return affectedRow;
        }

        public int UpdateData(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iversion_name, string iversion_desc, int iversion_number, int iupdate_term, string iuse_yn, int itxr_user)
        {
            int affectedRow = base.UpdateData_Dac(iestterm_ref_id, ikpi_ref_id,  ikpi_target_version_id, iversion_name, iversion_desc,
                                                  iversion_number, iupdate_term, iuse_yn, itxr_user);
            return affectedRow;
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, int itxr_user)
        { 
            int affectedRow = base.DeleteData_Dac(iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id, itxr_user);
            return affectedRow;
        }
    }
}
