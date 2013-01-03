<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2200.aspx.cs" Inherits="ctl_ctl2200" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
    
    
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
<script type="text/javascript">
<!--

/////////////////////////////////////
// 사용자 수정
/////////////////////////////////////
function openwindow_updateUser(ptype, pempid, biz_code)
{
    if(ptype == undefined)
    {
        return false;
    }

    if(pempid == undefined)
    {
        pempid = "";
    }
        
    gfOpenWindow("ctl2202.aspx?mode=" + ptype + "&EmpID=" + pempid + "&biz_type_code=" + biz_code, 800, 600);
}

// 팝업창 생성
// 결재선지정 창
function imgAssign_onclick() {
        var doctype = document.getElementById("ddlDoctype").value;     
    
        if(doctype == "")
        {
            alert("결재유형을 선택해 주시기 바랍니다.");
            return
        }
        gfOpenWindow("COM802_ApprovalConfig.aspx?apptype=" + doctype, 600, 550); 
}
/* -- 2006-06-22 제거
function OpenAppLine() 
{
    var biz_code = document.forms[0].ddlBizInfoList.value;
    if(biz_code == "*")
    {
        alert("결재선 종류를 선택하세요.");
        return false;
    }
    
    var url = 'ctl2202.aspx?biz_type_code=' + biz_code + '&mode=New';

    window.open(url , 'deptform', 'width=800,height=600,toolbar=no,statusbar=no');
}
*/

// -->
</script>
    <form id="form2" runat="server">
    <div>
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

	<table cellpadding=0 cellspacing=0 border=0 width=99% height="100%">
	<tr height="60">
		<td>
		<table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
		    <td class="tableOutBorder">
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder">
            <tr>
                <td style="width: 100px;" class="tableTitle" align=center>결재선종류</td>
                <td class="tableContent">
                    <asp:DropDownList ID="ddlBizInfoList" runat="server" CssClass="box01"></asp:DropDownList></td>
                <td style="width: 100px;" class="tabletitle" align=center>부&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;서</td>
                <td class="tableContent">
                    <asp:TextBox ID="txtDeptID" runat="server" Width="50px"></asp:TextBox>
                    <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                    <a href="#null" onclick="gfOpenWindow('ctl2102.aspx', 310, 400);"><img src="../images/btn/b_034.gif" align="middle" id="imgDeptSearch" border="0"/></a>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;" class="tabletitle" align=center>사 원 명</td>
                <td class="tableContent" colspan="3"><asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox></td>
            </tr>
            </table>
            </td>
        </tr>
        </table>
        </td>
    </tr>
    <tr>
        <td align="right" style="height: 30px">
        <asp:ImageButton ID="ibtnSearch" runat="server" Height="19px" ImageUrl="~/images/btn/b_033.gif" OnClick="ibtnSearch_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow"
                Width="100%">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <Columns>
                            <ig:TemplatedColumn EditorControlID="" FooterText="" Format="" HeaderText="선택"
                                Key="selchk" Width="30px">
                                <CellTemplate>
                                    <asp:CheckBox ID="selchk" runat="server" />
                                </CellTemplate>
                                <Header Caption="선택">
                                </Header>
                                <Footer Caption="">
                                </Footer>
                            </ig:TemplatedColumn>
                            <ig:UltraGridColumn HeaderText="수정" Key="MODIFY" Type="HyperLink" Width="30px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="수정">
                                    
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                                Format="" HeaderText="부서" Key="DEPT_NAME">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="부서">
                                    
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <HeaderStyle  HorizontalAlign=Center />
                                <CellStyle HorizontalAlign=Center ></CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID="" FooterText=""
                                Format="" HeaderText="성명" Key="EMP_NAME" Width="50px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="성명">
                                    
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <HeaderStyle  HorizontalAlign=Center />
                                <CellStyle HorizontalAlign=Center ></CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="POSITION_NAME" EditorControlID="" FooterText=""
                                Format="" HeaderText="직책" Key="POSITION_NAME" Width="50px" Hidden="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="직책">
                                    
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <HeaderStyle  HorizontalAlign=Center />
                                <CellStyle HorizontalAlign=Center ></CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="BIZ_TYPE_NAME" EditorControlID="" FooterText=""
                                Format="" HeaderText="결재선종류" Key="BIZ_TYPE_NAME" Width="220px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="결재선종류">
                                    
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <HeaderStyle  HorizontalAlign=Center />
                                <CellStyle HorizontalAlign=Center ></CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="APP_CNT" HeaderText="결재단계수" Key="APP_CNT">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="결재단계수">
                                    
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <HeaderStyle  HorizontalAlign=Center />
                                <CellStyle HorizontalAlign=Center ></CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="BIZ_TYPE_CODE" FooterText="app_path_seq" HeaderText=""
                                Hidden="True" Key="BIZ_TYPE_CODE">
                                <Header Caption="">
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Header>
                                <Footer Caption="app_path_seq">
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="REP_EMP_ID" FooterText="deptid" Hidden="True"
                                Key="REP_EMP_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Header>
                                <Footer Caption="deptid">
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                    CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" JavaScriptFileName=""
                    JavaScriptFileNameCommon="" Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No"
                    SelectTypeCellDefault="Single" SelectTypeColDefault="Single" SelectTypeRowDefault="Single"
                    StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed"
                    Version="4.00">
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="white">
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
                </DisplayLayout>
            </ig:UltraWebGrid>

		</td>
	</tr>
    <tr height="30">
        <td align="right">
        <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/images/btn/b_004.gif" Height="19px" OnClick="ibtnDelete_Click" />
        </td>
    </tr>
	</table>

        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<!--- MAIN END --->
    <MenuControl:MenuControl_Bottom id="MenuControl_Bottom1" runat="server" />
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>