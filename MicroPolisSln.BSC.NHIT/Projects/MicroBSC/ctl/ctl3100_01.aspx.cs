﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MicroBSC.Data;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Common;
using MicroBSC.Estimation.Biz;



public partial class ctl_ctl3100_01 : AppPageBase
{
    // Control for Call Back
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    private int ROLE_REF_ID;


    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            iBtnDelete.Attributes.Add("onclick", "return confirm('선택된 메뉴를 정말 삭제하시겠습니까?');");


            iBtnAdd.Attributes.Add("onclick", "return Valid();");
            iBtnAdd.Style.Add("vertical-align", "middle");
            iBtnRemove.Style.Add("vertical-align", "middle");
            ddlRoles.Style.Add("vertical-align", "middle");
            GridBindginMenu();
            WebCommon.SetRoleDropDownList(ddlRoles, 0);

            //UltraWebGrid1.Columns[7]..Style.Padding.Bottom = new Unit(100);
            
        }

        ROLE_REF_ID = DataTypeUtility.GetToInt32( ddlRoles.SelectedValue);
        lblScript.Text = "";
    }

    #region 내부함수
        private void GridBindginMenu()
        {
            //MenuInfos menu = new MenuInfos();
            //UltraWebGrid1.DataSource = menu.GetMenuInfo();
            //UltraWebGrid1.DataBind();

            UltraWebGrid1.DataSource = GetGridTable();
            UltraWebGrid1.DataBind();
        }

        private DataTable GetGridTable()
        {
            Biz_ctl_ctl3100 biz = new Biz_ctl_ctl3100();

            DataTable dtTmp;
            DataTable dtRet = new DataTable();
            DataRow drNew;

            dtRet.Columns.Add("MENU_REF_ID", typeof(int));
            dtRet.Columns.Add("UP_MENU_ID", typeof(int));
            dtRet.Columns.Add("MENU_NAME", typeof(string));
            dtRet.Columns.Add("MENU_DIR", typeof(string));
            dtRet.Columns.Add("MENU_PAGE_NAME", typeof(string));
            dtRet.Columns.Add("MENU_PARAM", typeof(string));
            dtRet.Columns.Add("MENU_FULL_PATH", typeof(string));
            dtRet.Columns.Add("MENU_DESC", typeof(string));
            dtRet.Columns.Add("MENU_PRIORITY", typeof(int));
            dtRet.Columns.Add("MENU_TYPE", typeof(string));
            dtRet.Columns.Add("MENU_NAME_IMAGE_PATH", typeof(string));
            dtRet.Columns.Add("MENU_PREV_ICON_PATH", typeof(string));
            dtRet.Columns.Add("MENU_CREATE_DATE", typeof(DateTime));

            DataSet dsMenu = biz.GetMenuInfo();
            dsMenu.Relations.Add("MENURELATION", dsMenu.Tables[0].Columns["MENU_REF_ID"], dsMenu.Tables[0].Columns["UP_MENU_ID"], false);

            foreach (DataRow drRow in dsMenu.Tables[0].Rows)
            {
                
                //int up_menu_id = DataTypeUtility.GetToInt32(drRow["UP_MENU_ID"]);

                

                
                if (drRow.IsNull("UP_MENU_ID") || drRow["UP_MENU_ID"].ToString().Equals("0"))
                //if (up_menu_id.Equals(0))
                {
                    drNew = dtRet.NewRow();

                    drNew["MENU_REF_ID"]    = Convert.ToInt32(drRow["MENU_REF_ID"]);

                    drNew["MENU_NAME"] = "<img src='../images/treeview/folders.gif' border=0  align=absmiddle> " + "<b>" + drRow["MENU_NAME"].ToString() + "</b>";
                    drNew["MENU_DIR"]       = drRow["MENU_DIR"].ToString();
                    drNew["MENU_PAGE_NAME"] = drRow["MENU_PAGE_NAME"].ToString();
                    drNew["MENU_PARAM"]     = drRow["MENU_PARAM"].ToString();
                    drNew["MENU_FULL_PATH"] = drRow["MENU_FULL_PATH"].ToString();
                    drNew["MENU_DESC"]      = drRow["MENU_DESC"].ToString();
                    drNew["MENU_PRIORITY"]  = Convert.ToInt32(drRow["MENU_PRIORITY"]);
                    drNew["MENU_TYPE"]      = drRow["MENU_TYPE"].ToString();
                    
                    drNew["MENU_NAME_IMAGE_PATH"]   = drRow["MENU_NAME_IMAGE_PATH"].ToString();
                    drNew["MENU_PREV_ICON_PATH"]    = drRow["MENU_PREV_ICON_PATH"].ToString();
                    drNew["MENU_CREATE_DATE"]       = Convert.ToDateTime(drRow["MENU_CREATE_DATE"]);

                    dtRet.Rows.Add(drNew);

                    SetRecursiveMenu(drRow, ref dtRet,4);
                }
            }

            lblRowCnt.Text = dtRet.Rows.Count.ToString();
            return dtRet;
        }

        private void SetRecursiveMenu(DataRow drRow, ref DataTable dtRef,int idepth)
        {
            string sp = "";
            string iconname="";
            foreach (DataRow childRow in drRow.GetChildRows("MENURELATION"))
            {
                DataRow drNew = dtRef.NewRow();
                if (childRow["MENU_PAGE_NAME"].ToString().Trim().Length > 0)
                    iconname = "<img src='../images/treeview/notes.gif' border=0  align=absmiddle> ";
                else
                    iconname = "<img src='../images/treeview/folder.gif' border=0  align=absmiddle> ";

                drNew["MENU_REF_ID"] = Convert.ToInt32(childRow["MENU_REF_ID"]);
                drNew["UP_MENU_ID"]     = Convert.ToInt32(childRow["UP_MENU_ID"]);
                drNew["MENU_NAME"] = sp.PadLeft(idepth, ' ') + iconname + childRow["MENU_NAME"].ToString();
                drNew["MENU_DIR"]       = childRow["MENU_DIR"].ToString();
                drNew["MENU_PAGE_NAME"] = childRow["MENU_PAGE_NAME"].ToString();
                drNew["MENU_PARAM"]     = childRow["MENU_PARAM"].ToString();
                drNew["MENU_FULL_PATH"] = childRow["MENU_FULL_PATH"].ToString();
                drNew["MENU_DESC"]      = childRow["MENU_DESC"].ToString();
                drNew["MENU_PRIORITY"]  = Convert.ToInt32(childRow["MENU_PRIORITY"]);
                drNew["MENU_TYPE"]      = childRow["MENU_TYPE"].ToString();

                drNew["MENU_NAME_IMAGE_PATH"]   = childRow["MENU_NAME_IMAGE_PATH"].ToString();
                drNew["MENU_PREV_ICON_PATH"]    = childRow["MENU_PREV_ICON_PATH"].ToString();
                drNew["MENU_CREATE_DATE"]       = Convert.ToDateTime(childRow["MENU_CREATE_DATE"]);

                dtRef.Rows.Add(drNew);

                SetRecursiveMenu(childRow, ref dtRef, idepth + 3);
            }
        }

        private string GetMenuTypeName(string menuType)
        {
            if (menuType.Equals("T"))
            {
                return "메뉴 폴더";
            }
            else if (menuType.Equals("M"))
            {
                return "메뉴 페이지 그룹";
            }
            else if (menuType.Equals("S"))
            {
                return "메뉴 페이지";
            }
            else if (menuType.Equals("N"))
            {
                return "메뉴 없는 페이지";
            }

            return "없는 메뉴 형태임";
        }
        private void DataBindingMenuRole(int menu_ref_id)
        {
            RoleInfos role = new RoleInfos();
            //UltraWebGrid2.DataSource = role.GetMenuRoles(menu_ref_id);
            //UltraWebGrid2.DataBind();
        }

        private void CheckMenuRoleCount()
        {
            if (ddlRoles.Items.Count == 0)
            {
                ddlRoles.Visible = false;
                iBtnAdd.Visible = false;
            }
            else
            {
                ddlRoles.Visible = true;
                iBtnAdd.Visible = true;
            }
        }
    #endregion

    #region 서버 이벤트 처리 함수
        protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
        {

            Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

            DataTable dataTable = objMenuInfo.GetDataTableSchema();

            dataTable = UltraGridUtility.GetDataTableByCheckValue(this.UltraWebGrid1
                                                                , "cBox"
                                                                , "selchk"
                                                                , new string[] { "MENU_REF_ID", "UP_MENU_ID", "MENU_NAME", "MENU_DIR", "MENU_PAGE_NAME", "MENU_PARAM", "MENU_FULL_PATH"
                                                                , "MENU_DESC", "MENU_PRIORITY", "MENU_AUTH_TYPE", "MENU_TYPE", "MENU_NAME_IMAGE_PATH", "MENU_NAME_IMAGE_PATH_U"
                                                                , "MENU_PREV_ICON_PATH", "MENU_CREATE_DATE", "SHOW_LEFT_MENU" }
                                                                , dataTable);

            MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common bizCustom = new MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common();

            int okCnt = bizCustom.AddMenuRole(dataTable, ddlRoles.SelectedValue);

            //RoleInfos role = new RoleInfos();

            //role.RemoveRoleMenu();

            //role.AddRoleMenu(int.Parse(ddlRoles.SelectedValue), int.Parse(hdfMenu_Ref_ID.Value));
            //WebCommon.SetRoleDropDownList(ddlRoles, int.Parse(hdfMenu_Ref_ID.Value));
            //DataBindingMenuRole(int.Parse(hdfMenu_Ref_ID.Value));
            CheckMenuRoleCount();
            GridBindginMenu();

            //Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

            //DataTable blankDataTable = new DataTable();
            //blankDataTable.Columns.Add("ROLE_REF_ID", typeof(string));
            //blankDataTable.Columns.Add("MENU_REF_ID", typeof(string));

            ////dataTable = UltraGridUtility.GetDataTableByCheckValue(this.UltraWebGrid1
            ////                                                    , "cBox"
            ////                                                    , "selchk"
            ////                                                    , new string[] { "MENU_REF_ID", "UP_MENU_ID", "MENU_NAME", "MENU_DIR", "MENU_PAGE_NAME", "MENU_PARAM", "MENU_FULL_PATH"
            ////                                                    , "MENU_DESC", "MENU_PRIORITY", "MENU_AUTH_TYPE", "MENU_TYPE", "MENU_NAME_IMAGE_PATH", "MENU_NAME_IMAGE_PATH_U"
            ////                                                    , "MENU_PREV_ICON_PATH", "MENU_CREATE_DATE", "SHOW_LEFT_MENU","MENU_ROLE" }
            ////                                                    , dataTable);

            //foreach (UltraGridRow ugRow in UltraWebGrid1.Rows)
            //{
            //    TemplatedColumn col_cBox = (TemplatedColumn)ugRow.Band.Columns.FromKey("selchk");
            //    CheckBox cBox = (CheckBox)((CellItem)col_cBox.CellItems[ugRow.BandIndex]).FindControl("cBox");

            //    if (cBox.Checked)
            //    {
            //        DataRow dataRow = blankDataTable.NewRow();

            //        TemplatedColumn col_ddl = (TemplatedColumn)ugRow.Band.Columns.FromKey("MENU_ROLE");
            //        DropDownList colDDL = (DropDownList)((CellItem)col_ddl.CellItems[ugRow.BandIndex]).FindControl("ddlMenuRole");

            //        dataRow["ROLE_REF_ID"] = colDDL.SelectedValue;

            //        dataRow["MENU_REF_ID"] = ugRow.Cells.FromKey("MENU_REF_ID").Value;


            //        blankDataTable.Rows.Add(dataRow);
            //    }

            //}

            //object a = this.UltraWebGrid1.Rows[1].Cells.FromKey("MENU_ROLE").Value;

            //Biz_DongbuMetal_Custom bizCustom = new Biz_DongbuMetal_Custom();

            //int okCnt = bizCustom.AddMenuRole(blankDataTable, ddlRoles.SelectedValue);

            ////RoleInfos role = new RoleInfos();

            ////role.RemoveRoleMenu();

            ////role.AddRoleMenu(int.Parse(ddlRoles.SelectedValue), int.Parse(hdfMenu_Ref_ID.Value));
            ////WebCommon.SetRoleDropDownList(ddlRoles, int.Parse(hdfMenu_Ref_ID.Value));
            ////DataBindingMenuRole(int.Parse(hdfMenu_Ref_ID.Value));
            //CheckMenuRoleCount();
        }

        protected void iBtnRemove_Click(object sender, ImageClickEventArgs e)
        {

            Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

            DataTable dataTable = objMenuInfo.GetDataTableSchema();

            dataTable = UltraGridUtility.GetDataTableByCheckValue(
                        this.UltraWebGrid1
                        , "cBox"
                        , "selchk"
                        , new string[] { "MENU_REF_ID", "UP_MENU_ID", "MENU_NAME", "MENU_DIR"
                                        , "MENU_PAGE_NAME", "MENU_PARAM", "MENU_FULL_PATH"
                                        , "MENU_DESC", "MENU_PRIORITY", "MENU_AUTH_TYPE", "MENU_TYPE"
                                        , "MENU_NAME_IMAGE_PATH", "MENU_NAME_IMAGE_PATH_U"
                                        , "MENU_PREV_ICON_PATH", "MENU_CREATE_DATE", "SHOW_LEFT_MENU" }
                        , dataTable);

            RoleInfos role = new RoleInfos();

            foreach (DataRow row in dataTable.Rows)
            {
                int menu_ref_id = DataTypeUtility.GetToInt32(row["MENU_REF_ID"]);
                role.RemoveRoleMenu(ROLE_REF_ID, menu_ref_id);
            }

            GridBindginMenu();

            //RoleInfos role = new RoleInfos();

            //CheckBox chk;
            //UltraGridRow row;
            //TemplatedColumn col;
            //bool isOK = false;
            //int edidx = 0;

            //for (int i = 0; i < this.UltraWebGrid2.Rows.Count; i++)
            //{
            //    row = UltraWebGrid2.Rows[i];
            //    col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            //    chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            //    if (chk.Checked)
            //    {
            //        try
            //        {
            //            isOK = role.RemoveRoleMenu(int.Parse(row.Cells.FromKey("ROLE_REF_ID").Value.ToString()), int.Parse(hdfMenu_Ref_ID.Value));
            //        }
            //        catch (Exception ex)
            //        {
            //            lblScript.Text = JSHelper.GetAlertScript("삭제 중 오류가 발생하였습니다..", false);
            //            return;
            //        }
            //    }
            //}

            //if (!isOK)
            //    lblScript.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
            //else
            //{
            //    WebCommon.SetRoleDropDownList(ddlRoles, int.Parse(hdfMenu_Ref_ID.Value));
            //    DataBindingMenuRole(int.Parse(hdfMenu_Ref_ID.Value));
            //    CheckMenuRoleCount();
            //}
        }

        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Data;

            int menu_ref_id = DataTypeUtility.GetToInt32(dr["MENU_REF_ID"]);

            e.Row.Cells.FromKey("MENU_TYPE_NAME").Value = GetMenuTypeName(dr["MENU_TYPE"].ToString());

            e.Row.Cells.FromKey("MENU_UPDATE").Value = string.Format("<a href=\"#null\" onclick=\"OpenMenuInfoWindow('{0}','{1}');\"><img src='../images/drafts.gif' border='0'></a>"
                                                                                        , "U"
                                                                                        , menu_ref_id.ToString());

            TemplatedColumn tempRole = (TemplatedColumn)e.Row.Band.Columns.FromKey("MENU_ROLE");
            DropDownList ddlColRole = (DropDownList)((CellItem)tempRole.CellItems[e.Row.BandIndex]).FindControl("ddlMenuRole");


            RoleInfos role = new RoleInfos();
            DataSet ds = role.GetMenuRoles(menu_ref_id);

            ddlColRole.Items.Clear();

            ddlColRole.DataSource = ds;
            ddlColRole.DataTextField = "ROLE_NAME";
            ddlColRole.DataValueField = "ROLE_REF_ID";
            ddlColRole.DataBind();

            int ddlCnt = ds.Tables[0].Rows.Count;
            if (ddlCnt > 0)
                ddlColRole.SelectedIndex = ddlCnt - 1;

            
            //if (e.Row.Index < 10)
            //{
            //    // e.Row.Cells.FromKey("MENU_ROLE").Column.ValueList

            //    //e.Row.Cells.FromKey("MENU_ROLE").Column.ValueList.Style.Padding.Top = new Unit(30);

            //    ddlColRole.Items.Clear();



            //    ddlColRole.Items.Add("시스템관리자 권한");
            //}
            //else
            //{
            //    //e.Row.Cells.FromKey("MENU_ROLE").Column.ValueList.Style.Padding.Top = new Unit(30);

            //    ddlColRole.Items.Clear();

            //    ddlColRole.Items.Add("3");
            //    ddlColRole.Items.Add("4");
            //}

            e.Row.Cells.FromKey("MENU_ROLE").Style.Padding.Top = new Unit(0);

        }

        protected void UltraWebGrid2_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {

        }

        protected void UltraWebGrid1_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
        {
            //tblRole.Visible = true;
            int menu_ref_id = int.Parse(e.SelectedRows[0].Cells.FromKey("MENU_REF_ID").Value.ToString());
            hdfMenu_Ref_ID.Value = menu_ref_id.ToString();
            DataBindingMenuRole(menu_ref_id);
            WebCommon.SetRoleDropDownList(ddlRoles, menu_ref_id);
            CheckMenuRoleCount();
        }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        GridBindginMenu();

        //this.UltraWebGrid2.Clear();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

        DataTable dataTable = objMenuInfo.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(this.UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "MENU_REF_ID", "UP_MENU_ID", "MENU_NAME", "MENU_DIR", "MENU_PAGE_NAME", "MENU_PARAM", "MENU_FULL_PATH"
                                                                , "MENU_DESC", "MENU_PRIORITY", "MENU_AUTH_TYPE", "MENU_TYPE", "MENU_NAME_IMAGE_PATH", "MENU_NAME_IMAGE_PATH_U"
                                                                , "MENU_PREV_ICON_PATH", "MENU_CREATE_DATE", "SHOW_LEFT_MENU" }
                                                            , dataTable);

        bool isOK = objMenuInfo.RemoveMenuinfo(dataTable);

        if (!isOK)
        {
            lblScript.Text = JSHelper.GetAlertScript("삭제할 메뉴를 체크해주세요.", false);
        }
        else
        {
            lblScript.Text = JSHelper.GetAlertScript("메뉴를 삭제하였습니다.", false);

            GridBindginMenu();
        }
    }
    #endregion
   
}


