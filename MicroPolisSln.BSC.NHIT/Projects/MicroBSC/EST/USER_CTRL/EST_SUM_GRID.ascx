<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EST_SUM_GRID.ascx.cs" Inherits="EST_USER_CTRL_EST_SUM_GRID" %>
<asp:Literal ID="ltrJScript" runat="server"></asp:Literal>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td height="30">
            <asp:Image ID="imgTitle" runat="server" ImageAlign="AbsMiddle" /> <asp:Label ID="lblTitle" runat="server" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    <%--<tr>
        <td height="20">
            <img src='../images/title/ta_t40.gif' border="0" />
        </td>
    </tr>--%>
</table>
<asp:GridView ID="GridView1" runat="server"></asp:GridView>
<ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="80%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
    <Bands>
        <ig:UltraGridBand>
            <AddNewRow View="NotSet" Visible="NotSet">
            </AddNewRow>
            <Columns>
                <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="True">
                </ig:UltraGridColumn>
                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="180px" HeaderText="부서명">
                    <Header Caption="부서명">
                        <RowLayoutColumnInfo OriginX="0" OriginY="0" SpanY="2" />
                    </Header>
                    <HeaderStyle HorizontalAlign="Center" />
                    <CellStyle HorizontalAlign="Left"/>
                </ig:UltraGridColumn>
            </Columns>
            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
            </RowTemplateStyle>
        </ig:UltraGridBand>
    </Bands>
    <DisplayLayout  CellPaddingDefault="2" 
                    AllowColSizingDefault="Free" 
                    AllowDeleteDefault="Yes"
                    AllowSortingDefault="NotSet" 
                    BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="NotSet" 
                    Name="ctl00xUltraWebGrid1" 
                    RowHeightDefault="20px"
                    RowSelectorsDefault="No" 
                    SelectTypeRowDefault="Extended" 
                    Version="4.00" 
                    CellClickActionDefault="RowSelect" 
                    TableLayout="Fixed" 
                    StationaryMargins="Header" 
                    AutoGenerateColumns="False"
                    OptimizeCSSClassNamesOutput="False"
                    ReadOnly="LevelTwo">
            <%--<GroupByBox>
                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
            </GroupByBox>
            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
            </GroupByRowStyleDefault>
            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                <BorderDetails ColorTop="White" WidthTop="1px" />
            </FooterStyleDefault>
            <RowAlternateStyleDefault BackColor="#F9F9F7">
                <BorderDetails  ColorLeft="249, 249, 247" ColorTop="249, 249, 247" />
            </RowAlternateStyleDefault>
            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                <Padding Left="3px" />
            </RowStyleDefault>
            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
            </HeaderStyleDefault>
            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
            </EditCellStyleDefault>
            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt"
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
            </AddNewBox>--%>
            <RowStyleDefault  CssClass="GridRowStyle" />
            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
            <FrameStyle CssClass="GridFrameStyle" Width="100%"></FrameStyle>
            <Images>
                <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
            </Images>
        </DisplayLayout>
</ig:UltraWebGrid>
<table width="100%" cellpadding="0" cellspacing="0" border="0" style="display:none">
    <tr>
        <td>
            <br />
            <img src='../images/title/ta_t03-1.gif' border="0" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtProblem" runat="server" TextMode="MultiLine" Height="60" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td height="5">
        </td>
    </tr>
    <tr>
        <td>
            <img src='../images/title/ta_t04-1.gif' border="0" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtSolution" runat="server" TextMode="MultiLine" Height="60" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td height="40" align="right">
            <%--<asp:ImageButton ID="ibnSave" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_tp07.gif" />--%>
            <a href='#null' onclick="return confirm('해당평가의 결과분석 및 개선방향의 코멘트를 저장하시겠습니까?');"><img src='../images/btn/b_tp07.gif' border="0" /></a> 
            &nbsp;
        </td>
    </tr>
</table>
<br />
