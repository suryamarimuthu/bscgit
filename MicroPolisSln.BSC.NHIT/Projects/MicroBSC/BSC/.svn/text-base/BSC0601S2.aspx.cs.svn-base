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

using MicroBSC.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0601S2 : AppPageBase
{
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
                ViewState["CCB1"] = this.lBtnReload.ClientID.Replace('_', '$');
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string IObjKey
    {
        get
        {
            if (ViewState["OBJ_KEY"] == null)
            {
                ViewState["OBJ_KEY"] = GetRequest("OBJ_KEY", "");
            }

            return (string)ViewState["OBJ_KEY"];
        }
        set
        {
            ViewState["OBJ_KEY"] = value;
        }
    }

    public string IObjVal
    {
        get
        {
            if (ViewState["OBJ_VAL"] == null)
            {
                ViewState["OBJ_VAL"] = GetRequest("OBJ_VAL", "");
            }

            return (string)ViewState["OBJ_VAL"];
        }
        set
        {
            ViewState["OBJ_VAL"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.InitForm();
            this.SetDicodeGrid();
        }
    }

    public void InitForm()
    {
        if (this.IType == "P")
        {
            base.SetMenuControl(false, false, false);
            
            pnlPTitle.Visible = true;
            pnlPTitle2.Visible = true;
            
            iBtnInsert.Visible = false;
            lblPopUpTitle.Text = "DICode 검색";
        }
        else
        {
            pnlPTitle.Visible = false;
            pnlPTitle2.Visible = false;
            popContent.Style.Add("padding", "0px");
            
            iBtnInsert.Visible = true;
        }
    }

    /// <summary>
    /// DICode 리스트 조회
    /// </summary>
    public void SetDicodeGrid()
    {
        Biz_Bsc_Interface_Dicode objBSC = new Biz_Bsc_Interface_Dicode();
        objBSC.IDicode       = txtsCode.Text;
        objBSC.IName         = txtsName.Text;
        objBSC.ICreate_User  = gUserInfo.Emp_Ref_ID;
        DataSet dsDicdoe     = objBSC.GetAllList(objBSC.IDicode, objBSC.IName, objBSC.ICreate_User);

        ugrdDicode.Clear();
        ugrdDicode.DataSource = dsDicdoe;
        ugrdDicode.DataBind();
    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetDicodeGrid();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetDicodeGrid();
    }
    protected void ugrdDicode_InitializeLayout(object sender, LayoutEventArgs e)
    {
        if (this.IType == "P")
        {
            e.Layout.Bands[0].Columns.FromKey("SELECT").Hidden = false;
        }
        else
        {
            e.Layout.Bands[0].Columns.FromKey("SELECT").Hidden = true;
        }
    }


    protected void ugrdDicode_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn colSel = (TemplatedColumn)e.Row.Band.Columns.FromKey("SELECT");
        ImageButton iBtnSel    = (ImageButton)((CellItem)colSel.CellItems[e.Row.BandIndex]).FindControl("ibtnSel");

        string sCode = e.Row.Cells.FromKey("DICODE").Value.ToString();
        string sName = e.Row.Cells.FromKey("NAME").Value.ToString();

        string sFunc = String.Format("return SetDicode('{0}','{1}');", sCode, sName);
        iBtnSel.Attributes.Add("onclick", sFunc);
    }
}
