var stmnLEFT = 0; // Left point for scrollmenu
var stmnGAP1 = 0; // space of page header
var stmnGAP2 = 0; // top space to browser.(default 0)
var stmnBASE = 0; // start point of scroll menu 
var stmnActivateSpeed = 10; // move speed
var stmnScrollSpeed = 0; // scroll speed

var stmnTimer;

function RefreshStaticMenu() {
	var stmnStartPoint, stmnEndPoint, stmnRefreshTimer;

	stmnStartPoint = parseInt(STATICMENU.style.top, 10);
	stmnEndPoint = document.body.scrollTop + stmnGAP2;
	if (stmnEndPoint < stmnGAP1) stmnEndPoint = stmnGAP1;

	stmnRefreshTimer = stmnActivateSpeed;

	if ( stmnStartPoint != stmnEndPoint ) {
        stmnScrollAmount = Math.ceil( Math.abs( stmnEndPoint - stmnStartPoint ) / 15 );
        STATICMENU.style.top = parseInt(STATICMENU.style.top, 10) + ( ( stmnEndPoint<stmnStartPoint ) ? -stmnScrollAmount : stmnScrollAmount );
        stmnRefreshTimer = stmnScrollSpeed;
    }
    stmnTimer = setTimeout ("RefreshStaticMenu();", stmnRefreshTimer);
}

function InitializeStaticMenu() {
	STATICMENU.style.left = stmnLEFT;
	STATICMENU.style.top = document.body.scrollTop + stmnBASE;
    RefreshStaticMenu();
}

function RefreshStaticBottomMenu() {
	var stmnStartPoint, stmnEndPoint, stmnRefreshTimer;

	stmnStartPoint = parseInt(STATICMENU.style.top, 10);
	stmnEndPoint = document.body.scrollTop + document.body.clientHeight- parseInt(STATICMENU.style.height, 10);

	stmnRefreshTimer = stmnActivateSpeed;

	if ( stmnStartPoint != stmnEndPoint ) {
        stmnScrollAmount = Math.ceil( Math.abs( stmnEndPoint - stmnStartPoint ) / 15 );
        STATICMENU.style.top = parseInt(STATICMENU.style.top, 10) + ( ( stmnEndPoint<stmnStartPoint ) ? -stmnScrollAmount : stmnScrollAmount );
        stmnRefreshTimer = stmnScrollSpeed;
    }
    stmnTimer = setTimeout ("RefreshStaticBottomMenu();", stmnRefreshTimer);
}

function InitializeStaticBottomMenu() {
	STATICMENU.style.left = document.body.clientWidth - parseInt(STATICMENU.style.width, 10);;
	STATICMENU.style.top = document.body.clientHeight- parseInt(STATICMENU.style.height, 10);
    RefreshStaticBottomMenu();
}

