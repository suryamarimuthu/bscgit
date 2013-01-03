using System;
using System.Web;
using System.Data;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    /// <summary>
    /// Dac_ctl_ctl3100에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_ctl_ctl3100 Dac 클래스
    /// Class 내용		: PositionGrp 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.05.24
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_ctl_ctl3100 : DbAgentBase
    {
        public DataSet GetTopMenuInfo()
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT                          \n");
            sbQuery.Append("       MENU_REF_ID          ,   \n");
            sbQuery.Append("       UP_MENU_ID           ,   \n");
            sbQuery.Append("       MENU_NAME            ,   \n");
            sbQuery.Append("       MENU_DIR             ,   \n");
            sbQuery.Append("       MENU_PAGE_NAME       ,   \n");
            sbQuery.Append("       MENU_PARAM           ,   \n");
            sbQuery.Append("       MENU_FULL_PATH       ,   \n");
            sbQuery.Append("       MENU_DESC            ,   \n");
            sbQuery.Append("       MENU_PRIORITY        ,   \n");
            sbQuery.Append("       MENU_TYPE            ,   \n");
            sbQuery.Append("       MENU_NAME_IMAGE_PATH ,   \n");
            sbQuery.Append("       MENU_PREV_ICON_PATH  ,   \n");
            sbQuery.Append("       MENU_CREATE_DATE         \n");
            sbQuery.Append("  FROM COM_MENU_INFO            \n");
            sbQuery.Append(" WHERE MENU_TYPE = 'T'          \n");
            sbQuery.Append(" ORDER BY                       \n");
            sbQuery.Append("       MENU_PRIORITY            \n");

            return DbAgentObj.Fill(sbQuery.ToString());
        }

        public DataSet GetMenuInfo(int aiUpRefID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT                          \n");
            sbQuery.Append("       MENU_REF_ID          ,   \n");
            sbQuery.Append("       UP_MENU_ID           ,   \n");
            sbQuery.Append("       MENU_NAME            ,   \n");
            sbQuery.Append("       MENU_DIR             ,   \n");
            sbQuery.Append("       MENU_PAGE_NAME       ,   \n");
            sbQuery.Append("       MENU_PARAM           ,   \n");
            sbQuery.Append("       MENU_FULL_PATH       ,   \n");
            sbQuery.Append("       MENU_DESC            ,   \n");
            sbQuery.Append("       MENU_PRIORITY        ,   \n");
            sbQuery.Append("       MENU_TYPE            ,   \n");
            sbQuery.Append("       MENU_NAME_IMAGE_PATH ,   \n");
            sbQuery.Append("       MENU_PREV_ICON_PATH  ,   \n");
            sbQuery.Append("       MENU_CREATE_DATE         \n");
            sbQuery.Append("  FROM COM_MENU_INFO            \n");
            sbQuery.Append(" WHERE 1=1                      \n");
            sbQuery.Append("   AND UP_MENU_ID = @UP_MENU_ID \n");
            sbQuery.Append(" ORDER BY                       \n");
            sbQuery.Append("       MENU_PRIORITY            \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@UP_MENU_ID",     SqlDbType.Int);

            paramArray[0].Value = aiUpRefID;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray); 
        }

        public DataSet GetMenuInfo()
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT MENU_REF_ID      ,               \n");
            sbQuery.Append("       UP_MENU_ID       ,               \n");
            sbQuery.Append("       MENU_NAME        ,               \n");
            sbQuery.Append("       MENU_DIR         ,               \n");
            sbQuery.Append("       MENU_PAGE_NAME   ,               \n");
            sbQuery.Append("       MENU_PARAM       ,               \n");
            sbQuery.Append("       MENU_FULL_PATH   ,               \n");
            sbQuery.Append("       MENU_DESC        ,               \n");
            sbQuery.Append("       MENU_PRIORITY    ,               \n");
            sbQuery.Append("       MENU_TYPE        ,               \n");
            sbQuery.Append("       MENU_NAME_IMAGE_PATH ,           \n");
            sbQuery.Append("       MENU_PREV_ICON_PATH  ,           \n");
            sbQuery.Append("       MENU_CREATE_DATE     ,           \n");
            sbQuery.Append("       CASE MENU_TYPE WHEN 'T' THEN 1   \n");
            sbQuery.Append("                      WHEN 'M' THEN 2   \n");
            sbQuery.Append("                      WHEN 'S' THEN 3   \n");
            sbQuery.Append("                      ELSE 4            \n");
            sbQuery.Append("       END V_ORDER                      \n");
            sbQuery.Append("  FROM COM_MENU_INFO                    \n");
            sbQuery.Append(" ORDER BY                               \n");
            sbQuery.Append("       V_ORDER      ,                   \n");
            sbQuery.Append("       MENU_PRIORITY                    \n");

            return DbAgentObj.Fill(sbQuery.ToString());
        }
    }
}
