<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4300.aspx.cs" Inherits="ctl_ctl4300" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript">
        
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
        gfOpenWindow("ctl4301.aspx?TYPE=" + gfGetSelect(gfGetFindObj("ddlType")), 407, 400, false, true);
    }
    else if (sMode.toUpperCase() == "UPD")
    {
        var sCodeID = (argc >= 2 ? argv[1] : "");
        
        if (sCodeID != "")
        {
            gfOpenWindow("ctl4301.aspx?CODE_ID=" + sCodeID, 407, 223, false, true);
        }
    }
}

</script>

<!--- MAIN START --->                
<table border="0" cellspacing="0" cellpadding="0" width="100%"  height="100%" >
    <tr style=" height:25px;">
        <td colspan="3">
            <asp:hiddenfield id="hdnCodeInfoID" runat="server"></asp:hiddenfield>
            <span style="color: #3300ff">
            ※ 분류코드 접두어- BS:BSC System Code, BU:BSC User Code, PS: 성과평가
                System Code, 성과평가 User Code&nbsp;</span>
        </td>
    </tr>
    <tr style="height:80%;">
        <td valign="top" style="width:265px;">
            <ig:UltraWebGrid ID="ugrdCategory" runat="server" Height="100%" Width="100%" OnClick="ugrdCategory_Click">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <Columns>
                            <ig:UltraGridColumn BaseColumnName="CATEGORY_CODE" HeaderText="코드" Key="CATEGORY_CODE" Width="58px">
                                <CellStyle VerticalAlign="Top" />
                                <HEADER caption="코드">
                                </HEADER>
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            </ig:UltraGridColumn>                                            
                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue="" BaseColumnName="CATEGORY_NAME" NullText=" "
                                HeaderText="분류명" Key="CATEGORY_NAME" Width="132">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="분류명" Title="">                                                    
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <CELLSTYLE horizontalalign="Left" verticalalign="Middle"></CELLSTYLE>
                                <Footer Caption="" Title="">
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue="" BaseColumnName = "SYSTEM_YN" NullText=" "
                                HeaderText="S/U" Key="SYSTEM_YN" Width="37px" Type="CheckBox">
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                <Header Caption="S/U" Title="">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <CELLSTYLE horizontalalign="Left" verticalalign="Middle"></CELLSTYLE>
                                <Footer Caption="" Title="">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="NotSet"
                    Name="ugrdCategory" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                    Version="4.00" CellClickActionDefault="RowSelect" OptimizeCSSClassNamesOutput="False">
                    <%--<GroupByBox>
                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
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
                        ForeColor="White" Height="30px" HorizontalAlign="Left">
                        <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                    </FrameStyle>
                    <Pager>
                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </PagerStyle>
                    </Pager>
                    <AddNewBox Hidden="False" Prompt="행추가">
                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </BoxStyle>
                        <ButtonStyle BorderStyle="Outset" Cursor="Hand" Height="20px" Width="20px">
                        </ButtonStyle>
                    </AddNewBox>
                    <AddNewRowDefault>
                        <RowStyle BackColor="#FFC0C0" BorderColor="#FFE0C0" BorderStyle="Solid" BorderWidth="1px"
                            ForeColor="Blue"></RowStyle>
                    </AddNewRowDefault>--%>
                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                    
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                </DisplayLayout>
            </ig:UltraWebGrid>
        </td>
        <td style="width:20px;"></td>
        <td valign="top">
            <ig:UltraWebGrid ID="ugrdComCode" runat="server" Width="100%" height="100%" OnActiveRowChange="ugrdComCode_ActiveRowChange" OnInitializeRow="ugrdComCode_InitializeRow">
                <Bands>
                    <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                        <Columns>
                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="CODE_INFO_ID"  HeaderText="선택" Key="CODE_INFO_ID" Type="CheckBox" Width="40px" Hidden="True">
                                <CellStyle HorizontalAlign="Center" />
                                <HEADER caption="선택"></HEADER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="CATEGORY_CODE" HeaderText="분류코드" Key="CATEGORY_CODE" Width="50px" Hidden="True">
                                <CellStyle VerticalAlign="Top" />
                                <HEADER caption="분류코드">
                                    <ROWLAYOUTCOLUMNINFO originx="1" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="1" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue=""  NullText=" "
                                HeaderText="분류명" Key="CATEGORY_NAME" Width="130px" Hidden="True">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="분류명" Title="">                                                    
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                <Footer Caption="" Title="">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="ETC_CODE" HeaderText="기타코드" Key="ETC_CODE" Width="65px"  NullText="">
                                <HEADER caption="기타코드">
                                    <ROWLAYOUTCOLUMNINFO originx="3" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="3" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="CODE_NAME" HeaderText="기타코드명" Key="CODE_NAME" DataType=""  NullText="" Width="150px">
                                <CellStyle HorizontalAlign="Left" />
                                <HEADER caption="기타코드명">
                                    <ROWLAYOUTCOLUMNINFO originx="4" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="4" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="CODE_DESC" HeaderText="코드설명" Key="CODE_DESC"  NullText=" " Width="150px">
                                <CellStyle horizontalalign="Left" />
                                <HEADER caption="코드설명">
                                    <ROWLAYOUTCOLUMNINFO originx="5" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="5" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="SORT_ORDER" HeaderText="정렬순서" DataType="System.Int" Key="SORT_ORDER"  NullText="" Width="55px">
                                <CellStyle HorizontalAlign="Center" />
                                <HEADER caption="정렬순서">
                                    <ROWLAYOUTCOLUMNINFO originx="6" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="6" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="USE_YN" HeaderText="사용여부" Key="USE_YN" Type="CheckBox" Width="60px">
                                <CellStyle HorizontalAlign="Center" />
                                <HEADER caption="사용여부">
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="SEGMENT1" HeaderText="SEGMENT1" Key="SEGMENT1" Width="80px">
                                <CellStyle HorizontalAlign="Center" />
                                <HEADER caption="여유필드1">
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="SEGMENT2" HeaderText="SEGMENT2" Key="SEGMENT2" Width="80px">
                                <CellStyle HorizontalAlign="Center" />
                                <HEADER caption="여유필드2">
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="SEGMENT3" HeaderText="SEGMENT3" Key="SEGMENT3" Width="80px">
                                <CellStyle HorizontalAlign="Center" />
                                <HEADER caption="여유필드3">
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="SEGMENT4" HeaderText="SEGMENT4" Key="SEGMENT4" Width="80px">
                                <CellStyle HorizontalAlign="Center" />
                                <HEADER caption="여유필드4">
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="SEGMENT5" HeaderText="SEGMENT5" Key="SEGMENT5" Width="80px">
                                <CellStyle HorizontalAlign="Center" />
                                <HEADER caption="여유필드5">
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </HEADER>
                                <FOOTER>
                                    <ROWLAYOUTCOLUMNINFO originx="7" />
                                </FOOTER>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>

                <DisplayLayout 
                                CellPaddingDefault="2" 
                                AllowColSizingDefault="Free" 
                                AllowColumnMovingDefault="OnServer" 
                                BorderCollapseDefault="Separate"
                                HeaderClickActionDefault="NotSet" 
                                Name="ugrdComCode" 
                                RowHeightDefault="20px"
                                RowSelectorsDefault="No" 
                                SelectTypeRowDefault="Extended" 
                                Version="4.00" 
                                TableLayout="Fixed" 
                                StationaryMargins="Header" 
                                AutoGenerateColumns="False"
                                CellClickActionDefault="RowSelect"
                                OptimizeCSSClassNamesOutput="False">
                    <%--<GroupByBox>
                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" Height="30px" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
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
                    <AddNewBox Hidden="False" Prompt="행추가">
                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </BoxStyle>
                        <ButtonStyle BorderColor="SlateGray" BorderStyle="Outset" Cursor="Hand" Height="25px" Width="20px">
                        </ButtonStyle>
                    </AddNewBox>
                    <AddNewRowDefault>
                        <RowStyle BackColor="White" Cursor="Hand"></RowStyle>
                    </AddNewRowDefault>
                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                    </SelectedRowStyleDefault>--%>
                    <CLIENTSIDEEVENTS MouseOverHandler="MouseOverHandler" />
                    
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
            </DisplayLayout>
            </ig:UltraWebGrid>
        </td>
        
        <!--<CLIENTSIDEEVENTS mousedownhandler="UltraWebGrid1_MouseDownHandler" mouseuphandler="UltraWebGrid1_MouseUpHandler" cellclickhandler="UltraWebGrid1_CellClickHandler" aftercellupdatehandler="UltraWebGrid1_AfterCellUpdateHandler" clickcellbuttonhandler="UltraWebGrid1_ClickCellButtonHandler" beforecellupdatehandler="UltraWebGrid1_BeforeCellUpdateHandler" />-->
    </tr>
    
    <tr style="padding-top:5px;">
        <td valign="top">
            <table id="Table4" border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                <tr>
                    <td class="cssTblTitle">
                        분류코드&nbsp;</td>
                    <td class="cssTblContent">
                        <asp:textbox id="txtCatCode" runat="server"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitle">
                        분류명</td>
                    <td class="cssTblContent">
                        <asp:textbox id="txtCatName" runat="server"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitle" style="height: 19px">
                        System/User</td>
                    <td class="cssTblContent" style="height: 19px">
                        <asp:checkbox id="chkSystemYn" runat="server"></asp:checkbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitle" style="height: 19px">
                        사용여부</td>
                    <td class="cssTblContent" style="height: 19px">
                        <asp:checkbox id="chkUseYn" runat="server"></asp:checkbox>
                    </td>
                </tr>
            </table>
        </td>
        <td></td>
        <td>
            <table id="Table1" border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                <tr>
                    <td class="cssTblTitle">
                        분류코드
                    </td>
                    <td class="cssTblContent">
                        <asp:textbox id="txtSCatCode" runat="server" Width="100%" Enabled="False"></asp:textbox>
                    </td>
                    <td class="cssTblTitle">
                        분류명
                    </td>
                    <td class="cssTblContent">
                        <asp:textbox id="txtSCatName" runat="server" Width="100%" Enabled="False"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitle">
                        기타코드
                    </td>
                    <td class="cssTblContent">
                        <asp:textbox id="txtEtcCode" runat="server" Width="100%"></asp:textbox>
                    </td>
                    <td class="cssTblTitle">
                        기타코드명
                    </td>
                    <td class="cssTblContent">
                        <asp:textbox id="txtEtcName" runat="server" Width="100%"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitle">
                        정렬순서
                    </td>
                    <td class="cssTblContent">
                        <asp:textbox id="txtSortOrder" runat="server" Width="100%"></asp:textbox>
                    </td>
                    <td class="cssTblTitle">
                        사용여부
                    </td>
                    <td class="cssTblContent">
                        <asp:checkbox id="chkSUseYn" runat="server"></asp:checkbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitle">코드설명</td>
                    <td class="cssTblContent">
                        <asp:textbox id="txtEtcDesc" runat="server" Width="100%"></asp:textbox>
                    </td>
                    <td class="cssTblTitle">여유필드1</td>
                    <td class="cssTblContent"><asp:TextBox ID="txtSegment1" runat="server" width="100%" Height="100%"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td class="cssTblTitle">여유필드2</td>
                    <td class="cssTblContent"><asp:TextBox ID="txtSegment2" runat="server" width="100%" Height="100%"></asp:TextBox> </td>
                    <td class="cssTblTitle">여유필드3</td>
                    <td class="cssTblContent"><asp:TextBox ID="txtSegment3" runat="server" width="100%" Height="100%"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td class="cssTblTitle">여유필드4</td>
                    <td class="cssTblContent"><asp:TextBox ID="txtSegment4" runat="server" width="100%" Height="100%"></asp:TextBox> </td>
                    <td class="cssTblTitle">여유필드5</td>
                    <td class="cssTblContent"><asp:TextBox ID="txtSegment5" runat="server" width="100%" Height="100%"></asp:TextBox> </td>
                </tr>
            </table>
        </td>
    </tr>
    
    <tr class="cssPopBtnLine">
        <td align="right">
            <asp:imagebutton id="btnCatSave" runat="server" imageurl="../images/btn/b_001.gif" OnClick="btnCatSave_Click"></asp:imagebutton>
        </td>
        <td></td>
        <td align=right>
            <asp:literal id="ltlMsg" runat="server"></asp:literal>
            <ASP:LINKBUTTON id="lbReload" runat="server" ></ASP:LINKBUTTON>
            <asp:imagebutton id="iBtnAdd" runat="server" imageurl="../images/btn/b_156.gif" OnClick="iBtnAdd_Click"></asp:imagebutton>
            <ASP:IMAGEBUTTON id="iBtnUpdate" runat="server" imageurl="../images/btn/b_002.gif" OnClick="iBtnUpdate_Click"></ASP:IMAGEBUTTON>
        </td>
    </tr>
</table>
<!--- MAIN END --->
</asp:Content>
            