<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0101A4.aspx.cs" Inherits="PRJ_PRJ0101A4" enableEventValidation="false" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    <script type="text/javascript" language="javascript">

    /*=========================================================================
     호출 파라미터 결재상신, 재상신 처리
     prj_ref_id     : 결재원문파라미터
     app_ref_id     : 결재문서가 최초버젼일 아닐경우
     biz_type       : KDA:지표정의서 결재, KRA:지표실적결재, PMA:사업관리
     app_ccb        : 결재처리후 호출화면에서 처리시 컨트롤 client id 넘겨줌
   //========================================================================*/
   function OpenDraft(draftStatus)
   {
        
        var prj_ref_id      = "<%= this.IPrjRefID %>";     
        var app_ref_id      = "<%= this.IApp_Ref_Id %>";
        var app_ccb         = "<%= this.IAPP_CCB %>";
        var biz_type        = "<%= Biz_Type.biz_type_prj_doc %>";
        
        var draft_emp_id    = parseInt("<%= this.IDraftEmpID %>",10);
        
        if (draft_emp_id=="NaN" || draft_emp_id  < 1)
        {
            alert("기안자 정보를 알수 없습니다.");
            return false;
        }
        
        var url             = "../BSC/BSC0901M1.aspx?DRAFT_STATUS="+draftStatus+"&PRJ_REF_ID=" + prj_ref_id + "&BIZ_TYPE="+biz_type+"&APP_CCB="+app_ccb+"&APP_REF_ID="+app_ref_id+"&DRAFT_EMP_ID="+draft_emp_id;

        gfOpenWindow(url, 900, 650, 'BSC0901M1');
        
        return false;
   }
    </script>
    
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
    <table cellpadding="2" cellspacing="0" border="0" width="100%"> 
    <tr>
     <td class="tableOutBorder">
       <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="tableTitle" align="center" style="width:100px; height: 22px">사업 CODE</td>
            <td class="tableContent" style="height: 22px">
              <asp:TextBox ID="txtPRJ_CODE" runat="server" BorderWidth="0" BackColor="LightGray" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="tableTitle" align="center" style="width:100px; height: 22px">
                사 업 명</td>
	        <td class="tableContent" valign="middle" style="height: 22px">
                <asp:TextBox ID="txtPRJ_NAME" runat="server" Width="450px" BorderWidth="0" BackColor="LightGray" ReadOnly="True"></asp:TextBox>
             </td>
        </tr>
       </table>
     </td>
    </tr>
    </table>
    <BR />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tbody>
                        <tr>
                          <td>
                            <table cellspacing="0" cellpadding="1" width="100%" border="0">
                              <tbody>
                                <tr>
                                  <td class="tableTitle" width="80" align="center">평가기간</td>
                                  <td class="tableContent" width="120">
                                     <asp:dropdownlist id="ddlEstTermInfo" class="box01" runat="server" width="100%" ></asp:dropdownlist></td>
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
                                    <asp:ImageButton id="iBtnSearch"  runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle" OnClick="iBtnSearch_Click"></asp:ImageButton>&nbsp;
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </td>
                        </tr>
                      </tbody>
                    </table>
         <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:480px;">
                              <tr>
                                <td  valign="top" style="width: 302px;">
                                    <ig:UltraWebGrid ID="ugrdKpiPrjList" runat="server" Height="100%" 
                                         Width="100%">
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                </AddNewRow>
                                                <Columns>
                                                    <ig:TemplatedColumn Key="selchk" Width="30px">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'ugrdKpiPrjList');" />
                                                        </HeaderTemplate>
                                                        <CellTemplate>
                                                            <asp:CheckBox ID="cBox" runat="server" />
                                                        </CellTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="iTYPE" Hidden="True" Key="ITYPE">
                                                        <Header Caption="iTYPE">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="평가기간코드" Hidden="True"
                                                        Key="ESTTERM_REF_ID">
                                                        <Header Caption="평가기간코드">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                                        FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="PRJ_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI" Hidden="True"
                                                        Key="KPI_REF_ID">
                                                        <Header Caption="KPI">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_CODE" HeaderText="CODE" Key="KPI_CODE"
                                                        Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="CODE">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_NAME" HeaderText="KPI 명" Key="KPI_NAME"
                                                        Width="210px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="KPI 명">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                </Columns>
                                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                </RowTemplateStyle>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout AllowColSizingDefault="Free" AllowDeleteDefault="Yes" AllowSortingDefault="Yes"
                                            AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect"
                                            CellPaddingDefault="2" HeaderClickActionDefault="NotSet" Name="ugrdKpiPrjList"
                                            RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                            StationaryMargins="Header" TableLayout="Fixed" Version="4.00">
                                            <GroupByBox>
                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                            </GroupByBox>
                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                            </GroupByRowStyleDefault>
                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                            </FooterStyleDefault>
                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px"
                                                Cursor="Hand">
                                                <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                <Padding Left="3px" />
                                            </RowStyleDefault>
                                            <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                ForeColor="White" Height="20px" HorizontalAlign="Left">
                                                <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
                                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                                            <ClientSideEvents  />
                                            <ActivationObject BorderColor="" BorderWidth="">
                                            </ActivationObject>
                                        </DisplayLayout>
                                    </ig:UltraWebGrid></td>
                                <td  valign="middle" style="width: 9px;">&nbsp;&nbsp;
                                    <asp:ImageButton ID="btnOut" runat="server" Height="14px" ImageUrl="~/images/btn/b_arrow2.gif"
                                        OnClick="btnOut_Click" /><br />
                                    <br />
                                    <br />
                                    <asp:ImageButton ID="btnIn" runat="server" Height="14px" ImageUrl="~/images/btn/b_arrow1.gif"
                                        OnClick="btnIn_Click" /></td>
                                <td valign="top">
                                <DIV style="DISPLAY: block; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; OVERFLOW: auto;  WIDTH: 100%;  HEIGHT: 100%" id="Div1">
                                    <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Height="100%" 
                                         Width="100%">
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                </AddNewRow>
                                                <Columns>
                                                    <ig:TemplatedColumn Key="selchk" Width="30px">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'ugrdKpiList');" />
                                                        </HeaderTemplate>
                                                        <CellTemplate>
                                                            <asp:CheckBox ID="cBox" runat="server" />
                                                        </CellTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="iTYPE" Hidden="True" Key="ITYPE">
                                                        <Header Caption="iTYPE">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                                        FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="ESTTERM_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                                        FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="KPI_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                        Format="" HeaderText="CODE" Key="KPI_CODE" Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="CODE">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                        Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="150px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Header Caption="운영조직">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                        Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="200px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ValueList DisplayStyle="NotSet">
                                                        </ValueList>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Header Caption="KPI 명">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME"
                                                        Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="KPI담당자">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표유형" Key="KPI_GROUP_NAME"
                                                        Width="70px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="지표유형">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Hidden="True" Key="UNIT_NAME"
                                                        Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="단위">
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID=""
                                                        FooterText="" Format="" HeaderText="실적방식" Hidden="True" Key="RESULT_INPUT_TYPE_NAME"
                                                        Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="실적방식">
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:TemplatedColumn BaseColumnName="USE_YN" EditorControlID="" FooterText="" HeaderText="사용여부"
                                                        Hidden="True" Key="USE_YN" Width="35px">
                                                        <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                        </CellTemplate>
                                                        <HeaderStyle Wrap="True" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="사용여부">
                                                            <RowLayoutColumnInfo OriginX="11" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="11" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    <ig:TemplatedColumn BaseColumnName="APPROVAL_STATUS" EditorControlID="" FooterText=""
                                                        HeaderText="확정여부" Hidden="True" Key="APPROVAL_STATUS" Width="35px">
                                                        <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                        </CellTemplate>
                                                        <HeaderStyle Wrap="True" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="확정여부">
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계"
                                                        Hidden="True" Key="RESULT_MEASUREMENT_STEP_NAME" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Header Caption="측정단계">
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                            </Columns>
                            
                            
                            
                                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                </RowTemplateStyle>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout AllowColSizingDefault="Free" AllowDeleteDefault="Yes" AllowSortingDefault="Yes"
                                            AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect"
                                            CellPaddingDefault="2" HeaderClickActionDefault="NotSet" Name="ugrdKpiList"
                                            RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                            StationaryMargins="Header" TableLayout="Fixed" Version="4.00">
                                            <GroupByBox>
                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                            </GroupByBox>
                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                            </GroupByRowStyleDefault>
                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                            </FooterStyleDefault>
                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px"
                                                Cursor="Hand">
                                                <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                <Padding Left="3px" />
                                            </RowStyleDefault>
                                            <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                ForeColor="White" Height="20px" HorizontalAlign="Left">
                                                <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
                                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                                            <ClientSideEvents />
                                            <ActivationObject BorderColor="" BorderWidth="">
                                            </ActivationObject>
                                        </DisplayLayout>
                                    </ig:UltraWebGrid>
                                    </DIV>
                                    <SJ:SmartScroller ID="SmartScroller2" runat="server" MaintainScrollX="true" MaintainScrollY="true"
                                        TargetObject="Div1">
                                    </SJ:SmartScroller>
                                </td>
                              </tr>
                              
                              <tr>
                              <td colspan="4" style="height:24px;" align="right" valign="middle">
                            <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
                                  <asp:HiddenField ID="hdfPrjRefID" runat="server" />
                                  <asp:LinkButton ID="linkBtnDraft" runat="server" OnClick="linkBtnDraft_Click" Visible="false"></asp:LinkButton>
                                  <asp:ImageButton ID="iBtnDraft" runat="server" ImageUrl="../images/draft/draft.gif" Visible="false" />
                                  <asp:ImageButton ID="iBtnReDraft" runat="server" ImageUrl="../images/draft/redraft.gif" Visible="false" />
                                  <asp:ImageButton ID="iBtnMoDraft" runat="server" ImageUrl="../images/draft/modraft.gif" Visible="false" />
                                  <asp:ImageButton ID="iBtnReWrite" ImageUrl="../images/draft/rewrite.gif" runat="server" Visible="false" />
                                  <asp:ImageButton ID="iBtnReqModify" runat="server" ImageUrl="../images/draft/morequest.gif" OnClick="iBtnReqModify_Click" Visible="false" />
                                  <asp:ImageButton ID="iBtnClose" runat="server" Height="19px" ImageUrl="../images/btn/b_003.gif" OnClick="iBtnClose_Click" />
                              </td>
                             </tr>
                            </table>
    <!--- MAIN END --->
    </form>
</body>
</html>
