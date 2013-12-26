<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Mac_basicInfo.aspx.cs" Inherits="ThreeNetTwo.Manage.MacRight.Sys_Mac_basicInfo" %>

<%@ Register src="../../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../Css/main.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>
    <script src="../../js/Sys_Mac_BasicInfo.js" type="text/javascript"></script>
    
    <style type="text/css">

        form
        {
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
        }

        table
        {
            vertical-align:middle;
            border:1px solid #73a4f6;
            border-collapse:collapse;
            color: #15428B;
        }
              
        table td
        {
            border:1px solid #73a4f6;
            padding:3px 3px 3px 3px;
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
        
        .more
        {
            cursor:pointer;
          
        }
 
    </style>
</head>
<body style="background-color:#e5f6fb">
    <form id="form1" runat="server">

      <div style=" padding-top:10px;">
         <table cellpadding="0" cellspacing="0" width="100%" border="0">
           <tr>
                <td align="right"  style="width:140px; padding-right:0px">
                    MAC</td>
                <td>
                    <asp:TextBox ID="txtMac" runat="server" ReadOnly="true" CssClass="text"></asp:TextBox>
                </td>
                <td align="right" style="width:140px;" >
                    姓名</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" ReadOnly="true" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    身份證號</td>
                <td style="width:200px">
                    <asp:TextBox ID="txtUserId" runat="server" ReadOnly="true" CssClass="text"></asp:TextBox>
                </td>
                 <td align="right">
                   性別</td>
                <td>
                    <asp:TextBox ID="txtSex" runat="server" CssClass="text" ReadOnly="true" ></asp:TextBox> 
                   
                </td>
 
            </tr>
            <tr>
                <td colspan='4' valign="top">
                    <div runat="server" id='programme'></div>
                </td>
            </tr>
            <tr>
                <td colspan='2' valign="top">
                    <div runat="server" id='movie' >
                    
                    </div>
                </td>
                <td colspan='2' valign="top">
                    <div runat="server" id='play'>
                    
                    </div>
                </td>
            </tr>
            
            <tr>
                <td colspan='2' valign="top">
                    <div runat="server" id='music'>
                    
                    </div>
                </td>
                <td  colspan='2' valign="top">
                    <div id="photo" runat="server">
                       
                    </div>
                </td>
            </tr>
         </table>
    </div>
    
    <div id="WinMore" title="  更多信息"  collapsible="false" minimizable="false" maximizable="false" class="divStyle" style="height:75%">
               <div region="center" border="false"  class="subdivStyle" style="height:100%;background-color:#e5f6fb">
                    <iframe id="subFrame" allowtransparency=true  name="subFrame" scrolling="no" frameborder="0"  src="" style="width:100%;height:100%;"></iframe>
               </div>   
     </div>
     
     
      <uc1:IsLogin ID="IsLogin1" runat="server" />
     
     
    </form>
</body>
</html>
