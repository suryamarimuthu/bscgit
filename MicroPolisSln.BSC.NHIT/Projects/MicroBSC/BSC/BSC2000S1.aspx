<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC2000S1.aspx.cs" Inherits="BSC_BSC2000S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

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

function UltraWebGrid1_DblClickHandler(gridName, id)
{
	var cell            = igtbl_getElementById(id);
    var row             = igtbl_getRowById(id);
    var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();
    var kpi_ref_id      = row.getCellFromKey("KPI_REF_ID").getValue();
    var ymd             = row.getCellFromKey("YMD").getValue();
    
    location.href = 'BSC0304S2.aspx?ESTTERM_REF_ID='    + estterm_ref_id 
                                + '&KPI_REF_ID='        + kpi_ref_id 
                                + '&YMD='               + ymd;
}// -->

function OpenEstDept() {
    var EsttermRefID = document.getElementById("ctl00_Contents_ddlEstTermInfo").value;
    var intEstDeptID = "ctl00$Contents$txtDeptID";
    var strEstDeptNM = "ctl00$Contents$txtDeptName";

    var strURL = "BSC0406S2.aspx?ESTTERM_REF_ID=" + EsttermRefID + "&CCB1=" + intEstDeptID + "&CCB2=" + strEstDeptNM;

    gfOpenWindow(strURL, 350, 500, 0, 0, 'BSC0406S2');
}
</script>
    
    <table cellpadding="0" cellspacing="0" width="100%" height="100%" border="0">
        <tr>
            <td style="height:25px">
                <!-- 검색 조건 --->
                 <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder" style="height: 100%;">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent"> 
                            <asp:DropDownList ID="ddlEstTermInfo" class="box01" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:DropDownList>
                            <asp:DropDownList ID="ddlMonthInfo" class="box01" runat="server" ></asp:DropDownList>
                        </td>
                        <td class="cssTblTitle">
                            부서명
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlDeptList" runat="server" Width="100%" CssClass="box01" 
                                onselectedindexchanged="ddlDeptList_SelectedIndexChanged" />
                        </td>
                    </tr>
                 </table>
                <!-- 검색 조건 --->
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                    <tr>
                        <td style="width:50%;">
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="Goal, Target 차이 분석"/></td>
                                </tr>
                            </table>
                        </td>
                        <td align="right"> 
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td align="right">
                                        <asp:RadioButtonList ID="rdoMethod" runat="server" RepeatLayout="Flow" RepeatColumns="2" style="cursor:pointer;">
                                            <asp:ListItem Text="당월" Value="MS"></asp:ListItem>
                                            <asp:ListItem Text="누적" Value="TS"  Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>&nbsp;&nbsp;
                                    </td>
                                    <td style="width:1%;">
                                    <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;</td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td style="height:100%;">
                <table cellpadding="0" cellspacing="0" width="100%" height="100%">
                    <tr>
                        <td  style="height:100%;">
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" 
                              OnSelectedRowsChange ="UltraWebGrid1_SelectedRowsChange"
                              OnInitializeRow="UltraWebGrid1_InitializeRow"
                              OnInitializeLayout="UltraWebGrid1_InitializeLayout" >
                              <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:TemplatedColumn  Format="" HeaderText="선택"
                                                Hidden="True" Width="40px">
                                                <Header Caption="선택" >
                                                    <RowLayoutColumnInfo OriginX="0" OriginY="0" SpanY="2" />
                                                </Header>
                                                <Footer Caption="">
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" 
                                                Format="" HeaderText="KPI"  Key="KPI_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI">
                                                    <RowLayoutColumnInfo OriginX="1" OriginY="0" SpanY="2" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" FooterText="" HeaderText="KPI 명칭"
                                                Key="KPI_NAME" Width="160px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI 명">
                                                    <RowLayoutColumnInfo OriginX="2"  OriginY="0" SpanY="2"/>
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="평가부서"  Width="100px"
                                                Key="DEPT_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="평가부서">
                                                    <RowLayoutColumnInfo OriginX="3"  OriginY="0" SpanY="2"/>
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Justify">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_NAME"  Width="100px"
                                                Format="" HeaderText="KPI 담당자"  Key="CHAMPION_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI 담당자">
                                                    <RowLayoutColumnInfo OriginX="4"  OriginY="0" SpanY="2"/>
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                          
                                            <ig:UltraGridColumn BaseColumnName="" DataType="System.Decimal" Format="###,###,##0.####"
                                                HeaderText="목표(Target)" Key="TARGET_P" Width="120px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="목표(Target)">
                                                    <RowLayoutColumnInfo OriginX="5" OriginY="1"  />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>  
                                            <ig:UltraGridColumn BaseColumnName="" DataType="System.Decimal" Format="###,###,##0.####"
                                                HeaderText="의지목표(Goal)" Key="GOAL_P" Width="120px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="의지목표(Goal)">
                                                    <RowLayoutColumnInfo OriginX="6" OriginY="1" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" DataType="System.Decimal" Format="###,###,##0.####"
                                                HeaderText="실적" Key="RESULT" Width="120px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="실적">
                                                    <RowLayoutColumnInfo OriginX="7" OriginY="0" SpanY="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" DataType="System.Decimal" Format="#,##0.00"
                                                HeaderText="목표(Target)" Key="TARGET_DAL" Width="120px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="목표(Target)">
                                                    <RowLayoutColumnInfo OriginX="8" OriginY="1"  />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" DataType="System.Decimal" Format="#,##0.00"
                                                HeaderText="의지목표(Goal)" Key="GOAL_DAL" Width="120px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="의지목표(Goal)">
                                                    <RowLayoutColumnInfo OriginX="9" OriginY="1"  />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" 
                                                AllowColumnMovingDefault="OnServer" 
                                                AllowDeleteDefault="Yes"
                                                AllowSortingDefault="No" 
                                                BorderCollapseDefault="Separate" 
                                                AutoGenerateColumns="False" 
                                                HeaderClickActionDefault="SortMulti" 
                                                Name="ugrdResultStatus"
                                                HeaderStyleDefault-Height="18px" 
                                                HeaderStyleDefault-Font-Bold="true" 
                                                RowHeightDefault="20px"
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended" 
                                                Version="4.00" 
                                                CellClickActionDefault="RowSelect" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="Header">
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                    <Images>
                                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>    
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                                    
                        </td>
                        
                    </tr>
                    
                </table>
            </td>
        </tr>
       
        <tr >
            <td>
                
                <asp:Panel runat="server" id="ChartView">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                    <tr>
                        <td style="width:10%;">
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Goal, Target 목표 및 실적 월별 현황"/>
                                        (<asp:Label ID="lblKpiName1" runat="server" Font-Bold="true" ForeColor="Red" Text=""/>)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Chart ID="chartMM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="250px" Height="220px" >
                                            <ChartAreas>
                                                <asp:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX>
                                                <Area3DStyle  WallWidth="5" Enable3D="False"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="False">
                                                <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY2>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                </asp:Legend>
                                            </Legends>
                                        </asp:Chart>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                        <td style="width:2%;">
                        &nbsp;
                        </td>
                        <td style="width:80%;">
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Goal, Target 달성율 현황"/>
                                        (<asp:Label ID="lblKpiName2" runat="server" Font-Bold="true" ForeColor="Red" Text=""/>)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Chart ID="chartDal" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="250px" Height="220px" >
                                            <ChartAreas>
                                                <asp:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX>
                                                <Area3DStyle  WallWidth="5" Enable3D="False"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="False">
                                                <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY2>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                </asp:Legend>
                                            </Legends>
                                        </asp:Chart>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
    </table>

    <asp:linkbutton id="lBtnReload" runat="server" onclick="lBtnReload_Click"></asp:linkbutton>
    <asp:Literal ID="ltrScript" runat="server" />

</asp:Content>
