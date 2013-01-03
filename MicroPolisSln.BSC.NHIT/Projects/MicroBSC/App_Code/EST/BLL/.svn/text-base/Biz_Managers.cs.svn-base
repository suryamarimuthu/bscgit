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
    public class Biz_Managers
    {
        private Dac_DeptEstDetails _deptEstDetail = new Dac_DeptEstDetails();
        private Dac_DeptPosDetails _deptPosDetail = new Dac_DeptPosDetails();
        private Dac_DeptPosScales  _deptPosScale  = new Dac_DeptPosScales();
        private Dac_RelGroupInfos  _relGroupInfo  = new Dac_RelGroupInfos();
        private Dac_RelGroupDepts  _relGroupDept  = new Dac_RelGroupDepts();
        private Dac_RelGroupPositionInfos _relGroupPosInfo = new Dac_RelGroupPositionInfos();
        private Dac_RelGroupPositionDatas _relGroupPosData = new Dac_RelGroupPositionDatas();
        private Dac_RelGroupTgtMaps _relGroupTgtMap = new Dac_RelGroupTgtMaps();
        private Dac_EmpEstTargetMaps _relEmpEstTgtMap = new Dac_EmpEstTargetMaps();
        private Dac_QuestionDeptEmpMaps _questionDeptEmpMap = new Dac_QuestionDeptEmpMaps();

        public bool CopyEstTermDataFromTo(bool check_1, bool check_2, bool check_3, bool check_4) 
        {
            int affectedRow = 0;

            Dac_QuestionEstMaps questionEstMap      = new Dac_QuestionEstMaps();
            Dac_QuestionSubjects questionSubject    = new Dac_QuestionSubjects();
            Dac_QuestionItems questionItem          = new Dac_QuestionItems();
            Dac_QuestionDatas questionData          = new Dac_QuestionDatas();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                if(check_1) 
                {
                    
                }

                if(check_2) 
                {
                
                }

                if(check_3) 
                {
                
                }

                if(check_4) 
                {
                
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
    }
}
