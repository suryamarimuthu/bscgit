using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;

using MicroBSC.Biz.BSC.Biz;

public partial class usr_usr1006 : AppPageBase
{
    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public bool IExtKpiYN
    {
        get
        {
            if (ViewState["EXT_KPI_YN"] == null)
            {
                ViewState["EXT_KPI_YN"] = (GetRequest("EXT_KPI_YN", "N") == "Y") ? true : false;
            }

            return (bool)ViewState["EXT_KPI_YN"];
        }
        set
        {
            ViewState["EXT_KPI_YN"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e) 
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !Page.IsPostBack )
        {
            if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
                rdoGoalTong.Visible = true;

            base.SetMenuControl(true, true, true);

            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

            if (this.IEstTermRefID < 1)
            {
                this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            }
            else
            {
                PageUtility.FindByValueDropDownList(ddlEstTermInfo, this.IEstTermRefID.ToString());
            }

            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            if (this.IYmd == "")
            {
                this.IYmd = PageUtility.GetByValueDropDownList(ddlMonthInfo);
            }
            else
            {
                PageUtility.FindByValueDropDownList(ddlMonthInfo, this.IYmd);
            }

            WebCommon.SetExternalScoreCheckBox(chkApplyExtScore, this.IEstTermRefID);
            chkApplyExtScore.Checked = this.IExtKpiYN;

            BindDeptOrg();
        }
    }

    private void BindDeptOrg() 
    {
        string legend_offsetLeft = "150";
        string legend_offsetTop = "15";
        string legend_colCnt = "2";

        string sExtKpi =  (chkApplyExtScore.Checked && chkApplyExtScore.Visible) ? "Y" : "N";
        string url = "usr_dept_org.aspx?ESTTERM_REF_ID=" + this.IEstTermRefID.ToString() + "&TMCODE=" + this.IYmd + "&EXT_KPI_YN=" + sExtKpi + "&LEGEND_OFFSETLEFT=" + legend_offsetLeft + "&LEGEND_OFFSETTOP=" + legend_offsetTop + "&LEGEND_COLCNT=" + legend_colCnt;

        ifmDeptOrg.Attributes.Add("src", url);
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        // 골타겟 관련 입력 버튼 (농협에서 추가)
        //iBtnGoalTong.Visible = iBtnAddTarget.Visible;

        if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
        {
            BizUtility.GOALTONG_TYPE = rdoGoalTong.SelectedValue;
        }

        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd = PageUtility.GetByValueDropDownList(ddlMonthInfo);

        BindDeptOrg();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    }
}
