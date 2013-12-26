<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_Channel_Edit.aspx.cs"
    Inherits="ThreeNetTwo.js.MD_Channel_Edit" %>

<%@ Register src="../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>頻道操作頁面</title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/MD_Channel.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">            
            <tr id="trChannelName" runat="server">
                <td align="right" style="width: 16%">
                    <span>
                        <asp:Label ID="Label1" runat="server" Text="*" Style="color: Red"></asp:Label>頻道名稱</span>
                </td>
                <td style="width: 34%">
                    <asp:DropDownList ID="ddlChannelName" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 16%">
                    <span><asp:Label ID="Label2" runat="server" Text="*" Style="color: Red"></asp:Label>頻道URL</span>
                </td>
                <td>
                    <asp:TextBox ID="txtChannelUrl" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>            
            <tr>
                <td align="right" style="width: 16%">
                    <span><asp:Label ID="Label3" runat="server" Text="*" Style="color: Red"></asp:Label>URL(iPad)</span>
                </td>
                <td>
                    <asp:TextBox ID="txtUrlIPad" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right" style="width: 16%">
                    <span><asp:Label ID="Label4" runat="server" Text="*" Style="color: Red"></asp:Label>圖標</span>
                </td>
                <td>
                    <asp:FileUpload ID="FileUploadLogo" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 16%">
                    <span><asp:Label ID="Label5" runat="server" Text="*" Style="color: Red"></asp:Label>地區</span>
                </td>
                <td style="width: 34%">
                    <asp:DropDownList ID="ddlArea" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 16%">
                    <span><asp:Label ID="Label6" runat="server" Text="*" Style="color: Red"></asp:Label>類型</span>
                </td>
                <td style="width: 34%">
                    <asp:DropDownList ID="ddlChannelType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>            
        </table>
    </div>
    
    <asp:TextBox ID="txtID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtImgPath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:Button ID="btnStopKeyEnter" runat="server" CssClass="hide" onclick="btnStopKeyEnter_Click" />
    <asp:Button ID="btnOK" runat="server" CssClass="hide" onclick="btnOK_Click" />
    <asp:TextBox ID="txtPageRecord" runat="server" CssClass="hide"></asp:TextBox>
    </form>

</body>
</html>
