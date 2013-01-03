<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4301.aspx.cs" Inherits="ctl_ctl4301" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

       <!--- MAIN START --->
         <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
           <tr>
             <td style="width:33%;">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="대분류 등록" />
                        </td>
                    </tr>
                </table>
             </td>
             <td style="width:33%;">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="Label1" runat="server" style="font-weight:bold" text="중분류 등록" />
                        </td>
                    </tr>
                </table>
             </td>
             <td style="width:34%;">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="Label2" runat="server" style="font-weight:bold" text="소분류 등록" />
                        </td>
                    </tr>
                </table>
             </td>
           </tr>
           <tr style="height:100%;">
             <td>
                <ig:UltraWebGrid ID="ugrdCategoryTop" runat="server" Height="100%" Width="100%" OnInitializeRow="ugrdCategoryTop_InitializeRow" OnActiveRowChange="ugrdCategoryTop_ActiveRowChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn Hidden="True" Key="selchk" Width="20px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" />
                                    </CellTemplate>
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="ITYPE" Hidden="True" Key="ITYPE"
                                    Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="ITYPE">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_TOP_REF_ID" HeaderText="CATEGORY_TOP_REF_ID"
                                    Hidden="True" Key="CATEGORY_TOP_REF_ID" Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="CATEGORY_TOP_REF_ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_TOP_NAME" EditorControlID="" FooterText="" AllowUpdate="No"
                                    Format="" HeaderText="분류명" Key="CATEGORY_TOP_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="분류명" Title="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="USE_YN" EditorControlID="" FooterText="" Format="" AllowUpdate="No"
                                    HeaderText="USE" Key="USE_YN" Width="32px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="USE" Title="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="NotSet"
                        Name="ugrdCategoryTop" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                        Version="4.00" CellClickActionDefault="RowSelect" AllowUpdateDefault="Yes">
                        <%--<GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                            ForeColor="White" Height="30px" HorizontalAlign="Left">
                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand"
                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                        </FrameStyle>
                        <Pager>
                            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </PagerStyle>
                        </Pager>
                        <AddNewBox Hidden="False" Prompt="행추가">
                            <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </BoxStyle>
                            <ButtonStyle BorderStyle="Outset" Cursor="Hand" Height="20px" Width="20px">
                            </ButtonStyle>
                        </AddNewBox>
                        <AddNewRowDefault>
                            <Style BackColor="#FFC0C0" BorderColor="#FFE0C0" BorderStyle="Solid" BorderWidth="1px"
                                ForeColor="Blue"></Style>
                        </AddNewRowDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>--%>
                        
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
             </td>
             <td>
                <ig:UltraWebGrid ID="ugrdCategoryMid" runat="server" Height="100%" Width="100%" OnInitializeRow="ugrdCategoryMid_InitializeRow" OnActiveRowChange="ugrdCategoryMid_ActiveRowChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn Hidden="True" Key="selchk" Width="20px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" />
                                    </CellTemplate>
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="ITYPE" Hidden="True" Key="ITYPE"
                                    Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="ITYPE">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_TOP_REF_ID" HeaderText="CATEGORY_TOP_REF_ID"
                                    Hidden="True" Key="CATEGORY_TOP_REF_ID" Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="CATEGORY_TOP_REF_ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_MID_REF_ID" HeaderText="CATEGORY_MID_REF_ID"
                                    Hidden="True" Key="CATEGORY_MID_REF_ID" Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="CATEGORY_MID_REF_ID">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_MID_NAME" EditorControlID="" FooterText="" AllowUpdate="No"
                                    Format="" HeaderText="분류명" Key="CATEGORY_MID_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="분류명" Title="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="USE_YN" EditorControlID="" FooterText="" Format="" AllowUpdate="No"
                                    HeaderText="USE" Key="USE_YN" Width="32px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="USE" Title="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="NotSet"
                        Name="ugrdCategoryMid" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                        Version="4.00" CellClickActionDefault="RowSelect" AllowUpdateDefault="Yes">
                        <%--<GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                            ForeColor="White" Height="30px" HorizontalAlign="Left">
                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand"
                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                        </FrameStyle>
                        <Pager>
                            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </PagerStyle>
                        </Pager>
                        <AddNewBox Hidden="False" Prompt="행추가">
                            <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </BoxStyle>
                            <ButtonStyle BorderStyle="Outset" Cursor="Hand" Height="20px" Width="20px">
                            </ButtonStyle>
                        </AddNewBox>
                        <AddNewRowDefault>
                            <RowStyle BackColor="#FFC0C0" BorderColor="#FFE0C0" BorderStyle="Solid" BorderWidth="1px"
                                ForeColor="Blue"></RowStyle>
                        </AddNewRowDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>--%>
                        
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
             </td>
             <td>
                <ig:UltraWebGrid ID="ugrdCategoryLow" runat="server" Height="100%" Width="100%" OnInitializeRow="ugrdCategoryLow_InitializeRow" OnActiveRowChange="ugrdCategoryLow_ActiveRowChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn Hidden="True" Key="selchk" Width="20px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" />
                                    </CellTemplate>
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="ITYPE" Hidden="True" Key="ITYPE"
                                    Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="ITYPE">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_TOP_REF_ID" HeaderText="CATEGORY_TOP_REF_ID"
                                    Hidden="True" Key="CATEGORY_TOP_REF_ID" Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="CATEGORY_TOP_REF_ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_MID_REF_ID" HeaderText="CATEGORY_MID_REF_ID"
                                    Hidden="True" Key="CATEGORY_MID_REF_ID" Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="CATEGORY_MID_REF_ID">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_LOW_REF_ID" HeaderText="CATEGORY_LOW_REF_ID"
                                    Hidden="True" Key="CATEGORY_LOW_REF_ID" Width="58px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="CATEGORY_LOW_REF_ID">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                    <CellStyle VerticalAlign="Top">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_LOW_NAME" EditorControlID="" FooterText="" AllowUpdate="No"
                                    Format="" HeaderText="분류명" Key="CATEGORY_LOW_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="분류명" Title="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="USE_YN" EditorControlID="" FooterText="" Format="" AllowUpdate="No"
                                    HeaderText="USE" Key="USE_YN" Width="32px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="USE" Title="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="NotSet"
                        Name="ugrdCategoryLow" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                        Version="4.00" CellClickActionDefault="RowSelect" AllowUpdateDefault="Yes">
                        <%--<GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                            ForeColor="White" Height="30px" HorizontalAlign="Left">
                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand"
                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                        </FrameStyle>
                        <Pager>
                            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </PagerStyle>
                        </Pager>
                        <AddNewBox Hidden="False" Prompt="행추가">
                            <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </BoxStyle>
                            <ButtonStyle BorderStyle="Outset" Cursor="Hand" Height="20px" Width="20px">
                            </ButtonStyle>
                        </AddNewBox>
                        <AddNewRowDefault>
                            <RowStyle BackColor="#FFC0C0" BorderColor="#FFE0C0" BorderStyle="Solid" BorderWidth="1px"
                                ForeColor="Blue"></RowStyle>
                        </AddNewRowDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>--%>
                        
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
           <tr>
             <td>
                <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                    <tr>
                        <td class="cssTblTitle">분류명</td>
                        <td class="cssTblContent">
                            <asp:textbox id="txtTopCatName" runat="server"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">기타사항</td>
                        <td class="cssTblContent">
                            <asp:textbox id="txtTopCatDesc" runat="server"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">사용여부</td>
                        <td class="cssTblContent">
                            <asp:checkbox id="chkTopUseYn" runat="server"></asp:checkbox>
                        </td>
                    </tr>
                </table>
             </td>
             <td>
                <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                    <tr>
                        <td class="cssTblTitle">분류명</td>
                        <td class="cssTblContent">
                            <asp:textbox id="txtMidCatName" runat="server"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">기타사항</td>
                        <td class="cssTblContent">
                            <asp:textbox id="txtMidCatDesc" runat="server"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">사용여부</td>
                        <td class="cssTblContent">
                            <asp:checkbox id="chkMidUseYn" runat="server"></asp:checkbox>
                        </td>
                    </tr>
                </table>
             </td>
             <td>
                <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                    <tr>
                        <td class="cssTblTitle">분류명</td>
                        <td class="cssTblContent">
                            <asp:textbox id="txtLowCatName" runat="server"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">기타사항</td>
                        <td class="cssTblContent">
                            <asp:textbox id="txtLowCatDesc" runat="server"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">사용여부</td>
                        <td class="cssTblContent">
                            <asp:checkbox id="chkLowUseYn" runat="server"></asp:checkbox>
                        </td>
                    </tr>
                </table>
             </td>
           </tr>
           <tr class="cssPopBtnLine">
             <td>
               <asp:imagebutton id="iBtnAddTop" runat="server" imageurl="../images/btn/b_001.gif" OnClick="iBtnAddTop_Click"></asp:imagebutton>
               <asp:imagebutton id="iBtnUdtTop" runat="server" imageurl="../images/btn/b_002.gif" OnClick="iBtnUdtTop_Click"></asp:imagebutton>
             </td>
             <td>
               <asp:imagebutton id="iBtnAddMid" runat="server" imageurl="../images/btn/b_001.gif" OnClick="iBtnAddMid_Click"></asp:imagebutton>
               <asp:imagebutton id="iBtnUdtMid" runat="server" imageurl="../images/btn/b_002.gif" OnClick="iBtnUdtMid_Click"></asp:imagebutton>
             </td>
             <td>
               <asp:imagebutton id="iBtnAddLow" runat="server" imageurl="../images/btn/b_001.gif" OnClick="iBtnAddLow_Click"></asp:imagebutton>
               <asp:imagebutton id="iBtnUdtLow" runat="server" imageurl="../images/btn/b_002.gif" OnClick="iBtnUdtLow_Click"></asp:imagebutton>
             </td>
           </tr>
         </table>
       <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
       <!--- MAIN END --->
</asp:Content>