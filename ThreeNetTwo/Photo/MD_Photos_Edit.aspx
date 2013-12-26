<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_Photos_Edit.aspx.cs" Inherits="ThreeNetTwo.Photo.MD_Photos_Ins" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>圖片操作頁面</title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="overflow:hidden">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr id="trImageName" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red">*</span>圖片名稱</span>
                </td>
                <td style="width:34%">
                    <asp:TextBox ID="txtImageName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trPicCata" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red">*</span>圖片類型</span></td>
                <td>
                    <asp:DropDownList ID="ddlPictureCatalog" Width="157px" runat="server" CssClass="borderset"></asp:DropDownList>
                </td>
            </tr>
            <tr id="trServiceID" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red">*</span>服務器ID</span></td>
                <td>
                    <asp:TextBox ID="txtServiceID" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trUserCode" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red">*</span>收藏者</span></td>
                <td>
                    <asp:TextBox ID="txtUserCode" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr id="trUpload" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red">*</span>上傳圖片</span></td>
                <td>
                    <asp:FileUpload ID="fileUpload" runat="server"/>
                </td>
            </tr>
        </table>
     </div>
     
     <div id="ShowImage" runat="server" style="padding-left:90px;padding-top:10px">
        <asp:Image runat="server" id="imgBig" Width="400px" Height="200px" ImageUrl="" />
    </div>
    
    <asp:Button ID="btn_OK" runat="server" onclick="btn_OK_Click" CssClass="hide"/>
    <asp:TextBox ID="imgID" CssClass="hide" runat="server"/>
    <asp:TextBox ID="imgPath" CssClass="hide" runat="server"/>
    </form>
</body>
</html>
