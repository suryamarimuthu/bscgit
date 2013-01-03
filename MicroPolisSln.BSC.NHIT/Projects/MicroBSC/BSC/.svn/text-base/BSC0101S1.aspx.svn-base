<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0101S1.aspx.cs" Inherits="BSC_BSC0101S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<%--<%Response.WriteFile("../_common/html/CommonTop.htm");%>--%>

    <script id="Infragistics" type="text/javascript">

//    function MouseOverHandler(gridName, id, objectType)
//    {
//    
//	    if(objectType == 0) 
//	    { // Are we over a cell
//           var cell = igtbl_getElementById(id);
//           cell.style.cursor = 'hand';
//        }

//    }
    
    function DblClickHandler(gridName, id) 
    {
        var cell     = igtbl_getElementById(id);
        var row      = igtbl_getRowById(id);
        var viewID   = row.getCellFromKey("VIEW_REF_ID").getValue();
        var viewYN   = row.getCellFromKey("USE_YN").getValue() =='Y'? 'U':'D';
        var ICCB1 = "<%= this.ICCB1 %>";

        gfOpenWindow('BSC0101M1.aspx?iType=' + viewYN  + '&VIEW_REF_ID='+ viewID +'&CCB1='+ICCB1, 650, 360);
    }

    function doPoppingUp_View(viewYN, viewID, ICCB1) {
      
      var popHeight = 340 + <%=POP_HEIGHT %>;
        gfOpenWindow('BSC0101M1.aspx?iType=' + viewYN
                                 + '&VIEW_REF_ID=' + viewID
                                 + '&CCB1=' + ICCB1
                                 , 650
                                 , popHeight);
    }
    
    
    function OpenInsertWindow()
    {
        var ICCB1 = "<%= this.ICCB1 %>";
        gfOpenWindow('BSC0101M1.aspx?iType=A&VIEW_REF_ID=0&CCB1='+ICCB1, 650, 380);
    }
    
</script>

 		<table style="height: 100%;">
		    <tr>
			    <td  valign="top" colspan="2"  style="height: 100%;">
		            <ig:UltraWebGrid ID="ugrdView" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdView_InitializeRow">
                        <Bands>
                            <ig:UltraGridBand>
                                <Columns>
                                    <ig:TemplatedColumn Hidden="True">
                                        <Header Caption="선택"></Header>
                                        <Footer Caption=""></Footer>
                                    </ig:TemplatedColumn>
                                    <ig:UltraGridColumn Key="VIEW_REF_ID" BaseColumnName="VIEW_REF_ID" Hidden="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="관점ID"><RowLayoutColumnInfo OriginX="1" /></Header>
                                        <Footer Caption=""><RowLayoutColumnInfo OriginX="1" /></Footer>
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn Key="VIEW_SEQ" BaseColumnName="VIEW_SEQ" Width="40px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="순서">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn Key="VIEW_NAME" BaseColumnName="VIEW_NAME" Width="150px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="관점명"><RowLayoutColumnInfo OriginX="3" /></Header>
                                        <Footer Caption=""><RowLayoutColumnInfo OriginX="3" /></Footer>
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </ig:UltraGridColumn>
                                    <ig:TemplatedColumn Key="USE_YN" BaseColumnName="USE_YN" Width="35px">
                                      <Header Caption="사용">
                                        <RowLayoutColumnInfo OriginX="4" />
                                      </Header>
                                      <HeaderStyle Wrap="true" HorizontalAlign="Center"/>
                                      <CellStyle HorizontalAlign="Center"></CellStyle>
                                      <CellTemplate>
                                        <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                      </CellTemplate>
                                      <Footer Caption=""><RowLayoutColumnInfo OriginX="4" /></Footer>
                                    </ig:TemplatedColumn>
                                    <ig:UltraGridColumn Key="VIEW_DESC" BaseColumnName="VIEW_DESC" Width="240px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="관점 설명"><RowLayoutColumnInfo OriginX="5" /></Header>
                                        <Footer Caption=""><RowLayoutColumnInfo OriginX="5" /></Footer>
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn Key="VIEW_ETC" BaseColumnName="VIEW_ETC" Width="300px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="비고"><RowLayoutColumnInfo OriginX="6" /></Header>
                                        <Footer Caption=""><RowLayoutColumnInfo OriginX="6" /></Footer>
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </ig:UltraGridColumn>
                                </Columns>
                            </ig:UltraGridBand>
                        </Bands>
                        <DisplayLayout  Name="ugrdView" 
                                        Version="4.00"  
                                        CellPaddingDefault="2" 
                                        AllowColSizingDefault="Free" 
                                        BorderCollapseDefault="Separate" 
                                        AutoGenerateColumns="False"
                                        HeaderClickActionDefault="SortMulti" 
                                        RowHeightDefault="20px"
                                        RowSelectorsDefault="No" 
                                        SelectTypeRowDefault="Single" 
                                        CellClickActionDefault="RowSelect" 
                                        TableLayout="Fixed" 
                                        ReadOnly="LevelTwo"
                                        StationaryMargins="Header">
                               <%-- <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                </FooterStyleDefault>
                                <RowAlternateStyleDefault BackColor="#F9F9F7">
                                    <BorderDetails  ColorLeft="249, 249, 247" ColorTop="249, 249, 247" />
                                </RowAlternateStyleDefault>
                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                    <Padding Left="3px" />
                                </RowStyleDefault>
                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                </EditCellStyleDefault>
                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Cursor="Hand"
                                    Width="100%">
                                </FrameStyle>
                                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>--%>
                                
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                <%--<ClientSideEvents DblClickHandler="DblClickHandler"/>--%>
                                <Images>
	                                <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
	                                <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                </Images>
                            </DisplayLayout>
                    </ig:UltraWebGrid>
                </td>
		    </tr>
		    <tr>
			    <td style="height:25px;">
			        <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click" Visible="false">iBtn</asp:linkbutton>
			    </td>
			    <td align="right">
			        <div id='divAdd' runat="server">
			            <img alt="" src="../images/btn/b_005.gif" style="cursor:hand;" onclick="OpenInsertWindow();" />
			        </div>
			    </td>
		    </tr>
		</table>
 </asp:Content>
