<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_UsersManage_Edit.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_UsersManage_Edit" %>

<%@ Register src="../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
     <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>
    <script src="../js/Sys_UsersManage.js" type="text/javascript"></script>
    <script src="../js/jquery.lazyload.js" type="text/javascript"></script>
    <script type="text/javascript">
     $(document).ready(function()
               {
        if($('#txtSearchflag').val()=="sel")
        {
          $('#spanUserCode').hide();
          $('#spanUserName').hide();
          $('#spantxtTEL').hide();
          $('#spanEmail').hide();
          $('#spanMobile').hide();
          $('#spanrole').hide();
          $('#spanIP').hide();
         
        }       
        }
     )
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr id="trUserCode" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spanUserCode">*</span>用戶帳號</span>
                </td>
                <td style="width:34%">
                    <asp:TextBox ID="txtUserCode" runat="server" Text="" CssClass="text" 
                        MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr id="trUserName" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spanUserName">*</span>用戶名稱</span></td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Text="" CssClass="text" 
                        MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr id="trPassword" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red">*</span>用戶密碼</span>
                </td>
                <td style="width:34%">
                    <asp:TextBox ID="txtPassword" runat="server" Text="" CssClass="text" 
                        MaxLength="15" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr id="trcfPassword" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red">*</span>確認密碼</span></td>
                <td>
                    <asp:TextBox ID="txtcfPassword" runat="server" Text="" CssClass="text" 
                        MaxLength="15" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr id="trfileUpload" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red">*</span>上傳圖片</span></td>
                <td>
                    <asp:FileUpload ID="fileUpload" runat="server"/>
                </td>
            </tr>
            <tr id="trTEL" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spantxtTEL">*</span>電話</span>
                </td>
                <td style="width:34%">
                    <asp:TextBox ID="txtTEL" runat="server" Text="" CssClass="text" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr id="trEmail" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spanEmail">*</span>郵箱</span></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Text="" CssClass="text" 
                        MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr id="trMobile" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spanMobile">*</span>手機號碼</span>
                </td>
                <td style="width:34%">
                    <asp:TextBox ID="txtMobile" runat="server" Text="" CssClass="text" 
                        MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr id="trrole" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spanrole">*</span>角色</span></td>
                <td>
                    <asp:DropDownList ID="ddlrole" Width="157px" runat="server" 
                        CssClass="borderset"></asp:DropDownList>
                </td>
            </tr>
            <tr id="trIP" runat="server">
                <td align="right" style="width:16%">
                    <span><span style="color:Red" id="spanIP">*</span>IP</span>
                </td>
                <td style="width:34%">
                    <asp:TextBox ID="txtIP" runat="server" Text="" CssClass="text" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
     <asp:Button ID="Button1" runat="server" CssClass="hide" onclick="Button1_Click"/>
     <asp:Button ID="btn_OK" runat="server" CssClass="hide" onclick="btn_OK_Click"/>
      <asp:TextBox ID="lblID" runat="server" CssClass="hide"></asp:TextBox>
      <asp:TextBox ID="lblimgpath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtSearchflag" runat="server" CssClass="hide"></asp:TextBox>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
