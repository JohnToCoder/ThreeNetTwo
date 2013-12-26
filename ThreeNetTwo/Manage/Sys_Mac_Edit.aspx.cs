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
    public partial class Sys_Mac_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlListBind();
                    string strFlag = Request["Flag"].ToString();

                    string Id = Request["ID"].ToString();
                    if (strFlag == "3")
                    {
                        setValue(Id);
                    }

                    if (strFlag == "1")
                    {
                        txtFlag.Text = strFlag;
                    }
                    txtId.Text = Id; 
                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// 函數名：setValue
        /// 函數功能：修改時賦值
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="strId"></param>
        private void setValue(string strId)
        {

            SqlParameter[] param ={
                                     new SqlParameter("@Flag",5),
                                     new SqlParameter("@MacId",strId)
                                 };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_MAC_sp", param);


            txtMac.Text = dt.Rows[0].ItemArray[0].ToString().Trim();
            txtMeno.Text = dt.Rows[0].ItemArray[1].ToString().Trim();
            txtName.Text = dt.Rows[0].ItemArray[2].ToString().Trim();
            txtTel.Text = dt.Rows[0].ItemArray[3].ToString().Trim();
            txtMobile.Text = dt.Rows[0].ItemArray[4].ToString().Trim();
            ddlRole.SelectedValue = dt.Rows[0].ItemArray[5].ToString().Trim();

            txtUserId.Text = dt.Rows[0].ItemArray[6].ToString().Trim();
            ddlSex.SelectedValue = dt.Rows[0].ItemArray[7].ToString().Trim();
            txtBirthDay.Text = dt.Rows[0].ItemArray[8].ToString().Trim();
            txtAddress.Text = dt.Rows[0].ItemArray[9].ToString().Trim();
            txtEmail.Text = dt.Rows[0].ItemArray[10].ToString().Trim();


        }


        /// <summary>
        /// 函數名：ddlListBind
        /// 函數功能：綁定下拉框
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void ddlListBind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@Flag",9)
                                 };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_MAC_sp", param);
            ddlRole.DataValueField = "ID";
            ddlRole.DataTextField = "MacRoleDesc";

            ddlRole.DataSource = dt;
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, "");

            SqlParameter[] param1 ={
                                     new SqlParameter("@Flag",10)
                                 };

            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_MAC_sp", param1);
            ddlSex.DataValueField = "ID";
            ddlSex.DataTextField = "IDdesc";

            ddlSex.DataSource = dtb;
            ddlSex.DataBind();
            ddlSex.Items.Insert(0, "");
        }
    }

}