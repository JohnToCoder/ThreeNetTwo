using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace ThreeNetTwo.Class
{
    public class Photo
    {
        /// <summary>
        /// 函數名稱：Add_Photo
        /// 功能：新增相冊圖片信息
        /// 開發人員：胡貴
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="strImageName"></param>
        /// <param name="strPictureCatalog"></param>
        /// <param name="strImagePath"></param>
        /// <returns></returns>
        public static string Add_Photo(string strImageName, string strPictureCatalog, string strImagePath)
        {
            //獲取登陸用戶信息
            User objUser = HttpContext.Current.Session["User"] as User;
            string strDBpath = "";

            //驗證數據庫資料動作
            SqlParameter[] param1 ={
                                  new SqlParameter("@flag",11),
                                  new SqlParameter("@ImageName",strImageName)
                             };
            DataTable dt1 = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[User_Photo_sp]", param1);
            if (dt1.Rows.Count > 0)
            {
                return "Exits";
            }

            //插入數據庫以及上傳圖片動作
            try
            {
                //上傳圖片類型
                string strImageType = strImagePath.Substring(strImagePath.LastIndexOf("."));

                SqlParameter[] param2 ={
                                  new SqlParameter("@flag",12),
                                  new SqlParameter("@ImageName",strImageName),
                                  new SqlParameter("@PicClassID",strPictureCatalog),
                                  new SqlParameter("@ImageType",strImageType),
                                  new SqlParameter("@Creator",objUser.UserCode)

                             };
                //回傳相冊圖片地址
                DataTable dt2 = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[User_Photo_sp]", param2);

                strDBpath = dt2.Rows[0][0].ToString();
                //圖片上傳動作
                //Common.SaveImage(strImagePath, dt2.Rows[0][0].ToString(),"Photo");
            }
            catch
            {
                return "false";
            }

            //刷新頁面動作
            return "../Photo/MD_Photos.aspx?KeyValue=Add" + "^" + strDBpath;
        }

        /// <summary>
        /// 函數名稱：Delete_Photo
        /// 功能：刪除相冊圖片信息
        /// 開發人員：胡貴
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="ArrKeyVal"></param>
        /// <returns></returns>
        public static string Delete_Photo(string[] strParameter)
        {
            //獲取登陸用戶信息
            User objUser = HttpContext.Current.Session["User"] as User;

            //刪除本地圖片以及數據庫數據
            string basePath = Common.GetImagePath("Photo");
            string strSql = string.Empty;

            //從1開始，0為標誌位。
            SqlParameter[] paras = null;
            for (int i = 1, count = strParameter.Length; i < count; i++)
            {
                //判斷是否加入收藏
                paras = new SqlParameter[]{
                          new SqlParameter("@flag",18),
                          new SqlParameter("@ID",strParameter[i].Trim())
                        };
                DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "User_Photo_sp" , paras);
                if(dt.Rows.Count > 0){
                    return "Enjoy";
                }

                strSql = strSql + "exec [User_Photo_sp] 16," + "@ID='" + strParameter[i].Trim() + "'";
            }

            DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.Text, strSql);
            foreach(DataTable dt in ds.Tables)
            {
                string imaPath = dt.Rows[0]["ImaPath"].ToString();
                if (!string.IsNullOrEmpty(imaPath))
                {
                    try
                    {
                        System.IO.File.Delete(basePath + imaPath);
                    }
                    catch { }
                }
            }

            //刪除數據庫
            strSql = string.Empty;
            try
            {
                for (int i = 1; i < strParameter.Length; i++)
                {
                    strSql = strSql + "exec [User_Photo_sp] 15," + "@ID='" + strParameter[i].Trim() + "',@Creator='" + objUser.UserCode + "'";
                }
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
            }
            catch{}

            return "../Photo/MD_Photos.aspx?KeyValue=Del";
        }


        /// <summary>
        /// 函數名稱：Edit_Photo
        /// 功能：修改相冊圖片信息
        /// 開發人員：胡貴
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="strImageName"></param>
        /// <param name="strPCID"></param>
        /// <returns></returns>
        public static string Edit_Photo(string ID, string strImageName, string strPCID)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@flag",17),
                                       new SqlParameter("@ID",ID),
                                       new SqlParameter("@ImageName",strImageName),
                                       new SqlParameter("@PicClassID",strPCID)
                                   };

            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "User_Photo_sp", paras);

            return "../Photo/MD_Photos.aspx?KeyValue=Upd";
        }
    }
}
