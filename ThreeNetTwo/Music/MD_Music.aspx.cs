using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ThreeNetTwo.Class;

namespace ThreeNetTwo.Music
{
    public partial class MD_Music : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request["strID"] != null)
                    {
                        txtID.Text = Request["strID"].ToString();
                    }
                    //記錄父頁面的索引值以備返回時使用
                    if (Request["pageIndex"] != null)
                    {
                        txtParentIndex.Text = Request["pageIndex"].ToString();
                        Session["ParentIndex"] = txtParentIndex.Text;
                    }

                    if (Session["User"] != null)
                    {
                        User objUser = new User();
                        objUser = Session["User"] as User;
                        objUser.GetRight(objUser.RoleCode, "31", this.Page);//頁面按鈕權限管控
                    }
                    //修改，刪除數據動作后執行
                    if (Request["KeyValue"] != null)
                    {
                        //獲取專輯ID
                        string strID = Request["AlbumID"].ToString();
                        txtID.Text = strID;
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        lblFlag.Text = strKeyValue;                        

                        //修改動作后設置本頁面頁碼
                        if (Request["strIndex"] != null && Request["strIndex"].ToString() != "")
                        {
                            string strIndex = Request["strIndex"];
                            Gv_Music.PageIndex = Convert.ToInt32(strIndex);

                            txtPageIndex.Text = Gv_Music.PageIndex.ToString();
                        }
                        //綁定修改后信息
                        GvMusicBind(strID);
                        txtParentIndex.Text = Session["ParentIndex"].ToString();
                    }

                    //查詢動作信息綁定
                    else if (Request["SearchKey"] != null)
                    {
                        string strSearchValue = Request["SearchKey"].ToString().Trim();
                        string[] ArrKeyValue = strSearchValue.Split('=');
                        DataSearchBind(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim(), ArrKeyValue[5].Trim(), ArrKeyValue[6].Trim());
                        txtID.Text = ArrKeyValue[1].Trim().ToString();
                    }
                    else
                    {
                        string strID = Request["strID"].ToString();
                        GvMusicBind(strID);
                    }
                }
            }
            catch
            { 
            
            }
        }

        /// <summary>
        /// 作者：郭世麗
        /// 時間：2011-03-11
        /// 功能描述：綁定GvMusic數據
        /// </summary>
        private void GvMusicBind(string strID)
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",17),
                                new SqlParameter("@MusicAlbumID",strID)
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_Music.DataSource = dt;
                Gv_Music.DataBind();

                for (int i = 0, intRowCount = Gv_Music.Rows.Count; i < intRowCount; i++)
                {
                    Gv_Music.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_Music.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_Music.DataSource = dt;
                Gv_Music.DataBind();
                Gv_Music.Rows[0].Cells.Clear();
                Gv_Music.Rows[0].Cells.Add(new TableCell());
                Gv_Music.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_Music.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Music.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_Music.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 作者：郭世麗
        /// 時間：2011-03-15
        /// 功能描述：字符串過長顯示處理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Music_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Text = "<span title=\'" + e.Row.Cells[3].Text + "\'>" + Common.SubString(e.Row.Cells[3].Text, 22) + "</span>";
                e.Row.Cells[4].Text = "<span title=\'" + e.Row.Cells[4].Text + "\'>" + Common.SubString(e.Row.Cells[4].Text, 22) + "</span>";
                e.Row.Cells[7].Text = "<span title=\'" + e.Row.Cells[7].Text + "\'><a href=\'"+e.Row.Cells[7].Text+"\' target=\'_blank\'>" + Common.SubString(e.Row.Cells[7].Text, 58) + "</a></span>";
            }
        }

        /// <summary>
        /// 作者：郭世麗
        /// 時間：2011-03-11
        /// 功能描述：Gv_Music翻頁功能 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Music_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";
            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_Music.PageIndex = e.NewPageIndex;

            Gv_Music.DataSource = dtbs;
            Gv_Music.DataBind();

            for (int i = 0, intRowCount = Gv_Music.Rows.Count; i < intRowCount; i++)
            {
                Gv_Music.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                Gv_Music.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }
        /// <summary>
        /// 函數名稱：DataSearchBind
        /// 函數功能：查詢所有音樂的數據綁定
        /// </summary>
        /// <param name="strMusic"></param>
        /// <param name="strMusicAlbumID"></param>
        /// <param name="strddlType"></param>
        /// <param name="strUrl"></param>
        /// <param name="strComeOut"></param>
        /// <param name="strSinger"></param>
        /// <param name="strArea"></param>
        /// <param name="strMediaSource"></param>

        private void DataSearchBind(string strMusic, string strMusicAlbumID, string strddlType, string strUrl, string strComeOut, string strSinger,string strOrder)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",28),
                                 new SqlParameter("@MusicName",strMusic),
                                 new SqlParameter("@MusicAlbumID",strMusicAlbumID),
                                 new SqlParameter("@MusicClassID",strddlType), 
                                 new SqlParameter("@MusicURL",strUrl),       
                                 new SqlParameter("@OrderId",strOrder),
                                 new SqlParameter("@ComeOut",strComeOut),
                                 new SqlParameter("@Creator",strSinger),
                                
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param);
            if (dt.Rows.Count > 0)
            {
                Gv_Music.DataSource = dt;
                Gv_Music.DataBind();
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
                Gv_Music.DataSource = dt;
                Gv_Music.DataBind();
                Gv_Music.Rows[0].Cells.Clear();
                Gv_Music.Rows[0].Cells.Add(new TableCell());
                Gv_Music.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_Music.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Music.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
            ViewState["dt"] = dt;
        }
    }
}
