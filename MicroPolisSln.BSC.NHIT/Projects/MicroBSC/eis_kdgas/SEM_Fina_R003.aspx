<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Fina_R003.aspx.cs" Inherits="eis_SEM_Fina_R003" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <!--META http-equiv="Page-Enter" content="blendTrans(Duration=0.3)">
        <META http-equiv="Page-Exit" content="blendTrans(Duration=0.3)"-->
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    </head>
    
    <body style="margin:0 0 0 0 ; background-color:#FFFFFF">
        <form id="form1" runat="server">
            <div>
                <MenuControl:MenuControl ID="MenuControl1" runat="server" />
                <!--- MAIN START --->
                <!--- TITLE --->
                <table>
                    <tr>
                        <td width="8"></td>
                    </tr>
                </table>
                <table width="800px" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF" class="box_tt01">
                    <tr> 
                        <td align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">년/월</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="cboYY" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cboMM" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>∼
                            <asp:DropDownList ID="cboTYY" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cboTMM" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                        </td>
                        <td align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">사업장</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="cboCom" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" align="right" class="box_td01">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="800px" >
	                <tr>
	                    <td style="padding-left:5px;">
	                        <table border="0" width="100%">
	                            <tr>
	                                <td align="center">
	                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>요약손익계산서</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단위 : 천원</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>&nbsp;</strong></font></td>
                                        </tr>
                                      </table>
	                                </td>
	                            </tr>
	                            <tr>
	                                <td width="100%" align="left">
                                      <table>
                                       <tr>
                                         <td align="center">
		                                              <table cellpadding="0"  cellspacing="0" border="0">
		                                                <tr>
    	                                                   <td style="background-image:url(../images/bg/son_tm01.gif);">
                                                               <table  border="0">
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4003000000_01" runat="server" Text="매출액"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4003000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4003000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4003000000_03" runat="server" CssClass="son_03" ReadOnly="True" Visible="False"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="background-image: url(../images/bg/son_tm03.gif); width: 10px">&nbsp;</td>
    	                                                   <td style="background-image:url(../images/bg/son_tm01.gif);">
                                                              <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4007000000_01" runat="server" Text="매출총이익"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4007000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4007000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4007000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="background-image: url(../images/bg/son_tm03.gif); width: 10px">&nbsp;</td>
    	                                                   <td style="background-image:url(../images/bg/son_tm01.gif);">
                                                              <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4011000000_01" runat="server" Text="영업이익"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4011000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4011000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4011000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="background-image: url(../images/bg/son_tm03.gif); width: 10px">&nbsp;</td>
                                                           <td style="background-image:url(../images/bg/son_tm06.gif);">
                                                              <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4017000000_01" runat="server" Text="경상이익"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4017000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4017000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4017000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="width:11px; background-image: url(../images/bg/son_tm03.gif);">&nbsp;</td>
    	                                                   <td style="background-image:url(../images/bg/son_tm06.gif);">
                                                              <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4001000000_01" runat="server" Text="당기순이익" CssClass=".input" Height="18"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4001000000_01" runat="server" CssClass="son_01" ReadOnly="True">0</asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4001000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4001000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
		                                                </tr>
		                                                <tr>
		                                                   <td style="height:8px;">&nbsp;</td>
		                                                   <td style="background-image: url(../images/bg/son_tm07.gif); width: 10px">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td style="background-image: url(../images/bg/son_tm07.gif); width: 10px">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td style="width:11px; background-image: url(../images/bg/son_tm07.gif);">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td style="background-image: url(../images/bg/son_tm07.gif); width: 10px">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                </tr>
		                                                <tr>
    	                                                   <td style="background-image:url(../images/bg/son_tm02.gif);">
                                                               <table>
    	                                                          <tr>
    	                                                            <td >
    	                                                                <strong><asp:Label ID="lbl_4005000000_01" runat="server" Text="매출원가"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4005000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4005000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4005000000_03" runat="server" CssClass="son_03" ReadOnly="True" Visible="False"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="width:10px; background-image:url(../images/bg/son_tm09.gif);">&nbsp;</td>
    	                                                   <td style="background-image:url(../images/bg/son_tm02.gif);">
                                                               <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4009000000_01" runat="server" Text="판관비"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4009000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4009000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4009000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="background-image: url(../images/bg/son_tm09.gif); width: 10px">&nbsp;</td>
    	                                                   <td style="background-image:url(../images/bg/son_tm01.gif);">
                                                               <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4013000000_01" runat="server" Text="영업외수익"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4013000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4013000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4013000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="width:11px; background-image: url(../images/bg/son_tm10.gif);">&nbsp;</td>
    	                                                   <td style="background-image:url(../images/bg/son_tm01.gif);">
                                                               <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4019000000_01" runat="server" Text="특별이익"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4019000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4019000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4019000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="background-image: url(../images/bg/son_tm10.gif); width: 10px">&nbsp;</td>
    	                                                   <td>&nbsp;</td>
		                                                </tr>
		                                                <tr>
		                                                   <td style="height:16px;">&nbsp;</td>
		                                                   <td style="width: 10px; height: 16px;">&nbsp;</td>
		                                                   <td style="height: 16px">&nbsp;</td>
		                                                   <td style="height: 16px;">&nbsp;</td>
		                                                   <td style="height: 16px">&nbsp;</td>
		                                                   <td style="width: 10px; background-image: url(../images/bg/son_tm07.gif);">&nbsp;</td>
		                                                   <td style="height: 16px">&nbsp;</td>
		                                                   <td style="width: 10px; background-image: url(../images/bg/son_tm07.gif);">&nbsp;</td>
		                                                   <td style="height: 16px">&nbsp;</td>
		                                                </tr>
		                                                <tr>
    	                                                   <td>&nbsp;</td>
    	                                                   <td style="width: 10px">&nbsp;</td>
    	                                                   <td>&nbsp;</td>
    	                                                   <td>&nbsp;</td>
    	                                                   <td style="background-image:url(../images/bg/son_tm02.gif);">
                                                               <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4015000000_01" runat="server" Text="영업외비용"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4015000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4015000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4015000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="width:10px; background-image: url(../images/bg/son_tm09.gif);">&nbsp;</td>
                                                           <td style="background-image:url(../images/bg/son_tm02.gif);">
                                                               <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4021000000_01" runat="server" Text="특별손실"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4021000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4021000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4021000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="width:11px; background-image: url(../images/bg/son_tm10.gif);">&nbsp;</td>
    	                                                   <td>&nbsp;</td>
		                                                </tr>
		                                                <tr>
		                                                   <td style="height:8px;">&nbsp;</td>
		                                                   <td style="width: 10px">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td style="width: 10px">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td style="width: 10px; background-image: url(../images/bg/son_tm07.gif);">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                </tr>
		                                                <tr>
    	                                                   <td>&nbsp;</td>
    	                                                   <td style="width: 10px">&nbsp;</td>
    	                                                   <td>&nbsp;</td>
    	                                                   <td style="width:10px;">&nbsp;</td>
    	                                                   <td>&nbsp;</td>
    	                                                   <td style="width:11px;">&nbsp;</td>
                                                           <td style="background-image:url(../images/bg/son_tm02.gif);">
                                                               <table>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <strong><asp:Label ID="lbl_4025000000_01" runat="server" Text="법인세비용"></asp:Label></strong>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4025000000_01" runat="server" CssClass="son_01" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                          <tr>
    	                                                            <td>
    	                                                                <asp:TextBox ID="txt_4025000000_02" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox>
    	                                                                <asp:TextBox ID="txt_4025000000_03" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox>
    	                                                            </td>
    	                                                          </tr>
    	                                                      </table>
    	                                                   </td>
    	                                                   <td style="width:11px; background-image: url(../images/bg/son_tm09.gif);">&nbsp;</td>
    	                                                   <td>&nbsp;</td>
		                                                </tr>
		                                                <tr>
		                                                   <td style="height:8px;">&nbsp;</td>
		                                                   <td style="width: 10px">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td style="width: 10px">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                   <td style="width: 10px">&nbsp;</td>
		                                                   <td>&nbsp;</td>
		                                                </tr>
		                                                <tr>
		                                                   <td colspan="9" align="left">
		                                                       <table class="box_tt01">
		                                                              <tr>
		                                                                  <td align="left">
    	                                                                      <asp:TextBox ID="TextBox1" runat="server" CssClass="son_02" ReadOnly="True"></asp:TextBox><b /> : 전년동월대비 증감율
		                                                                  </td>
		                                                              </tr>
		                                                              <tr>
		                                                                  <td  align="left">
		                                                                      <asp:TextBox ID="TextBox2" runat="server" CssClass="son_03" ReadOnly="True"></asp:TextBox><b /> : 매출총이익대비 구성비율

		                                                                  </td>
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
                                     </table>
                        </td>
	                </tr>
                </table>
                <!--- MAIN END --->
                <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
            </div>
        </form>
    </body>
</html>