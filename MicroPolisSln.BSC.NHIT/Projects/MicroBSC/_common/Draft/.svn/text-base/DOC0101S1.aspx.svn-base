<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DOC0101S1.aspx.cs" Inherits="_common_Draft_DOC0101S1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   {^0^}
   <div style="text-align:center; width:98%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
       <script type="text/javascript" language="javascript">  
    <!--    
    function mfUpload(hAttachNo, strUpDown)
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
        var oaArg   = new Array("FILE", "KPIREA", (oAttach==null ? "" : oAttach.value));
        
        var oReturn = "";
        if (strUpDown == "UP")
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=T", oaArg, 485, 307);
        }
        else
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F", oaArg, 485, 307);
        }
        
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
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:center;">
          <tr>
            <th style="text-align:left; font-weight:bold;">
              Part Ⅰ KPI 정의
            </th>
          </tr>
          <tr>
            <td style="text-align:left;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                    <th style="width:12%;">
                      KPI 코드
                    </th>
                    <td style="width:16%;">
                      <asp:Label ID="lblKpiCode" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                    <th style="width:12%;">
                      KPI 명
                    </th>
                    <td style="width:60%;">
                      <asp:Label ID="lblKpiName" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                  </tr>
                  <tr>
                    <th>
                      KPI 유형
                    </th>
                    <td>
                      <asp:Label ID="lblKpiType" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                    <th>
                      지표분류
                    </th>
                    <td>
                      <asp:Label ID="lblKpiClass" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                  </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <th align="center" style="height: 20px; width:12%;">챔&nbsp;&nbsp;피&nbsp;&nbsp;언</th>
                        <td style="height: 20px">
                           <asp:Label ID="lblChampionEmpName" runat="server" Width="98%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" style="width:12%;">지&nbsp;&nbsp;표&nbsp;&nbsp;및&nbsp;<br />용&nbsp;어&nbsp;정&nbsp;의</th>
                        <td align="left">
                          <asp:Label ID="lblWordDefinition" runat="server" Width="98%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" style="width:12%;">
                            당&nbsp;월&nbsp;산&nbsp;식</th>
                        <td>
                          <asp:Label ID="lblCalcFormMs" runat="server" Width="98%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" style="width:12%;">누&nbsp;계&nbsp;산&nbsp;식</th>
                        <td>
                           <asp:Label ID="lblCalcFormTs" runat="server" Width="98%"></asp:Label>
                           <asp:Label ID="lblMeasurementPurpose" runat="server" Width="98%" Visible="false"></asp:Label>
                           <asp:Label ID="lblRelatedIssue" runat="server" Width="98%" Visible="false"></asp:Label>
                        </td>
                    </tr>
<%--		                        <tr>
                        <td class="tableTitle" align="center" width="100">용&nbsp;어&nbsp;정&nbsp;의</td>
                        <td class="tableContent" colspan="3">
                        </td>
                    </tr>--%>
<%--		                        <tr>
                        <td class="tableTitle" align="center" width="100">관&nbsp;련&nbsp;이&nbsp;슈</td>
                        <td class="tableContent" colspan="3"></td>
                    </tr>
                    <tr>
                        <td class="tableTitle" align="center" width="100">KPI 정의서&nbsp;</td>
                        <td class="tableContent" colspan="3"></td>
                    </tr>--%>
                </table>
            </td>
          </tr>
          <tr>
            <th style="text-align:left; font-weight:bold;">
              Part Ⅱ KPI 측정
            </th>
          </tr>
          <tr>
            <td style="text-align:left;">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <th align="center" style="height: 20px; width:12%;">측정조직담당자</th>
                        <td style="height: 20px;">
                            <asp:Label ID="lblMeasurementEmpName" runat="server" Width="100%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" style="height: 20px;">측&nbsp;정&nbsp;유&nbsp;형</th>
                        <td style="height: 20px">
                            <asp:Label ID="lblResultInputType" runat="server" Width="98%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" style="width:12%;">데이터집계방법</th>
                        <td style="height: 20px">
                          <asp:Label ID="lblDataGetheringMethod" runat="server" Width="98%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" style="width:12%;">데이터상세정의</th>
                        <td style="vertical-align:top; text-align:left;">
                            <asp:GridView ID="grvDataSource" runat="server" AutoGenerateColumns="false" Width="100%">
                              <Columns>
                                <asp:BoundField HeaderText="Level1" DataField="LEVEL1"><ItemStyle CssClass="tdAlignLeft" /></asp:BoundField>
                                <asp:BoundField HeaderText="Level2" DataField="LEVEL2" />
                                <asp:BoundField HeaderText="Level3" DataField="LEVEL3" />
                                <asp:BoundField HeaderText="실적데이터원천" DataField="RESULT_SOURCE" />
                                <asp:BoundField HeaderText="실적생성시기" DataField="RESULT_CREATE_TIME" />
                                <asp:BoundField HeaderText="데이터원천" DataField="TARGET_SOURCE" />
                                <asp:BoundField HeaderText="단위" DataField="UNIT" />
                              </Columns>
                              <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
                              <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                  </table>
            </td>
          </tr>
          <tr>
            <th style="text-align:left; font-weight:bold;">
              Part Ⅲ KPI 계획 및 평가
            </th>
          </tr>
          <tr>
            <td style="text-align:left;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                    <th style="width:20%;">
                      KPI 유형
                    </th>
                    <th style="width:20%;">
                      누적실적유형
                    </th>
                    <th style="width:20%;">
                      구간산정방법
                    </th>
                    <th style="width:20%;">
                      단위
                    </th>
                    <th style="width:20%;">
                      <%=this.GetText("LBL_00003", "평가단계") %>
                    </th>
                  </tr>
                  <tr>
                    <td>
                      <asp:Label ID="lblResultAchievementType" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                    <td>
                      <asp:Label ID="lblResultTsCalcType" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                    <td>
                      <asp:Label ID="lblMeasurementGradeType" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                    <td>
                      <asp:Label ID="lblUnit" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                    <td>
                      <asp:Label ID="lblResultMeasurementStep" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="3" style="vertical-align:top; text-align:left;">
                        <asp:GridView ID="grvTarget" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCreated="grvTarget_RowCreated" OnRowDataBound="grvTarget_RowDataBound">
                          <Columns>
                              <asp:BoundField HeaderText="목표&lt;BR /&gt;시기" DataField="YMD_DESC">
                                  <HeaderStyle Width="80px" />
                                  <ItemStyle BackColor="WhiteSmoke" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="당월" DataField="MS_PLAN" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="누계" DataField="TS_PLAN" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="당월" DataField="MM_PLAN" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="누계" DataField="TM_PLAN" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="마감여부" DataField="MONTHLY_CLOSE_YN">
                                  <HeaderStyle Width="40px" />
                                  <ItemStyle BackColor="WhiteSmoke" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="MOD_CHECK_YN" DataField="ORI_CHECK_YN" Visible="true">
                                  <HeaderStyle Width="0px" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="MOD_CHECK_YN" DataField="MOD_CHECK_YN" Visible="true">
                                  <HeaderStyle Width="0px" />
                              </asp:BoundField>
                          </Columns>
                          <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
                          <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:GridView>                        
                    </td>
                    <td colspan="2" style="vertical-align:top;">
                      <asp:GridView ID="grvSignal" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCreated="grvSignal_RowCreated" OnRowDataBound="grvSignal_RowDataBound">
                        <Columns>
                          <asp:BoundField HeaderText="상태" DataField="SIGNAL" />
                          <asp:TemplateField HeaderText="신호">
                            <ItemTemplate>
                              <asp:Image ID="imgSignal" ImageUrl='<%# "../images/"+Eval("IMAG_PATH") %>' runat="server"/>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField HeaderText="구간" DataField="THRS_DESC" />
                          <asp:BoundField HeaderText="계획" DataField="SET_MIN_VALUE" DataFormatString="{0:#,##0.###}" HtmlEncode="False" />
                          <asp:BoundField HeaderText="달성율" DataField="ACHIEVE_RATE" DataFormatString="{0:#,##0.##}" HtmlEncode="False" />
                          <asp:BoundField HeaderText="점수" DataField="POINT" DataFormatString="{0:#,##0.##}" HtmlEncode="False" />
                        </Columns>
                      </asp:GridView>
                      <asp:Image ID="imgChart" ImageUrl="" runat="server" />
                      <DCWC:Chart ID="chartScore" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Height="150px" Width="350px" Visible="false" >
                        <ChartAreas>
                            <DCWC:ChartArea BackColor="White" BackGradientEndColor="White" BorderColor="196, 196, 196"
                                Name="Default" ShadowColor="Transparent">
                                <AxisX LabelsAutoFit="False" LineColor="196, 196, 196" Interval="1">
                                    <LabelStyle Font="Tahoma, 9px" />
                                    <MajorGrid LineColor="196, 196, 196" />
                                </AxisX>
                                 <Area3DStyle WallWidth="2" YAngle="10" />
                                <AxisY LineColor="196, 196, 196" LabelsAutoFit="False">
                                    <LabelStyle Font="Tahoma, 9px" />
                                    <MajorGrid LineColor="196, 196, 196" />
                                </AxisY>
                            </DCWC:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                Enabled="False" LegendStyle="Row" Name="Default" ShadowOffset="2">
                            </DCWC:Legend>
                        </Legends>
                      </DCWC:Chart>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        목표 및 등급구간 설정근거<br />
                        <asp:ImageButton ID="iBtnTargetFile_Down" ImageUrl="~/images/icon/gr_po04.gif" runat="server" ImageAlign="AbsMiddle" OnClientClick="return mfUpload('hdfTargetReasonFile','DOWN')" />
                    </th>
                    <td colspan="4" align="left">                      
                      <asp:Label ID="lblTargetReason" Text="" runat="server" Width="98%"></asp:Label>
                    </td>
                  </tr>
                </table>
            </td>
          </tr>
          <tr>
            <th style="text-align:left; font-weight:bold;">
              Part Ⅲ KPI Initiative관리
            </th>
          </tr>
          <tr>
            <td style="text-align:left; vertical-align:top;">
                  <asp:GridView ID="grvInitiative" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grvInitiative_RowDataBound">
                    <Columns>
                      <asp:BoundField HeaderText="년월" DataField="YMD_DESC" HeaderStyle-Width="100px" /> 
                      <asp:BoundField HeaderText="추진계획" DataField="INITIATIVE_PLAN" ItemStyle-Wrap="true" />
                      <asp:BoundField HeaderText="측정여부" DataField="CHECK_YN" HeaderStyle-Width="50px" Visible="true" />
                    </Columns>
                  </asp:GridView>
            </td>
          </tr>
        </table>
        <asp:HiddenField ID = "hdfTargetReasonFile" runat="server" Value="" />
    </div>
   {^0^}
    </form>
</body>
</html>
