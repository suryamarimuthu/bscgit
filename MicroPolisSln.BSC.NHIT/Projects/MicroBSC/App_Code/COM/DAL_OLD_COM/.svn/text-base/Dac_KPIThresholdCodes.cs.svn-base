using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC
{

    public class KPIThresholdCodes : DbAgentBase
    {
        public KPIThresholdCodes()
        {

        }

        public KPIThresholdCodes(int kpi_threshold_code_id)
        {
            DataSet ds = GetKPIThresholdCode(kpi_threshold_code_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _kpi_threshold_stepname = Convert.ToString(dr["KPI_THRESHOLD_STEPNAME"]);
                _base_min_value         = Convert.ToDouble(dr["BASE_MIN_VALUE"]);
                _base_max_value         = Convert.ToDouble(dr["BASE_MAX_VALUE"]);
                _mark_color             = Convert.ToString(dr["MARK_COLOR"]);
                _mark_image_path        = Convert.ToString(dr["MARK_IMAGE_PATH"]);
                _sequence               = Convert.ToInt32(dr["SEQUENCE"]);
                _kpi_threshold_code_id  = Convert.ToInt32(dr["KPI_THRESHOLD_CODE_ID"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private string _kpi_threshold_stepname;
        private double _base_min_value;
        private double _base_max_value;
        private string _mark_color;
        private string _mark_image_path;
        private int _sequence;
        private int _kpi_threshold_code_id;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public string KPI_Threshold_StepName
        {
            get
            {
                return _kpi_threshold_stepname;
            }
            set
            {
                _kpi_threshold_stepname = (value == null ? "" : value);
            }
        }

        public double Base_Min_Value
        {
            get
            {
                return _base_min_value;
            }
            set
            {
                _base_min_value = value;
            }
        }

        public double Base_Max_Value
        {
            get
            {
                return _base_max_value;
            }
            set
            {
                _base_max_value = value;
            }
        }

        public string Mark_Color
        {
            get
            {
                return _mark_color;
            }
            set
            {
                _mark_color = (value == null ? "" : value);
            }
        }

        public string Mark_Image_Path
        {
            get
            {
                return _mark_image_path;
            }
            set
            {
                _mark_image_path = (value == null ? "" : value);
            }
        }

        public int Sequence
        {
            get
            {
                return _sequence;
            }
            set
            {
                _sequence = value;
            }
        }

        public int Kpi_Threshold_Code_ID
        {
            get
            {
                return _kpi_threshold_code_id;
            }
            set
            {
                _kpi_threshold_code_id = value;
            }
        }
        #endregion

        public bool ModifyKPIThresholdCode(int kpi_threshold_code_id, string kpi_threshold_stepname, double base_min_value, double base_max_value, string mark_color, string mark_image_path, int sequence)
        {
            string query = @"UPDATE	COM_KPI_THRESHOLD_CODE
                                SET	KPI_THRESHOLD_STEPNAME  = @KPI_THRESHOLD_STEPNAME
	                                ,BASE_MIN_VALUE         = @BASE_MIN_VALUE
	                                ,BASE_MAX_VALUE         = @BASE_MAX_VALUE
	                                ,MARK_COLOR             = @MARK_COLOR
	                                ,MARK_IMAGE_PATH        = @MARK_IMAGE_PATH
	                                ,[SEQUENCE]             = @SEQUENCE
                                WHERE	KPI_THRESHOLD_CODE_ID = @KPI_THRESHOLD_CODE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@KPI_THRESHOLD_STEPNAME", SqlDbType.VarChar);
            paramArray[0].Value         = kpi_threshold_stepname;
            paramArray[1]               = CreateDataParameter("@BASE_MIN_VALUE", SqlDbType.Real);
            paramArray[1].Value         = base_min_value;
            paramArray[2]               = CreateDataParameter("@BASE_MAX_VALUE", SqlDbType.Real);
            paramArray[2].Value         = base_max_value;
            paramArray[3]               = CreateDataParameter("@MARK_COLOR", SqlDbType.VarChar);
            paramArray[3].Value         = mark_color;
            paramArray[4]               = CreateDataParameter("@MARK_IMAGE_PATH", SqlDbType.VarChar);
            paramArray[4].Value         = mark_image_path;
            paramArray[5]               = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[5].Value         = sequence;
            paramArray[6]               = CreateDataParameter("@KPI_THRESHOLD_CODE_ID", SqlDbType.Int);
            paramArray[6].Value         = kpi_threshold_code_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetKPIThresholdCode(int kpi_threshold_code_id)
        {
            string query = @"SELECT	T1.KPI_THRESHOLD_STEPNAME
	                                ,T1.BASE_MIN_VALUE
	                                ,T1.BASE_MAX_VALUE
	                                ,T1.MARK_COLOR
	                                ,T1.MARK_IMAGE_PATH
	                                ,T1.[SEQUENCE]
	                                ,T1.KPI_THRESHOLD_CODE_ID
                                FROM	COM_KPI_THRESHOLD_CODE T1
                                WHERE	T1.KPI_THRESHOLD_CODE_ID = @KPI_THRESHOLD_CODE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@KPI_THRESHOLD_CODE_ID", SqlDbType.Int);
            paramArray[0].Value         = kpi_threshold_code_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "KPITHRESHOLDCODEGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetAllKPIThresholdCode()
        {
            string query = @"SELECT	T1.KPI_THRESHOLD_STEPNAME
	                                ,T1.BASE_MIN_VALUE
	                                ,T1.BASE_MAX_VALUE
	                                ,T1.MARK_COLOR
	                                ,T1.MARK_IMAGE_PATH
	                                ,T1.[SEQUENCE]
	                                ,T1.KPI_THRESHOLD_CODE_ID
                                FROM	COM_KPI_THRESHOLD_CODE T1";

            DataSet ds = DbAgentObj.FillDataSet(query, "KPITHRESHOLDCODEGETALL", null, null, CommandType.Text);
            return ds;
        }

        public bool AddKPIThresholdCode(int kpi_threshold_code_id, string kpi_threshold_stepname, double base_min_value, double base_max_value, string mark_color, string mark_image_path, int sequence)
        {
            string query = @"INSERT INTO COM_KPI_THRESHOLD_CODE(KPI_THRESHOLD_STEPNAME
			                                                    ,BASE_MIN_VALUE
			                                                    ,BASE_MAX_VALUE
			                                                    ,MARK_COLOR
			                                                    ,MARK_IMAGE_PATH
			                                                    ,SEQUENCE
			                                                    ,KPI_THRESHOLD_CODE_ID
			                                                    )
		                                                    VALUES	(@KPI_THRESHOLD_STEPNAME
			                                                    ,@BASE_MIN_VALUE
			                                                    ,@BASE_MAX_VALUE
			                                                    ,@MARK_COLOR
			                                                    ,@MARK_IMAGE_PATH
			                                                    ,@SEQUENCE
			                                                    ,@KPI_THRESHOLD_CODE_ID
			                                                    )";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@KPI_THRESHOLD_STEPNAME", SqlDbType.VarChar);
            paramArray[0].Value         = kpi_threshold_stepname;
            paramArray[1]               = CreateDataParameter("@BASE_MIN_VALUE", SqlDbType.Real);
            paramArray[1].Value         = base_min_value;
            paramArray[2]               = CreateDataParameter("@BASE_MAX_VALUE", SqlDbType.Real);
            paramArray[2].Value         = base_max_value;
            paramArray[3]               = CreateDataParameter("@MARK_COLOR", SqlDbType.VarChar);
            paramArray[3].Value         = mark_color;
            paramArray[4]               = CreateDataParameter("@MARK_IMAGE_PATH", SqlDbType.VarChar);
            paramArray[4].Value         = mark_image_path;
            paramArray[5]               = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[5].Value         = sequence;
            paramArray[6]               = CreateDataParameter("@KPI_THRESHOLD_CODE_ID", SqlDbType.Int);
            paramArray[6].Value         = kpi_threshold_code_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveKPIThresholdCode(int kpi_threshold_code_id)
        {
            string query = @"DELETE	COM_KPI_THRESHOLD_CODE
                                WHERE	KPI_THRESHOLD_CODE_ID = @KPI_THRESHOLD_CODE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@KPI_THRESHOLD_CODE_ID", SqlDbType.Int);
            paramArray[0].Value         = kpi_threshold_code_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
