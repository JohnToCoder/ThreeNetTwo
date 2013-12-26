
$(document).ready(function() {
    ImageShow();
    var lblOperator = $('#lblOperator');
    lblOperator.css("display", "none");

    InsertEvent();
    UpdateEvent();
    DeleteEvent();
    SearchEvent();

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
    $('#Gv_Album').find("tbody>tr>td>img").each(function() {

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
        iFrameIns[0].src = "../Music/MD_Album_Edit.aspx?flag=ins";
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
            iFrameUpd[0].src = "../Music/MD_Album_Edit.aspx?flag=upd&key=" + chkKey;
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
        iFrameSel[0].src = "../Music/MD_Album_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        AjaxForSearch('../Music/MD_Album.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
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
//新增專輯信息
function AjaxForInsert() {

    var iFrameContent = $("#subFrameIns").contents();

    var txtAlbumName = iFrameContent.find('#txtAlbumName').val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtSinger = iFrameContent.find('#txtSinger').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var ddlMediaSource = iFrameContent.find('#ddlMediaSource').val();

    var file = iFrameContent.find("#fileUpload").val();

    var pos = file.lastIndexOf("/");
    if (pos == -1) {
        pos = file.lastIndexOf("\\");
    }
    var fuFileName = file.substr(pos + 1);

    if ($.trim(txtAlbumName) == "") {
        $.messager.alert('系统提示', '專輯名稱不能爲空！', 'warning');
        return false;
    }
    if (CheckStr(txtAlbumName)) {
        $.messager.alert('系統提示', '專輯名稱中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    
    if ($.trim(ddlType) == "") {
        $.messager.alert('系统提示', '請先選擇專輯類型！', 'warning');
        return false;
    }
    if ($.trim(txtUrl) == "") {
        $.messager.alert('系统提示', '播放地址不能爲空！', 'warning');
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
    if ($.trim(txtComeOut) == "") {
        $.messager.alert('系统提示', '發行時間不能爲空！', 'warning');
        return false;
    }
    
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '專輯發行時間輸入有誤！', 'warning');
        return false;
    }
    if ($.trim(ddlMediaSource) == "") {
        $.messager.alert('系统提示', '媒體類型不能爲空！', 'warning');
        return false;
    }
    if ($.trim(fuFileName) == "") {
        $.messager.alert('系统提示', '請先上傳專輯圖片！', 'warning');
        return false;
    }
    else if (CheckFile(fuFileName)) {
        $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg類型的圖片！', 'warning');
        return false;
    }
    $.post('../ashx/AddData.ashx',
           {
               'KeyValue': 'Album',
               'AlbumName': txtAlbumName,
               'Type': ddlType,
               'Url': txtUrl,
               'ComeOut': txtComeOut,
               'Singer': txtSinger,
               'MediaSource': ddlMediaSource
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '新增專輯出錯!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '您要添加的專輯已經存在!', 'warning');
                }
                else {

                    iFrameContent.find('#btn_OK').click();
                }
            }
         )
}
//修改專輯信息

function AjaxForUpdate() {
    var iFrameContent = $("#subFrameUpd").contents();

    var txtAlbumName = iFrameContent.find('#txtAlbumName').val();
    var txtAlbumID = iFrameContent.find('#lblID').val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtSinger = iFrameContent.find('#txtSinger').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var ddlMediaSource = iFrameContent.find('#ddlMediaSource').val();

    var strIndex = $('#txtPageIndex').val();

    iFrameContent.find('#txtPageRecord').val(strIndex);

    var file = iFrameContent.find("#fileUpload").val();
    var pos = file.lastIndexOf("/");
    if (pos == -1) {
        pos = file.lastIndexOf("\\");
    }
    var fuFileName = file.substr(pos + 1);

    if ($.trim(txtAlbumName) == "") {
        $.messager.alert('系统提示', '專輯名稱不能爲空！', 'warning');
        return false;
    }
    if (CheckStr(txtAlbumName)) {
        $.messager.alert('系統提示', '專輯名稱中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    if ($.trim(ddlType) == "") {
        $.messager.alert('系统提示', '請先選擇專輯類型！', 'warning');
        return false;
    }
    if ($.trim(txtSinger) == "") {
        $.messager.alert('系统提示', '演唱者不能爲空！', 'warning');
        return false;
    }
    if (CheckStr(txtSinger)) {
        $.messager.alert('系統提示', '專輯名稱中不能包含@/\"#$%&^*！', 'warning');
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

    if ($.trim(ddlMediaSource) == "") {
        $.messager.alert('系统提示', '媒體類型不能爲空！', 'warning');
        return false;
    }

    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '專輯發行時間輸入有誤！', 'warning');
        return false;
    }

    if (CheckFile(fuFileName)) {
        $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg.bmp類型的圖片！', 'warning');
        return false;
    }

    if ($.trim(fuFileName) != "") {
        if (CheckFile(fuFileName)) {
            $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg.bmp類型的圖片！', 'warning');
            return false;
        }
    }
    $.post('../ashx/UpdateData.ashx',
           {
               'KeyValue': 'Album',
               'AlbumName': txtAlbumName,
               'AlbumID':txtAlbumID,
               'Type': ddlType,
               'Url': txtUrl,
               'ComeOut': txtComeOut,
               'Singer': txtSinger,
               'MediaSource': ddlMediaSource,
               'PageIndex': strIndex
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '更新專輯出錯!', 'warning');
                }
                if (Return == "Double") {
                    $.messager.alert('系統提示', '該專輯已經存在,不允許重複添加!', 'warning');
                }
                else {
                    iFrameContent.find('#btn_OK').click();
                }
            }
         )

}

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
    KeyValue = "Album";


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
                    $.messager.alert('系统提示', '專輯刪除失敗！', 'show');
                }
                else if (Return == "Use") {
                    $.messager.alert('系统提示', '該專輯中有歌曲,不能刪除！', 'show');
                }
                else if (Return == "UserAdd") {
                    $.messager.alert('系统提示', '該專輯加入我的收藏,不能刪除！', 'show');
                }
                else {
                    location.href = Return;
                }

            })
}

function AjaxForSearch(Url) {
    var iFrameContent = $("#subFrameSel").contents();

    var txtAlbumName = iFrameContent.find('#txtAlbumName').val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtSinger = iFrameContent.find('#txtSinger').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var ddlMediaSource = iFrameContent.find('#ddlMediaSource').val();

    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '上映時間輸入有誤', 'warning');
        return false;
    }
    
    if (txtAlbumName.indexOf('=') != -1) {
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
                location.href = Url + "?SearchKey=" + escape(txtAlbumName) + '=' + ddlType + '=' + txtUrl + '=' + txtComeOut + '=' + txtSinger + '=' + ddlMediaSource + '&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )

}

/*
功能:設置延遲鏈接頁面
開發人員：沈譚義
開發時間:2011-03-16
*/
function startRequest(Return) {
    parent.location.href = Return;
}

//彈出提示框

function AlertFlag(lblFlag) {
    if (lblFlag.text() == "Add") {
        $.messager.alert('系统提示', '專輯新增成功！', 'show');
    }
    if (lblFlag.text() == "Update") {
        $.messager.alert('系统提示', '專輯修改成功！', 'show');
    }
    if (lblFlag.text() == "Delete") {
        $.messager.alert('系统提示', '專輯刪除成功！', 'show')
    }
}

//加載所有音樂維護頁面
function MusicEdit(strID) {
    var pageIndex=$("#txtPageIndex").val();

    parent.document.getElementById("rightFrame").setAttribute("src", "../Music/MD_Music.aspx?strID=" + strID + "&pageIndex=" + pageIndex);
}

