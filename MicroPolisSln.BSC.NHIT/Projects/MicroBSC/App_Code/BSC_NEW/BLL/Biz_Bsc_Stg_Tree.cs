using System;
using System.Web;
using System.Data;
using System.Text;
using System.Collections;
using System.Transactions;

using MicroBSC.BSC.Dac;
using MicroBSC.Data;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Stg_Tree
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Stg_Tree
    /// Class Func     : BSC_STG_TREE Business Logic Class
    /// CREATE DATE    : 2008-12-12 오후 5:09:10
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Stg_Tree  : Dac_Bsc_Stg_Tree
    {
        private bool m_bIsFirst;
        public Biz_Bsc_Stg_Tree() { }
        public Biz_Bsc_Stg_Tree(decimal iidx) : base( iidx) { }
		
        public int InsertData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, int istg_ref_id, decimal iparent_idx, int isort_order, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx,  iestterm_ref_id,  iversion_ref_id,  istg_ref_id,  iparent_idx,  isort_order, itxr_user);
        }
		
        public int UpdateData(IDbConnection con, IDbTransaction trx, decimal iidx, int iestterm_ref_id, int iversion_ref_id, int istg_ref_id, decimal iparent_idx, int isort_order, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx,  iidx,  iestterm_ref_id,  iversion_ref_id,  istg_ref_id,  iparent_idx,  isort_order, itxr_user);
        }
		
        public int DeleteData(IDbConnection con, IDbTransaction trx, decimal iidx, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx,  iidx, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(con, trx, iestterm_ref_id, iversion_ref_id, itxr_user);
        }

        public int DeleteMultiNode(decimal[] arrIdx, int itxr_user)
        {
            IDbConnection con = DbAgentHelper.CreateDbConnection();
            con.Open();
            IDbTransaction trx = con.BeginTransaction();

            int iRtn = 0;
            try
            {
                for (int i = 0; i < arrIdx.Length; i++)
                {
                    iRtn += this.DeleteData(con, trx, arrIdx[i], itxr_user);
                }
                trx.Commit();
            }
            catch (Exception e)
            {
                trx.Rollback();
                base.Transaction_Message = e.Message;
            }
            finally
            {
                con.Close();
            }

            return iRtn;
        }

        /// <summary>
        /// 전략관계트리 조회
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간</param>
        /// <param name="iversion_ref_id">관계버젼</param>
        /// <returns></returns>
        public DataTable GetStgTree(int iestterm_ref_id, int iversion_ref_id)
        {
            DataSet rDs = base.GetAllList(iestterm_ref_id, iversion_ref_id);
            if (rDs.Tables.Count < 1)
            {
                return null;
            }
            else
            {
                Stack stTree = new Stack();
                DataTable dtOTree = rDs.Tables[0].Clone();
                
                m_bIsFirst = true;
                this.MakeTreeCollection(rDs.Tables[0], stTree, dtOTree);
                return dtOTree;
            }
        }
        /// <summary>
        /// 트리구성 재귀함수
        /// </summary>
        /// <param name="pDt">전략관계 테이블</param>
        /// <param name="pSt">스텍</param>
        /// <param name="oDt">정렬된 테이블</param>
        /// <returns></returns>
        public DataTable MakeTreeCollection(DataTable pDt, Stack pSt, DataTable oDt)
        {
            if (m_bIsFirst)
            {
                DataRow[] arrDr = pDt.Select("PARENT_IDX=0", "SORT_ORDER DESC");
                for (int i = 0; i < arrDr.Length; i++)
                {
                    pSt.Push(arrDr[i]["IDX"].ToString());
                }
            }
            else
            {
                string sIdx      = (string)pSt.Pop();
                string sFltSelf  = "IDX=" + sIdx;
                string sFltChild = "PARENT_IDX=" + sIdx;
                DataRow[] arrDrSelf  = pDt.Select(sFltSelf,  "SORT_ORDER ASC"); // 자식노드
                DataRow[] arrDrChild = pDt.Select(sFltChild, "SORT_ORDER DESC"); // 자식노드

                DataRow drSt;

                for (int i = 0; i < arrDrSelf.Length; i++)
                {
                    drSt = oDt.NewRow();
                    for (int j = 0; j < arrDrSelf[i].Table.Columns.Count; j++)
                    {
                        drSt[j] = arrDrSelf[i][j];
                    }
                    oDt.Rows.Add(drSt);
                }

                for (int i = 0; i < arrDrChild.Length; i++)
                {
                    pSt.Push(arrDrChild[i]["IDX"].ToString());
                }
            }

            m_bIsFirst = false;
            if (pSt.Count > 0)
            {
                MakeTreeCollection(pDt, pSt, oDt);
            }
            else
            {
                return oDt;
            }

            return oDt;
        }
    }
}