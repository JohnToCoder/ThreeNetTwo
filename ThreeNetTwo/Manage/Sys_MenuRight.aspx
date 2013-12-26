<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_MenuRight.aspx.cs"
    Inherits="ThreeNetTwo.Manage.Sys_MenuRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            background: #EBF4FD;
        }
        table td
        {
            border: 1px solid #73a4f6;
            padding: 4px 6px 4px 6px;
            vertical-align: top;
        }
    </style>
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/Sys_MenuRight.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblRoleCode" runat="server" Text=""></asp:Label>
                    角色的權限
                </td>
            </tr>
            <tr>
                <td style="width: 240px">
                    <asp:Panel ID="Panel1" Height="340px" ScrollBars="Vertical" runat="server">
                        <ul id="ttLeft" class="easyui-tree">
                        </ul>
                    </asp:Panel>
                </td>
                <td style="width: 240px">
                    <asp:Panel ID="Panel2" Height="340px" ScrollBars="Vertical" runat="server">
                        <ul id="ttRight" class="easyui-tree">
                        </ul>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <a id="btnLeft" class="easyui-linkbutton" href="javascript:void(0)">授權所選功能</a>
                </td>
                <td align="center">
                    <a id="btnRight" class="easyui-linkbutton" href="javascript:void(0)">收回所選權限</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
