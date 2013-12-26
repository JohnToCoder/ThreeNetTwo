using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Class
{
    public class MacRole
    {

        /// <summary>
        /// 函數名稱：Add_MacRoles
        /// 功能：新增客戶角色
        /// 開發人員：胡貴
        /// 開發日期：2011-4-1
        /// </summary>
        /// <param name="strDeptCode"></param>
        /// <param name="strDeptDesc"></param>
        /// <returns></returns>
        public static string Add_MacRoles(string strRoleCode,string strRoleDesc)
        {

            User objUser = new User();
            objUser =  HttpContext.Current.Session["User"] as User;

            SqlParameter[] param ={
                                  new SqlParameter("@flag",6),
                                  new SqlParameter("@ID",""),
                                  new SqlParameter("@MacRoleCode",strRoleCode)
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoles_sp", param);
            if (dtable.Rows.Count > 0)
            {
                return "Double";
            }

            else
            {

                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",2),
                                  new SqlParameter("@MacRoleCode",strRoleCode),
                                  new SqlParameter("@MacRoleDesc",strRoleDesc),
                                  new SqlParameter("@Creator",objUser.UserCode)

                             };
                DataTable dta = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoles_sp", param1);
                return "../Manage/Sys_MacRoles.aspx?KeyValue=Add";
            }
        }

        /// <summary>
        /// 函數名稱：Update_MacRoles
        /// 功能：修改客戶角色
        /// 開發人員：胡貴
        /// 開發日期：2011-4-1
        /// </summary>
        /// <param name="strDeptCode"></param>
        /// <param name="strDeptDesc"></param>
        /// <param name="strddlParentCode"></param>
        /// <param name="strddlDeptClass"></param>
        /// <returns></returns>
        public static string Update_MacRoles(string strRoleId, string strRoleCode, string strRoleDesc)
        {
            User objUser = new User();
            objUser = HttpContext.Current.Session["User"] as User;

            SqlParameter[] param ={
                                  new SqlParameter("@flag",6),
                                  new SqlParameter("@ID",strRoleId),
                                  new SqlParameter("@MacRoleCode",strRoleCode)
                             };
            DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoles_sp", param);
            if (dtable.Rows.Count > 0)
            {
                return "Double";
            }
            else
            {
                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",3),
                                  new SqlParameter("@ID",strRoleId),
                                  new SqlParameter("@MacRoleCode",strRoleCode),
                                  new SqlParameter("@MacRoleDesc",strRoleDesc),
                                  new SqlParameter("@Editor",objUser.UserCode)

                             };
                DataTable dta = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoles_sp", param1);
                return "../Manage/Sys_MacRoles.aspx?KeyValue=Update";
            }
        }



        /// <summary>
        /// 函數名稱：Delete_MacRole
        /// 功能：刪除客戶角色
        /// 開發人員：胡貴
        /// 開發日期：2011-03-16
        /// 
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_MacRole(string[] strParameter)
        {
            string strSql = string.Empty;

            SqlParameter[] paras = null;
            for (int i = 1; i < strParameter.Length; i++)
            {
                //判斷是否存在相關數據
                paras = new SqlParameter[]{
                          new SqlParameter("@flag",7),
                          new SqlParameter("@ID",strParameter[i].Trim())
                        };
                DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.StoredProcedure, "Sys_MacRoles_sp", paras);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    return "EnjoyInBoth";
                }
                else if (ds.Tables[0].Rows.Count > 0)
                {
                    return "EnjoyInMac";
                }
                else if (ds.Tables[1].Rows.Count > 0)
                {
                    return "EnjoyInRight";
                }

                strSql = strSql + "exec [Sys_MacRoles_sp] 4," + "@ID='" + strParameter[i].Trim() + "'";
            }
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);

            return "../Manage/Sys_MacRoles.aspx?KeyValue=Deleted";
        }

    }
}
 