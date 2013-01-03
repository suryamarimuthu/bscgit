<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl_Tree.ascx.cs" Inherits="_common_libNHIT_MenuControl_Tree" %>

<script>

	function UltraWebTree1_NodeClick( treeId, nodeId, button )
	{
//alert( "HI" );	
		if ( igtree_getNodeById( nodeId ).getTag() != null )
		{
		    var UrlSplit = igtree_getNodeById(nodeId).getTag().split(';');


//		    alert(igtree_getNodeById(nodeId).getTag());
//		    alert(UrlSplit.length);
//		    alert(UrlSplit[0].length);
//		    alert(UrlSplit[1].length);
			
	//				if ( UrlSplit != null && UrlSplit.length == 2 )
			if ( UrlSplit != null && UrlSplit.length == 2 && UrlSplit[0].length != 0 && UrlSplit[1].length != 0 ) {

			    //alert(UrlSplit.length);
				var Url = UrlSplit[0];
				location.href = Url;
			}

	//				location.href = igtree_getNodeById( nodeId ).getTag();
		}
	}

</script>
<table border="0" cellpadding="0" cellspacing="0" style="width: 170px; height: 100%;">
    <tr style="height:100%;">
        <td style="width: 170px;">
	        <ig:ULTRAWEBTREE
	                            BackColor="White"
	                            imagedirectory="/images/icon/NHIT/"
	                            id="UltraWebTree1" 
	                            runat="server"
	                            backimageurl="" 
	                            cursor="Hand" 
	                            defaultimage="" 
	                            defaultislandclass="" 
	                            defaultitemclass="" 
	                            disabledclass="" 
	                            fileurl="" 
	                            hiliteclass="" 
	                            hoverclass="" 
	                            indentation="5" 
	                            javascriptfilename="" 
	                            javascriptfilenamecommon="" 
	                            nodeeditclass="" 
	                            parentnodeimageurl="" 
	                            rootnodeimageurl="" 
	                            targetframe="" 
	                            targeturl="" 
	                            webtreetarget="HierarchicalTree" 
	                            height="100%" 
	                            width="100%"
	                            expandonclick="true"
	                            ExpandImagesVisible="false"
	                            expandanimation="None" 
	                            xslfile="" 
	                            CssClass="cssLeftMenu">
		        <CLIENTSIDEEVENTS   afterbeginnodeedit="" 
		                            afterendnodeedit="" 
		                            afternodeselectionchange="" 
		                            afternodeupdate=""
		                            beforebeginnodeedit="" 
		                            beforeendnodeedit=""
		                            beforenodeselectionchange="" 
		                            beforenodeupdate="" 
		                            demandload="" 
		                            drag="" 
		                            dragend="" 
		                            dragenter="" 
		                            dragleave="" 
		                            dragover="" 
		                            dragstart="" 
		                            drop="" 
		                            editkeydown="" 
		                            editkeyup="" 
		                            initializetree="" 
		                            keydown="" 
		                            keyup="" 
		                            nodechecked="" 
		                            nodeclick="UltraWebTree1_NodeClick" 
		                            nodecollapse="" 
		                            nodeexpand="" />
		        <SELECTEDNODESTYLE CssClass="cssLeftMenu_Selected" BorderStyle="None"/>
		        <HOVERNODESTYLE forecolor="#0054FF" />
		        <NODEPADDINGS bottom="1px" />
		        <Padding Left="15px" Top="15px" />
                <Images>
                    <%--<ExpandImage Url="icon_left02.gif" />--%>
                </Images>
	        </ig:ULTRAWEBTREE>
	    </td>
	</tr>
	<tr style="height:5px;"><td style="background-image:url(../images/NHIT/back_leftmenu_bottom.gif); background-repeat:no-repeat; background-position:bottom left; line-height:5px;">&nbsp;</td></tr>
</table>
