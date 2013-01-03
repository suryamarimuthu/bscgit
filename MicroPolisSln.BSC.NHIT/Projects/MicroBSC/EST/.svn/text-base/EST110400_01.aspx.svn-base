<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110400_01.aspx.cs" Inherits="EST110400_01" %>
<html>

    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
        <script type="text/javascript">
            function bindGroup() {
                var ugrd = igtbl_getGridById('ugrdGroup');
                var sRow = igtbl_getActiveRow(ugrd.Id);
                document.getElementById('hdfBIAS_GRP_ID').value = sRow.getCellFromKey("BIAS_GRP_ID").getValue();
                document.getElementById('txtBIAS_GRP_CD').value = sRow.getCellFromKey("BIAS_GRP_CD").getValue();
                document.getElementById('txtBIAS_GRP_NM').value = sRow.getCellFromKey("BIAS_GRP_NM").getValue();
                document.getElementById('txtBIAS_GRP_DESC').value = sRow.getCellFromKey("BIAS_GRP_DESC").getValue();
                document.getElementById('chkUSE_YN').checked = (sRow.getCellFromKey("USE_YN").getValue() == "Y" ? true : false);
                document.getElementById('txtBIAS_GRP_CD').readOnly = "readonly";
            }
            
            function initControl() {
                document.getElementById('hdfBIAS_GRP_ID').value = "0";
                document.getElementById('txtBIAS_GRP_CD').value = "";
                document.getElementById('txtBIAS_GRP_NM').value = "";
                document.getElementById('txtBIAS_GRP_DESC').value = "";
                document.getElementById('chkUSE_YN').checked = true;
                document.getElementById('txtBIAS_GRP_CD').readOnly = "";
                return false;
            }

            function confirmMSG(objID) {
                if (objID == "1") {
                    if (document.getElementById('txtBIAS_GRP_CD').value == null || document.getElementById('txtBIAS_GRP_CD').value.replace(/^\s*|\s*$/g, '') == '') {
                        alert("그룹코드를 입력하세요.");
                        return false;
                    }
                    if (document.getElementById('txtBIAS_GRP_NM').value == null || document.getElementById('txtBIAS_GRP_NM').value.replace(/^\s*|\s*$/g, '') == '') {
                        alert("그룹명칭을 입력하세요.");
                        return false;
                    }
                    if (document.getElementById('hdfBIAS_GRP_ID').value != "0")
                        return confirm("수정하시겠습니까?");
                    else
                        return confirm("저장하시겠습니까?");
                }
                else {
                    if (document.getElementById('hdfBIAS_GRP_ID').value == "0") {
                        alert("삭제할 그룹을 선택하세요.");
                        return false;
                    }
                    return confirm("삭제하시겠습니까?");
                }
            }
            function ttt() {
                if (document.getElementById('hdfChangeYN').value != "0")
                    opener.__doPostBack('<%= ICCB1 %>', '');
            }
        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onunload="ttt()">
    <form id="form1" runat="server">
        <!--- MAIN START --->
        <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="1">
            <tr>
                <td style="height: 40px;" valign="top">
				    <!-- 타이틀시작 -->
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                            <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top"><img src="../images/title/popup_t41.gif" ></td>
                                        <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                    </tr>
                                </table>
                                <!-- 타이틀끝 -->
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="cssPopContent">
                <td valign="top" style="height: 100%;">
                    <ig:UltraWebGrid ID="ugrdGroup" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdGroup_InitializeRow">
                        <Bands>
                            <ig:UltraGridBand>
                                <Columns>
                                    <ig:UltraGridColumn BaseColumnName="BIAS_GRP_CD" Key="BIAS_GRP_CD" Width="10%" HeaderText="코드">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="BIAS_GRP_NM" Key="BIAS_GRP_NM" Width="30%" HeaderText="명칭">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="BIAS_GRP_DESC" Key="BIAS_GRP_DESC" Width="50%" HeaderText="설명">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="USE_YN_I" Key="USE_YN_I" Width="10%" HeaderText="사용">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </ig:UltraGridColumn>                                            
                                    <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="true"></ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="BIAS_GRP_ID" Key="BIAS_GRP_ID" Hidden="true"></ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="USE_YN" Key="USE_YN" Hidden="true"></ig:UltraGridColumn>
                                </Columns>
                            </ig:UltraGridBand>
                        </Bands>
                        <DisplayLayout CellPaddingDefault="2" 
                                        AllowColSizingDefault="Free" 
                                        AllowColumnMovingDefault="None" 
                                        AllowDeleteDefault="No"
                                        AllowSortingDefault="Yes" 
                                        BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="SortMulti" 
                                        Name="ugrdGroup" 
                                        RowHeightDefault="23px" 
                                        HeaderStyleDefault-Height="25px"
                                        RowSelectorsDefault="No" 
                                        SelectTypeRowDefault="Extended" 
                                        Version="4.00" 
                                        CellClickActionDefault="RowSelect" 
                                        TableLayout="Fixed" 
                                        StationaryMargins="Header" 
                                        OptimizeCSSClassNamesOutput="False"
                                        AutoGenerateColumns="False">
                            <%--<GroupByBox>
                                <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
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
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                            </SelectedRowStyleDefault>--%>
                            <ClientSideEvents CellClickHandler="bindGroup"/>
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
            <tr class="cssPopContent">
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                       
                        <tr>
                            <td class="cssTblTitle">
                                그룹코드
                            </td>
                            <td class="cssTblContent">
                                <asp:HiddenField ID="hdfBIAS_GRP_ID" runat="server" Value="0" />
                                <asp:TextBox ID="txtBIAS_GRP_CD" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle">
                                그룹명칭
                            </td>
                            <td class="cssTblContent">
                                <asp:TextBox ID="txtBIAS_GRP_NM" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle">
                                그룹설명
                            </td>
                            <td class="cssTblContent">
                                <asp:TextBox ID="txtBIAS_GRP_DESC" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle">
                                사용여부
                            </td>
                            <td class="cssTblContent">
                                <asp:CheckBox ID="chkUSE_YN" runat="server" Checked="true" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="cssPopContent">
                <td align="right" style="height: 25px;">
                    <asp:ImageButton ID="iBtnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClientClick="return initControl();" />
                    <asp:ImageButton ID="iBtnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClientClick="return confirmMSG('1');" OnClick="iBtnSave_Click" />
                    <asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClientClick="return confirmMSG('2');" OnClick="iBtnDelete_Click" />
                    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hdfChangeYN" runat="server" Value="0" />
                </td>
            </tr>
        </table>
        <script>gfWinFocus();</script>
        <!--- MAIN END --->
    </form>
</body>
</html>
