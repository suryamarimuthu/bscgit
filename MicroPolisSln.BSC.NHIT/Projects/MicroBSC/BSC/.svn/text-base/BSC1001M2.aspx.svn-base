<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1001M2.aspx.cs" Inherits="BSC_BSC1001M2" %>

<!--DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"-->

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
      <script id="Infragistics" type="text/javascript">
        function OpenPreviewWindow()
        {
            
            var strURL = 'BSC0601S1.aspx?iType=P&DICODE='+ Dicode+'&CCB1='+ICCB1;
            
            gfOpenWindow(strURL, 800, 600, 'BSC0601S1');
            
            return false;
        }

        function doSaving() {
            if (doChecking('UltraWebGrid2')) {

                return confirm("저장 하시겠습니까?");
            }

            return false;

        }
        
        function doLinking_Pool(kpiID) {

            var ICCB1 = "<%= this.ICCB1 %>";

            var strURL = 'BSC0301M1.aspx?iType=X&KPI_POOL_REF_ID=' + kpiID;
            gfOpenWindow(strURL, 720, 670, "doLinking_Pool");
            
        }

  </script>

</head>
<body style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
<form id="form1" runat="server">

<!--- MAIN START --->
<table width="100%" cellpadding="0" cellspacing="0" style="height:100%;" border="0">
    <tr>
        <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr style="height:40px; background-image:url(../images/title/popup_t_bg.gif);"> 
                                <td style="width:170px; height:40px; background-image:url(../images/title/popup_title.gif);" class="cssPopTitleArea">
                                  <asp:Label ID="lblPopUpTitle" runat="server" Text="탬플릿 KPI" CssClass="cssPopTitleTxt"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width:140px; height:40px; background-image:url(../images/title/popup_img.gif); vertical-align:middle;">&nbsp;</td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                                <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                                <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                            </tr>
                        </table>
        </td>
    </tr>
    
    <tr class="cssPopContent">
        <td>
            <table width="100%" cellpadding="0" cellspacing="0" style="height:100%;" border="0">
                <tr>
                    <td>
                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                            <tr>
                                <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="탬플릿"/></td>
                            </tr>
                        </table>
                    </td>
                    <td></td>
                    <td>
                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                            <tr>
                                <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="KPI 목록"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
                   <td style="width:40%;height:100%;">
                      <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange" >
                            <Bands>
                                <ig:UltraGridBand>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="KPI_POOL_TEMPLETE_ID" Key="KPI_POOL_TEMPLETE_ID" Width="10%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="코드">
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="KPI_POOL_TEMPLETE_NAME" Key="KPI_POOL_TEMPLETE_NAME" Width="80%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="탬플릿 명">
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="" Key="KPI_CNT" Width="10%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="갯수">
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout CellPaddingDefault="2" 
                                            AllowColSizingDefault="Free" 
                                            AllowColumnMovingDefault="None" 
                                            AllowDeleteDefault="No"
                                            AllowSortingDefault="Yes" 
                                            BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="NotSet" 
                                            Name="UltraWebGrid1" 
                                            RowHeightDefault="20px" 
                                            RowSelectorsDefault="No" 
                                            SelectTypeRowDefault="Extended" 
                                            Version="4.00" 
                                            CellClickActionDefault="RowSelect" 
                                            TableLayout="Fixed" 
                                            StationaryMargins="Header" 
                                            OptimizeCSSClassNamesOutput="False"
                                            AutoGenerateColumns="False">
                                <GroupByBox>
                                    <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                                </GroupByBox>
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                <HeaderStyleDefault CssClass="GridHeaderStyle"  ></HeaderStyleDefault>                                   
                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                <%--<ClientSideEvents DblClickHandler="ugrdDeptKpi_DblClickHandler" />--%>
                            </DisplayLayout>
                        </ig:UltraWebGrid>   
                   </td>
                   <td style="width:1%;">
                     <asp:DropDownList ID="ddlUnit_Hdf" runat="server" Visible="false"></asp:DropDownList>
                     <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                   </td>
                   <td style="width:59%;">
                      <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdDeptKpi_InitializeRow" OnInitializeLayout="ugrdDeptKpi_InitializeLayout" >
                            <Bands>
                                <ig:UltraGridBand>
                                    <Columns>
                                        <ig:TemplatedColumn Key="selchk" Width="6%">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'UltraWebGrid2');" />
                                                <%--<img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox(this,'ugrdDeptKpi');" />--%>
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <CellTemplate>
                                                <asp:checkbox id="cBox" runat="server" style="cursor:pointer"/>
                                            </CellTemplate>
                                        </ig:TemplatedColumn>
                                        
                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="60%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="KPI 명">
                                            </Header>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="KPI_EXTERNAL_TYPE_NAME" Key="KPI_EXTERNAL_TYPE_NAME" Width="17%">
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
                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="17%">
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
                                        <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout CellPaddingDefault="2" 
                                            AllowColSizingDefault="Free" 
                                            AllowColumnMovingDefault="None" 
                                            AllowDeleteDefault="No"
                                            AllowSortingDefault="Yes" 
                                            BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="NotSet" 
                                            Name="UltraWebGrid2" 
                                            RowHeightDefault="20px" 
                                            RowSelectorsDefault="No" 
                                            SelectTypeRowDefault="Extended" 
                                            Version="4.00" 
                                            CellClickActionDefault="RowSelect" 
                                            TableLayout="Fixed" 
                                            StationaryMargins="Header" 
                                            OptimizeCSSClassNamesOutput="False"
                                            ReadOnly="LevelTwo"
                                            AutoGenerateColumns="False">
                                <GroupByBox>
                                    <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                                </GroupByBox>
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                <HeaderStyleDefault CssClass="GridHeaderStyle"  ></HeaderStyleDefault>                                   
                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                <%--<ClientSideEvents DblClickHandler="ugrdDeptKpi_DblClickHandler" />--%>
                            </DisplayLayout>
                        </ig:UltraWebGrid>   
                   </td>
                 </tr>
                 <tr >
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="height:100%;  width:100%;" border="0">
                            <tr>
                                <td >
                                </td>
                                <td class="cssPopBtnLine">
                                    <asp:ImageButton ID="iBtnSave" ImageUrl="~/images/btn/b_tp07.gif" runat="server" OnClick="iBtnSave_Click" OnClientClick="return doSaving();" AlternateText="저장" />
                                    <%--<asp:ImageButton ID="iBtnClose" ImageUrl="~/images/btn/b_003.gif" runat="server" OnClick="iBtnClose_Click" AlternateText="닫기" />--%>
                                    <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/btn/b_003.gif" runat="server" OnClientClick="window.close();" AlternateText="닫기" />
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
                    <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                    <td style="width:50%; background-color:#FFFFFF"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<!--- MAIN END --->
</form>
</body>
</html>