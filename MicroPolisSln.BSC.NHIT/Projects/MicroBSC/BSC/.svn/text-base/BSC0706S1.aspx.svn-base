<%@ Page Language="C#" MasterPageFile="~/_common/libNHIT/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC0706S1.aspx.cs" Inherits="BSC_BSC0706S1" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contents" Runat="Server">
<script type="text/javascript" >
    function OpenNoticeWindow()
    {
        var Estterm_ref_id = '<%=this.IEstTermRefID %>';
        var Ymd            = '';
        var ICCB1          = "<%= this.ICCB1 %>";
        var url            = '../BSC/BSC0704M1.aspx?iTYPE=A&ESTTERM_REF_ID='+ Estterm_ref_id +'&YMD='+Ymd+'&CCB1='+ICCB1;

        gfOpenWindow(url, 823, 540, 'yes', 'no', 'BSC0704M1A');
        
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

    function DblClickHandler_Notice(gridName, id) 
    {
        var cell     = igtbl_getElementById(id);
        var row      = igtbl_getRowById(id);
        var listID   = row.getCellFromKey("NOTICE_REF_ID").getValue();
        var termID   = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var Ymd      = row.getCellFromKey("YMD").getValue();
        var ICCB1    = "<%= this.ICCB1 %>";
        
        var strURL   = '../BSC/BSC0704M1.aspx?iTYPE=U&NOTICE_REF_ID='+listID+'&ESTTERM_REF_ID='+ termID +'&YMD='+Ymd+'&CCB1='+ICCB1;
        
        gfOpenWindow(strURL, 823, 540, 'BSC0704M1U');
    }
</script>

<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
<!-- 상단 검색 Start-->
    <tr style="height:23px;">
      <td>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;" class="tableBorder">
            <tr>
                <td class="cssTblTitle" style="width:5%;">제목</td>
                <td class="cssTblContent">
                    <asp:TextBox runat="server" ID="txtSearchText" Width="100%" CssClass="box01"></asp:TextBox>
                </td>
            </tr>
        </table>
      </td>
    </tr>
    <tr style="height:25px;">
        <td align="right">
            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle" />
        </td>
    </tr>
<!-- 상단 검색 End--> 
<!-- 그리드 Start-->
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%">
              <tr>
                <td>
                     <ig:UltraWebGrid ID="ugrdNotice" runat="server" Width="100%" Height="99%" OnInitializeRow="ugrdNotice_InitializeRow" >
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <Columns>
                                    <ig:UltraGridColumn BaseColumnName="NOTICE_REF_ID" HeaderText="No" Key="NOTICE_REF_ID" Width="60px" FooterText="">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="공지번호">
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="345px" HeaderText="제목">
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
                                    <ig:TemplatedColumn BaseColumnName="OWNER_NAME" Key="OWNER_NAME" Width="60px" FooterText="" HeaderText="작성자">
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
                                    <ig:TemplatedColumn BaseColumnName="NOTICE_FROM" Key="NOTICE_FROM" Width="100px" FooterText="" HeaderText="NOTICE_FROM">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="공지시작일">
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
                                    <ig:TemplatedColumn BaseColumnName="NOTICE_TO" Key="NOTICE_TO" Width="100px" FooterText="" HeaderText="NOTICE_TO">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="공지종료일">
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
                                </Columns>
                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                </RowTemplateStyle>
                            </ig:UltraGridBand>
                        </Bands>
                        <DisplayLayout  CellPaddingDefault="2"
                                        AllowColSizingDefault="Free"
                                        AllowColumnMovingDefault="OnServer"
                                        AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes"
                                        BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="SortMulti"
                                        Name="ugrdCommunicationOrg"
                                        RowHeightDefault="20px"
                                        RowSelectorsDefault="No"
                                        SelectTypeRowDefault="Extended"
                                        Version="4.00"
                                        CellClickActionDefault="RowSelect"
                                        TableLayout="Fixed"
                                        StationaryMargins="Header"
                                        AutoGenerateColumns="False">
                            
                            <GroupByBox>
                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                            <RowStyleDefault  CssClass="GridRowStyle" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                            <ClientSideEvents DblClickHandler="DblClickHandler_Notice" />
                        </DisplayLayout>
                    </ig:UltraWebGrid>                            
                </td>
              </tr>
              <tr>
                <td style="height:20px;" align="right">
                  <asp:ImageButton ID="iBtnWriteNotice" runat="server" ImageUrl="../images/btn/b_127.gif" OnClientClick="return OpenNoticeWindow();" />
                </td>
              </tr>
            </table>
            <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>

        </td>
    </tr>
<!-- 그리드 End-->  
</table>
</asp:Content>


