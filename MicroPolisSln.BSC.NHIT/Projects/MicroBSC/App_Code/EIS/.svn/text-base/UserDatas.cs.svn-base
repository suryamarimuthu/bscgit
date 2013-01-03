using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MicroBSC.Biz.EIS
{
    public class UserDatas
    {
        public DataTable GetArea() 
        {
            DataTable dt    = new DataTable();
            DataRow dr;
            dt.Columns.Add("KEY", typeof(string));
            dt.Columns.Add("VALUE", typeof(string));
            //dr = dt.NewRow();
            //dr["KEY"] = "--";
            //dr["VALUE"] = "전체";
            //dt.Rows.Add(dr);
            dr              = dt.NewRow();
            dr["KEY"]       = "01";
            dr["VALUE"]     = "울산";
            dt.Rows.Add(dr);

            dr              = dt.NewRow();
            dr["KEY"]       = "02";
            dr["VALUE"]     = "양산";
            dt.Rows.Add(dr);
            return dt;
        }
        public DataTable GetYear()
        {
            DataTable dt    = new DataTable();
            DataRow dr;
            dt.Columns.Add("KEY", typeof(string));
            dt.Columns.Add("VALUE", typeof(string));

            for (int i = 2001; i <= System.DateTime.Now.Year; i++) 
            {
                dr = dt.NewRow();
                dr["KEY"]   = i.ToString();
                dr["VALUE"] = i.ToString();
                dt.Rows.Add(dr);
            }

            return dt;
        }
        public DataTable GetMonth()
        {
            DataTable dt    = new DataTable();
            DataRow dr;
            dt.Columns.Add("KEY", typeof(string));
            dt.Columns.Add("VALUE", typeof(string));

            for (int i = 1; i <= 12; i++)
            {
                dr = dt.NewRow();
                dr["KEY"]   = i.ToString().PadLeft(2, '0');
                dr["VALUE"] = i.ToString().PadLeft(2, '0');
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
