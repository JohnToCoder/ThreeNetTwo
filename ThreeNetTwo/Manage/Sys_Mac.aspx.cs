using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Manage
{
    public partial class Sys_Mac : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        objUser.GetRight(objUser.RoleCode, "81", this.Page);//頁面按鈕權限管控
                    }

                    if (Request["KeyValue"] == null)
                    {
                        DataBind("", "","","","","","","","","","");
                    }

                    else
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        string[] ArrKeyValue = strKeyValue.Split('=');

                        string strMac = "";
                        string strMeno = "";
                        string strName = "";
                        string strTel = "";
                        string strMobile = "";
                        string strRole = "";
                        string strUserId = "";
                        string strSex = "";
                        string strBirthDay = "";
                        string strEmail = "";
                        string strAddress = "";



                        if (ArrKeyValue.Length != 1)
                        {
                            strMac = ArrKeyValue[0];
                            strMeno = ArrKeyValue[1];
                            strName = ArrKeyValue[2];
                            strTel = ArrKeyValue[3];
                            strMobile = ArrKeyValue[4];
                            strRole = ArrKeyValue[5];
                            strUserId = ArrKeyValue[6];
                            strSex = ArrKeyValue[7];
                            strBirthDay = ArrKeyValue[8];
                            strEmail = ArrKeyValue[9];
                            strAddress = ArrKeyValue[10];
                        }

                        DataBind(strMac, strMeno,strName,strTel,strMobile,strRole,strUserId,strSex,strBirthDay,strEmail,strAddress);
                        txtSuccess.Text = strKeyValue;
                    }
                    txtKeyValue.Text = "Mac";
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// 函數名：DataBind()
        /// 函數功能：初始綁定數據
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="strMac"></param>
        /// <param name="strMeno"></param>
        /// <param name="strName"></param>
        /// <param name="strTel"></param>
        /// <param name="strMobile"></param>
        /// <param name="strRole"></param>
        /// <param name="strUserId"></param>
        /// <param name="strSex"></param>
        /// <param name="strBirthDay"></param>
        /// <param name="strEmail"></param>
        /// <param name="strAddress"></param>
        private void DataBind(string strMac, string strMeno, string strName, string strTel, string strMobile, string strRole, string strUserId, string strSex, string strBirthDay, string strEmail, string strAddress)
        {

            SqlParameter[] param ={

                                      new SqlParameter("@Flag",1),
                                      new SqlParameter("@Mac",strMac),
                                      new SqlParameter("@Meno",strMeno),
                                      new SqlParameter("@UserName",strName),
                                      new SqlParameter("@Tel",strTel),
                                      new SqlParameter("@Mobile",strMobile),
                                      new SqlParameter("MacRoleDesc",strRole),
                                      new SqlParameter("@UserId",strUserId),
                                      new SqlParameter("@Sex",strSex),
                                      new SqlParameter("@BirthDay",strBirthDay),
                                      new SqlParameter("@Address",strAddress),
                                      new SqlParameter("@Email",strEmail)

                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_MAC_sp", param);
            if (dt.Rows.Count > 0)
            {
                GvMac.DataSource = dt;
                GvMac.DataBind();
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
                GvMac.DataSource = dt;
                GvMac.DataBind();
                GvMac.Rows[0].Cells.Clear();
                GvMac.Rows[0].Cells.Add(new TableCell());
                GvMac.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count+1;
                GvMac.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                GvMac.Rows[0].Cells[0].Style.Add("text-align", "center");
                GvMac.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");

            }

            ViewState["dt"] = dt;
        }

        /// <summary>
        /// 函數名：GvArea_RowDataBound()
        /// 函數功能：鼠標移至GridView變色
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvArea_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }


        /// <summary>
        /// 函數名：GvMac_PageIndexChanging()
        /// 函數功能：GridView分頁
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvMac_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            txtSuccess.Text = "";
            DataTable dtbs = ViewState["dt"] as DataTable;

            GvMac.PageIndex = e.NewPageIndex;

            GvMac.DataSource = dtbs;
            GvMac.DataBind();

            //txtPageIndex.Text = e.NewPageIndex.ToString();
        }
    }
}
