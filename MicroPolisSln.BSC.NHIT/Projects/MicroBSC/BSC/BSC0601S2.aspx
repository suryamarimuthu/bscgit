<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="BSC0601S2.aspx.cs"
    Inherits="BSC_BSC0601S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script id="Infragistics" type="text/javascript">
        function OpenPreviewWindow() {
            var Dicode = "";
            var ICCB1 = "<%= this.ICCB1 %>";

            var strURL = 'BSC0601S1.aspx?iType=P&DICODE=' + Dicode + '&CCB1=' + ICCB1;

            gfOpenWindow(strURL, 780, 580, 'BSC0601S1');

            return false;
        }

        function openInstWindow() {
            var ICCB1 = "<%= this.ICCB1 %>";
            var url = "BSC0601M1.aspx?iType=A&DICODE=''&CCB1=" + ICCB1;

            gfOpenWindow(url, 880, 680, 'yes', 'no', 'BSC0601M1');
            return false;
        }

        function ugrdDicode_DblClickHandler(gridName, cellId) {
            var cell = igtbl_getElementById(cellId);
            var row = igtbl_getRowById(cellId);
            var dicode = row.getCellFromKey("DICODE").getValue();
            var ICCB1 = "<%= this.ICCB1 %>";

            var url = 'BSC0601M1.aspx?iType=U&DICODE=' + dicode + '&CCB1=' + ICCB1;
            gfOpenWindow(url, 880, 680, 'yes', 'no', 'BSC0601M1');
        }

        function SetDicode(sCode, sName) {
            var objKey = eval("opener.document.forms[0]." + "<%= this.IObjKey %>");
            var objVal = eval("opener.document.forms[0]." + "<%= this.IObjVal %>");

            if (objKey != null && objVal != null) {
                objKey.value = sCode;
                objVal.value = sName;

                if (opener) opener.__doPostBack("<%= this.ICCB1 %>", '');
            }
            else {
                alert('객체를 찾을수 없습니다.');
            }
            window.close();
            return false;
        }
    </script>

    <!--- MAIN START --->
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
        <tr id="pnlPTitle" runat="server" visible="false">
            <td valign="top" style="height: 40px; background-image: url(../images/title/popup_t_bg.gif);">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="lblPopUpTitle" runat="server" Text="Data Interface Code" CssClass="cssPopTitleTxt"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            <img alt="" src="../images/title/popup_img.gif" />
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
        <tr class="cssPopContent" id="popContent" runat="server">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td>
                            <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="cssTblTitle">
                                        DICode
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtsCode" Width="100%" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="cssTblTitle">
                                        코드명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtsName" Width="100%" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td align="right">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19px" ImageUrl="../images/btn/b_033.gif"
                                OnClick="iBtnSearch_Click"></asp:ImageButton>
                        </td>
                    </tr>
                    <tr style="height: 100%">
                        <td>
                            <ig:UltraWebGrid ID="ugrdDicode" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdDicode_InitializeLayout"
                                OnInitializeRow="ugrdDicode_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:TemplatedColumn BaseColumnName="SELECT" DataType="System.String" EditorControlID=""
                                                FooterText="" Format="" HeaderText="SELECT" Key="SELECT" Width="30px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="선택">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <CellTemplate>
                                                    <asp:ImageButton ID="ibtnSel" runat="server" ImageUrl="../images/drafts.gif" />
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="SOURCE_NAME" DataType="System.String" EditorControlID=""
                                                FooterText="" Format="" HeaderText="SOURCE_NAME" Key="SOURCE_NAME" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="SOURCE NAME">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="INPUT_TYPE" DataType="System.String" EditorControlID=""
                                                FooterText="" Format="" HeaderText="INPUT_TYPE" Key="INPUT_TYPE" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="INPUT TYPE">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DICODE" DataType="System.String" EditorControlID=""
                                                FooterText="" Format="" HeaderText="DICODE" Key="DICODE" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="DICODE">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="NAME" HeaderText="NAME" Hidden="false" Key="NAME"
                                                Width="150px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="코드명">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEFINITION" HeaderText="DEFINITION" Hidden="false"
                                                Key="DEFINITION" Width="350px" CellMultiline="No">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="정의">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="USE_YN" HeaderText="USE_YN" Hidden="false" Key="USE_YN"
                                                Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="사용">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer"
                                    AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" Name="ugrdDicode" RowHeightDefault="22px"
                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat"
                                    CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                                    AutoGenerateColumns="False" OptimizeCSSClassNamesOutput="False">
                                    <%--<GroupByBox>
                            <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand" TextOverflow="Clip" Wrap="true">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="2px" />
                        </RowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                        </SelectedRowStyleDefault>--%>
                                    <HeaderStyleDefault CssClass="GridHeaderStyle">
                                    </HeaderStyleDefault>
                                    <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                    <RowStyleDefault CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                    </SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                    </RowAlternateStyleDefault>
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                    </FrameStyle>
                                    <ClientSideEvents DblClickHandler="ugrdDicode_DblClickHandler" />
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton runat="server" ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif"
                                ImageAlign="AbsMiddle" OnClientClick="return openInstWindow();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="pnlPTitle2" runat="server" visible="false">
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFC600">
                        </td>
                        <td style="width: 50%; background-color: #00549C">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:LinkButton ID="lBtnReload" runat="server" Visible="false" OnClick="lBtnReload_Click"></asp:LinkButton>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <!--- MAIN END --->
</asp:Content>
