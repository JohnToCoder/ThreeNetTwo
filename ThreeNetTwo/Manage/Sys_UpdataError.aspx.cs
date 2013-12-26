using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using ThreeNetTwo.Class;

namespace ThreeNetTwo.Manage
{
    public partial class Sys_UpdataError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    User objUser = new User();
                    objUser = Session["User"] as User;
                    objUser.GetRight(objUser.RoleCode, "88", this.Page);//頁面按鈕權限管控
                }
                BindError();
            }

        }

        private void BindError()
        {

            try
            {
                SqlParameter[] paras = {
                                     new SqlParameter("@flag",2),
                                     new SqlParameter("@Mac",""),
                                     new SqlParameter("@UserName",""),
                                     new SqlParameter("@ErrorMsg",""),
                                     new SqlParameter("@CreatDate","")                                   
                                   };
                DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[Sys_UpdateError_sp]", paras);

                if (dt.Rows.Count > 0)
                {
                    GvClient.DataSource = dt;
                    GvClient.DataBind();
                }
                else
                {
                    DataRow row = dt.NewRow();
                    foreach (DataColumn col in dt.Columns)
                    {
                        col.AllowDBNull = true;
                        row[col] = DBNull.Value;
                    }
                    dt.Rows.Add(row);
                    GvClient.DataSource = dt;
                    GvClient.DataBind();
                    GvClient.Rows[0].Cells.Clear();
                    GvClient.Rows[0].Cells.Add(new TableCell());
                    GvClient.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                    GvClient.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                    GvClient.Rows[0].Cells[0].Style.Add("text-align", "center");
                    GvClient.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
                }
                ViewState["dt"] = dt;
            }
            catch { }


        }

        protected void GvClient_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = "<span title=\'" + e.Row.Cells[2].Text.Replace("'","\"") + "\'>" + Common.SubString(e.Row.Cells[2].Text, 50) + "</span>";
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        protected void GvClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            txtSuccess.Text = "";

            DataTable dtbs = ViewState["dt"] as DataTable;

            GvClient.PageIndex = e.NewPageIndex;

            GvClient.DataSource = dtbs;
            GvClient.DataBind();

            for (int i = 0, rowCount = GvClient.Rows.Count; i < rowCount; i++)
            {
                GvClient.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvClient.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }
    }
}
