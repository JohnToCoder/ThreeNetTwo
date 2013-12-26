﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_LoadDataLog.aspx.cs"
    Inherits="ThreeNetTwo.Manage.Sys_LoadDataLog" %>

<%@ Register Src="../IsLogin.ascx" TagName="IsLogin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/Sys_LoadDataLog.js" type="text/javascript"></script>

    <script src="../js/jgxLoader.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
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
                                                    <span class="BText">你当前的位置</span>：[同步管理]-[客戶端資料更新Log]
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="60">
                                                    <div class="imgBtnSel" id="btnSel" runat="server">
                                                        查詢
                                                    </div>
                                                </td>
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
                        <td width="8" background="../images/table/tab_12.gif">
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GvDataLog" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                                            PageSize="13" OnPageIndexChanging="Gv_Replace_PageIndexChanging" OnRowDataBound="GvDataLog_RowDataBound">
                                            <PagerSettings PageButtonCount="4" />
                                            <Columns>
                                                <asp:BoundField HeaderText="MenuTypeID" DataField="MenuTypeID" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="hide" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="hide" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                
                                                <asp:BoundField HeaderText="DataID" DataField="DataID" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="hide" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="hide" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                
                                                <asp:BoundField HeaderText="MAC地址" DataField="MAC" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="14%" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="14%" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="客戶端主機名稱" DataField="UserName" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="15%" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="資料類型" DataField="CodeDesc" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="8%" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="8%" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="資料" DataField="Data" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="20%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="20%"/>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="資料明細" DataField="DataDesc" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left"  />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="動作" DataField="ActionTypeDesc" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="5%"/>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="開始時間" DataField="StartDate" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="10%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="10%"/>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="結束時間" DataField="EndDate" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="10%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="10%"/>
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle HorizontalAlign="Center" BackColor="#d1ecfc" CssClass="PageButton" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="8" background="../images/table/tab_15.gif">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20" background="../images/table/tab_19.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12" height="20">
                            <img src="../images/table/tab_18.gif" width="12" height="20" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td width="16">
                            <img src="../images/table/tab_20.gif" width="16" height="20" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <div id="WinSel" title="  查詢" collapsible="false" minimizable="false" maximizable="false"
        class="divStyle">
        <div region="center" border="false" class="subdivStyle" style="height: 90%">
            <iframe id="subFrameSel" name="subFrameSel" scrolling="no" frameborder="0" src=""
                style="width: 100%; height: 100%;"></iframe>
        </div>
        <div region="south" border="false" style="text-align: center; vertical-align: middle;
            height: 25px; line-height: 25px;">
            <table cellpadding="0" border="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" style="padding-top: 5px;">
                        <div id="btnSelYes" class="BtnYesStyle">
                            確定</div>
                    </td>
                    <td align="left" style="padding-left: 15px; padding-top: 5px;">
                        <div id="btnCancel2" class="BtnNoStyle">
                            取消</div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    <div id="MoreShow" title="  更多信息" collapsible="false" minimizable="false" maximizable="false" class="divStyle" style="height:93%;padding-bottom:5px">
           <div region="center" border="false" class="subdivStyle" style="height:95%">
                <iframe id="moreFrame" name="subFrame" scrolling="no" frameborder="0"  src="" style="width:100%;height:100%;"></iframe>
           </div> 
     </div>
         
         
    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="hide"></asp:TextBox>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
