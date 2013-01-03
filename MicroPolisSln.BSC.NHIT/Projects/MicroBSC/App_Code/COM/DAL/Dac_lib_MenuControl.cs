using System;
using System.Web;
using System.Data;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    /// <summary>
    /// Dac_lib_MenuControl에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_lib_MenuControl Dac 클래스
    /// Class 내용		: PositionGrp 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.05
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_lib_MenuControl : DbAgentBase
    {

        public DataSet GetAuthTopMenu(string asEmpRefID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "TM";
            paramArray[1]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = asEmpRefID;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_TOP_MENU"), "COM_MENU_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAuthSubMenu(string asEmpRefID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "MM";
            paramArray[1]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = asEmpRefID;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_SUB_MENU"), "COM_MENU_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// GetAuthMenu
        ///     : 현재 사용자가 가지고 있는 모든 메뉴페이지 리턴 (메뉴구성안하는 페이지는 제외)
        /// </summary>
        /// <param name="asEmpRefID"></param>
        /// <returns></returns>
        public DataSet GetAuthMenu(string asEmpRefID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "AM";
            paramArray[1]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = asEmpRefID;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_AUTH_MENU"), "COM_MENU_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// GetAuthMenu
        ///     : 현재 사용자가 가지고 있는 모든 메뉴페이지 리턴 (메뉴구성안하는 페이지는 제외)
        /// </summary>
        /// <param name="asEmpRefID"></param>
        /// <returns></returns>
        public DataSet GetAuthMenuInclude_N(string asEmpRefID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "NM";
            paramArray[1]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = asEmpRefID;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_NOT_AUTH_MENU"), "COM_MENU_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// IsNotUseMenu
        ///     : 현재페이지가 메뉴구성 안하는 페이지인가?
        /// </summary>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public bool IsNotUseMenu(string asEmpRefID, string asPageUrl)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "NU";
            paramArray[1]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = asEmpRefID;
            paramArray[2]               = CreateDataParameter("@iPAGE_URL", SqlDbType.VarChar);
            paramArray[2].Value         = asPageUrl;

            //return (Convert.ToString(DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_NOT_USE_MENU"), paramArray, CommandType.StoredProcedure)) == "N");

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_NOT_USE_MENU"), "COM_MENU_INFO", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string strRtn = ds.Tables[0].Rows[0][0].ToString();
                return (strRtn == "Y") ? true : false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// IsAuthPage
        ///     : 현재 페이지를 접근할 권한이 있는가?
        /// </summary>
        /// <param name="asEmpRefID"></param>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public bool IsAuthPage(string asEmpRefID, string asPageUrl)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "IA";
            paramArray[1]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = asEmpRefID;
            paramArray[2]               = CreateDataParameter("@iPAGE_URL", SqlDbType.VarChar);
            paramArray[2].Value         = asPageUrl;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_IS_ACCESS"), "COM_MENU_INFO", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int intRtn = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                return (intRtn>0) ? true : false;
            }
            else
            {
                return false;
            }

            //return (Convert.ToInt32(DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_IS_ACCESS"), paramArray, CommandType.StoredProcedure)) > 0);
        }

        /// <summary>
        /// GetTreeMenuPerUser : 사용자별 권한있는 페이지 트리조회
        /// </summary>
        /// <param name="asEmpRefID"></param>
        /// <returns></returns>
        public DataSet GetTreeMenuPerUser(string asEmpRefID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "UM";
            paramArray[1]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = asEmpRefID;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_AUTH_TREE_MENU"), "COM_MENU_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// GetMenuLine
        ///     : 현재 페이지의 페이지경로
        /// </summary>
        /// <param name="asEmpRefID"></param>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public DataSet GetMenuLine(string asPageUrl)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "ST";
            paramArray[1]               = CreateDataParameter("@iPAGE_URL", SqlDbType.VarChar);
            paramArray[1].Value         = asPageUrl;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_MENU_INFO", "PKG_COM_MENU_INFO.PROC_SELECT_MENU_LINE"), "COM_MENU_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// GetFinishRate
        ///     : KPI 실적 마감율 추출
        /// </summary>
        /// <param name="asFinishMonth"></param>
        /// <returns></returns>
        public int GetFinishRate(int estterm_ref_id, string asFinishMonth)
        {
            IDbDataParameter[] paramArray = null;
            string strSQL = "";
            string strORA = "";

            strSQL = "SELECT DBO.fn_BSC_MONTHLY_CLOSE_RATE(@iESTTERM_REF_ID,@iYMD)";
            strORA = "SELECT fn_BSC_MONTHLY_CLOSE_RATE(@iESTTERM_REF_ID,@iYMD) FROM DUAL";

            paramArray          = CreateDataParameters(2);
            paramArray[0]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1]       = CreateDataParameter("@iYMD", SqlDbType.VarChar);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = asFinishMonth;

            return Convert.ToInt32(DbAgentObj.ExecuteScalar(GetQueryStringByDb(strSQL, strORA), paramArray));
        }

        /// <summary>
        /// GetMenuTitle
        ///     : 해당페이지의 메뉴명을 리턴한다. (타이틀 표시시 사용)
        /// </summary>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public string GetMenuTitle(string asPageUrl)
        {
            string s_query = @"

                            SELECT 
                                ISNULL(MAX(MENU_NAME), ' ') 
                            FROM 
                                (SELECT MENU_NAME FROM COM_MENU_INFO WHERE UPPER(MENU_FULL_PATH) = UPPER(@PAGEURL) AND MENU_TYPE = 'S') A
            ";

            string o_query = @"

                            SELECT 
                                NVL(MAX(MENU_NAME), ' ') 
                            FROM 
                                (SELECT MENU_NAME FROM COM_MENU_INFO WHERE UPPER(MENU_FULL_PATH) = UPPER(@PAGEURL) AND MENU_TYPE = 'S') A
            ";
            
            StringBuilder sbQuery       = new StringBuilder();

            IDbDataParameter[] paramArray = null;

            paramArray          = CreateDataParameters(1);
            paramArray[0]       = CreateDataParameter("@PAGEURL", SqlDbType.VarChar);

            paramArray[0].Value = asPageUrl;

            return Convert.ToString(DbAgentObj.ExecuteScalar(GetQueryStringByDb(s_query, o_query), paramArray));
        }

        //--------------------------------------------------------------------------------------------
        // 추가일 : 2007.05.30 
        // UserControl - LeftMenu, TopMenu의 메뉴 Data를 호출한다
        //--------------------------------------------------------------------------------------------
        #region

        public IDataReader GetAuthReadMenu(string asEmpRefID)
        {
            IDbDataParameter[] paramArray = null;

            string query = @"
                                SELECT 
	                                CMI.MENU_REF_ID         AS MENU_REF_ID,                                    
	                                MENU_NAME               AS MENU_NAME,
	                                MENU_PRIORITY           AS MENU_SORT,
                                    UP_MENU_ID              AS UP_MENU_ID,
	                                MENU_DIR                AS MENU_DIR,
	                                MENU_PAGE_NAME          AS MENU_PAGE_NAME,
	                                MENU_PARAM              AS MENU_PARAM,
	                                MENU_FULL_PATH	        AS MENU_FULL_PATH   
                                FROM
	                                COM_MENU_INFO	        AS CMI
	                                INNER JOIN 
	                                    (
		                                    SELECT DISTINCT                                   
			                                    A.MENU_REF_ID           
		                                    FROM 
			                                    COM_ROLE_MENU_REL AS A                  
			                                    INNER JOIN 	COM_EMP_ROLE_REL AS B 
                                                ON A.ROLE_REF_ID = B.ROLE_REF_ID 
		                                    WHERE
			                                     B.EMP_REF_ID = @EMP_REF_ID
                                        ) AS CMI_R 
                                    ON CMI.MENU_REF_ID = CMI_R.MENU_REF_ID 
                                WHERE 
	                                MENU_TYPE IN ('T','M','S')
									
                                ORDER BY
	                                MENU_PRIORITY 
                            ";

            paramArray          = CreateDataParameters(1);
            paramArray[0]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = int.Parse(asEmpRefID);

            IDataReader dr      = DbAgentObj.ExecuteReader(query, paramArray);
            return dr;
        }

        public DataSet GetAuthReadSearchMenu(string asEmpRefID, string asSearchStr)
        {
            IDbDataParameter[] paramArray = null;

            string query = @"
                                SELECT 
	                                CMI.MENU_REF_ID                     AS MENU_REF_ID,
                                    UP_MENU_ID                          AS UP_MENU_ID,
	                                MENU_NAME                           AS MENU_NAME,
                                    IsNull(@SEARCHSTR,'')+MENU_NAME     AS SearchMenu,
                                    MENU_FULL_PATH                      AS MENU_FULL_PATH
                                FROM
	                                COM_MENU_INFO	        AS CMI
                                    INNER JOIN 
                                    (
                                        SELECT DISTINCT                                   
                                            A.MENU_REF_ID              
                                        FROM 
                                            COM_ROLE_MENU_REL AS A                  
                                            INNER JOIN 	COM_EMP_ROLE_REL AS B 
                                                ON A.ROLE_REF_ID = B.ROLE_REF_ID 
                                        WHERE
			                                 B.EMP_REF_ID = CONVERT(int, @EMP_REF_ID)
                                    ) AS CMI_R ON CMI.MENU_REF_ID = CMI_R.MENU_REF_ID 
                                WHERE 
	                                MENU_TYPE IN ('M','S')
                            ";

            paramArray          = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.VarChar);
            paramArray[1]       = CreateDataParameter("@SEARCHSTR", SqlDbType.VarChar);


            paramArray[0].Value = asEmpRefID;
            paramArray[1].Value = asSearchStr;

            DataSet ds = DbAgentObj.Fill(query, paramArray);
            return ds;
        }

        #endregion
        //--------------------------------------------------------------------------------------------
    }
}
