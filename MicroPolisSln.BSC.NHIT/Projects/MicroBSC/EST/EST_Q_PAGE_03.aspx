<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST_Q_PAGE_03.aspx.cs" Inherits="EST_EST_Q_PAGE_03" %>
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
        <script type="text/javascript" language="javascript">
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
                    //document.getElementById('span1').style.overflow = "auto";
                    document.getElementById('ddlStep').style.display = "block";
                }
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
            <td id="tdPreviousStep" style="height: 180px; display: none; border-bottom: 5px solid Gray; padding-top: 6px; ">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <span id="span1" style="overflow: auto; height: 180px; width: 100%;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr> 
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                    <tr> 
                                                        <td height="28" bgcolor="E8F0D9" class="cssTblTitle" width="25%">&nbsp;평가기간</td>
                                                        <td class="cssTblContent" align="center">&nbsp;<%= ESTTERM_REF_NAME%>&nbsp;<%= ESTTERM_SUB_NAME%>&nbsp;<%= ESTTERM_STEP_NAME_P%></td>
                                                        <td bgcolor="E8F0D9" class="cssTblTitle" width="25%">&nbsp;평가명</td>
                                                        <td class="cssTblContent" align="center" width="20%">&nbsp;<%= EST_NAME%> </td>
                                                    </tr>
                                                    <tr> 
                                                        <td height="28" bgcolor="E8F0D9" class="cssTblTitle">&nbsp;부서 / 평가자</td>
                                                          <td class="cssTblContent" align="center">&nbsp;<%= EST_DEPT_NAME_P %>&nbsp;<%= EST_EMP_NAME_P%></td>
                                                          <td bgcolor="E8F0D9" class="cssTblTitle">&nbsp;피부서 / 피평가자</td>
                                                          <td class="cssTblContent" width="120" align="center">&nbsp;<%= TGT_DEPT_NAME%>&nbsp;<%= TGT_EMP_NAME%></td>
                                                    </tr>
                                                    <tr> 
                                                        <td height="28" bgcolor="E8F0D9" class="cssTblTitle">&nbsp;질의평가그룹</td>
                                                          <td class="cssTblContent" align="center">&nbsp;<%= Q_OBJ_NAME%> </td>
                                                          <td bgcolor="E8F0D9" class="cssTblTitle">&nbsp;평가점수 / 총 배점</td>
                                                          <td class="cssTblContent" align="center">&nbsp;<asp:Literal ID="ltrTotalPoint_P" runat="server"></asp:Literal><span id="sumpoint_P"></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <!-- 정의가 할당된 질의문 반복  시작-->
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" class="tableBorder">
                            <tr>
                                <td>
                                    <!-- 정의가 할당된 질의문 반복  시작-->
                                    <asp:DataList ID="DataList4" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList4_ItemDataBound" DataKeyField="Q_DFN_ID" Width="100%">
                                        <ItemTemplate>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr> 
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                                        <tr> 
                                                                            <td height="28" align="center" bgcolor="E8F0D9" class="cssTblTitle" style="width: 120px"> 평가요소&nbsp;</td>
                                                                            <td height="28" align="center" bgcolor="E8F0D9" class="cssTblTitle"> 평가요소 정의 &nbsp;</td>
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
                                                <tr valign="top">
                                                    <td class="tableBorder">
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
	                                                            <td class="cssTblTitle" align="center" style="width:120px">카테고리</td>
	                                                            <td class="cssTblTitle" align="center">평가항목</td>
	                                                            <td class="cssTblTitle" align="center" style="width:120px" id="tdHeader" runat="server">평 가</td>
	                                                            <td class="cssTblTitle" align="center" style="width:60px">점 수</td>
                                                            </tr>
                                                        </table>
                                                       <asp:DataList ID="DataList6" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList6_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                                          <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td class="cssTblContent" align="center" style="width:122px">
                                                                        <asp:Literal ID="ltrLevelSbjName" runat="server"></asp:Literal></td>
                                                                    <td class="cssTblContent">
                                                                        <asp:Literal ID="ltrLevelSbjDefine" runat="server" ></asp:Literal>
                                                                        <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList" ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></td>
                                                                    <td class="cssTblContent" align="left" style="width:122px" id="tdContent" runat="server">
                                                                       <asp:RadioButtonList ID="rBtnList" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="1"></asp:RadioButtonList></td>
                                                                     <td class="cssTblContent" align="center" style="width:62px">&nbsp;
                                                                        <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>
                                                                        <asp:Literal ID="ltrWeight" runat="server" Text='<%# "<br>(" + DataTypeUtility.GetToDouble(DataBinder.Eval(Container, "DataItem.WEIGHT")).ToString("#,##0.00") + "%)" %>'></asp:Literal>
                                                                     </td>
                                                                </tr>
                                                                <tr id="trTextValue" runat="server" visible="false">
                                                                    <td colspan="4">
                                                                        <img src="../images/title/ta_t38.gif" border="0" />
                                                                        <asp:TextBox ID="txtLevelValue" runat="server" TextMode="MultiLine" Height="60" Width="100%" Visible="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                             </table>
                                                           </ItemTemplate>
                                                       </asp:DataList>	
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
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td class="tableBorder">
                                               <asp:DataList ID="DataList5" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList5_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                                  <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                         <tr>
                                                            <td class="cssTblTitle" align="center" style="width:120px">카테고리</td>
                                                            <td class="cssTblTitle" align="center">평가항목</td>
                                                            <td class="cssTblTitle" align="center" style="width:120px" id="tdHeader" runat="server">평 가</td>
                                                            <td class="cssTblTitle" align="center" style="width:60px">점 수</td>
                                                         </tr>
                                                         <tr>
                                                            <td class="cssTblContent" align="center">
                                                                <asp:Literal ID="ltrLevelSbjName" runat="server"></asp:Literal></td>
                                                            <td class="cssTblContent">
                                                                <asp:Literal ID="ltrLevelSbjDefine" runat="server" ></asp:Literal>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList" ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></td>
                                                            <td class="cssTblContent" id="tdContent" runat="server">
                                                               <asp:RadioButtonList ID="rBtnList" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="1"></asp:RadioButtonList></td>
                                                             <td class="cssTblContent" align="center">
                                                                <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>
                                                                <asp:Literal ID="ltrWeight" runat="server" Text='<%# "<br>(" + DataTypeUtility.GetToDouble(DataBinder.Eval(Container, "DataItem.WEIGHT")).ToString("#,##0.00") + "%)" %>'></asp:Literal>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trTextValue" runat="server" visible="false">
                                                            <td colspan="4">
                                                                <img src="../images/title/ta_t38.gif" border="0" />
                                                                <asp:TextBox ID="txtLevelValue" runat="server" TextMode="MultiLine" Height="60" Width="100%" Visible="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                     </table>
                                                   </ItemTemplate>
                                               </asp:DataList>	
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- 정의가 할당되지 않은 질의문 반복 끝-->  
                                </td>
                            </tr>
                        </table>
                    </span>
                </ContentTemplate>
                <Triggers><asp:AsyncPostBackTrigger ControlID="ddlStep" /></Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td style="height: 100%; padding-top: 5px;">
                <div style="height: 100%; overflow: auto;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td>
                                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                <tr> 
                                                    <td height="28" bgcolor="E8F0D9" class="cssTblTitle" width="25%">&nbsp;평가기간</td>
                                                      <td class="cssTblContent" align="center">&nbsp;<%= ESTTERM_REF_NAME%>&nbsp;<%= ESTTERM_SUB_NAME%>&nbsp;<%= ESTTERM_STEP_NAME%></td>
                                                      <td bgcolor="E8F0D9" class="cssTblTitle" width="25%">&nbsp;평가명</td>
                                                      <td class="cssTblContent" align="center" width="20%">&nbsp;<%= EST_NAME%> </td>
                                                </tr>
                                                <tr> 
                                                    <td height="28" bgcolor="E8F0D9" class="cssTblTitle">&nbsp;부서 / 평가자</td>
                                                      <td class="cssTblContent" align="center">&nbsp;<%= EST_DEPT_NAME %>&nbsp;<%= EST_EMP_NAME%></td>
                                                      <td bgcolor="E8F0D9" class="cssTblTitle">&nbsp;피부서 / 피평가자</td>
                                                      <td class="cssTblContent" width="120" align="center">&nbsp;<%= TGT_DEPT_NAME%>&nbsp;<%= TGT_EMP_NAME%></td>
                                                </tr>
                                                <tr> 
                                                    <td height="28" bgcolor="E8F0D9" class="cssTblTitle">&nbsp;질의평가그룹</td>
                                                      <td class="cssTblContent" align="center">&nbsp;<%= Q_OBJ_NAME%> </td>
                                                      <td bgcolor="E8F0D9" class="cssTblTitle">&nbsp;평가점수 / 총 배점</td>
                                                      <td class="cssTblContent" align="center">&nbsp;<asp:Literal ID="ltrTotalPoint" runat="server"></asp:Literal><span id="sumpoint"></span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <!-- 정의가 할당된 질의문 반복  시작-->
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" class="tableBorder">
                         <tr>
                            <td>
                                <!-- 정의가 할당된 질의문 반복  시작-->
                                <asp:DataList ID="DataList1" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList1_ItemDataBound" DataKeyField="Q_DFN_ID" Width="100%">
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr> 
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                                    <tr> 
                                                                        <td height="28" align="center" bgcolor="E8F0D9" class="cssTblTitle" style="width: 120px"> 평가요소&nbsp;</td>
                                                                        <td height="28" align="center" bgcolor="E8F0D9" class="cssTblTitle"> 평가요소 정의 &nbsp;</td>
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
                                            <tr valign="top">
                                                <td class="tableBorder">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
	                                                        <td class="cssTblTitle" align="center" style="width:120px">카테고리</td>
	                                                        <td class="cssTblTitle" align="center">평가항목</td>
	                                                        <td class="cssTblTitle" align="center" style="width:120px" id="tdHeader" runat="server">평 가</td>
	                                                        <td class="cssTblTitle" align="center" style="width:60px">점 수</td>
                                                        </tr>
                                                    </table>
                                                   <asp:DataList ID="DataList3" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList3_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                                      <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td class="cssTblContent" align="center" style="width:122px">
                                                                    <asp:Literal ID="ltrLevelSbjName" runat="server"></asp:Literal></td>
                                                                <td class="cssTblContent">
                                                                    <asp:Literal ID="ltrLevelSbjDefine" runat="server" ></asp:Literal>
                                                                    <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList" ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></td>
                                                                <td class="cssTblContent" align="left" style="width:122px" id="tdContent" runat="server">
                                                                   <asp:RadioButtonList ID="rBtnList" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="1"></asp:RadioButtonList></td>
                                                                 <td class="cssTblContent" align="center" style="width:62px">&nbsp;
                                                                    <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>
                                                                    <asp:Literal ID="ltrWeight" runat="server" Text='<%# "<br>(" + DataTypeUtility.GetToDouble(DataBinder.Eval(Container, "DataItem.WEIGHT")).ToString("#,##0.00") + "%)" %>'></asp:Literal>
                                                                 </td>
                                                            </tr>
                                                            <tr id="trTextValue" runat="server" visible="false">
                                                                <td colspan="4">
                                                                    <img src="../images/title/ta_t38.gif" border="0" />
                                                                    <asp:TextBox ID="txtLevelValue" runat="server" TextMode="MultiLine" Height="60" Width="100%" Visible="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                         </table>
                                                       </ItemTemplate>
                                                   </asp:DataList>	
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
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td class="tableBorder">
                                           <asp:DataList ID="DataList2" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList2_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                              <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                     <tr>
                                                        <td class="cssTblTitle" align="center" style="width:120px">카테고리</td>
                                                        <td class="cssTblTitle" align="center">평가항목</td>
                                                        <td class="cssTblTitle" align="center" style="width:120px" id="tdHeader" runat="server">평 가</td>
                                                        <td class="cssTblTitle" align="center" style="width:60px">점 수</td>
                                                     </tr>
                                                     <tr>
                                                        <td class="cssTblContent" align="center">
                                                            <asp:Literal ID="ltrLevelSbjName" runat="server"></asp:Literal></td>
                                                        <td class="cssTblContent">
                                                            <asp:Literal ID="ltrLevelSbjDefine" runat="server" ></asp:Literal>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList" ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></td>
                                                        <td class="cssTblContent" id="tdContent" runat="server">
                                                           <asp:RadioButtonList ID="rBtnList" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="1"></asp:RadioButtonList></td>
                                                         <td class="cssTblContent" align="center">
                                                            <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>
                                                            <asp:Literal ID="ltrWeight" runat="server" Text='<%# "<br>(" + DataTypeUtility.GetToDouble(DataBinder.Eval(Container, "DataItem.WEIGHT")).ToString("#,##0.00") + "%)" %>'></asp:Literal>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr id="trTextValue" runat="server" visible="false">
                                                        <td colspan="4">
                                                            <img src="../images/title/ta_t38.gif" border="0" />
                                                            <asp:TextBox ID="txtLevelValue" runat="server" TextMode="MultiLine" Height="60" Width="100%" Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                 </table>
                                               </ItemTemplate>
                                           </asp:DataList>	
                                        </td>
                                    </tr>
                                </table>
                                <!-- 정의가 할당되지 않은 질의문 반복 끝-->  
                            </td>
                        </tr>
                    </table>

                    <table width="98%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" height="40" runat="server" id="tdImgBox">
                                <asp:ImageButton ID="ibnFeedbackAgree" runat="server" ImageUrl="../images/btn/b_176.gif" CommandName="BIZ_Q_FEEDBACK_AGREE" OnClick="ibnFeedbackAgree_Click"/>
                                <asp:ImageButton ID="ibnFeedbackReject" runat="server" ImageUrl="../images/btn/b_175.gif" CommandName="BIZ_Q_FEEDBACK_REJECT" OnClick="ibnFeedbackReject_Click"/>
                                <asp:ImageButton ID="ibnSaveOpinion" runat="server" ImageUrl="../images/btn/b_166.gif" CommandName="BIZ_Q_SAVE_OPINION" OnClick="ibnSaveOpinion_Click"/>
                                <asp:ImageButton ID="ibnSaveEst" runat="server" ImageUrl="../images/btn/b_167.gif" OnClick="ibnSaveEst_Click" CommandName="BIZ_Q_SAVE_EST"/>
                                <a href="#null" onclick="window.close();"><img src="../images/btn/b_003.gif" height="19" border="0"></a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>    
    </table>

<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
<asp:LinkButton ID="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:LinkButton>
<sj:smartscroller ID="Smartscroller1" runat="server"></sj:smartscroller>
<script type="text/javascript">gfWinFocus();</script>
<!--- MAIN END --->    

</form>
</body>
</html>
