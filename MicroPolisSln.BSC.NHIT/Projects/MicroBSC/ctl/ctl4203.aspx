<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4203.aspx.cs" Inherits="ctl_ctl4203" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script  type="text/javascript">
function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    { // Are we over a cell
       var cell         = igtbl_getElementById(id);
       var row          = igtbl_getRowById(id);
       var band         = igtbl_getBandById(id);
       var active       = igtbl_getActiveRow(id);
       cell.style.cursor = 'hand';
    }
}

function showReason(gridName, cellId)
{
    var row = igtbl_getRowById(cellId);
    document.form2.txtReason.value = row.getCellFromKey("MREASON").getValue();
}
</script>

      <table class="tableBorder" cellSpacing=0 cellPadding=0 width="100%" border=0>
          <tbody>
             <tr>
                 <td style="WIDTH: 100px" class="tableTitle">성과 평가 기간</td>
                 <td class="tableContent"><asp:dropdownlist id="ddlEstTermInfo" runat="server" CssClass="box01"></asp:dropdownlist></td>
                 <td style="WIDTH: 100px" class="tableTitle">KPI 코드</td>
                 <td class="tableContent">
                     <asp:textbox id="txtSKpiCode" runat="server"></asp:textbox>
                 </td>
                 <td style="WIDTH: 100px" class="tableTitle">KPI명</td>
                 <td class="tableContent">
                     <asp:textbox id="txtSKpiName" runat="server"></asp:textbox>
                 </td>
                 <td class="tableContent" style="width: 81px"><asp:imagebutton id="imgBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" OnClick="imgBtnSearch_Click"></asp:imagebutton></td>
              </tr>
              </tbody>
      </table>
      <br />
      <table cellpadding="0" cellspacing="0" border="0" width="100%" height="500px" style="height: 90%">
        <tr>
            <td valign="top" colspan="3" style="height: 30px">
              <ig:UltraWebGrid ID="ugrdClose" runat="server" Height="100%" Width="100%" OnInitializeLayout="ugrdClose_InitializeLayout" OnDblClick="ugrdClose_DblClick" OnClick="ugrdClose_Click">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" HeaderText="CODE" Key="KPI_CODE" Width="50px">
                                    <Header Caption="CODE">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" HeaderText="KPI 명" Width="190px">
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="1" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" HeaderText="KPI_REF_ID" Width="100px" Hidden="True">
                                    <Header Caption="KPI_REF_ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="SortMulti" Name="ugrdClose" RowHeightDefault="20px" SelectTypeRowDefault="Extended" Version="4.00" AutoGenerateColumns="False" CellClickActionDefault="RowSelect" RowSelectorsDefault="No">
                        <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                        Width="100%">
                    </FrameStyle>
                    <Pager>
                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </Style>
                    </Pager>
                    <AddNewBox Hidden="False">
                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                              <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </Style>
                    </AddNewBox>
                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                    </SelectedRowStyleDefault>
                        <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                    </DisplayLayout>
                </ig:UltraWebGrid>
                
            </td>
            <td colspan="1" style="height: 30px" valign="top">
                <table cellpadding = "0" cellspacing = "0">
                    <tr>
                        <td style="width: 100px" class="tableTitle">KPI 명</td>
                        <td style="width: 100px">
                            <asp:textbox id="txtKPIName" runat="server" Width="500px"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tableTitle">QUERY GRID</td>
                        <td style="width: 100px">
                            <asp:textbox id="txtQRY_DATA" runat="server" height="120px" textmode="MultiLine" width="500px"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tableTitle">QUERY MONTHLY SUM</td>
                        <td style="width: 100px">
                            <asp:textbox id="txtQRY_MS" runat="server" height="120px" textmode="MultiLine" width="500px"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tableTitle">QUERY TOTAL SUM</td>
                        <td style="width: 100px">
                            <asp:textbox id="txtQRY_TS" runat="server" height="120px" textmode="MultiLine" width="500px"></asp:textbox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
          <tr>
              <td colspan="3" valign="top" height="40">
                  <asp:hiddenfield id="hdnTermID" runat="server"></asp:hiddenfield>
                  <asp:hiddenfield id="hdnKpiRefID" runat="server"></asp:hiddenfield>
              </td>
              <td colspan="1" valign="middle" align="right">
                  <asp:imagebutton id="imgBtnUpdate" runat="server" imageurl="../images/btn/b_002.gif" OnClick="imgBtnUpdate_Click"></asp:imagebutton>
              </td>
          </tr>
        </table>
        &nbsp;&nbsp;
        <asp:literal id="ltlMsg" runat="server"></asp:literal>
</asp:Content>
    