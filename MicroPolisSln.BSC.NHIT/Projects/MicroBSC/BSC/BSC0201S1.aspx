<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0201S1.aspx.cs" Inherits="BSC_BSC0201S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
    <script id="Infragistics" type="text/javascript">

        function checkPossibleCopy() {
            var termID1 = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
            var termID2 = document.getElementById("<% =this.ddlEstTermInfo2.ClientID.Replace('_','$') %>").value;

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

            return confirm('내보내시겠습니까?');
        }
//        
//        function MouseOverHandler(gridName, id, objectType)
//        {
//	        if(objectType == 0) 
//	        { // Are we over a cell
//               var cell             = igtbl_getElementById(id);
//               var row              = igtbl_getRowById(id);
//               var band             = igtbl_getBandById(id);
//               var active           = igtbl_getActiveRow(id);
//               var termName         = row.getCellFromKey("STG_NAME").getValue();
//               cell.style.cursor    = 'hand';
//            }
//        }
//        
        function DblClickHandler(gridName, id) 
        {
            var cell     = igtbl_getElementById(id);
            var row      = igtbl_getRowById(id);
            var termID   = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var stgID    = row.getCellFromKey("STG_REF_ID").getValue();
            var stgName  = row.getCellFromKey("STG_NAME").getValue();
             var stgYN   = row.getCellFromKey("USE_YN").getValue() =='Y'? 'U':'D';
             
            var ICCB1    = "<%= this.ICCB1 %>";
            
            var strURL   = 'BSC0201M1.aspx?iType=' + stgYN +'&ESTTERM_REF_ID='+ termID +'&STG_REF_ID='+stgID+'&CCB1='+ICCB1;
            
            gfOpenWindow(strURL, 620, 450, 'BSC0201M1U');
        }

        function doPoppingUp_StgList(stgYN, termID, stgID, ICCB1) {
           
            var strURL = 'BSC0201M1.aspx?iType=' + stgYN
                                     + '&ESTTERM_REF_ID=' + termID
                                     + '&STG_REF_ID=' + stgID 
                                     + '&CCB1=' + ICCB1;

            gfOpenWindow(strURL, 620, 450, 'BSC0201M1U');
        }
//        
        function OpenInsertWindow()
        {
            var termID = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
            var stgID  = '0';
            var ICCB1  = "<%= this.ICCB1 %>";
            
            var strURL = 'BSC0201M1.aspx?iType=A&ESTTERM_REF_ID='+ termID +'&STG_REF_ID='+stgID+'&CCB1='+ICCB1;
            gfOpenWindow(strURL, 620, 450,'BSC0201M1A');
       
        }
    </script>

		<table style="height:100%;">
		    <tr>
		        <td>
                    <table border="0" cellpadding="0" class="tableBorder" cellspacing="0" width="100%">
                        <tr>
                            <td class="cssTblTitle">평가기간</td>
                            <td class="cssTblContent">
                                <asp:dropdownlist ID="ddlEstTermInfo" runat="server" width="100%" CssClass="box01"></ASP:dropdownlist>
                            </td>
                            <td class="cssTblTitle">전략코드</td>
                            <td class="cssTblContent">
                                <asp:textbox id="txtKPICode" runat="server" width="100%"></asp:textbox>
                            </td>
                        </tr>
                        <tr>
                            <td  class="cssTblTitle">전략명</td>
                            <td class="cssTblContent">
                                <asp:textbox id="txtKPIName" runat="server" width="100%"></asp:textbox>
                            </td>
                            <td class="cssTblTitle">사용여부</td>
                            <td class="cssTblContent">
                                <asp:dropdownlist id="ddlUseYn" runat="server" Width="100%"  CssClass="box01"></asp:dropdownlist>
                            </td>
                        </tr>
                    </table>
		        </td>
		    </tr>
		    <tr class="cssPopBtnLine">
		        <td align="right">
                    <asp:imagebutton id="iBtnSearch" runat="server" align="absmiddle" imageurl="../images/btn/b_033.gif" onclick="iBtnSearch_Click"></asp:imagebutton>
                </td>
		    </tr>
		    <tr valign="top" style="height:100%;">
			    <td >
		            <ig:UltraWebGrid ID="ugrdStgList" runat="server" Width="100%" Height="100%" style="top: 1px" OnInitializeRow="ugrdStgList_InitializeRow">
                        <Bands>
                            <ig:UltraGridBand>
                                <Columns>
                                    <ig:TemplatedColumn Hidden="true" HeaderText="선택" Width="30px">
                                        <Header Caption="선택">
                                        </Header>
                                       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
                                        Format="" HeaderText="전략코드" Key="STG_CODE" Width="80px">
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
                                    <ig:UltraGridColumn BaseColumnName="STG_SET_DESC" Key="STG_SET_DESC" Width="430px" FooterText="" HeaderText="전략 설정 사유">
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
                                </Columns>
                            </ig:UltraGridBand>
                        </Bands>
                        <DisplayLayout AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="OnServer" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate" 
                                    AutoGenerateColumns="False"
                                    HeaderClickActionDefault="SortMulti" 
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
		    <tr>
		        <td>
		            <table border="0" cellpadding="0"  cellspacing="0" width="100%">
		                <td height="25">
			                평가중인 평가대상기간&nbsp;:&nbsp;<asp:dropdownlist ID="ddlEstTermInfo2" runat="server" class="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo2_SelectedIndexChanged"></ASP:dropdownlist>
                            <asp:imagebutton id="ibtnCopy" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_054.gif" OnClientClick="return checkPossibleCopy();" onclick="ibtnCopy_Click"></asp:imagebutton>
			                <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
			            </td>
			            <td align="right">
			                <div id='divAdd' runat="server">
			                   <img alt="" src="../images/btn/b_005.gif" style="cursor:hand;" onclick="OpenInsertWindow();" border="0" />
			                </div>
			            </td>
		            </table>
		        </td>
		    </tr>
		</table>
		
</asp:Content>
