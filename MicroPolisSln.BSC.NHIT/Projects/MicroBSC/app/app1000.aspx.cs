using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebGrid;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.RolesBasedAthentication;


public partial class app_app1000 : AppPageBase
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();


        this.UltraWebGrid1.Columns.FromKey("EMP_NAME").Header.Caption = GetText("LBL_00001", "è�Ǿ�");
    }

    #region ������ �ʱ�ȭ �Լ�

        private void SetAllTimeTop()
        {

        }

        private void InitControlValue()
        {

        }

        private void InitControlEvent()
        {

        }

        private void SetPageData()
        {

        }

        private void SetPostBack()
        {

        }

        private void SetAllTimeBottom()
        {

        }

    #endregion


    #region �����Լ�



    #endregion




    #region ���� �̺�Ʈ ó�� �Լ�


    #endregion
    
    
    
   
}
