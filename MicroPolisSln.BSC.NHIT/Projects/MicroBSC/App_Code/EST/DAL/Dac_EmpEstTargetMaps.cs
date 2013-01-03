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

namespace MicroBSC.Estimation.Dac
{
    public class Dac_EmpEstTargetMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , string status_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_EMP_EST_TARGET_MAP
                                SET	STATUS_ID           = @STATUS_ID
                                    ,UPDATE_DATE        = @UPDATE_DATE
                                    ,UPDATE_USER        = @UPDATE_USER
                                WHERE	COMP_ID         = @COMP_ID
                                    AND EST_ID          = @EST_ID
                                    AND	ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND	ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
                                    AND	ESTTERM_STEP_ID = @ESTTERM_STEP_ID
                                    AND	EST_DEPT_ID     = @EST_DEPT_ID
                                    AND	EST_EMP_ID      = @EST_EMP_ID
                                    AND	TGT_DEPT_ID     = @TGT_DEPT_ID
                                    AND	TGT_EMP_ID      = @TGT_EMP_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8]       = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 12);
            paramArray[8].Value = status_id;
            paramArray[9]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[9].Value = update_date;
            paramArray[10]      = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[10].Value = update_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object emp_ref_ids)
        {
            string query = @"UPDATE EST_EMP_EST_TARGET_MAP
	                            SET  TGT_DEPT_ID        = ED.DEPT_REF_ID
                                    ,TGT_POS_CLS_ID		= PC.POS_CLS_ID
		                            ,TGT_POS_CLS_NAME	= PC.POS_CLS_NAME
		                            ,TGT_POS_DUT_ID		= PD.POS_DUT_ID
		                            ,TGT_POS_DUT_NAME	= PD.POS_DUT_NAME
		                            ,TGT_POS_GRP_ID		= PG.POS_GRP_ID
		                            ,TGT_POS_GRP_NAME	= PG.POS_GRP_NAME
		                            ,TGT_POS_RNK_ID		= PR.POS_RNK_ID
		                            ,TGT_POS_RNK_NAME	= PR.POS_RNK_NAME
		                            ,TGT_POS_KND_ID		= PK.POS_KND_ID
		                            ,TGT_POS_KND_NAME	= PK.POS_KND_NAME
                                FROM				COM_DEPT_INFO		ED 
	                                JOIN			REL_DEPT_EMP		RD ON (ED.DEPT_REF_ID			= RD.DEPT_REF_ID)
	                                JOIN			COM_EMP_INFO		CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
                                    LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
                                    LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
                                    LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
		                            JOIN EST_EMP_EST_TARGET_MAP			TM ON (CE.EMP_REF_ID			= TM.TGT_EMP_ID)
	                            WHERE		TM.COMP_ID			= @COMP_ID
			                            AND TM.ESTTERM_REF_ID	= @ESTTERM_REF_ID
			                            AND TM.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
			                            AND CE.EMP_REF_ID IN (" + emp_ref_ids.ToString() + ")";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = estterm_ref_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_sub_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object emp_ref_ids
                        , string type)
        {
            string query = "";

            if(type.Equals("POS"))
                query = @"UPDATE EST_EMP_EST_TARGET_MAP
	                            SET  TGT_POS_CLS_ID		= PC.POS_CLS_ID
		                            ,TGT_POS_CLS_NAME	= PC.POS_CLS_NAME
		                            ,TGT_POS_DUT_ID		= PD.POS_DUT_ID
		                            ,TGT_POS_DUT_NAME	= PD.POS_DUT_NAME
		                            ,TGT_POS_GRP_ID		= PG.POS_GRP_ID
		                            ,TGT_POS_GRP_NAME	= PG.POS_GRP_NAME
		                            ,TGT_POS_RNK_ID		= PR.POS_RNK_ID
		                            ,TGT_POS_RNK_NAME	= PR.POS_RNK_NAME
		                            ,TGT_POS_KND_ID		= PK.POS_KND_ID
		                            ,TGT_POS_KND_NAME	= PK.POS_KND_NAME
                                FROM				COM_DEPT_INFO		DI 
	                                JOIN			REL_DEPT_EMP		RD ON (DI.DEPT_REF_ID			= RD.DEPT_REF_ID)
	                                JOIN			COM_EMP_INFO		CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
                                    LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
                                    LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
                                    LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
		                            JOIN EST_EMP_EST_TARGET_MAP			TM ON (CE.EMP_REF_ID			= TM.TGT_EMP_ID)
	                            WHERE		TM.COMP_ID			= @COMP_ID
			                            AND TM.ESTTERM_REF_ID	= @ESTTERM_REF_ID
			                            AND TM.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
			                            AND CE.EMP_REF_ID IN (" + emp_ref_ids.ToString() + ")";
            else if(type.Equals("DPT"))
                query = @"UPDATE EST_EMP_EST_TARGET_MAP
	                            SET  TGT_DEPT_ID        = DI.DEPT_REF_ID
                                FROM				COM_DEPT_INFO		DI 
	                                JOIN			REL_DEPT_EMP		RD ON (DI.DEPT_REF_ID			= RD.DEPT_REF_ID)
	                                JOIN			COM_EMP_INFO		CE ON (RD.EMP_REF_ID			= CE.EMP_REF_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
                                    LEFT OUTER JOIN	EST_POSITION_DUT	PD ON (CE.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
                                    LEFT OUTER JOIN	EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
                                    LEFT OUTER JOIN	EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
		                            JOIN EST_EMP_EST_TARGET_MAP			TM ON (CE.EMP_REF_ID			= TM.TGT_EMP_ID)
	                            WHERE		TM.COMP_ID			= @COMP_ID
			                            AND TM.ESTTERM_REF_ID	= @ESTTERM_REF_ID
			                            AND TM.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
			                            AND CE.EMP_REF_ID IN (" + emp_ref_ids.ToString() + ")";


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = estterm_ref_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_sub_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , OwnerType ownerType)
        {
            string query = @"SELECT	 TM.COMP_ID
                                    ,TM.EST_ID
	                                ,TM.ESTTERM_REF_ID
	                                ,TM.ESTTERM_SUB_ID
	                                ,TM.ESTTERM_STEP_ID
                                    ,ET.ESTTERM_STEP_NAME
	                                ,TM.EST_DEPT_ID
                                    ,ED1.DEPT_NAME              AS EST_DEPT_NAME
	                                ,TM.EST_EMP_ID
                                    ,CE1.EMP_NAME               AS EST_EMP_NAME
                                    ,CE1.POSITION_CLASS_CODE    AS EST_POS_CLS_ID
                                    ,PC.POS_CLS_NAME            AS EST_POS_CLS_NAME
		                            ,CE1.POSITION_DUTY_CODE     AS EST_POS_DUT_ID
                                    ,PD.POS_DUT_NAME            AS EST_POS_DUT_NAME
		                            ,CE1.POSITION_GRP_CODE      AS EST_POS_GRP_ID
                                    ,PG.POS_GRP_NAME            AS EST_POS_GRP_NAME
		                            ,CE1.POSITION_RANK_CODE     AS EST_POS_RNK_ID
		                            ,PR.POS_RNK_NAME            AS EST_POS_RNK_NAME
                                    ,CE1.POSITION_KIND_CODE     AS EST_POS_KND_ID
		                            ,PK.POS_KND_NAME            AS EST_POS_KND_NAME
	                                ,TM.TGT_DEPT_ID
                                    ,ED2.DEPT_NAME              AS TGT_DEPT_NAME
	                                ,TM.TGT_EMP_ID
                                    ,CE2.EMP_NAME               AS TGT_EMP_NAME
                                    ,TM.TGT_POS_CLS_ID
                                    ,TM.TGT_POS_CLS_NAME
		                            ,TM.TGT_POS_DUT_ID
                                    ,TM.TGT_POS_DUT_NAME
		                            ,TM.TGT_POS_GRP_ID
                                    ,TM.TGT_POS_GRP_NAME
		                            ,TM.TGT_POS_RNK_ID
		                            ,TM.TGT_POS_RNK_NAME
                                    ,TM.TGT_POS_KND_ID
		                            ,TM.TGT_POS_KND_NAME
                                    ,TM.DIRECTION_TYPE
                                    ,EM.FIXED_WEIGHT_YN
	                                ,TM.STATUS_ID
	                                ,TM.CREATE_DATE
	                                ,TM.CREATE_USER
	                                ,TM.UPDATE_DATE
	                                ,TM.UPDATE_USER
                                FROM	            EST_EMP_EST_TARGET_MAP TM
                                    LEFT OUTER JOIN COM_DEPT_INFO          ED1      ON (TM.EST_DEPT_ID          = ED1.DEPT_REF_ID)
                                    LEFT OUTER JOIN COM_DEPT_INFO          ED2      ON (TM.TGT_DEPT_ID          = ED2.DEPT_REF_ID)
                                    LEFT OUTER JOIN COM_EMP_INFO           CE1      ON (TM.EST_EMP_ID           = CE1.EMP_REF_ID)
                                    LEFT OUTER JOIN COM_EMP_INFO           CE2      ON (TM.TGT_EMP_ID           = CE2.EMP_REF_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	   PC       ON (CE1.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
		                            LEFT OUTER JOIN	EST_POSITION_DUT	   PD       ON (CE1.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
		                            LEFT OUTER JOIN	EST_POSITION_GRP	   PG       ON (CE1.POSITION_GRP_CODE	= PG.POS_GRP_ID)
		                            LEFT OUTER JOIN	EST_POSITION_RNK	   PR       ON (CE1.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	   PK       ON (CE1.POSITION_KIND_CODE	= PK.POS_KND_ID)
                                    JOIN            EST_TERM_STEP          ET       ON (TM.COMP_ID              = ET.COMP_ID
                                                                                    AND TM.ESTTERM_STEP_ID      = ET.ESTTERM_STEP_ID)
                                    JOIN    EST_TERM_STEP_EST_MAP          EM       ON (TM.COMP_ID              = EM.COMP_ID
                                                                                    AND TM.EST_ID               = EM.EST_ID
                                                                                    AND TM.ESTTERM_STEP_ID      = EM.ESTTERM_STEP_ID)
                                WHERE	(TM.COMP_ID         = @COMP_ID              OR @COMP_ID                 = 0)
                                    AND (TM.EST_ID          = @EST_ID               OR @EST_ID                      =''    )
                                    AND	(TM.ESTTERM_REF_ID  = @ESTTERM_REF_ID       OR @ESTTERM_REF_ID          = 0)
                                    AND	(TM.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID       OR @ESTTERM_SUB_ID          = 0)
                                    AND	(TM.ESTTERM_STEP_ID = @ESTTERM_STEP_ID      OR @ESTTERM_STEP_ID         = 0)
                                    AND	(TM.EST_DEPT_ID     = @EST_DEPT_ID          OR @EST_DEPT_ID             = 0)
                                    AND	(TM.EST_EMP_ID      = @EST_EMP_ID           OR @EST_EMP_ID              = 0)
                                    AND	(TM.TGT_DEPT_ID     = @TGT_DEPT_ID          OR @TGT_DEPT_ID             = 0)
                                    AND	(TM.TGT_EMP_ID      = @TGT_EMP_ID           OR @TGT_EMP_ID              = 0)";

            if(ownerType == OwnerType.Dept)
            {
                query += @" AND TM.TGT_EMP_ID < 0";
            }
            else if(ownerType == OwnerType.Emp_User)
            {
                query += @" AND TM.TGT_EMP_ID > 0";
            }

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "EMPESTTARGETMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , string tgt_pos_cls_id
                        , string tgt_pos_cls_name
                        , string tgt_pos_dut_id
                        , string tgt_pos_dut_name
                        , string tgt_pos_grp_id
                        , string tgt_pos_grp_name
                        , string tgt_pos_rnk_id
                        , string tgt_pos_rnk_name
                        , string tgt_pos_knd_id
                        , string tgt_pos_knd_name
                        , string direction_type
                        , string status_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_EMP_EST_TARGET_MAP( COMP_ID
                                                                ,EST_ID
			                                                    ,ESTTERM_REF_ID
			                                                    ,ESTTERM_SUB_ID
			                                                    ,ESTTERM_STEP_ID
			                                                    ,EST_DEPT_ID
			                                                    ,EST_EMP_ID
			                                                    ,TGT_DEPT_ID
			                                                    ,TGT_EMP_ID
                                                                ,TGT_POS_CLS_ID
                                                                ,TGT_POS_CLS_NAME
		                                                        ,TGT_POS_DUT_ID
                                                                ,TGT_POS_DUT_NAME
		                                                        ,TGT_POS_GRP_ID
                                                                ,TGT_POS_GRP_NAME
		                                                        ,TGT_POS_RNK_ID
		                                                        ,TGT_POS_RNK_NAME
                                                                ,TGT_POS_KND_ID
		                                                        ,TGT_POS_KND_NAME
                                                                ,DIRECTION_TYPE
			                                                    ,STATUS_ID
			                                                    ,CREATE_DATE
			                                                    ,CREATE_USER
			                                                    ,UPDATE_DATE
			                                                    ,UPDATE_USER
			                                                    )
		                                                    VALUES	(@COMP_ID
                                                                ,@EST_ID
			                                                    ,@ESTTERM_REF_ID
			                                                    ,@ESTTERM_SUB_ID
			                                                    ,@ESTTERM_STEP_ID
			                                                    ,@EST_DEPT_ID
			                                                    ,@EST_EMP_ID
			                                                    ,@TGT_DEPT_ID
			                                                    ,@TGT_EMP_ID
                                                                ,@TGT_POS_CLS_ID
                                                                ,@TGT_POS_CLS_NAME
		                                                        ,@TGT_POS_DUT_ID
                                                                ,@TGT_POS_DUT_NAME
		                                                        ,@TGT_POS_GRP_ID
                                                                ,@TGT_POS_GRP_NAME
		                                                        ,@TGT_POS_RNK_ID
		                                                        ,@TGT_POS_RNK_NAME
                                                                ,@TGT_POS_KND_ID
		                                                        ,@TGT_POS_KND_NAME
                                                                ,@DIRECTION_TYPE
			                                                    ,@STATUS_ID
			                                                    ,@CREATE_DATE
			                                                    ,@CREATE_USER
			                                                    ,NULL
			                                                    ,NULL
			                                                    )";

            IDbDataParameter[] paramArray = CreateDataParameters(23);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9]       = CreateDataParameter("@TGT_POS_CLS_ID", SqlDbType.NVarChar);
            paramArray[9].Value = tgt_pos_cls_id;
            paramArray[10]       = CreateDataParameter("@TGT_POS_CLS_NAME", SqlDbType.NVarChar);
            paramArray[10].Value = tgt_pos_cls_name;
            paramArray[11]      = CreateDataParameter("@TGT_POS_DUT_ID", SqlDbType.NVarChar);
            paramArray[11].Value= tgt_pos_dut_id;
            paramArray[12]      = CreateDataParameter("@TGT_POS_DUT_NAME", SqlDbType.NVarChar);
            paramArray[12].Value= tgt_pos_dut_name;
            paramArray[13]      = CreateDataParameter("@TGT_POS_GRP_ID", SqlDbType.NVarChar);
            paramArray[13].Value= tgt_pos_grp_id;
            paramArray[14]      = CreateDataParameter("@TGT_POS_GRP_NAME", SqlDbType.NVarChar);
            paramArray[14].Value= tgt_pos_grp_name;
            paramArray[15]      = CreateDataParameter("@TGT_POS_RNK_ID", SqlDbType.NVarChar);
            paramArray[15].Value= tgt_pos_rnk_id;
            paramArray[16]      = CreateDataParameter("@TGT_POS_RNK_NAME", SqlDbType.NVarChar);
            paramArray[16].Value= tgt_pos_rnk_name;
            paramArray[17]      = CreateDataParameter("@TGT_POS_KND_ID", SqlDbType.NVarChar);
            paramArray[17].Value= tgt_pos_knd_id;
            paramArray[18]      = CreateDataParameter("@TGT_POS_KND_NAME", SqlDbType.NVarChar);
            paramArray[18].Value= tgt_pos_knd_name;
            paramArray[19]      = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.NVarChar);
            paramArray[19].Value= direction_type;
            paramArray[20]      = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 12);
            paramArray[20].Value= status_id;
            paramArray[21]      = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[21].Value= create_date;
            paramArray[22]      = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[22].Value= create_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertDataFromTo( IDbConnection conn
                                    , IDbTransaction trx
                                    , int comp_id
                                    , int estterm_ref_id_from
                                    , int estterm_sub_id_from
                                    , int estterm_step_id_from
                                    , int estterm_ref_id_to
                                    , int estterm_sub_id_to
                                    , int estterm_step_id_to
                                    , DateTime create_date
                                    , int create_user)
        {
            string query = @"INSERT INTO EST_EMP_EST_TARGET_MAP( COMP_ID
                                                                ,EST_ID
			                                                    ,ESTTERM_REF_ID
			                                                    ,ESTTERM_SUB_ID
			                                                    ,ESTTERM_STEP_ID
			                                                    ,EST_DEPT_ID
			                                                    ,EST_EMP_ID
			                                                    ,TGT_DEPT_ID
			                                                    ,TGT_EMP_ID
                                                                ,TGT_POS_CLS_ID
                                                                ,TGT_POS_CLS_NAME
		                                                        ,TGT_POS_DUT_ID
                                                                ,TGT_POS_DUT_NAME
		                                                        ,TGT_POS_GRP_ID
                                                                ,TGT_POS_GRP_NAME
		                                                        ,TGT_POS_RNK_ID
		                                                        ,TGT_POS_RNK_NAME
                                                                ,TGT_POS_KND_ID
		                                                        ,TGT_POS_KND_NAME
                                                                ,DIRECTION_TYPE
			                                                    ,STATUS_ID
			                                                    ,CREATE_DATE
			                                                    ,CREATE_USER
			                                                    ,UPDATE_DATE
			                                                    ,UPDATE_USER
			                                                    )
                                                        SELECT	 @COMP_ID
                                                                ,TM.EST_ID
	                                                            ,@ESTTERM_REF_ID_TO
	                                                            ,@ESTTERM_SUB_ID_TO
	                                                            ,@ESTTERM_STEP_ID_TO
	                                                            ,TM.EST_DEPT_ID
	                                                            ,TM.EST_EMP_ID
	                                                            ,TM.TGT_DEPT_ID
	                                                            ,TM.TGT_EMP_ID
                                                                ,TM.TGT_POS_CLS_ID
                                                                ,PC.POS_CLS_NAME
		                                                        ,TM.TGT_POS_DUT_ID
                                                                ,PD.POS_DUT_NAME
		                                                        ,TM.TGT_POS_GRP_ID
                                                                ,PG.POS_GRP_NAME
		                                                        ,TM.TGT_POS_RNK_ID
		                                                        ,PR.POS_RNK_NAME
                                                                ,TM.TGT_POS_KND_ID
		                                                        ,PK.POS_KND_NAME
                                                                ,TM.DIRECTION_TYPE
	                                                            ,TM.STATUS_ID
	                                                            ,@CREATE_DATE
	                                                            ,@CREATE_USER
	                                                            ,NULL
	                                                            ,NULL
                                                            FROM	            EST_EMP_EST_TARGET_MAP TM
                                                                LEFT OUTER JOIN	EST_POSITION_CLS	   PC       ON (TM.TGT_POS_CLS_ID		= PC.POS_CLS_ID)
		                                                        LEFT OUTER JOIN	EST_POSITION_DUT	   PD       ON (TM.TGT_POS_DUT_ID		= PD.POS_DUT_ID)
		                                                        LEFT OUTER JOIN	EST_POSITION_GRP	   PG       ON (TM.TGT_POS_GRP_ID		= PG.POS_GRP_ID)
		                                                        LEFT OUTER JOIN	EST_POSITION_RNK	   PR       ON (TM.TGT_POS_RNK_ID		= PR.POS_RNK_ID)
                                                                LEFT OUTER JOIN	EST_POSITION_KND	   PK       ON (TM.TGT_POS_KND_ID		= PK.POS_KND_ID)
                                                            WHERE	TM.COMP_ID         = @COMP_ID        
                                                                AND (TM.EST_ID         = @EST_ID                OR @EST_ID     =''    )         
                                                                AND	TM.ESTTERM_REF_ID  = @ESTTERM_REF_ID_FROM
                                                                AND	TM.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID_FROM 
                                                                AND	TM.ESTTERM_STEP_ID = @ESTTERM_STEP_ID_FROM";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = "";
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID_FROM", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id_from;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID_FROM", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id_from;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID_FROM", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id_from;
            paramArray[5]       = CreateDataParameter("@ESTTERM_REF_ID_TO", SqlDbType.Int);
            paramArray[5].Value = estterm_ref_id_to;
            paramArray[6]       = CreateDataParameter("@ESTTERM_SUB_ID_TO", SqlDbType.Int);
            paramArray[6].Value = estterm_sub_id_to;
            paramArray[7]       = CreateDataParameter("@ESTTERM_STEP_ID_TO", SqlDbType.Int);
            paramArray[7].Value = estterm_step_id_to;
            paramArray[8]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value = create_date;
            paramArray[9]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[9].Value = create_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object tgt_dept_id
                        , object tgt_emp_id)
        {
            string query = @"DELETE	EST_EMP_EST_TARGET_MAP
                                WHERE	(COMP_ID         = @COMP_ID             OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID              OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID         OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID          OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID     = @TGT_DEPT_ID         OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID      = @TGT_EMP_ID          OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Count( IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object tgt_dept_id
                        , object tgt_emp_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_EMP_EST_TARGET_MAP
                                WHERE	(COMP_ID         = @COMP_ID             OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID              OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID         OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID          OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID     = @TGT_DEPT_ID         OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID      = @TGT_EMP_ID          OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;

            try
            {
               int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}