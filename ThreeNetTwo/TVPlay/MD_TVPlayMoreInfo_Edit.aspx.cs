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

namespace ThreeNetTwo.TVPlay
{
    public partial class MD_TVPlayMoreInfo_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                try
                {
                    //查詢事件
                    string strFlag=Request["flag"];
                    if(!strFlag.Equals("ins"))
                    {
                        lblTVSub.Visible = false;
                        lblUrl.Visible = false;
                        lblDesc.Visible = false;
                        lblComeOut.Visible = false;
                         
                    }
                    //修改事件
                    if (Request["key"] != null)
                    {

                        setValue(Request["key"].ToString());
                    }
                }
                catch { }
            }
           

        }

        //private void ddlBind()
        //{
        //    //綁定電視劇類型
        //    SqlParameter[] param ={
        //                             new SqlParameter("@flag",21)     
        //                         };
        //    ddlType.DataSource = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);
        //    ddlType.DataValueField = "ID";
        //    ddlType.DataTextField = "ClassDesc";
        //    ddlType.DataBind();

        //    ListItem ddlItem = new ListItem();
        //    ddlItem.Text = "--請選擇電視劇類型--";
        //    ddlItem.Value = "";
        //    ddlType.Items.Insert(0, ddlItem);        

        //}

        /// <summary>
        /// 函數名稱:setValue
        /// 函數功能:點擊修改按鈕時內容自動填充到頁面
        /// 開發者:曹翠華
        /// 開發日期:2011/3/31
        /// </summary>
        /// <param name="strKey"></param>
        protected void setValue(string strKey)
        {

            SqlParameter[] param ={
                                 new SqlParameter("@flag",39),
                                 new SqlParameter("@TVPlaySubID",strKey)
                             };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_TVPlay_sp]", param);

            txtTVsub.Text = dtb.Rows[0].ItemArray[0].ToString().Trim();
            txtUrl.Text = dtb.Rows[0].ItemArray[1].ToString().Trim();
            txtComeOut.Text =dtb.Rows[0].ItemArray[2].ToString().Trim();
            txtDesc.Text = dtb.Rows[0].ItemArray[3].ToString().Trim();         

            lblID.Text = strKey;//獲取修改數據的ID 

        }     
    }
}
