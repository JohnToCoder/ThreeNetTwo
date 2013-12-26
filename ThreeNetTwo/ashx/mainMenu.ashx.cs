using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using ThreeNetTwo;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// 開發功能：根據用戶登錄否，輸出不同的值
    /// 開發人員：楊碧清
    /// 開發時間：2011-03-11
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class mainMenu : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";

                if (context.Session["User"] != null)
                {
                    User objUser = new User();
                    objUser = context.Session["User"] as User;
                    string strUserName = objUser.UserName;
                    context.Response.Write("當前用戶：" + strUserName);
                }
                else
                {
                    //context.Response.Redirect("../login.html");
                    context.Response.Write("logout");
                }
            }
            catch (Exception e)
            {

                context.Response.Write("error");
            }
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
