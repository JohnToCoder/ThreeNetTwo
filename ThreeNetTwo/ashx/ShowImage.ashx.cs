using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Web.SessionState;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ShowImage : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                HttpContext.Current.Response.ClearContent();
                context.Response.ContentType = "text/plain";

                string strSourcePath = context.Request["path"];
                string strImagePath = context.Request["strId"];

                strImagePath = Class.Common.GetImagePath(strSourcePath) + strImagePath;

                FileStream fs = File.Open(strImagePath, FileMode.OpenOrCreate,FileAccess.Read);

                int Filelen = (Int32)fs.Length;
                byte[] bytes = new byte[Filelen];

                fs.Read(bytes, 0, Filelen);

                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms, false);

                HttpContext.Current.Response.ContentType = "image/gif";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());

                fs.Close();
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
