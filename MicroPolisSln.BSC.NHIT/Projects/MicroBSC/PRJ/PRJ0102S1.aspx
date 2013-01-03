<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0102S1.aspx.cs" Inherits="PRJ_PRJ0102S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%--@ Register Assembly="Infragistics2.WebUI.WebSchedule.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="ig_sched" --%>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
<!--

function OpenCalendarEvent(oScheduleInfo, oEvent, oDialog, oActivity)
{
            
            var keyDatas        = oActivity.getDataKey().split("|");
//              alert(keyDatas[0]);
//              alert(keyDatas[1]);
            
            var taskRefID        = keyDatas[0];
            var prjRefID        = keyDatas[1];
            
            var ICCB1           = "<%= this.ICCB1 %>";
            var READ_ONLY_YN    = "<%= this.READ_ONLY_YN %>";
            
            //alert(taskRefID);
            
            var url             = "PRJ0102M1.aspx?PRJ_REF_ID="+ prjRefID + "&TASK_REF_ID=" + taskRefID + "&CCB1=" + ICCB1 + "&READ_ONLY_YN=" + READ_ONLY_YN;
            oEvent.cancel = true;
            
            if(taskRefID != null)
            {
                gfOpenWindow(url, 700, 480, 'yes', 'no', 'PRJ0102M1');
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
            <%--                               <ig:webnumericedit id="txtMSResult" runat="server" Width="100%" Nullable="False" ValueText="0" BorderColor="red" BorderWidth="2px"
                                                MaxValue="9999" MinValue="0" ToolTip="당월실적" NegativeForeColor="Magenta" HorizontalAlign="Center" DataMode="Int"
                                                Font-Size="10pt" Font-Names="Verdana" Height="100%" NullText="0" MinDecimalPlaces="None" >
                                            </ig:webnumericedit>--%>
                                            <ig:webmaskedit id="txtYear" runat="server" InputMask="####" RealText="&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;" AutoPostBack="true" HorizontalAlign="Center" Width="100%" ToolTip="YYYY" Font-Names="Verdana" Font-Size="9pt" DataMode="RawText"></ig:webmaskedit>
                                      </td>
                                    </tr>
                                    <tr>
                                      <td class="cssTblTitle" style="border-right:none;">사업명&nbsp;</td>
                                      <td class="cssTblContent"  style="border-right:none;">
                                        <asp:DropDownList id="ddlPrjName" class="box01" runat="server" width="100%" AutoPostBack="false"></asp:DropDownList>
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
                          <td colspan="7" align="left" style="height: 100%">
                           <ig:WebMonthView ID="WebMonthView1" runat="server" height="450px" Width="100%" WebScheduleInfoID="WebScheduleInfo1" WeekNumbersVisible="False" WeekendDisplayFormat="Full" OnLoad="WebMonthView1_Load"></ig:WebMonthView>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                    <ig:WebScheduleInfo id="WebScheduleInfo1" style="z-index: 101" runat="server" EnableRecurringActivities="True" EnableSmartCallbacks="True" EnableProgressIndicator="False">
                       <ClientEvents ActivityDialogOpening="OpenCalendarEvent"></ClientEvents>
                    </ig:WebScheduleInfo>
            </td>
        </tr>
    </table>
<!--- MAIN END --->
<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>  
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>