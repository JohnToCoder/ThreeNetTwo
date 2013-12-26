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

namespace ThreeNetTwo.Channel
{
    public partial class MD_MyChannel : System.Web.UI.Page
    {
        /// <summary> 
        /// 函數名：Page_Load
        /// 函數功能：加載
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-18
        /// 修改者：
        /// 修改日期：
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    User objUser = new User();
                    objUser = Session["User"] as User;
                    objUser.GetRight(objUser.RoleCode, "12", this.Page);//頁面按鈕權限管控
                }

                if (Request["SearchKey"] != null)
                {
                    string strSearchValue = Request["SearchKey"].ToString().Trim();
                    string[] ArrKeyValue = strSearchValue.Split('=');
                    Select(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(),ArrKeyValue[4].Trim().ToString());
                }
                else
                {
                    Select("", "", "", "","");
                }
            }
        }

        /// <summary> 
        /// 函數名：Select
        /// 函數功能：查詢
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-11
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void Select(string programname, string channelcode, string ServiceID,string usercode, string createdate)
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 30),
                                        new SqlParameter("@ProgramName",programname),
                                        new SqlParameter("@ChannelCode",channelcode),
                                        new SqlParameter("@ServiceID",ServiceID),
                                        new SqlParameter("@UserCode",usercode),
                                        new SqlParameter("@CreatDate",createdate)
                                    };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);
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
        /// 開發日期：2011-03-16
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

        /// <summary> 
        /// 函數名：gdvCurrent_RowDataBound
        /// 函數功能：控制展示字符串長度
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-16
        /// 修改者：
        /// 修改日期：
        /// </summary>
        protected void gdvCurrent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (e.Row.Cells[5].Text != "" && e.Row.Cells[5].Text.ToLower() != "null")
                //{
                //    e.Row.Cells[5].Text = "<a href=\'ChannelAllTV.aspx?id=" + e.Row.Cells[1].Text + "\' target=\'_blank\'>" + e.Row.Cells[5].Text + "</a>";
                //}
                //e.Row.Cells[6].Text = "<span title=\'" + e.Row.Cells[6].Text + "\'>" + Common.SubString(e.Row.Cells[6].Text, 25) + "</span>";
                //e.Row.Cells[7].Text = "<span title=\'" + e.Row.Cells[7].Text + "\'>Channel/" + Common.SubString(e.Row.Cells[7].Text, 7) + "</span>";
            }
        }
    }
}
