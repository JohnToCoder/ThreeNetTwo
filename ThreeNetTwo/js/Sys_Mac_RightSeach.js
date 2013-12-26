
$(document).ready(function() {
    $('#btnSel').click(function() {
        btnSearchClick();
    });

    $('#btnCancel').click(function() {
        closeWin();
        //$('#subFrame').attr('src', $('#subFrame').attr('src'));
    });

    $('#btnOk').click(function() {
    
         btnOkClick();

    })



})

function btnOkClick() {
    var iFrameContent = $('#subFrame');

    var MAC = $('#txtMacValue').val();
    var macId = $('#txtMacId').val();
    var type = $('#txtType').val();
    var Mid = $('#txtMid').val();

    switch (type) {

        case "3":
            AjaxForSysChannelSearch(iFrameContent, '../../Manage/MacRight/Sys_MacRight_Channel.aspx?MenuId=3' + "&mac=" + MAC + "&MacId="+macId+"&Mid="+Mid);
            break;
        case "4":
            AjaxForSysMovieSearch(iFrameContent, '../../Manage/MacRight/Sys_MacRight_Movie.aspx?MenuId=4' + "&mac=" + MAC + "&MacId=" + macId + "&Mid=" + Mid);
            break;
        case "5":
            AjaxForSysTVPlaySearch(iFrameContent, '../../Manage/MacRight/Sys_MacRight_TVPlay.aspx?MenuId=5' + "&mac=" + MAC + "&MacId=" + macId + "&Mid=" + Mid);
            break;
        case "6":
            AjaxForSysMusicSearch(iFrameContent, '../../Manage/MacRight/Sys_MacRight_Music.aspx?MenuId=6' + "&mac=" + MAC + "&MacId=" + macId + "&Mid=" + Mid);
            break;
        case "7":
            AjaxForSysPhotoSearch(iFrameContent, '../../Manage/MacRight/Sys_MacRight_Photo.aspx?MenuId=7' + "&mac=" + MAC + "&MacId=" + macId + "&Mid=" + Mid);
            break;  
            
    }
 

}


function AjaxForSysChannelSearch(iFrameContent, Url) {


    var ChannelClass = iFrameContent.contents().find('#ddlClass').val();

    var ChannelStartDate = iFrameContent.contents().find('#txtCStartDate').val();

    var ChannelEndDate = iFrameContent.contents().find('#txtCEndDate').val();


    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        //alert(location.href);
    location.href = Url + "&KeyValue=" + escape(ChannelClass) + '=' + escape(ChannelStartDate) + '=' + escape(ChannelEndDate);
        closeWin();
    })
}



function AjaxForSysMovieSearch(iFrameContent, Url) {

    var MovieName = iFrameContent.contents().find('#txtMovieName').val();

    var MovieStartDate = iFrameContent.contents().find('#txtMStartDate').val();

    var MovieEndDate = iFrameContent.contents().find('#txtMEndDate').val();

//    var type = $('#txtType').val();

//    if (type == "1") {

//        if (Movie.indexOf('=') != -1) {
//            $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
//            return false;
//        }
//    }


    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        //alert(location.href);
        location.href = Url + "&KeyValue=" + escape(MovieName) + '=' + escape(MovieStartDate) + '=' + escape(MovieEndDate);
        closeWin();
    })
}


function AjaxForSysTVPlaySearch(iFrameContent, Url) {

    var MovieName = iFrameContent.contents().find('#txtMovieName').val();

    var MovieStartDate = iFrameContent.contents().find('#txtMStartDate').val();

    var MovieEndDate = iFrameContent.contents().find('#txtMEndDate').val();

//    if (TVPlay.indexOf('=') != -1) {
//        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
//        return false;
//    }

    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        //alert(location.href);
        location.href = Url + "&KeyValue=" + escape(MovieName) + '=' + escape(MovieStartDate) + '=' + escape(MovieEndDate);
        closeWin();
    })
}


function AjaxForSysMusicSearch(iFrameContent, Url) {

    var MusicClass = iFrameContent.contents().find('#ddlIistClass').val();

    var MusicName = iFrameContent.contents().find('#txtMUName').val();

    var MusicStartDate = iFrameContent.contents().find('#txtPStartDate').val();

    var MusicEndDate = iFrameContent.contents().find('#txtPEndDate').val();
    
    
//    if (Music.indexOf('=') != -1) {
//        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
//        return false;
//    }

    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        //alert(location.href);
    location.href = Url + "&KeyValue=" + escape(MusicClass) + '=' + escape(MusicName) + '=' + escape(MusicStartDate) + '=' + escape(MusicEndDate);
        closeWin();
    })
}


function AjaxForSysPhotoSearch(iFrameContent, Url) {


    var MusicClass = iFrameContent.contents().find('#ddlIistClass').val();

    var MusicName = iFrameContent.contents().find('#txtMUName').val();

    var MusicStartDate = iFrameContent.contents().find('#txtPStartDate').val();

    var MusicEndDate = iFrameContent.contents().find('#txtPEndDate').val();
    var classtype = "";
   // var Photo = iFrameContent.contents().find('#txtPhoto').val();

//    if (Photo.indexOf('=') != -1) {
//        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
//        return false;
//    }

    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        //alert(location.href);
        location.href = Url + "&KeyValue=" + escape(MusicClass) + '=' + escape(MusicName) + '=' + escape(MusicStartDate) + '=' + escape(MusicEndDate);
        closeWin();
    })
}




function openwin(Title) {
    $('#Win').window({
        width: 580,
        modal: true,
        shadow: true,
        closed: true,
        height: 390,
        top: 10,
        left: 80,
        resizable: false,
        title: Title
    });

}

function btnSearchClick() {
    openwin('查詢');
    $('#Win').css("display", "block");
    $('#Win').window('open');

    var iframe = $('#subFrame');
    var type = $("#txtType").val();
    
    iframe[0].src = "Sys_Mac_Right_Edit.aspx?type="+type;
}


function closeWin() {
    $('#Win').window('close');
}


