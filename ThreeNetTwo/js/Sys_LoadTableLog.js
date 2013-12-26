/// <reference path="jquery-1.4.2.min-vsdoc.js" />

$(document).ready(function() {

    var ClickFlag = "";

    $('#btnSel').click(function() {
        btnSearchClick();
        ClickFlag = 1;
    });

    $('#btnCancel').click(function() {
        closeWin();
        $('#subFrame').attr('src', $('#subFrame').attr('src'));
    });

    $('#btnOk').click(function() {
        btnOkClick(ClickFlag);
    });

});

function closeWin() {
    $('#Win').window('close');
}

function openwin(Title) {
    $('#Win').window({
        width: 580,
        modal: true,
        shadow: true,
        closed: true,
        height: 350,
        top: 50,
        left: 80,
        resizable: false,
        title: Title
    });
}

function btnSearchClick() {
    openwin('查詢');
    $('#Win').css("display", "block");
    $('#Win').window('open');

    var iframe = $('#subFrame');

    iframe[0].src = "../../Manage/SysLoadTableLog/Sys_LoadTableLog_Edit.aspx?Flag=1&ID=NO";
}

// 單擊注冊碼彈出解碼窗口
function btnsetClick(Id) {

    openWinPwd();

    $('#WinQX').css("display", "block");
    $('#WinQX').window('open');
    var iframe = $('#subFrameSel');
    iframe[0].src = "../../Manage/SysLoadTableLog/Sys_LoadTableLog_Info.aspx?Id=" + Id;
}

function openWinPwd() {
    $('#WinQX').window({
        width: 500,
        modal: true,
        shadow: true,
        closed: true,
        height: 350,
        top: 60,
        left: 120,
        resizable: false,
        title: '表結構的詳細描述'
    });
}

function btnOkClick(ClickFlaged) {

    var iFrameContent = $('#subFrame');
    switch (ClickFlaged) {

        case 1:
            AjaxForSysLoadTableSearch(iFrameContent, '../../Manage/SysLoadTableLog/Sys_LoadTableLog.aspx');
            break;
    }
}

function AjaxForSysLoadTableSearch(iFrameContent, Url) {
    var txtMac = iFrameContent.contents().find('#txtMac').val();

    var txtClientName = iFrameContent.contents().find('#txtClientName').val();
    var txtTableName = iFrameContent.contents().find('#txtTableName').val();
    var txtOrderId = iFrameContent.contents().find('#txtOrderId').val();
    var txtStartDate = iFrameContent.contents().find('#txtStartDate').val();
    var txtEndDate = iFrameContent.contents().find('#txtEndDate').val();

    if (txtMac.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtClientName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtTableName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtOrderId.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtStartDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtEndDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    $.post('../../ashx/SearchData.ashx',
     function(Retun) {
    location.href = Url + "?KeyValue=" + escape(txtMac) + '=' + escape(txtClientName) + '=' + escape(txtTableName) + '=' 
                        + escape(txtOrderId) + '=' + escape(txtStartDate) + '=' + escape(txtEndDate);
         closeWin();
     })
}