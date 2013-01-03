using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.BSC.Dac;
using MicroBSC.Data;
using MicroBSC.BSC.Biz;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_External_Score
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Kpi_External_Score
    /// Class Func     : BSC_KPI_EXTERNAL_SCORE Business Logic Class
    /// CREATE DATE    : 2009-02-04 오후 6:16:30
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Kpi_External_Score  : Dac_Bsc_Kpi_External_Score
    {
        public Biz_Bsc_Kpi_External_Score() { }
        public Biz_Bsc_Kpi_External_Score(int iestterm_ref_id, string iymd, int ikpi_ref_id) : base( iestterm_ref_id,  iymd,  ikpi_ref_id) { }
		
        public int InsertData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, string iymd, int ikpi_ref_id, decimal iweight_inr, decimal iweight_ext, decimal itarget_ext, decimal iresult_ext, decimal ipoints_ext, string igrade_ext, string iopinion_ext, string iaction_inr, string iopinion_file, string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx,  iestterm_ref_id,  iymd,  ikpi_ref_id,  iweight_inr,  iweight_ext, itarget_ext, iresult_ext, ipoints_ext,  igrade_ext,  iopinion_ext,  iaction_inr,  iopinion_file,  iuse_yn, itxr_user);
        }

        public int UpdateData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, string iymd, int ikpi_ref_id, decimal iweight_inr, decimal iweight_ext, decimal itarget_ext, decimal iresult_ext, decimal ipoints_ext, string igrade_ext, string iopinion_ext, string iaction_inr, string iopinion_file, string iuse_yn, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx,  iestterm_ref_id,  iymd,  ikpi_ref_id,  iweight_inr,  iweight_ext, itarget_ext, iresult_ext, ipoints_ext,  igrade_ext,  iopinion_ext,  iaction_inr,  iopinion_file,  iuse_yn, itxr_user);
        }
		
        public int DeleteData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, string iymd, int ikpi_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx,  iestterm_ref_id,  iymd,  ikpi_ref_id, itxr_user);
        }

        public int InsertAllData(DataTable dtScore, int itxr_user)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int iRtn = 0;
            try
            {
                for (int i = 0; i < dtScore.Rows.Count; i++)
                {
                    base.IEstterm_Ref_Id = int.Parse(dtScore.Rows[i]["ESTTERM_REF_ID"].ToString());
                    base.IYmd            = dtScore.Rows[i]["YMD"].ToString();
                    base.IKpi_Ref_Id     = int.Parse(dtScore.Rows[i]["KPI_REF_ID"].ToString());
                    base.IWeight_Inr     = decimal.Parse(dtScore.Rows[i]["WEIGHT_INR"].ToString());
                    base.IWeight_Ext     = decimal.Parse(dtScore.Rows[i]["WEIGHT_EXT"].ToString());
                    base.ITarget_Ext     = decimal.Parse(dtScore.Rows[i]["TARGET_EXT"].ToString());
                    base.IResult_Ext     = decimal.Parse(dtScore.Rows[i]["RESULT_EXT"].ToString());
                    base.IPoints_Ext     = decimal.Parse(dtScore.Rows[i]["POINTS_EXT"].ToString());
                    base.IGrade_Ext      = dtScore.Rows[i]["GRADE_EXT"].ToString();
                    base.IOpinion_Ext    = dtScore.Rows[i]["OPINION_EXT"].ToString();

                    iRtn += base.UpdateData_Dac
                           (conn, trx
                          , this.IEstterm_Ref_Id
                          , this.IYmd
                          , this.IKpi_Ref_Id
                          , this.IWeight_Inr
                          , this.IWeight_Ext
                          , this.ITarget_Ext
                          , this.IResult_Ext
                          , this.IPoints_Ext
                          , this.IGrade_Ext
                          , this.IOpinion_Ext
                          , "", "", "Y"
                          , itxr_user);
                    base.Transaction_Message = "정상적으로 처리되었습니다.";
                }
                
                trx.Commit();
            }
            catch(Exception e)
            {
                base.Transaction_Message = e.Message;
                trx.Rollback();
                return 0;
            }
            finally
            {
                conn.Close();
            }

            return iRtn;
        }
	}
}