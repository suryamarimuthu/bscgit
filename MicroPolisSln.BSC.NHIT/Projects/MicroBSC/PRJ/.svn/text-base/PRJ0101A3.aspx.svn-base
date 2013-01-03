<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0101A3.aspx.cs" Inherits="PRJ_PRJ0101A3" enableEventValidation="false" %>


<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    <script type="text/javascript" language="javascript">

    /*=========================================================================
     호출 파라미터 결재상신, 재상신 처리
     prj_ref_id     : 결재원문파라미터
     app_ref_id     : 결재문서가 최초버젼일 아닐경우
     biz_type       : KDA:지표정의서 결재, KRA:지표실적결재, PMA:사업관리
     app_ccb        : 결재처리후 호출화면에서 처리시 컨트롤 client id 넘겨줌
   //========================================================================*/
   function OpenDraft(draftStatus)
   {
        
        var prj_ref_id      = "<%= this.IPrjRefID %>";     
        var app_ref_id      = "<%= this.IApp_Ref_Id %>";
        var app_ccb         = "<%= this.IAPP_CCB %>";
        var biz_type        = "<%= Biz_Type.biz_type_prj_doc %>";
        
        var draft_emp_id    = parseInt("<%= this.IDraftEmpID %>",10);
        
        if (draft_emp_id=="NaN" || draft_emp_id  < 1)
        {
            alert("기안자 정보를 알수 없습니다.");
            return false;
        }
        
        var url             = "../BSC/BSC0901M1.aspx?DRAFT_STATUS="+draftStatus+"&PRJ_REF_ID=" + prj_ref_id + "&BIZ_TYPE="+biz_type+"&APP_CCB="+app_ccb+"&APP_REF_ID="+app_ref_id+"&DRAFT_EMP_ID="+draft_emp_id;

        gfOpenWindow(url, 900, 650, 'BSC0901M1');
        
        return false;
   }
    </script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        <table cellpadding="2" cellspacing="0" border="0" width="100%"> 
            <tr>
     <td class="tableOutBorder">
       <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="tableTitle" align="center" style="width:100px; height: 22px">사업 CODE</td>
            <td class="tableContent" style="height: 22px">
              <asp:TextBox ID="txtPRJ_CODE" runat="server" BorderWidth="0" BackColor="LightGray" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="tableTitle" align="center" style="width:100px; height: 22px">
                사 업 명</td>
	        <td class="tableContent" valign="middle" style="height: 22px">
                <asp:TextBox ID="txtPRJ_NAME" runat="server" Width="450px" BorderWidth="0" BackColor="LightGray" ReadOnly="True"></asp:TextBox>
             </td>
        </tr>
       </table>
     </td>
    </tr>
         </table>
         <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:560px;">
                          <tr style="height:15px;">
                              <td valign="top" style="width: 734px" colspan="2">
                                  :: 월별 예산 ::
                               </td>
                              </tr>
                              <tr>
                                <td class="tableTitle" style="width:13%;" align="left">
                                  프로젝트기간
                                </td>
                                <td>
                                    <asp:Label ID="lblPrjPeriod" runat="server" Width="400px"></asp:Label></td>
                              </tr>
                              <tr>
                                <td class="tableTitle" style="width:13%;" align="left">
                                  총예산금액
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalBudgetAmount" runat="server" Width="400px"></asp:Label></td>
                              </tr>
                              <tr>
                              <td colspan="2" style="height:10px;" align="left" valign="top"></td>
                              </tr>
                              <tr>
                                  <td valign="top" colspan="2">
                                    <ig:UltraWebGrid ID="ugrdBudgetList" runat="server" Width="100%" Height="300px" OnInitializeLayout="ugrdBudgetList_InitializeLayout" OnInitializeRow="ugrdBudgetList_InitializeRow" >
                                      <Bands>
                                          <ig:UltraGridBand>
                                              <AddNewRow View="NotSet" Visible="NotSet">
                                              </AddNewRow>
                                              <Columns>
                                                  <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="iTYPE" Hidden="True" Key="ITYPE">
                                                      <Header Caption="iTYPE">
                                                      </Header>
                                                  </ig:UltraGridColumn>
                                                  <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                                      FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID">
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
                                                  <ig:UltraGridColumn BaseColumnName="BUDGET_YM" HeaderText="BUDGET_YM" Hidden="True"
                                                      Key="BUDGET_YM">
                                                      <Header Caption="BUDGET_YM">
                                                          <RowLayoutColumnInfo OriginX="2" />
                                                      </Header>
                                                      <Footer>
                                                          <RowLayoutColumnInfo OriginX="2" />
                                                      </Footer>
                                                  </ig:UltraGridColumn>
                                                  <ig:UltraGridColumn BaseColumnName="BUDGET_YM_NAME" EditorControlID="" FooterText=""
                                                      Format="" HeaderText="년 월" Key="BUDGET_YM_NAME" Width="90px">
                                                      <HeaderStyle HorizontalAlign="Center" />
                                                      <CellStyle HorizontalAlign="Left">
                                                      </CellStyle>
                                                      <Header Caption="년 월">
                                                          <RowLayoutColumnInfo OriginX="3" />
                                                      </Header>
                                                      <Footer Caption="" Title="합 계">
                                                          <RowLayoutColumnInfo OriginX="3" />
                                                      </Footer>
                                                  </ig:UltraGridColumn>
                                                  <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="MONTHLY_AMOUNT" FooterText=""
                                                      Format="###,###,###,###,##0" HeaderText="계획예산" Key="MONTHLY_AMOUNT" Width="260px">
                                                      <FooterStyle BackColor="#C0C0FF" ForeColor="Black" />
                                                      <HeaderStyle HorizontalAlign="Center" />
                                                      <ValueList DisplayStyle="NotSet">
                                                      </ValueList>
                                                      <CellStyle HorizontalAlign="Left">
                                                      </CellStyle>
                                                      <SelectedCellStyle HorizontalAlign="Right">
                                                      </SelectedCellStyle>
                                                      <Header Caption="계획예산">
                                                          <RowLayoutColumnInfo OriginX="4" />
                                                      </Header>
                                                      <Footer Caption="">
                                                          <RowLayoutColumnInfo OriginX="4" />
                                                      </Footer>
                                                  </ig:UltraGridColumn>
                                                  <ig:UltraGridColumn BaseColumnName="AMOUNT" Format="###,###,###,###,##0" HeaderText="집행내역"
                                                      Key="AMOUNT" Width="260px">
                                                      <Header Caption="집행내역">
                                                          <RowLayoutColumnInfo OriginX="5" />
                                                      </Header>
                                                      <Footer>
                                                          <RowLayoutColumnInfo OriginX="5" />
                                                      </Footer>
                                                  </ig:UltraGridColumn>
                                                  <ig:UltraGridColumn BaseColumnName="RATE" Format="##0.00" HeaderText="집행율(%)"
                                                      Key="RATE" Width="90px">
                                                      <CellStyle HorizontalAlign="Right">
                                                      </CellStyle>
                                                      <Header Caption="집행율(%)">
                                                          <RowLayoutColumnInfo OriginX="6" />
                                                      </Header>
                                                      <Footer>
                                                          <RowLayoutColumnInfo OriginX="6" />
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
                                                    HeaderClickActionDefault="NotSet" Name="ugrdBudgetList" RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                          <GroupByBox>
                                              <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                          <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
                                              <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                          </HeaderStyleDefault>
                                          <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                          </EditCellStyleDefault>
                                          <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="300px"
                                                        Width="100%">
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
                                          <ClientSideEvents />
                                          <ActivationObject BorderColor="" BorderWidth="">
                                          </ActivationObject>
                                      </DisplayLayout>
                                  </ig:UltraWebGrid>
                                  </td>
                              </tr>
                              <tr>
                              <td colspan="4" style="height:24px;" align="right" valign="middle">
                                  <asp:LinkButton ID="linkBtnDraft" runat="server" OnClick="linkBtnDraft_Click" Visible="false"></asp:LinkButton>
                                  <asp:ImageButton ID="iBtnDraft" runat="server" ImageUrl="../images/draft/draft.gif" Visible="false" />
                                  <asp:ImageButton ID="iBtnReDraft" runat="server" ImageUrl="../images/draft/redraft.gif" Visible="false" />
                                  <asp:ImageButton ID="iBtnMoDraft" runat="server" ImageUrl="../images/draft/modraft.gif" Visible="false" />
                                  <asp:ImageButton ID="iBtnReWrite" ImageUrl="../images/draft/rewrite.gif" runat="server" Visible="false" />
                                  <asp:ImageButton ID="iBtnReqModify" runat="server" ImageUrl="../images/draft/morequest.gif" OnClick="iBtnReqModify_Click" Visible="false" />
                                  <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" OnClick="iBtnUpdate_Click" />
                                  <asp:ImageButton ID="iBtnClose" runat="server" Height="19px" ImageUrl="../images/btn/b_003.gif" OnClick="iBtnClose_Click" />
                              </td>
                             </tr>
                            </table>
         <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>              

    
    <!--- MAIN END --->
    </form>
</body>
</html>
