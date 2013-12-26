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
    public class Users
    {
        /// <summary>
        /// 函數名稱：Add_Users
        /// 功能：新增用戶
        /// 開發人員：劉洪彬
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="strDeptCode"></param>
        /// <param name="strDeptDesc"></param>
        /// <param name="strddlParentCode"></param>
        /// <param name="strddlDeptClass"></param>
        /// <returns></returns>
        public static string Add_Users(string strUserCode)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",8),
                                  new SqlParameter("@UserCode",strUserCode)
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);
            if (dtable.Rows.Count > 0)
            {
                return "Double";
            }
            return "../Manage/Sys_UsersManage.aspx?KeyValue=Add";
        }


        /// <summary>
        /// 函數名稱：Edit_Users
        /// 功能：修改電影信息
        /// 開發人員：劉洪彬
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="strUserId"></param>
        /// <param name="strUserName"></param>
        /// <param name="strEmail"></param>
        /// <param name="strDept"></param>
        /// <param name="strfuPicture"></param>
        /// <param name="strddlval"></param>
        /// <returns></returns>
        public static string Edit_Users(string strUserCode,int intID)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",12),
                                  new SqlParameter("@ID",intID),
                                  new SqlParameter("@UserCode",strUserCode)

                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);
            if (dtable.Rows.Count > 0)
            {
                return "Double";
            }
            else
            {
                return "../Manage/Sys_UsersManage.aspx?KeyValue=Update";
            }
        }

        /// <summary>
        /// 函數名稱：Delete_Users
        /// 功能：刪除電影數據
        /// 開發人員：劉洪彬
        /// 開發日期：2011-03-16
        /// 
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_Users(string[] strParameter)
        {

            ExecSQL("exec Sys_UsersManage_sp 6,", strParameter);
            return "../Manage/Sys_UsersManage.aspx?KeyValue=Deleted";
        }

        /// <summary>
        /// 函數名稱：ExecSQL Edit by 劉洪彬
        /// 功能：執行SQL語句
        /// 2011.03.16
        /// </summary>
        /// <param name="strSP"></param>
        /// <param name="strParameter"></param>
        private static void ExecSQL(string strSP, string[] strParameter)
        {
            string strSql = string.Empty;
            string strbasePath = HttpContext.Current.Server.MapPath("../Manage/PicFile/");
            //從1開始，0為標誌位。
            for (int i = 1, count = strParameter.Length; i < count; i++)
            {
                strSql = strSql + "exec [Sys_UsersManage_sp] 13," + "@ID='" + strParameter[i].Trim() + "'";
            }

            DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.Text, strSql);
            foreach (DataTable dt in ds.Tables)
            {
                string strimgPath = dt.Rows[0]["ImgPath"].ToString();
                if (!string.IsNullOrEmpty(strimgPath))
                {
                    try
                    {
                        System.IO.File.Delete(strbasePath + strimgPath);
                    }
                    catch { }
                }
            }

            strSql = string.Empty;
            try
            {
                for (int i = 1; i < strParameter.Length; i++)
                {
                    strSql = strSql + strSP + "@ID='" + strParameter[i].Trim() + "'";
                }
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
            }
            catch { }
        }


        /// <summary>
        /// 函數名稱:GetUsersID Edit By 劉洪彬 2011-03-17
        /// 根據電影名稱獲取電影ID
        /// </summary>
        /// <returns></returns>
        public static int GetUsersID(string strUserCode)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",10),
                                 new SqlParameter("@UserCode",strUserCode)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[Sys_UsersManage_sp]", param);

            int intID = Convert.ToInt32(dtb.Rows[0].ItemArray[0].ToString());
            return intID;

        }
       
    }
}
