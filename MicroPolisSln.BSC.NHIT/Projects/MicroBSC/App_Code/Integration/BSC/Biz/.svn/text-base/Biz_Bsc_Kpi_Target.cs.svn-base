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
/// Biz_Bsc_Kpi_Term의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Kpi_Info Biz 클래스
/// Class 내용		: Bsc_Kpi_Info Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 방병현
/// 최초작성일		: 2007.04.26
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
/// 
namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Kpi_Target : MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target
    {
        public Biz_Bsc_Kpi_Target() { }

        public DataTable GetBscKpiTargetGoalTong_DB(int estterm_ref_id
                                              , int kpi_ref_id
                                              , string ymd)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target dacBscKpiTarget = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target();
            return dacBscKpiTarget.Select_DB(estterm_ref_id, kpi_ref_id, ymd).Tables[0];
        }

        public DataTable GetBscKpiTargetGoalTongMM_DB(int estterm_ref_id
                                              , int kpi_ref_id
                                              , string ymd)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target dacBscKpiTarget = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target();
            return dacBscKpiTarget.SelectMM_DB(estterm_ref_id, kpi_ref_id, ymd).Tables[0];
        }

        public int ModifyData(int iestterm_ref_id
                            , int ikpi_ref_id
                            , int ikpi_target_version_id
                            , string iymd
                            , double itarget_ms
                            , double itarget_ts
                            , int itxr_user)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                    affectedRow += UpdateData_DB(conn
                                                , trx
                                                , iestterm_ref_id
                                                , ikpi_ref_id
                                                , ikpi_target_version_id
                                                , iymd
                                                , itarget_ms
                                                , itarget_ts
                                                , itxr_user);

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return affectedRow;

        }


        public int ModifyData(DataTable dt)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    affectedRow += UpdateData_DB(conn
                                                , trx
                                                , dataRow["ESTTERM_REF_ID"]
                                                , dataRow["KPI_REF_ID"]
                                                , dataRow["TARGET_VERSION_ID"]
                                                , dataRow["YMD"]
                                                , dataRow["TARGET_MS"]
                                                , dataRow["TARGET_TS"]
                                                , dataRow["UPDATE_USER"]);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                affectedRow = 0;
            }
            finally
            {
                conn.Close();
            }

            return affectedRow;
        }

    }
}
