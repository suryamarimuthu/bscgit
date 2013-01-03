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

namespace MicroBSC.Integration.EST.Dac
{
    public class Dac_Est_Pos_Weight : DbAgentBase
    {
        public Dac_Est_Pos_Weight()
        {
        }
        

        public DataTable Select_DB(object comp_id
                                , object estterm_ref_id
                                , object est_id
                                , object seq
                                , object pos_id
                                , object pos_value
                                , object dept_type_ref_id)
        {
            string query = @"
SELECT  COMP_ID
        , ESTTERM_REF_ID
        , EST_ID
        , SEQ
        , POS_ID
        , POS_VALUE
        , DEPT_TYPE_REF_ID
        , WEIGHT
    FROM    EST_POS_WEIGHT
    WHERE   (  COMP_ID          = @COMP_ID	            OR @COMP_ID             = 0  )
        AND (  ESTTERM_REF_ID   = @ESTTERM_REF_ID	    OR @ESTTERM_REF_ID      = 0  )
        AND (  EST_ID           = @EST_ID	            OR @EST_ID              =''  )
        AND (  SEQ              = @SEQ	                OR @SEQ                 = 0  )
        AND (  POS_ID           = @POS_ID	            OR @POS_ID              =''  )
        AND (  POS_VALUE        = @POS_VALUE	        OR @POS_VALUE           =''  )
        AND (  DEPT_TYPE_REF_ID = @DEPT_TYPE_REF_ID     OR @DEPT_TYPE_REF_ID    = 0  )
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[2].Value = est_id;
            paramArray[3] = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[3].Value = seq;
            paramArray[4] = CreateDataParameter("@POS_ID", SqlDbType.NVarChar);
            paramArray[4].Value = pos_id;
            paramArray[5] = CreateDataParameter("@POS_VALUE", SqlDbType.NVarChar);
            paramArray[5].Value = pos_value;
            paramArray[6] = CreateDataParameter("@DEPT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[6].Value = dept_type_ref_id;

            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }


        public int Insert_DB(IDbConnection conn, IDbTransaction trx
                            , object comp_id
                            , object estterm_ref_id
                            , object est_id
                            , object seq
                            , object pos_id
                            , object pos_value
                            , object dept_type_ref_id
                            , object weight
                            , object create_user_ref_id)
        {
            string query = @"
INSERT INTO EST_POS_WEIGHT
            (
              COMP_ID
            , ESTTERM_REF_ID
            , EST_ID
            , SEQ
            , POS_ID
            , POS_VALUE
            , DEPT_TYPE_REF_ID
            , WEIGHT
            , CREATE_USER
            )
            VALUES
            (
              @COMP_ID
            , @ESTTERM_REF_ID
            , @EST_ID
            , @SEQ
            , @POS_ID
            , @POS_VALUE
            , @DEPT_TYPE_REF_ID
            , @WEIGHT
            , @CREATE_USER
            )";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[2].Value = est_id;
            paramArray[3] = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[3].Value = seq;
            paramArray[4] = CreateDataParameter("@POS_ID", SqlDbType.NVarChar);
            paramArray[4].Value = pos_id;
            paramArray[5] = CreateDataParameter("@POS_VALUE", SqlDbType.NVarChar);
            paramArray[5].Value = pos_value;
            paramArray[6] = CreateDataParameter("@DEPT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[6].Value = dept_type_ref_id;
            paramArray[7] = CreateDataParameter("@WEIGHT", SqlDbType.Int);
            paramArray[7].Value = weight;
            paramArray[8] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[8].Value = create_user_ref_id;


            return DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
        }


        public int Delete_DB(IDbConnection conn, IDbTransaction trx
                            , object comp_id
                            , object estterm_ref_id
                            , object est_id
                            , object pos_id
                            , object pos_value
                            , object dept_type_ref_id)
        {
            string query = @"
DELETE FROM EST_POS_WEIGHT
    WHERE       COMP_ID             = @COMP_ID
        AND     ESTTERM_REF_ID      = @ESTTERM_REF_ID
        AND     EST_ID              = @EST_ID
        AND (   POS_ID              = @POS_ID	            OR @POS_ID              =''  )
        AND (   POS_VALUE           = @POS_VALUE	        OR @POS_VALUE           =''  )
        AND (   DEPT_TYPE_REF_ID    = @DEPT_TYPE_REF_ID     OR @DEPT_TYPE_REF_ID    = 0  )

";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[2].Value = est_id;
            paramArray[3] = CreateDataParameter("@POS_ID", SqlDbType.NVarChar);
            paramArray[3].Value = pos_id;
            paramArray[4] = CreateDataParameter("@POS_VALUE", SqlDbType.NVarChar);
            paramArray[4].Value = pos_value;
            paramArray[5] = CreateDataParameter("@DEPT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[5].Value = dept_type_ref_id;

            return DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
        }



        public DataTable Select_Est_Pos_Weight(object pos_id
                                            , object pos_table_name
                                            , object dept_type_ref_id_list
                                            , object comp_id
                                            , object estterm_ref_id
                                            , object est_id)
        {
            string query = string.Format(@"
SELECT  '{0}'               AS POS_ID
        , POS.POS_{0}_ID    AS POS_VALUE
        , POS.POS_{0}_NAME  AS POS_VALUE_NAME
        , PW.WEIGHT
        , PW.SEQ
        , PW.DEPT_TYPE_REF_ID
        , DI.TYPE_NAME      AS DEPT_TYPE_NAME
    FROM {1}                            POS
        LEFT OUTER JOIN EST_POS_WEIGHT  PW
            ON (
                    POS.POS_{0}_ID      =   PW.POS_VALUE 
                AND PW.POS_ID           =   POS_ID
                AND COMP_ID             =   @COMP_ID
                AND ESTTERM_REF_ID      =   @ESTTERM_REF_ID
                AND PW.DEPT_TYPE_REF_ID IN  ( {2} )
                AND EST_ID              =   @EST_ID
                )
        LEFT OUTER JOIN COM_DEPT_TYPE_INFO  DI
            ON (    
                    PW.DEPT_TYPE_REF_ID=DI.TYPE_REF_ID
                )
    ORDER BY PW.SEQ ASC
", pos_id, pos_table_name, dept_type_ref_id_list);

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[2].Value = est_id;


            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }
    }
}
