using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.PRJ.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.PRJ.Biz
{
    public class Biz_Prj_Question_Prj_Map
    {
        Dac_Prj_Question_Prj_Map _data;

        public Biz_Prj_Question_Prj_Map()
        {
            _data = new Dac_Prj_Question_Prj_Map();
        }



        public int Remove_Question_Prj_Map_Data(IDbConnection conn, IDbTransaction trx
                                                , int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id
                                                , int prj_ref_id)
        {
            int affectedRow = _data.Delete_DB(conn, trx
                                         , comp_id
                                         , est_id
                                         , estterm_ref_id
                                         , estterm_sub_id
                                         , estterm_step_id
                                         , prj_ref_id);
            return affectedRow;
        }


        public int Remove_Question_Prj_Map_Data(IDbConnection conn, IDbTransaction trx
                                                , int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id
                                                , string prj_ref_id_list)
        {
            int affectedRow = _data.Delete_DB_Bulk(conn, trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , prj_ref_id_list);
            return affectedRow;
        }
    }
}