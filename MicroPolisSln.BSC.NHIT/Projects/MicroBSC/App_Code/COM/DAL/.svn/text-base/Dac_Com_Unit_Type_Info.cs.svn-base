using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    public class Dac_Com_Unit_Type_Info :DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private string 	_itype;
        private int 	_iunit_type_ref_id;
        private string 	_iunit_type;
        private string 	_iunit;
        private string 	_iformat_string;
        private int 	_idecimal_point;
        private string 	_irounding_type;
        private string 	_iuse_yn;
        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Itype
        {
            get 
            {
	            return _itype;
            }
            set
            {
	            _itype = ( value==null ? "" : value );
            }
        }
         
        public int Iunit_type_ref_id
        {
            get 
            {
	            return _iunit_type_ref_id;
            }
            set
            {
	            _iunit_type_ref_id = value;
            }
        }
         
        public string Iunit_type
        {
            get 
            {
	            return _iunit_type;
            }
            set
            {
	            _iunit_type = ( value==null ? "" : value );
            }
        }
         
        public string Iunit
        {
            get 
            {
	            return _iunit;
            }
            set
            {
	            _iunit = ( value==null ? "" : value );
            }
        }
         
        public string Iformat_string
        {
            get 
            {
	            return _iformat_string;
            }
            set
            {
	            _iformat_string = ( value==null ? "" : value );
            }
        }
         
        public int Idecimal_point
        {
            get 
            {
	            return _idecimal_point;
            }
            set
            {
	            _idecimal_point = value;
            }
        }
         
        public string Irounding_type
        {
            get 
            {
	            return _irounding_type;
            }
            set
            {
	            _irounding_type = ( value==null ? "" : value );
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
	            _iuse_yn = ( value==null ? "" : value );
            }
        }
         
        #endregion
         
        /*
         
         
            DataRow dr;
         
            if(ds.Tables[0].Rows.Count == 1)
            {
	            dr = ds.Tables[0].Rows[0];
	            _itype = (dr["iTYPE"]  == DBNull.Value) ? "" : Convert.ToString(dr["iTYPE"]);
	            _iunit_type_ref_id = (dr["iUNIT_TYPE_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["iUNIT_TYPE_REF_ID"]);
	            _iunit_type = (dr["iUNIT_TYPE"]  == DBNull.Value) ? "" : Convert.ToString(dr["iUNIT_TYPE"]);
	            _iunit = (dr["iUNIT"]  == DBNull.Value) ? "" : Convert.ToString(dr["iUNIT"]);
	            _iformat_string = (dr["iFORMAT_STRING"]  == DBNull.Value) ? "" : Convert.ToString(dr["iFORMAT_STRING"]);
	            _idecimal_point = (dr["iDECIMAL_POINT"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["iDECIMAL_POINT"]);
	            _irounding_type = (dr["iROUNDING_TYPE"]  == DBNull.Value) ? "" : Convert.ToString(dr["iROUNDING_TYPE"]);
	            _iuse_yn = (dr["iUSE_YN"]  == DBNull.Value) ? "" : Convert.ToString(dr["iUSE_YN"]);
	            _itxr_user = (dr["iTXR_USER"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["iTXR_USER"]);
            }
         
        */

        internal protected IDataParameterCollection InsertData_Dac(string iunit_type, string iunit, string iformat_string, int idecimal_point, string irounding_type, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iUNIT_TYPE", SqlDbType.VarChar);
            paramArray[1].Value = iunit_type;
            paramArray[2] = CreateDataParameter("@iUNIT", SqlDbType.VarChar);
            paramArray[2].Value = iunit;
            paramArray[3] = CreateDataParameter("@iFORMAT_STRING", SqlDbType.VarChar);
            paramArray[3].Value = iformat_string;
            paramArray[4] = CreateDataParameter("@iDECIMAL_POINT", SqlDbType.Int);
            paramArray[4].Value = idecimal_point;
            paramArray[5] = CreateDataParameter("@iROUNDING_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = irounding_type;
            paramArray[6] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[6].Value = iuse_yn;
            paramArray[7] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value = itxr_user;
            paramArray[8] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar);
            paramArray[8].Direction = ParameterDirection.Output;
            paramArray[9] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar);
            paramArray[9].Direction = ParameterDirection.Output;
            paramArray[10] = CreateDataParameter("@oUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[10].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_UNIT_TYPE_INFO", "PKG_COM_UNIT_TYPE_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            return col;
        }

        internal protected IDataParameterCollection UpdateData_Dac(int iunit_type_ref_id, string iunit_type, string iunit, string iformat_string, int idecimal_point, string irounding_type, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iunit_type_ref_id;
            paramArray[2] = CreateDataParameter("@iUNIT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = iunit_type;
            paramArray[3] = CreateDataParameter("@iUNIT", SqlDbType.VarChar);
            paramArray[3].Value = iunit;
            paramArray[4] = CreateDataParameter("@iFORMAT_STRING", SqlDbType.VarChar);
            paramArray[4].Value = iformat_string;
            paramArray[5] = CreateDataParameter("@iDECIMAL_POINT", SqlDbType.Int);
            paramArray[5].Value = idecimal_point;
            paramArray[6] = CreateDataParameter("@iROUNDING_TYPE", SqlDbType.VarChar);
            paramArray[6].Value = irounding_type;
            paramArray[7] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[7].Value = iuse_yn;
            paramArray[8] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value = itxr_user;
            paramArray[9] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar);
            paramArray[9].Direction = ParameterDirection.Output;
            paramArray[10] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar);
            paramArray[10].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_UNIT_TYPE_INFO", "PKG_COM_UNIT_TYPE_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            return col;
        }

        internal protected IDataParameterCollection DeleteData_Dac(int iunit_type_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "D";
            paramArray[1] = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iunit_type_ref_id;
            paramArray[2] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar);
            paramArray[2].Direction = ParameterDirection.Output;
            paramArray[3] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar);
            paramArray[3].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_UNIT_TYPE_INFO", "PKG_COM_UNIT_TYPE_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            return col;
        }

        internal protected DataSet GetAllList_Dac()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_UNIT_TYPE_INFO", "PKG_COM_UNIT_TYPE_INFO.PROC_SELECT_ALL"), "COM_UNIT_TYPE_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetOneList_Dac(int iunit_type_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1] = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iunit_type_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_UNIT_TYPE_INFO", "PKG_COM_UNIT_TYPE_INFO.PROC_SELECT_ONE"), "COM_UNIT_TYPE_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

    }
}
