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
    public partial class MD_Album : System.Web.UI.Page
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
                        objUser.GetRight(objUser.RoleCode, "31", this.Page);//頁面按鈕權限管控
                    }
                    //新增，修改后結果展示
                    if (Request["KeyValue"] != null)
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        lblFlag.Text = strKeyValue;

                        //修改后設置頁碼索引
                        if (Request["strIndex"] != null && Request["strIndex"].ToString() != "")
                        {
                            string strIndex = Request["strIndex"];
                            Gv_Album.PageIndex = Convert.ToInt32(strIndex);
                            //保存當前索引
                            txtPageIndex.Text = Gv_Album.PageIndex.ToString();
                        }

                        GvAlbumBind();
                        
                    }
                    //查詢結果展示
                    else if (Request["SearchKey"] != null)
                    {
                        string strSearchValue = Request["SearchKey"].ToString().Trim();
                        string[] ArrKeyValue = strSearchValue.Split('=');
                        DataSearchBind(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim(), ArrKeyValue[5].Trim());
                    }
                    else
                    {
                        //從Detail頁面返回時設置頁碼索引值
                        if (Request["strPIndex"] != null && Request["strPIndex"].ToString() != "")
                        {
                            string strPIndex = Request["strPIndex"];
                            Gv_Album.PageIndex = Convert.ToInt32(strPIndex);
                            //保存當前索引
                            txtPageIndex.Text = Gv_Album.PageIndex.ToString();
                        }
                        GvAlbumBind();
                    }
                }
            }
            catch
            { 
            
            }            
        }

        /// <summary>
        /// 作者：郭世麗
        /// 時間：2011-03-16
        /// 功能描述：綁定Gv_Album數據 
        /// </summary>
        private void GvAlbumBind()
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",18)
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_Album.DataSource = dt;
                Gv_Album.DataBind();

                for (int i = 0, intRowCount = Gv_Album.Rows.Count; i < intRowCount; i++)
                {
                    Gv_Album.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_Album.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_Album.DataSource = dt;
                Gv_Album.DataBind();
                Gv_Album.Rows[0].Cells.Clear();
                Gv_Album.Rows[0].Cells.Add(new TableCell());
                Gv_Album.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_Album.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Album.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_Album.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 作者：郭世麗
        /// 時間：2011-03-16
        /// 功能描述：Gv_Album翻頁功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Album_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";

            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_Album.PageIndex = e.NewPageIndex;

            Gv_Album.DataSource = dtbs;
            Gv_Album.DataBind();

            for (int i = 0, intRowCount = Gv_Album.Rows.Count; i < intRowCount; i++)
            {
                Gv_Album.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                Gv_Album.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();

        }

        /// <summary>
        /// 作者：郭世麗
        /// 時間：2011-03-16
        /// 功能描述：字符串過長顯示處理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_Album_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Text = "<span title=\'" + e.Row.Cells[3].Text + "\'>" + Common.SubString(e.Row.Cells[3].Text, 22) + "</span>";
                e.Row.Cells[5].Text = "<span title=\'" + e.Row.Cells[5].Text + "\'>" + Common.SubString(e.Row.Cells[5].Text, 10) + "</span>";
                e.Row.Cells[6].Text = "<span title=\'" + e.Row.Cells[6].Text + "\'><a href=\'" + e.Row.Cells[6].Text + "\' target=\'_blank\'>" + Common.SubString(e.Row.Cells[6].Text, 58) + "</a></span>";
            }
        }
        /// <summary>
        /// 函數名：DataSearchBind
        /// 功能描述：專輯信息查詢后數據綁定
        /// </summary>
        /// <param name="strAlbumName"></param>
        /// <param name="strddlType"></param>
        /// <param name="strUrl"></param>
        /// <param name="strComeOut"></param>
        /// <param name="strSinger"></param>
        /// <param name="strMediaSource"></param>
        private void DataSearchBind(string strAlbumName, string strddlType, string strUrl, string strComeOut, string strSinger,string strMediaSource)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",23),
                                 new SqlParameter("@AlbumName",strAlbumName),                                 
                                 new SqlParameter("@MusicClassID",strddlType), 
                                 new SqlParameter("@AlbumURL",strUrl),
                                 new SqlParameter("@ComeOut",strComeOut),
                                 new SqlParameter("@Creator",strSinger),
                                 new SqlParameter("@MediaTypeID",strMediaSource)
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Music_sp]", param);
            if (dt.Rows.Count > 0)
            {
                Gv_Album.DataSource = dt;
                Gv_Album.DataBind();
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
                Gv_Album.DataSource = dt;
                Gv_Album.DataBind();
                Gv_Album.Rows[0].Cells.Clear();
                Gv_Album.Rows[0].Cells.Add(new TableCell());
                Gv_Album.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_Album.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Album.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
            ViewState["dt"] = dt;
        }
    }
}
