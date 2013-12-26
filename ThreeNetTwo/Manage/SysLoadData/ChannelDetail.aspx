<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelDetail.aspx.cs"
    Inherits="ThreeNetTwo.Manage.SysLoadData.ChannelDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
            <tr>
                <td>
                    <asp:GridView ID="GvChannelDetail" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                        PageSize="11" onpageindexchanging="GvChannelDetail_PageIndexChanging" 
                        onrowdatabound="GvChannelDetail_RowDataBound">
                        <PagerSettings PageButtonCount="4" />
                        <Columns>
                            <asp:BoundField HeaderText="節目名稱" DataField="ProgramName" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="65%" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="65%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="播放日期" DataField="PlayingDate" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="20%" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="20%" />
                            </asp:BoundField>
                             <asp:BoundField HeaderText="播放時間" DataField="PlayingTime" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="15%" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="15%" />
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
    </div>
    </form>
</body>
</html>
