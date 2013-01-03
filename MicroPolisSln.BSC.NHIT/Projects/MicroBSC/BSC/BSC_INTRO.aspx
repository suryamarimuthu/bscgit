<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC_INTRO.aspx.cs" Inherits="BSC_INTRO" MasterPageFile="~/_common/lib/MicroBSC.master" %>

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
</style>

<script language="javascript" type="text/javascript" >

    function doLinkingUrl() {
        var url = "<%=KPI_URL %>";

        document.location.href = url;

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

<table border="0" cellpadding="0" cellspacing="0" width="100%" height="1%">
    <tr>
        <td>
        
            <div style="width:1000px;">
                <div style="float:left;width:425px;">
                    <img src="../images/Intro/back_intro_1.jpg" usemap="#mykpi"/>
                </div>
		        <map name="mykpi">
		            <area shape="rect" coords="92,200,130,216" href="#" onclick="doLinkingUrl()">
		        </map>
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

            <div style="width:924px;clear:both;padding-top:10px;">
                <div class="mykpi" style="Height: 108px;">
                   <ig:UltraWebGrid ID="ugrdMyKpiList" runat="server" Width="100%" Height="100%" 
                                 OnInitializeRow="ugrdMyKpiList_InitializeRow" 
                                 OnInitializeLayout="ugrdMyKpiList_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand ColHeadersVisible="No">
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="132px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="11px" ForeColor="Silver" CssClass="span">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="TO_IMAGE" HeaderText="신호" Key="TO_IMAGE"
                                                Width="70%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="신호">
                                                    <RowLayoutColumnInfo OriginX="11" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="11" />
                                                </Footer>
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
                                    Name="ugrdMyKpiList"
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
                                  
                        <FrameStyle CssClass="GridFrameStyleIntro" Width="100%" Height="100%" ></FrameStyle>
                     
                        </DisplayLayout>
                </ig:UltraWebGrid>

                </div>
                <div class="score">
                    <span class="score1"><asp:label ID="lblMBOscore" runat="server" Text="0"></asp:label></span>
                    <span class="score2"><asp:label ID="lblTEAMscore" runat="server" Text="0"></asp:label></span>
                    <span class="score3"><asp:label ID="lblBONBUscore" runat="server" Text="0"></asp:label></span><br/>
                    <span class="name1"><b><asp:label ID="lblUserName" runat="server" Text=""></asp:label></b>님</span>
                    <span class="name2"><asp:label ID="lblTEAMname" runat="server" Text=""></asp:label></span>	
                    <span class="name3"><asp:label ID="lblBONBUname" runat="server" Text=""></asp:label></span>
                	
                </div>
                <div style="float:left;width:162px;height:110px;margin:0px 0px 0px 20px;">
                    <img src="../images/Intro/customer.gif"/>
                </div>
            </div>
            <div style="width:1000px;clear:both;padding-top:15px;height:10px;">
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
	                <a href="../BSC/BSC0703S1.ASPX"><img src="../images/Intro/btn_001.gif" vspace="3"/></a>
	                <a href="../BSC/BSC0901S1.ASPX"><img src="../images/Intro/btn_002.gif"/></a>
                </div>
            </div>
            <div style="clear:both;height:21px"></div>
            <%--<div style="border-top:1px solid #e9e9e9;"><img src="../images/Intro/footer.gif"/></div>--%>
            <asp:DropDownList id="ddlEstTermRefID" runat="server" class="box01" Visible="False" />
            <asp:Literal ID="ltrScript" runat="server" />
        </td>
    </tr>
</table>

</asp:Content>
