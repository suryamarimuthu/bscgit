using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Configuration;

using MicroBSC.Data;

/// <summary>
/// Summary description for Dac_Com_Low_HR_Info
/// </summary>
/// 

namespace MicroBSC.Biz.Common.Dac
{
    public class Dac_Com_Low_HR_Info : DbAgentBase
    {
        private enum Low_Object_Type
        { 
            Employee,
            Department
        }

        private string GetHRQuery(Low_Object_Type object_type)
        {
            string strEmp = ConfigurationManager.AppSettings["Object.Table.EMP"].ToString();
            string strDept = ConfigurationManager.AppSettings["Object.Table.DEPT"].ToString();
            string strQry    = "";
            if (object_type == Low_Object_Type.Employee)
            {
                //strQry = "SELECT DEPT_REF_ID,DEPT_NAME,EMP_REF_ID,EMP_NAME,RANK_CODE,RANK_NAME,CLASS_CODE,CLASS_NAME,DUTY_CODE,DUTY_NAME,GROUP_CODE,GROUP_NAME,USE_YN FROM " + strObject;
                strQry = string.Format(@"
SELECT   A.DEPT_CODE
        ,B.DEPT_NAME
        ,A.EMP_CODE
        ,A.EMP_NAME
        ,A.POS_RANK_CD
        ,A.POS_RANK_NM
        ,A.POS_CLS_CD
        ,A.POS_CLS_NM
        ,A.POS_DUTY_CD
        ,A.POS_DUTY_NM
        ,A.POS_GRP_CD
        ,A.POS_GRP_NM
        ,A.EMP_USEYN
FROM {0} A
LEFT OUTER JOIN {1} B ON B.DEPT_CODE = A.DEPT_CODE", strEmp, strDept);
            }
            else if (object_type == Low_Object_Type.Department)
            {
                //strQry    = "SELECT DEPT_REF_ID,DEPT_NAME,UP_DEPT_ID,DEPT_TYPE,USE_YN FROM "+ strObject + " WHERE USE_YN='Y'";
                strQry = string.Format(@"
SELECT   DEPT_CODE
        ,DEPT_NAME
        ,UP_DEPT_CODE
        ,DEPT_TYPE_CODE
        ,DEPT_TYPE_NAME
        ,DEPT_USEYN 
FROM {0}", strDept);
            }
            else
            {
                strQry = "";
            }

            return strQry;
        }

        private DataTable GetHRInfo(Low_Object_Type object_type)
        {
            string strProvider = ConfigurationManager.ConnectionStrings["Low_HR_DB"].ProviderName;
            DataTable dt = new DataTable();

            if (strProvider == "System.Data.SqlClient")
            {
                SqlConnection objCon = new SqlConnection();
                objCon.ConnectionString = ConfigurationManager.ConnectionStrings["Low_HR_DB"].ConnectionString;
                objCon.Open();
                if (objCon.State == ConnectionState.Open)
                {
                    SqlCommand objCmd = new SqlCommand(GetHRQuery(object_type), objCon);
                    SqlDataAdapter objDA = new SqlDataAdapter(objCmd);
                    objDA.Fill(dt);
                    objCon.Close();
                    objCon.Dispose();
                    return dt;
                }
                else
                {
                    objCon.Dispose();
                    return null;
                }
            }
            else if (strProvider == "System.Data.OracleClient")
            {
                OracleConnection objCon = new OracleConnection();
                objCon.ConnectionString = ConfigurationManager.ConnectionStrings["Low_HR_DB"].ConnectionString;
                objCon.Open();
                if (objCon.State == ConnectionState.Open)
                {
                    OracleCommand objCmd = new OracleCommand(GetHRQuery(object_type), objCon);
                    OracleDataAdapter objDA = new OracleDataAdapter(objCmd);
                    objDA.Fill(dt);
                    objCon.Close();
                    objCon.Dispose();
                    return dt;
                }
                else
                {
                    objCon.Dispose();
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public DataTable GetLowEmpInfo(out string ErrMsg)
        {
            ErrMsg = "";
            try
            {
                return this.GetHRInfo(Low_Object_Type.Employee);
            }
            catch (Exception e)
            {
                ErrMsg = e.Message;
                return null;
            }

            return null;
        }

        public DataTable GetLowDeptInfo(out string ErrMsg)
        {
            ErrMsg = "";
            try
            {
                return this.GetHRInfo(Low_Object_Type.Department);
            }
            catch (Exception e)
            {
                ErrMsg = e.Message;
                return null;
            }

            return null;
        }
    }    
}