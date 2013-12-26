using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace ThreeNetTwo.Channel
{
    public partial class MD_ChannelMoreInfo : System.Web.UI.Page
    {
        /// <summary>
        /// 函數功能：加載
        /// 開發者： 劉鋒
        /// 開發日期：2011-04-06        
        /// </summary>
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
                   
                    //記錄父頁面的頁碼索引值以備返回時使用
                    if (Request["pageIndex"] != null)
                    {
                        txtParentIndex.Text = Request["pageIndex"].ToString();
                        Session["ParentIndex"] = txtParentIndex.Text;
                    }

                    if (Request["SearchKey"] != null)
                    {
                        string strSearchValue = Request["SearchKey"].ToString().Trim();
                        string[] ArrKeyValue = strSearchValue.Split('=');
                        SelectMore(ArrKeyValue[0], ArrKeyValue[1],ArrKeyValue[2]);
                        
                        txtID.Text = ArrKeyValue[0].Trim().ToString();

                        txtParentIndex.Text = Session["ParentIndex"].ToString();
                    }
                    else if (Request["KeyValue"] != null)
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        lblFlag.Text = strKeyValue;
                        
                        string channelid=Request["ChannelID"].ToString().Trim();

                        if (Request["PlayingDate"] != null)
                        {
                            string playingDate = Request["PlayingDate"].ToString();
                            SelectMore(channelid, "", playingDate);                            
                        }
                        else
                        {
                            Select(channelid);
                        }

                        txtID.Text = channelid;

                        txtParentIndex.Text = Session["ParentIndex"].ToString();

                        //txtPageIndex.Text = gdvCurrent.PageIndex.ToString();                       
                    }
                    else if (Request["strID"].ToString() != null)
                    {
                        string strID = Request["strID"].ToString();                        
                        Select(strID);

                        txtID.Text = strID;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 函數功能：查詢頻道中節目詳細信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-04-06        
        /// </summary>
        private void Select(string id)
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 34),
                                        new SqlParameter("@ChannelID",id)
                                       
                                    };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);
            if (dt.Rows.Count > 0)
            {
                gdvCurrent.DataSource = dt;
                gdvCurrent.DataBind();
                ViewState["dt"] = dt;

                for (int i = 0, intRowCount = gdvCurrent.Rows.Count; i < intRowCount; i++)
                {
                    gdvCurrent.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    gdvCurrent.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                gdvCurrent.DataSource = dt;
                gdvCurrent.DataBind();
                gdvCurrent.Rows[0].Cells.Clear();
                gdvCurrent.Rows[0].Cells.Add(new TableCell());
                gdvCurrent.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gdvCurrent.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                gdvCurrent.Rows[0].Cells[0].Style.Add("text-align", "center");
                gdvCurrent.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
        }

        /// <summary>
        /// 函數功能：分頁
        /// 開發者： 劉鋒
        /// 開發日期：2011-04-06        
        /// </summary>
        protected void gdvCurrent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";

            gdvCurrent.PageIndex = e.NewPageIndex;
            gdvCurrent.DataSource = (DataTable)ViewState["dt"];
            gdvCurrent.DataBind();

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

        protected void gdvCurrent_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        /// <summary>
        /// 函數功能：查詢
        /// 開發者： 劉鋒
        /// 開發日期：2011-04-07        
        /// </summary>
        private void SelectMore(string channelid,string programname, string playingdate)
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 35),
                                        new SqlParameter("@ChannelID",channelid),
                                        new SqlParameter("@PlayingDate",playingdate),
                                        new SqlParameter("@ProgramName",programname)
                                    };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);
            if (dt.Rows.Count > 0)
            {
                gdvCurrent.DataSource = dt;
                gdvCurrent.DataBind();
                ViewState["dt"] = dt;

                for (int i = 0, intRowCount = gdvCurrent.Rows.Count; i < intRowCount; i++)
                {
                    gdvCurrent.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    gdvCurrent.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                gdvCurrent.DataSource = dt;
                gdvCurrent.DataBind();
                gdvCurrent.Rows[0].Cells.Clear();
                gdvCurrent.Rows[0].Cells.Add(new TableCell());
                gdvCurrent.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gdvCurrent.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                gdvCurrent.Rows[0].Cells[0].Style.Add("text-align", "center");
                gdvCurrent.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
        }
    }
}
