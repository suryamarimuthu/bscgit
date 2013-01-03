<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST040104.aspx.cs" Inherits="EST_EST060104" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

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
                                                    <td height="40" valign="top"><img src="../images/title/popup_t56.gif" /></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td width="50%" height="4" bgcolor="#FFFFFF"></td>
                                                    <td width="50%" bgcolor="#FFFFFF"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!-- 타이틀끝 -->
                            </td>
                        </tr>
                        <tr class="cssPopContent">
                            <td valign="top">
                                <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                                   
                                    <tr>
                                        <td valign="top" align="center" height="300">
                                            <div>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 98%:height:100%">
                                                    <tr>
                                                        <td>
                                                            <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="330px" OnInitializeRow="UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_NAME" Key="ESTTERM_STEP_NAME" Width="60px" FooterText="" HeaderText="평가차수">
                                                                                <Header Caption="평가차수" Title="">
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                                <Footer Caption="" Title="">
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" Key="EST_DEPT_NAME" Width="90px" FooterText="" HeaderText="평가자부서">
                                                                                <Header Caption="평가자부서" Title="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                                <Footer Caption="" Title="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EST_EMP_NAME" Key="EST_EMP_NAME" Width="80px" FooterText="" HeaderText="평가자명">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="평가자명" Title="">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                                <Footer Caption="" Title="">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="TGT_DEPT_NAME" Key="TGT_DEPT_NAME" Width="90px" FooterText="" HeaderText="피평가자부서">
                                                                                <Header Caption="피평가자부서" Title="">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                                <Footer Caption="" Title="">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="TGT_EMP_NAME" Key="TGT_EMP_NAME" Width="80px" FooterText="" HeaderText="피평가자명">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="피평가자명" Title="">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                                <Footer Caption="" Title="">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn Key="TGT_POS_CLS_NAME" BaseColumnName="TGT_POS_CLS_NAME" Width="40px" HeaderText="직급">
                                                                                <Header Caption="직급">
                                                                                    <RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center"/>
                                                                                <Footer>
                                                                                <RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn Key="TGT_POS_DUT_NAME" BaseColumnName="TGT_POS_DUT_NAME" Width="40px" HeaderText="직책">
                                                                                <Header Caption="직책">
                                                                                    <RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center"/>
                                                                                <Footer>
                                                                                <RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn Key="TGT_POS_GRP_NAME" BaseColumnName="TGT_POS_GRP_NAME" Width="40px" HeaderText="직군">
                                                                                <Header Caption="직군">
                                                                                    <RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center"/>
                                                                                <Footer>
                                                                                <RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn Key="TGT_POS_RNK_NAME" BaseColumnName="TGT_POS_RNK_NAME" Width="40px" HeaderText="직위">
                                                                                <Header Caption="직위">
                                                                                    <RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center"/>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn Key="TGT_POS_KND_NAME" BaseColumnName="TGT_POS_KND_NAME" Width="40px" HeaderText="직종">
                                                                                <Header Caption="직종">
                                                                                    <RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center"/>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                        </Columns>
                                                                    </ig:UltraGridBand>
                                                                </Bands>

                                                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                                    AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                                                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="OutlookGroupBy" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
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
                                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                                                        <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                    </HeaderStyleDefault>
                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                    </EditCellStyleDefault>
                                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="330px"
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
                                                                    <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
                                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                                    </ActivationObject>--%>
                                                                    
                                                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                </DisplayLayout>
                                                            </ig:ultrawebgrid>
                                                        </td>
                                                    </tr>
                                                    <tr align="right">
                                                        <td style="height: 40px"><br/>
                                                            &nbsp;<a href="javascript:window.close();"><img src="../images/btn/b_003.gif" border=0/></a>&nbsp;</td>
                                                    </tr>
                                                </table>
                                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="height: 16px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>      

    <script>gfWinFocus();</script>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <!--- MAIN END --->
    </form>
</body>
</html>
