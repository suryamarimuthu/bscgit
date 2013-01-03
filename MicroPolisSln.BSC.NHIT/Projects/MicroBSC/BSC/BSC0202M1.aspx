<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0202M1.aspx.cs" Inherits="BSC_BSC0202M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
  <script id="Infragistics" type="text/javascript">
    function DblClickHandler(gridName, id) 
    {
        var cell     = igtbl_getElementById(id);
        var row      = igtbl_getRowById(id);
        var termID   = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var stgID    = row.getCellFromKey("STG_REF_ID").getValue();
        var stgName  = row.getCellFromKey("STG_NAME").getValue();
        
        var objStgID = document.getElementById("<%=this.hdfStgPoolId.ClientID.Replace('$', '_') %>");
        var objStgNm = document.getElementById("<%=this.txtStgPool.ClientID.Replace('$', '_') %>");
        var objTypeT = document.getElementById("<%=this.hdfITypeTree.ClientID.Replace('$', '_') %>");
        
        if (objStgID)
        {
            objStgID.value = stgID;
        }
        else
        {
            objStgID.value = "";
        }
        
        if (objStgNm)
        {
            objStgNm.value = stgName;
        }
        else
        {
            objStgNm.value = "";
        }
        
        if (objTypeT)
        {
            objTypeT.value = "A";
        }
        else
        {
            objTypeT.value = "";
        }
    }
    
    function ShowPopUp()
    {
        var objLine = window.document.getElementById("<%=divAreaPopUp.ClientID.Replace('$','_') %>");

        if (objLine != null)
        {
            if (objLine.style.display == "block")
            {
                objLine.style.display    = "none";
            }
            else
            {
                objLine.style.display    = "block";
            }
        }
        
        return false;
    }
  </script>
  <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
    <tr>
      <td style="height:20px;" valign="top">
        <table border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td class="tableTitle" style="width:80px;">평가기간</td>
                <td class="tableContent" style="width:250;">
                    <asp:dropdownlist ID="ddlEstTermInfo" runat="server" CssClass="box01" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                </td>
                <td class="tableTitle" style="width:80px;">전략관계버젼</td>
                <td class="tableContent">
                    <asp:dropdownlist ID="ddlStgTreeVersion" runat="server" CssClass="box01"></asp:dropdownlist>
                </td>
                <td align="right" class="tableContent" colspan="2" style="width:80px;">
                    <asp:imagebutton id="iBtnSearch" runat="server" imageurl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click"></asp:imagebutton>
                </td>
            </tr>
        </table>
      </td>
    </tr>
    <tr>
        <td valign="top">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" style="height:100%; border-collapse:collapse; border-style:solid;">
                <tr style="height:20px;">
                    <td style="width:25%;">
                        &nbsp;<asp:Image ID="Image1" ImageUrl="~/images/icon/subtitle.gif" runat="server" ImageAlign="AbsMiddle" />&nbsp;전략관계기본정보
                    </td>
                    <td style="width:35%;">
                        &nbsp;<asp:Image ID="Image2" ImageUrl="~/images/icon/subtitle.gif" runat="server" ImageAlign="AbsMiddle" />&nbsp;전략관계트리
                    </td>
                    <td style="width:40%;">
                        &nbsp;<asp:Image ID="Image4" ImageUrl="~/images/icon/subtitle.gif" runat="server" ImageAlign="AbsMiddle" />&nbsp;설정
                    </td>
                </tr>
                <tr>
                  <td style="vertical-align:top;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                      <tr>
                        <td style="height:20px; width:28%;" align="center" class="tableTitle">버 젼 명</td>
                        <td style="height:20px;"><asp:TextBox ID="txtVERSION_NAME" runat="server" Width="98%"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td colspan="2" style="vertical-align:top;">
                          <ig:UltraWebGrid id="ugrdTerm" runat="server" height="100%" width="100%" ImageDirectory="" OnInitializeRow="ugrdTerm_InitializeRow" >
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:TemplatedColumn BaseColumnName="APPLY_YN" Key="APPLY_YN" Width="30px">
                                                <Header Caption="적용여부"></Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderTemplate>
                                                  <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdTerm')" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <CellTemplate>
                                                    <asp:CheckBox ID="chkCheckTerm" runat="server" />
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="평가년월" Key="YMD_DESC" Width="60px">
                                                <Header Caption="평가년월"></Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="VERSION_NAME" DataType="System.String" HeaderText="VERSION_NAME"
                                                Hidden="false"  Key="VERSION_NAME" Width="135px">
                                                <Header Caption="적용전략관계 버젼명">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="true"
                                                Key="ESTTERM_REF_ID">
                                                <Header Caption="ESTTERM_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="VERSION_REF_ID" HeaderText="VERSION_REF_ID" Hidden="true"
                                                Key="VERSION_REF_ID">
                                                <Header Caption="VERSION_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Hidden="true"
                                                Key="YMD">
                                                <Header Caption="YMD">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" Version="4.00" AutoGenerateColumns="false" 
                                 HeaderClickActionDefault="NotSet" Name="ugrdTerm" BorderCollapseDefault="Separate" RowSelectorsDefault="No" ScrollBarView="Both" HeaderStyleDefault-Height="25px" 
                                 RowHeightDefault="22px" SelectTypeRowDefault="Single" JavaScriptFileName="" JavaScriptFileNameCommon="" FixedHeaderIndicatorDefault="Button" TableLayout="Fixed" 
                                 StationaryMargins="Header" >
                                    <GroupByBox Hidden="True">
                                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                        <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False">
                                        <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                        Width="100%">
                                    </FrameStyle>
                                    <Pager>
                                    <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                    </Style>
                                    </Pager>
                                    <AddNewBox>
                                    <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                     </Style>
                                    </AddNewBox>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>
                                    <FilterOptionsDefault FilterUIType="HeaderIcons">
                                    </FilterOptionsDefault>
                                    <Images ImageDirectory="">
                                    </Images>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                      </tr>
                      <tr>
                        <td colspan="2" style="height:30px;" align="right">
                            <asp:ImageButton ID="iBtnVerClear"  runat="server" ImageUrl="~/images/btn/b_005.gif" OnClick="iBtnVerClear_Click" />
                            <asp:ImageButton ID="iBtnVerInsert" runat="server" ImageUrl="~/images/btn/b_001.gif" OnClick="iBtnVerInsert_Click" />
                            <asp:ImageButton ID="iBtnVerUpdate" runat="server" ImageUrl="~/images/btn/b_002.gif" OnClick="iBtnVerUpdate_Click" />
                            <asp:ImageButton ID="iBtnVerDelete" runat="server" ImageUrl="~/images/btn/b_004.gif" OnClick="iBtnVerDelete_Click" />
                        </td>
                      </tr>
                    </table>
                  </td>
                  <td style="vertical-align:top;">
                    <asp:Panel ID="pnlStgTree" runat="server" Width="100%" Height="100%" ScrollBars="auto">
                        <asp:TreeView ID="trvStg" runat="server" ImageSet="XPFileExplorer" NodeIndent="10" ShowLines="True" OnSelectedNodeChanged="trvStg_SelectedNodeChanged">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                            <Nodes>
                              <asp:TreeNode Text="ver01" Value="1"><asp:TreeNode Text="stg01" Value="2"></asp:TreeNode> </asp:TreeNode>
                            </Nodes>
                        </asp:TreeView>
                    </asp:Panel>
                  </td>
                  <td>
                      <table border="1" cellpadding="0" cellspacing="0" width="100%" style="height:100%; border-collapse:collapse; border-style:solid;">
                        <tr>
                          <td style="height:20%;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%">
                              <colgroup width="30%" align="center"></colgroup>
                              <colgroup width="70%" align="center"></colgroup>
                              <tr>
                                <td class="tableTitle">선택된 전략명</td>
                                <td class="tableContent" align="left">
                                  <asp:TextBox ID="txtSelStg" runat="server" Width="70%" ReadOnly="true" BackColor="whitesmoke"></asp:TextBox></td>
                              </tr>
                              <tr>
                                <td class="tableTitle">상위 전략명</td>
                                <td class="tableContent" align="left">
                                  <asp:TextBox ID="txtSelStgParent" runat="server" Width="70%" ReadOnly="true" BackColor="whitesmoke"></asp:TextBox>
                                  <asp:ImageButton ID="iBtnFindParent" runat="server" ImageUrl="~/images/btn/b_034.gif" ImageAlign="absMiddle" OnClick="iBtnFindParent_Click" />
                                </td>
                              </tr>
                              <tr>
                                <td class="tableTitle">추가할 전략명</td>
                                <td class="tableContent" align="left">
                                  <asp:HiddenField ID="hdfStgPoolId" runat="server" Value="" />
                                  <asp:TextBox ID="txtStgPool" runat="server" Width="70%" ReadOnly="true" BackColor="whitesmoke"></asp:TextBox>
                                </td> 
                              </tr>
                              <tr>                               
                                <td class="tableTitle">순서</td>
                                <td class="tableContent" align="left">
                                   <ig:webnumericedit id="txtSORT_ORDER" runat="server" Width="100px" Nullable="False" ValueText="0"
                                        MaxValue="10000" MinValue="0" ToolTip="순서" NegativeForeColor="Magenta"
                                        Font-Size="10pt" Font-Names="Verdana" Height="100%" NullText="0" MinDecimalPlaces="None" >
                                    </ig:webnumericedit>
                                </td>
                              </tr>
                              <tr>
                                <td colspan="2" align="right">
                                    <asp:ImageButton ID="iBtnNodeAddBrother" runat="server" ImageUrl="~/images/btn/b_106.gif" OnClick="iBtnNodeAddBrother_Click" />
                                    <asp:ImageButton ID="iBtnNodeAddChild" runat="server" ImageUrl="~/images/btn/b_107.gif" OnClick="iBtnNodeAddChild_Click" />
                                    <asp:ImageButton ID="iBtnNodeUpdate" runat="server" ImageUrl="~/images/btn/b_002.gif" OnClick="iBtnNodeUpdate_Click" />
                                    <asp:ImageButton ID="iBtnNodeDelete" runat="server" ImageUrl="~/images/btn/b_004.gif" OnClick="iBtnNodeDelete_Click" />
                                </td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                        <tr>
                          <td style="height:20px; vertical-align:middle;">
                              &nbsp;<asp:Image ID="Image3" ImageUrl="~/images/icon/subtitle.gif" runat="server" ImageAlign="AbsMiddle" />&nbsp;전략풀
                          </td>
                        </tr>
                        <tr>
                          <td style="vertical-align:top;">
                            <ig:UltraWebGrid ID="ugrdStgList" runat="server"  Width="100%" Height="100%">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID" FooterText="" HeaderText="전략 Code"
                                                Key="STG_REF_ID" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="전략 Code">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="STG_NAME" FooterText="" HeaderText="전략명" Key="STG_NAME"
                                                Width="180px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="전략명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:TemplatedColumn BaseColumnName="CNT_STG" FooterText="" HeaderText="CNT_STG" Key="CNT_STG"
                                                Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="전략수">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                Key="ESTTERM_REF_ID">
                                                <Header Caption="ESTTERM_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                Name="ugrdStgList" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="OutlookGroupBy">
                                    <GroupByBox Hidden="True">
                                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                    ForeColor="White" HorizontalAlign="Left">
                                        <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="100%">
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
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>
                                    <ClientSideEvents DblClickHandler="DblClickHandler" />
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
  <asp:LinkButton ID="lBtnReload" runat="server" Text="" Visible="false"></asp:LinkButton>
  <asp:HiddenField ID="hdfITypeTree" runat="server" Value = "" />
  <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    <div id="divAreaPopUp" runat="server" 
         style="position:absolute; height:500px; width:300px; margin:1px; border-width:1px; display:none; border-collapse:collapse; text-align:left; background-color:#ffffff;
                top:20px; right:80px;">
      <table border="2" cellpadding="0" cellspacing="0" style="width:100%; height:100%; border-collapse:collapse;">
        <tr>
          <td style="height:25px; text-align:left; background-image:url(../images/tab/ig_tab_lightY1.gif)">
              &nbsp;<img src="../images/arrow/arrow.gif" alt="" style="vertical-align:middle;" />&nbsp;<b>상위전략 선택</b>
          </td>
        </tr>
        <tr>
          <td style="margin-top:2px;">
             <asp:Panel ID="pnlParentTree" runat="server" Width="100%" Height="100%" ScrollBars="auto">
                <asp:TreeView ID="trvStgParent" runat="server" ImageSet="XPFileExplorer" NodeIndent="10" ShowLines="True" OnSelectedNodeChanged="trvStgParent_SelectedNodeChanged">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                </asp:TreeView>
             </asp:Panel>
          </td>
        </tr>
        <tr>
          <td style="height:25px; text-align:right;">
              <img src="../images/btn/b_003.gif" alt="" onclick="ShowPopUp();" style="cursor:hand; vertical-align:top;" />
          </td>
        </tr>
      </table>
    </div>
</asp:Content>
