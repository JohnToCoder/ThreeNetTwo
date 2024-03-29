﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_MacRoles.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_MacRoles" %>

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

    <script src="../js/Sys_MacRole.js" type="text/javascript"></script>

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
                                                        <img src="../images/table/tb.gif" width="16" height="16" alt="" /></div>
                                                </td>
                                                <td width="95%" class="NText">
                                                    <span class="BText">你当前的位置</span>：[同步管理]-[客戶端角色管理]
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="60">
                                                    <div class="imgBtnSel" id="btnSearch" style="line-height: 22px" runat="server">
                                                        查詢
                                                    </div>
                                                </td>
                                                <td width="60">
                                                    <div class="imgBtnIns" id="btnInsert" style="line-height: 22px" runat="server">
                                                        新增
                                                    </div>
                                                </td>
                                                <td width="60">
                                                    <div class="imgBtnUpd" id="btnUpd" style="line-height: 22px" runat="server">
                                                        修改
                                                    </div>
                                                </td>
                                                <td width="60">
                                                    <div class="imgBtnDel" id="btnDel" style="line-height: 22px" runat="server">
                                                        刪除
                                                    </div>
                                                </td>
                                                <%--<td width="60">
                                                    <div class="imgBtnSet" id="btnset" style="line-height:22px" runat="server">
                                                       權限設置  
                                                    </div>
                                                </td>--%>
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
                                        <asp:GridView ID="Gv_MacRole" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            BorderWidth="0px" GridLines="Vertical" BorderStyle="None" Width="100%" AllowPaging="True"
                                            PageSize="15" OnRowDataBound="Gv_Role_RowDataBound" OnPageIndexChanging="Gv_MacRole_PageIndexChanging">
                                            <PagerSettings PageButtonCount="4" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkCheck" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="GvHeader" Width="10px" />
                                                    <ItemStyle CssClass="GvItem" Width="10px" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="ID" DataField="ID">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="hideCss" />
                                                    <ItemStyle CssClass="hideCss" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="角色代碼" DataField="MacRoleCode">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="角色描述" DataField="MacRoleDesc">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="創建者" DataField="Creator">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="創建時間" DataField="CreatDate">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="修改者" DataField="Editor">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="修改時間" DataField="EditDate">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="權限設置" DataField="MacRoleSet">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="MoreCss" HorizontalAlign="Left" />
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
                        <td width="8" style="background-image: url('../images/table/tab_15.gif')">
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
    <div id="WinQX" title="  權限設置" collapsible="false" minimizable="false" maximizable="false"
        style="padding: 15px; background: #fafafa; width: 99%; height: 99%; display: none;
        overflow: hidden">
        <div region="center" border="false" style="padding: 0px; background: #EBF4FD; border: 1px solid #ccc;
            width: 100%; height: 100%;">
            <iframe id="subFrameSel" name="subFrameSel" scrolling="no" frameborder="0" src=""
                style="width: 100%; height: 100%;"></iframe>
        </div>
    </div>
    <div id="Win" title="  查詢" collapsible="false" minimizable="false" maximizable="false"
        class="divStyle" style="height: 80%">
        <div region="center" border="false" class="subdivStyle" style="height: 70%">
            <iframe id="subFrame" name="subFrame" scrolling="no" frameborder="0" src="" style="width: 100%;
                height: 80%;"></iframe>
        </div>
        <div region="south" border="false" style="text-align: center; vertical-align: middle;
            height: 25px; line-height: 25px;">
            <table cellpadding="0" border="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" style="padding-top: 15px;">
                        <div id="btnOk" class="BtnYesStyle">
                            確定</div>
                    </td>
                    <td align="left" style="padding-left: 15px; padding-top: 15px;">
                        <div id="btnCancel" class="BtnNoStyle">
                            取消</div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:TextBox ID="txtKeyValue" runat="server" CssClass="hideCss"></asp:TextBox>
    <asp:TextBox ID="txtSuccess" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="hide"></asp:TextBox>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
