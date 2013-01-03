using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    public class Dac_DeptTypeInfo : DbAgentBase
    {
        #region ============================== [Fields] ==============================

        private int _itype_ref_id;
        private string _itype_name;
        private int _isort_order;
        private string _itype_desc;
        private string _itype_image;
        private string _izipcode;
        private string _iaddress1;
        private string _iaddress2;
        private string _itel;
        private string _ifax;
        private string _isite_url;
        private string _ibrn;
        private string _iuse_yn;
        private int _imgr_user_id;
        private int _create_user;
        private DateTime _create_date;
        private int _update_user;
        private DateTime _update_date;
        private String _txr_message; // 처리결과메시지
        private String _txr_result; // 처리결과여부(Y,N)

        #endregion

        #region ============================== [Properties] ==============================

        public int Itype_ref_id
        {
            get
            {
                return _itype_ref_id;
            }
            set
            {
                _itype_ref_id = value;
            }
        }

        public string Itype_name
        {
            get
            {
                return _itype_name;
            }
            set
            {
                _itype_name = (value == null ? "" : value);
            }
        }

        public int Isort_order
        {
            get
            {
                return _isort_order;
            }
            set
            {
                _isort_order = value;
            }
        }

        public string Itype_desc
        {
            get
            {
                return _itype_desc;
            }
            set
            {
                _itype_desc = (value == null ? "" : value);
            }
        }

        public string Itype_image
        {
            get
            {
                return _itype_image;
            }
            set
            {
                _itype_image = value;
            }
        }

        public string Izipcode
        {
            get
            {
                return _izipcode;
            }
            set
            {
                _izipcode = (value == null ? "" : value);
            }
        }

        public string Iaddress1
        {
            get
            {
                return _iaddress1;
            }
            set
            {
                _iaddress1 = (value == null ? "" : value);
            }
        }

        public string Iaddress2
        {
            get
            {
                return _iaddress2;
            }
            set
            {
                _iaddress2 = (value == null ? "" : value);
            }
        }

        public string Itel
        {
            get
            {
                return _itel;
            }
            set
            {
                _itel = (value == null ? "" : value);
            }
        }

        public string Ifax
        {
            get
            {
                return _ifax;
            }
            set
            {
                _ifax = (value == null ? "" : value);
            }
        }

        public string Isite_url
        {
            get
            {
                return _isite_url;
            }
            set
            {
                _isite_url = (value == null ? "" : value);
            }
        }

        public string Ibrn
        {
            get
            {
                return _ibrn;
            }
            set
            {
                _ibrn = (value == null ? "" : value);
            }
        }

        public string Iuse_yn
        {
            get
            {
                return _iuse_yn;
            }
            set
            {
                _iuse_yn = (value == null ? "" : value);
            }
        }

        public int Imgr_user_id
        {
            get
            {
                return _imgr_user_id;
            }
            set
            {
                _imgr_user_id = value;
            }
        }


        public int Create_user
        {
            get
            {
                return _create_user;
            }
            set
            {
                _create_user = value;
            }
        }

        public DateTime Create_date
        {
            get
            {
                return _create_date;
            }
            set
            {
                _create_date = value;
            }
        }

        public int Update_user
        {
            get
            {
                return _update_user;
            }
            set
            {
                _update_user = value;
            }
        }

        public DateTime Update_date
        {
            get
            {
                return _update_date;
            }
            set
            {
                _update_date = value;
            }
        }

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

        #region ============================== [생성자] ==============================

        public Dac_DeptTypeInfo() { }

        public Dac_DeptTypeInfo(int itype_ref_id)
        {
            DataSet ds = this.GetOneList_Dac(itype_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _itype_ref_id   = (dr["TYPE_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TYPE_REF_ID"]);
                _itype_name     = (dr["TYPE_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["TYPE_NAME"]);
                _isort_order    = (dr["SORT_ORDER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
                _itype_desc     = (dr["TYPE_DESC"] == DBNull.Value) ? "" : Convert.ToString(dr["TYPE_DESC"]);
                _itype_image    = (dr["TYPE_IMAGE"] == DBNull.Value) ? "" : Convert.ToString(dr["TYPE_IMAGE"]);
                _izipcode       = (dr["ZIPCODE"] == DBNull.Value) ? "" : Convert.ToString(dr["ZIPCODE"]);
                _iaddress1      = (dr["ADDRESS1"] == DBNull.Value) ? "" : Convert.ToString(dr["ADDRESS1"]);
                _iaddress2      = (dr["ADDRESS2"] == DBNull.Value) ? "" : Convert.ToString(dr["ADDRESS2"]);
                _itel           = (dr["TEL"] == DBNull.Value) ? "" : Convert.ToString(dr["TEL"]);
                _ifax           = (dr["FAX"] == DBNull.Value) ? "" : Convert.ToString(dr["FAX"]);
                _isite_url      = (dr["SITE_URL"] == DBNull.Value) ? "" : Convert.ToString(dr["SITE_URL"]);
                _ibrn           = (dr["BRN"] == DBNull.Value) ? "" : Convert.ToString(dr["BRN"]);
                _iuse_yn        = (dr["USE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _imgr_user_id   = (dr["MGR_USER_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["MGR_USER_ID"]);
                _create_user    = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date    = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user    = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date    = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(string itype_name, int isort_order, string itype_desc, string itype_image, string izipcode, string iaddress1, string iaddress2, string itel, string ifax, string isite_url, string ibrn, int imgr_user_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iTYPE_NAME", SqlDbType.VarChar);
            paramArray[1].Value = itype_name;
            paramArray[2] = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            paramArray[2].Value = isort_order;
            paramArray[3] = CreateDataParameter("@iTYPE_DESC", SqlDbType.VarChar);
            paramArray[3].Value = itype_desc;
            paramArray[4] = CreateDataParameter("@iTYPE_IMAGE", SqlDbType.Image);
            paramArray[4].Value = itype_image;
            paramArray[5] = CreateDataParameter("@iZIPCODE", SqlDbType.VarChar);
            paramArray[5].Value = izipcode;
            paramArray[6] = CreateDataParameter("@iADDRESS1", SqlDbType.VarChar);
            paramArray[6].Value = iaddress1;
            paramArray[7] = CreateDataParameter("@iADDRESS2", SqlDbType.VarChar);
            paramArray[7].Value = iaddress2;
            paramArray[8] = CreateDataParameter("@iTEL", SqlDbType.VarChar);
            paramArray[8].Value = itel;
            paramArray[9] = CreateDataParameter("@iFAX", SqlDbType.VarChar);
            paramArray[9].Value = ifax;
            paramArray[10] = CreateDataParameter("@iSITE_URL", SqlDbType.VarChar);
            paramArray[10].Value = isite_url;
            paramArray[11] = CreateDataParameter("@iBRN", SqlDbType.VarChar);
            paramArray[11].Value = ibrn;
            paramArray[12] = CreateDataParameter("@iMGR_USER_ID", SqlDbType.Int);
            paramArray[12].Value = imgr_user_id;
            paramArray[13] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[13].Value = itxr_user;
            paramArray[14] = CreateDataParameter("@iRTN_MSG", SqlDbType.VarChar);
            paramArray[14].Direction = ParameterDirection.Output;
            paramArray[15] = CreateDataParameter("@iRTN_COMPLETE_YN", SqlDbType.Char);
            paramArray[15].Direction = ParameterDirection.Output;
            paramArray[16] = CreateDataParameter("@oTYPE_REF_ID", SqlDbType.Int);
            paramArray[16].Direction = ParameterDirection.Output;


            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_DEPT_TYPE_INFO", "PKG_COM_DEPT_TYPE_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Itype_ref_id        = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oTYPE_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int itype_ref_id, string itype_name, int isort_order, string itype_desc, string itype_image, string izipcode, string iaddress1, string iaddress2, string itel, string ifax, string isite_url, string ibrn, int imgr_user_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iTYPE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = itype_ref_id;
            paramArray[2] = CreateDataParameter("@iTYPE_NAME", SqlDbType.VarChar);
            paramArray[2].Value = itype_name;
            paramArray[3] = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            paramArray[3].Value = isort_order;
            paramArray[4] = CreateDataParameter("@iTYPE_DESC", SqlDbType.VarChar);
            paramArray[4].Value = itype_desc;
            paramArray[5] = CreateDataParameter("@iTYPE_IMAGE", SqlDbType.Image);
            paramArray[5].Value = itype_image;
            paramArray[6] = CreateDataParameter("@iZIPCODE", SqlDbType.VarChar);
            paramArray[6].Value = izipcode;
            paramArray[7] = CreateDataParameter("@iADDRESS1", SqlDbType.VarChar);
            paramArray[7].Value = iaddress1;
            paramArray[8] = CreateDataParameter("@iADDRESS2", SqlDbType.VarChar);
            paramArray[8].Value = iaddress2;
            paramArray[9] = CreateDataParameter("@iTEL", SqlDbType.VarChar);
            paramArray[9].Value = itel;
            paramArray[10] = CreateDataParameter("@iFAX", SqlDbType.VarChar);
            paramArray[10].Value = ifax;
            paramArray[11] = CreateDataParameter("@iSITE_URL", SqlDbType.VarChar);
            paramArray[11].Value = isite_url;
            paramArray[12] = CreateDataParameter("@iBRN", SqlDbType.VarChar);
            paramArray[12].Value = ibrn;
            paramArray[13] = CreateDataParameter("@iMGR_USER_ID", SqlDbType.Int);
            paramArray[13].Value = imgr_user_id;
            paramArray[14] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[14].Value = itxr_user;
            paramArray[15] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar);
            paramArray[15].Direction = ParameterDirection.Output;
            paramArray[16] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char);
            paramArray[16].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_DEPT_TYPE_INFO", "PKG_COM_DEPT_TYPE_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int itype_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "D";
            paramArray[1] = CreateDataParameter("@iTYPE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = itype_ref_id;
            paramArray[2] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value = itxr_user;
            paramArray[3] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_DEPT_TYPE_INFO", "PKG_COM_DEPT_TYPE_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected DataSet GetAllList_Dac()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_DEPT_TYPE_INFO", "PKG_COM_DEPT_TYPE_INFO.PROC_SELECT_ALL"), "COM_DEPT_TYPE_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetOneList_Dac(int itype_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1] = CreateDataParameter("@iTYPE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = itype_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_DEPT_TYPE_INFO", "PKG_COM_DEPT_TYPE_INFO.PROC_SELECT_ONE"), "COM_DEPT_TYPE_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetDeptTypeSortList_Dac(int estterm_ref_id, int dept_ref_id)
        {
            string query = @"
                                SELECT TYPE_REF_ID,
                                       TYPE_NAME,
                                       'N' AS HOME_YN_ORG,
                                       'N' AS HEADER_YN_ORG,
                                       'N' AS CONTENT_YN_ORG,
                                       7   AS POSITION_ORG,
                                       SORT_ORDER
                                FROM COM_DEPT_TYPE_INFO
                               WHERE USE_YN = 'Y'
                                 AND SORT_ORDER > (SELECT SORT_ORDER FROM COM_DEPT_TYPE_INFO WHERE TYPE_REF_ID = 
                                                  (SELECT DEPT_TYPE FROM EST_DEPT_INFO WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND EST_DEPT_REF_ID = @DEPT_REF_ID))
                              ORDER BY SORT_ORDER
            ";


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query,"DEPT_TYPE_SORT_LIST", null, paramArray, CommandType.Text);
            return ds;
        }


        internal protected DataTable GetDeptTypeList_Dac()
        {
            string query = @"
                                SELECT TYPE_REF_ID
		                             , TYPE_NAME
		                             , 'N' AS HOME_YN_ORG
		                             , 'N' AS HEADER_YN_ORG
		                             , 'N' AS CONTENT_YN_ORG
                                     , 7   AS POSITION_ORG
	                              FROM COM_DEPT_TYPE_INFO
		                         WHERE USE_YN = 'Y'
	                             ORDER BY SORT_ORDER ";

            return DbAgentObj.FillDataSet(query, "COM_DEPT_TYPE_INFO", null, null, CommandType.Text).Tables[0];
        }

//        internal protected int ModifyDeptTypeList_Dac(int type_ref_id, string home_yn_org, string header_yn_org, string content_yn_org)
//        {
//            string query = @"UPDATE COM_DEPT_TYPE_INFO
//	                            SET   HOME_YN_ORG		= @HOME_YN_ORG
//		                            , HEADER_YN_ORG		= @HEADER_YN_ORG
//		                            , CONTENT_YN_ORG	= @CONTENT_YN_ORG
//	                            WHERE TYPE_REF_ID		= @TYPE_REF_ID";

//            IDbDataParameter[] paramArray = CreateDataParameter[4];

//            paramArray[0]       = CreateDataParameter("@TYPE_REF_ID", SqlDbType.Int);
//            paramArray[0].Value = type_ref_id;
//            paramArray[1]       = CreateDataParameter("@HOME_YN_ORG", SqlDbType.Char, 1);
//            paramArray[1].Value = home_yn_org;
//            paramArray[2]       = CreateDataParameter("@HEADER_YN_ORG", SqlDbType.Char, 1);
//            paramArray[2].Value = header_yn_org;
//            paramArray[3]       = CreateDataParameter("@CONTENT_YN_ORG", SqlDbType.Char, 1);
//            paramArray[3].Value = content_yn_org;
            
//            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
//            return affectedRow;
//        }

        #endregion
    }
}
