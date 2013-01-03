<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST0901S1.aspx.cs" Inherits="EST_EST0901S1" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
    <div>	
        <%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
        <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
        <asp:literal runat="server" ID="ltrJScript"></asp:literal>
	    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
	        <tr valign="top">
		        <td width="30%">
		             <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
		                        <tr>
			                        <td height="20">
	                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
	                                        <tr>
	                                            <td class="tableoutBorder">
	                                                <table border="0" cellpadding="2" cellspacing="0" width="100%">
	                                                    <tr>
	                                                        <td width="60" class="tableTitle" align="center">평가기간&nbsp;</td>
                                                            <td style="width:200px;" class="tableContent">
                                                                <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" width="60%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                                                                <asp:dropdownlist id="ddlEstTermMonth" runat="server" class="box01" width="35%"></asp:dropdownlist>
                                                            </td>
                                                            <td width="60" class="tableTitle" align="center">직군&nbsp;</td>
                                                            <td style="width:200px;" class="tableContent">
                                                                <asp:dropdownlist id="ddlPositionGrp" runat="server" class="box01" width="100%"></asp:dropdownlist>
                                                            </td>
                                                            <td colspan="2" align="right" bgcolor="white" > 
                                                                <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif"
                                                                    OnClick="iBtnSearch_Click" />&nbsp</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="3px">
                                                </td>
                                            </tr>
                                         </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top; height:expression(eval(document.body.clientHeight)- 220); ">
                                        <ig:UltraWebGrid ID="ugrdResultTotal" runat="server" Width="100%" Height="100%" EnableTheming="True" DisplayLayout-ViewType="Flat" DisplayLayout-SortingAlgorithmDefault="QuickSort" DisplayLayout-RowSelectorsDefault="Yes" DisplayLayout-CellClickActionDefault="Edit">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <%--<ig:UltraGridColumn BaseColumnName="IDC" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="순위" Key="IDC" Width="70px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="순위">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>--%>
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="부서" Key="DEPT_NAME" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="부서">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="POS_CLS_NAME" HeaderText="직급"
                                                            Key="POS_CLS_NAME" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="직급">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_CODE" HeaderText="사번"
                                                            Key="EMP_CODE" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="사번">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="이름" Key="EMP_NAME" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="이름">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="STANDARD_SCORE" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="표준점수" Key="STANDARD_SCORE" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="표준점수">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right" >
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="STANDARD_RATING" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="등급" Key="STANDARD_RATING" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="등급">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                             <DisplayLayout CellClickActionDefault="Edit"
                                                BorderCollapseDefault="Separate"
                                                
                                                RowSelectorsDefault="no"
                                                Name="UltraWebGrid1" 
                                                RowHeightDefault="20px" 
                                                Version="4.00"  
                                                StationaryMargins="HeaderAndFooter" 
                                                TableLayout="Fixed" 
                                                AllowColSizingDefault="Free" 
                                                AutoGenerateColumns="False" ReadOnly="LevelTwo">
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                            <Padding Left="2px" />
                                        </RowStyleDefault>
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                            <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                        </HeaderStyleDefault> 
									    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
										    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
										    Width="100%">
									    </FrameStyle>									
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>
                                                </DisplayLayout>
                                        </ig:UltraWebGrid>
                                        
                                        <ig:UltraWebGrid ID="ugrdResultTotalDN" runat="server" Visible="false" Width="100%" Height="100%" EnableTheming="True" DisplayLayout-ViewType="Flat" DisplayLayout-SortingAlgorithmDefault="QuickSort" DisplayLayout-RowSelectorsDefault="Yes" DisplayLayout-CellClickActionDefault="Edit">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="부서" Key="DEPT_NAME" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="부서">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="POS_CLS_NAME" HeaderText="직급"
                                                            Key="POS_CLS_NAME" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="직급">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="POS_GRP_NAME" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="직군" Key="POS_GRP_NAME" Width="80PX">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="직군">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_CODE" HeaderText="사번"
                                                            Key="EMP_CODE" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="사번">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="이름" Key="EMP_NAME" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="이름">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="STANDARD_SCORE" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="표준점수" Key="STANDARD_SCORE" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="표준점수">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right" >
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="STANDARD_RATING" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="등급" Key="STANDARD_RATING" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="등급">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                             <DisplayLayout CellClickActionDefault="Edit"
                                                BorderCollapseDefault="Separate"
                                                RowSelectorsDefault="no"
                                                Name="UltraWebGrid1" 
                                                RowHeightDefault="20px" 
                                                Version="4.00"  
                                                StationaryMargins="HeaderAndFooter" 
                                                TableLayout="Fixed" 
                                                AllowColSizingDefault="Free" 
                                                AutoGenerateColumns="False" ReadOnly="LevelTwo">
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                            <Padding Left="2px" />
                                        </RowStyleDefault>
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                            <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                        </HeaderStyleDefault> 
									    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
										    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
										    Width="100%">
									    </FrameStyle>									
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>
                                                </DisplayLayout>
                                        </ig:UltraWebGrid>
                                        <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server">
                                        </ig:UltraWebGridExcelExporter>
                                    </td>
		                        </tr>
	                               <tr>
		                               <td align="right">
		                                  <table cellpadding="0" cellspacing="0" border="0" class="tableBorder">
	                                           <tr align="right">
	                                               <td class="tabletitle2" align="center" style="width:80px;">최대값</td>
		                                           <td class="tableContent"  style="width:100px;">
                                                      <ig:WebNumericEdit runat="server" ID="numMaxValue" Width="100%" Nullable="false" ReadOnly="true" MinDecimalPlaces="Two" />
                                                   </td>
                                                   <td class="tabletitle2" align="center" style="width:80px;">최소값</td>
		                                           <td class="tableContent"  style="width:100px;">
                                                      <ig:WebNumericEdit runat="server" ID="numMinValue" Width="100%" Nullable="false" ReadOnly="true" MinDecimalPlaces="Two" />
                                                   </td>
                                                   
		                                           <td class="tabletitle2" align="center" style="width:80px;">평균</td>
		                                           <td class="tableContent"  style="width:100px;">
                                                      <asp:Literal ID="ltGROUP_MEAN" runat="server"></asp:Literal>&nbsp;
                                                   </td>
		                                           <td class="tabletitle2" align="center"  style="width:80px;">표준편차</td>
		                                           <td class="tableContent"style="width:100px;">
                                                        <asp:Literal ID="ltSTANDARD_DEVIATION" runat="server"></asp:Literal>&nbsp;
                                                   </td>
	                                           </tr>
	                                       </table>
		                               </td>
	                               </tr>
		                        <tr>
			                        <td height="40" align="right">
		                                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                                        <asp:imagebutton id="iBtnExcelExport" imageurl="../images/btn/b_041.gif"  runat="server" onclick="iBtnExcelExport_Click" CommandName="BIZ_DOWN_EXCEL"></asp:imagebutton>
			                        </td>
		                        </tr>
		                    </table>
                    </td>
                </tr>
        </table>
        <ig:UltraWebGridExcelExporter ID="UltraWebGridExcelExporter1" runat="server"></ig:UltraWebGridExcelExporter>
        <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>