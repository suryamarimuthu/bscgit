<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0303M1.aspx.cs" Inherits="BSC_BSC0303M1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC::성과관리 시스템::KPI 수정</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script id="Infragistics" type="text/javascript">
    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell = igtbl_getElementById(id);
           var row = igtbl_getRowById(id);
           var band = igtbl_getBandById(id);
           var active = igtbl_getActiveRow(id);
           cell.style.cursor = 'hand';
        }
    }
</script>
</head>
<body style="margin:0,0,0,0;">
    <form id="form1" runat="server" style="margin-top:0px;margin-left:0px">
        <table border="0" cellpadding="0" cellspacing="0" style="vertical-align:top; width:100%; height:100%;"">
            <tr>
                <td colspan="2" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                            <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top"><img src="../images/title/popup_t5.gif" width="230" height="40"></td>
                                        <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr> 
                                        <td width="50%" height="4" bgcolor="FFFFFF"></td>
                                        <td width="50%" bgcolor="FFFFFF"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                     </table>
                </td>
            </tr>
            <tr class="cssPopContent">
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                        <tr>
                            <td colspan="2" valign="top">
                               <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="cssTblTitle">KPI 코드</td>
                                    <td class="cssTblContent"><asp:TextBox ID="txtKpiCode" runat="server" BorderWidth="0" Width="100%"></asp:TextBox></td>
                                    <td class="cssTblTitle">KPI 명</td>
	                                <td class="cssTblContent">
                                        <asp:Label ID="lblKpiName" runat="server" Text="" ></asp:Label>
                                    </td>
                                </tr>
                               </table>
                            </td>
                        </tr>
                        <tr class="cssPopTblBottomSpace"><td colspan="2">&nbsp;</td></tr>
                        <tr style="height:100%;">
                            <td valign="top" style="width: 250px">
                                <ig:UltraWebGrid ID="ugrdTarget" runat="server" Height="100%" Width="100%" OnActiveRowChange="ugrdTarget_ActiveRowChange">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="평가기간코드" Key="ESTTERM_REF_ID" Width="38px" Hidden="True">
                                                    <Header Caption="평가기간코드">
                                                    </Header>
                                                    <HeaderStyle Wrap="True" HorizontalAlign="Center" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn AllowUpdate="No" BaseColumnName="ESTTERM_NAME"
                                                    HeaderText="평가기간명" Key="ESTTERM_NAME" Type="Custom" Width="120px" Hidden="True"  >
                                                    <Header Caption="평가기간명">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                        
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="KPI_TARGET_VERSION_ID" HeaderText="목표버젼ID"
                                                    Key="KPI_TARGET_VERSION_ID" Type="Custom" Width="98px"  Hidden="True">
                                                    <Header Caption="목표버젼ID">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                        
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="VERSION_NAME" HeaderText="VERSION 명"
                                                    Key="VERSION_NAME" Type="Custom" Width="150px">
                                                    <Header Caption="VERSION 명">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                        
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="VERSION_DESC" HeaderText="누계"
                                                    Key="VERSION_DESC" Type="Custom" Width="98px" Hidden="True">
                                                    <Header Caption="누계">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                        
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="VERSION_NUMBER" DataType="System.Int32" HeaderText="VERSION 번호"
                                                    Key="VERSION_NUMBER" Hidden="True">
                                                    <Header Caption="VERSION 번호">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="UPDATE_TERM" DataType="System.Int32" HeaderText="수정기간"
                                                    Hidden="True" Key="UPDATE_TERM">
                                                    <Header Caption="수정기간">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="CREATE_DATE" DataType="System.Date" HeaderText="생성일자" Key="CREATE_DATE" Width="80px" Hidden="True">
                                                    <Header Caption="생성일자">
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ENABLE_REG" HeaderText="등록가능여부" Key="ENABLE_REG" Width="75px">
                                                    <Header Caption="등록가능여부">
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False"
                                        BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" CellPaddingDefault="2"
                                        HeaderClickActionDefault="NotSet" JavaScriptFileName="" JavaScriptFileNameCommon=""
                                        Name="ugrdTarget" RowHeightDefault="20px" RowSelectorsDefault="No" ScrollBar="Never"
                                        ScrollBarView="Horizontal" Version="4.00">
                                        <%--<GroupByBox>
                                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                        </GroupByBox>
                                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                            <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                        </GroupByRowStyleDefault>
                                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthTop="1px" />
                                        </FooterStyleDefault>
                                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                            <Padding Left="3px" />
                                        </RowStyleDefault>
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                            ForeColor="White" HorizontalAlign="Left">
                                            <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="1px"
                                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="320px" Width="250px">
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
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>
                                        <Images ImageDirectory="">
                                        </Images>--%>
                                        <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate" MouseOverHandler="MouseOverHandler" />
                                        
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                            <td valign="top">
                                <ig:UltraWebTab runat="server" ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="False" Width="100%" SelectedTab="0" AutoPostBack="True">
                                  <Tabs>
                                      <ig:Tab Text="등록정보" Key="1">
                                        <Style Width="160px" Height="25px" />
                                          <ContentTemplate>
		                                    <table id="Table1" border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%" style="height:100%;">
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        평가기간명</td>
                                                    <td class="cssTblContentSingle">
                                                        <asp:TextBox ID="txtTermName" runat="server" Enabled="False" Width="100%" BackColor="whiteSmoke"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        버젼명</td>
                                                    <td class="cssTblContentSingle">
                                                        <asp:TextBox ID="txtVersionName" runat="server" Width="100%"></asp:TextBox></td>
                                                        
                                                </tr>
                                                <tr style="height:100%;">
                                                    <td class="cssTblTitleSingle">수정사유</td>
                                                    <td class="cssTblContentSingle">
                                                        <asp:TextBox ID="txtVersionDesc" runat="server" Height="185px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        버젼번호</td>
                                                    <td class="cssTblContentSingle">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtVersionNumber" runat="server" BackColor="whiteSmoke" Width="100%" ReadOnly="true"></asp:TextBox>
                                                                </td>
                                                                <td style="width:120px;">
                                                                    <span style="color: #0000ff">(※1번은 최초계획)</span></td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        등록일자</td>
                                                    <td class="cssTblContentSingle">
                                                        <asp:TextBox ID="txtRegDate" runat="server"  BackColor="whiteSmoke" Width="100%" ReadOnly="true"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        수정계획등록여부</td>
                                                    <td class="cssTblContentSingle">
                                                        <asp:TextBox ID="txtEnabelReg" runat="server" BackColor="whiteSmoke" Width="100%" ReadOnly="true"></asp:TextBox></td>
                                                </tr>
                                            </table>
		                                 </ContentTemplate>
                                      </ig:Tab>
                                      <ig:TabSeparator>
                                        <Style Width="1px"></Style>
                                      </ig:TabSeparator>
                                      <ig:Tab Text="버전별 계획" Key="5">
                                        <Style Width="170px"  Height="25px" />
                                        <ContentTemplate>
                                          <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                                            <tr>
                                              <td style="height:100%;" valign="top">
                                                    <ig:UltraWebGrid ID="UltraDetailList" runat="server" Height="100%" Width="100%" ImageDirectory="">
                                                        <Bands>
                                                            <ig:UltraGridBand>
                                                                <Columns>
                                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="년월" Key="YMD" Width="50px">
                                                                        <Header Caption="년월">
                                                                            <RowLayoutColumnInfo OriginX="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign = "Center"> 
                                                                        </CellStyle> 
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Footer>
                                                                            <RowLayoutColumnInfo OriginX="0" />
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="TARGET_MS" HeaderText="당월계획" Key="TARGET_MS" Width="150px" Format="#,##0">
                                                                        <Header Caption="당월계획">
                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign = "Right"> 
                                                                            <Padding Right="10" />
                                                                        </CellStyle> 
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Footer>
                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" HeaderText="누적계획" Key="TARGET_TS" Width="150px" Format="#,##0">
                                                                        <Header Caption="누적계획">
                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign = "Right"> 
                                                                            <Padding Right="10" />
                                                                        </CellStyle> 
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Footer>
                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                </Columns>
                                                            </ig:UltraGridBand>
                                                        </Bands>
                                                        <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False"
                                                            BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" CellPaddingDefault="2"
                                                            HeaderClickActionDefault="NotSet" JavaScriptFileName="" JavaScriptFileNameCommon=""
                                                            Name="UltraDetailList" RowHeightDefault="20px" RowSelectorsDefault="No"
                                                            ScrollBarView="Horizontal" Version="4.00">
                                                            <%--<GroupByBox>
                                                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                            </GroupByBox>
                                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                                <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                            </GroupByRowStyleDefault>
                                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                                            </FooterStyleDefault>
                                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                <Padding Left="3px" />
                                                            </RowStyleDefault>
                                                            <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                ForeColor="White" HorizontalAlign="Center">
                                                                <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                            </HeaderStyleDefault>
                                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                            </EditCellStyleDefault>
                                                            <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="1px"
                                                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                                                            <ActivationObject BorderColor="" BorderWidth="">
                                                            </ActivationObject>
                                                            <Images ImageDirectory="">
                                                            </Images>--%>
                                                            <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdEstLevel_DblClickHandler" />
                                                            
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
                                          </table>                        
                                        </ContentTemplate>
                                      </ig:Tab>
                                  </Tabs>
                                  <DefaultTabStyle BackColor="White" Height="20px" CssClass="cssTabStyleOff">
                                  </DefaultTabStyle>
                                  <SelectedTabStyle CssClass="cssTabStyleOn" />
                                  <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif" SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                              </ig:UltraWebTab>
                            </td>
                        </tr>
                        <tr class="cssPopBtnLine">
                            <td colspan="2">
                                <asp:HiddenField ID="hdfVersionRefID" runat="server" Value="" />
                                <asp:ImageButton ID="iBtnReg" runat="server" ImageUrl="~/images/btn/b_094.gif" OnClick="iBtnReg_Click" />
                                <asp:ImageButton ID="iBtnClear" runat="server" ImageUrl="~/images/btn/b_075.gif" OnClick="iBtnClear_Click" />
		                        <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server" OnClick="iBtnInsert_Click"  />
		                        <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" OnClick="iBtnUpdate_Click"  />
		                        <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/b_004.gif" runat="server" OnClick="iBtnDelete_Click"  />
                                <img alt="" src="../images/btn/b_003.gif" style="cursor:hand;" onclick="self.close();" />
                                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                           </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                            <td style="width:50%; background-color:#FFFFFF"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

