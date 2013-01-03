<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST050200.aspx.cs" Inherits="EST_EST050200" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>


<body>
<form id="form1" runat="server">
<script type="text/javascript">
    function sendMail() {
        if (document.getElementById('hdfEstID').value == "") {
            alert('안내메일을 발송할 평가유형을 선택하세요!');
            return false;
        }
        return confirm('현재 평가에 대한 안내메일을 발송하시겠습니까?');
    }
    
    function isValid() {
        var oGrid = igtbl_getGridById('UltraWebGrid1');
        var cnt = oGrid.Rows.length;
        for (var i = 0; i < cnt; i++) {
            var oRow = oGrid.Rows.getRow(i);
            var oCell = oRow.getCellFromKey("STATUS_YN");
            if (oCell.getValue() != null) {
                if (oRow.getCellFromKey("START_DATE").getValue() == null || oRow.getCellFromKey("END_DATE").getValue() == null) {
                    var oName = oRow.getCellFromKey("EST_JOB_NAME").getValue();
                    alert("[" + oName + "]" + "의 시작일자와 종료일자를 확인하세요.");
                    return false;
                }
            }
        }
    }
    
    // ie 9 에러 때문..
    function igtbl_removeState(stateNode) {
        if (!stateNode || !stateNode.childNodes)
            return;
        while (stateNode.childNodes.length > 0)
            igtbl_removeState(stateNode.childNodes[0]);
        if (stateNode.parentNode) {
            if (typeof (stateNode.parentNode.removeChild) != "undefined")
                stateNode.parentNode.removeChild(stateNode); // IE
            else
                stateNode.parentNode.removeNode(stateNode); // Firefox
        }
        // removeNode isn't enough to make the node deallocate in IE
        if (typeof (stateNode.outerHTML) != "undefined")
            stateNode.outerHTML = "";
    }

    igtbl_StateChange.prototype.init = function(type, grid, obj, value) {
        //alert(igtbl_StateChange.base);
        //alert(igtbl_StateChange.base.init);
        igtbl_StateChange.base.init.apply(this, [type]);
        this.Node = ig_ClientState.addNode(grid.StateChanges, "StateChange");

        this.Grid = grid;
        this.Object = obj;
        ig_ClientState.setPropertyValue(this.Node, "Type", this.Type);
        if (typeof (value) != "undefined" && value != null) {
            if (value == "" && typeof (value) == "string") value = "\x01";
            ig_ClientState.setPropertyValue(this.Node, "Value", value);
        }
        if (obj) {
            if (obj.getLevel)
                ig_ClientState.setPropertyValue(this.Node, "Level", obj.getLevel(true));
            var dataKey = null;
            if (obj.Type == "row" || obj.Type == "cell" || obj.Type == "rows") {
                var row = obj;
                if (obj.Type == "cell")
                    row = obj.Row;
                else if (obj.Type == "rows")
                    row = obj.ParentRow;
                if (row) {
                    dataKey = (row.DataKey ? row.DataKey : "");
                    while (row.ParentRow) {
                        row = row.ParentRow;
                        dataKey = (row.DataKey ? row.DataKey : "") + "\x04" + dataKey;
                    }
                }
            }
            if (dataKey)
                ig_ClientState.setPropertyValue(this.Node, "DataKey", dataKey);
            if (this.Object._Changes[this.Type]) {
                var ch = this.Object._Changes[this.Type];
                if (!ch.length)
                    ch = new Array(ch);
                this.Object._Changes[this.Type] = ch.concat(this);
            }
            else
                this.Object._Changes[this.Type] = this;
        }
    }

    function igtbl_dispose(obj) {
        if (ig_csom.IsNetscape || ig_csom.IsNetscape6)
            return;
        for (var item in obj) {
            //if(typeof(obj[item])!="undefined" && obj[item]!=null && !obj[item].tagName && !obj[item].disposing && typeof(obj[item])!="string")
            if (typeof (obj[item]) != "undefined" && obj[item] != null && !obj[item].tagName && !obj[item].disposing && typeof (obj[item]) != "string" && obj.hasOwnProperty(item)) {
                try {

                    obj[item].disposing = true;
                    igtbl_dispose(obj[item]);
                } catch (exc1) { ; }
            }
            try {
                delete obj[item];
            } catch (exc2) {
                return;
            }
        }
    }
    //IE9오류 끝
</script>

<script id="igClientScript" type="text/javascript">
<!--

function UltraWebGrid1_AfterCellUpdateHandler(gridName, cellId)
{	
    var row       = igtbl_getRowById(cellId);
    row.getCellFromKey("UPDATE_YN").setValue('Y');
}
// -->
</script>
<div>
	
<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td>
                <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="cssTblTitle">평가기간</td>
                        <td class="cssTblContent" style="border-right:none;">
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermRefID_SelectedIndexChanged"></asp:dropdownlist>
							<asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged"></asp:dropdownlist>
							<asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;							
                        </td>
                        <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                        <td class="cssTblContent">&nbsp;</td>
                    </tr>
				</table>
				
            </td>
        </tr>		
        <tr style="vertical-align: top; height:100%; ">
            <td>
                <table cellpadding="0" cellspacing="0" height="100%" width="100%">                    
                    <%--<tr>
                        <td style="width:20%; height: 20">
                        </td>
                        <td style="width:2%">
                        </td>
                        <td style="width:78%">
                            <img align="absmiddle" src='../Images/etc/lis_t01.gif' />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img align="absmiddle" src='../Images/etc/lis_t02.gif' />
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="vertical-align: top; width:25%; height: 100%">
                            <div id="leftLayer" class="cssDivLayout">
								<asp:TreeView ID="TreeView1" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" runat="server"  Font-Names="Dotum" Font-Size="8pt" ImageSet="XPFileExplorer" ShowLines="False" NodeIndent="15">
								    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
									<ParentNodeStyle Font-Bold="False" />
								</asp:TreeView>
                            </div>
                        </td>
                        <td style="width:5px; height: 100%">
                        </td>
                        <td style="vertical-align: top; height:expression(eval(document.body.clientHeight) - 310);">
                            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" OnInitializeRow="UltraWebGrid1_InitializeRow">
								<Bands>
									<ig:UltraGridBand>										
									    <Columns>    
									        <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="ESTTERM_STEP_ID" HeaderText="차수" Key="STEP_ID" Type="DropDownList" Width="40px" Hidden="true">
                                                <ValueList>
                                                    <Style Font-Size="XX-Small"></Style>
                                                </ValueList>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="차수">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>                                                         
                                            <ig:UltraGridColumn BaseColumnName="EST_JOB_NAME" Key="EST_JOB_NAME" Width="170px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Header Caption="평가작업명">
                                                </Header>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="START_DATE" DataType="System.DateTime" EditorControlID="wdcDate" Key="START_DATE" Type="Custom" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="시작일자">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn AllowNull="False" AllowUpdate="Yes" BaseColumnName="END_DATE" DataType="System.DateTime" EditorControlID="wdcDate" Key="END_DATE" Type="Custom" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="종료일자">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Format="yyyy-MM-dd" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="등록일자">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="UPDATE_DATE" Key="UPDATE_DATE" Format="yyyy-MM-dd" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="수정일자">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="STATUS_YN" HeaderText="상태" Key="STATUS_YN" Type="DropDownList" Width="80px">
                                                <ValueList>
                                                    <Style Font-Size="XX-Small"></Style>
                                                </ValueList>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="상태">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_JOB_ID" Hidden="True" Key="EST_JOB_ID">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Hidden="True" Key="UPDATE_YN" NullText="N">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
										</Columns>                                       
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
									</ig:UltraGridBand>
								</Bands>
								<DisplayLayout  CellClickActionDefault="Edit"
                                                BorderCollapseDefault="Separate"
                                                RowSelectorsDefault="no"
                                                Name="UltraWebGrid1" 
                                                RowHeightDefault="20px" 
                                                Version="4.00"  
                                                TableLayout="Fixed" 
                                                OptimizeCSSClassNamesOutput="False"
                                                AutoGenerateColumns="False">								
									<%--<RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
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
                                    <ClientSideEvents AfterCellUpdateHandler="UltraWebGrid1_AfterCellUpdateHandler" />
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>--%>
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                    <ClientSideEvents AfterCellUpdateHandler="UltraWebGrid1_AfterCellUpdateHandler" />
                                </DisplayLayout>
							</ig:UltraWebGrid>	                                                       
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            <ig:WebDateChooser ID="wdcDate" runat="server" NullDateLabel="" Format="Short">
                                            <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                        </ig:WebDateChooser>        
                            <asp:HiddenField ID="hdfEstID" runat="server" />
                        </td>
                        <td align="right">
                            <asp:ImageButton id="ibtnMail" runat="server" ImageUrl="../images/btn/b_051.gif" OnClientClick="return sendMail();" OnClick="ibtnMail_Click"></asp:ImageButton>
                            &nbsp;
							<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClientClick="return isValid();" OnClick="ibnSave_Click"></asp:ImageButton>
							&nbsp;
                        </td>
                    </tr>
                </table></td>
        </tr>
	</table>
<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
	</div>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</form>
</body>
<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>
