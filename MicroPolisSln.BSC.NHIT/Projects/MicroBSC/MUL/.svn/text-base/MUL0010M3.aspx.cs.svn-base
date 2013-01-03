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
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using Infragistics.WebUI.UltraWebGrid;

using System.Collections.Generic;
using System.Text;


using MicroBSC.Estimation.Biz;
using MicroBSC.Integration.MUL.Biz;

public partial class MUL_MUL0010M3 : EstPageBase
{
    private string TGT_DEPT_ID;
    private string TGT_DEPT_NAME;
    private string TGT_EMP_ID;
    private string TGT_EMP_NAME;
    private string AVG_POINT;

    protected void Page_Load(object sender, EventArgs e)
    {
        Biz_Mul_Est_Data bizMulEstData = new Biz_Mul_Est_Data();
        DataTable DT = new DataTable();

        TGT_DEPT_ID = WebUtility.GetRequest("TGT_DEPT_ID");
        TGT_DEPT_NAME = "";
        TGT_EMP_ID = WebUtility.GetRequest("TGT_EMP_ID");
        TGT_EMP_NAME = "";
        AVG_POINT = "";

        if (TGT_DEPT_ID.Length > 0 && TGT_EMP_ID.Length > 0)
        {
            try
            {
                DT = bizMulEstData.Get_Est_Tgt_Emp_Info(TGT_DEPT_ID, TGT_EMP_ID);

                if (DT.Rows.Count > 0)
                {
                    TGT_DEPT_NAME = DT.Rows[0]["TGT_DEPT_NAME"].ToString();
                    TGT_EMP_NAME = DT.Rows[0]["TGT_EMP_NAME"].ToString();
                    AVG_POINT = DT.Rows[0]["AVG_POINT"].ToString();
                }

                if (AVG_POINT.Trim().Length == 0)
                    AVG_POINT = "-";

                Set_Labels();
                doBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



    protected void doBind()
    {
        Biz_Mul_Est_Data bizMulEstData = new Biz_Mul_Est_Data();

        DataTable DT = new DataTable();

        DT = bizMulEstData.Get_Est_Emp_List(TGT_DEPT_ID, TGT_EMP_ID);

        UltraWebGrid1.DataSource = DT;
        UltraWebGrid1.DataBind();
    }



    protected void Set_Labels()
    {
        lblTGT_DEPT_NAME.Text = TGT_DEPT_NAME;
        lblTGT_EMP_NAME.Text = TGT_EMP_NAME;
        lblAVG_POINT.Text = AVG_POINT;
    }


    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        UltraGridCell objCell = e.Row.Cells.FromKey("EST_POINT");

        if (objCell.Value == null)
        {
            objCell.Value = "-";
        }
    }
    
}
