using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class WebUtility
{
    public static string GetRequest(string asKey)
    {
        string reVal = "";
        if (HttpContext.Current.Request[asKey] != null)
        {
            string temp = HttpContext.Current.Request[asKey];

            if (temp.ToUpper().IndexOf("SELECT") > 0
                || temp.ToUpper().IndexOf("FROM") > 0
                || temp.ToUpper().IndexOf("HTML") > 0
                || temp.ToUpper().IndexOf("HTM") > 0
                || temp.ToUpper().IndexOf("SCRIPT") > 0
                || temp.ToUpper().IndexOf("TRIM") > 0
                || temp.ToUpper().IndexOf("AND") > 0
                || temp.ToUpper().IndexOf("|") > 0
                || temp.ToUpper().IndexOf("&") > 0
                || temp.ToUpper().IndexOf(";") > 0
                //|| temp.ToUpper().IndexOf("$") > 0
                || temp.ToUpper().IndexOf("%") > 0
                || temp.ToUpper().IndexOf("@") > 0
                || temp.ToUpper().IndexOf("'") > 0
                || temp.ToUpper().IndexOf("\"") > 0
                || temp.ToUpper().IndexOf("\\") > 0
                || temp.ToUpper().IndexOf("\\\"") > 0
                || temp.ToUpper().IndexOf("<") > 0
                || temp.ToUpper().IndexOf("<") > 0
                || temp.ToUpper().IndexOf("(") > 0
                || temp.ToUpper().IndexOf(")") > 0
                || temp.ToUpper().IndexOf("+") > 0
                || temp.ToUpper().IndexOf("\\r") > 0
                || temp.ToUpper().IndexOf("\\n") > 0
                //|| temp.ToUpper().IndexOf(",") > 0
                || temp.ToUpper().IndexOf(".INI") > 0)
            {
                reVal = "-0";
            }
            else
            {
                reVal = temp;
            }
        }

        return reVal;

        //return (HttpContext.Current.Request[asKey] == null ? "" : HttpContext.Current.Request[asKey]);
    }

    public static int GetRequestByInt(string asKey, int nullValue)
    {
        if (HttpContext.Current.Request[asKey] == null || HttpContext.Current.Request[asKey].Trim() == "")
            return nullValue;

        return Convert.ToInt32(HttpContext.Current.Request[asKey]);
    }

    public static int GetRequestByInt(string asKey)
    {
        return GetRequestByInt(asKey, 0);
    }

    public static string GetRequest(string asKey, string nullValue)
    {
        string reVal = nullValue;
        if (HttpContext.Current.Request[asKey] != null)
        {
            string temp = HttpContext.Current.Request[asKey];

            if (temp.ToUpper().IndexOf("SELECT") > 0
                || temp.ToUpper().IndexOf("FROM") > 0
                || temp.ToUpper().IndexOf("HTML") > 0
                || temp.ToUpper().IndexOf("HTM") > 0
                || temp.ToUpper().IndexOf("SCRIPT") > 0
                || temp.ToUpper().IndexOf("TRIM") > 0
                || temp.ToUpper().IndexOf("AND") > 0
                || temp.ToUpper().IndexOf("|") > 0
                || temp.ToUpper().IndexOf("&") > 0
                || temp.ToUpper().IndexOf(";") > 0
                || temp.ToUpper().IndexOf("$") > 0
                || temp.ToUpper().IndexOf("%") > 0
                //|| temp.ToUpper().IndexOf("@") > 0
                || temp.ToUpper().IndexOf("'") > 0
                || temp.ToUpper().IndexOf("\"") > 0
                || temp.ToUpper().IndexOf("\\") > 0
                || temp.ToUpper().IndexOf("\\\"") > 0
                || temp.ToUpper().IndexOf("<") > 0
                || temp.ToUpper().IndexOf("<") > 0
                || temp.ToUpper().IndexOf("(") > 0
                || temp.ToUpper().IndexOf(")") > 0
                || temp.ToUpper().IndexOf("+") > 0
                || temp.ToUpper().IndexOf("\\r") > 0
                || temp.ToUpper().IndexOf("\\n") > 0
                || temp.ToUpper().IndexOf(",") > 0
                || temp.ToUpper().IndexOf(".INI") > 0)
            {
                reVal = "-0";
            }
            else
            {
                reVal = temp;
            }
        }

        return reVal;

        //return (HttpContext.Current.Request[asKey] == null ? nullValue : HttpContext.Current.Request[asKey]);
    }

    public static string GetConfig(string asKey)
    {
        return GetConfig(asKey, "");
    }

    public static string GetConfig(string asKey, string return_default_string)
    {
        string lsRet = return_default_string;

        try
        {
            lsRet = ConfigurationManager.AppSettings[asKey].ToString();
        }
        catch (Exception)
        {
            lsRet = return_default_string;
        }

        return lsRet;
    }

    public static void FindByValueDropDownList(DropDownList ddlReceive, object sValue)
    {
        if (sValue == null)
            return;

        ddlReceive.ClearSelection();

        ListItem item = ddlReceive.Items.FindByValue(sValue.ToString());
        if (item != null)
            item.Selected = true;
    }

    public static string GetByValueDropDownList(DropDownList ddlSearch)
    {
        return GetByValueDropDownList(ddlSearch, "");
    }

    public static string GetByValueDropDownList(DropDownList ddlSearch, string returnValue)
    {
        return GetByValueDropDownList(ddlSearch, returnValue, true);
    }

    public static string GetByValueDropDownList(DropDownList ddlSearch, string returnValue, bool checkEnabled)
    {
        if (   ddlSearch.SelectedItem == null
            || ddlSearch.Items.Count == 0)
            return returnValue;
        if (checkEnabled && !ddlSearch.Enabled)
            return returnValue;

        return ddlSearch.SelectedItem.Value.ToString().Trim();
    }

    public static int GetIntByValueDropDownList(DropDownList ddlSearch)
    {
        if (   ddlSearch.SelectedItem   == null
            || ddlSearch.Items.Count    == 0
            || ddlSearch.Enabled        == false
            || ddlSearch.SelectedValue  == "") 
        {
            return 0;
        }

        return int.Parse(ddlSearch.SelectedValue);
    }

    public static string GetByTextDropDownList(DropDownList ddlSearch)
    {
        if (    ddlSearch.SelectedItem  == null
            ||  ddlSearch.Items.Count   == 0)
            return "";
        if (!ddlSearch.Enabled)
            return "";

        return ddlSearch.SelectedItem.Text.ToString().Trim();
    }

    public static void FindByValueDropDownList(DropDownList ddlReceive, DataRow drReceive)
    {
        ddlReceive.SelectedIndex = ddlReceive.Items.IndexOf(ddlReceive.Items.FindByValue(drReceive[0].ToString()));

        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    public static void FindByTextDropDownList(DropDownList ddlReceive, string sText)
    {
        ddlReceive.SelectedIndex = ddlReceive.Items.IndexOf(ddlReceive.Items.FindByText(sText));

        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    public static void FindByTextDropDownList(DropDownList ddlReceive, DataRow drReceive)
    {
        ddlReceive.SelectedIndex = ddlReceive.Items.IndexOf(ddlReceive.Items.FindByText(drReceive[0].ToString()));

        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    public static void FindByValueRadioButtonList(RadioButtonList rbtnlReceive, object sValue)
    {
        if(sValue != null)
            rbtnlReceive.SelectedIndex = rbtnlReceive.Items.IndexOf(rbtnlReceive.Items.FindByValue(sValue.ToString()));

        if (rbtnlReceive != null)
        {
            rbtnlReceive.Dispose();
            rbtnlReceive = null;
        }
    }

    public static string GetByValueRadioButtonList(RadioButtonList rbtnlSearch)
    {
        if (rbtnlSearch.SelectedIndex < 0)
            return "";

        return rbtnlSearch.SelectedItem.Value.ToString().Trim();
    }

    public static int GetIntByValueRadioButtonList(RadioButtonList rbtnlSearch)
    {
        if (rbtnlSearch.SelectedIndex < 0)
            return 0;

        if (rbtnlSearch.SelectedItem == null)
            return 0;

        return int.Parse(rbtnlSearch.SelectedItem.Value.ToString());
    }

    public static void FindByTextRadioButtonList(RadioButtonList rbtnlReceive, string sText)
    {
        rbtnlReceive.SelectedIndex = rbtnlReceive.Items.IndexOf(rbtnlReceive.Items.FindByText(sText));

        if (rbtnlReceive != null)
        {
            rbtnlReceive.Dispose();
            rbtnlReceive = null;
        }
    }

    public static void ExecuteScript(string sScript, Page page)
    {
        Type csType = page.GetType();

        sScript = "<script type='text/javascript' language='javascript' src='/ClientCommon/Script/common.js'></script><script type=text/javascript>" + sScript + "</script>";
        //현재시각과 랜덤값 더한 것을 sriptID 의 key 로 설정합니다.
        string sScriptID = DateTime.Now.ToString("yyyyMMddhhmmssfff");

        if (page.ClientScript.IsClientScriptBlockRegistered(csType, sScriptID))
            page.ClientScript.RegisterStartupScript(csType, sScriptID, sScript);
    }

    public static void FileDownload(string txt) 
    {
        HttpContext httpCurrentContext  = System.Web.HttpContext.Current;
        string path                     = httpCurrentContext.Server.MapPath(string.Format("f_{0}", DateTime.Now.ToString("yyyyMMddhhmmssfff")));

        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(txt);
        writer.Close();
        writer.Dispose();

        httpCurrentContext.Response.AddHeader( "Content-Disposition" , "attachment;filename=" + string.Format("error_msg_{0}.txt", DateTime.Now.ToString("yyyyMMddhhmmss")) );
        httpCurrentContext.Response.ContentType = "multipart/form-data";
        httpCurrentContext.Response.ContentType = "application/unknown";
		httpCurrentContext.Response.WriteFile( path );
		httpCurrentContext.Response.Flush();
		httpCurrentContext.Response.End();

        if(File.Exists(path))
            File.Delete(path);
    }

    public static string GetHtmlEncodeChar(string asStr)
    {
        asStr = asStr.Replace(";", "&#59;");
        asStr = asStr.Replace("&", "&#38;");
        asStr = asStr.Replace("\\", "");
        //asStr = asStr.Replace(" ", "&#32;");
        asStr = asStr.Replace("\"", "&#34;");
        asStr = asStr.Replace("(", "&#40;");
        asStr = asStr.Replace(")", "&#41;");
        asStr = asStr.Replace("'", "");

        return asStr;
    }

    public static string GetValueForSplit(DataTable dataTable
                                        , string dataColumnName
                                        , string splitChar)
    {
        string temp     = "";
        bool isFirst    = true;

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            if(isFirst) 
            {
                temp    += dataRow[dataColumnName].ToString();
                isFirst = false;
            }
            else 
            {
                temp    += string.Format("{0}{1}", splitChar, dataRow[dataColumnName]);
            }
        }

        return temp;
    }

    public static void PopupPage(   Literal ltrScript
                                  , string url
                                  , int width
                                  , int height
                                  , string window_name) 
    {
        string script   = string.Format("gfOpenWindow('{0}', {1}, {2}, false, false, 'pop_up');", url, width, height);
        ltrScript.Text  = JSHelper.GetBlankScript(script);
    }
}
