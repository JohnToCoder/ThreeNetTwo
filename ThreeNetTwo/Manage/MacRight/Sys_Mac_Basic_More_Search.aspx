<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Mac_Basic_More_Search.aspx.cs" Inherits="ThreeNetTwo.Manage.MacRight.Sys_Mac_Basic_More_Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
      <link href="../../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr runat="server">
                <td align="right" style="width:10%">
                    <span><span style="color:Red">*</span>收藏節目</span></td>
                <td style="width:25%">
                    <asp:TextBox ID="txtCollecte" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="txtType" runat="server" CssClass="hide"></asp:TextBox>
    </div>
    </form>
</body>
</html>
