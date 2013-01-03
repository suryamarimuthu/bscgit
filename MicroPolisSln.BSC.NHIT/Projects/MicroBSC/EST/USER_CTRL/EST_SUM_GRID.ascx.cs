using ASP;
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
using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Estimation.Biz;

using Infragistics.WebUI.UltraWebGrid;

// 제    목 : 집계정보를 보여주기 위한 Custom Grid 
// 내    용 : 성과평가가 끝난 뒤 경영자에게 보여주거나 결과보고를 하기 위한 화면
public partial class EST_USER_CTRL_EST_SUM_GRID : EstUserControlBase
{
    #region ----------------------- 필드 ------------------------------------

    private int _comp_id;
    private string _est_id;
    private int _estterm_ref_id;
    private int _estterm_sub_id;
    private int _estterm_step_id;
    private string _year_yn;
    private string _merge_yn;
    private string _owner_type;
    private OwnerType _eOwnerType;

    private int DEFAULT_INDEX_COUNT         = 1;

    private DataTable DT_EST_DATA           = null;
    private DataTable DT_GRADE              = null;

    #endregion

    #region ----------------------- 속성 ------------------------------------

    public int Comp_ID 
    {
        set 
        {
            _comp_id = value;
        }
    }

    public string Est_ID
    {
        set 
        {
            _est_id = value;
        }
    }

    public int EstTerm_Ref_ID 
    {
        set 
        {
            _estterm_ref_id = value;
        }
    }

    public int EstTerm_Sub_ID 
    {
        set 
        {
            _estterm_sub_id = value;
        }
    }

    public int EstTerm_Step_ID 
    {
        set 
        {
            _estterm_step_id = value;
        }
    }

    public string Year_YN
    {
        set 
        {
            _year_yn = value;
        }
    }

    public string Merge_YN
    {
        set 
        {
            _merge_yn = value;
        }
    }

    public string Owner_Type
    {
        set 
        {
            _owner_type = value;
        }
    }

    public string Title_Name
    {
        set 
        {
            lblTitle.Text = value;
        }
    }

    public string Title_Img_Url
    {
        set 
        {
            imgTitle.ImageUrl = value;
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack) 
        {
            DataBindingGrid(_comp_id
                            , _est_id
                            , _estterm_ref_id
                            , _estterm_sub_id
                            , _estterm_step_id
                            , _year_yn
                            , _merge_yn
                            , _owner_type);

            txtProblem.Text = 
@"전년도 평가에 비해서 금년 업적 평가가 전반적으로 상승하였습니다.
사업 부서간 격차에 좀더 신경 써야 할 것입니다.";

            txtSolution.Text = 
@"특정 부서의 평가 점수가 하향 곡선이며, 이에 대한 조치 사항을 논의 중입니다.";
        }
    }

    private void DataBindingGrid(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string year_yn
                                , string merge_yn
                                , string owner_type) 
    {
        _eOwnerType = BizUtility.GetOwnerType(owner_type);

        Biz_Datas data  = new Biz_Datas();
        DT_EST_DATA     = data.GetData(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , 0
                                        , 0
                                        , 0
                                        , 0
                                        , year_yn
                                        , merge_yn
                                        , _eOwnerType).Tables[0];

        Biz_Grades grade = new Biz_Grades();
        DT_GRADE         = grade.GetEstGrades(comp_id).Tables[0];

        DataTable dataDept          = BizUtility.GetDeptTree("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");

        if(_eOwnerType == OwnerType.Dept) 
        {
            dataDept.Columns.Add("B_POINT", typeof(double));
            dataDept.Columns.Add("A_POINT", typeof(double));
            dataDept.Columns.Add("B_GRADE", typeof(string));
            dataDept.Columns.Add("A_GRADE", typeof(string));
            dataDept.Columns.Add("IS_EST", typeof(string));

            foreach(DataRow dataRow in dataDept.Rows) 
            {
                dataRow["B_POINT"] = "0";
                dataRow["A_POINT"] = "0";
                dataRow["B_GRADE"] = "-";
                dataRow["A_GRADE"] = "-";
                dataRow["IS_EST"]  = "N";
            }

            foreach(DataRow drDept in dataDept.Rows) 
            {
                DataRow[] drEstData = DT_EST_DATA.Select(string.Format("TGT_DEPT_ID = {0}", drDept["DEPT_REF_ID"]));

                foreach(DataRow dataEstData in drEstData) 
                {
                    drDept["A_POINT"]       = DataTypeUtility.GetToDouble(dataEstData["POINT"]);
                    drDept["A_GRADE"]       = DataTypeUtility.GetValue(dataEstData["GRADE_ID"]);;
                    drDept["IS_EST"]        = "Y";
                }
            }
        }
        else if(_eOwnerType == OwnerType.Emp_User) 
        {
            foreach(DataRow drGrade in DT_GRADE.Rows) 
            {
                dataDept.Columns.Add("B_" + drGrade["GRADE_ID"].ToString(), typeof(string));
                dataDept.Columns.Add("A_" + drGrade["GRADE_ID"].ToString(), typeof(string));
            }

            dataDept.Columns.Add("IS_EST", typeof(string));

            foreach(DataRow dataRow in dataDept.Rows) 
            {
                foreach(DataRow drGrade in DT_GRADE.Rows) 
                {
                    dataRow["B_" + drGrade["GRADE_ID"].ToString()]  = "0";
                    dataRow["A_" + drGrade["GRADE_ID"].ToString()]  = "0";
                    dataRow["IS_EST"]                               = "N";
                }
            }

            foreach(DataRow drDept in dataDept.Rows) 
            {
                DataRow[] drEstData = DT_EST_DATA.Select(string.Format("TGT_DEPT_ID = {0}", drDept["DEPT_REF_ID"]));

                foreach(DataRow dataEstData in drEstData) 
                {
                    if(dataEstData["GRADE_ID"] != DBNull.Value)
                        drDept["A_" + DataTypeUtility.GetValue(dataEstData["GRADE_ID"])] = DataTypeUtility.GetToInt32(drDept["A_" + DataTypeUtility.GetValue(dataEstData["GRADE_ID"])]) + 1;

                    drDept["IS_EST"]        = "Y";
                }
            }

            DataRow dr         = dataDept.NewRow();
            dr["DEPT_REF_ID"]  = -9999;
            dr["DEPT_NAME"]    = "<div align='center'><b>합&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;계</b></center>";
            dr["IS_EST"]       = "T";
            dataDept.Rows.Add(dr);

            foreach(DataRow drGrade in DT_GRADE.Rows) 
            {
                foreach(DataRow drEstSum in dataDept.Rows) 
                {
                    if(DataTypeUtility.GetToInt32(drEstSum["DEPT_REF_ID"]) > 0) 
                    {
                        dataDept.Rows[dataDept.Rows.Count - 1]["B_" + DataTypeUtility.GetValue(drGrade["GRADE_ID"])] 
                            = DataTypeUtility.GetToInt32(dataDept.Rows[dataDept.Rows.Count - 1]["B_" + DataTypeUtility.GetValue(drGrade["GRADE_ID"])]) 
                                + DataTypeUtility.GetToInt32(drEstSum["B_" + DataTypeUtility.GetValue(drGrade["GRADE_ID"])]);

                        dataDept.Rows[dataDept.Rows.Count - 1]["A_" + DataTypeUtility.GetValue(drGrade["GRADE_ID"])] 
                            = DataTypeUtility.GetToInt32(dataDept.Rows[dataDept.Rows.Count - 1]["A_" + DataTypeUtility.GetValue(drGrade["GRADE_ID"])]) 
                                + DataTypeUtility.GetToInt32(drEstSum["A_" + DataTypeUtility.GetValue(drGrade["GRADE_ID"])]);
                    }
                }
            }
        }

        UltraWebGrid1.DataSource    = dataDept;
        UltraWebGrid1.DataBind();

        //GridView1.DataSource = dataDept;
        //GridView1.DataBind();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView) e.Data;

        if(drw["IS_EST"].ToString().Equals("N")) 
        {
            e.Row.Style.BackColor = Color.FromName("#FFF0F0");
        }

        if(drw["IS_EST"].ToString().Equals("T")) 
        {
            e.Row.Style.BackColor = Color.FromName("#EBEBEB");
        }

        if(_eOwnerType == OwnerType.Dept) 
        {
            if(DataTypeUtility.GetToDouble(drw["B_POINT"]) > 0) 
            {
                e.Row.Cells.FromKey("B_POINT").Style.Font.Bold  = true;
                e.Row.Cells.FromKey("B_POINT").Style.Cursor     = Infragistics.WebUI.Shared.Cursors.Hand;
            }

            if(DataTypeUtility.GetToDouble(drw["A_POINT"]) > 0) 
            {
                e.Row.Cells.FromKey("A_POINT").Style.Font.Bold  = true;
                e.Row.Cells.FromKey("A_POINT").Style.Cursor     = Infragistics.WebUI.Shared.Cursors.Hand;
            }

            if(!DataTypeUtility.GetValue(drw["B_GRADE"]).Equals("-")) 
            {
                e.Row.Cells.FromKey("B_GRADE").Style.Font.Bold  = true;
                e.Row.Cells.FromKey("B_GRADE").Style.Cursor     = Infragistics.WebUI.Shared.Cursors.Hand;
            }

            if(!DataTypeUtility.GetValue(drw["A_GRADE"]).Equals("-")) 
            {
                e.Row.Cells.FromKey("A_GRADE").Style.Font.Bold  = true;
                e.Row.Cells.FromKey("A_GRADE").Style.Cursor     = Infragistics.WebUI.Shared.Cursors.Hand;
            }
        }
        else if(_eOwnerType == OwnerType.Emp_User) 
        {
            foreach(DataRow drGrade in DT_GRADE.Rows) 
            {
                if(DataTypeUtility.GetToInt32(drw["B_" + drGrade["GRADE_ID"].ToString()]) > 0) 
                {
                    e.Row.Cells.FromKey("B_" + drGrade["GRADE_ID"].ToString()).Style.Font.Bold  = true;
                    e.Row.Cells.FromKey("B_" + drGrade["GRADE_ID"].ToString()).Style.Cursor     = Infragistics.WebUI.Shared.Cursors.Hand;
                }

                if(DataTypeUtility.GetToInt32(drw["A_" + drGrade["GRADE_ID"].ToString()]) > 0)
                {
                    e.Row.Cells.FromKey("A_" + drGrade["GRADE_ID"].ToString()).Style.Font.Bold  = true;
                    e.Row.Cells.FromKey("A_" + drGrade["GRADE_ID"].ToString()).Style.Cursor     = Infragistics.WebUI.Shared.Cursors.Hand;
                }
            }
        }
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        if(_eOwnerType == OwnerType.Dept) 
        {
            ColumnHeader ch                                 = null;
            UltraGridColumn ultraGridCol                    = null;

            ch                                              = new ColumnHeader(true);
            ch.Caption                                      = "평가점수";
            ch.RowLayoutColumnInfo.OriginX                  = 2;
            ch.RowLayoutColumnInfo.OriginY                  = 0;
            ch.RowLayoutColumnInfo.SpanX                    = 2;
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch                                              = new ColumnHeader(true);
            ch.Caption                                      = "평가등급";
            ch.RowLayoutColumnInfo.OriginX                  = 4;
            ch.RowLayoutColumnInfo.OriginY                  = 0;
            ch.RowLayoutColumnInfo.SpanX                    = 2;
            ch.Style.HorizontalAlign                        = HorizontalAlign.Center;
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ultraGridCol                                    = new UltraGridColumn();
            e.Layout.Bands[0].Columns.Add(ultraGridCol);
            ultraGridCol.Header.Caption                     = "전기";
            ultraGridCol.Header.Column.Width                = 150;
            ultraGridCol.Header.Column.Key                  = "B_POINT";
            ultraGridCol.Header.Column.BaseColumnName       = "B_POINT";
            ultraGridCol.Header.RowLayoutColumnInfo.OriginX = 2;
            ultraGridCol.Header.RowLayoutColumnInfo.OriginY = 1;
            ultraGridCol.CellStyle.HorizontalAlign          = HorizontalAlign.Center;
            ultraGridCol.Format                             = "#,##0.00";

            ultraGridCol                                    = new UltraGridColumn();
            e.Layout.Bands[0].Columns.Add(ultraGridCol);
            ultraGridCol.Header.Caption                     = "당기";
            ultraGridCol.Header.Column.Width                = 150;
            ultraGridCol.Header.Column.Key                  = "A_POINT";
            ultraGridCol.Header.Column.BaseColumnName       = "A_POINT";
            ultraGridCol.Header.RowLayoutColumnInfo.OriginX = 3;
            ultraGridCol.Header.RowLayoutColumnInfo.OriginY = 1;
            ultraGridCol.CellStyle.HorizontalAlign          = HorizontalAlign.Center;
            ultraGridCol.Format                             = "#,##0.00";

            ultraGridCol                                    = new UltraGridColumn();
            e.Layout.Bands[0].Columns.Add(ultraGridCol);
            ultraGridCol.Header.Caption                     = "전기";
            ultraGridCol.Header.Column.Width                = 150;
            ultraGridCol.Header.Column.Key                  = "B_GRADE";
            ultraGridCol.Header.Column.BaseColumnName       = "B_GRADE";
            ultraGridCol.Header.RowLayoutColumnInfo.OriginX = 4;
            ultraGridCol.Header.RowLayoutColumnInfo.OriginY = 1;
            ultraGridCol.CellStyle.HorizontalAlign          = HorizontalAlign.Center;

            ultraGridCol                                    = new UltraGridColumn();
            e.Layout.Bands[0].Columns.Add(ultraGridCol);
            ultraGridCol.Header.Caption                     = "당기";
            ultraGridCol.Header.Column.Width                = 150;
            ultraGridCol.Header.Column.Key                  = "A_GRADE";
            ultraGridCol.Header.Column.BaseColumnName       = "A_GRADE";
            ultraGridCol.Header.RowLayoutColumnInfo.OriginX = 5;
            ultraGridCol.Header.RowLayoutColumnInfo.OriginY = 1;
            ultraGridCol.CellStyle.HorizontalAlign          = HorizontalAlign.Center;
        }
        else if(_eOwnerType == OwnerType.Emp_User) 
        {
            ColumnHeader ch                                 = null;
            UltraGridColumn ultraGridCol                    = null;

            foreach(DataRow drGrade in DT_GRADE.Rows) 
            {
                ch                                              = new ColumnHeader(true);
                ch.Caption                                      = drGrade["GRADE_NAME"].ToString();
                ch.RowLayoutColumnInfo.OriginX                  = ++DEFAULT_INDEX_COUNT;
                ch.RowLayoutColumnInfo.OriginY                  = 0;
                ch.RowLayoutColumnInfo.SpanX                    = 2;
                ch.Style.HorizontalAlign = HorizontalAlign.Center;
                e.Layout.Bands[0].HeaderLayout.Add(ch);

                ultraGridCol                                    = new UltraGridColumn();
                e.Layout.Bands[0].Columns.Add(ultraGridCol);
                ultraGridCol.Header.Caption                     = "전기";
                ultraGridCol.Header.Column.Width                = 60;
                ultraGridCol.Header.Column.Key                  = "B_" + drGrade["GRADE_ID"].ToString();
                ultraGridCol.Header.Column.BaseColumnName       = "B_" + drGrade["GRADE_ID"].ToString();
                ultraGridCol.Header.RowLayoutColumnInfo.OriginX = DEFAULT_INDEX_COUNT;
                ultraGridCol.Header.RowLayoutColumnInfo.OriginY = 1;
                ultraGridCol.CellStyle.HorizontalAlign          = HorizontalAlign.Center;

                ultraGridCol                                    = new UltraGridColumn();
                e.Layout.Bands[0].Columns.Add(ultraGridCol);
                ultraGridCol.Header.Caption                     = "당기";
                ultraGridCol.Header.Column.Width                = 60;
                ultraGridCol.Header.Column.Key                  = "A_" + drGrade["GRADE_ID"].ToString();
                ultraGridCol.Header.Column.BaseColumnName       = "A_" + drGrade["GRADE_ID"].ToString();
                ultraGridCol.Header.RowLayoutColumnInfo.OriginX = ++DEFAULT_INDEX_COUNT;
                ultraGridCol.Header.RowLayoutColumnInfo.OriginY = 1;
                ultraGridCol.CellStyle.HorizontalAlign          = HorizontalAlign.Center;
            }
        }
    }
}
