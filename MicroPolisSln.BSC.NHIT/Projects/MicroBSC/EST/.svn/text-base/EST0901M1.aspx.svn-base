<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST0901M1.aspx.cs" Inherits="EST_EST0901M1" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
    <script>

    </script>

    <script id="igClientScript" type="text/javascript">
    <!--
        function ugrdResultTotal_AfterCellUpdateHandler(gridName, cellId) {	
            var row       = igtbl_getRowById(cellId);
            //row.getCellFromKey("ORGANIZATION_WEIGHT").setValue('Y');
            var weightSum = 0;
            
            weightSum += row.getCellFromKey("ORGANIZATION_WEIGHT").getValue();
            weightSum += row.getCellFromKey("APPRAISAL_WEIGHT").getValue();
            weightSum += row.getCellFromKey("OTHERS1_WEIGHT").getValue();
            weightSum += row.getCellFromKey("OTHERS2_WEIGHT").getValue();
            weightSum += row.getCellFromKey("OTHERS3_WEIGHT").getValue();
            
            row.getCellFromKey("WEIGHT_SUM").setValue(weightSum);
            
            var cell = igtbl_getCellById(row.getCellFromKey("WEIGHT_SUM").Id);
            if (weightSum != 100)
                cell.Element.style.color = "red";
            else
                cell.Element.style.color = "black";

        }

        function openStdDevSetting() {
            window.open("/EST/EST0901M1_01.aspx", "STDDEV", "height=600,width=500,resize=true");

            return false;
        }
    // -->
    </script>
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
                                                            <td colspan="2" align="right" bgcolor="white" > 
                                                                <asp:ImageButton ID="iBtnGrade" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_111.gif" OnClientClick="return openStdDevSetting();"  />
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
                                        <ig:UltraWebGrid ID="ugrdResultTotal" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdResultTotal_InitializeRow" OnInitializeLayout="ugrdResultTotal_InitializeLayout" EnableTheming="True" DisplayLayout-ViewType="Flat" DisplayLayout-SortingAlgorithmDefault="QuickSort" DisplayLayout-RowSelectorsDefault="Yes" DisplayLayout-CellClickActionDefault="Edit">
                                            <Bands>
                                                <ig:UltraGridBand>
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
                                                        <ig:UltraGridColumn BaseColumnName="EMP_CODE" EditorControlID=""
                                                            FooterText="" Format="" HeaderText="사번" Key="EMP_CODE" Width="70px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
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
                                                            FooterText="" Format="" HeaderText="이름" Key="EMP_NAME" Width="80px">
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
                                                        
                                                        <ig:UltraGridColumn NullText="0.00" BaseColumnName="ORGANIZATION_POINT" HeaderText="점수" Key="ORGANIZATION_POINT" Width="40px" DataType="System.Double" Format="#,##0.00">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="점수">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0" BaseColumnName="ORGANIZATION_WEIGHT" EditorControlID="" FooterText=""
                                                            HeaderText="가중치" Key="ORGANIZATION_WEIGHT" Width="40px" DataType="System.Int32" Format="#,##0" AllowUpdate="Yes">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="가중치">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0.00" BaseColumnName="APPRAISAL_POINT" HeaderText="점수" Key="APPRAISAL_POINT" Width="40px" DataType="System.Double" Format="#,##0.00" AllowUpdate="Yes">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="점수">
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0" BaseColumnName="APPRAISAL_WEIGHT" EditorControlID="" FooterText=""
                                                             DataType="System.Int32" Format="#,##0" AllowUpdate="Yes" HeaderText="가중치" Key="APPRAISAL_WEIGHT" Width="40px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="가중치">
                                                                <RowLayoutColumnInfo OriginX="9" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="9" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0.00" BaseColumnName="OTHERS1_POINT" HeaderText="점수" Key="OTHERS1_POINT" Width="40px" DataType="System.Double" Format="#,##0.00" AllowUpdate="Yes">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="점수">
                                                                <RowLayoutColumnInfo OriginX="10" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="10" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0" BaseColumnName="OTHERS1_WEIGHT" EditorControlID="" FooterText=""
                                                            DataType="System.Int32" Format="#,##0" AllowUpdate="Yes" HeaderText="가중치" Key="OTHERS1_WEIGHT" Width="40px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="가중치">
                                                                <RowLayoutColumnInfo OriginX="11" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="11" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0.00" BaseColumnName="OTHERS2_POINT" HeaderText="점수" Key="OTHERS2_POINT" Width="40px" DataType="System.Double" Format="#,##0.00" AllowUpdate="Yes">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="점수">
                                                                <RowLayoutColumnInfo OriginX="12" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="12" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0" BaseColumnName="OTHERS2_WEIGHT" EditorControlID="" FooterText=""
                                                            DataType="System.Int32" Format="#,##0" AllowUpdate="Yes" HeaderText="가중치" Key="OTHERS2_WEIGHT" Width="40px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="가중치">
                                                                <RowLayoutColumnInfo OriginX="13" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="13" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0.00" BaseColumnName="OTHERS3_POINT" HeaderText="점수" Key="OTHERS3_POINT" Width="40px" DataType="System.Double" Format="#,##0.00" AllowUpdate="Yes">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="점수">
                                                                <RowLayoutColumnInfo OriginX="14" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="14" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0" BaseColumnName="OTHERS3_WEIGHT" EditorControlID="" FooterText=""
                                                             DataType="System.Int32" Format="#,##0" AllowUpdate="Yes" HeaderText="가중치" Key="OTHERS3_WEIGHT" Width="40px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="가중치">
                                                                <RowLayoutColumnInfo OriginX="15" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="15" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0" BaseColumnName="WEIGHT_SUM" EditorControlID="" FooterText=""
                                                             DataType="System.Int32" Format="#,##0" HeaderText="가중치합" Key="WEIGHT_SUM" Width="60px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="가중치합">
                                                                <RowLayoutColumnInfo OriginX="16" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="16" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0" BaseColumnName="POINT_SUM" EditorControlID="" FooterText=""
                                                            DataType="System.Double" Format="#,##0.00" HeaderText="점수합" Key="POINT_SUM" Width="60px" Hidden="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="점수합">
                                                                <RowLayoutColumnInfo OriginX="17" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="17" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn NullText="0" BaseColumnName="STANDARD_SCORE" EditorControlID="" FooterText=""
                                                            Format="" HeaderText="표준점수" Key="STANDARD_SCORE" Width="60px" Hidden="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="표준점수">
                                                                <RowLayoutColumnInfo OriginX="18" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="18" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="STANDARD_RATING" EditorControlID="" FooterText=""
                                                            Format="" HeaderText="등급" Key="STANDARD_RATING" Width="60px" Hidden="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="등급">
                                                                <RowLayoutColumnInfo OriginX="19" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="19"/>
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                                            Format="" DataType="System.Int32" HeaderText="사번" Key="EMP_REF_ID" Width="0px" Hidden="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <Header Caption="사번">
                                                                <RowLayoutColumnInfo OriginX="20" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="20" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" HeaderText="부서코드" Width="0px" Hidden="true"
                                                            Key="EST_DEPT_REF_ID">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="부서코드">
                                                                <RowLayoutColumnInfo OriginX="21" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="21" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="POS_CLS_ID" HeaderText="직급코드" Width="0px" Hidden="true"
                                                            Key="POS_CLS_ID" DataType="System.String">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="직급코드">
                                                                <RowLayoutColumnInfo OriginX="22" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="23" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="POS_GRP_ID" HeaderText="직군코드" Width="0px" Hidden="true"
                                                            Key="POS_GRP_ID" DataType="System.String">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="직군코드">
                                                                <RowLayoutColumnInfo OriginX="24" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="24" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                    </Columns>
                                                    
                                                </ig:UltraGridBand>
                                            </Bands>
                                             <DisplayLayout CellClickActionDefault="Edit"
                                                AllowColSizingDefault="Free" 
                                                BorderCollapseDefault="Separate"
                                                RowSelectorsDefault="no"
                                                Name="ugrdResultTotal" 
                                                RowHeightDefault="20px" 
                                                Version="4.00"  
                                                StationaryMargins="HeaderAndFooter" 
                                                TableLayout="Fixed" 
                                                AutoGenerateColumns="False">
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
									    <ClientSideEvents AfterCellUpdateHandler="ugrdResultTotal_AfterCellUpdateHandler"/>
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
		                        </tr>
		                        <tr>
			                        <td height="40" align="right">
			                            <table>
			                                <tr>
			                                    <td height="40" align="right" valign="middle" style="width:"100%">
		                                            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
		                                            <asp:FileUpload ID="fldExcelFile" runat="server" Width="500px" CssClass="txt" />
		                                        </td>
		                                        <td height="40" align="right">
		                                            <asp:imagebutton ID="iBtnExcelImport" runat="server" imageurl="../images/btn/b_040.gif" onclick="iBtnExcelImport_Click" />
                                                    <asp:imagebutton id="iBtnExcelExport" imageurl="../images/btn/b_041.gif"  runat="server" onclick="iBtnExcelExport_Click" CommandName="BIZ_DOWN_EXCEL"></asp:imagebutton>
                                                    <asp:imagebutton ID="iBtnConfirm" runat="server" imageurl="../images/btn/b_tp07.gif" onclick="iBtnConfirm_Click" />
                                                </td>
                                            </tr>
                                        </table>
			                        </td>
		                        </tr>
		                    </table>
		                    <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server">
                            </ig:UltraWebGridExcelExporter>
                    </td>
                </tr>
        </table>
        <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>