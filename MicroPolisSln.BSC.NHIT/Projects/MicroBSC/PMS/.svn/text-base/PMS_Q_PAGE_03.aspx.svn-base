<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMS_Q_PAGE_03.aspx.cs" Inherits="PMS_PMS_Q_PAGE_03" %>
<html>
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
 
 <script type="text/javascript"> 
 function ViewProject()
 {
        var prjID           = <%=PRJ_REF_ID%>;
        var viewYN          = 'U';
        
        var url             = 'PRJ0101M1.aspx?iType=' + viewYN + '&PRJ_REF_ID=' + prjID;
        gfOpenWindow(url, 900, 680, 'yes', 'no', 'PRJ0101M1');
}
     
 function ViewTask()
 {
        var prjID           = <%=PRJ_REF_ID%>;
        var prjType         = "<%=PRJ_TYPE%>";
        var url             = 'PRJ0102S3.ASPX?PAGE_TYPE=P&PRJ_REF_ID=' + prjID+'&PRJ_TYPE='+prjType ;
        gfOpenWindow(url, 840, 520, 'yes', 'no', 'PRJ0102S3');
 }
</script>    
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">

<form id="form1" runat="server">
<!--- MAIN START --->	
<table  width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                    <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 

                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td style="width:170px; height:40px; background-image: url(../images/title/popup_title.gif);"
                                class="cssPopTitleArea">
                                    <asp:Label ID="lblPopUpTitle" runat="server" CssClass="cssPopTitleTxt" Text=""><%= Q_OBJ_NAME%></asp:Label>
                                </td>
                                <td align="right" valign="top">
                                    <img alt="" src="../images/title/popup_img.gif" />
                                </td>
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
        </td>
    </tr>
    <tr class="cssPopContent">
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" >
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                            <tr> 
                                <td   class="cssTblTitle">&nbsp;평가기간</td>
                                  <td class="cssTblContent" >&nbsp;<%= ESTTERM_REF_NAME%>&nbsp;<%= ESTTERM_SUB_NAME%>&nbsp;<%= ESTTERM_STEP_NAME%></td>
                                  <td  class="cssTblTitle"  style="width:20%;">&nbsp;평가명</td>
                                  <td class="cssTblContent"  >&nbsp;<%= EST_NAME%> </td>
                            </tr>
                            <tr> 
                                <td   class="cssTblTitle">&nbsp;평가자(부서)</td>
                                  <td class="cssTblContent" >&nbsp;<%= EST_EMP_NAME%>&nbsp;(<%= EST_DEPT_NAME %>)</td>
                                  <td  class="cssTblTitle">&nbsp;평가 대상 프로젝트명</td>
                                  <td class="cssTblContent"  >&nbsp;<%= PRJ_NAME%>&nbsp;(<%= PRJ_CODE%>)</td>
                            </tr>
                           <%-- <tr> 
                                <td   class="cssTblTitle">&nbsp;질의평가그룹</td>
                                  <td class="cssTblContent" >&nbsp;<%= Q_OBJ_NAME%> </td>
                                  <td  class="cssTblTitle">&nbsp;평가점수 / 총 배점</td>
                                  <td class="cssTblContent" >&nbsp;<asp:Literal ID="ltrTotalPoint" runat="server"></asp:Literal><span id="sumpoint"></span></td>
                            </tr>--%>
                           <tr> 
                                <td   class="cssTblTitle">&nbsp;피평가자(부서)</td>
                                  <td class="cssTblContent" >&nbsp;<%= TGT_EMP_NAME%>&nbsp;(<%= TGT_DEPT_NAME %>)</td>
                                  <td  class="cssTblTitle">&nbsp;평가점수 / 총 배점</td>
                                  <td class="cssTblContent" >&nbsp;<asp:Literal ID="ltrTotalPoint" runat="server"></asp:Literal><span id="sumpoint"></span></td>
                            </tr>
                        </table>
                               
                    </td>
                </tr>
                <tr style="display:none;">
                    <td class="cssPopBtnLine" >
                        <a href="#null" onclick="ViewProject();"><asp:Image ID="imgPrjInfo" runat="server" BorderStyle="None" BorderWidth="0px" ImageUrl="../images/btn/b_189.gif" /></a>
                        <a href="#null" onclick="ViewTask();"><asp:Image ID="imgPrjSch" runat="server" BorderWidth="0px" ImageUrl="../images/btn/b_190.gif" /></a>
                    </td>
                </tr>
             </table>
             <br />
        </td>
    </tr>
    
    <tr>
        <td align="center">
            <table width="98%" border="0" cellspacing="0" cellpadding="0">
                 <tr>
                    <td>               
                    <!-- 정의가 할당된 질의문 반복  시작-->
                    <asp:DataList ID="DataList1" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList1_ItemDataBound" DataKeyField="Q_DFN_ID" Width="100%">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                            <tr> 
                                                <td class="cssTblTitle" style="text-align:center;">평가요소</td>
                                                <td class="cssTblTitle" style="text-align:center;">평가요소 정의</td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblContent"><asp:Literal ID="ltrLevelDefName" runat="server"></asp:Literal></td>
                                                <td class="cssTblContent"><asp:Literal ID="ltrLevelDefine" runat="server"></asp:Literal></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                
                                <tr >
                                    <td class="tableBorder" valign="top">
	                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
	                                        <tr>
		                                        <td class="cssTblTitle" style="text-align:center;width:15%">카테고리</td>
		                                        <td class="cssTblTitle" style="text-align:center;width:35%">평가항목</td>
		                                        <td class="cssTblTitle" style="text-align:center;width:40%" id="tdHeader" runat="server">평 가</td>
		                                        <td class="cssTblTitle" style="text-align:center;width:10%">점수/배점</td>
	                                        </tr>
	                                    </table>
                                       <asp:DataList ID="DataList3" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList3_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                          <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
	                                                <td class="cssTblContent" style="width:15%" >
	                                                    <asp:Literal ID="ltrLevelSbjName" runat="server"></asp:Literal></td>
	                                                <td class="cssTblContent" style="width:35%">
	                                                    <asp:Literal ID="ltrLevelSbjDefine" runat="server" ></asp:Literal>
	                                                    <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList" ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></td>
	                                                <td class="cssTblContent" style="width:40%" id="tdContent" runat="server">
                                                       <asp:TextBox ID="txtLevelValue" Visible="false" runat="server"></asp:TextBox>
                                                       <asp:RadioButtonList ID="rBtnList" runat="server" style="cursor:pointer;" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="5" ></asp:RadioButtonList>
                                                       <asp:HiddenField ID="tmpSubItmYN" runat="server" />
                                                       </td>
                                                     <td class="cssTblContent" style="text-align:center;width:10%">
                                                        <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>
                                                        <asp:Literal ID="ltrWeight" runat="server" Text='<%# "<br>(" + DataTypeUtility.GetToDouble(DataBinder.Eval(Container, "DataItem.WEIGHT")).ToString("#,##0") + ")" %>'></asp:Literal>
                                                     </td>
                                                </tr>
                                             </table>
                                           </ItemTemplate>
                                       </asp:DataList>	
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                    <td class="tableBorder">   
                                    
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td class="cssTblTitle">
                                                  &nbsp;<asp:Label runat="server" ID="lblAvgSumText"></asp:Label> 
                                                  </td>
                                                <td class="cssTblContent">
                                                  &nbsp;<asp:Label runat="server" ID="lblAvgSumValue"></asp:Label>
                                                  </td>
                                                <td class="cssTblTitle">
                                                 &nbsp;<asp:Label runat="server" ID="lblAvgText"></asp:Label>
                                                   </td>
                                                 <td class="cssTblContent" >
                                                   &nbsp;<asp:Label runat="server" ID="lblAvgValue"></asp:Label>
                                                 </td>
                                            </tr>
                                         </table>                 
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:10px; border:0px;background-color:White;">
                                    </td>
                                </tr>
                            </table>                            
                       </ItemTemplate>
                    </asp:DataList>	
                    </td>
                 </tr>
             </table>
        </td>
    </tr>
    <tr>
        <td align="center" >
            <table width="98%" border="0" cellspacing="0" cellpadding="0" >
                 <tr>
                    <td>        
                     <!-- 정의가 할당되지 않은 질의문 반복  시작-->
                       <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="tableBorder"  align="center">
                                   <asp:DataList ID="DataList2" runat="server" ShowFooter="False" ShowHeader="False" OnItemDataBound="DataList2_ItemDataBound" DataKeyField="Q_SBJ_ID" Width="100%">
                                      <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                             <tr>
                                                <td class="cssTblTitle"  style="width:120px">카테고리</td>
                                                <td class="cssTblTitle" >평가항목</td>
                                                <td class="cssTblTitle"  style="width:190px" id="tdHeader" runat="server">평 가</td>
                                                <td class="cssTblTitle"  style="width:60px">점 수</td>
                                             </tr>
                                             <tr>
                                                <td class="cssTblContent" >
                                                    <asp:Literal ID="ltrLevelSbjName" runat="server"></asp:Literal></td>
                                                <td class="cssTblContent">
                                                    <asp:Literal ID="ltrLevelSbjDefine" runat="server" ></asp:Literal>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rBtnList" ErrorMessage="평가등급을 체크하세요." Enabled="false"></asp:RequiredFieldValidator></td>
                                                <td class="cssTblContent" id="tdContent" runat="server">
                                                   <asp:TextBox ID="txtLevelValue" Visible="false" runat="server"></asp:TextBox>
                                                   <asp:RadioButtonList ID="rBtnList" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="4"></asp:RadioButtonList>
                                                   <asp:HiddenField ID="tmpSubItmYN" runat="server" />
                                                   </td>
                                                 <td class="cssTblContent" >
                                                    <asp:Literal ID="ltrLevelPointData" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltrWeight" runat="server" Text='<%# "<br>(" + DataTypeUtility.GetToDouble(DataBinder.Eval(Container, "DataItem.WEIGHT")).ToString("#,##0.00") + "%)" %>'></asp:Literal>
                                                    &nbsp;</td>
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
        </td>
    </tr>
    <tr>
        <td align="right" height="40" runat="server" id="tdImgBox">
           <asp:ImageButton ID="ibnSaveEst" runat="server" ImageUrl="../images/btn/b_167.gif" OnClick="ibnSaveEst_Click" CommandName="BIZ_Q_SAVE_EST" Visible="false"/>
            <a href="#null" onclick="window.close();"><img src="../images/btn/b_003.gif" height="19" border="0"></a>
            &nbsp
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr> 
                    <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                    <td style="width:50%; background-color:#FFFFFF"></td>
                </tr>
            </table>
            
            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
            <asp:LinkButton ID="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:LinkButton>
            <sj:smartscroller ID="Smartscroller1" runat="server"></sj:smartscroller>
            <script type="text/javascript">    gfWinFocus();</script>
        </td>
    </tr>

</table>
        <!-- 정의가 할당된 질의문 반복 끝--> 
  

<!--- MAIN END --->    

</form>
</body>
</html>
