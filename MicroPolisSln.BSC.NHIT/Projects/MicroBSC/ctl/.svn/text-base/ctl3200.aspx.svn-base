<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl3200.aspx.cs" Inherits="ctl3200" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

   <script id="igClientScript" type="text/javascript">
    function UltraWebGrid1_MouseOverHandler(gridName, id, objectType)
    {
        if(objectType == 0) 
        { 
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);
           cell.style.cursor    = 'hand';
        }
    }
    
    var param1 = false;
    function selectChkBox(chkChild)
    {
        var _elements   = document.forms[0].elements;
        
        for (var i = 0; i < _elements.length; i++)
        {
            //_elements[i].id.indexOf(chkChild) >= 0 && -- 이건 무슨조건일까요?
            if (_elements[i].type=="checkbox")
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

        return false;
    }
    
   </script>

  <!--- MAIN START --->
    <table cellpadding="0" cellspacing="2" height="100%" width="100%">
            <tr>
                <td class="cssTblTitle" style="width:180px; text-align:center;">인사부서</td>
                <td class="cssTblTitle" style="width:100%; text-align:center;">사원리스트</td>
                <td class="cssTblTitle" style="width:180px; text-align:center; vertical-align:text-bottom;">
                   <asp:ImageButton ID="iBtnCheck" runat="server" ImageUrl="../images/checkbox.gif" ImageAlign="middle" />&nbsp;평가부서
                </td>
            </tr>
            <tr style="height:100%;">
                <td valign="top">
                    <div id="Div1" style="border:#F4F4F4 1 solid; DISPLAY:block; overflow: auto; 
                        width: 200px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px ">
                        &nbsp;&nbsp;
                        <asp:TreeView ID="TreeView2" runat="server" OnSelectedNodeChanged="TreeView2_SelectedNodeChanged" ImageSet="XPFileExplorer" NodeIndent="15">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                </div>
                    <SJ:SmartScroller id="SmartScroller1" runat="server" MaintainScrollY="true" MaintainScrollX="true" TargetObject="Div1"></SJ:SmartScroller>
                </td>
                <td valign="top">
                <ig:ultrawebgrid    id="UltraWebGrid1" runat="server" 
                                    width="100%" 
                                    Height="100%" 
                                    OnInitializeRow="UltraWebGrid1_InitializeRow" 
                                    style="left: 524px; top: -38px;" 
                                    OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" HeaderText="로그인ID" Key="EMP_REF_ID" Hidden="true">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <HeaderStyle  HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" ></CellStyle>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="LOGINID" EditorControlID="" FooterText=""
                                    Format="" FormulaErrorValue="" HeaderText="로그인ID" Key="LOGINID" Width="60px" Hidden="true">
                                    <Header Caption="로그인ID" Title="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <HeaderStyle  HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" ></CellStyle>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" FormulaErrorValue="" HeaderText="부서" Key="DEPT_NAME" Width="150px">
                                    <Header Caption="부서" Title="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <HeaderStyle  HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" ></CellStyle>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID="" FooterText=""
                                    Format="" FormulaErrorValue="" HeaderText="성명" Key="EMP_NAME" Width="80px">
                                    <Header Caption="성명" Title="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <HeaderStyle  HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" ></CellStyle>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:ULTRAGRIDCOLUMN basecolumnname="DEPT_REF_ID" hidden="True" editorcontrolid="" footertext="" format="" formulaerrorvalue="" headertext="부서" key="DEPT_REF_ID" width="80px">
                                    <HEADER caption="부서" title="">
                                        <ROWLAYOUTCOLUMNINFO originx="4" />
                                    </HEADER>
                                    <HEADERSTYLE horizontalalign="Center" />
                                    <CELLSTYLE horizontalalign="Center"></CELLSTYLE>
                                    <FOOTER caption="" title="">
                                        <ROWLAYOUTCOLUMNINFO originx="4" />
                                    </FOOTER>
                                </ig:ULTRAGRIDCOLUMN>
                                <ig:UltraGridColumn BaseColumnName="POSITION_duty_NAME" EditorControlID="" FooterText=""
                                    Format="" FormulaErrorValue="" HeaderText="직책" Key="POSITION_duty_NAME" Width="40px">
                                    <Header Caption="직책" Title="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <HeaderStyle  HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" ></CellStyle>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" HeaderText="직위" Key="POSITION_RANK_NAME" Width="40px">
                                    <Header Caption="직위">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <HeaderStyle  HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" ></CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" HeaderText="직급" Key="POSITION_CLASS_NAME" Width="40px">
                                    <Header Caption="직급">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <HeaderStyle  HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" ></CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POSITION_GRP_NAME" HeaderText="직군" Key="POSITION_GRP_NAME" Width="40px">
                                    <Header Caption="직군">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <HeaderStyle  HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" ></CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>

                    <DisplayLayout CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="NotSet" 
                                    Name="UltraWebGrid1" 
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
                                    OptimizeCSSClassNamesOutput="False">
                    <%--    <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt">
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Font-Bold="False" Font-Italic="False">
                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                            BorderWidth="1px" Font-Names="Arial" Font-Size="8pt" Height="100%"
                            Width="100%" Font-Bold="False">
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
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>--%>
                        <ClientSideEvents MouseOverHandler="UltraWebGrid1_MouseOverHandler" />
                        
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                </DisplayLayout>
                </ig:ultrawebgrid></td>
                <td valign="top">
                    <div id="leftLayer" style="border:#F4F4F4 1 solid; DISPLAY:block; overflow: auto; 
                        width: 200px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px ">
                        &nbsp;&nbsp;
                        <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" ShowCheckBoxes="All">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                        &nbsp;
                </div>
                    <SJ:SmartScroller id="SmartScroller2" runat="server" MaintainScrollY="true" MaintainScrollX="true" TargetObject="leftLayer"></SJ:SmartScroller>
                </td>
            </tr>
            <tr class="cssPopBtnLine">
                <td></td>
                <td height="40" align="right">
                    <asp:Literal ID="ltrScript" runat="server"></asp:Literal><asp:HiddenField ID="hdfEmpRefID" runat="server" />
                </td>
                <td align="right">
                    <asp:ImageButton ID="iBtnAdd" runat="server" align="absmiddle" ImageUrl="../images/btn/b_007.gif" OnClick="iBtnAdd_Click" Visible="False" />
                </td>
                <%--<td align="right">
                    fdsa</td>--%>
            </tr>
        </table>
        <!--- MAIN END --->

</asp:Content>