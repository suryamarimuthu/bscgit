using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;
using MicroBSC.Integration.PMS.Dac;

namespace MicroBSC.Integration.PMS.Biz
{
    public class Biz_Pms_Col_Info
    {
        Dac_Pms_Col_Info _data;
        DataTable etcCol_Info;

        public Biz_Pms_Col_Info()
        {
            _data = new Dac_Pms_Col_Info();

            etcCol_Info = new DataTable();
            etcCol_Info.Columns.Add("PRJ_COL_ID");
            etcCol_Info.Columns.Add("PRJ_COL_VIEW");
            etcCol_Info.Columns.Add("PRJ_COL_NOTE");
            etcCol_Info.Columns.Add("PRJ_COL_SOOSIK");
            etcCol_Info.Columns.Add("PRJ_COL_EST_STATE");
            etcCol_Info.Rows.Add(new string[] { "COL_Q", "Q", "프로세스:계획수립, 통제, 측정및 분석, 요구사항관리 등 각 단계의 관리 정도<br />산출물:분석, 설계, 개발,구현 단계", "품질평가점수", "프로젝트 종료 후" });
            etcCol_Info.Rows.Add(new string[] { "PMS_COL_C1", "C", "범위의 변경을 통한매출액의 증감 정도", "실적/계획*100", "프로젝트 종료 후" });
            etcCol_Info.Rows.Add(new string[] { "PMS_COL_C2", "C", "관련비용(투입MM, 일반경비 등)의 적정사용 정도", "실적/계획*100", "프로젝트 종료 후" });
            etcCol_Info.Rows.Add(new string[] { "PMS_COL_C3", "C", "해당PJ가 회사 손익에 기여한 정도", "실적/계획*100", "프로젝트 종료 후" });
            etcCol_Info.Rows.Add(new string[] { "PMS_COL_D", "D", "PJ추진을 기한 내 추진", "100-지연율", "프로젝트 종료 후" });
            etcCol_Info.Rows.Add(new string[] { "COL_CS", "CS", "PJ추진결과 고객의 요구사항 준수 정도", "고객만족도점수", "프로젝트 종료 후" });
        }


        public DataTable Get_Custom_Col_List(string PRJ_ID)
        {
            DataTable DT = _data.Select_Col_Info_List(PRJ_ID, "", "Y");

            return DT;
        }


        public DataTable Get_Col_Info_List(string PRJ_ID)
        {
            DataTable DT = _data.Select_Col_Info_List(PRJ_ID, "", "N");

            return DT;
        }


        public DataTable Get_Weight_Col_List(string PRJ_ID)
        {
            DataTable DT = _data.Select_Col_Info_List(PRJ_ID, "A", "");

            return DT;
        }


        public DataTable Get_Difficulty_Col_List(string PRJ_ID)
        {
            DataTable DT = _data.Select_Col_Info_List(PRJ_ID, "D", "");

            return DT;
        }


        public bool Modify_Custom_Col_Value(DataTable ColTable, string PRJ_ID, string USER_REF_ID)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < ColTable.Rows.Count; i++)
                {
                    affectedRow += _data.Update_Pms_Custom_Col_Value(conn, trx, PRJ_ID
                                                    , ColTable.Rows[i]["PRJ_COL_ID"].ToString()
                                                    , ColTable.Rows[i]["PRJ_COL_NAME"].ToString()
                                                    , ColTable.Rows[i]["PRJ_COL_VALUE"].ToString()
                                                    , USER_REF_ID);
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

            return affectedRow > 0 ? true : false;
        }



        public bool Modify_Common_Soosik_Value(string PRJ_ID, string SOOSIK, string USER_REF_ID)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                affectedRow += _data.Update_Pms_Common_Soosik_Value(conn, trx
                                                        , PRJ_ID, SOOSIK, USER_REF_ID);

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return affectedRow > 0 ? true : false;
        }


        




        public bool Sync_Col_Info(int Pms_Com_Info_Idx, DataTable dt_PRJ_ID, string USER_REF_ID)
        {
            Dac_Pms_Com_Info dacComInfo = new Dac_Pms_Com_Info();

            DataTable PmsComInfo = dacComInfo.Select_Pms_Com_Info(Pms_Com_Info_Idx);
            int affectedRow = 0;


            




            if (PmsComInfo.Rows.Count > 0)
            {
                string srcIF_COL_ID = PmsComInfo.Rows[0]["IF_COL_ID"].ToString();
                string srcIF_COL_NAME = PmsComInfo.Rows[0]["IF_COL_NAME"].ToString();

                string srcCUSTOM_COL_ID = PmsComInfo.Rows[0]["CUSTOM_COL_ID"].ToString();
                string srcCUSTOM_COL_NAME = PmsComInfo.Rows[0]["CUSTOM_COL_NAME"].ToString();

                string srcSOOSIK = PmsComInfo.Rows[0]["SOOSIK"].ToString();
                string srcSOOSIK_DESC = PmsComInfo.Rows[0]["SOOSIK_DESC"].ToString();




                string[] arrIF_COL_ID = Remove_Escape_Blank_Char(srcIF_COL_ID).Split(',');
                string[] arrIF_COL_NAME = Remove_Escape_Blank_Char(srcIF_COL_NAME).Split(',');

                string[] arrCUSTOM_COL_ID = Remove_Escape_Blank_Char(srcCUSTOM_COL_ID).Split(',');
                string[] arrCUSTOM_COL_NAME = Remove_Escape_Blank_Char(srcCUSTOM_COL_NAME).Split(',');




                if (arrIF_COL_ID.Length != arrIF_COL_NAME.Length)
                    return false;

                if (arrCUSTOM_COL_ID.Length != arrCUSTOM_COL_NAME.Length)
                    return false;



                IDbConnection conn = DbAgentHelper.CreateDbConnection();
                conn.Open();
                IDbTransaction trx = conn.BeginTransaction();

                try
                {
                    string prj_id_list = "";
                    for(int i=0; i<dt_PRJ_ID.Rows.Count; i++)
                    {
                        if(prj_id_list.Length>0)
                            prj_id_list += ", ";
                        prj_id_list += dt_PRJ_ID.Rows[i]["PROJECTID"].ToString();
                    }

                    Dac_Pms_Info dacPmsInfo = new Dac_Pms_Info();
                    DataTable dtPrjData_total = dacPmsInfo.Select_Prjdata_From_Vw(conn, trx, prj_id_list);


                    for (int i = 0; i < dt_PRJ_ID.Rows.Count; i++)
                    {
                        string PRJ_ID = dt_PRJ_ID.Rows[i]["PROJECTID"].ToString();
                        string PRJ_COL_CUSTOM_YN;

                        

                        //기존 데이터 삭제
                        _data.Delete_Pms_Col_Info(conn, trx, PRJ_ID, "");


                        DataTable dtPrjData = DataTypeUtility.FilterSortDataTable(dtPrjData_total, string.Format("PROJECTID={0}", PRJ_ID));

                        //자동컬럼 인서트
                        for (int j = 0; j < arrIF_COL_ID.Length; j++)
                        {
                            PRJ_COL_CUSTOM_YN = "N";

                            affectedRow += Add_Pms_Col_Info(conn, trx
                                                    , PRJ_ID
                                                    , arrIF_COL_ID[j]
                                                    , arrIF_COL_NAME[j]
                                                    , PRJ_COL_CUSTOM_YN
                                                    , j + 1
                                                    , DBNull.Value
                                                    , USER_REF_ID
                                                    , dtPrjData.Rows[0]);

                            
                        }



                        //수기컬럼 인서트
                        for (int j = 0; j < arrCUSTOM_COL_ID.Length; j++)
                        {
                            PRJ_COL_CUSTOM_YN = "Y";

                            affectedRow += Add_Pms_Col_Info(conn, trx
                                                    , PRJ_ID
                                                    , arrCUSTOM_COL_ID[j]
                                                    , arrCUSTOM_COL_NAME[j]
                                                    , PRJ_COL_CUSTOM_YN
                                                    , j + 1
                                                    , DBNull.Value
                                                    , USER_REF_ID
                                                    , dtPrjData.Rows[0]);
                        }



                        //수식 인서트
                        affectedRow += Add_Common_Soosik(conn, trx, PRJ_ID, srcSOOSIK, USER_REF_ID);

                        affectedRow += Add_Common_Soosik_Desc(conn, trx, PRJ_ID, srcSOOSIK_DESC, USER_REF_ID);
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
            }


            return affectedRow > 0 ? true : false;
        }



        public int Add_Pms_Col_Info(IDbConnection conn, IDbTransaction trx
                                    , string PRJ_ID
                                    , string PRJ_COL_ID
                                    , string PRJ_COL_NAME
                                    , string PRJ_COL_CUSTOM_YN
                                    , int ORD_NUM
                                    , object PRJ_COL_VALUE
                                    , string USER_REF_ID
                                    , DataRow drPrjData)
        {
            Dac_Pms_Info dacPmsInfo = new Dac_Pms_Info();

            string COL_ID = PRJ_COL_ID.Trim();
            string COL_NAME = PRJ_COL_NAME.Trim();

            string COL_TYPE = Proc_Col_Type(COL_ID);
            object COL_WEIGHT = Proc_Col_Weight(COL_ID);

            object COL_VIEW         = DBNull.Value;
            object COL_NOTE         = DBNull.Value;
            object COL_SOOSIK       = DBNull.Value;
            object COL_EST_STATE    = DBNull.Value;


            int affectedRow = 0;


            if (!COL_TYPE.Equals("B"))
            {
                COL_ID = COL_ID.Substring(0, COL_ID.IndexOf("("));
            }


            if (PRJ_COL_VALUE == DBNull.Value && PRJ_COL_CUSTOM_YN.Equals("N"))
            {
                if (drPrjData != null)
                {
                    PRJ_COL_VALUE = drPrjData[COL_ID];
                }
            }


            if (PRJ_COL_CUSTOM_YN.Equals("Y"))
            {
                DataTable tmpInfo = DataTypeUtility.FilterSortDataTable(etcCol_Info, string.Format("PRJ_COL_ID='{0}'", COL_ID));
                if (tmpInfo != null && tmpInfo.Rows.Count > 0)
                {
                    COL_NOTE = tmpInfo.Rows[0]["PRJ_COL_NOTE"];
                    COL_VIEW = tmpInfo.Rows[0]["PRJ_COL_VIEW"];
                    COL_SOOSIK = tmpInfo.Rows[0]["PRJ_COL_SOOSIK"];
                    COL_EST_STATE = tmpInfo.Rows[0]["PRJ_COL_EST_STATE"];
                }
            }


            //인서트
            affectedRow += _data.Insert_Pms_Col_Info(conn, trx
                                                , PRJ_ID
                                                , COL_ID
                                                , COL_NAME
                                                , COL_TYPE
                                                , PRJ_COL_CUSTOM_YN
                                                , COL_WEIGHT
                                                , ORD_NUM
                                                , PRJ_COL_VALUE
                                                , COL_NOTE
                                                , COL_VIEW
                                                , COL_SOOSIK
                                                , COL_EST_STATE
                                                , USER_REF_ID);

            return affectedRow;
        }



        public string Proc_Col_Type(string COL_ID)
        {
            string COL_TYPE;

            if (COL_ID.IndexOf("(D)") > 0)
            {
                COL_TYPE = "D";
            }
            else if (COL_ID.IndexOf("(") > 0)
            {
                COL_TYPE = "A";
            }
            else
            {
                COL_TYPE = "B";
            }

            return COL_TYPE;
        }


        public object Proc_Col_Weight(string COL_ID)
        {
            object Result;
            string COL_TYPE = Proc_Col_Type(COL_ID);

            if (COL_TYPE.Equals("A"))
            {
                int startIdx = COL_ID.IndexOf("(");

                Result = COL_ID.Substring(startIdx).Replace("(", "").Replace(")", "");
            }
            else
            {
                Result = DBNull.Value;
            }

            return Result;
        }


        public string Remove_Escape_Blank_Char(string inputStr)
        {
            return inputStr.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
        }


        public int Add_Common_Soosik(IDbConnection conn, IDbTransaction trx, object PRJ_ID, string SOOSIK, string USER_REF_ID)
        {
            int affectedRow = _data.Insert_Pms_Col_Info(conn, trx
                                                        , PRJ_ID
                                                        , "SOOSIK_" + PRJ_ID
                                                        , DBNull.Value
                                                        , "B"
                                                        , "S"
                                                        , DBNull.Value
                                                        , 0
                                                        , SOOSIK
                                                        , DBNull.Value
                                                        , DBNull.Value
                                                        , DBNull.Value
                                                        , DBNull.Value
                                                        , USER_REF_ID);

            return affectedRow;
        }



        public int Add_Common_Soosik_Desc(IDbConnection conn, IDbTransaction trx, object PRJ_ID, string SOOSIK, string USER_REF_ID)
        {
            int affectedRow = _data.Insert_Pms_Col_Info(conn, trx
                                                        , PRJ_ID
                                                        , "SOOSIK_DESC_" + PRJ_ID
                                                        , DBNull.Value
                                                        , "B"
                                                        , "S"
                                                        , DBNull.Value
                                                        , 0
                                                        , SOOSIK
                                                        , DBNull.Value
                                                        , DBNull.Value
                                                        , DBNull.Value
                                                        , DBNull.Value
                                                        , USER_REF_ID);

            return affectedRow;
        }



        public string Get_Common_Soosik(string PRJ_ID)
        {
            DataTable DT = _data.Select_Col_Info_List(PRJ_ID, "", "S");
            string Result = "";


            for (int i = 0; i < DT.Rows.Count; i++)
            {
                string PRJ_COL_ID = DT.Rows[i]["PRJ_COL_ID"].ToString();

                if (PRJ_COL_ID.Equals("SOOSIK_" + PRJ_ID))
                {
                    Result = DT.Rows[i]["PRJ_COL_VALUE"].ToString();
                    break;
                }
            }

            return Result;
        }


        public string Get_Common_Soosik_Desc(string PRJ_ID)
        {
            DataTable DT = _data.Select_Col_Info_List(PRJ_ID, "", "S");
            string Result = "";


            for (int i = 0; i < DT.Rows.Count; i++)
            {
                string PRJ_COL_ID = DT.Rows[i]["PRJ_COL_ID"].ToString();

                if (PRJ_COL_ID.Equals("SOOSIK_DESC_" + PRJ_ID))
                {
                    Result = DT.Rows[i]["PRJ_COL_VALUE"].ToString();
                    break;
                }
            }

            return Result;
        }
    }
}