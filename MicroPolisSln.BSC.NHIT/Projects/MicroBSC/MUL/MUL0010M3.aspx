<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MUL0010M3.aspx.cs" Inherits="MUL_MUL0010M3" %>

<html>
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();">

<form id="form1" runat="server">
<div>
    <table width="100%" style="height:100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                        <%--<td style="width:180px; height:40px; background-image:url(../images/title/popup_title.gif); vertical-align:middle; padding-left:70px;">
                          <asp:Label ID="Label1" runat="server" Font-Size="13" Font-Italic="false" Font-Bold="true" ForeColor="white" Text="다면평가 상세결과"></asp:Label>
                        </td>--%>
                        <td style="width:180px; height:40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                                <asp:Label ID="lblPopUpTitle" runat="server" CssClass="cssPopTitleTxt" Text="다면평가 상세결과"></asp:Label>
                            </td>
                        <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif" /></td>
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
       
       <tr class="cssPopContent">
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
        <tr>
            <td>
                <table class="tableBorder" width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td class="cssTblTitle" style="width:20%;">피평가부서</td>
                        <td class="cssTblContent"  style="width:80%;">
                          <asp:Label ID="lblTGT_DEPT_NAME" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">피평가자</td>
                        <td class="cssTblContent">
                            <asp:Label ID="lblTGT_EMP_NAME" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">점수</td>
                        <td class="cssTblContent">
                            <asp:Label ID="lblAVG_POINT" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr style="height:5px;">
            <td></td>
        </tr>
        
        <tr>
            <td>
                <table  cellpadding="0" cellspacing="0" border="0" style=" width:100%;">
                    <tr>
                        <td style="width:15px;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                        <td>평가 상세정보</td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr style="height:100%;">
            <td>
                <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
					            <Bands>
						            <ig:UltraGridBand>
						                <Columns>
							                <ig:UltraGridColumn BaseColumnName="EST_STEP_NAME" Key="EST_STEP_NAME" Width="25%">
								                <Header Caption="차수" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center"/>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" Key="EST_DEPT_NAME" Width="25%">
								                <Header Caption="평가자 부서" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Left"/>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="EST_EMP_NAME" Key="EST_EMP_NAME" Width="25%">
								                <Header Caption="평가자 명" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center" />
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="EST_POINT" Key="EST_POINT" Width="15%">
								                <Header Caption="점수" />
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Right" />
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
        
        
        <tr class="cssPopBtnLine">
            <td align="right">
                <a href="javascript:self.close();"><img src="../images/btn/b_003.gif" /></a>
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
                <asp:Literal ID="ltrScript" runat="server" ></asp:Literal>                
            </td>
        </tr>
        </table></td></tr>
    </table>
</div>
</form>
</body>
</html>
