using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace ThreeNetTwo.Photo
{
    public partial class MD_Photos : System.Web.UI.Page
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
                        objUser.GetRight(objUser.RoleCode, "41", this.Page);//頁面按鈕權限管控
                    }

                    //回傳Key：
                    //若是查詢時標示為SearchKey，且后接查詢參數值
                    //若是其他的動作則為KeyValue，如Add，Delete，Update操作
                    if (Request["SearchKey"] != null){
                        string [] paras = Request["SearchKey"].Split('=');
                        GvPhotoBind(paras);
                    }else{
                        lblFlag.Text = Request["KeyValue"];
                        GvPhotoBind();
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 作者：胡貴
        /// 時間：2011-03-11
        /// 功能描述：綁定GvPhotos數據
        /// </summary>
        public void GvPhotoBind()
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",9)
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "User_Photo_sp", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_Photo.DataSource = dt;
                Gv_Photo.DataBind();

                for (int i = 0, intRowCount = Gv_Photo.Rows.Count; i < intRowCount;i++ )
                {
                    Gv_Photo.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_Photo.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_Photo.DataSource = dt;
                Gv_Photo.DataBind();
                Gv_Photo.Rows[0].Cells.Clear();
                Gv_Photo.Rows[0].Cells.Add(new TableCell());
                Gv_Photo.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_Photo.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Photo.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_Photo.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 作者：胡貴
        /// 時間：2011-03-11
        /// 功能描述：代查詢條件的綁定GvPhotos數據
        /// </summary>
        /// <param name="paras"></param>
        public void GvPhotoBind(string[] paras)
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",9),
                                new SqlParameter("@ImageName",paras[0]==""?null:paras[0]),
                                new SqlParameter("@PicClassID",paras[1]==""?null:paras[1])
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "User_Photo_sp", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_Photo.DataSource = dt;
                Gv_Photo.DataBind();

                for (int i = 0, intRowCount = Gv_Photo.Rows.Count; i < intRowCount; i++)
                {
                    Gv_Photo.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_Photo.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_Photo.DataSource = dt;
                Gv_Photo.DataBind();
                Gv_Photo.Rows[0].Cells.Clear();
                Gv_Photo.Rows[0].Cells.Add(new TableCell());
                Gv_Photo.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_Photo.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_Photo.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_Photo.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 作者：胡貴
        /// 時間：2011-03-11
        /// 功能描述：Gv_Photo翻頁功能
        /// </summary>
        protected void Gv_Replace_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";

            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_Photo.PageIndex = e.NewPageIndex;

            Gv_Photo.DataSource = dtbs;
            Gv_Photo.DataBind();

            for (int i = 0, intRowCount = Gv_Photo.Rows.Count; i < intRowCount; i++)
            {
                Gv_Photo.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                Gv_Photo.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }
    }
}
