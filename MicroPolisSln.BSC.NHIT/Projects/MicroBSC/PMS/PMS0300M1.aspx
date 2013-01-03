<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMS0300M1.aspx.cs" Inherits="PMS_PMS0300M1" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />


<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">
    function CloseWindow() {
        self.close();
    }

    function TGT_EMP_EST_POPUP(TGT_DEPT_ID, TGT_EMP_ID) {
        var url = "PMS_Q_PAGE_03.aspx";
        
        
        var PRJ_REF_ID = document.getElementById("hdf_PRJ_REF_ID").value;
        var PRJ_CODE = document.getElementById("hdf_PRJ_CODE").value;
        var COMP_ID = document.getElementById("hdf_COMP_ID").value;
        var EST_ID = document.getElementById("hdf_EST_ID").value;
        var ESTTERM_REF_ID = document.getElementById("hdf_ESTTERM_REF_ID").value;
        var ESTTERM_SUB_ID = document.getElementById("hdf_ESTTERM_SUB_ID").value;
        var ESTTERM_STEP_ID = document.getElementById("hdf_ESTTERM_STEP_ID").value;
        var EST_DEPT_ID = document.getElementById("hdf_EST_DEPT_ID").value;
        var EST_EMP_ID = document.getElementById("hdf_EST_EMP_ID").value;


        var querystring =   "?PRJ_REF_ID=" + PRJ_REF_ID
                          + "&PRJ_CODE=" + PRJ_CODE
                          + "&COMP_ID=" + COMP_ID
                          + "&EST_ID=" + EST_ID
                          + "&ESTTERM_REF_ID=" + ESTTERM_REF_ID
                          + "&ESTTERM_SUB_ID=" + ESTTERM_SUB_ID
                          + "&ESTTERM_STEP_ID=" + ESTTERM_STEP_ID
                          + "&EST_DEPT_ID=" + EST_DEPT_ID
                          + "&EST_EMP_ID=" + EST_EMP_ID
                          + "&TGT_DEPT_ID=" + TGT_DEPT_ID
                          + "&TGT_EMP_ID=" + TGT_EMP_ID;
                          + "&EST_TGT_TYPE=TGT";

        gfOpenWindow(url + querystring, 800, 500, 'yes', 'no', 'TGT_EMP');
    }

    function doCanceling() {
        return confirm("확정 취소 할까요?");
    }
</script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();">

<form id="form1" runat="server">
    <div>
        <table width="100%" style="height:100%" border="0" cellspacing="0" cellpadding="0">
            <tr> 
                <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                            <%--<td style="width:170px; height:40px; background-image:url(../images/title/popup_title.gif); vertical-align:middle; padding-left:70px;">
                              <asp:Label ID="Label1" runat="server" Font-Size="Medium" Font-Italic="false" Font-Bold="true" ForeColor="white" Text="프로젝트 평가 결과" />
                            </td>--%>
                            <td style="width:170px; height:40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                                <asp:Label ID="lblPopUpTitle" runat="server" CssClass="cssPopTitleTxt" Text="프로젝트 평가 결과"></asp:Label>
                            </td>
                            <td align="right" valign="top">
                                <img alt="" src="../images/title/popup_img.gif" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                            <td style="width:50%; background-color:#FFFFFF"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            
            
            
            <%--<tr>
                <td>
                    <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
                        <tr>
                            <td class="cssTblTitle" style="width:20%;"></td>
                            <td class="cssTblContent" style="width:80%;"></td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" style="width:20%;"></td>
                            <td class="cssTblContent" style="width:80%;"></td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" style="width:20%;"></td>
                            <td class="cssTblContent" style="width:80%;"></td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" style="width:20%;"></td>
                            <td class="cssTblContent" style="width:80%;"></td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" style="width:20%;"></td>
                            <td class="cssTblContent" style="width:80%;"></td>
                        </tr>

                        <tr>
                            <td class="cssTblTitle" style="width:20%;"></td>
                            <td class="cssTblContent" style="width:80%;"></td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" style="width:20%;"></td>
                            <td class="cssTblContent" style="width:80%;"></td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            
            
            
            
            
            <tr class="cssPopContent" style="height:55%;">
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                    <tr>
                                        <td style="width:15px;">
                                            <img src="../images/title/ma_t14.gif" alt="" />
                                        </td>
                                        <td>
                                            <asp:Label id="lblStep1" runat="server" style="font-weight:bold" text="프로젝트 평가" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height:100%;">
                            <td>
                                <ig:UltraWebGrid    id="uwgrid_Weight" runat="server" Width="100%" Height="100%"
                                                    OnInitializeRow="uwgrid_Weight_InitializeRow">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_CUSTOM_YN" Key="PRJ_COL_CUSTOM_YN" Hidden="true">
                                                    <Header Caption="PRJ_COL_CUSTOM_YN" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_ID" Key="PRJ_COL_ID" Hidden="true">
                                                    <Header Caption="PRJ_COL_ID" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_VIEW" Key="PRJ_COL_VIEW" Width="40px">
                                                    <Header Caption="관점" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center"/>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_NAME" Key="PRJ_COL_NAME" Width="120px">
                                                    <Header Caption="평가항목" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left"/>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_NOTE" Key="PRJ_COL_NOTE" Width="395px">
                                                    <Header Caption="평가세부설명" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left" Wrap="true"/>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_SOOSIK" Key="PRJ_COL_SOOSIK" Width="100px">
                                                    <Header Caption="산식" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left"/>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_EST_STATE" Key="PRJ_COL_EST_STATE" Width="100px">
                                                    <Header Caption="평가시점" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center"/>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_WEIGHT" Key="PRJ_COL_WEIGHT" Width="55px"  Format="#,##0.#0">
                                                    <Header Caption="가중치" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer Total="Sum" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_VALUE" Key="PRJ_COL_VALUE" Width="45px" AllowUpdate="Yes" Format="#,##0.#0">
                                                    <Header Caption="점수" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer Total="Text" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="" Key="PRJ_COL_CAL" Width="55px"  Format="#,##0.#0">
                                                    <Header Caption="총점" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer Total="Sum" />
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout  BorderCollapseDefault="Separate" 
                                                    RowHeightDefault="33px" 
                                                    CellClickActionDefault="RowSelect" 
                                                    TableLayout="Fixed"
                                                    RowSelectorsDefault="No" 
                                                    OptimizeCSSClassNamesOutput="False"
                                                    AutoGenerateColumns="False"
                                                    ColFootersVisibleDefault="Yes">
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
                </td>
            </tr>
            
            
            <tr style="height:10px;">
                <td>&nbsp;</td>
            </tr>
            
            
            
            <tr class="cssPopContent" style="height:80px;">
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                        <tr>
                            <td style="width:35%;">
                                <ig:UltraWebGrid    id="uwgrid_Difficulty" runat="server" Width="100%" Height="100%">
			                        <Bands>
				                        <ig:UltraGridBand>
				                            <Columns>
				                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_ID" Key="PRJ_COL_ID" Hidden="true">
                                                    <Header Caption="PRJ_COL_ID" />
                                                </ig:UltraGridColumn>
				                                <ig:UltraGridColumn BaseColumnName="PRJ_COL_NAME" Key="PRJ_COL_NAME" Width="30%">
						                            <Header Caption="난이도" />
						                            <HeaderStyle HorizontalAlign="Center" />
						                            <CellStyle HorizontalAlign="Left"/>
					                            </ig:UltraGridColumn>
					                            <ig:UltraGridColumn BaseColumnName="PRJ_COL_NOTE" CellMultiline="Yes" Key="PRJ_COL_NOTE" Width="50%">
						                            <Header Caption="난이도 설명" />
						                            <HeaderStyle HorizontalAlign="Center" />
						                            <CellStyle HorizontalAlign="Left"/>
					                            </ig:UltraGridColumn>
					                            <ig:UltraGridColumn BaseColumnName="PRJ_COL_VALUE" Key="PRJ_COL_VALUE" Width="20%">
						                            <Header Caption="점수" />
						                            <HeaderStyle HorizontalAlign="Center" />
						                            <CellStyle HorizontalAlign="Right"/>
						                        </ig:UltraGridColumn>
						                        
					                        </Columns>
				                        </ig:UltraGridBand>
			                        </Bands>
			                        <DisplayLayout  CellPaddingDefault="2"
		                                            BorderCollapseDefault="Separate" 
		                                            RowHeightDefault="25px" 
		                                            CellClickActionDefault="RowSelect" 
		                                            TableLayout="Fixed" 
		                                            RowSelectorsDefault="No"
		                                            ReadOnly="LevelTwo"
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
                            <td id="tdCalcBtnMargin" runat="server" visible="false">&nbsp;</td>
                            <td style="width:4%;" id="tdCalcBtn" runat="server" visible="false">
                                <asp:ImageButton ID="ibnCalcPrjEstPoint" runat="server" Height="99%" ImageUrl="../images/btn/b_310.gif" OnClick="ibnCalcPrjEstPoint_Click" style="cursor:pointer;" Visible="false" />
                            </td>
                            <td align="center"><asp:Label runat="server" Text=">>"></asp:Label></td>
                            <td style="width:280px;">
                                <table class="tableBorder" width="100%" border="0" cellspacing="0" cellpadding="0" style="height:99%; border-bottom:#e5e5e5 1px solid;">
                                    <tr style="height:20px;">
                                        <td class="cssTblTitle" style="text-align:center;">계산식</td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblContent" style="height:100%; padding-left:0px;" align="center">
                                            <asp:Label id="lblCommonSoosik" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label id="lblCommonSoosik_Desc" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="center"><asp:Label runat="server" Text=">>"></asp:Label></td>
                            <td id="tblCol_PrjEstPoint" runat="server" style=" padding-right:10px; background-image:url(../images/dashboard/bg_box3.jpg); background-repeat:no-repeat; background-position:left; width:95px; font-size:30px; font-weight:bold; text-align:center;">
                                <asp:Label ID="lblPrjEstPoint" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            
            <tr style="height:10px;">
                <td>&nbsp;</td>
            </tr>
            
            
            <tr class="cssPopContent" style="height:100%;">
                <td>
                    <ig:UltraWebGrid    id="uwgrid_TGT_EMP_LIST" runat="server" Width="100%" Height="100%"
                                        OnInitializeRow="uwgrid_TGT_EMP_LIST_InitializeRow">
                        <Bands>
                            <ig:UltraGridBand>
                                <Columns>
                                    <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" Key="PRJ_REF_ID" Hidden="true">
		                                <Header Caption="PRJ_REF_ID" />
	                                </ig:UltraGridColumn>
	                                <ig:UltraGridColumn BaseColumnName="PRJ_CODE" Key="PRJ_CODE" Hidden="true">
		                                <Header Caption="PRJ_CODE" />
	                                </ig:UltraGridColumn>
	                                <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" Hidden="true">
		                                <Header Caption="TGT_DEPT_ID" />
	                                </ig:UltraGridColumn>
	                                <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" Hidden="true">
		                                <Header Caption="TGT_EMP_ID" />
	                                </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="EST_STATUS" Key="EST_STATUS" Width="40px">
		                                <Header Caption="상태" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Center"/>
	                                </ig:UltraGridColumn>
	                                <ig:UltraGridColumn BaseColumnName="TGT_EMP_NAME" Key="TGT_EMP_NAME" Width="130px">
		                                <Header Caption="피평가자" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Left"/>
		                            </ig:UltraGridColumn>
		                            <ig:UltraGridColumn BaseColumnName="TGT_DEPT_NAME" Key="TGT_DEPT_NAME">
		                                <Header Caption="부서" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Left"/>
		                            </ig:UltraGridColumn>
		                            <ig:UltraGridColumn BaseColumnName="TGT_EMP_ROLE_NAME" Key="TGT_EMP_ROLE_NAME" Width="60px">
		                                <Header Caption="역할" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Left"/>
		                            </ig:UltraGridColumn>
		                            <ig:UltraGridColumn BaseColumnName="TGT_EMP_GRADE_NAME" Key="TGT_EMP_GRADE_NAME" Width="60px">
		                                <Header Caption="기술등급" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Center"/>
		                            </ig:UltraGridColumn>
		                            <ig:UltraGridColumn BaseColumnName="EMP_WORK_MM" Key="EMP_WORK_MM" Width="70px">
		                                <Header Caption="투입M/M" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Center"/>
		                            </ig:UltraGridColumn>
		                            <ig:UltraGridColumn BaseColumnName="EMP_WORK_PERIOD" Key="EMP_WORK_PERIOD" Width="30%">
		                                <Header Caption="투입기간" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Center"/>
		                            </ig:UltraGridColumn>
		                            <ig:UltraGridColumn BaseColumnName="POINT" Key="POINT">
		                                <Header Caption="기여도 평가점수" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Right"/>
		                            </ig:UltraGridColumn>
		                            <ig:UltraGridColumn BaseColumnName="EST_BTN" Key="EST_BTN" Width="60px">
		                                <Header Caption="평가하기" />
		                                <HeaderStyle HorizontalAlign="Center" />
		                                <CellStyle HorizontalAlign="Center"/>
		                            </ig:UltraGridColumn>
	                            </Columns>
                            </ig:UltraGridBand>
                        </Bands>
                        <DisplayLayout  CellPaddingDefault="2"
                                        BorderCollapseDefault="Separate" 
                                        RowHeightDefault="20px" 
                                        CellClickActionDefault="RowSelect" 
                                        TableLayout="Fixed" 
                                        RowSelectorsDefault="No"
                                        OptimizeCSSClassNamesOutput="False"
                                        AutoGenerateColumns="False"
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
            
            <tr style="height:5px">
            <td></td></tr>
            
            <tr class="cssPopContent">
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                        <tr>
                            <td style="padding-left:5px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                                    <tr>
                                        <td style="width:15px;"><img src="../images/icon/color/red.gif" /></td>
                                        <td style="width:40px;">미확인</td>
                                        <td style="width:15px;"><img src="../images/icon/color/green.gif" /></td>
                                        <td style="width:40px;">평가중</td>
                                        <td style="width:15px;"><img src="../images/icon/color/blue.gif" /></td>
                                        <td>확정</td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right">
                                <asp:ImageButton ID="ibnSaveEst" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSaveEst_Click" Visible="false" />&nbsp;
                                <asp:ImageButton ID="ibnConfirmEst" runat="server" ImageUrl="../images/btn/b_015.gif" OnClick="ibnConfirmEst_Click" Visible="false" />&nbsp;
                                <asp:ImageButton ID="ibnCancelEst" runat="server" ImageUrl="../images/btn/b_178.gif" OnClick="ibnCancelEst_Click" Visible="false" OnClientClick="return doCanceling();"/>&nbsp;
                                <asp:ImageButton ID="ibnClose" runat="server" ImageUrl="../images/btn/b_003.gif" OnClientClick="CloseWindow()" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            
          
            
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                            <td style="width:50%; background-color:#FFFFFF"></td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdf_PRJ_REF_ID" runat="server" Value="" />
                    <asp:HiddenField ID="hdf_PRJ_CODE" runat="server" Value="" />
                    <asp:HiddenField ID="hdf_COMP_ID" runat="server" Value="" />
                    <asp:HiddenField ID="hdf_EST_ID" runat="server" Value="" />
                    <asp:HiddenField ID="hdf_ESTTERM_REF_ID" runat="server" Value="" />
                    <asp:HiddenField ID="hdf_ESTTERM_SUB_ID" runat="server" Value="" />
                    <asp:HiddenField ID="hdf_ESTTERM_STEP_ID" runat="server" Value="" />
                    <asp:HiddenField ID="hdf_EST_DEPT_ID" runat="server" Value="" />
                    <asp:HiddenField ID="hdf_EST_EMP_ID" runat="server" Value="" />
                    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
</form>
</body>
</html>
