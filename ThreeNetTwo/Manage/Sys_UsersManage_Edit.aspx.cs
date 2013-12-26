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
 

namespace ThreeNetTwo.Manage
{
    public partial class Sys_UsersManage_Edit : System.Web.UI.Page
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
                        trfileUpload.Visible = false;
                        trPassword.Visible = false;
                        trcfPassword.Visible = false;
                        txtSearchflag.Text = strFlag;
                    }
                    if (Request["key"] != null)
                    {
                        setValue(Request["key"].ToString());
                    }

                    DDLrole_Bind();
                }
                catch
                {

                }

            }
        }

        /// <summary>
        /// 作者：劉洪彬
        /// 時間：2011-03-15
        /// 功能描述：綁定圖片類型下拉菜單數據
        /// </summary>
        public void DDLrole_Bind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",7)     
                                 };
            ddlrole.DataSource = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);
            ddlrole.DataValueField = "ID";
            ddlrole.DataTextField = "RoleDesc";
            ddlrole.DataBind();

            ListItem ddlItem = new ListItem();
            ddlItem.Text = "--請選角色--";
            ddlItem.Value = "";
            ddlrole.Items.Insert(0, ddlItem);
        }

        /// <summary>
        /// 修改頁面時初始化頁面
        /// Edit By tanyi 2011.3.16
        /// </summary>
        /// <param name="strKey"></param>
        private void setValue(string strKey)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",9),
                                 new SqlParameter("@ID",strKey)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);
            txtUserCode.Text = dtb.Rows[0][0].ToString();
            txtUserName.Text = dtb.Rows[0][1].ToString();
            txtTEL.Text = dtb.Rows[0][3].ToString();
            txtEmail.Text = dtb.Rows[0][4].ToString();
            txtMobile.Text = dtb.Rows[0][5].ToString();
            ddlrole.SelectedValue = dtb.Rows[0][6].ToString();
            txtIP.Text = dtb.Rows[0][8].ToString();
            lblID.Text = strKey;//修改者： 沈譚義 獲取修改數據的ID 2011/3/16
            lblimgpath.Text=dtb.Rows[0][2].ToString();
        }



        /// <summary>
        /// 作者：劉洪彬
        /// 時間：2011-03-15
        /// 功能描述：新增用戶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                User objUser = new User();
                objUser = HttpContext.Current.Session["User"] as User;
                string strFileExtension = "";//劇照的後綴名
                if (fileUpload.FileName != "")
                {
                   strFileExtension = System.IO.Path.GetExtension(fileUpload.FileName);
                }
                if (lblID.Text.ToString() == "")
                {
                  
                       
                        SqlParameter[] param ={
                                           new SqlParameter("@flag",4),
                                           new SqlParameter("@UserCode",txtUserCode.Text.Trim().ToString()),
                                           new SqlParameter("@UserName",txtUserName.Text.Trim().ToString()),
                                           new SqlParameter("@Password",ObjCon.Security.HashTextMD5(txtPassword.Text.Trim().ToString())),
                                           new SqlParameter("@ImgExtension",strFileExtension),
                                           new SqlParameter("@TEL",txtTEL.Text.Trim().ToString()),
                                           new SqlParameter("@Email",txtEmail.Text.Trim().ToString()),
                                           new SqlParameter("@Mobile",txtMobile.Text.Trim().ToString()),
                                           new SqlParameter("@RoleID",ddlrole.SelectedValue.Trim()),
                                           new SqlParameter("@IP",txtIP.Text.Trim().ToString()),
                                           new SqlParameter("@Creator",objUser.UserCode)                               
                              };
                        
                        ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);
                        if (fileUpload.FileName != "")
                        {
                            int intID = Class.Users.GetUsersID(txtUserCode.Text.Trim().ToString());
                            string strfilepath = Server.MapPath("../Manage/PicFile/") + intID + strFileExtension;
                            fileUpload.PostedFile.SaveAs(strfilepath);
                        }
                        string strPostUrl = "../Manage/Sys_UsersManage.aspx?KeyValue=Add&t=" + DateTime.Now.ToFileTime();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");
                   
                }
                else
                {
                    if (txtPassword.Text.Trim()=="" && fileUpload.FileName== "")
                    {

                        SqlParameter[] param ={
                                           new SqlParameter("@flag",11),
                                           new SqlParameter("@ID",lblID.Text.Trim()),
                                           new SqlParameter("@UserCode",txtUserCode.Text.Trim().ToString()),
                                           new SqlParameter("@UserName",txtUserName.Text.Trim().ToString()),
                                           new SqlParameter("@TEL",txtTEL.Text.Trim().ToString()),
                                           new SqlParameter("@Email",txtEmail.Text.Trim().ToString()),
                                           new SqlParameter("@Mobile",txtMobile.Text.Trim().ToString()),
                                           new SqlParameter("@RoleID",ddlrole.SelectedValue.Trim()),
                                           new SqlParameter("@IP",txtIP.Text.Trim().ToString()),
                                           new SqlParameter("@Editor",objUser.UserCode )                               
                              };

                        ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);

                      


                    }
                    else if (txtPassword.Text.Trim()==""&& fileUpload.FileName!="")
                    {
                        SqlParameter[] param ={
                                           new SqlParameter("@flag",5),
                                           new SqlParameter("@ID",lblID.Text.Trim()),
                                           new SqlParameter("@UserCode",txtUserCode.Text.Trim().ToString()),
                                           new SqlParameter("@UserName",txtUserName.Text.Trim().ToString()),
                                           new SqlParameter("@ImgExtension",strFileExtension),
                                           new SqlParameter("@TEL",txtTEL.Text.Trim().ToString()),
                                           new SqlParameter("@Email",txtEmail.Text.Trim().ToString()),
                                           new SqlParameter("@Mobile",txtMobile.Text.Trim().ToString()),
                                           new SqlParameter("@RoleID",ddlrole.SelectedValue.Trim()),
                                           new SqlParameter("@IP",txtIP.Text.Trim().ToString()),
                                           new SqlParameter("@Editor",objUser.UserCode )                                
                              };

                        ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);
                        int intID =Convert.ToInt32(lblID.Text.Trim().ToString());
                        string strfilepath = Server.MapPath("../Manage/PicFile/") + intID + strFileExtension;
                        fileUpload.PostedFile.SaveAs(strfilepath);
                        DeleteOldImg(strfilepath);
                    }
                    else if (txtPassword.Text.Trim()!=""&& fileUpload.FileName== "")
                    {


                        SqlParameter[] param ={
                                           new SqlParameter("@flag",5),
                                           new SqlParameter("@ID",lblID.Text),
                                           new SqlParameter("@UserCode",txtUserCode.Text.Trim().ToString()),
                                           new SqlParameter("@UserName",txtUserName.Text.Trim().ToString()),
                                           new SqlParameter("@Password",ObjCon.Security.HashTextMD5(txtPassword.Text.Trim().ToString())),
                                           new SqlParameter("@TEL",txtTEL.Text.Trim().ToString()),
                                           new SqlParameter("@Email",txtEmail.Text.Trim().ToString()),
                                           new SqlParameter("@Mobile",txtMobile.Text.Trim().ToString()),
                                           new SqlParameter("@RoleID",ddlrole.SelectedValue.Trim()),
                                           new SqlParameter("@IP",txtIP.Text.Trim().ToString()), 
                                           new SqlParameter("@Editor",objUser.UserCode )                              
                              };

                        ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);

                    }
                    else 
                    {
                        SqlParameter[] param ={
                                           new SqlParameter("@flag",11),
                                           new SqlParameter("@ID",lblID.Text),
                                           new SqlParameter("@UserCode",txtUserCode.Text.Trim().ToString()),
                                           new SqlParameter("@UserName",txtUserName.Text.Trim().ToString()),
                                           new SqlParameter("@Password",ObjCon.Security.HashTextMD5(txtPassword.Text.Trim().ToString())),
                                           new SqlParameter("@ImgExtension",strFileExtension),
                                           new SqlParameter("@TEL",txtTEL.Text.Trim().ToString()),
                                           new SqlParameter("@Email",txtEmail.Text.Trim().ToString()),
                                           new SqlParameter("@Mobile",txtMobile.Text.Trim().ToString()),
                                           new SqlParameter("@RoleID",ddlrole.SelectedValue.Trim()),
                                           new SqlParameter("@IP",txtIP.Text.Trim().ToString()), 
                                           new SqlParameter("@Editor",objUser.UserCode )                               
                              };

                        ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "Sys_UsersManage_sp", param);
                        int intID =Convert.ToInt32(lblID.Text.Trim().ToString());
                        string strfilepath = Server.MapPath("../Manage/PicFile/") + intID + strFileExtension;
                        fileUpload.PostedFile.SaveAs(strfilepath);
                        DeleteOldImg(strfilepath);
                       
                    }
                    string strPostUrl = "../Manage/Sys_UsersManage.aspx?KeyValue=Update&t=" + DateTime.Now.ToFileTime();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script defer>startRequest('" + strPostUrl + "');</script>");

                }
            }

            catch
            {


            }
        }

        /// <summary>
        /// 如果修改的圖片後綴與原圖片不同則需要刪除原先的圖片
        /// Edit By tanyi 2011.3.21
        /// </summary>
        /// <param name="strFileExtension"></param>
        private void DeleteOldImg(string strfilepath)
        {
            if (lblimgpath.Text.ToString() != "")
            {
                string strImgPath = Server.MapPath("../Manage/PicFile/") + lblimgpath.Text.ToString();
                //刪除原來存在的圖片 Edit By tanyi 2011.03.17
                if (fileUpload.FileName != "")
                {
                    //如果文件名稱不一樣則刪除原來的圖片 Edit By Tanyi 2011-3-17
                    if (strfilepath != strImgPath)
                    {
                        File.Delete(strImgPath);
                    }
                }

            }
        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    
    }
}
