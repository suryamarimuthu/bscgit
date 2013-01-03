using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_DeptPosScales
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private int _estterm_ref_id;
        private int _dept_ref_id;
        private string _est_id;
        private int _seq;
        private string _pos_id;
        private string _pos_value;
        private string _scale_id;
        private DateTime _update_date;
        private int _update_user;

        private Dac_DeptPosScales _deptPosScale = new Dac_DeptPosScales();

        #endregion

        #region ============================== [Properties] ==============================

        public int Comp_ID
        {
            get
            {
                return _comp_id;
            }
            set
            {
                _comp_id = value;
            }
        }

        public int Estterm_Ref_ID
        {
            get
            {
                return _estterm_ref_id;
            }
            set
            {
                _estterm_ref_id = value;
            }
        }

        public int Dept_Ref_ID
        {
            get
            {
                return _dept_ref_id;
            }
            set
            {
                _dept_ref_id = value;
            }
        }

        public string Est_ID
        {
            get
            {
                return _est_id;
            }
            set
            {
                _est_id = (value == null ? "" : value);
            }
        }

        public int Seq
        {
            get
            {
                return _seq;
            }
            set
            {
                _seq = value;
            }
        }

        public string Pos_ID
        {
            get
            {
                return _pos_id;
            }
            set
            {
                _pos_id = (value == null ? "" : value);
            }
        }

        public string Pos_Value
        {
            get
            {
                return _pos_value;
            }
            set
            {
                _pos_value = (value == null ? "" : value);
            }
        }

        public string Scale_ID
        {
            get
            {
                return _scale_id;
            }
            set
            {
                _scale_id = (value == null ? "" : value);
            }
        }

        public DateTime Update_Date
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

        public int Update_User
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
        #endregion

        public Biz_DeptPosScales()
        {

        }

        public Biz_DeptPosScales(int comp_id, int estterm_ref_id, int dept_ref_id, string est_id)
        {
            DataSet ds = _deptPosScale.Select(null, null, comp_id, estterm_ref_id, dept_ref_id, est_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _estterm_ref_id     = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _dept_ref_id        = (dr["DEPT_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_REF_ID"]);
                _est_id             = (dr["EST_ID"]          == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _seq                = (dr["SEQ"]             == DBNull.Value) ? 0 : Convert.ToInt32(dr["SEQ"]);
                _pos_id             = (dr["POS_ID"]          == DBNull.Value) ? "" : (string)dr["POS_ID"];
                _pos_value          = (dr["POS_VALUE"]       == DBNull.Value) ? "" : (string)dr["POS_VALUE"];
                _scale_id           = (dr["SCALE_ID"]        == DBNull.Value) ? "" : (string)dr["SCALE_ID"];
                _update_date        = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user        = (dr["UPDATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool SaveDeptPosWithWeight( DataTable dtWeight )
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			object scale_id;

            try
            {
                foreach( DataRow drItem in dtWeight.Rows )
                {
                    _comp_id           = DataTypeUtility.GetToInt32( drItem["COMP_ID"] );
                    _estterm_ref_id    = DataTypeUtility.GetToInt32( drItem["ESTTERM_REF_ID"] );
                    _dept_ref_id       = DataTypeUtility.GetToInt32( drItem["DEPT_REF_ID"] );
                    _est_id            = drItem["EST_ID"].ToString();

					if ( drItem["WEIGHT"].ToString().Length == 0 )
					{
						scale_id = DBNull.Value;
					}
					else
					{
						scale_id = DataTypeUtility.GetToFloat( drItem["SCALE_ID"] );
					}

                    _update_date       = DataTypeUtility.GetToDateTime( drItem["DATE"] );
                    _update_user       = DataTypeUtility.GetToInt32( drItem["USER"] );

                    if ( IsExist(_comp_id, _estterm_ref_id, _dept_ref_id, _est_id ) == true )
                    {
                        affectedRow += _deptPosScale.Update( null
                                                            , null
                                                            , _comp_id
                                                            , _estterm_ref_id
                                                            , _dept_ref_id
                                                            , _est_id
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , scale_id
                                                            , _update_date
                                                            , _update_user);
                    }
                    else
                    {
                        affectedRow += _deptPosScale.Insert(  null
                                                            ,  null
                                                            , _comp_id
                                                            , _estterm_ref_id
                                                            , _dept_ref_id
                                                            , _est_id
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , scale_id
                                                            , _update_date
                                                            , _update_user );
                    }
                }

                trx.Commit();
            }
            catch( Exception ex )
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool ModifyDeptPosScale(  int comp_id
                                        , int estterm_ref_id
                                        , int dept_ref_id
                                        , string est_id
                                        , int seq
                                        , string pos_id
                                        , string pos_value
                                        , string scale_id
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _deptPosScale.Update(  null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , dept_ref_id
                                                , est_id
                                                , seq
                                                , pos_id
                                                , pos_value
                                                , scale_id
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool CopyDataFromTo(int comp_id
                                , int estterm_ref_id_from
                                , int estterm_ref_id_to
                                , DateTime create_date
                                , int create_user)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _deptPosScale.Delete(  conn
                                                    , trx
                                                    , comp_id
                                                    , estterm_ref_id_to
                                                    , 0
                                                    , ""
                                                    , 0);

                affectedRow += _deptPosScale.InsertDataFromTo(conn
                                                            , trx
                                                            , comp_id
                                                            , estterm_ref_id_from
                                                            , estterm_ref_id_to
                                                            , create_date
                                                            , create_user);

                trx.Commit();
            }
            catch( Exception ex )
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetDeptPosScale(int comp_id
                                    , int estterm_ref_id
                                    , int dept_ref_id
                                    , string est_id)
        {
            return _deptPosScale.Select(  null
                                        , null
                                        , comp_id
                                        , estterm_ref_id
                                        , dept_ref_id
                                        , est_id); 
        }

        public bool AddDeptPosScale( int comp_id
                                    , int estterm_ref_id
                                    , int dept_ref_id
                                    , string est_id
                                    , int seq
                                    , string pos_id
                                    , string pos_value
                                    , string scale_id
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _deptPosScale.Insert(   null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , dept_ref_id
                                                , est_id
                                                , seq
                                                , pos_id
                                                , pos_value
                                                , scale_id
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool SaveDeptPosScaleAll(DataTable dtDept, DataTable dtScaleData)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if(dtScaleData.Rows.Count > 0) 
                {
                    foreach( DataRow dataRowDept in dtDept.Rows )
                    {
                        affectedRow += _deptPosScale.Delete(  conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dtScaleData.Rows[0]["COMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dtScaleData.Rows[0]["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRowDept["DEPT_REF_ID"])
                                                            , DataTypeUtility.GetValue(dtScaleData.Rows[0]["EST_ID"])
                                                            , 0);
                    }
                }

                foreach( DataRow dataRowDept in dtDept.Rows )
                {
                    foreach( DataRow dataRowScaleData in dtScaleData.Rows )
                    {
                        affectedRow = _deptPosScale.Insert(   conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRowScaleData["COMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRowScaleData["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRowDept["DEPT_REF_ID"])
                                                            , DataTypeUtility.GetValue(dataRowScaleData["EST_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRowScaleData["SEQ"])
                                                            , DataTypeUtility.GetValue(dataRowScaleData["POS_ID"])
                                                            , DataTypeUtility.GetValue(dataRowScaleData["POS_VALUE"])
                                                            , DataTypeUtility.GetValue(dataRowScaleData["SCALE_ID"])
                                                            , DataTypeUtility.GetToDateTime(dataRowScaleData["DATE"])
                                                            , DataTypeUtility.GetToInt32(dataRowScaleData["USER"]));
                    }
                }

                trx.Commit();
            }
            catch( Exception ex )
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool InitDept(DataTable dtDept)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach( DataRow dataRowDept in dtDept.Rows )
                {
                    affectedRow += _deptPosScale.Delete(  conn
                                                        , trx
                                                        , DataTypeUtility.GetToInt32(dataRowDept["COMP_ID"])
                                                        , DataTypeUtility.GetToInt32(dataRowDept["ESTTERM_REF_ID"])
                                                        , DataTypeUtility.GetToInt32(dataRowDept["DEPT_REF_ID"])
                                                        , DataTypeUtility.GetValue(dataRowDept["EST_ID"])
                                                        , 0);
                }

                trx.Commit();
            }
            catch( Exception ex )
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool RemoveDeptPosScale(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach( DataRow dataRow in dataTable.Rows )
                {
                    affectedRow += _deptPosScale.Delete(  conn
                                                        , trx
                                                        , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                        , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                        , DataTypeUtility.GetToInt32(dataRow["DEPT_REF_ID"])
                                                        , DataTypeUtility.GetValue(dataRow["EST_ID"])
                                                        , DataTypeUtility.GetToInt32(dataRow["SEQ"]));
                }

                if(dataTable.Rows.Count > 0)
                {
                    DataTable dtPos = _deptPosScale.Select(   conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataTable.Rows[0]["COMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataTable.Rows[0]["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataTable.Rows[0]["DEPT_REF_ID"])
                                                            , DataTypeUtility.GetValue(dataTable.Rows[0]["EST_ID"])).Tables[0];

                    for(int i = 0; i < dtPos.Rows.Count; i++) 
                    {
                        affectedRow += _deptPosScale.Update(  conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dtPos.Rows[i]["COMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dtPos.Rows[i]["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dtPos.Rows[i]["DEPT_REF_ID"])
                                                            , DataTypeUtility.GetValue(dtPos.Rows[i]["EST_ID"])
                                                            , DataTypeUtility.GetValue(dtPos.Rows[i]["SEQ"])
                                                            , i + 1
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , DBNull.Value);
                    }
                }

                trx.Commit();
            }
            catch( Exception ex )
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool RemoveDeptPosScale(  int comp_id
                                        , int estterm_ref_id
                                        , int dept_ref_id
                                        , string est_id
										, int seq)
        {
            int affectedRow = 0;

            affectedRow = _deptPosScale.Delete(   null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , dept_ref_id
                                                , est_id 
												, seq);

            return (affectedRow > 0) ? true : false;
        }

		public bool IsExist(  int comp_id
                            , int estterm_ref_id
							, int dept_ref_id
							, string est_id )
		{
			return IsExist(   comp_id
                            , estterm_ref_id
                            , dept_ref_id
                            , est_id
                            , 0
                            , string.Empty
                            , string.Empty);
		}

		public bool IsExist(  int comp_id
                            , int estterm_ref_id
							, int dept_ref_id
							, string est_id
							, int seq 
                    )
		{
			return IsExist(   comp_id
                            , estterm_ref_id
                            , dept_ref_id
                            , est_id
                            , seq
                            , string.Empty
                            , string.Empty);
		}

        public bool IsExist(  int comp_id
                            , int estterm_ref_id
                            , int dept_ref_id
                            , string est_id
							, int seq
							, string pos_id
							, string pos_value)
        {
            int affectedRow = 0;

            affectedRow = _deptPosScale.Count(   comp_id
                                                , estterm_ref_id
                                                , dept_ref_id
                                                , est_id
												, seq
												, pos_id
                                                , pos_value);

            if ( affectedRow > 0 )
                return true;

            return false;
        }

		public int NewIdx(int comp_id
                        , int estterm_ref_id
                        , int dept_ref_id
                        , string est_id )
		{
			return _deptPosScale.NewIdx(  comp_id
                                        , estterm_ref_id
										, dept_ref_id
										, est_id);
		}

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("DEPT_REF_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("SEQ", typeof(int));
            dataTable.Columns.Add("POS_ID", typeof(string));
            dataTable.Columns.Add("POS_VALUE", typeof(string));
            dataTable.Columns.Add("SCALE_ID", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }
    }
}