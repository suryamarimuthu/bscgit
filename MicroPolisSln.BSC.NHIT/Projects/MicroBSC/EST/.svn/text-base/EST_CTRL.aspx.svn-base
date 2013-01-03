<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST_CTRL.aspx.cs" Inherits="EST_EST_CTRL" %>
<html>
<head runat="server">
    <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" src="../_common/js/common.js"></script>
        <script type="text/javascript">
        
        </script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40">
					            <!-- 타이틀시작 -->
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr> 
                                                    <td height="40" valign="top"><img runat="server" id="imgTitle" src="../images/title/popup_t83.gif" ></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td width="50%" height="4" bgcolor="FFFFFF"></td>
                                                    <td width="50%" bgcolor="FFFFFF"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!-- 타이틀끝 -->
                            </td>
                        </tr>
                        <tr class="cssPopContent">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <table class="tableBorder" cellpadding="0" cellspacing="1" width="100%">
                                                <tr runat="server" id="trTgtDeptName">
                                                    <td class="cssTblTitle" width="120px">피평가자 부서</td> 
                                                    <td class="cssTblContent" colspan="3"> 
                                                        <asp:Label ID="lblTgtDeptName" runat="Server"></asp:Label>
                                                    </td> 
                                                </tr>
                                                <tr runat="server" id="trTgtEmpName">
                                                    <td class="cssTblTitle" width="120px">피평가자 부서/명</td> 
                                                    <td class="cssTblContent" colspan="3">
                                                        <asp:Label ID="lblTgtEmpName" runat="Server"></asp:Label>
                                                    </td> 
                                                </tr>
                                                <tr runat="server" id="trCurPoint">
                                                    <td class="cssTblTitle" width="120px">현재 점수</td> 
                                                    <td class="cssTblContent" colspan="3"> 
                                                        <asp:Label ID="lblPoint" runat="Server"></asp:Label>
                                                    </td> 
                                                </tr>
                                                <tr runat="server" id="trCurGrade">
                                                    <td class="cssTblTitle" width="120px">현재 등급</td> 
                                                    <td class="cssTblContent" colspan="3"> 
                                                        <asp:Label ID="lblGrade" runat="Server"></asp:Label>
                                                    </td> 
                                                </tr>
                                            </table>
                                         </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr height="5">
                            <td></td>
                        </tr>
                        <tr>
                            <td style="height:100%;">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;height:100%;">
                                                    <tr>
                                                        <td style="height:100%;">
                                                            <table cellpadding="0" cellspacing="0" height="100%" width="100%">
                                                                <tr>
                                                                    <td style="height: 100%" valign="top">
                                                                        <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange" style="left: 0px">
							                                                <Bands>
								                                                <ig:UltraGridBand>
								                                                <Columns>
								                                                    <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" Hidden="True">
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_ID" Key="ESTTERM_SUB_ID" Hidden="True">
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_ID" Key="ESTTERM_STEP_ID" Hidden="True">
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="CTRL_EMP_ID" Key="CTRL_EMP_ID" Hidden="True">
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" Hidden="True">
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" Hidden="True">
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="CTRL_GRADE_ID" Key="CTRL_GRADE_ID" Hidden="true">
									                                                </ig:UltraGridColumn>
									                                                <ig:TemplatedColumn Key="CTRL_CONFIRM" Width="80px">
									                                                    <Header Caption="조정확정">
                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                        </Header>
                                                                                        <CellTemplate>
                                                                                            <asp:CheckBox ID="ckbCtrlConfirm" runat="server" style="cursor:pointer;"  />
                                                                                        </CellTemplate>
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </ig:TemplatedColumn>
									                                                <ig:UltraGridColumn BaseColumnName="CTRL_SEQ" Key="CTRL_SEQ" Width="100px" HeaderText="조정차수">
										                                                <Header Caption="조정차수">
                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                        </Header>
										                                                <HeaderStyle HorizontalAlign="Center" />
										                                                <CellStyle HorizontalAlign="Center"/>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                        </Footer>
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="CTRL_EMP_NAME" Key="CTRL_EMP_NAME" Width="80px" HeaderText="조정자명">
										                                                <Header Caption="조정자명">
											                                                <RowLayoutColumnInfo OriginX="9" />
										                                                </Header>
										                                                <HeaderStyle HorizontalAlign="Center" />
										                                                <CellStyle HorizontalAlign="Center"/>
										                                                <Footer>
											                                                <RowLayoutColumnInfo OriginX="9" />
										                                                </Footer>
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="CTRL_POINT" Key="CTRL_POINT" Width="80px" HeaderText="수정점수" Format="#,##0.00">
										                                                <Header Caption="수정점수">
											                                                <RowLayoutColumnInfo OriginX="10" />
										                                                </Header>
										                                                <HeaderStyle HorizontalAlign="Center" />
										                                                <CellStyle HorizontalAlign="Right"/>
										                                                <Footer>
											                                                <RowLayoutColumnInfo OriginX="10" />
										                                                </Footer>
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="CTRL_GRADE_NAME" Key="CTRL_GRADE_NAME" Width="80px" HeaderText="수정등급">
										                                                <Header Caption="수정등급">
											                                                <RowLayoutColumnInfo OriginX="11" />
										                                                </Header>
										                                                <HeaderStyle HorizontalAlign="Center" />
										                                                <CellStyle HorizontalAlign="Center"/>
										                                                <Footer>
											                                                <RowLayoutColumnInfo OriginX="11" />
										                                                </Footer>
									                                                </ig:UltraGridColumn>
									                                                <ig:UltraGridColumn BaseColumnName="CTRL_OPINION" Key="CTRL_OPINION" Width="120px" HeaderText="조정자 의견">
										                                                <Header Caption="조정자 의견">
											                                                <RowLayoutColumnInfo OriginX="12" />
										                                                </Header>
										                                                <HeaderStyle HorizontalAlign="Center" />
										                                                <CellStyle HorizontalAlign="Left"/>
										                                                <Footer>
											                                                <RowLayoutColumnInfo OriginX="12" />
										                                                </Footer>
									                                                </ig:UltraGridColumn>
							                                                    </Columns>
							                                                </ig:UltraGridBand>
							                                                </Bands>
							                                                <DisplayLayout  CellPaddingDefault="2" 
                                                                                            AllowColSizingDefault="Free" 
                                                                                            AllowDeleteDefault="Yes"
                                                                                            AllowSortingDefault="Yes" 
                                                                                            BorderCollapseDefault="Separate"
                                                                                            HeaderClickActionDefault="NotSet" 
                                                                                            Name="UltraWebGrid1" 
                                                                                            RowHeightDefault="20px"
                                                                                            RowSelectorsDefault="No" 
                                                                                            SelectTypeRowDefault="Extended" 
                                                                                            Version="4.00" 
                                                                                            CellClickActionDefault="RowSelect" 
                                                                                            TableLayout="Fixed" 
                                                                                            StationaryMargins="Header" 
                                                                                            ReadOnly="LevelTwo"
                                                                                            OptimizeCSSClassNamesOutput="False"
                                                                                            AutoGenerateColumns="False">
							                                                    <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                                                                <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate"  />
							                                                </DisplayLayout>
						                                                </ig:UltraWebGrid>	                                                       
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25">
                                                            &nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblCtrlMsg" ForeColor="#C00000"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:100%;">
                                                            <table cellpadding="0" cellspacing="0"  style="width: 100%;height:100%;">
                                                                <tr>
                                                                    <td>
                                                                        <table class="tableBorder" cellpadding="0" cellspacing="1" width="100%">
                                                                            <tr runat="server" id="trCtrlPoint">
                                                                                <td class="cssTblTitle" width="120px">수정점수</td> 
                                                                                <td class="cssTblContent" colspan="3"> 
                                                                                    <asp:textbox id="txtCtrlPoint" runat="server" MaxLength="50" Width="60px"></asp:textbox>
                                                                                </td> 
                                                                            </tr>
                                                                            <tr runat="server" id="trCtrlGrade">
                                                                                <td class="cssTblTitle" width="120px">수정등급</td> 
                                                                                <td class="cssTblContent" colspan="3"><asp:dropdownlist id="ddlCtrlGradeID" runat="server" class="box01"></asp:dropdownlist></td> 
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="cssTblTitle" width="120px">조정자 의견</td> 
                                                                                <td class="cssTblContent" colspan="3"> 
                                                                                    <asp:textbox id="txtCtrlOpinion" runat="server" MaxLength="50" Width="98%"></asp:textbox>
                                                                                </td> 
                                                                            </tr>
                                                                        </table>
                                                                     </td>
                                                                </tr>
                                                            </table>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr align="right">
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="30%">
	                                                                    &nbsp;<ASP:IMAGEBUTTON id="ibnCtrlConfirm" runat="server" imageurl="../images/btn/b_153.gif" OnClick="ibnCtrlConfirm_Click" CommandName="BIZ_CTRL_CONFIRM" Visible="False"/>
                                                                    </td>
                                                                    <td class="cssPopBtnLine">
                                                                        
							                                            <asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
							                                            <asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" CommandName="BIZ_CTRL_SAVE" Visible="False"></asp:ImageButton>
                                                                        <asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click"></asp:ImageButton>
                                                                        <a href="javascript:window.close();"><img src="../images/btn/b_003.gif" border="0"/></a>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:HiddenField ID="hdfCompID" runat="server" />
                                                <asp:HiddenField ID="hdfEstID" runat="server" />
                                                <asp:HiddenField ID="hdfEstTermRefID" runat="server" />
                                                <asp:HiddenField ID="hdfEstTermSubID" runat="server" />
                                                <asp:HiddenField ID="hdfEstTermStepID" runat="server" />
                                                <asp:HiddenField ID="hdfCtrlEmpID" runat="server" />
                                                <asp:HiddenField ID="hdfTgtDeptID" runat="server" />
                                                <asp:HiddenField ID="hdfTgtEmpID" runat="server" />
                                                <asp:HiddenField ID="hdfCtrlSeq" runat="server" />
                                                <asp:HiddenField ID="hdfCtrlStep" runat="server" />
                                                <asp:Literal ID="ltrScript" runat="server"></asp:Literal></div>
                                        
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>      
    <script>gfWinFocus();</script>
    <!--- MAIN END --->
    </form>
</body>
</html>