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
    public partial class Sys_Area : System.Web.UI.Page
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
                        objUser.GetRight(objUser.RoleCode, "74", this.Page);//頁面按鈕權限管控
                    }

                    if (Request["KeyValue"] == null)
                    {
                        databind("", "", "", "");
                    }
                    else
                    {
                        string strKeyValue = Request["KeyValue"].ToString().Trim();
                        string[] ArrKeyValue = strKeyValue.Split('=');

                        string strMac = "";
                        string strArea = "";
                        string strName = "";
                        string strMail = "";

                        if (ArrKeyValue.Length != 1)
                        {
                            strMac = ArrKeyValue[0];
                            strArea = ArrKeyValue[1];
                            strName = ArrKeyValue[2];
                            strMail = ArrKeyValue[3];
                        }

                        databind(strMac, strArea, strName, strMail);
                    }
                }
                catch
                {

                }
            }

        }

        private void databind(string strMac,string strArea,string strName,string strMail)
        {
            SqlParameter[] param ={

                                      new SqlParameter("@Flag",4),
                                      new SqlParameter("@Mac",strMac),
                                      new SqlParameter("@Area",strArea),
                                      new SqlParameter("@Name",strName),
                                      new SqlParameter("@Mail",strMail)

                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[User_Area_sp]", param);
            if (dt.Rows.Count > 0)
            {
                GvArea.DataSource = dt;
                GvArea.DataBind();
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
                GvArea.DataSource = dt;
                GvArea.DataBind();
                GvArea.Rows[0].Cells.Clear();
                GvArea.Rows[0].Cells.Add(new TableCell());
                GvArea.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GvArea.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                GvArea.Rows[0].Cells[0].Style.Add("text-align", "center");
                GvArea.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");

            }
        }

        protected void GvArea_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }
    }
}
