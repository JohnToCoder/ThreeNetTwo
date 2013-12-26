using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;

namespace ThreeNetTwo.TVPlay
{
    public partial class MD_TVPlay_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strFlag = Request["flag"];
                    if (!strFlag.Equals("ins"))
                    {
                        trFileUp.Visible = false;
                        this.btn_OK.Visible = false;
                        lblTVPlayName.Visible = false;
                        lblType.Visible = false;
                        lblUrl.Visible = false;
                        lblDesc.Visible = false;
                        lblComeOut.Visible = false;
                        lblDediaSource.Visible = false;

                        
                    }
                    else
                    {
                       
                        trFileUp.Visible = true;
                        this.btn_OK.Visible = true;
                    }
                    ddlBind();
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
        /// 函數名稱:setValue
        /// 函數功能:點擊修改按鈕時內容填充到頁面
        /// 開發者:曹翠華
        /// 開發日期:2011/3/16
        /// </summary>
        /// <param name="strKey"></param>
        protected void setValue(string strKey)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",26),
                                 new SqlParameter("@TVPlayID",strKey)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);

            txtTVPlayName.Text = dtb.Rows[0].ItemArray[0].ToString().Trim();
            txtUrl.Text = dtb.Rows[0].ItemArray[1].ToString().Trim();
            ddlType.SelectedValue = dtb.Rows[0].ItemArray[2].ToString().Trim();          
            txtComeOut.Text = Convert.ToDateTime(dtb.Rows[0].ItemArray[3].ToString().Trim()).ToString("yyyy-MM-dd");
            txtDesc.Text = dtb.Rows[0].ItemArray[4].ToString().Trim();
            ddlMediaSource.SelectedValue = dtb.Rows[0].ItemArray[5].ToString().Trim();

            lblID.Text = strKey;//獲取修改數據的ID
            txtImgPath.Text = dtb.Rows[0].ItemArray[6].ToString().Trim();//獲取原先圖片的路徑

        }

        /// <summary>
        ///函數名稱:ddlBind
        ///函數功能: 綁定電視劇類型、媒體來源
        ///開發者:曹翠華
        ///開發日期:2011/3/16
        /// </summary>
        private void ddlBind()
        {
            //綁定電視劇類型
            SqlParameter[] param ={
                                     new SqlParameter("@flag",21)     
                                 };
            ddlType.DataSource = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
            ddlType.DataValueField = "ID";
            ddlType.DataTextField = "ClassDesc";
            ddlType.DataBind();

            ListItem ddlItem = new ListItem();
            ddlItem.Text = "--請選擇電視劇類型--";
            ddlItem.Value = "0";
            ddlType.Items.Insert(0, ddlItem);

          
            //綁定媒體來源
            SqlParameter[] paramForMedia ={
                                     new SqlParameter("@flag",22)     
                                 };
            ddlMediaSource.DataSource = ObjCon.MSSQL.ExectuteDataSet(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", paramForMedia);
            ddlMediaSource.DataValueField = "ID";
            ddlMediaSource.DataTextField = "MediaName";
            ddlMediaSource.DataBind();

            ListItem ddlItemForMedia = new ListItem();
            ddlItemForMedia.Text = "--請選擇媒體來源--";
            ddlItemForMedia.Value = "0";
            ddlMediaSource.Items.Insert(0, ddlItemForMedia);

        }

        /// <summary>
        /// 函數名稱：btn_OK_Click
        /// 函數功能：新增和修改功能的觸發按鈕
        /// 開發者：曹翠華
        /// 開發時間：2011/3/20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string strFileExtension="";
                if(fileUpload.FileName!="")
                {
                    strFileExtension = System.IO.Path.GetExtension(fileUpload.FileName);
                }
                //新增電視劇信息
                if (lblID.Text == "")
                {
                    AddTVPlay(strFileExtension);
                    AddTVPlayImg(strFileExtension,"Add");
                    string strPostUrl = "../TVPlay/MD_TVPlay.aspx?KeyValue=Add&t=" + DateTime.Now.ToFileTime();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");
                }
                else
                {
                    UpdateTVPlay(strFileExtension);
                    if(fileUpload.FileName!="")
                    {
                      AddTVPlayImg(strFileExtension,"Update");
                      DeleteOldImg(strFileExtension);//如果圖片後綴與原圖片不同，刪除原圖片
                    }
                   string strPostUrl = "../TVPlay/MD_TVPlay.aspx?KeyValue=Update&strIndex=" + txtPageRecord.Text.ToString() + "&t=" + DateTime.Now.ToFileTime();
                   Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        /// <summary>
        /// 函數名稱：AddTVPlay
        /// 函數功能：電視劇數據的添加
        /// 開發者：曹翠華
        /// 開發時間：2011/3/20
        /// </summary>
        /// <param name="strFileExtension"></param>
        protected void AddTVPlay(string strFileExtension)
        {       
            User objUser=HttpContext.Current.Session["User"] as User;
                SqlParameter[] param1 =
                                  {
                                   new SqlParameter("@flag",25),
                                   new SqlParameter("@TVPlayName",txtTVPlayName.Text.Trim().ToString()),
                                   new SqlParameter("@TVPlayURL",txtUrl.Text.Trim().ToString()),
                                   new SqlParameter("@MTClassID",ddlType.SelectedValue),                                   
                                   new SqlParameter("@ComeOut",txtComeOut.Text.Trim().ToString()),
                                   new SqlParameter("@Summary",txtDesc.Text.Trim().ToString()),
                                   new SqlParameter("@ImgExtension",strFileExtension),
                                   new SqlParameter("@MediaSoureID",ddlMediaSource.SelectedValue),
                                   new SqlParameter("@Creator",objUser.UserCode),
                                 };              
                
                ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param1);        
        
        }
        /// <summary>
        /// 函數名稱：AddTVPlayImg
        /// 功能：進行劇照的添加
        /// 開發者：曹翠華
        /// 開發時間：2011/03/20
        /// </summary>
        protected void AddTVPlayImg(string strFileExtension,string strFlag)
        {
            string strImgPath = "";//數據庫路徑名稱
            string strImgPaths = "";//目標路徑

            int intTVPlayID;

            if (strFlag == "Add")
            {
                intTVPlayID = Class.TVPlay.GetTVPlayID(txtTVPlayName.Text.Trim().ToString());
                strImgPath = "Images/TV/" + intTVPlayID + strFileExtension;
            }
            else if(strFlag=="Update")
            {
                intTVPlayID = Convert.ToInt32(lblID.Text.ToString());
                strImgPath = "Images/TV/" + intTVPlayID + strFileExtension;            
            }

            //目標圖片所在的路徑
            strImgPaths = Class.Common.GetImagePath("TVPlay") + strImgPath;

            fileUpload.PostedFile.SaveAs(strImgPaths);
        
        }
        /// <summary>
        /// 函數名稱：UpdateTVPlay
        /// 函數功能：電視劇數據的修改
        /// 開發者：曹翠華
        /// 開發時間:2011/3/20
        /// </summary>
        protected void UpdateTVPlay(string strFileExtension)
        { 
            
            SqlParameter[] param2 ={
                                   new SqlParameter("@flag",27),
                                   new SqlParameter("@TVPlayName",txtTVPlayName.Text.Trim().ToString()),
                                   new SqlParameter("@TVPlayURL",txtUrl.Text.Trim().ToString()),
                                   new SqlParameter("@MTClassID",ddlType.SelectedValue),                                  
                                   new SqlParameter("@ComeOut",txtComeOut.Text.Trim().ToString()),
                                   new SqlParameter("@Summary",txtDesc.Text.Trim().ToString()),
                                   new SqlParameter("@ImgExtension",strFileExtension),
                                   new SqlParameter("MediaSoureID",ddlMediaSource.SelectedValue),
                                   new SqlParameter("@TVPlayID",Convert.ToInt32(lblID.Text.Trim().ToString()))
                                   };           
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param2);          
        
        }
        /// <summary>
        /// 函數名稱：DeleteOldImg
        /// 函數功能：刪除原來的劇照
        /// 開發者：曹翠華
        /// 開發時間：2011/3/20 
        ///
        /// </summary>
        /// <param name="strFileExtension"></param>
        private void DeleteOldImg(string strFileExtension)
        {
            int intTVPlayID = Convert.ToInt32(lblID.Text.ToString());
            string strImgPath = "Images/TV/" + intTVPlayID + strFileExtension;

            if(fileUpload.FileName!="")
            {
                if (txtImgPath.Text.Trim().ToString() != "" && txtImgPath.Text.Trim().ToString() != strImgPath)
                {
                    File.Delete(Class.Common.GetImagePath("TVPlay")+txtImgPath.Text.Trim().ToString());
                }
            }     
        
        }       
        
    }
}

