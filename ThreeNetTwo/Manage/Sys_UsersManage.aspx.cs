using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ThreeNetTwo.Class;

namespace ThreeNetTwo.Manage
{
    public partial class Sys_UsersManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["User"] != null)
                    {
                        User objUser = new User();
                        objUser = Session["User"] as User;
                        objUser.GetRight(objUser.RoleCode, "71", this.Page);//頁面按鈕權限管控
                    }

                    if (Request["KeyValue"] != null)
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        lblFlag.Text = strKeyValue;
                        GvUsersBind();
                    }
                    else if (Request["SearchKey"] != null)
                    {
                        string strSearchValue = Request["SearchKey"].ToString().Trim();
                        string[] ArrKeyValue = strSearchValue.Split('=');
                        DataSearchBind(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim().ToString(), ArrKeyValue[5].Trim(), ArrKeyValue[6].Trim().ToString());
                    }
                    else
                    {
                        GvUsersBind();
                    }
                }
                catch
                {


                }
            }
        }

        /// <summary>
        /// 函數名：GvUsersBind()
        /// 函數功能：初始綁定所有用戶數據
        /// 開發者： 劉洪彬
        /// 開發日期：2011-03-12
        /// 修改者：
        /// 修改日期：
        /// </summary>
        public void GvUsersBind()
        {
            DataTable dt = new DataTable();
            SqlParameter[] param={ 
                                   new SqlParameter("@flag",2)
                               };
            dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvUsers.DataSource = dt;
                GvUsers.DataBind();
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
                GvUsers.DataSource = dt;
                GvUsers.DataBind();
                GvUsers.Rows[0].Cells.Clear();
                GvUsers.Rows[0].Cells.Add(new TableCell());
                GvUsers.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GvUsers.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                GvUsers.Rows[0].Cells[0].Style.Add("text-align", "center");
                GvUsers.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;

        }


        /// <summary>
        /// 函數名：DataSearchBind()
        /// 函數功能：查詢特定用戶數據
        /// 開發者： 劉洪彬
        /// 開發日期：2011-03-12
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="strUserCode"></param>
        /// <param name="strUserName"></param>
        /// <param name="strTEL"></param>
        /// <param name="strEmail"></param>
        /// <param name="strMobile"></param>
        /// <param name="strID"></param>
        /// <param name="strIP"></param>

        protected void DataSearchBind(string strUserCode,string strUserName,string strTEL,string strEmail,string strMobile,string strID,string strIP)
        {

            DataTable dt = new DataTable();
            SqlParameter[] param ={ 
                                   new SqlParameter("@flag",3),
                                   new SqlParameter("@UserCode",strUserCode),
                                   new SqlParameter("@UserName",strUserName),
                                   new SqlParameter("@TEL",strTEL),
                                   new SqlParameter("@Email",strEmail),
                                   new SqlParameter("@Mobile",strMobile),
                                   new SqlParameter("@RoleID",strID),
                                   new SqlParameter("@IP", strIP)
                               };
            dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvUsers.DataSource = dt;
                GvUsers.DataBind();
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
                GvUsers.DataSource = dt;
                GvUsers.DataBind();
                GvUsers.Rows[0].Cells.Clear();
                GvUsers.Rows[0].Cells.Add(new TableCell());
                GvUsers.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GvUsers.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                GvUsers.Rows[0].Cells[0].Style.Add("text-align", "center");
                GvUsers.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;

        }
        
        /// <summary>
        /// 函數名：GvUsers_PageIndexChanging
        /// 函數功能：翻頁功能
        /// 開發者： 劉洪彬
        /// 開發日期：2011-03-12
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";
            DataTable dtbs = ViewState["dt"] as DataTable;
            GvUsers.PageIndex = e.NewPageIndex;
            GvUsers.DataSource = dtbs;
            GvUsers.DataBind();
            txtPageIndex.Text = e.NewPageIndex.ToString();

        }

        /// <summary>
        /// 函數名：GvUsers_RowDataBound
        /// 函數功能：鼠標事件
        /// 開發者： 劉洪彬
        /// 開發日期：2011-03-12
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void GvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[3].Text = "<span title=\'" + e.Row.Cells[3].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[3].Text, 10).Trim() + "</span>";
                //e.Row.Cells[4].Text = "<span title=\'" + e.Row.Cells[4].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[4].Text, 10).Trim() + "</span>";
                //e.Row.Cells[6].Text = "<span title=\'" + e.Row.Cells[6].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[6].Text, 10).Trim() + "</span>";
                //e.Row.Cells[7].Text = "<span title=\'" + e.Row.Cells[7].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[7].Text, 10) .Trim()+ "</span>";
                //e.Row.Cells[8].Text = "<span title=\'" + e.Row.Cells[8].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[8].Text, 10).Trim() + "</span>";
                //e.Row.Cells[9].Text = "<span title=\'" + e.Row.Cells[9].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[9].Text, 10).Trim() + "</span>";
                //e.Row.Cells[10].Text = "<span title=\'" + e.Row.Cells[10].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[10].Text, 8).Trim() + "</span>";
                //e.Row.Cells[11].Text = "<span title=\'" + e.Row.Cells[11].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[11].Text, 6).Trim() + "</span>";
                //e.Row.Cells[12].Text = "<span title=\'" + e.Row.Cells[12].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[12].Text, 6).Trim() + "</span>";
                //e.Row.Cells[13].Text = "<span title=\'" + e.Row.Cells[13].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[13].Text, 6).Trim() + "</span>";
                //e.Row.Cells[14].Text = "<span title=\'" + e.Row.Cells[14].Text.Trim() + "\'>" + Common.SubString(e.Row.Cells[14].Text, 6).Trim() + "</span>";
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }
    }
}
