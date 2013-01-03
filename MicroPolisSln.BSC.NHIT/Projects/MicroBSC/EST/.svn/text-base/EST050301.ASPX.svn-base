<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST050301.aspx.cs" Inherits="EST_EST050301" %>

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
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td style="height: 100%;" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40">
					            <!-- 타이틀시작 -->
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr> 
                                                    <td height="40" valign="top"><img src="../images/title/popup_t80.gif" alt="" /></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif" alt="" /></td>
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
                            <td valign="top" class="box_td03">
                                <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0" class="box_ta01">
                                    <tr>
                                        <td valign="top" align="center">
                                            <div>
                                                <table style="width: 100%" border="0"  cellpadding="1" cellspacing="3">
                                                    <tr>
                                                        <td align="center">
                                                            <table style="width: 100%; height: 330px; background-color:#ffffff;" border="0"  cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td style="height: 100%;padding-top:5px;"  valign="top" align="center">                    
                                                                        <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="330px" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                                                            <Bands>
                                                                                <ig:UltraGridBand>                               
                                                                                    <Columns>
                                                                                        <ig:UltraGridColumn BaseColumnName="STATUS_YN" Key="STATUS_YN" Hidden="true">
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_ID" Key="ESTTERM_STEP_ID" Hidden="true">
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_NAME" Key="ESTTERM_STEP_NAME" Width="40px" FooterText="" HeaderText="평가차수" MergeCells="true" Hidden="true">
                                                                                            <Header Caption="차수">
                                                                                            </Header>
                                                                                            <CellStyle HorizontalAlign="Center" VerticalAlign="top">
                                                                                            </CellStyle>
                                                                                            <Footer Caption="" Title="">
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="STATUS_IMG" Key="STATUS_IMG" Width="40px">
                                                                                            <Header Caption="상태" Title="">
                                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                                            </Header>
                                                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                                            <Footer Caption="" Title="">
                                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn> 
                                                                                        <ig:UltraGridColumn BaseColumnName="EST_JOB_NAME" Key="EST_JOB_NAME" Width="265px">
                                                                                            <Header Caption="평가작업명" Title="">
                                                                                            </Header>
                                                                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                                            <Footer Caption="" Title="">
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="START_DATE" Key="START_DATE" Width="80px" Format="yyyy-MM-dd" DataType="datetime" Hidden="true">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <Header Caption="시작일자" Title="">
                                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                                            </Header>
                                                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                                            <Footer Caption="" Title="">
                                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="END_DATE" Key="END_DATE" Width="80px" Format="yyyy-MM-dd" DataType="datetime" Hidden="true">
                                                                                            <Header Caption="종료일자" Title="">
                                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                                            </Header>
                                                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                                            <Footer Caption="" Title="">
                                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Format="yyyy-MM-dd" Width="80px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="확정일자">
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="UPDATE_DATE" Key="UPDATE_DATE" Format="yyyy-MM-dd" Width="80px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="수정일자">
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Footer>
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
                                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                                                                    <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                                </HeaderStyleDefault>
                                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                                </EditCellStyleDefault>
                                                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                                                                <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
                                                                                <ClientSideEvents DblClickHandler="DblClickHandler"/>
                                                                                
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
                                                            </table>
                                                        </td>
                                                    </tr>            
                                                </table>
                                                <table  style="width: 100%; height: 40PX;" border="0" cellpadding="0" cellspacing="0" >
                                                    <tr>
                                                        <td style="padding-left:5px;">                                                            
                                                            <img src='../Images/status/E.gif' border="0" alt=""/>&nbsp;확정&nbsp;
                                                            <img src='../Images/status/N.gif' border="0" alt=""/>&nbsp;미확정
                                                        </td>                                                    
                                                        <td align="right"  style="padding-right:5px;">
                                                            <a href="#null" onclick="window.close();"><img src="../images/btn/b_003.gif" border="0" alt=""/></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>      

    <script type="text/javascript">gfWinFocus();</script>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </form>
</body>
</html>