<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0304S2.aspx.cs" EnableEventValidation="false" Inherits="BSC_BSC0304S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Script1" type="text/javascript">

    var checkVal = 0;

    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
            var cell            = igtbl_getElementById(id);
            var row             = igtbl_getRowById(id);
            var band            = igtbl_getBandById(id);
            var active          = igtbl_getActiveRow(id);
            cell.style.cursor   = 'hand';
        }
    }
    
    function UltraWebGrid2_DblClickHandler(gridName, cellId)
    {
        
        var cell                = igtbl_getCellById(cellId); 
        var row                 = igtbl_getRowById(cellId);
        var grid                = igtbl_getGridById(gridName);
        var Ymd                 = row.getCellFromKey("YMD").getValue();
    
        var Estterm_ref_id  = '<%=this.IEstTermRefID %>';
        var Kpi_Ref_id      = '<%=this.IKpiRefID %>';
          
        var url             =  "BSC0604S1.aspx?ESTTERM_REF_ID="+ Estterm_ref_id +"&KPI_REF_ID="+ Kpi_Ref_id +"&YMD="+Ymd;
        
        gfOpenWindow(url,750,720,'no','no','BSC0604S1');
    }
    
    function OpenShowKpiDetail()
    {
        var Estterm_ref_id = '<%=this.IEstTermRefID %>';
        var Kpi_Ref_id     = '<%=this.IKpiRefID %>';
        var Ymd            = '<%=this.IYMD %>';
        var url            = 'BSC0302M1.aspx?ESTTERM_REF_ID='+ Estterm_ref_id +'&KPI_REF_ID='+ Kpi_Ref_id +'&YMD='+Ymd;
        
        gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
    }
    
    function OpenShowRelationKpi()
    {
        var Estterm_ref_id = '<%=this.IEstTermRefID %>';
        var Kpi_Ref_id     = '<%=this.IKpiRefID %>';
        var Ymd            = '<%=this.IYMD %>';
        var url            = '../usr/usr2004.aspx?ESTTERM_REF_ID='+ Estterm_ref_id +'&KPI_REF_ID='+ Kpi_Ref_id +'&YMD='+Ymd;
        
        gfOpenWindow(url, 900, 400, 'yes', 'no', 'USR2004');
    }
    
    function OpenCommunicationWindow()
    {
        var Estterm_ref_id = '<%=this.IEstTermRefID %>';
        var Kpi_Ref_id     = '<%=this.IKpiRefID %>';
        var Ymd            = '<%=this.IYMD %>';
        var ICCB1          = "<%= this.ICCB1 %>";
        var url            = '../BSC/BSC0701M1.aspx?iTYPE=A&ESTTERM_REF_ID='+ Estterm_ref_id +'&KPI_REF_ID='+ Kpi_Ref_id +'&YMD='+Ymd+'&CCB1='+ICCB1;

        gfOpenWindow(url, 823, 580, 'yes', 'no', 'BSC0701M1A');
        
        return false;
    }
    
    function DblClickHandler(gridName, id) 
    {
        var cell     = igtbl_getElementById(id);
        var row      = igtbl_getRowById(id);
        var listID   = row.getCellFromKey("LIST_REF_ID").getValue();
        var termID   = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var kpiID    = row.getCellFromKey("KPI_REF_ID").getValue();
        var Ymd      = row.getCellFromKey("YMD").getValue();
        var ICCB1    = "<%= this.ICCB1 %>";
        
        var strURL   = '../BSC/BSC0701M1.aspx?iTYPE=U&LIST_REF_ID='+listID+'&ESTTERM_REF_ID='+ termID +'&KPI_REF_ID='+kpiID+'&YMD='+Ymd+'&CCB1='+ICCB1;
        
        gfOpenWindow(strURL, 823, 540, 'BSC0701M1U');
    }
    
    function ShowPopUp()
    {
        var Estterm_ref_id = '<%=this.IEstTermRefID %>';
        var Kpi_Ref_id     = '<%=this.IKpiRefID %>';
        var Ymd            = '<%=this.IYMD %>';
        
        var strURL   = '../BSC/BSC0803S3.aspx?iTYPE=U&ESTTERM_REF_ID='+ Estterm_ref_id +'&KPI_REF_ID='+Kpi_Ref_id +"&YMD="+Ymd;
        
        gfOpenWindow(strURL, 540, 540, 'BSC0803S3');
        return false;
    }
    
    function OpenPrintPage()
    {
        var Estterm_ref_id = "<%=this.IEstTermRefID %>";
        var Kpi_Ref_id     = "<%=this.IKpiRefID %>";
        var Ymd            = "<%=this.IYMD %>";
        var url            = "BSC0304P2.aspx?ESTTERM_REF_ID="+ Estterm_ref_id +"&KPI_REF_ID="+ Kpi_Ref_id +"&YMD="+Ymd;
        
        gfOpenWindow(url, 800, 645, 'yes', 'no', 'BSC0304P2');
        return false;
    }
    
</script>
<script type="text/javascript" language="javascript">  
<!--          
        function clickshow(num)  
        {
            var objID = '<%=this.block0.ClientID %>';
                objID = objID.substring(objID,objID.length-1);
                
            for (i=0;i<4;i++)  
            {  
                menu    = eval(objID + i + ".style");
                imgbtn  = eval("document.img" + i);                                            
                
                if (num==i)  
                {  
                    if (menu.display == "block")  
                    { 
                        menu.display    = "none"; 
                        imgbtn.src      = "../images/btn/b_tp0" + (i+1) + "_2.gif";
                        showalt(i,0);
                    }  
                    else 
                    {  
                        menu.display            = "block"; 
                        imgbtn.src              = "../images/btn/b_tp0"+(i+1)+"_1.gif";
                        document.location.href  = "#link"+i;
                        showalt(i,1);
                    }  
                }  
            }   
        }  
        
        function showalt(i,act)
        {
            var title;
            var action;
            var imgbtn = eval("document.img"+i);
            
            if(act == 0)
                action = "보기";
            else
                action = "숨기기";
                
            if(i == 0)
                title = "실적정보 그래프 ";
            else if(i == 1)
                title = "실적정보 상세 ";
            else if(i == 2)
                title = "원인분석 및 대책 ";
            else if(i == 3)
                title = this.GetText("LBL_00004", "Communication");
                
            imgbtn.alt = title + action;            
        }
        
        function Upfile(ival,sval)
        {
            
        }
        
        function mfUpload(hAttachNo)
        {
            <%
            /*
                Argument설명
                    : ICM_FILE / ICM_PROCFILE 어느쪽에 셋팅하는가? (FILE / PROCFILE)
                    : 파일첨부시 어떤 프로젝트 소속인가? 해당폴더및 ATTACHNO추출시 접두어로 사용됨 (ICM, DCM, ....)
            */
            %>
            //수정(20060707 이승주)
            //var oAttach = gfGetFindObj("hAttachNo");
            var oAttach = gfGetFindObj(hAttachNo);
            var oaArg   = new Array("FILE", "PCAUSE", (oAttach==null ? "" : oAttach.value));
            
            var oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F", oaArg, 485, 307);
            
            if (oReturn != "" && oReturn != undefined)
            {
                oAttach.value = oReturn;
            }
            else
            {
                alert("파일첨부를 하지 않았습니다!");
            }
            return false;
        }
        
        function GoBack()
        {
            history.back();
            return false;
        }
        
    function ugrdPrjList_DblClickHandler(gridName, cellId)
    {
        var cell            = igtbl_getElementById(cellId);
        var row             = igtbl_getRowById(cellId);
        var prjID           = row.getCellFromKey("PRJ_REF_ID").getValue();
        var viewYN          = "S";//row.getCellFromKey("ISDELETE").getValue() =='Y'? 'D':'U';
        var ICCB1           = "<%= this.ICCB1 %>";
        
        var url             = '../PRJ/PRJ0101M1.aspx?iType=' + viewYN + '&PRJ_REF_ID=' + prjID+'&CCB1='+ICCB1 ;
        gfOpenWindow(url, 900, 680, 'yes', 'no', 'PRJ0101M1');
    }
//-->  
</script>
    <!--- MAIN START --->
<asp:Panel ID="pnlAll" runat="server" Width="100%" Height="100%" HorizontalAlign="Left" BorderWidth="0">
  <table cellpadding="0" cellspacing="0" border="0" width="100%;" style="height:100%;">
    <tr>
      <td align="left" style="vertical-align:top;">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style=" height:100%;">
          <tr>
            <td style="height:40px; vertical-align:top; width:100%;">
                <table cellpadding="2" cellspacing="0" border="0" width="100%"> 
                    <tr>
                        <td>
                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="cssTblTitle" >
                                        KPI 코드
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblKpiCode" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle" >
                                        KPI 명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblKpiName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        계획월
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlMonthInfo" runat="server" CssClass="box01" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="cssTblTitle"  >단위</td>
                                    <td class="cssTblContent"><asp:Label ID="lblUnitName" runat="server" Text="Label"></asp:Label></td>
                                 </tr>
                                <tr>
                                    <td class="cssTblTitle" >누적형태</td>
                                    <td class="cssTblContent" colspan="3"><asp:Label ID="lblPNUType" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssPopBtnLine">
                            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle"/>
                        </td>
                    </tr>
                </table>
            </td>
          </tr>
          <tr>
            <td align="left">
              <div style=" overflow:auto; width:100%; height:100%;">
                 <table border="0" cellspacing="0" cellpadding="0" style="width:100%; height:100%">
                  <tr>
                    <td style="vertical-align:top;">
                      <div runat="server" id="block0" style="display: block; margin-left: 1px; height:230px;"> 
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                                <td style="height:5px;" colspan="2"></td>
                            </tr>
                            <tr>
                                <td style="width:385px">
                                  <DCWC:Chart ID="chartMM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" >
                                        <ChartAreas>
                                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisX>
                                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY>
                                            
                                            </DCWC:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                                            </DCWC:Legend>
                                        </Legends>
                                    </DCWC:Chart>
                                   <%-- <asp:Chart ID="chartMM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="220px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="Default" BorderColor="196, 196, 196"
                                             BackColor="White" ShadowColor="Transparent">
                                            <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisX>
                                            <Area3DStyle  WallWidth="5" Enable3D="True"/>
                                            <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY>
                                            <AxisY2 linecolor="196, 196, 196"  IsLabelAutoFit="False" Enabled="True">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                                            </asp:Legend>
                                        </Legends>
                                    </asp:Chart>--%>
                                </td>
                                <td align="left">
                                    <DCWC:Chart ID="chartTM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" >
                                        <ChartAreas>
                                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisX>
                                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY>
                                            
                                            </DCWC:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                                            </DCWC:Legend>
                                        </Legends>
                                    </DCWC:Chart>
                                  <%--  <asp:Chart ID="chartTM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="200px" Height="220px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="Default" BorderColor="196, 196, 196"
                                             BackColor="White" ShadowColor="Transparent">
                                            <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisX>
                                            <Area3DStyle  WallWidth="5" Enable3D="True"/>
                                            <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False"  Enabled="True">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY>
                                            <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                                            </asp:Legend>
                                        </Legends>
                                    </asp:Chart>--%>
                                </td>
                            </tr>
                        </table>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td style="vertical-align:top;">
                     <div runat="server" id="block1"  style="display:block; margin-left: 1px; height:305px;">
                      <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                        <tr>
                          <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="실적정보 상세" />
                                    </td>
                                </tr>
                            </table>
                          </td>
                        </tr>
                        <tr>
                          <td style="height:100%;">
                            <ig:UltraWebGrid ID="ugrdKpiResultStatus" runat="server" Width="772px" Height="100%" OnInitializeLayout="ugrdKpiResultStatus_InitializeLayout" OnInitializeRow="ugrdKpiResultStatus_InitializeRow" >
                                <DisplayLayout CellPaddingDefault="2" 
                                               AllowColSizingDefault="Free" 
                                               AllowColumnMovingDefault="None" 
                                               AllowDeleteDefault="No"
                                                AllowSortingDefault="No" 
                                                BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="NotSet" 
                                                Name="ugrdKpiResultStatus" 
                                                RowHeightDefault="20px"
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended" 
                                                Version="4.00" 
                                                CellClickActionDefault="RowSelect" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="Header" 
                                                OptimizeCSSClassNamesOutput="False"
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
                                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="772px">
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
                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="UltraWebGrid2_DblClickHandler" />
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>--%>
                                    <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                    <ClientSideEvents DblClickHandler="UltraWebGrid2_DblClickHandler" />
                                </DisplayLayout>
                                <Bands>
                                <ig:UltraGridBand>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="MM" HeaderText="월" Key="MM" Width="30px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="월">
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS" DataType="System.Decimal" Format="#,##0.00"
                                            HeaderText="계획" Key="TARGET_MS" Width="90px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="계획">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS" DataType="System.Decimal" Format="#,##0.00"
                                            HeaderText="실적" Key="RESULT_MS" Width="90px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="실적">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="IMAGE_FILE_NAME_MS" HeaderText="상태" Key="IMAGE_FILE_NAME_MS"
                                            Width="30px">
                                            <Header Caption="상태">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="THRESHOLD_KNAME_MS" HeaderText="상태" Hidden="True"
                                            Key="THRESHOLD_KNAME_MS">
                                            <Header Caption="상태">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="TREND_MS" HeaderText="추세" Key="TREND_MS" Width="30px">
                                            <Header Caption="추세">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="TREND_MS_NAME" HeaderText="추세" Hidden="True"
                                            Key="TREND_MS_NAME">
                                            <Header Caption="추세">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="AC_RATE_MS" DataType="System.Decimal" Format="#,##0.00"
                                            HeaderText="달성율" Key="AC_RATE_MS" Width="70px">
                                            <Header Caption="달성율">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POINTS_MS" DataType="System.Decimal" Format="#,##0.00"
                                            HeaderText="점수" Key="POINTS_MS" Width="50px">
                                            <Header Caption="점수">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn AllowGroupBy="No" Width="12px" Key="SPLITER" BaseColumnName="SPLITER" HeaderText="">
                                            <HeaderStyle BackColor="White">
                                                <BorderDetails ColorBottom="White" ColorTop="White" />
                                            </HeaderStyle>
                                            <Header Caption="">
                                                <RowLayoutColumnInfo OriginX="9" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="9" />
                                            </Footer>
                                            <CellStyle BackColor="White">
                                                <BorderDetails ColorBottom="White" ColorTop="White" />
                                            </CellStyle>
                                            <FooterStyle BackColor="White">
                                                <BorderDetails ColorBottom="White" ColorTop="White" />
                                            </FooterStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS" DataType="System.Decimal" Format="###,###,##0.##"
                                            HeaderText="계획" Key="TARGET_TS" Width="90px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="계획">
                                                <RowLayoutColumnInfo OriginX="10" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="10" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS" DataType="System.Decimal" Format="###,###,##0.##"
                                            HeaderText="실적" Key="RESULT_TS" Width="90px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="실적">
                                                <RowLayoutColumnInfo OriginX="11" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="11" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="IMAGE_FILE_NAME_TS" HeaderText="상태" Key="IMAGE_FILE_NAME_TS"
                                            Width="30px">
                                            <Header Caption="상태">
                                                <RowLayoutColumnInfo OriginX="12" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="12" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="THRESHOLD_KNAME_TS" HeaderText="상태" Hidden="True"
                                            Key="THRESHOLD_KNAME_TS">
                                            <Header Caption="상태">
                                                <RowLayoutColumnInfo OriginX="13" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="13" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="TREND_TS" HeaderText="추세" Key="TREND_TS" Width="30px">
                                            <Header Caption="추세">
                                                <RowLayoutColumnInfo OriginX="14" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="14" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="TREND_TS_NAME" HeaderText="추세" Hidden="True"
                                            Key="TREND_TS_NAME">
                                            <Header Caption="추세">
                                                <RowLayoutColumnInfo OriginX="15" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="15" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="AC_RATE_TS" DataType="System.Decimal" Format="#,##0.00"
                                            HeaderText="달성율" Key="AC_RATE_TS" Width="70px">
                                            <Header Caption="달성율">
                                                <RowLayoutColumnInfo OriginX="16" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="16" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POINTS_TS" DataType="System.Decimal" Format="#,##0.00"
                                            HeaderText="점수" Key="POINTS_TS" Width="50px">
                                            <Header Caption="점수">
                                                <RowLayoutColumnInfo OriginX="17" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="17" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CHECK_YN" HeaderText="측정여부" Hidden="true"
                                            Key="CHECK_YN" Width="30px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="측정여부">
                                                <RowLayoutColumnInfo OriginX="18" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="18" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Key="YMD" Width="30px" Hidden="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="YMD">
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                                </Bands>
                            </ig:UltraWebGrid> 
                          </td>
                        </tr>
                      </table>
                     </div>
                    </td>
                  </tr>
                  <tr>
                    <td style="vertical-align:top;">
                     <div runat="server" id="block2"  style="display: block; margin-left: 1px; height:445px;">
                      <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                          <tr>
                              <td style="height:220px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%">
                                  <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label2" runat="server" style="font-weight:bold" text="원인 및 대책" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                  </tr>
                                  <tr>
                                    <td style="width:100%;">
                                        <table width="100%"  border="0" cellpadding="0" cellspacing="0" class="tableBorder">
                                            <tr> 
                                                <td class="cssTblTitle" style="width:10%;" >원인분석(당월)               
                                                    <asp:imagebutton ID="iBtnCauseFileID" ImageUrl="../images/icon/gr_po04.gif" runat="server"></asp:imagebutton>
                                                    <asp:HiddenField ID="hdfCauseDocNo"   Value="" runat="server" />
                                                </td>
                                                <td class="cssTblContent"  style="width:40%;">
                                                    <asp:TextBox ID="txtReason_Month" runat="server" Height="100" Width="100%" Rows="5" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
                                                <td class="cssTblTitle"   style="width:10%;">원인분석(누적)</td>
                                                <td  class="cssTblContent"  style="width:40%;">
                                                    <asp:TextBox ID="txtReason_Sum" runat="server" Height="100"  Width="100%"  Rows="5" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
                                            </tr>
                                            <tr> 
                                                <td  class="cssTblTitle" style="width:10%;" >대책검토(당월)
                                                    <asp:imagebutton ID="iBtnMeasureFileID" ImageUrl="../images/icon/gr_po04.gif" runat="server"></asp:imagebutton>
                                                    <asp:HiddenField ID="hdfMeasureDocNo" Value="" runat="server" />
                                                </td>
                                                <td  class="cssTblContent"  style="width:40%;"> 
                                                    <asp:TextBox ID="txtPlan_Month" runat="server" Height="100"  Width="100%"  Rows="5" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                                </td>
                                                <td  class="cssTblTitle" style="width:10%;" >대책검토(누적)</td>
                                                <td  class="cssTblContent"  style="width:40%;">
                                                    <asp:TextBox ID="txtPlan_Sum" runat="server" Height="100"  Width="100%" Rows="5" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                  </tr>
                                  
                                </table>
                              </td>
                            </tr>

                        <tr>
                          <td style="height:125px;">
                            <asp:Panel runat="server" ID="pnlinitiative" Width="100%" Height="100%">
                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                                  <tr>
                                    <td style="width:50%;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label3" runat="server" style="font-weight:bold" text="Initiative 추진계획" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label4" runat="server" style="font-weight:bold" text="Initiative 추진내용" />
                                                </td>
                                                <td style="padding-left:20px;">
                                                    <asp:imagebutton ID="iBtnInitiativeFile" ImageUrl="../images/icon/gr_po04.gif" runat="server"></asp:imagebutton>
                                                    <asp:imagebutton ID="iBtnEstOpinion" ImageUrl="../images/icon/est_opinion.gif" runat="server" ImageAlign="AbsMiddle" OnClientClick="return ShowPopUp();"></asp:imagebutton>
                                                    <asp:HiddenField ID="hdfInitiativeDocNo"   Value="" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                  </tr>
                                  <tr>
                                    <td style="height:100px;">
                                       <asp:TextBox ID="txtINITIATIVE_PLAN" runat="server" Height="99%" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td style="height:100px;">
                                       <asp:TextBox ID="txtINITIATIVE_DO" runat="server" Height="99%" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                  </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlPrj" Width="100%" Height="225px" Visible="false">
                                <br />
                                <img src="../images/icon/subtitle.gif" alt="" /><b>&nbsp;관련 Initiative 현황</b>
                                <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdPrjList_InitializeRow" OnInitializeLayout="ugrdPrjList_InitializeLayout" >
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:TemplatedColumn Hidden="True" Key="selchk" Width="30px">
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
                                                <ig:UltraGridColumn BaseColumnName="PRJ_CODE" HeaderText="코드" Key="PRJ_CODE" Width="60px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Header Caption="코드">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_NAME" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="사업명" Key="PRJ_NAME" Width="170px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ValueList DisplayStyle="NotSet">
                                                    </ValueList>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Header Caption="사업명">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PROCEED_RATE" Format="##0.00" HeaderText="진행율(%)"
                                                    Key="PROCEED_RATE" Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Header Caption="진행율(%)">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="OWNER_NAME" HeaderText="PM" Key="OWNER_NAME"
                                                    Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle Wrap="True">
                                                    </CellStyle>
                                                    <Header Caption="PM">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EFFECTIVENESS" HeaderText="기대효과" Key="EFFECTIVENESS"
                                                    Width="250px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="기대효과">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PLAN_START_DATE" DataType="System.DateTime"
                                                    EditorControlID="" FooterText="" Format="yyyy-MM-dd" HeaderText="시작일자" Key="PLAN_START_DATE"
                                                    Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Header Caption="시작일자">
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PLAN_END_DATE" DataType="System.DateTime"
                                                    EditorControlID="" FooterText="" Format="yyyy-MM-dd" HeaderText="종료일자" Key="PLAN_END_DATE"
                                                    Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Header Caption="종료일자">
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TOTAL_BUDGET" Format="###,##0.00" HeaderText="예상비용"
                                                    Key="TOTAL_BUDGET">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Header Caption="예상비용">
                                                        <RowLayoutColumnInfo OriginX="9" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="9" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SUM_BUDGET" Format="###,##0.00" HeaderText="소요비용"
                                                    Key="SUM_BUDGET">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                    <Header Caption="소요비용">
                                                        <RowLayoutColumnInfo OriginX="10" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="10" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="OWNER_DEPT_NAME" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="주관부서" Hidden="True" Key="OWNER_DEPT_NAME" Width="120px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Header Caption="주관부서">
                                                        <RowLayoutColumnInfo OriginX="11" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="11" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="DEFINITION" HeaderText="사업정의" Hidden="True"
                                                    Key="DEFINITION">
                                                    <Header Caption="사업정의">
                                                        <RowLayoutColumnInfo OriginX="12" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="12" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="REF_STG" HeaderText="전략목표" Hidden="True" Key="REF_STG">
                                                    <Header Caption="전략목표">
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="13" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="RANGE" HeaderText="사업범위" Hidden="True" Key="RANGE">
                                                    <Header Caption="사업범위">
                                                        <RowLayoutColumnInfo OriginX="14" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="14" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="INTERESTED_PARTIES" HeaderText="이해관계자" Hidden="True"
                                                    Key="INTERESTED_PARTIES">
                                                    <Header Caption="이해관계자">
                                                        <RowLayoutColumnInfo OriginX="15" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="15" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="REQUEST_DEPT" HeaderText="요청부서기관" Hidden="True"
                                                    Key="REQUEST_DEPT">
                                                    <Header Caption="요청부서기관">
                                                        <RowLayoutColumnInfo OriginX="16" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="16" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRIORITY" HeaderText="중요도" Hidden="True" Key="PRIORITY">
                                                    <Header Caption="중요도">
                                                        <RowLayoutColumnInfo OriginX="17" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="17" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="OWNER_EMP_NAME" HeaderText="책임자" Hidden="True"
                                                    Key="OWNER_EMP_NAME" Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Header Caption="책임자">
                                                        <RowLayoutColumnInfo OriginX="18" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="18" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_TYPE_NAME" HeaderText="사업유형" Hidden="True"
                                                    Key="PRJ_TYPE_NAME" Width="90px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Header Caption="사업유형">
                                                        <RowLayoutColumnInfo OriginX="19" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="19" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="PRJ_TYPE" HeaderText="사업유형" Hidden="True"
                                                    Key="PRJ_TYPE">
                                                    <Header Caption="사업유형">
                                                        <RowLayoutColumnInfo OriginX="20" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="20" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ACTUAL_START_DATE" DataType="System.DateTime"
                                                    EditorControlID="" FooterText="" HeaderText="시작일자" Hidden="True" Key="ACTUAL_START_DATE"
                                                    Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Header Caption="시작일자">
                                                        <RowLayoutColumnInfo OriginX="21" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="21" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ACTUAL_END_DATE" DataType="System.DateTime"
                                                    EditorControlID="" FooterText="" HeaderText="종료일자" Hidden="True" Key="ACTUAL_END_DATE"
                                                    Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Header Caption="종료일자">
                                                        <RowLayoutColumnInfo OriginX="22" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="22" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                     <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="NotSet" Name="ugrdPrjList" RowHeightDefault="20px"
                                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                            <%--<GroupByBox>
                                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                            </GroupByBox>
                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                            </GroupByRowStyleDefault>
                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                            </FooterStyleDefault>
                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                <Padding Left="3px" />
                                            </RowStyleDefault>
                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                Width="100%">
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
                                            <SelectedRowStyleDefault BackColor="#E2ECF4">
                                            </SelectedRowStyleDefault>
                                            <ActivationObject BorderColor="" BorderWidth="">
                                            </ActivationObject>--%>
                                            <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdPrjList_DblClickHandler" />
                                         
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                        </DisplayLayout>
                                </ig:UltraWebGrid>
                            </asp:Panel>
                          </td>
                        </tr>
                        
                        <tr>
                          <td style="vertical-align:top;">
                              <table style="border-width:0px; width:100%;">
                                <tr>
                                  <td>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                        <tr>
                                            <td style="width:15px;">
                                                <img src="../images/title/ma_t14.gif" alt="" />
                                            </td>
                                            <td>
                                                <asp:Label id="Label5" runat="server" style="font-weight:bold" text="익월실적예측" />
                                            </td>
                                        </tr>
                                    </table>
                                  </td>
                                </tr>
                              </table>
                              <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tableBorder">
                                <tr>
                                    <td class="cssTblTitle" align="center">구분</td>
                                    <td  align="center" class="cssTblTitle">
                                        (<asp:Label ID="lblNextYmd_Ms" runat="server"></asp:Label>)월 당월예측실적</td>
                                    <td align="center" class="cssTblTitle">
                                        (<asp:Label ID="lblNextYmd_Ts" runat="server"></asp:Label>)월 누적예측실적</td>
                                </tr>
                                <tr> 
                                    <td class="cssTblTitle">예상실적</td>
                                    <td style="height:20px; text-align:center" class="cssTblContent">
                                        <asp:Label ID="lblExtResult_MS" runat="server" Width="100%" Height="100%" BackColor="white"></asp:Label></td>
                                    <td style="height:20px; text-align:center" class="cssTblContent">
                                        <asp:Label ID="lblExtResult_TS" runat="server" Width="100%" Height="100%" BackColor="white"></asp:Label>
                                    </td>
                                </tr>
                                <tr> 
                                    <td class="cssTblTitle">예상근거
                                        <br />
                                        <asp:imagebutton ID="iBtnEXPECT_REASON_FILE_ID" ImageUrl="../images/icon/gr_po04.gif" runat="server"></asp:imagebutton>
                                    </td>
                                    <td align="center" style="height:80px;" class="cssTblContent">
                                        <asp:Label ID="lblEXPECT_REASON_MS" runat="server" Width="100%" BackColor="white" Height="100%"></asp:Label></td>
                                    <td align="center" style="height:80px;" class="cssTblContent">
                                        <asp:Label ID="lblEXPECT_REASON_TS" runat="server" Width="100%" BackColor="white" Height="100%"></asp:Label>
                                    </td>
                                </tr>
                              </table>
                          </td>
                        </tr>
                        
                        <tr>
                          <td style="vertical-align:top;">
                              <table style="border-width:0px; width:100%;">
                                <tr>
                                  <td>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td style="width:15px;">
                <img src="../images/title/ma_t14.gif" alt="" />
            </td>
            <td>
                <asp:Label id="Label6" runat="server" style="font-weight:bold" text="예측차이분석" />
            </td>
        </tr>
    </table>
                                  </td>
                                </tr>
                              </table>
                              
                              <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tableBorder">
                                <tr>
                                  <td colspan="2">
                                    <asp:GridView ID="grvResultExpt" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCreated="grvResultExpt_RowCreated" OnRowDataBound="grvResultExpt_RowDataBound" BorderStyle="NotSet">
                                      <Columns>
                                          <asp:BoundField HeaderText="구분" DataField="GUBUN">
                                              <ItemStyle CssClass="cssTblContent" />
                                              <HeaderStyle CssClass="cssTblTitle" />
                                          </asp:BoundField>
                                          <asp:BoundField HeaderText="계획" DataField="TARGET_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                              <HeaderStyle Width="100px" CssClass="cssTblTitle" />
                                              <ItemStyle HorizontalAlign="Right" CssClass="cssTblContent" />
                                          </asp:BoundField>
                                          <asp:BoundField HeaderText="실적" DataField="RESULT_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                              <HeaderStyle Width="100px" CssClass="cssTblTitle" />
                                              <ItemStyle HorizontalAlign="Right" CssClass="cssTblContent" />
                                          </asp:BoundField>
                                          <asp:BoundField HeaderText="달성율" DataField="AC_RATE_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                              <HeaderStyle Width="80px" CssClass="cssTblTitle" />
                                              <ItemStyle HorizontalAlign="Right" CssClass="cssTblContent" />
                                          </asp:BoundField>
                                          <asp:BoundField HeaderText="계획" DataField="TARGET_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                              <HeaderStyle Width="100px" CssClass="cssTblTitle" />
                                              <ItemStyle HorizontalAlign="Right" CssClass="cssTblContent" />
                                          </asp:BoundField>
                                          <asp:BoundField HeaderText="실적" DataField="RESULT_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                              <HeaderStyle Width="100px" CssClass="cssTblTitle" />
                                              <ItemStyle HorizontalAlign="Right" CssClass="cssTblContent" />
                                          </asp:BoundField>
                                          <asp:BoundField HeaderText="달성율" DataField="AC_RATE_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                              <HeaderStyle Width="80px" CssClass="cssTblTitle" />
                                              <ItemStyle HorizontalAlign="Right" CssClass="cssTblContent" />
                                          </asp:BoundField>
                                      </Columns>
                                      
                                    </asp:GridView> 
                                  </td>
                                </tr>
                                <tr>
                                    <th class="cssTblTitle">원인
                                        <asp:imagebutton ID="iBtnRESULT_DIFF_FILE_ID" ImageUrl="../images/icon/gr_po04.gif" runat="server"></asp:imagebutton>
                                    </th>
                                    <td style="height:80px;">
                                        <asp:Label ID="lbltxtRESULT_DIFF_CAUSE" runat="server" Width="100%" BackColor="white" Height="100%"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                              </table>
                              
                              
                              
                          </td>
                        </tr>
                      </table>    
                     </div>       
                    </td>
                  </tr>
                  <tr>
                    <td style="vertical-align:top;">
                     <div runat="server" id="block3"  style="display: block; margin-left: 1px; height:350px; vertical-align:top;">
                      <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                        <tr>
                          <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td style="width:15px;">
                <img src="../images/title/ma_t14.gif" alt="" />
            </td>
            <td>
                <asp:Label id="Label7" runat="server" style="font-weight:bold" text="Comunication" />
            </td>
        </tr>
    </table>
                          </td>
                        </tr>
                        <tr style="height:100%;">
                          <td style="vertical-align:top;">
                             <ig:UltraWebGrid ID="ugrdCommunication" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdCommunication_InitializeRow" >
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="READ_YN" Key="READ_YN" Hidden="true" Width="20px">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Header>
                                                <CellStyle HorizontalAlign="center"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LIST_REF_ID" HeaderText="No" Key="NUM_TEXT" Width="50px" FooterText="">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="글번호">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="130px" HeaderText="제목">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI 명">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="272px" HeaderText="제목">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="제목">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="ATTACH_NO" Key="ATTACH_NO" Width="40px" FooterText="" HeaderText="첨부" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="첨부">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="OWNER_NAME" Key="OWNER_NAME" Width="70px" FooterText="" HeaderText="작성자">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="작성자">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="100px" FooterText="" HeaderText="조직">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="운영조직">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="READ_COUNT" Key="READ_COUNT" Width="50px" FooterText="" HeaderText="조회수" Hidden="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="조회수">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="70px" Format="yyyy-MM-dd" FooterText="" HeaderText="작성일자">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="작성일자">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="IDX" Key="IDX" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BOARD_CATEGORY" Key="BOARD_CATEGORY" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LIST_REF_ID" Key="LIST_REF_ID" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="11" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="11" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="OWNER_EMP_ID" Key="OWNER_EMP_ID" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="TREE_LEVEL" Key="TREE_LEVEL" Hidden="True">
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" 
                                               AllowColSizingDefault="Free" 
                                               AllowColumnMovingDefault="OnServer" 
                                               AllowDeleteDefault="Yes"
                                                AllowSortingDefault="Yes" 
                                                BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" 
                                                Name="UltraWebGrid1" 
                                                RowHeightDefault="20px"
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended" 
                                                Version="4.00" 
                                                CellClickActionDefault="RowSelect" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="Header" 
                                                AutoGenerateColumns="False">
                                       <%-- <GroupByBox>
                                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="99%"
                                            Width="771px">
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
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="DblClickHandler" />
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>--%>
                                    <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                    <ClientSideEvents DblClickHandler="DblClickHandler" />
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                          </td>
                        </tr>
                        <tr>
                          <td style="height:20px;" align="left">
                            <asp:ImageButton ID="iBtnWriteComm" runat="server" ImageUrl="../images/btn/b_127.gif" OnClientClick="return OpenCommunicationWindow();" />&nbsp;&nbsp;&nbsp;
                          </td>
                        </tr>
                      </table>
                     </div>
                    </td>
                  </tr>
                 </table>
              </div>
            </td>
          </tr>
          <tr class="cssPopBtnLine">
            <td>
                <table style="height:100%; width:100%;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <img alt="실적정보 그래프 숨기기"  src="../images/btn/b_tp01_1.gif" style="CURSOR: hand;"  onclick="clickshow(0)" id="img0" name="img0"  />
                            <img alt="실적정보 상세 숨기기"  src="../images/btn/b_tp02_1.gif" style="CURSOR: hand;" onclick="clickshow(1)"  id="img1" name="img1"   /> 
                            <img alt="원인분석 및 대책검토 숨기기"  src="../images/btn/b_tp03_1.gif" style="CURSOR: hand;" onclick="clickshow(2)"  id="img2" name="img2" /> 
                            <img alt="<%=this.GetText("LBL_00004", "Communication")%> 숨기기"  src="../images/btn/b_tp04_1.gif" style="CURSOR: hand;" onclick="clickshow(3)"  id="img3" name="img3" /> 
                        </td>
                        <td align="right">
                            <img alt="" src="../images/btn/b_049.gif" onclick="OpenShowRelationKpi();" style="cursor:hand; visibility:hidden;" /> 
                            <asp:ImageButton ID="iBtnGoBack" runat="server" ImageUrl="../images/btn/b_140.gif" OnClientClick="return GoBack();" />
                            <asp:ImageButton ID="iBtnOrgMap" OnClientClick="GoUrl('home'); return false;" ImageUrl="../images/btn/b_137.gif" runat="server" />
                            <img alt="" src="../images/btn/b_048.gif" onclick="OpenShowKpiDetail();" style="cursor:hand;" />
                            <asp:ImageButton ID="ImgBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClientClick="return OpenPrintPage();" OnClick="ImgBtnPrint_Click" />
                            <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
                            <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport" OnCellExporting="ugrdEEP_CellExporting">
                            </ig:UltraWebGridExcelExporter>
                            <asp:HiddenField ID="hdfResultDiffFileId" runat="server" Value="" />
                            <asp:HiddenField ID="hdfExpectReasonFileId" runat="server" Value="" />
                        </td>
                    </tr>
                </table>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</asp:Panel>
<!--- MAIN END --->
</asp:Content>