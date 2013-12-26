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
using System.Collections.Generic;
using System.IO;

namespace ThreeNetTwo.Class
{
    public class Channel
    {
        /// <summary> 
        /// 函數名：CheckBeforeAdding
        /// 函數功能：驗證新增項目是否已經存在
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-17
        /// 修改者：
        /// 修改日期：
        /// </summary>
        public static string CheckBeforeAdding(string channelName)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",28),
                                  new SqlParameter("@ChannelCode",channelName)
                             };
            DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Channels_sp]", param);
            if (table.Rows.Count > 0)
            {
                return "Double";
            }
            return "../Channel/MD_Channel.aspx?KeyValue=Add";
        }

        /// <summary> 
        /// 函數名：UpdateChannel
        /// 函數功能：修改頻道信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-17
        /// 修改者：
        /// 修改日期：
        /// </summary>
        public static string UpdateChannel(string strPageIndex)
        {     
            return "../Channel/MD_Channel.aspx?KeyValue=Update&strIndex=" + strPageIndex;
        }

        /// <summary> 
        /// 函數名：Delete_Channel
        /// 函數功能：刪除頻道信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-17
        /// 修改者：
        /// 修改日期：
        /// </summary>
        public static string Delete_Channel(string[] strParameter)
        {
            //是否在Users_Programs中使用
            for (int i = 1; i < strParameter.Length; i++)
            {
                SqlParameter[] param ={
                                  new SqlParameter("@flag",33),
                                  new SqlParameter("@ID",Convert.ToInt32(strParameter[i]))
                             };
                DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Channels_sp]", param);
                if (dtable.Rows.Count > 0)
                {
                    return dtable.Rows[0]["ChannelID"].ToString();
                }
            }

            //是否在MD_Programs中使用
            for (int i = 1; i < strParameter.Length; i++)
            {
                SqlParameter[] param ={
                                  new SqlParameter("@flag",32),
                                  new SqlParameter("@ID",Convert.ToInt32(strParameter[i]))
                             };
                DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Channels_sp]", param);
                if (dtable.Rows.Count > 0)
                {
                    return dtable.Rows[0]["ChannelID"].ToString();
                }
            }

            for (int i = 1; i < strParameter.Length; i++)
            {
                SaveChannelBeforeDeleting(strParameter[i]);
            }  

            ExecSQL("exec dbo.MD_Channels_sp 25,", strParameter);            
            return "../Channel/MD_Channel.aspx?KeyValue=Deleted";
        }

        /// <summary> 
        /// 函數名：ExecSQL
        /// 函數功能：執行SQL語句
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-18
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private static void ExecSQL(string strSP, string[] strParameter)
        {
            try
            {
                string strSql = string.Empty;
                List<string> OldImgPaths = new List<string>();
                for (int i = 1; i < strParameter.Length; i++)
                {
                    strSql = strSql + strSP + "@ID='" + strParameter[i].Trim() + "';";
                    OldImgPaths.Add(getOldImgPath(strParameter[i].Trim()));
                }
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
                
                string strOldImagePaths = "";
                string strPath = Class.Common.GetImagePath("Channel");
                foreach (string strOldImgPath in OldImgPaths)
                {
                    //目標圖片文件所在路徑
                    strOldImagePaths = strPath + strOldImgPath;
                    if (File.Exists(strOldImagePaths))
                    {
                        File.Delete(strOldImagePaths);
                    }
                }
            }
            catch
            { }
        }

        /// <summary> 
        /// 函數名：getOldImgPath
        /// 函數功能：獲取圖片路徑
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-18
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private static string getOldImgPath(string strKey)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",29),
                                 new SqlParameter("@ID",strKey)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);
            return dtb.Rows[0]["ImgPath"].ToString().Trim();
        }

        /// <summary>
        /// 功能：新增節目檢查
        /// 開發人員：劉鋒
        /// 開發日期：2011-4-7
        /// </summary>
        public static string Check(string channelid, string programname, string playingdate, string playingtime)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",37),
                                  new SqlParameter("@ChannelID",channelid),
                                  new SqlParameter("@ProgramName",programname),
                                  new SqlParameter("@PlayingDate",playingdate),
                                  new SqlParameter("@PlayingTime",playingtime)
                             };
            DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Channels_sp]", param);
            if (table.Rows.Count > 0)
            {
                return "Double";
            }
            else
            {
                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",38),
                                  new SqlParameter("@ChannelID",channelid),
                                  new SqlParameter("@ProgramName",programname),
                                  new SqlParameter("@PlayingDate",playingdate),
                                  new SqlParameter("@PlayingTime",playingtime)
                             };
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[MD_Channels_sp]", param1);
                return "../Channel/MD_ChannelMoreInfo.aspx?KeyValue=Add&ChannelID=" + channelid + "&PlayingDate=" + playingdate;
            }
        }

        /// <summary>        
        /// 函數功能：修改節目信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-17       
        /// </summary>
        public static string UpdateChannelMore(string ChannelID,string KeyID, string ProgramName, string PlayingDate, string PlayingTime)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",43),
                                  new SqlParameter("@ChannelID",ChannelID),
                                  new SqlParameter("@ID",KeyID),
                                  new SqlParameter("@PlayingDate",PlayingDate),
                                  new SqlParameter("@PlayingTime",PlayingTime)
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Channels_sp]", param);
            if (dtable.Rows.Count > 0)
            {
                return "Using";
            }
            else
            {
                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",39),
                                  new SqlParameter("@ChannelID",ChannelID),
                                  new SqlParameter("@ID",KeyID),
                                  new SqlParameter("@ProgramName",ProgramName),
                                  new SqlParameter("@PlayingDate",PlayingDate),
                                  new SqlParameter("@PlayingTime",PlayingTime)
                             };
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[MD_Channels_sp]", param1);
                return "../Channel/MD_ChannelMoreInfo.aspx?KeyValue=Update&ChannelID=" + ChannelID + "&PlayingDate=" + PlayingDate;
            }
        }

        /// <summary>
        /// 函數功能：刪除節目信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-4-8
        /// </summary>
        public static string Delete_ChannelMore(string[] strParameter)
        {
            //是否在Users_Programs中使用
            for (int i = 2; i < strParameter.Length; i++)
            {
                SqlParameter[] param ={
                                  new SqlParameter("@flag",40),
                                  new SqlParameter("@ID",Convert.ToInt32(strParameter[i]))
                             };
                DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Channels_sp]", param);
                if (dtable.Rows.Count > 0)
                {
                    return "Using";
                }
            }

            for (int i = 2; i < strParameter.Length; i++)
            {
                SaveChannelMoreBeforeDeleting(strParameter[i]);              
            } 

            ExecSQLChannelMore("exec dbo.MD_Channels_sp 41,", strParameter);
            return "../Channel/MD_ChannelMoreInfo.aspx?KeyValue=Deleted&ChannelID=" + strParameter[1];
        }

        /// <summary> 
        /// 函數功能：執行SQL語句
        /// 開發者： 劉鋒
        /// 開發日期：2011-4-8
        /// </summary>
        private static void ExecSQLChannelMore(string strSP, string[] strParameter)
        {
            try
            {
                string strSql = string.Empty;
                for (int i = 2; i < strParameter.Length; i++)
                {
                    strSql = strSql + strSP + "@ID='" + strParameter[i].Trim() + "';";
                }
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
            }
            catch
            { }
        }

        /// <summary> 
        /// 函數功能：刪除頻道前保存相關信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-4-12
        /// </summary>
        private static void SaveChannelBeforeDeleting(string id)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",44),
                                  new SqlParameter("@ID",id)                                  
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Channels_sp]", param);

            User objUser = new User();
            objUser = HttpContext.Current.Session["User"] as User;
            string strUserName = objUser.UserName;

            SqlParameter[] param1 ={
                                  new SqlParameter("@flag",45),
                                  new SqlParameter("@ID",id),
                                  new SqlParameter("@ChannelCode",dtable.Rows[0]["ChannelCode"].ToString()),
                                  new SqlParameter("@ChannelDesc",dtable.Rows[0]["ChannelDesc"].ToString()),
                                  new SqlParameter("@ChannelURL",dtable.Rows[0]["ChannelURL"].ToString()),
                                  new SqlParameter("@ChannelURLiPad",dtable.Rows[0]["ChannelURLiPad"].ToString()),
                                  new SqlParameter("@ImgPath",dtable.Rows[0]["ImgPath"].ToString()),
                                  new SqlParameter("@ImgWidth",dtable.Rows[0]["ImgWidth"].ToString()),
                                  new SqlParameter("@ImgHeight",dtable.Rows[0]["ImgHeight"].ToString()),
                                  new SqlParameter("@OffsetWidth",dtable.Rows[0]["OffsetWidth"].ToString()),
                                  new SqlParameter("@OffsetHidth",dtable.Rows[0]["OffsetHidth"].ToString()),
                                  new SqlParameter("@WebURL",dtable.Rows[0]["WebURL"].ToString()),
                                  new SqlParameter("@AreaIDstr",dtable.Rows[0]["AreaID"].ToString()),
                                  new SqlParameter("@ChannelTypeIDstr",dtable.Rows[0]["ChannelTypeID"].ToString()),
                                  new SqlParameter("@Creator",strUserName)
                             };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[MD_Channels_sp]", param1);
        }

        /// <summary> 
        /// 函數功能：刪除節目前保存相關信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-4-12
        /// </summary>
        private static void SaveChannelMoreBeforeDeleting(string id)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",46),
                                  new SqlParameter("@ID",id)                                  
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Channels_sp]", param);

            User objUser = new User();
            objUser = HttpContext.Current.Session["User"] as User;
            string strUserName = objUser.UserName;

            SqlParameter[] param1 ={
                                  new SqlParameter("@flag",47),
                                  new SqlParameter("@ID",id),
                                  new SqlParameter("@ProgramName",dtable.Rows[0]["ProgramName"].ToString()),
                                  new SqlParameter("@PlayingDate",dtable.Rows[0]["PlayingDate"].ToString()),
                                  new SqlParameter("@PlayingTime",dtable.Rows[0]["PlayingTime"].ToString()),
                                  new SqlParameter("@ImgPath",dtable.Rows[0]["ImaPath"].ToString()),
                                  new SqlParameter("@ChannelID",dtable.Rows[0]["ChannelID"].ToString()),
                                  new SqlParameter("@Key1",dtable.Rows[0]["Key1"].ToString()),
                                  new SqlParameter("@Creator",strUserName)
                             };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[MD_Channels_sp]", param1);
        }
    }
}
