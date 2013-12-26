using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Sys_MenuRight : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            User objUser = new User();
            objUser = (User)context.Session["User"];

            string strFlag = context.Request["flag"].ToString().Trim();//flag=1表示左邊的樹，flag=2表示右邊的樹
            string strRoleCode = "";

            //獲取角色代碼
            //開發人：楊碧清
            if (context.Request["RoleCodeId"] != null)
            {
                strRoleCode = context.Request["RoleCodeId"].ToString().Trim();
            }
            else
            {
                strRoleCode = "";
            }

            if (context.Request["leftCode"] != null)
            {
                //获得选择左边的树的節點代碼(包含tree-checkbox1和tree-checkbox2)
                string strLeftCode = context.Request["leftCode"].ToString().Trim();

                string removeStr = "None,";

                string[] ArrNodeCode = DeleteString(strLeftCode, removeStr).Trim().Split(',');

                string strEnd = ",@TreeType='R',@RoleCode='" + strRoleCode + "'," + "@Creator='" + objUser.UserCode + "'";

                AddRole(ArrNodeCode, strEnd);
            }

            if (context.Request["leftCode1"] != null)
            {
                //获得选择左边的树的節點代碼(只包含tree-checkbox1)
                string strLeftCode = context.Request["leftCode1"].ToString().Trim();

                string removeStr = "None,";

                string[] ArrNodeCode = DeleteString(strLeftCode, removeStr).Trim().Split(',');

                string strEnd = ",@TreeType='L',@RoleCode='" + strRoleCode + "'," + "@Creator='" + objUser.UserCode + "'";

                AddRole(ArrNodeCode, strEnd);
            }

            if (context.Request["rightCode"] != null)
            {
                //获得选择右边的树的節點代碼(包含tree-checkbox1和tree-checkbox2)
                string strRightCode = context.Request["rightCode"].ToString().Trim();
                string removeStr = "None,";

                string[] ArrNodeCode = DeleteString(strRightCode, removeStr).Trim().Split(',');

                string strEnd = ",@TreeType='L',@RoleCode='" + strRoleCode + "'";

                RemoveRole(ArrNodeCode, strEnd);
            }

            if (context.Request["rightCode1"] != null)
            {
                //获得选择左边的树的節點代碼(只含tree-checkbox1)
                string strRightCode = context.Request["rightCode1"].ToString().Trim();
                string removeStr = "None,";

                string[] ArrNodeCode = DeleteString(strRightCode, removeStr).Trim().Split(',');

                string strEnd = ",@TreeType='R',@RoleCode='" + strRoleCode + "'";

                RemoveRole(ArrNodeCode, strEnd);
            }

            if (strFlag == "1")
            {
                string resultStr = "[{\"id\": \"None\", \"text\": \"未經授權的權限\", \"iconCls\": \"icon-ok1\"";
                context.Response.Write(resultStr + GetResultStr("0", strFlag, strRoleCode, "L") + "]}]");
            }
            else if (strFlag == "2")
            {
                string resultStr = "[{\"id\": \"None\", \"text\": \"已經授權的權限\", \"iconCls\": \"icon-ok1\"";
                context.Response.Write(resultStr + GetResultStr("0", strFlag, strRoleCode, "R") + "]}]");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 功能：插入權限
        /// 開發人員：楊碧清
        /// 開發日期：2011-03-16
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="strEnd"></param>
        private void AddRole(string[] parameter, string strEnd)
        {
            ExecSQL("exec Sys_MenuRight_sp @flag=3,", parameter, strEnd);
        }

        /// <summary>
        /// 功能：收回權限
        /// 開發人員：楊碧清
        /// 開發日期：2011-03-16
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="strEnd"></param>
        private void RemoveRole(string[] parameter, string strEnd)
        {
            ExecSQL("exec Sys_MenuRight_sp @flag=4,", parameter, strEnd);
        }

        /// <summary>
        /// 功能：在字符串中刪除指定的字符串
        /// 開發人員：楊碧清
        /// 開發日期：2011-03-16
        /// </summary>
        /// <param name="firstStr"></param>
        /// <param name="endStr"></param>
        /// <returns></returns>
        private string DeleteString(string firstStr, string delString)
        {
            int startIndex = firstStr.IndexOf("None,");
            int count = delString.Length;
            if (startIndex >= 0)
            {
                firstStr = firstStr.Remove(startIndex, count);
            }
            return firstStr;
        }

        private void ExecSQL(string strSP, string[] parameter, string strEnd)
        {
            string strSql = string.Empty;

            for (int i = 0; i < parameter.Length; i++)
            {
                strSql = strSql + strSP + "@NodeID='" + parameter[i].Trim() + "'" + strEnd + ";";
            }
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.Text, strSql);
        }

        private string GetResultStr(string strParent, string strFlag, string strRoleCode, string strTreeType)
        {
            DataTable dtbl = new DataTable();
            string resultStr = "";
            int Flag = 0;
            string strSub = "";
            string strIcon = "";

            SqlParameter[] param =
                     {
                         new SqlParameter("@flag",strFlag),
                         new SqlParameter("@NodeParent",strParent),
                         new SqlParameter("@RoleCode",strRoleCode),
                         new SqlParameter("@TreeType",strTreeType)
                     };
            dtbl = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.Sys_MenuRight_sp", param);

            //在表Sys_MenuDetail中判斷NodeParent是否等於0（即為父節點）
            if (strParent == "0" || strParent.Substring(1, 1) == "0")
            {
                resultStr += ",\"children\":[";
            }
            else
            {
                resultStr += ",\"state\":\"closed\",\"children\":["; //子節點收縮菜單
            }

            foreach (DataRow item in dtbl.Rows)
            {

                strIcon = GetIconCls(item[1].ToString().Trim());
                strSub = GetResultStr(item[0].ToString(), strFlag, strRoleCode, strTreeType);
                resultStr += "{";
                resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\", \"iconCls\": \"" + strIcon + "\"", item[0].ToString(), item[1].ToString());

                resultStr += strSub;

                if (strSub == "")
                {
                    resultStr += "},";
                }
                else
                {
                    resultStr += "]},";
                }

                Flag = 1;
            }


            if (Flag == 0)
            {
                return "";
            }
            else
            {
                resultStr = resultStr.Substring(0, resultStr.Length - 1);
                //resultStr += "]}";
                return resultStr;
            }
        }

        private string GetIconCls(string strText)
        {
            switch (strText)
            {
                case "查詢":

                    return "icon-search";


                case "新增":
                case "上傳":
                    return "icon-add";


                case "修改":
                case "修改密碼":

                    return "icon-edit";


                case "刪除":

                    return "icon-cancel1";


                case "權限設置":

                    return "icon-set";
            }

            return "";
        }
    }
}
