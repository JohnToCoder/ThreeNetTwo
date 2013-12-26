using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ThreeNetTwo.Manage.UpdateTable
{
    public partial class MD_UpdateTable_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["Id"] != null)
                    {
                        string Id = Request["Id"].ToString();
                        SetValue(Id);
                    }
                }
                catch
                { }
            }
        }

        private void SetValue(string strId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",7),
                                     new SqlParameter("@ID",strId)
                                  };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_UpdateTable_sp", param);

            txtCodeDesc.Text = dt.Rows[0]["CodeDesc"].ToString().Trim();

        }
    }
}
