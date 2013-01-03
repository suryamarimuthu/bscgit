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
    public class Biz_Bsc_Work_Task : MicroBSC.BSC.Dac.Dac_Bsc_Work_Task 
    {
        private string strText = ":: 전체 ::";
        private string strValue = "";
        
        public Biz_Bsc_Work_Task() { }

        public Biz_Bsc_Work_Task(int iexec_ref_id, int itask_ref_id)
            : base(iexec_ref_id, itask_ref_id) { }

        public int InsertData(int iexec_ref_id, int itask_ref_id, string itask_name, string itask_desc, decimal itask_weight, DateTime itgt_str_date, DateTime itgt_end_date, decimal itgt_cost, DateTime irst_str_date, DateTime irst_end_date, decimal irst_cost, decimal ido_rate, string iadd_file, string iuse_yn, int itxr_user)
        {
            return base.InsertData_Dac( iexec_ref_id,  itask_ref_id,  itask_name,  itask_desc,  itask_weight,  itgt_str_date,  itgt_end_date,  itgt_cost,  irst_str_date,  irst_end_date,  irst_cost, ido_rate, iadd_file,  iuse_yn,  itxr_user);
        }

        public int UpdateData(int iexec_ref_id, int itask_ref_id, string itask_name, string itask_desc, decimal itask_weight, DateTime itgt_str_date, DateTime itgt_end_date, decimal itgt_cost, DateTime irst_str_date, DateTime irst_end_date, decimal irst_cost, decimal ido_rate, string iadd_file, string iuse_yn, int itxr_user)
        {
            return base.UpdateData_Dac(iexec_ref_id, itask_ref_id, itask_name, itask_desc, itask_weight, itgt_str_date, itgt_end_date, itgt_cost, irst_str_date, irst_end_date, irst_cost,ido_rate, iadd_file, iuse_yn, itxr_user);
        }

        public int DeleteData(int iexec_ref_id, int itask_ref_id, Int32 itxr_user)
        {
            return base.DeleteData_Dac(iexec_ref_id, itask_ref_id, itxr_user);
        }

        public int ReUsedData(int iexec_ref_id, int itask_ref_id, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(iexec_ref_id, itask_ref_id, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, string itask_name, string itask_desc, decimal itask_weight, DateTime itgt_str_date, DateTime itgt_end_date, decimal itgt_cost, DateTime irst_str_date, DateTime irst_end_date, decimal irst_cost, decimal ido_rate, string iadd_file, string iuse_yn, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx, iexec_ref_id, itask_ref_id, itask_name, itask_desc, itask_weight, itgt_str_date, itgt_end_date, itgt_cost, irst_str_date, irst_end_date, irst_cost, ido_rate,iadd_file, iuse_yn, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, string itask_name, string itask_desc, decimal itask_weight, DateTime itgt_str_date, DateTime itgt_end_date, decimal itgt_cost, DateTime irst_str_date, DateTime irst_end_date, decimal irst_cost, decimal ido_rate, string iadd_file, string iuse_yn, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, iexec_ref_id, itask_ref_id, itask_name, itask_desc, itask_weight, itgt_str_date, itgt_end_date, itgt_cost, irst_str_date, irst_end_date, irst_cost, ido_rate, iadd_file, iuse_yn, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, Int32 itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iexec_ref_id, itask_ref_id, itxr_user);
        }

        public int ReUsedData(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(conn, trx, iexec_ref_id, itask_ref_id, itxr_user);
        }


        private void fillDropDownList(int iExecRefId, DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            if (iddList.Equals(null))
            {

            }
            else
            {
                try
                {
                    DataSet rtnDs = base.GetTaskList(iExecRefId);
                    iddList.DataSource = rtnDs;
                    iddList.DataTextField = "TASK_NAME";
                    iddList.DataValueField = "TASK_REF_ID";
                    iddList.DataBind();
                    iddList.Width = (iWidth == -1) ? 120 : iWidth;

                    if (blnTotalYn)
                    {
                        iddList.Items.Insert(0, new ListItem(strText, strValue));
                    }

                    iddList.SelectedIndex = defaultIndex;
                }
                catch
                {

                }
            }
        }

 
        public void GetTaskList(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth, int iExecRefId)
        {
            fillDropDownList(iExecRefId, iddList, defaultIndex, blnTotalYn, iWidth);
        }

    }
}