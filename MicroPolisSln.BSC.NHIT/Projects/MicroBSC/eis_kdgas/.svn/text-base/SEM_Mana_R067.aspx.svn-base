<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R067.aspx.cs" Inherits="eis_SEM_Mana_R067" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html>
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
    <table width="800px" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF" class="box_tt01">
    <tr>
    <td align="center" bgcolor="A6C5D1" width="15%"><strong><font color="#FFFFFF">년월</font></strong></td>
        <td class="box_td01">
                <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
                </td>
            <td align="center" bgcolor="A6C5D1" width="15%">
                <strong><font color="#FFFFFF">사업장</font></strong></td>
            <td class="box_td01">
                &nbsp;<asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList></td>    
            <td align="center" bgcolor="A6C5D1" width="15%">
                <strong><font color="#FFFFFF">구분</font></strong></td>
            <td class="box_td01">
                &nbsp;<asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList></td>
            <td align="right" class="box_td01">
                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="800px" height="95%" >
    	<tr>
    	<td height="300">
    	<table border=0 width=100%>
    	    <tr>
    	        <td>
    	        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>투자 집행 현황</strong></font></td>
                    </tr>
                </table>
                    </td>
    	        <td>
    	            </td>
    	    </tr>
    	    <tr>
    	        <td>
    	            <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="800px" >
                    <ChartAreas>
                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                         
                         BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                        <AxisY linecolor="196, 196, 196" LabelsAutoFit="false">
		                            <LabelStyle font="Tahoma, 10px" Format="#,##0"></LabelStyle>
		                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
	                            </AxisY>
	                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
		                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
		                            </AxisX>
                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="True" />
                        </DCWC:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                        </DCWC:Legend>
                    </Legends>
                    </DCWC:Chart>        
    	        </td>
            </tr>
        </table>
            </td>
    	</tr>
    	<tr>
    		<td>
    		    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="95%" >
    		    	<tr>
    		    		<td width=50% valign="top" align=center>
                            &nbsp;</td>
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
