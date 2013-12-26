using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace ThreeNetTwo.Music
{
    public partial class MD_Album_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    string strFlag = Request["flag"];
                    if (strFlag.Equals("sel"))
                    {
                        trFileUp.Visible = false;
                        this.btn_OK.Visible = false;
                        this.spAlbum.Visible = false;
                        this.spType.Visible = false;
                        this.spSinger.Visible = false;
                        this.spCome.Visible = false;
                        this.spUrl.Visible = false;
                        this.spMedia.Visible = false;

                    }
                    else
                    {

                        trFileUp.Visible = true;
                        this.btn_OK.Visible = false;
                    }
                    AllddlBind();
                    if (Request["key"] != null)
                    {
                        trFileUp.Visible = true;
                        setValue(Request["key"].ToString());
                    }
                }
                catch { }
            }


        }
        /// <summary>
        /// 函數名稱：
        /// 函數功能：點擊修改按鈕時內容自動填充
        /// 開發者：曹翠華
        /// 開發日期：2011/3/23
        /// </summary>
        /// 
        protected void setValue(string strKey)
        {
            SqlParameter[] param ={
                               new SqlParameter("@flag",34),
                               new SqlParameter("@MusicID",strKey)                               
                               };
            DataTable dbt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_Music_sp]", param);
            txtAlbumName.Text = dbt.Rows[0].ItemArray[0].ToString().Trim();
            ddlType.SelectedValue = dbt.Rows[0].ItemArray[1].ToString().Trim();
            txtUrl.Text = dbt.Rows[0].ItemArray[2].ToString().Trim();
            txtSinger.Text = dbt.Rows[0].ItemArray[3].ToString().Trim();
            txtComeOut.Text = Convert.ToDateTime(dbt.Rows[0].ItemArray[4].ToString().Trim()).ToString("yyyy-MM-dd");
            ddlMediaSource.SelectedValue = dbt.Rows[0].ItemArray[5].ToString().Trim();

            lblID.Text = strKey;
            txtImgPath.Text = dbt.Rows[0].ItemArray[6].ToString().Trim();

        }

        private void AllddlBind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",19)     
                                 };
            DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.StoredProcedure, "[MD_Music_sp]", param);

            //綁定專輯類型
            ddlType.DataSource = ds.Tables[0];
            ddlType.DataValueField = "ID";
            ddlType.DataTextField = "ClassDesc";
            ddlType.DataBind();

            ListItem ddlItem = new ListItem();
            ddlItem.Text = "--請選擇專輯類型--";
            ddlItem.Value = "";
            ddlType.Items.Insert(0, ddlItem);

            //綁定媒體來源
            ddlMediaSource.DataSource = ds.Tables[1];
            ddlMediaSource.DataValueField = "ID";
            ddlMediaSource.DataTextField = "MediaName";
            ddlMediaSource.DataBind();

            ListItem ddlItem2 = new ListItem();
            ddlItem2.Text = "--請選擇媒體來源--";
            ddlItem2.Value = "";
            ddlMediaSource.Items.Insert(0, ddlItem2);
        }
        //
        /// <summary>
        /// 函數名稱：btn_OK_Click
        /// 函數功能：新增和修改按鈕的觸發事件
        /// 開發者：曹翠華
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string strFileExtension = "";
                if (fileUpload.FileName != "")
                {
                    strFileExtension = System.IO.Path.GetExtension(fileUpload.FileName);

                }
                if (lblID.Text == "")
                {
                    AddAlbum(strFileExtension);
                    AddAlbumImg(strFileExtension, "Add");
                    string strPostUrl = "../Music/MD_Album.aspx?KeyValue=Add&t=" + DateTime.Now.ToFileTime();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");

                }
                else
                {

                    UpdateAlbum(strFileExtension);
                    AddAlbumImg(strFileExtension, "Update");
                    DeleteOldImg(strFileExtension);//如果圖片後綴與原圖片不同，刪除原圖片
                    string strPostUrl = "../Music/MD_Album.aspx?KeyValue=Update&strIndex=" + txtPageRecord.Text.ToString() + "&t=" + DateTime.Now.ToFileTime();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }


        }
        /// <summary>
        ///函數名稱：AddAlbum
        ///函數功能： 專輯信息的添加
        ///開發者：曹翠華
        /// </summary>
        /// <param name="strFileExtension"></param>
        protected void AddAlbum(string strFileExtension)
        {
            User objUser = HttpContext.Current.Session["User"] as User;
            SqlParameter[] param ={
                                  new SqlParameter("@flag",20),
                                  new SqlParameter("@AlbumName",txtAlbumName.Text.Trim().ToString()),
                                  new SqlParameter("@AlbumURL",txtUrl.Text.Trim().ToString()),
                                  new SqlParameter("@MusicClassID",ddlType.SelectedValue),                                
                                  new SqlParameter("@ComeOut",txtComeOut.Text.Trim().ToString()),
                                  new SqlParameter("@MediaTypeId",ddlMediaSource.SelectedValue),
                                  new SqlParameter("@Creator",txtSinger.Text.Trim()),
                                  new SqlParameter("@Creator1",objUser.UserCode),
                                  new SqlParameter("@ImgExtension",strFileExtension)
                             };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[MD_Music_sp]", param);


        }
        // 
        /// <summary>
        /// 函數名稱：AddAlbumImg        
        /// 函數功能：專輯劇照的添加
        /// 開發者：曹翠華
        /// </summary>
        /// <param name="strFileExtension"></param>
        /// <param name="strFlag"></param>

        protected void AddAlbumImg(string strFileExtension, string strFlag)
        {
            if (fileUpload.FileName != "")
            {
                string strImgPath = "";//數據庫路徑名稱
                string strImgPaths = "";//目標路徑

                int intAlbumID;

                if (strFlag == "Add")
                {
                    intAlbumID = Class.Music.GetAlbumID(txtAlbumName.Text.Trim().ToString());
                    strImgPath = "Images/MusicAlbum/" + intAlbumID + strFileExtension;
                }
                else if (strFlag == "Update")
                {
                    intAlbumID = Convert.ToInt32(lblID.Text.ToString());
                    strImgPath = "Images/MusicAlbum/" + intAlbumID + strFileExtension;
                }
                //目標圖片所在的路徑
                strImgPaths = Class.Common.GetImagePath("Music") + strImgPath;
                fileUpload.PostedFile.SaveAs(strImgPaths);
            }
        }
        /// <summary>
        /// 函數名稱：UpdateAlbum
        /// 函數功能：修改專輯信息
        /// </summary>
        /// <param name="strFileExtension"></param>
        protected void UpdateAlbum(string strFileExtension)
        {
            User objUser = HttpContext.Current.Session["User"] as User;
            SqlParameter[] param2 = {
                                  new SqlParameter("@flag",21),
                                  new SqlParameter("@AlbumName",txtAlbumName.Text.Trim().ToString()),
                                  new SqlParameter("@AlbumURL",txtUrl.Text.Trim().ToString()),
                                  new SqlParameter("@MusicClassID",ddlType.SelectedValue),                                 
                                  new SqlParameter("@ComeOut",txtComeOut.Text.Trim().ToString()),
                                  new SqlParameter("@MediaTypeId",ddlMediaSource.SelectedValue),
                                  new SqlParameter("@Creator",txtSinger.Text.Trim()),
                                  new SqlParameter("@Creator1",objUser.UserCode),
                                  new SqlParameter("@ImgExtension",strFileExtension),
                                  new SqlParameter("@MusicID",Convert.ToInt32(lblID.Text.Trim().ToString()))                                 
                                    
                                 };

            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[MD_Music_sp]", param2);
        }
        /// <summary>
        /// 函數名稱：DeleteOldImg
        /// 函數功能：刪除原來的劇照       
        /// 開發時間：2011/3/20 
        /// <param name="strFileExtension"></param>
        private void DeleteOldImg(string strFileExtension)
        {
            int intAlbumID = Convert.ToInt32(lblID.Text.ToString());
            string strImgPath = "Images/MusicAlbum/" + intAlbumID + strFileExtension;
            if (fileUpload.FileName != "")
            {
                if (txtImgPath.Text.Trim().ToString() != "" && txtImgPath.Text.Trim().ToString() != strImgPath)
                {
                    File.Delete(Class.Common.GetImagePath("Music") + txtImgPath.Text.Trim().ToString());

                }
            }
        }

        ///// <summary> 
        ///// 函數名：btnStopKeyEnter_Click
        ///// 函數功能：(不可刪除)防止在非IE瀏覽器下按下回車觸發默認按鈕事件
        ///// 開發者： 劉鋒
        ///// 開發日期：2011-03-23
        ///// 修改者：
        ///// 修改日期：
        ///// </summary>
        //protected void btnStopKeyEnter_Click(object sender, EventArgs e)
        //{
        //    try
        //    { }
        //    catch
        //    { }
        //}

    }
}
