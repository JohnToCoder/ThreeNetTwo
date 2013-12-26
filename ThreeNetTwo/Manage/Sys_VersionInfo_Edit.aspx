<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_VersionInfo_Edit.aspx.cs"
    Inherits="ThreeNetTwo.Manage.Sys_VersionInfo_Edit" %>

<%@ Register src="../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../Css/Common.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/Sys_VersionInfo.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 16%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="table">
            <tr id="trChannelName" runat="server">
                <td align="right">
                    <span><asp:Label ID="Label1" runat="server" Text="*" Style="color: Red"></asp:Label>版本號</span>
                </td>
                <td>
                    <asp:TextBox ID="txtVersionNum" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td>
                    <span><asp:Label ID="Label2" runat="server" Text="*" Style="color: Red"></asp:Label>版本描述</span></td>
                <td>
                    <asp:TextBox ID="txtVersionDesc" runat="server" Text="" CssClass="text" 
                        Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr id="trChannelUrl" runat="server">
                <td align="right">
                    <span><asp:Label ID="Label3" runat="server" Text="*" Style="color: Red"></asp:Label>版本日期</span></td>
                <td>
                    <asp:TextBox ID="txtVersionDate" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td>
                    <span><asp:Label ID="Label4" runat="server" Text="*" Style="color: Red"></asp:Label>發佈日期</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPubDate" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trCreateDate" runat="server">
                <td align="right">
                    上傳時間</td>
                <td colspan="3">
                    <asp:TextBox ID="txtCreateDate" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trFileUp" runat="server">
                <td align="right" class="style1">
                    <span><asp:Label ID="Label5" runat="server" Text="*" Style="color: Red"></asp:Label>版本路徑</span>
                </td>
                <td colspan="3">
                    <asp:FileUpload ID="FilePath" runat="server" />
                </td>
            </tr>
            </table>
    </div>
    <asp:TextBox ID="txtID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtImgPath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:Button ID="btnStopKeyEnter" runat="server" CssClass="hide" OnClick="btnStopKeyEnter_Click" />
    <asp:Button ID="btnOK" runat="server" CssClass="hide" OnClick="btnOK_Click" />
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
