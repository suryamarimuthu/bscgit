<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0308M1.aspx.cs" Inherits="BSC_BSC0308M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript">
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

        var url = 'BSC0302M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID;  //+ '&CCB1=NULL';  //+ ICCB1;
        gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1_' + kpiID);
    }

    function checkInOut(objID) {
        var isSelected = false;
        var ugrd;
        if (objID == '1') //입력
        {
            ugrd = igtbl_getGridById('<%= ugrdKpiList.ClientID %>');
            var ugrd2 = igtbl_getGridById('<%= ugrdGroupList.ClientID %>');
            for (var i = 0; i < ugrd.Rows.length; i++) {
                var tRow = ugrd.Rows.getRow(i);
                var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                if (chkYN.checked) {
                    isSelected = true;
                    var kpiID = tRow.getCellFromKey("KPI_REF_ID").getValue();
                    for (var j = 0; j < ugrd2.Rows.length; j++) {
                        if (ugrd2.Rows.getRow(j).getCellFromKey("KPI_REF_ID").getValue() == kpiID) {
                            alert((i + 1).toString() + " 번째 선택한 KPI는 이미 등록되어있습니다.");
                            return false;
                        }
                    }
                }
            }
            if (!isSelected) {
                alert('등록할 KPI를 선택하세요!');
                return false;
            }
            return confirm('등록하시겠습니까?');
        }
        else {
            ugrd = igtbl_getGridById('<%= ugrdGroupList.ClientID %>');
            for (var i = 0; i < ugrd.Rows.length; i++) {
                var tRow = ugrd.Rows.getRow(i);
                var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                if (chkYN.checked) {
                    isSelected = true;
                    break;
                }
            }
            if (!isSelected) {
                alert('삭제할 KPI를 선택하세요!');
                return false;
            }
            return confirm('삭제하시겠습니까?');
        }
    }
</script>
        
    <!--- MAIN START --->        
    <table cellpadding="0" cellspacing="0" border="0"  style="width:100%; height:100%;" >
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="설정현황" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermInfo" CssClass="box01" runat="server" width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle">
                            설정그룹
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlGroup" CssClass="box01" runat="server" width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:dropdownlist>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 50%">
            <td>
                <ig:UltraWebGrid ID="ugrdGroupList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdGroupList_InitializeRow">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn BaseColumnName="selchk" Key="selchk" Width="30px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdGroupList')" />
                                    </HeaderTemplate>
                                    <CellTemplate>
                                       <asp:CheckBox ID="cBox" runat="server" /> 
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="GROUP_NAME" HeaderText="그룹명" Key="GROUP_NAME" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" HeaderText="KPI 코드" Key="KPI_CODE" Width="75px"  Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" HeaderText="KPI명" Key="KPI_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="운영조직" Key="DEPT_NAME" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_NAME" HeaderText="챔피언" Key="CHAMPION_NAME" Width="170px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표유형" Key="KPI_GROUP_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="60px" FooterText="" HeaderText="사용여부">
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID="" Width="60px" FooterText="" HeaderText="결재상태">
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgApp" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="GROUP_CODE" Key="GROUP_CODE" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="true"></ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="NotSet" Name="ugrdGroupList" RowHeightDefault="20px"
                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                        <%--<GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
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
                        
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>       
            </td>
        </tr>
        <tr>
            <td valign="middle"  align="center" style="padding-top:5px;">
               <asp:ImageButton ID="ibtnInsert" runat="server" ImageUrl="../images/btn/btn_add_03.GIF" OnClientClick="return checkInOut('1');" OnClick="ibtnInsert_Click" />&nbsp;
               <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="../images/btn/btn_add_04.GIF" OnClientClick="return checkInOut('2');" OnClick="ibtnDelete_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="Label1" runat="server" style="font-weight:bold" text="대상KPI" />
                        </td>
                        
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                    <!--
                        <td class="cssTblTitle"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                        <td class="cssTblContent"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>
                        -->
                        <td class="cssTblTitle">KPI 명</td>
                        <td class="cssTblContent"><asp:TextBox id="txtKPIName" runat="server" width="100%"></asp:TextBox></td>
                        <td class="cssTblTitle"><%=this.GetText("LBL_00001", "챔피언") %></td>
                        <td class="cssTblContent"><asp:TextBox id="txtChamName" runat="server" width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        
                        <td class="cssTblTitle">지표유형</td>
                        <td class="cssTblContent"><asp:dropdownlist id="ddlKpiGroupRefID" class="box01" runat="server" width="99%"></asp:dropdownlist></td>
                        <td class="cssTblTitle">운영조직&nbsp;</td>
                        <td class="cssTblContent" style="border-right:none;">
                            <asp:dropdownlist id="ddlComDept" class="box01" runat="server" width="100%"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlResultInput" class="box01" runat="server" width="100%" visible="false"></asp:dropdownlist>
                        </td>
                    </tr>
              
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right">
                <asp:ImageButton id="ibtnSearch" onclick="ibtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
            </td>
        </tr>
        <tr style="height: 50%;">
            <td>
                <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiList_InitializeRow">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn BaseColumnName="selchk" Key="selchk" Width="30px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                    <CellTemplate>
                                       <asp:CheckBox ID="cBox" runat="server" /> 
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" HeaderText="KPI 코드" Key="KPI_CODE" Width="75px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" HeaderText="KPI명" Key="KPI_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="챔피언" Key="CHAMPION_EMP_NAME" Width="170px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표유형" Key="KPI_GROUP_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" Width="60px" FooterText="" HeaderText="사용여부">
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Width="60px" FooterText="" HeaderText="결재상태">
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgApp" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="NotSet" Name="ugrdKpiList" RowHeightDefault="20px"
                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                        <%--<GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
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
            </td>
        </tr>
    </table> 
    <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    <!--- MAIN END --->
  
</asp:Content>
