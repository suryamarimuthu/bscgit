<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110104.aspx.cs" Inherits="EST_EST110104" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
    <script type="text/javascript">
        //"right","+20
        //"left","-440

        function ViewJobList(comp_id, est_id, estterm_ref_id, estterm_sub_id) {
            gfOpenWindow("EST050301.aspx?COMP_ID=" + comp_id
	                                    + "&EST_ID=" + est_id
                                        + "&ESTTERM_REF_ID=" + estterm_ref_id
                                        + "&ESTTERM_SUB_ID=" + estterm_sub_id
                                       , 520
                                       , 430
                                       , true
                                       , true
                                       , "popup_est_tgt_map");
            return false;
        }

        function memview(viewurl) {
            var r = event.clientY + document.body.scrollTop - 90;
            var b = event.clientX + document.body.scrollLeft + 20;

            document.all.mview.style.pixelTop = r;
            document.all.mview.style.pixelLeft = b;
            document.all.mview.style.display = '';
            document.all.pmview.src = viewurl;
        }

        function move_memview() {
            var r = event.clientY + document.body.scrollTop - 90;
            var b = event.clientX + document.body.scrollLeft + 20;
            document.all.mview.style.pixelTop = r;
            document.all.mview.style.pixelLeft = b;
        }

        function hide_memview() {
            document.all.mview.style.display = 'none';
            document.all.pmview.src = '';
        }
	
	</script>
<form id="form1" runat="server">
    
<div>	
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
        <tr>
            <td>
                <table class="tableborder" cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                    <tr>
                        <td class="cssTblTitle">평가기간</td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged" />
                            <asp:label id="lblCompTitle" runat="server"></asp:label>                            
                            <asp:dropdownlist id="ddlEstTerm" class="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged" runat="server" width="68%" 
                            /><asp:DropDownList id="ddlEstTermSubID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged" width="30%" />
                        </td>
                        <td class="cssTblTitle">
                            <asp:Label id="lblDept" runat="server">피평가자부서</asp:Label>
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList id="ddlComDept" runat="server" class="box01" width="100%"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                    <tr class="cssPopBtnLine">
                        <td align="left">
                            <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                        </td>
                        <td align="right">
                            <asp:ImageButton id="ibtnSearch" onclick="ibtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr style="height:100%;">
            <td>
                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <ig:UltraWebGrid ID="ugrdMBO" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMBO_InitializeRow" OnInitializeLayout="ugrdMBO_InitializeLayout" >
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="EST_EMP_NAME" Key="EST_EMP_NAME" Width="70px" HeaderText="평가자">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" Key="EST_DEPT_NAME" Width="120px" HeaderText="평가자부서">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_STEP_NAME" Key="EST_STEP_NAME" Width="60px" HeaderText="평가차수">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="TGT_EMP_NAME" Key="TGT_EMP_NAME" Width="70px" HeaderText="피평가자">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="TGT_DEPT_NAME" Key="TGT_DEPT_NAME" Width="120px" HeaderText="피평가자부서">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_KPI_COUNT" Key="EST_KPI_COUNT" Width="50px" HeaderText="대상KPI" DataType="System.Int32">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="STATUS_N" Key="STATUS_N" Width="50px" HeaderText="미평가" DataType="System.Int32">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="STATUS_P" Key="STATUS_O" Width="50px" HeaderText=" 평가중" DataType="System.Int32">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="STATUS_E" Key="STATUS_C" Width="50px" HeaderText="완료" DataType="System.Int32">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="FEEDBACK_NAME" Key="FEEDBACK_NAME" Width="100px" HeaderText="피드백상태">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" Key="COMPLETE_YN" Width="60px" HeaderText="완료여부">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="SELECT" Key="SELECT" Width="100px" HeaderText="평가선택">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_ID" Key="ESTTERM_SUB_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_ID" Key="ESTTERM_STEP_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EST_EMP_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID" Key="EST_DEPT_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="SCORE_ORI" Key="SCORE_ORI" Hidden="true"></ig:UltraGridColumn>
                                        </Columns>
                                        
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="None" 
                                    AllowDeleteDefault="No"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="ugrdMBO" 
                                    RowHeightDefault="23px" 
                                    HeaderStyleDefault-Height="25px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
                                    ReadOnly="LevelTwo"
                                    OptimizeCSSClassNamesOutput="False">
                                    
                                    <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
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
                                    <AddNewBox Hidden="False">
                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </BoxStyle>
                                    </AddNewBox>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>--%>
                                    
                                    <GroupByBox>
                                        <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                                    </GroupByBox>
                                    <Pager>
                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </PagerStyle>
                                    </Pager>
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>