<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0409S1.aspx.cs" Inherits="BSC_BSC0409S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script type="text/javascript" language="javascript" >
        function checkSearch() {
            var ddldicode = document.getElementById('<%= ddlDiCode.ClientID %>');
            if (ddldicode.options[ddldicode.selectedIndex].value == '') {
                alert('실적지표를 선택하세요!');
                return false;
            }
            return true;
        }
    </script>

    <!--- MAIN START --->
    <table width="100%" style="vertical-align: top;" border="0" cellpadding="0" cellspacing="2">
        <tr>
	        <td valign="top" style="height: 19px;" align="center">
	            <table border="0" cellpadding="0" cellspacing="0" width="970px" style="height: 100%;" class="tableBorder">
                    <tr>
                        <td class="tableTitle" align="center" style="width: 70px;">
                            실적년월
                        </td>
                        <td class="tableContent" style="width: 200px;">
                            <asp:DropDownList ID="ddlEstTerm" runat="server" CssClass="box01" Width="150px"></asp:DropDownList><asp:DropDownList ID="ddlMonth" runat="server" CssClass="box01" Width="50px"></asp:DropDownList>
                        </td>
                        <td class="tableTitle" align="center" style="width: 70px;">
                            실적지표
                        </td>
                        <td class="tableContent" style="width: 150px;">
                            <asp:DropDownList ID="ddlDiCode" runat="server" CssClass="box01" Width="100%"></asp:DropDownList>
                        </td>
                        <td class="tableTitle" align="center" style="width: 70px;">
                            실적유형
                        </td>
                        <td class="tableContent" style="width: 50px;">
                            <asp:DropDownList ID="ddlSumType" runat="server" CssClass="box01" Width="100%"></asp:DropDownList>
                        </td>
                        <td class="tableTitle" align="center" style="width: 70px;">
                            차트
                        </td>
                        <td class="tableContent" style="width: 120px;">
                            <asp:DropDownList ID="ddlChart" runat="server" CssClass="box01" Width="100%"></asp:DropDownList>
                        </td>
                        <td class="tableContent" align="right">
                            <asp:ImageButton ID="ibtnSearch" runat="server" OnClientClick="return checkSearch();" OnClick="ibtnSearch_Click" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-right: 5px; height: 19px;" align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="970px">
                    <tr>
                        <td>
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;일별실적증감추이
                        </td>
                        <td align="right">
                            <asp:Label ID="lblUnit" runat="server" ForeColor="SteelBlue"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 420px; padding: 1px;">
                <DCWC:Chart ID="chat1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="970px" Height="420px" >
                    <ChartAreas>
                        <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                <LabelStyle Font="Tahoma, 10px" />
                                <MajorGrid LineColor="196, 196, 196" />
                            </AxisX>
                            <Area3DStyle XAngle="10" YAngle="10" WallWidth="2"/>
                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                <LabelStyle Font="Tahoma, 10px" />
                                <MajorGrid LineColor="196, 196, 196" />
                            </AxisY>
                            <AxisX2 linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                <LabelStyle Font="Tahoma, 10px" />
                                <MajorGrid LineColor="196, 196, 196" />
                            </AxisX2>
                            <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                <LabelStyle Font="Tahoma, 10px" />
                                <MajorGrid LineColor="196, 196, 196" />
                            </AxisY2>
                        </DCWC:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <DCWC:Title Alignment="TopCenter" Font="Tahoma, 11px" Name="Title1">
                        </DCWC:Title>
                    </Titles>
                    <Legends>
                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="2"  Font="Dotum, 10px" AutoFitText="False">
                        </DCWC:Legend>
                    </Legends>
                    <Series>
                        <DCWC:Series ChartType="Area" Name="Series1" XValueType="Double" YValueType="Double">
                        </DCWC:Series>
                    </Series>
                </DCWC:Chart>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 100px; padding: 1px;">
                <ig:UltraWebGrid ID="ugrdResult" runat="server" Width="100%" Height="100%" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="YEARMONTH" Key="YEARMONTH" Width="70px" HeaderText="실적년월" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY01" Key="DAY01" Width="50px" HeaderText="1일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY02" Key="DAY02" Width="50px" HeaderText="2일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY03" Key="DAY03" Width="50px" HeaderText="3일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY04" Key="DAY04" Width="50px" HeaderText="4일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY05" Key="DAY05" Width="50px" HeaderText="5일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY06" Key="DAY06" Width="50px" HeaderText="6일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY07" Key="DAY07" Width="50px" HeaderText="7일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY08" Key="DAY08" Width="50px" HeaderText="8일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY09" Key="DAY09" Width="50px" HeaderText="9일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY10" Key="DAY10" Width="50px" HeaderText="10일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY11" Key="DAY11" Width="50px" HeaderText="11일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY12" Key="DAY12" Width="50px" HeaderText="12일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY13" Key="DAY13" Width="50px" HeaderText="13일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY14" Key="DAY14" Width="50px" HeaderText="14일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY15" Key="DAY15" Width="50px" HeaderText="15일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY16" Key="DAY16" Width="50px" HeaderText="16일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY17" Key="DAY17" Width="50px" HeaderText="17일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY18" Key="DAY18" Width="50px" HeaderText="18일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY19" Key="DAY19" Width="50px" HeaderText="19일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY20" Key="DAY20" Width="50px" HeaderText="20일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY21" Key="DAY21" Width="50px" HeaderText="21일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY22" Key="DAY22" Width="50px" HeaderText="22일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY23" Key="DAY23" Width="50px" HeaderText="23일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY24" Key="DAY24" Width="50px" HeaderText="24일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY25" Key="DAY25" Width="50px" HeaderText="25일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY26" Key="DAY26" Width="50px" HeaderText="26일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY27" Key="DAY27" Width="50px" HeaderText="27일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY28" Key="DAY28" Width="50px" HeaderText="28일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY29" Key="DAY29" Width="50px" HeaderText="29일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY30" Key="DAY30" Width="50px" HeaderText="30일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DAY31" Key="DAY31" Width="50px" HeaderText="31일" DataType="System.Double" Format="###,###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" 
                        AllowColumnMovingDefault="None" 
                        AllowDeleteDefault="No"
                        AllowSortingDefault="No" 
                        BorderCollapseDefault="Separate" 
                        AutoGenerateColumns="False" 
                        HeaderClickActionDefault="NotSet" 
                        Name="ugrdResult" 
                        RowHeightDefault="20px" 
                        ReadOnly="LevelTwo"
                        RowSelectorsDefault="No" 
                        SelectTypeRowDefault="Extended" 
                        Version="4.00" 
                        ViewType="OutlookGroupBy" 
                        CellClickActionDefault="RowSelect" 
                        TableLayout="Fixed" 
                        StationaryMargins="Header">
                            <GroupByBox>
                                <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
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
                                <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100px"
                                Width="970px">
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
                        <ClientSideEvents />
                        <ActivationObject >
                        </ActivationObject>
                        </DisplayLayout>
                </ig:UltraWebGrid>
                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <!--- MAIN END --->
 </asp:Content>
