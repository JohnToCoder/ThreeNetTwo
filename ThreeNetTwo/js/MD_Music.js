
$(document).ready(function() {
    ImageShow();
    var lblOperator = $('#lblOperator');
    lblOperator.css("display", "none");

    //獲取當前頁碼索引
    var pageIndex = $("#txtParentIndex").val();

    InsertEvent();
    UpdateEvent();
    DeleteEvent();
    SearchEvent();

    //返回按鈕事件
    ReturnEvent(pageIndex);

    $('#txtComeOut').datebox(
        {
            formatter: function(date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
            }
        }
    );

    var lblFlag = $('#lblFlag');
    lblFlag.css("display", "none");
    AlertFlag(lblFlag);
});

//功能描述：異步調用Ashx程序加載本地圖片文件顯示
function ImageShow() {
    //1 .讀取本地圖片以流的方式顯示
    //2 .大小圖片切換瀏覽(需建立div)
    $('#Gv_Music').find("tbody>tr>td>img").each(function() {

        var strImagePath = $(this).attr("src");
        $(this).attr("src", "../ashx/ShowImage.ashx?path=Music&strId=" + strImagePath);

        $(this).click(function() {
            $('#ShowImage').css("display", "block");
            $('#imgBig').attr("src", "../ashx/ShowImage.ashx?path=Music&strId=" + strImagePath);
        });
    });

    $('#imgBig').click(function() {
        $('#ShowImage').css("display", "none");
    });
}


//新增事件
function InsertEvent() {
    $('#btnIns').click(function() {
        openWinIns();
        var iFrameIns = $("#subFrameIns");
        iFrameIns[0].src = "../Music/MD_Music_Edit.aspx?flag=ins";
    });
    $('#btnInsYes').click(function() {
        AjaxForInsert();
    });
    $('#btnCancel1').click(function() {
        $('#WinIns').window('close');
    });
}

//修改事件
function UpdateEvent() {
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
            iFrameUpd[0].src = "../Music/MD_Music_Edit.aspx?flag=upd&key=" + chkKey;
        }
    });
    $('#btnUpdYes').click(function() {
        AjaxForUpdate();
    });
    $('#btnCancel3').click(function() {
        $('#WinUpd').window('close');
    });
}

//刪除事件
function DeleteEvent(lblOperator) {
    $('#btnDel').click(function() {
        DeleteClick(lblOperator);
    });

}

//查詢事件
function SearchEvent() {
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Music/MD_Music_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        AjaxForSearch('../Music/MD_Music.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });

}

function ReturnEvent(strIndex) {
    $('#btnReturn').click(function() {

        parent.document.getElementById("rightFrame").setAttribute("src", "../Music/MD_Album.aspx?strPIndex=" + strIndex);

    });
}

function openWinIns() {
    $('#WinIns').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 380,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 新增窗口'
    });
    $('#WinIns').css("display", "block");
    $('#WinIns').window('open');
}

function openWinUpd() {
    $('#WinUpd').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 380,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 修改窗口'
    });
    $('#WinUpd').css("display", "block");
    $('#WinUpd').window('open');
}

function openWinSel() {
    $('#WinSel').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 380,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}
//新增音樂信息
function AjaxForInsert() {

    var iFrameContent = $("#subFrameIns").contents();

    var txtMusicName = iFrameContent.find('#txtMusicName').val();

    var ddlAlbum = $("#txtID").val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtSinger = iFrameContent.find('#txtSinger').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtOrder = iFrameContent.find('#txtOrder').val();

    if ($.trim(txtMusicName) == "") {
        $.messager.alert('系统提示', '音樂名稱不能爲空！', 'warning');
        return false;
    }
    if (CheckStr(txtMusicName)) {
        $.messager.alert('系統提示', '音樂名稱中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    if ($.trim(ddlType) == "") {
        $.messager.alert('系统提示', '請先選擇音樂類型！', 'warning');
        return false;
    }
    if ($.trim(txtSinger) == "") {
        $.messager.alert('系统提示', '演唱者不能爲空！', 'warning');
        return false;
    }
    if (CheckStr(txtSinger)) {
        $.messager.alert('系統提示', '演唱者中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    if ($.trim(txtUrl) == "") {
        $.messager.alert('系统提示', '播放地址不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtComeOut) == "") {
        $.messager.alert('系统提示', '發行時間不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtOrder) == "") {
        $.messager.alert('系统提示', '歌曲順序不能為空！', 'warning');
        return false;
    }
    if (parseInt(txtOrder) != txtOrder || parseInt(txtOrder)==0) {
        $.messager.alert('系统提示', '順序必須為正整數,請重新輸入！', 'warning');
        return false;
    }
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '音樂發行時間輸入有誤！', 'warning');
        return false;
    }


    $.post('../ashx/AddData.ashx',
           {
               'KeyValue': 'Music',
               'MusicName': txtMusicName,
               'AlbumID': ddlAlbum,
               'Type': ddlType,
               'Url': txtUrl,
               'ComeOut': txtComeOut,
               'Singer': txtSinger,
               'Order': txtOrder
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '新增歌曲出錯!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '您要添加的歌曲已經存在!', 'warning');
                }
                else if (Return == "Exist") {
                    $.messager.alert('系統提示', '您要添加的歌曲順序已經存在， 請修改!', 'warning');
                }
                else {
                    location.href = Return;
                }
            }
         )
}


function AjaxForUpdate() {
    var iFrameContent = $("#subFrameUpd").contents();

    var txtMusicName = iFrameContent.find('#txtMusicName').val();
    var ddlAlbum = $("#txtID").val();
    var txtMusicID = iFrameContent.find('#lblID').val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtSinger = iFrameContent.find('#txtSinger').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtOrder = iFrameContent.find('#txtOrder').val();

    var strIndex = $('#txtPageIndex').val();



    if ($.trim(txtMusicName) == "") {
        $.messager.alert('系统提示', '歌曲名稱不能爲空！', 'warning');
        return false;
    }
    if (CheckStr(txtMusicName)) {
        $.messager.alert('系統提示', '音樂名稱中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    if ($.trim(ddlType) == "") {
        $.messager.alert('系统提示', '請先選擇歌曲類型！', 'warning');
        return false;
    }
    if ($.trim(txtSinger) == "") {
        $.messager.alert('系统提示', '演唱者不能爲空！', 'warning');
        return false;
    }
    if (CheckStr(txtSinger)) {
        $.messager.alert('系統提示', '演唱者中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }

    if ($.trim(txtUrl) == "") {
        $.messager.alert('系统提示', '播放地址不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtComeOut) == "") {
        $.messager.alert('系统提示', '發行時間不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtOrder) == "") {
        $.messager.alert('系统提示', '歌曲順序不能為空！', 'warning');
        return false;
    }
    if (parseInt(txtOrder) != txtOrder || parseInt(txtOrder) == 0) {
        $.messager.alert('系统提示', '順序必須為正整數,請重新輸入！', 'warning');
        return false;
    }
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '音樂發行時間輸入有誤！', 'warning');
        return false;
    }


    $.post('../ashx/UpdateData.ashx',
           {
               'KeyValue': 'Music',
               'MusicName': txtMusicName,
               'AlbumName': ddlAlbum,
               'Type': ddlType,
               'Url': txtUrl,
               'ComeOut': txtComeOut,
               'Singer': txtSinger,
               'MusicID': txtMusicID,
               'PageIndex': strIndex, 
               'Order': txtOrder

           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '更新歌曲出錯!', 'warning');
                }
                if (Return == "Double") {
                    $.messager.alert('系統提示', '該歌曲已經存在,不允許重複添加!', 'warning');
                }
                else if (Return == "Exist") {
                    $.messager.alert('系統提示', '您要添加的歌曲順序已經存在， 請修改!', 'warning');
                }
                else {
                    location.href = Return;
                }
            }
         )

}
//刪除操作
function DeleteClick() {
    var chk = $('tbody>tr>td').find(':checkbox')
    var chked = chk.filter(':checked');

    if (chked.length == 0) {
        $.messager.alert('系统提示', '請選擇要刪除的資料！', 'warning');
    }
    else {

        $.messager.confirm('系统提示', '您確定刪除嗎?',
                                            function(YesOrNO) {

                                                if (YesOrNO) {
                                                    getKeyValue(chked);
                                                }
                                            }
                                       );
    }
}

function getKeyValue(chked) {

    KeyValue = "Music";

    if (KeyValue == "") {
        $.messager.alert('系统提示', '缺少lblOperator控件！', 'warning');
        return;
    }
    for (i = 0; i < chked.length; i++) {
        KeyValue += "-" + chked[i].parentNode.nextSibling.innerHTML;

    }
    KeyValue += "-" + $("#txtID").val();
    $.post('../ashx/DeleteData.ashx',
           { 'KeyValue': KeyValue },
            function(Return) {

                if (Return == "false") {
                    $.messager.alert('系统提示', '專輯刪除失敗！', 'show');
                }
                if (Return == "UserAdd") {
                    $.messager.alert('系统提示', '該專輯加入收藏,不允許刪除！', 'show');
                }
                else {
                    location.href = Return;
                }

            })
}
//查詢功能實現
function AjaxForSearch(Url) {
    var iFrameContent = $("#subFrameSel").contents();

    var txtMusicName = iFrameContent.find('#txtMusicName').val();
    var ddlAlbumID = $("#txtID").val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtSinger = iFrameContent.find('#txtSinger').val();
    var txtOrder = iFrameContent.find('#txtOrder').val();




    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '上映時間輸入有誤', 'warning');
        return false;
    }

    if (txtMusicName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtSinger.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtUrl.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }


    $.post('../ashx/SearchData.ashx',
            function(Return) {
                location.href = Url + "?SearchKey=" + escape(txtMusicName) + '=' + ddlAlbumID + '=' + ddlType + '=' + txtUrl + '=' + txtComeOut + '=' + txtSinger +'='+txtOrder+ '&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )

}

function AlertFlag(lblFlag) {
    if (lblFlag.text() == "Add") {
        $.messager.alert('系统提示', '音樂新增成功！', 'show');

    }
    if (lblFlag.text() == "Update") {
        $.messager.alert('系统提示', '音樂修改成功！', 'show');

    }
    if (lblFlag.text() == "Delete") {
        $.messager.alert('系统提示', '音樂刪除成功！', 'show')
    }
}

