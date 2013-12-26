using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ThreeNetTwo.Class;

namespace ThreeNetTwo.Manage.SysLoadTableLog
{
    public partial class Sys_LoadTableLog : System.Web.UI.Page
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
                            GvLoadTableLogBind();
                        }
                        else
                        {
                            GvLoadTableLogSearchBind(arrKeyValue[0].Trim(), arrKeyValue[1].Trim(), arrKeyValue[2].Trim(), arrKeyValue[3].Trim(), arrKeyValue[4].Trim(), arrKeyValue[5].Trim());
                        }

                        txtSuccess.Text = strKeyValue;
                    }
                    else
                    {
                        GvLoadTableLogBind();
                    }

                    txtKeyValue.Text = "UpdateTable";
                }
                catch
                { }
            }
        }

        private void GvLoadTableLogBind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",1)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadTableLog_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvLoadTableLog.DataSource = dt;
                GvLoadTableLog.DataBind();

                for (int i = 0, rowCount = GvLoadTableLog.Rows.Count; i < rowCount; i++)
                {
                    GvLoadTableLog.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvLoadTableLog.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：查詢綁定數據到GvLoadTableLog
        /// 開發人員：楊碧清
        /// 開發時間：2011-05-26
        /// </summary>
        private void GvLoadTableLogSearchBind(string strMac, string strClientName, string strTableName, string strOrderId, string strStartDate, string strEndDate)
        {
            if (strStartDate != "")
            {
                strStartDate = strStartDate + " 00:00:00";
            }
            if (strEndDate != "")
            {
                strEndDate = strEndDate + " 23:59:59";
            }

            SqlParameter[] param ={
                                      new SqlParameter("@flag",2),
                                      new SqlParameter("@Mac",strMac),
                                      new SqlParameter("@ClientName",strClientName),
                                      new SqlParameter("@TableName",strTableName),
                                      new SqlParameter("@OrderID",strOrderId),
                                      new SqlParameter("@StartDate",strStartDate),
                                      new SqlParameter("@EndDate",strEndDate)
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadTableLog_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvLoadTableLog.DataSource = dt;
                GvLoadTableLog.DataBind();

                for (int i = 0, rowCount = GvLoadTableLog.Rows.Count; i < rowCount; i++)
                {
                    GvLoadTableLog.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvLoadTableLog.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：GvLoadTableLog無數據時，顯示表的框架
        /// 開發人員：楊碧清
        /// 開發時間：2011-05-26
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
            GvLoadTableLog.DataSource = dt;
            GvLoadTableLog.DataBind();
            GvLoadTableLog.Rows[0].Cells.Clear();
            GvLoadTableLog.Rows[0].Cells.Add(new TableCell());
            GvLoadTableLog.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
            GvLoadTableLog.Rows[0].Cells[0].Text = "<font color='red'>None!</font>";
            GvLoadTableLog.Rows[0].Cells[0].Style.Add("text-align", "center");
            GvLoadTableLog.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
        }

        protected void GvLoadTableLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            txtSuccess.Text = "";

            DataTable dtbs = ViewState["dt"] as DataTable;

            GvLoadTableLog.PageIndex = e.NewPageIndex;

            GvLoadTableLog.DataSource = dtbs;
            GvLoadTableLog.DataBind();

            for (int i = 0, rowCount = GvLoadTableLog.Rows.Count; i < rowCount; i++)
            {
                GvLoadTableLog.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvLoadTableLog.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

        protected void GvLoadTableLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Attributes.Add("onclick", "btnsetClick('" + e.Row.Cells[0].Text + "')");

                e.Row.Cells[5].Text = Common.SubString(e.Row.Cells[5].Text, 55);
            }
        }
    }
}
