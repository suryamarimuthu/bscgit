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
/// Biz_Bsc_Map_Info에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Biz_Bsc_Map_Info Dac 클래스
/// Class 내용		@ Bsc_Map_Info Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.04.25
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Map_Info : MicroBSC.BSC.Dac.Dac_Bsc_Map_Info
    {
        public Biz_Bsc_Map_Info() { }

        public Biz_Bsc_Map_Info(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id)
               : base(iestterm_ref_id, iest_dept_ref_id, imap_version_id) { }
        
        public Biz_Bsc_Map_Info(int iestterm_ref_id, int iest_dept_ref_id, string iymd) 
               : base(iestterm_ref_id, iest_dept_ref_id, iymd) { }

        public int InsertData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user)
        { 
            return base.InsertData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, imap_version_name, idept_vision, imap_desc, ibscchampion_emp_id, iuse_yn, itxr_user);
        }

        public int UpdateData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user)
        { 
            return base.UpdateData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, imap_version_name, idept_vision, imap_desc, ibscchampion_emp_id, iuse_yn, itxr_user);
        }

        public int DeleteData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iuse_yn, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, iuse_yn, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, imap_version_name, idept_vision, imap_desc, ibscchampion_emp_id, iuse_yn, itxr_user);
        }

        public int UpdateData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, imap_version_name, idept_vision, imap_desc, ibscchampion_emp_id, iuse_yn, itxr_user);
        }

        public int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iuse_yn, int itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, iuse_yn, itxr_user);
        }

        /// <summary>
        /// 전략맵/전략맵 적용기간 저장
        /// </summary>
        /// <param name="iType">저장유형(입력/수정)</param>
        /// <param name="iestterm_ref_id">평가기간</param>
        /// <param name="iest_dept_ref_id">평가부서</param>
        /// <param name="imap_version_id">맵버젼ID</param>
        /// <param name="imap_version_name">맵버젼명</param>
        /// <param name="idept_vision">비젼</param>
        /// <param name="imap_desc">전략맵설명</param>
        /// <param name="ibscchampion_emp_id">BSC챔피언ID</param>
        /// <param name="iuse_yn">사용여부</param>
        /// <param name="itxr_user">처리자</param>
        /// <param name="iDtMapTerm">맵적용기간리스트</param>
        public void TxrMapInfo(string iType, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user, DataTable iDtMapTerm)
        {
            int intRow    = iDtMapTerm.Rows.Count;
            int intTxrCnt = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (iType == "A")
                {
                    intTxrCnt += base.InsertData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, imap_version_name, idept_vision, imap_desc, ibscchampion_emp_id, iuse_yn, itxr_user);
                }
                else if (iType == "U")
                {
                    intTxrCnt += base.UpdateData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, imap_version_name, idept_vision, imap_desc, ibscchampion_emp_id, iuse_yn, itxr_user);
                }
                else
                {
                    return;
                }

                if (base.Transaction_Result == "N")
                {
                    trx.Rollback();
                    return;
                }

                MicroBSC.BSC.Biz.Biz_Bsc_Map_Term objTerm = new Biz_Bsc_Map_Term();
                for (int i = 0; i < intRow; i++)
                {
                    objTerm.InsertData(conn, trx
                                      , int.Parse(iDtMapTerm.Rows[i]["ESTTERM_REF_ID"].ToString())
                                      , int.Parse(iDtMapTerm.Rows[i]["EST_DEPT_REF_ID"].ToString())
                                      , (iType=="A") ? base.Imap_version_id : int.Parse(iDtMapTerm.Rows[i]["MAP_VERSION_ID"].ToString())
                                      , iDtMapTerm.Rows[i]["YMD"].ToString()
                                      , int.Parse(iDtMapTerm.Rows[i]["TXR_USER"].ToString())
                                      );
                }


                base.Transaction_Message = "정상적으로 처리되었습니다.";
                trx.Commit();
            }
            catch (Exception e)
            {
                base.Transaction_Message = e.Message;
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return;
        }



        /// <summary>
        /// 전략맵 트리구성
        /// </summary>
        /// <param name="iTrvMap">트리</param>
        /// <param name="iEstTermRefID">평가기간</param>
        /// <param name="iEstDeptRefID">평가부서</param>
        public void DrawMapTree(TreeView iTrvMap, int iEstTermRefID, int iEstDeptRefID, int iMapVersionID, string iSelectedKey)
        {
            /* 수정작업 : 이천십일년 삼월 치릴
             * 수정작자 : 장동건
             * 수정내용 : BSC1004S1.ASPX 자화전자(성덕여왕 요청)
             *            측정주기 변경시 평가조직이 변경이 안됨
             *            조건변수를 두개로 날림
             *            */

            MicroBSC.Estimation.Dac.DeptInfos objDept = new MicroBSC.Estimation.Dac.DeptInfos(iEstDeptRefID);

            int cntRow = 0;
            int cntStg = 0;
            int cntKpi = 0;
            string strKey = "";
            string strVal = "";

            strKey = "D" + objDept.Dept_Ref_ID.ToString();
            strVal = objDept.Dept_Name + " 전략맵";
            TreeNode topNode = new TreeNode(strVal, strKey);

            iTrvMap.Nodes.Clear();
            iTrvMap.Nodes.Add(topNode);
            topNode.ImageUrl = "../images/stg/TREE_D.gif";

            TreeNode vNode;
            MicroBSC.BSC.Biz.Biz_Bsc_View_Info objView = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
            DataSet dsView = objView.GetAllList();

            TreeNode sNode;
            MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg objSTG = new Biz_Bsc_Map_Stg();
            DataSet dsSTG = new DataSet();

            TreeNode kNode;
            MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi objKPI = new Biz_Bsc_Map_Kpi();
            DataSet dsKPI = new DataSet();

            cntRow = dsView.Tables[0].Rows.Count;
            for (int i = 0; i < cntRow; i++)
            {
                strKey = "V" + dsView.Tables[0].Rows[i]["VIEW_REF_ID"].ToString();
                strVal = dsView.Tables[0].Rows[i]["VIEW_NAME"].ToString();
                vNode = new TreeNode(strVal, strKey);
                vNode.ImageUrl = "../images/stg/TREE_V.gif";
                topNode.ChildNodes.Add(vNode);

                if (iSelectedKey == strKey)
                {
                    vNode.Select();
                    vNode.ExpandAll();
                    vNode.SelectAction = TreeNodeSelectAction.Select;
                }

                dsSTG = objSTG.GetStrategyPerView(iEstTermRefID, iEstDeptRefID, iMapVersionID, int.Parse(dsView.Tables[0].Rows[i]["VIEW_REF_ID"].ToString()));
                cntStg = dsSTG.Tables[0].Rows.Count;

                for (int j = 0; j < cntStg; j++)
                {
                    strKey = "S" + dsSTG.Tables[0].Rows[j]["STG_REF_ID"].ToString();
                    strVal = dsSTG.Tables[0].Rows[j]["STG_NAME"].ToString();
                    sNode = new TreeNode(strVal, strKey);
                    sNode.ImageUrl = "../images/stg/TREE_S.gif";
                    vNode.ChildNodes.Add(sNode);

                    if (iSelectedKey == strKey)
                    {
                        sNode.Select();
                        sNode.ExpandAll();
                        sNode.SelectAction = TreeNodeSelectAction.Select;
                    }

                    dsKPI = objKPI.GetKpiListPerStg(iEstTermRefID, iEstDeptRefID, iMapVersionID, int.Parse(dsSTG.Tables[0].Rows[j]["STG_REF_ID"].ToString()));
                    cntKpi = dsKPI.Tables[0].Rows.Count;

                    for (int k = 0; k < cntKpi; k++)
                    {
                        strKey = "K" + dsKPI.Tables[0].Rows[k]["KPI_REF_ID"].ToString();
                        strVal = dsKPI.Tables[0].Rows[k]["KPI_NAME"].ToString();
                        kNode = new TreeNode(strVal, strKey);
                        kNode.ImageUrl = "../images/stg/TREE_K.gif";
                        sNode.ChildNodes.Add(kNode);

                        if (iSelectedKey == strKey)
                        {
                            kNode.Select();
                            kNode.ExpandAll();
                            kNode.SelectAction = TreeNodeSelectAction.Select;
                        }
                    }
                }
            }

            if (iTrvMap.SelectedNode == null)
            {
                topNode.Select();
            }

            iTrvMap.ExpandAll();
        }
    }
}