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
    public class Dac_Bsc_Map_Kpi : DbAgentBase
    {
        public Dac_Bsc_Map_Kpi()
        { }


        public int Insert_DB(IDbConnection conn, IDbTransaction trx
                            , object estterm_ref_id
                            , object est_dept_ref_id
                            , object map_version_id
                            , object stg_ref_id
                            , object kpi_ref_id
                            , object weight
                            , object sort_order
                            , object map_kpi_type
                            , object create_user_ref_id)
        {
            string query = @"
INSERT INTO BSC_MAP_KPI
        ( 
            ESTTERM_REF_ID 
            , EST_DEPT_REF_ID
            , MAP_VERSION_ID
            , STG_REF_ID 
            , KPI_REF_ID
            , WEIGHT
            , SORT_ORDER 
            , MAP_KPI_TYPE
            , CREATE_DATE   
            , CREATE_USER   
        ) 
        VALUES 
        ( 
            @ESTTERM_REF_ID 
            , @EST_DEPT_REF_ID
            , @MAP_VERSION_ID
            , @STG_REF_ID 
            , @KPI_REF_ID
            , @WEIGHT
            , @SORT_ORDER 
            , @MAP_KPI_TYPE
            , GETDATE()
            , @CREATE_USER   
        )
";


            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[2].Value = map_version_id;
            paramArray[3] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = stg_ref_id;
            paramArray[4] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = kpi_ref_id;
            paramArray[5] = CreateDataParameter("@WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = weight;
            paramArray[6] = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[6].Value = sort_order;
            paramArray[7] = CreateDataParameter("@MAP_KPI_TYPE", SqlDbType.NVarChar);
            paramArray[7].Value = map_kpi_type;
            paramArray[8] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[8].Value = create_user_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        public int Update_DB(IDbConnection conn, IDbTransaction trx
                            , object estterm_ref_id
                            , object est_dept_ref_id
                            , object map_version_id
                            , object stg_ref_id
                            , object kpi_ref_id
                            , object weight
                            , object sort_order
                            , object map_kpi_type
                            , object update_user_ref_id)
        {
            string query = @"
UPDATE      BSC_MAP_KPI
    SET     WEIGHT           = @WEIGHT
            ,SORT_ORDER      = @SORT_ORDER 
            ,MAP_KPI_TYPE    = @MAP_KPI_TYPE
            ,UPDATE_DATE     = GETDATE()
            ,UPDATE_USER     = @UPDATE_USER
    WHERE   ESTTERM_REF_ID   = @ESTTERM_REF_ID
        AND EST_DEPT_REF_ID  = @EST_DEPT_REF_ID
        AND MAP_VERSION_ID   = @MAP_VERSION_ID
        AND STG_REF_ID       = @STG_REF_ID
        AND KPI_REF_ID       = @KPI_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[2].Value = map_version_id;
            paramArray[3] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = stg_ref_id;
            paramArray[4] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = kpi_ref_id;
            paramArray[5] = CreateDataParameter("@WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = weight;
            paramArray[6] = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[6].Value = sort_order;
            paramArray[7] = CreateDataParameter("@MAP_KPI_TYPE", SqlDbType.NVarChar);
            paramArray[7].Value = map_kpi_type;
            paramArray[8] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[8].Value = update_user_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }
    }
}
