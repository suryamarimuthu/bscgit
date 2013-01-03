using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

/// <summary>
/// Biz_Bsc_Stg_Info의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Stg_Info : MicroBSC.BSC.Dac.Dac_Bsc_Stg_Info
    {
        public Biz_Bsc_Stg_Info() 
        {
        
        }

        public Biz_Bsc_Stg_Info(int iestterm_ref_id, int istg_ref_id) : base(iestterm_ref_id, istg_ref_id) 
        {
        
        }

        /// <summary>
        /// 전략정보등록
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간코드</param>
        /// <param name="iup_stg_id">상위전략</param>
        /// <param name="istg_code">전략코드</param>
        /// <param name="istg_name">전략명</param>
        /// <param name="istg_set_desc">전략설명</param>
        /// <param name="istg_etc">전략기타사항</param>
        /// <param name="iuse_yn">사용여부</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public int InsertData(int iestterm_ref_id
                            , int iup_stg_id
                            , string istg_code
                            , string istg_name
                            , string istg_set_desc
                            , string istg_etc
                            , string iuse_yn
                            , int itxr_user)
        {
            return base.InsertData_Dac(iestterm_ref_id
                                     , iup_stg_id
                                     , istg_code
                                     , istg_name
                                     , istg_set_desc
                                     , istg_etc
                                     , iuse_yn
                                     , itxr_user);
        }

        public int InsertData(
                            int iup_stg_id
                           , string istg_code
                           , string istg_name
                           , string istg_set_desc
                           , string istg_etc
                           , string iuse_yn
                           , int itxr_user, int view_ref_id)
        {
            return base.InsertData_Dac(
                                      iup_stg_id
                                     , istg_code
                                     , istg_name
                                     , istg_set_desc
                                     , istg_etc
                                     , iuse_yn
                                     , itxr_user,view_ref_id);
        }

        /// <summary>
        /// 전략정보 수정
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간</param>
        /// <param name="istg_ref_id">전략아이디</param>
        /// <param name="iup_stg_id">상위전략</param>
        /// <param name="istg_code">전략코드</param>
        /// <param name="istg_name">전략명</param>
        /// <param name="istg_set_desc">전략설명</param>
        /// <param name="istg_etc">전략기타사항</param>
        /// <param name="iuse_yn">사용여부</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public int UpdateData(int iestterm_ref_id
                                , int istg_ref_id
                                , int iup_stg_id
                                , string istg_code
                                , string istg_name
                                , string istg_set_desc
                                , string istg_etc
                                , string iuse_yn
                                , int itxr_user)
        {
            return base.UpdateData_Dac(iestterm_ref_id
                                     , istg_ref_id
                                     , iup_stg_id
                                     , istg_code
                                     , istg_name
                                     , istg_set_desc
                                     , istg_etc
                                     , iuse_yn
                                     , itxr_user);
        }

        public int UpdateData(int istg_ref_id
                                , int iup_stg_id
                                , string istg_code
                                , string istg_name
                                , string istg_set_desc
                                , string istg_etc
                                , string iuse_yn
                                , int itxr_user, int VIEW_REF_ID)
        {
            return base.UpdateData_Dac(
                                      istg_ref_id
                                     , iup_stg_id
                                     , istg_code
                                     , istg_name
                                     , istg_set_desc
                                     , istg_etc
                                     , iuse_yn
                                     , itxr_user, VIEW_REF_ID);
        }

        /// <summary>
        /// 전략정보삭제
        /// 삭제시 disable
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간아이디</param>
        /// <param name="istg_ref_id">전략아이디</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public int DeleteData(int iestterm_ref_id
                            , int istg_ref_id
                            , int itxr_user)
        {
            return base.DeleteData_Dac(iestterm_ref_id
                                     , istg_ref_id
                                     , itxr_user);
        }

        /// <summary>
        /// 전략 내보내기(전기간 참조용)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public bool CopyStg(int org_estterm_ref_id, int new_estterm_ref_id, int itxr_user)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.CopyStg(conn, trx, org_estterm_ref_id, new_estterm_ref_id, itxr_user);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        /// <summary>
        /// 전략정보 재사용
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="istg_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int ReUsedData(int iestterm_ref_id
                           , int istg_ref_id
                           , int itxr_user)
        {
            return base.ReUsedData_Dac(iestterm_ref_id
                                     , istg_ref_id
                                     , itxr_user);
        }
    }
}
