using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ThreeNetTwo.Manage.SysLoadData
{
    public partial class LoadDataLog_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ddlMenuTypeIdBind();
                    ddlActionTypeBind();
                }
                catch
                {}
            }
        }

        /// <summary>
        /// 開發功能：綁定DropDownList(動作類型)
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-14
        /// </summary>
        private void ddlActionTypeBind()
        {
            SqlParameter[] param ={
                                  new SqlParameter("flag",11)
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);
            ddlActionType.DataValueField = "ID";
            ddlActionType.DataTextField = "ActionTypeDesc";
            ddlActionType.DataSource = dt;
            ddlActionType.DataBind();
            ddlActionType.Items.Insert(0, new ListItem("--請選擇動作類型--", ""));
        }

        /// <summary>
        /// 開發功能：綁定DropDownList(資料類型)
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-14
        /// </summary>
        private void ddlMenuTypeIdBind()
        {
            SqlParameter[] param ={
                                      new SqlParameter("@flag",12)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);
            ddlMenuTypeId.DataValueField = "ID";
            ddlMenuTypeId.DataTextField = "CodeDesc";
            ddlMenuTypeId.DataSource = dt;
            ddlMenuTypeId.DataBind();
            ddlMenuTypeId.Items.Insert(0, new ListItem("--請選擇資料類型--", ""));
        }
    }
}
