using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.SessionState;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class MD_MyChannel_Edit : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["term"] != null && context.Request.QueryString["term"].ToString() != "")
            {
                string key = context.Request.QueryString["term"].ToString();
                context.Response.Write(GetCorporationList(key));
            }
        }

        public string GetCorporationList(string key)
        {
            SqlParameter[] param = { 
                                        new SqlParameter("@flag", 31),
                                        new SqlParameter("@UserCode",key)
                                    };            
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "dbo.MD_Channels_sp", param); 
            string result = "[";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result += "\"" + dt.Rows[i][0].ToString() + "\",";
                }
                result = result.Remove(result.Length - 1, 1);
                result += "]";
            }
            return result;
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
