<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_MacRoleRight_Edit.aspx.cs"
    Inherits="ThreeNetTwo.Manage.MacRoleRight.Sys_MacRoleRight_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr id="trMenuTypeName" runat="server">
                <td align="right">
                    <span>模塊名稱</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMenuTypeID" runat="server">
                    </asp:DropDownList>
                </td>
                 <td align="right">
                    <span>授權狀態</span>
                </td>
                <td>
                      <asp:DropDownList ID="ddlFlag" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trName" runat="server">
                <td align="right">
                    <span>資料名稱</span>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="txtType" runat="server" CssClass="hide"></asp:TextBox>
    </div>
    </form>
</body>
</html>
