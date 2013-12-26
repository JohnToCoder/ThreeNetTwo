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

namespace ThreeNetTwo.Manage
{
    public partial class Sys_VersionInfo_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string strFlag = Request["flag"];
                    if (!strFlag.Equals("ins"))
                    {
                        trFileUp.Visible = false;
                        trCreateDate.Visible = true;
                    }
                    else
                    {
                        trFileUp.Visible = true;
                        trCreateDate.Visible = false;
                    }

                    if (strFlag.Equals("upd"))
                    {
                        txtVersionNum.Enabled = false;
                        if (Request["key"] != null)
                        {
                            trFileUp.Visible = true;
                            trCreateDate.Visible = false;
                            InitialSettings(Request["key"].ToString());
                            txtID.Text = Request["key"].ToString();
                        }
                    }

                    if (strFlag.Equals("sel"))
                    {
                        Label1.Visible = false;
                        Label2.Visible = false;
                        Label3.Visible = false;
                        Label4.Visible = false;
                        Label5.Visible = false;
                    }
                }
            }
            catch
            { }
        }

        /// <summary> 
        /// 函數名：btnOK_Click
        /// 函數功能：button事件
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //新增
                if (txtID.Text == "")
                {
                    string strFilePath = getFilePath();
                    Insert(strFilePath);
                    //Edit By Tanyi 2011/4/8 保存文件於文件夾中
                    //string strNewFilePath = HttpContext.Current.Request.PhysicalApplicationPath;


                    //strNewFilePath = strNewFilePath.Substring(0, strNewFilePath.LastIndexOf("\\", 3))
                           //  + "/ThreeNetTwo/ThreeNetTwo/ThreeNetTwo";
                    //Edit By Tanyi 2011/4/12 路徑改成相對路徑
                    string s = Server.MapPath(strFilePath);
                    AddFile(Server.MapPath(strFilePath));

                }
                //修改
                else
                {
                    string strPath = "";
                    if (FilePath.FileName != "")
                    {
                        //string strNewFilePath = HttpContext.Current.Request.PhysicalApplicationPath;

                        //strNewFilePath = strNewFilePath.Substring(0, strNewFilePath.LastIndexOf("\\", 3))
                        //+ "/ThreeNetTwo/ThreeNetTwo/ThreeNetTwo";
                        //Edit By Tanyi 2011/4/12 改成相對路徑
                        if (strPath != "")
                        {
                            strPath = GetEditPathName(txtID.Text.ToString());
                        }
                        else
                        {
                            strPath = getFilePath();
                        }
                        string MapPath = Server.MapPath(strPath);
                        Update(strPath);
                        FilePath.SaveAs(MapPath);
                    }
                    else
                    {
                        Update(strPath);
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 函數名：GetEditPathName
        /// 函數功能：獲取編辑文件的路徑
        /// 開發者： 沈譚義
        /// 開發日期：2011-04-08
        /// 修改者：
        /// 修改日期：        /// </summary>
        /// <returns></returns>
        private string GetEditPathName(string strID)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",5),
                                 new SqlParameter("@ID",strID)
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_ServerVersion_sp]", param);
            return dt.Rows[0]["SavePath"].ToString();
        }

        /// <summary>
        /// 函數名：getFilePath
        /// 函數功能：獲取文件保存的名稱
        /// 開發者： 沈譚義
        /// 開發日期：2011-04-08
        /// 修改者：
        /// 修改日期：        /// </summary>
        /// <returns></returns>
        private string getFilePath()
        {
            string fileTime = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
                + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString()
                + DateTime.Now.Millisecond.ToString();
            return "/SystemVersion/" + fileTime + GetRandomint() + ".zip";
        }
        /// <summary> 
        /// 函數名：AddFile
        /// 函數功能：保存文件
        /// 開發者： 沈譚義
        /// 開發日期：2011-04-08
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void AddFile(string strFilePath)
        {
            FilePath.PostedFile.SaveAs(strFilePath);
        }
        /// <summary> 
        /// 函數名：GetRandomint
        /// 函數功能：獲取隨機生成的數
        /// 開發者： 沈譚義
        /// 開發日期：2011-04-08
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private string GetRandomint()
        {
            Random random = new Random();
            return (random.Next(10000).ToString());
        }
        /// <summary> 
        /// 函數名：Insert
        /// 函數功能：新增
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void Insert(string strFilePath)
        {
            SqlParameter[] param1 = {                                   
                                               new SqlParameter("@flag",3),
                                               new SqlParameter("@Version",txtVersionNum.Text.Trim()),
                                               new SqlParameter("@VerDesc",txtVersionDesc.Text.Trim()),
                                               new SqlParameter("@VerDate",txtVersionDate.Text.Trim()),
                                               new SqlParameter("@PubDate",txtPubDate.Text.Trim()),
                                               new SqlParameter("@filepath",strFilePath)
                                            };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[MD_ServerVersion_sp]", param1);
            string strPostUrl = "../Manage/Sys_VersionInfo.aspx?KeyValue=Add&t=" + DateTime.Now.ToFileTime();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");
        }

        /// <summary> 
        /// 函數名：Update
        /// 函數功能：修改
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void Update(string strPath)
        {
            SqlParameter[] param1 = {                                   
                                               new SqlParameter("@flag",4),
                                               new SqlParameter("@ID",Convert.ToInt32(Request["key"])),
                                               new SqlParameter("@VerDesc",txtVersionDesc.Text.Trim()),
                                               new SqlParameter("@VerDate",txtVersionDate.Text.Trim()),
                                               new SqlParameter("@PubDate",txtPubDate.Text.Trim()),
                                               new SqlParameter("@filepath",strPath)
                                            };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[MD_ServerVersion_sp]", param1);
            string strPostUrl = "../Manage/Sys_VersionInfo.aspx?KeyValue=Update&t=" + DateTime.Now.ToFileTime();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");
        }

        /// <summary> 
        /// 函數名：InitialSettings
        /// 函數功能：修改時數據自動填寫
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        private void InitialSettings(string id)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",5),
                                 new SqlParameter("@ID",id)
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_ServerVersion_sp]", param);

            txtVersionNum.Text = dt.Rows[0]["Version"].ToString();
            txtVersionDesc.Text = dt.Rows[0]["VerDesc"].ToString();
            txtVersionDate.Text = dt.Rows[0]["VerDate"].ToString();
            txtPubDate.Text = dt.Rows[0]["PubDate"].ToString();
        }

        /// <summary> 
        /// 函數名：btnStopKeyEnter_Click
        /// 函數功能：(不可刪除)防止在非IE瀏覽器下按下回車觸發默認按鈕事件
        /// 開發者： 劉鋒
        /// 開發日期：2011-03-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        protected void btnStopKeyEnter_Click(object sender, EventArgs e)
        {

        }
    }
}
