<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_MacRight_Movie.aspx.cs" Inherits="ThreeNetTwo.Manage.MacRight.Sys_MacRight_Movie" %>

<%@ Register src="../../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head  runat="server">
    <title></title>
    <link href="../../Css/GvStyle.css" rel="stylesheet" type="text/css" />
     <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/Sys_Mac_RightSeach.js" type="text/javascript"></script>
        
   
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>
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

        table
       
        {
            vertical-align:middle;
           
            border-collapse:collapse;
            color: #15428B;
        }
    
        table td
        {
    
            padding:6px 6px 6px 6px;
        }
        
        .PageButton td
        {
        	border:1px solid #53bdcb;
        }
        
        .base table
        {
            vertical-align:middle;
            border-collapse:collapse;
            color: #15428B;
        }
            
        .base table td
        {
    
            padding:3px 3px 3px 3px;
        }
    </style>
</head>
<body scroll="no">
    <form id="form1" runat="server">
    <div>
     <table width="100%" border="0" cellpadding="0" cellspacing="0" id="GVTable" class="gvTableStyle">
                    <tr>
                        <td >
                              <table id="base" cellpadding="0" cellspacing="0" width="100%" border="0">
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
                              </table>
                        
                        </td>
                    
                    </tr>
     
                      <tr style="height:22px">
                         <td  align="right" style="padding-right:15px; height:22px">
                               <div class="imgBtnSel" id="btnSel" style="line-height:22px" runat="server">
                                    查詢  
                                </div>
                           </td>

                       </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="Sys_GvMac" runat="server"  AutoGenerateColumns="False" 
                                    Width="100%" CellPadding="4" BorderWidth="0px" GridLines="Vertical" 
                                    BorderStyle="None" onrowdatabound="Sys_GvMac_RowDataBound" AllowPaging="True"  PageSize="9"
                                    onpageindexchanging="Sys_GvMac_PageIndexChanging">
                                    <PagerSettings PageButtonCount="4" />
                                    <Columns>
                                         <asp:BoundField HeaderText="電影名稱" DataField="MovieName" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="150px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="150px"/>
                                         </asp:BoundField>
                                         
                                         <asp:BoundField HeaderText="開始日期" DataField="StartDate" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="150px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="150px"/>
                                         </asp:BoundField> 
                                         
                                         <asp:BoundField HeaderText="結束日期" DataField="EndDate" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="150px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="150px"/>
                                         </asp:BoundField>
                                         
                                          <asp:BoundField HeaderText="剩餘天數" DataField="LastDate" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="150px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="150px"/>
                                         </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle HorizontalAlign="Center" BackColor="#d1ecfc" CssClass="PageButton"  />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <EditRowStyle BackColor="#2461BF"  />
                                    <AlternatingRowStyle  CssClass="GridAlternatingRowStyle"/>
                                    
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
    </div>
          <div id="Win" title="  查詢" collapsible="false" minimizable="false" maximizable="false" class="divStyle" style="height:75%">
               <div region="center" border="false" class="subdivStyle" style="height:89%">
                    <iframe id="subFrame" name="subFrame" scrolling="no" frameborder="0"  src="" style="width:100%;height:100%;"></iframe>
               </div> 
           <div region="south" border="false" style="text-align: center; vertical-align:middle; height: 25px; line-height: 25px;">                
                <table cellpadding="0" border="0" cellspacing="0" width="100%">
                    <tr>
                    <td align="right" style="padding-top:15px;">
                             <div id="btnOk"  class="BtnYesStyle">確定</div>
                        </td>
                         <td align="left" style="padding-left:15px;padding-top:15px;">
                             <div id="btnCancel"  class="BtnNoStyle">取消</div>
                    </td></tr>
                 </table> 
           </div>    
         </div>
        <asp:TextBox ID="txtType" runat="server" CssClass="hide"></asp:TextBox>
        <asp:TextBox ID="txtMacValue" runat="server" CssClass="hide"></asp:TextBox>
        <asp:TextBox ID="txtMacId" runat="server" CssClass="hide"></asp:TextBox>
        <asp:TextBox ID="txtMid" runat="server" CssClass="hide"></asp:TextBox>

    <uc1:IsLogin ID="IsLogin1" runat="server" />

    </form>
 
</body>
</html>
