/*
功能描述：相冊的相關功能實現
人員：胡貴 
時間：2011-03-14
*/

//判定是否成功標誌
var Flag;

$(document).ready(function() {

    //新增頁面及其確定與取消
    $('#btnIns').click(function() {
        openWinIns();
        var iFrameIns = $("#subFrameIns");
        iFrameIns[0].src = "../Photo/MD_Photos_Edit.aspx?flag=ins";
    });
    $('#btnInsYes').click(function() {
        AjaxForPhotoIns();
    });
    $('#btnCancel1').click(function() {
        $('#WinIns').window('close');
    });

    //Edit By Tanyi 圖片逐漸下載 2011.3.24
    $("img").lazyload({
        placeholder: "../images/grey.gif",
        effect: "fadeIn"
    }); 
    
    
    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Photo/MD_Photos_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        AjaxForPhotoSel();
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });


    //修改頁面及其確定與取消
    $('#btnUpd').click(function() {
        var chk = $('#Gv_Photo>tbody>tr>td').find(':checkbox');
        var checked = chk.filter(':checked');

        if (checked.length == 0) {
            $.messager.alert('系统提示', '請選擇要修改的項目！', 'warning');
            return;
        }
        else {
            var id = checked.eq(0).parent().next().text();
            var imaDesc = checked.eq(0).parent().next().next().next().text();
            var pcid = checked.eq(0).parent().next().next().next().next().text();
            var src = checked.eq(0).parent().next().next().find('img').attr("src");

            openWinUpd();
            var iframe = $('#subFrameUpd');
            iframe[0].src = "../Photo/MD_Photos_Edit.aspx?flag=upd&KeyValue=" + id + "^" + escape(imaDesc) + "^" + escape(pcid) + "^" + escape(src);
        }
    });
    $('#btnUpdYes').click(function() {
        AjaxForPhotoUpd();
    });
    $('#btnCancel3').click(function() {
        $('#WinUpd').window('close');
    });

    //刪除頁面
    $('#btnDel').click(function() {
        AjaxForPhotoDel();
    });

    //給出提示信息
    AlertMsg();
});


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


/*
MD_Photo業務邏輯實現
*/

//新增圖片
function AjaxForPhotoIns() {
    var iFrameContent = $("#subFrameIns").contents();
    
    var txtImageName = iFrameContent.find('#txtImageName').val();
    var ddlPictureCatalog = iFrameContent.find('#ddlPictureCatalog').val();
    var fileUpload = iFrameContent.find('#fileUpload').val();

    if ($.trim(txtImageName) == "") {
        $.messager.alert('系统提示', '請輸入圖片名稱！', 'warning');
        return false;
    }

    if ($.trim(ddlPictureCatalog) == "") {
        $.messager.alert('系统提示', '請選擇圖片類型！', 'warning');
        return false;
    }

    if ($.trim(fileUpload) == "") {
        $.messager.alert('系统提示', '請選擇要上傳的圖片！', 'warning');
        return false;
    }

    if (CheckFile($.trim(fileUpload))) {
        $.messager.alert('系统提示', '請上傳.jpg.gif.png.jpeg類型的圖片！', 'warning');
        return false;
    }

    $.post("../ashx/AddData.ashx",
           {
               'KeyValue': 'Photo',
               'ImageName': txtImageName,
               'PictureCatalog': ddlPictureCatalog,
               'FileUpload': fileUpload
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系统提示', '對不起，新增相冊圖片出錯！', 'warning');
                } else if (Return == "Exits") {
                    $.messager.alert('系统提示', '對不起，新增相冊圖片已經存在！', 'warning');
                } else {
                    location.href = Return.toString().split('^')[0];
                    iFrameContent.find('#imgPath').val(Return.toString().split('^')[1]);
                    iFrameContent.find('#btn_OK').click();
                }
            }
     )
}


//查詢圖片
function AjaxForPhotoSel() {
    var iFrameContent = $("#subFrameSel").contents();

    var txtImageName = iFrameContent.find('#txtImageName').val();
    var ddlPictureCatalog = iFrameContent.find('#ddlPictureCatalog').val();

    $.post('../ashx/SearchData.ashx',
        function(Return) {
        location.href = "../Photo/MD_Photos.aspx?SearchKey=" + txtImageName + "=" + ddlPictureCatalog;
            $('#WinSel').window('close');
        }
     )
}


//刪除圖片
function AjaxForPhotoDel() {
    var chk = $('#Gv_Photo>tbody>tr>td').find(':checkbox');
    var checked = chk.filter(':checked');

    if (checked.length == 0) {
        $.messager.alert('系统提示', '請選擇要刪除的資料！', 'warning');
    }
    else {

        $.messager.confirm('系统提示', '您確定刪除嗎?',
                            function(YesOrNO) {
                                if (YesOrNO) {
                                    getKeyValue(checked);
                                }
                            }
                       );
    }
}
function getKeyValue(chked) {
    var KeyValue = "Photo";

    for (i = 0; i < chked.length; i++) {
        KeyValue += "-" + chked.eq(i).parent().next().text();
    }
    $.post('../ashx/DeleteData.ashx?',
       { 'KeyValue': KeyValue },
        function(Return) {
            if (Return == "false") {
                $.messager.alert('系统提示', '對不起，相冊圖片刪除失敗！', 'show');
            }
            else if (Return == "Enjoy") {
                $.messager.alert('系统提示', '對不起，存在加入收藏的相冊圖片！', 'show');
            }
            else {
                location.href = Return;
            }

        })
}

//修改圖片信息
function AjaxForPhotoUpd() {
    var iFrameContent = $("#subFrameUpd").contents();

    var id = iFrameContent.find('#imgID').val();
    var txtImageName = iFrameContent.find('#txtImageName').val();
    var ddlPictureCatalog = iFrameContent.find('#ddlPictureCatalog').val();

    if ($.trim(txtImageName) == "") {
        $.messager.alert('系统提示', '請輸入圖片名稱！', 'warning');
        return false;
    }

    if ($.trim(ddlPictureCatalog) == "") {
        $.messager.alert('系统提示', '請選擇圖片類型！', 'warning');
        return false;
    }

    $.post('../ashx/UpdateData.ashx',
            {
               'KeyValue': 'Photo',
               'ID': id,
               'ImageName': txtImageName,
               'PictureCatalog': ddlPictureCatalog
           },
        function(Return) {
            location.href = Return;
        }
     )
}


function AlertMsg() {
    var Flag = $('#lblFlag');
    if (Flag.text() == "Add") {
        $.messager.alert('系统提示', '相冊圖片新增成功！', 'show');
        Flag.val('');
    }
    if (Flag.text() == "Upd") {
        $.messager.alert('系统提示', '相冊圖片修改成功！', 'show');
        Flag.val('');
    }
    if (Flag.text() == "Del") {
        $.messager.alert('系统提示', '相冊圖片刪除成功！', 'show');
        Flag.val('');
    }
}

function startRequest(Return) {
    parent.location.href = Return;
}