using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Integration.PMS.Dac
{
    public class Dac_Pms_Info : DbAgentBase
    {
        public Dac_Pms_Info()
        {
        }


        /// <summary>
        /// 프로젝트 리스트
        /// </summary>
        public DataTable Select_Prj_List(object start_date, object end_date)
        {
            string query = @"
SELECT 
            PMS.PROJECTID
            , PMS.PROJECTNAME
            , EMP_PM.EMP_REF_ID     AS  PM_BSC_EMP_ID
            , PMS.PMSABUN           AS  PMCODE
            , PMS.PMNAME
            , PMS.PROJECTSTARTDATE
            , PMS.PROJECTENDDATE
            , PMS.PROJENDDATE
            , PRJ_DATA.STATUS_ID
    FROM
                            PMS_INFO    PMS
        LEFT OUTER JOIN     PRJ_INFO    PRJ
            ON          PMS.PROJECTID           =   PRJ.PRJ_CODE
        LEFT OUTER JOIN     PRJ_DATA
            ON (        
                        PRJ.PRJ_REF_ID          =   PRJ_DATA.PRJ_REF_ID
                AND     PRJ_DATA.TGT_DEPT_ID    =   -1
                AND     PRJ_DATA.TGT_EMP_ID     =   -1
               )
        LEFT OUTER JOIN     COM_EMP_INFO    EMP_PM
            ON          PMS.PMSABUN             =   EMP_PM.EMP_CODE
    WHERE   
            PMS.PROJECTENDDATE  BETWEEN     @START_DATE    
                                    AND     @END_DATE
    GROUP BY
            PMS.PROJECTID
            , PMS.PROJECTNAME
            , EMP_PM.EMP_REF_ID
            , PMS.PMSABUN
            , PMS.PMNAME
            , PMS.PROJECTSTARTDATE
            , PMS.PROJECTENDDATE
            , PMS.PROJENDDATE
            , PRJ_DATA.STATUS_ID
    ORDER BY
            PMS.PROJENDDATE   DESC
";


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@START_DATE", SqlDbType.Date);
            paramArray[0].Value = start_date;
            paramArray[1] = CreateDataParameter("@END_DATE", SqlDbType.Date);
            paramArray[1].Value = end_date;

            DataTable dt = DbAgentObj.FillDataSet(query, "PRJ_LIST", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        public DataTable Select_Prj_List(IDbConnection conn, IDbTransaction trx, object PRJ_ID)
        {
            string query = @"
SELECT 
            PMS.PROJECTID
            , PMS.PROJECTNAME
            , EMP_PM.EMP_REF_ID     AS  PM_BSC_EMP_ID
            , PMS.PMNAME
            , PMS.TEAM_BSC_DEPT_ID
            , PMS.PROJECTSTARTDATE
            , PMS.PROJECTENDDATE
            , PMS.PROJENDDATE

    FROM
                            PMS_INFO        PMS
        LEFT OUTER JOIN     COM_EMP_INFO    EMP_PM
            ON  PMS.PMSABUN     =   EMP_PM.EMP_CODE
    WHERE   
            PROJECTID           =   @PRJ_ID
    GROUP BY
            PROJECTID
            , PROJECTNAME
            , EMP_PM.EMP_REF_ID
            , PMNAME
            , TEAM_BSC_DEPT_ID
            , PROJECTSTARTDATE
            , PROJECTENDDATE
            , PROJENDDATE

    ORDER BY
            PROJECTSTARTDATE    ASC
";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;

            DataTable dt = DbAgentObj.FillDataSet(conn, trx, query, "PRJ_LIST", null, paramArray, CommandType.Text).Tables[0];
            
            return dt;
        }




        public DataTable Select_Prj_Detail(DataTable dtCol_List, object PRJ_ID, object start_date, object end_date)
        {
            StringBuilder colList = new StringBuilder();
            for (int i = 0; i < dtCol_List.Rows.Count; i++)
            {
                if (colList.Length > 0)
                    colList.Append(", ");
                colList.Append(dtCol_List.Rows[i]["PRJ_COL_ID"].ToString());
            }


            string query = string.Format(@"
SELECT 
            {0}
            , EMP_PM.EMP_REF_ID     AS  PM_BSC_EMP_ID
            , EMP_EMP.EMP_REF_ID    AS  EMPLOYEE_BSC_EMP_ID
            , DEPT.DEPT_REF_ID      AS  TEAM_BSC_DEPT_ID
    FROM
            PMS_INFO    PMS
        LEFT OUTER JOIN     COM_EMP_INFO    EMP_PM
            ON  PMS.PMSABUN         =   EMP_PM.EMP_CODE
        LEFT OUTER JOIN     COM_EMP_INFO    EMP_EMP
            ON  PMS.EMPLOYEESABUN   =   EMP_EMP.EMP_CODE
        LEFT OUTER JOIN     COM_DEPT_INFO   DEPT
            ON  PMS.TEAMERPCODE     =   DEPT.DEPT_CODE
    WHERE
            PROJECTID          =   @PROJECTID
        AND PROJECTENDDATE      BETWEEN     @START_DATE    
                                    AND     @END_DATE
    ORDER BY
            EMPLOYEE_BSC_EMP_ID  ASC
", colList.ToString());


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@PROJECTID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;
            paramArray[1] = CreateDataParameter("@START_DATE", SqlDbType.Date);
            paramArray[1].Value = start_date;
            paramArray[2] = CreateDataParameter("@END_DATE", SqlDbType.Date);
            paramArray[2].Value = end_date;

            DataTable dt = DbAgentObj.FillDataSet(query, "PRJ_DETAIL", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable Select_Prj_Detail(IDbConnection conn, IDbTransaction trx, object PRJ_ID)
        {
            string query = @"
SELECT 
            PROJECTID
            , PROJECTNAME
            --, PMID        --ERP에서의 직원ID
            , PM_BSC_EMP_ID
            , PMNAME
            , CUSTOMERID
            , CUSTOMERNAME
            , BUSSCHARGEEMPID
            , BUSSCHARGEEMPNAME
            , CONTCHARGEEMPID
            , CONTCHARGEEMPNAME
            , CONTRACTSTARTDATE
            , CONTRACTENDDATE
            , PROJECTSTARTDATE
            , PROJECTENDDATE
            , PROJENDDATE
            --, TEAMID      --ERP에서의 팀ID
            , TEAM_BSC_DEPT_ID
            , TEAMNAME
            , TOTALCOSTPRICE
            , TOTALSELLPRICE
            , TOTALGAINRATE
            , TOTALGAINPRICE
            , BUDGETCOSTPRICE
            , LABORCOSTPRICE
            , EQUIPCOSTPRICE
            , SALECONTPRICE
            , SALECONTVATPRICE
            , PROJOWNLABORMM
            , PREOWNLABORMM
            , OUTLABORMM
            , PLANPROGRESS
            , REALPROGRESS
            --, EMPLOYEEID      --ERP에서의 직원ID
            , EMPLOYEE_BSC_EMP_ID
            , EMPLOYEENAME
            , CGRADECODE
            , EMPGRADECODE
            , DTINVOLVESTARTDATE
            , DTINVOLVEENDDATE
            , EMPLOYEEROLEID
            , EMPLOYEEROLENAME
            , TOTALWORKTIME
            , VALUATIONJUMSU
            , PROJSTATUS
            , PROJENDTYPEID
            , PROJENDTYPENAME
            , PMSABUN           AS  PMCODE
            , TEAMERPCODE       AS  TEAMCODE
            , EMPLOYEESABUN     AS  EMPLOYEECODE
            , PROJECTGUBUN
            , ENDDATERATE
            , DALSUNGPROGRESS
            , EMPGRADENAME
    FROM
            PMS_INFO
    WHERE
            PROJECTID          =   @PROJECTID
    ORDER BY
            EMPLOYEE_BSC_EMP_ID  ASC
";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@PROJECTID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;

            DataTable dt = DbAgentObj.FillDataSet(conn, trx, query, "PRJ_DETAIL", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public int Insert_From_Vw_Bsc_Pms(IDbConnection conn, IDbTransaction trx
                                        , object start_date
                                        , object end_date
                                        , object prj_id_list
                                        , string colList)
        {
            string query = string.Format(@"
INSERT INTO
            PMS_INFO
    (
            {0}
            , PM_BSC_EMP_ID
            , EMPLOYEE_BSC_EMP_ID
            , TEAM_BSC_DEPT_ID
    )
    SELECT
            {0}
            , EMP_PM.EMP_REF_ID     AS  PM_BSC_EMP_ID
            , EMP_EMP.EMP_REF_ID    AS  EMPLOYEE_BSC_EMP_ID
            , DEPT.DEPT_REF_ID      AS  TEAM_BSC_DEPT_ID
    FROM
            nhitpms.VW_BSC_PMS      VW
        LEFT OUTER JOIN     COM_EMP_INFO    EMP_PM
            ON  VW.PMSABUN         =   EMP_PM.EMP_CODE
        LEFT OUTER JOIN     COM_EMP_INFO    EMP_EMP
            ON  VW.EMPLOYEESABUN   =   EMP_EMP.EMP_CODE
        LEFT OUTER JOIN     COM_DEPT_INFO   DEPT
            ON  VW.TEAMERPCODE     =   DEPT.DEPT_CODE
    WHERE
            VW.PROJECTENDDATE      BETWEEN     @START_DATE
                                       AND     @END_DATE
        AND VW.PMSABUN          IS NOT NULL
        AND VW.TEAMERPCODE      IS NOT NULL
        AND VW.EMPLOYEESABUN    IS NOT NULL
        AND EMP_PM.EMP_REF_ID   IS NOT NULL
        AND EMP_EMP.EMP_REF_ID  IS NOT NULL
        AND DEPT.DEPT_REF_ID    IS NOT NULL
        AND VW.PROJECTID        IN ({1})
", colList, prj_id_list);

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@START_DATE", SqlDbType.NVarChar);
            paramArray[0].Value = start_date;
            paramArray[1] = CreateDataParameter("@END_DATE", SqlDbType.NVarChar);
            paramArray[1].Value = end_date;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;        
        }




        public int Delete_Pms_info(IDbConnection conn, IDbTransaction trx
                                        , object prj_id_list)
        {
            string query = string.Format(@"
DELETE FROM     PMS_INFO
    WHERE       PROJECTID  IN   ({0})
", prj_id_list);



            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, null);

            return affectedRow;
        }





        public DataTable Select_Vw_ProjectID(object start_date, object end_date)
        {
            string query = @"
SELECT      VW.PROJECTID
            , PRJ_DATA.STATUS_ID
    FROM                    nhitpms.VW_BSC_PMS  VW
        LEFT OUTER JOIN     PRJ_INFO    PRJ
            ON  VW.PROJECTID                    =   PRJ.PRJ_CODE
        LEFT OUTER JOIN     PRJ_DATA
            ON (        PRJ.PRJ_REF_ID          =   PRJ_DATA.PRJ_REF_ID
                AND     PRJ_DATA.TGT_DEPT_ID    =   -1
                AND     PRJ_DATA.TGT_EMP_ID     =   -1
               )
    WHERE   
            VW.PROJECTENDDATE   BETWEEN     @START_DATE 
                                    AND     @END_DATE
        AND VW.PMSABUN          IS NOT NULL
        AND VW.TEAMERPCODE      IS NOT NULL
        AND VW.EMPLOYEESABUN    IS NOT NULL
    GROUP BY
            VW.PROJECTID
            , PRJ_DATA.STATUS_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@START_DATE", SqlDbType.NVarChar);
            paramArray[0].Value = start_date;
            paramArray[1] = CreateDataParameter("@END_DATE", SqlDbType.NVarChar);
            paramArray[1].Value = end_date;

            DataTable dt = DbAgentObj.FillDataSet(query, "VW_PRJ_LIST", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }




        public DataTable Select_Prjdata_From_Vw(IDbConnection conn, IDbTransaction trx
                                            , object prj_id_list)
        {
            string query = string.Format(@"
SELECT
        PROJECTID
        , PROJECTNAME
        , PMID
        , PMSABUN
        , PMNAME
        , CUSTOMERID
        , CUSTOMERNAME
        , BUSSCHARGEEMPID
        , BUSSCHARGEEMPSABUN
        , BUSSCHARGEEMPNAME
        , CONTCHARGEEMPID
        , CONTCHARGEEMPSABUN
        , CONTCHARGEEMPNAME
        , CONTRACTSTARTDATE
        , CONTRACTENDDATE
        , PROJECTSTARTDATE
        , PROJECTENDDATE
        , PROJENDDATE
        , PROJECTGUBUN
        , ENDDATERATE
        , TEAMID
        , TEAMERPCODE
        , TEAMNAME
        , TOTALCOSTPRICE
        , TOTALSELLPRICE
        , TOTALGAINRATE
        , TOTALGAINPRICE
        , BUDGETCOSTPRICE
        , LABORCOSTPRICE
        , EQUIPCOSTPRICE
        , SALECONTPRICE
        , SALECONTVATPRICE
        , PROJOWNLABORMM
        , PREOWNLABORMM
        , OUTLABORMM
        , PLANPROGRESS
        , REALPROGRESS
        , DALSUNGPROGRESS
        , EMPLOYEEID
        , EMPLOYEESABUN
        , EMPLOYEENAME
        , EMPGRADECODE
        , EMPGRADENAME
        , DTINVOLVESTARTDATE
        , DTINVOLVEENDDATE
        , EMPLOYEEROLEID
        , EMPLOYEEROLENAME
        , TOTALWORKTIME
        , VALUATIONJUMSU
        , PROJSTATUS
        , PROJENDTYPEID
        , PROJENDTYPENAME
FROM
        nhitpms.VW_BSC_PMS
WHERE   PROJECTID   IN   ({0})
", prj_id_list.ToString());

            DataTable DT = DbAgentObj.FillDataSet(conn, trx, query, "COL_VAL", null, null, CommandType.Text).Tables[0];

            return DT;
        }
    }
}
