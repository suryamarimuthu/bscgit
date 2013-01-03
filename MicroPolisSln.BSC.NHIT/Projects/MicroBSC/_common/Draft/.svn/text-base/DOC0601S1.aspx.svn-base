<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DOC0601S1.aspx.cs" Inherits="_common_Draft_DOC0601S1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .docalignleft
        {
        	text-align: left;
        }
    </style>
    <script type="text/javascript" language="javascript" src="/_common/js/common.js"></script>
    <script type="text/javascript" language="javascript" src="../../_common/js/common.js"></script>
    <script type="text/javascript">
        function OpenDraftPrint() {
            var ugrd = igtbl_getGridById('ugrdKPI');
            var selRow = ugrd.getActiveRow();

            var estterm_ref_id = '<%= this.IESTTERM_REF_ID %>';

            var kpi_ref_id = selRow.getCellFromKey("KPI_REF_ID").getValue();
            var app_ref_id = "0";
            var biz_type = "<%= Biz_Type.biz_type_kpi_doc %>";
            var url = "/BSC/BSC0901P1.aspx?DRAFT_STATUS=" + '<%= Biz_Type.app_draft_select %>' + "&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id + "&BIZ_TYPE=" + biz_type + "&APP_REF_ID=" + app_ref_id;

            gfOpenWindow(url, 900, 650, 'BSC0901P1');

            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
   {^0^}
   <div style="text-align:center; width:98%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
       <script type="text/javascript" language="javascript">  
    <!--    
    function mfUpload(hAttachNo, strUpDown)
    {
        <%
        /*
            Argument설명
                : ICM_FILE / ICM_PROCFILE 어느쪽에 셋팅하는가? (FILE / PROCFILE)
                : 파일첨부시 어떤 프로젝트 소속인가? 해당폴더및 ATTACHNO추출시 접두어로 사용됨 (ICM, DCM, ....)
        */
        %>
        //수정(20060707 이승주)
        //var oAttach = gfGetFindObj("hAttachNo");
        var oAttach = gfGetFindObj(hAttachNo);
        var oaArg   = new Array("FILE", "MBOREA", (oAttach==null ? "" : oAttach.value));
        
        var oReturn = "";
        if (strUpDown == "UP")
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=T", oaArg, 485, 307);
        }
        else
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F", oaArg, 485, 307);
        }
        
        if (oReturn != "" && oReturn != undefined)
        {
            oAttach.value = oReturn;
            //__doPostBack('lBtnReload', '');
        }
        else
        {
            alert("파일첨부를 하지 않았습니다!");
        }
        return false;
    }
    //-->  
    </script>
        <table border="0" cellpadding="0" cellspacing="0" width="870px" style="text-align:center;">
          <tr>
            <td colspan="6" valign="top" style="padding-top: 1px; width: 100%;">
              <ig:UltraWebGrid ID="ugrdKPI" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKPI_InitializeRow" OnInitializeLayout="ugrdKPI_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="KPI 코드">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영조직">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" CssClass="docalignleft">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" HeaderText="KPI 명" Key="KPI_NAME" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left" CssClass="docalignleft" Font-Bold="true">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI담당자">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="단위">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID=""
                                    FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="실적방식">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_ID" Key="CHAMPION_EMP_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS" Key="APPROVAL_STATUS" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="IS_TEAM_KPI" Key="IS_TEAM_KPI" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" 
                        AllowColSizingDefault="Free" 
                        AllowColumnMovingDefault="None" 
                        AllowDeleteDefault="No"
                        AllowSortingDefault="Yes" 
                        BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="SortMulti" 
                        Name="ugrdKPI" 
                        RowHeightDefault="20px" 
                        HeaderStyleDefault-Height="23px"
                        RowSelectorsDefault="No" 
                        SelectTypeRowDefault="Extended" 
                        Version="4.00" 
                        CellClickActionDefault="RowSelect" 
                        TableLayout="Fixed" 
                        StationaryMargins="Header" 
                        AutoGenerateColumns="False"
                        UseFixedHeaders="true">
                        <GroupByBox>
                            <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
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
                        <ClientSideEvents DblClickHandler="OpenDraftPrint" />
                    </DisplayLayout>
              </ig:UltraWebGrid>
            </td>
          </tr>
        </table>
        <asp:HiddenField ID = "hdfTargetReasonFile" runat="server" Value="" />
    </div>
   {^0^}
    </form>
</body>
</html>
