<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="EST120100M1.aspx.cs"
    Inherits="EST120100M1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.3)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.3)" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" style="background-image: url(../images/title/popup_t_bg.gif); height: 40px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 180px; background-image: url(../images/title/popup_title.gif);"
                                        class="cssPopTitleArea">
                                        <asp:Label ID="Label2" runat="server" CssClass="cssPopTitleTxt" Text="본부/팀 가중치 설정"></asp:Label>
                                    </td>
                                    <td align="right" valign="top">
                                        <img alt="" src="../images/title/popup_img.gif" />
                                    </td>
                                </tr>
                            </table>
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
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;" class="tableBorder">
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        평가기간
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:DropDownList ID="ddlEstTermRefID" runat="server" CssClass="box01"></asp:DropDownList>
                                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01"></asp:dropdownlist>
                                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        직제구분
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:DropDownList ID="ddlEstPosInfo" runat="server" CssClass="box01">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" ImageUrl="../images/btn/b_033.gif"
                                OnClick="iBtnSearch_Click" />
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeLayout="UltraWebGrid1_InitializeLayout" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="POS_ID" Key="POS_ID" HeaderText="POS_ID" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="POS_VALUE" Key="POS_VALUE" HeaderText="코드" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="POS_VALUE_NAME" Key="POS_VALUE_NAME" HeaderText="명칭" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="WEIGHT" Key="WEIGHT" HeaderText="가중치" Hidden="true">
                                                <CellTemplate>
                                                    <ig:WebNumericEdit ID="WEIGHT" runat="server" DataMode="Double" MinValue="0" MaxValue="100" Width="100%" NullText="0"></ig:WebNumericEdit>
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="iWEIGHT_4" Key="iWEIGHT_4" HeaderText="본부 가중치" Width="80px">
                                                <CellTemplate>
                                                    <ig:WebNumericEdit ID="WEIGHT" runat="server" DataMode="Double" MinValue="0" MaxValue="100" Width="100%" NullText="0"></ig:WebNumericEdit>
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="iWEIGHT_7" Key="iWEIGHT_7" HeaderText="팀 가중치" Width="80px">
                                                <CellTemplate>
                                                    <ig:WebNumericEdit ID="WEIGHT" runat="server" DataMode="Double" MinValue="0" MaxValue="100" Width="100%" NullText="0"></ig:WebNumericEdit>
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="TOTAL_WEIGHT" Key="TOTAL_WEIGHT" HeaderText="합계(%)" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout RowHeightDefault="20px" AutoGenerateColumns="False" RowSelectorsDefault="No"
                                    ReadOnly="LevelTwo">
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
                            <asp:ImageButton ID="iBtnSave" runat="server" ImageUrl="/images/btn/b_tp07.gif" OnClick="iBtnSave_Click" />
                            <img src="../images/btn/b_003.gif" onclick="window.close();" style="cursor: pointer;" alt="닫기" />
                        </td>
                    </tr>
                </table>
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
        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </table>
    </form>
</body>
</html>
