<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0602M1.aspx.cs" Inherits="BSC_BSC0602M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<!--- MAIN START --->	

   <script id="Infragistics" type="text/javascript">
        function OpenDiCodeList()
        {
            var strObjKey   = "<%= this.txtDiCode.ClientID.Replace('_', '$') %>";
            var strObjVal   = "<%= this.txtDiName.ClientID.Replace('_', '$') %>";
            var CCB1        = "<%= this.ICCB1 %>";
            
            var url         = "BSC0601S2.aspx?iType=P&OBJ_KEY="+strObjKey+"&OBJ_VAL="+strObjVal+"&CCB1="+CCB1;
            
            gfOpenWindow(url, 850, 550, 'yes', 'no', 'BSC0601S2');
            
            return false;
        }
        
        function ProhibitKey(objEntity)
        {
            if (event.keyCode == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
  </script>
   <asp:HiddenField ID="hdfCurObj" runat="server" Value="" />
   <table width="100%" cellpadding="0" cellspacing="0" style="height:100%" border="0">
     <tr style="height:100%;">
       <td style="width:30%">
         <table width="100%" cellpadding="0" cellspacing="0" style="height:100%">
           <tr style="height:20px;">
             <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                       <td>
                         <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                         <td>지표정보</td>
                       </td>
                    </tr>
                </table>
             </td>
           </tr>
           <tr>
             <td style="height:40px;">
                 <table width="100%" cellpadding="0" cellspacing="0" style="height:100%" class="tableBorder">
                   <tr>
                     <td style="width:30%;" class="cssTblTitle">평가기간</td>
                     <td style="width:70%;" class="cssTblContent">
                       <asp:dropdownlist id="ddlEstTermInfo" CssClass="box01" runat="server" width="100%" ></asp:dropdownlist>
                     </td>
                   </tr>
                   <tr>
                     <td style="width:30%;" class="cssTblTitle">운영부서</td>
                     <td style="width:70%;" class="cssTblContent"><asp:dropdownlist id="ddlEstDept" runat="server" CssClass="box01" width="100%"></asp:dropdownlist></td>
                   </tr>
                   <tr>
                     <td style="width:30%;" class="cssTblTitle">지표CODE</td>
                     <td style="width:70%;" class="cssTblContent"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>
                   </tr>
                   <tr>
                     <td style="width:30%;" class="cssTblTitle">지표명</td>
                     <td style="width:70%;" class="cssTblContent"><asp:TextBox id="txtKPIName" runat="server" width="100%"></asp:TextBox></td>
                   </tr>
                   <tr>
                     <td style="width:30%;" class="cssTblTitle"><%=GetText("LBL_00001", "챔피언") %></td>
                     <td style="width:70%;" class="cssTblContent"><asp:TextBox id="txtChamName" runat="server" width="100%"></asp:TextBox></td>
                   </tr>
                   <tr>
                     <td style="width:30%;" class="cssTblTitle">쿼리설정</td>
                     <td style="width:70%;" class="cssTblContent">
                       <asp:DropDownList ID="ddlIS_SET_QUERY" runat="server" ></asp:DropDownList>
                     </td>
                   </tr>
                   <tr>
                     <td colspan="4" align="right" style="padding-right:5px; padding-bottom:5px;">
                        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                     </td>
                   </tr>
                 </table>
             </td>
           </tr>
           <tr>
             <td>
                 <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnClick="ugrdKpiList_Click" OnInitializeRow="ugrdKpiList_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
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
                                <ig:TemplatedColumn BaseColumnName="IS_SET_QUERY" Key="IS_SET_QUERY" EditorControlID="" Width="35px" FooterText="" HeaderText="IS_SET_QUERY">
                                  <Header Caption="설정여부">
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
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="40px">
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
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="200px">
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
                                    Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="100px">
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
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="50px">
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
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
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
                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부">
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
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID="" Width="35px" FooterText="" HeaderText="APP_STATUS">
                                  <Header Caption="결재상태">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Header>
                                  <HeaderStyle Wrap="True" />
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgApp" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                  <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Footer>
                                </ig:TemplatedColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="SortMulti" Name="ugrdKpiList" RowHeightDefault="20px"
                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
                            OptimizeCSSClassNamesOutput="False">
                        <%--
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="2px" />
                        </RowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
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
                        </SelectedRowStyleDefault>--%>
                        <GroupByBox>
                            <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                        <ClientSideEvents RowSelectorClickHandler="RowSelectorClickHandler" DblClickHandler="ugrdKpiResultList_DblClickHandler"/>
                    </DisplayLayout>
                  </ig:UltraWebGrid>
             </td>
           </tr>
         </table>
       </td>
       <td>
            <table width="100%" cellpadding="0" cellspacing="0" style="height:100%;">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width:15px;"><img src="../images/title/ma_t14.gif" alt="" /></td>
                                <td>Data Interface Code 상세정보</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0" style="height:100%" class="tableBorder">
                           <tr>
                             <td class="cssTblTitle">지표코드</td>
                             <td class="cssTblContent">
                                <asp:Label ID="lblKpiCode" runat="server" Width="100%"></asp:Label>
                             </td>
                             <td class="cssTblTitle">지표명</td>
                             <td class="cssTblContent">
                                <asp:Label ID="lblKpiName" runat="server" Width="100%"></asp:Label>
                             </td>
                           </tr>
                           <tr>
                             <td class="cssTblTitle">당월산식</td>
                             <td class="cssTblContent">
                               <asp:TextBox ID="txtCalcFormMs" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:TextBox>
                             </td>
                             <td class="cssTblTitle">누계산식</td>
                             <td class="cssTblContent">
                               <asp:TextBox ID="txtCalcFormTs" runat="server" Height="40px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                             </td>
                           </tr>
                           <tr>
                             <td class="cssTblTitle">DICODE</td>
                             <td class="cssTblContent">
                                <asp:TextBox ID="txtDiCode" runat="server" Width="100%"></asp:TextBox>
                             </td>
                             <td class="cssTblTitle">DICODE명</td>
                             <td class="cssTblContent">
                                <asp:TextBox ID="txtDiName" runat="server" Width="100%"></asp:TextBox>
                             </td>
                           </tr>
                         </table>
                    </td>
                </tr>
                <tr class="cssPopBtnLine">
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                                <td style="width:60px;">산식구분</td>
                                <td>
                                    <asp:RadioButtonList ID="rdoTermType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdoTermType_SelectedIndexChanged">
                                        <asp:ListItem Enabled="true" Selected="false" Text="지표조건식" Value="SS"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Selected="true" Text="당월산식" Value="MS"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Selected="false" Text="누적산식" Value="TS"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Selected="false" Text="산식검증" Value="QR"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right">
                                   <asp:ImageButton ID = "iBtnDicodeList" runat="server" ImageUrl="../images/btn/b_034.gif" OnClientClick="return OpenDiCodeList();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height:100%;">
                    <td style="vertical-align:top">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block" UpdateMode="always">
                         <ContentTemplate>
                             <asp:Panel ID="pnlOperator" runat="server" Height="318px">
                               <table width="100%" cellpadding="0" cellspacing="0" style="height:100%" class="tableBorder">
                                 <tr style="height:100%;">
                                   <td style="margin-left:5px;">
                                       <table border="1" cellpadding="0" cellspacing="0" style="width:100%; height:100%">
                                         <tr style="height:50%;">
                                           <th style="width:22px; text-align:center; height:100px;"><asp:RadioButton ID="rdoField" runat="server" AutoPostBack="True" OnCheckedChanged="rdoField_CheckedChanged" Checked="false" /><br />계<br />산<br />식</th>
                                           <td style="width:100px;">
                                               <asp:ListBox ID="lstListField" CssClass="box01" runat="server" Height="100%" Width="100%" SelectionMode="Single" Visible="false"></asp:ListBox>
                                               <asp:ListBox ID="lstField" CssClass="box01" runat="server" Height="100%" Width="100%" SelectionMode="Single" AutoPostBack="True" OnSelectedIndexChanged="lstField_SelectedIndexChanged"></asp:ListBox>
                                           </td>
                                           <td rowspan="2" style="width:120px; vertical-align:top;" align="center">
                                               <table border="0" cellpadding="0" cellspacing="1" width="100%">
                                                 <tr>
                                                   <td align="left" style="margin-left:2px; margin-top:2px;">
                                                       <asp:Button ID="btnD6" runat="server" Text="6" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnD7" runat="server" Text="7" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnD8" runat="server" Text="8" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnD9" runat="server" Text="9" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr>
                                                   <td align="left" style="margin-left:2px;">
                                                       <asp:Button ID="btnD5" runat="server" Text="5" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnD4" runat="server" Text="4" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnD3" runat="server" Text="3" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnD2" runat="server" Text="2" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr>
                                                   <td align="left" style="margin-left:2px;">
                                                       <asp:Button ID="btnD1" runat="server" Text="1" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnD0" runat="server" Text="0" CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnPoint" runat="server" Text="." CssClass="clacB" OnClick="OperatorButton_Click" />
                                                       <asp:Button ID="btnComma" runat="server" Text="," CssClass="clacB" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr><td style="height:5px;"></td></tr>
                                                 <tr>
                                                   <td align="left" style="margin-left:2px;">
                                                      <asp:Button ID="btnPlus" runat="server" Text="+" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnMinus" runat="server" Text="-" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnMultiply" runat="server" Text="*" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnDivision" runat="server" Text="/" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr>
                                                   <td align="left" style="margin-left:2px;">
                                                      <asp:Button ID="btnLeftBR" runat="server" Text="(" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnRightBR" runat="server" Text=")" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnQtaMark" runat="server" Text="'" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnConcat" runat="server" Text="||" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr><td style="height:5px;"></td></tr>
                                                 <tr>
                                                   <td align="left" style="margin-left:2px;">
                                                      <asp:Button ID="btnSum" runat="server" Text="SUM" CssClass="clac" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnAbs" runat="server" Text="ABS" CssClass="clac" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnAvg" runat="server" Text="AVG" CssClass="clac" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr>
                                                   <td align="left" style="margin-left:2px;">
                                                      <asp:Button ID="btnMax" runat="server" Text="MAX" CssClass="clac" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnMin" runat="server" Text="MIN" CssClass="clac" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnCount" runat="server" Text="CNT" CssClass="clac" OnClick="OperatorButton_Click" />
                                                 </tr>
                                                 <tr>
                                                   <td align="left" style="margin-left:2px;">
                                                      <asp:Button ID="btnRound" runat="server" Text="Round" CssClass="clacSM" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnTrunc" runat="server" Text="Trunc" CssClass="clacSM" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr><td style="height:10px;"></td></tr>
                                                 <tr>
                                                   <td align="left" style="margin-left:2px;">
                                                      <asp:Button ID="btnAnd" runat="server" Text="AND" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnOR" runat="server" Text="OR" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnEqual" runat="server" Text="=" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnNotEqual" runat="server" Text="!=" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr>
                                                   <td>
                                                      <asp:Button ID="btnLT" runat="server" Text="<" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnGT" runat="server" Text=">" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnLessThen" runat="server" Text="&lt;=" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnMoreThen" runat="server" Text="&gt;=" CssClass="clacS" OnClick="OperatorButton_Click" />                                  
                                                   </td>
                                                 </tr>
                                                 <tr>
                                                   <td>
                                                      <asp:Button ID="btnLike" runat="server" Text="Like" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnPercent" runat="server" Text="%" CssClass="clacS" OnClick="OperatorButton_Click" />
                                                      <asp:Button ID="btnBetween" runat="server" Text="Between" CssClass="clacSM" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                                 <tr>
                                                   <td>
                                                      <asp:TextBox ID="txtConstant" runat="server" Text="" Width="60%"></asp:TextBox>
                                                      <asp:Button ID="btnEnter" runat="server" Text="Ent." CssClass="clacS" OnClick="OperatorButton_Click" />
                                                   </td>
                                                 </tr>
                                               </table>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtField_Ms" runat="server" TextMode="MultiLine" Height="100%" Width="100%" BackColor="whitesmoke"></asp:TextBox>
                                               <asp:TextBox ID="txtField_Ts" runat="server" TextMode="MultiLine" Height="100%" Width="100%" BackColor="whitesmoke" Visible="true"></asp:TextBox>
                                               <asp:TextBox ID="txtField_Ss" runat="server" TextMode="MultiLine" Height="100%" Width="100%" BackColor="whitesmoke" Visible="false" ReadOnly="true"></asp:TextBox>
                                           </td>
                                         </tr>
                                         <tr style="height:50%;">
                                           <th style="text-align:center; height:100px;"><asp:RadioButton ID="rdoCondition" runat="server" AutoPostBack="True" OnCheckedChanged="rdoCondition_CheckedChanged" Checked="false" /><br />조<br />건<br />식</th>
                                           <td>
                                               <asp:ListBox ID="lstCondition" CssClass="box01" runat="server" Height="100%" Width="100%" SelectionMode="Single" AutoPostBack="True" OnSelectedIndexChanged="lstCondition_SelectedIndexChanged"></asp:ListBox>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtCondition_Ms" runat="server" TextMode="MultiLine" Height="100%" Width="100%" BackColor="whitesmoke"></asp:TextBox>
                                               <asp:TextBox ID="txtCondition_Ts" runat="server" TextMode="MultiLine" Height="100%" Width="100%" BackColor="whitesmoke" Visible="true"></asp:TextBox>
                                               <asp:TextBox ID="txtCondition_SS" runat="server" TextMode="MultiLine" Height="100%" Width="100%" BackColor="whitesmoke" Visible="true"></asp:TextBox>
                                           </td>
                                         </tr>
                                       </table>
                                   </td>
                                 </tr>
                               </table>
                             </asp:Panel>
                             <asp:Panel ID="pnlQuery" runat="server" Visible="false">
                               <table width="100%" cellpadding="0" cellspacing="0" style="height:100%" class="tableBorder">
                                 <tr>
                                   <td style="width:33%; height:25px;">리스트</td>
                                   <td style="width:33%">당월</td>
                                   <td style="width:34%">누계</td>
                                 </tr>
                                 <tr>
                                   <td><asp:TextBox runat="server" ID="txtQUERY_AL" TextMode="multiLine" Width="100%" Height="100%"></asp:TextBox></td>
                                   <td><asp:TextBox runat="server" ID="txtQUERY_MS" TextMode="multiLine" Width="100%" Height="100%"></asp:TextBox></td>
                                   <td><asp:TextBox runat="server" ID="txtQUERY_TS" TextMode="multiLine" Width="100%" Height="100%"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                   <td style="height:25px;"><asp:Label ID="lblSuccessAl" runat="server" Width="100%" ></asp:Label></td>
                                   <td><asp:Label ID="lblSuccessMs" runat="server" Width="100%" ></asp:Label></td>
                                   <td><asp:Label ID="lblSuccessTs" runat="server" Width="100%" ></asp:Label></td>
                                 </tr>
                               </table>
                             </asp:Panel>
                         </ContentTemplate>         
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
       </td>
     </tr>
    
     <tr class="cssPopBtnLine">
       <td colspan="2" style="margin-left:5px;" align="right">
         <asp:ImageButton ID="iBtnClear" runat="server" ImageUrl="~/images/btn/b_075.gif" OnClick="iBtnClear_Click" />
         <asp:ImageButton ID="iBtnInsert" ImageUrl="~/images/btn/b_001.gif" runat="server" OnClick="iBtnInsert_Click"  />
         <asp:ImageButton ID="iBtnUpdate" ImageUrl="~/images/btn/b_002.gif" runat="server" OnClick="iBtnUpdate_Click"  />
         <asp:ImageButton ID="iBtnDelete" ImageUrl="~/images/btn/b_208.gif" runat="server" OnClick="iBtnDelete_Click"  />
         <asp:ImageButton ID="iBtnReUse" ImageUrl="~/images/btn/b_138.gif" runat="server" OnClick="iBtnReUse_Click"  />
       </td>
     </tr>
   </table>
   <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
   <asp:LinkButton ID="lBtnReload" runat="server" Visible="false" OnClick="lBtnReload_Click"></asp:LinkButton>
<!--- MAIN END --->
</asp:Content>
