<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0305M1.aspx.cs" Inherits="BSC_BSC0305M1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC::성과관리 시스템::KPI 수정</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script id="Infragistics" type="text/javascript">
    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell = igtbl_getElementById(id);
           var row = igtbl_getRowById(id);
           var band = igtbl_getBandById(id);
           var active = igtbl_getActiveRow(id);
           cell.style.cursor = 'hand';
        }
    }
    
    var param1 = false;
    function selectChkBox(chkChild)
    {
        var _elements   = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
            {
                if (param1)
                {
                    _elements[i].checked = false;
                }
                else
                {
                    _elements[i].checked = true;
                }
            }
        }
        
        param1 = (param1==true) ? false : true;
    }
</script>
</head>
<body style="margin:0,0,0,0;">
    <form id="form1" runat="server" style="margin-top:0px;margin-left:0px">
        <table border="0" cellpadding="0" cellspacing="0" style="vertical-align:top; width:100%; height:100%;">
            <tr>
                <td colspan="2" valign="top" style="height:40px;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:40px;">
                        <tr> 
                            <td style="height:100%; background-image:url(../images/title/popup_t_bg.gif);" valign="top"> 
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t5.gif" width="230" height="40" /></td>
                                        <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif" /></td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr> 
                                        <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                                        <td style="width:50%; background-color:#FFFFFF"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                     </table>
                </td>
            </tr>
            <tr class="cssPopContent">
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                        <tr>
                            <td>
                              <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                <tr>
                                  <td style="vertical-align:middle; width:100%;">
                                     <ig:UltraWebTab runat="server" BorderWidth="1" ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="true" Width="100%" AutoPostBack="True" OnTabClick="ugrdKpiStatusTab_TabClick">
                                        <Tabs>
                                              <ig:Tab Text="하위지표" Key="1">
                                                <Style Width="100px" Height="20px" />
                                                  <ContentTemplate>
                                                    <table style="border-width:0px; width:100%; height:100%;">
                                                      <tr class="cssPopBtnLine">
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                                <tr>
                                                                    <td style="width:15px;">
                                                                        <img src="../images/title/ma_t14.gif" alt="" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="하위 KPI리스트" />
                                                                    </td>
                                                                    <td style="text-align:right;">
                                                                    <asp:ImageButton ID="iBtnSaveWeight" runat="server" ImageUrl="../images/btn/b_007.gif" OnClick="iBtnSaveWeight_Click" />
                                                                </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                      </tr>
                                                      <tr style="height:50%;">
                                                        <td>
                                                          <ig:UltraWebGrid ID="ugrdChildKpi" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdChildKpi_InitializeRow" >
                                                            <Bands>
                                                                <ig:UltraGridBand>
                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                    </AddNewRow>
                                                                    <Columns>
                                                                        <ig:TemplatedColumn Key="selchk" Width="25px" Hidden="false">
                                                                            <HeaderTemplate>
                                                                                <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdChildKpi')" />
                                                                            </HeaderTemplate>
                                                                            <Header Fixed="true"></Header>
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <CellStyle HorizontalAlign="center"  BackColor="whitesmoke"></CellStyle>
                                                                            <CellTemplate>
                                                                                <asp:checkbox id="cBox" runat="server" />
                                                                            </CellTemplate>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:TemplatedColumn Key="ROLLUP_TARGET_YN" BaseColumnName="ROLLUP_TARGET_YN" Width="35px">
                                                                            <Header Fixed="true" Caption="목표롤업"></Header>
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                                            <CellStyle HorizontalAlign="center" BackColor="whitesmoke"></CellStyle>
                                                                            <CellTemplate>
                                                                                <asp:checkbox id="cBox" runat="server" />
                                                                            </CellTemplate>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:TemplatedColumn Key="ROLLUP_SCORE_YN" BaseColumnName="ROLLUP_SCORE_YN" Width="35px">
                                                                            <Header Fixed="true" Caption="점수롤업"></Header>
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                                            <CellStyle HorizontalAlign="center"  BackColor="whitesmoke"></CellStyle>
                                                                            <CellTemplate>
                                                                                <asp:checkbox id="cBox" runat="server" />
                                                                            </CellTemplate>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                            FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="ESTTERM_REF_ID" Fixed="true">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID="" NullText="0"
                                                                            FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI_REF_ID" Fixed="true">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="60px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                            <Header Caption="KPI 코드" Fixed="true">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="250px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI 명" Fixed="true">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left" BackColor="whitesmoke" />
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="150px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="운영조직">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="50px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI담당자">
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="단위">
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID=""
                                                                            FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="실적방식">
                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="UP_KPI_WEIGHT" EditorControlID="" FooterText="" AllowUpdate="Yes"
                                                                            Format="" HeaderText="UP_KPI_WEIGHT" Key="UP_KPI_WEIGHT" DataType="System.Double" NullText="0" Width="60px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="가중치">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" />
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                    </Columns>
                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                    </RowTemplateStyle>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                             <DisplayLayout CellPaddingDefault="0" AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="No"
                                                                    AllowSortingDefault="No" BorderCollapseDefault="Separate" UseFixedHeaders="true" StationaryMargins="Header" 
                                                                    HeaderClickActionDefault="NotSet" Name="ugrdChileKpi" RowHeightDefault="20px" HeaderStyleDefault-Height="35px"
                                                                    RowSelectorsDefault="No" SelectTypeRowDefault="None" Version="4.00" ViewType="Flat" CellClickActionDefault="CellSelect" TableLayout="Fixed" AutoGenerateColumns="False">
                                                                    <%--<GroupByBox>
                                                                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                                    </GroupByBox>
                                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                    </GroupByRowStyleDefault>
                                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                    </FooterStyleDefault>
                                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                        <Padding Left="3px" />
                                                                    </RowStyleDefault>
                                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                                    </HeaderStyleDefault>
                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                    </EditCellStyleDefault>
                                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                                        Width="100%">
                                                                    </FrameStyle>
                                                                    <Pager>
                                                                    <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                    </Style>
                                                                    </Pager>
                                                                    <AddNewBox Hidden="False">
                                                                    <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                    </Style>
                                                                    </AddNewBox>
                                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                    </SelectedRowStyleDefault>--%>
                                                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdKpiList_DblClickHandler" />
                                                                    
                                                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                </DisplayLayout>
                                                          </ig:UltraWebGrid>
                                                        </td>
                                                      </tr>
                                                      <tr class="cssPopBtnLine">
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                                <tr>
                                                                    <td style="width:15px;">
                                                                        <img src="../images/title/ma_t14.gif" alt="" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label id="Label1" runat="server" style="font-weight:bold" text="대상 KPI 리스트" />
                                                                    </td>
                                                                    <td style="text-align:right;">
                                                                    <asp:ImageButton ID="addKpi" runat="server" ImageUrl="../images/btn/btn_add_03.gif" AlternateText="지표추가" OnClick="addKpi_Click" />&nbsp;
                                                                    <asp:ImageButton ID="remKpi" runat="server" ImageUrl="../images/btn/btn_add_04.gif" AlternateText="지표삭제" OnClick="remKpi_Click" />
                                                                </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                      </tr>
                                                      <tr style="height:50%;">
                                                        <td>
                                                            <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiList_InitializeRow" >
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                                                            <ig:TemplatedColumn Key="selchk" Width="30px" Hidden="false">
                                                                                <HeaderTemplate>
                                                                                    <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                                                                </HeaderTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                <CellTemplate>
                                                                                    <asp:checkbox id="cBox" runat="server" />
                                                                                </CellTemplate>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                                FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="ESTTERM_REF_ID">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                                FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="KPI_REF_ID">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                                                Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="60px">
                                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                                <Header Caption="KPI 코드">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                                                Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="350px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="KPI 명">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left">
                                                                                </CellStyle>
                                                                                <ValueList DisplayStyle="NotSet">
                                                                                </ValueList>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                                                Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="130px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="운영조직">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="50px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="KPI담당자">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="80px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="지표유형">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="단위">
                                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID=""
                                                                                FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="실적방식">
                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID="" Width="35px" FooterText="" HeaderText="APP_STATUS">
                                                                              <Header Caption="결재상태">
                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                              </Header>
                                                                              <HeaderStyle Wrap="True" />
                                                                              <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                              <CellTemplate>
                                                                                <asp:image runat="server" id="imgApp" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                                              </CellTemplate>
                                                                              <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                              </Footer>
                                                                            </ig:TemplatedColumn>
                                                                        </Columns>
                                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                        </RowTemplateStyle>
                                                                    </ig:UltraGridBand>
                                                                </Bands>
                                                                 <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="Yes"
                                                                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                                        HeaderClickActionDefault="NotSet" Name="ugrdKpiList" RowHeightDefault="20px" HeaderStyleDefault-Height="35px"
                                                                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                                        <%--<GroupByBox>
                                                                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                                        </GroupByBox>
                                                                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                        </GroupByRowStyleDefault>
                                                                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                        </FooterStyleDefault>
                                                                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                            <Padding Left="3px" />
                                                                        </RowStyleDefault>
                                                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                                        </HeaderStyleDefault>
                                                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                        </EditCellStyleDefault>
                                                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                                            Width="100%">
                                                                        </FrameStyle>
                                                                        <Pager>
                                                                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                        </Style>
                                                                        </Pager>
                                                                        <AddNewBox Hidden="False">
                                                                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                        </Style>
                                                                        </AddNewBox>
                                                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                        </SelectedRowStyleDefault>--%>
                                                                        <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdKpiList_DblClickHandler" />
                                                                        
                                                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                    </DisplayLayout>
                                                            </ig:UltraWebGrid>
                                                        </td>
                                                      </tr>
                                                      <tr class="cssPopTblBottomSpace"><td>&nbsp;</td></tr>
                                                      <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder">
                                                              <tbody>
                                                                <tr>
                                                                  <td class="cssTblTitle"><%=this.GetText("LBL_00001", "챔피언") %></td>
                                                                  <td class="cssTblContent">
                                                                     <asp:TextBox id="txtChamName" CssClass="box01" runat="server" width="100%"></asp:TextBox>
                                                                  </td>
                                                                  <td class="cssTblTitle" ><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                                                                  <td class="cssTblContent"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                  <td class="cssTblTitle">KPI 명</td>
                                                                  <td class="cssTblContent"><asp:TextBox id="txtKPIName" runat="server" width="100%"></asp:TextBox> </td>
                                                                  <td class="cssTblTitle">지표유형</td>
                                                                  <td class="cssTblContent"><asp:dropdownlist id="ddlKpiGroupRefID" class="box01" runat="server" width="100%"></asp:dropdownlist></td>
                                                                </tr>
                                                                <tr>
                                                                  <td class="cssTblTitle">운영조직</td>
                                                                  <td class="cssTblContent" style="border-right:none;">
                                                                    <asp:dropdownlist id="ddlEstDept" CssClass="box01" runat="server" width="100%"></asp:dropdownlist>
                                                                    <asp:dropdownlist id="ddlResultInput" CssClass="box01" runat="server" width="99%" visible="false"></asp:dropdownlist>
                                                                  </td>
                                                                  <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                                                  <td class="cssTblContent">&nbsp;</td>
                                                                </tr>
                                                              </tbody>
                                                            </table>
                                                        </td>
                                                      </tr>
                                                      <tr class="cssPopBtnLine">
                                                        <td>
                                                            <asp:ImageButton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;
                                                        </td>
                                                      </tr>
                                                    </table>                             
                                                  </ContentTemplate>
                                              </ig:Tab>
                                              <ig:TabSeparator>
                                                <Style Width="1px"></Style>
                                              </ig:TabSeparator>
                                              <ig:Tab Text="지표트리" Key="2">
                                                <Style Width="100px"  Height="25px" />
                                                  <ContentTemplate>
                                                      <asp:Panel ID="pnlTreeKpi" runat="server" Height="100%" Width="100%" ScrollBars="auto" Visible="true">
                                                          <ig:UltraWebGrid ID="ugrdChildKpiTarget" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdChildKpiTarget_InitializeLayout" OnInitializeRow="ugrdChildKpiTarget_InitializeRow" >
                                                            <Bands>
                                                                <ig:UltraGridBand>
                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                    </AddNewRow>
                                                                    <Columns>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="40px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                                            <Header Caption="KPI 코드">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="WhiteSmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="150px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI 명">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left" BackColor="WhiteSmoke" />
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_LEVEL" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="L" Key="KPI_LEVEL" Width="20px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="L">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left" BackColor="WhiteSmoke" />
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="UP_KPI_WEIGHT" EditorControlID="" FooterText="" AllowUpdate="No"
                                                                            Format="" HeaderText="가중치" Key="UP_KPI_WEIGHT" DataType="System.Double" NullText="0" Width="60px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="가중치">
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="WhiteSmoke" />
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="100px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="운영조직">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left" BackColor="WhiteSmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="50px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI담당자">
                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="WhiteSmoke">
                                                                            </CellStyle>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="단위">
                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="WhiteSmoke">
                                                                            </CellStyle>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID="" Hidden="false"
                                                                            FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="실적방식">
                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="WhiteSmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID="" Width="35px" FooterText="" HeaderText="APP_STATUS">
                                                                          <Header Caption="결재상태">
                                                                            <RowLayoutColumnInfo OriginX="10" />
                                                                          </Header>
                                                                          <HeaderStyle Wrap="True" />
                                                                          <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                          <CellTemplate>
                                                                            <asp:image runat="server" id="imgApp" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                                          </CellTemplate>
                                                                          <Footer Caption="">
                                                                            <RowLayoutColumnInfo OriginX="10" />
                                                                          </Footer>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_01" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="01월" Key="TARGET_MS_01" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="01월">
                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_02" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="02월" Key="TARGET_MS_02" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="02월">
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_03" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="03월" Key="TARGET_MS_03" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="03월">
                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_04" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="04월" Key="TARGET_MS_04" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="04월">
                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_05" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="05월" Key="TARGET_MS_05" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="05월">
                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_06" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="06월" Key="TARGET_MS_06" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="06월">
                                                                                <RowLayoutColumnInfo OriginX="16" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="16" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_07" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="07월" Key="TARGET_MS_07" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="07월">
                                                                                <RowLayoutColumnInfo OriginX="17" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="17" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_08" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="08월" Key="TARGET_MS_08" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="08월">
                                                                                <RowLayoutColumnInfo OriginX="18" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="18" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_09" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="09월" Key="TARGET_MS_09" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="09월">
                                                                                <RowLayoutColumnInfo OriginX="19" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="19" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_10" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="10월" Key="TARGET_MS_10" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="10월">
                                                                                <RowLayoutColumnInfo OriginX="20" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="20" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_11" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="11월" Key="TARGET_MS_11" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="11월">
                                                                                <RowLayoutColumnInfo OriginX="21" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="21" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS_12" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="12월" Key="TARGET_MS_12" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="12월">
                                                                                <RowLayoutColumnInfo OriginX="22" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="22" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_01" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="01월" Key="TARGET_TS_01" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="01월">
                                                                                <RowLayoutColumnInfo OriginX="23" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="23" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_02" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="02월" Key="TARGET_TS_02" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="02월">
                                                                                <RowLayoutColumnInfo OriginX="24" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="24" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_03" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="03월" Key="TARGET_TS_03" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="03월">
                                                                                <RowLayoutColumnInfo OriginX="25" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="25" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_04" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="04월" Key="TARGET_TS_04" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="04월">
                                                                                <RowLayoutColumnInfo OriginX="26" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="26" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_05" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="05월" Key="TARGET_TS_05" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="05월">
                                                                                <RowLayoutColumnInfo OriginX="27" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="27" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_06" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="06월" Key="TARGET_TS_06" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="06월">
                                                                                <RowLayoutColumnInfo OriginX="28" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="28" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_07" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="07월" Key="TARGET_TS_07" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="07월">
                                                                                <RowLayoutColumnInfo OriginX="29" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="29" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_08" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="08월" Key="TARGET_TS_08" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="08월">
                                                                                <RowLayoutColumnInfo OriginX="30" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="30" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_09" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="09월" Key="TARGET_TS_09" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="09월">
                                                                                <RowLayoutColumnInfo OriginX="31" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="31" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_10" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="10월" Key="TARGET_TS_10" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="10월">
                                                                                <RowLayoutColumnInfo OriginX="32" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="32" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_11" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="11월" Key="TARGET_TS_11" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="11월">
                                                                                <RowLayoutColumnInfo OriginX="33" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="33" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS_12" EditorControlID="" DataType="System.Double" Format="#,###,###,###,###,###,##0.####"
                                                                            FooterText="" HeaderText="12월" Key="TARGET_TS_12" Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="12월">
                                                                                <RowLayoutColumnInfo OriginX="34" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="34" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                            FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="ESTTERM_REF_ID">
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID="" NullText="0"
                                                                            FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI_REF_ID">
                                                                                <RowLayoutColumnInfo OriginX="35" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="35" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                    </Columns>
                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                    </RowTemplateStyle>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                             <DisplayLayout AllowColSizingDefault="Free" BorderCollapseDefault="Separate" UseFixedHeaders="true" StationaryMargins="Header" 
                                                                    HeaderClickActionDefault="SortSingle" Name="ugrdChildKpiTarget" RowHeightDefault="20px" CellClickActionDefault="RowSelect"
                                                                    RowSelectorsDefault="No" Version="4.00" TableLayout="Fixed" AutoGenerateColumns="False">
                                                                    <%--<GroupByBox>
                                                                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                                    </GroupByBox>
                                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                    </GroupByRowStyleDefault>
                                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                    </FooterStyleDefault>
                                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                        <Padding Left="3px" />
                                                                    </RowStyleDefault>
                                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="23px">
                                                                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                                    </HeaderStyleDefault>
                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                    </EditCellStyleDefault>
                                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                                        BorderWidth="0px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                                        Width="100%">
                                                                    </FrameStyle>
                                                                    <Pager>
                                                                    <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                    </Style>
                                                                    </Pager>
                                                                    <AddNewBox Hidden="False">
                                                                    <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                    </Style>
                                                                    </AddNewBox>
                                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                    </SelectedRowStyleDefault>--%>
                                                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdKpiList_DblClickHandler" />
                                                                    
                                                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                 <ActivationObject BorderColor="" BorderWidth="">
                                                                 </ActivationObject>
                                                                </DisplayLayout>
                                                          </ig:UltraWebGrid>
                                                      </asp:Panel>
                                                  </ContentTemplate>
                                              </ig:Tab>
                                        </Tabs>
                                        <DefaultTabStyle BackColor="White" CssClass="cssTabStyleOff"></DefaultTabStyle>
                                        <SelectedTabStyle CssClass="cssTabStyleOn" />
                                        <BorderDetails StyleRight="Solid" StyleBottom="Solid" />
                                        <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif" SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                                     </ig:UltraWebTab> 
                                  </td>
                                </tr>
                              </table>
                            </td>
                        </tr>
                        <tr class="cssPopBtnLine">
                            <td style="height:25px;" align="right">
                              <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                <tr>
                                  <td style="vertical-align:middle;" align="left" valign="middle">
                                    &nbsp;&nbsp;<asp:Literal ID="ltrAppLegend" runat="server" Text=""></asp:Literal> 
                                  </td>
                                  <td style="vertical-align:middle;" align="right">
                                      <asp:Label ID="lblCountRow" runat="server" Text=""></asp:Label>
                                      <img src="../images/btn/b_003.gif" alt="" style="cursor:hand; vertical-align:middle;" onclick="window.close();" />                          
                                  </td>
                                </tr>
                              </table>                  
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>            
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                            <td style="width:50%; background-color:#FFFFFF"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    </form>
</body>
</html>