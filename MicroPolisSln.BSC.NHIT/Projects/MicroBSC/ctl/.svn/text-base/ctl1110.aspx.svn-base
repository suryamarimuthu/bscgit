<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl1110.aspx.cs" Inherits="ctl_ctl1110" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<%@ Register Src="../_common/lib/CheckInOutControl.ascx" TagName="CheckInOutControl" TagPrefix="uc1" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script  type="text/javascript">
function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    { // Are we over a cell
       var cell             = igtbl_getElementById(id);
       var row              = igtbl_getRowById(id);
       var band             = igtbl_getBandById(id);
       var active           = igtbl_getActiveRow(id);
       cell.style.cursor    = 'hand';
    }
}
    
function closeTerm()
{
    if(confirm(' 해당 평가기간을 마감하시겠습니까?'))
    {
        return true;
    }
    else
    {
        return false;
    }
}

function openTerm()
{
    if(confirm(' 해당 평가기간을 마감취소 처리하시겠습니까?'))
    {
        return true;
    }
    else
    {
        return false;
    }
}
</script>
<div>
    <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
        <tr style="height:18px;">
            <td style="width:50%;" >
                <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="평가기간정보"/></td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;&nbsp;</td>
            <td style="width:50%;" >
                <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="평가기간상세정보"/></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:100%;">
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                    <tr>
                        <td>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:TemplatedColumn HeaderText="선택" Hidden="True" Key="selchk" Width="40px">
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                </CellTemplate>
                                                <Header Caption="선택">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_NAME" HeaderText="성과 평가 기간명" Key="ESTTERM_NAME"
                                                Width="145px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="성과 평가 기간명">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_STARTDATE" Format="yyyy-MM-dd" HeaderText="시작일"
                                                Key="EST_STARTDATE" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="시작일">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_COMPDATE" Format="yyyy-MM-dd" HeaderText="완료일"
                                                Key="EST_COMPDATE" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="완료일">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YEARLY_CLOSE_YN" HeaderText="마감여부" Key="YEARLY_CLOSE_YN"
                                                Type="CheckBox" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <Header Caption="마감여부">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_STATUS" HeaderText="사용" Key="EST_STATUS"
                                                Type="CheckBox" Width="35px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <Header Caption="사용">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID"
                                                Hidden="True" Key="ESTTERM_REF_ID">
                                                <Header Caption="ESTTERM_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" 
                                                AllowColumnMovingDefault="OnServer"
                                                TableLayout="Fixed"
                                                AllowSortingDefault="Yes" 
                                                BorderCollapseDefault="Separate" 
                                                SelectTypeRowDefault="Extended" 
                                                HeaderClickActionDefault="NotSet" 
                                                Name="UltraWebGrid1" 
                                                RowHeightDefault="20px" 
                                                Version="4.00" 
                                                AutoGenerateColumns="False" 
                                                CellClickActionDefault="RowSelect" 
                                                OptimizeCSSClassNamesOutput="False"
                                                RowSelectorsDefault="No">
                                    <%--<GroupByBox>
                                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowAlternateStyleDefault BackColor="#F9F9F7">
                                        <BorderDetails  ColorLeft="249, 249, 247" ColorTop="249, 249, 247" />
                                    </RowAlternateStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td></td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder" style="height: 100%;">
                                <tr>
                                    <td class="cssTblTitle">
                                        평가기간명
                                    </td>
                                    <td class="cssTblContent" colspan="3"> 
                                        <asp:TextBox ID="txtEstTermName" runat="server" Width="100%"></asp:TextBox>
                                        <asp:Literal ID="ltrEstTermRefId" runat="server" Visible="False"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">평가기간</td>
                                    <td class="cssTblContent" colspan="3">
                                        <table style="width:50%;" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width:40%;" >
                                                    <ig:WebDateChooser ID="wdcFrom" runat="server" NullDateLabel="" Format="Short">
                                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                    </ig:WebDateChooser>        
                                                </td>
                                                <td style="width:20%;" align="center"> ~ </td>
                                                <td style="width:40%;">
                                                    <ig:WebDateChooser ID="wdcTo" runat="server" NullDateLabel="">
                                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                    </ig:WebDateChooser>        
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle"  style="width:25%;" >예비마감일</td>
                                    <td class="cssTblContent" style="width:25%;" >
                                        <asp:dropdownlist id="ddlPRE_CLOSE_DAY" runat="server" CssClass="box01"></asp:dropdownlist>
                                    </td>
                                    <td class="cssTblTitle" style="width:25%;" >매월마감일</td>
                                    <td class="cssTblContent" style="width:25%;" >
                                        <asp:dropdownlist id="ddlMONTHLY_CLOSE_DAY" runat="server" CssClass="box01"></asp:dropdownlist>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle" >평가방식</td>
                                    <td class="cssTblContent" >
                                        <asp:dropdownlist id="ddlSCORE_VALUATION_TYPE" runat="server" CssClass="box01"></asp:dropdownlist>
                                    </td>
                                    <td class="cssTblTitle" >월마감방식</td>
                                    <td class="cssTblContent">
                                        <asp:dropdownlist id="ddlCLOSE_RATE_COMPLETE_YN" runat="server" CssClass="box01"></asp:dropdownlist>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">정성평가마감일</td>
                                    <td class="cssTblContent" colspan="3">
                                        <asp:dropdownlist id="ddlKPI_QLT_CLOSE_DAY" runat="server" CssClass="box01"></asp:dropdownlist>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle" >외부평가설정</td>
                                    <td class="cssTblContent" colspan="3" >
                                        <asp:CheckBox ID="chkEXTERNAL_SCORE_USE_YN" runat="server" Text="외부평가사용여부" />
                                        <asp:dropdownlist id="ddlEXTERNAL_SCORE_TYPE" runat="server" CssClass="box01"></asp:dropdownlist>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle" >평가기타사항</td>
                                    <td class="cssTblContent" colspan="3" >
                                        <asp:textbox id="txtEST_DESC" runat="server" height="60px" textmode="MultiLine" width="99%"></asp:textbox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="2" border="0" style="height:100%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label2" runat="server" Font-Bold="true" Text="성과분석일정"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton id="iBtnClear" runat="server" imageurl="~/images/btn/b_093.gif" visible="true" onclick="iBtnClear_Click" />
                                        <asp:ImageButton id="iBtnAdd" runat="server" imageurl="~/images/btn/b_001.gif" visible="true" OnClick="iBtnAdd_Click" />
                                        <asp:ImageButton id="iBtnModifyTermInfo" runat="server" imageurl="~/images/btn/b_002.gif" onclick="iBtnModifyTermInfo_Click" />
                                        <asp:ImageButton id="iBtnClose" runat="server" imageurl="~/images/btn/b_018.gif" visible="true" OnClick="iBtnClose_Click" OnClientClick="return closeTerm();" />
                                        <asp:ImageButton id="iBtnOpen" runat="server" imageurl="~/images/btn/b_078.gif" visible="true" OnClick="iBtnOpen_Click" OnClientClick="return openTerm();" />
                                        <asp:ImageButton id="iBtnDel" runat="server" imageurl="~/images/btn/b_004.gif" visible="true" OnClick="iBtnDel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:100%;">
                        <td>
                            <ig:UltraWebGrid ID="ugrdClose" runat="server" Height="100%" Width="100%" OnInitializeRow="ugrdClose_InitializeRow" style="left: 181px; top: 18px">
                                <Bands>
                                    <ig:UltraGridBand>
                                        
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText="" Format=""
                                                FormulaErrorValue="" HeaderText="마감월" Key="YMD" Width="70px" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="마감월" Title="">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YM" EditorControlID="" FooterText="" Format=""
                                                FormulaErrorValue="" HeaderText="마감월" Key="YM" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="마감월" Title="">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CLOSING_DATE" EditorControlID="" FooterText=""
                                                Format="YYYY-MM-DD" FormulaErrorValue="" HeaderText="마감일자" Key="CLOSING_DATE"
                                                Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="마감일자" Title="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CLOSING_RATE" EditorControlID="" FooterText=""
                                                Format="" FormulaErrorValue="" HeaderText="마감율" Key="CLOSING_RATE" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="마감율" Title="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="RELEASE_YN" EditorControlID="" FooterText=""
                                                Format="" FormulaErrorValue="" HeaderText="게시여부" Key="RELEASE_YN" Width="60px">
                                                <CellTemplate>
                                                    <asp:CheckBox id="chkRELEASE_YN" runat="server" Enabled="false" />
                                                </CellTemplate>
                                                <Header Caption="게시여부" Title="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="CLOSE_YN" EditorControlID="" FooterText=""
                                                Format="" FormulaErrorValue="" HeaderText="마감여부" Key="CLOSE_YN" Width="60px">
                                                <CellTemplate>
                                                    <asp:CheckBox id="chkCLOSE_YN" runat="server" Enabled="false" />
                                                </CellTemplate>
                                                <Header Caption="마감여부" Title="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="CLOSE_USER" EditorControlID="" FooterText=""
                                                Format="" FormulaErrorValue="" HeaderText="처리자" Key="CLOSE_USER" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="처리자" Title="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                                Format="" FormulaErrorValue="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                <Header Caption="ESTTERM_REF_ID" Title="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" 
                                                BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" 
                                                Name="ugrdClose" RowHeightDefault="18px" 
                                                SelectTypeRowDefault="Extended" 
                                                Version="4.00" 
                                                AutoGenerateColumns="False" 
                                                CellClickActionDefault="RowSelect" 
                                                RowSelectorsDefault="No"
                                                OptimizeCSSClassNamesOutput="False" 
                                                JavaScriptFileName="" 
                                                JavaScriptFileNameCommon="">
                                    <%--<GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowAlternateStyleDefault BackColor="#F9F9F7">
                                        <BorderDetails  ColorLeft="249, 249, 247" ColorTop="249, 249, 247" />
                                    </RowAlternateStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="18px">
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
                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                                        ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                                        GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                                        RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />--%>
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
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:literal id="ltrAddTermInfo" runat="server" Visible="False"></asp:literal>
                            <asp:ImageButton ID="iBtnRemoveEstTermInfo" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="iBtnRemoveEstTermInfo_Click" Visible="False" />&nbsp;
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
        
    <asp:LinkButton ID="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:LinkButton>
    <asp:linkbutton id="lBtnSubReload" runat="server" onclick="lBtnSubReload_Click"></asp:linkbutton>
</div>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>

</asp:Content>