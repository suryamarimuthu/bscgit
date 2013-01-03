<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr10002.aspx.cs" Inherits="usr_usr10002" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

        <script type="text/javascript" language="javascript">

        function openFullStgMap()
        {
            var url = "<%= this.GetKpiMapUrl() %>" ;
            var wo  = window.open(url, 'WinPop','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=yes,resizable=0,top=0,left=0,width=screen.width, height=screen.height');
            wo.resizeTo(screen.width,screen.height);
        }
        </script>

<!--- MAIN START --->
<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
  <tr>
    <td style="height: 80px"  >
      <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="top">
	      <td style="height: 80px">
	        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
	          <tr>
		        <td class="tableTitle2" align="center" style="width: 80px">조&nbsp;&nbsp;직&nbsp;&nbsp;명</td>
		        <td class="tdBorder" style="width: 630px">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                          <td onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onclick="this.style.cursor='hand'">
                              <asp:TextBox ID="txtDropDown" runat="server" Width="178px" onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onclick="this.style.cursor='hand'" /><asp:TextBox ID="txtDeptID" runat="server" Width="0px" BorderColor="White" BorderWidth="0px" BorderStyle="None" CssClass="NotBoader" Height="0px" style="visibility:hidden;" />
                                <asp:Panel ID="Panel1" runat="server" CssClass="popupControl">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                        <ContentTemplate>
                                           <div style="BORDER-RIGHT: #f4f4f4 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: #f4f4f4 1px solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; OVERFLOW:auto; BORDER-LEFT: #f4f4f4 1px solid; WIDTH: 200px; PADDING-TOP: 2px; BORDER-BOTTOM: #f4f4f4 1px solid; HEIGHT: 350px;background-color:White" id="leftLayer">
                                           <asp:TreeView ID="trvEstDept" runat="server" 
                                                        OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged" 
                                                        NodeIndent="5">
                                                <SelectedNodeStyle BackColor="Silver"></SelectedNodeStyle>
                                            </asp:TreeView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                                
                                <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server"
                                    TargetControlID="txtDropDown"
                                    PopupControlID="Panel1"
                                    Position="Bottom" />
                                
                                <ajaxToolkit:PopupControlExtender ID="PopupControlExtender2" runat="server"
                                    TargetControlID="txtDeptID"
                                    PopupControlID="Panel1"
                                    Position="Bottom" />
                              </td>
                          <td>
                          </td>
                          <td>
                               <asp:DropDownList ID="ddlShowKPI" runat="server" DataTextField="SYS_CTRL_VALUE" DataValueField="SYS_CTRL_KEY" Visible="False"></asp:DropDownList>
                               <asp:Label ID="lblLineType" runat="server" Text="Line" Visible="False"></asp:Label>
                               <asp:DropDownList ID="ddlLineType" runat="server" DataTextField="SYS_CTRL_VALUE" DataValueField="SYS_CTRL_KEY" Visible="False"></asp:DropDownList>
                               <asp:Label ID="lblShowKPI" runat="server" Text="KPI" Visible="False"></asp:Label></td>
                          <td>
                              &nbsp;<asp:CheckBox     ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" />
                              <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                          </td>
                        </tr>
                     </table>
                    <asp:DropDownList ID="ddlEstDept" runat="server" CssClass="box01" Width="120px" Visible="False"></asp:DropDownList></td>
		        <td  rowspan="3" style="width: 1px"></td>
		        <td rowspan="3" class="subTableTitle" valign="top" style="width: 230px" align="right" >
                        <ig:UltraWebGrid ID="ultraLegend" runat="server" Height="100px" Width="100%" OnInitializeRow="ultraLegend_InitializeRow" style="left: 0px"  >
                           <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Width="38px" Hidden="True">
                                            <Header Caption="ESTTERM_REF_ID" >
                                                
                                            </Header>
                                            <HeaderStyle Wrap="True" />
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Width="38px" Hidden="True" HeaderText="YMD">
                                            <Header Caption="YMD" >
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <HeaderStyle Wrap="True" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" HeaderText="EST_DEPT_REF_ID" Key="EST_DEPT_REF_ID" Width="38px" Hidden="True">
                                            <Header Caption="EST_DEPT_REF_ID" >
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <HeaderStyle Wrap="True" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" HeaderText="VIEW_REF_ID" Key="VIEW_REF_ID" Width="38px" Hidden="True">
                                            <Header Caption="VIEW_REF_ID" >
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <HeaderStyle Wrap="True" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="VIEW_NAME" HeaderText="VIEW_NAME" Key="VIEW_NAME" Width="73px">
                                            <Header Caption="VIEW_NAME" >
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <HeaderStyle Wrap="True" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="SCORE" HeaderText="점수" Key="SCORE" DataType="System.Double" Type="Custom" 
                                                Width="45px" AllowUpdate="No" Format="#,##0.00">
                                            <Header Caption="점수">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Right" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="DASH" Key="DASH" Width="6px" HeaderText="">
                                            <Header Caption="" >
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Center" />
                                            <HeaderStyle Wrap="True" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT" DataType="System.Double" Type="Custom" 
                                               Width="60px" AllowUpdate="No"  Format="#,##0.00">
                                            <Header Caption="가중치">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                        <DisplayLayout AllowColSizingDefault="NotSet" BorderCollapseDefault="NotSet"
                            HeaderClickActionDefault="NotSet" Name="ultraLegend" RowHeightDefault="18px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="NotSet" TableLayout="Fixed" StationaryMargins="Header" ColHeadersVisibleDefault="No" AutoGenerateColumns="False" ScrollBarView="Vertical">
                            <GroupByBox>
                                <Style BackColor="Transparent" BorderColor="Transparent"></Style>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="Transparent" BorderColor="Transparent" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="Transparent" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="Transparent" ForeColor="White">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" BorderWidth="1px">
                                <BorderDetails  ColorLeft="Transparent" ColorTop="Transparent" />
                                <Padding Left="2px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="Transparent" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="Transparent" ForeColor="White">
                                <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="9pt" Height="100px"
                                Width="100%">
                            </FrameStyle>
                            <Pager>
                                <Style BackColor="Transparent" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                </Style>
                            </Pager>
                            <AddNewBox Hidden="False">
                                <Style BackColor="Transparent" BorderColor="Transparent" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                </Style>
                            </AddNewBox>
                            <SelectedRowStyleDefault BackColor="Transparent">
                            </SelectedRowStyleDefault>
                            <FixedCellStyleDefault BackColor="Transparent">
                            </FixedCellStyleDefault>
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                        </DisplayLayout>
                    </ig:UltraWebGrid>
                </td>
	        </tr>
	        <tr>
		        <td class="tableTitle2" align="center" style="height: 22px; width: 80px;">조직 &nbsp;비전</td>
		        <td class="tdBorder" style="height: 22px; width: 480px;">&nbsp;<asp:Literal ID="ltrStgMapVision" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hdfDeptID" runat="server" />
                </td>
	        </tr>
	        <tr>
		        <td class="tableTitle2" align="center" style="width: 80px"><%=GetText("LBL_00001", "챔피언") %></td>
		        <td class="tdBorder" align="left">
		            <table width="100%">
    		            <tr>
    		                <td  style="height:19px;" align="left" ><asp:Literal ID="ltrStgMapChamp" runat="server"></asp:Literal></td>
    		                <td align="right"  style="height: 19px">
    		                    <a href="#null" onclick="openFullStgMap();"><img alt="" src="../images/btn/scr_b01.gif" align="absmiddle" /></a>&nbsp;
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
  <tr valign="top">
    <td>
      <table cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
        <tr align="center">
	      <td>
            <iframe id="ifm" style=" overflow:auto; width:100%; height:100%;" frameborder="0" runat="server" ></iframe>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>

<asp:Literal ID="ltrScript" runat="server"></asp:Literal>

<%--<map name="stgmap" id="stgmap">
<area shape="rect" coords="555,55,645,75"   href="javascript:goDocument('usr2001.aspx?eid=1275');">
<area shape="rect" coords="555,76,645,96"   href="javascript:goDocument('usr2001.aspx?eid=1276');">
<area shape="rect" coords="907,196,991,206" href="javascript:goDocument('usr2001.aspx?eid=1285');">
<area shape="rect" coords="444,332,525,361" href="javascript:goDocument('usr2001.aspx?eid=1289');">
</map>	

<script>
function goDocument(urldata)
{
	document.location.href=urldata;
}
</script>--%>

<!--- MAIN END --->
</asp:Content>