<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0407M1.aspx.cs" Inherits="BSC_BSC0407M1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script type="text/javascript" language="javascript">
        function showMemo() 
        {
            document.all.imgShow.style.display      = "none";
            document.all.imgHide.style.display      = "block";
	        document.all.leftLayer.style.display    = "block";
        }

        function hiddenMemo() 
        {
            document.all.imgShow.style.display      = "block";
            document.all.imgHide.style.display      = "none";
	        document.all.leftLayer.style.display    = "none";
        }
    </script>

<!--- MAIN START --->
		<table cellpadding="2" cellspacing="0" border="0" height="100%" width="98%">
		<tr valign="top">
			<td colspan="2">
<!--- 상단  --->	
        <div style=" overflow:auto; width:100%; height:100%;">
            <table cellpadding="0" cellspacing="0" border="0" width="100%" height="100%">
              <tr>
                <td width="5px">
            <!--- Tree  --->	
                <div id="leftLayer" style="border:#F4F4F4 3 solid; DISPLAY:block; overflow: auto; position:static; display:none;
                width: 200px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                <asp:TreeView ID="trvEstDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged" >
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
                <td width="5px">
                <!--- 이미지  --->	
                <a href="javascript:hiddenMemo();"><img alt="" src="../images/btn/btn_Hide.gif" id="imgHide" /></a><br />
                <a href="javascript:showMemo();"><img alt="" src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" /></a>
                </td>
                <td valign="top">
                  <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%; vertical-align:top;">
                    <tr>
                      <td valign="top" style="height:60px;">
	                    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
	                       <tr>
		                       <td class="tabletitle2" align="center"  style="height:20px; width:80px;">평&nbsp;가&nbsp;&nbsp;기&nbsp;간</td>
		                       <td class="tableContent" >
		                         <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
		                           <tr>
		                             <td>
                                         <asp:DropDownList ID="ddlEstTermInfo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" CssClass="box01"></asp:DropDownList>&nbsp;
                                         <asp:DropDownList ID="ddlEstTermMonth" runat="server" Visible="False" CssClass="box01"></asp:DropDownList>		                             
		                             </td>
	                                 <td class="tabletitle2" align="center"  style="height:20px; width:80px;">평&nbsp;가&nbsp;&nbsp;조&nbsp;직</td>
	                                 <td class="tableContent" >
                                        <asp:Label ID="ltEstDeptName" runat="server" Width="100%"></asp:Label></td>
		                           </tr>
		                         </table>
                               </td>
	                       </tr>
	                       <tr>
		                       <td class="tabletitle2" align="center"  style="width:80px;">조&nbsp;직&nbsp;&nbsp;비&nbsp;젼</td>
		                       <td class="tableContent" width="500" >
		                         <asp:Label ID="lblSTGMapName" Width="100%" runat="server"></asp:Label>
		                       </td>
	                       </tr>
	                       <tr>
		                       <td class="tableTitle" align="center" style="height:20px; width:80px;">BSC Champion</td>
		                       <td class="tableContent">
		                         <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
		                           <tr>
		                             <td style="width:150px;">
                                         <asp:Label   ID="lblChampName" runat="server" Width="98%"></asp:Label>
		                             </td>
		                             <td align="right">
                                         <asp:ImageButton ID="iBtnSelect" runat="server" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSelect_Click" />
                                         <asp:ImageButton ID="iBtnSave" runat="server" ImageUrl="../images/btn/b_001.gif" OnClick="iBtnSave_Click" />		                             
		                             </td>
		                           </tr>
		                         </table>
		                       </td>
	                       </tr>
	                    </table>   
                      </td>
                    </tr>
                    <tr>
                      <td valign="top">
                          <ig:UltraWebGrid ID="ugrdLoadMapList" runat="server"  Width="100%" Height="100%" OnInitializeLayout="ugrdLoadMapList_InitializeLayout" OnInitializeRow="ugrdLoadMapList_InitializeRow">
                            <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" 
                                               Width="80px" Hidden="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="ESTTERM_REF_ID">
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" FooterText="" HeaderText="전략 ID"
                                            Key="EST_DEPT_REF_ID" Width="70px" Hidden="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="EST_DEPT_REF_ID">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="YMD" FooterText="" HeaderText="년월"
                                            Key="YMD" Width="40px" Hidden="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="년월">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="YMD_DESC" FooterText="" HeaderText="년월"
                                            Key="YMD_DESC" Width="60px" AllowUpdate="No">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="년월">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:TemplatedColumn BaseColumnName="MONTHLY_PLAN" FooterText="" HeaderText="계획" Key="MONTHLY_PLAN"
                                            Width="295px" CellMultiline="Yes">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="당월">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left" Wrap="True"></CellStyle>
                                            <CellTemplate>
                                              <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" Wrap="false" id="txtMONTHLY_PLAN" runat="server"></asp:TextBox>
                                            </CellTemplate>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                        <ig:TemplatedColumn BaseColumnName="DETAILS" FooterText="" HeaderText="추진내용" Key="DETAILS"
                                            Width="295px" CellMultiline="Yes">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="누적">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left" Wrap="True">
                                            </CellStyle>
                                            <CellTemplate>
                                              <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" Wrap="false" id="txtDETAILS" runat="server"></asp:TextBox>
                                            </CellTemplate>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                        <ig:TemplatedColumn BaseColumnName="ETC_CONTENTS" FooterText="" HeaderText="특이사항" Key="ETC_CONTENTS"
                                            Width="150px" CellMultiline="Yes" Hidden="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="특이사항">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left" Wrap="True"></CellStyle>
                                            <CellTemplate>
                                              <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" Wrap="false" id="txtETC_CONTENTS" runat="server"></asp:TextBox>
                                            </CellTemplate>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                        <ig:UltraGridColumn BaseColumnName="CLOSE_YN" FooterText="" HeaderText="CLOSE_YN" Key="CLOSE_YN"
                                            Width="30px" CellMultiline="Yes" Hidden="true">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="마감">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Center" Wrap="True">
                                            </CellStyle>
                                            <Footer Caption="">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                    </RowTemplateStyle>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                Name="ugrdLoadMapList" RowHeightDefault="187px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="Flat" AllowUpdateDefault="Yes">
                                <GroupByBox Hidden="True">
                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                </GroupByBox>
                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                </GroupByRowStyleDefault>
                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                </FooterStyleDefault>
                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                    <Padding Left="0px" Bottom="0px" Right="0px" Top="0px" />
                                </RowStyleDefault>
                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                </SelectedRowStyleDefault>
                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                    ForeColor="White" HorizontalAlign="Left" Height="23px">
                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px" Wrap="True">
                                </EditCellStyleDefault>
                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="100%">
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
                                <ActivationObject BorderColor="" BorderWidth="">
                                </ActivationObject>
                            </DisplayLayout>
                        </ig:UltraWebGrid>                      
                      </td>
                    </tr>
                  </table>
                </td>
            </tr>
            </table>
        </div>
	        </td>
    	</tr>
		
		</table>
       <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
<!--- MAIN END --->

</asp:Content>