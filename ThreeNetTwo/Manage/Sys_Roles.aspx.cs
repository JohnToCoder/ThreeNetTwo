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
    public partial class Sys_Roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["User"] != null)
                    {
                        User objUser = new User();
                        objUser = Session["User"] as User;
                        objUser.GetRight(objUser.RoleCode, "72", this.Page);//頁面按鈕權限管控
                    }

                    if (Request["KeyValue"] == null)
                    {
                        databind("", "");
                    }

                    else
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        string[] ArrKeyValue = strKeyValue.Split('=');

                        string strRole = "";
                        string strDesc = "";
                        if (ArrKeyValue.Length != 1)
                        {
                            strRole = ArrKeyValue[0];
                            strDesc = ArrKeyValue[1];
                        }

                        databind(strRole, strDesc);
                        txtSuccess.Text = strKeyValue;
                    }

                    txtKeyValue.Text = "Role";
                }
                catch
                {

                }
            }

        }

        /// <summary>
        /// Gview綁定
        /// </summary>
        /// <param name="strRole"></param>
        /// <param name="strDesc"></param>
        private void databind(string strRole,string strDesc)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",1),
                                     new SqlParameter("@RoleCode",strRole),
                                     new SqlParameter("@RoleDesc",strDesc)
                                 };

            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[Sys_Roles_sp]", param);
            if (dtb.Rows.Count > 0)
            {
                Gv_Role.DataSource = dtb;
                Gv_Role.DataBind();
            }
            else
            {
                DataRow row = dtb.NewRow();
                foreach (DataColumn col in dtb.Columns)
                {
                    col.AllowDBNull = true;
                    row[col] = DBNull.Value;
                }
                dtb.Rows.Add(row);
                Gv_Role.DataSource = dtb;
                Gv_Role.DataBind();
                Gv_Role.Rows[0].Cells.Clear();
                Gv_Role.Rows[0].Cells.Add(new TableCell());
                Gv_Role.Rows[0].Cells[0].ColumnSpan = dtb.Columns.Count;
                Gv_Role.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Role.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_Role.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }

        }
        /// <summary>
        /// 鼠標移至GridView變色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Role_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }
    }
}
