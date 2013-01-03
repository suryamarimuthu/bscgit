<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0805M1.aspx.cs" Inherits="BSC_BSC0805M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
    <script id="Infragistics" type="text/javascript">

    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);
           cell.style.cursor    = 'hand';
        }
    }
    
    function ugrdExtScore_DblClickHandler(gridName, cellId)
    {
        var cell            = igtbl_getElementById(cellId);
        var row             = igtbl_getRowById(cellId);
        var kpiID           = row.getCellFromKey("KPI_REF_ID").getValue();
        var kpiName         = row.getCellFromKey("KPI_NAME").getValue();
        var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();

        var url             = "BSC0302M1.aspx?iType=S&KPI_REF_ID=" + kpiID + "&ESTTERM_REF_ID=" + estterm_ref_id
        
        gfOpenWindow(url,900, 645,'yes','no');
    }
    
    </script>

<!--- MAIN START --->	
		<table cellpadding="2" cellspacing="0" border="0" style="width:100%; height:100%;">
		    <tr valign="top" style="height: 60px">
                <td colspan="2" style="height: 60px">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tbody>
                        <tr>
                          <td class="tableoutBorder">
                            <table cellspacing="0" cellpadding="2" width="100%;" border="0">
                              <tbody>
                                <tr>
                                  <td class="tableTitle" style="width:60px;" align="center">평가기간</td>
                                  <td class="tableContent" style="width:200px;">
                                     <asp:dropdownlist id="ddlEstTermInfo" CssClass="box01" runat="server" width="60%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                                     <asp:dropdownlist id="ddlEstTermMonth" CssClass="box01" runat="server" width="35%" ></asp:dropdownlist>
                                  </td>
                                  <td class="tableTitle" style="width:60px;" align="center"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                                  <td class="tableContent" style="width:100px;"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>
                                  <td class="tableTitle"   style="width:60px;" align="center">KPI 명</td>
                                  <td class="tableContent" style="width:100px;"><asp:TextBox id="txtKPIName" runat="server" width="100%"></asp:TextBox></td>
                                  <td class="tableContent" rowspan="2" align="center">
                                    <asp:CheckBox ID="chkApplyFirstRow" runat="server" Text="첫번째행의 가중치 일괄적용" AutoPostBack="True" OnCheckedChanged="chkApplyFirstRow_CheckedChanged" /><br />
                                    <asp:Label ID="lblNotice" Text="※ 외부지표만 점수입력이 가능합니다." ForeColor="blue" runat="server"></asp:Label>
                                  </td>
                                </tr>
                                <tr>
                                  <td class="tableTitle" align="center">관리부서
                                  </td>
                                  <td class="tableContent"><asp:dropdownlist id="ddlComDept" CssClass="box01" runat="server" width="100%"></asp:dropdownlist></td>
                                  <td class="tableTitle" align="center">지표유형&nbsp;</td>
                                  <td class="tableContent" colspan="3">
                                      <asp:dropdownlist id="ddlKpiGroupRefID" runat="server" CssClass="box01" width="100%"></asp:dropdownlist>
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
        <tr>
            <td valign="top" colspan="2" >
		        <ig:UltraWebGrid ID="ugrdExtScore" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdExtScore_InitializeRow" OnInitializeLayout="ugrdExtScore_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="관리부서명" Key="COM_DEPT_NAME" Width="90px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="관리부서명">
                                    </Header>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="KPI 코드">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME"
                                    Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="KPI담당자">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표유형" Key="KPI_GROUP_NAME"
                                    Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="지표유형">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT_INR" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="내부" Key="WEIGHT_INR" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="내부">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT_EXT" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="외부" Key="WEIGHT_EXT" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="외부">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET_INR" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="목표" Key="TARGET_INR" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="목표">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_INR" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="실적" Key="RESULT_INR" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="실적">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET_EXT" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="목표" Key="TARGET_EXT" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="목표">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_EXT" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="실적" Key="RESULT_EXT" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="실적">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINTS_INR_ORI" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="내부" Key="POINTS_INR_ORI" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="내부">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINTS_EXT_ORI" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="외부" Key="POINTS_EXT_ORI" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="외부">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="GRADE_EXT" HeaderText="GRADE_EXT" Key="GRADE_EXT" Width="35px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="등급">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINTS_INR_FNL" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="내부" Key="POINTS_INR_FNL" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="내부">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINTS_EXT_FNL" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="#,##0.00" HeaderText="외부" Key="POINTS_EXT_FNL" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Header Caption="외부">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" EditorControlID="" FooterText=""
                                    HeaderText="결재상태" Key="APP_STATUS" Width="35px" Hidden="True">
                                    <CellTemplate>
                                      <asp:image runat="server" id="imgApp" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                    </CellTemplate>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="결재상태">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="ESTTERM_REF_ID">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="COM_DEPT_REF_ID" Hidden="True" Key="COM_DEPT_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="COM_DEPT_REF_ID">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="KPI_REF_ID">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" DataType="System.String" EditorControlID=""
                                    FooterText="" Format="" HeaderText="YMD" Hidden="True" Key="YMD">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="YMD">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                     </Bands>
                     <DisplayLayout CellPaddingDefault="1" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="No"
                       AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                       HeaderClickActionDefault="SortMulti" Name="ugrdExtScore" RowHeightDefault="20px"
                       RowSelectorsDefault="No" SelectTypeRowDefault="Single" Version="4.00" ViewType="Flat" CellClickActionDefault="Edit" 
                       tableLayout="Fixed" StationaryMargins="No" AutoGenerateColumns="False">
                            <GroupByBox>
                                <Style BackColor="WhiteSmoke" BorderColor="Window"></Style>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                            <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                         <ActivationObject BorderColor="" BorderWidth="">
                         </ActivationObject>
                        </DisplayLayout>
                </ig:UltraWebGrid>
		    </td>
		</tr>
		<tr>
			<td align="right" style="height: 30px">
			   <table border="0" cellpadding="0" cellspacing="0" width="100%">
			     <tr>
			       <td align="left">
			           <asp:label id="lblCountRow" runat="server" text=""></asp:label>
			       </td>
			       <td align="right">
                        외부평가관련 첨부파일:<asp:FileUpload ID="fluExtEst" runat="server" Width="300px" />
                        <asp:imagebutton id="iBtnSave" runat="server" imageurl="../images/btn/b_007.gif" OnClick="iBtnSave_Click" ImageAlign="AbsMiddle" Visible="true"></asp:imagebutton>
                        <asp:imagebutton id="iBtnPrint" runat="server" imageurl="../images/btn/b_080.gif" Visible="false"  onclick="iBtnPrint_Click" ImageAlign="AbsMiddle"></asp:imagebutton>
                        <asp:ImageButton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" Height="19px" ImageAlign="AbsMiddle"></asp:ImageButton>
			       </td>
			     </tr>
			   </table>
			</td>
		</tr>
      </table>
        
	<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
  <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
</asp:Content>