<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0401S1.aspx.cs" Inherits="BSC_BSC0401S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

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
            var intEstTermID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo) %>";
            var intEstDeptID = "<%= this.IEstDeptRefID%>";
            var strYMD       = "<%= PageUtility.GetByValueDropDownList(ddlEstTermMonth)%>";
            
            var strURL       = "../BSC/BSC0401M1.aspx?EST_DEPT_REF_ID="+intEstDeptID+"&ESTTERM_REF_ID="+intEstTermID+"&YMD="+strYMD;
            gfOpenWindow(strURL, 1000, 620,0,0,'BSC0401M1'); 
        }
        
        
        function openFullStgMap()
        {
            var intEstTermID  = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo) %>";
            var intEstDeptID  = "<%= this.IEstDeptRefID%>";
            var strYMD        = "<%= PageUtility.GetByValueDropDownList(ddlEstTermMonth)%>";
            var intMapVersion = "<%= this.IMapVersionID%>";

            var url = '../usr/usr_stg_map.aspx?ESTTERM_REF_ID=' + intEstTermID + '&EST_DEPT_REF_ID=' + intEstDeptID + '&MAP_VERSION_ID=' + intMapVersion + '&TMCODE=' + strYMD + '&LINE_TYPE=0&SHOW_KPI_LIST=1&FULLSCREEN=Y';
            
            var wo  = window.open(url, 'WinPop','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=yes,resizable=0,top=0,left=0,width=screen.width, height=screen.height');
            wo.resizeTo(screen.width,screen.height);
        }
    </script>

<!--- MAIN START --->
		<table cellpadding="0" cellspacing="0" border="0" height="100%" width="100%">
		<tr valign="top">
			<td colspan="2">
                <div style=" overflow:auto; width:100%; height:100%;">
                    <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%">
                    <tr>
                        <td width="5px">
                    <!--- Tree  --->	
                        <div id="leftLayer" style="border:#F4F4F4 1 solid; DISPLAY:block; overflow: auto; position:static; 
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
                    <!--- /Tree  --->
            	        </td>
                        <td width="5px">
                        <!--- 이미지  --->	
                        <a href="javascript:hiddenMemo();"><img alt="" src="../images/btn/btn_Hide.gif" id="imgHide" /></a><br />
                        <a href="javascript:showMemo();"><img alt="" src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" /></a>
                        </td>
                        <td valign="top">
                          <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%; vertical-align:top;">
                            <tr>
                              <td valign="top">
	                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
	                               <tr>
		                               <td class="cssTblTitle">평가기간</td>
		                               <td class="cssTblContent">
                                          <asp:DropDownList ID="ddlEstTermInfo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" Width="65%" CssClass="box01" 
                                          /><asp:DropDownList ID="ddlEstTermMonth" runat="server" CssClass="box01" Width="34%" ></asp:DropDownList>
                                       </td>
		                               <td class="cssTblTitle">평가조직</td>
		                               <td class="cssTblContent">
                                            <asp:Literal ID="ltEstDeptName" runat="server"></asp:Literal>&nbsp;
                                       </td>
	                               </tr>
	                               <tr>
		                               <td class="cssTblTitle">조직비젼</td>
		                               <td class="cssTblContent">
		                                 <asp:Label   ID="lblSTGMapName" Width="100%" runat="server"></asp:Label>
		                               </td>
		                               <td class="cssTblTitle"><%=GetText("LBL_00001", "챔피언") %></td>
		                               <td class="cssTblContent">
		                                 <asp:Label ID="lblChampName" runat="server" Width="100%"></asp:Label>
		                               </td>
	                               </tr>
	                            </table>   
                              </td>
                            </tr>
                            <tr style="height:25px;">
                              <td align="right">
                                <asp:ImageButton ID="iBtnSelect" runat="server" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSelect_Click" />
                              </td>
                            </tr>
                            <tr style="height:100%;">
                              <td>
                                  <ig:UltraWebGrid ID="ugrdStgList" runat="server"  Width="100%" Height="100%">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="VIEW_NAME" HeaderText="관점" Key="VIEW_NAME"
                                                    MergeCells="True" Width="86px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="관점">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STG_REF_ID" FooterText="" HeaderText="전략 ID"
                                                    Key="STG_REF_ID" Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="전략 ID">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn BaseColumnName="STG_NAME" FooterText="" HeaderText="전략명" Key="STG_NAME"
                                                    Width="260px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="전략명">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="WEIGHT" FooterText="가중치" Format="###,###,##0.00"
                                                    HeaderText="가중치" Key="WEIGHT" Width="55px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="가중치">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Footer Caption="가중치">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PARENT_STG" CellMultiline="Yes" HeaderText="상위전략"
                                                    Key="PARENT_STG" Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상위전략">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout  AllowColSizingDefault="Free"
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
                                                    ViewType="OutlookGroupBy"
                                                    ReadOnly="LevelTwo"
                                                    OptimizeCSSClassNamesOutput="False">
                                        <%--
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
                                        </AddNewBox>--%>
                                        
                                        <GroupByBox Hidden="True">
                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                        </GroupByBox>
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                              </td>
                            </tr>
                            <tr style="height:25px;">
                                <td align="right">
                                    <img alt="" src="../images/btn/b_002.gif" style="cursor:hand;" onclick="OpenMgmMap();" />
                                    <img alt="" src="../images/btn/b_135.gif" style="cursor:hand;" onclick="openFullStgMap();" />
                                    <asp:ImageButton ID="iBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClick="iBtnPrint_Click" />
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
        &nbsp;
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
        
        <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport">
        </ig:UltraWebGridExcelExporter>
<!--- MAIN END --->
</asp:Content>