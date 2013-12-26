<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_ChannelMoreInfo_Edit.aspx.cs" Inherits="ThreeNetTwo.Channel.MD_ChannelMoreInfo_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/Common.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>
    
    <script type="text/javascript"> 
        $(document).ready(function(){
            $('#txtPlayingDate').datebox({});
        });
    </script>

    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="table"> 
            <tr>
                <td align="right">
                    <span><asp:Label ID="Label1" runat="server" Text="*" Style="color: Red"></asp:Label>節目名稱</span>
                </td>
                <td>
                    <asp:TextBox ID="txtProgramName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    <span><asp:Label ID="Label2" runat="server" Text="*" Style="color: Red"></asp:Label>播放日期</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPlayingDate" runat="server" Text="" CssClass="text" 
                        MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr id="trPlayingTime" runat="server">
                <td align="right">
                    <span><asp:Label ID="Label3" runat="server" Text="*" Style="color: Red"></asp:Label>播放時間</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPlayingTime" runat="server" Text="" CssClass="text" 
                        MaxLength="5"></asp:TextBox>
                </td>
            </tr>           
        </table>
    </div>
    
    <asp:TextBox ID="txtFlagID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtImgPath" runat="server" CssClass="hide"></asp:TextBox>
    <asp:Button ID="btnStopKeyEnter" runat="server" CssClass="hide" onclick="btnStopKeyEnter_Click" />
    <asp:Button ID="btnOK" runat="server" CssClass="hide" onclick="btnOK_Click" />
    <asp:TextBox ID="txtPageRecord" runat="server" CssClass="hide"></asp:TextBox>
    </form>
</body>
</html>
