<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_stg_map.aspx.cs" Inherits="usr_stg_map" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BSC</title>
    <link href="../_common/css/bsc_stg_map.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    <script type="text/javascript">
        function getXY(m_tbl_id, p_tbl_id, p_child_id)
        {
            var t_object        = document.getElementById(m_tbl_id);
            var t_top           = parseInt(t_object.offsetTop);
            var t_left          = parseInt(t_object.offsetLeft);
            var t_width         = parseInt(t_object.offsetWidth);
            var t_height        = parseInt(t_object.offsetHeight);
            
            var p_tbl_object    = document.getElementById(p_tbl_id);
            var p_tbl_top       = parseInt(t_top    + p_tbl_object.parentElement.offsetTop      + p_tbl_object.offsetTop);
            var p_tbl_left      = parseInt(t_left   + p_tbl_object.parentElement.offsetLeft     + p_tbl_object.offsetLeft);
            var p_tbl_width     = parseInt(p_tbl_object.offsetWidth);
            var p_tbl_height    = parseInt(p_tbl_object.offsetHeight);   

            var p_object        = document.getElementById(p_child_id);
            var p_top           = parseInt(p_tbl_top     + p_object.parentElement.offsetTop      + p_object.offsetTop);
            var p_left          = parseInt(p_tbl_left    + p_object.parentElement.offsetLeft     + p_object.offsetLeft);
            var p_width         = parseInt(p_object.offsetWidth);
            var p_height        = parseInt(p_object.offsetHeight);
            
            var xTop = p_left + p_width/2;
            var yTop = p_top + 2;
            
            var xBottom = p_left + p_width/2;
            var yBottom = p_top + p_height - 3;
            
            return xTop+'_'+yTop+'_'+xBottom+'_'+yBottom;
        }
        function pivotWorkMap() {
            var ibtn = document.getElementById('ibtnPivotWorkMap');
            __doPostBack(ibtn.id, '');
            return true;
        }
        function openWorkForm(estterm_ref_id, est_dept_ref_id, work_ref_id) {
            gfOpenWindow("../PRJ/PRJ1102M1.aspx?iType=U&ESTTERM_REF_ID=" + estterm_ref_id + "&EST_DEPT_REF_ID=" + est_dept_ref_id + "&WORK_REF_ID=" + work_ref_id
                , 720, 630, 'PRJ1102M1');
        }
        function openExecForm(estterm_ref_id, est_dept_ref_id, work_ref_id, exec_ref_id) {
            gfOpenWindow("../PRJ/PRJ1102M5.aspx?iType=U&ESTTERM_REF_ID=" + estterm_ref_id + "&EST_DEPT_REF_ID=" + est_dept_ref_id + "&WORK_REF_ID=" + work_ref_id + "&EXEC_REF_ID=" + exec_ref_id
                , 1000, 820, 'PRJ1102M5');
        }
</script>
</head>
<body style="margin:0; background-color: #edf0f5;" onload='doManualDrawing()' oncontextmenu='return false'>
    <form id="form1" runat="server">
    
        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
        <asp:Literal ID="ltrScript_PostBack" runat="server"></asp:Literal>
    <!--  onload='doManualDrawing()' onresize = 'doManualDrawing()'ondragstart='return false' onselectstart='return false'-->
    <!--div id="divLine" style="cursor:url('../images/etc/pen01.cur');  position:absolute;left:0px;top:0px;width:0%;height:0%;z-index:1;" onmousedown='doDrawing(event,0)' onmouseup='doDrawing(event,1)'></div-->
	<div id="layer1" style="position:absolute; width:100px; height:50px; z-index:0; border: 0px dotted #ff33ff; visibility: hidden;">
	    <table style="width:102px;" border='0' cellpadding='0' cellspacing='0'>
	        <tr>
	            <td valign="middle" style="width:102px;height:32px;background-image:url('../images/stg/full_down/down_01_off.gif');" align='center' id='down_01_' >	
	                <table>
	                    <tr>
	                        <td style="height:7px;">
	                        </td>
	                    </tr>
	                    <tr>
	                        <td>
	                            <asp:LinkButton ID="ltnSaveDrawing" runat="server" OnClick="ltnSaveDrawing_Click" OnClientClick = "return doSaving();" >저장</asp:LinkButton>
	                        </td>
	                    </tr>
	                </table>	                
	            </td>
	        </tr>
	        <tr>
	            <td style="width:102px;height:32px;background-image:url('../images/stg/full_down/down_02_off.gif');" align='center' id='down_02_' >	
	                <asp:LinkButton ID="ltnCancel" runat="server" OnClick="ltnCancel_Click">취소</asp:LinkButton>
	            </td>
	        </tr>
	        <tr>
	            <td style="width:102px;height:36px;background-image:url('../images/stg/full_down/down_03_off.gif');" align='center' id='down_03_' >	                 
	                <table>	                    
	                    <tr>
	                        <td>
	                          &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="ItnReset" runat="server" OnClick="ItnReset_Click" OnClientClick="return doResetting();">초기화</asp:LinkButton>
	                        </td>
	                    </tr>
	                    <tr>
	                        <td style="height:3px;">
	                        </td>
	                    </tr>
	                </table>	
	            </td>
	        </tr>
	    </table>              
	</div>
	<asp:HiddenField ID='hdfArrX1' runat="server" />
	<asp:HiddenField ID='hdfArrX2' runat="server" />
	<asp:HiddenField ID='hdfArrY1' runat="server" />
	<asp:HiddenField ID='hdfArrY2' runat="server" />
	<asp:HiddenField ID='hdf_StartUpTblID' runat="server" />
	<asp:HiddenField ID='hdf_StartTblID' runat="server" />	
	<asp:HiddenField ID='hdf_EndUpTblID' runat="server" />
	<asp:HiddenField ID='hdf_EndTblID' runat="server" />	
	<asp:ImageButton ID="ibtnPivotWorkMap" runat="server" OnClick="ibtnPivotWorkMap_Click" Width="0px" />
	<!--input type='button' value='aaaa' onclick='doLoading()'-->   

    </form>
     <script type="text/javascript">
     <!--

var pX1 = -1;
var pX2 = -1;
var pY1 = -1;
var pY2 = -1;

var pFlag = 0;

var arrX1 = '';
var arrX2 = '';
var arrY1 = '';
var arrY2 = '';

var bodyWidth  = 0;
var bodyHeight = 0;

var bodyWidth_0 = 0;
var bodyWidth_1 = 0;

var bodyHeight_0 = 0;
var bodyHeight_1 = 0;

function doMouseOver(obj)
{   
    var url = '../images/stg/full_down/'+obj+'on.gif';
    alert(url);
    document.getElementById(obj).style.backgroundImage = url;
}

function doMouseOut(obj)
{    
    var url = '../images/stg/full_down/'+obj+'off.gif';
    document.getElementById(obj).style.backgroundImage = url;
}

function doResetting()
{
    if(confirm('수동으로 설정한 모든 관계선이 지워집니다. \r\n\r\n계속 할까요?'))
    {
       __doPostBack('ItnReset','');       
    }
    else
    {
       doPoppingup(null,"hidden");
       return false;
    }
}

function doSaving()
{
    if(confirm('저장 하시겠습니까?'))
    {        
        pFlag = 0;
        document.getElementById('hdfArrX1').value = arrX1;        
        document.getElementById('hdfArrY1').value = arrY1;
        document.getElementById('hdfArrX2').value = arrX2;
        document.getElementById('hdfArrY2').value = arrY2;
                
        return true;
    }
}

function doLoading()
{
//    var t_object        = document.getElementById('tblContent');
//    var t_top           = parseInt(t_object.offsetTop);
//    var t_left          = parseInt(t_object.offsetLeft);
//    var t_width         = parseInt(t_object.offsetWidth);
//    var t_height        = parseInt(t_object.offsetHeight);
//    
//    document.getElementById('divLine').style.top    = t_top;
//    document.getElementById('divLine').style.left   = t_left;
//    document.getElementById('divLine').style.width  = t_width;
//    document.getElementById('divLine').style.height = t_height;
    
    document.getElementById('divLine').style.cursor = "../images/stg/full_down/pen01.cur";
}

function getUpTBL_ID(obj)
{
    if('<%=DRAWING_YN %>'=='Y')
    {
        if(pFlag == 0)   // 그리기 시작
        {
            
            document.getElementById('hdf_StartUpTblID').value = obj.id;
            
            if(confirm('그리기를 시작할까요?'))
            {            
                pFlag = 1;
                doLoading();
            }
            else
            {
                document.getElementById('hdf_StartUpTblID').value = '';
                document.getElementById('hdf_StartTblID').value   = '';
                document.getElementById('hdf_EndUpTblID').value   = '';
                document.getElementById('hdf_EndTblID').value     = '';
                pFlag = 0;
            }
        }
        else
        {
            document.getElementById('hdf_EndUpTblID').value   = obj.id;
            
            
            
    //        var m_tbl_id   = "tblContent";
    //        var p_tbl_id   = document.getElementById('hdf_EndUpTblID').value;
    //        var p_child_id = document.getElementById('hdf_EndTblID').value;
    //        
    //        var x2y2 = getXY(m_tbl_id,p_tbl_id,p_child_id).split('_');
    //        
    //        var temp = arrX2.split(',');

    //        //alert(temp.length);       
    //       alert(arrY2);

    ////        alert(x2y2[1]);
    ////        alert(x2y2[2]);
    //        alert(arrY2[temp.length - 1]);
    //        
    // 
    //        arrX2[temp.length - 1] = x2y2[2];
    //        arrY2[temp.length - 1] = x2y2[3];
    //        
    //        arrX1 = arrX1 + ',' + pX1;        
    //        arrY1 = arrY1 + ',' + pY1;
    //        arrX2 = arrX2 + ',' + x2y2[2];
    //        arrY2 = arrY2 + ',' + x2y2[3];
    //        
    //        alert(arrY2);
                
            if(confirm('그리기가 완료 되었습니다. \r\n\r\n저장 하시겠습니까?'))
            {
                pFlag = 0;
                document.getElementById('hdfArrX1').value = arrX1;        
                document.getElementById('hdfArrY1').value = arrY1;
                document.getElementById('hdfArrX2').value = arrX2;
                document.getElementById('hdfArrY2').value = arrY2;
            
                __doPostBack( 'ltnSaveDrawing', '' );
            }
            else
            {
                pFlag = 0;            
            }
            
        }
    }
}


function doStartingEvent(obj)
{
    if(pFlag == 0)   // 그리기 시작
    {
        document.getElementById('hdf_StartTblID').value = obj.id;
    }
    else
    {
        document.getElementById('hdf_EndTblID').value = obj.id;        
    }
}

function doCheckingBody()
{
    var t_object        = document.getElementById('tblContent');
    var t_top           = parseInt(t_object.offsetTop);
    var t_left          = parseInt(t_object.offsetLeft);
    var t_width         = parseInt(t_object.offsetWidth);
    var t_height        = parseInt(t_object.offsetHeight);
    
    bodyWidth_0  = t_width;
    bodyHeight_0 = t_height;
}

function doResizing()
{
//    //alert('doResizing');
//    var t_object        = document.getElementById('tblContent');
//    var t_top           = parseInt(t_object.offsetTop);
//    var t_left          = parseInt(t_object.offsetLeft);
//    var t_width         = parseInt(t_object.offsetWidth);
//    var t_height        = parseInt(t_object.offsetHeight);
//    
//    bodyWidth_1  = t_width;
//    bodyHeight_1 = t_height;
//    
//    //bodyWidth  = bodyWidth_0  - bodyWidth_1;
//    //bodyHeight = bodyHeight_0 - bodyHeight_1;
//    
//    bodyWidth  = (bodyWidth_0 - bodyWidth_1) / bodyWidth_0;
//    bodyHeight = (bodyHeight_0 - bodyHeight_1) / bodyHeight_0;
//  
//    bodyWidth_0  = t_width;
//    bodyHeight_0 = t_height;

}



function unDoDrawing()
{
    if(jg2)
    {
        jg2.clear();
        pX1 = -1;
        pX2 = -1;
        pY1 = -1;
        pY2 = -1;
        
        doPoppingup(null,"hidden");
        
        document.getElementById('divLine').style.width  = 0;
        document.getElementById('divLine').style.height = 0;
        
        document.getElementById('hdf_StartUpTblID').value = '';
        document.getElementById('hdf_StartTblID').value   = '';
        document.getElementById('hdf_EndUpTblID').value   = '';
        document.getElementById('hdf_EndTblID').value     = '';
        
        pFlag = 0;
        return false;
    }
}

function doPoppingup(e, proper)
{
    document.all['layer1'].style.visibility = proper;
    document.all['layer1'].style.left = event.x;
    document.all['layer1'].style.top  = event.y;
}



function doDrawing(e, flag)
{    
    if ((event.button==2) || (event.button==3)) 
    {
        doPoppingup(e, "visible");
    }
    else
    {
        doPoppingup(e,"hidden");
    }
    
    if(pFlag == 1)
    {
        var browser = navigator.appName
        
        if(flag == 0)
        {
            var m_tbl_id   = "tblContent";
            var p_tbl_id   = document.getElementById('hdf_StartUpTblID').value;
            var p_child_id = document.getElementById('hdf_StartTblID').value;
            
            var xy = getXY(m_tbl_id,p_tbl_id,p_child_id).split('_');
            
            pX1 = xy[0];
            pY1 = xy[1];
            
            if(pX2 >= 0)
            {
                pX1 = pX2;
                pY1 = pY2;
            }
        
            pX2 = pX1;
            pY2 = pY1;
            
            arrX1 = arrX1 + ',' + pX1;        
            arrY1 = arrY1 + ',' + pY1;
            arrX2 = arrX2 + ',' + pX2;
            arrY2 = arrY2 + ',' + pY2;
        }
        
        if(flag == 1)
        {
            if(browser == "Microsoft Internet Explorer") //브라우저가 IE일때 돌아간다. 크롬에서 써도 잘 된다.
            {   
                pX2 = event.x;
                pY2 = event.y;
            }
            else //그외(파이어폭스)일 때 돌아간다.
            {   
                pX2 = e.clientX;
                pY2 = e.clientY;
            }
        
            var xGap = pX1 - pX2;
            var yGap = pY1 - pY2;
            
            if(xGap != yGap)
            {
                if( Math.abs(xGap) > Math.abs(yGap))  // y 축 기준
                {
                    pY2 = pY1;
                }
                else                                  // x 축 기준
                {
                    pX2 = pX1;
                }
            }
            
            arrX1 = arrX1 + ',' + pX1;        
            arrY1 = arrY1 + ',' + pY1;
            arrX2 = arrX2 + ',' + pX2;
            arrY2 = arrY2 + ',' + pY2;
            
        }

        if (window.event) event.cancelBubble = true;

        jg2.setColor("#008800");
        jg2.setStroke(2);
        jg2.drawLine(pX1, pY1, pX2, pY2);
        
        if(flag > -1)
            jg2.paint();
        
    }
}



//function doManualDrawing(){  
//jg2.setColor('#008800'); 
// var xy = getXY('tblContent','tbl_0_1003','tbl_82_').split('_'); 
//var x1 = xy[0];  
//var y1 = xy[1];  
//jg2.drawLine( 377,	278,	377,	259);  
//jg2.drawLine( 377,	259,	541,	259);  
//jg2.drawLine( 541,	259,	541,	278);   
//jg2.paint(); }




//var jg2 = new jsGraphics('lblStgMap');
//var jg2 = new jsGraphics("divLine");



//-->
         var jg2 = new jsGraphics('divLine');
     </script>
</body>
</html>
