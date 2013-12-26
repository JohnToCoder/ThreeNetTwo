using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using System.IO;

namespace ThreeNetTwo.Class
{
    public class Music
    {
        /// <summary>
        /// 函數名稱：Add_Music
        /// 功能：新增專輯信息
        /// 開發人員：郭世麗
        /// 開發日期：2011-3-17 
        /// </summary>
        /// <param name="strMusicName"></param>
        /// <param name="strType"></param>
        /// <param name="strUrl"></param>
        /// <param name="strComeOut"></param>
        /// <param name="strSinger"></param>
        /// <param name="strArea"></param>
        /// <param name="strMediaSource"></param>
        /// <returns></returns>
        public static string Add_Album(string strAlbumName, string strType, string strUrl, string strComeOut, string strSinger, string strMediaSource)
        {
                        
            SqlParameter[] param1 ={
                                    new SqlParameter("@flag",24),
                                    new SqlParameter("@AlbumName",strAlbumName)
                                  };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param1);

            if (dt.Rows.Count > 0)
            {
                return "Double";
            }
           
            return "../Music/MD_Album.aspx?KeyValue=Add";                  
            
        }
        /// <summary>
        /// 函數名稱：Edit_Album
        /// 函數功能：修改專輯信息
        /// </summary>
        public static string Edit_Album(string strAlbumName,string strAlbumID, string strType, string strUrl, string strComeOut, string strSinger, string strMediaSource, string strPageIndex)
        {
            try
            {

                SqlParameter[] param ={
                                  new SqlParameter("@flag",39),
                                  new SqlParameter("@AlbumName",strAlbumName),
                                  new SqlParameter("@AlbumID",strAlbumID)
                             };
                DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_Music_sp]", param);

                if (table.Rows.Count > 0)
                {
                    return "Double";
                }
            }
            catch
            { }
            return "../Music/MD_Album.aspx?KeyValue=Update&strIndex=" + strPageIndex;
        }
        /// <summary>
        /// 函數名稱：Edit_Music
        /// 函數功能：修改歌曲信息
        /// </summary>
        /// <param name="strMusicName"></param>
        /// <param name="strType"></param>
        /// <param name="strUrl"></param>
        /// <param name="strComeOut"></param>
        /// <param name="strSinger"></param>
        /// <param name="strArea"></param>
        /// <param name="strMediaSource"></param>
        /// <returns></returns>
        public static string Edit_Music(string strMusicName, string strAlbumName, string strType, string strUrl, string strComeOut, string strSinger, string strMusicID, string strPageIndex,string strOrder)
        {
            try
            {
                SqlParameter[] param ={
                                  new SqlParameter("@flag",40),
                                  new SqlParameter("@MusicName",strMusicName),
                                  new SqlParameter("@MusicID",strMusicID),
                                  new SqlParameter("@AlbumID",strAlbumName)
                             };
                DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_Music_sp]", param);

                if (table.Rows.Count > 0)
                {
                    return "Double";
                }

                SqlParameter[] param2 ={
                                    new SqlParameter("@flag",41),
                                    new SqlParameter("@OrderId",strOrder),
                                    new SqlParameter("@MusicAlbumID",strAlbumName)
                                  };
                DataTable dt2 = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param2);

                if (dt2.Rows.Count > 0)
                {
                    return "Exist";
                }
                else
                {
                    SqlParameter[] param1 ={
                                  new SqlParameter("@flag",26),
                                  new SqlParameter("@MusicName",strMusicName),
                                  new SqlParameter("@MusicAlbumID",strAlbumName),
                                  new SqlParameter("@MusicURL",strUrl),
                                  new SqlParameter("@MusicClassID",strType),                                 
                                  new SqlParameter("@ComeOut",strComeOut),
                                  new SqlParameter("@OrderId",strOrder),
                                  new SqlParameter("@Creator",strSinger),
                                  new SqlParameter("@MusicID",strMusicID)
                             };
                    ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param1);
                }
                
            }
            catch { }

            return "../Music/MD_Music.aspx?KeyValue=Update&AlbumID=" + strAlbumName + "&strIndex=" + strPageIndex;

        }

        /// <summary>
        /// 函數名稱：Delete_Album
        /// 功能：刪除專輯信息
        /// 開發人員：郭世麗
        /// 開發日期：2011-3-18 
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_Album(string[] strParameter)
        {
            //獲取登陸用戶信息
            User objUser = HttpContext.Current.Session["User"] as User;

            //刪除本地圖片以及數據庫數據
            string basePath = Common.GetImagePath("Music");
            string strSql = string.Empty;
            string strSql1 = string.Empty;
            string strSql2 = string.Empty;
            for (int j = 1; j < strParameter.Length; j++)
            {
                //判斷要刪除的專輯里有無歌曲
                strSql1 = "exec [MD_Music_sp] 31," + "@MusicID='" + strParameter[j].Trim() + "'";

                DataTable dt1 = ObjCon.MSSQL.ExectuteDataTable(CommandType.Text, strSql1);

                if (dt1.Rows.Count > 0)
                {
                    return "Use";
                }
                //判斷要刪除的專輯是否加入到我的收藏中
                strSql2= "exec [MD_Music_sp] 37," + "@MusicID='" + strParameter[j].Trim() + "'";

                DataTable dt3= ObjCon.MSSQL.ExectuteDataTable(CommandType.Text, strSql2);
                if(dt3.Rows.Count>0)
                {
                  return "UserAdd";
                }
                else
                {
                    strSql1 = string.Empty;

                    strSql1 = "exec [MD_Music_sp] 30," + "@MusicID='" + strParameter[j].Trim() + "'";
                    DataTable dt2 = ObjCon.MSSQL.ExectuteDataTable(CommandType.Text, strSql1);

                    string imgPath = dt2.Rows[0]["ImgPath"].ToString();

                    if (!string.IsNullOrEmpty(imgPath))
                    {
                        try
                        {
                            System.IO.File.Delete(basePath + imgPath);
                        }
                        catch { }
                    }
                }
            }
          
            //刪除數據庫
            strSql = string.Empty;
            try
            {
                for (int i = 1; i < strParameter.Length; i++)
                {
                    strSql = strSql + "exec MD_Music_sp 22," + "@MusicID='" + strParameter[i].Trim() + "',@Creator1='" + objUser.UserCode + "'";
                }
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
            }
            catch { }

            return "../Music/MD_Album.aspx?KeyValue=Delete";
        }

        /// <summary>
        /// 函數名稱：Delete_Music
        /// 功能：刪除音樂信息
        /// 開發人員：郭世麗
        /// 開發日期：2011-3-18  
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_Music(string[] strParameter)
        {
            //獲取登陸用戶信息
            User objUser = HttpContext.Current.Session["User"] as User;

            string strSql = string.Empty;
            string strSql1 = string.Empty;
        
             for (int j = 1; j < strParameter.Length-1; j++)
            {               
                //判斷要刪除的音樂是否加入到我的收藏中
                strSql1= "exec [MD_Music_sp] 38," + "@MusicID='" + strParameter[j].Trim() + "'";
                DataTable dt1= ObjCon.MSSQL.ExectuteDataTable(CommandType.Text, strSql1);
                if(dt1.Rows.Count>0)
                {
                  return "UserAdd";
                }
             } 
            try
            {        
            
                for (int i = 1; i < strParameter.Length-1; i++)
                {
                    strSql = strSql + "exec MD_Music_sp 27," + "@MusicID='" + strParameter[i].Trim() + "',@Creator1='" + objUser.UserCode+"'";
                }
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
            }
           
            catch { }

            return "../Music/MD_Music.aspx?KeyValue=Delete&AlbumID=" + strParameter[strParameter.Length-1];
            
        }

        /// <summary>
        /// 函數名稱：Add_Music
        /// 功能：新增音樂信息
        /// 開發人員：郭世麗
        /// 開發日期：2011-3-18  
        /// </summary>
        /// <param name="strMusicName"></param>
        /// <param name="strAlbum"></param>
        /// <param name="strType"></param>
        /// <param name="strUrl"></param>
        /// <param name="strComeOut"></param>
        /// <param name="strSinger"></param>
        /// <param name="strArea"></param>
        /// <returns></returns>
        public static string Add_Music(string strMusicName,string strAlbum, string strType, string strUrl, string strComeOut, string strSinger,string strOrder)
        {
            //獲取登陸用戶信息
            User objUser = HttpContext.Current.Session["User"] as User;

            SqlParameter[] param1 ={
                                    new SqlParameter("@flag",29),
                                    new SqlParameter("@MusicName",strMusicName),
                                    new SqlParameter("@MusicAlbumID",strAlbum)
                                  };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param1);

            if (dt.Rows.Count > 0)
            {
                return "Double";
            }

            SqlParameter[] param2 ={
                                    new SqlParameter("@flag",41),
                                    new SqlParameter("@OrderId",strOrder),
                                    new SqlParameter("@MusicAlbumID",strAlbum)
                                  };
            DataTable dt2 = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param2);

            if (dt2.Rows.Count > 0)
            {
                return "Exist";
            }

            try
            {
                SqlParameter[] param ={
                                  new SqlParameter("@flag",25),
                                  new SqlParameter("@MusicName",strMusicName),
                                  new SqlParameter("@MusicAlbumID",strAlbum),
                                  new SqlParameter("@MusicURL",strUrl),
                                  new SqlParameter("@MusicClassID",strType),                                 
                                  new SqlParameter("@ComeOut",strComeOut),
                                  new SqlParameter("@OrderId",strOrder),
                                  new SqlParameter("@Creator",strSinger),
                                  new SqlParameter("@Creator1",objUser.UserCode)
                             };
                ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param);


            }
            catch
            {

            }
            return "../Music/MD_Music.aspx?KeyValue=Add&AlbumID=" + strAlbum;    
        }
        /// <summary>
        /// 根據專輯名稱獲得專輯ID
        /// </summary>
        /// <param name="strAlbumName"></param>
        /// <returns></returns>
        public static int GetAlbumID(string strAlbumName)
        {
            SqlParameter[] param ={
                               new SqlParameter("@flag",33),
                               new SqlParameter("@AlbumName",strAlbumName)                              
                              };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param);

            int intAlbumID = Convert.ToInt32(dtb.Rows[0].ItemArray[0].ToString());
            return intAlbumID; 
        }
        /// <summary>
        /// 根據音樂名稱獲得音樂的ID
        /// </summary>
        /// <param name="strMusicName"></param>
        /// <returns></returns>
        public static int GetMusicID(string strMusicName)
        {
            SqlParameter[] param ={
                               new SqlParameter("@flag",36),
                               new SqlParameter("@MusicName",strMusicName)                              
                              };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param);

            int intMusicID = Convert.ToInt32(dtb.Rows[0].ItemArray[0].ToString());
            return intMusicID; 
        }
    }
}
