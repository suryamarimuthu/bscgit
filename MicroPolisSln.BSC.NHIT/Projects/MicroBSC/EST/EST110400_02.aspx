<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110400_02.aspx.cs" Inherits="EST110400_02" %>

<%@ Register Src="USER_CTRL/EST_GRID.ascx" TagName="EST_GRID" TagPrefix="uc1" %>

<html>

    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
        <script type="text/javascript">
            function checkSave() {
                var selected = '<%= this.ISEQ %>';
                if (selected == '0') {
                    alert("저장할 컬럼을 선택하세요.");
                    return false;
                }

                return confirm("저장하시겠습니까?");                  
                
            }
        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        
        <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="2">
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
                <td valign="top" style="height: 100%; width: 100%; padding-top: 3px; padding-right: 3px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                        <tr>
                            <td style="width: 60%; height: 100%;">
                                <ig:UltraWebGrid ID="ugrdColumn" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdColumn_InitializeRow" OnSelectedRowsChange="ugrdColumn_SelectedRowsChange">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="VISIBLE_YN_I" Key="VISIBLE_YN_I" Width="10%" HeaderText="Visible">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COL_ORDER" Key="COL_ORDER" Width="8%" HeaderText="순서">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COL_KEY" Key="COL_KEY" Width="20%" HeaderText="컬럼 KEY">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COL_NAME" Key="COL_NAME" Width="20%" HeaderText="컬럼명칭">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>                                            
                                                <ig:UltraGridColumn BaseColumnName="COL_DESC" Key="COL_DESC" Width="27%" HeaderText="컬럼설명">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COL_TYPE_T" Key="COL_TYPE_T" Width="15%" HeaderText="컬럼유형">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SEQ" Key="SEQ" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="VISIBLE_YN" Key="VISIBLE_YN" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="USE_YN" Key="USE_YN" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COL_TYPE" Key="COL_TYPE" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COL_WIDTH" Key="COL_WIDTH" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="COL_ALIGN" Key="COL_ALIGN" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="DATA_TYPE" Key="DATA_TYPE" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PROC_NAME" Key="PROC_NAME" Hidden="true"></ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PROC_TYPE" Key="PROC_TYPE" Hidden="true"></ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout CellPaddingDefault="2" 
                                        AllowColSizingDefault="Free" 
                                        AllowColumnMovingDefault="None" 
                                        AllowDeleteDefault="No"
                                        AllowSortingDefault="No"
                                        BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="NotSet"
                                        Name="ugrdColumn" 
                                        RowHeightDefault="23px" 
                                        HeaderStyleDefault-Height="25px"
                                        RowSelectorsDefault="No" 
                                        SelectTypeRowDefault="Extended" 
                                        Version="4.00" 
                                        CellClickActionDefault="RowSelect" 
                                        TableLayout="Fixed" 
                                        StationaryMargins="Header" 
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
                                        </SelectedRowStyleDefault>
                                        <ClientSideEvents />--%>
                                        
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                        
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                            <td style="width: 40%; padding-left: 3px;" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                                <colgroup>
                                                    <col width="30%" style="height: 30px;" align="center" />
                                                    <col width="70%" style="height: 30px;" />
                                                </colgroup>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        컬럼보이기
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:RadioButtonList ID="rblVISIBLE_YN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        사용여부
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:RadioButtonList ID="rblUSE_YN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        컬럼순서
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:TextBox ID="txtCOL_ORDER" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        컬럼 KEY
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:TextBox ID="txtCOL_KEY" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        컬럼 명칭
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:TextBox ID="txtCOL_NAME" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        컬럼 설명
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:TextBox ID="txtCOL_DESC" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        컬럼 유형
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:DropDownList ID="ddlTYPE" runat="server" CssClass="box01" Width="100%" Enabled="false"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        컬럼 넓이
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:TextBox ID="txtCOL_WIDTH" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        컬럼 정렬
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:DropDownList ID="ddlALIGN" runat="server" CssClass="box01" Width="100%"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        데이터 유형
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:DropDownList ID="ddlDATATYPE" runat="server" CssClass="box01" Width="100%"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        계산프로시져명
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:TextBox ID="txtPROC_NAME" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        BIAS 점수대상
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:DropDownList ID="ddlPROCTYPE" runat="server" CssClass="box01" Width="100%"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 3px;">
                                            <asp:ImageButton ID="iBtnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClientClick="return checkSave();" OnClick="iBtnSave_Click" />
                                            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    <script>gfWinFocus();</script>
    <!--- MAIN END --->
    </form>
</body>
</html>
