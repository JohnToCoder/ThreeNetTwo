<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TVPlayDetail.aspx.cs"
    Inherits="ThreeNetTwo.Manage.SysLoadData.TVPlayDetail" %>

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
                    PageSize="12" OnPageIndexChanging="GvDataDetail_PageIndexChanging" 
                    onrowdatabound="GvDataDetail_RowDataBound">
                    <PagerSettings PageButtonCount="4" />
                    <Columns>
                        <asp:BoundField HeaderText="" DataField="Col1" HtmlEncode="False" HtmlEncodeFormatString="False">
                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="25%"/>
                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="25%"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="" DataField="Col2" HtmlEncode="False" HtmlEncodeFormatString="False">
                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="25%"/>
                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="25%"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="" DataField="Col3" HtmlEncode="False" HtmlEncodeFormatString="False">
                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="25%"/>
                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="25%"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="" DataField="Col4" HtmlEncode="False" HtmlEncodeFormatString="False">
                            <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="25%"/>
                            <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="25%"/>
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
    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                               
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        
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
                                        <asp:GridView ID="GvDataDetail" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                                            PageSize="10" OnPageIndexChanging="GvDataDetail_PageIndexChanging">
                                            <PagerSettings PageButtonCount="4" />
                                            <Columns>
                                                <asp:BoundField HeaderText="電視劇詳細名稱" DataField="TVSubName" HtmlEncode="False" HtmlEncodeFormatString="False">
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
    </table>--%>
    </form>
</body>
</html>
