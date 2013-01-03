<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0101S1.aspx.cs" Inherits="PRJ_PRJ0101S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script id="Infragistics" type="text/javascript">
    
    var timer;
        function DateOfCheck_ValueChanged(oDropDown, newValue, oEvent)
        {
//            
//            if(newValue==null && !oDropDown.Dropped)
//            {
//                alert("종료일자를 선택해주세요");
//                return;
//            }
//            
//            alert(wdcPlanStartDate.getValue());
            
//            if (newValue!=null)
////            if(window.confirm("Were you really born on "+newValue+"?"))
//                var newDate=oDropDown.getValue();
//                if(newDate.getFullYear()<1960||newDate.getFullYear()>1980)
//                    alert("I don't believe you.");
        }

    function ugrdPrjList_DblClickHandler(gridName, cellId)
    {
        var cell            = igtbl_getElementById(cellId);
        var row             = igtbl_getRowById(cellId);
        var prjID           = row.getCellFromKey("PRJ_REF_ID").getValue();
        var viewYN          = row.getCellFromKey("ISDELETE").getValue() =='Y'? 'D':'U';
        var ICCB1           = "<%= this.ICCB1 %>";
        
        var url             = 'PRJ0101M1.aspx?iType=' + viewYN + '&PRJ_REF_ID=' + prjID+'&CCB1='+ICCB1 ;
        gfOpenWindow(url, 900, 680, 'yes', 'no', 'PRJ0101M1');
    }
    
    function openInstWindow()
    {
        var ICCB1           = "<%= this.ICCB1 %>";
        var url             = 'PRJ0101M1.aspx?iType=A&PRJ_REF_ID=0&CCB1=' + ICCB1;
        
        
        gfOpenWindow(url, 900, 680, 'yes', 'no', 'PRJ0101M1');
        return false;
    }
    
</script>

		<table cellpadding="2" cellspacing="0" border="0"  style="width:100%; height:100%;" >
		    <tr valign="top" style="height: 60px">
                <td colspan="2" style="height: 60px">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tbody>
                        <tr>
                          <td class="tableBorder">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                              <tbody>
                                <tr>
                                  <td class="cssTblTitle">사업유형&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:dropdownlist id="ddlPrjType" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                  </td>
                                  <td class="cssTblTitle">사업 CODE&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:TextBox id="txtPrjCode" runat="server" width="100%"></asp:TextBox>
                                  </td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle">사업명&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:TextBox id="txtPrjName" runat="server" width="100%"></asp:TextBox>
                                  </td>
                                  <td class="cssTblTitle">책임자명&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:TextBox id="txtOwnerEmpName" class="box01" runat="server" width="100%"></asp:TextBox>
                                  </td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle">계획기간&nbsp;</td>
                                  <td class="cssTblContent">
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                       <tr>
                                         <td style="width:45%;">
                                            <ig:WebDateChooser ID="wdcPlanStartDate" Width="100%" runat="server" NullDateLabel="" Format="Short" AllowNull="false">
                                                <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                            </ig:WebDateChooser> 
                                         </td>
                                         <td style="width:10%;" align="center">~</td>
                                         <td align="left" style="width:45%;">
                                            <ig:WebDateChooser ID="wdcPlanEndDate" Width="100%" runat="server" NullDateLabel="" AllowNull="false">
                                            <ClientSideEvents ValueChanged="DateOfCheck_ValueChanged"></ClientSideEvents>
                                                <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                            </ig:WebDateChooser>
                                         </td>
                                       </tr>
                                     </table>
                                  </td>
                                  <td class="cssTblTitle">주관부서&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:dropdownlist id="ddlOwnerDeptID" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                </td>
            <td align="right" visible="false" style="height: 60px">
            </td>
        </tr>
        <tr style="height:25px;">
            <td>
                <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                <img align="absmiddle" src="../Images/etc/lis_t02.gif" /></td>
            </td>
            <td align="right">
              <asp:ImageButton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2" >
                <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdPrjList_InitializeRow" OnInitializeLayout="ugrdPrjList_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="PRJ_CODE" HeaderText="코드" Key="PRJ_CODE" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="코드">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OWNER_DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="주관부서" Key="OWNER_DEPT_NAME" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="주관부서">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="사업명" Key="PRJ_NAME" Width="155px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="사업명">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OWNER_EMP_NAME" HeaderText="책임자" Key="OWNER_EMP_NAME"
                                    Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="책임자">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_TYPE_NAME" HeaderText="사업유형" Key="PRJ_TYPE_NAME"
                                    Width="90px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="사업유형">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PLAN_START_DATE" DataType="System.DateTime"
                                    EditorControlID="" FooterText="" HeaderText="시작일자" Key="PLAN_START_DATE" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="시작일자">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PLAN_END_DATE" DataType="System.DateTime"
                                    EditorControlID="" FooterText="" HeaderText="종료일자" Key="PLAN_END_DATE" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="종료일자">
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ACTUAL_START_DATE" DataType="System.DateTime"
                                    EditorControlID="" FooterText="" HeaderText="시작일자" Key="ACTUAL_START_DATE" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="시작일자">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ACTUAL_END_DATE" DataType="System.DateTime"
                                    EditorControlID="" FooterText="" HeaderText="종료일자" Key="ACTUAL_END_DATE" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="종료일자">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="ISDELETE" EditorControlID="" FooterText=""
                                    HeaderText="사용여부" Key="ISDELETE" Width="60px">
                                    <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                    </CellTemplate>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="사용여부">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" EditorControlID="" FooterText=""
                                    HeaderText="결재상태" Key="APP_STATUS" Width="60px">
                                    <CellTemplate>
                                    <asp:image runat="server" id="imgApp" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                    </CellTemplate>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="결재상태">
                                        <RowLayoutColumnInfo OriginX="21" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="21" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="APP_REF_ID" Hidden="True" Key="APP_REF_ID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="22" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="22" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID"
                                    Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="PRJ_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_TYPE" HeaderText="사업유형" Hidden="True"
                                    Key="PRJ_TYPE">
                                    <Header Caption="사업유형">
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRIORITY" HeaderText="중요도" Hidden="True" Key="PRIORITY">
                                    <Header Caption="중요도">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TOTAL_BUDGET" HeaderText="총사업비" Hidden="True"
                                    Key="TOTAL_BUDGET">
                                    <Header Caption="총사업비">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="INTERESTED_PARTIES" HeaderText="이해관계자" Hidden="True"
                                    Key="INTERESTED_PARTIES">
                                    <Header Caption="이해관계자">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEFINITION" HeaderText="사업정의" Hidden="True"
                                    Key="DEFINITION">
                                    <Header Caption="사업정의">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="REF_STG" HeaderText="전략목표" Hidden="True" Key="REF_STG">
                                    <Header Caption="전략목표">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EFFECTIVENESS" HeaderText="기대효과" Hidden="True"
                                    Key="EFFECTIVENESS">
                                    <Header Caption="기대효과">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RANGE" HeaderText="사업범위" Hidden="True" Key="RANGE">
                                    <Header Caption="사업범위">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="REQUEST_DEPT" HeaderText="요청부서기관" Hidden="True"
                                    Key="REQUEST_DEPT">
                                    <Header Caption="요청부서기관">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                     <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="No"
                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="NotSet" Name="ugrdPrjList" RowHeightDefault="20px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="None" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
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
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                        <ClientSideEvents DblClickHandler="ugrdPrjList_DblClickHandler" />
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
                <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server">
                </ig:UltraWebGridExcelExporter>
		    </td>
		</tr>
		<tr>
			<td colspan="2" align="right" style="height: 23px">
                    <asp:ImageButton runat="server" ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif" ImageAlign="AbsMiddle" OnClientClick="return openInstWindow();" />
                <asp:ImageButton ID="ibnDownExcel" runat="server" CommandName="BIZ_DOWN_EXCEL" ImageAlign="AbsMiddle"
                    ImageUrl="~/images/btn/b_041.gif" OnClick="ibnDownExcel_Click" />&nbsp;
			</td>
		</tr>
	  </table>
	<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>