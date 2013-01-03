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
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Biz.BSC;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;
using MicroBSC.Estimation.Biz;

// 제    목 : 공지사항 페이지
// 내    용 : 공지사항 정보를 팝업으로 보여줌            
public partial class EST_NOTICE : EstPageBase
{
    protected string BOARD_ID;
    private string SUBJECT_TEXT;
    private string CONTENT_TEXT;

    protected void Page_Load(object sender, EventArgs e)
    {
        BOARD_ID = WebUtility.GetRequest("BOARD_ID");

        if (!Page.IsPostBack)
        {
        }

        GetNotice(BOARD_ID);
    }

    private void GetNotice(string board_id)
    {
        Biz_Boards objBoard = new Biz_Boards();

        DataSet ds = objBoard.GetBoard(board_id, "NTC", 0, "Y");

        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            SUBJECT_TEXT = DataTypeUtility.GetValue(dr["SUBJECT_TEXT"]);
            CONTENT_TEXT = DataTypeUtility.GetValue(dr["CONTENT_TEXT"]);

            // Add the page title to the header element.
            Page.Header.Title = SUBJECT_TEXT + " - MicroBSC";

            this.lblTitle.Text = SUBJECT_TEXT;
            this.ltrContent.Text = CONTENT_TEXT;
        }
    }
}
