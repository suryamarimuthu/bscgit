using System.Data;
using System.Data.SqlClient;
using MicroBSC.Biz.BSC.Dac;

/// <summary>
/// Summary description for Biz_EstDeptOrgDetails
/// </summary>
public class Biz_EstDeptOrgDetails
{
    private Dac_EstDeptOrgDetails _estDeptOrgDetail = null;

    public Biz_EstDeptOrgDetails() 
    {
        _estDeptOrgDetail = new Dac_EstDeptOrgDetails();
    }

    public bool ModifyEstDeptOrgDetail(IDbConnection conn
                                            , IDbTransaction trx
                                            , int estterm_ref_id
                                            , string est_dept_top_yn)
    {
        return _estDeptOrgDetail.ModifyEstDeptOrgDetail(conn, trx, estterm_ref_id, est_dept_top_yn);
    }

    public bool ModifyEstDeptOrgDetail(IDbConnection conn
                                            , IDbTransaction trx
                                            , int estterm_ref_id
                                            , int est_dept_ref_id
                                            , string est_dept_top_yn)
    {
        return _estDeptOrgDetail.ModifyEstDeptOrgDetail(conn, trx, estterm_ref_id, est_dept_ref_id, est_dept_top_yn);
    }

    public DataSet GetEstDeptOrgDetail(int estterm_ref_id, int est_dept_ref_id) 
    {
        return _estDeptOrgDetail.GetEstDeptOrgDetail(estterm_ref_id, est_dept_ref_id);
    }

    public bool AddEstDeptOrgDetail(IDbConnection conn
                                            , IDbTransaction trx
                                            , int estterm_ref_id
                                            , int est_dept_ref_id
                                            , int type_ref_id
                                            , string home_yn_org
                                            , string header_yn_org
                                            , string content_yn_org
                                            , string est_dept_top_yn_org
                                            , int position_org
                                            , int create_user) 
    {
        return _estDeptOrgDetail.AddEstDeptOrgDetail(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , est_dept_ref_id
                                                        , type_ref_id
                                                        , home_yn_org
                                                        , header_yn_org
                                                        , content_yn_org
                                                        , est_dept_top_yn_org
                                                        , position_org
                                                        , create_user);
    }

    public bool RemoveEstDeptOrgDetail(IDbConnection conn
                                        , IDbTransaction trx
                                        , int estterm_ref_id
                                        , int est_dept_ref_id
                                        , int type_ref_id) 
    {
        return _estDeptOrgDetail.RemoveEstDeptOrgDetail(conn, trx, estterm_ref_id, est_dept_ref_id, type_ref_id);
    }

    public bool IsDrillDown(int estterm_ref_id) 
    {
        int count = _estDeptOrgDetail.GetEstDeptOrgCount(estterm_ref_id);

        if (count > 1)
            return true;

        return false;
    }

    public bool IsEstDeptTopYN(int estterm_ref_id, int est_dept_ref_id) 
    {
        string ynStr = _estDeptOrgDetail.GetEstDeptTopYN(estterm_ref_id, est_dept_ref_id);

        if (ynStr.Equals("Y"))
            return true;

        return false;
    }

    public int GetEstDeptRefID(int estterm_ref_id) 
    {
        int est_dept_ref_id_top_yn  = _estDeptOrgDetail.GetEstDeptRefIDByTopYN(estterm_ref_id);
        int est_dept_ref_id_top_1   = _estDeptOrgDetail.GetEstDeptRefIDByTop1(estterm_ref_id);


        if (est_dept_ref_id_top_yn == 0)
            return est_dept_ref_id_top_1;

        return est_dept_ref_id_top_1;
    }

    public int GetEstDeptRefID(int estterm_ref_id, int emp_ref_id) 
    {
        int est_dept_ref_id_top_1   = _estDeptOrgDetail.GetEstDeptRefIDByTop1(estterm_ref_id, emp_ref_id);
        return est_dept_ref_id_top_1;
    }

    public bool IsDrillDownPosible(int estterm_ref_id, int est_dept_ref_id) 
    {
        int count = _estDeptOrgDetail.GetCount(estterm_ref_id, est_dept_ref_id);

        if (count > 0)
            return true;

        return false;
    }
}
