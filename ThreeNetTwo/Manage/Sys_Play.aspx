<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Play.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_Play" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
       <link href="../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
  <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="30" background="../images/table/tab_05.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12" height="30">
                            <img src="../images/table/tab_03.gif" width="12" height="30" />
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="46%" valign="middle">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="5%">
                                                    <div align="center">
                                                        <img src="../images/table/tb.gif" width="16" height="16" /></div>
                                                </td>
                                                <td width="95%" class="NText">
                                                    <span class="BText">你当前的位置</span>：[系統設置]-[播放設置]
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="60">
                                                <div class="imgBtnSel" id="btnSel">
                                                       查詢  
                                                    </div></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="16">
                            <img src="../images/table/tab_07.gif" width="16" height="30" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="8" style="background-image:url('../images/table/tab_12.gif')">
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GvPlay" runat="server"  AutoGenerateColumns="False" 
                                            Width="100%" CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None"
                                            AllowPaging="True" PageSize="13">
                                            <PagerSettings PageButtonCount="4" />
                                            <Columns>
                                                <asp:BoundField HeaderText="MAC地址" DataField="UserCode" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="20%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="20%"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="播放方式" DataField="PlayTYpe" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="20%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="20%"/>
                                                 </asp:BoundField>
                                                
                                                 <asp:BoundField HeaderText="用戶名稱" DataField="UserName" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="15%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="15%"/>
                                                 </asp:BoundField>
                                                 
                                                  <asp:BoundField HeaderText="郵箱地址" DataField="Email" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="25%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="25%"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="創建時間" DataField="CreatDate" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left"/>
                                                 </asp:BoundField>
                                                 
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle HorizontalAlign="Center" BackColor="#d1ecfc" CssClass="PageButton"  />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <EditRowStyle BackColor="#2461BF"  />
                                            <AlternatingRowStyle  CssClass="GridAlternatingRowStyle"/>
                                            
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="8" style="background-image:url('../images/table/tab_15.gif')">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td height="20"  style="background-image:url('../images/table/tab_19.gif')">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12" height="20">
                            <img src="../images/table/tab_18.gif" width="12" height="20" alt="" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td width="16">
                            <img src="../images/table/tab_20.gif" width="16" height="20" alt="" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
