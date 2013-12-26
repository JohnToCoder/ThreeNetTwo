using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ThreeNetTwo.ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class UpdateData : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string strKeyValue = context.Request["KeyValue"].ToString().Trim();
                string strReturn = "";
                switch (strKeyValue)
                {
                    case "Movie":
                        strReturn = ExecUpdate_Movie(context);
                        break;
                    case "Role":
                        strReturn = ExecUpdate_Role(context);
                        break;
                    case "MacRole":
                        strReturn = ExecUpdate_MacRole(context);
                        break;
                    case "TVPlay":
                       strReturn = ExecUpdate_TVPlay(context);
                       break;
                    case "TVPlaySub":
                       strReturn = ExecUpdate_TVSub(context);
                       break;
                    case "Channel":
                       strReturn = ExecUpdate_Channel(context);
                       break;
                    case "Users":
                       strReturn = ExecUpdate_Users(context);
                       break;
                    case "Photo":
                       strReturn = ExecUpdate_Photo(context);
                       break;
                    case "Mac":
                       strReturn = ExecUpdate_Mac(context);
                       break;
                    case "Album":
                       strReturn = ExecUpdate_Album(context);
                       break;
                    case "Music":
                        strReturn=ExecUpdate_Music(context);
                        break;
                    case "Version":
                        strReturn = ExecUpdate_Version(context);
                        break;
                    case "ChannelMore":
                        strReturn = ExecUpdate_ChannelMore(context);
                        break;
                    case "UpdateTable":
                        strReturn = ExecUpdate_UpdateTable(context);
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


        /// <summary>
        /// 功能：獲取電影設定值
        /// 開發人員：沈譚義
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Movie(HttpContext context)
        {
            string strMovieName = context.Request["MovieName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strType = context.Request["Type"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strDesc = context.Request["Desc"].ToString();
            string strMediaSource = context.Request["MediaSource"].ToString();
            string strPageIndex = context.Request["PageIndex"].ToString();
            return Class.Movie.Edit_Movie(strMovieName, strType, strUrl, strComeOut, strDesc,strMediaSource,strPageIndex);
        }

        /// <summary>
        /// 功能：獲取電視劇設定值
        /// 開發人員：曹翠華
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_TVPlay(HttpContext context)
        {
            string strTVPlayName = context.Request["TVPlayName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strTVPlayID = context.Request["TVPlayID"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strType = context.Request["Type"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strDesc = context.Request["Desc"].ToString();          
            string strMediaSource = context.Request["MediaSource"].ToString();
            string strPageIndex = context.Request["PageIndex"].ToString();
            return Class.TVPlay.Edit_TVPlay(strTVPlayName, strTVPlayID,strType, strUrl, strComeOut, strDesc, strMediaSource, strPageIndex); 

        }
        /// <summary>
        /// 函數名稱:ExecUpdate_TVSub
        /// 函數功能:獲取電視劇分集設定值
        /// 開發人員:曹翠華
        /// 開發日期:2011/3/31        
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_TVSub(HttpContext context)
        {
            
            string strTVSub = context.Request["TVSub"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strTVPlayID = context.Request["TVPlayID"].ToString();
            string strTVSubID = context.Request["TVSubID"].ToString();
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strDesc = context.Request["Desc"].ToString();
            string strPageIndex = context.Request["PageIndex"].ToString();
            return Class.TVPlay.Edit_TVSub(strTVSub, strTVPlayID,strTVSubID, strUrl, strComeOut, strDesc, strPageIndex); 

        }
          

        /// <summary>
        /// 函數功能：獲取專輯信息設定值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Album(HttpContext context)
        {
            string strAlbumName = context.Request["AlbumName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strAlbumID = context.Request["AlbumID"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strType = context.Request["Type"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strSinger = context.Request["Singer"].ToString();
            string strMediaSource = context.Request["MediaSource"].ToString();
            string strPageIndex = context.Request["PageIndex"].ToString();
            return Class.Music.Edit_Album(strAlbumName,strAlbumID, strType, strUrl, strComeOut, strSinger, strMediaSource, strPageIndex);
        }
        /// <summary>
        /// 獲取音樂信息設定值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Music(HttpContext context)
        {
            string strMusicName = context.Request["MusicName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
             string strAlbumName = context.Request["AlbumName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strType = context.Request["Type"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strSinger = context.Request["Singer"].ToString();
            string strMusicID = context.Request["MusicID"].ToString();
            string strPageIndex = context.Request["PageIndex"].ToString();
            string strOrder = context.Request["Order"].ToString();
            return Class.Music.Edit_Music(strMusicName, strAlbumName, strType, strUrl, strComeOut, strSinger, strMusicID, strPageIndex,strOrder);
        
        }


        /// <summary>
        /// 功能：獲取電視劇設定值
        ///修改人員：楊久中
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Role(HttpContext context)
        {
            string strCode = context.Request["RoleCode"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strDesc = context.Request["RoleDesc"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strRoleId = context.Request["RoleId"].ToString().Trim().Replace("--", "_").Replace("'", "’");

            return Class.Role.Update_Roles(strRoleId, strCode, strDesc);

        }

        /// <summary>
        /// 功能：獲取頻道設定值
        /// 修改人員：劉鋒
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Channel(HttpContext context)
        {
            string strChannelName = context.Request["ChannelName"].ToString().Trim();           
            string strChannelUrl = context.Request["ChannelUrl"].ToString().Trim();
            string strUrlIPad = context.Request["UrlIPad"].ToString();
            string strArea = context.Request["Area"].ToString();
            string strChannelType = context.Request["ChannelType"].ToString();
            string strPageIndex = context.Request["PageIndex"].ToString();
            return Class.Channel.UpdateChannel(strPageIndex);
        }


        /// <summary>
        /// 功能：獲取用戶設定值
        /// 修改人員：劉劉洪彬
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Users(HttpContext context)
        {
    
            string strUsersCode = context.Request["UserCode"].ToString().Trim();
            string strID = context.Request["ID"].ToString().Trim();
            return Class.Users.Edit_Users(strUsersCode,int.Parse(strID));
        }

        /// <summary>
        /// 功能：修改相冊數據
        /// 修改人員：胡貴
        /// 開發日期：2011-3-21
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Photo(HttpContext context)
        {
            string ID = context.Request["ID"].ToString().Trim();
            string strImageName = context.Request["ImageName"].ToString().Trim();
            string strPCID = context.Request["PictureCatalog"].ToString().Trim();

            return Class.Photo.Edit_Photo(ID , strImageName , strPCID);
        }

        /// <summary>
        /// 功能：獲取Mac設置
        ///修改人員：楊久中
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Mac(HttpContext context)
        {
            string strCode = context.Request["Mac"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strDesc = context.Request["Meno"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strMacId = context.Request["MacId"].ToString().Trim();
            string strName = context.Request["name"].ToString().Trim();
            string strTel = context.Request["tel"].ToString().Trim();
            string strMobile = context.Request["mobile"].ToString().Trim();
            string strRole = context.Request["role"].ToString().Trim();

            string strUserId = context.Request["UserId"].ToString().Trim();
            string strSex = context.Request["Sex"].ToString().Trim();
            string strBirDay = context.Request["BirthDay"].ToString().Trim();
            string strEmail = context.Request["Email"].ToString().Trim();
            string strAddress = context.Request["Address"].ToString().Trim();

            return Class.Mac.Update_Mac(strCode, strDesc,strMacId,strName,strTel,strMobile,strRole,strUserId,strSex,strBirDay,strEmail,strAddress);

        }

        /// <summary>
        /// 功能：獲取版本設定值
        /// 修改人員：劉鋒
        /// 開發日期：2011-3-24
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_Version(HttpContext context)
        {
            string strVersionNum = context.Request["VersionNum"].ToString().Trim();
            string strVersionDesc = context.Request["VersionDesc"].ToString().Trim();
            string strVersionDate = context.Request["VersionDate"].ToString();
            string strPubDate = context.Request["PubDate"].ToString();
            return Class.Version.UpdateVersion();
        }


        /// <summary>
        /// 功能：修改客戶角色
        /// 修改人員：胡貴
        /// 開發日期：2011-4-1
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_MacRole(HttpContext context)
        {
            string strCode = context.Request["MacRoleCode"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strDesc = context.Request["MacRoleDesc"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strRoleId = context.Request["MacRoleId"].ToString().Trim().Replace("--", "_").Replace("'", "’");

            return Class.MacRole.Update_MacRoles(strRoleId, strCode, strDesc);
        }

        /// <summary>
        /// 功能：獲取頻道設定值
        /// 修改人員：劉鋒
        /// 開發日期：2011-4-7
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_ChannelMore(HttpContext context)
        {
            string strChannelID = context.Request["ChannelID"].ToString().Trim();
            string strKeyID = context.Request["KeyID"].ToString().Trim();
            string strProgramName = context.Request["ProgramName"].ToString().Trim();
            string strPlayingDate = context.Request["PlayingDate"].ToString();
            string strPlayingTime = context.Request["PlayingTime"].ToString();
            return Class.Channel.UpdateChannelMore(strChannelID, strKeyID, strProgramName, strPlayingDate, strPlayingTime);
        }

        /// <summary>
        /// 修改人員：楊碧清
        /// 開發日期：2011-05-23
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecUpdate_UpdateTable(HttpContext context)
        {
            string strId= context.Request["Id"].ToString().Trim();
            string strTableName = context.Request["txtTableName"].ToString().Trim();
            string strCodeDesc = context.Request["txtCodeDesc"].ToString();
            string strOrderID = context.Request["txtOrderID"].ToString().Trim();
            return Class.UpdateTable.Update_UpdateTable(strId, strTableName, strCodeDesc,strOrderID);
        }
    }
}
