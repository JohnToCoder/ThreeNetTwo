$(document).ready(function() {

    //1 .讀取本地圖片以流的方式顯示
    //2 .大小圖片切換瀏覽(需建立div)
$('#Gv_TVPlaySub').find("tbody>tr>td>img").each(function() {

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

    //  獲取當前頁碼索引
    var pageIndex = $("#txtParentIndex").val();

  

    //時間控件
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
    //彈出框    
    var lblFlag = $('#lblFlag');
    lblFlag.css("display", "none");
    AlertFlag(lblFlag);

//刪除時用
    var lblOperator = $('#lblOperator');
    lblOperator.css("display", "none");

      //新增頁面功能的實現
    $('#btnIns').click(function() {
        openWinIns();
        var iFrameIns = $("#subFrameIns");
        iFrameIns[0].src = "../TVPlay/MD_TVPlayMoreInfo_Edit.aspx?flag=ins";
    });
    $('#btnInsYes').click(function() {
       AjaxForTVPlaySubIns();
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
            iFrameUpd[0].src = "../TVPlay/MD_TVPlayMoreInfo_Edit.aspx?flag=upd&key=" + chkKey;
        }
    });
    $('#btnUpdYes').click(function() {
        AjaxForTVPlaySubupd();
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
        iFrameSel[0].src = "../TVPlay/MD_TVPlayMoreInfo_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
       AjaxForTVPlaySubSearch('../TVPlay/MD_TVPlayMoreInfo.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });
    //返回按鈕事件
    ReturnEvent(pageIndex);     

});
//返回按鈕
function ReturnEvent(strIndex) {
    $('#btnReturn').click(function() {
        parent.document.getElementById("rightFrame").setAttribute("src", "../TVPlay/MD_TVPlay.aspx?strPIndex=" + strIndex);
    });
}

///打開新的窗口
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
//邏輯實現
// 新增
function AjaxForTVPlaySubIns() {

    var iFrameContent = $("#subFrameIns").contents();

    var txtTVsub = iFrameContent.find('#txtTVsub').val();
    var txtTVPlayID = $("#txtID").val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtDesc = iFrameContent.find('#txtDesc').val();
    

  
    if ($.trim(txtTVsub) == "") {
        $.messager.alert('系统提示', '電視劇分集不可為空！', 'warning');
        return false;
    }
    if ($.trim(txtComeOut) == "") {
        $.messager.alert('系统提示', '上映時間不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtUrl) == "") {
        $.messager.alert('系统提示', '地址不能爲空！', 'warning');
        return false;
    }

    if ($.trim(txtDesc) == "") {
        $.messager.alert('系统提示', '劇情簡介不能爲空！', 'warning');
        return false;
    }
    
    if(parseInt(txtTVsub)!=txtTVsub||parseInt(txtTVsub)==0) {
        $.messager.alert('系统提示', '分集必須為正整數,請重新輸入！', 'warning');
        return false;
    }
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '分集上映時間輸入有誤！', 'warning');
        return false;
    }  
 
    if ($.trim(txtDesc) != "") {
        if (CheckStr(txtDesc)) {
            $.messager.alert('系統提示', '劇情簡介中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
    $.post('../ashx/AddData.ashx',
           {
               'KeyValue': 'TVPlaySub',
               'TVSub': txtTVsub,
               'TVPlayID': txtTVPlayID,
               'Url': txtUrl,
               'ComeOut': txtComeOut,
               'Desc': txtDesc             
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '新增電視劇出錯!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '您要添加的電視劇分集已經存在!', 'warning');
                }
                else {
                    location.href = Return;
                }
            }
         )
}
//修改
function AjaxForTVPlaySubupd() {

    var iFrameContent = $("#subFrameUpd").contents();


    var txtTVsub = iFrameContent.find('#txtTVsub').val();
    var txtTVPlayID = $("#txtID").val();
    var txtTVsubID = iFrameContent.find('#lblID').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtDesc = iFrameContent.find('#txtDesc').val();

    var strIndex = $('#txtPageIndex').val();
    
   
    if ($.trim(txtTVsub) == "") {
        $.messager.alert('系统提示', '電視劇分集不可！', 'warning');
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
    if ($.trim(txtDesc) == "") {
        $.messager.alert('系统提示', '劇情簡介不能爲空！', 'warning');
        return false;
    }
    if (parseInt(txtTVsub) != txtTVsub || parseInt(txtTVsub) == 0) {
        $.messager.alert('系统提示', '分集必須為正整數,請重新輸入！', 'warning');
        return false;
    }
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '電視劇上映時間輸入有誤！', 'warning');
        return false;
    }  
    
    if ($.trim(txtDesc) != "") {
        if (CheckStr(txtDesc)) {
            $.messager.alert('系統提示', '電視劇簡介中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }     

    $.post('../ashx/UpdateData.ashx',
           {
              'KeyValue': 'TVPlaySub',
              'TVSub': txtTVsub,
              'TVPlayID': txtTVPlayID,
              'TVSubID': txtTVsubID,              
              'Url': txtUrl,
              'ComeOut': txtComeOut,
              'Desc': txtDesc,
              'PageIndex': strIndex      
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '更新電視出錯!', 'warning');
                }
                if (Return == "Double") {
                    $.messager.alert('系統提示', '該分集已經存在,不允許重複添加!', 'warning');
                }
                else {
                    location.href = Return;
                }
            }
         )
}

//查詢電視劇信息功能事項
function AjaxForTVPlaySubSearch(Url) {

    var iFrameContent = $("#subFrameSel").contents();

    var txtTVsub = iFrameContent.find('#txtTVsub').val();
    var txtTVPlayID = $("#txtID").val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtDesc = iFrameContent.find('#txtDesc').val();
    
    
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '上映時間輸入有誤', 'warning');
        return false;
    }
    if (parseInt(txtTVsub) != txtTVsub||parseInt(txtTVsub)==0) {
        $.messager.alert('系统提示', '分集必須為正整數,請重新輸入！', 'warning');
        return false;
    }
    if (txtTVsub.indexOf('=') != -1) {
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
            function(Return) {
    location.href = Url + "?SearchKey=" + escape(txtTVsub) + '=' + txtTVPlayID + '=' + txtUrl + '=' + txtComeOut + '=' + txtDesc + '&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )
}
//刪除電視劇分集
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
function getKeyValue(chked, lblOperator) {
    KeyValue ="TVPlaySub";

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
                    $.messager.alert('系统提示', '電視劇分集刪除失敗！', 'show');
                }
                if (Return == "ExistInMyTVSub") {
                    $.messager.alert('系统提示', '該分集加入我的收藏,不允許刪除！', 'show');
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
        $.messager.alert('系统提示', '電視劇分集新增成功！', 'show');
    }
    if (lblFlag.text() == "Update") {
        $.messager.alert('系统提示', '電視劇分集修改成功！', 'show');
    }
    if (lblFlag.text() == "Deleted") {
        $.messager.alert('系统提示', '電視劇分集刪除成功！', 'show');
    }

}

