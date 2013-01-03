<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1004S1.aspx.cs" Inherits="BSC_BSC1004S1" MasterPageFile="~/_common/lib/MicroBSC.master"%>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">

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

function AfterSelectChangeHandler(gridName, id)
{
    var row         = igtbl_getRowById(id);
    var est_dept_id = row.getCellFromKey("COM_DEPT_REF_ID").getValue();  //row.getCellFromKey("EST_DEPT_REF_ID").getValue();
    
    /*
    MBSCMain.location.href="usr5002.aspx?edeptid="          + est_dept_id 
                                        + "&tmcode="        + form1.ddlMonthInfo.options[form1.ddlMonthInfo.selectedIndex].value 
                                        + "&sumtype="       + form1.ddlSumType.options[form1.ddlSumType.selectedIndex].value 
                                        + "&esttermrefid="  + form1.ddlEstTermInfo.options[form1.ddlEstTermInfo.selectedIndex].value;
                                        */
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
    
    function OpenEstDept()
    {
        var EsttermRefID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo).ToString() %>"
        var intEstDeptID = "<%= this.ICCB1 %>"
        var strEstDeptNM = "<%= this.ICCB2 %>"
        var strLinkBtnNm = "<%= this.ICCB3 %>";
        
        var strURL       = "../BSC/BSC0406S2.aspx?ESTTERM_REF_ID="+EsttermRefID+"&CCB1="+intEstDeptID+"&CCB2="+strEstDeptNM+"&CCB3="+strLinkBtnNm;
        
        gfOpenWindow(strURL, 350, 500,0,0,'BSC0406S2'); 
    }
</script>

<!--- MAIN START --->
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
    <tr>
        <td>
            <table class="tableBorder" cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td  class="cssTblTitle" >측정주기</td>
                    <td class="cssTblContent">
                        <asp:DropDownList Width="100%" ID="ddlEstTermInfo" CssClass="box01" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td  class="cssTblTitle" >운영조직</td>
                    <td  class="cssTblContent">
                        <asp:dropdownlist id="ddlEstDept" runat="server" class="box01" width="100%" Visible="true"></asp:dropdownlist>
                        <asp:hiddenfield id="hdfDeptID" runat="server" Value="0"></asp:hiddenfield>    
                        <asp:textbox id="txtDeptName" runat="server" width="110px" Visible="false"></asp:textbox>
                        <img alt="" src='../images/btn/b_094.gif' style="cursor:hand; vertical-align:bottom; display:none;" visible="false" onclick="OpenEstDept();" />
                    </td>
                </tr>
                <tr>
                  <td  class="cssTblTitle" >측정월</td>
                  <td  class="cssTblContent">
                      <asp:DropDownList ID="ddlMonthInfo" CssClass="box01" Width="100%" runat="server"></asp:DropDownList>
                  </td>
                  <td  class="cssTblTitle" >조회구분</td>
                  <td  class="cssTblContent">
                      <asp:DropDownList ID="ddlSumType" CssClass="box01" Enabled="true"  Width="100%" runat="server"></asp:DropDownList>
                      <asp:DropDownList ID="ddlComTypeInfo" CssClass="box01" width="60px" Enabled="true" runat="server" Visible="false"></asp:DropDownList>
                      <asp:CheckBox     ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" />
                      <asp:CheckBox ID="chkInSubDept" runat="server" Text="하위조직포함" Visible="False" />  
                  </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width:50%;">
                        <asp:RadioButtonList ID="rdoGoalTong" runat="server" RepeatLayout="Flow" RepeatColumns="2" style="cursor:pointer;" Visible="false">
                            <asp:ListItem Text="목표(Target)" Value="TARGET" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="의지목표(Goal)" Value="GOAL"></asp:ListItem>
                        </asp:RadioButtonList>  
                    </td>
                    <td class="cssPopBtnLine">
                        <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                        <asp:ImageButton ID="iBtnPrint" runat="server" align="absmiddle" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClick="iBtnPrint_Click" />
                    </td>
                </tr>
            </table>       
        </td>
    </tr>
    <tr style="height:100%;">
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                <tr>
                    <td style="width: 25%;height: 100%;" valign="top">
                        <asp:Panel ID="plnScoreGrid" runat="server" Width="100%" Height="100%">
                        <!--div class=resizeMe id=outerRasiedDiv--> 
                          <div id="leftLayer" style=" width:100%; height: 100%;">
                              <table cellpadding="0" cellspacing="0" style="width: 100%; height:100%;" border="0">
                                  <tr>
                                      <td style="width:100%; height: 100%">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                          <tr>
                                            <td style="width:100%; height:100%;">
                                              <ig:UltraWebGrid ID="ugrdScore" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdScore_InitializeRow" OnClick="ugrdScore_Click" >
                                                  <Bands>
                                                      <ig:UltraGridBand>
                                                          <Columns>
                                                              <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                                                                  <Header Caption="ESTTERM_REF_ID"></Header>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="true">
                                                                  <Header Caption="YMD"><RowLayoutColumnInfo OriginX="1" /></Header>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="SUM_TYPE" Key="SUM_TYPE" Hidden="True">
                                                                  <Header Caption="SUM_TYPE"><RowLayoutColumnInfo OriginX="1" /></Header>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="ACCESS_YN" Key="ACCESS_YN" Hidden="True">
                                                                  <Header Caption="ACCESS_YN"><RowLayoutColumnInfo OriginX="1" /></Header>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Hidden="True" >
                                                                  <Header Caption="ID"><RowLayoutColumnInfo OriginX="2" /></Header>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="DEPT_TYPE" Key="DEPT_TYPE" Hidden="True" >
                                                                  <Header Caption="DEPT_TYPE"><RowLayoutColumnInfo OriginX="2" /></Header>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="RANK_ID" DataType="System.Int16" Key="RANK_ID" Width="40px">
                                                                  <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                  <Header Caption="순위"><RowLayoutColumnInfo OriginX="3" /></Header>
                                                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="EMP_NAME"  Key="EMP_NAME" Width="60px">
                                                                  <HeaderStyle HorizontalAlign="Center" />
                                                                  <Header Caption="사원명"><RowLayoutColumnInfo OriginX="4" /></Header>
                                                                  <CellStyle HorizontalAlign="Left"></CellStyle>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="SCORE" DataType="System.Double" Format="###,###,###.00" Key="SCORE" Width="40px">
                                                                  <HeaderStyle HorizontalAlign="Center" />
                                                                  <Header Caption="점수"><RowLayoutColumnInfo OriginX="5" /></Header>
                                                                  <CellStyle HorizontalAlign="Right"></CellStyle>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="DEPT_GRADE" Key="DEPT_GRADE" Width="25px" Hidden="true">
                                                                  <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                  <Header Caption="등급"><RowLayoutColumnInfo OriginX="5" /></Header>
                                                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="RANK_PERCENT" DataType="System.Double" Format="###,###,##0.00" Key="RANK_PERCENT" Width="40px" Hidden="true">
                                                                  <HeaderStyle HorizontalAlign="Center" />
                                                                  <Header Caption="%"><RowLayoutColumnInfo OriginX="5" /></Header>
                                                                  <CellStyle HorizontalAlign="Right"></CellStyle>
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Width="40px" Hidden="true">
                                                              </ig:UltraGridColumn>
                                                              <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="120px">
                                                                  <HeaderStyle HorizontalAlign="Center" />
                                                                  <Header Caption="부서명"><RowLayoutColumnInfo OriginX="5" /></Header>
                                                              </ig:UltraGridColumn>
                                                          </Columns>
                                                          <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                              <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                          </RowTemplateStyle>
                                                      </ig:UltraGridBand>
                                                  </Bands>
                                                  <DisplayLayout    AllowColSizingDefault="Free" 
                                                                        AllowColumnMovingDefault="OnServer" 
                                                                        AllowDeleteDefault="Yes" 
                                                                        AutoGenerateColumns="False" 
                                                                        BorderCollapseDefault="Separate"
                                                                        CellClickActionDefault="RowSelect" 
                                                                        CellPaddingDefault="2" 
                                                                        HeaderClickActionDefault="NotSet"
                                                                        Name="ugrdScore" 
                                                                        HeaderStyleDefault-Height="26px" 
                                                                        RowHeightDefault="20px" 
                                                                        RowSelectorsDefault="No" 
                                                                        SelectTypeRowDefault="Extended"
                                                                        StationaryMargins="Header" 
                                                                        TableLayout="Fixed" Version="4.00" 
                                                                        AllowRowNumberingDefault="Continuous" 
                                                                         OptimizeCSSClassNamesOutput="False"
                                                                         
                                                                        ScrollBarView="Vertical">
                                                     
                                                      <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                        
                                                  </DisplayLayout>
                                              </ig:UltraWebGrid>
                                            </td>
                                          </tr>
                                          <tr style="display:none;">
                                            <td align="right" style="height:40px;">
                                              <asp:ImageButton ID="iBtnPrintRank" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClick="iBtnPrintRank_Click"/>
                                            </td>
                                          </tr>
                                        </table>
                                      </td>
                                  </tr>
                              </table>
                          </div>
                        </asp:Panel>
                    </td>
                    <td style="width: 4px">&nbsp;
                        <a href="javascript:hiddenMemo();" style="display:none;"><img alt="" src="../images/btn/btn_Hide.gif" id="imgHide" /></a><br />
                        <a href="javascript:showMemo();"><img alt="" src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" /></a>   
                    </td>
                    <td style="width: 100%;height:100%">
                      <div id="RL" style=" width:100%; height:100%;">
                         <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                           <tr>
                             <td valign="top" style="height:90px;">
                                <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                  <tr>
                                    <td class="cssTblTitle"  width="80">
                                        부서명</td>
                                    <td class="tdBorder" colspan="3">
                                      <asp:Label ID="lblDeptName" runat="server" Width="98%"></asp:Label>
                                    </td>
                                    <td class="subTableTitle" width="150" rowspan="4" align="right">
                                      <asp:GridView ID="grvSignal" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeader="false" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                        <Columns>
                                          <asp:TemplateField HeaderText="신호" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                              <asp:Image ID="imgSignal" ImageUrl='<%# "../images/"+Eval("IMAGE_FILE_NAME") %>' runat="server"/>
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
                                    <td class="cssTblTitle"  width="80">
                                        평가년월</td>
                                    <td class="tdBorder" colspan="3">
                                      <asp:Label ID="lblDeptVision" runat="server" Width="98%"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle"  width="80">사원명</td>
                                    <td class="tdBorder" style="width:100px;" >
                                      <asp:Label ID="lblBSCChampion" runat="server" Width="95%"></asp:Label>
                                    </td>
                                    <td  class="cssTblTitle" width="80">
                                        순위</td>
                                    <td class="tdBorder" style="width:100px;">
                                        <asp:Label ID="lblRank"    runat="server" Font-Bold="True" ForeColor="Navy" Text=" "></asp:Label>/
                                        <asp:Label ID="lblRankAll" runat="server" Font-Bold="True" ForeColor="Navy" Text=" "></asp:Label>
                                    </td>
                                </tr>
                                    <tr>
                                        <td  class="cssTblTitle" width="80">
                                            BSC점수</td>
                                        <td class="tdBorder">
                                            <asp:Label ID="lblTotalScore" runat="server" Width="90%" Font-Bold="True" ForeColor="Navy" Text="0"></asp:Label>
                                        </td>
                                        <td  class="cssTblTitle" width="80">
                                            등급</td>
                                        <td class="tdBorder">
                                            <asp:Label ID="lblGrade" runat="server" Width="90%" Font-Bold="True" ForeColor="Navy" Text=" "></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                             </td>
                           </tr>
                           <tr>
                             <td>
                                 <ig:ultrawebgrid id="ugrdScoreCard" 
                                                  runat="server" 
                                                  OnInitializeRow="ugrdScoreCard_InitializeRow" 
                                                  OnInitializeLayout="ugrdScoreCard_InitializeLayout" Width="100%" Height="90%">
                                    <DisplayLayout RowHeightDefault="18px" 
                                                   Version="3.00" 
                                                   SelectTypeRowDefault="Single" 
                                                   OptimizeCSSClassNamesOutput="False"
                                                    ViewType="Hierarchical" 
                                                    SelectTypeCellDefault="Extended" 
                                                    BorderCollapseDefault="NotSet" 
                                                    AllowColSizingDefault="Free"
                                                    Name="ugrdScoreCard" 
                                                    TableLayout="Fixed" 
                                                    SelectTypeColDefault="Extended" 
                                                    ScrollBar="Auto"
                                                    NoDataMessage=" "
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
                             </td>
                           </tr>
                         </table>
                      </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false" />
                    </td>
                </tr>
            </table>
            
            <ig:ultrawebgrid id="ugrdScoreRankPrint" runat="server" Width="100%" Height="92%" Visible="false" OnInitializeRow="ugrdScoreRankPrint_InitializeRow" >
                <DisplayLayout Name="ugrdScoreRankPrint" Version="4.00" 
                    RowHeightDefault="18px" 
                    SelectTypeRowDefault="Single"
                    ViewType="Hierarchical" 
                    SelectTypeCellDefault="Extended" 
                    BorderCollapseDefault="NotSet" 
                    AllowColSizingDefault="Free"
                    TableLayout="Fixed" 
                    SelectTypeColDefault="Extended" 
                    CellClickActionDefault="RowSelect" 
                     OptimizeCSSClassNamesOutput="False"
                    AutoGenerateColumns="False">
                    <%--<AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver" View="Compact">
                        <BoxStyle BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </BoxStyle>
                        <ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></ButtonStyle>
                    </AddNewBox>
                    <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif" BorderStyle="Solid" HorizontalAlign="Center"
                        ForeColor="White" BackColor="#94BAC9" Height="35px">
                        <Padding Left="0px" Right="0px"></Padding>
                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </HeaderStyleDefault>
                    <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
                    <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                    <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                        BorderStyle="Solid" BackColor="#FAFCF1" Height="92%"></FrameStyle>
                    <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </FooterStyleDefault>
                    <ActivationObject BorderColor="170, 184, 131" BorderWidth=""></ActivationObject>
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
                    <ClientSideEvents DblClickHandler="AfterSelectChangeHandler"  />
                    <Images>
                        <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                        <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                        <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                        <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                    </Images>--%>
                    <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            
                </DisplayLayout>
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <Columns>
                          <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                              Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                              <Header Caption="ESTTERM_REF_ID">
                              </Header>
                              <Footer Caption="">
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                              Format="" HeaderText="YMD" Key="YMD" Hidden="true">
                              <Header Caption="YMD">
                                  <RowLayoutColumnInfo OriginX="1" />
                              </Header>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="1" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="SUM_TYPE" EditorControlID="" FooterText=""
                              Format="" HeaderText="SUM_TYPE" Hidden="True" Key="SUM_TYPE">
                              <Header Caption="SUM_TYPE">
                                  <RowLayoutColumnInfo OriginX="1" />
                              </Header>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="1" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="ACCESS_YN" EditorControlID="" FooterText=""
                              Format="" HeaderText="ACCESS_YN" Hidden="True" Key="ACCESS_YN">
                              <Header Caption="ACCESS_YN">
                                  <RowLayoutColumnInfo OriginX="1" />
                              </Header>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="1" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" EditorControlID="" FooterText=""
                              Format="" HeaderText="부서ID" Hidden="True" Key="EST_DEPT_REF_ID">
                              <Header Caption="부서ID">
                                  <RowLayoutColumnInfo OriginX="2" />
                              </Header>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="2" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="DEPT_TYPE" EditorControlID="" FooterText=""
                              Format="" HeaderText="DEPT_TYPE" Hidden="True" Key="DEPT_TYPE">
                              <Header Caption="DEPT_TYPE">
                                  <RowLayoutColumnInfo OriginX="2" />
                              </Header>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="2" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="RANK_ID" DataType="System.Int16" HeaderText="순위"
                              Hidden="false" Key="RANK_ID" Width="80px">
                              <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                              <Header Caption="순위">
                                  <RowLayoutColumnInfo OriginX="3" />
                              </Header>
                              <CellStyle HorizontalAlign="Center">
                              </CellStyle>
                              <Footer>
                                  <RowLayoutColumnInfo OriginX="3" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                              Format="" HeaderText="부서명" Key="DEPT_NAME" Width="350px" Hidden="false">
                              <HeaderStyle HorizontalAlign="Center" />
                              <Header Caption="부서명">
                                  <RowLayoutColumnInfo OriginX="4" />
                              </Header>
                              <CellStyle HorizontalAlign="Left">
                              </CellStyle>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="4" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="SCORE" DataType="System.Double" EditorControlID=""
                              FooterText="" Format="###,###,###.00" HeaderText="점수" Key="SCORE" Width="80px">
                              <HeaderStyle HorizontalAlign="Center" />
                              <Header Caption="점수">
                                  <RowLayoutColumnInfo OriginX="5" />
                              </Header>
                              <CellStyle HorizontalAlign="Right">
                              </CellStyle>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="5" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="DEPT_GRADE" DataType="System.String" EditorControlID=""
                              FooterText="" HeaderText="등급" Key="DEPT_GRADE" Width="80px" Hidden="false">
                              <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                              <Header Caption="등급">
                                  <RowLayoutColumnInfo OriginX="5" />
                              </Header>
                              <CellStyle HorizontalAlign="Center">
                              </CellStyle>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="5" />
                              </Footer>
                          </ig:UltraGridColumn>
                          <ig:UltraGridColumn BaseColumnName="RANK_PERCENT" DataType="System.Double" EditorControlID=""
                              FooterText="" Format="###,###,###.00" HeaderText="점수" Key="RANK_PERCENT" Width="40px" Hidden="true">
                              <HeaderStyle HorizontalAlign="Center" />
                              <Header Caption="%">
                                  <RowLayoutColumnInfo OriginX="5" />
                              </Header>
                              <CellStyle HorizontalAlign="Right">
                              </CellStyle>
                              <Footer Caption="">
                                  <RowLayoutColumnInfo OriginX="5" />
                              </Footer>
                          </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
            </ig:ultrawebgrid>
                
            <ig:ultrawebgrid id="ugrdScoreCardPrint" runat="server" Width="100%" Height="92%" OnInitializeRow="ugrdScoreCardPrint_InitializeRow" OnInitializeLayout="ugrdScoreCardPrint_InitializeLayout" Visible="False">
                <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single" OptimizeCSSClassNamesOutput="False"
                    ViewType="Hierarchical" SelectTypeCellDefault="Extended" BorderCollapseDefault="NotSet" AllowColSizingDefault="Free"
                    Name="ugrdScoreCardPrint" TableLayout="Fixed" SelectTypeColDefault="Extended" CellClickActionDefault="RowSelect" AutoGenerateColumns="False">
                    <%--<AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver" View="Compact">
                        <BoxStyle BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </BoxStyle>
                        <ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></ButtonStyle>
                    </AddNewBox>

                    <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif" BorderStyle="Solid" HorizontalAlign="Center"
                        ForeColor="White" BackColor="#94BAC9" Height="35px">
                        <Padding Left="0px" Right="0px"></Padding>
                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </HeaderStyleDefault>
                    <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
                    <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                    <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                        BorderStyle="Solid" BackColor="#FAFCF1" Height="92%"></FrameStyle>
                    <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </FooterStyleDefault>
                    <ActivationObject BorderColor="170, 184, 131" BorderWidth=""></ActivationObject>
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
                    <ClientSideEvents DblClickHandler="AfterSelectChangeHandler"  />
                    <Images>
                        <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                        <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                        <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                        <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                    </Images>--%>
                    <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            
                </DisplayLayout>
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <Columns>
                            <ig:UltraGridColumn BaseColumnName="VIEW_NAME" Key="VIEW_NAME" Width="100px" MergeCells="True" HeaderText="관점명" Hidden="true">
                                <Header Caption="관점명">
                                </Header>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="STG_NAME" Key="STG_NAME" Width="150px" MergeCells="True" HeaderText="전략명"  Hidden="true">
                                <Header Caption="전략명">
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="250px" HeaderText="지표명">
                                <Header Caption="지표명">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="UNIT" Key="UNIT" Width="50px" HeaderText="단위">
                                <Header  Caption="단위">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="TARGET" Key="TARGET" Width="90px" DataType="System.Double" Format="#,##0.00" HeaderText="목표">
                                <Header Caption="목표">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="RESULT" Key="RESULT" Width="90px" DataType="System.Double" Format="#,##0.00" HeaderText="실적">
                                <Header Caption="실적">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="SIGNAL_NAME" Key="SIGNAL_NAME" Width="100px" HeaderText="시그널">
                                <Header Caption="시그널">
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT" Width="60px" Format="#,##0.00" HeaderText="원시가중치">
                                <Header Caption="원시가중치">
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Header>
                                <HeaderStyle Wrap="True" />
                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="CURRENT_WEIGHT" Key="CURRENT_WEIGHT" Width="60px" Format="#,##0.00" HeaderText="변환가중치">
                                <Header Caption="변환가중치">
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Header>
                                <HeaderStyle Wrap="True" />
                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="ORI_POINT" Key="ORI_POINT" Width="60px" Format="#,##0.00" HeaderText="획득점수">
                                <Header Caption="획득점수">
                                    <RowLayoutColumnInfo OriginX="9" />
                                </Header>
                                <HeaderStyle Wrap="True" />
                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="9" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="POINT" Key="POINT" Width="60px" Format="#,##0.00" HeaderText="변환점수">
                                <Header Caption="변환점수">
                                    <RowLayoutColumnInfo OriginX="10" />
                                </Header>
                                <HeaderStyle Wrap="True" />
                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="10" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="AC_POINT" Key="AC_POINT" Width="60px" Format="#,##0.00" HeaderText="최종점수">
                                <Header Caption="최종점수">
                                    <RowLayoutColumnInfo OriginX="11" />
                                </Header>
                                <HeaderStyle Wrap="True" />
                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="11" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
            </ig:ultrawebgrid>
                                    
            <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport" OnInitializeRow="ugrdEEP_InitializeRow">
            </ig:UltraWebGridExcelExporter>
            
            <ig:UltraWebGridExcelExporter ID="ugrdEEP_Rank" runat="server" OnBeginExport="ugrdEEP_Rank_BeginExport">
            </ig:UltraWebGridExcelExporter>
            
            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
            <asp:linkbutton id="lBtnReload" runat="server" onclick="lBtnReload_Click"></asp:linkbutton>
        </td>
    </tr>
</table>
<!--- MAIN END --->
</asp:Content>