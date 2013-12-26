<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Mac_Basic_More.aspx.cs" Inherits="ThreeNetTwo.Manage.MacRight.Sys_Mac_Basic_More" %>

<%@ Register src="../../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link href="../../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>
    <script src="../../js/Sys_Mac_Basic_More_Search.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('#txtplaydate').datebox({
                formatter: function(date) {
                    var y = date.getFullYear();
                    var m = date.getMonth() + 1;
                    var d = date.getDate();
                    return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                }
            });

            $('#txtAddDate').datebox({
                formatter: function(date) {
                    var y = date.getFullYear();
                    var m = date.getMonth() + 1;
                    var d = date.getDate();
                    return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                }
            });

            $('#txtDate').datebox({
                formatter: function(date) {
                    var y = date.getFullYear();
                    var m = date.getMonth() + 1;
                    var d = date.getDate();
                    return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                }
            });

            $('#txtMdate').datebox({
                formatter: function(date) {
                    var y = date.getFullYear();
                    var m = date.getMonth() + 1;
                    var d = date.getDate();
                    return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                }
            });
        });
    </script>
    
    <style type="text/css">
    
        form
        {
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
        }

        #search table
        {
            vertical-align:middle;
           
            border-collapse:collapse;
            color: #15428B;
        }
            
        #search table td
        {
    
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
	        width: 260px;
            height: 18px;
            border: 1px solid #93bee2;
            font-size: 9pt;
            font-style: normal;
        }
        
        .PageButton td
        {
        	border:1px solid #53bdcb;
        }


    </style>  
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table id='search' width="100%" border="0" cellpadding="0" cellspacing="0"  class="gvTableStyle">
                      <tr>
                                   <td width="90%" valign="middle" >
                                        <table  width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr id ='channel' runat="server">
                                                <td align="right">
                                                  <asp:Label ID="lblClass" runat="server" Text="所屬頻道"></asp:Label>
                                                </td>
                                                <td align="left">
                                                     <asp:DropDownList ID="ddlClass" runat="server" CssClass="text" Width="172px" Height="23px" >
                                                     </asp:DropDownList>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblName" runat="server" Text="節目名稱"></asp:Label>    
                                                </td>
                                                   
                                                <td align="left">
                                                   
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="text" Width="170px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id='Channeldate' runat="server">
                                                <td align="right">
                                                    <asp:Label ID="lblPlayDate" runat="server" Text="演出日期"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtplaydate" runat="server" CssClass="text" ReadOnly="true" Width="170px"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblAddDate" runat="server" Text="收藏日期"></asp:Label>
                                                </td>
                                                   
                                                <td align="left">
                                                    <asp:TextBox ID="txtAddDate" runat="server"  CssClass="text" ReadOnly="true"  Width="170px"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr id='Movie' runat="server">
                                                <td align="right">
                                                     <asp:Label ID="lblMovie" runat="server" Text="電影名稱"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMovieName" runat="server" CssClass="text"  Width="170px"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblDate" runat="server" Text="收藏日期"></asp:Label>
                                                </td>
                                                   
                                                <td align="left">
                                                    <asp:TextBox ID="txtDate" runat="server"  CssClass="text" ReadOnly="true"  Width="170px"></asp:TextBox>
                                                </td>
                                            </tr> 
                                            
                                            <tr id="trMusic" runat="server">
                                               <td align="right">
                                                    <asp:Label ID="lblMname" runat="server" Text="音樂名稱"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMname" runat="server" CssClass="text" Width="170px"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblMaddDate" runat="server"  Text="收藏日期"></asp:Label>
                                                </td>
                                                   
                                                <td align="left">
                                                    <asp:TextBox ID="txtMdate" runat="server" ReadOnly="true" CssClass="text"  Width="170px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id='trdlMusic' runat="server">
                                               <td align="right">
                                                   <asp:Label ID="lblPhoto" runat="server" Text="所屬專輯"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlIistClass" runat="server" Width="172px" Height="23px" >
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                               
                                        </table>
                                    </td>
                             <td  align="right" style="padding-right:20px; padding-top:10px">
                               <div class="imgBtnSel" id="btnSel" style="line-height:22px" runat="server">
                                    查詢  
                                </div>
                           </td>

                       </tr>
                       <tr>
                             <td colspan='2' style="padding-top:10px"></td>
                       </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="Sys_GvMac" runat="server"  AutoGenerateColumns="False" 
                                    Width="100%" CellPadding="4" BorderWidth="0px" GridLines="Vertical" 
                                    BorderStyle="None" onrowdatabound="Sys_GvMac_RowDataBound" AllowPaging="True"  PageSize="5"
                                    onpageindexchanging="Sys_GvMac_PageIndexChanging">
                                    <PagerSettings PageButtonCount="4" />
                                    <Columns>
                                      <asp:BoundField HeaderText="所屬頻道" DataField="ChannelDesc"  HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="130px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="130px"/>
                                        </asp:BoundField>
                                    
                                       <asp:BoundField HeaderText="收藏節目" DataField="ProGramName"  HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="180px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="180px"/>
                                         </asp:BoundField>
                                         
                                                                
                                         <asp:BoundField HeaderText="演出日期" DataField="PlayingDate" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="80px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="80px"/>
                                         </asp:BoundField>
                                         <asp:BoundField HeaderText="演出時間" DataField="PlayingTime" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="80px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="80px"/>
                                         </asp:BoundField>
                                          <asp:BoundField HeaderText="收藏時間" DataField="CreatDate" HtmlEncode="False" 
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
                        <tr>
                             <td colspan='2' style="padding-top:10px"></td>
                       </tr>
                        <tr>
                            <td colspan='2'>
                                 <asp:GridView ID="Gvother" runat="server"  AutoGenerateColumns="False" 
                                    Width="100%" CellPadding="4" BorderWidth="0px" GridLines="Vertical" 
                                    BorderStyle="None"  AllowPaging="True"  PageSize="5" 
                                     onrowdatabound="Gvother_RowDataBound" onpageindexchanging="Gvother_PageIndexChanging" 
                                     >
                                    <PagerSettings PageButtonCount="4" />
                                    <Columns>
                                       <asp:BoundField HeaderText="節目名稱" DataField="SCJM"  HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="150px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="150px"/>
                                         </asp:BoundField>                       

                                          <asp:BoundField HeaderText="收藏時間" DataField="CreatDate" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="120px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="120px"/>
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
                        <tr>
                             <td colspan='2' style="padding-top:10px"></td>
                       </tr>
                        <tr>
                          <td colspan='3'>
                           <asp:GridView ID="gvMusicPhoto" runat="server"  AutoGenerateColumns="False" 
                                    Width="100%" CellPadding="4" BorderWidth="0px" GridLines="Vertical" 
                                    BorderStyle="None"  AllowPaging="True"  PageSize="5" 
                                  onpageindexchanging="gvMusicPhoto_PageIndexChanging" 
                                  onrowdatabound="gvMusicPhoto_RowDataBound" >
                                    <PagerSettings PageButtonCount="4" />
                                    <Columns>
                                     <asp:BoundField HeaderText="所屬專輯" DataField="OwnClass" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="120px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="120px"/>
                                         </asp:BoundField> 
                                       <asp:BoundField HeaderText="節目名稱" DataField="SCJM"  HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="150px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="150px"/>
                                         </asp:BoundField>                       
   
                                          <asp:BoundField HeaderText="收藏時間" DataField="CreatDate" HtmlEncode="False" 
                                            HtmlEncodeFormatString="False">
                                            <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="120px"/>
                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="120px"/>
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
    
<%--    <div id="Win"  title="  查詢" collapsible="false" minimizable="false" maximizable="false" class="divStyle" style="height:75%">
               <div region="center" border="false" class="subdivStyle" style="height:60%">
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
         </div>--%>
         <asp:TextBox ID="txtFlag" runat="server" CssClass="hide"></asp:TextBox>
         <asp:TextBox ID="txtMac" runat="server" CssClass="hide"></asp:TextBox>
         
    <uc1:IsLogin ID="IsLogin1" runat="server" />
         
    </form>
   
</body>
</html>
