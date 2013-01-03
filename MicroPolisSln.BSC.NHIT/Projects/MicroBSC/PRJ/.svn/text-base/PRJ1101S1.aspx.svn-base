<%@ Page Title="" Language="C#" MasterPageFile="~/_common/lib/MicroBSC.master" AutoEventWireup="true" CodeFile="PRJ1101S1.aspx.cs" Inherits="PRJ_PRJ1101S1" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">

    function MouseOverHandler(gridName, id, objectType) {
        if (objectType == 0) {

            var cell = igtbl_getElementById(id);
            var row = igtbl_getRowById(id);
            var band = igtbl_getBandById(id);
            var active = igtbl_getActiveRow(id);
            var termName = row.getCellFromKey("WORK_NAME").getValue();

            cell.style.cursor = 'hand';
        }
    }

    function ugrdWorkPool_DblClickHandler() {
        var ugrd = igtbl_getGridById('<%= ugrdWorkPool.ClientID %>');
        var Row = igtbl_getActiveRow(ugrd.Id);
        var workID = Row.getCellFromKey("WORK_POOL_REF_ID").getValue();
        

        var workYN = row.getCellFromKey("USE_YN").getValue() == 'Y' ? 'U' : 'D';


        var ICCB1 = "<%= this.ICCB1 %>";

        var strURL = 'PRJ1101M1.aspx?iType=' + workYN + '&WORK_POOL_REF_ID=' + workID + '&CCB1=' + ICCB1;
        gfOpenWindow(strURL, 720, 600,"yes","no", "PRJ1101M1");
    }

    function OpenInsertWindow() {
        var workID = '';
        var ICCB1 = "<%= this.ICCB1 %>";

        var strURL = 'PRJ1101M1.aspx?iType=A&WORK_POOL_REF_ID=' + workID + '&CCB1=' + ICCB1;
        gfOpenWindow(strURL, 720, 600, "yes", "no", 'PRJ1101M1');

        return false;
    }
</script>   

<!--- MAIN START --->	
    <table cellpadding="0" cellspacing="2" border="0" style="width:100%; height:100%;">
	    <tr valign="top" style="height: 20px">
		    <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" >
                    <tr>
                        <td class="tableBorder">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td width="80" class="tableTitle" align="center">중점과제 명</td>
                                    <td width="120" class="tableContent">
                                        <asp:TextBox ID="txtWorkName" runat="server" width="100%"></asp:TextBox>
                                    </td>
                                    <td width="80" class="tableTitle" align="center">중점과제 유형</td>
                                    <td width="120" class="tableContent">
                                        <asp:DropDownList ID="ddlWorkType" runat="server" CssClass="box01" />
                                    </td>
                                    <td width="80" class="tableTitle" align="center">사용여부</td>
                                    <td  class="tableContent">
                                        <asp:dropdownlist runat="server" id="ddlUseYn" CssClass="box01"></asp:dropdownlist>
                                        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" Height="19px" ImageUrl="../images/btn/b_033.gif"
                                            OnClick="iBtnSearch_Click" />
                                    </td>	
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right" visible="false"></td>
        </tr>
        <tr>
            <td valign="top" colspan="2" >
		        <ig:UltraWebGrid ID="ugrdWorkPool" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdWorkPool_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="WORK_POOL_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="WORK_POOL_REF_ID" Key="WORK_POOL_REF_ID" Width="100px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="WORK_POOL_REF_ID">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WORK_NAME" Key="WORK_NAME" Width="250px">
                                    <Header Caption="중점과제 명">
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
                                
                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="70px" FooterText="" HeaderText="사용여부">
                                  <Header Caption="사용여부">
                                    <RowLayoutColumnInfo OriginX="6" />
                                  </Header>
                                  <HeaderStyle Wrap="True" />
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                  <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="6" />
                                  </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="WORK_DESC" HeaderText="중점과제 설명" Key="WORK_DESC" Width="400px">
                                    <Header Caption="중점과제 설명">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
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
                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="SortMulti" Name="ugrdWorkPool" RowHeightDefault="20px"
                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect"
                        TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                        <GroupByBox>
                            <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
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
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="25px">
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
                        </SelectedRowStyleDefault>
                        <ClientSideEvents DblClickHandler="ugrdWorkPool_DblClickHandler"  MouseOverHandler="MouseOverHandler"  />
                    </DisplayLayout>
                </ig:UltraWebGrid>
		    </td>
		</tr>
		<tr>
            <td align="left" style="height: 25px">
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
                <asp:ImageButton runat="server" ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif" ImageAlign="AbsMiddle" OnClientClick="return OpenInsertWindow();" />
			</td>
		</tr>
	</table>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>

<!--- MAIN END --->
</asp:Content>