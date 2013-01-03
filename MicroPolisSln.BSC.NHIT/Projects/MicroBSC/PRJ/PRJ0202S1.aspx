<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0202S1.aspx.cs" Inherits="PRJ_PRJ0202S1" %>

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
                                                    <td height="40" valign="top"><img src="../images/title/popup_t79.gif" ></td>
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
                            <td valign="top" class="box_td03">
                                <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0" class="box_ta01">
                                    <tr style="height:100%;">
                                        <td valign="top" align="center">
                                            <div>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 98%; height:100%;">
                                                    <tr style="height:100%;">
                                                        <td>
                                                            <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Height="300px" 
                                                                Width="100%">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                                                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'ugrdPrjList');" />
                                                                                </HeaderTemplate>
                                                                                <CellTemplate>
                                                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                                                </CellTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                                FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID"
                                                                                Width="40px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Header Caption="PRJ_REF_ID">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="PRJ_CODE" HeaderText="사업코드" Key="PRJ_CODE"
                                                                                Width="60px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="사업코드">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="OWNER_DEPT_NAME" EditorControlID="" FooterText=""
                                                                                Format="" HeaderText="주관부서" Key="OWNER_DEPT_NAME" Width="130px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Left">
                                                                                </CellStyle>
                                                                                <Header Caption="주관부서">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="PRJ_NAME" EditorControlID="" FooterText=""
                                                                                Format="" HeaderText="사업명" Key="PRJ_NAME" Width="180px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ValueList DisplayStyle="NotSet">
                                                                                </ValueList>
                                                                                <CellStyle HorizontalAlign="Left">
                                                                                </CellStyle>
                                                                                <Header Caption="사업명">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="DEFINITION" HeaderText="사업정의" Hidden="True"
                                                                                Key="DEFINITION">
                                                                                <Header Caption="사업정의">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="REF_STG" HeaderText="전략목표" Hidden="True" Key="REF_STG">
                                                                                <Header Caption="전략목표">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EFFECTIVENESS" HeaderText="기대효과" Hidden="True"
                                                                                Key="EFFECTIVENESS">
                                                                                <Header Caption="기대효과">
                                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="RANGE" HeaderText="사업범위" Hidden="True" Key="RANGE">
                                                                                <Header Caption="사업범위">
                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="REQUEST_DEPT" HeaderText="요청부서기관" Hidden="True"
                                                                                Key="REQUEST_DEPT">
                                                                                <Header Caption="요청부서기관">
                                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="PRIORITY" HeaderText="중요도" Hidden="True" Key="PRIORITY">
                                                                                <Header Caption="중요도">
                                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="TOTAL_BUDGET" HeaderText="총사업비" Hidden="True"
                                                                                Key="TOTAL_BUDGET">
                                                                                <Header Caption="총사업비">
                                                                                    <RowLayoutColumnInfo OriginX="11" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="11" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="INTERESTED_PARTIES" HeaderText="이해관계자" Hidden="True"
                                                                                Key="INTERESTED_PARTIES">
                                                                                <Header Caption="이해관계자">
                                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="OWNER_EMP_NAME" HeaderText="책임자" Key="OWNER_EMP_NAME"
                                                                                Width="50px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Header Caption="책임자">
                                                                                    <RowLayoutColumnInfo OriginX="13" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="13" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="PRJ_TYPE_NAME" HeaderText="사업유형" Key="PRJ_TYPE_NAME"
                                                                                Width="90px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Left">
                                                                                </CellStyle>
                                                                                <Header Caption="사업유형">
                                                                                    <RowLayoutColumnInfo OriginX="14" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="14" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="PRJ_TYPE" HeaderText="사업유형" Hidden="True"
                                                                                Key="PRJ_TYPE">
                                                                                <Header Caption="사업유형">
                                                                                    <RowLayoutColumnInfo OriginX="15" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="15" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="PLAN_START_DATE" DataType="System.DateTime"
                                                                                EditorControlID="" FooterText="" HeaderText="시작일자" Key="PLAN_START_DATE" Width="70px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Header Caption="시작일자">
                                                                                    <RowLayoutColumnInfo OriginX="16" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="16" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="PLAN_END_DATE" DataType="System.DateTime"
                                                                                EditorControlID="" FooterText="" HeaderText="종료일자" Key="PLAN_END_DATE" Width="70px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Header Caption="종료일자">
                                                                                    <RowLayoutColumnInfo OriginX="17" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="17" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="ACTUAL_START_DATE" DataType="System.DateTime"
                                                                                EditorControlID="" FooterText="" HeaderText="시작일자" Hidden="True" Key="ACTUAL_START_DATE"
                                                                                Width="70px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Header Caption="시작일자">
                                                                                    <RowLayoutColumnInfo OriginX="18" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="18" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="ACTUAL_END_DATE" DataType="System.DateTime"
                                                                                EditorControlID="" FooterText="" HeaderText="종료일자" Hidden="True" Key="ACTUAL_END_DATE"
                                                                                Width="70px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Header Caption="종료일자">
                                                                                    <RowLayoutColumnInfo OriginX="19" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="19" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="ISDELETE" EditorControlID="" FooterText=""
                                                                                HeaderText="사용여부" Hidden="True" Key="ISDELETE" Width="35px">
                                                                                <CellTemplate>
                                                                                    <asp:Image ID="imgUseYn" runat="server" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif" />
                                                                                </CellTemplate>
                                                                                <HeaderStyle Wrap="True" />
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Header Caption="사용여부">
                                                                                    <RowLayoutColumnInfo OriginX="20" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="20" />
                                                                                </Footer>
                                                                            </ig:TemplatedColumn>
                                                                        </Columns>
                                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                        </RowTemplateStyle>
                                                                    </ig:UltraGridBand>
                                                                </Bands>
                                                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                                    AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                                    HeaderClickActionDefault="SortMulti" Name="ugrdPrjList" RowHeightDefault="20px"
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
                                                                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="300px"
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
                                                            </ig:UltraWebGrid>
                                                        </td>
                                                    </tr>
                                                    <tr align="right" class="cssPopBtnLine">
                                                        <td>
                                                            <ASP:IMAGEBUTTON id="ibnSave" runat="server" imageurl="../images/btn/b_094.gif" OnClick="ibnSave_Click"/>
	                                                        <a href="javascript:window.close();">
	                                                            <img src="../images/btn/b_003.gif" border=0/>
	                                                        </a>
	                                                    </td>
                                                    </tr>
                                                </table>
                                                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr> 
                                        <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                                        <td style="width:50%; background-color:#FFFFFF"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>      
    <script>gfWinFocus();</script>
    <!--- MAIN END --->
    </form>
</body>
</html>
