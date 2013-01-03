<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1001S1.aspx.cs" Inherits="BSC_BSC1001S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
   
    <script id="Infragistics" type="text/javascript">

    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    {
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);
           var termName         = row.getCellFromKey("KPI_NAME").getValue();
           cell.style.cursor    = 'hand';
        }

    }
    
    function ugrdKpiList_DblClickHandler(gridName, cellId)
    {
        var cell            = igtbl_getElementById(cellId);
        var row             = igtbl_getRowById(cellId);
        var kpiID           = row.getCellFromKey("KPI_REF_ID").getValue();
        var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var ICCB1           = "<%= this.ICCB1 %>";
        
        var url             = 'BSC0302M1.aspx?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID+'&CCB1='+ICCB1;
        gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
    }
    
    function openInstWindow()
    {
        var estterm_ref_id = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
        var ICCB1           = "<%= this.ICCB1 %>";
        
        var url             = "BSC0302M1.aspx?iType=A&IS_TEAM_KPI=N&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=0&CCB1="+ICCB1;
        
        gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
        return false;
    }

    var param1 = false;
    function selectChkBox(chkChild)
    {
        var _elements   = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
            {
                if (param1)
                {
                    _elements[i].checked = false;
                }
                else
                {
                    _elements[i].checked = true;
                }
            }
        }
        
        param1 = (param1==true) ? false : true;
    }
</script>

<!--- MAIN START --->	
        <asp:literal id="LitTest" runat="server"></asp:literal>
		<table cellpadding="2" cellspacing="0" border="0"  style="width:100%; height:100%;" >
		    <tr valign="top" style="height: 60px">
                <td colspan="2" style="height: 60px">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tbody>
                        <tr>
                          <td class="tableoutBorder">
                            <table cellspacing="0" cellpadding="2" width="100%" border="0">
                              <tbody>
                                <tr>
                                  <td class="tableTitle" width="80" align="center">평가기간&nbsp;</td>
                                  <td class="tableContent" width="120">
                                     <asp:dropdownlist id="ddlEstTermInfo" class="box01" runat="server" width="100%" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist></td>
                                  <td class="tableTitle" width="80" align="center"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                                  <td class="tableContent" width="120"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>
                                  <td class="tableTitle" width="80" align="center">KPI 명</td>
                                  <td class="tableContent" width="100"><asp:TextBox id="txtKPIName" runat="server" width="100%"></asp:TextBox> </td>
                                  <td class="tableTitle" style="width:80px;" align="center"><%=this.GetText("LBL_00001", "챔피언") %></td>
                                  <td class="tableContent"><asp:TextBox id="txtChamName" class="box01" runat="server" width="100%"></asp:TextBox> </td>
                                </tr>
                                <tr>
                                  <td class="tableTitle" align="center">지표유형</td>
                                  <td class="tableContent"><asp:dropdownlist id="ddlKpiGroupRefID" class="box01" runat="server" width="99%"></asp:dropdownlist></td>
                                  <td class="tableTitle" align="center">운영조직</td>
                                  <td class="tableContent" colspan="3">
                                    <asp:dropdownlist id="ddlEstDept" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                    <asp:dropdownlist id="ddlResultInput" class="box01" runat="server" width="99%" visible="false"></asp:dropdownlist>
                                  </td>
                                  <td class="tableContent" align="right" colspan="2">
                                    <asp:ImageButton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;
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
                <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiList_InitializeRow" OnInitializeLayout="ugrdKpiList_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" />
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="ESTTERM_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="KPI 코드">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="160px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영조직">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI담당자">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="단위">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID=""
                                    FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="실적방식">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부">
                                  <Header Caption="사용여부">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Header>
                                  <HeaderStyle Wrap="True" />
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                  <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Footer>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID="" Width="35px" FooterText="" HeaderText="APP_STATUS">
                                  <Header Caption="결재상태">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Header>
                                  <HeaderStyle Wrap="True" />
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgApp" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                  <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="dept_ref_id" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="관리부서ID" Hidden="True" Key="dept_ref_id">
                                    <Header Caption="관리부서ID">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS" HeaderText="APPROVAL_STATUS" Hidden="True"
                                    Key="APPROVAL_STATUS">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="승인여부">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="emp_email" HeaderText="E-Mail" Hidden="True"
                                    Key="emp_email" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="E-Mail">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계" Key="RESULT_MEASUREMENT_STEP_NAME"
                                    Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="측정단계">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_EST_DEPT_ID" DataType="System.Int16" HeaderText="상위부서"
                                    Hidden="True" Key="UP_EST_DEPT_ID" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="상위부서">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                     <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="SortMulti" Name="ugrdKpiList" RowHeightDefault="20px" HeaderStyleDefault-Height="35px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="OutlookGroupBy" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                            <GroupByBox>
                                <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
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
                            <ClientSideEvents DblClickHandler="ugrdKpiList_DblClickHandler" />
                        </DisplayLayout>
                </ig:UltraWebGrid>
		    </td>
		</tr>
		<tr>
            <td align="left" style="height: 40px; width:60%;">
              <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                <tr>
                  <td style="width:100px;">
                    <asp:ImageButton runat="server" ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif" ImageAlign="AbsMiddle" OnClientClick="return openInstWindow();" />
                  </td>
                  <td align="right">
                      <asp:Label runat="server" ID="lblCopyText" Text="평가중인 평가대상기간:"></asp:Label>
                      <asp:DropDownList runat="server" ID="ddlEsttermCopy" CssClass="box01" ></asp:DropDownList>
                      <asp:ImageButton runat="server" ID="iBtnKpiCopy" ImageUrl="../images/btn/b_054.gif" ImageAlign="AbsMiddle" OnClick="iBtnKpiCopy_Click" />
                  </td>
                </tr>
              </table>
            </td>
			<td align="right">
                <asp:label id="lblCountRow" runat="server" text="Label"></asp:label>&nbsp;
			</td>
		</tr>
	  </table>
	<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>
