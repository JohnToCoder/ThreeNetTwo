
$(document).ready(function() {

    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Manage/SysLoadData/LoadDataLog_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        var iFrameSel = $("#subFrameSel");
        AjaxForSysDataLogSearch(iFrameSel);
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });
});

function openWinSel() {
    $('#WinSel').window({
        width: 600,
        modal: true,
        shadow: true,
        closed: true,
        height: 350,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}

/*
功能：客戶端資料更新Log_查詢Ajax調用
開發人員：楊碧清
開發時間:2011-03-30
*/
function AjaxForSysDataLogSearch(iFrameContent) {

    var txtMac = iFrameContent.contents().find('#txtMac').val();    //Mac地址
    var txtClientName = iFrameContent.contents().find('#txtClientName').val();     //客戶端主機名稱
    var ddlMenuTypeId = iFrameContent.contents().find('#ddlMenuTypeId').val(); //資料類型
    var txtData = iFrameContent.contents().find('#txtData').val();
    var txtDataDesc = iFrameContent.contents().find('#txtDataDesc').val();    //
    var txtStartDate = iFrameContent.contents().find('#txtStartDate').val();
    var txtEndDate = iFrameContent.contents().find('#txtEndDate').val();
    var ddlActionType = iFrameContent.contents().find('#ddlActionType').val();//動作類型

    if (txtMac.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtClientName.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtData.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtDataDesc.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtStartDate.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtEndDate.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    $.post('../ashx/SearchData.ashx',
    function(Retun) {
    location.href = "../Manage/Sys_LoadDataLog.aspx?KeyValue=" + escape(txtMac) + '=' + escape(txtClientName) + '=' + escape(ddlMenuTypeId) + '=' + escape(txtData) + '=' + escape(txtDataDesc) + '=' + escape(txtStartDate) + '=' + escape(txtEndDate) + '=' + escape(ddlActionType);
        closeWin();
    })
}

//關閉彈出頁面
function closeWin() {
    $('#WinSel').window('close');
}

//
function DataDetailClick(MenuTypeID, ID) {

    var iframe = $('#moreFrame');

    if (MenuTypeID == '8') {
        openMorewin('頻道明細');
        iframe[0].src = "../Manage/SysLoadData/ChannelDetail.aspx?menuTypeId=" + MenuTypeID + "&Id=" + ID;
    }
    else if (MenuTypeID == '10') {
        openMorewin('電視劇明細');
        iframe[0].src = "../Manage/SysLoadData/TVPlayDetail.aspx?menuTypeId=" + MenuTypeID + "&Id=" + ID;
    }
    else if (MenuTypeID == '11') {
        openMorewin('音樂明細');
        iframe[0].src = "../Manage/SysLoadData/MusicDetail.aspx?menuTypeId=" + MenuTypeID + "&Id=" + ID;
    }
    else if (MenuTypeID == '12') {
        openMorewin('相冊明細');
        iframe[0].src = "../Manage/SysLoadData/PhotoDetail.aspx?menuTypeId=" + MenuTypeID + "&Id=" + ID;
    }

    $('#MoreShow').css("display", "block");
    $('#MoreShow').window('open');
}

function openMorewin(Title) {
    $('#MoreShow').window({
        width: 500,
        modal: true,
        shadow: true,
        closed: true,
        height: 420,
        top: 50,
        left: 150,
        resizable: false,
        title: Title
    });

}