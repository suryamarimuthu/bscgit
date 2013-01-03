<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DOC0201S1.aspx.cs" Inherits="_common_Draft_DOC0201S1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    {^0^}
    <div style="text-align:left; width:98%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
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
            <th align="center" style="height: 19px; width:80px;">KPI 코드</th>
            <td style="height: 19px; width:80px;">
                <asp:Label ID="lblKPICode" runat="server" Text="Label"></asp:Label></td>
            <th align="center" style="height: 19px; width:80px;">KPI 명</th>
            <td style="height: 19px">
                <asp:Label ID="lblKPIName" runat="server" Text="Label"></asp:Label></td>
            <th align="center" style="height: 19px; width:80px;">단위</th>
            <td style="height: 19px;width:80px;">
                &nbsp;<asp:Label ID="lblUnitName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th align="center" style="height: 19px;width:80px;">측정유형</th>
            <td style="height: 19px; width:80px;">
                <asp:Label ID="lblRESULT_INPUT_TYPE" runat="server"></asp:Label>
            </td>
            <th align="center" style="width: 80px; height: 19px">누적실적유형</th>
            <td style="height: 19px">
                <asp:Label ID="lblRESULT_TS_CALC_TYPE" runat="server"></asp:Label>
            </td>
            <th align="center" style="height: 19px;width:80px;">KPI 유형</th>
            <td style="height: 19px;">
                <asp:Label ID="lblRESULT_ACHIEVEMENT_TYPE" runat="server"></asp:Label>
                <asp:HiddenField ID="hdfCauseDocNo"   Value="" runat="server" />
                <asp:HiddenField ID="hdfMeasureDocNo" Value="" runat="server" />
                <asp:HiddenField ID="hdfInitiativeDocNo" Value="" runat="server" />
                <asp:HiddenField ID="hdfRESULT_DIFF_FILE_ID" runat="server" Value="" />
                <asp:HiddenField ID="hdfEXPECT_REASON_FILE_ID" runat="server" Value="" />
                <asp:DropDownList ID="ddlScoreGrade" runat="server" Visible="false"></asp:DropDownList>
            </td>
        </tr>
      </table>
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
              실적현황
          </td>
        </tr>
      </table>
      <table>
        <tr>
          <td>
            <asp:GridView ID="grvResult" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCreated="grvResult_RowCreated" OnRowDataBound="grvResult_RowDataBound">
              <Columns>
                  <asp:BoundField HeaderText="목표&lt;BR /&gt;시기" DataField="YMD_DESC">
                      <HeaderStyle Width="80px" />
                      <ItemStyle BackColor="WhiteSmoke" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="계획" DataField="TARGET_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="실적" DataField="RESULT_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="인터페이스실적" DataField="CAL_RESULT_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="달성율" DataField="AC_RATE_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="80px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="계획" DataField="TARGET_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="실적" DataField="RESULT_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="인터페이스실적" DataField="CAL_RESULT_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="달성율" DataField="AC_RATE_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="80px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:TemplateField HeaderText="당" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Image ID="imgSignal_MS" ImageUrl='<%# "../images/"+Eval("SIGNAL_MS") %>' runat="server"/>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="누" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Image ID="imgSignal_TS" ImageUrl='<%# "../images/"+Eval("SIGNAL_TS") %>' runat="server"/>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField HeaderText="SIGNAL_MS" DataField="SIGNAL_MS" HtmlEncode="False" Visible="false" >
                      <HeaderStyle Width="80px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="SIGNAL_TS" DataField="SIGNAL_TS" HtmlEncode="False" Visible="false" >
                      <HeaderStyle Width="80px" />
                      <ItemStyle HorizontalAlign="Right" />
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
              <%=this.GetText("LBL_00005", "PA Report")%>
          </td>
        </tr>
      </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th align="center" rowspan="3" style="width:12%;">구 &nbsp;분</th>
            <th align="center" colspan="2">
                (<asp:Label ID="lblMM_MS" runat="server"></asp:Label>)월 당월실적</th>
            <th align="center" colspan="2">
                (<asp:Label ID="lblMM_TS" runat="server"></asp:Label>)월 누적실적</th>
        </tr>
        <tr>
            <th align="center" style="width: 22%;">적용실적</th>
            <th align="center" style="width: 22%;">인터페이스실적</th>
            <th align="center" style="width: 22%;">적용실적</th>
            <th align="center" style="width: 22%;">인터페이스실적</th>
        </tr>
        <tr>
            <td align="right">
               <asp:Label ID="lblMSResult" runat="server" Width="98%"></asp:Label>
            </td>
            <td align="right">
               <asp:Label ID="lblMsCalcResult" runat="server" Width="98%"></asp:Label>
            </td>
            <td align="right">
               <asp:Label ID="lblTSResult" runat="server" Width="98%"></asp:Label>
            </td>
            <td align="right">
               <asp:Label ID="lblTsCalcResult" runat="server" Width="98%"></asp:Label>
            </td>
        </tr>
        <tr> 
            <th align="center" style="width:80px;">원&nbsp;인&nbsp;분&nbsp;석<br />
                <br />
                <asp:ImageButton ID="imgCauseDocNo" runat="server" ImageUrl="../images/icon/gr_po04.gif" OnClientClick="return mfUpload('hdfCauseDocNo');" />
            </th>
            <td colspan="2" align="center" style="height:80px; text-align:left;">
                <asp:Label ID="lblCAUSE_TEXT_MS" runat="server"></asp:Label></td>
            <td colspan="2" align="center" style="height:80px; text-align:left;">
                <asp:Label ID="lblCAUSE_TEXT_TS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr> 
            <th align="center">대&nbsp;책&nbsp;검&nbsp;토<br />
                <br />
                <asp:ImageButton ID="imgMeasureDocNo" runat="server" ImageUrl="../images/icon/gr_po04.gif" OnClientClick="return mfUpload('hdfMeasureDocNo');" />
            </th>
            <td colspan="2" style="background-color:#ffffff; text-align:left;"> 
                <asp:Label ID="lblMEASURE_TEXT_MS" runat="server"></asp:Label>
            </td>
            <td colspan="2" align="center" style="background-color:#ffffff; text-align:left;">
               <asp:Label ID="lblMEASURE_TEXT_TS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th align="center">인터페이스실적 <br /> 미적용 사유</th>
            <td colspan="4">
              <table style="border-width:0px; width:100%; height:100%;">
                <tr>
                  <td style="border-width:0px; width:20px;"><asp:CheckBox ID="ChkApplyItfsResult" runat="server" Enabled="false" /></td>
                  <td style="border-width:0px;">
                    <asp:Label runat="server" ID="lblNotApplyReason"></asp:Label>
                  </td>
                </tr>
              </table>
            </td>
        </tr>
      </table>
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
              익월실적예측
          </td>
        </tr>
      </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th align="center" style="width:12%;">구 &nbsp;분</th>
            <th align="center">
                (<asp:Label ID="lblNextYmd_Ms" runat="server"></asp:Label>)월 당월예측실적</th>
            <th align="center">
                (<asp:Label ID="lblNextYmd_Ts" runat="server"></asp:Label>)월 누적예측실적</th>
        </tr>
        <tr> 
            <th align="center" style="width:80px;">예&nbsp;상&nbsp;실&nbsp;적<br /></th>
            <td align="center" style="height:20px;">
                <asp:Label ID="lblExtResult_MS" runat="server"></asp:Label></td>
            <td align="center" style="height:20px;">
                <asp:Label ID="lblExtResult_TS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr> 
            <th align="center" style="width:80px;">예&nbsp;상&nbsp;근&nbsp;거<br />
                <br />
                <asp:ImageButton ID="imgEXPECT_REASON_FILE_ID" runat="server" ImageUrl="../images/icon/gr_po04.gif" OnClientClick="return mfUpload('hdfEXPECT_REASON_FILE_ID');" />
            </th>
            <td align="center" style="height:80px; text-align:left;">
                <asp:Label ID="lblEXPECT_REASON_MS" runat="server"></asp:Label></td>
            <td align="center" style="height:80px; text-align:left;">
                <asp:Label ID="lblEXPECT_REASON_TS" runat="server"></asp:Label>
            </td>
        </tr>
      </table>
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
              예측차이분석
          </td>
        </tr>
      </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td colspan="2">
            <asp:GridView ID="grvResultExpt" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCreated="grvResultExpt_RowCreated" OnRowDataBound="grvResultExpt_RowDataBound">
              <Columns>
                  <asp:BoundField HeaderText="구분" DataField="GUBUN">
                      <HeaderStyle Width="80px" />
                      <ItemStyle BackColor="WhiteSmoke" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="계획" DataField="TARGET_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="실적" DataField="RESULT_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="달성율" DataField="AC_RATE_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="80px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="계획" DataField="TARGET_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="실적" DataField="RESULT_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="달성율" DataField="AC_RATE_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                      <HeaderStyle Width="80px" />
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
            <th align="center" style="width:12%;">원&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;인<br /><br />
                <asp:ImageButton ID="imgRESULT_DIFF_FILE_ID" runat="server" ImageUrl="../images/icon/gr_po04.gif" OnClientClick="return mfUpload('hdfRESULT_DIFF_FILE_ID');" />
            </th>
            <td align="center" style="height:80px; text-align:left;">
                <asp:Label ID="lbltxtRESULT_DIFF_CAUSE" runat="server"></asp:Label></td>
        </tr>
      </table>
      <table style="border-width:0px; width:100%;">
        <tr>
          <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
              Initiative
          </td>
        </tr>
      </table>
      <table style="width:100%;">
        <tr>
          <th style="width:10%;">계획월</th>
          <th style="width:45%;">Initiative 추진계획</th>
          <th style="width:45%;">Initiative 추진실적</th>
        </tr>
        <tr>
          <td align="center">
            <asp:Label ID="lblINITIATIVE_MM" runat="server" Height="100%" Width="100%" ></asp:Label><br />
            <asp:ImageButton ID="imgInitiativeFile" runat="server" ImageUrl="../images/icon/gr_po04.gif" OnClientClick="return mfUpload('hdfInitiativeDocNo');" />
          </td>
          <td align="left">
            <asp:Label ID="lblINITIATIVE_PLAN" runat="server" Height="100%" Width="100%" ></asp:Label>
          </td>
          <td align="left">
            <asp:Label ID="lblINITIATIVE_DO" runat="server" Height="100%" Width="100%"></asp:Label>
          </td>
        </tr>
      </table>
    </div>
    {^0^}
    </form>
</body>
</html>
