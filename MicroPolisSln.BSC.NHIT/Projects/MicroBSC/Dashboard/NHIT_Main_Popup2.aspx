<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_Main_Popup2.aspx.cs" EnableEventValidation="false" Inherits="Dashboard_NHIT_Main_Popup2" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>::BSC::</title>
    <link rel="stylesheet" href="/_common/css/bsc.css" type="text/css" />
    <link rel="stylesheet" href="/_common/css/treeStyle.css" type="text/css" />
    <script type="text/javascript" src="/_common/js/common.js"></script>
    <script type="text/javascript" src="/_common/js/picker.js"></script>
    <script type="text/javascript" src="/_common/js/iezn_embed_patch.js" ></script>
    <script type="text/javascript" src="/_common/js/LayerShowHide.js"></script>
    <link type="text/css" rel="stylesheet" href="/_common/js/yahoo/container.css" />
    <link type="text/css" rel="Stylesheet" href="/_common/js/yahoo/styles.css" />
    <style type="text/css" media="screen">
       input
       {
            display:inline;
       }
    </style>
    <style type="text/css" media="print">
       input
       {
            display:none;
       }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div style="margin-top:0px;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
            <tr>
                <td valign="top" style="height:40px;" >
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td valign="top" style="background-image:url(../../images/title/popup_t_bg.gif); height:40px;"> 
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr> 
                                    <td  style="height:40px;" valign="top"><img alt="" src="../../images/title/popup_t79.gif" /></td>
                                    <td align="right" valign="top"><img alt="" src="../../images/title/popup_img.gif" /></td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr> 
                                    <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                                    <td style="width:50%; background-color:#FFFFFF"></td>
                                </tr>
                            </table>
                        </td>
                      </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top"  style="height:20px;">
                    <table cellspacing="0" border="0" width="100%" style="height:20px;"> 
                        <tr>
                            <td >
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="box01" style="cursor:pointer;"></asp:DropDownList>
                                <asp:RadioButtonList ID="rdoGoalTong" runat="server" RepeatLayout="Flow" RepeatColumns="2" style="cursor:pointer;" >
                                    <asp:ListItem Text="목표(Target)" Value="TARGET" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="의지목표(Goal)" Value="GOAL"></asp:ListItem>
                                </asp:RadioButtonList>&nbsp;&nbsp;  
                            </td>
                            <td  class="cssPopBtnLine">
                                <asp:ImageButton ID="ImageButton1" runat="server" align="absmiddle" Height="19px" ImageUrl="../../images/btn/b_033.gif" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" style="height:310px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="height:5px;" ></td>
                        </tr>
                        <tr>
                            <td style="width:100%; ">
                                <div style="width:100%; height:300px; border:solid 1px gray;">
                                    <DCWC:Chart ID="chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" >
                                        <ChartAreas>
                                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisX>
                                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY>
                                            <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="false">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY2>
                                            </DCWC:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                                            </DCWC:Legend>
                                        </Legends>
                                    </DCWC:Chart>
                                </div>
                            </td>
                        </tr>
                    </table>
               </td>
            </tr>
            <tr>
               <td valign="top">
                    <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" OnInitializeLayout="UltraWebGrid1_InitializeLayout" OnInitializeRow="UltraWebGrid1_InitializeRow" >
                        <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="ACC" HeaderText="경영지표" Key="ACC" Width="10%">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="GUBUN" HeaderText="구분" Key="GUBUN" Width="6%">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="M01" HeaderText="1월" Key="M01" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M02" HeaderText="2월" Key="M02" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M03" HeaderText="3월" Key="M03" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M04" HeaderText="4월" Key="M04" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M05" HeaderText="5월" Key="M05" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M06" HeaderText="6월" Key="M06" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M07" HeaderText="7월" Key="M07" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M08" HeaderText="8월" Key="M08" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M09" HeaderText="9월" Key="M09" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M10" HeaderText="10월" Key="M10" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M11" HeaderText="11월" Key="M11" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="M12" HeaderText="12월" Key="M12" Width="7%" Format="##,##.##">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                             </Columns>
                        </ig:UltraGridBand>
                        </Bands>
                         <DisplayLayout AllowColSizingDefault="Free" 
                                       AllowColumnMovingDefault="OnServer" 
                                       AllowDeleteDefault="Yes"
                                       AllowSortingDefault="Yes" 
                                       BorderCollapseDefault="Separate"
                                       HeaderClickActionDefault="SortMulti" 
                                       Name="UltraWebGrid1" 
                                       RowHeightDefault="30px"
                                       RowSelectorsDefault="No" 
                                       SelectTypeRowDefault="Extended" 
                                       Version="4.00" 
                                       CellClickActionDefault="RowSelect" 
                                       TableLayout="Fixed" 
                                       StationaryMargins="Header" 
                                       OptimizeCSSClassNamesOutput="False"
                                       ReadOnly = "LevelTwo"
                                       ColFootersVisibleDefault="No"
                                       AutoGenerateColumns="False">
                            <RowStyleDefault  CssClass="GridRowStyle" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                            <HeaderStyleDefault CssClass="GridHeaderStyle"  Cursor="Hand" ></HeaderStyleDefault>                                   
                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
                            <Images>
                                <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                            </Images>
                        </DisplayLayout>
                    </ig:UltraWebGrid> 
               </td>
             </tr>
             
           </table>
      </div>
</form>
</body>
</html>