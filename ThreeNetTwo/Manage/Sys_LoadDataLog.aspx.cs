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
    public partial class Sys_LoadDataLog : System.Web.UI.Page
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
                        objUser.GetRight(objUser.RoleCode, "84", this.Page);//頁面按鈕權限管控
                    }

                    if (Request["KeyValue"] != null)
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        string[] arrKeyValue = strKeyValue.Split('=');

                        if (arrKeyValue.Length == 1)
                        {
                            GvDataLogBind();
                        }
                        else
                        {
                            GvDataLogSearchBind(arrKeyValue[0].Trim(), arrKeyValue[1].Trim(), arrKeyValue[2].Trim(), arrKeyValue[3].Trim(), arrKeyValue[4].Trim(), arrKeyValue[5].Trim(), arrKeyValue[6].Trim(),arrKeyValue[7].Trim());
                        }
                    }
                    else
                    {
                        GvDataLogBind();
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 開發功能：綁定數據到GvDataLog
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-30
        /// </summary>
        private void GvDataLogBind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",1)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvDataLog.DataSource = dt;
                GvDataLog.DataBind();

                for (int i = 0, rowCount = GvDataLog.Rows.Count; i < rowCount; i++)
                {
                    GvDataLog.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvDataLog.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：查詢綁定數據到GvDataLog
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-30
        /// </summary>
        private void GvDataLogSearchBind(string strMac, string strClientName, string strddlMenuTypeId, string strData, string strDataDesc, string strStartDate, string strEndDate, string strActionTypeID)
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
                                      new SqlParameter("@MenuTypeID",strddlMenuTypeId),
                                      new SqlParameter("@Data",strData),
                                      new SqlParameter("@DataDesc",strDataDesc),
                                      new SqlParameter("@StartDate",strStartDate),
                                      new SqlParameter("@EndDate",strEndDate),
                                      new SqlParameter("@ActionType",strActionTypeID)
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvDataLog.DataSource = dt;
                GvDataLog.DataBind();

                for (int i = 0, rowCount = GvDataLog.Rows.Count; i < rowCount; i++)
                {
                    GvDataLog.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvDataLog.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：GvDataLog無數據時，顯示表的框架
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-30
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
            GvDataLog.DataSource = dt;
            GvDataLog.DataBind();
            GvDataLog.Rows[0].Cells.Clear();
            GvDataLog.Rows[0].Cells.Add(new TableCell());
            GvDataLog.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
            GvDataLog.Rows[0].Cells[0].Text = "<font color='red'>None!</font>";
            GvDataLog.Rows[0].Cells[0].Style.Add("text-align", "center");
            GvDataLog.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
        }

        /// <summary>
        /// 開發功能：GvDataLog翻頁功能
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-30
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Replace_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            GvDataLog.PageIndex = e.NewPageIndex;

            GvDataLog.DataSource = dtbs;
            GvDataLog.DataBind();

            for (int i = 0, rowCount = GvDataLog.Rows.Count; i < rowCount; i++)
            {
                GvDataLog.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvDataLog.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvDataLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //類型為頻道、電視劇、音樂和相冊加入單擊事件
            //    if (e.Row.Cells[0].Text == "8" || e.Row.Cells[0].Text == "10" || e.Row.Cells[0].Text=="11" || e.Row.Cells[0].Text=="12")
            //    {
            //        e.Row.Cells[5].Attributes.Add("onmouseover", "this.style.cursor='pointer'");
            //        e.Row.Cells[5].Attributes["style"] = "color:Blue";
            //        e.Row.Cells[5].Attributes.Add("onclick", "DataDetailClick('" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "')");
            //    }

            //}
        }
    }
}
