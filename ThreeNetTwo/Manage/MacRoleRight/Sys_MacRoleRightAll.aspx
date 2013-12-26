<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_MacRoleRightAll.aspx.cs"
    Inherits="ThreeNetTwo.Manage.MacRoleRight.Sys_MacRoleRightAll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../../js/Sys_MacRoleRightSearch.js" type="text/javascript"></script>

    <style type="text/css">
        form
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
        }
        table
        {
            vertical-align: middle;
            border-collapse: collapse;
            color: #15428B;
        }
        table td
        {
            padding: 4px;
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
            cursor: pointer;
        }
        .text
        {
            width: 260px;
            height: 18px;
            border: 0px solid;
            font-size: 9pt;
            font-style: normal;
        }
        .PageButton td
        {
            border: 1px solid #53bdcb;
        }
    </style>
</head>
<body scroll="no" style="background-color: #e5f6fb;">
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" id="GVTable" class="gvTableStyle">
            <tr>
                <td width="46%" valign="middle">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="5%">
                                <div align="center">
                                    <img src="../../images/table/tb.gif" width="16" height="16" /></div>
                            </td>
                            <td width="95%" class="NText">
                                <asp:Label ID="lblRoleName" runat="server" CssClass="text"></asp:Label>
                                的資料權限
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="right" style="padding-right: 15px">
                    <div class="imgBtnSel" id="btnSel" style="line-height: 22px" runat="server">
                        查詢
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GvName" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                        PageSize="10" OnPageIndexChanging="GvName_PageIndexChanging" OnRowDataBound="GvName_RowDataBound">
                        <PagerSettings PageButtonCount="4" />
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="hide" HorizontalAlign="Left" />
                                <ItemStyle CssClass="hide" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Flag" DataField="Flag" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="hide" HorizontalAlign="Left" />
                                <ItemStyle CssClass="hide" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="MenuType" DataField="MenuTypeID" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="hide" HorizontalAlign="Left" />
                                <ItemStyle CssClass="hide" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="隸屬模塊" DataField="MenuTypeName" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="120px" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="名稱" DataField="Name" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="680px" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="680px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="詳細資料">
                                <ItemTemplate>
                                    <a href="javascript:DataDetail(<%# Eval("ID")%>,<%# Eval("MenuTypeID")%>)">Detail</a>
                                </ItemTemplate>
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Center" Width="80px" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Center" Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否授權">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" oncheckedchanged="CheckBox1_CheckedChanged" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Center" Width="80px" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Center" Width="80px" />
                            </asp:TemplateField>
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
    <div id="Win" title="  查詢" collapsible="false" minimizable="false" maximizable="false"
        class="divStyle" style="height: 75%">
        <div region="center" border="false" class="subdivStyle" style="height: 70%">
            <iframe id="subFrame" name="subFrame" scrolling="no" frameborder="0" src="" style="width: 100%;
                height: 100%;"></iframe>
        </div>
        <div region="south" border="false" style="text-align: center; vertical-align: middle;
            height: 25px; line-height: 25px;">
            <table cellpadding="0" border="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" style="padding-top: 15px;">
                        <div id="btnOk" class="BtnYesStyle">
                            確定</div>
                    </td>
                    <td align="left" style="padding-left: 15px; padding-top: 15px;">
                        <div id="btnCancel" class="BtnNoStyle">
                            取消</div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:TextBox ID="txtRoleID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtMenuTypeID" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtKeyValue" runat="server" CssClass="hide"></asp:TextBox>
    </form>
</body>
</html>
