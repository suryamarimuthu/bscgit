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
    public class Dac_Bsc_Interface_Dicode : DbAgentBase
    {
        public DataTable Select_DB(IDbConnection conn, IDbTransaction trx
                                    , object dicode)
        {
            string query = @"
SELECT  DICODE
        , NAME
        , SOURCE_ID
        , INPUT_TYPE
        , DEFINITION
        , USE_YN
        , QUERY
        , CREATE_USER
        , UPDATE_USER
        , DAILYKPI_YN
    FROM    BSC_INTERFACE_DICODE
    WHERE   DICODE = @DICODE
";

            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@DICODE", SqlDbType.NVarChar);
            paramArray[0].Value = dicode;

            return DbAgentObj.FillDataSet(conn, trx, query, "BSC_INTERFACE_DICODE", null, paramArray, CommandType.Text).Tables[0];
        }


        public DataTable Select_DB(object dicode
                                    , object name
                                    , object input_type)
        {
            string query = @"
SELECT  DI.DICODE
        ,DI.NAME
        ,DI.SOURCE_ID
        ,DS.SOURCE_NAME
        ,DI.INPUT_TYPE
        ,DI.DEFINITION
        ,DI.USE_YN
        ,DI.QUERY
        ,DI.CREATE_USER
        ,DI.CREATE_DATE
        ,DI.UPDATE_USER
        ,DI.UPDATE_DATE 
    FROM            BSC_INTERFACE_DICODE DI
        LEFT JOIN   BSC_INTERFACE_DATASOURCE DS
            ON DI.SOURCE_ID     =   DS.SOURCE_ID
    WHERE   (DI.DICODE       LIKE    '%' + @DICODE       + '%'     OR  @DICODE       ='')
        AND (DI.NAME         LIKE    '%' + @NAME         + '%'     OR  @NAME         ='')
        AND (DI.INPUT_TYPE   LIKE    '%' + @INPUT_TYPE   + '%'     OR  @INPUT_TYPE   ='')
    ORDER BY
            DI.SOURCE_ID
            , DI.DICODE;
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@DICODE", SqlDbType.VarChar);
            paramArray[0].Value = dicode;
            paramArray[1] = CreateDataParameter("@NAME", SqlDbType.NVarChar);
            paramArray[1].Value = name;
            paramArray[2] = CreateDataParameter("@INPUT_TYPE", SqlDbType.NVarChar);
            paramArray[2].Value = input_type;

            return DbAgentObj.FillDataSet(query, "BSC_INTERFACE_DICODE", null, paramArray, CommandType.Text).Tables[0];
        }


        public int Insert_DB(IDbConnection conn
                            , IDbTransaction trx
                            , object dicode
                            , object name
                            , object source_id
                            , object input_type
                            , object definition
                            , object use_yn
                            , object query
                            , object create_user
                            , object dailykpi_yn)
        {

            string run_query = @"
INSERT INTO BSC_INTERFACE_DICODE
    (
        DICODE
       ,NAME
       ,SOURCE_ID
       ,INPUT_TYPE
       ,DEFINITION
       ,USE_YN
       ,QUERY
       ,CREATE_USER
       ,CREATE_DATE
       ,UPDATE_USER
       ,UPDATE_DATE
       ,DAILYKPI_YN
    )
    VALUES
    (
        @DICODE
       ,@NAME
       ,@SOURCE_ID
       ,@INPUT_TYPE
       ,@DEFINITION
       ,@USE_YN
       ,@QUERY
       ,@CREATE_USER
       ,GETDATE()
       ,@CREATE_USER
       ,GETDATE()
       ,@DAILYKPI_YN
    )
";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@DICODE", SqlDbType.NVarChar);
            paramArray[0].Value = dicode;
            paramArray[1] = CreateDataParameter("@NAME", SqlDbType.NVarChar);
            paramArray[1].Value = name;
            paramArray[2] = CreateDataParameter("@SOURCE_ID", SqlDbType.Int);
            paramArray[2].Value = source_id;
            paramArray[3] = CreateDataParameter("@INPUT_TYPE", SqlDbType.NVarChar);
            paramArray[3].Value = input_type;
            paramArray[4] = CreateDataParameter("@DEFINITION", SqlDbType.NVarChar);
            paramArray[4].Value = definition;
            paramArray[5] = CreateDataParameter("@USE_YN", SqlDbType.NVarChar);
            paramArray[5].Value = use_yn;
            paramArray[6] = CreateDataParameter("@QUERY", SqlDbType.NVarChar);
            paramArray[6].Value = query;
            paramArray[7] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[7].Value = create_user;
            paramArray[8] = CreateDataParameter("@DAILYKPI_YN", SqlDbType.Int);
            paramArray[8].Value = dailykpi_yn;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, run_query, paramArray);

            return affectedRow;
        }

        public int Update_DB(IDbConnection conn, IDbTransaction trx
                            , object name
                            , object source_id
                            , object input_type
                            , object definition
                            , object use_yn
                            , object query
                            , object update_user
                            , object dailykpi_yn
                            , object dicode)
        {

            string run_query = @"
UPDATE  BSC_INTERFACE_DICODE
    SET NAME            = @NAME
        ,SOURCE_ID      = @SOURCE_ID
        ,INPUT_TYPE     = @INPUT_TYPE
        ,DEFINITION     = @DEFINITION
        ,USE_YN         = @USE_YN
        ,QUERY          = @QUERY
        ,UPDATE_USER    = @UPDATE_USER
        ,UPDATE_DATE    = GETDATE()
        ,DAILYKPI_YN    = @DAILYKPI_YN
    WHERE   DICODE  =   @DICODE
";
            
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@NAME", SqlDbType.NVarChar);
            paramArray[0].Value = name;
            paramArray[1] = CreateDataParameter("@SOURCE_ID", SqlDbType.Int);
            paramArray[1].Value = source_id;
            paramArray[2] = CreateDataParameter("@INPUT_TYPE", SqlDbType.NVarChar);
            paramArray[2].Value = input_type;
            paramArray[3] = CreateDataParameter("@DEFINITION", SqlDbType.NVarChar);
            paramArray[3].Value = definition;
            paramArray[4] = CreateDataParameter("@USE_YN", SqlDbType.NVarChar);
            paramArray[4].Value = use_yn;
            paramArray[5] = CreateDataParameter("@QUERY", SqlDbType.NVarChar);
            paramArray[5].Value = query;
            paramArray[6] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[6].Value = update_user;
            paramArray[7] = CreateDataParameter("@DAILYKPI_YN", SqlDbType.NVarChar);
            paramArray[7].Value = dailykpi_yn;
            paramArray[8] = CreateDataParameter("@DICODE", SqlDbType.NVarChar);
            paramArray[8].Value = dicode;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, run_query, paramArray);

            return affectedRow;
        }





        
        public DataTable RetrieveDataInterfaceValue(IDbConnection conn, IDbTransaction trx
                                                    , object estterm_ref_id
                                                    , object ymd)
        {
            string query = @"
SELECT  KT.ESTTERM_REF_ID
        , KT.KPI_REF_ID
        , KT.YMD
        , KQ.DICODE
        , KQ.QUERY_MS
        , KQ.QUERY_TS
        , MIN.MIN_YMD
        , REPLACE(REPLACE(KQ.QUERY_MS, '@YMD', '''' + @YMD + ''''), 'MIN_YMD', '''' + MIN_YMD + '''')   AS  Q_MS
        , REPLACE(REPLACE(KQ.QUERY_TS, '@YMD', '''' + @YMD + ''''), 'MIN_YMD', '''' + MIN_YMD + '''')   AS  Q_TS
        FROM            BSC_KPI_TERM            KT
            INNER JOIN  BSC_INTERFACE_KPI_QUERY KQ
                ON  KT.KPI_REF_ID   =   KQ.KPI_REF_ID
            LEFT OUTER JOIN     (
                                    SELECT      MIN(YMD)    AS  MIN_YMD
                                        FROM    BSC_TERM_DETAIL 
                                        WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID
                                )               MIN
                ON  1=1
        WHERE   KT.ESTTERM_REF_ID   =   @ESTTERM_REF_ID
            AND KT.YMD              =   @YMD 
            AND KT.CHECK_YN         =   'Y'
            AND KQ.ACTIVE_YN        =   'Y'
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;


            DataTable dt = DbAgentObj.FillDataSet(conn, trx, query, "RETRIEVE_INTERFACE_DATA", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }
        public int Update_KPI_Result_From_RetrieveData(IDbConnection conn, IDbTransaction trx
                                                        , object query_ms
                                                        , object query_ts
                                                        , object estterm_ref_id
                                                        , object kpi_ref_id
                                                        , object ymd
                                                        , object update_user_ref_id)
        {
            string query = string.Format(@"
UPDATE  BSC_KPI_RESULT  SET
            CAL_RESULT_MS   = ({0})
            , CAL_RESULT_TS = ({1})
            , UPDATE_USER   = @UPDATE_USER
            , UPDATE_DATE   = GETDATE()
    WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID      = @KPI_REF_ID
        AND YMD             = @YMD';
", query_ms, query_ts);


            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2].Value = ymd;
            paramArray[3] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[3].Value = update_user_ref_id;


            int affectedRow = 0;
            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }
    }
}
