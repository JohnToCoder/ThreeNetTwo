
$(document).ready(function() {

    var ClickFlag = "";

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
});

function closeWin() {
    $('#Win').window('close');
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
        width: 550,
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

function openSearchWin() {
    $('#Win').window({
        width: 400,
        modal: true,
        shadow: true,
        closed: true,
        height: 280,
        top: 50,
        left: 80,
        resizable: false,
        title: '查詢'
    });
}

function btnSearchClick() {
    openSearchWin();
    $('#Win').css("display", "block");
    $('#Win').window('open');

    var iframe = $('#subFrame');

    iframe[0].src = "../../Manage/UpdateTable/MD_UpdateTable_Search.aspx?Flag=1&ID=NO";
}

function btnAddClick() {
    openwin('新增');
    $('#Win').css("display", "block");
    $('#Win').window('open');
    var iframe = $('#subFrame');
    iframe[0].src = "../../Manage/UpdateTable/MD_UpdateTable_Edit.aspx?Flag=2&ID=NO";
}

function btnUpdateClick() {

    var keyValue = $('#txtKeyValue').val();
    var chk = $('#GvUpdateTb>tbody>tr>td').find(':checkbox');

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
        iframe[0].src = "../../Manage/UpdateTable/MD_UpdateTable_Edit.aspx?Flag=3&ID=" + code;
    }
}

// 單擊注冊碼彈出解碼窗口
function btnsetClick(Id) {

    openWinPwd();

    $('#WinQX').css("display", "block");
    $('#WinQX').window('open');
    var iframe = $('#subFrameSel');
    iframe[0].src = "../../Manage/UpdateTable/MD_UpdateTable_Info.aspx?Id=" + Id;
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

function btnDelClick() {

    var keyValue = $('#txtKeyValue').val();
    var chk = $('#GvUpdateTb>tbody>tr>td').find(':checkbox');

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

                                            $.post('../../ashx/DeleteData.ashx',
                                             {
                                                 'keyValue': keyValue
                                             }, function(Return) {
                                                 if (Return == "false") {
                                                     $.messager.alert('系统提示', '對不起，資料刪除錯誤！', 'show');
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

    var iFrameContent = $('#subFrame');
    switch (ClickFlaged) {

        case 1:
            AjaxForMDUpdateTableSearch(iFrameContent, '../../Manage/UpdateTable/MD_UpdateTable.aspx');
            break;
        case 2:
            AjaxForMDUpdateTableAdd(iFrameContent, '../../ashx/AddData.ashx');
            break;
        case 3:
            AjaxForMDUpdateTableUpdate(iFrameContent, '../../ashx/UpdateData.ashx');
            break;
    }

}

function AjaxForMDUpdateTableSearch(iFrameContent, Url) {
    var txtTableName = iFrameContent.contents().find('#txtTableName').val();

    if (txtTableName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    $.post('../../ashx/SearchData.ashx',
     function(Retun) {
         location.href = Url + "?KeyValue=" + escape(txtTableName) +'=';
         closeWin();
     })
 }

 function AjaxForMDUpdateTableAdd(iFrameContent, Url) {
     var keyValue = $('#txtKeyValue').val();
     var txtTableName = iFrameContent.contents().find('#txtTableName').val();
     var txtCodeDesc = iFrameContent.contents().find('#txtCodeDesc').val();
     var txtOrderID = iFrameContent.contents().find('#txtOrderID').val();

     if (txtTableName == "") {
         $.messager.alert('系统提示', '表名不能為空', 'warning');
         return;
     }

     if (txtOrderID == "") {
         $.messager.alert('系统提示', '序號不能為空', 'warning');
         return;
     }
     
     if (txtCodeDesc == "") {
         $.messager.alert('系统提示', '表的描述不能為空', 'warning');
         return;
     }
     
     if (CheckStr(txtTableName)) {
         $.messager.alert('系統提示', '表名不能包含@/\"#$%&^*！', 'warning');
         return false;
     }
     
     if (parseInt(txtOrderID) != txtOrderID || parseInt(txtOrderID) <= 0) {
        $.messager.alert('系统提示', '步驟必須為正整數,請重新輸入！', 'warning');
        return false;
     }

     $.post(Url,
       {
           'KeyValue': keyValue,
           'txtTableName': txtTableName,
           'txtCodeDesc': txtCodeDesc,
           'txtOrderID': txtOrderID
       },
        function(Retun) {

            if (Retun == "false") {
                $.messager.alert('系统提示', '資料新增錯誤！', 'warning');
            }
            else if(Retun == "ExistsOrderId"){
                $.messager.alert('系统提示', '相同的日期里，已存在步驟相同的項！', 'warning');
            }
            else {
                location.href = Retun;
            }
        });
 }

function AjaxForMDUpdateTableUpdate(iFrameContent, Url) {
     var keyValue = $('#txtKeyValue').val();
     var Id = iFrameContent.contents().find('#txtId').val();
     var txtTableName = iFrameContent.contents().find('#txtTableName').val();
     var txtCodeDesc = iFrameContent.contents().find('#txtCodeDesc').val();
     var txtOrderID = iFrameContent.contents().find('#txtOrderID').val();

     if (txtTableName == "") {
         $.messager.alert('系统提示', '表名不能為空', 'warning');
         return;
     }

    if (txtOrderID == "") {
         $.messager.alert('系统提示', '序號不能為空', 'warning');
         return;
     }
     
     if (txtCodeDesc == "") {
         $.messager.alert('系统提示', '表的描述不能為空', 'warning');
         return;
     }
          
     if (CheckStr(txtTableName)) {
         $.messager.alert('系統提示', '表名不能包含@/\"#$%&^*！', 'warning');
         return false;
     }
     
    if (parseInt(txtOrderID) != txtOrderID || parseInt(txtOrderID) <= 0) {
        $.messager.alert('系统提示', '步驟必須為正整數,請重新輸入！', 'warning');
        return false;
     }

    $.post(Url,
       {
          'KeyValue': keyValue,
          'Id':Id,
          'txtTableName': txtTableName,
          'txtCodeDesc': txtCodeDesc,
          'txtOrderID':txtOrderID
       },
        function(Retun) {

            if (Retun == "false") {
                $.messager.alert('系统提示', '資料修改錯誤！', 'warning');
            }
             else if(Retun == "ExistsOrderId"){
                $.messager.alert('系统提示', '已存在該表中序號相同的項', 'warning');
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