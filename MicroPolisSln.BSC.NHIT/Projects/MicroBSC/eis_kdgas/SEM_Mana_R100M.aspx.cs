using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eis_kdgas_SEM_Mana_R100M : AppPageBase
{
    private const string sFPath = "eis_kdgas\\";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_01_Click(object sender, ImageClickEventArgs e)
    {
        string addFileName = AppDomain.CurrentDomain.BaseDirectory + sFPath + lbl_01.Text;
        if (file_01.HasFile)
        {
            if (System.IO.File.Exists(addFileName))
            {
                System.IO.File.SetAttributes(addFileName, System.IO.FileAttributes.Normal);
                System.IO.File.Delete(addFileName);
            }
            file_01.SaveAs(addFileName);
        }
        else
        {
            ltlMsg.Text = JSHelper.GetAlertScript("파일이 존재하지 않습니다.", false);
        }
    }
    protected void btn_02_Click(object sender, ImageClickEventArgs e)
    {
        string addFileName = AppDomain.CurrentDomain.BaseDirectory + sFPath + lbl_02.Text;
        if (file_02.HasFile)
        {
            if (System.IO.File.Exists(addFileName))
            {
                System.IO.File.SetAttributes(addFileName, System.IO.FileAttributes.Normal);
                System.IO.File.Delete(addFileName);
            }
            file_02.SaveAs(addFileName);
        }
        else
        {
            ltlMsg.Text = JSHelper.GetAlertScript("파일이 존재하지 않습니다.", false);
        }
    }
    protected void btn_03_Click(object sender, ImageClickEventArgs e)
    {
        string addFileName = AppDomain.CurrentDomain.BaseDirectory + sFPath + lbl_03.Text;
        if (file_03.HasFile)
        {
            if (System.IO.File.Exists(addFileName))
            {
                System.IO.File.SetAttributes(addFileName, System.IO.FileAttributes.Normal);
                System.IO.File.Delete(addFileName);
                ltlMsg.Text = "";
            }
            file_03.SaveAs(addFileName);
        }
        else
        {
            ltlMsg.Text = JSHelper.GetAlertScript("파일이 존재하지 않습니다.", false);
        }
    }
    protected void btn_04_Click(object sender, ImageClickEventArgs e)
    {
        string addFileName = AppDomain.CurrentDomain.BaseDirectory + sFPath + lbl_04.Text;
        if (file_04.HasFile)
        {
            if (System.IO.File.Exists(addFileName))
            {
                System.IO.File.SetAttributes(addFileName, System.IO.FileAttributes.Normal);
                System.IO.File.Delete(addFileName);
                ltlMsg.Text = "";
            }
            file_04.SaveAs(addFileName);
        }
        else
        {
            ltlMsg.Text = JSHelper.GetAlertScript("파일이 존재하지 않습니다.", false);
        }
    }
    protected void btn_05_Click(object sender, ImageClickEventArgs e)
    {
        string addFileName = AppDomain.CurrentDomain.BaseDirectory + sFPath + lbl_05.Text;
        if (file_05.HasFile)
        {
            if (System.IO.File.Exists(addFileName))
            {
                System.IO.File.SetAttributes(addFileName, System.IO.FileAttributes.Normal);
                System.IO.File.Delete(addFileName);
                ltlMsg.Text = "";
            }
            file_05.SaveAs(addFileName);
        }
        else
        {
            ltlMsg.Text = JSHelper.GetAlertScript("파일이 존재하지 않습니다.", false);
        }
    }
    protected void btn_06_Click(object sender, ImageClickEventArgs e)
    {
        string addFileName = AppDomain.CurrentDomain.BaseDirectory + sFPath + lbl_06.Text;
        if (file_06.HasFile)
        {
            if (System.IO.File.Exists(addFileName))
            {
                System.IO.File.SetAttributes(addFileName, System.IO.FileAttributes.Normal);
                System.IO.File.Delete(addFileName);
                ltlMsg.Text = "";
            }
            file_06.SaveAs(addFileName);
        }
        else
        {
            ltlMsg.Text = JSHelper.GetAlertScript("파일이 존재하지 않습니다.", false);
        }
    }
}
