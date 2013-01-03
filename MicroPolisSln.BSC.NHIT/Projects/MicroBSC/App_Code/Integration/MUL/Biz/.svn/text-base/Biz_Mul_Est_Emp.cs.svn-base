using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.PRJ.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.MUL.Biz
{
    public class Biz_Mul_Est_Emp
    {
        #region ============================== [Fields] ==============================

        private Dac_Prj_Schedule _data = new Dac_Prj_Schedule();

        #endregion

        public Biz_Mul_Est_Emp()
        {

        }




        public DataTable GetDeptMapping_DB(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id)
        {
            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();
            return dacMulEstEmp.Select_DB(comp_id
                                           , est_id
                                           , estterm_ref_id
                                           , estterm_sub_id);
        }

        public DataTable GetEstEmp_DB(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int emp_ref_id
                                    , string est_type)
        {
            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();
            return dacMulEstEmp.SelectEstEmp_DB(comp_id
                                           , est_id
                                           , estterm_ref_id
                                           , estterm_sub_id
                                           , emp_ref_id
                                           , est_type);
        }

        public string RemoveEstEmp(DataTable dtEmp
                              , int comp_id
                              , string est_id
                              , int estterm_ref_id
                              , int estterm_sub_id
                              , string est_type)
        {
            string returnVal = string.Empty;
            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();

            int intTxrCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dtEmp.Rows.Count; i++)
                {
                    DataRow row = dtEmp.Rows[i];

                    intTxrCnt += dacMulEstEmp.Delete_DB(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , row["EMP_REF_ID"]
                                                    , est_type);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                returnVal = ex.Message;
                trx.Rollback();
                return returnVal;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;

        }


        public string AddEstEmp(DataTable dtDelEmp
                              , DataTable dtEmp
                              , int comp_id
                              , string est_id
                              , int estterm_ref_id
                              , int estterm_sub_id
                              , string est_type
                              , DateTime create_date
                              , int create_user)
        {
            string returnVal = string.Empty;
            int affectedRow = 0;

            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dtDelEmp.Rows.Count; i++)
                {
                    DataRow row = dtDelEmp.Rows[i];
                    affectedRow = dacMulEstEmp.Delete_DB(conn
                                                        , trx
                                                        , comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , row["EMP_REF_ID"]
                                                        , est_type);
                }

                for (int i = 0; i < dtEmp.Rows.Count; i++)
                {
                    DataRow row = dtEmp.Rows[i];

                    object emp_ref_id = row["EMP_REF_ID"];

                    affectedRow += dacMulEstEmp.Insert_DB(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , emp_ref_id
                                                    , est_type
                                                    , create_date
                                                    , create_user);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                returnVal = ex.Message;
                trx.Rollback();
                return returnVal;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }
        



        public string AddEstEmp(DataTable dtEmp
                              , int comp_id
                              , string est_id
                              , int estterm_ref_id
                              , int estterm_sub_id
                              , string est_type
                              , DateTime create_date
                              , int create_user)
        {
            string returnVal = string.Empty;
            int affectedRow = 0;

            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                
                    affectedRow = dacMulEstEmp.Delete_DB(conn
                                                        , trx
                                                        , comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , 0
                                                        , est_type);

                for (int i = 0; i < dtEmp.Rows.Count; i++)
                {
                    DataRow row = dtEmp.Rows[i];

                    object emp_ref_id = row["EMP_REF_ID"];

                    affectedRow += dacMulEstEmp.Insert_DB(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , emp_ref_id
                                                    , est_type
                                                    , create_date
                                                    , create_user);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                returnVal = ex.Message;
                trx.Rollback();
                return returnVal;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }
    }
}