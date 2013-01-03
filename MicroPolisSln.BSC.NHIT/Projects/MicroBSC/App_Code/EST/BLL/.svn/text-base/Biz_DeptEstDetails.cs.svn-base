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
    public class Biz_DeptEstDetails
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private int _estterm_ref_id;
        private int _dept_ref_id;
        private string _est_id;
        private string _scale_id;
        private int _est_grp_id;
        private float _weight;
        private string _weight_type;
        private DateTime _update_date;
        private int _update_user;

        private Dac_DeptEstDetails _deptEstDetail = new Dac_DeptEstDetails(); 

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

        public int Est_Grp_ID
        {
            get
            {
                return _est_grp_id;
            }
            set
            {
                _est_grp_id = value;
            }
        }

        public float Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public string Weight_Type
        {
            get
            {
                return _weight_type;
            }
            set
            {
                _weight_type = (value == null ? "" : value);
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

        public Biz_DeptEstDetails()
        {

        }
        public Biz_DeptEstDetails(int comp_id
                                , int estterm_ref_id
                                , int dept_ref_id
                                , string est_id)
        {
            DataSet ds = _deptEstDetail.Select(comp_id, estterm_ref_id, dept_ref_id, est_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _estterm_ref_id     = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _dept_ref_id        = (dr["DEPT_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_REF_ID"]);
                _est_id             = (dr["EST_ID"]          == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _scale_id           = (dr["SCALE_ID"]        == DBNull.Value) ? "" : (string)dr["SCALE_ID"];
                _est_grp_id         = (dr["EST_GRP_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_GRP_ID"]);
                _weight             = (dr["WEIGHT"]          == DBNull.Value) ? 0 : (float)dr["WEIGHT"];
                _weight_type        = (dr["WEIGHT_TYPE"]     == DBNull.Value) ? "" : (string)dr["WEIGHT_TYPE"];
                _update_date        = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user        = (dr["UPDATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool SaveDeptEstWidthScale(DataTable dtScale)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach(DataRow drScale in dtScale.Rows) 
                {
                    _comp_id           = DataTypeUtility.GetToInt32(drScale["COMP_ID"]);
                    _estterm_ref_id    = DataTypeUtility.GetToInt32(drScale["ESTTERM_REF_ID"]);
                    _dept_ref_id       = DataTypeUtility.GetToInt32(drScale["DEPT_REF_ID"]);
                    _est_id            = drScale["EST_ID"].ToString();
                    _scale_id          = drScale["SCALE_ID"].ToString();
                    _update_date       = DataTypeUtility.GetToDateTime(drScale["DATE"]);
                    _update_user       = DataTypeUtility.GetToInt32(drScale["USER"]);

                    if (IsExist(_comp_id, _estterm_ref_id, _dept_ref_id, _est_id, ""))
                    {
                        affectedRow += _deptEstDetail.Update( null
                                                            , null
                                                            , _comp_id
                                                            , _estterm_ref_id
                                                            , _dept_ref_id
                                                            , _est_id
                                                            , _scale_id
                                                            , _update_date
                                                            , _update_user);

                        //affectedRow += _deptEstDetail.Update(null
                        //                                    , null
                        //                                    , _comp_id
                        //                                    , _estterm_ref_id
                        //                                    , _dept_ref_id
                        //                                    , _est_id
                        //                                    , _scale_id
                        //                                    , DBNull.Value
                        //                                    , DBNull.Value
                        //                                    , DBNull.Value
                        //                                    , _update_date
                        //                                    , _update_user);
                    }
                    else
                    {
                        affectedRow += _deptEstDetail.Insert( null
                                                            , null
                                                            , _comp_id
                                                            , _estterm_ref_id
                                                            , _dept_ref_id
                                                            , _est_id
                                                            , _scale_id
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , _update_date
                                                            , _update_user);
                    }
                }

                trx.Commit();
            }
            catch (Exception ex)
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


        public bool SaveDeptEstWithWeight( DataTable dtWeight )
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			object weight;

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
						weight = DBNull.Value;
					}
					else
					{
						weight = DataTypeUtility.GetToFloat( drItem["WEIGHT"] );
					}

                    _update_date       = DataTypeUtility.GetToDateTime( drItem["DATE"] );
                    _update_user       = DataTypeUtility.GetToInt32( drItem["USER"] );

                    if (IsExist(_comp_id, _estterm_ref_id, _dept_ref_id, _est_id, ""))
                    {
                        affectedRow += _deptEstDetail.Update( null
                                                            , null
                                                            , _comp_id
                                                            , _estterm_ref_id
                                                            , _dept_ref_id
                                                            , _est_id
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , weight
                                                            , DBNull.Value
                                                            , _update_date
                                                            , _update_user);
                    }
                    else
                    {
                        affectedRow += _deptEstDetail.Insert(  null
                                                            ,  null
                                                            , _comp_id
                                                            , _estterm_ref_id
                                                            , _dept_ref_id
                                                            , _est_id
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , weight
                                                            , DBNull.Value
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


        public bool ModifyDeptEstDetail(  int comp_id
                                        , int estterm_ref_id
                                        , int dept_ref_id
                                        , string est_id
                                        , string scale_id
                                        , int est_grp_id
                                        , float weight
                                        , string weight_type
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _deptEstDetail.Update(  null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , dept_ref_id
                                                , est_id
                                                , scale_id
                                                , est_grp_id
                                                , weight
                                                , weight_type
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool CopyDataFromTo(   int comp_id
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
                affectedRow += _deptEstDetail.Delete( conn
                                                    , trx
                                                    , comp_id
                                                    , estterm_ref_id_to
                                                    , 0
                                                    , "");

                affectedRow += _deptEstDetail.InsertDataFromTo(conn
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

        public DataSet GetDeptEstDetail(  int comp_id
                                        , int estterm_ref_id
                                        , int dept_ref_id
                                        , string est_id)
        {
            return _deptEstDetail.Select( comp_id
                                        , estterm_ref_id
                                        , dept_ref_id
                                        , est_id);
        }

        public bool AddDeptEstDetail( int comp_id
                                    , int estterm_ref_id
                                    , int dept_ref_id
                                    , string est_id
                                    , string scale_id
                                    , int est_grp_id
                                    , float weight
                                    , string weight_type
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _deptEstDetail.Insert(  null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , dept_ref_id
                                                , est_id
                                                , scale_id
                                                , est_grp_id
                                                , weight
                                                , weight_type
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveDeptEstDetail(  int comp_id
                                        , int estterm_ref_id
                                        , int dept_ref_id
                                        , string est_id)
        {
            int affectedRow = 0;

            affectedRow = _deptEstDetail.Delete(  null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
                                                , dept_ref_id
                                                , est_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(  int comp_id
                            , int estterm_ref_id
                            , int dept_ref_id
                            , string est_id
                            , string scale_id)
        {
            int affectedRow = 0;

            affectedRow = _deptEstDetail.Count(comp_id
                                            , estterm_ref_id
                                            , dept_ref_id
                                            , est_id
                                            , scale_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("DEPT_REF_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("SCALE_ID", typeof(string));
            dataTable.Columns.Add("EST_GRP_ID", typeof(string));
            dataTable.Columns.Add("WEIGHT", typeof(object));
            dataTable.Columns.Add("WEIGHT_TYPE", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }
    }
}