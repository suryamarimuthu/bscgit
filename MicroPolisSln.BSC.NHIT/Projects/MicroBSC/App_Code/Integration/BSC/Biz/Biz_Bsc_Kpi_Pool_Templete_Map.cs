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
    public class Biz_Bsc_Kpi_Pool_Templete_Map
    {
        public Biz_Bsc_Kpi_Pool_Templete_Map() { }

        public string AddData_DB(string kpi_pool_templete_id
                                , string[] kpi_pool_ref_id_list
                                , DateTime create_date
                                , int create_user)
        {
            string reVal = string.Empty;

            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool_Templete_MAP dacBscKpiPoolTempleteMap = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool_Templete_MAP();

            affectedRow = dacBscKpiPoolTempleteMap.DeleteData_DB(conn
                                                    , trx
                                                    , kpi_pool_templete_id);

            try
            {
                foreach (string kpi_pool_ref_id in kpi_pool_ref_id_list)
                {

                    affectedRow = dacBscKpiPoolTempleteMap.InsertData_DB(conn
                                                    , trx
                                                    , kpi_pool_templete_id
                                                    , kpi_pool_ref_id
                                                    , create_date
                                                    , create_user);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                reVal = ex.Message;
                trx.Rollback();
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return reVal;

        }

        public DataTable GetBscKpiPoolTempleteMap_DB(string kpi_pool_templete_id)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool_Templete_MAP dacBscKpiPoolTempleteMap = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool_Templete_MAP();

            return dacBscKpiPoolTempleteMap.SelectData_DB(kpi_pool_templete_id);
        }
    }
}
