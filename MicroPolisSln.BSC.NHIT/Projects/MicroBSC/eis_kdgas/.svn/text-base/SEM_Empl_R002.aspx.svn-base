<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Empl_R002.aspx.cs" Inherits="SEM_Empl_R002" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html>
<head id="Head1" runat="server">
<title> ▒ KD JUMP - 성과관리 네트워크 ▒ </title>
<meta http-equiv="Content-Type" content="text/html;" />
<!--META http-equiv="Page-Enter" content="blendTrans(Duration=0.3)">
<META http-equiv="Page-Exit" content="blendTrans(Duration=0.3)"-->
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">
    function ValidCtrl() 
    {
        if(document.forms[0].hdfSabun.value == '') 
        {
            alert('사원를 선택해 주세요.');
            return false;
        }
        
        return true;
    }
</script>

</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
    <div>
<MenuControl:MenuControl ID="MenuControl1" runat="server" />
<!--- MAIN START --->
<table border="0" cellspacing="1" cellpadding="2" width="800px" style="height:100%" bgcolor="#FFFFFF">
    <tr>
        <td valign="top" style="height:1" align="left">
     <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF" class="box_tt01">
            <tr>
                <td align="center" bgcolor="A6C5D1" width="10%"><strong><font color="#FFFFFF">부문</font></strong></td>
                <td class="box_td01">
                <asp:TextBox ID="txtBumunName" runat="server"></asp:TextBox></td>
                <td align="center" bgcolor="A6C5D1" width="10%"><strong><font color="#FFFFFF">팀</font></strong></td>
                <td class="box_td01">
                    <asp:TextBox ID="txtTeamName" runat="server"></asp:TextBox></td>
                <td align="center" bgcolor="A6C5D1" width="10%"><strong><font color="#FFFFFF">이름</font></strong></td>
                <td class="box_td01">
                    &nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                <td align="right" class="box_td01">
                    &nbsp;<asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;<a href='#null' onclick="window.open('SEM_Empl_R002_Popup.aspx','aa','width=400, height=400')"><img src="../images/btn/b_008.gif" border='0'/></a>&nbsp;
                </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdfSabun" runat="server" />
    <table>
        <tr>
          <td height="5"></td>
        </tr>
    </table>
    		    <table border="0" cellspacing="0" cellpadding="0" width="100%" >
    		    	<tr>
    		    		<td valign="top">
    		    		<table width=100%>
    		    		    <tr>
    		    		        <td colspan="2" align="center">
    		    		            <table cellSpacing=0 borderColorDark=#ffffff cellPadding=1 width="100%" borderColorLight=#A2A2A2 border=1>
                                  <tr>
                                    <td align="center" class="tableTitle">성 명</td>
                                    <td colspan="3" align="center">&nbsp;<asp:Label ID="lblName" runat="server"></asp:Label></td>
                                    <td align="center" class="tableTitle">사번</td>
                                    <td align="center">&nbsp;<asp:Label ID="lblSabun" runat="server"></asp:Label></td>
                                    <td rowspan="6" align="center" width="100">
                                        <asp:Image ID="imgEmp" ImageUrl="" runat="server" />
                                    </td>                                      
                                  </tr>
                                  <tr>
                                    <td width="80" align="center" class="tableTitle">입사일자</td>
                                    <td style="height: 21px" align="center">&nbsp;<asp:Label ID="lblJoinDate" runat="server"></asp:Label></td>
                                    <td width="80" align="center" class="tableTitle">생년월일</td>
                                    <td style="height: 21px" align="center">&nbsp;<asp:Label ID="lblBrthDate" runat="server"></asp:Label></td>
                                    <td width="80" align="center" class="tableTitle">결혼유무</td>
                                    <td style="height: 21px" align="center">&nbsp;<asp:Label ID="lblMarryGubn" runat="server"></asp:Label></td>
                                  </tr>
                                  <tr>
                                    <td align="center" class="tableTitle">주민번호</td>
                                    <td align="center">&nbsp;<asp:Label ID="lblJmno" runat="server"></asp:Label></td>
                                    <td align="center" class="tableTitle">성 별 </td>
                                    <td align="center">&nbsp;<asp:Label ID="lblSexGubn" runat="server"></asp:Label></td>
                                    <td align="center" class="tableTitle">취미/특기</td>
                                    <td align="center">&nbsp;<asp:Label ID="lblHobby" runat="server"></asp:Label> / <asp:Label ID="lblSpecialTalent" runat="server"></asp:Label></td>
                                  </tr>
                                  <tr>
                                    <td align="center" class="tableTitle">본 적 </td>
                                    <td colspan="3">&nbsp;<asp:Label ID="lblBonjuk" runat="server"></asp:Label></td>
                                    <td align="center" class="tableTitle">병력</td>
                                    <td align="center">&nbsp;<asp:Label ID="Label4" runat="server"></asp:Label></td>
                                  </tr>
                                  <tr>
                                    <td align="center" class="tableTitle">주 소 </td>
                                    <td colspan="3">&nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                                    <td align="center" class="tableTitle">주특기</td>
                                    <td align="center">&nbsp;<asp:Label ID="lblMainTalent" runat="server"></asp:Label></td>
                                  </tr>
                                  <tr>
                                    <td align="center" class="tableTitle">신 장 </td>
                                    <td align="center">&nbsp;<asp:Label ID="lblHeight" runat="server"></asp:Label>
                                        Cm</td>
                                    <td align="center" class="tableTitle">&nbsp;체중</td>
                                    <td align="center">&nbsp;<asp:Label ID="lblWeight" runat="server"></asp:Label>
                                        Kg</td>
                                    <td align="center" class="tableTitle">군번</td>
                                    <td align="center">&nbsp;<asp:Label ID="lblMilitaryNumber" runat="server"></asp:Label></td>
                                  </tr>
                                  <tr>
                                    <td align="center" class="tableTitle">시 력 </td>
                                    <td align="center">&nbsp;(좌) :
                                        <asp:Label ID="lblVisionLeft" runat="server"></asp:Label>
                                        (우) :
                                        <asp:Label ID="lblVisionRight" runat="server"></asp:Label></td>
                                    <td align="center" class="tableTitle">혈액형</td>
                                    <td align="center">&nbsp;<asp:Label ID="lblBloodType" runat="server"></asp:Label></td>
                                    <td align="center" class="tableTitle">E-Mail ID </td>
                                    <td colspan=2 align="center">&nbsp;<asp:Label ID="lblEMail" runat="server"></asp:Label></td>
                                  </tr>
                                </table>
    		    		        </td>
    		    		    </tr>
    		    		    <tr>
    		    		        <td width="50%" valign="top">
    		    		            <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Height="100px"
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand AddButtonCaption="Column0Column1Column2" BaseTableName="Column0Column1Column2" Key="Column0Column1Column2">
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="EMP_RELATION" Key="EMP_RELATION" Width="80px" HeaderText="관계">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="관계">
                                                    
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="100px" HeaderText="성명">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="성명">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_BRTH_DATE" Key="EMP_BRTH_DATE" Width="90px" HeaderText="생년월일">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="생년월일">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_JOB" Key="EMP_JOB" Width="100px" HeaderText="직업">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="직업">
                                                    
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid2" RowHeightDefault="20px"
                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                    <GroupByBox>
                                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#C7C7C7"
                                         ForeColor="White">
                                        <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="150px"
                                        Width="100%">
                                    </FrameStyle>
                                    <Pager>
                                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                    </Pager>
                                    <AddNewBox Hidden="False">
                                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                    </AddNewBox>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault BackColor="#E7E7E7">
                                    </RowAlternateStyleDefault>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
    		    		        </td>
    		    		        <td valign="top">
    		    		            <ig:UltraWebGrid ID="UltraWebGrid3" runat="server" Height="150px"
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="EMP_GRADUATE_DATE" Key="EMP_GRADUATE_DATE" Width="90px" HeaderText="구분">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="졸업일">
                                                    
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_SCHOOL" Key="EMP_SCHOOL" Width="180px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="학교명">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_STUDY" Key="EMP_STUDY" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="전공">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid3" RowHeightDefault="20px"
                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                    <GroupByBox>
                                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <HeaderStyleDefault horizontalalign="Center">
                                    </HeaderStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#C7C7C7"
                                         ForeColor="White">
                                        <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="150px"
                                        Width="100%">
                                    </FrameStyle>
                                    <Pager>
                                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                    </Pager>
                                    <AddNewBox Hidden="False">
                                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                    </AddNewBox>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault BackColor="#E7E7E7">
                                    </RowAlternateStyleDefault>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
    		    		        </td>
    		    		    </tr>
    		    		    </table>
    		    		    <table border="0" cellspacing="0" cellpadding="0" width="100%" >
    		    		     <tr>
    		    		        <td valign="top">
    		    		          <table border="0" cellspacing="0" cellpadding="0">
    		    		            <tr>
    		                            <td align="left"><asp:ImageButton ID="iBtnOrder" runat="server" OnClick="iBtnOrder_Click" ImageUrl="../images/btn/tap_bs01.gif" /></td>  
    		                            <td align="left"><asp:ImageButton ID="iBtnPrize" runat="server" OnClick="iBtnPrize_Click" ImageUrl="../images/btn/tap_bs02.gif" /></td>
    		                            <td align="left"><asp:ImageButton ID="iBtnJob" runat="server" OnClick="iBtnJob_Click" ImageUrl="../images/btn/tap_bs03.gif" /></td>
    		                            <td align="left"><asp:ImageButton ID="iBtnInsa" runat="server" OnClick="iBtnInsa_Click" ImageUrl="../images/btn/tap_bs04.gif" /></td>
    		                            <td align="left"><asp:ImageButton ID="iBtnCtf" runat="server" OnClick="iBtnCtf_Click" ImageUrl="../images/btn/tap_bs05.gif" /></td>
    		                            <td align="left"><asp:ImageButton ID="iBtnLearning" runat="server" OnClick="iBtnLearning_Click" ImageUrl="../images/btn/tap_bs06.gif" /></td>
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
                              <tr>
                                  <td>
    		    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
    	            <tr>
    		            <td>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="150px"
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand AddButtonCaption="Column0Column1Column2" BaseTableName="Column0Column1Column2" Key="Column0Column1Column2">
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" BorderCollapseDefault="Separate"
                                HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header">
                                <GroupByBox>
                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                </GroupByBox>
                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                </GroupByRowStyleDefault>
                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                </FooterStyleDefault>
                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" Width=150>
                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                    <Padding Left="3px" />
                                </RowStyleDefault>
                                <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#C7C7C7"
                                     ForeColor="White">
                                    <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                </EditCellStyleDefault>
                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                    Width="100%">
                                </FrameStyle>
                                <Pager>
                                    <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                    </Style>
                                </Pager>
                                <AddNewBox Hidden="False">
                                    <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                    </Style>
                                </AddNewBox>
                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                </SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault BackColor="#E7E7E7">
                                                </RowAlternateStyleDefault>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                        </td>
    		    		      </tr>
    		    		   </table>
                                
                            <asp:LinkButton ID="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:LinkButton>
    		</td>
    	</tr>
    </table>
<!--- MAIN END --->
<%Response.WriteFile("../_common/html/MenuBottom.htm");%>
    </div>
    </form>
</body>
</html>
