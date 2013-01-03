<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST_RPT_EMP.aspx.cs" Inherits="EST_EST_RPT_EMP" %>

<%@ Register Src="USER_CTRL/EST_GRID.ascx" TagName="EST_GRID" TagPrefix="uc1" %>
 
<html>

    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

        <script type="text/javascript">
            function viewDetail(objID) {
                document.getElementById('div1').disabled = true;
                document.getElementById('div2').style.display = "block";

                document.getElementById('div_a').style.display = "none";
                document.getElementById('div_b').style.display = "none";
                document.getElementById('div_c').style.display = "none";
                document.getElementById('div_d').style.display = "none";
                if (objID == "1")
                    document.getElementById('div_a').style.display = "block";
                else if (objID == "2")
                    document.getElementById('div_b').style.display = "block";
                else if (objID == "3")
                    document.getElementById('div_c').style.display = "block";
                else if (objID == "0")
                    document.getElementById('div_d').style.display = "block";
            }
            function closeDetail() {
                document.getElementById('div1').disabled = false;
                document.getElementById('div2').style.display = "none";
            }
        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	    
        <div id="div1" style="z-index: 1; position: absolute; width: 100%; height: 100%;">
            <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 100%" valign="top">
                        <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="2">
                            <tr>
                                <td height="40">
					                <!-- 타이틀시작 -->
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr> 
                                            <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr> 
                                                        <td height="40" valign="top"><img src="../images/title/popup_t41.gif"></td>
                                                        <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr> 
                                                        <td width="50%" height="4" bgcolor="FFFFFF"></td>
                                                        <td width="50%" bgcolor="FFFFFF"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- 타이틀끝 -->
                                </td>
                            </tr>
                            <tr class="cssPopContent">
                                <td valign="top">
                                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td valign="top" align="center" style="height: 25px;">
                                                <div style="height: 100%;">
                                                    <table style="height: 25px;" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                        <tr>
                                                            <td>
                                                              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr> 
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                                           <tr> 
                                                                              <td class="cssTblTitle" style="width: 150px;" align="center">평가기간</td>
                                                                              <td class="cssTblContent" align="center"><%= ESTTERM_REF_NAME%>&nbsp;<%= ESTTERM_SUB_NAME%></td>
                                                                              <td class="cssTblTitle" style="width: 150px;" align="center">피평가부서 / 사원</td>
                                                                              <td class="cssTblContent" align="center"><%= TGT_DEPT_NAME%>&nbsp;/&nbsp;<%= TGT_EMP_NAME%></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%;">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
                                                    <ContentTemplate>
                                                        <table width="100%" style="height: 100%;" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td style="width: 100%; height: 100%;">
                                                                    <div style="width: 100%; height: 100%;">
                                                                        <ig:UltraWebTab ID="igTab" runat="server" Width="100%" Height="100%" ThreeDEffect="false" AutoPostBack="false" EnableViewState="true">
                                                                            <Tabs>
                                                                                <ig:Tab>
                                                                                    <Style Width="200px" Height="23px" Font-Bold="true"></Style>
                                                                                    <ContentTemplate>
                                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                                                            <tr valign="top">
                                                                                                <td style="height: 100%; width: 100%;">
                                                                                                    <div style="border:#F4F4F4 1px solid; overflow: auto; width: 100%; height:100%">
                                                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="100%" Width="97%" OnRowDataBound="GridView1_RowDataBound" BorderWidth="0px" CellPadding="2" CellSpacing="2" ShowHeader="False">
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField></asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </ig:Tab>
                                                                                
                                                                                <%--평가결과 탭 숨김 수정 2012.10.12--%>
                                                                                <ig:TabSeparator><Style Width="1px"></Style></ig:TabSeparator>
                                                                                <ig:Tab Text="평가결과 Dash Board" Key="2" Visible="false">
                                                                                    <Style Width="200px" Height="23px" ForeColor="#1E8BC0" Font-Bold="true"></Style>
                                                                                    <ContentTemplate>
                                                                                        <div style="border:#F4F4F4 1px solid; overflow: auto; width: 100%; height:100%; vertical-align: top;">
                                                                                            <table border="0" cellpadding="0" cellspacing="5" style="width: 100%; height: 100%;">
                                                                                                <tr>
                                                                                                    <td style="height: 100%; width: 100%; color: #1E8BC0;" valign="top">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                            <tr>
                                                                                                                <td style="height: 20px; padding-left: 5px;">
                                                                                                                    <img src="/images/icon/left_icon02.gif" align="absmiddle" alt="" />&nbsp;<b>최종평가결과</b>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <table style="border: 1px solid #CCCCC;" cellpadding="0" cellspacing="0" width="100%">
                                                                                                                        <tr>
                                                                                                                            <td align="center" style="background-color: #D1D1D1; color: #666666; width: 25%; height: 25px;">
                                                                                                                                <b>최종평가점수</b>
                                                                                                                            </td>
                                                                                                                            <td align="center" style="background-color: #DDDDDD; color: #666666; width: 25%;">
                                                                                                                                <b>최종등급</b>
                                                                                                                            </td>
                                                                                                                            <td align="center" style="background-color: #EAEAEA; color: #666666; width: 25%;">
                                                                                                                                <b>업적평가점수</b>
                                                                                                                            </td>
                                                                                                                            <td align="center" style="background-color: #F1F1F1; color: #666666; width: 25%;">
                                                                                                                                <b>역량평가점수</b>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="center" style="height: 90px;" valign="middle">
                                                                                                                                <div style="width: 95px; height: 64px; vertical-align: middle; color: White; background-image: url('../images/dashboard/bg_box1.jpg');">
                                                                                                                                    <br /><asp:Label ID="lblPoint_1" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
                                                                                                                                </div>                                                                                                                            
                                                                                                                            </td>
                                                                                                                            <td align="center" valign="middle">
                                                                                                                                <div style="width: 95px; height: 64px; vertical-align: middle; color: White; background-image: url('../images/dashboard/bg_box2.jpg');">
                                                                                                                                    <br /><asp:Label ID="lblPoint_2" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
                                                                                                                                </div>                                                                                                                            
                                                                                                                            </td>
                                                                                                                            <td align="center" valign="middle">
                                                                                                                                <div style="width: 95px; height: 64px; vertical-align: middle; color: #898989; background-image: url('../images/dashboard/bg_box3.jpg');">
                                                                                                                                    <br /><asp:Label ID="lblPoint_3" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
                                                                                                                                </div>                                                                                                                            
                                                                                                                            </td>
                                                                                                                            <td align="center" valign="middle">
                                                                                                                                <div style="width: 95px; height: 64px; vertical-align: middle; color: #898989; background-image: url('../images/dashboard/bg_box3.jpg');">
                                                                                                                                    <br /><asp:Label ID="lblPoint_4" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
                                                                                                                                </div>                                                                                                                            
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                                                                        <tr>
                                                                                                                            <td style="height: 20px; padding-left: 5px; padding-top: 10px;">
                                                                                                                                <img src="/images/icon/left_icon02.gif" align="absmiddle" alt="" />&nbsp;<b>업적평가결과</b>
                                                                                                                            </td>
                                                                                                                            <td style="padding-top: 10px; padding-left: 50px;" valign="middle">
                                                                                                                                <asp:RadioButtonList ID="rblFindType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblFindType_SelectedIndexChanged"></asp:RadioButtonList>
                                                                                                                            </td>
                                                                                                                            <td style="padding-top: 13px; padding-left: 10px;" valign="middle">
                                                                                                                                <asp:DropDownList ID="ddlListType" runat="server" class="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlListType_SelectedIndexChanged" Visible="false" />
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                 </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 100px; width: 100%;">
                                                                                                                    <!--공헌도평가-->
                                                                                                                    <div id="div03" runat="server" style="width: 100%; height: 100%; background-color: Red;" onclick="viewDetail('0')">
                                                                                                                        <DCWC:Chart ID="Chart0" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                                                                                                            BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="200px"
                                                                                                                            Palette="Dundas" Width="196px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                                                                                                            <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                                                                                                            <Series>
                                                                                                                                <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                    Name="Series1" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                    ShowLabelAsValue="False">
                                                                                                                                </DCWC:Series>
                                                                                                                            </Series>
                                                                                                                            <Series>
                                                                                                                                <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                    Name="Series2" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                    ShowLabelAsValue="False">
                                                                                                                                </DCWC:Series>
                                                                                                                            </Series>
                                                                                                                            <UI>
                                                                                                                                <Toolbar BorderColor="Red">
                                                                                                                                    <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                                                                                                                </Toolbar>
                                                                                                                            </UI>
                                                                                                                            <ChartAreas>
                                                                                                                                <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                                                                                                                    Name="Default">
                                                                                                                                    <AxisX>
                                                                                                                                        <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                        <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                        <MinorGrid LineColor="Red" />
                                                                                                                                        <MinorTickMark LineColor="Red" />
                                                                                                                                        <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                        
                                                                                                                                        <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                                                                                                                    </AxisX>
                                                                                                                                    <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                                                                                                                    <AxisY Interval="10" TitleFont="Dotum, 10px">
                                                                                                                                        <MajorGrid LineColor="LightGray" />
                                                                                                                                        <MinorGrid LineColor="#F4F4F4" />
                                                                                                                                        <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                        <MinorGrid LineColor="Red" />
                                                                                                                                        <MinorTickMark LineColor="Red" />
                                                                                                                                        <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                    </AxisY>
                                                                                                                                    <AxisX2>
                                                                                                                                        <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                        <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                        <MinorGrid LineColor="Red" />
                                                                                                                                        <MinorTickMark LineColor="Red" />
                                                                                                                                        <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                    </AxisX2>
                                                                                                                                    <AxisY2>
                                                                                                                                        <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                        <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                        <MinorGrid LineColor="Red" />
                                                                                                                                        <MinorTickMark LineColor="Red" />
                                                                                                                                        <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                    </AxisY2>
                                                                                                                                </DCWC:ChartArea>
                                                                                                                            </ChartAreas>
                                                                                                                            <Titles>
                                                                                                                                <DCWC:Title Name="Title1">
                                                                                                                                </DCWC:Title>
                                                                                                                            </Titles>
                                                                                                                            <Legends>
                                                                                                                                <DCWC:Legend Alignment="Center" BackColor="#F4F4F4" BorderColor="#F4F4F4" Docking="Top" Font="Dotum, 10px"
                                                                                                                                    Enabled="True" LegendStyle="Row" Name="Default" ShadowOffset="0" DockInsideChartArea="true">
                                                                                                                                </DCWC:Legend>
                                                                                                                            </Legends>
                                                                                                                        </DCWC:Chart>
                                                                                                                    </div>
                                                                                                                    <!--MBO평가-->
                                                                                                                    <div id="div04" runat="server" style="width: 100%; height: 100%;">
                                                                                                                        <ig:UltraWebGrid ID="ugrdMBO" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMBO_InitializeRow">
                                                                                                                            <Bands>
                                                                                                                                <ig:UltraGridBand>
                                                                                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                                                                                    </AddNewRow>
                                                                                                                                    <Columns>
                                                                                                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" HeaderText="지표명칭" Width="52%">
                                                                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                                                                        </ig:UltraGridColumn>
                                                                                                                                        <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치(%)" Width="12%" DataType="System.Double" Format="###,##0.00">
                                                                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                                                                            <CellStyle HorizontalAlign="Right">
                                                                                                                                                <Padding Right="20px" />
                                                                                                                                            </CellStyle>
                                                                                                                                        </ig:UltraGridColumn>
                                                                                                                                        <ig:UltraGridColumn BaseColumnName="RESULT" HeaderText="달성율(%)" Width="12%" DataType="System.Double" Format="###,##0.00">
                                                                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                                                                            <CellStyle HorizontalAlign="Right">
                                                                                                                                                <Padding Right="20px" />
                                                                                                                                            </CellStyle>
                                                                                                                                        </ig:UltraGridColumn>
                                                                                                                                        <ig:UltraGridColumn BaseColumnName="SIGNAL" Key="SIGNAL" HeaderText="등급" Width="12%">
                                                                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                                                                                        </ig:UltraGridColumn>
                                                                                                                                        <ig:UltraGridColumn BaseColumnName="POINT" HeaderText="점수" Width="12%" DataType="System.Double" Format="###,##0">
                                                                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                                                                            <CellStyle HorizontalAlign="Right">
                                                                                                                                                <Padding Right="20px" />
                                                                                                                                            </CellStyle>
                                                                                                                                        </ig:UltraGridColumn>
                                                                                                                                    </Columns>
                                                                                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                                                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                                                                                    </RowTemplateStyle>
                                                                                                                                </ig:UltraGridBand>
                                                                                                                            </Bands>
                                                                                                                             <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" BorderCollapseDefault="Separate"
                                                                                                                                    Name="ugrdMBO" RowHeightDefault="20px"
                                                                                                                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00"
                                                                                                                                    ReadOnly="NotSet" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                                                                                                    <GroupByBox>
                                                                                                                                        <BoxStyle BackColor="whitesmoke" BorderColor="#CCCCCC"></BoxStyle>
                                                                                                                                    </GroupByBox>
                                                                                                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#CCCCCC" ForeColor="DimGray">
                                                                                                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                                                                                    </GroupByRowStyleDefault>
                                                                                                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                                                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                                                                                    </FooterStyleDefault>
                                                                                                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                                                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                                                                                        <Padding Left="3px" />
                                                                                                                                    </RowStyleDefault>
                                                                                                                                    <HeaderStyleDefault BackColor="#F1F1F1" BorderStyle="Solid" BorderColor="#CCCCCC" ForeColor="#666666" Height="20px">
                                                                                                                                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" StyleTop="None" />
                                                                                                                                    </HeaderStyleDefault>
                                                                                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                                                                                    </EditCellStyleDefault>
                                                                                                                                    <FrameStyle BackColor="Window" BorderColor="#CCCCCC" BorderStyle="Solid"
                                                                                                                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                                                                                                        Width="100%">
                                                                                                                                    </FrameStyle>
                                                                                                                                    <Pager>
                                                                                                                                        <PagerStyle BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px">
                                                                                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                                                                                        </PagerStyle>
                                                                                                                                    </Pager>
                                                                                                                                    <AddNewBox Hidden="False">
                                                                                                                                        <BoxStyle BackColor="#CCCCCC" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                                                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                                                                                        </BoxStyle>
                                                                                                                                    </AddNewBox>
                                                                                                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                                                                                    </SelectedRowStyleDefault>
                                                                                                                                 <ClientSideEvents />
                                                                                                                            </DisplayLayout>
                                                                                                                        </ig:UltraWebGrid>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 20px; padding-left: 5px; padding-top: 15px;">
                                                                                                                    <img src="/images/icon/left_icon02.gif" align="absmiddle" alt="" />&nbsp;<b>역량평가결과</b>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 20px; width: 100%; padding-top: 5px;">
                                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                                        <tr>
                                                                                                                            <td align="center" style="width: 30%;">
                                                                                                                                평가별 점수
                                                                                                                            </td>
                                                                                                                            <td align="center" style="width: 70%; border-left: 1px solid LightGray;">
                                                                                                                                평가항목별 점수 현황
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="center" style="width: 31%; padding-top: 3px;">
                                                                                                                                <DCWC:Chart ID="Chart1" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                                                                                                                    BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="200px"
                                                                                                                                    Palette="Dundas" Width="270px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                                                                                                                    <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                                                                                                                    <Series>
                                                                                                                                        <DCWC:Series BorderColor="Yellow" ChartType="StackedBar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                            Name="Default" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                            ShowLabelAsValue="False">
                                                                                                                                        </DCWC:Series>
                                                                                                                                    </Series>
                                                                                                                                    <UI>
                                                                                                                                        <Toolbar BorderColor="Red">
                                                                                                                                            <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                                                                                                                        </Toolbar>
                                                                                                                                    </UI>
                                                                                                                                    <ChartAreas>
                                                                                                                                        <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                                                                                                                            Name="Default">
                                                                                                                                            <AxisX>
                                                                                                                                                <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                <MinorGrid LineColor="Red" />
                                                                                                                                                <MinorTickMark LineColor="Red" />
                                                                                                                                                <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                
                                                                                                                                                <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                                                                                                                            </AxisX>
                                                                                                                                            <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                                                                                                                            <AxisY Interval="30">
                                                                                                                                                <MajorGrid LineColor="LightGray" />
                                                                                                                                                <MinorGrid LineColor="#F4F4F4" />
                                                                                                                                                <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                <MinorGrid LineColor="Red" />
                                                                                                                                                <MinorTickMark LineColor="Red" />
                                                                                                                                                <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                            </AxisY>
                                                                                                                                            <AxisX2>
                                                                                                                                                <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                <MinorGrid LineColor="Red" />
                                                                                                                                                <MinorTickMark LineColor="Red" />
                                                                                                                                                <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                            </AxisX2>
                                                                                                                                            <AxisY2>
                                                                                                                                                <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                <MinorGrid LineColor="Red" />
                                                                                                                                                <MinorTickMark LineColor="Red" />
                                                                                                                                                <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                            </AxisY2>
                                                                                                                                        </DCWC:ChartArea>
                                                                                                                                    </ChartAreas>
                                                                                                                                    <Titles>
                                                                                                                                        <DCWC:Title Name="Title1">
                                                                                                                                        </DCWC:Title>
                                                                                                                                    </Titles>
                                                                                                                                    <Legends>
                                                                                                                                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="Red" Docking="Bottom"
                                                                                                                                            Enabled="False" LegendStyle="Table" Name="Default" ShadowOffset="0">
                                                                                                                                        </DCWC:Legend>
                                                                                                                                    </Legends>
                                                                                                                                </DCWC:Chart>
                                                                                                                            </td>
                                                                                                                            <td align="center" style="width: 69%; border-left: 1px solid LightGray;">
                                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td align="center" onclick="viewDetail('1')">
                                                                                                                                            <DCWC:Chart ID="Chart2" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                                                                                                                                BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="200px"
                                                                                                                                                Palette="Dundas" Width="196px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                                                                                                                                <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                                                                                                                                <Series>
                                                                                                                                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                                        Name="Series1" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                                        ShowLabelAsValue="False">
                                                                                                                                                    </DCWC:Series>
                                                                                                                                                </Series>
                                                                                                                                                <Series>
                                                                                                                                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                                        Name="Series2" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                                        ShowLabelAsValue="False">
                                                                                                                                                    </DCWC:Series>
                                                                                                                                                </Series>
                                                                                                                                                <UI>
                                                                                                                                                    <Toolbar BorderColor="Red">
                                                                                                                                                        <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                                                                                                                                    </Toolbar>
                                                                                                                                                </UI>
                                                                                                                                                <ChartAreas>
                                                                                                                                                    <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                                                                                                                                        Name="Default">
                                                                                                                                                        <AxisX>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                            
                                                                                                                                                            <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                                                                                                                                        </AxisX>
                                                                                                                                                        <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                                                                                                                                        <AxisY Interval="10" TitleFont="Dotum, 10px">
                                                                                                                                                            <MajorGrid LineColor="LightGray" />
                                                                                                                                                            <MinorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisY>
                                                                                                                                                        <AxisX2>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisX2>
                                                                                                                                                        <AxisY2>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisY2>
                                                                                                                                                    </DCWC:ChartArea>
                                                                                                                                                </ChartAreas>
                                                                                                                                                <Titles>
                                                                                                                                                    <DCWC:Title Name="Title1">
                                                                                                                                                    </DCWC:Title>
                                                                                                                                                </Titles>
                                                                                                                                                <Legends>
                                                                                                                                                    <DCWC:Legend Alignment="Center" BackColor="#F4F4F4" BorderColor="#F4F4F4" Docking="Top" Font="Dotum, 10px"
                                                                                                                                                        Enabled="True" LegendStyle="Row" Name="Default" ShadowOffset="0" DockInsideChartArea="true">
                                                                                                                                                    </DCWC:Legend>
                                                                                                                                                </Legends>
                                                                                                                                            </DCWC:Chart>
                                                                                                                                        </td>
                                                                                                                                        <td align="center" onclick="viewDetail('2')">
                                                                                                                                            <DCWC:Chart ID="Chart3" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                                                                                                                                BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="200px"
                                                                                                                                                Palette="Dundas" Width="196px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                                                                                                                                <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                                                                                                                                <Series>
                                                                                                                                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                                        Name="Series1" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                                        ShowLabelAsValue="False">
                                                                                                                                                    </DCWC:Series>
                                                                                                                                                </Series>
                                                                                                                                                <Series>
                                                                                                                                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                                        Name="Series2" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                                        ShowLabelAsValue="False">
                                                                                                                                                    </DCWC:Series>
                                                                                                                                                </Series>
                                                                                                                                                <UI>
                                                                                                                                                    <Toolbar BorderColor="Red">
                                                                                                                                                        <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                                                                                                                                    </Toolbar>
                                                                                                                                                </UI>
                                                                                                                                                <ChartAreas>
                                                                                                                                                    <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                                                                                                                                        Name="Default">
                                                                                                                                                        <AxisX>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                            
                                                                                                                                                            <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                                                                                                                                        </AxisX>
                                                                                                                                                        <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                                                                                                                                        <AxisY Interval="30">
                                                                                                                                                            <MajorGrid LineColor="LightGray" />
                                                                                                                                                            <MinorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisY>
                                                                                                                                                        <AxisX2>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisX2>
                                                                                                                                                        <AxisY2>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisY2>
                                                                                                                                                    </DCWC:ChartArea>
                                                                                                                                                </ChartAreas>
                                                                                                                                                <Titles>
                                                                                                                                                    <DCWC:Title Name="Title1">
                                                                                                                                                    </DCWC:Title>
                                                                                                                                                </Titles>
                                                                                                                                                <Legends>
                                                                                                                                                    <DCWC:Legend Alignment="Center" BackColor="#F4F4F4" BorderColor="#F4F4F4" Docking="Top" Font="Dotum, 10px"
                                                                                                                                                        Enabled="True" LegendStyle="Row" Name="Default" ShadowOffset="0" DockInsideChartArea="true">
                                                                                                                                                    </DCWC:Legend>
                                                                                                                                                </Legends>
                                                                                                                                            </DCWC:Chart>
                                                                                                                                        </td>
                                                                                                                                        <td align="center" onclick="viewDetail('3')">
                                                                                                                                            <DCWC:Chart ID="Chart4" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                                                                                                                                BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="200px"
                                                                                                                                                Palette="Dundas" Width="196px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                                                                                                                                <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                                                                                                                                <Series>
                                                                                                                                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                                        Name="Series1" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                                        ShowLabelAsValue="False">
                                                                                                                                                    </DCWC:Series>
                                                                                                                                                </Series>
                                                                                                                                                <Series>
                                                                                                                                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                                                                                                                                        Name="Series2" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 10px"
                                                                                                                                                        ShowLabelAsValue="False">
                                                                                                                                                    </DCWC:Series>
                                                                                                                                                </Series>
                                                                                                                                                <UI>
                                                                                                                                                    <Toolbar BorderColor="Red">
                                                                                                                                                        <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                                                                                                                                    </Toolbar>
                                                                                                                                                </UI>
                                                                                                                                                <ChartAreas>
                                                                                                                                                    <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                                                                                                                                        Name="Default">
                                                                                                                                                        <AxisX>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                            
                                                                                                                                                            <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                                                                                                                                        </AxisX>
                                                                                                                                                        <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                                                                                                                                        <AxisY Interval="30">
                                                                                                                                                            <MajorGrid LineColor="LightGray" />
                                                                                                                                                            <MinorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisY>
                                                                                                                                                        <AxisX2>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisX2>
                                                                                                                                                        <AxisY2>
                                                                                                                                                            <MajorGrid LineColor="#F4F4F4" />
                                                                                                                                                            <MajorTickMark LineColor="#F4F4F4" />
                                                                                                                                                            <MinorGrid LineColor="Red" />
                                                                                                                                                            <MinorTickMark LineColor="Red" />
                                                                                                                                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                                                                                                                                        </AxisY2>
                                                                                                                                                    </DCWC:ChartArea>
                                                                                                                                                </ChartAreas>
                                                                                                                                                <Titles>
                                                                                                                                                    <DCWC:Title Name="Title1">
                                                                                                                                                    </DCWC:Title>
                                                                                                                                                </Titles>
                                                                                                                                                <Legends>
                                                                                                                                                    <DCWC:Legend Alignment="Center" BackColor="#F4F4F4" BorderColor="#F4F4F4" Docking="Top" Font="Dotum, 10px"
                                                                                                                                                        Enabled="True" LegendStyle="Row" Name="Default" ShadowOffset="0" DockInsideChartArea="true">
                                                                                                                                                    </DCWC:Legend>
                                                                                                                                                </Legends>
                                                                                                                                            </DCWC:Chart>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                </ig:Tab>
                                                                            </Tabs>
                                                                            <DefaultTabStyle BackColor="White" Height="20px"></DefaultTabStyle>
                                                                            <%--<RoundedImage FillStyle="LeftMergedWithCenter" 
                                                                                NormalImage="../images/tab/ig_tab_blueb1.gif" 
                                                                                SelectedImage="../images/tab/ig_tab_blueb2.gif" />--%>
                                                                        </ig:UltraWebTab>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr><td style="height:5px"></td></tr>
                                        <tr valign="bottom" align="right" style="height: 25px;">
                                            <td>
                                                <a href="#null" onclick="window.close();"><img src="../images/btn/b_003.gif" border="0"/></a>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:DropDownList id="ddlGradePoint_hdf" runat="server" width="0"></asp:DropDownList>
                    </td>
                </tr>
            </table>   
        </div>
        <div id="div2" style="z-index: 2; position: absolute; width: 900px; height: 610px; display: none; background-color: #F4F4F4; left: 0px; top: 50px;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center" onclick="closeDetail()">
                        <div id="div_d" style="display: none;">
                            <DCWC:Chart ID="ChartD" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="610px"
                                Palette="Dundas" Width="900px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                <Series>
                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                        Name="Series1" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 20px"
                                        ShowLabelAsValue="False">
                                    </DCWC:Series>
                                </Series>
                                <Series>
                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                        Name="Series2" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 20px"
                                        ShowLabelAsValue="False">
                                    </DCWC:Series>
                                </Series>
                                <UI>
                                    <Toolbar BorderColor="Red">
                                        <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                    </Toolbar>
                                </UI>
                                <ChartAreas>
                                    <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                        Name="Default">
                                        <AxisX>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                            
                                            <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                        </AxisX>
                                        <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                        <AxisY Interval="10" TitleFont="Dotum, 10px">
                                            <MajorGrid LineColor="LightGray" />
                                            <MinorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisY>
                                        <AxisX2>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisX2>
                                        <AxisY2>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisY2>
                                    </DCWC:ChartArea>
                                </ChartAreas>
                                <Titles>
                                    <DCWC:Title Name="Title1">
                                    </DCWC:Title>
                                </Titles>
                                <Legends>
                                    <DCWC:Legend Alignment="Center" BackColor="#F4F4F4" BorderColor="#F4F4F4" Docking="Top" Font="Dotum, 10px"
                                        Enabled="True" LegendStyle="Row" Name="Default" ShadowOffset="0" DockInsideChartArea="true">
                                    </DCWC:Legend>
                                </Legends>
                            </DCWC:Chart>
                        </div>
                        <div id="div_a">
                            <DCWC:Chart ID="ChartA" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="610px"
                                Palette="Dundas" Width="900px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                <Series>
                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                        Name="Series1" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 20px"
                                        ShowLabelAsValue="False">
                                    </DCWC:Series>
                                </Series>
                                <Series>
                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                        Name="Series2" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 20px"
                                        ShowLabelAsValue="False">
                                    </DCWC:Series>
                                </Series>
                                <UI>
                                    <Toolbar BorderColor="Red">
                                        <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                    </Toolbar>
                                </UI>
                                <ChartAreas>
                                    <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                        Name="Default">
                                        <AxisX>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                            
                                            <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                        </AxisX>
                                        <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                        <AxisY Interval="10" TitleFont="Dotum, 10px">
                                            <MajorGrid LineColor="LightGray" />
                                            <MinorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisY>
                                        <AxisX2>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisX2>
                                        <AxisY2>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisY2>
                                    </DCWC:ChartArea>
                                </ChartAreas>
                                <Titles>
                                    <DCWC:Title Name="Title1">
                                    </DCWC:Title>
                                </Titles>
                                <Legends>
                                    <DCWC:Legend Alignment="Center" BackColor="#F4F4F4" BorderColor="#F4F4F4" Docking="Top" Font="Dotum, 10px"
                                        Enabled="True" LegendStyle="Row" Name="Default" ShadowOffset="0" DockInsideChartArea="true">
                                    </DCWC:Legend>
                                </Legends>
                            </DCWC:Chart>
                        </div>
                        <div id="div_b" style="display: none;">
                            <DCWC:Chart ID="ChartB" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="610px"
                                Palette="Dundas" Width="900px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                <Series>
                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                        Name="Series1" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 20px"
                                        ShowLabelAsValue="False">
                                    </DCWC:Series>
                                </Series>
                                <Series>
                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                        Name="Series2" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 20px"
                                        ShowLabelAsValue="False">
                                    </DCWC:Series>
                                </Series>
                                <UI>
                                    <Toolbar BorderColor="Red">
                                        <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                    </Toolbar>
                                </UI>
                                <ChartAreas>
                                    <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                        Name="Default">
                                        <AxisX>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                            
                                            <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                        </AxisX>
                                        <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                        <AxisY Interval="10" TitleFont="Dotum, 10px">
                                            <MajorGrid LineColor="LightGray" />
                                            <MinorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisY>
                                        <AxisX2>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisX2>
                                        <AxisY2>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisY2>
                                    </DCWC:ChartArea>
                                </ChartAreas>
                                <Titles>
                                    <DCWC:Title Name="Title1">
                                    </DCWC:Title>
                                </Titles>
                                <Legends>
                                    <DCWC:Legend Alignment="Center" BackColor="#F4F4F4" BorderColor="#F4F4F4" Docking="Top" Font="Dotum, 10px"
                                        Enabled="True" LegendStyle="Row" Name="Default" ShadowOffset="0" DockInsideChartArea="true">
                                    </DCWC:Legend>
                                </Legends>
                            </DCWC:Chart>
                        </div>
                        <div id="div_c" style="display: none;">
                            <DCWC:Chart ID="ChartC" runat="server" BackColor="#F4F4F4" BackGradientEndColor="Yellow"
                                BorderLineColor="#CCCCCC" BorderLineStyle="Solid" BorderLineWidth="1" Height="610px"
                                Palette="Dundas" Width="900px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                <BorderSkin FrameBackColor="Yellow" FrameBackGradientEndColor="Yellow" SkinStyle="Sunken" />
                                <Series>
                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                        Name="Series1" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 20px"
                                        ShowLabelAsValue="False">
                                    </DCWC:Series>
                                </Series>
                                <Series>
                                    <DCWC:Series BorderColor="Yellow" ChartType="Radar" CustomAttributes="StackedBarLabelStyle=Outside, StackedBarOutsideLabelPlacement=Right"
                                        Name="Series2" ShadowOffset="1" XValueType="String" YValueType="String" Font="Dotum, 20px"
                                        ShowLabelAsValue="False">
                                    </DCWC:Series>
                                </Series>
                                <UI>
                                    <Toolbar BorderColor="Red">
                                        <BorderSkin PageColor="Red" SkinStyle="Emboss" />
                                    </Toolbar>
                                </UI>
                                <ChartAreas>
                                    <DCWC:ChartArea BackColor="#F4F4F4" BorderColor="#F4F4F4" BorderStyle="Solid"
                                        Name="Default">
                                        <AxisX>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                            
                                            <StripLines><DCWC:StripLine BackColor="Red" /></StripLines>
                                        </AxisX>
                                        <Area3DStyle Light="None" Clustered="True" PointGapDepth="30" Enable3D="True" XAngle="20" YAngle="20" WallWidth="10" />
                                        <AxisY Interval="10" TitleFont="Dotum, 10px">
                                            <MajorGrid LineColor="LightGray" />
                                            <MinorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisY>
                                        <AxisX2>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisX2>
                                        <AxisY2>
                                            <MajorGrid LineColor="#F4F4F4" />
                                            <MajorTickMark LineColor="#F4F4F4" />
                                            <MinorGrid LineColor="Red" />
                                            <MinorTickMark LineColor="Red" />
                                            <ScrollBar LineColor="Red" BackColor="Red" />
                                        </AxisY2>
                                    </DCWC:ChartArea>
                                </ChartAreas>
                                <Titles>
                                    <DCWC:Title Name="Title1">
                                    </DCWC:Title>
                                </Titles>
                                <Legends>
                                    <DCWC:Legend Alignment="Center" BackColor="#FFFFFF" BorderColor="#FFFFFF" Docking="Top" Font="Dotum, 10px"
                                        Enabled="True" LegendStyle="Row" Name="Default" ShadowOffset="0" DockInsideChartArea="true">
                                    </DCWC:Legend>
                                </Legends>
                            </DCWC:Chart>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    <script>gfWinFocus();</script>
    <!--- MAIN END --->
    </form>
</body>
</html>
