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
using MicroBSC.Integration.PMS.Biz;

public partial class PMS_PMS0200S1 : EstPageBase
{
    SiteIdentity gUserInfo;


    Biz_Pms_Info bizPmsInfo;
    Biz_Pms_Col_Info bizPmsColInfo;
    Biz_Pms_Com_Info bizPmsComInfo;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }




    protected void Page_Load(object sender, EventArgs e)
    {
        gUserInfo = (SiteIdentity)Context.User.Identity;
        
        
        bizPmsInfo = new Biz_Pms_Info();
        bizPmsColInfo = new Biz_Pms_Col_Info();
        bizPmsComInfo = new Biz_Pms_Com_Info();

        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);

            this.prj_sDate.Value = System.DateTime.Now.AddMonths(-1);
        }


        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

        ltrScript.Text = "";

        ibnSoosikSave.Visible = false;
        ibnSoosikSave.Enabled = false;
    }



    protected string PRJ_ID
    {
        get
        {
            return hdfPRJ_ID.Value.ToString();
        }
        set
        {
            hdfPRJ_ID.Value = value;
        }
    }



    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();
        UltraWebGrid2.Bands[0].ResetColumns();
        UltraWebGrid3.Clear();
        
        this.TxtBox_Soosik.Text = "";

        Project_Bind();
    }



    protected void Project_Bind()
    {
        Biz_Pms_Info bizPms = new Biz_Pms_Info();
        object StartDate = this.prj_sDate.Value;
        object EndDate = this.prj_eDate.Value;

        DataTable DT = bizPms.Get_Project_List((DateTime)StartDate, (DateTime)EndDate);

        UltraWebGrid1.DataSource = DT;
        UltraWebGrid1.DataBind();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        object status_id = e.Row.Cells.FromKey("STATUS_ID").Value;


        string redIcon = "../images/icon/color/red.gif";
        string greenIcon = "../images/icon/color/green.gif";
        string blueIcon = "../images/icon/color/blue.gif";

        string imgStr = "<img src=\"{0}\"/>";
        
        string status;


        if (status_id == null || status_id.ToString().Equals("N"))
        {
            status = "-";
        }
        else if (status_id.ToString().Equals("P"))
        {
            status = string.Format(imgStr, greenIcon);
        }
        else if (status_id.ToString().Equals("E"))
        {
            status = string.Format(imgStr, blueIcon);
        }
        else
        {
            status = "-";
        }

        e.Row.Cells.FromKey("STATUS").Value = status;
    }
    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        UltraWebGrid2.Clear();
        UltraWebGrid2.Bands[0].ResetColumns();

        PRJ_ID = e.SelectedRows[0].Cells.FromKey("PROJECTID").Value.ToString();

        Project_Detail_Bind();
        Custom_Col_Bind();
        Soosik_Bind();
    }


    protected void Project_Detail_Bind()
    { 
        object StartDate = this.prj_sDate.Value;
        object EndDate = this.prj_eDate.Value;

        DataTable DT = bizPmsInfo.Get_Project_Detail(PRJ_ID, (DateTime)StartDate, (DateTime)EndDate);

        UltraWebGrid2.DataSource = DT;
        UltraWebGrid2.DataBind();
    }


    protected void UltraWebGrid2_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Bands[0].ResetColumns();

        DataTable DT = (DataTable)e.Layout.Grid.DataSource;
        DataTable ColInfo = bizPmsColInfo.Get_Col_Info_List(PRJ_ID);

        for (int i = 0; i < DT.Columns.Count; i++)
        {
            UltraGridColumn objColumn = new UltraGridColumn();
            objColumn.Key = DT.Columns[i].ColumnName;
            objColumn.BaseColumnName = DT.Columns[i].ColumnName;
            objColumn.Header.Caption = DT.Columns[i].ColumnName;
            objColumn.Header.Style.HorizontalAlign = HorizontalAlign.Center;
            objColumn.CellStyle.HorizontalAlign = HorizontalAlign.Left;


            string column_ID = DT.Columns[i].ColumnName;
            string column_name = null;

            for (int j = 0; j < ColInfo.Rows.Count; j++)
            {
                if (ColInfo.Rows[j]["PRJ_COL_ID"].ToString().Equals(column_ID))
                {
                    column_name = ColInfo.Rows[j]["PRJ_COL_NAME"].ToString();
                    break;
                }
            }

            if (column_name != null)
            {
                objColumn.Header.Caption = column_name;
            }


            UltraWebGrid2.Columns.Add(objColumn);
        }
    }



    protected void Custom_Col_Bind()
    {
        DataTable DT = bizPmsColInfo.Get_Custom_Col_List(PRJ_ID);

        UltraWebGrid3.DataSource = DT;
        UltraWebGrid3.DataBind();
    }



    protected void Soosik_Bind()
    {
        string Soosik_desc = bizPmsColInfo.Get_Common_Soosik_Desc(PRJ_ID);

        this.TxtBox_Soosik.Text = Soosik_desc;
    }



    protected void Save_Custom_Col_Value()
    {
        DataTable DT = new DataTable();
        string[] Cols = new string[] { "PRJ_COL_ID", "PRJ_COL_NAME", "PRJ_COL_VALUE" };

        for (int i = 0; i < Cols.Length; i++)
        {
            DT.Columns.Add(Cols[i]);
        }
        
        DT = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid3, Cols, DT);

        bool Result;
        
        Result = bizPmsColInfo.Modify_Custom_Col_Value(DT, PRJ_ID, gUserInfo.Emp_Ref_ID.ToString());

        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장에 실패하였습니다.");
        }
    }




    protected void ibnCustomCol_Value_Save_Click(object sender, ImageClickEventArgs e)
    {
        Save_Custom_Col_Value();
    }




    protected void ibnSoosikSave_Click(object sender, ImageClickEventArgs e)
    {
        Save_Common_Soosik_Value();
    }

    protected void ibnPMS_IF_Click(object sender, EventArgs e)
    {
        int Pms_Com_Info_Idx = 1;
        bool Result;

        object start_date = prj_sDate.Value;
        object end_date = prj_eDate.Value;


        DataTable dtPrj_ID = bizPmsInfo.Get_Vw_ProjectID((DateTime)start_date, (DateTime)end_date);
        dtPrj_ID = DataTypeUtility.FilterSortDataTable(dtPrj_ID, " STATUS_ID IS NULL");


        Result = bizPmsColInfo.Sync_Col_Info(Pms_Com_Info_Idx, dtPrj_ID, gUserInfo.Emp_Ref_ID.ToString());
        if (Result)
        {
            /*
            for (int i = 0; i < dtPrj_ID.Rows.Count; i++)
            {
                string prj_id = dtPrj_ID.Rows[i]["PROJECTID"].ToString();

                DataTable dtColList = bizPmsColInfo.Get_Col_Info_List(prj_id);
                System.Text.StringBuilder colList = new StringBuilder();
                for (int j = 0; j < dtColList.Rows.Count; j++)
                {
                    if (colList.Length > 0)
                        colList.Append(", ");
                    colList.Append(dtColList.Rows[j]["PRJ_COL_ID"].ToString());
                }
                Result = bizPmsInfo.Add_Project_Info_To_Pms((DateTime)start_date, (DateTime)end_date, prj_id, colList.ToString());

                if (!Result)
                    break;
            }
            */


            DataTable dtComInfo = bizPmsComInfo.Get_Pms_Com_Info(Pms_Com_Info_Idx);
            string srcIF_COL_ID = dtComInfo.Rows[0]["IF_COL_ID"].ToString();
            string tgtIF_COL_ID = "";
            string tmpIF_COL_ID;
            string[] arrIF_COL_ID = bizPmsColInfo.Remove_Escape_Blank_Char(srcIF_COL_ID).Split(',');
            for (int i = 0; i < arrIF_COL_ID.Length; i++)
            {
                string col_type = bizPmsColInfo.Proc_Col_Type(arrIF_COL_ID[i]);
                if (col_type.Equals("B"))
                {
                    tmpIF_COL_ID = arrIF_COL_ID[i];
                }
                else
                {
                    tmpIF_COL_ID = arrIF_COL_ID[i].Substring(0, arrIF_COL_ID[i].IndexOf("("));
                }

                if (tgtIF_COL_ID.Length > 0)
                    tgtIF_COL_ID += ", ";
                tgtIF_COL_ID += tmpIF_COL_ID;
            }

            string prj_id_list = "";
            for (int i = 0; i < dtPrj_ID.Rows.Count; i++)
            {
                if (prj_id_list.Length > 0)
                    prj_id_list += ", ";
                prj_id_list += "'" + dtPrj_ID.Rows[i]["PROJECTID"].ToString() + "'";
            }
            Result = bizPmsInfo.Add_Project_Info_To_Pms((DateTime)start_date, (DateTime)end_date, prj_id_list, tgtIF_COL_ID );
        }
        


        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장에 실패하였습니다.");
        }


        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();
        UltraWebGrid2.Bands[0].ResetColumns();
        UltraWebGrid3.Clear();

        this.TxtBox_Soosik.Text = "";

        Project_Bind();
    }


    protected void Save_Common_Soosik_Value()
    {
        bool Result;

        Result = bizPmsColInfo.Modify_Common_Soosik_Value(PRJ_ID, this.TxtBox_Soosik.Text, gUserInfo.Emp_Ref_ID.ToString());

        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장에 실패하였습니다.");
        }
    }
}

