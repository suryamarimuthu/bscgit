<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4302.aspx.cs" Inherits="ctl_ctl4302" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">

  function CheckCtrl(cbox_0, cbox_1, cbox_2) 
{
    var cBox0       = document.getElementById(cbox_0);
    var cBox1       = document.getElementById(cbox_1);
 

         var myGrid = igtbl_getGridById(cbox_0);
         
         var radName = 'ctl00$Contents$ugrdGradeList$ci_0_7_';
         var radName2 ='$radMidGrade_YN';

         for (i = 0; i < myGrid.Rows.length; i++)
         {
             var rad = radName + i + radName2;
             var cBox9       = document.getElementById(rad);  
             if(i == cbox_2)
            { 
                 cBox9.checked = true; 
             }
            else 
            {
                 cBox9.checked = false; 
            } 
         }
         
//         
//         var _elements   = document.forms[0].elements;

//        for (var i = 0; i < _elements.length; i++)
//        {
//            if (_elements[i].id.indexOf(cbox_0) >= 0 && _elements[i].type=="checkbox")
//            {
//            
//                    _elements[i].checked = true;
//               
//            }
//        }
//        
//        param1 = true;
}
    
    
    function selectChkBox(objMe, chkChild)
    {
        var _elements  = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
            {
                if (objMe.id == _elements[i].id)
                {
                    _elements[i].checked = true;
                }
                else
                {
                    _elements[i].checked = false;
                }
            }
        }
    }
    
</script>
       <!--- MAIN START --->
        
      <table cellpadding="0" cellspacing="2" border="0"  style="width:100%; height:100%;" >
	    <tr>
            <td>
                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0" style="height:100%;">
                    <tbody>
                        <tr>
                            <td class="cssTblTitle">
                                평가기간
                            </td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlEstTermInfo" CssClass="box01" runat="server" Width="100%"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td class="cssTblContent">
                                조직유형
                            </td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlDeptType" CssClass="box01" runat="server" AutoPostBack="True" Width="100%"
                                    OnSelectedIndexChanged="ddlDeptType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right">
                <asp:ImageButton ID="iBtnSearch" OnClick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;
            </td>
        </tr>
        <tr style="height:100%;">
            <td valign="top" style="height: 100%">
                <ig:UltraWebGrid ID="ugrdGradeList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdGradeList_InitializeRow" OnInitializeLayout="ugrdGradeList_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="입력구분" Hidden="True" Key="ITYPE"
                                    Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="입력구분">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="ESTTERM_REF_ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_TYPE" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="EST_DEPT_TYPE" Hidden="True" Key="EST_DEPT_TYPE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="EST_DEPT_TYPE">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TYPE_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="부서유형" Key="TYPE_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="부서유형">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left" BackColor="WhiteSmoke">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="GRADE_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="등급코드" Hidden="True" Key="GRADE_REF_ID" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="등급코드">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="GRADE_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="등급명" Key="GRADE_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="등급명">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MIN_VALUE" DataType="System.Double" HeaderText="최소등급값"
                                    Key="MIN_VALUE" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="최소등급값">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MAX_VALUE" DataType="System.Double" HeaderText="최대등급값"
                                    Key="MAX_VALUE" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="최대등급값">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SORT_ORDER" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="순서" Key="SORT_ORDER" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="순서">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="MID_GRADE_YN" EditorControlID="" FooterText=""
                                    HeaderText="중간등급여부" Key="MID_GRADE_YN" Width="120px">
                                    <CellTemplate>
                                    <asp:CheckBox ID="chkMidGrade_YN" runat="server" Width="100%" />
                                    </CellTemplate>
                                      <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <Header Caption="중간등급여부">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="USE_YN" EditorControlID="" FooterText="" HeaderText="사용여부"
                                    Key="USE_YN" Width="60px">
                                    <HeaderStyle Wrap="True" />
                                    <CellTemplate>
                                    <asp:DropDownList ID="ddlUse_YN" runat="server" Width="100%" CssClass="box01" ></asp:DropDownList>
                                    </CellTemplate>
                                    <Header Caption="사용여부">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:TemplatedColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                       <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="NotSet" Name="ugrdGradeList" RowHeightDefault="20px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                            <%--<GroupByBox>
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
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                            </ActivationObject>--%>
                            
                            <RowStyleDefault  CssClass="GridRowStyle" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                        </DisplayLayout>
                </ig:UltraWebGrid>
                           
                            </td>
		</tr>
		<tr class="cssPopBtnLine">
            <td valign ="top" align="right">
                <asp:ImageButton ID="ImgBtnAddRow" runat="server" ImageUrl="../images/btn/b_005.gif" OnClick="ImgBtnAddRow_Click" />
                <asp:ImageButton ID="iBtnUpdate" runat="server" ImageUrl="../images/btn/b_002.gif" OnClick="iBtnUpdate_Click" />
            </td>
        </tr>
	  </table> 
       
       <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
       <!--- MAIN END --->
</asp:Content>