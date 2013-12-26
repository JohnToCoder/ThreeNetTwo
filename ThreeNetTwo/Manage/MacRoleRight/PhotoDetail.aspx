<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoDetail.aspx.cs" Inherits="ThreeNetTwo.Manage.MacRoleRight.PhotoDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.easyui.pack.js" type="text/javascript"></script>
    <script src="../../js/Sys_MacRoleDetailRight_Photo.js" type="text/javascript"></script>
    
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
            padding: 3px;
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
        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="gvTableStyle">
            <tr>
                <td align="right">
                    <table border="0" cellpadding="0" cellspacing="1" align="right" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" style="padding-right: 15px">
                                <div class="imgBtnSel" id="btnSel" style="line-height: 22px" runat="server">
                                    查詢
                                </div>
                            </td>
                            <td align="right" width="60">
                                <div class="imgBtnReturn" id="btnReturn" runat="server">
                                    返回
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GvPhotoDetail" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                        PageSize="11" OnRowDataBound="GvPhotoDetail_RowDataBound" OnPageIndexChanging="GvPhotoDetail_PageIndexChanging">
                        <PagerSettings PageButtonCount="4" />
                        <Columns>
                            <asp:BoundField HeaderText="SubID" DataField="SubID" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="hide" HorizontalAlign="Left" />
                                <ItemStyle CssClass="hide" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Flag" DataField="Flag" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="hide" HorizontalAlign="Left" />
                                <ItemStyle CssClass="hide" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="名稱" DataField="PictureCatalog" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="45%" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="45%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="詳細名稱" DataField="Name" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" Width="45%" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="45%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="是否授權">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="GvHeader" HorizontalAlign="Center" Width="10%" />
                                <ItemStyle CssClass="GvItem" HorizontalAlign="Center" Width="10%" />
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
    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtParentIndex" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtRightId" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtMenuTypeId" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtRoleId" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtRoleName" runat="server" CssClass="hide"></asp:TextBox>
    <asp:TextBox ID="txtKeyValue" runat="server" CssClass="hide"></asp:TextBox>
    </form>
</body>
</html>
