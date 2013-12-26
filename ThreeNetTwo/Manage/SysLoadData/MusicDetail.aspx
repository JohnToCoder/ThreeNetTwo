<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MusicDetail.aspx.cs"
    Inherits="ThreeNetTwo.Manage.SysLoadData.MusicDetail" %>

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
    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
        <tr>
            <td>
                <asp:GridView ID="GvDataDetail" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                    PageSize="12" OnPageIndexChanging="GvDataDetail_PageIndexChanging" OnRowDataBound="GvDataDetail_RowDataBound">
                    <PagerSettings PageButtonCount="4" />
                    <Columns>
                        <asp:BoundField HeaderText="" DataField="Col1" HtmlEncode="False" HtmlEncodeFormatString="False">
                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="50%"/>
                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="50%"/>
                        </asp:BoundField>
                         <asp:BoundField HeaderText="" DataField="Col2" HtmlEncode="False" HtmlEncodeFormatString="False">
                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="50%"/>
                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="50%"/>
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
    </form>
</body>
</html>
