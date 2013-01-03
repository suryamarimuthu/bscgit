<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0803S2.aspx.cs" Inherits="BSC_BSC0803S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript" language="javascript" >
    function ugrdSelectValidationList_DblClickHandler(gridName, cellId)
    {
        var cell            = igtbl_getElementById(cellId);
        var row             = igtbl_getRowById(cellId);
        var kpiID           = row.getCellFromKey("KPI_REF_ID").getValue();
        var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var group_ref_id    = row.getCellFromKey("GROUP_REF_ID").getValue();
        var emp_ref_id      = row.getCellFromKey("EMP_REF_ID").getValue();
        var url             = 'BSC0803M1.aspx?iType=U&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + "&GROUP_REF_ID="+group_ref_id + "&EMP_REF_ID="+emp_ref_id;
        gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
    }
    
    function ugrdOpinionList_CellClickHandler(gridName, cellId, button)
    {
	    var cell    = igtbl_getElementById(cellId);
	    var row     = igtbl_getRowById(cellId);
	    var objOpin = window.document.getElementById("<%=txtDetailOpinion.ClientID.Replace('_','$') %>");
    	
	    objOpin.value = row.getCellFromKey("OPINION").getValue();
    	
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

       <!--- MAIN START --->
        <table border="0" cellpadding="2" cellspacing="0" style="width:100%; height:100%;">
          <tr>
            <td style="height:50px;" class="tableContent" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                  <tr>
                    <td style="width:60px;" class="tableTitle" align="center">평가기간</td>
                    <td style="width:200px;" class="tableContent">
                      <asp:DropDownList ID="ddlEstTerm" runat="server" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged" CssClass="box01"></asp:DropDownList>
                      <asp:dropdownlist id="ddlEstTermMonth" runat="server" width="36%" CssClass="box01"></asp:dropdownlist>
                    </td>
                    <td style="width:60px;" class="tableTitle" align="center">평가그룹</td>
                    <td style="width:150px;" class="tableContent"><asp:DropDownList ID="ddlEstGroup" runat="server" Width="100%" AutoPostBack="True" CssClass="box01" OnSelectedIndexChanged="ddlEstGroup_SelectedIndexChanged1"></asp:DropDownList></td>
                    <td style="width:60px;" class="tableTitle" align="center">평가차수</td>
                    <td style="width:150px;" class="tableContent"><asp:DropDownList ID="ddlEstLevel" runat="server" Width="100%" AutoPostBack="True" CssClass="box01"></asp:DropDownList></td>
                    <td rowspan="2" align="center"><asp:ImageButton ID="iBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" /></td>
                  </tr>
                  <tr>
                    <td style="width:60px;" class="tableTitle" align="center">운영조직&nbsp;</td>
                    <td class="tableContent"><asp:dropdownlist id="ddlEstDept" runat="server" width="100%" CssClass="box01"></asp:dropdownlist></td>
                    <td style="width:60px;" class="tableTitle" align="center">지표유형</td>
                    <td class="tableContent"><asp:DropDownList id="ddlKpiGroup" runat="server" width="100%" CssClass="box01"></asp:DropDownList></td>
                    <td style="width:60px;" class="tableTitle" align="center">정성지표</td>
                    <td class="tableContent"><asp:DropDownList id="ddlBASIS_USE_YN" runat="server" width="100%" CssClass="box01" OnSelectedIndexChanged="ddlBASIS_USE_YN_SelectedIndexChanged"></asp:DropDownList> </td>
                  </tr>
                </table>
            </td>
          </tr>
          <tr>
            <td valign="top">
                <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnActiveRowChange="ugrdKpiList_ActiveRowChange" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px" Hidden="true">
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
                                <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="GROUP_REF_ID" Hidden="true" Key="GROUP_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="GROUP_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_LEVEL" EditorControlID="" FooterText=""
                                    Format="" HeaderText="EST_LEVEL" Key="EST_LEVEL" Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="EST_LEVEL">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header><Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
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
                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="EMP_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="50px">
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
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="270px">
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
                                <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="운영조직" Key="OP_DEPT_NAME">
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
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="80px">
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
                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부" Hidden="true">
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
                                <ig:TemplatedColumn BaseColumnName="APPROVAL_STATUS" Key="APPROVAL_STATUS" EditorControlID="" Width="35px" FooterText="" HeaderText="목표확정" Hidden="true">
                                  <Header Caption="확정여부">
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
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" EditorControlID=""
                                    FooterText="" Format="" HeaderText="지표유형" Key="KPI_GROUP_NAME" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="dept_ref_id" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="관리부서ID" Hidden="True" Key="dept_ref_id">
                                    <Header Caption="관리부서ID">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="daily_phone" HeaderText="연락처" Hidden="True"
                                    Key="daily_phone">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="연락처">
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
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="60px">
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
                                <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계" Key="RESULT_MEASUREMENT_STEP_NAME"
                                    Width="60px">
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
                            HeaderClickActionDefault="NotSet" Name="ugrdKpiList" RowHeightDefault="20px" HeaderStyleDefault-Height="35px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                            <GroupByBox>
                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                            <HeaderStyleDefault BackColor="#94BAC9" Cursor="Hand" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" Cursor="Hand" BorderColor="#E9EBEB" BorderStyle="Solid"
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
              <td style="width:250px;" valign="top">
                <ig:ultrawebgrid id="ugrdOpinionList" runat="server" width="100%" Height="100%" style="left: 0px" Browser="Xml"><Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <Columns>
                        <ig:TemplatedColumn Key="selchk" Width="30px" Hidden="True">
                        <CellTemplate>
                            <asp:CheckBox ID="cBox" runat="server" />
                        </CellTemplate>
                        </ig:TemplatedColumn>
                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                Format="" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Width="50px" Hidden="True">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="ESTTERM_REF_ID">
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header><Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" EditorControlID="" FooterText=""
                                Format="" HeaderText="GROUP_REF_ID" Key="GROUP_REF_ID" Width="60px" Hidden="True">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="GROUP_REF_ID">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header><Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                Format="" HeaderText="사원번호" Key="EMP_REF_ID" Width="60px" Hidden="True">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="사원번호">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header><Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_LEVEL_NAME" Key="EST_LEVEL_NAME" Width="48px" FooterText="" HeaderText="차수명">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="차수명">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="OPINION" EditorControlID="" FooterText=""
                                Format="" HeaderText="평가의견" Key="OPINION" Width="180px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="평가의견">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                    <DisplayLayout Version="4.00" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" 
                                   HeaderClickActionDefault="SortMulti" Name="ugrdOpinionList" BorderCollapseDefault="Separate" 
                                   RowSelectorsDefault="No" RowHeightDefault="80px" SelectTypeRowDefault="Single" 
                                   AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" 
                                   StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed" JavaScriptFileName="" JavaScriptFileNameCommon="" RowSizingDefault="Free">
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                        </GroupByRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="36px">
                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <Images ImageDirectory="">
                        </Images>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px" Wrap="True">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" Cursor="Hand" BorderColor="#E7E7E7" BorderStyle="Solid"
                            BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                        <ClientSideEvents CellClickHandler="ugrdOpinionList_CellClickHandler" />
                    </DisplayLayout>
                </ig:ultrawebgrid>
            </td>
          </tr>
        </table>
        <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
        <div id="divAreaAppLine" runat="server" 
             style="position:absolute; height:300px; width:500px; margin:1px; border-width:1px; display:none; border-collapse:collapse; text-align:left; background-color:#ffffff;
                    top:200px; left:200px;">
          <table border="2" cellpadding="0" cellspacing="2" style="width:100%; height:100%; border-collapse:collapse;">
            <tr>
              <td style="height:25px; text-align:left;">
                  <img src="../images/arrow/arrow.gif" alt="" />&nbsp;<b>평가의견 상세내용</b>
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