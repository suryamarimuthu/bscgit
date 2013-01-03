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

using MicroBSC.Data;
using MicroBSC.BSC.Dac;

/// <summary>
/// Biz_Bsc_Kpi_Result의 요약 설명입니다.
/// </summary>

/// <summary>
/// Biz_Bsc_Kpi_Result의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Kpi_RollUp Biz 클래스
/// Class 내용		: Bsc_Kpi_RollUp Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 방병현
/// 최초작성일		: 2007.04.26
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Kpi_RollUp :Dac_Bsc_Kpi_RollUp
    {
        /// <summary>
        /// 상위지표 목표롤업
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trx"></param>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public bool RollUpTarget(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            if (con == null)
            {
                con = DbAgentHelper.CreateDbConnection();
                con.Open();
            }

            if (trx == null)
            {
                trx = con.BeginTransaction();
            }

            int intRtn = base.RollUpTarget_Dac(con, trx, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
            if (base.Transaction_Result == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool RollUpTarget(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return this.RollUpTarget(null, null, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        /// <summary>
        /// 상위지표 목표 취소
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trx"></param>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public bool RollUpTargetCancel(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            if (con == null)
            {
                con = DbAgentHelper.CreateDbConnection();
                con.Open();
            }

            if (trx == null)
            {
                trx = con.BeginTransaction();
            }

            int intRtn = base.RollUpTargetCancel_Dac(con, trx, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
            if (base.Transaction_Result == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool RollUpTargetCancel(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return this.RollUpTargetCancel(null, null, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        /// <summary>
        /// 상위지표 실적 롤업
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trx"></param>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public bool RollUpResult(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            if (con == null)
            {
                con = DbAgentHelper.CreateDbConnection();
                con.Open();
            }

            if (trx == null)
            {
                trx = con.BeginTransaction();
            }

            int intRtn = base.RollUpResult_Dac(con, trx, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
            if (base.Transaction_Result == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool RollUpResult(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return this.RollUpResult(null, null, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        /// <summary>
        /// 상위지표 실적 롤업취소
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trx"></param>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public bool RollUpResultCancel(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            if (con == null)
            {
                con = DbAgentHelper.CreateDbConnection();
                con.Open();
            }

            if (trx == null)
            {
                trx = con.BeginTransaction();
            }

            int intRtn = base.RollUpResultCancel_Dac(con, trx, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
            if (base.Transaction_Result == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RollUpResultCancel(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return this.RollUpResultCancel(null, null, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }
    }
}