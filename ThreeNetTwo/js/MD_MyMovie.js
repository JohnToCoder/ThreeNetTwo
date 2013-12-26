/*
功能描述：異步調用Ashx程序加載本地圖片文件顯示
人員：胡貴 
時間：2011-03-14

Edit by Tanyi 2011-3-18
*/
$(document).ready(function() {

    $('#Gv_Movie').find("tbody>tr>td>img").each(function() {
        var strImagePath = $(this).attr("src");
        $(this).attr("src", "../ashx/ShowImage.ashx?path=Movie&strId=" + strImagePath);
        $(this).click(function() {
            $('#ShowImage').css("display", "block");
            $('#imgBig').attr("src", "../ashx/ShowImage.ashx?path=Movie&strId=" + strImagePath);
        });
    });
    $('#gvTV').find("tbody>tr>td>img").each(function() {
        var strImagePath = $(this).attr("src");
        $(this).attr("src", "../ashx/ShowImage.ashx?path=TVPlay&strId=" + strImagePath);
        $(this).click(function() {
            $('#ShowTVImg').css("display", "block");
            $('#ImgBigForTV').attr("src", "../ashx/ShowImage.ashx?path=TVPlay&strId=" + strImagePath);
        });
    });
    $('#imgBig').click(function() {
        $('#ShowImage').css("display", "none");
    });
    $('#ImgBigForTV').click(function() {
        $('#ShowTVImg').css("display", "none");
    });
    //Edit By Tanyi 圖片逐漸下載 2011.3.24
    $("img").lazyload({
        placeholder: "../images/grey.gif",
        effect: "fadeIn"
    }); 
    
    /*Edit By Tanyi 2010/10/14 DateTime js*/
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
    $('#txtTVcomeout').datebox(
        {
            formatter: function(date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
            }
        }
    );
    /*Edit By Tanyi 2010/10/14 DateTime js*/
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
    $('#txtTVcreatDate').datebox(
        {
            formatter: function(date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                return y + '/' + (m < 10 ? '0' + m : m) + '/' + (d < 10 ? '0' + d : d);
            }
        }
    );

    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
    });
    $('#btnSelYes').click(function() {
        AjaxForMyMovieSearch('../Movie/MD_MyMovie.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSelForMovie').window('close');
    });

    //查詢頁面及其確定與取消
    $('#btnSelForTV').click(function() {
        openWinSelForTV();
    });
    $('#btnSelYesForTV').click(function() {
        AjaxForMyTVSearch('../Movie/MD_MyMovie.aspx');
    });
    $('#btnCancelForTV').click(function() {
        $('#WinSelForTV').window('close');
    });
});

function openWinSel() {
    $('#WinSelForMovie').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 200,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSelForMovie').css("display", "block");
    $('#WinSelForMovie').window('open');
}

function openWinSelForTV() {
    $('#WinSelForTV').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 200,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSelForTV').css("display", "block");
    $('#WinSelForTV').window('open');
}

function AjaxForMyMovieSearch(Url) {
    var txtMovieName = $('#txtMovieName').val();
    var txtUrl = $('#txtUrl').val();
    var txtComeOut = $('#txtComeOut').val();
    var txtCreator = $('#txtCreator').val();
    var txtCreatDate = $('#txtCreatDate').val();
    var txtServiceID = $('#txtServiceID1').val();

    //Edit By tanyi 2011.3.18
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '上映時間輸入有誤', 'warning');
        return false;
    }
    if (txtCreatDate != "" && !isDate(txtCreatDate).test(txtCreatDate)) {
        $.messager.alert('系统提示', '創建時間輸入有誤', 'warning');
        return false;
    }

    if (txtMovieName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtUrl.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtCreator.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }


    $.post('../ashx/SearchData.ashx',
            function(Return) {
    location.href = Url + "?Flag=1&SearchKeyForMovie=" + escape(txtMovieName) + '=' + escape(txtUrl) + '=' + escape(txtComeOut) + '=' + escape(txtCreator) + '=' + escape(txtCreatDate) +'='+ escape(txtServiceID) + '&rand=' + Math.random();
                $('#WinSelForMovie').window('close');
            }
         )
}
//For Tv Edit By tanyi 2011.3.21
function AjaxForMyTVSearch(Url) {
    var txtTVName = $('#txtTVName').val();
    var txtUrl = $('#txtTVurl').val();
    var txtComeOut = $('#txtTVcomeout').val();
    var txtCreator = $('#txtTVcreator').val();
    var txtCreatDate = $('#txtTVcreatDate').val();
    var txtServiceID = $('#txtServiceID').val();

    //Edit By tanyi 2011.3.18
    if (txtComeOut != "" && !isDate(txtComeOut).test(txtComeOut)) {
        $.messager.alert('系统提示', '上映時間輸入有誤', 'warning');
        return false;
    }
    if (txtCreatDate != "" && !isDate(txtCreatDate).test(txtCreatDate)) {
        $.messager.alert('系统提示', '創建時間輸入有誤', 'warning');
        return false;
    }

    if (txtTVName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtUrl.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    if (txtCreator.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }


    $.post('../ashx/SearchData.ashx',
            function(Return) {
    location.href = Url + "?Flag=2&SearchKeyForTV=" + escape(txtTVName) + '=' + escape(txtUrl) + '=' + escape(txtComeOut) + '=' + escape(txtCreator) + '=' + escape(txtCreatDate) + '=' + escape(txtServiceID) + '&rand=' + Math.random();
                $('#WinSelForTV').window('close');
            }
         )
}
//開發者：沈譚義
//開發功能：我的劇場菜單按鈕初始化時的樣式
//2011.3.21
function startRequest() {
    var flag = $("#txtFlag").val();
    if (flag == "1") {
        var Mymovie = $("#tab_1");
        var MyTV = $("#tab_2");
        Mymovie.attr("class", "aaa");
        MyTV.attr("class", "");
        $("#tab_a2").css("display", "none");
        $("#tab_a1").css("display", "block");

    }
    else if (flag == "2") {
        var Mymovie = $("#tab_1");
        var MyTV = $("#tab_2");
        Mymovie.attr("class", "");
        MyTV.attr("class", "aaa");
        $("#tab_a2").css("display", "block");
        $("#tab_a1").css("display", "none");
    }
}