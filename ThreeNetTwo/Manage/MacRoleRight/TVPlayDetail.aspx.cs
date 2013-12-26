using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace ThreeNetTwo.Manage.MacRoleRight
{
    public partial class TVPlayDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strID = "";
                    string strMenuTypeID = "";
                    string strRoleID = "";
                    string pageIndex = "";
                    string strRoleName = "";
                    string strKeyValue = "";

                    if (Request["strID"] != null)
                    {
                        strID = Request["strID"].ToString();
                    }
                    if (Request["strMenuTypeID"] != null)
                    {
                        strMenuTypeID = Request["strMenuTypeID"].ToString();
                    }
                    if (Request["strRoleID"] != null)
                    {
                        strRoleID = Request["strRoleID"].ToString();
                    }
                    if (Request["pageIndex"] != null)
                    {
                        pageIndex = Request["pageIndex"].ToString();
                    }
                    if (Request["strRoleName"] != null)
                    {
                        strRoleName = Request["strRoleName"].ToString();
                    }
                    if (Request["KeyValue"] != null)
                    {
                        strKeyValue = Request["KeyValue"].ToString();
                    }
                   
                    txtRightId.Text = strID;
                    txtMenuTypeId.Text = strMenuTypeID;
                    txtRoleId.Text = strRoleID;
                    txtParentIndex.Text = pageIndex;
                    txtRoleName.Text = strRoleName;
                    txtKeyValue.Text = strKeyValue;

                    if (Request["DetailKeyValue"] == null)
                    {
                        Bind(strID, strMenuTypeID, strRoleID);
                    }
                    else
                    {
                        //string[] ArrKeyValue = strKeyValue.Split('=');

                        //if (ArrKeyValue.Length != 1)
                        //{
                        SearchBind(strID, strMenuTypeID, strRoleID, Request["DetailKeyValue"].ToString().Trim());
                        //}
                    }
                }
                catch
                { }
            }
        }

        private void Bind(string strID, string strMenuTypeID, string strRoleID)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",9),
                                     new SqlParameter("@MenuTypeID",strMenuTypeID),
                                     new SqlParameter("@MacRoleID",strRoleID),
                                     new SqlParameter("@RightID",strID),
                                     new SqlParameter("@SubName","")
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvTVDetail.DataSource = dt;
                GvTVDetail.DataBind();

                for (int i = 0, rowCount = GvTVDetail.Rows.Count; i < rowCount; i++)
                {
                    GvTVDetail.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvTVDetail.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        private void SearchBind(string strID, string strMenuTypeID, string strRoleID, string strSubName)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",9),
                                     new SqlParameter("@MenuTypeID",strMenuTypeID),
                                     new SqlParameter("@MacRoleID",strRoleID),
                                     new SqlParameter("@RightID",strID),
                                     new SqlParameter("@SubName",strSubName)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvTVDetail.DataSource = dt;
                GvTVDetail.DataBind();

                for (int i = 0, rowCount = GvTVDetail.Rows.Count; i < rowCount; i++)
                {
                    GvTVDetail.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvTVDetail.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：GvDataLog無數據時，顯示表的框架
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-12
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
            GvTVDetail.DataSource = dt;
            GvTVDetail.DataBind();
            GvTVDetail.Rows[0].Cells.Clear();
            GvTVDetail.Rows[0].Cells.Add(new TableCell());
            GvTVDetail.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
            GvTVDetail.Rows[0].Cells[0].Text = "<font color='red'>None!</font>";
            GvTVDetail.Rows[0].Cells[0].Style.Add("text-align", "center");
            GvTVDetail.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkbox.Parent.Parent;

            string strRightId = Request["strID"].ToString();
            string strRightSubId = row.Cells[0].Text.ToString();//
            string strMenuTypeID = Request["strMenuTypeID"].ToString();//MenuTypeID

            if (checkbox.Checked)
            {
                ChangeSubRight(strMenuTypeID, strRightId, strRightSubId, 1, 2);//授權
            }
            else
            {
                ChangeSubRight(strMenuTypeID, strRightId, strRightSubId, 2, 2);//收回權限
            }

            Bind(strRightId, strMenuTypeID, txtRoleId.Text.Trim());
        }

        /// <summary>
        /// 開發功能：權限的改變（有子項的）
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-12
        /// </summary>
        /// <param name="strRightId"></param>
        /// <param name="strType"></param>
        private void ChangeSubRight(string strMenuTypeID, string strRightId, string strRightSubId, int strType, int strSubFlag)
        {
            if (Session["User"] != null)
            {
                User objUser = new User();
                objUser = Session["User"] as User;

                SqlParameter[] param ={
                                      new SqlParameter("@flag",8),
                                      new SqlParameter("@MenuTypeID",strMenuTypeID),
                                      new SqlParameter("@MacRoleID",Request["strRoleID"].ToString()),
                                      new SqlParameter("@RightID",strRightId),
                                      new SqlParameter("@RightSubID",strRightSubId),
                                      new SqlParameter("@Creator",objUser.UserCode),
                                      new SqlParameter("@T",strType),
                                      new SqlParameter("@SubFlag",strSubFlag)
                                 };
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvTVDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text.ToString() != "-1")
                {
                    CheckBox cbox = (CheckBox)e.Row.Cells[3].FindControl("CheckBox1");
                    cbox.Checked = true;
                }
            }
        }

        /// <summary>
        /// 開發功能：GvTVDetail翻頁功能
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvTVDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            GvTVDetail.PageIndex = e.NewPageIndex;

            GvTVDetail.DataSource = dtbs;
            GvTVDetail.DataBind();

            for (int i = 0, rowCount = GvTVDetail.Rows.Count; i < rowCount; i++)
            {
                GvTVDetail.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvTVDetail.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

    }
}
