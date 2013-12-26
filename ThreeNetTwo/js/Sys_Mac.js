$(document).ready(function() {
    $('#btnSel').click(function() {
        btnSearchClick();
        ClickFlag = 1;
    });

    $('#btnInsert').click(function() {
        btnAddClick();
        ClickFlag = 2;
    });

    $('#btnUpd').click(function() {
        btnUpdateClick();
        ClickFlag = 3;
    });
    $('#btnDel').click(function() {
        btnDelClick();
    });


    $('#btnCancel').click(function() {
        closeWin();
        $('#subFrame').attr('src', $('#subFrame').attr('src'));
    });

    $('#btnOk').click(function() {
        btnOkClick(ClickFlag);
    });

    alertSuccessMsg();

    $(".MoreCss").each(function() {
        $(this).click(function() {
            var RoleId = $(this).parent().children().eq(8).text();
            var MId = $(this).parent().children().eq(1).text();
            var Macvalue = $(this).parent().children().eq(1).next().next().text();
            MoreClick(RoleId, MId, Macvalue);
        });
    });

    $(".MoreInfoCss").each(function() {
        $(this).click(function() {
            var Id = $(this).parent().children().eq(1).text();
            //var Macvalue = $(this).parent().children().eq(1).next().text();
            MoreInfoClick(Id);
        });
    });

    $('#btnColse').click(function() {
        CloseWin();
    })

})


function CloseWin() {
    $('#MoreInfoShow').window('close');

}


function MoreClick(id,Mid,mac) {
    
    openMorewin('權限查看');
    $('#MoreShow').css("display", "block");
    $('#MoreShow').window('open');
    
    var iframe = $('#moreFrame');

    iframe[0].src = "../Manage/Sys_MacRight.aspx?strId="+id+"&mac="+mac+"&Mid="+Mid;
}

function MoreInfoClick(id) {
    openInfowin('更多信息');
    $('#MoreInfoShow').css("display", "block");
    $('#MoreInfoShow').window('open');

    var iframe = $('#infoFrame');
    iframe[0].src = "../Manage/Sys_Mac_More.aspx?strId=" + id;
}


function btnDelClick() {

    var keyValue = $('#txtKeyValue').val();
    var MacALL = "";
    var chk = $('#GvMac>tbody>tr>td').find(':checkbox');

    var checked = chk.filter(':checked');


    if (checked.length == 0) {
        $.messager.alert('系统提示', '請選擇要刪除的項目！', 'warning');
        return;
    }
    else {
        $.messager.confirm('系统提示', '確定要刪除嗎？',
                                    function(YesOrNO) {
                                        if (YesOrNO) {

                                            for (i = 0; i < checked.length; i++) {
                                                keyValue += "-" + checked.eq(i).parent().next().text();
                                                MacALL += "|" + checked.eq(i).parent().next().next().text();
                                            }

                                            $.post('../ashx/DeleteData.ashx',
                                              {
                                                  'keyValue': keyValue,
                                                  'macAll': MacALL
                                              }, function(Return) {
                                                  if (Return == "false") {
                                                      $.messager.alert('系统提示', '資料刪除錯誤！', 'show');
                                                      return;
                                                  }

                                                  if (Return == "exist") {
                                                      $.messager.alert('系统提示', '存在與該資料相關聯的表！', 'show');
                                                      return;
                                                  }


                                                  else {
                                                      location.href = Return;
                                                  }
                                              });

                                        }
                                    }
                            )
    }
}

function alertSuccessMsg() {
    var Rval = $('#txtSuccess').val();
    if (Rval == "Deleted") {
        $.messager.alert('系统提示', '刪除資料成功！', 'warning');
        return;
    }
    if (Rval == "Update") {
        $.messager.alert('系统提示', '修改資料成功！', 'warning');
        return;
    }
    if (Rval == "Add") {
        $.messager.alert('系统提示', '新增資料成功！', 'warning');
        return;
    }

}


function openwin(Title) {
    $('#Win').window({
        width: 580,
        modal: true,
        shadow: true,
        closed: true,
        height: 450,
        top: 50,
        left: 80,
        resizable: false,
        title: Title
    });

}

function openInfowin(Title) {
    $('#MoreInfoShow').window({
        width: 600,
        modal: true,
        shadow: true,
        closed: true,
        height: 380,
        top: 50,
        left: 80,
        resizable: false,
        title: Title
    });

}



function openMorewin(Title) {

    $('#MoreShow').window({
        width: 960,
        modal: true,
        shadow: true,
        closed: true,
        height:470,
        top: 30,
        left:10,
        resizable: false,
        title: Title
    });

}

function btnSearchClick() {
    openwin('查詢');
    $('#Win').css("display", "block");
    $('#Win').window('open');

    var iframe = $('#subFrame');

    iframe[0].src = "../Manage/Sys_Mac_Edit.aspx?Flag=1&ID=NO";
}

function btnAddClick() {
    openwin('新增');
    $('#Win').css("display", "block");
    $('#Win').window('open');
    var iframe = $('#subFrame');
    iframe[0].src = "../Manage/Sys_Mac_Edit.aspx?Flag=2&ID=NO";
}

function btnUpdateClick() {

    var keyValue = $('#txtKeyValue').val();
    var chk = $('#GvMac>tbody>tr>td').find(':checkbox');

    var checked = chk.filter(':checked');

    if (checked.length == 0) {
        $.messager.alert('系统提示', '請選擇要修改的項目！', 'warning');
        return;
    }
    else {
        var code = checked.eq(0).parent().next().text();
        openwin('修改');
        $('#Win').css("display", "block");
        $('#Win').window('open');
        var iframe = $('#subFrame');
        iframe[0].src = "../Manage/Sys_Mac_Edit.aspx?Flag=3&ID=" + code;
    }
}


function closeWin() {
    $('#Win').window('close');
}



function btnOkClick(ClickFlaged) {
    var iFrameContent = $('#subFrame');
    switch (ClickFlaged) {

        case 1:
            AjaxForSysMacSearch(iFrameContent, '../Manage/Sys_Mac.aspx');
            break;
        case 2:
            AjaxForSysMacAdd(iFrameContent, '../ashx/AddData.ashx');
            break;
        case 3:
            AjaxForSysMacUpdate(iFrameContent, '../ashx/UpdateData.ashx');
            break;
    }
}


function AjaxForSysMacSearch(iFrameContent, Url) {
    var mac = iFrameContent.contents().find('#txtMac').val();
    var Meno = iFrameContent.contents().find('#txtMeno').val();
    var UserName = iFrameContent.contents().find('#txtName').val();
    var Tel = iFrameContent.contents().find('#txtTel').val();
    var Mobile = iFrameContent.contents().find('#txtMobile').val();
    var Role = iFrameContent.contents().find('#ddlRole').val();

    var UserId = iFrameContent.contents().find('#txtUserId').val();
    var Sex = iFrameContent.contents().find('#ddlSex').val();
    var BirthDay = iFrameContent.contents().find('#txtBirthDay').val();
    var Email = iFrameContent.contents().find('#txtEmail').val();
    var Address = iFrameContent.contents().find('#txtAddress').val();

    if (UserName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (mac.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Tel.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Mobile.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Meno.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }


    if (UserId.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Email != "" && Tel.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Address.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    
    $.post('../ashx/SearchData.ashx',
    function(Retun) {
    location.href = Url + "?KeyValue=" + escape(mac) + '=' + escape(Meno) + '=' + escape(UserName) + '=' + escape(Tel) + '=' + escape(Mobile) + '=' + escape(Role) +
     '=' + escape(UserId) + '=' + escape(Sex ) + '=' + escape(BirthDay) + '=' + escape(Email) + '=' + escape(Address);
        closeWin();
    })
}

function AjaxForSysMacAdd(iFrameContent, Url) {
    var keyValue = $('#txtKeyValue').val();
    var mac = iFrameContent.contents().find('#txtMac').val();
    var Meno = iFrameContent.contents().find('#txtMeno').val();
    var UserName = iFrameContent.contents().find('#txtName').val();
    var Tel = iFrameContent.contents().find('#txtTel').val();
    var Mobile = iFrameContent.contents().find('#txtMobile').val();
    var Role = iFrameContent.contents().find('#ddlRole').val();

    var UserId = iFrameContent.contents().find('#txtUserId').val();
    var Sex = iFrameContent.contents().find('#ddlSex').val();
    var BirthDay = iFrameContent.contents().find('#txtBirthDay').val();
    var Email = iFrameContent.contents().find('#txtEmail').val();
    var Address = iFrameContent.contents().find('#txtAddress').val();

    if (UserName == "") {
        $.messager.alert('系统提示', '名稱不能為空', 'warning');
        return;
    }

    if (UserName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(UserName)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }


    if (mac == "") {
        $.messager.alert('系统提示', 'Mac地址不能為空', 'warning');
        return;
    }

    if (mac.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(mac)) {
        $.messager.alert('系統提示', 'Mac地址中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if (Sex == "") {
        $.messager.alert('系统提示', '性別不能為空', 'warning');
        return;
    }

    if (Tel != "" && Tel.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Tel != "" && CheckStr(Tel)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if (Mobile != "" && Mobile.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Mobile != "" && CheckStr(Mobile)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if (Role == "") {
        $.messager.alert('系统提示', '角色描述不能為空', 'warning');
        return;
    }

    if (Meno == "") {
        $.messager.alert('系统提示', '備注不能為空', 'warning');
        return;
    }


    if (Meno.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(Meno)) {
        $.messager.alert('系統提示', '備注中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }


    if (UserId == "") {
        $.messager.alert('系统提示', '身份證號不能為空', 'warning');
        return;
    }

    if (UserId.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(UserId)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }


    if (Email != "" && Tel.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    //    if (Email != "" && CheckStr(Email)) {
    //        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
    //        return false;
    //    }


    if (Address == "") {
        $.messager.alert('系统提示', '家庭住址不能為空', 'warning');
        return;
    }

    if (Address.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(Address)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }


    $.post(Url,
       {
           'KeyValue': keyValue,
           'Mac': mac,
           'Meno': Meno,
           'name': UserName,
           'tel': Tel,
           'mobile': Mobile,
           'role': Role,
           'UserId':UserId,
           'Sex':Sex,
           'BirthDay':BirthDay,
           'Email':Email,
           'Address':Address
       },
        function(Retun) {

            if (Retun == "false") {
                $.messager.alert('系统提示', '資料新增錯誤！', 'warning');
            }
            else if (Retun == "Double") {
                $.messager.alert('系统提示', '資料重復，此角色已經存在！', 'warning');
            }
            else {
                location.href = Retun;
            }
        });

}


function AjaxForSysMacUpdate(iFrameContent, Url) {
    var keyValue = $('#txtKeyValue').val();
    var mac = iFrameContent.contents().find('#txtMac').val();
    var Meno = iFrameContent.contents().find('#txtMeno').val();
    var UserName = iFrameContent.contents().find('#txtName').val();
    var Tel = iFrameContent.contents().find('#txtTel').val();
    var Mobile = iFrameContent.contents().find('#txtMobile').val();
    var macId = iFrameContent.contents().find('#txtId').val();
    var Role = iFrameContent.contents().find('#ddlRole').val();

    var UserId = iFrameContent.contents().find('#txtUserId').val();
    var Sex = iFrameContent.contents().find('#ddlSex').val();
    var BirthDay = iFrameContent.contents().find('#txtBirthDay').val();
    var Email = iFrameContent.contents().find('#txtEmail').val();
    var Address = iFrameContent.contents().find('#txtAddress').val();

    if (UserName == "") {
        $.messager.alert('系统提示', '名稱不能為空', 'warning');
        return;
    }

    if (UserName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(UserName)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }


    if (mac == "") {
        $.messager.alert('系统提示', 'Mac地址不能為空', 'warning');
        return;
    }

    if (mac.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(mac)) {
        $.messager.alert('系統提示', 'Mac地址中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if (Sex == "") {
        $.messager.alert('系统提示', '性別不能為空', 'warning');
        return;
    }


    if (Tel != "" && Tel.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Tel != "" && CheckStr(Tel)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if (Mobile != "" && Mobile.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (Mobile != "" && CheckStr(Mobile)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if (Role == "") {
        $.messager.alert('系统提示', '角色描述不能為空', 'warning');
        return;
    }

    if (Meno == "") {
        $.messager.alert('系统提示', '備注不能為空', 'warning');
        return;
    }


    if (Meno.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(Meno)) {
        $.messager.alert('系統提示', '備注中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if (UserId == "") {
        $.messager.alert('系统提示', '身份證號不能為空', 'warning');
        return;
    }

    if (UserId.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(UserId)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if (Email != "" && Tel.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    //    if (Email != "" && CheckStr(Email)) {
    //        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
    //        return false;
    //    }


    if (Address == "") {
        $.messager.alert('系统提示', '家庭住址不能為空', 'warning');
        return;
    }

    if (Address.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(Address)) {
        $.messager.alert('系統提示', '輸入項不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    

    $.post(Url,
       {
           'KeyValue': keyValue,
           'Mac': mac,
           'Meno': Meno,
           'name': UserName,
           'tel': Tel,
           'mobile': Mobile,
           'MacId': macId,
           'role': Role,
           'UserId': UserId,
           'Sex': Sex,
           'BirthDay': BirthDay,
           'Email': Email,
           'Address': Address
       },
        function(Retun) {

            if (Retun == "false") {
                $.messager.alert('系统提示', '資料修改錯誤！', 'warning');
            }
            else if (Retun == "Double") {
                $.messager.alert('系统提示', '資料重復，此用戶已經存在！', 'warning');
            }
            else {
                location.href = Retun;
            }
        });
}


function CheckStr(str) {
    var myReg = /^[^@\/\'\\\"#$%&\^\*]+$/;


    if (myReg.test(str)) {
        return false;
    }
    return true;
}