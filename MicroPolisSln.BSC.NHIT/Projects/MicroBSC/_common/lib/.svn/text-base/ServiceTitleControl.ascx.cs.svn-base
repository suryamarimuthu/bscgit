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

public partial class _common_lib_ServiceTitleControl : System.Web.UI.UserControl
{
    public String ASPXcode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPXcode = Request.Url.ToString().Substring(Request.Url.ToString().LastIndexOf("/") + 1, 7);
        this._ViewTitle(ASPXcode);
    }
    protected void _ViewTitle(String ASPXcode)
    {
        TitleImage.Text = @"<table width='100%' border='0' cellpadding='0' cellspacing='0'>
                <tr>
                    <td width='15' height='27'>&nbsp;</td>
                    <td width='25'><img src='../images/icon/mtt_icon01.gif'></td>
                    <td><strong>";

        if (ASPXcode.ToLower().StartsWith("svr1")) { TitleImage.Text = TitleImage.Text + "전략풀"; }//전략풀
        else if (ASPXcode.ToLower().StartsWith("svr2")) { TitleImage.Text = TitleImage.Text + "KPI풀"; }//KPI풀
        else if (ASPXcode.ToLower().StartsWith("svr30")) { TitleImage.Text = TitleImage.Text + "전략체계도"; }//전략체계도
        else if (ASPXcode.ToLower().StartsWith("svr30")) { TitleImage.Text = TitleImage.Text + "전략지표체계도"; }//전략지표체계도
        else if (ASPXcode.ToLower().StartsWith("svr31")) { TitleImage.Text = TitleImage.Text + "전략지표체계도"; }//전략지표체계도
        else if (ASPXcode.ToLower().StartsWith("svr32")) { TitleImage.Text = TitleImage.Text + "전략지표체계도"; }//전략지표체계도
        else if (ASPXcode.ToLower().StartsWith("svr4")) { TitleImage.Text = TitleImage.Text + "실적관리"; }//실적관리
        else if (ASPXcode.ToLower().StartsWith("usr1")) { TitleImage.Text = TitleImage.Text + "전략분석"; }//전략분석
        else if (ASPXcode.ToLower().StartsWith("usr2")) { TitleImage.Text = TitleImage.Text + "KPI 분석"; }//성과지표분석
        else if (ASPXcode.ToLower().StartsWith("eis")) { TitleImage.Text = TitleImage.Text + "주요 경영 지표 분석"; }//주요항목분석
        else if (ASPXcode.ToLower().StartsWith("usr4")) { TitleImage.Text = TitleImage.Text + "주요 경영 지표 상세분석"; }//실적상세분석
        else if (ASPXcode.ToLower().StartsWith("est0")) { TitleImage.Text = TitleImage.Text + "성과 평가"; }//조직업적
        else if (ASPXcode.ToLower().StartsWith("est11")) { TitleImage.Text = TitleImage.Text + "조직업적"; }//조직업적
        else if (ASPXcode.ToLower().StartsWith("est120")) { TitleImage.Text = TitleImage.Text + "정성평가"; }//정성평가
        else if (ASPXcode.ToLower().StartsWith("est121")) { TitleImage.Text = TitleImage.Text + "임원조정평가"; }//임원조정평가
        else if (ASPXcode.ToLower().StartsWith("est13")) { TitleImage.Text = TitleImage.Text + "업적평가점수산출"; }//업적평가점수산출
        else if (ASPXcode.ToLower().StartsWith("est21")) { TitleImage.Text = TitleImage.Text + "역량평가"; }//역량평가
        else if (ASPXcode.ToLower().StartsWith("est22")) { TitleImage.Text = TitleImage.Text + "역량평가BIAS 조정"; }//역량평가BIAS 조정
        else if (ASPXcode.ToLower().StartsWith("est23")) { TitleImage.Text = TitleImage.Text + "역량평가점수산출"; }//역량평가점수산출
        else if (ASPXcode.ToLower().StartsWith("est31")) { TitleImage.Text = TitleImage.Text + "업적평가등급산출"; }//업적평가등급산출
        else if (ASPXcode.ToLower().StartsWith("est32")) { TitleImage.Text = TitleImage.Text + "역량평가등급산출"; }//역량평가등급산출
        else if (ASPXcode.ToLower().StartsWith("est33")) { TitleImage.Text = TitleImage.Text + "성과평가등급산출"; }//성과평가등급산출
        else if (ASPXcode.ToLower().StartsWith("ctl11")) { TitleImage.Text = TitleImage.Text + "성과평가기간관리"; }//성과평가기간관리
        else if (ASPXcode.ToLower().StartsWith("ctl12")) { TitleImage.Text = TitleImage.Text + "평가기준관리"; }//평가기준관리
        else if (ASPXcode.ToLower().StartsWith("ctl13")) { TitleImage.Text = TitleImage.Text + "피평가자관리"; }//피평가자관리
        else if (ASPXcode.ToLower().StartsWith("ctl14")) { TitleImage.Text = TitleImage.Text + "평가질의 관리"; }//피평가자관리
        else if (ASPXcode.ToLower().StartsWith("ctl21")) { TitleImage.Text = TitleImage.Text + "조직관리"; }//조직관리
        else if (ASPXcode.ToLower().StartsWith("ctl21")) { TitleImage.Text = TitleImage.Text + "사원관리"; }//사원관리
        else if (ASPXcode.ToLower().StartsWith("ctl22")) { TitleImage.Text = TitleImage.Text + "결제선관리"; }//결제선관리
        else if (ASPXcode.ToLower().StartsWith("ctl23")) { TitleImage.Text = TitleImage.Text + "평가조직관리"; }//평가조직관리
        else if (ASPXcode.ToLower().StartsWith("ctl31")) { TitleImage.Text = TitleImage.Text + "메뉴권한 관리"; }//시스템권한관리
        else if (ASPXcode.ToLower().StartsWith("ctl32")) { TitleImage.Text = TitleImage.Text + "평가권한관리"; }//평가권한관리
        else if (ASPXcode.ToLower().StartsWith("ctl41")) { TitleImage.Text = TitleImage.Text + "시스템 정보"; }//시스템 정보
        else if (ASPXcode.ToLower().StartsWith("ctl42")) { TitleImage.Text = TitleImage.Text + "DB 정보"; }//DB 정보
        else if (ASPXcode.ToLower().StartsWith("com1")) { TitleImage.Text = TitleImage.Text + "KPI 실적 마감율"; }//KPI 실적 마감율

        else if (ASPXcode.ToLower().StartsWith("svr0")) { TitleImage.Text = TitleImage.Text + "전략 및 KPI 관리 Process Flow "; }//DB 정보
        else if (ASPXcode.ToLower().StartsWith("est1")) { TitleImage.Text = TitleImage.Text + "업적평가 Process Flow "; }//DB 정보
        else if (ASPXcode.ToLower().StartsWith("est2")) { TitleImage.Text = TitleImage.Text + "역량평가 Process Flow "; }//DB 정보
        else if (ASPXcode.ToLower().StartsWith("est3")) { TitleImage.Text = TitleImage.Text + "종합 평가 Process Flow "; }//DB 정보

        else { TitleImage.Text = "&nbsp;"; }//

        //if (TitleImage.Text.Length > 0)
        
        TitleImage.Text += @"</strong></td></tr></table>";

    }
}
