<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Mac_More.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_Mac_More" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/SubFrameStyle.css" rel="stylesheet" type="text/css" />

 
      <style type="text/css">
    
        form
        {
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
          
        }
              
        
       .OddRow
        {
            background-color: #d1ecfc;
        }
        td
        {
            font-size: 14px;
            border: 1px solid #53bdcb;
        }
  

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table  cellpadding="0" cellspacing="0" width="100%" style="border: #53bdcb 1px solid;background-color:#e5f6fb;">
            <tr>
                <td align="left" class="OddRow" style="width:10%">
                    備注
                </td>
                <td class="OddRow" style="width:20%">
                    <asp:Label ID="lblMeno" runat="server" Width="50px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="FormTitle" align="left">
                    身份證號
                </td>
                <td class="FormLabel">
                    <asp:Label ID="lblUserId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="OddRow" align="left">
                    E-Mail</td>
                <td class="OddRow">
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    家庭住址</td>
                <td>
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="OddRow" align="left">
                    創建者</td>
                <td class="OddRow">
                    <asp:Label ID="lblCreator" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    創建日期</td>
                <td>
                    <asp:Label ID="lblCreatedate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="OddRow" align="left">
                    編輯者</td>
                <td class="OddRow">
                    <asp:Label ID="lblEditor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    編輯日期</td>
                <td>
                    <asp:Label ID="lblEditDate" runat="server"></asp:Label>
                </td>
            </tr>          
            
        </table>
    </div>
    </form>
</body>
</html>
