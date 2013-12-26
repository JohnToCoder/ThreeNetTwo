/*
功能描述：異步調用Ashx程序加載本地圖片文件顯示
人員：胡貴 
時間：2011-03-14

Edit by Tanyi 2011-3-15
*/
$(document).ready(function() {

    $('#Gv_Movie').find("tbody>tr>td>img").each(function() {
        var strImagePath = $(this).attr("src");
        $(this).attr("src", "../ashx/ImgShowForMovie.ashx?strId=" + strImagePath);
        $(this).click(function() {
            $('#ShowImage').css("display", "block");
            $('#imgBig').attr("src", "../ashx/ImgShowForMovie.ashx?strId=" + strImagePath);
        });
    });
    $('#imgBig').click(function() {
        $('#ShowImage').css("display", "none");
    });
    /*Edit By Tanyi 2010/10/14 DateTime js*/
    $('#txtComeOut').datebox(
        {
            required: true
        }
    );

    //新增頁面功能的實現
    $('#btnIns').click(function() {
        openWinIns();
        var iFrameIns = $("#subFrameIns");
        iFrameIns[0].src = "../Movie/MD_Movie_Edit.aspx?flag=ins";
    });
    $('#btnInsYes').click(function() {
        AjaxForMovieIns();
    });
    $('#btnCancel1').click(function() {
        $('#WinIns').window('close');
    });
});
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
/*
MD_Moive業務邏輯實現
Edit By Tanyi 2011.3.16
*/

//新增電影
function AjaxForMovieIns() {
    var iFrameContent = window.frames["subFrameIns"];

    var txtMovieName = iFrameContent.find('#txtMovieName').val();
    var ddlType = iFrameContent.find('#ddlType').val();
    var txtUrl = iFrameContent.find('#txtUrl').val();
    var txtComeOut = iFrameContent.find('#txtComeOut').val();
    var txtDesc = iFrameContent.find('#txtDesc').val();
    var ddlArea = iFrameContent.find('#ddlArea').val();
    var ddlMediaSource = iFrameContent.find('#ddlMediaSource').val();

    if ($.trim(txtMovieName) == "") {
        $.messager.alert('系统提示', '電影名稱不能爲空！', 'warning');
        return false;
    }
    if ($.trim(ddlType) == "0") {
        $.messager.alert('系统提示', '請先選擇電影類型！', 'warning');
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
    if ($.trim(ddlArea) == "0") {
        $.messager.alert('系统提示', '地區不能爲空！', 'warning');
        return false;
    }
    if ($.trim(ddlMediaSource) == "0") {
        $.messager.alert('系统提示', '媒體類型不能爲空！', 'warning');
        return false;
    }
    if (CheckFile(fuFileName)) {
        $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg類型的圖片！', 'warning');
        return false;
    }
    $.post('../ashx/UpdateData.ashx',
           {
               'KeyValue': '71',
               'FormName': fuFileName,
               'FormType': ddlFormType
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '新增資料錯誤!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '您要上傳的表單已經存在!', 'warning');
                }
                else {
                    iFrameContent.find('#btn_OK').click();
                }
            }
         )
}
/*
功能：上傳文件類型是否合法
開發人員：沈譚義
開發時間:2011-03-16
*/
function CheckFile(strFile) {
    var checkStr = ".jpg^.gif^.png^.jpeg^";
    var arrStr = checkStr.split('^');
    for (var i = 0; i < arrStr.length; i++) {
        if (strFile.toString().toLocaleLowerCase().indexOf(arrStr[i]) != -1) {
            return false;
        }
    }
    return true;
}