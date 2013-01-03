<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2203.aspx.cs" Inherits="usr_usr2203" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html; " />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script language="javascript" type="text/javascript">
<!--

function openwindow(empId, empName)
{
    opener.document.getElementById('txtEmpID').value = empId;
    opener.document.getElementById('txtEmpName').value = empName;
    self.close();
}

/////////////////////////////////////
// 그리드 그룹 확장/축소
/////////////////////////////////////
function ExpandAllRows(btnEl) 
{
    // Loop thru the rows of Band 0 and expand each one
    var oGrid = oUltraWebGrid1;
    var oBands = oGrid.Bands;
    var oBand = oBands[0];
    var oColumns = oBand.Columns;
    var count = oColumns.length;
    var oRows = oGrid.Rows;
    oGrid.suspendUpdates(true);
    for(i=0; i<oRows.length; i++) {
        oRow = oRows.getRow(i);
        if(btnEl.value == "Expand All") {
            oRow.setExpanded(true);
        }
        else {
            oRow.setExpanded(false);
        }
    }
    oGrid.suspendUpdates(false);
    if(btnEl.value == "Expand All") 
        btnEl.value = "Collapse All";
    else        
        btnEl.value = "Expand All";
    
}

    
/////////////////////////////////////
// 사용 목적 : 메뉴 전체 선택 전체 해제
/////////////////////////////////////
function AllChk1(chk)
{
	var f = document.all;
	
	for(i=0; i<f.length; i++)
	{
		if(f[i].getAttribute("type")=="checkbox")
		{
		    if(f[i].getAttribute("name") != "chkall" && 
		        f[i].getAttribute("name") != "chkUse")
            {
                f[i].checked = chk.checked;
    		}
		}
	}
}

/////////////////////////////////////
// 사용 목적 : 메뉴 전체 선택 전체 해제
// chk: checkbox object
// name: checkbox name
/////////////////////////////////////
function AllChk2(chk, name)
{
	var f = document.all;
	for(i=0; i<f.length; i++)
	{
		if(f[i].getAttribute("name")==name)
		{
			f[i].checked = chk.checked;
		}
	}
}


/////////////////////////////////////
// 사용 목적 : 메뉴 전체 선택 전체 해제
// chk: target checkbox
/////////////////////////////////////
function AllChk(chk)
{
	//var f = document.all;
	var f = document.all["selchk"]);
	for(i=0; i<f.length; i++)
	{
		//if(f[i].getAttribute("name")=="selchk")
		//{
			f[i].checked = chk.checked;
		//}
	}
}

// -->
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                        <td height="40" valign="top">
                            <img src="../images/title/popup_t23.gif">
                        </td>
                        <td align="right" valign="top">
                            <img src="../images/title/popup_img.gif">
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="4" bgcolor="#FFFFFF">
                        </td>
                        <td width="50%" bgcolor="#FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr style="height:100%;">
                        <td style="width: 190px" valign="top">
                            <div style="border: #F4F4F4 3px solid; overflow: auto; width: 200; height: 100%">
                                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                                    ImageSet="XPFileExplorer" NodeIndent="15">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                        NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                        </td>
                        <td>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" HeaderText="선택" Key="SELECT"
                                                Width="30px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="선택">
                                                </Header>
                                                <Footer Caption="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="사원번호" Key="EMP_REF_ID" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="사원번호">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOGINID" EditorControlID="" FooterText="" Format=""
                                                HeaderText="로그인ID" Key="LOGINID" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="로그인ID">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID="" FooterText="" Format=""
                                                HeaderText="성명" Key="EMP_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="성명">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText="" Format=""
                                                HeaderText="부서" Key="DEPT_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="부서">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="POSITION_NAME" EditorControlID="" FooterText=""
                                                Format="" HeaderText="직책" Key="POSITION_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="직책">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" HeaderText="사인" Key="SIGN_PATH"
                                                Width="30px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="사인">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" HeaderText="도장" Key="STAMP_PATH"
                                                Width="30px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="도장">
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CREATE_DATE" EditorControlID="" FooterText=""
                                                Format="" HeaderText="등록일" Key="CREATE_DATE">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="등록일">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="MODIFY_DATE" EditorControlID="" FooterText=""
                                                Format="" HeaderText="수정일" Key="MODIFY_DATE">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="수정일">
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" ViewType="Flat" Version="4.00" AllowSortingDefault="Yes"
                                    AllowColSizingDefault="Free" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1"
                                    BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" RowSelectorsDefault="No"
                                    RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single"
                                    AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single"
                                    SelectTypeColDefault="Single" StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True"
                                    TableLayout="Fixed" JavaScriptFileName="" JavaScriptFileNameCommon="" AllowUpdateDefault="Yes"
                                    OptimizeCSSClassNamesOutput="False">
                                    <%--<GroupByBox>
                                        <style backcolor="ActiveBorder" bordercolor="Window">
                                            </style>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                        <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                                        ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                                        GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                                        RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left"
                                        BorderColor="#E5E5E5" ForeColor="white">
                                        <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="2px"
                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="300px" Width="100%">
                                    </FrameStyle>
                                    <Pager>
                                        <style backcolor="LightGray" borderstyle="Solid" borderwidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" /></style>
                                    </Pager>
                                    <AddNewBox Hidden="False">
                                        <style backcolor="Window" bordercolor="InactiveCaption" borderstyle="Solid" borderwidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" /></style>
                                    </AddNewBox>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>--%>
                                    
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td colspan="2">
                            <a href="#" onclick="self.close();">
                                <img src="../images/btn/b_003.gif" border="0" /></a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
