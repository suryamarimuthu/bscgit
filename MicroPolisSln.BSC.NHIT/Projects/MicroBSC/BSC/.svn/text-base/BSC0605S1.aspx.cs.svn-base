using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Text;
using MicroBSC.Integration.BSC.Biz;
using MicroBSC.Common;

public partial class BSC_BSC0605S1 : AppPageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        bool RadoChecked = false;
        for (int i = 0; i < rdoList.Items.Count; i++)
        {
            if (rdoList.Items[i].Selected) RadoChecked = true;
        }
        if (!RadoChecked)
        {
            Response.Write("<script>alert('템플릿 유형을 선택하세요.');</script>");
        }
        else
        {
            //string NHIT_DASHBOARD_EMP = "CR_YEAR,CR_MONTH,BONBU_NAME,TEAM_NAME,GRP_ONE_B_NAME,GRP_ONE_C_NAME,PROJECT_NAME,EMP_NAME,RESULT_FULL,RESULT_DONG,RESULT_BDONG";
            StringBuilder NHIT_DASHBOARD_EMP = new StringBuilder();
            NHIT_DASHBOARD_EMP.AppendLine("해당 년,해당 월,본부 명칭,팀 명칭,고객사 구분,사업유형 구분,프로젝트명칭,성명,가득,가동,비가동");
            NHIT_DASHBOARD_EMP.AppendLine("CR_YEAR,CR_MONTH,BONBU_NAME,TEAM_NAME,GRP_ONE_B_NAME,GRP_ONE_C_NAME,PROJECT_NAME,EMP_NAME,RESULT_FULL,RESULT_DONG,RESULT_BDONG");
            NHIT_DASHBOARD_EMP.AppendLine("YYYY,MM,경제사업본부,경제사업팀,중앙회,SM,프로젝트명칭,홍길동,1,,");
            NHIT_DASHBOARD_EMP.AppendLine("YYYY,MM,,,계열사,SI,,,,,");
            NHIT_DASHBOARD_EMP.AppendLine(",,,,대외,상품,,,,,");
            NHIT_DASHBOARD_EMP.AppendLine(",,,,조합,ETC,,,,,");
            NHIT_DASHBOARD_EMP.AppendLine(",,,,기타,공통,,,,,");


            //string NHIT_DASHBOARD_EMP_MERGE = "CR_YEAR,CR_MONTH,TARGET_FULL_RATE,RESULT_FULL_RATE,RESULT_DONG_RATE,RESULT_BDONG_RATE";
            StringBuilder NHIT_DASHBOARD_EMP_MERGE = new StringBuilder();
            NHIT_DASHBOARD_EMP_MERGE.AppendLine("해당년도,해당원,년 목표가득률,실적(누적)가득률,실적(누적)가동률,실적(누적)비가득률,년 목표가동률,실적(당월)가득률,실적(당월)가동률,실적(당월)비가동률");
            NHIT_DASHBOARD_EMP_MERGE.AppendLine("CR_YEAR,CR_MONTH,TARGET_FULL_RATE,RESULT_FULL_RATE,RESULT_DONG_RATE,RESULT_BDONG_RATE,TARGET_DANG_RATE,RESULT_FULL_RATE_MS,RESULT_DONG_RATE_MS,RESULT_BDONG_RATE_MS");
            NHIT_DASHBOARD_EMP_MERGE.AppendLine("YYYY,MM,84,91.1,94.8,5.1,84,91.1,94.8,5.1");
            NHIT_DASHBOARD_EMP_MERGE.AppendLine("YYYY,MM,84,87.6,92.5,7.4,84,87.6,92.5,7.4");


            //string NHIT_DASHBOARD_MAIN = "GRP_ONE_CODE,GRP_ONE_NAME,GRP_TWO_CODE,GRP_TWO_NAME,GRP_THREE_CODE,GRP_THREE_NAME,CR_YEAR,CR_MONTH,TARGET_YEAR,TARGET_TS,RESULT_TS,DAL_RATE";
            StringBuilder NHIT_DASHBOARD_MAIN = new StringBuilder();
            NHIT_DASHBOARD_MAIN.AppendLine("대분류코드,대분류명칭,중분류코드,중분류명칭,손익항목코드,손익항목명칭,실적 년도,실적 월,년 목표,누적목표,누적실적,달성율,목표구분");
            NHIT_DASHBOARD_MAIN.AppendLine("GRP_ONE_CODE,GRP_ONE_NAME,GRP_TWO_CODE,GRP_TWO_NAME,GRP_THREE_CODE,GRP_THREE_NAME,CR_YEAR,CR_MONTH,TARGET_YEAR,TARGET_TS,RESULT_TS,DAL_RATE,TG_GUBUN");
            NHIT_DASHBOARD_MAIN.AppendLine("A,전사,10,전사,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,20,중앙회,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,30,계열사,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,40,대외,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,50,SI,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,60,SM,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,70,상품,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,80,사업지원,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,90,금융사업,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,100,경제사업,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,110,카드사업,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,120,보험부문,ME,매출,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,130,전략사업,ME,매출,YYYY,MM,-,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("A,전사,10,전사,YG,영업이익,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,80,사업지원,YG,영업이익,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,90,금융사업,YG,영업이익,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,100,경제사업,YG,영업이익,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,110,카드사업,YG,영업이익,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,120,보험부문,YG,영업이익,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,130,전략사업,YG,영업이익,YYYY,MM,-,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,20,중앙회,YG,영업이익,YYYY,MM,-,-,0,-,T");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,30,계열사,YG,영업이익,YYYY,MM,-,-,0,-,T");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,40,대외,YG,영업이익,YYYY,MM,-,-,0,-,T");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,50,SI,YG,영업이익,YYYY,MM,-,-,0,-,T");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,60,SM,YG,영업이익,YYYY,MM,-,-,0,-,T");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,70,상품,YG,영업이익,YYYY,MM,-,-,0,-,T");
            NHIT_DASHBOARD_MAIN.AppendLine("A,전사,10,전사,DN,당기순이익,YYYY,MM,0,0,0,0,T");
            NHIT_DASHBOARD_MAIN.AppendLine("A,전사,10,전사,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,20,중앙회,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,30,계열사,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,40,대외,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,50,SI,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,60,SM,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,70,상품,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,80,사업지원,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,90,금융사업,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,100,경제사업,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,110,카드사업,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,120,보험부문,ME,매출,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,130,전략사업,ME,매출,YYYY,MM,-,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("A,전사,10,전사,YG,영업이익,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,80,사업지원,YG,영업이익,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,90,금융사업,YG,영업이익,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,100,경제사업,YG,영업이익,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,110,카드사업,YG,영업이익,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,120,보험부문,YG,영업이익,YYYY,MM,0,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("D,본부,130,전략사업,YG,영업이익,YYYY,MM,-,0,0,0,G");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,20,중앙회,YG,영업이익,YYYY,MM,-,-,0,-,G");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,30,계열사,YG,영업이익,YYYY,MM,-,-,0,-,G");
            NHIT_DASHBOARD_MAIN.AppendLine("B,고객사,40,대외,YG,영업이익,YYYY,MM,-,-,0,-,G");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,50,SI,YG,영업이익,YYYY,MM,-,-,0,-,G");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,60,SM,YG,영업이익,YYYY,MM,-,-,0,-,G");
            NHIT_DASHBOARD_MAIN.AppendLine("C,사업유형,70,상품,YG,영업이익,YYYY,MM,-,-,0,-,G");
            NHIT_DASHBOARD_MAIN.AppendLine("A,전사,10,전사,DN,당기순이익,YYYY,MM,0,0,0,0,G");


            //string NHIT_DASHBOARD_PMS = "CR_YEAR,PROJECT_CODE,PROJECT_NAME,GUBUN_ONE,GRP_ONE_C_CODE,GRP_ONE_C_NAME,GRP_ONE_B_CODE,GRP_ONE_B_NAME,GRP_ONE_D_CODE,GRP_ONE_D_NAME,TEAM_NAME,PLAN_STR,PLAN_END,END_YN,GE_COMP,BUNLYU_CODE,MECHUL,SANPUM,JAERYO,OYJU,JICK_EMP,JICK_KYUNG,HANGAE,BUN_EMP,BUN_KYUNG,JUNSA_EMP,JUNSA_KYUNG,MECHUL_TOT,PANME_EMP,PANME_KYUNG,YOUNGUP";
            StringBuilder NHIT_DASHBOARD_PMS = new StringBuilder();
            NHIT_DASHBOARD_PMS.AppendLine("년,프로젝트코드,계약명,구분.1,사업유형 구분코드,사업유형 구분명칭,고객사 코드,고객사 명칭,본부 코드,본부 명칭,팀 명칭,계획시작일,계획종료일,종료여부,계약업체,분류코드,매출액,상품매출원가,재료비,외주비,직접인건비,직접경비,한계이익,본부간접인건비,본부간접경비,전사간접인건비,전사간접경비,매출총이익,판매관리비(人),판매관리비(경비),영업이익");
            NHIT_DASHBOARD_PMS.AppendLine("CR_YEAR,PROJECT_CODE,PROJECT_NAME,GUBUN_ONE,GRP_ONE_C_CODE,GRP_ONE_C_NAME,GRP_ONE_B_CODE,GRP_ONE_B_NAME,GRP_ONE_D_CODE,GRP_ONE_D_NAME,TEAM_NAME,PLAN_STR,PLAN_END,END_YN,GE_COMP,BUNLYU_CODE,MECHUL,SANPUM,JAERYO,OYJU,JICK_EMP,JICK_KYUNG,HANGAE,BUN_EMP,BUN_KYUNG,JUNSA_EMP,JUNSA_KYUNG,MECHUL_TOT,PANME_EMP,PANME_KYUNG,YOUNGUP");
            NHIT_DASHBOARD_PMS.AppendLine("YYYY,,,구매,50,SI,20,중앙회,80,사업지원본부,,2011-10-24,2012-03-30,완,,1,,,,,,,,,,,,,,,");
            NHIT_DASHBOARD_PMS.AppendLine(",,,용역,60,SM,30,계열사,90,금융사업본부,,,,,,2,,,,,,,,,,,,,,,");
            NHIT_DASHBOARD_PMS.AppendLine(",,,,70,상품,40,대외,100,경제사업본부,,,,,,3,,,,,,,,,,,,,,,");
            NHIT_DASHBOARD_PMS.AppendLine(",,,,,,,,110,카드사업본부,,,,,,4,,,,,,,,,,,,,,,");
            NHIT_DASHBOARD_PMS.AppendLine(",,,,,,,,120,보험사업본부,,,,,,5,,,,,,,,,,,,,,,");
            NHIT_DASHBOARD_PMS.AppendLine(",,,,,,,,130,전략사업본부,,,,,,6,,,,,,,,,,,,,,,");




            string csv = string.Empty;
            string filename = "";
            switch (rdoList.SelectedValue)
            {
                case "0":
                    csv = NHIT_DASHBOARD_EMP.ToString();
                    filename = "NHIT_DASHBOARD_EMP";
                    break;
                case "1":
                    csv = NHIT_DASHBOARD_EMP_MERGE.ToString();
                    filename = "NHIT_DASHBOARD_EMP_MERGE";
                    break;
                case "2":
                    csv = NHIT_DASHBOARD_MAIN.ToString();
                    filename = "NHIT_DASHBOARD_MAIN";
                    break;
                case "3":
                    csv = NHIT_DASHBOARD_PMS.ToString();
                    filename = "NHIT_DASHBOARD_PMS";
                    break;
            }


            Response.Clear();
            //Response.ContentType = "Application/vnd.ms-excel";
            Response.ContentType = "text/csv";
            Response.ContentEncoding = Encoding.GetEncoding(949);
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.csv", filename));
            Response.Write(csv);
            Response.End();
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Grid1Bind(file1.PostedFile);
        Grid2Bind(file2.PostedFile);
        Grid3Bind(file3.PostedFile);
        Grid4Bind(file4.PostedFile);
    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        if (grid1.Rows.Count == 0 && grid2.Rows.Count == 0 && grid3.Rows.Count == 0 && grid4.Rows.Count == 0)
        {
            PageUtility.AlertMessage("가져온 엑셀 파일이 없습니다.");
        }
        else
        {
            int count = 0;
            count += Grid1Save();
            count += Grid2Save();
            count += Grid3Save();
            count += Grid4Save();

            Response.Write(string.Format("<script>alert('{0}');location.href='{1}';</script>",
                string.Format("{0}개 행이 저장 되었습니다.", count)
                , Request.Url.AbsolutePath));
        }
    }

    #region Grid1Save()
    private int Grid1Save()
    {
        int rowEffect = 0;
        int rowEffectD = 0;
        for (int i = 0; i < grid1.Rows.Count; i++)
        {
            float fi = 0;
            string CR_YEAR = grid1.Rows[i].Cells.FromKey("CR_YEAR").Value.ToString();
            string CR_MONTH = grid1.Rows[i].Cells.FromKey("CR_MONTH").Value.ToString();
            string BONBU_NAME = grid1.Rows[i].Cells.FromKey("BONBU_NAME").Value.ToString();
            string TEAM_NAME = grid1.Rows[i].Cells.FromKey("TEAM_NAME").Value.ToString();
            string GRP_ONE_B_NAME = grid1.Rows[i].Cells.FromKey("GRP_ONE_B_NAME").Value.ToString();
            string GRP_ONE_C_NAME = grid1.Rows[i].Cells.FromKey("GRP_ONE_C_NAME").Value.ToString();
            string PROJECT_NAME = grid1.Rows[i].Cells.FromKey("PROJECT_NAME").Value.ToString();
            string EMP_NAME = grid1.Rows[i].Cells.FromKey("EMP_NAME").Value.ToString();
            float RESULT_FULL = (grid1.Rows[i].Cells.FromKey("RESULT_FULL").Value.ToString() == "" ||
                !float.TryParse(grid1.Rows[i].Cells.FromKey("RESULT_FULL").Value.ToString(), out fi)) ?
                0 : float.Parse(grid1.Rows[i].Cells.FromKey("RESULT_FULL").Value.ToString());
            float RESULT_DONG = (grid1.Rows[i].Cells.FromKey("RESULT_DONG").Value.ToString() == "" ||
                !float.TryParse(grid1.Rows[i].Cells.FromKey("RESULT_DONG").Value.ToString(), out fi)) ?
                0 : float.Parse(grid1.Rows[i].Cells.FromKey("RESULT_DONG").Value.ToString());
            float RESULT_BDONG = (grid1.Rows[i].Cells.FromKey("RESULT_BDONG").Value.ToString() == "" ||
                !float.TryParse(grid1.Rows[i].Cells.FromKey("RESULT_BDONG").Value.ToString(), out fi)) ?
                0 : float.Parse(grid1.Rows[i].Cells.FromKey("RESULT_BDONG").Value.ToString());

            rowEffectD += new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_Delete(CR_YEAR, CR_MONTH, BONBU_NAME, TEAM_NAME,
                GRP_ONE_B_NAME, GRP_ONE_C_NAME, PROJECT_NAME, EMP_NAME);

            rowEffect += new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_Insert(CR_YEAR, CR_MONTH, BONBU_NAME, TEAM_NAME,
                GRP_ONE_B_NAME, GRP_ONE_C_NAME, PROJECT_NAME, EMP_NAME, RESULT_FULL, RESULT_DONG, RESULT_BDONG);
        }
        return rowEffect;
    }
    #endregion

    #region Grid2Save()
    private int Grid2Save()
    {
        int rowEffect = 0;
        int rowEffectD = 0;
        for (int i = 0; i < grid2.Rows.Count; i++)
        {
            float fi = 0;
            string CR_YEAR = grid2.Rows[i].Cells.FromKey("CR_YEAR").Value.ToString();
            string CR_MONTH = grid2.Rows[i].Cells.FromKey("CR_MONTH").Value.ToString();

            float TARGET_FULL_RATE = (grid2.Rows[i].Cells.FromKey("TARGET_FULL_RATE").Value.ToString() == "" ||
                !float.TryParse(grid2.Rows[i].Cells.FromKey("TARGET_FULL_RATE").Value.ToString(), out fi)) ?
                0 : float.Parse(grid2.Rows[i].Cells.FromKey("TARGET_FULL_RATE").Value.ToString());

            float RESULT_FULL_RATE = (grid2.Rows[i].Cells.FromKey("RESULT_FULL_RATE").Value.ToString() == "" ||
                !float.TryParse(grid2.Rows[i].Cells.FromKey("RESULT_FULL_RATE").Value.ToString(), out fi)) ?
                0 : float.Parse(grid2.Rows[i].Cells.FromKey("RESULT_FULL_RATE").Value.ToString());

            float RESULT_DONG_RATE = (grid2.Rows[i].Cells.FromKey("RESULT_DONG_RATE").Value.ToString() == "" ||
                !float.TryParse(grid2.Rows[i].Cells.FromKey("RESULT_DONG_RATE").Value.ToString(), out fi)) ?
                0 : float.Parse(grid2.Rows[i].Cells.FromKey("RESULT_DONG_RATE").Value.ToString());

            float RESULT_BDONG_RATE = (grid2.Rows[i].Cells.FromKey("RESULT_BDONG_RATE").Value.ToString() == "" ||
                !float.TryParse(grid2.Rows[i].Cells.FromKey("RESULT_BDONG_RATE").Value.ToString(), out fi)) ?
                0 : float.Parse(grid2.Rows[i].Cells.FromKey("RESULT_BDONG_RATE").Value.ToString());

            float TARGET_DONG_RATE = (grid2.Rows[i].Cells.FromKey("TARGET_DONG_RATE").Value.ToString() == "" ||
                !float.TryParse(grid2.Rows[i].Cells.FromKey("TARGET_DONG_RATE").Value.ToString(), out fi)) ?
                0 : float.Parse(grid2.Rows[i].Cells.FromKey("TARGET_DONG_RATE").Value.ToString());

            float RESULT_FULL_RATE_MS = (grid2.Rows[i].Cells.FromKey("RESULT_FULL_RATE_MS").Value.ToString() == "" ||
                !float.TryParse(grid2.Rows[i].Cells.FromKey("RESULT_FULL_RATE_MS").Value.ToString(), out fi)) ?
                0 : float.Parse(grid2.Rows[i].Cells.FromKey("RESULT_FULL_RATE_MS").Value.ToString());

            float RESULT_DONG_RATE_MS = (grid2.Rows[i].Cells.FromKey("RESULT_DONG_RATE_MS").Value.ToString() == "" ||
                !float.TryParse(grid2.Rows[i].Cells.FromKey("RESULT_DONG_RATE_MS").Value.ToString(), out fi)) ?
                0 : float.Parse(grid2.Rows[i].Cells.FromKey("RESULT_DONG_RATE_MS").Value.ToString());

            float RESULT_BDONG_RATE_MS = (grid2.Rows[i].Cells.FromKey("RESULT_BDONG_RATE_MS").Value.ToString() == "" ||
                !float.TryParse(grid2.Rows[i].Cells.FromKey("RESULT_BDONG_RATE_MS").Value.ToString(), out fi)) ?
                0 : float.Parse(grid2.Rows[i].Cells.FromKey("RESULT_BDONG_RATE_MS").Value.ToString());

            rowEffectD += new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_MERGE_Delete(CR_YEAR, CR_MONTH);

            rowEffect += new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_MERGE_Insert(CR_YEAR, CR_MONTH,
                TARGET_FULL_RATE, RESULT_FULL_RATE, RESULT_DONG_RATE, RESULT_BDONG_RATE,
                TARGET_DONG_RATE, RESULT_FULL_RATE_MS, RESULT_DONG_RATE_MS, RESULT_BDONG_RATE_MS);
        }
        return rowEffect;
    }
    #endregion

    #region Grid3Save()
    private int Grid3Save()
    {
        int rowEffect = 0;
        int rowEffectD = 0;
        for (int i = 0; i < grid3.Rows.Count; i++)
        {
            float fi = 0;
            string GRP_ONE_CODE = grid3.Rows[i].Cells.FromKey("GRP_ONE_CODE").Value.ToString();
            string GRP_ONE_NAME = grid3.Rows[i].Cells.FromKey("GRP_ONE_NAME").Value.ToString();
            string GRP_TWO_CODE = grid3.Rows[i].Cells.FromKey("GRP_TWO_CODE").Value.ToString();
            string GRP_TWO_NAME = grid3.Rows[i].Cells.FromKey("GRP_TWO_NAME").Value.ToString();
            string GRP_THREE_CODE = grid3.Rows[i].Cells.FromKey("GRP_THREE_CODE").Value.ToString();
            string GRP_THREE_NAME = grid3.Rows[i].Cells.FromKey("GRP_THREE_NAME").Value.ToString();
            string CR_YEAR = grid3.Rows[i].Cells.FromKey("CR_YEAR").Value.ToString();
            string CR_MONTH = grid3.Rows[i].Cells.FromKey("CR_MONTH").Value.ToString();
            float TARGET_YEAR = (grid3.Rows[i].Cells.FromKey("TARGET_YEAR").Value.ToString() == "" ||
                !float.TryParse(grid3.Rows[i].Cells.FromKey("TARGET_YEAR").Value.ToString(), out fi)) ?
                0 : float.Parse(grid3.Rows[i].Cells.FromKey("TARGET_YEAR").Value.ToString());
            float TARGET_TS = (grid3.Rows[i].Cells.FromKey("TARGET_TS").Value.ToString() == "" ||
                !float.TryParse(grid3.Rows[i].Cells.FromKey("TARGET_TS").Value.ToString(), out fi)) ?
                0 : float.Parse(grid3.Rows[i].Cells.FromKey("TARGET_TS").Value.ToString());
            float RESULT_TS = (grid3.Rows[i].Cells.FromKey("RESULT_TS").Value.ToString() == "" ||
                !float.TryParse(grid3.Rows[i].Cells.FromKey("RESULT_TS").Value.ToString(), out fi)) ?
                0 : float.Parse(grid3.Rows[i].Cells.FromKey("RESULT_TS").Value.ToString());
            float DAL_RATE = (grid3.Rows[i].Cells.FromKey("DAL_RATE").Value.ToString() == "" ||
                !float.TryParse(grid3.Rows[i].Cells.FromKey("DAL_RATE").Value.ToString(), out fi)) ?
                0 : float.Parse(grid3.Rows[i].Cells.FromKey("DAL_RATE").Value.ToString());
            string TG_GUBUN = grid3.Rows[i].Cells.FromKey("TG_GUBUN").Value.ToString();

            rowEffectD += new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_MAIN_Delete(GRP_ONE_CODE, GRP_TWO_CODE, GRP_THREE_CODE, CR_YEAR, CR_MONTH, TG_GUBUN);

            rowEffect += new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_MAIN_Insert(GRP_ONE_CODE, GRP_ONE_NAME,
                GRP_TWO_CODE, GRP_TWO_NAME, GRP_THREE_CODE, GRP_THREE_NAME,
                CR_YEAR, CR_MONTH, TARGET_YEAR, TARGET_TS,
                RESULT_TS, DAL_RATE, TG_GUBUN);
        }
        return rowEffect;
    }
    #endregion

    #region Grid4Save()
    private int Grid4Save()
    {
        int rowEffect = 0;
        int rowEffectD = 0;
        for (int i = 0; i < grid4.Rows.Count; i++)
        {
            float fi = 0;
            string CR_YEAR = grid4.Rows[i].Cells.FromKey("CR_YEAR").Value.ToString();
            string PROJECT_CODE = grid4.Rows[i].Cells.FromKey("PROJECT_CODE").Value.ToString();
            string PROJECT_NAME = grid4.Rows[i].Cells.FromKey("PROJECT_NAME").Value.ToString();
            string GUBUN_ONE = grid4.Rows[i].Cells.FromKey("GUBUN_ONE").Value.ToString();
            string GRP_ONE_C_CODE = grid4.Rows[i].Cells.FromKey("GRP_ONE_C_CODE").Value.ToString();
            string GRP_ONE_C_NAME = grid4.Rows[i].Cells.FromKey("GRP_ONE_C_NAME").Value.ToString();
            string GRP_ONE_B_CODE = grid4.Rows[i].Cells.FromKey("GRP_ONE_B_CODE").Value.ToString();
            string GRP_ONE_B_NAME = grid4.Rows[i].Cells.FromKey("GRP_ONE_B_NAME").Value.ToString();
            string GRP_ONE_D_CODE = grid4.Rows[i].Cells.FromKey("GRP_ONE_D_CODE").Value.ToString();
            string GRP_ONE_D_NAME = grid4.Rows[i].Cells.FromKey("GRP_ONE_D_NAME").Value.ToString();
            string TEAM_NAME = grid4.Rows[i].Cells.FromKey("TEAM_NAME").Value.ToString();
            string PLAN_STR = grid4.Rows[i].Cells.FromKey("PLAN_STR").Value.ToString();
            string PLAN_END = grid4.Rows[i].Cells.FromKey("PLAN_END").Value.ToString();
            string END_YN = grid4.Rows[i].Cells.FromKey("END_YN").Value.ToString();
            string GE_COMP = grid4.Rows[i].Cells.FromKey("GE_COMP").Value.ToString();
            string BUNLYU_CODE = grid4.Rows[i].Cells.FromKey("BUNLYU_CODE").Value.ToString();
            float MECHUL = (grid4.Rows[i].Cells.FromKey("MECHUL").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("MECHUL").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("MECHUL").Value.ToString());
            float SANPUM = (grid4.Rows[i].Cells.FromKey("SANPUM").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("SANPUM").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("SANPUM").Value.ToString());
            float JAERYO = (grid4.Rows[i].Cells.FromKey("JAERYO").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("JAERYO").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("JAERYO").Value.ToString());
            float OYJU = (grid4.Rows[i].Cells.FromKey("OYJU").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("OYJU").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("OYJU").Value.ToString());
            float JICK_EMP = (grid4.Rows[i].Cells.FromKey("JICK_EMP").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("JICK_EMP").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("JICK_EMP").Value.ToString());
            float JICK_KYUNG = (grid4.Rows[i].Cells.FromKey("JICK_KYUNG").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("JICK_KYUNG").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("JICK_KYUNG").Value.ToString());
            float HANGAE = (grid4.Rows[i].Cells.FromKey("HANGAE").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("HANGAE").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("HANGAE").Value.ToString());
            float BUN_EMP = (grid4.Rows[i].Cells.FromKey("BUN_EMP").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("BUN_EMP").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("BUN_EMP").Value.ToString());
            float BUN_KYUNG = (grid4.Rows[i].Cells.FromKey("BUN_KYUNG").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("BUN_KYUNG").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("BUN_KYUNG").Value.ToString());
            float JUNSA_EMP = (grid4.Rows[i].Cells.FromKey("JUNSA_EMP").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("JUNSA_EMP").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("JUNSA_EMP").Value.ToString());
            float JUNSA_KYUNG = (grid4.Rows[i].Cells.FromKey("JUNSA_KYUNG").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("JUNSA_KYUNG").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("JUNSA_KYUNG").Value.ToString());
            float MECHUL_TOT = (grid4.Rows[i].Cells.FromKey("MECHUL_TOT").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("MECHUL_TOT").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("MECHUL_TOT").Value.ToString());
            float PANME_EMP = (grid4.Rows[i].Cells.FromKey("PANME_EMP").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("PANME_EMP").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("PANME_EMP").Value.ToString());
            float PANME_KYUNG = (grid4.Rows[i].Cells.FromKey("PANME_KYUNG").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("PANME_KYUNG").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("PANME_KYUNG").Value.ToString());
            float YOUNGUP = (grid4.Rows[i].Cells.FromKey("YOUNGUP").Value.ToString() == "" ||
                 !float.TryParse(grid4.Rows[i].Cells.FromKey("YOUNGUP").Value.ToString(), out fi)) ?
                 0 : float.Parse(grid4.Rows[i].Cells.FromKey("YOUNGUP").Value.ToString());

            rowEffectD += new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_PMS_Delete(CR_YEAR, PROJECT_CODE,
                GUBUN_ONE, GRP_ONE_C_CODE,
                GRP_ONE_B_CODE, GRP_ONE_D_CODE,
                TEAM_NAME);

            rowEffect += new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_PMS_Insert(CR_YEAR, PROJECT_CODE, PROJECT_NAME,
         GUBUN_ONE, GRP_ONE_C_CODE, GRP_ONE_C_NAME,
         GRP_ONE_B_CODE, GRP_ONE_B_NAME, GRP_ONE_D_CODE,
         GRP_ONE_D_NAME, TEAM_NAME, PLAN_STR,
         PLAN_END, END_YN, GE_COMP,
         BUNLYU_CODE, MECHUL, SANPUM,
         JAERYO, OYJU, JICK_EMP,
         JICK_KYUNG, HANGAE, BUN_EMP,
         BUN_KYUNG, JUNSA_EMP, JUNSA_KYUNG,
         MECHUL_TOT, PANME_EMP, PANME_KYUNG,
         YOUNGUP);

        }
        return rowEffect;
    }
    #endregion

    #region private void File1Save(HttpPostedFile fileControl)
    private void File1Save(HttpPostedFile fileControl)
    {
        if (fileControl.ContentLength > 0)
        {
            if (fileControl.ContentLength <= 20971520)
            {
                string filePathName = Server.MapPath("/_common/UploadImages/") + "tmp.csv";
                fileControl.SaveAs(filePathName);
                FileStream stream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);
                BufferedStream bRead = new BufferedStream(stream);
                StreamReader sr = new StreamReader(bRead, System.Text.Encoding.Default);
                string readString = sr.ReadToEnd().Replace("\r\n", "^");
                string[] readLine = readString.Split('^');
                if (readLine.Length - 1 > 1)
                {
                    for (int i = 0; i < readLine.Length - 1; i++)
                    {
                        if (i != 0)
                        {
                            string[] cData = readLine[i].Split(',');
                            new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_Insert(
                                cData[0], cData[1], cData[2], cData[3], cData[4], cData[5], cData[6], cData[7],
                                cData[8] == "" ? 0 : float.Parse(cData[8]),
                                cData[9] == "" ? 0 : float.Parse(cData[9]),
                                cData[10] == "" ? 0 : float.Parse(cData[10]));
                        }
                    }
                }
                else
                {
                    PageUtility.AlertMessage("파일을 확인하세요.");
                }
                sr.Dispose();
                bRead.Dispose();
                stream.Dispose();

                FileInfo file = new FileInfo(filePathName);
                file.Delete();
            }
            else
            {
                PageUtility.AlertMessage("파일 최대용량은 20MB까지 입니다.");
            }
        }
    }
    #endregion

    #region private void File2Save(HttpPostedFile filePathName)
    private void File2Save(HttpPostedFile fileControl)
    {
        if (fileControl.ContentLength > 0)
        {
            if (fileControl.ContentLength <= 20971520)
            {
                string filePathName = Server.MapPath("/_common/UploadImages/") + "tmp.csv";
                fileControl.SaveAs(filePathName);
                FileStream stream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);
                BufferedStream bRead = new BufferedStream(stream);
                StreamReader sr = new StreamReader(bRead, System.Text.Encoding.Default);
                string readString = sr.ReadToEnd().Replace("\r\n", "^");
                string[] readLine = readString.Split('^');
                if (readLine.Length - 1 > 1)
                {
                    for (int i = 0; i < readLine.Length - 1; i++)
                    {
                        if (i != 0)
                        {
                            string[] cData = readLine[i].Split(',');
                            new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_MERGE_Insert(
                                cData[0], cData[1],
                                cData[2] == "" ? 0 : float.Parse(cData[2]),
                                cData[3] == "" ? 0 : float.Parse(cData[3]),
                                cData[4] == "" ? 0 : float.Parse(cData[4]),
                                cData[5] == "" ? 0 : float.Parse(cData[5]),
                                cData[6] == "" ? 0 : float.Parse(cData[6]),
                                cData[7] == "" ? 0 : float.Parse(cData[7]),
                                cData[8] == "" ? 0 : float.Parse(cData[8]),
                                cData[9] == "" ? 0 : float.Parse(cData[9]));
                        }
                    }
                }
                else if (fileControl.ContentLength == 0)
                {

                }
                else
                {
                    PageUtility.AlertMessage("파일을 확인하세요.");
                }
                sr.Dispose();
                bRead.Dispose();
                stream.Dispose();

                FileInfo file = new FileInfo(filePathName);
                file.Delete();
            }
            else
            {
                PageUtility.AlertMessage("파일 최대용량은 20MB까지 입니다.");
            }
        }

    }
    #endregion

    #region private void File3Save(HttpPostedFile filePathName)
    private void File3Save(HttpPostedFile fileControl)
    {
        if (fileControl.ContentLength > 0)
        {
            if (fileControl.ContentLength <= 20971520)
            {
                string filePathName = Server.MapPath("/_common/UploadImages/") + "tmp.csv";
                fileControl.SaveAs(filePathName);
                FileStream stream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);
                BufferedStream bRead = new BufferedStream(stream);
                StreamReader sr = new StreamReader(bRead, System.Text.Encoding.Default);
                string readString = sr.ReadToEnd().Replace("\r\n", "^");
                string[] readLine = readString.Split('^');
                if (readLine.Length - 1 > 1)
                {
                    for (int i = 0; i < readLine.Length - 1; i++)
                    {
                        if (i != 0)
                        {
                            string[] cData = readLine[i].Split(',');
                            new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_MAIN_Insert(
                                cData[0], cData[1], cData[2], cData[3],
                                cData[4], cData[5], cData[6], cData[7],
                                cData[8] == "" ? 0 : float.Parse(cData[8]),
                                cData[9] == "" ? 0 : float.Parse(cData[9]),
                                cData[10] == "" ? 0 : float.Parse(cData[10]),
                                cData[11] == "" ? 0 : float.Parse(cData[11]), cData[12]);
                        }
                    }
                }
                else
                {
                    PageUtility.AlertMessage("파일을 확인하세요.");
                }
                sr.Dispose();
                bRead.Dispose();
                stream.Dispose();

                FileInfo file = new FileInfo(filePathName);
                file.Delete();
            }
            else
            {
                PageUtility.AlertMessage("파일 최대용량은 20MB까지 입니다.");
            }
        }

    }
    #endregion

    #region private void File4Save(HttpPostedFile filePathName)
    private void File4Save(HttpPostedFile fileControl)
    {
        if (fileControl.ContentLength > 0)
        {
            if (fileControl.ContentLength <= 20971520)
            {
                string filePathName = Server.MapPath("/_common/UploadImages/") + "tmp.csv";
                fileControl.SaveAs(filePathName);
                FileStream stream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);
                BufferedStream bRead = new BufferedStream(stream);
                StreamReader sr = new StreamReader(bRead, System.Text.Encoding.Default);
                string readString = sr.ReadToEnd().Replace("\r\n", "^");
                string[] readLine = readString.Split('^');
                if (readLine.Length - 1 > 1)
                {
                    for (int i = 0; i < readLine.Length - 1; i++)
                    {
                        if (i != 0)
                        {
                            string[] cData = readLine[i].Split(',');
                            new Biz_Bsc_Dashboard_Data().NHIT_DASHBOARD_PMS_Insert(
                                cData[0], cData[1], cData[2], cData[3],
                                cData[4], cData[5], cData[6], cData[7],
                                cData[8], cData[9], cData[10], cData[11],
                                cData[12], cData[13], cData[14], cData[15],
                                cData[16] == "" ? 0 : float.Parse(cData[16]),
                                cData[17] == "" ? 0 : float.Parse(cData[17]),
                                cData[18] == "" ? 0 : float.Parse(cData[18]),
                                cData[19] == "" ? 0 : float.Parse(cData[19]),
                                cData[20] == "" ? 0 : float.Parse(cData[20]),
                                cData[21] == "" ? 0 : float.Parse(cData[21]),
                                cData[22] == "" ? 0 : float.Parse(cData[22]),
                                cData[23] == "" ? 0 : float.Parse(cData[23]),
                                cData[24] == "" ? 0 : float.Parse(cData[24]),
                                cData[25] == "" ? 0 : float.Parse(cData[25]),
                                cData[26] == "" ? 0 : float.Parse(cData[26]),
                                cData[27] == "" ? 0 : float.Parse(cData[27]),
                                cData[28] == "" ? 0 : float.Parse(cData[28]),
                                cData[29] == "" ? 0 : float.Parse(cData[29]),
                                cData[30] == "" ? 0 : float.Parse(cData[30])
                                );
                        }
                    }
                }
                else
                {
                    PageUtility.AlertMessage("파일을 확인하세요.");
                }
                sr.Dispose();
                bRead.Dispose();
                stream.Dispose();

                FileInfo file = new FileInfo(filePathName);
                file.Delete();
            }
            else
            {
                PageUtility.AlertMessage("파일 최대용량은 20MB까지 입니다.");
            }
        }

    }
    #endregion

    #region private void Grid1Bind(HttpPostedFile postFile)
    private void Grid1Bind(HttpPostedFile postFile)
    {
        if (postFile.ContentLength > 0)
        {
            if (postFile.ContentLength <= 20971520)
            {
                string filePathName = Server.MapPath("/_common/UploadImages/") + duplicateFileName();
                postFile.SaveAs(filePathName);
                FileStream stream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);
                BufferedStream bRead = new BufferedStream(stream);
                StreamReader sr = new StreamReader(bRead, System.Text.Encoding.Default);
                string readString = sr.ReadToEnd().Replace("\r\n", "^");
                string[] readLine = readString.Split('^');

                if (readLine.Length - 1 > 1)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("CR_YEAR"));
                    dt.Columns.Add(new DataColumn("CR_MONTH"));
                    dt.Columns.Add(new DataColumn("BONBU_NAME"));
                    dt.Columns.Add(new DataColumn("TEAM_NAME"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_B_NAME"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_C_NAME"));
                    dt.Columns.Add(new DataColumn("PROJECT_NAME"));
                    dt.Columns.Add(new DataColumn("EMP_NAME"));
                    dt.Columns.Add(new DataColumn("RESULT_FULL"));
                    dt.Columns.Add(new DataColumn("RESULT_DONG"));
                    dt.Columns.Add(new DataColumn("RESULT_BDONG"));

                    for (int i = 0; i < readLine.Length - 1; i++)
                    {
                        if (i > 1)
                        {
                            string[] cData = readLine[i].Split(',');
                            DataRow dr = dt.NewRow();
                            dr["CR_YEAR"] = cData[0];
                            dr["CR_MONTH"] = cData[1].PadLeft(2,'0');
                            dr["BONBU_NAME"] = cData[2];
                            dr["TEAM_NAME"] = cData[3];
                            dr["GRP_ONE_B_NAME"] = cData[4];
                            dr["GRP_ONE_C_NAME"] = cData[5];
                            dr["PROJECT_NAME"] = cData[6];
                            dr["EMP_NAME"] = cData[7];
                            dr["RESULT_FULL"] = cData[8] == "" ? 0 : float.Parse(cData[8]);
                            dr["RESULT_DONG"] = cData[9] == "" ? 0 : float.Parse(cData[9]);
                            dr["RESULT_BDONG"] = cData[10] == "" ? 0 : float.Parse(cData[10]);
                            dt.Rows.Add(dr);
                        }
                    }

                    grid1.DataSource = dt;
                    grid1.DataBind();
                }
                else
                {
                    PageUtility.AlertMessage("파일을 확인하세요.");
                }
                sr.Dispose();
                bRead.Dispose();
                stream.Dispose();

                FileInfo file = new FileInfo(filePathName);
                file.Delete();
            }
            else
            {
                PageUtility.AlertMessage("파일 최대용량은 20MB까지 입니다.");
            }
        }
    }
    #endregion

    #region private void Grid2Bind(HttpPostedFile postFile)
    private void Grid2Bind(HttpPostedFile postFile)
    {
        if (postFile.ContentLength > 0)
        {
            if (postFile.ContentLength <= 20971520)
            {
                string filePathName = Server.MapPath("/_common/UploadImages/") + duplicateFileName();
                postFile.SaveAs(filePathName);
                FileStream stream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);
                BufferedStream bRead = new BufferedStream(stream);
                StreamReader sr = new StreamReader(bRead, System.Text.Encoding.Default);
                string readString = sr.ReadToEnd().Replace("\r\n", "^");
                string[] readLine = readString.Split('^');

                if (readLine.Length - 1 > 1)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("CR_YEAR"));
                    dt.Columns.Add(new DataColumn("CR_MONTH"));
                    dt.Columns.Add(new DataColumn("TARGET_FULL_RATE"));
                    dt.Columns.Add(new DataColumn("RESULT_FULL_RATE"));
                    dt.Columns.Add(new DataColumn("RESULT_DONG_RATE"));
                    dt.Columns.Add(new DataColumn("RESULT_BDONG_RATE"));
                    dt.Columns.Add(new DataColumn("TARGET_DONG_RATE"));
                    dt.Columns.Add(new DataColumn("RESULT_FULL_RATE_MS"));
                    dt.Columns.Add(new DataColumn("RESULT_DONG_RATE_MS"));
                    dt.Columns.Add(new DataColumn("RESULT_BDONG_RATE_MS"));

                    for (int i = 0; i < readLine.Length - 1; i++)
                    {
                        if (i > 1)
                        {
                            string[] cData = readLine[i].Split(',');
                            DataRow dr = dt.NewRow();
                            dr["CR_YEAR"] = cData[0];
                            dr["CR_MONTH"] = cData[1].PadLeft(2, '0');
                            dr["TARGET_FULL_RATE"] = cData[2];
                            dr["RESULT_FULL_RATE"] = cData[3];
                            dr["RESULT_DONG_RATE"] = cData[4];
                            dr["RESULT_BDONG_RATE"] = cData[5];
                            dr["TARGET_DONG_RATE"] = cData[6];
                            dr["RESULT_FULL_RATE_MS"] = cData[7];
                            dr["RESULT_DONG_RATE_MS"] = cData[8];
                            dr["RESULT_BDONG_RATE_MS"] = cData[9];

                            dt.Rows.Add(dr);
                        }
                    }

                    grid2.DataSource = dt;
                    grid2.DataBind();
                }
                else
                {
                    PageUtility.AlertMessage("파일을 확인하세요.");
                }
                sr.Dispose();
                bRead.Dispose();
                stream.Dispose();

                FileInfo file = new FileInfo(filePathName);
                file.Delete();
            }
            else
            {
                PageUtility.AlertMessage("파일 최대용량은 20MB까지 입니다.");
            }
        }
    }
    #endregion

    #region private void Grid3Bind(HttpPostedFile postFile)
    private void Grid3Bind(HttpPostedFile postFile)
    {
        if (postFile.ContentLength > 0)
        {
            if (postFile.ContentLength <= 20971520)
            {
                string filePathName = Server.MapPath("/_common/UploadImages/") + duplicateFileName();
                postFile.SaveAs(filePathName);
                FileStream stream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);
                BufferedStream bRead = new BufferedStream(stream);
                StreamReader sr = new StreamReader(bRead, System.Text.Encoding.Default);
                string readString = sr.ReadToEnd().Replace("\r\n", "^");
                string[] readLine = readString.Split('^');

                if (readLine.Length - 1 > 1)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("GRP_ONE_CODE"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_NAME"));
                    dt.Columns.Add(new DataColumn("GRP_TWO_CODE"));
                    dt.Columns.Add(new DataColumn("GRP_TWO_NAME"));
                    dt.Columns.Add(new DataColumn("GRP_THREE_CODE"));
                    dt.Columns.Add(new DataColumn("GRP_THREE_NAME"));
                    dt.Columns.Add(new DataColumn("CR_YEAR"));
                    dt.Columns.Add(new DataColumn("CR_MONTH"));
                    dt.Columns.Add(new DataColumn("TARGET_YEAR"));
                    dt.Columns.Add(new DataColumn("TARGET_TS"));
                    dt.Columns.Add(new DataColumn("RESULT_TS"));
                    dt.Columns.Add(new DataColumn("DAL_RATE"));
                    dt.Columns.Add(new DataColumn("TG_GUBUN"));

                    for (int i = 0; i < readLine.Length - 1; i++)
                    {
                        if (i > 1)
                        {
                            string[] cData = readLine[i].Split(',');
                            DataRow dr = dt.NewRow();
                            dr["GRP_ONE_CODE"] = cData[0];
                            dr["GRP_ONE_NAME"] = cData[1];
                            dr["GRP_TWO_CODE"] = cData[2];
                            dr["GRP_TWO_NAME"] = cData[3];
                            dr["GRP_THREE_CODE"] = cData[4];
                            dr["GRP_THREE_NAME"] = cData[5];
                            dr["CR_YEAR"] = cData[6];
                            dr["CR_MONTH"] = cData[7].PadLeft(2, '0');
                            dr["TARGET_YEAR"] = cData[8];
                            dr["TARGET_TS"] = cData[9];
                            dr["RESULT_TS"] = cData[10];
                            dr["DAL_RATE"] = cData[11];
                            dr["TG_GUBUN"] = cData[12];
                            dt.Rows.Add(dr);
                        }
                    }

                    grid3.DataSource = dt;
                    grid3.DataBind();
                }
                else
                {
                    PageUtility.AlertMessage("파일을 확인하세요.");
                }
                sr.Dispose();
                bRead.Dispose();
                stream.Dispose();

                FileInfo file = new FileInfo(filePathName);
                file.Delete();
            }
            else
            {
                PageUtility.AlertMessage("파일 최대용량은 20MB까지 입니다.");
            }
        }
    }
    #endregion

    #region private void Grid4Bind(HttpPostedFile postFile)
    private void Grid4Bind(HttpPostedFile postFile)
    {
        if (postFile.ContentLength > 0)
        {
            if (postFile.ContentLength <= 20971520)
            {
                string filePathName = Server.MapPath("/_common/UploadImages/") + duplicateFileName();
                postFile.SaveAs(filePathName);
                FileStream stream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);
                BufferedStream bRead = new BufferedStream(stream);
                StreamReader sr = new StreamReader(bRead, System.Text.Encoding.Default);
                string readString = sr.ReadToEnd().Replace("\r\n", "^");
                string[] readLine = readString.Split('^');

                if (readLine.Length - 1 > 1)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("CR_YEAR"));
                    dt.Columns.Add(new DataColumn("PROJECT_CODE"));
                    dt.Columns.Add(new DataColumn("PROJECT_NAME"));
                    dt.Columns.Add(new DataColumn("GUBUN_ONE"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_C_CODE"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_C_NAME"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_B_CODE"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_B_NAME"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_D_CODE"));
                    dt.Columns.Add(new DataColumn("GRP_ONE_D_NAME"));
                    dt.Columns.Add(new DataColumn("TEAM_NAME"));
                    dt.Columns.Add(new DataColumn("PLAN_STR"));
                    dt.Columns.Add(new DataColumn("PLAN_END"));
                    dt.Columns.Add(new DataColumn("END_YN"));
                    dt.Columns.Add(new DataColumn("GE_COMP"));
                    dt.Columns.Add(new DataColumn("BUNLYU_CODE"));
                    dt.Columns.Add(new DataColumn("MECHUL"));
                    dt.Columns.Add(new DataColumn("SANPUM"));
                    dt.Columns.Add(new DataColumn("JAERYO"));
                    dt.Columns.Add(new DataColumn("OYJU"));
                    dt.Columns.Add(new DataColumn("JICK_EMP"));
                    dt.Columns.Add(new DataColumn("JICK_KYUNG"));
                    dt.Columns.Add(new DataColumn("HANGAE"));
                    dt.Columns.Add(new DataColumn("BUN_EMP"));
                    dt.Columns.Add(new DataColumn("BUN_KYUNG"));
                    dt.Columns.Add(new DataColumn("JUNSA_EMP"));
                    dt.Columns.Add(new DataColumn("JUNSA_KYUNG"));
                    dt.Columns.Add(new DataColumn("MECHUL_TOT"));
                    dt.Columns.Add(new DataColumn("PANME_EMP"));
                    dt.Columns.Add(new DataColumn("PANME_KYUNG"));
                    dt.Columns.Add(new DataColumn("YOUNGUP"));

                    for (int i = 0; i < readLine.Length - 1; i++)
                    {
                        if (i > 1)
                        {
                            string[] cData = readLine[i].Split(',');
                            DataRow dr = dt.NewRow();

                            dr["CR_YEAR"] = cData[0];
                            dr["PROJECT_CODE"] = cData[1];
                            dr["PROJECT_NAME"] = cData[2];
                            dr["GUBUN_ONE"] = cData[3];
                            dr["GRP_ONE_C_CODE"] = cData[4];
                            dr["GRP_ONE_C_NAME"] = cData[5];
                            dr["GRP_ONE_B_CODE"] = cData[6];
                            dr["GRP_ONE_B_NAME"] = cData[7];
                            dr["GRP_ONE_D_CODE"] = cData[8];
                            dr["GRP_ONE_D_NAME"] = cData[9];
                            dr["TEAM_NAME"] = cData[10];
                            dr["PLAN_STR"] = cData[11];
                            dr["PLAN_END"] = cData[12];
                            dr["END_YN"] = cData[13];
                            dr["GE_COMP"] = cData[14];
                            dr["BUNLYU_CODE"] = cData[15];
                            dr["MECHUL"] = cData[16];
                            dr["SANPUM"] = cData[17];
                            dr["JAERYO"] = cData[18];
                            dr["OYJU"] = cData[19];
                            dr["JICK_EMP"] = cData[20];
                            dr["JICK_KYUNG"] = cData[21];
                            dr["HANGAE"] = cData[22];
                            dr["BUN_EMP"] = cData[23];
                            dr["BUN_KYUNG"] = cData[24];
                            dr["JUNSA_EMP"] = cData[25];
                            dr["JUNSA_KYUNG"] = cData[26];
                            dr["MECHUL_TOT"] = cData[27];
                            dr["PANME_EMP"] = cData[28];
                            dr["PANME_KYUNG"] = cData[29];
                            dr["YOUNGUP"] = cData[30];
                            dt.Rows.Add(dr);
                        }
                    }

                    grid4.DataSource = dt;
                    grid4.DataBind();
                }
                else
                {
                    PageUtility.AlertMessage("파일을 확인하세요.");
                }
                sr.Dispose();
                bRead.Dispose();
                stream.Dispose();

                FileInfo file = new FileInfo(filePathName);
                file.Delete();
            }
            else
            {
                PageUtility.AlertMessage("파일 최대용량은 20MB까지 입니다.");
            }
        }
    }
    #endregion

    #region private string duplicateFileName()
    private string duplicateFileName()
    {
        DirectoryInfo dir = new DirectoryInfo(Server.MapPath("/_common/UploadImages/"));
        return string.Format("{0}.{1}", dir.GetFiles().Length + 1, "csv");
    }
    #endregion
}



