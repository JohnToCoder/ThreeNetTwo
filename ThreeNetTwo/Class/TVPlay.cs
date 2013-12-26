using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace ThreeNetTwo.Class
{
    public class TVPlay
    {
        /// <summary>
        /// 函數名稱：Add_Movie
        /// 功能：新增電視信息
        /// 開發人員：曹翠華
        /// 開發日期：2011-3-16
        /// </summary>     
        public static string Add_TVPlay(string strTVPlayName, string strType, string strUrl, string strComeOut, string strDesc,  string strMediaSource)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",24),
                                  new SqlParameter("@TVPlayName",strTVPlayName)
                             };
            DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
            if (table.Rows.Count > 0)
            {
                return "Double";
            }
            return "../TVPlay/MD_TVPlay.aspx?KeyValue=Add";
        }
        /// <summary>
        ///函數名稱:Add_TVSub
        ///函數功能: 新增電視劇分集信息
        ///開發者:曹翠華
        ///開發日期:2011/3/31
        /// </summary>       
        public static string Add_TVSub(string strTVSub, string strTVPlayID, string strUrl, string strComeOut, string strDesc)
        {
            SqlParameter[] param = { 
                                    new SqlParameter("@flag",34),
                                    new SqlParameter("@OrderId",strTVSub),
                                    new SqlParameter("@TVPlayID",strTVPlayID)
                                   };
            DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
            if (table.Rows.Count > 0)
            {
                return "Double";
            }
            try
            {
                User objUser = HttpContext.Current.Session["User"] as User;
                SqlParameter[] param1 =
                                  {
                                   new SqlParameter("@flag",35),
                                   new SqlParameter("@OrderId",strTVSub),
                                   new SqlParameter("@TVPlayID",strTVPlayID),
                                   new SqlParameter("@TVPlayURL", strUrl),
                                   new SqlParameter("@ComeOut",strComeOut),
                                   new SqlParameter("@Summary",strDesc),                               
                                   new SqlParameter("@Creator",objUser.UserCode),
                                 };
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param1);
            }
            catch { }
            return "../TVPlay/MD_TVPlayMoreInfo.aspx?KeyValue=Add&TVPlayID=" +strTVPlayID;
        }
        /// <summary>
        /// 函數名稱：Edit_TVPlay
        /// 功能：修改電視信息
        /// 修改人員：曹翠華
        /// 開發日期：2011-3-16
        /// </summary>       
        public static string Edit_TVPlay(string strTVPlayName,string strTVPlayID, string strType, string strUrl, string strComeOut, string strDesc, string strMediaSource, string strPageIndex)
        {
            try
            {
                SqlParameter[] param ={
                                  new SqlParameter("@flag",41),
                                  new SqlParameter("@TVPlayName",strTVPlayName),
                                  new SqlParameter("@TVPlayID",strTVPlayID)
                             };
                DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
                if (table.Rows.Count > 0)
                {
                    return "Double";
                }
            }
            catch { }

            return "../TVPlay/MD_TVPlay.aspx?KeyValue=Update&strIndex=" + strPageIndex;
        }
        /// <summary>
        /// 函數名稱:Edit_TVSub
        /// 函數功能:修改分集信息
        /// 開發人員:曹翠華
        /// 開發日期:2011/3/30
        /// </summary>       
        public static string Edit_TVSub(string strTVSub, string strTVPlayID,string strTVSubID, string strUrl, string strComeOut, string strDesc, string strPageIndex)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",42),
                                  new SqlParameter("@OrderId",strTVSub),
                                  new SqlParameter("@TVPlaySubID",strTVSubID),
                                  new SqlParameter("@TVPlayID",strTVPlayID)
                             };
            DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
            if (table.Rows.Count > 0)
            {
                return "Double";
            }
            try
            {
                 SqlParameter[] param2 =
                                  {
                                   new SqlParameter("@flag",36),
                                   new SqlParameter("@OrderId",strTVSub),
                                   new SqlParameter("@TVPlayID",strTVPlayID),
                                   new SqlParameter("@TVPlaySubID",strTVSubID),
                                   new SqlParameter("@TVPlayURL",strUrl),
                                   new SqlParameter("@ComeOut",strComeOut),
                                   new SqlParameter("@Summary",strDesc)                          
                                   };
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param2);
          }
         catch  { }           
        return "../TVPlay/MD_TVPlayMoreInfo.aspx?KeyValue=Update&TVPlayID=" + strTVPlayID + "&strIndex=" + strPageIndex ;
        }
        /// <summary>
        /// 函數名稱：Delete_TVPlay
        /// 功能：刪除電視劇信息
        /// 開發人員：曹翠華
        /// 開發日期：2011-3-17
        /// </summary>        
        public static string Delete_TVPlay(string[] strParameter)
        {
            for (int i = 1; i < strParameter.Length;i++ )
            {
                if (IsExistMyTVPlay(strParameter[i].Trim()))
                {
                    return "ExistInMyTVPlay";
                }
                if (IsExistTVsub(strParameter[i].Trim()))
                {
                    return "ExistTVsub";
                }
            }
            ExecSQL("exec MD_TVPlay_sp 28",strParameter,"1");
            return "../TVPlay/MD_TVPlay.aspx?KeyValue=Deleted";     
        
        }
        /// <summary>
        /// 函數名稱:Delete_TVSub
        /// 函數功能:刪除電視劇分集信息
        /// 開發人員:曹翠華
        /// 開發日期:2011/3/30
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_TVSub(string[] strParameter)
        {
            try
            {
                for (int i = 1; i < strParameter.Length - 1; i++)
                {
                    if (IsExistMyTVSub(strParameter[i].Trim()))
                    {
                        return "ExistInMyTVSub";
                    }
                }
                ExecSQL("exec MD_TVPlay_sp 38", strParameter,"2");
            }
            catch { }
            return "../TVPlay/MD_TVPlayMoreInfo.aspx?KeyValue=Deleted&TVPlayID=" + strParameter[strParameter.Length-1];;  
        }
         
        /// <summary>
        /// 函數名稱：ExecSQL
        /// 功能：執行SQL刪除電視劇信息
        /// 開發人員：曹翠華
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        private static void ExecSQL(string strSP,string[] strParameter,string Flag)
        {
            try
            {
                string strSql = string.Empty;
                string strSql1=string.Empty;
                //獲取登錄用戶信息
                User objUser = HttpContext.Current.Session["User"] as User;

                List<string> OldImgPaths = new List<string>();
             
                //刪除電視劇名稱
                if (Flag == "1")
                {
                    string strOldImagePaths = "";
                    string strPath = Class.Common.GetImagePath("TVPlay");                    
                    for (int i = 1; i < strParameter.Length; i++)
                    {

                        strSql = strSql + strSP + ",@TVPlayID='" + strParameter[i].Trim() + "',@Creator='" + objUser.UserCode + "'";

                        OldImgPaths.Add(getOldImgPath(strParameter[i].Trim()));

                        ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
                    }
                    //刪除電視劇劇照  
                    foreach (string strOldeImgPath in OldImgPaths)
                    {
                        strOldImagePaths = strPath + strOldeImgPath;
                        if (File.Exists(strOldImagePaths))
                        {
                            File.Delete(strOldImagePaths);
                        }
                    }
                }
                //刪除電視劇分集
                else
                {
                    for (int i = 1; i < strParameter.Length - 1; i++)
                    {

                        strSql1 = strSql1 + strSP + ",@TVPlaySubID='" + strParameter[i].Trim() + "',@Creator='" + objUser.UserCode + "'";
                        ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql1);
                    }
                }               
              
            }
            catch { }
        }
        /// <summary>
        /// 函數名稱:getOldImgPath
        /// 函數功能:刪除時獲取原文件路徑
        /// 開發人員:曹翠華
        /// 開發時間:2011/3/20
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        private static string getOldImgPath(string strKey)
        {
            SqlParameter[] param = {
                                   
                         new SqlParameter("@flag",26),
                         new SqlParameter("@TVPlayID",strKey)
                                   } ;

            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
            return dtb.Rows[0].ItemArray[6].ToString().Trim();        
           }
        /// <summary>
        /// 函數名稱:GetTVPlayID
        /// 函數功能:根據電視劇名稱獲得電視劇ID
        /// 開發人員:曹翠華
        /// 開發時間:2011/3/20
        /// </summary>
        /// <param name="strTVPlayName"></param>
        /// <returns></returns>
        public static int GetTVPlayID(string strTVPlayName)
        {
            SqlParameter[] param ={
                              new SqlParameter("@flag",29),
                              new SqlParameter("@TVPlayName",strTVPlayName)                              
                              };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);

            int intTVPlayID = Convert.ToInt32(dtb.Rows[0].ItemArray[0].ToString());
            return intTVPlayID;        
        }
        /// <summary>
        /// 函數名稱:IsExistMyTVPlay
        /// 函數功能:查找電視劇是否加入我的收藏中
        /// 開發人員:曹翠華
        /// 開發時間:2011/3/30
        /// </summary>
        /// <param name="strTVPlayID"></param>
        /// <returns></returns>
        private static bool IsExistMyTVPlay(string strTVPlayID)
        {
            SqlParameter[] param = { 
                                     new SqlParameter("@flag",31),
                                     new SqlParameter("@TVPlayID",strTVPlayID)                                   
                                   };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
            if (dtb.Rows.Count > 0)
            {
                return  true;
            }
            return  false;
        }
        /// <summary>
        /// 函數名稱:IsExistTVsub
        /// 函數功能:查找電視劇中是否存在分集
        /// 開發人員:曹翠華
        /// 開發日期:2011/4/6
        /// </summary>
        /// <param name="strTVPlayID"></param>
        /// <returns></returns>
        private static bool IsExistTVsub(string strTVPlayID)
        {
            SqlParameter[] param ={
                                new SqlParameter("@flag",40),
                                new SqlParameter("@TVPlayID",strTVPlayID)                              
                                };
            DataTable dt1 = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
            if (dt1.Rows.Count > 0)
            {
                return true;
            }
            return false;        
        }
        /// <summary>
        /// 函數名稱:IsExistMyTVSub
        /// 函數功能:查找電視劇分集是否加入我的收藏
        /// 開發人員:曹翠華
        /// 開發日期:2011/3/31
        /// </summary>      
        private static bool IsExistMyTVSub(string strTVSubID)
        {
            SqlParameter[] param = { 
                                     new SqlParameter("@flag",37),
                                     new SqlParameter("@TVPlaySubID",strTVSubID)                                   
                                   };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
            if (dtb.Rows.Count > 0)
            {
                return true;
            }
            return false;        
        }
    }
}