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

using MicroBSC.Data;
using MicroBSC.Integration.COM.Dac;

namespace MicroBSC.Integration.COM.Biz
{
    public class Biz_Com_IF
    {
        public Biz_Com_IF()
        {
            
        }


        public enum GUBUN { TOTAL, MATCH, NOTMATCH };



        /// <summary>
        /// BSC 부서 정보와 기간계 부서정보 비교 리스트
        /// </summary>
        public DataTable Get_Diff_Dept_IF(GUBUN gubun)
        {
            Dac_Com_IF dacComIF = new Dac_Com_IF();

            DataSet DS = dacComIF.Select_Diff_DeptInfo_IF();

            string expression = "";

            if (gubun == GUBUN.MATCH)
                expression = "GUBUN='Y'";
            else if (gubun == GUBUN.NOTMATCH)
                expression = "GUBUN='N'";

            DataTable DT = DataTypeUtility.FilterSortDataTable(DS.Tables[0], expression);
            //DT = AddStatusCol(DT, GUBUN2.DEPT);

            return DT;
        }




        /// <summary>
        /// BSC 부서 정보와 기간계 부서정보 동기화
        /// </summary>
        public bool Sync_Dept_IF(string LOGIN_ID)
        {
            Dac_Com_IF dacComIF = new Dac_Com_IF();
            Dac_Com_Dept_Type dacComDeptType = new Dac_Com_Dept_Type();
            Dac_Com_Dept_Info dacComDeptInfo = new Dac_Com_Dept_Info();
            Dac_Com_Emp_Info dacComEmpInfo = new Dac_Com_Emp_Info();

            int cnt = 0;

                     
            string DEPT_REF_ID;
            string UP_DEPT_CODE;
            string UP_DEPT_ID;
            string DEPT_LEVEL;
            string DEPT_NAME;
            string DEPT_CODE;
            string DEPT_FLAG;


            string DEPT_TYPE;
            DataRow[] DeptTypeRow = dacComDeptType.Select_Com_Dept_Type().Select("", "TYPE_REF_ID DESC");
            DEPT_TYPE = DeptTypeRow[0]["TYPE_REF_ID"].ToString();


            string SORT_ORDER;
            string DEPT_DESC;
            string CREATE_USER = dacComEmpInfo.Select_EMP_REF_ID(LOGIN_ID);
            string UPDATE_USER = CREATE_USER;



            

            DataSet DS = dacComIF.Select_Diff_DeptInfo_IF();
            string expression = "GUBUN='N' AND SRC_DEPT_CODE IS NOT NULL";
            string order = " SRC_DEPT_LEVEL ASC, SRC_SORT_ORDER ASC, SRC_DEPT_CODE ASC";

            //인서트할 데이터
            DataTable inputDT = DataTypeUtility.FilterSortDataTable(DS.Tables[0], expression, order);
            //DataRow[] DR = DS.Tables[0].Select(expression, order);

            int i;

            if (inputDT.Rows.Count > 0)
            {
                IDbConnection conn = DbAgentHelper.CreateDbConnection();
                conn.Open();
                IDbTransaction trx = conn.BeginTransaction();

                try
                {
                    for (i = 0; i < inputDT.Rows.Count; i++)
                    {
                        DEPT_REF_ID = dacComDeptInfo.SelectNextDeptID(conn, trx);

                        DEPT_CODE = inputDT.Rows[i]["SRC_DEPT_CODE"].ToString();
                        DEPT_NAME = inputDT.Rows[i]["SRC_DEPT_NAME"].ToString();


                        UP_DEPT_CODE = inputDT.Rows[i]["SRC_UP_DEPT_CODE"].ToString();
                        if (UP_DEPT_CODE == "0" || UP_DEPT_CODE == "-" || UP_DEPT_CODE == "")
                            UP_DEPT_ID = "0";
                        else
                            UP_DEPT_ID = dacComDeptInfo.Select_DEPT_REF_ID(conn, trx, UP_DEPT_CODE);


                        DEPT_LEVEL = inputDT.Rows[i]["SRC_DEPT_LEVEL"].ToString();
                        SORT_ORDER = inputDT.Rows[i]["SRC_SORT_ORDER"].ToString();
                        DEPT_FLAG = "1";
                        //DEPT_TYPE = "";
                        DEPT_DESC = "";


                        cnt += dacComDeptInfo.Insert_DeptInfo(conn, trx
                                                            , DEPT_REF_ID
                                                            , UP_DEPT_ID
                                                            , DEPT_LEVEL
                                                            , DEPT_NAME
                                                            , DEPT_CODE
                                                            , DEPT_FLAG
                                                            , DEPT_TYPE
                                                            , SORT_ORDER
                                                            , DEPT_DESC
                                                            , CREATE_USER
                                                            , UPDATE_USER);
                    }

                    trx.Commit();
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                cnt++;

            if (cnt > 0)
                return true;
            else
                return false;
        }




        /// <summary>
        /// BSC 직원 정보와 기간계 직원정보 비교 리스트
        /// </summary>
        public DataTable Get_Diff_Emp_IF(GUBUN gubun, int firstRowNum, int lastRowNum)
        {
            Dac_Com_IF dacComIF = new Dac_Com_IF();
            DataSet DS;

            string option;

            if (gubun == GUBUN.MATCH)
                option = "Y";
            else if (gubun == GUBUN.NOTMATCH)
                option = "N";
            else
                option = "";

            DS = dacComIF.Select_Diff_EmpInfo_IF(option, firstRowNum, lastRowNum);

            return DS.Tables[0];
        }




        /// <summary>
        /// BSC 직원 정보와 기간계 직원정보 비교 리스트
        /// </summary>
        public int Get_Diff_Emp_IF_Count(GUBUN gubun)
        {
            Dac_Com_IF dacComIF = new Dac_Com_IF();
            int Result;


            string option = "";

            if (gubun == GUBUN.MATCH)
                option = "Y";
            else if (gubun == GUBUN.NOTMATCH)
                option = "N";

            Result = dacComIF.Select_Diff_EmpInfo_IF_Count(option);

            return Result;
        }



        public bool Sync_Emp_IF(string LOGIN_ID)
        {
            Dac_Com_IF dacComIF = new Dac_Com_IF();
            Dac_Com_Emp_Info dacComEmpInfo = new Dac_Com_Emp_Info();

            string en_use_yn = WebUtility.GetConfig("ENCRYPTION_USE_YN", "N").ToUpper();
            string encryption_oneway_mode = WebUtility.GetConfig("ENCRYPTION_ONEWAY_MODE").ToUpper();
            string encryption_key = WebUtility.GetConfig("ENCRYPTION_KEY").ToUpper();


            


            int cntEmp = 0;
            int cntRel = 0;


            //EMP_INFO에 인서트할 정보
            string EMP_REF_ID;
            string EMP_CODE;
            string LOGINID;
            string LOGINIP;
            string PASSWD;
            string EMP_NAME;
            string EMP_EMAIL;
            string POSITION_CLASS_CODE;
            string POSITION_GRP_CODE;
            string POSITION_RANK_CODE;
            string POSITION_DUTY_CODE;
            string POSITION_STAT_CODE;
            string POSITION_KIND_CODE;
            string DAILY_PHONE;
            string CELL_PHONE;
            string FAX_NUMBER;
            string JOB_STATUS;
            string ZIPCODE;
            string ADDR_1;
            string ADDR_2;
            string SIGN_PATH;
            string STAMP_PATH;
            string CREATE_TYPE;
            string CREATE_EMP_ID = dacComEmpInfo.Select_EMP_REF_ID(LOGIN_ID);
            string MODIFY_TYPE;
            string MODIFY_EMP_ID = CREATE_EMP_ID;



            //REL에 인서트할 정보
            string DEPT_REF_ID;
            string REL_STATUS;
            string BOSS_FLAG;
            string REL_DATE;
            string REL_EMP_ID;



            //임시로 사용할 정보
            string DEPT_CODE;




            int firstRow = 1;
            int lastRow = dacComIF.Select_Diff_EmpInfo_IF_Count("N");

            DataSet DS = dacComIF.Select_Diff_EmpInfo_IF("N", firstRow, lastRow);
            
            string expression = @"      SRC_EMP_CODE IS NOT NULL
                                AND     TARGET_EMP_CODE IS NULL     
                                AND     SRC_DEPT_USEYN = 'Y'";



            //인서트할 데이터
            DataTable inputDT = DataTypeUtility.FilterSortDataTable(DS.Tables[0], expression);
            //DataRow[] DR = DS.Tables[0].Select(expression);


            
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (inputDT.Rows.Count > 0)
                {
                    for (int i = 0; i < inputDT.Rows.Count; i++)
                    {

                        #region 직원정보 인서트
                        EMP_REF_ID = dacComEmpInfo.SelectNextEmpRefID(conn, trx);

                        EMP_CODE = DataTypeUtility.GetString(inputDT.Rows[i]["SRC_EMP_CODE"]);
                        LOGINID = EMP_CODE;
                        LOGINIP = "";
                        PASSWD = "1111";
                        EMP_NAME = DataTypeUtility.GetString(inputDT.Rows[i]["SRC_EMP_NAME"]);
                        EMP_EMAIL = DataTypeUtility.GetString(inputDT.Rows[i]["E_MAIL"]);
                        POSITION_CLASS_CODE = DataTypeUtility.GetString(inputDT.Rows[i]["SRC_POSITION_CLASS_CODE"]);
                        POSITION_GRP_CODE = DataTypeUtility.GetString(inputDT.Rows[i]["SRC_POSITION_GRP_CODE"]);
                        POSITION_RANK_CODE = DataTypeUtility.GetString(inputDT.Rows[i]["SRC_POSITION_RANK_CODE"]);
                        POSITION_DUTY_CODE = DataTypeUtility.GetString(inputDT.Rows[i]["SRC_POSITION_DUTY_CODE"]);
                        POSITION_STAT_CODE = "-1";
                        POSITION_KIND_CODE = "99";
                        DAILY_PHONE = "";
                        CELL_PHONE = DataTypeUtility.GetString(inputDT.Rows[i]["CELL_PHONE"]);
                        FAX_NUMBER = "";
                        JOB_STATUS = "0";
                        ZIPCODE = "";
                        ADDR_1 = "";
                        ADDR_2 = "";
                        SIGN_PATH = "";
                        STAMP_PATH = "";
                        CREATE_TYPE = "0";
                        CREATE_EMP_ID = dacComEmpInfo.Select_EMP_REF_ID(conn, trx, LOGIN_ID);
                        MODIFY_TYPE = "0";
                        MODIFY_EMP_ID = CREATE_EMP_ID;


                        if (en_use_yn.Equals("Y"))
                        {
                            PASSWD = FormsAuthentication.HashPasswordForStoringInConfigFile(PASSWD, encryption_oneway_mode);
                            EMP_EMAIL = DataTypeUtility.Encrypt(EMP_EMAIL, encryption_key);
                            CELL_PHONE = DataTypeUtility.Encrypt(CELL_PHONE, encryption_key);
                        }


                        cntEmp += dacComEmpInfo.Insert_EmpInfo(conn, trx
                                                            , EMP_REF_ID
                                                            , EMP_CODE
                                                            , LOGINID
                                                            , LOGINIP
                                                            , PASSWD
                                                            , EMP_NAME
                                                            , EMP_EMAIL
                                                            , POSITION_CLASS_CODE
                                                            , POSITION_GRP_CODE
                                                            , POSITION_RANK_CODE
                                                            , POSITION_DUTY_CODE
                                                            , POSITION_STAT_CODE
                                                            , POSITION_KIND_CODE
                                                            , DAILY_PHONE
                                                            , CELL_PHONE
                                                            , FAX_NUMBER
                                                            , JOB_STATUS
                                                            , ZIPCODE
                                                            , ADDR_1
                                                            , ADDR_2
                                                            , SIGN_PATH
                                                            , STAMP_PATH
                                                            , CREATE_TYPE
                                                            , CREATE_EMP_ID
                                                            , MODIFY_TYPE
                                                            , MODIFY_EMP_ID);
                        #endregion


                        #region REL_DEPT_EMP 인서트
                        Dac_Com_Dept_Info dacComDeptIno = new Dac_Com_Dept_Info();

                        DEPT_CODE = inputDT.Rows[i]["SRC_DEPT_CODE"].ToString();
                        DEPT_REF_ID = dacComDeptIno.Select_DEPT_REF_ID(conn, trx, DEPT_CODE);
                        REL_STATUS = "1";
                        BOSS_FLAG = "0";
                        REL_DATE = System.DateTime.Now.ToString("yyyy-MM-dd");
                        REL_EMP_ID = dacComEmpInfo.Select_EMP_REF_ID(conn, trx, LOGIN_ID);


                        cntRel += dacComIF.Insert_Rel_Dept_Emp(conn, trx
                                                            , EMP_REF_ID
                                                            , DEPT_REF_ID
                                                            , REL_STATUS
                                                            , BOSS_FLAG
                                                            , REL_DATE
                                                            , REL_EMP_ID);
                        #endregion
                    }
                }
                else
                    cntEmp++;

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
            
            if (cntEmp > 0)
                return true;
            else
                return false;
        }


        /*
        public enum GUBUN2 { DEPT, EMP };
        protected DataTable AddStatusCol(DataTable DT, GUBUN2 gubun)
        {
            DT.Columns.Add("STATUS");
            DT.Columns.Add("STATUS_IMG");


            if (gubun == GUBUN2.DEPT)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                    CompareDeptInfo(DT.Rows[i]);
            }
            else if (gubun == GUBUN2.EMP)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                    CompareEmpInfo(DT.Rows[i]);
            }

            return DT;
        }
        */
    }
}