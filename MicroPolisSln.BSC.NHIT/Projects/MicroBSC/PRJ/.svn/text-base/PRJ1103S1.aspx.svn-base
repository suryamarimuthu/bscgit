<%@ Page Title="" Language="C#" MasterPageFile="~/_common/lib/MicroBSC.master" AutoEventWireup="true" CodeFile="PRJ1103S1.aspx.cs" Inherits="PRJ_PRJ1103S1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contents" Runat="Server">

<script type="text/javascript" language="javascript">

    function showMemo() {
        document.all.imgShow.style.display = "none";
        document.all.imgHide.style.display = "block";
        document.all.leftLayer.style.display = "block";
    }

    function hiddenMemo() {
        document.all.imgShow.style.display = "block";
        document.all.imgHide.style.display = "none";
        document.all.leftLayer.style.display = "none";
    }
    
    //중점과제 수정화면 호출
    function OpenMapSKIEWindow() {

        var ESTTERM_REF_ID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo) %>";
        var EST_DEPT_REF_ID = "<%= this.IEstDeptRefID %>";
        var MAP_VERSION_ID = "<%= this.IMapVersionID %>";
        var workYN = "A";
        if (MAP_VERSION_ID == 0) {
            alert('해당 부서의 기본맵이 없습니다. 맵 생성 후 다시 하세요.');
            return false;
        }
        else {

            var ICCB1 = "<%= this.ICCB1 %>";

            var strURL = 'PRJ1103M1.aspx?iType=' + workYN + '&ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID1=' + EST_DEPT_REF_ID + '&MAP_VERSION_ID=' + MAP_VERSION_ID + '&CCB1=' + ICCB1;
            gfOpenWindow(strURL, 1000, 800, "PRJ1103M1");
        }
    }

</script>

<script id="Infragistics" type="text/javascript">

    function MouseOverHandler(gridName, id, objectType) {
        if (objectType == 0) {

            var cell = igtbl_getElementById(id);
            var row = igtbl_getRowById(id);
            var band = igtbl_getBandById(id);
            var active = igtbl_getActiveRow(id);

            cell.style.cursor = 'hand';
        }
    }

</script>



<table cellpadding="1" cellspacing="0" border="0" style="width: 100%; height: 100%">
    <tr valign="top">
        <td style="width:5px;">
            <!--- Tree  --->	
            <div id="leftLayer" style="border: #F4F4F4 3 solid; DISPLAY: block; overflow: auto; position: static; width: 200px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                <asp:TreeView ID="trvEstDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" 
                    OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                        VerticalPadding="0px" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                        NodeSpacing="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </div>
            <!--- /Tree  --->
        </td>
        <td style="width:5px;">
            <!--- 이미지  --->	
            <a href="javascript:hiddenMemo();"><img alt="" src="../images/btn/btn_Hide.gif" id="imgHide" /></a><br />
            <a href="javascript:showMemo();"><img alt="" src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" /></a>
        </td>
        <td>
            <table cellpadding="" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                <tr >
                    <td style="width:100%; height:40px;"  class="tableOutBorder">
                    
                        <!--   검색조건-->
                        <div id="Div1" >
                            <table  cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                <tr>
                                    <td class="tableTitle2" align="center" style="width: 100px;"><span>평&nbsp;가&nbsp;기&nbsp;간</span></td>
                                    <td class="tableContent"  style="width: 210px;">
                                        <asp:DropDownList ID="ddlEstTermInfo" runat="server" AutoPostBack="true" 
                                            OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" CssClass="box01" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="tableTitle2" align="center"  style="width: 100px;">평&nbsp;가&nbsp;부&nbsp;서</td>
                                    <td class="tableContent" >
                                        <asp:TextBox ID="txtEstDeptName" runat="server" Width="210px" style="vertical-align: middle;"></asp:TextBox>&nbsp;
                                        <asp:ImageButton ID="iBtnSelect" runat="server" style="vertical-align:middle;" 
                                            ImageUrl="../images/btn/b_301.gif" onclick="iBtnSelect_Click"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle2" align="center"  style="width:100px;">전략맵</td>
                                    <td class="tableContent" colspan="3">
                                        <asp:TextBox ID="txtMapVerName" runat="server" Width="160px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>  
                        </div>                    
                    </td>
                </tr>
                <tr valign="top">
                    <td style="height: 100%;">
                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;" class="tableBorder"  >
                            <tr valign="top">
                                <td style="width: 200px; height: 100%;">
                                    <div id="divMap" style="border: #F4F4F4 3 solid; DISPLAY: block; overflow: auto; position: static; 
                                        width: 200px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                                        <asp:TreeView ID="trvStgMap" runat="server" OnSelectedNodeChanged="trvStgMap_SelectedNodeChanged" 
                                            ImageSet="Faq" BorderStyle="None" EnableTheming="False" PopulateNodesFromClient="False" ShowLines="false" NodeIndent="15" >
                                            <ParentNodeStyle Font-Bold="False" />
                                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" 
                                                VerticalPadding="0px" />
                                        </asp:TreeView>
                                    </div>
                                </td>
                                <td>
                                    <div id="conDetailDiv"  style="border: #F4F4F4 3 solid; DISPLAY: block; overflow: auto; position: static; 
                                         height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                                        
                                        <ig:UltraWebGrid ID="ugrdMapSKIE" runat="server" Width="100%" Height="100%" 
                                            oninitializerow="ugrdMapSKIE_InitializeRow" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>

                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" 
                                                                            FooterText="ESTTERM_REF_ID" 
                                                                            HeaderText="ESTTERM_REF_ID" 
                                                                            Key="ESTTERM_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="평가기간ID">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_NAME" 
                                                                            FooterText="ESTTERM_NAME" 
                                                                            HeaderText="ESTTERM_NAME" 
                                                                            Key="ESTTERM_NAME" 
                                                                            Width="100px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="평가기간">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    
                                                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" 
                                                                            FooterText="EST_DEPT_REF_ID" 
                                                                            HeaderText="EST_DEPT_REF_ID" 
                                                                            Key="EST_DEPT_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="평가부서ID">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" 
                                                                            FooterText="DEPT_NAME" 
                                                                            HeaderText="DEPT_NAME" 
                                                                            Key="DEPT_NAME" 
                                                                            Width="100px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="평가부서">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="STG_REF_ID" 
                                                                            FooterText="STG_REF_ID" 
                                                                            HeaderText="STG_REF_ID" 
                                                                            Key="STG_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="전략id">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="STG_NAME" 
                                                                            FooterText="STG_NAME" 
                                                                            HeaderText="STG_NAME" 
                                                                            Key="STG_NAME" 
                                                                            Width="100px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="전략명">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                         <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" 
                                                                            FooterText="KPI_REF_ID" 
                                                                            HeaderText="KPI_REF_ID" 
                                                                            Key="KPI_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="지표id">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                         <ig:UltraGridColumn BaseColumnName="KPI_NAME" 
                                                                            FooterText="KPI_NAME" 
                                                                            HeaderText="KPI_NAME" 
                                                                            Key="KPI_NAME" 
                                                                            Width="100px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="지표명">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                         <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" 
                                                                            FooterText="WORK_REF_ID" 
                                                                            HeaderText="WORK_REF_ID" 
                                                                            Key="WORK_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="중점과제id">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                         <ig:UltraGridColumn BaseColumnName="WORK_NAME" 
                                                                            FooterText="WORK_NAME" 
                                                                            HeaderText="WORK_NAME" 
                                                                            Key="WORK_NAME" 
                                                                            Width="100px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="중점과제명">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                         <ig:UltraGridColumn BaseColumnName="EXEC_REF_ID" 
                                                                            FooterText="EXEC_REF_ID" 
                                                                            HeaderText="EXEC_REF_ID" 
                                                                            Key="EXEC_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실행과제id">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                         <ig:UltraGridColumn BaseColumnName="EXEC_NAME" 
                                                                            FooterText="EXEC_NAME" 
                                                                            HeaderText="EXEC_NAME" 
                                                                            Key="EXEC_NAME" 
                                                                            Width="100px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실행과제명">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                       
                                                        <ig:UltraGridColumn BaseColumnName="ORDER_SEQ" 
                                                                            FooterText="ORDER_SEQ" 
                                                                            HeaderText="ORDER_SEQ" 
                                                                            Key="ORDER_SEQ" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="정렬순서">
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                    </Columns>
                                                    <RowTemplateStyle  BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" 
                                                AllowDeleteDefault="Yes"
                                                AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" Name="ugrdMapSKIE" RowHeightDefault="20px"
                                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="OutlookGroupBy" 
                                                CellClickActionDefault="RowSelect"
                                                TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
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
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
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
                                                <ClientSideEvents  MouseOverHandler="MouseOverHandler"  />
                                            </DisplayLayout>
                                                
                                        </ig:UltraWebGrid>
                                                                                           
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr valign="top">
                    <td >

                        <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
                        <img alt="" src="../images/btn/b_002.gif" style="cursor:hand;" onclick="return OpenMapSKIEWindow();" />
                    </td>
                </tr>
            </table>

        </td>
    </tr>
</table>

<div>
    &nbsp;
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal><asp:Literal ID="Literal2" runat="server"></asp:Literal><asp:Literal ID="Literal3" runat="server"></asp:Literal></div>
</asp:Content>