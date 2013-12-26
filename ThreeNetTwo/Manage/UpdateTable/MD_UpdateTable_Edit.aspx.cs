using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Manage.UpdateTable
{
    public partial class MD_UpdateTable_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strFlag = Request["Flag"].ToString();
                    string Id = Request["ID"].ToString();

                    if (strFlag == "2")//新增
                    {
                    }

                    if (strFlag == "3")//修改
                    {
                        SetValue(Id);
                    }

                    txtId.Text = Id;

                }
                catch
                { }
            }
        }


        private void SetValue(string strId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",6),
                                     new SqlParameter("@ID",strId)
                                  };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_UpdateTable_sp", param);

            txtTableName.Text = dt.Rows[0]["TableName"].ToString().Trim();
            txtOrderID.Text = dt.Rows[0]["OrderID"].ToString().Trim();
            txtCodeDesc.Text = dt.Rows[0]["CodeDesc"].ToString().Trim();
        }

    }
}
