/*
功能描述：系統版本發佈信息頁面的相關功能實現
人員：劉鋒 
時間：2011-03-24
*/
$(document).ready(function() {


    $('#txtVersionDate').datebox({});
    $('#txtPubDate').datebox({});
    $('#txtCreateDate').datebox({});

    var lblOperator = $('#lblOperator');
    lblOperator.css("display", "none");

    //新增頁面及其確定與取消
    $('#btnIns').click(function() {
        openWinIns();
        var iFrameIns = $("#subFrameIns");
        iFrameIns[0].src = "../Manage/Sys_VersionInfo_Edit.aspx?flag=ins";
    });
    $('#btnInsYes').click(function() {
        AjaxForVersionIns();
    });
    $('#btnCancel1').click(function() {
        $('#WinIns').window('close');
    });


    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Manage/Sys_VersionInfo_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        AjaxForVersionSearch('../Manage/Sys_VersionInfo.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });


    //修改頁面及其確定與取消
    $('#btnUpd').click(function() {
        var chk = $('tbody>tr>td').find(':checkbox')
        var chked = chk.filter(':checked');

        if (chked.length == 0) {
            $.messager.alert('系统提示', '請選擇要修改的資料！', 'warning');
        }
        else {
            openWinUpd();
            var chkKey = chked[0].parentNode.nextSibling.innerHTML;
            var iFrameUpd = $("#subFrameUpd");
            iFrameUpd[0].src = "../Manage/Sys_VersionInfo_Edit.aspx?flag=upd&key=" + chkKey;
        }
    });
    $('#btnUpdYes').click(function() {
        AjaxForVersionUpd();
    });
    $('#btnCancel3').click(function() {
        $('#WinUpd').window('close');
    });

    //刪除頁面
    $('#btnDel').click(function() {
        DeleteClick(lblOperator);
    });

    var lblFlag = $('#lblFlag');
    lblFlag.css("display", "none");
    AlertFlag(lblFlag);
});


function openWinIns() {
    $('#WinIns').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 410,
        top: 50,
        left: 80,
        resizable: false,
        scroll: false,
        title: ' 新增窗口'
    });
    $('#WinIns').css("display", "block");
    $('#WinIns').window('open');
}

function openWinSel() {
    $('#WinSel').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 410,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}

function openWinUpd() {
    $('#WinUpd').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 410,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 修改窗口'
    });
    $('#ddlChannelName').attr("", "false");
    $('#WinUpd').css("display", "block");
    $('#WinUpd').window('open');
}

//新增
function AjaxForVersionIns() {
    var iFrameContent = $("#subFrameIns").contents();

    var txtVersionNum = iFrameContent.find('#txtVersionNum').val();
    var txtVersionDesc = iFrameContent.find('#txtVersionDesc').val();
    var txtVersionDate = iFrameContent.find('#txtVersionDate').val();
    var txtPubDate = iFrameContent.find('#txtPubDate').val();
    //Edit By Tanyi 2011/04/08 添加上傳文件功能
    var file = iFrameContent.find('#FilePath').val();

    var pos = file.lastIndexOf("/");
    if (pos == -1) {
        pos = file.lastIndexOf("\\");
    }
    var fuFileName = file.substr(pos + 1);

    if ($.trim(txtVersionNum) == "") {
        $.messager.alert('系统提示', '請先輸入版本號！', 'warning');
        return false;
    }
    if ($.trim(txtVersionDesc) == "") {
        $.messager.alert('系统提示', '請先輸入版本描述！', 'warning');
        return false;
    }
    if ($.trim(txtVersionDate) == "") {
        $.messager.alert('系统提示', '請先輸入版本日期！', 'warning');
        return false;
    }
    if ($.trim(txtPubDate) == "") {
        $.messager.alert('系统提示', '請先輸入發佈日期！', 'warning');
        return false;
    }
    
    if(!checkDate(txtVersionDate)){
        $.messager.alert('系统提示', '版本日期格式錯誤！', 'warning');
        return false;
    } 
    if(!checkDate(txtPubDate)){
        $.messager.alert('系统提示', '發佈日期格式錯誤！', 'warning');
        return false;
    }
    if (txtVersionNum.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtVersionDesc.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtVersionDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtPubDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if ($.trim(fuFileName) == "") {
        $.messager.alert('系统提示', '請先上傳文件！', 'warning');
        return false;
    }
    else if (CheckFile(fuFileName)) {
        $.messager.alert('系統提示', '您只能上傳.zip類型的文件！', 'warning');
        return false;
    }

    $.post('../ashx/AddData.ashx',
           {
               'KeyValue': 'Version',
               'VersionNum': txtVersionNum,
               'VersionDesc': txtVersionDesc,
               'VersionDate': txtVersionDate,
               'PubDate': txtPubDate
           },

            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '新增版本出錯!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '您要添加的版本號已經存在!', 'warning');
                }
                else {
                    iFrameContent.find('#btnOK').click();
                }
            }
         )
}

//修改
function AjaxForVersionUpd() {
    var iFrameContent = $("#subFrameUpd").contents();

    var txtVersionNum = iFrameContent.find('#txtVersionNum').val();
    var txtVersionDesc = iFrameContent.find('#txtVersionDesc').val();
    var txtVersionDate = iFrameContent.find('#txtVersionDate').val();
    var txtPubDate = iFrameContent.find('#txtPubDate').val();

    var file = iFrameContent.find("#FilePath").val();
    var pos = file.lastIndexOf("/");
    if (pos == -1) {
        pos = file.lastIndexOf("\\");
    }
    var fuFileName = file.substr(pos + 1);
    
    if ($.trim(txtVersionNum) == "") {
        $.messager.alert('系统提示', '請先輸入版本號！', 'warning');
        return false;
    }
    if ($.trim(txtVersionDesc) == "") {
        $.messager.alert('系统提示', '請先輸入版本描述！', 'warning');
        return false;
    }
    if ($.trim(txtVersionDate) == "") {
        $.messager.alert('系统提示', '請先輸入版本日期！', 'warning');
        return false;
    }
    if ($.trim(txtPubDate) == "") {
        $.messager.alert('系统提示', '請先輸入發佈日期！', 'warning');
        return false;
    }
    
    if(!checkDate(txtVersionDate)){
        $.messager.alert('系统提示', '版本日期格式錯誤！', 'warning');
        return false;
    } 
    if(!checkDate(txtPubDate)){
        $.messager.alert('系统提示', '發佈日期格式錯誤！', 'warning');
        return false;
    }
    if (txtVersionNum.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtVersionDesc.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtVersionDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtPubDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if ($.trim(fuFileName) != "") {
        if (CheckFile(fuFileName)) {
            $.messager.alert('系統提示', '您只能上傳.zip類型的文件！', 'warning');
            return false;
        }
    }
    
    $.post('../ashx/UpdateData.ashx',
           {
               'KeyValue': 'Version',
               'VersionNum': txtVersionNum,
               'VersionDesc': txtVersionDesc,
               'VersionDate': txtVersionDate,
               'PubDate': txtPubDate
           },

            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '修改版本出錯!', 'warning');
                }
                else {
                    iFrameContent.find('#btnOK').click();
                }
            }
         )
}


function startRequest(Return) {
    parent.location.href = Return;
}

///Edit By tanyi 2011/4/8 判斷上傳文件的類型
function CheckFile(strFile) {
    var checkStr = ".zip";
    if (strFile.toString().toLocaleLowerCase().indexOf(checkStr) != -1) {
        return false;
    }
    return true;
}

//刪除
function DeleteClick(lblOperator) {
    var chk = $('tbody>tr>td').find(':checkbox')
    var chked = chk.filter(':checked');

    if (chked.length == 0) {
        $.messager.alert('系统提示', '請選擇要刪除的資料！', 'warning');
    }
    else {

        $.messager.confirm('系统提示', '您確定刪除嗎?',
                                            function(YesOrNO) {

                                                if (YesOrNO) {
                                                    getKeyValue(chked, lblOperator);
                                                }
                                            }
                                       );
    }
}

function getKeyValue(chked, lblOperator) {
    KeyValue = lblOperator.text();

    if (KeyValue == "") {
        $.messager.alert('系统提示', '缺少lblOperator控件！', 'warning');
        return;
    }
    for (i = 0; i < chked.length; i++) {
        KeyValue += "-" + chked[i].parentNode.nextSibling.innerHTML;

    }
    $.post('../ashx/DeleteData.ashx',
           { 'KeyValue': KeyValue },
            function(Return) {

                if (Return == "false") {
                    $.messager.alert('系统提示', '版本刪除失敗！', 'show');
                }
                else if (Return != "../Manage/Sys_VersionInfo.aspx?KeyValue=Deleted") {
                    $.messager.alert('系统提示', '版本' + Return + '正在客戶端系統更新Log中使用，不能刪除！', 'show');
                }
                else {
                    location.href = Return;
                }

            })
}

//查詢
function AjaxForVersionSearch(Url) {
    var iFrameContent = $("#subFrameSel").contents();

    var txtVersionNum = iFrameContent.find('#txtVersionNum').val();
    var txtVersionDesc = iFrameContent.find('#txtVersionDesc').val();
    var txtVersionDate = iFrameContent.find('#txtVersionDate').val();
    var txtPubDate = iFrameContent.find('#txtPubDate').val();
    var txtCreateDate = iFrameContent.find('#txtCreateDate').val();

    if (txtVersionNum.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtVersionDesc.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtVersionDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtPubDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtCreateDate.indexOf('=') != -1)
    {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    $.post('../ashx/SearchData.ashx',
            function(Return) {
                location.href = Url + "?SearchKey=" + txtVersionNum + '=' + txtVersionDesc + '=' + txtVersionDate + '=' + txtPubDate + '='+txtCreateDate+'&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )
}

function AlertFlag(lblFlag) {
    if (lblFlag.text() == "Add") {
        $.messager.alert('系统提示', '版本新增成功！', 'show');
    }
    if (lblFlag.text() == "Update") {
        $.messager.alert('系统提示', '版本修改成功！', 'show');
    }
    if (lblFlag.text() == "Deleted") {
        $.messager.alert('系统提示', '版本刪除成功！', 'show');
    }
}

function checkDate(f1) 
{ 
    var reg=/\d{4}(-|\/)\d{1,2}(-|\/)\d{1,2}/;
    if(reg.test(f1)){
        return true;
    } 
    else{
        return false;
    }
} 


   
