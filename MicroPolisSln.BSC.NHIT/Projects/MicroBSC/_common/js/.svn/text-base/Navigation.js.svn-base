
//Used to determine if the "Dock Panel" is pinned or not
var _pinned = true;

//Toggles the "Dock Panel" to either Pinned or Docked State
function toggleDockPanel(){
	var theMainMenuText = document.getElementById('theMainMenuText');
	var theListBar = iglbar_getListbarById('wb');
	var theImage = document.getElementById('theDockPanelImage');
	var theHeader = document.getElementById('Mainbg');
	var thedotdot = document.getElementById('dotdot');	
	var theFrameSet = top.frameset?top.frameset:top.document.getElementById("frsContent");
	//var theSearchCombo = document.getElementById('dvSearchCombo');
	
	if (_pinned){
		theFrameSet.setAttribute("cols", "28, *");
		theListBar.Element.style.display = 'none';
		theMainMenuText.style.display = 'none';
		//theSearchCombo.style.display = 'none';
		theImage.src='/images/navigation/pushPinClose.gif';
		theHeader.style.backgroundimage = "url(/images/navigation/toggle_bg_hor.gif)";
		theHeader.style.backgroundRepeat = "no-repeat";
		thedotdot.style.backgroundimage = "url(/images/navigation/dotdot_bg.gif)";		

	}else{		
		theFrameSet.setAttribute("cols", "20%, 80%");
		theListBar.Element.style.display = '';
		theMainMenuText.style.display = '';
		//theSearchCombo.style.display = '';
		theImage.src='/images/navigation/pushPin.gif';
		theHeader.style.backgroundImage = "url(/images/navigation/onyxBar.gif)";
		thedotdot.style.backgroundImage = "url(/images/navigation/onyxBar.gif)";
		
	}
	_pinned = !_pinned;
}



function wb_InitializeListbar(oListbar, oEvent){
	fixMozillaItemScrolling(oListbar.Id);
}

function fixMozillaItemScrolling(lbarID){
	//If this is firefox, we will set the Items container height to 0.  This is to force
	//firefox to properly scroll the items area.
	if(navigator.userAgent.toLowerCase().indexOf("mozilla")>=0){
		if(navigator.userAgent.toLowerCase().indexOf("firefox")>=0){
			ig.getElementById(lbarID+"_Items_0").parentNode.style.height=0;
		}
	}
}

function body_onLoad()
{
    if(navigator.userAgent.toLowerCase().indexOf("firefox")>=0)
    {
        window.resizeBy(1,1);
        window.resizeBy(-1,-1);		
    }
}


function UltraWebTree1_NodeClick(treeId, newNodeId){
	var tree = igtree_getTreeById("UltraWebTree1");
	var node = igtree_getNodeById(newNodeId);
	var t = (node.getTag());
	if(t != null) {
		node.setTargetUrl("contents.aspx?t=" + t);
		node.setTargetFrame("main");
	}

}

/*
function InitializeCombo(combo){
    var combo=igcmbo_getComboById(combo);
    combo._selectWhere=combo.selectWhere;
    combo.selectWhere=function(where)
    {
        var items=where.substring(where.indexOf("'")+1,where.lastIndexOf("'")).split(" ");
        return combo._selectWhere(where.substring(0,where.indexOf("'")+1)+"%"+items.join("%' and SearchTerms Like '%")+"'");
    };
}
*/

function MainMenu_onclick() {

}
