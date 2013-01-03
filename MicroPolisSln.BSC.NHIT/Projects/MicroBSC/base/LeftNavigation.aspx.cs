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

using System.Collections.Generic;
using System.Text;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.BSC;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;
using System.Threading;


public partial class base_LeftNavigation : AppPageBase
{
    protected DataSet dsMenu;
    protected DataSet dsSearchMenu;
    private const int PRODUCT_SPACING = 5;
    Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
    StaticDsMenu dm = new StaticDsMenu();


    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            wb.Groups.Clear();

            //dsSearchMenu    = biz.GetAuthReadSearchMenu(gUserInfo.Emp_Ref_ID.ToString(), SearchCombo.ToString());
            dsMenu = StaticDsMenu.GetData(gUserInfo.Emp_Ref_ID.ToString());

            if (!dsMenu.Relations.Contains("MenuRelation"))
            {
                dsMenu.Relations.Add("MenuRelation", dsMenu.Tables[0].Columns["MENU_REF_ID"], dsMenu.Tables[0].Columns["UP_MENU_ID"], false);
            }

            foreach (DataRow drMenus in dsMenu.Tables[0].Rows)
            {
                if (drMenus.IsNull("UP_MENU_ID"))
                {
                    string strmenu = drMenus["MENU_REF_ID"].ToString();
                    wb.Groups.Add(Convert.ToString(drMenus["MENU_NAME"]), Convert.ToString(drMenus["MENU_REF_ID"]));

                    GetSubMenuAdd(drMenus);
                }
            }
            this.ClearItemKeys();
        }
    }

    private void GetSubMenuAdd(DataRow drMenu)
    {
        foreach (DataRow childRow in drMenu.GetChildRows("MenuRelation"))
        {
            this.GetMenuAdd(childRow);
            GetSubMenuAdd(childRow);
        }
    }

    private void GetMenuAdd(DataRow drMenu)
    {
        int MENU_REF_ID = 0;
        int UP_MENU_ID = 0;
        int ROOT_MENU_ID = 0;
        string Menu_Name = Convert.ToString(drMenu["Menu_Name"]);
        if (drMenu["MENU_REF_ID"] != DBNull.Value) MENU_REF_ID = (int)(drMenu["MENU_REF_ID"]);
        if (drMenu["UP_MENU_ID"] != DBNull.Value) UP_MENU_ID = (int)(drMenu["UP_MENU_ID"]);
        if (drMenu["UP_MENU_ID"] != DBNull.Value) ROOT_MENU_ID = (int)(drMenu["UP_MENU_ID"]);

        DataRow drRootParent = drMenu;

        if (drRootParent.GetParentRow("MenuRelation") != null)
            drRootParent = drRootParent.GetParentRow("MenuRelation");
        if (drRootParent["UP_MENU_ID"] != DBNull.Value)
            ROOT_MENU_ID = Convert.ToInt32(drRootParent["UP_MENU_ID"]);

        Infragistics.WebUI.UltraWebListbar.Group ownerGroup = wb.Groups.FromKey(ROOT_MENU_ID.ToString());

        try
        {
            if (ownerGroup != null)
            {
                Menu_Name = Convert.ToString(drMenu["Menu_Name"]);
                string theRunningSampleURL = Convert.ToString(drMenu["MENU_FULL_PATH"]);

                ItemEX ownerItem = ownerGroup.Items.FromKey(UP_MENU_ID.ToString()) as ItemEX;

                if (ownerItem != null)
                {
                    ItemEX theListBarItem;

                    theListBarItem = new ItemEX();
                    theListBarItem.Text = Menu_Name;
                    theListBarItem.Tag = theRunningSampleURL;
                    theListBarItem.Key = theRunningSampleURL;
                    theListBarItem.TargetUrl = theRunningSampleURL;
                    theListBarItem.TargetFrame = "frMain";
                    theListBarItem.Align = "left";
                    theListBarItem.DefaultStyle.Padding.Left = 15;
                    ownerGroup.DefaultItemStyle.Cursor = Infragistics.WebUI.Shared.Cursors.Hand;
                    ownerGroup.DefaultItemHoverStyle.BorderStyle = BorderStyle.None;
                    ownerItem.AddChild(theListBarItem);
                }
                else
                {
                    ItemEX theListBarItem;

                    theListBarItem = new ItemEX();
                    theListBarItem.Text = Menu_Name;
                    theListBarItem.Key = MENU_REF_ID.ToString();//theSampleDescription;
                    theListBarItem.Align = "left";
                    theListBarItem.DefaultStyle.Font.Bold = true;
                    theListBarItem.DefaultStyle.Padding.Top = Unit.Pixel(PRODUCT_SPACING);
                    ownerGroup.Items.Add(theListBarItem);
                }
            }
        }
        catch (NullReferenceException e) { }
    }

    private void ClearItemKeys()
    {
        foreach (Infragistics.WebUI.UltraWebListbar.Group g in wb.Groups)
        {
            g.Key = string.Empty;
            foreach (Infragistics.WebUI.UltraWebListbar.Item i in g.Items)
            {
                i.Key = string.Empty;
            }
        }
    }

    #region // Menu Search
    //void SearchCombo_InitializeDataSource(object sender, Infragistics.WebUI.WebCombo.WebComboEventArgs e)
    //{
    //    this.SearchCombo.DataSource         = dsSearchMenu.Tables[0];
    //    this.SearchCombo.DataTextField      = "MENU_NAME";
    //    this.SearchCombo.DataValueField     = "MENU_NAME";
    //}

    //void SearchCombo_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    //{
    //    // This needs to be refactored and optomized
    //    int MENU_REF_ID = (int)e.Row.Cells.FromKey("MENU_REF_ID").Value;

    //    DataRow drMenus = this.dsSearchMenu.Tables[0].Select("MENU_REF_ID=" + MENU_REF_ID)[0];
    //    if (drMenus == null) return;

    //    string theRunningSampleURL = Convert.ToString(drMenus["MENU_FULL_PATH"]);

    //    e.Row.Cells.FromKey("Menu_Name").TargetURL = theRunningSampleURL;
    //}

    //void SearchCombo_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    //{
    //    Infragistics.WebUI.UltraWebGrid.UltraGridColumn col = null;

    //    col = this.SearchCombo.Columns.FromKey("MENU_REF_ID");
    //    if (col != null)
    //    {
    //        col.ServerOnly = true;
    //    }
    //    col = this.SearchCombo.Columns.FromKey("UP_MENU_ID");
    //    if (col != null)
    //    {
    //        col.ServerOnly = true;
    //    }
    //    //col = this.SearchCombo.Columns.FromKey("MENU_NAME");
    //    //if (col != null)
    //    //{
    //    //    col.ServerOnly = true;
    //    //}
    //    col = this.SearchCombo.Columns.FromKey("SearchMenu");
    //    if (col != null)
    //    {
    //        col.ServerOnly = true;
    //    }
    //    col = this.SearchCombo.Columns.FromKey("MENU_FULL_PATH");
    //    if (col != null)
    //    {
    //        col.ServerOnly = true;
    //    }
    //    col = this.SearchCombo.Columns.FromKey("MENU_NAME");
    //    if (col != null)
    //    {
    //        col.Type = Infragistics.WebUI.UltraWebGrid.ColumnType.HyperLink;
    //    }
    //}

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //this.SearchCombo.InitializeDataSource += new Infragistics.WebUI.WebCombo.InitializeDataSourceEventHandler(SearchCombo_InitializeDataSource);
        //this.SearchCombo.InitializeLayout += new Infragistics.WebUI.WebCombo.InitializeLayoutEventHandler(SearchCombo_InitializeLayout);
        //this.SearchCombo.InitializeRow += new Infragistics.WebUI.WebCombo.InitializeRowEventHandler(SearchCombo_InitializeRow);
        base.OnInit(e);
    }
    #endregion
    #endregion
}


public class ItemEX : Infragistics.WebUI.UltraWebListbar.Item
{
    private ItemEX parentItem = null;

    public ItemEX()
        : base()
    {
    }
    public ItemEX ParentItem
    {
        get { return this.parentItem; }
        set { this.parentItem = value; }
    }
    public int Level
    {
        get
        {
            int level = 0;
            ItemEX parent = this.ParentItem;
            while (parent != null)
            {
                parent = parent.ParentItem;
                level++;
            }
            return level;
        }
    }
    public void AddChild(ItemEX item)
    {
        if (this.PrimaryCollection as Infragistics.WebUI.UltraWebListbar.Items != null)
        {
            Infragistics.WebUI.UltraWebListbar.Items items = ((Infragistics.WebUI.UltraWebListbar.Items)this.PrimaryCollection);
            int offset = 0;
            for (int i = this.Index; i < items.Count; i++)
            {
                if (((ItemEX)items[i]).ParentItem == this) offset++;
            }
            items.Insert(this.Index + offset + 1, item);
        }
    }
}
