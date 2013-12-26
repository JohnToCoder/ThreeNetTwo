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
    public partial class Sys_Roles_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
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

        /// <summary>
        /// 函數名：setValue
        /// 函數功能:修改頁面賦值
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="strID"></param>
        private void setValue(string strID)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@Flag",5),
                                     new SqlParameter("@ID",strID)
                                 };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Roles_sp", param);

            txtRoleCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtRoleName.Text = dt.Rows[0].ItemArray[1].ToString();
            
        }
    }
}
