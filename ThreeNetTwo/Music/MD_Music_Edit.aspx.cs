using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ThreeNetTwo.Music
{
    public partial class MD_Music_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    AllddlBind();
                    if (Request["key"] != null)
                    {
                        setValue(Request["key"].ToString());
                    }
                }
                catch { }
            }
        }          
           
        
        protected void setValue(string strKey)
        
        {
            SqlParameter[] param ={
                               new SqlParameter("@flag",35),
                               new SqlParameter("@MusicID",strKey)                               
                               };

            DataTable dbt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[dbo].[MD_Music_sp]", param);
            txtMusicName.Text = dbt.Rows[0].ItemArray[0].ToString().Trim();
            ddlType.SelectedValue = dbt.Rows[0].ItemArray[1].ToString().Trim();
            //ddlAlbum.Text = dbt.Rows[0].ItemArray[2].ToString().Trim();
            txtSinger.Text = dbt.Rows[0].ItemArray[3].ToString().Trim();
            txtComeOut.Text = Convert.ToDateTime(dbt.Rows[0].ItemArray[4].ToString().Trim()).ToString("yyyy-MM-dd");            
            txtUrl.Text = dbt.Rows[0].ItemArray[5].ToString().Trim();
            txtOrder.Text = dbt.Rows[0].ItemArray[6].ToString().Trim();

            lblID.Text = strKey;
        
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
            ddlItem.Text = "--請選擇音樂類型--";
            ddlItem.Value = "";
            ddlType.Items.Insert(0, ddlItem);  
            
            ////綁定歌曲順序
            //for (int i = 1; i <= 50; i++)
            //{
            //    ListItem ddlItems = new ListItem();
            //    ddlItems.Text = i.ToString();
            //    ddlItems.Value = i.ToString();
            //    ddlOrder.Items.Add(ddlItems);
            //}
            //ListItem ddlItems1 = new ListItem();
            //ddlItems1.Text = "--請選擇音樂順序--";
            //ddlItems1.Value = "";
            //ddlOrder.Items.Insert(0, ddlItem);  

         
            //綁定專輯名稱
            //ddlAlbum.DataSource = ds.Tables[2];
            //ddlAlbum.DataValueField = "ID";
            //ddlAlbum.DataTextField = "AlbumName";
            //ddlAlbum.DataBind();

            //ListItem ddlItem3 = new ListItem();
            //ddlItem3.Text = "--請選擇專輯名稱--";
            //ddlItem3.Value = "0";
            //ddlAlbum.Items.Insert(0, ddlItem3);    
         

        }
    }
}
