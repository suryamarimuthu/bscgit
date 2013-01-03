using System;
using System.Data;
using MicroBSC.Biz.Common.Dac;
using MicroBSC.Estimation.Dac;

/// <summary>
/// Summary description for Biz_Com_Low_HR_Info
/// </summary>
/// 
namespace MicroBSC.Biz.Common.Biz
{
    public class Biz_Com_Low_HR_Info
    {
        public DataTable GetCompareEmpInfo(out string sErr)
        {
            sErr = "";
            Dac_EmpInfos objBscEmp         = new Dac_EmpInfos();
            Dac_Com_Low_HR_Info objLowEmp = new Dac_Com_Low_HR_Info();

            DataTable dtCom  = this.GetEmpSchema();
            DataSet dsBscEmp = objBscEmp.SelectByDept(0, 0);
            if (dsBscEmp.Tables.Count > 0)
            {
                DataTable dtBsc = dsBscEmp.Tables[0];
                DataTable dtLow = objLowEmp.GetLowEmpInfo(out sErr);

                if (dtLow == null)
                {
                    return dtCom;
                }

                DataRow drCom = null;
                foreach (DataRow dr in dtBsc.Rows)
                {
                    drCom = dtCom.NewRow();
                    drCom["BSC_DEPT_REF_ID"] = dr["DEPT_REF_ID"];
                    drCom["BSC_DEPT_NAME"]   = dr["DEPT_NAME"];
                    drCom["BSC_EMP_REF_ID"]  = dr["LOGINID"];
                    drCom["BSC_EMP_NAME"]    = dr["EMP_NAME"];
                    drCom["BSC_RANK_CODE"]   = dr["TGT_POS_RNK_ID"];
                    drCom["BSC_RANK_NAME"]   = dr["TGT_POS_RNK_NAME"];
                    drCom["BSC_CLASS_CODE"]  = dr["TGT_POS_CLS_ID"];
                    drCom["BSC_CLASS_NAME"]  = dr["TGT_POS_CLS_NAME"];
                    drCom["BSC_DUTY_CODE"]   = dr["TGT_POS_DUT_ID"];
                    drCom["BSC_DUTY_NAME"]   = dr["TGT_POS_DUT_NAME"];
                    drCom["BSC_GROUP_CODE"]  = dr["TGT_POS_GRP_ID"];
                    drCom["BSC_GROUP_NAME"]  = dr["TGT_POS_GRP_NAME"];
                    drCom["BSC_USE_YN"]      = "Y";

                    DataRow[] arrDr = dtLow.Select("EMP_CODE='" + drCom["BSC_EMP_REF_ID"].ToString() + "'");
                    int idx = 0;
                    foreach (DataRow tDr in arrDr)
                    {
                        if (idx == 0)
                        { 
                            drCom["LOW_DEPT_REF_ID"] = tDr["DEPT_CODE"];
                            drCom["LOW_DEPT_NAME"]   = tDr["DEPT_NAME"];
                            drCom["LOW_EMP_REF_ID"]  = tDr["EMP_CODE"];
                            drCom["LOW_EMP_NAME"]    = tDr["EMP_NAME"];
                            drCom["LOW_RANK_CODE"]   = tDr["POS_RANK_CD"];
                            drCom["LOW_RANK_NAME"]   = tDr["POS_RANK_NM"];
                            drCom["LOW_CLASS_CODE"]  = tDr["POS_CLS_CD"];
                            drCom["LOW_CLASS_NAME"]  = tDr["POS_CLS_NM"];
                            drCom["LOW_DUTY_CODE"]   = tDr["POS_DUTY_CD"];
                            drCom["LOW_DUTY_NAME"]   = tDr["POS_DUTY_NM"];
                            drCom["LOW_GROUP_CODE"]  = tDr["POS_GRP_CD"];
                            drCom["LOW_GROUP_NAME"]  = tDr["POS_GRP_NM"];
                            drCom["LOW_USE_YN"]      = tDr["EMP_USEYN"];
                        }
                        idx++;
                        dtLow.Rows.Remove(tDr);
                    }

                    dtCom.Rows.Add(drCom);
                }

                foreach (DataRow dr in dtLow.Rows)
                {
                    drCom = dtCom.NewRow();
                    drCom["LOW_DEPT_REF_ID"] = dr["DEPT_CODE"];
                    drCom["LOW_DEPT_NAME"]   = dr["DEPT_NAME"];
                    drCom["LOW_EMP_REF_ID"]  = dr["EMP_CODE"];
                    drCom["LOW_EMP_NAME"]    = dr["EMP_NAME"];
                    drCom["LOW_RANK_CODE"]   = dr["POS_RANK_CD"];
                    drCom["LOW_RANK_NAME"]   = dr["POS_RANK_NM"];
                    drCom["LOW_CLASS_CODE"]  = dr["POS_CLS_CD"];
                    drCom["LOW_CLASS_NAME"]  = dr["POS_CLS_NM"];
                    drCom["LOW_DUTY_CODE"]   = dr["POS_DUTY_CD"];
                    drCom["LOW_DUTY_NAME"]   = dr["POS_DUTY_NM"];
                    drCom["LOW_GROUP_CODE"]  = dr["POS_GRP_CD"];
                    drCom["LOW_GROUP_NAME"]  = dr["POS_GRP_NM"];
                    drCom["LOW_USE_YN"]      = dr["EMP_USEYN"];
                    dtCom.Rows.Add(drCom);
                }
            }

            return dtCom;
        }

        public DataTable GetCompareDeptInfo(out string sErr)
        {
            sErr = "";
            Dac_ComDeptInfo objBscDept     = new Dac_ComDeptInfo();
            Dac_Com_Low_HR_Info objLowDept = new Dac_Com_Low_HR_Info();
            
            DataTable dtCom = this.GetDeptSchema();

            DataSet dsBsc   = objBscDept.GetAllList_Dac();
            if (dsBsc.Tables.Count > 0)
            {
                DataTable dtBsc = dsBsc.Tables[0];
                DataTable dtLow = objLowDept.GetLowDeptInfo(out sErr);

                if (dtLow == null)
                {
                    return dtCom;
                }
                
                DataRow   drCom = null;
                foreach (DataRow dr in dtBsc.Rows)
                {
                    drCom = dtCom.NewRow();
                    drCom["BSC_DEPT_REF_ID"] = dr["DEPT_CODE"];
                    drCom["BSC_DEPT_NAME"]   = dr["DEPT_NAME"];
                    drCom["BSC_USE_YN"]      = (dr["DEPT_FLAG"] == null) ? "N" : dr["DEPT_FLAG"].ToString();
                    drCom["BSC_USE_YN"]      = (drCom["BSC_USE_YN"].ToString() == "1" ? "Y" : "N");

                    DataRow[] arrDr = dtLow.Select("DEPT_CODE='" + drCom["BSC_DEPT_REF_ID"].ToString() + "'");
                    int idx = 0;
                    foreach (DataRow tDr in arrDr)
                    {
                        if (idx == 0)
                        { 
                            drCom["LOW_DEPT_REF_ID"] = tDr["DEPT_CODE"];
                            drCom["LOW_DEPT_NAME"]   = tDr["DEPT_NAME"];
                            drCom["LOW_USE_YN"]      = tDr["DEPT_USEYN"];
                        }
                        idx++;
                        dtLow.Rows.Remove(tDr);
                    }

                    dtCom.Rows.Add(drCom);
                }

                foreach (DataRow dr in dtLow.Rows)
                {
                    drCom = dtCom.NewRow();
                    drCom["LOW_DEPT_REF_ID"] = dr["DEPT_CODE"];
                    drCom["LOW_DEPT_NAME"]   = dr["DEPT_NAME"];
                    drCom["LOW_USE_YN"]      = dr["DEPT_USEYN"];
                    dtCom.Rows.Add(drCom);
                }
            }

            return dtCom;
        }

        private DataTable GetEmpSchema()
        {
            DataTable dtEmp = new DataTable("EMP");
            dtEmp.Columns.Add("BSC_DEPT_REF_ID" , typeof(string));
            dtEmp.Columns.Add("BSC_DEPT_NAME"   , typeof(string));
            dtEmp.Columns.Add("BSC_EMP_REF_ID"  , typeof(string));
            dtEmp.Columns.Add("BSC_EMP_NAME"    , typeof(string));
            dtEmp.Columns.Add("BSC_RANK_CODE"   , typeof(string));
            dtEmp.Columns.Add("BSC_RANK_NAME"   , typeof(string));
            dtEmp.Columns.Add("BSC_CLASS_CODE"  , typeof(string));
            dtEmp.Columns.Add("BSC_CLASS_NAME"  , typeof(string));
            dtEmp.Columns.Add("BSC_DUTY_CODE"   , typeof(string));
            dtEmp.Columns.Add("BSC_DUTY_NAME"   , typeof(string));
            dtEmp.Columns.Add("BSC_GROUP_CODE"  , typeof(string));
            dtEmp.Columns.Add("BSC_GROUP_NAME"  , typeof(string));
            dtEmp.Columns.Add("BSC_USE_YN"      , typeof(string));
            dtEmp.Columns.Add("LOW_DEPT_REF_ID" , typeof(string));
            dtEmp.Columns.Add("LOW_DEPT_NAME"   , typeof(string));
            dtEmp.Columns.Add("LOW_EMP_REF_ID"  , typeof(string));
            dtEmp.Columns.Add("LOW_EMP_NAME"    , typeof(string));
            dtEmp.Columns.Add("LOW_RANK_CODE"   , typeof(string));
            dtEmp.Columns.Add("LOW_RANK_NAME"   , typeof(string));
            dtEmp.Columns.Add("LOW_CLASS_CODE"  , typeof(string));
            dtEmp.Columns.Add("LOW_CLASS_NAME"  , typeof(string));
            dtEmp.Columns.Add("LOW_DUTY_CODE"   , typeof(string));
            dtEmp.Columns.Add("LOW_DUTY_NAME"   , typeof(string));
            dtEmp.Columns.Add("LOW_GROUP_CODE"  , typeof(string));
            dtEmp.Columns.Add("LOW_GROUP_NAME"  , typeof(string));
            dtEmp.Columns.Add("LOW_USE_YN"      , typeof(string));

            return dtEmp;
        }

        private DataTable GetDeptSchema()
        {
            DataTable dtDept = new DataTable("DEPT");
            dtDept.Columns.Add("BSC_DEPT_REF_ID" , typeof(string));
            dtDept.Columns.Add("BSC_DEPT_NAME"   , typeof(string));
            dtDept.Columns.Add("BSC_USE_YN"      , typeof(string));
            dtDept.Columns.Add("LOW_DEPT_REF_ID" , typeof(string));
            dtDept.Columns.Add("LOW_DEPT_NAME"   , typeof(string));
            dtDept.Columns.Add("LOW_USE_YN"      , typeof(string));

            //dtDept.Constraints.Add("BSC_DEPT_REF_ID",dtDept.Columns["BSC_DEPT_REF_ID"], true);

            return dtDept;
        }
    }
}
