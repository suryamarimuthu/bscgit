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
/// Biz_Bsc_Threshold_Code의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Threshold_Code Biz 클래스
/// Class 내용		: Bsc_Threshold_Code Biz Logic 처리 
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
    public class Biz_Bsc_Threshold_Code : MicroBSC.BSC.Dac.Dac_Bsc_Threshold_Code
    {
        public Biz_Bsc_Threshold_Code() { }

        public int RtnThresholdCodeMaxSeq()
        {
            return RtnThresholdCodeMaxSeq_Dac();
        }

        public DataSet GetThresholdCodeList(string threshold_level)
        {
            DataSet ds = GetThresholdCodeList_Dac(threshold_level);

            return ds;
        }

        // 같은영문명이나 한글명을 가지고 있는 코드가 등록되어 있는 지 여부 리턴
        public bool UseThresholdName(string threshold_ename, string threshold_kname)
        {
            return UseThresholdName_Dac(threshold_ename, threshold_kname);
        }

        // iRet : 3 - 중복된 이름
        public int InsertThresholdCode(string threshold_ename, string threshold_kname, string image_file_name, int sequence, string use_yn, int emp_ref_id)
        {
            int iRet = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();
            if (!UseThresholdName(threshold_ename, threshold_kname)) // Threshold 이름 중복여부 확인
            {
                try
                {
                    GetThresholdCodeAddSeqUpdate(sequence);
                    iRet = InsertThresholdCode_Dac(threshold_ename, threshold_kname, image_file_name, sequence, use_yn, emp_ref_id);
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
            }
            else
            {
                iRet = 3;
            }
            return iRet;
        }

        public IDataReader InfoThresholdCode(int threshold_ref_id)
        {            
            IDataReader sdr = InfoThresholdCode_Doc(threshold_ref_id);

            return sdr;
        }

        public int UpdateThresholdCode(int threshold_ref_id, string threshold_ename, string thrreshold_kname, string image_file_name, int sequence, string use_yn, int emp_ref_id)
        {
            int iRet = 0;


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                // 기존 정렬 순서
                int oldseq = RtnThresholdCodeOldSeq_Dac(threshold_ref_id);
                string state = (oldseq > sequence) ? "P" : (oldseq < sequence) ? "M" : "";

                if (state != "")
                {
                    GetThersholdcodeSeqUpdatd(sequence, oldseq, state);
                }
                
                iRet = UpdateThresholdCode_Dac(threshold_ref_id,threshold_ename, thrreshold_kname, image_file_name, sequence, use_yn, emp_ref_id);

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

        // rtnValue : -1 - 이미 사용중인 코드
        public int DelThresholdCode(string[,] asaCode)
        {
            int iRet = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for (int i = 0; i <= asaCode.GetUpperBound(0); i++)
                {
                    //사용 여부 체크
                    Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();   
                    if (biz.UseThresholdCodeInStep(Convert.ToInt32(asaCode[i, 0])))
                    {
                        iRet = -1;
                        break;
                    }
                    else
                    {
                        int oldseq = RtnThresholdCodeOldSeq_Dac(Convert.ToInt32(asaCode[i, 0]));
                        if (DelThresholdCode_Dac(Convert.ToInt32(asaCode[i, 0])) > 0)
                        {
                            iRet += 1;
                            GetThresholdCodeDelSeqUpdate(oldseq);
                        }
                    }
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
    }
}