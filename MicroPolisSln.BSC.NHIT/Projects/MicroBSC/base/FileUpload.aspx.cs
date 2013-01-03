using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.Common;

public partial class base_FileUpload : AppPageBase
{
    public int miFilesProcessed = 0;
    //private string CS_MAPPATH = "/UploadFiles/";
    private string CS_MAPPATH = "";
    private string CS_EXCELPATH = "";
    private string[] mArgs = new string[3];

    private enum EN_ARGS_INFO : int
    {
        TBLINFO  = 0,
        SAVEINFO = 1,
        ATTACHNO = 2
    }
    private int GetArgsInfo(EN_ARGS_INFO eInfo)
    {
        return (int)eInfo;
    }
    public int IFileLimitSize
    {
        get
        {
            switch (GetRequest("SIZE", "S"))
            {
                case "S":
                    ViewState["SIZE"] = PageUtility.GetAppConfig("File.Size.Small");
                    break;
                case "M":
                    ViewState["SIZE"] = PageUtility.GetAppConfig("File.Size.Medium");
                    break;
                case "L":
                    ViewState["SIZE"] = PageUtility.GetAppConfig("File.Size.Large");
                    break;
                default:
                    ViewState["SIZE"] = PageUtility.GetAppConfig("File.Size.Small");
                    break;
            }

            return Convert.ToInt32(ViewState["SIZE"]);
        }
        set
        {
            ViewState["SIZE"] = value;
        }
    }

    public int ITotalSize
    {
        get
        {
            if (ViewState["TOTAL_SIZE"] == null)
            {
                ViewState["TOTAL_SIZE"] = GetRequest("TOTAL_SIZE","0");
            }
            return Convert.ToInt32(ViewState["TOTAL_SIZE"]);
        }
        set
        {
            ViewState["TOTAL_SIZE"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }

    ///////////////////////////////////////////////////////////////////////////////
    #region 페이지로딩시 실행되는 오버라이드 기본함수
        /// <summary>
        /// 페이지 초기화
        /// </summary>
        protected void SetPageData()
        {
            SearchDB();
        }

        /// <summary>
        /// Controls 값 초기화
        /// </summary>
        protected void InitControlValue()
        {
            hArgArray.Value = GetRequest("ARGS");
            hChangeFlag.Value = "F";

            // 추가된 기능으로 down_flag의 아규먼트가 넘어오면 보여주도록 한다.
            // 기능은 파일 다운로드까지 처리하도록 변경.
            if (GetRequest("DOWN_FLAG") == "T")
                btnDownFile.Visible = true;
            else
                btnDownFile.Visible = false;

            if (GetRequest("UP_FLAG") == "F")
            {
                this.FindFile.Visible   = false;
                this.btnDelFile.Visible = false;
            }
            else
            {
                this.FindFile.Visible   = true;
                this.btnDelFile.Visible = true;
            }
        }

        /// <summary>
        /// control event 등록
        /// </summary>
        protected void InitControlEvent()
        {
            //FindFile.Attributes["onpropertychange"] = "return mfCheckFile()";
            FindFile.Attributes["onchange"] = "return mfCheckFile()";
        }

        /// <summary>
        /// post back인 경우 처리
        /// </summary>
        protected void SetPostBack()
        {
            return;
        }

        /// <summary>
        /// SetAllTime
        ///     : 페이지 로딩의 모든 경우에 실행
        /// </summary>
        protected void SetAllTimeTop()
        {
            CS_MAPPATH   = PageUtility.GetAppConfig("Base.Upload");  // 업로드 루트 위치
            CS_EXCELPATH = PageUtility.GetAppConfig("Base.Excel");   // 엑셀 업로드 루트 위치
        }

        protected void SetAllTimeBottom()
        {
        }
    #endregion

    #region 내부 기타 함수
        private void SearchDB()
        {

            // dialogArguments가 있는지 체크한다.
            mArgs = hArgArray.Value.ToString().Split(';');

            if (mArgs.Length >= 1)
            {
                // 엑셀파일 저장인지 확인한다.
                if (mArgs[GetArgsInfo(EN_ARGS_INFO.TBLINFO)] == "EXCEL")
                {
                    return;
                }
            }

            if (mArgs.Length < 3)
            {
                PageUtility.AlertMessage("파일첨부에 대한 정보를 알 수 없습니다!", false, true);
                return;
            }

            hSaveAttachNo.Value = mArgs[GetArgsInfo(EN_ARGS_INFO.ATTACHNO)];

            Biz_Base_FileUpload bizCom = new Biz_Base_FileUpload();
            DataSet lDS = bizCom.GetFileUploaded(mArgs[GetArgsInfo(EN_ARGS_INFO.ATTACHNO)]);

            DataTable lDT = lDS.Tables[0];

            this.ITotalSize = 0;
            lbFileList.Items.Clear();
            for (int i = 0; i < lDT.Rows.Count; i++)
            {
                lbFileList.Items.Add(new ListItem(lDT.Rows[i]["v_FileText"].ToString(), lDT.Rows[i]["v_FileValue"].ToString()));
                this.ITotalSize += Convert.ToInt32(lDT.Rows[i]["P_FILESIZE"].ToString())/1000;
            }

            lblEnableAttKbyte.Text = this.GetRemainFileSize(); 
        }

        private void SetAdd2()
        {
            lblStatus.Text = "";

            string dir     = "";
            string status  = "";

            string lsAddFileInfo = "";  // 테이블에 저장될 파일정보
            string lsAddName     = "";	    //중복되면 시간을 붙여 파일명으로 만든다.
            string lsFileName    = System.IO.Path.GetFileName(FindFile.PostedFile.FileName);

            string sText    = "";
            string sValue   = "";

            string sTmpText = "";

            // dialogArguments가 있는지 체크한다.
            mArgs = hArgArray.Value.ToString().Split(';');

            if (Page.IsPostBack == true)
            {
                if (lsFileName == "")
                    return;

                if (mArgs[GetArgsInfo(EN_ARGS_INFO.TBLINFO)] == "EXCEL")
                {
                    // 엑셀파일일 경우는 파일 하나만 추가하도록 조정한다.
                    dir = CS_EXCELPATH + DateTime.Now.ToString("yyyyMMdd") + "/";

                    if (lsFileName.Substring(lsFileName.LastIndexOf(".") + 1).ToUpper() != "XLS" 
                        || lsFileName.Substring(lsFileName.LastIndexOf(".") + 1).ToUpper() != "XLSX")
                    {
                        PageUtility.AlertMessage("엑셀파일만 업로드할 수 있습니다!");
                        return;
                    }

                    if (lbFileList.Items.Count > 0)
                    {
                        PageUtility.AlertMessage("엑셀파일이 이미 추가되어 있습니다.");
                        return;
                    }
                }
                else
                {
                    // 일반파일일 경우
                    dir = CS_MAPPATH + mArgs[GetArgsInfo(EN_ARGS_INFO.SAVEINFO)] + "/" + DateTime.Now.ToString("yyyyMMdd") + "/";

                    if (mArgs.Length < 3)
                    {
                        PageUtility.AlertMessage("파일첨부에 대한 정보를 알 수 없습니다!", false, true);
                        return;
                    }

                    // AttachNo 추출여부 확인
                    if (hSaveAttachNo.Value == "")
                    {
                        //Biz_Base_FileUpload biz = new Biz_Base_FileUpload();
                        //hSaveAttachNo.Value = biz.GetAttachNo(mArgs[GetArgsInfo(EN_ARGS_INFO.SAVEINFO)] + "_F");

                        hSaveAttachNo.Value = mArgs[GetArgsInfo(EN_ARGS_INFO.SAVEINFO)] + "_F" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    }

                    for (int i = 0; i < lbFileList.Items.Count; i++)
                    {
                        sTmpText = lbFileList.Items[i].Text;
                        if (sTmpText.Substring(0, sTmpText.LastIndexOf(" (")) == lsFileName)
                        {
                            PageUtility.AlertMessage("이미 추가되어 있습니다!");

                            if (lbFileList.SelectedIndex >= 0)
                                lbFileList.Items[lbFileList.SelectedIndex].Selected = false;

                            lbFileList.Items[i].Selected = true;

                            return;
                        }
                    }
                }

                int iPostedFileSize = (FindFile.PostedFile.ContentLength / 1000);
                try
                {
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    while (true)
                    {
                        if (File.Exists(dir + lsAddName + lsFileName))
                            lsAddName = DateTime.Now.ToString("HHmmss") + "_";
                        else
                            break;
                    }

                    if ((this.ITotalSize + iPostedFileSize) > this.IFileLimitSize)
                    {
                        PageUtility.AlertMessage("파일용량을 초과하였습니다.");
                        return;
                    }

                    FindFile.PostedFile.SaveAs(dir + lsAddName + lsFileName);
                    miFilesProcessed++;
                    status += "&nbsp;&nbsp;- " + lsFileName + "<br>";

                    sValue = dir + lsAddName + lsFileName;
                    sText = System.IO.Path.GetFileName(FindFile.PostedFile.FileName) + " (" + TypeUtility.GetByte2Str(FindFile.PostedFile.InputStream.Length) + ")";

                    lbFileList.Items.Add(new ListItem(sText, sValue));
                    lblStatus.Text = "These " + miFilesProcessed + " file(s) were uploaded:<br>" + status;

                    hSaveFiles.Value += sText + ";" + sValue;

                    /*
                     * AttachNo, v_FileName, v_FileSize, p_FileSize, p_FullPath
                     * */
                    lsAddFileInfo = hSaveAttachNo.Value + ";"
                                  + System.IO.Path.GetFileName(FindFile.PostedFile.FileName) + ";"
                                  + TypeUtility.GetByte2Str(FindFile.PostedFile.InputStream.Length) + ";"
                                  + FindFile.PostedFile.InputStream.Length.ToString() + ";"
                                  + (dir + lsAddName + lsFileName);

                    // 파일저장 테이블에 인서트
                    int iProcess = 0;
                    Biz_Base_FileUpload bizUpload = new Biz_Base_FileUpload();

                    switch (mArgs[GetArgsInfo(EN_ARGS_INFO.TBLINFO)])
                    {
                        case "EXCEL":
                            // 저장이 엑셀업로드용 이라면 실제 디렉토리정보를 리턴한다.
                            hSaveAttachNo.Value = (dir + lsAddName + lsFileName);
                            break;
                        case "FILE":
                            iProcess = bizUpload.AddFileInfo(TypeUtility.GetSplit(lsAddFileInfo));
                            break;
                        case "PROCFILE":
                            // 추후에 ICM_PROCFILE에 업데이트 하는 모듈 개발해야 한다. (2006.02.25 강신규)
                            iProcess = bizUpload.AddFileInfo(TypeUtility.GetSplit(lsAddFileInfo));
                            break;
                    }

                    // 파일 저장정보 변경시 changeflag 셋팅
                    if (this.hChangeFlag.Value != "T")
                        this.hChangeFlag.Value = "T";

                    this.ITotalSize += iPostedFileSize;
                    lblEnableAttKbyte.Text = this.GetRemainFileSize();
                }
                catch (Exception err)
                {
                    // 파일처리가 되었다면 삭제한다.
                    DeleteFile(true);

                    lblStatus.Text = "Error saving file " + dir + "<br>" + err.ToString();
                }
            }
            else
            {

            }
        }

        private void SetAdd()
        {
            lblStatus.Text = "";

            // dialogArguments가 있는지 체크한다.
            mArgs = hArgArray.Value.ToString().Split(';');

            if (mArgs.Length < 3)
            {
                PageUtility.AlertMessage("파일첨부에 대한 정보를 알 수 없습니다!", false, true);
                return;
            }

            // AttachNo 추출여부 확인
            if (hSaveAttachNo.Value == "")
            {
                Biz_Base_FileUpload bizCom = new Biz_Base_FileUpload();
                hSaveAttachNo.Value = bizCom.GetAttachNo(mArgs[GetArgsInfo(EN_ARGS_INFO.SAVEINFO)] + "_F");
            }

            //string dir = Server.MapPath(CS_MAPPATH);
            string dir = CS_MAPPATH + mArgs[GetArgsInfo(EN_ARGS_INFO.SAVEINFO)] + "/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            string status = "";

            string lsAddFileInfo = "";  // 테이블에 저장될 파일정보
            string lsAddName     = "";	//중복되면 시간을 붙여 파일명으로 만든다.
            string lsFileName    = System.IO.Path.GetFileName(FindFile.PostedFile.FileName);

            string sText         = "";
            string sValue        = "";

            string sTmpText      = "";

            if (Page.IsPostBack == true)
            {
                if (lsFileName == "")
                    return;

                for (int i = 0; i < lbFileList.Items.Count; i++)
                {
                    sTmpText = lbFileList.Items[i].Text;
                    if (sTmpText.Substring(0, sTmpText.LastIndexOf(" (")) == lsFileName)
                    {
                        PageUtility.AlertMessage("이미 추가되어 있습니다!");

                        if (lbFileList.SelectedIndex >= 0)
                            lbFileList.Items[lbFileList.SelectedIndex].Selected = false;

                        lbFileList.Items[i].Selected = true;

                        return;
                    }
                }


                try
                {
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    while (true)
                    {
                        if (File.Exists(dir + lsAddName + lsFileName))
                            lsAddName = DateTime.Now.ToString("HHmmss") + "_";
                        else
                            break;
                    }

                    FindFile.PostedFile.SaveAs(dir + lsAddName + lsFileName);
                    miFilesProcessed++;
                    status += "&nbsp;&nbsp;- " + lsFileName + "<br>";

                    sValue = dir + lsAddName + lsFileName;
                    sText = System.IO.Path.GetFileName(FindFile.PostedFile.FileName) + " (" + TypeUtility.GetByte2Str(FindFile.PostedFile.InputStream.Length) + ")";

                    lbFileList.Items.Add(new ListItem(sText, sValue));
                    lblStatus.Text = "These " + miFilesProcessed + " file(s) were uploaded:<br>" + status;

                    hSaveFiles.Value += sText + ";" + sValue;

                    /*
                     * AttachNo, v_FileName, v_FileSize, p_FileSize, p_FullPath
                     * */
                    lsAddFileInfo = hSaveAttachNo.Value + ";"
                                  + System.IO.Path.GetFileName(FindFile.PostedFile.FileName) + ";"
                                  + TypeUtility.GetByte2Str(FindFile.PostedFile.InputStream.Length) + ";"
                                  + FindFile.PostedFile.InputStream.Length.ToString() + ";"
                                  + (dir + lsAddName + lsFileName);

                    // 파일저장 테이블에 인서트
                    int iProcess = 0;
                    Biz_Base_FileUpload bizUpload = new Biz_Base_FileUpload();

                    switch (mArgs[GetArgsInfo(EN_ARGS_INFO.TBLINFO)])
                    {
                        case "FILE":
                            iProcess = bizUpload.AddFileInfo(TypeUtility.GetSplit(lsAddFileInfo));
                            break;
                        case "PROCFILE":
                            // 추후에 ICM_PROCFILE에 업데이트 하는 모듈 개발해야 한다. (2006.02.25 강신규)
                            iProcess = bizUpload.AddFileInfo(TypeUtility.GetSplit(lsAddFileInfo));
                            break;
                    }
                }
                catch (Exception err)
                {
                    // 파일처리가 되었다면 삭제한다.
                    DeleteFile(true);

                    lblStatus.Text = "Error saving file " + dir + "<br>" + err.ToString();
                }

            }
            else
            {

            }
        }

        private void DeleteFile(bool isAll)
        {
            string lsRemoveFile = "";
            int iRemoveFileSize = 0;
            // dialogArguments가 있는지 체크한다.
            mArgs = hArgArray.Value.ToString().Split(';');

            Biz_Base_FileUpload bizCom = new Biz_Base_FileUpload();

            if (lbFileList.Items.Count != 0)
            {
                if (isAll)
                {
                    for (int i = 0; i < lbFileList.Items.Count; i++)
                    {
                        if (lbFileList.SelectedIndex >= 0)
                            lbFileList.Items[lbFileList.SelectedIndex].Selected = false;

                        lbFileList.Items[0].Selected = true;
                        lsRemoveFile = lbFileList.SelectedItem.Text;

                        try
                        {
                            if (File.Exists(lbFileList.SelectedItem.Value))
                            {
                                System.IO.FileInfo fn = new FileInfo(lbFileList.SelectedItem.Value);
                                iRemoveFileSize = Convert.ToInt32(fn.Length / 1000);

                                File.Delete(lbFileList.SelectedItem.Value);
                                miFilesProcessed++;
                            }

                            if (mArgs[GetArgsInfo(EN_ARGS_INFO.TBLINFO)] != "EXCEL")
                                bizCom.RemoveFileInfo(hSaveAttachNo.Value, lbFileList.SelectedItem.Value);

                            lbFileList.Items.RemoveAt(lbFileList.SelectedIndex);
                            lblStatus.Text = "These " + miFilesProcessed + " file(s) were removed:<br>" + lsRemoveFile;

                            this.ITotalSize -= iRemoveFileSize;
                            lblEnableAttKbyte.Text = this.GetRemainFileSize();
                        }
                        catch (Exception err)
                        {
                            lblStatus.Text = "Error removing file " + lsRemoveFile + "<br><br>" + err.ToString();
                        }
                    }
                }
                else
                {
                    if (lbFileList.SelectedIndex >= 0)
                    {
                        lsRemoveFile = lbFileList.SelectedItem.Text;

                        try
                        {
                            if (File.Exists(lbFileList.SelectedItem.Value))
                            {
                                System.IO.FileInfo fn = new FileInfo(lbFileList.SelectedItem.Value);
                                iRemoveFileSize = Convert.ToInt32(fn.Length / 1000);

                                File.Delete(lbFileList.SelectedItem.Value);
                                miFilesProcessed++;
                            }

                            if (mArgs[GetArgsInfo(EN_ARGS_INFO.TBLINFO)] != "EXCEL")
                                bizCom.RemoveFileInfo(hSaveAttachNo.Value, lbFileList.SelectedItem.Value.ToString());

                            lbFileList.Items.RemoveAt(lbFileList.SelectedIndex);
                            lblStatus.Text = "These " + miFilesProcessed + " file(s) were removed:<br>" + lsRemoveFile;

                            this.ITotalSize -= iRemoveFileSize;
                            lblEnableAttKbyte.Text = this.GetRemainFileSize();
                        }
                        catch (Exception err)
                        {
                            lblStatus.Text = "Error removing file " + lsRemoveFile + "<br><br>" + err.ToString();
                        }
                    }
                }

                // 파일 저장정보 변경시 changeflag 셋팅
                if (this.hChangeFlag.Value != "T")
                    this.hChangeFlag.Value = "T";
            }
        }

        private string GetRemainFileSize()
        {
            string sTemp = Convert.ToString(this.IFileLimitSize - this.ITotalSize);
            return sTemp;
        }
    #endregion

    #region 각 서버객체 이벤트함수
        ///////// <summary>
        ///////// 리스트박스에 추가된 파일들을 서버디렉토리로 업로드한다.
        ///////// </summary>
        ///////// <param name="sender"></param>
        ///////// <param name="e"></param>
        //////public void Upload_ServerClick(object sender, System.EventArgs e)
        //////{
        //////    string dir = Server.MapPath(CS_MAPPATH);
        //////    string status = "";

        //////    if (Page.IsPostBack == true)
        //////    {
        //////        if ((lbFileList.Items.Count == 0) && (miFilesProcessed == 0))
        //////        {
        //////            lblStatus.Text = "Error - a file name must be specified.";
        //////            return;

        //////        }
        //////        else
        //////        {
        //////            foreach (System.Web.UI.HtmlControls.HtmlInputFile HIF in hif)
        //////            {
        //////                try
        //////                {
        //////                    if (HIF.PostedFile != null)
        //////                    {
        //////                        string lsAddName = "";	//중복되면 시간을 붙여 파일명으로 만든다.
        //////                        string lsFileName = System.IO.Path.GetFileName(HIF.PostedFile.FileName);

        //////                        if (!Directory.Exists(dir))
        //////                            Directory.CreateDirectory(dir);

        //////                        while (true)
        //////                        {
        //////                            if (File.Exists(dir + lsAddName + lsFileName))
        //////                                lsAddName = DateTime.Now.ToString("HHmmss") + "_";
        //////                            else
        //////                                break;
        //////                        }

        //////                        HIF.PostedFile.SaveAs(dir + lsAddName + lsFileName);
        //////                        miFilesProcessed++;
        //////                        status += "&nbsp;&nbsp;- " + lsFileName + "<br>";

        //////                    }
        //////                }
        //////                catch (Exception err)
        //////                {
        //////                    lblStatus.Text = "Error saving file " + dir + "<br>" + err.ToString();
        //////                }
        //////            }

        //////            if (miFilesProcessed == hif.Count)
        //////            {
        //////                lblStatus.Text = "These " + miFilesProcessed + " file(s) were uploaded:<br>" + status;
        //////            }

        //////            ////string fileName = "";
        //////            ////foreach (HttpFileCollection hfC in ALFiles)
        //////            ////{
        //////            ////    if (!System.IO.Directory.Exists(dir))
        //////            ////        System.IO.Directory.CreateDirectory(dir);

        //////            ////    for (int i = 0; i < hfC.Count; i++)
        //////            ////    {
        //////            ////        HttpPostedFile file = hfC[i];

        //////            ////        fileName = System.IO.Path.GetFileName(file.FileName);

        //////            ////        file.SaveAs(dir + fileName);					// 업로드 한다.
        //////            ////    }


        //////            ////}

        //////            ALFiles.Clear();

        //////            //////////////////////////////
        //////            //System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
        //////            //string fileName = "";


        //////            //if (!System.IO.Directory.Exists(dir))
        //////            //    System.IO.Directory.CreateDirectory(dir);

        //////            //for (int i = 0; i < files.Count; i++)
        //////            //{
        //////            //    HttpPostedFile file = files[i];

        //////            //    fileName = System.IO.Path.GetFileName(file.FileName);

        //////            //    file.SaveAs(dir + fileName);					// 업로드 한다.
        //////            //}

        //////            hif.Clear();
        //////            lbFileList.Items.Clear();
        //////        }
        //////    }
        //////}

        protected void btnDelFile_Click(object sender, EventArgs e)
        {
            DeleteFile(false);
        }

        protected void lbnAdd_Click(object sender, EventArgs e)
        {
            SetAdd2();
        }

        protected void btnDownFile_Click(object sender, EventArgs e)
        {
            string sText = "";
            string sValue = "";

            if (lbFileList.Items.Count <= 0)
            {
                PageUtility.AlertMessage("첨부된 파일이 없습니다!");
                return;
            }

            if (lbFileList.SelectedIndex >= 0)
            {
                sText = lbFileList.SelectedItem.Text;
                sValue = lbFileList.SelectedItem.Value;

                PageUtility.FileDownLoad(sText.Substring(0, sText.LastIndexOf(" (")), sValue);
            }
            else
            {
                PageUtility.AlertMessage("다운로드 할 파일을 선택하십시요!");
                return;
            }
        }
    #endregion
}
