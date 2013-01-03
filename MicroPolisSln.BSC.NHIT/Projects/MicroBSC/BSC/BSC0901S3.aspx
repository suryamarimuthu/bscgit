<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0901S3.aspx.cs" Inherits="BSC_BSC0901S3" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
<!--- MAIN START --->	
   <script id="Infragistics" type="text/javascript">
   /*=========================================================================
     호출 파라미터 승인 처리 - 승인처리의 경우 문서번호만 넘겨줌
     app_ref_id     : 결재문서가 최초버젼일 아닐경우
     version_no     : 결재버전번호
     line_step      : 결재단계번호
     app_ccb        : 결재처리후 호출화면에서 처리시 컨트롤 client id 넘겨줌
   //========================================================================*/
    function ugrdAppList_DblClickHandler(gridName, cellId)
    {
        var cell    = igtbl_getElementById(cellId);
        var row     = igtbl_getRowById(cellId);
        var appID   = row.getCellFromKey("APP_REF_ID").getValue();
        var verNO   = row.getCellFromKey("VERSION_NO").getValue();
        var linST   = row.getCellFromKey("LINE_STEP").getValue();
        var biz_type    = row.getCellFromKey("BIZ_TYPE").getValue();
        var draftStatus = "<%= Biz_Type.app_draft_select %>";
        var app_ccb     = "<%= this.IAPP_CCB %>";
        
        var strURL = "BSC0901M1.aspx?DRAFT_STATUS="+draftStatus+"&APP_REF_ID="+ appID+"&VERSION_NO="+verNO+"&LINE_STEP="+linST+"&APP_CCB="+app_ccb+"&BIZ_TYPE="+biz_type;
        
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
    </script>   

		<table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
		    <tr valign="top">
			    <td>
	                <table border="0" cellpadding="0" cellspacing="0" width="100%">
	                    <tr>
	                        <td>
                                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
	                                <tr>
                                        <td class="cssTblTitle">결재상태</td>
                                        <td class="cssTblContent">
                                            <asp:DropDownList ID="ddlApprovalStatus" runat="server" CssClass="box01" Width="100%"/>
                                        </td>
                                        <td class="cssTblTitle">업무구분</td>
                                        <td class="cssTblContent">
                                            <asp:dropdownlist runat="server" id="ddlBizType" CssClass="box01" Width="100%"></asp:dropdownlist>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle">문서제목</td>
                                        <td class="cssTblContent">
                                            <asp:TextBox ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
                                        </td>	
                                        <td class="cssTblTitle">결재일자</td>
                                        <td class="cssTblContent">
                                             <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                               <tr>
                                                 <td style="width:45%;">
                                                    <ig:WebDateChooser ID="wdcSDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false" Width="100%">
                                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                    </ig:WebDateChooser> 
                                                 </td>
                                                 <td style="width:10%;" align="center">~</td>
                                                 <td style="width:45%;" align="left">
                                                    <ig:WebDateChooser ID="wdcEDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false" Width="100%">
                                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                    </ig:WebDateChooser>
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
        <tr style="height:25px;">
            <td>
                <table>
                    <tr>
                        <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                        <td>결재대상 문서함</td>
                        <td align="right">
                            <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:60%;">
            <td valign="top">
		        <ig:UltraWebGrid ID="ugrdAppList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdAppList_InitializeRow" OnActiveRowChange="ugrdAppList_ActiveRowChange" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
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
                                <ig:UltraGridColumn BaseColumnName="BIZ_TYPE_NAME" Key="BIZ_TYPE_NAME" Width="100px">
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
                                <ig:UltraGridColumn BaseColumnName="APP_CODE" Key="APP_CODE" Width="100px">
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
                                <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="420px">
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
                                <ig:UltraGridColumn BaseColumnName="APP_STATUS_NAME" Key="APP_STATUS_NAME" Width="100px">
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
                                <ig:UltraGridColumn BaseColumnName="TXR_DATE" Key="TXR_DATE" Width="100px">
                                    <Header Caption="작성일자">
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
        <tr style="height:25px;">
            <td>
                <table width="100%">
                    <tr>
                        <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                        <td>결재상세</td>                        
                    </tr>
                </table>
            </td>
        </tr>
		<tr style="height:100%;">
		  <td>
		        <ig:UltraWebGrid ID="ugrdAppPrc" runat="server" Width="100%" Height="100%">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
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
                                <ig:UltraGridColumn BaseColumnName="LINE_STEP" Key="LINE_STEP" Width="60px">
                                    <Header Caption="결재단계">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="120px">
                                    <Header Caption="부서">
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
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="50px">
                                    <Header Caption="결재자">
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
                                <ig:UltraGridColumn BaseColumnName="COMMENTS" Key="COMMENTS" Width="180px">
                                    <Header Caption="결재의견">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" ForeColor="Blue" Wrap="true"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RETURN_REASON" Key="RETURN_REASON" Width="180px">
                                    <Header Caption="반려사유">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" ForeColor="red"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="LINE_TYPE_NAME" Key="LINE_TYPE_NAME" Width="60px">
                                    <Header Caption="결재유형">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" Key="COMPLETE_YN" Width="60px">
                                    <Header Caption="처리여부">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="100px">
                                    <Header Caption="처리일자">
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
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                     <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="No"
                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate" RowSizingDefault="Free"
                            HeaderClickActionDefault="SortMulti" Name="ugrdAppPrc" RowHeightDefault="20px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
                            OptimizeCSSClassNamesOutput="False">
                            
                            <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
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
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                            <ClientSideEvents CellClickHandler="ugrdOpinionList_CellClickHandler" />
                    </DisplayLayout>
                </ig:UltraWebGrid>
		  </td>
		</tr>
		<tr style="height:25px;">
			<td align="right">
                <asp:Label ID="lblCountRow" runat="server" Text="0" Visible="false"></asp:Label>&nbsp;
                <asp:linkbutton id="linkBtnDraft" runat="server" OnClick="linkBtnDraft_Click"></asp:linkbutton>
			</td>
		</tr>
		</table>
	    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
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
  <!--- MAIN END --->
</asp:Content>