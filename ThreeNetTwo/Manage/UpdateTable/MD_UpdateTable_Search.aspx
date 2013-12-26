<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_UpdateTable_Search.aspx.cs"
    Inherits="ThreeNetTwo.Manage.UpdateTable.MD_UpdateTable_Search" %>

<%@ Register src="../../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/jquery-ui-1.8rc3.custom.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr id="trTableName" runat="server">
                <td align="right" style="width: 85px">
                    表名稱
                </td>
                <td style="width: 230px">
                    <asp:TextBox ID="txtTableName" runat="server" Text="" CssClass="text" MaxLength="40"
                        Width="140px"></asp:TextBox>
                </td>
            </tr>
 
        </table>
    </div>
    <asp:TextBox ID="txtId" runat="server" Text="" CssClass="hide"></asp:TextBox>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
