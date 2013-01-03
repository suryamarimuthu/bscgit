<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST_Q_PAGE_04.aspx.cs" Inherits="EST_EST_Q_PAGE_04" %>

<html>
<head>
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
        function CheckAgree() {
            if (confirm('평가질의에 동의하십니까?')) {
                if (document.getElementById('txtFeedbackComment').value == '') {
                    alert('평가자에 대한 피드백을 등록하세요.');
                    document.getElementById('txtFeedbackComment').focus();
                    return false;
                }

                return true;
            }

            return false;
        }

        function CheckReject() {
            if (confirm('평가질의에 거절하십니까?')) {
                if (document.getElementById('txtFeedbackComment').value == '') {
                    alert('평가자에 대한 거절 이유 및 기타의견을 등록하세요.');
                    document.getElementById('txtFeedbackComment').focus();
                    return false;
                }

                return true;
            }

            return false;
        }

        function doRejection() {
            return confirm("평가거부 하시겠습니까?");
        }
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
        <tr>
            <td style="height: 40px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                        <td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="Label7" runat="server" CssClass="cssPopTitleTxt" Text="다면평가" />
                        </td>
                        <td align="right" valign="top">
                            <img alt="" src="../images/title/popup_img.gif" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="4" bgcolor="FFFFFF">
                        </td>
                        <td width="50%" bgcolor="FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="cssTblTitle">
                                        평가기간
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblEstTermName" runat="server"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        평가명
                                    </td>
                                    <td class="cssTblContent" width="20%">
                                        <asp:Label ID="lblEstName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        평가자
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblEstEmp" runat="server"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        피평가자
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblTgtEmp" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        질의평가그룹
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblQobjName" runat="server"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        평가점수 / 총 배점
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblPoint" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <ig:UltraWebGrid ID="ugrdEstQuestion" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdEstQuestion_InitializeLayout"
                                OnInitializeRow="ugrdEstQuestion_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="Q_DFN_ID" Key="Q_DFN_ID" HeaderText="Q_DFN_ID"
                                                Hidden="true" />
                                            <ig:UltraGridColumn BaseColumnName="Q_DFN_NAME" Key="Q_DFN_NAME" HeaderText="Q_DFN_NAME"
                                                MergeCells="true" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center" Wrap="true">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="Q_SBJ_ID" Key="Q_SBJ_ID" HeaderText="Q_SBJ_ID"
                                                Hidden="true" />
                                            <ig:UltraGridColumn BaseColumnName="Q_SBJ_NAME" Key="Q_SBJ_NAME" HeaderText="Q_SBJ_NAME"
                                                MergeCells="true" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="LEFT" Wrap="true">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="Q_SBJ_DEFINE" Key="Q_SBJ_DEFINE" HeaderText="평가내용"
                                                Width="280px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left" Wrap="true">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="Q_ITEM" Key="Q_ITEM" HeaderText="평가 결과" Width="300px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <CellTemplate>
                                                    <asp:RadioButtonList ID="rdoQuestionItem" runat="server" DataTextField="Q_ITEM_NAME"
                                                        DataValueField="Q_ITM_ID">
                                                    </asp:RadioButtonList>
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout RowHeightDefault="20px" AutoGenerateColumns="False" RowSelectorsDefault="No"
                                    OptimizeCSSClassNamesOutput="False" ReadOnly="LevelTwo">
                                    <RowStyleDefault CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                    </SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                    </RowAlternateStyleDefault>
                                    <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle">
                                    </HeaderStyleDefault>
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                    </FrameStyle>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                    <%--
                    <!--아직 다면평가 전용 팝업이라 기능 비활성시킴-->
                    <tr id="rowTGT_EMP_FEEDBACK" runat="server" visible="false">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="피평가자 피드백 작성" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtFeedbackComment" runat="server" TextMode="MultiLine" Height="45px" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                    <tr class="cssPopBtnLine">
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left: 5px;">
                                        <asp:ImageButton ID="iBtnReject" runat="server" ImageUrl="../images/btn/btn_refusal.gif" OnClick="iBtnReject_Click" OnClientClick="return doRejection();" Visible="false" />
                                    </td>
                                    <td align="right" height="40">
                                        <%--
                                        <!--아직 다면평가 전용 팝업이라 기능 비활성시킴-->
                                        <asp:ImageButton ID="iBtnFeedbackAgree" runat="server" ImageUrl="../images/btn/b_176.gif" CommandName="BIZ_Q_FEEDBACK_AGREE" OnClick="iBtnFeedbackAgree_Click" Visible="false" />
                                        <asp:ImageButton ID="iBtnFeedbackReject" runat="server" ImageUrl="../images/btn/btn_objection.gif" CommandName="BIZ_Q_FEEDBACK_REJECT" OnClick="iBtnFeedbackReject_Click" Visible="false" />
                                        <asp:ImageButton ID="iBtnSaveOpinion" runat="server" ImageUrl="../images/btn/b_166.gif" CommandName="BIZ_Q_SAVE_OPINION" OnClick="iBtnSaveOpinion_Click" Visible="false" />--%>
                                        <asp:ImageButton ID="iBtnSaveEst" runat="server" ImageUrl="../images/btn/b_167.gif" OnClick="iBtnSaveEst_Click" CommandName="BIZ_Q_SAVE_EST" Visible="false" />
                                        <a href="#null" onclick="window.close();"><img src="../images/btn/b_003.gif" /></a>
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
    <asp:LinkButton ID="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:LinkButton>
    <SJ:SmartScroller ID="SmartScroller1" runat="server">
    </SJ:SmartScroller>

    <script type="text/javascript">        gfWinFocus();</script>

    <!--- MAIN END --->
    </form>
</body>
</html>
