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
/// Biz_Bsc_Faq의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Faq Biz 클래스
/// Class 내용		: Bsc_Faq Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 서대원    
/// 최초작성일		: 2012.09.14
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
/// 
namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Faq
    {
        Dac_Bsc_Faq _data;

        public Biz_Bsc_Faq() 
        {
            _data = new Dac_Bsc_Faq();
        }


        public DataTable SelectBscFaqAll()
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq dacBscFaq = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq();
            return dacBscFaq.SelectBscFaqAll();
        }

        public DataTable SelectBscFaqAll(string question)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq dacBscFaq = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq();
            return dacBscFaq.SelectBscFaqAll(question);
        }

        public DataTable SelectBscFaqCateAll(int faq_category)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq dacBscFaq = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq();
            return dacBscFaq.SelectBscFaqCateAll(faq_category);
        }

        public DataTable SelectBscFaqIdxAll(int faq_category, int IDX)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq dacBscFaq = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq();
            return dacBscFaq.SelectBscFaqIdxAll(faq_category, IDX);
        }

        public DataTable SelectBscFaqIdxAll(int IDX)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq dacBscFaq = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq();
            return dacBscFaq.SelectBscFaqIdxAll(IDX);
        }

        public string Delete_DB(int IDX, int UPDATE_USER)
        {
            string rtnValue = string.Empty;

            int okCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq dacBscFaq = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq();

                okCnt = dacBscFaq.Delete_DB(conn, trx, IDX, UPDATE_USER);

                trx.Commit();

            }
            catch (Exception ex)
            {
                rtnValue = ex.Message;
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        public string Insert_DB(int FAQ_CATEGORY
                               ,string FAQ_QUESTION
                               ,string FAQ_ANSWER
                               ,int CREATE_USER)
        {
            string rtnValue = string.Empty;

            int okCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq dacBscFaq = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq();
                okCnt = dacBscFaq.InsertData_DB(conn, trx, FAQ_CATEGORY, FAQ_QUESTION, FAQ_ANSWER, CREATE_USER);
                trx.Commit();
 
            }
            catch (Exception ex)
            {
                rtnValue = ex.Message;
                trx.Rollback();

            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public string Update_DB(int IDX, int FAQ_CATEGORY
                               , string FAQ_QUESTION
                               , string FAQ_ANSWER
                               , int UPDATE_USER)
        {
            string rtnValue = string.Empty;

            int okCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq dacBscFaq = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Faq();
                okCnt = dacBscFaq.UpdateData_DB(conn, trx, IDX, FAQ_CATEGORY, FAQ_QUESTION, FAQ_ANSWER, UPDATE_USER);
                trx.Commit();

            }
            catch (Exception ex)
            {
                rtnValue = ex.Message;
                trx.Rollback();

            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        
    }
}
