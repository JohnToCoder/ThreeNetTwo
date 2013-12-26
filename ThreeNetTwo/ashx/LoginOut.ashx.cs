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
    /// 開發功能：清除用戶登錄的Session
    /// 開發人員：楊碧清
    /// 開發時間：2011-03-11
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class LoginOut : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                if (context.Session["User"] != null)
                {
                    context.Session.Clear();
                }
                context.Response.Write("success");
            }
            catch (Exception ex)
            {
                context.Response.Write("false");
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
