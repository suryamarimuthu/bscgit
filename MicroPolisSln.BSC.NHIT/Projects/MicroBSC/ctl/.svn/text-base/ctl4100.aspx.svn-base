<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4100.aspx.cs" Inherits="ctl_ctl4100" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
<script type="text/javascript">
        
function himgDaily_Click()
{
    gfOpenDialog("eis0002_Daily_Main.aspx", "", 820, 500);
}

function mfOpenWindow(sMode)
{
    var argv = mfOpenWindow.arguments;
    var argc = argv.length;

    if (sMode.toUpperCase() == "ADD")
    {
        gfOpenWindow("ctl4101.aspx?TYPE=" + gfGetSelect(gfGetFindObj("ddlType")), 407, 193, false, true);
    }
    else if (sMode.toUpperCase() == "UPD")
    {
        var sCodeID = (argc >= 2 ? argv[1] : "");
        
        if (sCodeID != "")
        {
            gfOpenWindow("ctl4102.aspx?CODE_ID=" + sCodeID, 407, 223, false, true);
        }
    }
}
</script>
        
<form id="form1" runat="server">
<div>
        <%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
        <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" width="98%">
         <tr>
            <td>
                <table cellSpacing=0 width=100% border=0>
                    <tr>
                        <td width="15%">
                            <img src="../images/title/se_ti01.gif" align=absmiddle>
                        </td>
                        <td width="50%">
                            <asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01">
                            </asp:DropDownList>
                            
                        </td>
                        
                        <td align=right>
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" onclick="iBtnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table border="0" cellspacing="0" cellpadding="0" width="98%"  >
        <tr>
            <td style="
                       width:100%;
                       height:expression(eval(document.body.clientHeight)-200);
                      "
            >
                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%"  OnInitializeRow="UltraWebGrid1_InitializeRow" height="100%">
                    <Bands>
                        <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn AllowUpdate="Yes"  HeaderText="선택" Key="selChk" Type="CheckBox" Width="40px">
                                    <CellStyle HorizontalAlign="Center" />
                                    <HEADER caption="선택">
                                    </HEADER>
                                </ig:UltraGridColumn>
                                
                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_CODE_ID" hidden="true" headertext="V_CODE_ID" key="V_CODE_ID">
                                    <CELLSTYLE verticalalign="Top"></CELLSTYLE>
                                    <HEADER caption="V_CODE_ID">
                                        <ROWLAYOUTCOLUMNINFO originx="1" />
                                    </HEADER>
                                    <FOOTER>
                                        <ROWLAYOUTCOLUMNINFO originx="1" />
                                    </FOOTER>
                                </ig:ULTRAGRIDCOLUMN>
                                
                                <ig:UltraGridColumn BaseColumnName="V_TYPE" hidden="true" HeaderText="V_TYPE" Key="V_TYPE">
                                    <CellStyle VerticalAlign="Top" />
                                    <HEADER caption="V_TYPE">
                                        <ROWLAYOUTCOLUMNINFO originx="1" />
                                    </HEADER>
                                    <FOOTER>
                                        <ROWLAYOUTCOLUMNINFO originx="1" />
                                    </FOOTER>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue=""
                                    HeaderText="수정" Key="MODIFY" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="수정" Title="">
                                        
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="V_STEPNAME" HeaderText="Threshold 명" Key="V_STEPNAME">
                                    <HEADER caption="Threshold 명">
                                        <ROWLAYOUTCOLUMNINFO originx="2" />
                                    </HEADER>
                                    <FOOTER>
                                        <ROWLAYOUTCOLUMNINFO originx="2" />
                                    </FOOTER>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="V_MIN_VALUE" HeaderText="최저수치" Key="V_MIN_VALUE" datatype="" format="#,##0.##">
                                    <CellStyle HorizontalAlign="Right" />
                                    <HEADER caption="최저수치">
                                        <ROWLAYOUTCOLUMNINFO originx="3" />
                                    </HEADER>
                                    <FOOTER>
                                        <ROWLAYOUTCOLUMNINFO originx="3" />
                                    </FOOTER>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="V_COLOR" HeaderText="표시색상" Key="V_COLOR" >
                                    <CellStyle horizontalalign="Center" />
                                    <HEADER caption="표시색상">
                                        <ROWLAYOUTCOLUMNINFO originx="4" />
                                    </HEADER>
                                    <FOOTER>
                                        <ROWLAYOUTCOLUMNINFO originx="4" />
                                    </FOOTER>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="V_IMG_PATH" HeaderText="이미지파일명" Key="V_IMG_PATH">
                                    <CellStyle HorizontalAlign="Center" />
                                    <HEADER caption="이미지파일명">
                                        <ROWLAYOUTCOLUMNINFO originx="5" />
                                    </HEADER>
                                    <FOOTER>
                                        <ROWLAYOUTCOLUMNINFO originx="5" />
                                    </FOOTER>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="V_POINT" HeaderText="평가점수" Key="V_POINT">
                                    <CellStyle HorizontalAlign="Center" />
                                    <HEADER caption="평가 점수">
                                        <ROWLAYOUTCOLUMNINFO originx="6" />
                                    </HEADER>
                                    <FOOTER>
                                        <ROWLAYOUTCOLUMNINFO originx="6" />
                                    </FOOTER>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>

                    <DisplayLayout 
                                    CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="OnServer" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="UltraWebGrid1" 
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    ViewType="Flat" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                        Width="100%">
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
                    <CLIENTSIDEEVENTS mousedownhandler="UltraWebGrid1_MouseDownHandler" mouseuphandler="UltraWebGrid1_MouseUpHandler" cellclickhandler="UltraWebGrid1_CellClickHandler" aftercellupdatehandler="UltraWebGrid1_AfterCellUpdateHandler" clickcellbuttonhandler="UltraWebGrid1_ClickCellButtonHandler" beforecellupdatehandler="UltraWebGrid1_BeforeCellUpdateHandler" />
                </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
            
            <!--<CLIENTSIDEEVENTS mousedownhandler="UltraWebGrid1_MouseDownHandler" mouseuphandler="UltraWebGrid1_MouseUpHandler" cellclickhandler="UltraWebGrid1_CellClickHandler" aftercellupdatehandler="UltraWebGrid1_AfterCellUpdateHandler" clickcellbuttonhandler="UltraWebGrid1_ClickCellButtonHandler" beforecellupdatehandler="UltraWebGrid1_BeforeCellUpdateHandler" />-->
        </tr>
        
        <tr><td height="10px">&nbsp;</td></tr>
        
        <tr>
            <td align=right>
                <ASP:LINKBUTTON id="lbReload" runat="server" onclick="lbReload_Click"></ASP:LINKBUTTON>
                <ASP:IMAGEBUTTON id="iBtnDel" runat="server" imageurl="../images/btn/b_004.gif" onclick="iBtnDel_Click"></ASP:IMAGEBUTTON>
                &nbsp;&nbsp;
                <ASP:IMAGEBUTTON id="iBtnAdd" runat="server" imageurl="../images/btn/b_156.gif" onclick="iBtnAdd_Click"></ASP:IMAGEBUTTON>
            </td>
        </tr>
    </table>
    <!--- MAIN END --->
<MenuControl:MenuControl_Bottom id="MenuControl_Bottom1" runat="server" />
</div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>