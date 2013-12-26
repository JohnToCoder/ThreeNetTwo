$(document).ready(function() {
    $('#btnSel').click(function() {
        btnSearchClick();
        ClickFlag = 1;
    });

    $('#btnCancel').click(function() {
        closeWin();
        $('#subFrame').attr('src', $('#subFrame').attr('src'));
//        alert($('div.panel-tool-close').length);
    });

    $('#btnOk').click(function() {
        btnOkClick(ClickFlag);
    });


//    $('div.panel-tool-close').click(function() {
//        $('#subFrame').attr('src', $('#subFrame').attr('src'));
//    });
})

function openwin(Title) {
    $('#Win').window({
        width: 580,
        modal: true,
        shadow: true,
        closed: true,
        height: 220,
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
    iframe[0].src = "../Manage/Sys_Area_Edit.aspx?Flag=1";
}

function closeWin() {
    $('#Win').window('close');
}



function btnOkClick(ClickFlaged) {
    var iFrameContent = $('#subFrame');
    AjaxForSysAreaSearch(iFrameContent, '../Manage/Sys_Area.aspx');
}


function AjaxForSysAreaSearch(iFrameContent, Url) {
    var mac = iFrameContent.contents().find('#txtMac').val();
    var Area = iFrameContent.contents().find('#txtArea').val();
    var Name = iFrameContent.contents().find('#txtUserName').val();
    var Mail = iFrameContent.contents().find('#txtMail').val();

    if (mac.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Area.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Name.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Mail.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
        
    $.post('../ashx/SearchData.ashx',
    function(Retun) {
        location.href = Url + "?KeyValue=" + escape(mac) + '=' + escape(Area) + '=' + escape(Name) + '=' + escape(Mail);
        closeWin();
    })
}
