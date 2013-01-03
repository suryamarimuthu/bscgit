<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DOC0301S1.aspx.cs" Inherits="_common_Draft_DOC0301S1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    {^0^}
    <div style="text-align:left; width:98%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;" align="left">
    <script type="text/javascript" language="javascript">  
    <!--    
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
            var oaArg   = new Array("FILE", "PCAUSE", (oAttach==null ? "" : oAttach.value));
            
            var url = "../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F";
            
            var oReturn = gfOpenDialog(url, oaArg, 485, 307);
            
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
    //-->  
    </script>
    
      <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:left;">
        <tr>
            <th align="center" style="height: 19px; width:100px;"> 사업코드</th>
            <td style="height: 19px; width:200px;">
                &nbsp;<asp:Label ID="lblPRJCode" runat="server"></asp:Label></td>
            <th align="center" style="height: 19px; width:100px;">사업명</th>
            <td style="height: 19px; text-align: left;" colspan="3" align="left">
                &nbsp;<asp:Label ID="lblPRJName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th align="center" style="height: 19px; width:100px;"> 사업정의</th>
            <td style="height: 19px; text-align: left;" colspan="5" align="left">
                &nbsp;<asp:Label ID="lblPRJDefinition" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th align="center" style="height: 19px; width:100px;"> 계획기간</th>
            <td style="height: 19px;">
                &nbsp;<asp:Label ID="lblPlanStartDate" runat="server"></asp:Label> ~
                <asp:Label ID="lblPlanEndDate" runat="server"></asp:Label>
            </td>
            <th align="center" style="height: 19px; width:100px;">실행기간</th>
            <td style="height: 19px;">
                &nbsp;<asp:Label ID="lblActualStartDate" runat="server"></asp:Label> ~
                <asp:Label ID="lblActualEndDate" runat="server"></asp:Label>
             </td>
              <th align="center" style="height: 19px; width:100px;">사업유형</th>
            <td style="height: 19px;width:150px;">
                &nbsp;<asp:Label ID="lblPRJTypeName" runat="server"></asp:Label>
                <asp:HiddenField ID="hdfPrjType" runat="server" />
            </td>
        </tr>
        <tr>
            <th align="center" style="height: 19px; width:100px;"> 주관부서</th>
            <td style="height: 19px;">
                &nbsp;<asp:Label ID="lblOwnerDeptName" runat="server"></asp:Label>
                <asp:HiddenField ID="hdfOwnerDeptID" runat="server" />
            </td>
            <th align="center" style="height: 19px; width:100px;">책임자</th>
            <td style="height: 19px">
                &nbsp;<asp:Label ID="lblOwnerEmpName" runat="server"></asp:Label>
                <asp:HiddenField ID="hdfOwnerEmpID" runat="server" />
             </td>
              <th align="center" style="height: 19px; width:100px;">요청부서(기관)</th>
            <td style="height: 19px; width: 150px;">
                &nbsp;<asp:Label ID="lblRequestDept" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th align="center" style="height: 19px; width:100px;">중요도</th>
            <td style="height: 19px">
                &nbsp;<asp:Label ID="lblPriorityName" runat="server"></asp:Label>
                <asp:HiddenField ID="hdfPriority" runat="server" />
             </td>
             <th align="center" style="height: 19px; width:100px;">총사업비</th>
            <td style="height: 19px; text-align: right;">
                &nbsp;<asp:Label ID="lblTotalBudget" runat="server"></asp:Label>&nbsp;
             </td>
             <th align="center" style="height: 19px; width:100px;">이해관계자</th>
            <td style="height: 19px; width: 150px;">
                &nbsp;<asp:Label ID="lblInterested" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <th align="center" style="height: 19px; width:100px;"> 전략목표</th>
            <td style="height: 19px; text-align: left;" colspan="5">
                &nbsp;<asp:Label ID="lblRefStg" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <th align="center" style="height: 70px; width:100px;"> 기대효과</th>
            <td style="text-align: left; height: 70px;" colspan="6" align="left" valign="top">
                &nbsp;<asp:Label ID="lblEffectiveness" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <th align="center" style="width:100px; height: 70px;"> 사업범위</th>
            <td style="position: static; text-align: left;" colspan="6" align="left" valign="top">
                &nbsp;<asp:Label ID="lblRange" runat="server"></asp:Label></td>
        </tr>
        
        
      </table>
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
              사업공유정보
          </td>
        </tr>
      </table>
      <table style="width: 300px">
        <tr>
          <td align="left">
            <asp:GridView ID="grdProjectShareList" runat="server" AutoGenerateColumns="False" Width="300px" OnRowDataBound="grdProjectShareList_RowDataBound">
              <Columns>
                  <asp:BoundField HeaderText="성명" DataField="EMP_NAME">
                      <HeaderStyle Width="100px" HorizontalAlign="Center"/>
             
                  </asp:BoundField>
                  <asp:BoundField HeaderText="부서명" DataField="DEPT_NAME" HtmlEncode="False" >
                      <HeaderStyle Width="200px" HorizontalAlign="Center" />
                      
                  </asp:BoundField>
              </Columns>
              <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
              <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>     
          </td>
        </tr>
      </table>
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
              사업수행구성원
          </td>
        </tr>
      </table>
      <table style="width: 600px">
        <tr>
          <td>
            <asp:GridView ID="ugrdResourceList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="ugrdResourceList_RowDataBound">
              <Columns>
                  <asp:BoundField HeaderText="성명" DataField="EMP_NAME">
                      <HeaderStyle Width="100px" HorizontalAlign="Center"/>
                  </asp:BoundField>
                  <asp:BoundField DataField="ROLE_TYPE" HeaderText="역할" >
                   <HeaderStyle Width="110px" HorizontalAlign="Center"/>
                  </asp:BoundField>
                  <asp:BoundField HeaderText="전화번호" DataField="DAILY_PHONE" HtmlEncode="False" >
                      <HeaderStyle Width="120px" HorizontalAlign="Center"/>
                  </asp:BoundField>
                  <asp:BoundField DataField="CELL_PHONE" HeaderText="모바일" >
                   <HeaderStyle Width="120px" HorizontalAlign="Center"/>
                  </asp:BoundField>
                  <asp:BoundField DataField="EMP_EMAIL" HeaderText="이메일" >
                   <HeaderStyle Width="150px" HorizontalAlign="Center"/>
                  </asp:BoundField>
              </Columns>
              <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
              <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>     
          </td>
        </tr>
      </table>
      
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
              사업일정
          </td>
        </tr>
      </table>
      <table style="width: 100%">
        <tr>
          <td>
            <asp:GridView ID="grdTaskList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grdTaskList_RowDataBound">
              <Columns>
              <asp:BoundField DataField="PRJ_REF_ID" HeaderText="PRJ_REF_ID" Visible="False" />
                  <asp:BoundField DataField="TASK_REF_ID" HeaderText="TASK_REF_ID" Visible="False" />
                  <asp:BoundField DataField="TASK_CODE" HeaderText="작업코드" />
                  <asp:BoundField DataField="TASK_NAME" HeaderText="작업명" />
                  <asp:BoundField DataField="TASK_TYPE" HeaderText="TASK_TYPE" Visible="False" />
                  <asp:BoundField DataField="TASK_TYPE_NAME" HeaderText="사업유형" />
                  <asp:BoundField DataField="UP_TASK_REF_ID" HeaderText="UP_TASK_REF_ID" Visible="False" />
                  <asp:BoundField DataField="PLAN_START_DATE" HeaderText="시작일자" DataFormatString="{0:yyyy-MM-dd}" />
                  <asp:BoundField DataField="PLAN_END_DATE" HeaderText="종료일자" DataFormatString="{0:yyyy-MM-dd}" />
                  <asp:BoundField DataField="PROCEED_RATE" HeaderText="진행율" DataFormatString="{0:##0.#0}" />
                  <asp:BoundField DataField="TASK_WEIGHT" HeaderText="가중치" DataFormatString="{0:##0.#0}" />
                  <asp:TemplateField HeaderText="첨부파일" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="30px">
                    <ItemTemplate>
                      <asp:ImageButton ID="imgFile" ImageUrl="~/images/icon/icon_gr_po04.gif" Height="16px" runat="server"/>
                      <asp:HiddenField ID="hdfFile" runat="server" Value="" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="ATT_FILE" NullDisplayText="-" HeaderText="첨부파일" Visible="false" />
                 </Columns>
              <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
              <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>     
          </td>
        </tr>
      </table>
      
       <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold; width: 430px;">
           작업수행담당자
          </td>
          <td align="left" style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
           일정공유자
          </td>
        </tr>
      </table>
      <table style="width: 600px">
        <tr>
          <td align="left" valign="top">
          <asp:GridView ID="grdTaskOwnerList" runat="server" AutoGenerateColumns="False" Width="430px" OnRowDataBound="grdProjectShareList_RowDataBound">
              <Columns>
                  <asp:BoundField DataField="TASK_NAME" HeaderText="작업명">
                  <HeaderStyle Width="270px" HorizontalAlign="Left"/>
                    <ItemStyle HorizontalAlign="left" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="성명" DataField="EMP_NAME">
                      <HeaderStyle Width="80px" HorizontalAlign="Center"/>
                  </asp:BoundField>
                  <asp:BoundField HeaderText="부서명" DataField="DEPT_NAME" HtmlEncode="False" >
                      <HeaderStyle Width="80px" HorizontalAlign="Left" />
                  </asp:BoundField>
              </Columns>
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Center" />
          </asp:GridView>
          </td>
          <td align="left" valign="top">
          <asp:GridView ID="grdTaskShareList" runat="server" AutoGenerateColumns="False" Width="430px" OnRowDataBound="grdProjectShareList_RowDataBound">
              <Columns>
                  <asp:BoundField DataField="TASK_NAME" HeaderText="작업명">
                  <HeaderStyle Width="270px" HorizontalAlign="Left"/>
                  </asp:BoundField>
                  <asp:BoundField HeaderText="성명" DataField="EMP_NAME">
                      <HeaderStyle Width="80px" HorizontalAlign="Center"/>
                  </asp:BoundField>
                  <asp:BoundField HeaderText="부서명" DataField="DEPT_NAME" HtmlEncode="False" >
                      <HeaderStyle Width="80px" HorizontalAlign="Left" />
                  </asp:BoundField>
              </Columns>
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Center" />
          </asp:GridView>
          </td>
        </tr>
      </table>
    
      
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold; width: 701px;">
              사업예산(월별)
          </td>
        </tr>
      </table>
      <table style="width: 600px" border=0 cellspacing="0" cellpadding="0">
        <tr>
          <td colspan="4">
            <asp:GridView ID="grdBudgetList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grdBudgetList_RowDataBound">
              <Columns>
                  <asp:BoundField HeaderText="년 월" DataField="BUDGET_YM_NAME">
                     <HeaderStyle Width="100px" HorizontalAlign="Center"/>
                  </asp:BoundField>
                  <asp:BoundField DataField="MONTHLY_AMOUNT" HeaderText="계획예산" DataFormatString="{0:#,##0.##}">
                   <HeaderStyle Width="200px" HorizontalAlign="Center"/>
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="집행내역" DataField="AMOUNT" DataFormatString="{0:#,##0.##}" >
                     <HeaderStyle Width="200px" HorizontalAlign="Center"/>
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField DataField="RATE" HeaderText="집행율(%)" DataFormatString="{0:##0.##}" >
                   <HeaderStyle Width="100px" HorizontalAlign="Center"/>
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
              </Columns>
              <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
              <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>     
          </td>
        </tr>
        <tr>
            <td width="100px" align="right" bgcolor="WhiteSmoke" style="height: 19px">
              합 계
            </td>
            <td width="200px" style="height: 19px; text-align: right" align="right" >
                <asp:Label ID="lblTOTAL_MONTHLY_AMOUNT" runat="server">1</asp:Label></td>
            <td width="200px" style="height: 19px; text-align: right" align="right" >
                <asp:Label ID="lblTOTAL_AMOUNT" runat="server">2</asp:Label></td>
            <td width="100px" style="height: 19px; text-align: right" align="right" >
                <asp:Label ID="lblTOTAL_RATE" runat="server">3</asp:Label></td>
        </tr>
      </table>
      
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
              프로젝트별 지표연계
          </td>
        </tr>
      </table>
      <table style="width: 600px">
        <tr>
          <td>
            <asp:GridView ID="grdKpiPrjList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grdKpiPrjList_RowDataBound">
              <Columns>
                 <asp:BoundField HeaderText="KPI코드" DataField="KPI_CODE">
                     <HeaderStyle Width="100px" HorizontalAlign="Center"/>
                  </asp:BoundField>
                  <asp:BoundField DataField="KPI_NAME" HeaderText="KPI 명" DataFormatString="{0:#,##0.##}">
                   <HeaderStyle Width="500px" HorizontalAlign="Center"/>
                      <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
              </Columns>
              <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
              <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>     
          </td>
        </tr>
      </table>
      
    </div>
    {^0^}
    </form>
</body>
</html>
