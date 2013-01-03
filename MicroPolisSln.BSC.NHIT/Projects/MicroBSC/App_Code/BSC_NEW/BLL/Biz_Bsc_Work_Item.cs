using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;


/// <summary>
/// Biz_Bsc_Work_Exec의 요약 설명입니다.
/// </summary>
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Work_Item : MicroBSC.BSC.Dac.Dac_Bsc_Work_Item 
    {
        public Biz_Bsc_Work_Item() { }

        public Biz_Bsc_Work_Item(int iexec_ref_id, int itask_ref_id, int iitem_ref_id)
            : base(iexec_ref_id, itask_ref_id, iitem_ref_id) { }

        public int InsertData(int iexec_ref_id, int itask_ref_id, int iitem_ref_id, string iitem_ymd, string iitem_name, string iitem_desc, string iitem_unit, string iitem_tgt, string iitem_rst, string iadd_file, string iuse_yn, int itxr_user)
        {
            return base.InsertData_Dac(iexec_ref_id,  itask_ref_id,  iitem_ref_id,  iitem_ymd,  iitem_name,  iitem_desc,  iitem_unit,  iitem_tgt,  iitem_rst,  iadd_file,  iuse_yn,  itxr_user);
        }

        public int UpdateData(int iexec_ref_id, int itask_ref_id, int iitem_ref_id, string iitem_ymd, string iitem_name, string iitem_desc, string iitem_unit, string iitem_tgt, string iitem_rst, string iadd_file, string iuse_yn, int itxr_user)
        {
            return base.UpdateData_Dac(iexec_ref_id, itask_ref_id, iitem_ref_id, iitem_ymd, iitem_name, iitem_desc, iitem_unit, iitem_tgt, iitem_rst, iadd_file, iuse_yn, itxr_user);
        }

        public int DeleteData(int iexec_ref_id, int itask_ref_id, int iitem_ref_id, Int32 itxr_user)
        {
            return base.DeleteData_Dac(iexec_ref_id, itask_ref_id, iitem_ref_id, itxr_user);
        }

        public int ReUsedData(int iexec_ref_id, int itask_ref_id, int iitem_ref_id, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(iexec_ref_id, itask_ref_id, iitem_ref_id, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, int iitem_ref_id, string iitem_ymd, string iitem_name, string iitem_desc, string iitem_unit, string iitem_tgt, string iitem_rst, string iadd_file, string iuse_yn, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx, iexec_ref_id, itask_ref_id, iitem_ref_id, iitem_ymd, iitem_name, iitem_desc, iitem_unit, iitem_tgt, iitem_rst, iadd_file, iuse_yn, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, int iitem_ref_id, string iitem_ymd, string iitem_name, string iitem_desc, string iitem_unit, string iitem_tgt, string iitem_rst, string iadd_file, string iuse_yn, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, iexec_ref_id, itask_ref_id, iitem_ref_id, iitem_ymd, iitem_name, iitem_desc, iitem_unit, iitem_tgt, iitem_rst, iadd_file, iuse_yn, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, int iitem_ref_id, Int32 itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iexec_ref_id, itask_ref_id, iitem_ref_id, itxr_user);
        }

        public int ReUsedData(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, int iitem_ref_id, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(conn, trx, iexec_ref_id, itask_ref_id, iitem_ref_id, itxr_user);
        }

    }
}