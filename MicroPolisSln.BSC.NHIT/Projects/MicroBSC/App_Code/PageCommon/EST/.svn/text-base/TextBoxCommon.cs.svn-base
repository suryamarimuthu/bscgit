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
/// Summary description for TextBoxCommon
/// </summary>
public class TextBoxCommon
{
    public static void SetOnlyInteger(TextBox txtBox) 
    {
        txtBox.Attributes.Add("onkeydown", "gfChkInputNum_Std()");
        txtBox.Style.Add("ime-mode", "disabled");
        txtBox.Style.Add("text-align", "right");
    }

    public static void SetOnlyPercent(TextBox txtBox) 
    {
        txtBox.Attributes.Add("onkeydown", "gfChkInputNum(-1, 4)");
        txtBox.Style.Add("ime-mode", "disabled");
        txtBox.Style.Add("text-align", "right");
    }
}
