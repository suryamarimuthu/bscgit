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

/// <summary>
/// Dac_Bsc_Map_Kpi 에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Map_Kpi Dac 클래스
/// Class 내용		@ Bsc_Map_Kpi Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.06.19
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 

namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Initiative : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================

        public DataSet SelectData_DB(object estterm_ref_id
                                    , object kpi_ref_id
                                    , object ymd)
        {
            string strQuery = @"
SELECT  ESTTERM_REF_ID                
      , KPI_REF_ID                    
      , YMD                           
      , INITIATIVE_DO
      , DO_FILE
      , CREATE_USER                   
      , CREATE_DATE                   
      , UPDATE_USER                   
      , UPDATE_DATE 
FROM  BSC_KPI_INITIATIVE
WHERE ESTTERM_REF_ID                = @ESTTERM_REF_ID                
  AND KPI_REF_ID                    = @KPI_REF_ID                    
  AND YMD                           = @YMD
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = ymd;

            return DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INITIATIVE", null, paramArray, CommandType.Text);
        }


        public int InsertData_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object ymd
                                , object initiative_plan
                                , object initiative_do
                                , object do_file
                                , object initiative_desc
                                , object create_user)
        {
            string query = @"
          
INSERT INTO BSC_KPI_INITIATIVE
(ESTTERM_REF_ID,    KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO, DO_FILE, INITIATIVE_DESC,    CREATE_USER,    CREATE_DATE)
VALUES
(@ESTTERM_REF_ID,   @KPI_REF_ID,    @YMD,           @INITIATIVE_PLAN,   @INITIATIVE_DO, @DO_FILE, @INITIATIVE_DESC,   @CREATE_USER,   GETDATE())
";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@INITIATIVE_PLAN", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@INITIATIVE_DO", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@DO_FILE", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@INITIATIVE_DESC", SqlDbType.VarChar);
            paramArray[7] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = ymd;
            paramArray[3].Value = initiative_plan;
            paramArray[4].Value = initiative_do;
            paramArray[5].Value = do_file;
            paramArray[6].Value = initiative_desc;
            paramArray[7].Value = create_user;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        public int InsertData_DB_From_Bsc_Kpi_Initiative(IDbConnection idc
                                                        , IDbTransaction idt
                                                        , object estterm_ref_id
                                                        , object org_kpi_ref_id
                                                        , object kpi_ref_id
                                                        , object create_user_ref_id)
        {
            string query = @"
INSERT INTO     BSC_KPI_INITIATIVE
            (
                ESTTERM_REF_ID
                , KPI_REF_ID
                , YMD
                , INITIATIVE_PLAN
                , INITIATIVE_DO
                , INITIATIVE_DESC
                , CREATE_USER
                , CREATE_DATE
            )
    SELECT      @ESTTERM_REF_ID
                , @KPI_REF_ID
                , YMD
                , INITIATIVE_PLAN
                , INITIATIVE_DO
                , INITIATIVE_DESC
                , @CREATE_USER
                , GETDATE()
    FROM        BSC_KPI_INITIATIVE
    WHERE       ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND     KPI_REF_ID      = @ORG_KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@CREATE_USER", SqlDbType.VarChar);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = org_kpi_ref_id;
            paramArray[2].Value = kpi_ref_id;
            paramArray[3].Value = create_user_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }




        public int UpdateData_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object ymd
                                , object initiative_plan
                                , object initiative_do
                                , object initiative_desc
                                , object create_user)
        {
            string query = @"
        
UPDATE BSC_KPI_INITIATIVE
    SET INITIATIVE_PLAN     = @INITIATIVE_PLAN               
        , INITIATIVE_DO     = @INITIATIVE_DO                 
        , INITIATIVE_DESC   = @INITIATIVE_DESC               
        , UPDATE_USER       = @CREATE_USER
        , UPDATE_DATE       = GETDATE()                   
WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID                
    AND KPI_REF_ID    = @KPI_REF_ID                    
    AND YMD           = @YMD

";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@INITIATIVE_PLAN", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@INITIATIVE_DO", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@INITIATIVE_DESC", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = ymd;
            paramArray[3].Value = initiative_plan;
            paramArray[4].Value = initiative_do;
            paramArray[5].Value = initiative_desc;
            paramArray[6].Value = create_user;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int UpdateDo_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object ymd                                
                                , object initiative_do
                                , object do_file
                                , object create_date
                                , object create_user)
        {
            string query = @"
        UPDATE BSC_KPI_INITIATIVE
                  SET INITIATIVE_DO                 = @INITIATIVE_DO                 
                    , DO_FILE                       = @DO_FILE
                    , UPDATE_USER                   = @CREATE_USER                   
                    , UPDATE_DATE                   = @CREATE_DATE                   
                WHERE ESTTERM_REF_ID                = @ESTTERM_REF_ID                
                  AND KPI_REF_ID                    = @KPI_REF_ID                    
                  AND YMD                           = @YMD

";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@INITIATIVE_DO", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@DO_FILE", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@CREATE_DATE", SqlDbType.Date);
            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = ymd;
            paramArray[3].Value = initiative_do;
            paramArray[4].Value = do_file;
            paramArray[5].Value = create_date;
            paramArray[6].Value = create_user;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        internal protected int DeleteData_DB(IDbConnection idc
                                            , IDbTransaction idt
                                            , object estterm_ref_id
                                            , object kpi_ref_id)
        {
            string query = @"
DELETE FROM BSC_KPI_INITIATIVE
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID
";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		        = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[0].Value 	    = estterm_ref_id;
	        paramArray[1] 		        = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = kpi_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);


            return affectedRow;
        }

        #endregion

    }

}