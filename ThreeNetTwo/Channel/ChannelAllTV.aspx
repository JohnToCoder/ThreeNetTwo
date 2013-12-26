<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelAllTV.aspx.cs" Inherits="ThreeNetTwo.Channel.ChannelAllTV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>頻道播放</title>
    <link rel="stylesheet" href="../css/ControlItem.css" type="text/css" media="screen" />
    <link href="../css/HideMouse.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.4.2.min.js" type="text/javascript"></script>

    <%--<script src="../JS/HideMouse.js" type="text/javascript"></script>--%>

    <script language="JScript" event="Buffering(bStart)" for="MediaPlayer">  
        if(bStart)
        {
            document.getElementById('divLoading').style.height=window.screen.availHeight-window.screenTop;
            document.getElementById('divLoading').style.display='';
        }
        else
        {
            document.getElementById('divLoading').style.display='none';
        }
    </script>

    <style>
        .VolumnBar
        {
            cursor: hand;
            width: 30px;
            height: 20px;
            border-bottom: solid 1px #f79646;
            border-top: solid 1px #f79646;
        }
    </style>
</head>
<body onselectstart="return false" scroll="no" style="overflow: hidden; font-family: 微軟正黑體;
    font-size: 20pt;">
    <form id="form1" runat="server">
    <%--<body style="font-family:微軟正黑體;font-size:20pt;">--%>
    <div id="divLoading" style=" display:none;width: 100%; text-align: center; vertical-align: middle">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%">
            <tr valign="middle">
                <td>
                    <img src="../images/loading_s.gif" alt="加載中..." />
                </td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%=ViewState["strKey"].ToString() %>
    <table id="VolumeTable" style="display: none;" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td style="vertical-align: middle;">
                音量設置：<img src="./images/sound.JPG" />&nbsp;&nbsp;
            </td>
            <%=ViewState["strVolumeBar"].ToString()%>
            <td>
                <div style="cursor: hand;" onclick="javascript:document.getElementById('VolumeTable').style.display='none';document.getElementById('MediaPlayer').height='100%';">
                    隱藏</div>
            </td>
        </tr>
    </table>
    <table id="ProgramListTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%=ViewState["strProgramList"].ToString()%>
                        <div style="display: none;">
                            <asp:TextBox ID="tbcurrentVolume" runat="server"></asp:TextBox>
                            <asp:TextBox ID="tbUpChannel" runat="server" Text="-1"></asp:TextBox>
                            <asp:TextBox ID="tbCurrentChannel" runat="server" Text="-1"></asp:TextBox>
                            <asp:TextBox ID="tbDownChannel" runat="server" Text="-1"></asp:TextBox></div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btgetProgramList" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <div style="display: none;">
        <asp:Button ID="btsaveVolume" runat="server" Text="Button" OnClick="btsaveVolume_Click" />
        <asp:Button ID="btgetProgramList" runat="server" Text="Button" OnClick="btgetProgramList_Click" />
    </div>
    <div style="width: 100%; height: 20px;" onmouseover="javascript:if(top==this){showVolumeTable();}">
    </div>
    <table>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btsaveVolume" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

    <script>
    window.onload = function() {
//     Hidemouse();
//    IsiPad();
    if(top==this)
    {
        document.onkeydown = getKey;
        
    }
    else
    {
        document.getElementById('ProgramListTable').style.display='none';
    }
 
    //CollectGarbage();
}
function IsiPad()
{  
	var ua = navigator.userAgent.toLowerCase();
    var isiPad;
    isiPad = ua.match(/iPad/i);

	if(isiPad == "ipad")
	{
		location = "./ChannelAllTV_ipad.aspx";		
	}
}

if(top==this)
{
    //document.getElementById('MediaPlayer').width=window.screen.width;
    document.getElementById('MediaPlayer').height=window.screen.height-120;
    var currentVolume = parseInt(document.getElementById('tbcurrentVolume').value);
    var startT=0;
    var endT=0;
    var RightNow;
    RightNow = new Date(); 
    startT=RightNow.getTime();
    setTimeout("hideProgramListTable()",5000);
    setVolumebarColor(currentVolume);
    controlVolume(currentVolume);
}
else
{
    document.getElementById('MediaPlayer').scrollIntoView();
}
function getKey(e)
{
    e = e || window.event;
    var keycode = e.which ? e.which : e.keyCode;
    if (keycode == 37 && currentVolume - 1 >= 0) 
    {         
         currentVolume = currentVolume - 1;         
    }
    
    else if(keycode == 39 && currentVolume + 1 <= 10)
    {
         currentVolume = currentVolume + 1;    
    }       
    else if (keycode == 38 && document.getElementById('tbUpChannel').value!=-1) 
    {
        document.getElementById('tbCurrentChannel').value = document.getElementById('tbUpChannel').value;

    }//up  
    else if (keycode == 40 && document.getElementById('tbDownChannel').value!=-1) 
    {
        document.getElementById('tbCurrentChannel').value = document.getElementById('tbDownChannel').value;
    }//down  
    else if (keycode == 36) {
            window.location = '/index.htm?id=0';
    }        
    
    if (keycode == 37 | keycode == 39)
    {
        document.getElementById('VolumeTable').style.display='block';
        document.getElementById('ProgramListTable').style.display='none';
        document.getElementById('MediaPlayer').height=window.screen.height-80;        
        controlVolume(currentVolume);
        document.getElementById('tbcurrentVolume').value=currentVolume;
        document.getElementById('btsaveVolume').click();
        setVolumebarColor(currentVolume); 
        RightNow = new Date(); 
        startT=RightNow.getTime();
        setTimeout("hideVolumeTable()",5000);        
    }    
    if ((keycode == 38 && document.getElementById('tbUpChannel').value!=-1) | (keycode == 40 && document.getElementById('tbDownChannel').value!=-1))
    {
       document.getElementById('VolumeTable').style.display='none';
       document.getElementById('btgetProgramList').click();
       document.getElementById('MediaPlayer').height=window.screen.height-120;
       document.getElementById('ProgramListTable').style.display='block';
       RightNow = new Date(); 
       startT=RightNow.getTime();
       setTimeout("hideProgramListTable()",5000);
    }    
}

function setVolume(strength)
{
    controlVolume(strength);
    currentVolume = strength;
    setVolumebarColor(currentVolume);
    document.getElementById('tbcurrentVolume').value=currentVolume;    
    document.getElementById('btsaveVolume').click();
    RightNow = new Date(); 
    startT=RightNow.getTime();
    setTimeout("hideVolumeTable()",5000);      
}

function showVolumeTable()
{
    document.getElementById('VolumeTable').style.display='block';
    document.getElementById('ProgramListTable').style.display='none';
    document.getElementById('MediaPlayer').height=window.screen.height-80; 
    RightNow = new Date(); 
    startT=RightNow.getTime();
    setTimeout("hideVolumeTable()",5000); 
}

function hideVolumeTable()
{
    RightNow = new Date();
    endT=RightNow.getTime();
    if(Math.abs(endT - startT - 5000) < 300 )
    {
        document.getElementById('VolumeTable').style.display='none';
        document.getElementById('MediaPlayer').height='100%';
    }
}

function hideProgramListTable()
{
    RightNow = new Date();
    endT=RightNow.getTime();
    if(Math.abs(endT - startT - 5000) < 300 )
    {
        document.getElementById('ProgramListTable').style.display='none';
        document.getElementById('MediaPlayer').height='100%';
    }
}

function controlVolume(strength)
{
    switch(strength)
    {
        case 0:
            document.getElementById('MediaPlayer').Volume=-2500;
            break;
        case 1:
            document.getElementById('MediaPlayer').Volume=-1900;
            break;
        case 2:
            document.getElementById('MediaPlayer').Volume=-1400;
            break;
        case 3:
            document.getElementById('MediaPlayer').Volume=-1000;
            break;
        case 4:
            document.getElementById('MediaPlayer').Volume=-700;
            break;
        case 5:
            document.getElementById('MediaPlayer').Volume=-500;
            break;
        case 6:
            document.getElementById('MediaPlayer').Volume=-400;
            break;
        case 7:
            document.getElementById('MediaPlayer').Volume=-300;
            break;
        case 8:
            document.getElementById('MediaPlayer').Volume=-200;
            break;
        case 9:
            document.getElementById('MediaPlayer').Volume=-100;
            break;
        case 10:
            document.getElementById('MediaPlayer').Volume=-0;
            break;
    }
}
function setVolumebarColor(currentVolume)
{
    for (i=0; i<=10; i=i+1)
    {
        if(i<=currentVolume)
        {
            document.getElementById('VolumnBar'+i).style.backgroundColor='#f79646';
        }
        else
        {
            document.getElementById('VolumnBar'+i).style.backgroundColor='Transparent';                    
        }
    }    
}

    </script>

    </form>
</body>
</html>
