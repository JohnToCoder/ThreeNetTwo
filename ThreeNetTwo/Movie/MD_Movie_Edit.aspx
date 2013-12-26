<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_Movie_Edit.aspx.cs"
    Inherits="ThreeNetTwo.Movie.MD_Movie_Edit" %>

<%@ Register src="../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>電影操作頁面</title>
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../Css/Common.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/MD_Movie.js" type="text/javascript"></script>

    <script src="../js/jquery.lazyload.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="table">
            <tr id="trImageName" runat="server">
                <td align="right">
                    <span><span id="MovieName" runat="server" style="color: Red">*</span>電影名稱</span></td>
                <td>
                    <asp:TextBox ID="txtMovieName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span><span id="MovieType" runat="server" style="color: Red">*</span>電影類型</span></td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="text">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trPicCata" runat="server">
                <td align="right">
                    <span><span id="MovieAddress" runat="server" style="color: Red">*</span>播放地址</span>
                </td>
                <td>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span><span id="MovieComeOut" runat="server" style="color: Red">*</span>上映時間</span></td>
                <td>
                    <asp:TextBox ID="txtComeOut" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    電影簡介</td>
                <td colspan="3">
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="text" Height="74px" 
                        TextMode="MultiLine" Width="338px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span><span id="MovieMedia" runat="server" style="color: Red">*</span>媒體來源</span></td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlMediaSource" runat="server" CssClass="text">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trFileUp" runat="server">
                <td align="right">
                    <span><span style="color: Red">*</span>上傳圖片</span></td>
                <td colspan="3">
                    <asp:FileUpload ID="fileUpload" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnFocus" CssClass="hide" runat="server" Text="Button" 
        onclick="btnFocus_Click" />
    <asp:Button ID="btn_OK" runat="server" CssClass="hide" onclick="btn_OK_Click" />
    <asp:TextBox ID="lblID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtImgPath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtPageRecord" runat="server" CssClass="hide"></asp:TextBox>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
