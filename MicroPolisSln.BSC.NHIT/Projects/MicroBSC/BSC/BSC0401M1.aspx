<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0401M1.aspx.cs" Inherits="BSC_BSC0401M1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>

<script id="" type="text/javascript">
    function findValue(strGridName)
    {
        var grid      = igtbl_getGridById(strGridName);
        var findValue = document.form1.txtStgFind.value;
        var re        = new RegExp("^" + findValue, "gi");
        
        var cellRtn   = grid.find(re);
       
        if (cellRtn != null)
        {
            cellRtn.setSelected(true);
        }
    }
    
    function openDeptEmp(strKeyObj, strValObj)
    {
        var estterm_ref_id  = <%= this.IEstTermRefID.ToString() %>;
        var url             = "../ctl/ctl2106.aspx?ESTTERM_REF_ID="+ estterm_ref_id +"&OBJ_KEY="+ strKeyObj + "&OBJ_VAL=" + strValObj;
        
        gfOpenWindow(url, 750, 400, 'yes', 'no', 'svr2002_3');
    }
    
    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    {
           var cell   = igtbl_getElementById(id);
           var row    = igtbl_getRowById(id);
           var band   = igtbl_getBandById(id);
           var active = igtbl_getActiveRow(id);
           cell.style.cursor = 'hand';
        }
    }
    
    function AlertDeleteStg()
    {
        if (confirm('전략 삭제시 해당전략의 KPI 및 상위전략이 삭제됩니다. 삭제하시겠습니까?'))
        {
            return true;
        }
        else
        {
            return false;
        }        
    }
    
    function openFullStgMap()
    {
        var url = '../usr/usr_stg_map.aspx?ESTTERM_REF_ID=<%= Convert.ToString(IEstTermRefID) %>&EST_DEPT_REF_ID=<%= Convert.ToString(IEstDeptRefID) %>&MAP_VERSION_ID=<%= Convert.ToString(IMapVersionID) %>&TMCODE=<%= Convert.ToString(IYmd) %>&LINE_TYPE=0&SHOW_KPI_LIST=1&DRAWING_YN=Y';
        var wo  = window.open(url, 'WinPop','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=yes,resizable=0,top=0,left=0,width=screen.width, height=screen.height');
        wo.resizeTo(screen.width,screen.height);
    }
</script>

<html>
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html; " />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
  <form id="form1" runat="server">
    <div>
      <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%">
        <tr> 
            <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                        <td  style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t46.gif" /></td>
                        <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif" /></td>
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
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                    <tr>
            <%--          <td colspan="2" style="height:40px; vertical-align:top; padding-top:1px; padding-bottom:5px; padding-left:2px; padding-right:2px;">
                          <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                            <tr>
                                <td class="tabletitle2" align="right" width="150">평가 조직</td>
                                <td class="tableContent" width="500" ondragenter="return false;">
                                    <asp:Literal ID="ltEstDeptName" runat="server"></asp:Literal>&nbsp;
                                    <asp:HiddenField ID="hdfEstDeptRefID" runat="server" />
                                </td>
                                <td class="tableContent" ondragenter="return false;" rowspan="3">
                                    <img alt="" id="iBtnSave" runat="server" src="../images/btn/b_002.gif" style="cursor:hand;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tabletitle2" align="right" width="150">조직 비젼</td>
                                <td class="tableContent" width="500">
                                    <asp:TextBox ID="txtSTGMapName" Width="100%" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableTitle" align="right" width="150">BSC Champion</td>
                                <td class="tableContent">
                                   <asp:TextBox ID="txtChampName" runat="server" readonly="True" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                          </table>--%>
                      <td style="width:300px;">
                          <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%" style="height:100%;">
                             <tr>
                                <td class="cssTblTitle">전략맵버젼</td>
                                <td class="cssTblContent">
                                    <asp:DropDownList ID="ddlMapVersion" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlMapVersion_SelectedIndexChanged" CssClass="box01"></asp:DropDownList>
                                </td>
                             </tr>
                           </table>
                      </td>
                      <td style="width:5px;">&nbsp;</td>
                      <td>
                          <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
                             <tr>
                                <td style="width:50%;">
                                    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%" style="height:100%;">
                                        <tr>
                                            <td class="cssTblTitleSingle">선택유형</td>
                                            <td class="cssTblContentSingle">
                                                <asp:Label ID="lblSelType" runat="server" Text="" >&nbsp;</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:5px; border-left-style:none;">&nbsp;</td>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                        <tr>
                                            <td class="cssTblTitleSingle">선택개체명</td>
                                            <td class="cssTblContentSingle">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="tableBorder" style="padding-left:3px;">
                                                            <asp:Label ID="lblSelTypeNM" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td align="right" style="width:108px;">
                                                            <img alt="" onclick="openFullStgMap();" style="cursor:hand;" src="../images/btn/b_135.gif" />&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                             </tr>
                           </table>
                      </td>
                    </tr>
                    <tr style="height:5px;"><td></td></tr>
                    <tr style="height:100%;">
                      <td style="vertical-align:top;">
                        <!--- Tree  --->	
                        <div id="leftLayer" class="tableBorder cssTblContent" style="DISPLAY:block; overflow: auto; position:static; 
                               width: 300px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                            <asp:TreeView BackColor="White" ID="trvStgMap" runat="server" OnSelectedNodeChanged="trvStgMap_SelectedNodeChanged" ImageSet="Faq" BorderStyle="None" EnableTheming="False" PopulateNodesFromClient="False" ShowLines="false" NodeIndent="15" >
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                        </div>
                        <sj:smartscroller id="SmartScroller1" runat="server" TargetObject="leftLayer"></sj:smartscroller>
                        <!--- /Tree  --->
                      </td>
                      <td></td>
                      <td style="vertical-align:top;">
                        <div id="rightLayer" class="tableBorder cssTblContent" style="DISPLAY:block; overflow: auto; position:static; 
                               width: 100%;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; background-color:White; ">
                           <asp:Panel ID="pnlDept" runat="server" Visible="false" Height="100%" Width="100%">
                               <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
                                 <tr>
                                   <td style="width:50%;">
                                    <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
                                        <tr>
                                            <td style="width:15px"><img src="../images/title/ma_t14.gif" alt="" /></td>
                                            <td><b>전략맵정보</b></td>
                                        </tr>
                                    </table>
                                   </td>
                                   <td style="width:5px">&nbsp;</td>
                                   <td>
                                    <table>
                                        <tr>
                                            <td style="width:15px"><img src="../images/title/ma_t14.gif" alt="" /></td>
                                            <td><b>전략맵 버젼정보</b></td>
                                        </tr>
                                    </table>
                                   </td>
                                 </tr>
                                 <tr style="height:100%;">
                                   <td style="width:50%;" valign="top">
                                     <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" style="width:100%; height:100%;">
                                       <tr>
                                        <td class="cssTblTitleSingle">평가기간</td>
                                        <td class="cssTblContentSingle">
                                            <asp:TextBox ID="txtTermDesc" runat="server" Text="" Width="100%" Enabled="false" BackColor="whitesmoke"></asp:TextBox>
                                        </td>
                                       </tr>
                                       <tr>
                                        <td class="cssTblTitleSingle">평가부서명</td>
                                        <td class="cssTblContentSingle">
                                            <asp:TextBox ID="txtEstDeptName" runat="server" Text="" Width="100%" Enabled="false" BackColor="whitesmoke"></asp:TextBox>
                                        </td>
                                       </tr>
                                       <tr>
                                        <td class="cssTblTitleSingle"><%= GetText("LBL_00001", "챔피언")%></td>
                                        <td class="cssTblContentSingle">
                                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" style="width:100%; height:100%;">
                                                <tr>
                                                    <td>
                                                        <asp:HiddenField ID="hdfBSCChampionID" runat="server" Value="" />
                                                        <asp:TextBox ID="txtBSCChampion" runat="server" Text="" Width="100%" Enabled="false" BackColor="whitesmoke"></asp:TextBox>
                                                    </td>
                                                    <td style="width:20px;"><img alt="" src="../images/btn/b_008.gif" style="cursor:hand; vertical-align:baseline;" onclick="openDeptEmp('hdfBSCChampionID','txtBSCChampion')" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                       </tr>
                                       <tr style="height:50%;">
                                        <td class="cssTblTitleSingle">조직비젼</td>
                                        <td class="cssTblContentSingle">
                                            <asp:TextBox ID="txtDeptVision" runat="server" TextMode="MultiLine" Text="" Height="100%" Width="100%"></asp:TextBox>
                                        </td>
                                       </tr>
                                       <tr>
                                        <td class="cssTblTitleSingle">전략맵버젼</td>
                                        <td class="cssTblContentSingle">
                                            <asp:TextBox ID="txtMapVersionID" runat="server" Text="" Width="15%" BackColor="whitesmoke" Enabled="false" 
                                            /><asp:TextBox ID="txtMapVersionName" runat="server" Text="" Width="83%"></asp:TextBox>
                                        </td>
                                       </tr>
                                       <tr style="height:50%;">
                                        <td class="cssTblTitleSingle">전략맵정보</td>
                                        <td class="cssTblContentSingle">
                                            <asp:TextBox ID="txtMapDesc" runat="server" TextMode="MultiLine" Height="100%" Text="" Width="100%"></asp:TextBox>
                                        </td>
                                       </tr>
                                     </table>
                                   </td>
                                   <td style="width:5px;">&nbsp;</td>
                                   <td>
                                      <ig:UltraWebGrid id="ugrdTerm" runat="server" height="100%" width="100%" ImageDirectory="" OnInitializeRow="ugrdTerm_InitializeRow" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="평가년월" Key="YMD" DataType="System.String" Hidden="true">
                                                            <Header Caption="평가년월"></Header>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="평가년월" Key="YMD_DESC" Width="60px">
                                                            <Header Caption="평가년월"></Header>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:TemplatedColumn BaseColumnName="APPLY_YN" Key="APPLY_YN" Width="60px">
                                                            <Header Caption="적용여부"></Header>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <HeaderTemplate>
                                                              <asp:Label ID="lblTerm" runat="server" Text="적용여부"></asp:Label>
                                                              <%--<img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdTerm')" />--%>
                                                            </HeaderTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                            <CellTemplate>
                                                                <asp:CheckBox ID="chkCheckTerm" runat="server" />
                                                            </CellTemplate>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CLOSE_YN" DataType="System.String" HeaderText="마감여부"
                                                            Hidden="false"  Key="CLOSE_YN" Width="35px">
                                                            <Header Caption="마감여부">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MAP_VERSION_NAME" DataType="System.String" HeaderText="MAP_VERSION_NAME"
                                                            Hidden="false"  Key="MAP_VERSION_NAME" Width="145px">
                                                            <Header Caption="적용전략맵">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                            Key="ESTTERM_REF_ID">
                                                            <Header Caption="ESTTERM_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                            Key="ESTTERM_REF_ID">
                                                            <Header Caption="ESTTERM_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" Version="4.00" AutoGenerateColumns="false" 
                                             HeaderClickActionDefault="NotSet" Name="ugrdTerm" BorderCollapseDefault="Separate" RowSelectorsDefault="No" ScrollBarView="Both"
                                             RowHeightDefault="25px" SelectTypeRowDefault="Single" JavaScriptFileName="" JavaScriptFileNameCommon="" FixedHeaderIndicatorDefault="Button" TableLayout="Fixed" 
                                             StationaryMargins="Header" >
                                                <GroupByBox Hidden="True">
                                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                </GroupByBox>
                                                <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False">
                                                    <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" Cursor="hand"
                                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                    Width="100%">
                                                </FrameStyle>
                                                <Pager>
                                                <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                </Style>
                                                </Pager>
                                                <AddNewBox>
                                                <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                 </Style>
                                                </AddNewBox>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>
                                                <ActivationObject BorderColor="" BorderWidth="">
                                                </ActivationObject>
                                                <FilterOptionsDefault FilterUIType="HeaderIcons">
                                                </FilterOptionsDefault>
                                                <Images ImageDirectory="">
                                                </Images>--%>
                                                
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                                
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                   </td>
                                 </tr>
                                 <tr class="cssPopBtnLine">
                                   <td colspan="3" align="right">
                                      <asp:ImageButton ID="iBtnInsertMapInfo" runat="server" ImageUrl="../images/btn/b_001.gif" OnClick="iBtnInsertMapInfo_Click" />
                                      <asp:ImageButton ID="iBtnInitMapInfo"   runat="server" ImageUrl="../images/btn/b_093.gif" OnClick="iBtnInitMapInfo_Click" />
                                      <asp:ImageButton ID="iBtnUpdateMapInfo" runat="server" ImageUrl="../images/btn/b_002.gif" OnClick="iBtnUpdateMapInfo_Click" />
                                      <asp:ImageButton ID="iBtnDeleteMapInfo" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="iBtnDeleteMapInfo_Click" />
                                   </td>
                                 </tr>
                               </table>
                           </asp:Panel>
                           <asp:Panel ID="pnlSTG" runat="server" Visible="false" Height="100%" Width="100%">
                               <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                                 <tr>
                                   <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label5" runat="server" style="font-weight:bold" text="관점별 전략리스트" />
                                                </td>
                                            </tr>
                                        </table>
                                   </td>
                                 </tr>
                                 <tr style="height:50%;">
                                   <td>
                                            <ig:UltraWebGrid ID="ugrdStgPerView" runat="server"  Width="100%" Height="180px">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:TemplatedColumn HeaderText="선택" Key="selchk" Width="30px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle VerticalAlign="Middle">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                                </CellTemplate>
                                                                <Header Caption="선택">
                                                                </Header>
                                                            </ig:TemplatedColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                Key="ESTTERM_REF_ID" Width="50px" Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="전략 ID">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" FooterText="" HeaderText="EST_DEPT_REF_ID"
                                                                Key="EST_DEPT_REF_ID" Width="50px" Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="EST_DEPT_REF_ID">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="MAP_VERSION_ID" FooterText="" HeaderText="MAP_VERSION_ID"
                                                                Key="MAP_VERSION_ID" Width="50px" Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="MAP_VERSION_ID">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" FooterText="" HeaderText="VIEW_REF_ID"
                                                                Key="VIEW_REF_ID" Width="50px" Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="VIEW_REF_ID">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                Key="STG_REF_ID" Width="80px" AllowUpdate="No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="전략 ID">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:TemplatedColumn BaseColumnName="STG_NAME" FooterText="" HeaderText="전략명" Key="STG_NAME"
                                                                Width="520px" AllowUpdate="No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="전략명">
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <ValueList DisplayStyle="NotSet">
                                                                </ValueList>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Footer>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="SORT_ORDER" FooterText="" HeaderText="순서" Key="SORT_ORDER"
                                                                Width="30px" AllowUpdate="Yes">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="순서">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <ValueList DisplayStyle="NotSet">
                                                                </ValueList>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:TemplatedColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free"
                                                AllowSortingDefault="No" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                Name="ugrdStgPerView" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="Flat" AllowUpdateDefault="Yes">
                                                <GroupByBox Hidden="True">
                                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                </GroupByBox>
                                                <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                    ForeColor="White" HorizontalAlign="Left">
                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="180px">
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
                                                <ActivationObject BorderColor="" BorderWidth="">
                                                </ActivationObject>--%>
                                                
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                   </td>
                                 </tr>
                                 <tr style="height:30px;">
                                   <td style="vertical-align:middle;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label6" runat="server" style="font-weight:bold" text="대상 전략리스트" />
                                                </td>
                                                <td align="right">
                                                  <asp:ImageButton ID="ImgBtnStgAdd" runat="server" ImageUrl="../images/btn/btn_add_03.gif" OnClick="ImgBtnStgAdd_Click" />&nbsp;
                                                  <asp:ImageButton ID="ImgBtnStgDel" runat="server" ImageUrl="../images/btn/btn_add_04.gif" OnClientClick="return AlertDeleteStg();" OnClick="ImgBtnStgDel_Click" />
                                               </td>
                                            </tr>
                                        </table>
                                   </td>
                                 </tr>
                                 <tr style="height:50%;">
                                   <td>
                                        <ig:UltraWebGrid ID="ugrdStgAll" runat="server"  Width="100%" Height="250px">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:TemplatedColumn HeaderText="선택" Width="30px" Key="selchk">
                                                            <CellTemplate>
                                                                <asp:CheckBox ID="cBox" runat="server" />
                                                            </CellTemplate>
                                                            <Header Caption="선택">
                                                            </Header>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="STG_REF_ID" FooterText="" HeaderText="전략 ID"
                                                            Key="STG_REF_ID" Width="80px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="전략 ID">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:TemplatedColumn BaseColumnName="STG_NAME" FooterText="" HeaderText="전략명" Key="STG_NAME"
                                                            Width="550px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="전략명">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <ValueList DisplayStyle="NotSet">
                                                            </ValueList>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Footer>
                                                        </ig:TemplatedColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                            AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                            CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                            Name="ugrdStgAll" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                            StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="OutlookGroupBy">
                                                <GroupByBox Hidden="True">
                                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                </GroupByBox>
                                                <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                ForeColor="White" HorizontalAlign="Left">
                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="250px">
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
                                                <ActivationObject BorderColor="" BorderWidth="">
                                                </ActivationObject>--%>
                                                
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                   </td>
                                 </tr>
                                 <tr style="height:25px;">
                                   <td>
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                         <tr style="height:25px;">
                                           <td style="width:60%;" align="left">
                                              ID:<asp:TextBox ID="txtFindStgID" Text="" runat="server" Width="50px" />
                                              Name:<asp:TextBox ID="txtFindStgNM" Text="" runat="server" Width="120px" />                                  
                                           </td>
                                           <td style="width:40%;" align="right">
                                              <asp:ImageButton ID="iBtnFindStg" runat="server" ImageUrl="../images/btn/b_034.gif" OnClick="iBtnFindStg_Click" />
                                           </td>
                                         </tr>
                                     </table>                         
                                   </td>
                                 </tr>
                               </table>
                           </asp:Panel>
                           <asp:Panel ID="pnlKPI" runat="server" Visible="false" Height="100%" Width="100%" >
                            <table border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                              <tr>
                                <td>
                                  <ig:UltraWebTab runat="server" ID="ugwtKpiTab" Height="100%" ThreeDEffect="False" Width="100%" AutoPostBack="True" OnTabClick="ugwtKpiTab_TabClick" >
                                      <Tabs>
                                          <ig:Tab Text="전략별 KPI 설정" Key="1">
                                            <Style Width="200px" Height="25px" />
                                              <ContentTemplate>
                                               <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                                                 <tr style="height:25px;">
                                                   <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                                            <tr>
                                                                <td style="width:15px;">
                                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label id="Label2" runat="server" style="font-weight:bold" text="전략별 KPI리스트" />
                                                                </td>
                                                                <td style="text-align:right; vertical-align:middle;">
                                                                    <asp:Label ID="lblWeightTitle" Text="총가중치 합 : " Font-Bold="true" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblWeightTotal" Text="0" Font-Bold="true" runat="server"></asp:Label>
                                                                    <asp:ImageButton ID="iBtnUpdateKpi" runat="server" ImageUrl="../images/btn/b_007.gif" OnClick="iBtnUpdateKpi_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                   </td>
                                                 </tr>
                                                 <tr style="height:50%;">
                                                   <td>
                                                            <ig:UltraWebGrid ID="ugrdKPIPerStg" runat="server"  Width="100%" Height="150px" OnInitializeRow="ugrdKPIPerStg_InitializeRow">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                                                            <ig:TemplatedColumn HeaderText="선택" Key="selchk" Width="30px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle VerticalAlign="Middle">
                                                                                </CellStyle>
                                                                                <CellTemplate>
                                                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                                                </CellTemplate>
                                                                                <Header Caption="선택">
                                                                                </Header>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                                Key="ESTTERM_REF_ID" Width="50px" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="전략 ID">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" FooterText="" HeaderText="EST_DEPT_REF_ID"
                                                                                Key="EST_DEPT_REF_ID" Width="50px" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="EST_DEPT_REF_ID">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="MAP_VERSION_ID" FooterText="" HeaderText="MAP_VERSION_ID"
                                                                                Key="MAP_VERSION_ID" Width="50px" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="MAP_VERSION_ID">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                                Key="STG_REF_ID" Width="50px" AllowUpdate="No" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="전략 ID">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="STG_NAME" FooterText="" HeaderText="전략명" Key="STG_NAME"
                                                                                Width="180px" AllowUpdate="No" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="전략명">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left">
                                                                                </CellStyle>
                                                                                <ValueList DisplayStyle="NotSet">
                                                                                </ValueList>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" FooterText="" HeaderText="KPI Code"
                                                                                Key="KPI_CODE" Width="70px" AllowUpdate="No">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="KPI Code">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="KPI_NAME" FooterText="" HeaderText="KPI 명" Key="KPI_NAME"
                                                                                Width="215px" AllowUpdate="No">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="KPI 명">
                                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke">
                                                                                </CellStyle>
                                                                                <ValueList DisplayStyle="NotSet">
                                                                                </ValueList>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                                </Footer>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" FooterText="" HeaderText="KPI 명" Key="OP_DEPT_NAME"
                                                                                Width="100px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="운영부서">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke"></CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" FooterText="" HeaderText="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME"
                                                                                Width="70px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="챔피언">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke"></CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="WEIGHT" FooterText="" HeaderText="가중치" Key="WEIGHT"
                                                                                Width="50px" AllowUpdate="Yes" Format="#,###.####" DataType="System.Double">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="가중치">
                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Right">
                                                                                </CellStyle>
                                                                                <ValueList DisplayStyle="NotSet">
                                                                                </ValueList>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                </Footer>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="SORT_ORDER" FooterText="" HeaderText="순서" Key="SORT_ORDER"
                                                                                Width="50px" AllowUpdate="Yes" DataType="System.Int">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="순서">
                                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <ValueList DisplayStyle="NotSet">
                                                                                </ValueList>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                                </Footer>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="MAP_KPI_TYPE" HeaderText="유형" Key="MAP_KPI_TYPE"
                                                                                Width="70px" AllowUpdate="Yes">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header>
                                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <CellTemplate>
                                                                                    <asp:DropDownList ID="ddlMAP_KPI_TYPE" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                                                                                </CellTemplate>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                                </Footer>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" FooterText="" HeaderText="KPI_REF_ID"
                                                                                Key="KPI_REF_ID" Width="80px" AllowUpdate="No" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="KPI_REF_ID">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                    </Columns>
                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                    </RowTemplateStyle>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                            <DisplayLayout AllowColSizingDefault="Free"
                                                                AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                                Name="ugrdKPIPerStg" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                                StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="OutlookGroupBy" AllowUpdateDefault="Yes">
                                                                <GroupByBox Hidden="True">
                                                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                </GroupByBox>
                                                                <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                </GroupByRowStyleDefault>
                                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                </FooterStyleDefault>
                                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                    <Padding Left="3px" />
                                                                </RowStyleDefault>
                                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                </SelectedRowStyleDefault>
                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                    ForeColor="White" HorizontalAlign="Left">
                                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                </HeaderStyleDefault>
                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                </EditCellStyleDefault>
                                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="150px">
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
                                                                <ActivationObject BorderColor="" BorderWidth="">
                                                                </ActivationObject>--%>
                                                                
                                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                                            </DisplayLayout>
                                                        </ig:UltraWebGrid>
                                                        <asp:DropDownList ID="ddlMAP_KPI_TYPE_H" runat="server" Width="100%" CssClass="box01" Visible="false"></asp:DropDownList>
                                                   </td>
                                                 </tr>
                                                 <tr class="cssPopBtnLine">
                                                   <td style="vertical-align:middle;">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                            <tr>
                                                                <td style="width:15px;">
                                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label id="Label3" runat="server" style="font-weight:bold" text="대상 KPI 리스트" />
                                                                </td>
                                                                <td align="right">
                                                                  <asp:ImageButton ID="iBtnAddKpi" runat="server" ImageUrl="../images/btn/btn_add_03.gif" OnClick="iBtnAddKpi_Click" />
                                                                  <asp:ImageButton ID="iBtnDelKpi" runat="server" ImageUrl="../images/btn/btn_add_04.gif" OnClick="iBtnDelKpi_Click" />
                                                               </td>
                                                            </tr>
                                                        </table>
                                                   </td>
                                                 </tr>
                                                 <tr style="height:50%;">
                                                   <td>
                                                        <ig:UltraWebGrid ID="ugrdKPIAll" runat="server"  Width="100%" Height="250px">
                                                            <Bands>
                                                                <ig:UltraGridBand>
                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                    </AddNewRow>
                                                                    <Columns>
                                                                        <ig:TemplatedColumn HeaderText="선택" Width="30px" Key="selchk">
                                                                            <CellTemplate>
                                                                                <asp:CheckBox ID="cBox" runat="server" />
                                                                            </CellTemplate>
                                                                            <Header Caption="선택">
                                                                            </Header>
                                                                        </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                                Key="ESTTERM_REF_ID" Width="50px" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="전략 ID">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" FooterText="" HeaderText="KPI Code"
                                                                            Key="KPI_CODE" Width="80px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI Code">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" FooterText="" HeaderText="KPI 명" Key="KPI_NAME"
                                                                            Width="350px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI 명">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" FooterText="" HeaderText="KPI 명" Key="OP_DEPT_NAME"
                                                                            Width="110px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="운영부서">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" FooterText="" HeaderText="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME"
                                                                            Width="80px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="챔피언">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" FooterText="" HeaderText="KPI_REF_ID"
                                                                            Key="KPI_REF_ID" Width="80px" AllowUpdate="No" Hidden="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI_REF_ID">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                    </Columns>
                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                    </RowTemplateStyle>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="No"
                                                                            AllowSortingDefault="No" AutoGenerateColumns="False" BorderCollapseDefault="NotSet"
                                                                            CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="NotSet"
                                                                            Name="ugrdKPIAll" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="None"
                                                                            StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="flat">
                                                                <GroupByBox Hidden="True">
                                                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                                </GroupByBox>
                                                                <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                </GroupByRowStyleDefault>
                                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                </FooterStyleDefault>
                                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                    <Padding Left="3px" />
                                                                </RowStyleDefault>
                                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                </SelectedRowStyleDefault>
                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                                ForeColor="White" HorizontalAlign="Left">
                                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                </HeaderStyleDefault>
                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
                                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="250px">
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
                                                                <ActivationObject BorderColor="" BorderWidth="">
                                                                </ActivationObject>--%>
                                                                
                                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                                            </DisplayLayout>
                                                        </ig:UltraWebGrid>
                                                   </td>
                                                 </tr>
                                                 <tr style="height:25px;">
                                                   <td>
                                                     <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                                       <tr>
                                                         <td style="width:40px;">ID:</td>
                                                         <td>
                                                             <asp:TextBox ID="txtFindKpiID" Text="" runat="server" Width="50px" />   
                                                         </td>
                                                         <td>Name:</td>
                                                         <td>
                                                             <asp:TextBox ID="txtFindKpiNM" Text="" runat="server" Width="120px" />
                                                         </td>
                                                         <td rowspan="2" align="right">
                                                           <asp:ImageButton ID="iBtnFindKpi" runat="server" ImageUrl="../images/btn/b_034.gif" OnClick="iBtnFindKpi_Click" />
                                                         </td>
                                                       </tr>
                                                       <tr>
                                                         <td><%=GetText("LBL_00001", "챔피언") %></td>
                                                         <td>
                                                             <asp:TextBox ID="txtChampion" Text="" runat="server" Width="50px" />
                                                         </td>
                                                           <td>운영부서</td>
                                                           <td>
                                                               <asp:TextBox ID="txtMgmDept" Text="" runat="server" Width="120px" />
                                                           </td>
                                                         </tr>
                                                     </table>
                                                   </td>
                                                 </tr>
                                               </table>                                   
                                              </ContentTemplate>
                                          </ig:Tab>
                                          <ig:Tab Text="상위전략 설정" Key="2">
                                            <Style Width="200px" Height="25px"/>
                                              <ContentTemplate>
                                               <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                                                 <tr style="height:25px;">
                                                   <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                            <tr>
                                                                <td style="width:15px;">
                                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="상위전략 리스트" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                   </td>
                                                 </tr>
                                                 <tr style="height:50%;">
                                                   <td>
                                                            <ig:UltraWebGrid ID="ugrdUpStgList" runat="server"  Width="100%" Height="150px">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                                                            <ig:TemplatedColumn HeaderText="선택" Key="selchk" Width="30px" BaseColumnName="selchk">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle VerticalAlign="Middle">
                                                                                </CellStyle>
                                                                                <CellTemplate>
                                                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                                                </CellTemplate>
                                                                                <Header Caption="선택">
                                                                                </Header>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                                Key="ESTTERM_REF_ID" Width="50px" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="전략 ID">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" FooterText="" HeaderText="EST_DEPT_REF_ID"
                                                                                Key="EST_DEPT_REF_ID" Width="50px" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="EST_DEPT_REF_ID">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="MAP_VERSION_ID" FooterText="" HeaderText="MAP_VERSION_ID"
                                                                                Key="MAP_VERSION_ID" Width="50px" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="MAP_VERSION_ID">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" FooterText="" HeaderText="VIEW_REF_ID"
                                                                                Key="VIEW_REF_ID" Width="50px" Hidden="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="VIEW_REF_ID">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="VIEW_NAME" FooterText="" HeaderText="관점"
                                                                                Key="VIEW_NAME" Width="100px" AllowUpdate="No">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="관점">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                                Key="STG_REF_ID" Width="50px" AllowUpdate="No" Hidden="true">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="전략 ID">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="UP_STG_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                                Key="UP_STG_REF_ID" Width="80px" AllowUpdate="No">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="상위전략 ID">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="UP_STG_NAME" FooterText="" HeaderText="전략명" Key="UP_STG_NAME"
                                                                                Width="450px" AllowUpdate="No">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="상위전략명">
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
                                                            <DisplayLayout AllowColSizingDefault="Free"
                                                                AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                                Name="ugrdUpStgList" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                                StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="OutlookGroupBy" AllowUpdateDefault="Yes">
                                                                <GroupByBox Hidden="True">
                                                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                                </GroupByBox>
                                                                <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                </GroupByRowStyleDefault>
                                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                </FooterStyleDefault>
                                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                    <Padding Left="3px" />
                                                                </RowStyleDefault>
                                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                </SelectedRowStyleDefault>
                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                    ForeColor="White" HorizontalAlign="Left">
                                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                </HeaderStyleDefault>
                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                </EditCellStyleDefault>
                                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="150px">
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
                                                                <ActivationObject BorderColor="" BorderWidth="">
                                                                </ActivationObject>--%>
                                                                
                                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                                            </DisplayLayout>
                                                        </ig:UltraWebGrid>
                                                   </td>
                                                 </tr>
                                                 <tr class="cssPopBtnLine">
                                                   <td style="vertical-align:middle;">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                            <tr>
                                                                <td style="width:15px;">
                                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label id="Label1" runat="server" style="font-weight:bold" text="대상 상위 전략리스트" />
                                                                </td>
                                                                <td align="right">
                                                                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/btn/btn_add_03.gif" OnClick="iBtnAddUpStg_Click" />&nbsp;&nbsp;
                                                                  <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/btn/btn_add_04.gif" OnClick="iBtnDelUpStg_Click" />
                                                               </td>
                                                            </tr>
                                                        </table>
                                                   </td>
                                                 </tr>
                                                 <tr style="height:50%;">
                                                   <td>
                                                        <ig:UltraWebGrid ID="ugrdStgPerDept" runat="server"  Width="100%" Height="250px">
                                                            <Bands>
                                                                <ig:UltraGridBand>
                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                    </AddNewRow>
                                                                    <Columns>
                                                                        <ig:TemplatedColumn HeaderText="선택" Width="30px" Key="selchk">
                                                                            <CellTemplate>
                                                                                <asp:CheckBox ID="cBox" runat="server" />
                                                                            </CellTemplate>
                                                                            <Header Caption="선택">
                                                                            </Header>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                            Key="ESTTERM_REF_ID" Width="50px" Hidden="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="전략 ID">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" FooterText="" HeaderText="EST_DEPT_REF_ID"
                                                                            Key="EST_DEPT_REF_ID" Width="50px" Hidden="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="EST_DEPT_REF_ID">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="MAP_VERSION_ID" FooterText="" HeaderText="MAP_VERSION_ID"
                                                                            Key="MAP_VERSION_ID" Width="50px" Hidden="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="MAP_VERSION_ID">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" FooterText="" HeaderText="VIEW_REF_ID"
                                                                            Key="VIEW_REF_ID" Width="50px" Hidden="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="VIEW_REF_ID">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="VIEW_NAME" FooterText="" HeaderText="관점"
                                                                            Key="VIEW_NAME" Width="100px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="관점">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="STG_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                            Key="STG_REF_ID" Width="100px" Hidden="true">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="전략 ID">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="UP_STG_REF_ID" FooterText="" HeaderText="전략 ID"
                                                                            Key="UP_STG_REF_ID" Width="80px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="상위전략 ID">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="STG_NAME" FooterText="" HeaderText="전략명" Key="STG_NAME"
                                                                            Width="445px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="전략명">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Footer>
                                                                        </ig:TemplatedColumn>
                                                                    </Columns>
                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                    </RowTemplateStyle>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                                            AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                                            CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                                            Name="ugrdStgPerDept" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                                            StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="OutlookGroupBy">
                                                                <GroupByBox Hidden="True">
                                                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                                </GroupByBox>
                                                                <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                </GroupByRowStyleDefault>
                                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                </FooterStyleDefault>
                                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                    <Padding Left="3px" />
                                                                </RowStyleDefault>
                                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                </SelectedRowStyleDefault>
                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                                ForeColor="White" HorizontalAlign="Left">
                                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                </HeaderStyleDefault>
                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
                                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="250px">
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
                                                                <ActivationObject BorderColor="" BorderWidth="">
                                                                </ActivationObject>--%>
                                                                
                                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                                            </DisplayLayout>
                                                        </ig:UltraWebGrid>
                                                   </td>
                                                 </tr>
                                               </table>
                                              </ContentTemplate>
                                          </ig:Tab>
                                      </Tabs>
                                      <DefaultTabStyle BackColor="White" CssClass="cssTabStyleOff"></DefaultTabStyle>
                                      <SelectedTabStyle CssClass="cssTabStyleOn" />
                                     <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_light1.gif" SelectedImage="../images/tab/ig_tab_light2.gif" />
                                  </ig:UltraWebTab>
                                </td>
                              </tr>
                            </table>
                           </asp:Panel>
                           <asp:Panel ID="pnlKPIDetail" runat="server" HorizontalAlign="Left" >
                               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                 <tr style="height:25px;">
                                   <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label4" runat="server" style="font-weight:bold" text="하위 KPI리스트" />
                                                </td>
                                            </tr>
                                        </table>
                                   </td>
                                 </tr>
                                 <tr style="height:450px;">
                                   <td>
                                        <ig:UltraWebGrid ID="ugrdChildKpiList" runat="server" Width="100%" Height="100%" >
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:TemplatedColumn Key="UP_KPI_TR_ROLLUP_YN" Width="35px">
                                                                <Header Fixed="true" Caption="목표롤업"></Header>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  Wrap="true" />
                                                                <CellStyle HorizontalAlign="center"  BackColor="whitesmoke"></CellStyle>
                                                                <CellTemplate>
                                                                    <asp:checkbox id="cBox" runat="server" Enabled="false" />
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn Key="UP_KPI_PO_ROLLUP_YN" Width="35px">
                                                                <Header Fixed="true" Caption="점수롤업"></Header>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                                <CellStyle HorizontalAlign="center"  BackColor="whitesmoke"></CellStyle>
                                                                <CellTemplate>
                                                                    <asp:checkbox id="cBox" runat="server" Enabled="false" />
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="40px" AllowUpdate="No">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="KPI 코드" Fixed="true">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="210px" AllowUpdate="No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="KPI 명">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="120px" AllowUpdate="No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="운영조직">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="50px" AllowUpdate="No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="KPI담당자">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px" AllowUpdate="No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="단위">
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID=""
                                                                FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px" AllowUpdate="No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="실적방식">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="UP_KPI_WEIGHT" EditorControlID="" FooterText="" AllowUpdate="No"
                                                                Format="" HeaderText="UP_KPI_WEIGHT" Key="UP_KPI_WEIGHT" DataType="System.Double" NullText="0" Width="60px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="가중치">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Right" BackColor="whitesmoke" />
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="ESTTERM_REF_ID" Fixed="true">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID="" NullText="0"
                                                                FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="KPI_REF_ID" Fixed="true">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                 <DisplayLayout CellPaddingDefault="0" AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="No"
                                                        AllowSortingDefault="No" BorderCollapseDefault="Separate" UseFixedHeaders="true" StationaryMargins="Header" 
                                                        HeaderClickActionDefault="NotSet" Name="ugrdChileKpi" RowHeightDefault="20px" HeaderStyleDefault-Height="35px"
                                                        RowSelectorsDefault="No" SelectTypeRowDefault="None" Version="4.00" ViewType="Flat" CellClickActionDefault="CellSelect" TableLayout="Fixed" AutoGenerateColumns="False">
                                                        <GroupByBox>
                                                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                        </GroupByBox>
                                                        <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
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
                                                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                                                        </SelectedRowStyleDefault>--%>
                                                        
                                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                        <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdKpiList_DblClickHandler" />
                                                    </DisplayLayout>
                                              </ig:UltraWebGrid>
                                   </td>
                                 </tr>
                               </table>
                           </asp:Panel>
                        </div>
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
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:HiddenField ID="hdfImagePath" runat="server" Value="" />
            </td>
        </tr>
      </table>
    </div>
   <asp:Literal ID="ltrScript" runat="server" ></asp:Literal>
  </form>
</body>
</html>

