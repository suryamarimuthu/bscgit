<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl3100_01.aspx.cs" Inherits="ctl_ctl3100_01" MasterPageFile="~/_common/lib/MicroBSC.master" enableEventValidation="false" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script  type="text/javascript">
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

function Valid() 
{
    var ddlRole ="<%= PageUtility.GetByValueDropDownList(ddlRoles) %>";
    
    if(ddlRole == '') 
    {
        alert('등록할 권한이 없습니다.');
        return false;
    }
    
    return true;
}        

var popHeight = 460 + 50;
    function OpenInsertWindow()
    {
        var ICCB1 = "<%= this.ICCB1 %>";
        gfOpenWindow('CTL301020.aspx?iType=A&ROLE_REF_ID=0&CCB1='+ICCB1, 650, popHeight);
    }     
    
    function OpenMenuInfoWindow(type,menu_ref_id)
    {
        var ICCB1 = "<%= this.ICCB1 %>";
        gfOpenWindow("CTL301020.aspx?iType=" + type + "&MENU_REF_ID=" + menu_ref_id + "&CCB1=" + ICCB1, 650, popHeight);
    }    
    
    function doAddingRole()
    {
        return confirm('권한을 추가할까요?');
    }
    
    function doDeletingRole()
    {
        return confirm('권한을 삭제할까요?');
    }
    
</script>        

 <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" width="100%" height="100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr class="cssPopBtnLine" style="text-align:left">
                        <td colspan="2">
                            <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                            <asp:label id="lblRowCnt" runat="server" text="0"></asp:label>
                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                        </td>
                        <%--<td align="right" colspan="2">(Total Rows : <asp:Label ID="" runat="server" Text="" />)</td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height:90%">
                
                <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:TemplatedColumn AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No" Key="selchk"
                                    Width="30px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                    </HeaderTemplate>
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" />
                                    </CellTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="MENU_UPDATE" HeaderText="수정" Key="MENU_UPDATE"
                                    Width="40px">
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                    </CellStyle>
                                    <Header Caption="수정">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MENU_REF_ID" HeaderText="Key" Hidden="True"
                                    Key="MENU_REF_ID" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="Key">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_MENU_ID" HeaderText="부모" Hidden="True"
                                    Key="UP_MENU_ID" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="부모">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MENU_NAME" HeaderText="메뉴명" Key="MENU_NAME"
                                    Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="메뉴명">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MENU_PAGE_NAME" HeaderText="파일명" Key="MENU_PAGE_NAME"
                                    Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="파일명">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MENU_FULL_PATH" HeaderText="전체경로" Key="MENU_FULL_PATH"
                                    Width="330px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="전체경로">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn  AllowUpdate="No" Key="MENU_ROLE"  Width="120px">
                                    <Header Caption="적용권한">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <CellTemplate>
                                        <asp:DropDownList ID="ddlMenuRole" runat="server" Width="100%" Font-Size="10px"/>
                                    </CellTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="MENU_TYPE_NAME" HeaderText="메뉴타입" Hidden="True"
                                    Key="MENU_TYPE_NAME" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="메뉴타입">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MENU_DESC" HeaderText="설명" Hidden="True" Key="MENU_DESC"
                                    Width="120px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="설명">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EDIDX" Hidden="True" Key="EDIDX">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="NotSet" 
                                    Name="UltraWebGrid1" 
                                    RowHeightDefault="23px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="Edit" 
                                    ReadOnly = "LevelTwo"
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False">
                            <%--<RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                            </HeaderStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                Width="100%">
                            </FrameStyle>
                            <SelectedRowStyleDefault BackColor="#E2ECF4">
                            </SelectedRowStyleDefault>--%>
                            
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
        <tr>
            <td style="height:10px;">
                <asp:hiddenfield id="hdfMenu_Ref_ID" runat="server"></asp:hiddenfield>
                <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click" Visible="false"></asp:linkbutton>
                <asp:literal id="lblScript" runat="server"></asp:literal>
            </td>
        </tr>
        <tr >
            <td align="right" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width:50%">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="font-size:13px;font-weight:bold;">메뉴 :&nbsp;</td>
                                    <td><img alt="" src="../images/btn/b_005.gif" style="cursor:hand;" onclick="OpenInsertWindow();" />
                                        <asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="iBtnDelete_Click" /></td>
                                </tr>
                            </table>
                        </td>
                        <td align="right">
                             <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="font-size:13px;font-weight:bold;">권한 :&nbsp;</td>
                                    <td>
                                        <asp:dropdownlist id="ddlRoles" runat="server" class="box01"></asp:dropdownlist>
                                        <asp:ImageButton id="iBtnAdd" runat="server" ImageUrl="../images/btn/b_005.gif" onclick="iBtnAdd_Click" OnClientClick="return doAddingRole();"></asp:ImageButton>
                                        <asp:imagebutton id="iBtnRemove" onclick="iBtnRemove_Click" runat="server" ImageUrl="../images/btn/b_004.gif" OnClientClick="return doDeletingRole();"></asp:imagebutton>
                                    </td>
                                </tr>
                             </table>
                        </td>
                    </tr>
                </table>
            </td>
         </tr>
    </table>
    

<!--- MAIN END --->

</asp:Content>