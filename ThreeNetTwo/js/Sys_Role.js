$(document).ready(function() {

    var ClickFlag = "";
    $('#btnset').click(function() {
        btnsetClick();
    });

    $('#btnSearch').click(function() {
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
})




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


function btnsetClick() {

    var chk = $('#Gv_Role>tbody>tr>td').find(':checkbox');

    var checked = chk.filter(':checked');

    if (checked.length == 0) {
        $.messager.alert('系统提示', '請選擇角色！', 'warning');
        return;
    }

    else {
        var id = checked.eq(0).parent().next().text();
        var RoleCode = checked.eq(0).parent().next().next().text();
        openWinPwd();
        
        $('#WinQX').css("display", "block");
        $('#WinQX').window('open');
        var iframe = $('#subFrameSel');
        iframe[0].src = "../Manage/Sys_MenuRight.aspx?Id=" + id + "&RoleCode=" + RoleCode;
    }
}

function openWinPwd() {
    $('#WinQX').window({
        width: 580,
        modal: true,
        shadow: true,
        closed: true,
        height: 495,
        top: 50,
        left: 80,
        resizable: false,
        title: '權限設置'
    });
}


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
    iframe[0].src = "../Manage/Sys_Roles_Edit.aspx?Flag=1&ID=NO";
}

function btnAddClick() {
    openwin('新增');
    $('#Win').css("display", "block");
    $('#Win').window('open');
    var iframe = $('#subFrame');
    iframe[0].src = "../Manage/Sys_Roles_Edit.aspx?Flag=2&ID=NO";
}

function btnUpdateClick() {

    var keyValue = $('#txtKeyValue').val();
    var chk = $('#Gv_Role>tbody>tr>td').find(':checkbox');

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
        iframe[0].src = "../Manage/Sys_Roles_Edit.aspx?Flag=3&ID="+code;
    }
}

function btnDelClick() {

    var keyValue = $('#txtKeyValue').val();
    var chk = $('#Gv_Role>tbody>tr>td').find(':checkbox');

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

                                            }

                                            $.post('../ashx/DeleteData.ashx',
                                             {
                                                 'keyValue': keyValue
                                             }, function(Return) {
                                                 if (Return == "false") {
                                                     $.messager.alert('系统提示', '資料刪除錯誤！', 'show');
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

function btnOkClick(ClickFlaged) {

    var iFrameContent=$('#subFrame');
    switch (ClickFlaged) {

        case 1:
            AjaxForSysRoleSearch(iFrameContent, '../Manage/Sys_Roles.aspx');
             break;
        case 2:
            AjaxForSysRoleAdd(iFrameContent, '../ashx/AddData.ashx');
            break;
        case 3:
            AjaxForSysRoleUpdate(iFrameContent, '../ashx/UpdateData.ashx');
            break;
    }

}

function AjaxForSysRoleSearch(iFrameContent, Url) {
    var RoleCode = iFrameContent.contents().find('#txtRoleCode').val();
    var RoleDesc = iFrameContent.contents().find('#txtRoleName').val();

    if (RoleCode.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (RoleDesc.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }


    $.post('../ashx/SearchData.ashx',
    function(Retun) {
        location.href = Url + "?KeyValue=" + escape(RoleCode) + '=' + escape(RoleDesc);
        closeWin();
    })
}


function closeWin() {
    $('#Win').window('close');
}

function AjaxForSysRoleAdd(iFrameContent, Url) {
    var keyValue = $('#txtKeyValue').val();
    var RoleCode = iFrameContent.contents().find('#txtRoleCode').val();
    var RoleDesc = iFrameContent.contents().find('#txtRoleName').val();

    if (RoleCode == "") {
        $.messager.alert('系统提示', '角色代碼不能為空', 'warning');
        return;
    }
    
    if (RoleDesc == "") {
        $.messager.alert('系统提示', '角色描述不能為空', 'warning');
        return;
    }

    if (RoleCode.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (RoleDesc.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(RoleCode)) {
        $.messager.alert('系統提示', 'Mac地址中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }


    if (CheckStr(RoleDesc)) {
        $.messager.alert('系統提示', '備注中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    

    $.post(Url,
       {
           'KeyValue': keyValue,
           'RoleCode': RoleCode,
           'RoleDesc': RoleDesc
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


function AjaxForSysRoleUpdate(iFrameContent, Url) {

    var keyValue = $('#txtKeyValue').val();
    var RoleCode = iFrameContent.contents().find('#txtRoleCode').val();
    var RoleDesc = iFrameContent.contents().find('#txtRoleName').val();
    var RoleId = iFrameContent.contents().find('#txtId').val();

    if (RoleCode == "") {
        $.messager.alert('系统提示', '角色代碼不能為空', 'warning');
        return;
    }

    if (RoleDesc == "") {
        $.messager.alert('系统提示', '角色描述不能為空', 'warning');
        return;
    }

    if (RoleCode.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (RoleDesc.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (CheckStr(RoleCode)) {
        $.messager.alert('系統提示', 'Mac地址中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }


    if (CheckStr(RoleDesc)) {
        $.messager.alert('系統提示', '備注中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    $.post(Url,
       {
           'KeyValue': keyValue,
           'RoleId': RoleId,
           'RoleCode': RoleCode,
           'RoleDesc': RoleDesc
       },
        function(Retun) {

            if (Retun == "false") {
                $.messager.alert('系统提示', '資料修改錯誤！', 'warning');
            }
            else if (Retun == "Double") {
                $.messager.alert('系统提示', '資料重復，此角色已經存在！', 'warning');
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