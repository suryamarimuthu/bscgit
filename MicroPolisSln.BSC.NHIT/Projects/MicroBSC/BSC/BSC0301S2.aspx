<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0301S2.aspx.cs" Inherits="BSC_BSC0301S2" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    
   <script id="Infragistics" type="text/javascript">
    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);
           var termName         = row.getCellFromKey("KPI_NAME").getValue();
           cell.style.cursor    = 'hand';
        }
    }
    
    function ugrdKPIPool_DblClickHandler(gridName, cellId)
    {
        var cell    = igtbl_getElementById(cellId);
        var row     = igtbl_getRowById(cellId);
        var kpiID   = row.getCellFromKey("KPI_POOL_REF_ID").getValue();
        
        var strURL = 'BSC0301M1.aspx?iType=U&KPI_POOL_REF_ID='+ kpiID;
        gfOpenWindow(strURL, 720, 670,"BSC0301M1");
    }
    
    function OpenInsertWindow()
    {
        var kpiID  = '';
        var strURL = 'BSC0301M1.aspx?iType=A&KPI_POOL_REF_ID='+ kpiID;
        gfOpenWindow(strURL, 720, 670, 'BSC0301M1');
    }
    
    function SetPoolinfo(strPooLId, strPoolNm)
    {
        var objKey = eval("opener.document.forms[0]."+"<%= this.IObjKey %>");
        var objVal = eval("opener.document.forms[0]."+"<%= this.IObjVal %>");
        
        if (objKey != null && objVal != null)
        {
            objKey.value = strPooLId;
            objVal.value = strPoolNm;
            
            if (opener) opener.__doPostBack('linkBtnSelKpiPool',''); 
        }
        else
        {
            alert('객체를 찾을수 없습니다.');
        }
        window.close();
    }
    </script>   

</head>
<body style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
<form id="form1" runat="server">
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>

<!--- MAIN START --->	
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr> 
                <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                            <td style="width:170px; height:40px; background-image:url(../images/title/popup_title.gif);" class="cssPopTitleArea">
                                <asp:Label ID="Label1" runat="server" CssClass="cssPopTitleTxt" Text="지표검색" />
                            </td>
                            <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif" /></td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                            <td style="width:50%; background-color:#FFFFFF"></td>
                        </tr>
                    </table>
                </td>
              </tr>
            </table>
        </td>
    </tr>
    <tr class="cssPopContent">
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                <tr>
                    <td>
                        <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="cssTblTitle">KPI 명</td>
                                <td class="cssTblContent">
                                    <asp:TextBox ID="txtKPIName" runat="server" width="100%" OnTextChanged="txtKPIName_TextChanged"></asp:TextBox>
                                </td>
                                <td class="cssTblTitle">KPI 유형</td>
                                <td class="cssTblContent">
                                    <asp:DropDownList ID="ddlKpiType" runat="server" Width="100%" CssClass="box01" />
                                </td>
                            </tr>
                            <tr>
                                <td class="cssTblTitle">사용여부</td>
                                <td class="cssTblContent">
                                    <asp:dropdownlist runat="server" id="ddlUseYn" Width="100%" CssClass="box01"></asp:dropdownlist>
                                </td>	
                                <td class="cssTblTitle">지표분류</td>
                                <td class="cssTblContent">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlKpiCategoryTop" Width="33%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryTop_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                            /><asp:DropDownList ID="ddlKpiCategoryMid" Width="33%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryMid_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                            /><asp:DropDownList ID="ddlKpiCategoryLow" Width="33%" runat="server" CssClass="box01" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssTblTitle" style="border-right:none;">평가기준사용여부</td>
                                <td class="cssTblContent" style="border-right:none;">
                                    <asp:DropDownList ID="ddlBASIS_USE_YN" Width="100%" runat="server" CssClass="box01" />
                                </td>
                                <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                <td class="cssTblContent">&nbsp;</td>
                            </tr>
                    </table>
                    </td>
                </tr>
                
                <tr class="cssPopBtnLine">
                    <td align="right">
                        <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                    </td>
                </tr>
                
                <tr style="height:100%;">
                    <td>
                        <ig:UltraWebGrid ID="ugrdKPIPool" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKPIPool_InitializeRow" >
                            <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" EditorControlID="" FooterText=""
                                            Format="" HeaderText="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" Width="100px" Hidden="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="KPI_POOL_REF_ID">
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Footer Caption="">
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="250px">
                                            <Header Caption="KPI 명">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="KPI_EXTERNAL_TYPE_NAME" Key="KPI_EXTERNAL_TYPE_NAME" Width="100px">
                                            <Header Caption="KPI 구분">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="100px">
                                            <Header Caption="KPI 유형">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="TOP_CATEGORY_NAME" Key="TOP_CATEGORY_NAME" Width="100px">
                                            <Header Caption="대분류">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="MID_CATEGORY_NAME" Key="MID_CATEGORY_NAME" Width="100px">
                                            <Header Caption="중분류">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="LOW_CATEGORY_NAME" Key="LOW_CATEGORY_NAME" Width="100px">
                                            <Header Caption="소분류">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ValueList DisplayStyle="NotSet">
                                            </ValueList>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="60px" FooterText="" HeaderText="사용여부">
                                          <Header Caption="사용여부">
                                            <RowLayoutColumnInfo OriginX="5" />
                                          </Header>
                                          <HeaderStyle Wrap="True" />
                                          <CellStyle HorizontalAlign="Center"></CellStyle>
                                          <CellTemplate>
                                            <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                          </CellTemplate>
                                          <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="5" />
                                          </Footer>
                                        </ig:TemplatedColumn>
                                        <ig:UltraGridColumn BaseColumnName="KPI_DESC" HeaderText="KPI 설명" Key="KPI_DESC" Width="400px">
                                            <Header Caption="KPI 설명">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                    </RowTemplateStyle>
                                </ig:UltraGridBand>
                            </Bands>
                             <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" Name="ugrdKPIPool" RowHeightDefault="18px"
                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
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
                                </SelectedRowStyleDefault>--%>
                                <GroupByBox>
                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                </GroupByBox>
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                <ClientSideEvents DblClickHandler="ugrdKPIPool_DblClickHandler" MouseOverHandler="MouseOverHandler" />
                            </DisplayLayout>
                        </ig:UltraWebGrid>
                    </td>
                </tr>
                
                <tr class="cssPopBtnLine">
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left">
                                    <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
                                </td>
			                    <td align="right">
                                   &nbsp<%-- <img alt="" src="../images/btn/b_005.gif" style="cursor:hand;" onclick="OpenInsertWindow();" />--%>
			                    </td>
                            </tr>
                        </table>
    	            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>            
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    
    
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr> 
                    <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                    <td style="width:50%; background-color:#FFFFFF"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</form>
</body>
</html>