<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Mac_Right_Edit.aspx.cs" Inherits="ThreeNetTwo.Manage.MacRight.Sys_Mac_Right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $(function() {
                $('#txtCStartDate').datebox({
                    formatter: function(date) {
                        var y = date.getFullYear();
                        var m = date.getMonth() + 1;
                        var d = date.getDate();
                        return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                    }
                });

                $('#txtCEndDate').datebox({
                    formatter: function(date) {
                        var y = date.getFullYear();
                        var m = date.getMonth() + 1;
                        var d = date.getDate();
                        return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                    }
                });

                $('#txtMStartDate').datebox({
                    formatter: function(date) {
                        var y = date.getFullYear();
                        var m = date.getMonth() + 1;
                        var d = date.getDate();
                        return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                    }
                });

                $('#txtMEndDate').datebox({
                    formatter: function(date) {
                        var y = date.getFullYear();
                        var m = date.getMonth() + 1;
                        var d = date.getDate();
                        return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                    }
                });

                $('#txtPStartDate').datebox({
                    formatter: function(date) {
                        var y = date.getFullYear();
                        var m = date.getMonth() + 1;
                        var d = date.getDate();
                        return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                    }
                });

                $('#txtPEndDate').datebox({
                    formatter: function(date) {
                        var y = date.getFullYear();
                        var m = date.getMonth() + 1;
                        var d = date.getDate();
                        return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                    }
                });
            });

        });
    </script>
    <style type="text/css">
        form
        {
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
        }

         #base
        {
            vertical-align:middle;
            border:1px solid #73a4f6;
            border-collapse:collapse;
            color: #15428B;
        }
              
        #base td
        {
            border:1px solid #73a4f6;
            padding:6px 6px 6px 6px;
        }

        .button
        {
            width: 50px;
            height: 21px;
            border: 1px solid #93bee2;
            color: #006699;
            font-size: 9pt;
            font-style: normal;
            background-color: #e8f4ff;
            cursor:pointer;
        }
        .text
        {
	        width: 150px;
            height: 18px;
            border: 1px solid #93bee2;
            font-size: 9pt;
            font-style: normal;
	        margin-bottom: 0px;
        }

        .borderset
        {
	        border: 1px solid #93bee2;
        }
        .hide
        {
	        display:none;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <table id="base"  width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr id ='channel' runat="server">
            <td align="right" style="width:150px">
              <asp:Label ID="lblClass" runat="server" Text="所屬頻道"></asp:Label>
            </td>
            <td align="left">
                 <asp:DropDownList ID="ddlClass" runat="server" CssClass="text" Width="172px" Height="23px" >
                 </asp:DropDownList>
            </td>
            <td align="right" style="width:150px">
                <asp:Label ID="lblName" runat="server" Text="開始日期"></asp:Label>    
            </td>
               
            <td align="left">
                
                <asp:TextBox ID="txtCStartDate" runat="server" ReadOnly="true" CssClass="text" Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr id='Channeldate' runat="server">
            <td align="right">
                <asp:Label ID="lblPlayDate" runat="server" Text="結束日期"></asp:Label>
            </td>
            <td align="left" colspan='3'>
                <asp:TextBox ID="txtCEndDate" runat="server" ReadOnly="true" CssClass="text" Width="170px"></asp:TextBox>
            </td>
        </tr>
         <tr id='Movie' runat="server">
            <td align="right">
                 <asp:Label ID="lblMovie" runat="server" Text="電影名稱"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtMovieName" runat="server" CssClass="text" Width="165px"></asp:TextBox>
            </td>
            <td align="right">
                <asp:Label ID="lblDate" runat="server" Text="開始日期"></asp:Label>
            </td> 
            <td align="left">
                <asp:TextBox ID="txtMStartDate" runat="server" ReadOnly="true" CssClass="text"  Width="165px"></asp:TextBox>
            </td>
        </tr> 
          <tr id='trTV' runat="server">
            <td align="right">
                 <asp:Label ID="lblMendDate" runat="server" Text="結束日期"></asp:Label>
            </td>
            <td align="left" colspan='3'>
                <asp:TextBox ID="txtMEndDate" runat="server" ReadOnly="true" CssClass="text" Width="165px"></asp:TextBox>
            </td>
   
        </tr> 
        
        <tr id="trMusic" runat="server">
           <td align="right">
                <asp:Label ID="lblMname" runat="server" Text="所屬專輯"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlIistClass" runat="server" Width="172px" Height="23px" >
                </asp:DropDownList>
              
            </td>
            <td align="right">
                <asp:Label ID="lblMUName" runat="server" Text="音樂名稱"></asp:Label>
            </td>
               
            <td align="left">
                <asp:TextBox ID="txtMUName" runat="server"  CssClass="text"  Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr id='trdlMusic' runat="server"> 
           <td align="right">
               <asp:Label ID="lblPhoto" runat="server" Text="開始日期"></asp:Label>
            </td>
            <td align="left">
                  <asp:TextBox ID="txtPStartDate" runat="server" ReadOnly="true" CssClass="text" Width="170px"></asp:TextBox>
            </td>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="結束日期"></asp:Label>
            </td>
               
            <td align="left">
                <asp:TextBox ID="txtPEndDate" runat="server"  CssClass="text" ReadOnly="true" Width="170px"></asp:TextBox>
            </td>
        </tr>
           
    </table>
        <asp:TextBox ID="txtType" runat="server" CssClass="hide"></asp:TextBox>
    </div>
    </form>
</body>
</html>
