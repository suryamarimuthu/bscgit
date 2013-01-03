<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110500M2.aspx.cs" Inherits="EST_EST110500M2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.3)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.3)" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <style type="text/css">
        .rdoBtnListItem td
        {
            width: 33%;
        }
    </style>

    <script type="text/javascript">
        function OpenSelfTGT() {

            var popup_path = "EST110500M1.aspx";

            var open_path = popup_path + "?"
                    + "COMP_ID=<%=COMP_ID %>"
                    + "&EST_ID=<%=EST_ID %>"
                    + "&ESTTERM_REF_ID=<%=ESTTERM_REF_ID %>"
                    + "&ESTTERM_SUB_ID=<%=ESTTERM_SUB_ID %>"
                    + "&ESTTERM_STEP_ID=<%=ESTTERM_STEP_ID %>"
                    + "&EST_DEPT_ID=<%=EST_DEPT_ID %>"
                    + "&EST_EMP_ID=<%=EST_EMP_ID %>"
                    + "&TGT_DEPT_ID=<%=TGT_DEPT_ID %>"
                    + "&TGT_EMP_ID=<%=TGT_EMP_ID %>"
                    + "&STATUS_ID=<%=STATUS_ID %>"
                    + "&EST_TGT_TYPE=TGT";


            var width = "1230";
            var height = "700";
            var scroll = "no";
            gfOpenWindow(open_path
                    , width
                    , height
                    , scroll
                    , 'no'
                    , 'POP_UP_TGT');

            return false;
        }

        function ValidatePoint(gridName, cellId, key) {
            var objTbl = igtbl_getGridById(gridName);
            var objRow = igtbl_getRowById(cellId);
            cntCur = objRow.getIndex();
            var objTmpRow = objTbl.Rows.getRow(cntCur);
            var currentValue = parseInt(objTmpRow.getCell(8).getValue());
            if (currentValue > 5 || currentValue < 1) {
                objTmpRow.getCell(8).setValue("0");
            }
        }
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td valign="top" style="background-image: url(../images/title/popup_t_bg.gif); height: 40px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 180px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="Label2" runat="server" CssClass="cssPopTitleTxt" Text="역량평가 평가표"></asp:Label>
                        </td>
                        <td align="right" valign="top">
                            <img alt="" src="../images/title/popup_img.gif" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;" class="tableBorder">
                                            <tr>
                                                <td class="cssTblTitle">
                                                    평가기간
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:Label ID="lblEstTerm" runat="server"></asp:Label>
                                                </td>
                                                <td class="cssTblTitle">
                                                    평가명
                                                </td>
                                                <td class="cssTblContent">
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
                                                    <asp:Label ID="lblEstOtherEmp" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle">
                                                    질의평가그룹
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:Label ID="lblEstGroup" runat="server"></asp:Label>
                                                </td>
                                                <td class="cssTblTitle">
                                                    평가점수/총 배점
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:Label ID="lblPoint" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle">
                                                    최종 작성일
                                                </td>
                                                <td class="cssTblContent" style="border-right: none;">
                                                    <asp:Label ID="lblUpdateDate" runat="server"></asp:Label>
                                                </td>
                                                <td class="cssTblContent" style="width: 15%; border-left: none; border-right: none;">
                                                    &nbsp;
                                                </td>
                                                <td class="cssTblContent">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr >
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;" >
                                <tr>
                                    <td >
                                        <asp:Label ID="Label1" runat="server" Text = " 1차 평가 점수 범위 : 1.0 ~ 5.0 (소수 첫 째 자리까지 입력)" ForeColor="Red" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td class="cssPopBtnLine">
                                       <a href="#" onclick="return OpenSelfTGT()"><img src="../images/btn/b_314.gif" /></a>
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
                                                MergeCells="true" Width="80px">
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
                                            <ig:TemplatedColumn BaseColumnName="Q_FIRST" Key="Q_FIRST" HeaderText="1차 평가" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center" />
                                                <CellTemplate>
                                                    <ig:WebNumericEdit ID="Q_FIRST" runat="server" DataMode="Float" MaxValue="5.0" MinValue="1.0" MaxLength="3" NullText="0" Width="100%"></ig:WebNumericEdit>
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                  <DisplayLayout CellPaddingDefault="1" 
                                    AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="None" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="NotSet"
                                    Name="ugrdEstQuestion" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="NotSet"
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
                                    OptimizeCSSClassNamesOutput="False">
                       
                        <GroupByBox>
                            <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                        <ClientSideEvents AfterCellUpdateHandler="ValidatePoint" />
                    </DisplayLayout>
                            
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cssPopBtnLine">
                <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_167.gif" runat="server"
                    OnClick="iBtnInsert_Click" />
                <img src="../images/btn/b_003.gif" onclick="window.close();" style="cursor: pointer;"
                    alt="닫기" />
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:literal id="ltrScript" runat="server"></asp:literal>
    </form>
</body>
</html>
