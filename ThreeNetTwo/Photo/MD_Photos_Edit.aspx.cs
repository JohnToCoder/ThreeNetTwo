using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ThreeNetTwo.Photo
{
    public partial class MD_Photos_Ins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string strFlag = Request["flag"];

                    DDLPictureCatalog_Bind();

                    if (!strFlag.Equals("ins"))
                    {
                        trUpload.Visible = false;
                    }

                    if (!strFlag.Equals("myphoto"))
                    {
                        //我的相冊查詢條件。默認不顯示。
                        trUserCode.Visible = false;
                    }

                    if(!strFlag.Equals("upd"))
                    {
                        ShowImage.Visible = false;
                    }
                    else
                    {
                        string[] paras = Request["KeyValue"].Split('^');
                        //顯示圖片
                        imgBig.ImageUrl = paras[3];
                        //綁定圖片其他信息
                        ddlPictureCatalog.Items.FindByText(paras[2]).Selected = true ;
                        txtImageName.Text = paras[1];
                        imgID.Text = paras[0];
                    }

                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 作者：胡貴
        /// 時間：2011-03-15
        /// 功能描述：綁定圖片類型下拉菜單數據
        /// </summary>
        public void DDLPictureCatalog_Bind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",10)     
                                 };
            ddlPictureCatalog.DataSource = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "User_Photo_sp", param);
            ddlPictureCatalog.DataValueField = "PCID";
            ddlPictureCatalog.DataTextField = "PCName";
            ddlPictureCatalog.DataBind();

            ListItem ddlItem = new ListItem();
            ddlItem.Text = "--請選擇圖片類型--";
            ddlItem.Value = "";
            ddlPictureCatalog.Items.Insert(0, ddlItem);
        }

        /// <summary>
        /// 函數名稱：AddPhoto        
        /// 函數功能：添加相冊
        /// 開發者：胡貴
        /// </summary>
        /// <param name="strFileExtension"></param>
        /// <param name="strFlag"></param>
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            //目標圖片所在的路徑
            string strImgPaths = Class.Common.GetImagePath("Photo")+imgPath.Text.ToString();
            fileUpload.PostedFile.SaveAs(strImgPaths);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + "../Photo/MD_Photos.aspx?KeyValue=Add" + "');</script>");
        }
    }
}
