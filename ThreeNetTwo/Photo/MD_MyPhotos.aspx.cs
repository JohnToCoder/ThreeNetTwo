using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Photo
{
    public partial class MD_MyPhotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    User objUser = new User();
                    objUser = Session["User"] as User;
                    objUser.GetRight(objUser.RoleCode, "42", this.Page);//頁面按鈕權限管控
                }

                if (Request["SearchKey"] != null)
                {
                    string[] paras = Request["SearchKey"].Split('=');
                    GvMyPhotoBind(paras);
                }
                else
                {
                    GvMyPhotoBind();
                }
            }
        }

        /// <summary>
        /// 作者：胡貴
        /// 時間：2011-03-11
        /// 功能描述：綁定GvPhotos數據
        /// </summary>
        public void GvMyPhotoBind()
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",14)
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "User_Photo_sp", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_MyPhoto.DataSource = dt;
                Gv_MyPhoto.DataBind();

                for (int i = 0, intRowCount = Gv_MyPhoto.Rows.Count; i < intRowCount; i++)
                {
                    Gv_MyPhoto.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_MyPhoto.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_MyPhoto.DataSource = dt;
                Gv_MyPhoto.DataBind();
                Gv_MyPhoto.Rows[0].Cells.Clear();
                Gv_MyPhoto.Rows[0].Cells.Add(new TableCell());
                Gv_MyPhoto.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_MyPhoto.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_MyPhoto.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_MyPhoto.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 作者：胡貴
        /// 時間：2011-03-11
        /// 功能描述：代查詢條件的綁定GvPhotos數據
        /// </summary>
        /// <param name="paras"></param>
        public void GvMyPhotoBind(string[] paras)
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",14),
                                new SqlParameter("@ImageName",paras[0]==""?null:paras[0]),
                                new SqlParameter("@PicClassID",paras[1]==""?null:paras[1]),
                                new SqlParameter("@UserCode",paras[2]==""?null:paras[2]),
                                new SqlParameter("@ServiceID",paras[3]==""?null:paras[3]),
                                
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "User_Photo_sp", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_MyPhoto.DataSource = dt;
                Gv_MyPhoto.DataBind();

                for (int i = 0, intRowCount = Gv_MyPhoto.Rows.Count; i < intRowCount; i++)
                {
                    Gv_MyPhoto.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_MyPhoto.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_MyPhoto.DataSource = dt;
                Gv_MyPhoto.DataBind();
                Gv_MyPhoto.Rows[0].Cells.Clear();
                Gv_MyPhoto.Rows[0].Cells.Add(new TableCell());
                Gv_MyPhoto.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_MyPhoto.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_MyPhoto.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_MyPhoto.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 作者：胡貴
        /// 時間：2011-03-11
        /// 功能描述：Gv_MyPhoto翻頁功能
        /// </summary>
        protected void Gv_Replace_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_MyPhoto.PageIndex = e.NewPageIndex;

            Gv_MyPhoto.DataSource = dtbs;
            Gv_MyPhoto.DataBind();

            for (int i = 0, intRowCount = Gv_MyPhoto.Rows.Count; i < intRowCount; i++)
            {
                Gv_MyPhoto.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                Gv_MyPhoto.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }
    }
}
