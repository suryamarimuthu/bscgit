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

namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Mbo_Kpi_Classification : DbAgentBase
    {
        public Dac_Bsc_Mbo_Kpi_Classification()
        { }


        public DataTable Select_DB(IDbConnection conn, IDbTransaction trx
                                , object estterm_ref_id
                                , object emp_ref_id
                                , object kpi_ref_id
                                , object org_kpi_ref_id
                                , object kpi_class_ref_id)
        {
            string query = @"
SELECT      ESTTERM_REF_ID
            , EMP_REF_ID
            , KPI_REF_ID
            , ORG_KPI_REF_ID
            , KPI_CLASS_REF_ID
    FROM    BSC_MBO_KPI_CLASSIFICATION
    WHERE   
            (  ESTTERM_REF_ID      = @ESTTERM_REF_ID	    OR @ESTTERM_REF_ID      = 0  )
        AND (  EMP_REF_ID          = @EMP_REF_ID	        OR @EMP_REF_ID          = 0  )
        AND (  KPI_REF_ID          = @KPI_REF_ID	        OR @KPI_REF_ID          = 0  )
        AND (  ORG_KPI_REF_ID      = @ORG_KPI_REF_ID	    OR @ORG_KPI_REF_ID      = 0  )
        AND (  KPI_CLASS_REF_ID    = @KPI_CLASS_REF_ID	    OR @KPI_CLASS_REF_ID    =''  )

";
            IDbDataParameter[] paramArray = paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;
            paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = kpi_ref_id;
            paramArray[3] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value = org_kpi_ref_id;
            paramArray[4] = CreateDataParameter("@KPI_CLASS_REF_ID", SqlDbType.NVarChar);
            paramArray[4].Value = kpi_class_ref_id;

            DataTable dt = DbAgentObj.FillDataSet(conn, trx, query, "BSC_MBO_KPI_CLASSIFICATION", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }



  

        public int Insert_DB(IDbConnection conn, IDbTransaction trx
                                , object estterm_ref_id
                                , object emp_ref_id
                                , object kpi_ref_id
                                , object org_kpi_ref_id
                                , object kpi_class_ref_id
                                , object create_user_ref_id)
        {
            string query = @"
INSERT INTO     BSC_MBO_KPI_CLASSIFICATION
            (
                ESTTERM_REF_ID
                , EMP_REF_ID
                , KPI_REF_ID
                , ORG_KPI_REF_ID
                , KPI_CLASS_REF_ID
                , CREATE_USER
            )
    VALUES
            (
                @ESTTERM_REF_ID
                , @EMP_REF_ID
                , @KPI_REF_ID
                , @ORG_KPI_REF_ID
                , @KPI_CLASS_REF_ID
                , @CREATE_USER
            )
";
            IDbDataParameter[] paramArray = paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;
            paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = kpi_ref_id;
            paramArray[3] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value = org_kpi_ref_id;
            paramArray[4] = CreateDataParameter("@KPI_CLASS_REF_ID", SqlDbType.NVarChar);
            paramArray[4].Value = kpi_class_ref_id;
            paramArray[5] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[5].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }
    }
}
