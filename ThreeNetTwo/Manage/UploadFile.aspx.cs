using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ThreeNetTwo.Manage
{
    public partial class UploadFile : System.Web.UI.Page
    {

        //服务器默认保存路径
        private readonly string serverPath = @"D:\upload\";

        /// <summary>
        /// 開發功能：獲取客服端傳過來的文件，并保存
        /// 開發人員：楊碧清
        /// 開發時間：2011-03-29
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            // 获取 http提交上传的文件, 并保存
            foreach (string key in Request.Files.AllKeys)
            {
                HttpPostedFile file = Request.Files[key];
                //string newFilename = DateTime.Now.ToString("yyMMddhhmmssffff") + file.FileName.Substring(file.FileName.LastIndexOf('.'));
                string newFilename = file.FileName;

                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }

                try
                {   //文件保存并返回相对路径地址
                    file.SaveAs(this.serverPath + newFilename);
                    Response.Write("upload/" + newFilename);
                }
                catch
                {
                }
            }
        }
    }
}
