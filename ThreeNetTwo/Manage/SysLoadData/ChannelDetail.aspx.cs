using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ThreeNetTwo.Manage.SysLoadData
{
    public partial class ChannelDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string menuTypeId = Request["menuTypeId"].ToString();
                    string Id = Request["Id"].ToString();

                    //類型為頻道時顯示頻道明細數據
                    if (menuTypeId == "8")
                    {
                        DataBind(menuTypeId, Id);
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 開發功能：綁定數據到GvChannelDetail
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-08
        /// </summary>
        private void DataBind(string strMenuTypeId, string strDataId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",3),
                                     new SqlParameter("@MenuTypeID",strMenuTypeId),
                                     new SqlParameter("@LoadDataID",strDataId)
                                     
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvChannelDetail.DataSource = dt;
                GvChannelDetail.DataBind();

                for (int i = 0, rowCount = GvChannelDetail.Rows.Count; i < rowCount; i++)
                {
                    GvChannelDetail.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvChannelDetail.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：GvChannelDetail無數據時，顯示表的框架
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-08
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
            GvChannelDetail.DataSource = dt;
            GvChannelDetail.DataBind();
            GvChannelDetail.Rows[0].Cells.Clear();
            GvChannelDetail.Rows[0].Cells.Add(new TableCell());
            GvChannelDetail.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
            GvChannelDetail.Rows[0].Cells[0].Text = "<font color='red'>None!</font>";
            GvChannelDetail.Rows[0].Cells[0].Style.Add("text-align", "center");
            GvChannelDetail.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
        }

        /// <summary>
        /// 開發功能：GvChannelDetail翻頁功能
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-08
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvChannelDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            GvChannelDetail.PageIndex = e.NewPageIndex;

            GvChannelDetail.DataSource = dtbs;
            GvChannelDetail.DataBind();

            for (int i = 0, rowCount = GvChannelDetail.Rows.Count; i < rowCount; i++)
            {
                GvChannelDetail.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvChannelDetail.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }

        protected void GvChannelDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCellCollection tHeader = e.Row.Cells;
                tHeader.Clear();
                tHeader.Add(new TableHeaderCell());
                tHeader[0].Attributes.Add("bgcolor", "#d1ecfc");
                tHeader[0].Attributes.Add("colspan", "3");//合并表頭
                tHeader[0].Style.Add("border", "1px solid #53bdcb");
                
                //tHeader[0].Text = "";
                tHeader.Add(new TableHeaderCell());
                tHeader[1].Text = "節目名稱";
                tHeader[1].Attributes.Add("bgcolor", "#d1ecfc");
                tHeader[1].Style.Add("border", "1px solid #53bdcb");
                tHeader[1].Style.Add("font-size", "12px");
                tHeader[1].Style.Add("height", "20px");
                tHeader[1].Style.Add("text-align", "left");
                
                tHeader.Add(new TableHeaderCell());
                tHeader[2].Text = "播放日期";
                tHeader[2].Attributes.Add("bgcolor", "#d1ecfc");
                tHeader[2].Style.Add("border", "1px solid #53bdcb");
                tHeader[2].Style.Add("font-size", "12px");
                tHeader[2].Style.Add("height", "20px");
                tHeader[2].Style.Add("text-align", "left");
               
                tHeader.Add(new TableHeaderCell());
                tHeader[3].Text = "播放時間";
                tHeader[3].Attributes.Add("bgcolor", "#d1ecfc");
                tHeader[3].Style.Add("border", "1px solid #53bdcb");
                tHeader[3].Style.Add("font-size", "12px");
                tHeader[3].Style.Add("height", "20px");
                tHeader[3].Style.Add("text-align", "left");
                
                SqlParameter[] param ={
                                     new SqlParameter("@flag",4),
                                     new SqlParameter("@LoadDataID",Request["Id"].ToString())
                                     
                                };
                DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);

                if (dt.Rows.Count > 0)
                {
                    tHeader[0].Text = dt.Rows[0][0].ToString() + "</th></tr><tr>";//表頭的標題
                }
            }
        }

    }
}
