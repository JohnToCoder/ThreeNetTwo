<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Mac_Edit.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_Mac_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
        form
        {
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
        }

         #table1
        {
            vertical-align:middle;
            border:1px solid #73a4f6;
            border-collapse:collapse;
            color: #15428B;
        }
              
        #table1 td
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
    
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('#txtBirthDay').datebox({
                formatter: function(date) {
                    var y = date.getFullYear();
                    var m = date.getMonth() + 1;
                    var d = date.getDate();
                    return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                }
            });

            if ($('#txtFlag').val() == "1") {
                $('span').hide();
            }

        });
        
    </script>

</head>
<body style="font-size:50%">
    <form id="form1" runat="server">
    <div>
       <table cellpadding="0" cellspacing="0" width="100%" border="0" id="table1">
           <tr >
                <td align="right">
                    <span style="color: Red">*</span>名稱</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                   <span style="color: Red">*</span>MAC地址</td>
                <td>
                    <asp:TextBox ID="txtMac" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            
             <tr >
                <td align="right">
                    <span style="color: Red">*</span>性別</td>
                <td>
                    <asp:DropDownList ID="ddlSex" runat="server"  CssClass="borderset">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    生日</td>
                <td>
                  
                    <asp:TextBox ID="txtBirthDay" runat="server" Text="" CssClass="text" ReadOnly="true"></asp:TextBox>
          
                </td>
            </tr>
              <tr>
                <td align="right">
                    電話</td>
                <td>
                  
                    <asp:TextBox ID="txtTel" runat="server" Text="" CssClass="text"></asp:TextBox>
          
                </td>
                <td align="right">
                    手機</td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="right">
                    <span style="color: Red">*</span>角色描述</td>
                <td>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="borderset">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <span style="color: Red">*</span>備注</td>
                <td>
                    <asp:TextBox ID="txtMeno" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span style="color: Red">*</span>身份證號</td>
                <td >
                    <asp:TextBox ID="txtUserId" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
                <td align="right">
                    E-Mail</td>
                <td >
                    <asp:TextBox ID="txtEmail" runat="server" Text="" CssClass="text"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="right">
                    <span style="color: Red">*</span>家庭住址</td>
                <td colspan='3'>
                    <asp:TextBox ID="txtAddress" runat="server" Text="" Width="75%" CssClass="text"></asp:TextBox>
                </td>
           
            </tr>
        </table>
    </div>
     <asp:TextBox ID="txtId" runat="server" Text="" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtFlag" runat="server" CssClass="hide" ></asp:TextBox>
    </form>
</body>
</html>
