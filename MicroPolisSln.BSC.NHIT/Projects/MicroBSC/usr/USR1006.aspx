<%@ Page Language="C#" MasterPageFile="~/_common/libNHIT/MicroBSC.master" AutoEventWireup="true" CodeFile="USR1006.aspx.cs" Inherits="usr_USR1006" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contents" Runat="Server">
<script src="/_common/js/jQuery/jquery-1.6.4.min.js" type="text/javascript"></script>
<script type="text/javascript">
function fnClick(depth, id, e){
    var maxRow = parseInt('<%=rowCount %>');
    if (depth != "" && id != "") {
        $.ajax({
            type: "POST",
            url: "USR1006S.aspx",
            data: { level: depth, upId: id },
            contentType: "application/x-www-form-urlencoded",
            success: function(data) {
                var id = "div" + depth;
                var layer = $("#" + id);
                if (layer.length > 0) {
                    $("#" + id).html("");
                    $("#" + id).append(data);
                }
                else {
                    var makeDiv = "<div class='depth' id=\"" + id + "\"></div>";
                    $("#div_wrap").append(makeDiv);
                    $("#" + id).append(data);
                }
                var tmp = parseInt(depth) - 1;
                var layerid = "#div" + tmp + " > .dept";
                $(layerid).css("border-color", "#cccccc");
                $(e).css("border-color", "red");
                for (var i = parseInt(depth) + 1; i <= maxRow; i++) {
                    var ids = "#div" + i;
                    $(ids).remove();
                }
            }
        });
    }
}
$(function() {
$("#div_wrap:parent:parent").css("vertical-align", "top");
});
</script>
<style type="text/css">

#div_wrap{width:auto;margin:0;padding:10px;border:1px solid #bdbdbd;vertical-align:top; height:100%;}
.depth {margin: 5px 5px 5px 5px; width: 150px; display:inline; vertical-align:top;}
.dept{border : solid 1px #cccccc; padding: 5px 5px 5px 5px; margin: 5px 5px 5px 5px; width: 150px; cursor:pointer; text-align:center; font-weight:bold;}

</style>
<div id="div_wrap">
    <div class="depth" id="div0">
    <%=Html %>
    </div>
</div>

</asp:Content>

