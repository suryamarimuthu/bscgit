using System;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Text;


namespace MicroBSC.Common
{
    public class Utils
    {
        /// <summary>
        /// 텍스트를 지정된 수로 잘라서 말줄임표시와 함께 리턴
        /// </summary>
        /// <param name="orgText">원본 문자열</param>
        /// <param name="CutSize">자르고자 하는 글자 수</param>
        /// <param name="addOpt">말줄임표시 추가 여부</param>
        /// <returns></returns>
        public static string GetSubText(string orgText, int cutSize, bool addOpt)
        {
            if (orgText.Length <= 0 || orgText.Length < cutSize) return orgText;

            return (addOpt ? (orgText.Substring(0, cutSize) + "...") : (orgText.Substring(0, cutSize)));
        }

        public static string GetRemoveSlash(string str)
        {
            return str.Replace("//", "/");
        }

        public static bool IsNumeric(string str)
        {
            bool isNum = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str, i))
                    isNum = true;
                else
                    return false;
            }

            return isNum;
        }

        public static void WriteFile(string path, string msg)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true, System.Text.Encoding.Default);
            writer.WriteLine(msg);
            writer.Close();
        }

        public static string GetRedirectPath(string filePath, System.Web.HttpRequest request)
        {
            NameValueCollection nameValueCol = request.QueryString;
            string[] allKeys = nameValueCol.AllKeys;
            string queryString = "";
            bool isFirst = true;

            for (int i = 0; i < allKeys.Length; i++)
            {
                if (isFirst)
                    isFirst = false;
                else
                    queryString += "&";

                queryString += allKeys[i] + "=";

                String[] allValues = nameValueCol.GetValues(allKeys[i]);

                for (int j = 0; j < allValues.Length; j++)
                {
                    queryString += allValues[j];
                }
            }

            if (!queryString.Equals(""))
                return filePath + "?" + queryString;

            return filePath;
        }

        public static float GetZeroToSingle(string strData)
        {
            if (strData.Trim().Equals(String.Empty))
                return 0;
            return float.Parse(strData);
        }

        public static double GetZeroToDouble(string strData)
        {
            if (strData.Trim().Equals(String.Empty))
                return 0;
            return Double.Parse(strData);
        }

        public static decimal GetZeroToDecimal(string strData)
        {
            if (strData.Trim().Equals(String.Empty))
                return 0;
            return Decimal.Parse(strData);
        }

        public static long GetZeroToInt64(string strData)
        {
            if (strData.Trim().Equals(String.Empty))
                return 0;
            return long.Parse(strData);
        }

        public static int GetZeroToInt32(string strData)
        {
            if (strData.Trim().Equals(String.Empty))
                return 0;
            return int.Parse(strData);
        }

        public static short GetZeroToInt16(string strData)
        {
            if (strData.Trim().Equals(String.Empty))
                return 0;
            return short.Parse(strData);
        }

        /// <summary>
        /// 텍스트에서 HTML 관련 태그를 모두 제거하여 리턴
        /// </summary>
        /// <param name="OrgText">원본 문자열</param>
        /// <returns></returns>
        public static string RemoveHTMLTag(string OrgText)
        {
            string strRetString = "";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<script.+?/script>");
            strRetString = regex.Replace(OrgText, "");
            strRetString = System.Text.RegularExpressions.Regex.Replace(strRetString, "<style.+?/style>", "");
            strRetString = System.Text.RegularExpressions.Regex.Replace(strRetString, "<.+?>", "");

            strRetString = strRetString.Replace("onclick", "onxclick");
            strRetString = strRetString.Replace("onload", "onxload");
            strRetString = strRetString.Replace("onunload", "onunxload");
            strRetString = strRetString.Replace("&quot;", "\"");
            return strRetString;
        }

        public static string UploadFile(string fileDir, string appSettingName)
        {
            string saveFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + System.Configuration.ConfigurationSettings.AppSettings[appSettingName];
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string fileName = "";

            if (fileDir.Trim().Equals(string.Empty))
                return "";

            if (!System.IO.Directory.Exists(saveFilePath))
                System.IO.Directory.CreateDirectory(saveFilePath);

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];

                if (!file.FileName.Equals(fileDir))
                    continue;

                fileName = System.IO.Path.GetFileName(file.FileName);

                fileName = FileOverLapCheck(saveFilePath, fileName);
                file.SaveAs(saveFilePath + "\\" + fileName);					// 업로드 한다.
            }

            return fileName;
        }

        public static string UploadFileReplace(string fileDir, string appSettingName)
        {
            string saveFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + System.Configuration.ConfigurationSettings.AppSettings[appSettingName];
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string fileName = "";

            if (fileDir.Trim().Equals(string.Empty))
                return "";

            if (!System.IO.Directory.Exists(saveFilePath))
                System.IO.Directory.CreateDirectory(saveFilePath);

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];

                if (!file.FileName.Equals(fileDir))
                    continue;

                fileName = System.IO.Path.GetFileName(file.FileName);

                if (System.IO.File.Exists(saveFilePath + "\\" + fileName)) System.IO.File.Delete(saveFilePath + "\\" + fileName);
                file.SaveAs(saveFilePath + "\\" + fileName);					// 업로드 한다.
            }

            return fileName;
        }

        private static string FileOverLapCheck(string saveFilePath, string fileName)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(saveFilePath);
            System.IO.FileInfo[] files = dir.GetFiles();

            int i = 1;

            foreach (System.IO.FileInfo file in files)
            {
                while (true)
                {
                    if (file.Name.Equals(fileName))
                    {
                        fileName = "[__]" + fileName;
                        i++;
                    }
                    else
                        break;
                }
            }

            return fileName;
        }

        public static string GetAppSettingsValue(string key) 
        {
            return System.Configuration.ConfigurationSettings.AppSettings[key];
        }

        public static string GetZipCode(string zip1, string zip2)
        {
            if (zip1.Equals(String.Empty) || zip2.Equals(String.Empty))
                return "";

            return zip1.PadRight(3, ' ') + zip2.PadRight(3, ' ');
        }

        public static string GetNullToEmpty(string orgText)
        {
            if (orgText == null)
                return "";
            else
                return orgText;
        }

        public static string GetNullToEmpty(object orgDataRow)
        {
            if (orgDataRow == null)
                return "";
            else
                return orgDataRow.ToString();
        }

        /// <summary>
        /// 1 --> true 0 --> false
        /// </summary>
        public static bool ConvertByteToBoolean(byte byteData)
        {
            if (byteData == 0)
            {
                return false;
            }
            
            return false;
        }

        /// <summary>
        /// true --> 1 false --> 0
        /// </summary>
        public static byte ConvertBooleanToByte(bool boolData)
        {
            if (boolData == false)
            {
                return 0;
            }
            
            return 1;
        }

        /// <summary>
        /// 2012.10.05 심민섭 추가
        /// 파일 확장자 유효성 검사
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool FileExtensionValidator(HttpPostedFile postFile)
        {
            bool extensionCheck = false;
            string extension = string.Empty;
            if (postFile.FileName == "")
            {
                return true;
            }
            else
            {
                string file = postFile.FileName;
                string[] arrFile = file.Split('.');
                if (arrFile.Length > 0)
                {
                    extension = arrFile[arrFile.Length - 1].ToString().ToLower();

                    if (extension == "gul") { extensionCheck = true; }
                    else if (extension == "hwp") { extensionCheck = true; }
                    else if (extension == "jpg") { extensionCheck = true; }
                    else if (extension == "bmp") { extensionCheck = true; }
                    else if (extension == "gif") { extensionCheck = true; }
                    else if (extension == "png") { extensionCheck = true; }
                    else if (extension == "tif") { extensionCheck = true; }
                    else if (extension == "xls") { extensionCheck = true; }
                    else if (extension == "xlsx") { extensionCheck = true; }
                    else if (extension == "ppt") { extensionCheck = true; }
                    else if (extension == "pptx") { extensionCheck = true; }
                    else if (extension == "doc") { extensionCheck = true; }
                    else if (extension == "docx") { extensionCheck = true; }
                    else if (extension == "pdf") { extensionCheck = true; }

                }
                else
                {
                    extensionCheck = true;
                }
                return extensionCheck;
            }
        }
    }
}
