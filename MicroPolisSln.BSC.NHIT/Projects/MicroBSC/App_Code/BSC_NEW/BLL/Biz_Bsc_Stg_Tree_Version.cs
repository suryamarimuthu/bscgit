using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.BSC.Dac;
using MicroBSC.Data;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Stg_Tree_Version
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Stg_Tree_Version
    /// Class Func     : BSC_STG_TREE_VERSION Business Logic Class
    /// CREATE DATE    : 2008-12-12 오후 6:00:23
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Stg_Tree_Version  : Dac_Bsc_Stg_Tree_Version
    {
        public Biz_Bsc_Stg_Tree_Version() { }
        public Biz_Bsc_Stg_Tree_Version(int iestterm_ref_id, int iversion_ref_id) : base(iestterm_ref_id,  iversion_ref_id) { }
		
        public int InsertData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, string iversion_name, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx,  iestterm_ref_id,  iversion_ref_id,  iversion_name, itxr_user);
        }
		
        public int UpdateData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, string iversion_name, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx,  iestterm_ref_id,  iversion_ref_id,  iversion_name, itxr_user);
        }
		
        public int DeleteData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx,  iestterm_ref_id,  iversion_ref_id, itxr_user);
        }

        public int InsertData(int iestterm_ref_id, int iversion_ref_id, string iversion_name, int itxr_user)
        {
            IDbConnection con = DbAgentHelper.CreateDbConnection();
            con.Open();
            IDbTransaction trx = con.BeginTransaction();

            return this.InsertData(con, trx, iestterm_ref_id, iversion_ref_id, iversion_name, itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int iversion_ref_id, string iversion_name, int itxr_user)
        {
            IDbConnection con = DbAgentHelper.CreateDbConnection();
            con.Open();
            IDbTransaction trx = con.BeginTransaction();

            return this.UpdateData(con, trx, iestterm_ref_id, iversion_ref_id, iversion_name, itxr_user) ;
        }

        public int DeleteData(int iestterm_ref_id, int iversion_ref_id, int itxr_user)
        {
            IDbConnection con = DbAgentHelper.CreateDbConnection();
            con.Open();
            IDbTransaction trx = con.BeginTransaction();

            return this.DeleteData(con, trx, iestterm_ref_id, iversion_ref_id, itxr_user);
        }

        public int TrxVersionAndTerm(string iType, int iestterm_ref_id, int iversion_ref_id, string iversion_name, int itxr_user, DataTable dtVerTerm)
        {
            int iAffRow = 0;
            int iRow    = 0;
            IDbConnection con = DbAgentHelper.CreateDbConnection();
            con.Open();
            IDbTransaction trx = con.BeginTransaction();

            try
            {
                if (iType == "A")
                {
                    iAffRow = this.InsertData(con, trx, iestterm_ref_id, iversion_ref_id, iversion_name, itxr_user);
                }
                else if (iType == "U")
                {
                    iAffRow = this.UpdateData(con, trx, iestterm_ref_id, iversion_ref_id, iversion_name, itxr_user);
                }
                else if (iType == "D")
                {
                    iAffRow = this.DeleteData(con, trx, iestterm_ref_id, iversion_ref_id, itxr_user);
                    Biz_Bsc_Stg_Tree objSTree = new Biz_Bsc_Stg_Tree();
                    Biz_Bsc_Stg_Tree_Term objSTerm = new Biz_Bsc_Stg_Tree_Term();

                    iAffRow = objSTree.DeleteData(con, trx, iestterm_ref_id, iversion_ref_id, itxr_user);
                    iAffRow = objSTerm.DeleteData(con, trx, iestterm_ref_id, iversion_ref_id, itxr_user);
                }

                if (iType=="A" || iType == "U")
                {
                    iRow = dtVerTerm.Rows.Count;
                    if (base.Transaction_Result == "Y")
                    {
                        Biz_Bsc_Stg_Tree_Term objTerm = new Biz_Bsc_Stg_Tree_Term();
                        for (int i = 0; i < iRow; i++)
                        {
                            objTerm.IEstterm_Ref_Id = base.IEstterm_Ref_Id;
                            objTerm.IVersion_Ref_Id = base.IVersion_Ref_Id;
                            objTerm.IYmd            = dtVerTerm.Rows[i]["YMD"].ToString();
                            iAffRow += objTerm.UpdateData(con, trx, objTerm.IEstterm_Ref_Id, objTerm.IVersion_Ref_Id, objTerm.IYmd, itxr_user);
                        }
                    }
                }

                trx.Commit();
            }
            catch (Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result  = "N";
                trx.Rollback();
            }
            finally
            {
                con.Close();
            }

            return iAffRow;
        }
	}
}