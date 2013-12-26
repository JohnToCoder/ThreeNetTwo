$(document).ready(function() {
    var MacId = $('#txtId').val(); //RoleId
    var Mac = $('#txtRight').val();
    var MId = $('#txtMacId').val(); //macId

    var menuTypeId = 1;

    $('#imgmenu5>table>tbody>tr').children().eq(1).css('padding-left', '14px');

    $('#frameShow').attr('src', '../Manage/MacRight/Sys_Mac_basicInfo.aspx?MenuId=' + menuTypeId + "&MacId=" + MacId + "&mac=" + Mac + "&Mid=" + MId);
    $('.menu_title').eq(0).children().find('.STYLE1').addClass('ClickBg');
    $('.menu_title').each(function() {


        if (navigator.userAgent.indexOf("MSIE") > 0) {
            var nav = navigator.appVersion.split(';')[1].replace(/[ ]/g, '');
            if (nav == 'MSIE7.0' || nav == 'MSIE6.0') {
                $(this).parent().next().children().eq(0).height('5px');
            }
        }

        var menuTypeId = $(this).attr('title');

        $(this).click(function() {
            $('.ClickBg').removeClass('ClickBg');
            $(this).children().find('.STYLE1').addClass('ClickBg');

            SetChangePage(menuTypeId, MacId, Mac);
        });
    });

    $('#frameShow').height($('#leftDiv').height());

})


function SetChangePage(menuTypeId, MacId, Mac) {
    var MId = $('#txtMacId').val();  //macId
    switch (menuTypeId) {

        case "1":
            $('#frameShow').attr('src', '../Manage/MacRight/Sys_Mac_basicInfo.aspx?MenuId=' + menuTypeId + "&MacId=" + MacId + "&mac=" + Mac + "&Mid=" + MId);
            break;
        case "2":
            $('#frameShow').attr('src', '../Manage/MacRight/Sys_MacRight_Info.aspx?MenuId=' + menuTypeId + "&MacId=" + MacId + "&mac=" + Mac + "&Mid=" + MId);
            break;
        case "3":
            $('#frameShow').attr('src', '../Manage/MacRight/Sys_MacRight_Channel.aspx?MenuId=' + menuTypeId + "&MacId=" + MacId + "&mac=" + Mac + "&Mid=" + MId + "&keyValue=");
            break;
        case "4":
            $('#frameShow').attr('src', '../Manage/MacRight/Sys_MacRight_Movie.aspx?MenuId=' + menuTypeId + "&MacId=" + MacId + "&mac=" + Mac + "&Mid=" + MId + "&keyValue=");
            break;
        case "5":
            $('#frameShow').attr('src', '../Manage/MacRight/Sys_MacRight_TVPlay.aspx?MenuId=' + menuTypeId + "&MacId=" + MacId + "&mac=" + Mac + "&Mid=" + MId + "&keyValue=");
            break;
        case "6":
            $('#frameShow').attr('src', '../Manage/MacRight/Sys_MacRight_Music.aspx?MenuId=' + menuTypeId + "&MacId=" + MacId + "&mac=" + Mac + "&Mid=" + MId+"&keyValue=");
            break;
        case "7":
            $('#frameShow').attr('src', '../Manage/MacRight/Sys_MacRight_Photo.aspx?MenuId=' + menuTypeId + "&MacId=" + MacId + "&mac=" + Mac + "&Mid=" + MId + "&keyValue=");
            break;
    }
} 


