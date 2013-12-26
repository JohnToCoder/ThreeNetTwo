using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class DeleteData : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string strKeyValue = context.Request["KeyValue"].ToString().Trim();
                string[] ArrKeyVal = strKeyValue.Split('-');

                string strReturn = "";
                switch (ArrKeyVal[0].Trim())
                {
                    case "Movie":
                        strReturn = Class.Movie.Delete_Movie(ArrKeyVal);
                        break;
                    case "Photo":
                        strReturn = Class.Photo.Delete_Photo(ArrKeyVal);
                        break;
                    case "Role":
                        strReturn = Class.Role.Delete_Role(ArrKeyVal);
                        break;
                    case "MacRole":
                        strReturn = Class.MacRole.Delete_MacRole(ArrKeyVal);
                        break;
                    case "Users":
                        strReturn = Class.Users.Delete_Users(ArrKeyVal);
                        break;
                    case "TVPlay":
                        strReturn = Class.TVPlay.Delete_TVPlay(ArrKeyVal);
                        break;
                    case "TVPlaySub":
                        strReturn = Class.TVPlay.Delete_TVSub(ArrKeyVal);
                        break;
                    case "Channel":
                        strReturn = Class.Channel.Delete_Channel(ArrKeyVal);
                        break;
                    case "Album":
                        strReturn = Class.Music.Delete_Album(ArrKeyVal);
                        break;
                    case "Music":
                        strReturn = Class.Music.Delete_Music(ArrKeyVal);
                        break;

                    case "Mac":

                        string[] strMac = {};
                        string[] strId = { };

                        if (context.Request["macAll"] != null)
                        {
                            strMac = context.Request["macAll"].ToString().Trim().Split('|');
                        }

                         bool BResult=checkMac(strMac);
                         if (BResult == false)
                         {
                             strReturn = "exist";
                         }
                         else
                         {
                             strReturn = Class.Mac.Delete_Mac(ArrKeyVal);
                         }
                        break;
                    case "Version":
                        strReturn = Class.Version.Delete_Version(ArrKeyVal);
                        break;
                    case "ChannelMore":
                        strReturn = Class.Channel.Delete_ChannelMore(ArrKeyVal);
                        break;
                    case "UpdateTable":
                        strReturn = Class.UpdateTable.Delete_UpdateTable(ArrKeyVal);
                        break;
                    default:
                        break;
                }
                context.Response.Write(strReturn);
            }
            catch
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


        private bool checkMac(string[] strMac)
        {
            SqlParameter[] param ={
                                      new SqlParameter("@flag",8)
                             };

            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                foreach (string sMAC in strMac)
                {
                    if (dtb.Rows[i].ItemArray[0].ToString().Trim() == sMAC.Trim())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
