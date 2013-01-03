using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MicroBSC.Biz.Common.Biz;

public partial class eis_kdgas_SEM_Empl_R001 : EISPageBase
{
    private const int iPosT_LV1   = 139;
    private const int iPosT_LV2   = 203;

    private const int iHeight_LV1 = 19;
    private const int iHeight_LV2 = 172;

    private const int iPosStart_LV2 = 17;

    private const int iWidth_LV1 = 103;
    private const int iWidth_LV2 = 27;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetImageMap();
        }
    }

    public void SetImageMap()
    {
        string[,]  arrUser = new string[,] 
        { 
            {"T","강원구","1990005","62"},
            {"T","이성환","2005004","229"},
            {"T","최기홍","1988004","460"},
            {"T","김진철","2009006","674"},
            {"M","이지수","2004038","17"},
            {"M","서도원","1994001","50"},
            {"M","박재현","1995006","84"},
            {"M","박희재","1996035","118"},
            {"M","안병모","1995002","152"},
            {"M","정진욱","1991012","186"},
            {"M","이정한","1995008","218"},
            {"M","손현익","1992032","251"},
            {"M","김지선","1992035","284"},
            {"M","김상복","1993031","317"},
            {"M","최인환","1990008","350"},
            {"M","김대중","1993020","383"},
            {"M","이종화","1987016","0"},
            {"M","이시영","1984016","0"},
            {"M","홍순혁","1993036","0"},
            {"M","김판상","1991022","0"},
            {"M","김주경","1988010","0"},
            {"M","손창민","1991018","0"},
            {"M","한영채","1984005","0"},
            {"M","권세장","1986002","0"},
            {"M","김경중","1990007","0"},
            {"M","김동준","1991009","0"},
            {"M","고문열","1996028","0"},   
        };

        ImageMap imgMap = new ImageMap();
        imgMap.ImageUrl = "~/eis_kdgas/경동조직도.jpg";

        RectangleHotSpot hs;
        int iRow     = arrUser.Length / 4;
        int iPosLeft = 0;

        for (int i = 0; i < iRow; i++)
        {
            hs = new RectangleHotSpot();
            hs.AlternateText = arrUser[i,1];
            hs.NavigateUrl   = "SEM_Empl_R002.aspx?EMP_NO=" + arrUser[i,2];

            if (arrUser[i,0].Equals("T"))
            {
                hs.Left   = int.Parse(arrUser[i,3]);
                hs.Top    = iPosT_LV1;
                hs.Right  = hs.Left   + iWidth_LV1;
                hs.Bottom = iPosT_LV1 + iHeight_LV1;
            }
            else
            {
                iPosLeft  += (iPosLeft == 0) ? iPosStart_LV2 : 33;
                hs.Left   = iPosLeft;
                hs.Top    = iPosT_LV2;
                hs.Right  = hs.Left   + iWidth_LV2;
                hs.Bottom = iPosT_LV2 + iHeight_LV2;
            }
            
            imgMap.HotSpots.Add(hs);
        }

        tdDigm.Controls.Add(imgMap);
    }
}
