<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1104S2.aspx.cs" Inherits="PRJ_PRJ1104S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script type="text/javascript" language="javascript">
        function openWorkForm(estterm_ref_id, est_dept_ref_id, work_ref_id) {
            gfOpenWindow("../PRJ/PRJ1102M1.aspx?iType=U&ESTTERM_REF_ID=" + estterm_ref_id + "&EST_DEPT_REF_ID=" + est_dept_ref_id + "&WORK_REF_ID=" + work_ref_id
                , 720, 700, 'PRJ1102M1');
        }

        function openExecForm(estterm_ref_id, est_dept_ref_id, work_ref_id, exec_ref_id) {
            gfOpenWindow("../PRJ/PRJ1102M5.aspx?iType=U&ESTTERM_REF_ID=" + estterm_ref_id + "&EST_DEPT_REF_ID=" + est_dept_ref_id + "&WORK_REF_ID=" + work_ref_id + "&EXEC_REF_ID=" + exec_ref_id
                , 1000, 820, 'PRJ1102M5');
        }
    </script>

    <!--- MAIN START --->
	<table cellpadding="0" cellspacing="2" border="0" style="width: 100%; height: 100%;">
	    <tr valign="top">
			<td style="padding: 0; border: 0;">
                <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%" style="height: 100%;">
                    <colgroup>
                        <col width="50px" />
                        <col width="120px" />
                        <col width="50px" />
                        <col width="50px" />
                        <col width="50px" />
                        <col width="50px" />
                        <col width="50px" />
                        <col width="50px" />
                        <col width="50px" />
                    </colgroup>
                    <tr>
                        <td class="tabletitle" align="center" style="height: 20px;">평가기간</td>
                        <td class="tableContent" style="border-right: 0px;">
                            <asp:DropDownList ID="ddlEstTerm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged" Width="100%" CssClass="box01" ></asp:DropDownList>
                        </td>
                        <td class="tabletitle" align="center">과제코드</td>
                        <td class="tableContent">
                            <asp:TextBox ID="txtWorkCode" runat="server" width="100%"></asp:TextBox>
                        </td>
                        <td class="tabletitle" align="center">과&nbsp;제&nbsp;명</td>
                        <td class="tableContent">
                            <asp:TextBox ID="txtWorkName" runat="server" width="100%"></asp:TextBox>
                        </td>
                        <td class="tabletitle" align="center">관리자명</td>
                        <td class="tableContent">
                            <asp:TextBox ID="txtEmpName" runat="server" width="100%"></asp:TextBox>
                        </td>
                        <td class="tableContent" rowspan="2" style="border-left: 0px;" align="center">
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle" OnClick="ibtnSearch_Click" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tabletitle" align="center" style="height: 20px;">평가조직</td>
                        <td class="tableContent" style="border-right: 0px;">
                            <asp:DropDownList ID="ddlEstDept" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                        </td>
                        <td class="tabletitle" align="center">과제유형</td>
                        <td class="tableContent" style="border-right: 0px;">
                            <asp:DropDownList ID="ddlWorkType" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                        </td>
                        <td class="tabletitle" align="center">완료여부</td>
                        <td class="tableContent">
                            <asp:DropDownList ID="ddlCompleteYN" runat="server" Width="100%" CssClass="box01"></asp:DropDownList>
                        </td>
                        <td class="tabletitle" align="center">관리자 ID</td>
                        <td class="tableContent">
                            <asp:TextBox ID="txtEmpID" runat="server" width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9" valign="top" style="width: 100%; padding: 0; border: 0;">
                            <ig:UltraWebGrid ID="ugrdWorkList" runat="server"  Width="100%" Height="100%" OnInitializeRow="ugrdWorkList_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="WORK_UPDATE" HeaderText="수정" Key="WORK_UPDATE" AllowUpdate="No" Width="6%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE_NAME" HeaderText="과제유형" Key="WORK_TYPE_NAME" AllowUpdate="No" Width="8%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="주관부서" Key="DEPT_NAME" AllowUpdate="No" Width="30%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_CODE" HeaderText="과제코드" Key="WORK_CODE" AllowUpdate="No" Width="8%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_NAME" HeaderText="과제명칭" Key="WORK_NAME" AllowUpdate="No" Width="30%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_EMP_NAME" HeaderText="관리자" Key="WORK_EMP_NAME" AllowUpdate="No" Width="10%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" HeaderText="완료여부" Key="COMPLETE_YN" AllowUpdate="No" Width="8%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" Key="WORK_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID_ORG" Key="WORK_REF_ID_ORG" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_DEPT_REF_ID" Key="WORK_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE" Key="WORK_TYPE" Hidden="true"></ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free"
                                    AllowSortingDefault="No" 
                                    AutoGenerateColumns="False" 
                                    BorderCollapseDefault="Separate" 
                                    CellPaddingDefault="2" 
                                    CellClickActionDefault="RowSelect"
                                    HeaderClickActionDefault="SortMulti"
                                    Name="ugrdWorkList" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="Yes"
                                    RowSelectorStyleDefault-Width="20px"
                                    SelectTypeRowDefault="Extended"
                                    StationaryMargins="Header" 
                                    TableLayout="Fixed" 
                                    Version="4.00" 
                                    ViewType="Flat" 
                                    AllowUpdateDefault="Yes">
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
                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="100%">
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
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>
                                    <ClientSideEvents />
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="8" style="height: 25px;">
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
                        <td align="right" style="padding-right: 10px;">
                            <asp:ImageButton ID="ibtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  ImageAlign="AbsMiddle" OnClick="ibtnPrint_Click" />
                        </td>
                    </tr>
                </table>
	        </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>    
    <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport">
    </ig:UltraWebGridExcelExporter>
    <!--- MAIN END --->
</asp:Content>