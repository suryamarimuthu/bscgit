<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST_EMP.aspx.cs" Inherits="EST_EST_EMP" %>
    
<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" src="../_common/js/common.js"></script>
        <script type="text/javascript">

        function SetValue(deptId, deptName, empId, empName) 
        {
            if('<%=CTRL_DEPT_VALUE_NAME%>' != '')
                opener.document.getElementById('<%=CTRL_DEPT_VALUE_NAME%>').value   = deptId;
            
            if('<%=CTRL_DEPT_TEXT_NAME%>' != '')
                opener.document.getElementById('<%=CTRL_DEPT_TEXT_NAME%>').value    = deptName;
                
            if('<%=CTRL_EMP_VALUE_NAME%>' != '')
                opener.document.getElementById('<%=CTRL_EMP_VALUE_NAME%>').value   = empId;
                
            if('<%=CTRL_EMP_TEXT_NAME%>' != '')
                opener.document.getElementById('<%=CTRL_EMP_TEXT_NAME%>').value    = empName;
                
            window.close();
        }
        
        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40">
					            <!-- 타이틀시작 -->
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr> 
                                                    <td height="40" valign="top"><img src="../images/title/popup_t23.gif" ></td>
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
                                <!-- 타이틀끝 -->
                            </td>
                        </tr>
                        <tr class="cssPopContent">
                            <td valign="top" class="box_td03">
                                <table style="width: 100%" class="box_ta01">
                                    <tr>
                                        <td rowspan="5" style="width: 200px" valign="top">
                                        <div style=" overflow: auto; width: 200; height: 330px" class="cssDivLayout">
                                            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ImageSet="XPFileExplorer" NodeIndent="15" >
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                                    VerticalPadding="0px" />
                                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView>
                                            </div>
                                        </td>
                                        <td valign="top" style="height:300px;">
                                            <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" ImageDirectory="" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="True">
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Hidden="True">
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_CLS_ID" Key="POS_CLS_ID" Hidden="True">
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_RNK_ID" Key="POS_RNK_ID" Hidden="True">
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_DUT_ID" Key="POS_DUT_ID" Hidden="True">
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_GRP_ID" Key="POS_GRP_ID" Hidden="True">
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_KND_ID" Key="POS_KND_ID" Hidden="True">
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn Key="SELECT" Width="35px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="선택">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Footer>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="150px" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="부서">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Footer>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="155px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="이름">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Footer>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_CLS_NAME" Key="POS_CLS_NAME" Width="50px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="직급">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Footer>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_RNK_NAME" Key="POS_RNK_NAME" Width="56px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="직위">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Footer>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_DUT_NAME" Key="POS_DUT_NAME" Width="55px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="직책">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Footer>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_GRP_NAME" Key="POS_GRP_NAME" Width="60px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="직군">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Footer>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="POS_KND_NAME" Key="POS_KND_NAME" Width="55px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="직종">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Footer>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                    </Columns>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout  CellPaddingDefault="2" 
                                                        AllowColSizingDefault="Free" 
                                                        AllowDeleteDefault="Yes"
                                                        AllowSortingDefault="Yes" 
                                                        BorderCollapseDefault="Separate"
                                                        HeaderClickActionDefault="NotSet" 
                                                        Name="UltraWebGrid1" 
                                                        RowHeightDefault="20px"
                                                        RowSelectorsDefault="No" 
                                                        SelectTypeRowDefault="Extended" 
                                                        Version="4.00" 
                                                        ReadOnly="LevelTwo"
                                                        CellClickActionDefault="NotSet" 
                                                        TableLayout="Fixed" 
                                                        StationaryMargins="Header"
                                                        OptimizeCSSClassNamesOutput="False"
                                                        AutoGenerateColumns="False">
                                            <%--<GroupByBox>
                                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                            </GroupByBox>
                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                            </GroupByRowStyleDefault>
                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                            </FooterStyleDefault>
                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                <Padding Left="3px" />
                                            </RowStyleDefault>
                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="280px"
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
                                            <ActivationObject BorderColor="" BorderWidth="">
                                            </ActivationObject>--%>
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            <Images>
	                                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
	                                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                            </Images>
                                        </DisplayLayout>
                                    </ig:ultrawebgrid>
                                    </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width=100% border=0>
                                                <tr>
                                                    <td height="20">
                                                        총 인원수 : <asp:label id="lblTotal" runat="server" ForeColor="#2080D0" Text="0"></asp:label>명
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;&nbsp;
                                                <a href="#" onclick="self.close();"><img src="../images/btn/b_003.gif" border="0" /></a>&nbsp; </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    
                                </table>
                                
                            </td>
                        </tr>
                        <tr">
                            <td>
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
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
<script>gfWinFocus();</script>
    <!--- MAIN END --->
    </form>
</body>
</html>