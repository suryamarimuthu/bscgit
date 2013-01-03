
function GetDataSet(url, controlName, textId, valueId, type, categoryKey, categoryId)
{
	var pageUrl		= url 
		+ "?Type="				+ type
		+ "&CateKey="			+ categoryKey
		+ "&CateID="			+ categoryId;
		
	var xmlRequest	= new ActiveXObject("MSXML2.XMLHTTP");
	var objDoc		= new ActiveXObject("Msxml2.DOMDocument");

	xmlRequest.open("POST", pageUrl, false);
	xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
	xmlRequest.send();
	
	objDoc.async = true;
	objDoc.loadXML(xmlRequest.responseText);
	
	var itemLength = objDoc.getElementsByTagName( textId ).length;
	var ddList = document.all[ controlName ];
	
	/*
	ddList.options[0] = new Option('다운 중...','');
	ddList.value = '0'
	*/

	// 아이템 삭제
	for (i = ddList.options.length; i >= 0; i--) 
	{
		ddList.options[i] = null;
	}

	// 아이템 삽입
	ddList.options[0] = new Option('----------','0');

	if(itemLength >= 1) 
	{
		for(i=1;i <= itemLength; i++)
		{
			ddList.options[i] = new Option( objDoc.getElementsByTagName( textId ).item(i-1).text
					, objDoc.getElementsByTagName( valueId ).item(i-1).text);
		}
	}
	
	return xmlRequest;
}

