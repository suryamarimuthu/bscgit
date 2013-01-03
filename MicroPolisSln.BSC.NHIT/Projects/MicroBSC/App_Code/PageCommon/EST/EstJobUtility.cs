using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Biz;

using Infragistics.WebUI.UltraWebGrid;

public class EstJobUtility
{
    /// <summary>
    /// EST_JOB_ID에 따른 STATUS_YN 값을 가지고 온다.
    /// </summary>
    /// <param name="comp_id"></param>
    /// <param name="est_id"></param>
    /// <param name="estterm_ref_id"></param>
    /// <param name="estterm_sub_id"></param>
    /// <param name="estterm_step_id"></param>
    /// <param name="est_job_id"></param>
    /// <returns></returns>
    public static string GetStatusYN(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string est_job_id) 
    {
        Biz_JobDetails jobDetail = new Biz_JobDetails(comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , est_job_id);

        return jobDetail.Status_YN;
    }

    /// <summary>
    /// EST_JOB_ID에 따른 STATUS_YN 값을 저장한다.
    /// </summary>
    /// <param name="comp_id"></param>
    /// <param name="est_id"></param>
    /// <param name="estterm_ref_id"></param>
    /// <param name="estterm_sub_id"></param>
    /// <param name="estterm_step_id"></param>
    /// <param name="est_job_id"></param>
    /// <param name="status_yn"></param>
    /// <param name="date"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static bool SetStatusYN(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string est_job_id
                                    , string status_yn
                                    , DateTime date
                                    , int user) 
    {
        Biz_JobDetails jobDetail = new Biz_JobDetails();
        return jobDetail.SaveJobDetail(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_job_id
                                    , status_yn
                                    , DateTime.Now
                                    , user);
    }

    public static bool SetConfirmButtonVisible(int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , string est_job_id
                                            , ImageButton ibnConfirm
                                            , ImageButton ibnConfirmCancel) 
    {
        return SetConfirmButtonVisible(   comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_job_id
                                        , ibnConfirm
                                        , ibnConfirmCancel
                                        , ""
                                        , DateTime.MinValue
                                        , 0
                                        , null);
    }

    /// <summary>
    /// 상태값에 따라 버튼 보이기 
    /// </summary>
    /// <param name="comp_id"></param>
    /// <param name="est_id"></param>
    /// <param name="estterm_ref_id"></param>
    /// <param name="estterm_sub_id"></param>
    /// <param name="estterm_step_id"></param>
    /// <param name="est_job_id"></param>
    /// <param name="ibnConfirm"></param>
    /// <param name="ibnConfirmCancel"></param>
    /// <param name="status_yn"></param>
    /// <param name="ltrScript"></param>
    /// <param name="date"></param>
    /// <param name="user"></param>
    public static bool SetConfirmButtonVisible(int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , string est_job_id
                                            , ImageButton ibnConfirm
                                            , ImageButton ibnConfirmCancel
                                            , string status_yn
                                            , DateTime date
                                            , int user
                                            , Literal ltrScript) 
    {
        if(status_yn.Equals("")) 
        {
            status_yn = GetStatusYN(  comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_job_id);
        }
        else 
        {
            Biz_JobInfos jobInfo        = new Biz_JobInfos(est_job_id);
            Biz_JobDetails jobDetail    = new Biz_JobDetails();

            if (jobInfo.Est_Job_Depen_IDs != null)
            {
                // 만약 종속 작업 ID 가 존재하고 현재 작업을 확정하려고 할 때
                if (!jobInfo.Est_Job_Depen_IDs.Equals("")
                    && status_yn.Equals("Y"))
                {
                    string[] est_job_depen_ids = jobInfo.Est_Job_Depen_IDs.Split(';');

                    foreach (string est_job_depen_id in est_job_depen_ids)
                    {
                        string status_depen_yn = GetStatusYN(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , est_job_depen_id);

                        if (status_depen_yn.Equals("N"))
                        {
                            Biz_JobInfos depenJobInfo = new Biz_JobInfos(est_job_depen_id);

                            if (ltrScript != null)
                                ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0} 작업을 우선 확정하신 후에 현재 작업이 확정 가능합니다.", depenJobInfo.Est_Job_Name));

                            return false;
                        }
                    }
                }
            }
            
            bool isOK = SetStatusYN(  comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_job_id
                                    , status_yn
                                    , date
                                    , user);
        }

        if(status_yn.Equals("Y")) 
        {
            if(ibnConfirm != null)
                ibnConfirm.Visible          = false;

            if(ibnConfirmCancel != null)
                ibnConfirmCancel.Visible    = true;
        }
        else if(status_yn.Equals("N")) 
        {
            if(ibnConfirm != null)
                ibnConfirm.Visible          = true;

            if(ibnConfirmCancel != null)
                ibnConfirmCancel.Visible    = false;
        }
        else
        {
            if(ibnConfirm != null)
                ibnConfirm.Visible          = true;

            if(ibnConfirmCancel != null)
                ibnConfirmCancel.Visible    = false;
        }

        return true;
    }


    //public static bool SetConfirmButtonVisible(int comp_id
    //                                        , string est_id
    //                                        , int estterm_ref_id
    //                                        , int estterm_sub_id
    //                                        , int estterm_step_id
    //                                        , string est_job_id
    //                                        , ImageButton ibnConfirm
    //                                        , ImageButton ibnConfirmCancel
    //                                        , string status_yn
    //                                        , DateTime date
    //                                        , int user
    //                                        , Literal ltrScript) 
    //{
    //    if(status_yn.Equals("")) 
    //    {
    //        status_yn = GetStatusYN(  comp_id
    //                                , est_id
    //                                , estterm_ref_id
    //                                , estterm_sub_id
    //                                , estterm_step_id
    //                                , est_job_id);
    //    }
    //    else 
    //    {
    //        Biz_JobInfos jobInfo        = new Biz_JobInfos(est_job_id);
    //        Biz_JobDetails jobDetail    = new Biz_JobDetails();

    //        // 만약 종속 작업 ID 가 존재하고 현재 작업을 확정하려고 할 때
    //        if(    !jobInfo.Est_Job_Depen_IDs.Equals("") 
    //            && status_yn.Equals("Y")) 
    //        {
    //            string[] est_job_depen_ids = jobInfo.Est_Job_Depen_IDs.Split(';');

    //            foreach(string est_job_depen_id in est_job_depen_ids) 
    //            {
    //                string status_depen_yn = GetStatusYN( comp_id
    //                                                    , est_id
    //                                                    , estterm_ref_id
    //                                                    , estterm_sub_id
    //                                                    , estterm_step_id
    //                                                    , est_job_depen_id);

    //                if(status_depen_yn.Equals("N")) 
    //                {
    //                    Biz_JobInfos depenJobInfo        = new Biz_JobInfos(est_job_depen_id);

    //                    if(ltrScript != null)
    //                        ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0} 작업을 우선 확정하신 후에 현재 작업이 확정 가능합니다.", depenJobInfo.Est_Job_Name));

    //                    return false;
    //                }
    //            }
    //        }
    //    }
        
    //    return true;
    //}

    public static string GetStatusHtml(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string[] est_job_ids) 
    {
        string temp = "";

        Biz_JobDetails jobDetail = null;

        foreach(string est_job_id in est_job_ids) 
        {
            jobDetail   = new Biz_JobDetails( comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_job_id);

            Biz_Status status = new Biz_Status(jobDetail.Status_YN, "0004");

            if(!jobDetail.Est_Job_Name.Equals("") && !jobDetail.Status_YN.Equals(""))
                temp += string.Format("<img src='{1}'> {0}&nbsp;", jobDetail.Est_Job_Name, status.Status_Img_Path);
        }

        return temp;
    }
}
