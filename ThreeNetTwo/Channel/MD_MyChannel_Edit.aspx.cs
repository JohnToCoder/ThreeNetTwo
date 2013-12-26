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
    public partial class MD_MyChannel_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindChannelName();
                    //string strFlag = Request["flag"];
                    //if (strFlag.Equals("sel"))
                    //{
                       
                    //}
                }
            }
            catch
            { }
        }

        /// <summary> 
        /// 函數名：BindChannelName
        /// 函數功能：綁定頻道名稱
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-16
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void BindChannelName()
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 27) 
                                    };
            ddlChannelName.DataValueField = "ChannelCode";
            ddlChannelName.DataTextField = "ChannelName";
            ddlChannelName.DataSource = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);
            ddlChannelName.DataBind();
            ddlChannelName.Items.Insert(0, "");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
