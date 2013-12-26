using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace ThreeNetTwo.Channel
{
    public partial class MD_ChannelMoreInfo_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strFlag = Request["flag"];
                if (strFlag == "sel")
                {
                    trPlayingTime.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                    Label3.Visible = false;
                }
                if (Request["key"] != null)
                {
                    txtFlagID.Text = Request["key"].ToString();
                    if (txtFlagID.Text.Trim() != "")
                    {
                        int programID = Convert.ToInt32(txtFlagID.Text);
                        Settings(programID);
                    }
                }
            }
        }

        /// <summary>
        /// 函數功能：修改節目信息時自動填充數據
        /// 開發者： 劉鋒
        /// 開發日期：2011-4-8       
        /// </summary>
        private void Settings(int id)
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 42),
                                        new SqlParameter("@ID",id)
                                       
                                    };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);
            txtProgramName.Text = dt.Rows[0]["ProgramName"].ToString();
            txtPlayingDate.Text = dt.Rows[0]["PlayingDate"].ToString();
            txtPlayingTime.Text = dt.Rows[0]["PlayingTime"].ToString();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {           

        }       

        protected void btnStopKeyEnter_Click(object sender, EventArgs e)
        {

        }
    }
}
