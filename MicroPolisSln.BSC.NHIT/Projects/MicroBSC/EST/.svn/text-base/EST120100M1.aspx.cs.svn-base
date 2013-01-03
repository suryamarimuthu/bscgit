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
using System.IO;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.WebDataInput;
using System.Drawing;

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

using MicroBSC.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Integration.COM.Biz;
using MicroBSC.Integration.EST.Biz;

public partial class EST120100M1 : AppPageBase
{
    public int COMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
            {
                ViewState["COMP_ID"] = WebUtility.GetRequestByInt("COMP_ID");
            }

            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }

    public int ESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public string EST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
            {
                ViewState["EST_ID"] = WebUtility.GetRequest("EST_ID");
            }

            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }

    public string POS_ID
    {
        get
        {
            if (ViewState["POS_ID"] == null)
            {
                ViewState["POS_ID"] = WebUtility.GetRequest("POS_ID");
            }

            return (string)ViewState["POS_ID"];
        }
        set
        {
            ViewState["POS_ID"] = value;
        }
    }

    public string DEPT_TYPE_REF_ID_LIST
    {
        get
        {
            if (ViewState["DEPT_TYPE_REF_ID_LIST"] == null)
            {
                ViewState["DEPT_TYPE_REF_ID_LIST"] = WebUtility.GetRequest("DEPT_TYPE_REF_ID_LIST");
            }

            return (string)ViewState["DEPT_TYPE_REF_ID_LIST"];
        }
        set
        {
            ViewState["DEPT_TYPE_REF_ID_LIST"] = value;
        }
    }

    public int[] DEPT_TYPE_REF_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";

        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            PageUtility.FindByValueDropDownList(ddlEstTermRefID, ESTTERM_REF_ID);

            DropDownListCommom.BindPositionInfo(ddlEstPosInfo);
            PageUtility.FindByValueDropDownList(ddlEstPosInfo, POS_ID);
        }



        //쿼리스트링으로 받은 부서타입을 배열로 변환
        DEPT_TYPE_REF_ID_LIST = DEPT_TYPE_REF_ID_LIST.Replace(" ", "");
        string[] tmp = DEPT_TYPE_REF_ID_LIST.Split(',');
        DEPT_TYPE_REF_ID = new int[tmp.Length];
        for (int i = 0; i < tmp.Length; i++)
        {
            if (tmp[i].Trim().Length > 0)
            {
                DEPT_TYPE_REF_ID[i] = DataTypeUtility.GetToInt32(tmp[i]);
            }
            else
            { 
                //비정상 데이터
                this.ltrScript.Text = JSHelper.GetAlertScript("비정상 부서타입이 존재합니다.");
                return;
            }
        }




        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        POS_ID = WebUtility.GetByValueDropDownList(ddlEstPosInfo);

        if (!IsPostBack)
            doBind();
    }





    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        doBind();
    }
    protected void doBind()
    {
        string dept_type_ref_id_list = "";
        for (int i = 0; i < DEPT_TYPE_REF_ID.Length; i++)
        {
            if (dept_type_ref_id_list.Length > 0)
                dept_type_ref_id_list += ", ";

            dept_type_ref_id_list += DEPT_TYPE_REF_ID[i];
        }

        Biz_PositionInfos bizPosInfo = new Biz_PositionInfos(POS_ID);


        //종으로 출력된 부서타입별 가중치를 횡으로 변환
        if (bizPosInfo.Position_Table_Name != null && bizPosInfo.Position_Table_Name.Trim().Length > 0)
        {
            Biz_Est_Pos_Weight bizEstPosWeight = new Biz_Est_Pos_Weight();
            DataTable dt = bizEstPosWeight.Get_Est_Pos_Weight(POS_ID
                                                                , bizPosInfo.Position_Table_Name
                                                                , dept_type_ref_id_list
                                                                , COMP_ID
                                                                , ESTTERM_REF_ID
                                                                , EST_ID);

            DataTable dt_result = DataTypeUtility.GetGroupByDataTable(dt, new string[] { "POS_ID", "POS_VALUE", "POS_VALUE_NAME" });

            if (dt_result.Rows.Count > 0)
            {
                for (int i = 0; i < DEPT_TYPE_REF_ID.Length; i++)
                {
                    int dept_type_ref_id = DEPT_TYPE_REF_ID[i];
                    
                    string colName = string.Format("WEIGHT_{0}", dept_type_ref_id);
                    dt_result.Columns.Add(colName);


                    Biz_DeptTypeInfo bizDeptTypeInfo = new Biz_DeptTypeInfo(dept_type_ref_id);
                    string dept_type_name = bizDeptTypeInfo.Itype_name;

                    
                    
                    TemplatedColumn srcCol = (TemplatedColumn)UltraWebGrid1.Columns.FromKey("WEIGHT");
                    //컬럼 복사 후 추가
                    if (!UltraWebGrid1.Columns.Exists(colName))
                    {
                        UltraGridColumn hdCol = new UltraGridColumn();//히든 컬럼
                        hdCol.BaseColumnName = colName;
                        hdCol.Key = colName;
                        hdCol.Hidden = true;
                        UltraWebGrid1.Columns.Insert(srcCol.Index, hdCol);
                    }

                    if (!UltraWebGrid1.Columns.Exists("i"+colName))
                    {
                        TemplatedColumn tgtCol = new TemplatedColumn();//입력 컬럼
                        tgtCol.CopyFrom(srcCol);
                        tgtCol.BaseColumnName = "i" + colName;
                        tgtCol.Key = "i" + colName;
                        tgtCol.Hidden = false;
                        tgtCol.Width = Unit.Pixel(80);
                        tgtCol.Header.Caption = string.Format("{0} 가중치", dept_type_name);

                        UltraWebGrid1.Columns.Insert(srcCol.Index, tgtCol);
                    }

                    




                    DataTable dt_filtered_pos_weght = DataTypeUtility.FilterSortDataTable(dt, string.Format("DEPT_TYPE_REF_ID={0}", dept_type_ref_id));

                    if (dt_filtered_pos_weght.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt_result.Rows.Count; j++)
                        {
                            string pos_value = DataTypeUtility.GetString(dt_result.Rows[j]["POS_VALUE"]);

                            DataTable dt_pos_weight = DataTypeUtility.FilterSortDataTable(dt_filtered_pos_weght, string.Format("POS_VALUE='{0}'", pos_value));

                            if (dt_pos_weight.Rows.Count > 0)
                            {
                                double pos_weight = DataTypeUtility.GetToDouble(dt_pos_weight.Rows[0]["WEIGHT"]);
                                dt_result.Rows[j][string.Format("WEIGHT_{0}", dept_type_ref_id)] = pos_weight;
                            }
                            else
                            {
                                dt_result.Rows[j][string.Format("WEIGHT_{0}", dept_type_ref_id)] = 0;
                            }
                        }
                    }
                }
            }
            
            
            UltraWebGrid1.Clear();
            UltraWebGrid1.DataSource = dt_result;
            UltraWebGrid1.DataBind();
        }
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    { 
    
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        double total_weight = 0;//가중치 합계
        double weight = 0;//부서 가중치


        //가중치 입력 필드에 바인드
        for (int i = 0; i < DEPT_TYPE_REF_ID.Length; i++)
        {
            string colName = string.Format("WEIGHT_{0}", DEPT_TYPE_REF_ID[i]);
            TemplatedColumn tc = (TemplatedColumn)UltraWebGrid1.Columns.FromKey("i" + colName);
            Infragistics.WebUI.WebDataInput.WebNumericEdit ne = (Infragistics.WebUI.WebDataInput.WebNumericEdit)((CellItem)tc.CellItems[e.Row.Index]).FindControl("WEIGHT");
            
            weight = DataTypeUtility.GetToDouble(e.Row.Cells.FromKey(colName).Value);
            ne.Value = weight;

            total_weight += weight;
        }


        e.Row.Cells.FromKey("TOTAL_WEIGHT").Value = total_weight;
    }




    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (doSave())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("처리되었습니다.");
            doBind();
        }
        else
        {
            this.ltrScript.Text += JSHelper.GetAlertScript("실패하였습니다.");
        }
    }
    protected bool doSave()
    {
        Biz_Est_Pos_Weight bizEstPosWeight = new Biz_Est_Pos_Weight();
        DataTable dt = bizEstPosWeight.Get_Est_Pos_Weight_Tbl_Scheme();




        for (int i = 0; i < UltraWebGrid1.Rows.Count; i++)
        {
            


            double total_weight = 0;//가중치 합계
            double weight = 0;//부서 가중치



            for (int j = 0; j < DEPT_TYPE_REF_ID.Length; j++)
            {
                DataRow dr = dt.NewRow();

                string colName = string.Format("WEIGHT_{0}", DEPT_TYPE_REF_ID[j]);

                TemplatedColumn tc = (TemplatedColumn)UltraWebGrid1.Columns.FromKey("i" + colName);
                Infragistics.WebUI.WebDataInput.WebNumericEdit ne = (Infragistics.WebUI.WebDataInput.WebNumericEdit)((CellItem)tc.CellItems[i]).FindControl("WEIGHT");
                weight = DataTypeUtility.GetToDouble(ne.Value);

                total_weight += weight;


                dr["COMP_ID"] = COMP_ID;
                dr["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
                dr["EST_ID"] = EST_ID;
                dr["SEQ"] = i;
                dr["POS_ID"] = UltraWebGrid1.Rows[i].Cells.FromKey("POS_ID").Value;
                dr["POS_VALUE"] = UltraWebGrid1.Rows[i].Cells.FromKey("POS_VALUE").Value;
                dr["DEPT_TYPE_REF_ID"] = DEPT_TYPE_REF_ID[j];
                dr["WEIGHT"] = weight;

                dt.Rows.Add(dr);
            }


            if (total_weight != 100)
            {
                this.ltrScript.Text = JSHelper.GetAlertScript("본부 가중치와 팀 가중치의 합은 100이 되어야 합니다.");
                return false;
            }
        }


        //dt를 넘겨서 db에 저장
        int affectedRow = bizEstPosWeight.Add_Est_Pos_Weight(COMP_ID
                                                            , ESTTERM_REF_ID
                                                            , EST_ID
                                                            , dt
                                                            , POS_ID
                                                            , gUserInfo.Emp_Ref_ID);

        return affectedRow > 0 ? true : false;
    }
}