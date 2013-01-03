<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl1113.aspx.cs" Inherits="ctl_ctl1113" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript" src="../_common/js/yahoo/scripts.js"></script>
<script type="text/javascript" src="../_common/js/yahoo/yahoo.js"></script>
<script type="text/javascript" src="../_common/js/yahoo/dom.js"></script>
<script type="text/javascript" src="../_common/js/yahoo/event.js"></script>
<script type="text/javascript" src="../_common/js/yahoo/container.js"></script>
<link type="text/css" rel="stylesheet" href="../_common/js/yahoo/container.css" />
<link type="text/css" rel="Stylesheet" href="../_common/js/yahoo/styles.css" />

<script  type="text/javascript">
function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    {
       var cell             = igtbl_getElementById(id);
       var row              = igtbl_getRowById(id);
       var band             = igtbl_getBandById(id);
       var active           = igtbl_getActiveRow(id);
       cell.style.cursor    = 'hand';
    }
}
</script>
<table border="0" cellpadding="0" cellspacing="2" width="100%" style="height: 100%;">
<tr>
<td valign="top" style="height: 100%;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
        <tr>
            <td style="height: 25px;">
                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="cssTblTitle">평가 기간</td>
                        <td class="cssTblContent" style="border-right:none;">
                            <asp:dropdownlist id="ddlEstTermInfo" CssClass="box01" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                        </td>
                        <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                        <td class="cssTblContent">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                    <tr valign="top">
                        <td style="width: 50%; height:100%;" valign="top">
                          <ig:UltraWebGrid ID="ugrdClose" runat="server" Height="100%" Width="100%" OnInitializeRow="ugrdClose_InitializeRow" OnClick="ugrdClose_Click">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="YM" HeaderText="마감월" Key="YM" Width="50px">
                                                <Header Caption="마감월">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" />
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CLOSING_RATE" Key="CLOSING_RATE" HeaderText="마감율" Width="60px">
                                                <Header Caption="마감율">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="RELEASE_YN" Key="RELEASE_YN" HeaderText="게시여부" Width="35px">
                                                <Header Caption="게시여부">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" Wrap="true" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="INTERFACE_YN" Key="INTERFACE_YN" HeaderText="실적I/F" Width="35px">
                                                <Header Caption="실적I/F">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" Wrap="true" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CLOSE_YN" Key="CLOSE_YN" HeaderText="마감여부" Width="35px">
                                                <Header Caption="실적마감">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" Wrap="true" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="NORMDIST_YN" Key="NORMDIST_YN" HeaderText="NORMDIST_YN" Width="35px">
                                                <Header Caption="등급산출">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" Wrap="true" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="APPLY_EXT_SCORE_YN" Key="APPLY_EXT_SCORE_YN" HeaderText="APPLY_EXT_SCORE_YN" Width="35px">
                                                <Header Caption="외부평가">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" Wrap="true" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CLOSING_DATE" Key="CLOSING_DATE" Format="YYYY-MM-DD" HeaderText="마감일자" Width="70px">
                                                <Header Caption="마감일자">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="UPDATE_USER_NAME" Key="UPDATE_USER_NAME" HeaderText="처리자" Width="60px" Hidden="true">
                                                <Header Caption="처리자">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <HeaderStyle HorizontalAlign ="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                <Header Caption="ESTTERM_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Hidden="true" Key="YMD">
                                                <Header Caption="YMD">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" 
                                                AllowColSizingDefault="Free" 
                                                BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" 
                                                Name="ugrdClose" 
                                                RowHeightDefault="20px" 
                                                SelectTypeRowDefault="Extended" 
                                                Version="4.00" 
                                                AutoGenerateColumns="False" 
                                                CellClickActionDefault="RowSelect" 
                                                OptimizeCSSClassNamesOutput="False"
                                                RowSelectorsDefault="No">
                                    <%--<GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="40px">
                                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                        Width="100%">
                                    </FrameStyle>
                                    <Pager>
                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </PagerStyle>
                                    </Pager>
                                    <AddNewBox Hidden="False">
                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                              <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </BoxStyle>
                                    </AddNewBox>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />--%>
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Cursor="Hand"></FrameStyle>
                                    <Images>
                                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                        <td></td>
                        <td align="right" style="width:48%; height: 100%;" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder" style="height:100%;">
                                <tr>
                                    <td style="width:100px; height: 19px;" class="cssTblTitle">
                                        기간명</td>
                                    <td class="cssTblContent" style="height: 19px">
                                       <asp:textbox id="txtEstTermName" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        마감월</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtCloseMM" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        IF여부</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtIFYn" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        I/F일자</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtIFDate" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        I/F 처리자</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtIFUser" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
                                </tr>
                                <tr style="height:50%;">
                                    <td class="cssTblTitle">
                                        I/F 처리<br />기타사항</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtIFDesc" runat="server" Height="90px" TextMode="MultiLine" Width="100%"></asp:textbox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        마감여부</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtCloseYN" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        마감일자</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtCloseDate" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        마감자</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtCloseUser" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
                                </tr>
                                <tr style="height:50%;">
                                    <td class="cssTblTitle">
                                        마감처리<br />기타사항</td>
                                    <td class="cssTblContent">
                                        <asp:textbox id="txtEtc" runat="server" Height="90px" TextMode="MultiLine" Width="100%"></asp:textbox>
                                    </td>
                                </tr>
                            </table>
                            <asp:hiddenfield id="hdnTermID" runat="server"></asp:hiddenfield>
                            <asp:hiddenfield id="hdnTermMM" runat="server"></asp:hiddenfield>
                        </td>
                    </tr>
                    <tr valign="bottom">
                        <td colspan="3" style="height:30px;" align="right" valign="bottom">&nbsp;
                            <asp:imagebutton id="imgBtnRelease" runat="server" imageurl="../images/btn/b_134.gif" OnClick="imgBtnRelease_Click" Visible="false" ></asp:imagebutton>
                            <asp:imagebutton id="imgBtnInterface" runat="server" imageurl="../images/btn/b_055.gif" OnClick="imgBtnInterface_Click" Visible="false"></asp:imagebutton>
                            <asp:imagebutton id="imgBtnCancel" runat="server" imageurl="../images/btn/b_078.gif" OnClick="imgBtnCancel_Click" Visible="false"></asp:imagebutton>
                            <asp:ImageButton ID="imgBtnCalc" runat="server" Imageurl="../images/btn/b_014.gif" OnClick="imgBtnCalc_Click" Visible="false" />
                            <asp:imagebutton id="imgBtnClose" runat="server" imageurl="../images/btn/b_077.gif" OnClick="imgBtnClose_Click" Visible="false"></asp:imagebutton>
                            <asp:imagebutton id="imgBtnNormDist" runat="server" imageurl="../images/btn/b_028.gif" OnClick="imgBtnNormDist_Click" Visible="false" ></asp:imagebutton>
                            <asp:imagebutton id="imgBtnApplyExt" runat="server" imageurl="../images/btn/b_053.gif" OnClick="imgBtnApplyExt_Click" Visible="false" ></asp:imagebutton>
                            <asp:imagebutton id="imgBtnPrint" runat="server" imageurl="../images/btn/b_213.gif" OnClick="imgBtnPrint_Click" Visible="false" ></asp:imagebutton>
                            <asp:imagebutton id="ImgBtnPrintNorm" runat="server" imageurl="../images/btn/b_212.gif" OnClick="imgBtnPrintNorm_Click" Visible="true" ></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        <asp:literal id="ltlMsg" runat="server"></asp:literal>
        <ig:ultrawebgrid id="ugrdKpiScore" runat="server" Width="100%" Height="100%" Visible="false">
                <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single"
                    ViewType="Hierarchical" SelectTypeCellDefault="Extended" BorderCollapseDefault="NotSet" AllowColSizingDefault="Free"
                    Name="ugrdScoreCard" TableLayout="Fixed" SelectTypeColDefault="Extended" CellClickActionDefault="RowSelect">
                    <AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver" View="Compact">
                        <BoxStyle BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </BoxStyle>
                        <ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></ButtonStyle>
                    </AddNewBox>

                    <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif" BorderStyle="Solid" HorizontalAlign="Center"
                        ForeColor="White" BackColor="#94BAC9">
                        <Padding Left="0px" Right="0px"></Padding>
                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </HeaderStyleDefault>
                    <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
                    <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                    <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                        BorderStyle="Solid" BackColor="#FAFCF1" Height="100%"></FrameStyle>
                    <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </FooterStyleDefault>
                    <ActivationObject BorderColor="170, 184, 131"></ActivationObject>
                    <GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
                        <BoxStyle BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
                        </BoxStyle>
                        <BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
                    </GroupByBox>
                    <RowExpAreaStyleDefault BackColor="WhiteSmoke"></RowExpAreaStyleDefault>
                    <EditCellStyleDefault VerticalAlign="Middle" BorderWidth="0px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderStyle="None"
                        HorizontalAlign="Left"></EditCellStyleDefault>
                    <SelectedRowStyleDefault ForeColor="White" BackColor="#BECA98"></SelectedRowStyleDefault>
                    <SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="#CF5F5B"></SelectedGroupByRowStyleDefault>
                    <RowStyleDefault VerticalAlign="Middle" BorderWidth="1px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderColor="#AAB883"
                        BorderStyle="Solid" HorizontalAlign="Left" ForeColor="#333333" BackColor="White">
                        <Padding Left="3px" Right="3px"></Padding>
                        <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                    </RowStyleDefault>
                    <ImageUrls CurrentEditRowImage="../images/tree/arrow_brown.gif" ExpandImage="../images/tree/ig_treePlus.gif"
                        CollapseImage="../images/tree/ig_treeMinus.gif" CurrentRowImage="../images/tree/arrow_brown.gif"></ImageUrls>
                    <ClientSideEvents DblClickHandler="AfterSelectChangeHandler"  />
                </DisplayLayout>
                <Bands>
                    <ig:UltraGridBand AddButtonCaption="Column0Column1Column2" Key="Column0Column1Column2">
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                    </ig:UltraGridBand>
                </Bands>
            </ig:ultrawebgrid>    
        <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnRowExporting="ugrdEEP_RowExporting">
        </ig:UltraWebGridExcelExporter>
</td>
</tr>
</table>
</asp:Content>