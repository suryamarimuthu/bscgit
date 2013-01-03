<%@ Page Language="C#" MasterPageFile="~/_common/libNHIT/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC0707S1.aspx.cs" Inherits="BSC_BSC0707S1" Title="MicroBSC" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contents" Runat="Server">
<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
<!-- 상단 검색 Start-->
    <tr style="height:23px;">
      <td>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;" class="tableBorder">
            <tr>
                <td class="cssTblTitle">평가기간</td>
                <td class="cssTblContent">
                    <asp:dropdownlist id="ddlEstTermInfo" runat="server" Width="100%" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                </td>	
                <td class="cssTblTitle">측정 월</td>
                <td class="cssTblContent"><asp:dropdownlist id="ddlMonthInfo" runat="server" Width="100%" CssClass="box01"></asp:dropdownlist></td>
            </tr>
        </table>
      </td>
    </tr>
    <tr style="height:25px;">
        <td align="right">
            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle" />
        </td>
    </tr>
<!-- 상단 검색 End-->    
<!-- 그리드 Start-->
    <tr>
        <td>
        <ig:UltraWebTab runat="server" 
                          ID="ugrdKpiStatusTab" 
                          Height="100%"  
                          Width="100%" 
                          AutoPostBack="True" 
                          BorderWidth="1px" 
                          BorderStyle="Solid" 
                          SpaceOnLeft="1" 
                          OnTabClick="ugrdKpiStatusTab_TabClick" 
                          SelectedTab="1">
              <Tabs>
                  <ig:Tab Text="나의 Comment/Feedback" Key="1" >
                  
                      <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                          <tr>
                            <td>
                                 <ig:UltraWebGrid ID="ugrdCommunication" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdCommunication_InitializeRow" >
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="READ_YN" Key="READ_YN" Hidden="true" Width="20px">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="130px" HeaderText="제목" MergeCells="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="KPI 명">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="LIST_REF_ID" HeaderText="No" Key="NUM_TEXT" Width="60px" FooterText="">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="글번호">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="315px" HeaderText="제목">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="제목">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn BaseColumnName="ATTACH_NO" Key="ATTACH_NO" Width="40px" FooterText="" HeaderText="첨부" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="첨부">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="OWNER_NAME" Key="OWNER_NAME" Width="60px" FooterText="" HeaderText="작성자">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="작성자">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="100px" FooterText="" HeaderText="조직">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="운영조직">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="READ_COUNT" Key="READ_COUNT" Width="50px" FooterText="" HeaderText="조회수" Hidden="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="조회수">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="70px" Format="yyyy-MM-dd" FooterText="" HeaderText="작성일자">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="작성일자">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="IDX" Key="IDX" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="BOARD_CATEGORY" Key="BOARD_CATEGORY" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="LIST_REF_ID" Key="LIST_REF_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="9" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="9" />
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
                                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="11" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="11" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="12" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="12" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="OWNER_EMP_ID" Key="OWNER_EMP_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TREE_LEVEL" Key="TREE_LEVEL" Hidden="True">
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
                                    <DisplayLayout  CellPaddingDefault="2"
                                                    AllowColSizingDefault="Free"
                                                    AllowColumnMovingDefault="OnServer"
                                                    AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="Yes"
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="SortMulti"
                                                    Name="ugrdCommunication"
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No"
                                                    SelectTypeRowDefault="Extended"
                                                    Version="4.00"
                                                    CellClickActionDefault="RowSelect"
                                                    TableLayout="Fixed"
                                                    StationaryMargins="Header"
                                                    AutoGenerateColumns="False"
                                                    OptimizeCSSClassNamesOutput="False">
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
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BorderColor="#E9EBEB" BackColor="White" BorderStyle="Solid" Cursor="Hand" 
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
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>--%>
                                            
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                        <ClientSideEvents DblClickHandler="DblClickHandler" />
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                          </tr>
                        </table>
                      </ContentTemplate>
                  </ig:Tab>
                  <ig:TabSeparator>
                    <Style Width="1px"></Style>
                  </ig:TabSeparator>
                  <ig:Tab Text="관련조직의 Comment/Feedback" Key="2">
                      <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                          <tr>
                            <td>
                                 <ig:UltraWebGrid ID="ugrdCommunicationOrg" runat="server" Width="100%" Height="99%" OnInitializeRow="ugrdCommunication_InitializeRow" >
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="READ_YN" Key="READ_YN" Hidden="true" Width="20px">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="130px" HeaderText="제목" MergeCells="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="KPI 명">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="LIST_REF_ID" HeaderText="No" Key="NUM_TEXT" Width="60px" FooterText="">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="글번호">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="315px" HeaderText="제목">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="제목">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn BaseColumnName="ATTACH_NO" Key="ATTACH_NO" Width="40px" FooterText="" HeaderText="첨부" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="첨부">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="OWNER_NAME" Key="OWNER_NAME" Width="60px" FooterText="" HeaderText="작성자">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="작성자">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="100px" FooterText="" HeaderText="조직">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="운영조직">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="READ_COUNT" Key="READ_COUNT" Width="50px" FooterText="" HeaderText="조회수" Hidden="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="조회수">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="70px" Format="yyyy-MM-dd" FooterText="" HeaderText="작성일자">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="작성일자">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="IDX" Key="IDX" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="BOARD_CATEGORY" Key="BOARD_CATEGORY" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="LIST_REF_ID" Key="LIST_REF_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="9" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="9" />
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
                                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="11" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="11" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="12" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="12" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="OWNER_EMP_ID" Key="OWNER_EMP_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TREE_LEVEL" Key="TREE_LEVEL" Hidden="True">
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
                                    <DisplayLayout  CellPaddingDefault="2"
                                                    AllowColSizingDefault="Free"
                                                    AllowColumnMovingDefault="OnServer"
                                                    AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="Yes"
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="SortMulti"
                                                    Name="ugrdCommunicationOrg"
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No"
                                                    SelectTypeRowDefault="Extended"
                                                    Version="4.00"
                                                    CellClickActionDefault="RowSelect"
                                                    TableLayout="Fixed"
                                                    StationaryMargins="Header"
                                                    AutoGenerateColumns="False"
                                                    OptimizeCSSClassNamesOutput="False">
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
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" Cursor="Hand" 
                                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="99%"
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
                                        </SelectedRowStyleDefault>
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>--%>
                                        
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                        <ClientSideEvents DblClickHandler="DblClickHandler" />
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                          </tr>
                        </table>
                      </ContentTemplate>
                  </ig:Tab>
 
              </Tabs>
              <DefaultTabStyle Width="150" Height="26"  CssClass="cssTabStyleOff" ></DefaultTabStyle>
              <SelectedTabStyle Width="150" Height="26" CssClass="cssTabStyleOn"></SelectedTabStyle>

              <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif" SelectedImage="../images/tab/ig_tab_blueb2.gif" />

          </ig:UltraWebTab>
          <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
          <asp:Literal ID="ltrScript" runat="server"></asp:Literal>

        </td>
    </tr>
<!-- 그리드 End-->    
</table>    
</asp:Content>


