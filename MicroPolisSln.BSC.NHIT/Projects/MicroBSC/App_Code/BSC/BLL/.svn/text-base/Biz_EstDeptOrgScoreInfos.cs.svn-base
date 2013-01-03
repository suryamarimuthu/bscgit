using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Biz.BSC.Dac;
using MicroBSC.Data;

/// <summary>
/// Summary description for Biz_EstDeptOrgScoreInfos
/// </summary>
public class Biz_EstDeptOrgScoreInfos : Dac_EstDeptOrgScoreInfos
{
	public Biz_EstDeptOrgScoreInfos()
	{
		
	}

    public Biz_EstDeptOrgScoreInfos(int estterm_ref_id, string score_code) 
        : base(estterm_ref_id, score_code)
    {
        
    }

    public Biz_EstDeptOrgScoreInfos(string score_code)
        : base(0, score_code)
    {

    }

    public DataSet GetEstDeptOrgScoreInfo(string score_code) 
    {
        return GetEstDeptOrgScoreInfo_Dac(0, score_code);
    }

    public DataSet GetEstDeptOrgScoreInfos(int estterm_ref_id) 
    {
        return GetEstDeptOrgScoreInfo_Dac(estterm_ref_id, "");
    }

    public bool InsertEDOS(int estterm_ref_id, string score_code, string score_name, double min_value, double max_value, int reg_user)
    {
        return base.InsertEDOS(estterm_ref_id, score_code, score_name, min_value, max_value, reg_user);
    }
    public bool DeleteEDOS(int estterm_ref_id, DataTable dtDel)
    {
        return base.DeleteEDOS(estterm_ref_id, dtDel);
    }
    public bool CopyEDOS(int org_estterm_ref_id, int new_estterm_ref_id, int reg_user)
    {
        bool rtnValue = false;
        IDbConnection conn = DbAgentHelper.CreateDbConnection();
        conn.Open();
        IDbTransaction trx = conn.BeginTransaction();

        try
        {

            rtnValue = base.CopyEDOS(conn, trx, org_estterm_ref_id, new_estterm_ref_id, reg_user);
            if (rtnValue)
                trx.Commit();
            else
                trx.Rollback();
        }
        catch (Exception ex)
        {
            trx.Rollback();
        }
        finally
        {
            conn.Close();
        }
        return rtnValue;
    }
}
