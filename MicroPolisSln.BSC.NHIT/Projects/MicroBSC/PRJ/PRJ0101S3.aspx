<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0101S3.aspx.cs" Inherits="PRJ_PRJ0101S3" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
    <script id="Infragistics" type="text/javascript">
    
     function openKpiInfo(estterm_ref_id,kpiID)
    {
        var url             = '../BSC/BSC0302M1.aspx?iType=S&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID;
        gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
    }
    
   

    function ugrdPrjList_DblClickHandler(gridName, cellId)
    {
//        var cell            = igtbl_getElementById(cellId);
//        var row             = igtbl_getRowById(cellId);
//        var prjID           = row.getCellFromKey("PRJ_REF_ID").getValue();
//        var prjType         = row.getCellFromKey("PRJ_TYPE").getValue();

//        var url             = 'PRJ0102S3.ASPX?PAGE_TYPE=P&PRJ_REF_ID=' + prjID+'&PRJ_TYPE='+prjType ;
//        gfOpenWindow(url, 840, 520, 'yes', 'no', 'PRJ0102S3');
    }
    
   
</script>

		<table cellpadding="0" cellspacing="0" border="0"  style="width:100%; height:100%;" >
		    <tr valign="top" style="height: 60px">
                <td style="height: 60px">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tbody>
                        <tr>
                          <td>
                            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                              <tbody>
                                <tr>
                                  <td class="cssTblTitle">사업유형&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:dropdownlist id="ddlPrjType" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                  </td>
                                  <td class="cssTblTitle">사업 CODE&nbsp;</td>
                                  <td class="cssTblContent"><asp:TextBox id="txtPrjCode" runat="server" width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle">사업명&nbsp;</td>
                                  <td class="cssTblContent"><asp:TextBox id="txtPrjName" runat="server" width="100%"></asp:TextBox></td>
                                  <td class="cssTblTitle">
                                      평가기간&nbsp;</td>
                                  <td class="cssTblContent">
                                      <asp:DropDownList ID="ddlEstTermInfo" runat="server" class="box01" Width="100%">
                                      </asp:DropDownList>
                                  </td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle">평가부서&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:dropdownlist id="ddlEstDept" class="box01" runat="server" width="100%"></asp:dropdownlist></td>
                                  <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                  <td class="cssTblContent">&nbsp;</td>
                                </tr>
                              </tbody>
                            </table>
                          </td>
                        </tr>
                        <tr style="height:25px;">
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                            <img align="absmiddle" src="../Images/etc/lis_t02.gif" />
                                        </td>
                                        <td align="right">
                                          <asp:ImageButton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>                            
                        </tr>
                      </tbody>
                    </table>
                </td>
        </tr>
        <tr>
            <td valign="top" >
                <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdPrjList_InitializeRow" OnInitializeLayout="ugrdPrjList_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn HeaderText="Column 0" Hidden="True">
                                    <Header Caption="Column 0">
                                    </Header>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                     <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="NotSet" Name="ugrdPrjList" RowHeightDefault="22px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False" UseFixedHeaders="True"
                            OptimizeCSSClassNamesOutput="False">
                            
                        <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
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
                        
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                        <ClientSideEvents DblClickHandler="ugrdPrjList_DblClickHandler" />
                    </DisplayLayout>
                </ig:UltraWebGrid>
                <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server">
                </ig:UltraWebGridExcelExporter>
		    </td>
		</tr>
		<tr style="height:25px;">
			<td align="right">
                <asp:ImageButton ID="ibnDownExcel" runat="server" CommandName="BIZ_DOWN_EXCEL" ImageUrl="~/images/btn/b_041.gif"
                    OnClick="ibnDownExcel_Click" Visible="False" />&nbsp;
			</td>
		</tr>
	  </table>
	<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>