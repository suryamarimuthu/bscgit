
function setCookie( name, value, expiredays )
{
	var todayDate = new Date();
	todayDate.setDate( todayDate.getDate() + expiredays );
	document.cookie = name + "=" + escape( value ) + "; path=/; expires=" + todayDate.toGMTString() + ";"
}


function getCookie( name )
{
	var nameOfCookie = name + "=";
	var x = 0;
	while ( x <= document.cookie.length )
	{
		var y = (x+nameOfCookie.length);
		if ( document.cookie.substring( x, y ) == nameOfCookie ) {
			if ( (endOfCookie=document.cookie.indexOf( ";", y )) == -1 )
				endOfCookie = document.cookie.length;
			return unescape( document.cookie.substring( y, endOfCookie ) );
		}
		x = document.cookie.indexOf( " ", x ) + 1;
		if ( x == 0 )
			break;
	}
	return "";
}


if ( getCookie( "Notice" ) != "done" )
{
	var l = (screen.width-453)/2;
  	var t = (screen.height-517)/2;
  	window.open('../_common/popup/popup.htm','notice', "width=476,height=373,top=180,left=430");
	//noticeWindow  =  
	//noticeWindow.opener = self;
}



/* ÆË¾÷ ÆäÀÌÁö Function */


function setCookie( name, value, expiredays )
    {
	var todayDate = new Date();
	todayDate.setDate( todayDate.getDate() + expiredays );
	document.cookie = name + "=" + escape( value ) + "; path=/; expires=" + todayDate.toGMTString() + ";"
	}

function closeWin() 
{ 
	if ( document.forms[0].check_box.checked ) 
 		setCookie( "Notice", "done" , 1); 

	self.close(); 
}
