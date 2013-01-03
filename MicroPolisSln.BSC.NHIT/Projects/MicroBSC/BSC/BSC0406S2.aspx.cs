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

using MicroBSC.Biz.Common.Biz;
using MicroBSC.Common;


public partial class BSC_BSC0406S2 : AppPageBase
{

    public int IEsttermRefID
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

    /// <summary>
    /// 평가부서ID
    /// </summary>
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    /// <summary>
    /// 평가부서명
    /// </summary>
    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", "");
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    /// <summary>
    /// 링크버튼
    /// </summary>
    public string ICCB3
    {
        get
        {
            if (ViewState["CCB3"] == null)
            {
                ViewState["CCB3"] = GetRequest("CCB3", "");
            }

            return (string)ViewState["CCB3"];
        }
        set
        {
            ViewState["CCB3"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            WebCommon.FillEstTree(TreeView1, this.IEsttermRefID);
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

        string strTreeNm = TreeView1.SelectedNode.Text;
        string strTreeID = TreeView1.SelectedNode.Value;
        
        Biz_DeptTypeInfo biz    = new Biz_DeptTypeInfo();
        DataSet ds              = biz.GetDeptTypeSortList(this.IEsttermRefID
                                                        , int.Parse(strTreeID));
        string strScript = string.Empty;

        if (this.ICCB3 == "")
        {
//            string strScript = @"
//                                  <script type='text/javascript'>
//                                    opener.document.getElementById('{0}').value='" + strTreeID + @"' 
//                                    opener.document.getElementById('{1}').value='" + strTreeNm + @"'
//
//                                    var openerFlag = 'ctl00_Contents_hdfDept_Type_Flag';
//                                    if(opener.document.getElementById(openerFlag))
//                                        opener.document.getElementById(openerFlag).value = '';
//
//                                    self.close();
//                                  </script>
//                               ";
//            ltrScript.Text = String.Format(strScript, this.ICCB1, this.ICCB2);
            strScript = string.Format(@"
                                  <script type='text/javascript'>
                                    window.opener.PopupSetValue('{0}','{1}');
                                    self.close();
                                  </script>
                               ", strTreeID, strTreeNm);
           
        }
        else
        { 
//            string strScript = @"
//                                  <script type='text/javascript'>
//                                    opener.document.getElementById('{0}').value='" + strTreeID + @"' 
//                                    opener.document.getElementById('{1}').value='" + strTreeNm + @"'
//                                    
//                                    var openerFlag = 'ctl00_Contents_hdfDept_Type_Flag';
//                                    if(opener.document.getElementById(openerFlag))
//                                        opener.document.getElementById(openerFlag).value = '';
//
//                                    opener.__doPostBack('{2}','');
//                                    self.close();
//                                  </script>
//                               ";
            strScript = string.Format(@"
                                  <script type='text/javascript'>
                                    window.opener.PopupSetValue('{0}','{1}');
                                    var openerFlag = 'ctl00_Contents_hdfDept_Type_Flag';
                                    if(opener.document.getElementById(openerFlag))
                                        opener.document.getElementById(openerFlag).value = '';

                                    opener.__doPostBack('{2}','');
                                    self.close();
                                  </script>
                               ", strTreeID, strTreeNm, this.ICCB3);
        }
        ltrScript.Text = strScript;
    }
}
