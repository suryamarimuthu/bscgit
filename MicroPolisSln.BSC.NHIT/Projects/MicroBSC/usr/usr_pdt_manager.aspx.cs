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

using SJ.Web.UI;

using MicroBSC.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.BSC.Biz;

using DeptInfos = MicroBSC.Estimation.Dac.DeptInfos;

public partial class usr_pdt_manager : AppPageBase
{
    private DataSet dsDept      = null;
    private DataSet dsDeptData  = null;
    private int VER_ID          = 0;
    private int ESTTERM_REF_ID  = 0;

    public string DeptID 
    {
        get 
        {
            if (Session["DEPT_REF_ID"] == null)
                return "0";

            return (string)Session["DEPT_REF_ID"];
        }
        set 
        {
            Session["DEPT_REF_ID"] = value;
        }
    }

    protected void Page_Init(object sender, System.EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
        CreateDataGrid();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        VER_ID          = PageUtility.GetIntByValueDropDownList(ddlStgVersion);
        ESTTERM_REF_ID  = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        if (!Page.IsPostBack) 
        {
            DeptID = "0";

            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.FillEstTree(trvEstDept, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), EMP_REF_ID);
            StgVersionDropDownBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

            StgVerDataBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                             , PageUtility.GetIntByValueDropDownList(ddlStgVersion));

            iBtnSearch.Attributes.Add("onclick", "return ValidCheck();");
        }

        ltrScript.Text  = "";
    }

    private void StgVersionDropDownBinding(int estterm_ref_id) 
    {
        ddlStgVersion.ClearSelection();
        Biz_PDTAndAHPVersions pdtAhpVersion = new Biz_PDTAndAHPVersions();
        DataSet ds                          = pdtAhpVersion.GetPdtAhpVersions(estterm_ref_id); 
        ddlStgVersion.DataSource            = ds;
        ddlStgVersion.DataValueField        = "VER_ID";
        ddlStgVersion.DataTextField         = "VER_NAME";
        ddlStgVersion.DataBind();
    }

    private void CreateDataGrid() 
    {
        TemplateColumn templeatCol = null;

        DeptInfos deptInfo                          = new DeptInfos();
        dsDept                                      = deptInfo.GetEstDeptListByLevel(int.Parse(DeptID));

        foreach (DataRow dr in dsDept.Tables[0].Rows) 
        {
            /* 2011-08-29 수정 : DataGrid에서 UltraDataGrid로 변환으로 변경 필요 
            templeatCol                             = new TemplateColumn();
            templeatCol.HeaderTemplate              = new DGridTemplete(ListItemType.Header, dr["DEPT_NAME"].ToString(), "");
            templeatCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            templeatCol.ItemTemplate                = new DGridTemplete(ListItemType.Item, "C_" + dr["EST_DEPT_REF_ID"].ToString());
            templeatCol.ItemStyle.HorizontalAlign   = HorizontalAlign.Center;
            DataGrid1.Columns.Add(templeatCol);
            */
            Infragistics.WebUI.UltraWebGrid.TemplatedColumn tempCol = new Infragistics.WebUI.UltraWebGrid.TemplatedColumn();
            DataGrid1.Bands[0].Columns.Add(tempCol);
        }
    }

    private void StgVerDataBinding(int estterm_ref_id, int ver_id)
    {
        if (DeptID == "0" || DeptID == "")
            return;

        Biz_PDTAndAHPStgInfos stgInfo               = new Biz_PDTAndAHPStgInfos();
        DataSet ds                                  = stgInfo.GetPDTAndAHPStgInfo(ver_id, estterm_ref_id, 0);

        Biz_PDTAndAHPStgEstDeptDatas pdtAhpStgEst   = new Biz_PDTAndAHPStgEstDeptDatas();
        dsDeptData                                  = pdtAhpStgEst.GetPDTAndAHPStgEstDeptData(ver_id, estterm_ref_id, int.Parse(DeptID), 0);

        DataRow dr                      = null;

        if (ds.Tables[0].Rows.Count == 0)
            return;

        DataTable stgVerData = new DataTable();

        stgVerData.Columns.Add("STG_REF_ID" , typeof(int));
        stgVerData.Columns.Add("UP_STG_ID"  , typeof(int));
        stgVerData.Columns.Add("STG_NAME"   , typeof(string));
        stgVerData.Columns.Add("LEVEL"      , typeof(int));
        stgVerData.Columns.Add("STG_MAP_YN" , typeof(string));
        stgVerData.Columns.Add("F_YN"       , typeof(string));
        stgVerData.Columns.Add("C_YN"       , typeof(string));
        stgVerData.Columns.Add("P_YN"       , typeof(string));
        stgVerData.Columns.Add("L_YN"       , typeof(string));

        ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["STG_REF_ID"], ds.Tables[0].Columns["UP_STG_ID"], false);

        int level = 0;

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (Convert.ToInt32(dbRow["UP_STG_ID"]) == 0)
            {
                dr                  = stgVerData.NewRow();
                dr["STG_REF_ID"]    = int.Parse(dbRow["STG_REF_ID"].ToString());
                dr["UP_STG_ID"]     = int.Parse(dbRow["UP_STG_ID"].ToString());
                dr["STG_NAME"]      = dbRow["STG_NAME"].ToString();
                dr["LEVEL"]         = level;
                dr["STG_MAP_YN"]    = dbRow["STG_MAP_YN"].ToString();
                dr["F_YN"]          = dbRow["F_YN"].ToString();
                dr["C_YN"]          = dbRow["C_YN"].ToString();
                dr["P_YN"]          = dbRow["P_YN"].ToString();
                dr["L_YN"]          = dbRow["L_YN"].ToString();
                stgVerData.Rows.Add(dr);

                PopulateSubTree(dbRow, ref stgVerData, level);
            }
        }

        DataGrid1.DataSource = stgVerData;
        DataGrid1.DataBind();

        if (stgVerData.Rows.Count > 0)
            iBtnSave.Visible = true;
    }

    private void PopulateSubTree(DataRow dbRow, ref DataTable dataTable, int level)
    {
        DataRow dr = null;
        level++;

        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            dr                  = dataTable.NewRow();
            dr["STG_REF_ID"]    = int.Parse(childRow["STG_REF_ID"].ToString());
            dr["UP_STG_ID"]     = int.Parse(childRow["UP_STG_ID"].ToString());
            dr["STG_NAME"]      = childRow["STG_NAME"].ToString();
            dr["LEVEL"]         = level;
            dr["STG_MAP_YN"]    = childRow["STG_MAP_YN"].ToString();
            dr["F_YN"]          = childRow["F_YN"].ToString();
            dr["C_YN"]          = childRow["C_YN"].ToString();
            dr["P_YN"]          = childRow["P_YN"].ToString();
            dr["L_YN"]          = childRow["L_YN"].ToString();
            dataTable.Rows.Add(dr);

            PopulateSubTree(childRow, ref dataTable, level);
        }
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (!DataGrid1.Visible)
            DataGrid1.Visible = true;

        StgVerDataBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                             , PageUtility.GetIntByValueDropDownList(ddlStgVersion));
    }
    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptID = trvEstDept.SelectedNode.Value;

        PopupControlExtender1.Commit(trvEstDept.SelectedNode.Text);
        PopupControlExtender2.Commit(trvEstDept.SelectedNode.Value);
    }

    private bool isVisible;

    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Item.DataItem;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
            isVisible = true;

            (e.Item.Cells[0].FindControl("lblStgName") as Label).Text
                = "&nbsp;" + PageUtility.ReplicationStr("&nbsp;&nbsp;&nbsp;&nbsp;", int.Parse(drw["LEVEL"].ToString()))
                    + "<img align='absbottom' src='../images/pdt/lev_" + Convert.ToInt32(int.Parse(drw["LEVEL"].ToString()) + 1).ToString() + ".gif'>"
                    + drw["STG_NAME"].ToString();

            int stg_ref_id= int.Parse((e.Item.Cells[0].FindControl("lblStgRefID") as Label).Text);

            (e.Item.Cells[1].FindControl("cBoxStgMap") as CheckBox).Checked = (drw["STG_MAP_YN"].ToString()    == "Y") ? true : false;
            (e.Item.Cells[2].FindControl("cBoxF") as CheckBox).Checked      = (drw["F_YN"].ToString()          == "Y") ? true : false;
            (e.Item.Cells[2].FindControl("cBoxC") as CheckBox).Checked      = (drw["C_YN"].ToString()          == "Y") ? true : false;
            (e.Item.Cells[2].FindControl("cBoxP") as CheckBox).Checked      = (drw["P_YN"].ToString()          == "Y") ? true : false;
            (e.Item.Cells[2].FindControl("cBoxL") as CheckBox).Checked      = (drw["L_YN"].ToString()          == "Y") ? true : false;

            foreach (DataRow deptRow in dsDept.Tables[0].Rows)
            {
                CheckBox cBox_YN = e.Item.FindControl("C_" + deptRow["EST_DEPT_REF_ID"].ToString()) as CheckBox;

                if (deptRow["EST_DEPT_REF_ID"].ToString() != txtDeptID.Text)
                    cBox_YN.Enabled = false;


                if (cBox_YN != null)
                {
                    DataRow[] drArr = dsDeptData.Tables[0].Select(string.Format("VER_ID={0} AND ESTTERM_REF_ID={1} AND EST_DEPT_REF_ID={2} AND STG_REF_ID={3}"
                                                                    , PageUtility.GetIntByValueDropDownList(ddlStgVersion)
                                                                    , PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                                                    , int.Parse(deptRow["EST_DEPT_REF_ID"].ToString())
                                                                    , stg_ref_id));

                    if (drArr.Length == 1)
                    {
                        cBox_YN.Checked = (drArr[0]["CHECK_YN"].ToString() == "Y") ? true : false;

                        // 상위부서의 전략이 선택되어지지 않으면 체크박스를 지운다.
                        if (deptRow["EST_DEPT_REF_ID"].ToString() == txtDeptID.Text)
                        {
                            cBox_YN.Visible = isVisible;
                        }
                        else 
                        {
                            if (!cBox_YN.Checked)
                            {
                                cBox_YN.Visible = false;
                                isVisible       = false;
                            }
                        }
                    }
                }

            }

            
        }
    }
    private void SavePDTData() 
    {
        Biz_PDTAndAHPStgEstDeptDatas pDTAndAHPStgEstDeptDatas = new Biz_PDTAndAHPStgEstDeptDatas();

        DataTable stgdData  = new DataTable();
        DataRow dr          = null;
        stgdData.Columns.Add("STG_REF_ID"   , typeof(int));
        stgdData.Columns.Add("UP_STG_ID"    , typeof(int));
        stgdData.Columns.Add("STG_MAP_YN"   , typeof(string));
        stgdData.Columns.Add("F_YN"         , typeof(string));
        stgdData.Columns.Add("C_YN"         , typeof(string));
        stgdData.Columns.Add("P_YN"         , typeof(string));
        stgdData.Columns.Add("L_YN"         , typeof(string));

        /* 2011-08-29 수정 : Grid에서 UltraWebGrid로 변경에 따른 수정 필요
        foreach (DataGridItem item in DataGrid1.Items)
        {
            dr                  = stgdData.NewRow();
            dr["STG_REF_ID"]    = (item.Cells[0].FindControl("lblStgRefID") as Label).Text;
            dr["UP_STG_ID"]     = 0;
            dr["STG_MAP_YN"]    = ((item.Cells[1].FindControl("cBoxStgMap") as CheckBox).Checked) ? "Y":"N";
            dr["F_YN"]          = ((item.Cells[2].FindControl("cBoxF") as CheckBox).Checked)? "Y":"N";
            dr["C_YN"]          = ((item.Cells[2].FindControl("cBoxC") as CheckBox).Checked)? "Y":"N";
            dr["P_YN"]          = ((item.Cells[2].FindControl("cBoxP") as CheckBox).Checked)? "Y":"N";
            dr["L_YN"]          = ((item.Cells[2].FindControl("cBoxL") as CheckBox).Checked)? "Y":"N";
            stgdData.Rows.Add(dr);
        }
        */

        DataTable estDeptData   = new DataTable();
        estDeptData.Columns.Add("EST_DEPT_REF_ID", typeof(int));
        estDeptData.Columns.Add("STG_REF_ID", typeof(int));
        estDeptData.Columns.Add("CHECK_YN", typeof(string));

        DeptInfos deptInfo  = new DeptInfos();

        if (txtDeptID.Text != "") 
        {
            DataSet ds          = deptInfo.GetEstDeptListByLevel(int.Parse(txtDeptID.Text));

            foreach (DataRow deptRow in ds.Tables[0].Rows) 
            {
                /* 2011-08-29 수정 : Grid에서 UltraWebGrid로 변경에 따른 수정 필요
                foreach (DataGridItem item in DataGrid1.Items)
                {
                    CheckBox cBox_YN = item.FindControl("C_" + deptRow["EST_DEPT_REF_ID"].ToString()) as CheckBox;

                    if (cBox_YN != null)
                    {
                        dr                      = estDeptData.NewRow();
                        dr["EST_DEPT_REF_ID"]   = deptRow["EST_DEPT_REF_ID"].ToString();
                        dr["STG_REF_ID"]        = (item.Cells[0].FindControl("lblStgRefID") as Label).Text;
                        dr["CHECK_YN"]          = (cBox_YN.Checked) ? "Y" : "N";
                        dr["CHECK_YN"]          = (!cBox_YN.Visible) ? "N" : dr["CHECK_YN"].ToString();
                        estDeptData.Rows.Add(dr);
                    }
                }
                */
            }
        }
        else 
        {
            
        }

        bool isOK = pDTAndAHPStgEstDeptDatas.AddPDTAndAHPStgEstDeptDatas(PageUtility.GetIntByValueDropDownList(ddlStgVersion)
                                                                        , PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                                                        , stgdData
                                                                        , estDeptData
                                                                        , int.Parse(DeptID)
                                                                        , EMP_REF_ID);

        
        
        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되었습니다.", false);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.", false);
        }
    }
    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        SavePDTData();
    }
}


public class DGridTemplete : System.Web.UI.Page, ITemplate 
{
	private ListItemType _templateType;
	private string _columnName;
    private string _chbName;

    public DGridTemplete(ListItemType type, string colName, string chbName)
	{
		_templateType	= type;
		_columnName		= colName;
        _chbName        = chbName;
	}

    public DGridTemplete(ListItemType type, string chbName)
	{
		_templateType	= type;
        _chbName        = chbName;
	}

	public void InstantiateIn(System.Web.UI.Control container) 
	{
		Literal ltr		= new Literal();
		CheckBox cBox	= new CheckBox();

        switch (_templateType)
		{
			case ListItemType.Header:

                ltr.Text = _columnName;
                container.Controls.Add(ltr);
				break;

			case ListItemType.Item:

                cBox.ID         = _chbName;
                container.Controls.Add(cBox);
				break;

            case ListItemType.AlternatingItem:

                cBox.ID         = _chbName;
                container.Controls.Add(cBox);
                break;
		}
	}
}

