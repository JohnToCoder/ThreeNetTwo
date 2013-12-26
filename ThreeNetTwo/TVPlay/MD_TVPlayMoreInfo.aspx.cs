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
using ThreeNetTwo.Class;

namespace ThreeNetTwo.TVPlay
{
    public partial class MD_TVPlayMoreInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               try
               {
                   if (Request["strID"] != null)
                   {
                        txtID.Text=Request["strID"].ToString();
                   }
                  
                   //記錄父頁面的頁碼索引值以備返回時使用
                   if (Request["pageIndex"] != null)
                   {
                       txtParentIndex.Text = Request["pageIndex"].ToString();
                   }                  

                    if (Session["User"] != null)
                    {
                        User objUser = new User();
                        objUser = Session["User"] as User;
                        objUser.GetRight(objUser.RoleCode, "31", this.Page);//頁面按鈕權限管控
                    }

                   //修改、刪除數據動作后執行
                   if(Request["KeyValue"]!=null)
                   {
                     //獲取電視ID
                    string strID = Request["TVPlayID"].ToString();
                    txtID.Text = strID;
                    string strKeyValue=Request["KeyValue"].ToString().Trim();
                    lblFlag.Text=strKeyValue;


                    //修改動作后設置本頁面頁碼
                    if (Request["strIndex"] != null && Request["strIndex"].ToString() != "")
                    {
                        string strIndex = Request["strIndex"];
                        Gv_TVPlaySub.PageIndex = Convert.ToInt32(strIndex);
                        //保存當前頁碼
                        txtPageIndex.Text = Gv_TVPlaySub.PageIndex.ToString();
                    }
                     //綁定修改後的信息
                    GVTVSubBind(strID);
                   }
                   // 查詢動作后信息綁定
                  else if(Request["SearchKey"]!=null)
                  {
                     string strSearchValue=Request["SearchKey"].ToString().Trim();
                     string[] ArrKeyValue=strSearchValue.Split('=');
                     DataSearchBind(ArrKeyValue[0].Trim().ToString(), ArrKeyValue[1].Trim().ToString(), ArrKeyValue[2].Trim().ToString(), ArrKeyValue[3].Trim().ToString(), ArrKeyValue[4].Trim().ToString());
                     txtID.Text = ArrKeyValue[1].Trim().ToString();
                  }
                else
                 {
                    string strID = Request["strID"].ToString();
                    GVTVSubBind(strID);
                 }
               }
                catch
               {
                
               }
            }
        }
        /// <summary>
        /// 函數名稱：GVTVSubBind
        /// 函數功能：初始化顯示分集信息
        /// 開發者：曹翠華
        /// 開發日期:2011/3/31
        /// </summary>
        private void GVTVSubBind(string strID)
        {
            SqlParameter[] param = { 
                                   
                                    new SqlParameter("@flag",32),
                                    new SqlParameter("@TVPlayID",strID),
                                    new SqlParameter("@TVPlaySubID",""),
                                   };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_TVPlay_sp]", param);

            if (dt.Rows.Count > 0)
            {
                Gv_TVPlaySub.DataSource = dt;
                Gv_TVPlaySub.DataBind();

                for (int i = 0, intRowCount = Gv_TVPlaySub.Rows.Count; i < intRowCount; i++)
                {
                    Gv_TVPlaySub.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                    Gv_TVPlaySub.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
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
                Gv_TVPlaySub.DataSource = dt;
                Gv_TVPlaySub.DataBind();
                Gv_TVPlaySub.Rows[0].Cells.Clear();
                Gv_TVPlaySub.Rows[0].Cells.Add(new TableCell());
                Gv_TVPlaySub.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                Gv_TVPlaySub.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                Gv_TVPlaySub.Rows[0].Cells[0].Style.Add("text-align", "center");
                Gv_TVPlaySub.Rows[0].Cells[0].Style.Add("border", "solid 1px #567ab2");
            }
            ViewState["dt"] = dt;        
        }
        
        /// <summary>
        /// 函數名稱：Gv_TVPlaySub_PageIndexChanging
        /// 函數功能:翻頁事件
        /// 開發人員：曹翠華
        /// 開發日期：2011/3/31
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gv_TVPlaySub_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblFlag.Text = "";
            DataTable dtbs = ViewState["dt"] as DataTable;

            Gv_TVPlaySub.PageIndex = e.NewPageIndex;

            Gv_TVPlaySub.DataSource = dtbs;
            Gv_TVPlaySub.DataBind();

            for (int i = 0, intRowCount = Gv_TVPlaySub.Rows.Count; i < intRowCount; i++)
            {

                Gv_TVPlaySub.Rows[i].Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#cdeaf2'");
                Gv_TVPlaySub.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
            txtPageIndex.Text = e.NewPageIndex.ToString();
        }
        /// <summary>
        /// 函數名稱:DataSearchBind
        /// 函數功能:綁定分集查詢后的表單信息
        /// 開發者:曹翠華
        /// 開發日期:2011/3/31
        /// </summary>
        private void DataSearchBind(string strTVsub,string strTVPlayID, string strUrl, string strComeOut, string strDesc)
        {
            try
            {               

                SqlParameter[] param ={
                                 new SqlParameter("@flag",33),                                
                                 new SqlParameter("@OrderId",strTVsub.ToString()),
                                 new SqlParameter("@TVPlayID",strTVPlayID), 
                                 new SqlParameter("@TVPlayURL",strUrl),          
                                 new SqlParameter("@ComeOut",strComeOut),
                                 new SqlParameter("@Summary",strDesc)
                                 
                             };
                
                    DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "[MD_TVPlay_sp]", param);
                    

                    if (dt.Rows.Count > 0)
                    {
                        Gv_TVPlaySub.DataSource = dt;
                        Gv_TVPlaySub.DataBind();
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
                        Gv_TVPlaySub.DataSource = dt;
                        Gv_TVPlaySub.DataBind();
                        Gv_TVPlaySub.Rows[0].Cells.Clear();
                        Gv_TVPlaySub.Rows[0].Cells.Add(new TableCell());
                        Gv_TVPlaySub.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        Gv_TVPlaySub.Rows[0].Cells[0].Text = "<font color='red'>None</font>";
                        Gv_TVPlaySub.Rows[0].Cells[0].Style.Add("text-align", "center");
                    }
                    ViewState["dt"] = dt;
                }
                catch { }            
         
        }
        /// <summary>
        /// 函數名稱:Gv_TVPlaySub_RowDataBound
        /// 函數功能:GridView 鼠標移動事件
        /// 開發者:曹翠華
        /// 開發日期:2011/3/31
        /// </summary>

        protected void Gv_TVPlaySub_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Text = "<span title=\'" + e.Row.Cells[5].Text + "\'><a href=\'" + e.Row.Cells[5].Text + "\' target=\'_blank\'>" + Common.SubString(e.Row.Cells[5].Text, 50) + "</a></span>";
                e.Row.Cells[7].Text = "<span title=\'" + e.Row.Cells[7].Text + "\' style='display:block;width:300px;'>" + Common.SubString(e.Row.Cells[7].Text, 136) + "</span>";
            }
        }

        }

    }


