using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;


namespace ThreeNetTwo
{
    public class User
    {
        private string id;
        private string userCode;
        private string userName;
        private string password;
        private string imgPath;
        private string userTEL;
        private string userEmail;
        private string userMobile;
        private string roleCode;
        private string userIP;

        /// <summary>
        /// 用戶ID
        /// </summary>
        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }


        /// <summary>
        /// 用戶Code
        /// </summary>
        public string UserCode
        {
            set
            {
                userCode = value;
            }
            get
            {
                return userCode;
            }
        }

        /// <summary>
        /// 用戶名稱
        /// </summary>
        public string UserName
        {
            set
            {
                userName = value;
            }
            get
            {
                return userName;
            }
        }


        /// <summary>
        /// 用戶密碼
        /// </summary>
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }

        /// <summary>
        /// 用戶圖片地址
        /// </summary>
        public string ImgPath
        {
            set
            {
                imgPath = value;
            }
            get
            {
                return imgPath;
            }
        }

        /// <summary>
        /// 用戶電話
        /// </summary>
        public string UserTEL
        {
            set
            {
                userTEL = value;
            }
            get
            {
                return userTEL;
            }
        }

        /// <summary>
        /// 用戶Email
        /// </summary>
        public string UserEmail
        {
            set
            {
                userEmail = value;
            }
            get
            {
                return userEmail;
            }
        }

        /// <summary>
        /// 用戶手機
        /// </summary>
        public string UserMobile
        {
            set
            {
                userMobile = value;
            }
            get
            {
                return userMobile;
            }
        }

        /// <summary>
        /// 角色代碼
        /// </summary>
        public string RoleCode
        {
            set
            {
                roleCode = value;
            }
            get
            {
                return roleCode;
            }
        }

        /// <summary>
        /// 用戶IP
        /// </summary>
        public string UserIP
        {
            set
            {
                userIP = value;
            }
            get
            {
                return userIP;
            }
        }

        public void GetRight(string strRoleCode, string strParentId, Page page)
        {
            initVisiable(page);
            DataTable dtb = new DataTable();
            SqlParameter[] param ={
                                 new SqlParameter("@flag",2),
                                 new SqlParameter("@RoleCode",strRoleCode),
                                 new SqlParameter("@ParentMenuid",strParentId)
                             };
            dtb = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "Sys_Menu_sp", param);
            if (dtb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in dtb.Rows)
            {
                if (page.FindControl(dr.ItemArray[5].ToString()) != null && dr.ItemArray[1].ToString().Trim() == "_0")
                {
                    page.FindControl(dr.ItemArray[5].ToString()).Visible = true;
                }

                if (page.FindControl(dr.ItemArray[5].ToString()) != null && dr.ItemArray[1].ToString().Trim() == "_1")
                {
                    page.FindControl(dr.ItemArray[5].ToString()).Visible = true;
                }

                if (page.FindControl(dr.ItemArray[5].ToString()) != null && dr.ItemArray[1].ToString().Trim() == "_2")
                {
                    page.FindControl(dr.ItemArray[5].ToString()).Visible = true;
                }

                if (page.FindControl(dr.ItemArray[5].ToString()) != null && dr.ItemArray[1].ToString().Trim() == "_3")
                {
                    page.FindControl(dr.ItemArray[5].ToString()).Visible = true;
                }

                if (page.FindControl(dr.ItemArray[5].ToString()) != null && dr.ItemArray[1].ToString().Trim() == "_4")
                {
                    page.FindControl(dr.ItemArray[5].ToString()).Visible = true;
                }

            }
        }

        private void initVisiable(Page page)
        {
            if (page.FindControl("btnSel") != null)
            {
                page.FindControl("btnSel").Visible = false;
            }

            if (page.FindControl("btnIns") != null)
            {
                page.FindControl("btnIns").Visible = false;
            }

            if (page.FindControl("btnUpd") != null)
            {
                page.FindControl("btnUpd").Visible = false;
            }
            if (page.FindControl("btnDel") != null)
            {
                page.FindControl("btnDel").Visible = false;
            }
            if (page.FindControl("btnset") != null)
            {
                page.FindControl("btnset").Visible = false;
            }
        }
    }
}
