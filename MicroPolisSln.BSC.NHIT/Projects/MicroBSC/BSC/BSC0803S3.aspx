<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0803S3.aspx.cs" Inherits="BSC_BSC0803S3" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

</head>
<body style="margin: 0,0,0,0;">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif); height: 40px;">
                        <td style="width: 170px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="lblPopUpTitle" runat="server" CssClass="cssPopTitleTxt" Text="평가의견"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            <img src="../images/title/popup_img.gif" alt="" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <div id="divAreaPopUp" runat="server" style="height: 100%; width: 100%; display: inline;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                        <tr style="height: 100%;">
                            <td>
                                <ig:UltraWebGrid ID="ugrdEstOpinion" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdEstOpinion_InitializeRow">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:TemplatedColumn Hidden="false" Key="EST_LEVEL_NAME" BaseColumnName="EST_LEVEL_NAME"
                                                    Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="차수명">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="center">
                                                    </CellStyle>
                                                    <CellTemplate>
                                                        <asp:Label ID="lblEST_LEVEL_NAME" runat="server"></asp:Label><br />
                                                        <asp:ImageButton ID="iBtnReviewFile" runat="server" ImageUrl="../images/icon/icon_gr_po04.gif" />
                                                        <asp:HiddenField ID="iHdfReviewFile" runat="server" Value="" />
                                                    </CellTemplate>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="OPINION" Key="OPINION" Width="430px" HeaderText="OPINION"
                                                    CellMultiline="Yes" AllowUpdate="Yes">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="평가의견">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left" Wrap="true" TextOverflow="Clip" VerticalAlign="top">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="REVIEW_FILE_ID" Key="REVIEW_FILE_ID" Width="390px"
                                                    HeaderText="REVIEW_FILE_ID" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="REVIEW_FILE_ID">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer"
                                        AllowDeleteDefault="NotSet" AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="SortMulti" Name="ugrdEstOpinion" RowHeightDefault="20px"
                                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="Edit"
                                        TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                        <%--<GroupByBox>
                                            <style backcolor="ActiveBorder" bordercolor="Window">
                                                </style>
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
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center"
                                            BorderColor="#E5E5E5" ForeColor="White" Height="20">
                                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="0px"
                                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="430px" Width="100%">
                                        </FrameStyle>
                                        <Pager>
                                            <style backcolor="LightGray" borderstyle="Solid" borderwidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" />
                                            </style>
                                        </Pager>
                                        <AddNewBox Hidden="False">
                                            <style backcolor="Window" bordercolor="InactiveCaption" borderstyle="Solid" borderwidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" />
                                            </style>
                                        </AddNewBox>
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>--%>
                                        <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="DblClickHandler" />
                                        <RowStyleDefault CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                        </SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                        </RowAlternateStyleDefault>
                                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                                        </HeaderStyleDefault>
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                        </FrameStyle>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                        </tr>
                        <tr class="cssPopBtnLine">
                            <td>
                                <img src="../images/btn/b_003.gif" alt="" onclick="self.close();" style="cursor: hand;
                                    vertical-align: baseline;" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
