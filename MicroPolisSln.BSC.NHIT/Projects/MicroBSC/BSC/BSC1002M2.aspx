﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1002M2.aspx.cs" Inherits="BSC_BSC1002M2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">

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








 <table cellpadding="0" cellspacing="5" border="0" style="width:100%; height:100%;">
   <tr>
     <td align="left">
	    <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;" >
	        <tr>
                <td style="width:40%;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                        <tr style="height:25px;">
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td align="left" style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                                        <td><b>My 평가대상 KPI</b></td>
                                        <td align="right">
                                            <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <ig:UltraWebGrid ID="ugrdChildKpi" runat="server" Width="100%" Height="100%" >
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:TemplatedColumn Key="selchk" Width="25px">
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
                                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" DataType="System.Int32" EditorControlID=""
                                                    FooterText="" Format="" HeaderText="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" NullText="0">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="EMP_REF_ID" Fixed="true">
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
                                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="70px" AllowUpdate="No">
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
                                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="160px" AllowUpdate="No">
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
                                                <ig:UltraGridColumn BaseColumnName="WEIGHT" EditorControlID="" FooterText="" AllowUpdate="Yes"
                                                    Format="" HeaderText="WEIGHT" Key="WEIGHT" DataType="System.Double" NullText="0" Width="60px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="가중치">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right" />
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="100px" AllowUpdate="No">
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
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                     <DisplayLayout CellPaddingDefault="0"
                                                    AllowColSizingDefault="Free"
                                                    AllowColumnMovingDefault="None"
                                                    AllowDeleteDefault="No"
                                                    AllowSortingDefault="No"
                                                    BorderCollapseDefault="Separate"
                                                    UseFixedHeaders="true"
                                                    StationaryMargins="Header" 
                                                    HeaderClickActionDefault="NotSet"
                                                    Name="ugrdChileKpi"
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No"
                                                    SelectTypeRowDefault="None"
                                                    Version="4.00"
                                                    ViewType="Flat"
                                                    CellClickActionDefault="CellSelect"
                                                    TableLayout="Fixed"
                                                    TabDirection="TopToBottom"
                                                    AutoGenerateColumns="False">
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
                                        <ClientSideEvents />--%>
                                        
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="center" style="width:3%;">
                    <asp:ImageButton ID="addKpi" runat="server" ImageUrl="../images/btn/btn_add_02.gif" AlternateText="지표추가" OnClick="addKpi_Click" /><br /><br />
                    <asp:ImageButton ID="remKpi" runat="server" ImageUrl="../images/btn/btn_add_01.gif" AlternateText="지표삭제" OnClick="remKpi_Click" />
                </td>
                <td valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                        <tr style="height:25px;">
                            <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                            <td>
                                <b>대상 KPI 리스트</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <%--<colgroup>
                                        <col width="200px" style="height: 25px;" />
                                        <col />
                                        <col width="200px" style="height: 25px;" />
                                        <col />
                                    </colgroup>--%>
                                    <tr>
                                        <td class="cssTblTitle">평가기간</td>
                                        <td class="cssTblContent">
                                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" Width="100%" CssClass="box01"></asp:dropdownlist>
                                        </td>
                                        <td class="cssTblTitle">조회구분</td>
                                        <td class="cssTblContent">
                                            <asp:DropDownList ID="ddlGubun" Width="100%" runat="server" CssClass="box01"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle">지표코드</td>
                                        <td class="cssTblContent">
                                            <asp:TextBox ID="txtKpiCode" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td class="cssTblTitle">지표명</td>
                                        <td class="cssTblContent">
                                            <asp:TextBox ID="txtKpiName" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height:25px;">
                            <td align="right" colspan="2">
                                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                            </td>  
                        </tr>
                        <tr style="height:100%">
                            <td colspan="2">
                                <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiList_InitializeRow" >
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:TemplatedColumn Key="selchk" Width="30px">
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
                                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="70px">
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
                                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="180px">
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
                                                    Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="100px">
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
                                                <ig:UltraGridColumn BaseColumnName="IS_TEAM_KPI" Key="IS_TEAM_KPI" Hidden="true"></ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                     <DisplayLayout CellPaddingDefault="2"
                                                    AllowColSizingDefault="Free"
                                                    AllowColumnMovingDefault="None"
                                                    AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="Yes"
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="NotSet"
                                                    Name="ugrdKpiList"
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No"
                                                    SelectTypeRowDefault="Extended"
                                                    Version="4.00"
                                                    ViewType="Flat"
                                                    CellClickActionDefault="RowSelect"
                                                    TableLayout="Fixed"
                                                    StationaryMargins="Header"
                                                    AutoGenerateColumns="False"
                                                    OptimizeCSSClassNamesOutput="False">
                                        <%--
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
                                        
                                        <GroupByBox>
                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                        </GroupByBox>
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                        <ClientSideEvents />
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
	        <tr>
                <td style="height: 30px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="2" style="width: 40%;" align="left">
                                <asp:ImageButton ID="udtKpi" runat="server" ImageUrl="../images/btn/b_007.gif" AlternateText="가중치설정" OnClick="udtKpi_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
     </td>
   </tr>
 </table>

</asp:Content>
