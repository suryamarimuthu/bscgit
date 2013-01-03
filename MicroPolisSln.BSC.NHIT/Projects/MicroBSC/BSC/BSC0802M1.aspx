<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0802M1.aspx.cs" Inherits="BSC_BSC0802M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript" language="javascript">
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
    
    function askAllCopyKPI()
    {
        if (confirm("현재 선택된 사용자의 지표를 해당 그룹의 모든 사용자에게 배포하시겠습니까? \n "))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
</script>

       <!--- MAIN START --->
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
          <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                  <tr>
                    <td style="width:230px;" class="tableContent">
                      <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                        <tr>
                          <td style="height:95px; vertical-align:top;" class="tableoutBorder">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                              <tr>
                                <td style="width:60px;" class="tableTitle">평가기간</td>
                                <td class="tableContent">
                                  <asp:DropDownList ID="ddlEstTerm" CssClass="box01" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                              </tr>
                              <tr>
                                <td class="tableTitle">평가그룹</td>
                                <td class="tableContent"><asp:DropDownList ID="ddlEstGroup" CssClass="box01" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstGroup_SelectedIndexChanged"></asp:DropDownList></td>
                              </tr>
                              <tr>
                                <td class="tableTitle">평가차수</td>
                                <td class="tableContent"><asp:DropDownList ID="ddlEstLevel" CssClass="box01" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstGroup_SelectedIndexChanged"></asp:DropDownList></td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                        <tr>
                          <td style="vertical-align:top;">
                            <table border="0" cellpadding="0" cellspacing="0" >
                              <tr>
                                <td style="height:210px;">
                                    <ig:ultrawebgrid id="ugrdVaidationUserGrid" runat="server" width="100%" Height="100%" style="left: 0px" OnActiveRowChange="ugrdVaidationUserGrid_ActiveRowChange"><Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px" Hidden="true">
                                            <CellTemplate>
                                                <asp:CheckBox ID="cBox" runat="server" />
                                            </CellTemplate>
                                            </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Width="50px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="ESTTERM_REF_ID">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header><Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="GROUP_REF_ID" Key="GROUP_REF_ID" Width="60px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="GROUP_REF_ID">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header><Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="사원번호" Key="EMP_REF_ID" Width="60px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="사원번호">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header><Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="LOGINID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="로그인ID" Key="LOGINID" Width="60px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="로그인ID">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="DEPT_NAME" Key="DEPT_NAME" Width="100px" Hidden="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="부서명">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="50px" FooterText="" HeaderText="이름">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="평가자">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="CNT_KPI" Key="CNT_KPI" Width="55px" FooterText="" HeaderText="이름">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <Header Caption="지표수">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="USE_YN" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="USE_YN" Key="USE_YN" Width="50px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="평가">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                        <DisplayLayout ViewType="Flat" Version="4.00" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" HeaderStyleDefault-Height="35px"
                                                       HeaderClickActionDefault="SortMulti" Name="ugrdVaidationUserGrid" BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" 
                                                       RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" 
                                                       AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" 
                                                       StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed" JavaScriptFileName="" JavaScriptFileNameCommon="" 
                                                       AllowUpdateDefault="Yes">
                                            <GroupByBox>
                                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                            </GroupByBox>
                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                            </GroupByRowStyleDefault>
                                            <ActivationObject BorderColor="" BorderWidth="">
                                            </ActivationObject>
                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                            </FooterStyleDefault>
                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                <Padding Left="3px" />
                                            </RowStyleDefault>
                                            <SelectedRowStyleDefault BackColor="#E2ECF4">
                                            </SelectedRowStyleDefault>
                                            <HeaderStyleDefault BackColor="#5DABC0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#D2D2D2" ForeColor="White">
                                                <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                            </HeaderStyleDefault>
                                            <Images ImageDirectory="">
                                            </Images>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" Cursor="Hand" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                Width="100%">
                                            </FrameStyle>
                                            <Pager>
                                                <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                            </Style>
                                            </Pager>
                                            <AddNewBox Hidden="False">
                                                <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                            </Style>
                                            </AddNewBox>
                                        </DisplayLayout>
                                    </ig:ultrawebgrid>
                                </td>
                              </tr>
                              <tr>
                                <td style="height:210px;">
                                    <ig:ultrawebgrid id="ugrdTerm" runat="server" width="100%" Height="100%" style="left: 0px" OnInitializeRow="ugrdTerm_InitializeRow"><Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px" Hidden="true">
                                            <CellTemplate>
                                                <asp:CheckBox ID="cBox" runat="server" />
                                            </CellTemplate>
                                            </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="YMD" Key="YMD" Width="80px" Hidden="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="평가기간">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header><Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn BaseColumnName="EST_YN" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="EST_YN" Key="EST_YN" Width="60px" Hidden="false">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <Header Caption="평가여부">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellTemplate>
                                                      <asp:CheckBox ID="chkEst" runat="server" />
                                                    </CellTemplate>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn BaseColumnName="BIAS_YN" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="BIAS_YN" Key="BIAS_YN" Width="60px" Hidden="false">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <Header Caption="조정여부">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellTemplate>
                                                      <asp:CheckBox ID="chkBias" runat="server" />
                                                    </CellTemplate>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Width="50px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="ESTTERM_REF_ID">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header><Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="GROUP_REF_ID" Key="GROUP_REF_ID" Width="50px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="GROUP_REF_ID">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header><Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_LEVEL" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="EST_LEVEL" Key="EST_LEVEL" Width="50px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="EST_LEVEL">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header><Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                                                    Format="" HeaderText="YMD" Key="YMD" Width="50px" Hidden="true">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="YMD">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header><Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                        <DisplayLayout ViewType="Flat" Version="4.00" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" HeaderStyleDefault-Height="35px"
                                                       HeaderClickActionDefault="SortMulti" Name="ugrdVaidationUserGrid" BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" 
                                                       RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" 
                                                       AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" 
                                                       StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed" JavaScriptFileName="" JavaScriptFileNameCommon="" 
                                                       AllowUpdateDefault="Yes">
                                            <GroupByBox>
                                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                            </GroupByBox>
                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                            </GroupByRowStyleDefault>
                                            <ActivationObject BorderColor="" BorderWidth="">
                                            </ActivationObject>
                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                            </FooterStyleDefault>
                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                <Padding Left="3px" />
                                            </RowStyleDefault>
                                            <SelectedRowStyleDefault BackColor="#E2ECF4">
                                            </SelectedRowStyleDefault>
                                            <HeaderStyleDefault BackColor="#5DABC0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#D2D2D2" ForeColor="White">
                                                <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                            </HeaderStyleDefault>
                                            <Images ImageDirectory="">
                                            </Images>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" Cursor="Hand" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                Width="100%">
                                            </FrameStyle>
                                            <Pager>
                                                <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                            </Style>
                                            </Pager>
                                            <AddNewBox Hidden="False">
                                                <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                            </Style>
                                            </AddNewBox>
                                        </DisplayLayout>
                                    </ig:ultrawebgrid>
                                </td>
                              </tr>
                              <tr>
                                <td align="right">
                                   <asp:ImageButton ID="iBtnSaveEstTerm" runat="server" ImageUrl="~/images/btn/b_007.gif" ImageAlign="absMiddle" OnClick="iBtnSaveEstTerm_Click" />
                                </td>
                              </tr>
                            </table>
                          

                          </td>
                        </tr>
                      </table>
                    </td>
                    <td class="tableContent">
                      <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                        <tr>
                          <td style="height:60px; vertical-align:top;" class="tableoutBorder">
                            <table cellspacing="0" cellpadding="2" width="100%" border="0">
                              <tbody>
                                <tr>
                                  <td class="tableTitle" style="width:60px;" align="center"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                                  <td class="tableContent" style="width:100px;"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>
                                  <td class="tableTitle" style="width:60px;" align="center">KPI명</td>
                                  <td class="tableContent" style="width:100px;"><asp:TextBox id="txtKPIName" runat="server" width="100%"></asp:TextBox> </td>
                                  <td class="tableTitle" style="width:60px;" align="center">지표군</td>
                                  <td class="tableContent" style="width:100px;"><asp:DropDownList id="ddlKpiGroup" runat="server" width="100%" CssClass="box01"></asp:DropDownList> </td>
                                  <td class="tableContent" align="right" rowspan="2">
                                    <asp:ImageButton id="iBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" Height="19px" OnClick="iBtnSearch_Click"></asp:ImageButton>
                                    <asp:ImageButton ID="iBtnSearchNotAlloc" runat="server" ImageUrl="../images/btn/b_013.gif" OnClick="iBtnSearchNotAlloc_Click" />
                                  </td>
                                </tr>
                                <tr>
                                  <td class="tableTitle" align="right">운영조직</td>
                                  <td class="tableContent"><asp:dropdownlist id="ddlEstDept" runat="server" width="100%" CssClass="box01"></asp:dropdownlist></td>
                                  <td class="tableTitle" align="right"><%=this.GetText("LBL_00001", "챔피언") %></td>
                                  <td class="tableContent"><asp:TextBox id="txtChamName" runat="server" width="100%"></asp:TextBox> </td>
                                  <td class="tableTitle" style="width:60px;" align="center">평가방식</td>
                                  <td class="tableContent" style="width:100px;"><asp:DropDownList id="ddlBASIS_USE_YN" runat="server" width="100%" CssClass="box01"></asp:DropDownList> </td>
                                </tr>
                              </tbody>
                            </table>
                          </td>
                        </tr>
                        <tr>
                          <td style="height:200px; vertical-align:top;">
		                    <ig:UltraWebGrid ID="ugrdSelectValidationList" runat="server" Width="100%" Height="100%" >
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                                <HeaderTemplate>
                                                    <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdSelectValidationList')" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <CellTemplate>
                                                    <asp:checkbox id="cBox" runat="server" />
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
                                            <ig:UltraGridColumn BaseColumnName="EST_LEVEL" EditorControlID="" FooterText=""
                                                Format="" HeaderText="EST_LEVEL" Key="EST_LEVEL" Width="60px" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="EST_LEVEL">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header><Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                                FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" DataType="System.Int32" EditorControlID=""
                                                FooterText="" Format="" HeaderText="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="EMP_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" DataType="System.Int32" EditorControlID=""
                                                FooterText="" Format="" HeaderText="GROUP_REF_ID" Hidden="True" Key="GROUP_REF_ID">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="GROUP_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="KPI 코드">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="280px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI 명">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                Format="" HeaderText="운영조직" Key="OP_DEPT_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="운영조직">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI담당자">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부" Hidden="true">
                                              <Header Caption="사용여부">
                                                <RowLayoutColumnInfo OriginX="5" />
                                              </Header>
                                              <HeaderStyle Wrap="True" />
                                              <CellStyle HorizontalAlign="Center"></CellStyle>
                                              <CellTemplate>
                                                <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                              </CellTemplate>
                                              <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="5" />
                                              </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="APPROVAL_STATUS" Key="APPROVAL_STATUS" EditorControlID="" Width="35px" FooterText="" HeaderText="목표확정" Hidden="true">
                                              <Header Caption="확정여부">
                                                <RowLayoutColumnInfo OriginX="5" />
                                              </Header>
                                              <HeaderStyle Wrap="True" />
                                              <CellStyle HorizontalAlign="Center"></CellStyle>
                                              <CellTemplate>
                                                <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                              </CellTemplate>
                                              <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="5" />
                                              </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="BASIS_USE_YN_NAME" EditorControlID=""
                                                FooterText="" Format="" HeaderText="BASIS_USE_YN_NAME" Key="BASIS_USE_YN_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="평가방식">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" EditorControlID=""
                                                FooterText="" Format="" HeaderText="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="지표유형">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="단위">
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계" Key="RESULT_MEASUREMENT_STEP_NAME"
                                                Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="측정단계">
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="UP_EST_DEPT_ID" DataType="System.Int16" HeaderText="상위부서"
                                                Hidden="True" Key="UP_EST_DEPT_ID" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="상위부서">
                                                    <RowLayoutColumnInfo OriginX="14" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="14" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                 <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="NotSet" Name="ugrdKpiList" RowHeightDefault="20px" HeaderStyleDefault-Height="35px"
                                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                        <GroupByBox>
                                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                                        <FrameStyle BackColor="Window" Cursor="Hand" BorderColor="#E9EBEB" BorderStyle="Solid"
                                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                            Width="100%">
                                        </FrameStyle>
                                        <Pager>
                                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                        </Pager>
                                        <AddNewBox Hidden="False">
                                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                        </AddNewBox>
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
                                        <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdKpiList_DblClickHandler" />
                                    </DisplayLayout>
                            </ig:UltraWebGrid>
                          </td>
                        </tr>
                        <tr>
                          <td style="height:25px; vertical-align:top;" align="center">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                              <tr>
                                <td style="width:40%;">
                                    ↑평가자&nbsp;:&nbsp;<asp:Label ID="lblUserName" runat="server" ></asp:Label>
                                    &nbsp;<asp:ImageButton ID="iBtnCopyKpiList" runat="server" ImageUrl="../images/btn/b_134.gif" OnClientClick="return askAllCopyKPI();" OnClick="iBtnCopyKpiList_Click" />
                                </td>
                                <td style="width: 10%" align="center">
                                    <asp:ImageButton ID="iBtnAddEmp" runat="server" ImageUrl="../images/btn/btn_add_03.GIF" OnClick="iBtnAddEmp_Click" />
                                    <asp:ImageButton ID="iBtnRemoveEmp" runat="server" ImageUrl="../images/btn/btn_add_04.GIF" OnClick="iBtnRemoveEmp_Click" />
                                </td>
                                <td style="width:40%;" align="right">
                                    ↓검색지표수&nbsp;:&nbsp;<asp:Label ID="lblCntKpiTarget" runat="server"></asp:Label>&nbsp;
                                </td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                        <tr>
                          <td style="vertical-align:top;">
		                    <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" >
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                                <HeaderTemplate>
                                                    <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <CellTemplate>
                                                    <asp:checkbox id="cBox" runat="server" />
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
                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                                FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="KPI 코드">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="280px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI 명">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                Format="" HeaderText="운영조직" Key="OP_DEPT_NAME">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="운영조직">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI담당자">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부" Hidden="true">
                                              <Header Caption="사용여부">
                                                <RowLayoutColumnInfo OriginX="5" />
                                              </Header>
                                              <HeaderStyle Wrap="True" />
                                              <CellStyle HorizontalAlign="Center"></CellStyle>
                                              <CellTemplate>
                                                <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                              </CellTemplate>
                                              <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="5" />
                                              </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="APPROVAL_STATUS" Key="APPROVAL_STATUS" EditorControlID="" Width="35px" FooterText="" HeaderText="목표확정" Hidden="true">
                                              <Header Caption="확정여부">
                                                <RowLayoutColumnInfo OriginX="5" />
                                              </Header>
                                              <HeaderStyle Wrap="True" />
                                              <CellStyle HorizontalAlign="Center"></CellStyle>
                                              <CellTemplate>
                                                <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                              </CellTemplate>
                                              <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="5" />
                                              </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="BASIS_USE_YN_NAME" EditorControlID=""
                                                FooterText="" Format="" HeaderText="BASIS_USE_YN_NAME" Key="BASIS_USE_YN_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="평가방식">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" EditorControlID=""
                                                FooterText="" Format="" HeaderText="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="지표유형">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="단위">
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계" Key="RESULT_MEASUREMENT_STEP_NAME"
                                                Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="측정단계">
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="UP_EST_DEPT_ID" DataType="System.Int16" HeaderText="상위부서"
                                                Hidden="True" Key="UP_EST_DEPT_ID" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="상위부서">
                                                    <RowLayoutColumnInfo OriginX="14" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="14" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                 <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="NotSet" Name="ugrdSelectValidationList" RowHeightDefault="20px" HeaderStyleDefault-Height="35px"
                                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                        <GroupByBox>
                                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                                        <FrameStyle BackColor="Window" Cursor="Hand" BorderColor="#E9EBEB" BorderStyle="Solid"
                                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                            Width="100%">
                                        </FrameStyle>
                                        <Pager>
                                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                        </Pager>
                                        <AddNewBox Hidden="False">
                                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                        </AddNewBox>
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
                                        <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="ugrdSelectValidationList_DblClickHandler" />
                                    </DisplayLayout>
                            </ig:UltraWebGrid>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                </table>
            </td>
          </tr>
        </table>
        <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
       <!--- MAIN END --->
</asp:Content>