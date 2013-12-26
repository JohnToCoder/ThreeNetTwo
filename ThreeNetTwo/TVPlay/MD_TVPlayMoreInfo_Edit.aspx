<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_TVPlayMoreInfo_Edit.aspx.cs" Inherits="ThreeNetTwo.TVPlay.MD_TVPlayMoreInfo_Edit" %>

<%@ Register src="../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>電視劇分集操作頁面</title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/TVPlayDetail.js" type="text/javascript"></script>   
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr id="trImageName" runat="server">
                <td align="right">
                   <span>
                       <asp:Label ID="lblTVSub"  ForeColor="Red"  runat="server" Text="*"></asp:Label>電視分集</span>
                </td>
                <td>
                   <asp:TextBox ID="txtTVsub" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
               <td align="right">
                    <span> 
                        <asp:Label ID="lblComeOut" ForeColor="Red"  runat="server" Text="*"></asp:Label>上映時間</span>
                </td>
                <td>
                    <asp:TextBox ID="txtComeOut" runat="server" CssClass="text"></asp:TextBox>
                </td>        
            </tr>
            <tr id="trPicCata" runat="server">
                <td align="right">
                    <span>
                        <asp:Label ID="lblUrl" ForeColor="Red"  runat="server" Text="*"></asp:Label> 播放地址</span>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="text"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="right">
                   <span> <asp:Label ID="lblDesc" ForeColor="Red"  runat="server" Text="*"></asp:Label>劇情簡介</td></span>
                <td colspan="3">
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="text" Height="74px" 
                        TextMode="MultiLine" Width="338px"></asp:TextBox>
                </td>
            </tr>          
        </table>    
    </div>  

    <asp:TextBox ID="lblID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtImgPath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtPageRecord" runat="server" CssClass="hide"></asp:TextBox>   
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
