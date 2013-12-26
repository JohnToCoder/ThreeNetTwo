
$(document).ready(function() {

    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Manage/Sys_Mobile_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        var iFrameSel = $("#subFrameSel");
        AjaxForSysMobileSearch(iFrameSel);
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });
});

function openWinSel() {
    $('#WinSel').window({
        width: 580,
        modal: true,
        shadow: true,
        closed: true,
        height: 200,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}

/*
功能：手機管理_查詢Ajax調用
開發人員：楊碧清
開發時間:2011-03-17
*/
function AjaxForSysMobileSearch(iFrameContent) {

    var txtMac = iFrameContent.contents().find('#txtMac').val();    //
    var txtUserName = iFrameContent.contents().find('#txtUserName').val();     //用戶名稱
    var txtMobileCode = iFrameContent.contents().find('#txtMobileCode').val();   //手機號碼
    var txtMail = iFrameContent.contents().find('#txtMail').val();    //

    if (txtMac.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtUserName.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtMobileCode.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtMail.indexOf('=') != -1) {
        $.messager.alert('系统提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    $.post('../ashx/SearchData.ashx',
    function(Retun) {
        location.href = "../Manage/Sys_Mobile.aspx?KeyValue=" + escape(txtMac) + '=' + escape(txtUserName) + '=' + escape(txtMobileCode) + '=' + escape(txtMail);
        closeWin();
    })
}

//關閉彈出頁面
function closeWin() {
    $('#WinSel').window('close');
}