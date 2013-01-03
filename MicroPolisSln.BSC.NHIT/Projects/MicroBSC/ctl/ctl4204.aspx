<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4204.aspx.cs" Inherits="ctl_ctl4204" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script  type="text/javascript">
function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    { 
       var cell     = igtbl_getElementById(id);
       var row      = igtbl_getRowById(id);
       var band     = igtbl_getBandById(id);
       var active   = igtbl_getActiveRow(id);
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
                 <td style="WIDTH: 100px" class="tableTitle">측정월</td>
                 <td class="tableContent"><asp:dropdownlist id="ddlMonthInfo" runat="server" CssClass="box01" OnSelectedIndexChanged="ddlMonthInfo_SelectedIndexChanged"></asp:dropdownlist></td>
                 <td style="WIDTH: 100px" class="tableTitle">조회</td>
                 <td class="tableContent"><asp:imagebutton id="imgBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" OnClick="imgBtnSearch_Click"></asp:imagebutton></td>
              </tr>
              </tbody>
      </table>
      <table cellpadding="0" cellspacing="0" border="0" width="100%" height="500px" style="height: 90%">
        <tr>
            <td height="30" valign="top" colspan="3">
            <br />
              <ig:UltraWebGrid ID="ugrdClose" runat="server" Height="320px" Width="100%" OnInitializeLayout="ugrdClose_InitializeLayout">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" HeaderText="KPI_CODE" Key="KPI_CODE" Width="50px">
                                    <Header Caption="KPI_CODE">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" HeaderText="KPI 명" Width="170px">
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="1" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" HeaderText="부서명" Width="60px">
                                    <Header Caption="부서명">
                                        <RowLayoutColumnInfo OriginX="2" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" HeaderText="챔피언명" Width="30px">
                                    <Header Caption="챔피언명">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MS_RESULT" Key="MS_RESULT" HeaderText="당월" Width="120px" Format="#,##0.####">
                                    <Header Caption="당월">
                                        <RowLayoutColumnInfo OriginX="4" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TS_RESULT" Key="TS_RESULT" HeaderText="누계" Width="120px" Format="#,##0.####">
                                    <Header Caption="누계">
                                        <RowLayoutColumnInfo OriginX="5" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CAL_MS_RESUTL" Key="CAL_MS_RESUTL" HeaderText="당월" Width="120px" Format="#,##0.####">
                                    <Header Caption="당월">
                                        <RowLayoutColumnInfo OriginX="6" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CAL_TS_RESULT" Key="CAL_TS_RESULT" HeaderText="누계" Width="120px" Format="#,##0.####">
                                    <Header Caption="누계">
                                        <RowLayoutColumnInfo OriginX="7" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MREASON" Key="MREASON" HeaderText="미적용사유" Width="80px" Hidden="True">
                                    <Header Caption="미적용사유">
                                        <RowLayoutColumnInfo OriginX="8" />
                                        
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="320px"
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
                        <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="showReason" />
                    </DisplayLayout>
                </ig:UltraWebGrid>
              <table class="tableBorder" cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tbody>
                    <tr height=10>
                        <td colspan=2>
                        </td>
                    </tr>
                     <tr>
                         <td style="WIDTH: 100px; text-align: center;" class="tableTitle">
                             산식미적용<br />
                             사유&nbsp;
                        </td>
                         <td class="tableContent">
                               <asp:textbox id="txtReason" runat="server" height="100px" textmode="MultiLine" width="100%"></asp:textbox>
                         </td>
                      </tr>
                      </tbody>
              </table>
                
            <asp:hiddenfield id="hdnTermID" runat="server"></asp:hiddenfield>
                <asp:hiddenfield id="hdnTermMM" runat="server"></asp:hiddenfield>
                
            </td>
          </tr>
        </table>
        &nbsp;&nbsp;
        <asp:literal id="ltlMsg" runat="server"></asp:literal>
<!--- MAIN END --->
</asp:Content>