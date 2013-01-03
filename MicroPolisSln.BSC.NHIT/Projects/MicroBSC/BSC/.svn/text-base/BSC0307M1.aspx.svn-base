<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0307M1.aspx.cs" Inherits="BSC_BSC0307M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">

  
    
    
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
                                  <td class="tableTitle" width="60" align="center">평가기간</td>
                                  <td class="tableContent" width="120">
                                     <asp:dropdownlist id="ddlEstTermInfo" class="box01" runat="server" width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist></td>
                                  <td class="tableTitle" width="60" align="center"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                                  <td class="tableContent" width="120"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>
                                  <td class="tableTitle" width="60" align="center">KPI 명</td>
                                  <td class="tableContent" width="100"><asp:TextBox id="txtKPIName" runat="server" width="100%"></asp:TextBox> </td>
                                  <td class="tableTitle" style="width:60px;" align="center"><%=this.GetText("LBL_00001", "챔피언") %></td>
                                  <td class="tableContent" colspan="2"><asp:TextBox id="txtChamName" class="box01" runat="server" width="100%"></asp:TextBox> </td>
                                </tr>
                                <tr>
                                  <td class="tableTitle" align="center">지표유형</td>
                                  <td class="tableContent"><asp:dropdownlist id="ddlKpiGroupRefID" class="box01" runat="server" width="99%"></asp:dropdownlist></td>
                                  <td class="tableTitle" align="center">운영조직</td>
                                  <td class="tableContent">
                                    <asp:dropdownlist id="ddlEstDept" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                    <asp:dropdownlist id="ddlResultInput" class="box01" runat="server" width="50px" visible="false"></asp:dropdownlist>
                                  </td>
                                 
                                       <td class="tableTitle" align="center">
                                           적용여부</td>
                                  <td class="tableContent"> <asp:dropdownlist id="ddlNormdistYN" class="box01" runat="server" width="98%">
                                  </asp:DropDownList></td>
                                   <td class="tableTitle" align="center">
                                       누적그룹</td>
                                  <td class="tableContent"> <asp:dropdownlist id="ddlsNormdistGroup" class="box01" runat="server" width="60%">
                                  </asp:DropDownList><asp:ImageButton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;
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
                <td valign="top" colspan="2" style="height: 98%"  > 
                    <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiList_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn BaseColumnName="selchk" Key="selchk" Width="30px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                       <asp:CheckBox ID="cBox" runat="server" /> 
                                    </CellTemplate>
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="ESTTERM_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI_REF_ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="코드" Key="KPI_CODE" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="코드">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="160px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영조직">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME"
                                    Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI담당자">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표유형" Key="KPI_GROUP_NAME"
                                    Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Hidden="True" Key="UNIT_NAME"
                                    Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="단위">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="NORMDIST_GROUP_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="누적확률그룹명" Key="NORMDIST_GROUP_NAME" Width="120px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="누적확률그룹명">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="NORMDIST_GROUP" EditorControlID="" FooterText=""
                                    Format="" HeaderText="누적확률그룹" Hidden="True" Key="NORMDIST_GROUP" Width="120px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="누적확률그룹">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                
                                <ig:TemplatedColumn BaseColumnName="NORMDIST_USE_YN" EditorControlID="" FooterText="" HeaderText="적용여부"
                                    Key="NORMDIST_USE_YN" Width="60px">
                                    <HeaderStyle Wrap="True" />
                                    <CellTemplate>
                                        <asp:Image ID="imgUseYn" runat="server" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif" />
                                    </CellTemplate>
                                    <Header Caption="적용여부">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:TemplatedColumn>
                            
                                <ig:UltraGridColumn BaseColumnName="dept_ref_id" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="관리부서ID" Hidden="True" Key="dept_ref_id">
                                    <Header Caption="관리부서ID">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="daily_phone" HeaderText="연락처" Hidden="True"
                                    Key="daily_phone">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="연락처">
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="emp_email" HeaderText="E-Mail" Hidden="True"
                                    Key="emp_email" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="E-Mail">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계"
                                    Hidden="True" Key="RESULT_MEASUREMENT_STEP_NAME" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="측정단계">
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_EST_DEPT_ID" DataType="System.Int16" HeaderText="상위부서"
                                    Hidden="True" Key="UP_EST_DEPT_ID" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="상위부서">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                            AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="NotSet" Name="ugrdKpiList" RowHeightDefault="20px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Single" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False" AllowUpdateDefault="Yes" SelectTypeCellDefault="Single" SelectTypeColDefault="Single">
                        <GroupByBox>
                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                Width="100%">
                        </FrameStyle>
                        </DisplayLayout>
                </ig:UltraWebGrid>
                           
                            </td>
		</tr>
		  <tr valign="top">
                   
                    <td valign ="top" align="right" style="width: 387px">
                     누적확률그룹 : 
                    <asp:DropDownList ID="ddlNormdistGroup" runat="server"></asp:DropDownList>
                    </td>
                     <td valign ="top" align="right">
                         <asp:Label ID="lblCountRow" runat="server" Text="Label"></asp:Label>
                         &nbsp; &nbsp;<asp:ImageButton ID="iBtnUseYN" runat="server" ImageUrl="../images/btn/b_139.gif"
                        OnClick="iBtnUseYN_Click" />&nbsp;
                         <asp:ImageButton ID="iBtnUpdate" runat="server" ImageUrl="../images/btn/b_007.gif"
                        OnClick="iBtnUpdate_Click" /></td>
              </tr>
		
	  </table>
 <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
    <asp:HiddenField ID="hdViewType" runat="server" />
  <!--- MAIN END --->
  
</asp:Content>
