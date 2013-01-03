<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC2100M1.aspx.cs" Inherits="BSC_BSC2100M1" %>

<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" src="../_common/js/common.js"></script>
        <script type="text/javascript">
            
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
                                        <div style="border:#F4F4F4 3px solid; overflow: auto; width: 200; height: 300px">
                                            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ImageSet="XPFileExplorer" NodeIndent="15">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                                    VerticalPadding="0px" />
                                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView>
                                            </div>
                                        </td>
                                        <td valign="top" style="height: 130px">
                                        <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="140px" OnInitializeRow="UltraWebGrid1_InitializeRow" ImageDirectory="">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                       <ig:TemplatedColumn Key="selchk" Width="30px">
                                                    <CellTemplate>
                                                        <asp:CheckBox ID="cBox" runat="server" />
                                                    </CellTemplate>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                                    </HeaderTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                   </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="LOGINID" Key="LOGINID" Width="60px" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_EMAIL" Hidden="True" Key="EMP_EMAIL" Width="180px">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="POS_CLS_NAME" Hidden="True" Key="POS_CLS_NAME" Width="60px">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="Q_OBJ_ID" HeaderText="Q_OBJ_ID" Hidden="True" Key="Q_OBJ_ID">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ENABLED" FooterText="ENABLED" Hidden="True" Key="ENABLED">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="150px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="부서">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="160px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="이름">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="Q_OBJ_NAME" Key="Q_OBJ_NAME" Width="200px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="평가질의 그룹명">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                        </Bands>
                                            <DisplayLayout  CellPaddingDefault="2" 
                                                            AllowColSizingDefault="Free" 
                                                            AllowDeleteDefault="Yes"
                                                            AllowSortingDefault="NotSet" 
                                                            BorderCollapseDefault="Separate"
                                                            HeaderClickActionDefault="SortMulti" 
                                                            Name="UltraWebGrid1" 
                                                            RowHeightDefault="20px"
                                                            RowSelectorsDefault="No" 
                                                            SelectTypeRowDefault="Extended" 
                                                            Version="4.00" 
                                                            CellClickActionDefault="RowSelect" 
                                                            TableLayout="Fixed" 
                                                            StationaryMargins="Header" 
                                                            AutoGenerateColumns="False">
                                            <%--<GroupByBox>
                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="140px"
                                                Width="100%">
                                            </FrameStyle>
                                            <Pager>
                                                <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                </PagerStyle>
                                            </Pager>
                                            <AddNewBox Hidden="False">
                                                <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                </BoxStyle>
                                            </AddNewBox>
                                            <SelectedRowStyleDefault BackColor="#E2ECF4">
                                            </SelectedRowStyleDefault>
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>
                                        <Images ImageDirectory="">
                                        </Images>--%>
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                        </DisplayLayout>
                                       </ig:ultrawebgrid>
                                    </td>
                                    </tr>
                                       <tr align="right">
                                        <td>
                                            <table width=100% border=0>
                                                <tr>
                                                    <td height="20" style="width: 96px">
                                                        총 인원수 :
                                                        <asp:label id="lblTotal" runat="server" ForeColor="#2080D0" Text="0"></asp:label>명
                                                    </td>
                                                    <td align="left">
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                                        <asp:ImageButton ID="ibtnDelEmp" runat="server" ImageUrl="../images/btn/btn_add_03.GIF" OnClick="ibtnDelEmp_Click"/>&nbsp;
                                                        <asp:ImageButton ID="ibtnAddEmp" runat="server" ImageUrl="../images/btn/btn_add_04.GIF" OnClick="ibtnAddEmp_Click"/></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td style="height: 130px">
                                        <ig:ultrawebgrid id="UltraWebGrid2" runat="server" width="100%" Height="140px" ImageDirectory="">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_EMAIL" Hidden="True" Key="EMP_EMAIL" Width="180px">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="POS_CLS_NAME" Hidden="True" Key="POS_CLS_NAME" Width="60px">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="Q_OBJ_ID" HeaderText="Q_OBJ_ID" Hidden="True" Key="Q_OBJ_ID">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ENABLED" FooterText="ENABLED" Hidden="True" Key="ENABLED">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="LOGINID" Key="LOGINID" Width="60px" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:TemplatedColumn Key="selchk" Width="30px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellTemplate>
                                                                <asp:CheckBox ID="cBox" runat="server" />
                                                            </CellTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid2');" />
                                                            </HeaderTemplate>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="150px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="부서">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="160px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="이름">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="Q_OBJ_NAME" Key="Q_OBJ_NAME" Width="200px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="평가질의 그룹명">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout  CellPaddingDefault="2" 
                                                            AllowColSizingDefault="Free" 
                                                            AllowDeleteDefault="Yes"
                                                            AllowSortingDefault="NotSet" 
                                                            BorderCollapseDefault="Separate"
                                                            HeaderClickActionDefault="SortMulti" 
                                                            Name="UltraWebGrid2" 
                                                            RowHeightDefault="20px"
                                                            RowSelectorsDefault="No" 
                                                            SelectTypeRowDefault="Extended" 
                                                            Version="4.00" 
                                                            CellClickActionDefault="RowSelect" 
                                                            TableLayout="Fixed" 
                                                            StationaryMargins="Header" 
                                                            AutoGenerateColumns="False">
                                                <%--<GroupByBox>
                                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="140px"
                                                    Width="100%">
                                                </FrameStyle>
                                                <Pager>
                                                    <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </PagerStyle>
                                                </Pager>
                                                <AddNewBox Hidden="False">
                                                    <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </BoxStyle>
                                                </AddNewBox>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>
                                                <ActivationObject BorderColor="" BorderWidth="">
                                                </ActivationObject>
                                                <Images ImageDirectory="">
                                                </Images>--%>
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                    </tr>
                                    <tr align="right">
                                        <td>
                                            <table width=100% border=0>
                                                <tr>
                                                    <td height="20">
                                                        선택된 인원수 :
                                                        <asp:label id="lblSelect" runat="server" ForeColor="#2080D0" Text="0"></asp:label>명
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;<asp:ImageButton ID="iBtnConfirm" runat="server" ImageUrl="../images/btn/b_005.gif"
                                                    OnClick="iBtnConfirm_Click" />&nbsp;
                                                <a href="#" onclick="self.close();"><img src="../images/btn/b_003.gif" border="0" /></a>&nbsp; </td>
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
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
<script>    gfWinFocus();</script>
    <!--- MAIN END --->
    </form>
</body>
</html>