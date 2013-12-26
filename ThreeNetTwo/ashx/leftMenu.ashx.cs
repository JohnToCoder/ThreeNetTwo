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
    /// 開發功能：從資料表里抓取資料，拼接html，返回菜單節點，供Ajax調用
    /// 開發人員：楊碧清
    /// 開發時間：2011-03-11
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class leftMenu : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (System.Web.HttpContext.Current.Session["User"] == null)
            {
                context.Response.Write("NoLogin");
                context.Response.End();
                return;
            }

            DataTable table = new DataTable();
            string strMenuList = "";
            string strRoleCode = "";
            User objUser = new User();
            objUser = context.Session["User"] as User;
            strRoleCode = objUser.RoleCode;

            strMenuList += "<table width='165' height='100%' border='0' cellpadding='0' cellspacing='0'>";
            strMenuList += "<tr><td height='28' background='images/main_40.gif'>";
            strMenuList += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
            strMenuList += "<tr><td width='19%'></td><td width='81%' height='20'><span class='STYLE1'>管理菜單</span></td>";
            strMenuList += "</tr></table>";
            strMenuList += "</td></tr>";

            strMenuList += "<tr>";
            strMenuList += "<td valign='top'>";
            strMenuList += "<table width='151' border='0' align='center' cellpadding='0' cellspacing='0'>";

            table = GetMenuData("SysRoot",strRoleCode);
            if (table.Rows.Count == 0)
            {
                context.Response.Write("NoAccess");
                context.Response.End();
                return;
            }

            foreach (DataRow dr in table.Rows)
            {
                strMenuList += "<tr><td><table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                strMenuList += "<tr>";
                strMenuList += "<td height='23' background=\"images/main_47.gif\" id='imgmenu" + dr[5].ToString().Trim() + "' class='menu_title' onmouseover=\"this.className='menu_title2';\" onclick='showsubmenu(" + dr[5].ToString() + ")' onmouseout=\"this.className='menu_title';\" style='cursor:pointer'>";
                strMenuList += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                strMenuList += "<tr><td width='18%'></td>";
                strMenuList += "<td width='82%' class='STYLE1'>" + dr[1].ToString().Trim() + "</td>";
                strMenuList += "</tr></table>";
                strMenuList += "</td></tr>";

                if (Int32.Parse(dr[5].ToString().Trim()) <= 4)
                {
                    strMenuList += "<tr><td background='images/main_51.gif' id='submenu" + dr[5].ToString().Trim() + "'>";
                }
                else
                {
                    strMenuList += "<tr><td background='images/main_51.gif' style='display:none;' id='submenu" + dr[5].ToString().Trim() + "'>";
                }
                strMenuList += "<div class='sec_menu'><table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                strMenuList += "<tr><td>";
                strMenuList += "<table width='90%' border='0' align='center' cellpadding='0' cellspacing='0'>";

                DataTable tableChild = new DataTable();
                tableChild = GetMenuData(dr[0].ToString().Trim(),strRoleCode);
                foreach (DataRow dtChild in tableChild.Rows)
                {
                    strMenuList += "<tr>";
                    strMenuList += "<td><div align='center'><img src=\"images/left.gif\" width='10' height='10'/></div>";
                    strMenuList += "</td>";
                    strMenuList += "<td height='23'>";
                    strMenuList += "<table border='0' cellspacing='0' cellpadding='0'>";
                    strMenuList += "<tr>";
                    strMenuList += "<td height='20' style='cursor: pointer' onmouseover=\"this.style.borderStyle='solid';this.style.borderWidth='1';borderColor='#7bc4d3';\" onmouseout=\"this.style.borderStyle='none'\" onclick=\"SubMenuClick('" + dtChild[3].ToString().Trim() + "',this)\">";
                    //strMenuList += "<a href='" + dtChild[3].ToString().Trim() + "' target='rightFrame'>";
                    strMenuList += "<span class='STYLE3'>" + dtChild[1].ToString().Trim() + "</span>";
                    //strMenuList += "</a>";
                    strMenuList += "</td>";
                    strMenuList += "</tr>";
                    strMenuList += "</table></td></tr>";
                }
                strMenuList += "</table></td></tr>";
                strMenuList += "<tr><td height='5'><img src=\"images/main_52.gif\" width='151' height='5' />";
                strMenuList += "</td> </tr></table>";
                strMenuList += "</div></td> ";
                strMenuList += "</tr>";

                strMenuList += "</table></td></tr>";
            }

            strMenuList += "</table>";
            strMenuList += "</td>";
            strMenuList += "</tr>";

            strMenuList += "<tr><td height='18' background=\"images/main_58.gif\">";
            strMenuList += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
            strMenuList += "<tr><td height='18' valign='bottom'><div align='center' class='STYLE3'></div></td>";
            strMenuList += "</tr></table>";
            strMenuList += "</td></tr>";
            strMenuList += "</table>";

            context.Response.Write(strMenuList);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 函數名：GetMenuData
        /// 功能：獲取資料庫里的菜單資料
        /// 開發人員：楊碧清
        /// 開發日期：2011-3-10
        /// </summary>
        /// <param name="strParentID"></param>
        /// <returns></returns>
        private DataTable GetMenuData(string strParentID,string strRoleCode)
        {
            SqlParameter[] param ={
                                      new SqlParameter("@flag",1),
                                      new SqlParameter("@ParentMenuid",strParentID),
                                      new SqlParameter("@RoleCode",strRoleCode)
                                 };
            return ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Menu_sp", param);
        }
    }
}
