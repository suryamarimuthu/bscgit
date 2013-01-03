using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.EST.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Biz
{
    public class Biz_Est_Pos_Weight
    {
        Dac_Est_Pos_Weight _data;

        public Biz_Est_Pos_Weight()
	    {
            _data = new Dac_Est_Pos_Weight();
	    }

        public DataTable Get_Est_Pos_Weight_Tbl_Scheme()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("COMP_ID");
            dt.Columns.Add("ESTTERM_REF_ID");
            dt.Columns.Add("EST_ID");
            dt.Columns.Add("SEQ");
            dt.Columns.Add("POS_ID");
            dt.Columns.Add("POS_VALUE");
            dt.Columns.Add("DEPT_TYPE_REF_ID");
            dt.Columns.Add("WEIGHT");

            return dt.Clone();
        }


        public DataTable Get_Est_Pos_Weight(int comp_id
                                            , int estterm_ref_id
                                            , string est_id
                                            , int seq
                                            , string pos_id
                                            , string pos_value
                                            , int dept_type_ref_id)
        {
            DataTable dt = _data.Select_DB(comp_id
                                        , estterm_ref_id
                                        , est_id
                                        , seq
                                        , pos_id
                                        , pos_value
                                        , dept_type_ref_id);

            return dt;
        }


        /// <summary>
        /// 부서별 포지션에 따른 가중치
        /// </summary>
        /// <param name="dept_type_ref_id_list">", "로 구분된 리스트</param>
        public DataTable Get_Est_Pos_Weight(string pos_id
                                            , string pos_table_name
                                            , string dept_type_ref_id_list
                                            , int comp_id
                                            , int estterm_ref_id
                                            , string est_id)
        {
            DataTable dt = _data.Select_Est_Pos_Weight(pos_id
                                                    , pos_table_name
                                                    , dept_type_ref_id_list
                                                    , comp_id
                                                    , estterm_ref_id
                                                    , est_id);

            return dt;
        }


        /// <summary>
        /// 해당 POS_ID의 데이터 삭제 후 인서트
        /// </summary>
        /// <param name="dt_est_pos_weight">COLUMNS : POS_ID, POS_VALUE, DEPT_TYPE_REF_ID, WEIGHT</param>
        public int Add_Est_Pos_Weight(int comp_id
                                    , int estterm_ref_id
                                    , string est_id
                                    , DataTable dt_est_pos_weight
                                    , string pos_id
                                    , int create_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();
            
            try
            {
                _data.Delete_DB(conn
                                , trx
                                , comp_id
                                , estterm_ref_id
                                , est_id
                                , pos_id
                                , ""
                                , 0);

                for (int i = 0; i < dt_est_pos_weight.Rows.Count; i++)
                {
                    affectedRow += _data.Insert_DB(conn
                                                , trx
                                                , comp_id
                                                , estterm_ref_id
                                                , est_id
                                                , i + 1
                                                , DataTypeUtility.GetString(dt_est_pos_weight.Rows[i]["POS_ID"])
                                                , DataTypeUtility.GetString(dt_est_pos_weight.Rows[i]["POS_VALUE"])
                                                , DataTypeUtility.GetToInt32(dt_est_pos_weight.Rows[i]["DEPT_TYPE_REF_ID"])
                                                , DataTypeUtility.GetToInt32(dt_est_pos_weight.Rows[i]["WEIGHT"])
                                                , create_user_ref_id);
                }
                
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                affectedRow = 0;
            }
            finally
            {
                conn.Close();
            }

            return affectedRow;
        }

    }
}