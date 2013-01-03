<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST060300.aspx.cs" Inherits="EST_EST060300" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>
    <style type="text/css">
		.font01 {font-size: 11px; font-family: "돋움"; color:#FFFFFF; text-align:center; padding-top:3;}
		.font02 {font-size: 11px; font-family: "돋움"; color:#000000; text-align:center; padding-top:3;}
		.font03 {font-size: 11px; font-family: "돋움"; color:#000000; text-align:left; padding-top:3; padding-left:5;}
	 </style>

<form id="form1" runat="server">
	 
	<script src="../_common/js/stg_map_graphics.js"></script>
	<script type="text/javascript">
        
        function ViewEmpList(comp_id, est_id, estterm_ref_id, rel_grp_id)
        {            
	        gfOpenWindow( "EST040105.aspx?COMP_ID="             + comp_id
	                                    + "&EST_ID="	        + est_id
                                        + "&ESTTERM_REF_ID="	+ estterm_ref_id
                                        + "&REL_GRP_ID="	    + rel_grp_id
                                       , 680
                                       , 450
                                       , true
                                       , true
                                       , "popup_est_tgt_map" );
	        return false;
        }
        
		// 객체(div)의 윗선의 중간좌표 리턴
		function GetTopPoint( Obj )
		{
			Obj			= document.all[Obj];
		
			var top		= parseInt( Obj.offsetTop );
			var left		= parseInt( Obj.offsetLeft );
			var width	= parseInt( Obj.offsetWidth );

			var Point	= new Object();
			Point.x		= left + ( width / 2 );
			Point.y		= top;

			return Point;
		}

		// 객체(div)의 아래선의 중간좌표 리턴
		function GetBottomPoint( Obj )
		{
			Obj			= document.all[Obj];
		
			var top		= parseInt( Obj.offsetTop );
			var left		= parseInt( Obj.offsetLeft );
			var width	= parseInt( Obj.offsetWidth );
			var height	= parseInt( Obj.offsetHeight );

			var Point	= new Object();
			Point.x		= left + ( width / 2 );
			Point.y		= top + height;

			return Point;
		}

		// 레벨선, 중간선 그리기
		// 부모 - 자식노드( 시작노드, 끝노드)만 있으면 노드간의 선을 그려줌
		function DrawLevelLine( ParentObj, FirstObj, LastObj, jg )
		{	
			var ParentBottom	= GetBottomPoint( ParentObj );
			var FirstTop			= GetTopPoint( FirstObj );
			var LastTop			= GetTopPoint( LastObj );

			// 버젼1 : 상위노드와 시작노드(자식노드에서 시작노드)의 중간지점 높이
//			var LevelLineY = ( ( FirstTop.y + ParentBottom.y ) / 2 ) + 3;

			// 버젼2 : 시작노드 높이에서 위로(-) 15 뺌
			var LevelLineY = FirstTop.y - 15;
			
			// 중간선 그릴때 필요 - 레벨선의 시작X좌표
			var LevelLineXCenter = ( FirstTop.x + LastTop.x ) / 2;
			
			// 중간선 그릴때 필요 - 중간선의 Y좌표
			var BetweenY = ( ParentBottom.y + LevelLineY ) / 2;
			
			// 메인 - 레벨선
			// 3번에 그림 1) 메인 - 사이선(메인과 레벨선의 사이 중앙)
			//					2) 중간선 - 레벨선 위
			//					3) 레벨선 위 - 레벨선 아래
			// 조건) 메인Botton.x 좌표 == 레벨선 중앙.x
			if ( ParentBottom.x == LevelLineXCenter )
			{
				// 자식노드 바로위에 부모노드가 있는경우 : 수직선임.
				jg.drawLine( ParentBottom.x, ParentBottom.y, ParentBottom.x, LevelLineY );							
			}
			else
			{
				// 자식노드 바로위에 부모노드가 없는경우 : 선을 3번 꺽어서 그린다. 
				var Xpoints = new Array( ParentBottom.x, ParentBottom.x, LevelLineXCenter, LevelLineXCenter );
				var YPoints = new Array( ParentBottom.y, BetweenY, BetweenY, LevelLineY );
				jg.drawPolyline( Xpoints, YPoints );
			}

			// 메인 - 레벨선 버젼1) 사선 - 테이블중간에서 레벨선중간까지 사선으로 그림(직선이 아닌 사선버젼)
//			jg.drawLine( ParentBottom.x, ParentBottom.y, LevelLineXCenter, LevelLine );			
			
			// 메인 - 레벨선 버젼2) 처음노드 - 마지막 노드 선 그리기
			jg.drawLine( FirstTop.x, LevelLineY, LastTop.x, LevelLineY );	
			jg.drawLine( FirstTop.x, LevelLineY, FirstTop.x, FirstTop.y - 1 ); // 접점차이때문에 -1
			jg.drawLine( LastTop.x, LevelLineY, LastTop.x, LastTop.y - 1 ); // 접점차이때문에 -1
			jg.paint();
		}
		
		// 윗선 그리기
		// 해당테이블의 윗 중간에서 레벨선 높이까지의 윗선 그리기
		function DrawUpperLine( ParentObj, ThisObj, jg )
		{
			var ParentBottom	= GetBottomPoint( ParentObj );
			var ThisTop			= GetTopPoint( ThisObj );
			
			ParentObj		= document.all[ParentObj];
			ThisObj			= document.all[ThisObj];
			
			var LevelLine = ( ThisTop.y + ParentBottom.y ) / 2;
			
			jg.drawLine( ThisTop.x, LevelLine, ThisTop.x, ThisTop.y - 1 );
			jg.paint();
		}

		// 부모 - 자식 선
		// 부모객체 하단에서 자식노드 상단까지의 수직선 그리기(부모,자식노드 X좌표가 다를때에는 사선으로 표시됨)
		function DrawVerticalLine( ParentObj, ThisObj, jg )
		{
			var ParentBottom	= GetBottomPoint( ParentObj );
			var ThisTop			= GetTopPoint( ThisObj );
			
			ParentObj		= document.all[ParentObj];
			ThisObj			= document.all[ThisObj];
			
			jg.drawLine( ParentBottom.x, ParentBottom.y, ThisTop.x, ThisTop.y - 1 );
			jg.paint();						
		}

	</script>
	<div>

<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    
	<table cellpadding="0" cellspacing="0" border="0" style="width:100%;">
		<tr>
			<td>
			    <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitleSingle">평가기간</td> 
                        <td class="cssTblContentSingle" > 
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
							<asp:ImageButton ID="ibnSearch" runat="server" ImageAlign="absMiddle" border="0" ImageUrl="../images/btn/b_033.gif" OnClick="ibnSearch_Click" visible="false" />
                        </td> 
                    </tr>
                   
                </table>
			</td>
		</tr>			
        <tr style="vertical-align: top; height:expression(eval(document.body.clientHeight) - 180)">
            <td>
                <table cellpadding="0" cellspacing="0" border="0" style="width:100%;height:100%">
	                <tr>        
                        <td style="width:200;">	
                            <div style="border:#F4F4F4 3px solid; overflow: auto; width: 100%; height: 100%" id="Div1">
                                <asp:TreeView ID="TreeView1"  runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Dotum" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                            <SJ:SmartScroller id="SmartScroller2" runat="server" TargetObject="Div1" MaintainScrollX="true" MaintainScrollY="true"></SJ:SmartScroller>
                        </td>
                        <td>	
                            <div id="divMapMain"    runat="server" style="border:solid 0px black;background-color:#EFEFEF;width: 100%;height:100%; overflow: auto"></div>
                            &nbsp;
                        </td>
                    </tr>
	            </table>
            </td>
        </tr>
	</table>

    <!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
	</div>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>