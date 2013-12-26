<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_MacRoles_Edit.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_MacRoles_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            if ($('#txtFlag').val() == "1") {
                $('#spCode').hide();
                $('#spRoleName').hide();
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr id="trImageName" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spCode">*</span>客戶角色代碼</span>
                </td>
                <td style="width:34%">
                    <asp:TextBox ID="txtMacRoleCode" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trPicCata" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spRoleName">*</span>客戶角色名稱</span></td>
                <td>
                    <asp:TextBox ID="txtMacRoleName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="txtId" runat="server" Text="" CssClass="hide"></asp:TextBox>
        <asp:TextBox ID="txtFlag" runat="server" CssClass="hide"></asp:TextBox>
    </div>
    </form>
</body>
</html>
