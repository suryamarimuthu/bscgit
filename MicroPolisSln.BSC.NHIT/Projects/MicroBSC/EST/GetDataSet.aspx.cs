using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

public partial class GetDataSet : EstPageBase
{
    private DataSet ds = null;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Request["Type"].Equals("Survey"))
        {
            if (Request["CateKey"].Equals("B"))
                ds = GetSurveySubject(Request["CateID"]);
           
        }

        if (ds != null)
        {
            Response.Write(ds.GetXml());
            Response.Flush();
            Response.End();
        }
    }

    private DataSet GetSurveySubject(string q_obj_Id)
    {
        Biz_QuestionSubjects questionSubject = new Biz_QuestionSubjects();
        return questionSubject.GetQuestionSubject("",q_obj_Id,"");
    }
}

