using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class Dac_EstDeptInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int est_dept_ref_id
                        , int estterm_ref_id
                        , int dept_ref_id
                        , int up_est_dept_id
                        , int dept_level
                        , string dept_name
                        , bool temp_flag
                        , int est_dept_group_id
                        , int dept_type
                        , int sort_order
                        , string view_yn_org
                        , string header_img_org
                        , int sort_org
                        , string dept_name_org
                        , string industry_type
                        , int industry_type_order
                        , int update_user
                        , DateTime update_date)
        {
            string query = @"UPDATE	EST_DEPT_INFO
                                SET	ESTTERM_REF_ID      = @ESTTERM_REF_ID
	                                ,DEPT_REF_ID        = @DEPT_REF_ID
	                                ,UP_EST_DEPT_ID     = @UP_EST_DEPT_ID
	                                ,DEPT_LEVEL         = @DEPT_LEVEL
	                                ,DEPT_NAME          = @DEPT_NAME
	                                ,TEMP_FLAG          = @TEMP_FLAG
	                                ,EST_DEPT_GROUP_ID  = @EST_DEPT_GROUP_ID
	                                ,DEPT_TYPE          = @DEPT_TYPE
	                                ,SORT_ORDER         = @SORT_ORDER
	                                ,VIEW_YN_ORG        = @VIEW_YN_ORG
	                                ,HEADER_IMG_ORG     = @HEADER_IMG_ORG
	                                ,SORT_ORG           = @SORT_ORG
	                                ,DEPT_NAME_ORG      = @DEPT_NAME_ORG
	                                ,INDUSTRY_TYPE      = @INDUSTRY_TYPE
	                                ,INDUSTRY_TYPE_ORDER= @INDUSTRY_TYPE_ORDER
	                                ,UPDATE_USER        = @UPDATE_USER
	                                ,UPDATE_DATE        = @UPDATE_DATE
                                WHERE	EST_DEPT_REF_ID = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0]           = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value     = est_dept_ref_id;
            paramArray[1]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = estterm_ref_id;
            paramArray[2]           = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = dept_ref_id;
            paramArray[3]           = CreateDataParameter("@UP_EST_DEPT_ID", SqlDbType.Int);
            paramArray[3].Value     = up_est_dept_id;
            paramArray[4]           = CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
            paramArray[4].Value     = dept_level;
            paramArray[5]           = CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar, 100);
            paramArray[5].Value     = dept_name;
            paramArray[6]           = CreateDataParameter("@TEMP_FLAG", SqlDbType.Bit);
            paramArray[6].Value     = temp_flag;
            paramArray[7]           = CreateDataParameter("@EST_DEPT_GROUP_ID", SqlDbType.Int);
            paramArray[7].Value     = est_dept_group_id;
            paramArray[8]           = CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
            paramArray[8].Value     = dept_type;
            paramArray[9]           = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[9].Value     = sort_order;
            paramArray[10]          = CreateDataParameter("@VIEW_YN_ORG", SqlDbType.Char, 1);
            paramArray[10].Value    = view_yn_org;
            paramArray[11]          = CreateDataParameter("@HEADER_IMG_ORG", SqlDbType.Char, 1);
            paramArray[11].Value    = header_img_org;
            paramArray[12]          = CreateDataParameter("@SORT_ORG", SqlDbType.Int);
            paramArray[12].Value    = sort_org;
            paramArray[13]          = CreateDataParameter("@DEPT_NAME_ORG", SqlDbType.VarChar, 50);
            paramArray[13].Value    = dept_name_org;
            paramArray[14]          = CreateDataParameter("@INDUSTRY_TYPE", SqlDbType.VarChar, 50);
            paramArray[14].Value    = industry_type;
            paramArray[15]          = CreateDataParameter("@INDUSTRY_TYPE_ORDER", SqlDbType.Int);
            paramArray[15].Value    = industry_type_order;
            paramArray[16]          = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[16].Value    = update_user;
            paramArray[17]          = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[17].Value    = update_date;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select(int estterm_ref_id, int est_dept_ref_id)
        {
            string query = @"SELECT	 EST_DEPT_REF_ID
	                                ,ESTTERM_REF_ID
	                                ,DEPT_REF_ID
	                                ,UP_EST_DEPT_ID
	                                ,DEPT_LEVEL
	                                ,DEPT_NAME
	                                ,TEMP_FLAG
	                                ,EST_DEPT_GROUP_ID
	                                ,DEPT_TYPE
	                                ,SORT_ORDER
	                                ,VIEW_YN_ORG
	                                ,HEADER_IMG_ORG
	                                ,SORT_ORG
	                                ,DEPT_NAME_ORG
	                                ,INDUSTRY_TYPE
	                                ,INDUSTRY_TYPE_ORDER
	                                ,CREATE_USER
	                                ,CREATE_DATE
	                                ,UPDATE_USER
	                                ,UPDATE_DATE
                                FROM	EST_DEPT_INFO 
                                    WHERE	(ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                        AND (EST_DEPT_REF_ID    = @EST_DEPT_REF_ID  OR @EST_DEPT_REF_ID = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }


        public DataSet SelectDeptDetail(int estterm_ref_id, string est_id)
        {
            string query = @"SELECT	DI.EST_DEPT_REF_ID
                                    ,DI.ESTTERM_REF_ID
                                    ,DI.DEPT_REF_ID
                                    ,DI.UP_EST_DEPT_ID
                                    ,DI.DEPT_LEVEL
                                    ,DI.DEPT_NAME
                                    ,DI.TEMP_FLAG
                                    ,DI.EST_DEPT_GROUP_ID
                                    ,DI.DEPT_TYPE
                                    ,DI.SORT_ORDER
                                    ,DI.VIEW_YN_ORG
                                    ,DI.HEADER_IMG_ORG
                                    ,DI.SORT_ORG
                                    ,DI.DEPT_NAME_ORG
                                    ,DI.INDUSTRY_TYPE
                                    ,DI.INDUSTRY_TYPE_ORDER
                                    ,DI.CREATE_USER
                                    ,DI.CREATE_DATE
                                    ,DI.UPDATE_USER
                                    ,DI.UPDATE_DATE
                                    ,DE.SCALE_ID
                                    ,DE.EST_GRP_ID
                                    ,DE.WEIGHT
                                    ,DE.WEIGHT_TYPE
                            FROM	EST_DEPT_INFO DI
                                LEFT OUTER JOIN EST_DEPT_EST_DETAIL DE
                                    ON DE.ESTTERM_REF_ID    = DI.ESTTERM_REF_ID 
                                    AND DE.EST_DEPT_REF_ID  = DI.EST_DEPT_REF_ID
                                    AND (DE.EST_ID          = @EST_ID           OR  @EST_ID = '')
                            WHERE	(DI.ESTTERM_REF_ID      = @ESTTERM_REF_ID   OR  @ESTTERM_REF_ID  = '')";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar,6);
            paramArray[1].Value = est_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }


        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int est_dept_ref_id
                        , int estterm_ref_id
                        , int dept_ref_id
                        , int up_est_dept_id
                        , int dept_level
                        , string dept_name
                        , bool temp_flag
                        , int est_dept_group_id
                        , int dept_type
                        , int sort_order
                        , string view_yn_org
                        , string header_img_org
                        , int sort_org
                        , string dept_name_org
                        , string industry_type
                        , int industry_type_order
                        , int create_user
                        , DateTime create_date)
        {
            string query = @"INSERT INTO EST_DEPT_INFO(EST_DEPT_REF_ID
			                                        ,ESTTERM_REF_ID
			                                        ,DEPT_REF_ID
			                                        ,UP_EST_DEPT_ID
			                                        ,DEPT_LEVEL
			                                        ,DEPT_NAME
			                                        ,TEMP_FLAG
			                                        ,EST_DEPT_GROUP_ID
			                                        ,DEPT_TYPE
			                                        ,SORT_ORDER
			                                        ,VIEW_YN_ORG
			                                        ,HEADER_IMG_ORG
			                                        ,SORT_ORG
			                                        ,DEPT_NAME_ORG
			                                        ,INDUSTRY_TYPE
			                                        ,INDUSTRY_TYPE_ORDER
			                                        ,CREATE_USER
			                                        ,CREATE_DATE
			                                        ,UPDATE_USER
			                                        ,UPDATE_DATE
			                                        )
		                                        VALUES	(@EST_DEPT_REF_ID
			                                        ,@ESTTERM_REF_ID
			                                        ,@DEPT_REF_ID
			                                        ,@UP_EST_DEPT_ID
			                                        ,@DEPT_LEVEL
			                                        ,@DEPT_NAME
			                                        ,@TEMP_FLAG
			                                        ,@EST_DEPT_GROUP_ID
			                                        ,@DEPT_TYPE
			                                        ,@SORT_ORDER
			                                        ,@VIEW_YN_ORG
			                                        ,@HEADER_IMG_ORG
			                                        ,@SORT_ORG
			                                        ,@DEPT_NAME_ORG
			                                        ,@INDUSTRY_TYPE
			                                        ,@INDUSTRY_TYPE_ORDER
			                                        ,@CREATE_USER
			                                        ,@CREATE_DATE
			                                        ,NULL
			                                        ,NULL) ";

            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0]           = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value     = est_dept_ref_id;
            paramArray[1]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = estterm_ref_id;
            paramArray[2]           = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = dept_ref_id;
            paramArray[3]           = CreateDataParameter("@UP_EST_DEPT_ID", SqlDbType.Int);
            paramArray[3].Value     = up_est_dept_id;
            paramArray[4]           = CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
            paramArray[4].Value     = dept_level;
            paramArray[5]           = CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar, 100);
            paramArray[5].Value     = dept_name;
            paramArray[6]           = CreateDataParameter("@TEMP_FLAG", SqlDbType.Bit);
            paramArray[6].Value     = temp_flag;
            paramArray[7]           = CreateDataParameter("@EST_DEPT_GROUP_ID", SqlDbType.Int);
            paramArray[7].Value     = est_dept_group_id;
            paramArray[8]           = CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
            paramArray[8].Value     = dept_type;
            paramArray[9]           = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[9].Value     = sort_order;
            paramArray[10]          = CreateDataParameter("@VIEW_YN_ORG", SqlDbType.Char, 1);
            paramArray[10].Value    = view_yn_org;
            paramArray[11]          = CreateDataParameter("@HEADER_IMG_ORG", SqlDbType.Char, 1);
            paramArray[11].Value    = header_img_org;
            paramArray[12]          = CreateDataParameter("@SORT_ORG", SqlDbType.Int);
            paramArray[12].Value    = sort_org;
            paramArray[13]          = CreateDataParameter("@DEPT_NAME_ORG", SqlDbType.VarChar, 50);
            paramArray[13].Value    = dept_name_org;
            paramArray[14]          = CreateDataParameter("@INDUSTRY_TYPE", SqlDbType.VarChar, 50);
            paramArray[14].Value    = industry_type;
            paramArray[15]          = CreateDataParameter("@INDUSTRY_TYPE_ORDER", SqlDbType.Int);
            paramArray[15].Value    = industry_type_order;
            paramArray[16]          = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[16].Value    = create_user;
            paramArray[17]          = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[17].Value    = create_date;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , int est_dept_ref_id)
        {
            string query = @"DELETE	EST_DEPT_INFO
                                WHERE	EST_DEPT_REF_ID = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = est_dept_ref_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Count(int est_dept_ref_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_DEPT_INFO
                                WHERE	(EST_DEPT_REF_ID = @EST_DEPT_REF_ID OR @EST_DEPT_REF_ID = '')";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = est_dept_ref_id;

            try
            {
                return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CopyEstDept(IDbConnection conn, IDbTransaction trx, object org_estterm_ref_id, object new_estterm_ref_id, object reg_user)
        {
            // 평가부서는 여러사람이 쓰는 것이 아니므로 동적으로 임시테이블을 만들지 않았음
            string strQuery = @"
IF NOT EXISTS (SELECT * FROM EST_DEPT_INFO WHERE ESTTERM_REF_ID = @NEW_ESTTERM_REF_ID AND UP_EST_DEPT_ID <> 0)
BEGIN
    DELETE FROM EST_DEPT_INFO   WHERE ESTTERM_REF_ID    = @NEW_ESTTERM_REF_ID

    INSERT INTO EST_DEPT_INFO
        (ESTTERM_REF_ID,        DEPT_REF_ID,        UP_EST_DEPT_ID,     DEPT_LEVEL
        ,DEPT_NAME,             TEMP_FLAG,          EST_DEPT_GROUP_ID,  DEPT_TYPE,          SORT_ORDER
        ,VIEW_YN_ORG,           HEADER_IMG_ORG,     SORT_ORG,           DEPT_NAME_ORG,      INDUSTRY_TYPE
        ,INDUSTRY_TYPE_ORDER,   CREATE_USER,        CREATE_DATE,        UPDATE_USER,        UPDATE_DATE)
    SELECT
         @NEW_ESTTERM_REF_ID,   DEPT_REF_ID,        UP_EST_DEPT_ID,     DEPT_LEVEL
        ,DEPT_NAME,             TEMP_FLAG,          EST_DEPT_GROUP_ID,  DEPT_TYPE,          SORT_ORDER
        ,VIEW_YN_ORG,           HEADER_IMG_ORG,     SORT_ORG,           DEPT_NAME_ORG,      INDUSTRY_TYPE
        ,INDUSTRY_TYPE_ORDER,   @REG_USER,          GETDATE(),          @REG_USER,          GETDATE()
    FROM    EST_DEPT_INFO
    WHERE   ESTTERM_REF_ID  = @ORG_ESTTERM_REF_ID
    ORDER BY EST_DEPT_REF_ID

    SELECT * INTO TEMP_COPY_EST_DEPT_INFO FROM EST_DEPT_INFO WHERE ESTTERM_REF_ID IN (@ORG_ESTTERM_REF_ID, @NEW_ESTTERM_REF_ID)

    UPDATE EST_DEPT_INFO
        SET
            UP_EST_DEPT_ID  = ISNULL(C.EST_DEPT_REF_ID, 0)
    FROM    EST_DEPT_INFO   A
    LEFT OUTER JOIN TEMP_COPY_EST_DEPT_INFO   B   ON  B.ESTTERM_REF_ID    = @ORG_ESTTERM_REF_ID
                                                AND B.EST_DEPT_REF_ID   = A.UP_EST_DEPT_ID
    LEFT OUTER JOIN TEMP_COPY_EST_DEPT_INFO   C   ON  C.ESTTERM_REF_ID    = @NEW_ESTTERM_REF_ID
                                                AND ISNULL(C.DEPT_REF_ID, -9999)       = ISNULL(B.DEPT_REF_ID, -9999)
                                                AND ISNULL(C.DEPT_LEVEL, -9999)        = ISNULL(B.DEPT_LEVEL, -9999)
                                                AND ISNULL(C.DEPT_NAME, 'XXXXXXXXXX')         = ISNULL(B.DEPT_NAME, 'XXXXXXXXXX')
                                                AND ISNULL(C.SORT_ORDER, -9999)        = ISNULL(B.SORT_ORDER, -9999)
    WHERE   A.ESTTERM_REF_ID  = @NEW_ESTTERM_REF_ID
END
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ORG_ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = org_estterm_ref_id;
            paramArray[1] = CreateDataParameter("@NEW_ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = new_estterm_ref_id;
            paramArray[2] = CreateDataParameter("@REG_USER", SqlDbType.Int);
            paramArray[2].Value = reg_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) > 0)
                return true;
            return false;
        }
    }
}
