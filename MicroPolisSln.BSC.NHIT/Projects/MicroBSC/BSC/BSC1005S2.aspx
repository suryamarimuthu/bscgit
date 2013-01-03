<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1005S2.aspx.cs" Inherits="BSC_BSC1005S2"
    MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
    <style>
        #txt td
        {
            text-align: center;
        }
        #tdScore span
        {
            font-family: 'verdana';
            font-size: 50px;
            font-weight: bold;
            line-height: 100%;
            letter-spacing: -5px;
        }
        #tdGrade span
        {
            font-family: 'verdana';
            font-size: 70px;
            font-weight: bold;
            line-height: 100%;
            letter-spacing: -5px;
        }
    </style>
    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;" class="tableBorder">
                                <tr>
                                    <td class="cssTblTitle">
                                        평가기간
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlEstTermInfo" runat="server" Width="60%" CssClass="box01" 
                                        /><asp:DropDownList ID="ddlMonthInfo" runat="server" Width="39%" CssClass="box01" />
                                    </td>
                                    <td class="cssTblTitle">
                                        부서명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlDeptList" runat="server" Width="100%" CssClass="box01" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 50%;">
                                        <asp:RadioButtonList ID="rdoGoalTong" runat="server" RepeatLayout="Flow" RepeatColumns="2"
                                            Style="cursor: pointer;" Visible="false">
                                            <asp:ListItem Text="목표(Target)" Value="TARGET" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="의지목표(Goal)" Value="GOAL"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        &nbsp;&nbsp;
                                    </td>
                                    <td class="cssPopBtnLine">
                                        <asp:ImageButton ID="iBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif"
                                            OnClick="iBtnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 250;">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;"
                                class="tableBorder">
                                <tr>
                                    <td style="text-align: center;">
                                    <DCWC:Chart ID="chart_score" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="925px" Height="248px" >
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
                                            
                                            </DCWC:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                                            </DCWC:Legend>
                                        </Legends>
                                    </DCWC:Chart>
                                    
                                      
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 10px;">
                        </td>
                        <td style="width: 150px;">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;"
                                class="tableBorder" id="txt">
                                <tr>
                                    <td class="cssTblTitle">
                                        종합등급
                                    </td>
                                </tr>
                                <tr style="height: 50%;">
                                    <td class="cssTblContent" id="tdGrade">
                                        <asp:Label ID="lblGrade" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        점수
                                    </td>
                                </tr>
                                <tr style="height: 50%;">
                                    <td class="cssTblContent" id="tdScore">
                                        <asp:Label ID="lblScore" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopTblBottomSpace">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr style="height: 100%;">
            <td>
                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow"
                    OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <%--<ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" HeaderText="ESTTERM_REF_ID"
                                    Hidden="True" Key="ESTTERM_REF_ID">
                                </ig:UltraGridColumn>--%>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" HeaderText="지표명" Key="KPI_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="TARGET" HeaderText="목표" Key="TARGET" Width="80px" Format="##,##.00">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="RESULT" HeaderText="실적" Key="RESULT" Width="80px" Format="##,##.00">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="PROGRESS" HeaderText="달성율" Key="PROGRESS" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SIGNAL_NAME" HeaderText="등급" Key="SIGNAL_NAME"
                                    Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout RowHeightDefault="20px" ReadOnly="LevelTwo" OptimizeCSSClassNamesOutput="False"
                        RowSelectorsDefault="No" AutoGenerateColumns="false">
                        <RowStyleDefault CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                        </SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                        </RowAlternateStyleDefault>
                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                        </HeaderStyleDefault>
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                        </FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    <!--- MAIN END --->
</asp:Content>
