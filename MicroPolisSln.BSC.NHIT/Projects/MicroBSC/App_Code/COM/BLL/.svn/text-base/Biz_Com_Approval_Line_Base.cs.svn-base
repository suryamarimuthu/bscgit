using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.Data;
using MicroBSC.Biz.Common.Dac;

namespace MicroBSC.Biz.Common.Biz
{
    /// <summary>
    /// Biz_Com_Approval_Line_Base
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Com_Approval_Line_Base
    /// Class Func     : COM_APPROVAL_LINE_BASE Business Logic Class
    /// CREATE DATE    : 2008-08-20 오후 1:04:54
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Com_Approval_Line_Base  : Dac_Com_Approval_Line_Base
    {
        public Biz_Com_Approval_Line_Base() { }
        public Biz_Com_Approval_Line_Base(string ibiz_type, int iemp_ref_id) : base( ibiz_type,  iemp_ref_id) { }

        public int InsertData(IDbConnection con, IDbTransaction trx, string ibiz_type, int iemp_ref_id, int isort_order, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx, ibiz_type,  iemp_ref_id, isort_order, itxr_user);
        }

        public int UpdateData(IDbConnection con, IDbTransaction trx, string ibiz_type, int iemp_ref_id, int isort_order, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx, ibiz_type, iemp_ref_id, isort_order, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction trx, string ibiz_type, int iemp_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx, ibiz_type, iemp_ref_id, itxr_user);
        }

        /// <summary>
        /// 데이터 입력
        /// </summary>
        /// <param name="iDt"></param>
        /// <returns></returns>
        public bool InsertAllData(DataTable iDt)
        {
            int iRtn = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int iRow = iDt.Rows.Count;
            string iType = "";

            try
            {
                for (int i = 0; i < iRow; i++)
                {
                    iType             = iDt.Rows[i]["ITYPE"].ToString();
                    base.IBiz_Type    = iDt.Rows[i]["BIZ_TYPE"].ToString();
                    base.IEmp_Ref_Id  = int.Parse(iDt.Rows[i]["EMP_REF_ID"].ToString());
                    base.ISort_Order  = int.Parse(iDt.Rows[i]["SORT_ORDER"].ToString());
                    base.IUpdate_User = int.Parse(iDt.Rows[i]["TXR_USER"].ToString());

                    if (iType == "A" || iType == "U")
                    {
                        iRtn = base.UpdateData_Dac(conn, trx, base.IBiz_Type, base.IEmp_Ref_Id, base.ISort_Order, base.IUpdate_User);
                    }
                    else if (iType == "D")
                    {
                        iRtn = base.DeleteData_Dac(conn, trx, base.IBiz_Type, base.IEmp_Ref_Id, base.IUpdate_User);
                    }
                }
                trx.Commit();
                return true;
            }
            catch (Exception e)
            {
                trx.Rollback();
                base.Transaction_Message = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return true;
        }

        public DataTable GetAppEmpSchema()
        {
            DataTable rDt = new DataTable("COM_APPROVAL_LINE_BASE");
            rDt.Columns.Add("ITYPE", typeof(string));
            rDt.Columns.Add("BIZ_TYPE", typeof(string));
            rDt.Columns.Add("EMP_REF_ID", typeof(int));
            rDt.Columns.Add("SORT_ORDER", typeof(int));
            rDt.Columns.Add("TXR_USER", typeof(int));

            return rDt;
        }
    }
}