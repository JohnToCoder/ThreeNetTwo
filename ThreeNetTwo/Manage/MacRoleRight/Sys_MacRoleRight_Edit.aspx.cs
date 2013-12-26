using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ThreeNetTwo.Manage.MacRoleRight
{
    public partial class Sys_MacRoleRight_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ddlMenuTypeIDBind();
                    ddlFlagBind();
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 開發功能：綁定DropDownList(模塊類型)
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-07
        /// </summary>
        private void ddlMenuTypeIDBind()
        {
            SqlParameter[] param ={
                                  new SqlParameter("flag",1)
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);
            ddlMenuTypeID.DataValueField = "Id";
            ddlMenuTypeID.DataTextField = "CodeDesc";
            ddlMenuTypeID.DataSource = dt;
            ddlMenuTypeID.DataBind();
            ddlMenuTypeID.Items.Insert(0, new ListItem("全部", ""));
        }

        /// <summary>
        /// 開發功能：綁定DropDownList(授權狀態)
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-07
        /// </summary>
        private void ddlFlagBind()
        {
            ddlFlag.Items.Insert(0, new ListItem("全部", ""));
            ddlFlag.Items.Insert(1, new ListItem("未授權", "-1"));
            ddlFlag.Items.Insert(2, new ListItem("已授權", "1"));
        }
    }
}
