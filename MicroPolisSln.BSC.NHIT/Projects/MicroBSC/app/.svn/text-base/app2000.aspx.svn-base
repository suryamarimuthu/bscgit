<%@ Page Language="C#" AutoEventWireup="true" CodeFile="app2000.aspx.cs" Inherits="app_app2000" %>
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
<%@ Register TagPrefix="TitleControl" TagName="TitleControl" Src="~/_common/lib/ServiceTitleControl.ascx" %>


    
    
<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html; " />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

        <script id="Infragistics" type="text/javascript">
        <!--
            function MouseUpHandler(gridName, id, button)
            {
                if (!gfWG_isColumnHeader(id))
                {
	                var cell    = igtbl_getElementById(id);
                    var row     = igtbl_getRowById(id);
                    
                    var sAppRefID = row.getCellFromKey("V_APP_REF_ID").getValue();
                    
                    if (sAppRefID != "")
                    {
                        Callback1.Callback(sAppRefID);
                    }
                }
            }// 
            
            function mfConfirmCheck()
            {
                var grid = igtbl_getGridById("UltraWebGrid1");
                var iChecked = 0;
                var bCheck = false;
                
                for(var i=0; i < grid.Rows.length; i++)
                {
                    var checkVal = grid.Rows.getRow(i).getCell(0).getValue().toLowerCase();
                    
                    if (checkVal == "true")
                    {
                        if (!bCheck) bCheck = true;
                        iChecked++;
                    }
                }
                
                if (iChecked > 0)
                {
                    return (confirm("선택된 [" + iChecked + "]건을 상신취소 처리하시겠습니까?\n\n상신취소 하시면 다시 되돌릴 수 없습니다!"))
                }
                else
                {
                    alert(sGubun + " 처리를 하시려면 먼저 선택하셔야 합니다!");
                    return false;
                }
                
            }
        -->
        </script>
    </head>
    <body style="margin:0 0 0 0 ; background-color:#FFFFFF">
        <form id="form1" runat="server">
            <div>
                <table BORDER=0  width="100%" CELLPADDING="0" CELLSPACING="0">
                    <tr>
	                    <td align="center" valign="top">
                            <MenuControl:MenuControl ID="MenuControl1" runat="server" />
                            <!--- MAIN START --->	
		                    
                            
		                    <TABLE cellpadding=2 cellspacing=0 border=0 height="100%">
                                <tr>
                                    <td class="tableOutBorder"  width="100%" height="44px">
		                                <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                            <tr>
                                                <td class="tableTitle" style="width: 15%">업무 구분</td>
                                                <td class="tableContent">
                                                    <ASP:DROPDOWNLIST id="ddlAppGubun" runat="server"></ASP:DROPDOWNLIST>
                                                </td>
                                                <td class="tableTitle" style="width: 15%">평가 기간</td>
                                                <td class="tableContent">
                                                    <ASP:DROPDOWNLIST id="ddlEstTerm" runat="server"></ASP:DROPDOWNLIST>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tableTitle" style="width: 15%">결재 유형</td>
                                                <td class="tableContent" colspan="3">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <ASP:DROPDOWNLIST id="ddlAppType" runat="server"></ASP:DROPDOWNLIST>
                                                            </td>
                                                            <td width="100%" align="right">
                                                                <ASP:IMAGEBUTTON id="iBtnSearch" runat="server" imagealign="absBottom" imageurl="../images/btn/b_033.gif" onclick="iBtnSearch_Click"  />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
		                            </td>
                                </tr>
		                        <tr valign=top>
			                        <td id="tdUltra"
			                            style="
			                                   height:expression(eval(document.body.clientHeight)-(eval(document.body.clientHeight)/1.5))
			                                  "
			                        >
                                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="100%" oninitializelayout="UltraWebGrid1_InitializeLayout" oninitializerow="UltraWebGrid1_InitializeRow" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:TemplatedColumn HeaderText="선택" Key="SelChk" Width="40px" type="CheckBox" allowgroupby="No" allowupdate="Yes" >
                                                    <Header Caption="선택">
                                                    </Header>
                                                    <CELLSTYLE verticalalign="Top" horizontalalign="Center"></CELLSTYLE>
                                                </ig:TemplatedColumn>
                                                
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_APP_TYPE_NAME" width="110px" headertext="문서타입" key="V_APP_TYPE_NAME">
                                                    <HEADER caption="문서타입">
                                                        <ROWLAYOUTCOLUMNINFO originx="1" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="1" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Left"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN width="135px" basecolumnname="V_APP_REF_ID" headertext="문서번호" key="V_APP_REF_ID" nulltext="문서번호">
                                                    <HEADER caption="문서번호">
                                                        <ROWLAYOUTCOLUMNINFO originx="2" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="2" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_KPI_CODE" headertext="KPI 코드" key="V_KPI_CODE" width="80px">
                                                    <HEADER caption="KPI 코드">
                                                        <ROWLAYOUTCOLUMNINFO originx="3" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="3" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Center"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_KPI_NAME" headertext="KPI 명" key="V_KPI_NAME" width="180px">
                                                    <HEADER caption="KPI 명">
                                                        <ROWLAYOUTCOLUMNINFO originx="4" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="4" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_KPI_RESULT" headertext="KPI실적" key="V_KPI_RESULT" format="#,###.###" width="60px">
                                                    <HEADER caption="KPI실적">
                                                        <ROWLAYOUTCOLUMNINFO originx="5" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="5" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Right"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN width="180px" basecolumnname="V_REP_TITLE" headertext="제 목" key="V_REP_TITLE">
                                                    <HEADER caption="제 목">
                                                        <ROWLAYOUTCOLUMNINFO originx="6" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="6" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Left"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN width="80px" basecolumnname="V_REP_EMP_NAME" headertext="상신자명" key="V_REP_EMP_NAME">
                                                    <HEADER caption="상신자명">
                                                        <ROWLAYOUTCOLUMNINFO originx="7" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="7" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Center"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN width="80px" basecolumnname="V_APP_EMP_NAME" headertext="결재자명" key="V_APP_EMP_NAME">
                                                    <HEADER caption="결재자명">
                                                        <ROWLAYOUTCOLUMNINFO originx="8" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="8" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Center"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN width="90px" hidden="True" basecolumnname="V_CUR_APP_STATUS" headertext="현재결재상태" key="V_CUR_APP_STATUS">
                                                    <HEADER caption="현재결재상태">
                                                        <ROWLAYOUTCOLUMNINFO originx="9" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="9" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Center"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN width="90px" hidden="True" basecolumnname="V_ALL_APP_STATUS" headertext="전체결재상태" key="V_ALL_APP_STATUS">
                                                    <HEADER caption="전체결재상태">
                                                        <ROWLAYOUTCOLUMNINFO originx="10" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="10" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Center"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN width="135px" basecolumnname="V_REP_DATE" datatype="System.DateTime" headertext="상신일" key="V_REP_DATE">
                                                    <HEADER caption="상신일">
                                                        <ROWLAYOUTCOLUMNINFO originx="11" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="11" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Center"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN width="135px" basecolumnname="V_APP_COMPDATE" datatype="System.DateTime" headertext="결재일" key="V_APP_COMPDATE">
                                                    <HEADER caption="결재일">
                                                        <ROWLAYOUTCOLUMNINFO originx="12" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="12" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Center"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:ULTRAGRIDCOLUMN hidden="True" basecolumnname="V_REMARK" headertext="취소사유" key="V_REMARK" width="200px">
                                                    <HEADER caption="취소사유">
                                                        <ROWLAYOUTCOLUMNINFO originx="13" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="13" />
                                                    </FOOTER>
                                                    <CELLSTYLE horizontalalign="Left"></CELLSTYLE>
                                                </ig:ULTRAGRIDCOLUMN>
                                                
                                                <ig:UltraGridColumn HeaderText="문서타입" basecolumnname="V_APP_CODE" key="V_APP_CODE" hidden="True">
                                                    <Header Caption="문서타입">
                                                        <RowLayoutColumnInfo OriginX="14" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="14" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_EVENT_ID" headertext="KPI문서정보" hidden="True" key="V_EVENT_ID">
                                                    <HEADER caption="KPI문서정보">
                                                        <ROWLAYOUTCOLUMNINFO originx="15" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="15" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_EVENT_ADD_ID" headertext="KPI문서추가정보" hidden="True" key="V_EVENT_ADD_ID">
                                                    <HEADER caption="KPI문서추가정보">
                                                        <ROWLAYOUTCOLUMNINFO originx="16" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="16" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_APP_STEP" headertext="현재결재단계" hidden="True" key="V_APP_STEP">
                                                    <HEADER caption="현재결재단계">
                                                        <ROWLAYOUTCOLUMNINFO originx="17" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="17" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_MAX_APP_STEP" headertext="전체결재단계" hidden="True" key="V_MAX_APP_STEP">
                                                    <HEADER caption="전체결재단계">
                                                        <ROWLAYOUTCOLUMNINFO originx="18" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="18" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_CUR_APP_STATUS_CD" headertext="현재결재상태 코드" hidden="True" key="V_CUR_APP_STATUS_CD">
                                                    <HEADER caption="현재결재상태 코드">
                                                        <ROWLAYOUTCOLUMNINFO originx="19" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="19" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_ALL_APP_STATUS_CD" headertext="전체결재상태 코드" hidden="True" key="V_ALL_APP_STATUS_CD">
                                                    <HEADER caption="전체결재상태 코드">
                                                        <ROWLAYOUTCOLUMNINFO originx="20" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="20" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_TERM_REF_ID" headertext="평가기간코드" hidden="True" key="V_TERM_REF_ID">
                                                    <HEADER caption="평가기간코드">
                                                        <ROWLAYOUTCOLUMNINFO originx="21" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="21" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_REP_EMP_ID" headertext="상신자" key="V_REP_EMP_ID" hidden="True">
                                                    <HEADER caption="상신자">
                                                        <ROWLAYOUTCOLUMNINFO originx="22" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="22" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                <ig:ULTRAGRIDCOLUMN basecolumnname="V_APP_EMP_ID" headertext="결재자" key="V_APP_EMP_ID" hidden="True">
                                                    <HEADER caption="결재자">
                                                        <ROWLAYOUTCOLUMNINFO originx="23" />
                                                    </HEADER>
                                                    <FOOTER>
                                                        <ROWLAYOUTCOLUMNINFO originx="23" />
                                                    </FOOTER>
                                                </ig:ULTRAGRIDCOLUMN>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                AllowSortingDefault="No" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="23px"
                                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="OutlookGroupBy" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                <GroupByBox>
                                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" font-bold="True" cursor="Hand" BorderColor="#E5E5E5" ForeColor="White">
                                                    <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                    Width="100%">
                                                </FrameStyle>
                                                <Pager>
                                                    <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </Style>
                                                </Pager>
                                                <AddNewBox Hidden="False">
                                                    <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </Style>
                                                </AddNewBox>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>
                                                <ClientSideEvents mouseuphandler="MouseUpHandler" />
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
		                        </tr>
		                        <tr>
			                        <td align="right">
			                            <ASP:IMAGEBUTTON id="iBtnAppCancel" runat="server" imagealign="absBottom" imageurl="../images/btn/b_067.gif" onclick="iBtnAppCancel_Click"  />
			                        </td>
		                        </tr>
		                        <tr>
		                            <td class="tableTitle" width="25%" align="left">결제 진행현황</td>
		                        </tr>
		                        <tr>
		                            <td>
		                                <div id="divHeader">
                                        </div>
                                        <div id="FixHeader" class="FixHeaderCol" 
                                             style="border:1px solid #D6D6D6;
                                                    WIDTH: 100%;
                                                    height:expression(eval(document.body.clientHeight)-eval(document.all.tdUltra.offsetHeight)-212);
                                                   "
                                        >
		                                    <ASP:GRIDVIEW id="GridView1" runat="server" autogeneratecolumns="False" visible="true" onrowdatabound="GridView1_RowDataBound">
                                                <ALTERNATINGROWSTYLE cssclass="TableListA" />
                                                <ROWSTYLE cssclass="TableListB" />
                                                <HEADERSTYLE BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" font-bold="true" BorderColor="#E5E5E5" ForeColor="white">
                                                    
                                                </HeaderStyle>
        
                                                <COLUMNS>
                                                    <ASP:BOUNDFIELD readonly="True" datafield="V_APP_STEP" headertext="순번">
                                                        <ITEMSTYLE horizontalalign="center" verticalalign="Middle" width="40px" />
                                                    </ASP:BOUNDFIELD>
                                                    <ASP:BOUNDFIELD datafield="V_EMP_NAME" headertext="성명" readonly="True">
                                                        <ITEMSTYLE horizontalalign="center" verticalalign="Middle" width="80px" />
                                                    </ASP:BOUNDFIELD>
                                                    <ASP:BOUNDFIELD datafield="V_POSITION_DUTY_NAME" headertext="직책" readonly="True">
                                                        <ITEMSTYLE horizontalalign="center" verticalalign="Middle" width="120px" />
                                                    </ASP:BOUNDFIELD>
                                                    <ASP:BOUNDFIELD datafield="V_DEPT_NAME" headertext="부서명" readonly="True">
                                                        <ITEMSTYLE horizontalalign="center" verticalalign="Middle" width="100px" />
                                                    </ASP:BOUNDFIELD>
                                                    <ASP:BOUNDFIELD datafield="V_APP_STATUS" headertext="상태" readonly="True">
                                                        <ITEMSTYLE horizontalalign="center" verticalalign="Middle" width="80px" />
                                                    </ASP:BOUNDFIELD>
                                                    <ASP:BOUNDFIELD datafield="V_APP_DATE" headertext="결재일시" readonly="True">
                                                        <ITEMSTYLE horizontalalign="center" verticalalign="Middle" width="135px" />
                                                    </ASP:BOUNDFIELD>
                                                    <ASP:BOUNDFIELD datafield="V_APP_REMARK" headertext="취소사유" readonly="True">
                                                        <ITEMSTYLE horizontalalign="center" verticalalign="Middle" width="200px" />
                                                    </ASP:BOUNDFIELD>
                
                                                </COLUMNS>
                                            </ASP:GRIDVIEW>
		                                </div>
		                            </td>
		                        </tr>
		                    </table>
                            
		                    
                            <!--- MAIN END --->
                        </td>
                    </tr>
                </table>    
            </div>
        </form>
    </body>
</html>
