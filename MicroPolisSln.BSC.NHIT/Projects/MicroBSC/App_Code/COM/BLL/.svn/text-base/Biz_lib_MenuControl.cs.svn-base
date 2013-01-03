using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.Data;
using MicroBSC.Biz.Common.Dac;


namespace MicroBSC.Biz.Common.Biz
{
    /// <summary>
    /// Biz_lib_MenuControl에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_lib_MenuControl Biz 클래스
    /// Class 내용		: MenuControl Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.04
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_lib_MenuControl : MicroBSC.Biz.Common.Dac.Dac_lib_MenuControl
    {
        /// <summary>
        /// 현재페이지의 메뉴명을 리턴
        /// </summary>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public string GetMenuName(string asPageUrl)
        {
            DataSet rDs = base.GetMenuLine(asPageUrl);
            string strNm = "Unregistered Page!";

            int cntRow = rDs.Tables[0].Rows.Count;

            if (cntRow > 0)
            {
                strNm = rDs.Tables[0].Rows[cntRow - 1]["MENU_NAME"].ToString();
            }

            return strNm;
        }

        /// <summary>
        /// 현재페이지의 메뉴페이지명 리턴
        /// </summary>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public string GetMenuPageName(string asPageUrl)
        {
            DataSet rDs = base.GetMenuLine(asPageUrl);
            string strNm = "Unregistered Page!";

            int cntRow = rDs.Tables[0].Rows.Count;

            if (cntRow > 0)
            {
                strNm = rDs.Tables[0].Rows[cntRow - 1]["MENU_PAGE_NAME"].ToString();
            }

            return strNm;
        }

        /// <summary>
        /// 현재페이지의 최상위 메뉴페이지명 리턴
        /// </summary>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public string GetTopMenuPageName(string asPageUrl)
        {
            DataSet rDs = base.GetMenuLine(asPageUrl);
            string strNm = "Unregistered Page!";

            int cntRow = rDs.Tables[0].Rows.Count;

            if (cntRow > 0)
            {
                strNm = rDs.Tables[0].Rows[0]["MENU_PAGE_NAME"].ToString();
            }

            return strNm;
        }

        /// <summary>
        /// 현재 메뉴의 경로 리턴
        /// </summary>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public string GetMenuNamePath(string asPageUrl)
        {
            DataSet rDs = base.GetMenuLine(asPageUrl);
            string strNm = "";

            int cntRow = rDs.Tables[0].Rows.Count;

            for (int i = 0; cntRow > i ;i++)
            {
                if (i > 0)
                {
                    strNm += " -> ";
                }

                strNm += rDs.Tables[0].Rows[i]["MENU_NAME"].ToString();
            }

            if (strNm == "")
            {
                strNm = "Unregistered Page!";
            }

            return strNm;
        }

        /// <summary>
        /// 메뉴페이지 정보 리턴
        /// </summary>
        /// <param name="asPageUrl">현재페이지</param>
        /// <param name="oPageName">현재페이지명</param>
        /// <param name="oMenuPageName">현재페이지 메뉴명</param>
        /// <param name="oMenuPath">현재페이지의 경로명</param>
        /// <param name="oMenuPageNameTop">현재페이지의 최상위 페이지명</param>
        /// <param name="oIsUseLeftMenu">현재페이지가 왼쪽메뉴를 사용할것인지 여부</param>
        public void GetMenuPageInfo
                       (string asPageUrl
                      , out string strCurMenuPageName
                      , out string strCurMenuFileName
                      , out string strAllMenuPathName
                      , out string strTopMenuFileName
                      , out string strUseLeftMenuPage)
        { 
            DataSet rDs = base.GetMenuLine(asPageUrl);
            int cntRow = rDs.Tables[0].Rows.Count;

            if (cntRow > 0)
            {
                strCurMenuPageName = rDs.Tables[0].Rows[cntRow - 1]["MENU_NAME"].ToString();
                strCurMenuFileName = rDs.Tables[0].Rows[cntRow - 1]["MENU_PAGE_NAME"].ToString().Trim().ToUpper();
                strUseLeftMenuPage = rDs.Tables[0].Rows[cntRow - 1]["SHOW_LEFT_MENU"].ToString().Trim().ToUpper();
                strTopMenuFileName = rDs.Tables[0].Rows[0]["MENU_PAGE_NAME"].ToString().ToUpper();
            }
            else
            {
                strCurMenuPageName = "Unregistered Page!";
                strCurMenuFileName = "Unregistered Page!";
                strUseLeftMenuPage = "Unregistered Page!";
                strTopMenuFileName = "Unregistered Page!";
            }

            strAllMenuPathName = "";
            for (int i = 0; cntRow > i ;i++)
            {
                if (i > 0)
                {
                    strAllMenuPathName += " -> ";
                }

                strAllMenuPathName += rDs.Tables[0].Rows[i]["MENU_NAME"].ToString();
            }

            if (strAllMenuPathName == "")
            {
                strAllMenuPathName = "Unregistered Page!";
            }
        }

        //public string GetTopMenuHtmlString(string asEmpRefID)
        //{
        //    DataSet rDs = base.GetTreeMenuPerUser(asEmpRefID);

            
        //}

        /// <summary>
        /// GetFinishRate
        ///     : KPI 실적 마감율 추출
        /// </summary>
        /// <param name="asFinishMonth"></param>
        /// <returns></returns>
        public int GetFinishRate(int estterm_ref_id, string asFinishMonth)
        {
            int iRet = 0;

           
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Dac_lib_MenuControl dac = new Dac_lib_MenuControl();

                iRet = dac.GetFinishRate(estterm_ref_id, asFinishMonth);

            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }


            return iRet;
        }

        /// <summary>
        /// GetMenuTitle
        ///     : 해당페이지의 메뉴명을 리턴한다. (타이틀 표시시 사용)
        /// </summary>
        /// <param name="asPageUrl"></param>
        /// <returns></returns>
        public string GetMenuTitle(string asPageUrl)
        {
            string sRet = "";

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Dac_lib_MenuControl dac = new Dac_lib_MenuControl();

                sRet = dac.GetMenuTitle(asPageUrl);
            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }

            
            return sRet;
        }

        //--------------------------------------------------------------------------------------------
        // 추가일 : 2007.05.30 
        // UserControl - LeftMenu, TopMenu의 메뉴 Data를 호출한다
        //--------------------------------------------------------------------------------------------
        #region

        public IDataReader GetAuthReadMenu(string asEmpRefID)
        {
            IDataReader dr = null;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Dac_lib_MenuControl dac = new Dac_lib_MenuControl();

                dr = dac.GetAuthReadMenu(asEmpRefID);

            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }


            return dr;
        }


        public DataSet GetAuthReadSearchMenu(string asEmpRefID, string asSearchStr)
        {
            DataSet lDS = new DataSet();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Dac_lib_MenuControl dac = new Dac_lib_MenuControl();

                lDS = dac.GetAuthReadSearchMenu(asEmpRefID, asSearchStr);

            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }


            return lDS;
        }


        #endregion
        //--------------------------------------------------------------------------------------------
    }
}
