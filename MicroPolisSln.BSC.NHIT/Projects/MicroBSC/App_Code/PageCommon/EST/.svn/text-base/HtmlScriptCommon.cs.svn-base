using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.BSC.Biz;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

public class HtmlScriptCommon
{
    public static void CreateStatusHtmlTable(Table tbl, string est_id) 
    {
        if (tbl != null && tbl.Rows.Count > 0)
        {
            for (int i = 0; i < tbl.Rows.Count; i++)
                tbl.Rows.RemoveAt(0);
        }

        Biz_Status status   = new Biz_Status();
        DataTable dataTable = status.GetStatusByEstID(est_id).Tables[0];

        tbl.CellPadding     = 0;
        tbl.CellSpacing     = 0;
        tbl.BorderWidth     = 0;

        TableRow tblRow     = new TableRow();

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            TableCell tblCell = new TableCell();
            tblCell.Style.Add("padding-right", "5px");
            tblCell.Text    = string.Format("<img src='{0}' alt='{1}' /> {2} ", dataRow["STATUS_IMG_PATH"], dataRow["STATUS_DESC"], dataRow["STATUS_NAME"]);
            tblRow.Cells.Add(tblCell);
        }

        tbl.Rows.Add(tblRow);
    }
}
