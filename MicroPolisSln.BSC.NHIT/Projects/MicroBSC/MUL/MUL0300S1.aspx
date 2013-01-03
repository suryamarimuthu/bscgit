<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MUL0300S1.aspx.cs" Inherits="MUL_MUL0300S1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">



    function doSavingDept() {
        if (doChecking('UltraWebGrid1')) {

            var estTypeName = "평가자";

            if (document.getElementById('rdoEstTypeList_0').checked)
                estTypeName = "피평가자";

            return confirm(estTypeName + '선정을 실행할까요?');
        }

        return false;
    }

    function doDeletingDept() {
        if (doChecking('UltraWebGrid1')) {

            var estTypeName = "평가자";

            if (document.getElementById('rdoEstTypeList_0').checked)
                estTypeName = "피평가자";

            return confirm("선정된 " + estTypeName + '를 삭제할까요?');
        }

        return false;
    }

    function doSavingEstData() {
        /*
        if (doChecking('UltraWebGrid1')) {
            var estTypeName = "평가자";

            if (document.getElementById('rdoEstTypeList_0').checked)
                estTypeName = "피평가자";

            return confirm('선택한 부서의 ' + estTypeName + '를 확정 하시겠습니까?');
        }
        */

        return confirm("다면평가 평가/피평가자 상태를 확정할까요?");
    }

    function doDeletingEstData() {
        /*
        if (doChecking_Disabled('UltraWebGrid1')) {
            var estTypeName = "평가자";

            if (document.getElementById('rdoEstTypeList_0').checked)
                estTypeName = "피평가자";

            return confirm('선택한 부서의 ' + estTypeName + ' 확정을 취소 하시겠습니까?');
        }
        */

        return confirm("다면평가 평가/피평가자 상태 확정을 취소할까요?");
    }


    function ValidateEstCntRange() {
        var Max = document.getElementById("txtMaxEstEmpCnt").value;
        var Mid = document.getElementById("txtMidEstEmpCnt").value;
        var Min = document.getElementById("txtMinEstEmpCnt").value;

        if (Max >= Mid && Mid >= Min)
            return true;

        alert("값을 잘못 입력하셨습니다.");
        return false;
    }

    function confirmResetCntRange() {
        if (confirm("기본 정보를 삭제할까요?"))
            return true;

        return false;
    }


    // 체크 여부 확인
    function doChecking_Disabled(chkbox) {
        var _elements = document.forms[0].elements;
        var chkCnt = 0;

        for (var i = 0; i < _elements.length; i++) {
            if (_elements[i].id.indexOf(chkbox) >= 0 && _elements[i].type == "checkbox") {
                if (_elements[i].checked)
                    chkCnt++;
                else if (_elements[i].disabled == true)
                    chkCnt++;
            }
        }

        if (chkCnt == 0) {
            // 선택된 항목이 없습니다.
            var strChoiceMsg = "선택된 항목이 없습니다.";
            alert(strChoiceMsg);
            return false;
        }

        return true;
    }

</script>

<form id="form1" runat="server">
<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
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
                        </td> 
                    </tr>
                   
                </table>
            </td>
        </tr>
        
        
        
        
        
        <tr>
            <td>
                <table  cellpadding="0" cellspacing="0" border="0" style=" width:100%; height:100%;">
                    <tr style="height:28px;">
                        <td>
                            <table  cellpadding="0" cellspacing="0" border="0" style=" width:100%; height:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td style="width:70px;">
                                        <asp:Label ID="lblTitle3" runat="server" Font-Bold="true" Text="기본 설정"/>
                                    </td>
                                    <td>
                                        <asp:ImageButton id="ibnClearMulBasicInfo" runat="server" 
                                            imageurl="../images/btn/b_075.gif" onclick="ibnClearMulBasicInfo_Click" onclientclick="return confirmResetCntRange();"></asp:ImageButton>
                                        <asp:ImageButton id="ibnSaveMulBasicInfo" runat="server" 
                                            imageurl="../images/btn/b_tp07.gif" onclick="ibnSaveMulBasicInfo_Click" onclientclick="return ValidateEstCntRange();"></asp:ImageButton>
                                    </td>
                                    <td align="right">
                                        <asp:label id="lblCompTitle" runat="server" visible="false" ></asp:label>
                                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                                        <asp:HiddenField ID="hdfEstID" runat="server" />
                                        <asp:imagebutton id="ibnSearch" runat="server" height="19px" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style=" width:100%;">
                                <tr>
                                    <td class="cssTblTitle">평가자 최대인원</td>
                                    <td class="cssTblContent">
                                        <ig:WebNumericEdit ID="txtMaxEstEmpCnt" runat="server" MaxValue="100" MinValue="1" NullText="0"></ig:WebNumericEdit>
                                    </td>
                                    <td class="cssTblTitle">최소 평가수</td>
                                    <td class="cssTblContent">
                                        <ig:WebNumericEdit ID="txtMinEstEmpCnt" runat="server" MaxValue="100" MinValue="1" NullText="0"></ig:WebNumericEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">최대 유지 인원</td>
                                    <td class="cssTblContent" style="border-right:none;">
                                        <ig:WebNumericEdit ID="txtMidEstEmpCnt" runat="server" MaxValue="100" MinValue="1" NullText="0"></ig:WebNumericEdit>
                                    </td>
                                    <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                    <td class="cssTblContent">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        
        
        <tr style="height:100%;">
            <td style="width:100%;">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                    <tr>
                        <td>
                            <table  cellpadding="0" cellspacing="0" border="0" style=" width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td style="width:29%;"><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="부서 정보"/></td>
                                    <td style="width:70%;" align="right"><asp:RadioButtonList style="display:none;cursor:pointer;" id="rdoEstTypeList" runat="server"  RepeatDirection="Horizontal" autopostback="True" onselectedindexchanged="rdoEstTypeList_SelectedIndexChanged"/></td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                        <td>
                            <table  cellpadding="0" cellspacing="0" border="0" style=" width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td style="width:90%;">
                                        <asp:Label ID="lblTitle1" runat="server" Font-Bold="true" Text="피평가자"/>
                                        <asp:Label ID="lblTitleDept" runat="server" Font-Bold="true" Text="(부서 사용자)"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td >
                            <table  cellpadding="0" cellspacing="0" border="0" style=" width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td style="width:90%;"><asp:Label ID="lblTitle2" runat="server" Font-Bold="true" Text="평가자"/></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:100%;">
                        <td style="width:33%;">
                            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
					            <Bands>
						            <ig:UltraGridBand>
						                <Columns>
						                    <ig:TemplatedColumn Key="selchk" Width="25px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer"/>
                                                </CellTemplate>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'UltraWebGrid1');" />
                                                </HeaderTemplate>
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:TemplatedColumn>
							                <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Width="60px" Hidden="true">
								                <Header Caption="">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <CellStyle HorizontalAlign="Right"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="140px">
								                <Header Caption="부서명">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Left"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="TOTAL_CNT" Key="TOTAL_CNT" Width="38px">
								                <Header Caption="인원">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="TGT_CNT" Key="TGT_CNT" Width="55px">
								                <Header Caption="피평가자">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="EST_CNT" Key="EST_CNT" Width="51px">
								                <Header Caption="평가자">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="" Key="RND_EST_LIST" Hidden="true">
										    </ig:UltraGridColumn>
							            </Columns>
						            </ig:UltraGridBand>
					            </Bands>
					            <DisplayLayout AllowColSizingDefault="Free" 
					                           AllowColumnMovingDefault="OnServer" 
					                           AllowDeleteDefault="Yes" 
					                           AllowSortingDefault="Yes" 
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
                                    <%--<ClientSideEvents DblClickHandler="DblClickHandler"/>--%>
                                    <Images>
                                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
					            </DisplayLayout>
				            </ig:UltraWebGrid>
                        </td>
                        <td style="width:1%;">&nbsp;
                        </td>
                        <td  style="width:33%;"> 
                            <ig:UltraWebGrid id="UltraWebGrid2" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid2_InitializeRow"  OnSelectedRowsChange="UltraWebGrid2_SelectedRowsChange">
								<Bands>
									<ig:UltraGridBand>
									    <Columns>
									        <ig:TemplatedColumn Key="selchk" Width="25px" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer"/>
                                                </CellTemplate>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'UltraWebGrid2');" />
                                                </HeaderTemplate>
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:TemplatedColumn>
										    <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="60px">
											    <Header Caption="사용자"></Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Center"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="POS_KND_NAME" Key="POS_KND_NAME" Width="60px">
											    <Header Caption="직위">
												    <RowLayoutColumnInfo OriginX="1" />
											    </Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Left"/>
											    <Footer>
												    <RowLayoutColumnInfo OriginX="1" />
											    </Footer>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="POS_CLS_NAME" Key="POS_CLS_NAME" Width="60px">
											    <Header Caption="직급">
												    <RowLayoutColumnInfo OriginX="1" />
											    </Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Left"/>
											    <Footer>
												    <RowLayoutColumnInfo OriginX="1" />
											    </Footer>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="POS_DUT_NAME" Key="POS_DUT_NAME" Width="60px">
											    <Header Caption="직책">
												    <RowLayoutColumnInfo OriginX="1" />
											    </Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Left"/>
											    <Footer>
												    <RowLayoutColumnInfo OriginX="1" />
											    </Footer>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EST_EMP_ID" Hidden="true">
										    </ig:UltraGridColumn>
										</Columns>
									</ig:UltraGridBand>
								</Bands>
								<DisplayLayout AllowColSizingDefault="Free" 
								               AllowColumnMovingDefault="OnServer" 
								               AllowDeleteDefault="Yes" 
								               AllowSortingDefault="Yes" 
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
								               AutoGenerateColumns="False">
								    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                    <Images>
                                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
								</DisplayLayout>
							</ig:UltraWebGrid>
                        </td> 
                        <td  style="width:33%;">
                            <ig:UltraWebGrid id="UltraWebGrid3" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid2_InitializeRow">
								<Bands>
									<ig:UltraGridBand>
									    <Columns>
									        <ig:TemplatedColumn Key="selchk" Width="25px" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer"/>
                                                </CellTemplate>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'UltraWebGrid2');" />
                                                </HeaderTemplate>
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" Key="DEPT_NAME" Width="100px">
								                <Header Caption="부서명">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Left"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="EST_EMP_NAME" Key="EMP_NAME" Width="60px">
											    <Header Caption="사용자"></Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Center"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="EST_POS_KND_NAME" Key="POS_KND_NAME" Width="60px">
											    <Header Caption="직위">
												    <RowLayoutColumnInfo OriginX="1" />
											    </Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Left"/>
											    <Footer>
												    <RowLayoutColumnInfo OriginX="1" />
											    </Footer>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="EST_POS_CLS_NAME" Key="POS_CLS_NAME" Width="60px">
											    <Header Caption="직급">
												    <RowLayoutColumnInfo OriginX="1" />
											    </Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Left"/>
											    <Footer>
												    <RowLayoutColumnInfo OriginX="1" />
											    </Footer>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="EST_POS_DUT_NAME" Key="POS_DUT_NAME" Width="60px">
											    <Header Caption="직책">
												    <RowLayoutColumnInfo OriginX="1" />
											    </Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Left"/>
											    <Footer>
												    <RowLayoutColumnInfo OriginX="1" />
											    </Footer>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EMP_REF_ID" Hidden="true">
											    <Header Caption="">
												    <RowLayoutColumnInfo OriginX="1" />
											    </Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Center"/>
											    <Footer>
												    <RowLayoutColumnInfo OriginX="1" />
											    </Footer>
										    </ig:UltraGridColumn>
										</Columns>
									</ig:UltraGridBand>
								</Bands>
								<DisplayLayout AllowColSizingDefault="Free" 
								               AllowColumnMovingDefault="OnServer" 
								               AllowDeleteDefault="Yes" 
								               AllowSortingDefault="Yes" 
								               BorderCollapseDefault="Separate" 
								               HeaderClickActionDefault="SortMulti" 
								               Name="UltraWebGrid3" 
								               RowHeightDefault="20px" 
								               RowSelectorsDefault="No" 
								               SelectTypeRowDefault="Extended" 
								               Version="4.00" 
								               ViewType="Flat" 
								               CellClickActionDefault="RowSelect" 
								               TableLayout="Fixed" 
								               StationaryMargins="Header" 
								               ReadOnly="LevelTwo"
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
                    <tr>
                        <td class="cssPopBtnLine">
                            <asp:ImageButton id="ibnRandom" runat="server" ImageUrl="../images/btn/btn_appoint.gif" OnClick="ibnRandom_Click" OnClientClick="return doSavingDept();" enabled="false"></asp:ImageButton>							
				            <asp:ImageButton id="ibnDelRandom" runat="server" ImageUrl="../images/btn/btn_clear.gif" OnClick="ibnDelRandom_Click" OnClientClick="return doDeletingDept();" enabled="false"></asp:ImageButton>
                        </td>
                        <td></td>
                        <td></td>
                        <td class="cssPopBtnLine">
				            <asp:ImageButton id="ibnAddEstData" runat="server" ImageUrl="../images/btn/b_015.gif" OnClick="ibnAddEstData_Click"  OnClientClick="return doSavingEstData();" enabled="true"></asp:ImageButton>
				            <asp:ImageButton id="ibnDelEstData" runat="server" ImageUrl="../images/btn/btn_clear.gif" OnClick="ibnDelEstData_Click" OnClientClick="return doDeletingEstData();" enabled="true"></asp:ImageButton>
				            <asp:HiddenField ID="hdfEstTermSubID" runat="server" />
                            <asp:literal id="ltrScript" runat="server"></asp:literal>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</form>
<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>