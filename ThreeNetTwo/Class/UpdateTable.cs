using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Class
{
    public class UpdateTable
    {
        /// <summary>
        /// 函數名稱：Add_UpdateTb
        /// 功能：新增表結構
        /// 開發人員：楊碧清
        /// 開發日期：2011-5-23
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strCodeDesc"></param>
        /// <returns></returns>
        public static string Add_UpdateTb(string strTableName, string strCodeDesc,string strOrderID)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",8),
                                  //new SqlParameter("@TableName",strTableName),
                                  new SqlParameter("@OrderID",strOrderID)

                             };
            DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_UpdateTable_sp", param);

            if (table.Rows.Count > 0)
            {
                return "ExistsOrderId";
            }
            else
            {
                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",3),
                                  new SqlParameter("@TableName",strTableName),
                                  new SqlParameter("@CodeDesc",strCodeDesc),
                                  new SqlParameter("@OrderID",strOrderID)

                             };
                DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_UpdateTable_sp", param1);
                return "../../Manage/UpdateTable/MD_UpdateTable.aspx?KeyValue=Add";
            }

        }

        /// <summary>
        /// 函數名稱：Update_UpdateTable
        /// 功能：修改表結構
        /// 開發人員：楊碧清
        /// 開發日期：2011-5-23
        /// </summary>
        /// <param name="strId"></param>
        /// <param name="strTableName"></param>
        /// <param name="strCodeDesc"></param>
        /// <returns></returns>
        public static string Update_UpdateTable(string strId,string strTableName,string strCodeDesc,string strOrderID)
        {
            SqlParameter[] param ={
                                  new SqlParameter("@flag",9),
                                  new SqlParameter("@ID",strId),
                                  //new SqlParameter("@TableName",strTableName),
                                  new SqlParameter("@OrderID",strOrderID)

                             };
            DataTable table = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_UpdateTable_sp", param);

            if (table.Rows.Count > 0)
            {
                return "ExistsOrderId";
            }
            else
            {
                SqlParameter[] param1 ={
                                  new SqlParameter("@flag",4),
                                  new SqlParameter("@ID",strId),
                                  new SqlParameter("@TableName",strTableName),
                                  new SqlParameter("@CodeDesc",strCodeDesc),
                                  new SqlParameter("@OrderID",strOrderID)
                             };
                DataTable dtable = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_UpdateTable_sp", param1);

                return "../../Manage/UpdateTable/MD_UpdateTable.aspx?KeyValue=Update";
            }
        }

        /// <summary>
        /// 函數名稱：Delete_UpdateTable
        /// 功能：刪除
        /// 開發人員：楊碧清
        /// 開發日期：2011-5-23 
        /// </summary>
        /// <param name="strParameter"></param>
        /// <returns></returns>
        public static string Delete_UpdateTable(string[] strParameter)
        {
            string strSql = string.Empty;

            for (int i = 1; i < strParameter.Length; i++)
            {
                strSql = strSql + "exec [MD_UpdateTable_sp] 5," + "@ID='" + strParameter[i].Trim() + "'";
            }

            ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);

            return "../../Manage/UpdateTable/MD_UpdateTable.aspx?KeyValue=Deleted";
        }
    }
}
