<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="EST110105.aspx.cs" Inherits="EST_EST110105" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>


<form id="form1" runat="server">
    <script id="Infragistics" type="text/javascript">
        function btnClick(clickValue) {
            switch (clickValue) {
                case "1":
                    if ('<%= this.IEST_STATUS %>' == "Y") {
                        alert('이미 확정된 평가입니다.');
                        return false;
                    }
                    if ('<%= this.IEST_COMPLETE %>' == "Y") {
                        alert('평가확정버튼을 이용하세요.');
                        return false;
                    }
                    return confirm('강제확정 하시겠습니까?');
                    break;
                case "2":
                    if ('<%= this.IEST_STATUS %>' == "Y") {
                        alert('이미 확정된 평가입니다.');
                        return false;
                    }
                    if ('<%= this.IEST_COMPLETE %>' == "N") {
                        alert('완료되지 않은 평가가 존재합니다. 확정할 수 없습니다.');
                        return false;
                    }
                    return confirm('평가확정 하시겠습니까?');
                    break;
                case "3":
                    if ('<%= this.IEST_STATUS %>' != "Y") {
                        alert('확정되지않은 평가입니다.');
                        return false;
                    }
                    return confirm('확정취소 하시겠습니까?');
                    break;
            }
            return false;
        }
    </script>
        <%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
        <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
        <!--- MAIN START --->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
            <tr style="height: 95%;">
                <td style="height: 100%;" valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                        <tr>
                            <td style="height: 25px; width: 100%;">
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 25px">
                                    <tr>
                                        <td style="height: 25px;" align="left" valign="middle" colspan="3">
                                            <img src="../images/icon/subtitle.gif" alt="" />&nbsp;<b>MBO 평가현황</b>
                                        </td>
                                        <td align="right" colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 100%;" valign="top">
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%; vertical-align: top;">
                                    <tr>
                                        <td style="height: 20px; padding-bottom: 1px;" class="tableBorder">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <colgroup>
                                                    <col width="60px" />
                                                    <col width="220px" />
                                                    <col width="60px" />
                                                    <col width="150px" />
                                                    <col width="60px" />
                                                    <col width="60px"/>
                                                    <col width="" />
                                                </colgroup>
                                                <tr>
                                                    <td align="center" class="tableTitle">평가기간</td>
                                                    <td class="tableContent">
                                                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                                                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged" width="0%"></asp:dropdownlist>
                                                        <asp:dropdownlist id="ddlEstTerm" class="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged" runat="server" width="70%"></asp:dropdownlist><asp:DropDownList id="ddlEstTermSubID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged" width="29%"></asp:dropdownlist>
                                                    </td>
                                                    <td align="center" class="tableTitle">피평가부서</td>
                                                    <td class="tableContent">
                                                        <asp:DropDownList id="ddlComDept" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlComDept_SelectedIndexChanged" width="100%"></asp:dropdownlist>
                                                    </td>
                                                    <td align="center" class="tableTitle">평가차수</td>
                                                    <td class="tableContent">
                                                        <asp:DropDownList id="ddlEstTermStepID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermStepID_SelectedIndexChanged" width="100%"></asp:dropdownlist>
                                                    <td align="right" style="padding-right: 10px;">
                                                        <asp:ImageButton id="ibtnSearch" onclick="ibtnSearch_Click"  runat="server" imageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnSearchAll" onclick="ibtnSearchAll_Click" runat="server" ImageUrl="../images/btn/b_301.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="padding-top: 1px; width: 100%; height: 100%;">
                                            <ig:UltraWebGrid ID="ugrdMBO" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMBO_InitializeRow" OnInitializeLayout="ugrdMBO_InitializeLayout" >
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:UltraGridColumn BaseColumnName="EST_STATUS" Key="EST_STATUS" Width="7%" HeaderText="상태">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_NAME" Key="ESTTERM_STEP_NAME" Width="10%" HeaderText="차수">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_EMP_NAME" Key="EST_EMP_NAME" Width="10%" HeaderText="평가자">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TGT_DEPT_NAME" Key="TGT_DEPT_NAME" Width="23%" HeaderText="피평가부서">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TGT_EMP_NAME" Key="TGT_EMP_NAME" Width="10%" HeaderText="피평가자">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" Key="POSITION_CLASS_NAME" Width="10%" HeaderText="직급">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POSITION_DUTY_NAME" Key="POSITION_DUTY_NAME" Width="10%" HeaderText="직책">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" Key="POSITION_RANK_NAME" Width="10%" HeaderText="직위">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POINT" Key="POINT" Width="10%" HeaderText=" 점수" DataType="System.Double" Format="###,##0.00">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Right">
                                                                    <Padding Right="5px" />
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>                                                            
                                                            <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_ID" Key="ESTTERM_SUB_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_ID" Key="ESTTERM_STEP_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EST_EMP_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID" Key="EST_DEPT_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="STATUS_NAME" Key="STATUS_NAME" Hidden="true"></ig:UltraGridColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="#E5E5E5" BorderStyle="Solid">
                                                            <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout CellPaddingDefault="2" 
                                                    AllowColSizingDefault="Free" 
                                                    AllowColumnMovingDefault="None" 
                                                    AllowDeleteDefault="No"
                                                    AllowSortingDefault="Yes" 
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="NotSet"
                                                    Name="ugrdMBO" 
                                                    RowHeightDefault="20px" 
                                                    HeaderStyleDefault-Height="23px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
                                                    CellClickActionDefault="CellSelect"
                                                    TableLayout="Fixed" 
                                                    StationaryMargins="Header" 
                                                    AutoGenerateColumns="False"
                                                    UseFixedHeaders="true">                                                        
                                                    
                                                    <GroupByBox>
                                                        <BoxStyle BackColor="whitesmoke" BorderColor="Window" BorderStyle="Solid"></BoxStyle>
                                                    </GroupByBox>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderStyle="Solid" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="2px" />
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
                                                    </SelectedRowStyleDefault>
                                                    <ClientSideEvents />
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                            <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnEndExport="ugrdEEP_EndExport" OnBeginExport="ugrdEEP_BeginExport">
                                            </ig:UltraWebGridExcelExporter>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; padding-right: 10px; padding-top: 5px;">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="100">
                                                                    <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                                                                    <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                                                    <img align="absmiddle" src="../Images/etc/lis_t02.gif" />
                                                                </td>
                                                                <td>
                                                                    <asp:table id="tblViewStatus" runat="server"></asp:table></td>
                                                            </tr>
                                                        </table>
                                                    </td>                                                
                                                    <td align="right" style="padding-right: 5px; padding-top: 0px;">
                                                        <asp:ImageButton id="ibtnConfirmAll" runat="server" imageUrl="../images/btn/b_207.gif" OnClientClick="return btnClick('1');" OnClick="ibtnConfirmAll_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnConfirmMbo" runat="server" imageUrl="../images/btn/b_160.gif" OnClientClick="return btnClick('2');" OnClick="ibtnConfirmMbo_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnCancelConfirm" runat="server" imageUrl="../images/btn/b_019.gif" OnClientClick="return btnClick('3');" OnClick="ibtnCancelConfirm_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnDownload" runat="server" imageUrl="../images/btn/b_041.gif" OnClick="ibtnDownload_Click"></asp:ImageButton>
                                                        <asp:Literal id="ltrScript" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
        <!--- MAIN END --->
        <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

