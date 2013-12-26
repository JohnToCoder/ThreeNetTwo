using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ThreeNetTwo.Class;

namespace ThreeNetTwo.Manage.UpdateTable
{
    public partial class MD_UpdateTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["KeyValue"] != null)
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        string[] arrKeyValue = strKeyValue.Split('=');

                        if (arrKeyValue.Length == 1)
                        {
                            GvUpdateTbBind();
                        }
                        else
                        {
                            GvUpdateTbSearchBind(arrKeyValue[0].Trim());
                        }

                        txtSuccess.Text = strKeyValue;
                    }
                    else
                    {
                        GvUpdateTbBind();
                    }

                    txtKeyValue.Text = "UpdateTable";
                }
                catch
                { }
            }
        }

        private void GvUpdateTbBind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",1)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_UpdateTable_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvUpdateTb.DataSource = dt;
                GvUpdateTb.DataBind();

                for (int i = 0, rowCount = GvUpdateTb.Rows.Count; i < rowCount; i++)
                {
                    GvUpdateTb.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvUpdateTb.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：查詢綁定數據到GvUpdateTb
        /// 開發人員：楊碧清
        /// 開發時間：2011-05-23
        /// </summary>
        private void GvUpdateTbSearchBind(string strTableName)
        {
            SqlParameter[] param ={
                                      new SqlParameter("@flag",2),
                                      new SqlParameter("@TableName",strTableName)
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_UpdateTable_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvUpdateTb.DataSource = dt;
                GvUpdateTb.DataBind();

                for (int i = 0, rowCount = GvUpdateTb.Rows.Count; i < rowCount; i++)
                {
                    GvUpdateTb.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvUpdateTb.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：GvUpdateTb無數據時，顯示表的框架
        /// 開發人員：楊碧清
        /// 開發時間：2011-05-23
        /// </summary>
        /// <param name="dt"></param>
        private void getNullValue(DataTable dt)
        {
            DataRow row = dt.NewRow();
            foreach (DataColumn column in dt.Columns)
            {
                column.AllowDBNull = true;
                row[column] = DBNull.Value;
            }
            dt.Rows.Add(row);
            GvUpdateTb.DataSource = dt;
            GvUpdateTb.DataBind();
            GvUpdateTb.Rows[0].Cells.Clear();
            GvUpdateTb.Rows[0].Cells.Add(new TableCell());
            GvUpdateTb.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
            GvUpdateTb.Rows[0].Cells[0].Text = "<font color='red'>None!</font>";
            GvUpdateTb.Rows[0].Cells[0].Style.Add("text-align", "center");
            GvUpdateTb.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
        }

        protected void GvUpdateTb_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            txtSuccess.Text = "";

            DataTable dtbs = ViewState["dt"] as DataTable;

            GvUpdateTb.PageIndex = e.NewPageIndex;

            GvUpdateTb.DataSource = dtbs;
            GvUpdateTb.DataBind();

            for (int i = 0, rowCount = GvUpdateTb.Rows.Count; i < rowCount; i++)
            {
                GvUpdateTb.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvUpdateTb.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

        protected void GvUpdateTb_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Attributes.Add("onclick", "btnsetClick('" + e.Row.Cells[1].Text + "')");

                e.Row.Cells[4].Text = Common.SubString(e.Row.Cells[4].Text, 80);
            }
        }

    }
}
