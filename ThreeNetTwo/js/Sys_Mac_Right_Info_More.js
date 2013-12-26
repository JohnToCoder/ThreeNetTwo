$(document).ready(function() {

    var flag = $('#txtFlag').val();
    $('#btnSel').click(function() {
        btnOkClick();
    });

})

function btnOkClick() {
    var iFrameContent = $('#subFrame');

    var flag = $('#txtFlag').val();
    var role = $('#txtRole').val();

    //頻道
    var className = $('#ddlClass').val();
    var PlayDate = $('#txtCDate').val();
    
    //電影
    var MovieName = $('#txtMovieName').val();
    var TVDate = $('#txtTDate').val();

    //音樂
    var MClass = $('#ddlIistClass').val();
    var Mname = $('#txtPhotoName').val();
    var Mdate = $('#txtMdate').val();



    AjaxForSysChannelSearch(iFrameContent, '../../Manage/MacRight/Sys_MacRight_Info_More.aspx?flag=' + flag +
     "&mac=" + role + "&class=" + className + "&playDate=" + PlayDate +
     "&MovieName=" + MovieName + "&TVDate=" + TVDate + "&Mname=" + Mname + "&Mdate=" + Mdate + "&MClass=" + MClass);
}






function closeWin() {
    $('#Win').window('close');
}


function AjaxForSysChannelSearch(iFrameContent, Url) {

    //    var channel = iFrameContent.contents().find('#txtCollecte').val();

//    var name = $('#txtName').val();

//    if (name.indexOf('=') != -1) {
//        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
//        return false;
//    }

    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        //alert(location.href);
        location.href = Url;
        closeWin();
    })
}




