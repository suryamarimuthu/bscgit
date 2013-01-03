<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST_Q_PAGE_02.aspx.cs" Inherits="EST_EST_Q_PAGE_02" %>
<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <style type="text/css">
            .page_ddldisplay
            {
            	display: none;
            }
        </style>
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
        <script type="text/javascript">
            function CheckAgree() 
            {
                if(confirm('평가질의에 동의하십니까?')) 
                {
                    if(document.getElementById('txtFeedbackComment').value == '') 
                    {
                        alert('평가자에 대한 피드백을 등록하세요.');
                        document.getElementById('txtFeedbackComment').focus();
                        return false;
                    }
                    
                    return true;
                }
                
                return false;
            }
            
            function CheckReject() 
            {
                if(confirm('평가질의에 거절하십니까?')) 
                {
                    if(document.getElementById('txtFeedbackComment').value == '') 
                    {
                        alert('평가자에 대한 거절 이유 및 기타의견을 등록하세요.');
                        document.getElementById('txtFeedbackComment').focus();
                        return false;
                    }

                    return true;
                }

                return false;
            }
            function pageOnLoad() {
                document.getElementById('tableMain1').style.height = document.body.clientHeight;
            }
            function showHidePreviousStep() {
                if (document.getElementById('tdPreviousStep').style.display == "block") {
                    document.getElementById('tdPreviousStep').style.display = "none";
                    document.getElementById('ddlStep').style.display = "none";
                }
                else {
                    document.getElementById('tdPreviousStep').style.display = "block";
                    document.getElementById('ddlStep').style.display = "block";
                }
            }

            function doRejection() {
                return confirm("평가거부 하시겠습니까?");
            }
        </script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="pageOnLoad(); document.focus();">

<form id="form1" runat="server">
<!--- MAIN START --->
    <table id="tableMain1" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height: 40px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr> 
                                    <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr> 
                                                <td height="40" valign="top"><img src="../images/title/popup_t74.gif"></td>
                                                <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr> 
                                                <td width="50%" height="4" bgcolor="FFFFFF"></td>
                                                <td width="50%" bgcolor="FFFFFF"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr valign="top">
            <td>
                <div id="divPreviousControl" runat="server" style="height: 19px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 19px;">
                        <tr>
                            <td style="height: 19px;">
                                <img id="imgPreviousControl" src="../images/etc/imgPreviousStep.jpg" alt="이전차수 평가정보" width="120px" height="19px" style="cursor: pointer;" onclick="showHidePreviousStep()" />
                            </td>
                            <td valign="top" style="padding-top: 1px; padding-left: 5px;">
                                <asp:DropDownList ID="ddlStep" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlStep_SelectedIndexChanged" CssClass="box01 page_ddldisplay"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        
        <tr class="cssPopContent">
            <td id="tdPreviousStep" style="height: 180px; display: none; border-bottom: 5px solid Gray; padding-top: 6px; overflow: scroll;">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <span id="span1" style="overflow: auto; height: 180px; width: 100%;">
                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                            <tr> 
                                <td  class="cssTblTitle" >&nbsp;평가기간</td>
                                <td class="cssTblContent" >&nbsp;<%= ESTTERM_REF_NAME%>&nbsp;<%= ESTTERM_SUB_NAME%>&nbsp;<%= ESTTERM_STEP_NAME_P%></td>
                                <td  class="cssTblTitle" >&nbsp;평가명</td>
                                <td class="cssTblContent"  width="20%">&nbsp;<%= EST_NAME%></td>
                            </tr>
                            <tr> 
                                <td  class="cssTblTitle">&nbsp;부서 / 평가자</td>
                                <td class="cssTblContent" >&nbsp;<%= EST_DEPT_NAME_P %>&nbsp;/&nbsp;<%= EST_EMP_NAME_P%></td>
                                <td  class="cssTblTitle">&nbsp;피부서 / 피평가자</td>
                                <td class="cssTblContent" >&nbsp;<%= TGT_DEPT_NAME%>&nbsp;/&nbsp;<%= TGT_EMP_NAME%></td>
                            </tr>
                            <tr> 
                                <td  class="cssTblTitle">&nbsp;질의평가그룹</td>
                                <td class="cssTblContent" >&nbsp;<%= Q_OBJ_NAME%></td>
                                <td  class="cssTblTitle">&nbsp;평가점수 / 총 배점</td>
                                <td class="cssTblContent" >&nbsp;<asp:Literal ID="ltrTotalPoint_P" runat="server"></asp:Literal><span id="sumpoint_P"></span></td>
                            </tr>
                        </table>
                        <!-- 정의가 할당된 질의문 반복  시작-->
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" class="tableBorder">
                            <tr>
                                <td>
                                    <asp:DataList ID="DataList4" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList4_ItemDataBound" DataKeyField="Q_DFN_ID" Width="100%">
                                        <ItemTemplate>
                                          <br/>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                <tr >
                                                    <td>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tr> 
                                                                        <td class="tableBorder">
                                                                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                                                <tr> 
                                                                                    <td height="28"width="80px" align="center"  class="cssTblTitle"> 평가요소&nbsp;</td>
                                                                                    <td height="28" align="center"  class="cssTblTitle"> 평가요소 정의 &nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                      <td class="cssTblContent" align="center">&nbsp;<asp:Literal ID="ltrLevelDefName_P" runat="server"></asp:Literal></td>
                                                                                       <td class="cssTblContent"  align="left"> &nbsp;<asp:Literal ID="ltrLevelDefine_P" runat="server"></asp:Literal></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr class="tableBorder">
                                                            <td>
                                                               <asp:DataList ID="DataList6" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList6_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                                                    <ItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0"  width="100%"  align="center">
                                                                            <tr valign="top">
                                                                                <td class="tableBorder">
                                                                                       <table cellpadding="0" cellspacing="0" border="0"  width="100%">
                                                                                                <tr>
                                                                                                     <td height="22" align="left" class="cssTblContent"><strong><asp:Label id="lblSortID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUM") %>'/>.<asp:Label id="lblSubjectName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Q_SBJ_NAME") %>'/> <asp:Literal ID="ltrPoint" runat="server"></asp:Literal></strong>
                                                                                                     </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="tableBorder">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                                                                            <tr>
                                                                                                                <td  class="cssTblTitleSingle">정 의</td>
                                                                                                                <td  class="cssTblContent">
                                                                                                                    &nbsp;<asp:Literal ID="ltrLevelDefine" runat="server"></asp:Literal>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td  class="cssTblTitleSingle">설 명</td>
                                                                                                                <td  class="cssTblContent">
                                                                                                                     &nbsp;<asp:Literal ID="ltrLevelDesc" runat="server"></asp:Literal>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr valign="top">
                                                                                                    <td class="cssTblContent">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                                        <tr>
                                                                                                            <td width="14" id="tdLeft" runat="server"><img src="../images/bar_gray1.gif" width="14" height="41"></td>
                                                                                                            <td height="41" align="center" background="../images/bg_gray.gif" id="tdCenter" runat="server">
                                                                                                                <asp:Label runat="server" ID="lblEstText" ForeColor="#996600" Font-Bold="True"></asp:Label><strong>
                                                                                                                <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                                                                                <asp:RadioButtonList ID="rBtnList" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList>
                                                                                                                </strong>
                                                                                                            </td>
                                                                                                            <td width="17" align="right" id="tdRight" runat="server"><img src="../images/bar_gray2.gif" width="17" height="41"></td>
                                                                                                        </tr>
                                                                                                        <tr id="trTextValue" runat="server" visible="false">
                                                                                                            <td colspan="3">
                                                                                                                <img src="../images/title/ta_t38.gif" border="0" />
                                                                                                                <asp:TextBox ID="txtLevelValue" runat="server" TextMode="MultiLine" Height="60" Width="100%"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        </table>
                                                                                                          <div align="center"><b><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList"
                                                                                                                    ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></b></div> 
                                                                                                    </td>
                                                                                                </tr>
                                                                                       </table>
                                                                                </td>
                                                                             </tr>  
                                                                         </table> 
                                                                  </ItemTemplate>
                                                               </asp:DataList>	
                                                            </td>
                                                        </tr>
                                                    </td>
                                                </tr>
                                             </table> 
                                       </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                        <!-- 정의가 할당된 질의문 반복 끝--> 
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td>
                                            <!-- 정의가 할당되지 않은 질의문 반복  시작-->
                                                <asp:DataList ID="DataList5" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList5_ItemDataBound" DataKeyField="Q_SBJ_ID">
                                                    <ItemTemplate>
                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr> 
                                                                <td> 
                                                                     <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr valign="top"> 
                                                                            <td> 
                                                                                <table cellpadding="0" cellspacing="0" border="0"  width="100%">
                                                                                    <tr>
                                                                                        <td height="22" align="left" ><strong><asp:Label id="lblSortID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUM") %>'/>.<asp:Label id="lblSubjectName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Q_SBJ_NAME") %>'/> <asp:Literal ID="ltrPoint" runat="server"></asp:Literal></strong>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                <tr>
                                                                                    <td class="tableBorder">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" class="" width="100%">
                                                                                            <tr>
                                                                                                <td  class="cssTblTitleSingle">정 의</td>
                                                                                                <td  class="cssTblContent">
                                                                                                    &nbsp;<asp:Literal ID="ltrLevelDefine" runat="server"></asp:Literal>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td  class="cssTblTitleSingle">설 명</td>
                                                                                                <td  class="cssTblContent">
                                                                                                     &nbsp;<asp:Literal ID="ltrLevelDesc" runat="server"></asp:Literal>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                           </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                     <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr valign="top">
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="14" id="tdLeft" runat="server"><img src="../images/bar_gray1.gif" width="14" height="41"></td>
                                                                                        <td height="41" width="100%" align="center" background="../images/bg_gray.gif"  id="tdCenter" runat="server">
                                                                                            <asp:Label runat="server" ID="lblEstText" ForeColor="#996600" Font-Bold="True"></asp:Label><strong>
                                                                                            <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>
                                                                                            <asp:RadioButtonList ID="rBtnList" runat="server" Enabled="false" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                                            </asp:RadioButtonList>
                                                                                            </strong>
                                                                                        </td>
                                                                                        <td width="17" align="right" id="tdRight" runat="server"><img src="../images/bar_gray2.gif" width="17" height="41"></td>
                                                                                    </tr>
                                                                                    <tr id="trTextValue" runat="server" visible="false">
                                                                                        <td colspan="3">
                                                                                            <img src="../images/title/ta_t38.gif" border="0" />
                                                                                            <asp:TextBox ID="txtLevelValue" runat="server" TextMode="MultiLine" Height="60" Width="100%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                  <div align="center"><b><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList"
                                                                                            ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></b></div> 
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>	
                                                  </ItemTemplate>
                                                  </asp:DataList></td>
                                                <!-- 정의가 할당되지 않은 질의문 반복 끝-->  
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </span>
                </ContentTemplate>
                <Triggers><asp:AsyncPostBackTrigger ControlID="ddlStep" /></Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr class="cssPopContent" valign="top">
            <td style="height: 100%; padding-top: 5px;">
                <div style="height: 100%; overflow: auto;">
                    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                        <tr> 
                            <td  class="cssTblTitle" style="width:20%;">평가기간</td>
                            <td class="cssTblContent" style="width:30%;"><%= ESTTERM_REF_NAME%>&nbsp;<%= ESTTERM_SUB_NAME%>&nbsp;<%= ESTTERM_STEP_NAME%></td>
                            <td  class="cssTblTitle" style="width:20%;">평가명</td>
                            <td class="cssTblContent" style="width:30%;"><%= EST_NAME%></td>
                        </tr>
                        <tr> 
                            <td  class="cssTblTitle">부서 / 평가자</td>
                            <td class="cssTblContent" ><%= EST_DEPT_NAME %>&nbsp;/&nbsp;<%= EST_EMP_NAME%></td>
                            <td  class="cssTblTitle">피부서 / 피평가자</td>
                            <td class="cssTblContent" ><%= TGT_DEPT_NAME%>&nbsp;/&nbsp;<%= TGT_EMP_NAME%></td>
                        </tr>
                        <tr> 
                            <td  class="cssTblTitle">질의평가그룹</td>
                            <td class="cssTblContent" ><%= Q_OBJ_NAME%></td>
                            <td  class="cssTblTitle">평가점수 / 총 배점</td>
                            <td class="cssTblContent" ><asp:Literal ID="ltrTotalPoint" runat="server"></asp:Literal><span id="sumpoint"></span></td>
                        </tr>
                        <tr runat="server" id="trViewComment" >
                            <td  class="cssTblTitle">피평가자 피드백</td>
                            <td class="cssTblContent" colspan="3"><asp:Label ID="lblFeedbackComment" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <!-- 정의가 할당된 질의문 반복  시작-->
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                         <tr>
                            <td>
                                <asp:DataList ID="DataList1" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList1_ItemDataBound" DataKeyField="Q_DFN_ID" Width="100%">
                        <ItemTemplate>
                         <br/>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                <tr >
                                    <td>
                                            <tr>
                                                <td>
                                                      <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr> 
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                                    <tr> 
                                                                        <td height="28"width="80px" align="center"  class="cssTblTitle"> 평가요소&nbsp;</td>
                                                                        <td height="28" align="center"  class="cssTblTitle"> 평가요소 정의 &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                          <td class="cssTblContent" align="center">&nbsp;<asp:Literal ID="ltrLevelDefName" runat="server"></asp:Literal></td>
                                                                           <td class="cssTblContent"  align="left"> &nbsp;<asp:Literal ID="ltrLevelDefine" runat="server"></asp:Literal></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   <asp:DataList ID="DataList3" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList3_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                                        <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0"  width="100%"  align="center">
                                                            <tr valign="top">
                                                                <td class="tableBorder">
                                                                       <table cellpadding="0" cellspacing="0" border="0"  width="100%">
                                                                                <tr>
                                                                                     <td height="22" align="left" class="cssTblContent"><strong><asp:Label id="lblSortID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUM") %>'/>.<asp:Label id="lblSubjectName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Q_SBJ_NAME") %>'/> <asp:Literal ID="ltrPoint" runat="server"></asp:Literal></strong>
                                                                                     </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                            <tr>
                                                                                                <td  class="cssTblTitleSingle">정 의</td>
                                                                                                <td  class="cssTblContent">
                                                                                                    &nbsp;<asp:Literal ID="ltrLevelDefine" runat="server"></asp:Literal>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td  class="cssTblTitleSingle">설 명</td>
                                                                                                <td  class="cssTblContent">
                                                                                                     &nbsp;<asp:Literal ID="ltrLevelDesc" runat="server"></asp:Literal>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr valign="top">
                                                                                    <td class="cssTblContent">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="14" id="tdLeft" runat="server"><img src="../images/bar_gray1.gif" width="14" height="41"></td>
                                                                                            <td height="41" align="center" background="../images/bg_gray.gif" id="tdCenter" runat="server">
                                                                                                <asp:Label runat="server" ID="lblEstText" ForeColor="#996600" Font-Bold="True"></asp:Label><strong>
                                                                                                <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                                                                <asp:RadioButtonList ID="rBtnList" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList>
                                                                                                </strong>
                                                                                            </td>
                                                                                            <td width="17" align="right" id="tdRight" runat="server"><img src="../images/bar_gray2.gif" width="17" height="41"></td>
                                                                                        </tr>
                                                                                        <tr id="trTextValue" runat="server" visible="false">
                                                                                            <td colspan="3">
                                                                                                <img src="../images/title/ta_t38.gif" border="0" />
                                                                                                <asp:TextBox ID="txtLevelValue" runat="server" TextMode="MultiLine" Height="60" Width="100%"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        </table>
                                                                                          <div align="center"><b><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList"
                                                                                                    ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></b></div> 
                                                                                    </td>
                                                                                </tr>
                                                                       </table>
                                                                </td>
                                                             </tr>  
                                                             </table> 
                                                      </ItemTemplate>
                                                   </asp:DataList>	
                                                </td>
                                            </tr>
                                    </td>
                                </tr>
                                  <tr class="cssTblContent">
                                    <td height="10">
                                    </td>
                                  </tr>
                             </table> 
                       </ItemTemplate>
                    </asp:DataList>
                            </td>
                        </tr>
                    </table>
                    <!-- 정의가 할당된 질의문 반복 끝-->
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <!-- 정의가 할당되지 않은 질의문 반복  시작-->
                                <asp:DataList ID="DataList2" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList2_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                    <ItemTemplate>
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr> 
                                                <td> 
                                                     <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr valign="top"> 
                                                            <td> 
                                                                <table cellpadding="0" cellspacing="0" border="0"  width="100%">
                                                                    <tr>
                                                                        <td height="22" align="left" ><strong><asp:Label id="lblSortID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUM") %>'/>.<asp:Label id="lblSubjectName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Q_SBJ_NAME") %>'/> <asp:Literal ID="ltrPoint" runat="server"></asp:Literal></strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0" class="" width="100%">
                                                                            <tr>
                                                                                <td  class="cssTblTitleSingle">정 의</td>
                                                                                <td  class="cssTblContent">
                                                                                    &nbsp;<asp:Literal ID="ltrLevelDefine" runat="server"></asp:Literal>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td  class="cssTblTitleSingle">설 명</td>
                                                                                <td  class="cssTblContent">
                                                                                     &nbsp;<asp:Literal ID="ltrLevelDesc" runat="server"></asp:Literal>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                           </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                     <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr valign="top">
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                    <tr>
                                                                        <td width="14" id="tdLeft" runat="server"><img src="../images/bar_gray1.gif" width="14" height="41"></td>
                                                                        <td height="41" width="100%" align="center" background="../images/bg_gray.gif"  id="tdCenter" runat="server">
                                                                            <asp:Label runat="server" ID="lblEstText" ForeColor="#996600" Font-Bold="True"></asp:Label><strong>
                                                                            <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>
                                                                            <asp:RadioButtonList ID="rBtnList" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                            </asp:RadioButtonList>
                                                                            </strong>
                                                                        </td>
                                                                        <td width="17" align="right" id="tdRight" runat="server"><img src="../images/bar_gray2.gif" width="17" height="41"></td>
                                                                    </tr>
                                                                    <tr id="trTextValue" runat="server" visible="false">
                                                                        <td colspan="3">
                                                                            <img src="../images/title/ta_t38.gif" border="0" />
                                                                            <asp:TextBox ID="txtLevelValue" runat="server" TextMode="MultiLine" Height="60" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                  <div align="center"><b><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList"
                                                                            ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></b></div> 
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>	
                                    </ItemTemplate>
                                </asp:DataList>
                                <!-- 정의가 할당되지 않은 질의문 반복 끝-->  
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" runat="server" id="tblComment" visible="false" align="center">
                        <tr>
                            <td>
                                <img src="../images/title/ta_t39.gif" border="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtFeedbackComment" runat="server" TextMode="MultiLine" Height="70px" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left:5px;">
                                <asp:ImageButton ID="iBtnReject" runat="server" ImageUrl="../images/btn/btn_refusal.gif" OnClick="iBtnReject_Click" OnClientClick="return doRejection();"/>
                            </td>
                            <td align="right" height="40">
                                <asp:ImageButton ID="ibnFeedbackAgree" runat="server" ImageUrl="../images/btn/b_176.gif" CommandName="BIZ_Q_FEEDBACK_AGREE" OnClick="ibnFeedbackAgree_Click"/>
                                <asp:ImageButton ID="ibnFeedbackReject" runat="server" ImageUrl="../images/btn/btn_objection.gif" CommandName="BIZ_Q_FEEDBACK_REJECT" OnClick="ibnFeedbackReject_Click"/>
                                <asp:ImageButton ID="ibnSaveOpinion" runat="server" ImageUrl="../images/btn/b_166.gif" CommandName="BIZ_Q_SAVE_OPINION" OnClick="ibnSaveOpinion_Click"/>
                                <asp:ImageButton ID="ibnSaveEst" runat="server" ImageUrl="../images/btn/b_167.gif" OnClick="ibnSaveEst_Click" CommandName="BIZ_Q_SAVE_EST"/>
                                <a href="#null" onclick="window.close();"><img src="../images/btn/b_003.gif" height="19" border="0"></a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        </table></td></tr>
    </table>

<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
<asp:LinkButton ID="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:LinkButton>        
<sj:smartscroller id="SmartScroller1" runat="server"></sj:smartscroller>
<script type="text/javascript">gfWinFocus();</script>
<!--- MAIN END --->
</form>
</body>
</html>
