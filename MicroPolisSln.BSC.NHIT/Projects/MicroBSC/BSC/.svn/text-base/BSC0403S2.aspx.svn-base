<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0403S2.aspx.cs" Inherits="BSC_BSC0403S2"
    MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script>

        $(function() {

            // ^ main으로 시작하는 클래스    * 포함하는 클래스
            $('[class*=cssMScore]').click(function() {

                $('[class*=cssMScore]').css('background-color', 'white');

                var cssName = this.className;
                var temp = cssName.split('_');
                //alert($('[class*=cssMScore]').find('td'));

                $('[class*=' + temp[5] + ']').css('background-color', '#c0d9e8');

            });

        });
    
    </script>

    <script id="Infragistics" type="text/javascript">


        function UltraWebGrid_CellClickHandler(gridName, cellId, button) {

            //alert(document.getElementById('divLoadingIMG').style.display);
            document.getElementById('divLoadingIMG').style.display = "";

            //alert(document.getElementById('divLoadingIMG').style.display);

            var cell = igtbl_getCellById(cellId);
            var elem = cell.Element;
            var oGrid = igtbl_getGridById(gridName);
            var oBands = oGrid.Bands;
            var oBand = oBands[0];
            var oColumns = oBand.Columns;
            var count = oColumns.length;
            var oRows = oGrid.Rows;
            var oRowsval = oGrid.Rows;
            var total = oRows.length;

            var idxDeptId = 0;
            var idxDeptNm = 0;
            var idxDeptPo = 0;

            //        if(cell.getValue()!="-")
            //        {
            //            for(i=0; i<total; i++) 
            //            {
            //                oRow = oRows.getRow(i);
            //                
            //                for(j=0;j<count;j++)
            //                {
            ////                    idxDeptId = j*6+1;
            ////                    idxDeptNm = j*6+3;
            ////                    idxDeptPo = j*6+4;
            //                    idxDeptId = j * 3 + 0;
            //                    idxDeptNm = j * 3 + 1;
            //                    idxDeptPo = j * 3 + 2;


            //                    
            //                    oCell = oRow.getCell(idxDeptNm);
            //                    
            //                    if(oCell !=null)
            //                    {
            //                        if(cell.getValue() ==oCell.getValue())
            //                        {
            //                            if(ig_csom.IsIE) oCell.Element.runtimeStyle.backgroundColor = "#e0d9f8";
            //                                oCell.Element.style.backgroundColor = "#e0d9f8";
            //                                oRow.getCell(idxDeptPo).Element.style.backgroundColor = "#e0d9f8";
            //                                oRow.getCell(idxDeptId).Element.style.backgroundColor = "#e0d9f8";
            //                        }else
            //                        {
            //                            if(ig_csom.IsIE) oCell.Element.runtimeStyle.backgroundColor = "white";
            //                                oCell.Element.style.backgroundColor = "white";
            //                                oRow.getCell(idxDeptPo).Element.style.backgroundColor = "white";
            //                                oRow.getCell(idxDeptId).Element.style.backgroundColor = "white";
            //                        }
            //                    }
            //                }
            //            }
            //        }

            document.getElementById('divLoadingIMG').style.display = "none";
        }

        function ShowScoreTrace(estterm_ref_id, month, sumType, est_dept_ref_id, dept_type_id) {
            var url = 'BSC0403S1.aspx?ITYPE=POP'
                                 + '&ESTTERM_REF_ID=' + estterm_ref_id
                                 + '&YMD=' + month
                                 + '&SUM_TYPE=' + sumType
                                 + '&EST_DEPT_REF_ID=' + est_dept_ref_id
                                 + '&DEPT_TYPE_ID=' + dept_type_id;

            gfOpenWindow(url, 850, 660, 'no', 'no');
        }

        function OpenEstDept() {
            var EsttermRefID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo).ToString() %>"
            var intEstDeptID = "<%= this.ICCB1 %>"
            var strEstDeptNM = "<%= this.ICCB2 %>"
            var strLinkBtnNm = "<%= this.ICCB3 %>";

            var strURL = "../BSC/BSC0406S2.aspx?ESTTERM_REF_ID=" + EsttermRefID + "&CCB1=" + intEstDeptID + "&CCB2=" + strEstDeptNM + "&CCB3=" + strLinkBtnNm;

            gfOpenWindow(strURL, 350, 500, 0, 0, 'BSC0406S2');
        }


        function itemCntDropDownList() {
            var ddlControl = document.getElementById("<%=this.ddlComTypeInfo.ClientID %>");
            var dept_type_flag = document.getElementById("<%=this.hdfDept_Type_Flag.ClientID %>");

            if (dept_type_flag.value == "") {
                alert("조직 유형을 불러오는 중입니다.");
                return false;
            }

            if (dept_type_flag.value == "0") {
                alert("하위 조직이 있는 조직을 선택 후 조회하세요.");
                return false;
            }

            return true;
        }

        function PopupSetValue(strTreeID, strTreeNm) {
            document.getElementById("<%=hdfDeptID.ClientID%>").value = strTreeID;
            document.getElementById("<%=txtDeptName.ClientID%>").value = strTreeNm;
        }
    </script>

    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
        <tr>
            <td style="height: 30px; width: 100%;">
                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0"
                    style="height: 100%;">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlEstTermInfo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"
                                CssClass="box01" Width="100%">
                            </asp:DropDownList>
                        </td>
                        <td class="cssTblTitle">
                            조직
                        </td>
                        <td class="cssTblContent">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hdfDeptID" runat="server" Value="0"></asp:HiddenField>
                                        <asp:TextBox ID="txtDeptName" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                    <td style="width: 63px;">
                                        <img alt="" src='../images/btn/b_094.gif' style="cursor: hand;" onclick="OpenEstDept();"
                                            align="absMiddle" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            조회구분
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlSumType" Enabled="true" runat="server" CssClass="box01"
                                Width="100%">
                            </asp:DropDownList>
                        </td>
                        <td class="cssTblTitle">
                            조직유형
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlComTypeInfo" Enabled="true" runat="server" Width="100%"
                                CssClass="box01">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" />
                            <asp:HiddenField ID="hdfDept_Type_Flag" runat="server" Value="" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 25px;">
            <td align="right">
                <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif"
                    OnClick="iBtnSearch_Click" OnClientClick="return itemCntDropDownList()" />
            </td>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="middle" align="center">
                <asp:Image ID="imgNoData" ImageUrl="../images/bg/bg_nodata.gif" runat="server" Visible="false" />
                <!--div class=resizeMe id=outerRasiedDiv-->
                <ig:UltraWebGrid ID="ugrdMScore" runat="server" Height="135px" Width="100%" OnInitializeLayout="ugrdMScore_InitializeLayout"
                    OnInitializeRow="ugrdMScore_InitializeRow">
                    <Bands>
                        <ig:UltraGridBand AddButtonCaption="Column0Column1Column2" Key="Column0Column1Column2">
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                        BorderCollapseDefault="Separate" HeaderClickActionDefault="NotSet" Name="ugrdMScore"
                        RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                        Version="4.00" TableLayout="Fixed" StationaryMargins="Header" NoDataMessage=" "
                        ReadOnly="LevelTwo" OptimizeCSSClassNamesOutput="False">
                        <%--<GroupByBox>
                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px" Height="20px">
                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#C7C7C7" ForeColor="White" Height="20px">
                                <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
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
                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                        </HeaderStyleDefault>
                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                        <RowStyleDefault CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                        </SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                        </RowAlternateStyleDefault>
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                        </FrameStyle>
                        <ClientSideEvents CellClickHandler="UltraWebGrid_CellClickHandler" />
                    </DisplayLayout>
                </ig:UltraWebGrid>
                <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport"
                    OnEndExport="ugrdEEP_EndExport" OnCellExported="ugrdEEP_CellExported">
                </ig:UltraWebGridExcelExporter>
                <ig:UltraWebGrid ID="ugrdMScore2" runat="server" Height="135px" Width="100%" Visible="false">
                    <Bands>
                        <ig:UltraGridBand AddButtonCaption="Column0Column1Column2" Key="Column0Column1Column2">
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                        BorderCollapseDefault="Separate" HeaderClickActionDefault="NotSet" Name="ugrdMScore2"
                        RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                        Version="4.00" TableLayout="Fixed" StationaryMargins="Header" NoDataMessage=" "
                        OptimizeCSSClassNamesOutput="False">
                        <%--
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px" Height="20px">
                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#C7C7C7" ForeColor="White" Height="20px">
                                <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
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
                            <ClientSideEvents />--%>
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                            </BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                        </HeaderStyleDefault>
                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                        <RowStyleDefault CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                        </SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                        </RowAlternateStyleDefault>
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                        </FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
        <tr style="height: 25px;">
            <td align="right">
                <asp:ImageButton ID="iBtnDownload" runat="server" align="absmiddle" Height="19px"
                    ImageUrl="../images/btn/b_080.gif" Visible="false" OnClick="iBtnDownload_Click" />
                <div id="divLoadingIMG" style="display: none;">
                    <img src="../images/loading6.gif" alt="처리중" />
                </div>
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <asp:LinkButton ID="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:LinkButton>
    <!--- MAIN END --->
</asp:Content>
