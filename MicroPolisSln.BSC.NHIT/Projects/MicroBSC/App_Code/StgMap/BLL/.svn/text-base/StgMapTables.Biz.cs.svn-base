using System.Data;

namespace MicroBSC.Biz.BSC
{
    public class StgMapTables_Biz : StgMapTables_Data
    {
        private string _script_image_path               = "";
        private string _signal_image_path               = "";
        private string _script_stg_title                = "";
        private string _script_stg_kpi                  = "";
        private string _script_merge                    = "";
        private string[] _script_image_map_type         = null;
        private double[] _script_stg_map_type_weight    = null;
        private int _stgMapTypeCount                    = 0;
        private DataTable _stgMapTypeCol                = null;
        private string _statusType                      = "complete";
        private bool _isVisible                         = true;

        private int _view_type                          = 0;
        private string _working_yn                      = "N";
        private string _fullscreen                      = "N";

        public StatusType SetStatusType 
        {
            set 
            {
                if (value == StatusType.Created) 
                {
                    _statusType = "complete";
                }
                else if (value == StatusType.Unmasured)
                {
                    _statusType = "unmasured";
                }
                else if (value == StatusType.Pending)
                {
                    _statusType = "pending";
                }
                else if (value == StatusType.Alert)
                {
                    _statusType = "alert";
                }
                else if (value == StatusType.Ended)
                {
                    _statusType = "complete";
                }
            }
        }

        public string SignalImagePaht 
        {
            set 
            {
                _signal_image_path = value;
            }
        }

        public StgMapTables_Biz(int est_year
                                , string est_month
                                , int estterm_ref_id
                                , int est_dept_ref_id
                                , int map_version_id
                                , string script_image_path
                                , bool isVisible
                                , int view_type
                                , string fullscreen) : base(est_year, est_month, estterm_ref_id, est_dept_ref_id, map_version_id) 
        {
            StgMaps_Biz stgMap              = new StgMaps_Biz();
            _stgMapTypeCount                = stgMap.GetStgMapTypeCount();
            _stgMapTypeCol                  = stgMap.GetStgMapTypes();
            _script_image_map_type          = new string[_stgMapTypeCount];
            _script_stg_map_type_weight     = new double[_stgMapTypeCount];

            _script_image_path              = script_image_path;
            _isVisible                      = isVisible;
            _view_type                      = view_type;
            _fullscreen                     = fullscreen;

            Init();
        }

        public StgMapTables_Biz(int est_year
                                , string est_month
                                , int estterm_ref_id
                                , int est_dept_ref_id
                                , int map_version_id
                                , string script_image_path
                                , bool isVisible
                                , int view_type
                                , string working_yn
                                , string fullscreen)
            : base(est_year, est_month, estterm_ref_id, est_dept_ref_id, map_version_id)
        {
            StgMaps_Biz stgMap = new StgMaps_Biz();
            _stgMapTypeCount = stgMap.GetStgMapTypeCount();
            _stgMapTypeCol = stgMap.GetStgMapTypes();
            _script_image_map_type = new string[_stgMapTypeCount];
            _script_stg_map_type_weight = new double[_stgMapTypeCount];

            _script_image_path = script_image_path;
            _isVisible = isVisible;
            _view_type = view_type;
            _working_yn = working_yn;
            _fullscreen = fullscreen;

            Init();
        }

        private void Init() 
        {
            for(int i = 0; i < _stgMapTypeCol.Rows.Count; i++)
            {
               _script_stg_map_type_weight[i] = GetTotalPointByStgMapType( int.Parse(_stgMapTypeCol.Rows[i]["VIEW_REF_ID"].ToString()) );               
            }

            for (int i = 0; i < _stgMapTypeCol.Rows.Count; i++)
            {
                _script_image_map_type[i] = @"  <td>&nbsp;</td>
                                            <td width='105'> 
                                                <table height='99' border='0' cellpadding='0' cellspacing='0' background='" + _script_image_path + @"map_jt03.gif'>
                                                    <tr> 
                                                        <td height='12'><img src='" + _script_image_path + @"map_jt01.png'></td>
                                                    </tr>
                                                    <tr> 
                                                        <td height='55' valign='bottom' align='center' background='" + _script_image_path + _stgMapTypeCol.Rows[i]["VIEW_IMAGE_NAME"].ToString() + @"' class='basic_bold_w' size='9px'><span id='F" + i.ToString() + "'>" + _stgMapTypeCol.Rows[i]["VIEW_NAME"].ToString() + @"</span></td>
                                                    </tr>
                                                    <tr> 
                                                        <td height='20' align='center' background='" + _script_image_path + @"map_jt02_b.gif' class='basic_bold_w'><span id='L" + i.ToString() + "'>" + _script_stg_map_type_weight[i].ToString("#,##0.00") + @"</span></td>
                                                    </tr>
                                                    <tr> 
                                                        <td height='12'><img src='" + _script_image_path + @"map_jt02.png'></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            ";
            }
        }

        private string GetMergeScript(int stg_map_id) 
        {
            StgMaps_Biz stgMap = new StgMaps_Biz(Est_Year, Est_Month, EstTerm_Ref_ID, Est_Dept_Ref_ID, Map_Version_ID, stg_map_id);
            //<font title='{0}'></font> onclick=alert('전략링크') onmouseover=this.style.cursor='hand' onmouseover=this.style.cursor='default'
            //_script_stg_title = string.Format("<div onmouseover=\"ExcuteFnc('{1}')\">{2}_{1}</div>"
            //                        , stgMap.Stg_Desc
            //                        , stg_map_id
            //                        , stgMap.Stg_Name);

            if (_working_yn == "Y" || _working_yn == "T")
                _script_stg_title = string.Format("<div><font title='{0}'>{1}</font></div>"
                                        , stgMap.Stg_Desc
                                        , stgMap.Stg_Name);
            else
                _script_stg_title = string.Format("<div><font title='{0}'><a href='#null' onclick=\"selSTGlist('{1}', '{2}', '{3}', '{4}');\">{5}</a></font></div>"
                                        , stgMap.Stg_Desc
                                        , EstTerm_Ref_ID
                                        , Est_Dept_Ref_ID
                                        , stg_map_id
                                        , Est_Month
                                        , stgMap.Stg_Name);

            _script_stg_kpi     = GetKPIListScript(stg_map_id);
            
            string vibleStr     = "";
            //string valignStr    = "";

            if (_isVisible)
            {
                vibleStr        = "block";
                //valignStr       = "valign='top'";
            }
            else 
            {
                vibleStr        = "none";
            }

            if(_view_type == 1)
                _script_merge = @"<TABLE height='100%' cellSpacing='0' cellPadding='0' width='150' background='" + _script_image_path + @"table_skin/" + _statusType + @"/map_jt10.gif' border=0 >
                                    <TBODY>
                                        <TR> 
                                            <TD align='center' background='" + _script_image_path + @"table_skin/" + _statusType + @"/map_jt08.png' height='37'> 
                                            <TABLE width='95%' height='100%' border='0' cellPadding='0' cellSpacing='0'>
                                                    <TBODY>
                                                        <TR > 
                                                            <TD class='stext_jw'>
                                                                " + _script_stg_title + @"
                                                            </TD>
                                                            <TD width='43' align='right' class='stext_oo'> 
                                                                <table width='100%' height='100%' border='0' cellpadding='0' cellspacing='0'>
                                                                    <tr> 
                                                                        <td height='27' align='right'>
                                                                            <FONT color=#54ff00>목표</FONT>
									                                    </td>
                                                                    </tr>
                                                                    <tr> 
                                                                        <td height='8' align='center'><img id='img_block_" + stg_map_id.ToString() + @"' src='" + _script_image_path + @"map_jt13_down.gif' style='CURSOR: hand;DISPLAY:none' onclick=VisibleSpan('block_" + stg_map_id.ToString() + @"')></td>
                                                                    </tr>
                                                                </table></TD>
                                                        </TR>
                                                    </TBODY>
                                                </TABLE>
			                                </TD>
                                        </TR>
                                        <TR> 
                                            <TD height='3'>
            	                                <IMG height='3' src='" + _script_image_path + @"table_skin/" + _statusType + @"/map_jt11.gif' width='150'></TD>
                                        </TR>
                                        <TR> 
                                            <TD align=left valign='top'>
                                                <span id='block_" + stg_map_id.ToString() + @"' style='DISPLAY: " + vibleStr + @"; MARGIN-LEFT: 1px'>
            		                                " + _script_stg_kpi + @"</span></TD>
                                        </TR>
                                        <TR> 
                                            <TD height='9'>
            	                                <IMG height='9' src='" + _script_image_path + @"table_skin/" + _statusType + @"/map_jt09.png'></TD>
                                        </TR>
	                                </TABLE>";
            else
                _script_merge = @"<TABLE height='100%' cellSpacing='0' cellPadding='0' width='150' background='" + _script_image_path + @"table_skin/" + _statusType + @"/map_jt10.gif' border=0 >
                                    <TBODY>
                                        <TR> 
                                            <TD align='center' background='" + _script_image_path + @"table_skin/" + _statusType + @"/map_jt08.png' height='37'> 
                                            <TABLE width='95%' height='100%' border='0' cellPadding='0' cellSpacing='0'>
                                                    <TBODY>
                                                        <TR > 
                                                            <TD class='stext_jw'>
                                                                " + _script_stg_title + @"
                                                            </TD>
                                                            <TD width='33' align='center' valign='bottom' class='stext_oo'> 
                                                                <table width='100%' height='100%' border='0' cellpadding='0' cellspacing='0'>
                                                                    <tr> 
                                                                        <td height='27' align='center'>
                                                                            <FONT color=#54ff00>" + GetStgPointById(stg_map_id).ToString("#,##0.00") + @"</FONT>
									                                    </td>
                                                                    </tr>
                                                                    <tr> 
                                                                        <td height='8' align='center'><img id='img_block_" + stg_map_id.ToString() + @"' src='" + _script_image_path + @"map_jt13_down.gif' style='CURSOR: hand;DISPLAY:none' onclick=VisibleSpan('block_" + stg_map_id.ToString() + @"')></td>
                                                                    </tr>
                                                                </table></TD>
                                                        </TR>
                                                    </TBODY>
                                                </TABLE>
			                                </TD>
                                        </TR>
                                        <TR> 
                                            <TD height='3'>
            	                                <IMG height='3' src='" + _script_image_path + @"table_skin/" + _statusType + @"/map_jt11.gif' width='150'></TD>
                                        </TR>
                                        <TR> 
                                            <TD align=left valign='top'>
                                                <span id='block_" + stg_map_id.ToString() + @"' style='DISPLAY: " + vibleStr + @"; MARGIN-LEFT: 1px'>
            		                                " + _script_stg_kpi + @"</span></TD>
                                        </TR>
                                        <TR> 
                                            <TD height='9'>
            	                                <IMG height='9' src='" + _script_image_path + @"table_skin/" + _statusType + @"/map_jt09.png'></TD>
                                        </TR>
	                                </TABLE>";

            return _script_merge;
        }

        public string GetStgMapTableScript(int stg_map_id, bool isVisible) 
        {
            return GetMergeScript(stg_map_id);
        }

        public string GetStgMapTypeScript(int index) 
        {
            return _script_image_map_type[index];
        }

        private string GetKPIListScript(int stg_map_id) 
        {
            string header   = @"<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'>
                                ";
            string content  = "";
            string content2 = "";
            string footer   = "</TABLE>";

            DataTable dt;
            if (_working_yn == "Y" || _working_yn == "T")
            {
                dt = GetWorkList(stg_map_id).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (_view_type == 0)
                    {
                        content += @"<TR>
                                    <TD width='15' valign='top' align='right' class='stext' style='padding-top: 3px;'>"
                                    + (dt.Rows[i]["WORK_TYPE"].ToString() == "C" ? "<IMG src='../images/stg/TREE_W.gif' width='15' align='absMiddle' />" : "<IMG src='../images/stg/TREE_E.gif' width='15' align='absMiddle' />")
                                        + @"</TD>
	                                <TD class='stext'>
		                                " + (dt.Rows[i]["WORK_TYPE"].ToString() == "C" ?
                                            string.Format("<a href='#null' onclick=\"openWorkForm('{0}', '{1}', '{2}');\">{3}</a>", EstTerm_Ref_ID, Est_Dept_Ref_ID, dt.Rows[i]["KPI_REF_ID"].ToString(), dt.Rows[i]["KPI_NAME"].ToString())
                                            : string.Format("<a href='#null' onclick=\"openExecForm('{0}', '{1}', '{2}', '{3}');\">{4}</a>", EstTerm_Ref_ID, Est_Dept_Ref_ID, dt.Rows[i]["ORG_KPI_REF_ID"].ToString(), dt.Rows[i]["KPI_REF_ID"].ToString(), dt.Rows[i]["KPI_NAME"].ToString())) + @"</TD>
	                                    <TD width='33' class='stext' valign='top'>"
                                          + (dt.Rows[i]["COMPLETE_YN"].ToString() == "Y" ? "<IMG src='../images/icon/gr_po03_b.gif' width='39' />&nbsp;" : "<IMG src='../images/icon/icon_bt02.gif' width='15' alt='Not Finish' />&nbsp;")
                                        + @"</TD>
                                </TR>
                                ";
                    }
                    else
                    {
                        content += @"<TR>
                                    <TD width='15' valign='top' align='right' class='stext'>
                                        <IMG src='" + _script_image_path + @"arrow.gif' width='15' align='absMiddle' style='vertical-align:middle;'></TD>
	                                <TD class='stext' valign='top'>
		                                " + string.Format("<a href='#null' onclick=\"selKPIlist('{0}', '{1}', '{2}');\">{3}</a>", EstTerm_Ref_ID, dt.Rows[i]["KPI_REF_ID"].ToString(), Est_Month, dt.Rows[i]["KPI_NAME"].ToString()) + @"</TD>
	                                <TD width='43' class='stext' valign='top' align='right'>
  		                                <font color='#2080D0'>" + GetTargetByMonth(int.Parse(dt.Rows[i]["KPI_REF_ID"].ToString())) + @"&nbsp;</font></TD>
                                </TR>";
                    }
                }
            }
            else
            {
                dt = GetKpiList(stg_map_id).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    //content2 = (dt.Rows[i]["MAP_KPI_TYPE"].ToString() == "" ? "&nbsp;" : "<img src='" + dt.Rows[i]["MAP_KPI_TYPE_DESC"].ToString() + @"' width='11' align='absMiddle' style='vertical-align:middle;' alt='" + dt.Rows[i]["MAP_KPI_TYPE_NAME"].ToString() + "' />");


                    if (dt.Rows[i]["MAP_KPI_TYPE"].ToString() == "")
                    { 
                        content2 = "&nbsp;";
                    }
                    else
                    {
                        if (dt.Rows[i]["MAP_KPI_TYPE_DESC"].ToString().Trim().Length > 0)
                        {
                            content2 = "<img src='" + dt.Rows[i]["MAP_KPI_TYPE_DESC"].ToString() + @"' width='11' align='absMiddle' style='vertical-align:middle;' alt='" + dt.Rows[i]["MAP_KPI_TYPE_NAME"].ToString() + "' />";
                        }
                    }



                    if (_view_type == 0)
                    {
                        content += @"<TR>
                                    <TD width='26' valign='top' align='right' class='stext' style='padding-top: 3px;'>
                                        <IMG src='" + _script_image_path + @"arrow.gif' width='15' align='absMiddle' style='vertical-align:middle;' />" + content2 + @"
                                    </TD>
	                                <TD class='stext'>
		                                " + string.Format("<a href='#null' onclick=\"selKPIlist('{0}', '{1}', '{2}');\">{3}</a>", EstTerm_Ref_ID, dt.Rows[i]["KPI_REF_ID"].ToString(), Est_Month, dt.Rows[i]["KPI_NAME"].ToString()) + @"</TD>
	                                <TD width='33' class='stext' valign='top'>
  		                                <IMG src='" + _signal_image_path + GetKPIIndicatorImageName(int.Parse(dt.Rows[i]["KPI_REF_ID"].ToString()), CloseType.MonthSignal) + @"' width='11'>&nbsp;"
                                        + @"<IMG src='" + _signal_image_path + GetKPIIndicatorImageName(int.Parse(dt.Rows[i]["KPI_REF_ID"].ToString()), CloseType.TotalSignal) + @"' width='11'></TD>
                                </TR>
                                ";
                    }
                    else
                    {
                        content += @"<TR>
                                    <TD width='26' valign='top' align='right' class='stext' style='padding-top: 3px;'>
                                        <IMG src='" + _script_image_path + @"arrow.gif' width='15' align='absMiddle' style='vertical-align:middle;' />" + content2 + @"
                                    </TD>
	                                <TD class='stext' valign='top'>
		                                " + string.Format("<a href='#null' onclick=\"selKPIlist('{0}', '{1}', '{2}');\">{3}</a>", EstTerm_Ref_ID, dt.Rows[i]["KPI_REF_ID"].ToString(), Est_Month, dt.Rows[i]["KPI_NAME"].ToString()) + @"</TD>
	                                <TD width='43' class='stext' valign='top' align='right'>
  		                                <font color='#2080D0'>" + GetTargetByMonth(int.Parse(dt.Rows[i]["KPI_REF_ID"].ToString())) + @"&nbsp;</font></TD>
                                </TR>";
                    }
                }
            }

            return header + content + footer;
        }

        //public StatusType GetStatusTypeByIndicator(int stg_ref_id) 
        //{
        //    string temp = "";

        //    DataSet ds = GetIndicator(stg_ref_id);

        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        temp += ds.Tables[0].Rows[i]["MS"].ToString() + ds.Tables[0].Rows[i]["TS"].ToString();
        //    }

        //    if (temp.IndexOf('A') > -1)
        //        return StatusType.Alert;
        //    else if (temp.Replace("U", "") == "")
        //        return StatusType.Unmasured;

        //    return StatusType.Ended;
        //}

        public StatusType GetStatusTypeByIndicator(int stg_ref_id)
        {
            bool bIsUnmeasured = false;
            bool bIsAlert      = false;

            DataSet ds = GetStgStatus(stg_ref_id);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    bIsUnmeasured = (ds.Tables[0].Rows[0]["IS_U"].ToString() == "Y") ? true : false;
                    bIsAlert      = (ds.Tables[0].Rows[0]["IS_A"].ToString() == "Y") ? true : false;
                }
            }

            if (bIsAlert)
                return StatusType.Alert;
            else if (bIsUnmeasured)
                return StatusType.Unmasured;

            return StatusType.Ended;
        }
    }
}
