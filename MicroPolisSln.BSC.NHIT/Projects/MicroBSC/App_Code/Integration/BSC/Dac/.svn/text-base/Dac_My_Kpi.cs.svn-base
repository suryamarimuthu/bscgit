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
/// Dac_My_Kpi에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_My_Kpi Dac 클래스
/// Class 내용		@ My_kpi Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 서대원    
/// 최초작성일		@ 2012.09.14
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
///
namespace MicroBSC.Integration.BSC.Dac
{

    public class Dac_My_Kpi : DbAgentBase
    {
        public Dac_My_Kpi()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region 멀티 db 작업

        public DataTable  SelectCurrentYYYYMM()
        {
            string query = @"
select max(ymd)
  from bsc_term_detail
where ymd <= to_char(sysdate, 'yyyymm')
   and close_yn = 'Y' 
";
            DataTable dt = DbAgentObj.FillDataSet(query, "CURRENT_YYYYMM", null, null, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectMyMboKpi(object estterm_ref_id, object ymd, object loginid)
        {
            string query = @"
SELECT 
    A.EMP_REF_ID, 
    A.EMP_NAME, 
    B.DEPT_REF_ID, 
    C.DEPT_NAME AS DEPT_NAME,
    MB.KPI_REF_ID, 
    KP.KPI_NAME,  
    MW.WEIGHT,
    BS.YMD, 
    BS.THRESHOLD_REF_ID_MS AS CUR_SIG_ID,   
    BC1.IMAGE_FILE_NAME AS CUR_IMAGE,
    BS.THRESHOLD_REF_ID_TS AS TO_SIG_ID,
    BC2.IMAGE_FILE_NAME AS TO_IMAGE,
    BS.POINTS_MS AS CUR_POINT, 
    BS.POINTS_TS AS TO_POINT
FROM    COM_EMP_INFO  A
        LEFT  JOIN REL_DEPT_EMP  B   
            ON B.EMP_REF_ID  = A.EMP_REF_ID
        LEFT  JOIN COM_DEPT_INFO C   
            ON C.DEPT_REF_ID = B.DEPT_REF_ID
        INNER JOIN BSC_MBO_KPI_CLASSIFICATION MB   
            ON MB.ESTTERM_REF_ID = @ESTTERM_REF_ID AND 
               MB.EMP_REF_ID =  A.EMP_REF_ID
        LEFT  JOIN BSC_MBO_KPI_WEIGHT MW  
            ON MW.ESTTERM_REF_ID = MB.ESTTERM_REF_ID AND 
               MW.EMP_REF_ID = MB.EMP_REF_ID AND 
               MW.KPI_REF_ID = MB.KPI_REF_ID AND 
               MW.USE_YN = 'Y'
        INNER JOIN BSC_KPI_INFO BI     
            ON MB.ESTTERM_REF_ID = BI.ESTTERM_REF_ID  AND 
               MB.KPI_REF_ID = BI.KPI_REF_ID  AND 
               BI.USE_YN = 'Y'
        LEFT  JOIN BSC_KPI_POOL KP    
            ON BI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
        LEFT  JOIN BSC_KPI_SCORE BS  
            ON BS.ESTTERM_REF_ID = MB.ESTTERM_REF_ID AND 
               BS.KPI_REF_ID = MB.KPI_REF_ID
        LEFT  JOIN BSC_THRESHOLD_CODE BC1 
            ON BC1.THRESHOLD_REF_ID = BS.THRESHOLD_REF_ID_MS
        LEFT  JOIN BSC_THRESHOLD_CODE BC2 
            ON BC2.THRESHOLD_REF_ID = BS.THRESHOLD_REF_ID_TS         
WHERE BS.YMD = @YMD  
  AND A.LOGINID = @LOGINID
  AND ROWNUM <= 5";
       
       

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@LOGINID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = ymd;
            paramArray[2].Value = loginid;

            DataTable dt = DbAgentObj.FillDataSet(query, "MY_MBO_KPI", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectMyTeamKpi(object estterm_ref_id, object ymd, object loginid)
        {
            string query = @"
SELECT 
    A.EMP_REF_ID, 
    A.EMP_NAME, 
    B.DEPT_REF_ID, 
    C.DEPT_NAME AS DEPT_NAME,
    DA.ESTTERM_REF_ID, 
    BK.KPI_REF_ID,
    KP.KPI_NAME, 
    BK.WEIGHT,
    BS.YMD, 
    BS.THRESHOLD_REF_ID_MS AS CUR_SIG_ID,
    BC1.IMAGE_FILE_NAME AS CUR_IMAGE,
    BS.THRESHOLD_REF_ID_TS AS TO_SIG_ID,
    BC2.IMAGE_FILE_NAME AS TO_IMAGE,
    BS.POINTS_MS AS CUR_POINT,
    BS.POINTS_TS AS TO_POINT
FROM COM_EMP_INFO A
       LEFT JOIN REL_DEPT_EMP B    ON B.EMP_REF_ID  = A.EMP_REF_ID
       LEFT JOIN COM_DEPT_INFO C   ON C.DEPT_REF_ID = B.DEPT_REF_ID
       LEFT JOIN ( SELECT ESTTERM_REF_ID, DEPT_REF_ID, MAX(EST_DEPT_REF_ID) AS MAX_EST_DEPT
                     FROM EST_DEPT_INFO
                    WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
                      AND TEMP_FLAG = 1
                    GROUP BY ESTTERM_REF_ID, DEPT_REF_ID
                  ) DA  ON C.DEPT_REF_ID = DA.DEPT_REF_ID
       LEFT JOIN EST_DEPT_INFO DB  
         ON DA.ESTTERM_REF_ID = DB.ESTTERM_REF_ID
        AND DA.MAX_EST_DEPT   = DB.EST_DEPT_REF_ID 
       LEFT JOIN BSC_MAP_KPI BK
         ON DA.ESTTERM_REF_ID = BK.ESTTERM_REF_ID
        AND DA.MAX_EST_DEPT = BK.EST_DEPT_REF_ID
       INNER JOIN BSC_KPI_INFO BI
         ON BK.ESTTERM_REF_ID = BI.ESTTERM_REF_ID
         AND BK.KPI_REF_ID = BI.KPI_REF_ID
         AND BI.USE_YN = 'Y'
       LEFT JOIN BSC_KPI_POOL KP
         ON BI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
       LEFT JOIN BSC_KPI_SCORE BS
         ON BK.ESTTERM_REF_ID = BS.ESTTERM_REF_ID
        AND BK.KPI_REF_ID = BS.KPI_REF_ID
       LEFT JOIN BSC_THRESHOLD_CODE BC1
         ON BC1.THRESHOLD_REF_ID = BS.THRESHOLD_REF_ID_MS
       LEFT JOIN BSC_THRESHOLD_CODE BC2
         ON BC2.THRESHOLD_REF_ID = BS.THRESHOLD_REF_ID_TS         
WHERE BS.YMD = @YMD  
   AND A.LOGINID = @LOGINID
  AND ROWNUM <= 5";



            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@LOGINID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = ymd;
            paramArray[2].Value = loginid;

            DataTable dt = DbAgentObj.FillDataSet(query, "MY_TEAM_KPI", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }
	#endregion



    }
}
