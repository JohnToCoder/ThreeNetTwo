using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace ThreeNetTwo.Class
{
    public class Movie
    {
        /// <summary>
        /// 函數名稱：Add_Movie
        /// 功能：新增電影信息
        /// 開發人員：沈譚義
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="strDeptCode"></param>
        /// <param name="strDeptDesc"></param>
        /// <param name="strddlParentCode"></param>
        /// <param name="strddlDeptClass"></param>
        /// <returns></returns>
        public static string Add_Movie(string strMovieName, string strType, string strUrl, string strComeOut, string strDesc, string strMediaSource)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",14),
                                  new SqlParameter("@MovieName",strMovieName)
                             };
            DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", param);
            if (table.Rows.Count > 0)
            {
                return "Double";
            }
            return "../Movie/MD_Movie.aspx?KeyValue=Add";
        }
        /// <summary>
        /// 函數名稱：Edit_Movie
        /// 功能：修改電影信息
        /// 開發人員：沈譚義
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="strUserId"></param>
        /// <param name="strUserName"></param>
        /// <param name="strEmail"></param>
        /// <param name="strDept"></param>
        /// <param name="strfuPicture"></param>
        /// <param name="strddlval"></param>
        /// <returns></returns>
        public static string Edit_Movie(string strMovieName, string strType, string strUrl, string strComeOut, string strDesc, string strMediaSource, string strIndex)
        {
            return "../Movie/MD_Movie.aspx?KeyValue=Update&strIndex=" + strIndex;
        }
        /// <summary>
        /// 函數名稱：Delete_Movie
        /// 功能：刪除電影數據
        /// 開發人員：沈譚義
        /// 開發日期：2011-03-16
        /// 
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_Movie(string[] strParameter)
        {
            for (int i = 1; i < strParameter.Length; i++)
            {
                if (!IsExitMyMovie(strParameter[i].Trim()))
                {
                    return "ExistMyMovie";
                }
            }
             //獲取登陸用戶信息
            User objUser = HttpContext.Current.Session["User"] as User;
            //Edit By tanyi 2011-04-12 添加Movie的log信息
            ExecSQL("exec MD_Movies_sp 18,@Creator='"+objUser.UserCode+"',", strParameter);
            //刪除劇照 2011-03-17
            return "../Movie/MD_Movie.aspx?KeyValue=Deleted";
        }
        /// <summary>
        /// 函數名稱：ExecSQLTest Edit by tanyi
        /// 功能：執行SQL語句
        /// 2011.03.16
        /// </summary>
        /// <param name="strSP"></param>
        /// <param name="strParameter"></param>
        private static void ExecSQL(string strSP, string[] strParameter)
        {
            try
            {
                string strSql = string.Empty;

                List<string> OldImgPaths = new List<string>();
                for (int i = 1; i < strParameter.Length; i++)
                {
                    strSql = strSql + strSP + "@MoviesID='" + strParameter[i].Trim() + "'";
                    OldImgPaths.Add(getOldImgPath(strParameter[i].Trim()));
                }
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);

                //Edit By Tanyi 2011.3.17
                string strOldImagePaths = "";
                string strPath = Class.Common.GetImagePath("Movie");
                foreach (string strOldImgPath in OldImgPaths)
                {
                    strOldImagePaths =strPath+ strOldImgPath;
                    if (File.Exists(strOldImagePaths))
                    {
                        File.Delete(strOldImagePaths);
                    }
                }
            }
            catch
            {
            }

        }
        /// <summary>
        /// 判斷電影是否存在我的電影中
        /// Edit By tanyi 2011.3.30
        /// </summary>
        /// <returns></returns>
        private static bool IsExitMyMovie(string strMovieID)
        {

            SqlParameter[] param ={
                                 new SqlParameter("@flag",22),
                                 new SqlParameter("@MoviesID",strMovieID)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", param);
            if (dtb.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 函數名稱：getOldImgPath Edit by tanyi 2011-03-17
        /// 刪除時獲取原圖片的路徑
        /// </summary>
        private static string getOldImgPath(string strKey)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",16),
                                 new SqlParameter("@MoviesID",strKey)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", param);

            return dtb.Rows[0].ItemArray[6].ToString().Trim();
        }
        /// <summary>
        /// 函數名稱:GetMovieID Edit By tanyi 2011-03-17
        /// 根據電影名稱獲取電影ID
        /// </summary>
        /// <returns></returns>
        public static int GetMovieID(string strMovieName)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",20),
                                 new SqlParameter("@MovieName",strMovieName)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", param);

            int intMovieID = Convert.ToInt32(dtb.Rows[0].ItemArray[0].ToString());
            return intMovieID;

        }
    }
}
