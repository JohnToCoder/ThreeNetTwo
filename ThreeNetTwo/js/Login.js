$(document).ready(function() {
    $('#Login').click(function() {
        valide();
    });

    $('#LoginName').focus();

    if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {
        //$('#code').css('width', '15%');
        $('#TdCode').css('padding-left', '5px');
        $('#vaTr').css('padding-top', '1px');
    }
});

function valide() {
    if ($('#LoginName').val() == '') {
        //$.messager.alert('系統提示', '請輸入用戶名', 'warning');
        alert('請輸入用戶名');
        return;
    }
    if ($('#LoginPwd').val() == '') {
        //$.messager.alert('系統提示', '請輸入密碼', 'warning');
        alert('請輸入密碼');
        return;
    }
    if ($('#LoginCode').val() == '') {
        //$.messager.alert('系統提示', '請輸入驗證碼', 'warning');
        alert('請輸入驗證碼');
        return;
    }

    else {
        $.post("../ashx/LoginHandler.ashx",
            {
                'username': escape($('#LoginName').val()),
                'pwd': $.md5(escape($('#LoginPwd').val())),
                'Code': escape($('#LoginCode').val().toLowerCase())
            },
            function(ReturnValue) {
                if (ReturnValue == "overtime") {
                   // $.messager.alert('系統提示', '驗證碼已過期', 'warning');
                    alert("驗證碼已過期");
                    $('#LoginCode').val('');
                    $('#LoginPwd').val('');
                    $('#ValidateImg').click();
                    return;
                }
                else if (ReturnValue == "CodeError") {
                    //$.messager.alert('系統提示', '輸入的驗證碼錯誤', 'warning');
                    alert("輸入的驗證碼錯誤");
                    $('#LoginCode').val('');
                    $('#ValidateImg').click();
                    return;
                }
                else if (ReturnValue == "ErrUser") {
                    //$('#LoginPwd').val('');
                    //$.messager.alert('系統提示', '輸入的用戶名或密碼錯誤', 'warning');
                    alert("輸入的用戶名或密碼錯誤");

                    return;
                }
                else if (ReturnValue == "success") {
                    location.href = "../main.html";
                }


            });
     }
 }

 window.onload = function() {

     document.onkeydown = getKey;
 }

 function getKey(e) {
     e = e || window.event;
     var keycode = e.which ? e.which : e.keyCode;

     // alert(keycode);

     if (keycode == 13) {
         $('#Login').trigger('click');
     }
 }
        
