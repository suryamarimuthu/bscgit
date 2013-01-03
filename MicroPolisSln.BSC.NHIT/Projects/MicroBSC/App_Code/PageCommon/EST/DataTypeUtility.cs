using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for DataTypeCommon
/// </summary>
public class DataTypeUtility
{
    public static int GetBooleanToInt32(bool isTrue)
    {
        if (isTrue)
            return 1;
        return 0;
    }

    public static bool GetInt32ToBoolean(int isTrue)
    {
        if (isTrue == 1)
            return true;
        return false;
    }

    public static bool GetToBoolean(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return false;
        }

        return Convert.ToBoolean(obj);
    }

    public static Double GetToDouble(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return 0;
        }

        return Convert.ToDouble(obj.ToString().Replace(",", ""));
    }

    public static Double GetToPlusDouble(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return 0;
        }

        double num = Convert.ToDouble(obj.ToString().Replace(",", ""));

        if(num < 0)
            return num * (-1);

        return num;
    }

    public static Double GetToMinusDouble(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return 0;
        }

        double num = Convert.ToDouble(obj.ToString().Replace(",", ""));

        if(num > 0)
            return num * (-1);

        return num;
    }

    public static string GetToOnlyMinusText(object obj)
    {
        return GetToOnlyMinusText(obj, "#,##0", true);
    }

    /// <summary>
    /// 그리드에서 만약 값이 - 부호가 붙었을 경우 () 로 변경해 주는 메소드
    /// </summary>
    /// <param name="obj">값</param>
    /// <param name="format">포맷</param>
    /// <returns></returns>
    public static string GetToOnlyMinusText(object obj, string format, bool hasRedText)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return "0";
        }

        double num = Convert.ToDouble(obj.ToString().Replace(",", ""));

        if (num >= 0)
            return num.ToString(format);
        else
            num = num * (-1);

        if(hasRedText)
            return string.Format("<font style='color:Red'>({0})</font>", num.ToString(format));
        else
            return string.Format("({0})", num.ToString(format));
    }

	/// <summary>
	/// GetToOnlyMinusText 로 생성된 값을 다시 원래 값(마이너스값)으로 되돌림
	/// </summary>
	public static object GetToOnlyPlusText( object getToOnlyMinusString )
	{
		object objReturn = getToOnlyMinusString;

		if ( getToOnlyMinusString.ToString().IndexOf( "<font style='color:Red'>(" ) == 0 )
		{
			string strReturn = getToOnlyMinusString.ToString().Replace( "<font style='color:Red'>(", string.Empty );
			strReturn = strReturn.Replace( ")</font>", string.Empty );

			double dbReturn = Convert.ToDouble( strReturn );
			dbReturn = dbReturn * -1;

			objReturn = dbReturn;
		}

		return objReturn;
	}

    public static float GetToFloat(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return 0;
        }

        return Convert.ToSingle(obj.ToString().Replace(",", ""));
    }

    public static Int32 GetToInt32(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return 0;
        }

        return Convert.ToInt32(obj.ToString().Replace(",", ""));
    }

    public static string GetToInt32_String(object obj, string format)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return "";
        }

        if (int.Parse(obj.ToString()) == 0)
            return "";

        if (format != null)
            return Convert.ToInt32(obj.ToString().Replace(",", "")).ToString(format);

        return Convert.ToInt32(obj).ToString();
    }

    public static Int64 GetToInt64(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return 0;
        }

        return Convert.ToInt64(obj.ToString().Replace(",", ""));
    }

    public static string GetToDateTimeText(object obj)
    {
        return GetToDateTimeText(obj, "yyyy-MM-dd");
    }

    public static string GetToDateTimeText(object obj, string formatString)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return "";
        }

        return Convert.ToDateTime(obj).ToString(formatString);
    }

    public static string GetToLastDateText(object year, object month, bool isReverse) 
    {
        return GetToLastDateText(year, month, isReverse, "yyyy-MM-dd");
    }

    /// <summary>
    /// 전표에서 전표일자를 만들기 위함 메소드
    /// </summary>
    /// <param name="year">년</param>
    /// <param name="month">월</param>
    /// <param name="isReverse">역기표여부</param>
    /// <param name="formatString">포맷</param>
    /// <returns></returns>
    public static string GetToLastDateText(object year, object month, bool isReverse, string formatString)
    {
        if (   year             == null
            || year             == DBNull.Value
            || year.ToString()  == ""
            || month            == null
            || month            == DBNull.Value
            || month.ToString() == ""
            )
        {
            return "";
        }

        string year_str     = year.ToString();
        string month_str    = month.ToString();

        if(month_str.Equals("00"))
            month_str = "01";

        DateTime date = GetToDateTime(year_str + "-" + month_str + "-" + "01");

        // 역기표라면
        if (isReverse)
        {
            return date.ToString(formatString);
        }
        
        return date.AddMonths(1).AddDays(-1).ToString(formatString);
    }

    public static DateTime GetToDateTime(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return DateTime.MinValue;
        }

        return Convert.ToDateTime(obj);
    }

    public static string GetString(object obj)
    {
        if (   obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return "";
        }

        return obj.ToString();
    }

    public static string GetBooleanToYN(bool isTrue)
    {
        if (isTrue)
            return "Y";

        return "N";
    }

    public static bool GetYNToBoolean(string ynStr)
    {
        if (   ynStr == null
            || ynStr.Trim() == "")
            return false;

        if (ynStr.Equals("Y"))
            return true;

        return false;
    }

    public static string GetValue(object obj)
		{
			return GetValue(obj, "");
		}

		public static string GetValue(object obj, string defaultVaue)
		{
			if (   obj == null
				|| obj == DBNull.Value)
			{
				return defaultVaue;
			}

			return obj.ToString();
		}

    public static decimal GetToDecimal(object obj)
    {
        if (obj == null
            || obj == DBNull.Value
            || obj.ToString() == "")
        {
            return 0;
        }

        return Convert.ToDecimal(obj.ToString().Replace(",", ""));
    }

    public static void SetYearMonthByNextMonth(string year
                                            , string month
                                            , out string next_year
                                            , out string next_month)
    {
        if (month.Equals("12")) 
        {
            next_year   = Convert.ToInt32(Convert.ToInt32(year) + 1).ToString();
            next_month  = "00";
        }
        else if (month.Equals("00")) 
        {
            next_year   = year;
            next_month  = "01";
        }

        next_year   = Convert.ToDateTime(year + "-" + month + "-" + "01").AddMonths(1).Year.ToString();
        next_month  = Convert.ToDateTime(year + "-" + month + "-" + "01").AddMonths(1).Month.ToString().PadLeft(2, '0');
    }

    public static string GetInt32ToAlphabet(int index) 
    {
        List<string> list = new List<string>();
        Dictionary<int, string> dic = new Dictionary<int,string>();

        dic.Add(0, "");
        dic.Add(1, "A");
        dic.Add(2, "B");
        dic.Add(3, "C");
        dic.Add(4, "D");
        dic.Add(5, "E");
        dic.Add(6, "F");
        dic.Add(7, "G");
        dic.Add(8, "H");
        dic.Add(9, "I");
        dic.Add(10, "J");
        dic.Add(11, "K");
        dic.Add(12, "L");
        dic.Add(13, "M");
        dic.Add(14, "N");
        dic.Add(15, "O");
        dic.Add(16, "P");
        dic.Add(17, "Q");
        dic.Add(18, "R");
        dic.Add(19, "S");
        dic.Add(20, "T");
        dic.Add(21, "U");
        dic.Add(22, "V");
        dic.Add(23, "W");
        dic.Add(24, "X");
        dic.Add(25, "Y");
        dic.Add(26, "Z");

        if(dic.ContainsKey(index))
            return dic[index];

        return "";
    }

    public static Type GetStringToType(string dataType)
    {
        if (dataType.ToUpper().Equals("STRING")) 
        {
            return typeof(string);
        }
        else if (dataType.ToUpper().Equals("DATETIME")) 
        {
            return typeof(DateTime);
        }
        if (dataType.ToUpper().Equals("INT")) 
        {
            return typeof(int);
        }
        if (dataType.ToUpper().Equals("LONG")) 
        {
            return typeof(long);
        }
        if (dataType.ToUpper().Equals("DOUBLE")) 
        {
            return typeof(double);
        }
        if (dataType.ToUpper().Equals("FLOAT")) 
        {
            return typeof(float);
        }
        if (dataType.ToUpper().Equals("OBJECT")) 
        {
            return typeof(object);
        }
        
        return typeof(object);
    }

    public static bool TryParse(string dataType, object value) 
    {
        DateTime dateTime_out;
        int int_out;
        long long_out;
        double double_out;
        float float_out;

        if (dataType.ToUpper().Equals("STRING")) 
        {
            return true;
        }
        else if (dataType.ToUpper().Equals("DATETIME")) 
        {
            return DateTime.TryParse(value.ToString(), out dateTime_out);
        }
        if (dataType.ToUpper().Equals("INT")) 
        {
            return int.TryParse(value.ToString(), out int_out);
        }
        if (dataType.ToUpper().Equals("LONG")) 
        {
            return long.TryParse(value.ToString(), out long_out);
        }
        if (dataType.ToUpper().Equals("DOUBLE")) 
        {
            return double.TryParse(value.ToString(), out double_out);
        }
        if (dataType.ToUpper().Equals("FLOAT")) 
        {
            return float.TryParse(value.ToString(), out float_out);
        }
        if (dataType.ToUpper().Equals("OBJECT")) 
        {
            return true;
        }
        
        return true;
    }

    public static DataSet FilterSortDataSet(DataSet dsStart, int iTbl, string filter, string sort)
    {
        System.Data.DataTable dt = dsStart.Tables[iTbl].Clone();
        DataRow[] drs   = dsStart.Tables[iTbl].Select(filter, sort);

        foreach (DataRow dr in drs)
        {
            dt.ImportRow(dr);
        }

        DataSet ds = new DataSet();

        for (int i = 0; i < dsStart.Tables.Count; i++)
        {
            if (i == iTbl)
            {
                ds.Tables.Add(dt);
            }
            else
            {
                ds.Tables.Add(dsStart.Tables[i].Copy());
            }
        }

        return ds;
    }

    public static DataSet FilterSortDataSet(DataSet dsStart, string filter, string sort)
    {
        DataSet ds      = dsStart.Clone();
        DataRow[] drs   = dsStart.Tables[0].Select(filter, sort);

        foreach (DataRow dr in drs)
        {
            ds.Tables[0].ImportRow(dr);
        }

        return ds;
    }

    public static System.Data.DataTable FilterSortDataTable(System.Data.DataTable dtStart
                                                        , string filter
                                                        , string sort
                                                        , string tableName)
    {
        System.Data.DataTable dt    = dtStart.Clone();

        if(tableName != null && tableName != "")
            dt.TableName                = tableName;

        DataRow[] drs               = null;

        if(sort == null)
            drs = dtStart.Select(filter);
        else
            drs = dtStart.Select(filter, sort);

        foreach (DataRow dr in drs)
        {
            dt.ImportRow(dr);
        }

        return dt;
    }

    public static System.Data.DataTable FilterSortDataTable(System.Data.DataTable dtStart, string filter)
    {
        return FilterSortDataTable(dtStart, filter, null, null);
    }

    public static System.Data.DataTable FilterSortDataTable(System.Data.DataTable dtStart, string filter, string sort)
    {
        return FilterSortDataTable(dtStart, filter, sort, null);
    }

    #region ========================= 연결 대사 관련 DataTable Groupping Merging =========================


    /// <summary>
    /// 각각의 DataTable를 하나의 DataTable으로 만든다. Row 가 아닌 컬럼으로 합치되 정렬된 순서로 Merge
    /// </summary>
    /// <param name="dataTable_L"></param>
    /// <param name="dataTable_R"></param>
    /// <param name="sort_column_L"></param>
    /// <param name="sort_column_R"></param>
    /// <returns></returns>
    public static DataTable GetMergeSortedDataTable(DataTable dataTable_L, DataTable dataTable_R, string sort_column) 
    {
        DataTable dtMerge   = new DataTable();
        DataRow dataRow     = null;

        foreach (DataColumn column_L in dataTable_L.Columns) 
        {
            if(!dtMerge.Columns.Contains(column_L.ColumnName + "_L"))
                dtMerge.Columns.Add(new DataColumn(column_L.ColumnName + "_L", column_L.DataType));
        }

        foreach (DataColumn column_R in dataTable_R.Columns) 
        {
            if(!dtMerge.Columns.Contains(column_R.ColumnName + "_R"))
                dtMerge.Columns.Add(new DataColumn(column_R.ColumnName + "_R", column_R.DataType));
        }

        int max = (dataTable_L.Rows.Count >= dataTable_R.Rows.Count) ?  dataTable_L.Rows.Count : dataTable_R.Rows.Count;

        for (int i = 0; i < max; i++) 
        {
            dataRow = dtMerge.NewRow();
            dtMerge.Rows.Add(dataRow);
        }

        dataTable_L = FilterSortDataTable(dataTable_L, "", sort_column);
        dataTable_R = FilterSortDataTable(dataTable_R, "", sort_column);

        for (int i = 0; i < dataTable_L.Rows.Count; i++) 
        {
            foreach (DataColumn column_L in dataTable_L.Columns) 
            {
                dtMerge.Rows[i][column_L.ColumnName + "_L"] = dataTable_L.Rows[i][column_L.ColumnName];
                
            }
        }

        for (int i = 0; i < dataTable_R.Rows.Count; i++) 
        {
            foreach (DataColumn column_R in dataTable_R.Columns) 
            {
                dtMerge.Rows[i][column_R.ColumnName + "_R"] = dataTable_R.Rows[i][column_R.ColumnName];
                
            }
        }
        
        return dtMerge;
    }

    //----------- 기존에 DataTable 그룹화 컬럼 추가
    public static DataTable GetDataTableAddAggregateValue(    DataTable originDataTable
                                                            , string aggregateOriginField
                                                            , string[] groupByColumns
                                                            , string aggregateNewField) 
    {
        string aggregateSumField = string.Format("{0}_{1}", "SUM", aggregateNewField);
        string aggregateCntField = string.Format("{0}_{1}", "CNT", aggregateNewField);
        string aggregateAvgField = string.Format("{0}_{1}", "AVG", aggregateNewField);

        originDataTable.Columns.Add(aggregateSumField, typeof(double));
        originDataTable.Columns.Add(aggregateCntField, typeof(double));
        originDataTable.Columns.Add(aggregateAvgField, typeof(double));

        originDataTable.Columns.Add("IS_AGGEGATED", typeof(int));

        // 집계 처리 여부 필드 추가
        foreach (DataRow dr in originDataTable.Rows) 
        {
            dr["IS_AGGEGATED"] = 0;
        }

        DataTable dataTempTable = originDataTable.Clone();
        DataRow[] dataRowCol    = null;
        
        foreach (DataRow dataRow in originDataTable.Rows) 
        {
            dataRowCol             = originDataTable.Select(GetFilterString(dataRow, groupByColumns) + " AND IS_AGGEGATED = 0");
            double aggreSumData    = 0;
            double aggreCntData    = 0;
            double aggreAvgData    = 0;

            if(dataRowCol.Length == 0)
                continue;

            for (int i = 1; i <= dataRowCol.Length; i++) 
            {
                //------- SUM 처리 시작 --------------
                aggreSumData += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField]);
                //------- SUM 처리 끝 --------------

                //------- COUNT 처리 시작 --------------
                if(aggreCntData == 0) 
                    aggreCntData = dataRowCol.Length;
                //------- COUNT 처리 끝 --------------
                
                //------- AVG 처리 시작 --------------
                    aggreAvgData += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField]);

                    if (i == dataRowCol.Length) 
                        aggreAvgData = aggreAvgData / DataTypeUtility.GetToDouble(i);
                //------- AVG 처리 끝 --------------
                
                // 집계처리된 Row
                dataRowCol[i - 1]["IS_AGGEGATED"] = 1;
            }

            foreach (DataRow originDataRow in dataRowCol)
            {
                originDataRow[aggregateSumField] = aggreSumData;
                originDataRow[aggregateCntField] = aggreCntData;
                originDataRow[aggregateAvgField] = Math.Round(aggreAvgData, 4);

                dataTempTable.ImportRow(originDataRow);
            }
        }

        dataTempTable.Columns.Remove("IS_AGGEGATED");


        //------------- 정렬 처리 시작 -----------------------
        DataTable dataSotedTable    = dataTempTable.Clone();
        DataRow[] d               = null;

        dataRowCol = dataTempTable.Select("", GetSortString(groupByColumns));

        foreach (DataRow dr in dataRowCol)
        {
            dataSotedTable.ImportRow(dr);
        }
        //------------- 정렬 처리 끝 -----------------------

        originDataTable.Dispose();
        dataTempTable.Dispose();

        return dataSotedTable;
    }

    //----------- 그룹화된 DataTable
    public static DataTable GetGroupByDataTable(  DataTable originDataTable
                                                , string[] groupByColumns)
    { 
        return GetGroupByDataTable(   originDataTable
                                    , ""
                                    , ""
                                    , groupByColumns
                                    , ""
                                    , ""
                                    , "");
    }

    public static DataTable GetGroupByDataTable(  DataTable originDataTable
                                                , string aggregateOriginField
                                                , string[] groupByColumns
                                                , string aggregateNewField )
    { 
        return GetGroupByDataTable(   originDataTable
                                    , aggregateOriginField
                                    , string.Empty
                                    , groupByColumns
                                    , aggregateNewField
                                    , string.Empty
                                    , string.Empty );
    }

    //----------- 그룹화된 DataTable
    public static DataTable GetGroupByDataTable(  DataTable originDataTable
                                                , string aggregateOriginField
                                                , string[] groupByColumns
                                                , string aggregateNewField
                                                , string primaryKey)
    { 
        return GetGroupByDataTable(   originDataTable
                                    , aggregateOriginField
                                    , ""
                                    , groupByColumns
                                    , aggregateNewField
                                    , ""
                                    , primaryKey);
    }

    //----------- 그룹화된 DataTable
    public static DataTable GetGroupByDataTable(  DataTable originDataTable
                                                , string aggregateOriginField1
                                                , string aggregateOriginField2
                                                , string[] groupByColumns
                                                , string aggregateNewField1
                                                , string aggregateNewField2
                                                , string primaryKey) 
    {
        // 집계컬럼이 없을 경우
        if (aggregateOriginField1 == "" || aggregateOriginField1 == null)  
        {
            aggregateOriginField1 = "T" + DateTime.Now.ToString("yyyyMMddHHmmddfff");
            originDataTable.Columns.Add(aggregateOriginField1, typeof(int));

            for (int i = 0; i < originDataTable.Rows.Count; i++) 
            {
                originDataTable.Rows[i][aggregateOriginField1] = 0;
            }

            originDataTable.AcceptChanges();
        }

        // 새이름 집계컬럼이 없을 경우
        if (aggregateNewField1 == "" || aggregateNewField1 == null) 
        {
            aggregateNewField1 = aggregateOriginField1;
        }

        // PrimaryKey 가 없을 경우
        if (primaryKey == "" || primaryKey == null) 
        {
            primaryKey = "IDX";

            if(!originDataTable.Columns.Contains(primaryKey))
                originDataTable.Columns.Add(primaryKey, typeof(int));

            for (int i = 0; i < originDataTable.Rows.Count; i++) 
            {
                originDataTable.Rows[i][primaryKey] = (i + 1);
            }

            originDataTable.AcceptChanges();
        }

        // 집계 변수 선언;
        string aggregateSumField1 = string.Format("{0}_{1}", "SUM", aggregateNewField1);
        string aggregateCntField1 = string.Format("{0}_{1}", "CNT", aggregateNewField1);
        string aggregateAvgField1 = string.Format("{0}_{1}", "AVG", aggregateNewField1);

        string aggregateSumField2 = string.Format("{0}_{1}", "SUM", aggregateNewField2);
        string aggregateCntField2 = string.Format("{0}_{1}", "CNT", aggregateNewField2);
        string aggregateAvgField2 = string.Format("{0}_{1}", "AVG", aggregateNewField2);

        if (!originDataTable.Columns.Contains("IS_AGGEGATED"))
            originDataTable.Columns.Add("IS_AGGEGATED", typeof(int));

        // 집계 처리 여부 필드 추가
        foreach (DataRow dr in originDataTable.Rows) 
        {
            dr["IS_AGGEGATED"] = 0;
        }

        // 템프 DataTable 생성
        DataTable dataTempTable = originDataTable.Clone();

        List<string> removeColList = new List<string>();

        foreach (DataColumn dataColumn in dataTempTable.Columns) 
        {
            bool isContain = false;

            for (int i = 0; i < groupByColumns.Length; i++) 
            {
                if (groupByColumns[i] == dataColumn.ColumnName) 
                {
                    isContain = true;
                    break;
                }

                // 그룹화 컬럼이 아닌 경우 DataColumn 삭제리스트 추가
                if (i == groupByColumns.Length - 1) 
                {
                    if (isContain == false) 
                    {
                        removeColList.Add(dataColumn.ColumnName);
                    }
                }
            }
        }

        // 컬럼 삭제
        for(int i = 0; i < removeColList.Count; i++)
            dataTempTable.Columns.Remove(removeColList[i]);

        dataTempTable.AcceptChanges();

        dataTempTable.Columns.Add(aggregateSumField1, typeof(double));
        dataTempTable.Columns.Add(aggregateCntField1, typeof(double));
        dataTempTable.Columns.Add(aggregateAvgField1, typeof(double));

        dataTempTable.Columns.Add(aggregateSumField2, typeof(double));
        dataTempTable.Columns.Add(aggregateCntField2, typeof(double));
        dataTempTable.Columns.Add(aggregateAvgField2, typeof(double));

        dataTempTable.Columns.Add(primaryKey, typeof(string));

        DataRow dataTempRow     = null;
        DataRow[] dataRowCol    = null;
        
        foreach (DataRow dataRow in originDataTable.Rows) 
        {
            dataRowCol             = originDataTable.Select(GetFilterString(dataRow, groupByColumns) + " AND IS_AGGEGATED = 0");

            double aggreSumData1    = 0;
            double aggreCntData1    = 0;
            double aggreAvgData1    = 0;

            double aggreSumData2    = 0;
            double aggreCntData2    = 0;
            double aggreAvgData2    = 0;

            string idx_array       = "";

            if(dataRowCol.Length == 0)
                continue;

            for (int i = 1; i <= dataRowCol.Length; i++) 
            {
                //------- SUM 처리 시작 --------------
                    aggreSumData1 += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField1]);

                    if(!aggregateOriginField2.Equals(""))
                        aggreSumData2 += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField2]);
                //------- SUM 처리 끝 --------------

                //------- COUNT 처리 시작 --------------
                    if(aggreCntData1 == 0) 
                        aggreCntData1 = dataRowCol.Length;

                    if (!aggregateOriginField2.Equals(""))
                    { 
                        if(aggreCntData2 == 0) 
                            aggreCntData2 = dataRowCol.Length;
                    }

                //------- COUNT 처리 끝 --------------
                
                //------- AVG 처리 시작 --------------
                    aggreAvgData1 += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField1]);

                    if(!aggregateOriginField2.Equals(""))
                        aggreAvgData2 += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField2]);

                    if (i == dataRowCol.Length) 
                        aggreAvgData1 = aggreAvgData1 / DataTypeUtility.GetToDouble(i);

                    if (!aggregateOriginField2.Equals(""))
                    {
                        if (i == dataRowCol.Length)
                            aggreAvgData2 = aggreAvgData2 / DataTypeUtility.GetToDouble(i);
                    }

                //------- AVG 처리 끝 --------------

                //------- IDX 처리 시작 --------------

                    if(i == 1)
                        idx_array +=        dataRowCol[i - 1][primaryKey];
                    else 
                        idx_array += ";"  + dataRowCol[i - 1][primaryKey];
                //------- IDX 처리 끝 --------------
                
                // 집계처리된 Row
                dataRowCol[i - 1]["IS_AGGEGATED"] = 1;
            }

            dataTempRow = dataTempTable.NewRow();

            foreach (string groupByColumn in groupByColumns)
            {
                dataTempRow[groupByColumn] = dataRow[groupByColumn];
            }

            dataTempRow[aggregateSumField1]  = aggreSumData1;
            dataTempRow[aggregateCntField1]  = aggreCntData1;
            dataTempRow[aggregateAvgField1]  = Math.Round(aggreAvgData1, 4);

            if (!aggregateOriginField2.Equals(""))
            {
                dataTempRow[aggregateSumField2] = aggreSumData2;
                dataTempRow[aggregateCntField2] = aggreCntData2;
                dataTempRow[aggregateAvgField2] = Math.Round(aggreAvgData2, 4);
            }

            dataTempRow[primaryKey]          = idx_array;

            dataTempTable.Rows.Add(dataTempRow);
        }

        //------------- 정렬 처리 시작 -----------------------
        DataTable dataSotedTable    = dataTempTable.Clone();
        DataRow[] d               = null;

        dataRowCol = dataTempTable.Select("", GetSortString(groupByColumns));

        foreach (DataRow dr in dataRowCol)
        {
            dataSotedTable.ImportRow(dr);
        }
        //------------- 정렬 처리 끝 -----------------------

        originDataTable.Dispose();
        dataTempTable.Dispose();

        return dataSotedTable;
    }

    // NULL 칼럼까지 포함시키는 그룹화된 DataTable
    public static DataTable GetGroupByIncludeNullDataTable(  DataTable originDataTable
                                                , string aggregateOriginField
                                                , string[] groupByColumns
                                                , string aggregateNewField
                                                , string primaryKey
												, string[] nullColumns )
    { 
        return GetGroupByIncludeNullDataTable( originDataTable
                                    , aggregateOriginField
                                    , ""
                                    , groupByColumns
                                    , aggregateNewField
                                    , ""
                                    , primaryKey
									, nullColumns );
    }

    // NULL 칼럼까지 포함시키는 그룹화된 DataTable
    public static DataTable GetGroupByIncludeNullDataTable( DataTable originDataTable
                                                , string aggregateOriginField1
                                                , string aggregateOriginField2
                                                , string[] groupByColumns
                                                , string aggregateNewField1
                                                , string aggregateNewField2
                                                , string primaryKey
												, string[] nullColumns )
    {
        // 집계 변수 선언;
        string aggregateSumField1 = string.Format("{0}_{1}", "SUM", aggregateNewField1);
        string aggregateCntField1 = string.Format("{0}_{1}", "CNT", aggregateNewField1);
        string aggregateAvgField1 = string.Format("{0}_{1}", "AVG", aggregateNewField1);

        string aggregateSumField2 = string.Format("{0}_{1}", "SUM", aggregateNewField2);
        string aggregateCntField2 = string.Format("{0}_{1}", "CNT", aggregateNewField2);
        string aggregateAvgField2 = string.Format("{0}_{1}", "AVG", aggregateNewField2);

        originDataTable.Columns.Add("IS_AGGEGATED", typeof(int));

        // 집계 처리 여부 필드 추가
        foreach (DataRow dr in originDataTable.Rows) 
        {
            dr["IS_AGGEGATED"] = 0;
        }

        // 템프 DataTable 생성
        DataTable dataTempTable = originDataTable.Clone();

        List<string> removeColList = new List<string>();

        foreach (DataColumn dataColumn in dataTempTable.Columns) 
        {
            bool isContain = false;

            for (int i = 0; i < groupByColumns.Length; i++) 
            {
                if (groupByColumns[i] == dataColumn.ColumnName) 
                {
                    isContain = true;
                    break;
                }

                // 그룹화 컬럼이 아닌 경우 DataColumn 삭제리스트 추가
                if (i == groupByColumns.Length - 1) 
                {
                    if (isContain == false) 
                    {
                        removeColList.Add(dataColumn.ColumnName);
                    }
                }
            }
        }

        // 컬럼 삭제
        for(int i = 0; i < removeColList.Count; i++)
            dataTempTable.Columns.Remove(removeColList[i]);

        dataTempTable.AcceptChanges();

        dataTempTable.Columns.Add(aggregateSumField1, typeof(double));
        dataTempTable.Columns.Add(aggregateCntField1, typeof(double));
        dataTempTable.Columns.Add(aggregateAvgField1, typeof(double));

        dataTempTable.Columns.Add(aggregateSumField2, typeof(double));
        dataTempTable.Columns.Add(aggregateCntField2, typeof(double));
        dataTempTable.Columns.Add(aggregateAvgField2, typeof(double));

        dataTempTable.Columns.Add(primaryKey, typeof(string));

        DataRow dataTempRow     = null;
        DataRow[] dataRowCol    = null;
        
        foreach (DataRow dataRow in originDataTable.Rows) 
        {
            dataRowCol = originDataTable.Select( GetFilterStringIsNull( dataRow, groupByColumns, nullColumns ) + " AND IS_AGGEGATED = 0" );

            double aggreSumData1    = 0;
            double aggreCntData1    = 0;
            double aggreAvgData1    = 0;

            double aggreSumData2    = 0;
            double aggreCntData2    = 0;
            double aggreAvgData2    = 0;

            string idx_array       = "";

            if(dataRowCol.Length == 0)
                continue;

            for (int i = 1; i <= dataRowCol.Length; i++) 
            {
                //------- SUM 처리 시작 --------------
				if ( dataRowCol[i - 1][aggregateOriginField1] != DBNull.Value )
                    aggreSumData1 += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField1]);

                    if(!aggregateOriginField2.Equals(""))
                        aggreSumData2 += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField2]);
                //------- SUM 처리 끝 --------------

                //------- COUNT 처리 시작 --------------
                    if(aggreCntData1 == 0) 
                        aggreCntData1 = dataRowCol.Length;

                    if (!aggregateOriginField2.Equals(""))
                    { 
                        if(aggreCntData2 == 0) 
                            aggreCntData2 = dataRowCol.Length;
                    }

                //------- COUNT 처리 끝 --------------
                
                //------- AVG 처리 시작 --------------
				if ( dataRowCol[i - 1][aggregateOriginField1] != DBNull.Value )
                    aggreAvgData1 += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField1]);

                    if(!aggregateOriginField2.Equals(""))
                        aggreAvgData2 += DataTypeUtility.GetToDouble(dataRowCol[i - 1][aggregateOriginField2]);

                    if (i == dataRowCol.Length) 
                        aggreAvgData1 = aggreAvgData1 / DataTypeUtility.GetToDouble(i);

                    if (!aggregateOriginField2.Equals(""))
                    {
                        if (i == dataRowCol.Length)
                            aggreAvgData2 = aggreAvgData2 / DataTypeUtility.GetToDouble(i);
                    }

                //------- AVG 처리 끝 --------------

                //------- IDX 처리 시작 --------------

                    if(i == 1)
                        idx_array +=        dataRowCol[i - 1][primaryKey];
                    else 
                        idx_array += ";"  + dataRowCol[i - 1][primaryKey];
                //------- IDX 처리 끝 --------------
                
                // 집계처리된 Row
                dataRowCol[i - 1]["IS_AGGEGATED"] = 1;
            }

            dataTempRow = dataTempTable.NewRow();

            foreach (string groupByColumn in groupByColumns)
            {
                dataTempRow[groupByColumn] = dataRow[groupByColumn];
            }

            dataTempRow[aggregateSumField1]  = aggreSumData1;
            dataTempRow[aggregateCntField1]  = aggreCntData1;
            dataTempRow[aggregateAvgField1]  = Math.Round(aggreAvgData1, 4);

            if (!aggregateOriginField2.Equals(""))
            {
                dataTempRow[aggregateSumField2] = aggreSumData2;
                dataTempRow[aggregateCntField2] = aggreCntData2;
                dataTempRow[aggregateAvgField2] = Math.Round(aggreAvgData2, 4);
            }

            dataTempRow[primaryKey]          = idx_array;

            dataTempTable.Rows.Add(dataTempRow);
        }

        //------------- 정렬 처리 시작 -----------------------
        DataTable dataSotedTable    = dataTempTable.Clone();
        DataRow[] d               = null;

        dataRowCol = dataTempTable.Select("", GetSortString(groupByColumns));

        foreach (DataRow dr in dataRowCol)
        {
            dataSotedTable.ImportRow(dr);
        }
        //------------- 정렬 처리 끝 -----------------------

        originDataTable.Dispose();
        dataTempTable.Dispose();

        return dataSotedTable;
    }

    //-------------------------------------------------------------
    //------- DataTable Merge
    //-------------------------------------------------------------
    public static DataTable MergeDataTableTypeA(  DataTable dataTable_L
                                                , DataTable dataTable_R
                                                , string aggregateField
                                                , string[] matchingColumns_L
                                                , string[] matchingColumns_R) 
    {
        DataTable dataTempMatchTable         = new DataTable();
        DataRow dataTempMatchRow             = null;

        dataTable_L.Columns.Add("IS_AGGEGATED", typeof(int));
        dataTable_R.Columns.Add("IS_AGGEGATED", typeof(int));

        dataTempMatchTable.Columns.Add(string.Format("SORT_ID"), typeof(string));
        dataTempMatchTable.Columns.Add(string.Format("T_MATCH_KEY_{0}", "L"), typeof(string));

        for (int i = 0; i < dataTable_L.Columns.Count; i++) 
        {
            dataTempMatchTable.Columns.Add( string.Format("{0}_{1}", dataTable_L.Columns[i].ColumnName, "L")
                                            , dataTable_L.Columns[i].DataType);
        }

        dataTempMatchTable.Columns.Add(string.Format("{0}_{1}_{2}", "SUM", aggregateField, "L"), typeof(double));

        dataTempMatchTable.Columns.Add(string.Format("T_MATCH_KEY_{0}", "R"), typeof(string));

        for (int i = 0; i < dataTable_R.Columns.Count; i++) 
        {
            dataTempMatchTable.Columns.Add(string.Format("{0}_{1}", dataTable_R.Columns[i].ColumnName, "R")
                                            , dataTable_R.Columns[i].DataType);
        }

        dataTempMatchTable.Columns.Add(string.Format("{0}_{1}_{2}", "SUM", aggregateField, "R"), typeof(double));
        dataTempMatchTable.Columns.Add(string.Format("{0}", "DIFF"), typeof(double));
        dataTempMatchTable.Columns.Add(string.Format("{0}", "STATUS"), typeof(string));

        foreach (DataRow dr in dataTable_L.Rows) 
        {
            dr["IS_AGGEGATED"] = 0;
        }

        foreach (DataRow dr in dataTable_R.Rows) 
        {
            dr["IS_AGGEGATED"] = 0;
        }

        DataRow[] dataRowCol_L      = null;
        DataRow[] dataRowCol_R      = null;
        double aggreSumData_L       = 0;
        double aggreSumData_R       = 0;
        
        int rowIndex = 1;

        foreach (DataRow dataRow_L in dataTable_L.Rows) 
        {
            aggreSumData_L  = 0;
            aggreSumData_R  = 0;

            dataRowCol_L    = dataTable_L.Select(GetFilterString(dataRow_L, matchingColumns_L, matchingColumns_L) + " AND IS_AGGEGATED = 0");
            dataRowCol_R    = dataTable_R.Select(GetFilterString(dataRow_L, matchingColumns_L, matchingColumns_R) + " AND IS_AGGEGATED = 0");

            //--------------- 일치하는 양간의 Table이 존재할 경우
            if (dataRowCol_L.Length > 0 && dataRowCol_R.Length > 0) 
            {
                for (int i = 1; i <= dataRowCol_L.Length; i++) 
                {
                    //------- SUM 처리 시작 --------------
                    aggreSumData_L += DataTypeUtility.GetToDouble(dataRowCol_L[i - 1][aggregateField]);
                    //------- SUM 처리 끝 --------------

                    // 집계처리된 Row
                    dataRowCol_L[i - 1]["IS_AGGEGATED"] = 1;
                }

                for (int i = 1; i <= dataRowCol_R.Length; i++) 
                {
                    //------- SUM 처리 시작 --------------
                    aggreSumData_R += DataTypeUtility.GetToDouble(dataRowCol_R[i - 1][aggregateField]);
                    //------- SUM 처리 끝 --------------

                    // 집계처리된 Row
                    dataRowCol_R[i - 1]["IS_AGGEGATED"] = 1;
                }

                int maxRow          = (dataRowCol_L.Length >= dataRowCol_R.Length) ? dataRowCol_L.Length : dataRowCol_R.Length;
                double difference   = aggreSumData_L - aggreSumData_R;

                //string match_key    = Guid.NewGuid().ToString();
                string match_key    = "";

                for (int i = 0; i < maxRow; i++) 
                {
                    dataTempMatchRow = dataTempMatchTable.NewRow();

                    if (dataRowCol_L.Length >= i + 1) 
                    {
                        foreach (DataColumn dataColumn in dataTable_L.Columns) 
                        {
                            dataTempMatchRow[string.Format("{0}_{1}", dataColumn.ColumnName, "L")]    = dataRowCol_L[i][dataColumn.ColumnName];
                        }

                        dataTempMatchRow["SORT_ID"]                                                   = rowIndex;
                        dataTempMatchRow[string.Format("T_MATCH_KEY_{0}", "L")]                       = rowIndex + "_" + i.ToString() + "_L";
                        dataTempMatchRow[string.Format("{0}_{1}_{2}", "SUM", aggregateField, "L")]    = aggreSumData_L;
                    }

                    if (dataRowCol_R.Length >= i + 1)
                    {
                        foreach (DataColumn dataColumn in dataTable_R.Columns)
                        {
                            dataTempMatchRow[string.Format("{0}_{1}", dataColumn.ColumnName, "R")]    = dataRowCol_R[i][dataColumn.ColumnName];
                        }

                        dataTempMatchRow["SORT_ID"]                                                   = rowIndex;
                        dataTempMatchRow[string.Format("T_MATCH_KEY_{0}", "R")]                       = rowIndex + "_" + i.ToString() + "_R";
                        dataTempMatchRow[string.Format("{0}_{1}_{2}", "SUM", aggregateField, "R")]    = aggreSumData_R;
                    }
                    
                    dataTempMatchRow["DIFF"] = difference;

                    if(difference == 0)
                        dataTempMatchRow["STATUS"] = "0";
                    else
                        dataTempMatchRow["STATUS"] = "1";

                    dataTempMatchTable.Rows.Add(dataTempMatchRow);
                }
            }
            //--------------- 자기 Table 만 존재할 경우
            else if (dataRowCol_L.Length > 0 && dataRowCol_R.Length == 0) 
            {
                for (int i = 1; i <= dataRowCol_L.Length; i++) 
                {
                    //------- SUM 처리 시작 --------------
                    aggreSumData_L += DataTypeUtility.GetToDouble(dataRowCol_L[i - 1][aggregateField]);
                    //------- SUM 처리 끝 --------------

                    // 집계처리된 Row
                    dataRowCol_L[i - 1]["IS_AGGEGATED"] = 1;
                }

                double difference   = aggreSumData_L - 0;

                for (int i = 0; i < dataRowCol_L.Length; i++) 
                {
                    dataTempMatchRow = dataTempMatchTable.NewRow();

                    if (dataRowCol_L.Length >= i + 1) 
                    {
                        foreach (DataColumn dataColumn in dataTable_L.Columns) 
                        {
                            dataTempMatchRow[string.Format("{0}_{1}", dataColumn.ColumnName, "L")] = dataRowCol_L[i][dataColumn.ColumnName];
                        }

                        dataTempMatchRow[string.Format("T_MATCH_KEY_{0}", "L")]                    = rowIndex + "_" + i.ToString() + "_L";
                        dataTempMatchRow[string.Format("{0}_{1}_{2}", "SUM", aggregateField, "L")] = aggreSumData_L;
                    }

                    dataTempMatchRow["DIFF"] = difference;

                    dataTempMatchRow["STATUS"] = "2";

                    dataTempMatchTable.Rows.Add(dataTempMatchRow);
                }
            }
            //--------------- 상대 Table 만 존재할 경우
            else if (dataRowCol_L.Length == 0 && dataRowCol_R.Length > 0)
            {
                for (int i = 1; i <= dataRowCol_R.Length; i++) 
                {
                    //------- SUM 처리 시작 --------------
                    aggreSumData_R += DataTypeUtility.GetToDouble(dataRowCol_R[i - 1][aggregateField]);
                    //------- SUM 처리 끝 --------------

                    // 집계처리된 Row
                    dataRowCol_R[i - 1]["IS_AGGEGATED"] = 1;
                }

                double difference   = 0 - aggreSumData_R;

                for (int i = 0; i < dataRowCol_R.Length; i++) 
                {
                    dataTempMatchRow = dataTempMatchTable.NewRow();

                    if (dataRowCol_R.Length >= i + 1)
                    {
                        foreach (DataColumn dataColumn in dataTable_R.Columns)
                        {
                            dataTempMatchRow[string.Format("{0}_{1}", dataColumn.ColumnName, "R")] = dataRowCol_R[i][dataColumn.ColumnName];
                        }

                        dataTempMatchRow[string.Format("T_MATCH_KEY_{0}", "R")]                    = rowIndex + "_" + i.ToString() + "_R";
                        dataTempMatchRow[string.Format("{0}_{1}_{2}", "SUM", aggregateField, "R")] = aggreSumData_R;
                    }

                    dataTempMatchRow["DIFF"] = difference;

                    dataTempMatchRow["STATUS"] = "2";
                    
                    dataTempMatchTable.Rows.Add(dataTempMatchRow);
                }
            }
            else 
            {
                continue;
            }

            rowIndex++;
        }

        // 만약 처리하지 않은 Row 가 존재할 경우
        foreach (DataRow dataRow_R in dataTable_R.Rows) 
        {
            aggreSumData_L  = 0;
            aggreSumData_R  = 0;

            dataRowCol_L    = dataTable_L.Select(GetFilterString(dataRow_R, matchingColumns_R, matchingColumns_L) + " AND IS_AGGEGATED = 0");
            dataRowCol_R    = dataTable_R.Select(GetFilterString(dataRow_R, matchingColumns_R, matchingColumns_R) + " AND IS_AGGEGATED = 0");

            if (dataRowCol_L.Length == 0 && dataRowCol_R.Length == 0)
                continue;

            rowIndex++;

            for (int i = 1; i <= dataRowCol_L.Length; i++) 
            {
                //------- SUM 처리 시작 --------------
                aggreSumData_L += DataTypeUtility.GetToDouble(dataRowCol_L[i - 1][aggregateField]);
                //------- SUM 처리 끝 --------------

                // 집계처리된 Row
                dataRowCol_L[i - 1]["IS_AGGEGATED"] = 1;
            }

            double difference   = aggreSumData_L - 0;

            for (int i = 0; i < dataRowCol_L.Length; i++) 
            {
                dataTempMatchRow = dataTempMatchTable.NewRow();

                if (dataRowCol_L.Length >= i + 1) 
                {
                    foreach (DataColumn dataColumn in dataTable_L.Columns) 
                    {
                        dataTempMatchRow[string.Format("{0}_{1}", dataColumn.ColumnName, "L")] = dataRowCol_L[i][dataColumn.ColumnName];
                    }

                    dataTempMatchRow[string.Format("T_MATCH_KEY_{0}", "L")]                    = rowIndex + "_" + i.ToString() + "_L";
                    dataTempMatchRow[string.Format("{0}_{1}_{2}", "SUM", aggregateField, "L")] = aggreSumData_L;
                }

                dataTempMatchRow["DIFF"] = difference;

                dataTempMatchRow["STATUS"] = "2";

                dataTempMatchTable.Rows.Add(dataTempMatchRow);
            }

            for (int i = 1; i <= dataRowCol_R.Length; i++) 
            {
                //------- SUM 처리 시작 --------------
                aggreSumData_R += DataTypeUtility.GetToDouble(dataRowCol_R[i - 1][aggregateField]);
                //------- SUM 처리 끝 --------------

                // 집계처리된 Row
                dataRowCol_R[i - 1]["IS_AGGEGATED"] = 1;
            }

            difference   = 0 - aggreSumData_R;

            for (int i = 0; i < dataRowCol_R.Length; i++) 
            {
                dataTempMatchRow = dataTempMatchTable.NewRow();

                if (dataRowCol_R.Length >= i + 1)
                {
                    foreach (DataColumn dataColumn in dataTable_R.Columns)
                    {
                        dataTempMatchRow[string.Format("{0}_{1}", dataColumn.ColumnName, "R")] = dataRowCol_R[i][dataColumn.ColumnName];
                    }

                    dataTempMatchRow[string.Format("T_MATCH_KEY_{0}", "R")]                    = rowIndex + "_" + i.ToString() + "_R";
                    dataTempMatchRow[string.Format("{0}_{1}_{2}", "SUM", aggregateField, "R")] = aggreSumData_R;
                }

                dataTempMatchRow["DIFF"] = difference;

                dataTempMatchRow["STATUS"] = "2";
                
                dataTempMatchTable.Rows.Add(dataTempMatchRow);
            }
        }

        // 내부 컬럼 삭제
        dataTempMatchTable.Columns.Remove("IS_AGGEGATED_L");
        dataTempMatchTable.Columns.Remove("IS_AGGEGATED_R");

        //------------- 정렬 처리 시작 -----------------------
        DataTable dataSotedTable    = dataTempMatchTable.Clone();
        DataRow[] dataRowCol        = null;

        dataRowCol = dataTempMatchTable.Select("", "STATUS," + "SORT_ID DESC," + GetSortString(matchingColumns_L, "_L", "DESC"));

        foreach (DataRow dr in dataRowCol)
        {
            dataSotedTable.ImportRow(dr);
        }
        //------------- 정렬 처리 끝 -----------------------

        return dataSotedTable;
    }

  

    // Filter 문자열 반환
    public static string GetFilterString(DataRow dataRow, string[] filterColumns_L, string[] filterColumns_R) 
    {
        string filter = "1 = 1";

        for (int i = 0; i < filterColumns_L.Length; i++) 
        {
            filter += string.Format(" AND {0} = '{1}'", filterColumns_R[i], dataRow[filterColumns_L[i]]);
        }

        return filter;
    }

    // Filter 문자열 반환
    public static string GetFilterString(DataRow dataRow, string[] filterColumns) 
    {
        string filter = "1 = 1";

        for (int i = 0; i < filterColumns.Length; i++) 
        {
            filter += string.Format(" AND {0} = '{1}'", filterColumns[i], dataRow[filterColumns[i]]);
        }

        return filter;
    }

	// Where MAIN_UNIT_ID = 'MAIN' And SUB_UNIT_ID = 'SUB' And ACT_ID = 'ACT'
	//	And SelectColumnName = 'SelectColumnValue'
	public static string GetFilterString( DataRow dataRow, string[] selectGeneralColumns, string selectColumnName, string selectColumnValue )
	{
		string strReturn = string.Empty;

		int intCount = selectGeneralColumns.Length;
		if ( intCount != 0 )
		{
			for ( int i = 0; i < intCount; i++ )
			{
				if ( i != 0 )
					strReturn += "AND ";

				strReturn += string.Format( "{0} = '{1}' ", selectGeneralColumns[i], dataRow[selectGeneralColumns[i]] );
			}

			if ( selectColumnName.Length == 0 || selectColumnValue.Length == 0 )
				return strReturn;
			else
				strReturn += string.Format( "AND {0} = '{1}'", selectColumnName, selectColumnValue );
		}
		else
			strReturn += string.Format( "{0} = '{1}'", selectColumnName, selectColumnValue );

		return strReturn;
	}

	/// <summary>
	/// 07.12.4 류승태
	/// DataRow에 NULL이 있을때 Is Null로...
	/// </summary>
    public static string GetFilterStringIsNull( DataRow dataRow, string[] selectGeneralColumns, string[] nullColumns )
    {
		string strReturn = string.Empty;

		int intCount = selectGeneralColumns.Length;
		if ( intCount != 0 )
		{
			for ( int i = 0; i < intCount; i++ )
			{
				if ( i != 0 )
					strReturn += "AND ";

				// NULL 여부 확인
				if ( dataRow[selectGeneralColumns[i]].ToString().Length != 0 )
				{
					strReturn += string.Format( "{0} = '{1}' ", selectGeneralColumns[i], dataRow[selectGeneralColumns[i]] );
				}
				else
				{
					if ( ChkValue( nullColumns, selectGeneralColumns[i] ) == true )
						strReturn += string.Format( "{0} IS NULL ", selectGeneralColumns[i] );
					else
						strReturn += string.Format( "{0} = '' ", selectGeneralColumns[i] );
				}
			}
		}

		return strReturn;
    }

	private static bool ChkValue( string[] strarr, string strValue )
	{
		bool bolReturn = false;

		for ( int i = 0; i < strarr.Length; i++ )
		{
			if ( strarr[i].Equals( strValue ) == true )
				return true;
		}

		return bolReturn;
	}

    // Sort 문자열 반환 오버로드 1
    public static string GetSortString(string[] sortColumns, string lastfix, string asc_desc)
    {
        string sorter   = "";

        for (int i = 0; i < sortColumns.Length; i++) 
        {
            if (i == 0)
            {
                sorter += sortColumns[i] + lastfix + " " + asc_desc;
            }
            else 
            {
                sorter += "," + sortColumns[i] + lastfix + " " + asc_desc;
            }
        }
        return sorter;
    }

    // Sort 문자열 반환 오버로드 2
    public static string GetSortString(string[] sortColumns)
    { 
        return GetSortString(sortColumns, "", "");
    }

    // Array Merging...
    public static string[] MergeArrays(string[] array1, string[] array2) 
    {
        if(array2 == null)
            return array1;

        string[] array = new string[array1.Length + array2.Length];

        int i = 0;

        for (; i < array1.Length; i++) 
        {
            array[i] = array1[i];
        }

        i++;

        for (; i < array.Length; i++) 
        {
            array[i] = array2[i];
        }

        return array;
    }

    public static string Right(string s, int n) 
    {
        if (n == s.Length) 
        {
            return s;
        }
        else if (n < 1) 
        {
            return "";
        }
        else 
        {
            return s.Substring(s.Length - n, n);
        }
    }

    #endregion

	public static object GetToDbNull( object obj )
	{
		if ( obj == null ||
			obj == DBNull.Value ||
			obj.ToString().Length == 0 )
			return DBNull.Value;

		return obj;
	}

    public static string GetSplitString(  DataTable dataTable
                                            , string columnName
                                            , string spliter)
        {
            return GetSplitString(dataTable
                                , columnName
                                , spliter
                                , true);
        }

    /// <summary>
	/// 데이터 테이블에서 해당 컬럼의 Spliter를 붙인 문자열을 반환한다.
	/// </summary>
	/// <param name="dataTable"></param>
	/// <param name="columnName"></param>
	/// <param name="spliter"></param>
	/// <returns></returns>
	public static string GetSplitString(  DataTable dataTable
                                        , string columnName
                                        , string spliter
                                        , bool isString)
    {
        string temp     = "";
        bool isFirst    = true;

	    foreach(DataRow dataRow in dataTable.Rows) 
        {
            if(isFirst) 
            {
                if(isString)
                    temp += string.Format("'{0}'", dataRow[columnName]);
                else
                    temp += string.Format("{0}", dataRow[columnName]);

                isFirst = false;
            }
            else 
            {
                if(isString)
                    temp += string.Format("{1}'{0}'", dataRow[columnName], spliter);
                else
                    temp += string.Format("{1}{0}", dataRow[columnName], spliter);
            }
        }

        return temp;
    }

    /// <summary>
    /// String 배열을 DataTable로 변환
    /// </summary>
    /// <param name="data_array_string"></param>
    /// <param name="splitChar"></param>
    /// <param name="columnName"></param>
    /// <param name="blankDataTable"></param>
    /// <returns></returns>
    public static DataTable ConvertArrayStringToDataTable(string data_array_string
                                                        , char splitChar
													    , string columnName
													    , DataTable blankDataTable)
	{
		DataRow dataRow = null;

        if(data_array_string == null
            || splitChar == null
            || columnName == null
            || columnName == "")
            return null;

        string[] str_array = data_array_string.Split(splitChar);

        if(blankDataTable == null)
        {
            blankDataTable = new DataTable("DT_ARRAY_CHAR_DATA");
            blankDataTable.Columns.Add(columnName, typeof(string));
        }
        
		foreach(string str in str_array) 
        {
            dataRow = blankDataTable.NewRow();
            dataRow[columnName] = str;
            blankDataTable.Rows.Add(dataRow);
        }

		return blankDataTable;
	}

    
    public static string Decrypt(string stringToDecrypt, string sEncryptionKey)
	{
		byte[] key = { };
		byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
		byte[] inputByteArray = new byte[stringToDecrypt.Length];
		try
		{
			key                             = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
			DESCryptoServiceProvider des    = new DESCryptoServiceProvider();
			inputByteArray                  = Convert.FromBase64String(stringToDecrypt);
			MemoryStream ms                 = new MemoryStream();
			CryptoStream cs                 = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			Encoding encoding               = Encoding.UTF8;
			return encoding.GetString(ms.ToArray());
		}
		catch
		{
			return (string.Empty);
        }
	}

	public static string Encrypt(string stringToEncrypt, string sEncryptionKey)
	{
		byte[] key = { };
		byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
		byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length)

		try
		{
			if (stringToEncrypt != "")
			{
				key                             = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
				DESCryptoServiceProvider des    = new DESCryptoServiceProvider();                
				inputByteArray                  = Encoding.UTF8.GetBytes(stringToEncrypt);
				MemoryStream ms                 = new MemoryStream();
				CryptoStream cs                 = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
				cs.Write(inputByteArray, 0, inputByteArray.Length);
				cs.FlushFinalBlock();
				return Convert.ToBase64String(ms.ToArray());
			}
			else
			{
				return (string.Empty);
			}
		}
		catch
		{
			return (string.Empty);
		}
	}

    //public static string GetInt32ToAlphabet(int index) 
    //{
    //    List<string> list = new List<string>();
    //    Dictionary<int, string> dic = new Dictionary<int,string>();

    //    dic.Add(0, "");
    //        dic.Add(1, "A");
    //        dic.Add(2, "B");
    //        dic.Add(3, "C");
    //        dic.Add(4, "D");
    //        dic.Add(5, "E");
    //        dic.Add(6, "F");
    //        dic.Add(7, "G");
    //        dic.Add(8, "H");
    //        dic.Add(9, "I");
    //        dic.Add(10, "J");
    //        dic.Add(11, "K");
    //        dic.Add(12, "L");
    //        dic.Add(13, "M");
    //        dic.Add(14, "N");
    //        dic.Add(15, "O");
    //        dic.Add(16, "P");
    //        dic.Add(17, "Q");
    //        dic.Add(18, "R");
    //        dic.Add(19, "S");
    //        dic.Add(20, "T");
    //        dic.Add(21, "U");
    //        dic.Add(22, "V");
    //        dic.Add(23, "W");
    //        dic.Add(24, "X");
    //        dic.Add(25, "Y");
    //        dic.Add(26, "Z");

    //        dic.Add(27, "AA");
    //        dic.Add(28, "AB");
    //        dic.Add(29, "AC");
    //        dic.Add(30, "AD");
    //        dic.Add(31, "AE");
    //        dic.Add(32, "AF");
    //        dic.Add(33, "AG");
    //        dic.Add(34, "AH");
    //        dic.Add(35, "AI");
    //        dic.Add(36, "AJ");
    //        dic.Add(37, "AK");
    //        dic.Add(38, "AL");
    //        dic.Add(39, "AM");
    //        dic.Add(40, "AN");
    //        dic.Add(41, "AO");
    //        dic.Add(42, "AP");
    //        dic.Add(43, "AQ");
    //        dic.Add(44, "AR");
    //        dic.Add(45, "AS");
    //        dic.Add(46, "AT");
    //        dic.Add(47, "AU");
    //        dic.Add(48, "AV");
    //        dic.Add(49, "AW");
    //        dic.Add(50, "AX");
    //        dic.Add(51, "AY");
    //        dic.Add(52, "AZ");

    //        dic.Add(53, "BA");
    //        dic.Add(54, "BB");
    //        dic.Add(55, "BC");
    //        dic.Add(56, "BD");
    //        dic.Add(57, "BE");
    //        dic.Add(58, "BF");
    //        dic.Add(59, "BG");
    //        dic.Add(60, "BH");
    //        dic.Add(61, "BI");
    //        dic.Add(62, "BJ");
    //        dic.Add(63, "BK");
    //        dic.Add(64, "BL");
    //        dic.Add(65, "BM");
    //        dic.Add(66, "BN");
    //        dic.Add(67, "BO");
    //        dic.Add(68, "BP");
    //        dic.Add(69, "BQ");
    //        dic.Add(70, "BR");
    //        dic.Add(71, "BS");
    //        dic.Add(72, "BT");
    //        dic.Add(73, "BU");
    //        dic.Add(74, "BV");
    //        dic.Add(75, "BW");
    //        dic.Add(76, "BX");
    //        dic.Add(77, "BY");
    //        dic.Add(78, "BZ");

    //        dic.Add(79, "CA");
    //        dic.Add(80, "CB");
    //        dic.Add(81, "CC");
    //        dic.Add(82, "CD");
    //        dic.Add(83, "CE");
    //        dic.Add(84, "CF");
    //        dic.Add(85, "CG");
    //        dic.Add(86, "CH");
    //        dic.Add(87, "CI");
    //        dic.Add(88, "CJ");
    //        dic.Add(89, "CK");
    //        dic.Add(90, "CL");
    //        dic.Add(91, "CM");
    //        dic.Add(92, "CN");
    //        dic.Add(93, "CO");
    //        dic.Add(94, "CP");
    //        dic.Add(95, "CQ");
    //        dic.Add(96, "CR");
    //        dic.Add(97, "CS");
    //        dic.Add(98, "CT");
    //        dic.Add(99, "CU");
    //        dic.Add(100, "CV");
    //        dic.Add(101, "CW");
    //        dic.Add(102, "CX");
    //        dic.Add(103, "CY");
    //        dic.Add(104, "CZ");


    //    if(dic.ContainsKey(index))
    //        return dic[index];

    //    return "";
    //}
}
