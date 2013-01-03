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

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebTab;

using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Biz.BSC;
using MicroBSC.Data;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Biz.BSC.Biz;

using MicroBSC.Integration.PRJ.Biz;
using MicroBSC.Integration.PMS.Biz;

public partial class PMS_PMS0300M1 : AppPageBase
{
    Biz_Pms_Col_Info bizPmsColInfo;
    Biz_Prj_Data bizPrjData;


    #region HiddenField
    protected int PRJ_REF_ID
    {
        get
        {
            return DataTypeUtility.GetToInt32(hdf_PRJ_REF_ID.Value);
        }
        set
        {
            hdf_PRJ_REF_ID.Value = DataTypeUtility.GetString(value);
        }
    }


    protected string PRJ_CODE
    {
        get
        {
            return DataTypeUtility.GetString(hdf_PRJ_CODE.Value);
        }
        set
        {
            hdf_PRJ_CODE.Value = value;
        }
    }


    protected int COMP_ID
    {
        get
        {
            return DataTypeUtility.GetToInt32(hdf_COMP_ID.Value);
        }
        set
        {
            hdf_COMP_ID.Value = DataTypeUtility.GetString(value);
        }
    }



    protected string EST_ID
    {
        get
        {
            return DataTypeUtility.GetString(hdf_EST_ID.Value);
        }
        set
        {
            hdf_EST_ID.Value = value;
        }
    }



    protected int ESTTERM_REF_ID
    {
        get
        {
            return DataTypeUtility.GetToInt32(hdf_ESTTERM_REF_ID.Value);
        }
        set
        {
            hdf_ESTTERM_REF_ID.Value = DataTypeUtility.GetString(value);
        }
    }



    protected int ESTTERM_SUB_ID
    {
        get
        {
            return DataTypeUtility.GetToInt32(hdf_ESTTERM_SUB_ID.Value);
        }
        set
        {
            hdf_ESTTERM_SUB_ID.Value = DataTypeUtility.GetString(value);
        }
    }



    protected int ESTTERM_STEP_ID
    {
        get
        {
            return DataTypeUtility.GetToInt32(hdf_ESTTERM_STEP_ID.Value);
        }
        set
        {
            hdf_ESTTERM_STEP_ID.Value = DataTypeUtility.GetString(value);
        }
    }


    protected int EST_DEPT_ID
    {
        get
        {
            return DataTypeUtility.GetToInt32(hdf_EST_DEPT_ID.Value);
        }
        set
        {
            hdf_EST_DEPT_ID.Value = DataTypeUtility.GetString(value);
        }
    }


    protected int EST_EMP_ID
    {
        get
        {
            return DataTypeUtility.GetToInt32(hdf_EST_EMP_ID.Value);
        }
        set
        {
            hdf_EST_EMP_ID.Value = DataTypeUtility.GetString(value);
        }
    }



    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        bizPmsColInfo = new Biz_Pms_Col_Info();
        bizPrjData = new Biz_Prj_Data();


        PRJ_REF_ID = DataTypeUtility.GetToInt32(WebUtility.GetRequest("PRJ_REF_ID"));
        PRJ_CODE = WebUtility.GetRequest("PRJ_CODE");
        COMP_ID = DataTypeUtility.GetToInt32(WebUtility.GetRequest("COMP_ID"));
        EST_ID = WebUtility.GetRequest("EST_ID");
        ESTTERM_REF_ID = DataTypeUtility.GetToInt32(WebUtility.GetRequest("ESTTERM_REF_ID"));
        ESTTERM_SUB_ID = DataTypeUtility.GetToInt32(WebUtility.GetRequest("ESTTERM_SUB_ID"));
        ESTTERM_STEP_ID = DataTypeUtility.GetToInt32(WebUtility.GetRequest("ESTTERM_STEP_ID"));
        EST_DEPT_ID = DataTypeUtility.GetToInt32(WebUtility.GetRequest("EST_DEPT_ID"));
        EST_EMP_ID = DataTypeUtility.GetToInt32(WebUtility.GetRequest("EST_EMP_ID"));


        ltrScript.Text = "";


        if (!IsPostBack && PRJ_REF_ID > 0 && PRJ_CODE.Length > 0)
        {
            Weight_Col_Bind();
            Difficulty_Col_Bind();
            Common_Soosik_Bind();
            Prj_Est_Point_Bind();
            SetBottons();
        }

        Prj_Data_Bind();
    }


    protected void SetBottons()
    {
        /*
        if (EST_EMP_ID != gUserInfo.Emp_Ref_ID)
        {
            this.tdCalcBtnMargin.Visible = false;
            this.tdCalcBtn.Visible = false;
        }*/

        for (int i = 0; i < EMP_ROLES.Count; i++)
        {
            //성과 평가 관리자만
            string role_ref_id = DataTypeUtility.GetString(EMP_ROLES[i]);

            if (role_ref_id.Equals("9"))
            {
                this.tdCalcBtnMargin.Visible = true;
                this.tdCalcBtn.Visible = true;

                this.ibnCalcPrjEstPoint.Enabled = true;
                this.ibnCalcPrjEstPoint.Visible = true;
                this.ibnSaveEst.Enabled = true;
                this.ibnSaveEst.Visible = true;
                this.ibnConfirmEst.Enabled = true;
                this.ibnConfirmEst.Visible = true;
                this.ibnCancelEst.Enabled = true;
                this.ibnCancelEst.Visible = true;
            }
        }
    }

    protected void Weight_Col_Bind()
    {
        DataTable DT = bizPmsColInfo.Get_Weight_Col_List(PRJ_CODE);

        uwgrid_Weight.Clear();
        uwgrid_Weight.DataSource = DT;
        uwgrid_Weight.DataBind();
    }


    protected void Difficulty_Col_Bind()
    {
        DataTable DT = bizPmsColInfo.Get_Difficulty_Col_List(PRJ_CODE);

        uwgrid_Difficulty.Clear();
        uwgrid_Difficulty.DataSource = DT;
        uwgrid_Difficulty.DataBind();
    }


    protected void Common_Soosik_Bind()
    {
        string CommonSoosik = bizPmsColInfo.Get_Common_Soosik(PRJ_CODE);
        string CommonSoosik_Desc = bizPmsColInfo.Get_Common_Soosik_Desc(PRJ_CODE);

        this.lblCommonSoosik.Text = CommonSoosik;
        this.lblCommonSoosik_Desc.Text = CommonSoosik_Desc;
    }


    protected void Prj_Data_Bind()
    { 
        DataTable DT = bizPrjData.Get_Prj_Data_List(PRJ_REF_ID
                                                    , COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID);

        uwgrid_TGT_EMP_LIST.Clear();
        uwgrid_TGT_EMP_LIST.DataSource = DataTypeUtility.FilterSortDataTable(DT, "TGT_DEPT_ID > -1 AND TGT_EMP_ID > -1");
        uwgrid_TGT_EMP_LIST.DataBind();
    }


    protected void ibnSaveEst_Click(object sender, ImageClickEventArgs e)
    {
        bool Result;

        Result = Update_Prj_Weight_Value();
        if (Result)
            Result = Save_Prj_Est_Point();

        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("오류가 발생했습니다.");
        }
    }


    protected void Prj_Est_Point_Bind()
    {
        DataTable dt = bizPrjData.Get_Prj_Data_List(PRJ_REF_ID, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID);

        DataTable dtPrjInfo = DataTypeUtility.FilterSortDataTable(dt, "TGT_DEPT_ID=-1 AND TGT_EMP_ID=-1");

        object point = dtPrjInfo.Rows[0]["POINT"];

        string Result = Math.Round(DataTypeUtility.GetToDouble(point), 1).ToString();
        
        this.lblPrjEstPoint.Text = Result;
    }


    protected bool Save_Prj_Est_Point()
    {
        int tgt_dept_id = -1;
        int tgt_emp_id = -1;

        double point = DataTypeUtility.GetToDouble(lblPrjEstPoint.Text);


        return bizPrjData.Modify_Prj_Data_Point(PRJ_REF_ID, tgt_dept_id, tgt_emp_id, point, gUserInfo.Emp_Ref_ID);
    }


    protected bool Update_Prj_Weight_Value()
    {
        bool Result = true;

        DataTable dtCols = new DataTable();
        dtCols.Columns.Add("PRJ_COL_ID");
        dtCols.Columns.Add("PRJ_COL_NAME");
        dtCols.Columns.Add("PRJ_COL_VALUE");

        for (int i = 0; i < uwgrid_Weight.Rows.Count; i++)
        {
            string custom_yn = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_CUSTOM_YN").Value.ToString();
            if (custom_yn.Equals("Y"))
            {
                string prj_col_id = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_ID").Value.ToString();
                string prj_col_name = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_NAME").Value.ToString();
                string prj_col_value = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_VALUE").Value.ToString();

                dtCols.Rows.Add(new string[] { prj_col_id, prj_col_name, prj_col_value });
            }
        }

        if (dtCols.Rows.Count > 0)
            Result = bizPmsColInfo.Modify_Custom_Col_Value(dtCols, PRJ_CODE, gUserInfo.Emp_Ref_ID.ToString());

        return Result;
    }



    protected void ibnCancelEst_Click(object sender, ImageClickEventArgs e)
    {
         bool Result;

        Result = bizPrjData.Modify_Prj_Data_Est_Status(PRJ_REF_ID, 0, 0, "P", gUserInfo.Emp_Ref_ID);

        if (Result)
        {
            //this.ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.");
            this.ltrScript.Text = JSHelper.GetAlertOpenerReflashScript("정상적으로 처리되었습니다.", false);
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("오류가 발생했습니다.");
        }
       
        Prj_Data_Bind();
    }


    protected void ibnConfirmEst_Click(object sender, ImageClickEventArgs e)
    {
        if (Check_TgtEmp_Est_Status())
        {
            bool Result;

            Result = bizPrjData.Modify_Prj_Data_Est_Status(PRJ_REF_ID, 0, 0, "E", gUserInfo.Emp_Ref_ID);

            if (Result)
            {
                //this.ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.");
                this.ltrScript.Text = JSHelper.GetAlertOpenerReflashScript("정상적으로 처리되었습니다.", false);
            }
            else
            {
                this.ltrScript.Text = JSHelper.GetAlertScript("오류가 발생했습니다.");
            }
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("평가하지 않은 피평가자가 존재합니다.");
        }

        Prj_Data_Bind();
    }

    /// <summary>
    /// 프로젝트평가 확정 전 평가하지 않은 피평가자 존재 확인
    /// </summary>
    protected bool Check_TgtEmp_Est_Status()
    {
        bool Result = true;

        for (int i = 0; i < uwgrid_TGT_EMP_LIST.Rows.Count; i++)
        {
            object point = uwgrid_TGT_EMP_LIST.Rows[i].Cells.FromKey("POINT").Value;

            if(DataTypeUtility.GetString(point).Length==0)
                return false;
        }


        return Result;
    }


    protected bool Confirm_Prj_Est()
    {
        int TGT_DEPT_ID = -1;
        int TGT_EMP_ID = -1;

        string EST_STATUS = "E";

        return bizPrjData.Modify_Prj_Data_Est_Status(PRJ_REF_ID, TGT_DEPT_ID, TGT_EMP_ID, EST_STATUS, gUserInfo.Emp_Ref_ID);
    }



    protected void Calc_Prj_Est_Point()
    {
        int rowCnt = uwgrid_Weight.Rows.Count;

        object[] arrValue = new object[rowCnt];
        object[] arrWeight = new object[rowCnt];



        DataTable dtValue = new DataTable();
        DataTable dtWeight = new DataTable();


        
        string[] colList = new string[rowCnt];
        for (int i = 0; i < rowCnt; i++)
        {
            colList[i] = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_ID").Value.ToString();
            arrValue[i] = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_VALUE").Value;
            arrWeight[i] = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_WEIGHT").Value;

            dtValue.Columns.Add(colList[i], typeof(double));
            dtWeight.Columns.Add(colList[i], typeof(double));
        }


        
        dtValue.Rows.Add(arrValue);
        dtWeight.Rows.Add(arrWeight);


        int dfRowCnt = uwgrid_Difficulty.Rows.Count;
        string[] dfCollist = new string[dfRowCnt];
        object[] dfValue = new object[dfRowCnt];

        for (int i = 0; i < dfRowCnt; i++)
        {
            dfCollist[i] = uwgrid_Difficulty.Rows[i].Cells.FromKey("PRJ_COL_ID").Value.ToString();
            dfValue[i] = uwgrid_Difficulty.Rows[i].Cells.FromKey("PRJ_COL_VALUE").Value;

            dtValue.Columns.Add(dfCollist[i], typeof(double));
            dtValue.Rows[0][dfCollist[i]] = dfValue[i];
        }


        string soosik = this.lblCommonSoosik.Text.Replace("\r", "").Replace("\n", "");
        object Result = dtValue.Compute(soosik, null).ToString();


        this.lblPrjEstPoint.Text = Math.Round(Convert.ToDouble(Result), 1).ToString();
    }



    protected void Calc_Prj_Est_Point_2()
    {
        double Result;

        DataTable calcDt = new DataTable();
        calcDt.Columns.Add("COL_ID");
        calcDt.Columns.Add("COL_TYPE");
        calcDt.Columns.Add("COL_WEIGHT");
        calcDt.Columns.Add("COL_VALUE");

        object[] tmpRow = new object[4];

        int rowCnt = uwgrid_Weight.Rows.Count;


        //가중치 컬럼/밸류 추가
        for (int i = 0; i < rowCnt; i++)
        {
            tmpRow[0] = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_ID").Value;
            tmpRow[1] = "A";
            tmpRow[2] = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_WEIGHT").Value;
            tmpRow[3] = uwgrid_Weight.Rows[i].Cells.FromKey("PRJ_COL_VALUE").Value;

            calcDt.Rows.Add(tmpRow);
        }



        int dfRowCnt = uwgrid_Difficulty.Rows.Count;

        //난이도 추가
        for (int i = 0; i < dfRowCnt; i++)
        {
            tmpRow[0] = uwgrid_Difficulty.Rows[i].Cells.FromKey("PRJ_COL_ID").Value.ToString();
            tmpRow[1] = "D";
            tmpRow[2] = null;
            tmpRow[3] = uwgrid_Difficulty.Rows[i].Cells.FromKey("PRJ_COL_VALUE").Value;

            calcDt.Rows.Add(tmpRow);
        }


        //위로 테이블 준비
        //아래로 테이블 바탕으로 계산


        if (calcDt.Rows.Count == 0)
            Result = 0.0;
        else
        {
            double tmpNum1;
            double tmpNum2;


            //난이도 곱셈
            double difficulty = 0.0;
            if (dfRowCnt > 0)
            {
                DataTable dtDifficulty = DataTypeUtility.FilterSortDataTable(calcDt, "COL_TYPE='D'");
                for (int i = 0; i < dtDifficulty.Rows.Count; i++)
                {
                    tmpNum1 = DataTypeUtility.GetToDouble(dtDifficulty.Rows[i]["COL_VALUE"]);
                    if (i == 0)
                        difficulty = tmpNum1;
                    else
                        difficulty = difficulty * tmpNum1;
                }
            }



            //가중치 컬럼끼리 합계
            double etcValue = 0.0;
            if (rowCnt > 0)
            {
                DataTable dtEtcValue = DataTypeUtility.FilterSortDataTable(calcDt, "COL_TYPE='A'");
                for (int i = 0; i < dtEtcValue.Rows.Count; i++)
                {
                    tmpNum1 = DataTypeUtility.GetToDouble(dtEtcValue.Rows[i]["COL_WEIGHT"]) / 100;
                    tmpNum2 = DataTypeUtility.GetToDouble(dtEtcValue.Rows[i]["COL_VALUE"]);

                    if (i == 0)
                        etcValue = tmpNum1 * tmpNum2;
                    else
                        etcValue += tmpNum1 * tmpNum2;
                }
            }

            Result = Math.Round(difficulty * etcValue, 1);
        }



        this.lblPrjEstPoint.Text = DataTypeUtility.GetString(Result);
    }




    protected void ibnCalcPrjEstPoint_Click(object sender, EventArgs e)
    {
        Calc_Prj_Est_Point_2();
    }


    protected void uwgrid_Weight_InitializeRow(object sender, RowEventArgs e)
    {
        if (e.Row.Cells.FromKey("PRJ_COL_CUSTOM_YN").Value.ToString().Equals("N") 
            || EST_EMP_ID == gUserInfo.Emp_Ref_ID)
        {
            e.Row.Cells.FromKey("PRJ_COL_VALUE").AllowEditing = AllowEditing.No;
        }
        else
        {
            e.Row.Cells.FromKey("PRJ_COL_VALUE").Style.BackColor = System.Drawing.Color.MintCream;
        }

        double prj_col_weight = DataTypeUtility.GetToDouble(e.Row.Cells.FromKey("PRJ_COL_WEIGHT").Value);
        double prj_col_value = DataTypeUtility.GetToDouble(e.Row.Cells.FromKey("PRJ_COL_VALUE").Value);

        double cal = prj_col_value * (prj_col_weight / 100);

        e.Row.Cells.FromKey("PRJ_COL_CAL").Value = cal;
    }


    protected void uwgrid_TGT_EMP_LIST_InitializeRow(object sender, RowEventArgs e)
    {
        //평가상태 아이콘
        UltraGridCell status_Cell = e.Row.Cells.FromKey("EST_STATUS");
        string EST_STATUS = status_Cell.Value.ToString();

        string redIcon = "../images/icon/color/red.gif";
        string greenIcon = "../images/icon/color/green.gif";
        string blueIcon = "../images/icon/color/blue.gif";

        string imgURL = "<img src=\"{0}\" />";

        if (EST_STATUS.Equals("N"))
        {
            status_Cell.Value = string.Format(imgURL, redIcon);
        }
        else if (EST_STATUS.Equals("P"))
        {
            status_Cell.Value = string.Format(imgURL, greenIcon);
        }
        else
        {
            status_Cell.Value = string.Format(imgURL, blueIcon);
        }





        if (!EST_STATUS.Equals("E"))
        {
            UltraGridCell btn_Cell = e.Row.Cells.FromKey("EST_BTN");
            string btnText;

            btnText = "평가하기";
            /*
            if (EST_STATUS.Equals("N"))
            {
                btnText = "평가하기";
            }
            else if (EST_STATUS.Equals("P"))
            {
                btnText = "확정하기";
            }
            else
            {
                btnText = "확정취소";
            }
            */

            string TGT_DEPT_ID = e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString();
            string TGT_EMP_ID = e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString();
            string jsLink = string.Format("javascript:TGT_EMP_EST_POPUP('{0}', '{1}');", TGT_DEPT_ID, TGT_EMP_ID);

            btn_Cell.Value = string.Format("<a href=\"{0}\" >{1}</a>", jsLink, btnText);
        }
    }
}