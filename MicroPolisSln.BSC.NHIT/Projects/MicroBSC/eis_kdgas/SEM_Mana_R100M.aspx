<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R100M.aspx.cs" Inherits="eis_kdgas_SEM_Mana_R100M" %>
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
<script  type="text/javascript">
function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell = ig_getElementById(id);
           var row = ig_getRowById(id);
           var band = ig_getBandById(id);
           var active = ig_getActiveRow(id);
           //var termName = row.getCellFromKey("KPI_NAME").getValue();
           cell.style.cursor = 'hand';
         
            /*
           var label = ig_getElementById("Label2");
           var parts = id.split("_");
           if(label && parts.length>=3)
                label.innerHTML = "Current Row:" + parts[1] + " - Current Column:" + parts[2];
            */
        }
    }
</script>
    <form id="form2" runat="server">
    <div>

<MenuControl:MenuControl ID="MenuControl2" runat="server" />
      <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder">
        <tr>
            <td valign="top" colspan="3">
                <table>
                    <tr>
                        <td style="height: 36px" align="center" class="tableTitle">메뉴명</td>
                        <td style="height: 36px" align="center" class="tableTitle">파일명</td>
                        <td style="height: 36px" align="center" class="tableTitle">파일위치</td>
                        <td style="height: 36px" align="center" class="tableTitle">저장</td>
                    </tr>
                    <tr>
                        <td class="tableContent">1.고문위촉현황</td>
                        <td class="tableContent"> 
                            <asp:label id="lbl_01" runat="server" text="고문위촉현황_R100.ppt"></asp:label>
                        </td>
                        <td class="tableContent">
                            <asp:fileupload id="file_01" runat="server" width="300px"></asp:fileupload>
                        </td>
                        <td class="tableContent">
                            <asp:imagebutton id="btn_01" runat="server" ImageUrl="~/images/btn/b_002.gif" OnClick="btn_01_Click"></asp:imagebutton>
                        </td>
                    </tr>
                    <tr>
                        <td class="tableContent">2. 예금현황</td>
                        <td class="tableContent"> 
                            <asp:label id="lbl_02" runat="server" text="금융기관별예금현황_R102.ppt"></asp:label>
                        </td>
                        <td class="tableContent">
                            <asp:fileupload id="file_02" runat="server" width="300px"></asp:fileupload>
                        </td>
                        <td class="tableContent">
                            <asp:imagebutton id="btn_02" runat="server" imageurl="~/images/btn/b_002.gif" OnClick="btn_02_Click"></asp:imagebutton>
                        </td>
                    </tr>
                    <tr>
                        <td class="tableContent" style="height: 25px">3. 차입금현황</td>
                        <td class="tableContent" style="height: 25px"> 
                            <asp:label id="lbl_03" runat="server" text="금융기관별차입현황_R103.ppt"></asp:label>
                        </td>
                        <td class="tableContent" style="height: 25px">
                            <asp:fileupload id="file_03" runat="server" width="300px"></asp:fileupload>
                        </td>
                        <td class="tableContent" style="height: 25px">
                            <asp:imagebutton id="btn_03" runat="server" imageurl="~/images/btn/b_002.gif" OnClick="btn_03_Click"></asp:imagebutton>
                        </td>
                    </tr>
                    <tr>
                        <td class="tableContent" style="height: 25px">4. 자본금현황</td>
                        <td class="tableContent" style="height: 25px"> 
                            <asp:label id="lbl_04" runat="server" text="자본금현황_R104.ppt"></asp:label>
                        </td>
                        <td class="tableContent" style="height: 25px">
                            <asp:fileupload id="file_04" runat="server" width="300px"></asp:fileupload>
                        </td>
                        <td class="tableContent" style="height: 25px">
                            <asp:imagebutton id="btn_04" runat="server" imageurl="~/images/btn/b_002.gif" OnClick="btn_04_Click"></asp:imagebutton>
                        </td>
                    </tr>
                    <tr>
                        <td class="tableContent">5. 주요주주명세서</td>
                        <td class="tableContent"> 
                            <asp:label id="lbl_05" runat="server" text="주요주주명세서_R105.ppt"></asp:label>
                        </td>
                        <td class="tableContent">
                            <asp:fileupload id="file_05" runat="server" width="300px"></asp:fileupload>
                        </td>
                        <td class="tableContent">
                            <asp:imagebutton id="btn_05" runat="server" imageurl="~/images/btn/b_002.gif" OnClick="btn_05_Click"></asp:imagebutton>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px" class="tableContent">6. 타법인출자현황</td>
                        <td style="height: 30px" class="tableContent"> 
                            <asp:label id="lbl_06" runat="server" text="타법인출자현황_R106.ppt"></asp:label>
                        </td>
                        <td style="height: 30px" class="tableContent">
                            <asp:fileupload id="file_06" runat="server" width="300px"></asp:fileupload>
                        </td>
                        <td style="height: 30px" class="tableContent">
                            <asp:imagebutton id="btn_06" runat="server" imageurl="~/images/btn/b_002.gif" OnClick="btn_06_Click"></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
          <tr>
              <td colspan="3" valign="top" align="right" style="width: 613px; height: 30px;">
                  &nbsp;
              </td>
          </tr>
        
        </table>
        &nbsp;&nbsp;
        <asp:literal id="ltlMsg" runat="server"></asp:literal>
    </div>
<!--- MAIN END --->
<%Response.WriteFile("../_common/html/MenuBottom.htm");%>
    
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>


