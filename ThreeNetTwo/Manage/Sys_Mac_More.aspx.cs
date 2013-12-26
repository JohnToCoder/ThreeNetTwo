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
    public partial class Sys_Mac_More : System.Web.UI.Page
    {
        /// <summary>
        /// 函數名：Page_Load
        /// 函數功能：更多信息賦值
        /// 開發者：楊久中
        /// 開發日期：2011-04-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strId = Request["strId"].ToString();
                SqlParameter[] param ={
                                          new SqlParameter("@flag",11),
                                          new SqlParameter("@MacId",strId)
                                     };

                DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);

                lblMeno.Text = dtb.Rows[0].ItemArray[0].ToString();
                lblUserId.Text = dtb.Rows[0].ItemArray[1].ToString();
                lblAddress.Text = dtb.Rows[0].ItemArray[2].ToString();
                lblEmail.Text = dtb.Rows[0].ItemArray[3].ToString();
                lblCreator.Text = dtb.Rows[0].ItemArray[4].ToString();
                lblCreatedate.Text = dtb.Rows[0].ItemArray[5].ToString();
                lblEditor.Text = dtb.Rows[0].ItemArray[6].ToString();
                lblEditDate.Text=dtb.Rows[0].ItemArray[7].ToString();
            }
        }
    }
}
