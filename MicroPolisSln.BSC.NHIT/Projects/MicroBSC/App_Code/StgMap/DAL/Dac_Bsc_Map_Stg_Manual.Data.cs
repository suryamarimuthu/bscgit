using System;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;
using MicroBSC.Biz.BSC;

namespace MicroBSC.Biz.BSC
{
    public class Dac_Bsc_Map_Stg_Manual_Data : DbAgentBase
    {
        #region ------------------------ 필드 ------------------------
                
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)

        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public String Transaction_Message
        {
            get
            {
                return _txr_message;
            }
            set
            {
                _txr_message = value;
            }
        }

        public String Transaction_Result
        {
            get
            {
                return _txr_result;
            }
            set
            {
                _txr_result = value;
            }
        }

        #endregion

        public Dac_Bsc_Map_Stg_Manual_Data()
        {
            
        }

        public DataSet Select(int estterm_ref_id
                            , int est_dept_ref_id
                            , string ymd
                            , string st_up_tbl_id
                            , string st_tbl_id
                            , string ed_up_tbl_id
                            , string ed_tbl_id)
        {

            string query = @"

 SELECT   SEQ
        , ESTTERM_REF_ID
        , YMD
        , EST_DEPT_REF_ID
        , ST_UP_TBL_ID
        , ST_TBL_ID
        , ED_UP_TBL_ID
        , ED_TBL_ID
        , X1
        , Y1
        , X2
        , Y2
        , CREATE_USER
        , CREATE_DATE
        , UPDATE_USER
        , UPDATE_DATE
 FROM BSC_MAP_STG_MANUAL
 WHERE ESTTERM_REF_ID   =   @ESTTERM_REF_ID
   AND YMD              =   @YMD
   AND EST_DEPT_REF_ID  =   @EST_DEPT_REF_ID
   AND (ST_UP_TBL_ID       =   @ST_UP_TBL_ID          OR          @ST_UP_TBL_ID      =       '')
   AND (ST_TBL_ID          =   @ST_TBL_ID             OR          @ST_TBL_ID         =       '')
   AND (ED_UP_TBL_ID       =   @ED_UP_TBL_ID          OR          @ED_UP_TBL_ID      =       '')
   AND (ED_TBL_ID          =   @ED_TBL_ID             OR          @ED_TBL_ID         =       '')
 ORDER BY ESTTERM_REF_ID
        , YMD
        , EST_DEPT_REF_ID
        , ST_UP_TBL_ID
        , ST_TBL_ID
        , ED_UP_TBL_ID
        , ED_TBL_ID
        , SEQ    ";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.Int);
            paramArray[2].Value = ymd;
            paramArray[3] = CreateDataParameter("@ST_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[3].Value = st_up_tbl_id;
            paramArray[4] = CreateDataParameter("@ST_TBL_ID", SqlDbType.VarChar);
            paramArray[4].Value = st_tbl_id;
            paramArray[5] = CreateDataParameter("@ED_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[5].Value = ed_up_tbl_id;
            paramArray[6] = CreateDataParameter("@ED_TBL_ID", SqlDbType.VarChar);
            paramArray[6].Value = ed_tbl_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "BSC_MAP_STG_MANUAL", null, paramArray, CommandType.Text);

            return ds;
        }

        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx
                            , int estterm_ref_id
                            , int est_dept_ref_id
                            , string ymd
                            , string st_up_tbl_id
                            , string st_tbl_id
                            , string ed_up_tbl_id
                            , string ed_tbl_id)
        {

            string query = @"

 SELECT   SEQ
        , ESTTERM_REF_ID
        , YMD
        , EST_DEPT_REF_ID
        , ST_UP_TBL_ID
        , ST_TBL_ID
        , ED_UP_TBL_ID
        , ED_TBL_ID
        , X1
        , Y1
        , X2
        , Y2
        , CREATE_USER
        , CREATE_DATE
        , UPDATE_USER
        , UPDATE_DATE
 FROM BSC_MAP_STG_MANUAL
 WHERE ESTTERM_REF_ID   =   @ESTTERM_REF_ID
   AND YMD              =   @YMD
   AND EST_DEPT_REF_ID  =   @EST_DEPT_REF_ID
   AND (ST_UP_TBL_ID       =   @ST_UP_TBL_ID          OR          @ST_UP_TBL_ID      =       '')
   AND (ST_TBL_ID          =   @ST_TBL_ID             OR          @ST_TBL_ID         =       '')
   AND (ED_UP_TBL_ID       =   @ED_UP_TBL_ID          OR          @ED_UP_TBL_ID      =       '')
   AND (ED_TBL_ID          =   @ED_TBL_ID             OR          @ED_TBL_ID         =       '')
 ORDER BY ESTTERM_REF_ID
        , YMD
        , EST_DEPT_REF_ID
        , ST_UP_TBL_ID
        , ST_TBL_ID
        , ED_UP_TBL_ID
        , ED_TBL_ID
        , SEQ        ";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.Int);
            paramArray[2].Value = ymd;
            paramArray[3] = CreateDataParameter("@ST_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[3].Value = st_up_tbl_id;
            paramArray[4] = CreateDataParameter("@ST_TBL_ID", SqlDbType.VarChar);
            paramArray[4].Value = st_tbl_id;
            paramArray[5] = CreateDataParameter("@ED_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[5].Value = ed_up_tbl_id;
            paramArray[6] = CreateDataParameter("@ED_TBL_ID", SqlDbType.VarChar);
            paramArray[6].Value = ed_tbl_id;
            //paramArray[7] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            //paramArray[7].Direction = ParameterDirection.Output;
            //paramArray[8] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            //paramArray[8].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "BSC_MAP_STG_MANUAL", null, paramArray, CommandType.Text,out col);

            //this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            //this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return ds;
            
        }

        public int NewSeq(IDbConnection conn
                        , IDbTransaction trx
                        , int estterm_ref_id
                        , int est_dept_ref_id
                        , string ymd
                        , string st_up_tbl_id
                        , string st_tbl_id
                        , string ed_up_tbl_id
                        , string ed_tbl_id)
        {

            int reVal = 0;

            string query = @"

 SELECT MAX(SEQ) FROM BSC_MAP_STG_MANUAL
 WHERE ESTTERM_REF_ID   =   @ESTTERM_REF_ID
   AND YMD              =   @YMD
   AND EST_DEPT_REF_ID  =   @EST_DEPT_REF_ID
   AND (ST_UP_TBL_ID       =   @ST_UP_TBL_ID          OR          @ST_UP_TBL_ID      =       '')
   AND (ST_TBL_ID          =   @ST_TBL_ID             OR          @ST_TBL_ID         =       '')
   AND (ED_UP_TBL_ID       =   @ED_UP_TBL_ID          OR          @ED_UP_TBL_ID      =       '')
   AND (ED_TBL_ID          =   @ED_TBL_ID             OR          @ED_TBL_ID         =       '')

                           ";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.Int);
            paramArray[2].Value = ymd;
            paramArray[3] = CreateDataParameter("@ST_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[3].Value = st_up_tbl_id;
            paramArray[4] = CreateDataParameter("@ST_TBL_ID", SqlDbType.VarChar);
            paramArray[4].Value = st_tbl_id;
            paramArray[5] = CreateDataParameter("@ED_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[5].Value = ed_up_tbl_id;
            paramArray[6] = CreateDataParameter("@ED_TBL_ID", SqlDbType.VarChar);
            paramArray[6].Value = ed_tbl_id;
            //paramArray[7] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            //paramArray[7].Direction = ParameterDirection.Output;
            //paramArray[8] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            //paramArray[8].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            object objMaxSeq = DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text, out col);

            if(objMaxSeq == null || objMaxSeq == DBNull.Value)
                reVal = 0;
            else
                reVal = DataTypeUtility.GetToInt32(objMaxSeq) + 1;

            //this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            //this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return reVal;
        }

        public int Delete(int estterm_ref_id
                        , int est_dept_ref_id
                        , string ymd)
        {

            int okCnt = 0;

            string query = @"

 DELETE FROM BSC_MAP_STG_MANUAL
 WHERE ESTTERM_REF_ID   =   @ESTTERM_REF_ID
   AND YMD              =   @YMD
   AND EST_DEPT_REF_ID  =   @EST_DEPT_REF_ID
                           ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.Int);
            paramArray[2].Value = ymd;
            
                        
            okCnt = DbAgentObj.ExecuteNonQuery(query, paramArray);
            return okCnt;
        }

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , int estterm_ref_id
                        , int est_dept_ref_id
                        , string ymd
                        , string st_up_tbl_id
                        , string st_tbl_id
                        , string ed_up_tbl_id
                        , string ed_tbl_id)
        {

            int okCnt = 0;

            string query = @"

 DELETE FROM BSC_MAP_STG_MANUAL
 WHERE ESTTERM_REF_ID   =   @ESTTERM_REF_ID
   AND YMD              =   @YMD
   AND EST_DEPT_REF_ID  =   @EST_DEPT_REF_ID
   AND (ST_UP_TBL_ID       =   @ST_UP_TBL_ID )
   AND (ST_TBL_ID          =   @ST_TBL_ID    )
   AND (ED_UP_TBL_ID       =   @ED_UP_TBL_ID )
   AND (ED_TBL_ID          =   @ED_TBL_ID    )
                           ";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.Int);
            paramArray[2].Value = ymd;
            paramArray[3] = CreateDataParameter("@ST_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[3].Value = st_up_tbl_id;
            paramArray[4] = CreateDataParameter("@ST_TBL_ID", SqlDbType.VarChar);
            paramArray[4].Value = st_tbl_id;
            paramArray[5] = CreateDataParameter("@ED_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[5].Value = ed_up_tbl_id;
            paramArray[6] = CreateDataParameter("@ED_TBL_ID", SqlDbType.VarChar);
            paramArray[6].Value = ed_tbl_id;
            //paramArray[7] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            //paramArray[7].Direction = ParameterDirection.Output;
            //paramArray[8] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            //paramArray[8].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            okCnt = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text, out col);

            //this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            //this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return okCnt;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int seq
                        , int estterm_ref_id                                                
                        , int est_dept_ref_id
                        , string ymd
                        , string st_up_tbl_id
                        , string st_tbl_id
                        , string ed_up_tbl_id
                        , string ed_tbl_id
                        , string x1
                        , string y1
                        , string x2
                        , string y2
                        , int create_user
                        , DateTime create_date)
        {

            int okCnt = 0;

            string query = @"

 INSERT INTO BSC_MAP_STG_MANUAL ( SEQ
                                , ESTTERM_REF_ID
                                , YMD
                                , EST_DEPT_REF_ID
                                , ST_UP_TBL_ID
                                , ST_TBL_ID
                                , ED_UP_TBL_ID
                                , ED_TBL_ID
                                , X1
                                , Y1
                                , X2
                                , Y2
                                , CREATE_USER
                                , CREATE_DATE
                                , UPDATE_USER
                                , UPDATE_DATE )
      VALUES  ( @SEQ
              , @ESTTERM_REF_ID
              , @YMD
              , @EST_DEPT_REF_ID
              , @ST_UP_TBL_ID
              , @ST_TBL_ID
              , @ED_UP_TBL_ID
              , @ED_TBL_ID
              , @X1
              , @Y1
              , @X2
              , @Y2
              , @CREATE_USER
              , @CREATE_DATE
              , null
              , null )

                           ";

            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0] = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[0].Value = seq;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[2].Value = est_dept_ref_id;
            paramArray[3] = CreateDataParameter("@YMD", SqlDbType.Int);
            paramArray[3].Value = ymd;
            paramArray[4] = CreateDataParameter("@ST_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[4].Value = st_up_tbl_id;
            paramArray[5] = CreateDataParameter("@ST_TBL_ID", SqlDbType.VarChar);
            paramArray[5].Value = st_tbl_id;
            paramArray[6] = CreateDataParameter("@ED_UP_TBL_ID", SqlDbType.VarChar);
            paramArray[6].Value = ed_up_tbl_id;
            paramArray[7] = CreateDataParameter("@ED_TBL_ID", SqlDbType.VarChar);
            paramArray[7].Value = ed_tbl_id;
            paramArray[8] = CreateDataParameter("@X1", SqlDbType.VarChar);
            paramArray[8].Value = x1;
            paramArray[9] = CreateDataParameter("@Y1", SqlDbType.VarChar);
            paramArray[9].Value = y1;
            paramArray[10] = CreateDataParameter("@X2", SqlDbType.VarChar);
            paramArray[10].Value = x2;
            paramArray[11] = CreateDataParameter("@Y2", SqlDbType.VarChar);
            paramArray[11].Value = y2;
            paramArray[12] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[12].Value = create_user;
            paramArray[13] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[13].Value = create_date;
            //paramArray[14] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            //paramArray[14].Direction = ParameterDirection.Output;
            //paramArray[15] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            //paramArray[15].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            okCnt = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text, out col);

            //this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            //this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return okCnt;
        }
    }
}
