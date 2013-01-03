<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DOC0401S1.aspx.cs" Inherits="_common_Draft_DOC0401S1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
        <table border="0" cellpadding="0" cellspacing="0" width="1360px" style="text-align:center;">
          <tr>
            <td colspan="6" valign="top" style="padding-top: 1px; width: 100%;">
              <ig:UltraWebGrid ID="ugrdMBO" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMBO_InitializeRow" OnInitializeLayout="ugrdMBO_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="KPI<BR />코드" Fixed="true">
                                        <RowLayoutColumnInfo />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영조직" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="담당자" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CLASS_NAME" Key="CLASS_NAME" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표구분" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_NAME" Key="CATEGORY_NAME" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직무분류" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" Key="UNIT_NAME" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="단위" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="가중치" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS_YN" Key="APPROVAL_STATUS_YN" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="확정여부" Fixed="true">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH01" HeaderText="1월" Key="MONTH01" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH02" HeaderText="2월" Key="MONTH02" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH03" HeaderText="3월" Key="MONTH03" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH04" HeaderText="4월" Key="MONTH04" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH05" HeaderText="5월" Key="MONTH05" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH06" HeaderText="6월" Key="MONTH06" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH07" HeaderText="7월" Key="MONTH07" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH08" HeaderText="8월" Key="MONTH08" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH09" HeaderText="9월" Key="MONTH09" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH10" HeaderText="10월" Key="MONTH10" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH11" HeaderText="11월" Key="MONTH11" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH12" HeaderText="12월" Key="MONTH12" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
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
                        Name="ugrdMBO" 
                        RowHeightDefault="20px" 
                        HeaderStyleDefault-Height="35px"
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
                            Width="1360px">
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
                        <ClientSideEvents DblClickHandler="" />
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
