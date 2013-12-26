using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace ThreeNetTwo.Movie
{
    public partial class MD_Movie_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    btnFocus.Focus();
                    string strFlag = Request["flag"];
                    if (!strFlag.Equals("ins"))
                    {
                        trFileUp.Visible = false;
                        this.btn_OK.Visible = false;
                        this.MovieAddress.Visible = false;
                        this.MovieComeOut.Visible = false;
                        this.MovieMedia.Visible = false;
                        this.MovieName.Visible = false;
                        this.MovieType.Visible = false;
                    }
                    else
                    {
                        trFileUp.Visible = true;
                        this.btn_OK.Visible = true;
                        this.MovieAddress.Visible = true ;
                        this.MovieComeOut.Visible = true;
                        this.MovieMedia.Visible = true;
                        this.MovieName.Visible = true;
                        this.MovieType.Visible = true;
                    }
                    ddlBind();
                    if (Request["key"] != null)
                    {
                        trFileUp.Visible = true;
                        setValue(Request["key"].ToString());
                    }
                }
                catch
                { }
            }
        }
        /// <summary>
        /// 修改頁面時初始化頁面
        /// Edit By tanyi 2011.3.16
        /// </summary>
        /// <param name="strKey"></param>
        private void setValue(string strKey)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",16),
                                 new SqlParameter("@MoviesID",strKey)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", param);

            txtMovieName.Text = dtb.Rows[0].ItemArray[0].ToString().Trim();
            txtUrl.Text = dtb.Rows[0].ItemArray[1].ToString().Trim();
            ddlType.SelectedValue = dtb.Rows[0].ItemArray[2].ToString().Trim();
            txtComeOut.Text = Convert.ToDateTime(dtb.Rows[0].ItemArray[3].ToString().Trim()).ToString("yyyy-MM-dd");
            txtDesc.Text = dtb.Rows[0].ItemArray[4].ToString().Trim();
            ddlMediaSource.SelectedValue = dtb.Rows[0].ItemArray[5].ToString().Trim();

            lblID.Text = strKey;//修改者： 沈譚義 獲取修改數據的ID 2011/3/16

            txtImgPath.Text = dtb.Rows[0].ItemArray[6].ToString().Trim();//獲取原先圖片路徑　Edit by tanyi 2011.03.17
        }
        /// <summary>
        /// 綁定電影類型、地區、媒體來源
        /// Edit By Tanyi 2011.3.16
        /// </summary>
        private void ddlBind()
        {
            //綁定電影類型
            SqlParameter[] param ={
                                     new SqlParameter("@flag",6)     
                                 };
            ddlType.DataSource = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_Movies_sp]", param);
            ddlType.DataValueField = "id";
            ddlType.DataTextField = "ClassDesc";
            ddlType.DataBind();

            ListItem ddlItem = new ListItem();
            ddlItem.Text = "--請選擇電影類型--";
            ddlItem.Value = "0";
            ddlType.Items.Insert(0, ddlItem);

            //綁定媒體來源
            SqlParameter[] paramForMedia ={
                                     new SqlParameter("@flag",1)     
                                 };
            DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.StoredProcedure, "[MD_Movies_sp]", paramForMedia);
            DataTable dt = ds.Tables[1];
            ddlMediaSource.DataSource = dt;
            ddlMediaSource.DataValueField = "ID";
            ddlMediaSource.DataTextField = "MediaName";
            ddlMediaSource.DataBind();

            ListItem ddlItemForMedia = new ListItem();
            ddlItemForMedia.Text = "--請選擇媒體來源--";
            ddlItemForMedia.Value = "0";
            ddlMediaSource.Items.Insert(0, ddlItemForMedia);

        }
        /// <summary>
        /// 電影數據的添加和修改
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

                //lblID用來判斷是新增還是修改 By Tanyi 2010/10/11
                if (lblID.Text == "")
                {
                    AddMovie(strFileExtension);//添加數據
                    AddMovieImg(strFileExtension,"Add");//保存圖片
                    string strPostUrl = "../Movie/MD_Movie.aspx?KeyValue=Add&t=" + DateTime.Now.ToFileTime();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");
                }
                else
                {
                    UpdateMovie(strFileExtension);//更新數據
                    //Eidt By tanyi 2011/4/7  如果沒有上傳圖片的情況
                    if (fileUpload.FileName != "")
                    {
                        AddMovieImg(strFileExtension, "Update");//更新圖片
                        DeleteOldImg(strFileExtension);//如果圖片後綴與原圖片不同，刪除原圖片
                    }

                    string strPostUrl = "../Movie/MD_Movie.aspx?KeyValue=Update&strIndex="+txtPageRecord.Text.ToString()+"&t=" + DateTime.Now.ToFileTime();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");

                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        /// <summary>
        /// 電影數據的添加
        /// Edit By Tanyi 2011.03.21
        /// </summary>
        private void AddMovie(string strFileExtension)
        {
            SqlParameter[] param1 ={
                                   new SqlParameter("@flag",15),
                                   new SqlParameter("@MovieName",txtMovieName.Text.Trim().ToString()),
                                   new SqlParameter("@MoviesURL",txtUrl.Text.Trim().ToString()),
                                   new SqlParameter("@MTClassID",ddlType.SelectedValue),
                                   new SqlParameter("@ComeOut",txtComeOut.Text.Trim().ToString()),
                                   new SqlParameter("@Summary",txtDesc.Text.Trim().ToString()),
                                   new SqlParameter("@ImgExtension",strFileExtension),
                                   new SqlParameter("@MediaForID",ddlMediaSource.SelectedValue),
                              };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[MD_Movies_sp]", param1);
        }
        /// <summary>
        /// 進行劇照的添加
        /// Edit by tanyi 2011.3.21
        /// </summary>
        private void AddMovieImg(string strFileExtension,string strFlag)
        {
            //Edit By Tanyi 2011.3.17
            //劇照的添加
            string strImgPath = ""; //數據庫路徑字段的名稱
            string strImgPaths = "";//目標文件的位置

            //進行劇照的添加
            //獲取劇照的ID edit By tanyi 2011-3-17
            int intMovieID;

            if (strFlag =="Add")
            {
                intMovieID = Class.Movie.GetMovieID(txtMovieName.Text.Trim().ToString());
                strImgPath = "Images/Movie/" + intMovieID + strFileExtension;
            }
            else if (strFlag == "Update")
            {
                intMovieID=Convert.ToInt32(lblID.Text.ToString());
                strImgPath = "Images/Movie/" + intMovieID + strFileExtension;
            }


            //目標圖片文件所在路徑
            strImgPaths = Class.Common.GetImagePath("Movie") + strImgPath;


            fileUpload.PostedFile.SaveAs(strImgPaths);
        }
        /// <summary>
        /// 電影數據的修改
        /// Edit By Tanyi 2011.03.21
        /// </summary>
        private void UpdateMovie(string strFileExtension)
        {
            SqlParameter[] param2 ={
                                   new SqlParameter("@flag",17),
                                   new SqlParameter("@MovieName",txtMovieName.Text.Trim().ToString()),
                                   new SqlParameter("@MoviesURL",txtUrl.Text.Trim().ToString()),
                                   new SqlParameter("@MTClassID",ddlType.SelectedValue),
                                   new SqlParameter("@ComeOut",txtComeOut.Text.Trim().ToString()),
                                   new SqlParameter("@Summary",txtDesc.Text.Trim().ToString()),
                                   new SqlParameter("@ImgExtension",strFileExtension),
                                   new SqlParameter("@MediaForID",ddlMediaSource.SelectedValue),
                                   new SqlParameter("@MoviesID",Convert.ToInt32(lblID.Text.Trim().ToString()))
                              };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[MD_Movies_sp]", param2);
        }
        /// <summary>
        /// 如果修改的圖片後綴與原圖片不同則需要刪除原先的圖片
        /// Edit By tanyi 2011.3.21
        /// </summary>
        /// <param name="strFileExtension"></param>
        private void DeleteOldImg(string strFileExtension)
        {
            int intMovieID = Convert.ToInt32(lblID.Text.ToString());
            string strImgPath = "Images/Movie/" + intMovieID + strFileExtension;
            //刪除原來存在的圖片 Edit By tanyi 2011.03.17
            if (fileUpload.FileName != "")
            {
                //如果文件名稱不一樣則刪除原來的圖片 Edit By Tanyi 2011-3-17
                if (txtImgPath.Text.Trim().ToString() != "" && txtImgPath.Text.Trim().ToString() != strImgPath)
                {
                    File.Delete(Class.Common.GetImagePath("Movie") + txtImgPath.Text.Trim().ToString());
                }
            }
        }

        protected void btnFocus_Click(object sender, EventArgs e)
        {

        }   
    }
}
