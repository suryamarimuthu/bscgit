<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0101A2.aspx.cs" Inherits="PRJ_PRJ0101A2" enableEventValidation="false"  %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="/_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="/_common/js/common.js"></script>
    <script language="jscript" type="text/javascript">
   
        function processKeyPress() 
        { 
            if (event.keyCode == 13) 
            { 
            self.focus(); 
            return false; 
            } 
        } 
   
    function CheckValue()
    {
      var f = document.forms[0];
      
      if(f.txtProceedRate.value > 100)
      {
         alert("진행율 입력값을 다시 확인해주세요");
         f.txtProceedRate.focus();
		    return false;
      }
      else
      {
         return true;
      }
    }
    function chkUpdate() 
    {
	    var f = document.forms[0];
	    
        if(f.hdfTaskRefID.value == '0' || f.hdfTaskRefID.value == '') 
	    {
		    alert('작업을 선택 주세요.');
		    return false;
	    }
	    
	    if(f.txtTaskCode.value == '') 
	    {
		    alert('작업코드를 입력해주세요.');
		    return false;
	    }
	    
	
	
	    if(f.txtTaskName.value == '') 
	    {
		    alert('작업명을 입력해 주세요.');
		    f.txtTaskName.focus();
		    return false;
	    }
    	
	    if(document.getElementById('wdcSchPlanStartDate').value == '') 
	    {
		    alert('계획시작일자를 선택해 주세요.');
		    return false;
	    }
    	
    	
	    if(document.getElementById('wdcSchPlanEndDate').value == '') 
	    {
		    alert('계획종료일자를 선택해 주세요.');
		    return false;
	    }
	        	
	    return true;	
    }
    function selectNode(strValObj)
    {
        var objKey = document.getElementById('hdfSelectNode'); 
        objKey.value = strValObj;
        
        //alert(objKey.value);
        
        __doPostBack('TrvSelectNode','');
    }
    
    function openPrjUpTask(strKeyObj, strValObj,strNodeObj)
    {
      var objKey = document.getElementById('hdfUpTaskRefID');
    
      
        if(objKey.value == "")
        {
           alert("일정을 먼저 선택하여주십시오.");
           return;
        }
        
        if(objKey.value == "0")
        {
           alert("프로젝트레벨은 상위작업을 선택하실수없습니다.");
           return;
        }
    
            var objKey = document.getElementById(strKeyObj);
            var objVal = document.getElementById(strValObj);
            var objNode = document.getElementById(strNodeObj); 
            strKeyObj = objKey.name;
            strValObj = objVal.name;
            strNode = objNode.value;
              
            var ICCB2           = "<%= this.ICCB2 %>";
            var PRJ_REF_ID      = "<%= this.IPrjRefID %>";

            var url             = "PRJ0104S1.aspx?CTRL_VALUE_NAME="+ strKeyObj + "&CTRL_TEXT_NAME=" + strValObj + "&PRJ_REF_ID=" + PRJ_REF_ID + "&AFTER_TASK_YN=N&SELECT_NODE=" + strNode;
            
            gfOpenWindow(url, 500, 430, 'yes', 'no', 'PRJ0104S1');
    }
    
    function openPrjAfterTask(strKeyObj, strValObj,strNodeObj)
    {
            var objKey = document.getElementById(strKeyObj);
            var objVal = document.getElementById(strValObj);
            var objNode = document.getElementById(strNodeObj);
            
            strKeyObj = objKey.name;
            strValObj = objVal.name;
            strNode = objNode.value;
            var ICCB2           = "<%= this.ICCB2 %>";
            var PRJ_REF_ID      = "<%= this.IPrjRefID %>";

            var url             = "PRJ0104S1.aspx?CTRL_VALUE_NAME="+ strKeyObj + "&CTRL_TEXT_NAME=" + strValObj + "&PRJ_REF_ID=" + PRJ_REF_ID + "&AFTER_TASK_YN=Y&SELECT_NODE=" + strNode;
            
            gfOpenWindow(url, 500, 430, 'yes', 'no', 'PRJ0104S1');
    }
    
    function openTaskOwner(strVal1,strVal2,strVal3,strVal4,strVal5)
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
        
         var PRJ_REF_ID      = "<%= this.IPrjRefID %>";
      
        var ICCB3           = "<%= this.ICCB3 %>";

        var url             = "PRJ0103S2.aspx?PRJ_REF_ID="+ PRJ_REF_ID  + "&STR_VAR1="+ strVal1 + "&STR_VAR2=" + strVal2 + "&STR_VAR3="+ strVal3 + "&STR_VAR4=" + strVal4 + "&STR_VAR5="+ strVal5 + "&TYPE=O&CCB2="+ICCB3;
        
        gfOpenWindow(url, 750, 400, 'yes', 'no', 'PRJ0103S1');
    }
    
    function openTaskShare(strVal1,strVal2,strVal3,strVal4,strVal5)
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
      
        var ICCB4           = "<%= this.ICCB4 %>";

        var url             = "PRJ0103S1.aspx?STR_VAR1="+ strVal1 + "&STR_VAR2=" + strVal2 + "&STR_VAR3="+ strVal3 + "&STR_VAR4=" + strVal4 + "&STR_VAR5="+ strVal5 + "&TYPE=S&CCB2="+ICCB4;
        
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

<script language="javascript" type="text/javascript">
    // <!CDATA[
    function mfUpload(hAttachNo)
    {
      
        //수정(20060707 이승주)
        var oAttach = document.getElementById("hdfAttachNo");
       
        var oaArg   = new Array("FILE", "PRJ_File", (oAttach==null ? "" : oAttach.value));
        
        var oReturn = gfOpenDialog("../base/FileUploadMain.aspx", oaArg, 485, 307);
        
        if (oReturn != "" && oReturn != undefined)
        {
            oAttach.value = oReturn;
             //__doPostBack('TrvSelectNode','');
        }
        else
        {
            alert("파일첨부를 하지 않았습니다!");
        }
        return false;
    }
    // ]]>
    </script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
       
        </table>
         <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="3">
                    <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="cssTblTitle">사업코드</td>
                        <td class="cssTblContent">
                          <asp:TextBox ID="txtPRJ_CODE" runat="server" Width="100%" BorderWidth="0" BackColor="LightGray" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="cssTblTitle" >
                            사업명</td>
	                    <td class="cssTblContent">
                            <asp:TextBox ID="txtPRJ_NAME" runat="server" Width="100%" BorderWidth="0" BackColor="LightGray" ReadOnly="True"></asp:TextBox>
                         </td>
                    </tr>
               </table>
                </td>
            </tr>
          <tr>
            <td style="width:70%; height:20px;">
              <table  cellpadding="0" cellspacing="2" border="0" style="height:98%; width:100%;">
                <tr>
                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                    <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="일정현황"/></td>
                </tr>
              </table> 
            </td>
            <td style="width:1%";>
                
            </td>
            <td  style="width:29%;">
              <table  cellpadding="0" cellspacing="2" border="0" style="height:98%; width:100%;">
                <tr>
                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                    <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="일정계획"/></td>
                </tr>
              </table> 
            </td>
          </tr>
          <tr>
            <td style="height:100%;" valign="top" class="cssDivLayout">
              <asp:Panel Width="100%" Height="100%" ScrollBars="auto" runat="server" ID="pnlTask">
                  <table  border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                      <td class="cssTblTitle" style="width:380px;height:25px;text-align:center;">작업명</td>
                  <%--<td class="cssTblTitle" width="100">기간</td>--%>
                      <td class="cssTblTitle" style="width:80px;text-align:center;">시작일자</td>
                      <td class="cssTblTitle" style="width:80px;text-align:center;">종료일자</td>
                      <td class="cssTblTitle" style="width:60px;text-align:center;">진행율</td>
                    </tr>
                    <tr>
                      <td colspan="5" style="height: 100%">
                        <asp:TreeView ID="TtrvTask" runat="server" Target="_self"  EnableClientScript="true" Width="100%" OnSelectedNodeChanged="TtrvTask_SelectedNodeChanged" ShowLines="True"></asp:TreeView>
                      </td>
                    </tr> 
                  </table>
              </asp:Panel>
            </td>
            <td>
                <asp:HiddenField ID="hdfValue1" runat="server" />
                  <asp:HiddenField ID="hdfValue2" runat="server" />
                  <asp:HiddenField ID="hdfValue3" runat="server" />
                  <asp:HiddenField ID="hdfValue4" runat="server" />
                  <asp:HiddenField ID="hdfValue5" runat="server" />
                  <asp:HiddenField ID="hdfSelectNode" runat="server" /><asp:HiddenField ID="hdfNodeDepth" runat="server" />
                  <asp:linkbutton id="lBtnAddRow" runat="server" OnClick="lBtnAddRow_Click"></asp:linkbutton><asp:linkbutton id="lBtnTaskOwnerAddRow" runat="server" OnClick="lBtnTaskOwnerAddRow_Click"></asp:linkbutton>&nbsp;
                  <asp:linkbutton id="lBtnTaskShareAddRow" runat="server" OnClick="lBtnTaskShareAddRow_Click"></asp:linkbutton><asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
                  <asp:LinkButton ID="TrvSelectNode" runat="server" OnClick="TrvSelectNode_Click"></asp:LinkButton>
                  <asp:HiddenField ID="hdfDesction" runat="server" />
            </td>
            <td style="vertical-align:top;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="pnlPlan">
                              <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="300px">
                                <tr>
                                  <td class="cssTblTitle"  nowrap="noWrap" >
                                      작업코드(*)
                                  </td>
                                  <td class="cssTblContent">
                                    <asp:TextBox ID="txtTaskCode" runat="server" Width="120px"></asp:TextBox>
                                      <asp:HiddenField ID="hdfTaskRefID" runat="server" /></td>
                                </tr>  
                                <tr>
                                  <td class="cssTblTitle" >
                                      작업명(*)
                                  </td>
                                  <td class="cssTblContent">
                                    <asp:TextBox ID="txtTaskName" runat="server" Width="120px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle" >
                                      계획일자
                                  </td>
                                  <td class="cssTblContent">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                      <tr>
                                        <td style="width:10%;">
                                            <ig:WebDateChooser ID="wdcSchPlanStartDate" runat="server" NullDateLabel="" Format="Short" Width="90px" >
                                                <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                            </ig:WebDateChooser>                                                
                                        </td>
                                        <td style="text-align:center">~</td>
                                        <td style="width:10%;">
                                            <ig:WebDateChooser ID="wdcSchPlanEndDate" runat="server" NullDateLabel="" Width="90px">
                                                <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                            </ig:WebDateChooser>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle" >
                                      작업가중치
                                  </td>
                                  <td class="cssTblContent">
                                    <ig:webnumericedit id="txtWeight" runat="server" Width="100px" Nullable="False" ValueText="0.0000"
                                        MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="작업가중치" NegativeForeColor="Magenta"
                                        Font-Size="10pt" Font-Names="Verdana" Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                     </ig:webnumericedit>%
                                  </td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle" >
                                      상위작업명
                                  </td>
                                  <td class="cssTblContent">
                                      <asp:TextBox ID="txtUPTaskName" runat="server" Width="100px" onclick="openPrjUpTask('hdfUpTaskRefID','txtUPTaskName','hdfSelectNode');" BackColor="LightGray"></asp:TextBox>&nbsp;
                                      <asp:Image ID="ibtnTask" runat="server" BorderWidth="0px" ImageAlign="Top" ImageUrl="../images/btn/b_094.gif" onclick="openPrjUpTask('hdfUpTaskRefID','txtUPTaskName','hdfSelectNode');" />
                                      <asp:HiddenField ID="hdfUpTaskRefID" runat="server" />
                                  </td>
                                </tr>
                                 <tr>
                                  <td class="cssTblTitle" >
                                      선행작업명
                                  </td>
                                  <td class="cssTblContent">
                                      <asp:TextBox ID="txtAfterTaskRefName" runat="server" Width="100px" onclick="openPrjAfterTask('hdfAfterTaskRefID','txtAfterTaskRefName','hdfSelectNode');" BackColor="LightGray"></asp:TextBox>&nbsp;
                                      <asp:Image ID="Image1" runat="server" BorderWidth="0px" ImageAlign="Top" ImageUrl="../images/btn/b_094.gif" onclick="openPrjAfterTask('hdfAfterTaskRefID','txtAfterTaskRefName','hdfSelectNode');" />
                                      <asp:HiddenField ID="hdfAfterTaskRefID" runat="server" />
                                  </td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle" >
                                    작업유형
                                  </td>
                                  <td class="cssTblContent">
                                    <asp:DropDownList ID="ddlTaskType" runat="server" class="box01" Width="120px"></asp:DropDownList>
                                  </td>
                                </tr> 
                                <tr>
                                  <td colspan="2">
                                      <table  cellpadding="0" cellspacing="2" border="0" style="height:98%; width:100%;">
                                        <tr>
                                            <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                            <td><asp:Label ID="Label2" runat="server" Font-Bold="true" Text="작업수행담당자"/></td>
                                        </tr>
                                      </table> 
                                  </td>
                                </tr>
                                <tr>
                                  <td colspan="2" align="right" style="height:110px;">
                                  <ig:UltraWebGrid ID="ugrdTaskOwnerList" runat="server" Width="100%" Height="100%" >
                                      <Bands>
                                          <ig:UltraGridBand>
                                              <Columns>
                                                  <ig:TemplatedColumn Key="selchk" Width="30px">
                                                      <HeaderTemplate>
                                                        <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'ugrdTaskOwnerList');" />
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
                                                      Format="" HeaderText="성명" Key="EMP_NAME" Width="105px">
                                                      <HeaderStyle HorizontalAlign="Center" />
                                                      <CellStyle HorizontalAlign="Left">
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
                                          </ig:UltraGridBand>
                                      </Bands>
                                      <DisplayLayout AllowColSizingDefault="Free" 
                                                     AllowDeleteDefault="Yes"
                                                     AllowSortingDefault="Yes" 
                                                     BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="NotSet" 
                                                    Name="ugrdTaskOwnerList" 
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No"
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
                                                    CellClickActionDefault="RowSelect" 
                                                    TableLayout="Fixed" 
                                                    OptimizeCSSClassNamesOutput="False"
                                                    StationaryMargins="Header" 
                                                    AutoGenerateColumns="False">
                                          <%--<FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="95px"
                                                Width="100%">
                                          </FrameStyle>
                                          <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdResourceList_DblClickHandler" />
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
                                          <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
                                              <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                          </HeaderStyleDefault>
                                          <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                              <Padding Left="3px" />
                                              <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                          </RowStyleDefault>
                                          <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                              <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
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
                                            <ClientSideEvents DblClickHandler="ugrdResourceList_DblClickHandler" />
                                      </DisplayLayout>
                                  </ig:UltraWebGrid>
                                  <asp:Image ID="ibtnTaskOwnerAddRow" runat="server" BorderWidth="0px" ImageUrl="../images/btn/b_005.gif" onclick="openTaskOwner('hdfValue1','hdfValue2','hdfValue3','hdfValue4','hdfValue5');" />
                                  <asp:ImageButton ID="ibtnTaskOwnerDelRow" ImageUrl="../images/btn/b_004.gif" runat="server" OnClick="ibtnTaskOwnerDelRow_Click" /></td>
                                </tr>
                                <tr>
                                  <td colspan="2">
                                    <table  cellpadding="0" cellspacing="2" border="0" style="height:98%; width:100%;">
                                        <tr>
                                            <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                            <td><asp:Label ID="Label3" runat="server" Font-Bold="true" Text="일정공유자"/></td>
                                        </tr>
                                      </table> 
                                  </td>
                                </tr>
                                <tr>
                                  <td colspan="2" align="right" style="height:110px;">
                                  <ig:UltraWebGrid ID="ugrdTaskShareList" runat="server" Width="100%" Height="100%" style="left: 1px; top: 1px"  >
                                      <Bands>
                                          <ig:UltraGridBand>
                                              <Columns>
                                                  <ig:TemplatedColumn Key="selchk" Width="30px">
                                                      <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" onclick="selectChkBox(this, 'ugrdTaskShareList');" />
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
                                                      Format="" HeaderText="성명" Key="EMP_NAME" Width="105px">
                                                      <HeaderStyle HorizontalAlign="Center" />
                                                      <CellStyle HorizontalAlign="Left">
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
                                              
                                          </ig:UltraGridBand>
                                      </Bands>
                                      <DisplayLayout AllowColSizingDefault="Free" 
                                                     AllowDeleteDefault="Yes"
                                                     AllowSortingDefault="Yes" 
                                                     BorderCollapseDefault="Separate"
                                                     HeaderClickActionDefault="NotSet" 
                                                     Name="ugrdTaskShareList" 
                                                     RowHeightDefault="20px"
                                                     RowSelectorsDefault="No" 
                                                     SelectTypeRowDefault="Extended" 
                                                     Version="4.00" 
                                                     CellClickActionDefault="RowSelect" 
                                                     TableLayout="Fixed" 
                                                     StationaryMargins="Header" 
                                                     OptimizeCSSClassNamesOutput="False"
                                                     AutoGenerateColumns="False">
                                          <%--<FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="95px"
                                                Width="100%">
                                          </FrameStyle>
                                          <ClientSideEvents MouseOverHandler="MouseOverHandler" />
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
                                          <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
                                              <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                          </HeaderStyleDefault>
                                          <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                              <Padding Left="3px" />
                                              <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                          </RowStyleDefault>
                                          <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                              <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
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
                                  <asp:Image ID="ibtnTaskShareAddRow" runat="server" BorderWidth="0px" ImageUrl="../images/btn/b_005.gif" onclick="openTaskShare('hdfValue1','hdfValue2','hdfValue3','hdfValue4','hdfValue5');" />
                                      <asp:ImageButton ID="ibtnTaskShareDelRow" ImageUrl="../images/btn/b_004.gif" runat="server" OnClick="ibtnTaskShareDelRow_Click" /></td>
                                </tr>
                              </table>
                          </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="pnlDo">
                                <table  cellpadding="0" cellspacing="2" border="0" style="width:100%;">
                                  <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label4" runat="server" Font-Bold="true" Text="일정실적"/></td>
                                  </tr>
                                </table> 
                                
                                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                      <td class="cssTblTitle">
                                        실행일자
                                      </td>
                                      <td class="cssTblContent">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                          <tr>
                                            <td style="width:10%;">
                                                <ig:WebDateChooser ID="wdcSchActualStartDate" runat="server" NullDateLabel="" Format="Short" Width="90px">
                                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                </ig:WebDateChooser>
                                            </td>
                                            <td style="text-align:center;">~</td>
                                            <td style="width:10%;">
                                                <ig:WebDateChooser ID="wdcSchActualEndDate" runat="server" NullDateLabel="" Format="Short" Width="90px">
                                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                </ig:WebDateChooser>
                                            </td>
                                          </tr>
                                        </table>
                                      </td>
                                    </tr>
                                    <tr>
                                      <td class="cssTblTitle" >
                                        진행율
                                      </td>
                                      <td class="cssTblContent">
                                          <asp:TextBox ID="txtProceedRate" runat="server" Width="120px"></asp:TextBox>%</td>
                                    </tr>
                                    <tr>
                                      <td class="cssTblTitle">
                                        관련파일
                                      </td>
                                      <td class="cssTblContent">
                                          <asp:HiddenField ID="hdfAttachNo" runat="server" />
                                          <asp:DropDownList ID="ddlFileUpload" runat="server" Width="115px">
                                          </asp:DropDownList><a href="#null" onclick="mfUpload('hdfAttachNo');"><img src="../images/icon/icon_gr_po05.gif" align="absMiddle" border="0"/></a><asp:ImageButton
                                              ID="iBtnDownload" runat="server" align="absmiddle" ImageUrl="../images/icon/icon_gr_po04.gif"
                                              OnClick="iBtnDownload_Click" /></td>
                                    </tr>
                                </table>
                              </asp:Panel>
                        </td>
                    </tr>
                   
                </table>
            </td>
          </tr>
          <tr>
              <td colspan="4" class="cssPopBtnLine">
                  <asp:LinkButton ID="linkBtnDraft" runat="server" OnClick="linkBtnDraft_Click" Visible="false"></asp:LinkButton>
                  <asp:ImageButton ID="iBtnDraft" runat="server" ImageUrl="../images/draft/draft.gif" Visible="false" />
                  <asp:ImageButton ID="iBtnReDraft" runat="server" ImageUrl="../images/draft/redraft.gif" Visible="false" />
                  <asp:ImageButton ID="iBtnMoDraft" runat="server" ImageUrl="../images/draft/modraft.gif" Visible="false" />
                  <asp:ImageButton ID="iBtnReWrite" ImageUrl="../images/draft/rewrite.gif" runat="server" Visible="false" />
                  <asp:ImageButton ID="iBtnReqModify" runat="server" ImageUrl="../images/draft/morequest.gif" OnClick="iBtnReqModify_Click" Visible="false" />
                  <asp:ImageButton ID="iBtnAddBrother" runat="server" ImageUrl="../images/btn/b_106.gif" OnClick="iBtnAddBrother_Click" />
                  <asp:ImageButton ID="iBtnAddChild" runat="server" ImageUrl="../images/btn/b_107.gif" OnClick="iBtnAddChild_Click" />
                  <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" OnClick="iBtnUpdate_Click" OnClientClick="return chkUpdate();" />
                  <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/b_004.gif" runat="server" OnClick="iBtnDelete_Click" />
                  <asp:ImageButton ID="iBtnClose" runat="server" Height="19px" ImageUrl="../images/btn/b_003.gif" OnClick="iBtnClose_Click" />
              </td>
         </tr>
        </table>
         

    
    <!--- MAIN END --->
    </form>
</body>
</html>
