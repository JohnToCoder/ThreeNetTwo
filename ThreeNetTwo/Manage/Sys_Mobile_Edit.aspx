<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Mobile_Edit.aspx.cs"
    Inherits="ThreeNetTwo.Manage.Sys_Mobile_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="overflow:hidden">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
             <tr id="trMAC" runat="server">
                <td align="right">
                    <span>MAC地址</span></td>
                <td>
                    <asp:TextBox ID="txtMac" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span>手機號碼</span></td>
                <td>
                    <asp:TextBox ID="txtMobileCode" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trUserName" runat="server">
                <td align="right">
                    <span>用戶名稱</span>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span>郵箱地址</span></td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>           
        </table>
        <asp:TextBox ID="txtId" runat="server" Text="" CssClass="hide"></asp:TextBox>
    </div>
    </form>
</body>
</html>
