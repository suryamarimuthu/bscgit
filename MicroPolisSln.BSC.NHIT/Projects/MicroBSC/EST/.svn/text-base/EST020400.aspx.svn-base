<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST020400.aspx.cs" Inherits="EST_EST020400" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

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

</script>
    <form id="form1" runat="server">
    <div>
        
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <%--<tr>
            <td colspan="2" height="20">
                <table cellpadding=0 cellspacing=0 border=0 width="100%">
                    <tr>
                        <td>
                            <img src="../images/title/se_ti01.gif" align=absmiddle>
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermRefID_SelectedIndexChanged"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged"></asp:dropdownlist>
                            <!--<img align="absMiddle" src="../images/title/opt_s03.gif" />--><asp:dropdownlist id="ddlEstTermStepID"
                                runat="server" class="box01" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermStepID_SelectedIndexChanged"></asp:dropdownlist></td>
                        <td align="right">
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                            <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px"
                                width="120px"></asp:textbox>
                            <a href="#null" onclick="SearchEstID();">
                                <img align="absMiddle" border="0" src="../images/btn/b_143.gif" /></a>
                            <asp:imagebutton id="ibnSearch" runat="server" height="19px" imagealign="AbsMiddle"
                                imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>
                            <asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <%--<tr height="15px">
            <td width="30%">
                &nbsp;<asp:image id="imgQTitle" runat="server" imageurl="../images/title/ta_t33.gif"></asp:image></td>
            <td>
                &nbsp;<asp:image id="imgTitle" runat="server" imageurl="../images/title/ta_t17.gif"></asp:image>
            </td>
        </tr>--%>
        <tr style="height:100%;">
            <td style="vertical-align: top; width:30% ">
                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" Width="100%" style="left: -4px; top: 233px" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="ROLE_REF_ID" Key="ROLE_REF_ID" Hidden="True" >
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ROLE_NAME" Key="ROLE_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="권한명">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ROLE_DESC" Key="ROLE_DESC" Width="150px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="권한설명">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout  CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="NotSet" 
                                    Name="UltraWebGrid1" 
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
                                    OptimizeCSSClassNamesOutput="False">
                        <%--<GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
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
                            ForeColor="White" HorizontalAlign="Center">
                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
                            Cursor="Hand" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                        </AddNewBox>--%>
                        
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
                <ig:UltraWebGrid id="UltraWebGrid2" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid2_InitializeRow">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                            </RowTemplateStyle>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="COMMAND_NAME" Key="COMMAND_NAME" Hidden="True">
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" />
                                    </CellTemplate>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid2');" />
                                    </HeaderTemplate>
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="COMMAND_NAME" Key="COMMAND_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="버튼 Commmand Name">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="BUTTON_NAME" Key="BUTTON_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="Command Name 설명">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout  Name="UltraWebGrid2" 
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No"  
                                    Version="4.00" 
                                    ReadOnly="LevelTwo"
                                    CellClickActionDefault="NotSet" 
                                    TableLayout="Fixed"  
                                    AutoGenerateColumns="False">
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
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>--%>
                        
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
    <tr class="cssPopBtnLine">
        <td align="right" colspan="2">
            <asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click"></asp:ImageButton>
        </td>
    </tr>
</table>
<asp:literal id="ltrScript" runat="server"></asp:literal>
<asp:hiddenfield id="hdfRoleRefID" runat="server"></asp:hiddenfield>
&nbsp;
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    <!--- MAIN END --->
    </div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

