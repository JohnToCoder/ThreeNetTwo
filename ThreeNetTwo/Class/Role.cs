using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Class
{
    public class Role
    {

        /// <summary>
        /// 函數名稱：Add_Users
        /// 功能：新增用戶
        /// 開發人員：楊久中
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="strDeptCode"></param>
        /// <param name="strDeptDesc"></param>
        /// <param name="strddlParentCode"></param>
        /// <param name="strddlDeptClass"></param>
        /// <returns></returns>
        public static string Add_Roles(string strRoleCode,string strRoleDesc)
        {

            User objUser = new User();
            objUser =  HttpContext.Current.Session["User"] as User;

            SqlParameter[] param ={
                                  new SqlParameter("@flag",6),
                                  new SqlParameter("@ID",""),
                                  new SqlParameter("@RoleCode",strRoleCode)
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Roles_sp", param);
            if (dtable.Rows.Count > 0)
            {
                return "Double";
            }

            else
            {

                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",2),
                                  new SqlParameter("@RoleCode",strRoleCode),
                                  new SqlParameter("@RoleDesc",strRoleDesc),
                                  new SqlParameter("@Creator",objUser.UserCode)

                             };
                DataTable dta = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Roles_sp", param1);
                return "../Manage/Sys_Roles.aspx?KeyValue=Add";
            }
        }

        /// <summary>
        /// 函數名稱：UpdateRoles
        /// 功能：修改角色
        /// 開發人員：楊久中
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="strDeptCode"></param>
        /// <param name="strDeptDesc"></param>
        /// <param name="strddlParentCode"></param>
        /// <param name="strddlDeptClass"></param>
        /// <returns></returns>
        public static string Update_Roles(string strRoleId,string strRoleCode,string strRoleDesc)
        {
            User objUser = new User();
            objUser = HttpContext.Current.Session["User"] as User;

            SqlParameter[] param ={
                                  new SqlParameter("@flag",6),
                                  new SqlParameter("@ID",strRoleId),
                                  new SqlParameter("@RoleCode",strRoleCode)
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Roles_sp", param);
            if (dtable.Rows.Count > 0)
            {
                return "Double";
            }
            else
            {
                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",3),
                                  new SqlParameter("@ID",strRoleId),
                                  new SqlParameter("@RoleCode",strRoleCode),
                                  new SqlParameter("@RoleDesc",strRoleDesc),
                                  new SqlParameter("@Editor",objUser.UserCode)

                             };
                DataTable dta = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Roles_sp", param1);
                return "../Manage/Sys_Roles.aspx?KeyValue=Update";
            }
        }



        /// <summary>
        /// 函數名稱：Delete_Role
        /// 功能：刪除數據
        /// 開發人員：楊久中
        /// 開發日期：2011-03-16
        /// 
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_Role(string[] strParameter)
        {

            ExecSQL("exec [Sys_Roles_sp] 4,", strParameter);
            return "../Manage/Sys_Roles.aspx?KeyValue=Deleted";
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
                strSql = strSql + strSP + "@ID='" + strParameter[i].Trim() + "'";
            }
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
        }

    }
}
 