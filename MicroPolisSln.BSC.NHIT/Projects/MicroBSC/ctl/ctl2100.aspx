<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ctl2100.aspx.cs" Inherits="usr_usr2100" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script language="javascript" type="text/javascript">
<!--
/////////////////////////////////////
// 팝업창 생성
// 추가/수정
/////////////////////////////////////
function openwindow(ptype, pempid)
{
    if(ptype == undefined)
    {
        return false;
    }

    if(pempid == undefined)
    {
        pempid = "";
    }
    
  
    
    /*    
    var inputform = window.open(
        "ctl2101.aspx?mode=" + ptype + "&empid=" + pempid, 
        "inputform", "width=600,height=470,toolbar=no,statusbar=no");
    */
        
    gfOpenWindow("ctl2101.aspx?&mode=" + ptype + "&empId=" + pempid+"&CCB1="+"<%=this.ICCB1 %>", 600, 550, true, true, "editForm");
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


function showMemo() 
{
    document.all.imgShow.style.display = "none";
    document.all.imgHide.style.display = "block";
	document.all.leftLayer.style.display = "block";
}

function hiddenMemo() 
{
    document.all.imgShow.style.display = "block";
    document.all.imgHide.style.display = "none";
	document.all.leftLayer.style.display = "none";
}

function ReloadGrid()
{
    
    __doPostBack('<%= this.ICCB1 %>', '');
}

function IMG1_onclick() 
{

}

function addUserWindow()
{
    var url = "ctl2101.aspx?mode=New&deptid="+"<%=hdfDeptRefId.Value  %>";
    gfOpenWindow(url, 600, 420, true, true, 'AddForm');
}

/////////////////////////////////////
// 팝업창 생성
// 추가/수정
/////////////////////////////////////
function OpenLowDeptEmpWindow()
{
    var strURL = "ctl2107s1.aspx";
    gfOpenWindow(strURL, 980, 700, 'ctl2107');
    return false;
}

// -->
</script>
<!--- MAIN START --->

        <table cellpadding="0" cellspacing="0" border="0" width="100%" height="100%">
            
            <tr>
                <td rowspan="4">
                    <div id="leftLayer" class="cssDivLayout" >
                        <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ImageSet="XPFileExplorer" NodeIndent="15">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </div>
                </td>
                <td rowspan="4" style="width: 9px">
                    <a href="javascript:hiddenMemo('leftLayer');"><img src="../images/btn/btn_Hide.gif" id="imgHide" border="0" /></a><br /><a href="javascript:showMemo('leftLayer');"><img src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" border="0"/></a>   
                </td>
                <td valign="top" align="right">
                    <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                        <tr>
                            <td class="cssTblTitle" >
                                부서명</td>
                            <td class="cssTblContent" >
                                <asp:TextBox ID="txtDeptName" runat="server" BackColor="White" Width="60%"></asp:TextBox>
                                <asp:TextBox ID="txtDeptCode" runat="server" BackColor="White" Width="35%" MaxLength="20"></asp:TextBox>
                                <asp:HiddenField ID="hdfDeptRefId" runat="server" />
                            </td>
                            <td class="cssTblTitle" >
                                상위부서명</td>
                            <td class="cssTblContent" cssTblContent>
                                <asp:TextBox ID="txtUpDeptName" runat="server" BackColor="White" ReadOnly="True" Width="100%" BorderWidth="0"></asp:TextBox>
                                <asp:HiddenField ID="hdfUpDeptRefId" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" >
                                조직유형</td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlDeptType" runat="server" class="box01"></asp:DropDownList></td>
                            <td class="cssTblTitle">
                                정렬순서</td>
                            <td class="cssTblContent" cssTblContent>
                                <asp:TextBox ID="txtSortOrder" runat="server" BackColor="White" Width="100%"></asp:TextBox>
                                <asp:HiddenField ID="hdfDeptLevel" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" >
                                사용유무</td>
                            <td class="cssTblContent">
                                <asp:CheckBox ID="chkUseYn" runat="server" Enabled="False" /></td>
                            <td class="cssTblTitle">
                                생성일자</td>
                            <td class="cssTblContent" cssTblContent>
                                <asp:TextBox ID="txtCreateDate" runat="server" BackColor="White" ReadOnly="True" Width="100%" BorderWidth="0"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" >
                                기타사항</td>
                            <td class="cssTblContent" colspan="3" >
                                <asp:TextBox ID="txtDeptDesc" runat="server" Height="40px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel  ID="Panel1" runat="server" Height="40px" Visible="False" Width="100%">
                        <table cellpadding="0" cellspacing="0" style="height:40;" border="0">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="iBtnAddBrother" runat="server" ImageUrl="../images/btn/b_106.gif" OnClick="iBtnAddBrother_Click" />
                                    <asp:ImageButton ID="iBtnAddChild" runat="server" ImageUrl="../images/btn/b_107.gif" OnClick="iBtnAddChild_Click" />
                                    <asp:ImageButton ID = "iBtnUpdate" runat="server" ImageUrl="../images/btn/b_002.gif" OnClick="iBtnUpdate_Click" />
                                    <a href="#null" onclick="window.open('ctl2105.aspx','','width=600, height=450')"><img src="../images/btn/b_038.gif" border="0"/></a>
                                    <asp:ImageButton ID = "itnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="itnDelete_Click" />
                                    <a href="#null" onclick="gfOpenWindow('ctl2103.aspx?mode=Remove', 600, 450);"></a>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr runat="server" id="trStyle">
                <td valign="top" style="height: 1px">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left" style="width: 96px; height: 25px;" nowrap="noWrap">
                            <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                                        <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                        <img align="absmiddle" src="../Images/etc/lis_t02.gif" />
                            </td>
                            <td valign="middle" align="right" style="width: 76%;" nowrap="noWrap">
                                
                                <asp:DropDownList ID="ddlSchType" runat="server" class="box01">
                                    <asp:ListItem Value="EMP_NAME">성명</asp:ListItem>
                                    <asp:ListItem Value="EMP_CODE">아이디</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSearch" runat="server" Width="92px"></asp:TextBox>
                            </td>
                            <td nowrap="noWrap" valign="middle" width="120">
                                <asp:RadioButtonList ID="radType" runat="server" RepeatColumns="2" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True" Value="1">재직</asp:ListItem>
                                    <asp:ListItem Value="0">퇴사</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td align="right" width="55px">
                                <asp:ImageButton ID="ibtnSearch" runat="server" ImageAlign="AbsMiddle" Height="19px" ImageUrl="~/images/btn/b_008.gif" OnClick="ibtnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; height:260px;">
                    <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout"><Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="LOGINIP" Hidden="True" Key="LOGINIP">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Hidden="True" Key="DEPT_REF_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_CLS_ID" Hidden="True" Key="POS_CLS_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_GRP_ID" Hidden="True" Key="POS_GRP_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_RNK_ID" Hidden="True" Key="POS_RNK_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_DUT_ID" Hidden="True" Key="POS_DUT_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_KND_ID" Hidden="True" Key="POS_KND_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No">
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" />
                                    </CellTemplate>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center"  />
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn FooterText="" HeaderText="수정" Key="MODIFY" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                    </CellStyle>
                                    <Header Caption="수정">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn FooterText="" HeaderText="권한수정" Key="ROLE" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                    </CellStyle>
                                    <Header Caption="권한수정">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn FooterText="" HeaderText="권한리스트" Key="EMP_NAMES" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="권한리스트" Title="">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" FooterText="" HeaderText="부서" Key="DEPT_NAME"
                                    Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="부서" Title="">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" FooterText="" HeaderText="성명" Key="EMP_NAME"
                                    Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="성명" Title="">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="LOGINID" FooterText="" HeaderText="아이디" Key="LOGINID"
                                    Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="아이디" Title="">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_CLS_NAME" HeaderText="직급" Key="POS_CLS_NAME"
                                    Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="직급">
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_DUT_NAME" FooterText="" HeaderText="직책"
                                    Key="POS_DUT_NAME" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="직책" Title="">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_RNK_NAME" HeaderText="직위" Key="POS_RNK_NAME"
                                    Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="직위">
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_GRP_NAME" HeaderText="직군" Key="POS_GRP_NAME"
                                    Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="직군">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_KND_NAME" HeaderText="직종" Key="POS_KND_NAME"
                                    Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="직종">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn FooterText="" HeaderText="사인" Hidden="True" Key="SIGN_PATH"
                                    Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="사인" Title="">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn FooterText="" HeaderText="도장" Hidden="True" Key="STAMP_PATH"
                                    Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="도장" Title="">
                                        <RowLayoutColumnInfo OriginX="21" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="21" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CREATE_DATE" FooterText="" Format="yyyy-MM-dd"
                                    HeaderText="등록일" Key="CREATE_DATE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="등록일" Title="">
                                        <RowLayoutColumnInfo OriginX="22" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="22" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MODIFY_DATE" FooterText="" Format="yyyy-MM-dd"
                                    HeaderText="수정일" Key="MODIFY_DATE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="수정일" Title="">
                                        <RowLayoutColumnInfo OriginX="23" />
                                    </Header>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="23" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout  CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="NotSet" 
                                    Name="UltraWebGrid1" 
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    ReadOnly="LevelTwo"
                                    CellClickActionDefault="NotSet" 
                                    TableLayout="Fixed" 
                                    ScrollBar = "Auto"
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False">
                    <%--    <GroupByBox>
                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Font-Bold="False" Font-Italic="False">
                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                            BorderWidth="1px" Font-Names="Arial" Font-Size="8pt" Height="100%"
                            Width="100%" Font-Bold="False">
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
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>--%>
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                        <Images>
                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                        </Images>
                    </DisplayLayout>
                </ig:ultrawebgrid>
                </td>
            </tr>
            <tr>
                <td height="40">
                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                         <tr>
                            <td width="60%">
                                <asp:ImageButton ID="ibnUpdatePos" runat="server" ImageUrl="~/images/btn/b_201.gif" OnClick="ibnUpdate_Click"/>
                                <asp:ImageButton ID="ibnUpdateDpt" runat="server" ImageUrl="~/images/btn/b_203.gif" OnClick="ibnUpdate_Click"/>
                            </td>
                            <td align="right" runat="server" id="trEmp">
                                <asp:ImageButton ID="ibtnRollback" runat="server" ImageUrl="~/images/btn/b_138.gif" OnClick="ibtnRollback_Click" Visible="false" />
                                <img id="hImgNew" src="../images/btn/b_156.gif" style="cursor:hand" onclick="addUserWindow();" border="0" runat="server" />
                                <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/images/btn/b_179.gif" OnClick="ibtnDelete_Click" />
                                <asp:ImageButton ID="ibtnSelect" runat="server" visible="false" ImageUrl="~/images/btn/b_007.gif" OnClick="ibtnSelect_Click" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ImageButton ID="ibtnOpenLowDeptEmp" runat="server" ImageUrl="~/images/btn/b_211.gif" OnClientClick="return OpenLowDeptEmpWindow();"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
<!--- MAIN END --->
<ASP:LINKBUTTON id="lBtnReload" runat="server" onclick="lBtnReload_Click"></ASP:LINKBUTTON>
<ASP:LINKBUTTON id="lBtnRefreshEmp" runat="server" onclick="lBtnRefreshEmp_Click"></ASP:LINKBUTTON>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>

</asp:Content>