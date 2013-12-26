<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_MyPhotos.aspx.cs" Inherits="ThreeNetTwo.Photo.MD_MyPhotos" %>

<%@ Register src="../IsLogin.ascx" tagname="IsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>我的相冊</title>
    <link href="../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/ShowImage.js" type="text/javascript"></script>
    <script src="../js/MD_MyPhoto.js" type="text/javascript"></script>
    <script src="../js/jquery.lazyload.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
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
                                                    <span class="BText">你当前的位置</span>：[相簿欣賞]-[我的相冊]
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="60">
                                                <div class="imgBtnSel" id="btnSel" runat="server">
                                                       查詢  
                                                    </div></td>
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
                        <td width="8" background="../images/table/tab_12.gif">
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
                                <tr>
                                    <td>
                                        <asp:GridView ID="Gv_MyPhoto" runat="server"  AutoGenerateColumns="False" 
                                            Width="100%" CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None"
                                            AllowPaging="True" PageSize="13" onpageindexchanging="Gv_Replace_PageIndexChanging">
                                            <PagerSettings PageButtonCount="4" />
                                            <Columns>
                                                
                                                <asp:BoundField DataField="ID">
                                                    <HeaderStyle CssClass="hide" Width="0" />
                                                    <ItemStyle CssClass="hide" Width="0"/>
                                                </asp:BoundField>
                                                 
                                                 <asp:TemplateField HeaderText="圖片預覽">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" CssClass="imgStyle" Height="50px"  Width="100px" runat="server" ImageAlign="AbsMiddle" ImageUrl='<%# Eval("ImaPath")%>' ToolTip="點擊瀏覽大圖"/>
                                                    </ItemTemplate>   
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="54px"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="54px"/>
                                                 </asp:TemplateField>
                                                 
                                                 <asp:BoundField HeaderText="圖片名" DataField="imadesc" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="20%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="20%"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="圖片類型" DataField="PictureCatalog" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="18%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="18%"/>
                                                 </asp:BoundField>
                                                  <asp:BoundField HeaderText="服務器ID" DataField="ServiceID" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="18%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="18%"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="收藏者" DataField="UserCode" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left" Width="18%"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="18%"/>
                                                 </asp:BoundField>
                                                 
                                                 <asp:BoundField HeaderText="收藏時間" DataField="CreatDate" HtmlEncode="False" 
                                                    HtmlEncodeFormatString="False">
                                                    <HeaderStyle  CssClass="GvHeader" HorizontalAlign="Left"/>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left"/>
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
                        <td width="8" background="../images/table/tab_15.gif">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td height="20" background="../images/table/tab_19.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12" height="20">
                            <img src="../images/table/tab_18.gif" width="12" height="20" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td width="16">
                            <img src="../images/table/tab_20.gif" width="16" height="20" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <div id="ShowImage" class="showdivStyle">
        <asp:Image runat="server" id="imgBig" Width="650px" Height="400px" cssClass="imgStyle" ImageUrl="" ToolTip="點擊預覽小圖"/>
    </div>
    
    <div id="WinSel" title="  查詢" collapsible="false" minimizable="false" maximizable="false"
        style="padding: 15px; background: #fafafa; width: 99%; height: 93%; display: none;
        overflow: hidden">
        <div region="center" border="false" style="background: #fff; border: 1px solid #ccc;
            width: 98%; height: 93%;">
            <iframe id="subFrameSel" name="subFrameSel" scrolling="no" frameborder="0" src=""
                style="width: 100%; height: 100%;"></iframe>
        </div>
        <div region="south" border="false" style="text-align: center; vertical-align: middle;
            height: 25px; line-height: 25px;">
            <table cellpadding="0" border="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" style="padding-top: 5px;">
                        <div id="btnSelYes" class="BtnYesStyle">
                            確定</div>
                    </td>
                    <td align="left" style="padding-left: 15px; padding-top: 5px;">
                        <div id="btnCancel2" class="BtnNoStyle">
                            取消</div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="hide"></asp:TextBox>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
