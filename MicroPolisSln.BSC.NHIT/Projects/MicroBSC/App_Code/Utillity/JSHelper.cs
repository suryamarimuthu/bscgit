using System;
using System.Collections.Generic;
using System.Text;

public class JSHelper
{
    public static string GetBlankScript(string script)
    {
        return string.Format("<script type='text/javascript'>{0}</script>", script);
    }
    /// <summary>
    /// Literal�� ���� Alert �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="msg">�޼���</param>
    /// <param name="selfclose">Self.Close ����</param>
    /// <returns></returns>
    public static string GetAlertScript(string msg, bool selfclose)
    {
        if (selfclose)
            //return string.Format("<script type='text/javascript'> alert('{0}'); self.close(); </script>", msg);
            // �˾����°� �ƴѰ�쵵 ����â���� �ݵ���... (2006.02.10 ���ű�)
            return string.Format("<script type='text/javascript'> alert('{0}'); opener=self; window.close(); </script>", msg);
        else
            return string.Format("<script type='text/javascript'> alert('{0}'); </script>", msg);
    }

    public static string GetAlertScript(string msg)
    {
        return GetAlertScript(msg, false);
    }

    /// <summary>
    /// Literal�� ���� Alert �� ��Ŀ���̵� �ڹٽ�ũ��Ʈ�� �������ִ� �Լ� (2006.02.08 ���ű�)
    /// </summary>
    /// <param name="sMsg"></param>
    /// <param name="sFocusObj"></param>
    /// <returns></returns>
    public static string GetAlertFocus(string sMsg, string sFocusObj)
    {
        string sReturn =
            @"
                <script type='text/javascript'>
                    alert('" + sMsg + @"');
                    try {document.getElementById('" + sFocusObj + @"').select();} catch(e){}
                    try {document.getElementById('" + sFocusObj + @"').focus();} catch(e){}
                </script>
            ";

        return sReturn;
    }

    /// <summary>
    /// Literal�� ���� Alert �� Opener �ٽ÷ε� �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="msg">�޼���</param>
    /// <param name="selfclose">Self.Close ����</param>
    /// <returns></returns>
    public static string GetAlertOpenerReflashScript(string msg, bool selfclose)
    {
        if (selfclose)
        {
            if (msg == null)
            {
                return string.Format("<script type='text/javascript'> window.opener.location.href=window.opener.location.href; self.close(); </script>", msg);
            }
            else
            {
                return string.Format("<script type='text/javascript'> alert('{0}'); window.opener.location.href=window.opener.location.href; self.close(); </script>", msg);
            }
        }
        else
        {
            if (msg == null)
            {
                return string.Format("<script type='text/javascript'> window.opener.location.href=window.opener.location.href; </script>", msg);
            }
            else
            {
                return string.Format("<script type='text/javascript'> alert('{0}'); window.opener.location.href=window.opener.location.href; </script>", msg);
            }
        }
    }

    /// <summary>
    /// Opener �� Control �� �����Ű�� �Լ�
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="controlId"></param>
    /// <param name="selfclose"></param>
    /// <returns></returns>
    public static string GetAlertOpenerControlCallBackScript(string msg, string controlId, bool selfclose)
    {
        return GetAlertOpenerControlCallBackScript(msg, controlId, "", selfclose);
    }

    /// <summary>
    /// Opener �� Control �� �����Ű�� �߰����� ��ũ��Ʈ�� �ʿ��� ��
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="controlId"></param>
    /// <param name="selfclose"></param>
    /// <returns></returns>
    public static string GetAlertOpenerControlCallBackScript(string msg, string controlId, string addFunction, bool selfclose)
    {
        if (selfclose)
            return string.Format("<script type='text/javascript'> alert('{0}'); if (opener) opener.__doPostBack('{1}',''); self.close(); </script>", msg, controlId);
        else
            return string.Format("<script type='text/javascript'> alert('{0}'); if (opener) opener.__doPostBack('{1}',''); </script>", msg, controlId);
    }

    /// <summary>
    /// Literal�� ���� Alert �� Redirect �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="redirectPath"></param>
    /// <returns></returns>
    public static string GetAlertOpenerControlCallBackRedirectScript(string msg, string controlId, string redirectPath)
    {
        return "<script language = javascript> {alert('" + msg + "');opener.__doPostBack('" + controlId + "',''); location.replace('" + redirectPath + "');}</script>";
    }

    /// <summary>
    /// Opener �� Control �� �����Ű�� �Լ�
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="controlId"></param>
    /// <param name="selfclose"></param>
    /// <returns></returns>
    public static string GetOpenerControlCallBackScript(string controlId, bool selfclose)
    {
        if (selfclose)
            return string.Format("<script type='text/javascript'> opener.__doPostBack('{0}',''); self.close(); </script>", controlId);
        else
            return string.Format("<script type='text/javascript'> opener.__doPostBack('{0}',''); </script>", controlId);
    }

    /// <summary>
    /// Literal�� ���� Alert �� Opener �ٽ÷ε� �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="msg">�޼���</param>
    /// <param name="selfclose">Self.Close ����</param>
    /// <returns></returns>
    public static string GetAlertOpenerReflashSelfRedirectScript(string msg, string path)
    {
        return string.Format("<script type='text/javascript'> alert('{0}'); window.opener.location.reload(); location.replace('{1}'); </script>", msg, path);
    }

    /// <summary>
    /// Literal�� Close �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <returns></returns>
    public static string GetCloseScript()
    {
        return "<script language = javascript> window.close();</script>";
    }

    /// <summary>
    /// Literal�� ���� Alert �� Back �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static string GetAlertBackScript(string msg)
    {
        return "<script language = javascript> {alert('" + msg + "');history.back();}</script>";
    }

    /// <summary>
    /// Literal�� ���� Alert �� Redirect �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="redirectPath"></param>
    /// <returns></returns>
    public static string GetAlertRedirectScript(string msg, string redirectPath)
    {
        return "<script language = javascript> {alert('" + msg + "');location.replace('" + redirectPath + "');}</script>";
    }

    /// <summary>
    /// Literal�� ���� Alert �� Redirect �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="redirectPath"></param>
    /// <returns></returns>
    public static string GetAlertRedirectScript(string msg, string redirectPath, bool boolQueryString)
    {
        return "<script language = javascript> {alert('" + msg + "');location.replace('" + redirectPath + "'+location.search);}</script>";
    }

    /// <summary>
    /// Literal�� ���� Alert �� Parent Redirect �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="redirectPath"></param>
    /// <returns></returns>
    public static string GetAlertParentRedirectScript(string msg, string redirectPath)
    {
        return "<script language = javascript> {alert('" + msg + "');parent.location.replace('" + redirectPath + "');}</script>";
    }

    /// <summary>
    /// Literal�� ���� Replace �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="redirectPath"></param>
    /// <returns></returns>
    public static string GetReplaceScript(string redirectPath)
    {
        return "<script language = javascript> location.replace('" + redirectPath + "');</script>";
    }

    /// <summary>
    /// Literal�� ���� Parent Redirect �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="redirectPath"></param>
    /// <returns></returns>
    public static string GetAlertParentRedirectScript(string redirectPath)
    {
        return "<script language = javascript> parent.location.href='" + redirectPath + "';</script>";
    }

    /// <summary>
    /// Literal�� ���� Close �� Parent Redirect �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="redirectPath"></param>
    /// <returns></returns>
    public static string GetCloseParentRedirect(string redirectPath)
    {
        return "<script language = javascript> parent.location.href='" + redirectPath + "';window.close();</script>";
    }

    /// <summary>
    /// Literal�� ���� Title �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="titleName"></param>
    /// <returns></returns>
    public static string GetTitleScript(string titleName)
    {
        return "<script language = javascript>{document.title='" + titleName + "'}</script>";
    }

    /// <summary>
    /// Literal�� ���� Alert �� Parent Reload �ڹٽ�ũ��Ʈ�� �������ִ� �Լ�
    /// </summary>
    /// <param name="frameName"></param>
    /// <returns></returns>
    public static string GetParentReloadScript(string frameName)
    {
        return "<script language = javascript> parent.document.frames['" + frameName + "'].location.reload();</script>";
    }

    public static string GetSclipt(string asScript)
    {
        return "<script language='javascript'>" + asScript + "</script>";
    }
}

