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
    public partial class MD_Movie : System.Web.UI.Page
    {
        string strBasePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            strBasePath = Request.PhysicalApplicationPath;
            if (!IsPostBack)
            {
                try
                {
                    if (Session["User"] != null)
                    {
                        User objUser = new User();
                        objUser = Session["User"] as User;
                        objUser.GetRight(objUser.RoleCode, "21", this.Page);//頁面按鈕權限管控
                    }

                    //if(Session[""])
                    //{
                    //判斷是否是修改動作 Edit By Tanyi 2011.3.16
                    if (Request["KeyValue"] != null)
                    {
                        if (Request["strIndex"] != null)
                        {
                            string s = Request["strIndex"].ToString();
                        }
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        lblFlag.Text = strKeyValue;
                        if (Request["strIndex"] != null && Request["strIndex"].ToString() != "")
                        {
                            string strIndex = Request["strIndex"];
                            Gv_Movie.PageIndex = Convert.ToInt32(strIndex);
                            txtPageIndex.Text = Gv_Movie.PageIndex.ToString();
                        }
                        BindMovie();
                    }
                    //當是查詢時 Edit By Tanyi 2011.3.16
                    else if (Request["SearchKey"] != null)
                    {
                        string strSearchValue = Request["SearchKey"].ToString().Trim();
                        string[] ArrKeyValue = strSearchValue.Split('=');
                        DataSearchBind(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim(), ArrKeyValue[5].Trim());
                    }
                    else
                    {
                        BindMovie();
                    }
                    //}
                    //else
                    //{

                    //}
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// 作者：沈譚義
        /// 時間：2011-03-14
        /// 功能描述：綁定電影數據
        /// </summary>
        private void BindMovie()
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",12)
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
        /// Page Change
        /// Edit by tanyi 2011314
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Movie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";
            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_Movie.PageIndex = e.NewPageIndex;

            Gv_Movie.DataSource = dtbs;
            Gv_Movie.DataBind();

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }
        /// <summary>
        /// 字符過長的處理
        /// edit by tanyi 2011314
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Movie_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Text = "<span title=\'" + e.Row.Cells[5].Text + "\'>" + Common.SubString(e.Row.Cells[5].Text,50) + "</span>";
                e.Row.Cells[6].Text = "<span title=\'" + e.Row.Cells[6].Text + "\'><a href=\'" + e.Row.Cells[6].Text + "\' target=\'_blank\'>" + Common.SubString(e.Row.Cells[6].Text, 50) + "</a></span>";
                e.Row.Cells[7].Text = "<span title=\'" + e.Row.Cells[7].Text + "\'>" + Common.SubString(e.Row.Cells[7].Text, 20) + "</span>";
                e.Row.Cells[8].Text = "<span title=\'" + e.Row.Cells[8].Text + "\'>" + Common.SubString(e.Row.Cells[8].Text,20) + "</span>";
                e.Row.Cells[9].Text = "<span title=\'" + e.Row.Cells[9].Text + "\' style='display:block;width:300px;'>" + Common.SubString(e.Row.Cells[9].Text,136) + "</span>";
                e.Row.Cells[10].Text = "<span title=\'" + e.Row.Cells[10].Text + "\'>" + Common.SubString(e.Row.Cells[10].Text, 10) + "</span>";
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }
        /// <summary>
        /// 編號：MD_MD_Form_001
        /// 函數名：DataSearchBind
        /// 函數功能：綁定查詢後表單數據
        /// 開發者： 沈譚義
        /// 開發日期：2010-09-15
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataSearchBind(string strMovieName, string strddlType, string strUrl, string strComeOut, string strDesc, string strMediaSource)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",19),
                                 new SqlParameter("@MovieName",strMovieName),
                                 new SqlParameter("@MoviesURL",strUrl),
                                 new SqlParameter("@MTClassID",strddlType),
                                 new SqlParameter("@ComeOut",strComeOut),
                                 new SqlParameter("@Summary",strDesc),
                                 new SqlParameter("@MediaForID",strMediaSource)
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", param);
            if (dt.Rows.Count > 0)
            {
                Gv_Movie .DataSource = dt;
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
            }
            ViewState["dt"] = dt;
        }
    }
}
