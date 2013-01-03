<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110400.ASPX.cs" Inherits="EST_EST110400" %>

<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%Response.WriteFile("../_common/html/CommonTop.htm");%>


<script type="text/javascript">
    function checkYearClose(objID) {
        if ('<%= this.IIS_TERM_CLOSE %>' != '0') {
            alert("평가기간이 마감되었습니다!");
            return false;
        }

        if (objID == '1')
            return true;
        else {
            if ('<%= this.IBIAS_GRP_ID %>' == '0') {
                alert("그룹을 먼저 선택하세요.");
                return false;
            }
            return confirm("설정하시겠습니까?");
        }
    }

    function popupGroupColumn(objid) {
        if (!checkYearClose('1'))
            return false;
        if (objid == '1') {
            gfOpenWindow("EST110400_01.aspx?COMP_ID=<%= this.ICOMP_ID %>"
                                + "&EST_ID=<%= this.IEST_ID %>"
                                + "&CCB1=<%= ICCB1 %>"
                               , 500
                               , 500
                               , false
                               , false
                               , "popup_est_bias_group");
        }
        else {
            gfOpenWindow("EST110400_02.aspx?COMP_ID=<%= this.ICOMP_ID %>"
                                + "&EST_ID=<%= this.IEST_ID %>"
                               , 800
                               , 600
                               , false
                               , false
                               , "popup_est_bias_column");
            return false;
        }
    }

    var TREEVIEW_ID = 'treeEmp';//the ID of the TreeView control
    //the constants used by GetNodeIndex()
    var LINK = 0;
    var CHECKBOX = 1;

    //this function is executed whenever user clicks on the node text
    function ToggleCheckBox(senderId) {
        var nodeIndex = GetNodeIndex(senderId, LINK);
        var checkBoxId = TREEVIEW_ID + "n" + nodeIndex + "CheckBox";
        var checkBox = document.getElementById(checkBoxId);
        checkBox.checked = !checkBox.checked;

        ToggleChildCheckBoxes(checkBox);
        ToggleParentCheckBox(checkBox);
    }

    //checkbox click event handler
    function checkBox_Click(eventElement) {
        ToggleChildCheckBoxes(eventElement.target);
        ToggleParentCheckBox(eventElement.target);
    }

    //returns the index of the clicked link or the checkbox
    function GetNodeIndex(elementId, elementType) {
        var nodeIndex;
        if (elementType == LINK) {
            nodeIndex = elementId.substring((TREEVIEW_ID + "t").length);
        }
        else if (elementType == CHECKBOX) {
            nodeIndex = elementId.substring((TREEVIEW_ID + "n").length, elementId.indexOf("CheckBox"));
        }
        return nodeIndex;
    }

    //checks or unchecks the nested checkboxes
    function ToggleChildCheckBoxes(checkBox) {
        var postfix = "n";
        var childContainerId = TREEVIEW_ID + postfix + GetNodeIndex(checkBox.id, CHECKBOX) + "Nodes";
        var childContainer = document.getElementById(childContainerId);
        if (childContainer) {
            var childCheckBoxes = childContainer.getElementsByTagName("input");
            for (var i = 0; i < childCheckBoxes.length; i++) {
                childCheckBoxes[i].checked = checkBox.checked;
            }
        }
    }

    //unchecks the parent checkboxes if the current one is unchecked
    function ToggleParentCheckBox(checkBox) {
        if (checkBox.checked == false) {
            var parentContainer = GetParentNodeById(checkBox, TREEVIEW_ID);
            if (parentContainer) {
                var parentCheckBoxId = parentContainer.id.substring(0, parentContainer.id.search("Nodes")) + "CheckBox";
                if ($get(parentCheckBoxId) && $get(parentCheckBoxId).type == "checkbox") {
                    $get(parentCheckBoxId).checked = false;
                    ToggleParentCheckBox($get(parentCheckBoxId));
                }
            }
        }
    }

    //returns the ID of the parent container if the current checkbox is unchecked
    function GetParentNodeById(element, id) {
        var parent = element.parentNode;
        if (parent == null) {
            return false;
        }
        if (parent.id.search(id) == -1) {
            return GetParentNodeById(parent, id);
        }
        else {
            return parent;
        }
    }
</script>

<form id="form1" runat="server">
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="2" border="0" width="100%" style="height: 100%;">
        <tr>
	        <td height="20px">
	            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="tableBorder">
	                <tr>
	                    <td class="cssTblTitle">
	                        <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="평가기간"/>&nbsp;
	                    </td>
	                    <td class="cssTblContent" style="border-right:none;">
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" autopostback="True" onselectedindexchanged="ddlEstTermRefID_SelectedIndexChanged" width="100%" class="box01"></asp:dropdownlist>
                            <%--<asp:dropdownlist id="ddlEstTermSubID" runat="server" autopostback="True" class="box01" onselectedindexchanged="ddlEstTermSubID_SelectedIndexChanged"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermStepID" runat="server" autopostback="True" class="box01" onselectedindexchanged="ddlEstTermStepID_SelectedIndexChanged" Visible="False"></asp:dropdownlist>--%>
                        </td>
                        <td class="cssTblContent" style="width:50%; border-left:none;" colspan="2" align="right">
                            <img id="imgGroup" runat="server" style="cursor: pointer;" OnClick="popupGroupColumn('1')" src="../images/dashboard/bg_box_1.jpg" />
                            <img id="imgColumn" runat="server" style="cursor: pointer;" OnClick="popupGroupColumn('2')" src="../images/dashboard/bg_box_2.jpg" />
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                        </td>
	                </tr>
	            </table>
            </td>
        </tr>
        <tr>
            <td style="height: 100%;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                    <tr>
                        <td style="width: 300px; height: 20px; padding-right: 5px;" align="left">
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="lblTitle1" runat="server" Font-Bold="true" Text="Bias Group"/></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="lblTitle2" runat="server" Font-Bold="true" Text="인사부서/사용자"/></td>
                                </tr>
                            </table>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblGroup" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 370px;">
                            <ig:UltraWebGrid ID="ugrdGroup" runat="server" Width="100%" Height="100%" OnSelectedRowsChange="ugrdGroup_SelectedRowsChange">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="BIAS_GRP_CD" Key="BIAS_GRP_CD" Width="60px" HeaderText="그룹코드">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BIAS_GRP_NM" Key="BIAS_GRP_NM" Width="190px" HeaderText="그룹명칭">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_COUNT" Key="DEPT_COUNT" Width="60px" HeaderText="설정부서" DataType="System.Int32" Format="###,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_COUNT" Key="EMP_COUNT" Width="60px" HeaderText="설정인원" DataType="System.Int32" Format="###,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BIAS_GRP_DESC" Key="BIAS_GRP_DESC" Width="200px" HeaderText="그룹설명">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            
                                            <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BIAS_GRP_ID" Key="BIAS_GRP_ID" Hidden="true"></ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" 
                                                AllowColSizingDefault="Free" 
                                                AllowColumnMovingDefault="None" 
                                                AllowDeleteDefault="No"
                                                AllowSortingDefault="Yes" 
                                                BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="NotSet"
                                                Name="ugrdGroup" 
                                                RowHeightDefault="23px" 
                                                HeaderStyleDefault-Height="22px"
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended" 
                                                Version="4.00" 
                                                CellClickActionDefault="RowSelect" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="Header" 
                                                OptimizeCSSClassNamesOutput="False"
                                                AutoGenerateColumns="False">
                                    <%--<GroupByBox>
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
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
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
                                    <ClientSideEvents />--%>
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
                            </ig:UltraWebGrid>
                        </td>
                        <td style="padding-left: 5px;" valign="top">
                            <div style="BORDER: #f4f4f4 1px solid; width: 100%; height: 100%; overflow: scroll; padding-left: 30px;">
                                <asp:treeview id="treeEmp" runat="server" nodeindent="15" imageset="XPFileExplorer">
                                    <ParentNodeStyle Font-Bold="False"  />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px"  />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:treeview>
                            </div>
                        </td>
                    </tr>
                </table>
	        </td>
        </tr>
        <tr valign="bottom">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 370px; height: 25px;" align="right">
                            <ig:UltraWebGrid ID="ugrdGroupEmpList" runat="server"  Width="100%" Height="100%" Visible="false">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="BIAS_GRP_ID" MergeCells="true" HeaderText="그룹 ID" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BIAS_GRP_CD" MergeCells="true" HeaderText="그룹 CODE" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BIAS_GRP_NM" MergeCells="true" HeaderText="그룹명" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" HeaderText="부서코드" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서명" Width="150px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" HeaderText="사원코드" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="사원명" Width="120px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" 
                                                AllowColumnMovingDefault="None"
                                                AllowDeleteDefault="No"
                                                AllowSortingDefault="No"
                                                AutoGenerateColumns="False" 
                                                BorderCollapseDefault="Separate"
                                                CellClickActionDefault="NotSet"
                                                CellPaddingDefault="2" 
                                                HeaderClickActionDefault="NotSet"
                                                Name="ugrdGroupEmpList" 
                                                RowHeightDefault="20px" 
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended"
                                                StationaryMargins="Header" 
                                                TableLayout="Fixed" 
                                                Version="4.00" 
                                                OptimizeCSSClassNamesOutput="False"
                                                ViewType="OutlookGroupBy">
                                    <%--<GroupByBox Hidden="True">
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                        ForeColor="White" HorizontalAlign="Left">
                                        <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="100%" Cursor="hand">
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
                                    </AddNewBox>--%>
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
                            </ig:UltraWebGrid>
                            <asp:imagebutton id="ibtnExcel" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_041.gif" onclick="ibtnExcel_Click"></asp:imagebutton>
                            <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport">
                            </ig:UltraWebGridExcelExporter>
                        </td>
                        <td align="right">
                            <asp:imagebutton id="ibtnSave" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_007.gif" onclientclick="return checkYearClose('2');" onclick="ibtnSave_Click"></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:literal id="ltrScript" runat="server"></asp:literal>
    <asp:linkbutton id="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:linkbutton>
    <!--- MAIN END --->
    <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</form>
<script type="text/javascript">
    var links = document.getElementsByTagName("a");
    for (var i = 0; i < links.length; i++) {
        if (links[i].className == TREEVIEW_ID + "_0") {
            links[i].href = "javascript:ToggleCheckBox(\"" + links[i].id + "\");";
        }
    }

    var checkBoxes = document.getElementsByTagName("input");
    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].type == "checkbox") {
            $addHandler(checkBoxes[i], "click", checkBox_Click);
        }
    }
</script>

<%Response.WriteFile("../_common/html/CommonBottom.htm");%>