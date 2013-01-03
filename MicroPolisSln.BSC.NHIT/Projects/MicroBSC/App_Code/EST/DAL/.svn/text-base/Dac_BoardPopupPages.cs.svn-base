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
    public class Dac_BoardPopupPages : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int menu_ref_id
                        , int sort_order
                        , string use_yn
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_BOARD_POPUP_PAGE
	                            SET	SORT_ORDER          = @SORT_ORDER
                                    ,USE_YN             = @USE_YN
                                    ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	MENU_REF_ID		= @MENU_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
            paramArray[0]       = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[0].Value = menu_ref_id;
            paramArray[1]       = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[1].Value = sort_order;
	        paramArray[3] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[3].Value = use_yn;
	        paramArray[4] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[4].Value = update_date;
	        paramArray[5] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[5].Value = update_user;
         
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
         
        public DataSet Select(int menu_ref_id)
        {
            string query = @"SELECT	 BPP.MENU_REF_ID
                                    ,MEU.MENU_NAME
                                    ,BPP.SORT_ORDER
                                    ,BPP.USE_YN
                                    ,BPP.CREATE_DATE
                                    ,BPP.CREATE_USER
                                    ,BPP.UPDATE_DATE
                                    ,BPP.UPDATE_USER
                                    FROM	EST_BOARD_POPUP_PAGE BPP
                                    LEFT JOIN COM_MENU_INFO MEU
                                    ON MEU.MENU_REF_ID = BPP.MENU_REF_ID
                                    WHERE	(BPP.MENU_REF_ID = @MENU_REF_ID OR @MENU_REF_ID = 0)
                                    AND BPP.USE_YN = 'Y'
                                    ORDER BY BPP.SORT_ORDER";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[0].Value = menu_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "BOARDPOPUPPAGEGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int menu_ref_id
                        , int sort_order
                        , string use_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_BOARD_POPUP_PAGE(MENU_REF_ID
                                                    ,SORT_ORDER
			                                        ,USE_YN
			                                        ,CREATE_DATE
			                                        ,CREATE_USER
			                                        ,UPDATE_DATE
			                                        ,UPDATE_USER
			                                        )
		                                        VALUES	(@MENU_REF_ID
			                                        ,@SORT_ORDER
			                                        ,@USE_YN
			                                        ,@CREATE_DATE
			                                        ,@CREATE_USER
			                                        ,NULL
			                                        ,NULL)";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
	       
            paramArray[0]       = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[0].Value = menu_ref_id;
            paramArray[1]       = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[1].Value = sort_order;
	        paramArray[2] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[2].Value = use_yn;
	        paramArray[3] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[3].Value = create_date;
	        paramArray[4] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[4].Value = create_user;
         
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
                        , int meun_ref_id)
        {
            string query = @"DELETE	EST_BOARD_POPUP_PAGE
	                            WHERE	MENU_REF_ID = @MENU_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[0].Value = meun_ref_id;
         
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
    }
}
