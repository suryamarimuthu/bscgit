<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST050300.aspx.cs" Inherits="EST_EST050300" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>
    <style type="text/css">
		.font01 {font-size: 11px; font-family: "돋움"; color:#FFFFFF; text-align:center; padding-top:3;}
		.font02 {font-size: 11px; font-family: "돋움"; color:#000000; text-align:center; padding-top:3;}
		.font03 {font-size: 11px; font-family: "돋움"; color:#000000; text-align:left; padding-top:3; padding-left:5;}	
		a:link  {color:#FFFFFF;text-decoration:none} 			
		a:active{color:#FFFFFF}
        a:visited{color:#FFFFFF;text-decoration:none}
        a:hover {color:#FFFFFF;text-decoration:none}
	
	 </style>

<form id="form1" runat="server">
			
	<script type="text/javascript" src="../_common/js/stg_map_graphics.js"></script>
	<script type="text/javascript">

		// 객체(div)의 윗선의 중간좌표 리턴
		function GetTopPoint( Obj )
		{
			Obj			= document.all[Obj];
		
			var top		= parseInt( Obj.offsetTop );
			var left	= parseInt( Obj.offsetLeft );
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
			var left	= parseInt( Obj.offsetLeft );
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
			var FirstTop		= GetTopPoint( FirstObj );
			var LastTop			= GetTopPoint( LastObj );

			// 버젼1 : 상위노드와 시작노드(자식노드에서 시작노드)의 중간지점 높이
//			var LevelLineY = ( ( FirstTop.y + ParentBottom.y ) / 2 ) + 3;

			// 버젼2 : 시작노드 높이에서 위로(-) 15 뺌
			var LevelLineY = FirstTop.y - 10;
			
			// 중간선 그릴때 필요 - 레벨선의 시작X좌표
			var LevelLineXCenter = ( FirstTop.x + LastTop.x ) / 2;
			
			// 중간선 그릴때 필요 - 중간선의 Y좌표
			var BetweenY = ( ParentBottom.y + LevelLineY ) / 2;
			
			// 메인 - 레벨선
			// 3번에 그림 1) 메인      - 사이선(메인과 레벨선의 사이 중앙)
			//			  2) 중간선    - 레벨선 위
			//			  3) 레벨선 위 - 레벨선 아래
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
			
			ParentObj		    = document.all[ParentObj];
			ThisObj			    = document.all[ThisObj];
			
			var LevelLine       = ( ThisTop.y + ParentBottom.y ) / 2;
			
			jg.drawLine( ThisTop.x, LevelLine, ThisTop.x, ThisTop.y - 1 );
			jg.paint();
		}

		// 부모 - 자식 선
		// 부모객체 하단에서 자식노드 상단까지의 수직선 그리기(부모,자식노드 X좌표가 다를때에는 사선으로 표시됨)
		function DrawVerticalLine( ParentObj, ThisObj, jg )
		{
			var ParentBottom	= GetBottomPoint( ParentObj );
			var ThisTop			= GetTopPoint( ThisObj );
			
			ParentObj		    = document.all[ParentObj];
			ThisObj			    = document.all[ThisObj];
			
			jg.drawLine( ParentBottom.x, ParentBottom.y, ThisTop.x, ThisTop.y - 1 );
			jg.paint();						
		}

	</script>
	
	
	<script type="text/javascript">
	    //"right","+20
		//"left","-440
			
	    function ViewJobList(comp_id, est_id, estterm_ref_id, estterm_sub_id)
        {            
	        gfOpenWindow( "EST050301.aspx?COMP_ID="             + comp_id
	                                    + "&EST_ID="	        + est_id
                                        + "&ESTTERM_REF_ID="	+ estterm_ref_id
                                        + "&ESTTERM_SUB_ID="	+ estterm_sub_id
                                       , 520
                                       , 430
                                       , true
                                       , true
                                       , "popup_est_tgt_map" );
	        return false;
        }
	    
	    function memview(viewurl)
	    {
	        var r = event.clientY + document.body.scrollTop - 90;
	        var b = event.clientX + document.body.scrollLeft + 20;
	        
	        document.all.mview.style.pixelTop	= r;
	        document.all.mview.style.pixelLeft	= b;
	        document.all.mview.style.display    = '';
	        document.all.pmview.src             = viewurl;
	    }

	    function move_memview()
	    {
	        var r = event.clientY + document.body.scrollTop - 90;
	        var b = event.clientX + document.body.scrollLeft + 20;
	        document.all.mview.style.pixelTop	= r;
	        document.all.mview.style.pixelLeft	= b;
	    }
	    
	    function hide_memview() 
	    {
	        document.all.mview.style.display = 'none';
	        document.all.pmview.src          = '' ;
	    }
	
	</script>
	
	<div id='mview' style='DISPLAY: none; Z-INDEX: 99; POSITION: absolute'>
		<table id='Tablemember' cellspacing='1' cellpadding='1' style="background-color:#5a69a7" border='0'>
			<tr>
			    <td style="background-color:#ffffff;">
			        <iframe width='400' height='250' name='pmview' id='pmview' frameborder='0'></iframe>
			    </td>
			</tr>
        </table>
    </div>
			
<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
         <tr>
            <td>
                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitleSingle">평가기간</td> 
                        <td class="cssTblContentSingle" colspan="3"> 
                            <asp:DropDownList id="ddlEstTermRefID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermRefID_SelectedIndexChanged"></asp:dropdownlist>
						            <asp:DropDownList id="ddlEstTermSubID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged"></asp:dropdownlist>
                        </td> 
                    </tr>
                   
                </table>
            </td>
	    </tr>
	    <tr>
            <td style="height:3px;">
                
            </td>
	    </tr>
	    <tr>
            <td align="right">
                <asp:ImageButton id="ibnAllEst" runat="server" ImageAlign="absMiddle" border="0" ImageUrl="../images/btn/tap_b04.gif" OnClick="ibnAllEst_Click" CommandName="BIZ_EST_MAP_WORK" Visible="False" />
                <asp:ImageButton id="ibnMyEst" runat="server" ImageAlign="absMiddle" border="0" ImageUrl="../images/btn/tap_b03.gif" OnClick="ibnMyEst_Click" />
                <asp:label id="lblCompTitle" runat="server"></asp:label>
                <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
	            <asp:ImageButton id="ibnSearch" runat="server" ImageAlign="absMiddle" border="0" ImageUrl="../images/btn/b_033.gif" OnClick="ibnSearch_Click" Visible="False" />
            </td>
	    </tr>
	    <tr>
            <td style="height:3px;">
                
            </td>
	    </tr>
	    <tr>
            <td style="height:100%;">
                <div id="divMapMain" runat="server" style="border:solid 0px black;background-color:#ffffff;height:100%; padding-top: 10px; text-align:center;"></div>
                <table cellpadding="0" cellspacing="0" width="100%" height="100%" id="tbGrid" runat="server">
                    <tr>
                        <td style="vertical-align: top; height:100%;">
                            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
					            <Bands>
						            <ig:UltraGridBand>
							            <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                </RowTemplateStyle>
						                <Columns>
							                <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="true">
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="EST_NAME" Key="EST_NAME" Width="150px">
								                <Header Caption="평가명">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Left"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT" Width="80px" Hidden="true">
								                <Header Caption="가중치">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="EST_CNT" Key="EST_CNT" Width="180px">
								                <Header Caption="내가 평가해야할 건수">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="OPN_CNT" Key="OPN_CNT" Width="180px">
								                <Header Caption="내가 의견상신 해야할 건수">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							                <ig:UltraGridColumn BaseColumnName="FBK_CNT" Key="FBK_CNT" Width="180px">
								                <Header Caption="내가 피드백 해야할 건수">
									                <RowLayoutColumnInfo OriginX="1" />
								                </Header>
								                <HeaderStyle HorizontalAlign="Center" />
								                <CellStyle HorizontalAlign="Center"/>
								                <Footer>
									                <RowLayoutColumnInfo OriginX="1" />
								                </Footer>
							                </ig:UltraGridColumn>
							            </Columns>
						            </ig:UltraGridBand>
					            </Bands>
					            <DisplayLayout  CellPaddingDefault="2" 
					                            AllowColSizingDefault="Free" 
					                            AllowColumnMovingDefault="OnServer" 
					                            AllowDeleteDefault="Yes" 
					                            AllowSortingDefault="Yes" 
					                            BorderCollapseDefault="Separate" 
					                            HeaderClickActionDefault="SortMulti" 
					                            Name="UltraWebGrid1" 
					                            RowHeightDefault="20px" 
					                            RowSelectorsDefault="No" 
					                            SelectTypeRowDefault="Extended" 
					                            Version="4.00" 
					                            ViewType="Flat" 
					                            ReadOnly="LevelTwo"
					                            CellClickActionDefault="NotSet" 
					                            TableLayout="Fixed" 
					                            StationaryMargins="Header" 
					                            AutoGenerateColumns="False"
					                            OptimizeCSSClassNamesOutput="False">
					            <%--<GroupByBox>
						            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
					            </GroupByBox>
					            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
						            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
					            </GroupByRowStyleDefault>
					            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
						            <BorderDetails ColorTop="White" WidthTop="1px" />
					            </FooterStyleDefault>
					            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
						            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
						            <Padding Left="3px" />
					            </RowStyleDefault>
					            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					            </HeaderStyleDefault>
					            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
					            </FrameStyle>
					            <Pager>
						            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
							            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
						            </PagerStyle>
					            </Pager>
					            <AddNewBox Hidden="False">
						            <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
							            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
						            </BoxStyle>
					            </AddNewBox>
					            <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>--%>
            					
					            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
					            </DisplayLayout>
				            </ig:UltraWebGrid>	                                                       
                        </td>
                    </tr>
                </table>
            </td>
	    </tr>
	   
    </table>
    

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
	
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</form>

<%
    Response.WriteFile("../_common/html/CommonBottom.htm");
%>