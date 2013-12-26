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
using System.IO;

namespace ThreeNetTwo.js
{
    public partial class MD_Channel_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindArea();
                    BindChannelName();
                    BindType();
                    string strFlag = Request["flag"];
                    if (strFlag.Equals("upd"))
                    {
                        ddlChannelName.Enabled = false;
                        if (Request["key"] != null)
                        {
                            InitialSettings(Request["key"].ToString());
                            txtID.Text = Request["key"].ToString();
                        }
                    }
                    else if (strFlag.Equals("sel"))
                    {
                        FileUploadLogo.Enabled = false;
                        Label1.Visible = false;
                        Label2.Visible = false;
                        Label3.Visible = false;
                        Label4.Visible = false;
                        Label5.Visible = false;
                        Label6.Visible = false;
                    }
                }
            }
            catch
            { }
        }

        /// <summary> 
        /// 函數名：BindArea
        /// 函數功能：綁定地區類型
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-11
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void BindArea()
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 20) 
                                    };
            ddlArea.DataValueField = "ID";
            ddlArea.DataTextField = "AreaDesc";
            ddlArea.DataSource = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, "");
        }

        /// <summary> 
        /// 函數名：BindType
        /// 函數功能：綁定頻道類型
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-11
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void BindType()
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 21) 
                                    };
            ddlChannelType.DataValueField = "ID";
            ddlChannelType.DataTextField = "ChannelTypeDesc";
            ddlChannelType.DataSource = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);
            ddlChannelType.DataBind();
            ddlChannelType.Items.Insert(0, "");
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

        /// <summary> 
        /// 函數名：btnOK_Click
        /// 函數功能：button事件
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-17
        /// 修改者：
        /// 修改日期：
        /// </summary>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string strBasePath = HttpContext.Current.Request.PhysicalApplicationPath;
                string strfileName = "";
                string strImagePath = "";
                string strFileExtension = "";

                SqlParameter[] param ={
                                     new SqlParameter("@flag",1),
                                     new SqlParameter("@type","Channel")
                                 };
                DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_SourcePath_sp", param);

                if (FileUploadLogo.FileName != "")
                {
                    strFileExtension = System.IO.Path.GetExtension(FileUploadLogo.FileName);
                    strfileName = "Images/TvSign/" + ddlChannelName.SelectedValue + strFileExtension;                  
                }
                else
                {
                    strfileName = txtImgPath.Text;                    
                }
                //目標圖片文件指定存放路徑
                strImagePath = strBasePath.Substring(0, strBasePath.LastIndexOf("\\", 3)) + dt.Rows[0]["ImageURL"].ToString()
                        + strfileName;

                User objUser = new User();
                objUser = Session["User"] as User;
                string strUserName = objUser.UserName;

                string strPostUrl = "";
                //新增
                if (txtID.Text == "")
                {
                    Insert(strImagePath, strfileName, strPostUrl, strUserName);
                }
                //修改
                else
                {
                    Update(strImagePath, strfileName, strPostUrl, strUserName);
                }
            }
            catch
            { }
        }

        /// <summary> 
        /// 函數名：InitialSettings
        /// 函數功能：修改時數據自動填寫
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-17
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void InitialSettings(string id)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",29),
                                 new SqlParameter("@ID",id)
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param);

            ddlChannelName.SelectedValue = dt.Rows[0]["ChannelCode"].ToString();
            txtChannelUrl.Text = dt.Rows[0]["ChannelURL"].ToString();
            txtUrlIPad.Text = dt.Rows[0]["ChannelURLiPad"].ToString();
            ddlArea.Text = dt.Rows[0]["AreaID"].ToString();
            ddlChannelType.Text = dt.Rows[0]["ChannelTypeID"].ToString();

            txtID.Text = id;//獲取修改數據的ID
            txtImgPath.Text = dt.Rows[0]["ImgPath"].ToString().Trim();//獲取原先圖片路徑
        }

        /// <summary> 
        /// 函數名：Insert
        /// 函數功能：新增頻道信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-17
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void Insert(string strImagePath, string strfileName, string strPostUrl, string strUserName)
        {
            SqlParameter[] param1 = {                                   
                                               new SqlParameter("@flag",23),
                                               new SqlParameter("@ChannelDesc",ddlChannelName.SelectedItem.ToString()),
                                               new SqlParameter("@ChannelCode",ddlChannelName.SelectedValue),
                                               new SqlParameter("@ChannelURL",txtChannelUrl.Text.Trim()),
                                               new SqlParameter("@ChannelURLiPad",txtUrlIPad.Text.Trim()),
                                               new SqlParameter("@ImgPath",strfileName),
                                               new SqlParameter("@AreaIDstr",ddlArea.SelectedValue),
                                               new SqlParameter("@ChannelTypeIDstr",ddlChannelType.SelectedValue),
                                               new SqlParameter("@Creator",strUserName)                                               
                                            };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param1);
            FileUploadLogo.PostedFile.SaveAs(strImagePath);           
            strPostUrl = "../Channel/MD_Channel.aspx?KeyValue=Add&t=" + DateTime.Now.ToFileTime();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");
        }

        /// <summary> 
        /// 函數名：Update
        /// 函數功能：修改頻道信息
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-17
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void Update(string strImagePath, string strfileName, string strPostUrl, string strUserName)
        {
            SqlParameter[] param1 = {                                   
                                               new SqlParameter("@flag",24),
                                               new SqlParameter("ID",Convert.ToInt32(Request["key"])),
                                               new SqlParameter("@ChannelDesc",ddlChannelName.SelectedItem.ToString()),
                                               new SqlParameter("@ChannelCode",ddlChannelName.SelectedValue),
                                               new SqlParameter("@ChannelURL",txtChannelUrl.Text.Trim()),
                                               new SqlParameter("@ChannelURLiPad",txtUrlIPad.Text.Trim()),
                                               new SqlParameter("@ImgPath",strfileName),
                                               new SqlParameter("@AreaID",ddlArea.SelectedValue),
                                               new SqlParameter("@ChannelTypeID",ddlChannelType.SelectedValue),
                                               new SqlParameter("@Editor",strUserName)                                               
                                            };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param1);
            FileUploadLogo.PostedFile.SaveAs(strImagePath);
            string strindex = txtPageRecord.Text.Trim();
            strPostUrl = "../Channel/MD_Channel.aspx?KeyValue=Update&strIndex=" + strindex + "&t=" + DateTime.Now.ToFileTime();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");
        }

        /// <summary> 
        /// 函數名：btnStopKeyEnter_Click
        /// 函數功能：(不可刪除)防止在非IE瀏覽器下按下回車觸發默認按鈕事件
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-23
        /// 修改者：
        /// 修改日期：
        /// </summary>
        protected void btnStopKeyEnter_Click(object sender, EventArgs e)
        {
            try
            {}
            catch 
            {}
        }
    }
}
