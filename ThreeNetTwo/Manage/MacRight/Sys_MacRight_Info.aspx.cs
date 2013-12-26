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
    public partial class Sys_MacRight_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string strId = Request["Mid"].ToString();
                    string strMacValue = Request["mac"].ToString();
                    string strRoleID = Request["MacId"].ToString();

                    txtRole.Text = strRoleID;
                    setValue(strId);
                    GetProgramme(strRoleID);
                    GetMovieAndTvplay(strRoleID);
                    getMusicAndphoto(strRoleID);
                }
            }
            catch
            {
            }

        }
        private void setValue(string strMacId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",12),
                                     new SqlParameter("@MacId",strMacId)
                                 };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_MAC_sp]", param);

            txtMac.Text = dtb.Rows[0].ItemArray[0].ToString();
            txtName.Text = dtb.Rows[0].ItemArray[1].ToString();
            txtUserId.Text = dtb.Rows[0].ItemArray[2].ToString();
            txtSex.Text = dtb.Rows[0].ItemArray[3].ToString();
        }


        private void GetProgramme(string strRoleId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",7),
                                     new SqlParameter("@MacRoleId",strRoleId),
                                     new SqlParameter("@DoubLeClick","1")
                                      
                                 };
            DataTable dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[Sys_MacRight_sp]", param);

            string strHtml = "";

            strHtml += "<table width='100%' height='100%' border='0' cellpadding='0' cellspacing='0'>";
            strHtml += "<tr><td style='font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權頻道</td>" +
                "<td style='font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權時間</td></tr>";
            if (dtb.Rows.Count > 0)
            {
                foreach (DataRow row in dtb.Rows)
                {
                    strHtml += "<tr><td style='width:200px' class='setTBorder'>" + row.ItemArray[0].ToString() + "</td>" +
                        "<td style='width:180px;'class='setTBorder'>" + row.ItemArray[2].ToString() + "</td></tr>";
                }

                strHtml += "<tr style='width:100%'><td align='right' colspan='2'><span class='more' id='moreProGramme'><img alt='' src='../../images/more.png' /></span></td></tr>";
            }
            else
            {
                strHtml += "<tr style='width:100%'><td  colspan='2' style='padding-right:8px'  align='center'>none</td></tr>";
            }


            strHtml += "</table>";
            programme.InnerHtml = strHtml;

        }

        private void GetMovieAndTvplay(string strRoleId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",8),
                                     new SqlParameter("@MacRoleId",strRoleId),
                                     new SqlParameter("@DoubLeClick","1")
                                 };
            DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.StoredProcedure, "[Sys_MacRight_sp]", param);

            string strHtml = "";

            string strHtmlTv = "";

            strHtml += "<table width='100%' height='100%' border='0' cellpadding='0' cellspacing='0'>";
            strHtml += "<tr><td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權電影</td>" +
             "<td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權時間</td></tr>";

            strHtmlTv += "<table width='100%' height='100%' border='0' cellpadding='0' cellspacing='0'>";
            strHtmlTv +="<tr><td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權電視劇</td>" +
                "<td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權時間</td></tr>";


            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    strHtml += "<tr><td style='width:200px' class='setTBorder'>" + row.ItemArray[0].ToString() + "</td>" +
                        "<td style='width:200x;'class='setTBorder'>" + row.ItemArray[2].ToString() + "</td></tr>";
                }

                strHtml += "<tr style='width:100%'><td align='right' colspan='2' ><span class='more' id='moreMovie'><img alt='' src='../../images/more.png' /></span></td></tr>";

            }
            else
            {
                strHtml += "<tr><td style='width:400px' colspan='2' align='center'>none</td></tr>";
            }

            if (ds.Tables[1].Rows.Count > 0)
            {

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    strHtmlTv += "<tr><td style='width:200px'>" + row.ItemArray[2].ToString() + "</td>" +
                    "<td style='width:200px'>" + row.ItemArray[4].ToString() + "</td></tr>";
                }

                strHtmlTv += "<tr style='width:100%'><td align='right' colspan='2'><span class='more' id='moreTvplay'><img alt='' src='../../images/more.png' /></span></td></tr>";
            }
            else
            {
                strHtmlTv += "<tr><td style='width:400px' colspan='2' align='center'>none</td></tr>";
            }

            strHtml += "</table>";
            strHtmlTv += "</table>";

            movie.InnerHtml = strHtml;
            play.InnerHtml = strHtmlTv;
        }


        private void getMusicAndphoto(string strRoleId)
        {
            SqlParameter[] param ={
                                     new SqlParameter("@flag",9),
                                     new SqlParameter("@MacRoleId",strRoleId),
                                     new SqlParameter("@DoubLeClick","1")
                                 };
            DataSet ds = ObjCon.MSSQL.ExectuteDataSet(CommandType.StoredProcedure, "[Sys_MacRight_sp]", param);

            string strHtml = "";

            string strHtmlPhoto = "";

            strHtml += "<table width='100%' height='100%' border='0' cellpadding='0' cellspacing='0'>";
            strHtml += "<tr><td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>所屬專輯</td>" +
                "<td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權音樂</td>"+
             "<td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權時間</td></tr>";

            strHtmlPhoto += "<table width='100%' height='100%' border='0' cellpadding='0' cellspacing='0'>";
            strHtmlPhoto += "<tr><td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>所屬相冊</td>" +
                 "<td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權相冊</td>" +
                "<td style='width:200px;font-weight:bold;background-color:#d1ecfc;' class='setTBorder'>授權時間</td></tr>";


            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    strHtml += "<tr><td style='width:200px' class='setTBorder'>" + row.ItemArray[3].ToString() + "</td>" +
                         "<td style='width:180px;'class='setTBorder'>" + row.ItemArray[1].ToString() + "</td>"+
                        "<td style='width:180px;'class='setTBorder'>" + row.ItemArray[4].ToString() + "</td></tr>";
                }

                strHtml += "<tr style='width:100%'><td align='right' colspan='3'><span class='more' id='moreMusic'><img alt='' src='../../images/more.png' /></span></td></tr>";
            }
            else
            {
                strHtml += "<tr><td style='width:400px' colspan='3' align='center'>none</td></tr>";
            }

            if (ds.Tables[1].Rows.Count > 0)
            {

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    strHtmlPhoto += "<tr><td style='width:200px' class='setTBorder'>" + row.ItemArray[1].ToString() + "</td>" +
                         "<td style='width:180px;'class='setTBorder'>" + row.ItemArray[2].ToString() + "</td>"+
                        "<td style='width:180px;'class='setTBorder'>" + row.ItemArray[3].ToString() + "</td></tr>";
                }

                strHtmlPhoto += "<tr style='width:100%'><td align='right' colspan='3'><span class='more' id='morePhoto'><img alt='' src='../../images/more.png' /></span></td></tr>";
            }
            else
            {
                strHtmlPhoto += "<tr><td style='width:400px' colspan='3' align='center'>none</td></tr>";
            }

            strHtml += "</table>";
            strHtmlPhoto += "</table>";

            music.InnerHtml = strHtml;
            photo.InnerHtml = strHtmlPhoto;
        }

    }
}
