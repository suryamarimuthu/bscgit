<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2400.aspx.cs" Inherits="ctl2400" MasterPageFile="~/_common/lib/MicroBSC.master"  validateRequest="false" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript">
function CheckCtrl(cbox_0, cbox_1, cbox_2, cbox_3, ddl_1) 
{
    var cBox0       = document.getElementById(cbox_0);
    var cBox1       = document.getElementById(cbox_1);
    var cBox2       = document.getElementById(cbox_2);
    var cBox3       = document.getElementById(cbox_3);
    var ddl1        = document.getElementById(ddl_1);
    
    var cheVal      = cBox0.checked;
    
    cBox1.checked   = false;
    cBox2.checked   = false;
    cBox3.checked   = false;
    
    if(cheVal       == true)
    {
        cBox0.checked       = true;
        ddl1.disabled       = false;
        
        if(document.getElementById(cbox_3).checked)
            ddl1.disabled   = true;
    }
    else 
    {
        ddl1.disabled       = true;
    }
}
</script>

<!--- MAIN START --->
<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr style="height:30px;">
                    <td>
                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                            <tr>
                                <td style="width:15px;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="평가 부서"/></td>
                            </tr>
                        </table>
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="ddlEstTermInfo" runat="server" CssClass="box01">
                        </asp:DropDownList>&nbsp;<asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="height:100%;">
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
                <tr style="height:100%;">
                    <td style="width:30%;">
                        <div id="leftLayer" class="cssDivLayout">
                            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ImageSet="XPFileExplorer" NodeIndent="15" ShowCheckBoxes="All">
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                    VerticalPadding="0px" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                    NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                        </div>
                        <SJ:SmartScroller id="SmartScroller2" runat="server" MaintainScrollY="true" MaintainScrollX="true" TargetObject="leftLayer"></SJ:SmartScroller>
                    </td>
                    <td style="width:5px;"></td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                                    <tr>
                                                        <td style="width:15px;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                                        <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="조직 개체별 상세 정보"/></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="height:100%;">
                                            <td>
                                                 <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" style="width:100%; height:100%;">
                                                      <tr>
                                                        <td class="cssTblTitle">부서 별칭</td>
                                                        <td class="cssTblContent" >
                                                            <asp:TextBox ID="txtDeptName_Org" runat="server" BackColor="White" Width="100%"></asp:TextBox>
                                                        </td>
                                                      </tr>
                                                      <tr>
                                                        <td class="cssTblTitle" style="width: 125px">내부 개체 정렬순서</td>
                                                        <td class="cssTblContent"><asp:TextBox ID="txtSort_Org" runat="server" BackColor="White" Width="100%"></asp:TextBox></td>
                                                      </tr>
                                                      <tr>
                                                        <td class="cssTblTitle">해더 이미지</td>
                                                        <td class="cssTblContent"><asp:DropDownList ID="ddlHearderType" runat="server" CssClass="box01">
                                                            <asp:ListItem Value="1">파란색</asp:ListItem>
                                                            <asp:ListItem Value="2">초록색</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                      </tr>
                                                      <tr>
                                                        <td class="cssTblTitle">조직 타입</td>
                                                        <td class="cssTblContent">
                                                            <asp:DropDownList ID="ddlDeptType" runat="server" CssClass="box01">
                                                            </asp:DropDownList></td>
                                                      </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table> 
                                </td>
                            </tr>
                            <tr class="cssPopBtnLine">
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                        <tr style="height:100%;">
                                            <td align="right">
                                                <asp:ImageButton ID = "iBtnSave_1" runat="server" ImageUrl="../images/btn/b_124.gif" OnClick="iBtnSave_1_Click" Visible="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="height:100%;">
                                <td>
                                    <table style="width:100%; height:100%;" cellpadding='0' cellspacing='0' border="0">
                                        <tr>
                                            <td>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                    <tr>
                                                        <td style="width:15px;">
                                                            <img src="../images/title/ma_t14.gif" alt="" />
                                                        </td>
                                                        <td>
                                                            <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="조직 타입별 설정" />
                                                        </td>
                                                        <td align="right">
                                                            (드릴다운 사용 여부 : 
                                                            <asp:RadioButtonList ID="rtlDrildownYN" runat="server" RepeatDirection="Horizontal"
                                                                RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rtlDrildownYN_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">사용</asp:ListItem>
                                                                <asp:ListItem Value="0">미사용</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            )
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="height:100%;">
                                            <td valign="top">
                                                <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="202px" OnInitializeRow="UltraWebGrid1_InitializeRow"><Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">                                    </AddNewRow>
                                                        <Columns>
                                                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue=""
                                                                BaseColumnName="TYPE_REF_ID" Key="TYPE_REF_ID" Width="150px" HeaderText="TYPE_REF_ID" Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="TYPE_REF_ID" Title="">
                                                                </Header>
                                                                <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                                                <Footer Caption="" Title="">                                            </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue=""
                                                                BaseColumnName="TYPE_NAME" Key="TYPE_NAME" Width="150px" HeaderText="조직 타입명">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="조직 타입명" Title="">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Header>
                                                                <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                                                <Footer Caption="" Title="">                                            
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:TemplatedColumn Key="HOME_YN_ORG" Width="100px" HeaderText="전사타입 여부">
                                                                <Header Caption="전사타입 여부" Title="">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                                                <CellTemplate>
                                                                    <asp:CheckBox ID="cBoxHome_Yn_Org" runat="server" />                                            </CellTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Footer>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn Key="HEADER_YN_ORG" Width="100px" HeaderText="해더타입 여부">
                                                                <Header Caption="해더타입 여부" Title="">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                                                <CellTemplate>
                                                                    <asp:CheckBox ID="cBoxHeader_YN_Org" runat="server" />                                            </CellTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Footer>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn Key="CONTENT_YN_ORG" Width="100px" HeaderText="컨텐트타입 여부">
                                                                <Header Caption="컨텐트타입 여부" Title="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                                                <CellTemplate>
                                                                    <asp:CheckBox ID="cBoxContent_YN_Org" runat="server" />                                            </CellTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn Key="POSITION_ORG" HeaderText="위치값" Width="120">
                                                                <CellTemplate>
                                                                    <asp:DropDownList CssClass="box01" ID="ddlPosition_Org" runat="server">
                                                                        <asp:ListItem Value="1">상단/좌측</asp:ListItem>
                                                                        <asp:ListItem Value="2">상단/중간</asp:ListItem>
                                                                        <asp:ListItem Value="3">상단/우측</asp:ListItem>
                                                                        <asp:ListItem Value="4">가운데/좌측</asp:ListItem>
                                                                        <asp:ListItem Value="5">가운데/중간</asp:ListItem>
                                                                        <asp:ListItem Value="6">가운데/우측</asp:ListItem>
                                                                        <asp:ListItem Value="7">하단</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </CellTemplate>
                                                                <Header Caption="위치값">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:TemplatedColumn>
                                                        </Columns>
                                                    </ig:UltraGridBand>
                                                </Bands>

                                                <DisplayLayout  CellPaddingDefault="2" 
                                                                Version="4.00" 
                                                                AllowSortingDefault="Yes" 
                                                                AllowColSizingDefault="Free" 
                                                                HeaderClickActionDefault="SortMulti" 
                                                                Name="UltraWebGrid1" 
                                                                BorderCollapseDefault="Separate" 
                                                                AllowDeleteDefault="Yes" 
                                                                RowSelectorsDefault="No" 
                                                                RowHeightDefault="23px" 
                                                                AllowColumnMovingDefault="OnServer" 
                                                                SelectTypeRowDefault="Single" 
                                                                AutoGenerateColumns="False" 
                                                                CellClickActionDefault="RowSelect" 
                                                                SelectTypeCellDefault="Single" 
                                                                SelectTypeColDefault="Single" 
                                                                StationaryMargins="Header" 
                                                                StationaryMarginsOutlookGroupBy="True" 
                                                                TableLayout="Fixed" 
                                                                JavaScriptFileName="" 
                                                                JavaScriptFileNameCommon="">
                                                <%--<GroupByBox>
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
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">                            </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="202px"
                                                    Width="100%">                            </FrameStyle>
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
                                                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>--%>
                                                
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                </DisplayLayout>
                                                </ig:ultrawebgrid>
                                                <div align="right"><asp:CheckBox ID="cBoxEstDeptTopYN" runat="server" Text="조식상황판 첫페이지로 설정" />
                                                    <asp:ImageButton ID="itnClearDeptDrill" runat="server" ImageUrl="../images/btn/b_125.gif" OnClick="itnClearDeptDrill_Click" Visible="False" />&nbsp;&nbsp;&nbsp;
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="cssPopBtnLine">
                    <td align="right">
                        <asp:ImageButton ID = "iBtnSave_0" runat="server" ImageUrl="../images/btn/b_123.gif" OnClick="iBtnSave_0_Click" />
                    </td>
                    <td></td>
                    <td align="right">
                        <asp:ImageButton ID = "iBtnSave_2" runat="server" ImageUrl="../images/btn/b_122.gif" OnClick="iBtnSave_2_Click" Visible="False" />
                        <asp:ImageButton ID = "itnClearEstDeptOrg" runat="server" ImageUrl="../images/btn/b_093.gif" OnClick="itnClearEstDeptOrg_Click" Visible="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<!--- MAIN END --->
    <asp:LinkButton id="lBtnReload" runat="server" onclick="lBtnReload_Click"></asp:Linkbutton>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>