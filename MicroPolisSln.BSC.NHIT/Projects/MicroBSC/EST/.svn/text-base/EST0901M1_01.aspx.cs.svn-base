using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Estimation.Biz;
using System.Data;

public partial class EST_EST0901M1_01 : AppPageBase
{
    #region ======================= [ Variable, Property ] ===============
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string ITermRefId { 
        get 
        {
            if (ViewState["ITERMREFID"] == null)
            {
                ViewState["ITERMREFID"] = GetRequest("iTermRefId", "");
            }

            return (string)ViewState["ITERMREFID"];
        }
        private set 
        {
            ViewState["ITERMREFID"] = value;
        } 
    }

    private int _iestterm_ref_id = 0;
    #endregion
    #region ======================= [ Server Event ] ========================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.InitControlValue();
            this.SetResultListGrid();
            
            this.gridStdDevSetting.Columns.FromKey("ScoreCode").EditorControlID = this.txtNormalEditor.UniqueID;
            this.gridStdDevSetting.Columns.FromKey("ScoreName").EditorControlID = this.txtNormalEditor.UniqueID;
            this.gridStdDevSetting.Columns.FromKey("MinValue").EditorControlID = this.txtNumberEditor.UniqueID;
            this.gridStdDevSetting.Columns.FromKey("MaxValue").EditorControlID = this.txtNumberEditor.UniqueID;
        }
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas bizStdDev = new Biz_Datas();
        DataTable dtStdDevGrade = new DataTable();
        int resultCnt = 0;
        // 테이블 구조 생성
        foreach (UltraGridColumn col in this.gridStdDevSetting.Columns)
        {
            dtStdDevGrade.Columns.Add(col.Key);
        }

        for (int rowIdx = 0; rowIdx < gridStdDevSetting.Rows.Count; rowIdx++)
        {
            dtStdDevGrade.Rows.Add(gridStdDevSetting.Rows[rowIdx].Cells.FromKey("checkDel").Value
                                        , gridStdDevSetting.Rows[rowIdx].Cells.FromKey("ScoreCode").Value
                                        , gridStdDevSetting.Rows[rowIdx].Cells.FromKey("ScoreName").Value
                                        , gridStdDevSetting.Rows[rowIdx].Cells.FromKey("MinValue").Value
                                        , gridStdDevSetting.Rows[rowIdx].Cells.FromKey("MaxValue").Value);
        }

        resultCnt = bizStdDev.SaveAllStdDevGrade(dtStdDevGrade, int.Parse(this.USERID));
    }
    #endregion
    #region ======================== [ Method ] =========================
    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlTerm);
    }

    public void SetResultListGrid()
    {
        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlTerm);
        DataSet dsStdDev;
        Biz_Datas bizStdDev = new Biz_Datas();

        dsStdDev = bizStdDev.SelectAllStdDevGrade();

        this.gridStdDevSetting.DataSource = dsStdDev;
        this.gridStdDevSetting.DataBind();
    }
    #endregion
    
}
