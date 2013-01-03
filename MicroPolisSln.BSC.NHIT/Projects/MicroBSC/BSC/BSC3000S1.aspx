<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC3000S1.aspx.cs" Inherits="BSC_BSC3000S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
<!--

function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    {
       var cell         = igtbl_getElementById(id);
       cell.style.cursor = 'hand';
    }
}

// -->

</script>
    <table cellpadding="0" cellspacing="0" width="100%"  border="0">
        <tr>
            <td style="height:100px; width:100%; vertical-align:middle; text-align:center;">
            평가프로세스 설명
            </td>
        </tr>
    </table>
    
    <table cellpadding="0" cellspacing="0" width="100%"  border="0">
        <tr>
            <td style="height:100px; width:34%">
                <!-- 조직kpi or  --->
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
                <ig:UltraWebGrid ID="ugrdMyKpiList" runat="server" Width="100%" Height="100%" 
                                 OnInitializeRow="ugrdMyKpiList_InitializeRow" 
                                 OnInitializeLayout="ugrdMyKpiList_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="60%">
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
                                </ig:TemplatedColumn>
                                 <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="40%">
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
                                </ig:TemplatedColumn>

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
                                    Name="ugrdMyKpiList"
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No"
                                    SelectTypeRowDefault="Extended"
                                    Version="4.00"
                                    CellClickActionDefault="RowSelect"
                                    TableLayout="Fixed"
                                    StationaryMargins="Header"
                                    AutoGenerateColumns="False">
                       
                        
                        <GroupByBox>
                            <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                     
                        </DisplayLayout>
                </ig:UltraWebGrid>

                <!-- 조직kpi --->
            </td>
            <td style="height:100px; width:33%; text-align:center;">
    팀점수
            </td>
            <td style="height:100px; width:33%; text-align: center;">
    조직점수
            </td>
        </tr>
 
         <tr>
            <td style="height:100px; width:34%;">
             <!-- 공지사항 --->

                <ig:UltraWebGrid ID="ugrdNotice" runat="server" Width="100%" Height="99%" OnInitializeRow="ugrdNotice_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>

                                <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="70%" HeaderText="제목">
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
 
                                <ig:TemplatedColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="30%" Format="yyyy-MM-dd" FooterText="" HeaderText="작성일자">
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
                                    Name="ugrdNotice"
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No"
                                    SelectTypeRowDefault="Extended"
                                    Version="4.00"
                                    CellClickActionDefault="RowSelect"
                                    TableLayout="Fixed"
                                    StationaryMargins="Header"
                                    AutoGenerateColumns="False">
                        
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                      
                    </DisplayLayout>
                </ig:UltraWebGrid>                            
<!--  공지사항 --->
            </td>
            <td style="height:100px; width:33%;">
             <!-- FAQ --->

                <ig:UltraWebGrid ID="ugrdFAQ" runat="server" Width="100%" Height="99%" OnInitializeRow="ugrdFAQ_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>

                                <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="70%" HeaderText="제목">
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
 
                                <ig:TemplatedColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="30%" Format="yyyy-MM-dd" FooterText="" HeaderText="작성일자">
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
                                    Name="ugrdFAQ"
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No"
                                    SelectTypeRowDefault="Extended"
                                    Version="4.00"
                                    CellClickActionDefault="RowSelect"
                                    TableLayout="Fixed"
                                    StationaryMargins="Header"
                                    AutoGenerateColumns="False">
                        
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                      
                    </DisplayLayout>
                </ig:UltraWebGrid>                  <!--  FAQ --->
            </td >
                          

            <td style="height:100px; width:33%; text-align:center;">
                           <!-- 담당자연락처 --->
                 담당자연락처
                <!--   담당자연락처 --->

            </td>
        </tr>
       
    </table>
    <asp:DropDownList id="ddlEstTermRefID" runat="server" class="box01" Visible="False" />

    <asp:Literal ID="ltrScript" runat="server" />

</asp:Content>
