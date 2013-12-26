using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Class
{
    public class Mac
    {

        public static string Add_Mac(string strMac, string strMeno, string strUserName, string strTel, string strMobile, string strRole, string strUserId, string strSex, string strBirDay, string strEmail, string strAddress)
        {

            User objUser = new User();
            objUser = HttpContext.Current.Session["User"] as User;

            SqlParameter[] param ={
                                  new SqlParameter("@flag",6),
                                  new SqlParameter("@MAC",strMac)
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_MAC_sp", param);
            if (dtable.Rows.Count > 0)
            {
                return "Double";
            }

            else
            {

                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",2),
                                  new SqlParameter("@MAC",strMac),
                                  new SqlParameter("@Meno",strMeno),
                                  new SqlParameter("@UserName",strUserName),
                                  new SqlParameter("@Tel",strTel),
                                  new SqlParameter("@Mobile",strMobile),
                                  new SqlParameter("@MacRoleDesc",strRole),
                                  new SqlParameter("@UserId",strUserId),
                                  new SqlParameter("@Sex",strSex),
                                  new SqlParameter("@BirthDay",strBirDay),
                                  new SqlParameter("@Address",strAddress),
                                  new SqlParameter("@Email",strEmail),
                                  new SqlParameter("@Creator",objUser.UserCode)

                             };
                DataTable dta = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_MAC_sp", param1);
                return "../Manage/Sys_Mac.aspx?KeyValue=Add";
            }
        }

        public static string Update_Mac(string strMac, string strMeno, string strMacID, string strUserName, string strTel, string strMobile,string strRole,string strUserId,string strSex,string strBirDay,string strEmail,string strAddress)
        {

            User objUser = new User();
            objUser = HttpContext.Current.Session["User"] as User;

            SqlParameter[] param ={
                                  new SqlParameter("@flag",7),
                                  new SqlParameter("@MAC",strMac),
                                  new SqlParameter("@MacId",strMacID)

                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_MAC_sp", param);
            if (dtable.Rows.Count > 0)
            {
                return "Double";
            }

            else
            {

                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",3),
                                  new SqlParameter("@MAC",strMac),
                                  new SqlParameter("@Meno",strMeno),
                                  new SqlParameter("@UserName",strUserName),
                                  new SqlParameter("@Tel",strTel),
                                  new SqlParameter("@Mobile",strMobile),
                                  new SqlParameter("@MacId",strMacID),
                                  new SqlParameter("@MacRoleDesc",strRole),
                                  new SqlParameter("@UserId",strUserId),
                                  new SqlParameter("@Sex",strSex),
                                  new SqlParameter("@BirthDay",strBirDay),
                                  new SqlParameter("@Address",strAddress),
                                  new SqlParameter("@Email",strEmail),
                                  new SqlParameter("@Editor",objUser.UserCode)

                             };
                DataTable dta = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_MAC_sp", param1);
                return "../Manage/Sys_Mac.aspx?KeyValue=Update";
            }
        }


        /// <summary>
        /// 函數名稱：Delete_Mac
        /// 功能：刪除數據
        /// 開發人員：楊久中
        /// 開發日期：2011-03-16
        /// 
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_Mac(string[] strParameter)
        {

            string strValue = checkChargeData(strParameter);
            if (strValue != "")
            {
                return strValue;
            }

            else
            {
                ExecSQL("exec [MD_MAC_sp] 4,", strParameter);
                return "../Manage/Sys_Mac.aspx?KeyValue=Deleted";
            }
        }

        private static string  checkChargeData(string[] strParameter)
        {
            string strReturn = "";

            for (int i = 1; i < strParameter.Length; i++)
            {
                SqlParameter[] param ={
                                         new SqlParameter("@flag",19),
                                          new SqlParameter("@UserId",strParameter[i])
                                     };

                DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);
                if (dt.Rows.Count > 0)
                {
                    strReturn = "exist";
                }
            }

            return strReturn;
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
            string strSql = string.Empty;

            for (int i = 1; i < strParameter.Length; i++)
            {
                strSql = strSql + strSP + "@MacId='" + strParameter[i].Trim() + "'";
            }
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
        }
    }
}
