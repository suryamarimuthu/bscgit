<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0902M1.aspx.cs" Inherits="BSC_BSC0902M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
    <script type="text/javascript">
        function confirmUpDown(objID) {
            if ('<%= this.IBIZ_TYPE %>' == '') {
                alert('업무유형을 선택하세요!');
                return false;
            }
            
            var ugrd;
            if (objID == '11' || objID == '21')
                ugrd = igtbl_getGridById('<%= ugrdFixEmp.ClientID %>');
            else if (objID == '12' || objID == '22')
                ugrd = igtbl_getGridById('<%= ugrdSignerEmp.ClientID %>');

            if (igtbl_getActiveRow(ugrd.Id) == null) {
                alert("순서변경할 라인을 선택하세요.");
                return false;
            }
            if (ugrd.Rows.length == 1 || (igtbl_getActiveRow(ugrd.Id).getIndex() == 0 && objID.substring(0, 1) == "1") || (igtbl_getActiveRow(ugrd.Id).getIndex() == ugrd.Rows.length - 1 && objID.substring(0, 1) == "2"))
                return false;                

            visibleLoading();
            return true;
        }
        
        function visibleLoading() {
            var div1 = document.getElementById('<%= div1.ClientID %>');
            div1.style.top = (document.body.offsetHeight / 2) - (div1.offsetHeight / 2);
            div1.style.left = (document.body.offsetWidth / 2) - (div1.offsetWidth / 2);
            div1.style.display = "block";
        }
        function hideLoading() {
            var div1 = document.getElementById('<%= div1.ClientID %>');
            div1.style.display = "none";
        }

        function confirmSel(objID) {
            if ('<%= this.IBIZ_TYPE %>' == '') {
                alert('업무유형을 선택하세요!');
                return false;
            }
            
            if (objID == '21' || objID == '22' || objID == '23') {
                var ugrd = igtbl_getGridById('<%= ugrdEmpList.ClientID %>');
                var isSelected = false;
                var ugrdDestination;
                if (objID == '21')
                    ugrdDestination = igtbl_getGridById('<%= ugrdFixEmp.ClientID %>');
                else if (objID == '22')
                    ugrdDestination = igtbl_getGridById('<%= ugrdSignerEmp.ClientID %>');
                else if (objID == '23')
                    ugrdDestination = igtbl_getGridById('<%= ugrdDraftEmp.ClientID %>');

                var ugrdFix = igtbl_getGridById('<%= ugrdFixEmp.ClientID %>');
                var ugrdApp = igtbl_getGridById('<%= ugrdSignerEmp.ClientID %>');
                var ugrdDraft = igtbl_getGridById('<%= ugrdDraftEmp.ClientID %>');

                for (var i = 0; i < ugrd.Rows.length; i++) {
                    var tRow = ugrd.Rows.getRow(i);
                    var e = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                    if (e.checked) {
                        if (tRow.getCellFromKey("EXIST_YN").getValue() == "Y" && objID == '23') {
                            alert(tRow.getCellFromKey("EMP_NAME").getValue() + "님은 이미 상신자정보가있습니다!\n이름을 클릭하세요.");
                            return false;
                        }
                        isSelected = true;
                        if (objID == '22') {
                            for (var j = 0; j < ugrdFix.Rows.length; j++) {
                                if (ugrdFix.Rows.getRow(j).getCellFromKey("EMP_REF_ID").getValue() == tRow.getCellFromKey("EMP_REF_ID").getValue()) {
                                    alert(tRow.getCellFromKey("EMP_NAME").getValue() + "님은 이미 필수결재선에 등록되어있습니다!");
                                    return false;
                                }
                            }
                            for (var j = 0; j < ugrdDraft.Rows.length; j++) {
                                if (ugrdDraft.Rows.getRow(j).getCellFromKey("EMP_REF_ID").getValue() == tRow.getCellFromKey("EMP_REF_ID").getValue()) {
                                    alert(tRow.getCellFromKey("EMP_NAME").getValue() + "님은 이미 결재상신자에 등록되어있습니다!");
                                    return false;
                                }
                            }
                        }
                        if (objID == '21') {
                            for (var j = 0; j < ugrdApp.Rows.length; j++) {
                                if (ugrdApp.Rows.getRow(j).getCellFromKey("EMP_REF_ID").getValue() == tRow.getCellFromKey("EMP_REF_ID").getValue()) {
                                    alert(tRow.getCellFromKey("EMP_NAME").getValue() + "님은 이미 결재선에 등록되어있습니다!");
                                    return false;
                                }
                            }
                        }
                        if (objID == '23') {
                            for (var j = 0; j < ugrdApp.Rows.length; j++) {
                                if (ugrdApp.Rows.getRow(j).getCellFromKey("EMP_REF_ID").getValue() == tRow.getCellFromKey("EMP_REF_ID").getValue()) {
                                    alert(tRow.getCellFromKey("EMP_NAME").getValue() + "님은 이미 결재선에 등록되어있습니다!");
                                    return false;
                                }
                            }
                        }
                        
                        var emp_id = tRow.getCellFromKey("EMP_REF_ID").getValue();
                        for (var j = 0; j < ugrdDestination.Rows.length; j++) {
                            var tRowDes = ugrdDestination.Rows.getRow(j);
                            if (tRow.getCellFromKey("EMP_REF_ID").getValue() == tRowDes.getCellFromKey("EMP_REF_ID").getValue()) {
                                alert(tRow.getCellFromKey("EMP_NAME").getValue() + "님은 이미 등록되어있습니다!");
                                return false;
                            }
                        }
                    }
                }
                if (!isSelected) {
                    alert("등록할 사원을 선택하세요");
                    return false;
                }
                if (confirm("등록하시겠습니까?")) {
                    visibleLoading();
                    return true;
                }
                return false;
            }
            else {
                var isSelected = false;
                var ugrdDestination;
                if (objID == '11')
                    ugrdDestination = igtbl_getGridById('<%= ugrdFixEmp.ClientID %>');
                else if (objID == '12')
                    ugrdDestination = igtbl_getGridById('<%= ugrdSignerEmp.ClientID %>');
                else if (objID == '13')
                    ugrdDestination = igtbl_getGridById('<%= ugrdDraftEmp.ClientID %>');

                for (var i = 0; i < ugrdDestination.Rows.length; i++) {
                    var tRow = ugrdDestination.Rows.getRow(i);
                    var e = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                    if (e.checked) {
                        isSelected = true;
                        break;
                    }
                }
                if (!isSelected) {
                    alert("삭제할 사원을 선택하세요");
                    return false;
                }
                if (confirm("선택한 사원을 삭제하시겠습니까?")) {
                    visibleLoading();
                    return true;
                }
                return false;
            }
        }
    </script>
<!--- MAIN START --->
    <div style="z-index: 1; position: relative; width: 100%; height: 100%;">
    <table border="0" cellpadding="0" cellspacing="2" style="width:100%; height:100%; text-align:left; border-collapse:collapse;">
        <tr>
            <td style="height: 20px;" colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableBorder">
                    <tr>
                        <td class="cssTblTitle">
                            업무유형
                        </td>
                        <td class="cssTblContentSingle">
                            <asp:DropDownList ID="ddlWorkType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWorkType_SelectedIndexChanged" CssClass="box01" Width="100%"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:100%;">
            <td style="width: 60%; padding-top: 5px; height: 100%;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td style="height: 30%; padding-bottom: 5px;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="필수결재선" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;필수결재선--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 100%;padding-top: 3px;">
                                        <div style="height: 100%;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                        <ig:UltraWebGrid ID="ugrdFixEmp" runat="server" Width="100%" Height="100%">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:TemplatedColumn Key="selchk" Width="30px">
                                                            <Header Caption="선택"></Header>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <CellTemplate>
                                                                <asp:checkbox id="cBox" runat="server" />
                                                            </CellTemplate>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="180px" AllowUpdate="No">
                                                            <Header Caption="부서명">
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
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="80px" AllowUpdate="No">
                                                            <Header Caption="사용자명">
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
                                                        <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" Key="POSITION_CLASS_NAME" Width="80px" AllowUpdate="No">
                                                            <Header Caption="직책">
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
                                                        <ig:UltraGridColumn BaseColumnName="SORT_ORDER" Key="SORT_ORDER" Width="40px" DataType="System.Int">
                                                            <Header Caption="순서">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ValueList DisplayStyle="NotSet"></ValueList>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Width="80px" AllowUpdate="No" Hidden="True">
                                                            <Header Caption="EMP_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="2px" WidthLeft="2px" WidthRight="2px" WidthTop="2px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout 
                                                    CellPaddingDefault="2" 
                                                    AllowColSizingDefault="Free" 
                                                    AllowDeleteDefault="Yes"
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="SortMulti" 
                                                    Name="ugrdFixEmp" 
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Single" 
                                                    Version="4.00" ViewType="Flat" 
                                                    CellClickActionDefault="RowSelect" 
                                                    TableLayout="Fixed" 
                                                    StationaryMargins="Header" 
                                                    AutoGenerateColumns="False">
                                                <%--<GroupByBox>
                                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
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
                                                <ClientSideEvents />
                                                
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ibtnAdd1" />
                                            <asp:AsyncPostBackTrigger ControlID="ibtnDel1" />
                                            <asp:AsyncPostBackTrigger ControlID="ibtnUp1" />
                                            <asp:AsyncPostBackTrigger ControlID="ibtnDown1" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35%; padding-bottom: 5px;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label1" runat="server" style="font-weight:bold" text="결재자" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;결재자--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 100%;padding-top: 3px;">
                                        <div style="height: 100%;">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                        <ig:UltraWebGrid ID="ugrdSignerEmp" runat="server" Width="100%" Height="100%">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:TemplatedColumn Key="selchk" Width="30px">
                                                            <Header Caption="선택"></Header>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <CellTemplate>
                                                                <asp:checkbox id="cBox" runat="server" />
                                                            </CellTemplate>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="180px" AllowUpdate="No">
                                                            <Header Caption="부서명">
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
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="80px" AllowUpdate="No">
                                                            <Header Caption="사용자명">
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
                                                        <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" Key="POSITION_CLASS_NAME" Width="80px" AllowUpdate="No">
                                                            <Header Caption="직책">
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
                                                        <ig:UltraGridColumn BaseColumnName="SORT_ORDER" Key="SORT_ORDER" Width="40px" DataType="System.Int">
                                                            <Header Caption="순서">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ValueList DisplayStyle="NotSet"></ValueList>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="BIZ_TYPE" Key="BIZ_TYPE" Width="80px" AllowUpdate="No" Hidden="True">
                                                            <Header Caption="BIZ_TYPE">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Width="80px" AllowUpdate="No" Hidden="True">
                                                            <Header Caption="EMP_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="2px" WidthLeft="2px" WidthRight="2px" WidthTop="2px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                             <DisplayLayout CellPaddingDefault="2" 
                                                            AllowColSizingDefault="Free" 
                                                            AllowDeleteDefault="Yes"
                                                            BorderCollapseDefault="Separate"
                                                            HeaderClickActionDefault="SortMulti" 
                                                            Name="ugrdSignerEmp" 
                                                            RowHeightDefault="20px"
                                                            RowSelectorsDefault="No" 
                                                            SelectTypeRowDefault="Single" 
                                                            Version="4.00" 
                                                            ViewType="Flat" 
                                                            CellClickActionDefault="RowSelect" 
                                                            TableLayout="Fixed" 
                                                            StationaryMargins="Header" 
                                                            AutoGenerateColumns="False">
                                                    <%--<GroupByBox>
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                    </GroupByBox>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="3px" />
                                                    </RowStyleDefault>
                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
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
                                                    <ClientSideEvents />
                                                    
                                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                </DisplayLayout>
                                        </ig:UltraWebGrid>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ibtnAdd2" />
                                            <asp:AsyncPostBackTrigger ControlID="ibtnDel2" />
                                            <asp:AsyncPostBackTrigger ControlID="ibtnUp2" />
                                            <asp:AsyncPostBackTrigger ControlID="ibtnDown2" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35%;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label2" runat="server" style="font-weight:bold" text="결재상신자" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;결재상신자--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 100%;padding-top: 3px;">
                                        <div style="height: 100%;">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                        <ig:UltraWebGrid ID="ugrdDraftEmp" runat="server" Width="100%" Height="100%">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:TemplatedColumn Key="selchk" Width="30px">
                                                            <Header Caption="선택"></Header>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <CellTemplate>
                                                                <asp:checkbox id="cBox" runat="server" />
                                                            </CellTemplate>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="180px" AllowUpdate="No">
                                                            <Header Caption="부서명">
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
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="80px" AllowUpdate="No">
                                                            <Header Caption="사용자명">
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
                                                        <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" Key="POSITION_CLASS_NAME" Width="80px" AllowUpdate="No">
                                                            <Header Caption="직책">
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
                                                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Width="80px" AllowUpdate="No" Hidden="True">
                                                            <Header Caption="EMP_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="2px" WidthLeft="2px" WidthRight="2px" WidthTop="2px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                             <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="SortMulti" Name="ugrdDraftEmp" RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" SelectTypeRowDefault="Single" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                    <%--<GroupByBox>
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                    </GroupByBox>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="3px" />
                                                    </RowStyleDefault>
                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
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
                                                    <ClientSideEvents />
                                                    
                                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                </DisplayLayout>
                                        </ig:UltraWebGrid>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ibtnAdd3" />
                                            <asp:AsyncPostBackTrigger ControlID="ibtnDel3" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="padding-left: 3px; padding-right: 3px;">
                <table border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td style="height: 30%; padding-bottom: 5px; padding-top: 20px;">
                            <asp:ImageButton ImageUrl="~/images/arrow/up.gif" ID="ibtnUp1" runat="server" OnClientClick="return confirmUpDown('11');" OnClick="ibtnUp1_Click" />
                            <asp:ImageButton ImageUrl="~/images/arrow/down.gif" ID="ibtnDown1" runat="server" OnClientClick="return confirmUpDown('21');" OnClick="ibtnDown1_Click" />
                            <br />
                            <br />
                            <asp:ImageButton ImageUrl="~/images/arrow/del_up.gif" ID="ibtnDel1" runat="server" OnClientClick="return confirmSel('11');" OnClick="ibtnDel1_Click" />
                            <asp:ImageButton ImageUrl="~/images/arrow/add_up.gif" ID="ibtnAdd1" runat="server" OnClientClick="return confirmSel('21');" OnClick="ibtnAdd1_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35%; padding-bottom: 5px;">
                            <asp:ImageButton ImageUrl="~/images/arrow/up.gif" ID="ibtnUp2" runat="server" OnClientClick="return confirmUpDown('12');" OnClick="ibtnUp2_Click" />
                            <asp:ImageButton ImageUrl="~/images/arrow/down.gif" ID="ibtnDown2" runat="server" OnClientClick="return confirmUpDown('22');" OnClick="ibtnDown2_Click" />
                            <br />
                            <br />
                            <asp:ImageButton ImageUrl="~/images/arrow/del_up.gif" ID="ibtnDel2" runat="server" OnClientClick="return confirmSel('12'); visibleLoading();" OnClick="ibtnDel2_Click" />
                            <asp:ImageButton ImageUrl="~/images/arrow/add_up.gif" ID="ibtnAdd2" runat="server" OnClientClick="return confirmSel('22'); visibleLoading();" OnClick="ibtnAdd2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35%; padding-bottom: 5px;" valign="middle">
                            <asp:ImageButton ImageUrl="~/images/arrow/del_up.gif" ID="ibtnDel3" runat="server" OnClientClick="return confirmSel('13'); visibleLoading();" OnClick="ibtnDel3_Click" />
                            <asp:ImageButton ImageUrl="~/images/arrow/add_up.gif" ID="ibtnAdd3" runat="server" OnClientClick="return confirmSel('23'); visibleLoading();" OnClick="ibtnAdd3_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 40%; padding-top: 5px; height: 100%;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label id="Label3" runat="server" style="font-weight:bold" text="프로젝트 목록" />
                                    </td>
                                </tr>
                            </table>
                            <%--<img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;사용자정보--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 50%; padding-top: 3px;">
                            <div id="divDeptTree" style="width:100%; height:100%; overflow:auto; display: block; border: 1px solid #E9EBEB;">
                                <asp:TreeView ID="trvDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" BorderWidth="0px"
                                    OnSelectedNodeChanged="trvDept_SelectedNodeChanged" Width="100%" Height="100%" ShowLines="false" >
                                    <ParentNodeStyle Font-Bold="False" BorderWidth="0px" />
                                    <SelectedNodeStyle ForeColor="LightBlue" BackColor="#E0E0E0" Font-Underline="True" HorizontalPadding="1px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                        NodeSpacing="0px" VerticalPadding="0px" BorderWidth="0px" />
                                    <RootNodeStyle BorderWidth="0px" />
                                    <LeafNodeStyle BorderWidth="0px" />
                                    <HoverNodeStyle BorderWidth="0px" />
                                </asp:TreeView>
                            </div>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 50%;">
                            <div style="height: 100%;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <ig:UltraWebGrid ID="ugrdEmpList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdEmpList_InitializeRow" OnActiveRowChange="ugrdEmpList_ActiveRowChange">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                                <Header Caption="선택"></Header>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <CellTemplate>
                                                    <asp:checkbox id="cBox" runat="server" onclick="hideLoading()" />
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME" Width="90px" Hidden="false">
                                                <Header Caption="부서">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle horizontalalign="Left" verticalalign="Middle"></CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME" Width="80px">
                                                <Header Caption="성명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle horizontalalign="Left" verticalalign="Middle"></CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" HeaderText="직책" Key="POSITION_CLASS_NAME" Width="50px">
                                                <Header Caption="직책">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle horizontalalign="Left" verticalalign="Middle"></CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" HeaderText="empid">
                                                <Header Caption="empid">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EXIST_YN" Key="EXIST_YN" Hidden="true"></ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="2px" WidthLeft="2px" WidthRight="2px" WidthTop="2px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                 <DisplayLayout 
                                    CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowDeleteDefault="Yes"
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="ugrdEmpList" 
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Single" 
                                    Version="4.00" 
                                    ViewType="Flat" 
                                    CellClickActionDefault="CellSelect"
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False">
                                    <%--<GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Default">
                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
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
                                    <ClientSideEvents />
                                    
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                </DisplayLayout>
                            </ig:UltraWebGrid>     
                             </ContentTemplate>
                             <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="trvDept" />
                                <asp:PostBackTrigger ControlID="ugrdSignerEmp" />
                                <asp:AsyncPostBackTrigger ControlID="ibtnAdd3" />
                             </Triggers>
                            </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right">
                <asp:ImageButton ImageUrl="~/images/btn/b_075.gif" ID="ibtnInit" runat="server" OnClick="ibtnInit_Click" />
            </td>
            <td colspan="2"></td>
        </tr>
    </table>
    </div>
    <div id="div1" runat="server" style="z-index: 2; position: absolute; width: 100%; height: 100%; display: none;">
        <img id="imgLoading" alt="" src="../images/etc/box_loading.gif" />
    </div>
<!--- MAIN END --->
</asp:Content>