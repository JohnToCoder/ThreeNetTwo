using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Class
{
    public class Common
    {
        /// <summary>
        /// Edit by tanyi 2011314
        /// 獲取指定長度的中英文混合字符串
        /// </summary>
        public static string SubString(string str, int len)
        {
            string temp = str.Trim();
            int j = 0;
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (Regex.IsMatch(temp.Substring(i, 1), @"[\u4e00-\u9fa5]+"))
                {
                    j += 2;//雙字節
                }
                else
                {
                    j += 1;//單字節
                }

                if (j <= len)
                {
                    k += 1;
                }
                if (j > len)
                {
                    return temp.Substring(0, k) + "...";
                }
            }
            return temp;
        }


        /// <summary>
        /// 按比例縮小圖片
        /// </summary>
        /// <param name="sourceFile">源图文件名(包括路径)</param>
        /// <param name="destFile">缩小后保存为文件名(包括路径)</param>
        /// <param name="destHeight">缩小至高度</param>
        /// <param name="destWidth">缩小至宽度</param>
        /// <returns></returns>
        public static List<int> GetThumbnail(string sourceFile, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = System.Drawing.Image.FromFile(sourceFile);
            int sW = 0, sH = 0;
            // 按比例缩放
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;

            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }

            //System.Drawing.Image objThumbImage = imgSource.GetThumbnailImage(sW, sH, null, new IntPtr());
            ////放入畫布
            //Bitmap objBitmap = new Bitmap(objThumbImage);
            ////存檔
            //objBitmap.Save(destFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            //imgSource.Dispose();
            //objThumbImage.Dispose();

            List<int> imageSize = new List<int>();
            imageSize.Add(sH);
            imageSize.Add(sW);
            return imageSize;
        }

        /// <summary>
        /// 按地址上傳圖片
        /// strOldImagePath : 為需上傳圖片本地地址
        /// strFilePath ： 為數據庫存放部分地址
        /// strImageType ： 圖片所屬類型
        /// </summary>
        /// <param name="strImagePath"></param>
        /// <param name="strFilePath"></param>
        /// <param name="strImageType"></param>
        public static void SaveImage(string strOldImagePath, string strFilePath , string strImageType)
        {
            FileStream fs = File.Open(strOldImagePath, FileMode.OpenOrCreate, FileAccess.Read);

            int Filelen = (Int32)fs.Length;
            byte[] bytes = new byte[Filelen];

            fs.Read(bytes, 0, Filelen);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms, false);
            Bitmap bm = new Bitmap(img);

            string strNewImagePath = GetImagePath(strImageType) + strFilePath;
            bm.Save(strNewImagePath);

            fs.Close();
            fs.Dispose();
        }


        /// <summary>
        /// 根據圖片類型找出圖片存放路徑
        /// </summary>
        /// <param name="strImageType"></param>
        /// <returns></returns>
        public static string GetImagePath(string strImageType)
        {
            string strNewImagePath = HttpContext.Current.Request.PhysicalApplicationPath;
            SqlParameter[] param ={
                                     new SqlParameter("@flag",1),
                                     new SqlParameter("@type",strImageType)
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_SourcePath_sp", param);

            strNewImagePath = strNewImagePath.Substring(0, strNewImagePath.LastIndexOf("\\", 3))
                        + dt.Rows[0]["ImageURL"].ToString();
            return strNewImagePath;
        }
    }
}
