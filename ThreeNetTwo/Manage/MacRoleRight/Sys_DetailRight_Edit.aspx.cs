using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThreeNetTwo.Manage.MacRoleRight
{
    public partial class Sys_DetailRight_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["RightID"] != null)
                    {
                        txtRightId.Text = Request["RightID"].ToString();
                    }
                    if (Request["MenuTypeID"] != null)
                    {
                        txtMenuTypeId.Text = Request["MenuTypeID"].ToString();
                    }
                    if (Request["RoleID"] != null)
                    {
                        txtRoleId.Text = Request["RoleID"].ToString();
                    }

                    //ddlFlagBind();

                }
                catch
                { }
            }
        }

        /// <summary>
        /// 開發功能：綁定DropDownList(授權狀態)
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-13
        /// </summary>
        private void ddlFlagBind()
        {
            //ddlFlag.Items.Insert(0, new ListItem("全部", ""));
            //ddlFlag.Items.Insert(1, new ListItem("未授權", "-1"));
            //ddlFlag.Items.Insert(2, new ListItem("已授權", "Y"));
        }
    }
}
