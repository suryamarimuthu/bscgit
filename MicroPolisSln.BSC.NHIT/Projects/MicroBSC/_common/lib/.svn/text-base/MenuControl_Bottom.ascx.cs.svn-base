using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Diagnostics;

public partial class _common_lib_MenuControl_Bottom : AppUserControlBase
{
    private string IASSEMBLY_VERSION
    {
        get
        {
            if (ViewState["ASSEMBLY_VERSION"] == null)
            {
                ViewState["ASSEMBLY_VERSION"] = "";
            }

            return (string)ViewState["ASSEMBLY_VERSION"];
        }
        set
        {
            ViewState["ASSEMBLY_VERSION"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SetCopyrightLayout(dvMenuBottom);
        if (!IsPostBack)
        {
            imgBottomCopy.ImageUrl = ConfigurationManager.AppSettings["BottomPageCopy.ImageUrl"].ToString();
            #region FileVersion
            if (this.IASSEMBLY_VERSION == "")
            {
                string sVersionFormat = "[ {0} ]";
                try
                {
                    FileVersionInfo FVI = FileVersionInfo.GetVersionInfo(Server.MapPath("../bin/MicroBSC_deploy.dll"));
                    this.IASSEMBLY_VERSION = String.Format(sVersionFormat, FVI.FileVersion);
                }
                catch
                {
                }
            }
            lblSysVer.Text = this.IASSEMBLY_VERSION;
            #endregion
        }


        string manual_down_btn_yn = WebUtility.GetConfig("MANUAL_DOWN_YN", "N");
        this.hdfManual_url.Value = WebUtility.GetConfig("MANUAL_DOWN_URL", "");

        if (manual_down_btn_yn.Equals("N"))
        {
            this.ibnManual_down.Enabled = false;
            this.ibnManual_down.Visible = false;
        }
    }
}
