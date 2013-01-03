<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMS0200S1.aspx.cs" Inherits="PMS_PMS0200S1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">
    function Validate_PRJ_ID() {
        var PRJ_ID = document.getElementById("hdfPRJ_ID").value;

        /*
        if (PRJ_ID.length == 0) {
            alert("프로젝트를 선택하세요.");
            return false;
        }
        */

        return true;
    }
</script>

<form id="form1" runat="server">
<div>
<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td>
                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitle">프로젝트 종료일</td> 
                        <td class="cssTblContent" style="border-right:none;"> 
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                               <tr>
                                 <td style="width:45%;">
                                    <ig:WebDateChooser ID="prj_sDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false" Width="99%">
                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                    </ig:WebDateChooser> 
                                 </td>
                                 <td style="width:10%; text-align:center;">&nbsp;~&nbsp;</td>
                                 <td style="width:45%;">
                                    <ig:WebDateChooser ID="prj_eDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false" Width="99%">
                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                    </ig:WebDateChooser>
                                 </td>
                               </tr>
                             </table>
                        </td> 
                        <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                        <td class="cssTblContent">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr style="height:100%;">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height:100%;">
                    <tr class="cssPopBtnLine">
                        <td style="width:30%;" align="left">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="프로젝트 목록" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="lblTitle2" runat="server" style="font-weight:bold" text="프로젝트 세부데이터" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right">
                                        <asp:label id="lblCompTitle" runat="server" visible="false" ></asp:label>
                                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True"></asp:dropdownlist>
                                        <asp:HiddenField ID="hdfEstID" runat="server" />
                                        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:100%;">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                                <tr style="height:100%;">
                                    <td>
                                        <ig:UltraWebGrid    id="UltraWebGrid1" runat="server" Width="100%" 
                                            Height="100%" onselectedrowschange="UltraWebGrid1_SelectedRowsChange"
                                            OnInitializeRow="UltraWebGrid1_InitializeRow">
					                        <Bands>
						                        <ig:UltraGridBand>
						                            <Columns>
						                                <ig:UltraGridColumn BaseColumnName="PROJECTID" Key="PROJECTID" Hidden="true">
								                            <Header Caption="PROJECTID" />
							                            </ig:UltraGridColumn>
							                            <ig:UltraGridColumn BaseColumnName="PROJECTNAME" Key="PROJECTNAME" Width="100%">
								                            <Header Caption="프로젝트명" />
								                            <HeaderStyle HorizontalAlign="Center" />
								                            <CellStyle HorizontalAlign="Left"/>
								                        </ig:UltraGridColumn>
								                        <ig:UltraGridColumn BaseColumnName="STATUS_ID" Key="STATUS_ID" Hidden="true">
								                            <Header Caption="STATUS_ID" />
							                            </ig:UltraGridColumn>
							                            <ig:UltraGridColumn BaseColumnName="STATUS" Key="STATUS" Width="30px">
								                            <Header Caption="상태" />
								                            <HeaderStyle HorizontalAlign="Center" />
								                            <CellStyle HorizontalAlign="Center"/>
								                        </ig:UltraGridColumn>
							                        </Columns>
						                        </ig:UltraGridBand>
					                        </Bands>
					                        <DisplayLayout  CellPaddingDefault="2"
					                                        AllowColSizingDefault="Free" 
				                                            AllowColumnMovingDefault="OnServer" 
				                                            BorderCollapseDefault="Separate" 
				                                            HeaderClickActionDefault="SortMulti" 
				                                            Name="UltraWebGrid1" 
				                                            RowHeightDefault="20px" 
				                                            RowSelectorsDefault="No" 
				                                            SelectTypeRowDefault="Extended" 
				                                            Version="4.00" 
				                                            ViewType="Flat" 
				                                            CellClickActionDefault="RowSelect" 
				                                            TableLayout="Fixed" 
				                                            StationaryMargins="Header" 
				                                            OptimizeCSSClassNamesOutput="False"
				                                            AutoGenerateColumns="False">
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
                                <tr class="cssPopBtnLine">
                                    <td align="right">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                                            <tr>
                                                <td style="width:15px;" align="center"><img src="../images/icon/color/green.gif" /></td>
                                                <td style="width:40px;">평가중</td>
                                                <td style="width:15px;" align="center"><img src="../images/icon/color/blue.gif" /></td>
                                                <td>평가완료</td>
                                                <td align="right">
                                                    <asp:ImageButton runat="server" id="ibnPMS_IF" imageurl="../images/btn/btn_enter.gif" imagealign="absmiddle"
                                            onclientclick="return Validate_PRJ_ID()"
                                            onclick="ibnPMS_IF_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                        <td></td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height:100%;">
                                <tr style="height:50%;">
                                    <td>
                                        <ig:UltraWebGrid    id="UltraWebGrid2" runat="server" Width="100%" 
                                            Height="100%" oninitializelayout="UltraWebGrid2_InitializeLayout">
					                        <Bands>
						                        <ig:UltraGridBand>
						                            <Columns>
						                                <%--<ig:UltraGridColumn BaseColumnName="PRJ_ID" Key="PRJ_ID" Hidden="true">
								                            <Header Caption="PRJ_ID" />
							                            </ig:UltraGridColumn>
							                            <ig:UltraGridColumn BaseColumnName="PRJ_NM" Key="PRJ_NM" Width="50%">
								                            <Header Caption="프로젝트명" />
								                            <HeaderStyle HorizontalAlign="Center" />
								                            <CellStyle HorizontalAlign="Left"/>
								                        </ig:UltraGridColumn>
								                        <ig:UltraGridColumn BaseColumnName="PRJ_EMP_ID" Key="PRJ_EMP_ID" Hidden="true">
								                            <Header Caption="PRJ_EMP_ID" />
							                            </ig:UltraGridColumn>
							                            <ig:UltraGridColumn BaseColumnName="PRJ_EMP_NM" Key="PRJ_EMP_NM" Width="50%">
								                            <Header Caption="투입인력명칭" />
								                            <HeaderStyle HorizontalAlign="Center" />
								                            <CellStyle HorizontalAlign="Left"/>
								                        </ig:UltraGridColumn>--%>
							                        </Columns>
						                        </ig:UltraGridBand>
					                        </Bands>
					                        <DisplayLayout  CellPaddingDefault="2"
					                                        AllowColSizingDefault="Free" 
				                                            AllowColumnMovingDefault="OnServer" 
				                                            BorderCollapseDefault="Separate" 
				                                            HeaderClickActionDefault="SortMulti" 
				                                            Name="UltraWebGrid1" 
				                                            RowHeightDefault="20px" 
				                                            RowSelectorsDefault="No" 
				                                            SelectTypeRowDefault="Extended" 
				                                            Version="4.00" 
				                                            ViewType="Flat" 
				                                            CellClickActionDefault="RowSelect" 
				                                            TableLayout="Fixed" 
				                                            StationaryMargins="Header" 
				                                            OptimizeCSSClassNamesOutput="False"
				                                            AutoGenerateColumns="False"
				                                            NoDataMessage=" "
				                                            NullTextDefault="-"
				                                            ReadOnly="LevelTwo">
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
                                <tr style="height:50%;">
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height:100%;">
                                            <tr class="cssPopBtnLine">
                                                <td style="width:49%;">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                        <tr>
                                                            <td style="width:15px;">
                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label id="lblTitle3" runat="server" style="font-weight:bold" text="수기입력란" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width:1%;">&nbsp;</td>
                                                <td style="width:49%;">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                        <tr>
                                                            <td style="width:15px;">
                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label id="lblTitle4" runat="server" style="font-weight:bold" text="수식" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height:100%;">
                                                <td >
                                                    <ig:UltraWebGrid    id="UltraWebGrid3" runat="server" Width="100%" Height="100%">
					                                    <Bands>
						                                    <ig:UltraGridBand>
						                                        <Columns>
						                                            <ig:UltraGridColumn BaseColumnName="PRJ_COL_ID" Key="PRJ_COL_ID" Hidden="true">
								                                        <Header Caption="컬럼ID" />
							                                        </ig:UltraGridColumn>
							                                        <ig:UltraGridColumn BaseColumnName="PRJ_COL_NAME" Key="PRJ_COL_NAME" Width="50%" AllowUpdate="No">
								                                        <Header Caption="컬럼명" />
								                                        <HeaderStyle HorizontalAlign="Center" />
								                                        <CellStyle HorizontalAlign="Left"/>
								                                    </ig:UltraGridColumn>
								                                    <ig:UltraGridColumn BaseColumnName="PRJ_COL_VALUE" Key="PRJ_COL_VALUE" Width="50%">
								                                        <Header Caption="입력 값" />
								                                        <HeaderStyle HorizontalAlign="Center" />
								                                        <CellStyle HorizontalAlign="Left"/>
								                                    </ig:UltraGridColumn>
							                                    </Columns>
						                                    </ig:UltraGridBand>
					                                    </Bands>
					                                    <DisplayLayout  CellPaddingDefault="2"
					                                                    AllowColSizingDefault="Free" 
				                                                        AllowColumnMovingDefault="OnServer" 
				                                                        BorderCollapseDefault="Separate" 
				                                                        HeaderClickActionDefault="SortMulti" 
				                                                        Name="UltraWebGrid1" 
				                                                        RowHeightDefault="20px" 
				                                                        RowSelectorsDefault="No" 
				                                                        SelectTypeRowDefault="Extended" 
				                                                        Version="4.00" 
				                                                        ViewType="Flat" 
				                                                        CellClickActionDefault="Edit" 
				                                                        TableLayout="Fixed" 
				                                                        StationaryMargins="Header" 
				                                                        OptimizeCSSClassNamesOutput="False"
				                                                        AutoGenerateColumns="False"
				                                                        AllowUpdateDefault="Yes">
					                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
					                                    </DisplayLayout>
				                                    </ig:UltraWebGrid>
                                                </td>
                                                <td></td>
                                                <td style="width:49%;">
                                                    <asp:TextBox id="TxtBox_Soosik" runat="server" width="100%" style="height:99%;" textmode="multiline"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="cssPopBtnLine">
                                                <td align="right">
                                                    <asp:ImageButton id="ibnCustomCol_Value_Save" runat="server" 
                                                        ImageUrl="../images/btn/b_tp07.gif" onclick="ibnCustomCol_Value_Save_Click" onclientclick="return Validate_PRJ_ID()" />
                                                </td>
                                                <td></td>
                                                <td align="right">
                                                    <asp:ImageButton id="ibnSoosikSave" runat="server" 
                                                        ImageUrl="../images/btn/b_tp07.gif" onclick="ibnSoosikSave_Click" onclientclick="return Validate_PRJ_ID()" />
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
        
        
        <tr>
            <td>
                <asp:HiddenField ID="hdfPRJ_ID" runat="server" value="" />
                <asp:literal id="ltrScript" runat="server"></asp:literal>
            </td>
        </tr>
    </table>
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</div>
</form>
<%Response.WriteFile( "../_common/html/CommonBottom.htm" );%>