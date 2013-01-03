using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Rel_Dept_Emp : DbAgentBase
    {
      

        public Dac_Rel_Dept_Emp()
        {

        }

        public DataSet SelectRelDeptEmp_DB(object emp_ref_id
                                         , object comp_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id)
        {
            string query = @"SELECT	  A.LOGINID
		                            , A.LOGINIP
                                    , A.EMP_REF_ID
                                    , A.EMP_NAME
		                            , B.DEPT_REF_ID             AS DEPT_REF_ID
                                    , C.DEPT_NAME               AS DEPT_NAME
                                    , A.EMP_EMail
		                            , A.DAILY_PHONE
		                            , A.CELL_PHONE
		                            , A.FAX_NUMBER
		                            , A.JOB_STATUS
		                            , A.ZIPCODE
		                            , A.ADDR_1
		                            , A.ADDR_2
		                            , A.SIGN_PATH
		                            , A.STAMP_PATH
                                    , A.POSITION_CLASS_CODE
                                    , F.POS_CLS_NAME
                                    , A.POSITION_GRP_CODE
                                    , G.POS_GRP_NAME
                                    , A.POSITION_RANK_CODE
                                    , H.POS_RNK_NAME
                                    , A.POSITION_DUTY_CODE
                                    , D.POS_DUT_NAME	
                                    , A.POSITION_KIND_CODE
                                    , E.POS_KND_NAME
                                    , A.EMP_CODE
                                    , M.EST_TYPE            AS EST_TYPE_EST
                                    , L.EST_TYPE            AS EST_TYPE_TGT
                            FROM  COM_EMP_INFO          A 
                       LEFT OUTER              JOIN REL_DEPT_EMP   B ON (A.EMP_REF_ID   = B.EMP_REF_ID)
                       LEFT OUTER              JOIN COM_DEPT_INFO  C ON (B.DEPT_REF_ID  = C.DEPT_REF_ID)
                       LEFT OUTER              JOIN EST_POSITION_DUT  D ON (A.POSITION_DUTY_CODE  = D.POS_DUT_ID)
                       LEFT OUTER              JOIN EST_POSITION_KND  E ON (A.POSITION_KIND_CODE  = E.POS_KND_ID)
                       LEFT OUTER              JOIN EST_POSITION_CLS  F ON (A.POSITION_CLASS_CODE = F.POS_CLS_ID)
                       LEFT OUTER              JOIN EST_POSITION_GRP  G ON (A.POSITION_GRP_CODE   = G.POS_GRP_ID)
                       LEFT OUTER              JOIN EST_POSITION_RNK  H ON (A.POSITION_RANK_CODE  = H.POS_RNK_ID)
                       LEFT OUTER              JOIN MUL_EST_EMP  M      ON (    A.EMP_REF_ID         = M.EST_EMP_ID 
                                                                 AND M.COMP_ID            = @COMP_ID
                                                                 AND M.EST_ID             = @EST_ID
                                                                 AND M.ESTTERM_REF_ID     = @ESTTERM_REF_ID
                                                                 AND M.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
                                                                 AND M.EST_TYPE           = 'EST')
                       LEFT OUTER              JOIN MUL_EST_EMP  L      ON (    A.EMP_REF_ID         = L.EST_EMP_ID 
                                                                 AND L.COMP_ID            = @COMP_ID
                                                                 AND L.EST_ID             = @EST_ID
                                                                 AND L.ESTTERM_REF_ID     = @ESTTERM_REF_ID
                                                                 AND L.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID                                                                 
                                                                 AND L.EST_TYPE           = 'TGT')
                      WHERE (A.EMP_REF_ID = @EMP_REF_ID  OR    @EMP_REF_ID =  0   )  ";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1].Value = comp_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2].Value = est_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_sub_id;


            DataSet ds = DbAgentObj.FillDataSet(query, "REL_DEPT_EMP", null, paramArray, CommandType.Text);
            return ds;
        }



        public string Select_Dept_ID_of_Emp_ID(IDbConnection conn, IDbTransaction trx
                                                , object EMP_REF_ID)
        {
            object Result;
            string query = @"
SELECT      DEPT_REF_ID
    FROM    REL_DEPT_EMP
    WHERE   EMP_REF_ID    =   @EMP_REF_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = EMP_REF_ID;

            Result = DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text);

            return DataTypeUtility.GetString(Result);
        }



        public DataSet SelectRelDeptEmp_DB(object emp_ref_id
                                        , object comp_id
                                        , object dept_ref_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id)
        {
            string query = @"SELECT	  A.LOGINID
		                            , A.LOGINIP
                                    , A.EMP_REF_ID
                                    , A.EMP_NAME
		                            , B.DEPT_REF_ID             AS DEPT_REF_ID
                                    , C.DEPT_NAME               AS DEPT_NAME
                                    , A.EMP_EMail
		                            , A.DAILY_PHONE
		                            , A.CELL_PHONE
		                            , A.FAX_NUMBER
		                            , A.JOB_STATUS
		                            , A.ZIPCODE
		                            , A.ADDR_1
		                            , A.ADDR_2
		                            , A.SIGN_PATH
		                            , A.STAMP_PATH
                                    , A.POSITION_CLASS_CODE
                                    , F.POS_CLS_NAME
                                    , A.POSITION_GRP_CODE
                                    , G.POS_GRP_NAME
                                    , A.POSITION_RANK_CODE
                                    , H.POS_RNK_NAME
                                    , A.POSITION_DUTY_CODE
                                    , D.POS_DUT_NAME	
                                    , A.POSITION_KIND_CODE
                                    , E.POS_KND_NAME
                                    , A.EMP_CODE
                                    , M.EST_TYPE            AS EST_TYPE_EST
                                    , L.EST_TYPE            AS EST_TYPE_TGT
                            FROM  COM_EMP_INFO          A 
                       LEFT OUTER              JOIN REL_DEPT_EMP   B ON (A.EMP_REF_ID   = B.EMP_REF_ID)
                       LEFT OUTER              JOIN COM_DEPT_INFO  C ON (B.DEPT_REF_ID  = C.DEPT_REF_ID)
                       LEFT OUTER              JOIN EST_POSITION_DUT  D ON (A.POSITION_DUTY_CODE  = D.POS_DUT_ID)
                       LEFT OUTER              JOIN EST_POSITION_KND  E ON (A.POSITION_KIND_CODE  = E.POS_KND_ID)
                       LEFT OUTER              JOIN EST_POSITION_CLS  F ON (A.POSITION_CLASS_CODE = F.POS_CLS_ID)
                       LEFT OUTER              JOIN EST_POSITION_GRP  G ON (A.POSITION_GRP_CODE   = G.POS_GRP_ID)
                       LEFT OUTER              JOIN EST_POSITION_RNK  H ON (A.POSITION_RANK_CODE  = H.POS_RNK_ID)
                       LEFT OUTER              JOIN MUL_EST_EMP  M      ON (    A.EMP_REF_ID         = M.EST_EMP_ID 
                                                                 AND M.COMP_ID            = @COMP_ID
                                                                 AND M.EST_ID             = @EST_ID
                                                                 AND M.ESTTERM_REF_ID     = @ESTTERM_REF_ID
                                                                 AND M.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
                                                                 AND M.EST_TYPE           = 'EST')
                       LEFT OUTER              JOIN MUL_EST_EMP  L      ON (    A.EMP_REF_ID         = L.EST_EMP_ID 
                                                                 AND L.COMP_ID            = @COMP_ID
                                                                 AND L.EST_ID             = @EST_ID
                                                                 AND L.ESTTERM_REF_ID     = @ESTTERM_REF_ID
                                                                 AND L.ESTTERM_SUB_ID     = @ESTTERM_SUB_ID                                                                 
                                                                 AND L.EST_TYPE           = 'TGT')
                      WHERE (  A.EMP_REF_ID   =   @EMP_REF_ID     OR    @EMP_REF_ID     =   0   )
                        AND (  B.DEPT_REF_ID  =   @DEPT_REF_ID    OR    @DEPT_REF_ID    =   0   )
";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1].Value = comp_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2].Value = est_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_sub_id;
            paramArray[5] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(query, "REL_DEPT_EMP", null, paramArray, CommandType.Text);
            return ds;
        }
    }
}
