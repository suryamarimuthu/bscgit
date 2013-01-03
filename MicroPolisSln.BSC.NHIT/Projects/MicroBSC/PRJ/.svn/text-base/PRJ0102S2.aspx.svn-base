<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0102S2.aspx.cs" Inherits="PRJ_PRJ0102S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%--@ Register Assembly="Infragistics2.WebUI.WebSchedule.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="ig_sched" --%>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
<!--

function OpenCalendarEvent(oScheduleInfo, oEvent, oDialog, oActivity)
{
             var keyDatas        = oActivity.getDataKey().split("|");

            var taskRefID        = keyDatas[0];
            var prjRefID         = keyDatas[1];
            var ICCB1            = "<%= this.ICCB1 %>";
            var READ_ONLY_YN     = "<%= this.READ_ONLY_YN %>";
            
            //alert(taskRefID);
            
            var url             = "PRJ0102M1.aspx?PRJ_REF_ID="+ prjRefID + "&TASK_REF_ID=" + taskRefID + "&CCB1=" + ICCB1+ "&READ_ONLY_YN=" + READ_ONLY_YN;
            oEvent.cancel = true;
            
            if(taskRefID != null)
            {
                gfOpenWindow(url, 700, 580, 'yes', 'no', 'PRJ0102M1');
            }
           
}
-->
</script>
<!--- MAIN START --->
   
		<table cellpadding="0" cellspacing="0" border="0"  style="width:100%; height:100%;" >
        <tr>
            <td align="left" valign="top">
            
            
            
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                              <tbody>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" class="tableBorder">
                                            <tr>
                                              <td class="cssTblTitle">사업유형&nbsp;</td>
                                              <td class="cssTblContent">
                                                <asp:dropdownlist id="ddlPrjType" class="box01" runat="server" width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlPrjType_SelectedIndexChanged"></asp:dropdownlist>
                                              </td>
                                              <td class="cssTblTitle">사업년도&nbsp;</td>
                                              <td class="cssTblContent">
                                                    <ig:webmaskedit id="txtYear" runat="server" InputMask="####" RealText="&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;" AutoPostBack="true" HorizontalAlign="Center" Width="100%" ToolTip="YYYY" Font-Names="Verdana" Font-Size="9pt" DataMode="RawText"></ig:webmaskedit>
                                              </td>
                                            </tr>
                                            <tr>
                                              <td class="cssTblTitle" style="border-right:none;">사 업 명&nbsp;</td>
                                              <td class="cssTblContent">
                                                <asp:DropDownList id="ddlPrjName" class="box01" runat="server" width="100%" AutoPostBack="True"></asp:DropDownList>
                                              </td>
                                              <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                              <td class="cssTblContent">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                  <td align="right">
                                      <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                                  </td>
                                </tr>
                                <tr>
                                  <td colspan="7" align="left" valign="top"  style="height: 100%">
                                     <ig:WebWeekView ID="WebWeekView1" runat="server" Height="450px" WebScheduleInfoID="WebScheduleInfo1"
                                          Width="100%" OnLoad="WebWeekView1_Load">
                                        <AppointmentStyle Font-Size="Smaller"></AppointmentStyle>
                                        </ig:WebWeekView>
                                  </td>
                                
                                </tr>
                              </tbody>
                            </table>
        <ig:webscheduleinfo id="WebScheduleInfo1" runat="server" EnableRecurringActivities="True" EnableSmartCallbacks="True">
            <ClientEvents ActivityDialogOpening="OpenCalendarEvent" />
        </ig:webscheduleinfo>
            </td>
        </tr>
    </table>
<!--- MAIN END --->
<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>  
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>