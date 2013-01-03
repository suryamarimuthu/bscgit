<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BiasManager.aspx.cs" Inherits="Resources_BiasManager" %>

<html>

    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
        <script type="text/javascript">
            function ttt() {
                if (document.getElementById('hdfChangeYN').value != "0")
                    opener.__doPostBack('<%= ICCB1 %>', '');
            }
        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onunload="ttt()">

<form id="form1" runat="server">

    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="2" style="width: 100%; height: 100%">
        <tr>
            <td style="height: 25px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="Bias 산식정의" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right">
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlBiasID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlBiasID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top;">
            <td valign="top" style="height: 100%;">
                <table cellpadding="0" cellspacing="0" style="height: 100%;" width="100%">
                    <tr>
                        <td style="height: 100%" valign="top">
                            <ig:UltraWebGrid id="ugrdResources" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
								<Bands>
									<ig:UltraGridBand>
										<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
									<RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
										<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
									</RowTemplateStyle>
									<Columns>                                    
                                        <ig:UltraGridColumn BaseColumnName="name" HeaderText="KEY" Type="Custom" Width="30%" Key="KEY">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </ig:UltraGridColumn>                                    
                                        <ig:UltraGridColumn BaseColumnName="value" HeaderText="VALUE" Type="Custom" Width="70%" AllowUpdate="NO" Key="VALUE">                                       
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="LEFT"></CellStyle>
                                        </ig:UltraGridColumn>                                 
                                    </Columns>
								</ig:UltraGridBand>
								</Bands>
								<DisplayLayout  CellPaddingDefault="2" 
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
								                AutoGenerateColumns="False"
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
								<HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
									<BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
								</HeaderStyleDefault>
								<EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
								<FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
								    BorderWidth="1px" Font-Names="Malgun Gothic" Font-Size="8.25pt" Height="100%" Width="100%">
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
								<SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
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
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table class="tableBorder" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td class="cssTblTitleSingle" width="120px">KEY</td> 
                                                <td class="cssTblContentSingle" colspan="3"> 
                                                    <asp:TextBox id="txtKey" runat="server" Width="100%" ></asp:TextBox>
                                                </td> 
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitleSingle" width="120px">VALUE</td> 
                                                <td class="cssTblContentSingle" colspan="3"> 
                                                     <asp:TextBox id="txtResources" runat="server" Width="100%" ></asp:TextBox>
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
        <tr>
            <td colspan="3" height="25px">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
							<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
							<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click"></asp:ImageButton>
                            <asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click"></asp:ImageButton>
                            <asp:HiddenField ID="hdfChangeYN" runat="server" Value="0" />
                            &nbsp;
                        </td>
                    </tr>
                </table></td>
        </tr>
    </table><asp:HiddenField ID="hdfScaleInfo" runat="server" />

<!--- MAIN END --->

	</div>
   <asp:literal id="ltrScript" runat="server"></asp:literal>

<script>    gfWinFocus();</script>
    <!--- MAIN END --->
    </form>
</body>
</html>