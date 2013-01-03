<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST0901M1_01.aspx.cs" Inherits="EST_EST0901M1_01" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
    <head id="header" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.3)" />
        <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.3)" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
        <style type="text/css">
            html   { height: 100%; width: 100%; }
            body { height: 100%; width: 100%; margin: 0px; }
            form  { height: 100%; width: 100%; }
            .editCellStyle  { margin: 2px; padding: 2px; border: solid 1px red; font-weight: bold;}
            .rowTemplateStyle { border-left: Ridge 2px white; border-top: Ridge 2px white; border-right: Ridge 2px white; border-bottom: Ridge 2px white; }
            .rowStyle     { background-color: #FCFEFE; border-color: #E5E5E5; border-style: Solid; border-width: 1px; padding: 0px 0px 0px 2px;}
            .selectedRowStyle { background-color: #FCFEFE; border-color: #E5E5E5; border-style: Solid; border-width: 1px; padding: 0px 0px 0px 2px;}
            .headerStyle { background-color: #94BAC9; border-left: solid 1px #94BAC9; border-top: solid 1px #94BAC9; border-right: solid 1px #E5E5E5; border-bottom: solid 1px #E5E5E5; text-align: center; color: #FFFFFF; font-weight: bold;}
            .frameStyle   { background-color: #FFFFFF; border-color: #E9EBEB; border-style: solid; border-width: 3px; height: 100%; width: 100%;}
        </style>
        <script type="text/javascript">
            var gridId = "<%= this.gridStdDevSetting.ClientID %>";
            function addRow() {
                var grid = igtbl_getGridById(gridId);

                var newRow = grid.Rows.addNew();
                
                return false;
            }

            function deleteRow() {
                var grid = igtbl_getGridById(gridId);

                for (var rowNo = grid.Rows.length - 1; rowNo >= 0; rowNo--) {
                    var rowObject = grid.Rows.getRow(rowNo);
                    var cellObject = rowObject.getCellFromKey("checkDel");
                    if (cellObject.getValue() == "true")
                        rowObject.remove(false);
                }

                return false;
            }

            function afterEnterEditModeEvent(gridId, cellId) {
                var grid = igtbl_getGridById(gridId);
                var cell = igtbl_getCellById(cellId);

                var inputElem = document.getElementById(gridId + "_tb");
            }

            function beforeExitEditModeEvent(gridId, cellId) {
                var grid = igtbl_getGridById(gridId);
                var cell = igtbl_getCellById(cellId);

                var oCtrl = cell.band.Grid;

                var inputElem = document.getElementById(gridId + "_tb");
            } 
        </script>
    </head>
    <body>
        <form id="frmStdDevSetting" runat="server">
            <!--- MAIN START --->	
            <table cellpadding="0" cellspacing="0" width="100%" >
                <tr><!-- 타이틀 -->
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width=100%">
                            <tr> 
                                <td valign="top" background="../images/title/popup_t_bg.gif"> 
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr> 
                                            <td height="40" valign="top"><img runat="server" id="imgTitle" src="../images/title/popup_t83.gif" alt="imageTitle" ></td>
                                            <td align="right" valign="top"><img src="../images/title/popup_img.gif" alt="imagePop"></td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr> 
                                            <td width="50%" height="4" bgcolor="#FFFFFF"></td>
                                            <td width="50%" bgcolor="#FFFFFF"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               <tr class="cssPopContent">
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                <tr><!-- 조회조건 -->
                    <td>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <table class="tableBorder" cellpadding="0" cellspacing="1" width="100%">
                                        <tr runat="server" id="trTgtDeptName">
                                            <td class="cssTblTitleSingle" style="width: 120px;">평가기간</td> 
                                            <td class="cssTblContent" style="width: auto;"> 
                                                <asp:DropDownList runat="server" ID="ddlTerm" Width="150px" />
                                            </td> 
                                        </tr>                                                    
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td></td>
                </tr>
                <tr><!-- 그리드 -->
                      <td valign="top" style="height: 470px">
                        <ig:WebTextEdit ID="txtNormalEditor" runat="server" MaxLength="10" CssClass="editCellStyle"></ig:WebTextEdit>
                        <ig:WebNumericEdit ID="txtNumberEditor" runat="server" MaxLength="5" Nullable="false" CssClass="editCellStyle" DataMode="Float" ></ig:WebNumericEdit>
                        <ig:UltraWebGrid id="gridStdDevSetting" runat="server" Width="100%" Height="100%">
                            <Bands>                            
                                <ig:UltraGridBand>
                                    <Columns>
                                        <ig:UltraGridColumn Key="checkDel" AllowUpdate="Yes" Type="CheckBox" Width="30px">
                                            <Header Caption="삭제"></Header>                                            
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn Key="ScoreCode" AllowNull="false" DataType="System.String" Type="Custom" BaseColumnName="SCORE_CODE" >
                                            <Header Caption="등급코드" />
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn Key="ScoreName" AllowNull="false" DataType="System.String" Type="Custom" BaseColumnName="SCORE_NAME">
                                            <Header Caption="등급명" />
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn Key="MinValue" DataType="System.Double" Format="#,###.00" Type="Custom" BaseColumnName="MIN_VALUE">
                                            <Header Caption="하한값" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Right"/>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn Key="MaxValue" DataType="System.Double" Format="#,###.00" Type="Custom" BaseColumnName="MAX_VALUE">
                                            <Header Caption="상한값"/>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Right" />
                                        </ig:UltraGridColumn>		                                                
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout  CellPaddingDefault="2" 
                                        AllowColSizingDefault="Free"
                                        AllowDeleteDefault="Yes"
                                        AllowSortingDefault="No"
                                        AllowUpdateDefault="Yes"
                                        BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="NotSet" 
                                        Name="gridStdDevSetting" 
                                        RowHeightDefault="20px"
                                        RowSelectorsDefault="No" 
                                        SelectTypeRowDefault="Extended"
                                        Version="4.00" 
                                        CellClickActionDefault="RowSelect" 
                                        TableLayout="Fixed" 
                                        StationaryMargins="Header" OptimizeCSSClassNamesOutput="False"
                                        AutoGenerateColumns="False" AllowAddNewDefault="Yes">
                                <%--<RowStyleDefault CssClass="rowStyle" />
                                <SelectedRowStyleDefault CssClass="selectedRowStyle" />
                                <HeaderStyleDefault CssClass="headerStyle" />
                                <FrameStyle CssClass="frameStyle" Height="100%" Width="100%" />
                                <EditCellStyleDefault CssClass="editCellStyle"></EditCellStyleDefault>--%>
                                
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
                
                <tr style="height: 5px;">
                    <td></td>
                </tr>
                
                <tr class="cssPopContent"><!-- 버튼영역 -->
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" width="30%">
                                    &nbsp;
                                </td>
                                <td style="text-align: right;">
                                    <asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClientClick="return addRow();" ></asp:ImageButton>
                                    <asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClientClick="return true;" OnClick="iBtnSave_Click"></asp:ImageButton>
                                    <asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClientClick="return deleteRow();"></asp:ImageButton>
                                    <asp:ImageButton id="ibtnClose" runat="server" ImageUrl="../images/btn/b_003.gif" OnClientClick="return false;"></asp:ImageButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </table></td></tr>
            </table>
            <!--- MAIN END --->
        </form>
    </body>
</html>