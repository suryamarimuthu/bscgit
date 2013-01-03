    <%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="EST110104_01M1.aspx.cs" Inherits="EST110104_01M1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.3)" />
<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.3)" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript" language="javascript">  
//<!--

    function doSettingValueInCell(ugrid_Id, fromkey_point, fromkey_point_list, fromkey_grade, row_no, point, point_list) {

        //alert(point_list);
        var oGrid = opener.igtbl_getGridById(ugrid_Id);
        
        var oRows = oGrid.Rows;
        var oRow = oRows.getRow(row_no);


        oRow.getCellFromKey("SCORE_MT").setValue(point);
        oRow.getCellFromKey("SCORE_ORI").setValue(point);

        var score_dt = oRow.getCellFromKey("SCORE_DT").getValue();
        var score_mt = point
        var ratio_dt = oRow.getCellFromKey("RATIO_DT").getValue() / 100.0;
        var ratio_mt = oRow.getCellFromKey("RATIO_MT").getValue() / 100.0;


        var calc_dt = score_dt * ratio_dt;
        var calc_mt = score_mt * ratio_mt;


        var finalPoint = calc_dt + calc_mt;
        
        oRow.getCellFromKey(fromkey_point).setValue(finalPoint);//EST_DATA에 저장
        oRow.getCellFromKey(fromkey_point_list).setValue(point_list);
        oRow.getCellFromKey(fromkey_grade).setValue('');
//        alert(fromkey_point_list);
//        alert(point_list);
        self.close();
    }


    function doClosing(){
        self.close();
    }

//-->  
</script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();" id="iBtnQtnList">
<form id="form1" runat="server">    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%">
        <asp:HiddenField ID="hdnEstTermID" runat="server" />
        <asp:HiddenField ID="hdnKpiId" runat="server" />
        <asp:HiddenField ID="hdnYMD" runat="server" />
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr> 
                    <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td  style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t12.gif" /></td>
                                <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif" /></td>
                            </tr>
                        </table>
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
        <tr class="cssPopContent" ><%--style="height:100%;"--%>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                  <tr>
                    <td style="width:40%; height:25px;">
                        <table  cellpadding="0" cellspacing="0" border="0" style="height:98%; width:100%;">
                            <tr>
                                <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="평가기준"/></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width:1%;">
                        <asp:Literal ID="ltrScript" runat="server" Text="" ></asp:Literal>
                    </td>
                    <td style="width:59%; height:25px;">
                        <table  cellpadding="0" cellspacing="0" border="0" style="height:98%; width:100%;">
                            <tr>
                                <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="평가항목"/></td>
                            </tr>
                        </table>
                    </td>
                  </tr>
                  <tr>
                    <td>
                      <asp:Panel ID="pnlBasis" runat="server" ScrollBars="auto" CssClass="cssDivLayout">
                        <asp:Literal runat="server" ID="ltrEstBasis"></asp:Literal>
                      </asp:Panel>
                    </td>
                    <td style="width:1%;">
                    </td>
                     <td style="padding-left:0px;">
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                         
                          <tr>
                            <td style="height:100%;">
                              <ig:ultrawebgrid id="ugrdQuestionList" runat="server" height="100%" width="100%" OnInitializeLayout="ugrdQuestionList_InitializeLayout" OnInitializeRow="ugrdQuestionList_InitializeRow"  > 
                                 <Bands>
                                  <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="입력구분" Key="ITYPE" Hidden="True" Width="40px" AllowUpdate="No">
                                            <Header Caption="입력구분"></Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                            Key="ESTTERM_REF_ID" AllowUpdate="No">
                                            <Header Caption="ESTTERM_REF_ID">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI_REF_ID" Hidden="True"
                                            Key="KPI_REF_ID" AllowUpdate="No">
                                            <Header Caption="KPI_REF_ID">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" HeaderText="EST_EMP_ID" Hidden="True"
                                            Key="EST_EMP_ID" AllowUpdate="No">
                                            <Header Caption="EST_EMP_ID">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" HeaderText="GROUP_REF_ID" Hidden="True"
                                            Key="GROUP_REF_ID" AllowUpdate="No">
                                            <Header Caption="GROUP_REF_ID">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Hidden="True"
                                            Key="YMD" AllowUpdate="No">
                                            <Header Caption="YMD">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EST_LEVEL" HeaderText="EST_LEVEL" Hidden="True"
                                            Key="EST_LEVEL" Width="40px" AllowUpdate="No">
                                            <Header Caption="EST_LEVEL">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EST_LEVEL_NAME" HeaderText="차수명"
                                            Key="EST_LEVEL_NAME" Width="70px" MergeCells="True" AllowUpdate="No" Hidden="true">
                                            <Header Caption="차수명">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle BackColor="WhiteSmoke"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="QUESTION_REF_ID" HeaderText="QUESTION_REF_ID" Hidden="True"
                                            Key="QUESTION_REF_ID" Width="60px" AllowUpdate="No">
                                            <Header Caption="QUESTION_REF_ID">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="ITEM_NAME" HeaderText="평가항목"
                                            Key="ITEM_NAME" Width="120px" AllowUpdate="No">
                                            <Header Caption="평가항목">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle BackColor="WhiteSmoke"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT" DataType="System.Double" NullText="0" Width="45px" AllowUpdate="No">
                                            <Header Caption="가중치" >
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Right" BackColor="WhiteSmoke"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Footer>
                                        </ig:UltraGridColumn>
<%--                                                        <ig:UltraGridColumn BaseColumnName="SCORE" HeaderText="점수" Key="SCORE" DataType="System.Double" NullText="0" Width="50px" AllowUpdate="Yes">
                                            <Header Caption="점수" >
                                                <RowLayoutColumnInfo OriginX="9" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="9" />
                                            </Footer>
                                        </ig:UltraGridColumn>--%>
                                        <ig:TemplatedColumn Key="TXTSCORE" BaseColumnName="SCORE" Width="80px" Hidden="true">
                                          <Header Caption="점수"></Header>
                                          <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                          <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                            <CellTemplate>
                                               <ig:webnumericedit id="txtScore" runat="server" Width="100%" Nullable="False" ValueText="0.0000"
                                                    MaxValue="1000000000" MinValue="0" ToolTip="평가점수" NegativeForeColor="Magenta"
                                                    Font-Size="10pt" Font-Names="Verdana" Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                                </ig:webnumericedit>
                                            </CellTemplate>
                                        </ig:TemplatedColumn>
                                        <ig:TemplatedColumn Key="DDLSCORE" BaseColumnName="SCORE_GRADE" Width="150px" NullText="ZZZ" Hidden="true">
                                          <Header Caption="점수"></Header>
                                          <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                          <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                            <CellTemplate>
                                                <asp:DropDownList ID="ddlScore" runat="server" Width="100%"></asp:DropDownList>
                                            </CellTemplate>
                                        </ig:TemplatedColumn>
                                        <ig:UltraGridColumn BaseColumnName="" HeaderText="점수" Type="DropDownList"
                                            Key="POINT" Width="120px" AllowUpdate="Yes">
                                            <Header Caption="점수">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle BackColor="WhiteSmoke"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                    </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout Version="4.00" 
                                                   AllowUpdateDefault="Yes" 
                                                   HeaderClickActionDefault="NotSet" 
                                                   Name="ugrdQuestionList" 
                                                   BorderCollapseDefault="Separate" 
                                                   RowSelectorsDefault="No" 
                                                   RowHeightDefault="23px" 
                                                   SelectTypeRowDefault="Single" 
                                                   TableLayout="Fixed" 
                                                   AutoGenerateColumns="False" 
                                                   AllowRowNumberingDefault="Continuous" 
                                                   StationaryMargins="HeaderAndFooter" 
                                                   CellClickActionDefault="Edit" >
                                              
                                        <%--<GroupByBox>
                                          <BoxStyle CssClass="GridGroupBoxStyle" />
                                        </GroupByBox>
                                        <Pager>
                                            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                            </PagerStyle>
                                        </Pager>--%>
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
            </td>
        </tr>
        <tr>
            <td class="cssPopBtnLine">
                <asp:ImageButton ID="iBtnConfirmOpinion" runat="server" ImageUrl="../images/btn/b_015.gif" OnClick="iBtnConfirmOpinion_Click" />
                <asp:ImageButton ID="iBtnCloseEstForm" ImageUrl="../images/btn/b_003.gif" runat="server" OnClick="iBtnClose_Click"  OnClientClick="return doClosing();" />
            </td>
        </tr>
        <tr>
            <td class="cssPopBottomLine">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                        <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                        <td style="width:50%; background-color:#FFFFFF"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</form>
</body>
</html>
