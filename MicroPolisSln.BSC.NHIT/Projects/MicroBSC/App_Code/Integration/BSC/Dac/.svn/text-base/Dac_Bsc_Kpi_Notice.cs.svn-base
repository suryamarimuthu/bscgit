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

using MicroBSC.Integration.COM.Dac;
using MicroBSC.Integration.BSC.Dac;
using MicroBSC.Data;

/// <summary>
/// Dac_Bsc_Kpi_Notice의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Dac_Bsc_Kpi_Notice
/// Class 내용		: Dac_Bsc_Kpi_Notice Db 처리 
/// 작성자			: 심민섭    
/// 최초작성일		: 2012.09.28
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
/// 
namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Notice : DbAgentBase
    {
        public Dac_Bsc_Kpi_Notice()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable SelectNoticeAll(string title)
        {
            string query = @" SELECT CN.NOTICE_REF_ID 
                       , CN.ESTTERM_REF_ID
                       , CN.YMD           
                       , CN.TITLE         
                       , CN.DETAILS       
                       , CN.READ_COUNT    
                       , CN.ATTACH_NO     
                       , CN.NOTICE_FROM   
                       , CN.NOTICE_TO     
                       , CN.SHOW_POP_UP   
                       , CN.ISDELETE   
                       , CE.EMP_NAME as OWNER_NAME   
                       , CN.CREATE_USER   
                       , CN.CREATE_DATE   
                       , CN.UPDATE_USER   
                       , CN.UPDATE_DATE   
                   FROM BSC_COMMUNICATION_NOTICE CN
                        LEFT JOIN COM_EMP_INFO CE
                          ON CN.CREATE_USER = CE.EMP_REF_ID
                  WHERE CN.ISDELETE = 'N' 
                  AND (CN.TITLE LIKE '%' + @TITLE + '%' OR  @TITLE ='') 
                  ORDER BY CN.CREATE_DATE DESC";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@TITLE", SqlDbType.VarChar);
            paramArray[0].Value = title;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_NOTICE_ALL", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }
    }
}
