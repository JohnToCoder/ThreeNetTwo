using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ThreeNetTwo.Class;

namespace ThreeNetTwo.Movie
{
    public partial class MD_MyMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request["Flag"] != null)
                {
                    string strFlag = Request["Flag"].ToString();
                    if (strFlag == "1")
                    {
                        if (Session["User"] != null)
                        {
                            User objUser = new User();
                            objUser = Session["User"] as User;
                            objUser.GetRight(objUser.RoleCode, "23", this.Page);//頁面按鈕權限管控
                        }

                        txtFlag.Text = "1";//我的電影
                        //綁定我的電影頁面 Edit By tanyi 2011-3-18

                        //當是查詢時 Edit By Tanyi 2011.3.16
                        if (Request["SearchKeyForMovie"] != null)
                        {
                            string strSearchValue = Request["SearchKeyForMovie"].ToString().Trim();
                            string[] ArrKeyValue = strSearchValue.Split('=');
                            DataSearchBind(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim(),ArrKeyValue[5].Trim().ToString());
                        }
                        else
                        {
                            BindGVMyMovie();
                        }
                    }
                    else if (strFlag == "2")
                    {
                        if (Session["User"] != null)
                        {
                            User objUser = new User();
                            objUser = Session["User"] as User;
                            objUser.GetRight(objUser.RoleCode, "24", this.Page);//頁面按鈕權限管控
                        }

                        txtFlag.Text = "2";//我的電視劇
                        if (Request["SearchKeyForTV"] != null)
                        {
                            string strSearchValue = Request["SearchKeyForTV"].ToString().Trim();
                            string[] ArrKeyValue = strSearchValue.Split('=');
                            DataSearchBindForTV(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim(),ArrKeyValue[5].Trim().ToString());
                        }
                        else
                        {
                            BindTVData();
                        }
                    }

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>startRequest();</script>");
                }
            }
        }
        /// <summary>
        /// 查詢電視節目
        /// Edit By Tanyi 2011.3.21
        /// </summary>
        /// <param name="strTVName"></param>
        /// <param name="strUrl"></param>
        /// <param name="strComeOut"></param>
        /// <param name="strCreator"></param>
        /// <param name="strCreatDate"></param>
        private void DataSearchBindForTV(string strTVName, string strUrl, string strComeOut, string strCreator, string strCreatDate,string strServiceID)
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",30),
                                new SqlParameter("@ip",strCreator),
                                new SqlParameter("@TVPlayName",strTVName),
                                new SqlParameter("@TVPlayURL",strUrl),
                                new SqlParameter("@ComeOut",strComeOut),
                                new SqlParameter("@CreatDate",strCreatDate),
                                new SqlParameter("@ServiceID",strServiceID)
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_TVPlay_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                gvTV.DataSource = dt;
                gvTV.DataBind();
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
                gvTV.DataSource = dt;
                gvTV.DataBind();
                gvTV.Rows[0].Cells.Clear();
                gvTV.Rows[0].Cells.Add(new TableCell());
                gvTV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvTV.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                gvTV.Rows[0].Cells[0].Style.Add("text-align", "center");
                gvTV.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;
        }
        /// <summary>
        /// 初始化綁定電視節目的功能
        /// Edit By Tanyi 2011.3.21
        /// </summary>
        private void BindTVData()
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",30),
                                new SqlParameter("@ip",""),
                                new SqlParameter("@TVPlayName",""),
                                new SqlParameter("@TVPlayURL",""),
                                new SqlParameter("@ComeOut",""),
                                new SqlParameter("@CreatDate",""),
                                new SqlParameter("@ServiceID","")
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_TVPlay_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                gvTV.DataSource = dt;
                gvTV.DataBind();
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
                gvTV.DataSource = dt;
                gvTV.DataBind();
                gvTV.Rows[0].Cells.Clear();
                gvTV.Rows[0].Cells.Add(new TableCell());
                gvTV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvTV.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                gvTV.Rows[0].Cells[0].Style.Add("text-align", "center");
                gvTV.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;
        }
        /// <summary>
        /// 點擊查詢時執行過程
        /// Edit By tanyi 2011.3.18
        /// </summary>
        /// <param name="strMovieName"></param>
        /// <param name="strUrl"></param>
        /// <param name="strComeOut"></param>
        /// <param name="strCreator"></param>
        /// <param name="strCreatDate"></param>
        private void DataSearchBind(string strMovieName, string strUrl, string strComeOut, string strCreator, string strCreatDate,string strServiceID)
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",21),
                                new SqlParameter("@strUserIP",strCreator),
                                new SqlParameter("@MovieName",strMovieName),
                                new SqlParameter("@MoviesURL",strUrl),
                                new SqlParameter("@ComeOut",strComeOut),
                                new SqlParameter("@CreatDate",strCreatDate),
                                new SqlParameter("@ServiceID",strServiceID)

                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_Movie.DataSource = dt;
                Gv_Movie.DataBind();
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
                Gv_Movie.DataSource = dt;
                Gv_Movie.DataBind();
                Gv_Movie.Rows[0].Cells.Clear();
                Gv_Movie.Rows[0].Cells.Add(new TableCell());
                Gv_Movie.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_Movie.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Movie.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_Movie.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;
        }
        /// <summary>
        /// 初始化頁面時綁定我的電影
        /// Edit By tanyi 2011-3-18
        /// </summary>
        private void BindGVMyMovie()
        {
            
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",21),
                                new SqlParameter("@strUserIP",""),
                                new SqlParameter("@MovieName",""),
                                new SqlParameter("@MoviesURL",""),
                                new SqlParameter("@ComeOut",""),
                                new SqlParameter("@CreatDate",""),
                                new SqlParameter("@ServiceID","")
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_Movie.DataSource = dt;
                Gv_Movie.DataBind();
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
                Gv_Movie.DataSource = dt;
                Gv_Movie.DataBind();
                Gv_Movie.Rows[0].Cells.Clear();
                Gv_Movie.Rows[0].Cells.Add(new TableCell());
                Gv_Movie.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_Movie.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Movie.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_Movie.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;
        }
        /// <summary>
        /// 翻頁效果　Edit By tanyi 2011.3.18
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Movie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_Movie.PageIndex = e.NewPageIndex;

            Gv_Movie.DataSource = dtbs;
            Gv_Movie.DataBind();
            setDefaultStyle();
        }
        /// <summary>
        /// 截取字符長度，及移動效果 Edit By tanyi 2011.3.18
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Movie_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = "<span title=\'" + e.Row.Cells[1].Text + "\'>" + Common.SubString(e.Row.Cells[1].Text, 50) + "</span>";
                e.Row.Cells[2].Text = "<span title=\'" + e.Row.Cells[2].Text + "\'><a href=\'" + e.Row.Cells[2].Text + "\' target=\'_blank\'>" + Common.SubString(e.Row.Cells[2].Text, 50) + "</a></span>";
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }
        /// <summary>
        /// 翻頁效果　Edit By tanyi 2011.3.18
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            gvTV.PageIndex = e.NewPageIndex;

            gvTV.DataSource = dtbs;
            gvTV.DataBind();
            setDefaultStyle();
        }
        /// <summary>
        /// 截取字符長度，及移動效果 Edit By tanyi 2011.3.18
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = "<span title=\'" + e.Row.Cells[1].Text + "\'>" + Common.SubString(e.Row.Cells[1].Text, 50) + "</span>";
                e.Row.Cells[3].Text = "<span title=\'" + e.Row.Cells[3].Text + "\'><a href=\'" + e.Row.Cells[3].Text + "\' target=\'_blank\'>" + Common.SubString(e.Row.Cells[3].Text, 50) + "</a></span>";
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }
        /// <summary>
        /// 開發功能：GridView回傳頁面時樣式的設定
        /// 開發人員：沈譚義
        /// 開發時間：2011-03-18
        /// </summary>
        protected void setDefaultStyle()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>startRequest();</script>");
        }
    }
}
