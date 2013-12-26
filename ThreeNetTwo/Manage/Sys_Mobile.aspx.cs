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
    public partial class Sys_Mobile : System.Web.UI.Page
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
                        objUser.GetRight(objUser.RoleCode, "73", this.Page);//頁面按鈕權限管控
                    }

                    if (Request["KeyValue"] != null)
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        string[] arrKeyValue = strKeyValue.Split('=');

                        if (arrKeyValue.Length == 1)
                        {
                            GvMobileBind();
                        }
                        else
                        {
                            GvMobileSearchBind(arrKeyValue[0].Trim(), arrKeyValue[1].Trim(), arrKeyValue[2].Trim(), arrKeyValue[3].Trim());
                        }
                    }
                    else
                    {
                        GvMobileBind();
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 開發功能：綁定數據到GvMobile
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-17
        /// </summary>
        private void GvMobileBind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",1)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Mobile_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvMobile.DataSource = dt;
                GvMobile.DataBind();

                for (int i = 0, rowCount = GvMobile.Rows.Count; i < rowCount; i++)
                {
                    GvMobile.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvMobile.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：查詢綁定數據到GvMobile
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-17
        /// </summary>
        private void GvMobileSearchBind(string strMac, string strUserName, string strMobileCode, string strMail)
        {
            SqlParameter[] param ={
                                      new SqlParameter("@flag",2),
                                      new SqlParameter("@Mac",strMac),
                                      new SqlParameter("@MobileCode",strMobileCode),
                                      new SqlParameter("@UserName",strUserName),
                                      new SqlParameter("@Mail",strMail)
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Mobile_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvMobile.DataSource = dt;
                GvMobile.DataBind();

                for (int i = 0, rowCount = GvMobile.Rows.Count; i < rowCount; i++)
                {
                    GvMobile.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvMobile.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：GvMobile無數據時，顯示表的框架
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-17
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
            GvMobile.DataSource = dt;
            GvMobile.DataBind();
            GvMobile.Rows[0].Cells.Clear();
            GvMobile.Rows[0].Cells.Add(new TableCell());
            GvMobile.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
            GvMobile.Rows[0].Cells[0].Text = "<font color='red'>None!</font>";
            GvMobile.Rows[0].Cells[0].Style.Add("text-align", "center");
            GvMobile.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
        }

        /// <summary>
        /// 開發功能：GvMobile翻頁功能
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-17
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Replace_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            GvMobile.PageIndex = e.NewPageIndex;

            GvMobile.DataSource = dtbs;
            GvMobile.DataBind();

            for (int i = 0, rowCount = GvMobile.Rows.Count; i < rowCount; i++)
            {
                GvMobile.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvMobile.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }
    }
}
