<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_Album_Edit.aspx.cs"
    Inherits="ThreeNetTwo.Music.MD_Album_Edit" %>

<%@ Register Src="../IsLogin.ascx" TagName="IsLogin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>專輯操作頁面</title>
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../Css/Common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

    </style>

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/Common.js" type="text/javascript"></script>

    <script src="../js/MD_Album.js" type="text/javascript"></script>
<%--    <script type="text/javascript">
        $(document).ready(function() {
        $("#red1").hide();
    })
    </script>--%>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="table">
            <tr id="trImageName" runat="server">
                <td align="right">
                    <span id="spAlbum" runat="server" style="color: Red">*</span>專輯名稱
                </td>
                <td>
                    <asp:TextBox ID="txtAlbumName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span id="spType" runat="server" style="color: Red">*</span>專輯類型
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="text">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trPicCata" runat="server">
                <td align="right">
                    <span id="spSinger" runat="server" style="color: Red">*</span>演唱者
                </td>
                <td>
                    <asp:TextBox ID="txtSinger" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span id="spCome" runat="server" style="color: Red">*</span>發行時間
                </td>
                <td>
                    <asp:TextBox ID="txtComeOut" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span id="spUrl" runat="server" style="color: Red">*</span>播放地址
                </td>
                <td>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span  id="spMedia" runat="server" style="color: Red">*</span>媒體來源
                </td>
                <td>
                    <asp:DropDownList ID="ddlMediaSource" runat="server" CssClass="text">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trFileUp" runat="server">
                <td align="right">
                    <span style="color: Red">*</span>上傳圖片
                </td>
                <td colspan="3">
                    <asp:FileUpload ID="fileUpload" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
<%--    <asp:Button ID="btnStopKeyEnter" runat="server" CssClass="hide" OnClick="btnStopKeyEnter_Click" />
--%>    <asp:Button ID="btn_OK" runat="server" OnClick="btn_OK_Click" CssClass="hide" />
    <asp:TextBox ID="lblID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtImgPath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtPageRecord" runat="server" CssClass="hide"></asp:TextBox>
    </form>
</body>
</html>
