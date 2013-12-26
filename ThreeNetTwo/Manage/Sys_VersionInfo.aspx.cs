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

namespace ThreeNetTwo.Manage
{
    public partial class Sys_VersionInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["User"] != null)
                    {
                        User objUser = new User();
                        objUser = Session["User"] as User;
                        objUser.GetRight(objUser.RoleCode, "82", this.Page);//頁面按鈕權限管控
                    }

                    if (Request["KeyValue"] != null)
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        lblFlag.Text = strKeyValue;
                        Select("", "", "", "","");
                    }
                    if (Request["SearchKey"] != null)
                    {
                        string strSearchValue = Request["SearchKey"].ToString().Trim();
                        string[] ArrKeyValue = strSearchValue.Split('=');
                        Select(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString()
                            , ArrKeyValue[3].Trim(),ArrKeyValue[4].Trim());
                    }
                    else
                    {
                        Select("", "", "", "","");
                    }
                }
            }
            catch
            { }
        }

        /// <summary> 
        /// 函數名：Select
        /// 函數功能：頁面初始化顯示和查詢
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void Select(string version, string verdesc, string verdate, string pubdate,string createdate)
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 1),
                                        new SqlParameter("@Version",version),
                                        new SqlParameter("@VerDesc",verdesc),
                                        new SqlParameter("@VerDate",verdate),
                                        new SqlParameter("@PubDate",pubdate),
                                        new SqlParameter("@createdate",createdate)
                                    };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_ServerVersion_sp", param);
            if (dt.Rows.Count > 0)
            {
                gdvCurrent.DataSource = dt;
                gdvCurrent.DataBind();
                ViewState["dt"] = dt;

                for (int i = 0, intRowCount = gdvCurrent.Rows.Count; i < intRowCount; i++)
                {
                    gdvCurrent.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    gdvCurrent.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
                }
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
                gdvCurrent.DataSource = dt;
                gdvCurrent.DataBind();
                gdvCurrent.Rows[0].Cells.Clear();
                gdvCurrent.Rows[0].Cells.Add(new TableCell());
                gdvCurrent.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gdvCurrent.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                gdvCurrent.Rows[0].Cells[0].Style.Add("text-align", "center");
                gdvCurrent.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
        }        

        /// <summary> 
        /// 函數名：gdvCurrent_PageIndexChanging
        /// 函數功能：翻頁
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        protected void gdvCurrent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";

            gdvCurrent.PageIndex = e.NewPageIndex;
            gdvCurrent.DataSource = (DataTable)ViewState["dt"];
            gdvCurrent.DataBind();

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

        protected void gdvCurrent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text.Replace("&nbsp;","").ToString() != "")
                {
                    e.Row.Cells[3].Text = "<a href=\'" + e.Row.Cells[3].Text + "\'>" +getFileName(e.Row.Cells[3].Text.ToString())+ "</a>";
                }
            }
        }
        /// <summary> 
        /// 函數名：getFileName
        /// 函數功能：獲取文件名稱
        /// 開發者： 劉鋒
        /// 開發日期：2011-04-08
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private string getFileName(string strFilePath)
        {
            return strFilePath.Substring(strFilePath.LastIndexOf("/")+1);
        }
    }
}
