using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Biz;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.BSC.Biz;
using MicroBSC.Estimation.Dac;


public partial class usr_stg_map : AppPageBase
{
    private string REDRAWING_SCRIPT = string.Empty;

    private int ESTTERM_REF_ID                          = 0;
    private int EST_DEPT_REF_ID                         = 0;
    private int MAP_VERSION_ID                          = 0;
    private string TMCODE                               = "";
    private LineType ENUMLINETYPE                       = LineType.Straight;
    private bool ISKPILISTVIEW                          = true;
    private string FULLSCREEN                           = "N";
    private int YEAR                                    = 0;
    protected string DRAWING_YN                         = "N";
    private string IWORKINGMAP_YN
    {
        get
        {
            if (ViewState["WORKINGMAP_YN"] == null)
                ViewState["WORKINGMAP_YN"] = "N";
            return (string)ViewState["WORKINGMAP_YN"];
        }
        set
        {
            ViewState["WORKINGMAP_YN"] = value;
        }
    }

    MicroBSC.Estimation.Dac.DeptInfos   _estDeptInfo    = new MicroBSC.Estimation.Dac.DeptInfos();
    Biz_Bsc_Map_Info                    _stgMapInfo     = new Biz_Bsc_Map_Info();
    Biz_Bsc_Score_Card                  _score_card     = new Biz_Bsc_Score_Card();
    
    //StrategyMapInfos _stgMapInfo = new StrategyMapInfos();
    //Biz_Score_Card                      _score_card     = new Biz_Score_Card();

    EmpSysInfos_Biz                     _empSysInfo     = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetQueryStringData();
        
        if (!Page.IsPostBack)
        {
            DoBinding();
        }
    }

    private void DoBinding()
    {
        StgMaps_Biz stgMap;
        if (IWORKINGMAP_YN == "N")
            stgMap = new StgMaps_Biz(YEAR
                                                , TMCODE
                                                , ESTTERM_REF_ID
                                                , EST_DEPT_REF_ID
                                                , MAP_VERSION_ID
                                                , ISKPILISTVIEW
                                                , ENUMLINETYPE
                                                , 0
                                                , FULLSCREEN);
        else
            stgMap = new StgMaps_Biz(YEAR
                                                , TMCODE
                                                , ESTTERM_REF_ID
                                                , EST_DEPT_REF_ID
                                                , MAP_VERSION_ID
                                                , ISKPILISTVIEW
                                                , ENUMLINETYPE
                                                , 0
                                                , IWORKINGMAP_YN
                                                , FULLSCREEN);

        if (IWORKINGMAP_YN == "H")
            IWORKINGMAP_YN = "Y";
        else if (IWORKINGMAP_YN == "Y")
            IWORKINGMAP_YN = "H";

        ltrScript.Text = stgMap.Script_Stg_Map;
    }

    private void SetQueryStringData() 
    {
        _empSysInfo = new EmpSysInfos_Biz(gUserInfo.Emp_Ref_ID);

        if (GetRequest("ESTTERM_REF_ID").Equals(""))
        {
            TermInfos term  = new TermInfos();
            DataView dw     = term.GetAllTermInfo().Tables[0].DefaultView;

            for (int i = 0; i < dw.Table.Rows.Count; i++)
            {
                if (Convert.ToInt32(dw.Table.Rows[i]["EST_STATUS"]) == 1)
                {
                    ESTTERM_REF_ID = int.Parse(dw.Table.Rows[i]["ESTTERM_REF_ID"].ToString());
                    return;
                }
            }
        }
        else
        {
            ESTTERM_REF_ID = GetRequestByInt("ESTTERM_REF_ID");
        }

        if (GetRequest("EST_DEPT_REF_ID").Equals(""))
        {
            EST_DEPT_REF_ID = _estDeptInfo.GetRootEstDeptID(ESTTERM_REF_ID);
        }
        else
        {
            EST_DEPT_REF_ID = GetRequestByInt("EST_DEPT_REF_ID");
        }

        MAP_VERSION_ID = GetRequestByInt("MAP_VERSION_ID");

        if (GetRequest("TMCODE").Equals(""))
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
            TMCODE = objTerm.GetReleasedMonth();
        }
        else
        {
            TMCODE = GetRequest("TMCODE");
        }

        string lineType         = "";
        string showKpiList      = "";

        if (GetRequest("LINE_TYPE").Equals(""))
        {
            lineType            = _empSysInfo.GetSysValueByEmpID(1000);
        }
        else 
        {
            lineType            = GetRequest("LINE_TYPE");
        }

        if (GetRequest("SHOW_KPI_LIST").Equals(""))
        {
            showKpiList         = _empSysInfo.GetSysValueByEmpID(1002);
        }
        else 
        {
            showKpiList         = GetRequest("SHOW_KPI_LIST");
        }

        ENUMLINETYPE            = (lineType == "0") ? LineType.Diagonal : LineType.Straight;
        ISKPILISTVIEW           = (showKpiList == "1") ? true : false;
        DRAWING_YN              = GetRequest("DRAWING_YN","N");

        if (!IsPostBack)
            IWORKINGMAP_YN = GetRequest("WORKINGMAPYN", "N");

        FULLSCREEN              = GetRequest("FULLSCREEN", "N");
    }

    protected void ltnSaveDrawing_Click(object sender, EventArgs e)
    {
        int okCnt = DoSaving();
        ltrScript_PostBack.Text = JSHelper.GetAlertRedirectScript("저장 되었습니다", "usr_stg_map.aspx", true);
    }

    protected void ltnCancel_Click(object sender, EventArgs e)
    {
        ltrScript_PostBack.Text = JSHelper.GetBlankScript("location.replace('usr_stg_map.aspx'+location.search);");
    }

    protected void ItnReset_Click(object sender, EventArgs e)
    {
        int okCnt = DoDeleting();
        ltrScript_PostBack.Text = JSHelper.GetAlertRedirectScript("초기화 되었습니다", "usr_stg_map.aspx", true);
    }

    protected void ibtnPivotWorkMap_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    private int DoDeleting()
    {
        Biz_Bsc_Map_Stg_Manual_Biz biz = new Biz_Bsc_Map_Stg_Manual_Biz();
        int okCnt = biz.Remove_BSC_MAP_STG_MANUAL(ESTTERM_REF_ID
                                                , EST_DEPT_REF_ID
                                                , TMCODE);

        return okCnt;
    }

    private int DoSaving()
    {
        int okCnt = 0;

        string st_up_tbl_id = hdf_StartUpTblID.Value;
        string st_tbl_id    = hdf_StartTblID.Value;
        string ed_up_tbl_id = hdf_EndUpTblID.Value;
        string ed_tbl_id    = hdf_EndTblID.Value;

        Biz_Bsc_Map_Stg_Manual_Biz biz = new Biz_Bsc_Map_Stg_Manual_Biz();

        if (hdfArrX1.Value.Length > 1)
        {
            string[] arrX1 = hdfArrX1.Value.Remove(0, 1).Split(',');
            string[] arrY1 = hdfArrY1.Value.Remove(0, 1).Split(',');
            string[] arrX2 = hdfArrX2.Value.Remove(0, 1).Split(',');
            string[] arrY2 = hdfArrY2.Value.Remove(0, 1).Split(',');

            okCnt = biz.Add_BSC_MAP_STG_MANUAL(ESTTERM_REF_ID
                                             , EST_DEPT_REF_ID
                                             , TMCODE
                                             , st_up_tbl_id
                                             , st_tbl_id
                                             , ed_up_tbl_id
                                             , ed_tbl_id
                                             , arrX1
                                             , arrY1
                                             , arrX2
                                             , arrY2
                                             , EMP_REF_ID
                                             , DateTime.Now
                                             , MAP_VERSION_ID);
        }

        return okCnt;
    }

    private string DoManualdrawing()
    {
        string st_up_tbl_id = string.Empty;
        string st_tbl_id    = string.Empty;
        string ed_up_tbl_id = string.Empty;
        string ed_tbl_id    = string.Empty;

        Biz_Bsc_Map_Stg_Manual_Biz biz = new Biz_Bsc_Map_Stg_Manual_Biz();
        DataSet ds = biz.Get_BSC_MAP_STG_MANUAL(ESTTERM_REF_ID
                                              , EST_DEPT_REF_ID
                                              , TMCODE
                                              , st_up_tbl_id
                                              , st_tbl_id
                                              , ed_up_tbl_id
                                              , ed_tbl_id);

        string script_pointXY = " var xy = getXY('tblContent','{0}','{1}').split('_'); var x1 = xy[0];  var y1 = xy[1]; ";

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

                    st_up_tbl_id    = row["ST_UP_TBL_ID"].ToString();
                    st_tbl_id       = row["ST_TBL_ID"].ToString();
                    ed_up_tbl_id    = row["ED_UP_TBL_ID"].ToString();
                    ed_tbl_id       = row["ED_TBL_ID"].ToString();

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

                string line_point = string.Format(" jg2.drawLine({0}, {1}, {2}, {3}); ", point1, point2, point3, point4);

                if (i == ds.Tables[0].Rows.Count - 1)
                {
                    string[] stTemp = st_up_tbl_id.Split('_');
                    string[] edTemp = ed_up_tbl_id.Split('_');

                    if (stTemp[stTemp.Length - 1] == edTemp[edTemp.Length - 1])
                    {
                        line_point = string.Format(@"
var temp = getXY('tblContent','" + ed_up_tbl_id + @"','" + ed_tbl_id + @"').split('_');

var y2 = temp[1];

jg2.drawLine({0}, {1}, {2}, y2); ", point1, point2, point3, point4);
                    }
                    else
                    {

                        line_point = string.Format(@"
var temp = getXY('tblContent','" + ed_up_tbl_id + @"','" + ed_tbl_id + @"').split('_');

var y2 = temp[3];

jg2.drawLine({0}, {1}, {2}, y2); ", point1, point2, point3, point4);
                    }
                }

                sbPoint.Append(line_point);

                point1 = point3;
                point2 = point4;
            }

            REDRAWING_SCRIPT = "  function doManualDrawing(){  jg2.clear(); jg2.setColor('#008800'); "
                             + sbPoint.ToString()
                             //+ "  } ";
            + "  jg2.paint(); } var jg2 = new jsGraphics('divLine');";
        }
        else
        {
            REDRAWING_SCRIPT = "  function doManualDrawing(){ } ";
        }

        return REDRAWING_SCRIPT;
    }
}
