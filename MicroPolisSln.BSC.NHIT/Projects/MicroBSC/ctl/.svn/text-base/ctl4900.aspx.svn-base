<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4900.aspx.cs" Inherits="ctl_ctl4900" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript">

function mfOpenWindow(sMode)
{
    var argv = mfOpenWindow.arguments;
    var argc = argv.length;
    var ICCB1 = "<%= this.ICCB1 %>";
    var ICCB2 = "<%= this.ICCB2 %>";

    if (sMode.toUpperCase() == "ADD_C") // 등급코드 등록
    {
        gfOpenWindow("ctl4901.aspx?COUNT=<%=COD_ESEQ_COUNT %>&CCB1="+ICCB1, 437, 253, false, true);
    }
    else if (sMode.toUpperCase() == "ADD_S") // 등급단계 등록
    {
        gfOpenWindow("ctl4904.aspx?ICCB2="+ICCB2 , 340, 190, false, true);
    }
    else if (sMode.toUpperCase() == "UPD_C")// 등급코드 정보 수정
    {
        var sCodeID = (argc >= 2 ? argv[1] : "");        
        
        if (sCodeID != "")
        {
            gfOpenWindow("ctl4902.aspx?CODEID=" + sCodeID+'&CCB1='+ICCB1, 437, 273, false, true);
        }
    }
    else if (sMode.toUpperCase() == "UPD_S")// 등급단계 코드 수정
    {               
        var sCodeID = (argc >= 2 ? argv[1] : ""); 
        var sStepLevel = (argc >=3 ? argv[2] : "");           
        
        if (sCodeID != "")
        {
            gfOpenWindow("ctl4903.aspx?CODEID=" + sCodeID + "&STEPLEVEL=" + sStepLevel +"&CCB1="+ICCB1, 327, 213, false, true);
        }
    }
}
</script>
        
<!--- MAIN START --->
<table style=" width:100%; height:100%; " border="0" cellpadding="0" cellspacing="0">    
    <tr valign="top">
        <!-- 평가코드 관리 START -->
        <td style=" width:60%;">
            <table style=" width:100%;height:100%; " border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td style="width:15px;">
                                    <img src="../images/title/ma_t14.gif" alt="" />
                                </td>
                                <td>
                                    <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="THRESHOLD 코드 관리" />
                                </td>
                            </tr>
                        </table>
                        <%--<img alt="" src="../images/title/threshold_code_title.gif" />--%>
                    </td>
                </tr>
                <tr style="height:100%;">
                    <td>
                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" >
                            <Bands>
                                <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                                    <Columns>
                                        <ig:UltraGridColumn AllowUpdate="Yes"  HeaderText="선택" Key="selChk" Type="CheckBox" Width="40px">
                                            <CellStyle HorizontalAlign="Center" />
                                            <HEADER caption="선택">
                                            </HEADER>
                                        </ig:UltraGridColumn>
                                        <ig:ULTRAGRIDCOLUMN basecolumnname="THRESHOLD_REF_ID" hidden="true" headertext="THRESHOLD_REF_ID" key="THRESHOLD_REF_ID">
                                            <CELLSTYLE verticalalign="Top"></CELLSTYLE>
                                            <HEADER caption="THRESHOLD_REF_ID">
                                                <ROWLAYOUTCOLUMNINFO originx="1" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="1" />
                                            </FOOTER>
                                        </ig:ULTRAGRIDCOLUMN>
                                        <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue=""
                                            HeaderText="수정" Key="MODIFY" Width="40px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="수정" Title="">                                                    
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                            <Footer Caption="" Title="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>                                            
                                        <ig:UltraGridColumn BaseColumnName="THRESHOLD_ENAME" HeaderText="Threshold 명" Key="THRESHOLD_ENAME">
                                            <HEADER caption="Threshold 명">
                                                <ROWLAYOUTCOLUMNINFO originx="2" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="2" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="THRESHOLD_KNAME" HeaderText="Threshold 명" Key="THRESHOLD_KNAME">
                                            <HEADER caption="Threshold 명">
                                                <ROWLAYOUTCOLUMNINFO originx="3" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="3" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="IMAGE_FILE_NAME" HeaderText="이미지파일명" Key="IMAGE_FILE_NAME" Width="100px">
                                            <CellStyle HorizontalAlign="Center" />
                                            <HEADER caption="이미지파일명">
                                                <ROWLAYOUTCOLUMNINFO originx="4" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="4" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="SEQUENCE" HeaderText="순서" Key="SEQUENCE" Width="40px">
                                            <CellStyle HorizontalAlign="Center"/>
                                            <HEADER caption="순서">
                                                <ROWLAYOUTCOLUMNINFO originx="5" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="5" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="USE_YN" HeaderText="사용여부" Key="USE_YN" Width="40px">
                                            <CellStyle HorizontalAlign="Center" />
                                            <HEADER caption="사용">
                                                <ROWLAYOUTCOLUMNINFO originx="5" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="5" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout 
                                            CellPaddingDefault="2" 
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
                                            ViewType="Flat" 
                                            CellClickActionDefault="RowSelect" 
                                            TableLayout="Fixed" 
                                            StationaryMargins="Header" 
                                            AutoGenerateColumns="False"
                                            OptimizeCSSClassNamesOutput="False">
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
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
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
                            </SelectedRowStyleDefault>--%>
                            
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
                    <td>
                        <table style=" width:100%;" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td align="left">
                                    <asp:ImageButton valign="absmiddle" ID="iBtnCodeSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" onclick="iBtnCodeSearch_Click" />
                                </td>                                    
                                <td align="right">           
                                    <ASP:LINKBUTTON id="lBtnReload" runat="server" onclick="lBtnReload_Click"></ASP:LINKBUTTON>
                                    <ASP:IMAGEBUTTON id="iBtnCodeDel" runat="server" imageurl="../images/btn/b_004.gif" onclick="iBtnCodeDel_Click"></ASP:IMAGEBUTTON>
                                    &nbsp;&nbsp;
                                    <ASP:IMAGEBUTTON id="iBtnCodeAdd" runat="server" imageurl="../images/btn/b_156.gif" onclick="iBtnCodeAdd_Click"></ASP:IMAGEBUTTON>
                                </td>             
                            </tr>
                        </table>                        
                    </td>       
                </tr>
            </table>
        </td>
        <!-- 평가코드 관리 END -->
        <td style=" width:35px;">
            <table  style=" width:100%;height:100%; " border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle" align = "center" style="text-align:center">
                        <asp:ImageButton valign="absmiddle" ID="iBtnCodeToStep" runat="server" Height="19" ImageUrl="~/images/btn/btn_add_01.gif" onclick="iBtnCodeToStep_Click" />
                        <br />
                        <br />
                        <ASP:LINKBUTTON id="lbLevelReload" runat="server" onclick="lbLevelReload_Click"></ASP:LINKBUTTON>
                        <asp:ImageButton valign="absmiddle" ID="iBtnStepToCode" runat="server" Height="19" ImageUrl="~/images/btn/btn_add_02.gif" onclick="iBtnStepToCode_Click" />
                    </td>
                </tr>
            </table>
        </td>
        <!-- 평가등급별 코드관리 START -->
        <td>
            <table style=" width:100%;height:100%; " border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td style="width:15px;">
                                    <img src="../images/title/ma_t14.gif" alt="" />
                                </td>
                                <td>
                                    <asp:Label id="Label1" runat="server" style="font-weight:bold" text="THRESHOLD 등급별 코드 관리" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height:100%;">
                    <td>                            
                        <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Width="100%" height="100%" OnInitializeRow="UltraWebGrid2_InitializeRow">
                            <Bands>
                                <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                                    <Columns>
                                        <ig:UltraGridColumn AllowUpdate="Yes"  HeaderText="선택" Key="selChk" Type="CheckBox" Width="35px">
                                            <CellStyle HorizontalAlign="Center" />
                                            <HEADER caption="선택">
                                            </HEADER>
                                        </ig:UltraGridColumn>
                                        <ig:ULTRAGRIDCOLUMN basecolumnname="THRESHOLD_REF_ID" hidden="true" headertext="THRESHOLD_REF_ID" key="THRESHOLD_REF_ID">
                                            <CELLSTYLE verticalalign="Top"></CELLSTYLE>
                                            <HEADER caption="THRESHOLD_REF_ID">
                                                <ROWLAYOUTCOLUMNINFO originx="1" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="1" />
                                            </FOOTER>
                                        </ig:ULTRAGRIDCOLUMN>
                                        <ig:ULTRAGRIDCOLUMN basecolumnname="THRESHOLD_LEVEL" hidden="true" headertext="THRESHOLD_LEVEL" key="THRESHOLD_LEVEL">
                                            <CELLSTYLE verticalalign="Top"></CELLSTYLE>
                                            <HEADER caption="THRESHOLD_LEVEL">
                                                <ROWLAYOUTCOLUMNINFO originx="2" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="2" />
                                            </FOOTER>
                                        </ig:ULTRAGRIDCOLUMN>
                                        <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue=""
                                            HeaderText="수정" Key="MODIFY" Width="40px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="수정" Title="">                                                    
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                            <Footer Caption="" Title="">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>                                            
                                        <ig:UltraGridColumn BaseColumnName="THRESHOLD_ENAME" HeaderText="Threshold 명" Key="THRESHOLD_ENAME" Width="90px">
                                            <HEADER caption="Threshold 명">
                                                <ROWLAYOUTCOLUMNINFO originx="4" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="4" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POINT" Type="NotSet" HeaderText="POINT" Key="POINT" Width="35px" Format="#,##0">
                                            <HEADER caption="점수">
                                                <ROWLAYOUTCOLUMNINFO originx="5" />
                                            </HEADER>
                                            <CellStyle HorizontalAlign="right"></CellStyle>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="5" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="BASE_LINE_YN" HeaderText="BASE_LINE_YN" Key="BASE_LINE_YN" Width="40px">
                                            <HEADER caption="기준선여부">
                                                <ROWLAYOUTCOLUMNINFO originx="4" />
                                            </HEADER>
                                            <HeaderStyle Wrap="true" />
                                            <CellStyle HorizontalAlign="center"></CellStyle>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="4" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="SEQUENCE" HeaderText="순서" Key="SEQUENCE" Width="40px">
                                            <CellStyle HorizontalAlign="Center"/>
                                            <HEADER caption="순서">
                                                <ROWLAYOUTCOLUMNINFO originx="6" />
                                            </HEADER>
                                            <FOOTER>
                                                <ROWLAYOUTCOLUMNINFO originx="6" />
                                            </FOOTER>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout 
                                            CellPaddingDefault="2" 
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
                                            ViewType="Flat" 
                                            CellClickActionDefault="RowSelect" 
                                            TableLayout="Fixed" 
                                            StationaryMargins="Header" 
                                            AutoGenerateColumns="False"
                                            OptimizeCSSClassNamesOutput="False">
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
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
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
                            </SelectedRowStyleDefault>       --%>     
                            
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
                    <td>    
                        <table style=" width:100%;height:100%; " border="0" cellpadding="0" cellspacing="0">
                           <tr>
                                <td style=" width:100px">
                                    <asp:DropDownList id="ddlLevel" style=" valign:abstop;" width="100%" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:ImageButton valign="absmiddle" ID="iBtnStepSearch" runat="server" ImageUrl="~/images/btn/b_033.gif" onclick="iBtnStepSearch_Click" />
                                </td>
                                <td align="right">                                        
                                    <ASP:IMAGEBUTTON id="iBtnStepAdd" runat="server" imageurl="../images/btn/b_156.gif" onclick="iBtnStepAdd_Click"></ASP:IMAGEBUTTON>
                                </td>
                            </tr>
                        </table>
                    </td>                    
                </tr>
            </table>
        </td>
        <!-- 평가등급별 코드관리 START -->
    </tr>    
</table>
<asp:HiddenField ID="hdViewType" runat="server" />
<!--- MAIN END --->
</asp:Content>
