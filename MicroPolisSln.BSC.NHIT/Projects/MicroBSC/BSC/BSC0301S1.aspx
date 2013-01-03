<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0301S1.aspx.cs" Inherits="BSC_BSC0301S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
   <script id="Infragistics" type="text/javascript">

    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) { 
           
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);
           var termName         = row.getCellFromKey("KPI_NAME").getValue();
           
           cell.style.cursor    = 'hand';
        }
    }
    
    function ugrdKPIPool_DblClickHandler(gridName, cellId)
    {
        var cell    = igtbl_getElementById(cellId);
        var row     = igtbl_getRowById(cellId);
        var kpiID   = row.getCellFromKey("KPI_POOL_REF_ID").getValue();
        var kpiYN   = row.getCellFromKey("USE_YN").getValue() =='Y'? 'U':'D';
       
        
        var ICCB1 = "<%= this.ICCB1 %>";
        
        var strURL = 'BSC0301M1.aspx?iType=' + kpiYN + '&KPI_POOL_REF_ID='+ kpiID+'&CCB1='+ICCB1;
        gfOpenWindow(strURL, 720, 670,"BSC0301M1");
    }
    
    function OpenInsertWindow()
    {
        var kpiID  = '';
        var ICCB1 = "<%= this.ICCB1 %>";
        
        var strURL = 'BSC0301M1.aspx?iType=A&KPI_POOL_REF_ID='+ kpiID+'&CCB1='+ICCB1;
        gfOpenWindow(strURL, 720, 670, 'BSC0301M1');
        
        return false;
    }
    </script>   

<!--- MAIN START --->	
		<table cellpadding="0" cellspacing="0" border="0"  Width="100%" style="height:100%;">
		    <tr valign="top">
			    <td colspan="2">
                    <table class="tableBorder" cellpadding="0" cellspacing="0" border="0"  Width="100%">
                        <tr>
                            <td class="cssTblTitle">KPI 명</td>
                            <td class="cssTblContent">
                                <asp:TextBox ID="txtKPIName" runat="server" width="100%"></asp:TextBox>
                            </td>
                            <td class="cssTblTitle">KPI 유형</td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlKpiType" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle">사용여부</td>
                            <td class="cssTblContent" style="border-right:none;">
                                <asp:dropdownlist runat="server" id="ddlUseYn" Width="99%" CssClass="box01"></asp:dropdownlist>
                            </td>	
                            <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                            <td class="cssTblContent">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="cssPopBtnLine">
                <td align="left">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left" width="110">
                                <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                    <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
                </td>
                <td align="right">
                    <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                </td>
            </tr>
            <tr style="height:100%;">
                <td valign="top" colspan="2" >
		            <ig:UltraWebGrid ID="ugrdKPIPool" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKPIPool_InitializeRow" >
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <Columns>
                                    <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" EditorControlID="" FooterText=""
                                        Format="" HeaderText="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" Width="100px" Hidden="true">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="KPI_POOL_REF_ID">
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="230px">
                                        <Header Caption="KPI 명">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_EXTERNAL_TYPE_NAME" Key="KPI_EXTERNAL_TYPE_NAME" Width="70px">
                                        <Header Caption="KPI 구분">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="70px">
                                        <Header Caption="KPI 유형">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부">
                                      <Header Caption="사용여부">
                                        <RowLayoutColumnInfo OriginX="5" />
                                      </Header>
                                      <HeaderStyle Wrap="True" />
                                      <CellStyle HorizontalAlign="Center"></CellStyle>
                                      <CellTemplate>
                                        <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                      </CellTemplate>
                                      <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                      </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_DESC" HeaderText="KPI 설명" Key="KPI_DESC" Width="380px">
                                        <Header Caption="KPI 설명">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                </Columns>
                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                </RowTemplateStyle>
                            </ig:UltraGridBand>
                        </Bands>
                         <DisplayLayout CellPaddingDefault="2"
                                        AllowColSizingDefault="Free"
                                        AllowColumnMovingDefault="OnServer"
                                        AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes"
                                        BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="SortMulti"
                                        Name="ugrdKPIPool"
                                        RowHeightDefault="20px"
                                        RowSelectorsDefault="No"
                                        SelectTypeRowDefault="Extended"
                                        Version="4.00"
                                        ViewType="OutlookGroupBy"
                                        CellClickActionDefault="RowSelect"
                                        TableLayout="Fixed"
                                        StationaryMargins="Header"
                                        AutoGenerateColumns="False"
                                        OptimizeCSSClassNamesOutput="False">
                            <%--
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
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                            </SelectedRowStyleDefault>--%>
                            
                            <GroupByBox>
                                <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                            <RowStyleDefault  CssClass="GridRowStyle" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                            <ClientSideEvents DblClickHandler="ugrdKPIPool_DblClickHandler" />
                            </DisplayLayout>
                    </ig:UltraWebGrid>
		        </td>
		    </tr>
		    <tr style="height:25px;">
			    <td colspan="2" align="right">
                    <asp:ImageButton runat="server" ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif" ImageAlign="AbsMiddle" OnClientClick="return OpenInsertWindow();" />
			    </td>
		    </tr>
		</table>
	 <asp:Literal ID="ltrScript" runat="server"></asp:Literal>

  <!--- MAIN END --->
</asp:Content>