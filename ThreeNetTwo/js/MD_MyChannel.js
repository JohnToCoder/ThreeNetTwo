/*
功能描述：我的節目頁面的相關功能實現
人員：劉鋒 
時間：2011-03-18
*/


$(document).ready(function() {

    //1 .讀取本地圖片以流的方式顯示
    //2 .大小圖片切換瀏覽(需建立div)
    $('#gdvCurrent').find("tbody>tr>td>img").each(function() {

        var strImagePath = $(this).attr("src");
        $(this).attr("src", "../ashx/ShowImage.ashx?path=Channel&strId=" + strImagePath);

        $(this).click(function() {
            $('#ShowImage').css("display", "block");
            $('#imgBig').attr("src", "../ashx/ShowImage.ashx?path=Channel&strId=" + strImagePath);
        });
    });

    $('#imgBig').click(function() {
        $('#ShowImage').css("display", "none");
    });
    
    $('#txtDate').datebox({});
    
//    $( "#txtUserName" ).autocomplete({
//			    source: "ashx/MD_MyChannel_Edit.ashx",
//			    minLength: 2
//	}); 

    var lblOperator = $('#lblOperator');
    lblOperator.css("display", "none");

    //新增頁面及其確定與取消
//    $('#btnIns').click(function() {
//        openWinIns();
//        var iFrameIns = $("#subFrameIns");
//        iFrameIns[0].src = "../Channel/MD_Channel_Edit.aspx?flag=ins";
//    });
//    $('#btnInsYes').click(function() {
//        AjaxForChannelIns();
//    });
//    $('#btnCancel1').click(function() {
//        $('#WinIns').window('close');
//    });    


    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Channel/MD_MyChannel_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
         AjaxForChannelSearch('../Channel/MD_MyChannel.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });


    //修改頁面及其確定與取消
//    $('#btnUpd').click(function() {
//        var chk = $('tbody>tr>td').find(':checkbox')
//        var chked = chk.filter(':checked');

//        if (chked.length == 0) {
//            $.messager.alert('系统提示', '請選擇要修改的資料！', 'warning');
//        }
//        else{
//        openWinUpd();
//        var chkKey = chked[0].parentNode.nextSibling.innerHTML;
//        var iFrameUpd = $("#subFrameUpd");
//        iFrameUpd[0].src = "../Channel/MD_Channel_Edit.aspx?flag=upd&key="+chkKey;
//        }
//    });
//    $('#btnUpdYes').click(function() {
//         AjaxForChannelUpd();
//    });
//    $('#btnCancel3').click(function() {
//        $('#WinUpd').window('close');
//    });

    //刪除頁面
//    $('#btnDel').click(function() {
//        DeleteClick(lblOperator);
//    });
    
    var lblFlag = $('#lblFlag');
    lblFlag.css("display", "none");
    AlertFlag(lblFlag);
});


//function openWinIns() {
//    $('#WinIns').window({
//        width: 650,
//        modal: true,
//        shadow: true,
//        closed: true,
//        height: 400,
//        top: 50,
//        left: 80,
//        resizable: false,
//        title: ' 新增窗口'
//    });
//    $('#WinIns').css("display", "block");
//    $('#WinIns').window('open');
//}

function openWinSel() {
    $('#WinSel').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 370,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}

//function openWinUpd() {
//    $('#WinUpd').window({
//        width: 650,
//        modal: true,
//        shadow: true,
//        closed: true,
//        height: 400,
//        top: 50,
//        left: 80,
//        resizable: false,
//        title: ' 修改窗口'
//    });
//    $('#ddlChannelName').attr("","false");
//    $('#WinUpd').css("display", "block");
//    $('#WinUpd').window('open');
//}

//新增頻道
//function AjaxForChannelIns() {
//    var iFrameContent = $("#subFrameIns").contents();
//    
//    var ddlChannelName=iFrameContent.find('#ddlChannelName').val();
//    var txtChannelUrl=iFrameContent.find('#txtChannelUrl').val();
//    var txtUrlIPad=iFrameContent.find('#txtUrlIPad').val();
//    var txtLogo=iFrameContent.find('#txtLogo').val();
//    var ddlArea=iFrameContent.find('#ddlArea').val();
//    var ddlChannelType=iFrameContent.find('#ddlChannelType').val(); 
//    
//    var file = iFrameContent.find("#FileUploadLogo").val();
//    var pos = file.lastIndexOf("/");
//    if (pos == -1) {
//        pos = file.lastIndexOf("\\");
//    }
//    var fuFileName = file.substr(pos + 1);  

//    if ($.trim(ddlChannelName) == "") {
//        $.messager.alert('系统提示', '請先選擇頻道名稱！', 'warning');
//        return false;
//    }
//    if ($.trim(txtChannelUrl) == "") {
//        $.messager.alert('系统提示', '頻道URL不能為空！', 'warning');
//        return false;
//    }
//    if ($.trim(txtUrlIPad) == "") {
//        $.messager.alert('系统提示', 'URL(iPad)不能爲空！', 'warning');
//        return false;
//    }
//    if ($.trim(ddlArea) == "") {
//        $.messager.alert('系统提示', '地區類型不能爲空！', 'warning');
//        return false;
//    }
//    if ($.trim(ddlChannelType) == "") {
//        $.messager.alert('系统提示', '頻道類型不能爲空！', 'warning');
//        return false;
//    }
//    if ($.trim(fuFileName) == "") {
//        $.messager.alert('系统提示', '請先上傳Logo！', 'warning');
//        return false;
//    }
//    else if (CheckFile(fuFileName)) {
//        $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg類型的圖片！', 'warning');
//        return false;
//    }
//       
//    $.post('../ashx/AddData.ashx',
//           {
//               'KeyValue': 'Channel',
//               'ChannelName': ddlChannelName,
//               'ChannelUrl': txtChannelUrl,
//               'UrlIPad': txtUrlIPad,
//               'Area': ddlArea,
//               'ChannelType': ddlChannelType
//           },

//            function(Return) {
//                if (Return == "false") {
//                    $.messager.alert('系統提示', '新增頻道出錯!', 'warning');
//                }
//                else if (Return == "Double") {
//                    $.messager.alert('系統提示', '您要添加的頻道已經存在!', 'warning');
//                }
//                else {
//                    iFrameContent.find('#btnOK').click();
//                }
//            }
//         )
//}

//修改頻道
//function AjaxForChannelUpd() {
//    var iFrameContent = $("#subFrameUpd").contents();
//    
//    var ddlChannelName=iFrameContent.find('#ddlChannelName').val();
//    var txtChannelUrl=iFrameContent.find('#txtChannelUrl').val();
//    var txtUrlIPad=iFrameContent.find('#txtUrlIPad').val();
//    var txtLogo=iFrameContent.find('#txtLogo').val();
//    var ddlArea=iFrameContent.find('#ddlArea').val();
//    var ddlChannelType=iFrameContent.find('#ddlChannelType').val(); 
//    
//    var file = iFrameContent.find("#FileUploadLogo").val();
//    var pos = file.lastIndexOf("/");
//    if (pos == -1) {
//        pos = file.lastIndexOf("\\");
//    }
//    var fuFileName = file.substr(pos + 1);  

//    if ($.trim(ddlChannelName) == "") {
//        $.messager.alert('系统提示', '請先選擇頻道名稱！', 'warning');
//        return false;
//    }
//    if ($.trim(txtChannelUrl) == "") {
//        $.messager.alert('系统提示', '頻道URL不能為空！', 'warning');
//        return false;
//    }
//    if ($.trim(txtUrlIPad) == "") {
//        $.messager.alert('系统提示', 'URL(iPad)不能爲空！', 'warning');
//        return false;
//    }
//    if ($.trim(ddlArea) == "") {
//        $.messager.alert('系统提示', '地區類型不能爲空！', 'warning');
//        return false;
//    }
//    if ($.trim(ddlChannelType) == "") {
//        $.messager.alert('系统提示', '頻道類型不能爲空！', 'warning');
//        return false;
//    }
//    if ($.trim(fuFileName) == "") {
//        $.messager.alert('系统提示', '請先上傳Logo！', 'warning');
//        return false;
//    }
//    else if (CheckFile(fuFileName)) {
//        $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg類型的圖片！', 'warning');
//        return false;
//    }
//       
//    $.post('../ashx/UpdateData.ashx',
//           {
//               'KeyValue': 'Channel',
//               'ChannelName': ddlChannelName,
//               'ChannelUrl': txtChannelUrl,
//               'UrlIPad': txtUrlIPad,
//               'Area': ddlArea,
//               'ChannelType': ddlChannelType
//           },

//            function(Return) {
//                if (Return == "false") {
//                    $.messager.alert('系統提示', '修改頻道出錯!', 'warning');
//                }                
//                else {
//                    iFrameContent.find('#btnOK').click();
//                }
//            }
//         )
//}


function startRequest(Return) {
    parent.location.href = Return;
}

//function CheckFile(strFile) {
//    var checkStr = ".jpg^.gif^.png^.jpeg";
//    var arrStr = checkStr.split('^');
//    for (var i = 0; i < arrStr.length; i++) {
//        if (strFile.toString().toLocaleLowerCase().indexOf(arrStr[i]) != -1) {
//            return false;
//        }
//    }
//    return true;
//}

//刪除頻道
//function DeleteClick(lblOperator) {
//    var chk = $('tbody>tr>td').find(':checkbox')
//    var chked = chk.filter(':checked');

//    if (chked.length == 0) {
//        $.messager.alert('系统提示', '請選擇要刪除的資料！', 'warning');
//    }
//    else {

//        $.messager.confirm('系统提示', '您確定刪除嗎?',
//                                            function(YesOrNO) {

//                                                if (YesOrNO) {
//                                                    getKeyValue(chked, lblOperator);
//                                                }
//                                            }
//                                       );
//    }
//}

//function getKeyValue(chked, lblOperator) {
//    KeyValue = lblOperator.text();

//    if (KeyValue == "") {
//        $.messager.alert('系统提示', '缺少lblOperator控件！', 'warning');
//        return;
//    }
//    for (i = 0; i < chked.length; i++) {
//        KeyValue += "-" + chked[i].parentNode.nextSibling.innerHTML;

//    }
//    $.post('../ashx/DeleteData.ashx',
//           { 'KeyValue': KeyValue },
//            function(Return) {

//                if (Return == "false") {
//                    $.messager.alert('系统提示', '頻道刪除失敗！', 'show');
//                }
//                else {
//                    location.href = Return;
//                }

//            })
//}

function AjaxForChannelSearch(Url) {
    var iFrameContent = $("#subFrameSel").contents();

    var ddlChannelName=iFrameContent.find('#ddlChannelName').val();
    var txtProgramName=iFrameContent.find('#txtProgramName').val();
    var txtUserName=iFrameContent.find('#txtUserName').val();
    var txtDate = iFrameContent.find('#txtDate').val();
    var txtServiceID = iFrameContent.find('#txtServiceID').val();
    
    if (txtProgramName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtUserName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    
    if (txtDate != "" && !isDate(txtDate).test(txtDate)) {
        $.messager.alert('系统提示', '收藏時間輸入有誤', 'warning');
        return false;
    }

    $.post('../ashx/SearchData.ashx',
            function(Return) {
    location.href = Url + "?SearchKey=" + txtProgramName + '=' + ddlChannelName + '=' + txtServiceID + '=' + txtUserName + '=' + txtDate + '&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )
}

function AlertFlag(lblFlag) {
    if (lblFlag.text() == "Add") {
        $.messager.alert('系统提示', '頻道新增成功！', 'show');
    }
    if (lblFlag.text() == "Update") {
        $.messager.alert('系统提示', '頻道修改成功！', 'show');
    }
    if (lblFlag.text() == "Deleted") {
        $.messager.alert('系统提示', '頻道刪除成功！', 'show');
    }
    
}

 function showMoreInfo(id)
{
     window.showModalDialog('MD_ChannelMoreInfo.aspx?ID=' + id, null,
      'dialogWidth=530px;dialogHeight=260px;center:yes;' + 'help:no'
    + 'status=no;toolbar=no;menubar=no;scroll:no;Resizable=no', '');
    
} 