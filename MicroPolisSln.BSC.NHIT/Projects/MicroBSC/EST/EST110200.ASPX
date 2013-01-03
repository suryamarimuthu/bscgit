<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110200.aspx.cs" Inherits="EST_EST110200" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
<script type="text/javascript">

    function SearchEstID()
    {
	    gfOpenWindow( "EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&CTRL_VALUE_NAME="	+ "hdfSearchEstID"
                                + "&CTRL_TEXT_NAME="	+ "txtSearchEstName"
                                + "&CHECKBOX_YN="	    + "N"
                                + "&CTRL_VALUE_VALUE="  + ""
                               , 430
                               , 400
                               , false
                               , false
                               , "popup_est_est_id" );
	    //return false;
    }
    
    function Search() 
    {
        if(document.getElementById('hdfSearchEstID').value == "") 
        {
            alert('평가를 선택하세요.');
            return false;
        }
        
        return true;
    }
    
    function ShowEstDeptID()
	{
		gfOpenWindow( "EST_DEPT.aspx?COMP_ID=<%=COMP_ID%>"
                                + "&ESTTERM_REF_ID=<%= ESTTERM_REF_ID.ToString() %>"
								+ "&CTRL_VALUE_NAME="	+ "hdfEstDept"
								+ "&CTRL_TEXT_NAME="	+ "txtEstDept"
								+ "&CHECKBOX_YN="	    + "Y"
								+ "&CTRL_VALUE_VALUE="  + document.getElementById('hdfEstDept').value
								+ "&POSTBACK_YN="       + "Y"
                                + "&POSTBACK_CTRL_NAME="+ "lbnReload"
							   , 430
							   , 400
							   , false
							   , false
							   , "popup_est_dept" );
		return false;
	}
    
</script>
<form id="form1" runat="server">
    <div>
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
<TABLE cellpadding=0 cellspacing=0 border=0 width="100%" height="100%">
	<tr>
		<td height="20">
		    <table width="100%" cellpadding="0" cellspacing="0" border="0">
		        <tr>
		            <td>
		                <img src="../images/title/se_ti01.gif" align="absmiddle">
                        <asp:dropdownlist id="ddlEstTermRefID" runat="server" autopostback="True" onselectedindexchanged="ddlEstTermRefID_SelectedIndexChanged" class="box01"></asp:dropdownlist>
                        <asp:dropdownlist id="ddlEstTermSubID" runat="server" autopostback="True" class="box01" onselectedindexchanged="ddlEstTermSubID_SelectedIndexChanged"></asp:dropdownlist>
                        <asp:dropdownlist id="ddlEstTermStepID" runat="server" autopostback="True" class="box01" onselectedindexchanged="ddlEstTermStepID_SelectedIndexChanged" Visible="False"></asp:dropdownlist>
                    </td>
                    <td align="right" id="tdBiasDept" runat="server" visible="false">
                        &nbsp;
						<asp:textbox id="txtEstDept" runat="server" maxlength="100" width="119px"></asp:textbox> 
						<a href="#null" onClick="ShowEstDeptID();"><IMG src="../images/btn/b_147.gif" align="absMiddle" border="0" /></a> 
						<asp:hiddenfield id="hdfEstDept" runat="server"></asp:hiddenfield>
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="ibnLowHigh" runat="server" ImageUrl="../images/btn/tap_b02.gif" OnClick="ibnLowHigh_Click"/>
                        <asp:ImageButton ID="ibnRadar" runat="server" ImageUrl="../images/btn/tap_b01.gif" OnClick="ibnRadar_Click"/>        
                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                        <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px" width="120px"></asp:textbox>
                        <a href="#null" onclick="SearchEstID();">
                            <img align="absMiddle" border="0" src="../images/btn/b_143.gif" id="imgEstButton" runat="server" /></a>
                        <asp:imagebutton id="ibnSearch" runat="server" height="19px" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>
                        &nbsp;
                    </td>
		        </tr>
		    </table>
        </td>
    </tr>
    <%--<tr>
        <td height="20">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <td>
                    &nbsp;&nbsp;&nbsp;
                    
                </td>
                <td align="right">
                    
                    &nbsp;
                </td>
            </table>
        </td>
    </tr>--%>
    <tr>
        <td align="center">
            <DCWC:Chart ID="Chart1" runat="server" ImageUrl="../TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas">
                <ChartAreas>
                    <dcwc:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                        <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" />
                        <position y="15" height="78" width="88" x="5"></Position>
                        <axisy linecolor="64, 64, 64, 64" LabelsAutoFit="False">
	                        <labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
	                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                        <majortickmark size="0.6"></MajorTickMark>
                        </AxisY>
                        <axisx linecolor="64, 64, 64, 64" LabelsAutoFit="False" Interval="1">
	                        <labelstyle font="Gulim, 12px"></LabelStyle>
	                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                        </AxisX>
                    </dcwc:ChartArea>
                </ChartAreas>
                <Legends>
                   <DCWC:Legend Name="Default">
                   </DCWC:Legend>
               </Legends>
            </DCWC:Chart>
            <DCWC:Chart ID="Chart2" runat="server" ImageUrl="../TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Height="5px" Width="5px">
                <ChartAreas>
                    <dcwc:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                        <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" />
                        <position y="15" height="78" width="88" x="5"></Position>
                        <axisy linecolor="64, 64, 64, 64" LabelsAutoFit="False">
	                        <labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
	                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                        <majortickmark size="0.6"></MajorTickMark>
                        </AxisY>
                        <axisx linecolor="64, 64, 64, 64" LabelsAutoFit="False" Interval="1">
	                        <labelstyle font="Gulim, 12px"></LabelStyle>
	                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                        </AxisX>
                    </dcwc:ChartArea>
                </ChartAreas>
                <Legends>
                   <DCWC:Legend Name="Default">
                   </DCWC:Legend>
               </Legends>
            </DCWC:Chart>
		</td>
	</tr>
	<tr height="8">
	    <td>
	        <img src="../images/blank.gif" width="1" height="8">
        </td>
    </tr>
	<tr>
		<td height="40">
            <table width="100%">
                <tr>
                    <td id="tdImgBox" runat="server">
                        &nbsp;
                        <asp:dropdownlist id="ddlBiasTypeID" runat="server" class="box01" Visible="False"></asp:dropdownlist>
                        <asp:imagebutton id="ibnApplyBiasPoint" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_186.gif" CommandArgument="JOB_04" CommandName="BIZ_CONFIRM_BIAS" onclick="ibnConfirmBias_Click" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="ibnConfirmCancel" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_019.gif" onclick="ibnConfirmCancel_Click" visible="False"></asp:imagebutton></td>
                    <td align="right">
                        <asp:imagebutton id="ibnDownExcel" runat="server" height="19px" imageurl="~/images/btn/b_041.gif" onclick="ibnDownExcel_Click" ImageAlign="AbsMiddle" Visible="false"></asp:imagebutton>
                        &nbsp;&nbsp;
                        <asp:ImageButton id="ibnCalcBiasPoint" onclick="ibnCalcBiasPoint_Click" runat="server" ImageUrl="~/images/btn/b_187.gif"  CommandArgument="JOB_04" CommandName="BIZ_CONFIRM_BIAS" ImageAlign="AbsMiddle"></asp:ImageButton>
                        <asp:ImageButton ID="ibnOrg" ImageUrl="~/images/btn/b_025.gif" runat="server" OnClick="ibnOrg_Click" ImageAlign="AbsMiddle" />
                        <asp:ImageButton ID="ibnAvg" ImageUrl="~/images/btn/b_026.gif" runat="server" OnClick="ibnAvg_Click" ImageAlign="AbsMiddle" />
                        <asp:ImageButton ID="ibnStd" ImageUrl="~/images/btn/b_027.gif" runat="server" OnClick="ibnStd_Click" ImageAlign="AbsMiddle" />
                        &nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
		</td>
	</tr>
</table>

<asp:hiddenfield id="hdfEstID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermRefID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermSubID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermStepID" runat="server"></asp:hiddenfield>
<asp:literal id="ltrScript" runat="server"></asp:literal>
<asp:linkbutton id="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:linkbutton>
<!--- MAIN END --->
    <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>