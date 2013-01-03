using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Biz_Bsc_View_Info의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_View_Info : MicroBSC.BSC.Dac.Dac_Bsc_View_Info
    {
        public Biz_Bsc_View_Info() { }
        public Biz_Bsc_View_Info(int iview_ref_id) : base(iview_ref_id) { }

        /// <summary>
        /// 관점정보입력
        /// </summary>
        /// <param name="iview_seq">관점순서</param>
        /// <param name="iview_name">관점명</param>
        /// <param name="iview_desc">관점설명</param>
        /// <param name="iview_etc">관점기타사항</param>
        /// <param name="iview_image_name">관점이미지명</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public int InsertData(int iview_seq, string iview_name, string iview_desc, string iview_etc,
                              string iview_image_name, int itxr_user)
        {
            return base.InsertData_Dac(iview_seq, 
                                       iview_name, 
                                       iview_desc, 
                                       iview_etc, 
                                       iview_image_name, 
                                       itxr_user);
        }

        /// <summary>
        /// 관점정보수정
        /// </summary>
        /// <param name="iview_ref_id">관점아이디</param>
        /// <param name="iview_seq">관점순서</param>
        /// <param name="iview_name">관점명</param>
        /// <param name="iview_desc">관점설명</param>
        /// <param name="iview_etc">관점기타사항</param>
        /// <param name="iview_image_name">관점이미지명</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public int UpdateData(int iview_ref_id, int iview_seq, string iview_name, string iview_desc, string iview_etc,
                              string iview_image_name, int itxr_user)
        {
            return base.UpdateData_Dac(iview_ref_id, 
                                       iview_seq, 
                                       iview_name, 
                                       iview_desc, 
                                       iview_etc,
                                       iview_image_name, 
                                       itxr_user);
        }

        /// <summary>
        /// 관점삭제
        /// 삭제시 Disable 처리
        /// </summary>
        /// <param name="iview_ref_id">관점아이디</param>
        /// <param name="iuse_yn">사용여부</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public int DeleteData(Int32 iview_ref_id, String iuse_yn, Int32 itxr_user)
        {
            return base.DeleteData_Dac(iview_ref_id, 
                                       iuse_yn, 
                                       itxr_user);
        }

        public int ReUsedData(Int32 iview_ref_id, String iuse_yn, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(iview_ref_id,
                                       iuse_yn,
                                       itxr_user);
        }
    }

   
}
