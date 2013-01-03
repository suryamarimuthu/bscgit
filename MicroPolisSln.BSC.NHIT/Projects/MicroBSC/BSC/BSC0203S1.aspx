<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0203S1.aspx.cs" Inherits="BSC_BSC0203S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">   
    <script type="text/javascript" src="../_common/js/yahoo/scripts.js"></script>
    <script type="text/javascript" src="../_common/js/yahoo/yahoo.js"></script>
    <script type="text/javascript" src="../_common/js/yahoo/dom.js"></script>
    <script type="text/javascript" src="../_common/js/yahoo/event.js"></script>
    <script type="text/javascript" src="../_common/js/yahoo/container.js"></script>

    <script id="Infragistics" type="text/javascript">

    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);
           cell.style.cursor    = 'hand';
        }
    }
    
    function ugrdMapKpi_DblClickHandler(gridName, cellId)
    {
        var cell            = igtbl_getElementById(cellId);
        var row             = igtbl_getRowById(cellId);
        var kpiID           = row.getCellFromKey("KPI_REF_ID").getValue();
        var kpiName         = row.getCellFromKey("KPI_NAME").getValue();
        var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();

        var url             = "BSC0302M1.aspx?iType=S&KPI_REF_ID=" + kpiID + "&ESTTERM_REF_ID=" + estterm_ref_id
        
        gfOpenWindow(url,900, 645,'yes','no');
    }
    
    </script>

<!--- MAIN START --->	
		<table cellpadding="2" cellspacing="0" border="0" style="width:100%; height:100%;">
		    <tr valign="top" style="height: 60px">
                <td colspan="2" style="height: 60px">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tbody>
                        <tr>
                          <td class="tableoutBorder">
                            <table cellspacing="0" cellpadding="2" width="100%" border="0">
                              <tbody>
                                <tr>
                                  <td class="tableTitle" style="width:60px;" align="center">평가기간</td>
                                  <td class="tableContent" style="width:200px;">
                                     <asp:dropdownlist id="ddlEstTermInfo" CssClass="box01" runat="server" width="60%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                                     <asp:dropdownlist id="ddlEstTermMonth" CssClass="box01" runat="server" width="35%" ></asp:dropdownlist>
                                  </td>
                                  <td class="tableTitle" style="width:60px;" align="center">평가조직</td>
                                  <td class="tableContent" style="width:150px;"><asp:dropdownlist id="ddlEstDept" CssClass="box01" runat="server" width="100%"></asp:dropdownlist></td>
                                  <td class="tableTitle"   style="width:60px;" align="center">조회구분</td>
                                  <td class="tableContent" style="width:150px;">
                                    <asp:RadioButtonList ID="rdoSelect" runat="server" RepeatColumns="2">
                                      <asp:ListItem Text="전략기준" Value="S" Selected="true"></asp:ListItem>
                                      <asp:ListItem Text="지표기준" Value="K"></asp:ListItem>
                                    </asp:RadioButtonList>
                                  </td>
                                  <td class="tableContent" align="center">
                                    <asp:ImageButton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" Height="19px" ImageAlign="AbsMiddle"></asp:ImageButton>
                                  </td>
                                  <td class="tableTitle"   style="width:60px;" align="center"></td>
                                </tr>
                              </tbody>
                            </table>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                </td>
        </tr>
        <tr>
            <td valign="top" colspan="2" >
                <ig:ultrawebgrid id="ugrdMoonChart" runat="server" Visible="false" Width="100%" Height="100%" OnInitializeLayout="ugrdMoonChart_InitializeLayout">
                        <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
                            Name="ugrdMoonChart" TableLayout="Fixed" CellClickActionDefault="RowSelect"
                            StationaryMargins="Header" UseFixedHeaders="True" >
                            <AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver" View="Compact">
                                <BoxStyle BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                    </BorderDetails>
                                </BoxStyle>
                                <ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></ButtonStyle>
                            </AddNewBox>
                            <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif" BorderStyle="Solid" HorizontalAlign="Center"
                                ForeColor="White" BackColor="#94BAC9">
                                <Padding Left="0px" Right="0px"></Padding>
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </HeaderStyleDefault>
                            <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
                            <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                            <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                                BorderStyle="Solid" BackColor="#FAFCF1" Height="100%"></FrameStyle>
                            <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </FooterStyleDefault>
                            <ActivationObject BorderColor="170, 184, 131" BorderWidth=""></ActivationObject>
                            <GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
                                <BoxStyle BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
                                </BoxStyle>
                                <BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
                            </GroupByBox>
                            <RowExpAreaStyleDefault BackColor="WhiteSmoke"></RowExpAreaStyleDefault>
                            <EditCellStyleDefault VerticalAlign="Middle" BorderWidth="0px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderStyle="None"
                                HorizontalAlign="Left"></EditCellStyleDefault>
                            <SelectedRowStyleDefault ForeColor="White" BackColor="#BECA98"></SelectedRowStyleDefault>
                            <SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="#CF5F5B"></SelectedGroupByRowStyleDefault>
                            <RowStyleDefault VerticalAlign="Middle" BorderWidth="1px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderColor="#AAB883"
                                BorderStyle="Solid" HorizontalAlign="Left" ForeColor="#333333" BackColor="White">
                                <Padding Left="3px" Right="3px"></Padding>
                                <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                            </RowStyleDefault>
                            <ClientSideEvents />
                            <Images>
                                <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                                <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                                <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                                <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                            </Images>
                        </DisplayLayout>
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                            </ig:UltraGridBand>
                        </Bands>
                    </ig:ultrawebgrid>
        
		    </td>
		</tr>
		<tr>
            <td align="left" style="height: 30px">
                <a href="#null" onclick="openInstWindow()">
                <img alt="" src="../images/btn/b_005.gif" style="visibility:hidden"/></a>&nbsp;
                </td>
			<td align="right">
                <asp:label id="lblCountRow" runat="server" text="Label"></asp:label>
                <asp:imagebutton id="iBtnPrint" runat="server" imageurl="../images/btn/b_080.gif" Visible="false"  onclick="iBtnPrint_Click"></asp:imagebutton>
                &nbsp;<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
			</td>
		</tr>
      </table>
      
<%--출력을 위한 그리드 숨김--%>
       
        <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" >
        </ig:UltraWebGridExcelExporter>
      
	  <asp:Literal ID="ltrScript" runat="server"></asp:Literal>

<!--- MAIN END --->
</asp:Content>
