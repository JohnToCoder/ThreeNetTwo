$(document).ready(function() {
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

})


function openwin(Title) {
    $('#Win').window({
        width: 580,
        modal: true,
        shadow:false,
        closed: true,
        height: 180,
        top: -120,
        left:80,
        resizable: false,
        title: Title
    });

}


function btnSearchClick() {
    openwin('查詢');

    $('#Win').parent().removeClass('ui-state-disabled');
    $('#Win').css("display", "block");
    $('#Win').window('open');
    //$('#Win').parent().css('top','')
   // $('#Win').parent().offset().top
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        var nav = navigator.appVersion.split(';')[1].replace(/[ ]/g, '');

        //alert(parseInt($('#Win').parent().offset().top));
        if (nav == 'MSIE7.0' || nav == 'MSIE6.0') {
            if (parseInt($('#Win').parent().offset().top) != '130') {
                $('#Win').parent().css('top', '-8');
            }
        }
        if (nav == 'MSIE8.0') {
            if (parseInt($('#Win').parent().offset().top) != '58') {
                $('#Win').parent().css('top', '-48');
            }
        }
    }
    else {
        if (parseInt($('#Win').parent().offset().top) != '53') {
            $('#Win').parent().css('top', '-50px');
            $('#Win').css('top', '-50px');
        }

    }

}

function closeWin() {
    $('#Win').window('close');
}

function btnOkClick(ClickFlaged) {
    //alert($('#Win').parent().css('top'));
    // var iFrameContent = $('#subFrame');

    //alert($('ul').children());

    AjaxForSysAreaSearch('../Manage/Sys_ClientVersion.aspx');
}



function AjaxForSysAreaSearch(Url) {
    var mac = $('#txtMac').val();
    var meno = $('#txtMeno').val();
    var VerID = "";
    var VerName = $('#txtVerName').val();
    var VerDesc = $('#txtVerDesc').val();

    if (mac.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (meno.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (VerName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (VerDesc.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }


    $.post('../ashx/SearchData.ashx',
    function(Retun) {
        location.href = Url + "?KeyValue=" + escape(mac) + '=' + escape(meno) + '=' + escape(VerID) + '=' + escape(VerName) + "=" + escape(VerDesc);
        closeWin();
    })
}
