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
    public partial class Sys_MacRoleRight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string strRoleCode = Request["RoleName"].ToString();
                txtRoleName.Text = strRoleCode;

                DataTable table = new DataTable();
                table = GetMenuData();
                string strMenuList = "";

                strMenuList += "<table width='165' height='100%' border='0' cellpadding='0' cellspacing='0'>";
                strMenuList += "<tr><td height='14'>";
                strMenuList += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                strMenuList += "<tr><td width='19%'></td><td width='81%' height='14' align='left'><span class='STYLE1' style='color:#15428b;'></span></td>";
                strMenuList += "</tr></table>";
                strMenuList += "</td></tr>";

                strMenuList += "<tr>";
                strMenuList += "<td valign='top'>";
                strMenuList += "<table width='151' border='0' align='center' cellpadding='0' cellspacing='0' style='padding-top:12px'>";

                foreach (DataRow dr in table.Rows)
                {
                    strMenuList += "<tr><td><table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                    strMenuList += "<tr>";
                    strMenuList += "<td height='60' title='" + dr[0].ToString().Trim() + "'  id='imgmenu" + dr[0].ToString().Trim() + "' class='menu_title'  style='cursor:pointer'>";
                    strMenuList += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                    strMenuList += "<tr><td width='0'>&nbsp;</td>";
                    strMenuList += "<td width='100%' align='left' class='STYLE1' style='color:#072e6d'>" + dr[1].ToString().Trim() + "</td>";
                    strMenuList += "</tr></table>";
                    strMenuList += "</td></tr></table></td></tr>";
                }

                strMenuList += "</table></td></tr></table>";

                leftDiv.InnerHtml = strMenuList;
                string strId = Request["RoleID"].ToString().Trim();
                txtRoleID.Text = strId;
            }
        }

        /// <summary>
        /// 開發功能：綁定資料類型
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-02
        /// </summary>
        /// <returns></returns>
        private DataTable GetMenuData()
        {
            SqlParameter[] param ={
                                      new SqlParameter("@flag",1)
                                 };
            return ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);
        }
    }
}
