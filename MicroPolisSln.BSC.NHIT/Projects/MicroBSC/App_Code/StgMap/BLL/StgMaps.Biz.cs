using System;
using System.Collections;
using System.Data;
using System.Text;


using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;

namespace MicroBSC.Biz.BSC
{
    public class StgMaps_Biz : StgMaps_Data
    {
        private int ESTTERM_REF_ID  = 0;
        private int EST_DEPT_REF_ID = 0;
        private string TMCODE       = "";
        private string FULLSCREEN = "N";
        private string STR_MANUAL_SCRIPT = "";

        private int _est_year;
        private string _est_month;

        private string _stg_map_name                = "lblStgMap";
        private string _src_js_file_path            = "../_common/js/stg_map_graphics.js";
        private int _html_stroke_width              = 1;
        private bool _is_used_dot                   = false;
        private bool _isKpiListVisible              = false;
        private bool _is_blank                      = false;

        private string STR_INIT_SCRIPT              = "";
        private string STR_CONTENT_SCRIPT           = "";
        private string STR_EXECUT_FUN_SCRIPT        = "";
        //private string[] _html_vertical_div_col     = null;

        private string[] TABLE_TD_COL_LEVEL         = null;

        private string _script_header               = "";
        private string _script_content              = "";
        private string _script_footer               = "";
        private string _script_stg_map              = "";
        //private string _script_stg_map_row_line     = "";
        private string _script_image_path           = "../images/stg/";

        private string _signal_image_path           = string.Format("../images/org/signal_set{0}/", WebUtility.GetConfig("DTree.SignalSet"));

        private string _lineType                    = "0";
        private string _dedug_str                   = "";
        private int _view_type                      = 0;

        private string _working_yn                  = "N";

        private StgMapTables_Biz stgMapTable        = null;
        private DataTable _dtVertical               = null;
        private Hashtable hashTable                 = new Hashtable();

        public string Script_Header     { get { return _script_header;  } }
        public string Script_Content    { get { return _script_content; } }
        public string Script_Footer     { get { return _script_footer;  } }
        public string Script_Stg_Map    { get { return _script_stg_map; } }
        public string DEBUG_STR         { get { return _dedug_str; } }
        public LineType StgLineType 
        {
            set
            {
                if (value == LineType.Straight)
                {
                    _lineType = "0";
                } 
                else if (value == LineType.Diagonal)
                {
                    _lineType = "1";
                }
            }
        }

        public StgMaps_Biz()
        {
        
        }

        public StgMaps_Biz(int est_year
                        , string est_month
                        , int estterm_ref_id
                        , int est_dept_ref_id
                        , int map_version_id
                        , bool isVisible
                        , LineType lineType
                        , int view_type
                        , string _fullscreen)
            : base(estterm_ref_id, est_dept_ref_id, est_month, map_version_id) 
        {
            ESTTERM_REF_ID  = estterm_ref_id;
            EST_DEPT_REF_ID = est_dept_ref_id;
            TMCODE          = est_month;
            FULLSCREEN      = _fullscreen;

            int stgMapTypeCount = GetStgMapTypeCount();
            TABLE_TD_COL_LEVEL  = new string[stgMapTypeCount];

            _est_year           = est_year;
            _est_month          = est_month;
            _isKpiListVisible   = isVisible;
            _view_type          = view_type;

            if (lineType == LineType.Straight)
            {
                _lineType = "0";
            }
            else if (lineType == LineType.Diagonal)
            {
                _lineType = "1";
            }

            stgMapTable = new StgMapTables_Biz(est_year
                                                , est_month
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , map_version_id
                                                , _script_image_path
                                                , _isKpiListVisible
                                                , _view_type
                                                , FULLSCREEN);

            stgMapTable.SignalImagePaht = _signal_image_path;

            for (int i = 0; i < TABLE_TD_COL_LEVEL.Length; i++) 
            {
                TABLE_TD_COL_LEVEL[i] = stgMapTable.GetStgMapTypeScript(i);
            }

            
            GetHtmlStgMap();
            InitScript();
            BindStgMap();
            
        }

        public StgMaps_Biz(int est_year
                        , string est_month
                        , int estterm_ref_id
                        , int est_dept_ref_id
                        , int map_version_id
                        , bool isVisible
                        , LineType lineType
                        , int view_type
                        , string working_yn
                        , string fullscreen)
            : base(estterm_ref_id, est_dept_ref_id, est_month, map_version_id)
        {
            ESTTERM_REF_ID = estterm_ref_id;
            EST_DEPT_REF_ID = est_dept_ref_id;
            TMCODE = est_month;

            int stgMapTypeCount = GetStgMapTypeCount();
            TABLE_TD_COL_LEVEL = new string[stgMapTypeCount];

            _est_year = est_year;
            _est_month = est_month;
            _isKpiListVisible = isVisible;
            _view_type = view_type;
            _working_yn = working_yn;

            if (lineType == LineType.Straight)
            {
                _lineType = "0";
            }
            else if (lineType == LineType.Diagonal)
            {
                _lineType = "1";
            }

            stgMapTable = new StgMapTables_Biz(est_year
                                                , est_month
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , map_version_id
                                                , _script_image_path
                                                , _isKpiListVisible
                                                , _view_type
                                                , _working_yn
                                                , fullscreen);

            stgMapTable.SignalImagePaht = _signal_image_path;

            for (int i = 0; i < TABLE_TD_COL_LEVEL.Length; i++)
            {
                TABLE_TD_COL_LEVEL[i] = stgMapTable.GetStgMapTypeScript(i);
            }


            GetHtmlStgMap();
            InitScript();
            BindStgMap();

        }

        public StgMaps_Biz(int est_year
                        , string est_month
                        , int estterm_ref_id
                        , int est_dept_ref_id
                        , int map_version_id
                        , string stg_map_name
                        , string src_js_file_path
                        , string arrow_color
                        , int stroke_width
                        , bool is_used_dot
                        , int view_type) : base(estterm_ref_id, est_dept_ref_id, est_month, 0) 
        {
            ESTTERM_REF_ID = estterm_ref_id;
            EST_DEPT_REF_ID = est_dept_ref_id;
            TMCODE = est_month;


            int stgMapTypeCount = GetStgMapTypeCount();
            TABLE_TD_COL_LEVEL  = new string[stgMapTypeCount];

            _est_year           = est_year;
            _est_month          = est_month;
            _view_type          = view_type;

            stgMapTable = new StgMapTables_Biz(est_year
                                                , est_month
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , map_version_id
                                                , _script_image_path
                                                , _isKpiListVisible
                                                , _view_type
                                                , FULLSCREEN);

            stgMapTable.SignalImagePaht = _signal_image_path;

            for (int i = 0; i < TABLE_TD_COL_LEVEL.Length; i++)
            {
                TABLE_TD_COL_LEVEL[i] = stgMapTable.GetStgMapTypeScript(i);
            }

            _stg_map_name       = stg_map_name;
            _src_js_file_path   = src_js_file_path;
            _html_stroke_width  = stroke_width;
            _is_used_dot        = is_used_dot;

            
            GetHtmlStgMap();
            InitScript();
            BindStgMap();
        }

        public StgMaps_Biz(int est_year
                            , string est_month
                            , int estterm_ref_id
                            , int est_dept_ref_id
                            , int map_version_id
                            , int stg_map_id) : base(estterm_ref_id, est_dept_ref_id, stg_map_id, est_month, map_version_id) 
        {
            int stgMapTypeCount = GetStgMapTypeCount();
            TABLE_TD_COL_LEVEL  = new string[stgMapTypeCount];

            _est_year = est_year;
            _est_month = est_month;
        }

        public void InitScript()
        {
            string dot_line;
            dot_line = "";

            if (!_is_used_dot)
                dot_line = "//";

            string script = @"  
                                <script type='text/javascript' src='" + _src_js_file_path + @"'></script>
	                            <script type='text/javascript'>
                                function VisibleSpan(obj)  
                                {  
                                    var objStyle = eval('document.all.' + obj + '.style');
                                    var objImage = document.getElementById('img_' + obj); 
                                    
                                    if (objStyle.display == 'block')
                                    {
            	                        objStyle.display    = 'none';
            	                        objImage.src        = '" + _script_image_path + @"map_jt13_down.gif';
                                    }
                                    else 
                                    {
            	                        objStyle.display    = 'block';
            	                        objImage.src        = '" + _script_image_path + @"map_jt13_up.gif';
                                    }
                                }

                                function myDrawFunction(m_tbl_id, p_tbl_id, c_tbl_id, p_child_id, c_child_id, compareLevel, sequence, stg_map_type, clicked_stg_ref_id, lineType)
                                {
                                    var isClicked = false;
                                    
                                    if(c_child_id.replace('tbl_','').replace('_','') == clicked_stg_ref_id)
                                    {
                                        isClicked = true;
                                    }

                                    var sideValue       = 10;
                                    var upLevelValue    = 4 + sequence * 2;
                                    var sameLevelValue  = 13 + sequence * 2;
                                    var downLevelValue  = 9  - sequence * 2;

                                    var top_arrow_height    = -2;
                                    var same_arrow_height   = 0;
                                    var down_arrow_height   = 18;

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
                                    
                                    var c_tbl_object    = document.getElementById(c_tbl_id);
                                    var c_tbl_top       = parseInt(t_top    + c_tbl_object.parentElement.offsetTop      + c_tbl_object.offsetTop);
                                    var c_tbl_left      = parseInt(t_left   + c_tbl_object.parentElement.offsetLeft     + c_tbl_object.offsetLeft);
                                    var c_tbl_width     = parseInt(c_tbl_object.offsetWidth);
                                    var c_tbl_height    = parseInt(c_tbl_object.offsetHeight);
                                
                                    var p_object        = document.getElementById(p_child_id);
                                    var p_top           = parseInt(p_tbl_top     + p_object.parentElement.offsetTop      + p_object.offsetTop);
                                    var p_left          = parseInt(p_tbl_left    + p_object.parentElement.offsetLeft     + p_object.offsetLeft);
                                    var p_width         = parseInt(p_object.offsetWidth);
                                    var p_height        = parseInt(p_object.offsetHeight);
                                    
                                    var c_object        = document.getElementById(c_child_id);
                                    var c_top           = parseInt(c_tbl_top    + c_object.parentElement.offsetTop       + c_object.offsetTop);
                                    var c_left          = parseInt(c_tbl_left   + c_object.parentElement.offsetLeft      + c_object.offsetLeft);
                                    var c_width         = parseInt(c_object.offsetWidth);
                                    var c_height        = parseInt(c_object.offsetHeight);
                                    
                                    // -------- 화살표 그리기 ----------
                                    // ( 자식_LEFT + 자식_HEIGHT/2  , 자식_TOP )                 -> ( 자식_LEFT + 자식_HEIGHT/2  , 자식_TOP + 임의상수 )
                                    // ( 자식_LEFT + 자식_HEIGHT/2  , 자식_TOP + 임의상수 )      -> ( 부모_LEFT + 부모_WIDTH/2   , 자식_TOP + 임의상수 )
                                    // ( 부모_LEFT + 부모_WIDTH/2   , 자식_TOP + 임의상수 )      -> ( 부모_LEFT + 부모_WIDTH/2   , 부모_TOP + 부모_HEIGHT )
                                    
                                    if(compareLevel > 0) 
                                    {
                                        if(isClicked) 
                                        {
                                            jg.setColor('00ff00');
                                            jg.setStroke(2);
                                        }
                                        else
                                        {
                                            jg.setColor('gray');
                                            jg.setStroke(" + _html_stroke_width.ToString() + @");
                                        }
                                        
                                        //jg.setStroke(Stroke.DOTTED);

                                        if(lineType == '0') 
                                        {
                                            jg.drawLine(c_left + c_width/2, c_top + 2                , c_left + c_width/2, c_top - upLevelValue);
                                            jg.drawLine(c_left + c_width/2, c_top - upLevelValue     , p_left + p_width/2, c_top - upLevelValue);
                                            jg.drawLine(p_left + p_width/2, c_top - upLevelValue     , p_left + p_width/2, p_top + p_height + top_arrow_height);
                                            jg.fillPolygon(new Array(p_left + p_width/2 - 5, p_left + p_width/2, p_left + p_width/2 + 5, p_left + p_width/2), new Array(p_top + p_height + 8 + top_arrow_height, p_top + p_height + top_arrow_height, p_top + p_height + 8 + top_arrow_height, p_top + p_height + 8 + top_arrow_height));
                                        }
                                        else if(lineType == '1')  
                                        {
                                            jg.drawLine(c_left + c_width/2, c_top + 2                    , p_left + p_width/2, p_top + p_height - 4);
                                            jg.fillEllipse(p_left + p_width/2 - 3, p_top + p_height - 4 - 3, 6, 6);
                                        }
                                        else if(lineType == '2') 
                                        {
                                        	jg.setColor('#C0E0FF');
                                        	
                                            jg.fillRect(c_left + c_width/2 - 40, p_top + p_height + top_arrow_height + 20                , 80, c_top + 2 - (p_top + p_height + top_arrow_height + 23) );
                                            jg.fillPolygon(new Array(c_left + p_width/2 - 80, c_left + c_width/2, c_left + c_width/2 + 80, c_left + c_width/2), new Array(p_top + p_height + top_arrow_height + 21,         p_top + p_height + top_arrow_height + 21,             p_top + p_height + top_arrow_height + 21,             p_top + p_height + top_arrow_height + 5 ));
                                        }
                                    }
                                    else if(compareLevel == 0) 
                                    {
                                        if(isClicked) 
                                        {
                                            jg.setColor('00ff00');
                                            jg.setStroke(2);
                                        }
                                        else
                                        {
                                            jg.setColor('blue');
                                            jg.setStroke(" + _html_stroke_width.ToString() + @");
                                        }
                                        
                                        //jg.setStroke(Stroke.DOTTED);
                                        jg.drawLine(c_left + c_width/2 - sideValue, c_top                   , c_left + c_width/2 - sideValue, c_top - sameLevelValue);
                                        jg.drawLine(c_left + c_width/2 - sideValue, c_top - sameLevelValue  , p_left + p_width/2 - sideValue, c_top - sameLevelValue);
                                        jg.drawLine(p_left + p_width/2 - sideValue, c_top - sameLevelValue  , p_left + p_width/2 - sideValue, p_top + same_arrow_height);
                                        jg.fillPolygon(new Array(p_left + p_width/2 - 5 - sideValue, p_left + p_width/2 - sideValue, p_left + p_width/2 + 5 - sideValue, p_left + p_width/2 - sideValue), new Array(p_top - 8 + same_arrow_height, p_top - 8 + same_arrow_height, p_top - 8 + same_arrow_height, p_top + same_arrow_height));
                                    }
                                    else if(compareLevel < 0) 
                                    {
                                        if(isClicked) 
                                        {
                                            jg.setColor('00ff00');
                                            jg.setStroke(2);
                                        }
                                        else
                                        {
                                            jg.setColor('green');
                                            jg.setStroke(" + _html_stroke_width.ToString() + @");
                                        }
                                        
                                        //jg.setStroke(Stroke.DOTTED);
                                        jg.drawLine(c_left + c_width/2 + sideValue, c_top + c_height                    , c_left + c_width/2 + sideValue, c_top + c_height + downLevelValue);
                                        jg.drawLine(c_left + c_width/2 + sideValue, c_top + c_height + downLevelValue   , p_left + p_width/2 + sideValue, c_top + c_height + downLevelValue);
                                        jg.drawLine(p_left + p_width/2 + sideValue, c_top + c_height + downLevelValue   , p_left + p_width/2 + sideValue, p_top + down_arrow_height);
                                        jg.fillPolygon(new Array(p_left + p_width/2 - 5 + sideValue, p_left + p_width/2 + sideValue, p_left + p_width/2 + 5 + sideValue, p_left + p_width/2 + sideValue), new Array(p_top - 8 + down_arrow_height, p_top - 8 + down_arrow_height, p_top - 8 + down_arrow_height, p_top + down_arrow_height));
                                    }

                                    

                                    jg.paint();
                                }


                                function doManualDrawing()
                                {  
                                    //jg.clear(); 
                                    jg.setColor('red'); 
                                    
                                    "+STR_MANUAL_SCRIPT+ @"

                                    jg.paint(); 
                                } 

                                function doPrint()
                                {
                                    document.getElementById('ibtnPrint').style.display = 'none';
                                    window.print();
                                    document.getElementById('ibtnPrint').style.display = 'block';
                                }
                                                                    
                                var jg = new jsGraphics('" + _stg_map_name + @"');                                

                                </script>
                                ";

            STR_INIT_SCRIPT = script;
        }

        private void BindStgMap() 
        {
            string script = "function ExcuteFnc(clicked_stg_ref_id) \n{\n\tjg.clear(); \n" + STR_EXECUT_FUN_SCRIPT + " doManualDrawing();  } \nExcuteFnc(0); \nwindow.onload = ExcuteFnc; "
            + "\nwindow.onresize = function(){ExcuteFnc(0);}";

            _script_header  = STR_INIT_SCRIPT;
            _script_content = STR_CONTENT_SCRIPT;
            _script_footer  = GetScript(script);
                
                
            

            // 만약 전략맵이 없을 경우
            if (_is_blank)
            {
                _script_stg_map = _script_header + @"
                                    <table width='100%' height='100%' align='center'>
                                        <tr>
                                            <td align='center'>
                                                <table align='center' width='469' height='206' border='0' cellpadding='0' cellspacing='0' background='" + _script_image_path + @"notice_not_map.jpg'>
                                                    <tr>
                                                        <td colspan='3'>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td width='195'>&nbsp;</td>
                                                        <td width='142'>전략맵이 없습니다.</td>
                                                        <td width='124'>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan='3'>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>";
            }
            else 
            {
                _script_stg_map = _script_content + _script_header + _script_footer;
            }
        }
        
        /// <summary>
        /// 삭제 :  style='border:1px solid yellow'
        /// </summary>
        public void GetHtmlStgMap() 
        {
            int top_parent_count        = GetTopParentCount(1);

            DataRowCollection drCol     = GetTopParents(1).Tables[0].Rows;

            DataTable dt_NotChildren    = GetTopParents(2).Tables[0];

            if (top_parent_count == 0 && dt_NotChildren.Rows.Count == 0)
            {
                _is_blank = true;
                return;
            }

            // vertical_id를 사용하기 위해서
            SetVerticalDataTable(drCol);

            int i = 0;
            //for (; i < top_parent_count; i++) 
            //{
            //    SetHtmlLayer(drCol[i], i);
            //}
            SetHtmlLayer(drCol);
            i = drCol.Count + 1;

            //SetHtmlLayer_NotChildren(dt_NotChildren, i++);
            SetHtmlLayer_NotChildren(dt_NotChildren, 0);

            MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info bizComm = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
            DataTable dtComm = bizComm.GetCodeListPerCategory("BS0017", "Y").Tables[0];
            string strExMapKpiType = string.Empty;
            foreach (DataRow dr in dtComm.Rows)
            {
                strExMapKpiType += "<img src='{0}' alt='' />&nbsp;{1}&nbsp;&nbsp;&nbsp;";
                strExMapKpiType = string.Format(strExMapKpiType, dr["CODE_DESC"].ToString(), dr["CODE_NAME"].ToString());
            }

            //string strPrint = "<input name='ibtnPrint' align='absMiddle' class='ButtonOnScreen' id='ibtnPrint' onclick='window.print(); return false;' src='../images/btn/b_080.gif' />";
            string strPrint = "<img id='ibtnPrint' src='../images/btn/b_080.gif' alt='인쇄' onclick='doPrint();' style='cursor: pointer;' />";
            //string strPrint = "<asp:ImageButton ID='iBtnSearch' runat='server' CssClass='ButtonOnScreen' ImageUrl='../images/btn/b_080.gif' OnClientClick='window.print(); return false;' ImageAlign='AbsMiddle' />";
            string strPivotTopForWorkingMap = string.Empty;
            if (_working_yn == "Y" || _working_yn == "H")
                strPivotTopForWorkingMap = string.Format(@"
<table style='height: 20px; '>
    <tr>
        <td align='left' style='padding-left: 10px; padding-top: 5px; background-color: #edf0f5;'>
            <img ID='ibtnPivotWorkMap' runat='server' src='{0}' OnClick='return pivotWorkMap();' style='cursor: pointer;' />
        </td>
        <td style='padding-left: 5px;'>
            {1}
        </td>
        <td align='right'>
            {2}
        </td>
    </tr>
</table>
", (_working_yn == "Y" ? "../images/btn/b_135.gif" : "../images/btn/b_216.gif"), (FULLSCREEN == "Y" ? strExMapKpiType : "&nbsp;"), (FULLSCREEN == "Y" ? strPrint : "&nbsp;"));
            else
                strPivotTopForWorkingMap = string.Format(@"
<table style='height: 20px; width: 100%;'>
    <tr>
        <td style='padding-left: 5px;'>
            {0}
        </td>
        <td align='right'>
            {1}
        </td>
    </tr>
</table>
", (FULLSCREEN == "Y" ? strExMapKpiType : "&nbsp;"), (FULLSCREEN == "Y" ? strPrint : "&nbsp;"));

            STR_CONTENT_SCRIPT = strPivotTopForWorkingMap + string.Format("<div id='divLine' onmousedown='doDrawing(event,0)' onmouseup='doDrawing(event,1)'>\n\n<div id='{0}' style='width:100%;height:100%; background-color: #dce1e5;'>\n\n{1}\n\n</div>\n\n</div>"
                , _stg_map_name
                , MergeHtmlTableScript(TABLE_TD_COL_LEVEL, "<table id='tblContent' height='95%' cellpadding='0' cellspacing='0' border='0' width='100%'>"));
        }

        private void SetVerticalDataTable(DataRowCollection drCol) 
        {
            DataTable tempDt = null;

            _dtVertical = new DataTable();
            DataRow dr  = null;
            _dtVertical.Columns.Add("VERTICAL_ID", typeof(int));
            _dtVertical.Columns.Add("STG_REF_ID", typeof(int));

            for (int i = 0; i < drCol.Count; i++)
            {
                tempDt = GetStgMapList(Convert.ToInt32(drCol[i]["STG_REF_ID"])).Tables[0];

                for(int k = 0; k < tempDt.Rows.Count; k++) 
                {
                    dr                  = _dtVertical.NewRow();
                    dr["VERTICAL_ID"]   = i;
                    dr["STG_REF_ID"]    = tempDt.Rows[k]["STG_REF_ID"];
                    _dtVertical.Rows.Add(dr);
                }
            }
        }

/*
        private int GetVerticalID(int stg_ref_id) 
        {
            DataRow[] drArr = _dtVertical.Select("STG_REF_ID = " + stg_ref_id.ToString());
            if (drArr.Length > 0)
            {
                return (int)drArr[0]["VERTICAL_ID"];
            }

            return 0;
        }
*/
        
        /// <summary>
        /// 최상위 부모의 전략ID에 따른 전략Type별 작업
        /// </summary>
        private void SetHtmlLayer(DataRow dr, int vertical_id) 
        {
            DataTable dtStgMap          = GetStgMapList(Convert.ToInt32(dr["STG_REF_ID"])).Tables[0];
            DataTable dtStgMapTypeCol   = GetStgMapTypes();

            for (int i = 0; i < dtStgMapTypeCol.Rows.Count; i++)
            {
                GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = " + dtStgMapTypeCol.Rows[i]["VIEW_REF_ID"].ToString()), vertical_id, i, int.Parse(dtStgMapTypeCol.Rows[i]["VIEW_REF_ID"].ToString()));
                
            }

            //GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = 1"), vertical_id, 1);
            //GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = 2"), vertical_id, 2);
            //GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = 3"), vertical_id, 3);
            //GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = 4"), vertical_id, 4);
        }

        private void SetHtmlLayer(DataRowCollection dr)
        {
            DataTable dtStgMap = new DataTable();
            foreach (DataRow drd in dr)
            {
                dtStgMap.Merge(GetStgMapList(Convert.ToInt32(drd["STG_REF_ID"])).Tables[0]);
            }
            DataTable dtStgMapTypeCol = GetStgMapTypes();

            for (int i = 0; i < dtStgMapTypeCol.Rows.Count; i++)
            {
                if (dtStgMap.Rows.Count != 0)
                    GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = " + dtStgMapTypeCol.Rows[i]["VIEW_REF_ID"].ToString()), 0, i, int.Parse(dtStgMapTypeCol.Rows[i]["VIEW_REF_ID"].ToString()));

            }

            //GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = 1"), vertical_id, 1);
            //GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = 2"), vertical_id, 2);
            //GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = 3"), vertical_id, 3);
            //GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = 4"), vertical_id, 4);
        }

        private void SetHtmlLayer_NotChildren(DataTable dt, int vertical_id)
        {
            DataTable dtStgMap          = dt;
            DataTable dtStgMapTypeCol   = GetStgMapTypes();

            for (int i = 0; i < dtStgMapTypeCol.Rows.Count; i++)
            {
                GetHtmlLevelLayer(dtStgMap.Select("STG_MAP_TYPE = " + dtStgMapTypeCol.Rows[i]["VIEW_REF_ID"].ToString()), vertical_id, i, int.Parse(dtStgMapTypeCol.Rows[i]["VIEW_REF_ID"].ToString()));
            }
        }

        /// <summary>
        /// 전략 묶음 테이블 셀 반환
        /// </summary>
        public string content       = "";
        public string content_total = "";

        private void GetHtmlLevelLayer(DataRow[] drArray, int vertical_id, int index, int stg_map_type) 
        {
            content = "";

            for (int i = 0; i < drArray.Length; i++) 
            {
                content         += GetHtmlStgMapLayer(drArray[i], vertical_id);
                content_total   += content;
            }

            // 테이블 셀에 들어가는 테이블
            // <td>를 붙여줌
            // 레벨별로 문자열을 Merge 함
            // 삭제 : style='border:1px solid gray'

            string visibleStr = "";

            if (_working_yn == "Y" || _working_yn == "T")
            {
                if (_isKpiListVisible)
                    visibleStr = "<td valign='top' bgcolor='" + GetBgColor(index) + "'>\n<table height='90%' align='center' id='tbl_{0}_{1}'>\n\t<tr>\n\t\t{2}&nbsp;\n\t\t</td>\n\t</tr>\n</table>\n</td>\n";
                else
                    visibleStr = "<td bgcolor='" + GetBgColor(index) + "'>\n<table height='0' align='center' id='tbl_{0}_{1}'>\n\t<tr>\n\t\t{2}&nbsp;\n\t\t</td>\n\t</tr>\n</table>\n</td>\n";
            }
            else
            {
                if (_isKpiListVisible)
                    visibleStr = "<td valign='top' bgcolor='" + GetBgColor(index) + "'>\n<table height='90%' align='center' id='tbl_{0}_{1}' onclick='getUpTBL_ID(this)'>\n\t<tr>\n\t\t{2}&nbsp;\n\t\t</td>\n\t</tr>\n</table>\n</td>\n";
                else
                    visibleStr = "<td bgcolor='" + GetBgColor(index) + "'>\n<table height='0' align='center' id='tbl_{0}_{1}' onclick='getUpTBL_ID(this)'>\n\t<tr>\n\t\t{2}&nbsp;\n\t\t</td>\n\t</tr>\n</table>\n</td>\n";
            }
            if (drArray.Length > 0)
                TABLE_TD_COL_LEVEL[index] += string.Format(visibleStr, vertical_id, stg_map_type, content);
        }

        /// <summary>
        /// 최소단위인 전략테이블 반환
        /// </summary>
        private int temp_vertical_id    = 0;
        private int temp_stg_map_type   = 1;
        private int temp_sequence       = 0;

        // 화살표를 한번만 그리기 위해서
        private ArrayList stgMapIDsList = new ArrayList();
        private Biz_Bsc_View_Info viewInfo      = new Biz_Bsc_View_Info();

        private string GetHtmlStgMapLayer(DataRow dr, int vertical_id)
        {
            //string html_stg_mpa_script = string.Format("<td valign='top'>\n<div id='tbl_{0}'>{1}</div>\n<td>"
            //string html_stg_mpa_script = string.Format("<td valign='top'>\n<table height='100%' id='tbl_{0}'><tr><td>{1}</td></tr></table>\n<td>"
            //    , (int)dr["STG_REF_ID"]
            //    , stgMapTable.GetStgMapTableScript((int)dr["STG_REF_ID"], _isKpiListVisible));

            string html_stg_mpa_script = "";
            bool isContain = true;

            if (content_total.IndexOf(string.Format("tbl_{0}_", Convert.ToInt32(dr["STG_REF_ID"]))) < 0)
            {
                isContain = false;
                stgMapTable.SetStatusType = stgMapTable.GetStatusTypeByIndicator(Convert.ToInt32(dr["STG_REF_ID"]));

                string visibleHeight = "100%";

                if (_isKpiListVisible)
                {
                    visibleHeight = "100%";
                }
                else
                {
                    visibleHeight = "0";
                }
                //phdphd
                html_stg_mpa_script = string.Format("<td valign='top'>\n<table height='" + visibleHeight + @"' id='tbl_{0}_' onclick='doStartingEvent(this)' value='value_{0}_'><tr><td>{1}</td></tr></table>"
                                                    , Convert.ToInt32(dr["STG_REF_ID"])
                                                    , stgMapTable.GetStgMapTableScript(Convert.ToInt32(dr["STG_REF_ID"]), _isKpiListVisible));
            }

            // 최상위 부모가 아닌 Map_Type 인 경우 레이어에서 
            if (dr["UP_STG_ID"] != DBNull.Value) 
            {
                StgMaps_Biz stgMap_self = new StgMaps_Biz(_est_year, _est_month, EstTerm_Ref_ID, Est_Dept_Ref_ID, Map_Version_ID, Convert.ToInt32(dr["STG_REF_ID"]));
                StgMaps_Biz stgMap_up   = new StgMaps_Biz(_est_year, _est_month, EstTerm_Ref_ID, Est_Dept_Ref_ID, Map_Version_ID, Convert.ToInt32(dr["UP_STG_ID"]));
                int compareLevel        = stgMap_self.View_Seq - stgMap_up.View_Seq;

                // vertical_id 별 sequence 를 만들기 위해서
                if (vertical_id == temp_vertical_id && stgMap_self.Stg_Map_Type == temp_stg_map_type)
                {
                    temp_sequence++;

                    if (temp_sequence == 7)
                        temp_sequence = 1;
                }
                else
                {
                    temp_vertical_id    = vertical_id;
                    temp_stg_map_type   = stgMap_self.Stg_Map_Type;
                    temp_sequence       = 1;
                }

                //DataRowCollection drCol_Self = stgMap_self.GetMultiParentData().Tables[0].Rows;
                
                //, GetParentTableScript(GetVerticalID((int)dr["UP_STG_ID"]), GetStgMapType((int)dr["UP_STG_ID"]))
                //, GetParentTableScript(vertical_id, (int)dr["STG_MAP_TYPE"])

                // 모든 관계라인을 표현하기 위해서 선언한 변수
                string lineType = _lineType;

                // 최하위 관점일 경우만 화살표 처리
                if (stgMap_self.Stg_Map_Type == viewInfo.GetMaxViewRefID())
                {
                    if (stgMapIDsList.Contains(stgMap_self.Stg_Map_ID))
                    {
                        lineType = "";
                    }
                    else
                    {
                        if (stgMap_self.IsAllRelationed(stgMap_self.Stg_Map_ID))
                        {
                            lineType = "2";
                            stgMapIDsList.Add(stgMap_self.Stg_Map_ID);
                        }
                    }
                }

                string p_tbl_id = GetParentTableScript(GetVerticalIDByHashTable(Convert.ToInt32(dr["UP_STG_ID"]), vertical_id), GetStgMapType(Convert.ToInt32(dr["UP_STG_ID"])));
                string c_tbl_id = GetParentTableScript(GetVerticalIDByHashTable(Convert.ToInt32(dr["STG_REF_ID"]), vertical_id), Convert.ToInt32(dr["STG_MAP_TYPE"]));
                string p_child_id = GetChildTableScript(Convert.ToInt32(dr["UP_STG_ID"]));
                string c_child_id = GetChildTableScript(Convert.ToInt32(dr["STG_REF_ID"]));

                Biz_Bsc_Map_Stg_Manual_Biz biz = new Biz_Bsc_Map_Stg_Manual_Biz();
                DataSet ds = biz.Get_BSC_MAP_STG_MANUAL(ESTTERM_REF_ID
                                                      , EST_DEPT_REF_ID
                                                      , TMCODE
                                                      , c_tbl_id
                                                      , c_child_id
                                                      , p_tbl_id
                                                      , p_child_id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    STR_MANUAL_SCRIPT += DoManualdrawing(c_tbl_id, c_child_id, p_tbl_id, p_child_id);
                }
                else
                {
                    STR_EXECUT_FUN_SCRIPT += GetDrawArrowFunction("tblContent"
                                                                , p_tbl_id
                                                                , c_tbl_id
                                                                , p_child_id
                                                                , c_child_id
                                                                , compareLevel
                                                                , temp_sequence
                                                                , Convert.ToInt32(dr["STG_MAP_TYPE"])
                                                                , lineType);
                }

                // 최상위 부모거나 이전에 등록하지 않았던 전략ID개체 ID일경우만 전략맵을 생성한다.
                

                //// 부모가 2개 이상일 경우
                //if(stgMap_self.IsMultiParents())
                //{
                //    DataRowCollection drCol_Self = stgMap_self.GetMultiParentData().Tables[0].Rows;

                //    for (int i = 0; i < drCol_Self.Count; i++) 
                //    {
                //        STR_EXECUT_FUN_SCRIPT += GetDrawArrowFunction("tblContent"
                //                                                    //, GetParentTableScript(vertical_id, GetStgMapType((int)drCol_Self[i]["UP_STG_ID"]))
                //                                                    , GetParentTableScript(GetVerticalID((int)drCol_Self[i]["UP_STG_ID"]), GetStgMapType((int)drCol_Self[i]["UP_STG_ID"]))
                //                                                    , GetParentTableScript(vertical_id, (int)dr["STG_MAP_TYPE"])
                //                                                    , GetChildTableScript((int)drCol_Self[i]["UP_STG_ID"])
                //                                                    , GetChildTableScript((int)drCol_Self[i]["STG_REF_ID"])
                //                                                    , compareLevel
                //                                                    , temp_sequence
                //                                                    , (int)dr["STG_MAP_TYPE"]);
                //    }
                //}
            }

            if (!isContain)
            {
                AddHashTableByStgID(Convert.ToInt32(dr["STG_REF_ID"]), vertical_id);
            }

            return html_stg_mpa_script;
        }

        private static string GetScript(string content) 
        {
            return string.Format("\n<script type='text/javascript'>\n{0}\n</script>", content);
        }

        private static string GetDrawArrowFunction(string m_tbl_id, string p_tbl_id, string c_tbl_id, string p_child_id, string c_child_id, int compareLevel, int sequence, int stg_map_type, string lineType)
        {
            if (lineType.Equals(""))
                return "";

            return string.Format("\tmyDrawFunction('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, clicked_stg_ref_id, '{8}');\n", m_tbl_id, p_tbl_id, c_tbl_id, p_child_id, c_child_id, compareLevel, sequence, stg_map_type, lineType);
        }
        
        private static string GetChildTableScript(int stg_map_id) 
        {
            return string.Format("tbl_{0}_", stg_map_id);
        }

        private static string GetParentTableScript(int vertical_id, int stg_map_type)
        {
            return string.Format("tbl_{0}_{1}", vertical_id, stg_map_type);
        }

/*
        private static string MergeHtmlScript(string[] html_col)
        {
            string temp = "";

            for (int i = 0; i < html_col.Length; i++)
            {
                temp += html_col[i];
            }

            return temp;
        }
*/

        private string MergeHtmlTableScript(string[] html_col, string table_info_script)
        {
            string temp = "\n\n" + table_info_script;

            for (int i = 0; i < html_col.Length; i++)
            {
                temp += "\n\t<tr bgcolor='" + GetBgColor(i) + "'>";
                temp += html_col[i];
                temp += "\n\t</tr>";

                if (i < html_col.Length)
                {
                    temp += GetStgMapSplitLine(i);
                }
            }

            temp += "</table>";

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">tr 순서 (홀수, 짝수)</param>
        /// <returns></returns>
        private string GetStgMapSplitLine(int index) 
        {
            int top_parent_count = GetTopParentCount(1);

            if (IsNotContainChildrenParents())
                top_parent_count++;

            string temp = @"<tr> 
                                <td bgcolor='" + GetBgColor(index) + @"'>&nbsp;</td>
                                <td height='60' bgcolor='" + GetBgColor(index) + @"'>&nbsp;</td>
                             ";

            for (int i = 0; i <= top_parent_count; i++) 
            {
                temp += GetStgMapRowLine(index);
            }

            temp += "</tr>";

            return temp;
        }

        /// <summary>
        /// 전략간에 라인<td></td> html 만드는 메소드
        /// </summary>
        /// <param name="index">tr 순서 (홀수, 짝수)</param>
        /// <returns></returns>
        private string GetStgMapRowLine(int index) 
        {
            string bgColorStr = @"<td valign='bottom' bgcolor='" + GetBgColor(index) + @"'>
                                        <table width='100%' height='1' border='0' cellpadding='0' cellspacing='0' background='" + _script_image_path + @"map_jt12.gif'>
                                            <tr> 
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                    ";

            return bgColorStr;
        }      
/*
        private static string GetFieldValue(object fieldName, string returnStr)
        {
            if (fieldName == DBNull.Value)
                return returnStr;

            return fieldName.ToString();
        }
*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stg_map_id"></param>
        /// <param name="vertical_Id"></param>
        /// <returns></returns>
        private bool AddHashTableByStgID(int stg_map_id, int vertical_Id) 
        {
            if (!hashTable.Contains(stg_map_id)) 
            {
                hashTable.Add(stg_map_id, vertical_Id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stg_map_id"></param>
        /// <param name="vertical_id"></param>
        /// <returns></returns>
        private int GetVerticalIDByHashTable(int stg_map_id, int vertical_id) 
        {
            if (hashTable.ContainsKey(stg_map_id))
            {
                IDictionaryEnumerator myEnumerator = hashTable.GetEnumerator();
                while (myEnumerator.MoveNext()) 
                {
                    if ((int)myEnumerator.Key == stg_map_id)
                        return (int)myEnumerator.Value;
                }
            }

            return vertical_id;
        }

        private string GetBgColor(int index) 
        {
            string bgcolorStr = "";

            if ((index % 2) == 0)
                bgcolorStr = "#EDF0F5";
            else
                bgcolorStr = "#DCE1E5";

            return bgcolorStr;
        }

        #region =================================== 수동관계 그리기 ===================================

        private string DoManualdrawing(string st_up_tbl_id, string st_tbl_id, string ed_up_tbl_id, string ed_tbl_id)
        {
            string redrawing_script = string.Empty;

            Biz_Bsc_Map_Stg_Manual_Biz biz = new Biz_Bsc_Map_Stg_Manual_Biz();
            DataSet ds = biz.Get_BSC_MAP_STG_MANUAL(ESTTERM_REF_ID
                                                  , EST_DEPT_REF_ID
                                                  , TMCODE
                                                  , st_up_tbl_id
                                                  , st_tbl_id
                                                  , ed_up_tbl_id
                                                  , ed_tbl_id);

            string script_pointXY = " var xy = getXY('tblContent','{0}','{1}').split('_'); \nvar x1 = xy[0];  \nvar y1 = xy[1]; ";

            //script_pointXY += " alert(x1 +164); alert(y1); ";

            StringBuilder sbPoint = new StringBuilder();

            string point1 = " Number(x1) ";
            string point2 = " Number(y1) ";
            string point3 = " Number(x1) ";
            string point4 = " Number(y1) ";

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //foreach (DataRow row in ds.Tables[0].Rows)
                    //{
                    DataRow row = ds.Tables[0].Rows[i];

                    int x1 = DataTypeUtility.GetToInt32(row["X1"]);
                    int x2 = DataTypeUtility.GetToInt32(row["X2"]);
                    int y1 = DataTypeUtility.GetToInt32(row["Y1"]);
                    int y2 = DataTypeUtility.GetToInt32(row["Y2"]);

                    int seq = DataTypeUtility.GetToInt32(row["SEQ"]);

                    if (seq == 0)
                    {
                        point1 = " Number(x1) ";
                        point2 = " Number(y1) ";
                        point3 = " Number(x1) ";
                        point4 = " Number(y1) ";

                        st_up_tbl_id = row["ST_UP_TBL_ID"].ToString();
                        st_tbl_id = row["ST_TBL_ID"].ToString();
                        ed_up_tbl_id = row["ED_UP_TBL_ID"].ToString();
                        ed_tbl_id = row["ED_TBL_ID"].ToString();

                        sbPoint.Append(string.Format(script_pointXY, st_up_tbl_id, st_tbl_id));
                    }

                    if (x1 != x2)
                    {
                        if (x1 > x2)
                            point3 = point3 + "-" + DataTypeUtility.GetString(Math.Abs(x1 - x2));
                        else
                            point3 = point3 + "+" + DataTypeUtility.GetString(Math.Abs(x1 - x2));
                    }

                    if (y1 != y2)
                    {
                        if (y1 > y2)
                            point4 = point4 + "-" + DataTypeUtility.GetString(Math.Abs(y1 - y2));
                        else
                            point4 = point4 + "+" + DataTypeUtility.GetString(Math.Abs(y1 - y2));
                    }

                    string line_point = string.Format(" \njg.drawLine({0}, {1}, {2}, {3}); ", point1, point2, point3, point4);

                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        string[] stTemp = st_up_tbl_id.Split('_');
                        string[] edTemp = ed_up_tbl_id.Split('_');

                        if (stTemp[stTemp.Length - 1] == edTemp[edTemp.Length - 1])
                        {
                            line_point = string.Format(@"
var temp = getXY('tblContent','" + ed_up_tbl_id + @"','" + ed_tbl_id + @"').split('_');

var y2 = temp[1];

jg.drawLine({0}, {1}, {2}, y2); ", point1, point2, point3, point4);
                        }
                        else
                        {

                            line_point = string.Format(@"
var temp = getXY('tblContent','" + ed_up_tbl_id + @"','" + ed_tbl_id + @"').split('_');

var y2 = temp[3];

jg.drawLine({0}, {1}, {2}, y2); ", point1, point2, point3, point4);
                        }
                    }

                    sbPoint.Append(line_point);

                    point1 = point3;
                    point2 = point4;
                }

                redrawing_script = sbPoint.ToString();

                //redrawing_script = " jg2.setColor('#008800'); "
                //                 + sbPoint.ToString();
                //+"  } ";
                //+ "  jg2.paint(); ";

                //redrawing_script = "  function doManualDrawing(){  jg2.clear(); jg2.setColor('#008800'); "
                //                 + sbPoint.ToString()
                //    //+ "  } ";
                //+ "  jg2.paint(); } var jg2 = new jsGraphics('divLine');";
            }
            else
            {
                redrawing_script = "   ";
            }

            return redrawing_script;
        }


        #endregion
    }
}
