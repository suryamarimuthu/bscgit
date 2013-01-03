<%@ Page Title="" Language="C#" MasterPageFile="~/_common/lib/MicroBSC.master" AutoEventWireup="true" CodeFile="PRJ1102S1.aspx.cs" Inherits="PRJ_PRJ1102S1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contents" Runat="Server">


    <script src="../_common/js/jQuery/jquery-1.6.4.js" type="text/javascript"></script>
<script id="Infragistics" type="text/javascript">


    function OpenWorkStgWindow(ESTTERM_REF_ID, EST_DEPT_REF_ID, WORK_REF_ID) {

        var strURL = 'PRJ1102S2.aspx?ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&WORK_REF_ID=' + WORK_REF_ID;
        gfOpenWindow(strURL, 500, 320, "yes", "no", "PRJ1102S2");

    }
    
    function OpenExecStgWindow(ESTTERM_REF_ID, EST_DEPT_REF_ID, WORK_REF_ID, EXEC_REF_ID) {

        var strURL = 'PRJ1102S3.aspx?ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&WORK_REF_ID=' + WORK_REF_ID + '&EXEC_REF_ID=' + EXEC_REF_ID;
        gfOpenWindow(strURL, 500, 320, "yes", "no", "PRJ1102S3");

    }

    //중점과제 수정화면 호출
    function OpenWorkModifyWindow() {

        var ESTTERM_REF_ID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo) %>";
        var EST_DEPT_REF_ID = "<%= this.IEstDeptRefID %>";

        var ugrd = igtbl_getGridById('<%= ugrdWorkInfoList.ClientID %>');
        var oRow = igtbl_getActiveRow(ugrd.Id);
        var WORK_REF_ID = oRow.getCellFromKey("WORK_REF_ID").getValue();
        
        var workYN = 'U';

        if (WORK_REF_ID == 0) {
            alert('중점과제 선택 후 수정 바랍니다.');
            return false;
        }
        else {

            var ICCB1 = "<%= this.ICCB2 %>";

            var strURL = 'PRJ1102M1.aspx?iType=' + workYN + '&ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&WORK_REF_ID=' + WORK_REF_ID + '&CCB1=' + ICCB1;
            gfOpenWindow(strURL, 720, 650, "yes", "no", "PRJ1102M1");
            return false;
        }
    }

    //중점과제 추가화면 호출
    function OpenWorkInsertWindow() {

        var ESTTERM_REF_ID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo) %>"; 
        var EST_DEPT_REF_ID = "<%= this.IEstDeptRefID%>";
        var WORK_REF_ID = '';
        var workYN = 'A';

        var ICCB1 = "<%= this.ICCB2 %>";

        var strURL = 'PRJ1102M1.aspx?iType=' + workYN + '&ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&WORK_REF_ID=' + WORK_REF_ID + '&CCB1=' + ICCB1;
        gfOpenWindow(strURL, 720, 650, "yes", "no", "PRJ1102M1");

        return false;
    }

    //실행과제 수정화면 호출
    function OpenExecModifyWindow() {

        var ESTTERM_REF_ID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo) %>";
        var EST_DEPT_REF_ID = "<%= this.IEstDeptRefID%>";

        var ugrd = igtbl_getGridById('<%= ugrdWorkExecList.ClientID %>');
        var oRow = igtbl_getActiveRow(ugrd.Id);
        var WORK_REF_ID = oRow.getCellFromKey("WORK_REF_ID").getValue();
        var EXEC_REF_ID = oRow.getCellFromKey("EXEC_REF_ID").getValue();
       
        var workYN = 'U';

        if (EXEC_REF_ID == 0) {
            alert('실행과제 선택 후 수정 바랍니다.');
            return false;

        }
        else {
            var ICCB1 = "<%= this.ICCB3 %>";


            var strURL = 'PRJ1102M5.aspx?iType=' + workYN + '&ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&WORK_REF_ID=' + WORK_REF_ID + '&EXEC_REF_ID=' + EXEC_REF_ID + '&CCB1=' + ICCB1;
            gfOpenWindow(strURL, 800, 700, 'yes', 'no', "PRJ1102M5");

            return false;
        }
    }
    
    //실행과제 추가화면 호출
    function OpenExecInsertWindow() {

        var ESTTERM_REF_ID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo) %>";
        var EST_DEPT_REF_ID = "<%= this.IEstDeptRefID%>";
        var WORK_REF_ID = '<%= this.IWorkRefID %>';
        var EXEC_REF_ID = ''
        var workYN = 'A';

        var ICCB1 = "<%= this.ICCB3 %>";


        var strURL = 'PRJ1102M5.aspx?iType=' + workYN + '&ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&WORK_REF_ID=' + WORK_REF_ID + '&CCB1=' + ICCB1;
        gfOpenWindow(strURL, 800, 700, "yes", "no", 'PRJ1102M5');

        return false;
        
    }

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

<script type="text/javascript" language="javascript">

    $(document).ready(function() {

        $('#conDetailDiv').scrollTop(1000);

    });
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

</script>

<table cellpadding="0" cellspacing="2" border="0"  style="width:100%; height:100%;">
    <tr valign="top" style="height: 40px;">
        <td>
            <!--   검색조건-->
			<table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
			    <colgroup>
			        <col width="90px" />
			        <col width="180px" />
			        <col width="90px" />
			        <col width="120px" />
			        <col width="90px" />
			        <col width="120px" />
			        <col />
			    </colgroup>
				<tr>
					<td class="tableTitle" align="center">평가기간</td>
					<td class="tableContent">
						<asp:DropDownList ID="ddlEstTermInfo" runat="server" AutoPostBack="true" 
							OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" CssClass="box01" Width="100%" >
						</asp:DropDownList>
					</td>
					<td class="tableTitle" align="center">평가조직</td>
					<td class="tableContent" colspan="3">
						<asp:dropdownlist id="ddlEstDept" class="box01" runat="server" width="100%" 
							AutoPostBack="True" onselectedindexchanged="ddlEstDept_SelectedIndexChanged"></asp:dropdownlist>
					</td>
					<td style="padding-right: 10px; vertical-align: bottom;" rowspan="2" align="right">
						<asp:ImageButton ID="iBtnSelectAll" runat="server" 
							ImageUrl="../images/btn/b_033.gif" onclick="iBtnSelectAll_Click"  />
					</td>
				</tr>
				<tr>
					<td class="tableTitle" align="center">관리자명</td>
					<td class="tableContent">
						<asp:TextBox ID="txtWorkEmpIDName" runat="server" Width="100%"></asp:TextBox>
					</td>
					<td class="tableTitle" align="center">중점과제코드</td>
					<td class="tableContent">
						<asp:TextBox ID="txtWorkCode" runat="server" Width="100%"></asp:TextBox>
					</td>
					<td class="tableTitle" align="center">중점과제명</td>
					<td class="tableContent">
						<asp:TextBox ID="txtWorkName" runat="server" Width="100%"></asp:TextBox>
					</td>
					<%--<td class="tableContent">
						<asp:ImageButton ID="iBtnSelect" runat="server" 
							ImageUrl="../images/btn/b_300.gif" onclick="iBtnSelect_Click" />
	                   
					</td>--%>
				</tr>
			</table>  
        </td>
    </tr>
    <tr  valign="top" style="height: 100%;">
        <td>
			<table cellpadding="0" cellspacing="2" border="0" style="width:100%; height:100%;">
				<tr style="height: 50%;">
				    <td>
                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%; height: 100%;" >
                            <tr style="height: 20px;">
                                <td class="tableTitle2" style="height: 20px;" > 
                                    <asp:Label ID="lblEstTerm1" runat="server" Text="" ForeColor="Gray" ></asp:Label>
                                    <asp:Label ID="lblEstDept1" runat="server" Text="" ForeColor="LightGray"></asp:Label>&nbsp;중점과제
                                </td>
                            </tr>
                            <tr >
                                <td  class="tableContent" style="height: 100%; width: 100%; padding: 0;">
                                    
                                    <ig:UltraWebGrid ID="ugrdWorkInfoList" runat="server" Width="100%" Height="100%" 
                                        OnInitializeRow="ugrdWorkInfoList_InitializeRow" 
                                        >
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                </AddNewRow>
                                                <Columns>

                                                    <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" 
                                                        EditorControlID="" Width="70px" FooterText="" HeaderText="사용여부">
                                                        <Header Caption="사용여부">
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Header>
                                                        <HeaderStyle Wrap="True" />
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <CellTemplate>
                                                            <asp:image runat="server" id="imgUseYn" AlternateText="" imagealign="AbsMiddle" 
                                                                imageurl="../images/icon_x.gif"></asp:image>
                                                        </CellTemplate>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    
                                                    <ig:TemplatedColumn BaseColumnName="COMPLETE_YN" Key="COMPLETE_YN" 
                                                        EditorControlID="" Width="70px" FooterText="" HeaderText="완료여부">
                                                        <Header Caption="완료여부">
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Header>
                                                        <HeaderStyle Wrap="True" />
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <CellTemplate>
                                                            <asp:image runat="server" id="imgCompleteYn" AlternateText="" imagealign="AbsMiddle" 
                                                                imageurl="../images/icon_x.gif"></asp:image>
                                                        </CellTemplate>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" 
                                                                        FooterText="ESTTERM_REF_ID" 
                                                                        HeaderText="ESTTERM_REF_ID" 
                                                                        Key="ESTTERM_REF_ID" 
                                                                        Width="80px"
                                                                        Hidden="true" >
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="ESTTERM_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID_NAME" 
                                                                        FooterText="ESTTERM_REF_ID_NAME" 
                                                                        HeaderText="ESTTERM_REF_ID_NAME" 
                                                                        Key="ESTTERM_REF_ID_NAME" 
                                                                        Width="80px"
                                                                        Hidden="true" >
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="ESTTERM_REF_ID">
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
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="EST_DEPT_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID_NAME" 
                                                                        FooterText="EST_DEPT_REF_ID_NAME" 
                                                                        HeaderText="EST_DEPT_REF_ID_NAME" 
                                                                        Key="EST_DEPT_REF_ID_NAME" 
                                                                        Width="80px"
                                                                        Hidden="true" >
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="EST_DEPT_REF_ID_NAME">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" 
                                                                        FooterText="WORK_REF_ID" 
                                                                        HeaderText="WORK_REF_ID" 
                                                                        Key="WORK_REF_ID" 
                                                                        Width="80px"
                                                                        Hidden="true" >
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="WORK_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="WORK_POOL_REF_ID" 
                                                                        FooterText="WORK_POOL_REF_ID" 
                                                                        HeaderText="WORK_POOL_REF_ID" 
                                                                        Key="WORK_POOL_REF_ID" 
                                                                        Width="80px"
                                                                        Hidden="true" >
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="WORK_POOL_REF_ID">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="WORK_CODE" 
                                                                        FooterText="" 
                                                                        HeaderText="중점과제코드" 
                                                                        Key="WORK_CODE" 
                                                                        Width="100px"
                                                                        Hidden="false" >
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="중점과제코드">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="WORK_NAME" 
                                                                        FooterText="" 
                                                                        HeaderText="중점과제명" 
                                                                        Key="WORK_NAME" 
                                                                        Width="200px"
                                                                        Hidden="false" >
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="중점과제명">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="WORK_EMP_ID" 
                                                                        FooterText="WORK_EMP_ID" 
                                                                        HeaderText="WORK_EMP_ID" 
                                                                        Key="WORK_EMP_ID" 
                                                                        Width="80px" Hidden="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="WORK_EMP_ID">
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="WORK_EMP_ID_NAME" 
                                                                        FooterText="" 
                                                                        HeaderText="중점과제관리자" 
                                                                        Key="WORK_EMP_ID_NAME" 
                                                                        Width="120px" Hidden="false">
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                        <Header Caption="중점과제관리자">
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="WORK_EMP_ID_DEPT_ID" 
                                                                        FooterText="WORK_EMP_ID_DEPT_ID" 
                                                                        HeaderText="WORK_EMP_ID_DEPT_ID" 
                                                                        Key="WORK_EMP_ID_DEPT_ID" 
                                                                        Width="80px" Hidden="true">
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="WORK_EMP_ID_DEPT_ID">
                                                            <RowLayoutColumnInfo OriginX="11" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="11" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="WORK_EMP_ID_DEPT_ID_NAME" 
                                                                        FooterText="WORK_EMP_ID_DEPT_ID_NAME" 
                                                                        HeaderText="WORK_EMP_ID_DEPT_ID_NAME" 
                                                                        Key="WORK_EMP_ID_DEPT_ID_NAME" 
                                                                        Width="80px" Hidden="true">
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="WORK_EMP_ID_DEPT_ID">
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>

                                                    <ig:UltraGridColumn BaseColumnName="EXEC_COUNT" 
                                                                        CellMultiline="Yes" 
                                                                        HeaderText="실행과제수"
                                                                        Key="EXEC_COUNT" 
                                                                        Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="실행과제수">
                                                            <RowLayoutColumnInfo OriginX="14" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="14" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>

                                                    
                                                    <ig:UltraGridColumn BaseColumnName="STG_COUNT" 
                                                                        CellMultiline="Yes" 
                                                                        HeaderText="전략수"
                                                                        Key="STG_COUNT" 
                                                                        Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="전략수">
                                                            <RowLayoutColumnInfo OriginX="15" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="15" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    
                                                  <%--  <ig:UltraGridColumn BaseColumnName="KPI_COUNT" 
                                                                        CellMultiline="Yes" 
                                                                        HeaderText="지표수"
                                                                        Key="KPI_COUNT" 
                                                                        Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="지표수">
                                                            <RowLayoutColumnInfo OriginX="16" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="16" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>                                         --%>           
                                                    
                                                    <ig:TemplatedColumn Key="btn">
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                        <Header Caption="실행과제">
                                                            <RowLayoutColumnInfo OriginX="16" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center">
                                                        </CellStyle>
                                                        <CellTemplate>
                                                            <asp:ImageButton ID="btnExecView" runat="server" ImageUrl="../images/treeview/folder.gif" 
                                                                OnClick="btnExecView_Click" />
                                                        </CellTemplate>
                                                    </ig:TemplatedColumn>
                                                </Columns>
                                                <RowTemplateStyle  BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                    <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                                </RowTemplateStyle>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
                                            AllowDeleteDefault="Yes"
                                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="SortMulti" Name="ugrdWorkInfoList" RowHeightDefault="20px"
                                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" 
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
                                                BorderWidth="0px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                            <ClientSideEvents  MouseOverHandler="MouseOverHandler" DblClickHandler="OpenWorkModifyWindow"   />
                                        </DisplayLayout>
                                            
                                    </ig:UltraWebGrid>
                                </td>
                            </tr>
                            <tr style=" height: 25px;">
                                <td class="tableContent" style="height: 25px;">
                                    <asp:Panel ID="pnlInfoBtn" runat="server" Visible="False">
                                        <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                            <tr>
                                                <td style="width:50%;" align="left" >
                                                    <asp:ImageButton runat="server" ID="iBtnWorkInfoRefresh" ImageUrl="../images/btn/b_133.gif" 
                                                        ImageAlign="AbsMiddle" onclick="iBtnWorkInfoRefresh_Click" 
                                                        />&nbsp;
                                                </td>
                                                <td style="padding-right: 10px; width:50%;" align="right" >
                                                    <img id="iBtnWorkInfoInsert" alt="" src="../images/btn/b_005.gif" style="cursor:hand; vertical-align:middle;" 
                                                            onclick="return OpenWorkInsertWindow();"  />
                                                   
                                                </td>
                                            </tr>
                                        </table> 
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 50%;">
                    <td style="padding: 0;">
                    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%; height: 100%">
                        <tr style="height: 20px;">
                            <td class="tableTitle2" style="height: 20px;" >
                                <asp:Label ID="lblWorkInfo2" runat="server" Text="" 
                                    ForeColor="LightGray" ></asp:Label>&nbsp;실행과제
                            </td>
                        </tr>
                        <tr style="height: 100%;">
                            <td style="height: 100%; padding: 0;" >
                                <table cellpadding="0" cellspacing="0" border="0" class="" style="height: 100%; width:100%;">
                                    <tr style="height: 100%;">
                                        <td  class="tableContent" style="height: 100%; padding: 0;" >
                                            <ig:UltraWebGrid ID="ugrdWorkExecList" runat="server" Width="100%" Height="100%" 
                                                OnInitializeRow="ugrdWorkExecList_InitializeRow" >
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                        
                                                            <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" 
                                                                EditorControlID="" Width="70px" FooterText="" HeaderText="사용여부">
                                                                <Header Caption="사용여부">
                                                                    <RowLayoutColumnInfo OriginX="13" />
                                                                </Header>
                                                                <HeaderStyle Wrap="True" />
                                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                <CellTemplate>
                                                                    <asp:image runat="server" id="imgUseYn" AlternateText="" imagealign="AbsMiddle" 
                                                                        imageurl="../images/icon_x.gif"></asp:image>
                                                                </CellTemplate>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="13" />
                                                                </Footer>
                                                            </ig:TemplatedColumn>

                                                            <ig:TemplatedColumn BaseColumnName="COMPLETE_YN" Key="COMPLETE_YN" 
                                                                EditorControlID="" Width="70px" FooterText="" HeaderText="완료여부">
                                                                <Header Caption="완료여부">
                                                                    <RowLayoutColumnInfo OriginX="13" />
                                                                </Header>
                                                                <HeaderStyle Wrap="True" />
                                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                <CellTemplate>
                                                                    <asp:image runat="server" id="imgCompleteYn" AlternateText="" imagealign="AbsMiddle" 
                                                                        imageurl="../images/icon_x.gif"></asp:image>
                                                                </CellTemplate>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="13" />
                                                                </Footer>
                                                            </ig:TemplatedColumn>

                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" 
                                                                                FooterText="ESTTERM_REF_ID" 
                                                                                HeaderText="ESTTERM_REF_ID" 
                                                                                Key="ESTTERM_REF_ID" 
                                                                                Width="80px"
                                                                                Hidden="true" >
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="ESTTERM_REF_ID">
                                                                    <RowLayoutColumnInfo OriginX="0" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="0" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID_NAME" 
                                                                                FooterText="ESTTERM_REF_ID_NAME" 
                                                                                HeaderText="ESTTERM_REF_ID_NAME" 
                                                                                Key="ESTTERM_REF_ID_NAME" 
                                                                                Width="80px"
                                                                                Hidden="true" >
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="ESTTERM_REF_ID_NAME">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                        
                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" 
                                                                                FooterText="EST_DEPT_REF_ID" 
                                                                                HeaderText="EST_DEPT_REF_ID" 
                                                                                Key="EST_DEPT_REF_ID" 
                                                                                Width="80px"
                                                                                Hidden="true" >
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="EST_DEPT_REF_ID">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID_NAME" 
                                                                                FooterText="EST_DEPT_REF_ID_NAME" 
                                                                                HeaderText="EST_DEPT_REF_ID_NAME" 
                                                                                Key="EST_DEPT_REF_ID_NAME" 
                                                                                Width="80px"
                                                                                Hidden="true" >
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="EST_DEPT_REF_ID_NAME">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" 
                                                                                FooterText="WORK_REF_ID" 
                                                                                HeaderText="WORK_REF_ID" 
                                                                                Key="WORK_REF_ID" 
                                                                                Width="80px"
                                                                                Hidden="true" >
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="WORK_REF_ID">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID_NAME" 
                                                                                FooterText="WORK_REF_ID_NAME" 
                                                                                HeaderText="WORK_REF_ID_NAME" 
                                                                                Key="WORK_REF_ID_NAME" 
                                                                                Width="80px"
                                                                                Hidden="true" >
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="WORK_REF_ID_NAME">
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
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="EXEC_REF_ID">
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_CODE" 
                                                                                FooterText="" 
                                                                                HeaderText="실행과제코드" 
                                                                                Key="EXEC_CODE" 
                                                                                Width="100px"
                                                                                Hidden="false" >
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="실행과제코드">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_NAME" 
                                                                                FooterText="" 
                                                                                HeaderText="실행과제명" 
                                                                                Key="EXEC_NAME" 
                                                                                Width="200px"
                                                                                Hidden="false" >
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="실행과제명">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_EMP_ID" 
                                                                                FooterText="EXEC_EMP_ID" 
                                                                                HeaderText="EXEC_EMP_ID" 
                                                                                Key="EXEC_EMP_ID" 
                                                                                Width="80px" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="EXEC_EMP_ID">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="9" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_EMP_ID_NAME" 
                                                                                FooterText="EXEC_EMP_ID_NAME" 
                                                                                HeaderText="실행과제관리자" 
                                                                                Key="EXEC_EMP_ID_NAME" 
                                                                                Width="120px" Hidden="false">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="실행과제관리자">
                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_EMP_ID_DEPT_ID" 
                                                                                FooterText="EXEC_EMP_ID_DEPT_ID" 
                                                                                HeaderText="EXEC_EMP_ID_DEPT_ID" 
                                                                                Key="EXEC_EMP_ID_DEPT_ID" 
                                                                                Width="80px" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="EXEC_EMP_ID_DEPT_ID">
                                                                    <RowLayoutColumnInfo OriginX="11" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="11" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="EXEC_EMP_ID_DEPT_ID_NAME" 
                                                                                FooterText="EXEC_EMP_ID_DEPT_ID_NAME" 
                                                                                HeaderText="EXEC_EMP_ID_DEPT_ID_NAME" 
                                                                                Key="EXEC_EMP_ID_DEPT_ID_NAME" 
                                                                                Width="80px" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="EXEC_EMP_ID_DEPT_ID_NAME">
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
         
                                                            <ig:UltraGridColumn BaseColumnName="TASK_COUNT" 
                                                                                CellMultiline="Yes" 
                                                                                HeaderText="세부일정수"
                                                                                Key="TASK_COUNT" 
                                                                                Width="80px">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="세부일정수">
                                                                    <RowLayoutColumnInfo OriginX="14" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="14" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                           <ig:UltraGridColumn BaseColumnName="ITEM_COUNT" 
                                                                                CellMultiline="Yes" 
                                                                                HeaderText="관리항목수"
                                                                                Key="ITEM_COUNT" 
                                                                                Width="80px">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="관리항목수">
                                                                    <RowLayoutColumnInfo OriginX="14" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="14" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="STG_COUNT" 
                                                                                CellMultiline="Yes" 
                                                                                HeaderText="전략수"
                                                                                Key="STG_COUNT" 
                                                                                Width="80px">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="전략수">
                                                                    <RowLayoutColumnInfo OriginX="15" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="15" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
<%--                                                            <ig:UltraGridColumn BaseColumnName="KPI_COUNT" 
                                                                                CellMultiline="Yes" 
                                                                                HeaderText="지표수"
                                                                                Key="KPI_COUNT" 
                                                                                Width="80px">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                                <Header Caption="지표수">
                                                                    <RowLayoutColumnInfo OriginX="16" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="16" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>--%>
                                                            
                                                        </Columns>
                                                        <RowTemplateStyle  BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" 
                                                    AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="SortMulti" Name="ugrdWorkExecList" RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" 
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
                                                        BorderWidth="0px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                                    <ClientSideEvents MouseOverHandler="MouseOverHandler"  DblClickHandler="OpenExecModifyWindow"   />
                                                </DisplayLayout>    
                                            </ig:UltraWebGrid>
                                        </td>
                                    </tr>
                                    <tr style="height: 20px;">
                                        <td class="tableContent" style="height: 20px;" >
                                            <asp:Panel ID="pnlExecBtn" runat="server" Visible="False">
                                                <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                                    <tr>
                                                        <td style="width:50%;" align="left" >
                                                            <asp:ImageButton runat="server" ID="iBtnWorkExecRefresh" ImageUrl="../images/btn/b_133.gif" 
                                                                ImageAlign="AbsMiddle" onclick="iBtnWorkExecRefresh_Click" />
                                                        </td>
                                                        <td style="width:50%;" align="right" >
                                                            <img id="iBtnWorkExecInsert" alt="" src="../images/btn/b_005.gif" style="cursor:hand; vertical-align:middle;" 
                                                                onclick="return OpenExecInsertWindow();" />
                                                           
                                                        
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>                        
                        </tr> 
                        <tr>
                            <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
                        </tr>    
                    </table>    
                    </td>
                </tr>
            </table>

        </td>
    </tr>
</table>

<div>
    &nbsp;
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    <asp:Literal ID="Literal3" runat="server"></asp:Literal>

</div>

</asp:Content>


