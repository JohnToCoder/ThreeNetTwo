<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_MyMovie.aspx.cs" Inherits="ThreeNetTwo.Movie.MD_MyMovie" %>

<%@ Register Src="../IsLogin.ascx" TagName="IsLogin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的劇場</title>
    <link href="../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../Css/Common.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/Common.js" type="text/javascript"></script>

    <script src="../js/MD_MyMovie.js" type="text/javascript"></script>

    <script src="../js/jquery.lazyload.js" type="text/javascript"></script>
    
</head>
<body style="overflow-x: hidden; overflow-y: visible; word-break: break-all; word-wrap: break-word">
    <form id="form1" runat="server">
    <div class="tab">
        <div class="tab_b" id="tab_a1" style="display: block;">
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
                                                            <span class="BText">你当前的位置</span>：[電影劇場]-[我的電影]
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
                                <td width="8" background="../images/table/tab_12.gif">
                                    &nbsp;
                                </td>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="Gv_Movie" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                                                    PageSize="13" OnPageIndexChanging="Gv_Movie_PageIndexChanging" OnRowDataBound="Gv_Movie_RowDataBound">
                                                    <PagerSettings PageButtonCount="4" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="劇照">
                                                            <ItemTemplate>
                                                                <asp:Image ID="ImgUrl" runat="server" ImageAlign="AbsMiddle" CssClass="imgStyle"
                                                                    Height="50px" Width="100px" ToolTip="點擊瀏覽大圖" ImageUrl='<%# Eval("ImgPath")%>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="100px" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="電影名稱" DataField="Name" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="100px" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="URL" HeaderText="播放地址">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="150px" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Comeout" HeaderText="上映時間">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="ServiceID" HeaderText="服務器ID">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Creator" HeaderText="收藏人">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreatDate" HeaderText="收藏時間">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle HorizontalAlign="Center" BackColor="#d1ecfc" CssClass="PageButton" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td background="../images/table/tab_15.gif" width="8">
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
            <div id="ShowImage" style="padding: 0px; border: 2px solid #53bdcb; width: 650px;
                height: 400px; display: none; position: fixed; top: 10%; left: 10%">
                <asp:Image runat="server" ID="imgBig" Width="650px" Height="400px" CssClass="imgStyle"
                    ImageUrl="" ToolTip="點擊預覽小圖" />
            </div>
            <div id="WinSelForMovie" title="  查詢" collapsible="false" minimizable="false" maximizable="false"
                style="padding: 15px; background: #fafafa; width: 99%; display: none; overflow: hidden">
                <div region="center" border="false" style="vertical-align: middle; background: #fff;
                    border: 1px solid #ccc; width: 98%;">
                    <table cellpadding="0" cellspacing="0" width="100%" border="0" class="table">
                        <tr id="trImageName" runat="server">
                            <td align="right" class="td">
                                <span>電影名稱</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtMovieName" runat="server" Text="" CssClass="text"></asp:TextBox>
                            </td>
                            <td align="right" class="td">
                                <span>播放地址</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtUrl" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trPicCata" runat="server">
                            <td align="right" class="td">
                                <span>上映時間</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtComeOut" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                            <td align="right" class="td">
                                <span>收藏人</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtCreator" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="td">
                                <span>收藏時間</span>
                            </td>
                            <td  class="td">
                                <asp:TextBox ID="txtCreatDate" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                            <td align="right" class="td">
                                <span>服務器ID</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtServiceID1" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
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
        </div>
        <div class="tab_b" id="tab_a2" style="display: none;">
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
                                                            <span class="BText">你当前的位置</span>：[電影劇場]-[我的電視劇]
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="54%">
                                                <table border="0" align="right" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="60">
                                                            <div class="imgBtnSel" id="btnSelForTV" runat="server">
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
                                <td width="8" background="../images/table/tab_12.gif">
                                    &nbsp;
                                </td>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvTV" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                    BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                                                    PageSize="13" OnPageIndexChanging="gvTV_PageIndexChanging" OnRowDataBound="gvTV_RowDataBound">
                                                    <PagerSettings PageButtonCount="4" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="劇照">
                                                            <ItemTemplate>
                                                                <asp:Image ID="ImgUrl" runat="server" ImageAlign="AbsMiddle" CssClass="imgStyle"
                                                                    Height="50px" Width="100px" ToolTip="點擊瀏覽大圖" ImageUrl='<%# Eval("ImgPath")%>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="100px" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="電視劇名稱" DataField="TVPlayName" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="100px" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px" />
                                                        </asp:BoundField>
                                                         <asp:BoundField HeaderText="電視分集" DataField="OrderID" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="100px" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="100px" />
                                                        </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="TVPlayURL" HeaderText="播放地址">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="150px" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Comeout" HeaderText="上映時間">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="ServiceID" HeaderText="服務器ID">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Creator" HeaderText="收藏人">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreatDate" HeaderText="收藏時間">
                                                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle HorizontalAlign="Center" BackColor="#d1ecfc" CssClass="PageButton" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <AlternatingRowStyle CssClass="GridAlternatingRowStyle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td background="../images/table/tab_15.gif" width="8">
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
            <div id="WinSelForTV" title="  查詢" collapsible="false" minimizable="false" maximizable="false"
                style="padding: 15px; background: #fafafa; width: 99%; height: 99%; display: none;
                overflow: hidden">
                <div region="center" border="false" style="background: #fff; border: 1px solid #ccc;
                    width: 98%;">
                    <table cellpadding="0" cellspacing="0" width="100%" border="0" class="table">
                        <tr>
                            <td align="right" class="td">
                                <span>電視劇名稱</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtTVName" runat="server" Text="" CssClass="text"></asp:TextBox>
                            </td>
                            <td align="right" class="td">
                                <span>播放地址</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtTVurl" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr2" runat="server">
                            <td align="right" class="td">
                                <span>上映時間</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtTVcomeout" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                            <td align="right" class="td">
                                <span>收藏人</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtTVcreator" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="td">
                                <span>收藏時間</span>
                            </td>
                            <td  class="td">
                                <asp:TextBox ID="txtTVcreatDate" runat="server" CssClass="text"></asp:TextBox>
                            </td>                            
                           <td align="right" class="td">
                                <span>服務器ID</span>
                            </td>
                            <td class="td">
                                <asp:TextBox ID="txtServiceID" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div region="south" border="false" style="text-align: center; vertical-align: middle;
                    height: 25px; line-height: 25px;">
                    <table cellpadding="0" border="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right" style="padding-top: 5px;">
                                <div id="btnSelYesForTV" class="BtnYesStyle">
                                    確定</div>
                            </td>
                            <td align="left" style="padding-left: 15px; padding-top: 5px;">
                                <div id="btnCancelForTV" class="BtnNoStyle">
                                    取消</div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="ShowTVImg" style="padding: 0px; border: 2px solid #53bdcb; width: 650px;
                height: 400px; display: none; position: fixed; top: 10%; left: 10%">
                <asp:Image runat="server" ID="ImgBigForTV" Width="650px" Height="400px" CssClass="imgStyle"
                    ImageUrl="" ToolTip="點擊預覽小圖" />
            </div>
        </div>
        <asp:TextBox ID="txtFlag" runat="server" CssClass="hide"></asp:TextBox>
    </div>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
