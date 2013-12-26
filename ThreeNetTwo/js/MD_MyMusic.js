$(document).ready(function() {
    ImageShow();   
    
    $('#txtCreatDate').datebox(
       {
           formatter: function(date) {
               var y = date.getFullYear();
               var m = date.getMonth() + 1;
               var d = date.getDate();
               return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
           }
       }

    );
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
    });
    $('#btnSelYes').click(function() {
        AjaxForMyMusicSearch('../Music/MD_MyMusic.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });
});
//功能描述：異步調用Ashx程序加載本地圖片文件顯示
function ImageShow() {
    //1 .讀取本地圖片以流的方式顯示
    //2 .大小圖片切換瀏覽(需建立div)
    $('#Gv_MyMusic').find("tbody>tr>td>img").each(function() {

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


function openWinSel() {
    $('#WinSel').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 300,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}

function AjaxForMyMusicSearch(Url) {
    var txtMusicName = $('#txtMusicName').val();
    var txtAlbumName = $('#txtAlbumName').val();
    var txtSinger = $('#txtSinger').val();
    var txtCreator = $('#txtCreator').val();
    var txtCreatDate = $('#txtCreatDate').val();
    var txtServiceID = $('#txtServiceID').val();


    if (txtMusicName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '歌曲名稱中不能包含特殊字符,如"="！', 'warning');
        return false;
    }    
    if (txtAlbumName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '專輯名稱中不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    if (txtSinger.indexOf('=') != -1) {
        $.messager.alert('系統提示', '演唱者中不能包含特殊字符,如"="！', 'warning');
        return false;
    }
   
    if (txtCreator.indexOf('=') != -1) {
        $.messager.alert('系統提示', '創建者中不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtCreatDate != "" && !isDate(txtCreatDate).test(txtCreatDate)) {
        $.messager.alert('系统提示', '創建時間輸入有誤', 'warning');
        return false;
    }

    $.post('../ashx/SearchData.ashx',
            function(Return) {
    location.href = Url + "?SearchKey=" + escape(txtMusicName) + '=' + escape(txtAlbumName) + '=' + escape(txtSinger) + '=' + escape(txtCreator) + '=' + escape(txtCreatDate) + '=' + escape(txtServiceID) + '&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )
}