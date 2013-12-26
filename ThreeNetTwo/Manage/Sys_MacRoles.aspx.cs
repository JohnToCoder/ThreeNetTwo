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
    public partial class Sys_MacRoles : System.Web.UI.Page
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
                        objUser.GetRight(objUser.RoleCode, "85", this.Page);//頁面按鈕權限管控
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

                    txtKeyValue.Text = "MacRole";
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
        private void databind(string strRole, string strDesc)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",1),
                                     new SqlParameter("@MacRoleCode",strRole),
                                     new SqlParameter("@MacRoleDesc",strDesc)
                                 };

            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[Sys_MacRoles_sp]", param);
            if (dtb.Rows.Count > 0)
            {
                Gv_MacRole.DataSource = dtb;
                Gv_MacRole.DataBind();
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
                Gv_MacRole.DataSource = dtb;
                Gv_MacRole.DataBind();
                Gv_MacRole.Rows[0].Cells.Clear();
                Gv_MacRole.Rows[0].Cells.Add(new TableCell());
                Gv_MacRole.Rows[0].Cells[0].ColumnSpan = dtb.Columns.Count;
                Gv_MacRole.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_MacRole.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_MacRole.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }

            ViewState["dt"] = dtb;

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
                e.Row.Cells[8].Attributes.Add("onclick", "btnsetClick('" + e.Row.Cells[1].Text + "','" + e.Row.Cells[3].Text + "')");
            }
        }

        protected void Gv_MacRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            txtSuccess.Text = "";

            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_MacRole.PageIndex = e.NewPageIndex;

            Gv_MacRole.DataSource = dtbs;
            Gv_MacRole.DataBind();

            for (int i = 0, rowCount = Gv_MacRole.Rows.Count; i < rowCount; i++)
            {
                Gv_MacRole.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                Gv_MacRole.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }
    }
}
