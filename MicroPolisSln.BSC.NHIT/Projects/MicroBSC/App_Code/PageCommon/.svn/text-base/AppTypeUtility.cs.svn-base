using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Web;
using System.Net.Mail;

using MicroBSC.Biz.Common.Biz;

/// <summary>
/// Summary description for AppTypeUtility
/// </summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// Class   명		: AppTypeUtility
/// Class 내용		: 문자열변환및 유틸 클래스입니다.
/// 작  성  자		: 강신규
/// 최초작성일		: 2006.05.22
/// 최종수정자		: 
/// 최종수정일		: 
/// Services		:	
/// 주요 변경 로그	: 
/// ////////////////////////////////////////////////////////////////////////////////////
public class AppTypeUtility
{
    #region 필드/상수
        public enum SizeAlias
        {
            B = 0,
            KB = 1,
            MB = 2,
            GB = 3,
            TB = 4
        }
    #endregion

    #region 생성자

        /// <summary>
        /// 서비스명	: AppTypeUtility 생성자.
        /// 서비스내용	: AppTypeUtility 객체 인스턴스를 초기화합니다.
        /// </summary>
        public AppTypeUtility()
        {

        }

    #endregion

    #region 문자열 조작 메서드

        /// <summary>
        /// 서비스명	: ConvertString 메서드.
        /// 서비스내용	: Object 형을 String 형으로 변환합니다..
        /// </summary>
        /// <param name="oObject">문자열로 변환하고자하는 Object 형 입니다.</param>
        /// <returns>Trim 화된 String 을 반환합니다.</returns>
        public string ConvertString(object oObject)
        {
            return oObject.ToString();
        }

        /// <summary>
        /// 서비스명	: ToString 메서드.
        /// 서비스내용	: Object 형을 String 형으로 변환합니다..
        /// </summary>
        /// <param name="oObject">문자열로 변환하고자하는 Object 형 입니다.</param>
        /// <returns>Trim 화된 String 을 반환합니다.</returns>
        public string ToString(object oObject)
        {
            return oObject.ToString();
        }

        /// <summary>
        /// 서비스명	: MergeString 메서드.
        /// 서비스내용	: 문자열을 병합합니다.
        /// </summary>
        /// <param name="sItems">병합하고자하는 문자열입니다.</param>
        /// <returns>병합된 문자열을 반환합니다.</returns>
        public string MergeString(params string[] sItems)
        {
            StringBuilder clsBuilder = new StringBuilder("");

            for (int i = 0; i < sItems.Length; i++)
            {
                clsBuilder.Append(sItems[i].ToString());
            }

            return clsBuilder.ToString();
        }

        /// <summary>
        /// 서비스명	: MergeString 메서드.
        /// 서비스내용	: 문자열을 병합합니다.
        /// </summary>
        /// <param name="oItems">병합하고자하는 객체입니다.</param>
        /// <returns>병합된 문자열을 반환합니다.</returns>
        public string MergeString(params object[] oItems)
        {
            StringBuilder clsBuilder = new StringBuilder("");

            for (int i = 0; i < oItems.Length; i++)
            {
                clsBuilder.Append(oItems[i].ToString());
            }

            return clsBuilder.ToString();
        }

    #endregion

    #region MergeItem 메서드

        /// <summary>
        /// 서비스명	: MergeItem 메서드.
        /// 서비스내용	: 데이타베이스 멀티 DML 처리를 위하여 ArrayList 컬렉션에 모든 필드데이타를 설정합니다.
        /// </summary>
        /// <param name="oItems">ArrayList 컬렉션에 저장될 데이타입니다.</param>
        /// <returns>데이타베이스에 저장될 데이타를 ArrayList 컬렉션으로 담아 반환합니다.</returns>
        public ArrayList MergeItem(params object[] oItems)
        {
            ArrayList clsItems = new ArrayList();

            for (int i = 0; i < oItems.Length; i++)
            {
                clsItems.Add(oItems[i].ToString());
            }

            return clsItems;
        }


        /// <summary>
        /// 서비스명	: MergeItem 메서드.
        /// 서비스내용	: 데이타베이스 멀티 DML 처리를 위하여 1차원배열 공간에 모든 필드데이타를 설정합니다.
        /// </summary>
        /// <param name="iColumnLength">2차원 배열의 열 길이를 설정합니다.</param>
        /// <param name="oItems">1차원 배열에 저장할 데이타입니다.</param>
        /// <returns>데이타베이스에 저장될 데이타를 1차원배열로 담아 반환합니다.</returns>
        public string[] MergeItem(int iColumnLength, params object[] oItems)
        {
            //1차원 배열의 공간 확보.
            string[] sArrItems = new string[iColumnLength];

            //데이타를 2차원배열에 저장.
            if (iColumnLength == oItems.Length)
            {
                for (int x = 0, current = 0; x < iColumnLength; x++)
                {
                    sArrItems[x] = oItems[current].ToString();
                    current++;
                }
            }
            else
            {
                throw new Exception("DSPLM.QM.ApplicationFramework.DBUtiltiy.MergeItem(?,?) 메서드에서 발생된 예외로 1차원배열의 크기와 items 의 개수가 틀립니다.");
            }

            return sArrItems;
        }

        /// <summary>
        /// 서비스명	: MergeItem 메서드.
        /// 서비스내용	: 데이타베이스 멀티 DML 처리를 위하여 2차원배열 공간에 모든 필드데이타를 설정합니다.
        /// </summary>
        /// <param name="iRowLength">2차원 배열의 행 길이를 설정합니다.</param>
        /// <param name="iColumnLength">2차원 배열의 열 길이를 설정합니다.</param>
        /// <param name="oItems">2차원 배열에 저장할 데이타입니다.</param>
        /// <returns>데이타베이스에 저장될 데이타를 2차원배열로 담아 반환합니다.</returns>
        public string[,] MergeItem(int iRowLength, int iColumnLength, params object[] oItems)
        {
            //2차원 배열의 공간 확보.
            string[,] sArrItems = new string[iRowLength, iColumnLength];

            //데이타를 2차원배열에 저장.
            if ((iRowLength * iColumnLength) == oItems.Length)
            {
                for (int y = 0, current = 0; y < iRowLength; y++)
                {
                    for (int x = 0; x < iColumnLength; x++)
                    {
                        sArrItems[y, x] = oItems[current].ToString();
                        current++;
                    }
                }
            }
            else
            {
                throw new Exception("DSPLM.QM.ApplicationFramework.DBUtiltiy.MergeItem(?,?,?) 메서드에서 발생된 예외로 2차원배열의 크기와 items 의 개수가 틀립니다.");
            }

            return sArrItems;
        }

    #endregion

    #region 달력조작 메서드

        /// <summary>
        /// 서비스명	: UnbindDateFormat 메서드.
        /// 서비스내용	: 날짜(예:2002/02/02)에서 '/'를 제거합니다.
        /// </summary>
        /// <param name="sDate">'/'를 제거할 날자 문자열입니다.</param>
        /// <returns>년/월/일 로 설정된 날자에서 "/" 을 제거한 날자를 문자열로 반환합니다.</returns>
        public string UnbindDateFormat(string sDate)
        {
            if (sDate.Trim() == "" || sDate.Length != 10)
                return sDate.Trim();
            return sDate.Substring(0, 4) + sDate.Substring(5, 2) + sDate.Substring(8, 2);
        }

        /// <summary>
        /// 서비스명	: BindDateFormat 메서드.
        /// 서비스내용	: 날짜(20020202)에 '/'를 추가합니다.
        /// </summary>
        /// <param name="sDate">'/'를 추가할 날자 문자열입니다.</param>
        /// <returns>기본일자를 년/월/일로 설정하여 문자열로 반환합니다.</returns>
        public string BindDateFormat(string sDate)
        {
            if (sDate.Trim() == "" || sDate.Length != 8)
                return sDate.Trim();
            return sDate.Substring(0, 4) + "/" + sDate.Substring(4, 2) + "/" + sDate.Substring(6, 2);
        }

        /// <summary>
        /// 서비스명	: BindDateFormat 메서드.
        /// 서비스내용	: 날짜(20020202)에 원하는 Char 타입의 구분자를 추가합니다.
        /// </summary>
        /// <param name="sDate">날자 문자열입니다.</param>
        /// <param name="sSeparation">년월일을 구분할 구분자 Char 형입니다.</param>
        /// <returns>날짜(년월일)를 구분자로 구분하여 문자열로 반환합니다.</returns>
        public string BindDateFormat(string sDate, char cSeparation)
        {
            if (sDate.Trim() == "" || sDate.Length != 8)
                return sDate.Trim();
            return sDate.Substring(0, 4) + cSeparation + sDate.Substring(4, 2) + cSeparation + sDate.Substring(6, 2);
        }

        /// <summary>
        /// 서비스명	: BindTimeFormat 메서드(년/월/일/시/분).
        /// 서비스내용	: DateTime(200202021212)에 '/'를 추가합니다.
        /// </summary>
        /// <param name="sDate">'/'를 추가할 날자 문자열입니다.</param>
        /// <returns>기본일자를 년/월/일/시/분으로 설정하여 문자열로 반환합니다.</returns>
        public string BindTimeFormat(string sDateTime)
        {
            return sDateTime.Substring(0, 4) + "/" + sDateTime.Substring(4, 2) + "/" + sDateTime.Substring(6, 2) + "/" + sDateTime.Substring(8, 2) + "/" + sDateTime.Substring(10, 2);
        }

        /// <summary>
        /// 서비스명	: BindTimeFormat 메서드(년/월/일/시/분).
        /// 서비스내용	: DateTime(200202021212)을 임의 구분자 예를들면, 첫번째구분자('/') 와 두번째 구분자(:)로 하여 
        ///				  년/월/일 시:분 형식으로 변환합니다. 참고로 삼성의 표준은 년/월/일 시:분입니다.
        /// </summary>
        public string BindTimeFormat(string sDateTime, char cSeparation1, char cSeparation2)
        {
            return sDateTime.Substring(0, 4) + cSeparation1 + sDateTime.Substring(4, 2) + cSeparation1 + sDateTime.Substring(6, 2) + cSeparation1 + sDateTime.Substring(8, 2) + cSeparation2 + sDateTime.Substring(10, 2);
        }

        /// <summary>
        /// 서비스명	: Today 메서드.
        /// 서비스내용	: 오늘날짜(yyyy/mm/dd) 를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public string Today()
        {
            return this.BindDateFormat(DateTime.Today.ToString("yyyyMMdd"));
        }

        /// <summary>
        /// 서비스명	: AddDays 메서드.
        /// 서비스내용	: 현재의 일수에 지정된 일수를 더하여 (yyyy/MM/dd) 형식으로 가져옵니다.
        /// </summary>
        /// <param name="sDate">더해질 문자열날짜입니다.</param>
        /// <param name="iValue">더할 정수입니다.</param>
        /// <returns>날짜를 문자열로 반환합니다.</returns>
        public string AddDays(string sDate, int iValue)
        {
            return BindDateFormat(Convert.ToDateTime(sDate).AddDays(iValue).ToString("yyyyMMdd"), '/');
        }

        /// <summary>
        /// 서비스명	: AddDays 메서드.
        /// 서비스내용	: 현재의 일수에 지정된 일수를 더하여 원하는 구분자 방식으로 가져옵니다.
        /// </summary>
        /// <param name="sDate">더해질 문자열날짜입니다.</param>
        /// <param name="iValue">더할 정수입니다.</param>
        /// <param name="cSeparation">년월일을 구분할 구분자 Char 형입니다.</param>
        /// <returns>날짜를 문자열로 반환합니다.</returns>
        public string AddDays(string sDate, int iValue, char cSeparation)
        {
            return BindDateFormat(Convert.ToDateTime(sDate).AddDays(iValue).ToString("yyyyMMdd"), cSeparation);
        }

        /// <summary>
        /// 서비스명	: AddMonths 메서드.
        /// 서비스내용	: 현재의 달수에 지정된 달수를 더하여 원하는 구분자 방식으로 가져옵니다.
        /// </summary>
        /// <param name="sDate">더해질 문자열날짜입니다.</param>
        /// <param name="iValue">더할 정수입니다.</param>
        /// <returns>날짜를 문자열로 반환합니다.</returns>
        public string AddMonths(string sDate, int iValue)
        {
            return BindDateFormat(Convert.ToDateTime(sDate).AddMonths(iValue).ToString("yyyyMMdd"), '/');
        }

        /// <summary>
        /// 서비스명	: AddMonths 메서드.
        /// 서비스내용	: 현재의 달수에 지정된 달수를 더하여 원하는 구분자 방식으로 가져옵니다.
        /// </summary>
        /// <param name="sDate">더해질 문자열날짜입니다.</param>
        /// <param name="iValue">더할 정수입니다.</param>
        /// <param name="cSeparation">년월일을 구분할 구분자 Char 형입니다.</param>
        /// <returns>날짜를 문자열로 반환합니다.</returns>
        public string AddMonths(string sDate, int iValue, char cSeparation)
        {
            return BindDateFormat(Convert.ToDateTime(sDate).AddMonths(iValue).ToString("yyyyMMdd"), cSeparation);
        }

        /// <summary>
        /// 서비스명	: AddYears 메서드.
        /// 서비스내용	: 현재의 년수에 지정된 년수를 더하여 가져옵니다.
        /// </summary>
        /// <param name="sDate">더해질 문자열날짜입니다.</param>
        /// <param name="iValue">더할 정수입니다.</param>
        /// <returns>날짜를 문자열로 반환합니다.</returns>
        public string AddYears(string sDate, int iValue)
        {
            return BindDateFormat(Convert.ToDateTime(sDate).AddYears(iValue).ToString("yyyyMMdd"), '/');
        }

        /// <summary>
        /// 서비스명	: AddYears 메서드.
        /// 서비스내용	: 현재의 년수에 지정된 년수를 더하여 원하는 구분자 방식으로 가져옵니다.
        /// </summary>
        /// <param name="sDate">더해질 문자열날짜입니다.</param>
        /// <param name="iValue">더할 정수입니다.</param>
        /// <param name="cSeparation">년월일을 구분할 구분자 Char 형입니다.</param>
        /// <returns>날짜를 문자열로 반환합니다.</returns>
        public string AddYears(string sDate, int iValue, char cSeparation)
        {
            return BindDateFormat(Convert.ToDateTime(sDate).AddYears(iValue).ToString("yyyyMMdd"), cSeparation);
        }

        /// <summary>
        /// GetCountDiffDays
        ///     : 두 날짜 사이의 일수반환
        /// 작성자 : 강신규
        /// </summary>
        /// <param name="asDateS">YYYYMMDD형태의 문자열</param></param>
        /// <param name="asDateE">YYYYMMDD형태의 문자열</param>
        /// <returns></returns>
        public int GetCountDiffDays(string asDateS, string asDateE)
        {
            int liRet;

            if (
                asDateS.Length != 8 ||
                asDateE.Length != 8
               )
            {
                return -1;
            }

            DateTime ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                         Convert.ToInt32(asDateS.Substring(4, 2)),
                                         Convert.ToInt32(asDateS.Substring(6, 2)));
            DateTime ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                         Convert.ToInt32(asDateE.Substring(4, 2)),
                                         Convert.ToInt32(asDateE.Substring(6, 2)));

            liRet = (ldtE.Subtract(ldtS).Days) + 1;

            return liRet;
        }

        /// <summary>
        /// GetDateDiff
        ///     : 두 날짜사이의 일자를 문자배열로 반환
        /// 작성자 : 강신규    
        /// </summary>
        /// <param name="asDateS">시작일 / 시작월</param>
        /// <param name="asDateE">종료일 / 종료월</param>
        /// <returns></returns>
        public string[] GetDateDiff(string asDateS, string asDateE)
        {
            return GetDateDiff(asDateS, asDateE, false);
        }

        public string[] GetDateDiff(string asDateS, string asDateE, bool IsMonth)
        {
            string[] lsaRet;
            DateTime ldtTmp, ldtS, ldtE;

            if (IsMonth)
            {
                ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                    Convert.ToInt32(asDateS.Substring(4, 2)),
                                    1);
                ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                    Convert.ToInt32(asDateE.Substring(4, 2)),
                                    1);

                ldtE = ldtE.AddMonths(1).AddDays(-1);

            }
            else
            {
                ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                    Convert.ToInt32(asDateS.Substring(4, 2)),
                                    Convert.ToInt32(asDateS.Substring(6, 2)));
                ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                    Convert.ToInt32(asDateE.Substring(4, 2)),
                                    Convert.ToInt32(asDateE.Substring(6, 2)));
            }

            ldtTmp = ldtS;
            lsaRet = new string[(ldtE.Subtract(ldtS).Days) + 1];

            for (int i = 0; i < ((ldtE.Subtract(ldtS).Days) + 1); i++)
            {
                lsaRet[i] = ldtTmp.ToString("yyyyMMdd");

                ldtTmp = ldtS.AddDays(i + 1);
            }

            return lsaRet;
        }

        public string[] GetMonthDiff(string asDateS, string asDateE, string asDateType)
        {
            string[] lsaRet;
            int liCheck = 0;
            DateTime ldtTmp, ldtS = new DateTime(), ldtE = new DateTime();

            switch (asDateType.ToUpper())
            {
                case "D":
                    ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                        Convert.ToInt32(asDateS.Substring(4, 2)),
                                        Convert.ToInt32(asDateS.Substring(6, 2)));
                    ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                        Convert.ToInt32(asDateE.Substring(4, 2)),
                                        Convert.ToInt32(asDateE.Substring(6, 2)));

                    break;
                case "M":
                    ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                        Convert.ToInt32(asDateS.Substring(4, 2)),
                                        1);
                    ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                        Convert.ToInt32(asDateE.Substring(4, 2)),
                                        1);

                    ldtE = ldtE.AddMonths(1);
                    break;
                case "Y":
                    ldtS = new DateTime(Convert.ToInt32(asDateS),
                                        1,
                                        1);
                    ldtE = new DateTime(Convert.ToInt32(asDateE),
                                        12,
                                        1);
                    break;
            }

            liCheck = ((ldtE.Year - ldtS.Year) * 12) + (ldtE.Month - ldtS.Month);

            if (liCheck < 0)
            {
                return new string[0];
            }

            ldtTmp = ldtS;
            lsaRet = new string[liCheck];
            for (int i = 0; i < (liCheck); i++)
            {
                lsaRet[i] = ldtTmp.ToString("yyyyMM");

                ldtTmp = ldtS.AddMonths(i + 1);
            }

            return lsaRet;
        }

        /// <summary>
        /// GetDate
        ///     : 날짜 리턴
        /// 작성자 : 강신규  
        /// </summary>
        /// <param name="adt"></param>
        /// <returns></returns>
        public string GetDate(DateTime adt)
        {
            return GetDate(adt.Year, adt.Month, adt.Day);
        }

        public string GetDate()
        {
            return GetDate(System.DateTime.Now);
        }

        public string GetDate(int aYear, int aMonth, int aDay)
        {
            string tmpYear, tmpMonth, tmpDay;
            DateTime dt = new DateTime(aYear, aMonth, aDay);

            tmpYear = dt.Year.ToString();
            tmpMonth = dt.Month.ToString();
            tmpDay = dt.Day.ToString();

            if (Convert.ToInt32(tmpMonth) < 10)
                tmpMonth = "0" + tmpMonth;
            if (Convert.ToInt32(tmpDay) < 10)
                tmpDay = "0" + tmpDay;

            return (tmpYear + tmpMonth + tmpDay);
        }
        
        public string GetDateStr(DateTime aDT, string asSplit)
        {
            return GetDateStr(aDT, asSplit, false);
        }

        public string GetDateStr(DateTime aDT, string asSplit, bool abHMSView)
        {
            string tmpYear, tmpMonth, tmpDay, tmpHour, tmpMin, tmpSec;
            tmpYear = aDT.Year.ToString();
            tmpMonth= aDT.Month.ToString();
            tmpDay  = aDT.Day.ToString();
            tmpHour = aDT.Hour.ToString();
            tmpMin  = aDT.Minute.ToString();
            tmpSec  = aDT.Second.ToString();

            if (Convert.ToInt32(tmpMonth) < 10)
                tmpMonth = "0" + tmpMonth;
            if (Convert.ToInt32(tmpDay) < 10)
                tmpDay = "0" + tmpDay;
            if (Convert.ToInt32(tmpHour) < 10)
                tmpHour = "0" + tmpHour;
            if (Convert.ToInt32(tmpMin) < 10)
                tmpMin = "0" + tmpMin;
            if (Convert.ToInt32(tmpSec) < 10)
                tmpSec = "0" + tmpSec;

            if (abHMSView)
                return tmpYear + asSplit + tmpMonth + asSplit + tmpDay + " " + tmpHour + ":" + tmpMin + ":" + tmpSec;
            else
                return tmpYear + asSplit + tmpMonth + asSplit + tmpDay;
        }

        // 현재 날짜정보를 리턴한다.
        //  YYYY-MM-DD
        //  SYSDATE가 키가 되는 경우 입력되는 SYSDATE를 먼저 알기 위해 사용
        public string GetDateStr()
        {
            return GetDateStr(System.DateTime.Now, "-", false);
        }

        //public string GetDateStr(int aiYear, int aiMonth, int aiDay, string asSplit, bool abHMSView)
        //{
        //    DateTime dtCheck, dtCheck2;

        //    int iOverMonth  = 0;
        //    int iOverDay    = 0;

        //    int iTmpMonth   = 0;
        //    int iTmpMonth2  = 0;    // 현재달 혹은 12로 나눈 나머지+1
        //    int iTmpDay     = 0;
        //    int iTmpDay2    = 0;    // 현재일 혹은 마지막일자로 나눈 나머지+1

        //    iTmpMonth2 = ((aiMonth % 12) == 0 ? 12 : (aiMonth % 12));
        //    iTmpMonth2 = (aiMonth > 12 ? 12 : ())


        //    if (aiMonth < 0)
        //        iOverMonth = aiMonth;
        //    else if (aiMonth == 0)
        //        iOverMonth = System.DateTime.Now.Month;
        //    else if (aiMonth - 12 > 0)
        //        iOverMonth = aiMonth - 12;

        //    dtCheck = new DateTime(aiYear, iTmpMonth2, 1);
            
        //    // 해당월의 마지막을 구함 (이후 OverDay를 구하기 위해 사용)
        //    dtCheck = dtCheck.AddMonths(1).AddDays(-1);
        //    iTmpDay2 = ((aiDay % dtCheck.Day) == 0 ? dtCheck.Day : (aiDay % dtCheck.Day));

        //    if (aiDay < 0)
        //        iOverDay = aiDay;
        //    else if (aiDay == 0)
        //        iOverDay = System.DateTime.Now.Day;
        //    else if (aiDay - dtCheck.Day > 0)
        //        iOverDay = aiDay - dtCheck.Day;

        //    dtCheck = dtCheck.AddMonths(iOverMonth).AddDays(iOverDay);

        //    return GetDateStr(dtCheck, asSplit, abHMSView);
        //}

        //public string GetDateStr(int aiYear, int aiMonth, int aiDay)
        //{
        //    return GetDateStr(aiYear, aiMonth, aiDay, "-", false);
        //}
        
        //public string GetDateStr(int aiYear, int aiMonth, int aiDay, string asSplit)
        //{
        //    return GetDateStr(aiYear, aiMonth, aiDay, asSplit, false);
        //}

        // 현재 날짜정보를 리턴한다.
        //  YYYYMMDD HH24:MI:SS 형태
        //  SYSDATE가 키가 되는 경우 입력되는 SYSDATE를 먼저 알기 위해 사용
        public string GetDateStr(int aiAddSec)
        {
            string tmpYear, tmpMonth, tmpDay, tmpHour, tmpMin, tmpSec;
            DateTime dt = System.DateTime.Now.AddSeconds(Convert.ToDouble(aiAddSec));

            tmpYear = dt.Year.ToString();
            tmpMonth = dt.Month.ToString();
            tmpDay = dt.Day.ToString();
            tmpHour = dt.Hour.ToString();
            tmpMin = dt.Minute.ToString();
            tmpSec = dt.Second.ToString();

            if (Convert.ToInt32(tmpMonth) < 10)
                tmpMonth = "0" + tmpMonth;
            if (Convert.ToInt32(tmpDay) < 10)
                tmpDay = "0" + tmpDay;
            if (Convert.ToInt32(tmpHour) < 10)
                tmpHour = "0" + tmpHour;
            if (Convert.ToInt32(tmpMin) < 10)
                tmpMin = "0" + tmpMin;
            if (Convert.ToInt32(tmpSec) < 10)
                tmpSec = "0" + tmpSec;

            return tmpYear + tmpMonth + tmpDay + " " + tmpHour + ":" + tmpMin + ":" + tmpSec;
        }

        

        public DateTime GetDateDT(string asYYYYMMDD)
        {
            if (GetNumString(asYYYYMMDD).Length != 8)
            {
                return new DateTime();
            }

            string sYear = asYYYYMMDD.Substring(0, 4);
            string sMonth = asYYYYMMDD.Substring(4, 2);
            string sDay = asYYYYMMDD.Substring(6, 2);

            return GetDateDT(Convert.ToInt32(sYear), Convert.ToInt32(sMonth), Convert.ToInt32(sDay));
        }

        public DateTime GetDateDT(int aiYYYY, int aiMonth, int aiDay)
        {
            return new DateTime(aiYYYY, aiMonth, aiDay);
        }

    #endregion

    /// <summary>
    /// 숫자만 추출하여 반환
    /// </summary>
    /// <param name="psInput">문자열</param>
    /// <returns>숫자형 문자열</returns>
    /// 작성자 : 강신규  
    public string GetNumString(string psInput)
    {
        string sOrg = "", sTmp = "", sRet = "";
        sOrg = psInput + "";

        for (int i = 0; i < sOrg.Length; i++)
        {
            sTmp = sOrg.Substring(i, 1);
            switch (sTmp)
            {
                case ".":
                    goto case "9";
                case "0":
                    goto case "9";
                case "1":
                    goto case "9";
                case "2":
                    goto case "9";
                case "3":
                    goto case "9";
                case "4":
                    goto case "9";
                case "5":
                    goto case "9";
                case "6":
                    goto case "9";
                case "7":
                    goto case "9";
                case "8":
                    goto case "9";
                case "9":
                    sRet = sRet + sTmp;
                    break;
                default:
                    break;
            }
        }
        return sRet;
    }

    /// <summary>
    /// AddTokenDateStr
    ///     : 기본날짜형식에 토큰연결하여 리턴
    ///     : 예) 20051231 ==> 2005-12-31
    /// </summary>
    /// <param name="sToken"></param>
    /// <returns></returns>
    /// 작성자 : 강신규
    public string AddTokenDateStr(string sToken)
    {
        return AddTokenDateStr(GetDate(System.DateTime.Now));
    }

    public string AddTokenDateStr(string psDate, string sToken)
    {
        string sRet = "";

        if (GetNumString(psDate).Length == 8)
        {
            sRet = psDate.Substring(0, 4) + sToken + psDate.Substring(4, 2) + sToken + psDate.Substring(6);
        }

        return sRet;
    }

    public string GetBooleanToYN(bool isYes) 
    {
        if (isYes)
            return "Y";

        return "N";
    }

    public bool GetYNToBoolean(string yesStr)
    {
        if (yesStr.Equals("Y"))
            return true;

        return false;
    }

    #region Encode/Decode 메서드

        /// <summary>
        /// 서비스명	: TextEncode 메서드.
        /// 서비스내용	: Quotaion(Query 충돌방지) Encode 와 Html Tag 방지 Encode 를 수행합니다.
        /// </summary>
        /// <param name="oObject">Encode 할 Object 입니다.</param>
        /// <returns>Encode 된 값을 string 으로 반환합니다.</returns>
        public string TextEncode(object oObject)
        {
            return HttpUtility.HtmlEncode(this.EncodeQuotaion(oObject));
        }

        /// <summary>
        /// 서비스명	: TextDecode 메서드.
        /// 서비스내용	: Quotaion(Query 충돌방지) Decode 와 Html Tag 방지 Decode 를 수행합니다.
        /// </summary>
        /// <param name="oObject">Decode 할 Object 입니다.</param>
        /// <returns>Decode 된 값을 string 으로 반환합니다.</returns>
        public string TextDecode(object oObject)
        {
            return HttpUtility.HtmlDecode(oObject.ToString());
        }

        /// <summary>
        /// 서비스명	: EncodeQuotaion 메서드.
        /// 서비스내용	: T-SQL 문장과 충돌을 방지하기 위한 Encoding 합니다.
        /// </summary>
        /// <param name="oObject">Encode 하고자하는 Object 형 입니다.</param>
        /// <returns>Encode 된 String 을 반환합니다.</returns>
        public string EncodeQuotaion(object oObject)
        {
            return oObject.ToString().Replace("'", "''");
        }

        /// <summary>
        /// 서비스명	: HtmlEncode 메서드.
        /// 서비스내용	: Html Tag 방지를 위한 Encoding 작업을 수행하지만, Enter, Space, Tab 는 동작하도록
        ///				  BR, &nbsp;, &nbsp;&nbsp;&nbsp;&nbsp; 를 각각 "\r", "&nbsp", "\t" 로 변환한다.
        ///				  단, Tab 의 크기는 4로 한다.
        /// </summary>
        /// <param name="string">Encode 할 string 입니다.</param>
        /// <returns>Html Encode 된 값을 string 으로 반환합니다.</returns>
        public string HtmlEncode(string sValue)
        {
            sValue = HttpUtility.HtmlEncode(sValue);
            return sValue.Replace("\r", "<BR>").Replace("\n", "").Replace(" ", "&nbsp;").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
        }

        /// <summary>
        /// 서비스명	: HtmlDecode 메서드.
        /// 서비스내용	: Enter, Space, Tab 태그인 BR, &nbsp;, &nbsp;&nbsp;&nbsp;&nbsp; 을 
        ///				  "\r", "&nbsp", "\t" 로 변환한 후 Html Decoding 작업을 수행한다.
        /// </summary>
        /// <param name="string">Encode 할 string 입니다.</param>
        /// <returns>Html Encode 된 값을 string 으로 반환합니다.</returns>
        public string HtmlDecode(string sValue)
        {
            sValue = sValue.Replace("<BR>", "\r").Replace("&nbsp;", " ").Replace("&nbsp;&nbsp;&nbsp;&nbsp;", "\t");
            return HttpUtility.HtmlDecode(sValue);
        }

    #endregion

    #region 보안적용을 위한 String 암호화 관련 함수

        #region 일반문자열을 암호화문자열로 EnCoding 하는 메서드
            /// <summary>
            /// 일반문자열을 암호화문자열로 EnCoding 하는 메서드
            /// </summary>
            /// <param name="Word">일반 문자열</param>
            /// <returns>암호화된 문자열</returns>
            public string EnCoding(string Word)
            {
                StringBuilder sEncodedWord = new StringBuilder("");

                try
                {
                    if (Word == null || Word == "")
                    {
                        return "";
                    }
                    else
                    {
                        byte[] arrBuf = UnicodeEncoding.Unicode.GetBytes(Word);

                        for (int iCount = 0; iCount < arrBuf.GetLength(0); iCount++)
                        {
                            sEncodedWord.Append(arrBuf[iCount].ToString().PadLeft(3, '0'));
                        }
                        return sEncodedWord.ToString();
                    }
                }
                catch (Exception ex)
                {
                    //return sEncodedWord.ToString();
                    throw ex;
                }
            }
        #endregion

        #region 암호화문자열을 일반문자열로 DeCoding 하는 메서드
            /// <summary>
            /// 암호화문자열을 일반문자열로 DeCoding 하는 메서드
            /// </summary>
            /// <param name="Word">암호화된 문자열</param>
            /// <returns>암호가 풀린 일반 문자열</returns>
            public string DeCoding(string Word)
            {
                try
                {
                    if (Word == null || Word == "")
                    {
                        return "";
                    }
                    else
                    {
                        byte[] arrBuf = new byte[Convert.ToInt32(Word.Length / 3)];

                        int iTemp = 0;
                        int iCount = 0;
                        while (iCount < Word.Length)
                        {
                            string sBuf = Word.Substring(iCount, 3);
                            arrBuf[iTemp] = Convert.ToByte(Convert.ToInt32(sBuf));
                            iCount = iCount + 3;
                            iTemp = iTemp + 1;
                        }

                        return UnicodeEncoding.Unicode.GetString(arrBuf);
                    }
                }
                catch (Exception ex)
                {
                    //return sDecodedWord.ToString();
                    throw ex;
                }
            }


        #endregion

    #endregion

    #region 기타 메서드
        /// <summary>
        /// 서비스명	: GetDocNo 메서드.
        /// 서비스내용	: 문서번호를 가져옵니다.
        /// </summary>
        /// <param name="asPrefix"></param>
        /// <returns></returns>
        public string GetDocNo(string asPrefix)
        {
            Biz_App_Code_TypeUtility biz = new Biz_App_Code_TypeUtility();

            return biz.GetDocNo(asPrefix);
        }

        /// <summary>
        /// 서비스명	: GetRandomNumber 메서드.
        /// 서비스내용	: 0 ~ Max 에 해당되는 랜덤수를 가져옵니다.
        /// </summary>
        /// <param name="iMaxValue">최대 랜덤수입니다.</param>
        /// <returns>랜덤수를 int32 로 가져옵니다.</returns>
        public int GetRandomNumber(int iMaxValue)
        {
            Random random = new Random(unchecked((int)DateTime.Now.Ticks));
            return random.Next(iMaxValue);
        }

        /// <summary>
        /// 서비스명	: GetTempKey 메서드.
        /// 서비스내용	: 임시키를 가져옵니다.
        /// </summary>
        /// <param name="iMaxValue">원하는 길이만큼의 임시키를 가져옵니다.
        ///						    단, 길이는 1~18 사이즈만 가능합니다.</param>
        /// <returns>임시키를 string 으로 가져옵니다.</returns>
        public string GetTempKey(int length)
        {
            string sTempKey = DateTime.Now.ToString("yyyyMMhhmmssfff") + GetRandomNumber(999).ToString();
            if (length <= sTempKey.Length)
                return sTempKey.Substring(sTempKey.Length - length);
            else
                return sTempKey;
        }

        /// <summary>
        /// 서비스명    : GetSplit
        /// 서비스내용  : 구분자로 분리된 2차원배열 리턴
        /// 작성자      : 강신규 2005.12.01
        /// </summary>
        /// <param name="sStr"></param>
        /// <param name="iTerm"></param>
        /// <param name="cSep"></param>
        /// <returns></returns>

        public string[,] GetSplit(string sStr)
        {
            return GetSplit(sStr, 1);
        }

        public string[,] GetSplit(string sStr, int iTerm)
        {
            return GetSplit(sStr, iTerm, ';');
        }

        public string[,] GetSplit(string sStr, int iTerm, string sSep)
        {
            string[] saSep = new string[1];
            saSep[0] = sSep;

            if (sStr == "")
                return new string[0, 0];

            if (sStr.Substring(sStr.Length - sSep.Length, sSep.Length) == sSep)
                sStr = sStr.Substring(0, sStr.Length - sSep.Length);

            string[] saTemp = sStr.Split(saSep, StringSplitOptions.None);
            string[,] saRet = new string[saTemp.Length / iTerm, iTerm];

            int iIndex = 0;

            for (int i = 0; i < saTemp.Length; i += iTerm)
            {
                if ((i + (iTerm - 1)) < saTemp.Length)
                {
                    for (int j = 0; j < iTerm; j++)
                    {
                        saRet[iIndex, j] = saTemp[i + j];
                    }

                    iIndex++;
                }
            }

            return saRet;
        }

        public string[,] GetSplit(string sStr, int iTerm, char cSep)
        {
            if (sStr == "")
                return new string[0, 0];

            if (sStr.Substring(sStr.Length - 1, 1) == cSep.ToString())
                sStr = sStr.Substring(0, sStr.Length - 1);

            string[] saTemp = sStr.Split(cSep);
            string[,] saRet = new string[saTemp.Length / iTerm, iTerm];

            int iIndex = 0;

            for (int i = 0; i < saTemp.Length; i += iTerm)
            {
                if ((i + (iTerm - 1)) < saTemp.Length)
                {
                    for (int j = 0; j < iTerm; j++)
                    {
                        saRet[iIndex, j] = saTemp[i + j];
                    }

                    iIndex++;
                }
            }

            return saRet;
        }

        /// <summary>
        /// GetGraphMax
        ///     : 그래프의 최대값을 지정하면 그에 근접한 최대값을 리턴한다. (최대 이전자리에서 반올림)
        ///     :   1240 --> 1300
        /// 작성자 : 강신규
        /// </summary>
        /// <param name="dMax"></param>
        /// <returns></returns>
        public double GetGraphMax(double dMax)
        {
            double dReturn = 0.0;
            dReturn = Math.Ceiling(dMax / Math.Pow(10, (Math.Floor(Math.Log10(dMax) - 1))));
            dReturn = Math.Ceiling(dReturn * Math.Pow(10, Math.Floor(Math.Log10(dMax)) - 1));

            return (dReturn != dReturn ? 0.0 : dReturn);
        }

        /// <summary>
        /// GetRepHTMLCode
        ///     : 일반적인 HTML코드문자를 실제 문자로 변환하여 리턴한다.
        /// 작성자 : 강신규
        /// </summary>
        /// <param name="sHTMLCode"></param>
        /// <returns></returns>
        public string GetRepHTMLCode(string sHTMLCode)
        {
            return sHTMLCode.Replace("&lt;", "<").Replace("&gt", ">").Replace("&amp;", "&").Replace("&quot;", "'").Replace("&nbsp;", "").Replace("&trade;", "™");
        }

        /// <summary>
        /// Byte로 된 사이즈를 적절히 변환
        /// </summary>
        /// <param name="alByte"></param>
        /// <returns></returns>
        public string GetByte2Str(long alByte)
        {
            return GetByte2Str(alByte, SizeAlias.B);
        }

        public string GetByte2Str(long alByte, AppTypeUtility.SizeAlias aEnum)
        {
            int liDiv = 1024;
            string lsAlias = "";
            AppTypeUtility.SizeAlias lNextEnum = AppTypeUtility.SizeAlias.KB;

            switch (aEnum)
            {
                case AppTypeUtility.SizeAlias.B:
                    lsAlias = "B";
                    lNextEnum = AppTypeUtility.SizeAlias.KB;
                    break;
                case AppTypeUtility.SizeAlias.KB:
                    lsAlias = "KB";
                    lNextEnum = AppTypeUtility.SizeAlias.MB;
                    break;
                case AppTypeUtility.SizeAlias.MB:
                    lsAlias = "MB";
                    lNextEnum = AppTypeUtility.SizeAlias.GB;
                    break;
                case AppTypeUtility.SizeAlias.GB:
                    lsAlias = "GB";
                    lNextEnum = AppTypeUtility.SizeAlias.TB;
                    break;
                case AppTypeUtility.SizeAlias.TB:
                    lsAlias = "TB";
                    lNextEnum = AppTypeUtility.SizeAlias.TB;
                    break;
            }

            if (alByte >= 1000 && aEnum != AppTypeUtility.SizeAlias.TB)
                return GetByte2Str((long)(alByte / liDiv), lNextEnum);
            else
                //if (llCheck < 10000 || aEnum == SizeAlias.TB)
                return string.Format("{0} {1}", alByte, lsAlias);

        }

    
    #endregion



    /// <summary>
    /// 엑셀 레인지 지정시 문자로 리턴
    /// </summary>
    /// <param name="aiNum"></param>
    /// <returns></returns>
    public string GetExcelRange(int aiNum)
    {
        // 26 <= aiNum : 알파벳 1   A : 65 Z : 90
        // 26 >  aiNum : 알파벳 2

        const int CI_START = 64;
        const int CI_ALPHA = 26;

        string sRet = "";

        if (aiNum <= CI_ALPHA)
            sRet = Convert.ToString(Convert.ToChar(Convert.ToByte(aiNum + CI_START)));
        else
        {
            sRet = Convert.ToString(
                           Convert.ToChar(Convert.ToByte((aiNum / CI_ALPHA) + CI_START)) + "" +
                           Convert.ToChar(Convert.ToByte((aiNum % CI_ALPHA) + CI_START))
                   );
        }

        return sRet;
    }

    #region
        public void SendMailTest(string asFrom, string asTo, out string sReturn)
        {
            //MailMessage mess = new MailMessage();

            //mess.From = new MailAddress(asFrom);
            //mess.To.Add(new MailAddress(asTo));

            //mess.Subject = "VS2005 전자 메일 발송에 대한 테스트 건 ";

            //mess.Body = " 전자 메일을 보내는 요령에 대한 내용 입니다.";

            //SmtpClient client = new SmtpClient();
            ////client.Host = "192.168.1.32";
            //client.Host = "mail.micropolis.co.kr";
            ////client.Host = "mail.nownuri.net";
            //client.ClientCertificates
            //sReturn = "";

            //try
            //{
            //    client.Send(mess);
            //}
            //catch (SmtpException tt)
            //{
            //    sReturn = tt.ToString().Replace("\\n", "\\\\n");
            //}

            MailMessage message = new MailMessage(asFrom, asTo);
            message.Subject = "SMTP client 사용메일";
            message.Body = @"메일 테스트입니다.";

            Attachment maFile = new Attachment("C:\\UploadFiles\\ICM\\20060225\\nas20053.pdf");
            message.Attachments.Add(maFile);

            SmtpClient client = new SmtpClient("mail.micropolis.co.kr");
            // Credentials are necessary if the server requires the client 
            // to authenticate before it will send e-mail on the client's behalf.
            client.UseDefaultCredentials = true;

            sReturn = "";

            try
            {
                client.Send(message);
            }
            catch (SmtpException tt)
            {
                sReturn = tt.ToString().Replace("\n", "\\n").Replace("\r", "\\r");
            }

        }
    #endregion
}
