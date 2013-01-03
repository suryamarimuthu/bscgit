<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0404S1.aspx.cs" Inherits="BSC_BSC0404S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
 
function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    {
        var cell            = igtbl_getElementById(id);
        var row             = igtbl_getRowById(id);
        var band            = igtbl_getBandById(id);
        var active          = igtbl_getActiveRow(id);
        cell.style.cursor   = 'hand';
    }
}

function AfterSelectChangeHandler(gridName, id)
{
    var row         = igtbl_getRowById(id);
    var est_dept_id = row.getCellFromKey("EST_DEPT_REF_ID").getValue();
    
    MBSCMain.location.href="usr5002.aspx?edeptid="          + est_dept_id 
                                        + "&tmcode="        + form1.ddlMonthInfo.options[form1.ddlMonthInfo.selectedIndex].value 
                                        + "&sumtype="       + form1.ddlSumType.options[form1.ddlSumType.selectedIndex].value 
                                        + "&esttermrefid="  + form1.ddlEstTermInfo.options[form1.ddlEstTermInfo.selectedIndex].value;
}
    
</script>

<script language="jscript" type="text/javascript">

function showMemo() 
{
    document.all.imgShow.style.display      = "none";
    document.all.imgHide.style.display      = "block";
    document.all.leftLayer.style.display    = "block";
}

function hiddenMemo() 
{
    document.all.imgShow.style.display      = "block";
    document.all.imgHide.style.display      = "none";
    document.all.leftLayer.style.display    = "none";
}

</script>

<!--- MAIN START --->
        <table cellpadding="0" cellspacing="0" border="0" width="100%" height="100%">
        <tr>
            <td style="width:20%;height:100%;">
              <div id="leftLayer" class="cssDivLayout">
                  <%--<table cellpadding="0" cellspacing="0" style="width: 100%;">
                      <tr>
                          <td style="height: 100%;" valign="top">--%>
                            <asp:TreeView ID="trvEstDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                        NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                          <%--</td>
                      </tr>
                  </table>--%>
                </div>
            </td>
            <td style="width: 1%" align="right">
                <asp:HiddenField ID="hdfScreenWidth" runat="server" />
                <asp:HiddenField ID="hdfScreenHeight" runat="server" />
                <a href="javascript:hiddenMemo();"><img alt="" src="../images/btn/btn_Hide.gif" id="imgHide" style="display:none" /></a><br />
                <a href="javascript:showMemo();"><img alt="" src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" /></a>   
            </td>
            <td style="width:79%;">
              <div id="rightLayer">
                   <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                     <tr>
                        <td style="height:60px; width:80%;">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                             <tr>
                                <td style="width:100%;" >
                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;" class="tableBorder">
                                         <tr>
                                           <td  class="cssTblTitle">측정주기</td>
                                           <td class="cssTblContent">
                                              <asp:DropDownList ID="ddlEstTermInfo" runat="server" Width="60%" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" AutoPostBack="True" CssClass="box01"></asp:DropDownList>
                                              <asp:DropDownList ID="ddlMonthInfo"  runat="server"  Width="36%" OnSelectedIndexChanged="ddlMonthInfo_SelectedIndexChanged" AutoPostBack="True" CssClass="box01"></asp:DropDownList>                   
                                           </td>
                                           <td class="cssTblTitle">조회구분</td>
                                           <td class="cssTblContent">
                                              <asp:DropDownList ID="ddlSumType" runat="server" OnSelectedIndexChanged="ddlSumType_SelectedIndexChanged" AutoPostBack="True" CssClass="box01"></asp:DropDownList>
                                              <asp:DropDownList ID="ddlMapLevel" runat="server" OnSelectedIndexChanged="ddlMapLevel_SelectedIndexChanged" AutoPostBack="True" CssClass="box01"></asp:DropDownList>
                                              <asp:CheckBox     ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" AutoPostBack="true" OnCheckedChanged="chkApplyExtScore_CheckedChanged" />
                                              
                                           </td>
                                         </tr>
                                         <tr>
                                            <td class="cssTblTitle">부서명</td>
                                            <td class="cssTblContent">
                                              <asp:Label ID="lblDeptName" runat="server" Width="98%" Text=" "></asp:Label>
                                            </td>
                                            <td class="cssTblTitle" >BSC점수</td>
                                            <td class="cssTblContent">
                                                <asp:Label ID="lblTotalScore" runat="server" Width="55%" Font-Bold="True" ForeColor="Navy" Text="0"></asp:Label>
                                                
                                                <asp:Label ID="lblBSCChampion" runat="server" Width="100%" Visible="false"></asp:Label>
                                            </td>
                                         </tr>
                                         <tr>
                                            <td class="cssTblTitle">조직비전</td>
                                            <td class="tdBorder" colspan="3" style="height:20px;" >
                                              <asp:Label ID="lblDeptVision" runat="server" Width="98%" Text="-"></asp:Label>&nbsp;
                                            </td>
                                         </tr>
                                        </table>
                                </td>
                             </tr>
                             <tr>
                                 <td  style="width:100%;">    
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="width:50%;">
                                                <asp:RadioButtonList ID="rdoGoalTong" runat="server" RepeatLayout="Flow" 
                                                    RepeatColumns="2" style="cursor:pointer;" Visible="false" AutoPostBack="True" 
                                                    onselectedindexchanged="rdoGoalTong_SelectedIndexChanged" >
                                                    <asp:ListItem Text="목표(Target)" Value="TARGET"></asp:ListItem>
                                                    <asp:ListItem Text="의지목표(Goal)" Value="GOAL"  Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>&nbsp;&nbsp;  
                                            </td>
                                            <td class="cssPopBtnLine">
                                                <asp:ImageButton ID="iBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" Visible="false" />
                                                <asp:ImageButton ID="iBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClick="iBtnPrint_Click" />
                                            </td>
                                        </tr>
                                    </table>            
                                                      
                                    
                                </td>
                             </tr>
                           </table>
                           
                        </td>                        
                        <td style="width:20%; height:60px;" class="cssDivLayout" >
                            <asp:GridView ID="grvSignal" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeader="false" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                <Columns>
                                    <asp:TemplateField HeaderText="신호" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Image ID="imgSignal" ImageUrl='<%# Eval("IMAGE_FILE_NAME") %>' runat="server"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="THRESHOLD_ENAME" DataField="THRESHOLD_ENAME" ItemStyle-Font-Names="wizz" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDash" runat="server" Text=":"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField HeaderText="THRESHOLD_KNAME" DataField="THRESHOLD_KNAME" HtmlEncode="False" ItemStyle-Font-Names="wizz" />
                                </Columns>
                            </asp:GridView>
                        </td>
                     </tr>
                     <tr>
                        <td colspan="2">
                            <ig:UltraWebTab runat="server" 
                                            BorderColor="#BACFEC" 
                                            BorderWidth="1" 
                                            BorderStyle="Solid"  ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="False" Width="100%" AutoPostBack="True" OnTabClick="ugrdKpiStatusTab_TabClick">
                              <Tabs>
                                      <ig:Tab Text="스코어 카드" Key="1" >
                                          <ContentTemplate>
                                          
                                             <ig:ultrawebgrid id="ugrdScoreCard" runat="server" OnInitializeRow="ugrdScoreCard_InitializeRow" OnInitializeLayout="ugrdScoreCard_InitializeLayout" Width="100%" Height="100%">
                                                    <DisplayLayout  RowHeightDefault="18px" 
                                                                    Version="3.00" 
                                                                    SelectTypeRowDefault="Single"
                                                                    ViewType="Hierarchical" 
                                                                    SelectTypeCellDefault="Extended" 
                                                                    BorderCollapseDefault="NotSet" 
                                                                    AllowColSizingDefault="Free"
                                                                    Name="ugrdScoreCard" 
                                                                    TableLayout="Fixed" 
                                                                    SelectTypeColDefault="Extended"
                                                                    OptimizeCSSClassNamesOutput="False"
                                                                    RowSelectorsDefault = "No"
                                                                    ReadOnly="LevelTwo"
                                                                    CellClickActionDefault="RowSelect">
                                                        <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                                    </DisplayLayout>
                                                    <Bands>
                                                        <ig:UltraGridBand AddButtonCaption="Column0Column1Column2" Key="Column0Column1Column2">
                                                            <AddNewRow View="NotSet" Visible="NotSet">
                                                            </AddNewRow>
                                                        </ig:UltraGridBand>
                                                    </Bands>
                                                </ig:ultrawebgrid>
                                          </ContentTemplate>
                                      </ig:Tab>
                                      <ig:TabSeparator>
                                        <Style Width="1px"></Style>
                                      </ig:TabSeparator>
                                      <ig:Tab Text="관점별/등급구간별 분포" Key="2" Visible="false">
                                          <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                              <tr>
                                                <td style="width:50%; height:20px;">
                                                  <asp:Image ID="Image1" ImageUrl="../images/icon/left_icon01.gif" runat="server" />
                                                  관점별 달성율
                                                </td>
                                                <td style="width:50%; height:20px;">
                                                  <asp:Image ID="Image2" ImageUrl="../images/icon/left_icon01.gif" runat="server" />
                                                  등급구간별 분포
                                                </td>
                                              </tr>
                                              <tr>
                                                <td style="width:50%;" valign="top">
                                                    <asp:Chart ID="chartView" Visible="false" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="220px" >
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
                                                                <Area3DStyle  WallWidth="5"/>
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
                                                    </asp:Chart>
                                                </td>
                                                  
                                                <td style="width:50%;" valign="top">
                                                    <asp:Chart ID="chartGrade" Visible="false" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="240px" Height="300px" >
                                                     <ChartAreas>
                                                            <asp:ChartArea Name="AreaGrade" BorderColor="196, 196, 196"
                                                                 BackColor="White" ShadowColor="Transparent">
                                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                </AxisX>
                                                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                </AxisX2>
                                                                <Area3DStyle  WallWidth="5"/>
                                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                </AxisY>
                                                                <AxisY2 linecolor="196, 196, 196"  IsLabelAutoFit="False" Enabled="True">
                                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                </AxisY2>
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                        <Legends>
                                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                                            </asp:Legend>
                                                        </Legends>
                                                    </asp:Chart>
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
                                 <%-- <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_greenb1.gif" SelectedImage="../images/tab/ig_tab_greenb2.gif" />--%>
                        </td>
                     </tr>
                   </table>
               </div>
            </td>
          </tr>
       </table>

<%--출력을 위한 그리드 숨김--%>
       
     <ig:ultrawebgrid id="ugrdScoreCardForPrint" runat="server" Visible="false" OnInitializeRow="ugrdScoreCard_InitializeRow" OnInitializeLayout="ugrdScoreCard_InitializeLayout" Width="100%" Height="100%">
            <DisplayLayout  RowHeightDefault="18px" 
                            Version="3.00" 
                            SelectTypeRowDefault="Single"
                            ViewType="Hierarchical" 
                            SelectTypeCellDefault="Extended" 
                            BorderCollapseDefault="NotSet" 
                            AllowColSizingDefault="Free"
                            Name="ugrdScoreCardForPrint" 
                            TableLayout="Fixed" 
                            SelectTypeColDefault="Extended" 
                            OptimizeCSSClassNamesOutput="False"
                            ReadOnly="LevelTwo"
                            CellClickActionDefault="RowSelect">
                <%--<AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver" View="Compact">
                    <BoxStyle BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                        </BorderDetails>
                    </BoxStyle>
                    <ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></ButtonStyle>
                </AddNewBox>
                <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif" BorderStyle="Solid" HorizontalAlign="Center"
                    ForeColor="White" BackColor="#94BAC9">
                    <Padding Left="0px" Right="0px"></Padding>
                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                </HeaderStyleDefault>
                <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
                <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                    BorderStyle="Solid" BackColor="#FAFCF1" Height="100%"></FrameStyle>
                <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                </FooterStyleDefault>
                <ActivationObject BorderColor="170, 184, 131"></ActivationObject>
                <GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
                    <BoxStyle BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
                    </BoxStyle>
                    <BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
                </GroupByBox>
                <RowExpAreaStyleDefault BackColor="WhiteSmoke"></RowExpAreaStyleDefault>
                <EditCellStyleDefault VerticalAlign="Middle" BorderWidth="0px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderStyle="None"
                    HorizontalAlign="Left"></EditCellStyleDefault>
                <SelectedRowStyleDefault ForeColor="White" BackColor="#BECA98"></SelectedRowStyleDefault>
                <SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="#CF5F5B"></SelectedGroupByRowStyleDefault>
                <RowStyleDefault VerticalAlign="Middle" BorderWidth="1px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderColor="#AAB883"
                    BorderStyle="Solid" HorizontalAlign="Left" ForeColor="#333333" BackColor="White">
                    <Padding Left="3px" Right="3px"></Padding>
                    <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                </RowStyleDefault>
                <ImageUrls CurrentEditRowImage="../images/tree/arrow_brown.gif" ExpandImage="../images/tree/ig_treePlus.gif"
                    CollapseImage="../images/tree/ig_treeMinus.gif" CurrentRowImage="../images/tree/arrow_brown.gif"></ImageUrls>
                <ClientSideEvents />--%>
                <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                <RowStyleDefault  CssClass="GridRowStyle" />
                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
            </DisplayLayout>
            <Bands>
                <ig:UltraGridBand AddButtonCaption="Column0Column1Column2" Key="Column0Column1Column2">
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                </ig:UltraGridBand>
            </Bands>
        </ig:ultrawebgrid>

        <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport" OnInitializeRow="ugrdEEP_InitializeRow">
        </ig:UltraWebGridExcelExporter>
               
  <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
<!--- MAIN END --->
</asp:Content>