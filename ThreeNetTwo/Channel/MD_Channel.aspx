﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MD_Channel.aspx.cs" Inherits="ThreeNetTwo.Channel.MD_Channel" %>

<%@ Register Src="../IsLogin.ascx" TagName="IsLogin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>所有節目</title>
    <link href="../Css/GvStyle.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/jquery.easyui.pack.js" type="text/javascript"></script>

    <script src="../js/MD_Channel.js" type="text/javascript"></script> 

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
                                                    <span class="BText">你当前的位置</span>：[節目列表]-[所有節目]
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
                                                <td width="60">
                                                    <div class="imgBtnIns" id="btnIns" runat="server">
                                                        新增
                                                    </div>
                                                </td>
                                                <td width="60">
                                                    <div class="imgBtnUpd" id="btnUpd" runat="server">
                                                        修改
                                                    </div>
                                                </td>
                                                <td width="60">
                                                    <div class="imgBtnDel" id="btnDel" runat="server">
                                                        刪除
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
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6" class="gvTableStyle">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gdvCurrent" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" BorderWidth="0px" GridLines="Vertical" BorderStyle="None" AllowPaging="True"
                                            PageSize="13" OnPageIndexChanging="gdvCurrent_PageIndexChanging" OnRowDataBound="gdvCurrent_RowDataBound">
                                            <PagerSettings PageButtonCount="4" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkCheck" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="GvHeader" Width="10px" />
                                                    <ItemStyle CssClass="GvItem" Width="10px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ID" HeaderText="ID">
                                                    <HeaderStyle CssClass="hide" HorizontalAlign="Right" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="hide" HorizontalAlign="Right"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="圖標">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" CssClass="imgStyle" Height="30px" Width="70px" runat="server"
                                                            ImageAlign="AbsMiddle" ImageUrl='<%# Eval("ImgPath")%>' ToolTip="點擊瀏覽大圖" />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="GvItem" Width="70px" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ChannelDesc" HeaderText="頻道名稱">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ChannelCode" HeaderText="ChannelCode">
                                                    <HeaderStyle CssClass="hide" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="hide" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>                                               
                                                <asp:BoundField DataField="ChannelURL" HeaderText="頻道URL">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ChannelURLiPad" HeaderText="URL(iPad)">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ImgPath" HeaderText="Logo地址">
                                                    <HeaderStyle CssClass="hide" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="hide" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AreaDesc" HeaderText="地區">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" VerticalAlign="Middle" Width="30px"></HeaderStyle>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ChannelTypeDesc" HeaderText="類型">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" VerticalAlign="Middle" Width="30px"></HeaderStyle>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" Width="25px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Creator" HeaderText="創建者">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CreatDate" HeaderText="創建日期">
                                                    <HeaderStyle CssClass="GvHeader" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="GvItem" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Editor" HeaderText="修改者">
                                                    <HeaderStyle CssClass="hide" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="hide" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EditDate" HeaderText="修改日期">
                                                    <HeaderStyle CssClass="hide" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle CssClass="hide" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Detail</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href="javascript:ChannelDetail('<%# DataBinder.Eval(Container.DataItem,"ID")%>')">Detail</a>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="GvHeader" Width="10px" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="GvItem" Width="10px" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Detail</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="imgMoreInfo" id="btnMore" style="text-decoration:underline; color:Blue; cursor:pointer;">
                                                            Detail
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="GvHeader" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="GvItem" />
                                                </asp:TemplateField>         --%>                                       
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
    </table>
    <div id="ShowImage" class="showdivStyle">
        <asp:Image runat="server" ID="imgBig" Width="650px" Height="400px" CssClass="imgStyle"
            ImageUrl="" ToolTip="點擊預覽小圖" />
    </div>
    <div id="WinIns" title="  新增" collapsible="false" minimizable="false" maximizable="false"
        class="divStyle" style="padding: 15px; background: #fafafa; width: 99%; height: 99%;
        display: none; overflow: hidden">
        <div region="center" border="false" class="subdivStyle" style="background: #fff;
            border: 1px solid #ccc; width: 98%; height: 93%;">
            <iframe id="subFrameIns" name="subFrameIns" scrolling="no" frameborder="0" src=""
                style="width: 100%; height: 100%;"></iframe>
        </div>
        <div region="south" border="false" style="text-align: center; vertical-align: middle;
            height: 25px; line-height: 25px;">
            <table cellpadding="0" border="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" style="padding-top: 5px;">
                        <div id="btnInsYes" class="BtnYesStyle">
                            確定</div>
                    </td>
                    <td align="left" style="padding-left: 15px; padding-top: 5px;">
                        <div id="btnCancel1" class="BtnNoStyle">
                            取消</div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="WinSel" title="  查詢" collapsible="false" minimizable="false" maximizable="false"
        class="divStyle" style="padding: 15px; background: #fafafa; width: 99%; height: 99%;
        display: none; overflow: hidden">
        <div region="center" border="false" class="subdivStyle" style="background: #fff;
            border: 1px solid #ccc; width: 98%; height: 93%;">
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
    <div id="WinUpd" title="  修改" collapsible="false" minimizable="false" maximizable="false"
        class="divStyle" style="padding: 15px; background: #fafafa; width: 99%; height: 99%;
        display: none; overflow: hidden">
        <div region="center" border="false" class="subdivStyle" style="background: #fff;
            border: 1px solid #ccc; width: 98%; height: 93%;">
            <iframe id="subFrameUpd" name="subFrameUpd" scrolling="no" frameborder="0" src=""
                style="width: 100%; height: 100%;"></iframe>
        </div>
        <div region="south" border="false" style="text-align: center; vertical-align: middle;
            height: 25px; line-height: 25px;">
            <table cellpadding="0" border="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" style="padding-top: 5px;">
                        <div id="btnUpdYes" class="BtnYesStyle">
                            確定</div>
                    </td>
                    <td align="left" style="padding-left: 15px; padding-top: 5px;">
                        <div id="btnCancel3" class="BtnNoStyle">
                            取消</div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    <div id="WinMore" title="  更多信息" collapsible="false" minimizable="false" maximizable="false"
        class="divStyle" style="padding: 15px; background: #fafafa; width: 99%; height: 99%;
        display: none; overflow: hidden">
        <div region="center" border="false" class="subdivStyle" style="background: #fff;
            border: 1px solid #ccc; width: 98%; height: 90%;">
            <iframe id="IframeMore" name="IframeMore" scrolling="no" frameborder="0" src=""
                style="width: 100%; height: 100%;"></iframe>
        </div>
        <div region="south" border="false" style="text-align: center; vertical-align: middle;
            height: 25px; line-height: 25px;">
            <table cellpadding="0" border="0" cellspacing="0" width="100%">
                <tr>                    
                    <td align="center" style="padding-left: 15px; padding-top: 5px;">
                        <div id="btnCancel4" class="BtnNoStyle" >
                            關閉</div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="hide"></asp:TextBox>
    <asp:Label ID="lblOperator" runat="server" Text="Channel" Style="display: none"></asp:Label>
    <asp:Label ID="lblFlag" runat="server" Text="" Style="display: none"></asp:Label>
    <uc1:IsLogin ID="IsLogin1" runat="server" />
    </form>
</body>
</html>
