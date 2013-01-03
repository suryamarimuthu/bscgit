using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_RoleMenuRels
    {
        Dac_RoleMenuRels _roleMenuRel = new Dac_RoleMenuRels();

        public Biz_RoleMenuRels()
	    {
		    
	    }

        public DataSet GetRoleMenuRel( int role_ref_id, int menu_ref_id)
        {
            return _roleMenuRel.Select(null
                                    , null
                                    , role_ref_id
                                    , menu_ref_id);
        }
         
        public bool AddRoleMenuRel( int role_ref_id, int menu_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _roleMenuRel.Insert(null
                                            , null
                                            , role_ref_id
                                            , menu_ref_id);

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool SaveRoleMenuRel(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                if (dataTable.Rows.Count > 0)
                {
                    affectedRow += _roleMenuRel.Delete(conn
                                        , trx
                                        , DataTypeUtility.GetToInt32(dataTable.Rows[0]["ROLE_REF_ID"])
                                        , 0);
                }
                                            
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _roleMenuRel.Insert(conn
                                                        , trx
                                                        , DataTypeUtility.GetToInt32(dataRow["ROLE_REF_ID"])
                                                        , DataTypeUtility.GetToInt32(dataRow["MENU_REF_ID"]));
                }

				trx.Commit();
			}
			catch ( Exception ex )
			{
				trx.Rollback();
				return false;
			}
			finally
			{
				conn.Close();
			}

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveRoleMenuRel( int role_ref_id, int menu_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _roleMenuRel.Delete(null
                                            , null
                                            , role_ref_id
                                            , menu_ref_id);

            return ( affectedRow > 0 ) ? true : false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();
           
            dataTable.Columns.Add("ROLE_REF_ID", typeof(int));
            dataTable.Columns.Add("MENU_REF_ID", typeof(int));

            return dataTable;
        }
    }
}
