<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_dept_org.aspx.cs" Inherits="usr_dept_org" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BSC</title>
    <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
    <link href="../_common/css/dept_org.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        //////////////////////////
        //윈도우 열릴때 실행
        function initPage() {
            window.onresize = relocationLegend;
            document.onresize = relocationLegend;
            relocationLegend();
        }

        /*
        alert(e.keyCode); //크롬, 익스
        alert(e.which);//크롬, 파이어폭스
        alert(e.charCode); //크롬
        alert(document.all); //익스
        */

        if (window.addEventListener) {
            window.addEventListener("load", initPage, false); // W3C DOM 지원 브라우저 
        }
        else if (window.attachEvent) {
            window.attachEvent("onload", initPage); // W3C DOM 지원 브라우저 외(ex:MSDOM 지원 브라우저 IE) 
        }
        else {
            window.onload = initPage;
        }
        
        
        
        
        function viewPopUpT(stgMapLink, kpiLink, drillDownLink, scoreLink, workMapLink)
        {
	        // 사용 구분 선택
	        var objStgMap 	    = document.getElementById ("trStgMap");
	        var objKpi 	        = document.getElementById ("trKpi"); 
	        var objScore        = document.getElementById ("trScore");
	        var objDrillDown    = document.getElementById("trDrillDown");
	        var objWorkMap      = document.getElementById("trWorkMap");
        	
	        if (trim(stgMapLink) == '')
	        {
		        objStgMap.style.display = "none";
	        }
	        else
	        {
	            objStgMap.style.display = "block";
		        var lnkStgMap 	        = document.getElementById ("lnkStgMap");
		        lnkStgMap.href          = stgMapLink;
		    }

		    //if (trim(workMapLink) == 'N') {
		    if ('<%= WORKING_MAP_USE_YN %>' == 'N') {
		        objWorkMap.style.display = "none";
		    }
		    else {
		        objWorkMap.style.display = "block";
		        var lnkWorkMap = document.getElementById("lnkWorkMap");
		        lnkWorkMap.href = workMapLink;
		    }
        	
	        if (trim(kpiLink) == '')
	        {
		        objKpi.style.display = "none";
	        }
	        else
	        {
	            objKpi.style.display = "block";
		        var lnkKpi 	         = document.getElementById ("lnkKpi");
		        lnkKpi.href          = kpiLink;
	        }
        	
	        if (trim(drillDownLink) == '')
	        {
		        objDrillDown.style.display = "none";
	        }
	        else
	        {
	            objDrillDown.style.display  = "block";
		        var lnkDrillDown 	        = document.getElementById ("lnkDrillDown"); 
		        lnkDrillDown.href 	        = drillDownLink;
	        }
        	
	        if (trim(scoreLink) == '')
	        {
		        objScore.style.display = "none";
	        }
	        else
	        {
	            objScore.style.display = "block";
		        var lnkScore 	       = document.getElementById ("lnkScore");
		        lnkScore.href          = scoreLink;
		    }

		    if ('<%= DEPT_ORG_SCORE_USE_YN %>' == 'N') 
		    {
		        objScore.style.display = "none";
		    }

	        var x, y;
        	
	        // 마우스 위치 확인
	        x = (document.layers) ? loc.pageX : event.clientX;
	        y = (document.layers) ? loc.pageY : event.clientY;
        	
	        // 스크롤 영역 보정
	        x = document.body.scrollLeft + x;
	        y = document.body.scrollTop + y;
        	
	        var objNamePopUp = document.getElementById("divPopUp");
        	
	        if (objNamePopUp)
	        {
		        objNamePopUp.style.pixelTop		= y - 10;
		        objNamePopUp.style.pixelLeft 	= x + 15;
		        //objNamePopUp.style.display 		= (objNamePopUp.style.display == "block") ? "none" : "block";
		        objNamePopUp.style.display 		= "block";
	        }
	    }


	    function relocationLegend() {
	        var documentWidth = document.body.offsetWidth;
	        
	        var legend = document.getElementById("div_legend");
	        
	        var objOrg = document.getElementById("lblStgMap");
	        
	        
	        //var rootNode = document.getElementById("tbl_0_1");
	        //var posX = rootNode.offsetLeft + 0;
	        
	        
	        var posCenter = (objOrg.offsetLeft + objOrg.scrollWidth) / 2;
	        
	        
	        var posY = <%=legend_offsetTop.ToString() %>;
	        var add = <%=legend_offsetLeft.ToString() %>;
         
            //alert(posX);
	        //legend.style.right = 50;

	        legend.style.left = posCenter + add;
	        legend.style.top = 20;
	    }
    </script>
</head>
<%--<body style="margin-top:0px; margin-left:0px; background-image:url(../images/org/bg_org_<% = ImageType %>.jpg);">
    <form id="form2" runat="server">
        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </form>
</body>--%>
        
<body style="margin-top: 0; margin-left: 0; width: 100%;">
    <form id="form1" runat="server" style="width: 100%; height: 100%;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%" id="tblMain" runat="server">
            <tr>
                <td align="left" valign="middle" style="width: 100%; height: 100%; border: 0; margin: 0;">
                    <%--<img src="../images/org/bg_org_<%= ImageType %>.jpg" alt="" style="z-index: 0; position: absolute;" width="100%" height="100%" />--%>
                    <div style="z-index: 1; position: relative; width: 100%; height: 100%;">
                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>

<script type="text/javascript">
    document.getElementById("trScore").style.display = "none";
</script>
</html>
