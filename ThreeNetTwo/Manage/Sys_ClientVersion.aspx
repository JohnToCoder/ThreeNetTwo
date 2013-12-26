<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_ClientVersion.aspx.cs" Inherits="ThreeNetTwo.Manage.Sys_ClientVersion" %>

<%@ Register src="../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>
    <script src="../js/Sys_ClientVersion.js" type="text/javascript"></script>
    <link href="../Css/jquery-ui-1.8rc3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-ui-1.8rc3.custom.js" type="text/javascript"></script>
    <script type="text/javascript">
            $(document).ready(function() {

                $.post('../ashx/Sys_ClientVersion.ashx', function(data) {
                    var arr = data.split('|');
                    $('#txtMac').autocomplete({ source: arr });
                });

            });
    </script>
    <style type="text/css">
        #TabSearch 
        {
            vertical-align:middle;
            border:1px solid #73a4f6;
            border-collapse:collapse;
            color: #15428B;
        }
              
       #TabSearch  td
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
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="30" background="../images/table/tab_05.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12" height="30">
                            <img src="../images/table/tab_03.gif" width="12" height="30" />
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="46%" valign="middle">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="5%">
                                                    <div align="center">
                                                        <img src="../images/table/tb.gif" width="16" height="16" /></div>
                                                </td>
                                                <td width="95%" class="NText">
                                                    <span class="BText">你当前的位置</span>：[同步管理]-[客戶端系統更新Log]
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="60">
                                                    <div class="imgBtnSel" id="btnSel" style="line-height:22px" runat="server">
                                                       查詢  
                                                    </div>
                                               </td>
                                              
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="16">
                            <img src="../images/table/tab_07.gif" width="16" height="30" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="8" style="background-image:url('../images/table/tab_12.gif')">
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GvClient" runat="server"  AutoGenerateColumns="False" 
                                            Width="100%" CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None"
                                            AllowPaging="True" PageSize="13" onrowdatabound="GvClient_RowDataBound" onpageindexchanging="GvClient_PageIndexChanging"
                                           >
                                            <PagerSettings PageButtonCount="4" />
                                            <Columns>
                                                <asp:BoundField HeaderText="MAC地址" DataField="MAC" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="130px"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="130px"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="客戶端主機名稱" DataField="UserName" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="120px"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="120px"/>
                                                 </asp:BoundField>
                                                 
                                                  <asp:BoundField HeaderText="版本號" DataField="Version" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="100px"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="版本描述" DataField="VerDesc" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left"  Width="100px"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left"  Width="100px"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="升級日期" DataField="CreatDate" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="100px"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="版本日期" DataField="VerDate" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="100px"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px"/>
                                                 </asp:BoundField>
                                                  <asp:BoundField HeaderText="發布日期" DataField="pubDate" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left"  Width="100px"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px"/>
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
                        </td>
                        <td width="8" style="background-image:url('../images/table/tab_15.gif')">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td height="20"  style="background-image:url('../images/table/tab_19.gif')">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12" height="20">
                            <img src="../images/table/tab_18.gif" width="12" height="20" alt="" />
                        </td>
                        <td>
                            &nbsp;
                            </td>
                        <td width="16">
                            <img src="../images/table/tab_20.gif" width="16" height="20" alt="" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
    
        <div id="Win" title="  查詢" collapsible="false" minimizable="false" maximizable="false" class="divStyle" style="height:80%;">
               <div region="center" border="false" class="subdivStyle" style="height:70%">
               
                <table cellpadding="0" cellspacing="0" width="100%" border="0" id="TabSearch">
                   <tr id="trMAC" runat="server">
                        <td align="right">
                            地址</td>
                        <td>
                            <asp:TextBox ID="txtMac" runat="server" Text="" CssClass="text"></asp:TextBox>
                        </td>
                        <td align="right">
                            客戶端主機名稱</td>
                        <td>
                            <asp:TextBox ID="txtMeno" runat="server" Text="" CssClass="text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            版本號</td>
                        <td>
                            <asp:TextBox ID="txtVerName" runat="server" Text="" CssClass="text"></asp:TextBox>
                        </td>
                          <td align="right">
                           版本描述</td>
                        <td>
                            <asp:TextBox ID="txtVerDesc" runat="server" Text="" CssClass="text"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    <%--<iframe id="subFrame" name="subFrame" scrolling="no" frameborder="0"  src="" style="width:91%;height:45%;z-index:0;position:absolute;"></iframe>--%>
               </div> 
               <div region="south" border="false" style="text-align: center; vertical-align:middle; height: 25px; line-height: 25px;">                
                    <table cellpadding="0" border="0" cellspacing="0" width="100%">
                        <tr><td align="right" style="padding-top:15px;">
                                 <div id="btnOk"  class="BtnYesStyle">確定</div>
                            </td>
                             <td align="left" style="padding-left:15px;padding-top:15px;">
                                 <div id="btnCancel"  class="BtnNoStyle">取消</div>
                        </td></tr>
                     </table> 
               </div>    
          </div>
            <asp:TextBox ID="txtUl" runat="server" CssClass="hideCss"></asp:TextBox>
           <asp:TextBox ID="txtKeyValue" runat="server" CssClass="hideCss"></asp:TextBox>
           <asp:TextBox ID="txtSuccess" runat="server" CssClass="hideCss"></asp:TextBox>
           <asp:TextBox ID="txtPageIndex" runat="server" CssClass="hide"></asp:TextBox>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
