<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0101A1.aspx.cs" Inherits="PRJ_PRJ0101A1" enableEventValidation="false" %>
<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    <script language="jscript" type="text/javascript">
    
    function opencantt()
    {
         var prjID      = "<%= this.IPrjRefID %>";     
         var prjType         = document.forms[0].ddlPrjType.value;

        var url             = 'PRJ0102S3.ASPX?PAGE_TYPE=P&PRJ_REF_ID=' + prjID+'&PRJ_TYPE='+prjType ;
        gfOpenWindow(url, 840, 520, 'yes', 'no', 'PRJ0102S3');
    }

    
  function chkOK() 
{
	var f = document.forms[0];

    if(f.txtPRJ_CODE.value == '') 
	{
		alert('사업코드를 입력해 주세요.');
		f.txtPRJ_CODE.focus();
		return false;
	}
	
	if(f.txtPRJ_NAME.value == '') 
	{
		alert('사업명을 입력해 주세요.');
		f.txtPRJ_NAME.focus();
		return false;
	}
	
	if(document.getElementById('wdcPlanStartDate').value == '') 
	{
		alert('계획시작일자를 선택해 주세요.');
		return false;
	}
	
	
	if(document.getElementById('wdcPlanEndDate').value == '') 
	{
		alert('계획종료일자를 선택해 주세요.');
		return false;
	}
	
	if(f.ddlOwnerDeptID.value == '0') 
	{
		alert('주간부서를 선택해 주세요.');
		f.ddlOwnerDeptID.focus();
		return false;
	}
	if(f.txtOWNER_EMP_ID.value == '') 
	{
		alert('책임자를 입력해 주세요.');
		f.txtOWNER_EMP_ID.focus();
		return false;
	}
	
	return true;	
}

    function openGridDeptEmp(strVal1,strVal2,strVal3,strVal4,strVal5)
    {
        var objVal1 = document.getElementById(strVal1);
        var objVal2 = document.getElementById(strVal2);
        var objVal3 = document.getElementById(strVal3);
        var objVal4 = document.getElementById(strVal4);
        var objVal5 = document.getElementById(strVal5);
        
        strVal1 = objVal1.name;
        strVal2 = objVal2.name;
        strVal3 = objVal3.name;
        strVal4 = objVal4.name;
        strVal5 = objVal5.name;
      
        var ICCB2           = "<%= this.ICCB2 %>";

        var url             = "PRJ0103S1.aspx?STR_VAR1="+ strVal1 + "&STR_VAR2=" + strVal2 + "&STR_VAR3="+ strVal3 + "&STR_VAR4=" + strVal4 + "&STR_VAR5="+ strVal5 + "&TYPE=G&CCB2="+ICCB2;
        
        gfOpenWindow(url, 750, 400, 'yes', 'no', 'PRJ0103S1');
    }
    
    
    function openGridShareEmp(strVal1,strVal2,strVal3,strVal4,strVal5)
    {
        var objVal1 = document.getElementById(strVal1);
        var objVal2 = document.getElementById(strVal2);
        var objVal3 = document.getElementById(strVal3);
        var objVal4 = document.getElementById(strVal4);
        var objVal5 = document.getElementById(strVal5);
        
        strVal1 = objVal1.name;
        strVal2 = objVal2.name;
        strVal3 = objVal3.name;
        strVal4 = objVal4.name;
        strVal5 = objVal5.name;
      
        var ICCB2           = "<%= this.ICCB3 %>";

        var url             = "PRJ0103S1.aspx?STR_VAR1="+ strVal1 + "&STR_VAR2=" + strVal2 + "&STR_VAR3="+ strVal3 + "&STR_VAR4=" + strVal4 + "&STR_VAR5="+ strVal5 + "&TYPE=S&CCB2="+ICCB2;
        
        gfOpenWindow(url, 750, 400, 'yes', 'no', 'PRJ0103S1');
    }
    
    

    function openDeptEmp(strKeyObj, strValObj)
    {
        var objKey = document.getElementById(strKeyObj);
        var objVal = document.getElementById(strValObj);
        strKeyObj = objKey.name;
        strValObj = objVal.name;
        var ICCB2           = "<%= this.ICCB2 %>";

        var url             = "PRJ0103S1.aspx?OBJ_KEY="+ strKeyObj + "&OBJ_VAL=" + strValObj +"&TYPE=P&CCB2="+ICCB2;
        
        gfOpenWindow(url, 750, 400, 'yes', 'no', 'PRJ0103S1');
    }
    
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
         <table border="0" cellpadding="1" cellspacing="0" width="100%" class="tableBorder">
            <tr>
                <td class="cssTblTitle"  >
                    사업코드(*)
                </td>
                <td  class="cssTblContent" >
                    <asp:TextBox ID="txtPRJ_CODE" runat="server" Width="100%"></asp:TextBox></td>
                <td class="cssTblTitle"  >
                    사업명(*)
                </td>
                <td class="cssTblContent" >
                    <asp:TextBox ID="txtPRJ_NAME" runat="server" Width="100%"></asp:TextBox></td>
          </tr>
          
          <tr>
            <td class="cssTblTitle"  >
                사업정의
            </td>
            <td  class="cssTblContent">
              <asp:TextBox ID="txtDEFINITION" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td class="cssTblTitle"  >
                전략과제
            </td>
            <td  class="cssTblContent"  >
              <asp:TextBox ID="txtREF_STG" runat="server" Width="100%"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td class="cssTblTitle"  >
                계획기간(*)
            </td>
            <td class="cssTblContent" >
                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                   <tr>
                     <td style="width:80px;">
                        <ig:WebDateChooser ID="wdcPlanStartDate" runat="server" NullDateLabel="" Format="Short">
                            <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                        </ig:WebDateChooser> 
                     </td>
                     <td style="width:10px;">&nbsp;~&nbsp;</td>
                     <td >
                        <ig:WebDateChooser ID="wdcPlanEndDate" runat="server" NullDateLabel="">
                            <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                        </ig:WebDateChooser>
                     </td>
                   </tr>
                 </table>
            </td>
            <td class="cssTblTitle"  >
                실행기간
            </td>
            <td class="cssTblContent" >
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                   <tr>
                     <td  style="width:80px;">
                        <ig:WebDateChooser ID="wdcActualStartDate" runat="server" NullDateLabel="" Format="Short" BackColor="#E0E0E0" ReadOnly="True">
                            <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                        </ig:WebDateChooser> 
                     </td>
                     <td style="width:10px;">&nbsp;~&nbsp;</td>
                     <td  >
                        <ig:WebDateChooser ID="wdcActualEndDate" runat="server" NullDateLabel="" BackColor="#E0E0E0" ForeColor="Black" ReadOnly="True">
                            <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                        </ig:WebDateChooser>
                     </td>
                   </tr>
                </table>
            </td>
          </tr>
     
          <tr>
            <td class="cssTblTitle"  >
                기대효과
            </td>
            <td class="cssTblContent" colspan="3"  >
              <asp:TextBox ID="txtEFFECTIVENESS" runat="server" Width="100%" Height="66px" TextMode="MultiLine"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td class="cssTblTitle"  >
                예상산출물
            </td>
            <td class="cssTblContent" colspan="3"  >
              <asp:TextBox ID="txtRANGE" runat="server" Width="100%" Height="76px" TextMode="MultiLine"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td class="cssTblTitle"  >
                주관부서(*)
            </td>
            <td class="cssTblContent">
                <asp:DropDownList ID="ddlOwnerDeptID" runat="server" Width="250px" class="box01" >
                </asp:DropDownList>
            </td>
            <td class="cssTblContent" colspan="2" rowspan="7" >
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;height:100%;" >
                    <tr>
                        <td>
                            <table  cellpadding="0" cellspacing="2" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="사업공유정보"/></td>
                                </tr>
                            </table>
                        </td>
                        <td align="right">
                            <asp:Image ID="ImgBtnShareAddRow" style="cursor:pointer;" runat="server" BorderWidth="0px" ImageUrl="../images/btn/b_005.gif" onclick="openGridShareEmp('hdfValue1','hdfValue2','hdfValue3','hdfValue4','hdfValue5');" />
                            <asp:ImageButton ID="ImgBtnShareDelRow" style="cursor:pointer;" ImageUrl="../images/btn/b_004.gif" runat="server" OnClick="ImgBtnShareDelRow_Click" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:100%;">
                            <ig:UltraWebGrid ID="ugrdProjectShareList" runat="server" Height="100%" Width="100%">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header"  style="cursor:pointer;" runat="server" onclick="selectChkBox(this, 'ugrdProjectShareList');" />
                                                </HeaderTemplate>
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox"  style="cursor:pointer;" runat="server" />
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
                                            <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                                FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="PRJ_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="TASK_REF_ID" Hidden="True" Key="TASK_REF_ID">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="EMP_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_CODE" Hidden="True" Key="DEPT_CODE">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID="" FooterText=""
                                                Format="" HeaderText="성명" Key="EMP_NAME" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="성명">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서명" Key="DEPT_NAME"
                                                Width="150px">
                                                <Header Caption="부서명">
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" 
                                                AllowDeleteDefault="Yes" 
                                                AllowSortingDefault="Yes"
                                                AutoGenerateColumns="False" 
                                                BorderCollapseDefault="Separate" 
                                                CellClickActionDefault="RowSelect"
                                                CellPaddingDefault="2" 
                                                HeaderClickActionDefault="NotSet" 
                                                Name="ugrdProjectShareList"
                                                RowHeightDefault="20px" 
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended"
                                                StationaryMargins="Header" 
                                                TableLayout="Fixed" 
                                                ReadOnly="LevelTwo"
                                                OptimizeCSSClassNamesOutput="False"
                                                Version="4.00">
                                    <%--<FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                                    </FrameStyle>
                                    <ClientSideEvents />
                                    <Pager>
                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
                                        </PagerStyle>
                                    </Pager>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                        ForeColor="White" Height="20px" HorizontalAlign="Left">
                                        <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                    </HeaderStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px"
                                        Cursor="Hand">
                                        <Padding Left="3px" />
                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                    </RowStyleDefault>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                    </GroupByBox>
                                    <AddNewBox Hidden="False">
                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
                                        </BoxStyle>
                                    </AddNewBox>
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>--%>
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                    <Images>
                                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                </table>
                
                
            </td>
          </tr>
           <tr>
            <td class="cssTblTitle"  >
               책임자(*)
            </td>
            <td class="cssTblContent">
                <asp:HiddenField ID="hdfOWNER_EMP_ID" runat="server" />
              <asp:TextBox ID="txtOWNER_EMP_ID" runat="server" Width="48%" onclick="openDeptEmp('hdfOWNER_EMP_ID','txtOWNER_EMP_ID');" style="cursor:hand" AutoPostBack="True" BackColor="#E0E0E0"></asp:TextBox>
                <img  alt="" src="../images/btn/b_008.gif" style="cursor:hand; vertical-align: top;" onclick="openDeptEmp('hdfOWNER_EMP_ID','txtOWNER_EMP_ID');" /></td>
            
          </tr>
          <tr>
            <td class="cssTblTitle"  >
                요청부서(기관)
            </td>
            <td class="cssTblContent"  >
              <asp:TextBox ID="txtREQUEST_DEPT" runat="server" Width="250px"></asp:TextBox>
            </td>
            
          </tr>
          <tr>
            <td class="cssTblTitle"  >
                중요도
            </td>
            <td class="cssTblContent" >
              <asp:DropDownList ID="ddlPRIORITY" runat="server" class="box01"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td class="cssTblTitle"  >
                사업유형
            </td>
            <td class="cssTblContent" >
              <asp:DropDownList ID="ddlPrjType" runat="server" class="box01">
                </asp:DropDownList>
            </td>
          </tr>
            <tr>
            <td class="cssTblTitle"  >
              총 사업비
            </td>
            <td class="cssTblContent" >
                <ig:WebNumericEdit ID="txtTotalBudget" runat="server" MaxValue="999999999999999"
                    MinValue="-999999999999999" Width="250px">
                </ig:WebNumericEdit>
            </td>
          </tr>
          <tr>
            <td class="cssTblTitle" >
              이해관계자
            </td>
            <td  class="cssTblContent">
              <asp:TextBox ID="txtINTERESTED_PARTIES" runat="server" Width="250px"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td class="cssTblContent" colspan="4">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;height:100%;" >
                    <tr>
                        <td style="width:50%;">
                            <table  cellpadding="0" cellspacing="2" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="사업수행구성원"/></td>
                                </tr>
                            </table>
                        </td>
                        <td  style="width:50%;" align="right">
                            <asp:LinkButton ID="linkBtnDraft" style="cursor:pointer;" runat="server" OnClick="linkBtnDraft_Click" Visible="false"></asp:LinkButton>
                            <asp:Image ID="ImgBtnAddRow" style="cursor:pointer;" runat="server" BorderWidth="0px" ImageUrl="../images/btn/b_005.gif" onclick="openGridDeptEmp('hdfValue1','hdfValue2','hdfValue3','hdfValue4','hdfValue5');" />
                            <asp:ImageButton ID="ImgBtnDelRow" style="cursor:pointer;" ImageUrl="../images/btn/b_004.gif" runat="server" OnClick="ImgBtnDelRow_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"  style="height:150px;">
                            <ig:UltraWebGrid ID="ugrdResourceList" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdResourceList_InitializeLayout" OnInitializeRow="ugrdResourceList_InitializeRow" >
                                <Bands>
                                    <ig:UltraGridBand>
                                         <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header" style="cursor:pointer;" runat="server" onclick="selectChkBox(this, 'ugrdResourceList');" />
                                                </HeaderTemplate>
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" style="cursor:pointer;" runat="server" />
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
                                            <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                                FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="PRJ_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="EMP_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID="" FooterText=""
                                                Format="" HeaderText="성명" Key="EMP_NAME" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="성명">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="ROLE_TYPE" EditorControlID=""
                                                FooterText="" Format="" HeaderText="역할" Key="ROLE_TYPE" Width="120px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Header Caption="역할">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="NOTE" HeaderText="기타사항" Hidden="True" Key="NOTE">
                                                <Header Caption="기타사항">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ISDELETE" HeaderText="삭제여부" Hidden="True"
                                                Key="ISDELETE">
                                                <Header Caption="삭제여부">
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DAILY_PHONE" HeaderText="전화" Key="DAILY_PHONE"
                                                Width="130px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Header Caption="전화">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CELL_PHONE" HeaderText="모바일" Key="CELL_PHONE"
                                                Width="130px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Header Caption="모바일">
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_EMAIL" HeaderText="이메일" Key="EMP_EMAIL"
                                                Width="150px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Header Caption="이메일">
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                 <DisplayLayout CellPaddingDefault="2" 
                                                AllowColSizingDefault="Free" 
                                                AllowDeleteDefault="Yes"
                                                AllowSortingDefault="Yes" 
                                                BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="NotSet" 
                                                Name="ugrdResourceList" 
                                                RowHeightDefault="20px"
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended" 
                                                Version="4.00" 
                                                CellClickActionDefault="RowSelect" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="Header" 
                                                ReadOnly="LevelTwo"
                                                OptimizeCSSClassNamesOutput="False"
                                                AutoGenerateColumns="False">
                                        <%--<GroupByBox>
                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                        </GroupByBox>
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
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
                                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="170px"
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
                                        <ClientSideEvents />
                                     <ActivationObject BorderColor="" BorderWidth="">
                                     </ActivationObject>--%>
                                     <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                    <Images>
                                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                            <asp:HiddenField ID="hdfValue1" runat="server" />
                            <asp:HiddenField ID="hdfValue2" runat="server" />
                            <asp:HiddenField ID="hdfValue3" runat="server" />
                            <asp:HiddenField ID="hdfValue4" runat="server" />
                            <asp:HiddenField ID="hdfValue5" runat="server" />
                        </td>
                    </tr>
                </table>
              </td>
          </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%;" >
            <tr>    
                <td align="right" class="cssPopBtnLine">
                  <a href="javascript:opencantt();"><img alt="" src="../images/btn/b_009.gif" border="0" /></a>
                  <asp:ImageButton ID="iBtnComplete_Y" runat="server" ImageUrl="../images/btn/b_018.gif" OnClick="iBtnComplete_Y_Click" />
                  <asp:ImageButton ID="iBtnComplete_N" runat="server" ImageUrl="../images/btn/b_078.gif" OnClick="iBtnComplete_N_Click" />
                  <asp:ImageButton ID="iBtnDraft" ImageUrl="../images/draft/draft.gif" runat="server" Visible="false"  />
                  <asp:ImageButton ID="iBtnReDraft" ImageUrl="../images/draft/redraft.gif" runat="server" Visible="false" />
                  <asp:ImageButton ID="iBtnMoDraft" ImageUrl="../images/draft/modraft.gif" runat="server" Visible="false" />
                  <asp:ImageButton ID="iBtnReWrite" ImageUrl="../images/draft/rewrite.gif" runat="server" Visible="false" />
                  <asp:ImageButton ID="iBtnReqModify" ImageUrl="../images/draft/morequest.gif" runat="server" Visible="false" OnClick="iBtnReqModify_Click" />            
                  <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server" OnClick="iBtnInsert_Click" OnClientClick="return chkOK();" />
                  <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" OnClick="iBtnUpdate_Click" />
                  <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/b_004.gif" runat="server" OnClick="iBtnDelete_Click" />
                  <asp:ImageButton ID="iBtnReUsed" runat="server" Height="19px" ImageUrl="../images/btn/b_138.gif" OnClick="iBtnReUsed_Click" />
                  <asp:ImageButton ID="iBtnClose" runat="server" Height="19px" ImageUrl="../images/btn/b_003.gif" OnClick="iBtnClose_Click" />
                </td>
            </tr>
        </table>
        
          <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
         <asp:linkbutton id="lBtnAddRow" runat="server" OnClick="lBtnAddRow_Click"></asp:linkbutton>
        <asp:LinkButton ID="IBtnShareAddRow" runat="server" OnClick="IBtnShareAddRow_Click"></asp:LinkButton><!--- MAIN END --->

    </form>
   
</body>
</html>
