<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC_INTRO2.aspx.cs" Inherits="BSC_INTRO2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">


<link href="../_common/css/Intro.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    
    body{margin:0;padding:0;}
    div,p,ul,li{margin:0;padding:0;font-family:"dotum";font-size:12px;color:#747474;}
    img{border:none;}
    a{text-decoration:none;}
    li{list-style:none}
    input{border:1px solid #DFDFDF;font-family:dotum;font-size:12px;color:#666666;}
    .mywork{position:relative;top:48px;left:18px;}
    .mywork li{position:relative;float:left;margin-left:-12px;}

    .mykpi{float:left;width:397px;margin:0px 0px 0px 27px;border-bottom:2px solid #e4e5e7;}
    .mykpi span{width:132px;display:inline-block;vertical-align:middle;font-size:11px;font-weight:bold;color:#a7a7a7;}
    .span{width:132px;display:inline-block;vertical-align:middle;font-size:11px;font-weight:bold;color:#a7a7a7;}
    .span1{font-size:12px;color:#747474;}
    .fcols{color: #8fc9fa;}
    .fcola{color: #6fe1e0;}
    .fcolb{color: #a8f620;}
    .fcolc{color: #f6c739;}
    .fcold{color: #fb7716;}
    .fcolu{color: #b8b8b8;}
    .fcols2{color: #5983d3;}
    .fcola2{color: #59d3cd;}
    .fcolb2{color: #81d359;}
    .fcolc2{color: #f9d832;}
    .fcold2{color: #f99532;}
    .mykpi img{vertical-align:middle;}
    .mykpi li{border-bottom:1px solid #ebeef1;}
    .score{float:left;width:297px;height:110px;background:url(../images/Intro/back_blackscore.gif);margin:0px 0px 0px 20px;}
    .score1{position:relative;top:42px;height:50px; padding-top:4px; left:7px;width:82px;text-align:center;display:inline-block;color:#ffa200;font-family:"verdana";font-size:34px;font-weight:bold;}
    .score2{position:relative;top:42px;height:50px; padding-top:4px;left:30px;width:82px;text-align:center;display:inline-block;color:#fdff33;font-family:"verdana";font-size:34px;font-weight:bold;}
    .score3{position:relative;top:42px;height:50px; padding-top:4px;left:32px;width:82px;text-align:center;display:inline-block;color:#a8f620;font-family:"verdana";font-size:34px;font-weight:bold;}
    .name1{position:relative;top:33px;left:7px;width:82px;text-align:center;display:inline-block;font-size:11px;}
    .name2{position:relative;top:33px;left:30px;width:82px;text-align:center;display:inline-block;font-size:11px;}
    .name3{position:relative;top:33px;left:35px;width:82px;text-align:center;display:inline-block;font-size:11px;}
    .notice{float:left;width:404px;margin:0px 0px 0px 21px;border-bottom:2px solid #e4e5e7;}
    .notice li{padding:5px 0px 0px 0px;}
    .notice .not1{display:inline-block;width:270px;}
    .notice .not2{display:inline-block;width:65px;text-align:center;}
    .notice .not3{display:inline-block;width:64px;text-align:center;font-weight:bold;color:#a7a7a7;}
    .notice a{color:#747474;}
    .notice a:hover{color:#5f92dd;}
    .faq{float:left;width:297px;margin:0px 0px 0px 20px;}
    .faq ul{width:280px;padding:11px 8px 8px 2px;}
    .faq li{padding:3px 0px 2px 0px;}
    .faq a{color:#747474;}
    .faq a:hover{color:#5f92dd;}
    .kpi_0{float:left;width:335px; height:111px; margin:0px 0px 0px 20px;border:2px solid #cad5e7;}
    .kpi_1{float:left;width:109px;height:105px;margin:1px 0px 1px 2px;background:url('../images/Intro/back_blackscore1.gif') no-repeat;}
    .kpi_1_1{text-align:center;font-family:"verdana";font-size:40px;font-weight:bold;margin-top:33px;}
    .kpi_1_2{text-align:center;font-size:11px;font-weight:bold;margin-top:33px;}
    .kpi_2{float:left;width:210px; height:105px;margin:1px 0px 1px 4px;border-bottom:1px solid #ccc;}
    .kpi_3{float:left;width:370px; height:111px; margin:0px 0px 0px 17px;border:2px solid #cad5e7;}
    .kpi_3_2{width:95px;text-align:right;font-family:verdana;font-weight:bold;font-size:16px;}
    .kpi_3_R{text-align:right;height:13px;font-weight:bold;color:#000;background:url(../images/Intro/back_gr_R.gif);padding-top:2px;}
    .kpi_3_B{text-align:right;height:13px;font-weight:bold;color:#000;background:url(../images/Intro/back_gr_B.gif);padding-top:2px;}
    .progress
    {
        position:absolute;
        top:200px;
        left:300px;
        width:82px;
        text-align:center;
        display:inline-block;
        font-size:11px;
    }

</style>
<script language="javascript" type="text/javascript" >

    function doLinkingUrl() {
        var url = "<%=KPI_URL %>";

        document.location.href = url;

        return false;

    }

    function doMovingPage(no) {

        //document.getElementById("divProgress").style.display = "";
        //var url1 = "BSC0408S2.ASPX";
        var url1 = "<%=KPI_URL %>";
        var url2 = "../dashboard/nhit_org_pri_rank.aspx";
        var url3 = "../dashboard/NHIT_Main_1280_new.aspx";

        var link = url1;
        if (no == "1") {
            link = url1;
        }
        
        if (no == "2") {
            link = url2;
        }
        
        if (no == "3") {
            link = url3;
        }
        
        document.location.href = link;

        return false;

    }

    function doPoppingUp_Org() {

        //var url = "BSC_INTRO2_M1.aspx";
        var url = "BSC_INTRO2_M2.aspx";

        gfOpenWindow(url, 960, 720, "NO", "NO", 'doPoppingUp_Org');

        return false;

    }

    function DblClickHandler_Faq(id) {
        var strURL = '../BSC/BSC0705M2.aspx?iTYPE=U&FAQ_REF_ID=' + id;

        gfOpenWindow(strURL, 823, 540, 'BSC0705M1U');
    }
    function DblClickHandler_Notice(id) {
        var strURL = '../BSC/BSC0704M2.aspx?iTYPE=U&NOTICE_REF_ID=' + id;

        gfOpenWindow(strURL, 823, 540, 'BSC0704M2U');
    }

</script>

<table border"0" cellpadding="0" cellspacing="0" width="100%" height="1%">
    <tr>
        <td>
            
            <%-- bsc 일정--%>
            <div style="width:1000px;">
<%--                <div style="float:left;width:425px;">
                    <img src="../images/Intro/back_intro_1_1.jpg" usemap="#mykpi"/>
                </div>
		        <map name="mykpi">
		            <area shape="rect" coords="92,200,130,216" href="#" onclick="doLinkingUrl()">
		        </map>--%>
		        <div style="float:left;width:425px;">
                    <img alt="" src="../images/Intro/back_intro_1_1.jpg" />
                </div>

                <div style="float:left;width:499px;height:220px;background:url(../images/Intro/back_intro_2.jpg);">
	                <div class="mywork">
		                <ul style="margin-left:15px;">
			                <li><img src="../images/Intro/mywork.png"/></li>
			                <li style="z-index:99"><asp:ImageButton ID="btn1" runat="server" 
			                    ImageUrl="../images/Intro/mywork1_off.png" OnClick="iBtn1_Click" /></li>
                            <li style="z-index:98"><asp:ImageButton ID="btn2" runat="server"  
                                    ImageUrl="../images/Intro/mywork2_off.png" onclick="btn2_Click"/></li>
                            <li style="z-index:97"><asp:ImageButton ID="btn3" runat="server"  
                                    ImageUrl="../images/Intro/mywork3_off.png" onclick="btn3_Click"/></li>
                            <li style="z-index:96"><asp:ImageButton ID="btn4" runat="server"  
                                    ImageUrl="../images/Intro/mywork4_off.png" onclick="btn4_Click"/></li>
		                </ul>
	                </div>
		            <div style="position:relative;top:57px;left:18px;width:479px;height:109px; 
		                    border-bottom:solid 2px #b0c4dc;">
			            <ig:UltraWebGrid ID="ugrdSCHD" runat="server" Width="100%" Height="100%" 
                                 OnInitializeRow="ugrdSCHD_InitializeRow" 
                                 OnInitializeLayout="ugrdSCHD_InitializeLayout" >
                            <Bands>
                                <ig:UltraGridBand ColHeadersVisible="NotSet">
                                    <Columns>
                                        <ig:TemplatedColumn BaseColumnName="schd_mid" EditorControlID="" FooterText=""
                                            Format="" HeaderText="업무" Key="schd_mid" Width="30%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="업무">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left" CssClass="span1">
                                            </CellStyle>
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                         <ig:TemplatedColumn BaseColumnName="schd_mid_desc" EditorControlID="" FooterText=""
                                            Format="" HeaderText="업무설명" Key="schd_mid_desc" Width="50%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="업무설명">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left" CssClass="span1">
                                            </CellStyle>
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                         <ig:TemplatedColumn BaseColumnName="schd_end_date" EditorControlID="" FooterText=""
                                            Format="" HeaderText="일정" Key="schd_end_date" Width="20%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="일정">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Center" CssClass="span1">
                                            </CellStyle>
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                         <ig:TemplatedColumn BaseColumnName="link_dir" EditorControlID="" FooterText=""
                                            Format="" HeaderText="일정" Key="link_dir" Hidden="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="일정">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                         <ig:TemplatedColumn BaseColumnName="link_page_name" EditorControlID="" FooterText=""
                                            Format="" HeaderText="일정" Key="link_page_name" Hidden="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="일정">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                        
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>

                            <DisplayLayout  CellPaddingDefault="2"
                                            AllowColSizingDefault="Free"
                                            AllowColumnMovingDefault="OnServer"
                                            AllowDeleteDefault="Yes"
                                            AllowSortingDefault="Yes"
                                            BorderCollapseDefault="Separate" 
                                            HeaderClickActionDefault="SortMulti"
                                            Name="ugrdSCHD"
                                            RowHeightDefault="20px"
                                            RowSelectorsDefault="No"
                                            SelectTypeRowDefault="Extended"
                                            Version="4.00"
                                            CellClickActionDefault="RowSelect"
                                            TableLayout="Fixed"
                                            StationaryMargins="Header"
                                            ReadOnly="LevelTwo"
                                            AutoGenerateColumns="False">
                               
                                
                                <GroupByBox>
                                    <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                                </GroupByBox>
                                <HeaderStyleDefault CssClass="GridHeaderStyleIntro" ></HeaderStyleDefault>                                   
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                <RowStyleDefault  CssClass="GridRowStyleIntro" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                          
                                <FrameStyle CssClass="GridFrameStyleIntro" Width="100%" Height="100%" ></FrameStyle>
                                <ClientSideEvents DblClickHandler="UltraWebGrid1_DblClickHandler" />

                                </DisplayLayout>
                        </ig:UltraWebGrid>

		            </div>
	            </div>
             </div>

            <%--컨텐츠영역--%>
<div style="width:1000px;clear:both;padding-top:10px;">
    <div class="kpi_0" style="cursor:pointer;" onclick="return doMovingPage('1');">
	    <div class="kpi_1" style="cursor:pointer;" >
		    <%--<div class="kpi_1_1"><a href="../BSC/BSC0408S2.aspx"><asp:label ID="lblTEAMscore" runat="server" Text="0" style="color:#a8f620" ></asp:label></a></div>--%>
		    <div class="kpi_1_1"><asp:label ID="lblTEAMscore" runat="server" Text="0" ></asp:label></div>
		    <div class="kpi_1_2"><asp:label ID="lblTEAMname" runat="server" Text=""></asp:label></div>
	    </div>
	    <div class="kpi_2">
		    <div><img src="../images/Intro/bar_kpi.gif"/></div>
		    <div style="height:3px;cursor:pointer;">
		    <%--<div style="height:3px;cursor:pointer;" onclick="return doPoppingUp_Org();">--%>
                <ig:UltraWebGrid ID="ugrdRank" runat="server" Width="100%" Height="100px" 
                             OnInitializeRow="ugrdRank_InitializeRow" 
                             OnInitializeLayout="ugrdRank_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand ColHeadersVisible="No">
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn BaseColumnName="RANK_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="순위" Key="RANK_ID" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="순위">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center" Font-Bold="True" Font-Size="11px" 
                                    ForeColor="Silver" CssClass="span">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>
                               <ig:TemplatedColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="부서" Key="DEPT_NAME" Width="125px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="부서">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="11px" 
                                    ForeColor="Silver" CssClass="span">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>
    <%--         팀에서 본부로 변경,팀 사용시 활성화                  <ig:TemplatedColumn BaseColumnName="SCORE_TS" EditorControlID="" FooterText=""
                                    Format="" HeaderText="등급" Key="SCORE_TS" Width="35px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="등급">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="11px" 
                                    ForeColor="Silver" CssClass="span">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>--%>
                                 <ig:TemplatedColumn BaseColumnName="TS_SCORE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="등급" Key="TS_SCORE" Width="35px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="등급">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="11px" 
                                    ForeColor="Silver" CssClass="span">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>
                               <ig:TemplatedColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Width="132px" Hidden="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="ESTTERM_REF_ID">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="11px" 
                                    ForeColor="Silver" CssClass="span">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>
                               <ig:TemplatedColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                                    Format="" HeaderText="YMD" Key="YMD" Width="132px" Hidden="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="YMD">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="11px" 
                                    ForeColor="Silver" CssClass="span">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>
                               <ig:TemplatedColumn BaseColumnName="EST_DEPT_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="EST_DEPT_REF_ID" Key="EST_DEPT_REF_ID" Width="132px" Hidden="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="EST_DEPT_REF_ID">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="11px" 
                                    ForeColor="Silver" CssClass="span">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>
                              
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>

                    <DisplayLayout  CellPaddingDefault="2"
                                    AllowColSizingDefault="Free"
                                    AllowColumnMovingDefault="OnServer"
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes"
                                    BorderCollapseDefault="Separate" 
                                    HeaderClickActionDefault="SortMulti"
                                    Name="ugrdRank"
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No"
                                    SelectTypeRowDefault="Extended"
                                    Version="4.00"
                                    CellClickActionDefault="RowSelect"
                                    TableLayout="Fixed"
                                    StationaryMargins="Header"
                                                                    ReadOnly="LevelTwo"
                                    AutoGenerateColumns="False">
                       
                        
                        <GroupByBox>
                            <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyleIntro" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                  
                        <FrameStyle CssClass="GridFrameStyleIntro" Width="100%" Height="80px" ></FrameStyle>
                     
                    </DisplayLayout>
                </ig:UltraWebGrid>
		    </div>
    		
	    </div>
    </div>	
    <div class="kpi_3" style="cursor:pointer;" onclick="return doMovingPage('3');">
	    <div><img src="../images/Intro/bar_kpi2.gif"/></div>
	    <div style="padding:0px 0px; background:url(../images/Intro/back_score.gif); ">
		
	        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top:3px;">
		        <tr>
			        <td style="width:80px;height:24px; color:#f85607;"><img src="../images/Intro/icon_k2.gif">매출액</td>
			        <td class="kpi_3_2">
                        <asp:Label ID="amt1" runat="server" Text="0" style="color:#f85607"></asp:Label>
                    </td>
			        <td style="width:170px;padding:0px 10px 0px 10px;">
			            <div class="kpi_3_R"  id="ratediv1" runat="server" style="width:1%">
			                 <asp:Label ID="rate1" runat="server" Text="100" ></asp:Label>%
			                </div>
			        </td>
		        </tr>
		        <tr>
			        <td style="width:80px;height:24px; color:#3b87dd;"><img src="../images/Intro/icon_k2.gif">영업이익</td>
			        <td class="kpi_3_2">
			            <asp:Label ID="amt2" runat="server" Text="0" style="color:#3b87dd"></asp:Label>
			        </td>
			        <td style="width:170px;padding:0px 10px 0px 10px;">
			            <div class="kpi_3_B"   id="ratediv2" runat="server" style="width:100%">
			                <asp:Label ID="rate2" runat="server" Text="100" ></asp:Label>%</div>
			        </td>
		        </tr>
		        <tr>
			        <td style="width:80px;height:24px;color:#3b87dd;"><img src="../images/Intro/icon_k2.gif">당기순이익</td>
			        <td class="kpi_3_2">
			            <asp:Label ID="amt3" runat="server" Text="0" style="color:#3b87dd"></asp:Label>
			        </td>
			        <td style="width:170px;padding:0px 10px 0px 10px;">
			            <div class="kpi_3_B"   id="ratediv3" runat="server" style="width:85%">
			                <asp:Label ID="rate3" runat="server" Text="100" ></asp:Label>%</div>
			        </td>
		        </tr>
	        </table> 
		    
		
        </div>
    </div>

    <div style="float:left;width:162px;height:110px;margin:0px 0px 0px 20px;">
	    <img src="../images/Intro/customer.gif"/>
    </div>
</div>            
 
            
            
            <%-- 공지사항, faq--%>
            <div style="width:924px;clear:both;padding-top:5px;height:10px;">
               <%-- <div class="notice" style="height: 130px;">--%>
                <div class="notice" >
                    <div>
                        <img src="../images/Intro/bar_notice.gif" usemap="#notice"/>
                        <img src="../images/Intro/bar_notice2.gif" />
                    </div>
                    <map name="notice">
                        <area shape="rect" coords="365,7,405,20" href="../BSC/BSC0706S1.ASPX">
                    </map>
                    <ig:UltraWebGrid ID="ugrdNotice" runat="server" Width="100%" Height="100px" 
                                        OnInitializeRow="ugrdNotice_InitializeRow" >
                        <Bands>
                            <ig:UltraGridBand ColHeadersVisible="No">
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <Columns>

                                    <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="70%" 
                                        HeaderText="제목">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="제목">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Left" CssClass="span1">
                                        </CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="NOTICE_REF_ID" Key="NOTICE_REF_ID" Width="70%" Hidden="true" HeaderText="NOTICE_REF_ID"></ig:UltraGridColumn>
                                    <ig:TemplatedColumn BaseColumnName="OWNER_NAME" Key="OWNER_NAME" Width="15%"  FooterText="" HeaderText="작성자">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="작성자">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center" CssClass="span1">
                                        </CellStyle>
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:TemplatedColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="15%" Format="yy-MM-dd" FooterText="" HeaderText="작성일자">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="작성일자">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center" CssClass="span1">
                                        </CellStyle>
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Footer>
                                    </ig:TemplatedColumn>

                                </Columns>
                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                </RowTemplateStyle>
                            </ig:UltraGridBand>
                        </Bands>
                        <DisplayLayout  CellPaddingDefault="2"
                                        AllowColSizingDefault="Free"
                                        AllowColumnMovingDefault="OnServer"
                                        AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes"
                                        BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="SortMulti"
                                        Name="ugrdNotice"
                                        RowHeightDefault="20px"
                                        RowSelectorsDefault="No"
                                        SelectTypeRowDefault="Extended"
                                        Version="4.00"
                                        CellClickActionDefault="RowSelect"
                                        TableLayout="Fixed"
                                        StationaryMargins="Header"
                                                                        ReadOnly="LevelTwo"
                                        AutoGenerateColumns="False">
                            
                            <GroupByBox>
                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
                            <HeaderStyleDefault CssClass="GridHeaderStyleIntro" ></HeaderStyleDefault>                                   
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                            <RowStyleDefault  CssClass="GridRowStyleIntro" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                      
                            <FrameStyle CssClass="GridFrameStyleIntro" Width="100%" Height="80px" ></FrameStyle>
                          
                        </DisplayLayout>
                    </ig:UltraWebGrid>        
                </div>
               <%-- <div class="faq"  style="height: 130px;">--%>
                <div class="faq" >
	                <div>
	                    <img src="../images/Intro/bar_faq.gif" usemap="#faq"/>
	                </div>
	                <map name="faq">
	                    <area shape="rect" coords="260,9,300,22" href="../BSC/BSC0705S1.ASPX">
	                </map>
	                <div style="border:3px solid #e4e5e7; padding-top: 10px;">

 
	                    <ig:UltraWebGrid ID="ugrdFAQ" runat="server" Width="100%" 
	                        OnInitializeRow="ugrdFAQ_InitializeRow" >
                            <Bands>
                                <ig:UltraGridBand ColHeadersVisible="No">
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <Columns>

                                       <ig:UltraGridColumn BaseColumnName="FAQ_QUESTION" Key="FAQ_QUESTION" Width="100%" HeaderText="제목">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="질문">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left" CssClass="span1">
                                            </CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="FAQ_REF_ID" Key="FAQ_REF_ID" Width="100%" HeaderText="제목">
                                        </ig:UltraGridColumn>
                                    </Columns>
                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                    </RowTemplateStyle>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout  CellPaddingDefault="2"
                                            AllowColSizingDefault="Free"
                                            AllowColumnMovingDefault="OnServer"
                                            AllowDeleteDefault="Yes"
                                            AllowSortingDefault="Yes"
                                            BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="SortMulti"
                                            Name="ugrdFAQ"
                                            RowHeightDefault="20px"
                                            RowSelectorsDefault="No"
                                            SelectTypeRowDefault="Extended"
                                            Version="4.00"
                                            CellClickActionDefault="RowSelect"
                                            TableLayout="Fixed"
                                            StationaryMargins="Header"
                                            OptimizeCSSClassNamesOutput="False"
                                            ReadOnly="LevelTwo"
                                            AutoGenerateColumns="False">
                                
                                <GroupByBox>
                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                </GroupByBox>
                                <HeaderStyleDefault CssClass="GridHeaderStyleIntro" ></HeaderStyleDefault>                                   
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyleIntro" />                                
                                <RowStyleDefault  CssClass="GridRowStyleIntro" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyleIntro" ></SelectedRowStyleDefault>
                                          
                                <FrameStyle CssClass="GridFrameStyleIntro" Width="100%" Height="90px" 
                                 ></FrameStyle>

                            </DisplayLayout>
                        </ig:UltraWebGrid>  
	                </div>
                </div> 
                <%--<div style="float:left;width:162px;margin:5px 0px 0px 20px;">--%>
                <div style="float:inherit;width:162px;margin:0px 0px 0px 20px;padding-top:0px;padding-left:10px;">
	                <a href="../BSC/BSC0707S1.ASPX"><img src="../images/Intro/btn_001.gif" vspace="3"/></a>
	                <a href="../BSC/BSC0901S1.ASPX"><img src="../images/Intro/btn_002.gif"/></a>
                </div>
            </div>
            <div style="clear:both;height:21px"></div>
            <div class="progress" style="display:none;" id="divProgress">
                <img src="../images/loading6.gif"/>
            </div>
            <%--<div style="border-top:1px solid #e9e9e9;"><img src="../images/Intro/footer.gif"/></div>--%>
            <asp:DropDownList id="ddlEstTermRefID" runat="server" class="box01" Visible="False" />
            <asp:Literal ID="ltrScript" runat="server" />
        </td>
    </tr>
</table>

</asp:Content>
