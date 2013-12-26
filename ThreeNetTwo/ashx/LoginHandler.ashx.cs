using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Drawing;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using ThreeNetTwo;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class LoginHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            if (!string.IsNullOrEmpty(context.Request.QueryString["rdItem"]))
            {
                GenerateCheckCode(context);
            }
            else
            {
                string strUseID = context.Request["username"].ToString();
                string strPwd = context.Request["pwd"].ToString();
                string strCode = context.Request["Code"].ToString();

                if (context.Session["Code"] == null)
                {
                    context.Response.Write("overtime");
                }

                else if (strCode != context.Session["Code"].ToString())
                {
                    context.Response.Write("CodeError");
                }

                else
                {
                    DataTable dtb = CheckUser(strUseID, strPwd);
                    if (dtb.Rows.Count < 1)
                    {
                        context.Response.Write("ErrUser");
                    }
                    else
                    {
                        User user = new User();
                        user.Id = dtb.Rows[0].ItemArray[0].ToString().Trim();
                        user.UserCode = dtb.Rows[0].ItemArray[1].ToString().Trim();
                        user.UserName = dtb.Rows[0].ItemArray[2].ToString().Trim();
                        user.Password = dtb.Rows[0].ItemArray[3].ToString().Trim();
                        user.ImgPath = dtb.Rows[0].ItemArray[4].ToString().Trim();
                        user.UserTEL = dtb.Rows[0].ItemArray[5].ToString().Trim();
                        user.UserEmail = dtb.Rows[0].ItemArray[6].ToString().Trim();
                        user.UserMobile = dtb.Rows[0].ItemArray[7].ToString().Trim();
                        user.RoleCode = dtb.Rows[0].ItemArray[8].ToString().Trim();
                        user.UserIP = dtb.Rows[0].ItemArray[9].ToString().Trim();

                        context.Session["User"] = user;
                        context.Response.Write("success");
                    }
                }
            }
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void GenerateCheckCode(HttpContext context)
        {
            int intNumber;
            char code;
            string strCheckCode = String.Empty;

            System.Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                intNumber = random.Next();

                if (intNumber % 2 == 0)
                {
                    code = (char)('0' + (char)(intNumber % 10));
                }
                else
                {
                    code = (char)('A' + (char)(intNumber % 26));
                }

                strCheckCode += code.ToString();
            }

            context.Session["Code"] = strCheckCode.ToLower();

            drawImage(strCheckCode, context);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCheckCode"></param>
        /// <param name="context"></param>
        private void drawImage(string strCheckCode, HttpContext context)
        {
            if (strCheckCode != null || strCheckCode.Trim() != String.Empty)
            {
                System.Random random = new Random();
                System.Drawing.Bitmap image = new System.Drawing.Bitmap(63, 20);
                Graphics g = Graphics.FromImage(image);

                try
                {
                    //清空圖片背景色 
                    g.Clear(Color.Honeydew);

                    //畫圖片的背景噪音線 
                    for (int i = 0; i < 25; i++)
                    {
                        int x1 = random.Next(image.Width);
                        int x2 = random.Next(image.Width);
                        int y1 = random.Next(image.Height);
                        int y2 = random.Next(image.Height);

                        g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                    }

                    Font font = new System.Drawing.Font("Arial", 13, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                    System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                    g.DrawString(strCheckCode, font, brush, 2, 2);

                    //畫圖片的前景噪音點 
                    for (int i = 0; i < 100; i++)
                    {
                        int x = random.Next(image.Width);
                        int y = random.Next(image.Height);

                        image.SetPixel(x, y, Color.FromArgb(random.Next()));
                    }

                    //畫圖片的邊框線 
                    g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                    //混淆背景
                    Pen linePen = new Pen(new SolidBrush(Color.Chocolate), 1);
                    for (int x = 0; x < 4; x++)
                    {
                        g.DrawLine(linePen, new Point(random.Next(0, 99), random.Next(0, 19)), new Point(random.Next(0, 99), random.Next(0, 19)));
                    }

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    context.Response.ClearContent();
                    context.Response.ContentType = "image/gif";
                    context.Response.BinaryWrite(ms.ToArray());
                }
                finally
                {
                    g.Dispose();
                    image.Dispose();
                }
            }
        }


        private DataTable CheckUser(string strUserId,string strPwd)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",1),
                                     new SqlParameter("@UserCode",strUserId),
                                     new SqlParameter("@Password",strPwd)
                                 };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);
            return dtb;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
