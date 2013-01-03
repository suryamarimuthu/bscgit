using System;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Text;
//using Excel;

using MicroBSC.Data;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.RolesBasedAthentication;


/// <summary>
/// AppPageUtility의 요약 설명입니다.
/// </summary>
public class AppPageUtility
{
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// Class   명		: AppPageUtility
    /// Class 내용		: 페이지와 관련된 Utility 처리 클래스입니다.
    /// 작  성  자		: 강신규
    /// 최초작성일		: 2006.05.22
    /// 최종수정자		: 
    /// 최종수정일		: 
    /// Services		:	
    /// 주요 변경 로그	:
    /// ////////////////////////////////////////////////////////////////////////////////////


    #region 필드 및 상수

    //스크립트 블럭의 고유키입니다.
    private const string MESSAGE_NAME = "AppPageUtility";

    private Page _clsPage;          //페이지객체필드
    private AppTypeUtility _clsTypeUtil;

    //랜덤필드
    private Random _clsRandom;
    private SiteIdentity _UserInfo;

    #endregion

    #region 생성자

    /// <summary>
    /// 서비스명	: AppPageUtility 생성자.
    /// 서비스내용	: AppPageUtility 객체 인스턴스를 초기화합니다.
    /// </summary>
    public AppPageUtility(Page page)
    {
        _clsPage = page;

        if (_clsPage.User.Identity.IsAuthenticated)
        {
            _UserInfo = (SiteIdentity)_clsPage.User.Identity;
        }

        _clsRandom = new Random(unchecked((int)DateTime.Now.Ticks));
        _clsTypeUtil = new AppTypeUtility();
    }

    #endregion

    #region Dispose 메서드

    /// <summary>
    /// 서비스명	: Dispose 메서드.
    /// 서비스내용	: 현재 페이지 객체의 모든 자원을 해제합니다.
    /// </summary>
    public void Dispose()
    {
        if (_clsPage != null)
            _clsPage.Dispose();
    }

    #endregion

    #region DropDownList 메서드

    /// <summary>
    /// 서비스명	: DataBindDropDownList 메서드
    /// 서비스내용	: 드롭다운리스트에 검색된 데이타를 바인딩합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="dsReceive">검색결과를 담은 DataSet 객체입니다.</param>
    /// <param name="sText">바인딩할 Text 문자열입니다.</param>
    /// <param name="sValue">바인딩할 Value 문자열입니다.</param>
    public void DataBindDropDownList(DropDownList ddlReceive, DataSet dsReceive, string sText, string sValue)
    {
        DataBindDropDownList(ddlReceive, dsReceive, sText, sValue, null);
    }

    /// <summary>
    /// 서비스명	: DataBindDropDownList 메서드
    /// 서비스내용	: 드롭다운리스트에 검색된 데이타를 바인딩합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="dsReceive">검색결과를 담은 DataSet 객체입니다.</param>
    /// 		/// <param name="sText">바인딩할 Text 문자열입니다.</param>
    /// <param name="sValue">바인딩할 Value 문자열입니다.</param>
    /// <param name="sDefaultItem">드롭다운리스트의 첫번째 아이템에 출력할 문자열입니다.</param>
    public void DataBindDropDownList(DropDownList ddlReceive, DataSet dsReceive, string sText, string sValue, string sDefaultItem)
    {
        ddlReceive.Items.Clear();

        if (dsReceive.Tables.Count > 0)
        {
            //DB에서 검색된 데이타를 ddlReceive 컨트롤에 바인딩합니다.
            //DropDownList 컨트롤에 사용될 데이타소스입니다.
            ddlReceive.DataSource = dsReceive;
            //DropDownList 컨트롤에 출력될 Text 입니다.
            ddlReceive.DataTextField = sText;
            //DropDownList 컨트롤에 출력될 Value 입니다.
            ddlReceive.DataValueField = sValue;
            //DropDownList 컨트롤에 바인딩합니다.
            ddlReceive.DataBind();
        }

        if (sDefaultItem != null)
        {
            //ddlReceive 맨 위에 ddl 디폴트 아이템을 추가합니다.
            ddlReceive.Items.Insert(0, sDefaultItem);
        }

        //객체를 해제합니다
        if ((ddlReceive != null) && (dsReceive != null))
        {
            dsReceive.Dispose();
            ddlReceive.Dispose();
            dsReceive = null;
            ddlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명	: FindByValueDropDownList 오버로딩 메서드.
    /// 서비스내용	: string 타입의 Value 값을 디롭다운리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="sValue">Value 값입니다.</param>
    public void FindByValueDropDownList(DropDownList ddlReceive, object sValue)
    {
        //ddlReceive.SelectedIndex =
        //    ddlReceive.Items.IndexOf(ddlReceive.Items.FindByValue(sValue));

        ////객체를 해제합니다
        //if (ddlReceive != null)
        //{
        //    ddlReceive.Dispose();
        //    ddlReceive = null;
        //}


        if (sValue == null)
            return;

        ddlReceive.ClearSelection();
        
        ListItem item = ddlReceive.Items.FindByValue(sValue.ToString());
        if (item != null)
            item.Selected = true;

    }

    /// <summary>
    /// 서비스명    : GetByValueDropDownList 메서드.
    /// 서비스내용  : DropDownList의 선택된 Value를 리턴합니다.
    public string GetByValueDropDownList(DropDownList ddlSearch)
    {
        return GetByValueDropDownList(ddlSearch, "");
    }

    public string GetByValueDropDownList(DropDownList ddlSearch, string returnValue)
    {
        //if (ddlSearch.SelectedIndex < 0)
        //    return returnValue;

        if (ddlSearch.SelectedItem      == null
            || ddlSearch.Items.Count    == 0)
            return returnValue;

        return ddlSearch.SelectedItem.Value.ToString().Trim();
    }

    // interger 형으로 반환한다.
    public int GetIntByValueDropDownList(DropDownList ddlSearch)
    {
        //if (ddlSearch.SelectedIndex < 0)
        //    return 0;

        //return int.Parse(ddlSearch.SelectedValue);

        if (ddlSearch.SelectedItem      == null 
            || ddlSearch.Items.Count    == 0)
            return 0;

        return int.Parse(ddlSearch.SelectedValue);
    }

    public string GetByTextDropDownList(DropDownList ddlSearch)
    {
        if (ddlSearch.SelectedIndex < 0)
            return "";

        return ddlSearch.SelectedItem.Text.ToString().Trim();
    }

    /// <summary>
    /// 서비스명	: FindByValueDropDownList 오버로딩 메서드.
    /// 서비스내용	: DataRow 타입의 Value 값을 디롭다운리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="drReceive">DataRow 객체입니다.</param>
    public void FindByValueDropDownList(DropDownList ddlReceive, DataRow drReceive)
    {
        ddlReceive.SelectedIndex =
            ddlReceive.Items.IndexOf(ddlReceive.Items.FindByValue(drReceive[0].ToString()));

        //객체를 해제합니다
        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명	: FindByTextDropDownList 오버로딩 메서드.
    /// 서비스내용	: string 타입의 Text 값을 디롭다운리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="sText">Text 값입니다.</param>
    public void FindByTextDropDownList(DropDownList ddlReceive, string sText)
    {
        ddlReceive.SelectedIndex =
            ddlReceive.Items.IndexOf(ddlReceive.Items.FindByText(sText));

        //객체를 해제합니다
        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명	: FindByTextDropDownList 오버로딩 메서드.
    /// 서비스내용	: DataRow 타입의 Text 값을 디롭다운리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="drReceive">DataRow 객체입니다.</param>
    public void FindByTextDropDownList(DropDownList ddlReceive, DataRow drReceive)
    {
        ddlReceive.SelectedIndex =
            ddlReceive.Items.IndexOf(ddlReceive.Items.FindByText(drReceive[0].ToString()));

        //객체를 해제합니다
        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명	: FindByValueRadioButtonList 오버로딩 메서드.
    /// 서비스내용	: string 타입의 Value 값을 라디오버튼리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="rbtnlReceive">출력할 RadioButtonList 객체입니다.</param>
    /// <param name="sValue">Value 값입니다.</param>
    public void FindByValueRadioButtonList(RadioButtonList rbtnlReceive, string sValue)
    {
        rbtnlReceive.SelectedIndex =
            rbtnlReceive.Items.IndexOf(rbtnlReceive.Items.FindByValue(sValue));

        //객체를 해제합니다
        if (rbtnlReceive != null)
        {
            rbtnlReceive.Dispose();
            rbtnlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명    : GetByValueRadioButtonList 메서드.
    /// 서비스내용  : 라디오버튼리스트의 선택된 Value를 리턴합니다.
    /// </summary>
    /// <param name="rbtnlSearch"></param>
    /// <returns></returns>
    public string GetByValueRadioButtonList(RadioButtonList rbtnlSearch)
    {
        if (rbtnlSearch.SelectedIndex < 0)
            return "";

        return rbtnlSearch.SelectedItem.Value.ToString().Trim();
    }

    /// <summary>
    /// 서비스명	: FindByTextRadioButtonList 오버로딩 메서드.
    /// 서비스내용	: string 타입의 Text 값을 라디오버튼리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="rbtnlReceive">출력할 RadioButtonList 객체입니다.</param>
    /// <param name="sText">Text 값입니다.</param>
    public void FindByTextRadioButtonList(RadioButtonList rbtnlReceive, string sText)
    {
        rbtnlReceive.SelectedIndex =
            rbtnlReceive.Items.IndexOf(rbtnlReceive.Items.FindByText(sText));

        //객체를 해제합니다
        if (rbtnlReceive != null)
        {
            rbtnlReceive.Dispose();
            rbtnlReceive = null;
        }
    }


    #endregion


    #region 검색페이지총수와 레코드 총수를 포맷팅하는 메서드

    /// <summary>
    /// 서비스명	: FormattingPageNumer 메서드.
    /// 서비스내용	: 페이지수를 출력하기 위한 포맷팅을 수행합니다.
    /// </summary>
    /// <param name="dgReceive">참조할 DataGrid 객체입니다.</param>
    public string FormattingPageNumer(DataGrid dgReceive)
    {
        string sCurrentPage = "";
        if (dgReceive.VirtualItemCount == 0)
            sCurrentPage = Convert.ToString(dgReceive.CurrentPageIndex);
        else
            sCurrentPage = Convert.ToString(dgReceive.CurrentPageIndex + 1);
        string sPagesNubmer = Convert.ToString(dgReceive.PageCount);

        //객체를 해제합니다.
        if (dgReceive != null)
        {
            dgReceive.Dispose();
            dgReceive = null;
        }
        return sCurrentPage + "/" + String.Format("{0:#,###,###}", sPagesNubmer);
    }

    /// <summary>
    /// 서비스명	: FormattingRecordNumer 메서드.
    /// 서비스내용	: 레코드수를 출력하기 위한 포맷팅을 수행합니다.
    /// </summary>
    /// <param name="dgReceive">참조할 DataGrid 객체입니다.</param>
    public string FormattingRecordNumer(DataGrid dgReceive)
    {
        string sRowsNumber = dgReceive.VirtualItemCount.ToString();

        //객체를 해제합니다.
        if (dgReceive != null)
        {
            dgReceive.Dispose();
            dgReceive = null;
        }
        return String.Format("{0:#,###,###}", sRowsNumber);
    }

    #endregion

    #region DataGrid 메서드

    /// <summary>
    /// 서비스명	: GetDataGridBlankMessage 메서드.
    /// 서비스내용	: 데이타그리드에 출력할 레코드가 없을경우 대응메시지를 출력합니다.
    /// </summary>
    /// <param name="sender">이벤트를 발생시킨 sender 객체입니다.</param>
    /// <param name="e">특정 이벤트의 DataGridItem 개체입니다.</param>
    /// <param name="sMessage">출력할 대응메시지 입니다.</param>
    public void GetDataGridBlankMessage(object sender, DataGridItemEventArgs e, string sMessage)
    {
        TableCell summaryCell;

        if (e.Item.ItemType == ListItemType.Footer)
        {
            int cellCountNum = e.Item.Cells.Count;

            for (int i = 1; i < cellCountNum; i++)
            {
                e.Item.Cells.RemoveAt(0);
            }

            ((DataGrid)sender).ShowFooter = false;
            summaryCell = e.Item.Cells[0];
            if (((DataGrid)sender).Items.Count == 0)
            {
                summaryCell.Text = sMessage;
                ((DataGrid)sender).ShowFooter = true;
            }

            //좌우 정렬을 지정한다. 
            summaryCell.ColumnSpan = cellCountNum;
            summaryCell.HorizontalAlign = HorizontalAlign.Center;
        }
    }

    /// <summary>
    /// 서비스명	: SetMouseRollOver 메서드.
    /// 서비스내용	: 데이타그리드의 레코드(행)에 마우스 롤오버 효과를 부여합니다.
    /// </summary>
    /// <param name="sender">이벤트를 발생시킨 sender 객체입니다.</param>
    /// <param name="e">특정 이벤트의 DataGridItem 개체입니다.</param>
    /// <param name="sOverColer">마우스오버할 색입니다.</param>
    /// <param name="sOutColor">마우스아웃할 색입니다.</param>
    public void SetMouseRollOver(object sender, DataGridItemEventArgs e, string sOverColer, string sOutColor)
    {
        //데이타그리드 Item에 MouseOver시 색깔 변화됩니다.
        if (e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //mouse over 시 변할 색깔을 설정합니다.
            e.Item.Attributes.Add("onMouseOver", "this.style.backgroundColor = '" + sOverColer + "'");
            //mouse over 시 원래 색으로 복구합니다.
            e.Item.Attributes.Add("onMouseOut", "this.style.backgroundColor  = '" + sOutColor + "'");
        }
        if (e.Item.ItemType == ListItemType.Item)
        {
            //mouse over 시 변할 색깔을 설정합니다.
            e.Item.Attributes.Add("onMouseOver", "this.style.backgroundColor = '" + sOverColer + "'");
            //mouse over 시 원래 색으로 복구합니다.
            e.Item.Attributes.Add("onMouseOut", "this.style.backgroundColor  = '" + sOutColor + "'");
        }
    }

    #endregion

    #region Attach File Page 를 iFrame 으로 출력하는 메서드

    /// <summary>
    /// 서비스명	: ExecuteAttachFile 메서드.
    /// 서비스내용	: 공통모듈인 첨부파일화면을 iFrame으로 가져와 파일업로드및 리스트출력 기능을 제공합니다.
    ///				  단, 이메서드는 파일DB에 실제키가 저장됩니다.
    /// </summary>
    /// <param name="sIFrameID">출력할 iFrame Name입니다.</param>
    /// <param name="sAttachFilePageUrl">첨부파일페이지가 존재하는 URL 입니다.</param>
    /// <param name="sDocKind">첨부할 문서의 종류를 나타냅니다.</param>
    /// <param name="sPrimaryKey">첨부파일의 기본키를 나타냅니다.</param>
    /// <param name="bIsAttachEnabled">true 면 첨부된 파일리스트 읽기및 첨부가능, false 면 읽기만 가능합니다.</param>
    /// <returns>임시키가 존재하면 string 으로 반환하고 없으면 null을 반환합니다.</returns>
    public void ExecuteAttachFile(
        string sIFrameID,
        string sAttachFilePageUrl,
        string sDocKind,
        string sPrimaryKey,
        bool bIsAttachEnabled
        )
    {
        string sSystemDocID = sPrimaryKey;
        string sSystemID = "SYS-000-003";
        string sFlag = "1";			//첨부파일 Flag = 1(실제키)

        //iFrame 으로 호출을 위한 첨부파일 페이지 url 설정
        StringBuilder clsUrl = new StringBuilder("");
        clsUrl.Append(sAttachFilePageUrl);					//iFrame으로 가져올 파일첨부화면 URL
        clsUrl.Append("?SystemDocID=" + sSystemDocID);		//첨부파일서버에 저장될 기본키	
        clsUrl.Append("&SystemID=" + sSystemID);			//품질(QM)에서 사용되는 고유 SystemID : SYS-000-003
        clsUrl.Append("&DocKind=" + sDocKind);			//첨부문서종류
        clsUrl.Append("&Flag=" + sFlag);				//임시키에서 실제키 변환시 Flag = 1 로 설정
        if (bIsAttachEnabled)
            clsUrl.Append("&psInform=N");					//첨부가능
        else
            clsUrl.Append("&psInform=Y");					//첨부불가능

        //iFrame 을 실행(호출)합니다.
        ExecuteFrame(sIFrameID, clsUrl.ToString());
    }

    /// <summary>
    /// 서비스명	: ExecuteAttachFile 메서드.
    /// 서비스내용	: 공통모듈인 첨부파일화면을 iFrame으로 가져와 파일업로드및 리스트출력 기능을 제공합니다.
    ///				  단, 이메서드는 파일DB에 임시키가 저장됩니다.
    /// </summary>
    /// <param name="sIFrameID">출력할 iFrame Name입니다.</param>
    /// <param name="sAttachFilePageUrl">첨부파일페이지가 존재하는 URL 입니다.</param>
    /// <param name="sDocKind">첨부할 문서의 종류를 나타냅니다.</param>
    /// <param name="sTempStartKey">첨부파일의 임시키중 앞부분을 나타냅니다.</param>
    /// <param name="sTempEndKey">첨부파일의 임시키중 뒷부분을 나타냅니다.</param>
    /// <param name="bIsAttachEnabled">true 면 첨부된 파일리스트 읽기및 첨부가능, false 면 읽기만 가능합니다.</param>
    /// <returns>임시키가 존재하면 string 으로 반환하고 없으면 null을 반환합니다.</returns>
    public string ExecuteAttachFile(
        string sIFrameID,
        string sAttachFilePageUrl,
        string sDocKind,
        string sTempStartKey,
        string sTempEndKey,
        bool bIsAttachEnabled
        )
    {
        string sSystemDocID = null;
        string sSystemID = "SYS-000-003";
        string sFlag = "0";			//첨부파일 Flag = 0(임시키)

        //임시 PK 규칙 : sTempStartKey + 년(4) + 월(2) + 일(2) + 시(2) + 분(2) + 초(2) + 미리초(3) + "-" + sTempEndKey
        StringBuilder clsSystemDocTempID = new StringBuilder("");
        clsSystemDocTempID.Append(sTempStartKey);
        clsSystemDocTempID.Append(DateTime.Now.ToString("yyyyMMddhhmmssfff"));
        if (sTempEndKey != string.Empty)
        {
            clsSystemDocTempID.Append("-");
            clsSystemDocTempID.Append(sTempEndKey);
        }

        //임시 PK 획득합니다.
        sSystemDocID = clsSystemDocTempID.ToString();

        //iFrame 으로 호출을 위한 첨부파일 페이지 url 설정
        StringBuilder clsUrl = new StringBuilder("");
        clsUrl.Append(sAttachFilePageUrl);					//iFrame으로 가져올 파일첨부화면 URL
        clsUrl.Append("?SystemDocID=" + sSystemDocID);		//첨부파일서버에 저장될 기본키	
        clsUrl.Append("&SystemID=" + sSystemID);			//품질(QM)에서 사용되는 고유 SystemID : SYS-000-003
        clsUrl.Append("&DocKind=" + sDocKind);			//첨부문서종류
        clsUrl.Append("&Flag=" + sFlag);				//임시키에서 실제키 변환시 Flag = 1 로 설정
        if (bIsAttachEnabled)
            clsUrl.Append("&psInform=N");					//첨부가능
        else
            clsUrl.Append("&psInform=Y");					//첨부불가능

        //iFrame 을 실행(호출)합니다.
        ExecuteFrame(sIFrameID, clsUrl.ToString());

        //임시키를 리턴합니다.
        return sSystemDocID;
    }

    #endregion

    #region iFrame 호출 메서드

    /// <summary>
    /// 서비스명	: ExecuteFrame 메서드.
    /// 서비스내용	: C#(서버단)으로 iframe 을 호출(실행)합니다.
    /// </summary>
    /// <param name="sIFrameID">iFrame Name입니다.</param>
    /// <param name="sUrl">iFrame 에 넘겨줄 URL 입니다.</param>
    public void ExecuteFrame(string sIFrameID, string sUrl)
    {
        //iFrame 호출
        string sScript = "";
        sScript += sIFrameID + ".document.location.href='" + sUrl + "';";

        if (_clsPage != null)
        {
            //클라이언트 스크립드 실행
            ExecuteScript(sScript);
        }
    }

    #endregion

    #region 자바스크립트 실행 메서드

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩1)
    /// 서비스내용	: 페이지 로딩 후 자바스크립트 Alert 메세지를 출력합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    public void AlertMessage(string sMessage)
    {
        AlertMessage(sMessage, false, false, "");
    }

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩1)
    /// 서비스내용	: 자바스크립트 Alert 메세지를 출력합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    public void AlertMessage(string sMessage, bool bIsBlank)
    {
        AlertMessage(sMessage, bIsBlank, false, "");
    }

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩2)
    /// 서비스내용	: 자바스크립트 Alert 메세지출력, 창닫기유무, Alert 창 백그라운드에 공백출력유무등의 기능을
    ///				  제공합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="bIsClose">메시지 출력후 창닫기 여부를 결정합니다.</param>
    public void AlertMessage(string sMessage, bool bIsBlank, bool bIsClose)
    {
        AlertMessage(sMessage, bIsBlank, bIsClose, "");
    }

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩3)
    /// 서비스내용	: 자바스크립트 Alert 메세지를 출력후 페이지 이동을 수행합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="sRedirectUrl">메시지 출력후 페이지 이동할 Url 입니다.</param>
    public void AlertMessage(string sMessage, bool bIsBlank, string sRedirectUrl)
    {
        string sScriptCommand = "document.location.href = '" + sRedirectUrl + "';";
        AlertMessage(sMessage, bIsBlank, false, sScriptCommand);
    }

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩4)
    /// 서비스내용	: 자바스크립트 Alert 메세지출력, 창닫기유무, Alert 창 백그라운드에 공백출력유무,
    ///				  기타 자바스크립트 소스추가 유뮤를 자유롭게 선택할 수 있습니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="bIsClose">메시지 출력후 창닫기 여부를 결정합니다.</param>
    /// <param name="sScriptCommand">메시지 출력후 추가 실행할 자바스크립트 소스입니다.</param>
    public void AlertMessage(string sMessage, bool bIsBlank, bool bIsClose, string sScriptCommand)
    {
        string msMSG = "";
        msMSG += "alert('" + sMessage.Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r") + "');";
        msMSG += sScriptCommand;
        msMSG += bIsClose ? "opener = self; window.close();" : "";

        //자바스크립트 실행
        ExecuteScript(msMSG, bIsBlank);
    }

    /// <summary>
    /// 서비스명	: AlertMsgFocus 메서드
    /// 서비스내용	: 페이지 로딩 후 자바스크립트 Alert 메세지를 출력합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="sConFocus">Focus 이동할 컨트롤지정</param>
    public void AlertMsgFocus(string sMessage, string sConFocus)
    {
        AlertMsgFocus(sMessage, false, false, sConFocus);
    }

    /// <summary>
    /// 서비스명	: AlertMsgFocus
    /// 서비스내용	: 자바스크립트 Alert 메세지출력, 창닫기유무, Alert 창 백그라운드에 공백출력유무,
    ///				  이동할 포커스를 지정합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="bIsClose">메시지 출력후 창닫기 여부를 결정합니다.</param>
    /// <param name="sConFocus">메시지 출력후 이동할  포커스 지정합니다.</param>
    public void AlertMsgFocus(string sMessage, bool bIsBlank, bool bIsClose, string sConFocus)
    {
        string msMSG = "";
        msMSG += "alert('" + sMessage.Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", "\\r") + "');";
        msMSG += "try {eval(document.forms[0]." + sConFocus + ".select());} catch(e){}";
        msMSG += "try {eval(document.forms[0]." + sConFocus + ".focus());} catch(e){}";
        msMSG += bIsClose ? "self.close();" : "";

        //자바스크립트 실행
        ExecuteScript(msMSG, bIsBlank);
    }

    /// <summary>
    /// 서비스명	: Focus 메서드
    /// 서비스내용	: 페이지 로딩 후 자바스크립트 포커스를 지정합니다.
    /// </summary>
    /// <param name="sConFocus">Focus 이동할 컨트롤지정</param>
    public void Focus(string sConFocus)
    {
        Focus(false, false, sConFocus);
    }

    /// <summary>
    /// 서비스명	: Focus
    /// 서비스내용	: 자바스크립트 이동할 포커스를 지정합니다.
    /// </summary>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="bIsClose">메시지 출력후 창닫기 여부를 결정합니다.</param>
    /// <param name="sConFocus">메시지 출력후 이동할  포커스 지정합니다.</param>
    public void Focus(bool bIsBlank, bool bIsClose, string sConFocus)
    {
        string msMSG = "";
        msMSG += "eval(document.forms[0]." + sConFocus + ".focus());";
        msMSG += bIsClose ? "self.close();" : "";

        //자바스크립트 실행
        ExecuteScript(msMSG, bIsBlank);
    }

    /// <summary>
    /// 서비스명	: MovePage 메서드.
    /// 서비스내용	: 자바스크립트로 페이지 이동합니다.
    /// </summary>
    /// <param name="sRedirectUrl">이동할 페이지 Url 입니다.</param>
    public void MovePage(string sRedirectUrl)
    {
        string sScript = "";
        sScript += "document.location.href = '" + sRedirectUrl + "';";
        ExecuteScript(sScript, true);
    }

    /// <summary>
    /// 서비스명	: ExecuteScript 메서드.
    /// 서비스내용	: 페이지 로딩 후 자바스크립트 명령문을 처리합니다.
    /// </summary>
    /// <param name="sScript">실행할 클라이언트 스크립트 문자열입니다.</param>
    public void ExecuteScript(string sScript)
    {
        Type csType = _clsPage.GetType();

        sScript = "<script type=text/javascript>" + sScript + "</script>";
        //현재시각과 랜덤값 더한 것을 sriptID 의 key 로 설정합니다.
        string sScriptID = DateTime.Now.ToString("yyyyMMddhhmmssfff") + _clsRandom.Next().ToString();

        //if (!_clsPage.IsClientScriptBlockRegistered(sScriptID))
        //    _clsPage.RegisterStartupScript(sScriptID, sScript);

        if (!_clsPage.ClientScript.IsClientScriptBlockRegistered(csType, sScriptID))
            _clsPage.ClientScript.RegisterStartupScript(csType, sScriptID, sScript);

    }

    /// <summary>
    /// 서비스명	: ExecuteScript 메서드.
    /// 서비스내용	: 자바스크립트 명령문을 처리합니다.
    /// </summary>
    /// <param name="sScript">실행할 클라이언트 스크립트 문자열입니다.</param>
    /// <param name="bIsRunBeforePageLoad">페이지로드전에 실행하려면 true 로 설정합니다.</param>
    public void ExecuteScript(string sScript, bool bIsRunBeforePageLoad)
    {
        Type csType = _clsPage.GetType();

        sScript = "<script type=text/javascript>" + sScript + "</script>";
        //페이지로딩 전에 수행합니다.
        if (bIsRunBeforePageLoad)
        {
            HttpContext.Current.Response.Write(sScript);
        }
        //페이지로딩후에 수행합니다.
        else
        {
            //현재시각과 랜덤값 더한 것을 sriptID 의 key 로 설정합니다.
            string sScriptID = DateTime.Now.ToString("yyyyMMddhhmmssfff") + _clsRandom.Next().ToString();
            //if (!_clsPage.IsClientScriptBlockRegistered(sScriptID))
            //    _clsPage.RegisterStartupScript(sScriptID, sScript);


            if (!_clsPage.ClientScript.IsClientScriptBlockRegistered(csType, sScriptID))
                _clsPage.ClientScript.RegisterStartupScript(csType, sScriptID, sScript);
        }
    }

    #endregion

    #region 그외 메서드
    /// <summary>
    /// 루트 웹 패스
    /// </summary>
    /// <returns></returns>
    public string GetWebAppPath()
    {
        return HttpContext.Current.Request.ApplicationPath;
    }

    /// <summary>
    /// 실제 루트 디렉토리 패스
    /// </summary>
    /// <returns></returns>
    public string GetPhysicalPath()
    {
        return HttpContext.Current.Request.PhysicalApplicationPath;
    }

    public string GetAppConfig(string asSetting)
    {
        //string connstr = ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
        //string saveFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + System.Configuration.ConfigurationManager.AppSettings[asSetting];

        //System.Configuration.AppSettingsReader appSetting = new AppSettingsReader();
        //return (string)appSetting.GetValue(asSetting, Type.GetType("string"));

        string lsRet = "";

        try
        {
            lsRet = ConfigurationManager.AppSettings[asSetting].ToString();
        }
        catch (Exception ex)
        {
            lsRet = "";
        }

        return lsRet;
    }

    /// <summary>
    /// 서비스명	: CheckQueryString 메서드.
    /// 서비스내용	: QuertString 을 체크한 후 잘못되었으면 페이지를 표시하지 않습니다.(원천봉쇄 ^^)
    /// </summary>
    /// <param name="QueryString">QueryString 컬렉션입니다.</param>
    /// <param name="sQueryStringsForChecking">체크하고자 하는 특정 QueryString 문자열입니다.</param>
    public void CheckQueryString(System.Collections.Specialized.NameValueCollection queryString, params string[] sQueryStringsForChecking)
    {
        string sMessage = "";
        for (int i = 0; i < sQueryStringsForChecking.Length; i++)
        {
            if (queryString[sQueryStringsForChecking[i]] == null)
            {
                sMessage = "Wrong URL access!\r\n"
                    + "Access is blocked by "
                    + "QueryString[\"" + sQueryStringsForChecking[i] + "\"] "
                    + "not existing!";

                AlertMessage(sMessage, true, true);
                HttpContext.Current.Response.End();
            }
        }
    }

    /// <summary>
    /// 서비스명	: CheckMetaChar3 함수
    /// 서비스내용	: 검색 Meta 문자열 필터링
    ///				  ER 의뢰서 페이지에서 사용
    /// </summary>
    /// <param name="Input"></param>
    /// <param name="RuleKeyWord"></param>
    /// <returns></returns>
    public bool CheckMetaChar3(string Input, string[] RuleKeyWord)
    {
        // . 제외 % 제외
        for (int i = 0; i < RuleKeyWord.Length; i++)
        {
            if (Input.IndexOf(RuleKeyWord[i].ToString()) != -1)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 서비스명		: GetByteLength 함수
    /// 서비스내용		: 문자열 길이 리턴
    /// </summary>
    /// <param name="sChars"></param>
    /// <returns></returns>
    public int GetByteLength(string sChars)
    {
        byte[] maByte = System.Text.Encoding.Default.GetBytes(sChars);

        return maByte.Length;
    }

    #endregion

    #region 엑셀관련 함수
    //public void ExcelExport2PC(System.Data.DataTable pTable)
    //{
    //    Excel.Application xlApp = null; // Excel Application
    //    Excel.Workbook xlWorkbook = null; // Excel Workbook
    //    Excel.Worksheet xlWorksheet = null; // Excel Worksheet
    //    Excel.Range xlRange = null; // Excel Range
    //    Excel.Style xlStyle = null; // Excel Style

    //    int iIndRow = 0;
    //    int iIndCol = 0;
    //    string[,] saTotValue;
    //    string[] saLineValue;

    //    try
    //    {
    //        xlApp = new Excel.ApplicationClass();

    //        xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
    //        xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;
    //        xlStyle = xlWorkbook.Styles.Add("HeaderStyle", Type.Missing);

    //        #region 헤더 스타일 작성
    //        xlStyle.Interior.Color = (102 << 16) | (51 << 8) | 153;

    //        xlStyle.Borders.Color = (0 << 16) | (0 << 8) | 0;
    //        xlStyle.Font.Color = (255 << 16) | (255 << 8) | 255;
    //        xlStyle.Font.Bold = true;

    //        xlStyle.HorizontalAlignment = XlHAlign.xlHAlignCenter;
    //        xlStyle.VerticalAlignment = XlVAlign.xlVAlignCenter;
    //        xlStyle.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
    //        #endregion

    //        //xlApp.Visible = true;

    //        // Header
    //        iIndCol = 0;
    //        foreach (DataColumn dc in pTable.Columns)
    //        {
    //            iIndCol++;

    //            xlWorksheet.Cells[1, iIndCol] = dc.ColumnName;
    //        }

    //        xlRange = xlWorksheet.get_Range(
    //                                        string.Format("{0}{1}", _clsTypeUtil.GetExcelRange(1), 1)
    //                                      , string.Format("{0}{1}", _clsTypeUtil.GetExcelRange(iIndCol), 1)
    //                                       );

    //        xlRange.Style = xlStyle;

    //        xlRange.Borders.Color = (0 << 16) | (0 << 8) | 0;
    //        xlRange.Borders[XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
    //        xlRange.Borders[XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
    //        //xlRange.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
    //        //xlRange.Borders[XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
    //        xlRange.Borders[XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
    //        xlRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
    //        xlRange.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
    //        xlRange.Borders[XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;

    //        // Contents
    //        iIndRow = 1;

    //        // 추출된 데이터를 한번에 엑셀파일에 쓰기위한 배열 (속도의차이)
    //        saTotValue = new string[pTable.Rows.Count, pTable.Columns.Count];
    //        saLineValue = new string[pTable.Columns.Count];

    //        foreach (DataRow dr in pTable.Rows)
    //        {
    //            iIndRow++;

    //            iIndCol = 0;

    //            foreach (object val in dr.ItemArray)
    //            {
    //                iIndCol++;

    //                //xlStyle.Interior.Pattern=Excel.XlPattern.xlPatternSolid;
    //                //xlStyle.Interior.PatternColorIndex=Excel.XlBackground.xlBackgroundAutomatic;

    //                xlRange = xlWorksheet.get_Range(
    //                                                string.Format("{0}{1}", _clsTypeUtil.GetExcelRange(iIndCol), iIndRow)
    //                                              , string.Format("{0}{1}", _clsTypeUtil.GetExcelRange(iIndCol), iIndRow)
    //                                               );

    //                if (val.GetType() == System.Type.GetType("System.String"))
    //                    xlRange.NumberFormatLocal = @"@";

    //                saTotValue[iIndRow - 2, iIndCol - 1] = val.ToString();
    //                saLineValue[iIndCol - 1] = val.ToString();
    //                //xlWorksheet.Cells[iIndRow, iIndCol] = val;
    //            }
    //            xlRange = xlWorksheet.get_Range(
    //                                            string.Format("{0}{1}", _clsTypeUtil.GetExcelRange(1), iIndRow)
    //                                          , string.Format("{0}{1}", _clsTypeUtil.GetExcelRange(iIndCol), iIndRow)
    //                                           );

    //            xlRange.Value2 = saTotValue;
    //        }

    //        xlRange = xlWorksheet.get_Range(
    //                                        string.Format("{0}{1}", _clsTypeUtil.GetExcelRange(1), 2)
    //                                      , string.Format("{0}{1}", _clsTypeUtil.GetExcelRange(iIndCol), iIndRow)
    //                                       );

    //        //xlRange.Value2 = saTotValue;
    //        xlRange.EntireColumn.AutoFit();

    //        xlWorkbook.Saved = true;

    //        xlWorksheet.SaveAs("c:\\Test.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    //        //xlWorkbook.SaveAs("C:\\Test.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    //        //xlWorkbook.Saved = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        try
    //        {

    //            // 엑셀 객체 파괴
    //            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
    //            xlWorksheet = null;

    //            xlWorkbook.Close(false, "", false);
    //            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
    //            xlWorkbook = null;

    //            xlApp.Quit();
    //            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
    //            xlApp = null;

    //            GC.Collect();
    //            GC.WaitForPendingFinalizers();
    //        }
    //        catch
    //        {

    //        }
    //    }
    //}


    /* 2011-08-29 수정 : Interop.Excel 라이브러리를 제거. 메서드 역시 삭제
    public void ExportExcel(string fileName, string fileFullPath, string[] headers, System.Data.DataTable dtbody, bool previewfile)
    {
        Excel.Application xlApp = null; // Excel Application
        Excel.Workbook xlWorkbook = null; // Excel Workbook
        Excel.Worksheet xlWorksheet = null; // Excel Worksheet
        Excel.Range xlRange = null; // Excel Range
        Excel.Style xlStyle = null; // Excel Style

        //string sFileName            = string.Empty;
        //string sPath                = string.Empty;

        try
        {
            xlApp = new Excel.ApplicationClass();

            xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
            //xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;
            xlStyle = xlWorkbook.Styles.Add("NewStyle", Type.Missing);

            xlApp.Visible = previewfile;

            for (int i = 0; i < headers.Length; i++)
            {
                xlWorksheet.Cells[1, i + 1] = headers[i];
            }

            int DownRowCnt = dtbody.Rows.Count;

            for (int k = 0; k < DownRowCnt; k++)
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    xlWorksheet.Cells[k + 2, i + 1] = dtbody.Rows[k][i].ToString();
                }
            }


            int styleLen = headers.Length;

            xlRange = xlWorksheet.get_Range(_clsTypeUtil.GetExcelRange(1) + "1", _clsTypeUtil.GetExcelRange(styleLen) + "1");
            //xlRange                         = xlWorksheet.get_Range(_clsTypeUtil.GetExcelRange(1) + "1", _clsTypeUtil.GetExcelRange(10) + "1");
            xlRange.EntireColumn.AutoFit();
            xlRange.NumberFormatLocal = @"@";
            xlStyle.Interior.ColorIndex = 18;
            xlStyle.Font.ColorIndex = 2;

            //xlStyle.Interior.Pattern=Excel.XlPattern.xlPatternSolid;
            //xlStyle.Interior.PatternColorIndex=Excel.XlBackground.xlBackgroundAutomatic;

            xlRange.Style = xlStyle;

            xlWorkbook.Saved = true;

            //// Excel 저장

            if (File.Exists(fileFullPath))
                File.Delete(fileFullPath);

            xlWorkbook.SaveAs(fileFullPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ////xlWorkbook.SaveAs(sFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
            xlWorksheet = null;

            xlWorkbook.Close(false, fileFullPath, false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
            xlWorkbook = null;

            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            xlApp = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (File.Exists(fileFullPath))
            {
                //FileDownLoad(fileName + ".xls", fileFullPath);
                FileDownLoad(fileName, fileFullPath);
            }
            else
            {
                throw new Exception("엑셀파일을 생성하는데 실패하였습니다.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ExportExcelWithHeader(string fileName, string fileFullPath, string[] headers, bool previewfile)
    {
        Excel.Application xlApp = null; // Excel Application
        Excel.Workbook xlWorkbook = null; // Excel Workbook
        Excel.Worksheet xlWorksheet = null; // Excel Worksheet
        Excel.Range xlRange = null; // Excel Range
        Excel.Style xlStyle = null; // Excel Style

        //string sFileName            = string.Empty;
        //string sPath                = string.Empty;

        try
        {
            xlApp = new Excel.ApplicationClass();

            xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
            //xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;
            xlStyle = xlWorkbook.Styles.Add("NewStyle", Type.Missing);

            xlApp.Visible = previewfile;

            for (int i = 0; i < headers.Length; i++)
            {
                xlWorksheet.Cells[1, i + 1] = headers[i];
            }


            int styleLen = headers.Length;

            xlRange = xlWorksheet.get_Range(_clsTypeUtil.GetExcelRange(1) + "1", _clsTypeUtil.GetExcelRange(styleLen) + "1");
            //xlRange                         = xlWorksheet.get_Range(_clsTypeUtil.GetExcelRange(1) + "1", _clsTypeUtil.GetExcelRange(10) + "1");
            xlRange.EntireColumn.AutoFit();
            xlRange.NumberFormatLocal = @"@";
            xlStyle.Interior.ColorIndex = 18;
            xlStyle.Font.ColorIndex = 2;

            //xlStyle.Interior.Pattern=Excel.XlPattern.xlPatternSolid;
            //xlStyle.Interior.PatternColorIndex=Excel.XlBackground.xlBackgroundAutomatic;

            xlRange.Style = xlStyle;

            xlWorkbook.Saved = true;

            // Excel 저장

            if (File.Exists(fileFullPath))
                File.Delete(fileFullPath);

            xlWorkbook.SaveAs(fileFullPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //xlWorkbook.SaveAs(sFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
            xlWorksheet = null;

            xlWorkbook.Close(false, fileFullPath, false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
            xlWorkbook = null;

            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            xlApp = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (File.Exists(fileFullPath))
            {
                //FileDownLoad(fileName + ".xls", fileFullPath);
                FileDownLoad(fileName, fileFullPath);
            }
            else
            {
                throw new Exception("헤더를 포함한 엑셀파일을 생성하는데 실패하였습니다.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    */

    /// <summary>
    /// 서비스명    : 엑셀관련 함수
    /// 서비스내용  : 엑셀다운로드
    /// 작성자      : 강신규
    /// </summary>
    /// <param name="dgList"></param>
    /// <param name="pFileName"></param>
    //public void ExcelDownLoad(DataGrid dgList, string pFileName)
    //{
    //    if (dgList != null)
    //    {
    //        ExcelDownLoad(dgList, 0, dgList.Columns.Count - 1, pFileName, false);
    //    }
    //}

    //public void ExcelDownLoad(DataGrid dgList, string pFileName, bool bHideVisible)
    //{
    //    if (dgList != null)
    //    {
    //        ExcelDownLoad(dgList, 0, dgList.Columns.Count - 1, pFileName, bHideVisible);
    //    }
    //}

    //public void ExcelDownLoad(DataGrid dgList, int iEnd, string pFileName)
    //{
    //    ExcelDownLoad(dgList, 0, iEnd, pFileName, false);
    //}

    //public void ExcelDownLoad(DataGrid dgList, int iEnd, string pFileName, bool bHideVisible)
    //{
    //    ExcelDownLoad(dgList, 0, iEnd, pFileName, bHideVisible);
    //}

    //public void ExcelDownLoad(DataGrid dgList, int iStart, int iEnd, string pFileName, bool bHideVisible)
    //{
    //    System.Data.DataTable dtRet = new System.Data.DataTable();
    //    DataRow dr;
    //    int iIndex;

    //    if (dgList != null)
    //    {
    //        for (int i = iStart; i <= iEnd; i++)
    //        {
    //            if (dgList.Columns[i].Visible)
    //                dtRet.Columns.Add(dgList.Columns[i].HeaderText, typeof(string));
    //            else
    //            {
    //                if (bHideVisible)
    //                    dtRet.Columns.Add(dgList.Columns[i].HeaderText, typeof(string));
    //            }
    //        }

    //        for (int i = 0; i < dgList.Items.Count; i++)
    //        {

    //            dr = dtRet.NewRow();

    //            dr.BeginEdit();

    //            iIndex = iStart;
    //            for (int j = iStart; j <= iEnd; j++)
    //            {
    //                if (dgList.Columns[j].Visible)
    //                {
    //                    dr[iIndex] = dgList.Items[i].Cells[j].Text;
    //                    iIndex++;
    //                }
    //                else
    //                {
    //                    if (bHideVisible)
    //                    {
    //                        dr[iIndex] = dgList.Items[i].Cells[j].Text;
    //                        iIndex++;
    //                    }
    //                }
    //            }

    //            dr.EndEdit();

    //            dtRet.Rows.Add(dr);
    //        }

    //        ExcelDownLoad(dtRet, pFileName);

    //    }
    //}

    public void ExcelDownLoad(UltraWebGrid ugList, string pFileName)
    {
        ExcelDownLoad(ugList, pFileName, false);
    }

    public void ExcelDownLoad(UltraWebGrid ugList, string pFileName, bool bHideVisible)
    {
        if (ugList != null)
        {
            ExcelDownLoad(ugList, 0, ugList.Columns.Count - 1, pFileName, bHideVisible);
        }
    }

    public void ExcelDownLoad(UltraWebGrid ugList, int iEnd, string pFileName)
    {
        ExcelDownLoad(ugList, 0, iEnd, pFileName, false);
    }

    public void ExcelDownLoad(UltraWebGrid ugList, int iEnd, string pFileName, bool bHideVisible)
    {
        ExcelDownLoad(ugList, 0, iEnd, pFileName, bHideVisible);
    }

    public void ExcelDownLoad(UltraWebGrid ugList, int iStart, int iEnd, string pFileName, bool bHideVisible)
    {
        System.Data.DataTable dtRet = new System.Data.DataTable();
        DataRow dr;
        int iIndex;

        ArrayList arrList = new ArrayList();
        string sHeaderCol = "";
        string sTemp1 = "";
        string sTemp2 = "";

        if (ugList != null)
        {
            for (int i = iStart; i <= iEnd; i++)
            {
                sHeaderCol = GetValue(ugList.Columns[i].Header.Caption);

                while (arrList.Contains(sHeaderCol))
                {
                    sTemp1 = sHeaderCol.Substring(0, (sHeaderCol.LastIndexOf("_") < 0 ? sHeaderCol.Length : sHeaderCol.LastIndexOf("_")));
                    sTemp2 = sHeaderCol.Substring(sHeaderCol.LastIndexOf("_") + 1);

                    if (_clsTypeUtil.GetNumString(sTemp2) != "")
                    {
                        sTemp2 = (Convert.ToInt32(_clsTypeUtil.GetNumString(sTemp2)) + 1).ToString();
                    }
                    else
                        sTemp2 = "1";

                    sHeaderCol = sTemp1 + "_" + sTemp2;
                }

                arrList.Add(sHeaderCol);

                if (ugList.Columns[i].Hidden)
                {
                    if (bHideVisible)
                    {
                        dtRet.Columns.Add(sHeaderCol, Type.GetType(ugList.Columns[i].DataType));

                    }
                }
                else
                {
                    dtRet.Columns.Add(sHeaderCol, Type.GetType(ugList.Columns[i].DataType));
                }
            }

            for (int i = 0; i < ugList.Rows.Count; i++)
            {
                dr = dtRet.NewRow();
                dr.BeginEdit();

                iIndex = iStart;
                for (int j = iStart; j <= iEnd; j++)
                {
                    if (ugList.Columns[j].Hidden)
                    {
                        if (bHideVisible)
                        {
                            dr[iIndex] = ugList.Rows[i].Cells[j].Text;
                            iIndex++;
                        }
                    }
                    else
                    {
                        dr[iIndex] = ugList.Rows[i].Cells[j].Text;
                        iIndex++;
                    }
                }

                dr.EndEdit();

                dtRet.Rows.Add(dr);
            }

            ExcelDownLoad(dtRet, pFileName);
        }
    }

    public void ExcelDownLoad(DataSet pDSet)
    {
        ExcelDownLoad(pDSet, "ExcelDown");
    }

    public void ExcelDownLoad(DataSet pDSet, bool pbTitle)
    {
        ExcelDownLoad(pDSet, "ExcelDown", pbTitle);
    }

    public void ExcelDownLoad(DataSet pDSet, string pFileName)
    {
        System.Data.DataTable dt = new System.Data.DataTable();

        if (pDSet.Tables.Count > 0)
            dt = pDSet.Tables[0];

        ExcelDownLoad(dt, pFileName);
    }

    public void ExcelDownLoad(DataSet pDSet, string pFileName, bool pbTitle)
    {
        System.Data.DataTable dt = new System.Data.DataTable();

        if (pDSet.Tables.Count > 0)
            dt = pDSet.Tables[0];

        ExcelDownLoad(dt, pFileName, pbTitle);
    }

    public void ExcelDownLoad(System.Data.DataTable pTable)
    {
        ExcelDownLoad(pTable, "ExcelDown");
    }

    public void ExcelDownLoad(System.Data.DataTable pTable, bool pbTitle)
    {
        ExcelDownLoad(pTable, "ExcelDown", pbTitle);
    }

    public void ExcelDownLoad(System.Data.DataTable pTable, string pFileName)
    {
        StringBuilder sbWriter = new StringBuilder();
        sbWriter = MakeExcelFile(pTable, true);

        _clsPage.Response.Clear();
        //_clsPage.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(pFileName) + "_" + _clsTypeUtil.GetNumString(_clsTypeUtil.GetDateStr()) + ".xls");
        _clsPage.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(pFileName).Replace("+", "%20") + ".xls");
        _clsPage.Response.ContentType = "application/vnd.xls";

        _clsPage.Response.Write(sbWriter.ToString());
        _clsPage.Response.End();
    }

    public void ExcelDownLoad(System.Data.DataTable pTable, string pFileName, bool pbTitle)
    {
        StringBuilder sbWriter = new StringBuilder();
        sbWriter = MakeExcelFile(pTable, pbTitle);

        _clsPage.Response.Clear();
        //_clsPage.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(pFileName) + "_" + _clsTypeUtil.GetNumString(_clsTypeUtil.GetDateStr()) + ".xls");
        _clsPage.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(pFileName).Replace("+", "%20") + ".xls");
        _clsPage.Response.ContentType = "application/vnd.xls";

        _clsPage.Response.Write(sbWriter.ToString());
        _clsPage.Response.End();
    }

    public void CSVDownLoad(DataSet pDSet)
    {
        CSVDownLoad(pDSet, "ExcelDown");
    }

    public void CSVDownLoad(DataSet pDSet, string pFileName)
    {
        System.Data.DataTable dt = new System.Data.DataTable();

        if (pDSet.Tables.Count > 0)
            dt = pDSet.Tables[0];

        CSVDownLoad(dt, pFileName);
    }

    public void CSVDownLoad(System.Data.DataTable pTable)
    {
        CSVDownLoad(pTable, "ExcelDown");
    }

    public void CSVDownLoad(System.Data.DataTable pTable, string pFileName)
    {
        StringBuilder sbWriter = new StringBuilder();
        sbWriter = MakeCSVFile(pTable);

        _clsPage.Response.Clear();
        //_clsPage.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(pFileName) + "_" + _clsTypeUtil.GetNumString(_clsTypeUtil.GetDateStr()) + ".xls");
        _clsPage.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(pFileName) + ".xls");
        _clsPage.Response.ContentType = "multipart/form-data";
        _clsPage.Response.Charset = "ks_c_5601-1987";

        _clsPage.Response.Write(sbWriter.ToString());
        _clsPage.Response.End();
    }

    private StringBuilder MakeCSVFile(System.Data.DataTable pTable)
    {
        StringBuilder sbWriter = new StringBuilder();
        const string CS_CHANGE_STR = "'";
        string sPrefix = "";

        // Header
        foreach (DataColumn dc in pTable.Columns)
        {
            sbWriter.Append(dc.ColumnName + Convert.ToChar(9));
        }
        sbWriter.AppendLine();

        // Contents
        foreach (DataRow dr in pTable.Rows)
        {
            foreach (object val in dr.ItemArray)
            {
                sPrefix = "";

                if (val.GetType() == System.Type.GetType("System.String"))
                {
                    if (IsAllNumber(val.ToString()))
                        sPrefix = CS_CHANGE_STR;
                }

                sbWriter.Append(sPrefix + val.ToString() + Convert.ToChar(9));
            }
            sbWriter.AppendLine();
        }

        return sbWriter;
    }

    private StringBuilder MakeExcelFile(System.Data.DataTable pTable, bool pbTitle)
    {
        string sLine = "";
        StringBuilder sbWriter = new StringBuilder();

        sbWriter.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\" >                          \n");
        sbWriter.Append("<HTML>                                                                                     \n");
        sbWriter.Append("  <HEAD>                                                                                   \n");
        sbWriter.Append("        <TITLE>ExcelDown</TITLE>                                                           \n");
        sbWriter.Append("                                                                                           \n");
        sbWriter.Append("        <META name=\"GENERATOR\" content=\"Microsoft Visual Studio .NET 7.1\">             \n");
        sbWriter.Append("        <META http-equiv=\"Content-Type\" content=\"text/html; charset=ks_c_5601-1987\">   \n");
        sbWriter.Append("        <META name=\"CODE_LANGUAGE\" content=\"C#\">                                       \n");
        sbWriter.Append("        <META name=vs_defaultClientScript content=\"JavaScript\">                          \n");
        sbWriter.Append("        <STYLE>                    \n");
        sbWriter.Append("            body{font-family:돋움, 새굴림, 굴림, Helvetica, Verdana;font-size: 9pt;color:black;}   \n");
        sbWriter.Append("            /* 목록조회 table */   \n");
        sbWriter.Append("            .TableStyle0 {border-collapse: collapse;}  \n");
        sbWriter.Append("            .TableStyle {border-top: 2px solid #9fbbd4;border-bottom: 1px solid #CED5E0;border-collapse: collapse;}    \n");
        sbWriter.Append("            .TableTitle {color: #657696;height:22px;font-weight:bold; PADDING:4 2 2 2;BACKGROUND-COLOR:#E8F1FB;text-align : center;border: 1px solid #CED5E0;} \n");
        sbWriter.Append("            .TableTitle2 {color: #586886;height:22px;PADDING:4 2 2 2;BACKGROUND-COLOR:#F4F8FC;text-align : center;border: 1px solid #CED5E0;}                  \n");
        sbWriter.Append("            .TableListA {height:22px;PADDING:1 5 0 5;BACKGROUND-COLOR:#ffffff; border : 1px solid #E7E7E7;border-collapse: collapse;}                          \n");
        sbWriter.Append("            .TableListB {height:22px;PADDING:1 5 0 5;BACKGROUND-COLOR:#F9F9F9; border : 1px solid #E7E7E7;border-collapse: collapse;}                          \n");
        sbWriter.Append("            .TableList_Gray {height:22px;PADDING:1 5 0 5;BACKGROUND-COLOR:#EEEEEE;border : 1px solid #E0E0E0;border-collapse: collapse;}                       \n");
        sbWriter.Append("            /* 셀 내에서 ALT + 엔터값 넣기 */                          \n");
        sbWriter.Append("            br{mso-data-placement:same-cell;}                          \n");
        sbWriter.Append("                                                                       \n");
        sbWriter.Append("            /* 엑셀파일 저장시 숫자형태의 필드를 문자로 변환 */        \n");
        sbWriter.Append("            .xls2text                                                  \n");
        sbWriter.Append("            {   mso-number-format:\"\\@\";                             \n");
        sbWriter.Append("                font-family:돋움, 새굴림, 굴림, Helvetica, Verdana;    \n");
        sbWriter.Append("                height:20px;                                           \n");
        sbWriter.Append("                font-size: 9pt;		                                \n");
        sbWriter.Append("                background-color: white;                               \n");
        sbWriter.Append("                border:.5pt solid silver;                              \n");
        sbWriter.Append("                color:black;		                                    \n");
        sbWriter.Append("                font-weight:normal;                                    \n");
        sbWriter.Append("            }                                                          \n");
        sbWriter.Append("                                                                       \n");
        sbWriter.Append("            .xls2textRight                                             \n");
        sbWriter.Append("            {   mso-number-format:\"\\@\";                             \n");
        sbWriter.Append("                font-family:돋움, 새굴림, 굴림, Helvetica, Verdana;    \n");
        sbWriter.Append("                height:20px;                                           \n");
        sbWriter.Append("                font-size: 9pt;		                                \n");
        sbWriter.Append("                background-color: white;                               \n");
        sbWriter.Append("                color:black;		                                    \n");
        sbWriter.Append("                font-weight:normal;                                    \n");
        sbWriter.Append("                text-align:right;                                      \n");
        sbWriter.Append("            }                                                          \n");
        sbWriter.Append("                                                                       \n");
        sbWriter.Append("            .exceltitle                                                \n");
        sbWriter.Append("            {                                                          \n");
        sbWriter.Append("                font-family:돋움, 새굴림, 굴림, Helvetica, Verdana;    \n");
        sbWriter.Append("                height:20px;                                           \n");
        sbWriter.Append("            	font-size: 9pt;		                                    \n");
        sbWriter.Append("            	background-color: #993366;                              \n");
        sbWriter.Append("            	color:white;		                                    \n");
        sbWriter.Append("                font-weight:bold;                                      \n");
        sbWriter.Append("                text-align:center;                                     \n");
        sbWriter.Append("            }                                                          \n");
        sbWriter.Append("                                                                       \n");
        sbWriter.Append("            .excelnoinput                                              \n");
        sbWriter.Append("            {                                                          \n");
        sbWriter.Append("                font-family:돋움, 새굴림, 굴림, Helvetica, Verdana;    \n");
        sbWriter.Append("                height:20px;                                           \n");
        sbWriter.Append("            	font-size: 9pt;		                                    \n");
        sbWriter.Append("            	background-color: #CCFFCC;                              \n");
        sbWriter.Append("            	color:black;		                                    \n");
        sbWriter.Append("            	font-weight:normal;                                     \n");
        sbWriter.Append("            }                                                          \n");
        sbWriter.Append("            .excelsecret                                               \n");
        sbWriter.Append("            {                                                          \n");
        sbWriter.Append("                font-family:돋움, 새굴림, 굴림, Helvetica, Verdana;    \n");
        sbWriter.Append("                height:20px;                                           \n");
        sbWriter.Append("            	font-size: 9pt;		                                    \n");
        sbWriter.Append("            	background-color: #CCFFCC;                              \n");
        sbWriter.Append("            	color:red;		                                        \n");
        sbWriter.Append("            	font-weight:normal;                                     \n");
        sbWriter.Append("            }                                                          \n");
        sbWriter.Append("            .excelsecret2                                              \n");
        sbWriter.Append("            {                                                          \n");
        sbWriter.Append("                font-family:돋움, 새굴림, 굴림, Helvetica, Verdana;    \n");
        sbWriter.Append("                height:20px;                                           \n");
        sbWriter.Append("            	font-size: 9pt;		                                    \n");
        sbWriter.Append("            	background-color: #CCFFCC;                              \n");
        sbWriter.Append("            	color:navy;		                                        \n");
        sbWriter.Append("            	font-weight:normal;                                     \n");
        sbWriter.Append("            }                                                          \n");
        sbWriter.Append("                                                                       \n");
        sbWriter.Append("            .excelinput                                                \n");
        sbWriter.Append("            {                                                          \n");
        sbWriter.Append("                font-family:돋움, 새굴림, 굴림, Helvetica, Verdana;    \n");
        sbWriter.Append("                height:20px;                                           \n");
        sbWriter.Append("            	font-size: 9pt;		                                    \n");
        sbWriter.Append("            	background-color: white;                                \n");
        sbWriter.Append("                border:.5pt solid silver;                              \n");
        sbWriter.Append("            	color:black;		                                    \n");
        sbWriter.Append("            	font-weight:normal;                                     \n");
        sbWriter.Append("            }                                                          \n");
        sbWriter.Append("                                                                       \n");
        sbWriter.Append("        </STYLE>                                                       \n");
        sbWriter.Append("    </HEAD>                                                            \n");
        sbWriter.Append("    <BODY>                                                             \n");
        sbWriter.Append("        <TABLE>                                                        \n");

        if (pbTitle)
        {
            // Secret Strings..
            sbWriter.Append("<TR><TD class=\"excelsecret2\">인쇄자 이름 : " + _UserInfo.Emp_Name + "</TD></TR>\n");
            //sbWriter.Append("<TR><TD class=\"excelsecret2\">인쇄자 부서 : " + _UserInfo.de + " </TD></TR>\n");
            sbWriter.Append("<TR><TD class=\"excelsecret2\">인쇄  시간 : " + _clsTypeUtil.GetDateStr() + "</TD></TR>\n");
            sbWriter.Append("<TR><TD></TD></TR>\n");
            sbWriter.Append("<TR><TD class=\"excelsecret\">▶ MicroBSC   </TD></TR>\n");
            //sbWriter.Append("<TR><TD class=\"excelsecret\">▶ MicroBSC에서 열람되는 모든 정보에 대한 소유권은 회사에 있습니다.       </TD></TR>\n");
            //sbWriter.Append("<TR><TD class=\"excelsecret\">▶ 따라서 사외로의 무단반출을 금하며, 위규자는 적절한 처벌을 받게 됩니다. </TD></TR>\n");
            //sbWriter.Append("<TR><TD class=\"excelsecret\">▶ 본 출력물의 조회이력은 보안규정에 의거, 시스템에 기록되고 있습니다.    </TD></TR>\n");
            sbWriter.Append("<TR><TD></TD></TR>\n");
        }

        sbWriter.Append("            <TR>       \n");
        sbWriter.Append("                <TD>   \n");
        sbWriter.Append("                   <TABLE border=\"1\">                                \n");
        sbWriter.Append("                       <TR  class=\"exceltitle\" align=\"center\">    \n");

        // Header
        foreach (DataColumn dc in pTable.Columns)
        {
            sbWriter.Append("<TD>" + dc.ColumnName + "</TD>");
        }

        sbWriter.Append("                     \n</TR>               \n");

        // Contents
        foreach (DataRow dr in pTable.Rows)
        {
            sbWriter.Append("                   <TR class=\"excelinput\">                                                               \n");
            foreach (object val in dr.ItemArray)
            {
                if (val.GetType() == System.Type.GetType("System.String"))
                    sLine += "<TD class=\"xls2text\">" + val.ToString() + "</TD>";
                else
                    //sLine += "<TD class=\"xls2textRight\">" + val.ToString() + "</TD>";
                    sLine += "<TD class=\"excelinput\">" + val.ToString() + "</TD>";

            }

            sbWriter.Append(sLine + "\n");
            sbWriter.Append("                   </TR>\n");

            sLine = "";
        }

        sbWriter.Append("                   </TABLE>    \n");
        sbWriter.Append("                </TD>  \n");
        sbWriter.Append("            </TR>      \n");

        sbWriter.Append("        </TABLE>                                                               \n");
        sbWriter.Append("    </BODY>\n");
        sbWriter.Append("</HTML>    \n");
        return sbWriter;
    }
    #endregion

    #region 기타함수
    //========================================
    // 파일다운로드
    //========================================
    public void FileDownLoad(string asFileName, string asFullPath)
    {
        if (!File.Exists(asFullPath))
        {
            AlertMessage("파일이 존재하지 않습니다!");
            return;
        }

        //Encoding enc = Encoding.UTF8;

        _clsPage.Response.Clear();
        //_clsPage.Response.AddHeader("User-Agent", "Mozilla/4.0 (compatible;MSIE 6.0; Windows XP)");
        _clsPage.Response.AddHeader("target", "_blank");
        _clsPage.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(asFileName).Replace("+", "%20"));
        _clsPage.Response.ContentType = "application/unknown";

        try
        {
            _clsPage.Response.WriteFile(asFullPath);

        }
        catch (Exception ex)
        {
            _clsPage.Response.Write("<script type='text/javascript'>alert('파일 다운로드 중 오류가 발생했습니다!');</script>");
        }

        _clsPage.Response.End();
    }

    //========================================
    // 파일복사
    //========================================
    //public void FileCopy(string asOrgFile, string asDestFile)
    //{
    //    string sFileName = System.Guid.NewGuid().ToString().Replace("-", "") + ".xls";
    //    string DestFilePath = @"E:\webTest\file\" + sFileName;
    //    System.IO.File.Copy(asOrgFile, asDestFile, true);
    //}


    public string GetValue(object aObj)
    {
        if (aObj == null)
            return "";

        return aObj.ToString().Replace("&nbsp;", "").Trim();
    }

    // 전체문자열이 숫자형인지 검사한다. 
    public bool IsAllNumber(string asStr)
    {
        if (asStr == "")
        {
            return false;
        }

        char[] caStr = asStr.ToCharArray();

        return (_clsTypeUtil.GetNumString(asStr).Length == caStr.GetLength(0));
    }

    // 검색수 처리시 화면 보임처리
    public string GetGridItemCount(int aiCount)
    {
        string sRet = string.Format(
                                    "<img align='absmiddle' src='{0}' /><span style='padding-top:10px'>{1}</span>\n"
                                  + "<img align='absmiddle' src='{2}' />"
                                  , "/Images/etc/lis_t01.gif"
                                  , aiCount.ToString("#,##0")
                                  , "/Images/etc/lis_t02.gif"
                                   );

        return sRet;
    }

    public string GetGridItemCount(UltraWebGrid aWebGrid)
    {
        return GetGridItemCount(aWebGrid.Rows.Count);
    }

    public string GetGridItemCount(GridView aGV)
    {
        return GetGridItemCount(aGV.Rows.Count);
    }

    public string GetValueLimit(string asStr, int aiLimit)
    {
        string sRet = asStr;

        if (asStr.Length > aiLimit)
            sRet = (asStr.Substring(0, aiLimit) + "...");

        return sRet;
    }

    public string GetNumStringForSpliter(int startNum, int lastNum, string spliter) 
    {
        bool isFirst    = true;
        string temp     = "";

        for (int i = startNum; i <= lastNum; i++) 
        {
            if (isFirst)
            {
                isFirst = false;

                temp += i.ToString();
            }
            else 
            {
                temp += spliter + i.ToString();
            }
        }

        return temp;
    }

    public string GetHtmlEncodeChar(string asStr)
    {
        if (asStr == null)
        {
            return "";
        }
        //asStr = asStr.Replace(";", "&#59;");
        asStr = asStr.Replace("&", "&#38;");
        asStr = asStr.Replace("\\", "");
        asStr = asStr.Replace(" ", "&nbsp;");
        asStr = asStr.Replace("\"", "&#34;");
        asStr = asStr.Replace("(", "&#40;");
        asStr = asStr.Replace(")", "&#41;");
        asStr = asStr.Replace("'", "");
        asStr = asStr.Replace("\r\n", "<br />");
        

        return asStr;
    }

    public string GetReplicateString(string str, int count) 
    {
        return GetReplicateString(str, count, "");
    }

    public string GetReplicateString(string str, int count, string betweenStr) 
    {
        bool isFirst = true;
        string temp = "";

        for (int i = 0; i < count; i++)
        {
            if (isFirst)
            {
                isFirst = false;
                temp += str;
            }
            else 
            {
                temp += betweenStr + str;
            }
        }

        return temp;
    }

    public void GetWord(System.Web.UI.WebControls.Panel pnl, string fileName)
    {
        //string fileName     = fileName;
        System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-word";
        System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
        System.Web.HttpContext.Current.Response.Charset     = "euc-kr";
        pnl.EnableViewState = true;

        System.IO.StringWriter tw       = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        pnl.RenderControl(hw);
        String convStr                  = tw.ToString();
        convStr                         = System.Text.RegularExpressions.Regex.Replace(convStr, "&nbsp;", " ");

        System.Web.HttpContext.Current.Response.Write(convStr);
        System.Web.HttpContext.Current.Response.End();
    }


    #endregion

    #region 메일링 함수
    public bool CheckMailAddress(string sMailAdd)
    {
        if (sMailAdd.IndexOf('@') == -1)
        {
            return false;
        }

        string[] arrDomain = sMailAdd.Split('.');
        if (arrDomain.Length < 2)
        {
            return false;
        }

        return true;
    }

    public void SendMail(string[,] asaInfo, string asFromMail, string asToMail, string asSubTitle, BSC_SendMailType enType)
    {
        System.Web.Mail.MailMessage mail    = new System.Web.Mail.MailMessage();

        string sSubTitle                    = "";
        string sContent                     = "";

        sContent                            = GetFileContent(asaInfo, enType, out sSubTitle);

        mail.From                           = GetAppConfig("Mail.From");
        mail.To                             = asToMail;
        mail.Subject                        = sSubTitle;

        mail.Body                           = sContent;
        mail.BodyFormat                     = System.Web.Mail.MailFormat.Html;
        mail.BodyEncoding                   = System.Text.Encoding.Default;

        System.Web.Mail.SmtpMail.SmtpServer = GetAppConfig("Mail.SMTP");

        try
        {
            System.Web.Mail.SmtpMail.Send(mail);
        }
        catch
        {

        }

    }

    public string GetFileContent(string[,] asaInfo, BSC_SendMailType enType, out string osSubTitle)
    {
        string sResult = "";
        osSubTitle = "";

        Biz_App_Code_PageUtility biz = new Biz_App_Code_PageUtility();
        sResult = biz.GetMailContent(asaInfo, enType, out osSubTitle);

        return sResult;
    }

    /// <summary>
    /// 메일 내용 Parsing
    /// </summary>
    /// <param name="asFileName">메일템플릿파일</param>
    /// <param name="dtParam">치환 파라미터</param>
    /// <returns></returns>
    public string GetMailContent(string asFileName, System.Data.DataTable dtParam)
    {
        string sRet = "";
        string sFilePath = GetAppConfig("Mail.Template") + asFileName;

        try
        {
            System.IO.StreamReader stream = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath(sFilePath), System.Text.Encoding.Default);
            sRet = stream.ReadToEnd();
            stream.Close();

            int iRow = dtParam.Rows.Count;
            string sKey = "";
            string sVal = "";
            for (int i = 0; i < iRow; i++)
            {
                sKey = dtParam.Rows[i]["KEY"].ToString();
                sVal = dtParam.Rows[i]["VAL"].ToString();

                sRet = sRet.Replace(sKey, sVal);
            }
        }
        catch (Exception e)
        {
            sRet = e.Message;
        }

        return sRet;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dtParam"></param>
    /// <param name="asFromMail"></param>
    /// <param name="asToMail"></param>
    /// <param name="sTitle"></param>
    /// <param name="asFileName"></param>
    public bool SendMail(System.Data.DataTable dtParam, string asFromMail, string asToMail, string sTitle, string asFileName)
    {
        System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();

        string sFilePath = GetAppConfig("Mail.Template") + asFileName;
        string sContent  = "";

        sContent = GetMailContent(asFileName, dtParam);

        mail.From    = asFromMail;
        mail.To      = asToMail;
        mail.Subject = sTitle;

        mail.Body         = sContent;
        mail.BodyFormat   = System.Web.Mail.MailFormat.Html;
        mail.BodyEncoding = System.Text.Encoding.Default;

        System.Web.Mail.SmtpMail.SmtpServer = GetAppConfig("Mail.SMTP");

        try
        {
            System.Web.Mail.SmtpMail.Send(mail);
            return true;
        }
        catch 
        {
            return false;
        }

    }

    public void SendMail(string sTitle, string sContent, string asFromMail, string asToMail)
    {
        System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();

        mail.From         = asFromMail;
        mail.To           = asToMail;
        mail.Subject      = sTitle;

        mail.Body         = sContent;
        mail.BodyFormat   = System.Web.Mail.MailFormat.Html;
        mail.BodyEncoding = System.Text.Encoding.Default;

        System.Web.Mail.SmtpMail.SmtpServer = GetAppConfig("Mail.SMTP");

        try
        {
            System.Web.Mail.SmtpMail.Send(mail);
        }
        catch (Exception e)
        {
            
        }
    }

    public bool LogSendedMail(string asTermRefID, string asEmpRefID, string asFromMail, string asToMail, string asSubject, string asContent, string asGIdx, string asMailType)
    {
        SendLog sendLog = new SendLog();
        return sendLog.LogMaker(asTermRefID, asEmpRefID, asFromMail, asToMail, asSubject, asContent, asGIdx, asMailType);
    }

    public bool LogSendedMail(string asTermRefID, string asEmpRefID, string asFromMail, string asToMail, string asSubject, string asContent, string asMailType)
    {
        return LogSendedMail(asTermRefID, asEmpRefID, asFromMail, asToMail, asSubject, asContent, "0", asMailType);
    }

    public bool LogSendedMail(string asTermRefID, string asEmpRefID, string asFromMail, string asToMail, string asSubject, string asContent)
    {
        return LogSendedMail(asTermRefID, asEmpRefID, asFromMail, asToMail, asSubject, asContent, "0", "K");
    }
    #endregion

    #region

    public void SelectTreeNode(TreeView treeView, string value)
    {
        foreach (TreeNode treeNode in treeView.Nodes)
        {
            if (treeNode.Value == value)
            {
                treeNode.Select();
                return;
            }

            SelfFind(treeNode.ChildNodes, value);
        }
    }

    private void SelfFind(TreeNodeCollection nodeCol, string value)
    {
        foreach (TreeNode treeNode in nodeCol)
        {
            if (treeNode.Value == value)
            {
                treeNode.Select();
                return;
            }

            SelfFind(treeNode.ChildNodes, value);
        }
    }

    public int SetTopEstDeptRefID(TreeView treeView)
    {
        foreach (TreeNode treeNode in treeView.Nodes)
        {
            if (treeNode.SelectAction == TreeNodeSelectAction.Select || treeNode.SelectAction == TreeNodeSelectAction.SelectExpand)
            {
                return int.Parse(treeNode.Value);
            }

            int value = SelfFindEstDeptRefID(treeNode.ChildNodes);

            if (value > 0)
                return value;
        }

        return 0;
    }

    private int SelfFindEstDeptRefID(TreeNodeCollection nodeCol)
    {
        foreach (TreeNode treeNode in nodeCol)
        {
            if (treeNode.SelectAction == TreeNodeSelectAction.Select || treeNode.SelectAction == TreeNodeSelectAction.SelectExpand)
            {
                return int.Parse(treeNode.Value);
            }

            int value = SelfFindEstDeptRefID(treeNode.ChildNodes);

            if (value > 0)
                return value;
        }

        return 0;
    }

    public bool IsContainSystemAdminUser(int emp_ref_id)
    {
        string[] users = ConfigurationManager.AppSettings["Page.FirstPageUser"].ToString().Split(';');

        for (int i = 0; i < users.Length; i++)
        {
            if (users[i].Equals(emp_ref_id.ToString()))
                return true;
        }

        return false;
    }

    public bool IsContainSMGUser(int emp_ref_id)
    {
        string[] users = ConfigurationManager.AppSettings["Page.SMGPageUser"].ToString().Split(';');

        for (int i = 0; i < users.Length; i++)
        {
            if (users[i].Equals(emp_ref_id.ToString()))
                return true;
        }

        return false;
    }
    public string ReplicationStr(string copyStr, int count)
    {
        string temp = "";

        for (int i = 0; i < count; i++)
        {
            temp = temp + copyStr;
        }

        return temp;
    }

    public DataSet FilterSortData(DataSet dsStart, int iTbl, string filter, string sort)
    {
        System.Data.DataTable dt = dsStart.Tables[iTbl].Clone();
        DataRow[] drs   = dsStart.Tables[iTbl].Select(filter, sort);

        foreach (DataRow dr in drs)
        {
            dt.ImportRow(dr);
        }

        DataSet ds = new DataSet();

        for (int i = 0; i < dsStart.Tables.Count; i++)
        {
            if (i == iTbl)
            {
                ds.Tables.Add(dt);
            }
            else
            {
                ds.Tables.Add(dsStart.Tables[i].Copy());
            }
        }

        return ds;
    }

    public DataSet FilterSortData(DataSet dsStart, string filter, string sort)
    {
        DataSet ds      = dsStart.Clone();
        DataRow[] drs   = dsStart.Tables[0].Select(filter, sort);

        foreach (DataRow dr in drs)
        {
            ds.Tables[0].ImportRow(dr);
        }

        return ds;
    }

    public System.Data.DataTable FilterSortData(System.Data.DataTable dtStart, string filter, string sort)
    {
        System.Data.DataTable dt    = dtStart.Clone();
        DataRow[] drs               = dtStart.Select(filter, sort);

        foreach (DataRow dr in drs)
        {
            dt.ImportRow(dr);
        }

        return dt;
    }

    public object GetOutputParameterValue(IDataParameterCollection col, string parameterName, CommandType cmdType)
    {
        return DbAgentHelper.GetOutputParameterValue(col, parameterName, cmdType);
    }

    public object GetOutputParameterValue(IDataParameterCollection col, string parameterName)
    {
        return DbAgentHelper.GetOutputParameterValue(col, parameterName, CommandType.Text);
    }

    #endregion
}
