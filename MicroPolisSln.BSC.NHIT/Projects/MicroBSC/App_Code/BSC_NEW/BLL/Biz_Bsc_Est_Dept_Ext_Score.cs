using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.BSC.Dac;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Commnunication_List�� ���� ��� �����Դϴ�.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class ��		: Biz_Bsc_Est_Dept_Grade Biz Ŭ����
    /// Class ����		: Bsc_Est_Dept_Grade Biz Logic ó�� 
    ///                 : ���ܿ��� ���Ͽ� ó���ϴ� �κ��� �� �������� �Լ��� ȣ���Ѵ�.
    ///                 : ���������� �Լ��� Dac���� �Լ��� ���Ͽ� ���µ� Ʈ����� ó���� �����ϵ��� �����Ѵ�.
    /// �ۼ���			: �溴��
    /// �����ۼ���		: 2007.12.30
    /// ����������		:
    /// ����������		:
    /// Services		:
    /// �ֿ亯��α�	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Est_Dept_Ext_Score : Dac_Bsc_Est_Dept_Ext_Score
    {
        public Biz_Bsc_Est_Dept_Ext_Score() { }
        public Biz_Bsc_Est_Dept_Ext_Score(int iestterm_ref_id, string iymd, int iest_dept_ref_id) : 
               base(iestterm_ref_id, iymd, iest_dept_ref_id) { }


        public int InsertData(int iestterm_ref_id, string iymd, int iest_dept_ref_id
                            , double iweight_inr, double iweight_ext, double ipoints_ext, string iuse_yn, int itxr_user)
        { 
            return base.InsertData_Dac
                       ( iestterm_ref_id
                       , iymd
                       , iest_dept_ref_id
                       , iweight_inr
                       , iweight_ext
                       , ipoints_ext
                       , iuse_yn
                       , itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, string iymd, int iest_dept_ref_id
                            , double iweight_inr, double iweight_ext, double ipoints_ext, string iuse_yn, int itxr_user)
        { 
            return base.UpdateData_Dac
                       ( iestterm_ref_id
                       , iymd
                       , iest_dept_ref_id
                       , iweight_inr
                       , iweight_ext
                       , ipoints_ext
                       , iuse_yn
                       , itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, string iymd, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, iymd, itxr_user);
        }

        public int InsertAll(DataTable idtScore, int itxr_user)
        {
            int intRtn = 0;
            int intRow = idtScore.Rows.Count;
            DataRow dr = null;
            for (int i = 0; i < intRow; i++)
            { 
                dr = idtScore.Rows[i];
                base.Iestterm_ref_id  = Convert.ToInt32(dr["ESTTERM_REF_ID"].ToString());
                base.Iymd             = Convert.ToString(dr["YMD"]);
                base.Iest_dept_ref_id = Convert.ToInt32(dr["EST_DEPT_REF_ID"].ToString());
                base.Iweight_inr      = Convert.ToDouble(dr["WEIGHT_INR"].ToString());
                base.Iweight_ext      = Convert.ToDouble(dr["WEIGHT_EXT"].ToString());
                base.Ipoints_ext      = Convert.ToDouble(dr["POINTS_EXT"].ToString());
                base.Iuse_yn          = "Y";

                intRtn += base.InsertData_Dac
                               ( base.Iestterm_ref_id
                               , base.Iymd
                               , base.Iest_dept_ref_id
                               , base.Iweight_inr
                               , base.Iweight_ext
                               , base.Ipoints_ext
                               , base.Iuse_yn
                               , itxr_user);
            }

            return intRtn;
        }

    }

}