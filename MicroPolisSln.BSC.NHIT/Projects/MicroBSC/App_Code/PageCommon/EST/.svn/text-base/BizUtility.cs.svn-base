using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Estimation.Biz;

using Infragistics.WebUI.UltraWebGrid;

public class BizUtility
{
    private static string goalTong_Type;
    private static string kpi_pool_list;

    public static string GOALTONG_TYPE
    {
        get
        {
            if (goalTong_Type == null)
                return GoalTong.TARGET.ToString();

            return goalTong_Type;
        }
        set
        {
            goalTong_Type = value;
        }
    }

    public static string KPI_POOL_LIST
    {
        get
        {
            if (kpi_pool_list == null)
                return string.Empty;

            return kpi_pool_list;
        }
        set
        {
            kpi_pool_list = value;
        }
    }

    public static int GetDeptID(int emp_ref_id)
    {
        Biz_EmpInfos empInfo    = new Biz_EmpInfos();
        DataSet ds              = empInfo.GetEmpByEmpID(emp_ref_id);

        if(ds.Tables[0].Rows.Count > 0) 
        {
            return DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["DEPT_REF_ID"]);
        }

        return 0;
    }

    #region 부서트리 DataTable

    public static DataTable GetDeptTree(string spaceText) 
    {
        DataTable dtTemp                = null;
        string id_column                = "DEPT_REF_ID";
        string up_id_column             = "UP_DEPT_ID";
        string level_column             = "LEVEL";
        Biz_DeptInfos deptInfo          = new Biz_DeptInfos();
        DataSet ds                      = deptInfo.GetDeptInfos();

        ds.Tables[0].Columns.Add(level_column, typeof(string));

        dtTemp = ds.Tables[0].Clone();

        ds.Relations.Add("Relation", ds.Tables[0].Columns[id_column], ds.Tables[0].Columns[up_id_column], false);

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (DataTypeUtility.GetToInt32(dbRow[up_id_column]) == 0)
            {
                int level           = 0;
                dbRow[level_column] = level;
                dtTemp.ImportRow(dbRow);
                
                PopulateEstDataRow(dtTemp, dbRow, id_column, up_id_column, level_column, level + 1);
            }
        }

        foreach (DataRow dbRow in dtTemp.Rows)
        {
            string space = "";

            int level    = DataTypeUtility.GetToInt32(dbRow["LEVEL"]);

            for (int i = 0; i < level; i++)
            {
                space += spaceText;
            }

            dbRow["DEPT_NAME"] = string.Format("{0}{1}", space, dbRow["DEPT_NAME"]);
        }

        return dtTemp;
    }

	private static void PopulateEstDataRow(   DataTable dtData
                                            , DataRow dbRow
                                            , string id_column
                                            , string up_id_column
                                            , string level_column
                                            , int level)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("Relation"))
        {
            childRow[level_column] = level;
            dtData.ImportRow(childRow);
            PopulateEstDataRow(dtData, childRow, id_column, up_id_column, level_column, level + 1);
        }
    }

    #endregion

    #region 울트라 그리드 에서 부서별, 직급별 가중치 값 리턴

    public static void SetWeightByDptPos( DataRow[] drArrColumnNames
                                        , int comp_id
                                        , DataTable dtWeightData
                                        , DataRowView drw
                                        , CellsCollection cells) 
    {
        foreach(DataRow drColumnName in drArrColumnNames) 
        {
            string columnName = drColumnName["COL_KEY"].ToString();

            if(columnName.IndexOf("WEIGHT_") < 0)
                continue;

            string est_id               = columnName.Replace("WEIGHT_", "");
            Biz_EstInfos estChildInfo   = new Biz_EstInfos(comp_id, est_id);

            if (estChildInfo.Weight_Type != null && estChildInfo.Weight_Type.Equals("DPT")) 
            {
                DataRow[] drArr = dtWeightData.Select(string.Format("EST_ID = '{0}' AND DEPT_REF_ID = {1}", est_id, drw["TGT_DEPT_ID"]));

                if(drArr.Length > 0) 
                {
                    cells.FromKey(columnName).Value = DataTypeUtility.GetToDouble(drArr[0]["WEIGHT"]);
                }
                else 
                {
                    cells.FromKey(columnName).Value = 0;
                }
            }
            else if (estChildInfo.Weight_Type != null && estChildInfo.Weight_Type.Equals("POS")) 
            {
                //1. 해당 Row의 부서 정보로 검색
                //2. 부서_직급,직책에서 해당당 직급,직책으로 적용
                //3. 마지막으로 직급,직책의 값 으로 가중치 적용

                //해당 부서 중 직책, 직급을 선별
                DataRow[] drArrEstPosDetail = dtWeightData.Select(string.Format("EST_ID = '{0}' AND DEPT_REF_ID = {1}", est_id, drw["TGT_DEPT_ID"]), "SEQ");

                string weight = "";

                //선별된 직책, 직급의 순서에 따라
                foreach(DataRow drChildPosDetail in drArrEstPosDetail) 
                {
                    // 기본값이면
                    if(drChildPosDetail["POS_VALUE"].ToString().Equals("-"))
                    {
                        cells.FromKey(columnName).Value = DataTypeUtility.GetToDouble(drChildPosDetail["WEIGHT"]);
                        break;
                    }
                    else // 선별된 직급
                    {
                        if (drw[string.Format("TGT_POS_{0}_ID", drChildPosDetail["POS_ID"])].ToString().Equals(drChildPosDetail["POS_VALUE"].ToString()))
                        {
                            weight = DataTypeUtility.GetString(drChildPosDetail["WEIGHT"]);
                            //cells.FromKey(columnName).Value = DataTypeUtility.GetToDouble(drChildPosDetail["WEIGHT"]);
                            break;
                        }
                    }
                }

                if (weight.Length > 0)
                {
                    cells.FromKey(columnName).Value = DataTypeUtility.GetToDouble(weight);
                }
                else
                { 
                    //직급별 가중치 테이블에 데이터가 없을 경우
                }
            }
            else 
            {
                cells.FromKey(columnName).Value = 0;
            }
        }
    }

    public static void SetGradeByScale_ABS(DataTable dtScopeData
                                        , DataRowView drw
                                        , CellsCollection cells) 
    {
        // 계산된 등급 컬럼에 절대평가의 범위 구간에 따라 해당하는 평가등급으로 반환한다.
        string columnName                       = "GRADE_CALC_ID";
        string scaleColumnName                  = "SCALE_NAME";

        cells.FromKey(scaleColumnName).Value    = "절대평가";

        if(dtScopeData.Rows.Count > 0) 
        {
            double point    = DataTypeUtility.GetToDouble(drw["POINT"]);
            
            DataRow[] drArrScope = dtScopeData.Select(string.Format(@"SCALE_ID    = '{0}' 
                                                                  AND START_SCOPE <= {1} 
                                                                  AND END_SCOPE   > {1}" 
                                                                    , "ABS"
                                                                    , point));

            if(drArrScope.Length > 0) 
            {
                cells.FromKey(columnName).Value = drArrScope[0]["GRADE_ID"];
            }
            else
            {
                cells.FromKey(columnName).Value = "";
            }
        }
        else 
        {
            cells.FromKey(columnName).Value = "";
        }
    }

    public static void SetGradeByScale_REL(DataTable dtScopeData
                                        , DataTable dtEstData
                                        , DataRowView drw
                                        , CellsCollection cells) 
    {
        // 계산된 등급컬럼에 상대평가에 따라 현재의 등수를 총수로 나눠
        // 상위%값을 받아서 등급의 범위 구간에 따라  최종 등급을 반환 받는다.
        string columnName                       = "GRADE_CALC_ID";
        string scaleColumnName                  = "SCALE_NAME";

        cells.FromKey(scaleColumnName).Value    = "상대평가";

        if(dtScopeData.Rows.Count > 0) 
        {
            string rel_grp_id       = DataTypeUtility.GetValue(drw["REL_GRP_ID"]);
            double total_cnt        = 0;
            double self_rank        = 0;
            double self_rank_pct    = 0;

            if(rel_grp_id.Equals("")) 
            {
                cells.FromKey(columnName).Value = "";
                return;
            }

            DataRow[] dtArrEstDataByRelGrpID    = dtEstData.Select(string.Format("REL_GRP_ID = '{0}'", rel_grp_id), "POINT DESC");
            total_cnt                           = dtArrEstDataByRelGrpID.Length;
            DataRow dataRowSelf                 = null;

            for(int i = 0; i <= total_cnt - 1; i++) 
            {
                dtArrEstDataByRelGrpID[i]["RANK"] = i + 1;

                if(    DataTypeUtility.GetToInt32(drw["TGT_DEPT_ID"]) == DataTypeUtility.GetToInt32(dtArrEstDataByRelGrpID[i]["TGT_DEPT_ID"])
                    && DataTypeUtility.GetToInt32(drw["TGT_EMP_ID"])  == DataTypeUtility.GetToInt32(dtArrEstDataByRelGrpID[i]["TGT_EMP_ID"]))
                {
                    self_rank   = i + 1;
                    dataRowSelf = dtArrEstDataByRelGrpID[i];
                }
            }

            self_rank_pct       = (self_rank / total_cnt) * 100.00;

            DataRow[] drArrScope = dtScopeData.Select(string.Format(@"SCALE_ID    = '{0}' 
                                                                  AND START_SCOPE <= {1} 
                                                                  AND END_SCOPE   > {1}" 
                                                                    , "REL"
                                                                    , self_rank_pct));

            if(drArrScope.Length > 0) 
            {
                // 동점자 처리 내용
                if(self_rank > 1) //----------------------------
                {
                    DataRow[] drArrUpEstData = dtEstData.Select(string.Format("REL_GRP_ID = '{0}' AND RANK = {1}"
                                                                                , rel_grp_id
                                                                                , self_rank - 1));

                    // 상위 랭킹이 존재하는지 체크
                    if(drArrUpEstData.Length > 0) 
                    {
                        if(    (DataTypeUtility.GetToDouble(dataRowSelf["POINT"]) == DataTypeUtility.GetToDouble(drArrUpEstData[0]["POINT"]))
                            && (DataTypeUtility.GetValue(dataRowSelf[columnName]) != DataTypeUtility.GetValue(drArrUpEstData[0][columnName]))
                            )
                        {
                            dataRowSelf[columnName]         = DataTypeUtility.GetValue(drArrUpEstData[0][columnName]);
                            cells.FromKey(columnName).Value = DataTypeUtility.GetValue(drArrUpEstData[0][columnName]);
                        }
                        else 
                        {
                            dataRowSelf[columnName]         = drArrScope[0]["GRADE_ID"];
                            cells.FromKey(columnName).Value = drArrScope[0]["GRADE_ID"];
                        }
                    }
                    else 
                    {
                        dataRowSelf[columnName]         = drArrScope[0]["GRADE_ID"];
                        cells.FromKey(columnName).Value = drArrScope[0]["GRADE_ID"];
                    }
                }
                else 
                {
                    dataRowSelf[columnName]         = drArrScope[0]["GRADE_ID"];
                    cells.FromKey(columnName).Value = drArrScope[0]["GRADE_ID"];
                }
            }//----------------------------
            else
            {
                cells.FromKey(columnName).Value = "";
            }
        }
        else 
        {
            cells.FromKey(columnName).Value = "";
        }
    }

    public static void SetGradeToPoint(DataTable dtScopeData
                                    , DataRowView drw
                                    , CellsCollection cells) 
    {
        string columnName = "GRADE_TO_POINT_CALC";

        string grade_id    = drw["GRADE_ID"].ToString();
        string scale_id    = "ABS";
        
        DataRow[] drArrScope = dtScopeData.Select(string.Format("SCALE_ID = '{0}' AND GRADE_ID = '{1}'" 
                                                                , scale_id
                                                                , grade_id));

        if(drArrScope.Length > 0) 
        {
            cells.FromKey(columnName).Value = drArrScope[0]["GRADE_TO_POINT"];
        }
        else
        {
            cells.FromKey(columnName).Value = "";
        }
    }

    // 상태값 이미지 적용하기
    public static void SetStatusImage(DataRowView drw
                                    , CellsCollection cells) 
    {
        string column = "STATUS_IMG_PATH";

        if(!cells.Exists(column))
            return;

        if(drw.DataView.Table.Columns.Contains(column))
        {
            if(drw[column] == DBNull.Value) 
            {
                cells.FromKey(column).Value = string.Format("<img src='{0}'>", "../images/icon/color/red.gif");
            }
            else 
            {
                cells.FromKey(column).Value = string.Format("<img src='{0}'>", drw[column]);
            }
        }
    }

    // 점수그래프 적용하기
    public static void SetPointBar(DataRowView drw
                                 , CellsCollection cells) 
    {
        string column = "POINT_BAR";

        if(!cells.Exists(column))
            return;

        if(drw["POINT"] != DBNull.Value)
            cells.FromKey(column).Value = string.Format("<img src='{0}' width='{1}%' height='8px'>"
                                                        , "../images/bg/point_bar.gif"
                                                        , drw["POINT"]);
    }

    // 점수 조정 적용하기
    public static void SetCtrlPoint(  DataRowView drw
                                    , CellsCollection cells
                                    , DataTable dtColumnInfo
                                    , DataTable dtCtrlInfo
                                    , DataTable dtCtrlEstDeptMap
                                    , DataTable dtCtrlPointData
                                    , int cur_emp_id) 
    {
        // 조정점수 컬럼
        string column = "CTRL_POINT";

        if(!cells.Exists(column))
            return;

        DataRow[] drArr = dtColumnInfo.Select(string.Format(  @"COL_STYLE_ID = 'BIZ' 
                                                            AND VISIBLE_YN   = 'Y'
                                                            AND COL_KEY      = '{0}'"
                                                            , column));

        if(drArr.Length > 0) 
        {
            DataRow[] drArrCtrlPointData = dtCtrlPointData.Select(string.Format(@"TGT_DEPT_ID = {0} AND TGT_EMP_ID = {1}"
                                                                                , drw["TGT_DEPT_ID"]
                                                                                , drw["TGT_EMP_ID"]), "CTRL_SEQ DESC");

            foreach(DataRow drData in drArrCtrlPointData) 
            {
                if(DataTypeUtility.GetValue(drData["CTRL_YN"]).Equals("Y")) 
                {
                    cells.FromKey(column).Value = "<b><font color='#929292'>조정확정 완료</font></b>";
                    return;
                }
            }

            DataRow[] drArrCtrlInfo = dtCtrlInfo.Select(string.Format(@"CTRL_EMP_ID       = {0} 
                                                                    AND POINT_GRADE_TYPE  = 'PNT'", cur_emp_id));

            // 조정정보가 존재하는지 체크
            if(drArrCtrlInfo.Length > 0) 
            {
                DataRow[] drArrCtrlEstDeptMap = dtCtrlEstDeptMap.Select(string.Format(@"CTRL_ID             = '{0}' 
                                                                                      AND DEPT_REF_ID       = {1}"
                                                                                    , drArrCtrlInfo[0]["CTRL_ID"]
                                                                                    , drw["TGT_DEPT_ID"]));

                // 조정정보에 따른 부서정보가 존재하는지 또는 모든 평가부서 체크인지 확인
                if(    drArrCtrlEstDeptMap.Length > 0 
                    || DataTypeUtility.GetYNToBoolean(drArrCtrlInfo[0]["ALL_EST_DEPT_YN"].ToString()) == true) 
                {
                    cells.FromKey(column).Value = string.Format(  "<a href='#null' onclick=\"ViewCtrlPage('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');\"><font color='#2080D0'>점수조정 가능</font></a>"
                                                                , drArrCtrlInfo[0]["CTRL_ID"]
                                                                , drw["COMP_ID"]
                                                                , drw["EST_ID"]
                                                                , drw["ESTTERM_REF_ID"]
                                                                , drw["ESTTERM_SUB_ID"]
                                                                , drw["ESTTERM_STEP_ID"]
                                                                , drw["EST_DEPT_ID"]
                                                                , drw["EST_EMP_ID"]
                                                                , cur_emp_id
                                                                , drw["TGT_DEPT_ID"]
                                                                , drw["TGT_EMP_ID"]
                                                                , "PNT");
                }
                else 
                {
                    cells.FromKey(column).Value = "<font color='red'>권한부서 없음</font>";
                }
            }
            else 
            {
                cells.FromKey(column).Value = "&nbsp;";//"<font color='red'>조정권한 없음</font>";
            }
        }
        else 
        {
            cells.FromKey(column).Value = "<font color='red'>컬럼정보 없음</font>";
        }
    }

    // 등급 조정 적용하기
    public static void SetCtrlGrade(  DataRowView drw
                                    , CellsCollection cells
                                    , DataTable dtColumnInfo
                                    , DataTable dtCtrlInfo
                                    , DataTable dtCtrlEstDeptMap
                                    , DataTable dtCtrlGradeData
                                    , int cur_emp_id) 
    {
        // 등급조정 컬럼
        string column = "CTRL_GRADE";

        if(!cells.Exists(column))
            return;

        DataRow[] drArr = dtColumnInfo.Select(string.Format(  @"COL_STYLE_ID = 'BIZ' 
                                                            AND VISIBLE_YN   = 'Y'
                                                            AND COL_KEY      = '{0}'"
                                                            , column));

        if(drArr.Length > 0) 
        {
            DataRow[] drArrCtrlGradeData = dtCtrlGradeData.Select(string.Format(@"TGT_DEPT_ID = {0} AND TGT_EMP_ID = {1}"
                                                                                , drw["TGT_DEPT_ID"]
                                                                                , drw["TGT_EMP_ID"]), "CTRL_SEQ DESC");

            foreach(DataRow drData in drArrCtrlGradeData) 
            {
                if(DataTypeUtility.GetValue(drData["CTRL_YN"]).Equals("Y")) 
                {
                    cells.FromKey(column).Value = "<b><font color='#929292'>조정확정 완료</font></b>";
                    return;
                }
            }

            DataRow[] drArrCtrlInfo = dtCtrlInfo.Select(string.Format(@"CTRL_EMP_ID       = {0} 
                                                                    AND POINT_GRADE_TYPE  = 'GRD'", cur_emp_id));

            // 조정정보가 존재하는지 체크
            if(drArrCtrlInfo.Length > 0) 
            {
                DataRow[] drArrCtrlEstDeptMap = dtCtrlEstDeptMap.Select(string.Format(@"CTRL_ID         = '{0}' 
                                                                                      AND DEPT_REF_ID   = {1}"
                                                                                    , drArrCtrlInfo[0]["CTRL_ID"]
                                                                                    , drw["TGT_DEPT_ID"]));

                // 조정정보에 따른 부서정보가 존재하는지 체크
                if(    drArrCtrlEstDeptMap.Length > 0
                    || DataTypeUtility.GetYNToBoolean(drArrCtrlInfo[0]["ALL_EST_DEPT_YN"].ToString()) == true) 
                {
                    cells.FromKey(column).Value = string.Format(  "<a href='#null' onclick=\"ViewCtrlPage('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');\"><font color='#2080D0'>등급조정 가능</font></a>"
                                                                , drArrCtrlInfo[0]["CTRL_ID"]
                                                                , drw["COMP_ID"]
                                                                , drw["EST_ID"]
                                                                , drw["ESTTERM_REF_ID"]
                                                                , drw["ESTTERM_SUB_ID"]
                                                                , drw["ESTTERM_STEP_ID"]
                                                                , drw["EST_DEPT_ID"]
                                                                , drw["EST_EMP_ID"]
                                                                , cur_emp_id
                                                                , drw["TGT_DEPT_ID"]
                                                                , drw["TGT_EMP_ID"]
                                                                , "GRD");
                }
                else 
                {
                    cells.FromKey(column).Value = "<font color='red'>권한부서 없음</font>";
                }
            }
            else 
            {
                cells.FromKey(column).Value = "&nbsp;";//"<font color='red'>조정권한 없음</font>";
            }
        }
        else 
        {
            cells.FromKey(column).Value = "<font color='red'>컬럼정보 없음</font>";
        }
    }

    #endregion

    // 평가 트리 DataTable 반환
    public static DataTable GetEstIDTree(int comp_id, int estterm_ref_id, int estterm_sub_id )
	{
		DataTable dtTemp    = null;
		string id_column    = "EST_ID";
		string up_id_column = "UP_EST_ID";
		string level_column = "LEVEL";

		Biz_EstMap estMap = new Biz_EstMap();
		DataSet ds        = estMap.GetEstMap(comp_id,  estterm_ref_id, estterm_sub_id );

		ds.Tables[0].Columns.Add(level_column, typeof(string));

		dtTemp = ds.Tables[0].Clone();

		ds.Relations.Add( "Relation", ds.Tables[0].Columns[id_column], ds.Tables[0].Columns[up_id_column], false );

		foreach ( DataRow dbRow in ds.Tables[0].Rows )
		{
			if ( dbRow[up_id_column] == DBNull.Value )
			{
				int level           = 0;
				dbRow[level_column] = level;
				dtTemp.ImportRow( dbRow );

				PopulateEstDataRow( dtTemp, dbRow, id_column, up_id_column, level_column, level + 1 );
			}
		}

		return dtTemp;
	}

    public static DataTable GetEstIDTree(int comp_id)
	{
		DataTable dtTemp    = null;
		string id_column    = "EST_ID";
		string up_id_column = "UP_EST_ID";
		string level_column = "LEVEL";

		Biz_EstMap estMap = new Biz_EstMap();
        DataSet ds        = estMap.GetEstMap4Valid(comp_id);

		ds.Tables[0].Columns.Add( level_column, typeof( string ) );

		dtTemp = ds.Tables[0].Clone();

		ds.Relations.Add("Relation", ds.Tables[0].Columns[id_column], ds.Tables[0].Columns[up_id_column], false);

		foreach ( DataRow dbRow in ds.Tables[0].Rows )
		{
			if ( dbRow[up_id_column] == DBNull.Value )
			{
				int level           = 0;
				dbRow[level_column] = level;
				dtTemp.ImportRow( dbRow );

				PopulateEstDataRow( dtTemp, dbRow, id_column, up_id_column, level_column, level + 1 );
			}
		}

		return dtTemp;
	}

    /// <summary>
    /// 평가주기의 총가중치 합 반환
    /// </summary>
    /// <param name="est_id"></param>
    /// <returns></returns>
    public static double GetTotalWeightEstTermSub(int comp_id, string est_id) 
    {
        Biz_TermSubEstMaps estterm  = new Biz_TermSubEstMaps();
        DataTable dataTable         = estterm.GetTermSubEstMap(comp_id, est_id, "").Tables[0];

        double total = 0;

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            total += DataTypeUtility.GetToDouble(dataRow["WEIGHT"]);
        }

        if(total == 0) 
            return 100;

        return total;
    }

    /// <summary>
    /// 평가 주기의 가중치 String
    /// </summary>
    /// <param name="comp_id"></param>
    /// <param name="est_id"></param>
    /// <returns></returns>
    public static string GetWeightStringByEstTermSub(int comp_id, string est_id) 
    {
        Biz_TermSubEstMaps estterm  = new Biz_TermSubEstMaps();
        DataTable dataTable         = estterm.GetTermSubEstMap(comp_id, est_id, "").Tables[0];

        string temp     = "";
        bool isFirst    = true;

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            if(isFirst) 
            {
                temp    += DataTypeUtility.GetToDouble(dataRow["WEIGHT"]).ToString("#,##0.00");
                isFirst = false;
            }
            else 
            {
                temp    += " : " + DataTypeUtility.GetToDouble(dataRow["WEIGHT"]).ToString("#,##0.00");
            }
        }

        return temp;
    }

    /// <summary>
    /// 평가차수의 총가중치 합 반환
    /// </summary>
    /// <param name="est_id"></param>
    /// <returns></returns>
    public static double GetTotalWeightEstTermStep(int comp_id, string est_id) 
    {
        Biz_EstInfos estInfo         = new Biz_EstInfos(comp_id, est_id);

        Biz_TermStepEstMaps estterm  = new Biz_TermStepEstMaps();
        DataTable dataTable          = estterm.GetTermStepEstMap(comp_id, est_id).Tables[0];

        double total = 0;

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            // 상향평가가 아닌 가중치만 더한다.
            if(!DataTypeUtility.GetYNToBoolean(DataTypeUtility.GetValue(dataRow["FIXED_WEIGHT_YN"])))
                total += DataTypeUtility.GetToDouble(dataRow["WEIGHT"]);
        }

        // 만약 상향평가일 경우 고정가중치를 더해준다.
        if(DataTypeUtility.GetYNToBoolean(estInfo.Fixed_Weight_Use_YN))
            total += DataTypeUtility.GetToDouble(estInfo.Fixed_Weight);

        if(total == 0) 
            return 100;

        return total;
    }

     public static string GetWeightStringByEstTermStep(int comp_id, string est_id) 
    {
        Biz_TermStepEstMaps estterm  = new Biz_TermStepEstMaps();
        DataTable dataTable          = estterm.GetTermStepEstMap(comp_id, est_id).Tables[0];

        string temp     = "";
        bool isFirst    = true;

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            if(isFirst) 
            {
                temp    += DataTypeUtility.GetToDouble(dataRow["WEIGHT"]).ToString("#,##0.00");
                isFirst = false;
            }
            else 
            {
                temp    += " : " + DataTypeUtility.GetToDouble(dataRow["WEIGHT"]).ToString("#,##0.00");
            }
        }

        return temp;
    }

    public static int GetEstTermSubIDByYearYN(int comp_id) 
    {
        Biz_TermSubs termSub    = new Biz_TermSubs();
        DataTable dataTable     = termSub.GetTermSubByYearYN(comp_id, "Y").Tables[0];

        if(dataTable.Rows.Count > 0)
        {
            return DataTypeUtility.GetToInt32(dataTable.Rows[0]["ESTTERM_SUB_ID"]);
        }

        return -1;
    }

    public static int GetEstTermStepIDByMergeYN(int comp_id) 
    {
        Biz_TermSteps termStep  = new Biz_TermSteps();
        DataTable dataTable     = termStep.GetTermStepByMergeYN(comp_id, "Y").Tables[0];

        if(dataTable.Rows.Count > 0)
        {
            return DataTypeUtility.GetToInt32(dataTable.Rows[0]["ESTTERM_STEP_ID"]);
        }

        return -1;
    }

    /// <summary>
    /// 현재 로그인 유저의 Role에 Command_Name으로 Button의 Visible 속성 제어
    /// </summary>
    /// <param name="emp_ref_id"></param>
    public static void SetButtonVisibleCommandNameByRolID(   int emp_ref_id
                                                            , ControlCollection controls) 
    {
        Biz_ButtonCommandRoleMaps btnRoleMap    = new Biz_ButtonCommandRoleMaps();
        DataTable dataTable                     = btnRoleMap.GetButtonCommandsByEmpID(emp_ref_id).Tables[0];

        foreach(Control control in controls) 
        {
            if(control is ImageButton) 
            {
                ImageButton ibn     = (ImageButton) control;
                string command_name = ibn.CommandName;

                // COMMAND_NAME를 부여한 ImageButton만 처리한다.
                if(!command_name.Equals("") && ibn.Visible == false) 
                {
                    if(dataTable.Select(string.Format("COMMAND_NAME = '{0}'", command_name)).Length > 0)
                        ibn.Visible = true;
                }
            }
        }
    }

    public static void SetButtonVisibleCommandNameByRolID(int emp_ref_id, ImageButton ibn) 
    {
        Biz_ButtonCommandRoleMaps btnRoleMap    = new Biz_ButtonCommandRoleMaps();
        DataTable dataTable                     = btnRoleMap.GetButtonCommandsByEmpID(emp_ref_id).Tables[0];

        string command_name                     = ibn.CommandName;

        // COMMAND_NAME를 부여한 ImageButton만 처리한다.
        if(!command_name.Equals("") && ibn.Visible == false) 
        {
            if(dataTable.Select(string.Format("COMMAND_NAME = '{0}'", command_name)).Length > 0)
                ibn.Visible = true;
        }
    }

    /// <summary>
    /// EST_JOB_ID에 따라 버튼을 보여주기 여부 체크
    /// </summary>
    /// <param name="emp_ref_id"></param>
    public static void SetButtonVisibleByEstJobID(   string est_job_ids
                                                    , ControlCollection controls
                                                    , int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , int estterm_step_id) 
    {
        foreach(Control control in controls) 
        {
            if(control is ImageButton) 
            {
                ImageButton ibn         = (ImageButton) control;
                string btn_est_job_id   = ibn.CommandArgument;

                if (btn_est_job_id.Equals(""))
                {
                    if (est_id == "3GA")
                    {
                        if (est_job_ids == "JOB_91" && ibn.CommandName != "BIZ_DOWN_EXCEL")
                            ibn.Visible = false;
                        else if (est_job_ids == "JOB_07" && ibn.CommandName != "BIZ_CONFIRM_BY_FORCE" && ibn.CommandName != "BIZ_DOWN_EXCEL" && ibn.CommandName != "BIZ_SEARCH_ALL")
                            ibn.Visible = false;
                        else if (est_job_ids == "JOB_09" && ibn.CommandName == "BIZ_SEARCH_EMP")
                            ibn.Visible = false;
                        continue;
                    }
                    else
                        continue;
                }

                ibn.Visible = false;

                // COMMAND_NAME를 부여한 ImageButton만 처리한다.
                foreach(string est_job_id in est_job_ids.Split(',')) 
                {
                    if(est_job_id.Equals(btn_est_job_id)) 
                    {
                        EstJobUtility.SetConfirmButtonVisible(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , est_job_id
                                                            , ibn
                                                            , null);
                    }
                    //else 
                    //{
                    //    ibn.Visible = false;
                    //}
                }
            }
        }
    }

    /// <summary>
    /// EST_JOB_ID에 따라 버튼을 보여주기 여부 체크
    /// </summary>
    /// <param name="emp_ref_id"></param>
    public static void SetButtonVisibleByEstJobID(   string est_job_ids
                                                    , ImageButton ibn
                                                    , int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , int estterm_step_id) 
    {
        string btn_est_job_id   = ibn.CommandArgument;

        ibn.Visible = false;

        if(btn_est_job_id.Equals(""))
            return;

        // COMMAND_NAME를 부여한 ImageButton만 처리한다.
        foreach(string est_job_id in est_job_ids.Split(',')) 
        {
            if(est_job_id.Equals(btn_est_job_id)) 
            {
                EstJobUtility.SetConfirmButtonVisible(comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , est_job_id
                                                    , ibn
                                                    , null);
            }
            //else 
            //{
            //    ibn.Visible = false;
            //}
        }
    }

    public static OwnerType GetOwnerType(string ownerType) 
    {
        if(ownerType.Equals("D")) 
        {
            return OwnerType.Dept;
        }
        else if(ownerType.Equals("P")) 
        {
            return OwnerType.Emp_User;
        }

        return OwnerType.All;
    }

    /// <summary>
    /// 상대그룹 아이디에 따른 상대그룹 대상자 WHERE String 를 반환한다.
    /// </summary>
    /// <param name="comp_id"></param>
    /// <param name="est_id"></param>
    /// <param name="estterm_ref_id"></param>
    /// <param name="rel_grp_id">상대그룹 아이디</param>
    /// <param name="tbl_alias">테이블 별칭</param>
    /// <returns></returns>
    public static string GetRelGroupWhereString(  int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , string rel_grp_id
                                                , string tbl_alias)
    {
        StringBuilder sbSentence = new StringBuilder();

        Biz_RelGroupPositionInfos bizInfos = new Biz_RelGroupPositionInfos();
        DataSet dsInfos                    = bizInfos.GetRelGroupPosInfo(comp_id
                                                                        ,""
                                                                        ,rel_grp_id
                                                                        ,est_id
                                                                        ,estterm_ref_id);

        for (int i = 0; i < dsInfos.Tables[0].Rows.Count; i++)
        {
            string rel_grp_pos_id = dsInfos.Tables[0].Rows[i]["REL_GRP_POS_ID"].ToString();
            string optInfos       = dsInfos.Tables[0].Rows[i]["OPT_VALUE"].ToString();

            Biz_RelGroupPositionDatas bizdatas = new Biz_RelGroupPositionDatas();
            DataSet dsDatas                    = bizdatas.GetRelGroupPosData(comp_id
                                                                            ,""
                                                                            ,rel_grp_id
                                                                            ,rel_grp_pos_id
                                                                            ,est_id
                                                                            ,estterm_ref_id);
            if(i == 0 && dsDatas.Tables[0].Rows.Count > 0)
                optInfos = optInfos.ToUpper().Replace("OR", "").Replace("AND", "").Replace("END", "");

            if(dsDatas.Tables[0].Rows.Count > 0)
                sbSentence.Append(string.Format(" {0} ( ", optInfos));

            for (int k = 0 ; k < dsDatas.Tables[0].Rows.Count ; k++)
            {
                string optDatas  = dsDatas.Tables[0].Rows[k]["OPT_VALUE"].ToString();
                string pos_id    = dsDatas.Tables[0].Rows[k]["POS_ID"].ToString();
                string pos_value = dsDatas.Tables[0].Rows[k]["POS_VALUE"].ToString();

                if (k == 0)
                    optDatas = optDatas.ToUpper().Replace("OR", "").Replace("AND", "").Replace("END", "");

                sbSentence.Append(string.Format(" {0} " + tbl_alias + ".TGT_POS_{1}_ID = '{2}' ", optDatas, pos_id, pos_value));                    
            }

            if(dsDatas.Tables[0].Rows.Count > 0)
                sbSentence.Append(" ) ");
        }

        Biz_RelGroupDepts bizDept   = new MicroBSC.Estimation.Biz.Biz_RelGroupDepts();
        DataSet ds                  = bizDept.GetRelGroupDept(comp_id
                                                           , rel_grp_id
                                                           , 0
                                                           , est_id
                                                           , estterm_ref_id);

        if(ds.Tables[0].Rows.Count > 0) 
        {
            bool isFirst    = true;
            string deptcode = "";

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if(isFirst) 
                {
                    isFirst     = false;
                    deptcode    += row["DEPT_REF_ID"].ToString();
                }
                else 
                {
                    deptcode    += "," + row["DEPT_REF_ID"].ToString();
                }
            }
            
            string opr = (sbSentence.Length > 0) ? " AND " : string.Empty;
            sbSentence.Append(string.Format(opr + tbl_alias + ".TGT_DEPT_ID IN ( {0} ) ", deptcode));
        }

        return sbSentence.ToString();
    }

    public static string GetTgtSendType(string tgt_opinion_yn, string feedback_yn) 
    {
        if(tgt_opinion_yn.Equals("Y") && feedback_yn.Equals("N")) 
        {
            return "OPN";
        }
        else if(tgt_opinion_yn.Equals("N") && feedback_yn.Equals("Y")) 
        {
            return "FBK";
        }

        return "N";
    }

    public static string GetPageLink( DataTable dataTable
                                    , int comp_id
                                    , string est_id
                                    , string tgt_opinion_yn
                                    , string feedback_yn
                                    , string est_tgt_type) 
    {
        DataRow[] drArr    = dataTable.Select(string.Format(@"COMP_ID         = {0}
                                                        AND EST_ID          = '{1}'
                                                        AND (TGT_OPINION_YN = '{2}' OR '{2}' = 'N')
                                                        AND (FEEDBACK_YN    = '{3}' OR '{3}' = 'N')
                                                        AND EST_TGT_TYPE    = '{4}'"
                                                        , comp_id
                                                        , est_id
                                                        , tgt_opinion_yn
                                                        , feedback_yn
                                                        , est_tgt_type));

        if(drArr.Length > 0) 
        {
            DataRow dataRow = drArr[0];

            string temp = "";

            temp += DataTypeUtility.GetValue(dataRow["LINK_DIR"]);
            temp += DataTypeUtility.GetValue(dataRow["LINK_PAGE_NAME"]);

            if(!DataTypeUtility.GetValue(dataRow["EST_ID"]).Equals(""))
                temp        += string.Format("?EST_ID={0}", dataRow["EST_ID"]);

            if(!DataTypeUtility.GetValue(dataRow["EST_JOB_IDS"]).Equals(""))
                temp        += string.Format("&EST_JOB_IDS={0}", dataRow["EST_JOB_IDS"]);

            if(DataTypeUtility.GetValue(dataRow["ESTTERM_STEP_ALL_USE_YN"]).Equals("Y"))
                temp    += string.Format("&ESTTERM_STEP_ALL_USE_YN={0}", dataRow["ESTTERM_STEP_ALL_USE_YN"]);

            if(DataTypeUtility.GetValue(dataRow["YEAR_YN"]).Equals("Y"))
                temp    += string.Format("&YEAR_YN={0}", dataRow["YEAR_YN"]);

            if(DataTypeUtility.GetValue(dataRow["MERGE_YN"]).Equals("Y"))
                temp    += string.Format("&MERGE_YN={0}", dataRow["MERGE_YN"]);

            if(DataTypeUtility.GetValue(dataRow["EST_TGT_TYPE"]).Equals("TGT"))
                temp    += string.Format("&EST_TGT_TYPE={0}", dataRow["EST_TGT_TYPE"]);

            return temp;
        }

        return "#null";
    }

    public static OwnerType GetEnumByOwnerType(string ownerType) 
    {
        if(ownerType.Equals("D")) 
            return OwnerType.Dept;
        else if(ownerType.Equals("P")) 
            return OwnerType.Emp_User;

        return OwnerType.All;
    }

    public static string GetStringByOwnerType(OwnerType ownerType) 
    {
        if(ownerType == OwnerType.Dept) 
            return "D";
        else if(ownerType == OwnerType.Emp_User) 
            return "P";

        return "";
    }

    public static string GetSortColumns(string est_job_ids) 
    {
        Biz_JobInfos jobInfo = null;

        foreach(string est_job_id in est_job_ids.Split(',')) 
        {
            jobInfo = new Biz_JobInfos(est_job_id);

            if(!jobInfo.Sort_Column.Equals(""))
                return jobInfo.Sort_Column;
        }

        return "";
    }
}

