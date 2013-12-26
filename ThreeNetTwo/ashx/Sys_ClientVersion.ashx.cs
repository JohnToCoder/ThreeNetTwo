using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Collections;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Sys_ClientVersion : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string strData = "";

            SqlParameter[] param ={

                                      new SqlParameter("@Flag",2)
                                      //new SqlParameter("@Mac",strMac),
                                      //new SqlParameter("@Meno",strMeno)
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_ClientVersion_sp", param);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strData = strData + "|" + dt.Rows[i].ItemArray[0].ToString(); 
    
            }

       
            //var availableTags = ["c++", "java", "php", "coldfusion", "javascript", "asp", "ruby", "python", "c", "scala", "groovy", "haskell", "perl"];
            context.Response.Write(strData);
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
