<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1104S1.aspx.cs" Inherits="PRJ_PRJ1104S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script type="text/javascript" language="javascript">
        function showMemo() 
        {
            document.all.imgShow.style.display      = "none";
            document.all.imgHide.style.display      = "block";
	        document.all.leftLayer.style.display    = "block";
        }

        function hiddenMemo() 
        {
            document.all.imgShow.style.display      = "block";
            document.all.imgHide.style.display      = "none";
	        document.all.leftLayer.style.display    = "none";
        }
        
        function OpenMgmMap()
        {
            var intEstTermID = "<%= this.IESTTERM_REF_ID %>";
            var intEstDeptID = "<%= this.IEST_DEPT_REF_ID %>";
            
            var strURL       = "../PRJ/PRJ1104M1.aspx?EST_DEPT_REF_ID="+intEstDeptID+"&ESTTERM_REF_ID="+intEstTermID;
            gfOpenWindow(strURL, 1000, 620, 0, 0, 'PRJ1104M1');
            return false;
        }
        
        function openFullStgMap()
        {
            var intEstTermID = "<%= this.IESTTERM_REF_ID %>";
            var intEstDeptID = "<%= this.IEST_DEPT_REF_ID %>";
            var intMapVersion = "<%= this.IMAP_VERSION_ID %>";
            var intTermMonth = "<%= this.ITERM_MONTH %>";

            var url = '../usr/usr_stg_map.aspx?ESTTERM_REF_ID=' + intEstTermID + '&EST_DEPT_REF_ID=' + intEstDeptID + '&MAP_VERSION_ID=' + intMapVersion + '&TMCODE=' + intTermMonth + '&LINE_TYPE=0&SHOW_KPI_LIST=1&DRAWING_YN=Y&WORKINGMAPYN=Y';
            
            var wo  = window.open(url, 'WinPop','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=yes,resizable=0,top=0,left=0,width=screen.width, height=screen.height');
            wo.resizeTo(screen.width, screen.height);
            return false;
        }
    </script>

    <!--- MAIN START --->
	<table cellpadding="0" cellspacing="0" border="0" style="height: 100%;" width="100%">
	    <tr valign="top">
			<td colspan="2">
                <div style=" overflow:auto; width:100%; height:100%;">
                    <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%">
                        <tr>
                            <td width="5px">
                                <!--- Tree  --->	
                                <div id="leftLayer" style="border:#E9EBEB 1px solid; DISPLAY:block; overflow: auto; position:static; 
                                    width: 200px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                                    <asp:TreeView ID="trvEstDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged">
                                        <ParentNodeStyle Font-Bold="False" />
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                            VerticalPadding="0px" />
                                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                            NodeSpacing="0px" VerticalPadding="0px" />
                                    </asp:TreeView>
                                </div>
            	            </td>
                            <td width="7px">
                                <!--- 이미지  --->	
                                <a href="javascript:hiddenMemo();"><img alt="" src="../images/btn/btn_Hide.gif" id="imgHide" /></a><br />
                                <a href="javascript:showMemo();"><img alt="" src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" /></a>
                            </td>
                            <td valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%; vertical-align:top;">
                                    <tr>
                                        <td valign="top" style="height:60px;">
	                                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
	                                            <colgroup>
	                                                <col width="80px" />
	                                                <col width="350px" />
	                                                <col width="80px" />
	                                                <col width="500px" />
	                                            </colgroup>
	                                            <tr>
		                                            <td class="tabletitle2" align="center">평&nbsp;가&nbsp;기&nbsp;간</td>
		                                            <td class="tableContent">
                                                        <asp:DropDownList ID="ddlEstTermInfo" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" CssClass="box01" ></asp:DropDownList>
                                                    </td>
		                                           <td class="tabletitle2" align="center">평&nbsp;가&nbsp;조&nbsp;직</td>
		                                           <td class="tableContent">
                                                        <asp:Literal ID="ltEstDeptName" runat="server"></asp:Literal>&nbsp;
                                                   </td>
	                                            </tr>
                                                <tr>
		                                            <td class="tabletitle2" align="center">조&nbsp;직&nbsp;비&nbsp;젼</td>
		                                            <td class="tableContent" colspan="3" >
		                                                <asp:Label ID="lblSTGMapName" Width="98%" runat="server"></asp:Label>&nbsp;
		                                            </td>
	                                            </tr>
	                                            <tr>
		                                            <td class="tableTitle" align="center">BSC Champion</td>
		                                            <td class="tableContent"  colspan="3">
		                                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
		                                                    <tr>
		                                                        <td>
		                                                            <asp:Label ID="lblChampName" runat="server" Width="98%"></asp:Label>
		                                                        </td>
                                                                <td align="right" class="tableContent" valign="middle">
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/btn/b_002.gif" ImageAlign="AbsMiddle" OnClientClick="return OpenMgmMap();" />
                                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/btn/b_216.gif" ImageAlign="AbsMiddle" OnClientClick="return openFullStgMap();" />
                                                                    <asp:ImageButton ID="iBtnSelect" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle" OnClick="iBtnSelect_Click" />
                                                                    <asp:ImageButton ID="iBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  ImageAlign="AbsMiddle" OnClick="iBtnPrint_Click" />
                                                                    &nbsp;
                                                                </td>
		                                                    </tr>
		                                                </table>
		                                            </td>
	                                            </tr>
	                                        </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ig:UltraWebGrid ID="ugrdStgList" runat="server"  Width="100%" Height="100%" OnInitializeRow="ugrdStgList_InitializeRow">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:UltraGridColumn BaseColumnName="VIEW_NAME" MergeCells="true" HeaderText="관점" Key="VIEW_NAME" Width="86px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID" HeaderText="전략 ID" Key="STG_REF_ID" Width="70px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:TemplatedColumn BaseColumnName="STG_NAME" HeaderText="전략명" Key="STG_NAME" Width="260px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <ValueList DisplayStyle="NotSet">
                                                                </ValueList>
                                                            </ig:TemplatedColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_COUNT" HeaderText="중점과제 수" Key="WORK_COUNT" Width="90px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_COUNT" HeaderText="실행과제 수" Key="EXEC_COUNT" Width="90px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" Key="EST_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID" Key="STG_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" Key="WORK_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_REF_ID" Key="EXEC_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout AllowColSizingDefault="Free" 
                                                    AllowColumnMovingDefault="OnServer" 
                                                    AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="Yes" 
                                                    AutoGenerateColumns="False" 
                                                    BorderCollapseDefault="Separate"
                                                    CellClickActionDefault="RowSelect" 
                                                    CellPaddingDefault="2" 
                                                    HeaderClickActionDefault="SortMulti"
                                                    Name="ugrdStgList" 
                                                    RowHeightDefault="20px" 
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended"
                                                    StationaryMargins="Header" 
                                                    TableLayout="Fixed" 
                                                    Version="4.00" 
                                                    ViewType="OutlookGroupBy">
                                                    <GroupByBox Hidden="True">
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
                                                    </AddNewBox>
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
	        </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>    
    <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport">
    </ig:UltraWebGridExcelExporter>
    <!--- MAIN END --->
</asp:Content>