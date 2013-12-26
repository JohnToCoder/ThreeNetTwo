<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_DetailRight_Edit.aspx.cs" Inherits="ThreeNetTwo.Manage.MacRoleRight.Sys_DetailRight_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="overflow:hidden">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
              <tr id="trName" runat="server">
                <td align="right">
                    <span>詳細名稱</span>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
                </td>
                
            </tr>
            <%--<tr id="trFlag" runat="server">
                 <td align="right">
                    <span>授權狀態</span>
                </td>
                <td>
                      <asp:DropDownList ID="ddlFlag" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>--%>
        </table>
        <asp:TextBox ID="txtRightId" runat="server" Text="" CssClass="hide"></asp:TextBox>
        <asp:TextBox ID="txtMenuTypeId" runat="server" Text="" CssClass="hide"></asp:TextBox>
        <asp:TextBox ID="txtRoleId" runat="server" Text="" CssClass="hide"></asp:TextBox>
    </div>
    </form>
</body>
</html>
