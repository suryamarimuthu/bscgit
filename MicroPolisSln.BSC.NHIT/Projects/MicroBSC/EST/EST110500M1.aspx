<%@ Page Language="C#" AutoEventWireup="true"  validateRequest="false" EnableEventValidation="false" CodeFile="EST110500M1.aspx.cs" Inherits="EST110500M1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.3)" />
<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.3)" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">
    function copyEstComment() {
        alert(document.getElementById("hdfEstComment").value);
        
        return false;
    }
</script>
<style type="text/css">
.rdoBtnListItem td { width:33%;}
</style>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();">
<form id="form1" runat="server">    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr> 
                    <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td style="width:180px; background-image:url(../images/title/popup_title.gif);" class="cssPopTitleArea">
                                  <asp:Label ID="Label2" runat="server" CssClass="cssPopTitleTxt" Text="자기평가서"></asp:Label>
                                </td>
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
        <tr class="cssPopContent">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="tableBorder">
                                <tr>
                                    <td class="cssTblTitle">평가기간</td>
                                    <td class="cssTblContent"><asp:Label ID="lblEstTerm" runat="server"></asp:Label></td>
                                    <td class="cssTblTitle">평가유형</td>
                                    <td class="cssTblContent"><asp:Label ID="lblEstName" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">자기평가자</td>
                                    <td class="cssTblContent"><asp:Label ID="lblEstEmp" runat="server"></asp:Label></td>
                                    <td class="cssTblTitle">직위</td>
                                    <td class="cssTblContent"><asp:Label ID="lblEstEmpClass" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">최종 작성일</td>
                                    <td class="cssTblContent" style="border-right:none;"><asp:Label ID="lblUpdateDate" runat="server" Text=""></asp:Label></td>
                                    <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                    <td class="cssTblContent">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopTblBottomSpace">
                        <td>&nbsp;</td>
                    </tr>
                    <tr style="height:100%;">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                <tr>
                                    <td style="width:440px;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                        <tr>
                                                            <td style="width:15px;">
                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="자기평가 의견" />
                                                            </td>
                                                        </tr>
                                                    </table>                                                    
                                                </td>
                                            </tr>
                                            <tr style="height:50%;">
                                                <td>
                                                    <ig:UltraWebGrid ID="ugrdEstComment" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdEstComment_InitializeRow">
                                                        <Bands>
                                                            <ig:UltraGridBand>
                                                                <Columns>
                                                                    <ig:UltraGridColumn BaseColumnName="SELF_TOP_NM" Key="SELF_TOP_NM" HeaderText="구분" Width="90px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="SELF_TOP_ID" Key="SELF_TOP_ID" HeaderText="SELF_TOP_ID" Hidden="true">
                                                                    </ig:UltraGridColumn>
                                                                    <ig:TemplatedColumn BaseColumnName="EST_COMMENT" Key="EST_COMMENT" HeaderText="평가내용" Width="330px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <CellTemplate>
                                                                            <asp:RadioButtonList ID="rdoEstComment" runat="server" DataTextField="SELF_MID_NM" DataValueField="SELF_MID_ID" CssClass="rdoBtnListItem"></asp:RadioButtonList>
                                                                        </CellTemplate>
                                                                    </ig:TemplatedColumn>
                                                                </Columns>
                                                            </ig:UltraGridBand>
                                                        </Bands>
                                                        <DisplayLayout  RowHeightDefault="20px"
                                                                        AutoGenerateColumns="False"
                                                                        RowSelectorsDefault="No"
                                                                        ReadOnly="LevelTwo">                                                        
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
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                        <tr>
                                                            <td style="width:15px;">
                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label id="Label1" runat="server" style="font-weight:bold" text="인사상담사항(일,교육,건강,이동 등)" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height:50%;">
                                                <td>
                                                    <FCKeditorV2:FCKeditor ID="txtConsult"  runat="server" BasePath="../_common/FCKeditor/"
                                                        Height="100%" Width="100%">
                                                    </FCKeditorV2:FCKeditor>
                                                   <%-- <asp:TextBox ID="txtConsult" runat="server" TextMode="MultiLine" Height="100%" Width="100%"></asp:TextBox>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width:5px;"></td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                        <tr>
                                                            <td style="width:15px;">
                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label id="Label3" runat="server" style="font-weight:bold" text="자기평가 등록" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height:100%;">
                                                <td>
                                                    <ig:UltraWebGrid ID="ugrdEstQuestion" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdEstQuestion_InitializeLayout" OnInitializeRow="ugrdEstQuestion_InitializeRow">
                                                        <Bands>
                                                            <ig:UltraGridBand>
                                                                <Columns>
                                                                    <ig:UltraGridColumn BaseColumnName="Q_DFN_ID" Key="Q_DFN_ID" HeaderText="Q_DFN_ID" Hidden="true" />
                                                                    <ig:UltraGridColumn BaseColumnName="Q_DFN_NAME" Key="Q_DFN_NAME" HeaderText="Q_DFN_NAME" MergeCells="true" Width="70px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center" Wrap="true">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="Q_SBJ_ID" Key="Q_SBJ_ID" HeaderText="Q_SBJ_ID" Hidden="true" />
                                                                    <ig:UltraGridColumn BaseColumnName="Q_SBJ_NAME" Key="Q_SBJ_NAME" HeaderText="Q_SBJ_NAME" MergeCells="true" Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="LEFT" Wrap="true">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="Q_SBJ_DEFINE" Key="Q_SBJ_DEFINE" HeaderText="평가내용" Width="310px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left" Wrap="true">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:TemplatedColumn BaseColumnName="Q_ITEM" Key="Q_ITEM" HeaderText="자기평가 결과" Width="280px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <CellTemplate>
                                                                            <asp:RadioButtonList ID="rdoQuestionItem" runat="server" DataTextField="Q_ITEM_NAME" DataValueField="Q_ITM_ID"></asp:RadioButtonList>
                                                                        </CellTemplate>
                                                                    </ig:TemplatedColumn>
                                                                </Columns>
                                                            </ig:UltraGridBand>
                                                        </Bands>
                                                        <DisplayLayout  RowHeightDefault="20px"
                                                                        AutoGenerateColumns="False"
                                                                        RowSelectorsDefault="No"
                                                                        OptimizeCSSClassNamesOutput="False"
                                                                        ReadOnly="LevelTwo">                                                        
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
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                        <tr>
                                                            <td style="width:15px;">
                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label id="Label4" runat="server" style="font-weight:bold" text="평가자 정보" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height:80px;">
                                                <td>
                                                    <ig:UltraWebGrid ID="ugrdEstEmpList" runat="server" Width="100%" Height="100%">
                                                        <Bands>
                                                            <ig:UltraGridBand>
                                                                <Columns>
                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_NAME" Key="ESTTERM_STEP_NAME" HeaderText="구분" Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" Key="EST_DEPT_NAME" HeaderText="부서" Width="200px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="EST_POS_CLS" Key="EST_POS_CLS" HeaderText="직급" Width="80px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="EST_POS_RNK" Key="EST_POS_RNK" HeaderText="직위" Width="80px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="EST_EMP_NAME" Key="EST_EMP_NAME" HeaderText="성명" Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                </Columns>
                                                            </ig:UltraGridBand>
                                                        </Bands>
                                                        <DisplayLayout  RowHeightDefault="20px"
                                                                        AutoGenerateColumns="False"
                                                                        RowSelectorsDefault="No"
                                                                        OptimizeCSSClassNamesOutput="False">                                                        
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
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="iBtnSave" runat="server" ImageUrl="/images/btn/b_tp07.gif" 
                                onclick="iBtnSave_Click" />
                            <img src="../images/btn/b_003.gif" onclick="window.close();" style="cursor: pointer;"
                                alt="닫기" />
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
        <asp:HiddenField ID="hdfEstComment" runat="server" />
        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </table>
</form>
</body>
</html>
