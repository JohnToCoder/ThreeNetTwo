<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_LoadTableLog_Edit.aspx.cs"
    Inherits="ThreeNetTwo.Manage.SysLoadTableLog.Sys_LoadTableLog_Edit" %>

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

    <script src="../../js/jquery-ui-1.8rc3.custom.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('#txtStartDate').datebox(
                {
                    required: false
                }
            );
            $('#txtEndDate').datebox(
                {
                    required: false
                }
            );

            $.post('../../ashx/Mac.ashx', function(data) {
                var arr = data.split('|');
                $('#txtMac').autocomplete({ source: arr });
            });
        });
    </script>

</head>
<body style="overflow: hidden">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr id="trMAC" runat="server">
                <td align="right">
                    <span>開始時間</span>
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span>結束時間</span>
                </td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trCodeName" runat="server">
                <td align="right">
                    <span>MAC地址</span>
                </td>
                <td>
                    <asp:TextBox ID="txtMac" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span>客戶端主機名</span>
                </td>
                <td>
                    <asp:TextBox ID="txtClientName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trTime" runat="server">
                <td align="right">
                    <span>表名</span>
                </td>
                <td>
                    <asp:TextBox ID="txtTableName" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span>步驟</span>
                </td>
                <td>
                    <asp:TextBox ID="txtOrderId" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="txtId" runat="server" Text="" CssClass="hide"></asp:TextBox>
    </div>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
