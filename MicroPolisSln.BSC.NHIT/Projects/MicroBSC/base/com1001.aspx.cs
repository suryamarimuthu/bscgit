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
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.BSC.Biz;

public partial class base_com1001 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            hdnTerm.Value = Request.QueryString["eid"];
            hdnMM.Value = Request.QueryString["tmcode"];
            initForm();
            GridDataBinding();
        }

        this.UltraWebGrid1.Columns.FromKey("EMP_NAME").Header.Caption = GetText("LBL_00001", "챔피언");
    }

    private void initForm()
    {
        lblMM.Text = hdnMM.Value;
        ddlApplyYN.Items.Add(new ListItem("전체","0,1"));
        ddlApplyYN.Items.Add(new ListItem("실적입력", "1"));
        ddlApplyYN.Items.Add(new ListItem("실적미입력", "0"));
        ddlApplyYN.SelectedIndex = 2;
    }

    private void GridDataBinding() 
    {
        string query = @"
                SELECT ISNULL(CE.EMP_REF_ID,0) as EMP_REF_ID,
				       RTRIM(ISNULL(DE.DEPT_NAME,'')) as DEPT_NAME,
	                   ISNULL(CE.EMP_NAME,'') as EMP_NAME,
					   MAX(ISNULL(CE.EMP_EMAIL,'')) as EMP_EMAIL
                  FROM KPI_INFO KI, 
                       COM_EMP_INFO CE, 
	                   COM_DEPT_INFO DE, 
	                   REL_DEPT_EMP RD,
					   KPI_RESULT KR,
	                  (SELECT " + hdnMM.Value + @" as TMCODE,  MON_" + hdnMM.Value + @"_FLAG as  CHECK_YN, KPI_REF_ID FROM KPI_TERM WHERE KPI_TERM_TYPE = 0) TM
                 WHERE KI.KPI_REF_ID *= KR.KPI_REF_ID
				   AND KI.KPI_REF_ID *= TM.KPI_REF_ID
                   AND KI.CHAMPION_EMP_ID *= CE.EMP_REF_ID
                   AND RD.EMP_REF_ID = CE.EMP_REF_ID
                   AND RD.DEPT_REF_ID = DE.DEPT_REF_ID
				   AND TM.CHECK_YN = 1
				   AND KR.CHECKSTATUS IN (" + ddlApplyYN.SelectedValue + @")
				   AND KR.TMCODE = " + hdnMM.Value + @"
				 GROUP BY DE.DEPT_REF_ID,DE.DEPT_NAME,CE.EMP_REF_ID, CE.EMP_NAME

        ";
        
        MicroBSC.Data.DBAgent gDbAgent = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        DataSet ds = gDbAgent.FillDataSet(query, "data");
        EmpInfos emp                = new EmpInfos();
        UltraWebGrid1.DataSource = ds.Tables[0].DefaultView;
        UltraWebGrid1.DataBind();
    }
    protected void iBtnRoleDel_Click(object sender, ImageClickEventArgs e)
    {
        EmpInfos empLoginUser = new EmpInfos(gUserInfo.Emp_Ref_ID);

        string from     = empLoginUser.Emp_Email;
        string url      = System.Configuration.ConfigurationManager.AppSettings["Mail.Url"].ToString();
        string server   = System.Configuration.ConfigurationManager.AppSettings["Mail.SMTP"].ToString();

        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;

        for (int i = 0; i < UltraWebGrid1.Rows.Count; i++)
        {
            row = UltraWebGrid1.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    SendMail(
                         from
                        , row.Cells.FromKey("EMP_EMAIL").ToString()
                        , GetFileText("../_common/SendMailTemplate/BSC_Subject.txt")
                        , GetFileText("../_common/SendMailTemplate/BSC_Content.txt").Replace("[TODAY]", DateTime.Now.ToString("yyyy년 MM월 dd일 hh:mm")).Replace("[RESULT_DATE]", DateTime.Now.ToString("yyyy-MM-dd")).Replace("[MAIL.URL]", url)
                        , url
                        , server
                        );
                }
                catch (Exception ex)
                {
                    ltrScript.Text = JSHelper.GetAlertScript("발송 중 오류가 발생하였습니다.." + ex.Message, false);
                    return;
                }
            }
        }
        
        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 발송되었습니다.", true);
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Data;
    }
    protected void ddlApplyYN_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridDataBinding();
    }
}
