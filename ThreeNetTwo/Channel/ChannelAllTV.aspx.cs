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
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ThreeNetTwo.Channel
{
    public partial class ChannelAllTV : System.Web.UI.Page
    {
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        /// <summary>
        /// 開發人：鄧運強
        /// 開發時間：2010-12-21
        /// 功能：播放頻道 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            FlushMemory();
            if (!IsPostBack)
            {

                tbCurrentChannel.Text = Request["ID"].ToString().Trim();
                //tbCurrentChannel.Text = "3";
                ViewState["strKey"] = "";
                ViewState["strVolumeBar"] = "";
                ViewState["strProgramList"] = "";
                ViewState["strIP"] = GetUserIP();
                ViewState["dtChannelID"] = initChannelID();
                getChannelID((DataTable)ViewState["dtChannelID"]);
                string strChannel = getChannelUrl(tbCurrentChannel.Text).Rows[0]["ChannelURL"].ToString();
                tbcurrentVolume.Text = getVolume(tbCurrentChannel.Text, ViewState["strIP"].ToString());

                string strScript = "";
                strScript = "<OBJECT id='MediaPlayer' width='100%' height='100%' style='position:relative;top:0;left:0;'";
                strScript += "classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95'";
                strScript += "codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,4,05,0809'";
                strScript += "standby='Loading Microsoft Windows Media Player components...' type='application/x-oleobject'>";
                strScript += "<param name='fileName' value='" + strChannel + "'>";
                strScript += "<param name='uiMode' value='none'/>";
                strScript += "<param name='animationatStart' value='true'>";
                strScript += "<param name='AutoSize' value= '0'> ";
                strScript += "<param name='DisplaySize' value= '3'> ";
                strScript += "<param name='transparentatStart' value='false'>";
                strScript += "<param name='autoStart' value='true'>";
                strScript += "<param name='showControls' value='false'>";
                strScript += "<param name='loop' value='false'>";
                strScript += "<param name='Enabled' value='false'>";
                strScript += "<param name='Volume' value=-500>";
                strScript += "<EMBED type='application/x-mplayer2'";
                strScript += "pluginspage='http://microsoft.com/windows/mediaplayer/en/download/'";
                strScript += "id='mediaPlayer' name='mediaPlayer' displaysize='4' autosize='-1' ";
                strScript += "bgcolor='darkblue' showcontrols='0' showtracker='0'";
                strScript += "showdisplay='0' showstatusbar='0' videoborder3d='-1' ";
                strScript += "width='240' height='180'";
                strScript += "src='" + strChannel + "' autostart='true' designtimesp='5311' loop='false'";
                strScript += " name= 'NSOPlay '";
                strScript += "width= '100%' ";
                strScript += "height= '100% '";
                strScript += "DefaultFrame= 'content '";
                strScript += "AnimationAtStart= '-1 '";
                strScript += "AutoRewind= '-1 '";
                strScript += "AutoStart= '-1 '";
                strScript += "Autosize= '-1 '";
                strScript += "ControlType= '-1 '";
                strScript += "DisplaySize= '10'";
                strScript += "ShowAudioControls= '-1 '";
                strScript += "ShowControls= '-1 '";
                strScript += "Enabled= '-1 '";
                strScript += "ShowDisplay= '-1 '";
                strScript += "ShowGotoBar= '-1 '";
                strScript += "ShowPositionControls= '-1 '";
                strScript += "ShowStatusBar= '-1 '";
                strScript += "ShowTracker= '-1 '";
                strScript += " TransparentAtStart= '-1 '";
                strScript += ">";
                strScript += "</EMBED>";
                strScript += "</OBJECT>";

                ViewState["strKey"] = strScript;

                string strVolumnBar = "";
                for (int i = 0; i <= 10; i++)
                {
                    if (i == 10)
                    {
                        strVolumnBar += "<td><div id='VolumnBar" + i + "' class='VolumnBar' style='border-right:solid 1px #f79646;' onclick='javascript:setVolume(" + i + ");'></div></td>";
                    }
                    else
                    {
                        strVolumnBar += "<td><div id='VolumnBar" + i + "' class='VolumnBar' onclick='javascript:setVolume(" + i + ");'></div></td>";
                    }
                }
                ViewState["strVolumeBar"] = strVolumnBar;

                string strProgramList = "";
                DataTable dtpl = getProgramList(tbCurrentChannel.Text);
                strProgramList += "<table>";
                if (dtpl.Rows.Count > 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            if (dtpl.Rows[i]["ProgramName"].ToString().Length > 15)
                            {
                                strProgramList += "<tr><td rowspan=2 style='padding-right:20px;'>" + dtpl.Rows[i]["ChannelDesc"].ToString() + "</td><td>" + dtpl.Rows[i]["PlayingTime"].ToString() + "</td><td>" + dtpl.Rows[i]["ProgramName"].ToString().Substring(0, 15) + "...</td></tr>";
                            }
                            else
                            {
                                strProgramList += "<tr><td rowspan=2 style='padding-right:20px;'>" + dtpl.Rows[i]["ChannelDesc"].ToString() + "</td><td>" + dtpl.Rows[i]["PlayingTime"].ToString() + "</td><td>" + dtpl.Rows[i]["ProgramName"].ToString() + "</td></tr>";
                            }
                        }
                        else
                        {
                            if (dtpl.Rows[i]["ProgramName"].ToString().Length > 15)
                            {
                                strProgramList += "<tr><td>" + dtpl.Rows[i]["PlayingTime"].ToString() + "</td><td>" + dtpl.Rows[i]["ProgramName"].ToString().Substring(0, 15) + "...</td></tr>";
                            }
                            else
                            {
                                strProgramList += "<tr><td>" + dtpl.Rows[i]["PlayingTime"].ToString() + "</td><td>" + dtpl.Rows[i]["ProgramName"].ToString() + "</td></tr>";
                            }
                        }
                    }
                }
                else
                {
                    strProgramList += "<tr><td>" + getChannelUrl(tbCurrentChannel.Text).Rows[0]["ChannelDesc"].ToString() + "</td><td>無節目</td></tr>";
                }
                strProgramList += "</table>";
                ViewState["strProgramList"] = strProgramList;
            }
        }

        /// <summary>
        /// 清理内存
        /// </summary>
        public static void FlushMemory()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        /// <summary>
        /// 開發人：Charles
        /// 開發時間：2010-12-22
        /// 功能：獲取頻道影像地址
        /// </summary>
        /// <param name="ChannelID"></param>
        protected DataTable getChannelUrl(string ChannelID)
        {
            SqlParameter[] param ={
                                   new SqlParameter("@flag",8), 
                                   new SqlParameter("@ChannelID",ChannelID)
                                 };

            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_Channels_sp", param);
            return dt;
        }

        /// <summary>
        /// 開發人：Charles
        /// 開發時間：2010-12-22
        /// 功能：獲取節目音量
        /// </summary>
        /// <param name="ChannelID"></param>
        /// <param name="IP"></param>
        protected string getVolume(string ChannelID, string IP)
        {
            SqlParameter[] param ={
                                   new SqlParameter("@flag",5), 
                                   new SqlParameter("@ChannelID",ChannelID),
                                   new SqlParameter("@Ip",IP)
                                 };

            DataTable dtbl = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "User_Volum_sp", param);
            return dtbl.Rows[0]["volum"].ToString();
        }

        /// <summary>
        /// 開發人：Charles
        /// 開發時間：2010-12-22
        /// 功能：儲存節目音量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btsaveVolume_Click(object sender, EventArgs e)
        {
            SqlParameter[] param ={
                                   new SqlParameter("@flag",4), 
                                   new SqlParameter("@ChannelID",Int32.Parse(tbCurrentChannel.Text)),
                                   new SqlParameter("@Volum",Int32.Parse(tbcurrentVolume.Text)),
                                   new SqlParameter("@Ip",ViewState["strIP"].ToString())
                                 };
            ObjCon.MSSQL.ExecuteNonQuery(CommandType.StoredProcedure, "User_Volum_sp", param);
        }

        /// <summary>
        /// 開發人：Charles
        /// 開發時間：2010-12-22
        /// 功能：取得換臺後節目表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btgetProgramList_Click(object sender, EventArgs e)
        {
            getChannelID((DataTable)ViewState["dtChannelID"]);
            string strChannel = getChannelUrl(tbCurrentChannel.Text).Rows[0]["ChannelURL"].ToString();
            tbcurrentVolume.Text = getVolume(tbCurrentChannel.Text, ViewState["strIP"].ToString());
            string strrefreshVolume = "";
            strrefreshVolume += "currentVolume = " + tbcurrentVolume.Text + ";setVolumebarColor(currentVolume);controlVolume(currentVolume);";
            strrefreshVolume += "document.getElementById('MediaPlayer').stop();";
            if (strChannel != "" && strChannel != null)
            {
                strrefreshVolume += "document.getElementById('MediaPlayer').fileName = '" + strChannel + "';";
                strrefreshVolume += "document.getElementById('MediaPlayer').play();";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "refreshVolume", strrefreshVolume, true);
            string strProgramList = "";
            DataTable dtpl = getProgramList(tbCurrentChannel.Text);
            strProgramList += "<table>";
            if (dtpl.Rows.Count > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        if (dtpl.Rows[i]["ProgramName"].ToString().Length > 15)
                        {
                            strProgramList += "<tr><td rowspan=2 style='padding-right:20px;'>" + dtpl.Rows[i]["ChannelDesc"].ToString() + "</td><td>" + dtpl.Rows[i]["PlayingTime"].ToString() + "</td><td>" + dtpl.Rows[i]["ProgramName"].ToString().Substring(0, 15) + "...</td></tr>";
                        }
                        else
                        {
                            strProgramList += "<tr><td rowspan=2 style='padding-right:20px;'>" + dtpl.Rows[i]["ChannelDesc"].ToString() + "</td><td>" + dtpl.Rows[i]["PlayingTime"].ToString() + "</td><td>" + dtpl.Rows[i]["ProgramName"].ToString() + "</td></tr>";
                        }
                    }
                    else
                    {
                        if (dtpl.Rows[i]["ProgramName"].ToString().Length > 15)
                        {
                            strProgramList += "<tr><td>" + dtpl.Rows[i]["PlayingTime"].ToString() + "</td><td>" + dtpl.Rows[i]["ProgramName"].ToString().Substring(0, 15) + "...</td></tr>";
                        }
                        else
                        {
                            strProgramList += "<tr><td>" + dtpl.Rows[i]["PlayingTime"].ToString() + "</td><td>" + dtpl.Rows[i]["ProgramName"].ToString() + "</td></tr>";
                        }
                    }
                }
            }
            else
            {
                strProgramList += "<tr><td>" + getChannelUrl(tbCurrentChannel.Text).Rows[0]["ChannelDesc"].ToString() + "</td><td>無節目</tr></td>";
            }
            strProgramList += "</table>";
            ViewState["strProgramList"] = strProgramList;
        }

        /// <summary>
        /// 開發人：Roni
        /// 開發時間：2010-12-22
        /// 功能：獲取節目列表
        /// </summary>
        /// <param name="intChannelID"></param>
        protected DataTable getProgramList(string ChannelID)
        {
            SqlParameter[] param ={
                                   new SqlParameter("@flag",3),
                                   new SqlParameter("@ChannelID",Int32.Parse(ChannelID))
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_Channels_sp", param);
            return dt;
        }

        /// <summary>
        /// 開發人：Charles
        /// 開發時間：2010-12-22
        /// 功能：初始化節目ID
        /// </summary>
        protected DataTable initChannelID()
        {
            SqlParameter[] param ={
                                   new SqlParameter("@flag",15)
                                 };
            DataTable dt = ObjCon.MSSQL.ExectuteDataTable(CommandType.StoredProcedure, "MD_Channels_sp", param);
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "tempID";
            dc1.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(dc1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["tempID"] = i.ToString();
            }

            return dt;
        }

        /// <summary>
        /// 開發人：Charles
        /// 開發時間：2010-12-22
        /// 功能：獲取節目ID
        /// </summary>
        /// <param name="dt"></param>
        protected void getChannelID(DataTable dt)
        {
            int flag = -1;
            tbDownChannel.Text = "-1";
            tbUpChannel.Text = "-1";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ID"].ToString() == tbCurrentChannel.Text)
                {
                    flag = i;
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (flag > 0 && Int32.Parse(dt.Rows[i]["tempID"].ToString()) == flag - 1)
                {
                    tbUpChannel.Text = dt.Rows[i]["ID"].ToString();
                }
                if (flag < dt.Rows.Count && Int32.Parse(dt.Rows[i]["tempID"].ToString()) == flag + 1)
                {
                    tbDownChannel.Text = dt.Rows[i]["ID"].ToString();
                }
            }
        }

        /// <summary>
        /// 編號:User_006
        /// 函數名： GetUserIP
        /// 函數功能：獲取登錄者IP  
        /// 開發者：沈譚義
        /// 開發日期：2010-10-14
        /// 修改者：
        /// 修改日期：
        ///</summary>
        public string GetUserIP()
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ip == null || ip.Length == 0 || ip.ToLower().IndexOf("unknown") > -1)
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                if (ip.IndexOf(',') >= -1)
                {
                    ip = ip.Substring(0, ip.IndexOf(','));
                }
                if (ip.IndexOf(';') > -1)
                {
                    ip = ip.Substring(0, ip.IndexOf(';'));
                }
            }
            Regex regex = new Regex("[^0-9.]");
            if (ip == null || ip.Length == 0 || regex.IsMatch(ip))
            {
                ip = HttpContext.Current.Request.UserHostAddress;
                if (ip == null || ip.Length == 0 || regex.IsMatch(ip))
                {
                    ip = "0.0.0.0";
                }
            }
            return GetCustomerMac(ip);
            //string hostInfo = Dns.GetHostName();
            //ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //ManagementObjectCollection mo = mc.GetInstances();
            //foreach(ManagementBaseObject m in mo)
            //{
            //    if((bool)m["IpEnabled"]==true)
            //    {
            //        return m["MacAddress"].ToString();
            //    }
            //}
            //mo.Dispose();
            //return null;
        }

        /// <summary>
        /// get MAC 20110310
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public string GetCustomerMac(string IP)
        {
            string dirResults = "";
            ProcessStartInfo psi = new ProcessStartInfo();
            Process proc = new Process();
            psi.FileName = "nbtstat";
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = "-a " + IP;
            psi.UseShellExecute = false;
            proc = Process.Start(psi);
            dirResults = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();//匹配 mac 地址 
            Match m = Regex.Match(dirResults, "\\w+\\-\\w+\\-\\w+\\-\\w+\\-\\w+\\-\\w\\w"); //若匹配成功则返回 mac,否则返回找不到主机信息
            if (m.ToString() != "")
            {
                return m.ToString();
            }
            else
            {
                return "127.0.0.1";
            }
        }
    }
}
