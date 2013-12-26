/*
功能描述：異步調用Ashx程序加載本地圖片文件顯示
人員：胡貴 
時間：2011-03-14
*/
$(document).ready(function() {

    //1 .讀取本地圖片以流的方式顯示
    //2 .大小圖片切換瀏覽(需建立div)
    $('#Gv_TVPlay').find("tbody>tr>td>img").each(function() {

        var strImagePath = $(this).attr("src");
        $(this).attr("src", "../ashx/ShowImage.ashx?path=TVPlay&strId=" + strImagePath);

        $(this).click(function() {
            $('#ShowImage').css("display", "block");
            $('#imgBig').attr("src", "../ashx/ShowImage.ashx?path=TVPlay&strId=" + strImagePath);
        });
    });

    $('#imgBig').click(function() {
        $('#ShowImage').css("display", "none");
    });
    //時間控件
    $('#txtComeOut').datebox(
            {
                formatter: function(date) 
                 {
                 var y = date.getFullYear();
                 var m = date.getMonth() + 1;
                 var d = date.getDate();
                 return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
                }
            }
    );
    

    var lblOperator = $('#lblOperator');
    lblOperator.css("display", "none");



    //新增頁面功能的實現
    $('#btnIns').click(function() {
        openWinIns();
        var iFrameIns = $("#subFrameIns");
        iFrameIns[0].src = "../TVPlay/MD_TVPlay_Edit.aspx?flag=ins";
    });
    $('#btnInsYes').click(function() {
        AjaxForTVPlayIns();
    });
    $('#btnCancel1').click(function() {
        $('#WinIns').window('close');
    });
    //修改頁面功能的實現

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
            iFrameUpd[0].src = "../TVPlay/MD_TVPlay_Edit.aspx?flag=upd&key=" + chkKey;
        }
    });
    $('#btnUpdYes').click(function() {
        AjaxForTVPlayupd();
    });
    $('#btnCancel3').click(function() {
        $('#WinUpd').window('close');
    });
    //刪除頁面
    $('#btnDel').click(function() {
        DeleteClick(lblOperator);
    });
    //查詢頁面及按鈕
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../TVPlay/MD_TVPlay_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        AjaxForTVPlaySearch('../TVPlay/MD_TVPlay.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });


    var lblFlag = $('#lblFlag');
    lblFlag.css("display", "none");
    AlertFlag(lblFlag);
});


///打開新的窗口

function openWinMore() {
    $('#WinMore').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 400,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 更多信息'
    });
    $('#WinMore').css("display", "block");
    $('#WinMore').window('open');
}
function openWinIns() {
    $('#WinIns').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 400,
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
        height: 400,
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
        height: 400,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}

/*
MD_TVPlay業務邏輯實現
2011.3.16
*/

//新增電視劇
function AjaxForTVPlayIns() {

    var iFrameContent = $("#subFrameIns").contents();

    var txtTVPlayName = iFrameContent.find('#txtTVPlayName').val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtDesc = iFrameContent.find('#txtDesc').val();
    var ddlMediaSource = iFrameContent.find('#ddlMediaSource').val();

    var file = iFrameContent.find("#fileUpload").val();
    
    var pos = file.lastIndexOf("/");
    if (pos == -1) {
        pos = file.lastIndexOf("\\");
    }
    var fuFileName = file.substr(pos + 1);

    if ($.trim(txtTVPlayName) == "") {
        $.messager.alert('系统提示', '電視名稱不能爲空！', 'warning');
        return false;
    }
    if ($.trim(ddlType) == "0") {
        $.messager.alert('系统提示', '電視劇分類不可為空！', 'warning');
        return false;
    }
    if ($.trim(txtUrl) == "") {
        $.messager.alert('系统提示', '播放地址不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtComeOut) == "") {
        $.messager.alert('系统提示', '上映時間不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtDesc) == "") {
        $.messager.alert('系统提示', '劇情簡介不能爲空！', 'warning');
        return false;
    }
    if ($.trim(ddlMediaSource) == "0") {
        $.messager.alert('系统提示', '媒體來源不能爲空！', 'warning');
        return false;
    }
    if (CheckStr(txtTVPlayName)) {
        $.messager.alert('系統提示', '電視劇名稱中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    if ($.trim(txtDesc) != "") {
        if (CheckStr(txtDesc)) {
            $.messager.alert('系統提示', '電視劇簡介中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '電視劇上映時間輸入有誤！', 'warning');
        return false;
    }

    if ($.trim(fuFileName) == "") {
        $.messager.alert('系统提示', '請先上傳劇照！', 'warning');
        return false;
    }
    else if (CheckFile(fuFileName)) {
        $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg類型的圖片！', 'warning');
        return false;
    }
    $.post('../ashx/AddData.ashx',
           {
               'KeyValue': 'TVPlay',
               'TVPlayName': txtTVPlayName,
               'Type': ddlType,
               'Url': txtUrl,
               'ComeOut': txtComeOut,
               'Desc': txtDesc,
               'MediaSource': ddlMediaSource
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '新增電視劇出錯!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '您要添加的電視劇已經存在!', 'warning');
                }
                else {
                    iFrameContent.find('#btn_OK').click();
                }
            }
         )
}
//修改電視劇信息
function AjaxForTVPlayupd() 
{
    var iFrameContent = $("#subFrameUpd").contents();

    var txtTVPlayName = iFrameContent.find('#txtTVPlayName').val();
    var lblTVPlayID = iFrameContent.find('#lblID').val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtDesc = iFrameContent.find('#txtDesc').val();
    var ddlMediaSource = iFrameContent.find('#ddlMediaSource').val();

    var strIndex = $('#txtPageIndex').val();
    
    iFrameContent.find('#txtPageRecord').val(strIndex);

    var file = iFrameContent.find("#fileUpload").val();
    var pos = file.lastIndexOf("/");
    if (pos == -1) {
        pos = file.lastIndexOf("\\");
    }
    var fuFileName = file.substr(pos + 1);

    if ($.trim(txtTVPlayName) == "") {
        $.messager.alert('系统提示', '電視劇名稱不能爲空！', 'warning');
        return false;
    }
    if ($.trim(ddlType) == "0") {
        $.messager.alert('系统提示', '請先選擇電視類型！', 'warning');
        return false;
    }
    if ($.trim(txtUrl) == "") {
        $.messager.alert('系统提示', '地址不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtComeOut) == "") {
        $.messager.alert('系统提示', '上映時間不能爲空！', 'warning');
        return false;
    }
    if ($.trim(ddlMediaSource) == "0") {
        $.messager.alert('系统提示', '媒體類型不能爲空！', 'warning');
        return false;
    }

    if (CheckStr(txtTVPlayName)) {
        $.messager.alert('系統提示', '電視劇名稱中不能包含@/\"#$%&^*！', 'warning');
        return false;
    }
    if ($.trim(txtDesc) != "") {
        if (CheckStr(txtDesc)) {
            $.messager.alert('系統提示', '電視劇簡介中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '電視劇上映時間輸入有誤！', 'warning');
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
               'KeyValue': 'TVPlay',
               'TVPlayName': txtTVPlayName,
               'TVPlayID':lblTVPlayID,
               'Type': ddlType,
               'Url': txtUrl,
               'ComeOut': txtComeOut,
               'Desc': txtDesc,
               'MediaSource': ddlMediaSource,
               'PageIndex': strIndex
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '更新電視出錯!', 'warning');
                }
                if (Return == "Double") {
                    $.messager.alert('系統提示', '該電視劇已經存在,不允許重複添加!', 'warning');
                }
                
                else {
                    iFrameContent.find('#btn_OK').click();
                }
            }
         )
}

//查詢電視劇信息功能事項
function AjaxForTVPlaySearch(Url) {
    var iFrameContent = $("#subFrameSel").contents();

    var txtTVPlayName = iFrameContent.find('#txtTVPlayName').val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtDesc = iFrameContent.find('#txtDesc').val();
    var ddlMediaSource = iFrameContent.find('#ddlMediaSource').val();
    
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '上映時間輸入有誤', 'warning');
        return false;
    }
    if (txtTVPlayName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '電視劇名稱不能包含特殊字符，如"="!', 'warning');
        return false;
    }
    if (txtUrl.indexOf('=') != -1) {
        $.messager.alert('系統提示', '播放地址不能包含特殊字符，如"="!', 'warning');
        return false;
    }
    if (txtDesc.indexOf('=') != -1) {
        $.messager.alert('系統提示', '電視劇描述中不能包含特殊字符，如"="!', 'warning');
        return false;
    }
   

    $.post('../ashx/SearchData.ashx',
            function(Return)
             {
                location.href = Url + "?SearchKey=" + escape(txtTVPlayName) + '=' + ddlType + '=' + txtUrl + '=' + txtComeOut + '=' + txtDesc+ '=' + ddlMediaSource + '&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )
}
//刪除電視劇
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
                    $.messager.alert('系统提示', '電視劇刪除失敗！', 'show');
                }

               else  if (Return == "ExistTVsub") {
                    $.messager.alert('系统提示', '該電視劇中有分集存在,不允許刪除！', 'show');
                }
              else   if (Return == "ExistInMyTVPlay") {
                    $.messager.alert('系统提示', '該電視劇加入我的收藏,不允許刪除！', 'show');
                }
                else {
                    location.href = Return;
                }

            })
}
/*
功能:設置延遲鏈接頁面
開發人員：沈譚義
開發時間:2011-03-16
*/
function startRequest(Return) {
    parent.location.href = Return;
}
/*
功能:彈出提示窗口
開發人員：沈譚義
開發時間:2011-03-16
*/
function AlertFlag(lblFlag) {
    if (lblFlag.text() == "Add") {
        $.messager.alert('系统提示', '電視劇新增成功！', 'show');
    }
    if (lblFlag.text() == "Update") {
        $.messager.alert('系统提示', '電視劇修改成功！', 'show');
    }
    if (lblFlag.text() == "Deleted") {
        $.messager.alert('系统提示', '電視劇 刪除成功！', 'show');
    }

}

function TVPlayEdit(strID) {
    var pageIndex = $("#txtPageIndex").val();
    parent.document.getElementById("rightFrame").setAttribute("src", "../TVPlay/MD_TVPlayMoreInfo.aspx?strID=" + strID + "&pageIndex=" + pageIndex);
}



