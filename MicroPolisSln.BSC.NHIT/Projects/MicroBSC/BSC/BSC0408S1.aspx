<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0408S1.aspx.cs" Inherits="BSC_BSC0408S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script type="text/javascript" language="javascript" >
        function ugrdSelectValidationList_DblClickHandler(gridName, cellId)
        {
            var cell            = igtbl_getElementById(cellId);
            var row             = igtbl_getRowById(cellId);
            var kpiID           = row.getCellFromKey("KPI_REF_ID").getValue();
            var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var group_ref_id    = row.getCellFromKey("GROUP_REF_ID").getValue();
            var emp_ref_id      = row.getCellFromKey("EMP_REF_ID").getValue();
            var url             = 'BSC0803M1.aspx?iType=U&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + "&GROUP_REF_ID="+group_ref_id + "&EMP_REF_ID="+emp_ref_id;
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
        }
        
        function showTotalOpinionWindow()
        {
            var url   = "BSC0505M1.aspx?iType=POP&ESTTERM_REF_ID="+"<%= this.IEstTermRefID %>"+"&YMD="+"<%= this.IYmd %>";
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0505M1');
            return false;
        }
    </script>

       <!--- MAIN START --->
<table border="0" cellpadding="0" cellspacing="0" style="width:100%;height:100%;">
    <tr>
        <td style="width:100%;">
            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="cssTblTitle">평가기간</td>
                    <td class="cssTblContent" >
                        <asp:DropDownList ID="ddlEstTermInfo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" CssClass="box01 "></asp:DropDownList><asp:DropDownList ID="ddlMonthInfo" runat="server" CssClass="box01"></asp:DropDownList>
                        <asp:CheckBox     ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" Visible="false" />
                    </td>
                    <td class="cssTblTitle">구분</td>
                    <td class="cssTblContent">
                        
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                            <tr>
                                <td style="width:170px;" valign="middle">
                                    <asp:RadioButtonList ID="rdoGubun" runat="server" RepeatLayout="Flow" RepeatColumns="2" AutoPostBack="true">
                                        <asp:ListItem Text="년별 분석" Value="AY" Selected="True"></asp:ListItem><asp:ListItem Text="월별 분석" Value="AM"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style="width: 190px;">
                                    <asp:Panel ID="pnlAY" runat="server">
                                        최근
                                        <ig:webnumericedit id="txtYearTerm" runat="server" Width="20px" Nullable="False" ValueText="3" BorderColor="red" BorderWidth="2px"
                                            MaxValue="10" MinValue="3" ToolTip="3~10" NegativeForeColor="Magenta" HorizontalAlign="center"
                                            Font-Size="9pt" Font-Names="Verdana" Height="100%" NullText="3" MinDecimalPlaces="None" >
                                        </ig:webnumericedit>
                                        년간 누계분석
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAM" runat="Server" Width="190px">
                                        <table border="0" cellpadding="0" cellspacing="0" width="190px">
                                            <tr>
                                                <td style="width:60px;">
                                                    <ig:WebDateTimeEdit ID="wdtSYM" runat="server" EditModeFormat="yyyy/MM" Width="60px" HorizontalAlign="center" DataMode="Date"></ig:WebDateTimeEdit>
                                                </td>
                                                <td style="width:10px;">~</td>
                                                <td align="left" style="width: 60px;">
                                                    <ig:WebDateTimeEdit ID="wdtEYM" runat="server" EditModeFormat="yyyy/MM" Width="60px" HorizontalAlign="center" DataMode="Date"></ig:WebDateTimeEdit>
                                                </td>
                                                <td style="width: 70px; padding-left: 3px;">
                                                    <asp:dropdownlist id="ddlSumType" runat="server" CssClass="box01" Width="60px" ></asp:dropdownlist><%--<asp:dropdownlist id="ddlGraphType" runat="server" CssClass="box01" Width="80px" Visible="false" ></asp:dropdownlist>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>                   
                                </td>
                                
                            </tr>
                        </table>
                        
                    </td>
                    
                </tr>                                
            </table>
        </td>
    </tr>
     <tr>
        <td  style="width:100%;">
            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                <tr>
                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                    <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="전사지표현황"/></td>
                    <td  class="cssPopBtnLine">
                        <asp:ImageButton ID="iBtnSelect" runat="server" OnClick="iBtnSe_Click" ImageUrl="~/images/btn/b_033.gif" ImageAlign="AbsMiddle" />
                        <%--<asp:Button ID="iBtnOp" runat="server" Text="종합분석" ForeColor="white" OnClientClick="return showTotalOpinionWindow();" />--%>
                        <asp:linkbutton id="lBtnReload" runat="server" onclick="lBtnReload_Click"></asp:linkbutton>
                        <asp:Literal ID="ltrScript" runat="server" />
                    </td>
                </tr>
            </table>
            
        </td>
    </tr>
    <tr>
        <td style="height:100%;" >
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                <tr>
                  <td align="center">
                        <asp:Chart ID="chartView" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="100px" Height="100px" >
                            <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                            </asp:Legend>
                         </Legends>
                         <Titles >
                          <asp:Title Alignment="TopCenter" Text="관점별 달성율" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                         </Titles>
                      </asp:Chart>
                  </td>
               
                  <td align="center">
                      <asp:Chart ID="chartGrade" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="150px" Height="100px" >
                         <ChartAreas>
                            <asp:ChartArea Name="AreaGrade" BorderColor="196, 196, 196"
                                 BackColor="White" ShadowColor="Transparent">
                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1" Enabled="True">
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisX>
                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1" Enabled="False">
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisX2>
                                <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                <AxisY linecolor="196, 196, 196"  IsLabelAutoFit="False" Enabled="True" >
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
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                            </Legends>
                            <Titles >
                              <asp:Title Alignment="TopCenter" Text="지표등급별 분포" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                            </Titles>
                      </asp:Chart>
                  </td>
               
                  <td align="center">
                      <asp:Chart ID="chartGroup" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="150px" Height="100px" >
                         <ChartAreas>
                            <asp:ChartArea Name="AreaGroup" BorderColor="196, 196, 196"
                                 BackColor="White" ShadowColor="Transparent">
                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1" Enabled="True">
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisX>
                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1" Enabled="False">
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisX2>
                                <Area3DStyle  WallWidth="2" Enable3D="True"/>
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
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                            </Legends>
                            <Titles >
                              <asp:Title Alignment="TopCenter" Text="지표유형별 분포" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                            </Titles>
                      </asp:Chart>
                  </td>
                </tr>
             </table>
       </td>
    </tr>
    
    <tr>
        <td style="width:100%;">
            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                <tr>
                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                    <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="주요지표분석"/></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
       <td>
             <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%; border-collapse:collapse;">
                <tr runat="server" id="tr01">
                  <td align="center">
                          <asp:Chart ID="chtKPI1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="120px" >
                             <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                             </Legends>
                             <Titles >
                              <asp:Title Alignment="TopCenter" Text="No Data" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                             </Titles>
                          </asp:Chart>
                  </td>
                  <td align="center">
                          <asp:Chart ID="chtKPI2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="120px" >
                             <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                             </Legends>
                             <Titles >
                              <asp:Title Alignment="TopCenter" Text="No Data" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                             </Titles>
                          </asp:Chart>
                  </td>
                
                  <td align="center">
                          <asp:Chart ID="chtKPI3" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="120px" >
                             <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                             </Legends>
                             <Titles >
                              <asp:Title Alignment="TopCenter" Text="No Data" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                             </Titles>
                          </asp:Chart>
                  </td>
                  <td align="center">
                          <asp:Chart ID="chtKPI4" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="120px" >
                             <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                             </Legends>
                             <Titles >
                              <asp:Title Alignment="TopCenter" Text="No Data" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                             </Titles>
                          </asp:Chart>
                  </td>
                </tr>
                <tr runat="server" id="tr03">
                  <td align="center">
                          <asp:Chart ID="chtKPI5" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="120px" >
                             <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                             </Legends>
                             <Titles >
                              <asp:Title Alignment="TopCenter" Text="No Data" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                             </Titles>
                          </asp:Chart>
                  </td>
                  <td align="center">
                          <asp:Chart ID="chtKPI6" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="120px" >
                             <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                             </Legends>
                             <Titles >
                              <asp:Title Alignment="TopCenter" Text="No Data" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                             </Titles>
                          </asp:Chart>
                  </td>
               
                  <td align="center">
                          <asp:Chart ID="chtKPI7" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="120px" >
                             <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                             </Legends>
                             <Titles >
                              <asp:Title Alignment="TopCenter" Text="No Data" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                             </Titles>
                          </asp:Chart>
                  </td>
                  <td align="center">
                          <asp:Chart ID="chtKPI8" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="120px" >
                             <ChartAreas>
                                <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                     BackColor="White" ShadowColor="Transparent">
                                    <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX>
                                    <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisX2>
                                    <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                    <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY>
                                    <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                    </AxisY2>
                                </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                </asp:Legend>
                             </Legends>
                             <Titles >
                              <asp:Title Alignment="TopCenter" Text="No Data" Font="Tahoma, 11px" Name="Title1"></asp:Title>
                             </Titles>
                          </asp:Chart>
                  </td>
                </tr>
             </table>
       </td>
     </tr>
   </table>

       
 </asp:Content>
