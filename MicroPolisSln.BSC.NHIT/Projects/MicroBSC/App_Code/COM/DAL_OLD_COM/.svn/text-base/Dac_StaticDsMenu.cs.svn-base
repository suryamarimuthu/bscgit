using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.Text;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.RolesBasedAthentication;


public sealed class StaticDsMenu
{
    private const string StaticDsMenuCache  = "StaticDsMenuCache";
    private static string StaticEmpRefID;


    public enum Tables
    {
        MENU_REF_ID = 0,
        MENU_NAME,
        MENU_SORT,
        UP_MENU_ID,
        MENU_DIR,
        MENU_PAGE_NAME,
        MENU_PARAM,
        MENU_FULL_PATH
    }
    

    #region Properties & Fields

    private static DataSet StaticMenu
    {
        get
        {
            Cache oCache = HttpContext.Current.Cache;
            DataSet ds = (DataSet)oCache[StaticDsMenuCache];

            if (ds == null)
            {
                ds = CacheStaticData();                
            }

            return ds;
        }        
    }

    /// <summary>
    /// Clear the Static Data from the Cache
    /// </summary>
    public static void ClearCache()
    {
        Cache oCache = HttpContext.Current.Cache;
        oCache.Remove("StaticDsMenuCache");
    }

    /// <summary>
    /// Cache Static Data
    /// </summary>
    public static DataSet CacheStaticData()
    {
        Cache oCache = System.Web.HttpContext.Current.Cache;

        // Get Static DataSet
        DataSet ds = GetDataSet();
        // Insert into cache
        oCache.Insert(StaticDsMenuCache, ds, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration);

        return ds;
    }

    public static DataSet GetData(string asEmpRefID)
    {
        StaticEmpRefID = asEmpRefID;

        return StaticMenu;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Get Static data from database
    /// </summary>
    /// <returns></returns>
    private static DataSet GetDataSet()
    {
        IDataReader dr = null;
        DataSet ds = new DataSet();
        try
        {
            Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
            dr = biz.GetAuthReadMenu(StaticEmpRefID);
            ds.Load(dr, LoadOption.OverwriteChanges, GetDataTablesValuesArray());

            return ds;
        }
        finally
        {
            if (dr != null && !dr.IsClosed)
            {
                dr.Close();
            }
        }
    }

    /// <summary>
    /// Helper method to return an string array of the values in the Tables enum
    /// </summary>
    /// <returns></returns>
    private static string[] GetDataTablesValuesArray()
    {
        string[] s = new string[0];
        foreach (Tables value in Enum.GetValues(typeof(Tables)))
        {
            Array.Resize(ref s, s.Length + 1);
            s.SetValue(value.ToString(), s.Length - 1);
        }
        return s;
    }

    #endregion
}


