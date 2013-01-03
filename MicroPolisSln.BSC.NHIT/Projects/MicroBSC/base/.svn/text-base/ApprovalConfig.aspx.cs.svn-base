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

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
//using MicroICM.Biz.ADM;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class BASE_ApprovalConfig : AppPageBase
{
    protected SqlConnection _connection;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ibtnDelete.Attributes.Add("onclick", "return confirm('선택하신 항목을 삭제할까요?');");
            this._makeTree();

        }
    }

    public DataSet _getData(string query)
    {
        _connection = new SqlConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
        //_connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bscConnectionString"].ConnectionString;

        SqlDataAdapter ad = new SqlDataAdapter(query, _connection);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        return ds;
    }

    private void _makeTree()
    {
        string query = "SELECT * FROM COM_DEPT_INFO ORDER BY dept_Level, up_Dept_ID";
        DataSet ds = this._getData(query);

        string nodeid = "";
        string p_nodeid = "";
        int deptlevel = 0;

        TreeNode tn;

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            nodeid = dr["dept_ref_id"].ToString();
            p_nodeid = dr["up_dept_id"].ToString();
            deptlevel = int.Parse(dr["dept_Level"].ToString());

            tn = new TreeNode(dr["dept_name"].ToString(), nodeid);

            // 최상위 노드
            if (p_nodeid.Equals("0"))
            {
                this.TreeView1.Nodes.Add(tn);
            }
            else
            {

                if (deptlevel == 2)
                {
                    this.TreeView1.Nodes[0].ChildNodes.Add(tn);
                }
                else if (deptlevel == 3)
                {
                    for (int i = 0; i < this.TreeView1.Nodes[0].ChildNodes.Count; i++)
                    {
                        if (p_nodeid == this.TreeView1.Nodes[0].ChildNodes[i].Value)
                        {
                            this.TreeView1.Nodes[0].ChildNodes[i].ChildNodes.Add(tn);
                        }
                    }
                }
                else if (deptlevel == 4)
                {
                    for (int i = 0; i < this.TreeView1.Nodes[0].ChildNodes.Count; i++)
                    {
                        for (int j = 0; j < this.TreeView1.Nodes[0].ChildNodes[i].ChildNodes.Count; j++)
                        {
                            if (p_nodeid == this.TreeView1.Nodes[0].ChildNodes[i].ChildNodes[j].Value)
                            {
                                this.TreeView1.Nodes[0].ChildNodes[i].ChildNodes[j].ChildNodes.Add(tn);
                            }
                        }
                    }
                }

            }
        }

    }

    private void _getUsers(string deptid)
    {
        string query = "select a.emp_ref_id as empid, a.emp_name as EmpName, b.dept_ref_id as deptid, '' as jobcode, c.dept_name as deptname, '' as jobname from com_emp_info a, rel_dept_emp b, com_dept_info c where a.emp_ref_id =b.emp_ref_id and b.dept_ref_id = c.dept_ref_id and b.dept_ref_id = " + deptid + "";
        DataSet ds = this._getData(query);

        this.UltraWebGrid1.DataSource = ds;
        this.UltraWebGrid1.DataBind();

    }


    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string deptid = this.TreeView1.SelectedNode.Value;
        this._getUsers(deptid);

    }
    protected void ibtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        bool isDupId = false;
        int grid1_rowcnt = this.UltraWebGrid1.Rows.Count;
        int grid2_rowcnt = this.UltraWebGrid2.Rows.Count;

        CheckBox chk;
        Infragistics.WebUI.UltraWebGrid.UltraGridRow row;
        Infragistics.WebUI.UltraWebGrid.TemplatedColumn col;
        
        for (int i = 0; i < grid1_rowcnt; i++)
        {
            row = this.UltraWebGrid1.Rows[i];
            col = (Infragistics.WebUI.UltraWebGrid.TemplatedColumn)row.Band.Columns.FromKey("selchk1");
            chk = (CheckBox)((Infragistics.WebUI.UltraWebGrid.CellItem)col.CellItems[row.BandIndex]).FindControl("selchk1");

            if (chk.Checked)
            {
                // 동일한 사용자가 등록되었는지 확인
                for (int j = 0; j < grid2_rowcnt; j++)
                {
                    if (this.UltraWebGrid2.Rows[j].Cells[5].Value.Equals(row.Cells[4].Value))
                    {
                        isDupId = true;
                        break;
                    }
                }

                // 동일한 사용자가 선택되지 않았다면 결재선 지정에 추가함
                if (!isDupId)
                {
                    // 결재선 그리드 레코드 갯수 하나 추가
                    grid2_rowcnt++;

                    // 결재선 지정 그리드에 추가
                    this.UltraWebGrid2.Rows.Add();
                    // 사용자이름
                    this.UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells[1].Value = grid2_rowcnt;

                    this.UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells[2].Value = row.Cells[1].Value;
                    this.UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells[3].Value = row.Cells[2].Value;
                    this.UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells[4].Value = row.Cells[3].Value;
                    this.UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells[5].Value = row.Cells[4].Value;
                    this.UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells[6].Value = row.Cells[5].Value;
                    this.UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells[7].Value = row.Cells[6].Value;

                    // 선택항목 사용자 제거
                    this.UltraWebGrid1.Rows.Remove(row);
                    // 레코드 갯수 하나 삭제
                    grid1_rowcnt--;
                    // 일련번호 갯수 하나 삭제
                    i--;
                }
            }
        }

    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int chkcnt = 0;
        int grid2_rowcnt = this.UltraWebGrid2.Rows.Count;

        CheckBox chk;
        Infragistics.WebUI.UltraWebGrid.UltraGridRow row;
        Infragistics.WebUI.UltraWebGrid.TemplatedColumn col;

        for (int i = 0; i < grid2_rowcnt; i++)
        {
            row = this.UltraWebGrid2.Rows[i];
            col = (Infragistics.WebUI.UltraWebGrid.TemplatedColumn)row.Band.Columns.FromKey("selchk2");
            chk = (CheckBox)((Infragistics.WebUI.UltraWebGrid.CellItem)col.CellItems[row.BandIndex]).FindControl("selchk2");

            if (chk.Checked)
            {
                chkcnt++;
                // 선택항목 사용자 제거
                this.UltraWebGrid2.Rows.Remove(row);
                // 레코드 갯수 하나 삭제
                grid2_rowcnt--;
                // 일련번호 갯수 하나 삭제
                i--;
            }
        }

        grid2_rowcnt = this.UltraWebGrid2.Rows.Count;
        for (int i = 0; i < grid2_rowcnt; i++)
        {
            row = this.UltraWebGrid2.Rows[i];
            row.Cells[1].Value = i + 1;

        }

        if (chkcnt > 0)
        {
            //this._showMessage(this, "삭제가 완료되었습니다.");
        }
        else
        {
            //this._showMessage(this, "삭제할 항목을 선택해 주세요.");
        }
    }


    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        int result = 0;
        int grid2_rowcnt = this.UltraWebGrid2.Rows.Count;
        Infragistics.WebUI.UltraWebGrid.UltraGridRow row;

        /*
        COM_Approval_lines appline;

        for (int i = 0; i < grid2_rowcnt; i++)
        {
            appline = new COM_Approval_lines();
            row = this.UltraWebGrid2.Rows[i];

            result += appline.AddAPPROVAL_LINE(
                Request["apptype"], // 결재형태
                row.Cells[5].Text,  // 직번
                int.Parse(row.Cells[1].Text), // 순번
                "", // 다음결재자직번
                row.Cells[2].Text,  // 이름
                row.Cells[6].Text,  // 부서코드
                row.Cells[3].Text,  // 부서명
                row.Cells[7].Text,  // 직급코드
                row.Cells[4].Text,  // 직급명
                "", // 역할코드
                "");    // 역할명

            appline = null;
        }
        */
        if (result > 0)
        {
            // 저장 완료
//            this._showMessage(this, "저장이 완료되었습니다.");

            this.Literal1.Text = JSHelper.GetAlertOpenerReflashScript("저장이 완료되었습니다.", true);
        }
        else
        {
            // 저장 실패
            //this._showMessage(this, "저장이 실패하였습니다.");

        }

    }

}
