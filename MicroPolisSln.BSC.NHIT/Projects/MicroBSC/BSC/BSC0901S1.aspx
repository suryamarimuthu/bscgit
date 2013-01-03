<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0901S1.aspx.cs" Inherits="BSC_BSC0901S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
   <script id="Infragistics" type="text/javascript">
       var param1 = false;

       function selectChkBox(chkChild) {
           var _elements = document.forms[0].elements;

           for (var i = 0; i < _elements.length; i++) {
               if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type == "checkbox") {
                   if (param1) {
                       _elements[i].checked = false;
                   }
                   else {
                        if (!_elements[i].disabled)
                            _elements[i].checked = true;
                   }
               }
           }

           param1 = (param1 == true) ? false : true;
       }
   /*=========================================================================
     호출 파라미터 승인 처리 - 승인처리의 경우 문서번호만 넘겨줌
     app_ref_id     : 결재문서가 최초버젼일 아닐경우
     version_no     : 결재버전번호
     line_step      : 결재단계번호
     app_ccb        : 결재처리후 호출화면에서 처리시 컨트롤 client id 넘겨줌
   //========================================================================*/
    function ugrdAppList_DblClickHandler(gridName, cellId)
    {
        var cell        = igtbl_getElementById(cellId);
        var row         = igtbl_getRowById(cellId);
        var appID       = row.getCellFromKey("APP_REF_ID").getValue();
        var verNO       = row.getCellFromKey("VERSION_NO").getValue();
        var linST       = row.getCellFromKey("LINE_STEP").getValue();
        var biz_type    = row.getCellFromKey("BIZ_TYPE").getValue();
        var draftStatus = "<%= Biz_Type.app_draft_approval %>";
        var app_ccb     = "<%= this.IAPP_CCB %>";
        
        var draft_emp_id    = parseInt("<%= this.IDraftEmpID %>",10);
       
        if (draft_emp_id=="NaN" || draft_emp_id  < 1)
        {
            alert("기안자 정보를 알수 없습니다.");
            return false;
        }
        
        var strURL = "BSC0901M1.aspx?DRAFT_STATUS="+draftStatus+"&APP_REF_ID="+ appID+"&VERSION_NO="+verNO+"&LINE_STEP="+linST+"&APP_CCB="+app_ccb+"&DRAFT_EMP_ID="+draft_emp_id+"&BIZ_TYPE="+biz_type;
        
        gfOpenWindow(strURL, 900, 650,"BSC0901M1");
    }
    
    function OpenAppWin(appID, verNO)
    {
        var app_ccb = "<%= this.IAPP_CCB %>";
        
        var strURL = 'BSC0901M1.aspx?iType=U&APP_REF_ID='+ appID+'&VERSION_NO='+verNO+'&APP_CCB='+app_ccb;
        gfOpenWindow(strURL, 900, 650,"BSC0901M1");
        
        return false;
    }
    
    function ugrdOpinionList_CellClickHandler(gridName, cellId, button)
    {
	    var cell    = igtbl_getCellById(cellId);
	    var row     = igtbl_getRowById(cellId);
	    var objOpin = window.document.getElementById("<%=txtDetailOpinion.ClientID.Replace('_','$') %>");

        if (cell.Column.Key == "COMMENTS" || cell.Column.Key == "RETURN_REASON")
        {
	        objOpin.value = cell.getValue();
	    }
	    else
	    {
	        return;
	    }
    	
	    ShowAppline();
    }

    function ShowAppline()
    {
        var objLine = window.document.getElementById("<%=divAreaAppLine.ClientID.Replace('$','_') %>");

        if (objLine != null)
        {
            if (objLine.style.display == "block")
            {
                objLine.style.display    = "none";
            }
            else
            {
                objLine.style.display    = "block";
            }
        }
        
        return false;
    }

    function onDraft() {

        var avl = "";
        var ugrd = igtbl_getGridById('<%= ugrdAppList.ClientID %>');
        for (var i = 0; i < ugrd.Rows.length; i++) {
            var tRow = ugrd.Rows.getRow(i);
            var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
            if (chkYN.checked) {
                avl += tRow.getCellFromKey("APP_REF_ID").getValue() + ";" + tRow.getCellFromKey("VERSION_NO").getValue() + ";" + tRow.getCellFromKey("LINE_STEP").getValue() + ",";
            }
        }
        if (avl == "") {
            alert('일괄승인할 결재문서를 선택하세요!');
            return false;
        }

        avl = avl.substring(0, avl.length - 1);
        var app_ccb = "<%= this.IAPP_CCB %>";
        var url = "BSC0501M5.aspx?AVL=" + avl + "&CCB1=" + app_ccb;
        gfOpenWindow(url, 1010, 650, 'BSC0501M5'); // 728

        return false;
    }
    </script>   
<!--- MAIN START --->	
		<table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
		    <tr valign="top">
			    <td colspan="2">
	                <table border="0" cellpadding="0" cellspacing="0" width="100%">
	                    <tr>
	                        <td>
                                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
	                                <tr>
<%--                                        <td style="width:80px;" class="tableTitle">결재상태</td>
                                        <td style="width:120px;" class="tableContent">
                                            <asp:DropDownList ID="ddlApprovalStatus" runat="server" />
                                        </td>--%>
                                        <td class="cssTblTitle">업무구분</td>
                                        <td class="cssTblContent">
                                            <asp:dropdownlist runat="server" id="ddlBizType" width="100%" CssClass="box01"></asp:dropdownlist>
                                        </td>	
                                        <td class="cssTblTitle">상신부서</td>
                                        <td class="cssTblContent">
                                            <asp:dropdownlist id="ddlComDept" CssClass="box01" runat="server" width="100%"></asp:dropdownlist>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle">상신일자</td>
                                        <td class="cssTblContent" style="border-right:none;">
                                             <table width="99%" border="0" cellpadding="0" cellspacing="0">
                                               <tr>
                                                 <td style="width:45%;">
                                                    <ig:WebDateChooser ID="wdcSDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false" Width="100%">
                                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                    </ig:WebDateChooser> 
                                                 </td>
                                                 <td style="width:10%; text-align:center;">&nbsp;~&nbsp;</td>
                                                 <td style="width:45%;" align="left">
                                                    <ig:WebDateChooser ID="wdcEDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false" Width="100%">
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
                </table>
            </td>
            <td align="right" visible="false"></td>
        </tr>
        <tr>
          <td style="height:25px; vertical-align: bottom;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
              <tr>
                <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                <td style="width:150px;" align="left">결재대상 문서함</td>
                <td align="left">
                    <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                    <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                    <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                </td>
                <td align="right">
                    <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr style="height:60%;">
            <td valign="top" colspan="2">
		        <ig:UltraWebGrid ID="ugrdAppList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdAppList_InitializeRow" OnActiveRowChange="ugrdAppList_ActiveRowChange" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed">
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdAppList')" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" />
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="APP_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="APP_REF_ID" Key="APP_REF_ID" Width="100px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="APP_REF_ID">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="VERSION_NO" EditorControlID="" FooterText=""
                                    Format="" HeaderText="VERSION_NO" Key="VERSION_NO" Width="100px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="VERSION_NO">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="LINE_STEP" EditorControlID="" FooterText=""
                                    Format="" HeaderText="LINE_STEP" Key="LINE_STEP" Width="100px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="LINE_STEP">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="BIZ_TYPE_NAME" Key="BIZ_TYPE_NAME" Width="80px">
                                    <Header Caption="업무구분">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="APP_CODE" Key="APP_CODE" Width="80px">
                                    <Header Caption="문서번호">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="320px">
                                    <Header Caption="문서제목">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="APP_STATUS_NAME" Key="APP_STATUS_NAME" Width="80px">
                                    <Header Caption="결재상태">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DRAFT_EMP_NAME" Key="DRAFT_EMP_NAME" Width="80px">
                                    <Header Caption="상신자">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DRAFT_DEPT_NAME" Key="DRAFT_DEPT_NAME" Width="90px">
                                    <Header Caption="상신자 부서">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DRAFT_DATE" Key="DRAFT_DATE" Width="80px">
                                    <Header Caption="상신일자">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="BIZ_TYPE" Key="BIZ_TYPE" Width="80px" Hidden="true">
                                    <Header Caption="BIZ_TYPE">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                     <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="SortMulti" Name="ugrdAppList" RowHeightDefault="20px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
                            OptimizeCSSClassNamesOutput="False">
                        <%--
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="25px">
                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                            Width="100%">
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
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>--%>
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                        <ClientSideEvents DblClickHandler="ugrdAppList_DblClickHandler" />
                    </DisplayLayout>
                </ig:UltraWebGrid>
		    </td>
		</tr>
		<tr>
		    
        </tr>
		<tr style="height:25px;">
		    <td>
		        <table width="100%">
		            <tr>
		                <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
		                <td style="height:25px;">결재상세</td>
		                <td style="height:18px;" align="right">
                            <asp:ImageButton runat="server" ID="ibtnDraftBatch" ImageUrl="../images/btn/btn_draft_batch_app.gif" ImageAlign="AbsMiddle" OnClientClick="return onDraft();" Visible="true" />
                        </td>
		            </tr>
		        </table>
		    </td>
        </tr>
		<tr style="height:100%">
		  <td>
		        <ig:UltraWebGrid ID="ugrdAppPrc" runat="server" Width="100%" Height="100%" Visible="true">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="APP_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="APP_REF_ID" Key="APP_REF_ID" Width="100px" Hidden="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="APP_REF_ID">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="VERSION_NO" EditorControlID="" FooterText=""
                                    Format="" HeaderText="VERSION_NO" Key="VERSION_NO" Width="100px" Hidden="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="VERSION_NO">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="LINE_STEP" Key="LINE_STEP" Width="60px" FooterText="" HeaderText="결재단계">
                                    <Header Caption="결재단계">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="120px" FooterText="" HeaderText="부서">
                                    <Header Caption="부서">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="80px" FooterText="" HeaderText="결재자">
                                    <Header Caption="결재자">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="COMMENTS" Key="COMMENTS" Width="390px" FooterText="" HeaderText="상신/결재의견">
                                    <Header Caption="상신/결재의견">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="LINE_TYPE_NAME" Key="LINE_TYPE_NAME" Width="60px" FooterText="" HeaderText="결재유형">
                                    <Header Caption="결재유형">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" Key="COMPLETE_YN" Width="60px" FooterText="" HeaderText="처리여부">
                                    <Header Caption="처리여부">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="100px" FooterText="" HeaderText="처리일자">
                                    <Header Caption="처리일자">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                     <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="SortMulti" Name="ugrdAppPrc" RowHeightDefault="20px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
                            OptimizeCSSClassNamesOutput="False">
                            <%--
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="37px">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                <Margin Bottom="0px" Top="0px" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                Width="100%">
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
                            <SelectedRowStyleDefault BackColor="#E2ECF4">
                            </SelectedRowStyleDefault>
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>--%>
                            <GroupByBox>
                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                            <RowStyleDefault  CssClass="GridRowStyle" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                         <ClientSideEvents CellClickHandler="ugrdOpinionList_CellClickHandler" />
                    </DisplayLayout>
                </ig:UltraWebGrid>
		  </td>
		</tr>
		</table>

        <div id="divAreaAppLine" runat="server" 
             style="position:absolute; height:300px; width:500px; margin:1px; border-width:1px; display:none; border-collapse:collapse; text-align:left; background-color:#ffffff;
                    top:200px; left:200px;">
          <table border="2" cellpadding="0" cellspacing="2" style="width:100%; height:100%; border-collapse:collapse;">
            <tr>
              <td style="height:25px; text-align:left;">
                  <img src="../images/arrow/arrow.gif" alt="" />&nbsp;<b>상세내용</b>
              </td>
            </tr>
            <tr>
              <td>
                  <asp:TextBox ID="txtDetailOpinion" runat="server" Width="100%" Height="100%" TextMode="multiline"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td style="height:25px; text-align:right;">
                  <img src="../images/btn/b_003.gif" alt="" onclick="ShowAppline();" style="cursor:hand;" />
              </td>
            </tr>
          </table>
        </div>
		
	 <asp:linkbutton id="linkBtnDraft" runat="server" OnClick="linkBtnDraft_Click"></asp:linkbutton>
	 <asp:Literal ID="ltrScript" runat="server"></asp:Literal>

  <!--- MAIN END --->
</asp:Content>
