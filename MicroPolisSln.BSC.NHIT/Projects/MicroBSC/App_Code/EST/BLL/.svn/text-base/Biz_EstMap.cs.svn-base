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
	public class Biz_EstMap
	{
        private Dac_EstMap _estMap = new Dac_EstMap();

		public Biz_EstMap()
		{

		}

        public DataSet GetEstMap4Valid(int comp_id)
        {
            return _estMap.Select4Valid(comp_id);
        }

		public DataSet GetEstMap(int comp_id, string est_id)
		{
			return _estMap.Select(comp_id, est_id, 0, 0);
		}

		public DataSet GetEstMap(int comp_id)
		{
			return _estMap.Select(comp_id, "", 0, 0 );
		}

        public DataSet GetEstMap(int comp_id, int estterm_ref_id, int estterm_sub_id)
		{
			return _estMap.Select(comp_id, "", estterm_ref_id, estterm_sub_id);
		}

        public DataSet GetEstMap(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id)
		{
			return _estMap.Select(comp_id, est_id, estterm_ref_id, estterm_sub_id);
		}
	}
}