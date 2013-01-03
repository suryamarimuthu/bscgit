<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MUL0010S3.aspx.cs" Inherits="MUL_MUL0010S3" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">
    //평가정보 선택 여부 검사
    function validate() {
        var est_id = document.getElementById("hdfEstID").value;

        if (est_id.length == 0) {
            alert("평가정보를 선택하세요.");
            return false;
        }
        else {
            return true;
        }
    }


    //피평가자 상세정보 팝업
    function Show_Est_Stat_Detail_By_Emp(TGT_DEPT_ID, TGT_EMP_ID) {
        gfOpenWindow("MUL0010M3.aspx?TGT_DEPT_ID=" + TGT_DEPT_ID
	                        + "&TGT_EMP_ID=" + TGT_EMP_ID
                           , 640
                           , 480
                           , false
                           , false
                           , "popup_est_data");
    }
    
    
    //평가정보 팝업
    function SearchEstID() {
        gfOpenWindow("../EST/EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
	                        + "&CTRL_VALUE_NAME=" + "hdfEstID"
                            + "&CTRL_TEXT_NAME=" + "txtEstName"
                            + "&CHECKBOX_YN=" + "N"
                            + "&CTRL_VALUE_VALUE=" + ""
                           , 430
                           , 400
                           , false
                           , false
                           , "popup_est_scheId");
        return false;
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
                        <td class="cssTblTitle">평가기간</td> 
                        <td class="cssTblContent"> 
                            <asp:DropDownList id="ddlEstTermRefID" runat="server" class="box01"/>
                            <asp:DropDownList id="ddlEstTermSubID" runat="server" class="box01"/>
                        </td> 
                        <td class="cssTblTitle" width="120px">평가유형</td> 
                        <td class="cssTblContent">
                            <asp:DropDownList id="ddlEstList" runat="server" widht="100%" class="box01"/>
                            <%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:textbox id="txtEstName" runat="server" bordercolor="Silver" borderwidth="1px" width="100%" />
                                    </td>
                                    <td style="width:90px;" align="right">
                                        <a href="#null" onclick="javascript:SearchEstID();">
                                            <img align="absMiddle" border="0" src="../images/btn/b_143.gif" />
                                        </a>
                                    </td>
                                </tr>
                            </table>--%>
                        </td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:3px;">
            <td>
                <asp:label id="lblCompTitle" runat="server" visible="false" ></asp:label>
                <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                <asp:HiddenField ID="hdfEstID" runat="server" />
            </td>
        </tr>
        <tr style="height:100%;">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                    <tr style="height:25px;">
                        <td style="width:50%;">
                            <table  cellpadding="0" cellspacing="0" border="0" style=" width:100%;">
                                <tr>
                                    <td style="width:15px;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label style="font-weight:bold;" id="lblTitle1" runat="server" text="부서 정보" /></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:10px;">&nbsp;</td>
                        <td>
                            <table  cellpadding="0" cellspacing="0" border="0" style=" width:100%;">
                                <tr>
                                    <td style="width:15px;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label style="font-weight:bold;" id="lblTitle2" runat="server" text="사용자 정보(피평가자)" /></td>
                                    <td align="right" >
                                        <asp:imagebutton id="ibnSearch" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click" onclientclick="return validate();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:100%;">
                        <td>
                            <ig:UltraWebGrid    id="UltraWebGrid1" runat="server" Width="100%" Height="100%"
                                                OnInitializeLayout="UltraWebGrid1_InitializeLayout"
                                                OnInitializeRow="UltraWebGrid1_InitializeRow"
                                                OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
					            <Bands>
						            <ig:UltraGridBand>
						                <Columns>
						                    <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" Hidden="true">
								                <Header Caption="TGT_DEPT_ID" />
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="TGT_DEPT_NAME" Key="TGT_DEPT_NAME" Width="50%">
								                <Header Caption="부서명" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Left"/>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="TOTAL_EST_CNT" Key="TOTAL_EST_CNT" Width="40px">
								                <Header Caption="전체" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Right"/>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="STATUS_N_CNT" Key="STATUS_N_CNT" Width="50px">
								                <Header Caption="미평가" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Right" />
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="STATUS_P_CNT" Key="STATUS_P_CNT" Width="50px">
								                <Header Caption="평가중" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Right"/>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="STATUS_E_CNT" Key="STATUS_E_CNT" Width="60px">
								                <Header Caption="평가완료" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Right"/>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="EST_PROGRESS" Key="EST_PROGRESS" Width="50px">
								                <Header Caption="진행률" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Right"/>
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
                        <td>
                        </td>
                        <td> 
                            <ig:UltraWebGrid    id="UltraWebGrid2" runat="server" Width="100%" Height="100%"
                                                OnInitializeLayout="UltraWebGrid2_InitializeLayout"
                                                OnInitializeRow="UltraWebGrid2_InitializeRow">
								<Bands>
									<ig:UltraGridBand>
									    <Columns>
										    <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" Hidden="true">
											    <Header Caption="TGT_DEPT_ID"></Header>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" Hidden="true">
											    <Header Caption="TGT_EMP_ID"></Header>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="TGT_EMP_NAME" Key="TGT_EMP_NAME" Width="50%">
											    <Header Caption="피평가자" />
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Left"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="TOTAL_EST_CNT" Key="TOTAL_EST_CNT" Width="60px">
											    <Header Caption="평가자수" />
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Right"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="STATUS_N_CNT" Key="STATUS_N_CNT" Width="50px">
											    <Header Caption="미평가" />
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Right"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="STATUS_P_CNT" Key="STATUS_P_CNT" Width="50px">
											    <Header Caption="평가중" />
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Right"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="STATUS_E_CNT" Key="STATUS_E_CNT" Width="60px">
											    <Header Caption="평가완료" />
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Right"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="EST_PROGRESS" Key="EST_PROGRESS" Width="50px">
											    <Header Caption="진행률" />
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Right"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="DETAIL" Key="DETAIL" Width="40px" Hidden="true">
											    <Header Caption="상세" />
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Center"/>
										    </ig:UltraGridColumn>
										</Columns>
									</ig:UltraGridBand>
								</Bands>
								<DisplayLayout 
					                            AllowColSizingDefault="Free" 
				                                AllowColumnMovingDefault="OnServer" 
				                                BorderCollapseDefault="Separate" 
				                                HeaderClickActionDefault="SortMulti" 
				                                Name="UltraWebGrid2" 
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
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                    <Images>
                                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
								</DisplayLayout>
							</ig:UltraWebGrid>	    
                        </td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdfEstTermSubID" runat="server" />
                <asp:literal id="ltrScript" runat="server"></asp:literal>
            </td>
        </tr>
    </table>
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</div>
</form>
<%Response.WriteFile( "../_common/html/CommonBottom.htm" );%>