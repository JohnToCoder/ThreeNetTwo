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
    public partial class Sys_ClientVersion : System.Web.UI.Page
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
                        objUser.GetRight(objUser.RoleCode, "83", this.Page);//頁面按鈕權限管控
                    }

                    if (Request["KeyValue"] == null)
                    {
                        Databind("", "", "", "", "");
                    }
                    else
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        string[] ArrKeyValue = strKeyValue.Split('=');

                        string strMac = "";
                        string strMeno = "";
                        string strId = "";
                        string strVerName = "";
                        string strVerDesc = "";

                        if (ArrKeyValue.Length != 1)
                        {
                            strMac = ArrKeyValue[0];
                            strMeno = ArrKeyValue[1];
                            strId = ArrKeyValue[2];
                            strVerName = ArrKeyValue[3];
                            strVerDesc = ArrKeyValue[4];
                        }

                        Databind(strMac, strMeno, strId, strVerName, strVerDesc);
                    }
                }
                catch
                {

                }
            }
        }

        private void Databind(string strMac,string strMeno,string strId,string strVerName,string strVerDesc)
        {

            SqlParameter[] param ={

                                      new SqlParameter("@Flag",1),
                                      new SqlParameter("@Mac",strMac),
                                      new SqlParameter("@Meno",strMeno),
                                      new SqlParameter("@VerID",strId),
                                      new SqlParameter("@version",strVerName),
                                      new SqlParameter("@VerDesc",strVerDesc)


                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_ClientVersion_sp", param);
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
                GvClient.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 1;
                GvClient.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                GvClient.Rows[0].Cells[0].Style.Add("text-align", "center");
                GvClient.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");

            }

            ViewState["dt"] = dt;
        }

        protected void GvClient_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        /// <summary>
        /// 翻頁（碧清 2011/06/15)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
