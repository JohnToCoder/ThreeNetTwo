using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ThreeNetTwo.Class;

namespace ThreeNetTwo.Music
{
    public partial class MD_MyMusic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    User objUser = new User();
                    objUser = Session["User"] as User;
                    objUser.GetRight(objUser.RoleCode, "33", this.Page);//頁面按鈕權限管控
                }

                if (Request["SearchKey"] != null)
                {
                    string strSearchValue = Request["SearchKey"].ToString().Trim();
                    string[] ArrKeyValue = strSearchValue.Split('=');
                    DateSearchBindForMyMusic(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim(),ArrKeyValue[5].Trim().ToString());
                }
                else
                { 
                    GvMyMusicBind();
                }
            }
        }
        /// <summary>
        /// 我的音樂初始化顯示
        /// </summary>
        private void GvMyMusicBind()
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",32),
                                new SqlParameter("@strUserIP",""),
                                new SqlParameter("@MusicName",""),
                                new SqlParameter("@AlbumName",""),
                                new SqlParameter("@Creator",""),
                                new SqlParameter("@CreatDate",""),
                                new SqlParameter("@ServiceID",""),

                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_MyMusic.DataSource = dt;
                Gv_MyMusic.DataBind();

                for (int i = 0, intRowCount = Gv_MyMusic.Rows.Count; i < intRowCount; i++)
                {
                    Gv_MyMusic.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_MyMusic.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_MyMusic.DataSource = dt;
                Gv_MyMusic.DataBind();
                Gv_MyMusic.Rows[0].Cells.Clear();
                Gv_MyMusic.Rows[0].Cells.Add(new TableCell());
                Gv_MyMusic.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_MyMusic.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_MyMusic.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
            ViewState["dt"] = dt;
        }
        
        /// <summary>
        /// 查詢我的音樂信息
        /// </summary>
        /// <param name="strMusicName"></param>
        /// <param name="strAlbumName"></param>
        /// <param name="strSinger"></param>
        /// <param name="strCreator"></param>
        /// <param name="strCreatDate"></param>
        private void DateSearchBindForMyMusic(string strMusicName,string strAlbumName,string strSinger,string strCreator,string strCreatDate,string strServiceID)
        { 
                SqlParameter[] Paras ={
                                new SqlParameter("@flag",32),
                                new SqlParameter("@strUserIP",strCreator),
                                new SqlParameter("@MusicName",strMusicName),
                                new SqlParameter("@AlbumName",strAlbumName),
                                new SqlParameter("@Creator",strSinger),
                                new SqlParameter("@CreatDate",strCreatDate),
                                new SqlParameter("@ServiceID",strServiceID),

                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_MyMusic.DataSource = dt;
                Gv_MyMusic.DataBind();

                for (int i = 0, intRowCount = Gv_MyMusic.Rows.Count; i < intRowCount; i++)
                {
                    Gv_MyMusic.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_MyMusic.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_MyMusic.DataSource = dt;
                Gv_MyMusic.DataBind();
                Gv_MyMusic.Rows[0].Cells.Clear();
                Gv_MyMusic.Rows[0].Cells.Add(new TableCell());
                Gv_MyMusic.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_MyMusic.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_MyMusic.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
            ViewState["dt"] = dt;
        
        }
        /// <summary>
        /// 翻頁事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_MyMusic_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_MyMusic.PageIndex = e.NewPageIndex;

            Gv_MyMusic.DataSource = dtbs;
            Gv_MyMusic.DataBind();

            for (int i = 0, intRowCount = Gv_MyMusic.Rows.Count; i < intRowCount; i++)
            {

                Gv_MyMusic.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                Gv_MyMusic.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

        protected void Gv_MyMusic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                e.Row.Cells[2].Text = "<span title=\'" + e.Row.Cells[2].Text + "\'>" + Common.SubString(e.Row.Cells[2].Text, 20) + "</span>";
                e.Row.Cells[3].Text = "<span title=\'" + e.Row.Cells[3].Text + "\'>" + Common.SubString(e.Row.Cells[3].Text, 20) + "</span>";
                e.Row.Cells[4].Text = "<span title=\'" + e.Row.Cells[4].Text + "\'><a href=\'" + e.Row.Cells[4].Text + "\' target=\'_blank\'>" + Common.SubString(e.Row.Cells[4].Text, 58) + "</a></span>";
            }

        }
    }
}
