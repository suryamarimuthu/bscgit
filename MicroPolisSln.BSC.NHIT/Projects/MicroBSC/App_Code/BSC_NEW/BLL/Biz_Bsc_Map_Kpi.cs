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
/// Biz_Bsc_Map_Kpi에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Biz_Bsc_Map_Kpi Biz 클래스
/// Class 내용		@ Bsc_Map_Kpi Biz 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.06.19
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------

namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Map_Kpi : MicroBSC.BSC.Dac.Dac_Bsc_Map_Kpi
    {
        public Biz_Bsc_Map_Kpi() { }
        public Biz_Bsc_Map_Kpi(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id)
            : base(iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, ikpi_ref_id) { }


        public int InsertData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, double iweight, int isort_order, int itxr_user)
        { 
            return base.InsertData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, ikpi_ref_id, iweight, isort_order, itxr_user);
        }


        public int UpdateData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, double iweight, int isort_order, int itxr_user)
        { 
            return base.UpdateData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, ikpi_ref_id, iweight, isort_order, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, ikpi_ref_id, itxr_user);
        }

        public int DeleteKpiPerStgData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int itxr_user)
        {
            return base.DeleteKpiPerStgData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, double iweight, int isort_order, string imap_kpi_type, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, ikpi_ref_id, iweight, isort_order, imap_kpi_type, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, double iweight, int isort_order, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, ikpi_ref_id, iweight, isort_order, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, ikpi_ref_id, itxr_user);
        }

        public int DeleteKpiPerStgData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int itxr_user)
        {
            return base.DeleteKpiPerStgData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, itxr_user);
        }

        public bool TxrAllBscMapKpi(DataTable iDT)
        {
            int intRow         = iDT.Rows.Count;
            int intTxrCnt      = 0;

            

            

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < intRow; i++)
                {
                    string iTYPE = iDT.Rows[i]["ITYPE"].ToString();

                    int intESTTERM_REF_ID = DataTypeUtility.GetToInt32(iDT.Rows[i]["ESTTERM_REF_ID"]);
                    int intEST_DEPT_REF_ID = DataTypeUtility.GetToInt32(iDT.Rows[i]["EST_DEPT_REF_ID"]);
                    int intMAP_VERSION_ID = DataTypeUtility.GetToInt32(iDT.Rows[i]["MAP_VERSION_ID"]);
                    int intSTG_REF_ID = DataTypeUtility.GetToInt32(iDT.Rows[i]["STG_REF_ID"]);
                    int intKPI_REF_ID = DataTypeUtility.GetToInt32(iDT.Rows[i]["KPI_REF_ID"]);
                    int intTXR_USER = DataTypeUtility.GetToInt32(iDT.Rows[i]["TXR_USER"]);
                    int intSORT_ORDER = DataTypeUtility.GetToInt32(iDT.Rows[0]["SORT_ORDER"]);
                    double dblWEIGHT = DataTypeUtility.GetToDouble(iDT.Rows[i]["WEIGHT"]);
                    string strMAP_KPI_TYPE = DataTypeUtility.GetString(iDT.Rows[i]["MAP_KPI_TYPE"]);

                    if (iTYPE == "D")
                    {
                        intTxrCnt = this.DeleteData(conn
                                      , trx
                                      , intESTTERM_REF_ID
                                      , intEST_DEPT_REF_ID
                                      , intMAP_VERSION_ID
                                      , intSTG_REF_ID
                                      , intKPI_REF_ID
                                      , intTXR_USER
                                        );
                    }
                    else if (iTYPE == "U")
                    {
                        //map_kpi_type 업데이트 문제로 프로시져에서 integration으로 분리
                        MicroBSC.Integration.BSC.Dac.Dac_Bsc_Map_Kpi dacBscMapKpi = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Map_Kpi();
                        intTxrCnt = dacBscMapKpi.Update_DB(conn, trx
                                                        , intESTTERM_REF_ID
                                                        , intEST_DEPT_REF_ID
                                                        , intMAP_VERSION_ID
                                                        , intSTG_REF_ID
                                                        , intKPI_REF_ID
                                                        , dblWEIGHT
                                                        , intSORT_ORDER
                                                        , strMAP_KPI_TYPE
                                                        , intTXR_USER);
                        if (intTxrCnt == 0)
                        {
                            intTxrCnt = dacBscMapKpi.Insert_DB(conn, trx
                                                            , intESTTERM_REF_ID
                                                            , intEST_DEPT_REF_ID
                                                            , intMAP_VERSION_ID
                                                            , intSTG_REF_ID
                                                            , intKPI_REF_ID
                                                            , dblWEIGHT
                                                            , intSORT_ORDER
                                                            , strMAP_KPI_TYPE
                                                            , intTXR_USER);
                        }
                        //intTxrCnt = this.UpdateData(intESTTERM_REF_ID
                        //                          , intEST_DEPT_REF_ID
                        //                          , intMAP_VERSION_ID
                        //                          , intSTG_REF_ID
                        //                          , intKPI_REF_ID
                        //                          , dblWEIGHT
                        //                          , intSORT_ORDER
                        //                          , intTXR_USER);
                    }
                    else
                    {
                        DataTable dtBscMapKpi = this.GetOneList_DB(intESTTERM_REF_ID
                                                                  , intEST_DEPT_REF_ID
                                                                  , intMAP_VERSION_ID
                                                                  , intSTG_REF_ID
                                                                  , 0).Tables[0];

                        int sort_order = 0;

                        if (dtBscMapKpi.Rows.Count > 0)
                        {
                            sort_order = DataTypeUtility.GetToInt32(dtBscMapKpi.Rows[0]["SORT_ORDER"]) + 1;
                        }

                        
                        intTxrCnt = this.InsertData_DB(conn
                                              , trx
                                              , int.Parse(iDT.Rows[i]["ESTTERM_REF_ID"].ToString())
                                              , int.Parse(iDT.Rows[i]["EST_DEPT_REF_ID"].ToString())
                                              , int.Parse(iDT.Rows[i]["MAP_VERSION_ID"].ToString())
                                              , int.Parse(iDT.Rows[i]["STG_REF_ID"].ToString())
                                              , int.Parse(iDT.Rows[i]["KPI_REF_ID"].ToString())
                                              , double.Parse(iDT.Rows[i]["WEIGHT"].ToString())
                                              , sort_order
                                              , iDT.Rows[i]["MAP_KPI_TYPE"].ToString()
                                              , int.Parse(iDT.Rows[i]["TXR_USER"].ToString())
                                                );
                    }

                }

                base.Transaction_Message = "정상적으로 처리되었습니다.";
                base.Transaction_Result  = "Y";
                trx.Commit();
            }
            catch (Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result  = "N";
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }
    }
}