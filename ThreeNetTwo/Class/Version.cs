using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace ThreeNetTwo.Class
{
    public class Version
    {
        /// <summary> 
        /// 函數名：CheckBeforeAdding
        /// 函數功能：驗證新增項目是否已經存在
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        public static string CheckBeforeAdding(string version)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",2),
                                  new SqlParameter("@Version",version)
                             };
            DataTable dtbl = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_ServerVersion_sp", param);
            if (dtbl.Rows.Count > 0)
            {
                return "Double";
            }
            return "../Manage/Sys_VersionInfo.aspx?KeyValue=Add";
        }

        /// <summary> 
        /// 函數名：UpdateChannel
        /// 函數功能：修改版本信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        public static string UpdateVersion()
        {
            return "../Manage/Sys_VersionInfo.aspx?KeyValue=Update";
        }

        /// <summary> 
        /// 函數名：Delete_Version
        /// 函數功能：刪除頻道信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        public static string Delete_Version(string[] strParameter)
        {
            for (int i = 1; i < strParameter.Length; i++)
            {
                int id = Convert.ToInt32(strParameter[i]);
                SqlParameter[] param ={
                                  new SqlParameter("@flag",7),
                                  new SqlParameter("@ID",id)
                             };
                DataTable dtbl = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_ServerVersion_sp", param);
                if (dtbl.Rows.Count > 0)
                {
                    return dtbl.Rows[0]["VerDesc"].ToString();
                }
            }

            ExecSQL("exec [dbo].[MD_ServerVersion_sp] 6,", strParameter);
            return "../Manage/Sys_VersionInfo.aspx?KeyValue=Deleted";
        }

        /// <summary> 
        /// 函數名：ExecSQL
        /// 函數功能：執行SQL語句
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private static void ExecSQL(string strSP, string[] strParameter)
        {
            try
            {
                string strSql = string.Empty;
                for (int i = 1; i < strParameter.Length; i++)
                {
                    strSql = strSql + strSP + "@ID='" + strParameter[i].Trim() + "';";
                }
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql); 
            }
            catch
            { }
        }
    }
}
