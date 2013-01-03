﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0402S1.aspx.cs" Inherits="BSC_BSC0402S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
<!--
function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    {
       var cell             = igtbl_getElementById(id);
       var row              = igtbl_getRowById(id);
       var band             = igtbl_getBandById(id);
       var active           = igtbl_getActiveRow(id);
       cell.style.cursor    = 'hand';
    }
}

function UltraWebGrid1_DblClickHandler(gridName, id)
{
    var cell            = igtbl_getElementById(id);
    var row             = igtbl_getRowById(id);
    var est_dept_ref_id = row.getCellFromKey("EST_DEPT_REF_ID").getValue();
    var est_term_ref_id = row.getCellFromKey("ESTTERM_REF_ID").getValue();
    var ymd             = "<%= PageUtility.GetByValueDropDownList(ddlEstTermMonth) %>";
    
    window.location.href='../usr/usr10001.aspx?ESTTERM_REF_ID=' + est_term_ref_id
                                        + '&EST_DEPT_REF_ID='   + est_dept_ref_id
                                        + '&YMD='               + ymd;
}// -->
</script>
    
<!--- MAIN START --->	
<table  border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
    <tr>
        <td height="20">
            <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
	            <tr>
                    <td class="cssTblTitle">평가기간</td>
                    <td class="cssTblContent" style="border-right:none;" >
                        <asp:dropdownlist id="ddlEstTermInfo" runat="server" autopostback="True" Width="65%" class="box01" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged1" 
                        /><asp:dropdownlist id="ddlEstTermMonth" runat="server" Width="33%" class="box01"></asp:dropdownlist>                                    
                    </td>
                    <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                    <td class="cssTblContent">&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="height:25px;">
        <td align="right">
            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click"/>
        </td>
    </tr>
	<tr>
	<td valign="top">
		<ig:UltraWebGrid ID="ugrdMapList" runat="server" Width="100%" Height="99%" OnInitializeRow="UltraWebGrid1_InitializeRow">
            <Bands>
                <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <Columns>
                        <ig:TemplatedColumn EditorControlID="" FooterText="" Format="" HeaderText="선택"
                            Hidden="True" Width="40px">
                            <Header Caption="선택">
                            </Header>
                            <Footer Caption="">
                            </Footer>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                            Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                            <Header Caption="ESTTERM_REF_ID">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                            Format="" HeaderText="YMD" Hidden="True" Key="YMD">
                            <Header Caption="YMD">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" EditorControlID="" FooterText=""
                            Format="" HeaderText="부서ID" Hidden="True" Key="EST_DEPT_REF_ID">
                            <Header Caption="부서ID">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                            Format="" HeaderText="부서명" Key="DEPT_NAME" Width="178px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="부서명">                                
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <CellStyle HorizontalAlign="Justify">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="BSCCHAMPION_NAME" HeaderText="BSC 챔피언" Key="BSCCHAMPION_NAME"
                            Width="120px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="BSC 챔피언">                                
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_VISION" EditorControlID="" FooterText=""
                            Format="" HeaderText="조직 비전" Key="DEPT_VISION" Width="300px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="조직 비전">                                
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <ValueList DisplayStyle="NotSet">
                            </ValueList>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="CNT_STG" EditorControlID="" FooterText=""
                            Format="" HeaderText="소유전략수" Key="CNT_STG" Width="80px">
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                            <Header Caption="소유전략수">                                
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <CellStyle HorizontalAlign="Right"></CellStyle>
                            <ValueList DisplayStyle="NotSet">
                            </ValueList>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="CNT_KPI" EditorControlID="" FooterText=""
                            Format="" HeaderText="CNT_KPI" Key="CNT_KPI" Width="80px">
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                            <Header Caption="소유지표수">                                
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <CellStyle HorizontalAlign="Right"></CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="TOT_WEIGHT" EditorControlID="" FooterText=""
                            HeaderText="TOT_WEIGHT" Key="TOT_WEIGHT" Width="80px" Format="#,##0.00">
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                            <Header Caption="가중치합계">                                
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <CellStyle HorizontalAlign="Right"></CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_LEVEL" HeaderText="LEVEL" Hidden="True"
                            Key="DEPT_LEVEL">
                            <Header Caption="LEVEL">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
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
                            Name="ugrdMapList"
                            RowHeightDefault="20px"
                            RowSelectorsDefault="No"
                            SelectTypeRowDefault="Extended"
                            Version="4.00"
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
                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="99%"
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
                <ClientSideEvents DblClickHandler="UltraWebGrid1_DblClickHandler" />--%>
                <GroupByBox>
                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                </GroupByBox>
                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                <RowStyleDefault  CssClass="GridRowStyle" />
                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                <ClientSideEvents DblClickHandler="UltraWebGrid1_DblClickHandler" />
                </DisplayLayout>
        </ig:UltraWebGrid>
        </td></tr></table>
<!--- MAIN END --->

</asp:Content>