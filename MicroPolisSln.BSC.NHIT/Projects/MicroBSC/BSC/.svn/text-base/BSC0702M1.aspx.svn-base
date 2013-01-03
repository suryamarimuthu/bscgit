<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0702M1.aspx.cs" Inherits="BSC_BSC0702M1" %>

<html>
<head id="Head1" runat="server">
<title>BSC::성과관리 시스템</title>
<meta http-equiv="Content-Type" content="text/html; " />
<link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
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
	var f = document.all["selchk"];
	for(i=0; i<f.length; i++)
	{
		//if(f[i].getAttribute("name")=="selchk")
		//{
			f[i].checked = chk.checked;
		//}
	}
}

function selectChkBox(chkAll, chkChild)
    {
        var param1      = chkAll.checked;
        var _elements   = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox" )
            {
                if(_elements[i].disabled == false)
                {
                    if (param1 == false)
                        _elements[i].checked = false;
                    else
                        _elements[i].checked = true;
                }
            }
        }
    }

// -->
</script>


    <link href="../../_CSS/Styles.css" rel="stylesheet" type="text/css" />

</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
<!--- MAIN START --->	

        <table style="width: 98%">
            <tr>
                <td style="width: 200px" valign="top" rowspan="4">
                <div style="border:#F4F4F4 3px solid; overflow: auto; width: 200; height: 390px">
                    <asp:TreeView ID="trvComDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="trvComDept_SelectedNodeChanged">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                    </div>
                </td>
                <td height="50">
                    <ig:ultrawebgrid id="ugrdSelectedUser" runat="server" width="100%" Height="150px" style="left: 0px"><Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                            <ig:TemplatedColumn Key="selchk" Width="30px">
                        <CellTemplate>
                            <asp:CheckBox ID="cBox" runat="server" />
                        </CellTemplate>
                    </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="사원번호" Key="EMP_REF_ID" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="사원번호">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header><Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="LOGINID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="로그인ID" Key="LOGINID" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="로그인ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="60px" FooterText="" HeaderText="이름">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="이름">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_EMAIL" EditorControlID="" FooterText=""
                                    Format="" HeaderText="이메일" Key="EMP_EMAIL" Width="180px" Hidden="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="이메일">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="직책" Key="POSITION_CLASS_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직책">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_GRP_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="직군" Key="POSITION_GRP_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직군">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="직급" Key="POSITION_RANK_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직급">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_DUTY_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="직위" Key="POSITION_DUTY_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직위">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                        <DisplayLayout ViewType="OutlookGroupBy" Version="4.00" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed" JavaScriptFileName="" JavaScriptFileNameCommon="" AllowUpdateDefault="Yes">
                            <GroupByBox>
                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                            </GroupByRowStyleDefault>
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <SelectedRowStyleDefault BackColor="#E2ECF4">
                            </SelectedRowStyleDefault>
                            <HeaderStyleDefault BackColor="#5DABC0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#D2D2D2" ForeColor="White">
                                <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                            </HeaderStyleDefault>
                            <Images ImageDirectory="">
                            </Images>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="150px"
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

                        </DisplayLayout>
                    </ig:ultrawebgrid>
                    </td>
            </tr>
            <tr>
                <td align="center" height="50">
                    <asp:ImageButton ID="iBtnRemoveEmp" runat="server" ImageUrl="../images/btn/btn_add_03.GIF" OnClick="iBtnRemoveEmp_Click" />
                    &nbsp;
                    <asp:ImageButton ID="iBtnAddEmp" runat="server" ImageUrl="../images/btn/btn_add_04.GIF" OnClick="iBtnAddEmp_Click" /></td>
            </tr>
            <tr>
                <td height="100">
                    <ig:ultrawebgrid id="ugrdTargetUser" runat="server" width="100%" Height="150px" style="left: 0px">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" />
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="사원번호" Key="EMP_REF_ID" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="사원번호">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="LOGINID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="로그인ID" Key="LOGINID" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="로그인ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="60px" FooterText="" HeaderText="이름">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="이름">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_EMAIL" EditorControlID="" FooterText=""
                                    Format="" HeaderText="이메일" Key="EMP_EMAIL" Width="180px" Hidden="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="이메일">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="직책" Key="POSITION_CLASS_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직책">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_GRP_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="직군" Key="POSITION_GRP_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직군">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="직급" Key="POSITION_RANK_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직급">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_DUTY_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="직위" Key="POSITION_DUTY_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직위">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout ViewType="OutlookGroupBy" Version="4.00" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" HeaderClickActionDefault="SortMulti" Name="Ultrawebgrid2" BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed" JavaScriptFileName="" JavaScriptFileNameCommon="" AllowUpdateDefault="Yes">
                        <GroupByBox>
                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                        </GroupByRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#5DABC0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#D2D2D2" ForeColor="White">
                            <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                        </HeaderStyleDefault>
                        <Images ImageDirectory="">
                        </Images>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="150px"
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
                    </DisplayLayout>
                </ig:UltraWebGrid>
              </td>
            </tr>
            <tr>
                <td>
                    <table width=100% border=0>
                        <tr>
                            <td style="height: 25px">
                                총 인원수 :
                                <asp:label id="lblTotal" runat="server" ForeColor="#2080D0" Text="0"></asp:label>명
                            </td>
                            <td align="right" style="height: 25px">
                            <asp:checkbox id="CheckBox1" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1')" Text="전체 선택/해제" Visible="False"></asp:checkbox>
                                &nbsp;
                            <asp:ImageButton ID="iBtnConfirm" runat="server" ImageUrl="../images/btn/b_005.gif" OnClick="iBtnConfirm_Click" />&nbsp;
                            <a href="#" onclick="self.close();"><img src="../images/btn/b_003.gif" border="0" /></a>&nbsp;&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
                    
        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
        <script>gfWinFocus();</script>
    </form>
</body>
</html>
