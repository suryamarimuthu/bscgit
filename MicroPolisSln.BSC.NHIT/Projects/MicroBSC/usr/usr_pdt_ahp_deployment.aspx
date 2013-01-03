<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_pdt_ahp_deployment.aspx.cs" Inherits="usr_usr_pdt_ahp_deployment" %>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>

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
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td valign="top" height="40">
            <TABLE cellSpacing=0 cellPadding=2 border=0><TBODY>
                <TR>
                    <TD class="tableoutBorder" colSpan=2 height=20>
                        <TABLE cellSpacing=0 cellPadding=2 width="100%" border=0>
                            <TBODY>
                                <TR>
                                    <TD class="tableTitle" width=80>평가기간</TD>
                                    <TD class="tableContent" width=150>
                                        <asp:dropdownlist id="ddlEstTermInfo" runat="server" width="125px" CssClass="box01"></asp:dropdownlist>
                                    </TD>
                                    <TD class="tableTitle" width=80>버젼</TD>
                                    <TD class="tableContent" width=120>
                                        <asp:dropdownlist id="ddlStgVersion" runat="server" CssClass="box01"></asp:dropdownlist>
                                    </TD>
                                    <TD class="tableTitle" width=80>부서</TD>
                                    <TD class="tableContent" width=120>
                                        <TABLE cellSpacing=0 cellPadding=0 border=0>
                                            <TBODY>
                                                <TR>
                                                    <TD onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onclick="this.style.cursor='hand'">
                                                        <asp:textbox id="txtDropDown" runat="server" width="142px" onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onclick="this.style.cursor='hand'"></asp:textbox><asp:textbox style="VISIBILITY: hidden" id="txtDeptID" runat="server" width="0px" height="0px" cssclass="NotBoader" borderwidth="0px" borderstyle="None" bordercolor="White">0</asp:textbox> 
                                                        <asp:checkbox id="cBoxIsSubDept" runat="server" text="하위부서 포함"></asp:checkbox>
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
                                                            <ajaxToolkit:PopupControlExtender id="PopupControlExtender1" runat="server" TargetControlID="txtDropDown" Position="Bottom" PopupControlID="Panel1"></ajaxToolkit:PopupControlExtender> 
                                                            <ajaxToolkit:PopupControlExtender id="PopupControlExtender2" runat="server" TargetControlID="txtDeptID" Position="Bottom" PopupControlID="Panel1"></ajaxToolkit:PopupControlExtender> 
                                                    </TD>
                                                </TR>
                                            </TBODY>
                                        </TABLE>
                                    </TD>
                                    <TD class="tableContent" align=center width=90 colSpan=2>
                                        <asp:imagebutton id="iBtnSearch" runat="server" imageurl="~/images/btn/b_033.gif"
                                            onclick="iBtnSearch_Click"></asp:imagebutton>
                                        <br />
                                        <asp:imagebutton id="iBtnDeploy" runat="server" imageurl="~/images/btn/b_134.gif"
                                            onclick="iBtnDeploy_Click"></asp:imagebutton>
                                    </TD>
                                </TR>
                            </TBODY>
                        </TABLE>
                        </TD>
                    </TR>
                </TBODY>
            </TABLE>
        </td>
    </tr>
    <tr>
        <td height="300px" valign="top">
            <ig:UltraWebGrid ID="DataGrid1" runat="server" Height="100%" Width="100%">
                <Bands>
                    <ig:UltraGridBand>
                        <Columns>
                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" Key="EST_DEPT_NAME">
                                <Header Caption="부서명"></Header>
                            </ig:UltraGridColumn>
                            <ig:TemplatedColumn Key="STG_NM">
                                <Header Caption="전략명"></Header>
                                <CellTemplate>
                                    &nbsp;
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.STG_NAME") %>'></asp:Label>
                                    <asp:Label runat="server" ID="lblStgRefID" Text='<%# DataBinder.Eval(Container, "DataItem.STG_REF_ID") %>' Visible="False"></asp:Label>
                                </CellTemplate>
                            </ig:TemplatedColumn>
                            <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT">
                                <Header Caption="가중치"></Header>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="CI" Key="CI">
                                <Header Caption="CI"></Header>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="CR" Key="CR">
                                <Header Caption="CR"></Header>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="DEPLOY_YN" Key="DEPLOY_YN">
                                <Header Caption="배포여부"></Header>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="DEPLOY_DATE" Key="DEPLOY_DATE">
                                <Header Caption="배포일자"></Header>
                            </ig:UltraGridColumn>
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
</table>
<asp:literal id="ltrScript" runat="server"></asp:literal>
<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

