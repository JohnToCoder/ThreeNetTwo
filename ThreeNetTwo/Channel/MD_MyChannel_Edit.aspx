<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_MyChannel_Edit.aspx.cs"
    Inherits="ThreeNetTwo.Channel.MD_MyChannel_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/Common.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../Css/jquery.ui.autocomplete.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/Common.js" type="text/javascript"></script>

    <script src="../js/MD_MyChannel.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="table">
            <tr id="trChannelName" runat="server">
                <td align="right" style="width: 16%">
                    <span><span style="color: Red">*</span>頻道名稱</span>
                </td>
                <td style="width: 34%">
                    <asp:DropDownList ID="ddlChannelName" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 16%">
                    <span><span style="color: Red">*</span>節目名稱</span>
                </td>
                <td>
                    <asp:TextBox ID="txtProgramName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 16%">
                    <span><span style="color: Red">*</span>收藏人</span>
                </td>
                <td style="width: 34%">
                    <asp:TextBox ID="txtUserName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right" style="width: 16%">
                    <span><span style="color: Red">*</span>收藏日期</span>
                </td>
                <td style="width: 34%">
                    <asp:TextBox ID="txtDate" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td align="right" style="width: 16%">
                    <span><span style="color: Red">*</span>服務器ID</span>
                </td>
                <td style="width: 34%">
                    <asp:TextBox ID="txtServiceID" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                 
            
            </tr>
        </table>
    </div>
    <asp:TextBox ID="txtID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtImgPath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:Button ID="btnOK" runat="server" CssClass="hide" OnClick="btnOK_Click" />
    </form>
</body>
</html>
