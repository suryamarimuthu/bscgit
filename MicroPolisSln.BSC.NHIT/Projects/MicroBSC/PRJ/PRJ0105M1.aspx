<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0105M1.aspx.cs" Inherits="PRJ_PRJ0105M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
<script type="text/javascript" language="jscript">

    function MouseOverHandler(gridName, id, objectType)
    {
    
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell = igtbl_getCellById(id);
           
           if(cell.Key == "TASK_NAME")
           {
               cell.style.cursor = 'hand';
           }
           else
           {
               cell.style.cursor = 'default';
           }
        }
    }
    
    function DblClickHandler(gridName, id) 
    {
    
      var row      = igtbl_getRowById(id);
      var cell     = igtbl_getColumnById(id);
      
      if(cell != null && cell.Key == "TASK_NAME")
      {
              
            var ICCB2           = "<%= this.ICCB2 %>";
            var PRJ_REF_ID      = "<%= this.IPrjRefID %>";
            
            var objKey      = "<%= this.hdfTaskRefID.ClientID %>";
            var objVal      = "<%= this.hdfTaskName.ClientID %>";
            
            var objKey = document.getElementById(objKey);
            var objVal = document.getElementById(objVal);
            strKeyObj = objKey.name;
            strValObj = objVal.name;
            

            var url             = "PRJ0104S1.aspx?CTRL_VALUE_NAME="+ strKeyObj + "&CTRL_TEXT_NAME=" + strValObj + "&PRJ_REF_ID=" + PRJ_REF_ID + "&AFTER_TASK_YN=Y&CCB2="+ICCB2;
            
            
            gfOpenWindow(url, 500, 430, 'yes', 'no', 'PRJ0104S1');
      }

    }
    
</script>
<!--- MAIN START --->
   
		<table cellpadding="0" cellspacing="0" border="0"  style="width:100%; height:100%;" >
        <tr>
            <td align="left" valign="top" height="100%">
            
            <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height:100%">
                              <tbody>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" class="tableBorder">
                                            <tr>
                                              <td class="cssTblTitle">사업유형&nbsp;</td>
                                              <td class="cssTblContent">
                                                <asp:dropdownlist id="ddlPrjType" class="box01" runat="server" width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlPrjType_SelectedIndexChanged"></asp:dropdownlist>
                                              </td>
                                              <td class="cssTblTitle">사업년도&nbsp;</td>
                                              <td class="cssTblContent">
                                                    <ig:webmaskedit id="txtYear" runat="server" InputMask="####" RealText="&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;" AutoPostBack="true"
                                                           HorizontalAlign="Center" Width="100%" ToolTip="YYYY" Font-Names="Verdana" Font-Size="9pt" DataMode="RawText"></ig:webmaskedit>
                                              </td>
                                            </tr>
                                            <tr>
                                              <td class="cssTblTitle">사업명</td>
                                              <td class="cssTblContent" style="border-right:none;">
                                                <asp:DropDownList id="ddlPrjName" class="box01" runat="server" width="100%" />
                                              </td>
                                              <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                              <td class="cssTblContent">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td align="left">
                                                    <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                                                    <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                                    <img align="absmiddle" src="../Images/etc/lis_t02.gif" />
                                                </td>
                                                <td align="right">
                                                    <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                  <td align="left" style="width : 100%;" valign="top" height="100%">
                                      <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Width="100%" Height="400px"  >
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:TemplatedColumn Key="selchk" Width="30px">
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
                                                            <ig:UltraGridColumn BaseColumnName="ITYPE" Hidden="True" Key="ITYPE">
                                                                <Header>
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_REF_ID" HeaderText="예산집행일련번호" Hidden="True"
                                                                Key="EXEC_REF_ID">
                                                                <Header Caption="예산집행일련번호">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID"
                                                                Width="40px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Header Caption="PRJ_REF_ID">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="PRJ_CODE" FooterText="" HeaderText="코드" Key="PRJ_CODE"
                                                                Width="50px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Header Caption="코드">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="PRJ_NAME" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="사업명" Key="PRJ_NAME" Width="220px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ValueList DisplayStyle="NotSet">
                                                                </ValueList>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Header Caption="사업명">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Header>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="OWNER_EMP_ID" HeaderText="책임자사번" Hidden="True"
                                                                Key="OWNER_EMP_ID">
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Header Caption="책임자사번">
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="OWNER_EMP_NAME" HeaderText="책임자" Key="OWNER_EMP_NAME"
                                                                Width="70px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Header Caption="책임자">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TASK_REF_ID" HeaderText="작업ID" Hidden="True"
                                                                Key="TASK_REF_ID">
                                                                <Header Caption="작업ID">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TASK_NAME" HeaderText="작업명" Key="TASK_NAME"
                                                                Width="100px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Header Caption="작업명">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="EXEC_DATE" EditorControlID="WebDateChooser1"
                                                                Format="MM/dd/yyyy" HeaderText="집행년월일" Key="EXEC_DATE" Type="Custom" Width="90px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Header Caption="집행년월일">
                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="AMOUNT" Format="###,###,##0"
                                                                HeaderText="집행금액" Key="AMOUNT" Width="100px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                                <SelectedCellStyle HorizontalAlign="Right">
                                                                </SelectedCellStyle>
                                                                <Header Caption="집행금액">
                                                                    <RowLayoutColumnInfo OriginX="11" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="11" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn AllowUpdate="Yes" BaseColumnName="EXEC_CONTENT" Format=""
                                                                HeaderText="집행내역" Key="EXEC_CONTENT" Width="130px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="집행내역">
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="12" />
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
                                                                AllowDeleteDefault="Yes"
                                                                BorderCollapseDefault="Separate"
                                                                HeaderClickActionDefault="NotSet"
                                                                Name="ugrdPrjList"
                                                                RowHeightDefault="20px"
                                                                RowSelectorsDefault="No"
                                                                SelectTypeRowDefault="Single"
                                                                Version="4.00" TableLayout="Fixed"
                                                                StationaryMargins="Header"
                                                                AutoGenerateColumns="False"
                                                                CellClickActionDefault="RowSelect"
                                                                OptimizeCSSClassNamesOutput="False">
                                                    <%--
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
                                                        BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="400px"
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
                                                    
                                                    <GroupByBox>
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                    </GroupByBox>
                                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                    <ClientSideEvents DblClickHandler="DblClickHandler"/>
                                                </DisplayLayout>
                                              </ig:UltraWebGrid> 
                                      
                                      
                                      </td>
                                
                                </tr>
                                <tr>
                                
			                    <td align="right"><asp:ImageButton
                                       ID="iBtnAddRow" runat="server" ImageUrl="../images/btn/b_005.gif" OnClick="iBtnAddRow_Click" />&nbsp;<asp:ImageButton
                                       ID="iBtnDelRow" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="iBtnDelRow_Click" />
                                    <asp:ImageButton ID="iBtnUpdate" runat="server" ImageUrl="../images/btn/b_tp07.gif"
                                        OnClick="iBtnUpdate_Click" />
                                    <asp:ImageButton ID="ibnDownExcel" runat="server" CommandName="BIZ_DOWN_EXCEL" ImageUrl="~/images/btn/b_041.gif"
                                        OnClick="ibnDownExcel_Click" />&nbsp;
			                    </td>
		                    </tr>
                              </tbody>
                            </table>
                <ig:WebDateChooser ID="WebDateChooser1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="150px" Text="Null" Width="200px" NullDateLabel="">
                    <DropDownStyle Font-Names="Verdana" Font-Size="8pt">
                    </DropDownStyle>
                    <DropButton ImageUrl1="../images/icon/igsch_dropdown_up_o2003silver.gif">
                    </DropButton>
                    <CalendarLayout DayNameFormat="FirstLetter" FooterFormat="" ShowFooter="False" ShowNextPrevMonth="False"
                        ShowTitle="False">
                        <CalendarStyle Font-Names="Verdana" Font-Size="8pt">
                        </CalendarStyle>
                        <DayHeaderStyle BackColor="White" ForeColor="#A2A1A1" />
                        <DayStyle BackColor="White" Font-Names="Arial" Font-Size="9pt" />
                        <OtherMonthDayStyle ForeColor="White" />
                        <SelectedDayStyle BackColor="Silver" ForeColor="Black" />
                        <TitleStyle BackColor="White" />
                    </CalendarLayout>
                    <EditStyle Font-Names="Verdana" Font-Size="8pt">
                    </EditStyle>
                </ig:WebDateChooser>
                <asp:HiddenField ID="hdfTaskRefID" runat="server"  />
                <asp:HiddenField ID="hdfTaskName" runat="server" />
                <asp:LinkButton ID="lBtnBindRow" runat="server" OnClick="lBtnBindRow_Click"></asp:LinkButton>
                <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server">
                </ig:UltraWebGridExcelExporter>
            </td>
        </tr>
    </table>
    
    
<!--- MAIN END --->
<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>  
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>