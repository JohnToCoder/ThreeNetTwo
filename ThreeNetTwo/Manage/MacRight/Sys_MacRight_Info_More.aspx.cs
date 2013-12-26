using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Manage.MacRight
{
    public partial class Sys_MacRight_Info_More : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {

                    string strFlag = Request["flag"].ToString();
                    string strRoleId = Request["mac"].ToString();
                    string strClassName = Request["class"].ToString();
                    string strPlayDate = Request["playDate"].ToString().Replace("/", "").Trim();

                    string strMovieName = Request["MovieName"].ToString();
                    string strTvDate = Request["TVDate"].ToString();

                    string strMName = Request["Mname"].ToString();
                    string strMdate = Request["Mdate"].ToString();
                    string strClass = Request["MClass"].ToString();

                    if (strFlag == "1")
                    {
                        //lblClass.Style.Add("display", "none");
                        //txtClass.Style.Add("display", "none");
                        DropListBind();
                        channel.Style.Add("display", "block");

                        Movie.Style.Add("display", "none");
                        trMusic.Style.Add("display", "none");
                        trdlMusic.Style.Add("display", "none");

                        dataBind(strRoleId, strClassName, strPlayDate);
                    }

                    if (strFlag == "2" || strFlag == "3")
                    {

                        if (strFlag == "2")
                        {
                            lblMovie.Text = "電影名稱";
                        }
                        if (strFlag == "3")
                        {
                            lblMovie.Text = "電視劇名稱";
                        }

                        channel.Style.Add("display", "none");

                        trMusic.Style.Add("display", "none");
                        trdlMusic.Style.Add("display", "none");
                        Movie.Style.Add("display", "block");

                        dataOtherBind(strFlag,strRoleId,strMovieName,strTvDate);
                    }



                    if (strFlag == "4" || strFlag == "5")
                    {
                        if (strFlag == "4")
                        {
                            lblMname.Text = "所屬專輯";
                            lblPhoto.Text = "音樂名稱";
                            DropListBind1("4");

                        }

                        if (strFlag == "5")
                        {
                            lblMname.Text = "所屬相冊";
                            lblPhoto.Text = "相冊名稱";
                            DropListBind1("5");
                        }

                        channel.Style.Add("display", "none");
                        Movie.Style.Add("display", "none");
                        trMusic.Style.Add("display", "block");
                        trdlMusic.Style.Add("display", "block");

                        dataOtherBindMusic(strFlag, strRoleId,strMName, strMdate, strClass);
                    }

                    txtFlag.Text = strFlag;
                    txtRole.Text = Request["mac"].ToString();

                }
            }
            catch
            {

            }

        }


        private void dataBind(string strRole,  string strClass, string strDate)
        {

            SqlParameter[] param ={
                                     new SqlParameter("@flag",7),
                                     new SqlParameter("@doubleClick",2),
                                     new SqlParameter("@MacRoleId",strRole),
                                     new SqlParameter("@ChannelDesc",strClass),
                                     new SqlParameter("@CreateDate",strDate)

                                 };


            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[Sys_MacRight_sp]", param);

            if (dtb.Rows.Count > 0)
            {
                Sys_GvMac.DataSource = dtb;
                Sys_GvMac.DataBind();
            }

            else
            {


                DataRow row = dtb.NewRow();
                foreach (DataColumn col in dtb.Columns)
                {
                    col.AllowDBNull = true;
                    row[col] = DBNull.Value;
                }
                dtb.Rows.Add(row);
                Sys_GvMac.DataSource = dtb;
                Sys_GvMac.DataBind();
                Sys_GvMac.Rows[0].Cells.Clear();
                Sys_GvMac.Rows[0].Cells.Add(new TableCell());
                Sys_GvMac.Rows[0].Cells[0].ColumnSpan = dtb.Columns.Count - 1;
                Sys_GvMac.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Sys_GvMac.Rows[0].Cells[0].Style.Add("text-align", "center");
                Sys_GvMac.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");

            }

            ViewState["dt"] = dtb;
        }


        private void dataOtherBind(string strFlag, string strRole, string strName, string strDate)
        {

            SqlParameter[] param ={
                                     new SqlParameter("@flag",8),
                                     new SqlParameter("@doubleClick",2),
                                     new SqlParameter("@MacRoleId",strRole),
                                     new SqlParameter("@MovieName",strName),
                                     new SqlParameter("@CreateDate",strDate)
                                     
                                 };

            DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.StoredProcedure, "[Sys_MacRight_sp]", param);

            if (strFlag == "2")
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gvother.DataSource = ds.Tables[0];
                    Gvother.DataBind();
                }
                else
                {
                    DataRow row = ds.Tables[0].NewRow();
                    foreach (DataColumn col in ds.Tables[0].Columns)
                    {
                        col.AllowDBNull = true;
                        row[col] = DBNull.Value;
                    }
                    ds.Tables[0].Rows.Add(row);
                    Gvother.DataSource = ds.Tables[0];
                    Gvother.DataBind();
                    Gvother.Rows[0].Cells.Clear();
                    Gvother.Rows[0].Cells.Add(new TableCell());
                    Gvother.Rows[0].Cells[0].ColumnSpan = ds.Tables[0].Columns.Count - 3;
                    Gvother.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                    Gvother.Rows[0].Cells[0].Style.Add("text-align", "center");
                    Gvother.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
                }
                ViewState["dt"] = ds.Tables[0];
            }

            if (strFlag == "3")
            {

                if (ds.Tables[1].Rows.Count > 0)
                {
                    Gvother.DataSource = ds.Tables[1];
                    Gvother.DataBind();
                }
                else
                {
                    DataRow row = ds.Tables[1].NewRow();
                    foreach (DataColumn col in ds.Tables[1].Columns)
                    {
                        col.AllowDBNull = true;
                        row[col] = DBNull.Value;
                    }
                    ds.Tables[1].Rows.Add(row);
                    Gvother.DataSource = ds.Tables[1];
                    Gvother.DataBind();
                    Gvother.Rows[0].Cells.Clear();
                    Gvother.Rows[0].Cells.Add(new TableCell());
                    Gvother.Rows[0].Cells[0].ColumnSpan = ds.Tables[1].Columns.Count - 3;
                    Gvother.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                    Gvother.Rows[0].Cells[0].Style.Add("text-align", "center");
                    Gvother.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
                }
                ViewState["dt"] = ds.Tables[1];

                Gvother.HeaderRow.Cells[0].Text = "電視劇名稱";
            }
        }


        private void dataOtherBindMusic(string strFlag, string strRole, string strName, string strDate, string strClass)
        {

            SqlParameter[] param ={
                                     new SqlParameter("@flag",9),
                                     new SqlParameter("@doubleClick",2),
                                     new SqlParameter("@MacRoleId",strRole),
                                     new SqlParameter("@MusicName",strName),
                                     new SqlParameter("@class",strClass),
                                     new SqlParameter("@CreateDate",strDate)
                                 };

            DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.StoredProcedure, "[Sys_MacRight_sp]", param);

            if (strFlag == "4")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvMusicPhoto.DataSource = ds.Tables[0];
                    gvMusicPhoto.DataBind();
                }
                else
                {
                    DataRow row = ds.Tables[0].NewRow();
                    foreach (DataColumn col in ds.Tables[0].Columns)
                    {
                        col.AllowDBNull = true;
                        row[col] = DBNull.Value;
                    }
                    ds.Tables[0].Rows.Add(row);
                    gvMusicPhoto.DataSource = ds.Tables[0];
                    gvMusicPhoto.DataBind();
                    gvMusicPhoto.Rows[0].Cells.Clear();
                    gvMusicPhoto.Rows[0].Cells.Add(new TableCell());
                    gvMusicPhoto.Rows[0].Cells[0].ColumnSpan = ds.Tables[0].Columns.Count - 3;
                    gvMusicPhoto.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                    gvMusicPhoto.Rows[0].Cells[0].Style.Add("text-align", "center");
                    gvMusicPhoto.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
                }

                ViewState["dt"] = ds.Tables[0];
            }

            if (strFlag == "5")
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvMusicPhoto.DataSource = ds.Tables[1];
                    gvMusicPhoto.DataBind();
                }
                else
                {
                    DataRow row = ds.Tables[1].NewRow();
                    foreach (DataColumn col in ds.Tables[1].Columns)
                    {
                        col.AllowDBNull = true;
                        row[col] = DBNull.Value;
                    }
                    ds.Tables[1].Rows.Add(row);
                    gvMusicPhoto.DataSource = ds.Tables[1];
                    gvMusicPhoto.DataBind();
                    gvMusicPhoto.Rows[0].Cells.Clear();
                    gvMusicPhoto.Rows[0].Cells.Add(new TableCell());
                    gvMusicPhoto.Rows[0].Cells[0].ColumnSpan = ds.Tables[1].Columns.Count - 3;
                    gvMusicPhoto.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                    gvMusicPhoto.Rows[0].Cells[0].Style.Add("text-align", "center");
                    gvMusicPhoto.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
                }
                gvMusicPhoto.HeaderRow.Cells[1].Text = "相冊名稱";
                gvMusicPhoto.HeaderRow.Cells[0].Text = "授權相冊";
                ViewState["dt"] = ds.Tables[1];
            }
        }


        protected void Sys_GvMac_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            Sys_GvMac.PageIndex = e.NewPageIndex;

            Sys_GvMac.DataSource = dtbs;
            Sys_GvMac.DataBind();
        }

        protected void Sys_GvMac_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }


        protected void Gvother_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            Gvother.PageIndex = e.NewPageIndex;

            Gvother.DataSource = dtbs;
            Gvother.DataBind();
        }


        protected void Gvother_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        protected void gvMusicPhoto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            gvMusicPhoto.PageIndex = e.NewPageIndex;

            gvMusicPhoto.DataSource = dtbs;
            gvMusicPhoto.DataBind();
        }

        protected void gvMusicPhoto_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        private void DropListBind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",16)
                                 };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);

            ddlClass.DataValueField = "ChannelCode";
            ddlClass.DataTextField = "ChannelDesc";
            ddlClass.DataSource = dtb;
            ddlClass.DataBind();

            ddlClass.Items.Insert(0, "");
        }

        private void DropListBind1(string strFlag)
        {

            if (strFlag == "4")
            {
                SqlParameter[] param ={
                                     new SqlParameter("@flag",17)
                                 };
                DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);


                ddlIistClass.DataValueField = "ID";
                ddlIistClass.DataTextField = "AlbumName";
                ddlIistClass.DataSource = dtb;
                ddlIistClass.DataBind();
            }

            else
            {
                SqlParameter[] param ={
                                     new SqlParameter("@flag",18)
                                 };
                DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);


                ddlIistClass.DataValueField = "PicCatID";
                ddlIistClass.DataTextField = "PictureCataLog";
                ddlIistClass.DataSource = dtb;
                ddlIistClass.DataBind();
            }

            ddlIistClass.Items.Insert(0, "");
        }
    }
}
