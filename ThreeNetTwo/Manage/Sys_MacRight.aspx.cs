using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Manage
{
    public partial class Sys_MacRight : System.Web.UI.Page
    {
        /// <summary>
        /// 函數名：Page_Load
        /// 函數功能:初始化頁面并生成左邊菜單
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    string strMac = Request["mac"].ToString();
                    txtRight.Text = strMac;

                    DataTable table = new DataTable();
                    table = GetMenuData();
                    string strMenuList = "";

                    strMenuList += "<table width='165' height='100%' border='0' cellpadding='0' cellspacing='0'>";
                    strMenuList += "<tr><td style='height:6px'></td></tr>";
                    strMenuList += "<tr>";
                    strMenuList += "<td valign='top'>";
                    strMenuList += "<table width='151' border='0' align='center' cellpadding='0' cellspacing='0' style='padding-top:12px'>";


                    foreach (DataRow dr in table.Rows)
                    {
                        strMenuList += "<tr><td><table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                        strMenuList += "<tr>";
                        strMenuList += "<td height='40' title='" + dr[0].ToString().Trim() + "'  id='imgmenu" + dr[0].ToString().Trim() + "' class='menu_title'  style='cursor:pointer'>";
                        strMenuList += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                        strMenuList += "<tr><td width='0'>&nbsp;</td>";
                        strMenuList += "<td width='100%' align='left' class='STYLE1' style='color:#072e6d'>" + dr[1].ToString().Trim() + "</td>";
                        strMenuList += "</tr></table>";
                        strMenuList += "</td></tr><tr><td height='15'></td></tr></table></td></tr>";
                    }

                    //    //if (Int32.Parse(dr[5].ToString().Trim()) <= 4)
                    //    //{
                    //    //    strMenuList += "<tr><td background='images/main_51.gif' id='submenu" + dr[5].ToString().Trim() + "'>";
                    //    //}
                    //    //else
                    //    //{
                    //    //    strMenuList += "<tr><td background='images/main_51.gif' style='display:none;' id='submenu" + dr[5].ToString().Trim() + "'>";
                    //    //}
                    //    strMenuList += "<div class='sec_menu'><table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                    //    strMenuList += "<tr><td>";

                    //    strMenuList += "</table></td></tr>";
                    //}

                    //strMenuList += "</table>";
                    //strMenuList += "</td>";
                    //strMenuList += "</tr>";

                    //strMenuList += "<tr><td height='18' background=\"images/main_58.gif\">";
                    //strMenuList += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                    //strMenuList += "<tr><td height='18' valign='bottom'><div align='center' class='STYLE3'></div></td>";
                    //strMenuList += "</tr></table>";
                    //strMenuList += "</td></tr>";
                    strMenuList += "</table></td></tr></table>";

                    leftDiv.InnerHtml = strMenuList;
                    string strId = Request["strId"].ToString().Trim();
                    txtId.Text = strId;
                    txtMacId.Text = Request["Mid"].ToString().Trim();
                }
            }

            catch
            {

            }

        }

        /// <summary>
        /// 函數名：GetMenuData
        /// 函數功能:獲取菜單
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <returns></returns>
        private DataTable GetMenuData()
        {
            string strId = Request["strId"].ToString().Trim();
            txtMacId.Text = Request["Mid"].ToString().Trim();

            SqlParameter[] param ={
                                      new SqlParameter("@flag",1),
                                      new SqlParameter("@MacRoleId",strId)
                                 };
            return ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRight_sp", param);
        }
    }
}
