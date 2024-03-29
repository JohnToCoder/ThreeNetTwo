﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_MacRight.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_MacRight" %>

<%@ Register src="../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/Sys_Mac_Right.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color:#e5f6fb;
            
        }
        
        form
        {
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
            
        }

        .borderset
        {
	        border: 1px solid #93bee2;
        }     
            

        .STYLE1
        {
            font-size: 16px;
            text-align:center;
            height:40px;
            width:151px;
            background-image:url('../images/leftBg.png');
            
        }
        
        .STYLE1:hover
        {
            font-size: 16px;
            text-align:center;
            height:40px;
            width:151px;
            background-image:url('../images/LeftHoverbg.png');
        }
        

        
        .ClickBg
        {
        	left:3px;
        	font-size: 16px;
            text-align:center;
            height:40px;
            width:151px;
        	background:url('../images/leftBgClick.png');
        }
        
        
        .STYLE3
        {
            font-size: 12px;
            color: #033d61;
        }
        .menu_title 
        {
    
        }
        .menu_title2 SPAN
        {

        }
        

        .text
        {
	        width: 150px;
            height: 18px;
            font-size: 9pt;
            font-style: normal;
            border: 0px solid;
            width:200px;
            color:#15428B;
            font-size:14px;
        }

        .borderset
        {
	        border: 1px solid #93bee2;
        }
  
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color:#e5f6fb">
       <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color:#e5f6fb">
      
             <tr>
                <td align="left" style="width:18%; height:100%;background-color:#e5f6fb" valign="top">
                 <div id="leftDiv" style="height:100%; " runat="server">
  
                 </div>

                </td>
                <td valign="top" style="height:100%;background-color: #e5f6fb">
                     <iframe id="frameShow" name="subFrame" allowtransparency=true  scrolling="no" frameborder="0"    src="" style="width:100%; background-color:#e5f6fb;"></iframe>
                </td>
            </tr>
   
        </table>
        <asp:TextBox ID="txtId" runat="server" CssClass="hideCss"></asp:TextBox>
        <asp:TextBox ID="txtRight" runat="server" CssClass="hideCss"></asp:TextBox>
        <asp:TextBox ID="txtMacId" runat="server" CssClass="hideCss"></asp:TextBox>
    </div>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
