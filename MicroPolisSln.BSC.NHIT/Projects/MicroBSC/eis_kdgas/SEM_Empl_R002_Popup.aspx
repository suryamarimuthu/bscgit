<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Empl_R002_Popup.aspx.cs" Inherits="eis_SEM_Empl_R002_Popup" %>

<%@ Register Assembly="SJ.Web.UI" Namespace="SJ.Web.UI" TagPrefix="SJ" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>부서/사용자관리</title>
    <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
    <link href="treeStyle.css" type="text/css" rel="stylesheet" >
<script language="javascript" type="text/javascript">
function SetOpenerCtrl(sabun, bumunName, teamName, name) 
{
    opener.document.getElementById('hdfSabun').value = sabun;
    opener.document.getElementById('txtBumunName').value = bumunName;
    opener.document.getElementById('txtTeamName').value= teamName;
    opener.document.getElementById('txtName').value= name;
    //opener.__doPostBack('lBtnReload','');
    window.close();
}
</script></head>
<body>
                                <form id="form1" runat="server">
                                                <table cellpadding="1" cellspacing="0">
                                                    <tr>
                                                        <td align="left" style="width: 100px" valign="top" class="tdBorder">
                                                        <div style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; overflow: auto; border-left: darkgray 1px solid;
                                                                width: 200px; border-bottom: darkgray 1px solid; height: 300px">
                                                            <sj:treeview id="TreeView1" Width="260" 
                                                              AutoPostBackOnSelect="true"
                                                              EnableViewState="true"
                                                              CssClass="TreeView" 
                                                              NodeCssClass="TreeNode" 
                                                              SelectedNodeCssClass="SelectedTreeNode" 
                                                              MultipleSelectedNodeCssClass="MultipleSelectedTreeNode"
                                                              HoverNodeCssClass="HoverTreeNode"
                                                              CutNodeCssClass="CutTreeNode"
                                                              MarginWidth="24"
                                                              DefaultMarginImageWidth="24"
                                                              DefaultMarginImageHeight="20"
                                                              LineImageWidth="19" 
                                                              LineImageHeight="20"
                                                              DefaultImageWidth="16" 
                                                              DefaultImageHeight="16"
                                                              NodeLabelPadding="3"
                                                              ParentNodeImageUrl="folders.gif" 
                                                              LeafNodeImageUrl="folder.gif" 
                                                              CollapseImageUrl="exp.gif" 
                                                              ExpandImageUrl="col.gif" 
                                                              ExpandCollapseImageWidth="19"
                                                              ExpandCollapseImageHeight="20"
                                                              ShowLines="true" 
                                                              ImagesBaseUrl="images/"
                                                              LineImagesFolderUrl="images/lines"
                                                              runat="server" BorderColor="White" BorderWidth="0px" OnNodeSelected="TreeView1_NodeSelected" ></sj:treeview>
                                                              </div>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <table cellpadding="0" cellspacing="0" width="300">
                                                                <tr>
                                                                    <td>
                                                                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="280px" Width="300px" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                        <ig:UltraGridColumn HeaderText="선택" Key="edit" Width="30px">
                                            <Header Caption="선택">
                                            </Header>
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EMP_SABUN_T" Key="EMP_SABUN_T" Width="60px" FooterText="" HeaderText="사번">
                                            <Header Caption="사번">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="70px" FooterText="" HeaderText="성명">
                                            <Header Caption="성명">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                                                        </Columns>
                                                                    </ig:UltraGridBand>
                                                                </Bands>
                                                             <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorTop="White" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#C7C7C7"
                         ForeColor="White">
                        <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="280px"
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
                                    <RowAlternateStyleDefault BackColor="#E7E7E7">
                                    </RowAlternateStyleDefault>
                                </DisplayLayout>
                                                            </ig:UltraWebGrid>
                                 </td>
                                                                </tr>
                                                            </table>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            &nbsp;<a href='#null' onclick='window.close();'><img src='../images/btn/b_003.gif' border=0 /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </form>
</body>
</html>

