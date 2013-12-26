<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_Music_Edit.aspx.cs"
    Inherits="ThreeNetTwo.Music.MD_Music_Edit" %>

<%@ Register Src="../IsLogin.ascx" TagName="IsLogin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/MD_Music.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr id="trImageName" runat="server">
                <td align="right">
                    <span style="color: Red">*</span>歌曲名稱
                </td>
                <td>
                    <asp:TextBox ID="txtMusicName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span style="color: Red">*</span>歌曲類型
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="text">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trPicCata" runat="server">
                <td align="right">
                    <span style="color: Red">*</span>演唱者
                </td>
                <td>
                    <asp:TextBox ID="txtSinger" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <%--<td align="right">
                    <span style="color: Red">*</span>專輯名
                </td>
                <td>
                    <asp:DropDownList ID="ddlAlbum" runat="server" CssClass="text">
                    </asp:DropDownList>
                </td>--%>
                <td align="right">
                    <span style="color: Red">*</span>發行時間
                </td>
                <td>
                    <asp:TextBox ID="txtComeOut" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span style="color: Red">*</span>歌曲地址
                </td>
                <td>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span style="color: Red">*</span>歌曲顺序
                </td>
                <td>
                    <asp:TextBox ID="txtOrder" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    <asp:TextBox ID="lblID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtImgPath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtPageRecord" runat="server" CssClass="hide"></asp:TextBox>
    </form>
</body>
</html>
