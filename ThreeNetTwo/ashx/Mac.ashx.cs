using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Mac : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strData = "";

            SqlParameter[] param ={

                                      new SqlParameter("@Flag",13)
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_LoadDataLog_sp", param);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strData = strData + "|" + dt.Rows[i]["MAC"].ToString();//將所有的Mac地址組成字符串

            }
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
