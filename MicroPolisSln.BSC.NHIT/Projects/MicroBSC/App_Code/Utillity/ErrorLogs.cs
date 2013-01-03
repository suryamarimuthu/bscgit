using System;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace MicroBSC.Common
{
    /// <summary>
    /// Summary description for ErrorLog.
    /// </summary>
    public class ErrorLogs
    {
        public static void WriteFileError(string message, string errorUserIP, string logFile)
        {
            string msg = "";

            // 화일스트림 객체를 생성한다. 화일이 존재하지 않으면 새로 만들고 읽기쓰기 모드로 연다.
            FileStream fs = new FileStream(logFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            // stream writer 객체를 만든다. 
            StreamWriter logf = new StreamWriter(fs);

            // 읽기쓰기 포인터를 화일 끝으로 이동시킨다.
            logf.BaseStream.Seek(0, SeekOrigin.End);

            msg += "Log Entry : " + errorUserIP + "\r\n\r\n";
            msg += DateTime.Now.ToLongDateString() + " ";
            msg += DateTime.Now.ToLongTimeString() + " \r\n\r\n";
            msg += GetOnlyErrorMessage(message);
            msg += "-----------------------------------------------------------------------------------\r\n\r\n";

            logf.Write(msg); // 에러메시지를 추가한다.

            logf.Flush();             // 버퍼를 비운다.
            logf.Close();             // 화일을 닫는다.
        }

        private static string GetOnlyErrorMessage(string msg)
        {
            string rMsg = "";
            string[] errors = msg.Replace("\r\n", "|").Replace("--- 내부 예외 스택 추적의 끝 ---", "").Split('|');

            foreach (string error in errors)
            {
                if (error.IndexOf("at System") < 0)
                    rMsg += error + "\r\n";
            }

            return rMsg;
        }
    }
}
