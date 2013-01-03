using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.BSC.Dac;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Interface_Column
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Interface_Column
    /// Class Func     : BSC_INTERFACE_COLUMN Business Logic Class
    /// CREATE DATE    : 2008-07-19 오전 12:03:02
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Interface_Column  : Dac_Bsc_Interface_Column
    {
        public Biz_Bsc_Interface_Column() { }
        public Biz_Bsc_Interface_Column(string idicode, string icolumn_id, int itxr_user) : base(idicode, icolumn_id, itxr_user) { }

        public int InsertData(IDbConnection con, IDbTransaction trx, string idicode, string icolumn_id, string icolumn_alias, string ilov_yn, int isort_order, int iunit_ref_id, int idecimal_points, int igrid_width, string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx, idicode,  icolumn_id,  icolumn_alias,  ilov_yn,  isort_order, iunit_ref_id, idecimal_points, igrid_width,  iuse_yn, itxr_user);
        }

        public int UpdateData(IDbConnection con, IDbTransaction trx, string idicode, string icolumn_id, string icolumn_alias, string ilov_yn, int isort_order, int iunit_ref_id, int idecimal_points, int igrid_width, string iuse_yn, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx, idicode,  icolumn_id,  icolumn_alias,  ilov_yn,  isort_order, iunit_ref_id, idecimal_points, igrid_width,  iuse_yn, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction trx, string idicode, string icolumn_id, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx, idicode,  icolumn_id, itxr_user);
        }

        /// <summary>
        /// Data Interface Code 조회
        /// </summary>
        /// <param name="idicode"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataTable GetColumnInfoPerDicode(string idicode, int itxr_user)
        {
            DataTable dtDefault = GetDefaultColumn(idicode);
            DataSet rDs = base.GetAllList(idicode, itxr_user);

            string sColumnID    = "";
			string sDiCode      = "";
            string sColumnAlias = "";
            string sUseYn       = "N";
            int iSortOrder      = 0;
            int iUnitRefId      = 0;
            int iDecimalPoints  = 0;
            int iGridWidth      = 0;

            int    iRow      = 0;
            int    iDRow     = 0;

            string sSColumn  = "";
            string sDColumn  = "";

            if (rDs.Tables.Count > 0)
            {
                iRow  = rDs.Tables[0].Rows.Count;
                iDRow = dtDefault.Rows.Count;

                if (iRow > 0)
                {
                    for (int i = 0; i < iRow; i++)
                    {
                        sColumnID      = rDs.Tables[0].Rows[i]["COLUMN_ID"].ToString();
                        sColumnAlias   = rDs.Tables[0].Rows[i]["COLUMN_ALIAS"].ToString();
                        sUseYn         = rDs.Tables[0].Rows[i]["USE_YN"].ToString();
                        iSortOrder     = Convert.ToInt32(rDs.Tables[0].Rows[i]["SORT_ORDER"].ToString());
                        iUnitRefId     = Convert.ToInt32(rDs.Tables[0].Rows[i]["UNIT_REF_ID"].ToString());
                        iDecimalPoints = Convert.ToInt32(rDs.Tables[0].Rows[i]["DECIMAL_POINTS"].ToString());
                        iGridWidth     = Convert.ToInt32(rDs.Tables[0].Rows[i]["GRID_WIDTH"].ToString());

                        for (int j = 0; j < iDRow; j++)
                        {
                            sSColumn = dtDefault.Rows[j]["S_COLUMN_ID"].ToString();
                            sDColumn = dtDefault.Rows[j]["D_COLUMN_ID"].ToString();

                            if (sColumnID == sSColumn)
                            {
                                dtDefault.Rows[j]["S_USE_YN"]       = sUseYn;
                                dtDefault.Rows[j]["S_SORT_ORDER"]   = iSortOrder;
                                dtDefault.Rows[j]["S_COL_NAME"]     = sColumnAlias;
                                dtDefault.Rows[j]["S_GRID_WIDTH"]   = iGridWidth;
                                dtDefault.Rows[j]["S_INSERTED_YN"]  = "Y";
                                break;
                            }

                            if (sColumnID == sDColumn)
                            {
                                dtDefault.Rows[j]["D_USE_YN"]         = sUseYn;
                                dtDefault.Rows[j]["D_SORT_ORDER"]     = iSortOrder;
                                dtDefault.Rows[j]["D_UNIT_REF_ID"]    = iUnitRefId;
                                dtDefault.Rows[j]["D_COL_NAME"]       = sColumnAlias;
                                dtDefault.Rows[j]["D_GRID_WIDTH"]     = iGridWidth;
                                dtDefault.Rows[j]["D_DECIMAL_POINTS"] = iDecimalPoints;
                                dtDefault.Rows[j]["D_INSERTED_YN"]    = "Y";
                                break;
                            }
                        }
                    }
                }
            }


            return dtDefault;
        }

        /// <summary>
        /// Datat Interface Code 기본 레코드 조회
        /// </summary>
        /// <param name="idicode"></param>
        /// <returns></returns>
        public DataTable GetDefaultColumn(string idicode)
        {
            DataTable dtDiCode = new DataTable("DI_COLUMN");
            DataRow drDiCode;

            dtDiCode.Columns.Add("DICODE", typeof(string));
            dtDiCode.Columns.Add("S_COLUMN_ID", typeof(string));
            dtDiCode.Columns.Add("S_USE_YN", typeof(string));
            dtDiCode.Columns.Add("S_SORT_ORDER", typeof(int));
            dtDiCode.Columns.Add("S_COL_NAME", typeof(string));
            dtDiCode.Columns.Add("S_GRID_WIDTH", typeof(int));
            dtDiCode.Columns.Add("S_INSERTED_YN", typeof(string));

            dtDiCode.Columns.Add("D_COLUMN_ID", typeof(string));
            dtDiCode.Columns.Add("D_USE_YN", typeof(string));
            dtDiCode.Columns.Add("D_SORT_ORDER", typeof(int));
            dtDiCode.Columns.Add("D_COL_NAME", typeof(string));
            dtDiCode.Columns.Add("D_UNIT_REF_ID", typeof(int));
            dtDiCode.Columns.Add("D_DECIMAL_POINTS", typeof(int));
            dtDiCode.Columns.Add("D_GRID_WIDTH", typeof(int));
            dtDiCode.Columns.Add("D_INSERTED_YN", typeof(string));

            for (int i = 1; i < 11; i++)
            {
                drDiCode                     = dtDiCode.NewRow();
                drDiCode["DICODE"]           = idicode;
                drDiCode["S_USE_YN"]         = "N";
                drDiCode["S_SORT_ORDER"]     = 0;
                drDiCode["S_COL_NAME"]       = "";
                drDiCode["S_GRID_WIDTH"]     = 20;
                drDiCode["S_INSERTED_YN"]    = "N";

                drDiCode["D_USE_YN"]         = "N";
                drDiCode["D_SORT_ORDER"]     = 0;
                drDiCode["D_UNIT_REF_ID"]    = 0;
                drDiCode["D_COL_NAME"]       = "";
                drDiCode["D_GRID_WIDTH"]     = 20;
                drDiCode["D_DECIMAL_POINTS"] = 0;
                drDiCode["S_COLUMN_ID"]      = ("SVALUES"+i.ToString());
                drDiCode["D_COLUMN_ID"]      = ("DVALUES"+i.ToString());
                drDiCode["D_INSERTED_YN"]    = "N";

                dtDiCode.Rows.Add(drDiCode);
            }

            return dtDiCode;
        }

        /// <summary>
        /// Dicode 테이블 스키마정보
        /// </summary>
        /// <returns></returns>
        public DataTable GetInsertSchema()
        { 
            DataTable dtDiCode = new DataTable("BSC_INTERFACE_COLUMN");
            dtDiCode.Columns.Add("DICODE", typeof(string));
            dtDiCode.Columns.Add("COLUMN_ID", typeof(string));
            dtDiCode.Columns.Add("COLUMN_ALIAS", typeof(string));
            dtDiCode.Columns.Add("LOV_YN", typeof(string));
            dtDiCode.Columns.Add("SORT_ORDER", typeof(int));
            dtDiCode.Columns.Add("UNIT_REF_ID", typeof(int));
            dtDiCode.Columns.Add("DECIMAL_POINTS", typeof(int));
            dtDiCode.Columns.Add("GRID_WIDTH", typeof(int));
            dtDiCode.Columns.Add("USE_YN", typeof(string));

            return dtDiCode;
        }
    }
}