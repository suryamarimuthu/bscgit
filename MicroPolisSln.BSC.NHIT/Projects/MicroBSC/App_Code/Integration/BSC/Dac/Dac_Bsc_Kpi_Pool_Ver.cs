﻿using System;
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
/// Dac_Bsc_Kpi_Info에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Info Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Pool_Ver : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================
        
        
        public int InsertData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object kpi_pool_ver_id
                                , object kpi_pool_ver_name
                                , object kpi_pool_ver_note
                                , object create_date
                                , object create_user)
        {

            string query = @"
INSERT INTO BSC_KPI_POOL_VER
  ( 
     KPI_POOL_VER_ID  
    ,KPI_POOL_VER_NAME      
    ,KPI_POOL_VER_NOTE             
    ,CREATE_DATE
    ,CREATE_USER
    ,UPDATE_DATE
    ,UPDATE_USER
  )
VALUES
  ( 
     @KPI_POOL_VER_ID  
    ,@KPI_POOL_VER_NAME      
    ,@KPI_POOL_VER_NOTE      
    ,@CREATE_DATE
    ,@CREATE_USER
    ,@CREATE_DATE
    ,@CREATE_USER  
  )
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@KPI_POOL_VER_ID", SqlDbType.Int);
            paramArray[0].Value         = kpi_pool_ver_id;
            paramArray[1]               = CreateDataParameter("@KPI_POOL_VER_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = kpi_pool_ver_name;
            paramArray[2]               = CreateDataParameter("@KPI_POOL_VER_NOTE", SqlDbType.VarChar);
            paramArray[2].Value         = kpi_pool_ver_note;
            paramArray[3]              = CreateDataParameter("@CREATE_DATE", SqlDbType.Date);
            paramArray[3].Value        = create_date;
            paramArray[4]              = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[4].Value        = create_user;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        public int UpdateData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object kpi_pool_ver_id
                                , object kpi_pool_ver_name
                                , object kpi_pool_ver_note
                                , object create_date
                                , object create_user)
        {

            string query = @"
UPDATE BSC_KPI_POOL_VER
  SET
     KPI_POOL_VER_NAME  = @KPI_POOL_VER_NAME      
    ,KPI_POOL_VER_NOTE  = @KPI_POOL_VER_NOTE               
    ,UPDATE_DATE        = @CREATE_DATE
    ,UPDATE_USER        = @CREATE_USER  
WHERE KPI_POOL_VER_ID    = @KPI_POOL_VER_ID 
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@KPI_POOL_VER_ID", SqlDbType.Int);
            paramArray[0].Value         = kpi_pool_ver_id;
            paramArray[1]               = CreateDataParameter("@KPI_POOL_VER_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = kpi_pool_ver_name;
            paramArray[2]               = CreateDataParameter("@KPI_POOL_VER_NOTE", SqlDbType.VarChar);
            paramArray[2].Value         = kpi_pool_ver_note;
            paramArray[3]              = CreateDataParameter("@CREATE_DATE", SqlDbType.Date);
            paramArray[3].Value        = create_date;
            paramArray[4]              = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[4].Value        = create_user;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        public int DeleteData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object kpi_pool_ver_id)
        {

            string query = @"
DELETE FROM BSC_KPI_POOL_VER
WHERE KPI_POOL_VER_ID    = @KPI_POOL_VER_ID 
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@KPI_POOL_VER_ID", SqlDbType.Int);
            paramArray[0].Value         = kpi_pool_ver_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        public int SelectMax_DB(IDbConnection conn
                                , IDbTransaction trx)
        {

            string query = @"
SELECT ISNULL(MAX(KPI_POOL_VER_ID),0) FROM BSC_KPI_POOL_VER
 
";

            object objMax = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);


            return DataTypeUtility.GetToInt32(objMax) + 1;
        }


        public DataTable Select_DB()
        {

            string query = @"
SELECT KPI_POOL_VER_ID  
    ,KPI_POOL_VER_NAME      
    ,KPI_POOL_VER_NOTE             
    ,CREATE_DATE
    ,CREATE_USER
    ,UPDATE_DATE
    ,UPDATE_USER 
FROM BSC_KPI_POOL_VER
ORDER BY KPI_POOL_VER_ID
";

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_POOL_VER", null, null, CommandType.Text).Tables[0];
            return dt;
        }

        /// <summary>
        /// 상위전략 반환
        /// </summary>
        /// <returns></returns>
        public DataTable Select_UpSkill_DB()
        {
            string query = @"SELECT STG_REF_ID, STG_NAME FROM BSC_STG_INFO WHERE ESTTERM_REF_ID = (SELECT MAX(ESTTERM_REF_ID) FROM EST_TERM_INFO WHERE EST_STATUS = '1') ORDER BY STG_CODE";
            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_POOL_VER", null, null, CommandType.Text).Tables[0];
            return dt;
        }


        #endregion

    }
}
