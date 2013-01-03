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

namespace MicroBSC.Integration.MUL.Dac
{
    public class Dac_Mul_Est_Emp : DbAgentBase
    {
        public Dac_Mul_Est_Emp()
        {
        }

        public DataTable Select_DB(object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id)
        {
            string query = @"

SELECT 
  C.DEPT_REF_ID
, C.DEPT_CODE
, C.DEPT_NAME
, COUNT(B.EMP_REF_ID) AS TOTAL_CNT
, COUNT(Y.EST_EMP_ID) AS EST_CNT
, COUNT(Z.EST_EMP_ID) AS TGT_CNT
 FROM MUL_EST_EMP Y   RIGHT OUTER JOIN COM_EMP_INFO  A ON(    Y.EST_EMP_ID      = A.EMP_REF_ID
                                                          AND Y.COMP_ID         = @COMP_ID
                                                          AND Y.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                          AND Y.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
                                                          AND Y.EST_ID          = @EST_ID        
                                                          AND Y.EST_TYPE        = 'EST'          )  -- EST : 평가자
                                  JOIN REL_DEPT_EMP  B ON(A.EMP_REF_ID  = B.EMP_REF_ID)
                                  JOIN COM_DEPT_INFO C ON(B.DEPT_REF_ID = C.DEPT_REF_ID)
                      LEFT OUTER  JOIN MUL_EST_EMP   Z ON(    Z.EST_EMP_ID      = A.EMP_REF_ID
                                                          AND Z.COMP_ID         = @COMP_ID
                                                          AND Z.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                          AND Z.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
                                                          AND Z.EST_ID          = @EST_ID        
                                                          AND Z.EST_TYPE        = 'TGT'         )   -- TGT : 피평가자
GROUP BY C.DEPT_REF_ID
       , C.DEPT_CODE
       , C.DEPT_NAME
       , C.SORT_ORDER
ORDER BY C.SORT_ORDER

";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable SelectEstEmp_DB(object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object emp_ref_id
                                            , object est_type)
        {
            string query = @"


SELECT COMP_ID
      ,EST_ID
      ,ESTTERM_REF_ID
      ,ESTTERM_SUB_ID
      ,EST_EMP_ID
      ,EST_TYPE
FROM MUL_EST_EMP 
WHERE (COMP_ID         = @COMP_ID         OR   @COMP_ID        = 0  )
  AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR   @ESTTERM_REF_ID = 0  )
  AND (ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR   @ESTTERM_SUB_ID = 0  )
  AND (EST_ID          = @EST_ID          OR   @EST_ID         =''  )
  AND (EST_EMP_ID      = @EST_EMP_ID      OR   @EST_EMP_ID     = 0  )
  AND (EST_TYPE        = @EST_TYPE        OR   @EST_TYPE       =''  )
ORDER BY COMP_ID
      ,EST_ID
      ,ESTTERM_REF_ID
      ,ESTTERM_SUB_ID
      ,EST_EMP_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = emp_ref_id;
            paramArray[5] = CreateDataParameter("@EST_TYPE", SqlDbType.NVarChar);
            paramArray[5].Value = est_type;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public int Delete_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object est_emp_id
                        , object est_type)
        {
            string query = @"

DELETE FROM MUL_EST_EMP
  WHERE COMP_ID            = @COMP_ID
    AND EST_ID             = @EST_ID
    AND ESTTERM_REF_ID     = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
    AND (EST_EMP_ID        = @EST_EMP_ID       OR    @EST_EMP_ID   =  0)
    AND EST_TYPE           = @EST_TYPE

";

           
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = est_emp_id;
            paramArray[5]       = CreateDataParameter("@EST_TYPE", SqlDbType.NVarChar);
            paramArray[5].Value = est_type;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
          
        }


        public int Insert_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object est_emp_id
                        , object est_type
                        , object create_date
                        , object create_user)
        {
            string query = @"

INSERT INTO MUL_EST_EMP
		( COMP_ID
		 ,EST_ID 
         ,ESTTERM_REF_ID   
         ,ESTTERM_SUB_ID  
         ,EST_EMP_ID        
         ,EST_TYPE        
         ,CREATE_DATE
         ,CREATE_USER
		)
		VALUES
		(
			@COMP_ID
		 ,@EST_ID 
         ,@ESTTERM_REF_ID   
         ,@ESTTERM_SUB_ID  
         ,@EST_EMP_ID        
         ,@EST_TYPE       
         ,@CREATE_DATE 
         ,@CREATE_USER
         
		)

";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = est_emp_id;
            paramArray[5]       = CreateDataParameter("@EST_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = est_type;
            paramArray[6]       = CreateDataParameter("@CREATE_DATE", SqlDbType.Date);
            paramArray[6].Value = create_date;
            paramArray[7]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[7].Value = create_user;
            
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
          
        }


        /// <summary>
        /// 해당 부서의 평가/피평가자별 조회
        /// </summary>
        public DataSet SelectRelDeptEmp(object emp_ref_id
                                        , object comp_id
                                        , object dept_ref_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id
                                        , object est_type)
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
                        AND (  M.EST_TYPE     =   @EST_TYPE       OR    L.EST_TYPE     =   @EST_TYPE    OR  @EST_TYPE       =''     )
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

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
            paramArray[6] = CreateDataParameter("@EST_TYPE", SqlDbType.NVarChar);
            paramArray[6].Value = est_type;


            DataSet ds = DbAgentObj.FillDataSet(query, "REL_DEPT_EMP", null, paramArray, CommandType.Text);
            return ds;
        }
    }
}
