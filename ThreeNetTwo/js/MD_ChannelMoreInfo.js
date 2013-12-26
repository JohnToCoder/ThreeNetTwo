$(document).ready(function(){

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

    //返回按鈕
    $('#btnReturn').click(function() {
        var pageIndex = $("#txtParentIndex").val();
        parent.document.getElementById("rightFrame").setAttribute("src", "../Channel/MD_Channel.aspx?strPIndex=" + pageIndex);
    });
    
    var lblOperator = $('#lblOperator');
    lblOperator.css("display", "none");
    
    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Channel/MD_ChannelMoreInfo_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        AjaxForChannelSearch('../Channel/MD_ChannelMoreInfo.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });
    
     //新增頁面及其確定與取消
    $('#btnIns').click(function() {
        openWinIns();
        var iFrameIns = $("#subFrameIns");
        iFrameIns[0].src = "../Channel/MD_ChannelMoreInfo_Edit.aspx?flag=ins";
    });
    $('#btnInsYes').click(function() {
        AjaxForChannelIns();
    });
    $('#btnCancel1').click(function() {
        $('#WinIns').window('close');
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
            iFrameUpd[0].src = "../Channel/MD_ChannelMoreInfo_Edit.aspx?flag=upd&key=" + chkKey;
        }
    });
    $('#btnUpdYes').click(function() {
        AjaxForChannelUpd();
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

})

function openWinSel() {
    $('#WinSel').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 330,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}

function AjaxForChannelSearch(Url) {
    var iFrameContent = $("#subFrameSel").contents();
    
    var txtID = $('#txtID').val();
    var txtProgramName=iFrameContent.find('#txtProgramName').val();
    var txtPlayingDate=iFrameContent.find('#txtPlayingDate').val();
//    var txtPlayingTime=iFrameContent.find('#txtPlayingTime').val();
    
    if (txtProgramName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtPlayingDate.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }    

    $.post('../ashx/SearchData.ashx',
            function(Return) {
                location.href = Url + "?SearchKey=" + escape(txtID) + '=' + txtProgramName + '=' + txtPlayingDate 
                     +  '&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )
}

function openWinIns() {
    $('#WinIns').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 330,
        top: 50,
        left: 80,
        resizable: false,
        scroll:false,
        title: ' 新增窗口'
    });
    $('#WinIns').css("display", "block");
    $('#WinIns').window('open');
}

//新增
function AjaxForChannelIns() {
    var iFrameContent = $("#subFrameIns").contents();
    
    var txtID = $('#txtID').val();
    var txtProgramName=iFrameContent.find('#txtProgramName').val();
    var txtPlayingDate=iFrameContent.find('#txtPlayingDate').val();
    var txtPlayingTime=iFrameContent.find('#txtPlayingTime').val();

    
    if ($.trim(txtProgramName) == "") {
        $.messager.alert('系统提示', '節目名稱不能為空！', 'warning');
        return false;
    }
    if ($.trim(txtPlayingDate) == "") {
        $.messager.alert('系统提示', '播放日期不能為空！', 'warning');
        return false;
    }    
    if ($.trim(txtPlayingTime) == "") {
        $.messager.alert('系统提示', '播放時間不能爲空！', 'warning');
        return false;
    }
    
    
    if(!checkDate(txtPlayingDate)){
        $.messager.alert('系统提示', '播放日期格式錯誤！', 'warning');
        return false;
    } 
    if(!checkTime(txtPlayingTime)){
        $.messager.alert('系统提示', '播放時間格式錯誤！', 'warning');
        return false;
    } 
   
       
    $.post('../ashx/AddData.ashx',
           {
               'KeyValue': 'ChannelMore',
               'ChannelID': txtID,
               'ProgramName': txtProgramName,
               'PlayingDate': txtPlayingDate,
               'PlayingTime': txtPlayingTime
           },

            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '新增節目出錯!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '您要添加的節目已經存在!', 'warning');
                }
                else {
                    location.href = Return;
                }
            }
         )
}

function openWinUpd() {
    $('#WinUpd').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 330,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 修改窗口'
    });
    $('#WinUpd').css("display", "block");
    $('#WinUpd').window('open');
}


//修改
function AjaxForChannelUpd() {
    var iFrameContent = $("#subFrameUpd").contents();
    
    var txtID = $('#txtID').val();
    var txtFlagID=iFrameContent.find('#txtFlagID').val();
    var txtProgramName=iFrameContent.find('#txtProgramName').val();
    var txtPlayingDate=iFrameContent.find('#txtPlayingDate').val();
    var txtPlayingTime=iFrameContent.find('#txtPlayingTime').val();

    
    if ($.trim(txtProgramName) == "") {
        $.messager.alert('系统提示', '節目名稱不能為空！', 'warning');
        return false;
    }
    if ($.trim(txtPlayingDate) == "") {
        $.messager.alert('系统提示', '播放日期不能為空！', 'warning');
        return false;
    }
    if ($.trim(txtPlayingTime) == "") {
        $.messager.alert('系统提示', '播放時間不能爲空！', 'warning');
        return false;
    }
    
    if(!checkDate(txtPlayingDate)){
        $.messager.alert('系统提示', '播放日期格式錯誤！', 'warning');
        return false;
    } 
    if(!checkTime(txtPlayingTime)){
        $.messager.alert('系统提示', '播放時間格式錯誤！', 'warning');
        return false;
    }  
       
    $.post('../ashx/UpdateData.ashx',
           {
               'KeyValue': 'ChannelMore',
               'ChannelID':txtID,
               'KeyID':txtFlagID,
               'ProgramName': txtProgramName,
               'PlayingDate': txtPlayingDate,
               'PlayingTime': txtPlayingTime
           },

            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '修改節目出錯!', 'warning');
                }
                else if(Return == "Using"){
                    $.messager.alert('系統提示', '該時間已有節目!', 'warning');
                }                
                else {
                    location.href = Return;
                }
            }
         )
}


function startRequest(Return) {
    parent.location.href = Return;
}

function AlertFlag(lblFlag) {
    if (lblFlag.text() == "Add") {
        $.messager.alert('系统提示', '節目新增成功！', 'show');
    }
    if (lblFlag.text() == "Update") {
        $.messager.alert('系统提示', '節目修改成功！', 'show');
    }
    if (lblFlag.text() == "Deleted") {
        $.messager.alert('系统提示', '節目刪除成功！', 'show');
    }    
}

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
    KeyValue = lblOperator.text();;

    if (KeyValue == "") {
        $.messager.alert('系统提示', '缺少lblOperator控件！', 'warning');
        return;
    }
    
    KeyValue="ChannelMore";
    
    var txtID = $('#txtID').val();
    KeyValue += "-" + txtID;
    
    for (i = 0; i < chked.length; i++) {
        KeyValue += "-" + chked[i].parentNode.nextSibling.innerHTML;
    }
    
    $.post('../ashx/DeleteData.ashx',
           { 'KeyValue': KeyValue},
            function(Return) {

                if (Return == "false") {
                    $.messager.alert('系统提示', '節目刪除失敗！', 'show');
                }
                else if(Return == "Using"){
                    $.messager.alert('系统提示', '節目失敗，該節目正在使用！', 'show');
                }       
                else {
                    location.href = Return;
                }

            })
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

function checkTime(s) 
{ 
    if(isNaN(s[0])){
        return false;
    }
    if(s.length==5 && isNaN(s[4])){
        return false;                
    }
    var regu = "([0-1]?[0-9]|2[0-3]):([0-5]?[0-9])";
    var re = new RegExp(regu);
    if (s.search(re) != -1) {
        return true;
    } 
    else {
        return false;
    }
} 