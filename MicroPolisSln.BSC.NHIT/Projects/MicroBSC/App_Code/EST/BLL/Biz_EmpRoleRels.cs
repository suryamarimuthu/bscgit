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
    public class Biz_EmpRoleRels
    {
        Dac_EmpRoleRels _empRoleRel = new Dac_EmpRoleRels();

	    public Biz_EmpRoleRels()
	    {
		    
	    }

        public DataSet GetEmpRoleRel( int emp_ref_id, int role_ref_id)
        {
            return _empRoleRel.Select(null
                                    , null
                                    , emp_ref_id
                                    , role_ref_id);
        }
         
        public bool AddEmpRoleRel( int emp_ref_id, int role_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _empRoleRel.Insert( null
                                            , null
                                            , emp_ref_id
                                            , role_ref_id);

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool SaveEmpRoleRel(DataTable dataTable, int role_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow     += _empRoleRel.Delete(conn
                                                    , trx
                                                    , 0
                                                    , role_ref_id);
                                            
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    if(_empRoleRel.Select(conn
                                        , trx
                                        , DataTypeUtility.GetToInt32(dataRow["EMP_REF_iD"])
                                        , DataTypeUtility.GetToInt32(dataRow["ROLE_REF_ID"])).Tables[0].Rows.Count == 0)
                    {
                         affectedRow     += _empRoleRel.Insert(conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["EMP_REF_iD"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ROLE_REF_ID"]));
                    }
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
         
        public bool RemoveEmpRoleRel( int emp_ref_id, int role_ref_id)
        {
	        int affectedRow = 0;

            affectedRow = _empRoleRel.Delete( null
                                            , null
                                            , emp_ref_id
                                            , role_ref_id);

            return ( affectedRow > 0 ) ? true : false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("EMP_REF_ID", typeof(int));
            dataTable.Columns.Add("ROLE_REF_ID", typeof(int));

            return dataTable;
        }
    }
}
