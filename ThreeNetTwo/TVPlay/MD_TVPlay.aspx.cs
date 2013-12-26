using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ThreeNetTwo.Class;

namespace ThreeNetTwo.TVPlay
{
    public partial class MD_TVPlay : System.Web.UI.Page
    {
        //string strBasePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //strBasePath = Request.PhysicalApplicationPath;
            if (!IsPostBack)
            {
                try
                {
                    if (Session["User"] != null)
                    {
                        User objUser = new User();
                        objUser = Session["User"] as User;
                        objUser.GetRight(objUser.RoleCode, "22", this.Page);//頁面按鈕權限管控
                    }
                    
                    //判斷是否為修改動作
                     if (Request["KeyValue"] != null)
                     {
                         string strKeyValue = Request["KeyValue"].ToString().Trim();
                         lblFlag.Text = strKeyValue;
                         
                        
                         if (Request["strIndex"] != null && Request["strIndex"].ToString() != "")
                         {
                             string strIndex = Request["strIndex"];
                             Gv_TVPlay.PageIndex = Convert.ToInt32(strIndex);
                             //保存當前索引
                             txtPageIndex.Text = Gv_TVPlay.PageIndex.ToString();
                         }
                         GvTVPlayBind();
                     }
                       //查詢動作
                      else if(Request["SearchKey"]!=null)
                     {
                         
                         string strSearchValue = Request["SearchKey"].ToString().Trim();
                         string[] ArrKeyValue = strSearchValue.Split('=');
                         DataSearchBind(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim(), ArrKeyValue[5].Trim());
                      
                      }
                     else {
                             //從Detail頁面返回時設置頁碼索引值
                             if (Request["strPIndex"] != null && Request["strPIndex"].ToString() != "")
                             {
                                 string strPIndex = Request["strPIndex"];
                                 Gv_TVPlay.PageIndex = Convert.ToInt32(strPIndex);
                                
                                 //保存當前頁碼
                                 txtPageIndex.Text = Gv_TVPlay.PageIndex.ToString();
                             }
                              GvTVPlayBind();
                         }                   
                }

                catch { }
            }
        }

        /// <summary>
        /// 開發者：曹翠華
        /// 開發時間：2011-03-11
        /// 功能描述：綁定GvTVPlay數據
        /// </summary>
        private void GvTVPlayBind()
        {
            SqlParameter[] Paras ={
                                new SqlParameter("@flag",19)
                             };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_TVPlay_sp]", Paras);

            if (dt.Rows.Count > 0)
            {
                Gv_TVPlay.DataSource = dt;
                Gv_TVPlay.DataBind();

                for (int i = 0, intRowCount = Gv_TVPlay.Rows.Count; i < intRowCount; i++)
                {
                    Gv_TVPlay.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_TVPlay.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
                }
            }
            else
            {
                DataRow row = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                {
                    col.AllowDBNull = true;
                    row[col] = DBNull.Value;
                }
                dt.Rows.Add(row);
                Gv_TVPlay.DataSource = dt;
                Gv_TVPlay.DataBind();
                Gv_TVPlay.Rows[0].Cells.Clear();
                Gv_TVPlay.Rows[0].Cells.Add(new TableCell());
                Gv_TVPlay.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_TVPlay.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_TVPlay.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_TVPlay.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;
        }
               
       
        /// <summary>
        /// 開發者：曹翠華
        /// 開發時間：2011-03-11
        /// 功能描述：Gv_Play翻頁功能
        /// </summary>
        protected void Gv_Replace_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";
            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_TVPlay.PageIndex = e.NewPageIndex;

            Gv_TVPlay.DataSource = dtbs;
            Gv_TVPlay.DataBind();
            for (int i = 0, intRowCount = Gv_TVPlay.Rows.Count; i < intRowCount; i++)
            {
                Gv_TVPlay.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                Gv_TVPlay.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }

            txtPageIndex.Text = e.NewPageIndex.ToString();
        }

        /// <summary>
        /// 編號：MD_MD_TVPlay
        /// 函數名：Gv_TVPlay_RowDataBound
        /// 功能描述：較長字符串的省略
        /// 開發者：曹翠華
        /// 開發時間：2011-03-14
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Gv_TVPlay_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Text = "<span title=\'" + e.Row.Cells[5].Text + "\'>" + Common.SubString(e.Row.Cells[5].Text, 50) + "</span>";
                e.Row.Cells[6].Text = "<span title=\'" + e.Row.Cells[6].Text + "\'><a href=\'" + e.Row.Cells[6].Text + "\' target=\'_blank\'>" + Common.SubString(e.Row.Cells[6].Text, 50) + "</a></span>";  
                
                e.Row.Cells[9].Text = "<span title=\'" + e.Row.Cells[9].Text + "\' style='display:block;width:300px;'>"+ Common.SubString(e.Row.Cells[9].Text, 136) + "</span>";
               
            }
        }

        /// <summary>
        /// 編號：MD_MD_TVPlay
        /// 函數名：DataSearchBind
        /// 功能描述：綁定查詢后的表單信息
        /// 開發者：曹翠華
        /// 開發時間：2011-03-14
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="e"></param>
        private void DataSearchBind(string strTVPlayName, string strddlType, string strUrl, string strComeOut, string strDesc,  string strMediaSource)
        {
            SqlParameter[] param ={
                                 new SqlParameter("@flag",23),
                                 new SqlParameter("@TVPlayName",strTVPlayName),
                                 new SqlParameter("@TVPlayURL",strUrl),
                                 new SqlParameter("@MTClassID",strddlType),                                
                                 new SqlParameter("@ComeOut",strComeOut),
                                 new SqlParameter("@Summary",strDesc),
                                 new SqlParameter("@MediaSoureID",strMediaSource)
                             };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_TVPlay_sp]", param);
            if (dt.Rows.Count > 0)
            {
                Gv_TVPlay.DataSource = dt;
                Gv_TVPlay.DataBind();
            }
            else
            {
                DataRow row = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                {
                    col.AllowDBNull = true;
                    row[col] = DBNull.Value;
                }
                dt.Rows.Add(row);
                Gv_TVPlay.DataSource = dt;
                Gv_TVPlay.DataBind();
                Gv_TVPlay.Rows[0].Cells.Clear();
                Gv_TVPlay.Rows[0].Cells.Add(new TableCell());
                Gv_TVPlay.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_TVPlay.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_TVPlay.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
            ViewState["dt"] = dt;
        }        

    }
}
