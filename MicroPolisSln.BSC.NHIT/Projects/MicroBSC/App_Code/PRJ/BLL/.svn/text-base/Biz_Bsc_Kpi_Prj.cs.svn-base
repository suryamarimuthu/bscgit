using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;

namespace MicroBSC.PRJ.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_Prj
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Kpi_Prj
    /// Class Func     : PRJ_BUDGET Business Logic Class
    /// CREATE DATE    : 2008-04-10 오후 2:23:57
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Kpi_Prj : Dac_Bsc_Kpi_Prj
    {
       
        public Biz_Bsc_Kpi_Prj() { }

       

        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, int iprj_ref_id, int itxr_user)
        {
            return base.InsertData_Dac(iestterm_ref_id, ikpi_ref_id, iprj_ref_id, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, int iprj_ref_id)
        {
            return base.DeleteData_Dac(iestterm_ref_id, ikpi_ref_id, iprj_ref_id);
        }

        public bool IsExist(int iestterm_ref_id, int ikpi_ref_id, int iprj_ref_id)
        {
            DataSet ds = base.GetOneList(iestterm_ref_id, ikpi_ref_id, iprj_ref_id);
            return (ds.Tables[0].Rows.Count >= 1) ? true : false;
        }

        public DataTable GetTotalKpiPrjList(int iestterm_ref_id
                                  , int ikpi_ref_id
                                  , int iprj_ref_id
                                  , int iest_dept_ref_id
                                  , string iprj_type
                                  , string iprj_code
                                  , string iprj_name
                                  , int itxr_user)
        {
           

            return base.GetTotalKpiPrjList_Dac(iestterm_ref_id
                                  , ikpi_ref_id
                                  , iprj_ref_id
                                  , iest_dept_ref_id
                                  , iprj_type
                                  , iprj_code
                                  , iprj_name
                                  , itxr_user).Tables[0];
        }


        public DataSet GetKpiCodePrjectList(int iestterm_ref_id
                                 , int ikpi_ref_id)
        {


            return base.GetKpiCodePrjectList(iestterm_ref_id
                                  , ikpi_ref_id);
        }

    }
}