<%@ Page Language="C#" MasterPageFile="~/_common/lib/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC0102S1.aspx.cs" Inherits="BSC_BSC0102S1" %>

<asp:Content ID="cttContents" ContentPlaceHolderID="Contents" Runat="Server">
<script type="text/javascript">

    //-- Tree 보이고 숨기기 /
    function showMemo() {
        document.all.imgShow.style.display = "none";
        document.all.imgHide.style.display = "block";
        document.all.leftLayer.style.display = "block";
    }

    function hiddenMemo() {
        document.all.imgShow.style.display = "block";
        document.all.imgHide.style.display = "none";
        document.all.leftLayer.style.display = "none";
    }
    
    //-- 관점관리 추가 /
    function OpenInsertWindow() {
        var ICCB1 = "<%= this.ICCB1 %>";
        gfOpenWindow('BSC0101M1.aspx?iType=A&VIEW_REF_ID=0&CCB1=' + ICCB1, 650, 380);
    }
    
    //-- 관점관리 그리드 클릭 /
    function doPoppingUp_View(viewYN, viewID, ICCB1) {
      
      var popHeight = 340 + <%=POP_HEIGHT %>;
        gfOpenWindow('BSC0101M1.aspx?iType=' + viewYN
                                 + '&VIEW_REF_ID=' + viewID
                                 + '&CCB1=' + ICCB1
                                 , 650
                                 , popHeight);
    }
    
    
    //-- 전략관리 내보내기 클릭 /
    function checkPossibleCopy() {
        <%--var termID1 = document.getElementById("<%=ugrdKpiStatusTab.FindControl("ddlEstTermInfo").ClientID %>").value;
        var termID2 = document.getElementById("<%=ugrdKpiStatusTab.FindControl("ddlEstTermInfo2").ClientID %>").value;

        if (termID1 == termID2) {
            alert('동일한 평가기간을 복사할 수 없습니다.');
            return false;
        }

        var isPossible = '<%= this.IPOSSIBLE_COPY %>';
        if (isPossible.toUpperCase() == 'FALSE')
        {
            alert('이미 해당평가기간에 등록된 전략이 존재하여 내보낼 수 없습니다!');
            return false;
        }

        return confirm('내보내시겠습니까?');--%>
    }

    //-- 전략관리 추가 클릭 /
    function OpenInsertWindow2()
    {
        var termID = document.getElementById("<%=ugrdKpiStatusTab.FindControl("ddlEstTermInfo").ClientID %>").value;
        var stgID  = '0';
        var ICCB1  = "<%= this.ICCB1 %>";
        
        var strURL = 'BSC0201M1.aspx?iType=A&ESTTERM_REF_ID='+ termID +'&STG_REF_ID='+stgID+'&CCB1='+ICCB1;
        gfOpenWindow(strURL, 620, 380, 'BSC0201M1A');
    }
    
    //-- 전략관리 그리드 클릭 /
    function doPoppingUp_StgList(stgYN, termID, stgID, ICCB1) {
       
        var strURL = 'BSC0201M1.aspx?iType=' + stgYN
                                 + '&ESTTERM_REF_ID=' + termID
                                 + '&STG_REF_ID=' + stgID 
                                 + '&CCB1=' + ICCB1;

        gfOpenWindow(strURL, 620, 380, 'BSC0201M1U');
    }

    //-- kpi풀관리 추가 /
    function OpenInsertWindow3()
    {
        var kpiID  = '';
        var ICCB1 = "<%= this.ICCB1 %>";
        
        var strURL = 'BSC0301M1.aspx?iType=A&KPI_POOL_REF_ID='+ kpiID+'&CCB1='+ICCB1;
        //gfOpenWindow(strURL, 720, 690, 'BSC0301M1');
        var topValue = (((screen.height - 670) / 2) - 50);
	    if (topValue < 0)
	        topValue = 0;
        var argString = "width=900px,height=670px,left=" + ((screen.width - 670) / 2) + ", top=" + topValue + ",scrollbars=yes,resizable=no";
        window.open(strURL,'BSC0301M1',argString);
        return false;
    }
    
    //-- kpi풀 그리드 클릭 /
    function doInsertingKpi(kpiYN, kpiID, ICCB1) {
        
        var strURL = 'BSC0301M1.aspx?iType=' + kpiYN + '&KPI_POOL_REF_ID=' + kpiID + '&CCB1=' + ICCB1;
        var topValue = (((screen.height - 670) / 2) - 50);
	    if (topValue < 0)
	        topValue = 0;
        var argString = "width=900px,height=670px,left=" + ((screen.width - 670) / 2) + ", top=" + topValue + ",scrollbars=yes,resizable=no";
        window.open(strURL,'BSC0301M1',argString);
        //gfOpenWindow(strURL, 'BSC0301M1',argString);
    }
    function ugrdKPIPool_DblClickHandler(gridName, cellId)
    {
        var cell    = igtbl_getElementById(cellId);
        var row     = igtbl_getRowById(cellId);
        var kpiID   = row.getCellFromKey("KPI_POOL_REF_ID").getValue();
        var kpiYN   = row.getCellFromKey("USE_YN").getValue() =='Y'? 'U':'D';
       
        
        var ICCB1 = "<%= this.ICCB1 %>";
        
        var strURL = 'BSC0301M1.aspx?iType=' + kpiYN + '&KPI_POOL_REF_ID='+ kpiID+'&CCB1='+ICCB1;
        var topValue = (((screen.height - 670) / 2) - 50);
	    if (topValue < 0)
	        topValue = 0;
        //gfOpenWindow(strURL, 720, 670,"BSC0301M1");
        var argString = "width=900px,height=670px,left=" + ((screen.width - 670) / 2) + ", top=" + topValue + ",scrollbars=yes,resizable=no";
        window.open(strURL,'BSC0301M1',argString);
    }
    
</script>
<input type="hidden" name="treemenu" id="treemenu" value="0" />
<table cellpadding="0" cellspacing="0" border="0" height="100%" width="100%">
	<tr valign="top">
		<td colspan="2">
            <div style=" overflow:auto; width:100%; height:100%;">
                <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%">
                <tr>
                    <td width="5px">
                    <!--- Tree  --->	
                    <div id="leftLayer" style="border:#F4F4F4 1 solid; DISPLAY:block; overflow: auto; position:static; 
                    width: 200px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                            <asp:TreeView ID="trvEstDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                                <ParentNodeStyle Font-Bold="False" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                    NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                    </div>
                    <!--- /Tree  --->
        	        </td>
                    <td width="5px">
                    <!--- 이미지  --->	
                    <a href="javascript:hiddenMemo();"><img alt="" src="../images/btn/btn_Hide.gif" id="imgHide" /></a><br />
                    <a href="javascript:showMemo();"><img alt="" src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" /></a>
                    </td>
                    <td valign="top">
                    <ig:UltraWebTab runat="server" ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="False" Width="100%" SelectedTab="0" AutoPostBack="True" OnTabClick="ugrdKpiStatusTab_TabClick">
                    <Tabs>
                        <ig:Tab Text="관점관리" Key="1">
                        <Style Width="160px" Height="25px"/>
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%; vertical-align:top;">
                            <tr>
                              <td valign="top">
                                <ig:UltraWebGrid ID="ugrdView" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdView_InitializeRow">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:TemplatedColumn Hidden="True">
                                                    <Header Caption="선택"></Header>
                                                    <Footer Caption=""></Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn Key="VIEW_REF_ID" BaseColumnName="VIEW_REF_ID" Hidden="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="관점ID"><RowLayoutColumnInfo OriginX="1" /></Header>
                                                    <Footer Caption=""><RowLayoutColumnInfo OriginX="1" /></Footer>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn Key="VIEW_SEQ" BaseColumnName="VIEW_SEQ" Width="40px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="순서">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn Key="VIEW_NAME" BaseColumnName="VIEW_NAME" Width="150px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="관점명"><RowLayoutColumnInfo OriginX="3" /></Header>
                                                    <Footer Caption=""><RowLayoutColumnInfo OriginX="3" /></Footer>
                                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn Key="USE_YN" BaseColumnName="USE_YN" Width="35px">
                                                  <Header Caption="사용">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                  </Header>
                                                  <HeaderStyle Wrap="true" HorizontalAlign="Center"/>
                                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                                  <CellTemplate>
                                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                  </CellTemplate>
                                                  <Footer Caption=""><RowLayoutColumnInfo OriginX="4" /></Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn Key="VIEW_DESC" BaseColumnName="VIEW_DESC" Width="240px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="관점 설명"><RowLayoutColumnInfo OriginX="5" /></Header>
                                                    <Footer Caption=""><RowLayoutColumnInfo OriginX="5" /></Footer>
                                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn Key="VIEW_ETC" BaseColumnName="VIEW_ETC" Width="300px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="비고"><RowLayoutColumnInfo OriginX="6" /></Header>
                                                    <Footer Caption=""><RowLayoutColumnInfo OriginX="6" /></Footer>
                                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout  Name="ugrdView" 
                                                    Version="4.00"  
                                                    CellPaddingDefault="2" 
                                                    AllowColSizingDefault="Free" 
                                                    BorderCollapseDefault="Separate" 
                                                    AutoGenerateColumns="False"
                                                    HeaderClickActionDefault="SortMulti" 
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Single" 
                                                    CellClickActionDefault="RowSelect" 
                                                    TableLayout="Fixed" 
                                                    ReadOnly="LevelTwo"
                                                    StationaryMargins="Header">
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            <Images>
	                                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
	                                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                            </Images>
                                        </DisplayLayout>
                                </ig:UltraWebGrid>  
                              </td>
                            </tr>
                            <tr style="height:25px;">
                                <td align="right">
                                    <div id='divAdd' runat="server">
			                            <img alt="" src="../images/btn/b_005.gif" style="cursor:hand;" onclick="OpenInsertWindow();" />
			                        </div>
                                </td>
                            </tr>
                            </table>
                        </ContentTemplate>
                        </ig:Tab>
                        <ig:Tab Text="전략관리" Key="2">
                        <Style Width="160px" Height="25px"/>
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%; vertical-align:top;">
                            <tr>
                              <td valign="top">
                                  <table border="0" cellpadding="0" class="tableBorder" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="cssTblTitle">상위관점</td>
                                        <td class="cssTblContent">
                                            <asp:dropdownlist ID="ddlEstTermInfo" runat="server" CssClass="box01" style="display:none;"></ASP:dropdownlist>
                                            <asp:DropDownList ID="ddlStgViewInfo" runat="server" Width="100%" CssClass="box01"></asp:DropDownList>
                                        </td>
                                        <!--
                                        <td class="cssTblTitle">전략코드</td>
                                        <td class="cssTblContent">
                                            <asp:textbox id="txtKPICode" runat="server" width="100%"></asp:textbox>
                                        </td>
                                        -->
                                        <td  class="cssTblTitle">전략명</td>
                                        <td class="cssTblContent">
                                            <asp:textbox id="txtKPIName" runat="server" width="100%"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle">사용여부</td>
                                        <td class="cssTblContent" colspan="3">
                                            <asp:dropdownlist id="ddlUseYn" runat="server" Width="100px"  CssClass="box01"></asp:dropdownlist>
                                        </td>
                                    </tr>
                                  </table>
                              </td>
                            </tr>
                            <tr style="height:25px;">
                              <td align="right">
                                <asp:imagebutton id="iBtnSearch" runat="server" align="absmiddle" imageurl="../images/btn/b_033.gif" onclick="iBtnSearch_Click"></asp:imagebutton>
                              </td>
                            </tr>
                            <tr style="height:100%;">
                              <td>
                                <ig:UltraWebGrid ID="ugrdStgList" runat="server" Width="100%" Height="100%" style="top: 1px" OnInitializeRow="ugrdStgList_InitializeRow">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:TemplatedColumn Key="selchk" Width="25px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellTemplate>
                                                            <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer"/>
                                                        </CellTemplate>
                                                        <HeaderTemplate>
                                                            <input type="checkbox" id="ck1" onclick="selectChkBox(this,'ugrdStgList');" />
                                                            
                                                        </HeaderTemplate>
                                                        <Header>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID" Width="40px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="ESTTERM_REF_ID">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STG_REF_ID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="전략ID" Hidden="True" Key="STG_REF_ID" Width="40px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="전략ID">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STG_CODE" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="전략코드" Key="STG_CODE" Width="80px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="전략코드">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STG_NAME" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="전략명" Key="STG_NAME" Width="250px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="전략명">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="VIEW_NAME" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="상위관점" Key="VIEW_NAME" Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상위관점">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn BaseColumnName="MAPYN" Key="MAPYN" EditorControlID="" Width="47px" FooterText="" HeaderText="템플릿">
                                                  <Header Caption="템플릿">
                                                    <RowLayoutColumnInfo OriginX="5"/>
                                                  </Header>
                                                  <HeaderStyle Wrap="True" HorizontalAlign="Center"/>
                                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                                  <CellTemplate>
                                                    <asp:image runat="server" id="imgUseMapYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                  </CellTemplate>
                                                  <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                  </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="47px" FooterText="" HeaderText="사용여부">
                                                  <Header Caption="사용">
                                                    <RowLayoutColumnInfo OriginX="5"/>
                                                  </Header>
                                                  <HeaderStyle Wrap="True" HorizontalAlign="Center"/>
                                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                                  <CellTemplate>
                                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                  </CellTemplate>
                                                  <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                  </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="STG_SET_DESC" Key="STG_SET_DESC" Width="380px" FooterText="" HeaderText="전략 설정 사유">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="전략 설정 사유">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STG_ETC" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="비고" Hidden="True" Key="STG_ETC" Width="200px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="비고">
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STG_VIEW" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="STG_VIEW" Hidden="True" Key="STG_VIEW">
                                                    <Header Caption="STG_VIEW">
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="VIEW_REF_ID" Key="VIEW_REF_ID" Width="100px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="VIEW_REF_ID">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout AllowColSizingDefault="Free" 
                                                AllowColumnMovingDefault="OnServer" 
                                                AllowDeleteDefault="Yes"
                                                AllowSortingDefault="No"
                                                BorderCollapseDefault="Separate" 
                                                AutoGenerateColumns="False"
                                                HeaderClickActionDefault="NotSet"
                                                Name="ugrdStgList" 
                                                RowHeightDefault="20px" 
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Single" 
                                                Version="4.00" 
                                                CellClickActionDefault="RowSelect" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="HeaderAndFooter" 
                                                OptimizeCSSClassNamesOutput="False"
                                                ReadOnly="LevelTwo"
                                                ViewType="Flat">
                                           
                                        
                                            <GroupByBox>
                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                            </GroupByBox>
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
                                            <ClientSideEvents DblClickHandler="DblClickHandler"/>
                                            <Images>
	                                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
	                                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                            </Images>
                                        </DisplayLayout>
                                </ig:UltraWebGrid>    
                              </td>
                            </tr>
                            <tr style="height:25px;">
                                <td align="right">
                                    <table border="0" cellpadding="0"  cellspacing="0" width="100%">
		                                <td height="25">
			                                <%--평가중인 평가대상기간&nbsp;:&nbsp;<asp:dropdownlist ID="ddlEstTermInfo2" runat="server" class="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo2_SelectedIndexChanged"></ASP:dropdownlist>
                                            <asp:imagebutton id="ibtnCopy" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_054.gif" OnClientClick="return checkPossibleCopy();" onclick="ibtnCopy_Click"></asp:imagebutton>--%>
			                                <asp:imagebutton id="btnMapEdit" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/btn_Tsave.gif" onclick="btnMapEdit_Click"></asp:imagebutton>
			                                <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
			                            </td>
			                            <td align="right">
			                                <div id='div1' runat="server">
			                                   <img alt="" src="../images/btn/b_005.gif" style="cursor:hand;" onclick="OpenInsertWindow2();" border="0" />
			                                </div>
			                            </td>
		                            </table>
                                </td>
                            </tr>
                            </table>
                        </ContentTemplate>
                        </ig:Tab>
                        <ig:Tab Text="KPI풀 관리" Key="3">
                        <Style Width="160px" Height="25px"/>
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%; vertical-align:top;">
                                <tr>
                                  <td valign="top">
                                    <table class="tableBorder" cellspacing="0" width="100%">
                                        <tr>
                                            
                                            <td class="cssTblTitle">KPI 명</td>
                                            <td class="cssTblContent">
                                                <asp:TextBox ID="txtKpiNames" runat="server" width="100%"></asp:TextBox>
                                            </td>
                                            
                                            <td class="cssTblTitle">상위전략</td>
                                            <td class="cssTblContent">
                                                <asp:dropdownlist runat="server" id="ddlUpPoint" Width="100%" CssClass="box01"></asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="cssTblTitle">KPI 구분</td>
                                            <td class="cssTblContent">
                                                <asp:DropDownList ID="ddlKpi" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                                            </td>
                                            <td class="cssTblTitle">KPI 유형</td>
                                            <td class="cssTblContent">
                                                <asp:DropDownList ID="ddlKpiType" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="cssTblTitle">버전</td>
                                            <td class="cssTblContent">
                                                <asp:DropDownList ID="ddlKpiVersion" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                                            </td>
                                            <td class="cssTblTitle">템플릿</td>
                                            <td class="cssTblContent">
                                                <asp:DropDownList ID="ddlKpiTemplete" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="cssTblTitle">사용여부</td>
                                            <td class="cssTblContent" colspan="3">
                                                <asp:dropdownlist runat="server" id="ddlUseYn3" Width="41%" CssClass="box01"></asp:dropdownlist>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr style="height:25px;">
                                  <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left" width="110">
                                                        <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                                        <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                                        <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                                                    </td>
                                                    <td align="right";">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click3" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr style="height:100%;">
                                  <td>
                                  <ig:UltraWebGrid ID="ugrdKPIPool" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKPIPool_InitializeRow" >
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <Columns>
                                                    <ig:TemplatedColumn Key="selchk" Width="25px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellTemplate>
                                                            <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer"/>
                                                        </CellTemplate>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'ugrdKPIPool');" />
                                                        </HeaderTemplate>
                                                        <Header>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" EditorControlID="" FooterText=""
                                                        Format="" HeaderText="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" Width="100px" Hidden="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="KPI_POOL_REF_ID">
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="230px">
                                                        <Header Caption="KPI 명">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ValueList DisplayStyle="NotSet">
                                                        </ValueList>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="VIEW_NAME" Key="VIEW_NAME" Width="100px">
                                                        <Header Caption="관점">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ValueList DisplayStyle="NotSet">
                                                        </ValueList>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="STG_NAME" Key="STG_NAME" Width="100px">
                                                        <Header Caption="상위전략">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ValueList DisplayStyle="NotSet">
                                                        </ValueList>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_EXTERNAL_TYPE_NAME" Key="KPI_EXTERNAL_TYPE_NAME" Width="70px">
                                                        <Header Caption="KPI 구분">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ValueList DisplayStyle="NotSet">
                                                        </ValueList>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="70px">
                                                        <Header Caption="KPI 유형">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ValueList DisplayStyle="NotSet">
                                                        </ValueList>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부">
                                                      <Header Caption="사용">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                      </Header>
                                                      <HeaderStyle Wrap="True" />
                                                      <CellStyle HorizontalAlign="Center"></CellStyle>
                                                      <CellTemplate>
                                                        <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                                      </CellTemplate>
                                                      <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                      </Footer>
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="KPI_DESC" HeaderText="KPI 설명" Key="KPI_DESC" Width="370px">
                                                        <Header Caption="KPI 설명">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                </Columns>
                                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                </RowTemplateStyle>
                                            </ig:UltraGridBand>
                                        </Bands>
                                         <DisplayLayout CellPaddingDefault="2"
                                                        AllowColSizingDefault="Free"
                                                        AllowColumnMovingDefault="OnServer"
                                                        AllowDeleteDefault="Yes"
                                                        AllowSortingDefault="Yes"
                                                        BorderCollapseDefault="Separate"
                                                        HeaderClickActionDefault="NotSet"
                                                        Name="ugrdKPIPool"
                                                        RowHeightDefault="20px"
                                                        RowSelectorsDefault="No"
                                                        SelectTypeRowDefault="Extended"
                                                        Version="4.00"
                                                        ViewType="OutlookGroupBy"
                                                        CellClickActionDefault="RowSelect"
                                                        TableLayout="Fixed"
                                                        StationaryMargins="Header"
                                                        AutoGenerateColumns="False" 
                                                        ReadOnly="LevelTwo"
                                                        OptimizeCSSClassNamesOutput="False">
                                            <GroupByBox>
                                                <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                                            </GroupByBox>
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                            <ClientSideEvents DblClickHandler="ugrdKPIPool_DblClickHandler" />
                                            </DisplayLayout>
                                    </ig:UltraWebGrid>   
                                  </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
		                                <asp:linkbutton id="lBtnReload3" runat="server" OnClick="lBtnReloadKpi"></asp:linkbutton>
                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="width:50%;">
                                                <asp:ImageButton runat="server" ID="iBtnVersion" ImageUrl="../images/btn/btn_Vmanage.gif" ImageAlign="AbsMiddle" onClick="iBtnVersion_Click" />
                                                <asp:ImageButton runat="server" ID="iBtnTemplete" ImageUrl="../images/btn/btn_Tmanage.gif" ImageAlign="AbsMiddle" onClick="iBtnTemplete_Click" />
			                                </td>
			                                <td style="width:50%;" align="right">
                                                <asp:ImageButton runat="server" ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif" ImageAlign="AbsMiddle" OnClientClick="return OpenInsertWindow3();" />
			                                </td>
                                        </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        </ig:Tab>
                    </Tabs>
                    <DefaultTabStyle BackColor="White" CssClass="cssTabStyleOff" />
                    <SelectedTabStyle CssClass="cssTabStyleOn" />
                    <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif" SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                    </ig:UltraWebTab>
                    </td>
                </tr>
                </table>
            </div>
        </td>
	</tr>
</table>

</asp:Content>


