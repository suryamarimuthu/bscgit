<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1003S3.aspx.cs" Inherits="BSC_BSC1003S3"
    EnableEventValidation="false" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script id="Infragistics" type="text/javascript">
<!--
        function draftBatch() {
            var estterm_ref_id = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
            var ICCB1 = "<%= this.ICCB1 %>";

            var url = "BSC0501M4.aspx?IS_TEAM_KPI=N&CCB1=" + ICCB1;

            gfOpenWindow(url, 810, 645, 'yes', 'no', 'BSC0501M4');
            return false;
        }

        function ugrdKpiResultList_DblClickHandler(gridName, cellId) {

            var row = igtbl_getRowById(cellId);
            var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
            var Est_YN = row.getCellFromKey("CHECK_YN").getValue();
            var Confirm_YN = "N";
            var strMM = row.getCellFromKey("YMD").getValue();
            var intEST = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var ICCB1 = "<%= this.ICCB1 %>";

            var url = 'BSC0501M3.aspx?KPI_REF_ID=' + kpiID + '&YMD=' + strMM + '&ESTTERM_REF_ID=' + intEST + '&CCB1=' + ICCB1;

            gfOpenWindow(url
                    , 870
                    , 690
                    , 'no'
                    , 'no'
                    , 'Win5');
        }



        function doPopping_Result(kpiID, strMM, intEST, ICCB1) {
            var url = 'BSC0501M3.aspx?KPI_REF_ID=' + kpiID
                              + '&YMD=' + strMM
                              + '&ESTTERM_REF_ID=' + intEST
                              + '&CCB1=' + ICCB1;

            gfOpenWindow(url
                    , 870
                    , 690
                    , 'no'
                    , 'no'
                    , 'Win5');

        }
// -->
    </script>

    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
        <tr>
            <td>
                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlEstTermInfo" runat="server" class="box01" Width="59%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" />
                            <asp:DropDownList ID="ddlEstTermMonth" runat="server" class="box01" Width="39%">
                            </asp:DropDownList>
                        </td>
                        <td class="cssTblTitle">
                            운영조직
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlEstDept" runat="server" class="box01" Width="99%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <!--<td class="cssTblTitle">
                            <%=this.GetText("LBL_00009", "KPI CODE") %>
                        </td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtKPICode" runat="server" class="box01" Width="100%"></asp:TextBox>
                        </td>
                        -->
                        <td class="cssTblTitle">
                            <%=this.GetText("LBL_00001", "KPI 담당자") %>
                        </td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtChamName" runat="server" class="box01" Width="100%"></asp:TextBox>
                        </td>
                        <td class="cssTblTitle">
                            KPI 명
                        </td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtKPIName" runat="server" class="box01" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            지표유형
                        </td>
                        <td class="cssTblContent" colspan="3">
                            <asp:DropDownList ID="ddlKpiGroupRefID" runat="server" class="box01" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="rowKpiType" runat="server">
                        <td class="cssTblTitle">
                            직무분류
                        </td>
                        <td class="cssTblContent" colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlKpiCategoryTop" Width="33%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryTop_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                    /><asp:DropDownList ID="ddlKpiCategoryMid" Width="33%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryMid_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                    /><asp:DropDownList ID="ddlKpiCategoryLow" Width="33%" runat="server" CssClass="box01" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right">
                <table width="100%">
                    <tr>
                        <td>
                            <img style="vertical-align: middle;" src="../Images/etc/lis_t01.gif" alt="" />
                            <asp:Label ID="lblRowCount" runat="server" Text="0"></asp:Label>
                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif"
                                OnClick="iBtnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 100%">
            <td>
                <ig:UltraWebGrid ID="ugrdKpiResultList" runat="server" Width="100%" Height="100%"
                    OnInitializeRow="ugrdKpiResultList_InitializeRow" OnInitializeLayout="ugrdKpiResultList_InitializeLayout">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn BaseColumnName="KPI_NAME" HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </ig:TemplatedColumn>  
                                
                                 <ig:UltraGridColumn HeaderText="입력대상" Key="CHECK_YN" BaseColumnName="CHECK_YN" Width="80px">
                                    <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                               
                                <ig:UltraGridColumn HeaderText="당월목표" Key="TARGET_MS" BaseColumnName="TARGET_MS" Width="100px"  Format="#,##0.00" >
                                    <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn HeaderText="당월실적" Key="RESULT_MS" BaseColumnName="RESULT_MS" Width="100px"  Format="#,##0.00" >
                                    <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Width="60px" HeaderText="결재상태">
                                    <HeaderStyle Wrap="True" HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <CellTemplate>
                                        <asp:Image runat="server" ID="imgApp" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif">
                                        </asp:Image>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT"
                                    Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn> 
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME"
                                    Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CLASS_NAME" HeaderText="지표구분" Key="CLASS_NAME"
                                    Width="80px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" HeaderText="운영조직" Key="COM_DEPT_NAME"
                                    Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME"
                                    Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                 
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" DataType="System.Int16" HeaderText="KPI 코드"
                                    Key="KPI_CODE" Width="75px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표유형" Key="KPI_GROUP_NAME"
                                    Width="80px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_NAME" HeaderText="직무분류" Key="CATEGORY_NAME"
                                    Width="80px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn HeaderText="실적입력" Key="CHECKSTATUS" BaseColumnName="CHECKSTATUS"
                                    Width="80px" Hidden="true">
                                    <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" DataType="System.Int32"
                                    Key="ESTTERM_REF_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Hidden="True" DataType="System.Int32"
                                    Key="KPI_REF_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Hidden="true" Key="YMD">
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                                        <DisplayLayout CellPaddingDefault="1" 
                                    AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="None" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="ugrdKpiResultList" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
                                    OptimizeCSSClassNamesOutput="False">
                       
                        <GroupByBox>
                            <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                       <ClientSideEvents RowSelectorClickHandler="RowSelectorClickHandler" DblClickHandler="ugrdKpiResultList_DblClickHandler" />
                    </DisplayLayout>
                  
                </ig:UltraWebGrid>
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 25px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" style="padding-right: 5px;">
                            <asp:ImageButton runat="server" ID="ibtnDraftBatch" ImageUrl="../images/btn/btn_draft_batch.gif"
                                ImageAlign="AbsMiddle" OnClientClick="return draftBatch();" />
                        </td>
                    </tr>
                </table>
                <asp:LinkButton ID="lBtnReload" Visible="false" runat="server" OnClick="lBtnReload_Click">Refresh Result Grid</asp:LinkButton>
                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <!--- MAIN END --->
</asp:Content>
