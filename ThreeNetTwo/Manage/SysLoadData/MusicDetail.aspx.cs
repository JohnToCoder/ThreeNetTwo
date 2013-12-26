using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Manage.SysLoadData
{
    public partial class MusicDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string menuTypeId = Request["menuTypeId"].ToString();
                    string Id = Request["Id"].ToString();

                    //類型為音樂時顯示音樂明細數據
                    if (menuTypeId == "11")
                    {
                        DataBind(menuTypeId,Id);
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 開發功能：綁定數據到GvDataDetail
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-31
        /// </summary>
        private void DataBind(string strMenuTypeId,string strDataId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",7),
                                     new SqlParameter("@MenuTypeID",strMenuTypeId),
                                     new SqlParameter("@LoadDataID",strDataId)
                                     
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvDataDetail.DataSource = dt;
                GvDataDetail.DataBind();

                for (int i = 0, rowCount = GvDataDetail.Rows.Count; i < rowCount; i++)
                {
                    GvDataDetail.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvDataDetail.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：GvDataDetail無數據時，顯示表的框架
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-30
        /// </summary>
        /// <param name="dt"></param>
        private void getNullValue(DataTable dt)
        {
            DataRow row = dt.NewRow();
            foreach (DataColumn column in dt.Columns)
            {
                column.AllowDBNull = true;
                row[column] = DBNull.Value;
            }
            dt.Rows.Add(row);
            GvDataDetail.DataSource = dt;
            GvDataDetail.DataBind();
            GvDataDetail.Rows[0].Cells.Clear();
            GvDataDetail.Rows[0].Cells.Add(new TableCell());
            GvDataDetail.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
            GvDataDetail.Rows[0].Cells[0].Text = "<font color='red'>None!</font>";
            GvDataDetail.Rows[0].Cells[0].Style.Add("text-align", "center");
            GvDataDetail.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
        }

        /// <summary>
        /// 開發功能：GvDataDetail翻頁功能
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-31
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvDataDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            GvDataDetail.PageIndex = e.NewPageIndex;

            GvDataDetail.DataSource = dtbs;
            GvDataDetail.DataBind();

            for (int i = 0, rowCount = GvDataDetail.Rows.Count; i < rowCount; i++)
            {
                GvDataDetail.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvDataDetail.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }

        protected void GvDataDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCellCollection tHeader = e.Row.Cells;
                tHeader.Clear();
                tHeader.Add(new TableHeaderCell());
                tHeader[0].Attributes.Add("colspan", "2");//合并表頭
                tHeader[0].Attributes.Add("bgcolor", "#d1ecfc");
                tHeader[0].Style.Add("border", "1px solid #53bdcb");
                //tHeader[0].Text = "";

                SqlParameter[] param ={
                                     new SqlParameter("@flag",8),
                                     new SqlParameter("@LoadDataID",Request["Id"].ToString())
                                     
                                };
                DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);

                if (dt.Rows.Count > 0)
                {
                    e.Row.Cells[0].Text = dt.Rows[0][0].ToString();//表頭的標題
                }
            }
        }
    }
}
