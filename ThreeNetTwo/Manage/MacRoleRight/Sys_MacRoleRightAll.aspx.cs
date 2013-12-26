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
    public partial class Sys_MacRoleRightAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strMenuTypeID = "";
                    string strMacRoleID = "";
                    string strRoleName = "";

                    if (Request["MenuId"] != null)//資料類型
                    {
                        strMenuTypeID = Request["MenuId"].ToString().Trim();
                    }
                    if (Request["RoleID"] != null)//角色ID
                    {
                        strMacRoleID = Request["RoleID"].ToString().Trim();
                    }
                    if (Request["RoleName"] != null)//角色名稱
                    {
                        strRoleName = Request["RoleName"].ToString().Trim();
                    }


                    //設置頁碼索引
                    if (Request["pageIndex"] != null && Request["pageIndex"].ToString() != "")
                    {
                        string strIndex = Request["pageIndex"].ToString();
                        GvName.PageIndex = Convert.ToInt32(strIndex);
                        //保存當前索引
                        txtPageIndex.Text = GvName.PageIndex.ToString();
                    }

                    lblRoleName.Text = strRoleName;
                    txtMenuTypeID.Text = strMenuTypeID;
                    txtRoleID.Text = strMacRoleID;

                    Bind(Request["KeyValue"], strMenuTypeID, strMacRoleID);

                }
                catch
                { }
            }
        }

        /// <summary>
        /// 根據條件綁定數據
        /// </summary>
        /// <param name="strKeyValue"></param>
        /// <param name="strMenuTypeID"></param>
        /// <param name="strMacRoleID"></param>
        private void Bind(string strKeyValue, string strMenuTypeID, string strMacRoleID)
        {
            if (strKeyValue == null || strKeyValue == "")
            {
                txtKeyValue.Text = "";//無查詢操作時設置值

                if (strMenuTypeID == "8")//頻道
                {
                    BindChannelData(strMenuTypeID, strMacRoleID);
                    //SearchBindData(strMenuTypeID, strMacRoleID);
                }
                else if (strMenuTypeID == "9")//電影
                {
                    BindMovieData(strMenuTypeID, strMacRoleID);
                }
                else if (strMenuTypeID == "10")//電視劇
                {
                    BindTVData(strMenuTypeID, strMacRoleID);
                }
                else if (strMenuTypeID == "11")//音樂
                {
                    BindMusicData(strMenuTypeID, strMacRoleID);
                }
                else if (strMenuTypeID == "12")//圖片
                {
                    BindPhotoData(strMenuTypeID, strMacRoleID);
                }
            }
            else
            {
                txtKeyValue.Text = Request["KeyValue"].ToString().Trim();//保存查詢操作的參數

                string[] ArrKeyValue = strKeyValue.Split('=');

                if (ArrKeyValue.Length != 1)
                {
                    SearchBindData(strMacRoleID, ArrKeyValue[0].Trim(), ArrKeyValue[1].Trim(), ArrKeyValue[2].Trim());
                }
            }
        }

        /// <summary>
        /// 開發功能：綁定數據到GvName(頻道)
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-02
        /// </summary>
        private void BindChannelData(string strMenuTypeID, string strMacRoleID)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",2),
                                     new SqlParameter("@MenuTypeID",strMenuTypeID),
                                     new SqlParameter("@MacRoleID",strMacRoleID)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);

            GvName.Columns[5].Visible = false;//隱藏明細列

            BindData(dt);

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：綁定數據到GvName（電影）
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-02
        /// </summary>
        private void BindMovieData(string strMenuTypeID, string strMacRoleID)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",3),
                                     new SqlParameter("@MenuTypeID",strMenuTypeID),
                                     new SqlParameter("@MacRoleID",strMacRoleID)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);

            GvName.Columns[5].Visible = false;//隱藏明細列

            BindData(dt);

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：綁定數據到GvName（電視劇）
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-02
        /// </summary>
        private void BindTVData(string strMenuTypeID, string strMacRoleID)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",4),
                                     new SqlParameter("@MenuTypeID",strMenuTypeID),
                                     new SqlParameter("@MacRoleID",strMacRoleID)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);

            BindData(dt);

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：綁定數據到GvName（音樂）
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-02
        /// </summary>
        private void BindMusicData(string strMenuTypeID, string strMacRoleID)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",5),
                                     new SqlParameter("@MenuTypeID",strMenuTypeID),
                                     new SqlParameter("@MacRoleID",strMacRoleID)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);

            BindData(dt);

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：綁定數據到GvName（圖片）
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-02
        /// </summary>
        private void BindPhotoData(string strMenuTypeID, string strMacRoleID)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",6),
                                     new SqlParameter("@MenuTypeID",strMenuTypeID),
                                     new SqlParameter("@MacRoleID",strMacRoleID)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);

            BindData(dt);

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 開發功能：綁定數據到GvName（查詢綁定）
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-05
        /// </summary>
        private void SearchBindData(string strMacRoleID, string strMenuTypeID, string strName, string strddlFlag)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",7),
                                     new SqlParameter("@MenuTypeID",strMenuTypeID),
                                     new SqlParameter("@MacRoleID",strMacRoleID),
                                     new SqlParameter("@Name",strName),
                                     new SqlParameter("@TypeCode",strddlFlag)
                                };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);

            if (dt.Rows.Count > 0)
            {
                GvName.DataSource = dt;
                GvName.DataBind();

                for (int i = 0, rowCount = GvName.Rows.Count; i < rowCount; i++)
                {
                    if (strMenuTypeID == "8" || strMenuTypeID == "9")
                    {
                        GvName.Columns[5].Visible = false;//當搜索類型為頻道和電影時隱藏明細列
                    }
                    else if (strMenuTypeID == "")//搜索全部
                    {
                        string strTypeId = GvName.Rows[i].Cells[2].Text;//資料類型
                        if (strTypeId == "8" || strTypeId == "9")
                        {
                            GvName.Rows[i].Cells[5].Text = "";
                        }
                    }

                    GvName.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvName.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }

            ViewState["dt"] = dt;
        }


        /// <summary>
        /// 綁定數據到GridView
        /// </summary>
        /// <param name="dt"></param>
        private void BindData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                GvName.DataSource = dt;
                GvName.DataBind();

                for (int i = 0, rowCount = GvName.Rows.Count; i < rowCount; i++)
                {
                    GvName.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    GvName.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            else
            {
                getNullValue(dt);
            }
        }

        /// <summary>
        /// 開發功能：GvDataLog無數據時，顯示表的框架
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
            GvName.DataSource = dt;
            GvName.DataBind();
            GvName.Rows[0].Cells.Clear();
            GvName.Rows[0].Cells.Add(new TableCell());
            GvName.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
            GvName.Rows[0].Cells[0].Text = "<font color='red'>None!</font>";
            GvName.Rows[0].Cells[0].Style.Add("text-align", "center");
            GvName.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
        }

        /// <summary>
        /// 開發功能：GvName翻頁功能
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-02
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            GvName.PageIndex = e.NewPageIndex;

            GvName.DataSource = dtbs;
            GvName.DataBind();

            string strMenuTypeID = Request["MenuId"].ToString().Trim();

            for (int i = 0, rowCount = GvName.Rows.Count; i < rowCount; i++)
            {

                //if (strMenuTypeID == "")//搜索全部
                //{
                    string strTypeId = GvName.Rows[i].Cells[2].Text;//資料類型
                    if (strTypeId == "8" || strTypeId == "9")
                    {
                        GvName.Rows[i].Cells[5].Text = "";
                    }
                //}

                GvName.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                GvName.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

        /// <summary>
        /// 開發功能：GvName行綁定事件
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-06
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvName_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text.ToString() != "-1")
                {
                    CheckBox cbox = (CheckBox)e.Row.Cells[6].FindControl("CheckBox1");
                    cbox.Checked = true;
                }
            }
        }

        /// <summary>
        /// 開發功能：CheckBox發生改變觸發的事件
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-06 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkbox.Parent.Parent;
            string strRightId = row.Cells[0].Text.ToString();//RightID(明細資料ID)
            string strMenuTypeID = row.Cells[2].Text.ToString();//MenuTypeID
            DataTable dt = new DataTable();

            if (checkbox.Checked)
            {
                //授權
                if (strMenuTypeID == "8" || strMenuTypeID == "9")//頻道和電影
                {
                    ChangeRight(strMenuTypeID, strRightId, 1, 1);
                }
                else
                {
                    if (strMenuTypeID == "10")//電視劇
                    {
                        dt = TVDetailBind(strRightId);
                    }
                    else if (strMenuTypeID == "11")//音樂
                    {
                        dt = MusicDetailBind(strRightId);
                    }
                    else if (strMenuTypeID == "12")//相冊
                    {
                        dt = PhotoDetailBind(strRightId);
                    }

                    //將某個資料的所有明細都授權（如給一部電視劇全部授權給一個角色）
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ChangeSubRight(strMenuTypeID, strRightId, dt.Rows[i][0].ToString(), 1, 2);
                        }
                    }
                }
            }
            else
            {
                //收回權限
                ChangeRight(strMenuTypeID, strRightId, 2, 1);
            }


            Bind(Request["KeyValue"], strMenuTypeID, txtRoleID.Text.Trim());
        }

        /// <summary>
        /// 開發功能：權限的改變（沒有子項的）
        /// 開發人員：楊碧清
        /// 開發時間：2011-04-02
        /// </summary>
        /// <param name="strRightId"></param>
        /// <param name="strType"></param>
        private void ChangeRight(string strMenuTypeID, string strRightId, int strType, int strSubFlag)
        {
            if (Session["User"] != null)
            {
                User objUser = new User();
                objUser = Session["User"] as User;

                SqlParameter[] param ={
                                      new SqlParameter("@flag",8),
                                      new SqlParameter("@MenuTypeID",strMenuTypeID),
                                      new SqlParameter("@MacRoleID",txtRoleID.Text.ToString()),
                                      new SqlParameter("@RightID",strRightId),
                                      new SqlParameter("@Creator",objUser.UserCode),
                                      new SqlParameter("@T",strType),
                                      new SqlParameter("@SubFlag",strSubFlag)
                                 };
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);
            }
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
                                      new SqlParameter("@MacRoleID",txtRoleID.Text.ToString()),
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
        /// 電視劇明細
        /// </summary>
        /// <param name="strRightId"></param>
        /// <returns></returns>
        private DataTable TVDetailBind(string strRightId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",10),
                                     new SqlParameter("@RightID",strRightId),
                                };
            return ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);
        }


        /// <summary>
        /// 音樂明細
        /// </summary>
        /// <param name="strRightId"></param>
        /// <returns></returns>
        private DataTable MusicDetailBind(string strRightId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",12),
                                     new SqlParameter("@RightID",strRightId),
                                };
            return ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);
        }

        /// <summary>
        /// 相冊明細
        /// </summary>
        /// <param name="strRightId"></param>
        /// <returns></returns>
        private DataTable PhotoDetailBind(string strRightId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",14),
                                     new SqlParameter("@RightID",strRightId),
                                };
            return ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_MacRoleRight_sp", param);
        }
    }
}
