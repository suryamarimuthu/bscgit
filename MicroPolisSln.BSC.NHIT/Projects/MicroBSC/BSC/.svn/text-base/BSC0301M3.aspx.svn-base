<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0301M3.aspx.cs" Inherits="BSC_BSC0301M3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>성과관리 시스템::KPI 수정</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script id="Infragistics" type="text/javascript">

    function doClickingGrid(gridName, id) {
        var cell = igtbl_getElementById(id);
        var row = igtbl_getRowById(id);
        var kpi_pool_ver_id = row.getCellFromKey("KPI_POOL_VER_ID").getValue();
        var kpi_pool_ver_name = row.getCellFromKey("KPI_POOL_VER_NAME").getValue();
        var kpi_pool_ver_note = row.getCellFromKey("KPI_POOL_VER_NOTE").getValue();

        var hdfMapYN = row.getCellFromKey("MAP_YN").getValue();
        
        
        document.getElementById('txtKpiPoolVerID').value = kpi_pool_ver_id;
        document.getElementById('txtKpiPoolVerName').value = kpi_pool_ver_name;
        document.getElementById('txtKpiPoolVerNote').value = kpi_pool_ver_note;

        document.getElementById('hdfMapYN').value = hdfMapYN;
    }

    function doSaving() {
        var name = document.getElementById('txtKpiPoolVerName').value;

        if (name.length == 0) {
            alert('KPI Pool 버전명을 입력하세요');
            return false;
        }
    }

    function doKpiPoolSaving() {
        var id = document.getElementById('txtKpiPoolVerID').value;

        if (id.length == 0) {
            alert('선택된 버전이 없습니다.');
            return false;
        }
        else {
            if (document.getElementById('hdfMapYN').value == "Y") {
                return confirm('기존에 맵핑된 데이터는 삭제 됩니다. 계속 할까요?');
            }
        }
    }

    function doSelecting() {
        var id = document.getElementById('txtKpiPoolVerID').value;

        if (id.length == 0) {
            alert('선택된 버전이 없습니다.');
            return false;
        }
    }

    function doReset() {
        document.getElementById('txtKpiPoolVerID').value = '';
        document.getElementById('txtKpiPoolVerName').value = '';
        document.getElementById('txtKpiPoolVerNote').value = '';

        document.getElementById('txtKpiPoolVerName').focus();
        return false;
    } 
    
</script>
<script src="../_common/js/iezn_embed_patch.js" type="text/javascript"></script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
  <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr> 
                    <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td  style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t10_01.gif" /></td>
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
                    <tr style="height:100%;">
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0" style="width:100%; height:100%;">
                                <tr> 
                                    <td>
                                        <ig:UltraWebGrid ID="ugrdKPIPoolVer" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKPIPoolVer_InitializeRow"
                                             OnSelectedRowsChange="ugrdKPIPoolVer_SelectedRowsChange">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <Columns>
                                                            <ig:TemplatedColumn Key="selchk" Width="25px" Hidden="true">
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
                                                            <ig:UltraGridColumn BaseColumnName="KPI_POOL_VER_ID" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="KPI_POOL_VER_ID" Key="KPI_POOL_VER_ID" Width="145px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="KPI 풀(POOL) 버전">
                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                </Header>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_POOL_VER_NAME" Key="KPI_POOL_VER_NAME" Width="150px">
                                                                <Header Caption="KPI 풀(POOL) 버전명">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ValueList DisplayStyle="NotSet">
                                                                </ValueList>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_POOL_VER_NOTE" Key="KPI_POOL_VER_NOTE" Width="400px">
                                                                <Header Caption="KPI 풀(POOL) 설명">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ValueList DisplayStyle="NotSet">
                                                                </ValueList>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_POOL_VER_DATE" Key="KPI_POOL_VER_DATE" Width="70px" Hidden="true">
                                                                <Header Caption="KPI 유형">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ValueList DisplayStyle="NotSet">
                                                                </ValueList>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="" Key="MAP_YN" Width="80px">
                                                                <Header Caption="맵핑">
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ValueList DisplayStyle="NotSet">
                                                                </ValueList>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                        </Columns>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                 <DisplayLayout AllowColSizingDefault="Free"
                                                                AllowDeleteDefault="Yes"
                                                                AllowSortingDefault="Yes"
                                                                BorderCollapseDefault="Separate"
                                                                HeaderClickActionDefault="NotSet"
                                                                Name="ugrdKPIPoolVer"
                                                                RowHeightDefault="20px"
                                                                RowSelectorsDefault="No"
                                                                SelectTypeRowDefault="Extended"
                                                                Version="4.00"
                                                                CellClickActionDefault="RowSelect"
                                                                TableLayout="Fixed"
                                                                StationaryMargins="Header"
                                                                AutoGenerateColumns="False" 
                                                                OptimizeCSSClassNamesOutput="False">
                                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                    <ClientSideEvents CellClickHandler="doClickingGrid" />
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssPopBtnLine">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
	                            <tr>
	                                <td class="content" align="left">
	                                </td>
		                            <td class="content" align="right">
		                                <asp:ImageButton ID="iBtnSaveVer" ImageUrl="../images/btn/btn_Vcreate.gif" runat="server" OnClick="iBtnSaveVer_Click" OnClientClick="return doKpiPoolSaving();"  />
		                            </td>
	                            </tr>
	                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%"> 
                                <tr>
                                     <td>
                                        <table class="tableBorder" cellspacing="0" width="100%">
                                            <tr>
                                                
                                                <td class="cssTblTitle" style="width:200px;" ><%=this.GetText("LBL_00014","버전") %></td>
                                                <td class="cssTblContent" style="width:200px;">
                                                    <asp:TextBox ID="txtKpiPoolVerID" runat="server" width="100%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                
                                            
                                                <td class="cssTblTitle" style="width:200px;"><%=this.GetText("LBL_00015","버전명") %></td>
                                                <td class="cssTblContent">
                                                    <asp:TextBox ID="txtKpiPoolVerName" runat="server" width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle" style="width:200px;"><%=this.GetText("LBL_00016","설명") %></td>
                                                <td class="cssTblContent" colspan="3">
                                                    <asp:TextBox ID="txtKpiPoolVerNote" runat="server" TextMode="MultiLine" Height="50px" width="100%"></asp:TextBox>
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
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
	                            <tr>
	                                <td class="content">
	                                </td>
		                            <td class="cssPopBtnLine">
		                                <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif" runat="server" OnClick="iBtnInsert_Click"/>
		                                <asp:ImageButton ID="iBtnSave" ImageUrl="../images/btn/btn_Vsave.gif" runat="server" OnClick="iBtnSave_Click"  />		                    
		                                <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/btn_Vdelete.gif" runat="server" OnClick="iBtnDelete_Click"  OnClientClick="return doSelecting();"  />		                    
                                        <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server" OnClientClick="window.close();"  />
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
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                        <td style="width:50%; height:4px; background-color:#FFFFFF">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            <asp:Literal ID="ltrScript" runat="server" Text="" ></asp:Literal>
                            <asp:HiddenField ID="hdfMapYN" runat="server" ></asp:HiddenField>
                        </td>
                        <td style="width:50%; background-color:#FFFFFF"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
  </form>
</body>
</html>
