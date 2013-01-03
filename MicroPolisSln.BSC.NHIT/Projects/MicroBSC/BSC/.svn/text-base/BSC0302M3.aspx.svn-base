<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0302M3.aspx.cs" Inherits="BSC_BSC0302M3" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC::성과관리 시스템::KPI 결재일괄요청</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script id="Infragistics" type="text/javascript">
    var param1 = false;

    function selectChkBox(chkChild) {
        var _elements = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++) {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type == "checkbox") {
                if (param1) {
                    _elements[i].checked = false;
                }
                else {
                    _elements[i].checked = true;
                }
            }
        }

        param1 = (param1 == true) ? false : true;
    }
    function ugrdKpiList_DblClickHandler(gridName, cellId) {
        var cell = igtbl_getElementById(cellId);
        var row = igtbl_getRowById(cellId);
        var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
        var estterm_ref_id = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var ICCB1 = "<%= this.ICCB1 %>";

        var url = 'BSC0302M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB1;
        //gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');

        gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1_' + kpiID);
    }

    function onDraft() {
        
        var kpi_ref_id = "";
        var ugrd = igtbl_getGridById('ugrdDraft');
        for (var i = 0; i < ugrd.Rows.length; i++) {
            var tRow = ugrd.Rows.getRow(i);
            var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
            if (chkYN.checked) {
                kpi_ref_id += tRow.getCellFromKey("KPI_REF_ID").getValue() + ",";
            }
        }
        if (kpi_ref_id == "") {
            alert('일괄결재할 KPI를 선택하세요!');
            return false;
        }
        
        var e = document.getElementById('ddlDraftTerm');
        var estterm_ref_id = e.options[e.selectedIndex].value;
        var biz_type = "<%= Biz_Type.biz_type_kpi_docbatch %>";
        
        kpi_ref_id = kpi_ref_id.substring(0, kpi_ref_id.length - 1);
        var app_ccb         = "<%= this.ICCB2 %>";
        var url             = "BSC0901M3.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id+"&APP_CCB="+app_ccb+"&BIZ_TYPE="+biz_type;
        gfOpenWindow(url, 900, 680, 'BSC0901M3'); // 728
        
        return false;
    }
</script>
<script src="../_common/js/iezn_embed_patch.js" type="text/javascript"></script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <table  width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
            <tr>
                <td style="width:100%;" >
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr> 
                                    <td  style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t11.gif" /></td>
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
                                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="cssTblTitle">평가기간</td>
                                        <td class="cssTblContent">
                                            <asp:dropdownlist id="ddlDraftTerm" CssClass="box01" runat="server" width="100%"></asp:dropdownlist>
                                        </td>
                                        <td class="cssTblTitle">지표유형</td>
                                        <td class="cssTblContent">
                                            <asp:dropdownlist id="ddlDraftKpiType" CssClass="box01" runat="server" width="99%"></asp:dropdownlist>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle">실적방식</td>
                                        <td class="cssTblContent" style="border-right:none;">
                                            <asp:dropdownlist id="ddlDraftResultType" CssClass="box01" runat="server" width="99%" visible="true"></asp:dropdownlist>
                                        </td>
                                        <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                        <td class="cssTblContent">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="cssPopBtnLine">
                            <td>
                                <asp:ImageButton id="ibtnSearch" onclick="ibtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                            </td>
                        </tr>
                        <tr style="height:100%;">
                            <td>
                                <ig:UltraWebGrid ID="ugrdDraft" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdDraft_InitializeRow" OnInitializeLayout="ugrdDraft_InitializeLayout" >
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed">
                                                    <HeaderTemplate>
                                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdDraft')" />
                                                    </HeaderTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <CellTemplate>
                                                        <asp:checkbox id="cBox" runat="server" />
                                                    </CellTemplate>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <Header Caption="KPI 코드">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="KPI 명">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI 담당자" Key="CHAMPION_EMP_NAME" Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="KPI 담당자">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="지표유형">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="단위">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID=""
                                                    FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="실적방식">
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="60px" FooterText="" HeaderText="사용여부">
                                                  <Header Caption="사용여부">
                                                  </Header>
                                                  <HeaderStyle Wrap="True" />
                                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                                  <CellTemplate>
                                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                  </CellTemplate>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID="" Width="60px" FooterText="" HeaderText="APP_STATUS">
                                                  <Header Caption="결재상태">
                                                  </Header>
                                                  <HeaderStyle Wrap="True" />
                                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                                  <CellTemplate>
                                                    <asp:image runat="server" id="imgApp" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                  </CellTemplate>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                </ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                     <DisplayLayout CellPaddingDefault="2" 
                                                    AllowColSizingDefault="Free" 
                                                    AllowColumnMovingDefault="None" 
                                                    AllowDeleteDefault="No"
                                                    AllowSortingDefault="No"
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="NotSet"
                                                    Name="ugrdDraft" 
                                                    RowHeightDefault="20px" 
                                                    HeaderStyleDefault-Height="22px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended"
                                                    Version="4.00" 
                                                    ViewType="Flat"
                                                    CellClickActionDefault="RowSelect" 
                                                    TableLayout="Fixed" 
                                                    StationaryMargins="Header" 
                                                    AutoGenerateColumns="False">
                                            <%--<GroupByBox>
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
                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                            </SelectedRowStyleDefault>--%>
                                            <ClientSideEvents DblClickHandler="ugrdKpiList_DblClickHandler" />
                                            
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                        </DisplayLayout>
                                </ig:UltraWebGrid>
                                <asp:Literal ID="ltrScript" runat="server" Text="" ></asp:Literal>
                                <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
                                <asp:linkbutton id="lBtnReload2" runat="server" OnClick="lBtnReload2_Click"></asp:linkbutton>
                            </td>
                        </tr>
                        <tr class="cssPopBtnLine">
                            <td>
                                <asp:ImageButton id="ibtnDraft" runat="server" ImageUrl="../images/draft/draft.gif" ImageAlign="AbsMiddle" OnClientClick="return onDraft();"></asp:ImageButton>
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