using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;

using MicroBSC.Data;

/// <summary>
/// Biz_Bsc_Threshold_STEP의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Threshold_STEP Biz 클래스
/// Class 내용		: Biz_Bsc_Threshold_STEP Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 박혜준
/// 최초작성일		: 2007.06.13
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
/// 
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Threshold_Step : MicroBSC.BSC.Dac.Dac_Bsc_Threshold_Step
    {
        public Biz_Bsc_Threshold_Step() { }

        
        // ThresholdCode 를 ThresholdStep에서 사용하는지 여부 체크 리턴 : true - 사용중, false - 비사용중
        public bool UseThresholdCodeInStep(int threshold_code)
        {
            return UseThresholdCodeInStep_Dac(threshold_code);
        }

        
        // THRESHOLD_STEP MAX[SEQUENCE]
        public int RtnMaxSeqInStep(string threshold_level)
        {
            return RtnMaxSeqInStep_Dac(threshold_level);
        }

        public DataSet GetThresholdLevelSearch()
        {
            DataSet ds = GetThresholdLevelSearch_Dac();

            return ds;
        }

        public DataSet GetThresholdLevelList(string threshold_level)
        {
            DataSet ds = GetThresholdLevelList_Dac(threshold_level);

            return ds;
        }

        public int InsertThresholdStep(string[,] asaCode, string threshold_level, decimal point, string base_line_yn, int emp_ref_id)
        {
            int iRet = 0;


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for (int i = 0; i <= asaCode.GetUpperBound(0); i++)
                {
                    iRet += InsertThresholdStep_Dac(asaCode[i, 0],threshold_level, base_line_yn,point,emp_ref_id);
                }
                trx.Commit();
            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }

            return iRet;
        }

        public int DelThresholdStep(string[,] asaCode, string threshold_level)
        {
            int iRet = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for( int i = 0; i <= asaCode.GetUpperBound(0); i++)
                {
                    int oldseq = RtnThresholdSetpOldSeq_Dac(threshold_level, Convert.ToInt32(asaCode[i, 0]));

                    iRet += DelThresholdStep_Dac(Convert.ToInt32(asaCode[i,0]), threshold_level);
                    GetThresholdStepDelSeqUpdate(threshold_level, oldseq);
                }
                trx.Commit();
            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }
            
            return iRet;
        }

        public IDataReader InfoThresholdStep(int threshold_ref_id, string threshold_level)
        {
            IDataReader sdr = InfoThresholdStep_Dac(threshold_ref_id, threshold_level);

            return sdr;
        }

        public int UpdateThresholdStep(int threshold_ref_id, string threshold_level, decimal point, int sequence, string base_line_yn, int emp_ref_id)
        {
            int iRet = 0;
            try
            {
                int oldseq = RtnThresholdSetpOldSeq_Dac(threshold_level, threshold_ref_id);

                string state = (oldseq > sequence) ? "P" : (oldseq < sequence) ? "M" : "";

                if (state != "")
                {
                    GetThersholdStepSeqUpdatd(sequence, oldseq, threshold_level, state);
                }

                iRet = UpdateThresholdStep_Dac(threshold_ref_id, threshold_level, point, sequence, base_line_yn, emp_ref_id);
            }
            catch (Exception)
            {
                iRet = -1;
            }

            return iRet;
        }

        public int InsertThresholdStepNewLevel(int threshold_ref_id, string threshold_level, decimal point, string base_line_yn, int emp_ref_id)
        {
            int iRet = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                if (InsertThresholdStepNewLevel_Dac(threshold_ref_id, threshold_level, point, base_line_yn, emp_ref_id))
                {
                    iRet = 1;
                }
                else
                {
                    iRet = -1;
                    return iRet;
                }
                trx.Commit();
            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }

            return iRet;
        }

        public bool IsDelStepValidate(string[,] asaCode, string threshold_level)
        {
            bool result = false;
            int iRet = 0;

            for (int i = 0; i <= asaCode.GetUpperBound(0); i++)
            {
                iRet = IsDelStepValidate_Dac(Convert.ToInt32(asaCode[i, 0]), threshold_level);
                if (iRet > 0)
                {
                    result = true;
                    return result;
                }
            }      

            return result;
        }

        public DataSet InfoThresholdLebel()
        {
            return infoThresholdLevel_Dac();
        }
    }
}

