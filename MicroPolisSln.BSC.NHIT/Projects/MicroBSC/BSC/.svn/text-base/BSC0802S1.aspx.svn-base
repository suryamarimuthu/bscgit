<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0802S1.aspx.cs" Inherits="BSC_BSC0802S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="DundasWebChart, Version=5.0.0.1692, Culture=neutral, PublicKeyToken=90d06b0c62d592d0"
    Namespace="Dundas.Charting.WebControl" TagPrefix="DCWC" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
  <table border="0" cellpadding="5" cellspacing="0" style="width:820px; height:100%;">
    <tr>
      <td style="height:25px;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width:100px;"><img src="../images/title/se_ti03.gif" alt="" /></td>
                <td style="height: 25px;" >
                    <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                </td>	
                <td style="width:100px;"><img src="../images/title/se_ti07.gif" alt="" /></td>
                <td style="width:220px;"><asp:dropdownlist id="ddlMonthInfo" runat="server" CssClass="box01"></asp:dropdownlist>
                    <asp:ImageButton ID="iBtnSearch" runat="server" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle" />
                    <asp:imagebutton id="iBtnPrint" runat="server" imageurl="../images/btn/b_080.gif" Visible="false"  onclick="iBtnPrint_Click" ImageAlign="AbsMiddle"></asp:imagebutton></td>
            </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td>
              <ig:UltraWebTab runat="server" ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="False" Width="100%" SelectedTab="1" AutoPostBack="True" OnTabClick="ugrdKpiStatusTab_TabClick">
                  <Tabs>
                      <ig:Tab Text="PartⅠ 평가현황" Key="1">
                        <Style Width="160px" Height="25px" ForeColor="Navy" Font-Bold="True" />
                          <ContentTemplate>
                             <ig:UltraWebGrid ID="ugrdEstStatus" runat="server" Width="100%" Height="99%" OnInitializeRow="ugrdEstStatus_InitializeRow" >
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="EST_LEVEL_NAME" Key="EST_LEVEL_NAME" Width="150px" HeaderText="EST_LEVEL_NAME" MergeCells="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="평가차수명">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="GROUP_NAME" Key="GROUP_NAME" Width="140px" HeaderText="GROUP_NAME" MergeCells="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="평가그룹명">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="80px" HeaderText="EMP_NAME">
                                                <Header Caption="평가자">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CNT_REG" Key="CNT_REG" Width="70px" HeaderText="CNT_REG">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="미평가">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CNT_DFT" Key="CNT_DFT" Width="70px" HeaderText="CNT_DFT">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="평가중">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CNT_CET" Key="CNT_CET" Width="70px" HeaderText="CNT_CET">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="평가완료">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CNT_ALL" Key="CNT_ALL" Width="70px" HeaderText="CNT_ALL">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="총평가수">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_RATE" Key="EST_RATE" Width="70px" HeaderText="EST_RATE" Format="##0.00%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="진행율">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="AVG_SCORE" Key="AVG_SCORE" Width="70px" HeaderText="AVG_SCORE" Format="##0.00">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="평균점수">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_LEVEL" Key="EST_LEVEL" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="11" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="11" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" Key="GROUP_REF_ID" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EST_EMP_ID" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderStyleDefault-Height="30px" HeaderStyleDefault-HorizontalAlign="Center"
                                        HeaderClickActionDefault="NotSet" Name="ugrdCommunicationOrg" RowHeightDefault="25px"
                                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                        <GroupByBox>
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
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" Cursor="Hand" 
                                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.5pt" Height="99%"
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
                                    <ClientSideEvents DblClickHandler="DblClickHandler" />
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>
                                    </DisplayLayout>
                            </ig:UltraWebGrid>
                          </ContentTemplate>
                      </ig:Tab>
                      <ig:TabSeparator>
                        <Style Width="3px"></Style>
                      </ig:TabSeparator>
                      <ig:Tab Text="PartⅡ 평가결과" Key="2">
                        <Style Width="160px"  Height="25px" ForeColor="Navy" Font-Bold="True" />
                          <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                              <tr>
                                <td style="height:20px;">
                                   <asp:Image runat="server" ID="imgTitle" ImageUrl="~/images/arrow/arrow.gif" ImageAlign="absMiddle" /> 지표평가단
                                   <asp:DropDownList runat="server" ID="ddlEstGroup" CssClass="box01" OnSelectedIndexChanged="ddlEstGroup_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                                </td>
                              </tr>
                              <tr>
                                <td style="height:50%;">
                                  <DCWC:Chart ID="chartBias" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Height="150px" Width="400px" >
                                    <Legends>
                                    <DCWC:Legend Name="Default" LegendStyle="Row" BackColor="White" BorderColor="26, 59, 105" Alignment="Center" Docking="Top" ShadowOffset="2"></DCWC:Legend>
                                    </Legends>
                                                                        <Titles>
                                    <DCWC:Title Name="Title1"></DCWC:Title>
                                    </Titles>
                                                                        <ChartAreas>
                                    <DCWC:ChartArea BackColor="White" BackGradientEndColor="White" ShadowColor="Transparent" BorderColor="196, 196, 196" Name="Default">
                                    <AxisY LabelsAutoFit="False" LineColor="196, 196, 196">
                                    <MajorGrid LineColor="196, 196, 196"></MajorGrid>

                                    <LabelStyle Font="Tahoma, 9px"></LabelStyle>
                                    </AxisY>

                                    <AxisX LabelsAutoFit="False" LineColor="196, 196, 196" Interval="1">
                                    <MajorGrid LineColor="196, 196, 196"></MajorGrid>

                                    <LabelStyle Font="Tahoma, 9px"></LabelStyle>
                                    </AxisX>

                                    <Area3DStyle YAngle="10" WallWidth="2"></Area3DStyle>
                                    </DCWC:ChartArea>
                                    </ChartAreas>
                                  </DCWC:Chart>
                                </td>
                              </tr>
                              <tr>
                                <td>
                                 <ig:UltraWebGrid ID="ugrdBias" runat="server" Width="100%" Height="99%" OnInitializeLayout="ugrdBias_InitializeLayout" OnInitializeRow="ugrdBias_InitializeRow" >
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="GROUP_NAME" Key="GROUP_NAME" Width="60px" HeaderText="GROUP_NAME" MergeCells="true">
                                                    <Header Caption="평가단">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="60px" HeaderText="EMP_NAME" MergeCells="true">
                                                    <Header Caption="평가자">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="220px" HeaderText="KPI_NAME">
                                                    <Header Caption="지표명">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ORI_SCORE" Key="ORI_SCORE" Width="55px" HeaderText="ORI_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ORI_MIN_SCORE" Key="ORI_MIN_SCORE" Width="55px" HeaderText="ORI_MIN_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="최하점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ORI_MAX_SCORE" Key="ORI_MAX_SCORE" Width="55px" HeaderText="ORI_MAX_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="최고점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="AVG_SCORE" Key="AVG_SCORE" Width="55px" HeaderText="AVG_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="AVG_MIN_SCORE" Key="AVG_MIN_SCORE" Width="55px" HeaderText="AVG_MIN_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="최하점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="AVG_MAX_SCORE" Key="AVG_MAX_SCORE" Width="55px" HeaderText="AVG_MAX_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="최고점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STD_SCORE" Key="STD_SCORE" Width="55px" HeaderText="STD_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STD_MIN_SCORE" Key="STD_MIN_SCORE" Width="55px" HeaderText="STD_MIN_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="최하점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STD_MAX_SCORE" Key="STD_MAX_SCORE" Width="55px" HeaderText="STD_MAX_SCORE" Format="#,##0.00">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="최고점수">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="BIAS_YN" Key="BIAS_YN" Width="35px" HeaderText="BIAS_YN">
                                                    <Header Caption="조정여부">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="9" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="9" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="10" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="10" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EST_EMP_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderStyleDefault-Height="20px" HeaderStyleDefault-HorizontalAlign="Center"
                                            HeaderClickActionDefault="NotSet" Name="ugrdBias" RowHeightDefault="20px"
                                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                            <GroupByBox>
                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                            </GroupByBox>
                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                            </GroupByRowStyleDefault>
                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                            </FooterStyleDefault>
                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                <Padding Left="3px" />
                                            </RowStyleDefault>
                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" Cursor="Hand" 
                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.5pt" Height="99%"
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
                                        <ClientSideEvents />
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>
                                        </DisplayLayout>
                                </ig:UltraWebGrid>
                                </td>
                              </tr>
                            </table>
                          </ContentTemplate>
                      </ig:Tab>
                  </Tabs>
                  <DefaultTabStyle BackColor="White" Height="20px">
                  </DefaultTabStyle>
                  <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif" SelectedImage="../images/tab/ig_tab_blueb2.gif" />
              </ig:UltraWebTab>
      </td>
    </tr>
  </table>
    <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport" >
    </ig:UltraWebGridExcelExporter>
</asp:Content>
