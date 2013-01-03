<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0403S4.aspx.cs" Inherits="BSC_BSC0403S4" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script id="Infragistics" type="text/javascript">
    function ugrdKpiStatus_DblClickHandler(gridName, cellId){
        
        var row         = igtbl_getRowById(cellId);
        var intEST      = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var kpiID       = row.getCellFromKey("KPI_REF_ID").getValue();
        var strMM       = row.getCellFromKey("YMD").getValue();
        
        //POPUP_TYPE= E : 지표평가, R : 실적입력
        var url = 'BSC0304S2.aspx?iType=POP&KPI_REF_ID=' + kpiID+'&YMD='+strMM+'&ESTTERM_REF_ID='+intEST;

        location.href = url;
    }
    
    function showB(gubun)
    {
        var objScore   = document.getElementById ("plnScoreCard"); 
        var objLoadMap = document.getElementById ("plnDeptLoadMap"); 
        var bLoadMap   = document.getElementById ("bLoadMap"); 
        var bScoreCard = document.getElementById ("bScoreCard"); 
        
        if (gubun == '1')
        {
            objScore.style.display   = "none";
            objLoadMap.style.display = "inline";
            bLoadMap.style.display   = "none";
            bScoreCard.style.display = "inline";
        }
        else
        {
            objScore.style.display   = "inline";
            objLoadMap.style.display = "none";
            bLoadMap.style.display   = "inline";
            bScoreCard.style.display = "none";
        }
    }
    
    function initForm()
    {
        var objScore   = document.getElementById ("plnScoreCard"); 
        var objLoadMap = document.getElementById ("plnDeptLoadMap"); 
        var bLoadMap   = document.getElementById ("bLoadMap"); 
        var bScoreCard = document.getElementById ("bScoreCard"); 
        
            objScore.style.display   = "none";
            objLoadMap.style.display = "inline";
            bLoadMap.style.display   = "none";
            bScoreCard.style.display = "inline";
    }
    
    function OpenScoreCardPrint()
    {
        var EsttermRefID = "<%= this.IEstTermRefID %>";
        var intEstDeptID = "<%= this.IEstDeptID %>";
        var strYMD       = "<%= this.IYmd %>";
        var sSumType     = "<%= ISumType %>";
        var strURL       = "../BSC/BSC0403P4.aspx?ESTTERM_REF_ID="+EsttermRefID+"&EST_DEPT_REF_ID="+intEstDeptID+"&YMD="+strYMD+"&SUM_TYPE="+sSumType;
        
        gfOpenWindow(strURL, 880, 600,0,0,'BSC0403P4'); 
        return false;
    }
    
</script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus(); ">
<script type="text/javascript" language="javascript" src="../_common/js/LayerShowHide.js"></script>
  <form id="form1" runat="server">
     <div>
       <!--- MAIN START --->
         <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
           <tr>
             <td style="height:60px;">
                <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width:100%; height:100%;">
                  <tr>
                    <td style="width:75%">
                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width:100%; height:100%;">
                           <tr>
                               <td class="tabletitle2" align="center" style="width:85px; font-weight:bold; ">평&nbsp;가&nbsp;&nbsp;기&nbsp;간</td>
                               <td class="tableContent">
                                  <asp:DropDownList ID="ddlEstTermInfo" runat="server" CssClass="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" ></asp:DropDownList>
                                  <asp:DropDownList ID="ddlMonthInfo" runat="server" CssClass="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlMonthInfo_SelectedIndexChanged" ></asp:DropDownList>
                                  <asp:DropDownList ID="ddlSumType" runat="server" OnSelectedIndexChanged="ddlSumType_SelectedIndexChanged" AutoPostBack="True" CssClass="box01"></asp:DropDownList>
                                  <asp:dropdownlist id="ddlEstDept" CssClass="box01" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddlEstDept_SelectedIndexChanged"></asp:dropdownlist>
                                  <asp:ImageButton ID="iBtnLoadMap" runat="server" ImageUrl="../images/btn/b_060.gif" OnClick="btnLoadMap_Click" ImageAlign="AbsMiddle" />
                                  <asp:ImageButton ID="iBtnScoreCard" runat="server" ImageUrl="../images/btn/b_140.gif" OnClick="btnScoreCard_Click" ImageAlign="AbsMiddle" />
                                  <asp:ImageButton ID="iBtnGoDeptScore" runat="server" ImageUrl="../images/btn/b_137.gif" OnClick="iBtnGoDeptScore_Click" ImageAlign="AbsMiddle" />
                                   <asp:ImageButton ID="ImgBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false" 
                                       OnClick="ImgBtnPrint_Click" OnClientClick="return OpenScoreCardPrint();" ImageAlign="AbsMiddle" /></td>
                            </tr>
                            <tr>
                               <td class="tabletitle2" align="center"  style="width:85px; font-weight:bold;">평&nbsp;가&nbsp;&nbsp;조&nbsp;직</td>
                               <td class="tableContent">
                                    <asp:Label ID="lblEstDeptName" runat="server" Width="70%" BackColor="white" Font-Size="Small" Font-Names="HY울릉도M" Font-Bold="true"></asp:Label>
                                    <asp:CheckBox ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" />
                               </td>
                           </tr>
                           <tr>
                               <td class="tableTitle" align="center"  style="width:85px; font-weight:bold;">BSC Champion</td>
                               <td class="tableContent">
                                   <asp:Label ID="lblChampName" runat="server" Width="100%" BackColor="white" Font-Size="Small" Font-Names="HY울릉도M" Font-Bold="true"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td class="tabletitle2" align="center"  style="width:85px; font-weight:bold;">조&nbsp;직&nbsp;&nbsp;비&nbsp;젼</td>
                               <td class="tableContent" colspan="2" >
                                 <asp:Label ID="lblDeptVision" Width="100%" runat="server" BackColor="white" Font-Size="Small" Font-Names="HY울릉도M" Font-Bold="true"></asp:Label>
                               </td>
                           </tr>
                        </table> 
                    </td>
                    <td style="width:25%">
                            <ig:UltraWebGrid ID="ultraLegend" runat="server" Height="100px" Width="100%" OnInitializeRow="ultraLegend_InitializeRow" style="left: 0px"  >
                               <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Width="38px" Hidden="True">
                                                <Header Caption="ESTTERM_REF_ID" >
                                                    
                                                </Header>
                                                <HeaderStyle Wrap="True" />
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Width="38px" Hidden="True" HeaderText="YMD">
                                                <Header Caption="YMD" >
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <HeaderStyle Wrap="True" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" HeaderText="EST_DEPT_REF_ID" Key="EST_DEPT_REF_ID" Width="38px" Hidden="True">
                                                <Header Caption="EST_DEPT_REF_ID" >
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <HeaderStyle Wrap="True" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" HeaderText="VIEW_REF_ID" Key="VIEW_REF_ID" Width="38px" Hidden="True">
                                                <Header Caption="VIEW_REF_ID" >
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <HeaderStyle Wrap="True" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="VIEW_NAME" HeaderText="VIEW_NAME" Key="VIEW_NAME" Width="80px">
                                                <Header Caption="VIEW_NAME" >
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <HeaderStyle Wrap="True" />
                                                <CellStyle  BackColor="whitesmoke" HorizontalAlign="Right" Font-Bold="true"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="SCORE" HeaderText="점수" Key="SCORE" DataType="System.Double" Type="Custom" 
                                                    Width="55px" AllowUpdate="No" Format="#,##0.00">
                                                <Header Caption="점수">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right" BackColor="whitesmoke" Font-Bold="true" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DASH" Key="DASH" Width="15px" HeaderText="">
                                                <Header Caption="" >
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke" Font-Bold="true" />
                                                <HeaderStyle Wrap="True" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT" DataType="System.Double" Type="Custom" 
                                                   Width="60px" AllowUpdate="No"  Format="#,##0.00">
                                                <Header Caption="가중치">
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke" Font-Bold="true" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                            <DisplayLayout AllowColSizingDefault="NotSet" BorderCollapseDefault="NotSet"
                                HeaderClickActionDefault="NotSet" Name="ultraLegend" RowHeightDefault="20px"
                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="NotSet" TableLayout="Fixed" StationaryMargins="Header" ColHeadersVisibleDefault="No" AutoGenerateColumns="False" ScrollBarView="Vertical">
                                <GroupByBox>
                                    <Style BackColor="Transparent" BorderColor="Transparent"></Style>
                                </GroupByBox>
                                <GroupByRowStyleDefault BackColor="Transparent" BorderColor="Transparent" ForeColor="DimGray">
                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                </GroupByRowStyleDefault>
                                <FooterStyleDefault BackColor="Transparent" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="Transparent" ForeColor="White">
                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                </FooterStyleDefault>
                                <RowStyleDefault BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" BorderWidth="1px">
                                    <BorderDetails  ColorLeft="Transparent" ColorTop="Transparent" />
                                    <Padding Left="2px" />
                                </RowStyleDefault>
                                <HeaderStyleDefault BackColor="Transparent" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="Transparent" ForeColor="White">
                                    <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                </EditCellStyleDefault>
                                <FrameStyle BackColor="whitesmoke" BorderColor="Transparent" BorderStyle="None" 
                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="9pt" Height="100px"
                                    Width="100%">
                                </FrameStyle>
                                <Pager>
                                    <Style BackColor="Transparent" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                    </Style>
                                </Pager>
                                <AddNewBox Hidden="False">
                                    <Style BackColor="Transparent" BorderColor="Transparent" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                    </Style>
                                </AddNewBox>
                                <SelectedRowStyleDefault BackColor="Transparent">
                                </SelectedRowStyleDefault>
                                <FixedCellStyleDefault BackColor="Transparent">
                                </FixedCellStyleDefault>
                                <ActivationObject BorderColor="" BorderWidth="">
                                </ActivationObject>
                            </DisplayLayout>
                        </ig:UltraWebGrid>
                    </td>
                  </tr>
                </table>
             </td>
           </tr>
           <tr>
             <td>
               <asp:Panel ID="plnScoreCard" runat="server" Width="100%" Height="100%">
                    <ig:UltraWebGrid ID="ugrdKpiStatus" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiStatus_InitializeRow" >
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <Columns>
                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                        FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="ESTTERM_REF_ID">
                                        </Header>
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <Footer Caption="">
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" DataType="System.Int32" EditorControlID=""
                                        FooterText="" Format="" HeaderText="EST_DEPT_REF_ID" Hidden="True" Key="EST_DEPT_REF_ID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="EST_DEPT_REF_ID">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                        FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="KPI_REF_ID">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                                        Format="" HeaderText="YMD" Key="YMD" Width="50px" Hidden="True">
                                        <Header Caption="YMD">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <HeaderStyle Wrap="True" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="VIEW_NAME" EditorControlID="" FooterText=""
                                        Format="" HeaderText="관점명" Key="VIEW_NAME" Width="95px" MergeCells="True">
                                        <Header Caption="관점명">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center" Font-Size="Small" Font-Bold="True"></CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="STG_REF_ID" DataType="System.Int32" EditorControlID=""
                                        FooterText="" Format="" HeaderText="STG_REF_ID" Hidden="True" Key="STG_REF_ID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="STG_REF_ID">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="STG_NAME" EditorControlID="" FooterText=""
                                        Format="" HeaderText="전략명" Key="STG_NAME" Width="160px" MergeCells="True" Hidden="True">
                                        <Header Caption="전략명">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Left" Font-Size="X-Small" Font-Bold="True" Wrap="True">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                        Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="460px">
                                        <Header Caption="KPI 명">
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Left" Font-Size="Medium" Font-Bold="True" Wrap="True">
                                          <Padding Left="10px" />
                                        </CellStyle>
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:UltraGridColumn BaseColumnName="UNIT" EditorControlID=""
                                        FooterText="" HeaderText="단위" Key="UNIT" Width="48px">
                                        <Header Caption="단위">
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center" Font-Size="Smaller" Font-Bold="True">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="TARGET" DataType="System.Double" EditorControlID=""
                                        FooterText="" HeaderText="계획" Key="TARGET" Format="#,##0.##" Width="110px">
                                        <Header Caption="계획">
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right" Font-Size="Small" Font-Bold="True">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="RESULT" DataType="System.Double" EditorControlID=""
                                        FooterText="" HeaderText="실적" Key="RESULT" Format="#,##0.##" Width="110px">
                                        <Header Caption="실적">
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right" Font-Size="Small" Font-Bold="True">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="CURRENT_WEIGHT" DataType="System.Double" EditorControlID=""
                                        FooterText="" HeaderText="가중치" Key="CURRENT_WEIGHT" Format="#,##0.##" Width="60px">
                                        <Header Caption="가중치">
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right" Font-Size="Small" Font-Bold="True">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="AC_POINT" DataType="System.Double" EditorControlID=""
                                        FooterText="" HeaderText="점수" Key="AC_POINT" Format="#,##0.##" Width="55px">
                                        <Header Caption="점수">
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right" Font-Size="Small" Font-Bold="True">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="SIGNAL" HeaderText="신호" Key="SIGNAL" Width="45px">
                                        <Header Caption="신호">
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Header>
                                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center" Font-Size="Medium">
                                        </CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS" EditorControlID=""
                                        FooterText="" Format="" HeaderText="승인여부" Key="APPROVAL_STATUS" Width="60px" Hidden="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="승인여부">
                                            <RowLayoutColumnInfo OriginX="14" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="14" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                </Columns>
                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Solid">
                                    <BorderDetails WidthBottom="1px" WidthLeft="2px" WidthRight="2px" WidthTop="1px" />
                                </RowTemplateStyle>
                            </ig:UltraGridBand>
                        </Bands>
                         <DisplayLayout CellPaddingDefault="1" AllowColSizingDefault="Free" BorderCollapseDefault="Separate" HeaderTitleModeDefault="Always"
                                HeaderClickActionDefault="NotSet" Name="ugrdKpiStatus" RowHeightDefault="35px"
                                RowSelectorsDefault="No" Version="4.00" CellClickActionDefault="RowSelect" tableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                <GroupByBox>
                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                </GroupByBox>
                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                </GroupByRowStyleDefault>
                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                </FooterStyleDefault>
                                <RowStyleDefault VerticalAlign="Middle" BorderWidth="1px" Font-Size="8pt" Font-Names="HY울릉도M" BorderColor="#AAB883"
                                    BorderStyle="Solid" HorizontalAlign="Left" ForeColor="#333333" BackColor="White">
                                    <Padding Left="2px" Right="2px"></Padding>
                                    <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                                </RowStyleDefault>
                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="30px">
                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault VerticalAlign="Middle" BorderWidth="0px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderStyle="None"
                                    HorizontalAlign="Left"></EditCellStyleDefault>
                                <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                                    BorderStyle="Solid" BackColor="#FAFCF1" Height="100%"></FrameStyle>
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
                                <SelectedRowStyleDefault BackColor="#E2ECF4" ForeColor="White">
                                </SelectedRowStyleDefault>
                                <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdKpiStatus_DblClickHandler" />
                             <ActivationObject BorderColor="" BorderWidth="">
                             </ActivationObject>
                            </DisplayLayout>
                    </ig:UltraWebGrid>
               </asp:Panel>
               <asp:Panel ID="plnDeptLoadMap" runat="server" Visible="false" Width="100%" Height="100%">
                  <ig:UltraWebGrid ID="ugrdLoadMapList" runat="server"  Width="100%" Height="100%" OnInitializeRow="ugrdLoadMapList_InitializeRow" style="left: 1px" OnInitializeLayout="ugrdLoadMapList_InitializeLayout">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" 
                                       Width="80px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="ESTTERM_REF_ID">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" FooterText="" HeaderText="전략 ID"
                                    Key="EST_DEPT_REF_ID" Width="70px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="EST_DEPT_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" FooterText="" HeaderText="년월"
                                    Key="YMD" Width="80px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="년월">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <HeaderStyle Font-Size="Medium" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD_DESC" FooterText="" HeaderText="년월"
                                    Key="YMD_DESC" Width="95px" AllowUpdate="No">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="년월">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <HeaderStyle Font-Size="Medium" />
                                    <CellStyle HorizontalAlign="Center" BackColor="whitesmoke" Font-Size="Medium" Font-Bold="true">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="MONTHLY_PLAN" FooterText="" HeaderText="계획" Key="MONTHLY_PLAN"
                                    Width="440px" CellMultiline="Yes">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="당월">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <HeaderStyle Font-Size="Medium" />
                                    <CellStyle HorizontalAlign="Left" Wrap="True"></CellStyle>
                                    <CellTemplate>
                                      <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" Wrap="false" id="txtMONTHLY_PLAN" ReadOnly="true" BackColor="white" runat="server"></asp:TextBox>
                                    </CellTemplate>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="DETAILS" FooterText="" HeaderText="추진내용" Key="DETAILS"
                                    Width="440px" CellMultiline="Yes">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="누적">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <HeaderStyle Font-Size="Medium" />
                                    <CellStyle HorizontalAlign="Left" Wrap="True">
                                    </CellStyle>
                                    <CellTemplate>
                                      <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" Wrap="false" id="txtDETAILS" ReadOnly="true" BackColor="white" runat="server"></asp:TextBox>
                                    </CellTemplate>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="ETC_CONTENTS" FooterText="" HeaderText="특이사항" Key="ETC_CONTENTS"
                                    Width="220px" CellMultiline="Yes" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="특이사항">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <HeaderStyle Font-Size="Medium" />
                                    <CellStyle HorizontalAlign="Left" Wrap="True"></CellStyle>
                                    <CellTemplate>
                                      <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" Wrap="false" id="txtETC_CONTENTS" ReadOnly="true" BackColor="white" runat="server"></asp:TextBox>
                                    </CellTemplate>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="CLOSE_YN" FooterText="" HeaderText="CLOSE_YN" Key="CLOSE_YN"
                                    Width="30px" CellMultiline="Yes" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="마감">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center" Wrap="True">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="NotSet"
                        Name="ugrdLoadMapList" RowHeightDefault="305px" HeaderStyleDefault-Height="35" HeaderStyleDefault-HorizontalAlign="Center" RowSelectorsDefault="No" SelectTypeRowDefault="None"
                        StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="Flat" AllowUpdateDefault="No"  HeaderTitleModeDefault="Always">
                        <GroupByBox Hidden="True">
                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" Font-Names="HY울릉도M" BorderWidth="1px">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="0px" Bottom="0px" Top="0px" Right="0px" />
                        </RowStyleDefault>
                        <SelectedRowStyleDefault BackColor="White">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid" Font-Bold="true"
                            ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="Medium">
                            <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px" Wrap="True">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="100%">
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
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                    </DisplayLayout>
                </ig:UltraWebGrid> 
               </asp:Panel>
             </td>
           </tr>
         </table>
       <!--- MAIN END --->
       </div>
    </form>
    <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport"
        OnCellExported="ugrdEEP_CellExported" OnCellExporting="ugrdEEP_CellExporting">
    </ig:UltraWebGridExcelExporter>
</body>
</html>