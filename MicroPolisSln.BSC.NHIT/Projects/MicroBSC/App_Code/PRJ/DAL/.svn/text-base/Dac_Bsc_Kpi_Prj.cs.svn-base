using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.PRJ.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Prj
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Kpi_Prj
    /// Class Func     : PRJ_BUDGET Table Data Access
    /// CREATE DATE    : 2008-04-10 오후 3:04:58
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Prj : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int _iestterm_ref_id;
        private int _ikpi_ref_id;
        private int _iprj_ref_id;
        private Int32 _icreate_user;
        private DateTime _icreate_date;
        private Int32 _iupdate_user;
        private DateTime _iupdate_date;
        private String _txr_message;
        private String _txr_result;
        #endregion

        #region ============================== [Properties] ==============================
        public int IEstterm_Ref_Id
        {
            get { return _iestterm_ref_id; }
            set { _iestterm_ref_id = value; }
        }

        public int IKpi_Ref_Id
        {
            get { return _ikpi_ref_id; }
            set { _ikpi_ref_id = value; }
        }

        public int IPrj_Ref_Id
        {
            get { return _iprj_ref_id; }
            set { _iprj_ref_id = value; }
        }
        public int ICreate_User
        {
            get { return _icreate_user; }
            set { _icreate_user = value; }
        }
        public System.DateTime ICreate_Date
        {
            get { return _icreate_date; }
            set { _icreate_date = value; }
        }
        public int IUpdate_User
        {
            get { return _iupdate_user; }
            set { _iupdate_user = value; }
        }
        public System.DateTime IUpdate_Date
        {
            get { return _iupdate_date; }
            set { _iupdate_date = value; }
        }
        public String Transaction_Message
        {
            get { return _txr_message; }
            set { _txr_message = value; }
        }
        public String Transaction_Result
        {
            get { return _txr_result; }
            set { _txr_result = value; }
        }
        #endregion

        #region ============================== [Constructor] ==============================
        public Dac_Bsc_Kpi_Prj() { }
        
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iestterm_ref_id, int ikpi_ref_id, int iprj_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iprj_ref_id;
            paramArray[4]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;
            paramArray[5]       = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction = ParameterDirection.Output;
            paramArray[6]       = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_PRJ", "PKG_BSC_KPI_PRJ.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        

        internal protected int DeleteData_Dac
                (int iestterm_ref_id, int ikpi_ref_id, int iprj_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "D";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iprj_ref_id;
            paramArray[4]       = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5]       = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_PRJ", "PKG_BSC_KPI_PRJ.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, int iprj_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iprj_ref_id;
   

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_PRJ", "PKG_BSC_KPI_PRJ.PROC_SELECT_ONE"), "BSC_KPI_PRJ", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id, int iprj_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iprj_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_PRJ", "PKG_BSC_KPI_PRJ.PROC_SELECT_ALL"), "BSC_KPI_PRJ", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetTotalKpiPrjList_Dac(int iestterm_ref_id
                                  , int ikpi_ref_id
                                  , int iprj_ref_id
                                  , int iest_dept_ref_id
                                  , string iprj_type
                                  , string iprj_code
                                  , string iprj_name
                                  , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "ST";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iprj_ref_id;
            paramArray[4]       = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;
            paramArray[5]       = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar,20);
            paramArray[5].Value = iprj_type;
            paramArray[6]       = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar,30);
            paramArray[6].Value = iprj_code;
            paramArray[7]       = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar,100);
            paramArray[7].Value = iprj_name;
            paramArray[8] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value = itxr_user;
      

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_PRJ", "PKG_BSC_KPI_PRJ.PROC_SELECT_TOTAL"), "BSC_KPI_PRJ", null, paramArray, CommandType.StoredProcedure);
                       
            return ds;
        }

        /// <summary>
        /// 지표 리스트 조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iresult_input_type"></param>
        /// <param name="ikpi_code"></param>
        /// <param name="ikpi_name"></param>
        /// <param name="iuse_yn"></param>
        /// <param name="ichampion_name"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetKpiList(int iestterm_ref_id
            , int    iprj_ref_id
            , string iresult_input_type
            , string ikpi_code
            , string ikpi_name
            , string ichampion_name
            , int iest_dept_ref_id
            , string ikpi_group_ref_id
            , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SK";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iprj_ref_id;
            paramArray[3] = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = iresult_input_type;
            paramArray[4] = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[4].Value = ikpi_code;
            paramArray[5] = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[5].Value = ikpi_name;
            paramArray[6] = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[6].Value = ichampion_name;
            paramArray[7] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iest_dept_ref_id;
            paramArray[8] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[8].Value = ikpi_group_ref_id;
            paramArray[9] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_PRJ", "PKG_BSC_KPI_PRJ.PROC_SELECT_DEPT_KPI_LIST"), "BSC_KPI_PRJ", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetKpiCodePrjectList(int iestterm_ref_id
           , int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "KP";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_PRJ", "PKG_BSC_KPI_PRJ.PROC_SELECT_KPI_PRJ_LIST"), "BSC_KPI_PRJ", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
       
        #endregion
    }
}