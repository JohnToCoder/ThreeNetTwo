using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace ThreeNetTwo.Manage.MacRight
{
    public partial class Sys_Mac_Right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    string strType = Request["type"].ToString();

                    if (strType == "3")
                    {
                        channel.Style.Add("display", "block");
                        Channeldate.Style.Add("display", "block");
                        Movie.Style.Add("display", "none");
                        trTV.Style.Add("display", "none");

                        trMusic.Style.Add("display", "none");
                        trdlMusic.Style.Add("display", "none");
                        DropListBind();
                    }

                    if (strType == "4" || strType == "5")
                    {
                        if (strType == "4")
                        {
                            lblMovie.Text = "電影名稱";
                        }

                        if (strType == "5")
                        {
                            lblMovie.Text = "電視劇名稱";
                        }

                        channel.Style.Add("display", "none");
                        Channeldate.Style.Add("display", "none");
                        Movie.Style.Add("display", "block");
                        trTV.Style.Add("display", "block");

                        trMusic.Style.Add("display", "none");
                        trdlMusic.Style.Add("display", "none");

                    }


                    if (strType == "6" || strType == "7")
                    {
                        DropListBind1(strType);
                        if (strType == "6")
                        {
                            lblMname.Text = "所屬專輯";
                            lblMUName.Text = "音樂名稱";
                        }

                        if (strType == "7")
                        {
                            lblMname.Text = "所屬相冊";
                            lblMUName.Text = "相冊名稱";
                        }

                        channel.Style.Add("display", "none");
                        Channeldate.Style.Add("display", "none");
                        Movie.Style.Add("display", "none");
                        trTV.Style.Add("display", "none");

                        trMusic.Style.Add("display", "block");
                        trdlMusic.Style.Add("display", "block");

                    }

                    txtType.Text = strType;
                }
            }

            catch
            {

            }
        }

        private void DropListBind()
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",16)
                                 };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);

            ddlClass.DataValueField = "ChannelCode";
            ddlClass.DataTextField = "ChannelDesc";
            ddlClass.DataSource = dtb;
            ddlClass.DataBind();

            ddlClass.Items.Insert(0, "");
        }

        private void DropListBind1(string strFlag)
        {

            if (strFlag == "6")
            {
                SqlParameter[] param ={
                                     new SqlParameter("@flag",17)
                                 };
                DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);


                ddlIistClass.DataValueField = "ID";
                ddlIistClass.DataTextField = "AlbumName";
                ddlIistClass.DataSource = dtb;
                ddlIistClass.DataBind();
            }

            else
            {
                SqlParameter[] param ={
                                     new SqlParameter("@flag",18)
                                 };
                DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);


                ddlIistClass.DataValueField = "PicCatID";
                ddlIistClass.DataTextField = "PictureCataLog";
                ddlIistClass.DataSource = dtb;
                ddlIistClass.DataBind();
            }

       
            ddlIistClass.Items.Insert(0, "");
        }
        
    }
}
