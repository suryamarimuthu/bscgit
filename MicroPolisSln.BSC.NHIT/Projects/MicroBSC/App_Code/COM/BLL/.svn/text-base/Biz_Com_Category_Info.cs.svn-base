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
/// Biz_Com_Category_Info의 요약 설명입니다.
/// </summary>
/// 

namespace MicroBSC.Biz.Common.Biz
{
    public class Biz_Com_Category_Info : MicroBSC.Biz.Common.Dac.Dac_Com_Category_Info
    {
        public Biz_Com_Category_Info() { }
        public Biz_Com_Category_Info(string icategory_code) : base(icategory_code) { }

        public int InsertData(string icategory_code, string icategory_name, string icategory_desc, string isystem_yn, string iuse_yn, int itxr_user)
        {
            return base.InsertData_Dac(icategory_code, icategory_name, icategory_desc, isystem_yn, iuse_yn, itxr_user);
        }

        public int UpdateData(string icategory_code, string icategory_name, string icategory_desc, string isystem_yn, string iuse_yn, int itxr_user)
        { 
            return base.UpdateData_Dac(icategory_code, icategory_name, icategory_desc, isystem_yn, iuse_yn, itxr_user);
        }

        public int DeleteData(int icategory_code, int itxr_user)
        { 
            return base.DeleteData_Dac(icategory_code, itxr_user);
        }
    }
}