using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
using System.Drawing;
using Dundas.Charting.WebControl;
using MicroCharts;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Data.Oracle;
using System.Text;


public partial class eis_SEM_Mana_R017 : EISPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }

    #region 페이지 초기화 함수
        private void SetAllTimeTop()
        {

        }

        private void InitControlValue()
        {
            DateTime dtNow = System.DateTime.Now;
            string sMonth = "";

            this.ddlYear.Items.Clear();
            this.ddlMonth.Items.Clear();
            this.ddlLocation.Items.Clear();
            this.ddlGubun.Items.Clear();

            for (int i = dtNow.Year - 2; i <= dtNow.Year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i <= 12; i++)
            {
                sMonth = (i < 10 ? "0" + i.ToString() : i.ToString());
                this.ddlMonth.Items.Add(new ListItem(sMonth, sMonth));
            }

            this.SetAreaDropDownList(ddlLocation);

            ddlGubun.Items.Add(new ListItem("매출기간", "SALE"));
            ddlGubun.Items.Add(new ListItem("공급기간", "SUPPLY"));

            FindByValueDropDownList(ddlYear, dtNow.Year.ToString());
            FindByValueDropDownList(ddlMonth, (dtNow.Month < 10 ? "0" + Convert.ToString(dtNow.Month-1) : Convert.ToString(dtNow.Month-1)));
            FindByTextDropDownList(ddlLocation, "울산");

        }

        private void InitControlEvent()
        {
        }

        private void SetPageData()
        {
            GridBinding();
        }

        private void SetPostBack()
        {

        }

        private void SetAllTimeBottom()
        {

        }
    #endregion

    #region 내부함수
        private void GridBinding()
        {
            UltraWebGrid1.DataSource = GetDTGrid();
            UltraWebGrid1.DataBind();
        }

        // 그리드용 데이타테이블 반환
        private DataTable GetDTGrid()
        {
            string sYear = GetByValueDropDownList(ddlYear);
            string sMonth = GetByValueDropDownList(ddlMonth);

            string[]    saMonthTerm = GetMonthTerm(sYear, sMonth);    // 가로축 월별..
            string[,]   saGubuns    = GetGubunInfo();                   // 세로축 구분...

            int     iCount  = 0;    // SubTotal합계 표현시 1개 이상일경우만 보이기 위해 사용
            double  dTmp1   = 0;

            string sPrevCode2       = "";   // SubTotal을 추가하기 위해 이전 sem_code2를 저장하는 변수

            DataSet dsDefault = gDbAgent.Fill(GetDefaultQuery());
            DataTable dtDefault = null;
            DataRow[] draDefault = null;

            DataTable dataTable = new DataTable();
            DataRow drNew = null;

            dataTable.Columns.Add("SEM_CODE2", typeof(string));
            dataTable.Columns.Add("SEM_CODE3", typeof(string));
            dataTable.Columns.Add("합계",   typeof(double));

            for (int i=0; i <= saMonthTerm.GetUpperBound(0); i++)
            {
                dataTable.Columns.Add(Convert.ToInt32(saMonthTerm[i].Substring(4,2)).ToString() + "월", typeof(double));
            }

            if (dsDefault.Tables.Count > 0)
            {
                dtDefault = dsDefault.Tables[0];
                
                sPrevCode2 = saGubuns[0, 1];    // 시작시 sem_code2 저장

                for (int i=0; i < saGubuns.GetUpperBound(0); i++)
                {
                    if (sPrevCode2 != saGubuns[i, 1])
                    {
                        if (iCount > 1)
                        {
                            // SubTotal열 추가
                            drNew = dataTable.NewRow();

                            drNew["SEM_CODE2"] = sPrevCode2;
                            drNew["SEM_CODE3"] = "합계";

                            draDefault = dtDefault.Select(
                                                            "SEM_CODE2_NAME = '" + sPrevCode2 + "' "
                                                         );

                            dTmp1 = 0;
                            for (int j = 0; j < draDefault.Length; j++)
                            {
                                dTmp1 += Convert.ToDouble(draDefault[j]["V_QTY"]);
                            }

                            drNew["합계"] = dTmp1;

                            for (int j = 0; j <= saMonthTerm.GetUpperBound(0); j++)
                            {
                                draDefault = dtDefault.Select(
                                                                "SEM_CODE2_NAME = '" + sPrevCode2 + "' "
                                                          + "AND SALE_DATE_T = '" + saMonthTerm[j] + "' "
                                                             );

                                dTmp1 = 0;
                                for (int k = 0; k < draDefault.Length; k++)
                                {
                                    dTmp1 += Convert.ToDouble(draDefault[k]["V_QTY"]);
                                }

                                drNew[Convert.ToInt32(saMonthTerm[j].Substring(4, 2)).ToString() + "월"] = dTmp1;
                            }

                            dataTable.Rows.Add(drNew);
                        }

                        iCount = 0;
                        sPrevCode2 = saGubuns[i, 1];
                    }
                    
                    iCount++;

                    drNew = dataTable.NewRow();

                    drNew["SEM_CODE2"]  = saGubuns[i, 1];
                    drNew["SEM_CODE3"]  = saGubuns[i, 3];

                    draDefault = dtDefault.Select(
                                                    "SEM_CODE2_T = '" + saGubuns[i, 0] + "' "
                                              + "AND SEM_CODE3_T = '" + saGubuns[i, 2] + "' "
                                                 );

                    dTmp1 = 0;
                    for (int j=0; j < draDefault.Length; j++)
                    {
                        dTmp1 += Convert.ToDouble(draDefault[j]["V_QTY"]);
                    }

                    drNew["합계"] = dTmp1;

                    for (int j=0; j <= saMonthTerm.GetUpperBound(0); j++)
                    {
                        draDefault = dtDefault.Select(
                                                        "SEM_CODE2_T = '" + saGubuns[i, 0] + "' "
                                                  + "AND SEM_CODE3_T = '" + saGubuns[i, 2] + "' "
                                                  + "AND SALE_DATE_T = '" + saMonthTerm[j] + "' "
                                                     );

                        dTmp1 = 0;
                        for (int k=0; k < draDefault.Length; k++)
                        {
                            dTmp1 += Convert.ToDouble(draDefault[k]["V_QTY"]);
                        }

                        drNew[Convert.ToInt32(saMonthTerm[j].Substring(4,2)).ToString() + "월"] = dTmp1;
                    }
                    
                    dataTable.Rows.Add(drNew);
                }

                // 마지막 SubTotal 추가
                if (iCount > 1)
                {
                    // SubTotal열 추가
                    drNew = dataTable.NewRow();

                    drNew["SEM_CODE2"] = sPrevCode2;
                    drNew["SEM_CODE3"] = "합계";

                    draDefault = dtDefault.Select(
                                                    "SEM_CODE2_NAME = '" + sPrevCode2 + "' "
                                                 );

                    dTmp1 = 0;
                    for (int j = 0; j < draDefault.Length; j++)
                    {
                        dTmp1 += Convert.ToDouble(draDefault[j]["V_QTY"]);
                    }

                    drNew["합계"] = dTmp1;

                    for (int j = 0; j <= saMonthTerm.GetUpperBound(0); j++)
                    {
                        draDefault = dtDefault.Select(
                                                        "SEM_CODE2_NAME = '" + sPrevCode2 + "' "
                                                  + "AND SALE_DATE_T = '" + saMonthTerm[j] + "' "
                                                     );

                        dTmp1 = 0;
                        for (int k = 0; k < draDefault.Length; k++)
                        {
                            dTmp1 += Convert.ToDouble(draDefault[k]["V_QTY"]);
                        }

                        drNew[Convert.ToInt32(saMonthTerm[j].Substring(4, 2)).ToString() + "월"] = dTmp1;
                    }

                    dataTable.Rows.Add(drNew);
                }


                // Total열 추가
                drNew = dataTable.NewRow();

                drNew["SEM_CODE2"] = "";
                drNew["SEM_CODE3"] = "총합계";

                draDefault = dtDefault.Select();

                dTmp1 = 0;
                for (int j = 0; j < draDefault.Length; j++)
                {
                    dTmp1 += Convert.ToDouble(draDefault[j]["V_QTY"]);
                }

                drNew["합계"] = dTmp1;

                for (int j = 0; j <= saMonthTerm.GetUpperBound(0); j++)
                {
                    draDefault = dtDefault.Select(
                                                    "SALE_DATE_T = '" + saMonthTerm[j] + "' "
                                                 );

                    dTmp1 = 0;
                    for (int k = 0; k < draDefault.Length; k++)
                    {
                        dTmp1 += Convert.ToDouble(draDefault[k]["V_QTY"]);
                    }

                    drNew[Convert.ToInt32(saMonthTerm[j].Substring(4, 2)).ToString() + "월"] = dTmp1;
                }

                dataTable.Rows.Add(drNew);

            }

            return dataTable;
        }

        private string GetDefaultQuery()
        {

            string sYear = GetByValueDropDownList(ddlYear);
            string sMonth = GetByValueDropDownList(ddlMonth);
            string sLocate = GetByValueDropDownList(ddlLocation);
            string sGubun = GetByValueDropDownList(ddlGubun);

            string sQuery = "";

            switch (sGubun)
            {
                case "SALE":
                    sQuery = GetSaleQuery(sYear, sMonth, sLocate);

                    break;
                case "SUPPLY":
                    sQuery = GetSupplyQuery(sYear, sMonth, sLocate);

                    break;
            }

            return sQuery;
        }

        /// <summary>
        /// GetSaleQuery
        ///     : 매출쿼리 리턴
        /// </summary>
        /// <param name="asYear"></param>
        /// <param name="asMonth"></param>
        /// <param name="asLocate"></param>
        /// <returns></returns>
        private string GetSaleQuery(string asYear, string asMonth, string asLocate)
        {
            string[] saMonthTerm = GetMonthTerm(asYear, asMonth);

            string sQuery = "";
            asLocate = (asLocate == "--") ? "" : asLocate;

            sQuery += "SELECT B.V_YYYYMM   SALE_DATE_T,             \n";
            sQuery += "       B.SEM_CODE2_T,                        \n";
            sQuery += "       B.SEM_CODE2_NAME,                     \n";
            sQuery += "       B.SEM_CODE3_T,                        \n";
            sQuery += "       B.SEM_CODE3_NAME,                     \n";
            sQuery += "       TO_CHAR(NVL(A.V_QNT, 0)) V_QTY        \n";
            sQuery += "  FROM (                                     \n";
            sQuery += "       SELECT SM.SALE_DATE_T,                                              -- 년월                                   \n";
            sQuery += "              CM.SEM_CODE2_T,                                              -- 매출구분 코드                          \n";
            sQuery += "              CM.SEM_CODE2_NAME,                                           -- 매출구분 명                            \n";
            sQuery += "              CM.SEM_CODE3_T,                                                                                        \n";
            sQuery += "              CM.SEM_CODE3_NAME   ,                                                                                  \n";
            sQuery += "              DECODE(SUM(DD.DEVE_TOTAL_QNT), 0, 0, SUM(SM.SALE_QNT_ACTUAL)/SUM(DD.DEVE_TOTAL_QNT)) V_QNT  -- 원단위  \n";
            sQuery += "         FROM SEM_DEMAND_DEVELOP DD,                                                                         \n";
            sQuery += "              SEM_SALE_MONTHLY SM,                                                                           \n";
            sQuery += "              SEM_CODE_MASTER CM                                                                             \n";
            sQuery += "        WHERE SM.SALE_DATE_T BETWEEN '" + saMonthTerm[saMonthTerm.GetLowerBound(0)] + "' AND '" + saMonthTerm[saMonthTerm.GetUpperBound(0)] + "'                -- 조회저건 : 기간                         \n";
            sQuery += "          AND SM.SALE_OFFICE_T LIKE '" + asLocate + "'||'%'      -- 조회조건 : 사업장 01(울산),  02(양산)   \n";
            sQuery += "          AND CM.SEM_CODE1_T = '06'                              \n";
            sQuery += "          AND SM.SALE_DATE_T = DD.DEVE_DATE_T                    \n";
            sQuery += "          AND SM.SALE_OFFICE_T = DD.DEVE_OFFICE_T                \n";
            sQuery += "          AND CM.SEM_CODE2_T IN ('100','200','300','400')        \n";
            sQuery += "          AND SM.SALE_GUBN_CODE_T = DD.DEVE_GUBN_CODE_T          \n";
            sQuery += "          AND SM.SALE_GUBN_CODE_T = CM.SEM_CODE3_T               \n";
            sQuery += "        GROUP BY SM.SALE_DATE_T,                                 \n";
            sQuery += "              CM.SEM_CODE2_T,                                    \n";
            sQuery += "              CM.SEM_CODE2_NAME,                                 \n";
            sQuery += "              CM.SEM_CODE3_T,                                    \n";
            sQuery += "              CM.SEM_CODE3_NAME                                  \n";
            sQuery += "        ORDER BY                                                 \n";
            sQuery += "              SM.SALE_DATE_T,                                    \n";
            sQuery += "              CM.SEM_CODE2_T,                                    \n";
            sQuery += "              CM.SEM_CODE3_T                                     \n";
            sQuery += "       ) A,                                                      \n";
            sQuery += "       (                                                         \n";
            sQuery += "       SELECT A.V_YYYYMM,                                        \n";
            sQuery += "              B.SEM_CODE2_T,                                     \n";
            sQuery += "              B.SEM_CODE2_NAME ,                                 \n";
            sQuery += "              B.SEM_CODE3_T,                                     \n";
            sQuery += "              B.SEM_CODE3_NAME                                   \n";
            sQuery += "         FROM                                                    \n";
            sQuery += "               (                                                 \n";

            for (int i = 0; i <= saMonthTerm.GetUpperBound(0); i++) 
            {
                sQuery += "               SELECT '" + saMonthTerm[i] + "' V_YYYYMM FROM DUAL UNION ALL      \n";
            }
            sQuery += "               SELECT '000000' V_YYYYMM FROM DUAL                \n";


            sQuery += "               ) A,                                              \n";
            sQuery += "               (                                                 \n";
            sQuery += "               SELECT DISTINCT                                   \n";
            sQuery += "                      SEM_CODE2_T,                               \n";
            sQuery += "                      SEM_CODE2_NAME,                            \n";
            sQuery += "                      SEM_CODE3_T,                               \n";
            sQuery += "                      SEM_CODE3_NAME                             \n";
            sQuery += "                 FROM SEM_CODE_MASTER                            \n";
            sQuery += "                WHERE SEM_CODE1_T = '06'                         \n";
            sQuery += "                  AND SEM_CODE2_T IN ('100','200','300','400')   \n";
            sQuery += "               ) B                                               \n";
            sQuery += "       ) B                                                       \n";
            sQuery += " WHERE A.SALE_DATE_T    (+) = B.V_YYYYMM                         \n";
            sQuery += "   AND A.SEM_CODE2_T    (+) = B.SEM_CODE2_T                      \n";
            sQuery += "   AND A.SEM_CODE2_NAME (+) = B.SEM_CODE2_NAME                   \n";
            sQuery += "   AND A.SEM_CODE3_T    (+) = B.SEM_CODE3_T                      \n";
            sQuery += "   AND A.SEM_CODE3_NAME (+) = B.SEM_CODE3_NAME                   \n";
            sQuery += "   AND B.V_YYYYMM           <> '000000'                          \n";

            return sQuery;
        }

        /// <summary>
        /// GetSupplyQuery
        ///     : 공급쿼리 리턴
        /// </summary>
        /// <param name="asYear"></param>
        /// <param name="asMonth"></param>
        /// <param name="asLocate"></param>
        /// <returns></returns>
        private string GetSupplyQuery(string asYear, string asMonth, string asLocate)
        {
            string[] saMonthTerm = GetMonthTerm(asYear, asMonth);

            string sQuery = "";

            sQuery += "SELECT                                   \n";
            sQuery += "       B.V_YYYYMM    SALE_DATE_T,        \n";
            sQuery += "       B.SEM_CODE2_T,                    \n";
            sQuery += "       B.SEM_CODE2_NAME,                 \n";
            sQuery += "       B.SEM_CODE3_T,                    \n";
            sQuery += "       B.SEM_CODE3_NAME,                 \n";
            sQuery += "       TO_CHAR(NVL(A.V_UNIT, 0)) V_QTY   \n";
            sQuery += "  FROM                                   \n";
            sQuery += "       (                                 \n";
            sQuery += "       SELECT SU.UNIT_DATE_T,                                  -- 년월                   \n";
            sQuery += "              CM.SEM_CODE2_T,                                  -- 매출구분 대분류 코드   \n";
            sQuery += "              CM.SEM_CODE2_NAME,                               -- 매출구분 중분류 코드명 \n";
            sQuery += "              CM.SEM_CODE3_T,                                                            \n";
            sQuery += "              CM.SEM_CODE3_NAME,                                                         \n";
            sQuery += "              SUM(SU.UNIT_SALE_UNIT) V_UNIT                    -- 원단위 매출량          \n";
            sQuery += "         FROM SEM_SALE_UNIT SU,                                                  \n";
            sQuery += "              SEM_CODE_MASTER CM                                                 \n";
            sQuery += "        WHERE SU.UNIT_DATE_T BETWEEN '" + saMonthTerm[saMonthTerm.GetLowerBound(0)] + "' AND '" + saMonthTerm[saMonthTerm.GetUpperBound(0)] + "'     -- 조회조건 : 년월        \n";
            sQuery += "          AND SU.UNIT_OFFICE_T like '" + asLocate + "'||'%'    -- 조회조건 : 사업장      \n";
            sQuery += "          AND CM.SEM_CODE1_T = '06'                                 \n";
            sQuery += "          AND CM.SEM_CODE2_T IN ('100','200','300','400')           \n";
            sQuery += "          AND CM.SEM_CODE3_T IN ('110','120')                       \n";
            sQuery += "          AND SU.UNIT_GUBN_CODE_T = CM.SEM_CODE3_T                  \n";
            sQuery += "        GROUP BY                                                    \n";
            sQuery += "              SU.UNIT_DATE_T,                                       \n";
            sQuery += "              CM.SEM_CODE2_T,                                       \n";
            sQuery += "              CM.SEM_CODE2_NAME,                                    \n";
            sQuery += "              CM.SEM_CODE3_T,                                       \n";
            sQuery += "              CM.SEM_CODE3_NAME                                     \n";
            sQuery += "        UNION ALL                                                   \n";
            sQuery += "       SELECT SM.SALE_DATE_T UNIT_DATE_T,                                              -- 년월                                   \n";
            sQuery += "              CM.SEM_CODE2_T,                                              -- 매출구분 코드                          \n";
            sQuery += "              CM.SEM_CODE2_NAME,                                           -- 매출구분 명                            \n";
            sQuery += "              CM.SEM_CODE3_T,                                                                                        \n";
            sQuery += "              CM.SEM_CODE3_NAME   ,                                                                                  \n";
            sQuery += "              DECODE(SUM(DD.DEVE_TOTAL_QNT), 0, 0, SUM(SM.SALE_QNT_ACTUAL)/SUM(DD.DEVE_TOTAL_QNT)) V_UNIT  -- 원단위  \n";
            sQuery += "         FROM SEM_DEMAND_DEVELOP DD,                                                                         \n";
            sQuery += "              SEM_SALE_MONTHLY SM,                                                                           \n";
            sQuery += "              SEM_CODE_MASTER CM                                                                             \n";
            sQuery += "        WHERE SM.SALE_DATE_T BETWEEN '" + saMonthTerm[saMonthTerm.GetLowerBound(0)] + "' AND '" + saMonthTerm[saMonthTerm.GetUpperBound(0)] + "'                -- 조회저건 : 기간                         \n";
            sQuery += "          AND SM.SALE_OFFICE_T like '" + asLocate + "'||'%'                                     -- 조회조건 : 사업장 01(울산),  02(양산)   \n";
            sQuery += "          AND CM.SEM_CODE1_T = '06'                              \n";
            sQuery += "          AND SM.SALE_DATE_T = DD.DEVE_DATE_T                    \n";
            sQuery += "          AND SM.SALE_OFFICE_T = DD.DEVE_OFFICE_T                \n";
            sQuery += "          AND CM.SEM_CODE2_T IN ('100','200','300','400')        \n";
            sQuery += "          AND CM.SEM_CODE3_T not in ('110','120')                \n";
            sQuery += "          AND SM.SALE_GUBN_CODE_T = DD.DEVE_GUBN_CODE_T          \n";
            sQuery += "          AND SM.SALE_GUBN_CODE_T = CM.SEM_CODE3_T               \n";
            sQuery += "        GROUP BY SM.SALE_DATE_T,                                 \n";
            sQuery += "              CM.SEM_CODE2_T,                                    \n";
            sQuery += "              CM.SEM_CODE2_NAME,                                 \n";
            sQuery += "              CM.SEM_CODE3_T,                                    \n";
            sQuery += "              CM.SEM_CODE3_NAME                                  \n";
            sQuery += "       ) A,                                                         \n";
            sQuery += "       (                                                            \n";
            sQuery += "       SELECT A.V_YYYYMM,                                           \n";
            sQuery += "              B.SEM_CODE2_T,                                        \n";
            sQuery += "              B.SEM_CODE2_NAME ,                                    \n";
            sQuery += "              B.SEM_CODE3_T,                                        \n";
            sQuery += "              B.SEM_CODE3_NAME                                      \n";
            sQuery += "         FROM                                                       \n";
            sQuery += "               (                                                    \n";

            for (int i = 0; i <= saMonthTerm.GetUpperBound(0); i++)
            {
                sQuery += "               SELECT '" + saMonthTerm[i] + "' V_YYYYMM FROM DUAL UNION ALL      \n";
            }
            sQuery += "               SELECT '000000' V_YYYYMM FROM DUAL                \n";


            sQuery += "               ) A,                                                 \n";
            sQuery += "               (                                                    \n";
            sQuery += "               SELECT DISTINCT                                      \n";
            sQuery += "                      SEM_CODE2_T,                                  \n";
            sQuery += "                      SEM_CODE2_NAME,                               \n";
            sQuery += "                      SEM_CODE3_T,                                  \n";
            sQuery += "                      SEM_CODE3_NAME                                \n";
            sQuery += "                 FROM SEM_CODE_MASTER                               \n";
            sQuery += "                WHERE SEM_CODE1_T = '06'                            \n";
            sQuery += "                  AND SEM_CODE2_T IN ('100','200','300','400')      \n";
            sQuery += "               ) B                                                  \n";
            sQuery += "       ) B                                                          \n";
            sQuery += " WHERE A.UNIT_DATE_T    (+) = B.V_YYYYMM                            \n";
            sQuery += "   AND A.SEM_CODE2_T    (+) = B.SEM_CODE2_T                         \n";
            sQuery += "   AND A.SEM_CODE2_NAME (+) = B.SEM_CODE2_NAME                      \n";
            sQuery += "   AND A.SEM_CODE3_T    (+) = B.SEM_CODE3_T                         \n";
            sQuery += "   AND B.V_YYYYMM           <> '000000'                             \n";
            sQuery += " ORDER BY B.SEM_CODE2_T, B.SEM_CODE3_T                              \n";




            return sQuery;
        }

        /// <summary>
        /// GetGubunInfo
        ///     : 구분코드 및 코드명 2차원배열로 추출
        /// </summary>
        /// <returns></returns>
        private string[,] GetGubunInfo()
        {
            string sQuery = "";

            sQuery += "SELECT CM.SEM_CODE2_T,                               \n";
            sQuery += "       CM.SEM_CODE2_NAME,                            \n";
            sQuery += "       CM.SEM_CODE3_T,                               \n";
            sQuery += "       CM.SEM_CODE3_NAME                             \n";
            sQuery += "  FROM SEM_CODE_MASTER CM                    \n";
            sQuery += " WHERE CM.SEM_CODE1_T = '06'                         \n";
            sQuery += "   AND CM.SEM_CODE2_T IN ('100','200','300','400')   \n";
            sQuery += " GROUP BY                                            \n";
            sQuery += "       CM.SEM_CODE2_T,                               \n";
            sQuery += "       CM.SEM_CODE2_NAME,                            \n";
            sQuery += "       CM.SEM_CODE3_T,                               \n";
            sQuery += "       CM.SEM_CODE3_NAME                             \n";

            DataSet dsGubun = gDbAgent.Fill(sQuery);
            DataTable dtGubun = null;

            string sGubun = "";

            if (dsGubun.Tables.Count > 0)
            {
                dtGubun = dsGubun.Tables[0];

                foreach (DataRow dr in dtGubun.Rows)
                {
                    sGubun += dr["SEM_CODE2_T"].ToString() + ";" + dr["SEM_CODE2_NAME"].ToString() + ";" + dr["SEM_CODE3_T"].ToString() + ";" + dr["SEM_CODE3_NAME"].ToString() + ";";
                }
            }

            return GetSplit(sGubun, 4);
        }

        private string[] GetMonthTerm(string asYear, string asMonth)
        {
            string[] saMonthTerm;

            string sYYYYMMs = asYear + "01";
            string sYYYYMMe = asYear + asMonth;

            saMonthTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

            return saMonthTerm;
        }

        private string[] GetMonthTerm(int aiYear, string asMonth)
        {
            return GetMonthTerm(aiYear.ToString(), asMonth);
        }

        private string[] GetMonthTerm(string asYear)
        {
            string[] saMonthTerm;

            string sYYYYMMs = asYear + "01";
            string sYYYYMMe = asYear + "12";

            saMonthTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

            return saMonthTerm;
        }

        private string[] GetMonthTerm(int aiYear)
        {
            return GetMonthTerm(aiYear.ToString());
        }

    #endregion


    #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            GridBinding();
        }

        protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        {
            Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

            ch = e.Layout.Bands[0].Columns[0].Header;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 0;
            ch.RowLayoutColumnInfo.SpanY = 1;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            ch.Caption = "용도";



            e.Layout.Bands[0].Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].Columns[0].MergeCells = true;

            e.Layout.Bands[0].Columns[0].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP1);
            e.Layout.Bands[0].Columns[1].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP2);

            for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.00";

            }

        }

        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            #region 서브토탈 및 총합계열에 대한 색깔변경

            
            if (e.Row.Cells[1].Value.ToString().IndexOf("총합계") >= 0)
            {
                e.Row.Cells[0].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_NAME2);
                e.Row.Cells[1].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_NAME2);
                for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
                {
                    e.Row.Cells[i].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA2);
                }
            }
            else if (e.Row.Cells[1].Value.ToString().IndexOf("합계") >= 0)
            {

                e.Row.Cells[1].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_NAME1);
                for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
                {
                    e.Row.Cells[i].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
                }
            }
            #endregion

        }
    #endregion
}
