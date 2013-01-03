<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0102M1.aspx.cs" Inherits="PRJ_PRJ0102M1" %>
<html>
	<head>
		<title>BSC</title>
		<meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script language="jscript" type="text/javascript">
    
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
    function processKeyPress() 
        { 
            if (event.keyCode == 13) 
            { 
            self.focus(); 
            return false; 
            } 
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
      
        var ICCB3           = "<%= this.ICCB3 %>";

        var url             = "PRJ0103S1.aspx?STR_VAR1="+ strVal1 + "&STR_VAR2=" + strVal2 + "&STR_VAR3="+ strVal3 + "&STR_VAR4=" + strVal4 + "&STR_VAR5="+ strVal5 + "&TYPE=O&CCB2="+ICCB3;
        
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

    function OpenMailWindow() {
        var sURL = "../BSC/BSC9001M1.aspx";
        var objPrjName = document.getElementById("<%=txtPrjName.UniqueID %>");
        var objTskName = document.getElementById("<%=txtTaskName.UniqueID %>");

        var sPrjName = "<%=txtPrjName.Text %>";
        var sTskName = "<%=txtTaskName.Text %>";
        var sPrjId   = "<%=this.IPrjRefID %>"

        //sURL = sURL + "?TITLE=" + sPrjName + "/" + sTskName;
        sURL = sURL + "?KEY=" + sPrjId;
        
        gfOpenWindow(sURL, 780, 600, 'yes', 'no', 'BSC9001M1');
        return false;
    }

</script>

 <script language="javascript" type="text/javascript">
    // <!CDATA[
    function mfUpload(hAttachNo)
    {
        <%
        /*
            Argument설명
                : ICM_FILE / ICM_PROCFILE 어느쪽에 셋팅하는가? (FILE / PROCFILE)
                : 파일첨부시 어떤 프로젝트 소속인가? 해당폴더및 ATTACHNO추출시 접두어로 사용됨 (ICM, DCM, ....)
        */
        %>
        //수정(20060707 이승주)
        //var oAttach = gfGetFindObj("hAttachNo");
        var oAttach = gfGetFindObj(hAttachNo);
        var oaArg   = new Array("FILE", "PRJ_File", (oAttach==null ? "" : oAttach.value));
        
        var oReturn = gfOpenDialog("../base/FileUploadMain.aspx", oaArg, 485, 307);
        
       
        
        if (oReturn != "" && oReturn != undefined)
        {
            oAttach.value = oReturn;
            //__doPostBack('lBtnReload', '');
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
	<body class="FormBackground"  style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" >
		<form id="Form1" method="post" runat="server">
		<table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40">
					            <!-- 타이틀시작 -->
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr> 
                                                    <td height="40" valign="top"><img src="../images/title/popup_t77.gif" ></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td width="50%" height="4" bgcolor="#FFFFFF"></td>
                                                    <td width="50%" bgcolor="#FFFFFF"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!-- 타이틀끝 -->
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="box_td03">
		
			        <table style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; TOP: 0px; HEIGHT: 100%" cellSpacing="0" cellPadding="0">
				<tr class="cssPopContent">
					<td valign="top">
					 <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="cssTblTitle" align="left" style="width:117px; height: 22px">
                                사업명
                            </td>
                            <td class="cssTblcontent" style="height: 22px; width: 286px;">
                              <asp:TextBox ID="txtPrjName" runat="server" BorderWidth="0" BackColor="whitesmoke" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="cssTblTitle" align="left" style="width:120px; height: 22px">
                                프로젝트기간</td>
	                        <td class="cssTblContent" valign="middle" style="height: 22px; width: 213px;">
                                <asp:TextBox ID="txtPrjPeriod" runat="server" Width="200px" BorderWidth="0" BackColor="whitesmoke" ReadOnly="True"></asp:TextBox>
                             </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" align="left" style="width:117px; height: 22px">
                                작업코드
                            </td>
                            <td class="cssTblContent" style="height: 22px; width: 286px;">
                              <asp:TextBox ID="txtTaskCode" runat="server" BorderWidth="0" BackColor="WhiteSmoke" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="cssTblTitle" align="left" style="width:120px; height: 22px">
                                작업명</td>
	                        <td class="cssTblContent" valign="middle" style="height: 22px; width: 213px;">
                                <asp:TextBox ID="txtTaskName" runat="server" Width="200px" BorderWidth="0" BackColor="whitesmoke" ReadOnly="True"></asp:TextBox>
                             </td>
                        </tr>
                        <tr>
                            <td  class="cssTblTitle" align="left" style="width:117px; height: 22px">
                                상위작업명
                            </td>
                            <td class="cssTblContent" style="height: 22px; width: 286px;">
                              <asp:TextBox ID="txtUpTaskName" runat="server" BorderWidth="0" BackColor="whitesmoke" Width="300px" ReadOnly="True"></asp:TextBox><asp:HiddenField ID="hdfUpTaskRefID" runat="server" />
                            </td>
                            <td class="cssTblTitle" align="left" style="width:120px; height: 22px">
                                작업유형</td>
	                        <td class="cssTblContent" valign="top" style="height: 22px; width: 213px;">
                                <asp:DropDownList ID="ddlTaskType" runat="server" class="box01" Enabled="False" Width="115px">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdfAttachNo" runat="server" /></td>
                           
                        </tr>
                        <tr>
                            <td class="cssTblTitle" align="left" style="width:117px; height: 22px">
                                계획시작일자
                            </td>
                            <td class="cssTblContent" style="height: 22px; width: 286px;" align="left" valign="top">
                                <ig:WebDateChooser ID="wdcSchPlanStartDate" runat="server" Format="Short" NullDateLabel="" BackColor="WhiteSmoke" ReadOnly="True">
                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False">
                                    </CalendarLayout>
                                </ig:WebDateChooser>
                            </td>
                            <td class="cssTblTitle" align="left" style="width:120px; height: 22px">
                                계획종료일자</td>
	                        <td class="cssTblContent" valign="top" style="height: 22px; width: 213px;" align="left">
                                <ig:WebDateChooser ID="wdcSchPlanEndDate" runat="server" Format="Short" NullDateLabel="" BackColor="WhiteSmoke" ReadOnly="True">
                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False">
                                    </CalendarLayout>
                                </ig:WebDateChooser>
                             </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle" align="left" style="width:117px; height: 22px">
                                실행시작일자
                            </td>
                            <td class="cssTblContent" style="height: 22px; width: 286px;" align="left" valign="top">
                                <ig:WebDateChooser ID="wdcSchActualStartDate" runat="server" Format="Short" NullDateLabel="">
                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False">
                                    </CalendarLayout>
                                </ig:WebDateChooser>
                            </td>
                            <td class="cssTblTitle" align="left" style="width:120px; height: 22px">
                                실행종료일자</td>
	                        <td class="cssTblContent" valign="top" style="height: 22px; width: 213px;" align="left">
                                <ig:WebDateChooser ID="wdcSchActualEndDate" runat="server" Format="Short" NullDateLabel="">
                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False">
                                    </CalendarLayout>
                                </ig:WebDateChooser>
                             </td>
                        </tr>
                         <tr>
                            <td class="cssTblTitle" align="left" style="width:117px; height: 22px">
                               진행율
                            </td>
                            <td class="cssTblContent" style="height: 22px; width: 286px;" valign="top" align="right">
                              <asp:TextBox ID="txtProceedRate" runat="server" BorderWidth="1px" BackColor="Transparent" Width="270px"></asp:TextBox>%
                            </td>
                            <td class="cssTblTitle" align="left" style="width:120px; height: 22px">
                                첨부파일</td>
	                        <td class="cssTblContent" valign="top" style="height: 22px; width: 213px;">
                                <asp:DropDownList ID="ddlFileUpload" runat="server" Width="151px" CssClass="box01">
                                </asp:DropDownList><a href="#null" onclick="mfUpload('hdfAttachNo');"><img src="../images/icon/icon_gr_po05.gif" align="absmiddle" border="0"/></a><asp:ImageButton
                                    ID="iBtnDownload" runat="server" align="absmiddle" ImageUrl="../images/icon/icon_gr_po04.gif"
                                    OnClick="iBtnDownload_Click" /></td>
                        </tr>
                          <tr>
                            <td class="cssTblTitle" align="left" style="width:117px; height: 250px" valign="top">
                                작업수행<br />
                                담당자
                            </td>
                            <td class="cssTblContent" style="height: 250px; width: 286px;" align="left" valign="top">
                                <ig:UltraWebGrid ID="ugrdTaskOwnerList" runat="server" Width="280px" Height="98%" style="left: 0px" >
                                          <Bands>
                                              <ig:UltraGridBand>
                                                  <Columns>
                                                      <ig:TemplatedColumn Hidden="True" Key="selchk" Width="30px">
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
                                                          Format="" HeaderText="성명" Key="EMP_NAME" Width="80px">
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
                                                          Width="170px">
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
                                          <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                                                AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="NotSet" Name="ugrdTaskOwnerList" RowHeightDefault="20px"
                                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                              <%--<FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="98%"
                                                    Width="280px">
                                              </FrameStyle>--%>
                                              
                                              <%--<Pager>
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
                                              <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdResourceList_DblClickHandler" />
                                              
                                              <RowStyleDefault  CssClass="GridRowStyle" />
                                              <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                              <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                              <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                              <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                              <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                          </DisplayLayout>
                                      </ig:UltraWebGrid></td>
                                 
                            <td class="cssTblTitle" align="left" style="width:120px; height: 250px" valign="top">
                                작업정보</td>
	                        <td class="cssTblContent" valign="top" style="height: 250px; width: 213px;" align="left">
                                <asp:TextBox ID="txtDesction" runat="server" Height="98%" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                &nbsp;
                                </td>
                                
                        </tr>
                         
                          <tr>
                          <td colspan="4" style="height:34px;" align="right" valign="middle">&nbsp;&nbsp;
                              <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" OnClick="iBtnUpdate_Click" />
                              <asp:ImageButton ID="iBtnSendMail" ImageUrl="../images/btn/b_051.gif" runat="server" OnClientClick="return OpenMailWindow();" />
                              <asp:ImageButton ID="iBtnClose" runat="server" Height="19px" ImageUrl="../images/btn/b_003.gif" OnClick="iBtnClose_Click" />&nbsp;
                          </td>
                        </tr>
                       </table>
                        <asp:HiddenField ID="hdfTaskRefID" runat="server" />
                        <asp:HiddenField ID="hdfNodeDepth" runat="server" />
                        <asp:HiddenField ID="hdfValue1" runat="server" />
                        <asp:HiddenField ID="hdfValue2" runat="server" />
                        <asp:HiddenField ID="hdfValue3" runat="server" />
                        <asp:HiddenField ID="hdfValue4" runat="server" />
                        <asp:HiddenField ID="hdfValue5" runat="server" />
						</td>
				</tr>
				
			</table>
			        <asp:linkbutton id="lBtnTaskOwnerAddRow" runat="server" OnClick="lBtnTaskOwnerAddRow_Click"></asp:linkbutton>
                    <asp:linkbutton id="lBtnTaskShareAddRow" runat="server" OnClick="lBtnTaskShareAddRow_Click"></asp:linkbutton>
			        <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
			
			
			    </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>      
		</form>


	</body>
</html>