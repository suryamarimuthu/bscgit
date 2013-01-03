using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Dac;

/// <summary>
/// Biz_Bsc_Score_Card의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Score_Card : MicroBSC.BSC.Dac.Dac_Bsc_Score_Card
    {
        public Biz_Bsc_Score_Card() { }

        public DataSet GetEstDeptRank(int iestterm_ref_id, string iymd, int idept_type, string isum_type
                                    , int est_dept_id, string showChildDept, bool includeExtScore, int itxr_user)
        { 
            Biz_Bsc_Est_Dept_Grade objGrd = new Biz_Bsc_Est_Dept_Grade();
            DataSet dsGrade = objGrd.GetAllList(iestterm_ref_id, idept_type);
            DataSet dsRank  = new DataSet();

            if (includeExtScore)
            {
                dsRank = base.GetEstDeptRankList(iestterm_ref_id, iymd, idept_type, isum_type, est_dept_id, showChildDept, includeExtScore, itxr_user);
            }
            else
            {
                dsRank = base.GetEstDeptRankList(iestterm_ref_id, iymd, idept_type, isum_type, est_dept_id, showChildDept, itxr_user);
            }
            

            dsRank.Tables[0].Columns.Add("RANK_PERCENT", typeof(double));
            dsRank.Tables[0].Columns.Add("DEPT_GRADE", typeof(string));
            
            int intRankRow  = dsRank.Tables[0].Rows.Count;
            int intGrdeRow  = dsGrade.Tables[0].Rows.Count;

            if (intGrdeRow < 1)
            {
                return dsRank;
            }

            double currRank = 0;
            double lastRank = 0;

            double minValue = 0;
            double maxValue = 0;

            double grdValue = 0;
            double midValue = 0;

            grdValue = Math.Round((double.Parse(intRankRow.ToString()) / double.Parse(intGrdeRow.ToString())),0);

            grdValue = (grdValue < 1) ? 1 : grdValue;
            midValue = (intGrdeRow * grdValue - intRankRow);


            //int intMidRank = -1;
            //for (int i = 0; i < intGrdeRow; i++)
            //{
            //    if (dsGrade.Tables[0].Rows[i]["MID_GRADE_YN"].ToString() == "Y")
            //    {
            //        intMidRank = i;
            //    }

            //    if (intMidRank < i)
            //    {
            //        dsGrade.Tables[0].Rows[i]["MIN_VALUE"] = (i + 1) * grdValue;
            //    }
            //    else if (intMidRank == i)
            //    {
            //        dsGrade.Tables[0].Rows[i]["MIN_VALUE"] = ((i + 1) * grdValue) + midValue * -1;
            //    }
            //    else
            //    {
            //        dsGrade.Tables[0].Rows[i]["MIN_VALUE"] = ((i + 1) * grdValue) + midValue * -1;
            //    }

            //    if (intMidRank >= i)
            //    { 
            //        intMidRank += 1;
            //    }
            //}

            //for (int i = 0; i < intRankRow; i++)
            //{ 
            //    currRank = Convert.ToDouble(dsRank.Tables[0].Rows[i]["RANK_ID"].ToString());
            //    dsRank.Tables[0].Rows[i]["RANK_PERCENT"] = currRank ;

            //    for (int j = 0; j < intGrdeRow; j++)
            //    {
            //        minValue = Convert.ToDouble(dsGrade.Tables[0].Rows[j]["MIN_VALUE"].ToString());

            //        if (currRank <= minValue)
            //        { 
            //            dsRank.Tables[0].Rows[i]["DEPT_GRADE"] = dsGrade.Tables[0].Rows[j]["GRADE_NAME"].ToString();
            //            break;
            //        }
            //    }
            //}

            if (intRankRow > 0)
            {
                try
                {
                    lastRank = Convert.ToDouble(dsRank.Tables[0].Rows[intRankRow - 1]["RANK_ID"].ToString());
                }
                catch
                {
                    lastRank = 0;
                }

                if (intRankRow <= intGrdeRow)
                {
                    for (int i = 0; i < intRankRow; i++)
                    {
                        dsRank.Tables[0].Rows[i]["DEPT_GRADE"] = dsGrade.Tables[0].Rows[i]["GRADE_NAME"].ToString();
                    }
                }
                else
                {
                    for (int i = 0; i < intRankRow; i++)
                    {
                        currRank = (lastRank == 0 ? 0 : Math.Round(((i + 1) / lastRank) * 100, 4));
                        dsRank.Tables[0].Rows[i]["RANK_PERCENT"] = currRank;
                        double dScore = Convert.ToDouble(dsRank.Tables[0].Rows[i]["SCORE"].ToString());

                        for (int j = 0; j < intGrdeRow; j++)
                        {
                            minValue = Convert.ToDouble(dsGrade.Tables[0].Rows[j]["MIN_VALUE"].ToString());
                            maxValue = Convert.ToDouble(dsGrade.Tables[0].Rows[j]["MAX_VALUE"].ToString());

                            if (dScore >= minValue && dScore <= maxValue)
                            {
                                dsRank.Tables[0].Rows[i]["DEPT_GRADE"] = dsGrade.Tables[0].Rows[j]["GRADE_NAME"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            return dsRank;
        }

        public DataSet GetEstDeptRankPOP(int estterm_ref_id, string ymd, int dept_type, string sum_type)
        {
            return base.GetEstDeptRankPOP(estterm_ref_id, ymd, dept_type);
        }
        public DataSet GetEstDeptRank(int iestterm_ref_id, string iymd, int idept_type, string isum_type
                                    , int est_dept_id, string showChildDept, bool includeExtScore, int itxr_user, bool GetExtKpiScore)
        {
            Biz_Bsc_Est_Dept_Grade objGrd = new Biz_Bsc_Est_Dept_Grade();
            DataSet dsGrade = objGrd.GetAllList(iestterm_ref_id, idept_type);

            DataSet dsRank = new DataSet();

            if (GetExtKpiScore)
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                dsRank = objExt.GetEstDeptRankList(iestterm_ref_id, iymd, idept_type, isum_type, est_dept_id, showChildDept, includeExtScore, itxr_user);
            }
            else
            {
                dsRank = base.GetEstDeptRankList(iestterm_ref_id, iymd, idept_type, isum_type, est_dept_id, showChildDept, includeExtScore, itxr_user);
            }
            

            dsRank.Tables[0].Columns.Add("RANK_PERCENT", typeof(double));
            dsRank.Tables[0].Columns.Add("DEPT_GRADE", typeof(string));

            int intRankRow = dsRank.Tables[0].Rows.Count;
            int intGrdeRow = dsGrade.Tables[0].Rows.Count;

            if (intGrdeRow < 1)
            {
                return dsRank;
            }

            double currRank = 0;
            double lastRank = 0;

            double minValue = 0;
            double maxValue = 0;

            double grdValue = 0;
            double midValue = 0;

            grdValue = Math.Round((double.Parse(intRankRow.ToString()) / double.Parse(intGrdeRow.ToString())), 0);

            grdValue = (grdValue < 1) ? 1 : grdValue;
            midValue = (intGrdeRow * grdValue - intRankRow);


            //int intMidRank = -1;
            //for (int i = 0; i < intGrdeRow; i++)
            //{
            //    if (dsGrade.Tables[0].Rows[i]["MID_GRADE_YN"].ToString() == "Y")
            //    {
            //        intMidRank = i;
            //    }

            //    if (intMidRank < i)
            //    {
            //        dsGrade.Tables[0].Rows[i]["MIN_VALUE"] = (i + 1) * grdValue;
            //    }
            //    else if (intMidRank == i)
            //    {
            //        dsGrade.Tables[0].Rows[i]["MIN_VALUE"] = ((i + 1) * grdValue) + midValue * -1;
            //    }
            //    else
            //    {
            //        dsGrade.Tables[0].Rows[i]["MIN_VALUE"] = ((i + 1) * grdValue) + midValue * -1;
            //    }

            //    if (intMidRank >= i)
            //    {
            //        intMidRank += 1;
            //    }
            //}

            //for (int i = 0; i < intRankRow; i++)
            //{
            //    currRank = Convert.ToDouble(dsRank.Tables[0].Rows[i]["RANK_ID"].ToString());
            //    dsRank.Tables[0].Rows[i]["RANK_PERCENT"] = currRank;

            //    for (int j = 0; j < intGrdeRow; j++)
            //    {
            //        minValue = Convert.ToDouble(dsGrade.Tables[0].Rows[j]["MIN_VALUE"].ToString());

            //        if (currRank <= minValue)
            //        {
            //            dsRank.Tables[0].Rows[i]["DEPT_GRADE"] = dsGrade.Tables[0].Rows[j]["GRADE_NAME"].ToString();
            //            break;
            //        }
            //    }
            //}

            if (intRankRow > 0)
            {
                try
                {
                    lastRank = Convert.ToDouble(dsRank.Tables[0].Rows[intRankRow - 1]["RANK_ID"].ToString());
                }
                catch
                {
                    lastRank = 0;
                }

                if (intRankRow <= intGrdeRow)
                {
                    for (int i = 0; i < intRankRow; i++)
                    {
                        dsRank.Tables[0].Rows[i]["DEPT_GRADE"] = dsGrade.Tables[0].Rows[i]["GRADE_NAME"].ToString();
                    }
                }
                else
                {
                    for (int i = 0; i < intRankRow; i++)
                    {
                        currRank = (lastRank == 0 ? 0 : Math.Round(((i + 1) / lastRank) * 100, 4));
                        dsRank.Tables[0].Rows[i]["RANK_PERCENT"] = currRank;
                        double dScore = Convert.ToDouble(dsRank.Tables[0].Rows[i]["SCORE"].ToString());

                        for (int j = 0; j < intGrdeRow; j++)
                        {
                            minValue = Convert.ToDouble(dsGrade.Tables[0].Rows[j]["MIN_VALUE"].ToString());
                            maxValue = Convert.ToDouble(dsGrade.Tables[0].Rows[j]["MAX_VALUE"].ToString());

                            if (dScore >= minValue && dScore <= maxValue)
                            {
                                dsRank.Tables[0].Rows[i]["DEPT_GRADE"] = dsGrade.Tables[0].Rows[j]["GRADE_NAME"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            return dsRank;
        }

        public DataSet GetEstDeptRankList(int iestterm_ref_id, string iymd, int idept_type, string isum_type, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptRankList(iestterm_ref_id, iymd, idept_type, isum_type);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptRankList(iestterm_ref_id, iymd, idept_type, isum_type);
            }
            return rDs;
        }

        public DataSet GetEstDeptRankList(int iestterm_ref_id, string iymd, int idept_type, string isum_type
                                        , int iest_dept_ref_id, string iselecttype, int itxr_user, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptRankList(iestterm_ref_id, iymd, idept_type, isum_type
                                        , iest_dept_ref_id, iselecttype, itxr_user);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptRankList(iestterm_ref_id, iymd, idept_type, isum_type
                                        , iest_dept_ref_id, iselecttype, itxr_user);
            }
            return rDs;
        }

        public DataSet GetEstDeptKpiScoreList(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptKpiScoreList(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptKpiScoreList(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetEstDeptKpiScoreList_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptKpiScoreList_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptKpiScoreList_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetEstDeptKpiViewTypeList(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptKpiViewTypeList(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptKpiViewTypeList(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetEstDeptKpiViewTypeList_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptKpiViewTypeList_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptKpiViewTypeList_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetScorePerStrategy(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetScorePerStrategy( iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetScorePerStrategy(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetScorePerStrategy_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetScorePerStrategy_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetScorePerStrategy_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetEstDeptTotalScore(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptTotalScore(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptTotalScore(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetEstDeptTotalScore_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptTotalScore_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptTotalScore_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public double GetEstDeptTotalScoreOnly(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            double dblRtn = 0;
            if (!GetExtKpiScore)
            {
                dblRtn = double.Parse(base.GetEstDeptTotalScoreOnly(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id).Replace('-','0'));
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                dblRtn = double.Parse(objExt.GetEstDeptTotalScoreOnly(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id).Replace('-', '0'));
            }
            return dblRtn;
        }

        public string GetEstDeptTotalStringScoreOnly(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            string strRtn = "-";
            if (!GetExtKpiScore)
            {
                strRtn = base.GetEstDeptTotalScoreOnly(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                strRtn = objExt.GetEstDeptTotalScoreOnly(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return strRtn;
        }

        public string GetEstDeptTotalStringScoreOnly_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            string strRtn = "-";
            if (!GetExtKpiScore)
            {
                strRtn = base.GetEstDeptTotalScoreOnly_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                strRtn = objExt.GetEstDeptTotalScoreOnly_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return strRtn;
        }

        public DataSet GetEstDeptTotalScoreForMap(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetEstDeptTotalScoreForMap(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetEstDeptTotalScoreForMap(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetKpiDetailStatusForMap(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetKpiDetailStatusForMap(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetKpiDetailStatusForMap(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetKpiGradeStatusForMap(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetKpiGradeStatusForMap(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetKpiGradeStatusForMap(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetKpiGradeStatusForMap_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetKpiGradeStatusForMap_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetKpiGradeStatusForMap_Goal(iestterm_ref_id, iymd, isum_type, iest_dept_ref_id);
            }
            return rDs;
        }

        public DataSet GetYearlyTotalScoreTrend(int iestterm_ref_id, int idept_type, string isumtype, int iest_dept_ref_id, string iselecttype, int itxr_user, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetYearlyTotalScoreTrend(iestterm_ref_id, idept_type, isumtype, iest_dept_ref_id, iselecttype, itxr_user);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetYearlyTotalScoreTrend(iestterm_ref_id, idept_type, isumtype, iest_dept_ref_id, iselecttype, itxr_user);
            }
            return rDs;
        }

        public DataSet GetQuantityScoreForEstDetp(int iestterm_ref_id, int iestterm_sub_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetQuantityScoreForEstDetp(iestterm_ref_id, iestterm_sub_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetQuantityScoreForEstDetp(iestterm_ref_id, iestterm_sub_id);
            }
            return rDs;
        }

        public DataSet GetInterfaceQuantityScore(int iestterm_ref_id, int iestterm_sub_id, bool GetExtKpiScore)
        {
            DataSet rDs = new DataSet();
            if (!GetExtKpiScore)
            {
                rDs = base.GetInterfaceQuantityScore(iestterm_ref_id, iestterm_sub_id);
            }
            else
            {
                Dac_Bsc_Score_Card_Ext objExt = new Dac_Bsc_Score_Card_Ext();
                rDs = objExt.GetInterfaceQuantityScore(iestterm_ref_id, iestterm_sub_id);
            }
            return rDs;
        }
    }
}
