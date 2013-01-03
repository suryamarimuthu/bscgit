<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_ahp.aspx.cs" Inherits="usr_usr_ahp" %>

<%@ Register Assembly="DundasWebChart, Version=5.0.0.1692, Culture=neutral, PublicKeyToken=90d06b0c62d592d0"
    Namespace="Dundas.Charting.WebControl" TagPrefix="DCWC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BSC</title>
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <link rel="stylesheet" href="../_common/css/treeStyle.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    <script type="text/javascript">
    
    function GetSliderValue(lpoint, slider, rpoint) 
    {
        var lObj = document.getElementById(lpoint);
        var sObj = document.getElementById(slider);
        var rObj = document.getElementById(rpoint);
        
        if(sObj.value > 0) 
        {
            lObj.value = '';
            rObj.value = Number(sObj.value) + 1;
        }
        else if(sObj.value == 0) 
        {
            lObj.value = '';
            rObj.value = 1;
        }
        else 
        {
            lObj.value = (Number(sObj.value) - 1) * -1;
            rObj.value = '';
        }
    }
    
    function ValidCheck() 
    {
        var txtDeptID = document.getElementById('txtDeptID');
        
        if(txtDeptID.value == '0' || txtDeptID.value == "")
        {
            alert('부서를 선택하세요');
            return false;
        }
        
        return true;
    }
    
//    function GetSliderValue(lpoint, slider, rpoint) 
//    {
//        var lObj = document.getElementById(lpoint);
//        var sObj = document.getElementById(slider);
//        var rObj = document.getElementById(rpoint);
//        
//        if(sObj.value > 0) 
//        {
//            lObj.value = '';
//            rObj.value = Number(sObj.value) + 1;
//        }
//        else if(sObj.value == 0) 
//        {
//            lObj.value = '';
//            rObj.value = 1;
//        }
//        else 
//        {
//            lObj.value = (Number(sObj.value) - 1) * -1;
//            rObj.value = '';
//        }
//    }
    
    </script>
</head>
<body topmargin="0" leftmargin="0"> 
    <form id="form1" runat="server">
    
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    
    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr> 
                                    <td height="40" valign="top"><img src="../images/title/popup_t64.gif"/></td>
                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"/></td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr> 
                                    <td width="50%" height="4" bgcolor="FFC600"></td>
                                    <td width="50%" bgcolor="00549C"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
        </td>
      </tr>
    </table>
    <br />--%>
        
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td valign="top" height="40">
        <table cellpadding=2 cellspacing=0 border=0>
		    <tr>
		        <td colspan="2" height="20px" class="tableoutBorder">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td class="tableTitle" width="80">평가기간</td>
                            <td class="tableContent" width="150">
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" width="125px" CssClass="box01">
                        </asp:dropdownlist></td>
                            <td class="tableTitle" width="80">
                                버젼</td>
                            <td class="tableContent" width="120">
                                <asp:dropdownlist id="ddlStgVersion" runat="server" CssClass="box01"></asp:dropdownlist></td>
                            <td class="tableTitle" width="80">부서</td>
                            <td class="tableContent" width="120">
                                <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td onclick="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onmouseover="this.style.cursor='hand'">
                                        <asp:textbox id="txtDropDown" runat="server" width="149px" onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onclick="this.style.cursor='hand'"></asp:textbox><asp:textbox id="txtDeptID" runat="server" bordercolor="White" borderstyle="None"
                                            borderwidth="0px" cssclass="NotBoader" height="0px" style="visibility: hidden"
                                            width="0px">0</asp:textbox>
                                        <asp:panel id="Panel1" runat="server" cssclass="popupControl">
                                            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                <DIV style="BORDER-RIGHT: #f4f4f4 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: #f4f4f4 1px solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; OVERFLOW: auto; BORDER-LEFT: #f4f4f4 1px solid; WIDTH: 200px; PADDING-TOP: 2px; BORDER-BOTTOM: #f4f4f4 1px solid; HEIGHT: 350px; BACKGROUND-COLOR: white" id="leftLayer">
                                                    <asp:TreeView id="trvEstDept" runat="server" NodeIndent="5" OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged">
                                                        <SelectedNodeStyle BackColor="Silver"></SelectedNodeStyle>
                                                    </asp:TreeView>
                                                </DIV>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:panel>
                                        <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel1"
                                            Position="Bottom" TargetControlID="txtDropDown">
                                        </ajaxToolkit:PopupControlExtender>
                                        <ajaxToolkit:PopupControlExtender ID="PopupControlExtender2" runat="server" PopupControlID="Panel1"
                                            Position="Bottom" TargetControlID="txtDeptID">
                                        </ajaxToolkit:PopupControlExtender>
                                    </td>
                                </tr>
                            </table>
                            </td>
                            <td align="right" class="tableContent" colspan="2" width="90">
                                        <asp:imagebutton id="iBtnSearch" runat="server" imageurl="~/images/btn/b_033.gif"
                                            onclick="iBtnSearch_Click"></asp:imagebutton>&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
		        </td>
		    </tr>
        </table>
        </td>
    </tr>
</table>
        
    
    <table cellpadding="0" cellspacing="0" width="800">
        <tr height="70">
            <td colspan="2">
                <br />
                &nbsp;각 전략목표의 특성을 고려하여 하단 표의 좌, 우측 버튼을 이용하여 전략목표간의 상대적 중요도를 체크해 주시기 바랍니다.<br />
                &nbsp;※ AHP방식에 의한 설문의 효과성을 높이기 위해서는 일관성(consistency)이 요구되며, 일반적으로 10%이하를 기준으로 하고 있습니다.<br />
                &nbsp; &nbsp;&nbsp;
                    아래의 설문을 완성하신 후, 좌측의 CI 또는 CR이 <font color='red'>10%</font>를 초과할 경우 이를 고려하여 수정 부탁드립니다.<br />
            </td>
        </tr>
        <tr>
            <td colspan="2" height="20"></td>
        </tr>
        <tr runat="server" id="trGraph" visible="false">
            <td valign="top" width="40%">
                선택 대상 전략 목표 수 :&nbsp;
                <asp:label runat="server" ID="lblStgCount" Font-Bold="True" ForeColor="Navy"></asp:label>
                <br />
                <br />
                <asp:datagrid id="DataGrid2" runat="server" autogeneratecolumns="False" CssClass="tableBorder">
                    <Columns>
                        <asp:BoundColumn DataField="IDX" HeaderText="순번">
                            <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" Width="40px"  CssClass="tableTitle"></HeaderStyle>
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="전략명">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.STG_NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center"  CssClass="tableTitle"/>
                            <ItemStyle Width="200px" />                                
                        </asp:TemplateColumn>
                    </Columns>
                    <HeaderStyle Height="25px" />
                </asp:datagrid>
                <br />
                <table>
                    <tr>
                        <td>
                            CI (Consistency Index) :
                        </td>
                        <td align="right">
                            <asp:label runat="server" ID="lblCI" Text="0"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CR (Consistency Ratio) : &nbsp;</td>
                        <td align="right">
                            <asp:label runat="server" ID="lblCR" Text="0"></asp:label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label><br />
            </td>
            <td align="center">
                <DCWC:Chart ID="chartMM" runat="server" Height="220px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                    Palette="Dundas" Width="200px">
                    <ChartAreas>
                        <DCWC:ChartArea BackColor="White" BackGradientEndColor="White" BorderColor="196, 196, 196"
                            Name="Default" ShadowColor="Transparent">
                            <AxisX Interval="1" LabelsAutoFit="False" LineColor="196, 196, 196">
                                <LabelStyle Font="Tahoma, 10px" />
                                <MajorGrid LineColor="196, 196, 196" />
                            </AxisX>
                            <Area3DStyle Enable3D="True" WallWidth="5" XAngle="15" YAngle="10" />
                            <AxisY Enabled="True" LabelsAutoFit="False" LineColor="196, 196, 196">
                                <LabelStyle Font="Tahoma, 10px" />
                                <MajorGrid LineColor="196, 196, 196" />
                            </AxisY>
                        </DCWC:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="2" >
                        </DCWC:Legend>
                    </Legends>
                </DCWC:Chart>
                </td>
            
        </tr>
        <tr>
            <td colspan="2" height="20"></td>
        </tr>
        <tr height="50">
            <td style="height: 51px">
            </td>
            <td align="right" style="height: 51px">
            <asp:imagebutton id="iBtnSave" runat="server" imageurl="~/images/btn/b_007.gif"
                                            onclick="iBtnSave_Click" Visible="False" AccessKey="S"></asp:imagebutton>&nbsp;&nbsp;
            </td>
        </tr>
        <tr height="200">
            <td colspan="2" valign="top" align="center">
                <asp:datagrid id="DataGrid1" runat="server" autogeneratecolumns="False" OnItemDataBound="DataGrid1_ItemDataBound" CssClass="tableBorder">
                    <Columns>
                        <asp:BoundColumn DataField="IDX" HeaderText="조합">
                        <ItemStyle Width="40" HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" CssClass="tableTitle"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="A">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" Width="300px" />
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.L_STG_NAME") %>'></asp:Label>
                                <asp:Label ID="lblLStgRefID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.L_STG_REF_ID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center"  CssClass="tableTitle" Width="400px"/>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                <TABLE cellspacing="0" rules="all" border="0">
                                    <TBODY>
                                        <TR class="tableTitle">
                                            <TD colSpan="3" align="center" style="color:White"><b>평가 척도</b></TD>
                                        </TR>
                                        <TR>
                                            <TD width="100" align="center" style="color:White"><b>A가 B보다 중요</b></TD>
                                            <TD style="color:White"><b>=</b></TD>
                                            <TD width="100" align="center" style="color:White"><b>B가 A보다 중요</b></TD>
                                        </TR>
                                        <TR>
                                            <TD align="right" style="color:White"><font size="1">9 8 7 6 5 4 3 2 </font></TD>
                                            <TD align="center" style="color:White"><font size="1">1</font></TD>
                                            <TD align="left" style="color:White"><font size="1"> 2 3 4 5 6 7 8 9</font></TD>
                                        </TR>
                                    </TBODY>
                                </TABLE>
                            </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td><asp:TextBox ID="txtLPoint" runat="server" Width="20" BorderWidth="0" /></td>
                                    <td>
                                        <asp:TextBox ID="txtSlider1" runat="server" Width="200" /><asp:TextBox ID="txtSlider2" runat="server" /><asp:TextBox ID="txtSlider3" runat="server" /><asp:TextBox ID="txtSlider4" runat="server" /><asp:TextBox ID="txtSlider5" runat="server" /><asp:TextBox ID="txtSlider6" runat="server" /><asp:TextBox ID="txtSlider7" runat="server" /><asp:TextBox ID="txtSlider8" runat="server" /><asp:TextBox ID="txtSlider9" runat="server" /><asp:TextBox ID="txtSlider10" runat="server" /><asp:TextBox ID="txtSlider11" runat="server" /><asp:TextBox ID="txtSlider12" runat="server" /><asp:TextBox ID="txtSlider13" runat="server" /><asp:TextBox ID="txtSlider14" runat="server" /><asp:TextBox ID="txtSlider15" runat="server" /><asp:TextBox ID="txtSlider16" runat="server" /><asp:TextBox ID="txtSlider17" runat="server" /><asp:TextBox ID="txtSlider18" runat="server" /><asp:TextBox ID="txtSlider19" runat="server" /><asp:TextBox ID="txtSlider20" runat="server" /><asp:TextBox ID="txtSlider21" runat="server" /><asp:TextBox ID="txtSlider22" runat="server" /><asp:TextBox ID="txtSlider23" runat="server" /><asp:TextBox ID="txtSlider24" runat="server" /><asp:TextBox ID="txtSlider25" runat="server" /><asp:TextBox ID="txtSlider26" runat="server" /><asp:TextBox ID="txtSlider27" runat="server" /><asp:TextBox ID="txtSlider28" runat="server" /><asp:TextBox ID="txtSlider29" runat="server" /><asp:TextBox ID="txtSlider30" runat="server" /><asp:TextBox ID="txtSlider31" runat="server" /><asp:TextBox ID="txtSlider32" runat="server" /><asp:TextBox ID="txtSlider33" runat="server" /><asp:TextBox ID="txtSlider34" runat="server" /><asp:TextBox ID="txtSlider35" runat="server" /><asp:TextBox ID="txtSlider36" runat="server" /><asp:TextBox ID="txtSlider37" runat="server" /><asp:TextBox ID="txtSlider38" runat="server" /><asp:TextBox ID="txtSlider39" runat="server" /><asp:TextBox ID="txtSlider40" runat="server" /><asp:TextBox ID="txtSlider41" runat="server" /><asp:TextBox ID="txtSlider42" runat="server" /><asp:TextBox ID="txtSlider43" runat="server" /><asp:TextBox ID="txtSlider44" runat="server" /><asp:TextBox ID="txtSlider45" runat="server" /><asp:TextBox ID="txtSlider46" runat="server" /><asp:TextBox ID="txtSlider47" runat="server" /><asp:TextBox ID="txtSlider48" runat="server" /><asp:TextBox ID="txtSlider49" runat="server" /><asp:TextBox ID="txtSlider50" runat="server" />
                                    </td>
                                    <td><asp:TextBox ID="txtRPoint" runat="server" Width="20" BorderWidth="0"/></td>
                                </tr>
                            </table>
                            
                            <ajaxToolkit:SliderExtender ID="sxdSlider" runat="server"
                                BehaviorID='<%# "txtSlider" + Convert.ToString(DataBinder.Eval(Container, "DataItem.IDX")) %>'
                                TargetControlID='<%# "txtSlider" + Convert.ToString(DataBinder.Eval(Container, "DataItem.IDX")) %>'
                                Orientation="Horizontal"
                                EnableHandleAnimation="true"
                                Minimum="-8"
                                Maximum="8"
                                Steps="17"
                                 />
                            
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" CssClass="tableTitle"></HeaderStyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="B">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" Width="300px" />
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.R_STG_NAME") %>'></asp:Label>
                                <asp:Label ID="lblRStgRefID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.R_STG_REF_ID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" CssClass="tableTitle" Width="400px"/>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:datagrid>
            </td>
        </tr>
    </table>
    <asp:DataGrid ID="DataGrid3" runat="server" CssClass="tableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundColumn DataField="STG_REF_ID" HeaderText="전략ID">
                <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" CssClass="tableTitle"></HeaderStyle>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="STG_NAME" HeaderText="전략명">
                <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" CssClass="tableTitle"></HeaderStyle>
                <ItemStyle Width="200px" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="MULTIPLY" HeaderText="아이템 곱한 값">
                <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" CssClass="tableTitle"></HeaderStyle>
                <ItemStyle Width="120px" HorizontalAlign="Right" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="GEOMEAN" HeaderText="기하평균">
                <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" CssClass="tableTitle"></HeaderStyle>
                <ItemStyle Width="150px" HorizontalAlign="Right" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="WEIGHT" HeaderText="가중치">
                <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" CssClass="tableTitle"></HeaderStyle>
                <ItemStyle Width="60px" HorizontalAlign="Right" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="SUM" HeaderText="합">
                <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" CssClass="tableTitle"></HeaderStyle>
                <ItemStyle Width="60px" HorizontalAlign="Right" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="WS" HeaderText="가중치 * 합">
                <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" CssClass="tableTitle"></HeaderStyle>
                <ItemStyle Width="130px" HorizontalAlign="Right" />
            </asp:BoundColumn>
        </Columns>
        <ItemStyle Height="25px" />
    </asp:DataGrid>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    
    <%--<SJ:SmartScroller ID="SmartScroller2" runat="server"></SJ:SmartScroller>--%>
    
    </form>
</body>
</html>
