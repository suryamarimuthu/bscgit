<%@ Page Language="C#" MasterPageFile="~/_common/libNHIT/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC0605S1.aspx.cs" Inherits="BSC_BSC0605S1"%>

<asp:Content ID="Content3" ContentPlaceHolderID="Contents" Runat="Server">
<script src="/_common/js/jQuery/jquery-1.6.4.min.js" type="text/javascript"></script>
<script type="text/javascript">
    var Page = {
        Validate: function() {
            var files = $("input[type='file']");

            for (var i = 0; i < files.length; i++) {
                var full = files[i].value;
                if (full != "") {
                    var arrFull = full.split('\\');
                    var filename = arrFull[arrFull.length - 1];
                    var arrExtension = filename.split('.');
                    var extension = arrExtension[arrExtension.length - 1];
                    if (extension == "csv") {
                        return;
                    }
                    else {
                        alert("업로드 되지않는 파일 입니다.");
                        return false;
                    }
                }
            }
        },
        GridView: function(id, im) {
            var ids = "#" + id;
            var imgId = "#" + im;
            var divGrid = $(ids);
            var img = $(imgId);

            if (divGrid.css("display") == "none") {
                divGrid.show();
                img.attr("src", "/images/tree/exp.gif");
            }
            else {
                divGrid.hide();
                img.attr("src", "/images/tree/col.gif");
            }
        }
    }
</script>
<table cellpadding="0" cellspacing="0" border="0" width="99%" height="100%">
<tr>
    <td valign="top" style="height:20px;">
        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%; height:100%;">
        <tr>
            <td class="cssTblTitle" style="width:10%;">
                엑셀 템플릿 내려받기
            </td>
            <td class="cssTblContent">
                <asp:RadioButtonList runat="server" ID="rdoList" RepeatDirection="Horizontal">
                <asp:ListItem Value="0" >전사인력현황(NHIT_DASHBOARD_EMP)</asp:ListItem>
                <asp:ListItem Value="1" >인력정산정보(NHIT_DASHBOARD_EMP_MERGE)</asp:ListItem>
                <asp:ListItem Value="2" >경영현황(NHIT_DASHBOARD_MAIN)</asp:ListItem>
                <asp:ListItem Value="3" >프로젝트현황(NHIT_DASHBOARD_PMS)</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right;">
                <asp:ImageButton ID="btnDown" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_041.gif" OnClick="btnDown_Click" />
            </td>
        </tr>
        </table>
    </td>
</tr>
<tr><td style="height:10px;">&nbsp;</td></tr>
<tr>
    <td valign="top" style="height:100px;">
    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%; height:100px;">
        <tr>
            <td class="cssTblTitle" style="width:10%;">
                <span style="cursor:pointer;" onclick="Page.GridView('divGrid1', 'img1');">
                <img src="/images/tree/exp.gif" style="vertical-align:text-bottom;" alt="닫기" id="img1" />
                전사인력현황(NHIT_DASHBOARD_EMP)
                </span>
            </td>
            <td class="cssTblContent">
                <asp:FileUpload runat="server" ID="file1" Width="50%" />
            </td>
        </tr>
        <tr>
            <td class="cssTblTitle" style="width:10%;">
                <span style="cursor:pointer;" onclick="Page.GridView('divGrid2', 'img2');">
                <img src="/images/tree/exp.gif" style="vertical-align:text-bottom;" alt="닫기" id="img2" />
                인력정산정보(NHIT_DASHBOARD_EMP_MERGE)
                </span>
            </td>
            <td class="cssTblContent">
                <asp:FileUpload runat="server" ID="file2" Width="50%" />
            </td>
        </tr>
        <tr>
            <td class="cssTblTitle" style="width:10%;">
                <span style="cursor:pointer;" onclick="Page.GridView('divGrid3', 'img3');">
                <img src="/images/tree/exp.gif" style="vertical-align:text-bottom;" alt="닫기" id="img3" />
                경영현황(NHIT_DASHBOARD_MAIN)
                </span>
            </td>
            <td class="cssTblContent">
                <asp:FileUpload runat="server" ID="file3" Width="50%" />
            </td>
        </tr>
        <tr>
            <td class="cssTblTitle" style="width:10%;">
                <span style="cursor:pointer;" onclick="Page.GridView('divGrid4', 'img4');">
                <img src="/images/tree/exp.gif" style="vertical-align:text-bottom;" alt="닫기" id="img4" />
                프로젝트현황(NHIT_DASHBOARD_PMS)
                </span>
            </td>
            <td class="cssTblContent">
                <asp:FileUpload runat="server" ID="file4" Width="50%" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right;">
                <asp:ImageButton ID="btnUpload" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_053.gif" OnClick="btnUpload_Click" OnClientClick="return Page.Validate();" />
                <asp:ImageButton ID="btnReg" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_001.gif" OnClick="btnReg_Click"  />
            </td>
        </tr>
    </table>
    </td>
</tr>
<tr><td style="height:15px;">&nbsp;</td></tr>
<tr id="divGrid1"">
    <td style="height:100px;">
        <span style="font-weight:bold">전사인력현황(NHIT_DASHBOARD_EMP)</span>
        <ig:UltraWebGrid ID="grid1" runat="server" Width="100%" Height="100%">
        <Bands>
        <ig:UltraGridBand>
        <Columns>
            <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Width="100px" HeaderText="해당년도">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="CR_MONTH" Key="CR_MONTH" Width="100px" HeaderText="해당월">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="BONBU_NAME" Key="BONBU_NAME" Width="100px" HeaderText="본부명">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TEAM_NAME" Key="TEAM_NAME" Width="100px" HeaderText="팀명">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_B_NAME" Key="GRP_ONE_B_NAME" Width="100px" HeaderText="고객별 매출현황 구분">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_C_NAME" Key="GRP_ONE_C_NAME" Width="100px" HeaderText="사업유형별 매출현황 구분">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="PROJECT_NAME" Key="PROJECT_NAME" Width="100px" HeaderText="프로젝트명">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="100px" HeaderText="투입인력명">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_FULL" Key="RESULT_FULL" Width="100px" HeaderText="가득률">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_DONG" Key="RESULT_DONG" Width="100px" HeaderText="가동률">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_BDONG" Key="RESULT_BDONG" Width="100px" HeaderText="비가동">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
        </Columns>
        </ig:UltraGridBand>
        </Bands>
         <DisplayLayout CellPaddingDefault="0" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
            AllowDeleteDefault="No" AllowSortingDefault="No" BorderCollapseDefault="Separate"
            StationaryMargins="Header" HeaderClickActionDefault="NotSet" Name="grid1" RowHeightDefault="20px"
            RowSelectorsDefault="No" SelectTypeRowDefault="None" Version="4.00" ViewType="Flat"
            CellClickActionDefault="CellSelect" TableLayout="Fixed" AutoGenerateColumns="False" OptimizeCSSClassNamesOutput="False">
            <RowStyleDefault CssClass="GridRowStyle" />
            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
            </SelectedRowStyleDefault>
            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
            </RowAlternateStyleDefault>
            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
            <HeaderStyleDefault CssClass="GridHeaderStyle">
            </HeaderStyleDefault>
            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
            </FrameStyle>
        </DisplayLayout>
        </ig:UltraWebGrid>
      
    </td>
</tr>
<tr><td style="height:20px;">&nbsp;</td></tr>
<tr id="divGrid2">
    <td style="height:100px;">
        <span style="font-weight:bold">인력정산정보(NHIT_DASHBOARD_EMP_MERGE)</span>
        <ig:UltraWebGrid ID="grid2" runat="server" Width="100%" Height="100%">
        <Bands>
        <ig:UltraGridBand>
        <Columns>
            <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Width="100px" HeaderText="해당년도">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="CR_MONTH" Key="CR_MONTH" Width="100px" HeaderText="해당월">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TARGET_FULL_RATE" Key="TARGET_FULL_RATE" Width="100px" HeaderText="인력정산 목표가득률">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_FULL_RATE" Key="RESULT_FULL_RATE" Width="100px" HeaderText="인력정산 가득률">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_DONG_RATE" Key="RESULT_DONG_RATE" Width="100px" HeaderText="인력정산 가동률">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_BDONG_RATE" Key="RESULT_BDONG_RATE" Width="100px" HeaderText="인력정산 비가동">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TARGET_DONG_RATE" Key="TARGET_DONG_RATE" Width="100px" HeaderText="인력정산 목표가동률">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_FULL_RATE_MS" Key="RESULT_FULL_RATE_MS" Width="100px" HeaderText="인력정산 가득률(월)">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_DONG_RATE_MS" Key="RESULT_DONG_RATE_MS" Width="100px" HeaderText="인력정산 가동률(월)">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_BDONG_RATE_MS" Key="RESULT_BDONG_RATE_MS" Width="100px" HeaderText="인력정산 비가동(월)">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>

        </Columns>
        </ig:UltraGridBand>
        </Bands>
         <DisplayLayout CellPaddingDefault="0" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
            AllowDeleteDefault="No" AllowSortingDefault="No" BorderCollapseDefault="Separate"
            StationaryMargins="Header" HeaderClickActionDefault="NotSet" Name="grid1" RowHeightDefault="20px"
            RowSelectorsDefault="No" SelectTypeRowDefault="None" Version="4.00" ViewType="Flat"
            CellClickActionDefault="CellSelect" TableLayout="Fixed" AutoGenerateColumns="False" OptimizeCSSClassNamesOutput="False">
            <%--<RowStyleDefault CssClass="GridRowStyle" BorderColor="White" />
            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
            </SelectedRowStyleDefault>
            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
            </RowAlternateStyleDefault>
            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
            <HeaderStyleDefault CssClass="GridHeaderStyle">
            </HeaderStyleDefault>
            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
            </FrameStyle>--%>
            <RowStyleDefault CssClass="GridRowStyle" />
            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
            </SelectedRowStyleDefault>
            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
            </RowAlternateStyleDefault>
            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
            <HeaderStyleDefault CssClass="GridHeaderStyle">
            </HeaderStyleDefault>
            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
            </FrameStyle>
        </DisplayLayout>
        </ig:UltraWebGrid>
    </td>
</tr>
<tr><td style="height:20px;">&nbsp;</td></tr>
<tr id="divGrid3">
    <td style="height:100px;">
        <span style="font-weight:bold">경영현황(NHIT_DASHBOARD_MAIN)</span>
        <ig:UltraWebGrid ID="grid3" runat="server" Width="100%" Height="100%">
        <Bands>
        <ig:UltraGridBand>
        <Columns>
             <ig:UltraGridColumn BaseColumnName="GRP_ONE_CODE" Key="GRP_ONE_CODE" Width="100px" HeaderText="대분류코드">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_NAME" Key="GRP_ONE_NAME" Width="100px" HeaderText="대분류명칭">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_TWO_CODE" Key="GRP_TWO_CODE" Width="100px" HeaderText="중분류코드">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_TWO_NAME" Key="GRP_TWO_NAME" Width="100px" HeaderText="중분류명칭">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_THREE_CODE" Key="GRP_THREE_CODE" Width="100px" HeaderText="손익항목코드">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_THREE_NAME" Key="GRP_THREE_NAME" Width="100px" HeaderText="손익항목명">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Width="100px" HeaderText="해당년도">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="CR_MONTH" Key="CR_MONTH" Width="100px" HeaderText="해당월">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TARGET_YEAR" Key="TARGET_YEAR" Width="100px" HeaderText="년간목표">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="100px" HeaderText="목표">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="100px" HeaderText="실적">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="DAL_RATE" Key="DAL_RATE" Width="100px" HeaderText="달성률">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TG_GUBUN" Key="TG_GUBUN" Width="100px" HeaderText="목표구분">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
        </Columns>
        </ig:UltraGridBand>
        </Bands>
         <DisplayLayout CellPaddingDefault="0" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
            AllowDeleteDefault="No" AllowSortingDefault="No" BorderCollapseDefault="Separate"
            StationaryMargins="Header" HeaderClickActionDefault="NotSet" Name="grid1" RowHeightDefault="20px"
            RowSelectorsDefault="No" SelectTypeRowDefault="None" Version="4.00" ViewType="Flat"
            CellClickActionDefault="CellSelect" TableLayout="Fixed" AutoGenerateColumns="False" OptimizeCSSClassNamesOutput="False">
            <RowStyleDefault CssClass="GridRowStyle" />
            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
            </SelectedRowStyleDefault>
            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
            </RowAlternateStyleDefault>
            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
            <HeaderStyleDefault CssClass="GridHeaderStyle">
            </HeaderStyleDefault>
            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
            </FrameStyle>
        </DisplayLayout>
        </ig:UltraWebGrid>
    </td>
</tr>
<tr><td style="height:20px;">&nbsp;</td></tr>
<tr id="divGrid4">
    <td style="height:100px;">
        <span style="font-weight:bold">프로젝트현황(NHIT_DASHBOARD_PMS)</span>
        <ig:UltraWebGrid ID="grid4" runat="server" Width="100%" Height="100%">
        <Bands>
        <ig:UltraGridBand>
        <Columns>
            <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Width="100px" HeaderText="해당년도">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="PROJECT_CODE" Key="PROJECT_CODE" Width="100px" HeaderText="프로젝트코드">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="PROJECT_NAME" Key="PROJECT_NAME" Width="100px" HeaderText="계약명">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GUBUN_ONE" Key="GUBUN_ONE" Width="100px" HeaderText="구분_1">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_C_CODE" Key="GRP_ONE_C_CODE" Width="100px" HeaderText="사업유형구분코드">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_C_NAME" Key="GRP_ONE_C_NAME" Width="100px" HeaderText="사업유형구분명칭">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_B_CODE" Key="GRP_ONE_B_CODE" Width="100px" HeaderText="고객사코드">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_B_NAME" Key="GRP_ONE_B_NAME" Width="100px" HeaderText="고객사명">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_D_CODE" Key="GRP_ONE_D_CODE" Width="100px" HeaderText="본부코드">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="GRP_ONE_D_NAME" Key="GRP_ONE_D_NAME" Width="100px" HeaderText="본부명칭">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TEAM_NAME" Key="TEAM_NAME" Width="100px" HeaderText="팀명칭">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="PLAN_STR" Key="PLAN_STR" Width="100px" HeaderText="계획시작일">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="PLAN_END" Key="PLAN_END" Width="100px" HeaderText="계획종료일">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="END_YN" Key="END_YN" Width="100px" HeaderText="종료여부">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="GE_COMP" Key="GE_COMP" Width="100px" HeaderText="계약업체">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="BUNLYU_CODE" Key="BUNLYU_CODE" Width="100px" HeaderText="분류코드">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="MECHUL" Key="MECHUL" Width="100px" HeaderText="매출액">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="SANPUM" Key="SANPUM" Width="100px" HeaderText="상품매출원가">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="JAERYO" Key="JAERYO" Width="100px" HeaderText="재료비">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="OYJU" Key="OYJU" Width="100px" HeaderText="외주비">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="JICK_EMP" Key="JICK_EMP" Width="100px" HeaderText="직접인건비">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="JICK_KYUNG" Key="JICK_KYUNG" Width="100px" HeaderText="직접경비">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="HANGAE" Key="HANGAE" Width="100px" HeaderText="한계이익">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="BUN_EMP" Key="BUN_EMP" Width="100px" HeaderText="본부간접인건비">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
             <ig:UltraGridColumn BaseColumnName="BUN_KYUNG" Key="BUN_KYUNG" Width="100px" HeaderText="본부간접경비">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="JUNSA_EMP" Key="JUNSA_EMP" Width="100px" HeaderText="전사간접인건비">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="JUNSA_KYUNG" Key="JUNSA_KYUNG" Width="100px" HeaderText="전사간접경비">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="MECHUL_TOT" Key="MECHUL_TOT" Width="100px" HeaderText="매출총이익">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="PANME_EMP" Key="PANME_EMP" Width="100px" HeaderText="판매관리비(人)">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="PANME_KYUNG" Key="PANME_KYUNG" Width="100px" HeaderText="판매관리비(경비)">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="YOUNGUP" Key="YOUNGUP" Width="100px" HeaderText="영업이익">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
        </Columns>
        </ig:UltraGridBand>
        </Bands>
         <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="NotSet" Name="ugrdGroupList" RowHeightDefault="20px"
                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
                        ReadOnly="LevelTwo" OptimizeCSSClassNamesOutput="False">
         <RowStyleDefault  CssClass="GridRowStyle" />
         <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
         <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
         <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
         <HeaderStyleDefault CssClass="GridHeaderStyle"></HeaderStyleDefault>                                   
         <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
        </DisplayLayout>
        </ig:UltraWebGrid>
    </td>
</tr>
</table>
</asp:Content>


