using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MicroBSC.Biz.Common.Dac;

namespace MicroBSC.Biz.Common.Biz
{
    /// <summary>
    /// Biz_EtcCodeInfos에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_EtcCodeInfos Biz 클래스
    /// Class 내용		: EtcCodeInfos Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2006.10.23
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    /// 
    public class Biz_EtcCodeInfos : Dac_EtcCodeInfos
    {
        private string strText = ":: 전체 ::";
        private string strValue = "";

        private DataSet fillDataSet(string istrCode)
        {
            return getCatCodeList(istrCode,"Y");
        }

        private void fillDropDownList(string istrCode, DropDownList iddList, int iWidth)
        {
            if (iddList.Equals(null))
            {

            }
            else
            {
                DataSet rtnDs = getCatCodeList(istrCode,"Y");
                iddList.DataTextField = "CODE_NAME";
                iddList.DataValueField = "ETC_CODE";
                iddList.DataSource = rtnDs;
                iddList.DataBind();
                iddList.Width = (iWidth == -1) ? 120 : iWidth;
            }
        }

        private void fillDropDownList(string istrCode, DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            if (iddList.Equals(null))
            {

            }
            else
            {
                try
                {
                    DataSet rtnDs = getCatCodeList(istrCode,"Y");
                    iddList.DataSource = rtnDs;
                    iddList.DataTextField = "CODE_NAME";
                    iddList.DataValueField = "ETC_CODE";
                    iddList.DataBind();
                    iddList.Width = (iWidth == -1) ? 120 : iWidth;

                    iddList.SelectedIndex = defaultIndex;
                }
                catch
                { 
                
                }

                if (blnTotalYn)
                {
                    iddList.Items.Insert(0,new ListItem(strText, strValue));
                }
            }
        }

        private void fillDropDownList(string istrCode, DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            if (iddList.Equals(null))
            {

            }
            else
            {
                try
                {
                    DataSet rtnDs = getCatCodeList(istrCode, "Y");
                    iddList.DataSource = rtnDs;
                    iddList.DataTextField = "CODE_NAME";
                    iddList.DataValueField = "ETC_CODE";
                    iddList.DataBind();
                    if(iWidth !=0)
                        iddList.Width = (iWidth == -1) ? 120 : iWidth;

                    iddList.SelectedValue = defaultValue;
                }
                catch
                {

                }

                if (blnTotalYn)
                {
                    iddList.Items.Insert(0, new ListItem(strText, strValue));
                }
            }
        }

        //-------------------------------------------------------- 실적입력방식
        public DataSet getResultMethod(int defaultIndex)
        {
            return fillDataSet("BS001");
        }

        public void getResultMethod(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS001", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getResultMethod(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS001", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 기간유형
        public DataSet getTermType(int defaultIndex)
        {
            return fillDataSet("BS005");
        }

        public void getTermType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS005", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getTermType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS005", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- KPI유형
        public DataSet getPNUType(int defaultIndex)
        {
            return fillDataSet("BS003");
        }

        public void getPNUType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS003", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getPNUType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS003", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 누계유형
        public DataSet getColTargetType(int defaultIndex)
        {
            return fillDataSet("BS002");
        }

        public void getColTargetType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS002", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getColTargetType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS002", iddList, defaultValue, blnTotalYn, iWidth);
        }
        //-------------------------------------------------------- 측정단계
        public DataSet getCheckStep(int defaultIndex)
        {
            return fillDataSet("BS004");
        }

        public void getCheckStep(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS004", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getCheckStep(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS004", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 실적비교방법
        public DataSet getCheckType(int defaultIndex)
        {
            return fillDataSet("BS006");
        }

        public void getCheckType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS006", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getCheckType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS006", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- Initiative 작성단계
        public DataSet getInitiativeStatus(int defaultIndex)
        {
            return fillDataSet("BS007");
        }

        public void getInitiativeStatus(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS007", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void getInitiativeStatus(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS007", iddList, defaultValue, blnTotalYn, iWidth);
        }

        //-------------------------------------------------------- 점수계산방식
        public DataSet GetScoreValuationType(int defaultIndex)
        {
            return fillDataSet("BS008");
        }

        public void GetScoreValuationType(DropDownList iddList, int defaultIndex, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS008", iddList, defaultIndex, blnTotalYn, iWidth);
        }

        public void GetScoreValuationType(DropDownList iddList, string defaultValue, bool blnTotalYn, int iWidth)
        {
            fillDropDownList("BS008", iddList, defaultValue, blnTotalYn, iWidth);
        }

    }
}
