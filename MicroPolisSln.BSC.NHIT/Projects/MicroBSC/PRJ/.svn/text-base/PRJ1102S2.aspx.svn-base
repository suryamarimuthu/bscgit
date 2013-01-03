<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1102S2.aspx.cs" Inherits="PRJ_PRJ1102S2" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">

    var param1 = true;

    function MouseOverHandler(gridName, id, objectType) {
        if (objectType == 0) {

            var cell = igtbl_getElementById(id);
            var row = igtbl_getRowById(id);
            var band = igtbl_getBandById(id);
            var active = igtbl_getActiveRow(id);

            cell.style.cursor = 'hand';
        }
    }
   
</script>
</head>

<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();">
<form id="form1" name="form1" runat="server">
<div>

<center>

<table border="0" cellspacing="2" cellpadding="0" style="height:310px; width:100%;">
    <tr>
        <td  style="vertical-align:top">
            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="height:40px; width:100%;">
                <tr>
                    <td class="tableTitle" align="center" style=" width:120px; height:20px;"><b>평가기간</b></td>
                    <td class="tableContent"  align="left">
                        <asp:TextBox ID="txtEstTermRefId" runat="server" Width="100%" OnKeyPress="CheckKeys()" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tableTitle" align="center"  style=" width:120px; height:20px;"><b>중점과제</b></td>
                    <td class="tableContent" align="left" valign="middle">
                        <asp:TextBox ID="txtWorkName" runat="server" Width="100%"  OnKeyPress="CheckKeys()" ReadOnly="true"></asp:TextBox> 
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  style="vertical-align:top">
            <ig:UltraWebGrid ID="ugrdViewStg" runat="server" Width="100%" Height="270px" 
                                    
                                        >
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <Columns>

                       
                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" 
                                                FooterText="EST_DEPT_REF_ID" 
                                                HeaderText="EST_DEPT_REF_ID" 
                                                Key="EST_DEPT_REF_ID" 
                                                Width="80px"
                                                Hidden="true" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                <Header Caption="EST_DEPT_REF_ID">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                            </ig:UltraGridColumn>
                            
                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID_NAME" 
                                                FooterText="EST_DEPT_REF_ID_NAME" 
                                                HeaderText="EST_DEPT_REF_ID_NAME" 
                                                Key="EST_DEPT_REF_ID_NAME" 
                                                Width="150px"
                                                Hidden="false" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                <Header Caption="부서">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                            </ig:UltraGridColumn>
                            
                            <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" 
                                                FooterText="VIEW_REF_ID" 
                                                HeaderText="VIEW_REF_ID" 
                                                Key="VIEW_REF_ID" 
                                                Width="80px"
                                                Hidden="true" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                <Header Caption="VIEW_REF_ID">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                            
                            <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID_NAME" 
                                                FooterText="VIEW_REF_ID_NAME" 
                                                HeaderText="VIEW_REF_ID_NAME" 
                                                Key="VIEW_REF_ID_NAME" 
                                                Width="150px"
                                                Hidden="false" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                <Header Caption="관점">
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                            </ig:UltraGridColumn>
                            
                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID" 
                                                FooterText="STG_REF_ID" 
                                                HeaderText="STG_REF_ID" 
                                                Key="STG_REF_ID" 
                                                Width="80px"
                                                Hidden="true" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                <Header Caption="STG_REF_ID">
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Header>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Footer>
                            </ig:UltraGridColumn>
                            
                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID_NAME" 
                                                FooterText="STG_REF_ID_NAME" 
                                                HeaderText="STG_REF_ID_NAME" 
                                                Key="STG_REF_ID_NAME" 
                                                Width="150px"
                                                Hidden="false" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                <Header Caption="전략">
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
                 <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
                                            AllowDeleteDefault="Yes"
                                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="SortMulti" Name="ugrdViewStg" RowHeightDefault="20px"
                                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" 
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
                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="270px"
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
                                            <ClientSideEvents  MouseOverHandler="MouseOverHandler"    />
                                        </DisplayLayout>
                    
            </ig:UltraWebGrid>
        
        </td>
    </tr>
 </table>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</center>
</div>


</form>
</body>
</html>