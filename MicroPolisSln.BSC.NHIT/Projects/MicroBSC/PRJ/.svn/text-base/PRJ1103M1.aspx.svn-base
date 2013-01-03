<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1103M1.aspx.cs" Inherits="PRJ_PRJ1103M1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript" language="javascript">


   
    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    {
           var cell   = igtbl_getElementById(id);
           var row    = igtbl_getRowById(id);
           var band   = igtbl_getBandById(id);
           var active = igtbl_getActiveRow(id);
           cell.style.cursor = 'hand';
        }
    }
    
    function CheckKeys() // 문자입력 금지 함수 설정
    {
        event.keyCode = 0;
    }

    
</script>

    <style type="text/css">
        body
        {
            width: 100%;
            height: 100%;
            margin: 0px;
        }
        html
        {
            width: 100%;
            height: 100%;
            margin: 0px;
        }
    </style>

</head>

<body>

<form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;" >
        <tr>
            <td colspan="3"  style="height:40px; vertical-align:top;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background-image:url(../images/title/popup_t_bg.gif);">
                    <tr> 
                        <td style="height:40px;" valign="top">
                            <img alt="" src="../images/title/popup_t105.gif" /></td>
                        <td align="right" valign="top" ><img src="../images/title/popup_img.gif" alt="" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div style="height: 5px;"></div>
            </td>
        </tr>
        <tr valign="top">
            <td style="width: 240px; height:750px; "  class="tableContent">
                <table cellpadding="0" cellspacing="0" border="0"  style="width: 100%; height: 100%;" class="tableBorder">
                    <tr>
                        <td class="tableTitle2" align="center" style="width:70px; height:20px;">평가기간</td>
                        <td class="tableContent"  style="width:170px;">
                            <asp:TextBox ID="txtEsttermName" runat="server" Width="160px" 
                            OnKeyPress="CheckKeys()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tableTitle2" align="center"  style="width:70px;height:20px;">평가부서</td>
                        <td class="tableContent" style="width:170px;">
                            <asp:TextBox ID="txtEstDeptName1" runat="server" Width="160px" 
                                OnKeyPress="CheckKeys()"></asp:TextBox>
                        </td>
                    </tr> 
                    <tr>
                        <td class="tableTitle2" align="center"  style="width:70px;height:20px;">맵버젼</td>
                        <td class="tableContent" style="width:170px;">
                            <asp:TextBox ID="txtMapVerName" runat="server" Width="160px" 
                                OnKeyPress="CheckKeys()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td colspan="2" style=" height: 680px">
                            <div  id="divMap"style="border:#F4F4F4 3 solid; DISPLAY:block; overflow: auto ; position:static; 
    width: 240px;  height: 680px; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                                <asp:TreeView ID="trvStgMap" runat="server" OnSelectedNodeChanged="trvStgMap_SelectedNodeChanged" 
                                    ImageSet="Faq" BorderStyle="None" EnableTheming="False" PopulateNodesFromClient="False" 
                                        ShowLines="false" NodeIndent="15" >
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" 
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" 
                                        NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                </table>  
            </td>
            <td style="width:240px; height:750px;" >
	
                <div id="leftLayer" style="margin: 2px; border: #F4F4F4 3 solid; DISPLAY: block; overflow: auto; position: static; 
                    width: 240px;  height: 740px; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px;  ">
                    <asp:TreeView ID="trvEstDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" 
                        OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                            VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </div>

            </td>
            <td  style=" height:750px;">
                <div style="width:100%; height: 20px;" >
                    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width:100%;">
                        <tr>
                            <td class="tableTitle2" align="center"  style="width:100px; height:20px;">선&nbsp;택&nbsp;부&nbsp;서</td>
                            <td class="tableContent">
                                <asp:TextBox ID="txtEstDeptName2" runat="server" Width="160px" OnKeyPress="CheckKeys()"></asp:TextBox>
                            </td>
                            <td>
                                <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
                            </td>
                            <td class="tableContent" align="right" >
                                <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server" 
                                            OnClick="iBtnClose_Click" />&nbsp;  
                            </td>
                        </tr>
                      
                    </table>  
                </div>
                <asp:Panel ID="pnlWorkInfo" runat="server">
                    <div>
                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                            <tr style="height:20px;">
                                <td class="tableContent" style="width:80%;"> 
                                    <asp:Label ID="lblEstTerm1" runat="server" Text="" ForeColor="Red" Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="lblEstDept1" runat="server" Text="" ForeColor="Red"></asp:Label>중점과제
                                </td>
                                <td class="tableContent" align="right">
                                    <asp:ImageButton runat="server" ID="iBtnWorkInfoUpdate" ImageUrl="../images/btn/b_002.gif" 
                                                        ImageAlign="AbsMiddle" onclick="iBtnWorkInfoUpdate_Click"/>&nbsp;
                                </td>
                            </tr>
                            
                        </table>
                    </div>
                    <div>
        		        <ig:UltraWebGrid ID="ugrdWorkInfoList" runat="server" Width="100%" Height="250px" 
                            onInitializeRow="ugrdWorkInfoList_InitializeRow" 
                            onselectedrowschange="ugrdWorkInfoList_SelectedRowsChange" >
                            <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <Columns>
                                    
                                        <ig:UltraGridColumn BaseColumnName="STGKPI" 
                                                            FooterText="STGKPI" 
                                                            HeaderText="STGKPI" 
                                                            Key="STGKPI" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="STGKPI">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    
                                        <ig:TemplatedColumn HeaderText="선택" Key="selchk" Width="30px" Hidden="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle VerticalAlign="Middle">
                                            </CellStyle>
                                            <CellTemplate>
                                                <asp:CheckBox ID="cBox" runat="server" />
                                            </CellTemplate>
                                            <Header Caption="선택">
                                            </Header>
                                        </ig:TemplatedColumn>
                                    
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" 
                                                            FooterText="ESTTERM_REF_ID" 
                                                            HeaderText="ESTTERM_REF_ID" 
                                                            Key="ESTTERM_REF_ID" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="ESTTERM_REF_ID">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_NAME" 
                                                            FooterText="ESTTERM_NAME" 
                                                            HeaderText="ESTTERM_NAME" 
                                                            Key="ESTTERM_NAME" 
                                                            Width="100px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="평가기간">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    
                                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" 
                                                            FooterText="EST_DEPT_REF_ID" 
                                                            HeaderText="EST_DEPT_REF_ID" 
                                                            Key="EST_DEPT_REF_ID" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="EST_DEPT_REF_ID">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" 
                                                            FooterText="DEPT_NAME" 
                                                            HeaderText="DEPT_NAME" 
                                                            Key="평가부서" 
                                                            Width="100px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="평가부서">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" 
                                                            FooterText="WORK_REF_ID" 
                                                            HeaderText="WORK_REF_ID" 
                                                            Key="WORK_REF_ID" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="WORK_REF_ID">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="WORK_CODE" 
                                                            FooterText="" 
                                                            HeaderText="중점과제코드" 
                                                            Key="WORK_CODE" 
                                                            Width="80px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="중점과제코드">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="WORK_NAME" 
                                                            FooterText="" 
                                                            HeaderText="중점과제명" 
                                                            Key="WORK_NAME" 
                                                            Width="120px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="중점과제명">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                    </Columns>
                                    <RowTemplateStyle  BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                    </RowTemplateStyle>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" 
                                AllowDeleteDefault="Yes"
                                AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                HeaderClickActionDefault="SortMulti" Name="ugrdWorkInfoList" RowHeightDefault="20px"
                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="OutlookGroupBy" 
                                CellClickActionDefault="RowSelect"
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
                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                </EditCellStyleDefault>
                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="250px"
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
                                <ClientSideEvents  MouseOverHandler="MouseOverHandler"  />
                            </DisplayLayout>
                                
                        </ig:UltraWebGrid>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlWorkExec" runat="server">
                    <div>
                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                            <tr style="height:20px;">
                                <td class="tableContent" >
                                    <asp:Label ID="lblWorkInfo2" runat="server" Text="" 
                                        ForeColor="Red" Font-Bold="True"></asp:Label>실행과제
                                </td>
                                <td class="tableContent" align="right">
                                    <asp:ImageButton runat="server" ID="iBtnWorkExecUpdate" ImageUrl="../images/btn/b_002.gif" 
                                                        ImageAlign="AbsMiddle" onclick="iBtnWorkExecUpdate_Click"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <ig:UltraWebGrid ID="ugrdWorkExecList" runat="server" Width="100%" Height="250px" 
                            OnInitializeRow="ugrdWorkExecList_InitializeRow" 
                            onselectedrowschange="ugrdWorkExecList_SelectedRowsChange" >
                          
                            <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <Columns>
                                    
                                        <ig:UltraGridColumn BaseColumnName="STGKPI" 
                                                            FooterText="STGKPI" 
                                                            HeaderText="STGKPI" 
                                                            Key="STGKPI" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="STGKPI">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>

                                         <ig:TemplatedColumn HeaderText="선택" Key="selchk" Width="30px" Hidden="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle VerticalAlign="Middle">
                                            </CellStyle>
                                            <CellTemplate>
                                                <asp:CheckBox ID="cBox" runat="server" />
                                            </CellTemplate>
                                            <Header Caption="선택">
                                            </Header>
                                        </ig:TemplatedColumn>
                                    
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" 
                                                            FooterText="ESTTERM_REF_ID" 
                                                            HeaderText="ESTTERM_REF_ID" 
                                                            Key="ESTTERM_REF_ID" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="ESTTERM_REF_ID">
                                                <RowLayoutColumnInfo OriginX="0" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="0" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_NAME" 
                                                            FooterText="ESTTERM_NAME" 
                                                            HeaderText="ESTTERM_NAME" 
                                                            Key="ESTTERM_NAME" 
                                                            Width="80px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="평가기간">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    
                                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" 
                                                            FooterText="EST_DEPT_REF_ID" 
                                                            HeaderText="EST_DEPT_REF_ID" 
                                                            Key="EST_DEPT_REF_ID" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="EST_DEPT_REF_ID">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" 
                                                            FooterText="DEPT_NAME" 
                                                            HeaderText="DEPT_NAME" 
                                                            Key="DEPT_NAME" 
                                                            Width="80px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="평가부서">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" 
                                                            FooterText="WORK_REF_ID" 
                                                            HeaderText="WORK_REF_ID" 
                                                            Key="WORK_REF_ID" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="WORK_REF_ID">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="WORK_NAME" 
                                                            FooterText="WORK_NAME" 
                                                            HeaderText="WORK_NAME" 
                                                            Key="WORK_NAME" 
                                                            Width="80px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="중점과제명">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="EXEC_REF_ID" 
                                                            FooterText="EXEC_REF_ID" 
                                                            HeaderText="EXEC_REF_ID" 
                                                            Key="EXEC_REF_ID" 
                                                            Width="80px"
                                                            Hidden="true" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="EXEC_REF_ID">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="EXEC_CODE" 
                                                            FooterText="" 
                                                            HeaderText="실행과제코드" 
                                                            Key="EXEC_CODE" 
                                                            Width="80px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="실행과제코드">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="EXEC_NAME" 
                                                            FooterText="" 
                                                            HeaderText="실행과제명" 
                                                            Key="EXEC_NAME" 
                                                            Width="80px"
                                                            Hidden="false" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="실행과제명">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                    </Columns>
                                    <RowTemplateStyle  BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                    </RowTemplateStyle>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" 
                                AllowDeleteDefault="Yes"
                                AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                HeaderClickActionDefault="SortMulti" Name="ugrdWorkExecList" RowHeightDefault="20px"
                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="OutlookGroupBy" 
                                CellClickActionDefault="RowSelect"
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
                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                </EditCellStyleDefault>
                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="250px"
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
                                <ClientSideEvents MouseOverHandler="MouseOverHandler"  />
                            </DisplayLayout>    
                        </ig:UltraWebGrid>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <div style="height: 5px;"></div>
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server" ></asp:Literal>
</form>
</body>
</html>

