$(document).ready(function() {

    var flag = $('#txtFlag').val();
    var mac = $('#txtMac').val();
    $('#btnSel').click(function() {
        btnOkClick();
    });

    //    $('#btnCancel').click(function() {
    //        closeWin();
    //        //$('#subFrame').attr('src', $('#subFrame').attr('src'));
    //    });

    //    $('#btnOk').click(function() {

    //        btnOkClick();

    //    })



})

function btnOkClick() {
    var iFrameContent = $('#subFrame');

    var flag = $('#txtFlag').val();
    var mac = $('#txtMac').val();
    var name = $('#txtName').val();
    var className = $('#ddlClass').val();
    var PlayDate = $('#txtplaydate').val();
    var addDate = $('#txtAddDate').val();
    var MovieName = $('#txtMovieName').val();
    var TVDate = $('#txtDate').val();
    var Mname = $('#txtMname').val();
    var Mdate = $('#txtMdate').val();
    var MClass = $('#ddlIistClass').val();



    AjaxForSysChannelSearch(iFrameContent, '../../Manage/MacRight/Sys_Mac_Basic_More.aspx?flag=' + flag +
     "&mac=" + mac + "&name="+name+"&class="+className+"&playDate="+PlayDate+
     "&addDate=" + addDate + "&MovieName=" + MovieName + "&TVDate=" + TVDate + "&Mname=" + Mname + "&Mdate=" + Mdate + "&MClass="+MClass);

}

//function openwin(Title) {
//    $('#Win').window({
//        width: 580,
//        modal: true,
//        shadow: true,
//        closed: true,
//        height: 180,
//        top: 10,
//        left: 30,
//        resizable: false,
//        title: Title
//    });

//}

function btnSearchClick() {
//    openwin('查詢');
//    $('#Win').css("display", "block");
//    $('#Win').window('open');

//    var flag = $('#txtFlag').val();
//    var mac = $('#txtMac').val();

//    var iframe = $('#subFrame');
//    iframe[0].src = "Sys_Mac_Basic_More_Search.aspx?flag=" + flag+"&mac="+mac;
}



function closeWin() {
    $('#Win').window('close');
}


function AjaxForSysChannelSearch(iFrameContent, Url) {

    //    var channel = iFrameContent.contents().find('#txtCollecte').val();

    var name = $('#txtName').val();

    if (name.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        //alert(location.href);
        location.href = Url;
        closeWin();
    })
}




