<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMS0100S1.aspx.cs" Inherits="PMS_PMS0100S1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">
    function ClearAll() {
        if (confirm("입력된 내용을 모두 지울까요?")) {
            document.getElementById("txtIF_COL_ID").value = "";
            document.getElementById("txtIF_COL_NAME").value = "";
            document.getElementById("txtCUSTOM_COL_ID").value = "";
            document.getElementById("txtCUSTOM_COL_NAME").value = "";
            document.getElementById("txtSOOSIK").value = "";
        }
    }
</script>

<form id="form1" runat="server">
<div>
<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td>
                <asp:label id="lblCompTitle" runat="server" visible="false" ></asp:label>
                <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True"></asp:dropdownlist>
                <asp:HiddenField ID="hdfEstID" runat="server" />
            </td>
        </tr>
        
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="컬럼" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr style="height: 70%">
            <td>
                <table class="tableBorder" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                    <tr>
                        <td class="cssTblTitle" style="width:10%;">구분</td>
                        <td class="cssTblTitle" align="center" style="width:40%; text-align:center">컬럼ID</td>
                        <td class="cssTblTitle" align="center" style="width:40%; text-align:center">컬럼명</td>
                    </tr>
                    
                    <tr style="height:50%;">
                        <td class="cssTblTitle">IF 컬럼</td>
                        <td class="cssTblContent" style="padding-left:0px;">
                            <asp:TextBox runat="server" id="txtIF_COL_ID" width="100%" height="99%" textmode="multiline" ></asp:TextBox>
                        </td>
                        <td class="cssTblContent" style="padding-left:0px;">
                            <asp:TextBox runat="server" id="txtIF_COL_NAME" width="100%" height="99%" textmode="multiline" ></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr style="height:50%;">
                        <td class="cssTblTitle">수기 컬럼</td>
                        <td class="cssTblContent" style="padding-left:0px;">
                            <asp:TextBox runat="server" id="txtCUSTOM_COL_ID" width="100%" height="99%" textmode="multiline" ></asp:TextBox>
                        </td>
                        <td class="cssTblContent" style="padding-left:0px;">
                            <asp:TextBox runat="server" id="txtCUSTOM_COL_NAME" width="100%" height="99%" textmode="multiline" ></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="lblTitle2" runat="server" style="font-weight:bold" text="수식" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr style="height: 30%">
            <td>
                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                    <tr>
                        <td class="cssTblTitle" style="width:10%;">구분</td>
                        <td class="cssTblTitle" align="center" style="width:40%; text-align:center">수식</td>
                        <td class="cssTblTitle" align="center" style="width:40%; text-align:center">수식 설명</td>
                    </tr>
                    <tr style="height:100%;">
                        <td class="cssTblTitle">기본 수식</td>
                        <td class="cssTblContent" style="padding-left:0px;">
                            <asp:TextBox runat="server" id="txtSOOSIK" width="100%" height="99%" textmode="multiline"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" id="txtSOOSIK_DESC" width="100%" height="99%" textmode="multiline"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr class="cssPopBtnLine">
            <td align="right">
                <%--<a href="javascript:ClearAll();">
                    <img src="../images/btn/b_075.gif" />
                </a>--%>
                <asp:ImageButton id="ibnSave" runat="server" 
                    ImageUrl="../images/btn/b_tp07.gif" onclick="ibnSave_Click" />
            </td>
            <asp:literal id="ltrScript" runat="server"></asp:literal>
        </tr>
    </table>

    <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</div>
</form>
<%Response.WriteFile( "../_common/html/CommonBottom.htm" );%>