<%@ Page Language="C#" MasterPageFile="~/_common/libNHIT/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC0705S1.aspx.cs" Inherits="BSC_BSC0705S1" Title="MicroBSC" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contents" Runat="Server">
<script type="text/javascript" >
    function OpenFaqWindow()
    {
        var url = '../BSC/BSC0705M1.aspx?iTYPE=A';

        gfOpenWindow(url, 823, 540, 'yes', 'no', 'BSC0704M1A');
        
        return false;
    }

    function DblClickHandler_Faq(gridName, id) 
    {
        var cell     = igtbl_getElementById(id);
        var row      = igtbl_getRowById(id);
        var listID   = row.getCellFromKey("FAQ_REF_ID").getValue();

        var strURL = '../BSC/BSC0705M1.aspx?iTYPE=U&FAQ_REF_ID=' + listID;
        
        gfOpenWindow(strURL, 823, 540, 'BSC0705M1U');
    }
</script>

<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
<!-- 상단 검색 Start-->
    <tr style="height:23px;">
      <td>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;" class="tableBorder">
            <tr>
                <td class="cssTblTitle" style="width:10%;">FAQ 제목</td>
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
                                    <ig:UltraGridColumn BaseColumnName="FAQ_REF_ID" HeaderText="No" Key="FAQ_REF_ID" Width="80px" FooterText="">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="FAQ 번호">
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="FAQ_QUESTION" Key="FAQ_QUESTION" Width="800px" HeaderText="FAQ 질문">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="FAQ 질문">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
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
                            <ClientSideEvents DblClickHandler="DblClickHandler_Faq" />
                        </DisplayLayout>
                    </ig:UltraWebGrid>                            
                </td>
              </tr>
              <tr>
                <td style="height:20px;" align="right">
                  <asp:ImageButton ID="iBtnWriteNotice" runat="server" ImageUrl="../images/btn/b_127.gif" OnClientClick="return OpenFaqWindow();" />
                </td>
              </tr>
            </table>
            <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
        </td>
    </tr>
<!-- 그리드 End-->  
</table>
</asp:Content>


