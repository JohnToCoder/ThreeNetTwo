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
    public partial class Sys_MacRight_Channel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    string strID = Request["Mid"].ToString();//mac地址ID
                    txtMid.Text = strID;

                    setValue(strID);


                    string strKeyValue = Request["KeyValue"].ToString().Trim();
                    string[] ArrKeyValue = strKeyValue.Split('=');


                    string strChannelName = "";
                    string strStartDate = "";
                    string strEndDate = "";

                    if (ArrKeyValue.Length != 1)
                    {
                        strChannelName = ArrKeyValue[0];
                        strStartDate = ArrKeyValue[1];
                        strEndDate = ArrKeyValue[2];
                    }

                    dataBind(strChannelName, strStartDate, strEndDate);





                    string strMacId = Request["MacId"].ToString();//roleId
                    string strMac = Request["mac"].ToString();
                    //txtMac.Text = strMac + "的資料權限";

                    txtMacValue.Text = strMac;
                    txtMacId.Text = strMacId;


                    string strType = Request["MenuId"].ToString();
                    txtType.Text = strType;
                }
            }

            catch
            {
            }

        }


        private void setValue(string strMacId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",12),
                                     new SqlParameter("@MacId",strMacId)
                                 };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);

            txtMac.Text = dtb.Rows[0].ItemArray[0].ToString();
            txtName.Text = dtb.Rows[0].ItemArray[1].ToString();
            txtUserId.Text = dtb.Rows[0].ItemArray[2].ToString();
            txtSex.Text = dtb.Rows[0].ItemArray[3].ToString();

        }

        protected void Sys_GvMac_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        private void dataBind(string Chnanel,string strSDate,string strEDate)
        {
            string strMacId = Request["MId"].ToString();

            SqlParameter[] param ={
                                     new SqlParameter("@flag",1),
                                     new SqlParameter("@UserId",strMacId),
                                     new SqlParameter("@Channel",Chnanel),
                                     new SqlParameter("@StartDate",strSDate),
                                     new SqlParameter("@EndDate",strEDate)
                                 };

            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_ChargeData_sp", param);

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
                Sys_GvMac.Rows[0].Cells[0].ColumnSpan = dtb.Columns.Count-2;
                Sys_GvMac.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Sys_GvMac.Rows[0].Cells[0].Style.Add("text-align", "center");
                Sys_GvMac.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");

            }
            ViewState["dt"] = dtb;
        }

        protected void Sys_GvMac_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtbs = ViewState["dt"] as DataTable;

            Sys_GvMac.PageIndex = e.NewPageIndex;

            Sys_GvMac.DataSource = dtbs;
            Sys_GvMac.DataBind();

        }
    }
}
