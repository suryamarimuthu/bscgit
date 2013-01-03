using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.BSC.Dac;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Stg_Tree_Term
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Stg_Tree_Term
    /// Class Func     : BSC_STG_TREE_TERM Business Logic Class
    /// CREATE DATE    : 2008-12-12 오후 5:19:18
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Stg_Tree_Term  : Dac_Bsc_Stg_Tree_Term
    {
        public Biz_Bsc_Stg_Tree_Term() { }
        public Biz_Bsc_Stg_Tree_Term(int iestterm_ref_id, string iymd) : base( iestterm_ref_id,  iymd) { }
		
        public int InsertData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, string iymd, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx,  iestterm_ref_id,  iversion_ref_id,  iymd, itxr_user);
        }
		
        public int UpdateData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, string iymd, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx,  iestterm_ref_id,  iversion_ref_id,  iymd, itxr_user);
        }
		
        public int DeleteData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, string iymd, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx,  iestterm_ref_id,  iversion_ref_id,  iymd, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(con, trx, iestterm_ref_id, iversion_ref_id, itxr_user);
        }

        public DataTable GetSchemaStgTreeTerm()
        {
            DataTable dtTerm = new DataTable("BSC_STG_TREE_TERM");
            dtTerm.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dtTerm.Columns.Add("VERSION_REF_ID", typeof(int));
            dtTerm.Columns.Add("YMD", typeof(string));

            return dtTerm;
        }
	}
}