using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using MicroBSC.Biz.BSC.Dac;
using MicroBSC.Estimation.Dac;
using MicroBSC.Data;
using MicroBSC.BSC.Biz;

namespace MicroBSC.Biz.BSC.Biz
{
    public class Biz_EstDeptOrgMaps
    {
        private int _estterm_ref_id                 = 0;
        private int _month                          = 0;

        private string[] _pos_home_str              = null;
        private string[] _pos_dept_str              = null;
        private string[] _pos_legend_str            = null;

        private string _image_org_dir               = null;
        private string _image_stg_dir               = null;

        private DataTable _sinal_ds                 = null;

        private string _script_dir                  = null;
        private string _script_str                  = null;

        private string _top_link                    = "";

        private string _script_my_function_str      = "";

        private int _emp_ref_id;
        private int _est_dept_ref_id;
        private string _dept_name;
        private string _view_yn_org;
        private int _header_img_org;
        private int _position_org;
        private int _sort_org;
        private int _dept_type;
        private string _dept_name_org;
        private bool _is_embed = false;
        private bool _is_show_all_signal = (System.Configuration.ConfigurationManager.AppSettings["DTree.ShowAllSignal"].ToString()=="Y") ? true : false;
        private string _signal_set       = System.Configuration.ConfigurationManager.AppSettings["DTree.SignalSet"].ToString();
        private string _signal_level     = System.Configuration.ConfigurationManager.AppSettings["DTree.SignalLevel"].ToString();
        private bool _include_Ext_Kpi_Score;

        private Biz_EstDeptOrgScoreInfos estDeptOrgScore_e = null;
        private Biz_EstDeptOrgScoreInfos estDeptOrgScore_g = null;
        private Biz_EstDeptOrgScoreInfos estDeptOrgScore_w = null;
        private Biz_EstDeptOrgScoreInfos estDeptOrgScore_a = null;
        private Biz_EstDeptOrgScoreInfos estDeptOrgScore_u = null;


        private Biz_EstDeptOrgScoreInfos estDeptOrgScore = null;

        private Biz_Bsc_Score_Card objScordCard     = null;
        private Dac_EstDeptOrgMaps _estDeptOrgMap   = null;

        private int deptTitleWidth;
        private int deptTitleHeight;
        private int signalPaddingRight;
        private string lineColor;
        private int lineWidth;



        public int DeptTitleWidth
        {
            get
            {
                return deptTitleWidth;
            }
            set
            {
                if (deptTitleWidth == value)
                    return;
                deptTitleWidth = value;
            }
        }

        public int DeptTitleHeight
        {
            get
            {
                return deptTitleHeight;
            }
            set
            {
                if (deptTitleHeight == value)
                    return;
                deptTitleHeight = value;
            }
        }

        public int SignalPaddingRight
        {
            get
            {
                return signalPaddingRight;
            }
            set
            {
                if (signalPaddingRight == value)
                    return;
                signalPaddingRight = value;
            }
        }

        public string LineColor
        {
            get
            {
                return lineColor;
            }
            set
            {
                if (lineColor == value)
                    return;
                lineColor = value;
            }
        }

        public int LineWidth
        {
            get
            {
                return lineWidth;
            }
            set
            {
                if (lineWidth == value)
                    return;
                lineWidth = value;
            }
        }

        public int Emp_Ref_ID
        {
            get
            {
                return _emp_ref_id;
            }
            set
            {
                if (_emp_ref_id == value)
                    return;
                _emp_ref_id = value;
            }
        }
        public int Est_Dept_Ref_ID
        {
            get
            {
                return _est_dept_ref_id;
            }
            set
            {
                if (_est_dept_ref_id == value)
                    return;
                _est_dept_ref_id = value;
            }
        }
        public int Estterm_Ref_ID
        {
            get
            {
                return _estterm_ref_id;
            }
            set
            {
                if (_estterm_ref_id == value)
                    return;
                _estterm_ref_id = value;
            }
        }
        public string Dept_Name
        {
            get
            {
                return _dept_name;
            }
            set
            {
                if (_dept_name == value)
                    return;
                _dept_name = value;
            }
        }
        public string Yiew_YN_Org
        {
            get
            {
                return _view_yn_org;
            }
            set
            {
                if (_view_yn_org == value)
                    return;
                _view_yn_org = value;
            }
        }
        public int Header_Img_Org
        {
            get
            {
                return _header_img_org;
            }
            set
            {
                if (_header_img_org == value)
                    return;
                _header_img_org = value;
            }
        }
        public int Position_Org
        {
            get
            {
                return _position_org;
            }
            set
            {
                if (_position_org == value)
                    return;
                _position_org = value;
            }
        }
        public int Sort_Org
        {
            get
            {
                return _sort_org;
            }
            set
            {
                if (_sort_org == value)
                    return;
                _sort_org = value;
            }
        }
        public string Dept_Name_Org
        {
            get
            {
                return _dept_name_org;
            }
            set
            {
                if (_dept_name_org == value)
                    return;
                _dept_name_org = value;
            }
        }
        public int Dept_Type
        {
            get
            {
                return _dept_type;
            }
            set
            {
                if (_dept_type == value)
                    return;
                _dept_type = value;
            }
        }
        public bool Is_Embed
        {
            get
            {
                return _is_embed;
            }
            set
            {
                if (_is_embed == value)
                    return;
                _is_embed = value;
            }
        }

        public bool Include_Ext_Kpi_Score
        {
            get
            {
                return _include_Ext_Kpi_Score;
            }
            set
            {
                if (_include_Ext_Kpi_Score == value)
                    return;
                _include_Ext_Kpi_Score = value;
            }
        }

        public Biz_EstDeptOrgMaps() 
        {
            _estDeptOrgMap      = new Dac_EstDeptOrgMaps();
        }

        public Biz_EstDeptOrgMaps(int est_dept_ref_id)
        {
            _estDeptOrgMap          = new Dac_EstDeptOrgMaps();
            DataTable dataTable     = _estDeptOrgMap.GetDeptOrgMaps(est_dept_ref_id);

            if (dataTable.Rows.Count == 1) 
            {
                DataRow dr = dataTable.Rows[0];
                _est_dept_ref_id    = (dr["EST_DEPT_REF_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _estterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _dept_name          = (dr["DEPT_NAME"]          == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_NAME"]);
                _view_yn_org        = (dr["VIEW_YN_ORG"]        == DBNull.Value) ? "N" : Convert.ToString(dr["VIEW_YN_ORG"]);
                _header_img_org     = (dr["HEADER_IMG_ORG"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["HEADER_IMG_ORG"]);
                _sort_org           = (dr["SORT_ORG"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORG"]);
                _dept_type          = (dr["DEPT_TYPE"]          == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_TYPE"]);
                _dept_name_org      = (dr["DEPT_NAME_ORG"]      == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_NAME_ORG"]);
            }
        }

        public Biz_EstDeptOrgMaps(int estterm_ref_id, int month) 
        {
            _estterm_ref_id     = estterm_ref_id;
            _month              = month;

            _pos_home_str       = new string[7];
            _pos_dept_str       = new string[7];
            _pos_legend_str     = new string[7];

            estDeptOrgScore_e   = new Biz_EstDeptOrgScoreInfos(estterm_ref_id,"E");
            estDeptOrgScore_g   = new Biz_EstDeptOrgScoreInfos(estterm_ref_id,"G");
            estDeptOrgScore_w   = new Biz_EstDeptOrgScoreInfos(estterm_ref_id,"W");
            estDeptOrgScore_a   = new Biz_EstDeptOrgScoreInfos(estterm_ref_id,"A");
            estDeptOrgScore_u   = new Biz_EstDeptOrgScoreInfos(estterm_ref_id,"U");

            estDeptOrgScore = new Biz_EstDeptOrgScoreInfos();
            DataTable dtDeptOrgScore = estDeptOrgScore.GetEstDeptOrgScoreInfos(estterm_ref_id).Tables[0];

            dtDeptOrgScore = DataTypeUtility.FilterSortDataTable(dtDeptOrgScore, "", "MAX_VALUE DESC");

            _estDeptOrgMap      = new Dac_EstDeptOrgMaps();

            SetBlankValue(_pos_home_str);
            SetBlankValue(_pos_dept_str);
            SetBlankValue(_pos_legend_str);

            string master_site = WebUtility.GetConfig("SITE", "")+"/";

            _image_org_dir = string.Format("../images/{0}org/", master_site);
            _image_stg_dir = string.Format("../images/{0}org/signal_set{1}/", master_site, _signal_set);

            _script_dir         = "../_common/js/";


            string legend = "";

            legend += @"<table width='152' height='100' border='0' cellpadding='0' cellspacing='0' background='" + _image_org_dir + @"org_legend_level" + dtDeptOrgScore.Rows.Count.ToString() + @".gif'>
                                            <tr>
                                              <td width='18'>&nbsp;</td>
                                              <td valign='top'>
            	                                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                                                    <tr>
                                                        <td height='5'></td>
                                                    </tr>";

            foreach(DataRow drScore in dtDeptOrgScore.Rows) 
            {
                legend += string.Format(@"<tr>
                                            <td height='22' align='center' style='font-size: 12px ; color:#FF0000; width:15px;'><p align='center'><img src='" + _image_stg_dir + @"icon_{0}.gif'></p></td>
                                            <td height='22' align='left' style='font-size: 12px ; color:navy; width:50px;'><p align='left'>{1}</p></td>
                                            <td height='22' align='left' style='font-size: 12px ; color:#FF0000'><p align='center'>{2} ~ {3}</p></td>
                                        </tr>"
                                        , drScore["SCORE_CODE"]
                                        , drScore["SCORE_NAME"]
                                        , DataTypeUtility.GetToDouble(drScore["MIN_VALUE"]).ToString("#,##0")
                                        , DataTypeUtility.GetToDouble(drScore["MAX_VALUE"]).ToString("#,##0"));
            }

            legend += @"                            </table>
                                               </td>
                                            </tr>
                                        </table>";


            _pos_legend_str[2] = legend;


            _sinal_ds       = _estDeptOrgMap.GetSignal(_estterm_ref_id, _month);

            _script_str     = @"
                                    <SCRIPT src='" + _script_dir + @"stg_map_graphics.js' type=text/javascript></SCRIPT>
                                    <SCRIPT src='" + _script_dir + @"common.js' type=text/javascript></SCRIPT>
                                    <SCRIPT type=text/javascript>
                                    function myDrawFunction(m_tbl_id, p_tbl_id, c_tbl_id, p_child_id, c_child_id, level_type)
                                    {
                                        var upLevelValue    		= 15;
                                        var sameLevelValue  		= 15;
                                        
                                        var top_arrow_height        = -2;
                                        var same_arrow_height       = 0;
                                    	
                                        var t_object                = document.getElementById(m_tbl_id);
                                        var t_top                   = parseInt(t_object.offsetTop);
                                        var t_left                  = parseInt(t_object.offsetLeft);
                                        var t_width                 = parseInt(t_object.offsetWidth);
                                        var t_height                = parseInt(t_object.offsetHeight);
                                        
                                        var p_tbl_object            = document.getElementById(p_tbl_id);
                                        var p_tbl_top               = parseInt(t_top    + p_tbl_object.parentElement.offsetTop      + p_tbl_object.offsetTop);
                                        var p_tbl_left              = parseInt(t_left   + p_tbl_object.parentElement.offsetLeft     + p_tbl_object.offsetLeft);
                                        var p_tbl_width             = parseInt(p_tbl_object.offsetWidth);
                                        var p_tbl_height            = parseInt(p_tbl_object.offsetHeight);
                                        
                                        var c_tbl_object            = document.getElementById(c_tbl_id);
                                        var c_tbl_top               = parseInt(t_top    + c_tbl_object.parentElement.offsetTop      + c_tbl_object.offsetTop);
                                        var c_tbl_left              = parseInt(t_left   + c_tbl_object.parentElement.offsetLeft     + c_tbl_object.offsetLeft);
                                        var c_tbl_width             = parseInt(c_tbl_object.offsetWidth);
                                        var c_tbl_height            = parseInt(c_tbl_object.offsetHeight);

                                        var p_object                = document.getElementById(p_child_id);
                                        var p_top                   = parseInt(p_tbl_top     + p_object.parentElement.offsetTop      + p_object.offsetTop);
                                        var p_left                  = parseInt(p_tbl_left    + p_object.parentElement.offsetLeft     + p_object.offsetLeft);
                                        var p_width                 = parseInt(p_object.offsetWidth);
                                        var p_height                = parseInt(p_object.offsetHeight);
                                        
                                        var c_object                = document.getElementById(c_child_id);
                                        var c_top                   = parseInt(c_tbl_top    + c_object.parentElement.offsetTop       + c_object.offsetTop);
                                        var c_left                  = parseInt(c_tbl_left   + c_object.parentElement.offsetLeft      + c_object.offsetLeft);
                                        var c_width                 = parseInt(c_object.offsetWidth);
                                        var c_height                = parseInt(c_object.offsetHeight);
                                        
                                        //jg.setColor('#FF8000');
                                        jg.setColor('#A6A6A6');
		                                jg.setStroke(1);
                                    		
		                                if(level_type == 0)
		                                {
	                                      jg.drawLine(c_left + c_width/2, c_top                     , c_left + c_width/2, c_top - sameLevelValue);
                                          jg.drawLine(c_left + c_width/2, c_top - sameLevelValue    , p_left + p_width/2, c_top - sameLevelValue);
                                          jg.drawLine(p_left + p_width/2, c_top - sameLevelValue    , p_left + p_width/2, p_top + same_arrow_height);
		                                }
		                                else if(level_type == 1)
		                                {
			                              jg.drawLine(c_left + c_width/2, c_top                     , c_left + c_width/2, c_top - upLevelValue);
	                                      jg.drawLine(c_left + c_width/2, c_top - upLevelValue      , p_left + p_width/2, c_top - upLevelValue);
	                                      jg.drawLine(p_left + p_width/2, c_top - upLevelValue      , p_left + p_width/2, p_top + p_height + top_arrow_height);	
		                                }
                                        
                                        jg.paint();
                                    }
                                    var jg = new jsGraphics('lblStgMap');
                                    </SCRIPT>
                                ";
        }


        /// <summary>
        /// 외부평가 점수를 반영한 부서점수 구하기
        /// </summary>
        /// <param name="estterm_ref_id"></param>
        /// <param name="month"></param>
        /// <param name="include_ext_score"></param>
        public Biz_EstDeptOrgMaps(int estterm_ref_id, int month, bool include_ext_score, string line_Color, string line_Width)
        {
            _estterm_ref_id = estterm_ref_id;
            _month = month;
            Include_Ext_Kpi_Score = include_ext_score;

            _pos_home_str = new string[7];
            _pos_dept_str = new string[7];
            _pos_legend_str = new string[7];

            estDeptOrgScore_e = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "E");
            estDeptOrgScore_g = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "G");
            estDeptOrgScore_w = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "W");
            estDeptOrgScore_a = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "A");
            estDeptOrgScore_u = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "U");

            estDeptOrgScore = new Biz_EstDeptOrgScoreInfos();
            DataTable dtDeptOrgScore = estDeptOrgScore.GetEstDeptOrgScoreInfos(estterm_ref_id).Tables[0];

            dtDeptOrgScore = DataTypeUtility.FilterSortDataTable(dtDeptOrgScore, "", "MAX_VALUE DESC");

            _estDeptOrgMap = new Dac_EstDeptOrgMaps();

            SetBlankValue(_pos_home_str);
            SetBlankValue(_pos_dept_str);
            SetBlankValue(_pos_legend_str);


            string master_site = WebUtility.GetConfig("SITE", "")+"/";

            _image_org_dir = string.Format("../images/{0}org/", master_site);
            _image_stg_dir = string.Format("../images/{0}org/signal_set{1}/", master_site, _signal_set);

            _script_dir = "../_common/js/";

            string legend = "";

            // 시그널 테이블 배경 있는거..
//            legend += @"<table width='152' height='100' border='0' cellpadding='0' cellspacing='0' background='" + _image_org_dir + @"org_legend_level" + dtDeptOrgScore.Rows.Count.ToString() + @".gif'>
//                                            <tr>
//                                              <td width='18'>&nbsp;</td>
//                                              <td valign='top'>
//            	                                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
//                                                    <tr>
//                                                        <td height='5'></td>
//                                                    </tr>";










            legend += @"<table width='152' height='100' border='0' cellpadding='0' cellspacing='0' >
                                            <tr>
                                              <td width='18'>&nbsp;</td>
                                              <td valign='top'>
            	                                  <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                                                    <tr>
                                                        <td height='5'></td>
                                                    </tr>";

            foreach (DataRow drScore in dtDeptOrgScore.Rows)
            {
                legend += string.Format(@"<tr>
                                            <td height='22' align='center'><p align='center'><img src='" + _image_stg_dir + @"icon_{0}.gif'></p></td>
                                            <td height='22' align='left' class='cssSignalTitle'><p align='left'>{1}</p></td>
                                            <td height='22' align='left' class='cssSignalImg'><p align='center'>{2} ~ {3}</p></td>
                                        </tr>"
                                        , drScore["SCORE_CODE"]
                                        , drScore["SCORE_NAME"]
                                        , DataTypeUtility.GetToDouble(drScore["MIN_VALUE"]).ToString("#,##0")
                                        , DataTypeUtility.GetToDouble(drScore["MAX_VALUE"]).ToString("#,##0"));
            }

            legend += @"                            </table>
                                               </td>
                                            </tr>
                                        </table>";













            










            _pos_legend_str[2] = legend;

            _sinal_ds = _estDeptOrgMap.GetSignal(_estterm_ref_id, _month, include_ext_score);

            _script_str = @"
                                    <SCRIPT src='" + _script_dir + @"stg_map_graphics.js' type=text/javascript></SCRIPT>
                                    <SCRIPT src='" + _script_dir + @"common.js' type=text/javascript></SCRIPT>
                                    <SCRIPT type=text/javascript>
                                    function myDrawFunction(m_tbl_id, p_tbl_id, c_tbl_id, p_child_id, c_child_id, level_type)
                                    {
                                        var upLevelValue    		= 15;
                                        var sameLevelValue  		= 15;
                                        
                                        var top_arrow_height        = -2;
                                        var same_arrow_height       = 0;
                                    	
                                        var t_object                = document.getElementById(m_tbl_id);
                                        var t_top                   = parseInt(t_object.offsetTop);
                                        var t_left                  = parseInt(t_object.offsetLeft);
                                        var t_width                 = parseInt(t_object.offsetWidth);
                                        var t_height                = parseInt(t_object.offsetHeight);
                                        
                                        var p_tbl_object            = document.getElementById(p_tbl_id);
                                        var p_tbl_top               = parseInt(t_top    + p_tbl_object.parentElement.offsetTop      + p_tbl_object.offsetTop);
                                        var p_tbl_left              = parseInt(t_left   + p_tbl_object.parentElement.offsetLeft     + p_tbl_object.offsetLeft);
                                        var p_tbl_width             = parseInt(p_tbl_object.offsetWidth);
                                        var p_tbl_height            = parseInt(p_tbl_object.offsetHeight);
                                        
                                        var c_tbl_object            = document.getElementById(c_tbl_id);
                                        var c_tbl_top               = parseInt(t_top    + c_tbl_object.parentElement.offsetTop      + c_tbl_object.offsetTop);
                                        var c_tbl_left              = parseInt(t_left   + c_tbl_object.parentElement.offsetLeft     + c_tbl_object.offsetLeft);
                                        var c_tbl_width             = parseInt(c_tbl_object.offsetWidth);
                                        var c_tbl_height            = parseInt(c_tbl_object.offsetHeight);

                                        var p_object                = document.getElementById(p_child_id);
                                        var p_top                   = parseInt(p_tbl_top     + p_object.parentElement.offsetTop      + p_object.offsetTop);
                                        var p_left                  = parseInt(p_tbl_left    + p_object.parentElement.offsetLeft     + p_object.offsetLeft);
                                        var p_width                 = parseInt(p_object.offsetWidth);
                                        var p_height                = parseInt(p_object.offsetHeight);
                                        
                                        var c_object                = document.getElementById(c_child_id);
                                        var c_top                   = parseInt(c_tbl_top    + c_object.parentElement.offsetTop       + c_object.offsetTop);
                                        var c_left                  = parseInt(c_tbl_left   + c_object.parentElement.offsetLeft      + c_object.offsetLeft);
                                        var c_width                 = parseInt(c_object.offsetWidth);
                                        var c_height                = parseInt(c_object.offsetHeight);
                                        
                                        //jg.setColor('#FF8000');
                                        jg.setColor('" + line_Color + @"');
		                                jg.setStroke(" + line_Width + @");
                                    		
		                                if(level_type == 0)
		                                {
	                                      jg.drawLine(c_left + c_width/2, c_top                     , c_left + c_width/2, c_top - sameLevelValue);
                                          jg.drawLine(c_left + c_width/2, c_top - sameLevelValue    , p_left + p_width/2, c_top - sameLevelValue);
                                          jg.drawLine(p_left + p_width/2, c_top - sameLevelValue    , p_left + p_width/2, p_top + same_arrow_height);
		                                }
		                                else if(level_type == 1)
		                                {
			                              jg.drawLine(c_left + c_width/2, c_top                     , c_left + c_width/2, c_top - upLevelValue);
	                                      jg.drawLine(c_left + c_width/2, c_top - upLevelValue      , p_left + p_width/2, c_top - upLevelValue);
	                                      jg.drawLine(p_left + p_width/2, c_top - upLevelValue      , p_left + p_width/2, p_top + p_height + top_arrow_height);	
		                                }
                                        
                                        jg.paint();
                                    }
                                    var jg = new jsGraphics('lblStgMap');
                                    </SCRIPT>
                                ";


        }




        /// <summary>
        /// 외부평가 점수를 반영한 부서점수 구하기, 범례 컬럼 수 지정
        /// </summary>
        /// <param name="estterm_ref_id"></param>
        /// <param name="month"></param>
        /// <param name="include_ext_score"></param>
        public Biz_EstDeptOrgMaps(int estterm_ref_id, int month, bool include_ext_score, string line_Color, string line_Width, int legend_colCnt)
        {
            _estterm_ref_id = estterm_ref_id;
            _month = month;
            Include_Ext_Kpi_Score = include_ext_score;

            _pos_home_str = new string[7];
            _pos_dept_str = new string[7];
            _pos_legend_str = new string[7];

            estDeptOrgScore_e = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "E");
            estDeptOrgScore_g = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "G");
            estDeptOrgScore_w = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "W");
            estDeptOrgScore_a = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "A");
            estDeptOrgScore_u = new Biz_EstDeptOrgScoreInfos(estterm_ref_id, "U");

            estDeptOrgScore = new Biz_EstDeptOrgScoreInfos();
            DataTable dtDeptOrgScore = estDeptOrgScore.GetEstDeptOrgScoreInfos(estterm_ref_id).Tables[0];

            dtDeptOrgScore = DataTypeUtility.FilterSortDataTable(dtDeptOrgScore, "", "MAX_VALUE DESC");

            _estDeptOrgMap = new Dac_EstDeptOrgMaps();

            SetBlankValue(_pos_home_str);
            SetBlankValue(_pos_dept_str);
            SetBlankValue(_pos_legend_str);


            string master_site = WebUtility.GetConfig("SITE", "") + "/";

            _image_org_dir = string.Format("../images/{0}org/", master_site);
            _image_stg_dir = string.Format("../images/{0}org/signal_set{1}/", master_site, _signal_set);

            _script_dir = "../_common/js/";

            string legend = "";

            int legendCnt = dtDeptOrgScore.Rows.Count;
            int max_legendTbl_rowCnt = (int)Math.Ceiling((double)legendCnt / legend_colCnt);
            int loopStart = 0;
            int loopEnd = 0;


            int tableWidth = 125 * legend_colCnt;
            int tableHeight = 142 / legend_colCnt;


            string bgImgUrl = _image_org_dir + "example.gif";


legend += string.Format(@"
            <div id='div_legend' style='position:absolute; top:0px; left:0px;'>
                <table width='{0}' height='{1}' border='0' cellpadding='0' cellspacing='0' style='text-align:center; vertical-align:middle; background-image:url({2}); background-repeat:no-repeat;'>
                    <tr>
                        <td>
                            <table border='0' cellspacing='0' cellpadding='0'>
                                <tr>", tableWidth.ToString(), tableHeight.ToString(), bgImgUrl);





            for (int i = 0; i < legend_colCnt; i++)
            {
                loopEnd = (legendCnt - loopStart) > 0 ? (int)Math.Ceiling((double)(legendCnt - loopStart) / (legend_colCnt - i)) : (int)Math.Floor((double)(legendCnt - loopStart) / (legend_colCnt - i));


                if (i > 0)
legend += @"                        <td style='width:30px;'>&nbsp;</td>";


                if (legendCnt >= loopStart + loopEnd)
                {
legend += @"                        <td>
                                        <table width='100%' border='0' cellspacing='0' cellpadding='0'>";


                    for (int j = loopStart; j < loopStart + loopEnd; j++)
                    {
                        DataRow drScore = dtDeptOrgScore.Rows[j];
legend += string.Format(@"                  <tr>
                                                <td height='22' align='center'><p align='center'><img src='" + _image_stg_dir + @"icon_{0}.gif'></p></td>
                                                <td height='22' align='left' class='cssSignalTitle'><p align='left'>{1}</p></td>
                                                <td height='22' align='left' class='cssSignalImg'><p align='center'>{2} ~ {3}</p></td>
                                            </tr>"
                                                                    , drScore["SCORE_CODE"]
                                                                    , drScore["SCORE_NAME"]
                                                                    , DataTypeUtility.GetToDouble(drScore["MIN_VALUE"]).ToString("#,##0")
                                                                    , DataTypeUtility.GetToDouble(drScore["MAX_VALUE"]).ToString("#,##0"));
                    }
                    for (int j = 0; j < max_legendTbl_rowCnt - loopEnd; j++)
                    { 
legend += @"                                <tr>
                                                <td>&nbsp;</td>
                                            </tr>";
                    }


legend += @"                            </table>
                                    </td>";

                    loopStart += loopEnd;
                }
            }




legend += @"                    </tr>
                            </table>
                       </td>
                    </tr>
                </table>
            </div>";




            _pos_legend_str[2] = legend;

            _sinal_ds = _estDeptOrgMap.GetSignal(_estterm_ref_id, _month, include_ext_score);

            _script_str = @"
                                    <SCRIPT src='" + _script_dir + @"stg_map_graphics.js' type=text/javascript></SCRIPT>
                                    <SCRIPT src='" + _script_dir + @"common.js' type=text/javascript></SCRIPT>
                                    <SCRIPT type=text/javascript>
                                    function myDrawFunction(m_tbl_id, p_tbl_id, c_tbl_id, p_child_id, c_child_id, level_type)
                                    {
                                        var upLevelValue    		= 15;
                                        var sameLevelValue  		= 15;
                                        
                                        var top_arrow_height        = -2;
                                        var same_arrow_height       = 0;
                                    	
                                        var t_object                = document.getElementById(m_tbl_id);
                                        var t_top                   = parseInt(t_object.offsetTop);
                                        var t_left                  = parseInt(t_object.offsetLeft);
                                        var t_width                 = parseInt(t_object.offsetWidth);
                                        var t_height                = parseInt(t_object.offsetHeight);
                                        
                                        var p_tbl_object            = document.getElementById(p_tbl_id);
                                        var p_tbl_top               = parseInt(t_top    + p_tbl_object.parentElement.offsetTop      + p_tbl_object.offsetTop);
                                        var p_tbl_left              = parseInt(t_left   + p_tbl_object.parentElement.offsetLeft     + p_tbl_object.offsetLeft);
                                        var p_tbl_width             = parseInt(p_tbl_object.offsetWidth);
                                        var p_tbl_height            = parseInt(p_tbl_object.offsetHeight);
                                        
                                        var c_tbl_object            = document.getElementById(c_tbl_id);
                                        var c_tbl_top               = parseInt(t_top    + c_tbl_object.parentElement.offsetTop      + c_tbl_object.offsetTop);
                                        var c_tbl_left              = parseInt(t_left   + c_tbl_object.parentElement.offsetLeft     + c_tbl_object.offsetLeft);
                                        var c_tbl_width             = parseInt(c_tbl_object.offsetWidth);
                                        var c_tbl_height            = parseInt(c_tbl_object.offsetHeight);

                                        var p_object                = document.getElementById(p_child_id);
                                        var p_top                   = parseInt(p_tbl_top     + p_object.parentElement.offsetTop      + p_object.offsetTop);
                                        var p_left                  = parseInt(p_tbl_left    + p_object.parentElement.offsetLeft     + p_object.offsetLeft);
                                        var p_width                 = parseInt(p_object.offsetWidth);
                                        var p_height                = parseInt(p_object.offsetHeight);
                                        
                                        var c_object                = document.getElementById(c_child_id);
                                        var c_top                   = parseInt(c_tbl_top    + c_object.parentElement.offsetTop       + c_object.offsetTop);
                                        var c_left                  = parseInt(c_tbl_left   + c_object.parentElement.offsetLeft      + c_object.offsetLeft);
                                        var c_width                 = parseInt(c_object.offsetWidth);
                                        var c_height                = parseInt(c_object.offsetHeight);
                                        
                                        //jg.setColor('#FF8000');
                                        jg.setColor('" + line_Color + @"');
		                                jg.setStroke(" + line_Width + @");
                                    		
		                                if(level_type == 0)
		                                {
	                                      jg.drawLine(c_left + c_width/2, c_top                     , c_left + c_width/2, c_top - sameLevelValue);
                                          jg.drawLine(c_left + c_width/2, c_top - sameLevelValue    , p_left + p_width/2, c_top - sameLevelValue);
                                          jg.drawLine(p_left + p_width/2, c_top - sameLevelValue    , p_left + p_width/2, p_top + same_arrow_height);
		                                }
		                                else if(level_type == 1)
		                                {
			                              jg.drawLine(c_left + c_width/2, c_top                     , c_left + c_width/2, c_top - upLevelValue);
	                                      jg.drawLine(c_left + c_width/2, c_top - upLevelValue      , p_left + p_width/2, c_top - upLevelValue);
	                                      jg.drawLine(p_left + p_width/2, c_top - upLevelValue      , p_left + p_width/2, p_top + p_height + top_arrow_height);	
		                                }
                                        
                                        jg.paint();
                                    }
                                    var jg = new jsGraphics('lblStgMap');
                                    </SCRIPT>
                                ";


        }



        private void SetHtmlUnit() 
        {
            // 전사 데이터 가지고 오기
            DataTable dataTable                 = _estDeptOrgMap.GetHomeData(_estterm_ref_id, _est_dept_ref_id, _emp_ref_id);

            for (int i = 0; i < dataTable.Rows.Count; i++) 
            {
                string dept_name                = (dataTable.Rows[i]["DEPT_NAME_ORG"] == DBNull.Value) ? dataTable.Rows[i]["DEPT_NAME"].ToString() : dataTable.Rows[i]["DEPT_NAME_ORG"].ToString();
                int pos_index                   = int.Parse(dataTable.Rows[i]["POSITION_ORG"].ToString());
                int p_est_dept_ref_id           = int.Parse(dataTable.Rows[i]["EST_DEPT_REF_ID"].ToString());
                
                // 전사 테이블 값 설정
                _pos_home_str[pos_index - 1]    += "<td valign='top'>" + GetHomeHtmlTable(p_est_dept_ref_id
                                                                            , dept_name
                                                                            , dataTable.Rows[i]["HEADER_IMG_ORG"].ToString()
                                                                            , (dataTable.Rows[i]["TREE_NODE_TYPE"].ToString() == "1") ? true : false) + "</td>";

                /* 수정작업 : 이천십일년 삼월 치릴
             * 수정작자 : 장동건
             * 수정내용 : BSC1004S1.ASPX 자화전자(성덕여왕 요청)
             *            측정주기 변경시 평가조직이 변경이 안됨
             *            조건변수를 두개로 날림
             *            */

                DeptInfos deptInfo = new DeptInfos(p_est_dept_ref_id);

                if (deptInfo.Up_Est_Dept_ID != 0)
                    _top_link = "<img src='../images/arrow/arrow_up_1.gif' border='0' align='absmiddle'> " + GetOrgDeptLink(deptInfo.Up_Est_Dept_ID, "<img src='../images/org/est_dept_org_txt.gif' border='0' align='absmiddle'>", "Y", true);
                    //_top_link = "<img src='../images/arrow/arrow_up_1.gif' border='0' align='absmiddle'> " + "<span class='style3'> 상위조직</span>";
                    //_top_link = "<img src='../images/arrow/arrow_up.gif' border='0' align='absmiddle'> " + "<span class='style3'>" + GetPopupLink(deptInfo.Up_Est_Dept_ID, "<b>" + dept_name + "</b>의 상위조직으로 가기", "Y", true) + "</span>";

                // 헤더 데이터 가지고 오기
                DataTable dataTable_Header      = _estDeptOrgMap.GetHeaderData(_estterm_ref_id, int.Parse(dataTable.Rows[i]["EST_DEPT_REF_ID"].ToString()), _emp_ref_id);

                for (int k = 0; k < dataTable_Header.Rows.Count; k++) 
                {
                    string dept_name_header     = (dataTable_Header.Rows[k]["DEPT_NAME_ORG"] == DBNull.Value) ? dataTable_Header.Rows[k]["DEPT_NAME"].ToString() : dataTable_Header.Rows[k]["DEPT_NAME_ORG"].ToString();
                    int pos_index_header        = int.Parse(dataTable_Header.Rows[k]["POSITION_ORG"].ToString());
                    int c_est_dept_ref_id       = int.Parse(dataTable_Header.Rows[k]["EST_DEPT_REF_ID"].ToString());

                    // 헤더 테이블 값 설정
                    string deptHeader = "<td valign='top' width='180'>" + GetHeaderHtmlTable(int.Parse(dataTable.Rows[i]["EST_DEPT_REF_ID"].ToString())
                                                                                                                , c_est_dept_ref_id
                                                                                                                , dept_name_header
                                                                                                                , dataTable_Header.Rows[k]["HEADER_IMG_ORG"].ToString()
                                                                                                                , (dataTable_Header.Rows[k]["TREE_NODE_TYPE"].ToString() == "1") ? true : false
                                                                                                               ) + "</td>";
                    _pos_dept_str[pos_index_header - 1] += deptHeader;

                    MergeStrMyFunctionScript( "tbl_0_" + Convert.ToString(pos_index - 1)
                                            , "tbl_0_" + Convert.ToString(pos_index_header - 1)
                                            , p_est_dept_ref_id
                                            , c_est_dept_ref_id
                                            , pos_index_header);
                }
            }

            SetTableTag(_pos_home_str);
            SetTableTag(_pos_dept_str);
            SetScriptTag();
        }

        public string GetHtml() 
        {
            string html_tag;

            SetHtmlUnit();

            string strClose = "onclick='document.getElementById(\"divPopUp\").style.display=\"none\";'";
            //<table width='1003' height='592' border='0' id='tblContent' style='background:url(" + _image_org_dir + @"bg_org_1.jpg)'>
            html_tag = @"
                            <DIV id=lblStgMap align='center'>
                            <table width='800' height='94%' border='0' id='tblContent'>
                              <tr height='10%'>
                                <td align='center'  width='33%'>&nbsp;" + _top_link + _pos_home_str[0] + _pos_dept_str[0] + _pos_legend_str[0] + @"</td>
                                <td align='center'  width='33%'>&nbsp;" + _pos_home_str[1] + _pos_dept_str[1] + _pos_legend_str[1] + @"</td>
                                <td align='center'  width='33%'>&nbsp;" + _pos_home_str[2] + _pos_dept_str[2] + _pos_legend_str[2] + @"</td>
                              </tr>
                              <tr height='10%'>
                                <td align='right'>&nbsp;"   + _pos_home_str[3] + _pos_dept_str[3] + _pos_legend_str[3] + @"</td>
                                <td align='center'>&nbsp;"  + _pos_home_str[4] + _pos_dept_str[4] + _pos_legend_str[4] + @"</td>
                                <td align='left'>&nbsp;"    + _pos_home_str[5] + _pos_dept_str[5] + _pos_legend_str[5] + @"</td>
                              </tr>
                              <tr height='80%'>
                                <td colspan='3' align='center' valign='top'>&nbsp;" + _pos_home_str[6] + _pos_dept_str[6] + _pos_legend_str[6] + @"</td>
                              </tr>
                              <tr>
                                <td colspan='3' align='center' valign='top'>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                              </tr>
                            </table>
                            </Div>
                            <DIV class='popUp_css' id='divPopUp' onclick=this.style.display = 'none'>
                               <TABLE cellSpacing='0' cellPadding='3' width='150' bgColor='#ffffff' border='0'>
                                 <TBODY>
                                   <TR id='trStgMap'>
                                      <TD><A id='lnkStgMap'><img src='../images/icon/icon_stgmap.gif' align='absmiddle'>&nbsp;전략맵으로 가기</A></TD>
                                   </TR>
                                   <TR id='trWorkMap' style='display:none;'>
                                      <TD><A id='lnkWorkMap'><img src='../images/icon/icon_stgmap.gif' align='absmiddle'>&nbsp;과제맵으로 가기</A></TD>
                                   </TR>
                                  <TR id='trKpi'>
                                    <TD><A id='lnkKpi'><img src='../images/icon/icon_kpi.gif' align='absmiddle'>&nbsp;조직별분석으로 가기</A></TD>
                                  </TR>
                                  <TR id='trScore'>
                                    <TD><A id='lnkScore'><img src='../images/icon/icon_kpi.gif' align='absmiddle'>&nbsp경영전략회의로 가기</A></TD>
                                  </TR>
                                  <TR id='trDrillDown'>
                                    <TD><A id='lnkDrillDown'><img src='../images/icon/icon_drilldown.gif' align='absmiddle'>&nbsp;하위조직 분석</A></TD>
                                  </TR>
                                  <tr>
                                    <TD align='right'><A href='#none' " + strClose+@">&nbsp;닫기</A></TD>
                                  </tr>
                                </TBODY>
                               </TABLE>
	                        </DIV>
                            ";

            return html_tag + _script_str + _script_my_function_str;
        }

        /// <summary>
        /// 조직상황판 최상위조직 조직명/시그널 표현
        /// </summary>
        /// <param name="est_dept_ref_id"></param>
        /// <param name="dept_name"></param>
        /// <param name="header_img_org"></param>
        /// <param name="isLink"></param>
        /// <returns></returns>
        /// {4} 당월 : {5} 누적
        /// <td width='32' align='center'>{4}&nbsp;{5}</td> 당월시그널 안보이게 수정
        private string GetHomeHtmlTable(int est_dept_ref_id, string dept_name, string header_img_org, bool isLink) 
        {
            string html_str;
            string str_signal = (_is_show_all_signal) ? "{4}&nbsp;{5}" : "{5}";
            html_str = string.Format(@"	
                        <table id='tbl_{0}' width='152' height='61' border='0' cellpadding='0' cellspacing='0'>
	                        <tr>
		                        <td style='background:url({1}organization_{2}_top.gif); vertical-align:bottom;'>
			                        <table width='100%'>
				                        <tr>
					                        <td align='center'><span class='cssCompTitle'>{3}</span></td>
                                        </tr>
                                        <tr>
					                        <td style='padding-right:" + signalPaddingRight + "px; text-align:center;'  align='center'>" + str_signal + @"</td>
				                        </tr>
			                        </table>
		                        </td>
	                        </tr>
                        </table>", est_dept_ref_id, _image_org_dir, header_img_org, GetPopupLink(est_dept_ref_id, dept_name, "N", isLink), GetScoreCardLink(_estterm_ref_id, est_dept_ref_id, _month, 0, isLink), GetScoreCardLink(_estterm_ref_id, est_dept_ref_id, _month, 1, isLink));

            return html_str;
        }

        /// <summary>
        /// 최상위 하위조직 조직
        /// </summary>
        /// <param name="est_dept_ref_id_org"></param>
        /// <param name="est_dept_ref_id"></param>
        /// <param name="dept_name"></param>
        /// <param name="header_img_org"></param>
        /// <param name="isLink"></param>
        /// <returns></returns>
        /// 07.11.21 line 490 수정 : 누계시그널만 보이도록
        /// 원래소스 : <td width='32' align='center'>" + GetScoreCardLink(_estterm_ref_id, est_dept_ref_id, _month, 0, isLink) + @"&nbsp;" + GetScoreCardLink(_estterm_ref_id, est_dept_ref_id, _month, 1, isLink) + @"</td>
        private string GetHeaderHtmlTable(int est_dept_ref_id_org
                                        , int est_dept_ref_id
                                        , string dept_name
                                        , string header_img_org
                                        , bool isLink)
        {
            string str_signal = (_is_show_all_signal) 
                                ?"<td width='32' style='padding-right:"+signalPaddingRight+"px;' align='center'>" + GetScoreCardLink(_estterm_ref_id, est_dept_ref_id, _month, 0, isLink) + "&nbsp;" + GetScoreCardLink(_estterm_ref_id, est_dept_ref_id, _month, 1, isLink) + "</td>"
                                :"<td width='22' style='padding-right:"+signalPaddingRight+"px;' align='center'>" + GetScoreCardLink(_estterm_ref_id, est_dept_ref_id, _month, 1, isLink) + "</td>";
            string html_str = @"
                                <table id='tbl_" + est_dept_ref_id + @"' width='" + deptTitleWidth + @"' border='0' cellpadding='0' cellspacing='0'>
		                            <tr>
			                            <td width='" + deptTitleWidth + "' height='" + deptTitleHeight + "' style='background:url(" + _image_org_dir + @"organization_" + header_img_org + @".gif)' >
				                            <!-- Header -->
				                            <table width='100%'>
					                            <tr>
						                            <td align='center'><span class='cssDeptTitle'>" + GetPopupLink(est_dept_ref_id, dept_name, "Y", isLink) + GetImageDrillDown(_estterm_ref_id, est_dept_ref_id) + @"</span></td>"
                                                    + str_signal + @"</td>
					                            </tr>
				                            </table>				
			                            </td>
		                            </tr>
		                            <tr>
			                            <td height='50' style='background:url(" + _image_org_dir + @"organization_" + header_img_org + @"_body.gif); background-repeat:repeat-y' valign='top'>
				                            <!-- Content -->
				                            <table width='100%'>
					                            <tr height='5'><td colspan='2'></td></tr>
					                            " + GetContentHtmlTable(est_dept_ref_id_org, est_dept_ref_id) + @"
				                            </table>
			                            </td>
		                            </tr>
		                            <tr>
			                            <td><img src='" + _image_org_dir + @"organization_" + header_img_org + @"_bottom.gif' width='" + deptTitleWidth + @"' height='6' alt=''></td>
		                            </tr>
	                            </table>
                            ";

            return html_str;
        }

        /// <summary>
        /// 하위조직 조직명/ 시그널 표현
        /// </summary>
        /// <param name="est_dept_ref_id_org"></param>
        /// <param name="est_dept_ref_id"></param>
        /// <returns></returns>
        /// 07.11.21 누계시그널만 표현 
        /// line 538 원소스 : <td align='center' width='32'>" + GetScoreCardLink(_estterm_ref_id, c_est_dept_ref_id, _month, 0, isLink) + @"&nbsp;" + GetScoreCardLink(_estterm_ref_id, c_est_dept_ref_id, _month, 1, isLink) + @"</td>
        /// 08.06.19 다시돌림
        private string GetContentHtmlTable(int est_dept_ref_id_org, int est_dept_ref_id)
        {
            string html_str = "";
            string str_signal = "";

            DataTable dataTable = _estDeptOrgMap.GetContentData(_estterm_ref_id, est_dept_ref_id_org, est_dept_ref_id, _emp_ref_id);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string dept_name = (dataTable.Rows[i]["DEPT_NAME_ORG"] == DBNull.Value) ? dataTable.Rows[i]["DEPT_NAME"].ToString() : dataTable.Rows[i]["DEPT_NAME_ORG"].ToString();
                int c_est_dept_ref_id = int.Parse(dataTable.Rows[i]["EST_DEPT_REF_ID"].ToString());
                //int dept_level = int.Parse(dataTable.Rows[i]["DEPT_LEVEL"].ToString());

                bool isLink = (dataTable.Rows[i]["TREE_NODE_TYPE"].ToString() == "1") ? true : false;
                str_signal = (_is_show_all_signal)
                             ? "<td align='center' style='padding-right:" + signalPaddingRight + "px;' width='32'>" + GetScoreCardLink(_estterm_ref_id, c_est_dept_ref_id, _month, 0, isLink) + "&nbsp;" + GetScoreCardLink(_estterm_ref_id, c_est_dept_ref_id, _month, 1, isLink) + "</td>"
                             : "<td align='center' style='padding-right:" + signalPaddingRight + "px;' width='22'>" + GetScoreCardLink(_estterm_ref_id, c_est_dept_ref_id, _month, 1, isLink) + "</td>";

                string cssName = "cssDeptList";

                if (dept_name.IndexOf("nbsp") > 0)
                {
                    cssName = "cssDeptListChild";
                }


                html_str += @"
                                <tr>
		                            <td class='" + cssName + "' align='left'> " + GetPopupLink(c_est_dept_ref_id, dept_name, "Y", isLink) + GetImageDrillDown(_estterm_ref_id, c_est_dept_ref_id) + @"</td>"
                                    + str_signal + @"
	                            </tr>
                            ";
            }

            return html_str;
        }

        private static void SetBlankValue(string[] strArray) 
        {
            for (int i = 0; i < strArray.Length; i++) 
            {
                strArray[i] = "";
            }
        }

        private static void SetTableTag(string[] strArray)
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                if (!strArray[i].Equals(string.Empty))
                    strArray[i] = "<table id='tbl_0_" + i + "'><tr>" + strArray[i] + "</tr></table>";
            }
        }

        private void SetScriptTag()
        {
            if (_script_my_function_str != "")
            {
                //_script_my_function_str = "<script type=text/javascript>function ExecFun() {\njg.clear();\n" + _script_my_function_str + "}; window.onload = ExecFun; window.onresize = function(){ setTimeout(ExecFun, 0); } </script>";

                _script_my_function_str = @"<script type=text/javascript>
					var gExecFun_IsRunning = false;
					var gExecFun_Timer = null;

					function ExecFun() {
						if (gExecFun_IsRunning)
							return;
						gExecFun_IsRunning = true;
						jg.clear();
						" + _script_my_function_str + @"
						;
						gExecFun_IsRunning = false;
					}

					window.onload = ExecFun;
					window.onresize = function(){
						if (gExecFun_Timer )
						{
							clearTimeout(gExecFun_Timer );
							gExecFun_Timer  = null;
						}
						gExecFun_Timer = setTimeout(ExecFun, 500);
					}
					</script>";
            }
        }

        private void MergeStrMyFunctionScript(string p_tbl_id, string c_tbl_id, int p_est_dept_ref_id, int c_est_dept_ref_id, int pos_idx) 
        {
            int level_type;

            if (pos_idx == 1 || pos_idx == 2 || pos_idx == 3)
                level_type = 0;
            else
                level_type = 1;

            if (_script_my_function_str != null)
                _script_my_function_str += string.Format("myDrawFunction('tblContent', '{0}', '{1}', '{2}', '{3}', {4});\n", p_tbl_id, c_tbl_id, "tbl_" + p_est_dept_ref_id, "tbl_" + c_est_dept_ref_id, level_type);
        }

        private string GetPopupLink(int est_dept_ref_id, string text, string ynStr, bool isLink)
        {
            string linkStgMap       = "";
            string linkKpi          = "";
            string linkDrillDown    = "";
            string linkScore        = "";
            string linkWorkMap      = "";

                if (isLink || (IsDrillDown(_estterm_ref_id, est_dept_ref_id) && ynStr == "Y"))
                {
                    string sExtYN = (Include_Ext_Kpi_Score) ? "Y" : "N";
                    linkStgMap  = string.Format("usr_dept_org.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}&DRILLDOWN_YN=N&EXT_KPI_YN={3}", _estterm_ref_id, est_dept_ref_id, _month, sExtYN);
                    linkWorkMap = string.Format("usr_dept_org.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&DRILLDOWN_YN=W&EXT_KPI_YN={2}", _estterm_ref_id, est_dept_ref_id, sExtYN);
                    linkKpi     = string.Format("usr_dept_org.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}&DRILLDOWN_YN=X&EXT_KPI_YN={3}", _estterm_ref_id, est_dept_ref_id, _month, sExtYN);
                    linkScore   = string.Format("usr_dept_org.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}&DRILLDOWN_YN=S&EXT_KPI_YN={3}", _estterm_ref_id, est_dept_ref_id, _month, sExtYN);

                    if ((IsDrillDown(_estterm_ref_id, est_dept_ref_id) && ynStr == "Y"))
                    {
                        linkDrillDown = string.Format("usr_dept_org.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}&DRILLDOWN_YN=Y&EXT_KPI_YN={3}", _estterm_ref_id, est_dept_ref_id, _month, sExtYN);
                    }
                    else
                    {
                        linkDrillDown = "";
                    }

                    //string strTmp = string.Format("<a href='#null' onclick=\"('{0}', '{1}', '{2}','{3}')\">{4}</a>"
                    //                     , linkStgMap
                    //                     , linkKpi
                    //                     , linkDrillDown
                    //                     , linkScore
                    //                     , text);

                    return string.Format("<a href='#null' onclick=\"viewPopUpT('{0}', '{1}', '{2}','{3}','{4}')\">{5}</a>"
                                         , linkStgMap
                                         , linkKpi
                                         , linkDrillDown
                                         , linkScore
                                         , linkWorkMap
                                         , text);
                }
                else 
                {
                    return string.Format("{4}", _estterm_ref_id, est_dept_ref_id, _month, ynStr, text);
                }
            
        }
        
        private string GetOrgDeptLink(int est_dept_ref_id, string text, string ynStr, bool isLink)
        {
            string sExtYN = (Include_Ext_Kpi_Score) ? "Y" : "N";
            if (_is_embed)
            {
                if (isLink || (IsDrillDown(_estterm_ref_id, est_dept_ref_id) && ynStr == "Y"))
                {
                    return string.Format("<a href='#null' onclick=\"location.href='usr_dept_org_embed.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}&DRILLDOWN_YN={3}&EXT_KPI_YN={4}'\">{5}</a>", _estterm_ref_id, est_dept_ref_id, _month, ynStr, sExtYN, text);
                }
                else
                {
                    return string.Format("{4}", _estterm_ref_id, est_dept_ref_id, _month, ynStr, text);
                }
            }
            else
            {
                if (isLink || (IsDrillDown(_estterm_ref_id, est_dept_ref_id) && ynStr == "Y"))
                {
                    return string.Format("<a href='#null' onclick=\"location.href='usr_dept_org.aspx?ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&TMCODE={2}&DRILLDOWN_YN={3}&EXT_KPI_YN={4}'\">{5}</a>", _estterm_ref_id, est_dept_ref_id, _month, ynStr, sExtYN, text);
                }
                else
                {
                    return string.Format("{4}", _estterm_ref_id, est_dept_ref_id, _month, ynStr, text);
                }
            }
        }

        private string GetScoreCardLink(int estterm_ref_id, int est_dept_ref_id, int month, int sum_type, bool isLink) 
        {
            MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info bizComDeptInfo = new MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info(est_dept_ref_id);

            string sExtYN = (Include_Ext_Kpi_Score) ? "Y" : "N";
            string sum_type_str = "MS";
            string sum_type_name = "";
            string dept_name = bizComDeptInfo.DEPT_NAME;


            if (sum_type == 0)
            {
                sum_type_str = "MS";
                sum_type_name = "당월";
            }
            else if (sum_type == 1)
            {
                sum_type_str = "TS";
                sum_type_name = "누적";
            }

            if (isLink)
            {
                //return string.Format("<a href='../BSC/BSC0403S4.aspx?ITYPE=POP&ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&YMD={2}&SUM_TYPE={3}&DEPT_TYPE_ID={5}',825,740,'no','no');\"><img src='{4}' border='0'></a>", estterm_ref_id, est_dept_ref_id, month, sum_type_str, GetImageName(estterm_ref_id, month.ToString(), est_dept_ref_id, sum_type_str), "");
                //return string.Format("<a href='#null' onclick=\"gfOpenWindow('../BSC/BSC0403S4.aspx?ITYPE=POP&ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&YMD={2}&SUM_TYPE={3}&DEPT_TYPE_ID={5}',825,740,'no','no');\"><img src='{4}' border='0'></a>", estterm_ref_id, est_dept_ref_id, month, sum_type_str, GetImageName(est_dept_ref_id, sum_type), "");
                //BSC0403S1.aspx?ITYPE=POP&ESTTERM_REF_ID=1000&YMD=200601&SUM_TYPE=MS&EST_DEPT_REF_ID=1025&DEPT_TYPE_ID=90.45


                //팝업페이지 변경 2012.10.31 - 이현석
                //return string.Format("<a href='#null' onclick=\"gfOpenWindow('../BSC/BSC0403S1.aspx?ITYPE=POP&ESTTERM_REF_ID={0}&EST_DEPT_REF_ID={1}&YMD={2}&SUM_TYPE={3}&DEPT_TYPE_ID={4}&EXT_KPI_YN={5}',825,740,'no','no');\"><img src='{6}' alt='{7}' border='0'></a>", estterm_ref_id, est_dept_ref_id, month, sum_type_str, "", sExtYN, GetImageName(estterm_ref_id, month.ToString(), est_dept_ref_id, sum_type_str), sum_type_name);
                string url = "<a href=\"../BSC/BSC0404S1.ASPX?{1}{2}{3}\"  style=\"color:Navy;\" target=\"_top\">{0}</a>";
                string img = string.Format("<img src='{0}' alt='{1}' border='0'>", GetImageName(estterm_ref_id, month.ToString(), est_dept_ref_id, sum_type_str), sum_type_name);
                return string.Format(url, img, "&ESTTERM_REF_ID=" + estterm_ref_id, "&YMD=" + month, "&EST_DEPT_REF_ID=" + est_dept_ref_id);
            }

            return " ";
        }

        /// <summary>
        /// 시그널 이미지 명 반환
        /// </summary>
        /// <param name="est_dept_ref_id"></param>
        /// <param name="sum_type"></param>
        /// <returns></returns>
        private string GetImageName(int est_dept_ref_id, int sum_type)
        {
            if (_sinal_ds == null)
                return _image_stg_dir + "icon_u.gif";

            DataRow[] dr = _sinal_ds.Select("EST_DEPT_REF_ID = " + est_dept_ref_id);

            if (dr.Length == 0)
                return _image_stg_dir + "icon_u.gif";

            double score = 0 ;

            for (int i = 0; i < dr.Length; i++)
            {
                if (sum_type == 0)
                {
                     score += Convert.ToDouble(dr[i]["SCORE_MS"].ToString());
                }
                else if (sum_type == 1)
                {
                     score += Convert.ToDouble(dr[i]["SCORE_TS"].ToString());
                }
            }

            if (score >= estDeptOrgScore_e.Min_Value && score <= estDeptOrgScore_e.Max_Value)
            {
                return _image_stg_dir + "icon_e.gif";
            }
            else if (score >= estDeptOrgScore_g.Min_Value && score < estDeptOrgScore_g.Max_Value)
            {
                return _image_stg_dir + "icon_g.gif";
            }
            else if (score >= estDeptOrgScore_w.Min_Value && score < estDeptOrgScore_w.Max_Value)
            {
                return _image_stg_dir + "icon_w.gif";
            }
            else if (score >= estDeptOrgScore_a.Min_Value && score < estDeptOrgScore_a.Max_Value)
            {
                return _image_stg_dir + "icon_ania.gif";
            }
            else if (score >= estDeptOrgScore_u.Min_Value && score < estDeptOrgScore_u.Max_Value)
            {
                return _image_stg_dir + "icon_u.gif";
            }

            return _image_stg_dir + "icon_u.gif";
        }

        /// <summary>
        /// 조직시그널 반환
        /// 2009.02.06 방병현
        /// </summary>
        /// <param name="estterm_ref_id"></param>
        /// <param name="ymd"></param>
        /// <param name="est_dept_ref_id"></param>
        /// <param name="sum_type"></param>
        /// <returns></returns>
        private string GetImageName(  int estterm_ref_id
                                    , string ymd
                                    , int est_dept_ref_id
                                    , string sum_type)
        {
            Biz_Bsc_Score_Card objBSC = new Biz_Bsc_Score_Card();
            string sScore = objBSC.GetEstDeptTotalStringScoreOnly(estterm_ref_id
                                                                , ymd
                                                                , sum_type
                                                                , est_dept_ref_id
                                                                , Include_Ext_Kpi_Score);


            // 골타겟 관련 입력 버튼 (농협에서 추가)
            //iBtnGoalTong.Visible = iBtnAddTarget.Visible;

            //if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
            //    iBtnGoalTong.Visible = false;

            if (BizUtility.GOALTONG_TYPE.Equals(GoalTong.GOAL.ToString()))
                sScore = objBSC.GetEstDeptTotalStringScoreOnly_Goal(estterm_ref_id
                                                                , ymd
                                                                , sum_type
                                                                , est_dept_ref_id
                                                                , Include_Ext_Kpi_Score);
            


            if (sScore == "-")
            {
                return _image_stg_dir + "icon_u.gif";
            }

            double score = double.Parse(sScore.Replace('-','0'));

            estDeptOrgScore             = new Biz_EstDeptOrgScoreInfos();
            DataTable dtDeptOrgScore    = estDeptOrgScore.GetEstDeptOrgScoreInfos(estterm_ref_id).Tables[0];

            //dtDeptOrgScore              = DataTypeUtility.FilterSortDataTable(dtDeptOrgScore, "", "MIN_VALUE DESC");

            for(int i = 0; i < dtDeptOrgScore.Rows.Count; i++) 
            {
                DataRow drScore = dtDeptOrgScore.Rows[i];
                double dMaxVal = double.Parse(drScore["MIN_VALUE"].ToString());
                if (score >= dMaxVal)
                {
                    return _image_stg_dir + string.Format("icon_{0}.gif", drScore["SCORE_CODE"]);
                }
            }

            return _image_stg_dir + "icon_u.gif";
        }

        public bool ModifyViewYNOrg(int estterm_ref_id
                                    , TreeNodeCollection treeNodeCol) 
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                _estDeptOrgMap.ModifyViewYNOrg(conn, trx, estterm_ref_id, 0, "N");

                foreach (TreeNode node in treeNodeCol)
                {
                    _estDeptOrgMap.ModifyViewYNOrg(conn, trx, estterm_ref_id, Convert.ToInt32(node.Value), "Y");
                }

                trx.Commit();
            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        public bool ModifyEstDeptOrg(int est_dept_ref_id
                                    , int header_img_org
                                    , int sort_org
                                    , int dept_type
                                    , string dept_name_org)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                _estDeptOrgMap.ModifyEstDeptOrg(conn, trx, est_dept_ref_id, header_img_org, sort_org, dept_type, dept_name_org);

                trx.Commit();
            }
            catch (Exception)
            {
                trx.Rollback();
                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        private static string GetImageDrillDown(int estterm_ref_id, int est_dept_ref_id)
        {
            Biz_EstDeptOrgDetails biz_EstDeptOrgDetail  = new Biz_EstDeptOrgDetails();
            bool isTrue                                 = biz_EstDeptOrgDetail.IsDrillDownPosible(estterm_ref_id, est_dept_ref_id);

            if (isTrue)
                return "&nbsp;<img src='../images/arrow/arrow_down_1.gif' border='0' align='absmiddle'>";

            return string.Empty;
        }

        private static bool IsDrillDown(int estterm_ref_id, int est_dept_ref_id)
        {
            Biz_EstDeptOrgDetails biz_EstDeptOrgDetail  = new Biz_EstDeptOrgDetails();
            return biz_EstDeptOrgDetail.IsDrillDownPosible(estterm_ref_id, est_dept_ref_id);
        }
    }
}
