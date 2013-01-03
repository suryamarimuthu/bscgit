<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0804M1.aspx.cs" Inherits="BSC_BSC0804M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script id="Infragistics" type="text/javascript">

    var param1 = false;
    function selectChkBox(chkChild)
    {
        var _elements   = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
            {
                if (param1)
                {
                    _elements[i].checked = false;
                }
                else
                {
                    _elements[i].checked = true;
                }
            }
        }
        
        param1 = (param1==true) ? false : true;
    }
</script>

  <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
    <tr>
      <td class="tableoutBorder" style="height:20px;"> 
           <table border="0" cellpadding="2" cellspacing="0" style="width:100%; height:100%;">
             <tr>
               <td align="center" style="width:10%; height:20px;" class="tableTitle">측정주기</td>
               <td align="left" style="width:28%; height:20px;"  class="tableContent">
                  <asp:DropDownList ID="ddlEstTermInfo" runat="server" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" CssClass="box01"></asp:DropDownList>
                  <asp:DropDownList ID="ddlMonthInfo"  runat="server"  Width="36%" AutoPostBack="false" CssClass="box01"></asp:DropDownList>                   
               </td>
               <td class="tableTitle" style="width:10%;" align="center">조직유형</td>
               <td class="tableContent" style="width:12%;">
                  <asp:DropDownList ID="ddlComTypeInfo" width="100%" Enabled="true" runat="server" CssClass="box01"></asp:DropDownList>
               </td>
               <td style="width:42%; vertical-align:middle" align="right" class="tableContent">
                 <asp:CheckBox ID="chkApplyFirstRow" runat="server" Text="첫번째행의 가중치 일괄적용" AutoPostBack="True" OnCheckedChanged="chkApplyFirstRow_CheckedChanged" />
                 <asp:ImageButton ID="iBtnSelect" runat="server" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSelect_Click" />
                 <asp:ImageButton ID="iBtnSave"   runat="server" ImageUrl="../images/btn/b_001.gif" OnClick="iBtnSave_Click" />
               </td>
             </tr>
            </table>
      </td>
    </tr>
    <tr>
      <td>
        <ig:UltraWebGrid ID="ugrdExtScore" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdExtScore_InitializeRow" >
            <Bands>
                <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <Columns>
                        <ig:TemplatedColumn Key="selchk" Width="30px">
                            <HeaderTemplate>
                                <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdExtScore')" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <CellTemplate>
                                <asp:checkbox id="cBox" runat="server" Checked="true" />
                            </CellTemplate>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                            FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
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
                        <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                            Format="" HeaderText="YMD" Key="YMD" Width="40px" Hidden="True">
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <Header Caption="YMD">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" DataType="System.Int32" EditorControlID=""
                            FooterText="" Format="" HeaderText="EST_DEPT_REF_ID" Hidden="True" Key="EST_DEPT_REF_ID">
                            <Header Caption="EST_DEPT_REF_ID">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                            Format="" HeaderText="평가부서명" Key="DEPT_NAME" NullText=" " Width="370px" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="평가부서명">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="TYPE_NAME" EditorControlID="" FooterText=""
                            Format="" HeaderText="조직유형" Key="TYPE_NAME" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="조직유형">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="WEIGHT_INR" DataType="System.Double" HeaderText="내부평가가중치" Key="WEIGHT_INR" Width="100px" Format="#,##0.00##" NullText="0.00">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="내부평가가중치">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <CellStyle HorizontalAlign="Right">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="WEIGHT_EXT" DataType="System.Double" HeaderText="외부평가가중치" Key="WEIGHT_EXT" Width="100px" Format="#,##0.00##" NullText="0.00">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="외부평가가중치">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <CellStyle HorizontalAlign="Right">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POINTS_EXT" DataType="System.Double" HeaderText="외부평가점수" Key="POINTS_EXT" Width="100px" Format="#,##0.00##" NullText="0.00">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="외부평가점수">
                                <RowLayoutColumnInfo OriginX="8" />
                            </Header>
                            <CellStyle HorizontalAlign="Right">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="8" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_LEVEL" DataType="System.Int32" HeaderText="조직레벨"
                            Hidden="True" Key="DEPT_LEVEL" Width="100px" NullText="0">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="조직레벨">
                                <RowLayoutColumnInfo OriginX="9" />
                            </Header>
                            <CellStyle HorizontalAlign="Right">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                    </RowTemplateStyle>
                </ig:UltraGridBand>
            </Bands>
             <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="NotSet" Name="ugrdExtScore" RowHeightDefault="22px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="Edit" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False" AllowUpdateDefault="Yes">
                    <GroupByBox>
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                    
                 <ActivationObject BorderColor="" BorderWidth="">
                 </ActivationObject>
                </DisplayLayout>
        </ig:UltraWebGrid>
      </td>
    </tr>
  </table>
  <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
</asp:Content>