<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl_Tree.ascx.cs" Inherits="_common_lib_MenuControl_Tree" %>

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
    <tr>
        <td style="width: 170px;">
	        <ig:ULTRAWEBTREE BackColor="White" 
	            id="UltraWebTree1" 
	            runat="server" 
	            backimageurl="" 
	            cursor="Hand" 
	            defaultimage="" 
	            defaultislandclass="" 
	            defaultitemclass="" 
	            disabledclass="" 
	            expandimage="icon_left02.gif" 
	            fileurl="" 
	            hiliteclass="" 
	            hoverclass="" 
	            indentation="10" javascriptfilename="" javascriptfilenamecommon="" nodeeditclass="" parentnodeimageurl="" rootnodeimageurl="" targetframe="" targeturl="" 
	            webtreetarget="HierarchicalTree" height="100%" width="170px" expandonclick="True" imagedirectory="/images/icon/" expandimagesvisible="False" cssclass="" 
	            expandanimation="None" xslfile="" Font-Names="Dotum" Font-Size="11px">
		        <CLIENTSIDEEVENTS afterbeginnodeedit="" afterendnodeedit="" afternodeselectionchange="" afternodeupdate="" beforebeginnodeedit="" beforeendnodeedit="" beforenodeselectionchange="" beforenodeupdate="" demandload="" drag="" dragend="" dragenter="" dragleave="" dragover="" dragstart="" drop="" editkeydown="" editkeyup="" initializetree="" keydown="" keyup="" nodechecked="" nodeclick="UltraWebTree1_NodeClick" nodecollapse="" nodeexpand="" />
		        <SELECTEDNODESTYLE forecolor="#2080D0" borderstyle="None" />
		        <HOVERNODESTYLE forecolor="#0054FF" />
		        <NODEPADDINGS bottom="1px" />
                <Images>
                    <ExpandImage Url="icon_left02.gif" />
                </Images>
	        </ig:ULTRAWEBTREE>
	    </td>
	</tr>
</table>
