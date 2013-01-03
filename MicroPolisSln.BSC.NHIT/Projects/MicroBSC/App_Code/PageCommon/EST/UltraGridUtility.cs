using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using MicroBSC.BSC.Biz;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;


using Infragistics.WebUI.UltraWebGrid;

public class UltraGridUtility
{
	/// <summary>
	/// 울트라 그리드 안에 있는 체크박스 선택시 값 선택
	/// 리턴 : 111;222;333;
	/// </summary>
	public static string GetCheckBoxValues(UltraWebGrid ultraWebGrid
										, string strTemplateColumnCheckBoxName
										, string strCheckBoxName
										, string strIdxColumnName )
	{
		string	 strIdxs = string.Empty;

		foreach ( UltraGridRow ugRow in ultraWebGrid.Rows )
		{
			TemplatedColumn col_cBox = (TemplatedColumn)ugRow.Band.Columns.FromKey( strTemplateColumnCheckBoxName );
			CheckBox cBox = (CheckBox)((CellItem)col_cBox.CellItems[ugRow.BandIndex]).FindControl( strCheckBoxName );

			if ( cBox.Checked == true )
			{
				strIdxs += ugRow.Cells.FromKey( strIdxColumnName ).Value + ";";
			}
		}

		return strIdxs;
	}

	public static DataSet GetDataSetByCheckedBox( UltraWebGrid ultraWebGrid
		                                        , string[] strColumnNames
		                                        , string strTemplateColumnCheckBoxName
		                                        , string strCheckBoxName )
	{
		DataSet dsReturn    = new DataSet();
		DataTable dtReturn  = new DataTable();
		dsReturn.Tables.Add( dtReturn );

		for ( int i = 0; i < strColumnNames.Length; i++ )
		{
			DataColumn dcColumn = new DataColumn( strColumnNames[i], typeof( string ) );
			dtReturn.Columns.Add( dcColumn );
		}

		foreach ( UltraGridRow ugRow in ultraWebGrid.Rows )
		{
			TemplatedColumn col_cBox    = (TemplatedColumn)ugRow.Band.Columns.FromKey( strTemplateColumnCheckBoxName );
			CheckBox cBox               = (CheckBox)((CellItem)col_cBox.CellItems[ugRow.BandIndex]).FindControl( strCheckBoxName );

			DataRow drNew;
			if ( cBox.Checked == true )
			{
				drNew = dtReturn.NewRow();
				
				foreach( DataColumn dcItem in dtReturn.Columns )
				{
					drNew[dcItem.ColumnName] = ugRow.Cells.FromKey( dcItem.ColumnName ).Value;
				}
				dtReturn.Rows.Add( drNew );
			}
		}

		return dsReturn;
	}

    /// <summary>
    /// 체크박스가 있는 그리드에서 체크되어 있는 값을 반영된 DataTable에 넣어주어서
    /// 반환한다.
    /// </summary>
    /// <param name="ultraWebGrid"></param>
    /// <param name="checkBoxID"></param>
    /// <param name="cellKey_checkBox"></param>
    /// <param name="cellKey_value"></param>
    /// <param name="blankDataTable"></param>
    /// <returns></returns>
    public static DataTable GetDataTableByCheckValue( UltraWebGrid ultraWebGrid
		                                            , string checkBoxID
                                                    , string cellKey_checkBox
                                                    , string[] cellKey_values
                                                    , DataTable blankDataTable)
	{
        return GetDataTableByCheckValue(ultraWebGrid
                                        , checkBoxID
                                        , cellKey_checkBox
                                        , cellKey_values
                                        , blankDataTable
                                        , false);
	}

    public static DataTable GetDataTableByCheckValue(UltraWebGrid ultraWebGrid
                                                    , string checkBoxID
                                                    , string cellKey_checkBox
                                                    , string[] cellKey_values
                                                    , DataTable blankDataTable
                                                    , bool isDisabledCheckBoxYN)
    {
        DataRow dataRow = null;

        bool expandMode = false;
        if (ultraWebGrid.Rows.Count > 0)
            if (ultraWebGrid.Rows[0].Rows.Count > 0)
                expandMode = true;

        if (expandMode)
        {
            for (int i = 0; i < ultraWebGrid.Rows.Count; i++)
            {
                UltraGridRow pRow = ultraWebGrid.Rows[i];
                foreach (UltraGridRow ugRow in pRow.Rows)
                {
                    TemplatedColumn col_cBox = (TemplatedColumn)ugRow.Band.Columns.FromKey(cellKey_checkBox);
                    CheckBox cBox = (CheckBox)((CellItem)col_cBox.CellItems[ugRow.BandIndex]).FindControl(checkBoxID);

                    if (isDisabledCheckBoxYN)
                    {
                        if (cBox.Checked == true && cBox.Enabled == false)
                        {
                            dataRow = blankDataTable.NewRow();

                            foreach (string cellKey_value in cellKey_values)
                            {
                                if (ugRow.Cells.Exists(cellKey_value))
                                    dataRow[cellKey_value] = ugRow.Cells.FromKey(cellKey_value).Value;
                                else
                                    dataRow[cellKey_value] = DBNull.Value;
                            }

                            blankDataTable.Rows.Add(dataRow);
                        }
                    }
                    else
                    {
                        if (cBox.Checked)
                        {
                            dataRow = blankDataTable.NewRow();

                            foreach (string cellKey_value in cellKey_values)
                            {
                                if (ugRow.Cells.Exists(cellKey_value))
                                    dataRow[cellKey_value] = ugRow.Cells.FromKey(cellKey_value).Value;
                                else
                                    dataRow[cellKey_value] = DBNull.Value;
                            }

                            blankDataTable.Rows.Add(dataRow);
                        }
                    }
                }
            }
            return blankDataTable;
        }

        foreach (UltraGridRow ugRow in ultraWebGrid.Rows)
        {
            TemplatedColumn col_cBox    = (TemplatedColumn)ugRow.Band.Columns.FromKey(cellKey_checkBox);
            CheckBox cBox               = (CheckBox)((CellItem)col_cBox.CellItems[ugRow.BandIndex]).FindControl(checkBoxID);

            if (isDisabledCheckBoxYN)
            {
                if (cBox.Checked == true && cBox.Enabled == false)
                {
                    dataRow = blankDataTable.NewRow();

                    foreach (string cellKey_value in cellKey_values)
                    {
                        if (ugRow.Cells.Exists(cellKey_value))
                            dataRow[cellKey_value] = ugRow.Cells.FromKey(cellKey_value).Value;
                        else
                            dataRow[cellKey_value] = DBNull.Value;
                    }

                    blankDataTable.Rows.Add(dataRow);
                }
            }
            else
            {
                if (cBox.Checked)
                {
                    dataRow = blankDataTable.NewRow();

                    foreach (string cellKey_value in cellKey_values)
                    {
                        if (ugRow.Cells.Exists(cellKey_value))
                        {
                            if (ugRow.Cells.FromKey(cellKey_value).Value == null)
                                dataRow[cellKey_value] = DBNull.Value;
                            else
                                dataRow[cellKey_value] = ugRow.Cells.FromKey(cellKey_value).Value;
                        }
                        else
                            dataRow[cellKey_value] = DBNull.Value;
                    }

                    blankDataTable.Rows.Add(dataRow);
                }
            }
        }

        return blankDataTable;
    }

    /// <summary>
    /// 그리드의모든값이 반영된 DataTable에 넣어주어서 반환한다.
    /// </summary>
    /// <param name="ultraWebGrid"></param>
    /// <param name="cellKey_values"></param>
    /// <param name="blankDataTable"></param>
    /// <returns></returns>
    public static DataTable GetDataTableByAllValue(UltraWebGrid ultraWebGrid
                                                  , string[] cellKey_values
                                                  , DataTable blankDataTable)
    {
        DataRow dataRow = null;

        foreach (UltraGridRow ugRow in ultraWebGrid.Rows)
        {
            dataRow = blankDataTable.NewRow();

            foreach (string cellKey_value in cellKey_values)
            {
                dataRow[cellKey_value] = ugRow.Cells.FromKey(cellKey_value).Value;
            }

            blankDataTable.Rows.Add(dataRow);
        }

        return blankDataTable;
    }
    /// <summary>
    /// 특정컬럼값의 존재유무를 리턴합니다.
    /// </summary>
    /// <param name="ultraWebGrid"></param>
    /// <param name="row"></param>
    /// <param name="cellKey"></param>
    /// <param name="tgtcellkey"></param>
    /// <returns></returns>
    public static bool IsColumnValueContains(UltraWebGrid ultraWebGrid
                                            , UltraGridRow row
                                            , string cellKey
                                            , string tgtcellkey)
    {
         UltraGridRow tmprow;
         bool rtn = false;

        for (int i = 0; i < ultraWebGrid.Rows.Count; i++)
        {
               tmprow = ultraWebGrid.Rows[i];

               if (tmprow.Cells.FromKey(tgtcellkey).Value.Equals(row.Cells.FromKey(cellKey).Value))
               {
                   rtn = true;
                   break;
               }
               
        }

        return rtn;
    }

    /// <summary>
    /// 체크된Row를 삭제합니다.
    /// </summary>
    /// <param name="ultraWebGrid"></param>
    /// <param name="checkBoxID"></param>
    /// <param name="cellKey_checkBox"></param>
    public static void SetRemoveRow(UltraWebGrid ultraWebGrid
                                , string checkBoxID
                                , string cellKey_checkBox)
    {
        int cntRow = (ultraWebGrid.Rows.Count - 1);
        UltraGridRow row;

        for (int i = cntRow; i >= 0; i--)
        {
            row = ultraWebGrid.Rows[i];
            TemplatedColumn col_cBox = (TemplatedColumn)row.Band.Columns.FromKey(cellKey_checkBox);
            CheckBox cBox = (CheckBox)((CellItem)col_cBox.CellItems[row.BandIndex]).FindControl(checkBoxID);

            if (cBox.Checked)
            {
                ultraWebGrid.Rows.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// 텍스트에 해당하는 HorizontalAlign 를 반환한다.
    /// </summary>
    /// <param name="h_align"></param>
    /// <returns></returns>
    public static HorizontalAlign GetHorizontalAlign(object h_align) 
    {
        if (h_align == DBNull.Value) 
        {
            return HorizontalAlign.NotSet;
        }
        else if (h_align.ToString().ToUpper().Equals("LEFT")) 
        {
            return HorizontalAlign.Left;
        }
        else if (h_align.ToString().ToUpper().Equals("CENTER")) 
        {
            return HorizontalAlign.Center;
        }
        else if (h_align.ToString().ToUpper().Equals("RIGHT")) 
        {
            return HorizontalAlign.Right;
        }

        return HorizontalAlign.NotSet;
    }

    /// <summary>
    /// 직급,직군 보이기 여부
    /// </summary>
    /// <param name="dtPosNotUse"></param>
    /// <param name="ultraGridCol"></param>
    /// <param name="col_key"></param>
    public static void VisiblePosColumn(  DataTable dtPosNotUse
                                        , UltraGridColumn ultraGridCol
                                        , string col_key) 
    {
        foreach(DataRow dataRowPosNotUse in dtPosNotUse.Rows) 
        {
            if(col_key.IndexOf("POS_" + dataRowPosNotUse["POS_ID"].ToString()) >= 0) 
            {
                ultraGridCol.Hidden = true;
            }
        }
    }

    /// <summary>
    /// 직급,직군 보이기 여부
    /// </summary>
    /// <param name="columnCollection"></param>
    public static void VisiblePosColumn(ColumnsCollection columnCollection) 
    {
        Biz_PositionInfos positionInfo  = new Biz_PositionInfos();
        DataTable dtPosNotUse           = positionInfo.GetPositionInfoByUseYN("N").Tables[0];

        foreach(DataRow dataRowPosNotUse in dtPosNotUse.Rows) 
        {
            string col_key_id     = string.Format("TGT_POS_{0}_ID", dataRowPosNotUse["POS_ID"]);
            string col_key_name   = string.Format("TGT_POS_{0}_NAME", dataRowPosNotUse["POS_ID"]);

            string col_key_id_1   = string.Format("POS_{0}_ID", dataRowPosNotUse["POS_ID"]);
            string col_key_name_1 = string.Format("POS_{0}_NAME", dataRowPosNotUse["POS_ID"]);

            if(columnCollection.Exists(col_key_id)) 
            {
                columnCollection.FromKey(col_key_id).Hidden = true;
            }

            if(columnCollection.Exists(col_key_name)) 
            {
                columnCollection.FromKey(col_key_name).Hidden = true;
            }

            if(columnCollection.Exists(col_key_id_1)) 
            {
                columnCollection.FromKey(col_key_id_1).Hidden = true;
            }

            if(columnCollection.Exists(col_key_name_1)) 
            {
                columnCollection.FromKey(col_key_name_1).Hidden = true;
            }
        }
    }

    /// <summary>
    /// 평가 페이지에서 EST_ID에 따라서 컬럼을 동적으로 생성한다.
    /// </summary>
    /// <param name="ultraWebGrid"></param>
    /// <param name="est_id"></param>
    /// <param name="default_index_count"></param>
    /// <param name="dataTable"></param>
    public static void CreateColumns( UltraWebGrid ultraWebGrid
                                    , int comp_id
                                    , string est_id
                                    , int default_index_count
                                    , out DataTable dataTable
                                    , string owner_type
                                    , string[] est_job_ids
                                    , string dept_column_no_use_yn) 
    {
        Biz_ColumnInfos columnInfo      = new Biz_ColumnInfos();
        Biz_EstInfos    estInfo         = new Biz_EstInfos(comp_id, est_id);
        dataTable                       = columnInfo.GetColumnInfo(comp_id, est_id).Tables[0];
        DataRow dataRow                 = null;
        UltraGridColumn ultraGridCol    = null;
        int i                           = 0;

        owner_type                      = estInfo.Owner_Type;

        Biz_JobColumnMaps jobColumnMap  = new Biz_JobColumnMaps();
        DataTable dtColumnMap           = null;

        Biz_PositionInfos positionInfo  = new Biz_PositionInfos();
        DataTable dtPosNotUse           = positionInfo.GetPositionInfoByUseYN("N").Tables[0];
        
        foreach(string est_job_id in est_job_ids) 
        {
            if(dtColumnMap == null)
                dtColumnMap           = jobColumnMap.GetJobColumnMap(  comp_id
                                                                     , est_id
                                                                     , est_job_id).Tables[0];
            else
                dtColumnMap.Merge(dtColumnMap);
        }

        for (int j = ultraWebGrid.Bands[0].Columns.Count; j > default_index_count; j--)
        {
            ultraWebGrid.Bands[0].Columns.RemoveAt(j - 1);
            ultraWebGrid.DisplayLayout.Bands[0].HeaderLayout.RemoveAt(j - 1);
        }

        for (; i < dataTable.Rows.Count; i++) 
        {
            dataRow         = dataTable.Rows[i];

            //--------------------- 일반 컬럼일 경우
            if(dataRow["COL_STYLE_ID"].ToString().Equals("NML")) 
            {
                ultraGridCol    = new UltraGridColumn();
                ultraWebGrid.Bands[0].Columns.Add(ultraGridCol);

                ultraGridCol.Header.Caption                     = dataRow["CAPTION"].ToString();
                ultraGridCol.Header.Column.Width                = (dataRow["WIDTH"] == DBNull.Value) ? 100 : DataTypeUtility.GetToInt32(dataRow["WIDTH"]);
                ultraGridCol.Header.Column.Key                  = dataRow["COL_KEY"].ToString();

                if(DataTypeUtility.GetYNToBoolean(dataRow["DEFAULT_VALUE_YN"].ToString()) == false) 
                    ultraGridCol.Header.Column.BaseColumnName       = dataRow["COL_KEY"].ToString();

                ultraGridCol.Header.RowLayoutColumnInfo.OriginX = i+ default_index_count + - 1 ;
                ultraGridCol.CellStyle.HorizontalAlign          = UltraGridUtility.GetHorizontalAlign(dataRow["HALIGN"]);
                ultraGridCol.DataType                           = dataRow["DATA_TYPE"].ToString();
                ultraGridCol.Hidden                             = !DataTypeUtility.GetYNToBoolean(dataRow["VISIBLE_YN"].ToString());

                if(DataTypeUtility.GetYNToBoolean(dataRow["BACK_COLOR_YN"].ToString())) 
                {
                    if(     dataRow["BACK_COLOR"] != DBNull.Value 
                        ||  dataRow["BACK_COLOR"].ToString().Trim().Equals(""))
                        ultraGridCol.CellStyle.BackColor            = Color.FromName(dataRow["BACK_COLOR"].ToString());
                }

                if(DataTypeUtility.GetYNToBoolean(dataRow["FORMAT_YN"].ToString())) 
                {
                    if(     dataRow["FORMAT"] != DBNull.Value 
                        ||  dataRow["FORMAT"].ToString().Trim().Equals(""))
                        ultraGridCol.Format                     = dataRow["FORMAT"].ToString();
                }
                
                if(DataTypeUtility.GetYNToBoolean(dataRow["FORMULA_YN"].ToString())) 
                {
                    if(     dataRow["FORMULA_YN"] != DBNull.Value 
                        ||  dataRow["FORMULA_YN"].ToString().Trim().Equals(""))
                        ultraGridCol.Format                     = dataRow["FORMULA"].ToString();
                }

                if(DataTypeUtility.GetYNToBoolean(dataRow["DEFAULT_VALUE_YN"].ToString())) 
                {
                    if(     dataRow["DEFAULT_VALUE_YN"] != DBNull.Value 
                        ||  dataRow["DEFAULT_VALUE_YN"].ToString().Trim().Equals(""))
                        ultraGridCol.NullText                   = WebUtility.GetHtmlEncodeChar(dataRow["DEFAULT_VALUE"].ToString());
                }

                // 평가 주체가 부서인경우 (사원컬럼이면 보이기를 숨김으로 한다)
                if(owner_type.Equals("D") && dept_column_no_use_yn.Equals("N"))
                {
                    if(dataRow["COL_EMP_VISIBLE_YN"].ToString().Equals("Y"))
                    {
                        ultraGridCol.Hidden = true;
                    }
                }
                else if(owner_type.Equals("P") && dept_column_no_use_yn.Equals("Y"))
                {
                    if(dataRow["COL_EMP_VISIBLE_YN"].ToString().Equals("Y"))
                    {
                        ultraGridCol.Hidden = true;
                    }
                }

                VisiblePosColumn(dtPosNotUse, ultraGridCol, dataRow["COL_KEY"].ToString());
            }
            //--------------------- 존재하는 컬럼일 경우
            else if(dataRow["COL_STYLE_ID"].ToString().Equals("BLK")) 
            {
                try
                {
                    ultraWebGrid.Bands[0].Columns.FromKey(dataRow["COL_KEY"].ToString()).Hidden = !DataTypeUtility.GetYNToBoolean(dataRow["VISIBLE_YN"].ToString());
                }
                catch
                {
                }
            }
            //--------------------- 업무관련 컬럼
            else if(dataRow["COL_STYLE_ID"].ToString().Equals("BIZ")) 
            {
                ultraGridCol    = new UltraGridColumn();
                ultraWebGrid.Bands[0].Columns.Add(ultraGridCol);

                ultraGridCol.Header.Caption                     = dataRow["CAPTION"].ToString();
                ultraGridCol.Header.Column.Width                = (dataRow["WIDTH"] == DBNull.Value) ? 100 : DataTypeUtility.GetToInt32(dataRow["WIDTH"]);
                ultraGridCol.Header.Column.Key                  = dataRow["COL_KEY"].ToString();

                if(DataTypeUtility.GetYNToBoolean(dataRow["DEFAULT_VALUE_YN"].ToString()) == false) 
                    ultraGridCol.Header.Column.BaseColumnName       = dataRow["COL_KEY"].ToString();

                ultraGridCol.Header.RowLayoutColumnInfo.OriginX = i+ default_index_count + - 1 ;
                ultraGridCol.CellStyle.HorizontalAlign          = UltraGridUtility.GetHorizontalAlign(dataRow["HALIGN"]);
                ultraGridCol.DataType                           = dataRow["DATA_TYPE"].ToString();
                // 미리 숨김을 함
                ultraGridCol.Hidden                             = true; 

                if(DataTypeUtility.GetYNToBoolean(dataRow["BACK_COLOR_YN"].ToString())) 
                {
                    if(     dataRow["BACK_COLOR"] != DBNull.Value 
                        ||  dataRow["BACK_COLOR"].ToString().Trim().Equals(""))
                        ultraGridCol.CellStyle.BackColor            = Color.FromName(dataRow["BACK_COLOR"].ToString());
                }

                if(DataTypeUtility.GetYNToBoolean(dataRow["FORMAT_YN"].ToString())) 
                {
                    if(     dataRow["FORMAT"] != DBNull.Value 
                        ||  dataRow["FORMAT"].ToString().Trim().Equals(""))
                        ultraGridCol.Format                     = dataRow["FORMAT"].ToString();
                }
                
                if(DataTypeUtility.GetYNToBoolean(dataRow["FORMULA_YN"].ToString())) 
                {
                    if(     dataRow["FORMULA_YN"] != DBNull.Value 
                        ||  dataRow["FORMULA_YN"].ToString().Trim().Equals(""))
                        ultraGridCol.Format                     = dataRow["FORMULA_YN"].ToString();
                }

                if(DataTypeUtility.GetYNToBoolean(dataRow["DEFAULT_VALUE_YN"].ToString())) 
                {
                    if(     dataRow["DEFAULT_VALUE_YN"] != DBNull.Value 
                        ||  dataRow["DEFAULT_VALUE_YN"].ToString().Trim().Equals(""))
                        ultraGridCol.NullText                   = WebUtility.GetHtmlEncodeChar(dataRow["DEFAULT_VALUE"].ToString());
                }

                // COL_KEY 와 EST_JOB_ID 간에 매핑에 따라 보여주기 여부 처리
                foreach(DataRow drColMap in dtColumnMap.Rows) 
                {
                    if(ultraGridCol.Hidden == true) 
                    {
                        if(drColMap["COL_KEY"].ToString() == dataRow["COL_KEY"].ToString()) 
                        {
                            ultraGridCol.Hidden = false;
                            break;
                        }
                    }
                }

                if(ultraGridCol.Hidden == false)
                    ultraGridCol.Hidden = !DataTypeUtility.GetYNToBoolean(dataRow["VISIBLE_YN"].ToString());

                // 평가 주체가 부서인경우 (사원컬럼이면 보이기를 숨김으로 한다)
                if(owner_type.Equals("D") && dept_column_no_use_yn.Equals("N"))
                {
                    if(dataRow["COL_EMP_VISIBLE_YN"].ToString().Equals("Y"))
                    {
                        ultraGridCol.Hidden = true;
                    }
                }
                else if(owner_type.Equals("P") && dept_column_no_use_yn.Equals("Y"))
                {
                    if(dataRow["COL_EMP_VISIBLE_YN"].ToString().Equals("Y"))
                    {
                        ultraGridCol.Hidden = true;
                    }
                }

                VisiblePosColumn(dtPosNotUse, ultraGridCol, dataRow["COL_KEY"].ToString());
            }
        }
    }
}
