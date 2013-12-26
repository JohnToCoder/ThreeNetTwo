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
    public class AddData : IHttpHandler, IRequiresSessionState
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
                        strReturn = ExecAdd_Movie(context);
                        break;
                    case "Users":
                        strReturn = ExecAdd_Users(context);
                        break;
                    case "TVPlay":
                        strReturn = ExecAdd_TVPlay(context);
                        break;
                    case "TVPlaySub":
                        strReturn = ExecAdd_TVSub(context);
                        break;
                    case "Photo":
                        strReturn = ExecAdd_Photo(context);
                        break;
                    case "Channel":
                        strReturn = ExecAdd_Channel(context);
                        break;
                    case "Music":
                        strReturn = ExecAdd_Music(context);
                        break;
                    case "Album":
                        strReturn = ExecAdd_Album(context);
                        break;
                    case "Role":
                        strReturn = ExecAdd_Role(context);
                        break;
                    case "MacRole":
                        strReturn = ExecAdd_MacRole(context);
                        break;
                    case "Mac":
                        strReturn = ExecAdd_Mac(context);
                        break;
                    case "Version":
                        strReturn = ExecAdd_Version(context);
                        break;
                    case "ChannelMore":
                        strReturn = ExecAdd_ChannelMore(context);
                        break;
                    case "UpdateTable":
                        strReturn = ExecAdd_UpdateTable(context);
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
        private string ExecAdd_Movie(HttpContext context)
        {
            string strMovieName = context.Request["MovieName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strType = context.Request["Type"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strDesc = context.Request["Desc"].ToString();
            string strMediaSource = context.Request["MediaSource"].ToString();
            return Class.Movie.Add_Movie(strMovieName, strType, strUrl, strComeOut, strDesc, strMediaSource); ;
        }

        /// <summary>
        /// 函數名稱:ExecAdd_TVPlay
        /// 函數功能:獲取電視劇設定值
        /// 開發人員：曹翠華
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>

        private string ExecAdd_TVPlay(HttpContext context)
        {
            string strTVPlayName = context.Request["TVPlayName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strType = context.Request["Type"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strDesc = context.Request["Desc"].ToString();
            string strMediaSource = context.Request["MediaSource"].ToString();
            return Class.TVPlay.Add_TVPlay(strTVPlayName, strType, strUrl, strComeOut, strDesc, strMediaSource); ;
        }
        /// <summary>
        /// 函數名稱:ExecAdd_TVSub
        /// 函數功能:獲取電視劇分集信息設定值
        /// 開發人員:曹翠華
        /// 開發日期:2011/3/31
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_TVSub(HttpContext context)
        {

            string strTVSub = context.Request["TVSub"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strTVPlayID = context.Request["TVPlayID"].ToString();
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strDesc = context.Request["Desc"].ToString();
            return Class.TVPlay.Add_TVSub(strTVSub, strTVPlayID, strUrl, strComeOut, strDesc); ;

        }

        /// <summary>
        /// 功能：獲取用戶名和密碼
        /// 開發人員：劉洪彬
        /// 開發日期：2011-3-16
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_Users(HttpContext context)
        {

            string strUserCode = context.Request["UserCode"].ToString();
            return Class.Users.Add_Users(strUserCode);

        }


        /// <summary>
        /// 功能：新增相冊圖片
        /// 開發人員：胡貴
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_Photo(HttpContext context)
        {
            string strImageName = context.Request["ImageName"].ToString();
            string strPictureCatalog = context.Request["PictureCatalog"].ToString();
            string strFileUpload = context.Request["FileUpload"].ToString();
            return Class.Photo.Add_Photo(strImageName, strPictureCatalog, strFileUpload);
        }

        /// <summary>
        /// 功能：獲取頻道設定值
        /// 開發人員：劉鋒
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_Channel(HttpContext context)
        {
            string strChannelName = context.Request["ChannelName"].ToString().Trim();
            string strChannelUrl = context.Request["ChannelUrl"].ToString().Trim();
            string strUrlIPad = context.Request["UrlIPad"].ToString();
            string strArea = context.Request["Area"].ToString();
            string strChannelType = context.Request["ChannelType"].ToString();
            return Class.Channel.CheckBeforeAdding(strChannelName);
        }

        /// <summary>
        /// 獲取音樂設定值
        /// 開發人員：郭世麗
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_Music(HttpContext context)
        {
            string strMusicName = context.Request["MusicName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strAlbum = context.Request["AlbumID"].ToString();
            string strType = context.Request["Type"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strSinger = context.Request["Singer"].ToString();
            string strOrder = context.Request["Order"].ToString();
            return Class.Music.Add_Music(strMusicName, strAlbum, strType, strUrl, strComeOut, strSinger, strOrder);
        }

        /// <summary>
        /// 獲取音樂專輯設定值
        /// 開發人員：郭世麗
        /// 開發日期：2011-3-18
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_Album(HttpContext context)
        {
            string strAlbumName = context.Request["AlbumName"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strType = context.Request["Type"].ToString().Trim().Replace("-", "_").Replace("'", "’");
            string strUrl = context.Request["Url"].ToString();
            string strComeOut = context.Request["ComeOut"].ToString();
            string strSinger = context.Request["Singer"].ToString();
            string strMediaSource = context.Request["MediaSource"].ToString();
            return Class.Music.Add_Album(strAlbumName, strType, strUrl, strComeOut, strSinger, strMediaSource);
        }

        /// <summary>
        /// 獲取角色設定值
        /// 開發人員：楊久中
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_Role(HttpContext context)
        {
            string strCode = context.Request["RoleCode"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strDesc = context.Request["RoleDesc"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            return Class.Role.Add_Roles(strCode, strDesc);
        }

        /// <summary>
        /// 獲取Mac權限
        /// 開發人員：楊久中
        /// 開發日期：2011-3-17
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_Mac(HttpContext context)
        {
            string strCode = context.Request["Mac"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strDesc = context.Request["Meno"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strName = context.Request["name"].ToString().Trim();
            string strTel = context.Request["tel"].ToString().Trim();
            string strMobile = context.Request["mobile"].ToString().Trim();
            string strRole = context.Request["role"].ToString().Trim();

            string strUserId = context.Request["UserId"].ToString().Trim();
            string strSex = context.Request["Sex"].ToString().Trim();
            string strBirDay = context.Request["BirthDay"].ToString().Trim();
            string strEmail = context.Request["Email"].ToString().Trim();
            string strAddress = context.Request["Address"].ToString().Trim();




            return Class.Mac.Add_Mac(strCode, strDesc, strName, strTel, strMobile, strRole, strUserId, strSex, strBirDay, strEmail, strAddress);
        }

        /// <summary>
        /// 功能：獲取版本設定值
        /// 開發人員：劉鋒
        /// 開發日期：2011-3-24
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_Version(HttpContext context)
        {
            string strVersionNum = context.Request["VersionNum"].ToString().Trim();
            string strVersionDesc = context.Request["VersionDesc"].ToString().Trim();
            string strVersionDate = context.Request["VersionDate"].ToString();
            string strPubDate = context.Request["PubDate"].ToString();
            return Class.Version.CheckBeforeAdding(strVersionNum);
        }

        /// <summary>
        /// 功能：新增客戶角色管理
        /// 開發人員：胡貴
        /// 開發日期：2011-4-1
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_MacRole(HttpContext context)
        {
            string strCode = context.Request["MacRoleCode"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            string strDesc = context.Request["MacRoleDesc"].ToString().Trim().Replace("--", "_").Replace("'", "’");
            return Class.MacRole.Add_MacRoles(strCode, strDesc);
        }

        /// <summary>
        /// 功能：新增節目
        /// 開發人員：劉鋒
        /// 開發日期：2011-4-7
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_ChannelMore(HttpContext context)
        {
            string strChannelID = context.Request["ChannelID"].ToString().Trim();
            string strProgramName = context.Request["ProgramName"].ToString().Trim();
            string strPlayingDate = context.Request["PlayingDate"].ToString();
            string strPlayingTime = context.Request["PlayingTime"].ToString();
            return Class.Channel.Check(strChannelID, strProgramName, strPlayingDate, strPlayingTime);
        }


        /// <summary>
        /// 開發人員：楊碧清
        /// 開發日期：2011-05-23
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string ExecAdd_UpdateTable(HttpContext context)
        {
            string strTableName = context.Request["txtTableName"].ToString().Trim();
            string strCodeDesc = context.Request["txtCodeDesc"].ToString();
            string strOrderID = context.Request["txtOrderID"].ToString();
            return Class.UpdateTable.Add_UpdateTb(strTableName, strCodeDesc, strOrderID);
        }

    }

}
