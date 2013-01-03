<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0302M1M1.aspx.cs" Inherits="BSC_BSC0302M1M1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC::성과관리 시스템::KPI 수정</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script id="Infragistics" type="text/javascript">
    var isCounting = false;
    
    /////////////////////////////////////////////////// >> 계획자동계산
    function AfterCellUpdate(tableName, itemName) {

        var oRate = document.getElementById('txtRate').value;
        
        var rate = Math.abs(oRate);

        //alert(rate);
        
        if (isCounting)
            return;
            
        isCounting = true;
        var dblPlan = 0.00;
        var intDiv = 0;

        var oGrid = igtbl_getGridById(tableName);

        var strMS  = "";
        var strTS  = "";
        var strCK  = "";


        var targetMS = "";
        var targetTS = "";
        
        //alert(document.form1.hdfinitial_version_yn.value);
        
       // var tab = igtab_getTabById("ugrdKpiStatusTab");

        var objColType = document.getElementById("ddlResultTsCalcType"); 
        var strColType = objColType.value;
        
        
        if (document.form1.hdfinitial_version_yn.value == "Y")
        {
            strMS = "MS_PLAN";
            strTS = "TS_PLAN";
            strCK = "ORI_CHECK_YN";

            targetMS = "MS_TARGET";
            targetTS = "TS_TARGET";
        }
        else
        {
            strMS = "MM_PLAN";
            strTS = "TM_PLAN";
            strCK = "MOD_CHECK_YN";

            targetMS = "MS_TARGET";
            targetTS = "TS_TARGET";
        }

        //alert(itemName);
        
        oRows = oGrid.Rows;
        for (var i = 0; i < oRows.length; i++) {
            //alert(itemName);

            var oRow = oRows.getRow(i);

            //alert(oRow.getCellFromKey(strMS).getValue());


            intDiv += (oRow.getCellFromKey(strCK).getValue() == 'Y') ? 1 : 0;

            var valMS = oRow.getCellFromKey(strMS).getValue();
            var targetValMS = oRow.getCellFromKey(strMS).getValue();

            //alert(valMS);

            if (isNaN(parseFloat(valMS)) || (oRow.getCellFromKey(strCK).getValue() == 'N')) {
                
                oRow.getCellFromKey(strMS).setValue(0);
                oRow.getCellFromKey(strTS).setValue(0);

                var oValue = valMS;

                var rValue = 0;


                if (itemName == "S") {
                    if (oRate > 0) {
                        rValue = oValue + (oValue * (rate / 100));

                        dblPlan += oValue;

                        dblPlan = dblPlan + (dblPlan * (rate / 100));
                    }
                    else {
                        rValue = oValue - (oValue * (rate / 100));

                        dblPlan += oValue;

                        dblPlan = dblPlan - (dblPlan * (rate / 100));
                    }

                    oRow.getCellFromKey(strMS).setValue(rValue);
                }
                else {
                    dblPlan += parseFloat(valMS);
                }
                
                if (strColType=="SUM")      //단순합계
                {
                    oRow.getCellFromKey(strTS).setValue(dblPlan);
                }
                else if (strColType=="OTS") // 누적만측정
                {
                        //oRow.getCellFromKey(strMS).setValue(0);
                }
                else if (strColType=="AVG") // 단순평균
                {
                    dblPlan += parseFloat(oRow.getCellFromKey(strMS).getValue());
                    if (intDiv == 0)
                    {
                        oRow.getCellFromKey(strTS).setValue(dblPlan);
                    }
                    else
                    {
                        oRow.getCellFromKey(strTS).setValue(dblPlan/intDiv);
                    }
                }

                //alert('a');
            }
            else {
                //alert('b');
                var oValue = valMS;

                var rValue = 0;


                if (itemName == "S") {
                    if (oRate > 0) {
                        rValue = oValue + (oValue * (rate / 100));

                        dblPlan += oValue;

                        dblPlan = dblPlan + (dblPlan * (rate / 100));
                    }
                    else {
                        rValue = oValue - (oValue * (rate / 100));

                        dblPlan += oValue;

                        dblPlan = dblPlan - (dblPlan * (rate / 100));
                    }

                    oRow.getCellFromKey(strMS).setValue(rValue);
                }
                else {
                    dblPlan += parseFloat(valMS);
                }
                
                if (strColType=="SUM")      //단순합계
                {
                    
                    oRow.getCellFromKey(strTS).setValue(dblPlan);
                }
                else if (strColType=="AVG") // 단순평균
                {
                    
                    if (intDiv == 0)
                    {
                        oRow.getCellFromKey(strTS).setValue(dblPlan);
                    }
                    else
                    {
                        oRow.getCellFromKey(strTS).setValue(dblPlan/intDiv);
                    }
                }
            }
        }
        isCounting = false;

        //alert(itemName);
   }


   /////////////////////////////////////////////////// >> 계획자동계산
   function AfterCellUpdateFromTaget(tableName, itemName) {

       var oRate = document.getElementById('txtRate').value;

       var rate = Math.abs(oRate);

       //alert(rate);

       if (isCounting)
           return;

       isCounting = true;
       var dblPlan = 0.00;
       var intDiv = 0;

       var oGrid = igtbl_getGridById(tableName);

       var strMS = "";
       var strTS = "";
       var strCK = "";


       var targetMS = "";
       var targetTS = "";

       //alert(document.form1.hdfinitial_version_yn.value);

       // var tab = igtab_getTabById("ugrdKpiStatusTab");

       var objColType = document.getElementById("ddlResultTsCalcType");
       var strColType = objColType.value;


       if (document.form1.hdfinitial_version_yn.value == "Y") {
           strMS = "MS_PLAN";
           strTS = "TS_PLAN";
           strCK = "ORI_CHECK_YN";

           targetMS = "MS_TARGET";
           targetTS = "TS_TARGET";
       }
       else {
           strMS = "MM_PLAN";
           strTS = "TM_PLAN";
           strCK = "MOD_CHECK_YN";

           targetMS = "MS_TARGET";
           targetTS = "TS_TARGET";
       }

       //alert(itemName);

       oRows = oGrid.Rows;
       for (var i = 0; i < oRows.length; i++) {
           //alert(itemName);

           var oRow = oRows.getRow(i);

           //alert(oRow.getCellFromKey(strMS).getValue());


           intDiv += (oRow.getCellFromKey(strCK).getValue() == 'Y') ? 1 : 0;

           var valMS = oRow.getCellFromKey(targetMS).getValue();

           //alert(valMS);

           if (isNaN(parseFloat(valMS)) || (oRow.getCellFromKey(strCK).getValue() == 'N')) {

               oRow.getCellFromKey(strMS).setValue(0);
               oRow.getCellFromKey(strTS).setValue(0);


               if (strColType == "SUM")      //단순합계
               {
                   oRow.getCellFromKey(strTS).setValue(dblPlan);
               }
               else if (strColType == "OTS") // 누적만측정
               {
                   //oRow.getCellFromKey(strMS).setValue(0);
               }
               else if (strColType == "AVG") // 단순평균
               {
                   dblPlan += parseFloat(oRow.getCellFromKey(strMS).getValue());
                   if (intDiv == 0) {
                       oRow.getCellFromKey(strTS).setValue(dblPlan);
                   }
                   else {
                       oRow.getCellFromKey(strTS).setValue(dblPlan / intDiv);
                   }
               }

               //alert('a');
           }
           else {
               //alert('b');
               var oValue = valMS;

               var rValue = 0;


               if (itemName == "S") {
                   if (oRate > 0) {
                       rValue = oValue + (oValue * (rate / 100));

                       dblPlan += oValue;

                       dblPlan = dblPlan + (dblPlan * (rate / 100));
                   }
                   else {
                       rValue = oValue - (oValue * (rate / 100));

                       dblPlan += oValue;

                       dblPlan = dblPlan - (dblPlan * (rate / 100));
                   }

                   oRow.getCellFromKey(strMS).setValue(rValue);
               }
               else {
                   dblPlan += parseFloat(valMS);
               }

               if (strColType == "SUM")      //단순합계
               {

                   oRow.getCellFromKey(strTS).setValue(dblPlan);
               }
               else if (strColType == "AVG") // 단순평균
               {

                   if (intDiv == 0) {
                       oRow.getCellFromKey(strTS).setValue(dblPlan);
                   }
                   else {
                       oRow.getCellFromKey(strTS).setValue(dblPlan / intDiv);
                   }
               }
           }
       }
       isCounting = false;

       //alert(itemName);
   }

   function doRecounting() {
       AfterCellUpdateFromTaget('ugrdPlan', 'S');
       return false;
   }
    
</script>
<script src="../_common/js/iezn_embed_patch.js" type="text/javascript"></script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
  <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr> 
                    <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td  style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t107.gif" /></td>
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
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%"> 
                                <tr>
                                 <td>
                                   <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td class="cssTblTitle">KPI 코드</td>
                                        <td class="cssTblContent">
                                          <asp:TextBox ID="txtKpiCode" Width="100%" runat="server" BorderWidth="0"></asp:TextBox>
                                        </td>
                                        <td class="cssTblTitle">KPI 명</td>
	                                    <td class="cssTblContent">
	                                      <asp:TextBox ID="txtKpiName" runat="server" Width="100%" BorderWidth="0" ReadOnly="True" BackColor="whitesmoke"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle">KPI 유형</td>
                                        <td class="cssTblContent">
                                            <asp:Label ID="lblKpiType" Width="100%" runat="server" BorderWidth="0"></asp:Label>
                                        </td>
                                        <td class="cssTblTitle">지표분류</td>
	                                    <td class="cssTblContent">
                                            <asp:Label ID="lblKpiCatName" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                   </table>
                                 </td>
                                </tr>
                                <tr>
                                    <td><img alt="" src="../images/blank.gif" width="0" height="7px" /><br /></td>
                           </table>
                        </td>
                    </tr>
                    <tr class="cssPopTblBottomSpace"><td>&nbsp;</td></tr>
                    <tr style="height:100%;">
                        <td>
                          <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                              <tr>
                                  <td style="width:100%;" valign="top">
                                      <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableBorder">
                                          <tr>
                                            <td class="cssTblTitle" >KPI 유형</td>
                                            <td class="cssTblContent" >
                                                <asp:DropDownList ID="ddlResultAchievementType" runat="server" CssClass="box01" Width="100%">
                                                </asp:DropDownList></td>
                                            <td class="cssTblTitle"  >누적실적유형</td>
                                            <td class="cssTblContent" >
                                                <asp:DropDownList ID="ddlResultTsCalcType" runat="server" AutoPostBack="True" CssClass="box01" Width="100%">
                                                </asp:DropDownList></td>
                                          </tr>
                                          <tr>
                                            <td class="cssTblTitle" >구간산정방법</td>
                                            <td class="cssTblContent" >
                                                <asp:DropDownList ID="ddlMeasurementGradeType" runat="server" CssClass="box01" Width="100%">
                                                </asp:DropDownList></td>
                                             <td class="cssTblTitle"  >단위</td>
                                             <td class="cssTblContent" >
                                                 <asp:DropDownList ID="ddlUnit" runat="server" CssClass="box01" Width="100%"> </asp:DropDownList>
                                             </td>
                                          </tr>
                                          <tr>
                                              <td class="cssTblTitle"><%=this.GetText("LBL_00003", "평가단계") %></td>
                                              <td class="cssTblContent" colspan="3" >
                                                  <asp:DropDownList ID="ddlResultMeasurementStep" runat="server" AutoPostBack="True" CssClass="box01" Width="100%">
                                                  </asp:DropDownList></td>
                                          </tr>
                                      </table>
                                  </td>
                              </tr>
                              <tr>
                                <td style="height:100%;">
                                    <!------- 당초/수정계획 그리드 ---------------------------->
                                    <ig:UltraWebGrid id="ugrdPlan" runat="server" height="100%" width="100%" OnInitializeLayout="ugrdPlan_InitializeLayout" OnInitializeRow="ugrdPlan_InitializeRow">
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <Columns>
                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="목표시기" Key="YMD_DESC" Width="100px"  >
                                                        <Header Caption="목표시기" ></Header>
                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="당월" Key="MS_TARGET" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####">
                                                        <Header Caption="당월">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="누계" Key="TS_TARGET" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####">
                                                        <Header Caption="누계">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월" Key="MS_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####">
                                                        <Header Caption="당월">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="TS_PLAN" HeaderText="누계" Key="TS_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####">
                                                        <Header Caption="누계">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="MM_PLAN" HeaderText="당월" Key="MM_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####" Hidden="true">
                                                        <Header Caption="당월">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="TM_PLAN" HeaderText="누계" Key="TM_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####" Hidden="true">
                                                        <Header Caption="누계">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="측정주기" AllowUpdate="NotSet" Key="CHECK_YN" Width="50px">
                                                        <Header Caption="측정">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Footer>
                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="마감여부"  AllowUpdate="No" Key="CLOSE_YN" Width="50px" >
                                                        <Header Caption="마감">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Footer>
                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="보고주기"  AllowUpdate="NotSet" Key="REPORT_YN" Width="98px" Hidden="true">
                                                        <Header Caption="보고주기">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                        Key="ESTTERM_REF_ID">
                                                        <Header Caption="ESTTERM_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID" Hidden="True"  Key="KPI_REF_ID">
                                                        <Header Caption="KPI_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_TARGET_VERSION_ID" DataType="System.Int32" HeaderText="KPI_TARGET_VERSION_ID" Hidden="True"  Key="KPI_TARGET_VERSION_ID">
                                                        <Header Caption="KPI_TARGET_VERSION_ID">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Key="YMD" Width="50px" Hidden="True">
                                                        <Header Caption="YMD" >
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="ORI_CHECK_YN" HeaderText="ORI_CHECK_YN" Hidden="True"  Key="ORI_CHECK_YN">
                                                        <Header Caption="ORI_CHECK_YN">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="MOD_CHECK_YN" HeaderText="MOD_CHECK_YN" Hidden="True"  Key="MOD_CHECK_YN">
                                                        <Header Caption="MOD_CHECK_YN">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="MONTHLY_CLOSE_YN" HeaderText="MONTHLY_CLOSE_YN" Hidden="True"  Key="MONTHLY_CLOSE_YN">
                                                        <Header Caption="MONTHLY_CLOSE_YN">
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                     <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월" Key="OO_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####" Hidden="true">
                                                        <Header Caption="당월">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                </Columns>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout Version="4.00"
                                                       AllowColSizingDefault="Free" 
                                                       AllowUpdateDefault="Yes" 
                                                       AutoGenerateColumns="False" 
                                                       HeaderClickActionDefault="NotSet" 
                                                       Name="ugrdPlan" 
                                                       BorderCollapseDefault="Separate" 
                                                       RowSelectorsDefault="No" 
                                                       ScrollBarView="Vertical" 
                                                       RowHeightDefault="22px" 
                                                       JavaScriptFileName="" 
                                                       JavaScriptFileNameCommon="" 
                                                       CellClickActionDefault="Edit" 
                                                       StationaryMargins="Header" 
                                                       OptimizeCSSClassNamesOutput="False"
                                                       TableLayout="Fixed">
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate"  />
                                        </DisplayLayout>
                                    </ig:UltraWebGrid>
                                    <ig:UltraWebGrid id="ugrdBPlan" runat="server" height="100%" width="99%" Visible="false">
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <Columns>
                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="목표&lt;BR /&gt;시기" Key="YMD_DESC" Width="50px">
                                                        <Header Caption="목표&lt;BR /&gt;시기" ></Header>
                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월" Key="MS_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####">
                                                        <Header Caption="당월">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="TS_PLAN" HeaderText="누계" Key="TS_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####">
                                                        <Header Caption="누계">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="MM_PLAN" HeaderText="당월" Key="MM_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####">
                                                        <Header Caption="당월">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="TM_PLAN" HeaderText="누계" Key="TM_PLAN" DataType="System.Double" Type="Custom" Width="98px" Format="###,###.####">
                                                        <Header Caption="누계">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                        Key="ESTTERM_REF_ID">
                                                        <Header Caption="ESTTERM_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID" Hidden="True"  Key="KPI_REF_ID">
                                                        <Header Caption="KPI_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_TARGET_VERSION_ID" DataType="System.Int32" HeaderText="KPI_TARGET_VERSION_ID" Hidden="True"  Key="KPI_TARGET_VERSION_ID">
                                                        <Header Caption="KPI_TARGET_VERSION_ID">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Key="YMD" Width="50px" Hidden="True">
                                                        <Header Caption="YMD" >
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="ORI_CHECK_YN" HeaderText="ORI_CHECK_YN" Hidden="True"  Key="ORI_CHECK_YN">
                                                        <Header Caption="ORI_CHECK_YN">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="MOD_CHECK_YN" HeaderText="MOD_CHECK_YN" Hidden="True"  Key="MOD_CHECK_YN">
                                                        <Header Caption="MOD_CHECK_YN">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="MONTHLY_CLOSE_YN" HeaderText="MONTHLY_CLOSE_YN" Hidden="True"  Key="MONTHLY_CLOSE_YN">
                                                        <Header Caption="MONTHLY_CLOSE_YN">
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                </Columns>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout CellPaddingDefault="2"
                                                       Version="4.00"
                                                       AllowColSizingDefault="Free"
                                                       AllowUpdateDefault="Yes" 
                                                       AutoGenerateColumns="False" 
                                                       HeaderClickActionDefault="NotSet" 
                                                       Name="ugrdPlan" 
                                                       BorderCollapseDefault="Separate" 
                                                       RowSelectorsDefault="No" 
                                                       ScrollBarView="Vertical" 
                                                       RowHeightDefault="22px" 
                                                       JavaScriptFileName="" 
                                                       JavaScriptFileNameCommon="" 
                                                       CellClickActionDefault="Edit" 
                                                       StationaryMargins="Header" 
                                                       OptimizeCSSClassNamesOutput="False"
                                                       TableLayout="Fixed">
                                            
                                            <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate"  />
                                        </DisplayLayout>
                                    </ig:UltraWebGrid>
                                </td>
                              </tr>
                              <tr>
                                <td>
                                    <ig:UltraWebGrid id="ugrdTerm" runat="server" height="100%" width="600px" ImageDirectory="" OnInitializeRow="ugrdTerm_InitializeRow" OnInitializeLayout="ugrdTerm_InitializeLayout" Visible="false">
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <Columns>
                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="평가년월" Key="YMD" DataType="System.String" Hidden="true">
                                                        <Header Caption="평가년월"></Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="평가년월" Key="YMD_DESC">
                                                        <Header Caption="평가년월"></Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    </ig:UltraGridColumn>
                                                    <ig:TemplatedColumn BaseColumnName="CHECK_YN" Key="CHECK_YN">
                                                        <Header Caption="측정주기"></Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <HeaderTemplate>
                                                          <asp:Label ID="lblTerm" runat="server" Text="측정주기"></asp:Label>
                                                          <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdTerm')" />
                                                        </HeaderTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <CellTemplate>
                                                            <asp:CheckBox ID="chkCheckTerm" runat="server" />
                                                        </CellTemplate>
                                                    </ig:TemplatedColumn>
                                                    <ig:TemplatedColumn BaseColumnName="REPORT_YN" Key="REPORT_YN">
                                                        <Header Caption="보고주기"></Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <CellTemplate >
                                                            <asp:CheckBox ID="chkReportTerm" runat="server" />
                                                        </CellTemplate>
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="CLOSE_YN" DataType="System.String" HeaderText="마감여부"
                                                        Hidden="false"  Key="CLOSE_YN">
                                                        <Header Caption="마감여부">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID"
                                                        Hidden="True"  Key="KPI_REF_ID">
                                                        <Header Caption="KPI_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                        Key="ESTTERM_REF_ID">
                                                        <Header Caption="ESTTERM_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="typecode" DataType="System.Int32" HeaderText="typecode"
                                                        Hidden="True"  Key="typecode">
                                                        <Header Caption="typecode">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                </Columns>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout CellPaddingDefault="2" Version="4.00" AutoGenerateColumns="false" 
                                         HeaderClickActionDefault="NotSet" Name="ugrdTerm" BorderCollapseDefault="Separate" RowSelectorsDefault="No" ScrollBarView="Both" 
                                         RowHeightDefault="20px" SelectTypeRowDefault="Single" JavaScriptFileName="" JavaScriptFileNameCommon="" FixedHeaderIndicatorDefault="Button" TableLayout="Fixed" 
                                         StationaryMargins="Header" >
                                            
                                            <GroupByBox Hidden="True">
                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                            </GroupByBox>
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            <ClientSideEvents  />
                                        </DisplayLayout>
                                    </ig:UltraWebGrid>
                                </td>
                              </tr>
                           </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssPopBtnLine">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="width:1%;">
                                                    <ig:WebNumericEdit ID="txtRate" runat="server" MaxValue="100" MinValue="-100" NullText="0"></ig:WebNumericEdit>% 
                                                </td>
                                                <td>&nbsp;
                                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" OnClientClick="return doRecounting();" ImageUrl="~/images/btn/b_014.gif" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="iBtnSave" runat="server"  OnClick="ibtnSave_Click" Height="19px" ImageUrl="~/images/btn/b_tp07.gif" />
                                        <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server" OnClientClick="window.close();"  />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                        <td style="width:50%; height:4px; background-color:#FFFFFF">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            <asp:HiddenField ID="hdfImagePath" runat="server" Value="" />
                            <asp:Literal ID="ltrScript" runat="server" Text="" ></asp:Literal>
                            <asp:HiddenField ID = "hdfKpiPoolRefID" runat="server" Value="" />
                            <asp:HiddenField ID = "hdfEstTermRefID" runat="server" Value="" />
                            <asp:HiddenField ID = "hdfKpiRefID" runat="server" Value="" />
                            <asp:HiddenField ID = "hdfinitial_version_yn" runat="server" Value="" />
                            <asp:HiddenField ID = "hdfkpi_target_version_id" runat="server" Value="" />
                            <asp:HiddenField ID = "hdfTargetReasonFile" runat="server" Value="" />
                        </td>
                        <td style="width:50%; background-color:#FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
  </form>
</body>
</html>
