<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0103S1.aspx.cs" Inherits="PRJ_PRJ0103S1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>BSC</title>
            <meta http-equiv="Content-Type" content="text/html; " />
            <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/jscript" language="JavaScript" src="../_common/js/common.js"></script>
        <script id="Infragistics" type="text/javascript">
<!--
    function MouseOverHandler(gridName, id, objectType)
    {
	   if(objectType == 0) 
	    {
           var cell = igtbl_getElementById(id);
           var row = igtbl_getRowById(id);
           var band = igtbl_getBandById(id);
           var active = igtbl_getActiveRow(id);
           cell.style.cursor = 'hand';
       }
    }
    
   

        // -->
        </script>
            </head>
                <body style="margin:0 0 0 0 ; background-color:#FFFFFF">
                    <form id="form1" runat="server">
                    <!--- MAIN START --->	
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr> 
                                                    <td height="40" valign="top"><img src="../images/title/popup_t23.gif"></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td width="50%" height="4" bgcolor="#FFFFFF"></td>
                                                    <td width="50%" bgcolor="#FFFFFF"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                          </tr>
                        </table>
                    <center>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr class="cssPopContent" valign=top>
                <td width="250">
	                <div class="cssDivLayout" style=" width: 240; height: 300">
                        <asp:TreeView ID="TreeView1" runat="server"
                         OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ImageSet="XPFileExplorer" NodeIndent="15">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                            VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </div>
	            </td>
	            <td style="height:300PX;>
	                <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" ImageDirectory="" OnDblClick="UltraWebGrid1_DblClick"><Bands>
                        <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                    <Columns>
                        <ig:UltraGridColumn FooterText="" HeaderText="선택" Key="SELECT" Width="40px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                            </CellStyle>
                            <Header Caption="선택" Title="">
                            </Header>
                            <Footer Caption="" Title="">
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EMP_CODE" HeaderText="사번" Key="EMP_CODE" Width="80px">
                            <Header Caption="사번">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" HeaderText="사번" Hidden="True"
                            Key="EMP_REF_ID" Width="60px">
                            <Header Caption="사번">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                            </CellStyle>
                            <Header Caption="성명">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME"
                            Width="150px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                            </CellStyle>
                            <Header Caption="부서">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POSITION_NAME" HeaderText="직책" Key="POSITION_NAME">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                            </CellStyle>
                            <Header Caption="직책">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" HeaderText="deptid" Hidden="True"
                            Key="DEPT_REF_ID">
                            <Header Caption="deptid">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POSITION_ID" HeaderText="jobcode" Hidden="True"
                            Key="POSITION_ID">
                            <Header Caption="jobcode">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DAILY_PHONE" HeaderText="DAILY_PHONE" Hidden="True"
                            Key="DAILY_PHONE">
                            <Header Caption="DAILY_PHONE">
                                <RowLayoutColumnInfo OriginX="8" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="8" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="CELL_PHONE" HeaderText="CELL_PHONE" Hidden="True"
                            Key="CELL_PHONE">
                            <Header Caption="CELL_PHONE">
                                <RowLayoutColumnInfo OriginX="9" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EMP_EMail" HeaderText="EMP_EMail" Hidden="True"
                            Key="EMP_EMail">
                            <Header Caption="EMP_EMail">
                                <RowLayoutColumnInfo OriginX="10" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="10" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_CODE" Hidden="True" Key="DEPT_CODE">
                            <Header>
                                <RowLayoutColumnInfo OriginX="11" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="11" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                </ig:UltraGridBand>
                </Bands>

                <DisplayLayout Version="4.00"
                               AllowSortingDefault="Yes" 
                               AllowColSizingDefault="Free" 
                               HeaderClickActionDefault="SortMulti"
                               Name="UltraWebGrid1" 
                               BorderCollapseDefault="Separate" 
                               AllowDeleteDefault="Yes"
                               RowSelectorsDefault="No" 
                               RowHeightDefault="20px" 
                               AllowColumnMovingDefault="OnServer"
                               SelectTypeRowDefault="Single" 
                               AutoGenerateColumns="False" 
                               CellClickActionDefault="RowSelect"
                               SelectTypeCellDefault="Single" 
                               SelectTypeColDefault="Single" 
                               StationaryMargins="Header"
                               StationaryMarginsOutlookGroupBy="True" 
                               OptimizeCSSClassNamesOutput="False"
                               TableLayout="Fixed">
                    <%--<GroupByBox>
                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                        <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorTop="White" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                        <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                        BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="300px"
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
                    <ClientSideEvents />
                    <Images ImageDirectory="">
                    </Images>
                    <ActivationObject BorderColor="" BorderWidth="">
                    </ActivationObject>--%>
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
            </ig:ultrawebgrid>
	    </td>
    </tr>
</table>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="cssPopBtnLine">
		   <a href="javascript:window.close();"><img alt="" src="../images/btn/b_003.gif" border="0" /></a>
		   <asp:HiddenField ID="hdfObjKey" runat="server" />
		   <asp:HiddenField ID="hdfObjVal" runat="server" />
		   <asp:HiddenField ID="hdfType" runat="server" />
		    <asp:HiddenField ID="hdfValue5" runat="server" />
            <asp:HiddenField ID="hdfValue2" runat="server" />
            <asp:HiddenField ID="hdfValue3" runat="server" />
            <asp:HiddenField ID="hdfValue4" runat="server" />
            <asp:HiddenField ID="hdfValue1" runat="server" />
            <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr> 
                    <td width="50%" height="4" bgcolor="#FFFFFF"></td>
                    <td width="50%" bgcolor="#FFFFFF"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</center>
</form>
</body>
</html>