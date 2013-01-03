<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl1114.aspx.cs" Inherits="ctl_ctl1114" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
<script  type="text/javascript">
function MouseOverHandler(gridName, id, objectType)
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
</script>
        <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
            <tr>
                <td colspan="2" valign="middle">
                    <img alt="" style="vertical-align:middle;" src="../images/title/se_ti01.gif" />
                    <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width:280px; height:90%;">
                    <ig:UltraWebGrid ID="ugrdKpiGroup" runat="server" Height="100%" Width="100%" OnInitializeRow="ugrdKpiGroup_InitializeRow">
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <Columns>
                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="평가기간코드" Key="ESTTERM_REF_ID" Width="38px" Hidden="True">
                                        <Header Caption="평가기간코드">
                                        </Header>
                                        <HeaderStyle Wrap="True" />
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_REF_ID" HeaderText="지표군 CODE"
                                        Key="KPI_GROUP_REF_ID" Type="Custom" Width="100px">
                                        <Header Caption="지표군 CODE">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <CellStyle BackColor="whitesmoke"></CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표군명"
                                        Key="KPI_GROUP_NAME" Type="Custom" Width="150px">
                                        <Header Caption="지표군명">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <CellStyle BackColor="whitesmoke"></CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:TemplatedColumn BaseColumnName="NORMDIST_USE_YN" Key="NORMDIST_USE_YN" EditorControlID="" Width="60px" FooterText="" HeaderText="누적확률사용여부" Hidden="true">
                                      <Header Caption="누적확률사용여부">
                                        <RowLayoutColumnInfo OriginX="3" />
                                      </Header>
                                      <HeaderStyle Wrap="True" />
                                      <CellStyle HorizontalAlign="Center"></CellStyle>
                                      <CellTemplate>
                                        <asp:checkbox runat="server" id="chkUse" ></asp:checkbox>
                                      </CellTemplate>
                                      <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                      </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:TemplatedColumn BaseColumnName="MULTI_EST_USE_YN" Key="MULTI_EST_USE_YN" EditorControlID="" Width="60px" FooterText="" HeaderText="다차수평가사용여부" Hidden="true">
                                      <Header Caption="다차수평가사용여부">
                                        <RowLayoutColumnInfo OriginX="4" />
                                      </Header>
                                      <HeaderStyle Wrap="True" />
                                      <CellStyle HorizontalAlign="Center"></CellStyle>
                                      <CellTemplate>
                                        <asp:checkbox runat="server" id="chkUse" ></asp:checkbox>
                                      </CellTemplate>
                                      <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                      </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:UltraGridColumn BaseColumnName="DESCRIPTINS" HeaderText="기타사항" Key="DESCRIPTINS" Width="80px" Hidden="True">
                                        <Header Caption="기타사항">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                </Columns>
                            </ig:UltraGridBand>
                        </Bands>
                        <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False"
                            BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" CellPaddingDefault="2"
                            HeaderClickActionDefault="NotSet" JavaScriptFileName="" JavaScriptFileNameCommon=""
                            Name="ugrdKpiGroup" RowHeightDefault="20px" RowSelectorsDefault="No"
                            ScrollBarView="Horizontal" Version="4.00">
                            <GroupByBox>
                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                ForeColor="White" HorizontalAlign="Center">
                                <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="1px"
                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                            <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate" MouseOverHandler="MouseOverHandler" />
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                            <Images ImageDirectory="">
                            </Images>
                        </DisplayLayout>
                    </ig:UltraWebGrid>
                </td>
                <td valign="top" align="left" >
                    <ig:UltraWebGrid ID="ugrdEstLevel" runat="server" Height="100%" Width="100%" ImageDirectory="" OnInitializeRow="ugrdEstLevel_InitializeRow">
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <Columns>
                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="평가기간코드" Key="ESTTERM_REF_ID" Width="38px" Hidden="True">
                                        <Header Caption="평가기간코드">
                                        </Header>
                                        <HeaderStyle Wrap="True" />
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_REF_ID" HeaderText="지표군 CODE"
                                        Key="KPI_GROUP_REF_ID" Type="Custom" Width="70px" Hidden="True">
                                        <Header Caption="지표군 CODE">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표군명"
                                        Key="KPI_GROUP_NAME" Type="Custom" Width="100px" Hidden="True">
                                        <Header Caption="지표군명">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="EST_LEVEL" HeaderText="평가차수ID"
                                        Key="EST_LEVEL" Type="Custom" Width="70px" Hidden="True">
                                        <Header Caption="평가차수ID">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="EST_LEVEL_NAME" HeaderText="평가차수명"
                                        Key="EST_LEVEL_NAME" Type="Custom" Width="100px">
                                        <Header Caption="평가차수명">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:TemplatedColumn BaseColumnName="SETTLE_MEAN_YN" Key="SETTLE_MEAN_YN" EditorControlID="" 
                                       Width="35px" FooterText="" HeaderText="평균조정여부" Hidden="true">
                                      <Header Caption="평균조정여부">
                                        <RowLayoutColumnInfo OriginX="5" />
                                      </Header>
                                      <HeaderStyle Wrap="True" />
                                      <CellStyle HorizontalAlign="Center"></CellStyle>
                                      <CellTemplate>
                                        <asp:checkbox runat="server" id="chkUse" Enabled="false" Checked="false" ></asp:checkbox>
                                      </CellTemplate>
                                      <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                      </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:TemplatedColumn BaseColumnName="SETTLE_DEVIATION_YN" Key="SETTLE_DEVIATION_YN" EditorControlID="" 
                                       Width="35px" FooterText="" HeaderText="편차조정여부" Hidden="true">
                                      <Header Caption="편차조정여부">
                                        <RowLayoutColumnInfo OriginX="6" />
                                      </Header>
                                      <HeaderStyle Wrap="True" />
                                      <CellStyle HorizontalAlign="Center"></CellStyle>
                                      <CellTemplate>
                                        <asp:checkbox runat="server" id="chkUse" Enabled="false" Checked="true" ></asp:checkbox>
                                      </CellTemplate>
                                      <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                      </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치"
                                        Key="WEIGHT" Type="Custom" Width="60px" DataType="System.Double">
                                        <Header Caption="가중치">
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right"></CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="EST_ORDER" HeaderText="평가순서"
                                        Key="EST_ORDER" Type="Custom" Width="60px" DataType="System.Int32">
                                        <Header Caption="평가순서">
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Header>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right"></CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="DESCRIPTINS" HeaderText="기타사항" Key="DESCRIPTINS" Width="210px">
                                        <Header Caption="기타사항">
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                </Columns>
                            </ig:UltraGridBand>
                        </Bands>
                        <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False"
                            BorderCollapseDefault="Separate" CellClickActionDefault="Edit" CellPaddingDefault="2"
                            HeaderClickActionDefault="NotSet" JavaScriptFileName="" JavaScriptFileNameCommon=""
                            Name="ugrdEstLevel" RowHeightDefault="20px" RowSelectorsDefault="No"
                            ScrollBarView="Horizontal" Version="4.00" AllowUpdateDefault="Yes">
                            <GroupByBox>
                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                ForeColor="White" HorizontalAlign="Center">
                                <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="1px"
                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                            <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate" MouseOverHandler="MouseOverHandler" />
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                            <Images ImageDirectory="">
                            </Images>
                        </DisplayLayout>
                    </ig:UltraWebGrid>
                </td>
            </tr>
            <tr>
                <td colspan="2" valign="bottom" align="right" style="height: 40px">
                    <asp:ImageButton ID="iBtnReg" runat="server" ImageUrl="~/images/btn/b_001.gif" OnClick="iBtnReg_Click" />
                    <asp:imagebutton id="iBtnDel" runat="server" imageurl="~/images/btn/b_004.gif" OnClick="iBtnDel_Click"></asp:imagebutton>
                    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
               </td>
            </tr>
        </table>
</asp:Content>