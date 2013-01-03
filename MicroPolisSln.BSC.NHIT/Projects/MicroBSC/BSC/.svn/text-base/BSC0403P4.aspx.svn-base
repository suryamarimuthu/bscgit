<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0403P4.aspx.cs" Inherits="BSC_BSC0403P4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BSC</title>
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    <style type="text/css" media="print">
        .btnPrint
        {
            display:none;
            left:0px;
            top:0px;
        }
        /* 결재 원문 */
        #divArea_M
        {
            border-collapse:collapse;
            position:absolute;
            height:100%;
            width:100%;
            left:0px;
            top:0px;
            background-color:white;
            margin-top:3px;
            margin-bottom:5px;
            margin-left:3px;
            margin-right:5px;
            border:1px outset #ddd;
            text-align:center;
            overflow:none;
        }
        #divArea_M table 
        {
            /* table-layout:fixed; 그리드가 깨짐으로 사용금지*/
            border-collapse:collapse;
            border:1px solid #ddd;
        }

        #divArea_M td 
        {
            border-collapse:collapse;
            text-align:center;
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            line-height:1.5em;
        }

        #divArea_M th 
        {
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            text-align:center;
            background:#f1f1f7;
            line-height:1.5em;
            padding:3px;
            height:22px;
            font-weight:normal;
        }
        
        #divArea_M table tr th 
        {
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            text-align:center;
            background:#F8F8F8;
            line-height:1.5em;
            padding:3px;
            height:18px;
            font-weight:normal;
        }
        
        #divArea_M td span
        {
            border:0px solid #ccc;
            text-align:left;
            background:#ffffff;
            line-height:1.5em;
            padding:1px;
            width:98%;
            display:inline;
        }
    </style>
    
    <style type="text/css" media="screen">
        .btnPrint
        {
            display:inline;
            left:0px;
            top:0px;
        }
        /* 결재 원문 */
        #divArea_M
        {
            border-collapse:collapse;
            position:absolute;
            height:100%;
            width:100%;
            left:0px;
            top:0px;
            background-color:white;
            margin-top:3px;
            margin-bottom:5px;
            margin-left:3px;
            margin-right:5px;
            border:1px outset #ddd;
            text-align:center;
            overflow:scroll;
        }
        #divArea_M table 
        {
            /* table-layout:fixed; 그리드가 깨짐으로 사용금지*/
            border-collapse:collapse;
            border:1px solid #ddd;
        }

        #divArea_M td 
        {
            border-collapse:collapse;
            text-align:center;
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            line-height:1.5em;
        }

        #divArea_M th 
        {
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            text-align:center;
            background:#f1f1f7;
            line-height:1.5em;
            padding:3px;
            height:22px;
            font-weight:normal;
        }
        
        #divArea_M table tr th 
        {
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            text-align:center;
            background:#F8F8F8;
            line-height:1.5em;
            padding:3px;
            height:18px;
            font-weight:normal;
        }
        
        #divArea_M td span
        {
            border:0px solid #ccc;
            text-align:left;
            background:#ffffff;
            line-height:1.5em;
            padding:1px;
            width:98%;
            display:inline;
        }
    </style>
</head>
<body style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
  <form id="form1" runat="server">
    <div id="divArea_M">
        <table border="0" cellpadding="0" cellspacing="0" width="96%" style="text-align:center;">
          <tr>
            <th style="text-align:left; font-weight:bold;">
              기본정보<asp:ImageButton runat="server" ID="iBtnPrint" ImageUrl="~/images/btn/b_080.gif" Visible="false"  CssClass="btnPrint" OnClientClick="window.print(); return false;" ImageAlign="AbsMiddle" />
            </th>
          </tr>
          <tr>
            <td style="text-align:left;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                    <td style="width:600px;">
                        <table border="0" cellpadding="0" cellspacing="0" width="600px">
                          <tr>
                            <th style="width:12%;">
                              평가기간정보
                            </th>
                            <td style="width:16%; text-align:left;" align="left">
                              <asp:Label ID="lblEstTermInfo" Text="" runat="server"></asp:Label>
                              <asp:Label ID="lblMonthInfo" Text="" runat="server"></asp:Label>
                              <asp:DropDownList ID="ddlEstTermInfo" runat="server" CssClass="box01" Visible="false" ></asp:DropDownList>
                              <asp:DropDownList ID="ddlMonthInfo" runat="server" CssClass="box01" Visible="false" ></asp:DropDownList>
                              <asp:DropDownList ID="ddlSumType" runat="server" CssClass="box01" Visible="false"></asp:DropDownList>
                              <asp:dropdownlist id="ddlEstDept" runat="server" CssClass="box01" Visible="false"></asp:dropdownlist>
                              <asp:CheckBox     ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" Visible="false" />
                            </td>
                          </tr>
                          <tr>
                            <th style="width:12%;">
                              조&nbsp;&nbsp;회&nbsp;&nbsp;구&nbsp;&nbsp;분
                            </th>
                            <td style="width:60%; text-align:left;" align="left">
                              <asp:Label ID="lblSumType" Text="" runat="server" Width="98%"></asp:Label>
                            </td>
                          </tr>                  
                          <tr>
                            <th>
                              평가조직정보
                            </th>
                            <td align="left" style=" text-align:left;">
                              <asp:Label ID="lblEstDeptName" Text="" runat="server" Width="98%"></asp:Label>
                            </td>
                          </tr>
                          <tr>
                            <th>
                              BSC Champion
                            </th>
                            <td align="left" style=" text-align:left;">
                              <asp:Label ID="lblChampName" Text="" runat="server" Width="98%"></asp:Label>
                            </td>
                          </tr>
                          <tr>
                            <th>
                              조&nbsp;&nbsp;직&nbsp;&nbsp;비&nbsp;&nbsp;젼
                            </th>
                            <td align="left" style=" text-align:left;">
                              <asp:Label ID="lblDeptVision" Text="" runat="server" Width="98%"></asp:Label>
                            </td>
                          </tr>
                        </table>
                    </td>
                    <td style="vertical-align:top;">
                        <asp:GridView ID="ultraLegend" runat="server" AutoGenerateColumns="False" Width="255px" Height="100%" ShowHeader="false" BorderWidth="0px" GridLines="None" OnRowDataBound="ultraLegend_RowDataBound">
                          <Columns>
                            <asp:BoundField HeaderText="VIEW_NAME" DataField="VIEW_NAME" ItemStyle-Wrap="true" HeaderStyle-Width="100px" HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField HeaderText="SCORE" DataField="SCORE" ItemStyle-Wrap="true" HeaderStyle-Width="70px" DataFormatString="{0:#,##0.00}" HtmlEncode="false" />
                            <asp:TemplateField HeaderText="신호" HeaderStyle-Width="15px">
                                <ItemTemplate>
                                  /
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="WEIGHT" DataField="WEIGHT" ItemStyle-Wrap="true" HeaderStyle-Width="70px" DataFormatString="{0:#,##0.00}" HtmlEncode="false" />
                          </Columns>
                        </asp:GridView>                    
                    </td>
                  </tr>
                </table>
           </td>
         </tr>
         <tr>
            <th style="text-align:left; font-weight:bold;">
              스코어카드
            </th>
         </tr>
         <tr>
            <td>
                <asp:GridView ID="ugrdKpiStatus" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCreated="ugrdKpiStatus_RowCreated" OnRowDataBound="ugrdKpiStatus_RowDataBound">
                  <Columns>
                      <asp:BoundField HeaderText="관점명" DataField="VIEW_NAME">
                          <HeaderStyle Width="95px" />
                          <ItemStyle BackColor="WhiteSmoke" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="전략명" DataField="STG_NAME" HtmlEncode="False" Visible="false" >
                          <HeaderStyle Width="160px" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="지표명" DataField="KPI_NAME" HtmlEncode="False" >
                          <HeaderStyle Width="400px" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="단위" DataField="UNIT" HtmlEncode="False" >
                          <HeaderStyle Width="60px" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="계획" DataField="TARGET" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                          <HeaderStyle Width="110px" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="실적" DataField="RESULT" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                          <HeaderStyle Width="110px" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="가중치" DataField="CURRENT_WEIGHT" DataFormatString="{0:#,##0.##}" HtmlEncode="False" >
                          <HeaderStyle Width="110px" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="점수" DataField="AC_POINT" DataFormatString="{0:#,##0.##}" HtmlEncode="False" NullDisplayText="-" >
                          <HeaderStyle Width="60px" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundField>
                      <asp:TemplateField HeaderText="신호">
                        <ItemTemplate>
                          <asp:Image ID="imgSignal" ImageUrl='<%# "../images/"+Eval("SIGNAL") %>' runat="server"/>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField HeaderText="SIGNAL_NAME" DataField="SIGNAL" HtmlEncode="False" Visible="False" >
                          <HeaderStyle Width="60px" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundField>
                  </Columns>
                  <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
                  <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:GridView>                      
            </td>
         </tr>
         <tr>
            <th style="text-align:left; font-weight:bold;">
              Action Plan
            </th>
         </tr>
         <tr>
           <td>
              <asp:GridView ID="ugrdLoadMapList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="ugrdLoadMapList_RowDataBound">
                <Columns>
                  <asp:BoundField HeaderText="년월" DataField="YMD_DESC" HeaderStyle-Width="80px" /> 
                  <asp:BoundField HeaderText="추진계획" DataField="MONTHLY_PLAN" ItemStyle-Wrap="true" HeaderStyle-Width="390px" HtmlEncode="false" />
                  <asp:BoundField HeaderText="추진내용" DataField="DETAILS" ItemStyle-Wrap="true" HeaderStyle-Width="390px" HtmlEncode="false" />
                </Columns>
              </asp:GridView>
           </td>
         </tr>
       </table>  
    </div>
  </form>
</body>
</html>
