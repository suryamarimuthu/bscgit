<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_pdt_manager.aspx.cs" Inherits="usr_pdt_manager" %>

<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script type="text/javascript">
  
  function ValidCheck() 
    {
        var txtDeptID = document.getElementById('txtDeptID');
        
        if(txtDeptID.value == '0' || txtDeptID.value == "")
        {
            alert('부서를 선택하세요');
            return false;
        }
        
        return true;
    }
</script>

    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td valign="top" height="40">
           <table cellpadding=2 cellspacing=0 border=0>
		    <tr>
		        <td colspan="2" height="20px" class="tableoutBorder">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td class="tableTitle" width="80">평가기간</td>
                            <td class="tableContent" width="150">
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" width="125px" CssClass="box01"></asp:dropdownlist></td>
                            <td class="tableTitle" width="80">
                                버젼</td>
                            <td class="tableContent" width="120">
                                <asp:dropdownlist id="ddlStgVersion" runat="server" CssClass="box01"></asp:dropdownlist></td>
                            <td class="tableTitle" width="80">부서</td>
                            <td class="tableContent" width="120">
                                <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td onclick="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onmouseover="this.style.cursor='hand'">
                                        <asp:textbox id="txtDropDown" runat="server" width="149px" onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onclick="this.style.cursor='hand'"></asp:textbox><asp:textbox id="txtDeptID" runat="server" bordercolor="White" borderstyle="None"
                                            borderwidth="0px" cssclass="NotBoader" height="0px" style="visibility: hidden"
                                            width="0px">0</asp:textbox>
                                        <asp:panel id="Panel1" runat="server" cssclass="popupControl">
                                            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                <DIV style="BORDER-RIGHT: #f4f4f4 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: #f4f4f4 1px solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; OVERFLOW: auto; BORDER-LEFT: #f4f4f4 1px solid; WIDTH: 200px; PADDING-TOP: 2px; BORDER-BOTTOM: #f4f4f4 1px solid; HEIGHT: 350px; BACKGROUND-COLOR: white" id="leftLayer">
                                                    <asp:TreeView id="trvEstDept" runat="server" NodeIndent="5" OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged">
                                                        <SelectedNodeStyle BackColor="Silver"></SelectedNodeStyle>
                                                    </asp:TreeView>
                                                </DIV>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:panel>
                                        <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel1"
                                            Position="Bottom" TargetControlID="txtDropDown">
                                        </ajaxToolkit:PopupControlExtender>
                                        <ajaxToolkit:PopupControlExtender ID="PopupControlExtender2" runat="server" PopupControlID="Panel1"
                                            Position="Bottom" TargetControlID="txtDeptID">
                                        </ajaxToolkit:PopupControlExtender>
                                    </td>
                                </tr>
                            </table>
                            </td>
                            <td align="right" class="tableContent" colspan="2" width="90">
                                        <asp:imagebutton id="iBtnSearch" runat="server" imageurl="~/images/btn/b_033.gif"
                                            onclick="iBtnSearch_Click"></asp:imagebutton>&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
		        </td>
		    </tr>
    </table>
        </td>
    </tr>
    <tr>
        <td>
            <ig:UltraWebGrid ID="DataGrid1" runat="server">
                <Bands>
                    <ig:UltraGridBand>
                        <Columns>
                            <ig:TemplatedColumn Key="STG_NM">
                                <Header Caption="전략명"></Header>
                                <CellTemplate>
                                    <asp:Label id="lblStgName" Width="300" Text='<%# DataBinder.Eval(Container, "DataItem.STG_NAME") %>' Runat="server"></asp:Label> 
                                    <asp:Label id="lblStgRefID" Text='<%# DataBinder.Eval(Container, "DataItem.STG_REF_ID") %>' Runat="server" Visible="False"></asp:Label> 
                                </CellTemplate>
                            </ig:TemplatedColumn>
                            <ig:TemplatedColumn Key="STG_MAP">
                                <Header Caption="전략맵반영여부"></Header>
                                <CellTemplate>
                                    <asp:CheckBox ID="cBoxStgMap" runat="server" />
                                </CellTemplate>
                            </ig:TemplatedColumn>
                            <ig:TemplatedColumn Key="STG_FLOW">
                                <Header Caption="Flow (FCPL)"></Header>
                                <CellTemplate>
                                    <asp:CheckBox id="cBoxF" runat="server"></asp:CheckBox>
                                    <asp:CheckBox id="cBoxC" runat="server"></asp:CheckBox>
                                    <asp:CheckBox id="cBoxP" runat="server"></asp:CheckBox>
                                    <asp:CheckBox id="cBoxL" runat="server"></asp:CheckBox> 
                                </CellTemplate>
                            </ig:TemplatedColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout Name="DataGrid1" Version="4.00" 
                    RowHeightDefault="18px" 
                    SelectTypeRowDefault="Single" 
                    BorderCollapseDefault="Separate" 
                    AllowColSizingDefault="Free"
                    TableLayout="Fixed" 
                    CellClickActionDefault="RowSelect"
                    StationaryMargins="Header" 
                    UseFixedHeaders="True" >
                    <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif" BorderStyle="Solid" HorizontalAlign="Center"
                                ForeColor="White" BackColor="#94BAC9">
                                <Padding Left="0px" Right="0px"></Padding>
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </HeaderStyleDefault>
                    <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
                    <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                    <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                                BorderStyle="Solid" BackColor="#FAFCF1" Height="100%">
                    </FrameStyle>
                    <ActivationObject BorderColor="170, 184, 131" BorderWidth=""></ActivationObject>
                    <GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
                        <BoxStyle BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
                        </BoxStyle>
                        <BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
                    </GroupByBox>
                    <RowExpAreaStyleDefault BackColor="WhiteSmoke"></RowExpAreaStyleDefault>
                    <SelectedRowStyleDefault ForeColor="White" BackColor="#BECA98"></SelectedRowStyleDefault>
                    <SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="#CF5F5B"></SelectedGroupByRowStyleDefault>
                    <RowStyleDefault VerticalAlign="Middle" BorderWidth="1px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderColor="#AAB883"
                                BorderStyle="Solid" HorizontalAlign="Left" ForeColor="#333333" BackColor="White">
                                <Padding Left="3px" Right="3px"></Padding>
                                <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                    </RowStyleDefault>
                </DisplayLayout>
            </ig:UltraWebGrid>
        </td>
    </tr>
    <tr>
        <td style="height: 50px" align="right">
        <asp:imagebutton id="iBtnSave" runat="server" imageurl="~/images/btn/b_007.gif"
                                        onclick="iBtnSave_Click" Visible="False"></asp:imagebutton>
            &nbsp; &nbsp; &nbsp;
        </td>
    </tr>
</table>
           
<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>
<asp:literal id="ltrScript" runat="server"></asp:literal>
