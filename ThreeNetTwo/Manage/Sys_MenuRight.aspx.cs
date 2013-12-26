using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThreeNetTwo.Manage
{
    public partial class Sys_MenuRight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["roleCode"] != null)
                    {
                        string code = Request["RoleCode"].ToString();
                        lblRoleCode.Text = code;
                    }
                }
                catch
                {

                }
            }
        }
    }
}
