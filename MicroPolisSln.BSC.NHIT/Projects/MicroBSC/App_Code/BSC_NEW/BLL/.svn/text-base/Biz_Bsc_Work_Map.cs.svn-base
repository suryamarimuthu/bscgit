using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using System.Web.UI.WebControls;

using MicroBSC.BSC.Dac;
using MicroBSC.Data;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Work_Map
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Work_Map
    /// Class Func     : BSC_Work_Map Business Logic Class
    /// CREATE DATE    : 2011-11-01 
    /// CREATE USER    : H.D.Park
    /// 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Work_Map : Dac_Bsc_Work_Map
    {
        public Biz_Bsc_Work_Map() { }

        public bool InsertWorkMap(int estterm_ref_id, int est_dept_ref_id, int stg_ref_id, DataTable dtAdd, int emp_ref_id)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.InsertWorkMap(conn, trx, estterm_ref_id, est_dept_ref_id, stg_ref_id, dtAdd, emp_ref_id);

                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch (Exception ex)
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool DeleteWorkMap(int estterm_ref_id, int est_dept_ref_id, int stg_ref_id, DataTable dtDel)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.DeleteWorkMap(conn, trx, estterm_ref_id, est_dept_ref_id, stg_ref_id, dtDel);

                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch(Exception ex)
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public DataSet GetWorkMapTotalList(int estterm_ref_id
                                        , int est_dept_ref_id)
        {
            return base.GetWorkMapTotalList(estterm_ref_id
                                            , est_dept_ref_id);
        }

        public DataSet GetWorkMapTotalListHeader_DB(int estterm_ref_id
                                                  , int est_dept_ref_id)
        {
            return base.GetWorkMapTotalListHeader_DB(estterm_ref_id
                                            , est_dept_ref_id);
        }

        public DataSet GetWorkMapTotalList_DB()
        {
            return base.GetWorkMapTotalList_DB();
        }


        public DataSet GetWorkMapMaster(int estterm_ref_id
                                        , int est_dept_ref_id)
        {
            return base.GetWorkMapMaster(estterm_ref_id
                                        , est_dept_ref_id);
        }

        public DataSet GetWorkMapTree(int estterm_ref_id, int est_dept_ref_id, int map_version_id)
        {
            return base.GetWorkMapTree(estterm_ref_id, est_dept_ref_id, map_version_id);
        }

        public DataSet GetWorkMapWorkExec(int estterm_ref_id, int est_dept_ref_id, string select_type, int select_value, int map_version_id)
        {
            return base.GetWorkMapWorkExec(estterm_ref_id, est_dept_ref_id, select_type, select_value, map_version_id);
        }

        public DataSet GetWorkMapWorkExecList(int estterm_ref_id, int est_dept_ref_id, string work_type, string est_dept_name, string est_emp_id, string est_emp_name, string work_code, string work_name, string complete_yn)
        {
            return base.GetWorkMapWorkExecList(estterm_ref_id, est_dept_ref_id, work_type, est_dept_name, est_emp_id, est_emp_name, work_code, work_name, complete_yn);
        }

        public DataSet GetWorkMapList(int estterm_ref_id
                                    , string work_code
                                    , string work_name
                                    , string emp_name
                                    , int est_dept_ref_id
                                    , string work_type
                                    , string complete_yn
                                    , int work_emp_id)
        {
            return base.GetWorkMapList(estterm_ref_id
                                    , work_code
                                    , work_name
                                    , emp_name
                                    , est_dept_ref_id
                                    , work_type
                                    , complete_yn
                                    , work_emp_id);
        }
        
    }
}