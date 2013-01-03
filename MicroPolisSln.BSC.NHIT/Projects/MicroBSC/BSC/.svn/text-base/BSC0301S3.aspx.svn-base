<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0301S3.aspx.cs" Inherits="BSC_BSC0301S3" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
   <script id="Infragistics" type="text/javascript">
    
  
    function ugrdKPIPool_DblClickHandler(gridName, cellId)
    {
        var cell    = igtbl_getElementById(cellId);
        var row     = igtbl_getRowById(cellId);
        var kpiID   = row.getCellFromKey("KPI_POOL_REF_ID").getValue();
        var kpiYN   = row.getCellFromKey("USE_YN").getValue() =='Y'? 'U':'D';
       
        
        var ICCB1 = "<%= this.ICCB1 %>";
        
        var strURL = 'BSC0301M1.aspx?iType=' + kpiYN + '&KPI_POOL_REF_ID='+ kpiID+'&CCB1='+ICCB1;
        gfOpenWindow(strURL, 720, 670,"BSC0301M1");
    }

    function doInsertingKpi(kpiYN, kpiID, ICCB1) {
        
        var strURL = 'BSC0301M1.aspx?iType=' + kpiYN + '&KPI_POOL_REF_ID=' + kpiID + '&CCB1=' + ICCB1;
        gfOpenWindow(strURL, 720, 670, "BSC0301M1");
    }
    
    function OpenInsertWindow()
    {
        var kpiID  = '';
        var ICCB1 = "<%= this.ICCB1 %>";
        
        var strURL = 'BSC0301M1.aspx?iType=A&KPI_POOL_REF_ID='+ kpiID+'&CCB1='+ICCB1;
        gfOpenWindow(strURL, 720, 670, 'BSC0301M1');
        
        return false;
    }


    function doVersion() {
        if (doChecking('ugrdKPIPool')) {

            return true;
        }

        return false;
    }
    
    </script>   

<!--- MAIN START --->	
		<table cellpadding="0" cellspacing="2" border="0"  Width="100%" height="100%">
		    <tr valign="top" style="height: 20px">
			    <td colspan="2">
                    <table class="tableBorder" cellspacing="0" width="100%">
                        <tr>
                            
                            <td class="cssTblTitle">KPI 명</td>
                            <td class="cssTblContent">
                                <asp:TextBox ID="txtKPIName" runat="server" width="100%"></asp:TextBox>
                            </td>
                            
                        
                            <td class="cssTblTitle">KPI 유형</td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlKpiType" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle">버전</td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlKpiVersion" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                            </td>
                            <td class="cssTblTitle">템플릿</td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlKpiTemplete" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle">사용여부</td>
                            <td class="cssTblContent" colspan="3">
                                <asp:dropdownlist runat="server" id="ddlUseYn" Width="41%" CssClass="box01"></asp:dropdownlist>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="height:25px;">
                <td align="left">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left" width="110">
                                <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                    
                </td>
                <td align="right">
                    <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td style="height:100%;" colspan="2" >
		            <ig:UltraWebGrid ID="ugrdKPIPool" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKPIPool_InitializeRow" >
                        <Bands>
                            <ig:UltraGridBand>
                                <Columns>
                                    <ig:TemplatedColumn Key="selchk" Width="25px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellTemplate>
                                            <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer"/>
                                        </CellTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'ugrdKPIPool');" />
                                        </HeaderTemplate>
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:TemplatedColumn>
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
                                    <ig:UltraGridColumn BaseColumnName="KPI_EXTERNAL_TYPE_NAME" Key="KPI_EXTERNAL_TYPE_NAME" Width="80px">
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
                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="80px">
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
                                    <ig:UltraGridColumn BaseColumnName="KPI_DESC" HeaderText="KPI 설명" Key="KPI_DESC" Width="450px">
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
                         <DisplayLayout CellPaddingDefault="2"
                                        AllowColSizingDefault="Free"
                                        AllowColumnMovingDefault="OnServer"
                                        AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes"
                                        BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="NotSet"
                                        Name="ugrdKPIPool"
                                        RowHeightDefault="20px"
                                        RowSelectorsDefault="No"
                                        SelectTypeRowDefault="Extended"
                                        Version="4.00"
                                        ViewType="OutlookGroupBy"
                                        CellClickActionDefault="RowSelect"
                                        TableLayout="Fixed"
                                        StationaryMargins="Header"
                                        AutoGenerateColumns="False" 
                                        ReadOnly="LevelTwo"
                                        OptimizeCSSClassNamesOutput="False">
                            <GroupByBox>
                                <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                            <RowStyleDefault  CssClass="GridRowStyle" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                            <ClientSideEvents DblClickHandler="ugrdKPIPool_DblClickHandler" />
                            </DisplayLayout>
                    </ig:UltraWebGrid>
		        </td>
		    </tr>
		    <tr>
		        <td colspan="2" style="height:3px;">
		            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
		            <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
		        </td>
		    </tr>
		    <tr>
		        <td style="width:50%;">
                    <asp:ImageButton runat="server" ID="iBtnVersion" ImageUrl="../images/btn/btn_Vmanage.gif" ImageAlign="AbsMiddle" onClick="iBtnVersion_Click" />
                    <asp:ImageButton runat="server" ID="iBtnTemplete" ImageUrl="../images/btn/btn_Tmanage.gif" ImageAlign="AbsMiddle" onClick="iBtnTemplete_Click" />
			    </td>
			    <td align="right">
                    <asp:ImageButton runat="server" ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif" ImageAlign="AbsMiddle" OnClientClick="return OpenInsertWindow();" />
			    </td>
		    </tr>
		</table>
	 

  <!--- MAIN END --->
</asp:Content>
