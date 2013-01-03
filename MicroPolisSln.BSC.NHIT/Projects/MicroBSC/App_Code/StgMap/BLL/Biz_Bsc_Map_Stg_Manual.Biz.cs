using System;
using System.Collections;
using System.Data;

using MicroBSC.Data;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;

namespace MicroBSC.Biz.BSC
{
    public class Biz_Bsc_Map_Stg_Manual_Biz : Dac_Bsc_Map_Stg_Manual_Data
    {
        public Biz_Bsc_Map_Stg_Manual_Biz() 
        {
            
        }

        public DataSet Get_BSC_MAP_STG_MANUAL(int estterm_ref_id
                                            , int est_dept_ref_id
                                            , string ymd
                                            , string st_up_tbl_id
                                            , string st_tbl_id
                                            , string ed_up_tbl_id
                                            , string ed_tbl_id)
        {
            return base.Select(estterm_ref_id
                             , est_dept_ref_id
                             , ymd
                             , st_up_tbl_id
                             , st_tbl_id
                             , ed_up_tbl_id
                             , ed_tbl_id);
        }

        public int Remove_BSC_MAP_STG_MANUAL(int estterm_ref_id
                                           , int est_dept_ref_id
                                           , string ymd)
        {
            return base.Delete(estterm_ref_id
                             , est_dept_ref_id
                             , ymd);
        }

        public int Add_BSC_MAP_STG_MANUAL(int estterm_ref_id
                                        , int est_dept_ref_id
                                        , string ymd
                                        , string st_up_tbl_id
                                        , string st_tbl_id
                                        , string ed_up_tbl_id
                                        , string ed_tbl_id
                                        , string[] arrX1                                        
                                        , string[] arrY1
                                        , string[] arrX2
                                        , string[] arrY2
                                        , int create_user
                                        , DateTime create_date
                                        , int map_version_id)
        {
            int okCnt = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg_Parent objPrt = new Biz_Bsc_Map_Stg_Parent();
            MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi objKpi = new Biz_Bsc_Map_Kpi();

            try
            {
                DataSet ds = base.Select(conn
                                       , trx
                                       , estterm_ref_id
                                       , est_dept_ref_id
                                       , ymd
                                       , st_up_tbl_id
                                       , st_tbl_id
                                       , ed_up_tbl_id
                                       , ed_tbl_id);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    base.Delete(conn
                              , trx
                              , estterm_ref_id
                              , est_dept_ref_id
                              , ymd
                              , st_up_tbl_id
                              , st_tbl_id
                              , ed_up_tbl_id
                              , ed_tbl_id);
                }

                for (int i = 0; i < arrX1.Length; i++)
                {
                    if (arrX1[i] == arrX2[i] && arrY1[i] == arrY2[i])
                    {

                    }
                    else
                    {
                        int seq = base.NewSeq(conn
                                            , trx
                                            , estterm_ref_id
                                            , est_dept_ref_id
                                            , ymd
                                            , st_up_tbl_id
                                            , st_tbl_id
                                            , ed_up_tbl_id
                                            , ed_tbl_id);

                        okCnt += base.Insert(conn
                                           , trx
                                           , seq
                                           , estterm_ref_id
                                           , est_dept_ref_id
                                           , ymd
                                           , st_up_tbl_id
                                           , st_tbl_id
                                           , ed_up_tbl_id
                                           , ed_tbl_id
                                           , arrX1[i]
                                           , arrY1[i]
                                           , arrX2[i]
                                           , arrY2[i]
                                           , create_user
                                           , DateTime.Now);
                    }
                }

                if (okCnt > 0)
                {
                    string[] stg_ref_id    = st_tbl_id.Split('_');
                    string[] up_stg_ref_id = ed_tbl_id.Split('_');

                    Biz_Bsc_Map_Stg_Parent bizBsc_Map_Stg_Parent = new Biz_Bsc_Map_Stg_Parent();
                            bizBsc_Map_Stg_Parent.InsertData(conn
                                                           , trx
                                                           , estterm_ref_id
                                                           , est_dept_ref_id
                                                           , map_version_id
                                                           , DataTypeUtility.GetToInt32(stg_ref_id[1])
                                                           , DataTypeUtility.GetToInt32(up_stg_ref_id[1])
                                                           , DataTypeUtility.GetToInt32(create_user));
                }

                base.Transaction_Message = "정상적으로 처리되었습니다.";
                base.Transaction_Result  = "Y";
                trx.Commit();
            }
            catch (Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result = "N";
                trx.Rollback();
                okCnt = 0;
            }
            finally
            {
                conn.Close();
            }

            

            return okCnt;
        }
    }
}
