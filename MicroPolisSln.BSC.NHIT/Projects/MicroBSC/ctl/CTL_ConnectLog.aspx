<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CTL_ConnectLog.aspx.cs" Inherits="CTL_ConnectLog"
    MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script id="Infragistics" type="text/javascript">

        function MouseOverHandler(gridName, id, objectType) {

        }

        function UltraWebGrid1_DblClickHandler(gridName, id) {
        }

        function OpenEstDept() {
            var dept_Ctl1 = "<%= txtDeptName.ClientID%>";
            var dept_Ctl2 = "<%= txtDeptID.ClientID%>";
            var url = 'ctl2102.aspx?DeptNM=' + dept_Ctl1 + "&DeptID=" + dept_Ctl2;
            gfOpenWindow(url, 310, 400);
        }
        function PopUpCllFunction(deptId, deptName) {
            document.getElementById("<%= txtDeptID.ClientID%>").value = deptId;
            document.getElementById("<%= txtDeptName.ClientID%>").value = deptName;
        }

    </script>

    <!--- MAIN START --->
    <table width="100%" height="100%">
        <tr>
            <td height="20">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="cssTblTitle">
                                        조직
                                    </td>
                                    <td class="cssTblContent">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtDeptName" runat="server" Width="100%"></asp:TextBox>
                                                    <asp:TextBox ID="txtDeptID" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                </td>
                                                <td style="width: 59px;">
                                                    <img alt="" src='../images/btn/b_094.gif' align="absmiddle" onclick="OpenEstDept();"
                                                        style="cursor: hand;" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="cssTblTitle">
                                        사용자
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtUserNM" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        검색일자
                                    </td>
                                    <td class="cssTblContent" style="border-right: none;">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 45%;">
                                                    <ig:WebDateChooser ID="wdcSDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false"
                                                        Width="100%">
                                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False">
                                                        </CalendarLayout>
                                                    </ig:WebDateChooser>
                                                </td>
                                                <td style="width: 10%;" align="center">
                                                    ~
                                                </td>
                                                <td style="width: 45%;" align="left">
                                                    <ig:WebDateChooser ID="wdcEDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false"
                                                        Width="100%">
                                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False">
                                                        </CalendarLayout>
                                                    </ig:WebDateChooser>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="cssTblContent" style="width: 15%; border-left: none; border-right: none;">
                                        &nbsp;
                                    </td>
                                    <td class="cssTblContent">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 25px;">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                <tr>
                                    <td>
                                        <img align='absmiddle' src='../Images/etc/lis_t01.gif' />
                                        <asp:Label ID="lblRowCount" runat="server" Text="0"></asp:Label>
                                        <img align='absmiddle' src='../Images/etc/lis_t02.gif' />
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif"
                                            OnClick="iBtnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <ig:UltraWebGrid ID="ugrdResultStatus" runat="server" Width="100%" Height="100%"
                    OnPreRender="ugrdResultStatus_PreRender" InitializeLayout="ugrdResultStatus_InitializeLayout"
                    OnInitializeRow="ugrdResultStatus_InitializeRow" OnPageIndexChanged="ugrdResultStatus_PageIndexChanged">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn Width="40px" BaseColumnName="RN" HeaderText="RN" Hidden="True"
                                    Key="RN">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="NO.">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="성명">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME" MergeCells="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="부서">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CONNECT_IP" EditorControlID="" FooterText=""
                                    Format="" HeaderText="IP" Key="CONNECT_IP" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="IP">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="START_DT" EditorControlID="" FooterText="" Format=""
                                    HeaderText="접속시간" Key="START_DT" Width="180px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="접속시간">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="END_DT" HeaderText="종료시간" Key="END_DT" Width="180px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="종료시간">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate" AutoGenerateColumns="False"
                        HeaderClickActionDefault="SortMulti" Name="ugrdResultStatus" RowHeightDefault="20px"
                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat"
                        CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                        OptimizeCSSClassNamesOutput="False">
                        <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
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
                            <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                            Width="100%">
                        </FrameStyle>

                        <Pager PagerAppearance="Bottom" PageSize="20"
                            Alignment="Center"  AllowPaging="True" StyleMode="PrevNext" >
                        <Style BorderWidth="1px" BorderStyle="None" ForeColor="RoyalBlue" BackColor="LightGray" Height="20px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </Style>
                        </Pager>
                        <AddNewBox Hidden="False">
                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </Style>
                        </AddNewBox>
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>--%>
                        <GroupByBox>
                            <style backcolor="WhiteSmoke" bordercolor="Window">
                                </style>
                        </GroupByBox>
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
                        <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="UltraWebGrid1_DblClickHandler" />
                        <Pager PagerAppearance="Bottom" PageSize="20" Alignment="Center" AllowPaging="True"
                            StyleMode="PrevNext">
                            <%--<Style BorderWidth="1px" BorderStyle="None" ForeColor="RoyalBlue" BackColor="LightGray" Height="20px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </Style>--%>
                        </Pager>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    <!--- MAIN END --->
</asp:Content>
