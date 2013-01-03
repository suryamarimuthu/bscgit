<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0801M1.aspx.cs" Inherits="BSC_BSC0801M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

       <!--- MAIN START --->
       
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
          <tr style="height:25px;">
            <td style="width:200px;"><b>평가그룹</b></td>
            <td style="width:220px;"><b>조직트리</b></td>
            <td>
                 <b>그 룹 명:</b> <asp:Label ID="lblEstGroupName" runat="server" Text="" Width="150px"></asp:Label>
                 <b>평가기간:</b> <asp:DropDownList ID="ddlEstTerm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged" CssClass="box01"></asp:DropDownList>
            </td>
          </tr>
          <tr >
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                  <tr>
                    <td style="width:200px;" valign="top">
                            <ig:UltraWebGrid ID="ugrdValuationGrid" runat="server" Height="100%" Width="100%" OnActiveRowChange="ugrdValuationGrid_ActiveRowChange">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" HeaderText="GROUP_REF_ID" Key="GROUP_REF_ID" Width="58px" Hidden="true">
                                                <CellStyle VerticalAlign="Top" />
                                                <HEADER caption="GROUP_REF_ID">
                                                </HEADER>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </ig:UltraGridColumn>                                            
                                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue="" BaseColumnName="GROUP_NAME"
                                                HeaderText="GROUP_NAME" Key="GROUP_NAME" Width="140px">
                                                <Header Caption="그룹명" Title="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CELLSTYLE horizontalalign="Left" verticalalign="Middle"></CELLSTYLE>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" FormulaErrorValue="" BaseColumnName = "USE_YN"
                                                HeaderText="USE_YN" Key="USE_YN" Width="37px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <Header Caption="USE" Title="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CELLSTYLE horizontalalign="Center" verticalalign="Middle"></CELLSTYLE>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="NotSet"
                                    Name="ugrdValuationGrid" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                    Version="4.00" CellClickActionDefault="RowSelect">
                                    <GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="0px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                        ForeColor="White" Height="30px" HorizontalAlign="Left">
                                        <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" Cursor="Hand" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="0px"
                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                                    </FrameStyle>
                                    <Pager>
                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </PagerStyle>
                                    </Pager>
                                    <AddNewBox Hidden="False" Prompt="행추가">
                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </BoxStyle>
                                        <ButtonStyle BorderStyle="Outset" Cursor="Hand" Height="20px" Width="20px">
                                        </ButtonStyle>
                                    </AddNewBox>
                                    <AddNewRowDefault>
                                        <RowStyle BackColor="#FFC0C0" BorderColor="#FFE0C0" BorderStyle="Solid" BorderWidth="1px"
                                            ForeColor="Blue"></RowStyle>
                                    </AddNewRowDefault>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                    </td>
                  </tr>
                  <tr style="height:50px;">
                    <td style="vertical-align:bottom;">
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;" class="tableBorder">
                          <tr style="height:25px;">
                            <td align="left" class="tableTitle">그&nbsp;룹&nbsp;명</td>
                            <td class="tableContent">
                                <asp:HiddenField ID="hdfGroupRefID" runat="server" Value="" />
                                <asp:textbox id="txtGroupName" runat="server"></asp:textbox>
                            </td>
                          </tr>
                          <tr style="height:25px;">
                            <td align="left" class="tableTitle" style="height: 19px">사용여부</td>
                            <td class="tableContent" style="height: 19px">
                                <asp:checkbox id="chkUseYn" runat="server"></asp:checkbox>
                            </td>
                          </tr>
                          <tr style="height:40px;" align="right">
                            <td colspan="2" style="vertical-align:middle;">
                              <asp:ImageButton ID="iBtnAddGroup" runat="server" ImageUrl="../images/btn/b_001.gif" OnClick="iBtnAddGroup_Click" />
                              <asp:ImageButton ID="iBtnClrGroup" runat="server" ImageUrl="../images/btn/b_075.gif" OnClick="iBtnClrGroup_Click" />
                            </td>
                          </tr>
                        </table>
                    </td>
                  </tr>
                </table>
            </td>
            <td style="vertical-align:top;">
                <div style="border:#F4F4F4 3px solid; overflow: auto; width:219px; height: 100%;">
                    <asp:TreeView ID="trvComDept" runat="server" OnSelectedNodeChanged="trvComDept_SelectedNodeChanged" ImageSet="XPFileExplorer" NodeIndent="10" ShowLines="True">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                    </div>
            </td>
            <td style="vertical-align:top;">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                  <tr>
                    <td style="vertical-align:top; height:200px;">
                            <ig:ultrawebgrid id="ugrdSelectedGrid" runat="server" width="100%" Height="100%" style="left: 0px"><Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <Columns>
                                    <ig:TemplatedColumn Key="selchk" Width="30px">
                                <CellTemplate>
                                    <asp:CheckBox ID="cBox" runat="server" />
                                </CellTemplate>
                                </ig:TemplatedColumn>
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                            Format="" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Width="60px" Hidden="true">
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
                                            Format="" HeaderText="사원번호" Key="EMP_REF_ID" Width="60px">
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
                                            Format="" HeaderText="로그인ID" Key="LOGINID" Width="60px">
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
                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="80px" FooterText="" HeaderText="이름">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="이름">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="USE_YN" EditorControlID="" FooterText=""
                                            Format="" HeaderText="USE_YN" Key="USE_YN" Width="50px">
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
                                <DisplayLayout ViewType="Flat" Version="4.00" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" 
                                               HeaderClickActionDefault="SortMulti" Name="ugrdSelectedGrid" BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" 
                                               RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" 
                                               AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" 
                                               StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed" JavaScriptFileName="" JavaScriptFileNameCommon="" 
                                               AllowUpdateDefault="Yes">
                                    <GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </PagerStyle>
                                    </Pager>
                                    <AddNewBox Hidden="False">
                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </BoxStyle>
                                    </AddNewBox>
                                </DisplayLayout>
                            </ig:ultrawebgrid>
                    </td>
                  </tr>
                  <tr style="height:25px;">
                    <td align="center" valign="baseline">
                        <asp:ImageButton ID="iBtnAddEmp" runat="server" ImageUrl="../images/btn/btn_add_03.GIF" OnClick="iBtnAddEmp_Click" />
                        <asp:ImageButton ID="iBtnRemoveEmp" runat="server" ImageUrl="../images/btn/btn_add_04.GIF" OnClick="iBtnRemoveEmp_Click" />&nbsp;
                    </td>
                  </tr>
                  <tr>
                    <td>
                            <ig:ultrawebgrid id="ugrdTargetGrid" runat="server" width="100%" Height="100%" style="left: 0px"><Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <Columns>
                                    <ig:TemplatedColumn Key="selchk" Width="30px">
                                <CellTemplate>
                                    <asp:CheckBox ID="cBox" runat="server" />
                                </CellTemplate>
                                </ig:TemplatedColumn>
                                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                            Format="" HeaderText="사원번호" Key="EMP_REF_ID" Width="60px">
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
                                            Format="" HeaderText="로그인ID" Key="LOGINID" Width="60px">
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
                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="60px" FooterText="" HeaderText="이름">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="이름">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EMP_EMAIL" EditorControlID="" FooterText=""
                                            Format="" HeaderText="이메일" Key="EMP_EMAIL" Width="180px" Hidden="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="이메일">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" EditorControlID="" FooterText=""
                                            Format="" HeaderText="직책" Key="POSITION_CLASS_NAME" Width="50px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="직책">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POSITION_GRP_NAME" EditorControlID="" FooterText=""
                                            Format="" HeaderText="직군" Key="POSITION_GRP_NAME" Width="50px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="직군">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" EditorControlID="" FooterText=""
                                            Format="" HeaderText="직급" Key="POSITION_RANK_NAME" Width="50px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="직급">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POSITION_DUTY_NAME" EditorControlID="" FooterText=""
                                            Format="" HeaderText="직위" Key="POSITION_DUTY_NAME" Width="50px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="직위">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Header>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                                <DisplayLayout ViewType="Flat" Version="4.00" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" 
                                               HeaderClickActionDefault="SortMulti" Name="ugrdTargetGrid" BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" 
                                               RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" 
                                               AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" 
                                               StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed" JavaScriptFileName="" JavaScriptFileNameCommon="" 
                                               AllowUpdateDefault="Yes">
                                    <GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </PagerStyle>
                                    </Pager>
                                    <AddNewBox Hidden="False">
                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </BoxStyle>
                                    </AddNewBox>
                                </DisplayLayout>
                            </ig:ultrawebgrid>
                    </td>
                  </tr>
                </table>
            </td>
          </tr>
        </table>
        <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
       <!--- MAIN END --->
</asp:Content>