<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_ClientVersion_Edit.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_ClientVersion_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Css/jquery-ui-1.8rc3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8rc3.custom.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {

            $.post('../ashx/Sys_ClientVersion.ashx', function(data) {
                var arr = data.split('|');
                $('#txtMac').autocomplete({ source: arr });
            });

        });
    </script>
    
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table cellpadding="0" cellspacing="0" width="100%" border="0">
           <tr id="trMAC" runat="server">
                <td align="right">
                    地址</td>
                <td>
                    <asp:TextBox ID="txtMac" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    客戶端主機名稱</td>
                <td>
                    <asp:TextBox ID="txtMeno" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    版本號</td>
                <td>
                    <asp:TextBox ID="txtVerName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                  <td align="right">
                   版本描述</td>
                <td>
                    <asp:TextBox ID="txtVerDesc" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
